using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Ventas;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarTipoCondicionTraslado : FrmBusquedaBase
    {
        public frmBuscarTipoCondicionTraslado()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvCondiciones);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public TipoTrasladoE oTraslado = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = AgenteVentas.Proxy.ListarTipoTraslado();
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
                oTraslado = (TipoTrasladoE)bsBase.Current;
            }

            base.Aceptar();
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region Eventos

        private void frmBuscarTipoCondicionTraslado_Load(object sender, EventArgs e)
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
            dgvCondiciones.Columns[0].DefaultCellStyle.Format = "00";
        }

        #endregion

        

    }
}
