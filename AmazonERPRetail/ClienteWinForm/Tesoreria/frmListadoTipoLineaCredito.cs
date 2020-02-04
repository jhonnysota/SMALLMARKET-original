using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Recursos;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoTipoLineaCredito : FrmMantenimientoBase
    {

        public frmListadoTipoLineaCredito()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvLineas, true);
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }

        #endregion

        #region Procedimientos de Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoLineaCredito);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmTipoLineaCredito();
                oFrm.MdiParent = MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoLineaCredito);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmTipoLineaCredito(((TipoLineaCreditoE)bsTipoLinea.Current).idLinea);
                oFrm.MdiParent = MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                bsTipoLinea.DataSource = AgenteTesoreria.Proxy.ListarTipoLineaCredito(chkIncluir.Checked);
                bsTipoLinea.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsTipoLinea.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteTesoreria.Proxy.AnularTipoLineaCredito(((TipoLineaCreditoE)bsTipoLinea.Current).idLinea);
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

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmTipoLineaCredito oFrm = sender as frmTipoLineaCredito;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoTipoLineaCredito_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void bsTipoLinea_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsTipoLinea.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLineas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Editar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkIncluir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncluir.Checked)
            {
                dgvLineas.Columns[2].Visible = true;
                dgvLineas.Columns[3].Visible = true;
            }
            else
            {
                dgvLineas.Columns[2].Visible = false;
                dgvLineas.Columns[3].Visible = false;
            }

            Buscar();
        }

        private void dgvLineas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvLineas.Rows[e.RowIndex].Cells["indEstado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
        }

        #endregion

    }
}
