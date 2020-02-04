using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEEFFRatios : FrmMantenimientoBase
    {

        public frmReporteEEFFRatios()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();

            FormatoGrid(dgvDetalle);
            FormatoGrid(dgvDetalleGP);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        DataTable dtDatos = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        List<ReporteEEFFItemE> oListaReporte = null;
        List<ReporteEEFFItemE> oListaBalance = null;
        List<ReporteEEFFItemE> oListaGanPer = null;

        String RutaGeneral = String.Empty;
        String TipoRep = String.Empty;
        String Marque = String.Empty;
        String Anio = String.Empty;
        Int32 Letra = 0;

        Font LetraCab = new Font("Tahoma", 7.25f, FontStyle.Bold);

        #endregion

        #region Procedimientos de Usuario

        void ArmarReporte(List<ReporteEEFFItemE> oListaBalance_, List<ReporteEEFFItemE> oListaGanaPerdi_)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            dgvDetalle.DataSource = null;
            dgvDetalleGP.DataSource = null;

            dtDatos = new DataTable();
            DataRow dt = null;
            Decimal Valor1 = 0;
            Decimal Valor2 = 0;
            String EsTitulo = String.Empty;

            dtDatos.Columns.Add("TipoTabla");
            dtDatos.Columns.Add("Caracteristica");
            dtDatos.Columns.Add("idEEFFItem");
            dtDatos.Columns.Add("IniFin");
            dtDatos.Columns.Add("Item");
            dtDatos.Columns.Add("Descripcion");
            
            List<ReporteEEFFItemE> ListaDinamica = new List<ReporteEEFFItemE>();

            #region BALANCE GENERAL

            if (oListaBalance_.Count > 0)
            {
                ListaDinamica = oListaBalance_.GroupBy(x => x.AnioPeriodo).Select(g => g.First()).ToList();

                #region Columnas restantes para el DataTable

                foreach (ReporteEEFFItemE item in ListaDinamica)
                {
                    dtDatos.Columns.Add(item.AnioPeriodo);
                }

                foreach (ReporteEEFFItemE item in ListaDinamica)
                {
                    dtDatos.Columns.Add(item.AnioPeriodo + "V");
                }

                dtDatos.Columns.Add("Horizontal"); 

                #endregion

                oListaBalance_ = oListaBalance_.GroupBy(x => x.secItem).Select(g => g.First()).OrderBy(x => Convert.ToInt32(x.secItem)).ToList();

                for (int item = 0; item < oListaBalance_.Count; item++)
                {
                    dt = dtDatos.NewRow();

                    dt["TipoTabla"] = oListaBalance_[item].TipoTabla;
                    dt["Caracteristica"] = oListaBalance_[item].TipoCaracteristica;
                    dt["idEEFFItem"] = oListaBalance_[item].idEEFFItem;
                    dt["IniFin"] = oListaBalance_[item].IniFin;
                    dt["Item"] = Convert.ToInt32(oListaBalance_[item].secItem).ToString("00000");
                    dt["Descripcion"] = oListaBalance_[item].desItem;

                    foreach (ReporteEEFFItemE itemAnio in ListaDinamica)
                    {
                        ReporteEEFFItemE ItemReporte = (from x in oListaReporte
                                                        where x.AnioPeriodo == itemAnio.AnioPeriodo
                                                        && x.secItem == Convert.ToInt32(oListaBalance_[item].secItem).ToString()
                                                        && x.TipoReporte == "BAL"
                                                        select x).FirstOrDefault();
                        
                        if (ItemReporte != null)
                        {
                            if ((!String.IsNullOrWhiteSpace(ItemReporte.sSaldoSoles) || ItemReporte.sSaldoSoles != "0.00")
                                && (!String.IsNullOrWhiteSpace(ItemReporte.sSaldoDolares) || ItemReporte.sSaldoDolares != "0.00")
                                && ItemReporte.TipoTabla != "TIT")
                            {
                                dt[itemAnio.AnioPeriodo] = Convert.ToDecimal((cboMoneda.SelectedValue.ToString() == "01" ? ItemReporte.sSaldoSoles : ItemReporte.sSaldoDolares)).ToString("N0");
                                dt[itemAnio.AnioPeriodo + "V"] = (cboMoneda.SelectedValue.ToString() == "01" ? ItemReporte.GrupoTotalSol : ItemReporte.GrupoTotalDol) + " %";

                                if (Valor1 == 0)
                                {
                                    Valor1 = cboMoneda.SelectedValue.ToString() == "01" ? Convert.ToDecimal(ItemReporte.sSaldoSoles) : Convert.ToDecimal(ItemReporte.sSaldoDolares);
                                }
                                else
                                {
                                    if (Valor2 == 0)
                                    {
                                        Valor2 = cboMoneda.SelectedValue.ToString() == "01" ? Convert.ToDecimal(ItemReporte.sSaldoSoles) : Convert.ToDecimal(ItemReporte.sSaldoDolares);
                                    }
                                }

                                EsTitulo = "N";
                            }
                            else
                            {
                                dt[itemAnio.AnioPeriodo] = String.Empty;
                                dt[itemAnio.AnioPeriodo + "V"] = String.Empty;
                                EsTitulo = "S";
                            }
                        }
                        else
                        {
                            dt[itemAnio.AnioPeriodo] = "0";
                            dt[itemAnio.AnioPeriodo + "V"] = "0.00 %";
                            EsTitulo = "N";
                        }
                    }

                    if (Valor2 != 0 && Valor1 != 0)
                    {
                        dt["Horizontal"] = ((Valor2 / Valor1) * 100).ToString("N2") + " %";
                    }
                    else
                    {
                        if (EsTitulo == "S")
                        {
                            dt["Horizontal"] = "";
                        }
                        else
                        {
                            dt["Horizontal"] = "0.00 %";
                        }
                    }

                    Valor1 = 0;
                    Valor2 = 0;

                    dtDatos.Rows.Add(dt);
                }

                dgvDetalle.DataSource = dtDatos;
                dgvDetalle.Columns[0].Visible = false;
                dgvDetalle.Columns[1].Visible = false;
                dgvDetalle.Columns[2].Visible = false;
                dgvDetalle.Columns[3].Visible = false;

                dgvDetalle.Columns[5].HeaderText = "Descripción";

                dgvDetalle.Columns[8].HeaderText = dgvDetalle.Columns[8].HeaderText.Substring(0, 4);
                dgvDetalle.Columns[9].HeaderText = dgvDetalle.Columns[9].HeaderText.Substring(0, 4);
                dgvDetalle.Columns[10].HeaderText = dgvDetalle.Columns[9].HeaderText + "/" + dgvDetalle.Columns[8].HeaderText;

                dgvDetalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalle.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalle.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalle.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalle.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvDetalle.Columns[4].Width = 45;
                dgvDetalle.Columns[5].Width = 285;
                dgvDetalle.Columns[6].Width = 70;
                dgvDetalle.Columns[7].Width = 70;
                dgvDetalle.Columns[8].Width = 70;
                dgvDetalle.Columns[9].Width = 70;
                dgvDetalle.Columns[10].Width = 90;
            } 

            #endregion

            dtDatos = new DataTable();
            dt = null;
            Valor1 = 0;
            Valor2 = 0;

            dtDatos.Columns.Add("TipoTabla");
            dtDatos.Columns.Add("Caracteristica");
            dtDatos.Columns.Add("idEEFFItem");
            dtDatos.Columns.Add("Item");
            dtDatos.Columns.Add("Descripcion");

            #region ESTADO DE GANANCIAS Y PERDIDAS

            if (oListaGanaPerdi_.Count > 0)
            {
                //Obteniendo las cabeceras de las columnas dinámicas
                ListaDinamica = oListaGanaPerdi_.GroupBy(x => x.AnioPeriodo).Select(g => g.First()).ToList();

                #region Columnas restantes para el DataTable

                foreach (ReporteEEFFItemE item in ListaDinamica)
                {
                    dtDatos.Columns.Add(item.AnioPeriodo);
                }

                foreach (ReporteEEFFItemE item in ListaDinamica)
                {
                    dtDatos.Columns.Add(item.AnioPeriodo + "V");
                }

                dtDatos.Columns.Add("Horizontal");

                #endregion

                oListaGanaPerdi_ = oListaGanaPerdi_.GroupBy(x => x.secItem).Select(g => g.First()).ToList();//.OrderBy(x => x.secItem).ToList();
                oListaGanaPerdi_ = oListaGanaPerdi_.OrderBy(x => Convert.ToInt32(x.secItem)).ToList();

                for (int item = 0; item < oListaGanaPerdi_.Count; item++)
                {
                    dt = dtDatos.NewRow();

                    dt["TipoTabla"] = oListaGanaPerdi_[item].TipoTabla;
                    dt["Caracteristica"] = oListaGanaPerdi_[item].TipoCaracteristica;
                    dt["idEEFFItem"] = oListaGanaPerdi_[item].idEEFFItem;
                    dt["Item"] = Convert.ToInt32(oListaGanaPerdi_[item].secItem).ToString("00000");
                    dt["Descripcion"] = oListaGanaPerdi_[item].desItem;

                    Valor1 = 0;
                    Valor2 = 0;

                    foreach (ReporteEEFFItemE itemAnio in ListaDinamica)
                    {
                        ReporteEEFFItemE ItemReporte = (from x in oListaReporte
                                                        where x.AnioPeriodo == itemAnio.AnioPeriodo
                                                        && x.secItem == Convert.ToInt32(oListaGanaPerdi_[item].secItem).ToString()
                                                        && x.TipoReporte == "GAPER"
                                                        select x).FirstOrDefault();

                        if (ItemReporte != null)
                        {
                            if ((!String.IsNullOrWhiteSpace(ItemReporte.sSaldoSoles) || ItemReporte.sSaldoSoles != "0.00")
                                && (!String.IsNullOrWhiteSpace(ItemReporte.sSaldoDolares) || ItemReporte.sSaldoDolares != "0.00")
                                && ItemReporte.TipoTabla != "TIT")
                            {
                                dt[itemAnio.AnioPeriodo] = Convert.ToDecimal((cboMoneda.SelectedValue.ToString() == "01" ? ItemReporte.sSaldoSoles : ItemReporte.sSaldoDolares)).ToString("N0");
                                dt[itemAnio.AnioPeriodo + "V"] = (cboMoneda.SelectedValue.ToString() == "01" ? ItemReporte.GrupoTotalSol : ItemReporte.GrupoTotalDol) + " %";

                                if (Valor1 == 0)
                                {
                                    Valor1 = cboMoneda.SelectedValue.ToString() == "01" ? Convert.ToDecimal(ItemReporte.sSaldoSoles) : Convert.ToDecimal(ItemReporte.sSaldoDolares);
                                }
                                else
                                {
                                    if (Valor2 == 0)
                                    {
                                        Valor2 = cboMoneda.SelectedValue.ToString() == "01" ? Convert.ToDecimal(ItemReporte.sSaldoSoles) : Convert.ToDecimal(ItemReporte.sSaldoDolares);
                                    }
                                }
                            }
                            else
                            {
                                dt[itemAnio.AnioPeriodo] = String.Empty;
                                dt[itemAnio.AnioPeriodo + "V"] = String.Empty;
                            }
                        }
                        else
                        {
                            dt[itemAnio.AnioPeriodo] = "0";
                            dt[itemAnio.AnioPeriodo + "V"] = "0.00 %";
                        }
                    }

                    if (Valor2 != 0 && Valor1 != 0)
                    {
                        dt["Horizontal"] = ((Valor2 / Valor1) * 100).ToString("N2") + " %";
                    }
                    else
                    {
                        dt["Horizontal"] = String.Empty;
                    }

                    Valor1 = 0;
                    Valor2 = 0;

                    dtDatos.Rows.Add(dt);
                }

                dgvDetalleGP.DataSource = dtDatos;
                dgvDetalleGP.Columns[0].Visible = false;
                dgvDetalleGP.Columns[1].Visible = false;
                dgvDetalleGP.Columns[2].Visible = false;

                dgvDetalleGP.Columns[4].HeaderText = "Descripción";
                dgvDetalleGP.Columns[7].HeaderText = dgvDetalleGP.Columns[7].HeaderText.Substring(0, 4);
                dgvDetalleGP.Columns[8].HeaderText = dgvDetalleGP.Columns[8].HeaderText.Substring(0, 4);
                dgvDetalleGP.Columns[9].HeaderText = dgvDetalleGP.Columns[8].HeaderText + "/" + dgvDetalleGP.Columns[7].HeaderText;

                dgvDetalleGP.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalleGP.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalleGP.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalleGP.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalleGP.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvDetalleGP.Columns[3].Width = 45;
                dgvDetalleGP.Columns[4].Width = 285;
                dgvDetalleGP.Columns[5].Width = 80;
                dgvDetalleGP.Columns[6].Width = 80;
                dgvDetalleGP.Columns[7].Width = 70;
                dgvDetalleGP.Columns[8].Width = 70;
                dgvDetalleGP.Columns[9].Width = 80; 
            }

            #endregion
        }

        void FormatoGrid(DataGridView oDgv)
        {
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersWidth = 15;
            oDgv.BorderStyle = BorderStyle.None;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            oDgv.ColumnHeadersHeight = 35;
            oDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Bold, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 7.25f * 96f / CreateGraphics().DpiX, FontStyle.Regular, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            oDgv.MultiSelect = false;
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

            // Meses
            cboMesFinal.DataSource = FechasHelper.CargarMesesContable("MA");
            cboMesFinal.ValueMember = "MesId";
            cboMesFinal.DisplayMember = "MesDes";
            cboMesFinal.SelectedValue = "12";

            // Años
            cboAnio.DataSource = FechasHelper.CargarAnios((VariablesLocales.FechaHoy.Year - 1), VariablesLocales.FechaHoy.Year);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
            cboAnio.SelectedValue = VariablesLocales.PeriodoContable.AnioPeriodo;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                TipoRep = "REP";
                pbProgress.Visible = true;
                timer.Enabled = true;
                Marque = "Obteniendo los datos para el Reporte.";
                lblProcesando.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (TipoRep == "REP")
                {
                    int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    string PlanCuentasActual = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                    Anio = Convert.ToInt32(cboAnio.SelectedValue).ToString();

                    oListaReporte = AgenteContabilidad.Proxy.ListarReporteEEFFGananciasPerdidasRatios(idEmpresa, Convert.ToInt32(cboAnio.SelectedValue), "00", cboMesFinal.SelectedValue.ToString(), PlanCuentasActual, false);
                    Letra = 0;
                    lblProcesando.Text = String.Empty;
                    Marque = "Armando el Reporte...";

                    oListaBalance = (from x in oListaReporte where x.TipoReporte == "BAL" select x).ToList(); //Balance...
                    oListaGanPer = (from x in oListaReporte where x.TipoReporte == "GAPER" select x).ToList(); //Ganancia y Perdidas...

                }
                //else
                //{
                //    ExportarExcel(RutaGeneral);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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
                if (TipoRep == "REP")
                {
                    if (oListaReporte.Count > 0)
                    {
                        ArmarReporte(oListaBalance, oListaGanPer);
                        btReporte.Enabled = true;
                    }
                    else
                    {
                        dgvDetalle.DataSource = null;
                        dgvDetalleGP.DataSource = null;
                        Global.MensajeFault("No hay registros.");
                        btReporte.Enabled = false;
                    }
                }
                //else
                //{
                //    Global.MensajeComunicacion("Exportación Terminado...");
                //}
            }

            pbProgress.Visible = false;
            Cursor = Cursors.Arrow;
            timer.Enabled = false;
            lblProcesando.Visible = false;
            _bw.CancelAsync();
            _bw.Dispose();
        }

        #endregion

        #region Eventos

        private void frmReporteEEFFRatios_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            // exportar excel GIF LOADGIND
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Letra += 1;

                if (Letra == Marque.Length)
                {
                    lblProcesando.Text = String.Empty;
                    Letra = 0;
                }
                else
                {
                    lblProcesando.Text += Marque.Substring(Letra - 1, 1);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvDetalle.Rows[e.RowIndex].Cells[0].Value.ToString() == "TIT")
                    {
                        e.CellStyle.Font = LetraCab;//new Font(dgvDetalle.Font, FontStyle.Bold);

                    }
                    else if (dgvDetalle.Rows[e.RowIndex].Cells[0].Value.ToString() == "TOT")
                    {
                        e.CellStyle.Font = LetraCab; //new Font(dgvDetalle.Font, FontStyle.Bold);
                    }
                    else
                    {
                        //RowIndexPOS = -1;
                    }

                    if (dgvDetalle.Rows[e.RowIndex].Cells[3].Value.ToString() == "I" || dgvDetalle.Rows[e.RowIndex].Cells[3].Value.ToString() == "F")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(198, 224, 180);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalleGP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvDetalleGP.Rows[e.RowIndex].Cells[0].Value.ToString() == "TOT" || dgvDetalleGP.Rows[e.RowIndex].Cells[0].Value.ToString() == "TIT")
                    {
                        e.CellStyle.Font = LetraCab; //new Font(dgvDetalleGP.Font, FontStyle.Bold);
                        e.CellStyle.BackColor = Color.FromArgb(198, 224, 180);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btReporte_Click(object sender, EventArgs e)
        {
            cmsFormatos.Show(btReporte, new Point(0, btReporte.Height));
        }

        private void tsmiRatios_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImprimirEEFFRatios);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                List<ReporteEEFFItemE> oListaFinal = new List<ReporteEEFFItemE>();

                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvDetalle.Rows)
                    {
                        ReporteEEFFItemE oItem = new ReporteEEFFItemE()
                        {
                            TipoTabla = Convert.ToString(Fila.Cells["TipoTabla"].Value),
                            TipoCaracteristica = Convert.ToString(Fila.Cells["Caracteristica"].Value),
                            idEEFFItem = Convert.ToInt32(Fila.Cells["idEEFFItem"].Value),
                            IniFin = Convert.ToString(Fila.Cells["IniFin"].Value),
                            secItem = Convert.ToString(Fila.Cells["Item"].Value),
                            desItem = Convert.ToString(Fila.Cells["Descripcion"].Value),
                            Anio1 = Convert.ToString(Fila.Cells[6].Value),
                            Anio2 = Convert.ToString(Fila.Cells[7].Value),
                            Analisis1V = Convert.ToString(Fila.Cells[8].Value),
                            Analisis2V = Convert.ToString(Fila.Cells[9].Value),
                            AnalisisH = Convert.ToString(Fila.Cells[10].Value),
                            TipoReporte = "BAL"
                        };

                        oListaFinal.Add(oItem);
                    }
                }

                if (dgvDetalleGP.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvDetalleGP.Rows)
                    {
                        ReporteEEFFItemE oItem = new ReporteEEFFItemE()
                        {
                            TipoTabla = Convert.ToString(Fila.Cells["TipoTabla"].Value),
                            TipoCaracteristica = Convert.ToString(Fila.Cells["Caracteristica"].Value),
                            idEEFFItem = Convert.ToInt32(Fila.Cells["idEEFFItem"].Value),
                            secItem = Convert.ToString(Fila.Cells["Item"].Value),
                            desItem = Convert.ToString(Fila.Cells["Descripcion"].Value),
                            Anio1 = Convert.ToString(Fila.Cells[5].Value),
                            Anio2 = Convert.ToString(Fila.Cells[6].Value),
                            Analisis1V = Convert.ToString(Fila.Cells[7].Value),
                            Analisis2V = Convert.ToString(Fila.Cells[8].Value),
                            AnalisisH = Convert.ToString(Fila.Cells[9].Value),
                            TipoReporte = "GAPER"
                        };

                        oListaFinal.Add(oItem);
                    }
                }

                oFrm = new frmImprimirEEFFRatios(oListaFinal, Anio);
                oFrm.MdiParent = MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiVertical_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImprimirEEFFVertical);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                List<ReporteEEFFItemE> oListaFinal = new List<ReporteEEFFItemE>();

                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvDetalle.Rows)
                    {
                        ReporteEEFFItemE oItem = new ReporteEEFFItemE()
                        {
                            TipoTabla = Convert.ToString(Fila.Cells["TipoTabla"].Value),
                            TipoCaracteristica = Convert.ToString(Fila.Cells["Caracteristica"].Value),
                            idEEFFItem = Convert.ToInt32(Fila.Cells["idEEFFItem"].Value),
                            IniFin = Convert.ToString(Fila.Cells["IniFin"].Value),
                            secItem = Convert.ToString(Fila.Cells["Item"].Value),
                            desItem = Convert.ToString(Fila.Cells["Descripcion"].Value),
                            Anio1 = Convert.ToString(Fila.Cells[6].Value),
                            Anio2 = Convert.ToString(Fila.Cells[7].Value),
                            Analisis1V = Convert.ToString(Fila.Cells[8].Value),
                            Analisis2V = Convert.ToString(Fila.Cells[9].Value),
                            AnalisisH = Convert.ToString(Fila.Cells[10].Value),
                            TipoReporte = "BAL"
                        };

                        oListaFinal.Add(oItem);
                    }
                }

                if (dgvDetalleGP.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvDetalleGP.Rows)
                    {
                        ReporteEEFFItemE oItem = new ReporteEEFFItemE()
                        {
                            TipoTabla = Convert.ToString(Fila.Cells["TipoTabla"].Value),
                            TipoCaracteristica = Convert.ToString(Fila.Cells["Caracteristica"].Value),
                            idEEFFItem = Convert.ToInt32(Fila.Cells["idEEFFItem"].Value),
                            secItem = Convert.ToString(Fila.Cells["Item"].Value),
                            desItem = Convert.ToString(Fila.Cells["Descripcion"].Value),
                            Anio1 = Convert.ToString(Fila.Cells[5].Value),
                            Anio2 = Convert.ToString(Fila.Cells[6].Value),
                            Analisis1V = Convert.ToString(Fila.Cells[7].Value),
                            Analisis2V = Convert.ToString(Fila.Cells[8].Value),
                            AnalisisH = Convert.ToString(Fila.Cells[9].Value),
                            TipoReporte = "GAPER"
                        };

                        oListaFinal.Add(oItem);
                    }
                }

                oFrm = new frmImprimirEEFFVertical(oListaFinal,Anio);
                oFrm.MdiParent = MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }

        }

        private void tsmiHorizontal_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImprimirEEFFHorizontal);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                List<ReporteEEFFItemE> oListaFinal = new List<ReporteEEFFItemE>();

                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvDetalle.Rows)
                    {
                        ReporteEEFFItemE oItem = new ReporteEEFFItemE()
                        {
                            TipoTabla = Convert.ToString(Fila.Cells["TipoTabla"].Value),
                            TipoCaracteristica = Convert.ToString(Fila.Cells["Caracteristica"].Value),
                            idEEFFItem = Convert.ToInt32(Fila.Cells["idEEFFItem"].Value),
                            IniFin = Convert.ToString(Fila.Cells["IniFin"].Value),
                            secItem = Convert.ToString(Fila.Cells["Item"].Value),
                            desItem = Convert.ToString(Fila.Cells["Descripcion"].Value),
                            Anio1 = Convert.ToString(Fila.Cells[6].Value),
                            Anio2 = Convert.ToString(Fila.Cells[7].Value),
                            Analisis1V = Convert.ToString(Fila.Cells[8].Value),
                            Analisis2V = Convert.ToString(Fila.Cells[9].Value),
                            AnalisisH = Convert.ToString(Fila.Cells[10].Value),
                            TipoReporte = "BAL"
                        };

                        oListaFinal.Add(oItem);
                    }
                }

                if (dgvDetalleGP.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvDetalleGP.Rows)
                    {
                        ReporteEEFFItemE oItem = new ReporteEEFFItemE()
                        {
                            TipoTabla = Convert.ToString(Fila.Cells["TipoTabla"].Value),
                            TipoCaracteristica = Convert.ToString(Fila.Cells["Caracteristica"].Value),
                            idEEFFItem = Convert.ToInt32(Fila.Cells["idEEFFItem"].Value),
                            secItem = Convert.ToString(Fila.Cells["Item"].Value),
                            desItem = Convert.ToString(Fila.Cells["Descripcion"].Value),
                            Anio1 = Convert.ToString(Fila.Cells[5].Value),
                            Anio2 = Convert.ToString(Fila.Cells[6].Value),
                            Analisis1V = Convert.ToString(Fila.Cells[7].Value),
                            Analisis2V = Convert.ToString(Fila.Cells[8].Value),
                            AnalisisH = Convert.ToString(Fila.Cells[9].Value),
                            TipoReporte = "GAPER"
                        };

                        oListaFinal.Add(oItem);
                    }
                }

                oFrm = new frmImprimirEEFFHorizontal(oListaFinal, Anio);
                oFrm.MdiParent = MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }

        }

        #endregion

    }
}
