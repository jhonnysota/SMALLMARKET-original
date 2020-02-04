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
    public partial class FrmBusquedaDatos : FrmBusquedaBase
    {
        public ParTabla oDatos = null;
        public int idGrupo;
        //String Modo = "";
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        public FrmBusquedaDatos()
        {
            InitializeComponent();
        }
        // ============
        // CONSTRUCTOR
        // ============
        public FrmBusquedaDatos(int idCat)
            :this()
        {
            idGrupo = idCat;
        }
        // ============
        // BUSCAR
        // ============
        protected override void Buscar()
        {
            String filtro               =   txtFiltro.Text;
            bsBase.DataSource           =   AgenteGeneral.Proxy.ListarParTablaPorGrupo(idGrupo, filtro);
            bsBase.ResetBindings(false);
        }

        private void FrmBusquedaMarca_Load(object sender, EventArgs e)
        {
            // Global.CalcularAnchoGrilla(1, dataGridView1);
            FormatoGrid(dataGridView1, true);

            Buscar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                oDatos = (ParTabla)bsBase.Current;
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
