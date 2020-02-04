using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Maestros
{
    public partial class frmCCostosNumControl : FrmMantenimientoBase
    {

        public frmCCostosNumControl()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvCentroCostos, true);
            FormatoGrid(dgvCCostosSeries, true);
            LlenarTipoDocumento();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void LlenarTipoDocumento()
        {
            List<NumControlDetE> ListaDoc = new List<NumControlDetE>(from x in VariablesLocales.ListaDetalleNumControl
                                                                     where x.Grupo == EnumGrupoDocumentos.F.ToString() //Facturas
                                                                     || x.Grupo == EnumGrupoDocumentos.B.ToString()    //Boletas
                                                                     || x.Grupo == EnumGrupoDocumentos.C.ToString()    //Nota de Crédito
                                                                     || x.Grupo == EnumGrupoDocumentos.D.ToString()    //Nota de Débito
                                                                     select x).ToList();

            var oListaDocumento = ListaDoc.GroupBy(x => x.idDocumento).Select(p => p.First()).ToList();
            NumControlDetE Fila = new NumControlDetE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            oListaDocumento.Add(Fila);

            ComboHelper.LlenarCombos<NumControlDetE>(cboTipoDocumento, oListaDocumento.OrderBy(x => x.idDocumento).ToList(), "idDocumento", "desDocumento");
        }

        void LlenarSeries()
        {
            List<NumControlDetE> ListaDetalle = new List<NumControlDetE>(from x in VariablesLocales.ListaDetalleNumControl
                                                                         where x.idControl == ((NumControlDetE)cboTipoDocumento.SelectedItem).idControl
                                                                         && x.idDocumento == cboTipoDocumento.SelectedValue.ToString()
                                                                         select x).ToList();

            ComboHelper.LlenarCombos<NumControlDetE>(cboSeries, ListaDetalle.OrderBy(x => x.Serie).ToList(), "Serie", "desDocCompuesto");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                List<CCostosE> oListaCostos = AgenteMaestro.Proxy.ListarCCostosPorTipoCCosto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 1, 2);
                bsCCostos.DataSource = oListaCostos;
                bsCCostos.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmCCostosNumControl_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            Buscar();
        }

        private void btInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoDocumento.SelectedValue.ToString() == "0")
                {
                    Global.MensajeComunicacion("Debe escoger un tipo de documento.");
                    cboTipoDocumento.Focus();
                    return;
                }

                if (cboSeries.SelectedValue == null)
                {
                    Global.MensajeComunicacion("Debe escoger una serie.");
                    cboSeries.Focus();
                    return;
                }

                Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                String idCostos = ((CCostosE)bsCCostos.Current).idCCostos;
                String idDoc = cboTipoDocumento.SelectedValue.ToString();
                String Serie = cboSeries.SelectedValue.ToString();

                foreach (CCostosNumControlDetE item in bsCostosSerie.List)
                {
                    if (item.idEmpresa == idEmpresa && item.idCCostos == idCostos && item.idDocumento == idDoc && item.Serie == Serie)
                    {
                        Global.MensajeComunicacion("Esta serie ya se encuentra asociada a este Centro de Costo.");
                        return;
                    }
                }

                CCostosNumControlDetE itemNuevo = new CCostosNumControlDetE()
                {
                    idEmpresa = idEmpresa,
                    idCCostos = idCostos,
                    idDocumento = idDoc,
                    Serie = Serie,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                };

                AgenteMaestro.Proxy.InsertarCCostosNumControlDet(itemNuevo);

                ((CCostosE)bsCCostos.Current).ListaSeries.Add(itemNuevo);
                bsCCostos.ResetBindings(false);
                bsCostosSerie.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 resp = 0;

                if (bsCostosSerie.Current != null)
                {
                    resp = AgenteMaestro.Proxy.EliminarCCostosNumControlDet(((CCostosNumControlDetE)bsCostosSerie.Current).idEmpresa, ((CCostosNumControlDetE)bsCostosSerie.Current).idCCostos,
                                                                                    ((CCostosNumControlDetE)bsCostosSerie.Current).idDocumento, ((CCostosNumControlDetE)bsCostosSerie.Current).Serie);
                    if (resp > 0)
                    {
                        Global.MensajeComunicacion("Fila eliminada.");
                        ((CCostosE)bsCCostos.Current).ListaSeries.RemoveAt(bsCostosSerie.Position);
                        bsCCostos.ResetBindings(false);
                        bsCostosSerie.ResetBindings(false);
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LlenarSeries();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsCCostos_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblTitulo1.Text = "Registros " + bsCCostos.List.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsCostosSerie_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblTitulo2.Text = "Registros " + bsCostosSerie.List.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsCCostos_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsCCostos.Position >= 0)
                {
                    bsCostosSerie.DataSource = ((CCostosE)bsCCostos.Current).ListaSeries;
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
