using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarOperadorLogistico : FrmBusquedaBase
    {
        public frmBuscarOperadorLogistico()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvOperador);
        }

        #region Variables

        public MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public OpeLogisticoE oLogistico = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                String RazonSocial = txtFiltro.Text;

                bsBase.DataSource = AgenteMaestros.Proxy.ListarOpeLogPorParametro(VariablesLocales.SesionLocal.IdEmpresa, RazonSocial, String.Empty, true, false);
                dgvOperador.AutoResizeColumns();

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                oLogistico = (OpeLogisticoE)bsBase.Current;
            }

            base.Aceptar();
        }

        #endregion

        #region Eventos

        private void frmBuscarOperadorLogistico_Load(object sender, EventArgs e)
        {
            //dgvOperador.AutoResizeColumns();
        }

        private void dgvOperador_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvOperador, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvOperador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        #endregion

    }
}
