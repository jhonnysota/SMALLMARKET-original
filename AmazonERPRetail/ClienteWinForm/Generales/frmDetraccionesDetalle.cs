using System;
using System.Windows.Forms;
using Infraestructura;

using Entidades.Generales;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Generales
{
    public partial class frmDetraccionesDetalle : frmResponseBase
    {

        #region Eventos

        public frmDetraccionesDetalle()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        public frmDetraccionesDetalle(TasasDetraccionesDetalleE oDet)
            :this()
        {
            Detalle = oDet;
        } 

        #endregion

        #region Variables     

        public TasasDetraccionesDetalleE Detalle = null;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new TasasDetraccionesDetalleE();

                txtItem.Text = Variables.Cero.ToString();
                usuarioRegistroTextBox.Text = Detalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                Detalle.FechaRegistro = VariablesLocales.FechaHoy;
                txtFecRegistro.Text = Detalle.FechaRegistro.ToString();
                usuarioModificacionTextBox.Text = Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                Detalle.FechaModificacion = VariablesLocales.FechaHoy;
                txtFecModificacion.Text = Detalle.FechaModificacion.ToString();

                Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtItem.Text = Detalle.item.ToString();
                dtpFecInicio.Value = Convert.ToDateTime(Detalle.fecInicio);
                dtpFecFin.Value = Convert.ToDateTime(Detalle.fecFin);
                txtPor.Text = Convert.ToDecimal(Detalle.Porcentaje).ToString("N2");

                usuarioRegistroTextBox.Text = Detalle.UsuarioRegistro;
                txtFecRegistro.Text = Detalle.FechaRegistro.ToString();
                usuarioModificacionTextBox.Text = Detalle.UsuarioModificacion;
                txtFecModificacion.Text = Detalle.FechaModificacion.ToString();
                Detalle.FechaModificacion = VariablesLocales.FechaHoy;

                Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsBase.DataSource = Detalle;
            bsBase.ResetBindings(false);
            base.Nuevo();
        }

        public override void Aceptar()
        {
            bsBase.EndEdit();

            Detalle.Porcentaje = Convert.ToDecimal(txtPor.Text);
            Detalle.fecInicio = dtpFecInicio.Value.Date;
            Detalle.fecFin = dtpFecFin.Value.Date;

            if (!ValidarGrabacion())
            {
                return;
            }

            base.Aceptar();
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<TasasDetraccionesDetalleE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion
        
        #region Eventos

        private void frmDetraccionesDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        #endregion

    }
}
