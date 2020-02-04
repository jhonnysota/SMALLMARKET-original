using System;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Maestros
{
    public partial class frmEstablecimientos : FrmMantenimientoBase
    {

        #region Constructores
        
        public frmEstablecimientos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        public frmEstablecimientos(Int32 idEmpresa_, Int32 idLocal_, Int32 idEstablecimiento_, EnumOpcionGrabar Opcion, string Titulo)
            : this()
        {
            if (Opcion == EnumOpcionGrabar.Actualizar)
            {
                oEstablecimiento = AgenteMaestro.Proxy.ObtenerEstablecimientos(idEmpresa_, idLocal_, idEstablecimiento_);
                Text = "Zona - " + Titulo;
            }
            else
            {
                Text = "Nueva Zona";
                idEmpresa = idEmpresa_;
                idLocal = idLocal_;
            }
        }

        #endregion Constructores

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public EstablecimientosE oEstablecimiento = null;
        Int32 idEmpresa = Variables.Cero;
        Int32 idLocal = Variables.Cero;
        //Int32 idEstablecimiento = Variables.Cero;
        Int32 Opcion = Variables.Cero;

        #endregion Variables

        #region Procedimientos de Usuario

        void DatosGrabacion()
        {
            oEstablecimiento.Descripcion = txtDescripcion.Text;

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oEstablecimiento.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oEstablecimiento.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oEstablecimiento == null)
            {
                oEstablecimiento = new EstablecimientosE();
                oEstablecimiento.idEmpresa = idEmpresa;
                oEstablecimiento.idLocal = idLocal;
                //oEstablecimiento.idEstablecimiento = idEstablecimiento;
                //txtIdEstablecimiento.Text = idEstablecimiento.ToString();

                txtUsuarioRegistro.Text = txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtIdEstablecimiento.Text = oEstablecimiento.idEstablecimiento.ToString();
                txtDescripcion.Text = oEstablecimiento.Descripcion;

                txtUsuarioRegistro.Text = oEstablecimiento.UsuarioRegistro;
                txtFechaRegistro.Text = oEstablecimiento.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oEstablecimiento.UsuarioModificacion;
                txtFechaModificacion.Text = oEstablecimiento.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                DatosGrabacion();
                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oEstablecimiento = AgenteMaestro.Proxy.InsertarEstablecimientos(oEstablecimiento);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oEstablecimiento = AgenteMaestro.Proxy.ActualizarEstablecimientos(oEstablecimiento);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmEstablecimientos_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        #endregion Eventos

    }
}
