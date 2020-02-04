using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorCobrar;
using Entidades.Generales;
using Entidades.Seguridad;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;

namespace ClienteWinForm.CtasPorCobrar
{
    public partial class frmPlanillaCobranza : FrmMantenimientoBase
    {

        #region Constructor

        public frmPlanillaCobranza()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvDetalle, true);
            LlenarCombos();
        }

        //Nuevo
        public frmPlanillaCobranza(List<ParTabla> oListaParTabla, List<AsignarTipoCobranzaE> oListaTipoCobranza, Int32 TipoPlanilla)
            : this()
        {
            if (oListaParTabla != null)
            {
                ComboHelper.LlenarCombos<ParTabla>(cboTipoCobranza, oListaParTabla);
                oListaParTabla = null;
            }

            if (oListaTipoCobranza != null)
            {
                ComboHelper.LlenarCombos<AsignarTipoCobranzaE>(cboTipoCobranza, oListaTipoCobranza, "idTipoPlanilla", "desTipoPlanilla");
                oListaTipoCobranza = null;
            }

            cboTipoCobranza.SelectedValue = TipoPlanilla;

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                TipodePlanilla = ((ParTabla)cboTipoCobranza.SelectedItem).IdParTabla;
            }
            else
            {
                AsignarTipoCobranzaE Asignacion = (AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem;
                TipodePlanilla = ((AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem).idTipoPlanilla;
            }

            oTipoCobranzaDet = AgenteCtaPorCobrar.Proxy.ObtenerTipoIngresosDetPorPlanilla(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipodePlanilla);
        }

        //Edición
        public frmPlanillaCobranza(Int32 idPlanilla, List<ParTabla> oListaParTabla, List<AsignarTipoCobranzaE> oListaTipoCobranza)
            : this()
        {
            if (oListaParTabla != null)
            {
                ComboHelper.LlenarCombos<ParTabla>(cboTipoCobranza, oListaParTabla);
                oListaParTabla = null;
            }

            if (oListaTipoCobranza != null)
            {
                ComboHelper.LlenarCombos<AsignarTipoCobranzaE>(cboTipoCobranza, oListaTipoCobranza, "idTipoPlanilla", "desTipoPlanilla");
                oListaTipoCobranza = null;
            }

            oPlanillaCobranza = AgenteCtaPorCobrar.Proxy.ObtenerCobranzas(idPlanilla);
            Text = "Planilla de Cobranza (" + oPlanillaCobranza.codPlanilla + ")";

            cboTipoCobranza.SelectedValue = oPlanillaCobranza.TipoPlanilla;

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                TipodePlanilla = ((ParTabla)cboTipoCobranza.SelectedItem).IdParTabla;
            }
            else
            {
                AsignarTipoCobranzaE Asignacion = (AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem;
                TipodePlanilla = ((AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem).idTipoPlanilla;
            }

            oTipoCobranzaDet = AgenteCtaPorCobrar.Proxy.ObtenerTipoIngresosDetPorPlanilla(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipodePlanilla);
        }

        #endregion

        #region Variables

        CtasPorCobrarServiceAgent AgenteCtaPorCobrar { get { return new CtasPorCobrarServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        CobranzasE oPlanillaCobranza = null;
        String TipoCobro = String.Empty;

        Int32 TipodePlanilla;
        String Diario;
        String File;
        TipoIngresosDetE oTipoCobranzaDet = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ComboHelper.RellenarCombos<ComprobantesE>(cboComprobantes, (from x in ListaTipoComprobante
                                                                        orderby x.idComprobante
                                                                        select x).ToList(), "idComprobante", "desComprobanteComp", false);
            ListaTipoComprobante = null;

            List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListarBancos.Add(new BancosE() { idPersona = Variables.Cero, SiglaComercial = Variables.Seleccione });
            ComboHelper.RellenarCombos(cboBancos, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");

            oListarBancos = null;
        }

        void DatosPorGrabar()
        {
            oPlanillaCobranza.TipoPlanilla = Convert.ToInt32(cboTipoCobranza.SelectedValue);
            oPlanillaCobranza.Fecha = dtpFecha.Value.Date;
            oPlanillaCobranza.MontoSoles = Convert.ToDecimal(lblSoles.Text);
            oPlanillaCobranza.MontoDolares = Convert.ToDecimal(lblDolares.Text);
            oPlanillaCobranza.Observaciones = Global.DejarSoloUnEspacio(txtObservación.Text.Trim());
            oPlanillaCobranza.idComprobante = cboComprobantes.SelectedValue.ToString();
            oPlanillaCobranza.numFile = cboFile.SelectedValue.ToString();
            oPlanillaCobranza.AnioPeriodo = txtAnioPeriodo.Text;
            oPlanillaCobranza.MesPeriodo = txtMes.Text;
            oPlanillaCobranza.idBanco = Convert.ToInt32(cboBancos.SelectedValue) == 0 ? (Int32?)null : Convert.ToInt32(cboBancos.SelectedValue);

            if (String.IsNullOrWhiteSpace(txtCodPlanilla.Text))
            {
                oPlanillaCobranza.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oPlanillaCobranza.FechaRegistro = VariablesLocales.FechaHoy;
                oPlanillaCobranza.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPlanillaCobranza.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oPlanillaCobranza.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPlanillaCobranza.FechaModificacion = VariablesLocales.FechaHoy;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, CobranzasItemE oPlanillaCobranzaItem)
        {
            try
            {
                if (bsCobranzaItems.Count > 0)
                {
                    String TipoPlanillaNemo = String.Empty;

                    if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                    {
                        TipoPlanillaNemo = ((ParTabla)cboTipoCobranza.SelectedItem).NemoTecnico;
                    }
                    else
                    {
                        TipoPlanillaNemo = ((AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem).NemoTecnico;
                    }

                    frmPlanillaCobranzaDetalle oFrm = new frmPlanillaCobranzaDetalle(oPlanillaCobranzaItem, (txtEstado.Text == "ABIERTO" ?  false : true), TipoPlanillaNemo, dtpFecha.Value.Date);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oPlanillaCobranza.oListaCobranzas[e.RowIndex] = oFrm.oCobranzaItem;
                        bsCobranzaItems.DataSource = oPlanillaCobranza.oListaCobranzas;
                        bsCobranzaItems.ResetBindings(false);

                        SumarMontos();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void SumarMontos()
        {
            if (oPlanillaCobranza.oListaCobranzas.Count > 0)
            {
                Decimal Soles = 0;
                Decimal Dolares = 0;

                foreach (CobranzasItemE item in oPlanillaCobranza.oListaCobranzas)
                {
                    if (item.idMoneda == Variables.Soles)
                    {
                        Soles += item.Monto;
                        Dolares += item.Monto / item.tipCambioReci;
                    }
                    else
                    {
                        Soles += item.Monto * item.tipCambioReci;
                        Dolares += item.Monto;
                    }
                }

                lblSoles.Text = Soles.ToString("N2");
                lblDolares.Text = Dolares.ToString("N2");
            }
            else
            {
                lblSoles.Text = "0.00";
                lblDolares.Text = "0.00";
            }
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                if (oPlanillaCobranza == null)
                {
                    oPlanillaCobranza = new CobranzasE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal
                    };
                  
                    if (oTipoCobranzaDet != null)
                    {
                        Diario = oTipoCobranzaDet.idComprobante;
                        File = oTipoCobranzaDet.numFile;
                        TipoCobro = oTipoCobranzaDet.TipoCobro;
                    }
                    else
                    {
                        Diario = "04";
                        File = "01";
                        TipoCobro = null;
                    }

                    cboComprobantes.SelectedValue = Diario;
                    cboComprobantes_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboFile.SelectedValue = File;
                    cboFile_SelectionChangeCommitted(new Object(), new EventArgs());

                    if (oTipoCobranzaDet != null)
                    {
                        cboComprobantes.Enabled = false;
                        cboFile.Enabled = false;
                    }

                    txtEstado.Text = "ABIERTO";
                    txtAnioPeriodo.Text = dtpFecha.Value.ToString("yyyy");
                    txtMes.Text = dtpFecha.Value.ToString("MM");

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                }
                else
                {
                    dtpFecha.ValueChanged -= dtpFecha_ValueChanged;

                    cboTipoCobranza.SelectedValue = Convert.ToInt32(oPlanillaCobranza.TipoPlanilla);
                    txtCodPlanilla.Text = oPlanillaCobranza.codPlanilla;
                    dtpFecha.Value = oPlanillaCobranza.Fecha;
                    txtEstado.Text = oPlanillaCobranza.desEstado;
                    lblSoles.Text = oPlanillaCobranza.MontoSoles.ToString("N2");
                    lblDolares.Text = oPlanillaCobranza.MontoDolares.ToString("N2");
                    txtObservación.Text = oPlanillaCobranza.Observaciones.Trim();
                    cboComprobantes.SelectedValue = oPlanillaCobranza.idComprobante.ToString();
                    cboComprobantes_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboFile.SelectedValue = oPlanillaCobranza.numFile.ToString();
                    cboBancos.SelectedValue = oPlanillaCobranza.idBanco;

                    if (oTipoCobranzaDet != null)
                    {
                        TipoCobro = oTipoCobranzaDet.TipoCobro;
                        cboComprobantes.Enabled = false;
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        TipoCobro = null;
                    }

                    txtAnioPeriodo.Text = oPlanillaCobranza.AnioPeriodo;
                    txtMes.Text = oPlanillaCobranza.MesPeriodo;
                    txtVoucher.Text = oPlanillaCobranza.numVoucher.Trim();

                    txtUsuarioRegistro.Text = oPlanillaCobranza.UsuarioRegistro;
                    txtFechaRegistro.Text = oPlanillaCobranza.FechaRegistro.ToString();
                    txtUsuarioModificacion.Text = oPlanillaCobranza.UsuarioModificacion;
                    txtFechaModificacion.Text = oPlanillaCobranza.FechaModificacion.ToString();

                    dtpFecha.ValueChanged += dtpFecha_ValueChanged;
                }

                bsCobranzaItems.DataSource = oPlanillaCobranza.oListaCobranzas;
                bsCobranzaItems.ResetBindings(false);

                if (!oPlanillaCobranza.EstadoDoc)
                {
                    base.Nuevo();
                }
                else
                {
                    Global.MensajeComunicacion("La planilla se encuentra cerrada, no podrá hacer modificaciones.");
                    pnlCobranza.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }

                SumarMontos();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                bsCobranzaItems.EndEdit();
                DatosPorGrabar();

                if (String.IsNullOrEmpty(txtCodPlanilla.Text))
                {
                    if (Global.MensajeConfirmacion("Desea grabar la siguiente cobranza") == DialogResult.Yes)
                    {
                        oPlanillaCobranza = AgenteCtaPorCobrar.Proxy.GrabarCobranzas(oPlanillaCobranza, EnumOpcionGrabar.Insertar);
                    }
                }
                else
                {
                    if (txtAnioPeriodo.Text.Substring(2,2) != txtCodPlanilla.Text.Substring(2,2))
                    {
                        Global.MensajeComunicacion("No Coincide la Fecha Con la Numeracion !!! ");
                        return;
                    }

                    if (Global.MensajeConfirmacion("Desea actualizar la siguiente cobranza") == DialogResult.Yes)
                    {
                        oPlanillaCobranza = AgenteCtaPorCobrar.Proxy.GrabarCobranzas(oPlanillaCobranza, EnumOpcionGrabar.Actualizar);
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                String TipoPlanillaNemo = String.Empty;
                String TipoCob = String.Empty;

                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                {
                    TipoPlanillaNemo = ((ParTabla)cboTipoCobranza.SelectedItem).NemoTecnico;
                }
                else
                {
                    TipoPlanillaNemo = ((AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem).NemoTecnico;
                    TipoCob = ((AsignarTipoCobranzaE)cboTipoCobranza.SelectedItem).TipoCobro;
                }

                frmPlanillaCobranzaDetalle oFrm = new frmPlanillaCobranzaDetalle(dtpFecha.Value.Date, (ComprobantesFileE)cboFile.SelectedItem, TipoPlanillaNemo, TipoCobro);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    oPlanillaCobranza.oListaCobranzas.Add(oFrm.oCobranzaItem);
                    bsCobranzaItems.DataSource = oPlanillaCobranza.oListaCobranzas;
                    bsCobranzaItems.ResetBindings(false);

                    SumarMontos();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsCobranzaItems.Current != null || bsCobranzaItems.Count > 0)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (oPlanillaCobranza.oListaItemsEliminados == null)
                        {
                            oPlanillaCobranza.oListaItemsEliminados = new List<CobranzasItemE>();
                        }

                        CobranzasItemE oItemCobranza = (CobranzasItemE)bsCobranzaItems.Current;
                        oItemCobranza.oListaCobranzasItemDet = AgenteCtaPorCobrar.Proxy.ListarCobranzasItemDet(oItemCobranza.idPlanilla, oItemCobranza.Recibo);
                        oPlanillaCobranza.oListaItemsEliminados.Add(oItemCobranza);

                        oPlanillaCobranza.oListaCobranzas.RemoveAt(bsCobranzaItems.Position);
                        bsCobranzaItems.DataSource = oPlanillaCobranza.oListaCobranzas;
                        bsCobranzaItems.ResetBindings(false);
                        SumarMontos();

                        base.QuitarDetalle();
                        oItemCobranza = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion
         
        #region Eventos

        private void frmPlanillaCobranza_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboComprobantes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboComprobantes.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboComprobantes.SelectedItem).ListaComprobantesFiles);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (ListaFiles != null && ListaFiles.Count > 0)
                    {
                        cboFile.Enabled = true;
                    }
                    else
                    {
                        cboFile.Enabled = false;
                    }

                    ListaFiles = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            txtAnioPeriodo.Text = dtpFecha.Value.ToString("yyyy");
            txtMes.Text = dtpFecha.Value.ToString("MM");
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((CobranzasItemE)bsCobranzaItems.Current));
            }
        }

        private void cboFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //if (((ComprobantesFileE)cboFile.SelectedItem).LLevaCuenta)
                //{
                //    txtCodCuenta.Text = ((ComprobantesFileE)cboFile.SelectedItem).codCuenta.ToString();
                //}
                //else
                //{
                //    txtCodCuenta.Text = String.Empty;
                //}
                if (cboFile.SelectedValue != null && cboFile.SelectedValue.ToString() != "0")
                {
                    cboBancos.SelectedValue = ((ComprobantesFileE)cboFile.SelectedItem).idBanco;
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
