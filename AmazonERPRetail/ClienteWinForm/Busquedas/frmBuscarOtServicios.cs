using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarOtServicios : FrmBusquedaBase
    {

        public frmBuscarOtServicios()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvServicios);
        }

        public frmBuscarOtServicios(Int32 Persona)
                 : this()
        {
            Personatmp = Persona;
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public OrdenTrabajoServicioE oTrabajoServicio = null;
        Int32 Personatmp = 0;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = AgenteVentas.Proxy.ListarOTServicioPendientes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Personatmp);

                if (bsBase.Count > 0)
                {
                    dgvServicios.Enabled = true;
                    btnAceptar.Enabled = true;
                }
                else
                {
                    dgvServicios.Enabled = false;
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
                oTrabajoServicio = (OrdenTrabajoServicioE)bsBase.Current;

                if (oTrabajoServicio != null)
                {
                    base.Aceptar();
                }
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarOtServicios_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvServicios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvServicios, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        } 

        #endregion

    }
}
