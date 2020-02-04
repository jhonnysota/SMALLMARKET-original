using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
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
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.Procesos
{
    public partial class frmProcesoCierreConciliacion : FrmMantenimientoBase
    {
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        public frmProcesoCierreConciliacion()
        {
            InitializeComponent();
        }

        private void frmProcesoCierreConciliacion_Load(object sender, EventArgs e)
        {
            cboPeriodo.DataSource = FechasHelper.CargarMesesContable("PM");
            cboPeriodo.ValueMember = "MesId";
            cboPeriodo.DisplayMember = "MesDes";
            cboPeriodo.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;


            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
            cboAnio.SelectedValue = Convert.ToInt32(Anio);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {                   
                String Anio = cboAnio.SelectedValue.ToString();
                int idLocal = Convert.ToInt32(cboAnio.SelectedValue.ToString());
                int Nivel = VariablesLocales.VersionPlanCuentasActual.UltimoNivel.Value;
                string Mes = cboPeriodo.SelectedValue.ToString();

                pbProgress.Visible = true;
                lblprogress.Visible = true;
                Cursor = Cursors.WaitCursor;

                AgenteContabilidad.Proxy.ProcesoCierreConciliacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, Anio, Mes);
        }


        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblprogress.Visible = false;
            Cursor = Cursors.Arrow;
            Global.MensajeComunicacion("Se proceso con exito");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                pbProgress.Visible = true;
                lblprogress.Visible = true;
                Cursor = Cursors.WaitCursor;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
