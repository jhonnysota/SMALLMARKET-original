using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
//using Entidades.Asistencia;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using System.Threading;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmProcesoMayorizacion : FrmMantenimientoBase
    {
        public frmProcesoMayorizacion()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<Con_SaldosE> oProceso = null;
        BackgroundWorker _bw = new BackgroundWorker(){ WorkerSupportsCancellation = true };
        private Thread _backgroundWorkerThread;

        String Marquee = String.Empty;
        Int32 Letra = 0;
        String sParametro = string.Empty;
        //String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        String Anio = VariablesLocales.PeriodoContable.AnioPeriodo;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, (from x in listaLocales orderby x.IdLocal select x).ToList(), "idLocal", "Nombre", false);

            /////MES////
            //DataTable oDt = FechasHelper.CargarMesesContable("MA");
            //DataRow Fila = oDt.NewRow();
            //Fila["MesId"] = "0";
            //Fila["MesDes"] = Variables.Todos;
            //oDt.Rows.Add(Fila);

            //oDt.DefaultView.Sort = "MesId";
            cboMesIni.DataSource = FechasHelper.CargarMesesContable("MA"); // oDt;
            cboMesIni.ValueMember = "MesId";
            cboMesIni.DisplayMember = "MesDes";
            cboMesIni.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////MES////
            //DataTable oET = FechasHelper.CargarMesesContable("MA");
            //DataRow Fila2 = oET.NewRow();
            //Fila2["MesId"] = "0";
            //Fila2["MesDes"] = Variables.Todos;
            //oET.Rows.Add(Fila2);

            //oET.DefaultView.Sort = "MesId";
            cboMesFin.DataSource = FechasHelper.CargarMesesContable("MA"); //oET;
            cboMesFin.ValueMember = "MesId";
            cboMesFin.DisplayMember = "MesDes";
            cboMesFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////ANIOS/////
            Int32 anioInicio = 0;
            Int32 anioFin = 0;

            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
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
                    oProceso = AgenteContabilidad.Proxy.MayorizarMayor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                        Convert.ToInt32(cboSucursales.SelectedValue),
                                                                        Convert.ToString(cboMesIni.SelectedValue),
                                                                        Convert.ToString(cboAnio.SelectedValue),
                                                                        Convert.ToString(cboMesFin.SelectedValue),
                                                                        Convert.ToString(cboAnio.SelectedValue),
                                                                        VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);
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
            Letra = 0;
            timer1.Enabled = false;
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
                Global.MensajeComunicacion("Mayorización Exitosa");
            }

            _bw.CancelAsync();
            _bw.Dispose();            
        }

        #endregion

        #region Eventos

        private void frmProcesoMayorizacion_Load(object sender, EventArgs e)
        {
            cboAnio.SelectedValue = Convert.ToInt32(Anio);
            cboMesIni.SelectedValue = "00";
            cboMesFin.SelectedValue = "13";
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
                timer1.Enabled = true;
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
            //if (_backgroundWorkerThread != null)
            //{
            //    _backgroundWorkerThread.Abort();
            //    _bw.CancelAsync();
            //    _bw.Dispose();                
            //    GC.Collect();
            //}

            //timer1.Enabled = false;
            //btnAceptar.Enabled = true;
            //pbProgress.Visible = false;
            //lblProcesando.Visible = false;
            //lblProcesando.Text = String.Empty;
            //Marquee = String.Empty;
            //Letra = 0;

            //Cursor = Cursors.WaitCursor;
            //this.Close();

            if (_bw.IsBusy)
            {
                //if (_backgroundWorkerThread != null)
                //{
                //    _backgroundWorkerThread.Abort();
                _bw.CancelAsync();
                _bw.Dispose();
                //GC.Collect();
                //} 
            }

            timer1.Enabled = false;
            btnAceptar.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;
            Letra = 0;

            Cursor = Cursors.Arrow;
            Dispose();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Letra += 1;

            if (Letra == Marquee.Length)
            {
                lblProcesando.Text = String.Empty;
                Letra = 0;
            }
            else
            {
                lblProcesando.Text += Marquee.Substring(Letra - 1, 1);
            }
        }

        #endregion
    }
}
