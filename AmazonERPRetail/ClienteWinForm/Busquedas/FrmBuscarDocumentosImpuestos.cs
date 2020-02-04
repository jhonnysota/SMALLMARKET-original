using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

//using Entidades.Asistencia;
using Entidades.Generales;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class FrmBuscarDocumentosImpuestos : FrmBusquedaBase
    {
        public FrmBuscarDocumentosImpuestos()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvBuscarImpuestos);
        }

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        public ImpuestosE oImpuesto = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = AgenteGenerales.Proxy.ListarImpuestos();
                dgvBuscarImpuestos.AutoResizeColumns();
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
                oImpuesto = (ImpuestosE)bsBase.Current;
            }

            base.Aceptar();
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region Eventos

        private void FrmBuscarDocumentosImpuestos_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvBuscarImpuestos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvBuscarImpuestos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvBuscarImpuestos, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        } 

        #endregion
    }
}
