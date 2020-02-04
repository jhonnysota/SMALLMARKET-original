using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infraestructura.Winform;

using Presentadora.AgenteServicio;
using Infraestructura;
using Entidades;
using Entidades.Maestros;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Maestros.Busqueda
{
    public partial class FrmBusquedaLocal : FrmBusquedaBase
    {

        public FrmBusquedaLocal()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            FormatoGrid(localDataGridView, true);
        }

        #region Variables
        
        public LocalE local = null;
        public int codigoEmpresa = 0;
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } } 

        #endregion Variables

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            //if (!chkAnulado.Checked)
            //    bindingSourceBase.DataSource = AgenteMaestro.Proxy.ListarLocal(txtFiltro.Text, true, true, Convert.ToInt32(cbempresa.SelectedValue));
            //else
            //    bindingSourceBase.DataSource = AgenteMaestro.Proxy.ListarLocal(txtFiltro.Text, true, false, Convert.ToInt32(cbempresa.SelectedValue));

            bsBase.DataSource = AgenteMaestro.Proxy.ListarLocal(txtFiltro.Text, true, chkAnulado.Checked, Convert.ToInt32(cbempresa.SelectedValue));

            base.Buscar();
            txtFiltro.Focus();

            localDataGridView.AutoResizeColumns();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                local = (LocalE)bsBase.Current;
                local.NombreEmpresa = ((Empresa)cbempresa.SelectedItem).NombreComercial;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("NO EXITEN DATOS", "MENSAJE");
            }

            base.Aceptar();
        }

        #endregion

        #region Eventos

        private void FrmBusquedaLocal_Load(object sender, EventArgs e)
        {
            ComboHelper.LlenarCombos<Empresa>(cbempresa, AgenteMaestro.Proxy.ListarEmpresa(""), "IdEmpresa", "NombreComercial");
        }

        private void localDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void localDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(localDataGridView, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        #endregion Eventos

    }
}
