using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Properties;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarAlmacenes : FrmBusquedaBase
    {

        public frmBuscarAlmacenes()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvAlmacenes, true);
        }

        #region Variables

        AlmacenServiceAgent AgenteMaestros { get { return new AlmacenServiceAgent(); } }
        public AlmacenE oAlmacen = null;
        List<AlmacenE> oListaAlmacen = null;

        #endregion

        #region Procedimientos de Usuario

        void BuscarFiltro()
        {
            if (oListaAlmacen != null && oListaAlmacen.Count > 0)
            {
                bsBase.DataSource = (from x in oListaAlmacen
                                     where x.desAlmacen.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                     select x).ToList();
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = oListaAlmacen = AgenteMaestros.Proxy.ListarAlmacen(VariablesLocales.SesionLocal.IdEmpresa, String.Empty, 0, false, false);
                dgvAlmacenes.AutoResizeColumns();
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
                oAlmacen = (AlmacenE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("No hay datos, presione el botón Cancelar.");
            }
        }

        #endregion

        #region Eventos
        
        private void frmBuscarAlmacenes_Load(object sender, EventArgs e)
        {

        }

        private void dgvAlmacenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvAlmacenes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvAlmacenes, e, Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        } 

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            BuscarFiltro();
        }

        #endregion

    }
}
