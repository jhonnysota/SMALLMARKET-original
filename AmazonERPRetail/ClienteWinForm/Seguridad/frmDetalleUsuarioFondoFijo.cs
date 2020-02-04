using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Seguridad
{
    public partial class frmDetalleUsuarioFondoFijo : frmResponseBase
    {

        #region Constructores

        public frmDetalleUsuarioFondoFijo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarTipoFondo();
        }

        public frmDetalleUsuarioFondoFijo(List<UsuarioFondoFijoE> oListaTemp, Int32 idEmpresa, String nomEmpresa, Int32 idUsuario, String Usuario_)
            :this()
        {
            txtIdEmpresa.Text = idEmpresa.ToString();
            txtDesEmpresa.Text = nomEmpresa;
            txtIdUsuario.Text = idUsuario.ToString();
            txtNomUsuario.Text = Usuario_;

            oListaValidar = oListaTemp;
        }

        public frmDetalleUsuarioFondoFijo(List<UsuarioFondoFijoE> oListaTemp, UsuarioFondoFijoE UsuarioFondoFijo)
            :this()
        {
            oTipoFondo = UsuarioFondoFijo;
            oListaValidar = oListaTemp;
        }

        #endregion

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public UsuarioFondoFijoE oTipoFondo = null;
        List<UsuarioFondoFijoE> oListaValidar = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarTipoFondo()
        {
            ////TipoFondo////
            cboTipoFondo.DataSource = Global.CargarTipoFondo();
            cboTipoFondo.ValueMember = "id";
            cboTipoFondo.DisplayMember = "Nombre";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oTipoFondo == null)
                {
                    oTipoFondo = new UsuarioFondoFijoE
                    {
                        idEmpresa = Convert.ToInt32(txtIdEmpresa.Text),
                        nomEmpresa = txtDesEmpresa.Text,
                        idPersona = Convert.ToInt32(txtIdUsuario.Text),
                        nomUsuario = txtNomUsuario.Text,
                        Opcion = (Int32)EnumOpcionGrabar.Insertar
                    };

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();
                }
                else
                {
                    cboTipoFondo.Enabled = false;

                    txtIdEmpresa.Text = oTipoFondo.idEmpresa.ToString();
                    txtDesEmpresa.Text = oTipoFondo.nomEmpresa;
                    txtIdUsuario.Text = oTipoFondo.idPersona.ToString();
                    txtNomUsuario.Text = oTipoFondo.nomUsuario;
                    cboTipoFondo.SelectedValue = oTipoFondo.TipoFondo.ToString();
                    chkEditar.Checked = oTipoFondo.Edicion;
                    chkVisualizar.Checked = oTipoFondo.Visualizar;

                    txtUsuarioRegistro.Text = oTipoFondo.UsuarioRegistro;
                    txtFechaRegistro.Text = oTipoFondo.FechaRegistro.ToString();
                    txtUsuarioMod.Text = oTipoFondo.UsuarioModificacion;
                    txtFechaModifica.Text = oTipoFondo.FechaModificacion.ToString();

                    //oTipoCobranza.idTipoPlanillaAnte = oTipoCobranza.idTipoPlanilla; //Para poder actualizar esta llave principal
                    oTipoFondo.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
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
                oTipoFondo.TipoFondo = Convert.ToInt32(cboTipoFondo.SelectedValue);
                oTipoFondo.desTipoFondo = cboTipoFondo.Text;
                oTipoFondo.Edicion = chkEditar.Checked;
                oTipoFondo.Visualizar = chkVisualizar.Checked;

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (oTipoFondo.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oTipoFondo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                    if (Global.MensajeConfirmacion("Desea agregar este registro.") == DialogResult.Yes)
                    {
                        oTipoFondo = AgenteSeguridad.Proxy.InsertarUsuarioFondoFijo(oTipoFondo);
                        base.Aceptar();
                    }
                }
                else
                {
                    oTipoFondo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                    if (Global.MensajeConfirmacion("Desea actualizar el registro.") == DialogResult.Yes)
                    {
                        oTipoFondo = AgenteSeguridad.Proxy.ActualizarUsuarioFondoFijo(oTipoFondo);
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
                if (oTipoFondo.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    foreach (UsuarioFondoFijoE item in oListaValidar)
                    {
                        if (item.idEmpresa == oTipoFondo.idEmpresa && item.idPersona == oTipoFondo.idPersona && item.TipoFondo == oTipoFondo.TipoFondo)
                        {
                            Global.MensajeFault("Este Tipo de Fondo ya ha sido agregado escoja otro.");
                            return false;
                        }
                    }
                }
                //else
                //{
                //    if (oTipoCobranza.idTipoPlanilla != oTipoCobranza.idTipoPlanillaAnte)
                //    {
                //        foreach (UsuarioFondoFijoE item in oListaValidar)
                //        {
                //            if (item.idEmpresa == oTipoCobranza.idEmpresa && item.idLocal == oTipoCobranza.idLocal && item.idUsuario == oTipoCobranza.idUsuario && item.idTipoPlanilla == oTipoCobranza.idTipoPlanilla)
                //            {
                //                Global.MensajeFault("Esta planilla de cobranza ya ha sido agregada escoja otra o Presione Cancelar");
                //                return false;
                //            }
                //        }
                //    }
                //}
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmDetalleUsuarioFondoFijo_Load(object sender, EventArgs e)
        {
            Nuevo();
        } 

        #endregion

    }
}
