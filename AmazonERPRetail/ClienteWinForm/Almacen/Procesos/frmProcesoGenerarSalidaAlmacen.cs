using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Almacen.Procesos
{
    public partial class frmProcesoGenerarSalidaAlmacen : FrmMantenimientoBase
    {

        public frmProcesoGenerarSalidaAlmacen()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        BackgroundWorker _bw = new BackgroundWorker() { WorkerSupportsCancellation = true };
        String Marquee = String.Empty;
        //Int32 Letra = 0;
        String sParametro = string.Empty;
        Int32 cboTip = 0;
        string Costos = "";
        #endregion

        void LlenarCombos()
        {

            List<ParTabla> ListarTipoArticulos = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("TIPART");
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListarTipoArticulos orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);

            List<CCostosE> ListaCostos = AgenteMaestros.Proxy.ListarCCostosPorNivel(Convert.ToInt32(VariablesLocales.SesionLocal.IdEmpresa), 1);
            ComboHelper.RellenarCombos<CCostosE>(cboCCostos, ListaCostos, "idCCostos", "desCCostos", false);
        }

        private void frmProcesoGenerarSalidaAlmacen_Load(object sender, EventArgs e)
        {
            Grid = true;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                 AgenteAlmacen.Proxy.ProcesoGenerarSalidaAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, cboTip, Costos, dtpInicio.Value.ToString("yyyyMMdd"), dtpFin.Value.ToString("yyyyMMdd"));
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
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                cboTip = Convert.ToInt32(cboTipoArticulo.SelectedValue);
                Costos = Convert.ToString(cboCCostos.SelectedValue);
                btnAceptar.Enabled = false;
                lblProcesando.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
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
