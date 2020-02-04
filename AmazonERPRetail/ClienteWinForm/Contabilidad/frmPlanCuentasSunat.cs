using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmPlanCuentasSunat : FrmMantenimientoBase
    {
        public frmPlanCuentasSunat()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmPlanCuentasSunat(PlanCuentasSunatE PCS)
            :this()
        {
            OPlancuentasSunat = AgenteContabilidad.Proxy.ObtenerPlanCuentasSunat(PCS.codCuentaSunat);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public PlanCuentasSunatE OPlancuentasSunat = null;
        Int32 OpcionGrabar;
        #endregion


        #region Procedimientos de Usuario

        void NuevoRegistro()
        {
            if (OPlancuentasSunat == null)
            {
                OPlancuentasSunat = new PlanCuentasSunatE();


                txtUsuRegistra.Text = OPlancuentasSunat.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                OPlancuentasSunat.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = OPlancuentasSunat.FechaRegistro.ToString();
                txtUsuModifica.Text = OPlancuentasSunat.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                OPlancuentasSunat.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = OPlancuentasSunat.FechaModificacion.ToString();

                OpcionGrabar = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {

                txtDescipcion.Enabled = false;
                txtDescipcion.Text = OPlancuentasSunat.Descripcion;
                txtPlanCuentas.Text= OPlancuentasSunat.codCuentaSunat;


                txtUsuRegistra.Text = OPlancuentasSunat.UsuarioRegistro;
                txtRegistro.Text = OPlancuentasSunat.FechaRegistro.ToString();
                txtUsuModifica.Text = OPlancuentasSunat.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                OPlancuentasSunat.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = OPlancuentasSunat.FechaModificacion.ToString();


                OpcionGrabar = (Int32)EnumOpcionGrabar.Actualizar;
            }


  


            base.Nuevo();
        }

        void GuardarDatos()
        {
            OPlancuentasSunat.Descripcion = txtDescipcion.Text;
            OPlancuentasSunat.codCuentaSunat = txtPlanCuentas.Text;

            if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
            {
                OPlancuentasSunat.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                OPlancuentasSunat.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }


        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {
                if (OPlancuentasSunat != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            OPlancuentasSunat = AgenteContabilidad.Proxy.InsertarPlanCuentasSunat(OPlancuentasSunat);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            OPlancuentasSunat = AgenteContabilidad.Proxy.ActualizarPlanCuentasSunat(OPlancuentasSunat);
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

        public override void Editar()
        {
            base.Editar();
        }

        public override void Cancelar()
        {
            base.Cancelar();
        }

        public override bool ValidarGrabacion()
        {
            return base.ValidarGrabacion();
        }


        public override void Cerrar()
        {
            base.Cerrar();
        }



        #endregion


        #region eventos

        private void frmPlanCuentasSunat_Load(object sender, EventArgs e)
        {
            Grid = false;
            NuevoRegistro();
        }

        #endregion 

    }
}
