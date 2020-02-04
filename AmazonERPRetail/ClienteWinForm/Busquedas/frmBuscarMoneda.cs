using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Generales;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarMoneda : FrmBusquedaBase
    {
        public frmBuscarMoneda()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvMonedas);
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public MonedasE eMoneda = null;

        #endregion

        #region Procedimientos de Usuario

        void pListarMonedas()
        {
            bsBase.DataSource = AgenteGeneral.Proxy.ListarMonedas();
        }    
    
        #endregion

        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                eMoneda = (MonedasE)bsBase.Current;
            }

            base.Aceptar();
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        protected override void Buscar()
        {
            try
            {
                pListarMonedas();
                dgvMonedas.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        #endregion

        private void frmBuscarMoneda_Load(object sender, EventArgs e)
        {
            pListarMonedas();
        }

        private void dgvMonedas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != - 1)
            {
                Aceptar();    
            }       
        }

        private void dgvMonedas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvMonedas, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }
    }
}
