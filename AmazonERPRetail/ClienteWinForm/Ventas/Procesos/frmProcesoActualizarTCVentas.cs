using System;
using System.ComponentModel;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Infraestructura;

namespace ClienteWinForm.Almacen.Procesos
{
    public partial class frmProcesoActualizarTCVentas : FrmMantenimientoBase
    {

        public frmProcesoActualizarTCVentas()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        #region Variables
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        BackgroundWorker _bw = new BackgroundWorker() { WorkerSupportsCancellation = true };
        //String Marquee = String.Empty;
        //String sParametro = string.Empty;
        ////Int32 cboTip = 0;
        ////string Costos = "";
        #endregion

        private void frmProcesoGenerarSalidaAlmacen_Load(object sender, EventArgs e)
        {
            Grid = true;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
        }

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                AgenteVentas.Proxy.ActualizaTCVentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpInicio.Value.ToString("yyyyMMdd"), dtpFin.Value.ToString("yyyyMMdd"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAceptar.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;

            if (e.Error != null)
            {
                Global.MensajeError(String.Format("Ha ocurrido la excepción: {0}", e.Error.Message));
            }
            else if (e.Cancelled)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                Global.MensajeComunicacion("Generado");
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                btnAceptar.Enabled = false;
                lblProcesando.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion


    }
}
