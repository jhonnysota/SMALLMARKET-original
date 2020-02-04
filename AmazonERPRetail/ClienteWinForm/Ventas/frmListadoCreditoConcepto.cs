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
    public partial class frmListadoCreditoConcepto : FrmMantenimientoBase
    {
        
        public frmListadoCreditoConcepto()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCredito, true);
            
        }


        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = this.MdiChildren.FirstOrDefault(x => x is frmCreditoConcepto);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmCreditoConcepto();
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
            Form oFrm = this.MdiChildren.FirstOrDefault(x => x is frmCreditoConcepto);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            CreditoConceptoE CartaO = (CreditoConceptoE)bsCreditoConcepto.Current;

            if (CartaO != null)
            {

                oFrm = new frmCreditoConcepto(((CreditoConceptoE)bsCreditoConcepto.Current).idConcepto);
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();


            }
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCreditoConcepto oFrm = sender as frmCreditoConcepto;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        public override void Buscar()
        {
            try
            {
                bsCreditoConcepto.DataSource = AgenteVentas.Proxy.ListarCreditoConcepto();
                bsCreditoConcepto.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = "Creditos Conceptos [ " + bsCreditoConcepto.Count.ToString() + " Registros ]";
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
                if (bsCreditoConcepto.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarCreditoConcepto(((CreditoConceptoE)bsCreditoConcepto.Current).idConcepto);
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

        #region Eventos

        private void frmListadoCreditoConcepto_Load(object sender, EventArgs e)
        {
            Grid = true;

            Buscar();
        }

        private void dgvCredito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void frmListadoCreditoConcepto_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        #endregion
        
    }
}
