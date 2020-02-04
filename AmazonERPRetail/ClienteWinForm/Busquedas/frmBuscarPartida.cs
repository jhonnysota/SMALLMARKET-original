using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarPartida : FrmBusquedaBase
    {
        public frmBuscarPartida()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvpartida);
            NivelPartida();
        }

        #region Variables

        public MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public PartidaPresupuestariaE oPartidaPresupuestal = null;

        #endregion

        #region Procedimientos de Usuario

        void NivelPartida()
        {
            try
            {
                Int32 Nivel = AgenteMaestro.Proxy.ObtenerNivelPartida(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (Nivel > Variables.Cero)
                {
                    nudNivel.Value = Nivel;
                    nudNivel.Minimum = 1;
                    nudNivel.Maximum = Nivel; 
                }
                else
                {
                    Global.MensajeFault("No se han definido Partidas Presupuestales.");
                    nudNivel.Minimum = 1;
                    nudNivel.Maximum = 1; 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                String Tipo = String.Empty;
                String Descripcion = txtFiltro.Text;

                if (rbRe.Checked)
                {
                    Tipo = "RE";
                }

                if (rbGa.Checked)
                {
                    Tipo = "GA";
                }

                bsBase.DataSource = AgenteMaestro.Proxy.ListarPartidaPresupuestariaPorTipo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Tipo, Descripcion, Convert.ToInt32(nudNivel.Value));
                dgvpartida.AutoResizeColumns();
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
                oPartidaPresupuestal = (PartidaPresupuestariaE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("No hay datos, presione Cancelar...");
            }            
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region Eventos

        private void frmBuscarPartida_Load(object sender, EventArgs e)
        {
            dgvpartida.AutoResizeColumns();
        }

        private void dgvpartida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void dgvpartida_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvpartida, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        #endregion
    }
}
