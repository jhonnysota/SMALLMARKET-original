using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.CtasPorCobrar;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Entidades.Almacen;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Ventas;
using ClienteWinForm.Tesoreria;

namespace ClienteWinForm.CtasPorCobrar
{
    public partial class frmPlanillaCobranzaDetalle : frmResponseBase
    {

        #region Constructor

        public frmPlanillaCobranzaDetalle()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDetalle, true);
            LlenarCombo();
        }

        //Edición
        public frmPlanillaCobranzaDetalle(CobranzasItemE oItemCobranza_, Boolean Estado, String Tipo, DateTime Fecha)
            :this()
        {
            oCobranzaItem = oItemCobranza_;
            oCobranzaItem.oListaCobranzasItemDet = AgenteCtasPorCobrar.Proxy.ListarCobranzasItemDet(oCobranzaItem.idPlanilla, oCobranzaItem.Recibo);

            if (Estado)
            {
                BloquearTodo = "S";
            }

            TipoPlanillaNemo = Tipo;
            FechaCab = Fecha;
        }

        //Nuevo
        public frmPlanillaCobranzaDetalle(DateTime Fecha, ComprobantesFileE oFile, String Tipo, String TipoCobro_)
          :this()
        {
            FechaCab = Fecha;

            if (oFile != null)
            {
                if (oFile.LLevaCuenta)
                {
                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;

                    txtCtaDestino.Text = oFile.codCuenta;
                    txtDesCtaDestino.Text = oFile.desCuenta;
                    cboMon.SelectedValue = oFile.idMoneda;

                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                }
            }

            TipoPlanillaNemo = Tipo;
            TipoCobro = TipoCobro_;
        }

        #endregion

        #region Variables

        CtasPorCobrarServiceAgent AgenteCtasPorCobrar { get { return new CtasPorCobrarServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public CobranzasItemE oCobranzaItem = null;
        DateTime FechaCab;
        String BuscarDoc = "S";
        String BloquearTodo = "N";
        String TipoPlanillaNemo = String.Empty;
        String TipoCobro = String.Empty;
        ToolTip toolTipAyuda = new ToolTip();

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMon, (from x in ListaMoneda
                                                          where x.idMoneda == "01" || x.idMoneda == "02"
                                                          orderby x.idMoneda
                                                          select x).ToList(), "idMoneda", "desAbreviatura", false);
            //////Tipo de Cobro///////
            List<TipoIngresosE> ListaIngresos = AgenteCtasPorCobrar.Proxy.TipoIngresosCombos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ListaIngresos.Add(new TipoIngresosE() { TipoCobro = "0", Descripcion = Variables.Seleccione, Tipo = "S" });
            ComboHelper.RellenarCombos(cboTipoCobranza, (from x in ListaIngresos
                                                         orderby x.Descripcion
                                                         select x).ToList(), "TipoCobro", "Descripcion", false);

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indBaja == false
                                                                      select x).ToList();
            
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos(cboDocumento, (from x in ListaDocumentos
                                                      orderby x.desDocumento
                                                      select x).ToList(), "idDocumento", "desDocumento", false);

            List<ConceptosVariosE> oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosCobranzas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListaConceptos.Add(new ConceptosVariosE() { idConcepto = 0, Descripcion = Variables.Escoger });
            ComboHelper.LlenarCombos(cboConceptoGasto, (from x in oListaConceptos orderby x.idConcepto select x).ToList(), "idConcepto", "Descripcion");
            ComboHelper.LlenarCombos(cboConceptoInteres, (from x in oListaConceptos orderby x.idConcepto select x).ToList(), "idConcepto", "Descripcion");

            oListaConceptos = null;
            ListaMoneda = null;
            ListaIngresos = null;
            ListaDocumentos = null;
        }

        void ProvisionCambio(String idMoneda)
        {
            if (cboTipoCobranza.SelectedValue != null && cboTipoCobranza.SelectedValue.ToString() != "0")
            {
                TipoIngresosE tipo = (TipoIngresosE)cboTipoCobranza.SelectedItem;

                if (String.IsNullOrWhiteSpace(txtCtaDestino.Text.Trim()) && String.IsNullOrWhiteSpace(txtDesCtaDestino.Text.Trim()))
                {
                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;

                    if (tipo.SelCuenta == "N")
                    {
                        if (cboMon.SelectedValue.ToString() == "01")
                        {
                            txtCtaDestino.Text = tipo.ctaSoles;
                            txtDesCtaDestino.Text = tipo.desCtaSoles;
                        }
                        else
                        {
                            txtCtaDestino.Text = tipo.ctaDolares;
                            txtDesCtaDestino.Text = tipo.desCtaDolar;
                        }
                    }
                    else
                    {
                        txtCtaDestino.Text = tipo.filtroCuenta.Trim();
                    }

                    if (tipo.TipoCobro == "LD") //Abono y Cancelación de Letras
                    {
                        if (String.IsNullOrWhiteSpace(txtCtaDestino.Text.Trim()) && String.IsNullOrWhiteSpace(txtDesCtaDestino.Text.Trim()))
                        {
                            if (VariablesLocales.oConParametros != null)
                            {
                                if (idMoneda == "01")
                                {
                                    txtCtaDestino.Text = VariablesLocales.oConParametros.codCtaLetraRespS;
                                    txtDesCtaDestino.Text = VariablesLocales.oConParametros.desCtaLetraRespS;
                                }
                                else
                                {
                                    txtCtaDestino.Text = VariablesLocales.oConParametros.codCtaLetraRespD;
                                    txtDesCtaDestino.Text = VariablesLocales.oConParametros.desCtaLetraRespD;
                                }
                            }
                        }
                    }

                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(txtCtaDestino.Text))
                    {
                        if (txtCtaDestino.Text.Substring(0, 2) != "10")
                        {
                            if (TipoPlanillaNemo == "PLALDES" || TipoPlanillaNemo == "PLACALET")
                            {
                                if (tipo.SelCuenta == "N")
                                {
                                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;

                                    if (cboMon.SelectedValue.ToString() == "01")
                                    {
                                        txtCtaDestino.Text = tipo.ctaSoles;
                                        txtDesCtaDestino.Text = tipo.desCtaSoles;
                                    }
                                    else
                                    {
                                        txtCtaDestino.Text = tipo.ctaDolares;
                                        txtDesCtaDestino.Text = tipo.desCtaDolar;
                                    }

                                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                                }
                            }  
                        }
                    }
                }

                if (tipo.indCtaProvision == "S")
                {
                    txtCtaProvision.TextChanged -= txtCtaProvision_TextChanged;
                    txtDesCtaProvisión.TextChanged -= txtDesCtaProvisión_TextChanged;
                    txtRucAuxiliar.TextChanged -= txtRucAuxiliar_TextChanged;
                    txtRazonAuxiliar.TextChanged -= txtRazonAuxiliar_TextChanged;

                    if (VariablesLocales.oVenParametros != null && VariablesLocales.oVenParametros.ClienteVarios != 0)
                    {
                        txtRucAuxiliar.Tag = Convert.ToInt32(VariablesLocales.oVenParametros.ClienteVarios);
                        txtRucAuxiliar.Text = VariablesLocales.oVenParametros.RUC;
                        txtRazonAuxiliar.Text = VariablesLocales.oVenParametros.RazonSocial;
                    }

                    if (idMoneda == Variables.Soles)
                    {
                        txtCtaProvision.Text = tipo.codCuentaSoles;
                        txtDesCtaProvisión.Text = tipo.desCtaProvSoles;
                    }
                    else if (idMoneda == Variables.Dolares)
                    {
                        txtCtaProvision.Text = tipo.codCuentaDolares;
                        txtDesCtaProvisión.Text = tipo.desCtaProvDolar;
                    }

                    txtCtaProvision.TextChanged += txtCtaProvision_TextChanged;
                    txtDesCtaProvisión.TextChanged += txtDesCtaProvisión_TextChanged;
                    txtRucAuxiliar.TextChanged += txtRucAuxiliar_TextChanged;
                    txtRazonAuxiliar.TextChanged += txtRazonAuxiliar_TextChanged;
                }
                else
                {
                    txtCtaProvision.Text = String.Empty;
                    txtDesCtaProvisión.Text = String.Empty;
                    txtRucAuxiliar.Tag = 0;
                    txtRucAuxiliar.Text = String.Empty;
                    txtRazonAuxiliar.Text = String.Empty;
                }

                if (tipo.indManipularMoneda)
                {
                    cboMon.Enabled = true;
                }
                else
                {
                    cboMon.Enabled = false;
                }

                Bloquear();
            }
        }

        void Totales()
        {
            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).Tipo.ToString() == "S")
            {
                if (oCobranzaItem.oListaCobranzasItemDet.Count > 0)
                {
                    Decimal TotalGeneral = 0;
                    Decimal TotalRecibido = 0;
                    Decimal tot42 = 0;
                    Decimal.TryParse(txtGasCom.Text, out Decimal Gasto);
                    Decimal.TryParse(txtInteres.Text, out Decimal Interes);

                    if (TipoPlanillaNemo != "PLALDES")
                    {
                        Decimal Total12 = 0;

                        Decimal tot12 = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                          where (x.codCuenta.Substring(0, 2) == "12" || x.codCuenta.Substring(0, 2) == "13") && x.idDocumento != "NC"
                                                         select x.MontoReci).Sum());

                        Decimal tot12NC = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                            where (x.codCuenta.Substring(0, 2) == "12" || x.codCuenta.Substring(0, 2) == "13") && x.idDocumento == "NC"
                                                           select x.MontoReci).Sum());

                        tot42 = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                   where x.codCuenta.Substring(0, 2) == "42"
                                                   select x.MontoReci).Sum());

                        TotalRecibido = Decimal.Round(tot12 - tot12NC, 2);
                        Total12 = Decimal.Round((TotalRecibido - Gasto) + Interes, 2);
                        TotalGeneral = Total12 - tot42;

                        if (TotalRecibido == 0M && TotalGeneral == 0M)
                        {
                            Decimal tot4546 = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                                 where x.codCuenta.Substring(0, 2) == "45" || x.codCuenta.Substring(0, 2) == "46"
                                                                 select x.MontoReci).Sum());

                            tot42 = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                       where x.codCuenta.Substring(0, 2) == "42"
                                                       select x.MontoReci).Sum());

                            TotalRecibido = Decimal.Round(tot4546 - tot42, 2);
                            TotalGeneral = (tot4546 - Gasto) - tot42;
                        }
                    }
                    else
                    {
                        Decimal tot4546 = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                           where x.codCuenta.Substring(0, 2) == "45" || x.codCuenta.Substring(0, 2) == "46"
                                                           select x.MontoReci).Sum());

                        tot42 = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                   where x.codCuenta.Substring(0, 2) == "42"
                                                   select x.MontoReci).Sum());

                        TotalRecibido = Decimal.Round(tot4546 - tot42, 2);
                        TotalGeneral = ((tot4546 - Gasto) + Interes) - tot42;
                    }

                    txtRecibido.Text = TotalRecibido.ToString("N2");
                    txtMonto.Text = TotalGeneral.ToString("N2");
                }
                else
                {
                    txtRecibido.Text = "0.00";
                    txtMonto.Text = "0.00";
                } 
            }
        }

        void Bloquear()
        {
            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "C" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "HP")
            {
                if (BuscarDoc == "S")
                {
                    cboDocumento.SelectedValue = "CH";
                }
                
                txtRucBanco.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesBanco.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                if (BuscarDoc == "S")
                {
                    cboDocumento.SelectedValue = "CB";
                }
                
                txtIdBanco.Text = String.Empty;
                txtRucBanco.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesBanco.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        void CalcularTiCa()
        {
            if (oCobranzaItem.oListaCobranzasItemDet.Count > 0)
            {
                Decimal totRecibido = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                         select x.MontoReci).Sum());

                Decimal totAmortizado = Convert.ToDecimal((from x in oCobranzaItem.oListaCobranzasItemDet
                                                           select x.Monto).Sum());

                if (totRecibido != 0 && totAmortizado != 0)
                {
                    Decimal Tica = totRecibido / totAmortizado;
                    txtTipCambio.Text = Tica.ToString("N3");
                } 
            }
        }

        #endregion

        #region Procesos Heredados

        public override void Nuevo()
        {
            if (oCobranzaItem == null)
            {
                oCobranzaItem = new CobranzasItemE()
                {
                    numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

                txtRucAuxiliar.Tag = 0;
                txtURegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFModificacion.Text = VariablesLocales.FechaHoy.ToString();
                
                dtpCobranza.Value = FechaCab.Date;
                dtpFecha.Value = FechaCab.Date;

                if (TipoPlanillaNemo == "PLACOMP")
                {
                    cboTipoCobranza.Enabled = false;
                    cboTipoCobranza.SelectedValue = "P";
                    txtCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtDesCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    lblFecha.Text = "Fec.Compensan.";
                    btPorPagar.Enabled = true;
                }

                if (TipoPlanillaNemo == "PLALDES" || TipoPlanillaNemo == "PLACALET")
                {
                    btPorPagar.Enabled = true;
                    btLetras.Enabled = true;
                    btTercero.Enabled = true;
                    btPendientes.Enabled = false;
                }

                if (!String.IsNullOrWhiteSpace(TipoCobro))
                {
                    cboTipoCobranza.SelectedValue = TipoCobro;
                    cboTipoCobranza_SelectionChangeCommitted(new Object(), new EventArgs());
                }
            }
            else
            {
                txtRuc.TextChanged -= txtDni_TextChanged;
                txtDesAuxiliar.TextChanged -= txtDesAuxiliar_TextChanged;
                txtRucBanco.TextChanged -= txtRucBanco_TextChanged;
                txtDesBanco.TextChanged -= txtDesBanco_TextChanged;
                txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;
                txtCtaProvision.TextChanged -= txtCtaProvision_TextChanged;
                txtDesCtaProvisión.TextChanged -= txtDesCtaProvisión_TextChanged;
                txtRucAuxiliar.TextChanged -= txtRucAuxiliar_TextChanged;
                txtRazonAuxiliar.TextChanged -= txtRazonAuxiliar_TextChanged;
                txtGasCom.TextChanged -= txtGasCom_TextChanged;
                txtInteres.TextChanged -= txtInteres_TextChanged;

                BuscarDoc = "N";
                cboTipoCobranza.SelectedValue = oCobranzaItem.TipoCobro.ToString();
                cboTipoCobranza_SelectionChangeCommitted(new Object(), new EventArgs());

                if (TipoPlanillaNemo == "PLACOMP")
                {
                    cboTipoCobranza.Enabled = false;
                    txtCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtDesCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    lblFecha.Text = "Fec.Compensan.";
                    btPorPagar.Enabled = true;
                }

                if (TipoPlanillaNemo == "PLALDES" || TipoPlanillaNemo == "PLACALET")
                {
                    btPorPagar.Enabled = true;
                    btLetras.Enabled = true;
                    btTercero.Enabled = true;
                    btPendientes.Enabled = false;
                }

                txtDescripción.Text = oCobranzaItem.Descripcion;
                txtMonto.Text = oCobranzaItem.Monto.ToString("N2");
                txtTipCambio.Text = oCobranzaItem.tipCambioReci.ToString("N3");
                cboMon.SelectedValue = oCobranzaItem.idMoneda;

                if (oCobranzaItem.fecVencimiento != null)
                {
                    dtpVen.Value = oCobranzaItem.fecVencimiento.Value;
                }

                txtCtaProvision.Text = oCobranzaItem.codCuentaProvision;
                txtDesCtaProvisión.Text = oCobranzaItem.desCtaProvision;
                txtCtaDestino.Text = oCobranzaItem.codCuenta;
                txtDesCtaDestino.Text = oCobranzaItem.desCtaDetino;
                cboConceptoGasto.SelectedValue = Convert.ToInt32(oCobranzaItem.idConceptoGasto);
                cboConceptoGasto_SelectionChangeCommitted(new Object(), new EventArgs());
                cboConceptoInteres.SelectedValue = Convert.ToInt32(oCobranzaItem.idConceptoInteres);
                cboConceptoInteres_SelectionChangeCommitted(new Object(), new EventArgs());
                txtInteres.Text = Convert.ToString(oCobranzaItem.Interes);
                txtGasCom.Text = Convert.ToString(oCobranzaItem.Comision);
                dtpFecha.Value = FechaCab.Date;
                dtpCobranza.Value = oCobranzaItem.fecCobranza.Value;
                chkDifCancelado.Checked = oCobranzaItem.cheDifCancelando;
                txtIdBanco.Text = oCobranzaItem.idBanco.ToString();
                txtSerie.Text = oCobranzaItem.numSerie;
                txtCheque.Text = oCobranzaItem.numCheque;

                if (oCobranzaItem.idBanco != null && oCobranzaItem.idBanco != 0)
                {
                    txtIdBanco.Text = oCobranzaItem.idBanco.ToString();
                    txtRucBanco.Text = oCobranzaItem.RucBanco;
                    txtDesBanco.Text = oCobranzaItem.desBanco;
                }
                else
                {
                    txtIdBanco.Text = String.Empty;
                    txtRucBanco.Text = String.Empty;
                    txtDesBanco.Text = String.Empty;
                }

                if (((TipoIngresosE)cboTipoCobranza.SelectedItem).Tipo.ToString() == "N")
                {
                    if (Convert.ToInt32(oCobranzaItem.idPersona) == 0)
                    {
                        txtRucAuxiliar.Tag = 0;
                    }
                    else
                    {
                        txtRucAuxiliar.Tag = Convert.ToInt32(oCobranzaItem.idPersona);
                        txtRucAuxiliar.Text = oCobranzaItem.RucAuxiliar;
                        txtRazonAuxiliar.Text = oCobranzaItem.desAuxiliar;
                    } 
                }
                else
                {
                    txtRucAuxiliar.Tag = 0;
                }

                txtURegistro.Text = oCobranzaItem.UsuarioRegistro;
                txtFRegistro.Text = oCobranzaItem.FechaRegistro.ToString();
                txtUModificacion.Text = oCobranzaItem.UsuarioModificacion;
                txtFModificacion.Text = oCobranzaItem.FechaModificacion.ToString();
                cboDocumento.SelectedValue = String.IsNullOrWhiteSpace(oCobranzaItem.idDocumento) ? "0" : oCobranzaItem.idDocumento;
                oCobranzaItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtRuc.TextChanged += txtDni_TextChanged;
                txtDesAuxiliar.TextChanged += txtDesAuxiliar_TextChanged;
                txtRucBanco.TextChanged += txtRucBanco_TextChanged;
                txtDesBanco.TextChanged += txtDesBanco_TextChanged;
                txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                txtCtaProvision.TextChanged += txtCtaProvision_TextChanged;
                txtDesCtaProvisión.TextChanged += txtDesCtaProvisión_TextChanged;
                txtRucAuxiliar.TextChanged += txtRucAuxiliar_TextChanged;
                txtRazonAuxiliar.TextChanged += txtRazonAuxiliar_TextChanged;
                txtGasCom.TextChanged += txtGasCom_TextChanged;
                txtInteres.TextChanged += txtInteres_TextChanged;

                Bloquear();
                BuscarDoc = "S";
            }

            bsBase.DataSource = oCobranzaItem.oListaCobranzasItemDet;
            bsBase.ResetBindings(false);
            Totales();

            if (BloquearTodo == "S")
            {
                pnlBase.Enabled = false;
                pnlOtros.Enabled = false;
                btPendientes.Enabled = false;
                btPorPagar.Enabled = false;
                btLetras.Enabled = false;
                btTercero.Enabled = false;
                btEliminarCanje.Enabled = false;
                btAceptar.Enabled = false;
                dgvDetalle.ReadOnly = true;
            }
        }

        public override void Aceptar()
        {
            if (!ValidarGrabacion())
            {
                return;
            }

            oCobranzaItem.Fecha = dtpFecha.Value.Date;
            oCobranzaItem.idMoneda = Convert.ToString(cboMon.SelectedValue);
            oCobranzaItem.desMoneda = ((MonedasE)cboMon.SelectedItem).desAbreviatura;
            oCobranzaItem.Monto = Convert.ToDecimal(txtMonto.Text);
            oCobranzaItem.TipoCobro = Convert.ToString(cboTipoCobranza.SelectedValue);
            oCobranzaItem.Descripcion = txtDescripción.Text;
            oCobranzaItem.tipCambioReci = Convert.ToDecimal(txtTipCambio.Text);

            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "LP" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "HP")
            {
                oCobranzaItem.fecVencimiento = Convert.ToDateTime(dtpVen.Value);
            }
            else
            {
                oCobranzaItem.fecVencimiento = (DateTime?)null;
            }
            
            oCobranzaItem.fecCobranza = dtpCobranza.Value.Date;
            oCobranzaItem.idDocumento = Convert.ToString(cboDocumento.SelectedValue) == "0" ? String.Empty : Convert.ToString(cboDocumento.SelectedValue);
            oCobranzaItem.numSerie = txtSerie.Text.Trim();
            oCobranzaItem.numCheque = txtCheque.Text;
            oCobranzaItem.Comision = Convert.ToDecimal(txtGasCom.Text);
            oCobranzaItem.Interes =  Convert.ToDecimal(txtInteres.Text);
            oCobranzaItem.codCuenta = txtCtaDestino.Text;
            oCobranzaItem.codCuentaProvision = txtCtaProvision.Text;
            oCobranzaItem.idConceptoGasto = Convert.ToInt32(cboConceptoGasto.SelectedValue) == 0 ? (Int32?)null : Convert.ToInt32(cboConceptoGasto.SelectedValue);
            oCobranzaItem.idConceptoInteres = Convert.ToInt32(cboConceptoInteres.SelectedValue) == 0 ? (Int32?)null : Convert.ToInt32(cboConceptoInteres.SelectedValue);

            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "C" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "HP")
            {
                oCobranzaItem.idBanco = Convert.ToInt32(txtIdBanco.Text);
            }
            else
            {
                oCobranzaItem.idBanco = (int?)null;
            }

            if (chkIndPresupuesto.Checked)
            {
                oCobranzaItem.tipPartidaPresu = txtTipPartida.Text.Trim();
                oCobranzaItem.idPartidaPresu = txtCodPartida.Text;
            }
            else
            {
                oCobranzaItem.tipPartidaPresu = String.Empty;
                oCobranzaItem.idPartidaPresu = String.Empty;
            }
            
            oCobranzaItem.cheDifCancelando =  chkDifCancelado.Checked;

            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).Tipo.ToString() == "N")
            {
                if (Convert.ToInt32(txtRucAuxiliar.Tag) == 0)
                {
                    oCobranzaItem.idPersona = null;
                }
                else
                {
                    oCobranzaItem.idPersona = Convert.ToInt32(txtRucAuxiliar.Tag);
                }
            }
            else
            {
                oCobranzaItem.idPersona = null;
            }

            if (oCobranzaItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oCobranzaItem.UsuarioRegistro = txtURegistro.Text;
                oCobranzaItem.FechaRegistro = VariablesLocales.FechaHoy;
                oCobranzaItem.UsuarioModificacion = txtUModificacion.Text;
                oCobranzaItem.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oCobranzaItem.UsuarioModificacion = txtUModificacion.Text;
                oCobranzaItem.FechaModificacion = VariablesLocales.FechaHoy;
            }

            base.Aceptar();
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<CobranzasItemE>(oCobranzaItem);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            if (cboTipoCobranza.SelectedValue.ToString() == "0")
            {
                Global.MensajeFault("Debe escoger un tipo de cobro.");
                return false;
            }

            if (cboTipoCobranza.SelectedValue.ToString() != "P" && cboTipoCobranza.SelectedValue.ToString() != "CR") //Diferente a compensanciones y Aplicacion Nota de Credito
            {
                if (String.IsNullOrWhiteSpace(txtCtaDestino.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar una cuenta de destino.");
                    return false;
                } 
            }

            if (String.IsNullOrWhiteSpace(txtCheque.Text.Trim()) && cboTipoCobranza.SelectedValue.ToString() != "CR")
            {
                Global.MensajeFault("Debe ingresar numero de documento");
                return false;
            }

            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).indCtaProvision == "S")
            {
                if (String.IsNullOrWhiteSpace(txtCtaProvision.Text.Trim()))
                {
                    Global.MensajeFault("No esta configurada la cuenta de provisión en el tipo de cobranza.");
                    return false;
                }
            }

            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "C" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "HP")
            {
                if (String.IsNullOrWhiteSpace(txtIdBanco.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar un Banco.");
                    return false;
                }
            }

            if (Convert.ToDecimal(txtGasCom.Text) > 0)
            {
                if (String.IsNullOrWhiteSpace(((ConceptosVariosE)cboConceptoGasto.SelectedItem).codCuentaAdm))
                {
                    Global.MensajeFault("El concepto de Gasto/Comisión escogido, no tiene configurado ninguna cuenta contable.");
                    return false;
                }
            }

            if (Convert.ToDecimal(txtInteres.Text) > 0)
            {
                if (String.IsNullOrWhiteSpace(((ConceptosVariosE)cboConceptoInteres.SelectedItem).codCuentaAdm))
                {
                    Global.MensajeFault("El concepto de Interés escogido, no tiene configurado ninguna cuenta contable.");
                    return false;
                }
            }

            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).Tipo.ToString() == "S")
            {
                Decimal.TryParse(txtGasCom.Text, out Decimal Gasto);
                Decimal.TryParse(txtInteres.Text, out Decimal Interes);
                Decimal.TryParse(txtMonto.Text, out Decimal Monto);
                Decimal.TryParse(txtRecibido.Text, out Decimal Recibido);

                if (((Monto - Interes) + Gasto) != Recibido)
                {
                    Global.MensajeFault("El Monto no coincide con el Total Recibido.");
                    return false;
                } 
            }

            if (TipoPlanillaNemo == "PLAANC")
            {
                List<CobranzasItemDetE> DocumentosVentas = new List<CobranzasItemDetE>((from x in oCobranzaItem.oListaCobranzasItemDet where x.idDocumento != "NC" select x).ToList());

                if (DocumentosVentas.Count > 1)
                {
                    Global.MensajeFault("El registro solo puede tener solo un documento de venta.");
                    return false;
                }
            }

            if (txtTipCambio.Text == "0.000")
            {
                Global.MensajeFault("Debe colocar una Fecha de Cancelación con Tipo de Cambio o colocar un Tipo de Cambio manualmente.");
                return false;
            }

            return base.ValidarGrabacion();
        }
        
        #endregion

        #region Eventos

        private void frmPlanillaCobranzaDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
            
            txtCtaDestino.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
            txtCtaProvision.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
        }

        private void txtDesAuxiliar_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtDesAuxiliar.Text = String.Empty;
        }

        private void txtDesAuxiliar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtDesAuxiliar.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtDni_TextChanged;
                    txtDesAuxiliar.TextChanged -= txtDesAuxiliar_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtDesAuxiliar.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtDesAuxiliar.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtDesAuxiliar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtDesAuxiliar.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Auxiliar ingresado no existe");
                        txtDesAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRuc.Tag = 0;
                        txtRuc.Focus();
                    }

                    txtDesAuxiliar.TextChanged += txtDesAuxiliar_TextChanged;
                    txtRuc.TextChanged += txtDni_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDni_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtDesAuxiliar.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtDni_TextChanged;
                    txtDesAuxiliar.TextChanged -= txtDesAuxiliar_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtDesAuxiliar.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtDesAuxiliar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtDesAuxiliar.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Text = String.Empty;
                        txtRuc.Tag = 0;
                        txtDesAuxiliar.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtDni_TextChanged;
                    txtDesAuxiliar.TextChanged += txtDesAuxiliar_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoCobranza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (BuscarDoc == "S")
                {
                    ProvisionCambio(cboMon.SelectedValue.ToString());
                }

                if (((TipoIngresosE)cboTipoCobranza.SelectedItem).Tipo.ToString() == "N")
                {
                    txtRucAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtRazonAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
                else
                {
                    txtRucAuxiliar.Tag = 0;
                    txtRucAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtRazonAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                }

                if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "CR")
                {
                    txtCheque.Tag = 0;
                    txtCheque.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtCheque.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtSerie.Tag = 0;
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    cboDocumento.SelectedValue = "0";
                    cboDocumento.Enabled = false;
                    txtDesCtaDestino.Tag = 0;
                    txtDesCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtDesCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtCtaDestino.Tag = 0;
                    txtCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                }
                else
                {
                    txtCheque.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtCheque.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    cboDocumento.Enabled = true;
                    txtDesCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtDesCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtRuc.Tag) == 0)
                {
                    Global.MensajeComunicacion("Debe ingresar un auxiliar antes de sacar los pendientes.");
                    return;
                }

                String Tipo = "DC"; //Documentos por cobrar

                if (TipoPlanillaNemo == "PLACLT")
                {
                    Tipo = "DE"; //Documentos
                }

                frmPendientesAuxiliarVentas oFrm = new frmPendientesAuxiliarVentas(Convert.ToInt32(txtRuc.Tag), txtRuc.Text.Trim(), txtDesAuxiliar.Text.Trim(), Tipo);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte != null && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    foreach (CtaCteE item in oFrm.oListaCtaCte)
                    {
                        CobranzasItemDetE oCobranDetItem = new CobranzasItemDetE
                        {
                            idPersona = item.idPersona,
                            Ruc = item.RUC,
                            RazonSocial = item.RazonSocial,
                            idDocumento = item.idDocumento,
                            numSerie = item.numSerie,
                            numDocumento = item.numDocumento,
                            fecEmision = item.FechaDocumento,
                            idMoneda = item.idMoneda,
                            Moneda = item.desMoneda
                        };

                        if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "CR")
                        {
                            oCobranDetItem.idMonedaReci = item.idMoneda;
                            oCobranDetItem.MonedaReci = item.desMoneda;
                            oCobranDetItem.idMoneda = item.idMoneda;
                            oCobranDetItem.Moneda = item.desMoneda;
                        }
                        else
                        {
                            oCobranDetItem.idMonedaReci = cboMon.SelectedValue.ToString();
                            oCobranDetItem.MonedaReci = ((MonedasE)cboMon.SelectedItem).desAbreviatura;
                        }
                        
                        oCobranDetItem.Monto = item.Saldo;
                        oCobranDetItem.tipCambioReci = VariablesLocales.MontoTicaConta(oCobranDetItem.fecEmision.Value.Date, Variables.Dolares); //item.TipoCambio;

                        if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "R" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "T")
                        {

                        }
                        else
                        {
                            if (oCobranDetItem.idMoneda == oCobranDetItem.idMonedaReci.ToString())
                            {
                                oCobranDetItem.MontoReci = Convert.ToDecimal(item.Saldo);
                            }
                            else
                            {
                                if (oCobranDetItem.idMoneda == Variables.Dolares)
                                {
                                    oCobranDetItem.MontoReci = Decimal.Round(Convert.ToDecimal(item.Saldo) * Convert.ToDecimal(txtTipCambio.Text), 2);
                                }
                                else
                                {
                                    oCobranDetItem.MontoReci = Decimal.Round(Convert.ToDecimal(item.Saldo) / Convert.ToDecimal(txtTipCambio.Text), 2);
                                }
                            }
                        }
                                                
                        oCobranDetItem.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                        oCobranDetItem.codCuenta = item.codCuenta;
                        oCobranDetItem.fecVencimiento = item.FechaDocumento;
                        oCobranDetItem.idCtaCte = item.idCtaCte; //Cta. Cte.
                        oCobranDetItem.LetraEndosadaA = null;
                        oCobranDetItem.indTercero = false;
                        oCobranDetItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oCobranDetItem.FechaRegistro = VariablesLocales.FechaHoy;
                        oCobranDetItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oCobranDetItem.FechaModificacion = VariablesLocales.FechaHoy;
                           
                        oCobranDetItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oCobranzaItem.oListaCobranzasItemDet.Add(oCobranDetItem);
                    }

                    bsBase.DataSource = oCobranzaItem.oListaCobranzasItemDet;
                    bsBase.ResetBindings(false);
                    Totales();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminarCanje_Click(object sender, EventArgs e)
        {
            try
            {
                if (oCobranzaItem.oListaCobranzasItemDet != null && oCobranzaItem.oListaCobranzasItemDet.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        //Inicializando la lista de los canjes eliminados
                        if (oCobranzaItem.oListaDetalleEliminado == null)
                        {
                            oCobranzaItem.oListaDetalleEliminado = new List<CobranzasItemDetE>();
                        }
                        
                        //Agregando a la lista de eliminados
                        oCobranzaItem.oListaDetalleEliminado.Add((CobranzasItemDetE)bsBase.Current);
                        //AgenteCtasPorCobrar.Proxy.EliminarCobranzasItemDet(((CobranzasItemDetE)bsBase.Current).idPlanilla, ((CobranzasItemDetE)bsBase.Current).Recibo,((CobranzasItemDetE)bsBase.Current).item);
                        //Removiendo de la lista principal(temporalmente)...
                        oCobranzaItem.oListaCobranzasItemDet.RemoveAt(bsBase.Position);
                        //Actualizando la lista...
                        bsBase.DataSource = oCobranzaItem.oListaCobranzasItemDet;
                        bsBase.ResetBindings(false);
                        Totales();
                    }
                }
                else
                {
                    Global.MensajeFault("No Existen Registros");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDestino_TextChanged(object sender, EventArgs e)
        {
            //txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;
            txtDesCtaDestino.Text = String.Empty;
            //txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
        }

        private void txtDesCtaDestino_TextChanged(object sender, EventArgs e)
        {
            //txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
            txtCtaDestino.Text = String.Empty;
            //txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
        }

        private void txtCtaDestino_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDestino.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaDestino.Text.Trim()))
                {
                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDestino.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDestino.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDestino.Text = oFrm.oCuenta.Descripcion;
                            cboMon.SelectedValue = oFrm.oCuenta.idMoneda.ToString();
                        }
                        else
                        {
                            txtCtaDestino.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDestino.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDestino.Text = oListaCuentas[0].Descripcion;
                        cboMon.SelectedValue = oListaCuentas[0].idMoneda.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDestino.Text = String.Empty;
                        txtDesCtaDestino.Text = String.Empty;
                        txtCtaProvision.Text = String.Empty;
                        txtDesCtaProvisión.Text = String.Empty;
                    }

                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDestino_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDestino.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaDestino.Text.Trim()))
                {
                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaDestino.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDestino.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDestino.Text = oFrm.oCuenta.Descripcion;
                            cboMon.SelectedValue = oListaCuentas[0].idMoneda.ToString();
                        }
                        else
                        {
                            txtDesCtaDestino.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDestino.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDestino.Text = oListaCuentas[0].Descripcion;
                        cboMon.SelectedValue = oListaCuentas[0].idMoneda.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDestino.Text = String.Empty;
                        txtDesCtaDestino.Text = String.Empty;
                        txtCtaProvision.Text = String.Empty;
                        txtDesCtaProvisión.Text = String.Empty;
                    }

                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaProvision_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaProvisión.TextChanged -= txtDesCtaProvisión_TextChanged;
            txtDesCtaProvisión.Text = String.Empty;
            txtDesCtaProvisión.TextChanged += txtDesCtaProvisión_TextChanged;
        }

        private void txtDesCtaProvisión_TextChanged(object sender, EventArgs e)
        {
            txtCtaProvision.TextChanged -= txtCtaProvision_TextChanged;
            txtCtaProvision.Text = String.Empty;
            txtCtaProvision.TextChanged += txtCtaProvision_TextChanged;
        }

        private void txtCtaProvision_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaProvision.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaProvisión.Text.Trim()))
                {
                    txtCtaProvision.TextChanged -= txtCtaProvision_TextChanged;
                    txtDesCtaProvisión.TextChanged -= txtDesCtaProvisión_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaProvision.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaProvision.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaProvisión.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaProvision.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaProvision.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaProvisión.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaProvision.Text = String.Empty;
                        txtDesCtaProvisión.Text = String.Empty;
                    }

                    txtCtaProvision.TextChanged += txtCtaProvision_TextChanged;
                    txtDesCtaProvisión.TextChanged += txtDesCtaProvisión_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaProvision.TextChanged += txtCtaProvision_TextChanged;
                txtDesCtaProvisión.TextChanged += txtDesCtaProvisión_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaProvisión_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaProvision.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaProvisión.Text.Trim()))
                {
                    txtCtaProvision.TextChanged -= txtCtaProvision_TextChanged;
                    txtDesCtaProvisión.TextChanged -= txtDesCtaProvisión_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaProvisión.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaProvision.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaProvisión.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaProvisión.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaProvision.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaProvisión.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaProvision.Text = String.Empty;
                        txtDesCtaProvisión.Text = String.Empty;
                    }

                    txtCtaProvision.TextChanged += txtCtaProvision_TextChanged;
                    txtDesCtaProvisión.TextChanged += txtDesCtaProvisión_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaProvision.TextChanged += txtCtaProvision_TextChanged;
                txtDesCtaProvisión.TextChanged += txtDesCtaProvisión_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void btPresupuesto_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarPartida oFrm = new frmBuscarPartida();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
                {
                    txtCodPartida.Text = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                    txtCodPartida.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                    txtDesPartida.Text = oFrm.oPartidaPresupuestal.desPartidaPresu;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRucBanco_TextChanged(object sender, EventArgs e)
        {
            txtDesBanco.TextChanged -= txtDesBanco_TextChanged;
            txtIdBanco.Text = String.Empty;
            txtDesBanco.Text = String.Empty;
            txtDesBanco.TextChanged += txtDesBanco_TextChanged;
        }

        private void txtDesBanco_TextChanged(object sender, EventArgs e)
        {
            txtRucBanco.TextChanged -= txtRucBanco_TextChanged;
            txtIdBanco.Text = String.Empty;
            txtRucBanco.Text = String.Empty;
            txtRucBanco.TextChanged += txtRucBanco_TextChanged;
        }

        private void txtRucBanco_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRucBanco.Text.Trim()) && String.IsNullOrEmpty(txtDesBanco.Text.Trim()))
                {
                    txtRucBanco.TextChanged -= txtRucBanco_TextChanged;
                    txtDesBanco.TextChanged -= txtDesBanco_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucBanco.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucBanco.Text = oFrm.oPersona.RUC;
                            txtIdBanco.Text = oFrm.oPersona.IdPersona.ToString();
                            txtDesBanco.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRucBanco.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRucBanco.Text = oListaPersonas[0].RUC;
                        txtIdBanco.Text = oListaPersonas[0].IdPersona.ToString();
                        txtDesBanco.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRucBanco.Text = String.Empty;
                        txtIdBanco.Text = String.Empty;
                        txtDesBanco.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRucBanco.TextChanged -= txtRucBanco_TextChanged;
                    txtDesBanco.TextChanged -= txtDesBanco_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRucBanco.TextChanged += txtRucBanco_TextChanged;
                txtDesBanco.TextChanged += txtDesBanco_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesBanco_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtDesBanco.Text.Trim()) && String.IsNullOrEmpty(txtRucBanco.Text.Trim()))
                {
                    txtRucBanco.TextChanged -= txtRucBanco_TextChanged;
                    txtDesBanco.TextChanged -= txtDesBanco_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtDesBanco.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucBanco.Text = oFrm.oPersona.RUC;
                            txtIdBanco.Text = oFrm.oPersona.IdPersona.ToString();
                            txtDesBanco.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtDesBanco.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRucBanco.Text = oListaPersonas[0].RUC;
                        txtIdBanco.Text = oListaPersonas[0].IdPersona.ToString();
                        txtDesBanco.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Auxiliar ingresado no existe");
                        txtDesBanco.Text = String.Empty;
                        txtRucBanco.Text = String.Empty;
                        txtIdBanco.Text = String.Empty;
                        txtDesBanco.Focus();
                    }

                    txtRucBanco.TextChanged += txtRucBanco_TextChanged;
                    txtDesBanco.TextChanged += txtDesBanco_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRucBanco.TextChanged += txtRucBanco_TextChanged;
                txtDesBanco.TextChanged += txtDesBanco_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpCobranza_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpVen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            txtMonto.Text = Global.FormatoDecimal(txtMonto.Text);
        }

        private void txtGasCom_Leave(object sender, EventArgs e)
        {
            txtGasCom.Text = Global.FormatoDecimal(txtGasCom.Text);
        }

        private void txtInteres_Leave(object sender, EventArgs e)
        {
            txtInteres.Text = Global.FormatoDecimal(txtInteres.Text);
        }

        private void dtpCobranza_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (BuscarDoc == "S")
                {
                    Decimal Monto = VariablesLocales.MontoTicaConta(dtpCobranza.Value.Date, cboMon.SelectedValue.ToString());
                    txtTipCambio.Text = Monto.ToString("N3"); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkIndPresupuesto_CheckedChanged(object sender, EventArgs e)
        {
            btPresupuesto.Enabled = chkIndPresupuesto.Checked;
        }

        private void cboConceptoGasto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboConceptoGasto.SelectedValue) != 0)
                {
                    txtGasCom.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtGasCom.Focus();
                }
                else
                {
                    txtGasCom.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtGasCom.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboConceptoInteres_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboConceptoInteres.SelectedValue) != 0)
                {
                    txtInteres.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtInteres.Focus();
                }
                else
                {
                    txtInteres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtInteres.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #region Eventos Detalle

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    String nomColumn = dgvDetalle.Columns[e.ColumnIndex].Name;

                    if (nomColumn == "Monto" || nomColumn == "MontoReci" )
                    {
                        dgvDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                        e.CellStyle.BackColor = Valores.ColorColumnas;
                    }
                    else
                    {
                        dgvDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (CobranzasItemDetE item in oCobranzaItem.oListaCobranzasItemDet)
                {
                    if (item.Opcion == 0)
                    {
                        item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                    }
                }

                Totales();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetalle.Rows.Count > Variables.Cero)
                {
                    DataGridViewCell cellMoneda = dgvDetalle.Rows[e.RowIndex].Cells["idMoneda"];

                    if (dgvDetalle.Columns[e.ColumnIndex].Name == "MontoReci")
                    {
                        DataGridViewCell cellMonto = dgvDetalle.Rows[e.RowIndex].Cells["Monto"];
                        DataGridViewCell cellMontoReci = dgvDetalle.Rows[e.RowIndex].Cells["MontoReci"];

                        if ((String)dgvDetalle.Rows[e.RowIndex].Cells["idMoneda"].Value == cboMon.SelectedValue.ToString())
                        {
                            cellMonto.Value = cellMontoReci.Value;
                        }
                        else
                        {
                            CalcularTiCa();
                            Decimal TiCa = Convert.ToDecimal(txtTipCambio.Text);

                            if (!((TipoIngresosE)cboTipoCobranza.SelectedItem).indManipularMontos)
                            {
                                if (cellMoneda.Value.ToString() == Variables.Dolares)
                                {
                                    cellMonto.Value = Convert.ToDecimal(cellMontoReci.Value) / TiCa;
                                }
                                else
                                {
                                    cellMonto.Value = Convert.ToDecimal(cellMontoReci.Value) * TiCa;
                                }
                            }
                        }
                    }

                    if (dgvDetalle.Columns[e.ColumnIndex].Name == "Monto" )
                    {
                        DataGridViewCell cellMonto = dgvDetalle.Rows[e.RowIndex].Cells["Monto"];
                        DataGridViewCell cellMontoReci = dgvDetalle.Rows[e.RowIndex].Cells["MontoReci"];
                        

                        if ((String)dgvDetalle.Rows[e.RowIndex].Cells["idMoneda"].Value == cboMon.SelectedValue.ToString())
                        {
                            cellMontoReci.Value = cellMonto.Value;
                        }
                        else
                        {
                            CalcularTiCa();
                            Decimal TiCa = Convert.ToDecimal(txtTipCambio.Text);

                            if (cellMoneda.Value.ToString() == Variables.Dolares)
                            {
                                cellMontoReci.Value = Convert.ToDecimal(cellMonto.Value) * TiCa;
                            }
                            else
                            {
                                cellMontoReci.Value = Convert.ToDecimal(cellMonto.Value) / TiCa;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion

        private void btPorPagar_Click(object sender, EventArgs e)
        {
            try
            {
                String Bloquear = "S";

                if (Convert.ToInt32(txtRuc.Tag) == 0)
                {
                    Global.MensajeComunicacion("Debe ingresar un auxiliar antes de sacar los pendientes.");
                    return;
                }

                if (TipoPlanillaNemo == "PLACLT")
                {
                    Bloquear = "N";
                }

                frmPendientesAuxiliares oFrm = new frmPendientesAuxiliares(Convert.ToInt32(txtRuc.Tag), txtRuc.Text.Trim(), txtDesAuxiliar.Text.Trim(), Bloquear);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    foreach (CtaCteE item in oFrm.oListaCtaCte)
                    {
                        CobranzasItemDetE oCobranDetItem = new CobranzasItemDetE
                        {
                            idPersona = item.idPersona,
                            Ruc = item.RUC,
                            RazonSocial = item.RazonSocial,
                            idDocumento = item.idDocumento,
                            numSerie = item.numSerie,
                            numDocumento = item.numDocumento,
                            fecEmision = item.FechaDocumento,
                            idMoneda = item.idMoneda,
                            Moneda = item.desMoneda
                        };

                        if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "CR")
                        {
                            oCobranDetItem.idMonedaReci = item.idMoneda;
                            oCobranDetItem.MonedaReci = item.desMoneda;
                            oCobranDetItem.idMoneda = item.idMoneda;
                            oCobranDetItem.Moneda = item.desMoneda;
                        }
                        else
                        {
                            oCobranDetItem.idMonedaReci = cboMon.SelectedValue.ToString();
                            oCobranDetItem.MonedaReci = ((MonedasE)cboMon.SelectedItem).desAbreviatura;
                        }

                        oCobranDetItem.Monto = item.Saldo;
                        oCobranDetItem.tipCambioReci = VariablesLocales.MontoTicaConta(oCobranDetItem.fecEmision.Value.Date, Variables.Dolares); //item.TipoCambio;

                        if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "R" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "T")
                        {

                        }
                        else
                        {
                            if (oCobranDetItem.idMoneda == oCobranDetItem.idMonedaReci.ToString())
                            {
                                oCobranDetItem.MontoReci = Convert.ToDecimal(item.Saldo);
                            }
                            else
                            {
                                if (oCobranDetItem.idMoneda == Variables.Dolares)
                                {
                                    oCobranDetItem.MontoReci = Decimal.Round(Convert.ToDecimal(item.Saldo) * Convert.ToDecimal(txtTipCambio.Text), 2);
                                }
                                else
                                {
                                    oCobranDetItem.MontoReci = Decimal.Round(Convert.ToDecimal(item.Saldo) / Convert.ToDecimal(txtTipCambio.Text), 2);
                                }
                            }
                        }

                        oCobranDetItem.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                        oCobranDetItem.codCuenta = item.codCuenta;
                        oCobranDetItem.fecVencimiento = item.FechaDocumento;
                        oCobranDetItem.idCtaCte = item.idCtaCte; //Cta. Cte.
                        oCobranDetItem.LetraEndosadaA = null;
                        oCobranDetItem.indTercero = false;
                        oCobranDetItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oCobranDetItem.FechaRegistro = VariablesLocales.FechaHoy;
                        oCobranDetItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oCobranDetItem.FechaModificacion = VariablesLocales.FechaHoy;

                        oCobranDetItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oCobranzaItem.oListaCobranzasItemDet.Add(oCobranDetItem);
                    }

                    bsBase.DataSource = oCobranzaItem.oListaCobranzasItemDet;
                    bsBase.ResetBindings(false);
                    Totales();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRucAuxiliar_TextChanged(object sender, EventArgs e)
        {
            txtRazonAuxiliar.TextChanged -= txtRazonAuxiliar_TextChanged;
            txtRucAuxiliar.Tag = 0;
            txtRazonAuxiliar.Text = String.Empty;
            txtRazonAuxiliar.TextChanged += txtRazonAuxiliar_TextChanged;
        }

        private void txtRazonAuxiliar_TextChanged(object sender, EventArgs e)
        {
            txtRucAuxiliar.TextChanged -= txtRucAuxiliar_TextChanged;
            txtRucAuxiliar.Tag = 0;
            txtRucAuxiliar.Text = String.Empty;
            txtRucAuxiliar.TextChanged += txtRucAuxiliar_TextChanged;
        }

        private void txtRucAuxiliar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRucAuxiliar.Text.Trim()) && String.IsNullOrEmpty(txtRazonAuxiliar.Text.Trim()))
                {
                    txtRucAuxiliar.TextChanged -= txtRucAuxiliar_TextChanged;
                    txtRazonAuxiliar.TextChanged -= txtRazonAuxiliar_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucAuxiliar.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucAuxiliar.Text = oFrm.oPersona.RUC;
                            txtRucAuxiliar.Tag = Convert.ToInt32(oFrm.oPersona.IdPersona);
                            txtRazonAuxiliar.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonAuxiliar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRucAuxiliar.Text = oListaPersonas[0].RUC;
                        txtRucAuxiliar.Tag = Convert.ToInt32(oListaPersonas[0].IdPersona);
                        txtRazonAuxiliar.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRucAuxiliar.Tag = 0;
                        txtRucAuxiliar.Text = String.Empty;
                        txtRazonAuxiliar.Text = String.Empty;
                        txtRucAuxiliar.Focus();
                    }

                    txtRucAuxiliar.TextChanged += txtRucAuxiliar_TextChanged;
                    txtRazonAuxiliar.TextChanged += txtRazonAuxiliar_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonAuxiliar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonAuxiliar.Text.Trim()) && String.IsNullOrEmpty(txtRucAuxiliar.Text.Trim()))
                {
                    txtRucAuxiliar.TextChanged -= txtRucAuxiliar_TextChanged;
                    txtRazonAuxiliar.TextChanged -= txtRazonAuxiliar_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonAuxiliar.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucAuxiliar.Text = oFrm.oPersona.RUC;
                            txtRucAuxiliar.Tag = Convert.ToInt32(oFrm.oPersona.IdPersona);
                            txtRazonAuxiliar.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonAuxiliar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRucAuxiliar.Text = oListaPersonas[0].RUC;
                        txtRucAuxiliar.Tag = Convert.ToInt32(oListaPersonas[0].IdPersona);
                        txtRazonAuxiliar.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Auxiliar ingresado no existe");
                        txtRazonAuxiliar.Text = String.Empty;
                        txtRucAuxiliar.Text = String.Empty;
                        txtRucAuxiliar.Tag = 0;
                        txtRuc.Focus();
                    }

                    txtRucAuxiliar.TextChanged += txtRucAuxiliar_TextChanged;
                    txtRazonAuxiliar.TextChanged += txtRazonAuxiliar_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btLetras_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtRuc.Tag) == 0)
                {
                    Global.MensajeComunicacion("Debe ingresar un auxiliar antes de sacar los pendientes.");
                    return;
                }

                if (txtTipCambio.Text == "0.000")
                {
                    Global.MensajeComunicacion("Debe ingresar el tipo de cambio.");
                    return;
                }

                frmPendientesVentasLetrasEquival oFrm = new frmPendientesVentasLetrasEquival(Convert.ToInt32(txtRuc.Tag), txtRuc.Text.Trim(), txtDesAuxiliar.Text.Trim(), "PC");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte != null && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    foreach (CtaCteE item in oFrm.oListaCtaCte)
                    {
                        if (String.IsNullOrWhiteSpace(item.CuentaEquivalente))
                        {
                            Global.MensajeAdvertencia(String.Format("La cuenta {0} no tiene su equivalencia en el Maestro de Estados de Letras", item.codCuenta));
                            return;
                        }

                        CobranzasItemDetE oCobranDetItem = new CobranzasItemDetE
                        {
                            idPersona = item.idPersona,
                            Ruc = item.RUC,
                            RazonSocial = item.RazonSocial,
                            idDocumento = item.idDocumento,
                            numSerie = item.numSerie,
                            numDocumento = item.numDocumento,
                            fecEmision = item.FechaDocumento,
                            idMoneda = item.idMoneda,
                            Moneda = item.desMoneda
                        };

                        if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "CR")
                        {
                            oCobranDetItem.idMonedaReci = item.idMoneda;
                            oCobranDetItem.MonedaReci = item.desMoneda;
                            oCobranDetItem.idMoneda = item.idMoneda;
                            oCobranDetItem.Moneda = item.desMoneda;
                        }
                        else
                        {
                            oCobranDetItem.idMonedaReci = cboMon.SelectedValue.ToString();
                            oCobranDetItem.MonedaReci = ((MonedasE)cboMon.SelectedItem).desAbreviatura;
                        }

                        oCobranDetItem.Monto = (TipoPlanillaNemo == "PLACALET" ? Convert.ToDecimal(item.Saldo) : Convert.ToDecimal(item.SaldoOperativo));// item.SaldoOperativo;
                        oCobranDetItem.tipCambioReci = VariablesLocales.MontoTicaConta(oCobranDetItem.fecEmision.Value.Date, Variables.Dolares);

                        if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "R" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "T")
                        {

                        }
                        else
                        {
                            if (oCobranDetItem.idMoneda == oCobranDetItem.idMonedaReci.ToString())
                            {
                                oCobranDetItem.MontoReci = (TipoPlanillaNemo == "PLACALET" ? Convert.ToDecimal(item.Saldo) : Convert.ToDecimal(item.SaldoOperativo));
                            }
                            else
                            {
                                if (oCobranDetItem.idMoneda == Variables.Dolares)
                                {
                                    oCobranDetItem.MontoReci = Decimal.Round((TipoPlanillaNemo == "PLACALET" ? Convert.ToDecimal(item.Saldo) : Convert.ToDecimal(item.SaldoOperativo)) * Convert.ToDecimal(txtTipCambio.Text), 2);
                                }
                                else
                                {
                                    oCobranDetItem.MontoReci = Decimal.Round((TipoPlanillaNemo == "PLACALET" ? Convert.ToDecimal(item.Saldo) : Convert.ToDecimal(item.SaldoOperativo)) / Convert.ToDecimal(txtTipCambio.Text), 2);
                                }
                            }
                        }

                        oCobranDetItem.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                        oCobranDetItem.codCuenta = (TipoPlanillaNemo == "PLACALET" ? item.codCuenta : item.CuentaEquivalente);
                        oCobranDetItem.fecVencimiento = item.FechaVencimiento;
                        oCobranDetItem.idCtaCte = item.idCtaCte; //Cta. Cte.
                        oCobranDetItem.LetraEndosadaA = (item.idPersonaEndoso == 0 ? null : item.idPersonaEndoso);
                        oCobranDetItem.indTercero = false;
                        oCobranDetItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oCobranDetItem.FechaRegistro = VariablesLocales.FechaHoy;
                        oCobranDetItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oCobranDetItem.FechaModificacion = VariablesLocales.FechaHoy;

                        oCobranDetItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oCobranzaItem.oListaCobranzasItemDet.Add(oCobranDetItem);
                    }

                    bsBase.DataSource = oCobranzaItem.oListaCobranzasItemDet;
                    bsBase.ResetBindings(false);
                    Totales();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dgvDetalle.CurrentCell;
            var cellDisplayRect = dgvDetalle.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (e.ColumnIndex == dgvDetalle.Columns["RazonSocial"].Index)
            {
                toolTipAyuda.Show(((CobranzasItemDetE)bsBase.Current).RazonSocialEndose, dgvDetalle, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 2000);
            }

            toolTipAyuda.ToolTipTitle = "Endosado a:";
            toolTipAyuda.ToolTipIcon = ToolTipIcon.Info;
            toolTipAyuda.IsBalloon = true;
            dgvDetalle.ShowCellToolTips = false;
        }

        private void txtGasCom_TextChanged(object sender, EventArgs e)
        {
            Totales();
        }

        private void txtInteres_TextChanged(object sender, EventArgs e)
        {
            Totales();
        }

        private void cboMon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                TipoIngresosE tipo = (TipoIngresosE)cboTipoCobranza.SelectedItem;

                if (tipo.indManipularMoneda)
                {
                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;

                    if (cboMon.SelectedValue.ToString() == "01")
                    {
                        txtCtaDestino.Text = tipo.ctaSoles;
                        txtDesCtaDestino.Text = tipo.desCtaSoles;
                    }
                    else
                    {
                        txtCtaDestino.Text = tipo.ctaDolares;
                        txtDesCtaDestino.Text = tipo.desCtaDolar;
                    }

                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void btTercero_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipCambio.Text == "0.000")
                {
                    Global.MensajeComunicacion("Debe ingresar el tipo de cambio.");
                    return;
                }

                Persona persona = AgenteMaestro.Proxy.ObtenerPersonaPorNroRuc(VariablesLocales.SesionUsuario.Empresa.RUC, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (persona == null)
                {
                    Global.MensajeComunicacion(String.Format("La empresa {0} no esta ingresado como cliente.", VariablesLocales.SesionUsuario.Empresa.RazonSocial));
                    return;
                }

                if (TipoPlanillaNemo == "PLALDES")
                {
                    frmBuscarLetrasEndosadas oFrm = new frmBuscarLetrasEndosadas(Convert.ToInt32(persona.IdPersona));

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaLetras != null && oFrm.oListaLetras.Count > Variables.Cero)
                    {
                        foreach (PlanillaBancosE item in oFrm.oListaLetras)
                        {
                            CobranzasItemDetE oCobranDetItem = new CobranzasItemDetE
                            {
                                idPersona = item.idPersonaEmpresa,
                                Ruc = item.RucEmpresa,
                                RazonSocial = item.RazonSocialEmpresa,
                                idDocumento = "LT",
                                numSerie = String.Empty,
                                numDocumento = item.Letra,
                                fecEmision = item.Fecha,
                                idMoneda = item.idMoneda,
                                Moneda = item.desMoneda
                            };

                            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "CR")
                            {
                                oCobranDetItem.idMonedaReci = item.idMoneda;
                                oCobranDetItem.MonedaReci = item.desMoneda;
                                oCobranDetItem.idMoneda = item.idMoneda;
                                oCobranDetItem.Moneda = item.desMoneda;
                            }
                            else
                            {
                                oCobranDetItem.idMonedaReci = cboMon.SelectedValue.ToString();
                                oCobranDetItem.MonedaReci = ((MonedasE)cboMon.SelectedItem).desAbreviatura;
                            }

                            oCobranDetItem.Monto = item.MontoLetras;
                            oCobranDetItem.tipCambioReci = VariablesLocales.MontoTicaConta(oCobranDetItem.fecEmision.Value.Date, Variables.Dolares);

                            if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "R" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "T")
                            {

                            }
                            else
                            {
                                if (oCobranDetItem.idMoneda == oCobranDetItem.idMonedaReci.ToString())
                                {
                                    oCobranDetItem.MontoReci = item.MontoLetras;
                                }
                                else
                                {
                                    if (oCobranDetItem.idMoneda == Variables.Dolares)
                                    {
                                        oCobranDetItem.MontoReci = Decimal.Round(item.MontoLetras * Convert.ToDecimal(txtTipCambio.Text), 2);
                                    }
                                    else
                                    {
                                        oCobranDetItem.MontoReci = Decimal.Round(item.MontoLetras / Convert.ToDecimal(txtTipCambio.Text), 2);
                                    }
                                }
                            }

                            oCobranDetItem.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                            oCobranDetItem.codCuenta = item.codCuenta;
                            oCobranDetItem.fecVencimiento = item.fecVenc;
                            oCobranDetItem.idCtaCte = null; //Cta. Cte.
                            oCobranDetItem.LetraEndosadaA = item.idAuxiliar;
                            oCobranDetItem.RazonSocialEndose = item.RazonSocialAuxiliar;
                            oCobranDetItem.indTercero = true;
                            oCobranDetItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oCobranDetItem.FechaRegistro = VariablesLocales.FechaHoy;
                            oCobranDetItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oCobranDetItem.FechaModificacion = VariablesLocales.FechaHoy;

                            oCobranDetItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                            oCobranzaItem.oListaCobranzasItemDet.Add(oCobranDetItem);
                        }

                        bsBase.DataSource = oCobranzaItem.oListaCobranzasItemDet;
                        bsBase.ResetBindings(false);
                        Totales();
                    } 
                }
                else if (TipoPlanillaNemo == "PLACALET")
                {
                    TipoIngresosE tipo = (TipoIngresosE)cboTipoCobranza.SelectedItem;

                    if (Convert.ToInt32(txtRuc.Tag) == 0)
                    {
                        Global.MensajeComunicacion("Debe ingresar un auxiliar antes de sacar los pendientes.");
                        return;
                    }

                    if (tipo.TipoCobro == "CLD" || tipo.TipoCobro == "LDE")//9.6 CANC. LETRAS EN DSCTO ENDOSO C/PAGO o 9.7 CANCE. LETRA EN DSCTO ENDOSO S/PAGO
                    {
                        frmPendientesVentasLetrasEquival oFrm = new frmPendientesVentasLetrasEquival(Convert.ToInt32(txtRuc.Tag), txtRuc.Text.Trim(), txtDesAuxiliar.Text.Trim(), "CT");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte != null && oFrm.oListaCtaCte.Count > Variables.Cero)
                        {
                            foreach (CtaCteE item in oFrm.oListaCtaCte)
                            {
                                CobranzasItemDetE oCobranDetItem = new CobranzasItemDetE
                                {
                                    idPersona = item.idPersona,
                                    Ruc = item.RUC,
                                    RazonSocial = item.RazonSocial,
                                    idDocumento = item.idDocumento,
                                    numSerie = item.numSerie,
                                    numDocumento = item.numDocumento,
                                    fecEmision = item.FechaDocumento,
                                    idMoneda = item.idMoneda,
                                    Moneda = item.desMoneda
                                };

                                if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "CR")
                                {
                                    oCobranDetItem.idMonedaReci = item.idMoneda;
                                    oCobranDetItem.MonedaReci = item.desMoneda;
                                    oCobranDetItem.idMoneda = item.idMoneda;
                                    oCobranDetItem.Moneda = item.desMoneda;
                                }
                                else
                                {
                                    oCobranDetItem.idMonedaReci = cboMon.SelectedValue.ToString();
                                    oCobranDetItem.MonedaReci = ((MonedasE)cboMon.SelectedItem).desAbreviatura;
                                }

                                oCobranDetItem.Monto = Convert.ToDecimal(item.Saldo);
                                oCobranDetItem.tipCambioReci = VariablesLocales.MontoTicaConta(oCobranDetItem.fecEmision.Value.Date, Variables.Dolares);

                                if (((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "R" || ((TipoIngresosE)cboTipoCobranza.SelectedItem).TipoCobro == "T")
                                {

                                }
                                else
                                {
                                    if (oCobranDetItem.idMoneda == oCobranDetItem.idMonedaReci.ToString())
                                    {
                                        oCobranDetItem.MontoReci = Convert.ToDecimal(item.Saldo);
                                    }
                                    else
                                    {
                                        if (oCobranDetItem.idMoneda == Variables.Dolares)
                                        {
                                            oCobranDetItem.MontoReci = Convert.ToDecimal(item.Saldo);
                                        }
                                        else
                                        {
                                            oCobranDetItem.MontoReci = Convert.ToDecimal(item.Saldo);
                                        }
                                    }
                                }

                                oCobranDetItem.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                                oCobranDetItem.codCuenta = item.codCuenta;
                                oCobranDetItem.fecVencimiento = item.FechaVencimiento;
                                oCobranDetItem.idCtaCte = item.idCtaCte; //Cta. Cte.
                                oCobranDetItem.LetraEndosadaA = item.idPersonaEndoso == 0 ? (Int32?)null : item.idPersonaEndoso;
                                oCobranDetItem.indTercero = true;
                                oCobranDetItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                oCobranDetItem.FechaRegistro = VariablesLocales.FechaHoy;
                                oCobranDetItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                oCobranDetItem.FechaModificacion = VariablesLocales.FechaHoy;

                                oCobranDetItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                                oCobranzaItem.oListaCobranzasItemDet.Add(oCobranDetItem);
                            }

                            bsBase.DataSource = oCobranzaItem.oListaCobranzasItemDet;
                            bsBase.ResetBindings(false);
                            Totales();
                        }
                    }
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
