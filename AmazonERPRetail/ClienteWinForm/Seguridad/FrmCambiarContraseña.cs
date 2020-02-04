using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Tools;
using Entidades.Seguridad;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmCambiarContraseña : Form
    {
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }

        public FrmCambiarContraseña()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbclave.Text.Trim() != tbrepiteclave.Text.Trim())
            {
                Global.MensajeComunicacion("Las claves deben ser iguales");
                return;
            }

            if (String.IsNullOrEmpty(tbclave.Text))
            {
                Global.MensajeComunicacion("Debe ingresar una clave");
                return;
            }

            if (Global.MensajeConfirmacion("Desea grabar") != DialogResult.Yes)
            {
                return;
            }
           
            AgenteSeguridad.Proxy.ModificarClave(VariablesLocales.SesionUsuario.Credencial, EncryptHelper.EncryptToByte(tbclave.Text), false);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmCambiarContraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
