using System;
using System.Drawing;
using System.Windows.Forms;

using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Maestros
{
    public partial class frmDetallePersonaDireccion : frmResponseBase
    {

        #region Constructores
        
        public frmDetallePersonaDireccion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        public frmDetallePersonaDireccion(PersonaDireccionE oTemporalDetalleE)
            : this()
        {
            oPersonaDirección = oTemporalDetalleE;
        }

        #endregion Constructores

        #region Variables

        public PersonaDireccionE oPersonaDirección = null;

        #endregion Variables

        #region Procedimientos de Usuario

        void DatosPorAceptar()
        {
            oPersonaDirección.DescripcionSucursal = txtDesSucursal.Text;
            oPersonaDirección.DireccionCompleta = txtDireCompleta.Text;
            oPersonaDirección.Estado = chkEstado.Checked;

            if (oPersonaDirección.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oPersonaDirección.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oPersonaDirección.FechaRegistro = VariablesLocales.FechaHoy;
                oPersonaDirección.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPersonaDirección.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oPersonaDirección.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPersonaDirección.FechaModificacion = VariablesLocales.FechaHoy;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oPersonaDirección == null)
            {
                oPersonaDirección = new PersonaDireccionE();
                oPersonaDirección.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                oPersonaDirección.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtId.Text = oPersonaDirección.IdDireccion.ToString();
                txtDesSucursal.Text = oPersonaDirección.DescripcionSucursal;
                txtDireCompleta.Text = oPersonaDirección.DireccionCompleta;
                chkEstado.Checked = oPersonaDirección.Estado;

                txtUsuarioRegistro.Text = oPersonaDirección.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(oPersonaDirección.FechaRegistro);
                txtUsuarioModificacion.Text = oPersonaDirección.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(oPersonaDirección.FechaModificacion);
            }
            
            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (oPersonaDirección != null)
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

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmDetallePersonaDireccion_Load(object sender, EventArgs e)
        {
            Nuevo();
        }
		 
	    #endregion

    }
}
