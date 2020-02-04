using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCampanas : FrmBusquedaBase
    {
        public frmBuscarCampanas()
        {
            InitializeComponent();
            FormatoGrid(dgvCampanas);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<CampanaE> oListadoCampanas = null;
        public CampanaE oCampana = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oListadoCampanas = AgenteVentas.Proxy.ListarCampana(VariablesLocales.SesionLocal.IdEmpresa);
                bsBase.DataSource = oListadoCampanas;
                dgvCampanas.AutoResizeColumns();

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
                    oCampana = (CampanaE)bsBase.Current;
                    base.Aceptar();
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
        
        private void frmBuscarCampanas_Load(object sender, EventArgs e)
        {

        }

        private void dgvCampanas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvCampanas, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvCampanas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        } 

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (bsBase.Count > Variables.Cero)
                {
                    List<CampanaE> res = (from x in oListadoCampanas
                                          where x.Nombre.Contains(txtFiltro.Text.ToUpper()) || x.Nombre.Contains(txtFiltro.Text.ToUpper())
                                          select x).ToList();

                    bsBase.DataSource = res;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
