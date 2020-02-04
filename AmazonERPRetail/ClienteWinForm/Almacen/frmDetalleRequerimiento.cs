using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmDetalleRequerimiento : frmResponseBase
    {

        #region Constructores

        public frmDetalleRequerimiento()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
        }

        //Nuevo
        public frmDetalleRequerimiento(AlmacenE oAlmacen_, DateTime FechaReque_)
            : this()
        {
            oAlmacen = oAlmacen_;
            FechaReque = FechaReque_;
        }

        //Editar
        public frmDetalleRequerimiento(RequerimientosItemE oItem, AlmacenE oAlmacen_, DateTime FechaReque_)
            : this()
        {
            oAlmacen = oAlmacen_;
            FechaReque = FechaReque_;

            if (oItem.idRequerimiento != 0)
            {
                oRequerimientoItem = AgenteAlmacen.Proxy.ObtenerRequerimientosItem(oItem.idRequerimiento, oItem.Item);
            }
            else
            {
                oRequerimientoItem = oItem;
            }
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public RequerimientosItemE oRequerimientoItem = null;
        AlmacenE oAlmacen = null;
        DateTime FechaReque;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            try
            {
                List<UMedidaE> ListaUMedida = AgenteGeneral.Proxy.ListarUMedida("%");
                ListaUMedida.Add(new UMedidaE() { idUMedida = 0, NomUMedida = Variables.Seleccione });
                ComboHelper.LlenarCombos<UMedidaE>(cboUnidadMedida, (from x in ListaUMedida orderby x.idUMedida select x).ToList(), "idUMedida", "NomUMedida");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oRequerimientoItem == null)
            {
                oRequerimientoItem = new RequerimientosItemE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal
                };

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();

                oRequerimientoItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                txtIdArticulo.Text = oRequerimientoItem.idArticulo.ToString();
                txtCodArticulo.Text = oRequerimientoItem.codArticulo;
                txtDesArticulo.Text = oRequerimientoItem.nomArticulo;
                txtStock.Text = oRequerimientoItem.Stock.ToString("N2");
                cboUnidadMedida.SelectedValue = Convert.ToInt32(oRequerimientoItem.idUMedida);
                txtObservación.Text = oRequerimientoItem.Observacion.Trim();
                txtCantidad.Text = oRequerimientoItem.cantRequerida.ToString("N2");

                txtUsuarioRegistro.Text = oRequerimientoItem.UsuarioRegistro;
                txtFechaRegistro.Text = oRequerimientoItem.FechaRegistro.ToString();
                txtUsuarioMod.Text = oRequerimientoItem.UsuarioModificacion;
                txtFechaModifica.Text = oRequerimientoItem.FechaModificacion.ToString();

                if (oRequerimientoItem.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oRequerimientoItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    oRequerimientoItem.idTipoArticulo = Convert.ToInt32(oAlmacen.tipAlmacen);

                    if (oRequerimientoItem.idArticulo != Convert.ToInt32(txtIdArticulo.Text))
                    {
                        oRequerimientoItem.cantTemporal = 0;
                    }

                    oRequerimientoItem.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
                    oRequerimientoItem.codArticulo = txtCodArticulo.Text.Trim();
                    oRequerimientoItem.nomArticulo = txtDesArticulo.Text.Trim();
                    oRequerimientoItem.idUMedida = Convert.ToInt32(cboUnidadMedida.SelectedValue);
                    oRequerimientoItem.cantRequerida = Convert.ToDecimal(txtCantidad.Text);
                    oRequerimientoItem.cantAtendida = 0;
                    oRequerimientoItem.Observacion = txtObservación.Text.Trim();
                    oRequerimientoItem.indEstadoDet = "PN";
                    oRequerimientoItem.Stock = Convert.ToDecimal(txtStock.Text);

                    if (oRequerimientoItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oRequerimientoItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oRequerimientoItem.FechaRegistro = VariablesLocales.FechaHoy;
                        oRequerimientoItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oRequerimientoItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oRequerimientoItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oRequerimientoItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (Convert.ToString(txtCantidad.Text) == "0.00" || Convert.ToString(txtCantidad.Text) == "0")
            {
                Global.MensajeFault("Debe ingresar la cantidad.");
                txtCantidad.Focus();
                return false;
            }

            if (oAlmacen.VerificaStock)
            {
                //if (Tipo == "P")
                //{
                //    if (oListaDetalle != null && oListaDetalle.Count > Variables.Cero)
                //    {
                //        List<PedidoDetE> oListaTemp = new List<PedidoDetE>((from x in oListaDetalle
                //                                                            where x.idArticulo == Convert.ToInt32(txtIdArticulo.Text.Trim())
                //                                                            && x.codArticulo == txtCodArticulo.Text.Trim()
                //                                                            && x.Lote == txtLote.Text.Trim()
                //                                                            && x.indCalculo == chkCalculo.Checked
                //                                                            select x).ToList());
                //        if (oDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                //        {
                //            if (oListaTemp.Count > 0)
                //            {
                //                Global.MensajeFault("El articulo ya se encuentra añadido en la lista, cambie de código o modifique el articulo correspondiente.");
                //                oListaTemp = null;
                //                btBuscarArticulo.Focus();
                //                return false;
                //            }
                //        }
                //    }
                //}

                Decimal Stock = Variables.Cero;
                Decimal Cantidad = Variables.Cero;
                Decimal.TryParse(txtStock.Text, out Stock);
                Decimal.TryParse(txtCantidad.Text, out Cantidad);

                if (Cantidad > Stock)
                {
                    Global.MensajeComunicacion("No hay stock suficiente. Escoja otro producto o Modifique la cantidad.");
                    txtCantidad.Focus();
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmDetalleRequerimiento_Load(object sender, EventArgs e)
        {
            try
            {
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = String.Empty;
            txtCodArticulo.Text = String.Empty;
            cboUnidadMedida.SelectedValue = Variables.Cero;
            txtStock.Text = "0.00";
            oRequerimientoItem.Lote = "";
        }

        private void txtCodArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = String.Empty;
            txtDesArticulo.Text = String.Empty;
            cboUnidadMedida.SelectedValue = Variables.Cero;
            txtStock.Text = "0.00";
            oRequerimientoItem.Lote = "";
        }

        private void cboTipoUnidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarArticulo oFrm = null;

                if (oAlmacen.VerificaStock)
                {
                    oFrm = new frmBuscarArticulo(oAlmacen, "StockReque", FechaReque.ToString("yyyy"), FechaReque.ToString("MM"));
                }
                else
                {
                    oFrm = new frmBuscarArticulo(oAlmacen, "ArtiReque");
                }

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    txtIdArticulo.Text = oFrm.Articulo.idArticulo.ToString();
                    txtCodArticulo.Text = oFrm.Articulo.codArticulo;
                    txtDesArticulo.Text = oFrm.Articulo.nomArticulo;
                    oRequerimientoItem.idTipoArticulo = oFrm.Articulo.idTipoArticulo;
                    oRequerimientoItem.Lote = "0000000";
                    txtStock.Text = Convert.ToDecimal(oFrm.Articulo.Stock).ToString("N2");
                    cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.Articulo.codUniMedAlmacen);
                    txtObservación.Focus();

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodArticulo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    if (oAlmacen.VerificaStock)
                    {
                        #region Con Stock

                        List<StockE> oListaStock = null;

                        if (oAlmacen.VerificaLote)
                        {
                            oListaStock = AgenteAlmacen.Proxy.ListarStockArticuloRequeri(VariablesLocales.SesionLocal.IdEmpresa, oAlmacen.idAlmacen, Convert.ToInt32(oAlmacen.tipAlmacen),
                                                                                        FechaReque.ToString("yyyy"), FechaReque.ToString("MM"), true, txtCodArticulo.Text.Trim(), "");
                        }
                        else
                        {
                            oListaStock = AgenteAlmacen.Proxy.ListarStockArticuloRequeri(VariablesLocales.SesionLocal.IdEmpresa, oAlmacen.idAlmacen, Convert.ToInt32(oAlmacen.tipAlmacen),
                                                                                        FechaReque.ToString("yyyy"), FechaReque.ToString("MM"), false, txtCodArticulo.Text.Trim(), "");
                        }

                        if (oListaStock.Count > 1)
                        {
                            frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(oAlmacen.VerificaLote, oListaStock, null, "N", "S");

                            if (oFrm.ShowDialog() == DialogResult.OK)
                            {
                                txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                oRequerimientoItem.idTipoArticulo = oFrm.oArticulo.idTipoArticulo;
                                oRequerimientoItem.Lote = "0000000";
                                cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                                txtStock.Text = oFrm.oArticulo.Stock.ToString("N2");
                            }
                        }
                        else if (oListaStock.Count == 1)
                        {
                            txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                            txtCodArticulo.Text = oListaStock[0].codArticulo;
                            txtDesArticulo.Text = oListaStock[0].desArticulo;
                            oRequerimientoItem.idTipoArticulo = oListaStock[0].idTipoArticulo;
                            oRequerimientoItem.Lote = "0000000";
                            cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
                            txtStock.Text = oListaStock[0].canStock.ToString("N2");
                        }
                        else
                        {
                            Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                            txtIdArticulo.Text = string.Empty;
                            txtCodArticulo.Text = string.Empty;
                            txtDesArticulo.Text = string.Empty;
                            oRequerimientoItem.Lote = "";
                            txtCodArticulo.Focus();
                        }

                        #endregion
                    }
                    else
                    {
                        #region Sin Stock

                        if (VariablesLocales.oVenParametros != null)
                        {
                            //if (!VariablesLocales.oVenParametros.indListaPrecio)
                            //{
                            //    #region Sin Lista de Precios

                            //    List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                            //                                                                                        Convert.ToInt32(oAlmacen.tipAlmacen),
                            //                                                                                        txtCodArticulo.Text.Trim(), "");
                            //    if (oListaArticulos.Count > 1)
                            //    {
                            //        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

                            //        if (oFrm.ShowDialog() == DialogResult.OK)
                            //        {
                            //            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            //            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            //            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                            //            //txtLote.Text = "0000000";
                            //            txtStock.Text = "0.00";

                            //            cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
                            //            cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                            //            cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;
                            //        }
                            //    }
                            //    else if (oListaArticulos.Count == 1)
                            //    {
                            //        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                            //        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                            //        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                            //        //txtLote.Text = "0000000";
                            //        txtStock.Text = "0.00";

                            //        cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
                            //        cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                            //        cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);
                            //    }
                            //    else
                            //    {
                            //        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                            //        txtIdArticulo.Text = string.Empty;
                            //        txtCodArticulo.Text = string.Empty;
                            //        txtDesArticulo.Text = string.Empty;
                            //        //txtLote.Text = "0000000";
                            //        txtStock.Text = "0.00";

                            //        txtCodArticulo.Focus();
                            //    }

                            //    #endregion  
                            //}
                            //else
                            //{

                            //}
                        }

                        #endregion
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

        private void txtDesArticulo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDesArticulo.Text.Trim()) && string.IsNullOrEmpty(txtCodArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    if (oAlmacen.VerificaStock)
                    {
                        #region Con Stock

                        List<StockE> oListaStock = null;

                        if (oAlmacen.VerificaLote)
                        {
                            oListaStock = AgenteAlmacen.Proxy.ListarStockArticuloRequeri(VariablesLocales.SesionLocal.IdEmpresa, oAlmacen.idAlmacen, Convert.ToInt32(oAlmacen.tipAlmacen),
                                                                                        FechaReque.ToString("yyyy"), FechaReque.ToString("MM"), true, "", txtDesArticulo.Text.Trim());
                        }
                        else
                        {
                            oListaStock = AgenteAlmacen.Proxy.ListarStockArticuloRequeri(VariablesLocales.SesionLocal.IdEmpresa, oAlmacen.idAlmacen, Convert.ToInt32(oAlmacen.tipAlmacen),
                                                                                        FechaReque.ToString("yyyy"), FechaReque.ToString("MM"), false, "", txtDesArticulo.Text.Trim());
                        }

                        if (oListaStock.Count > 1)
                        {
                            frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(oAlmacen.VerificaLote, oListaStock, null, "N", "S");

                            if (oFrm.ShowDialog() == DialogResult.OK)
                            {
                                txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                oRequerimientoItem.idTipoArticulo = oFrm.oArticulo.idTipoArticulo;
                                oRequerimientoItem.Lote = "0000000";
                                cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                                txtStock.Text = oFrm.oArticulo.Stock.ToString("N2");
                            }
                        }
                        else if (oListaStock.Count == 1)
                        {
                            txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                            txtCodArticulo.Text = oListaStock[0].codArticulo;
                            txtDesArticulo.Text = oListaStock[0].desArticulo;
                            oRequerimientoItem.idTipoArticulo = oListaStock[0].idTipoArticulo;
                            oRequerimientoItem.Lote = "0000000";
                            cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
                            txtStock.Text = oListaStock[0].canStock.ToString("N2");
                        }
                        else
                        {
                            Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                            txtIdArticulo.Text = string.Empty;
                            txtCodArticulo.Text = string.Empty;
                            txtDesArticulo.Text = string.Empty;
                            oRequerimientoItem.Lote = "";
                            txtDesArticulo.Focus();
                        }

                        #endregion
                    }
                    else
                    {
                        #region Sin Stock

                        if (VariablesLocales.oVenParametros != null)
                        {
                            //if (!VariablesLocales.oVenParametros.indListaPrecio)
                            //{
                            //    #region Sin Lista de Precios

                            //    List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                            //                                                                                        Convert.ToInt32(oAlmacen.tipAlmacen),
                            //                                                                                        txtCodArticulo.Text.Trim(), "");
                            //    if (oListaArticulos.Count > 1)
                            //    {
                            //        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

                            //        if (oFrm.ShowDialog() == DialogResult.OK)
                            //        {
                            //            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            //            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            //            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                            //            //txtLote.Text = "0000000";
                            //            txtStock.Text = "0.00";

                            //            cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
                            //            cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                            //            cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;
                            //        }
                            //    }
                            //    else if (oListaArticulos.Count == 1)
                            //    {
                            //        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                            //        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                            //        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                            //        //txtLote.Text = "0000000";
                            //        txtStock.Text = "0.00";

                            //        cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
                            //        cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                            //        cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);
                            //    }
                            //    else
                            //    {
                            //        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                            //        txtIdArticulo.Text = string.Empty;
                            //        txtCodArticulo.Text = string.Empty;
                            //        txtDesArticulo.Text = string.Empty;
                            //        //txtLote.Text = "0000000";
                            //        txtStock.Text = "0.00";

                            //        txtCodArticulo.Focus();
                            //    }

                            //    #endregion  
                            //}
                            //else
                            //{

                            //}
                        }

                        #endregion
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

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            txtCantidad.Text = Global.FormatoDecimal(txtCantidad.Text);
        } 

        #endregion

    }
}
