using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmOrdenPagoDetalle : frmResponseBase
    {

        #region Contructores

        public frmOrdenPagoDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        //Nuevo
        public frmOrdenPagoDetalle(List<TipoPagoE> ListaTipoPago_, String Tipo_, String TipoPago_, Int32 Concepto_, String FormaPago_, DateTime fecOperacion)
            :this()
        {
            ListaTipoPago = ListaTipoPago_;
            Tipo = Tipo_;

            TipoPago = TipoPago_;
            Concepto = Concepto_;
            FormaPago = FormaPago_;

            Anio = fecOperacion.ToString("yyyy");
            Mes = fecOperacion.ToString("MM");
        }

        //Editar
        public frmOrdenPagoDetalle(OrdenPagoDetE oPagoDet, List<TipoPagoE> ListaTipoPago_, String Tipo_, Int32 idAuxiTmp, String Bloquear, DateTime fecOperacion)
            : this()
        {
            OrdenPagoItem = oPagoDet;
            txtIdAuxiliar.Text = oPagoDet.idProveedor.ToString();
            ListaTipoPago = ListaTipoPago_;
            Tipo = Tipo_;
            idPersonaAuxiliar = idAuxiTmp;
            BloqSN = Bloquear;

            Anio = fecOperacion.ToString("yyyy");
            Mes = fecOperacion.ToString("MM");
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public OrdenPagoDetE OrdenPagoItem = null;
        List<TipoPagoE> ListaTipoPago = null;
        String Tipo = "M"; // M=Manual L=Liquidacion S=Solicitud Adelanto Proveedor.
        Int32 idPersonaAuxiliar = 0; //Para poder hacer la busqueda de las cuentas de fondo fijo y rendiciones.
        String TipoPago = "0"; Int32 Concepto = 0; String FormaPago = "0"; //Para seleccionar el tipo, el concepto y forma de pago.
        String BuscarDato = "S";
        String BloqSN = "N";
        String Anio = String.Empty; String Mes = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Monedas
            List<MonedasE> listaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.LlenarCombos<MonedasE>(cboMonedas, (from x in listaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");
            ComboHelper.LlenarCombos<MonedasE>(cboMonedaBanco, (from x in listaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");
            ComboHelper.LlenarCombos<MonedasE>(cboMonedasPago, (from x in listaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");
            
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                    where x.indTesoreria == true
                                                    select x).ToList();
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");

            // Tipos de Pago
            ComboHelper.RellenarCombos<TipoPagoE>(cboTipoPago, (from x in ListaTipoPago orderby x.codTipoPago select x).ToList(), "codTipoPago", "desTipoPago");
            
            listaMonedas = null;
            ListaDocumentos = null;
        }

        void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Pro)
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Proveedor. Desea agregarlo?") == DialogResult.Yes)
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

        void LlenarBancos()
        {
            List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<BancosE>(cboBancos, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");

            if (oListarBancos == null || oListarBancos.Count == 0)
            {
                cboBancos.Enabled = false;
            }
            else
            {
                if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "PL" || ((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "RCTA")
                {
                    cboBancos.Enabled = false;
                }
                else
                {
                    cboBancos.Enabled = true;
                }
            }

            oListarBancos = null;
        }

        void LlenarTipoCuentas()
        {
            //Limpiando el combo
            cboTipoCuenta.DataSource = null;
            //RCTAA
            if ((((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "PL" && ((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "RCTA") && Tipo == "M")
            {
                List<ProveedorCuentaE> oListaTipos = AgenteMaestro.Proxy.TipoCuentaProv(Convert.ToInt32(txtIdAuxiliar.Text), VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboBancos.SelectedValue));
                ComboHelper.RellenarCombos<ProveedorCuentaE>(cboTipoCuenta, oListaTipos, "tipCuenta", "desTipoCuenta");

                if (oListaTipos == null || oListaTipos.Count == 0)
                {
                    cboTipoCuenta.Enabled = false;
                }
                else
                {
                    cboTipoCuenta.Enabled = true;
                }
            }
            else
            {
                if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "PL")
                {
                    cboTipoCuenta.Enabled = false;
                }

                List<ParTabla> ListaTipo = AgenteGeneral.Proxy.ListarParTablaPorNemo("CTABAN");
                ComboHelper.RellenarCombos<ParTabla>(cboTipoCuenta, (from x in ListaTipo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
            }
        }

        void LlenarCuentasBancarias()
        {
            //Limpiando el combobox
            cboCuentasBancarias.DataSource = null;

            switch (Tipo)
            {
                case "M"://Manual

                    if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "PL" && ((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "RCTA")
                    {
                        List<ProveedorCuentaE> oListaCuentas1 = AgenteMaestro.Proxy.CuentasBancosProv(Convert.ToInt32(txtIdAuxiliar.Text), VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                Convert.ToInt32(cboBancos.SelectedValue), Convert.ToInt32(cboTipoCuenta.SelectedValue));
                        ComboHelper.RellenarCombos<ProveedorCuentaE>(cboCuentasBancarias, oListaCuentas1, "CuentaBanco", "desCuenta");
                        cboMonedaBanco.SelectedValue = ((ProveedorCuentaE)cboTipoCuenta.SelectedItem).idMoneda;

                        if (oListaCuentas1 == null || oListaCuentas1.Count == 0)
                        {
                            cboCuentasBancarias.Enabled = false;
                        }
                        else
                        {
                            cboCuentasBancarias.Enabled = true;
                        }

                        oListaCuentas1 = null;
                    }
                    else
                    {
                        cboMonedaBanco.SelectedValue = ((ParTabla)cboTipoCuenta.SelectedItem).ValorCadena;
                    }

                    break;
                case "L": //Liquidación

                    List<FondoFijoE> oListaCuentaFF = AgenteTesoreria.Proxy.FondoFijoCuentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersonaAuxiliar);
                    ComboHelper.RellenarCombos<FondoFijoE>(cboCuentasBancarias, oListaCuentaFF, "numCuenta", "desCuenta");

                    if (oListaCuentaFF == null || oListaCuentaFF.Count == 0)
                    {
                        cboCuentasBancarias.Enabled = false;
                    }
                    else
                    {
                        cboCuentasBancarias.Enabled = true;
                    }

                    oListaCuentaFF = null;

                    break;
                case "S": //Solicitud de Proveedor/Adelantos

                    List<ProveedorCuentaE> oListaCuentas2 = AgenteMaestro.Proxy.CuentasBancosProv(Convert.ToInt32(txtIdAuxiliar.Text), VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                Convert.ToInt32(cboBancos.SelectedValue), Convert.ToInt32(cboTipoCuenta.SelectedValue));
                    ComboHelper.RellenarCombos<ProveedorCuentaE>(cboCuentasBancarias, oListaCuentas2, "CuentaBanco", "desCuenta");

                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (OrdenPagoItem == null)
            {
                OrdenPagoItem = new OrdenPagoDetE();

                OrdenPagoItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                OrdenPagoItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                OrdenPagoItem.idLocal = VariablesLocales.SesionLocal.IdLocal;

                if (TipoPago != "0")
                {
                    cboTipoPago.SelectedValue = TipoPago;
                    cboTipoPago_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboConceptos.SelectedValue = Concepto;
                    cboConceptos_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboFormaPago.SelectedValue = FormaPago;
                }
                else
                {
                    cboTipoPago.SelectedValue = "0";
                    cboTipoPago_SelectionChangeCommitted(new Object(), new EventArgs());
                }

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                {
                    LlenarBancos();

                    if (!String.IsNullOrWhiteSpace(txtIdAuxiliar.Text))
                    {
                        LlenarTipoCuentas();
                    }
                }
                else
                {
                    pnlDatosBancarios.Enabled = false;
                    cboBancos.DataSource = null;
                    cboTipoCuenta.DataSource = null;
                    cboCuentasBancarias.DataSource = null;
                }
                
                chkIndPago.Checked = false;
            }
            else
            {
                BuscarDato = "N";
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                if (OrdenPagoItem.Opcion == 0)
                {
                    OrdenPagoItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtIdAuxiliar.Text = Convert.ToString(OrdenPagoItem.idProveedor);
                txtRuc.Text = OrdenPagoItem.RucProv;
                txtRazonSocial.Text = OrdenPagoItem.desProveedor;
                cboTipoPago.SelectedValue = OrdenPagoItem.codTipoPago.ToString();
                cboTipoPago_SelectionChangeCommitted(new Object(), new EventArgs());
                cboConceptos.SelectedValue = Convert.ToInt32(OrdenPagoItem.idConcepto);
                cboConceptos_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFormaPago.SelectedValue = OrdenPagoItem.codFormaPago.ToString();
                cboFormaPago_SelectionChangeCommitted(new Object(), new EventArgs());
                cboDocumento.SelectedValue = String.IsNullOrWhiteSpace(OrdenPagoItem.idDocumento) ? "0" : OrdenPagoItem.idDocumento;
                txtSerie.Text = OrdenPagoItem.serDocumento;
                txtNumero.Text = OrdenPagoItem.numDocumento;
                cboMonedas.SelectedValue = OrdenPagoItem.idMoneda;
                txtMonto.Text = OrdenPagoItem.Monto.ToString("N2");

                cboMonedasPago.SelectedValue = OrdenPagoItem.idMonedaPago;
                txtMontoPago.Text = OrdenPagoItem.MontoPago.ToString("N2");

                txtCodPartida.Text = OrdenPagoItem.CodPartidaPresu;
                txtDesPartida.Text = OrdenPagoItem.DesPartida;

                txtConcepto.Text = OrdenPagoItem.Concepto;
                txtDes.Text = OrdenPagoItem.Descripcion;
                dtpFecha.Value = Convert.ToDateTime(OrdenPagoItem.Fecha);

                if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                {
                    if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "PL" || ((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "RCTA")
                    {
                        if (cboBancos.SelectedValue == null)
                        {
                            LlenarBancos();
                        }

                        if (cboTipoCuenta.SelectedValue == null)
                        {
                            LlenarTipoCuentas();
                        }

                        cboBancos.SelectedValue = Convert.ToInt32(OrdenPagoItem.idBanco);
                        cboTipoCuenta.SelectedValue = Convert.ToInt32(OrdenPagoItem.tipCuenta);
                        cboMonedaBanco.SelectedValue = OrdenPagoItem.idMonedaBanco.ToString();
                        txtNumCuenta.Text = OrdenPagoItem.numCtaBancaria.ToString();
                    }
                    else
                    {
                        if (cboBancos.SelectedValue == null)
                        {
                            LlenarBancos();
                        }

                        cboBancos.SelectedValue = Convert.ToInt32(OrdenPagoItem.idBanco);

                        if (cboTipoCuenta.SelectedValue == null)
                        {
                            LlenarTipoCuentas();
                        }

                        //cboBancos.SelectedValue = Convert.ToInt32(OrdenPagoItem.idBanco);
                        //cboBancos_SelectionChangeCommitted(new Object(), new EventArgs());
                        cboTipoCuenta.SelectedValue = Convert.ToInt32(OrdenPagoItem.tipCuenta);
                        cboTipoCuenta_SelectionChangeCommitted(new Object(), new EventArgs());
                        cboCuentasBancarias.SelectedValue = OrdenPagoItem.numCtaBancaria.ToString();
                        cboMonedaBanco.SelectedValue = OrdenPagoItem.idMonedaBanco.ToString();
                    }
                }

                chkIndPago.Checked = OrdenPagoItem.indPago;
                chkIndPago_CheckedChanged(null, null);

                txtUsuarioRegistro.Text = OrdenPagoItem.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(OrdenPagoItem.FechaRegistro);
                txtUsuarioModificacion.Text = OrdenPagoItem.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(OrdenPagoItem.FechaModificacion);

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                BuscarDato = "S";
            }

            if (OrdenPagoItem.indAuto)
            {
                if (BloqSN == "N")
                {
                    pnlBase.Enabled = true;
                    pnlDatosBancarios.Enabled = true;
                    btAceptar.Enabled = true;
                }
                else
                {
                    pnlBase.Enabled = false;
                    pnlDatosBancarios.Enabled = false;
                    //btAceptar.Enabled = false;
                }
            }
            else
            {
                if (BloqSN == "N")
                {
                    base.Nuevo();
                }
                else
                {
                    pnlBase.Enabled = false;
                    pnlDatosBancarios.Enabled = false;
                    //btAceptar.Enabled = false;
                }
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    if (OrdenPagoItem != null)
                    {
                        OrdenPagoItem.codTipoPago = cboTipoPago.SelectedValue.ToString();
                        OrdenPagoItem.idConcepto = Convert.ToInt32(cboConceptos.SelectedValue);
                        OrdenPagoItem.codFormaPago = cboFormaPago.SelectedValue.ToString();
                        OrdenPagoItem.Fecha = dtpFecha.Value.Date;
                        OrdenPagoItem.idProveedor = Convert.ToInt32(txtIdAuxiliar.Text);
                        OrdenPagoItem.RucProv = txtRuc.Text.Trim();
                        OrdenPagoItem.desProveedor = txtRazonSocial.Text.Trim();
                        OrdenPagoItem.idDocumento = Convert.ToString(cboDocumento.SelectedValue) == "0" ? String.Empty : Convert.ToString(cboDocumento.SelectedValue);
                        OrdenPagoItem.serDocumento = txtSerie.Text.Trim();
                        OrdenPagoItem.numDocumento = txtNumero.Text.Trim();
                        OrdenPagoItem.idMoneda = Convert.ToString(cboMonedas.SelectedValue);
                        OrdenPagoItem.desMoneda = ((MonedasE)cboMonedas.SelectedItem).desAbreviatura;
                        OrdenPagoItem.Monto = Convert.ToDecimal(txtMonto.Text);
                        OrdenPagoItem.CodPartidaPresu = txtCodPartida.Text;
                        OrdenPagoItem.DesPartida = txtDesPartida.Text;
                        OrdenPagoItem.idMonedaPago = Convert.ToString(cboMonedasPago.SelectedValue);
                        OrdenPagoItem.MontoPago = Convert.ToDecimal(txtMontoPago.Text);

                        TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia("02", OrdenPagoItem.Fecha.ToString("yyyyMMdd"));

                        if (oTica != null)
                        {
                            if (OrdenPagoItem.idMoneda == "01")
                            {
                                OrdenPagoItem.MontoSecu = Convert.ToDecimal(txtMonto.Text) / oTica.valVenta;
                            }
                            else
                            {
                                OrdenPagoItem.MontoSecu = Convert.ToDecimal(txtMonto.Text) / oTica.valVenta;
                            }
                        }

                        OrdenPagoItem.Concepto = txtConcepto.Text;
                        OrdenPagoItem.Descripcion = txtDes.Text;

                        if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                        {
                            OrdenPagoItem.idBanco = Convert.ToInt32(cboBancos.SelectedValue);
                            OrdenPagoItem.tipCuenta = Convert.ToInt32(cboTipoCuenta.SelectedValue);
                            OrdenPagoItem.idMonedaBanco = cboMonedaBanco.SelectedValue.ToString();
                            OrdenPagoItem.desMonedaBanco = ((MonedasE)cboMonedaBanco.SelectedItem).desAbreviatura;

                            if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "PL" || ((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "RCTA")
                            {
                                OrdenPagoItem.numCtaBancaria = txtNumCuenta.Text.Trim();
                            }
                            else
                            {
                                OrdenPagoItem.numCtaBancaria = cboCuentasBancarias.SelectedValue.ToString();
                            }
                        }
                        else
                        {
                            OrdenPagoItem.idBanco = null;
                            OrdenPagoItem.tipCuenta = null;
                            OrdenPagoItem.idMonedaBanco = String.Empty;
                            OrdenPagoItem.desMonedaBanco = String.Empty;
                            OrdenPagoItem.numCtaBancaria = String.Empty;
                        }

                        OrdenPagoItem.indPago = chkIndPago.Checked;

                        if (OrdenPagoItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            OrdenPagoItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            OrdenPagoItem.FechaRegistro = VariablesLocales.FechaHoy;
                            OrdenPagoItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            OrdenPagoItem.FechaModificacion = VariablesLocales.FechaHoy;
                        }
                        else
                        {
                            OrdenPagoItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            OrdenPagoItem.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                        }

                        base.Aceptar();
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "PL" && ((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "RCTA")
            {
                if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                {
                    if (cboBancos.SelectedValue == null)
                    {
                        Global.MensajeFault("No existen datos bancarios para este Auxiliar, debe ingresarlas en Maestros - Auxiliares - Proveedores.");
                        cboBancos.Focus();
                        return false;
                    }

                    if (cboTipoCuenta.SelectedValue == null)
                    {
                        Global.MensajeFault("Faltan datos bancarios para este Auxiliar, debe ingresarlas en Maestros - Auxiliares - Proveedores.");
                        cboTipoCuenta.Focus();
                        return false;
                    }

                    if (cboCuentasBancarias.SelectedValue == null)
                    {
                        Global.MensajeFault("Faltan datos bancarios para este Auxiliar, debe ingresarlas en Maestros - Auxiliares - Proveedores.");
                        cboCuentasBancarias.Focus();
                        return false;
                    }
                }
            }
            else
            {
                if (cboBancos.SelectedValue == null)
                {
                    Global.MensajeFault("No existen datos bancarios para este Trabajador, debe ingresarlas en el Maestro de Trabajadores");
                    cboBancos.Focus();
                    return false;
                }

                if (cboTipoCuenta.SelectedValue == null)
                {
                    Global.MensajeFault("Faltan datos bancarios para este Trabajador, debe ingresarlas en Maestros de Trabajadores.");
                    cboTipoCuenta.Focus();
                    return false;
                }

                if (String.IsNullOrWhiteSpace(txtNumCuenta.Text.Trim()))
                {
                    Global.MensajeFault("Faltan datos bancarios para este Trabajador, debe ingresarlas en Maestros de Trabajadores.");
                    txtRuc.Focus();
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmOrdenPagoDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarCombos();
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "PL" && ((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "RCTA")
                    {
                        List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                        if (oListaPersonas.Count > Variables.ValorUno)
                        {
                            frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                            {
                                txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                                txtRuc.Text = oFrm.oPersona.RUC;
                                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                                cboFormaPago_SelectionChangeCommitted(new Object(), new EventArgs());
                            }
                            else
                            {
                                txtRazonSocial.Focus();
                            }
                        }
                        else if (oListaPersonas.Count == 1)
                        {
                            ValidarAuxiliar(oListaPersonas);
                            txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                            txtRuc.Text = oListaPersonas[0].RUC;
                            txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                            cboFormaPago_SelectionChangeCommitted(new Object(), new EventArgs());
                        }
                        else
                        {
                            Global.MensajeFault("La Razón Social ingresada no existe");
                            txtIdAuxiliar.Text = String.Empty;
                            txtRuc.Text = String.Empty;
                            txtRazonSocial.Text = String.Empty;
                        } 
                    }
                    else
                    {
                        //List<TrabajadorE> oListaTrabajadores = AgenteMaestro.Proxy.ListarTrabajadorPorAnioMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text, Anio, Mes);

                        //if (oListaTrabajadores.Count > Variables.ValorUno)
                        //{
                        //    frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaTrabajadores);

                        //    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        //    {
                        //        txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                        //        txtRuc.Text = oFrm.oPersona.RUC;
                        //        txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                        //        if (cboBancos.SelectedValue == null)
                        //        {
                        //            LlenarBancos();
                        //        }

                        //        if (cboTipoCuenta.SelectedValue == null)
                        //        {
                        //            LlenarTipoCuentas();
                        //        }

                        //        cboBancos.SelectedValue = Convert.ToInt32(oFrm.oPersona.idBancoPago);
                        //        cboTipoCuenta.SelectedValue = Convert.ToInt32(oFrm.oPersona.idTipoCuentaPago);
                        //        cboMonedaBanco.SelectedValue = oFrm.oPersona.idMonedaPago;
                        //        txtNumCuenta.Text = oFrm.oPersona.NumCuentaPago;
                        //    }
                        //    else
                        //    {
                        //        txtRazonSocial.Focus();
                        //    }
                        //}
                        //else if (oListaTrabajadores.Count == 1)
                        //{
                        //    txtIdAuxiliar.Text = oListaTrabajadores[0].idPersona.ToString();
                        //    txtRuc.Text = oListaTrabajadores[0].RUC;
                        //    txtRazonSocial.Text = oListaTrabajadores[0].RazonSocial;

                        //    if (cboBancos.SelectedValue == null)
                        //    {
                        //        LlenarBancos();
                        //    }

                        //    if (cboTipoCuenta.SelectedValue == null)
                        //    {
                        //        LlenarTipoCuentas();
                        //    }

                        //    cboBancos.SelectedValue = Convert.ToInt32(oListaTrabajadores[0].idBancoPago);
                        //    cboTipoCuenta.SelectedValue = Convert.ToInt32(oListaTrabajadores[0].idTipoCuentaPago);
                        //    cboMonedaBanco.SelectedValue = oListaTrabajadores[0].idMonedaPago;
                        //    txtNumCuenta.Text = oListaTrabajadores[0].NumCuentaPago;
                        //}
                        //else
                        //{
                        //    Global.MensajeFault("El nombre del trabajador ingresado no existe");
                        //    txtIdAuxiliar.Text = String.Empty;
                        //    txtRuc.Text = String.Empty;
                        //    txtRazonSocial.Text = String.Empty;
                        //    txtNumCuenta.Text = String.Empty;
                        //    txtRazonSocial.Focus();
                        //}
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

        private void btProveedor_Click(object sender, EventArgs e)
        {
            frmBusquedaProveedor oFrm = new frmBusquedaProveedor();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProveedor != null)
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                txtRazonSocial.Text = oFrm.oProveedor.RazonSocial;
                txtRuc.Text = oFrm.oProveedor.RUC;
                txtIdAuxiliar.Text = Convert.ToString(oFrm.oProveedor.IdPersona);

                cboFormaPago_SelectionChangeCommitted(new Object(), new EventArgs());

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
        }

        private void cboBancos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancos.SelectedValue != null)
                {
                    if (!String.IsNullOrWhiteSpace(txtIdAuxiliar.Text))
                    {
                        LlenarTipoCuentas();
                        cboTipoCuenta_SelectionChangeCommitted(new Object(), new EventArgs());
                    }
                }
                else
                {
                    cboBancos.Enabled = false;
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
                if (cboTipoCuenta.SelectedValue != null)
                {
                    LlenarCuentasBancarias();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkIndPago_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndPago.Checked)
            {
                chkIndPago.Text = "Esta Pagado";
            }
            else
            {
                chkIndPago.Text = "Pendiente";
            }
        }

        private void cboTipoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoPago.SelectedValue != null)
                {
                    List<TipoPagoDetE> oLista = new List<TipoPagoDetE>(((TipoPagoE)cboTipoPago.SelectedItem).DetalleTipoPago);
                    oLista.Add(new TipoPagoDetE() { idConcepto = Variables.Cero, desConcepto = Variables.Seleccione });
                    ComboHelper.RellenarCombos<TipoPagoDetE>(cboConceptos, (from x in oLista orderby x.idConcepto select x).ToList(), "idConcepto", "desConcepto", false);

                    if (cboTipoPago.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboConceptos.Enabled = false;
                    }
                    else
                    {
                        cboConceptos.Enabled = true;
                    }

                    cboConceptos_SelectionChangeCommitted(new Object(), new EventArgs());

                    if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "PL" || ((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "RCTA")
                    {
                        cboBancos.Enabled = false;
                        cboTipoCuenta.Enabled = false;
                        txtNumCuenta.Visible = true;
                        cboCuentasBancarias.Visible = false;
                    }
                    else
                    {
                        cboBancos.Enabled = true;
                        cboTipoCuenta.Enabled = true;
                        txtNumCuenta.Visible = false;
                        cboCuentasBancarias.Visible = true;
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
            //if (((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "14")
            //{
            //    pnlDatosBancarios.Enabled = false;
            //}
            //else
            //{
            //    pnlDatosBancarios.Enabled = true;
            //}
        }

        private void cboConceptos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoPago.SelectedValue != null && cboConceptos.SelectedValue != null)
                {
                    List<FormaPagoE> ListaFormaPago = AgenteTesoreria.Proxy.ListarFormaPagoPorTipo(cboTipoPago.SelectedValue.ToString(), Convert.ToInt32(cboConceptos.SelectedValue), VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                    ComboHelper.RellenarCombos<FormaPagoE>(cboFormaPago, (from x in ListaFormaPago orderby x.codFormaPago select x).ToList(), "codFormaPago", "desFormaPago");

                    if (ListaFormaPago.Count == 0)
                    {
                        cboFormaPago.Enabled = false;
                    }
                    else
                    {
                        cboFormaPago.Enabled = true;
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

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "PL")
                    {
                        List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                        if (oListaPersonas.Count > Variables.ValorUno)
                        {
                            frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                            {
                                if (cboBancos.SelectedValue == null)
                                {
                                    LlenarBancos();
                                }

                                if (cboTipoCuenta.SelectedValue == null)
                                {
                                    LlenarTipoCuentas();
                                }

                                txtRuc.Text = oFrm.oPersona.RUC;
                                txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                                cboFormaPago_SelectionChangeCommitted(new Object(), new EventArgs());
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
                            txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                            txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                            cboFormaPago_SelectionChangeCommitted(new Object(), new EventArgs());
                        }
                        else
                        {
                            Global.MensajeFault("El Ruc ingresado no existe");
                            txtIdAuxiliar.Text = String.Empty;
                            txtRuc.Text = String.Empty;
                            txtRazonSocial.Text = String.Empty;
                            txtRuc.Focus();
                        }
                    }
                    else
                    {
                        //List<TrabajadorE> oListaTrabajadores = AgenteMaestro.Proxy.ListarTrabajadorPorAnioMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text, Anio, Mes);

                        //if (oListaTrabajadores.Count > Variables.ValorUno)
                        //{
                        //    frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaTrabajadores);

                        //    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        //    {
                        //        if (cboBancos.SelectedValue == null)
                        //        {
                        //            LlenarBancos();
                        //        }

                        //        if (cboTipoCuenta.SelectedValue == null)
                        //        {
                        //            LlenarTipoCuentas();
                        //        }

                        //        txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                        //        txtRuc.Text = oFrm.oPersona.RUC;
                        //        txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        //        cboBancos.SelectedValue = Convert.ToInt32(oFrm.oPersona.idBancoPago);
                        //        cboTipoCuenta.SelectedValue = Convert.ToInt32(oFrm.oPersona.idTipoCuentaPago);
                        //        cboMonedaBanco.SelectedValue = oFrm.oPersona.idMonedaPago;
                        //        txtNumCuenta.Text = oFrm.oPersona.NumCuentaPago;
                        //    }
                        //    else
                        //    {
                        //        txtRuc.Focus();
                        //    }
                        //}
                        //else if (oListaTrabajadores.Count == 1)
                        //{
                        //    if (cboBancos.SelectedValue == null)
                        //    {
                        //        LlenarBancos();
                        //    }

                        //    if (cboTipoCuenta.SelectedValue == null)
                        //    {
                        //        LlenarTipoCuentas();
                        //    }

                        //    txtIdAuxiliar.Text = oListaTrabajadores[0].idPersona.ToString();
                        //    txtRuc.Text = oListaTrabajadores[0].RUC;
                        //    txtRazonSocial.Text = oListaTrabajadores[0].RazonSocial;

                        //    cboBancos.SelectedValue = Convert.ToInt32(oListaTrabajadores[0].idBancoPago);
                        //    cboTipoCuenta.SelectedValue = Convert.ToInt32(oListaTrabajadores[0].idTipoCuentaPago);
                        //    cboMonedaBanco.SelectedValue = oListaTrabajadores[0].idMonedaPago;
                        //    txtNumCuenta.Text = oListaTrabajadores[0].NumCuentaPago;
                        //}
                        //else
                        //{
                        //    Global.MensajeFault("El Nro de documento del trabajador ingresado no existe");
                        //    txtIdAuxiliar.Text = String.Empty;
                        //    txtRuc.Text = String.Empty;
                        //    txtNumCuenta.Text = String.Empty;
                        //    txtRuc.Focus();
                        //}
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

        private void cboFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboFormaPago.SelectedValue != null)
                {
                    if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                    {
                        pnlDatosBancarios.Enabled = true;

                        if (BuscarDato == "S")
                        {
                            if (cboBancos.SelectedValue == null)
                            {
                                LlenarBancos();
                            }

                            if (!String.IsNullOrWhiteSpace(txtIdAuxiliar.Text))
                            {
                                LlenarTipoCuentas();
                            }
                        }
                    }
                    else
                    {
                        pnlDatosBancarios.Enabled = false;
                        cboBancos.DataSource = null;
                        cboTipoCuenta.DataSource = null;
                        cboCuentasBancarias.DataSource = null;
                    } 
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

        private void btPresupuesto_Click(object sender, EventArgs e)
        {
            frmBuscarPartida oFrm = new frmBuscarPartida();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
            {
                txtCodPartida.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                txtDesPartida.Text = oFrm.oPartidaPresupuestal.desPartidaPresu;
                OrdenPagoItem.TipPartidaPresu = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                OrdenPagoItem.CodPartidaPresu = oFrm.oPartidaPresupuestal.codPartidaPresu;
            }
        }

        #endregion

    }
}
