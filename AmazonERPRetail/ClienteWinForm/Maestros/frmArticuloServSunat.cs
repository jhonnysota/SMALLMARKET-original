using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Maestros
{
    public partial class frmArticuloServSunat : FrmMantenimientoBase
    {

        #region Constructores

        public frmArticuloServSunat()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmArticuloServSunat(ArticuloServSunatE oArtServSunat_)
            :this()
        {
            oArtServSunat = oArtServSunat_;
        } 

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        ArticuloServSunatE oArtServSunat = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oArtServSunat.CodigoSunat = txtCodSunat.Text;
            oArtServSunat.Descripcion = txtDescripcion.Text;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oArtServSunat.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oArtServSunat.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oArtServSunat == null)
            {
                oArtServSunat = new ArticuloServSunatE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodSunat.Enabled = false;
                txtCodSunat.Text = oArtServSunat.CodigoSunat;
                txtDescripcion.Text = oArtServSunat.Descripcion;

                txtUsuRegistra.Text = oArtServSunat.UsuarioRegistro;
                txtRegistro.Text = oArtServSunat.FechaRegistro.ToString();
                txtUsuModifica.Text = oArtServSunat.UsuarioModificacion;
                txtModifica.Text = oArtServSunat.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oArtServSunat != null)
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
                            oArtServSunat = AgenteMaestros.Proxy.InsertarArticuloServSunat(oArtServSunat);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oArtServSunat = AgenteMaestros.Proxy.ActualizarArticuloServSunat(oArtServSunat);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<ArticuloServSunatE>(oArtServSunat);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmArticuloServSunat_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        } 

        #endregion

    }
}
