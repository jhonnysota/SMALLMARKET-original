using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using Entidades.Ventas;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCondicionVentas : FrmBusquedaBase
    {
        public frmBuscarCondicionVentas(EnumTipoCondicionVenta idTipo)
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCondiciones);

            idTipoCondicion = (Int32)idTipo;
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<CondicionE> oListaCondiciones = null;
        public CondicionE oCondicion = null;
        Int32 idTipoCondicion = 0;

        #endregion

        #region Procedimientos de Usuario

        void Filtrar()
        {
            try
            {
                if (oListaCondiciones != null && oListaCondiciones.Count > Variables.Cero)
                {
                    bsBase.DataSource = (from x in oListaCondiciones
                                            where x.desCondicion.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                            select x).ToList();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = oListaCondiciones = AgenteVentas.Proxy.ListarCondicionPorTipo(idTipoCondicion);
                
                if (!String.IsNullOrEmpty(txtFiltro.Text))
                {
                    Filtrar();
                }

                dgvCondiciones.AutoResizeColumns();
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
                oCondicion = (CondicionE)bsBase.Current;
            }

            base.Aceptar();
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region Eventos
        
        private void frmBuscarCondicionVentas_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvCondiciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvCondiciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvCondiciones, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvCondiciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvCondiciones.Columns[0].DefaultCellStyle.Format = "00";
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filtrar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
