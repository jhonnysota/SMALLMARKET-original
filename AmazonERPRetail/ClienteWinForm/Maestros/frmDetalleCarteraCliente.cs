using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Maestros
{
    public partial class frmDetalleCarteraCliente : frmResponseBase
    {

        #region Constructores

        public frmDetalleCarteraCliente()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmDetalleCarteraCliente(String Titulo, Int32 id, List<VendedoresCarteraE> oListaTemp)
            :this()
        {
            lblTituloPrincipal.Text = "Detalle de  Clientes de " + Titulo;
            oListaClientes = oListaTemp;
            idVendedor = id;
        }

        public frmDetalleCarteraCliente(VendedoresCarteraE oDetalle_, List<VendedoresCarteraE> oListaTemp)
            : this()
        {
            oDetalleCliente = oDetalle_;
            lblTituloPrincipal.Text = "Detalle de  Clientes de " + oDetalleCliente.desVendedor;
            oListaClientes = oListaTemp;
            idVendedor = oDetalleCliente.idVendedor;
        } 

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<VendedoresCarteraE> oListaClientes = null; //Para que no repita el mismo cliente en la lista
        Int32 idVendedor = 0;
        public VendedoresCarteraE oDetalleCliente = null;

        #endregion

        #region Procedimientos de Usuario

        void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Cli)
            {
                ClienteE oCliente = new ClienteE()
                {
                    idPersona = oListaPersonasTmp[0].IdPersona,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    SiglaComercial = oListaPersonasTmp[0].RazonSocial,
                    TipoCliente = 0,
                    fecInscripcion = (Nullable<DateTime>)null,
                    fecInicioEmpresa = (Nullable<DateTime>)null,
                    tipConstitucion = 0,
                    tipRegimen = 0,
                    catCliente = 0,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                };

                AgenteMaestro.Proxy.InsertarCliente(oCliente);
            }
        }

        void QuitarEventos(String SN)
        {
            if (SN == "S")
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtCliente.TextChanged -= txtCliente_TextChanged;
            }
            else
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtCliente.TextChanged += txtCliente_TextChanged;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oDetalleCliente == null)
                {
                    oDetalleCliente = new VendedoresCarteraE();

                    oDetalleCliente.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oDetalleCliente.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
                }
                else
                {
                    if (oDetalleCliente.Opcion == 0)
                    {
                        oDetalleCliente.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                    }

                    QuitarEventos("S");

                    txtidCliente.Text = oDetalleCliente.idCliente.ToString();
                    txtRuc.Text = oDetalleCliente.RUC;
                    txtCliente.Text = oDetalleCliente.desCliente.ToString();
                    txtUsuarioRegistro.Text = oDetalleCliente.UsuarioRegistro;
                    txtFechaRegistro.Text = oDetalleCliente.FechaRegistro.ToString();
                    txtUsuarioModificacion.Text = oDetalleCliente.UsuarioModificacion;
                    txtFechaModificacion.Text = oDetalleCliente.FechaModificacion.ToString();

                    QuitarEventos("N");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Aceptar()
        {
            try
            {
                oDetalleCliente.idCliente = Convert.ToInt32(txtidCliente.Text);
                oDetalleCliente.desCliente = txtCliente.Text.Trim();
                oDetalleCliente.RUC = txtRuc.Text.Trim();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (oDetalleCliente.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                {
                    oDetalleCliente.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalleCliente.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    oDetalleCliente.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oDetalleCliente.FechaRegistro = VariablesLocales.FechaHoy;
                    oDetalleCliente.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalleCliente.FechaModificacion = VariablesLocales.FechaHoy;
                }

                base.Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (oListaClientes != null && oListaClientes.Count > 0)
            {
                foreach (VendedoresCarteraE item in oListaClientes)
                {
                    if (item.idCliente == oDetalleCliente.idCliente)
                    {
                        Global.MensajeComunicacion(String.Format("El cliente {0} ya se encuentra en la Cartera de Clientes", txtCliente.Text));
                        return false;
                    }
                }
            }

            VendedoresCarteraE oCliente = AgenteMaestro.Proxy.ObtenerCarteraPorIdCliente(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(txtidCliente.Text));

            if (oCliente != null)
            {
                if (idVendedor != oCliente.idVendedor)
                {
                    Global.MensajeComunicacion(String.Format("El cliente {0} ya se encuentra asignado al Vendedor(a) {1}", oCliente.desCliente, oCliente.desVendedor));
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmDetalleCarteraCliente_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btProveedor_Click(object sender, EventArgs e)
        {
            frmBuscarClientes oFrm = new frmBuscarClientes();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCliente != null)
            {
                QuitarEventos("S");

                txtidCliente.Text = Convert.ToString(oFrm.oCliente.idPersona);
                txtRuc.Text = oFrm.oCliente.RUC;
                txtCliente.Text = oFrm.oCliente.RazonSocial;

                QuitarEventos("N");
            }
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && string.IsNullOrEmpty(txtidCliente.Text.Trim()) && string.IsNullOrEmpty(txtCliente.Text.Trim()))
                {
                    QuitarEventos("S");

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtidCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtCliente.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtidCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtCliente.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtidCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtCliente.Text = String.Empty;
                        txtRuc.Focus();
                        return;
                    }

                    QuitarEventos("N");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtCliente.Text = String.Empty;
            txtidCliente.Text = String.Empty;
        }

        private void txtCliente_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCliente.Text.Trim()) && string.IsNullOrEmpty(txtidCliente.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    QuitarEventos("S");

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtCliente.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtidCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtCliente.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            btProveedor.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtidCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtCliente.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtidCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtCliente.Text = String.Empty;
                        txtCliente.Focus();
                    }

                    QuitarEventos("N");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            txtidCliente.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        #endregion

    }
}
