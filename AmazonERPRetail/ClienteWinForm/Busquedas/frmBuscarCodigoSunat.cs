using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCodigoSunat : FrmBusquedaBase
    {

        public frmBuscarCodigoSunat()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dataGridView1);
        }

        #region Variables
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        public ParTabla oOperacionSunat = null;
        public List<ParTabla> oPArtablalistasunat= null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oPArtablalistasunat = AgenteGenerales.Proxy.ListarParTablaPorNemo("TIPOPES");
                bsBase.DataSource = oPArtablalistasunat;
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
                    oOperacionSunat = (ParTabla)bsBase.Current;
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

        #region Eventos

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dataGridView1, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        #endregion

    }
}
