using Entidades.Generales;
using Entidades.Maestros;
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

namespace ClienteWinForm.Maestros
{
    public partial class frmCostosEstruc : FrmMantenimientoBase
    {

        #region Constructor

        public frmCostosEstruc()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        public frmCostosEstruc(CostosEstrucE _CostosEstruc)
            : this()
        {
            oCostosEstruc = _CostosEstruc;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        CostosEstrucE oCostosEstruc = null;
        CostosEstrucE oCostosEstrucAnte = null;
        Int32 Opcion;

        #endregion

        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (oCostosEstruc == null)
            {
                oCostosEstruc = new CostosEstrucE();

                oCostosEstruc.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuRegistra.Text = oCostosEstruc.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oCostosEstruc.FechaRegistro = VariablesLocales.FechaHoy;
                txtFechaRegistro.Text = oCostosEstruc.FechaRegistro.ToString();
                txtUsuModifica.Text = oCostosEstruc.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oCostosEstruc.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oCostosEstruc.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {

                NumNivel.Value = Convert.ToInt32(oCostosEstruc.numNivel);
                txtDes.Text = oCostosEstruc.desNivel;
                txtLong.Text = Convert.ToString(oCostosEstruc.numLongitud);
                cboIndNivel.SelectedValue = oCostosEstruc.indUltimoNivel.ToString();

                txtUsuRegistra.Text = oCostosEstruc.UsuarioRegistro;
                txtFechaRegistro.Text = oCostosEstruc.FechaRegistro.ToString();
                txtUsuModifica.Text = oCostosEstruc.UsuarioModificacion;
                txtModifica.Text = oCostosEstruc.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                oCostosEstrucAnte = oCostosEstruc;
            }

            base.Nuevo();
        }

        void LlenarCombos()
        {
            cboIndNivel.DataSource = Global.CargarSN();
            cboIndNivel.ValueMember = "id";
            cboIndNivel.DisplayMember = "Nombre";
        }

        void GuardarDatos()
        {
            oCostosEstruc = new CostosEstrucE()
            {
                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                numNivel = Convert.ToInt32(NumNivel.Value),
                desNivel = txtDes.Text,
                numLongitud = Convert.ToInt32(txtLong.Text),
                indUltimoNivel = cboIndNivel.SelectedValue.ToString(),
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text),
                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                FechaModificacion = Convert.ToDateTime(txtModifica.Text)
            };
        }

        #endregion

        #region Procedimientos Heredados

        public override void Grabar()
        {
            try
            {
                if (oCostosEstruc != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oCostosEstruc = AgenteMaestros.Proxy.GrabarCostosEstruc(oCostosEstruc, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oCostosEstruc = AgenteMaestros.Proxy.GrabarCostosEstruc(oCostosEstruc, EnumOpcionGrabar.Actualizar, oCostosEstrucAnte);
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
            base.Editar();
        }

        public override void Cancelar()
        {
            pnlAuditoria.Focus();
            base.Cancelar();
        }

        public override void Cerrar()
        {
            base.Cerrar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<CostosEstrucE>(oCostosEstruc);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        private void frmCostosEstruc_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }

        #endregion

    }
}
