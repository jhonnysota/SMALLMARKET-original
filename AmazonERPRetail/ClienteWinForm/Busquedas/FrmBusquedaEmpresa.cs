using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
//using ContratoWCF;
using Entidades;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class FrmBusquedaEmpresa : FrmBusquedaBase
    {
        
        public FrmBusquedaEmpresa()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            this.Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvEmpresa);
        }

        #region Variables

        public Empresa empresa = null;

        #endregion

        #region Procedimientos Heredados
        
        protected override void Buscar()
        {
            //if(!chkAnulado.Checked)
            //    bsBase.DataSource = new MaestrosServiceAgent().Proxy.ListarEmpresaPorEstado(txtFiltro.Text, true, true);
            //else
            //    bsBase.DataSource = new MaestrosServiceAgent().Proxy.ListarEmpresaPorEstado(txtFiltro.Text, true, false);
            // base.Buscar();


            //if (dataGridView1.Rows.Count > 10)
            //{
            //    Global.CalcularAnchoGrilla(3, dataGridView1);
            //}
            //else
            //{
            //    Global.CalcularAnchoGrilla(0, dataGridView1);
            //}
            bsBase.DataSource = new MaestrosServiceAgent().Proxy.ListarEmpresa(txtFiltro.Text);
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                empresa = (Empresa)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeFault("No existen datos. Presione cancelar.");
            }
        } 

        #endregion

        #region Eventos

        private void FrmBusquedaEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void dgvEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void dgvEmpresa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvEmpresa, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        #endregion

    }
}
