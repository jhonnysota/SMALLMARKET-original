using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmPagarComision : FrmMantenimientoBase
    {

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<ComisionesCalE> oComisiones = null;
        ComisionesCalE oComisionescal = null;
        string sParametro = string.Empty;

        readonly BackgroundWorker _bw = new BackgroundWorker();

        Int32 PeriodoIni;
        Int32 PeriodoFin;
        //DateTime Inicio;
        DateTime Fin;
        #endregion

        public frmPagarComision()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        public frmPagarComision(Int32 idEmpresa, Int32 idPeriodo)
            : this()
        {
            oComisionescal = AgenteVentas.Proxy.ObtenerPeriodoComisioncal(idEmpresa, idPeriodo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Fin = dtpFin.Value.Date;
                PeriodoIni = Convert.ToInt32(cboPeriodo.SelectedValue);
                PeriodoFin = Convert.ToInt32(cboPeriodo2.SelectedValue);
                //procesa
                pbProgress.Visible = true;
                lblprogresando.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmCalculodeComision_Load(object sender, EventArgs e)
        {
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            oComisiones = AgenteVentas.Proxy.PagarComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, PeriodoIni, PeriodoFin, Fin);
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblprogresando.Visible = false;
            _bw.CancelAsync();
            _bw.Dispose();

            Global.MensajeComunicacion("Comisiones Calculadas");
            this.Close();
        }

        #region Procedimientos de Usuario


        void LlenarCombos()
        {
            //////Periodo/////////
            List<PeriodoComisionE> ListaComision = AgenteVentas.Proxy.ListarPeriodoComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<PeriodoComisionE>(cboPeriodo, (from x in ListaComision orderby x.Anio descending, x.Mes descending select x).ToList(), "idPeriodo", "Nombre", false);

            List<PeriodoComisionE> ListaComision2 = AgenteVentas.Proxy.ListarPeriodoComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<PeriodoComisionE>(cboPeriodo2, (from x in ListaComision2 orderby x.Anio descending, x.Mes descending select x).ToList(), "idPeriodo", "Nombre", false);

        }

        #endregion


    }
}
