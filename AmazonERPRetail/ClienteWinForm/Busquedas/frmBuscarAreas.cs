using System;
using System.Text;
using System.Windows.Forms;

using Entidades.Maestros;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarAreas : FrmBusquedaBase
    {
        public frmBuscarAreas()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvAreas);
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public Area Areas = null;

        #endregion

        #region Procedimientos de Usuario
        
        //void pFormatoGrid()
        //{
        //    //Inicializar propiedades básicas DataGridView.
        //    dgvAreas.BackgroundColor = Color.LightSteelBlue;
        //    dgvAreas.BorderStyle = BorderStyle.None;

        //    //Establecer el estilo de las filas y columnas del encabezado
        //    //dgvActivo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dgvAreas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    dgvAreas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    dgvAreas.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

        //    //Valores de propiedad, conjunto adecuado para la visualización.
        //    dgvAreas.AllowUserToAddRows = false;
        //    dgvAreas.AllowUserToDeleteRows = false;
        //    dgvAreas.AllowUserToOrderColumns = false;
        //    dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvAreas.MultiSelect = false;

        //    dgvAreas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    dgvAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //    // establecer ajuste de altura automático para las filas
        //    dgvAreas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    // establecer ajuste de anchura automático para las columnas
        //    dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    ////Para que la primera columan no aparesca
        //    ////dgvdetalle.RowHeadersVisible = false;
        //    dgvAreas.RowHeadersWidth = 20;

        //    //Establecer el color para todas las filas y las filas alternas
        //    //El valor para las filas alternas anula el valor de todas las filas
        //    dgvAreas.RowsDefaultCellStyle.BackColor = Color.White;
        //    dgvAreas.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

        //    //// Attach a handler to the CellFormatting event.
        //    dgvAreas.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvAreas_CellFormatting);
        //}

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            StringBuilder cadBusqueda = new StringBuilder();
            string cad = string.Empty;
            
            cadBusqueda.Append(txtFiltro.Text);
            cadBusqueda.Append("%");
            cad = cadBusqueda.ToString();

            bsBase.DataSource = AgenteMaestros.Proxy.BuscarAreaDescripcion(VariablesLocales.SesionLocal.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, cad);
            
            base.Buscar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                Areas = (Area)bsBase.Current;
            }

            base.Aceptar();
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region Eventos

        private void frmBuscarAreas_Load(object sender, EventArgs e)
        {

        }

        private void dgvAreas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAreas.Columns[0].DefaultCellStyle.Format = "000";
        }

        private void dgvAreas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void dgvAreas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvAreas, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        } 

        #endregion

    }
}
