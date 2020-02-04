using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
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

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmListadoNumControlCompra : FrmMantenimientoBase
    {
        public frmListadoNumControlCompra()
        {
            InitializeComponent();
            FormatoGrid(dgvControl, true, false, 28, 23);
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNumControlCompra);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmNumControlCompra();
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
            try
            {
                if (bsNumControlCompra.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNumControlCompra);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    NumControlCompraE numControlcompraTmp = (NumControlCompraE)bsNumControlCompra.Current;

                    oFrm = new frmNumControlCompra(numControlcompraTmp);
                    oFrm.MdiParent = this.MdiParent;
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
            try
            {
                if (bsNumControlCompra.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteCtasPorPagar.Proxy.EliminarNumControlCompra(((NumControlCompraE)bsNumControlCompra.Current).idEmpresa, (((NumControlCompraE)bsNumControlCompra.Current).idLocal), ((NumControlCompraE)bsNumControlCompra.Current).idControl);
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
                bsNumControlCompra.DataSource = AgenteCtasPorPagar.Proxy.ListarNumControlCompra(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                bsNumControlCompra.ResetBindings(false);

                lblRegistros.Text = "Documentos - " + bsNumControlCompra.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        public override void Imprimir()
        {
            base.Imprimir();
        }

        #endregion

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmNumControlCompra oFrm = sender as frmNumControlCompra;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoNumControlCompra_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
        }

        private void frmListadoNumControlCompra_Activated(object sender, EventArgs e)
        {
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
