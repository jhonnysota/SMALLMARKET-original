using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm.Maestros;

namespace ClienteWinForm.Generales
{
    public partial class frmImpuestosDetalle : frmResponseBase
    {
        #region Constructores

        public frmImpuestosDetalle()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

       public frmImpuestosDetalle(ImpuestosPeriodoE oDet)
            :this()
        {
                Detalle = oDet;
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        public ImpuestosPeriodoE Detalle = null;
        
        #endregion

        #region Eventos
        
        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new ImpuestosPeriodoE();

                txtItem.Text = Variables.Cero.ToString();
                usuarioRegistroTextBox.Text = Detalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                Detalle.FechaRegistro = VariablesLocales.FechaHoy;
                txtFecRegistro.Text = Detalle.FechaRegistro.ToString();
                usuarioModificacionTextBox.Text = Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                Detalle.FechaModificacion = VariablesLocales.FechaHoy;
                txtFecModificacion.Text = Detalle.FechaModificacion.ToString();

                Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtItem.Text = Detalle.Item.ToString();
                dtpFecInicio.Value = Convert.ToDateTime(Detalle.fecInicio);
                dtpFecFin.Value = Convert.ToDateTime(Detalle.fecFin);
                txtPor.Text = Convert.ToDecimal(Detalle.Porcentaje).ToString("N2");

                usuarioRegistroTextBox.Text = Detalle.UsuarioRegistro;
                txtFecRegistro.Text = Detalle.FechaRegistro.ToString();
                usuarioModificacionTextBox.Text = Detalle.UsuarioModificacion;
                txtFecModificacion.Text = Detalle.FechaModificacion.ToString();
                Detalle.FechaModificacion = VariablesLocales.FechaHoy;

                Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsBase.DataSource = Detalle;
            bsBase.ResetBindings(false);
            base.Nuevo();
        }

        public override void Aceptar()
        {
            bsBase.EndEdit();

            Detalle.Porcentaje = Convert.ToDecimal(txtPor.Text);
            Detalle.fecInicio = dtpFecInicio.Value.Date;
            Detalle.fecFin = dtpFecFin.Value.Date;

            if (!ValidarGrabacion())
            {
                return;
            }

            base.Aceptar();
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<ImpuestosPeriodoE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        private void frmImpuestosDetalle_Load(object sender, EventArgs e)
        {
            Nuevo();
        } 

        #endregion

    }
}
