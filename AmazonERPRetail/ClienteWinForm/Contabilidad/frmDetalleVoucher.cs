using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmDetalleVoucher : frmResponseBase
    {

        #region Constructores

        public frmDetalleVoucher()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        public frmDetalleVoucher(VoucherE oVoucher_, VoucherItemE oVoucherItem_, VoucherItemE oVoucherItemTmp = null, String indBloqueo = Variables.NO, bool LlevaCuenta = false, String Cuenta = "")
            : this()
        {
            oVoucherCab = oVoucher_;
            oVoucherDet = oVoucherItem_;

            if (oVoucherItemTmp != null)
            {
                Ruc = oVoucherItemTmp.Ruc;
                idPersona = oVoucherItemTmp.idPersona;
                RazonSocial = oVoucherItemTmp.RazonSocial;
            }

            if (indBloqueo == Variables.SI)
            {
                Bloqueo = indBloqueo;

                foreach (Control item in Controls)
                {
                    if (item is Panel)
                    {
                        item.Enabled = false;
                    }
                }

                btAceptar.Enabled = false;
                btPendientes.Enabled = false;
            }

            fileLlevaCuenta = LlevaCuenta;
            fileCuenta = Cuenta;
        }

        #endregion

        #region Variables Privadas

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        VoucherE oVoucherCab = null;

        Int32? idPersona = Variables.Cero; //Para colocar nuevamente el mismo idPersona en los textbox de ruc y razon social si pide auxiliar..
        String RazonSocial = String.Empty;//Para colocar nuevamente el mismo RazonSocial en los textbox de ruc y razon social si pide auxiliar..
        String Ruc = String.Empty;//Para colocar nuevamente el mismo Ruc en los textbox de ruc y razon social si pide auxiliar..
        String TipoPartida = String.Empty;
        Int32 Opcion = Variables.Cero;
        Boolean Cambio = false;
        Boolean indMovimientoCtaCte = false; //Para indicar si el botón de CtaCte a sido presionado o saber si devuelve valores...
        Boolean indDistribucion = false; //Para indicar si el botón de Distribucion de CCostos a sido presionado...
        Int32 idCtaCteTmp = Variables.Cero; //Para almacenar el idCtacte traida desde los documentos pendientes(botón de CtaCte)...
        String indCtaGasto = String.Empty;
        String CuentaTemporal = String.Empty;//Para almcenar la cuenta y saber si ha cambiado o no, esto sirve para la modificación..
        DataGridView oDataGridViewDetalle = new DataGridView();
        String Bloqueo = Variables.NO;
        Boolean conCuenta = false;

        Boolean fileLlevaCuenta = false;
        String fileCuenta = "";

        #endregion

        #region Variables Publicas

        public VoucherItemE oVoucherDet = null;
        public List<VoucherItemE> oListaVouchers = null;

        #endregion

        #region Procedimientos de Usuario

        void Registro()
        {
            if (oVoucherDet != null)
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                txtSoles.TextChanged -= txtSoles_TextChanged;
                txtDolares.TextChanged -= txtDolares_TextChanged;
                dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
                txtCuenta.TextChanged -= txtCuenta_TextChanged;

                Datos();

                txtSoles.TextChanged += txtSoles_TextChanged;
                txtDolares.TextChanged += txtDolares_TextChanged;
                dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                txtCuenta.TextChanged += txtCuenta_TextChanged;
            }
            else
            {
                oVoucherDet = new VoucherItemE();

                cboMedioPago.SelectedValue = Variables.Cero;
                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                DatosCabecera();
                Opcion = (Int32)EnumOpcionGrabar.Insertar;
                chkTicaAuto.Checked = true;
            }

            if (conCuenta)
            {
                txtCuenta_Validating(new Object(), new CancelEventArgs());
            }
        }

        void LlenarCombos()
        {
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral 
                                                                      where x.indBaja == false
                                                                      select x).ToList();
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = " " + Variables.Seleccione };
            ListaDocumentos.Add(Fila);
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos 
                                                                   orderby x.desDocumento 
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);

            ComboHelper.RellenarCombos<DocumentosE>(cboReferencia, (from x in ListaDocumentos 
                                                                    where x.EsReferencia == true || x.idDocumento == "0"
                                                                    orderby x.desDocumento 
                                                                    select x).ToList(), "idDocumento", "desDocumento", false);

            // Debe / Haber
            cboDebeHaber.DataSource = Global.CargarDH();
            cboDebeHaber.ValueMember = "id";
            cboDebeHaber.DisplayMember = "Nombre";

            // Si es Reparable
            cboReparable.DataSource = Global.CargarTipoReparable();
            cboReparable.ValueMember = "id";
            cboReparable.DisplayMember = "Nombre";

            // Conceptos reparables
            cboConceptoReparable.DataSource = Global.CargarConceptosReparable();
            cboConceptoReparable.ValueMember = "id";
            cboConceptoReparable.DisplayMember = "Nombre";

            // Detracciones
            //List<TasasDetraccionesE> ListarDetracciones = AgenteGeneral.Proxy.ListarTasasDetraccionesActivas();
            //TasasDetraccionesE FilaNueva = new TasasDetraccionesE() { idTipoDetraccion = Variables.Cero.ToString(), NombreTemp = "<<Seleccionar Detraccion>>" };
            //ListarDetracciones.Add(FilaNueva);
            //ComboHelper.LlenarCombos<TasasDetraccionesE>(cboTipoDetraccion, (from x in ListarDetracciones orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "NombreTemp");

            // Medios de Pago
            List<ParTabla> oListaMedioPago = new List<ParTabla>();
            oListaMedioPago = AgenteGeneral.Proxy.ListarParTablaPorNemo("MEDPAG");
            ParTabla oInicio = new ParTabla { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            oListaMedioPago.Add(oInicio);
            ComboHelper.RellenarCombos<List<ParTabla>>(cboMedioPago, (from x in oListaMedioPago orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMonedaCuenta.DataSource = (from x in ListaMoneda
                                          where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                          orderby x.idMoneda
                                          select x).ToList();
            cboMonedaCuenta.ValueMember = "idMoneda";
            cboMonedaCuenta.DisplayMember = "desAbreviatura";
        }

        void LlenarComboDetraccion(DateTime Fecha)
        {
            // Tipo de Detraccion
            List<TasasDetraccionesDetalleE> ListaTipoDetraccion = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(Fecha);

            if (ListaTipoDetraccion.Count > 0)
            {
                ListaTipoDetraccion.Add(new TasasDetraccionesDetalleE() { idTipoDetraccion = Variables.Cero.ToString(), NombreTemp = "<<Seleccionar Detracción>>" });
                ComboHelper.RellenarCombos<TasasDetraccionesDetalleE>(cboTipoDetraccion, (from x in ListaTipoDetraccion orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "NombreTemp", false);
            }
            else
            {
                Global.MensajeFault("No existe ningún Tipo de Detracción para la fecha escogida.");
                cboTipoDetraccion.DataSource = null;
            }
        }

        void Datos()
        {
            //Buscando en el plan de cuentas
            oVoucherDet.PlanCuenta = VariablesLocales.ObtenerPlanCuenta(oVoucherDet.codCuenta);

            if (oVoucherDet.PlanCuenta != null)
            {
                #region Si la cuenta pide Razon Social

                if (oVoucherDet.PlanCuenta.indSolicitaAnexo == Variables.SI)
                {
                    Persona oPersona = AgenteMaestro.Proxy.RecuperarPersonaPorID(Convert.ToInt32(oVoucherDet.idPersona));

                    if (oPersona != null)
                    {
                        idPersona = oPersona.IdPersona;
                        txtRuc.Text = oPersona.RUC;
                        txtRazonSocial.Text = oPersona.RazonSocial;
                    }
                }
                else
                {
                    oVoucherDet.idPersona = (Nullable<Int32>)null;
                    oVoucherDet.RazonSocial = String.Empty;
                }

                #endregion

                //Basico
                txtCuenta.Text = CuentaTemporal = oVoucherDet.PlanCuenta.codCuenta;
                txtDesCuenta.Text = oVoucherDet.PlanCuenta.Descripcion;

                if (oVoucherDet.idMoneda != null)
                {
                    cboMonedaCuenta.SelectedValue = oVoucherDet.idMoneda.ToString();
                }
                else
                {
                    if (oVoucherDet.PlanCuenta.idMoneda == Variables.Cero.ToString())
                    {
                        cboMonedaCuenta.SelectedValue = oVoucherCab.idMoneda;
                    }
                    else
                    {
                        cboMonedaCuenta.SelectedValue = oVoucherDet.PlanCuenta.idMoneda;
                    }
                }

                #region Si la cuenta solicita Centro de Costos

                if (oVoucherDet.PlanCuenta.indSolicitaCentroCosto == Variables.SI)
                {
                    txtCCostos.Text = oVoucherDet.idCCostos;

                    CCostosE CCostos = VariablesLocales.ListarCCostosPorSistema.Find
                    (
                        delegate(CCostosE cc) { return cc.idCCostos == oVoucherDet.idCCostos; } 
                    );

                    if (CCostos != null)
                    {
                        txtDesCCostos.Text = CCostos.desCCostos;
                    }
                } 

                #endregion

                #region Si la Cuenta solicita documento
                
                if (oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI)
                {
                    if (String.IsNullOrEmpty(oVoucherDet.idDocumento))
                    {
                        cboDocumento.SelectedValue = Variables.Cero.ToString();
                    }
                    else
                    {
                        cboDocumento.SelectedValue = oVoucherDet.idDocumento;
                        txtSerie.Text = oVoucherDet.serDocumento;
                        txtNumDoc.Text = oVoucherDet.numDocumento;

                        if (oVoucherDet.fecDocumento != null)
                        {
                            dtpFecDocumento.Value = Convert.ToDateTime(oVoucherDet.fecDocumento);
                            LlenarComboDetraccion(dtpFecDocumento.Value.Date);
                        }

                        if (oVoucherDet.fecVencimiento != null)
                        {
                            dtpFecVencimiento.Value = Convert.ToDateTime(oVoucherDet.fecVencimiento);  
                        }

                        if (oVoucherDet.fecRecepcion != null)
                        {
                            dtpFecRecepcion.Value = Convert.ToDateTime(oVoucherDet.fecRecepcion);
                        }
                    }
                }

                #endregion

                HabilitaTextBoxMovimientos();
                cboDocumento_Leave(new Object(), new EventArgs());

                #region Columna CoVen

                if (oVoucherDet.idComprobante == Variables.RegistroVenta || oVoucherDet.idComprobante == Variables.RegistroCompra)
                {
                    pnlColumnaCoVen.Enabled = Bloqueo == Variables.SI ? false : true;
                    
                    ComboHelper.LlenarCombos<ParTabla>(cboCoVen, RecuperarDetalleCoVen(Convert.ToInt32(oVoucherDet.PlanCuenta.codColumnaCoven)), "idPartabla", "Descripcion");

                    if (oVoucherDet.codColumnaCoven != Variables.Cero)
                    {
                        cboCoVen.SelectedValue = oVoucherDet.codColumnaCoven;
                    }
                }

                #endregion
                
                cboDebeHaber.SelectedValue = oVoucherDet.indDebeHaber;

                if (oVoucherDet.indCambio.Substring(0, 1) == Variables.SI)
                {
                    chkTicaAuto.Checked = true;
                }
                else
                {
                    chkTicaAuto.Checked = false;
                }

                #region Importes
                
                txtSoles.Text = oVoucherDet.impSoles.ToString("N2");
                txtDolares.Text = oVoucherDet.impDolares.ToString("N2");
                txtTica.Text = Convert.ToDecimal(oVoucherDet.tipCambio).ToString("N3"); 

                #endregion

                #region Detraccion
                
                if (oVoucherDet.flagDetraccion.Substring(0, 1) == Variables.SI)
                {
                    chkDetraccion.Checked = true;
                    txtNumDetra.Text = oVoucherDet.numDetraccion;
                    dtpFecDetraccion.Value = Convert.ToDateTime(oVoucherDet.fecDetraccion);
                    cboTipoDetraccion.SelectedValue = oVoucherDet.tipDetraccion;
                    txtTasaDetra.Text = Convert.ToDecimal(oVoucherDet.TasaDetraccion).ToString("N2");
                    txtMontoDetraccion.Text = Convert.ToDecimal(oVoucherDet.MontoDetraccion).ToString("N2");
                    chkIndPagoDetra.Checked = oVoucherDet.indPagoDetra;

                    if (oVoucherDet.idMoneda == Variables.Soles)
                    {
                        txtRedondeo.Text = Math.Round(Convert.ToDecimal(oVoucherDet.MontoDetraccion), MidpointRounding.AwayFromZero).ToString("N2");
                    }
                    else
                    {
                        txtRedondeo.Text = Math.Round(Convert.ToDecimal(oVoucherDet.MontoDetraccion * oVoucherDet.tipCambio), MidpointRounding.AwayFromZero).ToString("N2");
                    }
                }
                else
                {
                    chkDetraccion.Checked = false;
                    chkIndPagoDetra.Checked = true;
                } 

                #endregion

                txtGlosa.Text = oVoucherDet.desGlosa;

                #region Partida Presupuestaria
                
                if (!String.IsNullOrEmpty(oVoucherDet.PlanCuenta.tipPartidaPresu.Trim()))
                {
                    TipoPartida = oVoucherDet.tipPartidaPresu;
                    txtPartida.Text = oVoucherDet.codPartidaPresu;
                    txtDesPartida.Text = oVoucherDet.PlanCuenta.desPartidaPresu;
                }
                else
                {
                    TipoPartida = oVoucherDet.tipPartidaPresu;
                    txtPartida.Text = oVoucherDet.codPartidaPresu;
                    txtDesPartida.Text = oVoucherDet.desPartidaPresu;
                }

                #endregion              
                
                cboMedioPago.SelectedValue = oVoucherDet.codMedioPago;
                txtUsuRegistro.Text = oVoucherDet.UsuarioRegistro;
                txtFechaRegistro.Text = oVoucherDet.FechaRegistro.ToString();
                txtUsuModificacion.Text = oVoucherDet.UsuarioModificacion;
                txtFechaModificacion.Text = oVoucherDet.FechaModificacion.ToString();

                if (oVoucherDet.PlanCuenta.indCtaCte == Variables.SI)
                {
                    btPendientes.Enabled = Bloqueo == Variables.SI ? false : true;
                }
                else
                {
                    btPendientes.Enabled = false;
                }

                if (oVoucherDet.idCampana != Variables.Cero)
                {
                    txtIdCampana.Text = oVoucherDet.idCampana.ToString();
                    txtDesProyecto.Text = oVoucherDet.desCampana;
                }

                if (oVoucherDet.idConceptoGasto != Variables.Cero)
                {
                    txtIdConcepto.Text = oVoucherDet.idConceptoGasto.ToString();
                    txtDesGasto.Text = oVoucherDet.desConcepto;
                }

                indCtaGasto = oVoucherDet.PlanCuenta.indCuentaGastos;
                cboReparable.SelectedValue = oVoucherDet.indReparable.Substring(0, 1);
                cboReparable_SelectionChangeCommitted(new Object(), new EventArgs());
                cboConceptoReparable.SelectedValue = Convert.ToInt32(oVoucherDet.idConceptoRep);
                txtRefRepa.Text = oVoucherDet.desReferenciaRep;

                if (oVoucherDet.idComprobante == Variables.RegistroCompra)
                {
                    if (((DocumentosE)cboDocumento.SelectedItem).indDocNoDom)
                    {
                        if (!string.IsNullOrEmpty(oVoucherDet.idDocumentoRef))
                        {
                            cboDocumentosCredito.SelectedValue = oVoucherDet.idDocumentoRef;
                        }
                        else
                        {
                            cboDocumentosCredito.SelectedValue = "0";
                        }

                        cboDocumentosCredito_SelectionChangeCommitted(new object(), new EventArgs());

                        cboAduanas.SelectedValue = Convert.ToInt32(oVoucherDet.depAduanera);
                        txtNroDua.Text = oVoucherDet.nroDua;
                        txtAnioDua.Text = String.IsNullOrEmpty(oVoucherDet.AnioDua.Trim()) ? dtpFecDocumento.Value.Year.ToString() : oVoucherDet.AnioDua.Trim();
                    }

                    //if (oVoucherDet.depAduanera != Variables.Cero)
                    //{
                    //    cboAduanas.SelectedValue = Convert.ToInt32(oVoucherDet.depAduanera);
                    //}
                }

                //Habilita textbox de los montos
                BloquearCajas();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }
        }

        void DatosCabecera()
        {
            dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
            dtpFecDocumento.Value = oVoucherCab.fecDocumento.Value.Date;
            dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
            txtTica.Text = Convert.ToDecimal(oVoucherCab.tipCambio).ToString("N3");
            txtGlosa.Text = oVoucherCab.GlosaGeneral;
        }

        List<ParTabla> RecuperarDetalleCoVen(Int32 ColumnaCoven)
        {
            List<ParTabla> ListaTmp = AgenteGeneral.Proxy.ListarParTablaPorValorEntero(ColumnaCoven);
            return ListaTmp;
        }

        VoucherItemE DatosPorAceptar()
        {
            #region Variables
            
            DateTime? fecDocumento = (Nullable<DateTime>)null; //dtpFecDocumento.Checked ? dtpFecDocumento.Value.Date : (Nullable<DateTime>)null;
            DateTime? fecVencimiento = dtpFecVencimiento.Checked ? dtpFecVencimiento.Value.Date : (Nullable<DateTime>)null;
            DateTime? fecRecepcion = dtpFecRecepcion.Checked ? dtpFecRecepcion.Value.Date : (Nullable<DateTime>)null;
            DateTime? fecRef = dtpFecDocRefe.Checked ? dtpFecDocRefe.Value.Date : (Nullable<DateTime>)null;
            DateTime? fecDetraccion = dtpFecDetraccion.Checked ? dtpFecDetraccion.Value.Date : (Nullable<DateTime>)null;
            String idDocRef = String.Empty;
            String serRef = String.Empty;
            String numRef = String.Empty;
            String numDocuPresu = String.Empty;
            Int32 codColumnaCoven = Variables.Cero;
            String desColumnaCoVen = String.Empty;
            String Usuario = String.Empty;
            String Accion = String.Empty;
            Int32? idCtaCte = Variables.Cero;
            Int32? idCtaCteItem = Variables.Cero;
            Int32? idCampana = Variables.Cero;
            Int32? idConceptoGasto = Variables.Cero;
            String indCtaCte_ = String.Empty;
            Int32 depAduanera = Variables.Cero;
            String Dua = String.Empty;

            #region Reparable

            String indReparable_ = String.Empty;
            Int32? idConceptoRep_ = Variables.Cero;
            String desReferenciaRep_ = String.Empty;

            #endregion

            #endregion

            #region Documentos

            if (oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI)
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    numDocuPresu += txtSerie.Text + "-";
                }

                if (!String.IsNullOrEmpty(txtNumDoc.Text.Trim()))
                {
                    numDocuPresu += txtNumDoc.Text;
                }

                dtpFecDocumento.Checked = true;
                fecDocumento = dtpFecDocumento.Value.Date;
            }

            if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
            {
                idDocRef = cboReferencia.SelectedValue.ToString();
                serRef = txtSerieRef.Text.Trim();
                numRef = txtNumDocRef.Text.Trim();
            }

            if (((DocumentosE)cboDocumento.SelectedItem).indDocNoDom && oVoucherCab.idComprobante == Variables.RegistroCompra)
            {
                idDocRef = cboDocumentosCredito.SelectedValue.ToString();
                depAduanera = cboAduanas.SelectedValue != null ? Convert.ToInt32(cboAduanas.SelectedValue) : Variables.Cero;
                Dua = txtNroDua.Text.Trim();
            }

            #endregion Documentos

            if (oVoucherCab.idComprobante == Variables.RegistroCompra || oVoucherCab.idComprobante == Variables.RegistroVenta)
            {
                #region Para la columna Compra / Venta

                if (pnlColumnaCoVen.Enabled)
                {
                    codColumnaCoven = Convert.ToInt32(cboCoVen.SelectedValue);

                    if (cboCoVen.SelectedItem != null)
                    {
                        desColumnaCoVen = ((ParTabla)cboCoVen.SelectedItem).Nombre;
                    }
                    else
                    {
                        desColumnaCoVen = cboCoVen.Text;
                    }
                }
                else
                {
                    codColumnaCoven = Variables.Cero;
                    desColumnaCoVen = String.Empty;
                }

                #endregion Para la columna Compra / Venta

                #region Para la CtaCte

                if (oVoucherDet.PlanCuenta.indCtaCte == Variables.SI)
                {
                    Accion = EnumAccionCtaCte.A.ToString();
                    indCtaCte_ = Variables.SI;
                }
                else
                {
                    Accion = EnumAccionCtaCte.Z.ToString();
                    indCtaCte_ = Variables.NO;
                }

                if (oVoucherDet.idCtaCte != Variables.Cero && oVoucherDet.idCtaCte != null)
                {
                    idCtaCte = Convert.ToInt32(oVoucherDet.idCtaCte);
                    oVoucherDet.desConcepto = Variables.SI;
                }
                else
                {
                    idCtaCte = (Nullable<Int32>)null;
                }

                if (oVoucherDet.idCtaCteItem != Variables.Cero && oVoucherDet.idCtaCteItem != null)
                {
                    idCtaCteItem = Convert.ToInt32(oVoucherDet.idCtaCteItem);
                }
                else
                {
                    idCtaCteItem = (Nullable<Int32>)null;
                }

                #endregion Para la CtaCte
            }
            else if (Convert.ToInt32(oVoucherCab.idComprobante) == (Int32)enumLibro.CajaIngreso || Convert.ToInt32(oVoucherCab.idComprobante) == (Int32)enumLibro.CajaEgreso)
            {
                #region Para la CtaCte

                if (oVoucherDet.PlanCuenta.indCtaCte == Variables.SI)
                {
                    Accion = EnumAccionCtaCte.M.ToString();

                    if (indMovimientoCtaCte && idCtaCteTmp != Variables.Cero)
                    {
                        idCtaCte = idCtaCteTmp;
                    }
                    else
                    {
                        if (oVoucherDet.idCtaCte != Variables.Cero && oVoucherDet.idCtaCte != null)
                        {
                            idCtaCte = Convert.ToInt32(oVoucherDet.idCtaCte);
                        }
                        else
                        {
                            idCtaCte = (Nullable<Int32>)null;
                        }
                    }
                    
                    if (oVoucherDet.idCtaCteItem != Variables.Cero && oVoucherDet.idCtaCteItem != null)
                    {
                        idCtaCteItem = Convert.ToInt32(oVoucherDet.idCtaCteItem);
                    }
                    else
                    {
                        idCtaCteItem = (Nullable<Int32>)null;
                    }

                    indCtaCte_ = Variables.SI;
                }
                else
                {
                    Accion = EnumAccionCtaCte.Z.ToString();
                    idCtaCte = (Nullable<Int32>)null;
                    idCtaCteItem = (Nullable<Int32>)null;
                    indCtaCte_ = Variables.NO;
                }
    
                #endregion
            }
            else
            {
                codColumnaCoven = Variables.Cero;
                desColumnaCoVen = String.Empty;
                Accion = EnumAccionCtaCte.Z.ToString();
                idCtaCte = (Nullable<Int32>)null;
                idCtaCteItem = (Nullable<Int32>)null;
                indCtaCte_ = Variables.NO;
            }

            if (!String.IsNullOrEmpty(txtIdCampana.Text) && txtIdCampana.Text != "0")
            {
                idCampana = Convert.ToInt32(txtIdCampana.Text);
            }
            else
            {
                idCampana = (Nullable<Int32>)null;
            }

            if (!String.IsNullOrEmpty(txtIdConcepto.Text) && txtIdConcepto.Text != "0")
            {
                idConceptoGasto = Convert.ToInt32(txtIdConcepto.Text);
            }
            else
            {
                idConceptoGasto = (Nullable<Int32>)null;
            }

            #region Reparable

            if (cboReparable.SelectedValue.ToString() == EnumReparable.R.ToString())
            {
                indReparable_ = cboReparable.SelectedValue.ToString();
                idConceptoRep_ = Convert.ToInt32(cboConceptoReparable.SelectedValue);
                desReferenciaRep_ = txtRefRepa.Text;
            }
            else
            {
                indReparable_ = cboReparable.SelectedValue.ToString();
                idConceptoRep_ = (Nullable<Int32>)null;
                desReferenciaRep_ = String.Empty;
            }

            #endregion Reparable

            Decimal MontoSoles = Variables.Cero;
            Decimal MontoDolares = Variables.Cero;
            Decimal TipoCambio = Variables.Cero;
            Decimal.TryParse(txtSoles.Text, out MontoSoles);
            Decimal.TryParse(txtDolares.Text, out MontoDolares);
            Decimal.TryParse(txtTica.Text, out TipoCambio);

            VoucherItemE item = new VoucherItemE
            {
                idComprobante = oVoucherCab.idComprobante,
                numFile = oVoucherCab.numFile,
                idPersona = oVoucherDet.PlanCuenta.indSolicitaAnexo == Variables.SI ? idPersona : (Nullable<Int32>)null,
                idPersonaCad = oVoucherDet.PlanCuenta.indSolicitaAnexo == Variables.SI ? idPersona.ToString() : String.Empty,
                RazonSocial = oVoucherDet.PlanCuenta.indSolicitaAnexo == Variables.SI ? txtRazonSocial.Text.Trim() : String.Empty,
                idMoneda = cboMonedaCuenta.SelectedValue.ToString(),
                tipCambio = TipoCambio,
                indCambio = chkTicaAuto.Checked ? Variables.SI : Variables.NO,
                idCCostos = oVoucherDet.PlanCuenta.indSolicitaCentroCosto == Variables.SI ? txtCCostos.Text.Trim() : String.Empty,
                numVerPlanCuentas = oVoucherDet.PlanCuenta.numVerPlanCuentas,
                codCuenta = txtCuenta.Text,
                desCuenta = txtDesCuenta.Text,
                desGlosa = txtGlosa.Text,
                fecDocumento = oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI ? fecDocumento : (Nullable<DateTime>)null,
                fecVencimiento = oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI ? fecVencimiento : (Nullable<DateTime>)null,
                fecRecepcion = oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI ? fecRecepcion : (Nullable<DateTime>)null,
                idDocumento = oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI ? cboDocumento.SelectedValue.ToString() : String.Empty,
                serDocumento = oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI ? txtSerie.Text.Trim() : String.Empty,
                numDocumento = oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI ? txtNumDoc.Text.Trim() : String.Empty,
                fecDocumentoRef = fecRef,
                idDocumentoRef = idDocRef,
                serDocumentoRef = serRef,
                numDocumentoRef = numRef,
                indDebeHaber = cboDebeHaber.SelectedValue.ToString(),
                impSoles = MontoSoles,
                impDolares = MontoDolares,
                indAutomatica = Variables.NO,
                CorrelativoAjuste = String.Empty,
                codFteFin = String.Empty,
                codProgramaCred = String.Empty,
                indMovimientoAnterior = String.Empty,
                tipPartidaPresu = TipoPartida,
                codPartidaPresu = txtPartida.Text.Trim(),
                numDocumentoPresu = numDocuPresu,
                codColumnaCoven = codColumnaCoven,
                NombreColumna = desColumnaCoVen,
                depAduanera = depAduanera,
                nroDua = Dua,
                AnioDua = txtAnioDua.Text.Trim(),
                flagDetraccion = chkDetraccion.Checked ? Variables.SI : Variables.NO,
                numDetraccion = chkDetraccion.Checked ? txtNumDetra.Text.Trim() : String.Empty,
                fecDetraccion = chkDetraccion.Checked ? dtpFecDetraccion.Value.Date : (Nullable<DateTime>)null,
                tipDetraccion = chkDetraccion.Checked ? cboTipoDetraccion.SelectedValue.ToString() : String.Empty,
                TasaDetraccion = chkDetraccion.Checked ? Convert.ToDecimal(txtTasaDetra.Text): Variables.ValorCeroDecimal,
                MontoDetraccion = chkDetraccion.Checked ? Convert.ToDecimal(txtMontoDetraccion.Text) : Variables.ValorCeroDecimal,
                MontoDetraEntero = chkDetraccion.Checked ? Convert.ToDecimal(txtRedondeo.Text) : Variables.ValorCeroDecimal,
                indPagoDetra = chkIndPagoDetra.Checked,
                indReparable = indReparable_,
                idConceptoRep = idConceptoRep_,
                desReferenciaRep = desReferenciaRep_,
                idAlmacen = String.Empty,
                tipMovimientoAlmacen = String.Empty,
                numDocumentoAlmacen = String.Empty,
                numItemAlmacen = String.Empty,
                CajaSucursal = String.Empty,
                indCompra = String.Empty,
                indConciliado = "N",
                codMedioPago = Convert.ToInt32(cboMedioPago.SelectedValue),
                idCampana = idCampana,
                idConceptoGasto = idConceptoGasto,
                idAccion = Accion,
                idCtaCte = idCtaCte,
                idCtaCteItem = idCtaCteItem,
                indCtaCte = indCtaCte_,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                FechaRegistro = VariablesLocales.FechaHoy,
                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                FechaModificacion = VariablesLocales.FechaHoy,
                Opcion = Opcion,

                indCuentaGastos = oVoucherDet.PlanCuenta.indCuentaGastos,
                codCuentaDestino = oVoucherDet.PlanCuenta.codCuentaDestino,
                codCuentaTransferencia = oVoucherDet.PlanCuenta.codCuentaTransferencia,
                Ruc = txtRuc.Text
            };

            return item;
        }

        void PresentarCuenta()
        {
            txtCuenta.Text = oVoucherDet.PlanCuenta.codCuenta;
            txtDesCuenta.Text = oVoucherDet.PlanCuenta.Descripcion;
            indCtaGasto = oVoucherDet.PlanCuenta.indCuentaGastos;

            HabilitaTextBoxMovimientos();
            cboDocumento_Leave(new Object(), new EventArgs());
            cboDebeHaber.SelectedValue = oVoucherDet.PlanCuenta.indNaturalezaCta;

            if (!String.IsNullOrEmpty(oVoucherDet.PlanCuenta.tipPartidaPresu))
            {
                TipoPartida = oVoucherDet.PlanCuenta.tipPartidaPresu;
                txtPartida.Text = oVoucherDet.PlanCuenta.codPartidaPresu;
                txtDesPartida.Text = oVoucherDet.PlanCuenta.desPartidaPresu;
            }
            else
            {
                TipoPartida = String.Empty;
                oVoucherDet.tipPartidaPresu = String.Empty;
                oVoucherDet.codPartidaPresu = String.Empty;
            }

            if (oVoucherDet.PlanCuenta.idMoneda == Variables.Cero.ToString())
            {
                cboMonedaCuenta.SelectedValue = oVoucherCab.idMoneda;
            }
            else
            {
                cboMonedaCuenta.SelectedValue = oVoucherDet.PlanCuenta.idMoneda;
            }

            if (oVoucherCab.idComprobante == Variables.RegistroVenta || oVoucherCab.idComprobante == Variables.RegistroCompra)
            {
                if (Convert.ToInt32(oVoucherDet.PlanCuenta.codColumnaCoven) > Variables.Cero)
                {
                    pnlColumnaCoVen.Enabled = true;
                    ComboHelper.LlenarCombos<ParTabla>(cboCoVen, RecuperarDetalleCoVen(Convert.ToInt32(oVoucherDet.PlanCuenta.codColumnaCoven)), "idPartabla", "Descripcion");
                }
            }
            else
            {
                if (oVoucherDet.PlanCuenta.indCtaCte == Variables.SI)
                {
                    btPendientes.Enabled = true;
                }
                else
                {
                    btPendientes.Enabled = false;
                }
            }

            //Habilita textbox de los montos
            BloquearCajas();

            if (txtRuc.Enabled)
            {
                txtRuc.Focus();
            }
        }

        void HabilitaTextBoxMovimientos()
        {
            if (oVoucherDet.PlanCuenta != null)
            {
                #region Si solicita Auxiliar

                if (oVoucherDet.PlanCuenta.indSolicitaAnexo == Variables.SI)
                {
                    Extensores.CambiaColorFondo(txtRuc, EnumTipoEdicionCuadros.Desbloquear);
                    Extensores.CambiaColorFondo(txtRazonSocial, EnumTipoEdicionCuadros.Desbloquear);
                    btRuc.Enabled = true;
                    txtRuc.Focus();

                    if (idPersona != Variables.Cero && !String.IsNullOrEmpty(RazonSocial))
                    {
                        txtRuc.Text = Ruc;
                        txtRazonSocial.Text = RazonSocial;
                    }
                }
                else
                {
                    Extensores.CambiaColorFondo(txtRuc, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    Extensores.CambiaColorFondo(txtRazonSocial, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    btRuc.Enabled = false;
                    cboDocumento.Focus();
                }

                #endregion

                #region Si solicita Documentos

                if (oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI)
                {
                    pnlDocumentos.Enabled = Bloqueo == Variables.NO ? true : false;

                    Extensores.CambiaColorFondo(cboDocumento, EnumTipoEdicionCuadros.Desbloquear);
                    Extensores.CambiaColorFondo(txtSerie, EnumTipoEdicionCuadros.Desbloquear);
                    Extensores.CambiaColorFondo(txtNumDoc, EnumTipoEdicionCuadros.Desbloquear);
                    Extensores.CambiaColorFondo(dtpFecDocumento, EnumTipoEdicionCuadros.Desbloquear);
                }
                else
                {
                    pnlDocumentos.Enabled = false;

                    Extensores.CambiaColorFondo(cboDocumento, EnumTipoEdicionCuadros.Bloquear);
                    Extensores.CambiaColorFondo(txtSerie, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    Extensores.CambiaColorFondo(txtNumDoc, EnumTipoEdicionCuadros.Bloquear, Variables.SI);

                    cboDocumento.SelectedValue = Variables.Cero.ToString();
                    dtpFecDocumento.Checked = false;
                    dtpFecVencimiento.Checked = false;
                    dtpFecRecepcion.Checked = false;
                    txtCCostos.Focus();
                }

                #endregion

                #region Si solicita Centro de Costo

                if (oVoucherDet.PlanCuenta.indSolicitaCentroCosto == Variables.SI)
                {
                    Extensores.CambiaColorFondo(txtCCostos, EnumTipoEdicionCuadros.Desbloquear);
                    btCentroC.Enabled = true;
                }
                else
                {
                    Extensores.CambiaColorFondo(txtCCostos, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    btCentroC.Enabled = false;
                }

                #endregion 
            }
            else
            {
                Extensores.CambiaColorFondo(txtRuc, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                Extensores.CambiaColorFondo(txtRazonSocial, EnumTipoEdicionCuadros.Bloquear, Variables.SI);

                btRuc.Enabled = false;
                pnlDocumentos.Enabled = false;

                Extensores.CambiaColorFondo(cboDocumento, EnumTipoEdicionCuadros.Bloquear);
                Extensores.CambiaColorFondo(txtSerie, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                Extensores.CambiaColorFondo(txtNumDoc, EnumTipoEdicionCuadros.Bloquear, Variables.SI);

                cboDocumento.SelectedValue = Variables.Cero.ToString();
                dtpFecDocumento.Checked = false;
                dtpFecVencimiento.Checked = false;
                dtpFecRecepcion.Checked = false;

                Extensores.CambiaColorFondo(txtCCostos, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                btCentroC.Enabled = false;
            }
        }

        void BloquearCajas()
        {
            if (chkTicaAuto.Checked)
            {
                if (cboMonedaCuenta.SelectedValue.ToString() == Variables.Soles)
                {
                    txtSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                }
                else
                {
                    txtSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
            }
            else
            {
                txtSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override Boolean ValidarGrabacion()
        {
            PlanCuentasE oPc = oVoucherDet.PlanCuenta;

            if (oPc != null)
            {

                #region Si solicita Razon Social

                if (oPc.indSolicitaAnexo == Variables.SI)
                {
                    if (String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && idPersona == Variables.Cero)
                    {
                        Global.MensajeComunicacion("La cuenta " + oPc.codCuenta + " necesita Auxiliar.");
                        btRuc.Focus();
                        return false;
                    }
                }

                #endregion

                #region Si solicita Centro de Costos

                if (oPc.indSolicitaCentroCosto == Variables.SI)
                {
                    if (String.IsNullOrEmpty(txtDesCCostos.Text.Trim()))
                    {
                        Global.MensajeComunicacion("La cuenta " + oPc.codCuenta + " necesita un Centro de Costo.");
                        btCentroC.Focus();
                        return false;
                    }
                }

                #endregion

                #region Si solicita Documento

                if (oPc.indSolicitaDcto == Variables.SI)
                {
                    if (cboDocumento.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        Global.MensajeComunicacion("La cuenta " + oPc.codCuenta + " necesita un tipo de documento.");
                        cboDocumento.Focus();
                        return false;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(txtSerie.Text.Trim()) && String.IsNullOrEmpty(txtNumDoc.Text.Trim()))
                        {
                            Global.MensajeComunicacion("La cuenta " + oPc.codCuenta + " necesita número de documento.");
                            txtSerie.Focus();
                            return false;
                        }
                        else
                        {
                            if (Convert.ToInt32(oVoucherCab.idComprobante) == (Int32)enumLibro.RegistroCompras || Convert.ToInt32(oVoucherCab.idComprobante) == (Int32)enumLibro.RegistroVentas)
                            {
                                if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
                                {
                                    if (cboReferencia.SelectedValue.ToString() == Variables.Cero.ToString())
                                    {
                                        Global.MensajeComunicacion("La NC / ND necesita un documento de referencia.\n\rTrate de colocar los datos del documento de ref. completos.");
                                        cboReferencia.Focus();
                                        return false;
                                    }
                                    else
                                    {
                                        if (String.IsNullOrEmpty(txtSerieRef.Text.Trim()) && String.IsNullOrEmpty(txtNumDocRef.Text.Trim()))
                                        {
                                            Global.MensajeComunicacion("La NC / ND necesita número de referencia del documento.");
                                            txtSerieRef.Focus();
                                            return false;
                                        }
                                    }

                                    if (!dtpFecDocRefe.Checked)
                                    {
                                        Global.MensajeComunicacion("La NC / ND necesita fecha de referencia del documento.");
                                        dtpFecDocRefe.Focus();
                                        return false;
                                    }
                                }
                            }
                        }
                    }

                    if (!dtpFecDocumento.Checked)
                    {
                        Global.MensajeComunicacion("Debe Indicar Fecha de Documento..");
                        dtpFecDocumento.Focus();
                        return false;
                    }
                }

                #endregion

            }

            #region Detraccion

            if (chkDetraccion.Checked)
            {
                if (String.IsNullOrEmpty(txtNumDetra.Text.Trim()))
                {
                    Global.MensajeComunicacion("La detracción necesita un Número.");
                    txtNumDetra.Focus();
                    return false;
                }

                if (!dtpFecDetraccion.Checked)
                {
                    Global.MensajeComunicacion("La detracción necesita una Fecha.");
                    dtpFecDetraccion.Focus();
                    return false;
                }

                if (cboTipoDetraccion.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    Global.MensajeComunicacion("Debe escoger la Tasa de Detracción.");
                    cboTipoDetraccion.Focus();
                    return false;
                }
            }

            #endregion

            #region Solo para el Libro de Ingresos y Egresos

            if (Convert.ToInt32(oVoucherCab.idComprobante) == (Int32)enumLibro.CajaIngreso || Convert.ToInt32(oVoucherCab.idComprobante) == (Int32)enumLibro.CajaEgreso)
            {
                if (oVoucherDet.PlanCuenta.codCuenta.Substring(0, 2) == "10")
                {
                    if (cboMedioPago.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        Global.MensajeFault("Para el Libro de Ingresos o Egresos es obligatorio escoger un medio de pago...");
                        pnlOtros.Focus();
                        cboMedioPago.Focus();
                        return false;
                    } 
                }
            } 

            #endregion

            if (((DocumentosE)cboDocumento.SelectedItem).indFecVencimiento)
            {
                if (!dtpFecVencimiento.Checked)
                {
                    Global.MensajeFault(String.Format("Para el documento elegido {0} es necesario la fecha de vencimiento", ((DocumentosE)cboDocumento.SelectedItem).desDocumento));
                    dtpFecVencimiento.Focus();
                    return false;
                }
            }

            if (txtCuenta.Text.Trim().Length != VariablesLocales.VersionPlanCuentasActual.Longitud)
            {
                Global.MensajeFault(String.Format("El total de dígitos de la Cta {0}, no coincide con el total de digitos de la estructura del Plan Contable.\n\r *****************************   {1}  DIGITOS   *****************************", txtCuenta.Text.Trim(), VariablesLocales.VersionPlanCuentasActual.Longitud));
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    if (!String.IsNullOrEmpty(txtDesCuenta.Text))
                    {
                        if (indMovimientoCtaCte)
                        {
                            if (oListaVouchers.Count == Variables.ValorUno)
                            {
                                oVoucherDet = DatosPorAceptar();
                            }
                            else
                            {
                                oVoucherDet = null;
                            }

                            base.Aceptar();
                        }

                        if (indDistribucion)
	                    {
		                    if (oListaVouchers.Count == Variables.ValorUno)
                            {
                                oVoucherDet = DatosPorAceptar();
                            }
                            else
                            {
                                oVoucherDet = null;
                            }

                            base.Aceptar();
	                    }

                        if (!indMovimientoCtaCte && !indDistribucion)
                        {
                            oVoucherDet = DatosPorAceptar();
                            base.Aceptar();
                        }
                    }
                    else
                    {
                        Global.MensajeFault("No hay datos. Presione Cancelar por favor");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmDetalleVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                Global.CrearToolTip(btCuenta, "Buscar el código de cuenta.");
                Global.CrearToolTip(btCentroC, "Buscar centro de costos.");
                Global.CrearToolTip(btRuc, "Buscar auxiliar.");
                Global.CrearToolTip(btBuscarProyecto, "Proyectos");
                Global.CrearToolTip(btBuscarGasto, "Centros de Gasto");

                Registro();

                // Datos de la Cuenta del File
                if (fileLlevaCuenta)
                {
                    conCuenta = fileLlevaCuenta;
                    txtCuenta.Text = fileCuenta;
                    CuentaTemporal = fileCuenta;
                    oVoucherDet.PlanCuenta = VariablesLocales.ObtenerPlanCuenta(txtCuenta.Text);
                    PresentarCuenta();

                    if (oVoucherCab.idComprobante == "04") // Ingresos
                    {
                        cboDebeHaber.SelectedValue = "D";
                    }

                    if (oVoucherCab.idComprobante == "05") // Egresos
                    {
                        cboDebeHaber.SelectedValue = "H";
                    }
                }

                txtCuenta.MaxLength = (Int32)VariablesLocales.VersionPlanCuentasActual.Longitud;

                if (txtRuc.Enabled == true)
                {
                    txtRuc.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                pnDetraccion.Enabled = true;
                txtNumDetra.Text = String.Empty;
                dtpFecDetraccion.Checked = false;
                txtNumDetra.Focus();
                cboTipoDetraccion.SelectedValue = Variables.Cero.ToString();
                txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                txtMontoDetraccion.Text = Variables.ValorCeroDecimal.ToString("N2");
                chkIndPagoDetra.Enabled = true;
                chkIndPagoDetra.Checked = true;
            }
            else
            {
                pnDetraccion.Enabled = false;
                txtNumDetra.Text = String.Empty;
                dtpFecDetraccion.Checked = false;
                cboTipoDetraccion.SelectedValue = Variables.Cero.ToString();
                txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                txtMontoDetraccion.Text = Variables.ValorCeroDecimal.ToString("N2");
                chkIndPagoDetra.Enabled = false;
                chkIndPagoDetra.Checked = true;
            }
        }

        private void btBuscarProyecto_Click(object sender, EventArgs e)
        {
            if (indCtaGasto == Variables.SI)
            {
                frmBuscarCampanas oFrm = new frmBuscarCampanas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCampana != null)
                {
                    txtIdCampana.Text = oFrm.oCampana.idCampana.ToString();
                    txtDesProyecto.Text = oFrm.oCampana.Nombre;
                }
            }
            else
            {
                Global.MensajeComunicacion("Tiene que ingresar una cuenta de gasto!!!");
            }
        }

        private void cboReparable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboReparable.SelectedValue.ToString() == EnumReparable.R.ToString())
            {
                cboConceptoReparable.Enabled = true;
                txtRefRepa.Enabled = true;
                txtRefRepa.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                cboConceptoReparable.SelectedValue = Variables.Cero;
                cboConceptoReparable.Enabled = false;
                txtRefRepa.Enabled = false;
                txtRefRepa.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
            }
        }

        private void btCentroC_Click(object sender, EventArgs e)
        {
            Int32 Nivel = 1;

            if (VariablesLocales.oConParametros != null)
            {
                if (VariablesLocales.oConParametros.numNivelCCosto > 0)
                {
                    Nivel = Convert.ToInt32(VariablesLocales.oConParametros.numNivelCCosto);
                }
            }

            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(Nivel);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtCCostos.Text = oVoucherDet.idCCostos = oFrm.CentroCosto.idCCostos;
                txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oVoucherDet.PlanCuenta = VariablesLocales.ObtenerPlanCuenta(oFrm.Cuentas.codCuenta);
                    txtCuenta.Text = oVoucherDet.PlanCuenta.codCuenta;
                    txtDesCuenta.Text = oVoucherDet.PlanCuenta.Descripcion;
                    indCtaGasto = oVoucherDet.PlanCuenta.indCuentaGastos;

                    HabilitaTextBoxMovimientos();
                    cboDocumento_Leave(new Object(), new EventArgs());

                    cboDebeHaber.SelectedValue = oVoucherDet.PlanCuenta.indNaturalezaCta;

                    if (!String.IsNullOrEmpty(oVoucherDet.PlanCuenta.tipPartidaPresu))
                    {
                        TipoPartida = oVoucherDet.PlanCuenta.tipPartidaPresu;
                        txtPartida.Text = oVoucherDet.PlanCuenta.codPartidaPresu;
                        txtDesPartida.Text = oVoucherDet.PlanCuenta.desPartidaPresu;
                    }
                    else
                    {
                        TipoPartida = String.Empty;
                        oVoucherDet.tipPartidaPresu = String.Empty;
                        oVoucherDet.codPartidaPresu = String.Empty;
                    }

                    if (oVoucherDet.PlanCuenta.idMoneda == Variables.Cero.ToString())
                    {
                        cboMonedaCuenta.SelectedValue = oVoucherCab.idMoneda;
                    }
                    else
                    {
                        cboMonedaCuenta.SelectedValue = oVoucherDet.PlanCuenta.idMoneda;
                    }

                    if (oVoucherCab.idComprobante == Variables.RegistroVenta || oVoucherCab.idComprobante == Variables.RegistroCompra)
                    {
                        if (Convert.ToInt32(oVoucherDet.PlanCuenta.codColumnaCoven) > Variables.Cero)
                        {
                            pnlColumnaCoVen.Enabled = true;
                            ComboHelper.LlenarCombos<ParTabla>(cboCoVen, RecuperarDetalleCoVen(Convert.ToInt32(oVoucherDet.PlanCuenta.codColumnaCoven)), "idPartabla", "Descripcion"); 
                        }
                    }
                    else
                    {
                        if (oVoucherDet.PlanCuenta.indCtaCte == Variables.SI)
                        {
                            btPendientes.Enabled = true;
                        }
                        else
                        {
                            btPendientes.Enabled = false;
                        }
                    }

                    //Habilita textbox de los montos
                    BloquearCajas();

                    if (oVoucherDet.PlanCuenta.indSolicitaDcto == Variables.SI)
                    {
                        dtpFecDocumento.Value = Convert.ToDateTime(oVoucherCab.fecDocumento);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btRuc_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                idPersona = oFrm.oPersona.IdPersona;
                txtRuc.Text = oFrm.oPersona.RUC;
                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                if (txtCCostos.Enabled)
                {
                    txtCCostos.Focus();
                }
                else
                {
                    if (pnlDocumentos.Enabled)
                    {
                        cboDocumento.Focus();
                    }
                }

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                if (oVoucherCab.idComprobante != Variables.RegistroCompra && oVoucherCab.idComprobante != Variables.RegistroVenta)
                {
                    if (btPendientes.Enabled)
                    {
                        btPendientes.PerformClick();
                    } 
                }
            }
        }

        private void btBuscaPartida_Click(object sender, EventArgs e)
        {
            frmBuscarPartida oFrm = new frmBuscarPartida();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
            {
                TipoPartida = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                txtPartida.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                txtDesPartida.Text = oFrm.oPartidaPresupuestal.desPartidaPresu;
            }
        }

        private void cboDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
                {
                    pnlDocumentoRefe.Enabled = true;

                    if (!String.IsNullOrEmpty(oVoucherDet.idDocumentoRef))
                    {
                        cboReferencia.SelectedValue = oVoucherDet.idDocumentoRef;
                        txtSerieRef.Text = oVoucherDet.serDocumentoRef;
                        txtNumDocRef.Text = oVoucherDet.numDocumentoRef;

                        if (oVoucherDet.fecDocumentoRef != null)
                        {
                            dtpFecDocRefe.Value = Convert.ToDateTime(oVoucherDet.fecDocumentoRef);
                        }
                        else
                        {
                            dtpFecDocRefe.Checked = false;
                        }
                    }
                    else
                    {
                        cboReferencia.SelectedValue = Variables.Cero.ToString();
                        txtSerieRef.Text = String.Empty;
                        txtNumDocRef.Text = String.Empty;
                        dtpFecDocRefe.Checked = false;
                    }
                }
                else
                {
                    pnlDocumentoRefe.Enabled = false;
                    cboReferencia.SelectedValue = Variables.Cero.ToString();
                    txtSerieRef.Text = String.Empty;
                    txtNumDocRef.Text = String.Empty;
                    dtpFecDocRefe.Checked = false;
                }

                if (((DocumentosE)cboDocumento.SelectedItem).codMedioPago != null)
                {
                    cboMedioPago.SelectedValue = ((DocumentosE)cboDocumento.SelectedItem).codMedioPago;
                }

                if (oVoucherCab.idComprobante == Variables.RegistroCompra)
                {
                    //if (((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "50" || ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "51" ||
                    //    ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "52" || ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "53" ||
                    //    ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "54")
                    if (((DocumentosE)cboDocumento.SelectedItem).indDocNoDom)
                    {
                        cboDocumentosCredito.Enabled = true;

                        // Documentos con derecho a crédito fiscal
                        List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                                  where x.indCreditoFiscal
                                                                                  select x).ToList();

                        DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = " " + Variables.Seleccione };
                        ListaDocumentos.Add(Fila);
                        ComboHelper.RellenarCombos<DocumentosE>(cboDocumentosCredito, (from x in ListaDocumentos
                                                                                       orderby x.desDocumento
                                                                                       select x).ToList(), "idDocumento", "desDocumento", false);
                        txtNroDua.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtAnioDua.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                        txtAnioDua.Text = dtpFecDocumento.Value.Year.ToString();
                    }
                    else
                    {
                        txtNroDua.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                        txtAnioDua.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                        cboDocumentosCredito.DataSource = null;
                        cboDocumentosCredito.Enabled = false;
                        cboAduanas.DataSource = null;
                        cboAduanas.Enabled = false;
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtSoles_Enter(object sender, EventArgs e)
        {
            txtSoles.SeleccinarTodo();
        }

        private void txtSoles_MouseClick(object sender, MouseEventArgs e)
        {
            txtSoles.SeleccinarTodo();
        }

        private void txtDolares_Enter(object sender, EventArgs e)
        {
            txtDolares.SeleccinarTodo();
        }

        private void txtDolares_MouseClick(object sender, MouseEventArgs e)
        {
            txtDolares.SeleccinarTodo();
        }

        private void txtTica_Enter(object sender, EventArgs e)
        {
            txtTica.SeleccinarTodo();
        }

        private void txtTica_MouseClick(object sender, MouseEventArgs e)
        {
            txtTica.SeleccinarTodo();
        }

        private void txtPartida_TextChanged(object sender, EventArgs e)
        {
            if (txtPartida.TextLength == Variables.Cero)
            {
                txtDesPartida.Text = String.Empty;
                TipoPartida = String.Empty;
            }
        }

        private void cboTipoDetraccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TasasDetraccionesDetalleE oDetraccion = ((TasasDetraccionesDetalleE)cboTipoDetraccion.SelectedItem);

            if (oDetraccion != null)
            {
                txtTasaDetra.Text = oDetraccion.Porcentaje.ToString("N2");
                Decimal Importe = Variables.ValorCeroDecimal;

                if (oVoucherCab.idMoneda == Variables.Soles)
                {
                    Decimal.TryParse(txtSoles.Text, out Importe);
                    txtMontoDetraccion.Text = ((oDetraccion.Porcentaje / 100) * Importe).ToString("N2");

                    txtRedondeo.Text = Math.Round(Convert.ToDecimal(txtMontoDetraccion.Text), MidpointRounding.AwayFromZero).ToString("N2");
                }
                else
                {
                    Decimal.TryParse(txtDolares.Text, out Importe);
                    txtMontoDetraccion.Text = ((oDetraccion.Porcentaje / 100) * Importe).ToString("N2");

                    txtRedondeo.Text = Math.Round(Convert.ToDecimal(txtMontoDetraccion.Text) * Convert.ToDecimal(txtTica.Text), MidpointRounding.AwayFromZero).ToString("N2");
                }
            }
            else
            {
                txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                txtMontoDetraccion.Text = Variables.ValorCeroDecimal.ToString("N2");
            }
        }

        private void dtpFecDocumento_ValueChanged(object sender, EventArgs e)
        {
            Cambio = true;
            LlenarComboDetraccion(dtpFecDocumento.Value.Date);
        }

        private void txtSoles_Leave(object sender, EventArgs e)
        {            
            if (Cambio)
            {
                if (chkTicaAuto.Checked && oVoucherCab.tipCambio != Variables.ValorCeroDecimal)
                {
                    Decimal Soles = Variables.ValorCeroDecimal;
                    Decimal.TryParse(txtSoles.Text, out Soles);
                    Decimal Tica = Variables.ValorCeroDecimal;
                    Decimal.TryParse(txtTica.Text, out Tica);

                    txtDolares.Text = Decimal.Round((Soles / Tica), 2).ToString("N2");
                    txtSoles.Text = Soles.ToString("N2");

                    if (chkDetraccion.Checked)
                    {
                        cboTipoDetraccion_SelectionChangeCommitted(new Object(), new EventArgs());
                    }
                }

                Cambio = false;
            }
        }

        private void txtDolares_Leave(object sender, EventArgs e)
        {
            if (Cambio)
            {
                if (chkTicaAuto.Checked && oVoucherCab.tipCambio != Variables.ValorCeroDecimal)
                {
                    Decimal Dolares = Variables.ValorCeroDecimal;
                    Decimal.TryParse(txtDolares.Text, out Dolares);
                    Decimal Tica = Variables.ValorCeroDecimal;
                    Decimal.TryParse(txtTica.Text, out Tica);

                    txtSoles.Text = Decimal.Round((Dolares * Tica), 2).ToString("N2");
                    txtDolares.Text = Dolares.ToString("N2");

                    if (chkDetraccion.Checked)
                    {
                        cboTipoDetraccion_SelectionChangeCommitted(new Object(), new EventArgs());
                    }
                }

                Cambio = false;
            }
        }

        private void txtTica_Leave(object sender, EventArgs e)
        {
            if (Cambio)
            {
                if (chkTicaAuto.Checked && oVoucherCab.tipCambio != Variables.ValorCeroDecimal)
                {
                    Decimal Soles = Variables.ValorCeroDecimal;
                    Decimal Dolares = Variables.ValorCeroDecimal;
                    Decimal Tica = Variables.ValorCeroDecimal;

                    Decimal.TryParse(txtTica.Text, out Tica);
                    
                    //Se cambio oVoucherDet.idMoneda
                    if (cboMonedaCuenta.SelectedValue.ToString() == Variables.Soles)
                    {
                        Decimal.TryParse(txtSoles.Text, out Soles);
                        txtDolares.Text = Decimal.Round((Soles / Tica), 2).ToString("N2");
                        txtSoles.Text = Soles.ToString("N2");
                    }
                    else
                    {
                        Decimal.TryParse(txtDolares.Text, out Dolares);
                        txtSoles.Text = Decimal.Round((Dolares * Tica), 2).ToString("N2");
                        txtDolares.Text = Dolares.ToString("N2");
                    }
                }

                Cambio = false; 
            }
        } 

        private void chkTicaAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSoles.Text.Trim().ToString() != "0.00" && txtDolares.Text.Trim().ToString() != "0.00")
            {
                if (chkTicaAuto.Checked && oVoucherCab.tipCambio != Variables.ValorCeroDecimal)
                {
                    Decimal Soles = Variables.ValorCeroDecimal;
                    Decimal Dolares = Variables.ValorCeroDecimal;
                    Decimal Tica = Variables.ValorCeroDecimal;
                    Decimal.TryParse(txtTica.Text, out Tica);

                    if (cboMonedaCuenta.SelectedValue.ToString() == Variables.Soles)
                    {
                        Decimal.TryParse(txtSoles.Text, out Soles);
                        txtDolares.Text = Decimal.Round((Soles / Tica), 2).ToString("N2");
                        txtSoles.Text = Soles.ToString("N2");
                    }
                    else
                    {
                        Decimal.TryParse(txtDolares.Text, out Dolares);
                        txtSoles.Text = Decimal.Round((Dolares * Tica), 2).ToString("N2");
                        txtDolares.Text = Dolares.ToString("N2");
                    }
                }
            }
            
            if (chkTicaAuto.Checked)
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
            else
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }

            //Habilita textbox de los montos
            BloquearCajas();
        }

        private void btPendientes_Click(object sender, EventArgs e)
        {
            String VersionPlanCuentas = oVoucherDet.PlanCuenta.numVerPlanCuentas;
            String Cuenta = oVoucherDet.PlanCuenta.codCuenta;
            String RazonSocial = txtRazonSocial.Text;

            if (String.IsNullOrEmpty(txtRazonSocial.Text))
            {
                Global.MensajeComunicacion("Debe Ingresar un auxiliar.");
                btRuc.Focus();
                return;
            }

            List<conCtaCteItemE> ListaCtaCte = AgenteContabilidad.Proxy.ListarConCtaCtePendientes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VersionPlanCuentas, Cuenta, idPersona.Value, oVoucherCab.fecOperacion.Value.Date);

            if (ListaCtaCte.Count == Variables.Cero)
            {
                Global.MensajeComunicacion(String.Format("No hay documentos pendientes de {0}", RazonSocial));
                return;
            }

            frmCtaCtePendientes oFrm = new frmCtaCtePendientes(ListaCtaCte, VersionPlanCuentas, Cuenta, idPersona.Value, RazonSocial, oVoucherCab.fecOperacion.Value);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaItemCtacte.Count > Variables.Cero)
            {
                chkTicaAuto.CheckedChanged -= chkTicaAuto_CheckedChanged;
                List<conCtaCteItemE> oListaCtaCteItems = oFrm.oListaItemCtacte;
                oListaVouchers = new List<VoucherItemE>();

                foreach (conCtaCteItemE item in oListaCtaCteItems)
                {
                    cboDocumento.SelectedValue = item.idDocumento.ToString();
                    txtSerie.Text = item.serDocumento;
                    txtNumDoc.Text = item.numDocumento;
                    dtpFecDocumento.Value = item.fecDocumento;

                    dtpFecDocumento_Leave(new object(), new EventArgs());
                    cboDebeHaber.SelectedValue = item.indDebeHaber;

                    txtSoles.Text = Math.Abs(item.SaldoSoles).ToString("N2");
                    txtDolares.Text = Math.Abs(item.SaldoDolares).ToString("N2");
                    idCtaCteTmp = item.idCtaCte;
                    indMovimientoCtaCte = true;

                    txtCCostos.Text = item.idCCostos;

                    if (!String.IsNullOrEmpty(txtCCostos.Text.Trim()))
                    {
                        CCostosE oCCosto = AgenteMaestro.Proxy.ObtenerCCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCCostos.Text.Trim());

                        if (oCCosto != null)
                        {
                            txtDesCCostos.Text = oCCosto.desCCostos;
                        }
                        else
                        {
                            txtDesCCostos.Text = String.Empty;
                        }
                    }

                    txtPartida.Text = item.codPartidaPresu;

                    PartidaPresupuestariaE oPartida = AgenteMaestro.Proxy.ListarPartidaPresupuestariaPorCodigo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtPartida.Text.Trim());

                    if (oPartida != null)
                    {
                        TipoPartida = oPartida.tipPartidaPresu;
                        txtDesPartida.Text = oPartida.desPartidaPresu;
                    }


                    oListaVouchers.Add(DatosPorAceptar());
                }

                chkTicaAuto.Checked = false;
                //Habilita textbox de los montos
                BloquearCajas();
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                chkTicaAuto.CheckedChanged += chkTicaAuto_CheckedChanged;
            }
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            if (txtCuenta.Text.Trim().Length == 0)
            {
                txtDesCuenta.Text = String.Empty;
            }
        }

        private void txtSoles_TextChanged(object sender, EventArgs e)
        {
            Cambio = true;
        }

        private void txtDolares_TextChanged(object sender, EventArgs e)
        {
            Cambio = true;
        }

        private void txtTica_TextChanged(object sender, EventArgs e)
        {
            Cambio = true;
        }

        private void dtpFecDocumento_Leave(object sender, EventArgs e)
        {
            String Libro = oVoucherCab.idComprobante;

            //ComprobantesE lLibro = (from x in VariablesLocales.oListaComprobantes
            //                        where x.idComprobante == Libro
            //                        select x).FirstOrDefault();
            if (Cambio)
            {
                //DateTime Fecha = dtpFecDocumento.Value.Date;
                //TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha);

                //if (Tica != null)
                //{
                //    if (lLibro.indTCVenta)
                //    {
                //        txtTica.Text = Tica.valVenta.ToString("N3");
                //    }
                //    else
                //    {
                //        txtTica.Text = Tica.valCompra.ToString("N3");
                //    }

                //    txtTica_Leave(new Object(), new EventArgs());
                //}
                //else
                //{
                //    dtpFecDocumento.Focus();
                //    Global.MensajeFault("Fecha ingresada no tiene registrado el Tipo de Cambio.");
                //}

                if (cboDocumento.SelectedValue.ToString() != "NC" && cboDocumento.SelectedValue.ToString() != "CR")
                {
                    DateTime Fecha = dtpFecDocumento.Value;
                    Decimal Monto = VariablesLocales.MontoTicaConta(Fecha.Date, Variables.Dolares, Libro);

                    if (Monto == 0)
                    {
                        Global.MensajeFault("Fecha ingresada no tiene registrado el Tipo de Cambio.");
                    }

                    txtTica.Text = Monto.ToString("N3");
                    txtTica_Leave(new Object(), new EventArgs());
                    Cambio = false; 
                }
            }
            else
            {
                if (indMovimientoCtaCte)
                {
                    //DateTime Fecha = dtpFecDocumento.Value.Date;
                    DateTime Fecha = dtpFecDocumento.Value;
                    Decimal Monto = VariablesLocales.MontoTicaConta(Fecha.Date, Variables.Dolares, Libro);

                    if (Monto == 0)
                    {
                        Global.MensajeFault("Fecha ingresada no tiene registrado el Tipo de Cambio.");
                    }

                    txtTica.Text = Monto.ToString("N3");
                    Cambio = false;
                    
                    //TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.Date);

                    //if (Tica != null)
                    //{
                    //    if (lLibro.indTCVenta)
                    //    {
                    //       txtTica.Text = Tica.valVenta.ToString("N3");
                    //    }
                    //    else
                    //    {
                    //       txtTica.Text = Tica.valCompra.ToString("N3");
                    //    }

                    //txtTica_Leave(new Object(), new EventArgs());
                    //}
                    //else
                    //{
                    //    dtpFecDocumento.Focus();
                    //    Global.MensajeFault("Fecha ingresada no tiene registrado el Tipo de Cambio.");
                    //}

                    Cambio = false;
                    txtTica_Leave(new Object(), new EventArgs());
                }
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtRuc.Text.Trim()))
            //{
            txtRazonSocial.Text = String.Empty;
            //}
        }

        private void txtCCostos_Leave(object sender, EventArgs e)
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

        private void txtCCostos_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCCostos.Text.Trim()))
            {
                txtDesCCostos.Text = String.Empty;
            }
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            ComboHelper.AutoCompletar(cboDocumento, e, false);
        }

        private void cboReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            ComboHelper.AutoCompletar(cboReferencia, e, false);
        }

        private void cboDebeHaber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void btBuscarGasto_Click(object sender, EventArgs e)
        {
            if (indCtaGasto == Variables.SI)
            {
                frmBuscarConceptosGasto oFrm = new frmBuscarConceptosGasto();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                {
                    txtIdConcepto.Text = oFrm.oConcepto.idConcepto.ToString();
                    txtDesGasto.Text = oFrm.oConcepto.desConcepto;
                }
            }
            else
            {
                Global.MensajeComunicacion("Tiene que ingresar una cuenta de gasto!!!");
            }
        }

        private void txtIdCampana_TextChanged(object sender, EventArgs e)
        {
            if (txtIdCampana.TextLength == Variables.Cero)
            {
                txtDesProyecto.Text = String.Empty;
            }
        }

        private void txtIdConcepto_TextChanged(object sender, EventArgs e)
        {
            if (txtIdConcepto.TextLength == Variables.Cero)
            {
                txtDesGasto.Text = String.Empty;
            }
        }

        private void cboDocumento_Leave(object sender, EventArgs e)
        {
            try
            {
                cboDocumento_SelectionChangeCommitted(new Object(), new EventArgs());
                //if (cboDocumento.SelectedValue != null)
                //{
                //    if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
                //    {
                //        pnlDocumentoRefe.Enabled = true;

                //        if (!String.IsNullOrEmpty(oVoucherDet.idDocumentoRef))
                //        {
                //            cboReferencia.SelectedValue = oVoucherDet.idDocumentoRef;
                //            txtSerieRef.Text = oVoucherDet.serDocumentoRef;
                //            txtNumDocRef.Text = oVoucherDet.numDocumentoRef;

                //            if (oVoucherDet.fecDocumentoRef != null)
                //            {
                //                dtpFecDocRefe.Value = Convert.ToDateTime(oVoucherDet.fecDocumentoRef);
                //            }
                //            else
                //            {
                //                dtpFecDocRefe.Checked = false;
                //            }
                //        }
                //        else
                //        {
                //            cboReferencia.SelectedValue = Variables.ValorCero.ToString();
                //            txtSerieRef.Text = String.Empty;
                //            txtNumDocRef.Text = String.Empty;
                //            dtpFecDocRefe.Checked = false;
                //        }
                //    }
                //    else
                //    {
                //        pnlDocumentoRefe.Enabled = false;
                //        cboReferencia.SelectedValue = Variables.ValorCero.ToString();
                //        txtSerieRef.Text = String.Empty;
                //        txtNumDocRef.Text = String.Empty;
                //        dtpFecDocRefe.Checked = false;
                //    }

                //    if (((DocumentosE)cboDocumento.SelectedItem).codMedioPago != null)
                //    {
                //        cboMedioPago.SelectedValue = ((DocumentosE)cboDocumento.SelectedItem).codMedioPago;
                //    }

                //    if (((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "50" || ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "51" ||
                //        ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "52" || ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "53" ||
                //        ((DocumentosE)cboDocumento.SelectedItem).CodigoSunat == "54")
                //    {
                //        cboAduanas.Enabled = true;
                //        //Dependencias aduaneras
                //        List<ParTabla> ListarDependencias = AgenteGeneral.Proxy.ListarParTablaPorNemo("DEAD");
                //        ParTabla FilaNueva = new ParTabla() { IdParTabla = Variables.ValorCero, desTemporal = Variables.TextoSeleccione };
                //        ListarDependencias.Add(FilaNueva);
                //        ComboHelper.LlenarCombos<ParTabla>(cboAduanas, (from x in ListarDependencias orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");
                //    }
                //    else
                //    {
                //        cboAduanas.DataSource = null;
                //        cboAduanas.Enabled = false;
                //    }
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboDocumento_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboDocumento.Text))
            {
                cboDocumento.SelectedValue = Variables.Cero.ToString();
            }
        }

        private void dtpFecDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            //{
            txtRuc.Text = String.Empty;
            //}
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!txtCCostos.Enabled)
                {
                    cboDocumento.Focus();
                }
                else
                {
                    txtCCostos.Focus();
                }
            }
        }

        private void dtpFecVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboDebeHaber.Focus();
            }
        }        

        private void txtNumDetra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFecDetraccion.Checked = true;
                dtpFecDetraccion.Focus();   
            }
        }

        private void dtpFecDetraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboTipoDetraccion.Focus();
            }
        }

        private void btnDistribucionCCostos_Click(object sender, EventArgs e)
        {
        
                Decimal ImporteSoles = Variables.Cero;
                Decimal.TryParse(txtSoles.Text, out ImporteSoles);
                Decimal ImporteDolares = Variables.Cero;
                Decimal.TryParse(txtDolares.Text, out ImporteDolares);

                if (Convert.ToDecimal(ImporteSoles) == 0 && Convert.ToDecimal(ImporteDolares) == 0)
                {
                    Global.MensajeFault("Debe de ingresar el Importe");
                    txtSoles.Focus();
                    return;
                }

                frmVoucherItemCCostos oFrm = null;

                if (oVoucherCab.idMoneda == Variables.Soles)
                {
                    oFrm = new frmVoucherItemCCostos(ImporteSoles);
                }
                else
                {
                    oFrm = new frmVoucherItemCCostos(ImporteDolares);
                }

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oLista.Count > Variables.Cero)
                {
                    List<VoucherItemCCostosE> oListaCCostos = oFrm.oLista;
                    oListaVouchers = new List<VoucherItemE>();

                    txtSoles.TextChanged -= txtSoles_TextChanged;
                    txtDolares.TextChanged -= txtDolares_TextChanged;

                    foreach (VoucherItemCCostosE item in oListaCCostos)
                    {
                        txtCCostos.Text = item.idCCostos;
                        txtDesCCostos.Text = item.desCCostos;

                        if (oVoucherCab.idMoneda == Variables.Soles)
                        {
                            txtSoles.Text = item.ImportePorcentaje.Value.ToString("N2");
                            txtDolares.Text = (item.ImportePorcentaje.Value / oVoucherCab.tipCambio.Value).ToString("N2");
                        }
                        else
                        {
                            txtDolares.Text = item.ImportePorcentaje.Value.ToString("N2");
                            txtSoles.Text = (item.ImportePorcentaje.Value * oVoucherCab.tipCambio.Value).ToString("N2");
                        }

                        indDistribucion = true;

                        oListaVouchers.Add(DatosPorAceptar());
                    }

                    txtSoles.TextChanged += txtSoles_TextChanged;
                    txtDolares.TextChanged += txtDolares_TextChanged;
                }
        }

        private void txtCuenta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCuenta.Text))
            {
                if (txtCuenta.Text != CuentaTemporal)
                {
                    oVoucherDet.PlanCuenta = VariablesLocales.ObtenerPlanCuenta(txtCuenta.Text);

                    if (oVoucherDet.PlanCuenta != null)
                    {
                        PresentarCuenta();
                    }
                    else
                    {
                        Global.MensajeComunicacion("La cuenta ingresada " + txtCuenta.Text + " no existe.");
                        btCuenta.PerformClick();
                    }
                }
            }
            else
            {
                oVoucherDet.PlanCuenta = null;              
                HabilitaTextBoxMovimientos();
            }
        }

        private void cboDocumentosCredito_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (((DocumentosE)cboDocumentosCredito.SelectedItem).indCreditoFiscal)
                {
                    cboAduanas.Enabled = true;
                    //Dependencias aduaneras
                    List<ParTabla> ListarDependencias = AgenteGeneral.Proxy.ListarParTablaPorNemo("DEAD");
                    ParTabla FilaNueva = new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione };
                    ListarDependencias.Add(FilaNueva);
                    ComboHelper.LlenarCombos<ParTabla>(cboAduanas, (from x in ListarDependencias orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");

                    cboAduanas.SelectedValue = (Int32)((DocumentosE)cboDocumento.SelectedItem).depAduanera;

                    if (((DocumentosE)cboDocumentosCredito.SelectedItem).indCreditoFiscal)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
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
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            idPersona = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            if (txtCCostos.Enabled)
                            {
                                txtCCostos.Focus();
                            }
                            else
                            {
                                if (pnlDocumentos.Enabled)
                                {
                                    cboDocumento.Focus();
                                }
                            }

                            if (btPendientes.Enabled)
                            {
                                //btPendientes.PerformClick();
                                btPendientes_Click(new object(), new EventArgs());
                            }
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        idPersona = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        if (txtCCostos.Enabled)
                        {
                            txtCCostos.Focus();
                        }
                        else
                        {
                            if (pnlDocumentos.Enabled)
                            {
                                cboDocumento.Focus();
                            }
                        }

                        if (btPendientes.Enabled)
                        {
                            //btPendientes.PerformClick();
                            btPendientes_Click(new object(), new EventArgs());
                        }
                    }
                    else
                    {
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("La razón social ingresada no existe");
                        btRuc.PerformClick();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            idPersona = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            if (txtCCostos.Enabled)
                            {
                                txtCCostos.Focus();
                            }
                            else
                            {
                                if (pnlDocumentos.Enabled)
                                {
                                    cboDocumento.Focus();
                                }
                            }

                            if (btPendientes.Enabled)
                            {
                                //btPendientes.PerformClick();
                                btPendientes_Click(new object(), new EventArgs());
                            }
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        idPersona = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        if (txtCCostos.Enabled)
                        {
                            txtCCostos.Focus();
                        }
                        else
                        {
                            if (pnlDocumentos.Enabled)
                            {
                                cboDocumento.Focus();
                            }
                        }

                        if (btPendientes.Enabled)
                        {
                            //btPendientes.PerformClick();
                            btPendientes_Click(new object(), new EventArgs());
                        }
                    }
                    else
                    {
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("El Ruc ingresado no existe");
                        btRuc.PerformClick();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboMonedaCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BloquearCajas();
        }
        
        private void dtpFecDocRefe_ValueChanged(object sender, EventArgs e)
        {
            if (Cambio)
            {
                if (dtpFecDocRefe.Enabled && dtpFecDocRefe.Checked)
                {
                    DateTime Fecha = dtpFecDocRefe.Value;
                    Decimal Monto = VariablesLocales.MontoTicaConta(Fecha.Date, Variables.Dolares, oVoucherCab.idComprobante);

                    if (Monto == 0)
                    {
                        Global.MensajeFault("La fecha de la referencia no tiene Tipo de Cambio, escoja otra fecha.");
                    }

                    txtTica.Text = Monto.ToString("N3");
                    //Cambio = false;
                    txtTica_Leave(new Object(), new EventArgs());
                } 
            }
        }

        private void txtPartida_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                txtPartida.TextChanged -= txtPartida_TextChanged;
                PartidaPresupuestariaE oPartida = AgenteMaestro.Proxy.ListarPartidaPresupuestariaPorCodigo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtPartida.Text.Trim());

                if (oPartida != null)
                {
                    TipoPartida = oPartida.tipPartidaPresu;
                    txtPartida.Text = oPartida.codPartidaPresu;
                    txtDesPartida.Text = oPartida.desPartidaPresu;
                }

                txtPartida.TextChanged += txtPartida_TextChanged;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}
