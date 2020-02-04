using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCuentasCte : FrmBusquedaBase
    {

        public frmBuscarCuentasCte()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvCuentas);
            Nivel();
        }

        #region Variables

        public ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public PlanCuentasE Cuentas = null;

        #endregion

        #region Procedimientos de Usuario

        void Nivel()
        {
            try
            {
                nudNivel.Value = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
                nudNivel.Minimum = 1;
                nudNivel.Maximum = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                Int32 Opcion = 3; // Opcion = 3 solo filtra las cuentas indicadas como cuentas corriente
                String Cuenta = txtFiltro.Text;

                if (String.IsNullOrEmpty(Cuenta.Trim()))
                {
                    Global.MensajeFault("Debe ingresar el indicio de la cuenta (10, 101, 1011...)");
                    return;
                }

                bsBase.DataSource = AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtFiltro.Text, Convert.ToInt32(nudNivel.Value), Opcion);
                dgvCuentas.AutoResizeColumns();
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

        private void frmBuscarCuentas_Load(object sender, EventArgs e)
        {
            dgvCuentas.AutoResizeColumns();
            txtFiltro.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
        }

        private void dgvCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvCuentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                EstiloCabeceras(dgvCuentas, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleCentered)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleLeft)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleRight)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.Tile)
            }
        }

        #endregion

    }
}
