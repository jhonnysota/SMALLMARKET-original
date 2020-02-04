using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infraestructura.Enumerados;
using Entidades.Seguridad;
using Presentadora.AgenteServicio;
using Infraestructura.Tools;

namespace ClienteWinForm.Seguridad
{
    public partial class FrmValidaAccion : Form
    {

        EnumAccion enumAccion;
        public Usuario oUsuario = new Usuario();

        public FrmValidaAccion()
        {
            InitializeComponent();
        }

        #region Propiedades
        public SeguridadServiceAgent AgenteSeguridad
        {
            get
            {
                return new SeguridadServiceAgent();
            }
        }

        #endregion

        public FrmValidaAccion(EnumAccion enumerado)
        {

            InitializeComponent();
            enumAccion = enumerado;
        }

        private void FrmValidaAccion_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            oUsuario = AgenteSeguridad.Proxy.RecuperarUsuarioAcccion(txtUsuario.Text, EncryptHelper.EncryptToByte(txtClave.Text), VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(enumAccion));


            if (oUsuario != null)
            {

                oUsuario.Roles = new List<Rol>();
                oUsuario.Roles.Add(new Rol { IdRol = (int)EnumAccion.AprobacionDiseno, Nombre = "Aprobar Diseño" });
                oUsuario.Roles.Add(new Rol { IdRol = (int)EnumAccion.AprobacionPedido, Nombre = "Aprobar Pedido" });
                oUsuario.Roles.Add(new Rol { IdRol = (int)EnumAccion.AprobacionAperturaCajaVenta, Nombre = "AprobacionAperturaCajaVenta" });
                List<AccionE> oListaAccion = new List<AccionE>();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                
            }
            else
            {
                MessageBox.Show("No tiene Permiso para realizar esta accion");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
