using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Entidades.CtasPorPagar;
using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarMovilidad : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarMovilidad()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvMovilidad, true);
        }

        public frmBuscarMovilidad(List<Int32> oListaTempIds)
            : this()
        {
            oListaIdsMovi = oListaTempIds;
        } 

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        public MovilidadE oMovilidad = null;
        List<MovilidadE> oListaMovilidad = null;
        List<Int32> oListaIdsMovi = null;

        #endregion

        #region Procedimientos de Usuario

        void BuscarFiltro()
        {
            if (oListaMovilidad != null && oListaMovilidad.Count > 0)
            {
                bsBase.DataSource = (from x in oListaMovilidad
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
                oListaMovilidad = AgenteCtasPorPagar.Proxy.ListarMovilidadPendientes(VariablesLocales.SesionLocal.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);

                if (oListaIdsMovi != null && oListaIdsMovi.Count > 0)
                {
                    oListaMovilidad = (from p in oListaMovilidad
                                       where !(oListaIdsMovi.Contains(p.idMovilidad))
                                       select p).ToList(); 
                }

                bsBase.DataSource = oListaMovilidad;

                if (oListaMovilidad.Count > 0 && !String.IsNullOrEmpty(txtFiltro.Text.Trim()))
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
                oMovilidad = (MovilidadE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("No hay datos, presione el botón Cancelar.");
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarMovilidad_Load(object sender, EventArgs e)
        {

        }

        private void dgvMovilidad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvMovilidad_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvMovilidad, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            BuscarFiltro();
        } 

        #endregion

    }
}
