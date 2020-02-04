using Infraestructura;
using Infraestructura.Enumerados;
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

namespace ClienteWinForm.Contabilidad.Procesos
{
    public partial class frmDisFactor : FrmMantenimientoBase
    {

        #region Variables
        DateTime TiempoIni;
        DateTime TiempoFin;
        Decimal Venta;
     ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        public frmDisFactor()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmDisFactor_Load(object sender, EventArgs e)
        {
            Grid = true;


            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

                //procesa
                pbProgress.Visible = true;
                lblprogress.Visible = true;
                _bw.RunWorkerAsync();
        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {

            TiempoIni = dtpFecIni.Value;
            TiempoFin = dtpFecFin.Value;
            Venta = Convert.ToDecimal(txtVenta.Text);



            AgenteContabilidad.Proxy.ProcesoDistribucionFactor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, TiempoIni, TiempoFin,Venta, VariablesLocales.SesionUsuario.Credencial);

        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblprogress.Visible = false;
            _bw.CancelAsync();
            _bw.Dispose();

            Global.MensajeComunicacion("Se proceso con exito");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
