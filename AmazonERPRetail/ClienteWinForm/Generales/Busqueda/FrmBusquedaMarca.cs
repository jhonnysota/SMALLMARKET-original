using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infraestructura;
using Presentadora.AgenteServicio;
using Entidades.Generales;

namespace ClienteWinForm.Generales.Busqueda
{
    public partial class FrmBusquedaMarca : FrmBusquedaBase
    {
        public Marca marca = null;        
        public FrmBusquedaMarca()
        {
            InitializeComponent();
        }

        protected override void Buscar()
        {
            
            //base.Buscar();
            //if (chkAnulado.Checked)
            //{
            //    bsBase.DataSource = (from x in new GeneralesServiceAgent().Proxy.ListarMarca(txtFiltro.Text, false) where x.IdMarca > 0 select x).ToList();
            //}
            //else {
            //    bsBase.DataSource = (from x in new GeneralesServiceAgent().Proxy.ListarMarca(txtFiltro.Text, true) where x.IdMarca > 0 select x).ToList();
            //}

            //int w;
            //if (dataGridView1.RowCount > 10)
            //{
            //    w = 6;
            //}
            //else {
            //    w = 1;
            //}

            //Global.CalcularAnchoGrilla(w, dataGridView1);               
        }
        private void FrmBusquedaMarca_Load(object sender, EventArgs e)
        {
           // Global.CalcularAnchoGrilla(1, dataGridView1);
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                marca = (Marca)bsBase.Current;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("NO EXITEN DATOS", "MENSAJE");
            }

            base.Aceptar();
        }

        private void FrmBusquedaMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnCanceñar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

    }
}
