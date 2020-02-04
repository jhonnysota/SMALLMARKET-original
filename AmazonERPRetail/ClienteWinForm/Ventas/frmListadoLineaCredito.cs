using Entidades.Ventas;
using Infraestructura;
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

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoLineaCredito : FrmMantenimientoBase
    {
        
        public frmListadoLineaCredito()
        {
            InitializeComponent();
            FormatoGrid(dgvDocumentos, true);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<LineaCreditoE> oLineaCredito = null;

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLineaCredito);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmLineaCredito();
                oFrm.MdiParent = this.MdiParent;
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
                oLineaCredito = AgenteVentas.Proxy.ListarLineaCredito();

                bsLineaCredito.DataSource = oLineaCredito;
                bsLineaCredito.ResetBindings(false);

                base.Buscar();
                LblTitulo.Text = "Linea Creditos [ " + bsLineaCredito.Count.ToString() + " Registros ]";
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
                if (bsLineaCredito.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMedioPago);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }


                    oFrm = new frmLineaCredito(((LineaCreditoE)bsLineaCredito.Current).idPersona, ((LineaCreditoE)bsLineaCredito.Current).idEmpresa, ((LineaCreditoE)bsLineaCredito.Current).item);
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
                if (bsLineaCredito.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarLineaCredito(((LineaCreditoE)bsLineaCredito.Current).idPersona, ((LineaCreditoE)bsLineaCredito.Current).idEmpresa, ((LineaCreditoE)bsLineaCredito.Current).item);
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


        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmLineaCredito oFrm = sender as frmLineaCredito;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoLineaCredito_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void frmListadoLineaCredito_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }
    }
}
