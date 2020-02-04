using System;
using System.Windows.Forms;

using ClienteWinForm.Busquedas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Maestros
{
    public partial class frmDetalleClienteAsociados : frmResponseBase
    {

        #region Constructores

        public frmDetalleClienteAsociados()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmDetalleClienteAsociados(ClienteAsociadosE oTemporalDetalleE)
            : this()
        {
            oClienteAsociados = oTemporalDetalleE;
        } 

        #endregion
        
        #region Variables

        public ClienteAsociadosE oClienteAsociados = null;

        #endregion Variables

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oClienteAsociados == null)
            {
                oClienteAsociados = new ClienteAsociadosE();
                oClienteAsociados.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                oClienteAsociados.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtRazon.Text = oClienteAsociados.RazonSocial;
                txtRuc.Text = oClienteAsociados.RUC;
                txtDireccion.Text = oClienteAsociados.Direccion;
                txtUsuarioRegistro.Text = oClienteAsociados.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(oClienteAsociados.FechaRegistro);
                txtUsuarioModificacion.Text = oClienteAsociados.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(oClienteAsociados.FechaModificacion);
            }
            
            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (oClienteAsociados != null)
                {
                    oClienteAsociados.RazonSocial = txtRazon.Text;
                    oClienteAsociados.RUC = txtRuc.Text;
                    oClienteAsociados.Direccion = txtDireccion.Text;
                    oClienteAsociados.Opcion = oClienteAsociados.Opcion;

                    if (oClienteAsociados.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oClienteAsociados.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oClienteAsociados.FechaRegistro = VariablesLocales.FechaHoy;
                        oClienteAsociados.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oClienteAsociados.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oClienteAsociados.UsuarioRegistro = txtUsuarioRegistro.Text;
                        oClienteAsociados.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                        oClienteAsociados.UsuarioModificacion = txtUsuarioModificacion.Text;
                        oClienteAsociados.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }

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

        private void frmDetalleClienteAsociados_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarRuc oFrm = new frmBuscarRuc();

                oFrm.Ruc = txtRuc.Text;

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
                {
                    #region Juridicas

                    txtRuc.Text = oFrm.Ruc;
                    txtRazon.Text = oFrm.RazonSocial;
                    txtDireccion.Text = oFrm.Direccion;

                    #endregion                    
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Eventos

    }
}
