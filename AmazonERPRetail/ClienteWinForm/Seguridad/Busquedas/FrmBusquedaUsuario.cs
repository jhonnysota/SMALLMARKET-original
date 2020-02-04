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
using Infraestructura;

namespace ClienteWinForm.Seguridad.Busquedas
{
        
    public partial class FrmBusquedaUsuario : FrmBusquedaBase
    {
        public Usuario usuario = null;
        List<Usuario> listausuario = null;
        public FrmBusquedaUsuario()
        {
            InitializeComponent();
        }

        private void FrmBusquedaUsuario_Load(object sender, EventArgs e)
        {
            Global.CalcularAnchoGrilla(0, usuarioDataGridView);
        }

        protected override void Buscar()
        {

            base.Buscar();
            if (chkAnulado.Checked)
                listausuario = new SeguridadServiceAgent().Proxy.ListarUsuario(txtFiltro.Text, true, false);                           
            else
                listausuario = new SeguridadServiceAgent().Proxy.ListarUsuario(txtFiltro.Text, true, true);                
            
            bsBase.DataSource = listausuario;

            if (usuarioDataGridView.Rows.Count > 10)
            {
                Global.CalcularAnchoGrilla(3, usuarioDataGridView);
            }
            else
            {
                Global.CalcularAnchoGrilla(0, usuarioDataGridView);
            }
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                usuario = (Usuario)bsBase.Current;
                usuario.Persona = new MaestrosServiceAgent().Proxy.RecuperarPersonaPorID(usuario.IdPersona);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("NO EXITEN DATOS", "MENSAJE");
            }
            base.Aceptar();
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //List<Usuario> res = (from x in listausuario where x.Credencial.Contains(txtFiltro.Text) select x).ToList();
            //bindingSourceBase.DataSource = res;
        }

        private void usuarioDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }
    }
}
