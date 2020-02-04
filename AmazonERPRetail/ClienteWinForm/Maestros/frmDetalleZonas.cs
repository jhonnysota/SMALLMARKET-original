using System;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Maestros
{
    public partial class frmDetalleZonas : FrmMantenimientoBase
    {

        #region Constructores
        
        public frmDetalleZonas()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        public frmDetalleZonas(int idEmpresa_, int idLocal_, int idEstablecimiento_, int idZona_, EnumOpcionGrabar Opcion, string Titulo)
            : this()
        {
            if (Opcion == EnumOpcionGrabar.Actualizar)
            {
                oZonaTrabajo = AgenteVentas.Proxy.ObtenerZonaTrabajo(idEmpresa_, idLocal_, idEstablecimiento_, idZona_);
                Text = "Nueva Zona de Influencia";
            }
            else
            {
                idEmpresa = idEmpresa_;
                idLocal = idLocal_;
                idEstablecimiento = idEstablecimiento_;
                idZona = idZona_;
                Text = "Zona de Influencia - " + Titulo;
            }
        }

        #endregion Constructores

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        ZonaTrabajoE oZonaTrabajo = null;
        Int32 idEmpresa = Variables.Cero;
        Int32 idLocal = Variables.Cero;
        Int32 idEstablecimiento = Variables.Cero;
        int idZona = Variables.Cero;
        Int32 Opcion = Variables.Cero;

        #endregion Variables

        #region Procedimientos de Usuario

        void DatosGrabacion()
        {
            oZonaTrabajo.Descripcion = txtDescripcion.Text;
            oZonaTrabajo.Principal = chkPrincipal.Checked;

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oZonaTrabajo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oZonaTrabajo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oZonaTrabajo == null)
                {
                    oZonaTrabajo = new ZonaTrabajoE();
                    oZonaTrabajo.idEmpresa = idEmpresa;
                    oZonaTrabajo.idLocal = idLocal;
                    oZonaTrabajo.idEstablecimiento = idEstablecimiento;
                    oZonaTrabajo.idZona = idZona;
                    txtIdZona.Text = idZona.ToString();
                    
                    txtUsuarioRegistro.Text = txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                    Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    txtIdZona.Text = oZonaTrabajo.idZona.ToString();
                    txtDescripcion.Text = oZonaTrabajo.Descripcion;
                    chkPrincipal.Checked = oZonaTrabajo.Principal;

                    txtUsuarioRegistro.Text = oZonaTrabajo.UsuarioRegistro;
                    txtFechaRegistro.Text = oZonaTrabajo.FechaRegistro.ToString();
                    txtUsuarioModificacion.Text = oZonaTrabajo.UsuarioModificacion;
                    txtFechaModificacion.Text = oZonaTrabajo.FechaModificacion.ToString();

                    Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                DatosGrabacion();

                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.InsertarZonaTrabajo(oZonaTrabajo);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.ActualizarZonaTrabajo(oZonaTrabajo);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmDetalleZonas_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        } 

        #endregion

    }
}
