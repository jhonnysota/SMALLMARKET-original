using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
using Infraestructura.Winform;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarOrdenCompra : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarOrdenCompra()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvListado);
        }

        public frmBuscarOrdenCompra(string Tipo_)
            :this()
        {
            TipoBusqueda = Tipo_;
        } 

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public OrdenCompraE oOC;
        string TipoBusqueda = "N";

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            DateTime fecIni = dtpDesde.Value.Date;
            DateTime fecFin = dtpHasta.Value.Date;
            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            int idLocal = VariablesLocales.SesionLocal.IdLocal;
            string Filtro = txtFiltro.Text;

            List<OrdenCompraE> oListaOrdenCompra = AgenteAlmacen.Proxy.ListarOCPendientes(idEmpresa, idLocal, fecIni, fecFin, Filtro.Trim(), TipoBusqueda);
            bsBase.DataSource = oListaOrdenCompra;
            bsBase.ResetBindings(false);

            base.Buscar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                oOC = (OrdenCompraE)bsBase.Current;
                base.Aceptar();
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarOrdenCompra_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvListado, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        #endregion

    }
}
