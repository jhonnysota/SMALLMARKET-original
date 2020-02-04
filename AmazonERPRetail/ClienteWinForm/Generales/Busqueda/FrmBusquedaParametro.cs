using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Entidades.Generales;

namespace ClienteWinForm.Generales.Busqueda
{
    public partial class FrmBusquedaParametro : FrmBusquedaBase
    {
        public FrmBusquedaParametro()
        {
            InitializeComponent();            
        }

        public ParametroE parametro = null;

        protected override void Buscar()
        {
            base.Buscar();
            if (chkAnulado.Checked)
            {
                //bsBase.DataSource = new GeneralesServiceAgent().Proxy.ListarParametro(txtFiltro.Text, true, false,VariablesLocales.SesionUsuario.Empresa.IdEmpresa);  
            }
            else
            {
                //bsBase.DataSource = new GeneralesServiceAgent().Proxy.ListarParametro(txtFiltro.Text, true, true,VariablesLocales.SesionUsuario.Empresa.IdEmpresa);  
            }

        }

            protected override void Aceptar()
            {
                if (bsBase.Count > 0)
                {
                    parametro = (ParametroE)bsBase.Current;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("NO EXITEN DATOS", "MENSAJE");
                }

                base.Aceptar();
            }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, btnBuscar); 
        }

        private void FrmBusquedaParametro_Load(object sender, EventArgs e)
        {

        }

        private void parametroDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

    }
}
