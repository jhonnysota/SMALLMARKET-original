using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Entidades.Seguridad;

namespace ClienteWinForm.Seguridad
{
    public partial class frmListadoRoles : FrmMantenimientoBase
    {
        public frmListadoRoles()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvRoles, true);
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRol);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new FrmRol();
                oFrm.MdiParent = this.MdiParent;
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
            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRol);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            Rol ERol = (Rol)bsRol.Current;

            if (ERol != null)
            {
                oFrm = new FrmRol(ERol);
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
        }

        public override void Buscar()
        {
            try
            {
                if (!chkIncluir.Checked)
                {
                    bsRol.DataSource = AgenteSeguridad.Proxy.ListarRol(txtBuscar.Text, false, false);
                }
                else
                {
                    bsRol.DataSource = AgenteSeguridad.Proxy.ListarRol(txtBuscar.Text, true, false);
                }
                
                base.Buscar();
                txtBuscar.Focus();
                lblRegistros.Text = "Roles - " + bsRol.Count.ToString() + " Registros";
                dgvRoles.AutoResizeColumns();
                BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            if (bsRol.Count > 0)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                {
                    bsRol.DataSource = AgenteSeguridad.Proxy.CambiarEstadoRol(Convert.ToInt32(((Rol)bsRol.Current).IdRol), Convert.ToBoolean(((Rol)bsRol.Current).Estado));
                    Buscar();
                    Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                    base.Anular();
                }
            }
        }

        #endregion

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmRol oFrm = sender as FrmRol;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoRoles_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvRoles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((bool)dgvRoles.Rows[e.RowIndex].Cells["Estado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 150, 150);
                }
            }

            dgvRoles.Columns[0].DefaultCellStyle.Format = "000";
        }

        private void frmListadoRoles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: //Buscar registros
                    Buscar();
                    break;
                case Keys.F2: //Agregar un registro
                    Nuevo();
                    break;
                case Keys.F3: //Editar un registro
                    Editar();
                    break;
                case Keys.F7:
                    Anular();
                    break;
                case Keys.Escape: //Salir del formulario
                    Cerrar();
                    break;
                default:
                    break;
            }
        }

        private void frmListadoRoles_Activated(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void dgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Editar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
