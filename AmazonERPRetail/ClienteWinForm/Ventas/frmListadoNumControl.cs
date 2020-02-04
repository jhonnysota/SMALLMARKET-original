using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoNumControl : FrmMantenimientoBase
    {

        public frmListadoNumControl()
        {
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvControl, true, false, 28, 23);
            AnchoColumnas();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvControl.Columns[0].Width = 45; //Código
            dgvControl.Columns[1].Width = 200; //Descripción
            dgvControl.Columns[2].Width = 35; //Nota de Crédito
            dgvControl.Columns[3].Width = 35; //Registro de Ventas
            dgvControl.Columns[4].Width = 35; //Código de Barras
            dgvControl.Columns[5].Width = 35; //Visible
            dgvControl.Columns[6].Width = 90; //Usuario Registro
            dgvControl.Columns[7].Width = 120; //Fecha Registro
            dgvControl.Columns[8].Width = 90; //Usuario Modificación
            dgvControl.Columns[9].Width = 120; //Fecha Modificación
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNumControl);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmNumControl
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
            try
            {
                if (bsControl.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNumControl);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    NumControlE numControlTmp = (NumControlE)bsControl.Current;

                    oFrm = new frmNumControl(numControlTmp)
                    {
                        MdiParent = MdiParent
                    };
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            if (bsControl.Count > 0)
            {

            }
        }

        public override void Buscar()
        {
            try
            {
                bsControl.DataSource = AgenteVentas.Proxy.ListarNumControl(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                bsControl.ResetBindings(false);

                lblRegistros.Text = "Registros " + bsControl.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmNumControl oFrm = sender as frmNumControl;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoNumControl_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
        }

        private void dgvControl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvControl_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvControl.Columns[0].DefaultCellStyle.Format = "00";
            }
        }

        #endregion

    }
}
