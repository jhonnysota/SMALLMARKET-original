using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmDetalleLetra : frmResponseBase
    {

        #region Constructores

        public frmDetalleLetra()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            LlenarCombos();
        }

        //Nuevo Canje
        public frmDetalleLetra(Int32 idCliente, String Ruc, String RazonSocial, String Monto, DateTime fecProceso, String idMoneda, LetrasE oLetraTemp = null)
            :this()
        {
            Persona oPersona = AgenteMaestro.Proxy.RecuperarPersonaPorID(Convert.ToInt32(idCliente), VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "S");
            txtIdCliente.Text = oPersona.IdPersona.ToString();
            txtRuc.Text = oPersona.RUC;
            txtRazonSocial.Text = oPersona.RazonSocial;
            txtGiradoA.Text = oPersona.RazonSocial;
            txtDireccionCliente.Text = oPersona.DireccionCompleta;
            txtTelefonoCliente.Text = oPersona.Telefonos;
            dtpFecha.Value = fecProceso;
            txtMonto.Text = Monto;
            cboMoneda.SelectedValue = idMoneda;

            if (oPersona.oListaAvales != null && oPersona.oListaAvales.Count > Variables.Cero)
            {
                ClienteAvalE oClienteAval = (from x in oPersona.oListaAvales
                                             where x.EsPrincipal == true
                                             select x).SingleOrDefault();

                if (oClienteAval != null)
                {
                    txtNombresAval.Text = oClienteAval.RazonSocial;
                    txtDireccionAval.Text = oClienteAval.Direccion;
                    txtNroDocAval.Text = oClienteAval.nroDocumento;
                    txtTelefonoAval.Text = oClienteAval.Telefonos;
                }
            }

            if (oLetraTemp != null)
            {
                oLetra = oLetraTemp;
            }
        }

        //Nueva Renovación automática
        public frmDetalleLetra(LetrasE oLetraTemp, String Automatica)
            :this()
        {
            if (oLetraTemp != null)
            {
                oLetra = oLetraTemp;
            }

            RenovacionAutomatica = Automatica;
        }

        //Edicion
        public frmDetalleLetra(LetrasE oLetraTemp)
            :this()
        {
            oLetra = oLetraTemp;

            if (oLetra.Estado == "A")
            {
                pnlBase.Enabled = false;
                btAceptar.Enabled = false;
            }
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public LetrasE oLetra = null;
        Int32 Opcion = Variables.Cero;
        String RenovacionAutomatica = "N";

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            cboTipoCanje.DataSource = Global.CargarTipoCanje();
            cboTipoCanje.ValueMember = "id";
            cboTipoCanje.DisplayMember = "Nombre";

            List<UbigeoE> oListaPlazas = AgenteVentas.Proxy.ListarPlazas();
            oListaPlazas.Add(new UbigeoE() { idUbigeo = "0", Departamento = "<Escoger Plaza>" });
            ComboHelper.LlenarCombos<UbigeoE>(cboDepartamento, (from x in oListaPlazas orderby x.idUbigeo select x).ToList(), "idUbigeo", "Departamento");

            ComboHelper.LlenarCombos<MonedasE>(cboMoneda, ((from x in VariablesLocales.ListaMonedas
                                                            where x.idMoneda == "01" || x.idMoneda == "02"
                                                            select x).ToList()), "idMoneda", "desAbreviatura");

            cboEstado.DataSource = Global.CargarEstadoCanje();
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "Nombre";
        }

        void DatosPorAceptar()
        {
            oLetra.tipCanje = cboTipoCanje.SelectedValue.ToString();
            oLetra.Numero = txtNumero.Text.Trim();
            oLetra.Corre = txtCorre.Text;
            oLetra.Letra = String.IsNullOrWhiteSpace(txtNumero.Text.Trim()) ? String.Empty : txtNumero.Text.Trim() + "-" + txtCorre.Text;
            oLetra.Fecha = dtpFecha.Value.Date;
            oLetra.FechaVenc = dtpFecVenc.Value.Date;
            oLetra.idMoneda = cboMoneda.SelectedValue.ToString();
            oLetra.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;

            if (oLetra.idMoneda == Variables.Soles)
            {
                oLetra.MontoOrigen = Convert.ToDecimal(txtMonto.Text);
                oLetra.MontoRefe = Convert.ToDecimal(Convert.ToDecimal(txtMonto.Text) / Convert.ToDecimal(txtTica.Text));
                oLetra.MontoSoles = oLetra.MontoOrigen;
                oLetra.MontoDolares = oLetra.MontoRefe;
            }
            else
            {
                oLetra.MontoOrigen = Convert.ToDecimal(txtMonto.Text); 
                oLetra.MontoRefe = Convert.ToDecimal(Convert.ToDecimal(txtMonto.Text) * Convert.ToDecimal(txtTica.Text));
                oLetra.MontoDolares = oLetra.MontoOrigen;
                oLetra.MontoSoles = oLetra.MontoRefe;
            }

            oLetra.idPersona = Convert.ToInt32(txtIdCliente.Text);
            oLetra.GiradoA = txtGiradoA.Text;
            oLetra.Direccion = Global.DejarSoloUnEspacio(txtDireccionCliente.Text.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));
            oLetra.Plaza = cboDepartamento.SelectedValue.ToString();
            oLetra.Doi = txtNroDocCliente.Text;
            oLetra.Telefono = txtTelefonoCliente.Text;
            oLetra.Aval = txtNombresAval.Text;
            oLetra.DoiAval = txtNroDocAval.Text;
            oLetra.TelefAval = txtTelefonoAval.Text;
            oLetra.DireccionAval = Global.DejarSoloUnEspacio(txtDireccionAval.Text.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));
            oLetra.Representante = Global.DejarSoloUnEspacio(txtRepresentanteAval.Text.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));
            oLetra.Estado = cboEstado.SelectedValue.ToString();
            oLetra.desEstado = cboEstado.Text.ToString();
            oLetra.tipCambio = Convert.ToDecimal(txtTica.Text);
            oLetra.Observacion = Global.DejarSoloUnEspacio(txtObservacion.Text.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oLetra.UsuarioRegistro = txtUsuRegistra.Text;
                oLetra.FechaRegistro = VariablesLocales.FechaHoy;
                oLetra.UsuarioModificacion = txtUsuModifica.Text;
                oLetra.FechaModificacion = VariablesLocales.FechaHoy;
                oLetra.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                oLetra.UsuarioModificacion = txtUsuModifica.Text;
                oLetra.FechaModificacion = VariablesLocales.FechaHoy;

                if (oLetra.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oLetra.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oLetra == null)
            {
                oLetra = new LetrasE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal
                };

                txtCorre.Text = "00";
                cboDepartamento.SelectedValue = "15";
                //P=Por Aceptar A=Aceptada
                cboEstado.SelectedValue = "P";

                if (VariablesLocales.TipoCambioDelDia != null)
                {
                    txtTica.Text = VariablesLocales.TipoCambioDelDia.valVenta.ToString("N3");
                }
                else
                {
                    Global.MensajeFault("Debe ingresar el Tipo de Cambio.");
                    txtTica.Text = "0.000";
                }

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                lblTituloPrincipal.Text = "Letra (Nuevo)";
                rb30_CheckedChanged(null, null);
                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                //Si es Renovación y es la primera vez que ingresa en automático
                if (oLetra.tipCanje == "RV" && RenovacionAutomatica == "S")
                {
                    Int16 Corre = Convert.ToInt16(oLetra.Corre);

                    cboTipoCanje.SelectedValue = oLetra.tipCanje.ToString();
                    cboTipoCanje.Enabled = false;
                    txtNumero.Text = oLetra.Numero;
                    txtCorre.Text = String.Format("{0:00}", Corre + 1);
                    cboDepartamento.SelectedValue = "15";
                    //P=Por Aceptar A=Aceptada
                    cboEstado.Enabled = false;
                    cboEstado.SelectedValue = "P";

                    dtpFecha.Value = oLetra.FechaVenc;
                    cboMoneda.SelectedValue = oLetra.idMoneda;
                    txtMonto.Text = oLetra.idMoneda == Variables.Soles ? oLetra.MontoSoles.ToString("N2") : oLetra.MontoDolares.ToString("N2");
                    txtIdCliente.Text = oLetra.idPersona.ToString();
                    txtRuc.Text = oLetra.RUC;
                    txtRazonSocial.Text = oLetra.RazonSocial;
                    txtGiradoA.Text = oLetra.GiradoA;
                    txtDireccionCliente.Text = oLetra.Direccion;
                    txtNroDocCliente.Text = oLetra.Doi;
                    txtTelefonoCliente.Text = oLetra.Telefono;
                    txtNombresAval.Text = oLetra.Aval;
                    txtDireccionAval.Text = oLetra.DireccionAval;
                    txtNroDocAval.Text = oLetra.DoiAval;
                    txtTelefonoAval.Text = oLetra.TelefAval;
                    txtRepresentanteAval.Text = oLetra.Representante;
                    txtObservacion.Text = oLetra.Observacion;

                    txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                    rb30_CheckedChanged(null, null);
                    lblTituloPrincipal.Text = "Letra (Renovación Nueva)";
                }

                //Si es Renovación y quiere actualizar
                if (oLetra.tipCanje == "RV" && RenovacionAutomatica == "N")
                {
                    dtpFecha.ValueChanged -= dtpFecha_ValueChanged;

                    cboTipoCanje.Enabled = false;
                    cboTipoCanje.SelectedValue = oLetra.tipCanje;
                    txtNumero.Text = oLetra.Numero;
                    txtCorre.Text = oLetra.Corre;
                    cboDepartamento.SelectedValue = oLetra.Plaza;
                    dtpFecha.Value = oLetra.Fecha;
                    dtpFecVenc.Value = oLetra.FechaVenc;
                    cboMoneda.SelectedValue = oLetra.idMoneda;
                    txtMonto.Text = oLetra.idMoneda == Variables.Soles ? oLetra.MontoSoles.ToString("N2") : oLetra.MontoDolares.ToString("N2");
                    txtTica.Text = Convert.ToDecimal(oLetra.tipCambio).ToString("N3");
                    cboEstado.Enabled = false;
                    cboEstado.SelectedValue = oLetra.Estado;
                    txtIdCliente.Text = oLetra.idPersona.ToString();
                    txtRuc.Text = oLetra.RUC;
                    txtRazonSocial.Text = oLetra.RazonSocial;
                    txtGiradoA.Text = oLetra.GiradoA;
                    txtDireccionCliente.Text = oLetra.Direccion;
                    txtNroDocCliente.Text = oLetra.Doi;
                    txtTelefonoCliente.Text = oLetra.Telefono;
                    txtNombresAval.Text = oLetra.Aval;
                    txtDireccionAval.Text = oLetra.DireccionAval;
                    txtNroDocAval.Text = oLetra.DoiAval;
                    txtTelefonoAval.Text = oLetra.TelefAval;
                    txtRepresentanteAval.Text = oLetra.Representante;
                    txtObservacion.Text = oLetra.Observacion;

                    txtUsuRegistra.Text = oLetra.UsuarioRegistro;
                    txtRegistro.Text = oLetra.FechaRegistro.ToString();
                    txtUsuModifica.Text = oLetra.UsuarioModificacion;
                    txtModifica.Text = oLetra.FechaModificacion.ToString();

                    dtpFecha.ValueChanged += dtpFecha_ValueChanged;
                }

                if (oLetra.tipCanje == "CJ")
                {
                    dtpFecha.ValueChanged -= dtpFecha_ValueChanged;

                    cboTipoCanje.SelectedValue = oLetra.tipCanje;
                    txtNumero.Text = oLetra.Numero;
                    txtCorre.Text = oLetra.Corre;
                    cboDepartamento.SelectedValue = oLetra.Plaza;
                    dtpFecha.Value = oLetra.Fecha;
                    dtpFecVenc.Value = oLetra.FechaVenc;
                    cboMoneda.SelectedValue = oLetra.idMoneda;
                    txtMonto.Text = oLetra.idMoneda == Variables.Soles ? oLetra.MontoSoles.ToString("N2") : oLetra.MontoDolares.ToString("N2");
                    txtTica.Text = Convert.ToDecimal(oLetra.tipCambio).ToString("N3");
                    cboEstado.SelectedValue = oLetra.Estado;
                    txtIdCliente.Text = oLetra.idPersona.ToString();
                    txtRuc.Text = oLetra.RUC;
                    txtRazonSocial.Text = oLetra.RazonSocial;
                    txtGiradoA.Text = oLetra.GiradoA;
                    txtDireccionCliente.Text = oLetra.Direccion;
                    txtNroDocCliente.Text = oLetra.Doi;
                    txtTelefonoCliente.Text = oLetra.Telefono;
                    txtNombresAval.Text = oLetra.Aval;
                    txtDireccionAval.Text = oLetra.DireccionAval;
                    txtNroDocAval.Text = oLetra.DoiAval;
                    txtTelefonoAval.Text = oLetra.TelefAval;
                    txtRepresentanteAval.Text = oLetra.Representante;
                    txtObservacion.Text = oLetra.Observacion;

                    txtUsuRegistra.Text = oLetra.UsuarioRegistro;
                    txtRegistro.Text = oLetra.FechaRegistro.ToString();
                    txtUsuModifica.Text = oLetra.UsuarioModificacion;
                    txtModifica.Text = oLetra.FechaModificacion.ToString();

                    dtpFecha.ValueChanged += dtpFecha_ValueChanged;
                }

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            cboTipoCanje_SelectionChangeCommitted(new object(), new EventArgs());
            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (txtTica.Text == "0.000")
                {
                    Global.MensajeComunicacion("Falta ingresar el tipo de cambio, sino escoja otro dia que tenga.");
                    return;
                }

                if (oLetra != null)
                {
                    DatosPorAceptar();
                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmDetalleLetra_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void rb30_CheckedChanged(object sender, EventArgs e)
        {
            if (rb30.Checked)
            {
                dtpFecVenc.Value = dtpFecha.Value.AddDays(30);
            }
        }

        private void rb45_CheckedChanged(object sender, EventArgs e)
        {
            if (rb45.Checked)
            {
                dtpFecVenc.Value = dtpFecha.Value.AddDays(45);
            }
        }

        private void rb50_CheckedChanged(object sender, EventArgs e)
        {
            if (rb50.Checked)
            {
                dtpFecVenc.Value = dtpFecha.Value.AddDays(50);
            }
        }

        private void rb60_CheckedChanged(object sender, EventArgs e)
        {
            if (rb60.Checked)
            {
                dtpFecVenc.Value = dtpFecha.Value.AddDays(60);
            }
        }

        private void rb75_CheckedChanged(object sender, EventArgs e)
        {
            if (rb75.Checked)
            {
                dtpFecVenc.Value = dtpFecha.Value.AddDays(75);
            }
        }

        private void rb90_CheckedChanged(object sender, EventArgs e)
        {
            if (rb90.Checked)
            {
                dtpFecVenc.Value = dtpFecha.Value.AddDays(90);
            }
        }

        private void rb100_CheckedChanged(object sender, EventArgs e)
        {
            if (rb100.Checked)
            {
                dtpFecVenc.Value = dtpFecha.Value.AddDays(100);
            }
        }

        private void rb120_CheckedChanged(object sender, EventArgs e)
        {
            if (rb120.Checked)
            {
                dtpFecVenc.Value = dtpFecha.Value.AddDays(120);
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                txtIdCliente.Text = String.Empty;
                txtRazonSocial.Text = String.Empty;
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                txtIdCliente.Text = String.Empty;
                txtRuc.Text = String.Empty;
            }
        }

        private void cboTipoCanje_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoCanje.SelectedValue.ToString() == "CT")
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        }

        private void btBuscarAval_Click(object sender, EventArgs e)
        {

        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            txtMonto.Text = Global.FormatoDecimal(txtMonto.Text);
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TipoCambioE Tica = VariablesLocales.RetornaTipoCambio("02", dtpFecha.Value.Date);

                if (Tica != null)
                {
                    txtTica.Text = Tica.valVenta.ToString("N3");
                }
                else
                {
                    txtTica.Text = "0.000";
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
