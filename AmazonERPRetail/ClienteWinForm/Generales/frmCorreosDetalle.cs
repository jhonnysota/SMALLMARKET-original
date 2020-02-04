using System;

using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Generales
{
    public partial class frmCorreosDetalle : frmResponseBase
    {

        #region Constructores

        public frmCorreosDetalle()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmCorreosDetalle(ContactosCorreosE correosE)
            :this()
        {
            oCorreo = correosE;
        } 

        #endregion

        #region Variables

        public ContactosCorreosE oCorreo = null;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oCorreo == null)
            {
                oCorreo = new ContactosCorreosE()
                {
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

            }
            else
            {
                if (oCorreo.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oCorreo.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtCorreo.Text = oCorreo.Correo;
                txtNombres.Text = oCorreo.Nombres;
            }
        }

        public override void Aceptar()
        {
            if (oCorreo != null)
            {
                String correo = Global.DejarSoloUnEspacio(txtCorreo.Text.Trim());

                if (!Global.RevisarEmail(correo))
                {
                    Global.MensajeAdvertencia("Correo invalido, coloque un correcto.");
                    return;
                }

                oCorreo.Correo = correo;
                oCorreo.Nombres = Global.DejarSoloUnEspacio(txtNombres.Text.Trim());

                if (oCorreo.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oCorreo.UsuarioRegistro = oCorreo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oCorreo.FechaRegistro = oCorreo.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    oCorreo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oCorreo.FechaModificacion = VariablesLocales.FechaHoy;
                }

                base.Aceptar();
            }
        }

        #endregion

        #region Eventos

        private void frmCorreosDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        } 

        #endregion

    }
}
