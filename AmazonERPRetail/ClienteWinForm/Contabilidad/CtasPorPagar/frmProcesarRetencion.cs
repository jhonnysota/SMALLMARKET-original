using Entidades.Almacen;
using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmProcesarRetencion : FrmMantenimientoBase
    {
        public frmProcesarRetencion()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        BackgroundWorker _bw = new BackgroundWorker() { WorkerSupportsCancellation = true };
        private Thread _backgroundWorkerThread;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        String Marquee = String.Empty;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {

            cboMesIni.DataSource = FechasHelper.CargarMesesContable("MA");
            cboMesIni.ValueMember = "MesId";
            cboMesIni.DisplayMember = "MesDes";
            cboMesIni.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            Int32 anioInicio = 0;
            Int32 anioFin = 0;
            Int32 anioInicio1 = 0;
            Int32 anioFin1 = 0;

            anioFin = Convert.ToInt32(Anio);
            anioFin1 = anioFin - 10;
            anioInicio = Convert.ToInt32(Anio);
            anioInicio1 = anioInicio - 10;

            cboAnioini.DataSource = FechasHelper.CargarAnios(anioInicio1, anioInicio);
            cboAnioini.ValueMember = "AnioId";
            cboAnioini.DisplayMember = "AnioDes";
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _backgroundWorkerThread = Thread.CurrentThread;
                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    String Anio = Convert.ToString(cboAnioini.SelectedValue);
                    String Mes = Convert.ToString(cboMesIni.SelectedValue);
                    AgenteCtasPorPagar.Proxy.ProcesarMigrarRetencion("0001", Anio, Mes,VariablesLocales.SesionUsuario.Empresa.IdEmpresa,VariablesLocales.SesionLocal.IdLocal);
                }
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;
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
            Marquee = String.Empty;
            Cursor = System.Windows.Forms.Cursors.Arrow;

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
                Global.MensajeComunicacion("Retencion Exitosa");
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        #endregion

        private void frmProcesarRetencion_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            cboAnioini.SelectedValue = Convert.ToInt32(Anio);
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                btnAceptar.Enabled = false;
                lblProcesando.Visible = true;
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Marquee = "Procesando...";
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_bw.IsBusy)
            {
                if (_backgroundWorkerThread != null)
                {
                    _backgroundWorkerThread.Abort();
                    _bw.CancelAsync();
                    _bw.Dispose();
                    GC.Collect();
                }
            }

            btnAceptar.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;

            Cursor = Cursors.WaitCursor;
            this.Close();
        }
    }
}
