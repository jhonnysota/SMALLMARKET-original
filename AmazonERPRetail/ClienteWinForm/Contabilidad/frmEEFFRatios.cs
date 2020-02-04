using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
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
    public partial class frmEEFFRatios : FrmMantenimientoBase
    {
        public frmEEFFRatios()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            CargarCombos();
         
        }

        public frmEEFFRatios(Int32 idEmpresa,Int32 idItem)
          : this()
        {
            try
            {
                entidad = AgenteContabilidad.Proxy.ObtenerEEFFRatios(idEmpresa, idItem);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }


        #region Variables
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        EEFFRatiosE entidad = null;
        Int32 opcion;
        List<EEFFRatiosE> oLista = new List<EEFFRatiosE>();
        Int32 itemMayor;
        #endregion

        void CargarCombos()
        {
            ComboHelper.RellenarCombos<DataTable>(cboTipoTabla, Global.CargarTipoTablaEEFFItem(), "IdTipoTabla", "TipoTabla", false);
        }


        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {
            if (entidad == null)
            {
                entidad = new EEFFRatiosE();
                entidad.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                txtUsuRegistro.Text = entidad.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                entidad.FechaRegistro = VariablesLocales.FechaHoy;
                txtFechaRegistro.Text = entidad.FechaRegistro.ToString();
                txtUsuModificacion.Text = entidad.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                entidad.FechaModificacion = VariablesLocales.FechaHoy;
                txtFechaModificacion.Text = entidad.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;

                oLista = AgenteContabilidad.Proxy.ListarEEFFRatios(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                foreach (EEFFRatiosE item in oLista)
                {
                    itemMayor = item.idItem;
                }
                itemMayor++;
                entidad.idItem = itemMayor;

            }
            else
            {
                txtTipoSeccion.Text = entidad.secItem;
                txtdesSeccion.Text = entidad.desItem;
                txtGlosa.Text = entidad.desGlosa;
                cboTipoTabla.SelectedValue = entidad.TipoTabla;
                txtFormula.Text = entidad.Formula;
                chkActivo.Checked = entidad.flagActivo;

                txtUsuRegistro.Text = entidad.UsuarioRegistro;
                txtFechaRegistro.Text = entidad.FechaRegistro.ToString();
                txtUsuModificacion.Text = entidad.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                entidad.FechaModificacion = VariablesLocales.FechaHoy;
                txtFechaModificacion.Text = entidad.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        void GuardarDatos()
        {
            entidad.secItem = txtTipoSeccion.Text;
            entidad.desItem = txtdesSeccion.Text;
            entidad.desGlosa = txtGlosa.Text;
            entidad.TipoTabla = cboTipoTabla.SelectedValue.ToString();
            entidad.Formula = txtFormula.Text;
            entidad.flagActivo = chkActivo.Checked;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            entidad = new EEFFRatiosE();

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (entidad != null)
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
                            entidad = AgenteContabilidad.Proxy.InsertarEEFFRatios(entidad);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            entidad = AgenteContabilidad.Proxy.ActualizarEEFFRatios(entidad);
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

        public override void Cerrar()
        {
            base.Cerrar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<EEFFRatiosE>(entidad);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        private void frmEEFFRatios_Load(object sender, EventArgs e)
        {
            Grid = false;
            EsNuevoRegistro();
        }

    }
}
