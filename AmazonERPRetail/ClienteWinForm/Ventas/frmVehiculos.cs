using System;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;

namespace ClienteWinForm.Ventas
{
    public partial class frmVehiculos : frmResponseBase
    {
        #region Constructores

        public frmVehiculos()
        {
            InitializeComponent();
        }

        public frmVehiculos(Int32 idTransporte_, Int32 idVehiculo_)
            :this()
        {
            oVehiculo = AgenteVentas.Proxy.ObtenerTransporteVehiculos(idTransporte_, idVehiculo_);
        }

        #endregion

        #region Variables

        public TransporteVehiculosE oVehiculo = null;
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void EsNuevo()
        {
            if (oVehiculo == null)
            {
                oVehiculo = new TransporteVehiculosE();
                
                Global.LimpiarControlesPaneles(pnlBase);
                txtIdVehiculo.Text = oVehiculo.idVehiculo.ToString();
                oVehiculo.indEstado = false;
                txtUsuRegistra.Text = oVehiculo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oVehiculo.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oVehiculo.FechaRegistro.ToString();
                txtUsuModifica.Text = oVehiculo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oVehiculo.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oVehiculo.FechaModificacion.ToString();
            }
            else
            {
                txtIdVehiculo.Text = oVehiculo.idVehiculo.ToString("00");
                txtPlaca.Text = oVehiculo.numPlaca;
                txtInscripcion.Text = oVehiculo.numInscripcion;
                txtDescripcion.Text = oVehiculo.desVehicular;
                txtMarca.Text = oVehiculo.Marca;
                txtCapacidad.Text = Convert.ToDecimal(oVehiculo.Capacidad).ToString("##0.00");

                txtUsuRegistra.Text = oVehiculo.UsuarioRegistro;
                txtRegistro.Text = oVehiculo.FechaRegistro.ToString();
                txtUsuModifica.Text = oVehiculo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oVehiculo.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oVehiculo.FechaModificacion.ToString();
            }

            base.Nuevo();
        }

        void Datos()
        {
            oVehiculo.numPlaca = txtPlaca.Text;
            oVehiculo.numInscripcion = txtInscripcion.Text;
            oVehiculo.desVehicular = txtDescripcion.Text;
            oVehiculo.Marca = txtMarca.Text;
            
            if (String.IsNullOrEmpty(txtCapacidad.Text.Trim()))
            {
                txtCapacidad.Text = Variables.Cero.ToString();
            }

            oVehiculo.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
        }

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            Datos();

            if (ValidarGrabacion())
            {
                if (oVehiculo != null)
                {
                    base.Aceptar();
                }
            }
        }

        public override bool ValidarGrabacion()
        {
            string respuesta = ValidarEntidad<TransporteVehiculosE>(oVehiculo);

            if (!string.IsNullOrEmpty(respuesta))
            {
                Global.MensajeComunicacion(respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            EsNuevo();
        }
    }
}
