using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmAccion : FrmMantenimientoBase
    {

        #region Constructores

        public FrmAccion()
        {
            InitializeComponent();
        }

        public FrmAccion(AccionE _Accion)
            : this()
        {
            accion = _Accion;
        } 

        #endregion

        #region Variables

        AccionE accion = null;
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }

        #endregion

        #region Procedimientos Usuario

        void Datos()
        {
            accion.Nombre = txtNombre.Text.Trim();
            accion.Descripcion = txtDescripcion.Text.Trim();

            if (String.IsNullOrWhiteSpace(txtIdAccion.Text.Trim()))
            {
                accion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                accion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (accion == null)
            {
                accion = new AccionE();
                
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                
                txtNombre.Focus();
            }
            else
            {
                txtIdAccion.Text = accion.IdAccion.ToString("000");

                txtNombre.Text = accion.Nombre;
                txtDescripcion.Text = accion.Descripcion;
                //chkBaja.Checked = accion.Estado;
                txtUsuarioModificacion.Text = accion.UsuarioRegistro;
                txtUsuarioRegistro.Text = accion.UsuarioModificacion;
                txtFechaRegistro.Text = accion.FechaRegistro.ToString();
                txtFechaModificacion.Text = accion.FechaModificacion.ToString();
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                Datos();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtIdAccion.Text.Trim()))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        accion = AgenteSeguridad.Proxy.InsertarAccion(accion);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        accion = AgenteSeguridad.Proxy.ActualizarAccion(accion);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            string res = ValidarEntidad<AccionE>(accion);

            if (!string.IsNullOrEmpty(res)) {
                Global.MensajeComunicacion(res);
                return false;
            }

            return base.ValidarGrabacion();
        }        

        #endregion        

        #region Eventos

        private void FrmAccion_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void FrmAccion_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.F2: //Nuevo Registro
            //        if (!bFlag)
            //        {
            //            Nuevo();    
            //        }                    
            //        break;
            //    case Keys.F3: //Editar Registro
            //        if (((Accion)bsAccion.Current).IdAccion != 0)
            //        {
            //            Editar();
            //        }
            //        break;
            //    case Keys.F5: //Grabar y Actualizar Registro
            //        if (bFlag)
            //        {
            //            Grabar();
            //        }
            //        break;
            //    case Keys.F6: //Cancelar Nuevo y Editar
            //        Cancelar();
            //        break;
            //    case Keys.F7: //Imprimir
            //        Imprimir();
            //        break;
            //    case Keys.Escape: //Salir del Sistema
            //        Cerrar();
            //        break;
            //    default:
            //        break;
            //}
        }

        #endregion

    }
}
