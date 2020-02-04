using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmDetalleOrdenDeCompra : frmResponseBase
    {

        #region Constructores
        
        public frmDetalleOrdenDeCompra()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();

            if (VariablesLocales.oListaImpuestos != null && VariablesLocales.oListaImpuestos.Count > 0)
            {
                objImpuestoPeriodo = (from x in VariablesLocales.oListaImpuestos where x.idImpuesto == 1 select x).SingleOrDefault();//AgenteGeneral.Proxy.ObtenerImpuestosPeriodo(1, 1); 
            }
        }

        //Nuevo...
        public frmDetalleOrdenDeCompra(Int32 TipoArticulo_, String TipoCompra_, Boolean TipoPlanilla)
            :this()
        {
            TipoArticulo = TipoArticulo_;
            TipoCompra = TipoCompra_;

            if (TipoCompra_ == "N")
            {
                chkIgv.Checked = true;
            }
            else
            {
                chkIgv.Checked = false;
            }

            if (TipoPlanilla)
            {
                pnlBase.Enabled = false;
                pnlMontos.Enabled = false;
                btAceptar.Enabled = false;
            }
        }

        //Edición...
        public frmDetalleOrdenDeCompra(OrdenCompraItemE ItemTmp, String numOrdenTmp, Int32 TipoArticulo_, String TipoCompra_, Boolean TipoPlanilla)
            :this()
        {
            oOrdenCompraDetalle = ItemTmp;
            numOrdenCompra = numOrdenTmp;
            TipoArticulo = TipoArticulo_;
            TipoCompra = TipoCompra_;

            if (TipoCompra_ == "N")
            {
                chkIgv.Checked = true;
            }
            else
            {
                chkIgv.Checked = false;
            }

            if (TipoPlanilla)
            {
                pnlBase.Enabled = false;
                pnlMontos.Enabled = false;
                btAceptar.Enabled = false;
            }
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        public OrdenCompraItemE oOrdenCompraDetalle = null;
        String numOrdenCompra = String.Empty;
        Int32 TipoArticulo = 0;
        String TipoCompra = "";
        ImpuestosPeriodoE objImpuestoPeriodo = null;
        //Boolean BloquerForm = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            try
            {
                List<UMedidaE> ListaUnidades = AgenteGeneral.Proxy.ListarUMedida("%");
                ListaUnidades.Add(new UMedidaE() { idUMedida = Variables.Cero, NomUMedida = Variables.Seleccione });
                ComboHelper.RellenarCombos<UMedidaE>(cboUnidadMedida, (from x in ListaUnidades orderby x.idUMedida select x).ToList(), "idUMedida", "NomUMedida", false);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void Calcular()
        {
            txtPrecioTotal.TextChanged -= txtPrecioTotal_TextChanged;
            
            #region Variables

            Decimal CantidadOrd = Variables.ValorCeroDecimal;
            Decimal PrecioUnitario = Variables.ValorCeroDecimal;
            Decimal Igv = Variables.Cero;
            Decimal porIgv = Variables.Cero;
            Decimal PorDscto = Variables.Cero;
            Decimal Dscto = Variables.Cero;
            Decimal SubTotal = Variables.Cero;
            Decimal Total = Variables.ValorCeroDecimal;

            #endregion

            Decimal.TryParse(txtCantOrdenada.Text, out CantidadOrd); //Cantidad  
            Decimal.TryParse(txtPrecioUnitario.Text, out PrecioUnitario); //Precio

            //Descuento
            Decimal.TryParse(txtPorDscto.Text, out PorDscto);
            txtDscto.Text = ((CantidadOrd * PrecioUnitario) * (PorDscto / 100)).ToString("N2");
            Decimal.TryParse(txtDscto.Text, out Dscto);

            //Subtotal
            txtSubTotal.Text = ((CantidadOrd * PrecioUnitario) - Dscto).ToString("N2");
            Decimal.TryParse(txtSubTotal.Text, out SubTotal);

            //Impuesto General a la Venta
            Decimal.TryParse(txtPorIgv.Text, out porIgv);
            txtIgv.Text = (SubTotal * (porIgv / 100)).ToString("N2");
            Decimal.TryParse(txtIgv.Text, out Igv);
            
            //Total General
            Total = SubTotal + Igv;
            txtPrecioTotal.Text = Total.ToString("N2");
            //txtPrecioVenta.Text = (ValorVenta + Isc + Igv).ToString("N2");

            txtPrecioTotal.TextChanged += txtPrecioTotal_TextChanged;
        }

        void CalcularReves()
        {
            txtPrecioUnitario.TextChanged -= txtPrecioUnitario_TextChanged;
            txtCantOrdenada.TextChanged -= txtCantOrdenada_TextChanged;

            Decimal Total = Variables.ValorCeroDecimal;
            Decimal subTotal = Variables.ValorCeroDecimal;
            Decimal CantidadOrd = Variables.ValorCeroDecimal;
            Decimal PrecioUnitario = Variables.ValorCeroDecimal;
            Decimal porIgv = Variables.Cero;

            Decimal.TryParse(txtPrecioTotal.Text, out Total);
            Decimal.TryParse(txtCantOrdenada.Text, out CantidadOrd);
            Decimal.TryParse(txtPrecioUnitario.Text, out PrecioUnitario);
            
            //Impuesto General a la Venta
            Decimal.TryParse(txtPorIgv.Text, out porIgv);
            subTotal = Total / ((porIgv / 100) + 1);
            txtIgv.Text = (subTotal * (porIgv / 100)).ToString("N2");

            //Sub Total
            txtSubTotal.Text = subTotal.ToString("N2");

            //Cantidad y Precio Unitario
            if (CantidadOrd > 0)
            {
                PrecioUnitario = subTotal / CantidadOrd;
                txtPrecioUnitario.Text = PrecioUnitario.ToString("N6");
            }
            else if (PrecioUnitario > 0)
            {
                CantidadOrd = subTotal / PrecioUnitario;
                txtCantOrdenada.Text = CantidadOrd.ToString("N2");
            }

            txtPrecioUnitario.TextChanged += txtPrecioUnitario_TextChanged;
            txtCantOrdenada.TextChanged += txtCantOrdenada_TextChanged;
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            if (oOrdenCompraDetalle == null)
            {
                oOrdenCompraDetalle = new OrdenCompraItemE();

                oOrdenCompraDetalle.UsuarioRegistro = txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtCantOrdenada.Text = oOrdenCompraDetalle.CanOrdenada.ToString("N4");
                txtPrecioUnitario.Text = oOrdenCompraDetalle.impPrecioUnitario.ToString("N6");
                txtPorDscto.Text = oOrdenCompraDetalle.porDescuento.ToString("N2");
                txtPrecioTotal.Text = oOrdenCompraDetalle.impTotalItem.ToString("N2");
                txtUltimaCompra.Text = Convert.ToDecimal(oOrdenCompraDetalle.impPrecioUltimaCompra).ToString("N2");
                txtLote.Text = oOrdenCompraDetalle.Lote = "0000000";
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                oOrdenCompraDetalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCantOrdenada.TextChanged -= txtCantOrdenada_TextChanged;
                txtPrecioUnitario.TextChanged -= txtPrecioUnitario_TextChanged;
                txtPorDscto.TextChanged -= txtPorDscto_TextChanged;
                chkIgv.CheckedChanged -= chkIgv_CheckedChanged;
                txtPorIgv.TextChanged -= txtPorIgv_TextChanged;
                txtPrecioTotal.TextChanged -= txtPrecioTotal_TextChanged;
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                txtNroCompra.Text = numOrdenCompra;
                txtNumItem.Text = oOrdenCompraDetalle.numItem;
                txtLote.Text = oOrdenCompraDetalle.Lote;
                txtIdArticulo.Text = oOrdenCompraDetalle.idArticuloServ.ToString();
                txtCodArticulo.Text = oOrdenCompraDetalle.codArticulo;
                txtDesArticulo.Text = oOrdenCompraDetalle.desArticulo;
                txtEspecificacion.Text = oOrdenCompraDetalle.desLarga;
                cboUnidadMedida.SelectedValue = Convert.ToInt32(oOrdenCompraDetalle.idUMedidaCompra);
                txtCantOrdenada.Text = oOrdenCompraDetalle.CanOrdenada.ToString("N4");
                txtPrecioUnitario.Text = oOrdenCompraDetalle.impPrecioUnitario.ToString("N6");
                txtPorDscto.Text = oOrdenCompraDetalle.porDescuento.ToString("N2");
                txtDscto.Text = oOrdenCompraDetalle.impDscto.ToString("N2");
                txtSubTotal.Text = oOrdenCompraDetalle.impVentaItem.ToString("N2");
                chkIgv.Checked = oOrdenCompraDetalle.indIgv;
                txtPorIgv.Text = oOrdenCompraDetalle.porIgv.ToString("N2");
                txtIgv.Text = oOrdenCompraDetalle.impIgv.ToString("N2");
                txtPrecioTotal.Text = oOrdenCompraDetalle.impTotalItem.ToString("N2");
                txtUltimaCompra.Text = Convert.ToDecimal(oOrdenCompraDetalle.impPrecioUltimaCompra).ToString("N2");

                txtUsuarioRegistro.Text = oOrdenCompraDetalle.UsuarioRegistro;
                txtUsuarioModificacion.Text = oOrdenCompraDetalle.UsuarioModificacion;
                txtFechaRegistro.Text = oOrdenCompraDetalle.FechaRegistro.ToString();
                txtFechaModificacion.Text = oOrdenCompraDetalle.FechaModificacion.ToString();

                oOrdenCompraDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                if (oOrdenCompraDetalle.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oOrdenCompraDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtCantOrdenada.TextChanged += txtCantOrdenada_TextChanged;
                txtPrecioUnitario.TextChanged += txtPrecioUnitario_TextChanged;
                txtPorDscto.TextChanged += txtPorDscto_TextChanged;
                chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                txtPorIgv.TextChanged += txtPorIgv_TextChanged;
                txtPrecioTotal.TextChanged += txtPrecioTotal_TextChanged;
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (cboUnidadMedida.SelectedIndex == 0)
                {
                    Global.MensajeFault("Seleccione la Unidad de Medida");
                    btArticulo.Focus();
                    return;
                }

                oOrdenCompraDetalle = new OrdenCompraItemE()
                {
                    numItem = txtNumItem.Text,
                    idArticuloServ = Convert.ToInt32(txtIdArticulo.Text),
                    codArticulo = txtCodArticulo.Text.Trim(),
                    Lote = txtLote.Text,
                    FechaEntrega = VariablesLocales.FechaHoy.Date,
                    CanOrdenada = Convert.ToDecimal(txtCantOrdenada.Text),
                    CanIngresada = Variables.ValorCeroDecimal,
                    canProvisionada = 0M,
                    impPrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text),
                    impVentaItem = Convert.ToDecimal(txtSubTotal.Text),
                    porDescuento = Convert.ToDecimal(txtPorDscto.Text),
                    impDscto = Convert.ToDecimal(txtDscto.Text),
                    porIsc = Variables.ValorCeroDecimal,
                    impIsc = Variables.ValorCeroDecimal,
                    indIgv = chkIgv.Checked,
                    porIgv = chkIgv.Checked ? Convert.ToDecimal(txtPorIgv.Text) : Variables.ValorCeroDecimal,
                    impIgv = chkIgv.Checked ? Convert.ToDecimal(txtIgv.Text) : Variables.ValorCeroDecimal,
                    impTotalItem = Convert.ToDecimal(txtPrecioTotal.Text),
                    desLarga = txtEspecificacion.Text,
                    idUMedidaCompra = Convert.ToInt32(cboUnidadMedida.SelectedValue),
                    desArticulo = txtDesArticulo.Text,
                    PartidaArancelaria = String.Empty,
                    FechaRecepcionFinal = (Nullable<DateTime>)null,
                    tipEstadoAtencion = oOrdenCompraDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar ? EnumEstadoOC.PN.ToString() : oOrdenCompraDetalle.tipEstadoAtencion,
                    impPrecioUltimaCompra = Variables.ValorCeroDecimal,
                    numItemRequerimiento = String.Empty,
                    nroParteProduccion = String.Empty,
                    UsuarioRegistro = txtUsuarioRegistro.Text,
                    UsuarioModificacion = txtUsuarioModificacion.Text,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    FechaModificacion = VariablesLocales.FechaHoy
                };

                base.Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmDetalleOrdenDeCompra_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btArticulo_Click(object sender, EventArgs e)
        {
            frmBuscarArticulo oFrm = new frmBuscarArticulo(TipoArticulo, TipoCompra);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
            {
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                txtIdArticulo.Text = oFrm.Articulo.idArticulo.ToString();
                txtDesArticulo.Text = oFrm.Articulo.nomArticulo;
                txtCodArticulo.Text = oFrm.Articulo.codArticulo;

                cboUnidadMedida.SelectedValue = oFrm.Articulo.codUniMedAlmacen;
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            }
        }

        private void txtCantOrdenada_Leave(object sender, EventArgs e)
        {
            txtCantOrdenada.Text = Global.FormatoDecimal(txtCantOrdenada.Text, 4);
        }

        private void txtPrecioUnitario_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPrecioUnitario.Text = Global.FormatoDecimal(txtPrecioUnitario.Text, 6);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            txtPorDscto.Text = Global.FormatoDecimal(txtPorDscto.Text);
        }

        private void txtPrecioTotal_Leave(object sender, EventArgs e)
        {
            txtPrecioTotal.Text = Convert.ToDecimal(txtPrecioTotal.Text).ToString("N2");
        }

        private void txtUltimaCompra_Leave(object sender, EventArgs e)
        {
            txtUltimaCompra.Text = Convert.ToDecimal(txtUltimaCompra.Text).ToString("N2");
        }

        private void txtCantOrdenada_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtCantOrdenada_Enter(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCantOrdenada.Text) == 0M)
            {
                txtCantOrdenada.SelectAll();
            }
            else
            {
                Int32 Punto = txtCantOrdenada.Text.IndexOf(".");
                String Decimales = txtCantOrdenada.Text.Substring(Punto + 1);
                txtCantOrdenada.Select(Punto + 1, Decimales.Length);
            }
        }

        private void txtCantOrdenada_MouseClick(object sender, MouseEventArgs e)
        {
            if (Convert.ToDecimal(txtCantOrdenada.Text) == 0M)
            {
                txtCantOrdenada.SelectAll();
            }
            else
            {
                Int32 Punto = txtCantOrdenada.Text.IndexOf(".");
                String Decimales = txtCantOrdenada.Text.Substring(Punto + 1);
                txtCantOrdenada.Select(Punto + 1, Decimales.Length);
            }
        }

        private void txtPrecioUnitario_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtPrecioUnitario.Text) == 0)
                {
                    txtPrecioUnitario.SelectAll();
                }
                else
                {
                    Int32 Punto = txtPrecioUnitario.Text.IndexOf(".");
                    String Decimales = txtPrecioUnitario.Text.Substring(Punto + 1);
                    txtPrecioUnitario.Select(Punto + 1, Decimales.Length);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtPrecioUnitario_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtPrecioUnitario.Text) == 0)
                {
                    txtPrecioUnitario.SelectAll();
                }
                else
                {
                    Int32 Punto = txtPrecioUnitario.Text.IndexOf(".");
                    String Decimales = txtPrecioUnitario.Text.Substring(Punto + 1);
                    txtPrecioUnitario.Select(Punto + 1, Decimales.Length);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtPrecioTotal_TextChanged(object sender, EventArgs e)
        {
            CalcularReves();
        }

        private void txtCodArticulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<ArticuloServE> oListaArticulos = AgenteMaestros.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa, TipoArticulo, txtCodArticulo.Text.Trim(), "");

                    if (oListaArticulos.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                            //numVerPlanCuentas = oFrm.oArticulo.numVerPlanCuentas;

                            //if (tipoCCosto == "1")
                            //{
                            //    codCuenta = oFrm.oArticulo.codCuentaAdm;
                            //}
                            //if (tipoCCosto == "2")
                            //{
                            //    codCuenta = oFrm.oArticulo.codCuentaVta;
                            //}
                            //if (tipoCCosto == "3")
                            //{
                            //    codCuenta = oFrm.oArticulo.codCuentaPro;
                            //}

                            cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;
                        }
                    }
                    else if (oListaArticulos.Count == 1)
                    {
                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                        //numVerPlanCuentas = oListaArticulos[0].numVerPlanCuentas;

                        //if (tipoCCosto == "1")
                        //{
                        //    codCuenta = oListaArticulos[0].codCuentaAdm;
                        //}

                        //if (tipoCCosto == "2")
                        //{
                        //    codCuenta = oListaArticulos[0].codCuentaVta;
                        //}

                        //if (tipoCCosto == "3")
                        //{
                        //    codCuenta = oListaArticulos[0].codCuentaPro;
                        //}

                        cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);
                    }
                    else
                    {
                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                        txtIdArticulo.Text = string.Empty;
                        txtCodArticulo.Text = string.Empty;
                        txtDesArticulo.Text = string.Empty;
                        //numVerPlanCuentas = string.Empty;
                        txtLote.Text = "0000000";
                        txtCodArticulo.Focus();
                    }

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesArticulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && !string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<ArticuloServE> oListaArticulos = AgenteMaestros.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa, TipoArticulo, "", txtDesArticulo.Text.Trim());

                    if (oListaArticulos.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                            //numVerPlanCuentas = oFrm.oArticulo.numVerPlanCuentas;

                            //if (tipoCCosto == "1")
                            //{
                            //    codCuenta = oFrm.oArticulo.codCuentaAdm;
                            //}
                            //if (tipoCCosto == "2")
                            //{
                            //    codCuenta = oFrm.oArticulo.codCuentaVta;
                            //}
                            //if (tipoCCosto == "3")
                            //{
                            //    codCuenta = oFrm.oArticulo.codCuentaPro;
                            //}

                            cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                        }
                    }
                    else if (oListaArticulos.Count == 1)
                    {
                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                        //numVerPlanCuentas = oListaArticulos[0].numVerPlanCuentas;

                        //if (tipoCCosto == "1")
                        //{
                        //    codCuenta = oListaArticulos[0].codCuentaAdm;
                        //}

                        //if (tipoCCosto == "2")
                        //{
                        //    codCuenta = oListaArticulos[0].codCuentaVta;
                        //}

                        //if (tipoCCosto == "3")
                        //{
                        //    codCuenta = oListaArticulos[0].codCuentaPro;
                        //}

                        cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);
                    }
                    else
                    {
                        Global.MensajeFault("El descripción ingresada no existe, vuelva a probar por favor.");
                        txtIdArticulo.Text = string.Empty;
                        txtCodArticulo.Text = string.Empty;
                        txtDesArticulo.Text = string.Empty;
                        //numVerPlanCuentas = string.Empty;
                        txtLote.Text = "0000000";
                        txtCodArticulo.Focus();
                    }

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtDesArticulo.Text = string.Empty;
        }

        private void txtDesArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtCodArticulo.Text = string.Empty;
        }

        private void cboUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void chkIgv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIgv.Checked)
            {

                if (objImpuestoPeriodo != null)
                {
                    txtPorIgv.Text = (objImpuestoPeriodo.Porcentaje).ToString(); 
                }
                else
                {
                    txtPorIgv.Text = "0.00";
                }
            }
            else
            {
                txtPorIgv.Text = "0.00";
            }
        }

        private void txtPorIgv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtPorDscto_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }        

        private void txtPorDscto_Enter(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtPorDscto.Text) == 0M)
            {
                txtPorDscto.SelectAll();
            }
            else
            {
                Int32 Punto = txtPorDscto.Text.IndexOf(".");
                String Decimales = txtPorDscto.Text.Substring(Punto + 1);
                txtPorDscto.Select(Punto + 1, Decimales.Length);
            }
        }

        private void txtPorDscto_MouseClick(object sender, MouseEventArgs e)
        {
            if (Convert.ToDecimal(txtPorDscto.Text) == 0M)
            {
                txtPorDscto.SelectAll();
            }
            else
            {
                Int32 Punto = txtPorDscto.Text.IndexOf(".");
                String Decimales = txtPorDscto.Text.Substring(Punto + 1);
                txtPorDscto.Select(Punto + 1, Decimales.Length);
            }
        }

        #endregion

    }
}
