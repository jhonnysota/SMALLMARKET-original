using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Properties;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarSolicitudAnticipos : FrmBusquedaBase
    {

        public frmBuscarSolicitudAnticipos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvSolicitudes, true);
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        public SolicitudProveedorE  oSolicitudAnticipo = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = AgenteTesoreria.Proxy.SolicitudProveedorPendientes(VariablesLocales.SesionLocal.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, txtFiltro.Text.Trim());
                dgvSolicitudes.AutoResizeColumns();
                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                oSolicitudAnticipo = (SolicitudProveedorE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("No hay datos, presione el botón Cancelar.");
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarSolicitudAnticipos_Load(object sender, EventArgs e)
        {

        }

        private void dgvSolicitudes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvSolicitudes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvSolicitudes, e, Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        } 

        #endregion

    }
}
