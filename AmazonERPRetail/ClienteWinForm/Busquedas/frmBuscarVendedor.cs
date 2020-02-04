using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarVendedor : FrmBusquedaBase
    {

        public frmBuscarVendedor()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvVendedor);
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro = new MaestrosServiceAgent();
        List<VendedoresE> oListaVendedor = new List<VendedoresE>();
        public VendedoresE oVendedor = new VendedoresE();

        #endregion

        #region Procedimientos de Usuario

        void BuscarFiltro()
        {
            if (oListaVendedor != null && oListaVendedor.Count > 0)
            {
                bsBase.DataSource = (from x in oListaVendedor
                                     where x.RazonSocial.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                     select x).ToList();
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oListaVendedor = AgenteMaestro.Proxy.BusquedaVendedores(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsBase.DataSource = oListaVendedor;

                if (oListaVendedor.Count > 0 && !String.IsNullOrEmpty(txtFiltro.Text.Trim()))
                {
                    BuscarFiltro();
                }


                base.Buscar();
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
                oVendedor = (VendedoresE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeFault("No hay datos presione el Botón Cancelar.");
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarVendedor_Load(object sender, EventArgs e)
        {

        }

        private void dgvVendedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void dgvVendedor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvVendedor, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            BuscarFiltro();
        }

        #endregion

    }
}
