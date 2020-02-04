using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarConceptosVarios : FrmBusquedaBase
    {

        public frmBuscarConceptosVarios(Int32 Tipo, Int32 EsAnticipo_ = 0)
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvConceptos);
            TipoConcepto = Tipo;
            EsAnticipo = EsAnticipo_;
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public ConceptosVariosE oConcepto = null;
        int TipoConcepto = 0;
        Int32 EsAnticipo = 0;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                String Descripcion = txtDes.Text;

                if (VariablesLocales.EsLiquidacion == Variables.NO)
                {
                    //List<ConceptosVariosE> oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosBusqueda(TipoConcepto, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Descripcion, false, idSistema);
                    List<ConceptosVariosE> oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosCompras(TipoConcepto, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Descripcion, false);

                    if (EsAnticipo == 1)
                    {
                        oListaConceptos = (from x in oListaConceptos where x.indAnticipo == true select x).ToList();
                    }
                    else
                    {
                        oListaConceptos = (from x in oListaConceptos where x.indAnticipo != true select x).ToList();
                    }

                    bsBase.DataSource = oListaConceptos;
                }
                else
                {
                    //bsBase.DataSource = AgenteAlmacen.Proxy.ConceptosVariosBusqueda(TipoConcepto, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Descripcion, true, idSistema);
                    bsBase.DataSource = AgenteAlmacen.Proxy.ConceptosVariosCompras(TipoConcepto, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Descripcion, true);
                }
                
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

        private void frmBuscarConceptosVarios_Load(object sender, EventArgs e)
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

        private void txtDes_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Buscar();
        }

        #endregion

    }
}
