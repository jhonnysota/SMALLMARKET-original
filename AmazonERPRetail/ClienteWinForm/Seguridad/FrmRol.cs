using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura;
using Entidades.Seguridad;
using ClienteWinForm.Seguridad.Busquedas;
using Infraestructura.Recursos;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmRol : FrmMantenimientoBase
    {
        #region Constructores

        public FrmRol()
        {
            InitializeComponent();
        }

        public FrmRol(Rol _Rol)
            : this()
        {
            rol = _Rol;
        } 

        #endregion

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        Rol rol = null;
        //bool bFlag = false;

        #endregion

        #region Procedimientos de Usuario

        void NuevoRegistro()
        {
            if (rol == null)
            {
                rol = new Rol();
                rol.Estado = false;

                idRolTextBox.Text = "0";
                rol.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                rol.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                rol.FechaRegistro = DateTime.Now;
                rol.FechaModificacion = DateTime.Now;

                bsRol.DataSource = rol;
                idRolTextBox.Enabled = false;
                nombreTextBox.Focus();
            }
            else
            {
                idRolTextBox.Text = rol.IdRol.ToString("000");
                rol.FechaModificacion = DateTime.Now;
                rol.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                bsRol.DataSource = rol;
                idRolTextBox.Enabled = false;
            }

            pnlDetalle.Enabled = true;
            bFlag = true;
            base.Nuevo();
        }

        #endregion

        #region Procedimientos Heredados

        public override void Cancelar()
        {
            pnlDetalle.Enabled = false;
            bFlag = false;
            pnlAuditoria.Focus();
            base.Cancelar();
        }

        public override void Cerrar()
        {
            this.Dispose();
            base.Cerrar();
        }

        public override void Editar()
        {
            pnlDetalle.Enabled = true;
            idRolTextBox.Enabled = false;
            bFlag = true;

            base.Editar();
        }

        public override void Grabar()
        {
            try
            {
                bsRol.EndEdit();

                if (!ValidarGrabacion())
                {
                    return;
                }                

                rol = (Rol)bsRol.Current;

                if (rol.IdRol == 0)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        rol = AgenteSeguridad.Proxy.InsertarRol(rol);
                        idRolTextBox.Text = rol.IdRol.ToString("000");
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        rol = AgenteSeguridad.Proxy.ActualizarRol(rol);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                pnlDetalle.Enabled = false;
                pnlAuditoria.Focus();
                base.Grabar();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Nuevo()
        {
            rol = new Rol();
            
            estadoCheckBox.Enabled = false;
            rol.FechaModificacion = DateTime.Now;
            rol.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            bsRol.DataSource = rol;

            pnlDetalle.Enabled = true;
            idRolTextBox.Enabled = false;
            nombreTextBox.Focus();
            bFlag = true;

            base.Nuevo();
        }

        public override bool ValidarGrabacion()
        {
            string resultado = ValidarEntidad<Rol>(rol);

            if (!string.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }
            
            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void FrmRol_Load(object sender, EventArgs e)
        {
            Grid = false;
            NuevoRegistro();
        }

        #endregion

    }
}
