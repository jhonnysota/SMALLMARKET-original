using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarConceptosGasto : FrmBusquedaBase
    {

        public frmBuscarConceptosGasto()
        {
            InitializeComponent();
            FormatoGrid(dgvConceptos);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<ConceptoGastoE> oListadoConceptos = null;
        public ConceptoGastoE oConcepto = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oListadoConceptos = AgenteContabilidad.Proxy.ListarConceptoGasto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsBase.DataSource = oListadoConceptos;
                dgvConceptos.AutoResizeColumns();

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
                    oConcepto = (ConceptoGastoE)bsBase.Current;
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

        private void frmBuscarConceptosGasto_Load(object sender, EventArgs e)
        {

        }

        private void dgvConceptos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvConceptos, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvConceptos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    List<ConceptoGastoE> res = (from x in oListadoConceptos
                                                where x.desConcepto.Contains(txtFiltro.Text.ToUpper()) || x.desConcepto.Contains(txtFiltro.Text.ToUpper())
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
