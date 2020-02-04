using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarOrdenCompraItem : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarOrdenCompraItem()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvOrden);
        }

        public frmBuscarOrdenCompraItem(Int32 idOrdenCompra_)
            :this()
        {
            //oHojaCosto = oReg_;
            idOrdenCompra = idOrdenCompra_;
        } 

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        //HojaCostoE oHojaCosto = new HojaCostoE();
        Int32 idOrdenCompra = 0;
        public List<OrdenCompraItemE> oOCItem = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oOCItem = AgenteAlmacen.Proxy.ListarOrdenCompraItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(idOrdenCompra));
                base.Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarOrdenCompraItem_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvOrden_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        #endregion

    }
}
