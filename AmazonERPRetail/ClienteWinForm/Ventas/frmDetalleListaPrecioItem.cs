using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmDetalleListaPrecioItem : frmResponseBase
    {

        #region Contructor

        public frmDetalleListaPrecioItem()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            //frmDetalleListaPrecioItem.WindowState = FormWindowState.Normal;
           // this.WindowState = FormWindowState.Maximized;
            LlenarComboBox();
            btBuscarArticulo.Focus();
        }

        //Nuevo
        public frmDetalleListaPrecioItem(List<ListaPrecioItemE> oLista = null)
            : this()
        {
            oListaPrecioItem = oLista;
        }

        //Editar
        public frmDetalleListaPrecioItem(ListaPrecioItemE oPrecioTemp_, Boolean Bloqueo_ = false, List<ListaPrecioItemE> oLista = null)
            : this()
        {
            oPrecioItem = oPrecioTemp_;
            oListaPrecioItem = oLista;
            Bloqueo = Bloqueo_;
        }
        
        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public ListaPrecioItemE oPrecioItem = null;
        List<ListaPrecioItemE> oListaPrecioItem = null;
        Boolean Bloqueo = false;
        
        #endregion Variables

        #region Procedimientos de Usuario

        private void LlenarComboBox()
        {
            List<ParTabla> ListaTipoUnidad = AgenteGeneral.Proxy.ListarParTablaPorNemo("UMED");
            ListaTipoUnidad.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
        }

        private Boolean ValidarArticulos()
        {
            if (String.IsNullOrEmpty(txtCodArticulo.Text.Trim()))
            {
                Global.MensajeFault("Debe escoger un articulo.");
                btBuscarArticulo.Focus();
                return false;
            }

            //if (String.IsNullOrWhiteSpace(txtPrecio.Text.Trim()) || txtPrecio.Text == "0.00")
            //{
            //    Global.MensajeFault("Debe la colocar el precio.");
            //    txtPrecio.Focus();
            //    return false;
            //}

            if (oListaPrecioItem != null && oListaPrecioItem.Count > Variables.Cero)
            {
                List<ListaPrecioItemE> oListaTemp = new List<ListaPrecioItemE>((from x in oListaPrecioItem
                                                                                where x.idArticulo == Convert.ToInt32(txtIdArticulo.Text.Trim())
                                                                                select x).ToList());
                if (oListaTemp.Count > Variables.Cero)
                {
                    Global.MensajeFault("El articulo ya se encuentra añadido en la lista, cambie de código o modifique el articulo correspondiente.");
                    oListaTemp = null;
                    btBuscarArticulo.Focus();
                    return false;
                }
            }

            if (chImpuesto.Checked)
            {
                decimal.TryParse(txtPorIgv.Text, out decimal porIgv);

                if (porIgv <= 0)
                {
                    Global.MensajeFault("El check de IGV esta activado, pero no existe el porcentaje o falta configurar en el Maestro de Impuestos.");
                    return false;
                }
            }

            if (ChkImpuestoD.Checked)
            {
                decimal.TryParse(TxtPorcIgvD.Text, out decimal porIgv);

                if (porIgv <= 0)
                {
                    Global.MensajeFault("El check de IGV esta activado, pero no existe el porcentaje o falta configurar en el Maestro de Impuestos.");
                    return false;
                }
            }

            //if (!string.IsNullOrWhiteSpace(TxtMedidaD.Text))
            int.TryParse(txtContenido.Text, out int nContenido);
                if (nContenido > 1)
                {
                decimal.TryParse(TxtPrecioD.Text, out decimal precioD);

                if (precioD <= 0M)
                {
                    Global.MensajeFault("Tiene Unidad de medida de detalle, tiene que colocar un Precio.");
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(TxtMedida.Text))
            {
                decimal.TryParse(txtPrecio.Text, out decimal precio);

                if (precio <= 0M)
                {
                    Global.MensajeFault("Tiene Unidad de medida de almacenamiento, tiene que colocar un Precio.");
                    return false;
                }
            }

            return true;
        }

        private void Calcular()
        {


            txtPrecVta.TextChanged -= txtPrecVta_TextChanged;

            #region Variables

            decimal.TryParse(txtPrecio.Text, out decimal Precio);
            decimal.TryParse(txtPorIgv.Text, out decimal porIgv);
            decimal ValorVenta = Variables.ValorCeroDecimal;

            #endregion

            //Impuesto General a la Venta   
            if (chImpuesto.Checked && porIgv > 0)
            {
                ValorVenta = Precio * (1 + (porIgv / 100));
            }

            //Total General
            txtPrecVta.Text = ValorVenta.ToString("N2");

            txtPrecVta.TextChanged += txtPrecVta_TextChanged;
        }
        private void CalcularReves()
        {
            txtPrecio.TextChanged -= txtPrecio_TextChanged;

            chImpuesto.Checked = true;
            decimal.TryParse(txtPrecVta.Text, out decimal PrecioIncIgv);
            decimal.TryParse(txtPorIgv.Text, out decimal porIgv);
            decimal Valor = Variables.ValorCeroDecimal;

            //Impuesto General a la Venta   
            if (chImpuesto.Checked && porIgv > 0)
            {
                Valor = PrecioIncIgv / (1 + (porIgv / 100));
            }

            txtPrecio.Text = Valor.ToString("N2");

            txtPrecio.TextChanged += txtPrecio_TextChanged;
          
        }

        private void CalcularPrecioD()
        {
            TxtPrecVtaD.TextChanged -= TxtPrecVtaD_TextChanged;

            #region Variables

            decimal.TryParse(TxtPrecioD.Text, out decimal Precio);
            decimal.TryParse(TxtPorcIgvD.Text, out decimal porIgv);
            decimal ValorVenta = Variables.ValorCeroDecimal;

            #endregion

            //Impuesto General a la Venta   
            if (chImpuesto.Checked && porIgv > 0)
            {
                ValorVenta = Precio * (1 + (porIgv / 100));
            }

            //Total General
            TxtPrecVtaD.Text = ValorVenta.ToString("N2");

            TxtPrecVtaD.TextChanged += TxtPrecVtaD_TextChanged;
        }

        private void CalcularRevesPrecioD()
        {
            TxtPrecioD.TextChanged -= TxtPrecioD_TextChanged;

            Decimal Total = Variables.ValorCeroDecimal;
            Decimal subTotal = Variables.ValorCeroDecimal;
            Decimal CantidadOrd = 1M;
            Decimal PrecioUnitario = Variables.ValorCeroDecimal;
            Decimal porIgv = Variables.Cero;

            Decimal.TryParse(TxtPrecVtaD.Text, out Total);
            Decimal.TryParse(TxtPrecioD.Text, out PrecioUnitario);

            //Impuesto General a la Venta
            Decimal.TryParse(TxtPorcIgvD.Text, out porIgv);
            subTotal = Total / ((porIgv / 100) + 1);
            //txtIgvD.Text = (subTotal * (porIgv / 100)).ToString("N2");

            //Sub Total
            //TxtValVentaD.Text = subTotal.ToString("N2");

            //Cantidad y Precio Unitario
            if (CantidadOrd > 0)
            {
                PrecioUnitario = subTotal / CantidadOrd;
                TxtPrecioD.Text = PrecioUnitario.ToString("N2");
            }

            TxtPrecioD.TextChanged += TxtPrecioD_TextChanged;
        }


        void CalcularKit(int codigo )
        {
     

        }
        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oPrecioItem == null)
            {
                oPrecioItem = new ListaPrecioItemE
                {
                    Opcion = (Int32)EnumOpcionGrabar.Insertar,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                //cboImpSelectivo.SelectedValue = "N";
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (oPrecioItem.Opcion == 0)
                {
                    oPrecioItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                chImpuesto.CheckedChanged -= chImpuesto_CheckedChanged;
                ChkImpuestoD.CheckedChanged -= ChkImpuestoD_CheckedChanged;
                txtPrecio.TextChanged -= txtPrecio_TextChanged;
                TxtPrecioD.TextChanged -= TxtPrecioD_TextChanged;
                txtPorDscto.TextChanged -= txtPorcDsct1_TextChanged;
                TxtPorDctoD.TextChanged -= TxtPorDctoD_TextChanged;
                txtPorIgv.TextChanged -= txtPorcIgv_TextChanged;
                TxtPorcIgvD.TextChanged -= TxtPorcIgvD_TextChanged;
                txtPrecVta.TextChanged -= txtPrecVta_TextChanged;
                TxtPrecVtaD.TextChanged -= TxtPrecVtaD_TextChanged;

                txtIdArticulo.Text = Convert.ToString(oPrecioItem.idArticulo);
                txtCodArticulo.Text = oPrecioItem.codArticulo;
                txtDesArticulo.Text = Convert.ToString(oPrecioItem.desArticulo);
                txtIdTipoArticulo.Text = Convert.ToString(oPrecioItem.idTipoArticulo);
                txtTipoArticulo.Text = oPrecioItem.desTipoArticulo;
                txtCapacidad.Text = oPrecioItem.Capacidad.ToString("N2");
                txtContenido.Text = oPrecioItem.Contenido.ToString("N2");
                txtPrecio.Text = oPrecioItem.PrecioBruto.ToString("N2");
                txtPorDscto.Text = oPrecioItem.PorDscto1.ToString("N2");
                //txtDsct1.Text = oPrecioItem.MontoDscto1.ToString("N2");
                //txtPorcDsct2.Text = oPrecioItem.PorDscto2.ToString("N2");
                //txtDsct2.Text = oPrecioItem.MontoDscto2.ToString("N2");
                //txtPorcDsct3.Text = oPrecioItem.PorDscto3.ToString("N2");
                //txtDsct3.Text = oPrecioItem.MontoDscto3.ToString("N2");
                //txtValVenta.Text = oPrecioItem.PrecioValorVenta.ToString("N2");
                //chIsc.Checked = oPrecioItem.flgisc;
                //cboImpSelectivo.Enabled = oPrecioItem.flgisc;
                //cboImpSelectivo.SelectedValue = oPrecioItem.TipoImpSelectivo;
                //txtPorcIsc.Text = oPrecioItem.porisc.ToString("N2");

                //if (chIsc.Checked)
                //{
                //    cboImpSelectivo.Enabled = true;
                //    txtPorcIsc.Enabled = true;
                //    txtPorcIsc.ReadOnly = false;
                //    txtPorcIsc.BackColor = System.Drawing.SystemColors.Window;
                //}
                //else
                //{
                //    cboImpSelectivo.Enabled = false;
                //    txtPorcIsc.Enabled = false;
                //    txtPorcIsc.ReadOnly = true;
                //    txtPorcIsc.BackColor = System.Drawing.SystemColors.InactiveCaption;
                //}

                //txtIsc.Text = oPrecioItem.isc.ToString("N2");
                txtPorIgv.Text = Convert.ToString(oPrecioItem.porigv);
                chImpuesto.Checked = oPrecioItem.flgigv;
                //TxtIgv.Text = oPrecioItem.igv.ToString("N2");
                txtPrecVta.Text = oPrecioItem.PrecioVenta.ToString("N2");
                //txtValVentaConte.Text = oPrecioItem.PrecioVentaConte.ToString("N2");
                //txtValBrutoConte.Text = oPrecioItem.PrecioBrutoConte.ToString("N2");

                TxtMedida.Tag = Convert.ToInt32(oPrecioItem.IdUMedida);
                TxtMedida.Text = oPrecioItem.nomUMedida;
                TxtMedidaD.Tag = Convert.ToInt32(oPrecioItem.IdUMedidaD);
                TxtMedidaD.Text = oPrecioItem.nomUMedidaEnv;
                TxtPrecioD.Text = oPrecioItem.PrecioD.ToString("N2");
                TxtPorDctoD.Text = oPrecioItem.PorDsctoD.ToString("N2");
                //TxtDsctoD.Text = oPrecioItem.MontoDsctoD.ToString("N2");
                //TxtValVentaD.Text = oPrecioItem.PrecioValorVentaD.ToString("N2");
                ChkImpuestoD.Checked = oPrecioItem.FlgIgvD;
                TxtPorcIgvD.Text = oPrecioItem.PorIgvD.ToString("N2");
                //txtIgvD.Text = oPrecioItem.IgvD.ToString("N2");
                TxtPrecVtaD.Text = oPrecioItem.PrecioVentaD.ToString("N2");

                txtUsuarioRegistro.Text = oPrecioItem.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(oPrecioItem.FechaRegistro);
                txtUsuarioModificacion.Text = oPrecioItem.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(oPrecioItem.FechaModificacion);

                PnlUma.Enabled = oPrecioItem.IdUMedida > 0;
                PnlUmd.Enabled = oPrecioItem.Contenido > 1;

                chImpuesto.CheckedChanged += chImpuesto_CheckedChanged;
                ChkImpuestoD.CheckedChanged += ChkImpuestoD_CheckedChanged;
                txtPrecio.TextChanged += txtPrecio_TextChanged;
                TxtPrecioD.TextChanged += TxtPrecioD_TextChanged;
                txtPorDscto.TextChanged += txtPorcDsct1_TextChanged;
                TxtPorDctoD.TextChanged += TxtPorDctoD_TextChanged;
                txtPorIgv.TextChanged += txtPorcIgv_TextChanged;
                TxtPorcIgvD.TextChanged += TxtPorcIgvD_TextChanged;
                txtPrecVta.TextChanged += txtPrecVta_TextChanged;
                TxtPrecVtaD.TextChanged += TxtPrecVtaD_TextChanged;
            }

            //string contenido = txtContenido.Text;
            //double con = Convert.ToDouble(contenido);
            //if (con == 0.00)
            //{
            //    txtPrecio.Enabled = false;
            //}
            //else
            //{
            //    txtPrecio.Enabled = true;
            //}

            if (Bloqueo)
            {
                pnlBase.Enabled = false;
                PnlUma.Enabled = false;
                btAceptar.Enabled = false;
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarArticulos())
                {
                    if (oPrecioItem != null)
                    {
                        decimal.TryParse(txtPrecio.Text, out decimal Precio);
                        decimal.TryParse(txtPorIgv.Text, out decimal porIgv);
                        decimal.TryParse(txtPrecVta.Text, out decimal PrecioInlIgv);
                        decimal.TryParse(txtPorDscto.Text, out decimal porDscto);
                        decimal.TryParse(TxtPrecioD.Text, out decimal PrecioD);
                        decimal.TryParse(TxtPorcIgvD.Text, out decimal porIgvD);
                        decimal.TryParse(TxtPrecVtaD.Text, out decimal PrecioInlIgvD);
                        decimal.TryParse(TxtPorDctoD.Text, out decimal porDsctoD);

                        oPrecioItem.idTipoArticulo = Convert.ToInt32(txtIdTipoArticulo.Text);
                        oPrecioItem.desTipoArticulo = txtTipoArticulo.Text;
                        oPrecioItem.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
                        oPrecioItem.codArticulo = txtCodArticulo.Text;
                        oPrecioItem.desArticulo = txtDesArticulo.Text;

                        oPrecioItem.PrecioBruto = chImpuesto.Checked == true ? decimal.Round(PrecioInlIgv / (1 + (porIgv / 100)), 5) : Precio;
                        oPrecioItem.PorDscto1 = porDscto;
                        oPrecioItem.PorDscto2 = 0M; //Convert.ToDecimal(txtPorcDsct2.Text);
                        oPrecioItem.PorDscto3 = 0M; //Convert.ToDecimal(txtPorcDsct3.Text);
                        oPrecioItem.MontoDscto1 = 0M;// Convert.ToDecimal(txtDsct1.Text);
                        oPrecioItem.MontoDscto2 = 0M; //Convert.ToDecimal(txtDsct2.Text);
                        oPrecioItem.MontoDscto3 = 0M; //Convert.ToDecimal(txtDsct3.Text);
                        oPrecioItem.PrecioValorVenta = 0M;// Convert.ToDecimal(txtValVenta.Text);

                        oPrecioItem.flgisc = false; //chIsc.Checked;
                        oPrecioItem.TipoImpSelectivo = "N"; //Convert.ToString(cboImpSelectivo.SelectedValue);
                        oPrecioItem.porisc = 0M; //Convert.ToDecimal(txtPorcIsc.Text);
                        oPrecioItem.isc = 0M; //Convert.ToDecimal(txtIsc.Text);
                        oPrecioItem.flgigv = chImpuesto.Checked;
                        oPrecioItem.porigv = porIgv;
                        oPrecioItem.igv = 0M; // Convert.ToDecimal(TxtIgv.Text);
                        oPrecioItem.PrecioVenta = PrecioInlIgv;
                        oPrecioItem.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
                        oPrecioItem.Contenido = Convert.ToDecimal(txtContenido.Text);
                        oPrecioItem.PrecioVentaConte = 0M; //Convert.ToDecimal(txtValVentaConte.Text);
                        oPrecioItem.PrecioBrutoConte = 0M; //Convert.ToDecimal(txtValBrutoConte.Text);

                        if (oPrecioItem.TipoImpSelectivo == "P")
                        {
                            oPrecioItem.desTipoImpSelectivo = "Porcentaje";
                        }
                        else if (oPrecioItem.TipoImpSelectivo == "L")
                        {
                            oPrecioItem.desTipoImpSelectivo = "Litro";
                        }
                        else
                        {
                            oPrecioItem.desTipoImpSelectivo = "Ninguno";
                        }

                        oPrecioItem.IdUMedida = Convert.ToInt32(TxtMedida.Tag);
                        oPrecioItem.IdUMedidaD = Convert.ToInt32(TxtMedidaD.Tag);
                        oPrecioItem.PrecioD = ChkImpuestoD.Checked == true ? decimal.Round(PrecioInlIgvD / (1 + (porIgvD / 100)), 5) : PrecioD;
                        oPrecioItem.PorDsctoD = porDsctoD;
                        oPrecioItem.MontoDsctoD = 0M;// Convert.ToDecimal(TxtDsctoD.Text);
                        oPrecioItem.PrecioValorVentaD = 0M;// Convert.ToDecimal(TxtValVentaD.Text);
                        oPrecioItem.FlgIgvD = ChkImpuestoD.Checked;
                        oPrecioItem.PorIgvD = porIgvD;
                        oPrecioItem.IgvD = 0M;// Convert.ToDecimal(txtIgvD.Text);
                        oPrecioItem.PrecioVentaD = PrecioInlIgvD;
                        oPrecioItem.Opcion = oPrecioItem.Opcion;

                        if (oPrecioItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            oPrecioItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oPrecioItem.FechaRegistro = VariablesLocales.FechaHoy;
                            oPrecioItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oPrecioItem.FechaModificacion = VariablesLocales.FechaHoy;
                        }
                        else
                        {
                            oPrecioItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oPrecioItem.FechaModificacion = VariablesLocales.FechaHoy;
                        }

                        base.Aceptar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmDetalleListaPrecioItem_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmBuscarArticulosListaPrecio frm = new frmBuscarArticulosListaPrecio(0, "PrecioListaArti");

            if (frm.ShowDialog() == DialogResult.OK && frm.Articulo != null)
            {
                txtIdTipoArticulo.Text = frm.Articulo.idTipoArticulo.ToString();
                txtTipoArticulo.Text = frm.Articulo.desTipoArticulo;
                txtIdArticulo.Text = Convert.ToString(frm.Articulo.idArticulo);
                txtCodArticulo.Text = frm.Articulo.codArticulo;
                txtDesArticulo.Text = frm.Articulo.nomArticulo;
                txtCapacidad.Text = frm.Articulo.Capacidad.ToString("N2");
                txtContenido.Text = frm.Articulo.Contenido.ToString("N2");

                TxtMedida.Tag = frm.Articulo.codUniMedAlmacen;
                TxtMedida.Text = frm.Articulo.nomUMedida;

                TxtMedidaD.Tag = frm.Articulo.idUniMedEnvase;
                TxtMedidaD.Text = frm.Articulo.nomUMedidaEnv;

                //if (txtIdArticulo.Text.Equals(Convert.ToString(333011)))
                //{
                //   int articulo =frm.Articulo.idArticulo;
                //    CalcularStock(articulo);
                //}

                if (txtCodArticulo.Text.Equals(330011))
                {
                    int codigo = frm.Articulo.idArticuloComponente;
                    CalcularKit(codigo);
                }
                
                if (frm.Articulo.Contenido > 0)
                {
                    PnlUma.Enabled = true;
                    chImpuesto.Checked = VariablesLocales.oVenParametros.indIgv;
                }
                else
                {
                    PnlUma.Enabled = false;
                    chImpuesto.Checked = false;
                    txtPrecio.Text = "0.00";
                }

                if (frm.Articulo.Contenido > 1)
                {
                    PnlUmd.Enabled = true;
                    ChkImpuestoD.Checked = VariablesLocales.oVenParametros.indIgv;
                }
                else
                {
                    TxtPrecioD.Text = "0.00";
                    PnlUmd.Enabled = false;
                    ChkImpuestoD.Checked = false;
                }

                txtPrecio.Focus();
            }
        }

        private void chImpuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (chImpuesto.Checked)
            {
                if (VariablesLocales.oListaImpuestos != null && VariablesLocales.oListaImpuestos.Count > 0)
                {
                    Decimal objImpuesto = VariablesLocales.oListaImpuestos[0].Porcentaje; //IGV
                    txtPorIgv.Text = objImpuesto.ToString("N2");
                }
                else
                {
                    Global.MensajeFault("Falta configurar el parámetro del IGV en Ventana de Impuestos.");
                    txtPorIgv.Text = "0.00";
                }

                txtPrecVta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtPorIgv.Text = "0.00";
                txtPrecVta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
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

        private void txtPorcDsct1_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    Calcular();
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeError(ex.Message);
            //}
        }

        private void txtPorcIgv_TextChanged(object sender, EventArgs e)
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

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            txtPrecio.Text = Global.FormatoDecimal(txtPrecio.Text);
        }

        private void txtPorcDsct1_Leave(object sender, EventArgs e)
        {
            txtPorDscto.Text = Global.FormatoDecimal(txtPorDscto.Text);
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            txtPrecio.SelectAll();
        }

        private void txtPrecio_MouseClick(object sender, MouseEventArgs e)
        {
            txtPrecio.SelectAll();
        }

        private void txtPorcDsct1_Enter(object sender, EventArgs e)
        {
            txtPorDscto.SelectAll();
        }

        private void txtPorcDsct1_MouseClick(object sender, MouseEventArgs e)
        {
            txtPorDscto.SelectAll();
        }

        private void txtPrecVta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularReves();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPrecVta_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPrecVta.Text.Trim()))
            {
                txtPrecVta.Text = Global.FormatoDecimal(txtPrecVta.Text);
            }
        }

        private void TxtPrecioD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularPrecioD();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void TxtPorDctoD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularPrecioD();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void TxtPrecVtaD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularRevesPrecioD();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void ChkImpuestoD_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkImpuestoD.Checked)
            {
                if (VariablesLocales.oListaImpuestos != null && VariablesLocales.oListaImpuestos.Count > 0)
                {
                    Decimal objImpuesto = VariablesLocales.oListaImpuestos[0].Porcentaje; //IGV
                    TxtPorcIgvD.Text = objImpuesto.ToString("N2");
                }
                else
                {
                    Global.MensajeFault("Falta configurar el parámetro del IGV en Ventana de Impuestos.");
                    TxtPorcIgvD.Text = "0.00";
                }

                TxtPrecVtaD.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                TxtPorcIgvD.Text = "0.00";
                TxtPrecVtaD.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        private void TxtPrecioD_Enter(object sender, EventArgs e)
        {
            TxtPrecioD.SelectAll();
        }

        private void TxtPrecioD_MouseClick(object sender, MouseEventArgs e)
        {
            TxtPrecioD.SelectAll();
        }

        private void TxtPrecioD_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtPrecioD.Text.Trim()))
            {
                TxtPrecioD.Text = Global.FormatoDecimal(TxtPrecioD.Text); 
            }
        }

        private void TxtPorDctoD_Enter(object sender, EventArgs e)
        {
            TxtPorDctoD.SelectAll();
        }

        private void TxtPorDctoD_MouseClick(object sender, MouseEventArgs e)
        {
            TxtPorDctoD.SelectAll();
        }

        private void TxtPorDctoD_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtPorDctoD.Text.Trim()))
            {
                TxtPorDctoD.Text = Global.FormatoDecimal(TxtPorDctoD.Text); 
            }
        }

        private void TxtPrecVtaD_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtPrecVtaD.Text.Trim()))
            {
                TxtPrecVtaD.Text = Global.FormatoDecimal(TxtPrecVtaD.Text);
            }
        }

        private void TxtPorcIgvD_TextChanged(object sender, EventArgs e)
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


        #endregion

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
