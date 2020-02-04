using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmMedioPago : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmMedioPago()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            Global.AjustarResolucion(this);
            LlenarCombos();
        }

        //Edición
        public frmMedioPago(Int32 idMedioPago, Int32 idEmpresa)
            : this()
        {
            oMedioPago = AgenteVentas.Proxy.ObtenerMedioPago(idMedioPago, idEmpresa);
            Text = "Medio de Pago " + oMedioPago.Nombre;
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MedioPagoE oMedioPago = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            cboDebeHaber.DataSource = Global.CargarDH();
            cboDebeHaber.ValueMember = "id";
            cboDebeHaber.DisplayMember = "Nombre";

            List<MonedasE> ListarMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas)
            {
                new MonedasE() { idMoneda = "0", desMoneda = Variables.Seleccione }
            };
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListarMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desMoneda", false);

            List<ParTabla> oListaMedioPago = AgenteGeneral.Proxy.ListarParTablaPorNemo("MEDPAG");
            oListaMedioPago.Add(new ParTabla() { IdParTabla = 0, Nombre = Variables.Escoger });
            ComboHelper.RellenarCombos<ParTabla>(CboMedioPago, (from x in oListaMedioPago orderby x.IdParTabla select x).ToList());
        }

        void GuardarDatos()
        {
            oMedioPago.Codigo = txtCodigo.Text;
            oMedioPago.Nombre = txtNombre.Text;
            oMedioPago.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oMedioPago.indDebeHaber = cboDebeHaber.SelectedValue.ToString();
            oMedioPago.numVerPlanCuentas = txtCodCuenta.Tag.ToString();
            oMedioPago.codCuenta = txtCodCuenta.Text;
            oMedioPago.indAuxiliar = chkAuxiliar.Checked;
            oMedioPago.idAuxiliar = oMedioPago.indAuxiliar == true ? Convert.ToInt32(txtRuc.Tag) : (int?)null;
            oMedioPago.idMedSunat = Convert.ToInt32(CboMedioPago.SelectedValue);
            oMedioPago.indPtoVta = ChkPtoVta.Checked;
            oMedioPago.indCredito = ChkCredito.Checked;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oMedioPago.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oMedioPago.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oMedioPago == null)
            {
                oMedioPago = new MedioPagoE
                {
                    indBaja = false,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                txtCodCuenta.Tag = string.Empty;
                txtRuc.Tag = 0;
                txtUsuRegistra.Text = txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = txtModifica.Text = VariablesLocales.FechaHoy.ToString();
                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazon.TextChanged -= txtRazon_TextChanged;
                txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                txtIDmediopago.Text = Convert.ToString(oMedioPago.idMedioPago);
                txtCodigo.Text = oMedioPago.Codigo;
                txtNombre.Text = oMedioPago.Nombre;
                txtCodCuenta.Tag = oMedioPago.numVerPlanCuentas;
                txtCodCuenta.Text = oMedioPago.codCuenta;
                txtDesCuenta.Text = oMedioPago.desCuenta;
                cboMoneda.SelectedValue = Convert.ToString(oMedioPago.idMoneda);
                cboDebeHaber.SelectedValue = Convert.ToString(oMedioPago.indDebeHaber);
                chkAuxiliar.Checked = oMedioPago.indAuxiliar;
                CboMedioPago.SelectedValue = oMedioPago.idMedSunat;
                ChkPtoVta.Checked = oMedioPago.indPtoVta;
                ChkCredito.Checked = oMedioPago.indCredito;

                if (chkAuxiliar.Checked)
                {
                    txtRuc.Tag = Convert.ToInt32(oMedioPago.idAuxiliar);
                    txtRuc.Text = oMedioPago.Ruc;
                    txtRazon.Text = oMedioPago.RazonSocial;
                }
                else
                {
                    txtRuc.Tag = 0;
                }

                txtUsuRegistra.Text = oMedioPago.UsuarioRegistro;
                txtRegistro.Text = oMedioPago.FechaRegistro.ToString();
                txtUsuModifica.Text = oMedioPago.UsuarioModificacion;
                txtModifica.Text = oMedioPago.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazon.TextChanged += txtRazon_TextChanged;
            }

            if (!oMedioPago.indBaja)
            {
                base.Nuevo();
            }
            else
            {
                chkBaja.Checked = oMedioPago.indBaja;
                dtpFechaBaja.Value = Convert.ToDateTime(oMedioPago.FechaBaja);
                pnlDatos.Enabled = false;
                dtpFechaBaja.Visible = true;
                chkBaja.Visible = true;
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oMedioPago != null)
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
                            oMedioPago = AgenteVentas.Proxy.InsertarMedioPago(oMedioPago);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oMedioPago = AgenteVentas.Proxy.ActualizarMedioPago(oMedioPago);
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
            String Respuesta = ValidarEntidad<MedioPagoE>(oMedioPago);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmMedioPago_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void txtCodCuenta_TextChanged(object sender, EventArgs e)
        {
            txtCodCuenta.Tag = string.Empty;
            txtDesCuenta.Text = string.Empty;
        }

        private void txtDesCuenta_TextChanged(object sender, EventArgs e)
        {
            txtCodCuenta.Tag = string.Empty;
            txtCodCuenta.Text = string.Empty;
        }

        private void txtCodCuenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuenta.Text,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.UltimoNivel.Value, 1);
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
                        txtCodCuenta.Tag = string.Empty;
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
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
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.Longitud, 2);
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
                        txtCodCuenta.Tag = string.Empty;
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
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

        private void chkAuxiliar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuxiliar.Checked)
            {
                txtRuc.Tag = 0;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtRuc.Tag = 0;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtRazon.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazon.Text = String.Empty;
        }

        private void txtRazon_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazon.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazon.TextChanged -= txtRazon_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > 1)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = Convert.ToInt32(oFrm.oPersona.IdPersona);
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazon.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazon.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = Convert.ToInt32(oListaPersonas[0].IdPersona);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazon.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazon.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazon.TextChanged += txtRazon_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazon.TextChanged += txtRazon_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazon.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazon.TextChanged -= txtRazon_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazon.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = Convert.ToInt32(oFrm.oPersona.IdPersona);
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazon.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = Convert.ToInt32(oListaPersonas[0].IdPersona);
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazon.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazon.Text = String.Empty;
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazon.TextChanged += txtRazon_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazon.TextChanged += txtRazon_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
