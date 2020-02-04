using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmLiquidacionDetalle : frmResponseBase
    {

        #region Contructores

        public frmLiquidacionDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            oParametrosConta = VariablesLocales.oConParametros;

            LlenarCombos();
        }

        //Nuevo
        public frmLiquidacionDetalle(String TipoCuenta_, List<LiquidacionDetE> oListaTemp, String TipoF, String Bloq)
            :this()
        {
            TipoCuenta = TipoCuenta_;
            TipoFondo = TipoF;
            Bloqueo = Bloq;

            if (oListaTemp != null && oListaTemp.Count > 0)
            {
                oListaIdMov = new List<int>();

                foreach (LiquidacionDetE item in oListaTemp)
                {
                    oListaIdMov.Add(item.idMovilidad.Value);
                }
            }
        }

        //Edición
        public frmLiquidacionDetalle(LiquidacionDetE oDetalle, String Bloqueo, String TipoCuenta_, List<LiquidacionDetE> oListaTemp, String TipoF, String Bloq)
            :this()
        {
            oLiquidacion = oDetalle;

            if (Bloqueo == "C")
            {
                pnlBase.Enabled = false;
                btAceptar.Enabled = false;
            }

            TipoCuenta = TipoCuenta_;
            TipoFondo = TipoF;
            Bloqueo = Bloq;

            if (oListaTemp != null && oListaTemp.Count > 0)
            {
                oListaIdMov = new List<int>();

                foreach (LiquidacionDetE item in oListaTemp)
                {
                    oListaIdMov.Add(item.idMovilidad.Value);
                }
            }
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public LiquidacionDetE oLiquidacion = null;
        String TipoCuenta = String.Empty;
        ConceptosVariosE oConceptoMovi = null;
        String BuscarCuentas = Variables.SI;
        List<Int32> oListaIdMov = null;
        String TipoFondo = String.Empty; //168=Rendiciones 102=Fondo Fijo
        String Bloqueo = "N";
        PlanCuentasE oPlanCuentasGenerado = null;
        ParametrosContaE oParametrosConta;

        #endregion

        #region Procedimiento de Usuario

        void LlenarCombos()
        {
            //Tipo de Documento de Liquidación
            cboTipoDocumento.DataSource = Global.CargarTipoDocLiquidacion();
            cboTipoDocumento.DisplayMember = "Nombre";
            cboTipoDocumento.ValueMember = "id";

            //Llenando las monedas
            List<MonedasE> listaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.LlenarCombos<MonedasE>(cboMonedas, (from x in listaMonedas 
                                                            where x.idMoneda == Variables.Soles
                                                            || x.idMoneda == Variables.Dolares
                                                            select x).ToList(), "idMoneda", "desAbreviatura");
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indViaticos == true
                                                                      select x).ToList();
            
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentos, (from x in ListaDocumentos
                                                                    orderby x.idDocumento
                                                                    select x).ToList(), "idDocumento", "desDocumento", false);
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

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oLiquidacion == null)
                {
                    oLiquidacion = new LiquidacionDetE()
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal,
                        Opcion = (Int32)EnumOpcionGrabar.Insertar,
                        indReparable = "N",
                        idConceptoRep = 0,
                        desReferenciaRep = String.Empty
                    };

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                    cboTipoDocumento_SelectionChangeCommitted(new Object(), new EventArgs());
                    dtpFecha_ValueChanged(null, null);
                }
                else
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
                    txtMonto.TextChanged -= txtMonto_TextChanged;
                    txtTica.TextChanged -= txtTica_TextChanged;
                    txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                    txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    txtCCostos.TextChanged -= txtCCostos_TextChanged;

                    BuscarCuentas = Variables.NO;

                    if (oLiquidacion.Opcion == 0)
                    {
                        oLiquidacion.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                    }
                    
                    cboTipoDocumento.SelectedValue = Convert.ToInt32(oLiquidacion.tipoDocumento);
                    cboTipoDocumento_SelectionChangeCommitted(new Object(), new EventArgs());

                    if (Convert.ToInt32(oLiquidacion.tipoDocumento) == 1) //Provisión
                    {
                        txtIdProvision.Text = oLiquidacion.idProvision.ToString();
                        txtCodConcepto.Text = String.Empty;
                        txtDesConcepto.Text = String.Empty;
                    }
                    else if (Convert.ToInt32(oLiquidacion.tipoDocumento) == 2) //Movilidad
                    {
                        txtIdMovilidad.Text = oLiquidacion.idMovilidad.ToString();
                        txtCodConcepto.Text = String.Empty;
                        txtDesConcepto.Text = String.Empty;
                    }
                    else //Otros
                    {
                        txtIdProvision.Text = String.Empty;
                        txtIdMovilidad.Text = String.Empty;

                        txtCodConcepto.Tag = Convert.ToInt32(oLiquidacion.idConcepto);
                        txtCodConcepto.Text = oLiquidacion.codConcepto;
                        txtDesConcepto.Text = oLiquidacion.Concepto;
                    }

                    txtRuc.Tag = oLiquidacion.idPersona != 0 ? txtRuc.Tag = oLiquidacion.idPersona : 0;
                    txtRuc.Text = oLiquidacion.Ruc;
                    txtRazonSocial.Text = oLiquidacion.RazonSocial;

                    if (String.IsNullOrWhiteSpace(oLiquidacion.idDocumento))
                    {
                        cboDocumentos.SelectedValue = "0";
                    }
                    else
                    {
                        cboDocumentos.SelectedValue = oLiquidacion.idDocumento.ToString();
                    }

                    txtSerie.Text = oLiquidacion.numSerie;
                    txtNumDocumento.Text = oLiquidacion.numDocumento;
                    dtpFecha.Value = oLiquidacion.FechaDocumento.Value;
                    cboMonedas.SelectedValue = oLiquidacion.idMoneda;
                    txtMonto.Text = oLiquidacion.Monto.ToString("N2");
                    chkTicaAuto.Checked = oLiquidacion.indTicaAuto;
                    chkTicaAuto_CheckedChanged(null, null);
                    txtTica.Text = oLiquidacion.TipoCambio.ToString("N3");
                    txtMontoLiqui.Text = oLiquidacion.MontoLiquidar.ToString("N2");
                    txtGlosa.Text = oLiquidacion.Glosa;
                    txtCodCuenta.Tag = oLiquidacion.numVerPlanCuentas.ToString();
                    txtCodCuenta.Text = oLiquidacion.codCuenta;
                    if (txtCodCuenta.Text != String.Empty)
                    {
                        oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCodCuenta.Text.Trim());
                        HabilitaTextBoxMovimientos("CN");
                        oPlanCuentasGenerado = null;
                    }                  
                    txtDesCuenta.Text = oLiquidacion.desCuenta;
                    txtCCostos.Text = oLiquidacion.idCCostos;
                    txtDesCCostos.Text = oLiquidacion.DesCCostos;

                    txtUsuarioRegistro.Text = oLiquidacion.UsuarioRegistro;
                    txtFechaRegistro.Text = oLiquidacion.FechaRegistro.ToString();
                    txtUsuarioModificacion.Text = oLiquidacion.UsuarioModificacion;
                    txtFechaModificacion.Text = oLiquidacion.FechaModificacion.ToString();

                    BuscarCuentas = Variables.SI;

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    dtpFecha.ValueChanged += dtpFecha_ValueChanged;
                    txtMonto.TextChanged += txtMonto_TextChanged;
                    txtTica.TextChanged += txtTica_TextChanged;
                    txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                    txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    txtCCostos.TextChanged += txtCCostos_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (txtTica.Text == "0.000" || String.IsNullOrWhiteSpace(txtTica.Text.Trim()))
                {
                    Global.MensajeComunicacion("Debe colocar una fecha donde que tenga Tipo de Cambio.");
                    return;
                }

                if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 2)
                {
                    if (String.IsNullOrWhiteSpace(txtIdMovilidad.Text.Trim()))
                    {
                        Global.MensajeComunicacion("Debe escoger una Planilla de Movilidad antes de guardar.");
                        txtIdMovilidad.Focus();
                        return;
                    }
                }


                oLiquidacion.tipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                oLiquidacion.desTipoDocumento = cboTipoDocumento.Text;

                if (Convert.ToInt32(oLiquidacion.tipoDocumento) == 1) //Provisión
                {
                    if (String.IsNullOrWhiteSpace(txtCodCuenta.Text.Trim()) && String.IsNullOrWhiteSpace(txtDesCuenta.Text.Trim()))
                    {
                        Global.MensajeComunicacion("Falta configurar la cuenta contable en los conceptos de provisión.");
                        txtCodCuenta.Focus();
                        return;
                    }

                    oLiquidacion.idProvision = Convert.ToInt32(txtIdProvision.Text);
                    oLiquidacion.idMovilidad = null;

                    if (oLiquidacion.idProvision == 0)
                    {
                        oLiquidacion.idProvision = null;
                    }
                }
                else if (Convert.ToInt32(oLiquidacion.tipoDocumento) == 2) //Movilidad
                {
                    if (String.IsNullOrWhiteSpace(txtCodCuenta.Text.Trim()) && String.IsNullOrWhiteSpace(txtDesCuenta.Text.Trim()))
                    {
                        Global.MensajeComunicacion("Falta configurar la cuenta contable en la movilidad.");
                        txtCodCuenta.Focus();
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(txtIdMovilidad.Text.Trim()))
                    {
                        Global.MensajeComunicacion("Debe escoger una Planilla de Movilidad antes de guardar.");
                        txtIdMovilidad.Focus();
                        return;
                    }

                    oLiquidacion.idProvision = null;
                    oLiquidacion.idMovilidad = Convert.ToInt32(txtIdMovilidad.Text);

                    if (oLiquidacion.idMovilidad == 0)
                    {
                        oLiquidacion.idMovilidad = null;
                    }
                }
                else //Otros
                {
                    if (String.IsNullOrWhiteSpace(txtCodCuenta.Text.Trim()) && String.IsNullOrWhiteSpace(txtDesCuenta.Text.Trim()))
                    {
                        Global.MensajeComunicacion("Falta configurar la cuenta contable para el concepto escogido.");
                        txtCodCuenta.Focus();
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(txtCodConcepto.Text.Trim()))
                    {
                        Global.MensajeComunicacion("Debe escoger un concepto antes de guardar.");
                        txtCodConcepto.Focus();
                        return;
                    }

                    oLiquidacion.idProvision = null;
                    oLiquidacion.idMovilidad = null;
                    oLiquidacion.idConcepto = Convert.ToInt32(txtCodConcepto.Tag);
                    oLiquidacion.codConcepto = txtCodConcepto.Text.Trim();
                    oLiquidacion.Concepto = txtDesConcepto.Text.Trim();
                }

                if (cboDocumentos.SelectedValue.ToString() == "0")
                {
                    oLiquidacion.idDocumento = String.Empty;
                }
                else
                {
                    oLiquidacion.idDocumento = cboDocumentos.SelectedValue.ToString();
                }
                
                oLiquidacion.numSerie = txtSerie.Text.Trim();
                oLiquidacion.numDocumento = txtNumDocumento.Text.Trim();
                oLiquidacion.FechaDocumento = dtpFecha.Value.Date;
                oLiquidacion.idMoneda = cboMonedas.SelectedValue.ToString();
                oLiquidacion.desMoneda = ((MonedasE)cboMonedas.SelectedItem).desAbreviatura;
                oLiquidacion.Monto = Convert.ToDecimal(txtMonto.Text);
                oLiquidacion.indTicaAuto = chkTicaAuto.Checked;
                oLiquidacion.TipoCambio = Convert.ToDecimal(txtTica.Text);
                oLiquidacion.MontoLiquidar = Convert.ToDecimal(txtMontoLiqui.Text);
                oLiquidacion.Glosa = txtGlosa.Text.Trim();
                oLiquidacion.numVerPlanCuentas = txtCodCuenta.Tag.ToString().Trim();
                oLiquidacion.codCuenta = txtCodCuenta.Text.Trim();
                oLiquidacion.desCuenta = txtDesCuenta.Text.Trim();
                oLiquidacion.idPersona = Convert.ToInt32(txtRuc.Tag) == 0 ? (Int32?)null : Convert.ToInt32(txtRuc.Tag);
                oLiquidacion.Ruc = txtRuc.Text.Trim();
                oLiquidacion.RazonSocial = txtRazonSocial.Text.Trim();
                oLiquidacion.idCCostos = txtCCostos.Text;

                if (oLiquidacion.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                {
                    oLiquidacion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oLiquidacion.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    oLiquidacion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oLiquidacion.FechaRegistro = VariablesLocales.FechaHoy;
                    oLiquidacion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oLiquidacion.FechaModificacion = VariablesLocales.FechaHoy;
                }

                base.Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void HabilitaTextBoxMovimientos(String Tipo)
        {
            if (oPlanCuentasGenerado != null)
            {
                if (oPlanCuentasGenerado.indSolicitaCentroCosto == Variables.SI)
                {
                    Extensores.CambiaColorFondo(txtCCostos, EnumTipoEdicionCuadros.Desbloquear);
                    btCentroC.Enabled = true;
                }
                else
                {
                    Extensores.CambiaColorFondo(txtCCostos, EnumTipoEdicionCuadros.Bloquear);
                    btCentroC.Enabled = false;
                }

            }
        }

        #endregion

        #region Eventos

        private void frmLiquidacionDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
            txtCodCuenta.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                txtCodCuenta.Visible = true;
                txtDesCuenta.Visible = true;
            }
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 1) //Provisión
                {
                    txtIdProvision.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    btProvision.Enabled = true;
                    btBuscarProvision.Enabled = true;
                    txtIdMovilidad.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    btMovilidad.Enabled = false;
                    btInsertarMovi.Enabled = false;

                    btConceptos.Enabled = false;
                    txtCodConcepto.Tag = 0;
                    txtCodConcepto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtDesConcepto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    btRecibosH.Enabled = false;
                    btReparable.Enabled = false;
                    txtRuc.Tag = 0;
                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    oConceptoMovi = null;

                    cboDocumentos.Enabled = false;
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNumDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    dtpFecha.Enabled = false;
                    cboMonedas.Enabled = false;
                    txtMonto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    chkTicaAuto.Enabled = false;
                }
                else if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 2) //Movilidad
                {
                    txtIdProvision.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    btProvision.Enabled = false;
                    btBuscarProvision.Enabled = false;
                    //txtIdMovilidad.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    btMovilidad.Enabled = true;
                    btInsertarMovi.Enabled = true;

                    btConceptos.Enabled = true;
                    txtCodConcepto.Tag = 0;
                    txtCodConcepto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtDesConcepto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    btRecibosH.Enabled = false;
                    btReparable.Enabled = true;
                    txtRuc.Tag = 0;
                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                    cboDocumentos.Enabled = false;
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNumDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    dtpFecha.Enabled = false;
                    cboMonedas.Enabled = false;
                    txtMonto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    chkTicaAuto.Enabled = false;

                    if (BuscarCuentas == Variables.SI)
                    {
                        txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                        txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                        if (oConceptoMovi == null)
                        {
                            oConceptoMovi = new AlmacenServiceAgent().Proxy.RecuperarCuentasMovilidad(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                            if (oConceptoMovi == null)
                            {
                                Global.MensajeFault("No esta configurado el concepto de movilidad.");
                            }
                            else
                            {
                                if (TipoCuenta == "TLVE") //Venta
                                {
                                    if (String.IsNullOrWhiteSpace(oConceptoMovi.codCuentaVen.Trim()))
                                    {
                                        Global.MensajeFault("No se ha colocado la cuenta de ventas en el concepto de movilidad.");
                                    }

                                    txtCodCuenta.Tag = oConceptoMovi.numVerPlanCuentas;
                                    txtCodCuenta.Text = oConceptoMovi.codCuentaVen;
                                    txtDesCuenta.Text = oConceptoMovi.desCuentaVen;
                                }

                                if (TipoCuenta == "TLADM") //Administración
                                {
                                    if (String.IsNullOrWhiteSpace(oConceptoMovi.codCuentaAdm.Trim()))
                                    {
                                        Global.MensajeFault("No se ha colocado la cuenta de administración en el concepto de movilidad.");
                                    }

                                    txtCodCuenta.Tag = oConceptoMovi.numVerPlanCuentas;
                                    txtCodCuenta.Text = oConceptoMovi.codCuentaAdm;
                                    txtDesCuenta.Text = oConceptoMovi.desCuentaAdm;
                                }

                                if (TipoCuenta == "TLPRO") //Producción
                                {
                                    if (String.IsNullOrWhiteSpace(oConceptoMovi.codCuentaPro.Trim()))
                                    {
                                        Global.MensajeFault("No se ha colocado la cuenta de producción en el concepto de movilidad.");
                                    }

                                    txtCodCuenta.Tag = oConceptoMovi.numVerPlanCuentas;
                                    txtCodCuenta.Text = oConceptoMovi.codCuentaPro;
                                    txtDesCuenta.Text = oConceptoMovi.desCuentaPro;
                                }
                            }
                        }
                        else
                        {
                            if (TipoCuenta == "TLVE") //Venta
                            {
                                if (String.IsNullOrWhiteSpace(oConceptoMovi.codCuentaVen.Trim()))
                                {
                                    Global.MensajeFault("No se ha colocado la cuenta de ventas en el concepto de movilidad.");
                                }

                                txtCodCuenta.Tag = oConceptoMovi.numVerPlanCuentas;
                                txtCodCuenta.Text = oConceptoMovi.codCuentaVen;
                                txtDesCuenta.Text = oConceptoMovi.desCuentaVen;
                            }

                            if (TipoCuenta == "TLADM") //Administración
                            {
                                if (String.IsNullOrWhiteSpace(oConceptoMovi.codCuentaAdm.Trim()))
                                {
                                    Global.MensajeFault("No se ha colocado la cuenta de administración en el concepto de movilidad.");
                                }

                                txtCodCuenta.Tag = oConceptoMovi.numVerPlanCuentas;
                                txtCodCuenta.Text = oConceptoMovi.codCuentaAdm;
                                txtDesCuenta.Text = oConceptoMovi.desCuentaAdm;
                            }

                            if (TipoCuenta == "TLPRO") //Producción
                            {
                                if (String.IsNullOrWhiteSpace(oConceptoMovi.codCuentaPro.Trim()))
                                {
                                    Global.MensajeFault("No se ha colocado la cuenta de producción en el concepto de movilidad.");
                                }

                                txtCodCuenta.Tag = oConceptoMovi.numVerPlanCuentas;
                                txtCodCuenta.Text = oConceptoMovi.codCuentaPro;
                                txtDesCuenta.Text = oConceptoMovi.desCuentaPro;
                            }
                        }

                        txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                        txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    }
                }
                else //Otros
                {
                    txtIdProvision.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    btProvision.Enabled = false;
                    btBuscarProvision.Enabled = false;
                    txtIdMovilidad.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    btMovilidad.Enabled = false;
                    
                    btConceptos.Enabled = true;
                    txtCodConcepto.Tag = 0;
                    txtCodConcepto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtDesConcepto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    btRecibosH.Enabled = true;
                    txtRuc.Tag = 0;
                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    btReparable.Enabled = true;
                    oConceptoMovi = null;

                    cboDocumentos.Enabled = true;
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNumDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    dtpFecha.Enabled = true;
                    cboMonedas.Enabled = true;
                    txtMonto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    chkTicaAuto.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTicaAuto.Checked)
                {
                    DateTime Fecha = dtpFecha.Value.Date;
                    TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMonedas.SelectedValue.ToString(), Fecha);

                    if (Tica != null)
                    {
                        txtTica.Text = Tica.valVenta.ToString("N3");
                    }
                    else
                    {
                        txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                        dtpFecha.Focus();
                        Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btProvision_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 idProvision = String.IsNullOrWhiteSpace(txtIdProvision.Text.Trim()) ? 0 : Convert.ToInt32(txtIdProvision.Text);

                frmProvisionLiquidacion oFrm = new frmProvisionLiquidacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idProvision, TipoFondo, Bloqueo, TipoCuenta, oLiquidacion.oProvision);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvisiones != null)
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (idProvision != 0)
                    {
                        oLiquidacion.ActualizarProvMov = true;
                    }
                    else
                    {
                        oLiquidacion.ActualizarProvMov = false;
                    }

                    oLiquidacion.oProvision = new ProvisionesE();
                    ProvisionesE ProvisionLiqui = oFrm.oProvisiones;
                    oLiquidacion.oProvision = ProvisionLiqui;
                    oLiquidacion.oProvision.idSistema = 6;

                    txtIdProvision.Text = ProvisionLiqui.idProvision.ToString();
                    cboDocumentos.SelectedValue = ProvisionLiqui.idDocumento;
                    txtSerie.Text = ProvisionLiqui.NumSerie;
                    txtNumDocumento.Text = ProvisionLiqui.NumDocumento;
                    dtpFecha.Value = ProvisionLiqui.FechaDocumento;
                    cboMonedas.SelectedValue = ProvisionLiqui.CodMonedaProvision;
                    txtGlosa.Text = ProvisionLiqui.DesProvision;
                    txtMonto.Text = ProvisionLiqui.ImpMonedaOrigen.ToString("N2");
                    txtRuc.Tag = ProvisionLiqui.idPersona;
                    txtRuc.Text = ProvisionLiqui.Ruc;
                    txtRazonSocial.Text = ProvisionLiqui.RazonSocial;
                    
                    txtCodCuenta.Tag = ProvisionLiqui.NumVerPlanCuentas;
                    txtCodCuenta.Text = ProvisionLiqui.codCuenta;
                    txtDesCuenta.Text = ProvisionLiqui.DesCuenta;
                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                    ProvisionLiqui = null;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void btMovilidad_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarMovilidad oFrm = new frmBuscarMovilidad(oListaIdMov);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oMovilidad != null)
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    oLiquidacion.oMovilidad = new MovilidadE();
                    oLiquidacion.oMovilidad = oFrm.oMovilidad;

                    txtIdMovilidad.Text = oFrm.oMovilidad.idMovilidad.ToString();
                    cboDocumentos.SelectedValue = "MO";
                    dtpFecha.Value = oFrm.oMovilidad.Fecha;
                    txtSerie.Text = oFrm.oMovilidad.Serie;
                    txtNumDocumento.Text = oFrm.oMovilidad.Numero;
                    txtMonto.Text = oFrm.oMovilidad.Monto.ToString("N2");
                    txtRuc.Tag = oFrm.oMovilidad.idPersona;
                    txtRuc.Text = oFrm.oMovilidad.RUC;
                    txtRazonSocial.Text = oFrm.oMovilidad.RazonSocial;
                    txtGlosa.Focus();

                    if (oFrm.oMovilidad.indReparado)
                    {
                        oLiquidacion.indReparable = "R";
                        oLiquidacion.idConceptoRep = 9;
                        oLiquidacion.desReferenciaRep = String.Empty;
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
            {
                txtMontoLiqui.Text = txtMonto.Text;
            }
            else
            {
                Decimal.TryParse(txtTica.Text, out decimal Tica);
                Decimal.TryParse(txtMonto.Text, out decimal MontoOrigen);

                txtMontoLiqui.Text = Decimal.Round(MontoOrigen * Tica, 2).ToString("N2");
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            txtMonto.Text = Global.FormatoDecimal(txtMonto.Text);
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMonedas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
            {
                txtMontoLiqui.Text = txtMonto.Text;
            }
            else
            {
                Decimal.TryParse(txtTica.Text, out decimal Tica);
                Decimal.TryParse(txtMonto.Text, out decimal MontoOrigen);

                txtMontoLiqui.Text = Decimal.Round(MontoOrigen * Tica, 2).ToString("N2");
            }
        }

        private void cboTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboDocumentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtCodCuenta_TextChanged(object sender, EventArgs e)
        {
            txtCodCuenta.Tag = String.Empty;
            txtDesCuenta.Text = String.Empty;
            Extensores.CambiaColorFondo(txtCCostos, EnumTipoEdicionCuadros.Bloquear);
            btCentroC.Enabled = false;
        }

        private void txtDesCuenta_TextChanged(object sender, EventArgs e)
        {
            txtCodCuenta.Tag = String.Empty;
            txtCodCuenta.Text = String.Empty;
        }

        private void txtCodCuenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCodCuenta.Text.Trim());

                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuenta.Tag = oFrm.oCuenta.numVerPlanCuentas;
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
                        txtCodCuenta.Tag = oListaCuentas[0].numVerPlanCuentas;
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuenta.Tag = String.Empty;
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;


                    HabilitaTextBoxMovimientos("CN");
                    oPlanCuentasGenerado = null;

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
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuenta.Tag = oFrm.oCuenta.numVerPlanCuentas;
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
                        txtCodCuenta.Tag = oListaCuentas[0].numVerPlanCuentas;
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuenta.Tag = String.Empty;
                        txtCodCuenta.Text = String.Empty;
                        txtDesCuenta.Text = String.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btInsertarMovi_Click(object sender, EventArgs e)
        {
            try
            {
                frmMovilidad oFrm = new frmMovilidad("Liqui");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oMovilidadLiqui != null)
                {
                    MovilidadE Movilidad = oFrm.oMovilidadLiqui;
                    Decimal Monto = oFrm.oMovilidadLiqui.ListaMovilidadDet.Sum(x => x.Monto);

                    txtIdMovilidad.Text = Movilidad.idMovilidad.ToString();

                    //cboDocumentos.SelectedValue = Movilidad.idDocumento;
                    //txtSerie.Text = Movilidad.NumSerie;
                    //txtNumDocumento.Text = Movilidad.NumDocumento;
                    dtpFecha.Value = Movilidad.Fecha;
                    //cboMonedas.SelectedValue = Movilidad.CodMonedaProvision;
                    txtMonto.Text = Monto.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkTicaAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTicaAuto.Checked)
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
            else
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtTica.Focus();
            }
        }

        private void btBuscarProvision_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarProvisiones oFrm = new frmBuscarProvisiones("Normal");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvision != null)
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    ProvisionesE Provision = oFrm.oProvision;
                    Provision.idSistema = 5;

                    txtIdProvision.Text = Provision.idProvision.ToString();
                    cboDocumentos.SelectedValue = Provision.idDocumento;
                    txtSerie.Text = Provision.NumSerie;
                    txtNumDocumento.Text = Provision.NumDocumento;
                    dtpFecha.Value = Provision.FechaDocumento;
                    cboMonedas.SelectedValue = Provision.CodMonedaProvision;
                    txtGlosa.Text = Provision.DesProvision;
                    txtMonto.Text = Provision.ImpMonedaOrigen.ToString("N2");
                    txtCodCuenta.Tag = Provision.NumVerPlanCuentas;
                    txtCodCuenta.Text = Provision.codCuenta;
                    txtDesCuenta.Text = Provision.DesCuenta;
                    txtRuc.Tag = Provision.idPersona;
                    txtRuc.Text = Provision.Ruc;
                    txtRazonSocial.Text = Provision.RazonSocial;

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtTica_TextChanged(object sender, EventArgs e)
        {
            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
            {
                txtMontoLiqui.Text = txtMonto.Text;
            }
            else
            {
                Decimal Tica = 0;
                Decimal MontoOrigen = 0;
                Decimal.TryParse(txtTica.Text, out Tica);
                Decimal.TryParse(txtMonto.Text, out MontoOrigen);

                txtMontoLiqui.Text = Decimal.Round(MontoOrigen * Tica, 2).ToString("N2");
            }
        }

        private void txtTica_Leave(object sender, EventArgs e)
        {
            txtTica.Text = Global.FormatoDecimal(txtTica.Text, 3);
        }

        private void btGastos_Click(object sender, EventArgs e)
        {
            try
            {
                ParTabla oGasto = AgenteGeneral.Proxy.ParTablaPorNemo("TCGAS");

                if (oGasto != null)
                {
                    VariablesLocales.EsLiquidacion = Variables.SI;
                    frmBuscarConceptosVarios oFrm = new frmBuscarConceptosVarios(oGasto.IdParTabla);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                    {
                        txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                        txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;
                        txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                        txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                        txtCodConcepto.Tag = oFrm.oConcepto.idConcepto;
                        txtCodConcepto.Text = oFrm.oConcepto.codConcepto;
                        txtDesConcepto.Text = oFrm.oConcepto.Descripcion;

                        if (TipoCuenta == "TLVE") //Venta
                        {
                            txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oConcepto.codCuentaVen;
                            txtDesCuenta.Text = oFrm.oConcepto.desCuentaVen;
                        }

                        if (TipoCuenta == "TLADM") //Administración
                        {
                            txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oConcepto.codCuentaAdm;
                            txtDesCuenta.Text = oFrm.oConcepto.desCuentaAdm;
                        }

                        if (TipoCuenta == "TLPRO") //Producción
                        {
                            txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oConcepto.codCuentaPro;
                            txtDesCuenta.Text = oFrm.oConcepto.desCuentaPro;
                        }

                        txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                        txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                        txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                        txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    }

                    VariablesLocales.EsLiquidacion = Variables.NO;
                }
            }
            catch (Exception ex)
            {
                VariablesLocales.EsLiquidacion = Variables.NO;
                Global.MensajeFault(ex.Message);
            }
        }

        private void btServicios_Click(object sender, EventArgs e)
        {
            try
            {
                ParTabla oGasto = AgenteGeneral.Proxy.ParTablaPorNemo("TCSER");

                if (oGasto != null)
                {
                    VariablesLocales.EsLiquidacion = Variables.SI;
                    frmBuscarConceptosVarios oFrm = new frmBuscarConceptosVarios(oGasto.IdParTabla);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                    {
                        txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                        txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;
                        txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                        txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                        txtCodConcepto.Tag = oFrm.oConcepto.idConcepto;
                        txtCodConcepto.Text = oFrm.oConcepto.codConcepto;
                        txtDesConcepto.Text = oFrm.oConcepto.Descripcion;

                        if (TipoCuenta == "TLVE") //Venta
                        {
                            txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oConcepto.codCuentaVen;
                            txtDesCuenta.Text = oFrm.oConcepto.desCuentaVen;
                        }

                        if (TipoCuenta == "TLADM") //Administración
                        {
                            txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oConcepto.codCuentaAdm;
                            txtDesCuenta.Text = oFrm.oConcepto.desCuentaAdm;
                        }

                        if (TipoCuenta == "TLPRO") //Producción
                        {
                            txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oConcepto.codCuentaPro;
                            txtDesCuenta.Text = oFrm.oConcepto.desCuentaPro;
                        }

                        txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                        txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                        txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                        txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    }

                    VariablesLocales.EsLiquidacion = Variables.NO;
                }
            }
            catch (Exception ex)
            {
                VariablesLocales.EsLiquidacion = Variables.NO;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodConcepto_TextChanged(object sender, EventArgs e)
        {
            txtCodConcepto.Tag = 0;
            txtDesConcepto.Text = String.Empty;
        }

        private void txtDesConcepto_TextChanged(object sender, EventArgs e)
        {
            txtCodConcepto.Tag = 0;
            txtCodConcepto.Text = String.Empty;
        }

        private void btReparable_Click(object sender, EventArgs e)
        {
            try
            {
                if (oLiquidacion != null)
                {
                    frmDetalleReparable oFrm = new frmDetalleReparable(oLiquidacion.indReparable, oLiquidacion.idConceptoRep.Value, oLiquidacion.desReferenciaRep);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oLiquidacion.indReparable = oFrm.indReparable;
                        oLiquidacion.idConceptoRep = oFrm.idConceptoRep;
                        oLiquidacion.desReferenciaRep = oFrm.desReferenciaRep;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
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
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
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
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
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
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;
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
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
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
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
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
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumentos.SelectedValue.ToString() == "FC" || cboDocumentos.SelectedValue.ToString() == "BR" || cboDocumentos.SelectedValue.ToString() == "CR" || cboDocumentos.SelectedValue.ToString() == "DR")
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

        private void txtNumDocumento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumentos.SelectedValue.ToString() == "FC" || cboDocumentos.SelectedValue.ToString() == "BR" || cboDocumentos.SelectedValue.ToString() == "CR" || cboDocumentos.SelectedValue.ToString() == "DR")
                {
                    if (!String.IsNullOrEmpty(txtNumDocumento.Text.Trim()))
                    {
                        if (txtNumDocumento.TextLength < txtNumDocumento.MaxLength && Global.EsNumero(txtNumDocumento.Text))
                        {
                            txtNumDocumento.Text = txtNumDocumento.Text.PadLeft(8, '0');
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btConceptos_Click(object sender, EventArgs e)
        {
            try
            {
                VariablesLocales.EsLiquidacion = Variables.SI;
                frmBuscarConceptosVarios oFrm = new frmBuscarConceptosVarios(0);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                {
                    txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                    txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                    txtCodConcepto.Tag = oFrm.oConcepto.idConcepto;
                    txtCodConcepto.Text = oFrm.oConcepto.codConcepto;
                    txtDesConcepto.Text = oFrm.oConcepto.Descripcion;

                    if (TipoCuenta == "TLVE") //Venta
                    {
                        txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                        txtCodCuenta.Text = oFrm.oConcepto.codCuentaVen;
                        txtDesCuenta.Text = oFrm.oConcepto.desCuentaVen;
                        oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(oFrm.oConcepto.codCuentaVen);
                    }

                    if (TipoCuenta == "TLADM") //Administración
                    {
                        txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                        txtCodCuenta.Text = oFrm.oConcepto.codCuentaAdm;
                        txtDesCuenta.Text = oFrm.oConcepto.desCuentaAdm;
                        oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(oFrm.oConcepto.codCuentaAdm);
                    }

                    if (TipoCuenta == "TLPRO") //Producción
                    {
                        txtCodCuenta.Tag = oFrm.oConcepto.numVerPlanCuentas;
                        txtCodCuenta.Text = oFrm.oConcepto.codCuentaPro;
                        txtDesCuenta.Text = oFrm.oConcepto.desCuentaPro;
                        oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(oFrm.oConcepto.codCuentaPro);
                    }

                    HabilitaTextBoxMovimientos("CN");

                    txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                    txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    oPlanCuentasGenerado = null;
                }

                VariablesLocales.EsLiquidacion = Variables.NO;
            }
            catch (Exception ex)
            {
                VariablesLocales.EsLiquidacion = Variables.NO;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCCostos_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCCostos.Text.Trim()))
            {
                txtDesCCostos.Text = String.Empty;
            }
        }

        private void txtCCostos_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCCostos.Text.Trim()))
                {
                    CCostosE oCCosto = AgenteMaestro.Proxy.ObtenerCCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCCostos.Text.Trim());

                    if (oCCosto != null)
                    {
                        txtCCostos.Text = oCCosto.idCCostos;
                        txtDesCCostos.Text = oCCosto.desCCostos;
                    }
                    else
                    {
                        txtDesCCostos.Text = String.Empty;
                        Global.MensajeFault("EL código ingresado no existe");
                        btCentroC.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCentroC_Click(object sender, EventArgs e)
        {

            Int32 Nivel = 1;

            if (oParametrosConta != null)
            {
                if (oParametrosConta.numNivelCCosto > 0)
                {
                    Nivel = Convert.ToInt32(oParametrosConta.numNivelCCosto);
                }
            }

            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(Nivel);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtCCostos.Text = oFrm.CentroCosto.idCCostos;
                txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        private void btRecibosH_Click(object sender, EventArgs e)
        {
            try
            {
                frmPendientesRRHH oFrm = new frmPendientesRRHH();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCtaCte != null)
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                    txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

                    cboDocumentos.SelectedValue = oFrm.oCtaCte.idDocumento;
                    txtSerie.Text = oFrm.oCtaCte.numSerie;
                    txtNumDocumento.Text = oFrm.oCtaCte.numDocumento;
                    dtpFecha.Value = oFrm.oCtaCte.FechaDocumento;
                    cboMonedas.SelectedValue = oFrm.oCtaCte.idMoneda;
                    txtMonto.Text = oFrm.oCtaCte.Saldo.ToString("N2");
                    txtTica.Text = oFrm.oCtaCte.TipoCambio.ToString("N3");
                    txtMontoLiqui.Text = oFrm.oCtaCte.Saldo.ToString("N2");
                    txtRuc.Tag = oFrm.oCtaCte.idPersona;
                    txtRuc.Text = oFrm.oCtaCte.RUC;
                    txtRazonSocial.Text = oFrm.oCtaCte.RazonSocial;
                    txtGlosa.Text = oFrm.oCtaCte.desGlosa;
                    txtCodCuenta.Tag = oFrm.oCtaCte.numVerPlanCuentas;
                    txtCodCuenta.Text = oFrm.oCtaCte.codCuenta;
                    txtDesCuenta.Text = oFrm.oCtaCte.desCuenta;

                    if (oFrm.oCtaCte.idConcepto != 0)
                    {
                        ConceptosVariosE oConcepto = new AlmacenServiceAgent().Proxy.ObtenerConceptosVarios(oFrm.oCtaCte.idConcepto, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                        if (oConcepto != null)
                        {
                            txtCodConcepto.Tag = oConcepto.idConcepto;
                            txtCodConcepto.Text = oConcepto.codConcepto;
                            txtDesConcepto.Text = oConcepto.Descripcion;
                        }
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                    txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                    txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
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
