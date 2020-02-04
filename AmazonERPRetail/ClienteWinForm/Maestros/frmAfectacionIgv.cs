using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Maestros
{
    public partial class frmAfectacionIgv : FrmMantenimientoBase
    {

        #region Constructores

        public frmAfectacionIgv()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmAfectacionIgv(AfectacionIgvE oAfec_)
            :this()
        {
            oAfec = oAfec_;
        } 

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        AfectacionIgvE oAfec = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            Int32.TryParse(txtID.Text, out Int32 codigo);
            oAfec.idAfectacion = codigo;
            oAfec.DesAfectacion = txtAfectacion.Text;
            oAfec.indIgv = chkIGV.Checked;
            oAfec.EquivalenciaSunat = txtEqSunat.Text;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oAfec.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oAfec.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oAfec == null)
            {
                oAfec = new AfectacionIgvE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtID.Enabled = false;
                txtID.Text = Convert.ToString(oAfec.idAfectacion);
                txtAfectacion.Text = oAfec.DesAfectacion;
                chkIGV.Checked = oAfec.indIgv;
                txtEqSunat.Text = oAfec.EquivalenciaSunat;

                txtUsuRegistra.Text = oAfec.UsuarioRegistro;
                txtRegistro.Text = oAfec.FechaRegistro.ToString();
                txtUsuModifica.Text = oAfec.UsuarioModificacion; ;
                txtModifica.Text = oAfec.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oAfec != null)
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
                            oAfec = AgenteMaestros.Proxy.InsertarAfectacionIgv(oAfec);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oAfec = AgenteMaestros.Proxy.ActualizarAfectacionIgv(oAfec);
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

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<AfectacionIgvE>(oAfec);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmAfectacionIgv_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        } 

        #endregion

    }
}
