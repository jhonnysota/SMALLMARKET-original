using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Maestros
{
    public partial class frmBancoCuenta : frmResponseBase
    {

        #region Constructores

        public frmBancoCuenta()
        {
            InitializeComponent();
            LlenarCombos();
        }

        //Edición
        public frmBancoCuenta(BancosCuentasE oItemSel, Boolean Bloq)
            :this()
        {
            oBancoCuenta = oItemSel;

            if (!Bloq)
            {
                pnlBase.Enabled = false;
                btAceptar.Enabled = false;
            }
        } 

        #endregion

        #region Variables

        public BancosCuentasE oBancoCuenta = null;
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            //Tipos de Cuenta Bancaria
            List<ParTabla> oLista = AgenteGenerales.Proxy.ListarParTablaPorNemo("CTABAN");
            ParTabla oItem = new ParTabla() { IdParTabla = 0, Nombre = Variables.Seleccione };
            oLista.Add(oItem);
            ComboHelper.RellenarCombos<ParTabla>(cboTipo, (from x in oLista orderby x.IdParTabla select x).ToList());

            ListaMoneda = null;
            oLista = null;
        } 

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oBancoCuenta != null)
            {
                cboTipo.SelectedValue = Convert.ToInt32(oBancoCuenta.tipCuenta);
                txtnumCuenta.Text = oBancoCuenta.numCuenta;
                txtCtaInter.Text = oBancoCuenta.numCuentaInter;
                cboMoneda.SelectedValue = oBancoCuenta.idMoneda.ToString();
                txtnumCheque.Text = oBancoCuenta.numCheque;
                txtforCheque.Text = oBancoCuenta.FormatoCheque;
                txtInicio.Text = oBancoCuenta.numChequeIni;
                txtFin.Text = oBancoCuenta.numChequeFin;
                chbBaja.Checked = oBancoCuenta.indBaja;
                txtcodCuenta.Text = oBancoCuenta.codCuenta;
                txtDesCuenta.Text = oBancoCuenta.desCuenta;
                chkDocumentos.Checked = oBancoCuenta.indDocumentos;

                txtUsuRegistro.Text = oBancoCuenta.UsuarioRegistro;
                txtFechaRegistro.Text = oBancoCuenta.FechaRegistro.ToString();
                txtUsuModificacion.Text = oBancoCuenta.UsuarioModificacion;
                txtFechaModificacion.Text = oBancoCuenta.FechaModificacion.ToString();
            }
            else
            {
                oBancoCuenta = new BancosCuentasE();
                oBancoCuenta.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oBancoCuenta.idLocal = VariablesLocales.SesionLocal.IdLocal;

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
        }

        public override void Aceptar()
        {
            try
            {
                // VALIDAMOS
                if (cboTipo.SelectedValue == null || Convert.ToInt32(cboTipo.SelectedValue) == 0)
                {
                    Global.MensajeComunicacion("Debe de seleccionar Tipo");
                    cboTipo.Focus();
                }

                else if (txtnumCuenta.Text.Trim().Length == 0)
                {
                    Global.MensajeComunicacion("Debe de ingresar el número de Cuenta Bancaria");
                    txtnumCuenta.Focus();
                }
                else if (txtcodCuenta.Text.Trim().Length == 0)
                {
                    Global.MensajeComunicacion("Debe de ingresar la Cuenta Contable");
                    txtcodCuenta.Focus();
                }
                else if (cboMoneda.SelectedValue == null)
                {
                    Global.MensajeComunicacion("Debe de seleccionar la Moneda");
                    cboTipo.Focus();
                }
                else
                {
                    //CARGAMOS VARIABLES
                    //oBancoCuenta.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    //oBancoCuenta.idLocal = VariablesLocales.SesionLocal.IdLocal;
                    oBancoCuenta.tipCuenta = Convert.ToInt32(cboTipo.SelectedValue);
                    oBancoCuenta.numCuenta = txtnumCuenta.Text;
                    oBancoCuenta.numCuentaInter = txtCtaInter.Text.Trim();
                    oBancoCuenta.idMoneda = cboMoneda.SelectedValue.ToString();
                    oBancoCuenta.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                    oBancoCuenta.codCuenta = txtcodCuenta.Text;
                    oBancoCuenta.numCheque = txtnumCheque.Text;
                    oBancoCuenta.numChequeIni = txtInicio.Text;
                    oBancoCuenta.numChequeFin = txtFin.Text;
                    oBancoCuenta.FormatoCheque = txtforCheque.Text;
                    oBancoCuenta.indDocumentos = chkDocumentos.Checked;
                    oBancoCuenta.indBaja = chbBaja.Checked;

                    oBancoCuenta.desTipCuenta = ((ParTabla)cboTipo.SelectedItem).Nombre;
                    oBancoCuenta.desMoneda = cboMoneda.Text;
                    oBancoCuenta.desCuenta = txtDesCuenta.Text;
                    
                    //SISTEMAS
                    oBancoCuenta.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oBancoCuenta.FechaRegistro = VariablesLocales.FechaHoy;
                    oBancoCuenta.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oBancoCuenta.FechaModificacion = VariablesLocales.FechaHoy;

                    //CERRAR
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmBancoCuenta_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void frmBancoCuenta_Shown(object sender, EventArgs e)
        {
            txtcodCuenta.Focus();
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            frmBuscarCuentas oFrm = new frmBuscarCuentas();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
            {
                txtcodCuenta.Text = oFrm.Cuentas.codCuenta;
                txtDesCuenta.Text = oFrm.Cuentas.Descripcion;
            }
        } 

        #endregion

    }
}
