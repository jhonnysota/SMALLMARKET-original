using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmFinanciamiento : FrmMantenimientoBase
    {

        #region Constructores

        public frmFinanciamiento()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        //Nuevo
        public frmFinanciamiento(List<BancosE> oListaBancos, List<TipoLineaCreditoE> oListaLineaCredito)
            : this()
        {
            LlenarCombos(oListaBancos, oListaLineaCredito);
        }

        //Edición
        public frmFinanciamiento(Int32 idFina, List<BancosE> oListaBancos, List<TipoLineaCreditoE> oListaLineaCredito)
            : this()
        {
            LlenarCombos(oListaBancos, oListaLineaCredito);
            oFinanciamiento = AgenteTesoreria.Proxy.ObtenerFinanciamiento(idFina);
            Text = "Financiamiento (N° " + oFinanciamiento.idFinanciamiento + ")";
        } 

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        FinanciamientoE oFinanciamiento = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos(List<BancosE> oListaBancos, List<TipoLineaCreditoE> oLineaCredito)
        {
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListaBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");
            ComboHelper.RellenarCombos<TipoLineaCreditoE>(cboLineaCredito, (from x in oLineaCredito orderby x.idLinea select x).ToList(), "idLinea", "Descripcion");

            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in oListaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");
        }

        void Registros()
        {
            oFinanciamiento.Fecha = dtpFecha.Value.Date;
            oFinanciamiento.codFinanciamiento = txtCodigo.Text.ToString();
            oFinanciamiento.idBanco = Convert.ToInt32(cboBancosEmpresa.SelectedValue);
            oFinanciamiento.idLinea = Convert.ToInt32(cboLineaCredito.SelectedValue);
            oFinanciamiento.Importe = String.IsNullOrWhiteSpace(txtImporte.Text) ? 0 : Convert.ToDecimal(txtImporte.Text);
            oFinanciamiento.idMoneda = cboMoneda.SelectedValue.ToString();
            oFinanciamiento.Garantia = String.IsNullOrWhiteSpace(txtGarantia.Text) ? 0 : Convert.ToDecimal(txtGarantia.Text);
            oFinanciamiento.Plazo = String.IsNullOrWhiteSpace(txtPlazo.Text) ? 0 : Convert.ToInt32(txtPlazo.Text);
            oFinanciamiento.Tea = String.IsNullOrWhiteSpace(txtTea.Text) ? 0 : Convert.ToDecimal(txtTea.Text);

            if (String.IsNullOrWhiteSpace(txtIdFinan.Text.Trim()))
            {
                oFinanciamiento.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oFinanciamiento.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oFinanciamiento == null)
                {
                    oFinanciamiento = new FinanciamientoE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                    };

                    cboBancosEmpresa.SelectedValue = Variables.Cero;
                    cboLineaCredito.SelectedValue = Variables.Cero;

                    txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();
                }
                else
                {
                    txtIdFinan.Text = oFinanciamiento.idFinanciamiento.ToString();
                    dtpFecha.Value = oFinanciamiento.Fecha.Date;
                    txtCodigo.Text = oFinanciamiento.codFinanciamiento;
                    cboBancosEmpresa.SelectedValue = Convert.ToInt32(oFinanciamiento.idBanco);
                    cboLineaCredito.SelectedValue = Convert.ToInt32(oFinanciamiento.idLinea);
                    txtImporte.Text = oFinanciamiento.Importe.ToString("N2");
                    cboMoneda.SelectedValue = oFinanciamiento.idMoneda.ToString();
                    txtGarantia.Text = oFinanciamiento.Garantia.ToString("N2");
                    txtPlazo.Text = oFinanciamiento.Plazo.ToString();
                    txtTea.Text = oFinanciamiento.Tea.ToString("N2");
                    txtUsuRegistra.Text = oFinanciamiento.UsuarioRegistro;
                    txtFechaRegistro.Text = oFinanciamiento.FechaRegistro.ToString();
                    txtUsuModifica.Text = oFinanciamiento.UsuarioModificacion;
                    txtFechaModifica.Text = oFinanciamiento.FechaModificacion.ToString();
                }

                if (oFinanciamiento.indEstado)
                {
                    Global.MensajeComunicacion("No podrá hacer modificaciones.");
                    pnlDatos.Enabled = false;
                    lblGlosaBaja.Visible = true;
                    txtBaja.Visible = true;
                    txtBaja.Text = oFinanciamiento.fecBaja.ToString();
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }
                else
                {
                    base.Nuevo();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                Registros();

                if (ValidarGrabacion())
                {
                    if (String.IsNullOrWhiteSpace(txtIdFinan.Text))
                    {
                        if (Global.MensajeConfirmacion("Grabar el Registro?") == DialogResult.Yes)
                        {
                            oFinanciamiento = AgenteTesoreria.Proxy.InsertarFinanciamiento(oFinanciamiento);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion("Actualizar el Registro?") == DialogResult.Yes)
                        {
                            oFinanciamiento = AgenteTesoreria.Proxy.ActualizarFinanciamiento(oFinanciamiento);
                        }
                    }

                    base.Grabar();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (Convert.ToInt32(cboBancosEmpresa.SelectedValue) == 0)
            {
                Global.MensajeFault("Debe escoger una Entidad Bancaria.");
                cboBancosEmpresa.Focus();
                return false;
            }

            if (Convert.ToInt32(cboLineaCredito.SelectedValue) == 0)
            {
                Global.MensajeFault("Debe escoger un Tipo de Linea de Crédito.");
                cboLineaCredito.Focus();
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtImporte.Text.Trim()) || txtImporte.Text == "0.00")
            {
                Global.MensajeFault("Debe colocar un importe.");
                txtImporte.Focus();
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos de Usuario

        #endregion

        #region Eventos

        private void frmFinanciamiento_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            txtImporte.Text = Global.FormatoDecimal(txtImporte.Text);
        }

        private void txtGarantia_Leave(object sender, EventArgs e)
        {
            txtGarantia.Text = Global.FormatoDecimal(txtGarantia.Text);
        }

        private void txtTea_Leave(object sender, EventArgs e)
        {
            txtTea.Text = Global.FormatoDecimal(txtTea.Text);
        }

        private void cboBancosEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboLineaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        #endregion

    }
}
