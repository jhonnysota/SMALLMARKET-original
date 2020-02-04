using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmTesParametros : FrmMantenimientoBase
    {

        public frmTesParametros()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        tesParametrosE oParametrosTesoreria = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oParametrosTesoreria.Rmv = Convert.ToDecimal(txtRmv.Text);
            oParametrosTesoreria.porRmv = Convert.ToDecimal(txtPorcentajeRmv.Text);

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oParametrosTesoreria.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oParametrosTesoreria.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oParametrosTesoreria == null)
                {
                    oParametrosTesoreria = new tesParametrosE();
                    oParametrosTesoreria.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                    opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    txtRmv.Text = oParametrosTesoreria.Rmv.ToString("N2");
                    txtPorcentajeRmv.Text = oParametrosTesoreria.porRmv.ToString("N2");

                    txtUsuRegistro.Text = oParametrosTesoreria.UsuarioRegistro;
                    txtFechaRegistro.Text = oParametrosTesoreria.FechaRegistro.ToString();
                    txtUsuModificacion.Text = oParametrosTesoreria.UsuarioModificacion;
                    txtFechaModificacion.Text = oParametrosTesoreria.FechaModificacion.ToString();

                    opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oParametrosTesoreria != null)
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
                            oParametrosTesoreria = AgenteTesoreria.Proxy.InsertarTesParametros(oParametrosTesoreria);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oParametrosTesoreria = AgenteTesoreria.Proxy.ActualizarTesParametros(oParametrosTesoreria);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    VariablesLocales.oTesParametros = oParametrosTesoreria;
                    base.Grabar();
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmTesParametros_Load(object sender, EventArgs e)
        {
            Grid = false;
            oParametrosTesoreria = VariablesLocales.oTesParametros;
            Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
        } 

        #endregion

    }
}
