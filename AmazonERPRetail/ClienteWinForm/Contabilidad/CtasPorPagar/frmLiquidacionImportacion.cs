using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Seguridad;
using Entidades.Generales;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmLiquidacionImportacion : FrmMantenimientoBase
    {

        #region Contructores

        //Nuevo
        public frmLiquidacionImportacion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvLiquidaciones, true, false, 28);
            LlenarCombos();
            dgvLiquidaciones.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridViewHelper.rowPostPaint_HeaderCount2);
        }

        //Edición
        public frmLiquidacionImportacion(LiquidacionImportacionE oLiquid)
            : this()
        {
            oLiquidacion = AgenteCtasPorPagar.Proxy.ObtenerLiquidacionImportacion(oLiquid.idLiquidacion);
            Text = "Liquidación de Importación (" + oLiquidacion.idLiquidacion.ToString() + ")";
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        LiquidacionImportacionE oLiquidacion = null;
        Int32 opcionGrabar = 0;
        String Bloqueo = "N";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Monedas
            List<MonedasE> ListaMonedas = new List<MonedasE>((from x in VariablesLocales.ListaMonedas
                                                              where x.idMoneda == "01" || x.idMoneda == "02"
                                                              orderby x.idMoneda
                                                              select x).ToList());

            ComboHelper.LlenarCombos<MonedasE>(cboMoneda, ListaMonedas, "idMoneda", "desAbreviatura");

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indTesoreria == true
                                                                      select x).ToList();
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");

            ListaDocumentos = null;
            ListaMonedas = null;
        }

        void Calcular()
        {
            if (oLiquidacion.oListaImportacionesDet != null && oLiquidacion.oListaImportacionesDet.Count > 0)
            {
                Decimal Dolares = oLiquidacion.oListaImportacionesDet.Sum(x => x.DolaresRec);
                Decimal Soles = oLiquidacion.oListaImportacionesDet.Sum(x => x.SolesRec);

                lblMontoDolares.Text = Dolares.ToString("N2");
                lblMontoSoles.Text = Soles.ToString("N2");
            }
            else
            {
                lblMontoSoles.Text = "0.00";
                lblMontoDolares.Text = "0.00";
            }
        }

        void Datos()
        {
            oLiquidacion.idPersona = String.IsNullOrWhiteSpace(txtRuc.Text) ? 0 : Convert.ToInt32(txtRuc.Tag);
            oLiquidacion.Fecha = dtpFecha.Value.Date;
            oLiquidacion.idDocumento = cboDocumento.SelectedValue.ToString();
            oLiquidacion.numSerie = txtSerie.Text;
            oLiquidacion.numDocumento = txtNumero.Text;
            oLiquidacion.idMoneda = cboMoneda.SelectedValue.ToString();
            Decimal.TryParse(txtImporte.Text, out Decimal Importe);
            oLiquidacion.Importe = Importe;
            oLiquidacion.TiCa = Convert.ToDecimal(txtTica.Text);
            oLiquidacion.numVerPlanCuentas = txtCodCuenta.Tag.ToString();
            oLiquidacion.codCuenta = txtCodCuenta.Text;
            oLiquidacion.AnioPeriodo = dtpFecha.Value.ToString("yyyy");
            oLiquidacion.MesPeriodo = dtpFecha.Value.ToString("MM");
            oLiquidacion.idComprobante = txtComprobante.Text;
            oLiquidacion.numFile = txtFile.Text;
            oLiquidacion.Glosa = txtGlosa.Text;

            if (opcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
            {
                oLiquidacion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oLiquidacion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void LlenarComboGrid()
        {
            DataGridViewComboBoxColumn ComboGrid = dgvLiquidaciones.Columns["idMonedaRec"] as DataGridViewComboBoxColumn;

            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(ComboGrid, (from x in oListaMonedas
                                                             where x.idMoneda == "01" || x.idMoneda == "02"
                                                             select x).ToList(), "idMoneda", "desAbreviatura");
        }

        void EditarDetalle(DataGridViewCellEventArgs e, LiquidacionImportacionDetE LineaEdicion)
        {
            try
            {
                if (bsLiquidacionDet.Count > 0)
                {
                    frmLiquidacionImportacionDetalle oFrm = new frmLiquidacionImportacionDetalle(LineaEdicion, Bloqueo, cboMoneda.SelectedValue.ToString());

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oLiquidacion.oListaImportacionesDet[e.RowIndex] = oFrm.oLiquidacionDet;
                        bsLiquidacionDet.DataSource = oLiquidacion.oListaImportacionesDet;
                        bsLiquidacionDet.ResetBindings(false);

                        base.AgregarDetalle();
                    }
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
            if (oLiquidacion == null)
            {
                oLiquidacion = new LiquidacionImportacionE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal
                };

                if (VariablesLocales.oConParametros != null)
                {
                    if (!String.IsNullOrWhiteSpace(VariablesLocales.oConParametros.DiarioLiqui))
                    {
                        ComprobantesE Diario = (from x in VariablesLocales.oListaComprobantes where x.idComprobante == VariablesLocales.oConParametros.DiarioLiqui select x).SingleOrDefault();

                        if (Diario != null)
                        {
                            txtComprobante.Text = VariablesLocales.oConParametros.DiarioLiqui;
                            txtDesComprobante.Text = Diario.Descripcion;
                            txtFile.Text = VariablesLocales.oConParametros.FileLiqui;
                            txtDesFile.Text = (from x in Diario.ListaComprobantesFiles where x.idComprobante == txtComprobante.Text && x.numFile == txtFile.Text select x.Descripcion).SingleOrDefault();
                        }

                        Diario = null;
                    }

                    txtCodCuenta.Tag = VariablesLocales.oConParametros.numVerPlanCuentas;

                    if (cboMoneda.SelectedValue.ToString() == "01")
                    {
                        txtCodCuenta.Text = VariablesLocales.oConParametros.codCtaLiquiSol;
                        txtDesCuenta.Text = VariablesLocales.oConParametros.desCtaLiquiSol;
                    }
                    else
                    {
                        txtCodCuenta.Text = VariablesLocales.oConParametros.codCtaLiquiDol;
                        txtDesCuenta.Text = VariablesLocales.oConParametros.desCtaLiquiDol;
                    }
                }

                txtRuc.Tag = 0;
                txtEstado.Text = "PENDIENTE";
                txtTica.Text = VariablesLocales.MontoTicaConta(dtpFecha.Value.Date, cboMoneda.SelectedValue.ToString()).ToString("N3");

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
                
                opcionGrabar = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                dtpFecha.ValueChanged -= dtpFecha_ValueChanged;

                LlenarComboGrid();

                txtCodLiqui.Tag = oLiquidacion.idLiquidacion;
                txtCodLiqui.Text = oLiquidacion.codLiquidacion;
                dtpFecha.Value = oLiquidacion.Fecha;
                txtEstado.Text = oLiquidacion.desEstado;
                txtRuc.Tag = oLiquidacion.idPersona;
                txtRuc.Text = oLiquidacion.RUC;
                txtRazonSocial.Text = oLiquidacion.RazonSocial;
                cboMoneda.SelectedValue = oLiquidacion.idMoneda;
                txtImporte.Text = oLiquidacion.Importe.ToString("N2");
                txtTica.Text = oLiquidacion.TiCa.ToString("N3");
                cboDocumento.SelectedValue = oLiquidacion.idDocumento.ToString();
                txtSerie.Text = oLiquidacion.numSerie;
                txtNumero.Text = oLiquidacion.numDocumento;
                txtComprobante.Text = oLiquidacion.idComprobante;
                txtDesComprobante.Text = oLiquidacion.desComprobante;
                txtFile.Text = oLiquidacion.numFile;
                txtDesFile.Text = oLiquidacion.desFile;
                txtCodCuenta.Tag = oLiquidacion.numVerPlanCuentas;
                txtCodCuenta.Text = oLiquidacion.codCuenta;
                txtDesCuenta.Text = oLiquidacion.desCuenta;
                txtGlosa.Text = oLiquidacion.Glosa.Trim();

                if (cboMoneda.SelectedValue.ToString() == "01")
                {
                    txtDesCuenta.Text = VariablesLocales.oConParametros.desCtaLiquiSol;
                }
                else
                {
                    txtDesCuenta.Text = VariablesLocales.oConParametros.desCtaLiquiDol;
                }

                ComprobantesE Diario = (from x in VariablesLocales.oListaComprobantes where x.idComprobante == txtComprobante.Text select x).SingleOrDefault();
                txtDesComprobante.Text = Diario.Descripcion;
                txtDesFile.Text = (from x in Diario.ListaComprobantesFiles where x.idComprobante == txtComprobante.Text && x.numFile == txtFile.Text select x.Descripcion).SingleOrDefault();

                txtUsuRegistra.Text = oLiquidacion.UsuarioRegistro;
                txtRegistro.Text = oLiquidacion.FechaRegistro.ToString();
                txtUsuModifica.Text = oLiquidacion.UsuarioModificacion;
                txtModifica.Text = oLiquidacion.FechaModificacion.ToString();

                opcionGrabar = (Int32)EnumOpcionGrabar.Actualizar;

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            }

            bsLiquidacionDet.DataSource = oLiquidacion.oListaImportacionesDet;
            bsLiquidacionDet.ResetBindings(false);
            Calcular();

            if (oLiquidacion.Estado)
            {
                Global.MensajeComunicacion("Este registro de liquidación ha sido cerrado. No podra hacer modificaciones.");
                pnlDatos.Enabled = false;
                Bloqueo = "S";
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
            else
            {
                base.Nuevo();
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oLiquidacion != null)
                {
                    Datos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oLiquidacion = AgenteCtasPorPagar.Proxy.GrabarLiquidacionImportacion(oLiquidacion, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oLiquidacion = AgenteCtasPorPagar.Proxy.GrabarLiquidacionImportacion(oLiquidacion, EnumOpcionGrabar.Actualizar);
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

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<LiquidacionImportacionE>(oLiquidacion);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (oLiquidacion.idPersona == 0)
            {
                Global.MensajeAdvertencia("Debe ingresar un axuliar.");
                txtRuc.Focus();
                return false;
            }

            if (oLiquidacion.Importe == 0M)
            {
                Global.MensajeAdvertencia("Debe ingresar el importe de la liquidación.");
                txtImporte.Focus();
                return false;
            }

            Decimal.TryParse(txtImporte.Text, out Decimal Importe);
            Decimal.TryParse((cboMoneda.SelectedValue.ToString() == "01" ? lblMontoSoles.Text : lblMontoDolares.Text), out Decimal ImporteDet);

            if (Importe != ImporteDet)
            {
                Global.MensajeAdvertencia("Debe cuadrar los Importes antes de poder grabar o actualizar.");
                return false;
            }

            if (opcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
            {
                if (String.IsNullOrWhiteSpace(oLiquidacion.idComprobante))
                {
                    Global.MensajeAdvertencia("Falta colocar el tipo de Comprobante en los parámetros contables.");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(oLiquidacion.numFile))
                {
                    Global.MensajeAdvertencia("Falta colocar el tipo de File en los parámetros contables.");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(oLiquidacion.codCuenta))
                {
                    Global.MensajeAdvertencia("Falta colocar cuenta contable para la liquidación de importación en los parámetros contables.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                //if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                //{
                //    if (String.IsNullOrWhiteSpace(TipoCuentaLiqui))
                //    {
                //        Global.MensajeComunicacion("El auxiliar no tiene el tipo de cuenta en el Maestro de Fondo Fijo y Cuentas a Rendir");
                //        return;
                //    }
                //}
                //else
                //{
                //    if (String.IsNullOrWhiteSpace(oLiquidacion.desTipoCuentaLiq))
                //    {
                //        Global.MensajeComunicacion("El auxiliar no tiene el tipo de cuenta en el Maestro de Fondo Fijo y Cuentas a Rendir");
                //        return;
                //    }
                //}

                //List<LiquidacionDetE> oListaLiquiMovilidad = new List<LiquidacionDetE>(from x in oLiquidacion.ListaLiquidacionDet
                //                                                                       where x.tipoDocumento == 2
                //                                                                       select x).ToList();

                //frmLiquidacionDetalle oFrm = new frmLiquidacionDetalle(TipoCuentaLiqui, oListaLiquiMovilidad, TipoFondo, Bloqueo);

                //if (oFrm.ShowDialog() == DialogResult.OK)
                //{
                //    oLiquidacion.ListaLiquidacionDet.Add(oFrm.oLiquidacion);
                //    bsLiquidacionDet.DataSource = oLiquidacion.ListaLiquidacionDet;
                //    bsLiquidacionDet.ResetBindings(false);
                //    SumarColumna(oLiquidacion.ListaLiquidacionDet);
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsLiquidacionDet.Current != null)
                {
                    //if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    //{
                    //    if (((LiquidacionDetE)bsLiquidacionDet.Current).tipoDocumento == 1)
                    //    {
                    //        ProvisionesE oProvisionCompra = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    //                                                                                            VariablesLocales.SesionLocal.IdLocal,
                    //                                                                                            ((LiquidacionDetE)bsLiquidacionDet.Current).idProvision.Value, false, "N");
                    //        if (oProvisionCompra.EstadoProvision == "PR")
                    //        {
                    //            Global.MensajeComunicacion("Este documento no se puede eliminar porque ya se encuentra Provisionado.");
                    //            return;
                    //        }
                    //    }

                    //    if (oLiquidacion.ListaEliminados == null)
                    //    {
                    //        oLiquidacion.ListaEliminados = new List<LiquidacionDetE>();
                    //    }

                    //    oLiquidacion.ListaEliminados.Add((LiquidacionDetE)bsLiquidacionDet.Current);
                    //    oLiquidacion.ListaLiquidacionDet.RemoveAt(bsLiquidacionDet.Position);

                    //    bsLiquidacionDet.DataSource = oLiquidacion.ListaLiquidacionDet;
                    //    bsLiquidacionDet.ResetBindings(false);
                    //    SumarColumna(oLiquidacion.ListaLiquidacionDet);

                    //    base.QuitarDetalle();
                    //}
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmLiquidacionImportacion_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTica.Text = VariablesLocales.MontoTicaConta(dtpFecha.Value.Date, cboMoneda.SelectedValue.ToString()).ToString("N3");
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

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            txtImporte.Text = Global.FormatoDecimal(txtImporte.Text);
        }

        private void btDocumentos_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarProvisiones oFrm = new frmBuscarProvisiones("ProvLiquiImp");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvision != null)
                {
                    LlenarComboGrid();

                    if (oLiquidacion.oListaImportacionesDet.Count > 0)
                    {
                        foreach (LiquidacionImportacionDetE item in oLiquidacion.oListaImportacionesDet)
                        {
                            if (item.idProvision == oFrm.oProvision.idProvision)
                            {
                                Global.MensajeAdvertencia("La provisión ya se encuentra, elimine primero o escoja otro.");
                                return;
                            }
                        }
                    }

                    LiquidacionImportacionDetE LiquidacionDet = new LiquidacionImportacionDetE()
                    {
                        idProvision = oFrm.oProvision.idProvision,
                        idDocumento = oFrm.oProvision.idDocumento,
                        numSerie = oFrm.oProvision.NumSerie,
                        numDocumento = oFrm.oProvision.NumDocumento,
                        FechaDocumento = oFrm.oProvision.FechaDocumento.Date,
                        idMoneda = oFrm.oProvision.CodMonedaProvision,
                        desMoneda = oFrm.oProvision.desMoneda,
                        MontoDoc = oFrm.oProvision.ImpMonedaOrigen,
                        idMonedaRec = oFrm.oProvision.CodMonedaProvision,
                        desMonedaRec = oFrm.oProvision.desMoneda,
                        MontoRec = oFrm.oProvision.ImpMonedaOrigen,
                        indTicaAuto = oFrm.oProvision.IndCalcAuto,
                        TipoCambio = oFrm.oProvision.TipCambio,
                        SolesRec = oFrm.oProvision.impTotalBase,
                        DolaresRec = oFrm.oProvision.impTotalSecun,
                        idPersona = oFrm.oProvision.idPersona.Value,
                        indReparable = oFrm.oProvision.indReparable,
                        idConceptoRep = oFrm.oProvision.idConceptoRep,
                        desReferenciaRep = oFrm.oProvision.desReferenciaRep,
                        numVerPlanCuentas = oFrm.oProvision.NumVerPlanCuentas,
                        codCuenta = oFrm.oProvision.codCuenta,
                        EsAutomatico = true,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy,

                        Opcion = (Int32)EnumOpcionGrabar.Insertar,
                        RazonSocial = oFrm.oProvision.RazonSocial,
                    };

                    oLiquidacion.oListaImportacionesDet.Add(LiquidacionDet);
                    bsLiquidacionDet.DataSource = oLiquidacion.oListaImportacionesDet;
                    bsLiquidacionDet.ResetBindings(false);

                    Calcular();
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAgregarOtros_Click(object sender, EventArgs e)
        {
            try
            {
                frmLiquidacionImportacionDetalle oFrm = new frmLiquidacionImportacionDetalle(cboMoneda.SelectedValue.ToString());

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oLiquidacionDet != null)
                {
                    LiquidacionImportacionDetE oItemRendicion = Colecciones.CopiarEntidad<LiquidacionImportacionDetE>(oFrm.oLiquidacionDet);
                    oLiquidacion.oListaImportacionesDet.Add(oItemRendicion);
                    bsLiquidacionDet.DataSource = oLiquidacion.oListaImportacionesDet;
                    bsLiquidacionDet.ResetBindings(false);

                    Calcular();
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLiquidacionDet.Count > 0)
                {
                    LiquidacionImportacionDetE current = (LiquidacionImportacionDetE)bsLiquidacionDet.Current;

                    if (current != null)
                    {
                        if (current.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            oLiquidacion.oListaImportacionesDet.Remove(current);
                        }
                        else
                        {
                            if (oLiquidacion.oListaImportacionesDetDel == null)
                            {
                                oLiquidacion.oListaImportacionesDetDel = new List<LiquidacionImportacionDetE>();
                            }

                            //Añadiendo a la lista de eliminados
                            oLiquidacion.oListaImportacionesDetDel.Add(current);
                            //Quitandolo de la lista principal
                            oLiquidacion.oListaImportacionesDet.Remove(current);
                        }

                        //Actualizando el source
                        bsLiquidacionDet.DataSource = oLiquidacion.oListaImportacionesDet;
                        bsLiquidacionDet.ResetBindings(false);

                        base.QuitarDetalle();
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
                if (cboMoneda.SelectedValue != null)
                {
                    txtCodCuenta.Tag = VariablesLocales.oConParametros.numVerPlanCuentas;

                    if (cboMoneda.SelectedValue.ToString() == "01")
                    {
                        txtCodCuenta.Text = VariablesLocales.oConParametros.codCtaLiquiSol;
                        txtDesCuenta.Text = VariablesLocales.oConParametros.desCtaLiquiSol;
                    }
                    else
                    {
                        txtCodCuenta.Text = VariablesLocales.oConParametros.codCtaLiquiDol;
                        txtDesCuenta.Text = VariablesLocales.oConParametros.desCtaLiquiDol;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsLiquidacionDet_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblDetalle.Text = String.Format("Detalle {0} Registros", bsLiquidacionDet.Count.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvLiquidaciones.Columns[e.ColumnIndex].Name == "idMonedaRec" || dgvLiquidaciones.Columns[e.ColumnIndex].Name == "MontoRec" || dgvLiquidaciones.Columns[e.ColumnIndex].Name == "indTicaAuto")
                {
                    e.CellStyle.BackColor = Color.LightBlue;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLiquidaciones.Columns[e.ColumnIndex].Name == "idMonedaRec")
                {
                    SendKeys.Send("{F4}");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
                {
                    dgvLiquidaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Validando la columna de porcentaje y el total para que acepte solo números
                if (dgvLiquidaciones.Columns[dgvLiquidaciones.CurrentCell.ColumnIndex].Name == "MontoRec")
                {
                    if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgvLiquidaciones.Columns[dgvLiquidaciones.CurrentCell.ColumnIndex].Name == "MontoRec")
                {
                    if (e.Control is TextBox txt)
                    {
                        txt.KeyPress -= new KeyPressEventHandler(dgvLiquidaciones_KeyPress);
                        txt.KeyPress += new KeyPressEventHandler(dgvLiquidaciones_KeyPress);
                    }
                }

                if (dgvLiquidaciones.Columns[dgvLiquidaciones.CurrentCell.ColumnIndex].Name == "idMonedaRec" && e.Control is ComboBox)
                {
                    ComboBox oCombo = e.Control as ComboBox;
                    //oCombo.SelectedIndexChanged += ColumnaComboSelectionChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Elimina el mensaje de error de la cabecera de la fila
                dgvLiquidaciones.Rows[e.RowIndex].ErrorText = String.Empty;
                bsLiquidacionDet.EndEdit();
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLiquidaciones.Columns[e.ColumnIndex].Name == "idMonedaRec" || dgvLiquidaciones.Columns[e.ColumnIndex].Name == "MontoRec")
                {
                    DataGridViewRow current = dgvLiquidaciones.CurrentRow;

                    if (((LiquidacionImportacionDetE)current.DataBoundItem).idMoneda != ((LiquidacionImportacionDetE)current.DataBoundItem).idMonedaRec)
                    {
                        if (((LiquidacionImportacionDetE)current.DataBoundItem).indTicaAuto == false)
                        {
                            if (((LiquidacionImportacionDetE)current.DataBoundItem).MontoDoc > 0 && ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec > 0)
                            {
                                if (((LiquidacionImportacionDetE)current.DataBoundItem).MontoDoc > ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec)
                                {
                                    ((LiquidacionImportacionDetE)current.DataBoundItem).TipoCambio = ((LiquidacionImportacionDetE)current.DataBoundItem).MontoDoc / ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec;
                                }
                                else
                                {
                                    ((LiquidacionImportacionDetE)current.DataBoundItem).TipoCambio = ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec / ((LiquidacionImportacionDetE)current.DataBoundItem).MontoDoc;
                                }
                            }

                            if (((LiquidacionImportacionDetE)current.DataBoundItem).idMonedaRec == "01")
                            {
                                ((LiquidacionImportacionDetE)current.DataBoundItem).SolesRec = ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec;
                                ((LiquidacionImportacionDetE)current.DataBoundItem).DolaresRec = ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec / ((LiquidacionImportacionDetE)current.DataBoundItem).TipoCambio;
                            }
                            else
                            {
                                ((LiquidacionImportacionDetE)current.DataBoundItem).DolaresRec = ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec;
                                ((LiquidacionImportacionDetE)current.DataBoundItem).SolesRec = ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec * ((LiquidacionImportacionDetE)current.DataBoundItem).TipoCambio;
                            }
                        }
                        //else
                        //{
                        //    if (((LiquidacionImportacionDetE)current.DataBoundItem).TipoCambio > 0M)
                        //    {
                        //        if (((LiquidacionImportacionDetE)current.DataBoundItem).idMoneda.ToString() == "01")
                        //        {
                        //            ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec = ((LiquidacionImportacionDetE)current.DataBoundItem).MontoDoc / ((LiquidacionImportacionDetE)current.DataBoundItem).TipoCambio;
                        //        }

                        //        if (((LiquidacionImportacionDetE)current.DataBoundItem).idMoneda.ToString() == "02")
                        //        {
                        //            ((LiquidacionImportacionDetE)current.DataBoundItem).MontoRec = ((LiquidacionImportacionDetE)current.DataBoundItem).MontoDoc * ((LiquidacionImportacionDetE)current.DataBoundItem).TipoCambio;
                        //        }
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvLiquidaciones.CurrentCell is DataGridViewCheckBoxCell)
                {
                    dgvLiquidaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (!((LiquidacionImportacionDetE)bsLiquidacionDet.Current).EsAutomatico)
                    {
                        EditarDetalle(e, ((LiquidacionImportacionDetE)bsLiquidacionDet.Current)); 
                    }
                    else
                    {
                        Global.MensajeComunicacion("Este registro es automático, debe eliminar y volver a jalarlo nuevamente.");
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
