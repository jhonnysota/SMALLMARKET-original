using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.CtasPorPagar
{
    public partial class frmBuscarNIngresoPorRecep : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarNIngresoPorRecep()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmBuscarNIngresoPorRecep(Plantilla_ConceptoE oPlantilla_)
            :this()
        {
            oPlantilla = oPlantilla_;
        }

        #endregion

        #region Variables

        public AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public MovimientoAlmacenE oIngreso = null;
        Plantilla_ConceptoE oPlantilla = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvIngresosPorRecep.RowHeadersVisible = false;
            dgvIngresosPorRecep.Columns[0].Width = 40;  //Numero de Nota de Ingreso
            dgvIngresosPorRecep.Columns[1].Width = 80; //Fecha de Ingreso
            dgvIngresosPorRecep.Columns[2].Width = 80; //Ruc
            dgvIngresosPorRecep.Columns[3].Width = 150; //Razon Social
            dgvIngresosPorRecep.Columns[4].Width = 80;  //Tipo de documento
            dgvIngresosPorRecep.Columns[5].Width = 30;  //Tipo de documento
            dgvIngresosPorRecep.Columns[6].Width = 40;  //Serie
            dgvIngresosPorRecep.Columns[7].Width = 70;  //Numero de Factura
            dgvIngresosPorRecep.Columns[8].Width = 40;  //Moneda
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                String Filtro = txtFiltro.Text;

                bsBase.DataSource = AgenteAlmacen.Proxy.ListarIngresosCompraPendiente(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,oPlantilla.CodMoneda);
                dgvIngresosPorRecep.AutoResizeColumns();
                AnchoColumnas();

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
                oIngreso = (MovimientoAlmacenE)bsBase.Current;
            }

            base.Aceptar();
        }

        #endregion

        #region Eventos

        private void frmBuscarNIngresoPorRecep_Load(object sender, EventArgs e)
        {
            dgvIngresosPorRecep.AutoResizeColumns();
            AnchoColumnas();
        }

        private void dgvIngresosPorRecep_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvIngresosPorRecep, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvIngresosPorRecep_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        #endregion

    }
}
