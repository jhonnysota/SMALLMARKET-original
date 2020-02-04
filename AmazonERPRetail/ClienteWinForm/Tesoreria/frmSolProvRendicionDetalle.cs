using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmSolProvRendicionDetalle : frmResponseBase
    {

        #region Constructores

        public frmSolProvRendicionDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LLenarCombos();
        }

        //Nuevo
        public frmSolProvRendicionDetalle(String idMoneda)
            :this()
        {
            idMonedaCab = idMoneda;
        }

        //Edición
        public frmSolProvRendicionDetalle(SolicitudProveedorRendicionDetE oDetalle, String Bloqueo, String idMoneda)
            :this()
        {
            oRendicionDetalle = oDetalle;
            BloquearTodo = Bloqueo;
            idMonedaCab = idMoneda;
        } 

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public SolicitudProveedorRendicionDetE oRendicionDetalle = null;
        String BloquearTodo = "N";
        String idMonedaCab = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LLenarCombos()
        {
            // Monedas
            List<MonedasE> ListaMonedas = new List<MonedasE>((from x in VariablesLocales.ListaMonedas
                                                              where x.idMoneda == "01" || x.idMoneda == "02"
                                                              orderby x.idMoneda
                                                              select x).ToList());
            List<MonedasE> ListaMonedas2 = new List<MonedasE>(ListaMonedas);

            ComboHelper.LlenarCombos<MonedasE>(cboMoneda, ListaMonedas, "idMoneda", "desAbreviatura");
            ComboHelper.LlenarCombos<MonedasE>(cboMonedaRec, ListaMonedas2, "idMoneda", "desAbreviatura");

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indTesoreria == true
                                                                      select x).ToList();
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");

            ListaMonedas = null;
            ListaDocumentos = null;
            ListaMonedas2 = null;

            // Si es Reparable
            cboReparable.DataSource = Global.CargarTipoReparable();
            cboReparable.ValueMember = "id";
            cboReparable.DisplayMember = "Nombre";

            // Conceptos Reparables
            cboConceptoReparable.DataSource = Global.CargarConceptosReparable();
            cboConceptoReparable.ValueMember = "id";
            cboConceptoReparable.DisplayMember = "Nombre";
        }

        void Calcular()
        {
            try
            {
                Decimal MontoDoc = 0;
                Decimal MontoRec = 0;
                Decimal Tica = 0;

                if (!chkIndTicaAuto.Checked)
                {
                    Decimal.TryParse(txtMontoDoc.Text, out MontoDoc);
                    Decimal.TryParse(txtMontoRec.Text, out MontoRec);

                    if (cboMoneda.SelectedValue.ToString() != cboMonedaRec.SelectedValue.ToString())
                    {
                        if (MontoDoc > 0 && MontoRec > 0)
                        {
                            if (MontoDoc > MontoRec)
                            {
                                Tica = MontoDoc / MontoRec;
                            }
                            else
                            {
                                Tica = MontoRec / MontoDoc;
                            }

                            txtTica.Text = Tica.ToString("N3"); 
                        }
                    }
                }
                else
                {
                    if (cboMoneda.SelectedValue.ToString() != cboMonedaRec.SelectedValue.ToString())
                    {
                        Decimal.TryParse(txtTica.Text, out Tica);

                        if (Tica > 0M)
                        {
                            if (cboMoneda.SelectedValue.ToString() == "01")
                            {
                                Decimal.TryParse(txtMontoDoc.Text, out MontoDoc);
                                MontoRec = MontoDoc / Tica;
                            }

                            if (cboMoneda.SelectedValue.ToString() == "02")
                            {
                                Decimal.TryParse(txtMontoDoc.Text, out MontoDoc);
                                MontoRec = MontoDoc * Tica;
                            } 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                if (oRendicionDetalle != null)
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    chkIndTicaAuto.CheckedChanged -= chkIndTicaAuto_CheckedChanged;
                    txtMontoRec.TextChanged -= txtMontoRec_TextChanged;
                    txtMontoDoc.TextChanged -= txtMontoDoc_TextChanged;

                    cboDocumento.SelectedValue = oRendicionDetalle.idDocumento.ToString();
                    txtSerie.Text = oRendicionDetalle.numSerie;
                    txtNumero.Text = oRendicionDetalle.numDocumento;
                    dtpFecDoc.Value = oRendicionDetalle.fecDocumento.Date;
                    cboMoneda.SelectedValue = oRendicionDetalle.idMoneda.ToString();
                    txtMontoDoc.Text = oRendicionDetalle.MontoDoc.ToString("N2");

                    cboMonedaRec.SelectedValue = oRendicionDetalle.idMonedaRec.ToString();
                    txtMontoRec.Text = oRendicionDetalle.MontoRec.ToString("N2");

                    chkIndTicaAuto.Checked = oRendicionDetalle.indTicaAuto;
                    txtTica.Text = oRendicionDetalle.tipCambio.ToString("N3");
                    txtRuc.Tag = oRendicionDetalle.idAuxiliar;
                    txtRuc.Text = oRendicionDetalle.RUC;
                    txtRazonSocial.Text = oRendicionDetalle.RazonSocial;
                    txtCodConcepto.Tag = Convert.ToInt32(oRendicionDetalle.idConcepto) > 0 ? oRendicionDetalle.idConcepto : 0;
                    txtCodConcepto.Text = oRendicionDetalle.codConcepto;
                    txtDesConcepto.Text = oRendicionDetalle.desConcepto;

                    cboReparable.SelectedValue = String.IsNullOrWhiteSpace(oRendicionDetalle.indReparable) ? "N" : oRendicionDetalle.indReparable;
                    cboReparable_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboConceptoReparable.SelectedValue = Convert.ToInt32(oRendicionDetalle.idConceptoRep);
                    txtRefRepa.Text = oRendicionDetalle.desReferenciaRep.Trim();

                    txtUsuarioRegistro.Text = oRendicionDetalle.UsuarioRegistro;
                    txtFechaRegistro.Text = oRendicionDetalle.FechaRegistro.ToString();
                    txtUsuarioMod.Text = oRendicionDetalle.UsuarioModificacion;
                    txtFechaModifica.Text = oRendicionDetalle.FechaModificacion.ToString();

                    chkIndTicaAuto.CheckedChanged += chkIndTicaAuto_CheckedChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    txtMontoRec.TextChanged += txtMontoRec_TextChanged;
                    txtMontoDoc.TextChanged += txtMontoDoc_TextChanged;

                    if (oRendicionDetalle.Opcion == 0)
                    {
                        oRendicionDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                    }

                    if (BloquearTodo == "S")
                    {
                        pnlReparable.Enabled = false;
                        pnlBase.Enabled = false;
                        btAceptar.Enabled = false;
                    }
                    else
                    {
                        if (oRendicionDetalle.EsAutomatico)
                        {
                            pnlReparable.Enabled = false;
                        }
                        else
                        {
                            pnlReparable.Enabled = true;
                        }
                    }
                }
                else
                {
                    oRendicionDetalle = new SolicitudProveedorRendicionDetE
                    {
                        Opcion = (Int32)EnumOpcionGrabar.Insertar,
                        EsAutomatico = false
                    };

                    txtRuc.Tag = 0;
                    chkIndTicaAuto_CheckedChanged(null, null);
                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    cboMoneda.Enabled = true;
                    txtUsuarioMod.Text = txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();

                    pnlReparable.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    if (oRendicionDetalle != null)
                    {
                        oRendicionDetalle.idDocumento = cboDocumento.SelectedValue.ToString();
                        oRendicionDetalle.numSerie = txtSerie.Text.Trim();
                        oRendicionDetalle.numDocumento = txtNumero.Text.Trim();
                        oRendicionDetalle.fecDocumento = dtpFecDoc.Value.Date;
                        oRendicionDetalle.idMoneda = cboMoneda.SelectedValue.ToString();
                        oRendicionDetalle.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                        oRendicionDetalle.MontoDoc = Convert.ToDecimal(txtMontoDoc.Text);
                        oRendicionDetalle.idMonedaRec = cboMonedaRec.SelectedValue.ToString();
                        oRendicionDetalle.desMonedaRec = ((MonedasE)cboMonedaRec.SelectedItem).desAbreviatura;
                        oRendicionDetalle.MontoRec = Convert.ToDecimal(txtMontoRec.Text);
                        oRendicionDetalle.indTicaAuto = chkIndTicaAuto.Checked;
                        oRendicionDetalle.tipCambio = Convert.ToDecimal(txtTica.Text);
                        oRendicionDetalle.idAuxiliar = Convert.ToInt32(txtRuc.Tag) == 0 ? (Int32?)null : Convert.ToInt32(txtRuc.Tag);
                        oRendicionDetalle.RazonSocial = txtRazonSocial.Text.Trim();
                        oRendicionDetalle.RUC = txtRuc.Text.Trim();
                        oRendicionDetalle.idConcepto = String.IsNullOrWhiteSpace(txtCodConcepto.Text) ? (Int32?)null : Convert.ToInt32(txtCodConcepto.Tag);
                        oRendicionDetalle.codConcepto = txtCodConcepto.Text;
                        oRendicionDetalle.desConcepto = txtDesConcepto.Text;

                        if (cboMonedaRec.SelectedValue.ToString() == "01")
                        {
                            oRendicionDetalle.SolesRecibidos = oRendicionDetalle.MontoRec;
                            oRendicionDetalle.DolaresRecibidos = oRendicionDetalle.MontoRec / oRendicionDetalle.tipCambio;
                        }
                        else
                        {
                            oRendicionDetalle.DolaresRecibidos = oRendicionDetalle.MontoRec;
                            oRendicionDetalle.SolesRecibidos = oRendicionDetalle.MontoRec * oRendicionDetalle.tipCambio;
                            
                        }

                        if (oRendicionDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            oRendicionDetalle.UsuarioModificacion = oRendicionDetalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oRendicionDetalle.FechaModificacion = oRendicionDetalle.FechaRegistro = VariablesLocales.FechaHoy;
                        }
                        else
                        {
                            oRendicionDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oRendicionDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                        }

                        oRendicionDetalle.indReparable = cboReparable.SelectedValue.ToString();
                        oRendicionDetalle.idConceptoRep = Convert.ToInt32(cboConceptoReparable.SelectedValue);
                        oRendicionDetalle.desReferenciaRep = txtRefRepa.Text.Trim();

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
            if (txtTica.Text == "0.000" || String.IsNullOrWhiteSpace(txtTica.Text.Trim()))
            {
                Global.MensajeFault("Debe ingresar el Tipo de Cambio.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmSolProvRendicionDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void chkIndTicaAuto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIndTicaAuto.Checked)
                {
                    txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtTica.Text = (VariablesLocales.MontoTicaConta(dtpFecDoc.Value.Date, cboMoneda.SelectedValue.ToString())).ToString("N3");
                }
                else
                {
                    txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    Calcular();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMontoRec_Leave(object sender, EventArgs e)
        {
            txtMontoRec.Text = Global.FormatoDecimal(txtMontoRec.Text);
        }

        private void txtTica_Leave(object sender, EventArgs e)
        {
            txtTica.Text = Global.FormatoDecimal(txtTica.Text);
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtSerie.Focus();
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtSerie.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtSerie.Focus();
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtSerie.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        private void txtMontoRec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btConceptos_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarConceptosTesoreria oFrm = new frmBuscarConceptosTesoreria(0);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                {
                    txtCodConcepto.Tag = oFrm.oConcepto.idConcepto;
                    txtCodConcepto.Text = oFrm.oConcepto.codConcepto;
                    txtDesConcepto.Text = oFrm.oConcepto.Descripcion;

                    if (!oRendicionDetalle.EsAutomatico)
                    {
                        if (oFrm.oConcepto.indCuentasMon)
                        {
                            oRendicionDetalle.numVerPlanCuentas = oFrm.oConcepto.numVerPlanCuentas.Trim();

                            if (idMonedaCab == Variables.Soles)
                            {
                                oRendicionDetalle.codCuenta = oFrm.oConcepto.CtaSoles.Trim();
                            }
                            else
                            {
                                oRendicionDetalle.codCuenta = oFrm.oConcepto.CtaDolares.Trim();
                            }
                        }
                        else
                        {
                            oRendicionDetalle.numVerPlanCuentas = oFrm.oConcepto.numVerPlanCuentas.Trim();
                            oRendicionDetalle.codCuenta = oFrm.oConcepto.codCuentaAdm.Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtMontoDoc_Leave(object sender, EventArgs e)
        {
            txtMontoDoc.Text = Global.FormatoDecimal(txtMontoDoc.Text);
        }

        private void txtMontoDoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboReparable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboReparable.SelectedValue.ToString() == EnumReparable.R.ToString())
            {
                cboConceptoReparable.Enabled = true;
                txtRefRepa.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                cboConceptoReparable.SelectedValue = Variables.Cero;
                cboConceptoReparable.Enabled = false;
                txtRefRepa.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
            }
        }

        #endregion

    }
}
