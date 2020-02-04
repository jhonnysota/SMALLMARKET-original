using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.Almacen;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmProgramaPago : FrmMantenimientoBase
    {

        #region Constructores

        public frmProgramaPago()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
        }

        public frmProgramaPago(ProgramaPagoE oPago_)
            : this()
        {
            oProgramaPago = oPago_;
        }

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        ProgramaPagoE oProgramaPago = null;
        List<DocumentosE> ListaDocumentos = null;
        String BuscarDato = "S";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Tipo de Pagos
            List<TipoPagoE> ListaTipoPago = AgenteTesoreria.Proxy.ListarTipoPagoCombo("E", VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ListaTipoPago.Add(new TipoPagoE() { codTipoPago = Variables.Cero.ToString(), desTipoPago = Variables.Seleccione });
            ComboHelper.RellenarCombos<TipoPagoE>(cboOperacion, (from x in ListaTipoPago orderby x.codTipoPago select x).ToList(), "codTipoPago", "desTipoPago");

            //Monedas
            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas)
            {
                new MonedasE() { idMoneda = Variables.Cero.ToString(), desMoneda = Variables.Seleccione }
            };
            ComboHelper.RellenarCombos<MonedasE>(cboMonedaPago, (from x in oListaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desMoneda");

            //Bancos
            List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListarBancos.Add(new BancosE() { idPersona = Variables.Cero, SiglaComercial = Variables.Seleccione });
            ComboHelper.RellenarCombos<BancosE>(cboBanco, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");

            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes)
            {
                new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos }
            };
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboLibro.SelectedValue = Variables.Cero.ToString();

            // Documentos
            ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                    where x.indTesoreria == true
                                                    select x).ToList();
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");

            // Documentos de Banco
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentoBanco, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");

            //Conceptos Gasto
            List<ConceptosVariosE> oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosTesoreria(0, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "");
            oListaConceptos = (from x in oListaConceptos where x.Descripcion.ToUpper().Contains("COMIS") || x.Descripcion.ToUpper().Contains("REDON") select x).ToList();
            oListaConceptos.Add(new ConceptosVariosE() { idConcepto = 0, Descripcion = Variables.Escoger });
            ComboHelper.LlenarCombos<ConceptosVariosE>(cboConceptoGasto, (from x in oListaConceptos orderby x.idConcepto select x).ToList(), "idConcepto", "Descripcion");

            ListaTipoComprobante = null;
            oListarBancos = null;
            oListaMonedas = null;
            ListaTipoPago = null;
            oListaConceptos = null;
        }

        void Datos()
        {
            oProgramaPago.desBeneficiario = txtDesBeneficiario.Text;

            oProgramaPago.Fecha = dtpFecPago.Value.Date;
            oProgramaPago.Grupo = txtGrupo.Text;
            oProgramaPago.codTipoPago = cboOperacion.SelectedValue.ToString();
            oProgramaPago.codFormaPago = cboFormaPago.SelectedValue.ToString();
            oProgramaPago.idMonedaPago = cboMonedaPago.SelectedValue.ToString();
            oProgramaPago.idPersonaBanco = Convert.ToInt32(cboBanco.SelectedValue);
            oProgramaPago.numCuenta = cboCuenta.SelectedValue.ToString();
            oProgramaPago.numCheque = txtNumCheque.Text.Trim();
            oProgramaPago.codPartidaPresu = txtCodPartida.Text;

            if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
            {
                oProgramaPago.idBancoAuxliar = Convert.ToInt32(cboBancosProveedor.SelectedValue);
                oProgramaPago.tipCtaAuxiliar = Convert.ToInt32(cboTipoCuenta.SelectedValue);

                if (((TipoPagoE)cboOperacion.SelectedItem).codTipo == "CPRO" || ((TipoPagoE)cboOperacion.SelectedItem).codTipo == "PDV")
                {
                    oProgramaPago.idMonedaAuxiliar = ((ProveedorCuentaE)cboTipoCuenta.SelectedItem).idMoneda.ToString();
                }
                else
                {
                    if (((TipoPagoE)cboOperacion.SelectedItem).codTipo != "PL" && ((TipoPagoE)cboOperacion.SelectedItem).codTipo != "RCTA")
                    {
                        if (cboDocumento.SelectedValue.ToString() == "AN")
                        {
                            oProgramaPago.idMonedaAuxiliar = ((ParTabla)cboTipoCuenta.SelectedItem).ValorCadena.ToString();
                        }
                        else
                        {
                            oProgramaPago.idMonedaAuxiliar = ((FondoFijoE)cboCuentasProveedor.SelectedItem).idMonedaCuenta.ToString();
                        } 
                    }
                }

                if (((TipoPagoE)cboOperacion.SelectedItem).codTipo == "PL" || ((TipoPagoE)cboOperacion.SelectedItem).codTipo == "RCTA")
                {
                    oProgramaPago.numCtaAuxiliar = txtNumCuenta.Text.Trim();
                }
                else
                {
                    oProgramaPago.numCtaAuxiliar = cboCuentasProveedor.SelectedValue.ToString();
                }
            }
            else
            {
                oProgramaPago.idBancoAuxliar = null;
                oProgramaPago.tipCtaAuxiliar = null;
                oProgramaPago.idMonedaAuxiliar = String.Empty;
                oProgramaPago.numCtaAuxiliar = String.Empty;
            }

            oProgramaPago.MontoOrigen = Convert.ToDecimal(txtMontoOrigen.Text);
            oProgramaPago.Monto = Convert.ToDecimal(txtMonto.Text);
            oProgramaPago.TipoCambio = Convert.ToDecimal(txtTica.Text);
            oProgramaPago.Glosa = txtGlosa.Text;
            oProgramaPago.idComprobante = cboLibro.SelectedValue.ToString();
            oProgramaPago.numFile = cboFile.SelectedValue.ToString();
            oProgramaPago.idDocumentoBanco = cboDocumentoBanco.SelectedValue.ToString();
            oProgramaPago.SerieBanco = txtSerieBanco.Text.Trim();
            oProgramaPago.NumeroBanco = txtNumeroBanco.Text.Trim();
            oProgramaPago.indComision = chkComision.Checked;

            if (chkComision.Checked)
            {
                oProgramaPago.idConceptoCom = Convert.ToInt32(cboConceptoGasto.SelectedValue);
                oProgramaPago.MontoCom = Convert.ToDecimal(txtGasCom.Text);
            }
            else
            {
                oProgramaPago.idConceptoCom = null;
                oProgramaPago.MontoCom = 0;
            }

            oProgramaPago.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
        }

        void LlenarComboBancoAuxiliar(Int32 idAuxiliar)
        {
            //Bancos Auxiliares
            if (((TipoPagoE)cboOperacion.SelectedItem).codTipo == "CPRO" || ((TipoPagoE)cboOperacion.SelectedItem).codTipo == "PDV")
            {
                List<ProveedorCuentaE> oListaBancosProv = AgenteMaestro.Proxy.BancosPorProv(idAuxiliar, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                ComboHelper.RellenarCombos<ProveedorCuentaE>(cboBancosProveedor, (from x in oListaBancosProv
                                                                                  orderby x.idPersonaBanco
                                                                                  select x).ToList(), "idPersonaBanco", "desBanco");
                oListaBancosProv = null;
            }
            else
            {
                List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                ComboHelper.RellenarCombos<BancosE>(cboBancosProveedor, (from x in oListarBancos
                                                                         orderby x.idPersona
                                                                         select x).ToList(), "idPersona", "SiglaComercial");
                oListarBancos = null;
            }
        }

        Boolean RevisarData(ProgramaPagoE oTmp)
        {
            if (oTmp.desBeneficiario != txtDesBeneficiario.Text)
            {
                return true;
            }

            if (oTmp.Monto != Convert.ToDecimal(txtMontoOrigen.Text))
            {
                return true;
            }

            if (oTmp.Grupo != txtGrupo.Text)
            {
                return true;
            }

            if (oTmp.codTipoPago != cboOperacion.SelectedValue.ToString())
            {
                return true;
            }

            if (oTmp.codFormaPago != cboFormaPago.SelectedValue.ToString())
            {
                return true;
            }

            if (oTmp.idMonedaPago != cboMonedaPago.SelectedValue.ToString())
            {
                return true;
            }

            if (oTmp.idPersonaBanco != Convert.ToInt32(cboBanco.SelectedValue))
            {
                return true;
            }

            if (oTmp.Glosa != txtGlosa.Text)
            {
                return true;
            }

            return false;
        }

        String DevolverMoneda(String idMoneda)
        {
            try
            {
                String Moneda = String.Empty;

                MonedasE oMon = VariablesLocales.ListaMonedas.Find
                (
                    delegate (MonedasE m) { return m.idMoneda == idMoneda; }
                );

                if (oMon != null)
                {
                    Moneda = oMon.desAbreviatura;
                }

                return Moneda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oProgramaPago != null)
            {
                BuscarDato = "N";
                txtMonto.TextChanged -= txtMonto_TextChanged;
                
                DocumentosE Doc = ListaDocumentos.Find
                (
                    delegate (DocumentosE d) { return d.idDocumento == oProgramaPago.idDocumento; }
                );

                if (Doc == null)
                {
                    throw new Exception(String.Format("El tipo de documento {0} no se encuentra en el listado de documentos de tesoreria.", oProgramaPago.idDocumento));
                }

                dtpFecPago.Value = oProgramaPago.Fecha.Date;
                cboDocumento.SelectedValue = oProgramaPago.idDocumento.ToString();
                cboDocumento_SelectionChangeCommitted(new Object(), new EventArgs());
                txtSerie.Text = oProgramaPago.serDocumento;
                txtNumero.Text = oProgramaPago.numDocumento;
                txtFecEmision.Text = Convert.ToDateTime(oProgramaPago.fecDocumento).ToString("dd/MM/yyyy");
                txtIdAuxiliar.Text = oProgramaPago.idPersona.ToString();
                txtRuc.Text = oProgramaPago.RUC;
                txtRazonSocial.Text = oProgramaPago.RazonSocial;
                txtDesBeneficiario.Text = oProgramaPago.desBeneficiario;
                txtIdMoneda.Tag = oProgramaPago.idMoneda.ToString();
                txtIdMoneda.Text = DevolverMoneda(txtIdMoneda.Tag.ToString());
                txtCodPartida.Text = oProgramaPago.codPartidaPresu;
                txtDesPartida.Text = oProgramaPago.desPartida;

                if (oProgramaPago.MontoOrigen == 0)
                {
                    oProgramaPago.MontoOrigen = oProgramaPago.Monto.Value;
                    txtMontoOrigen.Text = Convert.ToDecimal(oProgramaPago.MontoOrigen).ToString("N2");
                }
                else
                {
                    txtMontoOrigen.Text = Convert.ToDecimal(oProgramaPago.MontoOrigen).ToString("N2");
                }
                
                txtFecVencimiento.Text = Convert.ToDateTime(oProgramaPago.fecVencimiento).ToString("dd/MM/yyyy");

                if (oProgramaPago.idNumEgreso != null && oProgramaPago.idNumEgreso != 0)
                {
                    txtEgreso.Text = oProgramaPago.idNumEgreso.ToString();
                }

                txtGrupo.Text = oProgramaPago.Grupo;
                cboOperacion.SelectedValue = oProgramaPago.codTipoPago;
                cboOperacion_SelectionChangeCommitted(new Object(), new EventArgs());
                cboConceptos.SelectedValue = Convert.ToInt32(oProgramaPago.idConcepto);
                cboConceptos_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFormaPago.SelectedValue = oProgramaPago.codFormaPago;
                cboFormaPago_SelectionChangeCommitted(new Object(), new EventArgs());
                txtGlosa.Text = oProgramaPago.Glosa;

                //Bancos de la empresa
                cboBanco.SelectedValue = Convert.ToInt32(oProgramaPago.idPersonaBanco);

                if (oProgramaPago.idMonedaPago.ToString() == "0")
                {
                    cboMonedaPago.SelectedValue = oProgramaPago.idMoneda.ToString();
                }
                else
                {
                    cboMonedaPago.SelectedValue = oProgramaPago.idMonedaPago.ToString();
                }

                cboMonedaPago_SelectionChangeCommitted(new Object(), new EventArgs());
                cboCuenta.SelectedValue = oProgramaPago.numCuenta;
                cboCuenta_SelectionChangeCommitted(new Object(), new EventArgs());
                txtNumCheque.Text = oProgramaPago.numCheque;

                //Bancos de los auxiliares
                if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                {
                    LlenarComboBancoAuxiliar(Convert.ToInt32(txtIdAuxiliar.Text));
                    cboBancosProveedor.SelectedValue = Convert.ToInt32(oProgramaPago.idBancoAuxliar);
                    cboBancosProveedor_SelectionChangeCommitted(new object(), new EventArgs());
                    cboTipoCuenta.SelectedValue = Convert.ToInt32(oProgramaPago.tipCtaAuxiliar);
                    cboTipoCuenta_SelectionChangeCommitted(new object(), new EventArgs());

                    if (((TipoPagoE)cboOperacion.SelectedItem).codTipo != "PL" && ((TipoPagoE)cboOperacion.SelectedItem).codTipo != "RCTA")
                    {
                        txtNumCuenta.Visible = false;
                        cboCuentasProveedor.Visible = true;
                        cboCuentasProveedor.SelectedValue = oProgramaPago.numCtaAuxiliar.ToString();
                    }
                    else
                    {
                        cboBancosProveedor.Enabled = false;
                        cboTipoCuenta.Enabled = false;
                        txtNumCuenta.Visible = true;
                        cboCuentasProveedor.Visible = false;
                        txtNumCuenta.Text = oProgramaPago.numCtaAuxiliar.ToString();
                    }
                }
                else
                {
                    cboBancosProveedor.DataSource = null;
                    cboBancosProveedor.Enabled = false;
                    cboTipoCuenta.DataSource = null;
                    cboTipoCuenta.Enabled = false;
                    cboCuentasProveedor.DataSource = null;
                    cboCuentasProveedor.Enabled = false;
                }

                chkComision.Checked = oProgramaPago.indComision;

                if (oProgramaPago.indComision)
                {
                    cboConceptoGasto.SelectedValue = Convert.ToInt32(oProgramaPago.idConceptoCom);
                    txtGasCom.Text = oProgramaPago.MontoCom.ToString("N2");
                }

                //Datos Contables
                cboLibro.SelectedValue = oProgramaPago.idComprobante;
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFile.SelectedValue = oProgramaPago.numFile;

                txtTica.Text = oProgramaPago.TipoCambio.Value.ToString("N3");
                txtMonto.Text = oProgramaPago.Monto.Value.ToString("N2");

                cboDocumentoBanco.SelectedValue = String.IsNullOrWhiteSpace(oProgramaPago.idDocumentoBanco) ? "0" : oProgramaPago.idDocumentoBanco.ToString();
                txtSerieBanco.Text = oProgramaPago.SerieBanco;
                txtNumeroBanco.Text = oProgramaPago.NumeroBanco;

                txtMonto.TextChanged += txtMonto_TextChanged;
                BuscarDato = "S";

                if (oProgramaPago.Estado == "C")
                {
                    Global.MensajeComunicacion("El documento ya fue cerrado. No puede ser modificado.");
                    pnlDatos.Enabled = false;
                    pnlEmpresa.Enabled = false;
                    pnlAuxiliar.Enabled = false;
                    pnlContable.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }
                else if (oProgramaPago.Estado == "S")
                {
                    Global.MensajeComunicacion("El documento ya fue aprobado. No puede ser modificado.");
                    pnlDatos.Enabled = false;
                    pnlEmpresa.Enabled = false;
                    pnlAuxiliar.Enabled = false;
                    pnlContable.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }
                else
                {
                    pnlDatos.Enabled = false;
                    pnlEmpresa.Enabled = false;
                    pnlAuxiliar.Enabled = false;
                    pnlContable.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }

            }
        }

        public override void Grabar()
        {
            try
            {
                Datos();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                {
                    oProgramaPago = AgenteTesoreria.Proxy.ActualizarProgramaPago(oProgramaPago);
                    Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
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

        public override bool ValidarGrabacion()
        {
            String resultado = ValidarEntidad<ProgramaPagoE>(oProgramaPago);

            if (!String.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
            {
                if (cboBancosProveedor.SelectedValue == null)
                {
                    Global.MensajeFault("No existen datos bancarios para este Auxiliar, debe ingresarlas en Maestros - Auxiliares - Proveedores.");
                    return false;
                }

                if (cboTipoCuenta.SelectedValue == null)
                {
                    Global.MensajeFault("Faltan datos bancarios para este Auxiliar, debe ingresarlas en Maestros - Auxiliares - Proveedores.");
                    return false;
                }

                if (((TipoPagoE)cboOperacion.SelectedItem).codTipo != "PL" && ((TipoPagoE)cboOperacion.SelectedItem).codTipo != "RCTA")
                {
                    if (cboCuentasProveedor.SelectedValue == null)
                    {
                        Global.MensajeFault("Faltan datos bancarios para este Auxiliar, debe ingresarlas en Maestros - Auxiliares - Proveedores.");
                        cboCuentasProveedor.Focus();
                        return false;
                    } 
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtNumCuenta.Text.Trim()))
                    {
                        Global.MensajeFault("Falta número de cuenta.");
                        cboCuentasProveedor.Focus();
                        return false;
                    }
                }
            }

            if (cboBanco.SelectedValue == null || cboBanco.SelectedValue.ToString() == "0")
            {
                Global.MensajeFault("Falta escoger el Banco o la empresa no tiene Bancos asociados.");
                cboBanco.Focus();
                return false;
            }

            if (cboCuenta.SelectedValue.ToString() == "0" || cboCuenta.SelectedValue.ToString() == "<<SELECCIONE>>")
            {
                Global.MensajeFault("Tiene que escoger un N° de cuenta bancaria.");
                cboDocumentoBanco.Focus();
                return false;
            }

            if (cboDocumentoBanco.SelectedValue.ToString() == "0")
            {
                Global.MensajeFault("Falta escoger el tipo de documento del Banco.");
                cboDocumentoBanco.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtNumeroBanco.Text.Trim()))
            {
                Global.MensajeFault("Falta ingresar el N° documento del Banco.");
                txtNumeroBanco.Focus();
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Cerrar()
        {
            if (!Modificacion)
            {
                if (RevisarData(oProgramaPago))
                {
                    Modificacion = true;
                } 
            }

            base.Cerrar();
        }

        #endregion

        #region Eventos

        private void frmProgramaPago_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message + "\n\r" + ex.StackTrace);
            }
        }

        private void cboOperacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboOperacion.SelectedValue != null)
                {
                    List<TipoPagoDetE> oLista = new List<TipoPagoDetE>(((TipoPagoE)cboOperacion.SelectedItem).DetalleTipoPago);
                    oLista.Add(new TipoPagoDetE() { idConcepto = Variables.Cero, desConcepto = Variables.Seleccione });
                    ComboHelper.RellenarCombos<TipoPagoDetE>(cboConceptos, (from x in oLista orderby x.idConcepto select x).ToList(), "idConcepto", "desConcepto", false);

                    if (cboOperacion.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboConceptos.Enabled = false;
                    }
                    else
                    {
                        cboConceptos.Enabled = true;
                    }

                    cboConceptos_SelectionChangeCommitted(new Object(), new EventArgs());
                }
                else
                {
                    cboConceptos.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboBanco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<BancosCuentasE> oListaCuentas = AgenteMaestro.Proxy.ListarCuentasPorBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(cboBanco.SelectedValue), cboMonedaPago.SelectedValue.ToString());
                ComboHelper.RellenarCombos<BancosCuentasE>(cboCuenta, (from x in oListaCuentas orderby x.idPersona select x).ToList(), "numCuenta", "numCuenta");
                cboCuenta_SelectionChangeCommitted(new Object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMonedaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMonedaPago.SelectedValue != null)
            {
                String ProgramaPago = cboConceptos.Text.ToString();

                List<BancosCuentasE> oListaCuentas = AgenteMaestro.Proxy.ListarCuentasPorBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(cboBanco.SelectedValue), cboMonedaPago.SelectedValue.ToString());
                BancosCuentasE Ini = new BancosCuentasE() { idPersona = Variables.Cero, numCuenta = Variables.Seleccione };
                oListaCuentas.Add(Ini);
                ComboHelper.RellenarCombos<BancosCuentasE>(cboCuenta, (from x in oListaCuentas orderby x.idPersona select x).ToList(), "numCuenta", "numCuenta");

                if (cboMonedaPago.SelectedValue.ToString() != txtIdMoneda.Tag.ToString())
                {
                    txtMonto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
                else if (ProgramaPago == "DETRACCIONES MASIVAS")
                {
                    txtMonto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtMonto.ReadOnly = false;
                    txtMonto.Enabled = true;
                    txtMontoOrigen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
                else
                {
                    txtMonto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtMonto.Text = txtMontoOrigen.Text;
                    txtTica.Text = "1.000";
                }
            }
        }

        private void cboCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboCuenta.SelectedValue != null)
            {
                if (((FormaPagoE)cboFormaPago.SelectedItem).CodForma != "ETCC")
                {
                    txtNumCheque.Text = ((BancosCuentasE)cboCuenta.SelectedItem).numCheque; 
                }
                else
                {
                    txtNumCheque.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                }
            }
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }

                    if (ListaFiles.Count == 2)
                    {
                        cboFile.SelectedValue = ListaFiles[0].numFile;
                    }
                    else
                    {
                        cboFile.SelectedValue = Variables.Cero.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                {
                    pnlAuxiliar.Enabled = true;

                    if (BuscarDato == "S")
                    {
                        LlenarComboBancoAuxiliar(Convert.ToInt32(txtIdAuxiliar.Text));
                        cboBancosProveedor.SelectedValue = Convert.ToInt32(oProgramaPago.idBancoAuxliar);
                        cboBancosProveedor_SelectionChangeCommitted(new object(), new EventArgs());
                    }
                }
                else
                {
                    pnlAuxiliar.Enabled = false;
                    cboBancosProveedor.DataSource = null;
                    cboTipoCuenta.DataSource = null;
                    cboCuentasProveedor.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboBancosProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (((TipoPagoE)cboOperacion.SelectedItem).codTipo == "CPRO" || ((TipoPagoE)cboOperacion.SelectedItem).codTipo == "PDV")
                {
                    List<ProveedorCuentaE> oListaTipos = AgenteMaestro.Proxy.TipoCuentaProv(Convert.ToInt32(txtIdAuxiliar.Text), VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                        Convert.ToInt32(cboBancosProveedor.SelectedValue));
                    ComboHelper.RellenarCombos<ProveedorCuentaE>(cboTipoCuenta, oListaTipos, "tipCuenta", "desTipoCuenta");
                }
                else
                {
                    //Tipo Cuentas Bancarias
                    List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("CTABAN");
                    ListaTipoArticulo.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
                    ComboHelper.RellenarCombos<ParTabla>(cboTipoCuenta, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if ( ((TipoPagoE)cboOperacion.SelectedItem).codTipo == "CPRO" || ((TipoPagoE)cboOperacion.SelectedItem).codTipo == "PDV" )
                {
                    List<ProveedorCuentaE> oListaCuentas = AgenteMaestro.Proxy.CuentasBancosProv(Convert.ToInt32(txtIdAuxiliar.Text), VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                        Convert.ToInt32(cboBancosProveedor.SelectedValue), Convert.ToInt32(cboTipoCuenta.SelectedValue));
                    ComboHelper.RellenarCombos<ProveedorCuentaE>(cboCuentasProveedor, oListaCuentas, "CuentaBanco", "desCuenta");
                    oListaCuentas = null;
                }
                else
                {
                    if (((TipoPagoE)cboOperacion.SelectedItem).codTipo != "PL" && ((TipoPagoE)cboOperacion.SelectedItem).codTipo != "RCTA")
                    {
                        if (cboDocumento.SelectedValue.ToString() == "AN")
                        {
                            List<ProveedorCuentaE> oListaCuentas = AgenteMaestro.Proxy.CuentasBancosProv(Convert.ToInt32(txtIdAuxiliar.Text), VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                        Convert.ToInt32(cboBancosProveedor.SelectedValue), Convert.ToInt32(cboTipoCuenta.SelectedValue));
                            ComboHelper.RellenarCombos<ProveedorCuentaE>(cboCuentasProveedor, oListaCuentas, "CuentaBanco", "desCuenta");
                            oListaCuentas = null;
                        }
                        else
                        {
                            List<FondoFijoE> oListaCuentaFF = AgenteTesoreria.Proxy.FondoFijoCuentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(txtIdAuxiliar.Text), Convert.ToInt32(cboBancosProveedor.SelectedValue));
                            ComboHelper.RellenarCombos<FondoFijoE>(cboCuentasProveedor, oListaCuentaFF, "numCuenta", "desCuenta");
                            oListaCuentaFF = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "14")
            {
                pnlAuxiliar.Enabled = false;
            }
            else
            {
                pnlAuxiliar.Enabled = true;
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal.TryParse(txtMontoOrigen.Text, out Decimal MontoOrigen);
                Decimal.TryParse(txtMonto.Text, out Decimal Monto);

                if (cboMonedaPago.SelectedValue.ToString() != txtIdMoneda.Tag.ToString())
                {
                    if (txtIdMoneda.Tag.ToString() == "02" && cboMonedaPago.SelectedValue.ToString() == "01")
                    {
                        txtTica.Text = (Monto / MontoOrigen).ToString("N3");
                    }

                    if (txtIdMoneda.Tag.ToString() == "01" && cboMonedaPago.SelectedValue.ToString() == "02")
                    {
                        txtTica.Text = (MontoOrigen / Monto).ToString("N3");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboConceptos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                String ProgramaPago = String.Empty;

                if (cboOperacion.SelectedValue != null && cboConceptos != null)
                {
                    List<FormaPagoE> ListaFormaPago = AgenteTesoreria.Proxy.ListarFormaPagoPorTipo(cboOperacion.SelectedValue.ToString(), Convert.ToInt32(cboConceptos.SelectedValue), VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                    ComboHelper.RellenarCombos<FormaPagoE>(cboFormaPago, (from x in ListaFormaPago orderby x.codFormaPago select x).ToList(), "codFormaPago", "desFormaPago");

                    if (ListaFormaPago.Count == 0)
                    {
                        cboFormaPago.Enabled = false;
                    }
                    else
                    {
                        cboFormaPago.Enabled = true;
                    }
                    ProgramaPago = cboConceptos.Text;

                    if (ProgramaPago == "DETRACCIONES MASIVAS")
                    {
                        txtMonto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtMontoOrigen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }
                    else
                    {
                        txtMonto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                        txtMontoOrigen.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    }

                }
                else
                {
                    cboFormaPago.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            txtMonto.Text = Global.FormatoDecimal(txtMonto.Text);
        }

        private void chkComision_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComision.Checked)
            {
                cboConceptoGasto.Enabled = true;
                txtGasCom.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                cboConceptoGasto.Enabled = false;
                txtGasCom.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        private void btPresupuesto_Click(object sender, EventArgs e)
        {
            frmBuscarPartida oFrm = new frmBuscarPartida();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
            {
                txtCodPartida.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                txtDesPartida.Text = oFrm.oPartidaPresupuestal.desPartidaPresu;
                oProgramaPago.tipPartidaPresu = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                oProgramaPago.codPartidaPresu = oFrm.oPartidaPresupuestal.codPartidaPresu;
            }
        }

        #endregion

    }
}
