using Entidades.Maestros;
using Infraestructura;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCostosClasificacion : FrmBusquedaBase
    {
        public frmBuscarCostosClasificacion()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCostosClasificacion);
        }

        #region Variables
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public CostosClasificacionE oCostosClasificacion = null;
        public List<CostosClasificacionE> oListaCostosClasificacion = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oListaCostosClasificacion = AgenteMaestros.Proxy.ListarClasificacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsBase.DataSource = oListaCostosClasificacion;
                dgvCostosClasificacion.AutoResizeColumns();

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    oCostosClasificacion = (CostosClasificacionE)bsBase.Current;
                    base.Aceptar();
                }
                else
                {
                    Global.MensajeComunicacion("No hay datos. Presione Cancelar");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        private void dgvCostosClasificacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void frmBuscarCostosClasificacion_Load(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
