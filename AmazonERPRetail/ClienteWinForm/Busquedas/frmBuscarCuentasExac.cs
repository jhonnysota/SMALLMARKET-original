using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCuentasExac : FrmBusquedaBase
    {

        public frmBuscarCuentasExac()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvCuentasExac);
        }

        #region Variables

        public ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public PlanCuentasE Cuentas = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, "1",2, 1);
                dgvCuentasExac.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

            base.Buscar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                Cuentas = (PlanCuentasE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("Presione Cancelar...");
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarCuentasExac_Load(object sender, EventArgs e)
        {
            dgvCuentasExac.AutoResizeColumns();
            //Buscar();
        }

        private void dgvCuentasExac_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
