using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using ClienteWinForm.Busquedas;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;

namespace ClienteWinForm.Almacen
{
    public partial class frmOrdenConversionSalida : frmResponseBase
    {

        #region Constructores

        public frmOrdenConversionSalida()
        {
            InitializeComponent();
            LlenarCombos();
        }

        public frmOrdenConversionSalida(DateTime dtpFecha_)
            :this()
        {
            dtpFecha = dtpFecha_;
        }

        public frmOrdenConversionSalida(DateTime dtpFecha_, OrdenConversionSalidaE oDetalleConversionsAL_)
            :this()
        {
            dtpFecha = dtpFecha_;
            oDetalleConvSalida = oDetalleConversionsAL_;
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public OrdenConversionSalidaE oDetalleConvSalida = null;
        public DateTime dtpFecha = DateTime.Now.Date;

        #endregion

        void LlenarCombos()
        {
            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            AlmacenE oItem = new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione };
            oListaAlmacen.Add(oItem);

            ComboHelper.LlenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");

        }

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oDetalleConvSalida == null)
            {
                oDetalleConvSalida = new OrdenConversionSalidaE
                {
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;
                txtCantSolicitada.TextChanged -= txtCantSolicitada_TextChanged;

                oDetalleConvSalida.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                cboAlmacen.SelectedValue = oDetalleConvSalida.idAlmacen;
                txtIdArticulo.Text = Convert.ToString(oDetalleConvSalida.idArticulo);
                txtCodArticulo.Text = oDetalleConvSalida.codArticulo;
                txtDesArticulo.Text = oDetalleConvSalida.NombreArt;
                txtLote.Text = oDetalleConvSalida.Lote;
                txtStock.Text = Convert.ToString(oDetalleConvSalida.Stock);
                txtPesoUnitario.Text = Convert.ToString(oDetalleConvSalida.PesoUnitario);
                txtunitbase.Text = Convert.ToString(oDetalleConvSalida.ImpCostoUnitarioBase);
                txtunitrefe.Text = Convert.ToString(oDetalleConvSalida.ImpCostoUnitarioRefe);
                txttotbase.Text = Convert.ToString(oDetalleConvSalida.ImpTotalBase);
                txttotrefe.Text = Convert.ToString(oDetalleConvSalida.ImpTotalRefe);
                                     
                txtCantSolicitada.Text = oDetalleConvSalida.CantSolicitada.ToString("N3");    
                txtTotal.Text = oDetalleConvSalida.TotalPeso.ToString("N3");
                txtPesoUnitario.Text = oDetalleConvSalida.PesoUnitario.ToString("N6");

                txtIdMovSalida.Text = oDetalleConvSalida.tipMovimiento.ToString();
                txtDesMovSalida.Text = oDetalleConvSalida.desTipMovimiento;
                txtIdDocSalAlmacen.Text = oDetalleConvSalida.idDocumentoAlmacen.ToString();

                txtUsuarioRegistro.Text = oDetalleConvSalida.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(oDetalleConvSalida.FechaRegistro);
                txtUsuarioModificacion.Text = oDetalleConvSalida.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(oDetalleConvSalida.FechaModificacion);

                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                txtCantSolicitada.TextChanged += txtCantSolicitada_TextChanged;
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (oDetalleConvSalida != null)
                {
                    oDetalleConvSalida.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oDetalleConvSalida.idTipoArticulo = ((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen.Value;
                    oDetalleConvSalida.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
                    oDetalleConvSalida.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
                    oDetalleConvSalida.NombreArt = txtDesArticulo.Text;
                    oDetalleConvSalida.Lote = txtLote.Text.Trim();
                    oDetalleConvSalida.Stock = Convert.ToDecimal(txtStock.Text);
                    oDetalleConvSalida.CantSolicitada = Convert.ToDecimal(txtCantSolicitada.Text);
                    oDetalleConvSalida.TotalPeso = Convert.ToDecimal(txtTotal.Text);
                    oDetalleConvSalida.PesoUnitario = Convert.ToDecimal(txtPesoUnitario.Text);
                    oDetalleConvSalida.ImpCostoUnitarioBase = Convert.ToDecimal(txtunitbase.Text);
                    oDetalleConvSalida.ImpCostoUnitarioRefe = Convert.ToDecimal(txtunitrefe.Text);
                    oDetalleConvSalida.ImpTotalBase = Convert.ToDecimal(txttotbase.Text);
                    oDetalleConvSalida.ImpTotalRefe = Convert.ToDecimal(txttotrefe.Text);

                    if (oDetalleConvSalida.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oDetalleConvSalida.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oDetalleConvSalida.FechaRegistro = VariablesLocales.FechaHoy;
                        oDetalleConvSalida.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oDetalleConvSalida.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oDetalleConvSalida.UsuarioRegistro = txtUsuarioRegistro.Text;
                        oDetalleConvSalida.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                        oDetalleConvSalida.UsuarioModificacion = txtUsuarioModificacion.Text;
                        oDetalleConvSalida.FechaModificacion = VariablesLocales.FechaHoy;
                    }

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmOrdenConversionSalida_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarArticulo oFrm = new frmBuscarArticulo((AlmacenE)cboAlmacen.SelectedItem, "stock", dtpFecha.ToString("yyyy"), dtpFecha.ToString("MM"));

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;
                    txtTotal.TextChanged -= txtTotal_TextChanged;

                    txtIdArticulo.Text = oFrm.Articulo.idArticulo.ToString();
                    txtCodArticulo.Text = oFrm.Articulo.codArticulo;
                    txtDesArticulo.Text = oFrm.Articulo.nomArticulo.ToString();
                    txtLote.Text = oFrm.Articulo.Lote;
                    txtUEnvase.Text = oFrm.Articulo.nomUMedidaEnv;
                    txtCant.Text = oFrm.Articulo.Contenido.ToString("N3");
                    txtUPresentacion.Text = oFrm.Articulo.nomUMedidaPres;
                    txtStock.Text = oFrm.Articulo.Stock.ToString("N3");
                    txtPesoUnitario.Text = oFrm.Articulo.PesoUnitario.ToString("N6");

                    //Peso
                    Decimal cantidad = Convert.ToDecimal(txtCant.Text);
                    Decimal Solicitada = Convert.ToDecimal(txtCantSolicitada.Text);
                    txtTotal.Text = Convert.ToString(cantidad * Solicitada);

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                    txtTotal.TextChanged += txtTotal_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCantSolicitada_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(txtPesoUnitario.Text, out decimal Peso);
            decimal.TryParse(txtCantSolicitada.Text, out decimal Solicitada);

            txtTotal.TextChanged -= txtTotal_TextChanged;
            txtTotal.Text = Convert.ToDecimal(Peso * Solicitada).ToString("N3");
            txtTotal.TextChanged += txtTotal_TextChanged;
        }

        private void txtCantSolicitada_Leave(object sender, EventArgs e)
        {
            txtCantSolicitada.Text = Convert.ToDecimal(txtCantSolicitada.Text).ToString("N3");
        }

        private void txtPesoUnitario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.TryParse(txtPesoUnitario.Text, out decimal Peso);
                decimal.TryParse(txtCantSolicitada.Text, out decimal Solicitada);

                txtTotal.TextChanged -= txtTotal_TextChanged;
                txtTotal.Text = Convert.ToDecimal(Peso * Solicitada).ToString("N3");
                txtTotal.TextChanged += txtTotal_TextChanged;

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPesoUnitario_Leave(object sender, EventArgs e)
        {
            txtPesoUnitario.Text = Convert.ToDecimal(txtPesoUnitario.Text).ToString("N6");
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.TryParse(txtTotal.Text, out decimal Peso);
                decimal.TryParse(txtCantSolicitada.Text, out decimal Solicitada);

                txtPesoUnitario.TextChanged -= txtPesoUnitario_TextChanged;
                txtPesoUnitario.Text = Convert.ToDecimal(Peso / Solicitada).ToString("N6");
                txtPesoUnitario.TextChanged += txtPesoUnitario_TextChanged;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtTotal_Leave(object sender, EventArgs e)
        {
            txtTotal.Text = Convert.ToDecimal(txtTotal.Text).ToString("N3");
        }

        private void txtCantSolicitada_MouseClick(object sender, MouseEventArgs e)
        {
            txtCantSolicitada.SeleccinarTodo();
        }

        private void txtCantSolicitada_Enter(object sender, EventArgs e)
        {
            txtCantSolicitada.SeleccinarTodo();
        }

        private void txtPesoUnitario_Enter(object sender, EventArgs e)
        {
            txtPesoUnitario.SeleccinarTodo();
        }

        private void txtPesoUnitario_MouseClick(object sender, MouseEventArgs e)
        {
            txtPesoUnitario.SeleccinarTodo();
        }

        private void txtDesArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtCodArticulo.Text = string.Empty;
            txtLote.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtUEnvase.Text = string.Empty;
            txtCant.Text = string.Empty;
            txtUPresentacion.Text = string.Empty;
        }

        private void txtDesArticulo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDesArticulo.Text.Trim()) && string.IsNullOrEmpty(txtCodArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<StockE> oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                        0,0,"", "", true,
                                                                                        "", txtDesArticulo.Text.Trim(),"N");
                    if (oListaStock.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, oListaStock, null);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                            txtLote.Text = oFrm.oArticulo.Lote;
                            txtUEnvase.Text = oFrm.oArticulo.nomUMedidaEnv;
                            txtCant.Text = oFrm.oArticulo.Contenido.ToString();
                            txtUPresentacion.Text = oFrm.oArticulo.nomUMedidaPres;
                            txtStock.Text = oFrm.oArticulo.Stock.ToString("N2");
                            txtPesoUnitario.Text = oFrm.oArticulo.PesoUnitario.ToString("N6");

                            //Peso
                            Decimal cantidad = Convert.ToDecimal(txtCant.Text);
                            Decimal Solicitada = Convert.ToDecimal(txtCantSolicitada.Text);
                            txtTotal.Text = Convert.ToString(cantidad * Solicitada);

                            txtCantSolicitada.Focus();
                        }
                    }
                    else if (oListaStock.Count == 1)
                    {
                        txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                        txtCodArticulo.Text = oListaStock[0].codArticulo;
                        txtDesArticulo.Text = oListaStock[0].desArticulo;
                        txtLote.Text = oListaStock[0].Lote;
                        txtUEnvase.Text = oListaStock[0].nomUMedidaEnv;
                        txtCant.Text = oListaStock[0].Contenido.ToString();
                        txtUPresentacion.Text = oListaStock[0].nomUMedidaPres;
                        txtStock.Text = oListaStock[0].canStock.ToString("N2");
                        txtPesoUnitario.Text = oListaStock[0].PesoUnitario.ToString("N6");

                        //Peso
                        Decimal cantidad = Convert.ToDecimal(txtCant.Text);
                        Decimal Solicitada = Convert.ToDecimal(txtCantSolicitada.Text);
                        txtTotal.Text = Convert.ToString(cantidad * Solicitada);


                        txtCantSolicitada.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");

                        txtIdArticulo.Text = string.Empty;
                        txtCodArticulo.Text = string.Empty;
                        txtDesArticulo.Text = string.Empty;
                        txtLote.Text = string.Empty;
                        txtStock.Text = "0.00";
                        txtUEnvase.Text = string.Empty;
                        txtCant.Text = string.Empty;
                        txtUPresentacion.Text = string.Empty;
                        txtPesoUnitario.Text = "0.0000";
                        txtDesArticulo.Focus();
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
            txtLote.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtUEnvase.Text = string.Empty;
            txtCant.Text = string.Empty;
            txtUPresentacion.Text = string.Empty;
        }

        private void txtCodArticulo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<StockE> oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,0,
                                                                                        0,
                                                                                        "", "", true,
                                                                                        txtCodArticulo.Text.Trim(), "", "N");
                    if (oListaStock.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, oListaStock, null);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                            txtLote.Text = oFrm.oArticulo.Lote;
                            txtUEnvase.Text = oFrm.oArticulo.nomUMedidaEnv;
                            txtCant.Text = oFrm.oArticulo.Contenido.ToString();
                            txtUPresentacion.Text = oFrm.oArticulo.nomUMedidaPres;
                            txtStock.Text = oFrm.oArticulo.Stock.ToString("N2");
                            txtPesoUnitario.Text = oFrm.oArticulo.PesoUnitario.ToString("N6");

                            //Peso
                            Decimal cantidad = Convert.ToDecimal(txtCant.Text);
                            Decimal Solicitada = Convert.ToDecimal(txtCantSolicitada.Text);
                            txtTotal.Text = Convert.ToString(cantidad * Solicitada);
           
                            txtCantSolicitada.Focus();
                        }
                    }
                    else if (oListaStock.Count == 1)
                    {
                        txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                        txtCodArticulo.Text = oListaStock[0].codArticulo;
                        txtDesArticulo.Text = oListaStock[0].desArticulo;
                        txtLote.Text = oListaStock[0].Lote;
                        txtUEnvase.Text = oListaStock[0].nomUMedidaEnv;
                        txtCant.Text = oListaStock[0].Contenido.ToString();
                        txtUPresentacion.Text = oListaStock[0].nomUMedidaPres;
                        txtStock.Text = oListaStock[0].canStock.ToString("N2");
                        txtPesoUnitario.Text = oListaStock[0].PesoUnitario.ToString("N6");

                        //Peso
                        Decimal cantidad = Convert.ToDecimal(txtCant.Text);
                        Decimal Solicitada = Convert.ToDecimal(txtCantSolicitada.Text);
                        txtTotal.Text = Convert.ToString(cantidad * Solicitada);


                        txtCantSolicitada.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");

                        txtIdArticulo.Text = string.Empty;
                        txtCodArticulo.Text = string.Empty;
                        txtDesArticulo.Text = string.Empty;
                        txtLote.Text = string.Empty;
                        txtStock.Text = "0.00";
                        txtUEnvase.Text = string.Empty;
                        txtCant.Text = string.Empty;
                        txtPesoUnitario.Text = "0.0000";
                        txtUPresentacion.Text = string.Empty;

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

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

        }


        #endregion

    }
}
