using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarConceptosTesoreria : FrmBusquedaBase
    {

        public frmBuscarConceptosTesoreria(Int32 Tipo)
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvConceptos);
            TipoConcepto = Tipo;
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public ConceptosVariosE oConcepto = null;
        int TipoConcepto = 0;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                String Descripcion = txtDes.Text.Trim();
                bsBase.DataSource = AgenteAlmacen.Proxy.ConceptosVariosTesoreria(TipoConcepto, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Descripcion);
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
                    oConcepto = (ConceptosVariosE)bsBase.Current;
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

        private void frmBuscarConceptosTesoreria_Load(object sender, EventArgs e)
        {

        }

        private void dgvConceptos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvConceptos, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvConceptos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void txtDes_Validating(object sender, CancelEventArgs e)
        {
            Buscar();
        } 

        #endregion

    }
}
