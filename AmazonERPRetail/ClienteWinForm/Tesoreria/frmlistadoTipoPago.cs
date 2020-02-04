using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmlistadoTipoPago : FrmMantenimientoBase
    {
        
        public frmlistadoTipoPago()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        List<TipoPagoE> ListaTipoPago = null;

        #endregion

        #region Procedimientos Usuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 40; //CODTIPOPAGO
            dgvDocumentos.Columns[1].Width = 200; //DESTIPOPAGO
            dgvDocumentos.Columns[2].Width = 65; //DESTIPOPAGO
            dgvDocumentos.Columns[3].Width = 66; //DESTIPOPAGO
            dgvDocumentos.Columns[4].Width = 65; //DESTIPOPAGO
            dgvDocumentos.Columns[5].Width = 90; //USUARIOREG
            dgvDocumentos.Columns[6].Width = 120; //FECHA REG
            dgvDocumentos.Columns[7].Width = 90; //USUARIOMOD
            dgvDocumentos.Columns[8].Width = 150; // FECHA MOD
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoPago);

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

                //sino existe la instancia se crea una nueva
                oFrm = new frmTipoPago();
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
                ListaTipoPago = AgenteTesoreria.Proxy.ListarTipoPago();

                bsTipoPago.DataSource = ListaTipoPago;
                bsTipoPago.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = String.Format("Registros {0}", ListaTipoPago.Count.ToString());
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
                if (bsTipoPago.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoPago);

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

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmTipoPago(((TipoPagoE)bsTipoPago.Current).codTipoPago);
                    oFrm.MdiParent = MdiParent;
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
                if (bsTipoPago.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteTesoreria.Proxy.AnularTipoPago(((TipoPagoE)bsTipoPago.Current).codTipoPago, VariablesLocales.SesionUsuario.Credencial);
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

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmTipoPago oFrm = sender as frmTipoPago;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void frmlistadoTipoPago_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvDocumentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((Boolean)dgvDocumentos.Rows[e.RowIndex].Cells["indEstado"].Value == true)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
