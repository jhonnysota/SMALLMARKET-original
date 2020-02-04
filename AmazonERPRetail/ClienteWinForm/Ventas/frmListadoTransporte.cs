using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoTransporte : FrmMantenimientoBase
    {
        public frmListadoTransporte()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();

            FormatoGrid(dgvTransportes, true);
            
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<TransporteE> oListaTransportes = null;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTransporte);

                if (oFrm != null)
                {
                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmTransporte();
                oFrm.MdiParent = MdiParent;
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTransporte);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                if (((TransporteE)bsTransporte.Current).indEstado)
                {
                    Global.MensajeComunicacion("Este registro se encuentra anulado. No podra hacer modificaciones.");
                }

                oFrm = new frmTransporte(((TransporteE)bsTransporte.Current).idTransporte);
                oFrm.MdiParent = MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();                
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
                if (chkIndBaja.Checked)
                {
                    bsTransporte.DataSource = oListaTransportes = AgenteVentas.Proxy.ListarTransporte(txtRazonSocial.Text.Trim(), txtRuc.Text.Trim(), false, true);
                }
                else
                {
                    bsTransporte.DataSource = oListaTransportes = AgenteVentas.Proxy.ListarTransporte(txtRazonSocial.Text.Trim(), txtRuc.Text.Trim(), false, false);
                }

                LblRegistros.Text = "Registros " + bsTransporte.Count.ToString();
                dgvTransportes.AutoResizeColumns();
                base.Buscar();
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
                if (bsTransporte.Count > Variables.Cero)
                {
                    if (((TransporteE)bsTransporte.Current).indEstado)
                    {
                        Global.MensajeComunicacion("Este registro se encuentra anulado. No puede anularlo por segunda vez.");
                        return;
                    }

                    if (Global.MensajeConfirmacion("Se anulará el transporte con todos sus items ingresados.\n\rDesea continuar ?") == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.AnulacionCompleta(((TransporteE)bsTransporte.Current).idTransporte);
                        Global.MensajeComunicacion("Registros Anulados.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmTransporte oFrm = sender as frmTransporte;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                if (oListaTransportes != null && oListaTransportes.Count > Variables.Cero)
                {
                    if (oFrm.Opcion == (int)EnumOpcionGrabar.Actualizar)
                    {
                        for (Int32 i = 0; i < oListaTransportes.Count; i++)
                        {
                            if (oListaTransportes[i].idTransporte == oFrm.oTransporte.idTransporte)
                            {
                                oListaTransportes[i] = oFrm.oTransporte;
                                i = oListaTransportes.Count;
                            }
                        }

                        bsTransporte.DataSource = oListaTransportes;
                        bsTransporte.ResetBindings(false);
                    }
                    else
                    {
                        oListaTransportes.Add(oFrm.oTransporte);
                        bsTransporte.DataSource = oListaTransportes;
                        bsTransporte.ResetBindings(false);
                        bsTransporte.MoveNext();
                    }
                }
            }
        }

        #endregion

        #region Eventos

        private void frmListadoTransporte_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void frmListadoTransporte_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void dgvTransportes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvTransportes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvTransportes.Rows[e.RowIndex].Cells["chkIndEstado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            if (e.ColumnIndex == Variables.Cero)
            {
                dgvTransportes.Columns[0].DefaultCellStyle.Format = "00";
            }
        }

        private void txtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar();
            }
        }

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar();
            }
        }

        private void chkIndBaja_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

    }
}
