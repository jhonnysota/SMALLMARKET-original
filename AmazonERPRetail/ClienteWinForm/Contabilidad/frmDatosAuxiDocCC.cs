using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmDatosAuxiDocCC : frmResponseBase
    {

        #region Constructores

        public frmDatosAuxiDocCC()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
        }

        public frmDatosAuxiDocCC(String Tipo, List<VoucherItemE> voucherItems)
            :this()
        {
            switch (Tipo)
            {
                case "A":
                    pnlBase.Enabled = true;
                    break;
                case "D":
                    pnlDocumento.Enabled = true;
                    break;
                case "C":
                    pnlCostos.Enabled = true;
                    break;
                default:
                    break;
            }

            TipoActualizacion = Tipo;
            ListaVoucher = voucherItems;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<VoucherItemE> ListaVoucher = null;
        String TipoActualizacion = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indBaja == false
                                                                      select x).ToList();
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = " " + Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   orderby x.desDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);
        }

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            if (ValidarGrabacion())
            {
                switch (TipoActualizacion)
                {
                    case "A": //Auxiliar

                        foreach (VoucherItemE item in ListaVoucher)
                        {
                            item.idPersona = Convert.ToInt32(txtRuc.Tag);
                        }

                        break;
                    case "D": //Documento

                        foreach (VoucherItemE item in ListaVoucher)
                        {
                            item.idDocumento = cboDocumento.SelectedValue.ToString();
                            item.serDocumento = txtSerie.Text.Trim();
                            item.numDocumento = txtNumDoc.Text.Trim();
                        }

                        break;
                    case "C": //C.Costos

                        foreach (VoucherItemE item in ListaVoucher)
                        {
                            item.idCCostos = txtCCostos.Text.Trim();
                        }

                        break;
                    default:
                        break;
                }

                Int32 resp = AgenteContabilidad.Proxy.ActualizarVoucherItemAuxiCcDoc(ListaVoucher, TipoActualizacion);

                if (resp > 0)
                {
                    Global.MensajeComunicacion(String.Format("Registros actualizados {0}...!!!", resp.ToString()));
                    base.Aceptar(); 
                }
            }
        }

        public override bool ValidarGrabacion()
        {
            switch (TipoActualizacion)
            {
                case "A": //Auxiliar

                    if (Convert.ToInt32(txtRuc.Tag) == 0)
                    {
                        Global.MensajeAdvertencia("Debe ingresar un Auxiliar");
                        txtRuc.Focus();
                        return false;
                    }

                    break;
                case "D": //Documento

                    if (Convert.ToString(cboDocumento.SelectedValue) == "0")
                    {
                        Global.MensajeAdvertencia("Debe ingresar un tipo de documento");
                        cboDocumento.Focus();
                        return false;
                    }

                    if (String.IsNullOrWhiteSpace(txtNumDoc.Text.Trim()))
                    {
                        Global.MensajeAdvertencia("Debe ingresar el número del documento");
                        txtNumDoc.Focus();
                        return false;
                    }

                    break;
                case "C": //C.Costos

                    if (String.IsNullOrWhiteSpace(txtCCostos.Text.Trim()))
                    {
                        Global.MensajeAdvertencia("Debe ingresar el Centro de Costos");
                        txtCCostos.Focus();
                        return false;
                    }

                    break;
                default:
                    break;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmDatosAuxiDocCC_Load(object sender, EventArgs e)
        {
            if (TipoActualizacion == "A")
            {
                txtRuc.Tag = 0;
            }
        }

        private void btCentroC_Click(object sender, EventArgs e)
        {
            Int32 Nivel = 1;

            if (VariablesLocales.oConParametros != null)
            {
                if (VariablesLocales.oConParametros.numNivelCCosto > 0)
                {
                    Nivel = Convert.ToInt32(VariablesLocales.oConParametros.numNivelCCosto);
                }
            }

            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(Nivel);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtCCostos.Text = oFrm.CentroCosto.idCCostos;
                txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtAuxiliar.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtAuxiliar.TextChanged -= txtAuxiliar_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtAuxiliar.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtAuxiliar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtAuxiliar.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtAuxiliar.Text = String.Empty;
                        Global.MensajeFault("EL Ruc ingresado no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtAuxiliar.TextChanged += txtAuxiliar_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtAuxiliar.Text = String.Empty;
        }

        private void txtAuxiliar_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        private void txtAuxiliar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAuxiliar.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtAuxiliar.TextChanged -= txtAuxiliar_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtAuxiliar.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtAuxiliar.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtAuxiliar.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtAuxiliar.Text = String.Empty;
                        Global.MensajeFault("El Ruc ingresado no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtAuxiliar.TextChanged += txtAuxiliar_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

    }
}
