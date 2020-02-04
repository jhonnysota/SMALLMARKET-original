using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClienteWinForm.Busquedas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Maestros
{
    public partial class FrmUbigeo : FrmMantenimientoBase
    {
        #region Constructor

        public FrmUbigeo()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public FrmUbigeo(UbigeoE oUbigeo_)
            : this()
        {
            oUbigeo = oUbigeo_;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        UbigeoE oUbigeo = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oUbigeo.idUbigeo = txtUbigeo.Text;
            oUbigeo.Departamento = txtDepart.Text;
            oUbigeo.Provincia = txtProv.Text;
            oUbigeo.Distrito = txtDist.Text;
            oUbigeo.idPais = Convert.ToInt32(txtidPais.Text);

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oUbigeo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial; ;
            }
            else
                oUbigeo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlDatos.Enabled = Flag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oUbigeo == null)
            {
                oUbigeo = new UbigeoE();

                txtUsuRegistra.Text = oUbigeo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = oUbigeo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtUbigeo.Enabled = false;
                txtUbigeo.Text = oUbigeo.idUbigeo;
                txtDepart.Text = oUbigeo.Departamento;
                txtProv.Text = oUbigeo.Provincia;
                txtDist.Text = oUbigeo.Distrito;
                txtidPais.Text = Convert.ToString(oUbigeo.idPais);
                txtNomPais.Text = oUbigeo.NombrePais;

                txtUsuRegistra.Text = oUbigeo.UsuarioRegistro;
                txtRegistro.Text = oUbigeo.FechaRegistro.ToString();
                txtUsuModifica.Text = oUbigeo.UsuarioModificacion;
                txtModifica.Text = oUbigeo.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oUbigeo != null)
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
                            oUbigeo = AgenteMaestro.Proxy.InsertarUbigeo(oUbigeo);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oUbigeo = AgenteMaestro.Proxy.ActualizarUbigeo(oUbigeo);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override Boolean ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<UbigeoE>(oUbigeo);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos
        
        private void FrmUbigeo_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btPaises_Click(object sender, EventArgs e)
        {
            frmBuscarPaises oFrm = new frmBuscarPaises();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.ePais != null)
            {
                txtidPais.Text = oFrm.ePais.idPais.ToString();
                txtNomPais.Text = oFrm.ePais.Nombre;
            }
        } 

        #endregion

    }
}
