using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Generales
{
    public partial class frmUMedida : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmUMedida()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        //Edición
        public frmUMedida(UMedidaE oUnidadMedTmp)
            : this()
        {
            oUMedida = AgenteGenerales.Proxy.ObtenerUMedida(oUnidadMedTmp.idUMedida);
        }

        #endregion Constructores

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        UMedidaE oUMedida = null;
        Int32 idTipoMedida = 0;
        Int32 opcion;

        #endregion Variables

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            Decimal.TryParse(txtCCon.Text, out Decimal Conversion);
            Decimal.TryParse(txtCon.Text, out Decimal Contenido);
            oUMedida.CantConversion = Conversion;
            oUMedida.Contenido = Contenido;
            oUMedida.NomUMedida = txtNombreU.Text;
            oUMedida.NomUMedidaCorto = txtNombreC.Text;
            oUMedida.codSunat = txtCodSunat.Text;
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oUMedida == null)
            {
                oUMedida = new UMedidaE
                {
                    FechaRegistro = VariablesLocales.FechaHoy,
                    FechaModificacion = VariablesLocales.FechaHoy
                };

                txtUsuRegistra.Text = oUMedida.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = oUMedida.FechaRegistro.ToString();
                txtUsuModifica.Text = oUMedida.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = oUMedida.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtUMed.Text = Convert.ToString(oUMedida.idUMedida);
                txtCon.Text = Convert.ToString(oUMedida.Contenido);
                txtCCon.Text = Convert.ToString(oUMedida.CantConversion);
                txtNombreU.Text = oUMedida.NomUMedida;
                txtNombreC.Text = oUMedida.NomUMedidaCorto;
                txtCodSunat.Text = oUMedida.codSunat;

                txtUsuRegistra.Text = oUMedida.UsuarioRegistro;
                txtRegistro.Text = oUMedida.FechaRegistro.ToString();
                txtUsuModifica.Text = oUMedida.UsuarioModificacion;
                txtModifica.Text = oUMedida.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oUMedida != null)
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
                            oUMedida = AgenteGenerales.Proxy.InsertarUMedida(oUMedida);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oUMedida = AgenteGenerales.Proxy.ActualizarUMedida(oUMedida);
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

        public override Boolean ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<UMedidaE>(oUMedida);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos
        
        private void frmUMedida_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        #endregion Eventos

    }
}
