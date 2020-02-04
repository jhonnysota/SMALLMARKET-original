using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmLineaVenta : FrmMantenimientoBase
    {
        #region Constructores
        
        public frmLineaVenta()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmLineaVenta(Int32 idEmpresa, String idLinea)
            : this()
        {
            oLinea = AgenteVentas.Proxy.ObtenerLinea(idEmpresa, idLinea);
        }  

        #endregion
        
        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        LineaE oLinea = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oLinea == null)
            {
                oLinea = new LineaE();

                oLinea.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuRegistra.Text = oLinea.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oLinea.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oLinea.FechaRegistro.ToString();
                txtUsuModifica.Text = oLinea.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oLinea.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oLinea.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodLinea.Text = oLinea.idLinea;
                txtCodLinea.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtDesLin.Text = oLinea.Descripcion;
                txtUsuRegistra.Text = oLinea.UsuarioRegistro;
                txtRegistro.Text = oLinea.FechaRegistro.ToString();
                txtUsuModifica.Text = oLinea.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oLinea.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oLinea.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        void GuardarDatos()
        {
            oLinea.idLinea = txtCodLinea.Text;
            oLinea.Descripcion = txtDesLin.Text;
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            BloquearPaneles(true);
            oLinea = new LineaE();

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oLinea != null)
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
                            oLinea = AgenteVentas.Proxy.InsertarLinea(oLinea);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oLinea = AgenteVentas.Proxy.ActualizarLinea(oLinea);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            BloquearPaneles(true);
            base.Editar();
        }

        public override void Cancelar()
        {
            BloquearPaneles(false);
            pnlAuditoria.Focus();
            base.Cancelar();
        }

        public override void Cerrar()
        {
            base.Cerrar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<LineaE>(oLinea);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion
               
        #region Eventos

        private void frmLineaVenta_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }

        #endregion

    }
}
