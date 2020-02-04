using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmTasaYRenta : FrmMantenimientoBase
    {

        #region Constructores

        public frmTasaYRenta()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);
        }

        public frmTasaYRenta(String idTasaIRenta_)
            : this()
        {
            oTasaIRenta = AgenteContabilidad.Proxy.ObtenerTasaIRenta(idTasaIRenta_);
        } 

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        TasaIRentaE oTasaIRenta = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oTasaIRenta.idTasaIRenta = txtTasaRenta.Text;
            oTasaIRenta.DesTasaIRenta = txtDescripcion.Text;
            oTasaIRenta.Porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oTasaIRenta == null)
            {
                oTasaIRenta = new TasaIRentaE();

                txtTasaRenta.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtUsuRegistra.Text = oTasaIRenta.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oTasaIRenta.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oTasaIRenta.FechaRegistro.ToString();
                txtUsuModifica.Text = oTasaIRenta.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oTasaIRenta.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oTasaIRenta.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtTasaRenta.Text = Convert.ToString(oTasaIRenta.idTasaIRenta);
                txtDescripcion.Text = oTasaIRenta.DesTasaIRenta;
                txtPorcentaje.Text = Convert.ToString(oTasaIRenta.Porcentaje);

                txtUsuRegistra.Text = oTasaIRenta.UsuarioRegistro;
                txtRegistro.Text = oTasaIRenta.FechaRegistro.ToString();
                txtUsuModifica.Text = oTasaIRenta.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oTasaIRenta.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oTasaIRenta.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oTasaIRenta != null)
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
                            oTasaIRenta = AgenteContabilidad.Proxy.InsertarTasaIRenta(oTasaIRenta);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oTasaIRenta = AgenteContabilidad.Proxy.ActualizarTasaIRenta(oTasaIRenta);
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

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<TasaIRentaE>(oTasaIRenta);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                List<TasaIRentaE> ListaTasaIRenta = null;

                ListaTasaIRenta = AgenteContabilidad.Proxy.ListarTasaIRenta();
                foreach (TasaIRentaE item in ListaTasaIRenta)
                {
                    if (item.idTasaIRenta == oTasaIRenta.idTasaIRenta)
                    {
                        Global.MensajeComunicacion("No se puede repetir un código");
                        return false;
                    }
                } 
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmTasaYRenta_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        #endregion

    }
}
