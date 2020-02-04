using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarSeriesVentas : FrmBusquedaBase
    {

        public frmBuscarSeriesVentas()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvSeries);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public NumControlDetE oSerie = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = AgenteVentas.Proxy.ListarNumControlDetPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);

                if (bsBase.Count > 0)
                {
                    dgvSeries.Enabled = true;
                    btnAceptar.Enabled = true;
                }
                else
                {
                    dgvSeries.Enabled = false;
                    btnAceptar.Enabled = false;
                }

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
                oSerie = (NumControlDetE)bsBase.Current;

                if (oSerie != null)
                {
                    base.Aceptar();
                }
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarSeriesVentas_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvSeries_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.Button_Gray_Stripe_01_050, DGVHeaderImageAlignments.Stretch)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.Button_Gray_Stripe_01_050, DGVHeaderImageAlignments.FillCell)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.AquaBall_Blue, DGVHeaderImageAlignments.SingleCentered)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.AquaBall_Blue, DGVHeaderImageAlignments.SingleLeft)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.AquaBall_Blue, DGVHeaderImageAlignments.SingleRight)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.AquaBall_Blue, DGVHeaderImageAlignments.Tile)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.Button_Gray_Stripe_01_050, DGVHeaderImageAlignments.Stretch)
                EstiloCabeceras(dgvSeries, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleCentered);
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleCentered)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleLeft)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleRight)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.Tile)
            }
        }

        private void dgvSeries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        } 

        #endregion

    }
}
