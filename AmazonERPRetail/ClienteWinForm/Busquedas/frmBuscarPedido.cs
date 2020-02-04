using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarPedido : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarPedido()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvPedidos);
        }

        public frmBuscarPedido(Int32 idCliente_)
            :this()
        {
            idCliente = idCliente_;
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteProduccion { get { return new VentasServiceAgent(); } }
        Int32 idCliente = 0;
        public PedidoCabE oPedido = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                List<PedidoCabE> ListaPedidos = AgenteProduccion.Proxy.ListarPedidosPorCliente(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idCliente);
                bsBase.DataSource = ListaPedidos;
                bsBase.ResetBindings(false);

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
                    if (bsBase.Current != null)
                    {
                        oPedido = (PedidoCabE)bsBase.Current;
                        base.Aceptar(); 
                    }
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

        private void frmBuscarPedido_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvPedidos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvPedidos, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        #endregion

    }
}
