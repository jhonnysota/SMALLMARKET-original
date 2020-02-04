using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmReciboHonorariosComprobante : frmResponseBase
    {

        #region Constructores

        public frmReciboHonorariosComprobante()
        {
            InitializeComponent();
            LLenarCombos();
        }

        //Nuevo
        public frmReciboHonorariosComprobante(ReciboHonorariosE oCab_, String anio_, String Mes_)
           :this()
        {
            oCab = oCab_;
            Anio = anio_;
            Mes = Mes_;
        }

        //Edición
        public frmReciboHonorariosComprobante(ReciboHonorariosDetE oDetalle_, String anio_, String Mes_)
            :this()
        {
            oDetalle = oDetalle_;

            if (oDetalle.indVoucher)
            {
                Editable = "NO";
            }

            Anio = anio_;
            Mes = Mes_;
        } 

        #endregion

        #region Variables

        //ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public ReciboHonorariosDetE oDetalle;
        ReciboHonorariosE oCab;
        ParametrosContaE oParametroConta = VariablesLocales.oConParametros;
        String Editable = "SI";
        String BuscarC = "S";
        String Anio = String.Empty;
        String Mes = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LLenarCombos()
        {
            //oParametroConta = AgenteContabilidad.Proxy.ObtenerParametrosConta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desAbreviatura", false);

            //////tipo documento/////////
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral)
            {
                new DocumentosE
                {
                    idDocumento = Variables.Cero.ToString(),
                    desDocumento = Variables.Seleccione,
                    desCorta = "REC"
                }
            };
            ComboHelper.RellenarCombos<DocumentosE>(cboTipoDocumento, (from x in ListaDocumentos
                                                                       where x.desCorta == "REC"
                                                                       orderby x.desDocumento
                                                                       select x).ToList(), "idDocumento", "desDocumento", false);
        }

        void LlenarComboCuentas(ConceptosVariosE oConcepto)
        {
            List<ConceptosVariosE> ListarCuentas = new List<ConceptosVariosE>();
            ConceptosVariosE oCuenta = null;

            if (oConcepto.indCuentaAdm)
            {
                oCuenta = new ConceptosVariosE()
                {
                    Cuentas = oConcepto.codCuentaAdm,
                    Descripcion = "ADMINISTRACION",
                    indCentroCosto = oConcepto.indCCAdm,
                    numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                    desCuentas = oConcepto.desCuentaAdm
                };

                ListarCuentas.Add(oCuenta);
            }

            if (oConcepto.indCuentaVen)
            {
                oCuenta = new ConceptosVariosE()
                {
                    Cuentas = oConcepto.codCuentaVen,
                    Descripcion = "VENTAS",
                    indCentroCosto = oConcepto.indCCVen,
                    numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                    desCuentas = oConcepto.desCuentaVen
                };

                ListarCuentas.Add(oCuenta);
            }

            if (oConcepto.indCuentaPro)
            {
                oCuenta = new ConceptosVariosE()
                {
                    Cuentas = oConcepto.codCuentaPro,
                    Descripcion = "PRODUCCION",
                    indCentroCosto = oConcepto.indCCPro,
                    numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                    desCuentas = oConcepto.desCuentaPro
                };

                ListarCuentas.Add(oCuenta);
            }

            if (oConcepto.indCuentaFin)
            {
                oCuenta = new ConceptosVariosE()
                {
                    Cuentas = oConcepto.codCuentaFin,
                    Descripcion = "FINANZAS",
                    indCentroCosto = oConcepto.indCCFin,
                    numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                    desCuentas = oConcepto.desCuentaFin
                };

                ListarCuentas.Add(oCuenta);
            }

            // Llenando las cuentas
            ComboHelper.RellenarCombos<ConceptosVariosE>(cboCuentas, ListarCuentas, "Cuentas", "Descripcion", false);
        } 

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oDetalle == null)
            {
                oDetalle = new ReciboHonorariosDetE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

                oDetalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oDetalle.FechaRegistro = VariablesLocales.FechaHoy;
                oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oDetalle.FechaModificacion = VariablesLocales.FechaHoy;

                dtpOperacion.Value = Convert.ToDateTime("01" + "/" + Mes + "/" + Anio);
                txtFecRecibo_ValueChanged(null, null);
            }
            else
            {
                txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

                BuscarC = "N";

                if (oDetalle.Opcion == 0)
                {
                    oDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                cboTipoDocumento.SelectedValue = oDetalle.idDocumento;
                txtSerie.Text = oDetalle.serDocumento;
                txtNumero.Text = oDetalle.numDocumento;
                dtpOperacion.Value = oDetalle.FechaOperacion;
                txtFecRecibo.Value = oDetalle.FechaRecibo;
                cboMoneda.SelectedValue = oDetalle.idMoneda;
                txtImporte.Text = oDetalle.impRecibo.ToString("N2");
                chkIndCosto.Checked = oDetalle.indHojaCosto;
                txtNumHojaCosto.Text = oDetalle.indHojaCosto ? oDetalle.idHojaCosto.ToString() : string.Empty;
                txtGasto.Text = oDetalle.CuentaGastos;
                txtdesGasto.Text = oDetalle.NomGasto;

                if (oDetalle.oConcepto != null)
                {
                    LlenarComboCuentas(oDetalle.oConcepto);

                    if (cboCuentas.Items.Count > 0)
                    {
                        cboCuentas.Enabled = true;
                        cboCuentas.SelectedValue = oDetalle.CuentaGastos;
                        cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs()); 
                    }
                }
                
                txtCosto.Text = oDetalle.idCCostos;
                txtdesCosto.Text = oDetalle.NomCosto;
                txtGlosa.Text = oDetalle.Glosa;
                chbCuarta.Checked = oDetalle.indCuartaCat;
                txtFormula.Text = oDetalle.codFormula;
                txtPorRetencion.Text = Convert.ToString(oDetalle.porRetencion);
                txtCuartaCat.Text = Convert.ToString(oDetalle.impCuartaCat);
                txtFecPago.Value = Convert.ToDateTime(oDetalle.FechaPago);

                txtIdConcepto.Text = oDetalle.idConcepto.ToString();
                txtCodConcepto.Text = oDetalle.codConcepto;
                txtDesConcepto.Text = oDetalle.nomConcepto;

                if (Editable == "NO")
                {
                    pnlBase.Enabled = false;
                    pnlRetenciones.Enabled = false;
                    btAceptar.Enabled = false;
                }

                BuscarC = "S";

                txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            oDetalle.FechaOperacion = dtpOperacion.Value.Date;
            oDetalle.idDocumento = cboTipoDocumento.SelectedValue.ToString();
            //oDetalle.desDocumento = ((DocumentosE)cboTipoDocumento.SelectedItem).desDocumento;
            oDetalle.serDocumento = txtSerie.Text.Trim();
            oDetalle.numDocumento = txtNumero.Text.Trim();
            oDetalle.FechaRecibo = txtFecRecibo.Value.Date;
            oDetalle.TipoCambio = Convert.ToDecimal(txttipocambio.Text);
            oDetalle.idMoneda = cboMoneda.SelectedValue.ToString();
            oDetalle.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;

            if (oDetalle.idMoneda == Variables.Soles)
            {
                oDetalle.codCuenta = oParametroConta.HonorarioCtaSoles;
            }

            if (oDetalle.idMoneda == Variables.Dolares)
            {
                oDetalle.codCuenta = oParametroConta.HonorarioCtaDolar;
            }

            if (!String.IsNullOrWhiteSpace(txtIdConcepto.Text))
            {
                oDetalle.idConcepto = Convert.ToInt32(txtIdConcepto.Text);
            }
            else
            {
                oDetalle.idConcepto = null;
            }

            oDetalle.impRecibo = Convert.ToDecimal(txtImporte.Text);

            oDetalle.CuentaGastos = txtGasto.Text;
            oDetalle.idCCostos = txtCosto.Text;
            oDetalle.Glosa = txtGlosa.Text;

            oDetalle.indCuartaCat = chbCuarta.Checked;
            oDetalle.codFormula = txtFormula.Text;
            oDetalle.porRetencion = Convert.ToDecimal(txtPorRetencion.Text);
            oDetalle.impCuartaCat = Convert.ToDecimal(txtCuartaCat.Text);
            oDetalle.FechaPago = Convert.ToDateTime(txtFecPago.Value).Date;
            oDetalle.indHojaCosto = chkIndCosto.Checked;
            oDetalle.idHojaCosto = chkIndCosto.Checked ? Convert.ToInt32(txtNumHojaCosto.Text) : (Int32?)null;

            oDetalle.impFlete = 0;
            oDetalle.impRetencion = 0;
            oDetalle.numVerPlanCuenta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

            //oDetalle.Opcion = oDetalle.Opcion;

            if (oDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oDetalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oDetalle.FechaRegistro = VariablesLocales.FechaHoy;
                oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oDetalle.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oDetalle.FechaModificacion = VariablesLocales.FechaHoy;
            }

            if (!ValidarGrabacion()) { return; }
            base.Aceptar();
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<ReciboHonorariosDetE>(oDetalle);

            if (String.IsNullOrWhiteSpace(txtSerie.Text))
            {
                Global.MensajeConfirmacion("Ingrese el Número de Serie");
                return false;
            }

            if (cboTipoDocumento.SelectedIndex == 0)
            {
                Global.MensajeAdvertencia("Ingrese Tipo de Documento");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtNumero.Text))
            {
                Global.MensajeAdvertencia("Ingrese el Número ");
                return false;
            }

            if (oDetalle.FechaOperacion.Year.ToString() != Anio)
            {
                Global.MensajeAdvertencia("El Año debe ser igual al que escogio en el listado principal");
                return false;
            }

            String novo = String.Empty;

            if (oDetalle.FechaOperacion.Month < 10)
            {
                novo = "0" + oDetalle.FechaOperacion.Month.ToString();

                if (novo != Mes)
                {
                    Global.MensajeAdvertencia("El Mes debe ser igual que su listado ");
                    return false;
                }
            }

            if (oDetalle.FechaOperacion.Month >= 10)
            {
                if (oDetalle.FechaOperacion.Month.ToString() != Mes)
                {
                    Global.MensajeAdvertencia("El Mes debe ser igual que su listado ");
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(txtImporte.Text) || txtImporte.Text == "0.00")
            {
                Global.MensajeAdvertencia("Ingrese el Importe");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtGasto.Text))
            {
                Global.MensajeAdvertencia("Debe escoger un gasto con cuentas contables");
                return false;
            }

            //if (String.IsNullOrWhiteSpace(txtCosto.Text))
            //{
            //    Global.MensajeConfirmacion("Ingrese el Nro. De Costo");
            //    return false;
            //}

            if (String.IsNullOrWhiteSpace(txtGlosa.Text))
            {
                Global.MensajeAdvertencia("Ingrese la Glosa");
                return false;
            }

            if (txttipocambio.Text == "0.000")
            {
                Global.MensajeAdvertencia("Ingrese una fecha que tenga Tipo de Cambio");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos de Usuario

        private void lblListaTmp_DoubleClick(object sender, EventArgs e)
        {
            txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
            txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

            ListBox lb = (ListBox)sender;

            txtIdConcepto.Text = lb.SelectedValue.ToString();
            txtCodConcepto.Text = ((ConceptosVariosE)lb.SelectedItem).codConcepto;
            txtDesConcepto.Text = ((ConceptosVariosE)lb.SelectedItem).Descripcion;
            LlenarComboCuentas((ConceptosVariosE)lb.SelectedItem);

            if (cboCuentas.Items.Count > 0)
            {
                cboCuentas.Enabled = true;
                cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());
            }
            else
            {
                cboCuentas.Enabled = false;
            }

            //oConcepto = Colecciones.CopiarEntidad<ConceptosVariosE>((ConceptosVariosE)lb.SelectedItem);
            lb.Visible = false;
            lb.Dispose();

            txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
            txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
        }

        private void lblListaTmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

                ListBox lb = (ListBox)sender;

                txtIdConcepto.Text = lb.SelectedValue.ToString();
                txtCodConcepto.Text = ((ConceptosVariosE)lb.SelectedItem).codConcepto;
                txtDesConcepto.Text = ((ConceptosVariosE)lb.SelectedItem).Descripcion;
                LlenarComboCuentas((ConceptosVariosE)lb.SelectedItem);

                if (cboCuentas.Items.Count > 0)
                {
                    cboCuentas.Enabled = true;
                    cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());
                }
                else
                {
                    cboCuentas.Enabled = false;
                }

                //oConcepto = Colecciones.CopiarEntidad<ConceptosVariosE>((ConceptosVariosE)lb.SelectedItem);
                lb.Visible = false;
                lb.Dispose();

                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
            }
        }

        #endregion

        #region Eventos

        private void frmReciboHonorariosComprobante_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnCosto_Click(object sender, EventArgs e)
        {
            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtCosto.Text = oFrm.CentroCosto.idCCostos;
                txtdesCosto.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoDocumento.SelectedIndex != 0)
                {
                    String idDoc = Convert.ToString(cboTipoDocumento.SelectedValue);
                    DocumentosE Doc = AgenteMaestros.Proxy.ObtenerDocumentos(idDoc);

                    if (Doc != null)
                    {
                        if (Doc.ListaImpuestosDocumentos.Count > Variables.Cero)
                        {
                            foreach (ImpuestosDocumentosE item in Doc.ListaImpuestosDocumentos)
                            {
                                if (item.idImpuesto == 2)
                                {
                                    chbCuarta.Checked = true;
                                    txtPorRetencion.Text = "8";
                                    Decimal Porcen = Convert.ToDecimal(txtPorRetencion.Text);
                                    Decimal Impor = Convert.ToDecimal(txtImporte.Text);
                                    txtCuartaCat.Text = Convert.ToString(Porcen / 100 * Impor);
                                }
                                else
                                {
                                    chbCuarta.Checked = false;
                                    txtPorRetencion.Text = "0.00";
                                    txtCuartaCat.Text = "0.00";
                                }
                            }
                        }
                        else
                        {
                            chbCuarta.Checked = false;
                            txtPorRetencion.Text = "0.00";
                            txtCuartaCat.Text = "0.00";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtFecRecibo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txttipocambio.Enabled)
                {
                    DateTime Fecha = txtFecRecibo.Value.Date;
                    TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));

                    if (Tica != null)
                    {
                        txttipocambio.Text = Tica.valVenta.ToString("N3");
                    }
                    else
                    {
                        txttipocambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                        txtFecRecibo.Focus();
                        //Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String idDoc = Convert.ToString(cboTipoDocumento.SelectedValue);

                if (cboTipoDocumento.SelectedIndex != 0)
                {
                    DocumentosE Doc = new DocumentosE();
                    Doc = AgenteMaestros.Proxy.ObtenerDocumentos(idDoc);

                    if (Doc.ListaImpuestosDocumentos.Count > Variables.Cero && Doc != null)
                    {
                        foreach (ImpuestosDocumentosE item in Doc.ListaImpuestosDocumentos)
                        {
                            if (item.idImpuesto == 2)
                            {
                                chbCuarta.Checked = true;
                                txtPorRetencion.Text = "8";
                                Decimal Porcen = Convert.ToDecimal(txtPorRetencion.Text);
                                Decimal.TryParse(txtPorRetencion.Text, out Porcen);

                                Decimal Impor = Convert.ToDecimal(txtImporte.Text);
                                Decimal.TryParse(txtImporte.Text, out Impor);

                                txtCuartaCat.Text = Convert.ToString(Porcen / 100 * Impor);
                            }
                            else
                            {
                                chbCuarta.Checked = false;
                                txtPorRetencion.Text = "0";
                                txtCuartaCat.Text = "0";
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

        private void txtImporte_Enter(object sender, EventArgs e)
        {
            txtImporte.SelectAll();
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            txtImporte.Text = Global.FormatoDecimal(txtImporte.Text);
        }

        private void txtImporte_MouseClick(object sender, MouseEventArgs e)
        {
            txtImporte.SelectAll();
        }

        private void chkIndCosto_CheckedChanged(object sender, EventArgs e)
        {
            btCosto.Enabled = chkIndCosto.Checked;

            if (chkIndCosto.Checked)
            {
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
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

        private void txtCodConcepto_TextChanged(object sender, EventArgs e)
        {
            txtIdConcepto.Text = String.Empty;
            txtDesConcepto.Text = String.Empty;
            cboCuentas.DataSource = null;
            cboCuentas.Enabled = false;
            txtCosto.Text = String.Empty;
            txtdesGasto.Text = String.Empty;
        }

        private void txtDesConcepto_TextChanged(object sender, EventArgs e)
        {
            txtIdConcepto.Text = String.Empty;
            txtCodConcepto.Text = String.Empty;
            cboCuentas.DataSource = null;
            cboCuentas.Enabled = false;
            txtCosto.Text = String.Empty;
            txtdesGasto.Text = String.Empty;
        }

        private void btBuscarConcepto_Click(object sender, EventArgs e)
        {
            try
            {
                txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;
                txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;

                ParTabla oGasto = AgenteGeneral.Proxy.ParTablaPorNemo("TCSER");

                if (oGasto != null)
                {
                    frmBuscarConceptosVarios oFrm = new frmBuscarConceptosVarios(oGasto.IdParTabla, 0);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                    {
                        ConceptosVariosE oConcepto = Colecciones.CopiarEntidad<ConceptosVariosE>(oFrm.oConcepto);
                        txtIdConcepto.Text = oConcepto.idConcepto.ToString();
                        txtCodConcepto.Text = oConcepto.codConcepto;
                        txtDesConcepto.Text = oConcepto.Descripcion;

                        LlenarComboCuentas(oConcepto);

                        if (cboCuentas.Items.Count > 0)
                        {
                            cboCuentas.Enabled = true;
                            cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());
                        }
                        else
                        {
                            cboCuentas.Enabled = false;
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Falta configurar el parámetro de Servicios en Parámetros Generales");
                }

                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
            }
            catch (Exception ex)
            {
                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void cboCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboCuentas.SelectedValue != null)
                {
                    if (BuscarC == "S")
                    {
                        txtGasto.Text = ((ConceptosVariosE)cboCuentas.SelectedItem).Cuentas;
                        txtdesGasto.Text = ((ConceptosVariosE)cboCuentas.SelectedItem).desCuentas; 
                    }

                    if (((ConceptosVariosE)cboCuentas.SelectedItem).indCentroCosto == Variables.SI)
                    {
                        btnCosto.Enabled = true;
                        txtCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }
                    else
                    {
                        btnCosto.Enabled = false;
                        txtCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtDesConcepto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

                if (String.IsNullOrWhiteSpace(txtCodConcepto.Text) && !String.IsNullOrWhiteSpace(txtDesConcepto.Text))
                {
                    List<ConceptosVariosE> oListaConceptos = oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosCompras(0, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtDesConcepto.Text.Trim(), false);

                    if (oListaConceptos.Count == 1)
                    {
                        ConceptosVariosE oConcepto = Colecciones.CopiarEntidad(oListaConceptos[0]);

                        txtIdConcepto.Text = oConcepto.idConcepto.ToString();
                        txtCodConcepto.Text = oConcepto.codConcepto;
                        txtDesConcepto.Text = oConcepto.Descripcion;
                        LlenarComboCuentas(oConcepto);

                        if (cboCuentas.Items.Count > 0)
                        {
                            cboCuentas.Enabled = true;
                            cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());
                        }
                        else
                        {
                            cboCuentas.Enabled = false;
                        }
                    }
                    else if (oListaConceptos.Count > 1)
                    {
                        ListBox lblListaTmp = new ListBox()
                        {
                            FormattingEnabled = true,
                            Location = new System.Drawing.Point(txtDesConcepto.Location.X, txtDesConcepto.Location.Y + txtDesConcepto.Height + 1),
                            Size = new System.Drawing.Size(464, 43),
                            TabIndex = 0
                        };

                        lblListaTmp.Focus();
                        pnlBase.Controls.Add(lblListaTmp);
                        lblListaTmp.BringToFront();

                        lblListaTmp.DataSource = oListaConceptos;
                        lblListaTmp.DisplayMember = "Descripcion";
                        lblListaTmp.ValueMember = "idConcepto";

                        lblListaTmp.Focus();
                        lblListaTmp.DoubleClick += new EventHandler(lblListaTmp_DoubleClick);
                        lblListaTmp.KeyDown += new KeyEventHandler(lblListaTmp_KeyDown);
                    }
                    else
                    {
                        Global.MensajeComunicacion("La descripción del concepto no existe. Vuelva a ingresarlo nuevamente.");
                        txtDesConcepto.Text = String.Empty;
                        cboCuentas.DataSource = null;
                        txtDesConcepto.Focus();
                    }
                }

                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
            }
            catch (Exception ex)
            {
                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
