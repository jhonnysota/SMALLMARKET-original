using Entidades.Generales;
using Infraestructura;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarDetracciones : FrmBusquedaBase
    {
        public frmBuscarDetracciones()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dataGridView1);
        }


        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public TasasDetraccionesE eDetra = null;

        #endregion

        #region Procedimientos de Usuario

        void pListarMonedas()
        {
            bsBase.DataSource = AgenteGeneral.Proxy.ListarTasasDetracciones();
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                eDetra = (TasasDetraccionesE)bsBase.Current;
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
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }


        #endregion

        private void frmBuscarDetracciones_Load(object sender, EventArgs e)
        {
            pListarMonedas();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }
    }
}
