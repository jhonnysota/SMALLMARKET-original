using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Seguridad;
using Entidades.Maestros;
using Presentadora.AgenteServicio;
using Infraestructura;

namespace ClienteWinForm.Seguridad.Busquedas
{
    public partial class FrmBusquedaUsuarioEmpresaLocalPerfil : FrmBusquedaBase
    {

        #region Agentes
        SeguridadServiceAgent AgenteSeguridad
        {
            get
            {
                return new SeguridadServiceAgent();
            }
        }

        #endregion

        #region Variables
  
        List<UsuarioEmpresaLocalPerfil> Lista = null;
        public UsuarioEmpresaLocalPerfil vUsuarioEmpresaLocalPerfil = null;
        //public Vendedor vendedor = null;
        public int vLocal = 0;
        public bool ValidaPerfil = true;
        public bool Estado;
        #endregion

        public FrmBusquedaUsuarioEmpresaLocalPerfil()
        {
            InitializeComponent();
        }

        private void FrmBusquedaUsuarioEmpresaLocalPerfil_Load(object sender, EventArgs e)
        {

        }
        protected override void Buscar()
        {
            ValidaPerfil = true;
            Estado = true;
            if (chkAnulado.Checked == false)
            {
                ValidaPerfil = false;
            }
            //ValidaPerfil = true;
            bsBase.DataSource = Lista = AgenteSeguridad.Proxy.Listar_UsuarioEmpresaLocalPerfil(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,VariablesLocales.SesionLocal.IdLocal,2,txtFiltro.Text,ValidaPerfil,Estado);
            if (Lista == null)
            {
                Global.MensajeComunicacion("No se encuentra ningun vendedor asociado a este local");
                return;
            }
           // base.Buscar();
        }


        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                vUsuarioEmpresaLocalPerfil = (UsuarioEmpresaLocalPerfil)bsBase.Current;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("NO EXITEN DATOS", "MENSAJE");
            }
            base.Aceptar();
        }

        private void dgvVendedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }
    }
}
