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
using ClienteWinForm.Maestros;

namespace ClienteWinForm.Ventas
{
    public partial class frmCampanaTipo : FrmMantenimientoBase
    {
        #region Constructores
        
        public frmCampanaTipo()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmCampanaTipo(Int32 idTipoCampana, Int32 idEmpresa)
            : this()
        {
            oCampanaTipo = AgenteVentas.Proxy.ObtenerCampanaTipo(idTipoCampana, idEmpresa);
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        CampanaTipoE oCampanaTipo = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oCampanaTipo == null)
            {
                oCampanaTipo = new CampanaTipoE();



                oCampanaTipo.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
    

                txtUsuRegistra.Text = oCampanaTipo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oCampanaTipo.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = oCampanaTipo.FechaRegistro.ToString();
                txtUsuModifica.Text = oCampanaTipo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCampanaTipo.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oCampanaTipo.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;

            }
            else
            {


                txtTipoCampana.Text = Convert.ToString(oCampanaTipo.idTipoCampana);
                txtDes.Text = oCampanaTipo.desTipoCampana;
                

                txtUsuRegistra.Text = oCampanaTipo.UsuarioRegistro;
                txtRegistro.Text = oCampanaTipo.FechaRegistro.ToString();
                txtUsuModifica.Text = oCampanaTipo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCampanaTipo.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oCampanaTipo.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

            }

            base.Nuevo();
        }

        void GuardarDatos()
        {
            oCampanaTipo.desTipoCampana = txtDes.Text;

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
            oCampanaTipo = new CampanaTipoE();

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oCampanaTipo != null)
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
                            oCampanaTipo = AgenteVentas.Proxy.InsertarCampanaTipo(oCampanaTipo);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oCampanaTipo = AgenteVentas.Proxy.ActualizarCampanaTipo(oCampanaTipo);
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
            String Respuesta = ValidarEntidad<CampanaTipoE>(oCampanaTipo);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmCampanaTipo_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        } 

        #endregion
    }
}
