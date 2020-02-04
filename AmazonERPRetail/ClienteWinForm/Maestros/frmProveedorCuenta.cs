using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Maestros
{
    public partial class frmProveedorCuenta : frmResponseBase
    {

        #region Constructores

        public frmProveedorCuenta()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
        }

        //Nuevo
        public frmProveedorCuenta(List<ProveedorCuentaE> oListaCtaBancarias_)
            :this()
        {
            oListaCtaBancarias = oListaCtaBancarias_;
        }

        //Editar
        public frmProveedorCuenta(ProveedorCuentaE oPrecioTemp_, List<ProveedorCuentaE> oListaCtaBancarias_)
            : this()
        {
            ProveedorCuentaItem = oPrecioTemp_;
            oListaCtaBancarias = oListaCtaBancarias_;
        } 

        #endregion

        #region Variables

        public ProveedorCuentaE ProveedorCuentaItem = null;
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ProveedorCuentaE> oListaCtaBancarias = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Moneda
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);

            List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("CTABAN");
            ComboHelper.RellenarCombos<ParTabla>(cboCuenta, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (ProveedorCuentaItem == null)
            {
                ProveedorCuentaItem = new ProveedorCuentaE();

                ProveedorCuentaItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                ProveedorCuentaItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (ProveedorCuentaItem.Opcion == 0)
                {
                    ProveedorCuentaItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtDesBanco.Text = Convert.ToString(ProveedorCuentaItem.desBanco);
                cboCuenta.SelectedValue = Convert.ToInt32(ProveedorCuentaItem.tipCuenta);
                cboMoneda.SelectedValue = ProveedorCuentaItem.idMoneda;
                txtInter.Text = ProveedorCuentaItem.numInterbancaria;
                txtNumCuenta.Text = ProveedorCuentaItem.numCuenta;
                chkBancoDefecto.Checked = ProveedorCuentaItem.BancoPorDefecto;

                if (ProveedorCuentaItem.CuentaPorDefecto == "C")
                {
                    rbCta.Checked = true;
                }
                else
                {
                    rbCtaInter.Checked = true;
                }

                txtUsuRegistra.Text = ProveedorCuentaItem.UsuarioRegistro;
                txtRegistro.Text = ProveedorCuentaItem.FechaRegistro.ToString();
                txtUsuModifica.Text = ProveedorCuentaItem.UsuarioModificacion;
                txtModifica.Text = ProveedorCuentaItem.FechaModificacion.ToString();

                if (ProveedorCuentaItem.indBaja)
                {
                    pnlBase.Enabled = false;
                    btAceptar.Enabled = false;
                }
                else
                {
                    pnlBase.Enabled = true;
                    btAceptar.Enabled = true;
                }
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (ProveedorCuentaItem != null)
                {
                    ProveedorCuentaItem.tipCuenta = Convert.ToInt32(cboCuenta.SelectedValue);
                    ProveedorCuentaItem.desTipoCuenta = ((ParTabla)cboCuenta.SelectedItem).Nombre; //Cuenta bancaria
                    ProveedorCuentaItem.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
                    ProveedorCuentaItem.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desMoneda;
                    ProveedorCuentaItem.numCuenta = txtNumCuenta.Text;
                    ProveedorCuentaItem.numInterbancaria = txtInter.Text;
                    ProveedorCuentaItem.BancoPorDefecto = chkBancoDefecto.Checked;
                    ProveedorCuentaItem.desBanco = txtDesBanco.Text.Trim();

                    // C = Cuenta Normal I = Cuenta Interbancaria
                    if (rbCta.Checked)
                    {
                        ProveedorCuentaItem.CuentaPorDefecto = "C";
                    }
                    else
                    {
                        ProveedorCuentaItem.CuentaPorDefecto = "I";
                    }

                    ProveedorCuentaItem.Opcion = ProveedorCuentaItem.Opcion;

                    if (ProveedorCuentaItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        ProveedorCuentaItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        ProveedorCuentaItem.FechaRegistro = VariablesLocales.FechaHoy;
                        ProveedorCuentaItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        ProveedorCuentaItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        ProveedorCuentaItem.UsuarioModificacion = txtUsuModifica.Text;
                        ProveedorCuentaItem.FechaModificacion = Convert.ToDateTime(txtModifica.Text);
                    }

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (chkBancoDefecto.Checked)
            {
                if (oListaCtaBancarias != null && oListaCtaBancarias.Count > 0)
                {
                    foreach (ProveedorCuentaE item in oListaCtaBancarias)
                    {
                        if ((item.BancoPorDefecto == ProveedorCuentaItem.BancoPorDefecto) && (item.idMoneda == ProveedorCuentaItem.idMoneda))
                        {
                            Global.MensajeComunicacion("Ya existe el valor por defecto para la moneda escogida.");
                            return false;
                        }
                    }
                } 
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmProveedorCuenta_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            frmBuscarBancos oFrm = new frmBuscarBancos();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oBancos != null)
            {
                ProveedorCuentaItem.idPersonaBanco = oFrm.oBancos.idPersona;
                txtDesBanco.Text = ProveedorCuentaItem.desBanco = oFrm.oBancos.SiglaComercial;
            }
        }

        private void cboCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboMoneda.SelectedValue = ((ParTabla)cboCuenta.SelectedItem).ValorCadena.ToString();
        }

        private void txtNumCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtInter_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        #endregion

    }
}
