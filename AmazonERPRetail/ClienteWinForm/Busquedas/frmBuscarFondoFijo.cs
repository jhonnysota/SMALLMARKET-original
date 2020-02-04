using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarFondoFijo : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarFondoFijo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvFondos, true);
        }

        public frmBuscarFondoFijo(List<FondoFijoE> oListaFondos_)
            :this()
        {
            oListaFondos = oListaFondos_;
        } 

        #endregion

        #region Variables

        List<FondoFijoE> oListaFondos = null;
        public FondoFijoE oFondo = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                if (oListaFondos.Count > 0 && oListaFondos != null)
                {
                    bsBase.DataSource = oListaFondos;
                    bsBase.ResetBindings(false);

                    dgvFondos.GrupoColumnas = new String[] { "desTipoFondo" };
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            try
            {
                oFondo = (FondoFijoE)bsBase.Current;

                if (oFondo != null)
                {
                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarFondoFijo_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvFondos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvFondos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvFondos, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        } 

        #endregion

    }
}
