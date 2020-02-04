using Entidades.Almacen;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
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
    public partial class frmBuscarDireccion : FrmBusquedaBase
    {
        public frmBuscarDireccion()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCostosClasificacion);
        }

        #region Variables
        AlmacenServiceAgent AgenteAlmace { get { return new AlmacenServiceAgent(); } }
        public AlmacenE oDir = null;
        public List<AlmacenE> oListaDirec = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oListaDirec = AgenteAlmace.Proxy.ListarAlmacenPorDireccion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsBase.DataSource = oListaDirec;
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
                    oDir = (AlmacenE)bsBase.Current;
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

        private void dgvCostosClasificacion_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvCostosClasificacion, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }
    }
}
