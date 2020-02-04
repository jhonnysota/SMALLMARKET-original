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
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmCalculodeComision : FrmMantenimientoBase
    {

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<ComisionesCalE> oComisiones = null;
        ComisionesCalE oComisionescal = null;
        string sParametro = string.Empty;

        readonly BackgroundWorker _bw = new BackgroundWorker();

        Int32 Periodo;
        DateTime Inicio;
        DateTime Fin;
        #endregion

        #region Constructores

        public frmCalculodeComision()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        public frmCalculodeComision(Int32 idEmpresa, Int32 idPeriodo)
            : this()
        {
            oComisionescal = AgenteVentas.Proxy.ObtenerPeriodoComisioncal(idEmpresa, idPeriodo);
        }

        #endregion Constructores

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //////Periodo/////////
            List<PeriodoComisionE> ListaComision = AgenteVentas.Proxy.ListarPeriodoComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<PeriodoComisionE>(cboPeriodo, (from x in ListaComision orderby x.Anio descending, x.Mes descending select x).ToList(), "idPeriodo", "Nombre", false);
        }

        #endregion Procedimientos de Usuario

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            oComisiones = AgenteVentas.Proxy.CalculoComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Periodo, Inicio, Fin);
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

        #endregion Eventos de Usuario

        #region Eventos

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Periodo = Convert.ToInt32(cboPeriodo.SelectedValue);
                Inicio = dtpInicio.Value.Date;
                Fin = dtpFin.Value.Date;

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

            cboPeriodo_SelectionChangeCommitted(new object(), new EventArgs());
        }
        
        private void cboPeriodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Periodo = Convert.ToInt32(cboPeriodo.SelectedValue);
            oComisionescal = AgenteVentas.Proxy.ObtenerPeriodoComisioncal(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Periodo);

            dtpInicio.Value = oComisionescal.FechaInicial;
            dtpFin.Value = oComisionescal.FechaFinal;
        }

        #endregion Eventos
    }
}
