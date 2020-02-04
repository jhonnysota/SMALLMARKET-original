using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;
using ControlesWinForm;
using System.Text;

namespace ClienteWinForm.Maestros
{
    public partial class frmDetalleClienteAval : frmResponseBase
    {

        #region Constructores

        public frmDetalleClienteAval()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            LlenarCombo();
        }

        public frmDetalleClienteAval(ClienteAvalE oAvalTemp)
            : this()
        {
            oClienteAval = oAvalTemp;
        }

        #endregion

        #region Variables

        public ClienteAvalE oClienteAval = null;

        #endregion Variables

        #region Procedimientos de Usuario

        void DatosPorAceptar()
        {
            oClienteAval.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            oClienteAval.nroDocumento = txtRuc.Text.Trim();
            oClienteAval.RazonSocial = txtRazonSocial.Text;
            oClienteAval.Direccion = txtDireccion.Text;
            oClienteAval.Telefonos = txtTelefonos.Text;
            oClienteAval.Email = txtEmail.Text;
            oClienteAval.EsPrincipal = chkPrincipal.Checked;

            if (oClienteAval.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oClienteAval.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oClienteAval.FechaRegistro = VariablesLocales.FechaHoy;
                oClienteAval.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oClienteAval.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oClienteAval.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oClienteAval.FechaModificacion = VariablesLocales.FechaHoy;
            }
        }

        void LlenarCombo()
        {
            List<ParTabla> oListaTipoDocumento = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("TIPDOCPER");
            ParTabla oItem = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            oListaTipoDocumento.Add(oItem);

            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoDocumento, (from x in oListaTipoDocumento
                                                                          orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oClienteAval == null)
            {
                oClienteAval = new ClienteAvalE();
                oClienteAval.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oClienteAval.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                oClienteAval.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtIdAval.Text = oClienteAval.idAval.ToString();
                cboTipoDocumento.SelectedValue = Convert.ToInt32(oClienteAval.TipoDocumento);
                txtRuc.Text = oClienteAval.nroDocumento;
                txtRazonSocial.Text = oClienteAval.RazonSocial;
                txtRuc.Text = oClienteAval.nroDocumento;
                txtDireccion.Text = oClienteAval.Direccion;
                txtTelefonos.Text = oClienteAval.Telefonos;
                txtEmail.Text = oClienteAval.Email;
                chkPrincipal.Checked = oClienteAval.EsPrincipal;

                txtUsuarioRegistro.Text = oClienteAval.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(oClienteAval.FechaRegistro);
                txtUsuarioModificacion.Text = oClienteAval.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(oClienteAval.FechaModificacion);
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (oClienteAval != null)
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

        #endregion

        #region Eventos

        private void frmDetalleClienteAval_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarRuc oFrm = new frmBuscarRuc();
                String Direccion = String.Empty;

                oFrm.Ruc = txtRuc.Text;

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
                {
                    txtRazonSocial.Text = oFrm.RazonSocial;
                    Direccion = Global.DejarSoloUnEspacio(oFrm.Direccion.Trim());
                    txtDireccion.Text = Direccion.Trim();
                    txtTelefonos.Text = oFrm.Telefonos;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (((ParTabla)cboTipoDocumento.SelectedItem).NemoTecnico == "PERRUC")
                {
                    btSunat.Enabled = true;
                    btReniec.Visible = false;
                    txtRuc.MaxLength = 11;
                    txtRuc.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                }
                else if (((ParTabla)cboTipoDocumento.SelectedItem).NemoTecnico == "PERDNI")
                {
                    btReniec.Visible = true;
                    btSunat.Enabled = false;
                    btSunat.Visible = false;
                    txtRuc.MaxLength = 8;
                    txtRuc.TextBoxEstados = SuperTextBox.EstadoValidacion.SoloNumeros;
                }
                else
                {
                    btReniec.Visible = false;
                    btSunat.Visible = true;
                    btSunat.Enabled = false;
                    txtRuc.MaxLength = 20;
                    txtRuc.TextBoxEstados = SuperTextBox.EstadoValidacion.Defecto;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btReniec_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarDni oFrm = new frmBuscarDni();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
                {
                    StringBuilder NombreCompleto = new StringBuilder();

                    txtRuc.Text = oFrm.DNI;
                    
                    NombreCompleto.Append(oFrm.Informacion.ApePaterno.Replace("�", "Ñ"));
                    NombreCompleto.Append(" ");
                    NombreCompleto.Append(oFrm.Informacion.ApeMaterno.Replace("�", "Ñ"));
                    NombreCompleto.Append(" ");
                    NombreCompleto.Append(oFrm.Informacion.Nombres.Replace("�", "Ñ"));
                    txtRazonSocial.Text = NombreCompleto.ToString();
                    NombreCompleto = null;
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
