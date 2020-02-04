using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmLetrasEstados : FrmMantenimientoBase
    {

        #region Constructores

        public frmLetrasEstados()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
        }

        public frmLetrasEstados(String idEstado)
            :this()
        {
            oEstadoLetra = AgenteVentas.Proxy.ObtenerLetrasEstadoLibroFile(idEstado, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            Text = "Estado de Letra (" + oEstadoLetra.Descripcion + ")";
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        LetrasEstadoLibroFileE oEstadoLetra = null;
        Int32 Opcion = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiario, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboDiario.SelectedValue = Variables.Cero.ToString();
        }

        void GuardarDatos()
        {
            oEstadoLetra.Estado = txtCodEstado.Text.Trim();
            oEstadoLetra.Descripcion = txtDescripción.Text;
            oEstadoLetra.idComprobante = Convert.ToString(cboDiario.SelectedValue);
            oEstadoLetra.numFile = Convert.ToString(cboFile.SelectedValue);
            
            oEstadoLetra.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            oEstadoLetra.CuentaSoles = txtCtaSoles.Text.Trim();
            oEstadoLetra.CuentaDolares = txtCtaDolares.Text.Trim();

            oEstadoLetra.indEndosar = chkEquivalencia.Checked;
            oEstadoLetra.ctaSolesEndosada = txtCtaSolEqui.Text.Trim();
            oEstadoLetra.ctaDolaresEndosada = txtCtaDolEqui.Text.Trim();

            oEstadoLetra.ctaSolesDscto = txtCtaDsctoS.Text.Trim();
            oEstadoLetra.ctaDolaresDscto = txtCtaDsctoD.Text.Trim();

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oEstadoLetra.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oEstadoLetra.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void BloquearEquivalencia()
        {
            if (chkEquivalencia.Checked)
            {
                txtCtaSolEqui.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCtaSolEqui.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCtaDolEqui.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCtaDolEqui.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtCtaSolEqui.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCtaSolEqui.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtCtaDolEqui.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCtaDolEqui.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oEstadoLetra == null)
            {
                oEstadoLetra = new LetrasEstadoLibroFileE();

                txtCodEstado.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCodEstado.Focus();

                cboDiario.SelectedValue = "0";
                cboDiario_SelectionChangeCommitted(new Object(), new EventArgs());
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
                txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
                txtCtaSolEqui.TextChanged -= txtCtaSolEqui_TextChanged;
                txtDesCtaSolEqui.TextChanged -= txtDesCtaSolEqui_TextChanged;
                txtCtaDolEqui.TextChanged -= txtCtaDolEqui_TextChanged;
                txtDesCtaDolEqui.TextChanged -= txtDesCtaDolEqui_TextChanged;
                chkEquivalencia.CheckedChanged -= chkEquivalencia_CheckedChanged;
                txtCtaDsctoS.TextChanged -= txtCtaDsctoS_TextChanged;
                txtDesCtaDsctoS.TextChanged -= txtDesCtaDsctoS_TextChanged;
                txtCtaDsctoD.TextChanged -= txtCtaDsctoD_TextChanged;
                txtDesCtaDsctoD.TextChanged -= txtDesCtaDsctoD_TextChanged;

                txtCodEstado.Text = oEstadoLetra.Estado;
                txtDescripción.Text = oEstadoLetra.Descripcion;
                cboDiario.SelectedValue = String.IsNullOrWhiteSpace(oEstadoLetra.idComprobante) ?  "0" : oEstadoLetra.idComprobante;
                cboDiario_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFile.SelectedValue = oEstadoLetra.numFile;

                txtCtaSoles.Text = oEstadoLetra.CuentaSoles;
                txtDesCtaSoles.Text = oEstadoLetra.desCuentaSoles;
                txtCtaDolares.Text = oEstadoLetra.CuentaDolares;
                txtDesCtaDolares.Text = oEstadoLetra.desCuentaDolares;

                txtCtaDsctoS.Text = oEstadoLetra.ctaSolesDscto;
                txtDesCtaDsctoS.Text = oEstadoLetra.desCtaSolesDscto;
                txtCtaDsctoD.Text = oEstadoLetra.ctaDolaresDscto;
                txtDesCtaDsctoD.Text = oEstadoLetra.desCtaDolaresDscto;

                chkEquivalencia.Checked = oEstadoLetra.indEndosar;
                BloquearEquivalencia();
                txtCtaSolEqui.Text = oEstadoLetra.ctaSolesEndosada;
                txtDesCtaSolEqui.Text = oEstadoLetra.desCtaSolesEndosada;
                txtCtaDolEqui.Text = oEstadoLetra.ctaDolaresEndosada;
                txtDesCtaDolEqui.Text = oEstadoLetra.desCtaDolaresEndosada;

                txtUsuarioRegistro.Text = oEstadoLetra.UsuarioRegistro;
                txtFechaRegistro.Text = oEstadoLetra.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oEstadoLetra.UsuarioModificacion;
                txtFechaModificacion.Text = oEstadoLetra.FechaModificacion.ToString();

                txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                txtCtaSolEqui.TextChanged += txtCtaSolEqui_TextChanged;
                txtDesCtaSolEqui.TextChanged += txtDesCtaSolEqui_TextChanged;
                txtCtaDolEqui.TextChanged += txtCtaDolEqui_TextChanged;
                txtDesCtaDolEqui.TextChanged += txtDesCtaDolEqui_TextChanged;
                chkEquivalencia.CheckedChanged += chkEquivalencia_CheckedChanged;
                txtCtaDsctoS.TextChanged += txtCtaDsctoS_TextChanged;
                txtDesCtaDsctoS.TextChanged += txtDesCtaDsctoS_TextChanged;
                txtCtaDsctoD.TextChanged += txtCtaDsctoD_TextChanged;
                txtDesCtaDsctoD.TextChanged += txtDesCtaDsctoD_TextChanged;

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oEstadoLetra != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            AgenteVentas.Proxy.InsertarLetrasEstadoLibroFile(oEstadoLetra);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            AgenteVentas.Proxy.ActualizarLetrasEstadoLibroFile(oEstadoLetra);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override Boolean ValidarGrabacion()
        {
            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                LetrasEstadoLibroFileE oLetrasEstado = AgenteVentas.Proxy.ObtenerLetrasEstadoLibroFile(txtCodEstado.Text.Trim(), VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oLetrasEstado != null)
                {
                    Global.MensajeComunicacion("Este código de Estado ya existe.");
                    txtCodEstado.Focus();
                    return false;
                } 
            }

            if (String.IsNullOrWhiteSpace(txtCodEstado.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar el código.");
                txtCodEstado.Focus();
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmLetrasEstados_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            txtCtaSoles.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
            txtCtaDolares.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
            txtCtaSolEqui.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
            txtCtaDolEqui.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
        }

        private void cboDiario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboDiario.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboDiario.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboDiario.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }

                    if (ListaFiles.Count == 2)
                    {
                        cboFile.SelectedValue = ListaFiles[0].numFile;
                    }
                    else
                    {
                        cboFile.SelectedValue = Variables.Cero.ToString();
                    }

                    ListaFiles = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCtaSoles_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
            txtDesCtaSoles.Text = String.Empty;
            txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
        }

        private void txtDesCtaSoles_TextChanged(object sender, EventArgs e)
        {
            txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
            txtCtaSoles.Text = String.Empty;
            txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
        }

        private void txtCtaSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaSoles.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaSoles.Text.Trim()))
                {
                    txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                    txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
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
                            txtDesCtaSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaSoles.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaSoles.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaSoles.Text = string.Empty;
                        txtDesCtaSoles.Text = string.Empty;
                    }

                    txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                    txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCtaSoles.Text.Trim()) && !string.IsNullOrEmpty(txtDesCtaSoles.Text.Trim()))
                {
                    txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                    txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaSoles.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaSoles.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaSoles.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaSoles.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaSoles.Text = string.Empty;
                        txtDesCtaSoles.Text = string.Empty;
                    }

                    txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                    txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDolares_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
            txtDesCtaDolares.Text = String.Empty;
            txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
        }

        private void txtDesCtaDolares_TextChanged(object sender, EventArgs e)
        {
            txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
            txtCtaDolares.Text = String.Empty;
            txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
        }

        private void txtCtaDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtaDolares.Text.Trim()) && string.IsNullOrEmpty(txtDesCtaDolares.Text.Trim()))
                {
                    txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                    txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
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
                            txtDesCtaDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDolares.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDolares.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDolares.Text = string.Empty;
                        txtDesCtaDolares.Text = string.Empty;
                    }

                    txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                    txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCtaDolares.Text.Trim()) && !string.IsNullOrEmpty(txtDesCtaDolares.Text.Trim()))
                {
                    txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                    txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaDolares.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDolares.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDolares.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDolares.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDolares.Text = string.Empty;
                        txtDesCtaDolares.Text = string.Empty;
                    }

                    txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                    txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkEquivalencia_CheckedChanged(object sender, EventArgs e)
        {
            BloquearEquivalencia();
        }

        private void txtCtaSolEqui_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaSolEqui.Text = String.Empty;
        }

        private void txtDesCtaSolEqui_TextChanged(object sender, EventArgs e)
        {
            txtCtaSolEqui.Text = String.Empty;
        }

        private void txtCtaSolEqui_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaSolEqui.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaSolEqui.Text.Trim()))
                {
                    txtCtaSolEqui.TextChanged -= txtCtaSolEqui_TextChanged;
                    txtDesCtaSolEqui.TextChanged -= txtDesCtaSolEqui_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaSolEqui.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaSolEqui.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaSolEqui.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaSolEqui.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaSolEqui.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaSolEqui.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaSolEqui.Text = String.Empty;
                        txtDesCtaSolEqui.Text = String.Empty;
                    }

                    txtCtaSolEqui.TextChanged += txtCtaSolEqui_TextChanged;
                    txtDesCtaSolEqui.TextChanged += txtDesCtaSolEqui_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaSolEqui.TextChanged += txtCtaSolEqui_TextChanged;
                txtDesCtaSolEqui.TextChanged += txtDesCtaSolEqui_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaSolEqui_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaSolEqui.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaSolEqui.Text.Trim()))
                {
                    txtCtaSolEqui.TextChanged -= txtCtaSolEqui_TextChanged;
                    txtDesCtaSolEqui.TextChanged -= txtDesCtaSolEqui_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaSolEqui.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaSolEqui.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaSolEqui.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaSolEqui.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaSolEqui.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaSolEqui.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaSolEqui.Text = string.Empty;
                        txtDesCtaSolEqui.Text = string.Empty;
                    }

                    txtCtaSolEqui.TextChanged += txtCtaSolEqui_TextChanged;
                    txtDesCtaSolEqui.TextChanged += txtDesCtaSolEqui_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaSolEqui.TextChanged += txtCtaSolEqui_TextChanged;
                txtDesCtaSolEqui.TextChanged += txtDesCtaSolEqui_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDolEqui_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDolEqui.Text = String.Empty;
        }

        private void txtDesCtaDolEqui_TextChanged(object sender, EventArgs e)
        {
            txtCtaDolEqui.Text = String.Empty;
        }

        private void txtCtaDolEqui_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDolEqui.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaDolEqui.Text.Trim()))
                {
                    txtCtaDolEqui.TextChanged -= txtCtaDolEqui_TextChanged;
                    txtDesCtaDolEqui.TextChanged -= txtDesCtaDolEqui_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDolEqui.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDolEqui.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDolEqui.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDolEqui.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDolEqui.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDolEqui.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDolEqui.Text = String.Empty;
                        txtDesCtaDolEqui.Text = String.Empty;
                    }

                    txtCtaDolEqui.TextChanged += txtCtaDolEqui_TextChanged;
                    txtDesCtaDolEqui.TextChanged += txtDesCtaDolEqui_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDolEqui.TextChanged += txtCtaDolEqui_TextChanged;
                txtDesCtaDolEqui.TextChanged += txtDesCtaDolEqui_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDolEqui_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDolEqui.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaDolEqui.Text.Trim()))
                {
                    txtCtaDolEqui.TextChanged -= txtCtaDolEqui_TextChanged;
                    txtDesCtaDolEqui.TextChanged -= txtDesCtaDolEqui_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaDolEqui.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDolEqui.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDolEqui.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDolEqui.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDolEqui.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDolEqui.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDolEqui.Text = string.Empty;
                        txtDesCtaDolEqui.Text = string.Empty;
                    }

                    txtCtaDolEqui.TextChanged += txtCtaDolEqui_TextChanged;
                    txtDesCtaDolEqui.TextChanged += txtDesCtaDolEqui_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDolEqui.TextChanged += txtCtaDolEqui_TextChanged;
                txtDesCtaDolEqui.TextChanged += txtDesCtaDolEqui_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDsctoS_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDsctoS.Text = String.Empty;
        }

        private void txtDesCtaDsctoS_TextChanged(object sender, EventArgs e)
        {
            txtCtaDsctoS.Text = String.Empty;
        }

        private void txtCtaDsctoS_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDsctoS.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaDsctoS.Text.Trim()))
                {
                    txtCtaDsctoS.TextChanged -= txtCtaDsctoS_TextChanged;
                    txtDesCtaDsctoS.TextChanged -= txtDesCtaDsctoS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDsctoS.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDsctoS.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDsctoS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDsctoS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDsctoS.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDsctoS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDsctoS.Text = String.Empty;
                        txtDesCtaDsctoS.Text = String.Empty;
                    }

                    txtCtaDsctoS.TextChanged += txtCtaDsctoS_TextChanged;
                    txtDesCtaDsctoS.TextChanged += txtDesCtaDsctoS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDsctoS.TextChanged += txtCtaDsctoS_TextChanged;
                txtDesCtaDsctoS.TextChanged += txtDesCtaDsctoS_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDsctoS_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDsctoS.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaDsctoS.Text.Trim()))
                {
                    txtCtaDsctoS.TextChanged -= txtCtaDsctoS_TextChanged;
                    txtDesCtaDsctoS.TextChanged -= txtDesCtaDsctoS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaDsctoS.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDsctoS.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDsctoS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDsctoS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDsctoS.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDsctoS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDsctoS.Text = string.Empty;
                        txtDesCtaDsctoS.Text = string.Empty;
                    }

                    txtCtaDsctoS.TextChanged += txtCtaDsctoS_TextChanged;
                    txtDesCtaDsctoS.TextChanged += txtDesCtaDsctoS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDsctoS.TextChanged += txtCtaDsctoS_TextChanged;
                txtDesCtaDsctoS.TextChanged += txtDesCtaDsctoS_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDsctoD_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDsctoD.Text = String.Empty;
        }

        private void txtDesCtaDsctoD_TextChanged(object sender, EventArgs e)
        {
            txtCtaDsctoD.Text = String.Empty;
        }

        private void txtCtaDsctoD_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDsctoD.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaDsctoD.Text.Trim()))
                {
                    txtCtaDsctoD.TextChanged -= txtCtaDsctoD_TextChanged;
                    txtDesCtaDsctoD.TextChanged -= txtDesCtaDsctoD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDsctoD.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDsctoD.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDsctoD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDsctoD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDsctoD.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDsctoD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDsctoD.Text = String.Empty;
                        txtDesCtaDsctoD.Text = String.Empty;
                    }

                    txtCtaDsctoD.TextChanged += txtCtaDsctoD_TextChanged;
                    txtDesCtaDsctoD.TextChanged += txtDesCtaDsctoD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDsctoD.TextChanged += txtCtaDsctoD_TextChanged;
                txtDesCtaDsctoD.TextChanged += txtDesCtaDsctoD_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDsctoD_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDsctoD.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaDsctoD.Text.Trim()))
                {
                    txtCtaDsctoD.TextChanged -= txtCtaDsctoD_TextChanged;
                    txtDesCtaDsctoD.TextChanged -= txtDesCtaDsctoD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaDsctoD.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDsctoD.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDsctoD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDsctoD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDsctoD.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDsctoD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDsctoD.Text = string.Empty;
                        txtDesCtaDsctoD.Text = string.Empty;
                    }

                    txtCtaDsctoD.TextChanged += txtCtaDsctoD_TextChanged;
                    txtDesCtaDsctoD.TextChanged += txtDesCtaDsctoD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaDsctoD.TextChanged += txtCtaDsctoD_TextChanged;
                txtDesCtaDsctoD.TextChanged += txtDesCtaDsctoD_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
