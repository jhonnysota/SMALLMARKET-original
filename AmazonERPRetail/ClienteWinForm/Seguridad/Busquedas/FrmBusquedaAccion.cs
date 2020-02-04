using System;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;

namespace ClienteWinForm.Seguridad.Busquedas
{
    public partial class FrmBusquedaAccion : FrmBusquedaBase
    {

        public FrmBusquedaAccion()
        {
            InitializeComponent();
        }

        #region variables

        public AccionE accion = null;

        #endregion

        #region Procedimientos de Usuario

        void pFormatoGrid()
        {
            //Inicializar propiedades básicas DataGridView.
            dgvAccion.BackgroundColor = Color.LightSteelBlue;
            dgvAccion.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            //dgvActivo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAccion.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvAccion.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvAccion.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

            //Valores de propiedad, conjunto adecuado para la visualización.
            dgvAccion.AllowUserToAddRows = false;
            dgvAccion.AllowUserToDeleteRows = false;
            dgvAccion.AllowUserToOrderColumns = false;
            dgvAccion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccion.MultiSelect = false;

            dgvAccion.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dgvAccion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            ////Para que la primera columan no aparesca
            dgvAccion.RowHeadersWidth = 20;

            //Establecer el color para todas las filas y las filas alternas
            //El valor para las filas alternas anula el valor de todas las filas
            dgvAccion.RowsDefaultCellStyle.BackColor = Color.White;
            dgvAccion.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;
            dgvAccion.AutoResizeColumns();
            //// Attach a handler to the CellFormatting event.
            dgvAccion.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvAccion_CellFormatting);
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            bsBase.DataSource = new SeguridadServiceAgent().Proxy.ListarAccion(txtFiltro.Text);
            dgvAccion.AutoResizeColumns();
            base.Buscar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                accion = (AccionE)bsBase.Current;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("NO EXITEN DATOS", "MENSAJE");
            }
            base.Aceptar();
        }

        #endregion

        #region Eventos

        private void FrmBusquedaAccion_Load(object sender, EventArgs e)
        {
            pFormatoGrid();
        }

        private void accionDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void dgvAccion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAccion.Columns[0].DefaultCellStyle.Format = "000";
        }

        #endregion

    }
}
