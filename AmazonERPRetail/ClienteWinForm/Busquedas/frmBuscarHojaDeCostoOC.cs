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
    public partial class frmBuscarHojaDeCostoOC : FrmBusquedaBase
    {

        public frmBuscarHojaDeCostoOC()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvOC);
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<HojaCostoE> oListadoHojaCosto = null;
        public HojaCostoE oHojaCosto = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oListadoHojaCosto = AgenteAlmacen.Proxy.ListarHojaCosto(VariablesLocales.SesionLocal.IdEmpresa, dtpFecIni.Value.Date, dtpFecFin.Value.Date);
                bsBase.DataSource = oListadoHojaCosto;
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
                    oHojaCosto = (HojaCostoE)bsBase.Current;
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

        private void dgvOC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void frmBuscarHojaDeCostoOC_Load(object sender, EventArgs e)
        {
            Buscar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void dgvOC_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvOC, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        } 

        #endregion

    }
}
