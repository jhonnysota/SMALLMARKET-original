using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmComprasVarias : FrmMantenimientoBase
    {

        #region Constructores

        public frmComprasVarias()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        public frmComprasVarias(String AnioPeriodo, String MesPeriodo)
            :this()
        {
            Anio = AnioPeriodo;
            Mes = MesPeriodo;
        }

        public frmComprasVarias(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, Int32 idComprobante)
            : this()
        {
            oComprasVarias = AgenteContabilidad.Proxy.ObtenerComprasVariasPorId(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, idComprobante);
        } 

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        ComprasVariasE oComprasVarias = null;
        Int32 opcion;
        String RazonSocial = String.Empty;
        String Anio = String.Empty;
        String Mes = String.Empty;
        Decimal ValorIgv = Variables.ValorCeroDecimal;
        Boolean Revisar = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);
            //////tipodocumento/////////
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione, EsReferencia = true };
            ListaDocumentos.Add(Fila);
            ComboHelper.RellenarCombos<DocumentosE>(cboTipoDocumento, (from x in ListaDocumentos
                                                                       where x.indDocumentoVentas != true || x.idDocumento == "0"
                                                                       orderby x.desDocumento
                                                                       select x).ToList(), "idDocumento", "desDocumento", false);
            //////documentoreferencia////
            List<DocumentosE> ListaDocumentosRef = new List<DocumentosE>(ListaDocumentos);
            ComboHelper.RellenarCombos<DocumentosE>(cboTipoDocRef, (from x in ListaDocumentos
                                                                    where x.EsReferencia == true
                                                                    orderby x.desDocumento
                                                                    select x).ToList(), "idDocumento", "desDocumento", false);
            ////FlagGrabado////
            cboFlagGrabado.DataSource = Global.CargarFPCE();
            cboFlagGrabado.ValueMember = "id";
            cboFlagGrabado.DisplayMember = "Nombre";
        }

        void GuardarDatos()
        {
            oComprasVarias.idProveedor = Convert.ToInt32(txtIdProveedor.Text);
            oComprasVarias.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oComprasVarias.fecOperacion = dtpFechaOp.Value.Date;

            if (opcion == (Int32)EnumOpcionGrabar.Actualizar)
            {
                if (oComprasVarias.tipDocumento != cboTipoDocumento.SelectedValue.ToString() || oComprasVarias.serDocumento != txtSerDocumento.Text.Trim() || oComprasVarias.numDocumento != txtNumDocumento.Text.Trim())
                {
                    Revisar = true;
                }
            }

            oComprasVarias.tipDocumento = cboTipoDocumento.SelectedValue.ToString();
            oComprasVarias.serDocumento = txtSerDocumento.Text.Trim();
            oComprasVarias.numDocumento = txtNumDocumento.Text.Trim();
            oComprasVarias.tipCambio = Convert.ToDecimal(txtTipCambio.Text);
            oComprasVarias.montAfecto = Convert.ToDecimal(txtAfecto.Text);
            oComprasVarias.montInafecto = Convert.ToDecimal(txtInafecto.Text);
            oComprasVarias.montIGV = Convert.ToDecimal(txtIgv.Text);
            oComprasVarias.montTotal = Convert.ToDecimal(txtTotal.Text);
            oComprasVarias.numRegistro = txtNumActa.Text;
            oComprasVarias.flagGravado = cboFlagGrabado.SelectedValue.ToString();

            if (dtpFecRef.Checked)
            {
                oComprasVarias.fecRef = dtpFecRef.Value.Date;
                oComprasVarias.tipDocRef = cboTipoDocRef.SelectedValue.ToString();
                oComprasVarias.serDocRef = txtSerieRef.Text;
                oComprasVarias.numDocRef = txtNumRef.Text;

                oComprasVarias.impIGVRef = Convert.ToDecimal(txtIGVRef.Text);
                oComprasVarias.impAfectoRef = Convert.ToDecimal(txtAfectoRef.Text);
            }
            else
            {
                oComprasVarias.fecRef = (Nullable<DateTime>)null;
                oComprasVarias.tipDocRef = String.Empty;
                oComprasVarias.serDocRef = String.Empty;
                oComprasVarias.numDocRef = String.Empty;

                oComprasVarias.impIGVRef = Variables.ValorCeroDecimal;
                oComprasVarias.impAfectoRef = Variables.ValorCeroDecimal;
            }

            if (dtpRectificacion.Checked)
            {
                oComprasVarias.indRectificacion = true;
                oComprasVarias.fecRectificacion = dtpRectificacion.Value.Date;
            }
            else
            {
                oComprasVarias.indRectificacion = false;
                oComprasVarias.fecRectificacion = (Nullable<DateTime>)null;
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
        }

        void Calcular()
        {
            //Monto Afecto
            Decimal MontoAfecto = 0;
            Decimal.TryParse(txtAfecto.Text, out MontoAfecto);

            // Igv
            Decimal MontoIgv = 0;
            Decimal Igv = Decimal.Round(MontoAfecto * ValorIgv, 2);
            txtIgv.Text = Igv.ToString("N2");
            Decimal.TryParse(txtIgv.Text, out MontoIgv);

            //Monto Inafecto
            Decimal MontoInafecto = 0;
            Decimal.TryParse(txtInafecto.Text, out MontoInafecto);

            //Total
            txtTotal.Text = Decimal.Round((Igv + MontoInafecto + MontoAfecto), 2).ToString("N2");
        }

        void ObtenerIgv()
        {
            try
            {
                List<ImpuestosDocumentosE> oListaImpuestoDocumento = AgenteGeneral.Proxy.ListarImpuestosPorIdDocumento(cboTipoDocumento.SelectedValue.ToString());

                if (oListaImpuestoDocumento != null && oListaImpuestoDocumento.Count > Variables.Cero)
                {
                    ImpuestosDocumentosE oImpuestoTmp = (from x in oListaImpuestoDocumento
                                                         where x.idImpuesto == 1
                                                         select x).SingleOrDefault();
                    if (oImpuestoTmp != null)
                    {
                        ImpuestosPeriodoE oImpuestosPeriodo = AgenteGeneral.Proxy.ObtenerPorcentajeImpuesto(oImpuestoTmp.idImpuesto, dtpFechaOp.Value.Date);

                        if (oImpuestosPeriodo != null)
                        {
                            lblPorIGV.Text = oImpuestosPeriodo.Porcentaje.ToString() + " %";
                            ValorIgv = Convert.ToDecimal(oImpuestosPeriodo.Porcentaje) / 100;
                        }
                    }
                }
                else
                {
                    lblPorIGV.Text = String.Empty;
                    ValorIgv = Variables.Cero;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            //BloquearPaneles(true);
            if (oComprasVarias == null)
            {
                oComprasVarias = new ComprasVariasE();

                oComprasVarias.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oComprasVarias.idLocal = VariablesLocales.SesionLocal.IdLocal;
                oComprasVarias.AnioPeriodo = Anio;
                oComprasVarias.MesPeriodo = Mes;

                dtpFechaOp.Value = VariablesLocales.FechaHoy.Date;
                txtUsuRegistra.Text = oComprasVarias.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oComprasVarias.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oComprasVarias.FechaRegistro.ToString();
                txtUsuModifica.Text = oComprasVarias.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oComprasVarias.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oComprasVarias.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtComprobante.Text = Convert.ToString(oComprasVarias.idComprobante);
                cboFlagGrabado.SelectedValue = oComprasVarias.flagGravado;
                txtNumActa.Text = oComprasVarias.numRegistro;
                txtIdProveedor.Text = Convert.ToString(oComprasVarias.idProveedor);
                dtpFechaOp.ValueChanged -= new EventHandler(dtpFechaOp_ValueChanged);
                dtpFechaOp.Value = Convert.ToDateTime(oComprasVarias.fecOperacion);
                dtpFechaOp.ValueChanged += new EventHandler(dtpFechaOp_ValueChanged);
                txtTipCambio.Text = Convert.ToString(oComprasVarias.tipCambio);
                txtRUC.Text = oComprasVarias.RUC;
                txtRazonSocial.Text = oComprasVarias.RazonSocial;
                cboTipoDocumento.SelectedValue = oComprasVarias.tipDocumento.ToString();
                txtSerDocumento.Text = oComprasVarias.serDocumento;

                if (oComprasVarias.indRectificacion)
                {
                    dtpRectificacion.Checked = true;
                    dtpRectificacion.Value = Convert.ToDateTime(oComprasVarias.fecRectificacion);
                }
                else
                {
                    dtpRectificacion.Checked = false;
                }

                cboMoneda.SelectedValue = Convert.ToString(oComprasVarias.idMoneda);
                txtNumDocumento.Text = oComprasVarias.numDocumento;
                txtAfecto.TextChanged -= new EventHandler(txtAfecto_TextChanged);
                txtInafecto.TextChanged -= new EventHandler(txtInafecto_TextChanged);
                txtAfecto.Text = oComprasVarias.montAfecto.ToString("N2");
                txtInafecto.Text = oComprasVarias.montInafecto.ToString("N2");
                txtAfecto.TextChanged += new EventHandler(txtAfecto_TextChanged);
                txtInafecto.TextChanged += new EventHandler(txtInafecto_TextChanged);
                txtIgv.Text = oComprasVarias.montIGV.ToString("N2");
                txtTotal.Text = oComprasVarias.montTotal.ToString("N2");

                if (oComprasVarias.fecRef != null)
                {
                    dtpFecRef.Value = Convert.ToDateTime(oComprasVarias.fecRef);
                }

                if (String.IsNullOrEmpty(oComprasVarias.tipDocRef))
                {
                    cboTipoDocRef.SelectedValue = Variables.Cero.ToString();
                    txtSerieRef.Text = String.Empty;
                    txtNumRef.Text = String.Empty;
                    txtIGVRef.Text = String.Empty;
                    txtAfectoRef.Text = String.Empty;
                }
                else
                {
                    cboTipoDocRef.SelectedValue = oComprasVarias.tipDocRef.ToString();
                    txtSerieRef.Text = oComprasVarias.serDocRef;
                    txtNumRef.Text = oComprasVarias.numDocRef;
                    txtIGVRef.Text = oComprasVarias.impIGVRef.ToString("N2");
                    txtAfectoRef.Text = oComprasVarias.impAfectoRef.ToString("N2");
                }

                txtUsuRegistra.Text = oComprasVarias.UsuarioRegistro;
                txtRegistro.Text = oComprasVarias.FechaRegistro.ToString();
                txtUsuModifica.Text = oComprasVarias.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oComprasVarias.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oComprasVarias.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
                ObtenerIgv();
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oComprasVarias != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oComprasVarias = AgenteContabilidad.Proxy.InsertarComprasVarias(oComprasVarias);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oComprasVarias = AgenteContabilidad.Proxy.ActualizarComprasVarias(oComprasVarias, Revisar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Cancelar()
        {
            BloquearPaneles(false);
            pnlAuditoria.Focus();
            base.Cancelar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<ComprasVariasE>(oComprasVarias);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (txtTipCambio.Text == "0.000")
            {
                Global.MensajeFault("Tiene que escoger una fecha que tenga Tipo de Cambio");
                return false;
            }

            if (((DocumentosE)cboTipoDocumento.SelectedItem).indReferencia)
            {
                if (!dtpFecRef.Checked)
                {
                    Global.MensajeFault("El documento escogido obliga a tener fecha de referencia");
                    return false;    
                }

                if (cboTipoDocRef.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    Global.MensajeFault("El documento escogido obliga a tener un tipo de documento de referencia");
                    return false;   
                }

                if (String.IsNullOrEmpty(txtSerieRef.Text.Trim()))
                {
                    Global.MensajeFault("El documento escogido obliga a tener serie de referencia");
                    return false;
                }

                if (String.IsNullOrEmpty(txtNumRef.Text.Trim()))
                {
                    Global.MensajeFault("El documento escogido obliga a tener número de referencia");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmComprasVarias_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btProveedor_Click(object sender, EventArgs e)
        {
            frmBusquedaProveedor oFrm = new frmBusquedaProveedor();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProveedor != null)
            {
                txtIdProveedor.Text = Convert.ToString(oFrm.oProveedor.IdPersona);
                txtRUC.Text = oFrm.oProveedor.RUC;
                txtRazonSocial.Text = oFrm.oProveedor.RazonSocial;
            }
        }

        private void dtpFechaOp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha = dtpFechaOp.Value.Date;
                TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMoneda.SelectedValue.ToString(), Fecha);

                if (Tica != null)
                {
                    txtTipCambio.Text = Tica.valVenta.ToString("N3");
                }
                else
                {
                    txtTipCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtpFechaOp.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRUC_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRUC.Text.Trim()))
            {
                txtRazonSocial.Text = String.Empty;
                txtIdProveedor.Text = String.Empty;
            }
        }

        private void txtRUC_Leave(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRUC.Text.Trim()) || String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(txtRUC.Text.Trim()))
                    {
                        List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRUC.Text);

                        if (oListaPersonas.Count > Variables.ValorUno)
                        {
                            frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "");

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                            {
                                txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                                txtRUC.Text = oFrm.oPersona.RUC;
                                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            }
                        }
                        else if (oListaPersonas.Count == 1)
                        {
                            txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                            txtRUC.Text = oListaPersonas[0].RUC;
                            txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        }
                        else
                        {
                            txtIdProveedor.Text = String.Empty;
                            txtRUC.Text = String.Empty;
                            txtRazonSocial.Text = String.Empty;

                            Global.MensajeFault("EL Ruc ingresado no existe");
                        }
                    }
                    else
                    {
                        txtRazonSocial.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtInafecto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtAfecto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            ComboHelper.AutoCompletar(cboTipoDocumento, e, false);
        }

        private void cboTipoDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            ComboHelper.AutoCompletar(cboTipoDocRef, e, false);
        }

        private void dtpFechaOp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpFecRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRUC.Text.Trim()) || String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                    {
                        List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                        if (oListaPersonas.Count > Variables.ValorUno)
                        {
                            frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                            {
                                txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                                txtRUC.Text = oFrm.oPersona.RUC;
                                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            }
                        }
                        else if (oListaPersonas.Count == 1)
                        {
                            txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                            txtRUC.Text = oListaPersonas[0].RUC;
                            txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        }
                        else
                        {
                            txtIdProveedor.Text = String.Empty;
                            txtRUC.Text = String.Empty;
                            txtRazonSocial.Text = String.Empty;

                            Global.MensajeFault("La Razón Social ingresado no existe");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoDocumento_Leave(object sender, EventArgs e)
        {
            try
            {
                List<ImpuestosDocumentosE> oListaImpuestoDocumento = AgenteGeneral.Proxy.ListarImpuestosPorIdDocumento(((ComboBox)sender).SelectedValue.ToString());

                if (oListaImpuestoDocumento != null && oListaImpuestoDocumento.Count > Variables.Cero)
                {
                    ImpuestosDocumentosE oImpuestoTmp = (from x in oListaImpuestoDocumento
                                                         where x.idImpuesto == 1
                                                         select x).SingleOrDefault();
                    if (oImpuestoTmp != null)
                    {
                        ImpuestosPeriodoE oImpuestosPeriodo = AgenteGeneral.Proxy.ObtenerPorcentajeImpuesto(oImpuestoTmp.idImpuesto, dtpFechaOp.Value.Date);

                        if (oImpuestosPeriodo != null)
                        {
                            lblPorIGV.Text = oImpuestosPeriodo.Porcentaje.ToString() + " %";
                            ValorIgv = Convert.ToDecimal(oImpuestosPeriodo.Porcentaje) / 100;
                            txtAfecto_TextChanged(new Object(), new EventArgs());
                        }
                        else
                        {
                            Global.MensajeFault("Este documento tiene un impuesto asignado, pero el periodo de vigencia esta vencido.\n\rModifiquelo y vuelva a intentarlo.");
                            return;
                        }
                    }
                    else
                    {
                        Global.MensajeFault("No existe ningun impuesto asignado al documento.");
                    }
                }
                else
                {
                    lblPorIGV.Text = String.Empty;
                    ValorIgv = Variables.Cero;
                    txtAfecto_TextChanged(new Object(), new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                txtIdProveedor.Text = String.Empty;
                txtRUC.Text = String.Empty;
            }
        }

        private void txtAfecto_Leave(object sender, EventArgs e)
        {
            txtAfecto.Text = Global.FormatoDecimal(txtAfecto.Text);
        }

        private void txtInafecto_Leave(object sender, EventArgs e)
        {
            txtInafecto.Text = Global.FormatoDecimal(txtInafecto.Text);
        }

        private void cboFlagGrabado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtpFechaOp_ValueChanged(null, null);
        }

        private void txtIgv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(lblPorIGV.Text))
                {
                    //Monto Afecto
                    Decimal MontoAfecto = 0;
                    Decimal.TryParse(txtAfecto.Text, out MontoAfecto);

                    // Igv
                    Decimal MontoIgv = 0;
                    Decimal.TryParse(txtIgv.Text, out MontoIgv);

                    //Monto Inafecto
                    Decimal MontoInafecto = 0;
                    Decimal.TryParse(txtInafecto.Text, out MontoInafecto);

                    //Total
                    txtTotal.Text = Decimal.Round((MontoIgv + MontoInafecto + MontoAfecto), 2).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtAfecto_Enter(object sender, EventArgs e)
        {
            txtAfecto.SeleccinarTodo();
        }

        private void txtAfecto_MouseClick(object sender, MouseEventArgs e)
        {
            txtAfecto.SeleccinarTodo();
        }

        private void txtInafecto_Enter(object sender, EventArgs e)
        {
            txtInafecto.SeleccinarTodo();
        }

        private void txtInafecto_MouseClick(object sender, MouseEventArgs e)
        {
            txtInafecto.SeleccinarTodo();
        }

        private void txtIgv_Enter(object sender, EventArgs e)
        {
            txtIgv.SeleccinarTodo();
        }

        private void txtIgv_MouseClick(object sender, MouseEventArgs e)
        {
            txtIgv.SeleccinarTodo();
        }

        #endregion

        private void pnlDatos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
