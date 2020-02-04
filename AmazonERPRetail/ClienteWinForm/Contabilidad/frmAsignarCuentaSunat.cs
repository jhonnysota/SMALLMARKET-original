using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
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
using System.Threading;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmAsignarCuentaSunat : FrmMantenimientoBase
    {
        public frmAsignarCuentaSunat()
        {
            InitializeComponent();
            LlenarCombos();
            FormatoGrid(dgvDocumentos, true);
        }

        #region Variables
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<PlanCuentasE> ListaPlanCuentas = null;
        int anioInicio = 0;
        int anioFin = 0;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        BackgroundWorker _bw = new BackgroundWorker() { WorkerSupportsCancellation = true };
        private Thread _backgroundWorkerThread;
        String Marquee = String.Empty;
        Int32 Letra = 0;
        String anio = String.Empty;
        String Mes = String.Empty;
        #endregion


        #region Procedimientos de Usuario

        void LlenarCombos()
        {

            /////MES////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboMes.DataSource = oDt;
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

        }




        public override void Buscar()
        {
            try
            {
                anio = Convert.ToString(cboAño.SelectedValue);
                Mes = Convert.ToString(cboMes.SelectedValue);
                ListaPlanCuentas = AgenteContabilidad.Proxy.ListarCtaCuentaSunat(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, anio, Mes);

                 bsPlanCuentas.DataSource = ListaPlanCuentas;
                 bsPlanCuentas.ResetBindings(false);

                labelDegradado1.Text = "Plan Cuentas " + bsPlanCuentas.Count.ToString() + " Registros";
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
                if (bsPlanCuentas.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAsignarCuentas);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }


                    PlanCuentasE PLancuenta = (PlanCuentasE)bsPlanCuentas.Current;
                    oFrm = new frmAsignarCuentas(PLancuenta);
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

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnGenerar.Enabled = true;
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
                Global.MensajeComunicacion("Generar Completado");
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

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
                    ListaPlanCuentas = AgenteContabilidad.Proxy.GenerarBalanceComprobacionSunat(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, anio, Mes);
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

        #endregion

        #region  Eventos
        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmAsignarCuentas oFrm = sender as frmAsignarCuentas;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }


        private void frmAsignarCuentaSunat_Load(object sender, EventArgs e)
        {
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            cboMes.SelectedValue = 12;
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
        }

        private void dgvPeriodos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            try
            {
                anio = Convert.ToString(cboAño.SelectedValue);
                Mes = Convert.ToString(cboMes.SelectedValue);
                btnGenerar.Enabled = false;
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

        #endregion

    }
}
