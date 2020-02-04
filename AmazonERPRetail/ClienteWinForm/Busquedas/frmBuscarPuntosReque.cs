using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarPuntosReque : FrmBusquedaBase
    {

        public frmBuscarPuntosReque()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvPuntos);
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public RequerimientoPuntosE oRequerimiento = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = AgenteAlmacen.Proxy.ListarRequerimientoPuntos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (bsBase.Count > 0)
                {
                    dgvPuntos.Enabled = true;
                    btnAceptar.Enabled = true;
                }
                else
                {
                    dgvPuntos.Enabled = false;
                    btnAceptar.Enabled = false;
                }

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
                oRequerimiento = (RequerimientoPuntosE)bsBase.Current;

                if (oRequerimiento != null)
                {
                    base.Aceptar();
                }
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarPuntosReque_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvPuntos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvPuntos, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvPuntos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        } 

        #endregion

    }
}
