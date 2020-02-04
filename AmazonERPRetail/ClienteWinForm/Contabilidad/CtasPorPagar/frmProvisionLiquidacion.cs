using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;
using ClienteWinForm.CtasPorPagar;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmProvisionLiquidacion : FrmMantenimientoBase
    {

        #region Constructores

        public frmProvisionLiquidacion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvprovisionesccosto, false);
        }

        //Liquidaciones
        public frmProvisionLiquidacion(Int32 idEmpresa_, Int32 idLocal_, Int32 idProvision_, String TipoF, String Bloq, String TipoCuenta_, ProvisionesE oProv)
            :this()
        {
            TipoFondo = TipoF;
            TipoCuenta = TipoCuenta_;

            if (oProv == null)
            {
                oProvisiones = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(idEmpresa_, idLocal_, idProvision_);
            }
            else
            {
                oProvisiones = oProv;
            }

            if (oProvisiones != null)
            {
                if (oProvisiones.EstadoProvision != "LI" && oProvisiones.EstadoProvision != "RE")  //Si es Diferente a Liquidación...Por consultar RE
                {
                    BloquearPaneles(false);

                    if (oProvisiones.EstadoProvision == "PR")
                    {
                        Global.MensajeComunicacion("No podrá realizar modificaciones porque este documento ya se encuentra Provisionado."); 
                    }
                }

                Text = "Compras - Liquidación(N° " + oProvisiones.idProvision.ToString("000000") + ")";
            }

            Bloqueo = Bloq;
            TipoEstado = "LI";

            if (Bloqueo == "S")
            {
                btAceptar.Enabled = false;
            }
        }

        //Rendiciones
        public frmProvisionLiquidacion(Int32 idEmpresa_, Int32 idLocal_, Int32 idProvision_, ProvisionesE oProv, String Bloq, DateTime FechaProc)
            :this()
        {
            if (oProv == null && idProvision_ > 0)
            {
                oProvisiones = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(idEmpresa_, idLocal_, idProvision_);
            }
            else
            {
                oProvisiones = oProv;
                dtpFechaProvision.Value = FechaProc.Date;
            }

            if (oProvisiones != null)
            {
                if (oProvisiones.EstadoProvision != "RD" && oProvisiones.EstadoProvision != "RE")  //Si es Diferente a Rendición y Registrado
                {
                    BloquearPaneles(false);

                    if (oProvisiones.EstadoProvision == "PR")
                    {
                        Global.MensajeComunicacion("No podrá realizar modificaciones porque este documento ya se encuentra Provisionado.");
                    }
                }

                Text = "Compras - Rendición(N° " + oProvisiones.idProvision.ToString("000000") + ")";
            }

            Bloqueo = Bloq;
            TipoEstado = "RD";

            if (Bloqueo == "S")
            {
                btAceptar.Enabled = false;
            }
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        Int32 Opcion;
        String TipoFondo = String.Empty; // 168=Rendiciones 102=Fondo Fijo
        public ProvisionesE oProvisiones = null;
        String Bloqueo = "N";
        String TipoCuenta = String.Empty;
        String TipoEstado = String.Empty; //LI=Liquidación RD=Rendición

        #endregion

        #region Procedimientos de Usuario

        void BloquearPaneles(Boolean Flag)
        {
            pnlProvision.Enabled = Flag;
            pnlDetraccion.Enabled = Flag;
            pnlMontos.Enabled = Flag;
            pnlAuditoria.Enabled = Flag;
            btArticulos.Enabled = false;
            btGastos.Enabled = false;
            btServicios.Enabled = false;
            btActivos.Enabled = false;
        }

        void LlenarCombo()
        {
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   where x.indViaticos == true
                                                                   //&& x.indBaja == false
                                                                   orderby x.idDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);
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
            ListaDocumentos = null;
            ListaMoneda = null;
            oListaTipoCompras = null;
            Fila = null;
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
            oProvisiones.Ruc = txtRuc.Text;
            oProvisiones.RazonSocial = txtRazonSocial.Text;
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

            oProvisiones.DesEstado = txtDesEstado.Text;
            oProvisiones.CodMonedaProvision = cboMoneda.SelectedValue.ToString();
            oProvisiones.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
            oProvisiones.ImpMonedaOrigen = Convert.ToDecimal(txtImporteOrigen.Text);
            oProvisiones.AnioPeriodo = dtpFechaProvision.Value.ToString("yyyy");
            oProvisiones.MesPeriodo = dtpFechaProvision.Value.ToString("MM");

            if (String.IsNullOrEmpty(oProvisiones.numVoucher))
            {
                oProvisiones.numVoucher = String.Empty;
            }

            if (String.IsNullOrEmpty(oProvisiones.AnioPeriodo))
            {
                oProvisiones.AnioPeriodo = String.Empty;
            }

            if (String.IsNullOrEmpty(oProvisiones.MesPeriodo))
            {
                oProvisiones.MesPeriodo = String.Empty;
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
            oProvisiones.tipPartidaPresu = String.Empty;
            oProvisiones.CodPartidaPresu = String.Empty;
            oProvisiones.NumVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            oProvisiones.codCuenta = txtCodCuenta.Text;
            oProvisiones.DesCuenta = txtDesCuenta.Text;
            oProvisiones.DesProvision = txtDesProvision.Text;
            oProvisiones.idRecepcion = (Nullable<Int32>)null;
            oProvisiones.NumGuia = txtGuia.Text.Trim();
            oProvisiones.idPlantilla = (Nullable<Int32>)null;
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
                oProvisiones.retNumero = String.Empty;
                oProvisiones.retFecha = null;
                oProvisiones.TipoDetraccion = String.Empty;
                oProvisiones.TasaDetraccion = 0;
                oProvisiones.MontoDetraccion = 0;
                oProvisiones.indPagoDetra = false;
            }

            oProvisiones.idCompraFile = Convert.ToInt32(cboTipoAsiento.SelectedValue);
            oProvisiones.indHojaCosto = chkIndCosto.Checked;
            oProvisiones.idHojaCosto = chkIndCosto.Checked ? Convert.ToInt32(txtNumHojaCosto.Text) : (Int32?)null;
            oProvisiones.indDistribucion = false;

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
            oProvisiones.indNoDom = false;
            oProvisiones.idDocCredFiscal = String.Empty;
            oProvisiones.depAduanera = null;
            oProvisiones.serDocCredFiscal = String.Empty;
            oProvisiones.AnioDua = String.Empty;
            oProvisiones.numDocCredFiscal = String.Empty;
            oProvisiones.RentaBruta = 0;
            oProvisiones.TasaRetencion = 0;
            oProvisiones.RentaNeta = 0;
            oProvisiones.impRetenido = 0;
            oProvisiones.idTasaRenta = String.Empty;
            oProvisiones.codCuentaRenta = String.Empty;
            oProvisiones.indIgvNoDom = false;
            oProvisiones.IgvNoDom = 0;
            oProvisiones.indReversion = false;
            oProvisiones.idProvisionRev = null;

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oProvisiones.UsuarioRegistro = oProvisiones.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oProvisiones.FechaRegistro = oProvisiones.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oProvisiones.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oProvisiones.FechaModificacion = VariablesLocales.FechaHoy;
            }
        }

        void Calcular()
        {
            if (oProvisiones.ListaPorCCosto != null && oProvisiones.ListaPorCCosto.Count > 0)
            {
                Decimal TotalS = oProvisiones.ListaPorCCosto.Sum(x => x.impSoles);
                Decimal TotalD = oProvisiones.ListaPorCCosto.Sum(x => x.impDolares);
                Decimal subTotal = (from x in oProvisiones.ListaPorCCosto where x.indIgv == true select x.subTotal).Sum();
                Decimal subTotalExo = (from x in oProvisiones.ListaPorCCosto where x.indIgv == false select x.subTotal).Sum();
                Decimal Igv = oProvisiones.ListaPorCCosto.Sum(x => x.Igv);
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

                //Soles
                txtTotal.Text = TotalS.ToString("N2");
                txtAjuste.Text = "0.00";

                //Dólares
                txtTotalSecu.Text = TotalD.ToString("N2");
                txtAjusteSecu.Text = "0.00";

                if (chkDetraccion.Checked)
                {
                    CalcularDetraccion();
                }
            }
        }

        Int32 AñadirDias()
        {
            Int32.TryParse(txtNumDiasVen.Text, out int Dias);

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

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oProvisiones != null)
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
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

                if (oProvisiones.fecDocumentoRef != null)
                {
                    dtpFecRef.Value = Convert.ToDateTime(oProvisiones.fecDocumentoRef);
                }
                
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
                txtGuia.Text = oProvisiones.NumGuia;
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
                chkIndDistribucion.Checked = false; ///oProvisiones.indDistribucion;

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

                txtUsuRegistro.Text = oProvisiones.UsuarioRegistro;
                txtFechaRegistro.Text = oProvisiones.FechaRegistro.ToString();
                txtUsuModificacion.Text = oProvisiones.UsuarioModificacion;
                txtFechaModificacion.Text = oProvisiones.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
            }
            else
            {
                oProvisiones = new ProvisionesE
                {
                    idEmpresa = VariablesLocales.SesionLocal.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    EstadoProvision = TipoEstado,
                    indReparable = "N",
                    idConceptoRep = 0,
                    desReferenciaRep = String.Empty,
                    idSistema = 6, //Módulo de Tesoreria
                    EsLiquidacion = (TipoEstado == "LI" ? true : false),
                    EsRendicion = (TipoEstado == "LI" ? false : true)
                };

                txtDesEstado.Text = TipoEstado == "LI" ? "LIQUIDACION" : "RENDICION";
                dtpFecDocumento.Value = VariablesLocales.FechaHoy.Date;
                dtpFechaProvision.Value = VariablesLocales.FechaHoy.Date;
                txtNumDiasVen.Text = "0";

                cboDocumento.SelectedValue = EnumTipoDocumentoVenta.FC.ToString();
                cboDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                cboMoneda_SelectionChangeCommitted(new object(), new EventArgs());

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;

                //Jeritec... AyV... Power Seed
                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")
                {
                    if (TipoEstado == "LI")
                    {
                        cboTipoAsiento.Enabled = TipoFondo == "102";
                        btArticulos.Visible = TipoFondo == "102"; 
                    }

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217") //Jeritec
                    {
                        cboTipoAsiento.SelectedValue = 11;
                    }

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681") //AyV
                    {
                        cboTipoAsiento.SelectedValue = 16;
                    }

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410") //Power Seed
                    {
                        cboTipoAsiento.SelectedValue = 7;
                    }

                    cboTipoAsiento_SelectionChangeCommitted(new Object(), new EventArgs());
                }
            }

            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
            bsprovisionesccosto.ResetBindings(false);
            dgvprovisionesccosto.AutoResizeColumns();
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
                ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "07" || ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "08")
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

                if (oProvisiones != null)
                {
                    DatosPorGrabar();

                    if (!ValidarGrabacion()) { return; }

                    VariablesLocales.EsLiquidacion = Variables.NO;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmProvisionLiquidacion_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                LlenarCombo();
                Nuevo();

                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                {
                    dgvprovisionesccosto.Columns[12].Visible = true;
                }

                if (TipoEstado == "LI")
                {
                    VariablesLocales.EsLiquidacion = Variables.SI;
                }
                else
                {
                    VariablesLocales.EsLiquidacion = Variables.NO;
                }

                chkPagoDetra.Text = VariablesLocales.SesionUsuario.Empresa.NombreComercial + " Paga Detracción";
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

        private void txtCodCuenta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && String.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                        VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                        txtCodCuenta.Text,
                                                                                                                        Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
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
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuenta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    List<PlanCuentasE> oListaCuentas = AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
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
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
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

                if (txtNumDiasVen.Text == "0" || String.IsNullOrEmpty(txtNumDiasVen.Text.Trim()))
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

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
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

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
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
            txtIdProveedor.Text = String.Empty;
            txtRuc.Text = String.Empty;
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

                frmProvisionCosto oFrm = new frmProvisionCosto(dtpFecDocumento.Value, Columna, cboMoneda.SelectedValue.ToString(), false);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    if (oFrm.Detalle != null)
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
                        if (oFrm.oArticulo != null && oFrm.oArticulo.indDetraccion)
                        {
                            chkDetraccion.Checked = oFrm.oArticulo.indDetraccion;

                            if (chkDetraccion.Checked)
                            {
                                if (oProvisiones.ListaPorCCosto.Count == 0)
                                {
                                    //chkDetraccion.Enabled = false;
                                    //cbotipodetraccion.Enabled = false;
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

                    frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(oGasto.IdParTabla, dtpFecDocumento.Value, "G", Columna, cboMoneda.SelectedValue.ToString(), false, Bloqueo, TipoCuenta);

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
                        }

                        if (oFrm.oListaCompras != null && oFrm.oListaCompras.Count > 0)
                        {
                            oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>(oFrm.oListaCompras);
                            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                            bsprovisionesccosto.ResetBindings(false);
                        }

                        if (oFrm.oConcepto != null && oFrm.oConcepto.indDetraccion)
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

                    frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(oGasto.IdParTabla, dtpFecDocumento.Value, "S", Columna, cboMoneda.SelectedValue.ToString(), false, Bloqueo, TipoCuenta);

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
                        }

                        if (oFrm.oListaCompras != null && oFrm.oListaCompras.Count > 0)
                        {
                            oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>(oFrm.oListaCompras);
                            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                            bsprovisionesccosto.ResetBindings(false);
                        }

                        if (oFrm.oConcepto != null && oFrm.oConcepto.indDetraccion)
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

                    frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(oGasto.IdParTabla, dtpFecDocumento.Value, "C", Columna, cboMoneda.SelectedValue.ToString(), false, Bloqueo, TipoCuenta);

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
                        }

                        if (oFrm.oListaCompras != null && oFrm.oListaCompras.Count > 0)
                        {
                            oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>(oFrm.oListaCompras);
                            bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                            bsprovisionesccosto.ResetBindings(false);
                        }

                        if (oFrm.oConcepto != null && oFrm.oConcepto.indDetraccion)
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
            try
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
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvprovisionesccosto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && dgvprovisionesccosto.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
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

                            if (chkDetraccion.Checked)
                            {
                                Global.MensajeComunicacion("Ya hay una detracción asignada, se eliminará todo el detalle y se borrará la detracción.");

                                oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>();
                                bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                                bsprovisionesccosto.ResetBindings(false);

                                chkDetraccion.Checked = false;
                                chkDetraccion.Enabled = true;
                                txtNumDetraccion.Text = String.Empty;
                                cbotipodetraccion.Enabled = true;
                                cbotipodetraccion.SelectedValue = "0";
                                txtTasaDetra.Text = "0.00";
                                txtMontoDetraS.Text = "0.00";
                                txtMontoDetraD.Text = "0.00";
                            }
                            else
                            {
                                oProvisiones.ListaPorCCosto.RemoveAt(bsprovisionesccosto.Position);
                                bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                                bsprovisionesccosto.ResetBindings(false);
                            }

                            Calcular();
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
                            Detalle = (Provisiones_PorCCostoE)oProvisiones.ListaPorCCosto[e.RowIndex];
                            Detalle.idMoneda = cboMoneda.SelectedValue.ToString();

                            /*
                             A = Articulo
                             G = Gasto
                             S = Servicio
                             C = Activo
                             */

                            if (Detalle.Tipo != "A")
                            {
                                frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(Detalle, oProvisiones.EstadoProvision, false, Bloqueo, TipoCuenta);

                                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvisionCompra != null)
                                {
                                    oProvisiones.ListaPorCCosto[e.RowIndex] = oFrm.oProvisionCompra;
                                    bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                                    bsprovisionesccosto.ResetBindings(false);
                                    Calcular();
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
            try
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
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
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

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            oProvisiones = null;
            DialogResult = DialogResult.Cancel;
            Close();
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
                        txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                        txtNumRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                        dtpFecRef.Enabled = true;
                    }
                    else
                    {
                        cboReferencia.Enabled = false;
                        cboReferencia.SelectedValue = Variables.Cero.ToString();
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
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
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

        private void frmProvisionLiquidacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btCancelar.PerformClick();
            }
        }

        private void btConceptos_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                G = Gasto
                S = Servicio
                */

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

                frmDetalleConceptoProvision oFrm = new frmDetalleConceptoProvision(0, dtpFecDocumento.Value, "", Columna, cboMoneda.SelectedValue.ToString(), false, Bloqueo, TipoCuenta);

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
                        ItemDet.FlagHC = false;
                        txtDesProvision.Text = ItemDet.Descripcion.Trim();
                        ListaItems.Add(ItemDet);
                        bsprovisionesccosto.DataSource = ListaItems;
                        bsprovisionesccosto.ResetBindings(false);
                    }

                    if (oFrm.oListaCompras != null && oFrm.oListaCompras.Count > 0)
                    {
                        oProvisiones.ListaPorCCosto = new List<Provisiones_PorCCostoE>(oFrm.oListaCompras);
                        bsprovisionesccosto.DataSource = oProvisiones.ListaPorCCosto;
                        bsprovisionesccosto.ResetBindings(false);
                    }

                    if (oFrm.oConcepto != null && oFrm.oConcepto.indDetraccion)
                    {
                        if (!chkDetraccion.Checked)
                        {
                            chkDetraccion.Checked = true;
                            chkDetraccion.Enabled = false;
                            cbotipodetraccion.Enabled = false;
                            cbotipodetraccion.SelectedValue = oFrm.oConcepto.idTipoDetraccion.ToString();
                            txtTasaDetra.Text = oFrm.oConcepto.porImpuesto.ToString("N2");
                        }
                        else
                        {
                            if (Global.MensajeConfirmacion(String.Format("La compra ya tiene asignada una detracción, desea reemplazarla por la detracción que trae el Concepto({0}) agregado.", oFrm.oConcepto.porImpuesto.ToString("N2") + "%"), MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                cbotipodetraccion.SelectedValue = oFrm.oConcepto.idTipoDetraccion.ToString();
                                txtTasaDetra.Text = oFrm.oConcepto.porImpuesto.ToString("N2");
                            }
                        }
                    }

                    Calcular();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
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
                    txtNumHojaCosto.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
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

        #endregion

    }
}
