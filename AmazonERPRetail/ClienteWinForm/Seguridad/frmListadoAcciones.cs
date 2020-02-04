using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Seguridad
{
    public partial class frmListadoAcciones : FrmMantenimientoBase
    {

        public frmListadoAcciones()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvAcciones, true);
        }

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }

        #endregion

        #region Procedimientos Usuario

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmAccion);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new FrmAccion
                {
                    MdiParent = MdiParent
                };
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmAccion);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            AccionE EAccion = (AccionE)bsAccion.Current;

            if (EAccion != null)
            {
                oFrm = new FrmAccion(EAccion);
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.MdiParent = MdiParent;
                oFrm.Show();
            }
        }

        public override void Buscar()
        {
            try
            {
                bsAccion.DataSource = AgenteSeguridad.Proxy.ListarAccion(txtBuscar.Text);

                txtBuscar.Focus();
                label1.Text = " Registros " + bsAccion.Count.ToString();
                dgvAcciones.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            if (bsAccion.Count > 0)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                {
                    ////bsAccion.DataSource = AgenteSeguridad.Proxy.CambiarEstadoAccion(Convert.ToInt32(((Accion)bsAccion.Current).IdAccion), false);
                    //AgenteSeguridad.Proxy.CambiarEstadoAccion(Convert.ToInt32(((Accion)bsAccion.Current).IdAccion), false);
                    //Buscar();
                    //Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                    //base.Anular();
                }    
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmAccion oFrm = sender as FrmAccion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoAcciones_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvAcciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if ((bool)dgvAcciones.Rows[e.RowIndex].Cells["Estado"].Value == true)
            //{
            //    if (e.Value != null)
            //    {
            //        e.CellStyle.BackColor = Color.FromArgb(255, 150, 150);
            //    }
            //}

            //dgvAcciones.Columns[0].DefaultCellStyle.Format = "000";
        }

        private void dgvAcciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Editar();    
                }                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
