using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarTrabajador : FrmBusquedaBase
    {
        public frmBuscarTrabajador()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvTrabajador);
        }


        #region Variables

        MaestrosServiceAgent AgenteMaestro = new MaestrosServiceAgent();
        List<TrabajadorE> listaTrabajador = new List<TrabajadorE>();
        public TrabajadorE oTrabajador = new TrabajadorE();

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                //bsBase.DataSource = listaTrabajador = AgenteMaestro.Proxy.ListarTrabajador(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtNroDocumento.Text.Trim(), txtRazonSocial.Text.Trim());
                //dgvTrabajador.AutoResizeColumns();
                //base.Buscar();
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
                oTrabajador = (TrabajadorE)bsBase.Current;
            }

            base.Aceptar();
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region Eventos

        private void frmBuscarTrabajador_Load(object sender, EventArgs e)
        {

        }

        private void dgvTrabajador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void dgvTrabajador_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvTrabajador, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        #endregion

    }
}
