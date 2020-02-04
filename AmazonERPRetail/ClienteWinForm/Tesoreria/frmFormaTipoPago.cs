using System;
using System.Collections.Generic;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmFormaTipoPago : frmResponseBase
    {

        public frmFormaTipoPago(List<FormaTipoPagoE> oLista)
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
            oListaBusqueda = oLista;
        }

        #region Variables

        public FormaTipoPagoE FormaTipoPagoItem = null;
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        List<FormaTipoPagoE> oListaBusqueda = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<TipoPagoE> ListaTipoPago = AgenteTesoreria.Proxy.ListarTipoPagoCombo("E", VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ListaTipoPago.Add(new TipoPagoE() { codTipoPago = Variables.Cero.ToString(), desTipoPago = Variables.Seleccione });
            ComboHelper.RellenarCombos<TipoPagoE>(cboTipoPago, (from x in ListaTipoPago orderby x.codTipoPago select x).ToList(), "codTipoPago", "desTipoPago");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (FormaTipoPagoItem == null)
            {
                FormaTipoPagoItem = new FormaTipoPagoE();

                cboTipoPago.SelectedValue = "0";
                cboTipoPago_SelectionChangeCommitted(new Object(), new EventArgs());
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                FormaTipoPagoItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                cboTipoPago.SelectedValue = FormaTipoPagoItem.codTipoPago.ToString();
                cboTipoPago_SelectionChangeCommitted(new Object(), new EventArgs());
                cboConcepto.SelectedValue = FormaTipoPagoItem.idConcepto;

                txtUsuarioRegistro.Text = FormaTipoPagoItem.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(FormaTipoPagoItem.FechaRegistro);
                txtUsuarioModificacion.Text = FormaTipoPagoItem.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(FormaTipoPagoItem.FechaModificacion);

                if (FormaTipoPagoItem.Opcion == 0)
                {
                    FormaTipoPagoItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (FormaTipoPagoItem != null)
                {
                    FormaTipoPagoItem.codTipoPago = cboTipoPago.SelectedValue.ToString();
                    FormaTipoPagoItem.desTipoPago = ((TipoPagoE)cboTipoPago.SelectedItem).desTipoPago;
                    FormaTipoPagoItem.idConcepto = Convert.ToInt32(cboConcepto.SelectedValue);
                    FormaTipoPagoItem.desConcepto = ((TipoPagoDetE)cboConcepto.SelectedItem).desConcepto;

                    FormaTipoPagoItem.Opcion = FormaTipoPagoItem.Opcion;

                    if (FormaTipoPagoItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        FormaTipoPagoItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        FormaTipoPagoItem.FechaRegistro = VariablesLocales.FechaHoy;
                        FormaTipoPagoItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        FormaTipoPagoItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        FormaTipoPagoItem.UsuarioModificacion = txtUsuarioModificacion.Text;
                        FormaTipoPagoItem.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }

                    if (ValidarGrabacion())
                    {
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
            if (cboTipoPago.SelectedValue.ToString() == "0")
            {
                Global.MensajeFault("Tiene que escoger un Tipo de Pago.");
                return false;
            }

            if (cboConcepto.SelectedValue.ToString() == "0")
            {
                Global.MensajeFault("Tiene que escoger un Concepto.");
                return false;
            }

            if (oListaBusqueda != null && FormaTipoPagoItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                FormaTipoPagoE oTipo = oListaBusqueda.Find
                (
                    delegate (FormaTipoPagoE ftp) { return ftp.codTipoPago == cboTipoPago.SelectedValue.ToString() && ftp.idConcepto == Convert.ToInt32(cboConcepto.SelectedValue); }
                );

                if (oTipo != null)
                {
                    Global.MensajeFault("Este concepto ya se encuentra agregado en la Lista de Formas de Pagos.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmFormaTipoPago_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void cboTipoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoPago.SelectedValue != null)
                {
                    List<TipoPagoDetE> oLista = new List<TipoPagoDetE>(((TipoPagoE)cboTipoPago.SelectedItem).DetalleTipoPago);
                    oLista.Add(new TipoPagoDetE() { idConcepto = Variables.Cero, desConcepto = Variables.Seleccione });
                    ComboHelper.RellenarCombos<TipoPagoDetE>(cboConcepto, (from x in oLista orderby x.idConcepto select x).ToList(), "idConcepto", "desConcepto", false);

                    if (cboTipoPago.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboConcepto.Enabled = false;
                    }
                    else
                    {
                        cboConcepto.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
