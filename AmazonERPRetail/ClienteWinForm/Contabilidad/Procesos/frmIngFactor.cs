using Entidades.Contabilidad;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.Procesos
{
    public partial class frmIngFactor : FrmMantenimientoBase
    {

        #region Variables
        DateTime FechaProceso;
        string diario;
        string file;
        Decimal Venta;
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        public frmIngFactor()
        {
            InitializeComponent();

            Combos();
        }

        public void Combos()
        {

            // Libro
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiario, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboDiario.SelectedValue = "08";

            // File
            List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboDiario.SelectedItem).ListaComprobantesFiles);
            ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
            ListaFiles.Add(File);
            ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);
            cboFile.SelectedValue = "06";


        }


        private void frmIngFactor_Load(object sender, EventArgs e)
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

            FechaProceso = dtpFecProceso.Value;
            diario = Convert.ToString(cboDiario.SelectedValue);
            file = Convert.ToString(cboFile.SelectedValue);
            Venta = Convert.ToDecimal(txtVenta.Text);

            AgenteContabilidad.Proxy.ProcesoIngresoAlmacenFactor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, FechaProceso, diario, file, VariablesLocales.SesionUsuario.Credencial);

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

        private void cboDiario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboDiario.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboDiario.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);
                    cboFile.SelectedValue = "06";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
