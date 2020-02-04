using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class FrmDetallePlanCuentasVersion : frmResponseBase
    {
        #region Constructor

        public FrmDetallePlanCuentasVersion()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        public FrmDetallePlanCuentasVersion(PlanCuentasEstrucE oDetalle)
            :this()
        {
            Detalle = oDetalle;
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public PlanCuentasEstrucE Detalle = null;
        Int32 opcion = Variables.Cero;

        #endregion

        #region Procedimiento de Usuario

        void LlenarCombos()
        {
            cboIFF.DataSource = Global.CargarSN();
            cboIFF.ValueMember = "id";
            cboIFF.DisplayMember = "Nombre";

            cboIMoneda.DataSource = Global.CargarSN();
            cboIMoneda.ValueMember = "id";
            cboIMoneda.DisplayMember = "Nombre";
        }

        #endregion

        #region Procesos Heredados

        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new PlanCuentasEstrucE();

                txtURegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFModificacion.Text = VariablesLocales.FechaHoy.ToString();
                Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtNEstr.Text = Convert.ToString(Detalle.numNivelEstruc);
                txtDescripcion.Text = Detalle.Descripcion;
                txtLongitud.Text = Convert.ToString(Detalle.numLongiEstruc);
                cboIFF.SelectedValue = Detalle.indFteFinanciamiento;
                cboIMoneda.SelectedValue = Detalle.indMoneda;
                txtURegistro.Text = Detalle.UsuarioRegistro;
                txtFRegistro.Text = Detalle.FechaRegistro.ToString();
                txtUModificacion.Text = Detalle.UsuarioModificacion;
                txtFModificacion.Text = Detalle.FechaModificacion.ToString();
                Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsBase.ResetBindings(false);
            base.Nuevo();
        }

        public override void Aceptar()
        {
            Detalle.numNivelEstruc = Convert.ToInt32(txtNEstr.Text);
            Detalle.Descripcion = txtDescripcion.Text;
            Detalle.numLongiEstruc = Convert.ToInt32(txtLongitud.Text);
            Detalle.indFteFinanciamiento = Convert.ToString(cboIFF.SelectedValue);
            Detalle.indMoneda = Convert.ToString(cboIMoneda.SelectedValue);

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                Detalle.UsuarioRegistro = txtURegistro.Text;
                Detalle.FechaRegistro = VariablesLocales.FechaHoy;
                Detalle.UsuarioModificacion = txtUModificacion.Text;
                Detalle.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                Detalle.UsuarioModificacion = txtUModificacion.Text;
                Detalle.FechaModificacion = VariablesLocales.FechaHoy;
            }

            base.Aceptar();
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<PlanCuentasEstrucE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void FrmDetallePlanCuentasVersion_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        #endregion
    }
}
