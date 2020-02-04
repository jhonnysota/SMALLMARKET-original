using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Seguridad;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura;
using Infraestructura.Tools;
using ClienteWinForm.Seguridad.Busquedas;
using Infraestructura.Recursos;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmRestablecerPassword : FrmMantenimientoBase
    {

        public FrmRestablecerPassword()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvUsuario, true);
        }

        #region Variables
        
        List<Usuario> listaUsuario = null;
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        Usuario usuario = null; 

        #endregion        

        #region Procedimientos Heredados

        public override void Editar()
        {
            pnlDetalle.Enabled = true;
            base.Editar();
        }

        public override void Buscar()
        {
            listaUsuario = AgenteSeguridad.Proxy.ListarUsuario("", false, false);
            
            usuarioBindingSource.DataSource = listaUsuario;

            base.Buscar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
        }

        public override void Grabar()
        {
            if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) != DialogResult.Yes)
            {
                return;
            }

            if (textBox1.Text == "") 
            {
                Global.MensajeComunicacion("Debe generar una clave");
                return;
            }

            usuario.Clave = EncryptHelper.EncryptToByte(textBox1.Text);
            AgenteSeguridad.Proxy.ModificarClave(usuario.Credencial, usuario.Clave, true);

            pnlDetalle.Enabled = false;
            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
            base.Grabar();
        }

        #endregion        

        #region Eventos
        
        private void FrmRestablecerPassword_Load(object sender, EventArgs e)
        {
            Grid = false;
            base.Grabar();
            pnlDetalle.Enabled = false;
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuario = (Usuario)usuarioBindingSource.Current;
            textBox1.Text = EncryptHelper.GenerateClave();
        } 

        #endregion
    }
}
