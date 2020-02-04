using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoPresupuesto : FrmMantenimientoBase
    {

        public frmListadoPresupuesto()
        {
            InitializeComponent();
            FormatoGrid(dgvPresupuesto, true);
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPresupuesto);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPresupuesto()
                {
                    MdiParent = this.MdiParent
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
            try
            {
                if (bsPresupuesto.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPresupuesto);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    PresupuestoE Presupuestotmp = (PresupuestoE)bsPresupuesto.Current;

                    if (Presupuestotmp != null)
                    {                                            
                       oFrm = new frmPresupuesto(Presupuestotmp);
                       oFrm.MdiParent = this.MdiParent;
                       oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                       oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsPresupuesto.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarPresupuesto(((PresupuestoE)bsPresupuesto.Current).idEmpresa, ((PresupuestoE)bsPresupuesto.Current).idPresupuesto);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        base.Anular();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                bsPresupuesto.DataSource = AgenteContabilidad.Proxy.ListarPresupuesto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsPresupuesto.ResetBindings(false);

                lblRegistros.Text = "Documentos - " + bsPresupuesto.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmPresupuesto oFrm = sender as frmPresupuesto;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoPresupuesto_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
        }

        private void frmListadoPresupuesto_Activated(object sender, EventArgs e)
        {
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
        }

        private void dgvPresupuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvPresupuesto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvPresupuesto.Columns[0].DefaultCellStyle.Format = "00";
            }
        }

        #endregion

    }
}
