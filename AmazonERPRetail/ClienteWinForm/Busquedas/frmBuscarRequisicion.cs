using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
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
    public partial class frmBuscarRequisicion : FrmBusquedaBase
    {
        public frmBuscarRequisicion()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvRequisiscion);
        }


        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<RequisicionE> oListaRequisiciones;
        public RequisicionE oReq;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            DateTime fecIni = dtpDesde.Value.Date;
            DateTime fecFin = dtpHasta.Value.Date;
            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            string Filtro = txtFiltro.Text;

            oListaRequisiciones = AgenteAlmacen.Proxy.ListarRequisicionPendientes(idEmpresa, fecIni, fecFin, Filtro);

            bsBase.DataSource = oListaRequisiciones;
            bsBase.ResetBindings(false);

            base.Buscar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                oReq = (RequisicionE)bsBase.Current;
                base.Aceptar();
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarRequisicion_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void dgvRequisiscion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvRequisiscion_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvRequisiscion, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }


        #endregion

    }
}
