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
    public partial class frmProcesoCierreCuentaResultado : FrmMantenimientoBase
    {
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        readonly BackgroundWorker _bw = new BackgroundWorker();
        public frmProcesoCierreCuentaResultado()
        {
            InitializeComponent();
        }

        private void frmProcesoCierrePreLiminar_Load(object sender, EventArgs e)
        {
            ///EMPRESA////
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);

            txtfecCierre.Text = "31/12/" + VariablesLocales.PeriodoContable.AnioPeriodo;
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
                    
            ParametrosContaE oParametros = AgenteContabilidad.Proxy.ObtenerParametrosConta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            string lsDiario = oParametros.DiarioCierre;
            string lsFile = oParametros.FileCierreResultado;

            if (!String.IsNullOrEmpty(lsDiario) && !String.IsNullOrEmpty(lsFile))
            {
                String Anio = VariablesLocales.PeriodoContable.AnioPeriodo;
                int idLocal = Convert.ToInt32(cboSucursal.SelectedValue.ToString());
                int Nivel = VariablesLocales.VersionPlanCuentasActual.UltimoNivel.Value;
                string Version = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                DateTime fecCier = Convert.ToDateTime(txtfecCierre.Text);
                DateTime fecCierre = fecCier.AddDays(1);
                TipoCambioE CambioCie = AgenteGenerales.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, fecCierre.ToString("yyyyMMdd"));
                Decimal tc = CambioCie.valVenta;
                pbProgress.Visible = true;
                lblprogress.Visible = true;
                Cursor = Cursors.WaitCursor;

                AgenteContabilidad.Proxy.ProcesoCierreCuentaResultado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, Version, Anio, fecCier, Nivel, tc, "01", lsDiario, lsFile);

            }
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
