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
    public partial class frmProcesoCierreCuentaBalance : FrmMantenimientoBase
    {

        #region Constructores

        public frmProcesoCierreCuentaBalance()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string AnioCierre = VariablesLocales.PeriodoContable.AnioPeriodo;
        string AnioApertura = Convert.ToString(Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo) + 1);

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {

            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            int idLocal = Convert.ToInt32(cboSucursal.SelectedValue.ToString());

            DateTime fecCier = Convert.ToDateTime(txtfecCierre.Text);
            DateTime fecApertura = Convert.ToDateTime(txtfecApertura.Text);

            string libro = cboLibro.SelectedValue.ToString();
            string file = cboFile.SelectedValue.ToString();
            string mes = cboPeriodo.SelectedValue.ToString();

            string Version = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            int Nivel = VariablesLocales.VersionPlanCuentasActual.UltimoNivel.Value; 
            DateTime fecCierre = fecCier.AddDays(1);
            TipoCambioE CambioCie = AgenteGenerales.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, fecCierre.ToString("yyyyMMdd"));
            Decimal tcCie = CambioCie.valVenta;
            Decimal tcApe = CambioCie.valVenta;
            string idMoneda = "01";
            string CtaCie = "591101";
            string CtaApe = "591101";

            pbProgress.Visible = true;
            lblprogress.Visible = true;
            Cursor = Cursors.WaitCursor;

            AgenteContabilidad.Proxy.EliminaCierreBalance(idEmpresa, idLocal, AnioCierre, libro, file);

            AgenteContabilidad.Proxy.MayorizarMayor(idEmpresa, VariablesLocales.SesionLocal.IdLocal, "13", AnioCierre, "13", AnioCierre, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);

            AgenteContabilidad.Proxy.ProcesoCierreCuentaBalance(idEmpresa, idLocal, Version, AnioCierre, mes, AnioApertura, fecCier, fecApertura, Nivel, tcCie, tcApe, idMoneda, CtaCie, CtaApe, libro, file);

        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblprogress.Text = String.Empty;
            lblprogress.Visible = false;
            Cursor = Cursors.Arrow;

            _bw.CancelAsync();
            _bw.Dispose();

            Global.MensajeComunicacion("Se proceso con exito");
        }

        #endregion

        #region Eventos

        private void frmProcesoCierrePreLiminar_Load(object sender, EventArgs e)
        {
            ParametrosContaE oParametros = AgenteContabilidad.Proxy.ObtenerParametrosConta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            string lsDiario = oParametros.DiarioCierre;
            string lsFile = oParametros.FileCierreBalance;

            if (!String.IsNullOrEmpty(lsDiario) && !String.IsNullOrEmpty(lsFile))
            {

                ///EMPRESA////
                List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                             where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                             select x).ToList();//AgenteMaestros.Proxy.ListarLocalPorEmpresa(VariablesLocales.SesionLocal.IdEmpresa, true, false);
                ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);

                /////PERIODO////
                DataTable oDt = FechasHelper.CargarMesesContable("MA");
                DataRow Fila = oDt.NewRow();
                Fila["MesId"] = "0";
                Fila["MesDes"] = Variables.Todos;
                oDt.Rows.Add(Fila);

                oDt.DefaultView.Sort = "MesId";
                cboPeriodo.DataSource = oDt;
                cboPeriodo.ValueMember = "MesId";
                cboPeriodo.DisplayMember = "MesDes";
                cboPeriodo.SelectedValue = "00";

                ///LIBROS///
                List<ComprobantesE> ListaTipoComprobante = AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                ComprobantesE p = new ComprobantesE();
                p.idComprobante = Variables.Cero.ToString();
                p.desComprobanteComp = Variables.Todos;
                ListaTipoComprobante.Add(p);
                ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);

                cboLibro.SelectedValue = lsDiario;
                cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                cboFile.SelectedValue = lsFile;

                txtfecCierre.Text = "31/12/" + VariablesLocales.PeriodoContable.AnioPeriodo;
                txtfecApertura.Text = "01/01/" + AnioApertura;

                CheckForIllegalCrossThreadCalls = false;
                _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
                _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
                _bw.WorkerSupportsCancellation = true;
            }
            else
            {
                Global.MensajeComunicacion("Defina los Parametros para el Diario de Cierre !!");
                btnAceptar.Enabled = false;
                this.Close();
            }

        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(VariablesLocales.SesionLocal.IdEmpresa, cboLibro.SelectedValue.ToString());
                    ComprobantesFileE File = new ComprobantesFileE();
                    File.numFile = Variables.Cero.ToString();
                    File.desFileComp = Variables.Todos;
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);
                    cboFile.SelectedValue = Variables.Cero.ToString();

                    if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            pbProgress.Visible = true;
            lblprogress.Visible = true;
            Cursor = Cursors.WaitCursor;
            _bw.RunWorkerAsync();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
