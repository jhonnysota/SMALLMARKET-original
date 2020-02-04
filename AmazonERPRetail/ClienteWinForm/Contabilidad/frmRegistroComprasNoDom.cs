using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using Entidades.Generales;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmRegistroComprasNoDom : FrmMantenimientoBase
    {

        #region Constructores

        public frmRegistroComprasNoDom()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
        }

        public frmRegistroComprasNoDom(int Tipo)
            : this()
        {
            if (Tipo == 2)
            {
                Text = "Registro de Compras No Domicialiados";
            }
        } 

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        RegistroCompras2E oRegistro = null;
        Int32 Opcion = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Diarios
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "Descripcion", false);

            //Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desMoneda", false);

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                     where x.indDocumentoCompras == true
                                                                     && x.indDocNoDom == true
                                                                     select x).ToList();        
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento", false);

            //Documentos - Crédito Fiscal
            ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indDocumentoCompras == true
                                                                      && x.indCreditoFiscal == true
                                                                      select x).ToList();
            Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);

            ComboHelper.RellenarCombos<DocumentosE>(cboDocCreditoFiscal, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento", false);

            //Paises
            List<PaisesE> ListarPaises = AgenteGeneral.Proxy.ListarPaises();
            PaisesE p = new PaisesE() { idPais = Variables.Cero, Nombre = Variables.Seleccione };
            ListarPaises.Add(p);

            ComboHelper.LlenarCombos<PaisesE>(cboPais, (from x in ListarPaises orderby x.idPais select x).ToList(), "idPais", "Nombre");
            ComboHelper.LlenarCombos<PaisesE>(cboPaisBenef, (from x in ListarPaises orderby x.idPais select x).ToList(), "idPais", "Nombre");

            /***************************** PARTABLA ************************************/
            ParTabla FilaNueva = new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione };

            //Dependencias aduaneras
            List<ParTabla> ListarDependencias = AgenteGeneral.Proxy.ListarParTablaPorNemo("DEAD");
            ListarDependencias.Add(FilaNueva);
            ComboHelper.LlenarCombos<ParTabla>(cboDependencia, (from x in ListarDependencias orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");            

            //Vinculos
            List<ParTabla> oListaVinculos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPVI");
            ComboHelper.LlenarCombos<ParTabla>(cboVinculo, (from x in oListaVinculos orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");

            //Convenios
            List<ParTabla> oListaConvenios = AgenteGeneral.Proxy.ListarParTablaPorNemo("DOBTRI");
            ComboHelper.LlenarCombos<ParTabla>(cboConvenios, (from x in oListaConvenios orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");

            //Exoneración aplicada
            List<ParTabla> oListaExoneracion = AgenteGeneral.Proxy.ListarParTablaPorNemo("EXOPNODOM");
            ComboHelper.LlenarCombos<ParTabla>(cboExoneracion, (from x in oListaExoneracion orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");

            //Tipo Renta
            List<ParTabla> oListaTipoRenta = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPREN");
            ComboHelper.LlenarCombos<ParTabla>(cboTipoRenta, (from x in oListaTipoRenta orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");

            //Modalidad del servicio
            List<ParTabla> oListaModalidades = AgenteGeneral.Proxy.ListarParTablaPorNemo("MODSP");
            ComboHelper.LlenarCombos<ParTabla>(cboModalidad, (from x in oListaModalidades orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");

            //Listado de las cuentas de renta
            List<PlanCuentasE> oListaCuentas = AgenteContabilidad.Proxy.CuentasRenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);
            PlanCuentasE oCuenta = new PlanCuentasE() { codCuenta = "0", desCuentaTemp = Variables.Seleccione };
            oListaCuentas.Add(oCuenta);
            ComboHelper.LlenarCombos<PlanCuentasE>(cboTasa, (from x in oListaCuentas orderby x.codCuenta select x).ToList(), "codCuenta", "desCuentaTemp");

            ListaTipoComprobante = null;
            ListaMoneda = null;
            ListaDocumentos = null;
            ListarPaises = null;
            ListarDependencias = null;
            oListaVinculos = null;
            oListaConvenios = null;
            oListaExoneracion = null;
            oListaTipoRenta = null;
            oListaModalidades = null;
        }

        void DatosGrabacion()
        {
            oRegistro.fecOperacion = dtpFecOperacion.Value.Date;
            oRegistro.AnioPeriodo = dtpFecOperacion.Value.Year.ToString();
            oRegistro.MesPeriodo = dtpFecOperacion.Value.ToString("MM");
            oRegistro.idComprobante = cboLibro.SelectedValue.ToString();
            oRegistro.numFile = cboFile.SelectedValue.ToString();
            oRegistro.numVoucher = txtNumVoucher.Text;
            oRegistro.indVoucher = false;
            oRegistro.indHojaCosto = chkIndCosto.Checked;
            oRegistro.idHojaCosto = chkIndCosto.Checked ? Convert.ToInt32(txtNumHojaCosto.Text) : (Int32?)null;
            oRegistro.Glosa = txtGlosaGeneral.Text.Trim();
            oRegistro.codCuenta = cboTasa.SelectedValue.ToString();
            oRegistro.idPersona = !string.IsNullOrEmpty(txtIdPersona.Text.Trim()) ? Convert.ToInt32(txtIdPersona.Text) : (int?)null;
            oRegistro.idPersonaBen = !string.IsNullOrEmpty(txtIdBene.Text.Trim()) ? Convert.ToInt32(txtIdBene.Text) : (int?)null;
            oRegistro.Periodo = txtPeriodo.Text;
            oRegistro.Correlativo = string.Empty;
            oRegistro.fecEmisDocumento = dtpFecDocumento.Value.Date;
            oRegistro.tipDocumentoVenta = cboDocumento.SelectedValue.ToString();
            oRegistro.serDocumento = txtSerie.Text.Trim();
            oRegistro.numDocumento = txtNumDoc.Text.Trim();
            oRegistro.ValorAdquisicion = Convert.ToDecimal(txtValorAdquisicion.Text);
            oRegistro.OtrosConceptos = Convert.ToDecimal(txtOtroConcepto.Text);
            oRegistro.TotalAdquisiciones = Convert.ToDecimal(txtTotalAdquisicion.Text);
            oRegistro.tipDocCreditoFiscal = cboDocCreditoFiscal.SelectedValue.ToString();
            oRegistro.serCreditoFiscal = txtSerieCredFiscal.Text;
            oRegistro.AnioDua = txtAnioDua.Text.Trim();
            oRegistro.numCreditoFiscal = txtNumDua.Text.Trim();
            oRegistro.MontoIgvRet = Convert.ToDecimal(txtIgvRetenido.Text);
            oRegistro.idMoneda = cboMonedas.SelectedValue.ToString();
            oRegistro.indTicaAuto = chkTica.Checked;
            oRegistro.tipCambio = Convert.ToDecimal(txtTica.Text);
            oRegistro.PaidResidencia = cboPais.SelectedValue.ToString();
            //oRegistro.RazonSocial = txtRazonSocial.Text;
            //oRegistro.Direccion = txtDireccion.Text.Trim();
            //oRegistro.numIdentificacion = txtNroIdentificacion.Text.Trim();
            //oRegistro.numIdentiBenef = txtIdentiBenef.Text.Trim();
            //oRegistro.RazonBeneficiario = txtRazonBenef.Text.Trim();
            oRegistro.PaisBeneficiario = cboPaisBenef.SelectedValue.ToString();
            oRegistro.Vinculo = cboVinculo.SelectedValue.ToString();
            oRegistro.RentaBruta = Convert.ToDecimal(txtRentaBruta.Text);
            oRegistro.EnajenacionBienes = Convert.ToDecimal(txtEnaBienes.Text);
            oRegistro.RentaNeta = Convert.ToDecimal(txtRentaNeta.Text);
            oRegistro.TasaRetencion = Convert.ToDecimal(txtTasaRetencion.Text);
            oRegistro.ImpuestoRetenido = Convert.ToDecimal(txtImpuestoRete.Text);
            oRegistro.ConvenioDobImpo = cboConvenios.SelectedValue.ToString();
            oRegistro.ExoneracionApli = cboExoneracion.SelectedValue.ToString();
            oRegistro.TipoRenta = cboTipoRenta.SelectedValue.ToString();
            oRegistro.ModalidadServicio = cboModalidad.SelectedValue.ToString();
            oRegistro.LeyImpuestoRenta = txtLey.Text.Trim();
            oRegistro.Estado = txtEstado.Text.Trim();
            oRegistro.TipoCompra = 2;

            if (Opcion == (int)EnumOpcionGrabar.Insertar)
            {
                oRegistro.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oRegistro.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
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

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oRegistro == null)
            {
                oRegistro = new RegistroCompras2E();

                oRegistro.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oRegistro.idLocal = VariablesLocales.SesionLocal.IdLocal;

                txtNumVoucher.Text = "0";
                txtPeriodo.Text = dtpFecOperacion.Value.ToString("yyyyMM") + "00";
                cboLibro.SelectedValue = Variables.RegistroCompra;
                cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                txtGlosaGeneral.Text = "ASIENTO AUTOMATICO";
                dtpFecOperacion_ValueChanged(null, null);
                dtpFecDocumento_ValueChanged(null, null);
                txtEstado.Text = "0";
                Opcion = (int)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtNroIdentificacion.TextChanged -= txtNroIdentificacion_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                txtIdentiBenef.TextChanged -= txtIdentiBenef_TextChanged;
                txtRazonBenef.TextChanged -= txtRazonBenef_TextChanged;
                dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
                dtpFecOperacion.ValueChanged -= dtpFecOperacion_ValueChanged;

                dtpFecOperacion.Value = oRegistro.fecOperacion;
                //oRegistro.AnioPeriodo = dtpFecOperacion.Value.Year.ToString();
                //oRegistro.MesPeriodo = dtpFecOperacion.Value.ToString("MM");
                cboLibro.SelectedValue = oRegistro.idComprobante;
                cboFile.SelectedValue = oRegistro.numFile;
                txtNumVoucher.Text = oRegistro.numVoucher;
                //oRegistro.indVoucher;
                chkIndCosto.Checked = oRegistro.indHojaCosto;
                oRegistro.idHojaCosto = chkIndCosto.Checked ? Convert.ToInt32(txtNumHojaCosto.Text) : (Int32?)null;
                oRegistro.Glosa = txtGlosaGeneral.Text.Trim();
                oRegistro.codCuenta = cboTasa.SelectedValue.ToString();
                oRegistro.idPersona = !string.IsNullOrEmpty(txtIdPersona.Text.Trim()) ? Convert.ToInt32(txtIdPersona.Text) : (int?)null;
                oRegistro.idPersonaBen = !string.IsNullOrEmpty(txtIdBene.Text.Trim()) ? Convert.ToInt32(txtIdBene.Text) : (int?)null;
                oRegistro.Periodo = txtPeriodo.Text;
                oRegistro.Correlativo = string.Empty;
                oRegistro.fecEmisDocumento = dtpFecDocumento.Value.Date;
                oRegistro.tipDocumentoVenta = cboDocumento.SelectedValue.ToString();
                oRegistro.serDocumento = txtSerie.Text.Trim();
                oRegistro.numDocumento = txtNumDoc.Text.Trim();
                oRegistro.ValorAdquisicion = Convert.ToDecimal(txtValorAdquisicion.Text);
                oRegistro.OtrosConceptos = Convert.ToDecimal(txtOtroConcepto.Text);
                oRegistro.TotalAdquisiciones = Convert.ToDecimal(txtTotalAdquisicion.Text);
                oRegistro.tipDocCreditoFiscal = cboDocCreditoFiscal.SelectedValue.ToString();
                oRegistro.serCreditoFiscal = txtSerieCredFiscal.Text;
                oRegistro.AnioDua = txtAnioDua.Text.Trim();
                oRegistro.numCreditoFiscal = txtNumDua.Text.Trim();
                oRegistro.MontoIgvRet = Convert.ToDecimal(txtIgvRetenido.Text);
                oRegistro.idMoneda = cboMonedas.SelectedValue.ToString();
                oRegistro.indTicaAuto = chkTica.Checked;
                oRegistro.tipCambio = Convert.ToDecimal(txtTica.Text);
                oRegistro.PaidResidencia = cboPais.SelectedValue.ToString();
                //oRegistro.RazonSocial = txtRazonSocial.Text;
                //oRegistro.Direccion = txtDireccion.Text.Trim();
                //oRegistro.numIdentificacion = txtNroIdentificacion.Text.Trim();
                //oRegistro.numIdentiBenef = txtIdentiBenef.Text.Trim();
                //oRegistro.RazonBeneficiario = txtRazonBenef.Text.Trim();
                oRegistro.PaisBeneficiario = cboPaisBenef.SelectedValue.ToString();
                oRegistro.Vinculo = cboVinculo.SelectedValue.ToString();
                oRegistro.RentaBruta = Convert.ToDecimal(txtRentaBruta.Text);
                oRegistro.EnajenacionBienes = Convert.ToDecimal(txtEnaBienes.Text);
                oRegistro.RentaNeta = Convert.ToDecimal(txtRentaNeta.Text);
                oRegistro.TasaRetencion = Convert.ToDecimal(txtTasaRetencion.Text);
                oRegistro.ImpuestoRetenido = Convert.ToDecimal(txtImpuestoRete.Text);
                oRegistro.ConvenioDobImpo = cboConvenios.SelectedValue.ToString();
                oRegistro.ExoneracionApli = cboExoneracion.SelectedValue.ToString();
                oRegistro.TipoRenta = cboTipoRenta.SelectedValue.ToString();
                oRegistro.ModalidadServicio = cboModalidad.SelectedValue.ToString();
                oRegistro.LeyImpuestoRenta = txtLey.Text.Trim();
                oRegistro.Estado = txtEstado.Text.Trim();
                oRegistro.TipoCompra = 2;

                if (Opcion == (int)EnumOpcionGrabar.Insertar)
                {
                    oRegistro.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                }
                else
                {
                    oRegistro.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                }

                Opcion = (int)EnumOpcionGrabar.Actualizar;

                txtNroIdentificacion.TextChanged += txtNroIdentificacion_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                txtIdentiBenef.TextChanged += txtIdentiBenef_TextChanged;
                txtRazonBenef.TextChanged += txtRazonBenef_TextChanged;
                dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
                dtpFecOperacion.ValueChanged += dtpFecOperacion_ValueChanged;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                //Totales = true;
                DatosGrabacion();

                if (oRegistro != null)
                {

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oRegistro = AgenteContabilidad.Proxy.InsertarRegistroComprasNoDom(oRegistro);
                    }
                    else
                    {
                        oRegistro = AgenteContabilidad.Proxy.ActualizarRegistroComprasNoDom(oRegistro);
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

        private void frmRegistroComprasNoDom_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIndCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndCosto.Checked)
            {
                btCosto.Enabled = true;
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                btCosto.Enabled = false;
                txtNumHojaCosto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), Descripcion = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "Descripcion", false);
                    ListaFiles = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpFecOperacion_ValueChanged(object sender, EventArgs e)
        {
            txtPeriodo.Text = dtpFecOperacion.Value.ToString("yyyyMM") + "00";
            txtAnioDua.Text = dtpFecOperacion.Value.ToString("yyyy");
        }

        private void cboDocCreditoFiscal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //if (((DocumentosE)cboDocCreditoFiscal.SelectedItem).indCreditoFiscal)
                //{
                //    cboDependencia.Enabled = true;


                //    if (((DocumentosE)cboDependencia.SelectedItem).indAduanera)
                //    {
                //        cboDependencia.SelectedValue = (Int32)((DocumentosE)cboDocumento.SelectedItem).depAduanera;
                //    }
                //}
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
        }

        private void cboPaisBenef_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTasa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTasa.SelectedValue.ToString() == "0")
            {
                txtTasaRetencion.Text = "0.00";
            }
            else
            {
                txtTasaRetencion.Text = ((PlanCuentasE)cboTasa.SelectedItem).TasaRenta.ToString();
            }
        }

        private void chkTica_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkTica.Checked)
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                dtpFecDocumento_ValueChanged(new object(), new EventArgs());
            }
        }

        private void dtpFecDocumento_ValueChanged(object sender, EventArgs e)
        {
            if (chkTica.Checked)
            {
                DateTime Fecha = dtpFecDocumento.Value;
                TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));

                string Libro = cboLibro.SelectedValue.ToString();

                ComprobantesE lLibro = (from x in VariablesLocales.oListaComprobantes
                                        where x.idComprobante == Libro
                                        select x).FirstOrDefault();
                if (Tica != null)
                {
                    if (lLibro.indTCVenta)
                    {
                        txtTica.Text = Tica.valVenta.ToString("N3");
                    }
                    else
                    {
                        txtTica.Text = Tica.valCompra.ToString("N3");
                    }
                }
                else
                {
                    txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtpFecDocumento.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }

            if (dtpFecOperacion.Value.Month != dtpFecDocumento.Value.Date.Month)
            {
                txtEstado.Text = "9";
            }
            else
            {
                txtEstado.Text = "0";
            }
        }

        private void cboVinculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboTipoRenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboConvenios_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboExoneracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboModalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboDocCreditoFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboDependencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMonedas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtNroIdentificacion_TextChanged(object sender, EventArgs e)
        {
            txtIdPersona.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdPersona.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNroIdentificacion.Text = string.Empty;
        }

        private void txtNroIdentificacion_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNroIdentificacion.Text.Trim()) && string.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtNroIdentificacion.TextChanged -= txtNroIdentificacion_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtNroIdentificacion.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroIdentificacion.Text = oFrm.oPersona.RUC;
                            txtIdPersona.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtNroIdentificacion.Text = oListaPersonas[0].RUC;
                        txtIdPersona.Text = oListaPersonas[0].ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtNroIdentificacion.Text = string.Empty;
                        txtIdPersona.Text = string.Empty;
                        txtRazonSocial.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                    }

                    txtNroIdentificacion.TextChanged += txtNroIdentificacion_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
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
                if (!string.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && string.IsNullOrEmpty(txtNroIdentificacion.Text.Trim()))
                {
                    txtNroIdentificacion.TextChanged -= txtNroIdentificacion_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroIdentificacion.Text = oFrm.oPersona.RUC;
                            txtIdPersona.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtNroIdentificacion.Text = oListaPersonas[0].RUC;
                        txtIdPersona.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdPersona.Text = String.Empty;
                        txtNroIdentificacion.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                    }

                    txtNroIdentificacion.TextChanged += txtNroIdentificacion_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtIdentiBenef_TextChanged(object sender, EventArgs e)
        {
            txtIdBene.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
        }

        private void txtRazonBenef_TextChanged(object sender, EventArgs e)
        {
            txtIdBene.Text = string.Empty;
            txtIdentiBenef.Text = string.Empty;
        }

        private void txtIdentiBenef_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtIdentiBenef.Text.Trim()) && string.IsNullOrEmpty(txtRazonBenef.Text.Trim()))
                {
                    txtIdentiBenef.TextChanged -= txtIdentiBenef_TextChanged;
                    txtRazonBenef.TextChanged -= txtRazonBenef_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtIdentiBenef.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdentiBenef.Text = oFrm.oPersona.RUC;
                            txtIdBene.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonBenef.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtIdentiBenef.Text = oListaPersonas[0].RUC;
                        txtIdBene.Text = oListaPersonas[0].ToString();
                        txtRazonBenef.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Nro. de Identificación ingresado no existe");
                        txtIdentiBenef.Text = string.Empty;
                        txtIdBene.Text = string.Empty;
                        txtRazonBenef.Text = string.Empty;
                    }

                    txtIdentiBenef.TextChanged += txtIdentiBenef_TextChanged;
                    txtRazonBenef.TextChanged += txtRazonBenef_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonBenef_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonBenef.Text.Trim()) && string.IsNullOrEmpty(txtIdentiBenef.Text.Trim()))
                {
                    txtIdentiBenef.TextChanged -= txtIdentiBenef_TextChanged;
                    txtRazonBenef.TextChanged -= txtRazonBenef_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonBenef.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdentiBenef.Text = oFrm.oPersona.RUC;
                            txtIdBene.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonBenef.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtIdentiBenef.Text = oListaPersonas[0].RUC;
                        txtIdBene.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonBenef.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social del beneficiario ingresado no existe");
                        txtIdBene.Text = String.Empty;
                        txtIdentiBenef.Text = String.Empty;
                        txtRazonBenef.Text = String.Empty;
                    }

                    txtNroIdentificacion.TextChanged += txtNroIdentificacion_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboPaisBenef_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtValorAdquisicion_Enter(object sender, EventArgs e)
        {
            txtValorAdquisicion.SelectAll();
        }

        private void txtValorAdquisicion_MouseClick(object sender, MouseEventArgs e)
        {
            txtValorAdquisicion.SelectAll();
        }

        private void txtValorAdquisicion_Leave(object sender, EventArgs e)
        {
            txtValorAdquisicion.Text = Global.FormatoDecimal(txtValorAdquisicion.Text);
        }

        private void txtOtroConcepto_Enter(object sender, EventArgs e)
        {
            txtOtroConcepto.SelectAll();
        }

        private void txtOtroConcepto_MouseClick(object sender, MouseEventArgs e)
        {
            txtOtroConcepto.SelectAll();
        }

        private void txtOtroConcepto_Leave(object sender, EventArgs e)
        {
            txtOtroConcepto.Text = Global.FormatoDecimal(txtOtroConcepto.Text);
        }

        private void txtTotalAdquisicion_Enter(object sender, EventArgs e)
        {
            txtTotalAdquisicion.SelectAll();
        }

        private void txtTotalAdquisicion_MouseClick(object sender, MouseEventArgs e)
        {
            txtTotalAdquisicion.SelectAll();
        }

        private void txtTotalAdquisicion_Leave(object sender, EventArgs e)
        {
            txtTotalAdquisicion.Text = Global.FormatoDecimal(txtTotalAdquisicion.Text);
        }

        private void txtIgvRetenido_Enter(object sender, EventArgs e)
        {
            txtIgvRetenido.SelectAll();
        }

        private void txtIgvRetenido_MouseClick(object sender, MouseEventArgs e)
        {
            txtIgvRetenido.SelectAll();
        }

        private void txtIgvRetenido_Leave(object sender, EventArgs e)
        {
            txtIgvRetenido.Text = Global.FormatoDecimal(txtIgvRetenido.Text);
        }

        private void txtTica_Enter(object sender, EventArgs e)
        {
            txtTica.SelectAll();
        }

        private void txtTica_MouseClick(object sender, MouseEventArgs e)
        {
            txtTica.SelectAll();
        }

        private void txtTica_Leave(object sender, EventArgs e)
        {
            txtTica.Text = Global.FormatoDecimal(txtTica.Text, 3);
        }

        private void txtImpuestoRete_Enter(object sender, EventArgs e)
        {
            txtImpuestoRete.SelectAll();
        }

        private void txtImpuestoRete_MouseClick(object sender, MouseEventArgs e)
        {
            txtImpuestoRete.SelectAll();
        }

        private void txtImpuestoRete_Leave(object sender, EventArgs e)
        {
            txtImpuestoRete.Text = Global.FormatoDecimal(txtImpuestoRete.Text);
        }

        private void txtRentaBruta_Enter(object sender, EventArgs e)
        {
            txtRentaBruta.SelectAll();
        }

        private void txtRentaBruta_MouseClick(object sender, MouseEventArgs e)
        {
            txtRentaBruta.SelectAll();
        }

        private void txtRentaBruta_Leave(object sender, EventArgs e)
        {
            txtRentaBruta.Text = Global.FormatoDecimal(txtRentaBruta.Text);
        }

        private void txtEnaBienes_Enter(object sender, EventArgs e)
        {
            txtEnaBienes.SelectAll();
        }

        private void txtEnaBienes_MouseClick(object sender, MouseEventArgs e)
        {
            txtEnaBienes.SelectAll();
        }

        private void txtEnaBienes_Leave(object sender, EventArgs e)
        {
            txtEnaBienes.Text = Global.FormatoDecimal(txtEnaBienes.Text);
        }

        private void txtRentaNeta_Enter(object sender, EventArgs e)
        {
            txtRentaNeta.SelectAll();
        }

        private void txtRentaNeta_MouseClick(object sender, MouseEventArgs e)
        {
            txtRentaNeta.SelectAll();
        }

        private void txtRentaNeta_Leave(object sender, EventArgs e)
        {
            txtRentaNeta.Text = Global.FormatoDecimal(txtRentaNeta.Text);
        }

        private void btCosto_Click(object sender, EventArgs e)
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

        #endregion

    }
}
