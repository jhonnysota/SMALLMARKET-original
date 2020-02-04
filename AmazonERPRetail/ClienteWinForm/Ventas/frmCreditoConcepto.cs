using Entidades.Generales;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas
{
    public partial class frmCreditoConcepto : FrmMantenimientoBase
    {
        #region Constructor

        public frmCreditoConcepto()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        public frmCreditoConcepto(Int32 idConcepto)
            : this()
        {
            oCreditoConcepto = AgenteVentas.Proxy.ObtenerCreditoConcepto(idConcepto);
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        CreditoConceptoE oCreditoConcepto = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oCreditoConcepto == null)
            {
                oCreditoConcepto = new CreditoConceptoE();


                txtUsuRegistra.Text = oCreditoConcepto.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oCreditoConcepto.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oCreditoConcepto.FechaRegistro.ToString();
                txtUsuModifica.Text = oCreditoConcepto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCreditoConcepto.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oCreditoConcepto.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtDescripcion.Text = Convert.ToString(oCreditoConcepto.Descripcion);
                cboMoneda.SelectedValue = Convert.ToInt32(oCreditoConcepto.idMoneda);
                chkMon.Checked = oCreditoConcepto.flagMoneda;

                txtUsuRegistra.Text = oCreditoConcepto.UsuarioRegistro;
                txtRegistro.Text = oCreditoConcepto.FechaRegistro.ToString();
                txtUsuModifica.Text = oCreditoConcepto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCreditoConcepto.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oCreditoConcepto.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

            }

            base.Nuevo();
        }

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);
        }

        void GuardarDatos()
        {
            oCreditoConcepto.Descripcion= txtDescripcion.Text;
            oCreditoConcepto.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oCreditoConcepto.flagMoneda = chkMon.Checked;

        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            BloquearPaneles(true);
            oCreditoConcepto = new CreditoConceptoE();

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oCreditoConcepto != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oCreditoConcepto = AgenteVentas.Proxy.InsertarCreditoConcepto(oCreditoConcepto);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oCreditoConcepto = AgenteVentas.Proxy.ActualizarCreditoConcepto(oCreditoConcepto);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            BloquearPaneles(true);
            base.Editar();
        }

        public override void Cancelar()
        {
            BloquearPaneles(false);
            pnlAuditoria.Focus();
            base.Cancelar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<CreditoConceptoE>(oCreditoConcepto);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmCreditoConcepto_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }

        #endregion

    }
}
