using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmConceptosVarios : FrmMantenimientoBase
    {

        #region Constructores

        public frmConceptosVarios()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        //Nuevo
        public frmConceptosVarios(List<ParTabla> ListaTipo, Int32 tipo, Int32 idSistema_)
            :this()
        {
            oListaTipoConcepto = ListaTipo;
            TipoCombo = tipo;
            idSistema = idSistema_;
        }

        //Edición
        public frmConceptosVarios(ConceptosVariosE oConceptoTmp, List<ParTabla> oListaTipos)
            :this()
        {
            oListaTipoConcepto = oListaTipos;
            oConcepto = AgenteAlmacen.Proxy.ObtenerConceptosVarios(oConceptoTmp.idConcepto, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            Text = "Conceptos Varios (" + oConcepto.codConcepto + ")";
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        ConceptosVariosE oConcepto = null;
        Int32 TipoCombo = 0;
        List<ParTabla> oListaTipoConcepto = null;
        Int32 idSistema = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ComboHelper.LlenarCombos<ParTabla>(cboTipo, oListaTipoConcepto);

            //Detracciones
            List<TasasDetraccionesE> ListarDetracciones = AgenteGeneral.Proxy.ListarDetraccionesCabActivas();
            ListarDetracciones.Add(new TasasDetraccionesE() { idTipoDetraccion = Variables.Cero.ToString(), NombreTemp = "<<Seleccionar>>" });
            ComboHelper.LlenarCombos<TasasDetraccionesE>(cboDetracciones, (from x in ListarDetracciones orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "NombreTemp");

            ListarDetracciones = null;
        }

        void DatosGrabacion()
        {
            oConcepto.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            oConcepto.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
            oConcepto.codConcepto = txtCodConcepto.Text.Trim();
            oConcepto.Descripcion = txtDescripcion.Text.Trim();
            oConcepto.indCuentaAdm = chkIndCuenta.Checked;
            oConcepto.indCuentaVen = chkVentas.Checked;
            oConcepto.indCuentaPro = chkProduccion.Checked;
            oConcepto.indCuentaFin = chkFinanzas.Checked;
            oConcepto.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            oConcepto.indCuentasMon = chkCuentasMon.Checked;

            if (oConcepto.indCuentasMon)
            {
                oConcepto.CtaSoles = txtCtaSoles.Text;
                oConcepto.CtaDolares = txtCtaDolares.Text;
            }
            else
            {
                oConcepto.CtaSoles = String.Empty;
                oConcepto.CtaDolares = String.Empty;
            }

            oConcepto.indContraPartida = chkContraPartida.Checked;

            if (oConcepto.indContraPartida)
            {
                oConcepto.CtaContraSoles = txtCtaContraSoles.Text;
                oConcepto.CtaContraDolares = txtCtaContraDolares.Text;
            }
            else
            {
                oConcepto.CtaContraSoles = String.Empty;
                oConcepto.CtaContraDolares = String.Empty;
            }

            //Cuenta Administrativa
            if (chkIndCuenta.Checked)
            {
                oConcepto.codCuentaAdm = txtCodCuentaAdm.Text.Trim();
                oConcepto.desCuentaAdm = txtDesCuentaAdm.Text.Trim();
            }
            else
            {
                oConcepto.codCuentaAdm = String.Empty;
                oConcepto.desCuentaAdm = String.Empty;
            }

            //Cuenta Ventas
            if (chkVentas.Checked)
            {
                oConcepto.codCuentaVen = txtCodCuentaVen.Text.Trim();
                oConcepto.desCuentaVen = txtDesCuentaVen.Text.Trim();
            }
            else
            {
                oConcepto.codCuentaVen = String.Empty;
                oConcepto.desCuentaVen = String.Empty;
            }

            //Cuenta Produccion
            if (chkProduccion.Checked)
            {
                oConcepto.codCuentaPro = txtCodCuentaPro.Text.Trim();
                oConcepto.desCuentaPro = txtDesCuentaPro.Text.Trim();
            }
            else
            {
                oConcepto.codCuentaPro = String.Empty;
                oConcepto.desCuentaPro = String.Empty;
            }

            //Cuenta Finanzas
            if (chkFinanzas.Checked)
            {
                oConcepto.codCuentaFin = txtCodCuentaFin.Text.Trim();
                oConcepto.desCuentaFin = txtDesCuentaFin.Text.Trim();
            }
            else
            {
                oConcepto.codCuentaFin = String.Empty;
                oConcepto.desCuentaFin = String.Empty;
            }

            oConcepto.indConceptoLiqui = chkIndLiquidacion.Checked;

            if (rbDetraccion.Checked)
            {
                oConcepto.indDetraccion = rbDetraccion.Checked;

                if (cboDetracciones.SelectedValue != null)
                {
                    oConcepto.idTipoDetraccion = cboDetracciones.SelectedValue.ToString();
                }
                else
                {
                    oConcepto.idTipoDetraccion = "0";
                }
            }
            else
            {
                oConcepto.indDetraccion = false;
                oConcepto.idTipoDetraccion = String.Empty;
            }
            
            oConcepto.indRetencion = rbRetencion.Checked;
            oConcepto.porImpuesto = Convert.ToDecimal(txtPorcentaje.Text);
            oConcepto.ParaMovi = chkMovilidad.Checked;
            oConcepto.indTransferencia = chkTransferencia.Checked;
            oConcepto.indAnticipo = chkAnticipo.Checked;

            //Módulos
            oConcepto.indCompras = chkCompras.Checked;
            oConcepto.indTesoreria = chkTesoreria.Checked;
            oConcepto.indCobranzas = chkCobranzas.Checked;
            oConcepto.indPlanillas = chkPlanillas.Checked;

            //T=Terceros P=Personal R=Proveedor
            if (rbProveedor.Checked)
            {
                oConcepto.TipoSolicitud = "R";
            }

            if (rbTercero.Checked)
            {
                oConcepto.TipoSolicitud = "T";
            }

            if (rbPersonal.Checked)
            {
                oConcepto.TipoSolicitud = "P";
            }

            if (String.IsNullOrEmpty(txtIdConcepto.Text.Trim()))
            {
                oConcepto.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oConcepto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oConcepto == null)
            {
                oConcepto = new ConceptosVariosE();
                cboTipo.SelectedValue = TipoCombo;
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtCodCuentaAdm.TextChanged -= txtCodCuentaAdm_TextChanged;
                txtDesCuentaAdm.TextChanged -= txtDesCuentaAdm_TextChanged;
                txtCodCuentaVen.TextChanged -= txtCodCuentaVen_TextChanged;
                txtDesCuentaVen.TextChanged -= txtDesCuentaVen_TextChanged;
                txtCodCuentaPro.TextChanged -= txtCodCuentaPro_TextChanged;
                txtDesCuentaPro.TextChanged -= txtDesCuentaPro_TextChanged;
                txtCodCuentaFin.TextChanged -= txtCodCuentaFin_TextChanged;
                txtDesCuentaFin.TextChanged -= txtDesCuentaFin_TextChanged;
                txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                txtCtaDesSoles.TextChanged -= txtCtaDesSoles_TextChanged;
                txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                txtCtaDesDolares.TextChanged -= txtCtaDesDolares_TextChanged;
                txtCtaContraSoles.TextChanged -= txtCtaContraSoles_TextChanged;
                txtCtaDesContraSoles.TextChanged -= txtCtaDesContraSoles_TextChanged;
                txtCtaContraDolares.TextChanged -= txtCtaContraDolares_TextChanged;
                txtCtaDesContraDolares.TextChanged -= txtCtaDesContraDolares_TextChanged;

                txtIdConcepto.Text = oConcepto.idConcepto.ToString();
                cboTipo.SelectedValue = Convert.ToInt32(oConcepto.Tipo);
                txtCodConcepto.Text = oConcepto.codConcepto;
                txtDescripcion.Text = oConcepto.Descripcion;
                chkIndCuenta.Checked = oConcepto.indCuentaAdm;
                txtCodCuentaAdm.Text = oConcepto.codCuentaAdm;
                txtDesCuentaAdm.Text = oConcepto.desCuentaAdm;
                chkVentas.Checked = oConcepto.indCuentaVen;
                txtCodCuentaVen.Text = oConcepto.codCuentaVen;
                txtDesCuentaVen.Text = oConcepto.desCuentaVen;
                chkProduccion.Checked = oConcepto.indCuentaPro;
                txtCodCuentaPro.Text = oConcepto.codCuentaPro;
                txtDesCuentaPro.Text = oConcepto.desCuentaPro;
                chkFinanzas.Checked = oConcepto.indCuentaFin;
                txtCodCuentaFin.Text = oConcepto.codCuentaFin;
                txtDesCuentaFin.Text = oConcepto.desCuentaFin;
                chkIndLiquidacion.Checked = oConcepto.indConceptoLiqui;
                rbDetraccion.Checked = oConcepto.indDetraccion;
                cboDetracciones.SelectedValue = oConcepto.idTipoDetraccion.ToString();
                rbRetencion.Checked = oConcepto.indRetencion;
                txtPorcentaje.Text = oConcepto.porImpuesto.ToString("N2");
                chkMovilidad.Checked = oConcepto.ParaMovi;
                chkCuentasMon.Checked = oConcepto.indCuentasMon;
                chkCuentas_CheckedChanged(null, null);

                if (chkCuentasMon.Checked)
                {
                    txtCtaSoles.Text = oConcepto.CtaSoles;
                    txtCtaDesSoles.Text = oConcepto.CtaDesSoles;
                    txtCtaDolares.Text = oConcepto.CtaDolares;
                    txtCtaDesDolares.Text = oConcepto.CtaDesDolares;
                }
                else
                {
                    txtCtaSoles.Text = String.Empty;
                    txtCtaDesSoles.Text = String.Empty;
                    txtCtaDolares.Text = String.Empty;
                    txtCtaDesDolares.Text = String.Empty;
                }

                chkTransferencia.Checked = oConcepto.indTransferencia;
                chkContraPartida.Checked = oConcepto.indContraPartida;
                chkContraPartida_CheckedChanged(null, null);

                if (chkContraPartida.Checked)
                {
                    txtCtaContraSoles.Text = oConcepto.CtaContraSoles;
                    txtCtaDesContraSoles.Text = oConcepto.CtaDesContraSoles;
                    txtCtaContraDolares.Text = oConcepto.CtaContraDolares;
                    txtCtaDesContraDolares.Text = oConcepto.CtaDesContraDolares;
                }
                else
                {
                    txtCtaContraSoles.Text = String.Empty;
                    txtCtaDesContraSoles.Text = String.Empty;
                    txtCtaContraDolares.Text = String.Empty;
                    txtCtaDesContraDolares.Text = String.Empty;
                }

                chkAnticipo.Checked = oConcepto.indAnticipo;

                //Módulos
                chkCompras.Checked = oConcepto.indCompras;
                chkTesoreria.Checked = oConcepto.indTesoreria;
                chkCobranzas.Checked = oConcepto.indCobranzas;
                chkPlanillas.Checked = oConcepto.indPlanillas;

                //T = Terceros P = Personal R = Proveedor
                if (oConcepto.TipoSolicitud == "T")
                {
                    rbTercero.Checked = true;
                }

                if (oConcepto.TipoSolicitud == "P")
                {
                    rbPersonal.Checked = true;
                }

                txtUsuarioRegistro.Text = oConcepto.UsuarioRegistro;
                txtFechaRegistro.Text = oConcepto.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oConcepto.UsuarioModificacion;
                txtFechaModificacion.Text = oConcepto.FechaModificacion.ToString();

                txtCodCuentaAdm.TextChanged += txtCodCuentaAdm_TextChanged;
                txtDesCuentaAdm.TextChanged += txtDesCuentaAdm_TextChanged;
                txtCodCuentaVen.TextChanged += txtCodCuentaVen_TextChanged;
                txtDesCuentaVen.TextChanged += txtDesCuentaVen_TextChanged;
                txtCodCuentaPro.TextChanged += txtCodCuentaPro_TextChanged;
                txtDesCuentaPro.TextChanged += txtDesCuentaPro_TextChanged;
                txtCodCuentaFin.TextChanged += txtCodCuentaFin_TextChanged;
                txtDesCuentaFin.TextChanged += txtDesCuentaFin_TextChanged;
                txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                txtCtaDesSoles.TextChanged += txtCtaDesSoles_TextChanged;
                txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                txtCtaDesDolares.TextChanged += txtCtaDesDolares_TextChanged;
                txtCtaContraSoles.TextChanged += txtCtaContraSoles_TextChanged;
                txtCtaDesContraSoles.TextChanged += txtCtaDesContraSoles_TextChanged;
                txtCtaContraDolares.TextChanged += txtCtaContraDolares_TextChanged;
                txtCtaDesContraDolares.TextChanged += txtCtaDesContraDolares_TextChanged;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                DatosGrabacion();

                if (ValidarGrabacion())
                {
                    if (String.IsNullOrEmpty(txtIdConcepto.Text.Trim()))
                    {
                        if (Global.MensajeConfirmacion("Guardar datos...") == DialogResult.Yes)
                        {
                            oConcepto = AgenteAlmacen.Proxy.InsertarConceptosVarios(oConcepto);
                            Global.MensajeComunicacion("Datos guardados");
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion("Actualizar datos...") == DialogResult.Yes)
                        {
                            oConcepto = AgenteAlmacen.Proxy.ActualizarConceptosVarios(oConcepto);
                            Global.MensajeComunicacion("Datos actualizados");
                        }
                    }

                    base.Grabar();
                    DialogResult = DialogResult.OK;
                    Close(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (chkIndCuenta.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtCodCuentaAdm.Text.Trim()) || String.IsNullOrWhiteSpace(txtDesCuentaAdm.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar una cuenta de administración válida.");
                    return false;
                }
            }

            if (chkVentas.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtCodCuentaVen.Text.Trim()) || String.IsNullOrWhiteSpace(txtDesCuentaVen.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar una cuenta de ventas válida.");
                    return false;
                }
            }

            if (chkProduccion.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtCodCuentaPro.Text.Trim()) || String.IsNullOrWhiteSpace(txtDesCuentaPro.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar una cuenta de producción válida.");
                    return false;
                }
            }

            if (chkFinanzas.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtCodCuentaFin.Text.Trim()) || String.IsNullOrWhiteSpace(txtDesCuentaFin.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar una cuenta de finanzas válida.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmConceptosVarios_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                LlenarCombos();
                Nuevo();

                if (VariablesLocales.VersionPlanCuentasActual != null)
                {
                    txtCodCuentaAdm.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
                    txtCodCuentaFin.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
                    txtCodCuentaPro.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
                    txtCodCuentaVen.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
                    txtCtaSoles.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
                    txtCtaDolares.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCodCuentaAdm_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodCuentaAdm.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentaAdm.Text.Trim()))
                {
                    txtCodCuentaAdm.TextChanged -= txtCodCuentaAdm_TextChanged;
                    txtDesCuentaAdm.TextChanged -= txtDesCuentaAdm_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuentaAdm.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaAdm.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaAdm.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuentaAdm.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaAdm.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaAdm.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuentaAdm.Text = String.Empty;
                        txtDesCuentaAdm.Text = String.Empty;
                    }

                    txtCodCuentaAdm.TextChanged += txtCodCuentaAdm_TextChanged;
                    txtDesCuentaAdm.TextChanged += txtDesCuentaAdm_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaAdm_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodCuentaAdm.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaAdm.Text.Trim()))
                {
                    txtCodCuentaAdm.TextChanged -= txtCodCuentaAdm_TextChanged;
                    txtDesCuentaAdm.TextChanged -= txtDesCuentaAdm_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaAdm.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaAdm.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaAdm.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaAdm.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaAdm.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaAdm.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuentaAdm.Text = String.Empty;
                        txtDesCuentaAdm.Text = String.Empty;
                    }

                    txtCodCuentaAdm.TextChanged += txtCodCuentaAdm_TextChanged;
                    txtDesCuentaAdm.TextChanged += txtDesCuentaAdm_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodCuentaAdm_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaAdm.Text = String.Empty;
        }

        private void txtDesCuentaAdm_TextChanged(object sender, EventArgs e)
        {
            txtCodCuentaAdm.Text = String.Empty;
        }

        private void txtCodCuentaVen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodCuentaVen.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentaVen.Text.Trim()))
                {
                    txtCodCuentaVen.TextChanged -= txtCodCuentaVen_TextChanged;
                    txtDesCuentaVen.TextChanged -= txtDesCuentaVen_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuentaVen.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaVen.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaVen.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuentaVen.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaVen.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaVen.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuentaVen.Text = String.Empty;
                        txtDesCuentaVen.Text = String.Empty;
                    }

                    txtCodCuentaVen.TextChanged += txtCodCuentaVen_TextChanged;
                    txtDesCuentaVen.TextChanged += txtDesCuentaVen_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaVen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodCuentaVen.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaVen.Text.Trim()))
                {
                    txtCodCuentaVen.TextChanged -= txtCodCuentaVen_TextChanged;
                    txtDesCuentaVen.TextChanged -= txtDesCuentaVen_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaVen.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaVen.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaVen.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaVen.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaVen.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaVen.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuentaVen.Text = String.Empty;
                        txtDesCuentaVen.Text = String.Empty;
                    }

                    txtCodCuentaVen.TextChanged += txtCodCuentaVen_TextChanged;
                    txtDesCuentaVen.TextChanged += txtDesCuentaVen_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodCuentaVen_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaVen.Text = String.Empty;
        }

        private void txtDesCuentaVen_TextChanged(object sender, EventArgs e)
        {
            txtCodCuentaVen.Text = String.Empty;
        }

        private void txtCodCuentaPro_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodCuentaPro.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentaPro.Text.Trim()))
                {
                    txtCodCuentaPro.TextChanged -= txtCodCuentaPro_TextChanged;
                    txtDesCuentaPro.TextChanged -= txtDesCuentaPro_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuentaPro.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaPro.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaPro.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuentaPro.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaPro.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaPro.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuentaPro.Text = String.Empty;
                        txtDesCuentaPro.Text = String.Empty;
                    }

                    txtCodCuentaPro.TextChanged += txtCodCuentaPro_TextChanged;
                    txtDesCuentaPro.TextChanged += txtDesCuentaPro_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaPro_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodCuentaPro.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaPro.Text.Trim()))
                {
                    txtCodCuentaPro.TextChanged -= txtCodCuentaPro_TextChanged;
                    txtDesCuentaPro.TextChanged -= txtDesCuentaPro_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaPro.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaPro.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaPro.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaPro.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaPro.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaPro.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuentaPro.Text = String.Empty;
                        txtDesCuentaPro.Text = String.Empty;
                    }

                    txtCodCuentaPro.TextChanged += txtCodCuentaPro_TextChanged;
                    txtDesCuentaPro.TextChanged += txtDesCuentaPro_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaPro_TextChanged(object sender, EventArgs e)
        {
            txtCodCuentaPro.Text = String.Empty;
        }

        private void txtCodCuentaPro_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaPro.Text = String.Empty;
        }

        private void chkIndCuenta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndCuenta.Checked)
            {
                txtCodCuentaAdm.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentaAdm.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCodCuentaAdm.Focus();
            }
            else
            {
                txtCodCuentaAdm.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaAdm.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void chkVentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVentas.Checked)
            {
                txtCodCuentaVen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentaVen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCodCuentaVen.Focus();
            }
            else
            {
                txtCodCuentaVen.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaVen.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void chkProduccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProduccion.Checked)
            {
                txtCodCuentaPro.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentaPro.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCodCuentaPro.Focus();
            }
            else
            {
                txtCodCuentaPro.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaPro.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void chkFinanzas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFinanzas.Checked)
            {
                txtCodCuentaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCodCuentaFin.Focus();
            }
            else
            {
                txtCodCuentaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void txtCodCuentaFin_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaFin.Text = String.Empty;
        }

        private void txtDesCuentaFin_TextChanged(object sender, EventArgs e)
        {
            txtCodCuentaFin.Text = String.Empty;
        }

        private void txtCodCuentaFin_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodCuentaFin.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentaFin.Text.Trim()))
                {
                    txtCodCuentaFin.TextChanged -= txtCodCuentaFin_TextChanged;
                    txtDesCuentaFin.TextChanged -= txtDesCuentaFin_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuentaFin.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaFin.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaFin.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuentaFin.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaFin.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaFin.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuentaFin.Text = String.Empty;
                        txtDesCuentaFin.Text = String.Empty;
                    }

                    txtCodCuentaFin.TextChanged += txtCodCuentaFin_TextChanged;
                    txtDesCuentaFin.TextChanged += txtDesCuentaFin_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaFin_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodCuentaFin.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaFin.Text.Trim()))
                {
                    txtCodCuentaFin.TextChanged -= txtCodCuentaFin_TextChanged;
                    txtDesCuentaFin.TextChanged -= txtDesCuentaFin_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaFin.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaFin.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaFin.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaFin.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaFin.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaFin.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuentaFin.Text = String.Empty;
                        txtDesCuentaFin.Text = String.Empty;
                    }

                    txtCodCuentaFin.TextChanged += txtCodCuentaFin_TextChanged;
                    txtDesCuentaFin.TextChanged += txtDesCuentaFin_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDetraccion.Checked)
            {
                cboDetracciones.Enabled = true;
                txtPorcentaje.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtPorcentaje.Text = "0.00";
            }
            else
            {
                cboDetracciones.Enabled = false;
                cboDetracciones.SelectedValue = "0";
                txtPorcentaje.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtPorcentaje.Text = "0.00";
            }
        }

        private void chkCuentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCuentasMon.Checked)
            {
                //pnlMonedas.Enabled = true;
                txtCtaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCtaDesSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCtaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCtaDesDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                pnlProcesos.Enabled = false;
                chkIndCuenta.Checked = false;
                txtCodCuentaAdm.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaAdm.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                chkVentas.Checked = false;
                txtCodCuentaVen.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaVen.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                chkProduccion.Checked = false;
                txtCodCuentaPro.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaPro.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                chkFinanzas.Checked = false;
                txtCodCuentaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else
            {
                //pnlMonedas.Enabled = false;
                txtCtaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtCtaDesSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtCtaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtCtaDesDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                pnlProcesos.Enabled = true;
            }
        }

        private void txtCtaSoles_TextChanged(object sender, EventArgs e)
        {
            txtCtaDesSoles.Text = String.Empty;
        }

        private void txtCtaDesSoles_TextChanged(object sender, EventArgs e)
        {
            txtCtaSoles.Text = String.Empty;
        }

        private void txtCtaDolares_TextChanged(object sender, EventArgs e)
        {
            txtCtaDesDolares.Text = String.Empty;
        }

        private void txtCtaDesDolares_TextChanged(object sender, EventArgs e)
        {
            txtCtaDolares.Text = String.Empty;
        }

        private void txtCtaSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaSoles.Text.Trim()) && String.IsNullOrEmpty(txtCtaDesSoles.Text.Trim()))
                {
                    txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                    txtCtaDesSoles.TextChanged -= txtCtaDesSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaSoles.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaSoles.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaSoles.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaSoles.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaSoles.Text = String.Empty;
                        txtCtaDesSoles.Text = String.Empty;
                    }

                    txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                    txtCtaDesSoles.TextChanged += txtCtaDesSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDesSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaSoles.Text.Trim()) && !String.IsNullOrEmpty(txtCtaDesSoles.Text.Trim()))
                {
                    txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                    txtCtaDesSoles.TextChanged -= txtCtaDesSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDesSoles.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaSoles.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDesSoles.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaSoles.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaSoles.Text = String.Empty;
                        txtCtaDesSoles.Text = String.Empty;
                    }

                    txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                    txtCtaDesSoles.TextChanged += txtCtaDesSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDolares.Text.Trim()) && String.IsNullOrEmpty(txtCtaDesDolares.Text.Trim()))
                {
                    txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                    txtCtaDesDolares.TextChanged -= txtCtaDesDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDolares.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDolares.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDolares.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDolares.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDolares.Text = String.Empty;
                        txtCtaDesDolares.Text = String.Empty;
                    }

                    txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                    txtCtaDesDolares.TextChanged += txtCtaDesDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDesDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDolares.Text.Trim()) && !String.IsNullOrEmpty(txtCtaDesDolares.Text.Trim()))
                {
                    txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                    txtCtaDesDolares.TextChanged -= txtCtaDesDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDesDolares.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDolares.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDesDolares.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDolares.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDolares.Text = String.Empty;
                        txtCtaDesDolares.Text = String.Empty;
                    }

                    txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                    txtCtaDesDolares.TextChanged += txtCtaDesDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkContraPartida_CheckedChanged(object sender, EventArgs e)
        {

            if (chkContraPartida.Checked)
            {
                txtCtaContraSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCtaDesContraSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCtaContraDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCtaDesContraDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtCtaContraSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtCtaDesContraSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtCtaContraDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtCtaDesContraDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void txtCtaContraSoles_TextChanged(object sender, EventArgs e)
        {
            txtCtaDesContraSoles.Text = String.Empty;
        }

        private void txtCtaDesContraSoles_TextChanged(object sender, EventArgs e)
        {
            txtCtaContraSoles.Text = String.Empty;
        }

        private void txtCtaContraSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaContraSoles.Text.Trim()) && String.IsNullOrEmpty(txtCtaDesContraSoles.Text.Trim()))
                {
                    txtCtaContraSoles.TextChanged -= txtCtaContraSoles_TextChanged;
                    txtCtaDesContraSoles.TextChanged -= txtCtaDesContraSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaContraSoles.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaContraSoles.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesContraSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaContraSoles.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaContraSoles.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesContraSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaContraSoles.Text = String.Empty;
                        txtCtaDesContraSoles.Text = String.Empty;
                    }

                    txtCtaContraSoles.TextChanged += txtCtaContraSoles_TextChanged;
                    txtCtaDesContraSoles.TextChanged += txtCtaDesContraSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDesContraSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaContraSoles.Text.Trim()) && !String.IsNullOrEmpty(txtCtaDesContraSoles.Text.Trim()))
                {
                    txtCtaContraSoles.TextChanged -= txtCtaContraSoles_TextChanged;
                    txtCtaDesContraSoles.TextChanged -= txtCtaDesContraSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDesContraSoles.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaContraSoles.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesContraSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDesContraSoles.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaContraSoles.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesContraSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaContraSoles.Text = String.Empty;
                        txtCtaDesContraSoles.Text = String.Empty;
                    }

                    txtCtaContraSoles.TextChanged += txtCtaContraSoles_TextChanged;
                    txtCtaDesContraSoles.TextChanged += txtCtaDesSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaContraDolares_TextChanged(object sender, EventArgs e)
        {
            txtCtaDesContraDolares.Text = String.Empty;
        }

        private void txtCtaDesContraDolares_TextChanged(object sender, EventArgs e)
        {
            txtCtaContraDolares.Text = String.Empty;
        }

        private void txtCtaContraDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaContraDolares.Text.Trim()) && String.IsNullOrEmpty(txtCtaDesContraDolares.Text.Trim()))
                {
                    txtCtaContraDolares.TextChanged -= txtCtaContraDolares_TextChanged;
                    txtCtaDesContraDolares.TextChanged -= txtCtaDesContraDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaContraDolares.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaContraDolares.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesContraDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaContraDolares.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaContraDolares.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesContraDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaContraDolares.Text = String.Empty;
                        txtCtaDesContraDolares.Text = String.Empty;
                    }

                    txtCtaContraDolares.TextChanged += txtCtaContraDolares_TextChanged;
                    txtCtaDesContraDolares.TextChanged += txtCtaDesContraDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDesContraDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaContraDolares.Text.Trim()) && !String.IsNullOrEmpty(txtCtaDesContraDolares.Text.Trim()))
                {
                    txtCtaContraDolares.TextChanged -= txtCtaContraDolares_TextChanged;
                    txtCtaDesContraDolares.TextChanged -= txtCtaDesContraDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDesContraDolares.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaContraDolares.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesContraDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDesContraDolares.Text = String.Empty;
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaContraDolares.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesContraDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaContraDolares.Text = String.Empty;
                        txtCtaDesContraDolares.Text = String.Empty;
                    }

                    txtCtaContraDolares.TextChanged += txtCtaContraDolares_TextChanged;
                    txtCtaDesContraDolares.TextChanged += txtCtaDesContraDolares_TextChanged;
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
