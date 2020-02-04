using Entidades.Generales;
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
    public partial class frmBuscarPaises : FrmBusquedaBase
    {

        public frmBuscarPaises()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvPais);
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public PaisesE ePais = null;
        List<PaisesE> oListaPaises = null;

        #endregion

        #region Procedimientos de Usuario

        void BuscarFiltro()
        {
            bsBase.DataSource = (from x in oListaPaises
                                 where x.Nombre.ToUpper().Contains(txtPais.Text.ToUpper())
                                 select x).ToList();

            gbResultados.Text = "Registros " + bsBase.Count.ToString();
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                ePais = (PaisesE)bsBase.Current;
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
                bsBase.DataSource = oListaPaises = AgenteGeneral.Proxy.ListarPaises();
                dgvPais.AutoResizeColumns();

                if (!String.IsNullOrEmpty(txtPais.Text.Trim()))
                {
                    BuscarFiltro();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        #endregion

        #region Eventos

        private void frmBuscarPaises_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvPais_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }       
        }

        private void dgvPais_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvPais, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {
            if (oListaPaises != null && oListaPaises.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        }

        private void txtPais_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, btnBuscar);
        }

        #endregion
    
    }
}
