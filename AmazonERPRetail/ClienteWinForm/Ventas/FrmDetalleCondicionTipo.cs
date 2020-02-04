using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Ventas
{
    public partial class FrmDetalleCondicionTipo : frmResponseBase
    {

        #region Constructor

        public FrmDetalleCondicionTipo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDias, false);
        }

        public FrmDetalleCondicionTipo(CondicionE oDetalle)
            :this()
        {
            Detalle = oDetalle;
        }

        #endregion

        #region Variables

        public CondicionE Detalle = null;

        #endregion

        #region Procedimientos de Usuario

        void AgregarDetalle()
        {
            CondicionDiasE oDia = new CondicionDiasE()
            { 
                Opcion = (Int32)EnumOpcionGrabar.Insertar,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };

            Detalle.ListaDias.Add(oDia);
            bsDias.DataSource = Detalle.ListaDias;
            bsDias.ResetBindings(false);
        }

        void QuitarDetalle()
        {
            Detalle.ListaDias.RemoveAt(bsDias.Position);
            bsDias.DataSource = Detalle.ListaDias;
            bsDias.ResetBindings(false);
        }

        #endregion

        #region Procesos Heredados

        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new CondicionE();

                txtURegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodigo.Text = Convert.ToString(Detalle.idCondicion);
                txtDescripcion.Text = Detalle.desCondicion;
                chkGLetra.Checked = Detalle.GeneraLetra;
                chkCredito.Checked = Detalle.Credito;
                chkSCobra.Checked = Detalle.SeCobra;
                chkMUnidad.Checked = Detalle.ManejaUnidad;
                chkTGratuita.Checked = Detalle.tGratuita;
                chkCImpuesto.Checked = Detalle.ConImpuesto;
                chkncDescuento.Checked = Detalle.ncDescuentos;
                chkTFilial.Checked = Detalle.tFilial;
                chkCredCob.Checked = Detalle.indCreditoCobranza;
                chkIndDias.Checked = Detalle.indDias;
                chkIndDias_CheckedChanged(null, null);

                txtURegistro.Text = Detalle.UsuarioRegistro;
                txtFRegistro.Text = Detalle.FechaRegistro.ToString();
                txtUModificacion.Text = Detalle.UsuarioModificacion;
                txtFModificacion.Text = Detalle.FechaModificacion.ToString();
                
                Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsDias.DataSource = Detalle.ListaDias;
            bsBase.ResetBindings(false);
            base.Nuevo();
        }

        public override void Aceptar()
        {
            if (dgvDias.IsCurrentCellDirty)
            {
                dgvDias.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            bsDias.EndEdit();
            Detalle.ListaDias = (List<CondicionDiasE>)bsDias.List;

            if (!ValidarGrabacion())
            {
                return;
            }

            Detalle.desCondicion = txtDescripcion.Text;
            Detalle.GeneraLetra = chkGLetra.Checked;
            Detalle.Credito = chkCredito.Checked;
            Detalle.SeCobra = chkSCobra.Checked;
            Detalle.ManejaUnidad = chkMUnidad.Checked;
            Detalle.tGratuita = chkTGratuita.Checked;
            Detalle.ConImpuesto = chkCImpuesto.Checked;
            Detalle.ncDescuentos = chkncDescuento.Checked;
            Detalle.tFilial = chkTFilial.Checked;
            Detalle.indCreditoCobranza = chkCredCob.Checked;
            Detalle.indDias = chkIndDias.Checked;

            if (Detalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
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
            String resp = ValidarEntidad<CondicionE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            if (chkIndDias.Checked)
            {
                if (Detalle.ListaDias.Count == 0)
                {
                    Global.MensajeComunicacion("Debe ingresar Cantidad de Dias si esta habilitado el Check de Indicar Dias.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos
       
        private void FrmDetalleCondicionTipo_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btDias_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDias_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvDias.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvDias_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bsDias.EndEdit();

            //if (e.RowIndex != -1)
            //{
            //    if (((CondicionDiasE)bsDias.Current).Opcion != (int)EnumOpcionGrabar.Insertar)
            //    {
            //        ((CondicionDiasE)bsDias.Current).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            //        ((CondicionDiasE)bsDias.Current).Opcion = (int)EnumOpcionGrabar.Actualizar;
            //    }
            //}
        }

        private void btQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkIndDias_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndDias.Checked)
            {
                btDias.Enabled = true;
                btQuitar.Enabled = true;
            }
            else
            {
                btDias.Enabled = false;
                btQuitar.Enabled = false;
            }
        }

        #endregion

    }
}
