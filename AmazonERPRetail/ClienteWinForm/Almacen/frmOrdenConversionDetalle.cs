using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmOrdenConversionDetalle : frmResponseBase
    {

        #region Constructores

        public frmOrdenConversionDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarComboBox();
        }

        public frmOrdenConversionDetalle(DateTime FechaCab)
            : this()
        {
            FechaDet = FechaCab;
        }

        public frmOrdenConversionDetalle(OrdenConversionDetalleE oDetalleConversion_)
            : this()
        {
            oDetalleConversion = oDetalleConversion_;
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public OrdenConversionDetalleE oDetalleConversion = null;
        DateTime FechaDet;

        #endregion

        #region Procedimientos de Usuario

        void LlenarComboBox()
        {
            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            AlmacenE oItem = new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione };
            oListaAlmacen.Add(oItem);

            ComboHelper.LlenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oDetalleConversion == null)
            {
                oDetalleConversion = new OrdenConversionDetalleE();
                oDetalleConversion.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                dtpFecha.Value = FechaDet;
                txtLote.Text = "0";

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

                oDetalleConversion.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
               
                dtpFecha.Value = Convert.ToDateTime(oDetalleConversion.Fecha);
                txtIdArticulo.Text = Convert.ToString(oDetalleConversion.idArticulo);
                txtCodArticulo.Text = oDetalleConversion.codArticulo;
                txtDesArticulo.Text = oDetalleConversion.NombreArt;
                txtEnvase.Text = oDetalleConversion.nomUMedidaEnv;
                txtCantidad.Text = Convert.ToString(oDetalleConversion.contenido);
                txtPresentacion.Text = oDetalleConversion.nomUMedidaPres;

                cboAlmacen.SelectedValue = oDetalleConversion.idAlmacen;
                txtLote.Text = oDetalleConversion.Lote;
                txtCantSolicitada.Text = Convert.ToString(oDetalleConversion.Cantidad);
                txtEquivalente.Text = Convert.ToString(oDetalleConversion.Equivalente);
                chkGenerado.Checked = Convert.ToBoolean(oDetalleConversion.indGenerada);
                txtTipMovimiento.Text = oDetalleConversion.tipMovimiento != null ? oDetalleConversion.tipMovimiento.ToString() : string.Empty;
                txtDocAlmacen.Text = oDetalleConversion.idDocumentoAlmacen != null ? oDetalleConversion.idDocumentoAlmacen.ToString() : string.Empty;
                txtTotal.Text = Convert.ToString(oDetalleConversion.TotalPeso);
                txtPesoUnitario.Text = oDetalleConversion.PesoUnitario.ToString("N6");
                txtCostoUni.Text = oDetalleConversion.CostoUnitario.ToString("N6");
                txtCostoTot.Text = oDetalleConversion.TotalCosto.ToString("N2");

                txtUsuarioRegistro.Text = oDetalleConversion.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(oDetalleConversion.FechaRegistro);
                txtUsuarioModificacion.Text = oDetalleConversion.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(oDetalleConversion.FechaModificacion);

                    if (chkGenerado.Checked)
                    {
                        pnlBase.Enabled = false;
                        btAceptar.Enabled = false;
                    }
               

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
                if (ValidarGrabacion())
                {

                    if (oDetalleConversion != null)
                    {
                        oDetalleConversion.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                        oDetalleConversion.Fecha = dtpFecha.Value.Date;
                        oDetalleConversion.idTipoArticulo = Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen);
                        oDetalleConversion.codArticulo = txtCodArticulo.Text;
                        oDetalleConversion.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
                        oDetalleConversion.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
                        oDetalleConversion.nomAlmacen = ((AlmacenE)cboAlmacen.SelectedItem).desAlmacen;
                        oDetalleConversion.Lote = txtLote.Text.Trim();
                        oDetalleConversion.Cantidad = Convert.ToDecimal(txtCantSolicitada.Text);
                        oDetalleConversion.Equivalente = Convert.ToDecimal(txtEquivalente.Text);
                        oDetalleConversion.indGenerada = chkGenerado.Checked;
                        oDetalleConversion.tipMovimiento = string.IsNullOrEmpty(txtTipMovimiento.Text.Trim()) ? (int?)null : Convert.ToInt32(txtTipMovimiento.Text.Trim());
                        oDetalleConversion.idDocumentoAlmacen = string.IsNullOrEmpty(txtDocAlmacen.Text.Trim()) ? (int?)null : Convert.ToInt32(txtDocAlmacen.Text.Trim());
                        oDetalleConversion.NombreArt = txtDesArticulo.Text;
                        oDetalleConversion.nomUMedidaEnv = txtEnvase.Text;
                        oDetalleConversion.contenido = Convert.ToDecimal(txtCantidad.Text);
                        oDetalleConversion.nomUMedidaPres = txtPresentacion.Text;
                        oDetalleConversion.TotalPeso = Convert.ToDecimal(txtTotal.Text);
                        oDetalleConversion.PesoUnitario = Convert.ToDecimal(txtPesoUnitario.Text);
                        oDetalleConversion.CostoUnitario = Convert.ToDecimal(txtCostoUni.Text);
                        oDetalleConversion.TotalCosto = Convert.ToDecimal(txtCostoTot.Text);

                        if (oDetalleConversion.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            oDetalleConversion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oDetalleConversion.FechaRegistro = VariablesLocales.FechaHoy;
                            oDetalleConversion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oDetalleConversion.FechaModificacion = VariablesLocales.FechaHoy;
                        }
                        else
                        {
                            oDetalleConversion.UsuarioRegistro = txtUsuarioRegistro.Text;
                            oDetalleConversion.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                            oDetalleConversion.UsuarioModificacion = txtUsuarioModificacion.Text;
                            oDetalleConversion.FechaModificacion = VariablesLocales.FechaHoy;
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

        public override bool ValidarGrabacion()
        {
            if (txtLote.Text.Trim() == "")
            {
                Global.MensajeComunicacion("Se necesita un Lote");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmOrdenConversionDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAlmacen.SelectedValue) == Variables.Cero)
            {
                Global.MensajeComunicacion("Primero tiene que escoger un almacén.");
                return;
            }

            AlmacenE oAlmacen = (AlmacenE)cboAlmacen.SelectedItem;
            frmBuscarArticulo oFrm = new frmBuscarArticulo(oAlmacen, "ArtAlmacen", dtpFecha.Value.ToString("yyyy"), dtpFecha.Value.ToString("MM"));



            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
            {
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                txtIdArticulo.Text = oFrm.Articulo.idArticulo.ToString();
                txtCodArticulo.Text = oFrm.Articulo.codArticulo;
                txtDesArticulo.Text = oFrm.Articulo.nomArticulo.ToString();
                txtEnvase.Text = oFrm.Articulo.nomUMedidaEnv;
                txtPresentacion.Text = oFrm.Articulo.nomUMedidaPres;
                txtCantidad.Text = oFrm.Articulo.Contenido.ToString();
                txtPesoUnitario.Text = oFrm.Articulo.PesoUnitario.ToString("N6");
                txtEquivalente.Text = oFrm.Articulo.PesoUnitario.ToString("N6");
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                txtCantSolicitada.Focus();

                //txtEnvase.Text = oFrm.oArticulo.nomUMedidaEnv;
                //txtCantidad.Text = oFrm.oArticulo.Contenido.ToString();
                //txtPresentacion.Text = oFrm.oArticulo.nomUMedidaPres;
                //txtPesoUnitario.Text = oFrm.oArticulo.PesoUnitario.ToString("N6");
                //txtEquivalente.Text = oFrm.oArticulo.PesoUnitario.ToString("N6");
                //txtCantSolicitada.Focus();

            }
        }

        private void txtCodArticulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboAlmacen.SelectedValue) == Variables.Cero)
                {
                    Global.MensajeComunicacion("Primero tiene que escoger un almacén.");
                    cboAlmacen.Focus();
                    return;
                }

                if (!string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<ArticuloServE> oListaArticulo = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                    txtCodArticulo.Text.Trim(), "");
                    if (oListaArticulo.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulo);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                            txtEnvase.Text = oFrm.oArticulo.nomUMedidaEnv;
                            txtCantidad.Text = oFrm.oArticulo.Contenido.ToString();
                            txtPresentacion.Text = oFrm.oArticulo.nomUMedidaPres;
                            txtPesoUnitario.Text = oFrm.oArticulo.PesoUnitario.ToString("N6");
                            txtEquivalente.Text = oFrm.oArticulo.PesoUnitario.ToString("N6");
                            txtCantSolicitada.Focus();
                        }
                    }
                    else if (oListaArticulo.Count == 1)
                    {
                        txtIdArticulo.Text = oListaArticulo[0].idArticulo.ToString();
                        txtCodArticulo.Text = oListaArticulo[0].codArticulo;
                        txtDesArticulo.Text = oListaArticulo[0].nomArticulo;
                        txtEnvase.Text = oListaArticulo[0].nomUMedidaEnv;
                        txtCantidad.Text = oListaArticulo[0].Contenido.ToString();
                        txtPresentacion.Text = oListaArticulo[0].nomUMedidaPres;
                        txtPesoUnitario.Text = oListaArticulo[0].PesoUnitario.ToString("N6");
                        txtEquivalente.Text = oListaArticulo[0].PesoUnitario.ToString("N6");
                        txtCantSolicitada.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                        txtIdArticulo.Text = string.Empty;
                        txtCodArticulo.Text = string.Empty;
                        txtDesArticulo.Text = string.Empty;
                        txtEnvase.Text = string.Empty;
                        txtCantidad.Text = string.Empty;
                        txtPresentacion.Text = string.Empty;
                        txtPesoUnitario.Text = "0.000";
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
                if (Convert.ToInt32(cboAlmacen.SelectedValue) == Variables.Cero)
                {
                    Global.MensajeComunicacion("Primero tiene que escoger un almacén.");
                    cboAlmacen.Focus();
                    return;
                }

                if (!string.IsNullOrEmpty(txtDesArticulo.Text.Trim()) && string.IsNullOrEmpty(txtCodArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    List<ArticuloServE> oListaArticulo = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                    "", txtDesArticulo.Text.Trim());
                    if (oListaArticulo.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulo);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                            txtEnvase.Text = oFrm.oArticulo.nomUMedidaEnv;
                            txtCantidad.Text = oFrm.oArticulo.Contenido.ToString();
                            txtPresentacion.Text = oFrm.oArticulo.nomUMedidaPres;
                            txtPesoUnitario.Text = oFrm.oArticulo.PesoUnitario.ToString("N6");
                            txtEquivalente.Text = oFrm.oArticulo.PesoUnitario.ToString("N6");
                            txtCantSolicitada.Focus();
                        }
                    }
                    else if (oListaArticulo.Count == 1)
                    {
                        txtIdArticulo.Text = oListaArticulo[0].idArticulo.ToString();
                        txtCodArticulo.Text = oListaArticulo[0].codArticulo;
                        txtDesArticulo.Text = oListaArticulo[0].nomArticulo;
                        txtEnvase.Text = oListaArticulo[0].nomUMedidaEnv;
                        txtCantidad.Text = oListaArticulo[0].Contenido.ToString();
                        txtPresentacion.Text = oListaArticulo[0].nomUMedidaPres;
                        txtPesoUnitario.Text = oListaArticulo[0].PesoUnitario.ToString("N6");
                        txtEquivalente.Text = oListaArticulo[0].PesoUnitario.ToString("N6");
                        txtCantSolicitada.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                        txtIdArticulo.Text = string.Empty;
                        txtCodArticulo.Text = string.Empty;
                        txtDesArticulo.Text = string.Empty;
                        txtEnvase.Text = string.Empty;
                        txtCantidad.Text = string.Empty;
                        txtPresentacion.Text = string.Empty;
                        txtPesoUnitario.Text = "0.000";
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
            txtEnvase.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPresentacion.Text = string.Empty;
        }

        private void txtDesArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtCodArticulo.Text = string.Empty;
            txtEnvase.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPresentacion.Text = string.Empty;
        }

        private void txtCantSolicitada_TextChanged(object sender, EventArgs e)
        {
            Decimal Cant = 0;
            Decimal equivalente = 0;
            Decimal.TryParse(txtCantSolicitada.Text, out Cant);
            Decimal.TryParse(txtEquivalente.Text, out equivalente);

            txtTotal.Text = Convert.ToDecimal(equivalente * Cant).ToString("N3");
        }

        private void txtEquivalente_TextChanged(object sender, EventArgs e)
        {
            Decimal equivalente = 0;
            Decimal Cant = 0;
            Decimal.TryParse(txtEquivalente.Text, out equivalente);
            Decimal.TryParse(txtCantSolicitada.Text, out Cant);

            txtTotal.Text = Convert.ToDecimal(equivalente * Cant).ToString("N3");
        }

        private void txtCantSolicitada_Leave(object sender, EventArgs e)
        {
            txtCantSolicitada.Text = Convert.ToDecimal(txtCantSolicitada.Text).ToString("N3");
        }

        private void txtEquivalente_Leave(object sender, EventArgs e)
        {
            txtEquivalente.Text = Convert.ToDecimal(txtEquivalente.Text).ToString("N6");
        }

        private void txtCantSolicitada_Enter(object sender, EventArgs e)
        {
            txtCantSolicitada.SeleccinarTodo();
        }

        private void txtCantSolicitada_MouseClick(object sender, MouseEventArgs e)
        {
            txtCantSolicitada.SeleccinarTodo();
        }

        private void txtEquivalente_Enter(object sender, EventArgs e)
        {
            txtEquivalente.SeleccinarTodo();
        }

        private void txtEquivalente_MouseClick(object sender, MouseEventArgs e)
        {
            txtEquivalente.SeleccinarTodo();
        }

        private void btLote_Click(object sender, EventArgs e)
        {
            frmBuscarLoteArticulo oFrm = new frmBuscarLoteArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpFecha.Value.ToString("yyyy"), dtpFecha.Value.ToString("MM"), 
                                                                    Convert.ToInt32(cboAlmacen.SelectedValue), Convert.ToInt32(txtIdArticulo.Text));

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oLoteArticulo != null)
            {
                txtLote.Text = oFrm.oLoteArticulo.Lote;
            }
        }

        private void cboAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Boolean ManejaLote = false;
                ManejaLote = ((AlmacenE)cboAlmacen.SelectedItem).VerificaLote;

                if (ManejaLote)
                {
                    btLote.Enabled = true;
                }
                else
                {
                    btLote.Enabled = false;
                    txtLote.Text = "0000000";
                }

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Decimal Peso = 0;
                Decimal Solicitada = 0;
                decimal.TryParse(txtTotal.Text, out Peso);
                decimal.TryParse(txtCantSolicitada.Text, out Solicitada);

                txtEquivalente.TextChanged -= txtEquivalente_TextChanged;
                txtEquivalente.Text = Convert.ToDecimal(Peso / Solicitada).ToString("N6");
                txtEquivalente.TextChanged += txtEquivalente_TextChanged;

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

        #endregion


    }
}
