using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Entidades.Almacen;
using Infraestructura;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarConversiones : FrmBusquedaBase
    {

        public frmBuscarConversiones()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvOC);
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        //List<OrdenConversionE> oListadoHojaCosto = null;
        public OrdenConversionE oOrdenConversion = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                //oListadoHojaCosto = AgenteAlmacen.Proxy.ListarOrdenConversionProvision(VariablesLocales.SesionLocal.IdEmpresa, dtpFecIni.Value.Date, dtpFecFin.Value.Date);
                bsBase.DataSource = AgenteAlmacen.Proxy.ListarOrdenConversionProvision(VariablesLocales.SesionLocal.IdEmpresa, dtpFecIni.Value.Date, dtpFecFin.Value.Date);
                dgvOC.AutoResizeColumns();

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
                    oOrdenConversion = (OrdenConversionE)bsBase.Current;
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

        private void frmBuscarConversiones_Load(object sender, EventArgs e)
        {
            Buscar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void dgvOC_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if ((e.RowIndex == -1))
                {
                    EstiloCabeceras(dgvOC, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvOC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        } 

        #endregion

    }
}
