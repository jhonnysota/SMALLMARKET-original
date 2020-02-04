using Entidades.Contabilidad;
using Infraestructura;
using Presentadora.AgenteServicio;
using System;
using System.Windows.Forms;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarEEFFItem : FrmBusquedaBase
    {
        public frmBuscarEEFFItem()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvItem);
        }

        public frmBuscarEEFFItem(Int32 EEFF)
            :this()
        {
            EstaFinan = EEFF;
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public EEFFItemE eItem = null;
        Int32 EstaFinan = 0;
        #endregion



        #region Procedimientos de Usuario

        void pListarMonedas()
        {
            bsBase.DataSource = AgenteContabilidad.Proxy.ListarConEEFFItemParPres(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,EstaFinan);
        }

        #endregion


        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                eItem = (EEFFItemE)bsBase.Current;
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
                dgvItem.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        #endregion

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void frmBuscarEEFFItem_Load(object sender, EventArgs e)
        {
            pListarMonedas();
        }
    }
}
