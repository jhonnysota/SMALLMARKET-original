using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCorreos : FrmBusquedaBase
    {

        public frmBuscarCorreos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCorreos);
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral = new GeneralesServiceAgent();
        List<ContactosCorreosE> oListaCorreos = new List<ContactosCorreosE>();
        public ContactosCorreosE oCorreo = new ContactosCorreosE();

        #endregion

        #region Procedimientos de Usuario

        void BuscarFiltro()
        {
            bsBase.DataSource = (from x in oListaCorreos
                                 where x.Nombres.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                 select x).ToList();

            base.Buscar();
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            bsBase.DataSource = oListaCorreos = AgenteGeneral.Proxy.ListarCorreosBusqueda();
            dgvCorreos.AutoResizeColumns();

            base.Buscar();

            if (!String.IsNullOrEmpty(txtFiltro.Text) && oListaCorreos.Count > 0)
            {
                BuscarFiltro();
            }
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    oCorreo = (ContactosCorreosE)bsBase.Current;
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

        private void frmBuscarCorreos_Load(object sender, EventArgs e)
        {

        }

        private void dgvCorreos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void dgvCorreos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvCorreos, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvCorreos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Aceptar();
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (oListaCorreos != null && oListaCorreos.Count > 0)
                {
                    BuscarFiltro();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
