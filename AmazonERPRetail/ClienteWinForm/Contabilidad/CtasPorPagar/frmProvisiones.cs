using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.Almacen;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Contabilidad.CtasPorPagar;
using ClienteWinForm.Tesoreria;

namespace ClienteWinForm.CtasPorPagar
{
    public partial class frmProvisiones : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmProvisiones()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvprovisionesccosto, false);
        }

        //Edición
        public frmProvisiones(Int32 idEmpresa_, Int32 idLocal_, Int32 idProvision_, Boolean RevisarD = false)
            : this()
        {
            oProvisiones = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(idEmpresa_, idLocal_, idProvision_);
            oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(idEmpresa_, oProvisiones.AnioPeriodo, oProvisiones.MesPeriodo);

            if (oPeriodoContable.indCierre)
            {
                BloquearPaneles(false);
                MostroMensaje = true;
                Global.MensajeComunicacion("El mes Contable se encuentra cerrado. No podra hacer modificaciones.");
            }

            if (!MostroMensaje)
            {
                oCierreSistema = AgenteContabilidad.Proxy.ObtenerCierreSistema(idEmpresa_, oProvisiones.AnioPeriodo, oProvisiones.MesPeriodo, 5);

                if (oCierreSistema != null)
                {
                    if (oCierreSistema.indCierre)
                    {
                        if (oProvisiones.FechaProvision <= oCierreSistema.FechaCierre)
                        {
                            BloquearPaneles(false);
                            MostroMensaje = true;
                            Global.MensajeComunicacion("El sistema de Compras a esa fecha se encuentra cerrado");
                        }
                    }
                } 
            }

            if (!MostroMensaje)
            {
                if (oProvisiones.EstadoProvision == "PR")
                {
                    Global.MensajeComunicacion("No podrá realizar modificaciones porque este documento ya se encuentra Provisionado.");
                    BloquearPaneles(false);
                    chkIndReversion.CheckedChanged -= chkIndReversion_CheckedChanged;
                }

                if (oProvisiones.EstadoProvision == "LI")
                {
                    Global.MensajeComunicacion("No podrá realizar modificaciones porque este documento viene del Módulo de Tesoreria (Liquidaciones).");
                    BloquearPaneles(false);
                    chkIndReversion.CheckedChanged -= chkIndReversion_CheckedChanged;
                }

                if (oProvisiones.EstadoProvision == "RD")
                {
                    Global.MensajeComunicacion("No podrá realizar modificaciones porque este documento viene del Módulo de Tesoreria (Rendiciones).");
                    BloquearPaneles(false);
                    chkIndReversion.CheckedChanged -= chkIndReversion_CheckedChanged;
                }

                if (oProvisiones.EstadoProvision == "AN")
                {
                    Global.MensajeComunicacion("No podrá realizar modificaciones porque este documento ya se encuentra Anulado.");
                    BloquearPaneles(false);
                    chkIndReversion.CheckedChanged -= chkIndReversion_CheckedChanged;
                }

                if (oProvisiones.EstadoProvision == "RE")
                {
                    if (oProvisiones.idOrdenPago > 0)
                    {
                        Global.MensajeComunicacion("No podrá realizar modificaciones porque el documento se encuentra en una Orden de Pago.");
                        BloquearPaneles(false);
                        chkIndReversion.CheckedChanged -= chkIndReversion_CheckedChanged;
                    }
                } 
            }

            Text = "Compras(N° " + oProvisiones.idProvision.ToString("0000000") + ")";
            RevisionDetra = RevisarD;
            cboAfectacionAlmacen.Enabled = false;
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        Int32 Opcion;
        ProvisionesE oProvisiones = null;
        Boolean ingAlmacen = false;
        PeriodosE oPeriodoContable = null;
        CierreSistemaE oCierreSistema = null;
        Boolean RevisionDetra = false;
        Boolean BloqueoTotal = false;
        Boolean MostroMensaje = false;

        #endregion

        #region Procedimientos de Usuario

        void BloquearPaneles(Boolean Flag)
        {
            pnlProvision.Enabled = Flag;
            pnlDetraccion.Enabled = Flag;
            pnlMontos.Enabled = Flag;
            pnlAuditoria.Enabled = Flag;
            pnlCreditoFiscal.Enabled = Flag;
            pnlRenta.Enabled = Flag;
            btArticulos.Enabled = Flag;
            btGastos.Enabled = Flag;
            btServicios.Enabled = Flag;
            btActivos.Enabled = Flag;
            btAnticipos.Enabled = Flag;
            chkIndReversion.Enabled = Flag;
            txtIdReversion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            btBuscarRever.Enabled = Flag;

            BloqueoTotal = !Flag;
        }

        void LlenarCombo()
        {
            // Plantilla
            List<Plantilla_ConceptoE> ListaPlantilla = AgenteCtasPorPagar.Proxy.ListarPlantilla_Concepto(VariablesLocales.SesionLocal.IdEmpresa);
            Plantilla_ConceptoE Plantilla = new Plantilla_ConceptoE() { idPlantilla = Variables.Cero, DesPlantilla = "[Escoger Plantilla]" };
            ListaPlantilla.Add(Plantilla);
            ComboHelper.RellenarCombos<Plantilla_ConceptoE>(cboPlantilla, (from x in ListaPlantilla orderby x.idPlantilla select x).ToList(), "idPlantilla", "DesPlantilla", false);

            // Afectacion al Almacen
            cboAfectacionAlmacen.DataSource = Global.CargarAfectacionAlmacenNC();
            cboAfectacionAlmacen.ValueMember = "id";
            cboAfectacionAlmacen.DisplayMember = "Nombre";

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   where x.indDocumentoCompras == true
                                                                   && x.indBaja == false
                                                                   orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento", false);
            //Referencia
            ComboHelper.RellenarCombos<DocumentosE>(cboReferencia, (from x in ListaDocumentos
                                                                    where x.indDocumentoCompras == true && x.EsReferencia == true || x.idDocumento == "0"
                                                                    orderby x.desDocumento
                                                                    select x).ToList(), "idDocumento", "desDocumento", false);

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             where (x.idMoneda == Variables.Soles) ||
                                                                   (x.idMoneda == Variables.Dolares)
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);

            List<ComprasFileE> oListaTipoCompras = AgenteContabilidad.Proxy.ListarComprasFile(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "S");
            ComboHelper.RellenarCombos<ComprasFileE>(cboTipoAsiento, (from x in oListaTipoCompras
                                                                      orderby x.idCompraFile
                                                                      select x).ToList(), "idCompraFile", "Descripcion", false);

            //Tipo Documento
            List<ParTabla> oListaTipos = new List<ParTabla>
            {
                new ParTabla() { IdParTabla = 0, Nombre = "<< NINGUNO >>" },
                new ParTabla() { IdParTabla = 1, Nombre = "ANTICIPO" },
                new ParTabla() { IdParTabla = 2, Nombre = "APLICACION DE ANTICIPO" }
            };

            ComboHelper.RellenarCombos<ParTabla>(cboAnticipos, oListaTipos);

            ListaPlantilla = null;
            ListaDocumentos = null;
            ListaMoneda = null;
            oListaTipoCompras = null;
            Plantilla = null;
            Fila = null;
            oListaTipos = null;

            LlenarComboNoDomiciliados();
        }

        void LlenarComboNoDomiciliados()
        {
            /******************* NO DOMICIALIADO **************************/
            //Documentos - Crédito Fiscal
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indDocumentoCompras == true
                                                                      && x.indCreditoFiscal == true
                                                                      select x).ToList();
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);
            ComboHelper.RellenarCombos<DocumentosE>(cboDocCreditoFiscal, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento", false);

            //Dependencias aduaneras
            List<ParTabla> ListarDependencias = AgenteGeneral.Proxy.ListarParTablaPorNemo("DEAD");
            ParTabla fil = new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione };
            ListarDependencias.Add(fil);
            ComboHelper.LlenarCombos<ParTabla>(cboDependencia, (from x in ListarDependencias orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");

            ////Listado de las cuentas de renta
            //List<PlanCuentasE> oListaCuentas = AgenteContabilidad.Proxy.CuentasRenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);
            //PlanCuentasE oCuenta = new PlanCuentasE() { codCuenta = "0", desCuentaTemp = Variables.Seleccione };
            //oListaCuentas.Add(oCuenta);
            //ComboHelper.LlenarCombos<PlanCuentasE>(cboTasa, (from x in oListaCuentas orderby x.codCuenta select x).ToList(), "codCuenta", "desCuentaTemp");

            ListaDocumentos = null;
            Fila = null;
            ListarDependencias = null;
            fil = null;
            //oListaCuentas = null;
            //oCuenta = null;
        }

        void LlenarComboDetraccion(DateTime Fecha)
        {
            // Tipo de Detraccion
            List<TasasDetraccionesDetalleE> ListaTipoDetraccion = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(Fecha);

            if (ListaTipoDetraccion.Count > 0)
            {
                ListaTipoDetraccion.Add(new TasasDetraccionesDetalleE() { idTipoDetraccion = Variables.Cero.ToString(), Nombre = "<Escoger Tasa>" });
                ComboHelper.RellenarCombos<TasasDetraccionesDetalleE>(cbotipodetraccion, (from x in ListaTipoDetraccion orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "Nombre", false);
            }
            else
            {
                Global.MensajeFault("No existe ningún Tipo de Detracción para la fecha escogida.");
                cbotipodetraccion.DataSource = null;
                chkDetraccion.Checked = false;
                chkDetraccion.Enabled = true;
            }
        }

        void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Pro)
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Proveedor. Desea agregarlo ?") == DialogResult.Yes)
                {
                    ProveedorE oProveedor = new ProveedorE()
                    {
                        IdPersona = oListaPersonasTmp[0].IdPersona,
                        IdEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        SiglaComercial = oListaPersonasTmp[0].RazonSocial,
                        TipoProveedor = 0,
                        fecInscripcion = (Nullable<DateTime>)null,
                        fecInicioActividad = (Nullable<DateTime>)null,
                        tipConstitucion = 0,
                        tipRegimen = 0,
                        catProveedor = 0,
                        indBaja = Variables.NO,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestro.Proxy.InsertarProveedor(oProveedor);
                }
            }
        }

        void DatosPorGrabar()
        {
            oProvisiones.idPersona = String.IsNullOrWhiteSpace(txtIdProveedor.Text) ? (Int32?)null : Convert.ToInt32(txtIdProveedor.Text);
            oProvisiones.FechaProvision = dtpFechaProvision.Value.Date;
            oProvisiones.NumDiasVen = Convert.ToInt32(txtNumDiasVen.Text);
            oProvisiones.FechaVencimiento = dtpFecVencimiento.Value.Date;
            oProvisiones.idDocumento = cboDocumento.SelectedValue.ToString();
            oProvisiones.NumSerie = txtSerie.Text;
            oProvisiones.NumDocumento = txtNumero.Text;
            oProvisiones.FechaDocumento = dtpFecDocumento.Value.Date;

            if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
            {
                oProvisiones.idDocumentoRef = cboReferencia.SelectedValue.ToString();
                oProvisiones.numSerieRef = txtSerieRef.Text.Trim();
                oProvisiones.numDocumentoRef = txtNumRef.Text.Trim();
                oProvisiones.fecDocumentoRef = dtpFecRef.Value.Date;
            }
            else
            {
                oProvisiones.idDocumentoRef = String.Empty;
                oProvisiones.numSerieRef = String.Empty;
                oProvisiones.numDocumentoRef = String.Empty;
                oProvisiones.fecDocumentoRef = null;
            }

            oProvisiones.CodMonedaProvision = cboMoneda.SelectedValue.ToString();
            oProvisiones.ImpMonedaOrigen = Convert.ToDecimal(txtImporteOrigen.Text);
            oProvisiones.AnioPeriodo = dtpFechaProvision.Value.ToString("yyyy");
            oProvisiones.MesPeriodo = dtpFechaProvision.Value.ToString("MM");

            oProvisiones.indAfectacionAlmacen = Convert.ToInt32(cboAfectacionAlmacen.SelectedValue);

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oProvisiones.EstadoProvision = "RE";
            }

            if (String.IsNullOrEmpty(oProvisiones.numVoucher))
            {
                oProvisiones.numVoucher = string.Empty;
            }

            if (String.IsNullOrEmpty(oProvisiones.AnioPeriodo))
            {
                oProvisiones.AnioPeriodo = string.Empty;
            }

            if (String.IsNullOrEmpty(oProvisiones.MesPeriodo))
            {
                oProvisiones.MesPeriodo = string.Empty;
            }

            oProvisiones.idComprobante = ((ComprasFileE)cboTipoAsiento.SelectedItem).idComprobante;
            oProvisiones.numFile = ((ComprasFileE)cboTipoAsiento.SelectedItem).numFile;
            oProvisiones.TipCambio = Convert.ToDecimal(txtTipCambio.Text);
            oProvisiones.IndCalcAuto = chkIndCalcAuto.Checked;
            oProvisiones.impTotalBase = Convert.ToDecimal(txtTotal.Text);
            oProvisiones.impImponBase = Convert.ToDecimal(txtBaseImponible.Text);
            oProvisiones.impExonBase = Convert.ToDecimal(txtExonerado.Text);
            oProvisiones.impAjusteBase = Convert.ToDecimal(txtAjuste.Text);
            oProvisiones.impImpuestoBase = Convert.ToDecimal(txtImpuesto.Text);
            oProvisiones.impTotalSecun = Convert.ToDecimal(txtTotalSecu.Text);
            oProvisiones.impImponSecun = Convert.ToDecimal(txtBaseSecu.Text);
            oProvisiones.impExonSecun = Convert.ToDecimal(txtExoneradoSecu.Text);
            oProvisiones.impAjusteSecun = Convert.ToDecimal(txtAjusteSecu.Text);
            oProvisiones.impImpuestoSecun = Convert.ToDecimal(txtImpuestoSecu.Text);
            oProvisiones.CodPartidaPresu = txtCodPartida.Text.Trim();
            oProvisiones.tipPartidaPresu = txtCodPartida.Tag == null ? string.Empty : txtCodPartida.Tag.ToString();
            oProvisiones.NumVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            oProvisiones.codCuenta = txtCodCuenta.Text;
            oProvisiones.DesProvision = txtDesProvision.Text;
            oProvisiones.idRecepcion = String.IsNullOrEmpty(txtCodConversion.Text.Trim()) ? (Nullable<Int32>)null : (txtCodConversion.Text == "0" ? (Nullable<Int32>)null : Convert.ToInt32(txtCodConversion.Text));
            oProvisiones.idOrdenCompra = String.IsNullOrEmpty(txtOrdenCompra.Text.Trim()) ? (Nullable<Int32>)null : Convert.ToInt32(txtOrdenCompra.Tag);
            oProvisiones.NumGuia = txtGuia.Text.Trim();
            oProvisiones.idPlantilla = Convert.ToInt32(cboPlantilla.SelectedValue) == 0 ? (Nullable<Int32>)null : Convert.ToInt32(cboPlantilla.SelectedValue);
            oProvisiones.flagDetraccion = chkDetraccion.Checked;

            if (oProvisiones.flagDetraccion)
            {
                oProvisiones.retNumero = txtNumDetraccion.Text;
                oProvisiones.retFecha = dtpFecRetencion.Value.Date;
                oProvisiones.TipoDetraccion = cbotipodetraccion.SelectedValue.ToString();
                oProvisiones.TasaDetraccion = Convert.ToDecimal(txtTasaDetra.Text);

                if (oProvisiones.CodMonedaProvision == Variables.Soles)
                {
                    oProvisiones.MontoDetraccion = Convert.ToDecimal(txtMontoDetraS.Text);
                }
                else
                {
                    oProvisiones.MontoDetraccion = Convert.ToDecimal(txtMontoDetraD.Text);
                }

                oProvisiones.indPagoDetra = chkPagoDetra.Checked;
            }
            else
            {
                oProvisiones.retNumero = string.Empty;
                oProvisiones.retFecha = (Nullable<DateTime>)null;
                oProvisiones.TipoDetraccion = string.Empty; ;
                oProvisiones.TasaDetraccion = 0;
                oProvisiones.MontoDetraccion = 0;
                oProvisiones.indPagoDetra = false;
            }

            oProvisiones.idCompraFile = Convert.ToInt32(cboTipoAsiento.SelectedValue);
            oProvisiones.indHojaCosto = chkIndCosto.Checked;
            oProvisiones.idHojaCosto = chkIndCosto.Checked ? Convert.ToInt32(txtNumHojaCosto.Text) : (Int32?)null;
            oProvisiones.indDistribucion = chkIndDistribucion.Checked;

            //Conversion
            oProvisiones.indConversion = chkConversion.Checked;

            if (oProvisiones.indConversion)
            {
                oProvisiones.idOrdenConversion = Convert.ToInt32(txtCodConversion.Tag);
            }
            else
            {
                oProvisiones.idOrdenConversion = null;
            }

            /********************** Datos No Domiciliado *************************/
            oProvisiones.indNoDom = chkindNoDom.Checked;
            oProvisiones.idDocCredFiscal = cboDocCreditoFiscal.SelectedValue != null ? cboDocCreditoFiscal.SelectedValue.ToString() : string.Empty;
            oProvisiones.depAduanera = cboDependencia.SelectedValue != null ? Convert.ToInt32(cboDependencia.SelectedValue) : (int?)null;
            oProvisiones.serDocCredFiscal = txtSerieCredFiscal.Text.Trim();
            oProvisiones.AnioDua = txtAnioDua.Text.Trim();
            oProvisiones.numDocCredFiscal = txtNumDua.Text.Trim();

            Decimal.TryParse(txtRentaBruta.Text, out Decimal RentaB);
            Decimal.TryParse(txtTasaRetencion.Text, out Decimal TasaRet);
            Decimal.TryParse(txtRentaNeta.Text, out Decimal RentaN);
            Decimal.TryParse(txtImpuestoRete.Text, out Decimal impRet);
            Decimal.TryParse(txtIgvNoDom.Text, out Decimal IgvNoDom);

            oProvisiones.RentaBruta = RentaB;
            oProvisiones.TasaRetencion = TasaRet;
            oProvisiones.RentaNeta = RentaN;
            oProvisiones.impRetenido = impRet;

            oProvisiones.idTasaRenta = cboTasa.SelectedValue != null ? cboTasa.SelectedValue.ToString() : String.Empty;
            oProvisiones.codCuentaRenta = txtCuentaRenta.Text.Trim();
            oProvisiones.indIgvNoDom = chkIgvNoDom.Checked;
            oProvisiones.IgvNoDom = IgvNoDom;
            /**********************************************************************/

            oProvisiones.indReversion = chkIndReversion.Checked;
            oProvisiones.idProvisionRev = !String.IsNullOrWhiteSpace(txtIdReversion.Text.Trim()) ? Convert.ToInt32(txtIdReversion.Text.Trim()) : (int?)null;
            oProvisiones.EsAnticipo = Convert.ToInt32(cboAnticipos.SelectedValue);

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oProvisiones.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oProvisiones.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void Calcular()
        {
            if (oProvisiones.ListaPorCCosto != null && oProvisiones.ListaPorCCosto.Count > 0)
            {
                Decimal TotalS = (from x in oProvisiones.ListaPorCCosto where x.Tipo != "P" select x.impSoles).Sum();
                Decimal TotalSAA = (from x in oProvisiones.ListaPorCCosto where x.Tipo == "P" select x.impSoles).Sum();
                TotalS -= TotalSAA;

                Decimal TotalD = (from x in oProvisiones.ListaPorCCosto where x.Tipo != "P" select x.impDolares).Sum();
                Decimal TotalDAA = (from x in oProvisiones.ListaPorCCosto where x.Tipo == "P" select x.impDolares).Sum();
                TotalD -= TotalDAA;

                Decimal subTotal = (from x in oProvisiones.ListaPorCCosto where x.Tipo != "P" && x.indIgv == true select x.subTotal).Sum();
                Decimal subTotalAA = (from x in oProvisiones.ListaPorCCosto where x.Tipo == "P" && x.indIgv == true select x.subTotal).Sum();
                subTotal -= subTotalAA;

                Decimal subTotalExo = (from x in oProvisiones.ListaPorCCosto where x.Tipo != "P" && x.indIgv == false select x.subTotal).Sum();
                Decimal subTotalExoAA = (from x in oProvisiones.ListaPorCCosto where x.Tipo == "P" && x.indIgv == false select x.subTotal).Sum();
                subTotalExo -= subTotalExoAA;

                Decimal Igv = (from x in oProvisiones.ListaPorCCosto where x.Tipo != "P" select x.Igv).Sum();
                Decimal IgvAA = (from x in oProvisiones.ListaPorCCosto where x.Tipo == "P" select x.Igv).Sum();
                Igv -= IgvAA;

                Decimal Tica = Convert.ToDecimal(txtTipCambio.Text);

                if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                {
                    txtBaseImponible.Text = Decimal.Round(subTotal, 2).ToString("N2");
                    txtBaseSecu.Text = Decimal.Round(subTotal / Tica, 2).ToString("N2");

                    txtExonerado.Text = Decimal.Round(subTotalExo, 2).ToString("N2");
                    txtExoneradoSecu.Text = Decimal.Round(subTotalExo / Tica, 2).ToString("N2");

                    txtImpuesto.Text = Igv.ToString("N2");
                    txtImpuestoSecu.Text = Decimal.Round(Igv / Tica, 2).ToString("N2");

                    txtImporteOrigen.Text = TotalS.ToString("N2");
                }
                else
                {
                    txtBaseSecu.Text = Decimal.Round(subTotal, 2).ToString("N2");
                    txtBaseImponible.Text = Decimal.Round(subTotal * Tica, 2).ToString("N2");

                    txtExoneradoSecu.Text = Decimal.Round(subTotalExo, 2).ToString("N2");
                    txtExonerado.Text = Decimal.Round(subTotalExo * Tica, 2).ToString("N2");

                    txtImpuestoSecu.Text = Igv.ToString("N2");
                    txtImpuesto.Text = Decimal.Round(Igv * Tica, 2).ToString("N2");

                    txtImporteOrigen.Text = TotalD.ToString("N2");
                }

                if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                {
                  //Soles
                  txtTotal.Text = TotalS.ToString("N2");          
                  //Dólares
                  txtTotalSecu.Text = Decimal.Round(TotalS / Tica, 2).ToString("N2");
                }
                else
                {
                  //Soles
                  txtTotal.Text = Decimal.Round(TotalD * Tica, 2).ToString("N2");
                  //Dólares
                  txtTotalSecu.Text = TotalD.ToString("N2");
                }

                txtAjuste.Text = "0.00";
                txtAjusteSecu.Text = "0.00";

                if (chkDetraccion.Checked)
                {
                    CalcularDetraccion();
                }
            }
        }

        Int32 AñadirDias()
        {
            Int32.TryParse(txtNumDiasVen.Text, out Int32 Dias);

            return Dias;
        }

        void BuscarCuenta(ComprobantesFileE FileContabilidad)
        {
            if (FileContabilidad != null)
            {
                if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                {
                    if (!String.IsNullOrEmpty(((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta.codCuentaSoles.Trim()))
                    {
                        txtCodCuenta.Text = ((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta.codCuentaSoles;
                        txtDesCuenta.Text = ((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta.desCuentaSoles;
                    }
                    else
                    {
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
                        Global.MensajeFault("No existe ninguna cuenta en soles en el File escogido.");
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta.codCuentaDolar.Trim()))
                    {
                        txtCodCuenta.Text = ((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta.codCuentaDolar;
                        txtDesCuenta.Text = ((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta.desCuentaDolar;
                    }
                    else
                    {
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
                        Global.MensajeFault("No existe ninguna cuenta en dólares en el File escogido.");
                    }
                }
            }
            else
            {
                txtCodCuenta.Text = String.Empty;
                txtDesCuenta.Text = String.Empty;
                Global.MensajeFault("No existe ninguna cuenta configurada en File escogido.");
            }
        }

        List<CuentaTasaRentaE> ListaCuentasTasas(String Cuenta)
        {
            return AgenteContabilidad.Proxy.ListarCuentaTasaRenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Cuenta, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);
        }

        void CalcularDetraccion()
        {
            if (cbotipodetraccion.SelectedValue != null)
            {
                TasasDetraccionesDetalleE oDetraccion = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem);
                Decimal.TryParse(txtTotal.Text, out Decimal Monto);

                if (oDetraccion != null)
                {
                    if (Monto > oDetraccion.BaseAfecta || oDetraccion.BaseAfecta == 0)
                    {
                        txtTasaDetra.Text = oDetraccion.Porcentaje.ToString("N2");
                        Decimal.TryParse(txtTotal.Text, out Decimal ImporteS);
                        Decimal.TryParse(txtTotalSecu.Text, out Decimal ImporteD);

                        txtMontoDetraS.Text = Decimal.Round((oDetraccion.Porcentaje / 100) * ImporteS, 2).ToString("N2");
                        txtMontoDetraD.Text = Decimal.Round((oDetraccion.Porcentaje / 100) * ImporteD, 2).ToString("N2");
                    }
                    else
                    {
                        txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                        txtMontoDetraS.Text = Variables.ValorCeroDecimal.ToString("N2");
                        txtMontoDetraD.Text = Variables.ValorCeroDecimal.ToString("N2");
                        chkDetraccion.Checked = false;
                        chkDetraccion.Enabled = true;
                        cbotipodetraccion.Enabled = true;
                        cbotipodetraccion.SelectedValue = "0";
                        chkPagoDetra.Checked = false;
                    }
                }
                else
                {
                    txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtMontoDetraS.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtMontoDetraD.Text = Variables.ValorCeroDecimal.ToString("N2");
                    chkDetraccion.Checked = false;
                    chkDetraccion.Enabled = true;
                    cbotipodetraccion.Enabled = true;
                    cbotipodetraccion.SelectedValue = "0";
                    chkPagoDetra.Checked = false;
                }
            }
        }

        void ActualizarDetraccion()
        {
            try
            {
                if (oProvisiones != null)
                {
                    DatosPorGrabar();

                    foreach (Provisiones_PorCCostoE i in oProvisiones.ListaPorCCosto)
                    {
                        i.desGlosa = txtDesProvision.Text;
                    }

                    oProvisiones.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oProvisiones = AgenteCtasPorPagar.Proxy.GrabarProvision(oProvisiones, EnumOpcionGrabar.Actualizar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }

                //base.Grabar();
                //DialogResult = DialogResult.OK;
                //Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void BuscarDocumentoRef()
        {
            try
            {
                String idDocRef = cboReferencia.SelectedValue.ToString();
                String serDocRef = txtSerieRef.Text.Trim();
                String numDocRef = txtNumRef.Text.Trim();
                Int32 idProveedor = Convert.ToInt32(txtIdProveedor.Text.Trim());
                ProvisionesE oReferencia = AgenteCtasPorPagar.Proxy.ObtenerProvisionPorReferencia(VariablesLocales.SesionLocal.IdEmpresa, idProveedor, idDocRef, serDocRef, numDocRef);

                if (oReferencia != null)
                {
                    OrdenCompraE oOrden = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(VariablesLocales.SesionLocal.IdEmpresa, oReferencia.idOrdenCompra.Value);
                    txtOrdenCompra.Tag = Convert.ToInt32(oOrden.idOrdenCompra);
                    txtOrdenCompra.Text = oOrden.numOrdenCompra;

                    ImpuestosPeriodoE oImpuestoIgv = (from x in VariablesLocales.oListaImpuestos where x.idImpuesto == 1 select x).FirstOrDefault();
                    List<ParTabla> oListaBases = new List<ParTabla>(VariablesLocales.oListaBasesImponibles);
                    Provisiones_PorCCostoE detProvision = null;
                    TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia("02", oReferencia.FechaDocumento.ToString("yyyyMMdd"));

                    Decimal nMontoBase = 0, nMontoSecun = 0;

                    txtCodConversion.Text = "0";
                    txtOrdenCompra.Tag = Convert.ToInt32(oOrden.idOrdenCompra);
                    txtOrdenCompra.Text = oOrden.numOrdenCompra;
                    cboPlantilla.SelectedValue = 0;

                    dtpFecRef.Value = Convert.ToDateTime(oReferencia.FechaDocumento);

                    //dtpFecDocumento.Value = Convert.ToDateTime(oOrden.fecEmision);
                    cboMoneda.SelectedValue = oReferencia.CodMonedaProvision.ToString();
                    cboMoneda_SelectionChangeCommitted(new object(), new EventArgs());
                    txtTipCambio.Text = oTica.valVenta.ToString("N3");

                    Decimal Tica = Convert.ToDecimal(txtTipCambio.Text);

                    if (!oOrden.indIngAlm)
                    {
                        if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                        {
                            txtImporteOrigen.Text = oOrden.impTotal.ToString("N2");

                            //Soles
                            txtTotal.Text = oOrden.impTotal.ToString("N2");
                            nMontoBase = oOrden.impVenta;
                            txtBaseImponible.Text = Decimal.Round(nMontoBase, 2).ToString("N2");
                            txtAjuste.Text = "0.00";
                            txtExonerado.Text = "0.00";
                            txtImpuesto.Text = oOrden.impIgv.ToString("N2");

                            //Dólares
                            txtTotalSecu.Text = Convert.ToDecimal(oOrden.impTotal / Tica).ToString("N2");
                            nMontoSecun = oOrden.impVenta / Tica;
                            txtBaseSecu.Text = Decimal.Round(nMontoSecun, 2).ToString("N2");
                            txtAjusteSecu.Text = "0.00";
                            txtExoneradoSecu.Text = "0.00";
                            txtImpuestoSecu.Text = Convert.ToDecimal(oOrden.impIgv / Tica).ToString("N2");

                            txtExonerado.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                            txtExoneradoSecu.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                        }
                        else
                        {
                            txtImporteOrigen.Text = oOrden.impTotal.ToString("N2");

                            //Dólares
                            txtTotalSecu.Text = Convert.ToDecimal(oOrden.impTotal).ToString("N2");
                            nMontoSecun = oOrden.impVenta;
                            txtBaseSecu.Text = Decimal.Round(nMontoSecun, 2).ToString("N2");
                            txtAjusteSecu.Text = "0.00";
                            txtExoneradoSecu.Text = "0.00";
                            txtImpuestoSecu.Text = Convert.ToDecimal(oOrden.impIgv).ToString("N2");

                            //Soles
                            txtTotal.Text = Convert.ToDecimal(oOrden.impTotal * Tica).ToString("N2");
                            nMontoBase = oOrden.impVenta * Tica;
                            txtBaseImponible.Text = Decimal.Round(nMontoBase, 2).ToString("N2");
                            txtAjuste.Text = "0.00";
                            txtExonerado.Text = "0.00";
                            txtImpuesto.Text = Convert.ToDecimal(oOrden.impIgv * Tica).ToString("N2");

                            txtExonerado.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                            txtExoneradoSecu.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        }

                        txtDesEstado.Text = "POR REGISTRAR";
                        txtDesProvision.Text = oOrden.Observacion;

                        string codCuenta = oOrden.ListaOrdenesCompras[0].codCuenta;
                        Decimal impSoles = 0; Decimal impDolares = 0; Decimal MontoCuenta = 0;

                        if (oOrden.indDistribucion)
                        {
                            #region Con Distribución

                            Int32 idArticulo = oOrden.ListaOrdenesCompras[0].idArticuloServ;
                            String codArticulo = oOrden.ListaOrdenesCompras[0].codArticulo;
                            String desArticulo = oOrden.ListaOrdenesCompras[0].desArticulo;
                            Int32 Corre = 1;
                            Decimal Impuesto = Convert.ToDecimal(VariablesLocales.oListaImpuestos[0].Porcentaje) / 100;

                            foreach (OrdenCompraDistriE item in oOrden.ListaDistribucion)
                            {
                                detProvision = new Provisiones_PorCCostoE();
                                impSoles = 0;
                                impDolares = 0;
                                MontoCuenta = 0;

                                detProvision.idEmpresa = item.idEmpresa;
                                detProvision.idLocal = VariablesLocales.SesionLocal.IdLocal;
                                detProvision.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                                detProvision.idItem = Corre;
                                detProvision.idArticulo = idArticulo;
                                detProvision.Codigo = codArticulo;
                                detProvision.Descripcion = desArticulo;
                                detProvision.Cantidad = 1;
                                detProvision.PrecioUnitario = Convert.ToDecimal(item.Monto);
                                detProvision.codCuenta = item.codCuenta;
                                detProvision.DesCuenta = item.desCuenta;
                                detProvision.indCCostos = Variables.SI;
                                detProvision.idCCostos = item.idCCostos;
                                detProvision.DesCCosto = item.desCCostos;
                                detProvision.idMoneda = cboMoneda.SelectedValue.ToString();
                                detProvision.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                                detProvision.tipCambio = Convert.ToDecimal(txtTipCambio.Text);
                                detProvision.indCambio = chkIndCalcAuto.Checked;

                                if (detProvision.idMoneda == Variables.Soles)
                                {
                                    impSoles += Decimal.Round(item.Monto.Value + (item.Monto.Value * Impuesto), 2);
                                    impDolares += Decimal.Round((item.Monto.Value + (item.Monto.Value * Impuesto)) / Tica, 2);
                                    MontoCuenta += Decimal.Round(item.Monto.Value + (item.Monto.Value * Impuesto), 2);
                                }
                                else
                                {
                                    MontoCuenta += Decimal.Round(item.Monto.Value + (item.Monto.Value * Impuesto), 2);
                                    impSoles += Decimal.Round((item.Monto.Value + (item.Monto.Value * Impuesto)) * Tica, 2);
                                    impDolares += Decimal.Round(item.Monto.Value + (item.Monto.Value * Impuesto), 2);
                                }

                                detProvision.Igv = item.Monto.Value * Impuesto;
                                detProvision.subTotal = item.Monto.Value;
                                detProvision.desGlosa = txtDesProvision.Text;
                                detProvision.indIgv = true;

                                if (detProvision.indIgv)
                                {
                                    detProvision.codColumnaCoven = Convert.ToInt32(oListaBases.Where(w => w.NemoTecnico == "BAIMP").Select(x => x.IdParTabla).SingleOrDefault());
                                    detProvision.DesColumnaCoven = Convert.ToString(oListaBases.Where(w => w.NemoTecnico == "BAIMP").Select(x => x.Descripcion).SingleOrDefault());
                                }
                                else
                                {
                                    detProvision.codColumnaCoven = Convert.ToInt32(oListaBases.Where(w => w.NemoTecnico == "BAINA").Select(x => x.IdParTabla).SingleOrDefault());
                                    detProvision.DesColumnaCoven = Convert.ToString(oListaBases.Where(w => w.NemoTecnico == "BAINA").Select(x => x.Descripcion).SingleOrDefault());
                                }

                                detProvision.Tipo = "A";
                                detProvision.Calculo = "A";

                                detProvision.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                detProvision.FechaRegistro = VariablesLocales.FechaHoy;
                                detProvision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                detProvision.FechaModificacion = VariablesLocales.FechaHoy;

                                detProvision.MontoCuenta = MontoCuenta;
                                detProvision.impSoles = impSoles;
                                detProvision.impDolares = impDolares;
                                oProvisiones.ListaPorCCosto.Add(detProvision);

                                Corre++;
                            }

                            #endregion
                        }
                        else
                        {
                            #region Sin Distribución

                            oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>();

                            foreach (OrdenCompraItemE item in oOrden.ListaOrdenesCompras)//(from x in oOrden.ListaOrdenesCompras where x.CanOrdenada != x.canProvisionada select x).ToList())
                            {
                                detProvision = new Provisiones_PorCCostoE()
                                {
                                    idEmpresa = item.idEmpresa,
                                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                                    idItem = Convert.ToInt32(item.idItem),
                                    idArticulo = item.idArticuloServ,
                                    Codigo = item.codArticulo,
                                    Descripcion = item.desArticulo,
                                    Cantidad = item.CanOrdenada,
                                    PrecioUnitario = item.impPrecioUnitario,
                                    numVerPlanCuentas = item.numVerPlanCuentas,

                                    codCuenta = item.codCuenta,
                                    DesCuenta = item.desCuenta,
                                    idMoneda = cboMoneda.SelectedValue.ToString(),
                                    desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura,
                                    tipCambio = Convert.ToDecimal(txtTipCambio.Text),
                                    indCambio = chkIndCalcAuto.Checked,
                                    idCCostos = oOrden.idCCostos,
                                    DesCCosto = oOrden.desCCostos,
                                    desGlosa = txtDesProvision.Text,
                                    indIgv = item.indIgv,
                                    Igv = item.impIgv,
                                    porIgv = item.porIgv,
                                    subTotal = item.impVentaItem
                                };

                                if (item.canProvisionada > 0)
                                {
                                    detProvision.subTotal = detProvision.Cantidad * item.impPrecioUnitario;

                                    if (item.indIgv)
                                    {
                                        detProvision.Igv = detProvision.subTotal * (item.porIgv / 100);
                                    }

                                    detProvision.subTotal = detProvision.Cantidad * item.impPrecioUnitario;
                                    item.impTotalItem = detProvision.subTotal + detProvision.Igv;
                                }

                                if (detProvision.idMoneda == Variables.Soles)
                                {
                                    impSoles = Decimal.Round(item.impTotalItem, 2);
                                    impDolares = Decimal.Round(item.impTotalItem / Tica, 2);
                                    MontoCuenta = Decimal.Round(item.impTotalItem, 2);
                                }
                                else
                                {
                                    MontoCuenta = Decimal.Round(item.impTotalItem, 2);
                                    impSoles = Decimal.Round(item.impTotalItem * Tica, 2);
                                    impDolares = Decimal.Round(item.impTotalItem, 2);
                                }

                                if (detProvision.indIgv)
                                {
                                    detProvision.codColumnaCoven = Convert.ToInt32(oListaBases.Where(w => w.NemoTecnico == "BAIMP").Select(x => x.IdParTabla).SingleOrDefault());
                                    detProvision.DesColumnaCoven = Convert.ToString(oListaBases.Where(w => w.NemoTecnico == "BAIMP").Select(x => x.Descripcion).SingleOrDefault()); //"BASE IMPONIBLE";
                                }
                                else
                                {
                                    detProvision.codColumnaCoven = Convert.ToInt32(oListaBases.Where(w => w.NemoTecnico == "BAINA").Select(x => x.IdParTabla).SingleOrDefault());
                                    detProvision.DesColumnaCoven = Convert.ToString(oListaBases.Where(w => w.NemoTecnico == "BAINA").Select(x => x.Descripcion).SingleOrDefault());
                                }

                                detProvision.Tipo = "A";
                                detProvision.Calculo = "A";
                                detProvision.indCCostos = item.indCCostos;

                                if (detProvision.indCCostos == Variables.NO)
                                {
                                    detProvision.idCCostos = String.Empty;
                                    detProvision.DesCCosto = String.Empty;
                                }

                                detProvision.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                detProvision.FechaRegistro = VariablesLocales.FechaHoy;
                                detProvision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                detProvision.FechaModificacion = VariablesLocales.FechaHoy;

                                detProvision.MontoCuenta = MontoCuenta;
                                detProvision.impSoles = impSoles;
                                detProvision.impDolares = impDolares;

                                oProvisiones.ListaPorCCosto.Add(detProvision);

                                codCuenta = item.codCuenta;
                            }

                            #endregion
                        }
                    }

                    Calcular();
                    bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                    bsprovisionesccosto.ResetBindings(false);

                    dgvprovisionesccosto.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        void BotonesDetalle()
        {
            if (Convert.ToInt32(cboAnticipos.SelectedValue) == 0)
            {
                btActivos.Enabled = true;
                btServicios.Enabled = true;
                btArticulos.Enabled = true;
                btAnticipos.Enabled = false;
            }
            else if (Convert.ToInt32(cboAnticipos.SelectedValue) == 1)
            {
                btActivos.Enabled = false;
                btServicios.Enabled = false;
                btArticulos.Enabled = false;
                btAnticipos.Enabled = false;
            }
            else
            {
                btActivos.Enabled = true;
                btServicios.Enabled = true;
                btArticulos.Enabled = true;
                btAnticipos.Enabled = true;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oProvisiones != null)
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
                txtCodPartida.TextChanged -= txtCodPartida_TextChanged;
                chkDetraccion.CheckedChanged -= chkDetraccion_CheckedChanged;

                txtIdProvision.Text = oProvisiones.idProvision.ToString("0000000");
                txtIdProveedor.Text = oProvisiones.idPersona.ToString();
                txtRuc.Text = oProvisiones.Ruc;
                txtRazonSocial.Text = oProvisiones.RazonSocial;
                dtpFechaProvision.Value = oProvisiones.FechaProvision;
                txtDesEstado.Text = oProvisiones.DesEstado;
                dtpFecDocumento.Value = oProvisiones.FechaDocumento;
                LlenarComboDetraccion(oProvisiones.FechaDocumento); //Llenando si es que hubiese detracción
                txtNumDiasVen.Text = oProvisiones.NumDiasVen.ToString();
                dtpFecVencimiento.Value = oProvisiones.FechaVencimiento.Value;
                cboDocumento.SelectedValue = oProvisiones.idDocumento.ToString();
                cboDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                txtSerie.Text = oProvisiones.NumSerie;
                txtNumero.Text = oProvisiones.NumDocumento;
                cboReferencia.SelectedValue = String.IsNullOrWhiteSpace(oProvisiones.idDocumentoRef) ? "0" : oProvisiones.idDocumentoRef.ToString();
                txtSerieRef.Text = oProvisiones.numSerieRef;
                txtNumRef.Text = oProvisiones.numDocumentoRef;
                dtpFecRef.Value = Convert.ToDateTime(oProvisiones.fecDocumentoRef);
                cboAfectacionAlmacen.SelectedValue = Convert.ToInt32(oProvisiones.indAfectacionAlmacen);
                cboMoneda.SelectedValue = oProvisiones.CodMonedaProvision.ToString();
                txtImporteOrigen.Text = oProvisiones.ImpMonedaOrigen.ToString("N2");
                cboTipoAsiento.SelectedValue = oProvisiones.numFile;
                txtTipCambio.Text = oProvisiones.TipCambio.ToString();
                chkIndCalcAuto.Checked = oProvisiones.IndCalcAuto;
                txtTotal.Text = oProvisiones.impTotalBase.ToString("N2");
                txtBaseImponible.Text = oProvisiones.impImponBase.ToString("N2");
                txtExonerado.Text = oProvisiones.impExonBase.ToString("N2");
                txtAjuste.Text = oProvisiones.impAjusteBase.ToString("N2");
                txtImpuesto.Text = oProvisiones.impImpuestoBase.ToString("N2");
                txtTotalSecu.Text = oProvisiones.impTotalSecun.ToString("N2");
                txtBaseSecu.Text = oProvisiones.impImponSecun.ToString("N2");
                txtExoneradoSecu.Text = oProvisiones.impExonSecun.ToString("N2");
                txtAjusteSecu.Text = oProvisiones.impAjusteSecun.ToString("N2");
                txtImpuestoSecu.Text = oProvisiones.impImpuestoSecun.ToString("N2");
                txtCodCuenta.Text = oProvisiones.codCuenta;
                txtDesCuenta.Text = oProvisiones.DesCuenta;
                txtDesProvision.Text = oProvisiones.DesProvision;
                txtCodConversion.Text = oProvisiones.idRecepcion == 0 ? string.Empty : oProvisiones.idRecepcion.ToString();
                txtOrdenCompra.Tag = Convert.ToInt32(oProvisiones.idOrdenCompra);
                txtOrdenCompra.Text = oProvisiones.numOrdenCompra.Trim();
                txtGuia.Text = oProvisiones.NumGuia;
                cboPlantilla.SelectedValue = Convert.ToInt32(oProvisiones.idPlantilla);
                chkDetraccion.Checked = oProvisiones.flagDetraccion;

                if (chkDetraccion.Checked)
                {
                    txtNumDetraccion.Text = oProvisiones.retNumero;
                    dtpFecRetencion.Value = oProvisiones.retFecha.Value;
                    cbotipodetraccion.SelectedValue = oProvisiones.TipoDetraccion.ToString();
                    txtTasaDetra.Text = oProvisiones.TasaDetraccion.ToString("N2");
                    txtMontoDetraS.Text = oProvisiones.MontoDetraccion.ToString("N2");
                    chkPagoDetra.Checked = oProvisiones.indPagoDetra;

                    if (txtMontoDetraD.Text == "0.00")
                    {
                        CalcularDetraccion();
                    }

                    txtNumDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    dtpFecRetencion.Enabled = true;
                    cbotipodetraccion.Enabled = true;
                    chkPagoDetra.Enabled = true;
                }
                else
                {
                    txtNumDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    dtpFecRetencion.Enabled = false;
                    cbotipodetraccion.Enabled = false;
                    chkPagoDetra.Checked = false;
                    chkPagoDetra.Enabled = false;
                }

                cboTipoAsiento.SelectedValue = oProvisiones.idCompraFile;
                chkIndCosto.Checked = oProvisiones.indHojaCosto;
                txtNumHojaCosto.Text = oProvisiones.indHojaCosto ? oProvisiones.idHojaCosto.ToString() : String.Empty;
                chkIndDistribucion.Checked = oProvisiones.indDistribucion;
                txtCodPartida.Tag = oProvisiones.tipPartidaPresu;
                txtCodPartida.Text = oProvisiones.CodPartidaPresu;
                txtDesPartida.Text = oProvisiones.desPartidaPresu;

                //Conversion
                chkConversion.Checked = oProvisiones.indConversion;

                if (chkConversion.Checked)
                {
                    txtCodConversion.Tag = oProvisiones.idOrdenConversion;
                    txtCodConversion.Text = oProvisiones.codOrdenConversion;
                }
                else
                {
                    txtCodConversion.Tag = 0;
                }

                /********************** Datos No Domicialiado *************************/
                chkIgvNoDom.CheckedChanged -= chkIgvNoDom_CheckedChanged;
                txtCuentaRenta.TextChanged -= txtCuentaRenta_TextChanged;
                txtDesCuentaRenta.TextChanged -= txtDesCuentaRenta_TextChanged;

                chkindNoDom.Checked = oProvisiones.indNoDom;
                cboDocCreditoFiscal.SelectedValue = String.IsNullOrWhiteSpace(oProvisiones.idDocCredFiscal) ? "0" : oProvisiones.idDocCredFiscal.ToString();
                cboDependencia.SelectedValue = oProvisiones.depAduanera;
                txtSerieCredFiscal.Text = oProvisiones.serDocCredFiscal;
                txtAnioDua.Text = oProvisiones.AnioDua;
                txtNumDua.Text = oProvisiones.numDocCredFiscal;
                txtRentaBruta.Text = oProvisiones.RentaBruta.ToString("N2");
                txtTasaRetencion.Text = oProvisiones.TasaRetencion.ToString("N2");
                txtRentaNeta.Text = oProvisiones.RentaNeta.ToString("N2");
                txtImpuestoRete.Text = oProvisiones.impRetenido.ToString("N2");
                txtCuentaRenta.Text = oProvisiones.codCuentaRenta;
                txtDesCuentaRenta.Text = oProvisiones.desCuentaRenta;

                if (!String.IsNullOrWhiteSpace(oProvisiones.codCuentaRenta.Trim()))
                {
                    List<CuentaTasaRentaE> oLista = ListaCuentasTasas(txtCuentaRenta.Text.Trim());

                    if (oLista.Count > 0)
                    {
                        cboTasa.DataSource = oLista;
                        cboTasa.ValueMember = "idTasaRenta";
                        cboTasa.DisplayMember = "desTasaRenta";

                        cboTasa.SelectedValue = oProvisiones.idTasaRenta.ToString();
                    }
                }
                
                chkIgvNoDom.Checked = oProvisiones.indIgvNoDom;
                txtIgvNoDom.Text = oProvisiones.IgvNoDom.ToString("N2");

                chkIgvNoDom.CheckedChanged += chkIgvNoDom_CheckedChanged;
                txtCuentaRenta.TextChanged += txtCuentaRenta_TextChanged;
                txtDesCuentaRenta.TextChanged += txtDesCuentaRenta_TextChanged;
                /**********************************************************************/

                chkIndReversion.Checked = oProvisiones.indReversion;
                txtIdReversion.Text = oProvisiones.idProvisionRev != null ? oProvisiones.idProvisionRev.ToString() : String.Empty;
                cboAnticipos.SelectedValue = oProvisiones.EsAnticipo;

                if (!BloqueoTotal)
                {
                    BotonesDetalle();
                }

                txtUsuRegistro.Text = oProvisiones.UsuarioRegistro;
                txtFechaRegistro.Text = oProvisiones.FechaRegistro.ToString();
                txtUsuModificacion.Text = oProvisiones.UsuarioModificacion;
                txtFechaModificacion.Text = oProvisiones.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
                txtCodPartida.TextChanged += txtCodPartida_TextChanged;
                chkDetraccion.CheckedChanged += chkDetraccion_CheckedChanged;
            }
            else
            {
                oProvisiones = new ProvisionesE()
                {
                    idEmpresa = VariablesLocales.SesionLocal.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    EstadoProvision = "RE",
                    indReparable = "N",
                    idConceptoRep = 0,
                    desReferenciaRep = String.Empty,
                    idSistema = 5, //Módulo de Compras
                    EsLiquidacion = false,
                    EsRendicion = false
                };

                dtpFecDocumento.Value = VariablesLocales.FechaHoy.Date;
                //LlenarComboDetraccion(dtpFecDocumento.Value.Date);
                dtpFechaProvision.Value = VariablesLocales.FechaHoy.Date;
                txtNumDiasVen.Text = "0";

                cboDocumento.SelectedValue = EnumTipoDocumentoVenta.FC.ToString();
                cboDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                cboMoneda_SelectionChangeCommitted(new object(), new EventArgs());

                cboDocCreditoFiscal.SelectedValue = "0";

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }

            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
            bsprovisionesccosto.ResetBindings(false);
            dgvprovisionesccosto.AutoResizeColumns();

            if (oProvisiones.EstadoProvision == "PR" || oProvisiones.EstadoProvision == "AN" || oProvisiones.EstadoProvision == "LI")
            {
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
            else
            {
                base.Nuevo();

                btArticulos.Enabled = false;
                btGastos.Enabled = false;
                btServicios.Enabled = false;
                btActivos.Enabled = false;
                btAnticipos.Enabled = false;
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (tProvision.SelectedTab == tpDetalle)
                {
                    frmProvisionCosto oFrm = new frmProvisionCosto();

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                    {
                        Provisiones_PorCCostoE ItemDet = oFrm.Detalle;
                        List<Provisiones_PorCCostoE> ListaItems = (List<Provisiones_PorCCostoE>)bsprovisionesccosto.List;
                        Int32 Item;

                        if (ListaItems.Count == Variables.Cero)
                        {
                            Item = Variables.ValorUno;
                        }
                        else
                        {
                            Item = Convert.ToInt32(ListaItems.Max(mx => mx.idItem)) + 1;
                        }

                        ItemDet.idItem = Item;
                        ListaItems.Add(ItemDet);
                        bsprovisionesccosto.DataSource = ListaItems;
                        bsprovisionesccosto.ResetBindings(false);

                        base.AgregarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (tProvision.SelectedTab == tpDetalle)
                {
                    if (bsprovisionesccosto.Current != null)
                    {
                        if (oProvisiones.ListaPorCCosto != null && oProvisiones.ListaPorCCosto.Count > Variables.Cero)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                            {
                                return;
                            }

                            bsprovisionesccosto.EndEdit();

                            oProvisiones.ListaPorCCosto.RemoveAt(bsprovisionesccosto.Position);
                            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                            bsprovisionesccosto.ResetBindings(false);

                            base.QuitarDetalle();
                        }
                    }
                }
               
                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oProvisiones.AnioPeriodo, oProvisiones.MesPeriodo);

            if (oPeriodoContable.indCierre)
            {
                Global.MensajeComunicacion("El mes Contable se encuentra cerrado. No podra ingresar Documento con esta fecha.");
                return false;
            }

            oCierreSistema = AgenteContabilidad.Proxy.ObtenerCierreSistema(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oProvisiones.AnioPeriodo, oProvisiones.MesPeriodo, 5);

            if (oCierreSistema != null)
            {
                if (oCierreSistema.indCierre)
                {
                    if (oProvisiones.FechaProvision <= oCierreSistema.FechaCierre)
                    {
                        Global.MensajeComunicacion("El sistema de Compras a esa fecha se encuentra cerrado");
                        return false;
                    }
                }
            }

            if (!chkDetraccion.Checked)
            {
                oProvisiones.retNumero = "";
                oProvisiones.TipoDetraccion = null;
                oProvisiones.TasaDetraccion = 0;
                oProvisiones.MontoDetraccion = 0;
                oProvisiones.retFecha = null;
            }

            String respuesta = ValidarEntidad<ProvisionesE>(oProvisiones);

            if (!String.IsNullOrEmpty(respuesta))
            {
                Global.MensajeComunicacion(respuesta);
                return false;
            }

            if (String.IsNullOrEmpty(txtIdProveedor.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar un proveedor.");
                txtRuc.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtCodCuenta.Text.Trim()))
            {
                Global.MensajeComunicacion("Antes de guardar se debe escoger un File que tenga cuenta o falta configurar las cuentas en Diarios-Files.");
                cboTipoAsiento.Focus();
                return false;
            }

            if (chkIndCosto.Checked)
            {
                if (String.IsNullOrEmpty(txtNumHojaCosto.Text.Trim()))
                {
                    Global.MensajeComunicacion("El check de la hoja de Costo esta habilitado, debe ingresar un N° de Hoja de Costo.");
                    return false;
                }
            }

            if (chkConversion.Checked)
            {
                if (Convert.ToInt32(txtCodConversion.Tag) == 0)
                {
                    Global.MensajeComunicacion("El check de la hoja de Conversión esta habilitado, debe ingresar un N° de Conversión.");
                    return false;
                }
            }

            if (bsprovisionesccosto.List.Count > 0)
            {
                foreach (Provisiones_PorCCostoE item in bsprovisionesccosto.List)
                {
                    if (item.indCCostos == Variables.SI)
                    {
                        if (String.IsNullOrWhiteSpace(item.indCCostos))
                        {
                            Global.MensajeComunicacion(String.Format("El item {0} necesita Centro de Costos. Verifique", item.idItem.ToString()));
                            return false;
                        }
                    }
                }
            }

            if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
            {
                if (cboReferencia.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    Global.MensajeFault("El documento escogido esta obligado a tener un documento de referencia.");
                    return false;
                }

                if (String.IsNullOrEmpty(txtSerieRef.Text) && String.IsNullOrEmpty(txtNumRef.Text))
                {
                    Global.MensajeFault("El documento de referencia tiene que tener un N° de documento de referencia.");
                    return false;
                }

                if (txtTipCambio.Text == "0.000")
                {
                    Global.MensajeFault("No hay tipo de cambio para la fecha de referencia, debe colocarlo.");
                    return false;
                }
            }

            if (((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "01" || ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "03" ||
                ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "07" || ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "08" )
            {
                if (String.IsNullOrWhiteSpace(txtSerie.Text))
                {
                    Global.MensajeFault("Debe ingresar la serie del documento antes de grabar la Compra.");
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(txtNumero.Text))
            {
                Global.MensajeFault("Debe ingresar el número del documento antes de grabar la Compra.");
                return false;
            }

            if (VariablesLocales.oComprasParametros != null)
            {
                if (VariablesLocales.oComprasParametros.indPartPresupuestal)
                {
                    if (String.IsNullOrWhiteSpace(txtCodPartida.Text.Trim()))
                    {
                        Global.MensajeFault("Debe colocar la Partida Presupuestal.");
                        btPresupuesto.Focus();
                        return false;
                    }
                }
            }

            if (Convert.ToInt32(cboAnticipos.SelectedValue) == 1)
            {
                foreach (Provisiones_PorCCostoE item in bsprovisionesccosto.List)
                {
                    if (item.Tipo != "N")
                    {
                        Global.MensajeComunicacion("Solamente se puede colocar Anticipos.");
                        return false;
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        public override void Grabar()
        {
            try
            {
                if (dgvprovisionesccosto.IsCurrentCellDirty)
                {
                    dgvprovisionesccosto.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                bsprovisionesccosto.EndEdit();

                if (oProvisiones.ListaPorCCosto.Count == 0 && ingAlmacen)
                {
                    Global.MensajeComunicacion("El documento de recepción tiene habilitado el check de Cruzar C/Almacén, necesita ingreso al almacén antes de grabar o actualizar.");
                    return;
                }
              
                if (oProvisiones != null)
                {
                    DatosPorGrabar();

                    if (!ValidarGrabacion()) { return; }

                    foreach(Provisiones_PorCCostoE i in oProvisiones.ListaPorCCosto)
                    {
                        i.desGlosa = txtDesProvision.Text;
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) != DialogResult.Yes) { return; }
                        oProvisiones = AgenteCtasPorPagar.Proxy.GrabarProvision(oProvisiones, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) != DialogResult.Yes) { return; }
                        oProvisiones.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oProvisiones = AgenteCtasPorPagar.Proxy.GrabarProvision(oProvisiones, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmProvisiones_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                LlenarCombo();
                Nuevo();

                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                {
                    dgvprovisionesccosto.Columns["codCuenta"].Visible = true;
                }

                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);

                VariablesLocales.EsLiquidacion = Variables.NO;
                chkPagoDetra.Text = VariablesLocales.SesionUsuario.Empresa.NombreComercial + " Paga Detracción";

                if (RevisionDetra && oProvisiones.EstadoProvision == "PR")
                {
                    ActualizarDetraccion();
                }

                if (VariablesLocales.oComprasParametros != null)
                {
                    if (VariablesLocales.oComprasParametros.indPartPresupuestal)
                    {
                        txtCodPartida.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        btPresupuesto.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BuscarCuenta(((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
        
        private void txtCodCuenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                        VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                        txtCodCuenta.Text,
                                                                                                                        VariablesLocales.VersionPlanCuentasActual.Longitud, 1);

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && !string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    List<PlanCuentasE> oListaCuentas = AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuenta.Text,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.Longitud, 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecDocumento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumento.SelectedValue.ToString() != "97" && cboDocumento.SelectedValue.ToString() != "98" && cboDocumento.SelectedValue.ToString() != "CR" &&
                    cboDocumento.SelectedValue.ToString() != "DR" && cboDocumento.SelectedValue.ToString() != "NC" && cboDocumento.SelectedValue.ToString() != "ND")
                {
                    DateTime Fecha = ((DateTimePicker)sender).Value;
                    TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));

                    if (Tica != null)
                    {
                        txtTipCambio.Text = Decimal.Round(Tica.valVenta, 3).ToString();
                        Calcular();
                    }
                    else
                    {
                        txtTipCambio.Text = "0.000";
                        dtpFecDocumento.Focus();
                        Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                    } 
                }

                if (txtNumDiasVen.Text == "0" || string.IsNullOrEmpty(txtNumDiasVen.Text.Trim()))
                {
                    dtpFecVencimiento.Value = dtpFecDocumento.Value;
                }
                else
                {
                    Int32 Dias = AñadirDias();

                    if (Dias != 0)
                    {
                        dtpFecVencimiento.Value = dtpFecDocumento.Value.Date.AddDays(Dias);
                    }
                    else
                    {
                        dtpFecVencimiento.Value = dtpFecDocumento.Value;
                    }
                }

                LlenarComboDetraccion(dtpFecDocumento.Value.Date);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIndCalcAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndCalcAuto.Checked)
            {
                txtTipCambio.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
            else
            {
                txtTipCambio.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRuc.Text.Trim()) && string.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Text = String.Empty;
            txtIdProveedor.Text = String.Empty;
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = string.Empty;
            txtRuc.Text = string.Empty;
        }

        private void chkDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDetraccion.Checked)
            {
                txtNumDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                dtpFecRetencion.Enabled = true;
                cbotipodetraccion.Enabled = true;
                chkPagoDetra.Enabled = true;
                chkPagoDetra.Checked = true;
            }
            else
            {
                txtNumDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                dtpFecRetencion.Enabled = false;
                cbotipodetraccion.Enabled = false;
                chkPagoDetra.Checked = false;
                chkPagoDetra.Enabled = false;
            }

            if (cbotipodetraccion.SelectedValue == null)
            {
                chkDetraccion.Checked = false;
            }
        }

        private void btArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipCambio.Text == "0.000")
                {
                    Global.MensajeComunicacion("Debe buscar un dia que tenga Tipo de Cambio.");
                    return;
                }

                Int32 Columna = 0;

                if (cboTipoAsiento.SelectedValue != null)
                {
                    Columna = Convert.ToInt32(((ComprasFileE)cboTipoAsiento.SelectedItem).codColumnaCoven);
                }

                //Boleta de Venta Recibida
                Int32 col = VariablesLocales.DevolverBase(cboDocumento.SelectedValue.ToString());

                if (col != 0)
                {
                    Columna = col;
                }

                frmProvisionCosto oFrm = new frmProvisionCosto(dtpFecDocumento.Value, Columna, cboMoneda.SelectedValue.ToString(), chkIndDistribucion.Checked);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                {
                    Provisiones_PorCCostoE ItemDet = oFrm.Detalle;
                    List<Provisiones_PorCCostoE> ListaItems = (List<Provisiones_PorCCostoE>)bsprovisionesccosto.List;
                    Int32 Item;

                    if (ListaItems.Count == Variables.Cero)
                    {
                        Item = Variables.ValorUno;
                    }
                    else
                    {
                        Item = Convert.ToInt32(ListaItems.Max(mx => mx.idItem)) + 1;
                    }

                    ItemDet.idItem = Item;
                    ListaItems.Add(ItemDet);
                    bsprovisionesccosto.DataSource = ListaItems;
                    bsprovisionesccosto.ResetBindings(false);

                    //Detracción...
                    if (oFrm.oArticulo != null && oFrm.oArticulo.indDetraccion && oFrm.oArticulo.tipDetraccion != "0")
                    {
                        chkDetraccion.Checked = oFrm.oArticulo.indDetraccion;

                        if (chkDetraccion.Checked)
                        {
                            if (oProvisiones.ListaPorCCosto.Count == 0)
                            {
                                cbotipodetraccion.SelectedValue = oFrm.oArticulo.tipDetraccion.ToString();
                                txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                            }
                            else
                            {
                                Decimal.TryParse(txtMontoDetraS.Text, out Decimal Monto);

                                if (Monto > 0)
                                {
                                    if (Global.MensajeConfirmacion("La compra ya tiene asignada una detracción, desea reemplazarla que trae el Concepto.", MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                    {
                                        cbotipodetraccion.SelectedValue = oFrm.oArticulo.tipDetraccion.ToString();
                                        txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                                    }
                                }
                                else
                                {
                                    cbotipodetraccion.SelectedValue = oFrm.oArticulo.tipDetraccion.ToString();
                                    txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                                }
                            }
                        }
                    }

                    Calcular();

                    if (chkindNoDom.Checked)
                    {
                        txtRentaBruta.Text = txtImporteOrigen.Text;
                        txtRentaNeta.Text = txtImporteOrigen.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btGastos_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                A = Articulo
                G = Gasto
                S = Servicio
                C = Activo
                N = Anticipo
                */

                if (txtTipCambio.Text == "0.000")
                {
                    Global.MensajeComunicacion("Debe buscar un dia que tenga Tipo de Cambio.");
                    return;
                }

                ParTabla oGasto = AgenteGeneral.Proxy.ParTablaPorNemo("TCGAS");

                if (oGasto != null)
                {
                    Int32 Columna = 0;

                    if (cboTipoAsiento.SelectedValue != null)
                    {
                        Columna = Convert.ToInt32(((ComprasFileE)cboTipoAsiento.SelectedItem).codColumnaCoven);
                    }

                    //Boleta de Venta Recibida
                    Int32 col = VariablesLocales.DevolverBase(cboDocumento.SelectedValue.ToString());

                    if (col != 0)
                    {
                        Columna = col;
                    }

                    frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(oGasto.IdParTabla, dtpFecDocumento.Value, "G", Columna, 
                                                                                        cboMoneda.SelectedValue.ToString(), chkIndDistribucion.Checked, "N", "", Convert.ToInt32(cboAnticipos.SelectedValue));

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        if (oFrm.oProvisionCompra != null)
                        {
                            Provisiones_PorCCostoE ItemDet = oFrm.oProvisionCompra;
                            List<Provisiones_PorCCostoE> ListaItems = (List<Provisiones_PorCCostoE>)bsprovisionesccosto.List;
                            Int32 Item;

                            if (ListaItems.Count == Variables.Cero)
                            {
                                Item = Variables.ValorUno;
                            }
                            else
                            {
                                Item = Convert.ToInt32(ListaItems.Max(mx => mx.idItem)) + 1;
                            }

                            ItemDet.idItem = Item;
                            txtDesProvision.Text = ItemDet.Descripcion.Trim();
                            ListaItems.Add(ItemDet);
                            bsprovisionesccosto.DataSource = ListaItems;
                            bsprovisionesccosto.ResetBindings(false);

                            if (chkindNoDom.Checked)
                            {
                                txtRentaBruta.Text = txtImporteOrigen.Text;
                                txtRentaNeta.Text = txtImporteOrigen.Text;
                            }
                        }

                        if (oFrm.oListaCompras != null && oFrm.oListaCompras.Count > 0)
                        {
                            oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>(oFrm.oListaCompras);
                            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                            bsprovisionesccosto.ResetBindings(false);

                            if (chkindNoDom.Checked)
                            {
                                txtRentaBruta.Text = txtImporteOrigen.Text;
                                txtRentaNeta.Text = txtImporteOrigen.Text;
                            }
                        }

                        if (oFrm.oConcepto != null && oFrm.oConcepto.indDetraccion && oFrm.oConcepto.idTipoDetraccion != "0")
                        {
                            if (!chkDetraccion.Checked)
                            {
                                chkDetraccion.Checked = true;
                                chkDetraccion.Enabled = false;
                                cbotipodetraccion.Enabled = false;
                                cbotipodetraccion.SelectedValue = oFrm.oConcepto.idTipoDetraccion.ToString();
                                txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                            }
                            else
                            {
                                if (Global.MensajeConfirmacion(String.Format("La compra ya tiene asignada una detracción, desea reemplazarla por la detracción que trae el Concepto({0}) agregado.", oFrm.oConcepto.porImpuesto.ToString("N2") + "%"), MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    cbotipodetraccion.SelectedValue = oFrm.oConcepto.idTipoDetraccion.ToString();
                                    txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                                }
                            }
                        }

                        Calcular();
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Falta configurar el parámetro de Gastos en Parámetros Generales");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btServicios_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                A = Articulo
                G = Gasto
                S = Servicio
                C = Activo
                */

                if (txtTipCambio.Text == "0.000")
                {
                    Global.MensajeComunicacion("Debe buscar un dia que tenga Tipo de Cambio.");
                    return;
                }

                ParTabla oGasto = AgenteGeneral.Proxy.ParTablaPorNemo("TCSER");

                if (oGasto != null)
                {
                    Int32 Columna = 0;

                    if (cboTipoAsiento.SelectedValue != null)
                    {
                        Columna = Convert.ToInt32(((ComprasFileE)cboTipoAsiento.SelectedItem).codColumnaCoven);
                    }

                    //Boleta de Venta Recibida
                    Int32 col = VariablesLocales.DevolverBase(cboDocumento.SelectedValue.ToString());

                    if (col != 0)
                    {
                        Columna = col;
                    }

                    frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(oGasto.IdParTabla, dtpFecDocumento.Value, "S", Columna, cboMoneda.SelectedValue.ToString(), chkIndDistribucion.Checked);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        if (oFrm.oProvisionCompra != null)
                        {
                            Provisiones_PorCCostoE ItemDet = oFrm.oProvisionCompra;
                            List<Provisiones_PorCCostoE> ListaItems = (List<Provisiones_PorCCostoE>)bsprovisionesccosto.List;
                            Int32 Item;

                            if (ListaItems.Count == Variables.Cero)
                            {
                                Item = Variables.ValorUno;
                            }
                            else
                            {
                                Item = Convert.ToInt32(ListaItems.Max(mx => mx.idItem)) + 1;
                            }

                            ItemDet.idItem = Item;
                            txtDesProvision.Text = ItemDet.Descripcion.Trim();
                            ListaItems.Add(ItemDet);
                            bsprovisionesccosto.DataSource = ListaItems;
                            bsprovisionesccosto.ResetBindings(false);

                            if (chkindNoDom.Checked)
                            {
                                txtRentaBruta.Text = txtImporteOrigen.Text;
                                txtRentaNeta.Text = txtImporteOrigen.Text;
                            }
                        }

                        if (oFrm.oListaCompras != null && oFrm.oListaCompras.Count > 0)
                        {
                            oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>(oFrm.oListaCompras);
                            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                            bsprovisionesccosto.ResetBindings(false);

                            if (chkindNoDom.Checked)
                            {
                                txtRentaBruta.Text = txtImporteOrigen.Text;
                                txtRentaNeta.Text = txtImporteOrigen.Text;
                            }
                        }

                        if (oFrm.oConcepto != null && oFrm.oConcepto.indDetraccion && oFrm.oConcepto.idTipoDetraccion != "0")
                        {
                            if (!chkDetraccion.Checked)
                            {
                                chkDetraccion.Checked = true;
                                chkDetraccion.Enabled = false;
                                cbotipodetraccion.Enabled = false;
                                cbotipodetraccion.SelectedValue = oFrm.oConcepto.idTipoDetraccion.ToString();
                                txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");//oFrm.oConcepto.porImpuesto.ToString("N2");
                            }
                            else
                            {
                                if (Global.MensajeConfirmacion(String.Format("La compra ya tiene asignada una detracción, desea reemplazarla por la detracción que trae el Concepto({0}) agregado.", oFrm.oConcepto.porImpuesto.ToString("N2") + "%") , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    cbotipodetraccion.SelectedValue = oFrm.oConcepto.idTipoDetraccion.ToString();
                                    txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                                }
                            }
                        }

                        Calcular();
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Falta configurar el parámetro de Servicios en Parámetros Generales");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btActivos_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                A = Articulo
                G = Gasto
                S = Servicio
                C = Activo
                */

                if (txtTipCambio.Text == "0.000")
                {
                    Global.MensajeComunicacion("Debe buscar un dia que tenga Tipo de Cambio.");
                    return;
                }

                ParTabla oGasto = AgenteGeneral.Proxy.ParTablaPorNemo("TCACT");

                if (oGasto != null)
                {
                    Int32 Columna = 0;

                    if (cboTipoAsiento.SelectedValue != null)
                    {
                        Columna = Convert.ToInt32(((ComprasFileE)cboTipoAsiento.SelectedItem).codColumnaCoven);
                    }

                    //Boleta de Venta Recibida
                    Int32 col = VariablesLocales.DevolverBase(cboDocumento.SelectedValue.ToString());

                    if (col != 0)
                    {
                        Columna = col;
                    }

                    frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(oGasto.IdParTabla, dtpFecDocumento.Value, "C", Columna,
                                                                                        cboMoneda.SelectedValue.ToString(), chkIndDistribucion.Checked);
                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        if (oFrm.oProvisionCompra != null)
                        {
                            Provisiones_PorCCostoE ItemDet = oFrm.oProvisionCompra;
                            List<Provisiones_PorCCostoE> ListaItems = (List<Provisiones_PorCCostoE>)bsprovisionesccosto.List;
                            Int32 Item;

                            if (ListaItems.Count == Variables.Cero)
                            {
                                Item = Variables.ValorUno;
                            }
                            else
                            {
                                Item = Convert.ToInt32(ListaItems.Max(mx => mx.idItem)) + 1;
                            }

                            ItemDet.idItem = Item;
                            ListaItems.Add(ItemDet);
                            bsprovisionesccosto.DataSource = ListaItems;
                            bsprovisionesccosto.ResetBindings(false);

                            if (chkindNoDom.Checked)
                            {
                                txtRentaBruta.Text = txtImporteOrigen.Text;
                                txtRentaNeta.Text = txtImporteOrigen.Text;
                            }
                        }

                        if (oFrm.oListaCompras != null && oFrm.oListaCompras.Count > 0)
                        {
                            oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>(oFrm.oListaCompras);
                            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                            bsprovisionesccosto.ResetBindings(false);

                            if (chkindNoDom.Checked)
                            {
                                txtRentaBruta.Text = txtImporteOrigen.Text;
                                txtRentaNeta.Text = txtImporteOrigen.Text;
                            }
                        }

                        if (oFrm.oConcepto != null && oFrm.oConcepto.indDetraccion && oFrm.oConcepto.idTipoDetraccion != "0")
                        {
                            if (!chkDetraccion.Checked)
                            {
                                chkDetraccion.Checked = true;
                                chkDetraccion.Enabled = false;
                                cbotipodetraccion.Enabled = false;
                                cbotipodetraccion.SelectedValue = oFrm.oConcepto.idTipoDetraccion.ToString();
                                txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                            }
                            else
                            {
                                if (Global.MensajeConfirmacion(String.Format("La compra ya tiene asignada una detracción, desea reemplazarla por la detracción que trae el Concepto({0}) agregado.", oFrm.oConcepto.porImpuesto.ToString("N2") + "%"), MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    cbotipodetraccion.SelectedValue = oFrm.oConcepto.idTipoDetraccion.ToString();
                                    txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                                }
                            }
                        }

                        Calcular();
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Falta configurar el parámetro de Activos en Parámetros Generales");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvprovisionesccosto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvprovisionesccosto.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //DataGridViewButtonCell celBoton = dgvprovisionesccosto.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon Icono = new Icon(Environment.CurrentDirectory + @"\BorrarLinea.ico");
                e.Graphics.DrawIcon(Icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                dgvprovisionesccosto.Rows[e.RowIndex].Height = Icono.Height + 6;
                dgvprovisionesccosto.Columns[e.ColumnIndex].Width = Icono.Width + 6;

                e.Handled = true;
            }

            if (e.ColumnIndex >= 0 && dgvprovisionesccosto.Columns[e.ColumnIndex].Name == "Modificar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //DataGridViewButtonCell celBoton = dgvprovisionesccosto.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon Icono = new Icon(Environment.CurrentDirectory + @"\ModificarIco.ico");
                e.Graphics.DrawIcon(Icono, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                dgvprovisionesccosto.Rows[e.RowIndex].Height = Icono.Height + 6;
                dgvprovisionesccosto.Columns[e.ColumnIndex].Width = Icono.Width + 6;

                e.Handled = true;
            }
        }

        private void dgvprovisionesccosto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && dgvprovisionesccosto.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
                {
                    if (!BloqueoTotal)
                    {
                        if (bsprovisionesccosto.Current != null)
                        {
                            if (oProvisiones.ListaPorCCosto != null && oProvisiones.ListaPorCCosto.Count > Variables.Cero)
                            {
                                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                                {
                                    return;
                                }

                                bsprovisionesccosto.EndEdit();

                                if (oProvisiones.ItemsEliminados == null)
                                {
                                    oProvisiones.ItemsEliminados = new List<Provisiones_PorCCostoE>();
                                }

                                if (chkDetraccion.Checked)
                                {
                                    foreach (Provisiones_PorCCostoE item in oProvisiones.ListaPorCCosto)
                                    {
                                        oProvisiones.ItemsEliminados.Add(item);
                                    }

                                    Global.MensajeComunicacion("Ya hay una detracción asignada, se eliminará todo el detalle y se borrará la detracción.");

                                    oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>();
                                    bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                                    bsprovisionesccosto.ResetBindings(false);

                                    chkDetraccion.Checked = false;
                                    chkDetraccion.Enabled = true;
                                    txtNumDetraccion.Text = String.Empty;
                                    cbotipodetraccion.Enabled = false;
                                    cbotipodetraccion.SelectedValue = "0";
                                    txtTasaDetra.Text = "0.00";
                                    txtMontoDetraS.Text = "0.00";
                                    txtMontoDetraD.Text = "0.00";
                                }
                                else
                                {
                                    oProvisiones.ItemsEliminados.Add((Provisiones_PorCCostoE)bsprovisionesccosto.Current);
                                    oProvisiones.ListaPorCCosto.RemoveAt(bsprovisionesccosto.Position);
                                    bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                                    bsprovisionesccosto.ResetBindings(false);
                                }

                                Calcular();
                            }
                        } 
                    }
                }

                if (e.ColumnIndex >= 0 && dgvprovisionesccosto.Columns[e.ColumnIndex].Name == "Modificar" && e.RowIndex >= 0)
                {
                    if (e.RowIndex != -1)
                    {
                        if (dgvprovisionesccosto.Rows.Count > Variables.Cero)
                        {
                            Provisiones_PorCCostoE Detalle = new Provisiones_PorCCostoE();
                            Detalle = oProvisiones.ListaPorCCosto[e.RowIndex];
                            Detalle.idMoneda = cboMoneda.SelectedValue.ToString();

                            /*
                             A = Articulo
                             G = Gasto
                             S = Servicio
                             C = Activo
                             N = Anticipo
                             P = Aplicación Anticipo
                             */

                            if (Detalle.Tipo != "A")
                            {
                                if (Detalle.Tipo != "P")
                                {
                                    frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(Detalle, oProvisiones.EstadoProvision, chkIndDistribucion.Checked);

                                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvisionCompra != null)
                                    {
                                        oProvisiones.ListaPorCCosto[e.RowIndex] = oFrm.oProvisionCompra;
                                        bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                                        bsprovisionesccosto.ResetBindings(false);
                                        Calcular();

                                        if (chkindNoDom.Checked)
                                        {
                                            txtRentaBruta.Text = txtImporteOrigen.Text;
                                            txtRentaNeta.Text = txtImporteOrigen.Text;
                                            cboTasa_SelectionChangeCommitted(new object(), new EventArgs());
                                            chkIgvNoDom_CheckedChanged(null, null);
                                        }
                                    }  
                                }
                            }
                            else
                            {
                                frmProvisionCosto oFrm = new frmProvisionCosto(Detalle, oProvisiones.EstadoProvision);

                                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                                {
                                    oProvisiones.ListaPorCCosto[e.RowIndex] = oFrm.Detalle;
                                    bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                                    bsprovisionesccosto.ResetBindings(false);
                                    Calcular();

                                    if (chkindNoDom.Checked)
                                    {
                                        txtRentaBruta.Text = txtImporteOrigen.Text;
                                        txtRentaNeta.Text = txtImporteOrigen.Text;
                                        cboTasa_SelectionChangeCommitted(new object(), new EventArgs());
                                        chkIgvNoDom_CheckedChanged(null, null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cbotipodetraccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (txtImporteOrigen.Text != Variables.Cero.ToString("N2"))
            {
                CalcularDetraccion();
            }
            else
            {
                Global.MensajeComunicacion("Debe ingresar el monto total primero.");
                cbotipodetraccion.SelectedValue = Variables.Cero.ToString();
            }
        }

        private void chkIndCosto_CheckedChanged(object sender, EventArgs e)
        {
            btCosto.Enabled = chkIndCosto.Checked;

            if (chkIndCosto.Checked)
            {
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                chkConversion.Checked = false;
                txtCodConversion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else
            {
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void btCosto_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarHojaDeCostoOC oFrm = new frmBuscarHojaDeCostoOC();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oHojaCosto != null)
                {
                    chkIndCosto.Checked = true;
                    txtNumHojaCosto.Text = oFrm.oHojaCosto.idHojaCosto.ToString();
                }
                else
                {
                    chkIndCosto.Checked = false;
                    txtNumHojaCosto.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTasa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTasa.SelectedValue.ToString() == "0")
            {
                txtTasaRetencion.Text = "0.00";
                txtImpuestoRete.Text = "0.00";
            }
            else
            {
                txtTasaRetencion.Text = ((CuentaTasaRentaE)cboTasa.SelectedItem).TasaRenta.ToString();
                Decimal Tasa = ((CuentaTasaRentaE)cboTasa.SelectedItem).TasaRenta;
                Decimal.TryParse(txtRentaBruta.Text, out Decimal RentaB);

                txtImpuestoRete.Text = (RentaB * (Tasa / 100)).ToString("N2");
            }
        }

        private void chkindNoDom_CheckedChanged(object sender, EventArgs e)
        {
            if (oProvisiones.ListaPorCCosto.Count == 0)
            {
                chkindNoDom.CheckedChanged -= chkindNoDom_CheckedChanged;
                Global.MensajeComunicacion("Primero tiene que llenar el detalle de la compra.");
                chkindNoDom.Checked = false;
                chkindNoDom.CheckedChanged += chkindNoDom_CheckedChanged;
                return;
            }

            pnlRenta.Enabled = chkindNoDom.Checked;

            if (chkindNoDom.Checked)
            {
                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    txtRentaBruta.Text = txtImporteOrigen.Text;
                    txtRentaNeta.Text = txtImporteOrigen.Text;
                }
                else
                {
                    if (txtRentaBruta.Text == "0.00")
                    {
                        txtRentaBruta.Text = txtImporteOrigen.Text;
                    }

                    if (txtRentaNeta.Text == "0.00")
                    {
                        txtRentaNeta.Text = txtImporteOrigen.Text;
                    }
                }
            }
            else
            {
                txtRentaBruta.Text = "0.00";
                txtRentaNeta.Text = "0.00";
                txtCuentaRenta.Text = String.Empty;
                txtImpuestoRete.Text = "0.00";
                txtIgvNoDom.Text = "0.00";
                chkIgvNoDom.Checked = false;
                cboTasa.DataSource = null;
                txtTasaRetencion.Text = "0.00";
            }
        }

        private void cboDocCreditoFiscal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (((DocumentosE)cboDocCreditoFiscal.SelectedItem).indCreditoFiscal)
                {
                    cboDependencia.Enabled = true;

                    if (((DocumentosE)cboDocCreditoFiscal.SelectedItem).indAduanera)
                    {
                        cboDependencia.SelectedValue = Convert.ToInt32(((DocumentosE)cboDocCreditoFiscal.SelectedItem).depAduanera);
                    }
                }
                else
                {
                    if (cboDependencia.SelectedValue != null)
                    {
                        cboDependencia.SelectedValue = 0;
                        cboDependencia.Enabled = false;
                    }
                }

                cboDependencia_SelectionChangeCommitted(new Object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboDependencia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDependencia.SelectedValue) != 0)
            {
                txtSerieCredFiscal.Text = ((ParTabla)cboDependencia.SelectedItem).EquivalenciaSunat;
            }
            else
            {
                txtSerieCredFiscal.Text = string.Empty;
            }
        }

        private void chkIgvNoDom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIgvNoDom.Checked)
            {
                ImpuestosPeriodoE oImpuestoIgv = AgenteGeneral.Proxy.ObtenerImpuestosPeriodo(1, 1);

                if (oImpuestoIgv != null)
                {
                    Decimal.TryParse(txtImporteOrigen.Text, out Decimal Total);

                    txtIgvNoDom.Text = (Total * (oImpuestoIgv.Porcentaje / 100)).ToString("N2");
                }
                else
                {
                    txtIgvNoDom.Text = "0.00";
                }
            }
            else
            {
                txtIgvNoDom.Text = "0.00";
            }
        }

        private void txtNumDiasVen_Leave(object sender, EventArgs e)
        {
            Int32 Dias = AñadirDias();

            if (Dias != 0)
            {
                dtpFecVencimiento.Value = dtpFecDocumento.Value.Date.AddDays(Dias);
            }
            else
            {
                dtpFecVencimiento.Value = dtpFecDocumento.Value;
            }
        }

        private void btReparable_Click(object sender, EventArgs e)
        {
            try
            {
                if (oProvisiones != null)
                {
                    frmDetalleReparable oFrm = new frmDetalleReparable(oProvisiones.indReparable, oProvisiones.idConceptoRep, oProvisiones.desReferenciaRep);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oProvisiones.indReparable = oFrm.indReparable;
                        oProvisiones.idConceptoRep = oFrm.idConceptoRep;
                        oProvisiones.desReferenciaRep = oFrm.desReferenciaRep;
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
            if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
            {
                txtSerie.MaxLength = 4;
                txtNumero.MaxLength = 8;
            }
            else
            {
                txtSerie.MaxLength = 20;
                txtNumero.MaxLength = 20;
            }

            try
            {
                if (cboDocumento.SelectedValue.ToString() != Variables.Cero.ToString())
                {
                    if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
                    {
                        cboReferencia.Enabled = true;
                        cboReferencia.SelectedValue = Variables.Cero.ToString();
                        //cboAfectacionAlmacen.Enabled = true;
                        cboAfectacionAlmacen.SelectedValue = Variables.Cero.ToString();
                        txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                        txtNumRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                        dtpFecRef.Enabled = true;
                    }
                    else
                    {
                        cboReferencia.Enabled = false;
                        cboReferencia.SelectedValue = Variables.Cero.ToString();
                        //cboAfectacionAlmacen.Enabled = false;
                        cboAfectacionAlmacen.SelectedValue = Variables.Cero.ToString();
                        txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                        txtNumRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                        dtpFecRef.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
                {
                    if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                    {
                        if (txtSerie.TextLength < txtSerie.MaxLength && Global.EsNumero(txtSerie.Text))
                        {
                            txtSerie.Text = txtSerie.Text.PadLeft(4, '0');
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
                {
                    if (!String.IsNullOrEmpty(txtNumero.Text.Trim()))
                    {
                        if (txtNumero.TextLength < txtNumero.MaxLength && Global.EsNumero(txtNumero.Text))
                        {
                            txtNumero.Text = txtNumero.Text.PadLeft(8, '0');
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoAsiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BuscarCuenta(((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta);
                chkIndReversion.Checked = ((ComprasFileE)cboTipoAsiento.SelectedItem).FileConta.indPorExtornar;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btPresupuesto_Click(object sender, EventArgs e)
        {
            frmBuscarPartida oFrm = new frmBuscarPartida();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
            {
                txtCodPartida.TextChanged -= txtCodPartida_TextChanged;

                txtCodPartida.Tag = oFrm.oPartidaPresupuestal.tipPartidaPresu.ToString();
                txtCodPartida.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                txtDesPartida.Text = oFrm.oPartidaPresupuestal.desPartidaPresu;

                txtCodPartida.TextChanged += txtCodPartida_TextChanged;
            }
        }

        private void chkIndReversion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndReversion.Checked)
            {
                btBuscarRever.Enabled = false;
                txtIdReversion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
            else
            {
                btBuscarRever.Enabled = true;
                txtIdReversion.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }
        
        private void btBuscarRever_Click(object sender, EventArgs e)
        {
            frmBuscarProvisiones oFrm = new frmBuscarProvisiones("Rever");

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvision != null)
            {
                Int32 OpcionTemp = Opcion;
                Int32? idReversionTemp = oProvisiones.idProvisionRev;
                Int32 ID = oProvisiones.idProvision;
                Int32? idCtaCte = oProvisiones.idCtaCte;
                Int32? idCtaCteItem = oProvisiones.idCtaCteItem;

                oProvisiones = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(oFrm.oProvision.idEmpresa, oFrm.oProvision.idLocal, oFrm.oProvision.idProvision);
                Nuevo();

                oProvisiones.idEmpresa = VariablesLocales.SesionLocal.IdEmpresa;
                oProvisiones.idLocal = VariablesLocales.SesionLocal.IdLocal;
                oProvisiones.EstadoProvision = "RE";
                oProvisiones.idProvisionRevTmp = idReversionTemp;
                oProvisiones.EsLiquidacion = false;
                oProvisiones.idSistema = 5;

                dtpFechaProvision.Value = VariablesLocales.FechaHoy.Date;
                txtCodConversion.Text = String.Empty;
                chkIndCosto.CheckedChanged -= chkIndCosto_CheckedChanged;
                chkIndCosto.Checked = false;
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                chkIndCosto.CheckedChanged += chkIndCosto_CheckedChanged;
                txtDesEstado.Text = "POR REGISTRAR";
                chkIndReversion.Checked = false;
                txtIdReversion.Text = oProvisiones.idProvision.ToString();

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                if (OpcionTemp == (Int32)EnumOpcionGrabar.Insertar)
                {
                    txtIdProvision.Text = String.Empty;
                    Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    oProvisiones.idProvision = ID;
                    oProvisiones.idCtaCte = idCtaCte ?? 0;
                    oProvisiones.idCtaCteItem = idCtaCteItem ?? 0;
                    txtIdProvision.Text = oProvisiones.idProvision.ToString("0000000");
                    Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
            }
        }

        private void txtCuentaRenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCuentaRenta.Text.Trim()) && string.IsNullOrEmpty(txtDesCuentaRenta.Text.Trim()))
                {
                    txtCuentaRenta.TextChanged -= txtCuentaRenta_TextChanged;
                    txtDesCuentaRenta.TextChanged -= txtDesCuentaRenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = (from x in AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCuentaRenta.Text,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.Longitud, 1)
                                                        where x.indTasaRenta == true
                                                        select x).ToList();

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentaRenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaRenta.Text = oFrm.oCuenta.Descripcion;

                            if (oFrm.oCuenta.indTasaRenta)
                            {
                                List<CuentaTasaRentaE> oLista = ListaCuentasTasas(txtCuentaRenta.Text.Trim());

                                if (oLista.Count > 0)
                                {
                                    cboTasa.DataSource = oLista;
                                    cboTasa.ValueMember = "idTasaRenta";
                                    cboTasa.DisplayMember = "desTasaRenta";

                                    cboTasa_SelectionChangeCommitted(new object(), new EventArgs());
                                }
                                else
                                {
                                    Global.MensajeComunicacion("Esta cuenta no tiene ninguna tasa de renta asociada");
                                }
                            }
                        }
                        else
                        {
                            txtCuentaRenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentaRenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaRenta.Text = oListaCuentas[0].Descripcion;

                        if (oListaCuentas[0].indTasaRenta)
                        {
                            List<CuentaTasaRentaE> oLista = ListaCuentasTasas(txtCuentaRenta.Text.Trim());

                            if (oLista.Count > 0)
                            {
                                cboTasa.DataSource = oLista;
                                cboTasa.ValueMember = "idTasaRenta";
                                cboTasa.DisplayMember = "desTasaRenta";

                                cboTasa_SelectionChangeCommitted(new object(), new EventArgs());
                            }
                            else
                            {
                                Global.MensajeComunicacion("Esta cuenta no tiene ninguna tasa de renta asociada");
                            }
                        }
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no posee tasas de rentas. Ingrese otra cuenta.");
                        txtCuentaRenta.Text = string.Empty;
                        txtDesCuentaRenta.Text = string.Empty;
                    }

                    txtCuentaRenta.TextChanged += txtCuentaRenta_TextChanged;
                    txtDesCuentaRenta.TextChanged += txtDesCuentaRenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaRenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCuentaRenta.Text.Trim()) && !string.IsNullOrEmpty(txtDesCuentaRenta.Text.Trim()))
                {
                    txtCuentaRenta.TextChanged -= txtCuentaRenta_TextChanged;
                    txtDesCuentaRenta.TextChanged -= txtDesCuentaRenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = (from x in AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaRenta.Text,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.Longitud, 2)
                                                        where x.indTasaRenta == true
                                                        select x).ToList();

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCuentaRenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaRenta.Text = oFrm.oCuenta.Descripcion;

                            if (oFrm.oCuenta.indTasaRenta)
                            {
                                List<CuentaTasaRentaE> oLista = ListaCuentasTasas(txtCuentaRenta.Text.Trim());

                                if (oLista.Count > 0)
                                {
                                    cboTasa.DataSource = oLista;
                                    cboTasa.ValueMember = "idTasaRenta";
                                    cboTasa.DisplayMember = "desTasaRenta";

                                    cboTasa_SelectionChangeCommitted(new object(), new EventArgs());
                                }
                                else
                                {
                                    Global.MensajeComunicacion("Esta cuenta no tiene ninguna tasa de renta asociada");
                                }
                            }
                        }
                        else
                        {
                            txtDesCuentaRenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCuentaRenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaRenta.Text = oListaCuentas[0].Descripcion;

                        if (oListaCuentas[0].indTasaRenta)
                        {
                            List<CuentaTasaRentaE> oLista = ListaCuentasTasas(txtCuentaRenta.Text.Trim());

                            if (oLista.Count > 0)
                            {
                                cboTasa.DataSource = oLista;
                                cboTasa.ValueMember = "idTasaRenta";
                                cboTasa.DisplayMember = "desTasaRenta";

                                cboTasa_SelectionChangeCommitted(new object(), new EventArgs());
                            }
                            else
                            {
                                Global.MensajeComunicacion("Esta cuenta no tiene ninguna tasa de renta asociada");
                            }
                        }
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no posee tasas de renta. Ingrese otra cuenta.");
                        txtCuentaRenta.Text = string.Empty;
                        txtDesCuentaRenta.Text = string.Empty;
                    }

                    txtCuentaRenta.TextChanged += txtCuentaRenta_TextChanged;
                    txtDesCuentaRenta.TextChanged += txtDesCuentaRenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCuentaRenta_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaRenta.Text = String.Empty;
        }

        private void txtDesCuentaRenta_TextChanged(object sender, EventArgs e)
        {
            txtCuentaRenta.Text = String.Empty;
        }

        private void dtpFecRef_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumento.SelectedValue.ToString() == "97" || cboDocumento.SelectedValue.ToString() == "98" || cboDocumento.SelectedValue.ToString() == "CR" ||
                    cboDocumento.SelectedValue.ToString() == "DR" || cboDocumento.SelectedValue.ToString() == "NC" || cboDocumento.SelectedValue.ToString() == "ND")
                {
                    DateTime Fecha = ((DateTimePicker)sender).Value;
                    TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));

                    if (Tica != null)
                    {
                        txtTipCambio.Text = Decimal.Round(Tica.valVenta, 3).ToString();
                        Calcular();
                    }
                    else
                    {
                        txtTipCambio.Text = "0.000";
                        dtpFecRef.Focus();
                        Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btPorRecibir_Click(object sender, EventArgs e)
        {
            frmBuscarProvisiones oFrm = new frmBuscarProvisiones("PorRecibir");

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvision != null)
            {
                Int32 OpcionTemp = Opcion;
                Int32? idReversionTemp = oProvisiones.idProvisionRev;
                Int32 ID = oProvisiones.idProvision;
                oProvisiones = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(oFrm.oProvision.idEmpresa, oFrm.oProvision.idLocal, oFrm.oProvision.idProvision, true);

                foreach (Provisiones_PorCCostoE item in oProvisiones.ListaPorCCosto)
                {
                    item.PorRecibir = false;
                    item.idProvisionRecibida = item.idItem;                 
                }

                Nuevo();

                oProvisiones.idEmpresa = VariablesLocales.SesionLocal.IdEmpresa;
                oProvisiones.idLocal = VariablesLocales.SesionLocal.IdLocal;
                oProvisiones.EstadoProvision = "RE";
                oProvisiones.idProvisionRevTmp = idReversionTemp;
                oProvisiones.EsLiquidacion = false;
                oProvisiones.idSistema = 5;

                dtpFechaProvision.Value = VariablesLocales.FechaHoy.Date;
                txtCodConversion.Text = String.Empty;
                chkIndCosto.CheckedChanged -= chkIndCosto_CheckedChanged;
                chkIndCosto.Checked = false;
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                chkIndCosto.CheckedChanged += chkIndCosto_CheckedChanged;
                txtDesEstado.Text = "POR REGISTRAR";
                chkIndReversion.Checked = false;
                txtIdReversion.Text = oProvisiones.idProvision.ToString();

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                if (OpcionTemp == (Int32)EnumOpcionGrabar.Insertar)
                {
                    txtIdProvision.Text = String.Empty;
                    Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    oProvisiones.idProvision = ID;
                    txtIdProvision.Text = oProvisiones.idProvision.ToString("0000000");
                    Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
            }
        }

        private void btOrdenCompra_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarOrdenCompra oFrm = new frmBuscarOrdenCompra("F");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOC != null)
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;

                    ImpuestosPeriodoE oImpuestoIgv = (from x in VariablesLocales.oListaImpuestos where x.idImpuesto == 1 select x).FirstOrDefault();
                    OrdenCompraE oOrden = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(oFrm.oOC.idEmpresa, Convert.ToInt32(oFrm.oOC.idOrdenCompra));
                    List<ParTabla> oListaBases = new List<ParTabla>(VariablesLocales.oListaBasesImponibles);
                    Provisiones_PorCCostoE detProvision = null;
                    TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia("02", oFrm.oOC.fecEmision.ToString("yyyyMMdd"));
                    Decimal nMontoBase = 0, nMontoSecun = 0;

                    txtCodConversion.Text = "0";
                    txtOrdenCompra.Tag = Convert.ToInt32(oOrden.idOrdenCompra);
                    txtOrdenCompra.Text = oOrden.numOrdenCompra;
                    cboPlantilla.SelectedValue = 0;
                    dtpFecDocumento.Value = Convert.ToDateTime(oOrden.fecEmision);
                    cboMoneda.SelectedValue = oOrden.idMoneda.ToString();
                    cboMoneda_SelectionChangeCommitted(new object(), new EventArgs());
                    txtTipCambio.Text = oTica.valVenta.ToString("N3");

                    Decimal Tica = Convert.ToDecimal(txtTipCambio.Text);

                    txtIdProveedor.Text = oOrden.idProveedor.ToString();
                    txtRuc.Text = oOrden.RUC;
                    txtRazonSocial.Text = oOrden.RazonSocial;

                    if (!oOrden.indIngAlm)
                    {
                        if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                        {
                            txtImporteOrigen.Text = oOrden.impTotal.ToString("N2");

                            //Soles
                            txtTotal.Text = oOrden.impTotal.ToString("N2");
                            nMontoBase = oOrden.impVenta;
                            txtBaseImponible.Text = Decimal.Round(nMontoBase, 2).ToString("N2");
                            txtAjuste.Text = "0.00";
                            txtExonerado.Text = "0.00";
                            txtImpuesto.Text = oOrden.impIgv.ToString("N2");

                            //Dólares
                            txtTotalSecu.Text = Convert.ToDecimal(oOrden.impTotal / Tica).ToString("N2");
                            nMontoSecun = oOrden.impVenta / Tica;
                            txtBaseSecu.Text = Decimal.Round(nMontoSecun, 2).ToString("N2");
                            txtAjusteSecu.Text = "0.00";
                            txtExoneradoSecu.Text = "0.00";
                            txtImpuestoSecu.Text = Convert.ToDecimal(oOrden.impIgv / Tica).ToString("N2");

                            txtExonerado.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                            txtExoneradoSecu.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                        }
                        else
                        {
                            txtImporteOrigen.Text = oOrden.impTotal.ToString("N2");

                            ///Dólares
                            txtTotalSecu.Text = Convert.ToDecimal(oOrden.impTotal).ToString("N2");
                            nMontoSecun = oOrden.impVenta;
                            txtBaseSecu.Text = Decimal.Round(nMontoSecun, 2).ToString("N2");
                            txtAjusteSecu.Text = "0.00";
                            txtExoneradoSecu.Text = "0.00";
                            txtImpuestoSecu.Text = Convert.ToDecimal(oOrden.impIgv).ToString("N2");

                            //Soles
                            txtTotal.Text = Convert.ToDecimal(oOrden.impTotal * Tica).ToString("N2");
                            nMontoBase = oOrden.impVenta * Tica;
                            txtBaseImponible.Text = Decimal.Round(nMontoBase, 2).ToString("N2");
                            txtAjuste.Text = "0.00";
                            txtExonerado.Text = "0.00";
                            txtImpuesto.Text = Convert.ToDecimal(oOrden.impIgv * Tica).ToString("N2");

                            txtExonerado.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                            txtExoneradoSecu.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        }

                        txtDesEstado.Text = "POR REGISTRAR";
                        txtDesProvision.Text = oOrden.Observacion;

                        string codCuenta = oOrden.ListaOrdenesCompras[0].codCuenta;
                        Decimal impSoles = 0; Decimal impDolares = 0; Decimal MontoCuenta = 0;

                        if (oOrden.indDistribucion)
                        {
                            #region Con Distribución

                            Int32 idArticulo = oOrden.ListaOrdenesCompras[0].idArticuloServ;
                            String codArticulo = oOrden.ListaOrdenesCompras[0].codArticulo;
                            String desArticulo = oOrden.ListaOrdenesCompras[0].desArticulo;
                            Int32 Corre = 1;
                            Decimal Impuesto = Convert.ToDecimal(VariablesLocales.oListaImpuestos[0].Porcentaje) / 100;

                            foreach (OrdenCompraDistriE item in oOrden.ListaDistribucion)
                            {
                                detProvision = new Provisiones_PorCCostoE();
                                impSoles = 0;
                                impDolares = 0;
                                MontoCuenta = 0;

                                detProvision.idEmpresa = item.idEmpresa;
                                detProvision.idLocal = VariablesLocales.SesionLocal.IdLocal;
                                detProvision.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                                detProvision.idItem = Corre;
                                detProvision.idArticulo = idArticulo;
                                detProvision.Codigo = codArticulo;
                                detProvision.Descripcion = desArticulo;
                                detProvision.Cantidad = 1;
                                detProvision.PrecioUnitario = Convert.ToDecimal(item.Monto);
                                detProvision.codCuenta = item.codCuenta;
                                detProvision.DesCuenta = item.desCuenta;
                                detProvision.indCCostos = Variables.SI;
                                detProvision.idCCostos = item.idCCostos;
                                detProvision.DesCCosto = item.desCCostos;
                                detProvision.idMoneda = cboMoneda.SelectedValue.ToString();
                                detProvision.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                                detProvision.tipCambio = Convert.ToDecimal(txtTipCambio.Text);
                                detProvision.indCambio = chkIndCalcAuto.Checked;

                                if (detProvision.idMoneda == Variables.Soles)
                                {
                                    impSoles += Decimal.Round(item.Monto.Value + (item.Monto.Value * Impuesto), 2);
                                    impDolares += Decimal.Round((item.Monto.Value + (item.Monto.Value * Impuesto)) / Tica, 2);
                                    MontoCuenta += Decimal.Round(item.Monto.Value + (item.Monto.Value * Impuesto), 2);
                                }
                                else
                                {
                                    MontoCuenta += Decimal.Round(item.Monto.Value + (item.Monto.Value * Impuesto), 2);
                                    impSoles += Decimal.Round((item.Monto.Value + (item.Monto.Value * Impuesto)) * Tica, 2);
                                    impDolares += Decimal.Round(item.Monto.Value + (item.Monto.Value * Impuesto), 2);
                                }

                                detProvision.Igv = item.Monto.Value * Impuesto;
                                detProvision.subTotal = item.Monto.Value;
                                detProvision.desGlosa = txtDesProvision.Text;
                                detProvision.indIgv = true;

                                if (detProvision.indIgv)
                                {
                                    detProvision.codColumnaCoven = Convert.ToInt32(oListaBases.Where(w => w.NemoTecnico == "BAIMP").Select(x => x.IdParTabla).SingleOrDefault());
                                    detProvision.DesColumnaCoven = Convert.ToString(oListaBases.Where(w => w.NemoTecnico == "BAIMP").Select(x => x.Descripcion).SingleOrDefault());
                                }
                                else
                                {
                                    detProvision.codColumnaCoven = Convert.ToInt32(oListaBases.Where(w => w.NemoTecnico == "BAINA").Select(x => x.IdParTabla).SingleOrDefault());
                                    detProvision.DesColumnaCoven = Convert.ToString(oListaBases.Where(w => w.NemoTecnico == "BAINA").Select(x => x.Descripcion).SingleOrDefault());
                                }

                                detProvision.Tipo = "A";
                                detProvision.Calculo = "A";

                                detProvision.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                detProvision.FechaRegistro = VariablesLocales.FechaHoy;
                                detProvision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                detProvision.FechaModificacion = VariablesLocales.FechaHoy;

                                detProvision.MontoCuenta = MontoCuenta;
                                detProvision.impSoles = impSoles;
                                detProvision.impDolares = impDolares;
                                oProvisiones.ListaPorCCosto.Add(detProvision);

                                Corre++;
                            }

                            #endregion
                        }
                        else
                        {
                            //Agregado el 21-02-2019, para poder eliminar los items si en caso se vuelva a jalar nuevamente una OC
                            if (oProvisiones.ListaPorCCosto.Count > 0)
                            {
                                if (oProvisiones.ItemsEliminados == null)
                                {
                                    oProvisiones.ItemsEliminados = new List<Provisiones_PorCCostoE>();
                                }

                                foreach (Provisiones_PorCCostoE item in oProvisiones.ListaPorCCosto)
                                {
                                    oProvisiones.ItemsEliminados.Add(item);
                                }
                            }

                            #region Sin Distribución

                            oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>();

                            foreach (OrdenCompraItemE item in (from x in oOrden.ListaOrdenesCompras where x.CanOrdenada != x.canProvisionada select x).ToList())
                            {
                                detProvision = new Provisiones_PorCCostoE()
                                {
                                    idEmpresa = item.idEmpresa,
                                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                                    idItem = Convert.ToInt32(item.idItem),
                                    idArticulo = item.idArticuloServ,
                                    Codigo = item.codArticulo,
                                    Descripcion = item.desArticulo,
                                    Cantidad = item.CanOrdenada - item.canProvisionada,
                                    PrecioUnitario = item.impPrecioUnitario,
                                    numVerPlanCuentas = item.numVerPlanCuentas,

                                    codCuenta = item.codCuenta,
                                    DesCuenta = item.desCuenta,
                                    idMoneda = cboMoneda.SelectedValue.ToString(),
                                    desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura,
                                    tipCambio = Convert.ToDecimal(txtTipCambio.Text),
                                    indCambio = chkIndCalcAuto.Checked,
                                    idCCostos = oOrden.idCCostos,
                                    DesCCosto = oOrden.desCCostos,
                                    desGlosa = txtDesProvision.Text,
                                    indIgv = item.indIgv,
                                    Igv = item.impIgv,
                                    porIgv = item.porIgv,
                                    subTotal = item.impVentaItem
                                };

                                if (item.canProvisionada > 0)
                                {
                                    detProvision.subTotal = detProvision.Cantidad * item.impPrecioUnitario;

                                    if (item.indIgv)
                                    {
                                        detProvision.Igv = detProvision.subTotal * (item.porIgv / 100);
                                    }

                                    detProvision.subTotal = detProvision.Cantidad * item.impPrecioUnitario;
                                    item.impTotalItem = detProvision.subTotal + detProvision.Igv;
                                }

                                if (detProvision.idMoneda == Variables.Soles)
                                {
                                    impSoles = Decimal.Round(item.impTotalItem, 2);
                                    impDolares = Decimal.Round(item.impTotalItem / Tica, 2);
                                    MontoCuenta = Decimal.Round(item.impTotalItem, 2);
                                }
                                else
                                {
                                    MontoCuenta = Decimal.Round(item.impTotalItem, 2);
                                    impSoles = Decimal.Round(item.impTotalItem * Tica, 2);
                                    impDolares = Decimal.Round(item.impTotalItem, 2);
                                }

                                if (detProvision.indIgv)
                                {
                                    detProvision.codColumnaCoven = Convert.ToInt32(oListaBases.Where(w => w.NemoTecnico == "BAIMP").Select(x => x.IdParTabla).SingleOrDefault());
                                    detProvision.DesColumnaCoven = Convert.ToString(oListaBases.Where(w => w.NemoTecnico == "BAIMP").Select(x => x.Descripcion).SingleOrDefault()); //"BASE IMPONIBLE";
                                }
                                else
                                {
                                    detProvision.codColumnaCoven = Convert.ToInt32(oListaBases.Where(w => w.NemoTecnico == "BAINA").Select(x => x.IdParTabla).SingleOrDefault());
                                    detProvision.DesColumnaCoven = Convert.ToString(oListaBases.Where(w => w.NemoTecnico == "BAINA").Select(x => x.Descripcion).SingleOrDefault());
                                }

                                detProvision.Tipo = "A";
                                detProvision.Calculo = "A";
                                detProvision.indCCostos = item.indCCostos;

                                if (detProvision.indCCostos == Variables.NO)
                                {
                                    detProvision.idCCostos = String.Empty;
                                    detProvision.DesCCosto = String.Empty;
                                }

                                detProvision.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                detProvision.FechaRegistro = VariablesLocales.FechaHoy;
                                detProvision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                detProvision.FechaModificacion = VariablesLocales.FechaHoy;

                                detProvision.MontoCuenta = MontoCuenta;
                                detProvision.impSoles = impSoles;
                                detProvision.impDolares = impDolares;

                                oProvisiones.ListaPorCCosto.Add(detProvision);

                                codCuenta = item.codCuenta;

                                //Detracción...
                                if (item.ArticuloServ != null && item.ArticuloServ.indDetraccion && item.ArticuloServ.tipDetraccion != "0")
                                {
                                    chkDetraccion.Checked = item.ArticuloServ.indDetraccion;

                                    if (chkDetraccion.Checked)
                                    {
                                        if (oProvisiones.ListaPorCCosto.Count == 0)
                                        {
                                            cbotipodetraccion.SelectedValue = item.ArticuloServ.tipDetraccion.ToString();
                                            txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            Decimal.TryParse(txtMontoDetraS.Text, out Decimal Monto);

                                            if (Monto > 0)
                                            {
                                                //if (Global.MensajeConfirmacion("La compra ya tiene asignada una detracción, desea reemplazarla que trae el Concepto.", MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                                //{
                                                    cbotipodetraccion.SelectedValue = item.ArticuloServ.tipDetraccion.ToString();
                                                    txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                                                //}
                                            }
                                            else
                                            {
                                                cbotipodetraccion.SelectedValue = item.ArticuloServ.tipDetraccion.ToString();
                                                txtTasaDetra.Text = ((TasasDetraccionesDetalleE)cbotipodetraccion.SelectedItem).Porcentaje.ToString("N2");
                                            }
                                        }
                                    }
                                }
                            }

                            #endregion
                        }
                    }

                    Calcular();

                    bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                    bsprovisionesccosto.ResetBindings(false);

                    dgvprovisionesccosto.AutoResizeColumns();

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodPartida_TextChanged(object sender, EventArgs e)
        {
            txtCodPartida.Tag = String.Empty;
            txtDesPartida.Text = String.Empty;
        }

        private void txtNumRef_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (bFlag)
                {
                    if (cboReferencia.SelectedValue.ToString() != "0" && !String.IsNullOrEmpty(txtIdProveedor.Text.Trim()) && !String.IsNullOrEmpty(txtSerieRef.Text.Trim()) && !String.IsNullOrEmpty(txtNumRef.Text.Trim()))
                    {
                        BuscarDocumentoRef();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtSerieRef_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboReferencia.SelectedValue.ToString() == "FC" || cboReferencia.SelectedValue.ToString() == "BR" || cboReferencia.SelectedValue.ToString() == "DR")
                {
                    if (!String.IsNullOrEmpty(txtSerieRef.Text.Trim()))
                    {
                        if (txtSerieRef.TextLength < txtSerieRef.MaxLength && Global.EsNumero(txtSerieRef.Text))
                        {
                            txtSerieRef.Text = txtSerieRef.Text.PadLeft(4, '0');
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }

        }

        private void txtNumRef_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboReferencia.SelectedValue.ToString() == "FC" || cboReferencia.SelectedValue.ToString() == "BR" || cboReferencia.SelectedValue.ToString() == "DR")
                {
                    if (!String.IsNullOrEmpty(txtNumRef.Text.Trim()))
                    {
                        if (txtNumRef.TextLength < txtNumRef.MaxLength && Global.EsNumero(txtNumRef.Text))
                        {
                            txtNumRef.Text = txtNumRef.Text.PadLeft(8, '0');
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboAnticipos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BotonesDetalle();

            if (Convert.ToInt32(cboAnticipos.SelectedValue) == 0)
            {
                List<Provisiones_PorCCostoE> oListaDetalle = new List<Provisiones_PorCCostoE>(oProvisiones.ListaPorCCosto);

                if (oProvisiones.ItemsEliminados == null)
                {
                    oProvisiones.ItemsEliminados = new List<Provisiones_PorCCostoE>();
                }

                foreach (Provisiones_PorCCostoE item in oListaDetalle)
                {
                    if (item.Tipo == "N" || item.Tipo == "P") //Si en caso sea anticipo o aplicación de anticipo...
                    {
                        oProvisiones.ListaPorCCosto.Remove(item);
                        oProvisiones.ItemsEliminados.Add(item);
                    }
                }

                bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                bsprovisionesccosto.ResetBindings(false);
            }
        }

        private void btAnticipos_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                A = Articulo
                G = Gasto
                S = Servicio
                C = Activo
                N = Anticipo
                P = Aplicación de Anticipo
                */

                if (txtTipCambio.Text == "0.000")
                {
                    Global.MensajeComunicacion("Debe buscar un dia que tenga Tipo de Cambio.");
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtIdProveedor.Text.Trim()))
                {
                    Global.MensajeComunicacion("Debe escoger un Proveedor antes de buscar un Anticipo.");
                    return;
                }

                if (oProvisiones.ListaPorCCosto == null || oProvisiones.ListaPorCCosto.Count == 0)
                {
                    Global.MensajeComunicacion("Debe items al detalle antes de buscar el anticipo.");
                    return;
                }

                frmPendientesAnticiposCompras oFrm = new frmPendientesAnticiposCompras(Convert.ToInt32(txtIdProveedor.Text), txtRuc.Text, txtRazonSocial.Text);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte != null && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    List<AnticipoCtaCteE> oListaCtaCteTemp = new List<AnticipoCtaCteE>(oFrm.oListaCtaCte);
                    Int32 Item = 1;

                    if (oProvisiones.ListaPorCCosto.Count > 0)
                    {
                        Item = Convert.ToInt32(oProvisiones.ListaPorCCosto.Max(mx => mx.idItem)) + 1;
                        Decimal.TryParse(txtImpuesto.Text, out Decimal IGV);

                        AnticipoCtaCteE Anticipo = oListaCtaCteTemp.Find
                        (
                            delegate (AnticipoCtaCteE a) { return a.oProvisionDet.indIgv == true; }
                        );

                        if (IGV == 0 && Anticipo != null)
                        {
                            goto Salir1;
                        }

                        if (IGV > 0 && Anticipo == null)
                        {
                            goto Salir2;
                        }
                    }

                    foreach (AnticipoCtaCteE item in oListaCtaCteTemp)
                    {
                        item.oProvisionDet.idItem = Item;
                        item.oProvisionDet.Tipo = "P";
                        item.oProvisionDet.idCtaCteAnticipo = item.idCtaCte;
                        item.oProvisionDet.tipCambio = Convert.ToDecimal(txtTipCambio.Text);

                        if (item.oProvisionDet.idMoneda == "01")
                        {
                            item.oProvisionDet.impSoles = item.oProvisionDet.MontoCuenta = item.Saldo;
                            item.oProvisionDet.impDolares = item.Saldo / item.oProvisionDet.tipCambio;

                            if (item.oProvisionDet.indIgv)
                            {
                                Decimal.TryParse(item.oProvisionDet.porIgv.ToString(), out Decimal porIgv);
                                item.oProvisionDet.subTotal = item.oProvisionDet.impSoles / ((porIgv / 100) + 1);
                                item.oProvisionDet.Igv = item.oProvisionDet.subTotal * (porIgv / 100);
                            }
                            else
                            {
                                item.oProvisionDet.Igv = 0;
                                item.oProvisionDet.subTotal = item.Saldo;
                                item.oProvisionDet.PrecioUnitario = item.Saldo;
                            }
                        }
                        else
                        {
                            item.oProvisionDet.impDolares = item.oProvisionDet.MontoCuenta = item.Saldo;
                            item.oProvisionDet.impSoles = item.Saldo * item.oProvisionDet.tipCambio;

                            if (item.oProvisionDet.indIgv)
                            {
                                Decimal.TryParse(item.oProvisionDet.porIgv.ToString(), out Decimal porIgv);
                                item.oProvisionDet.subTotal = item.oProvisionDet.impDolares / ((porIgv / 100) + 1);
                                item.oProvisionDet.Igv = item.oProvisionDet.subTotal * (porIgv / 100);
                            }
                            else
                            {
                                item.oProvisionDet.Igv = 0;
                                item.oProvisionDet.subTotal = item.Saldo;
                                item.oProvisionDet.PrecioUnitario = item.Saldo;
                            }
                        }

                        item.oProvisionDet.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        item.oProvisionDet.FechaRegistro = VariablesLocales.FechaHoy;
                        item.oProvisionDet.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        item.oProvisionDet.FechaModificacion = VariablesLocales.FechaHoy;

                        oProvisiones.ListaPorCCosto.Add(item.oProvisionDet);

                        Item++;
                    }
                    
                    goto Finish;

                    Salir1:
                    Global.MensajeComunicacion(String.Format("Esta aplicando un Anticipo que tiene IGV al documento {0} {1}-{2} que no tiene IGV.", cboDocumento.SelectedValue.ToString(), txtSerie.Text, txtNumero.Text));

                    Salir2:
                    Global.MensajeComunicacion(String.Format("Esta aplicando un Anticipo que no tiene IGV al documento {0} {1}-{2} que tiene IGV.", cboDocumento.SelectedValue.ToString(), txtSerie.Text, txtNumero.Text));

                    Finish:
                    bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                    bsprovisionesccosto.ResetBindings(false);
                    Calcular();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btConversion_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarConversiones oFrm = new frmBuscarConversiones();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOrdenConversion != null)
                {
                    //chkIndCosto.Checked = true;
                    txtCodConversion.Tag = oFrm.oOrdenConversion.idOrdenConversion;
                    txtCodConversion.Text = oFrm.oOrdenConversion.Numero;
                }
                else
                {
                    chkIndCosto.Checked = false;
                    txtCodConversion.Tag = 0;
                    txtCodConversion.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkConversion_CheckedChanged(object sender, EventArgs e)
        {
            btConversion.Enabled = chkConversion.Checked;

            if (chkConversion.Checked)
            {
                txtCodConversion.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                chkIndCosto.Checked = false;
            }
            else
            {
                txtCodConversion.Tag = 0;
                txtCodConversion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        #endregion

    }
}
