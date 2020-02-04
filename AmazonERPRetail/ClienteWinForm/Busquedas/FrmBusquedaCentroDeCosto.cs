using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class FrmBusquedaCentroDeCosto : FrmBusquedaBase
    {

        #region Constructores

        public FrmBusquedaCentroDeCosto()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            FormatoGrid(dgvCentroDeCosto);
        }

        public FrmBusquedaCentroDeCosto(Int32 Nivel)
            : this()
        {
            nudNivel.Value = Nivel;
        } 

        #endregion

        #region Variables

        public CCostosE CentroCosto = null;
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        //void pFormatoGrid(DataGridView oDgv)
        //{
        //    //Prueba
        //    //dgvCuentas.ColumnHeadersDefaultCellStyle
        //    oDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        //    oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        //    oDgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.GhostWhite;
        //    oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);

        //    //Inicializar propiedades básicas DataGridView.
        //    oDgv.BackgroundColor = Color.LightSteelBlue;
        //    oDgv.BorderStyle = BorderStyle.None;

        //    //Establecer el estilo de las filas y columnas del encabezado
        //    //dgvActivo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    //dgvCuentas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    //dgvCuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    oDgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

        //    ////Valores de propiedad, conjunto adecuado para la visualización.
        //    oDgv.AllowUserToAddRows = false;
        //    oDgv.AllowUserToDeleteRows = false;
        //    oDgv.AllowUserToOrderColumns = false;
        //    oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    oDgv.MultiSelect = false;

        //    oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

        //    //dgvCuentas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    //dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //    //// establecer ajuste de altura automático para las filas
        //    //dgvCuentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    //// establecer ajuste de anchura automático para las columnas
        //    //dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    ////Para que la primera columan no aparesca
        //    oDgv.RowHeadersVisible = false;

        //    //Estableciendo el el alto de los titulos
        //    oDgv.ColumnHeadersHeight = 30;

        //    //Formato para las filas
        //    DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
        //    lineas.Height = 25;
        //    lineas.MinimumHeight = 10;
        //    oDgv.Refresh();
        //}

        //private void ListarCentroCosto()
        //{

            //List<MAE_C_COSTOS> vListaCentroCosto = AgenteContabilidad.Proxy.ListarMAE_C_COSTOS_PorEmpresa(VariablesLocales.SesionLocal.IdEmpresa);

            //if (vListaCONVOUCHEITEMCOSTO != null)
            //{
            //    foreach (MAE_C_COSTOS item in vListaCentroCosto)
            //    {
            //        if ((from x in vListaCONVOUCHEITEMCOSTO where x.COD_C_COSTOS == item.COD_C_COSTOS && x.NUM_VER_C_COSTOS == item.NUM_VER_C_COSTOS select x).Count() > 0) {

                        
            //            item.MarcarCentroCosto = true;

            //            if (tipoMoneda == (int)EnumValorCadenaTipoMoneda.SOLES)
            //            {
            //                item.ValorCentroCosto = (from x in vListaCONVOUCHEITEMCOSTO where x.COD_C_COSTOS == item.COD_C_COSTOS && x.NUM_VER_C_COSTOS == item.NUM_VER_C_COSTOS select x).FirstOrDefault().IMP_SOLES;
            //            }
            //            else if (tipoMoneda == (int)EnumValorCadenaTipoMoneda.DOLARES)
            //            {
            //                item.ValorCentroCosto = (from x in vListaCONVOUCHEITEMCOSTO where x.COD_C_COSTOS == item.COD_C_COSTOS && x.NUM_VER_C_COSTOS == item.NUM_VER_C_COSTOS select x).FirstOrDefault().IMP_DOLARES;
            //            }                       
            //        }                    
            //    }               
            //}


            //ListaMaeCentroDeCostoBindingSource.DataSource = vListaCentroCosto;
            //ListaMaeCentroDeCostoBindingSource.ResetBindings(false);
        //}

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                Int32? Nivel = Convert.ToInt32(nudNivel.Value) != Variables.Cero ? Convert.ToInt32(nudNivel.Value) : (Nullable<int>)null;
                bsBase.DataSource = AgenteMaestro.Proxy.ListarCCostosPorNivel(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Nivel);    
                dgvCentroDeCosto.AutoResizeColumns();
                base.Buscar();
            }
            catch (Exception ex)
            {
                 Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                CentroCosto = (CCostosE)bsBase.Current;
            }

            base.Aceptar();
        }

        protected override void Cancelar()
        {
            this.Close();
        }
        
        #endregion

        #region Eventos

        private void FrmBusquedaCentroDeCosto_Load(object sender, EventArgs e)
        {
            Buscar();
            dgvCentroDeCosto.AutoResizeColumns();
            //ListarCentroCosto();

            //if (Valida)
            //{
            //    dgvCentroDeCosto.Columns["MarcarCentroCosto"].Visible = false;
            //}
            //else
            //{
            //    dgvCentroDeCosto.Columns["MarcarCentroCosto"].Visible = true;
            //}
          
        }

        private void dgvCentroDeCosto_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex == dgvCentroDeCosto.Columns["ValorCentroCosto"].Index)
            //{
            //    decimal MontoTotalTemp = 0;
            //    DataGridViewRow row = dgvCentroDeCosto.Rows[e.RowIndex];

            //    if (e.FormattedValue.ToString() == "0")
            //    {

            //        dgvCentroDeCosto[e.ColumnIndex, e.RowIndex].Value = MontoTotalTemp;
            //        return;

            //    }
            //    if (!decimal.TryParse(e.FormattedValue.ToString(), out MontoTotalTemp))
            //    {

            //        dgvCentroDeCosto[e.ColumnIndex, e.RowIndex].Value = MontoTotalTemp;
            //        MessageBox.Show("DEBE INGRESAR UN NÚMERO VÁLIDO");
            //        return;

            //    }

            //    if (decimal.Parse(dgvCentroDeCosto[1, e.RowIndex].Value.ToString()) < 0)
            //    {
            //        MessageBox.Show("VALOR DEBE SER MAYOR A 0");
            //        return;

            //    }
            //} //Fin Columna 1
        }

        private void dgvCentroDeCosto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dgvCentroDeCosto.Columns["ValorCentroCosto"].Index)
            //{

            //    decimal MontoTotalTemp = 0;
            //   if (decimal.Parse(dgvCentroDeCosto[e.ColumnIndex, e.RowIndex].Value.ToString()) < 0)
            //    {
            //        dgvCentroDeCosto[e.ColumnIndex, e.RowIndex].Value = MontoTotalTemp;
            //        MessageBox.Show("VALOR DEBE SER MAYOR A 0");
            //        return;

            //    }


            //}
        }

        private void dgvCentroDeCosto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void dgvCentroDeCosto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvCentroDeCosto, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        #endregion

    }
}
