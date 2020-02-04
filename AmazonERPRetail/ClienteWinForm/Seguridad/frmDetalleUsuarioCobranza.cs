using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Seguridad
{
    public partial class frmDetalleUsuarioCobranza : frmResponseBase
    {
        
        #region Constructores

        public frmDetalleUsuarioCobranza()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarTipoPlanilla();
        }

        public frmDetalleUsuarioCobranza(List<AsignarTipoCobranzaE> oListaTemp, Int32 idEmpresa, String nomEmpresa, Int32 idLocal, String nomLocal, Int32 idUsuario, String Usuario_)
            : this()
        {
            txtIdEmpresa.Text = idEmpresa.ToString();
            txtDesEmpresa.Text = nomEmpresa;
            txtIdLocal.Text = idLocal.ToString();
            txtNombreLocal.Text = nomLocal;
            txtIdUsuario.Text = idUsuario.ToString();
            txtNomUsuario.Text = Usuario_;

            oListaValidar = oListaTemp;
        }

        public frmDetalleUsuarioCobranza(List<AsignarTipoCobranzaE> oListaTemp, AsignarTipoCobranzaE TipoCobranza)
            : this()
        {
            oTipoCobranza = TipoCobranza;
            oListaValidar = oListaTemp;
        } 

        #endregion

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public AsignarTipoCobranzaE oTipoCobranza = null;
        List<AsignarTipoCobranzaE> oListaValidar = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarTipoPlanilla()
        {
            List<ParTabla> TipoPlanilla = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPPLACO");
            ComboHelper.LlenarCombos<ParTabla>(cboTipoCobranza, TipoPlanilla);
            TipoPlanilla = null;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oTipoCobranza == null)
                {
                    oTipoCobranza = new AsignarTipoCobranzaE();

                    oTipoCobranza.idEmpresa = Convert.ToInt32(txtIdEmpresa.Text);
                    oTipoCobranza.nomEmpresa = txtDesEmpresa.Text;
                    oTipoCobranza.idLocal = Convert.ToInt32(txtIdLocal.Text);
                    oTipoCobranza.nomLocal = txtNombreLocal.Text;
                    oTipoCobranza.idUsuario = Convert.ToInt32(txtIdUsuario.Text);
                    oTipoCobranza.nomUsuario = txtNomUsuario.Text;

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();

                    oTipoCobranza.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    txtIdEmpresa.Text = oTipoCobranza.idEmpresa.ToString();
                    txtDesEmpresa.Text = oTipoCobranza.nomEmpresa;
                    txtIdLocal.Text = oTipoCobranza.idLocal.ToString();
                    txtNombreLocal.Text = oTipoCobranza.nomLocal;
                    txtIdUsuario.Text = oTipoCobranza.idUsuario.ToString();
                    txtNomUsuario.Text = oTipoCobranza.nomUsuario;
                    cboTipoCobranza.SelectedValue = Convert.ToInt32(oTipoCobranza.idTipoPlanilla);
                    chkAbrir.Checked = oTipoCobranza.AbrirPlanilla;
                    chkCerrar.Checked = oTipoCobranza.CerrarPlanilla;

                    txtUsuarioRegistro.Text = oTipoCobranza.UsuarioRegistro;
                    txtFechaRegistro.Text = oTipoCobranza.FechaRegistro.ToString();
                    txtUsuarioMod.Text = oTipoCobranza.UsuarioModificacion;
                    txtFechaModifica.Text = oTipoCobranza.FechaModificacion.ToString();

                    oTipoCobranza.idTipoPlanillaAnte = oTipoCobranza.idTipoPlanilla; //Para poder actualizar esta llave principal
                    oTipoCobranza.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Aceptar()
        {
            try
            {
                oTipoCobranza.idTipoPlanilla = Convert.ToInt32(cboTipoCobranza.SelectedValue);
                oTipoCobranza.desTipoPlanilla = ((ParTabla)cboTipoCobranza.SelectedItem).Nombre;
                oTipoCobranza.AbrirPlanilla = chkAbrir.Checked;
                oTipoCobranza.CerrarPlanilla = chkCerrar.Checked;

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (oTipoCobranza.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oTipoCobranza.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                    if (Global.MensajeConfirmacion("Desea agregar este registro.") == DialogResult.Yes)
                    {
                        oTipoCobranza = AgenteSeguridad.Proxy.InsertarAsignarTipoCobranza(oTipoCobranza);
                        base.Aceptar();
                    }
                }
                else
                {
                    oTipoCobranza.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                    if (Global.MensajeConfirmacion("Desea actualizar el registro.") == DialogResult.Yes)
                    {
                        oTipoCobranza = AgenteSeguridad.Proxy.ActualizarAsignarTipoCobranza(oTipoCobranza);
                        base.Aceptar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (oListaValidar != null && oListaValidar.Count > 0)
            {
                if (oTipoCobranza.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    foreach (AsignarTipoCobranzaE item in oListaValidar)
                    {
                        if (item.idEmpresa == oTipoCobranza.idEmpresa && item.idLocal == oTipoCobranza.idLocal && item.idUsuario == oTipoCobranza.idUsuario && item.idTipoPlanilla == oTipoCobranza.idTipoPlanilla)
                        {
                            Global.MensajeFault("Esta planilla de cobranza ya ha sido agregada escoja otra.");
                            return false;
                        }
                    } 
                }
                else
                {
                    if (oTipoCobranza.idTipoPlanilla != oTipoCobranza.idTipoPlanillaAnte)
                    {
                        foreach (AsignarTipoCobranzaE item in oListaValidar)
                        {
                            if (item.idEmpresa == oTipoCobranza.idEmpresa && item.idLocal == oTipoCobranza.idLocal && item.idUsuario == oTipoCobranza.idUsuario && item.idTipoPlanilla == oTipoCobranza.idTipoPlanilla)
                            {
                                Global.MensajeFault("Esta planilla de cobranza ya ha sido agregada escoja otra o Presione Cancelar");
                                return false;
                            }
                        }
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmDetalleUsuarioCobranza_Load(object sender, EventArgs e)
        {
            Nuevo();
        } 

        #endregion

    }
}
