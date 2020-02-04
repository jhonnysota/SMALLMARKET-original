using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoCostosMovimientos : FrmMantenimientoBase
    {

        #region Constructor

        public frmListadoCostosMovimientos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
            FormatoGrid(dgvCostosMovimientos, false);
            
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<CostosMovimientosE> oListaCostosMovimientos = null;
        List<CostosMovimientosItemE> oListaCostosMovimientosItem = null;
        string Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String Marque = String.Empty;
        Int32 letra = 0;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                    Form oFrm = this.MdiChildren.FirstOrDefault(x => x is frmCostosMovimientos);

                    if (oFrm != null)
                    {
                        oFrm.BringToFront();
                        return;
                    }
                String Anio = Convert.ToString(cboAnio.SelectedValue);
                Int32 Elemento = Convert.ToInt32(cboElem.SelectedValue);
                    oFrm = new frmCostosMovimientos(Anio, Elemento);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            Form oFrm = this.MdiChildren.FirstOrDefault(x => x is frmCostosMovimientos);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            CostosMovimientosE ECostosMov = (CostosMovimientosE)bsCostosMovimientos.Current;

            if (ECostosMov != null)
            {
                ECostosMov.ListaCostosMovimientos = AgenteMaestros.Proxy.ListarCostosMovimientosItem(ECostosMov.idEmpresa,ECostosMov.idElemento,ECostosMov.CodClasificacion);
                oFrm = new frmCostosMovimientos(ECostosMov);
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
        }

        public override void Buscar()
        {
            try
            {
                String Anio = Convert.ToString(cboAnio.SelectedValue);
                Int32 CodElem = Convert.ToInt32(cboElem.SelectedValue);
                oListaCostosMovimientos = AgenteMaestros.Proxy.ListarCostosMovimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, CodElem, Anio);
                bsCostosMovimientos.DataSource = oListaCostosMovimientos;


                lblRegistros.Text = "Registros " + bsCostosMovimientos.Count.ToString();
                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            Int32 resp = Variables.Cero;

            try
            {
                if (bsCostosMovimientos.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                    {
                        resp = AgenteMaestros.Proxy.EliminarCostosMovimientos(((CostosMovimientosE)bsCostosMovimientos.Current).idEmpresa, ((CostosMovimientosE)bsCostosMovimientos.Current).CodClasificacion, ((CostosMovimientosE)bsCostosMovimientos.Current).idElemento, ((CostosMovimientosE)bsCostosMovimientos.Current).Anio);
                        oListaCostosMovimientos.Remove((CostosMovimientosE)bsCostosMovimientos.Current);
                        bsCostosMovimientos.DataSource = oListaCostosMovimientos;
                        bsCostosMovimientos.ResetBindings(false);
                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void LlenarCombos()
        {
            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;


            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";

            List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("ELEM");
            ParTabla p1 = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            ListaTipoArticulo.Add(p1);
            ComboHelper.RellenarCombos<ParTabla>(cboElem, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

        }

        void Reporte()
        {

            if (oListaCostosMovimientos.Count == 0)
            {
                Global.MensajeFault("No hay registros");
                return;
            }
        }

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            Reporte();
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblprogress.Visible = false;
            timer1.Enabled = false;
            _bw.CancelAsync();
            _bw.Dispose();

            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReportesCostosMovimientos);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            String Anio = Convert.ToString(cboAnio.SelectedValue);
            oFrm = new frmReportesCostosMovimientos(oListaCostosMovimientos, oListaCostosMovimientosItem, Anio);
            oFrm.MdiParent = this.MdiParent;
            oFrm.Show();
        }

        #endregion

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCostosMovimientos oFrm = sender as frmCostosMovimientos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoCostosMovimientos_Load(object sender, EventArgs e)
        {
            cboAnio.SelectedValue = Convert.ToInt32(Anio);
            Grid = true;

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void dgvCostosMovimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmListadoCostosMovimientos_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (oListaCostosMovimientos != null)
            {
                CostosMovimientosE uCostosMov = (CostosMovimientosE)bsCostosMovimientos.Current;
                oListaCostosMovimientosItem = AgenteMaestros.Proxy.ListarCostosMovimientosItem(uCostosMov.idEmpresa, uCostosMov.idElemento, uCostosMov.CodClasificacion);

                if (oListaCostosMovimientosItem != null)
                {
                    if (oListaCostosMovimientos.Count > 0)
                    {
                        if (oListaCostosMovimientosItem.Count > 0)
                        {
                            //anio = cboAnio.SelectedValue.ToString();
                            //mesFin = cboMesFinal.SelectedValue.ToString();
                            timer1.Enabled = true;
                            pbProgress.Visible = true;
                            Marque = "Procesando ...";
                            lblprogress.Visible = true;
                            _bw.RunWorkerAsync();
                        }
                    }
                }
            }
            else
            {
                Global.MensajeComunicacion("No se Encuentran Registros");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        #endregion

    }
}
