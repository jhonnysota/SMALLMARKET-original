using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEEFFGananciasyPerdidas : FrmMantenimientoBase
    {

        public frmReporteEEFFGananciasyPerdidas()
        {
            InitializeComponent();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        //List<ReporteEEFFItemE> oListaReporte;
        readonly BackgroundWorker _bw = new BackgroundWorker();

        int idEEFF = 0;
        string anio = "";
        string mesFin = "";
        string Moneda = "";
        string desEEFF = "";
        String idCCostos = "";
        //string mesInicio = "00";
        string indAcumulado = "";
        string indCCostos = "";
        string fl_TipoReporte = "";

        String Marque = String.Empty;
        Int32 letra = 0;
        Boolean chkTodos = true;

        #endregion

        #region Procedimientos Heredados

        public override bool ValidarGrabacion()
        {
            if (idEEFF == 0)
            {
                Global.MensajeFault("Debe de seleccionar el Estado Financiero");
                return false;
            }

            if (indCCostos == "S")
            {
                if (idCCostos.Length == 0)
                {
                    Global.MensajeFault("Debe de seleccionar Centros de Costos");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        public override void Buscar()
        {
            if (ValidarGrabacion())
            {
                Reporte(); 
            }
        } 

        #endregion

        #region Procedimientos de Usuario

        void Reporte()
        {
            Decimal TipoCambio = 0;
            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            string PlanCuentasActual = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

            if (chbtipo_cambio.Checked)
            {
                TipoCambio = Convert.ToDecimal(txttipocambio.Text);
            }
            else
            {
                TipoCambio = Variables.Cero;
            }

            //oListaReporte = AgenteContabilidad.Proxy.ListarRptEEFFGananciasPerdidas(idEmpresa, anio, mesInicio, mesFin, idEEFF, idCCostos, indAcumulado, indCCostos, PlanCuentasActual, fl_TipoReporte, TipoCambio, Convert.ToInt32(cboNivel.SelectedValue));

            //if (oListaReporte.Count == 0)
            //{
            //    Global.MensajeFault("No hay registros");
            //    return;
            //}
        }

        void LlenarCombos()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            /////PERIODO////
            cboMesFinal.DataSource = FechasHelper.CargarMesesContable("MA");
            cboMesFinal.ValueMember = "MesId";
            cboMesFinal.DisplayMember = "MesDes";
            cboMesFinal.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////EEFF////
            List<EEFFE> oListaEEFF = AgenteContabilidad.Proxy.ListarEEFF(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, "", true);
            oListaEEFF.Add(new EEFFE { idEEFF = 0, desSeccion = "<SELECCIONE>" });
            ComboHelper.LlenarCombos<EEFFE>(cboEEFF, oListaEEFF.OrderBy(x => x.idEEFF).ToList(), "idEEFF", "desSeccion");

            //Cargando Años
            cboAnio.DataSource = FechasHelper.CargarAnios((VariablesLocales.FechaHoy.Year - 10), VariablesLocales.FechaHoy.Year);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
            cboAnio.SelectedValue = VariablesLocales.PeriodoContable.AnioPeriodo;

            Int32 Niveles = AgenteMaestro.Proxy.MaxNivelCCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ParTabla Item = null;
            List<ParTabla> Lista = new List<ParTabla>();

            for (int i = 1; i <= Niveles; i++)
            {
                Item = new ParTabla() { IdParTabla = i, Nombre = "Nivel " + i.ToString() };
                Lista.Add(Item);
            }

            ComboHelper.LlenarCombos<ParTabla>(cboNivel, Lista);

            if (VariablesLocales.oConParametros != null)
            {
                if (VariablesLocales.oConParametros.numNivelCCosto > 0)
                {
                    cboNivel.SelectedValue = Convert.ToInt32(VariablesLocales.oConParametros.numNivelCCosto);
                    cboNivel_SelectionChangeCommitted(new Object(), new EventArgs());
                }
            }
            else
            {
                cboNivel_SelectionChangeCommitted(new Object(), new EventArgs());
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Reporte();
            }
            catch (Exception ex)
            {
                btAceptar.Enabled = true;
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblprogress.Visible = false;
            timer.Enabled = false;
            btAceptar.Enabled = true;
            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                //if (oListaReporte.Count > 0)
                //{
                //    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasListado);

                //    if (oFrm != null)
                //    {
                //        if (oFrm.WindowState == FormWindowState.Minimized)
                //        {
                //            oFrm.WindowState = FormWindowState.Normal;
                //        }

                //        oFrm.BringToFront();
                //        return;
                //    }

                //    //oFrm = new frmReporteEEFFGananciasyPerdidasListado(oListaReporte, Moneda, idEEFF, desEEFF, idCCostos, fl_TipoReporte, mesInicio, mesFin, indAcumulado, anio);
                //    oFrm = new frmReporteEEFFGananciasyPerdidasListado();
                //    oFrm.MdiParent = MdiParent;
                //    oFrm.Show();
                //}
            }
        }

        #endregion

        #region Eventos

        private void frmReporteEEFFGanaciasPerdidas_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;

            LlenarCombos();
        }

        private void chbindCCostos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbindCCostos.Checked)
            {
                chbListaCCostos.Enabled = true;
                lnkTodos.Enabled = true;
            }
            else
            {
                chbListaCCostos.Enabled = false;
                lnkTodos.Enabled = false;
            }
        }

        private void chbtipo_cambio_CheckedChanged(object sender, EventArgs e)
        {
            if (chbtipo_cambio.Checked)
            {
                txttipocambio.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txttipocambio.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txttipocambio.Text = "0.0000";
            }
        }

        private void rdbTipoReporteCCostos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTipoReporteCCostos.Checked)
            {
                pnlCCostos.Visible = false;
                chbAcumulado.Visible = true;
                chbindCCostos.Checked = false;
                chbListaCCostos.Enabled = false;
            }
            else
            {
                pnlCCostos.Visible = true;
                chbAcumulado.Visible = false;
            }
        }

        private void lnkTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chbListaCCostos.Items.Count; i++)
            {
                chbListaCCostos.SetItemChecked(i, chkTodos);
            }

            if (chkTodos)
                chkTodos = false;
            else
                chkTodos = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                letra += 1;

                if (letra == Marque.Length)
                {
                    lblprogress.Text = String.Empty;
                    letra = 0;
                }
                else
                {
                    lblprogress.Text += Marque.Substring(letra - 1, 1);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txttipocambio_Enter(object sender, EventArgs e)
        {
            txttipocambio.SelectAll();
        }

        private void txttipocambio_MouseClick(object sender, MouseEventArgs e)
        {
            txttipocambio.SelectAll();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            idEEFF = Convert.ToInt32(cboEEFF.SelectedValue.ToString());
            anio = cboAnio.SelectedValue.ToString();
            mesFin = cboMesFinal.SelectedValue.ToString();
            Moneda = cboMoneda.SelectedValue.ToString();
            desEEFF = cboEEFF.Text;
            //mesInicio = "00";
            indAcumulado = (chbAcumulado.Checked ? "S" : "N");
            indCCostos = (chbindCCostos.Checked ? "S" : "N");
            fl_TipoReporte = (rdbTipoReporteMes.Checked ? "0" : "1");
            idCCostos = "";

            int count = chbListaCCostos.CheckedItems.Count;

            for (int i = 0; i < count; i++)
            {
                idCCostos += ((CCostosE)chbListaCCostos.CheckedItems[i]).idCCostos + (i < count - 1 ? "," : "");
            }

            if (ValidarGrabacion())
            {
                btAceptar.Enabled = false;
                //procesa
                timer.Enabled = true;
                pbProgress.Visible = true;
                Marque = "Procesando ...";
                lblprogress.Visible = true;

                _bw.RunWorkerAsync();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                _bw.CancelAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboNivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (rdbTipoReporteMes.Checked)
                {
                    List<CCostosE> ListarCCostos = AgenteMaestro.Proxy.ListarCCostosPorNivel(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboNivel.SelectedValue));
                    ComboHelper.LlenarListBox<CCostosE>(chbListaCCostos, ListarCCostos, "idCCostos", "desCCostos"); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
