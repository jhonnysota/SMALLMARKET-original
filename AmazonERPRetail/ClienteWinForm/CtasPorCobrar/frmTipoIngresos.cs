using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.CtasPorCobrar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.CtasPorCobrar
{
    public partial class frmTipoIngresos : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmTipoIngresos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDetalle, true);
            LlenarCombos();
        }

        //Edción
        public frmTipoIngresos(TipoIngresosE oTipoIngresos)
            :this()
        {
            oIngresos = AgenteCtasCobrar.Proxy.ObtenerTipoIngresos(oTipoIngresos.idEmpresa, oTipoIngresos.TipoCobro, "S");
            Text = "Tipo de Cobranzas(" + oTipoIngresos.TipoCobro + ")";
        } 

        #endregion

        #region Variables

        CtasPorCobrarServiceAgent AgenteCtasCobrar { get { return new CtasPorCobrarServiceAgent(); } }
        TipoIngresosE oIngresos = null;
        public Int32 opcion = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {        
            cboTipoOperacion.DataSource = Global.CargarCP();
            cboTipoOperacion.ValueMember = "id";
            cboTipoOperacion.DisplayMember = "Nombre";
       
            cboTipo.DataSource = Global.CargarSN();
            cboTipo.ValueMember = "id";
            cboTipo.DisplayMember = "Nombre";
        }

        void GuardarDatos()
        {
            oIngresos.TipoCobro = txtTipoCobro.Text;
            oIngresos.Tipo = Convert.ToString(cboTipo.SelectedValue);
            oIngresos.TipoOperacion = Convert.ToString(cboTipoOperacion.SelectedValue);
            oIngresos.Descripcion = txtDescripción.Text;
            oIngresos.SelCuenta = chkVariasCuentas.Checked ? "S" : "N";
            oIngresos.filtroCuenta = txtFilCuenta.Text;
            oIngresos.ctaSoles = txtCuentaSoles.Text.Trim();
            oIngresos.ctaDolares = txtCuentaDolares.Text.Trim();
            oIngresos.indCtaProvision = chkIndCtaProv.Checked ? "S" : "N";
            oIngresos.codCuentaSoles = txtCtaSoles.Text;
            oIngresos.codCuentaDolares =  txtCtaDolares.Text;
            oIngresos.indManipularMontos = chkManipular.Checked;
            oIngresos.indManipularMoneda = chkMonedas.Checked;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oIngresos.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oIngresos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e)
        {
            frmTipoIngresoDetalle oFrm = new frmTipoIngresoDetalle((TipoIngresosDetE)bsDetalle.Current);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oIngresoDetalle != null)
            {
                oIngresos.ListaIngresosDet[e.RowIndex] = oFrm.oIngresoDetalle;
                bsDetalle.DataSource = oIngresos.ListaIngresosDet;
                bsDetalle.ResetBindings(false);

                base.AgregarDetalle();
            }
        }

        void BloquearTxtCuentas(Boolean Bloq)
        {
            if (!Bloq)
            {
                txtFilCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtCuentaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCuentaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCuentaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtFilCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCuentaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtCuentaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCuentaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oIngresos == null)
            {
                oIngresos = new TipoIngresosE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    numVerPlanCuentas = VariablesLocales.oConParametros.numVerPlanCuentas
                };

                txtTipoCobro.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtTipoCobro.Focus();
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
                txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
                txtCuentaSoles.TextChanged -= txtCuentaSoles_TextChanged;
                txtDesCuentaSoles.TextChanged -= txtDesCuentaSoles_TextChanged;
                txtCuentaDolares.TextChanged -= txtCuentaDolares_TextChanged;
                txtDesCuentaDolares.TextChanged -= txtDesCuentaDolares_TextChanged;
                chkVariasCuentas.CheckedChanged -= chkVariasCuentas_CheckedChanged;

                txtTipoCobro.Text = oIngresos.TipoCobro;
                cboTipo.SelectedValue = oIngresos.Tipo;
                cboTipoOperacion.SelectedValue = oIngresos.TipoOperacion;
                txtDescripción.Text = oIngresos.Descripcion;
                chkVariasCuentas.Checked = oIngresos.SelCuenta == "S" ? true : false;
                txtFilCuenta.Text = oIngresos.filtroCuenta;
                txtCuentaSoles.Text = oIngresos.ctaSoles;
                txtDesCuentaSoles.Text = oIngresos.desCtaSoles;
                txtCuentaDolares.Text = oIngresos.ctaDolares;
                txtDesCuentaDolares.Text = oIngresos.desCtaDolar;
                chkIndCtaProv.Checked = oIngresos.indCtaProvision == "S" ? true : false;
                txtCtaSoles.Text = oIngresos.codCuentaSoles;
                txtDesCtaSoles.Text = oIngresos.desCtaProvSoles;
                txtCtaDolares.Text = oIngresos.codCuentaDolares;
                txtDesCtaDolares.Text = oIngresos.desCtaProvDolar;
                chkManipular.Checked = oIngresos.indManipularMontos;
                chkMonedas.Checked = oIngresos.indManipularMoneda;

                txtUsuarioRegistro.Text = oIngresos.UsuarioRegistro;
                txtFechaRegistro.Text = oIngresos.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oIngresos.UsuarioModificacion;
                txtFechaModificacion.Text = oIngresos.FechaModificacion.ToString();

                BloquearTxtCuentas(chkVariasCuentas.Checked);

                txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                txtCuentaSoles.TextChanged += txtCuentaSoles_TextChanged;
                txtDesCuentaSoles.TextChanged += txtDesCuentaSoles_TextChanged;
                txtCuentaDolares.TextChanged += txtCuentaDolares_TextChanged;
                txtDesCuentaDolares.TextChanged += txtDesCuentaDolares_TextChanged;
                chkVariasCuentas.CheckedChanged += chkVariasCuentas_CheckedChanged;

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsDetalle.DataSource = oIngresos.ListaIngresosDet;
            bsDetalle.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oIngresos != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oIngresos = AgenteCtasCobrar.Proxy.GrabarTipoIngresos(oIngresos, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oIngresos = AgenteCtasCobrar.Proxy.GrabarTipoIngresos(oIngresos, EnumOpcionGrabar.Actualizar);
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

        public override Boolean ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<TipoIngresosE>(oIngresos);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            List<TipoIngresosE> ListaTipoCIngresos = (from x in AgenteCtasCobrar.Proxy.ListarTipoIngresos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa)
                                                      where x.TipoCobro != txtTipoCobro.Text.Trim() select x).ToList();

            foreach (TipoIngresosE item in ListaTipoCIngresos)
            {
                if (txtTipoCobro.Text == item.TipoCobro)
                {
                    Global.MensajeComunicacion("Tipo de Cobro Existente");
                    return false;
                }
            }

            if (chkIndCtaProv.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtCtaSoles.Text.Trim()) || String.IsNullOrWhiteSpace(txtCtaDolares.Text.Trim()))
                {
                    Global.MensajeComunicacion("El check de Cta. Provisión esta habilitado, debe colocar las cuentas respectivas.");
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(txtTipoCobro.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar el código.");
                txtTipoCobro.Focus();
                return false;
            }

            if (!chkVariasCuentas.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtCuentaSoles.Text))
                {
                    Global.MensajeComunicacion("Falta ingresar una cuenta en Soles.");
                    txtCuentaSoles.Focus();
                    return false;
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtDesCuentaSoles.Text))
                    {
                        Global.MensajeComunicacion("La cuenta en soles ingresada no existe.");
                        txtCuentaSoles.Focus();
                        return false;
                    }
                }

                if (String.IsNullOrWhiteSpace(txtCuentaDolares.Text))
                {
                    Global.MensajeComunicacion("Falta ingresar una cuenta en dólares.");
                    txtCuentaDolares.Focus();
                    return false;
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtDesCuentaDolares.Text))
                    {
                        Global.MensajeComunicacion("La cuenta en dólares ingresada no existe.");
                        txtCuentaDolares.Focus();
                        return false;
                    }
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(txtFilCuenta.Text.Trim()))
                {
                    Global.MensajeComunicacion("Falta colocar algún indicio de la Cuenta de Destino.");
                    txtFilCuenta.Focus();
                    return false;
                }

                List<PlanCuentasE> oListaPlanCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                        VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                        txtFilCuenta.Text.Trim(), Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                if (oListaPlanCuentas.Count == 0)
                {
                    Global.MensajeComunicacion("No existe ningúna cuenta con el indicio colocado.");
                    txtFilCuenta.Focus();
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                frmTipoIngresoDetalle oFrm = new frmTipoIngresoDetalle(txtTipoCobro.Text.Trim(), txtDescripción.Text.Trim());

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    if (oFrm.oIngresoDetalle != null)
                    {
                        oIngresos.ListaIngresosDet.Add(oFrm.oIngresoDetalle);
                        bsDetalle.DataSource = oIngresos.ListaIngresosDet;
                        bsDetalle.ResetBindings(false);
                    }

                    if (oFrm.ListaIngresosDetalle != null && oFrm.ListaIngresosDetalle.Count > 0)
                    {
                        foreach (TipoIngresosDetE item in oFrm.ListaIngresosDetalle)
                        {
                            oIngresos.ListaIngresosDet.Add(item);
                        }

                        bsDetalle.DataSource = oIngresos.ListaIngresosDet;
                        bsDetalle.ResetBindings(false);
                    }

                    base.AgregarDetalle(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsDetalle.Current != null)
                {
                    TipoIngresosDetE current = (TipoIngresosDetE)bsDetalle.Current;

                    if (!String.IsNullOrWhiteSpace(current.TipoCobro))
                    {
                        if (oIngresos.ListaEliminados == null)
                        {
                            oIngresos.ListaEliminados = new List<TipoIngresosDetE>();
                        }

                        oIngresos.ListaEliminados.Add((TipoIngresosDetE)bsDetalle.Current);
                        oIngresos.ListaIngresosDet.RemoveAt(bsDetalle.Position);
                        bsDetalle.DataSource = oIngresos.ListaIngresosDet;
                        bsDetalle.ResetBindings(false);

                        base.QuitarDetalle();  
                    }
                    else
                    {
                        oIngresos.ListaIngresosDet.RemoveAt(bsDetalle.Position);
                        bsDetalle.DataSource = oIngresos.ListaIngresosDet;
                        bsDetalle.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmTipoIngresos_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            txtFilCuenta.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
            txtCtaSoles.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
            txtCtaDolares.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
        }

        private void txtDesCtaSoles_TextChanged(object sender, EventArgs e)
        {
            txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
            txtCtaSoles.Text = String.Empty;
            txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
        }

        private void txtCtaSoles_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
            txtDesCtaSoles.Text = String.Empty;
            txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
        }

        private void txtDesCtaDolares_TextChanged(object sender, EventArgs e)
        {
            txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
            txtCtaDolares.Text = String.Empty;
            txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
        }

        private void txtCtaDolares_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
            txtDesCtaDolares.Text = String.Empty;
            txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
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
                            oIngresos.numVerPlanCuentas = oFrm.oCuenta.numVerPlanCuentas;
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
                        oIngresos.numVerPlanCuentas = oListaCuentas[0].numVerPlanCuentas;
                        txtCtaSoles.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        oIngresos.numVerPlanCuentas = String.Empty;
                        txtCtaSoles.Text = String.Empty;
                        txtDesCtaSoles.Text = String.Empty;
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

        private void txtCtaSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtaSoles.Text.Trim()) && string.IsNullOrEmpty(txtDesCtaSoles.Text.Trim()))
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
                            oIngresos.numVerPlanCuentas = oFrm.oCuenta.numVerPlanCuentas;
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
                        oIngresos.numVerPlanCuentas = oListaCuentas[0].numVerPlanCuentas;
                        txtCtaSoles.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        oIngresos.numVerPlanCuentas = String.Empty;
                        txtCtaSoles.Text = String.Empty;
                        txtDesCtaSoles.Text = String.Empty;
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

        private void txtDesCtaDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDolares.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaDolares.Text.Trim()))
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
                            oIngresos.numVerPlanCuentas = oFrm.oCuenta.numVerPlanCuentas;
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
                        oIngresos.numVerPlanCuentas = oListaCuentas[0].numVerPlanCuentas;
                        txtCtaDolares.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        oIngresos.numVerPlanCuentas = String.Empty;
                        txtCtaDolares.Text = String.Empty;
                        txtDesCtaDolares.Text = String.Empty;
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

        private void txtCtaDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDolares.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaDolares.Text.Trim()))
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
                            oIngresos.numVerPlanCuentas = oFrm.oCuenta.numVerPlanCuentas;
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
                        oIngresos.numVerPlanCuentas = oListaCuentas[0].numVerPlanCuentas;
                        txtCtaDolares.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        oIngresos.numVerPlanCuentas = String.Empty;
                        txtCtaDolares.Text = String.Empty;
                        txtDesCtaDolares.Text = String.Empty;
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

        private void chkIndCtaProv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIndCtaProv.Checked)
                {
                    txtCtaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtDesCtaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtCtaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtDesCtaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
                else
                {
                    txtCtaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtDesCtaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtCtaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtDesCtaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkVariasCuentas_CheckedChanged(object sender, EventArgs e)
        {
            BloquearTxtCuentas(chkVariasCuentas.Checked);
            //if (!chkVariasCuentas.Checked)
            //{
            //    txtFilCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            //    txtCuentaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            //    txtDesCuentaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            //    txtCuentaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            //    txtDesCuentaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            //}
            //else
            //{
            //    txtFilCuenta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            //    txtCuentaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            //    txtDesCuentaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //    txtCuentaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            //    txtDesCuentaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //}
        }

        private void bsDetalle_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsDetalle.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bsDetalle.Current != null)
                {
                    EditarDetalle(e); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCuentaSoles_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaSoles.Text = String.Empty;
        }

        private void txtDesCuentaSoles_TextChanged(object sender, EventArgs e)
        {
            txtCuentaSoles.Text = String.Empty;
        }

        private void txtCuentaSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCuentaSoles.Text.Trim()) && string.IsNullOrEmpty(txtDesCuentaSoles.Text.Trim()))
                {
                    txtCuentaSoles.TextChanged -= txtCuentaSoles_TextChanged;
                    txtDesCuentaSoles.TextChanged -= txtDesCuentaSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCuentaSoles.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            oIngresos.numVerPlanCuentas = oFrm.oCuenta.numVerPlanCuentas;
                            txtCuentaSoles.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaSoles.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        oIngresos.numVerPlanCuentas = oListaCuentas[0].numVerPlanCuentas;
                        txtCuentaSoles.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        oIngresos.numVerPlanCuentas = String.Empty;
                        txtCuentaSoles.Text = String.Empty;
                        txtDesCuentaSoles.Text = String.Empty;
                    }

                    txtCuentaSoles.TextChanged += txtCuentaSoles_TextChanged;
                    txtDesCuentaSoles.TextChanged += txtDesCuentaSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCuentaSoles.TextChanged += txtCuentaSoles_TextChanged;
                txtDesCuentaSoles.TextChanged += txtDesCuentaSoles_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaSoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCuentaSoles.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaSoles.Text.Trim()))
                {
                    txtCuentaSoles.TextChanged -= txtCuentaSoles_TextChanged;
                    txtDesCuentaSoles.TextChanged -= txtDesCuentaSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaSoles.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            oIngresos.numVerPlanCuentas = oFrm.oCuenta.numVerPlanCuentas;
                            txtCuentaSoles.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCuentaSoles.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        oIngresos.numVerPlanCuentas = oListaCuentas[0].numVerPlanCuentas;
                        txtCuentaSoles.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        oIngresos.numVerPlanCuentas = String.Empty;
                        txtCuentaSoles.Text = String.Empty;
                        txtDesCuentaSoles.Text = String.Empty;
                    }

                    txtCuentaSoles.TextChanged += txtCuentaSoles_TextChanged;
                    txtDesCuentaSoles.TextChanged += txtDesCuentaSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCuentaSoles.TextChanged += txtCuentaSoles_TextChanged;
                txtDesCuentaSoles.TextChanged += txtDesCuentaSoles_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCuentaDolares_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaDolares.Text = String.Empty;
        }

        private void txtDesCuentaDolares_TextChanged(object sender, EventArgs e)
        {
            txtCuentaDolares.Text = String.Empty;
        }

        private void txtCuentaDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCuentaDolares.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentaDolares.Text.Trim()))
                {
                    txtCuentaDolares.TextChanged -= txtCuentaDolares_TextChanged;
                    txtDesCuentaDolares.TextChanged -= txtDesCuentaDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCuentaDolares.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            oIngresos.numVerPlanCuentas = oFrm.oCuenta.numVerPlanCuentas;
                            txtCuentaDolares.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaDolares.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        oIngresos.numVerPlanCuentas = oListaCuentas[0].numVerPlanCuentas;
                        txtCuentaDolares.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        oIngresos.numVerPlanCuentas = String.Empty;
                        txtCuentaDolares.Text = String.Empty;
                        txtDesCuentaDolares.Text = String.Empty;
                    }

                    txtCuentaDolares.TextChanged += txtCuentaDolares_TextChanged;
                    txtDesCuentaDolares.TextChanged += txtDesCuentaDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCuentaDolares.TextChanged += txtCuentaDolares_TextChanged;
                txtDesCuentaDolares.TextChanged += txtDesCuentaDolares_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaDolares_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCuentaDolares.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaDolares.Text.Trim()))
                {
                    txtCuentaDolares.TextChanged -= txtCuentaDolares_TextChanged;
                    txtDesCuentaDolares.TextChanged -= txtDesCuentaDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaDolares.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            oIngresos.numVerPlanCuentas = oFrm.oCuenta.numVerPlanCuentas;
                            txtCuentaDolares.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDolares.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        oIngresos.numVerPlanCuentas = oListaCuentas[0].numVerPlanCuentas;
                        txtCuentaDolares.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        oIngresos.numVerPlanCuentas = String.Empty;
                        txtCuentaDolares.Text = String.Empty;
                        txtDesCuentaDolares.Text = String.Empty;
                    }

                    txtCuentaDolares.TextChanged += txtCuentaDolares_TextChanged;
                    txtDesCuentaDolares.TextChanged += txtDesCuentaDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCuentaDolares.TextChanged += txtCuentaDolares_TextChanged;
                txtDesCuentaDolares.TextChanged += txtDesCuentaDolares_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
