using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmLiquidacionImportacionDetalle : frmResponseBase
    {

        #region Constructores

        public frmLiquidacionImportacionDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LLenarCombos();
        }

        //Nuevo
        public frmLiquidacionImportacionDetalle(String idMoneda)
            :this()
        {
            idMonedaCab = idMoneda;
        }

        //Edición
        public frmLiquidacionImportacionDetalle(LiquidacionImportacionDetE oDetalle, String Bloqueo, String idMoneda)
            :this()
        {
            oLiquidacionDet = oDetalle;
            BloquearTodo = Bloqueo;
            idMonedaCab = idMoneda;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public LiquidacionImportacionDetE oLiquidacionDet = null;
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
                if (oLiquidacionDet != null)
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    chkIndTicaAuto.CheckedChanged -= chkIndTicaAuto_CheckedChanged;
                    txtMontoRec.TextChanged -= txtMontoRec_TextChanged;
                    txtMontoDoc.TextChanged -= txtMontoDoc_TextChanged;

                    cboDocumento.SelectedValue = oLiquidacionDet.idDocumento.ToString();
                    txtSerie.Text = oLiquidacionDet.numSerie;
                    txtNumero.Text = oLiquidacionDet.numDocumento;
                    dtpFecDoc.Value = oLiquidacionDet.FechaDocumento.Date;
                    cboMoneda.SelectedValue = oLiquidacionDet.idMoneda.ToString();
                    txtMontoDoc.Text = oLiquidacionDet.MontoDoc.ToString("N2");

                    cboMonedaRec.SelectedValue = oLiquidacionDet.idMonedaRec.ToString();
                    txtMontoRec.Text = oLiquidacionDet.MontoRec.ToString("N2");

                    chkIndTicaAuto.Checked = oLiquidacionDet.indTicaAuto;
                    txtTica.Text = oLiquidacionDet.TipoCambio.ToString("N3");
                    txtRuc.Tag = oLiquidacionDet.idPersona;
                    txtRuc.Text = oLiquidacionDet.RUC;
                    txtRazonSocial.Text = oLiquidacionDet.RazonSocial;
                    txtCodConcepto.Tag = Convert.ToInt32(oLiquidacionDet.idConcepto) > 0 ? oLiquidacionDet.idConcepto : 0;
                    txtCodConcepto.Text = oLiquidacionDet.codConcepto;
                    txtDesConcepto.Text = oLiquidacionDet.desConcepto;

                    cboReparable.SelectedValue = String.IsNullOrWhiteSpace(oLiquidacionDet.indReparable) ? "N" : oLiquidacionDet.indReparable;
                    cboReparable_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboConceptoReparable.SelectedValue = Convert.ToInt32(oLiquidacionDet.idConceptoRep);
                    txtRefRepa.Text = oLiquidacionDet.desReferenciaRep.Trim();

                    txtUsuarioRegistro.Text = oLiquidacionDet.UsuarioRegistro;
                    txtFechaRegistro.Text = oLiquidacionDet.FechaRegistro.ToString();
                    txtUsuarioMod.Text = oLiquidacionDet.UsuarioModificacion;
                    txtFechaModifica.Text = oLiquidacionDet.FechaModificacion.ToString();

                    chkIndTicaAuto.CheckedChanged += chkIndTicaAuto_CheckedChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    txtMontoRec.TextChanged += txtMontoRec_TextChanged;
                    txtMontoDoc.TextChanged += txtMontoDoc_TextChanged;

                    if (oLiquidacionDet.Opcion == 0)
                    {
                        oLiquidacionDet.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                    }

                    if (BloquearTodo == "S")
                    {
                        pnlReparable.Enabled = false;
                        pnlBase.Enabled = false;
                        btAceptar.Enabled = false;
                    }
                    else
                    {
                        if (oLiquidacionDet.EsAutomatico)
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
                    oLiquidacionDet = new LiquidacionImportacionDetE
                    {
                        Opcion = (Int32)EnumOpcionGrabar.Insertar,
                        EsAutomatico = false
                    };

                    txtRuc.Tag = 0;
                    txtCodConcepto.Tag = 0;
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
                    if (oLiquidacionDet != null)
                    {
                        oLiquidacionDet.idDocumento = cboDocumento.SelectedValue.ToString();
                        oLiquidacionDet.numSerie = txtSerie.Text.Trim();
                        oLiquidacionDet.numDocumento = txtNumero.Text.Trim();
                        oLiquidacionDet.FechaDocumento = dtpFecDoc.Value.Date;
                        oLiquidacionDet.idMoneda = cboMoneda.SelectedValue.ToString();
                        oLiquidacionDet.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                        oLiquidacionDet.MontoDoc = Convert.ToDecimal(txtMontoDoc.Text);
                        oLiquidacionDet.idMonedaRec = cboMonedaRec.SelectedValue.ToString();
                        oLiquidacionDet.desMonedaRec = ((MonedasE)cboMonedaRec.SelectedItem).desAbreviatura;
                        oLiquidacionDet.MontoRec = Convert.ToDecimal(txtMontoRec.Text);
                        oLiquidacionDet.indTicaAuto = chkIndTicaAuto.Checked;
                        oLiquidacionDet.TipoCambio = Convert.ToDecimal(txtTica.Text);
                        oLiquidacionDet.idPersona = Convert.ToInt32(txtRuc.Tag) == 0 ? (Int32?)null : Convert.ToInt32(txtRuc.Tag);
                        oLiquidacionDet.RazonSocial = txtRazonSocial.Text.Trim();
                        oLiquidacionDet.RUC = txtRuc.Text.Trim();
                        oLiquidacionDet.idConcepto = String.IsNullOrWhiteSpace(txtCodConcepto.Text) ? (Int32?)null : Convert.ToInt32(txtCodConcepto.Tag);
                        oLiquidacionDet.codConcepto = txtCodConcepto.Text;
                        oLiquidacionDet.desConcepto = txtDesConcepto.Text;

                        if (cboMonedaRec.SelectedValue.ToString() == "01")
                        {
                            oLiquidacionDet.SolesRec = oLiquidacionDet.MontoRec;
                            oLiquidacionDet.DolaresRec = oLiquidacionDet.MontoRec / oLiquidacionDet.TipoCambio;
                        }
                        else
                        {
                            oLiquidacionDet.DolaresRec = oLiquidacionDet.MontoRec;
                            oLiquidacionDet.SolesRec = oLiquidacionDet.MontoRec * oLiquidacionDet.TipoCambio;

                        }

                        if (oLiquidacionDet.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            oLiquidacionDet.UsuarioModificacion = oLiquidacionDet.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oLiquidacionDet.FechaModificacion = oLiquidacionDet.FechaRegistro = VariablesLocales.FechaHoy;
                        }
                        else
                        {
                            oLiquidacionDet.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oLiquidacionDet.FechaModificacion = VariablesLocales.FechaHoy;
                        }

                        oLiquidacionDet.indReparable = cboReparable.SelectedValue.ToString();
                        oLiquidacionDet.idConceptoRep = Convert.ToInt32(cboConceptoReparable.SelectedValue);
                        oLiquidacionDet.desReferenciaRep = txtRefRepa.Text.Trim();

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
                Global.MensajeAdvertencia("Debe ingresar el Tipo de Cambio.");
                return false;
            }

            if (Convert.ToInt32(txtRuc.Tag) == 0)
            {
                Global.MensajeAdvertencia("Debe ingresar un auxiliar.");
                return false;
            }

            if (Convert.ToInt32(txtCodConcepto.Tag) == 0)
            {
                Global.MensajeAdvertencia("Debe ingresar un concepto.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(oLiquidacionDet.codCuenta))
            {
                Global.MensajeAdvertencia("El concepto escogido no tiene ninguna cuenta contable asociada.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmLiquidacionImportacionDetalle_Load(object sender, EventArgs e)
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
            txtTica.Text = Global.FormatoDecimal(txtTica.Text, 3);
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
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

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
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
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

                    if (!oLiquidacionDet.EsAutomatico)
                    {
                        if (oFrm.oConcepto.indCuentasMon)
                        {
                            oLiquidacionDet.numVerPlanCuentas = oFrm.oConcepto.numVerPlanCuentas.Trim();

                            if (idMonedaCab == Variables.Soles)
                            {
                                oLiquidacionDet.codCuenta = oFrm.oConcepto.CtaSoles.Trim();
                            }
                            else
                            {
                                oLiquidacionDet.codCuenta = oFrm.oConcepto.CtaDolares.Trim();
                            }
                        }
                        else
                        {
                            oLiquidacionDet.numVerPlanCuentas = oFrm.oConcepto.numVerPlanCuentas.Trim();
                            oLiquidacionDet.codCuenta = oFrm.oConcepto.codCuentaAdm.Trim();
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
