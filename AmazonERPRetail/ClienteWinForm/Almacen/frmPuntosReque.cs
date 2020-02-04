using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Almacen
{
    public partial class frmPuntosReque : FrmMantenimientoBase
    {

        #region Constructores

        public frmPuntosReque()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmPuntosReque(RequerimientoPuntosE oPuntoReq_)
            : this()
        {
            oPuntoReq = oPuntoReq_;
        } 

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        RequerimientoPuntosE oPuntoReq = null;
        Int32 opcion = 0;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oPuntoReq.Descripcion = txtDescripcion.Text.Trim();
            oPuntoReq.Observacion = txtObservacion.Text.Trim();

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oPuntoReq.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oPuntoReq.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oPuntoReq == null)
            {
                oPuntoReq = new RequerimientoPuntosE();

                oPuntoReq.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtIdPunto.Text = oPuntoReq.idPuntoReq.ToString();
                txtDescripcion.Text = oPuntoReq.Descripcion;
                txtObservacion.Text = oPuntoReq.Observacion;

                txtUsuRegistra.Text = oPuntoReq.UsuarioRegistro;
                txtRegistro.Text = oPuntoReq.FechaRegistro.ToString();
                txtUsuModifica.Text = oPuntoReq.UsuarioModificacion;
                txtModifica.Text = oPuntoReq.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oPuntoReq != null)
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
                            oPuntoReq = AgenteAlmacen.Proxy.InsertarRequerimientoPuntos(oPuntoReq);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oPuntoReq = AgenteAlmacen.Proxy.ActualizarRequerimientoPuntos(oPuntoReq);
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

        #endregion

        #region Eventos

        private void frmPuntosReque_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        } 

        #endregion

    }
}
