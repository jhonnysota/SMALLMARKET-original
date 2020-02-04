using System;

using Entidades.Generales;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Generales
{
    public partial class frmImpresoraUsuarioDetalle : frmResponseBase
    {
        public frmImpresoraUsuarioDetalle()
        {
            InitializeComponent();
        }

        #region Variables

        public UsuarioImpresorasDetE oDetalle = null;

        #endregion

        #region Procedimientos de Usuario

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oDetalle == null)
            {
                oDetalle = new UsuarioImpresorasDetE()
                {
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

                txtUsuarioReg.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaReg.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaMod.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtId.Text = oDetalle.Item.ToString();
                txtAncho.Text = oDetalle.AnchoEtiqueta.ToString("N2");
                txtAlto.Text= oDetalle.AltoEtiqueta.ToString("N2");
                txtCantidad.Text = oDetalle.cantEtiqueta.ToString();
                txtEspacios.Text = oDetalle.Gap.ToString();

                txtUsuarioReg.Text = oDetalle.UsuarioRegistro;
                txtFechaReg.Text = oDetalle.FechaRegistro.ToString();
                txtUsuarioMod.Text = oDetalle.UsuarioModificacion;
                txtFechaMod.Text = oDetalle.UsuarioModificacion.ToString();

                if (oDetalle.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar; 
                }
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            if (oDetalle != null)
            {
                Decimal.TryParse(txtAncho.Text, out Decimal Ancho);
                Decimal.TryParse(txtAlto.Text, out Decimal Alto);
                Int32.TryParse(txtCantidad.Text, out Int32 Cantidad);
                Int32.TryParse(txtEspacios.Text, out Int32 Espacio);

                oDetalle.PorDefecto = false;
                oDetalle.AnchoEtiqueta = Ancho;
                oDetalle.AltoEtiqueta = Alto;
                oDetalle.cantEtiqueta = Cantidad;
                oDetalle.Gap = Espacio;

                if (oDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oDetalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oDetalle.FechaRegistro = VariablesLocales.FechaHoy;
                    oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                }

                base.Aceptar(); 
            }
        }

        #endregion

        #region Eventos

        private void frmImpresoraUsuarioDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        } 

        #endregion

    }
}
