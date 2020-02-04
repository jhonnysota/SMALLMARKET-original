using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEEFFGananciasyPerdidasListado : FrmMantenimientoBase
    {

        #region Constructores

        public frmReporteEEFFGananciasyPerdidasListado()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
            /////Formato datagridview
            dgvPivot.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            dgvPivot.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvPivot.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPivot.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPivot.MultiSelect = false;
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        DataTable dtDatos = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        List<ReporteEEFFItemE> oListaReporte = null;

        Int32 idEEFF = 0;
        String idCCostos = "";
        String fl_TipoReporte = "";
        String idMoneda;
        String mesInicial;
        String mesFin;
        String columnName;
        String indAcumulado;
        String anio;
        String desEEFF;
        String indCCostos = "";
        String codEEFF = "";

        String RutaGeneral = String.Empty;
        Int32 RowIndexPOS = -1;
        Boolean chkTodos = true;
        String TipoRep = String.Empty;

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                dgvPivot.DataSource = null;
                idEEFF = Convert.ToInt32(cboEEFF.SelectedValue.ToString());
                anio = cboAnio.SelectedValue.ToString();
                mesFin = cboMesFinal.SelectedValue.ToString();
                idMoneda = cboMoneda.SelectedValue.ToString();
                desEEFF = cboEEFF.Text;
                mesInicial = "00";
                indAcumulado = (chbAcumulado.Checked ? "S" : "N");
                indCCostos = (chbindCCostos.Checked ? "S" : "N");
                fl_TipoReporte = (rdbTipoReporteMes.Checked ? "0" : "1");
                idCCostos = "";
                Cursor = Cursors.WaitCursor;
                TipoRep = "rep";

                Int32 count = chbListaCCostos.CheckedItems.Count;

                for (Int32 i = 0; i < count; i++)
                {
                    idCCostos += ((CCostosE)chbListaCCostos.CheckedItems[i]).idCCostos + (i < count - 1 ? "," : "");
                }

                if (ValidarGrabacion())
                {
                    pbProgress.Visible = true;

                    _bw.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Imprimir()
        {
            CerrarFormulario("frmReporteEEFFGananciasyPerdidasImprimir");

            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasImprimir);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            oFrm = new frmReporteEEFFGananciasyPerdidasImprimir(dtDatos, desEEFF, mesFin);
            oFrm.MdiParent = MdiParent;
            oFrm.Show();
        }

        public override void Exportar()
        {
            try
            {
                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", desEEFF + (fl_TipoReporte == "0" ? " por Meses" : " por Costos") + " a " + FechasHelper.NombreMes(Convert.ToInt32(mesFin)) + " del " + anio, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    pbProgress.Visible = true;
                    Cursor = Cursors.WaitCursor;
                    TipoRep = "exp";
                    _bw.RunWorkerAsync();
                }
                else
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (TipoRep == "rep")
                {
                    Decimal TipoCambio = 0;
                    Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    String PlanCuentasActual = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                    if (chbtipo_cambio.Checked)
                    {
                        TipoCambio = Convert.ToDecimal(txttipocambio.Text);
                    }
                    else
                    {
                        TipoCambio = Variables.Cero;
                    }

                    oListaReporte = AgenteContabilidad.Proxy.ListarRptEEFFGananciasPerdidas(idEmpresa, anio, mesInicial, mesFin, idEEFF, idCCostos, indAcumulado, indCCostos, PlanCuentasActual, fl_TipoReporte, TipoCambio, Convert.ToInt32(cboNivel.SelectedValue), chkMostrar.Checked);
                }
                else
                {
                    ExportarExcel(RutaGeneral);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            Cursor = Cursors.Arrow;

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
                if (TipoRep == "rep")
                {
                    if (oListaReporte.Count > 0)
                    {
                        ReportePivot();
                    }
                    else
                    {
                        dgvPivot.DataSource = null;
                        Global.MensajeFault("No hay registros.");
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Exportación Terminado...");
                }
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        #endregion

        #region Procedimientos de Usuario

        void ReportePivot()
        {
            dtDatos = new DataTable();
            DataRow dt = null;

            dtDatos.Columns.Add("Tipo Tabla");
            dtDatos.Columns.Add("idEEFFItem");
            dtDatos.Columns.Add("Item");
            dtDatos.Columns.Add("Descripcion");
            dtDatos.Columns.Add("TOTAL");

            List<ReporteEEFFItemE> listaCabe = null;
            listaCabe = new List<ReporteEEFFItemE>();

            if (fl_TipoReporte == "0")
            {
                if (!chkMostrar.Checked)
                {
                    listaCabe = oListaReporte.Where(x => x.saldo_dol != 0 || x.saldo_sol != 0).GroupBy(x => x.MesPeriodo).Select(g => g.First()).OrderBy(x => x.MesPeriodo).ToList();
                }
                else
                {
                    listaCabe = oListaReporte.GroupBy(x => x.MesPeriodo).Select(g => g.First()).OrderBy(x => x.MesPeriodo).ToList();
                }
            }
            else
            {
                if (!chkMostrar.Checked)
                {
                    listaCabe = oListaReporte.Where(x => x.saldo_dol != 0 || x.saldo_sol != 0).GroupBy(x => x.desCCostos).Select(g => g.First()).OrderBy(x => x.desCCostos).ToList(); 
                }
                else
                {
                    listaCabe = oListaReporte.GroupBy(x => x.desCCostos).Select(g => g.First()).OrderBy(x => x.desCCostos).ToList();
                }
            }

            for (Int32 i = 0; i < listaCabe.Count; i++)
            {
                String mes = FechasHelper.NombreMes(Convert.ToInt32(listaCabe[i].MesPeriodo));

                if (fl_TipoReporte == "0")
                {
                    dtDatos.Columns.Add(listaCabe[i].AnioPeriodo + " - " + mes.ToUpper());//(mes == "00" ? "APERTURA" : (mes == "01" ? "ENERO" : (mes == "02" ? "FEBRERO" : (mes == "03" ? "MARZO" : (mes == "04" ? "ABRIL" : (mes == "05" ? "MAYO" : (mes == "06" ? "JUNIO" : (mes == "07" ? "JULIO" : (mes == "08" ? "AGOSTO" : (mes == "09" ? "SETIEMBRE" : (mes == "10" ? "OCTUBRE" : (mes == "11" ? "NOVIEMBRE" : "DICIEMBRE")))))))))))));
                }
                else
                {
                    dtDatos.Columns.Add(listaCabe[i].desCCostos);
                }
            }

            List<ReporteEEFFItemE> listaData = null;
            Boolean NuevoLinea = false;
            String secItem = "";
            Int32 contador = 0;

            if (!chkMostrar.Checked)
            {
                listaData = (from x in oListaReporte where x.saldo_dol != 0 || x.saldo_sol != 0 orderby Convert.ToInt32(x.secItem) select x).ToList();
            }
            else
            {
                listaData = (from x in oListaReporte orderby Convert.ToInt32(x.secItem) select x).ToList();
            }

            for (Int32 data = 0; data < listaData.Count; data++)
            {
                if (data == 0)
                {
                    dt = dtDatos.NewRow();
                    NuevoLinea = true;
                    secItem = listaData[data].secItem;

                    dt["Tipo Tabla"] = listaData[data].TipoTabla;
                    dt["idEEFFItem"] = listaData[data].idEEFFItem;
                    dt["Item"] = Convert.ToInt32(secItem).ToString("00000");
                    dt["Descripcion"] = listaData[data].desItem;

                    contador++;
                }

                if (data > 0)
                {
                    if (secItem != listaData[data].secItem)
                    {
                        dt = dtDatos.NewRow();
                        NuevoLinea = true;
                        secItem = listaData[data].secItem;

                        dt["Tipo Tabla"] = listaData[data].TipoTabla;
                        dt["idEEFFItem"] = listaData[data].idEEFFItem;
                        dt["Item"] = Convert.ToInt32(secItem).ToString("00000");
                        dt["Descripcion"] = listaData[data].desItem;

                        contador++;
                    }
                    else
                    {
                        NuevoLinea = false;
                    }
                }

                if (NuevoLinea)
                {
                    decimal? Total = 0;

                    for (Int32 i = 0; i < listaCabe.Count; i++)
                    {
                        String mes = FechasHelper.NombreMes(Convert.ToInt32(listaCabe[i].MesPeriodo)); //listaCabe[i].MesPeriodo;
                        List<ReporteEEFFItemE> item;
                        String NombreColumna = "";

                        if (fl_TipoReporte == "0")
                        {
                            NombreColumna = listaCabe[i].AnioPeriodo + " - " + mes.ToUpper(); //(mes == "00" ? "APERTURA" : (mes == "01" ? "ENERO" : (mes == "02" ? "FEBRERO" : (mes == "03" ? "MARZO" : (mes == "04" ? "ABRIL" : (mes == "05" ? "MAYO" : (mes == "06" ? "JUNIO" : (mes == "07" ? "JULIO" : (mes == "08" ? "AGOSTO" : (mes == "09" ? "SETIEMBRE" : (mes == "10" ? "OCTUBRE" : (mes == "11" ? "NOVIEMBRE" : "DICIEMBRE"))))))))))));
                            item = (from x in oListaReporte
                                    where x.AnioPeriodo == listaCabe[i].AnioPeriodo
                                    && x.MesPeriodo == listaCabe[i].MesPeriodo
                                    && x.secItem == secItem
                                    select x).ToList();

                            if (item != null && item.Count > 0)
                            {
                                dt[NombreColumna] = Convert.ToDecimal((idMoneda == "01" ? item[0].saldo_sol : item[0].saldo_dol)).ToString("N2");
                                Total += (idMoneda == "01" ? item[0].saldo_sol : item[0].saldo_dol);
                            }
                            else
                            {
                                dt[NombreColumna] = 0;
                            }
                        }
                        else
                        {
                            NombreColumna = listaCabe[i].desCCostos;
                            item = oListaReporte.Where(x => x.desCCostos == NombreColumna && x.secItem == secItem).ToList();

                            if (item != null && item.Count > 0)
                            {
                                dt[NombreColumna] = Convert.ToDecimal((idMoneda == "01" ? item[0].saldo_sol : item[0].saldo_dol)).ToString("N2");
                                Total += (idMoneda == "01" ? item[0].saldo_sol : item[0].saldo_dol);
                            }
                            else
                            {
                                dt[NombreColumna] = 0;
                            }
                        }
                    }

                    dt["TOTAL"] = Convert.ToDecimal(Total).ToString("N2");
                    dtDatos.Rows.Add(dt);
                }
            }

            lblregistros.Text = desEEFF + " - " + contador.ToString() + " Items";
            Text = desEEFF;

            if (fl_TipoReporte == "0")
            {
                tsmiExcel.Enabled = false;
            }
            else
            {
                tsmiExcel.Enabled = true;
            }

            dgvPivot.DataSource = dtDatos;

            dgvPivot.Columns[0].Visible = false;
            dgvPivot.Columns[0].Frozen = true;
            dgvPivot.Columns[1].Visible = false;
            dgvPivot.Columns[1].Frozen = true;
            dgvPivot.Columns[2].Width = 50;
            dgvPivot.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPivot.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPivot.Columns[2].Frozen = true;
            dgvPivot.Columns[3].Width = 250;
            dgvPivot.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPivot.Columns[3].Frozen = true;

            for (Int32 i = 0; i < dgvPivot.Columns.Count; i++)
            {
                if (i <= 3)
                {
                    dgvPivot.Columns[i].DefaultCellStyle.BackColor = Color.Bisque;
                    dgvPivot.Columns[i].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                }

                if (i == 4)
                {
                    dgvPivot.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPivot.Columns[i].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                    dgvPivot.Columns[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                    dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPivot.Columns[i].Width = 120;
                    dgvPivot.Columns[i].Frozen = true;
                }

                if (i > 4)
                {
                    dgvPivot.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPivot.Columns[i].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                    dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPivot.Columns[i].Width = (fl_TipoReporte == "0" ? 90 : 105);
                }
            }
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

            for (Int32 i = 1; i <= Niveles; i++)
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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = desEEFF + " a " + FechasHelper.NombreMes(Convert.ToInt32(mesFin)) + " del " + anio;
            NombrePestaña = "Reporte";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = dgvPivot.ColumnCount;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas - 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        //Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas - 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        //Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    Int32 col = 1;

                    for (Int32 i = 2; i < TotColumnas; i++)
                    {
                        //Nueva Celda
                        String titDetalle = dgvPivot.Columns[i].HeaderText;

                        oHoja.Cells[InicioLinea, col].Value = titDetalle;
                        oHoja.Cells[InicioLinea, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, col].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, col].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        col++;
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas - 2].AutoFilter = true;

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;
                    col = 1;

                    foreach (DataRow item in dtDatos.Rows)
                    {
                        for (Int32 i = 2; i < TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i - 1].Value = item[i];

                            if (i == 2 | i == 3)
                            {
                                oHoja.Cells[InicioLinea, i - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, i - 1].Style.Fill.BackgroundColor.SetColor(Color.Bisque);
                                oHoja.Cells[InicioLinea, i - 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }

                            if (item[0].ToString() == "TOT" )
                            {
                                oHoja.Cells[InicioLinea, i - 1].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, i - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, i - 1].Style.Fill.BackgroundColor.SetColor(Color.Bisque);
                            }

                            if (i == 4 && item[0].ToString() != "TOT")
                            {
                                oHoja.Cells[InicioLinea, i - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, i - 1].Style.Fill.BackgroundColor.SetColor(Color.PaleTurquoise);
                            }

                            if (i >= 4)
                            {
                                oHoja.Cells[InicioLinea, i - 1].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, i - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, i - 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }
                        }

                        InicioLinea++;
                    }

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas - 2].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteEEFFGananciasPerdidasMeses_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            // exportar excel GIF LOADGIND
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        private void btnArchivoXls_Click(object sender, EventArgs e)
        {

        }

        private void dgvPivot_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            Int32 idLocal = VariablesLocales.SesionLocal.IdLocal;

            Int32 rowindex = dgvPivot.CurrentCell.RowIndex;
            Int32 columnindex = dgvPivot.CurrentCell.ColumnIndex;


            // se valida que sea celda con valor
            if (columnindex > 3 && columnindex < dgvPivot.Columns.Count && dgvPivot.Rows[rowindex].Cells[0].Value.ToString() == "DET")
            {
                Int32 idEEFFItem = Convert.ToInt32(dgvPivot.Rows[rowindex].Cells[1].Value.ToString());
                String desItem = dgvPivot.Rows[rowindex].Cells[3].Value.ToString();

                columnName = dgvPivot.Columns[columnindex].Name;
                String mes = (columnName.Contains("ENE") ? "01" : (columnName.Contains("FEB") ? "02" : (columnName.Contains("MAR") ? "03" : (columnName.Contains("ABR") ? "04" : (columnName.Contains("MAY") ? "05" : (columnName.Contains("JUN") ? "06" : (columnName.Contains("JUL") ? "07" : (columnName.Contains("AGO") ? "08" : (columnName.Contains("SEP") ? "09" : (columnName.Contains("OCT") ? "10" : (columnName.Contains("NOV") ? "11" : (columnName.Contains("DIC") ? "12" : "00"))))))))))));

                // =========================================================
                if (fl_TipoReporte != "0")
                    idCCostos = columnName.Split('-')[0].Trim();

                List<VoucherItemE> oListaDetalle;

                if (fl_TipoReporte == "0")
                {
                    oListaDetalle = AgenteContabilidad.Proxy.ListarRptEEFFGananciasPerdidasDetalle(
                                        idEmpresa, idLocal, anio, mesInicial, mes, idEEFF, idEEFFItem, idCCostos, idMoneda, fl_TipoReporte);
                }
                else
                {
                    oListaDetalle = AgenteContabilidad.Proxy.ListarRptEEFFGananciasPerdidasDetalle(idEmpresa, idLocal, anio, (fl_TipoReporte == "0" ? mesInicial : mesInicial), (fl_TipoReporte == "0" ? mes : mesFin), idEEFF, idEEFFItem, idCCostos, idMoneda, fl_TipoReporte);
                }

                if (oListaDetalle == null || oListaDetalle.Count == 0)
                {
                    Global.MensajeFault("No hay registros Voucher");
                    return;
                }

                // =========================================================

                CerrarFormulario("frmReporteEEFFGananciasyPerdidasDetalle");

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasDetalle);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                if (!chbAcumulado.Checked)
                {
                    oListaDetalle = oListaDetalle.Where(x => x.desGlosa != "Saldo Anterior ==>").ToList();
                }

                oFrm = new frmReporteEEFFGananciasyPerdidasDetalle(oListaDetalle, desItem);
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
        }

        private void dgvPivot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvPivot.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("TOT"))
                    {
                        RowIndexPOS = e.RowIndex;

                        DataGridViewCellStyle StyleNegrita = new DataGridViewCellStyle();
                        StyleNegrita.Font = new Font(dgvPivot.Font, FontStyle.Bold);

                        e.CellStyle.ApplyStyle(StyleNegrita);
                    }
                    else
                    {
                        RowIndexPOS = -1;
                    }

                    if (RowIndexPOS > 0)
                    {
                        e.CellStyle.BackColor = Color.Bisque;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnVerCuentas_Click(object sender, EventArgs e)
        {
            List<EEFFItemCtaE> ListaEEFFItemCta = new List<EEFFItemCtaE>();
            Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            Int32 rowindex = dgvPivot.CurrentCell.RowIndex;
            Int32 columnindex = dgvPivot.CurrentCell.ColumnIndex;
            Int32 idEEFFItem = Convert.ToInt32(dgvPivot.Rows[rowindex].Cells[1].Value.ToString());
            String desItem = dgvPivot.Rows[rowindex].Cells[3].Value.ToString();
            String Mostrar = Variables.NO;

            //ES FORMULA
            if (dgvPivot.Rows[rowindex].Cells[0].Value.ToString().Contains("TOT"))
            {
                List<EEFFItemForE> ListaEEFFItemFor = AgenteContabilidad.Proxy.ListarEEFFItemFor(idEmpresa, idEEFF, idEEFFItem);

                foreach (EEFFItemForE item in ListaEEFFItemFor)
                {
                    ListaEEFFItemCta.Add(new EEFFItemCtaE { CodPlaCta = item.secItem, desCuenta = item.desItem });
                }
            }
            else
            {
                String Cabecera = dgvPivot.Columns[columnindex].HeaderText;
                List<String> oLista = new List<String>(Cabecera.Split('-'));

                if (oLista[0].ToString().Trim() == "TOTAL")
                {
                    ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, VariablesLocales.SesionLocal.IdLocal, anio, mesFin);
                    Mostrar = Variables.SI;
                }
                else
                {
                    if (oLista.Count == 2)
                    {
                        String numMes = FechasHelper.NumeroMes(oLista[1].Trim());
                        ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, VariablesLocales.SesionLocal.IdLocal, oLista[0].Trim(), numMes);
                    }
                    else
                    {
                        ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, 0, "", "");
                    }
                }
            }

            CerrarFormulario("frmReporteEEFFGananciasyPerdidasCta");

            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasCta);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            oFrm = new frmReporteEEFFGananciasyPerdidasCta(ListaEEFFItemCta, desItem, idEmpresa, idEEFF, idEEFFItem, Mostrar, anio, mesFin)
            {
                MdiParent = MdiParent
            };

            oFrm.Show();
        }

        private void tsmiCuentas_Click(object sender, EventArgs e)
        {
            try
            {
                List<EEFFItemCtaE> ListaEEFFItemCta = new List<EEFFItemCtaE>();
                Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                Int32 rowindex = dgvPivot.CurrentCell.RowIndex;
                Int32 columnindex = dgvPivot.CurrentCell.ColumnIndex;
                Int32 idEEFFItem = Convert.ToInt32(dgvPivot.Rows[rowindex].Cells[1].Value.ToString());
                String desItem = dgvPivot.Rows[rowindex].Cells[3].Value.ToString();
                String Mostrar = Variables.NO;

                //ES FORMULA
                if (dgvPivot.Rows[rowindex].Cells[0].Value.ToString().Contains("TOT"))
                {
                    List<EEFFItemForE> ListaEEFFItemFor = AgenteContabilidad.Proxy.ListarEEFFItemFor(idEmpresa, idEEFF, idEEFFItem);

                    foreach (EEFFItemForE item in ListaEEFFItemFor)
                    {
                        ListaEEFFItemCta.Add(new EEFFItemCtaE { CodPlaCta = item.secItem, desCuenta = item.desItem });
                    }
                }
                else
                {
                    String Cabecera = dgvPivot.Columns[columnindex].HeaderText;
                    List<String> oLista = new List<String>(Cabecera.Split('-'));

                    if (oLista[0].ToString().Trim() == "TOTAL")
                    {
                        ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, VariablesLocales.SesionLocal.IdLocal, anio, mesFin);
                        Mostrar = Variables.SI;
                    }
                    else
                    {
                        if (oLista.Count == 2)
                        {
                            String numMes = FechasHelper.NumeroMes(oLista[1].Trim());
                            ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, VariablesLocales.SesionLocal.IdLocal, oLista[0].Trim(), numMes);
                        }
                        else
                        {
                            ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, 0, "", "");
                        }
                    }
                }

                CerrarFormulario("frmReporteEEFFGananciasyPerdidasCta");

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasCta);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmReporteEEFFGananciasyPerdidasCta(ListaEEFFItemCta, desItem, idEmpresa, idEEFF, idEEFFItem, Mostrar, anio, mesFin)
                {
                    MdiParent = MdiParent
                };

                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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

        private void rdbTipoReporteCCostos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTipoReporteCCostos.Checked)
            {
                //pnlCCostos.Visible = false;
                chbAcumulado.Visible = false;
                //chbindCCostos.Checked = false;
                //chbListaCCostos.Enabled = false;
            }
            else
            {
                pnlCCostos.Visible = true;

                if (((EEFFE)cboEEFF.SelectedItem).idEEFF == 1)
                {
                    chbAcumulado.Visible = true;
                }
                else
                {
                    chbAcumulado.Visible = false;
                }
            }
        }

        private void lnkTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (Int32 i = 0; i < chbListaCCostos.Items.Count; i++)
            {
                chbListaCCostos.SetItemChecked(i, chkTodos);
            }

            if (chkTodos)
            {
                chkTodos = false;
            }
            else
            {
                chkTodos = true;
            }
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

                for (Int32 i = 0; i < chbListaCCostos.Items.Count; i++)
                {
                    chbListaCCostos.SetItemChecked(i, false);
                }
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

        private void tsmiExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                Int32 idLocal = VariablesLocales.SesionLocal.IdLocal;
                String PlanCuentasActual = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                Int32 rowindex = dgvPivot.CurrentCell.RowIndex;
                Int32 idEEFFItem = Convert.ToInt32(dgvPivot.Rows[rowindex].Cells[1].Value.ToString());
                String desEEFFItem = dgvPivot.Rows[rowindex].Cells[3].Value.ToString();

                List<ReporteEEFFItemE> oListaArchivo = AgenteContabilidad.Proxy.ListarReporteEEFFGananciasPerdidasArchivo(idEmpresa, idEEFF, idEEFFItem);

                if (oListaArchivo == null || oListaArchivo.Count == 0)
                {
                    Global.MensajeFault("El item seleccionado no tiene valores asignados");
                    return;
                }

                List<EEFFItemE> oListaItem = AgenteContabilidad.Proxy.ListarEEFFItem(idEmpresa, idEEFF);

                for (Int32 i = 5; i < dgvPivot.Columns.Count; i++)
                {
                    idCCostos = dgvPivot.Columns[i].Name.Split('-')[0].Trim();

                    for (Int32 lin = 0; lin < dgvPivot.RowCount; lin++)
                    {
                        Int32 idItem = Convert.ToInt32(dgvPivot.Rows[lin].Cells[1].Value.ToString());
                        String tipoValorExcel = oListaItem.Where(x => x.idEEFFItem == idItem).ToList()[0].TipoColumna;

                        for (Int32 n = 0; n < oListaArchivo.Count; n++)
                        {
                            if (oListaArchivo[n].desCCostos == idCCostos && oListaArchivo[n].idEEFFItem == idItem)
                            {
                                decimal valor = Convert.ToDecimal(dgvPivot.Rows[lin].Cells[i].Value.ToString());
                                valor = decimal.Round(valor, 0);
                                valor = (tipoValorExcel == "2" ? valor * -1 : valor);
                                oListaArchivo[n].saldo_sol = valor;
                            }
                        }
                    }
                }

                CerrarFormulario("frmReporteEEFFGananciasyPerdidasArchivo");

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasArchivo);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmReporteEEFFGananciasyPerdidasArchivo(oListaArchivo, idMoneda, desEEFFItem);
                oFrm.MdiParent = MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btPle_Click(object sender, EventArgs e)
        {
            Int32 Linea = Variables.Cero;
            String Correlativo = String.Empty;

            try
            {
                String CodigoItem;
                Decimal Monto;

                if (codEEFF == "ESFI") // Estado de Situacion Financiera
                {
                    #region Nombres de Archivos

                    String NombreArchivo = String.Empty;

                    // Creando el Nombre del Asiento
                    if (dgvPivot.Columns.Count > Variables.Cero)
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00030100001111";
                    }
                    else
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00030100001011";
                    }

                    String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                    #endregion

                    if (!String.IsNullOrEmpty(RutaArchivoTexto))
                    {
                        #region Borrando los archivos si existieran

                        if (File.Exists(RutaArchivoTexto))
                        {
                            File.Delete(RutaArchivoTexto);
                        }

                        #endregion

                        #region Exportacion a un archivo de texto

                        StringBuilder Cadena = new StringBuilder();
                        String Periodo, Estado, Catalogo;
                        Int32 CodItem;

                        using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                        {
                            foreach (DataRow item in dtDatos.Rows)
                            {
                                Periodo = anio + mesFin + "00";
                                Catalogo = "01";
                                CodItem = Convert.ToInt32(item[1].ToString());
                                CodigoItem = item[2].ToString();
                                Monto = Math.Abs(Convert.ToDecimal(item[4].ToString()));
                                Estado = "1";

                                EEFFItemE oEEFFItem = AgenteContabilidad.Proxy.ObtenerEEFFItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idEEFF, CodItem);

                                if (oEEFFItem != null)
                                {
                                    if (oEEFFItem.codSunat != null && oEEFFItem.codSunat != "")
                                    {
                                        Cadena.Clear();

                                        Cadena.Append(Periodo).Append("|");
                                        Cadena.Append(Catalogo).Append("|");
                                        Cadena.Append(oEEFFItem.codSunat).Append("|");
                                        Cadena.Append(Monto.ToString("#####0.000")).Append("|");
                                        Cadena.Append(Estado).Append("|");

                                        oSw.WriteLine(Cadena.ToString());
                                    }
                                }
                            }
                        }

                        #endregion Exportacion a un archivo de texto

                        Global.MensajeComunicacion("Se generó el archivo correctamente.");
                    }
                }

                if (codEEFF == "ESRE") // Estado de Resultado
                {
                    #region Nombres de Archivos

                    String NombreArchivo = String.Empty;

                    // Creando el Nombre del Asiento
                    if (dgvPivot.Columns.Count > Variables.Cero)
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00032000001111";
                    }
                    else
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "000320100001011";
                    }

                    String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                    #endregion

                    if (!String.IsNullOrEmpty(RutaArchivoTexto))
                    {
                        #region Borrando los archivos si existieran

                        if (File.Exists(RutaArchivoTexto))
                        {
                            File.Delete(RutaArchivoTexto);
                        }

                        #endregion

                        #region Exportacion a un archivo de texto

                        StringBuilder Cadena = new StringBuilder();
                        String Periodo, Estado, Catalogo;
                        Int32 CodItem;

                        using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                        {
                            foreach (DataRow item in dtDatos.Rows)
                            {
                                Periodo = anio + mesFin + "00";
                                Catalogo = "01";
                                CodItem = Convert.ToInt32(item[1].ToString());
                                CodigoItem = item[2].ToString();
                                Monto = Math.Abs(Convert.ToDecimal(item[4].ToString()));
                                Estado = "1";

                                EEFFItemE oEEFFItem = AgenteContabilidad.Proxy.ObtenerEEFFItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idEEFF, CodItem);

                                if (oEEFFItem != null)
                                {
                                    if (oEEFFItem.codSunat != null && oEEFFItem.codSunat != "")
                                    {
                                        Cadena.Clear();

                                        Cadena.Append(Periodo).Append("|");
                                        Cadena.Append(Catalogo).Append("|");
                                        Cadena.Append(oEEFFItem.codSunat).Append("|");
                                        Cadena.Append(Monto.ToString("#####0.000")).Append("|");
                                        Cadena.Append(Estado).Append("|");

                                        oSw.WriteLine(Cadena.ToString());
                                    }
                                }
                            }
                        }

                        #endregion Exportacion a un archivo de texto

                        Global.MensajeComunicacion("Se generó el archivo correctamente.");
                    }
                }

                if (codEEFF == "EFED") // Flujo de Efectivo Metodo Directo
                {
                    #region Nombres de Archivos

                    String NombreArchivo = String.Empty;

                    // Creando el Nombre del Asiento
                    if (dgvPivot.Columns.Count > Variables.Cero)
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00031800001111";
                    }
                    else
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00031800001011";
                    }

                    String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                    #endregion

                    if (!String.IsNullOrEmpty(RutaArchivoTexto))
                    {
                        #region Borrando los archivos si existieran

                        if (File.Exists(RutaArchivoTexto))
                        {
                            File.Delete(RutaArchivoTexto);
                        }

                        #endregion

                        #region Exportacion a un archivo de texto

                        StringBuilder Cadena = new StringBuilder();
                        String Periodo, Estado, Catalogo;
                        Int32 CodItem;

                        using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                        {
                            foreach (DataRow item in dtDatos.Rows)
                            {
                                Periodo = anio + mesFin + "00";
                                Catalogo = "01";
                                CodItem = Convert.ToInt32(item[1].ToString());
                                CodigoItem = item[2].ToString();
                                Monto = Math.Abs(Convert.ToDecimal(item[4].ToString()));
                                Estado = "1";

                                EEFFItemE oEEFFItem = AgenteContabilidad.Proxy.ObtenerEEFFItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idEEFF, CodItem);

                                if (oEEFFItem != null)
                                {
                                    if (oEEFFItem.codSunat != null && oEEFFItem.codSunat != "")
                                    {
                                        Cadena.Clear();

                                        Cadena.Append(Periodo).Append("|");
                                        Cadena.Append(Catalogo).Append("|");
                                        Cadena.Append(oEEFFItem.codSunat).Append("|");
                                        Cadena.Append(Monto.ToString("#####0.000")).Append("|");
                                        Cadena.Append(Estado).Append("|");

                                        oSw.WriteLine(Cadena.ToString());
                                    }
                                }
                            }
                        }

                        #endregion Exportacion a un archivo de texto

                        Global.MensajeComunicacion("Se generó el archivo correctamente.");
                    }
                }

                if (codEEFF == "ECPN") // Estado de Cambio Patrimonio Neto
                {
                    #region Nombres de Archivos

                    String NombreArchivo = String.Empty;

                    // Creando el Nombre del Asiento
                    if (dgvPivot.Columns.Count > Variables.Cero)
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00031800001111";
                    }
                    else
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00031800001011";
                    }

                    String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                    #endregion

                    if (!String.IsNullOrEmpty(RutaArchivoTexto))
                    {
                        #region Borrando los archivos si existieran

                        if (File.Exists(RutaArchivoTexto))
                        {
                            File.Delete(RutaArchivoTexto);
                        }

                        #endregion

                        #region Exportacion a un archivo de texto

                        StringBuilder Cadena = new StringBuilder();
                        String Periodo, Estado, Catalogo;
                        Int32 CodItem;

                        using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                        {
                            foreach (DataRow item in dtDatos.Rows)
                            {
                                Periodo = anio + mesFin + "00";
                                Catalogo = "01";
                                CodItem = Convert.ToInt32(item[1].ToString());
                                CodigoItem = item[2].ToString();
                                Monto = Math.Abs(Convert.ToDecimal(item[4].ToString()));
                                Estado = "1";

                                EEFFItemE oEEFFItem = AgenteContabilidad.Proxy.ObtenerEEFFItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idEEFF, CodItem);

                                if (oEEFFItem != null)
                                {
                                    if (oEEFFItem.codSunat != null && oEEFFItem.codSunat != "")
                                    {
                                        Cadena.Clear();

                                        Cadena.Append(Periodo).Append("|");
                                        Cadena.Append(Catalogo).Append("|");
                                        Cadena.Append(oEEFFItem.codSunat).Append("|");
                                        Cadena.Append(Monto.ToString("#####0.000")).Append("|");
                                        Cadena.Append(Estado).Append("|");

                                        oSw.WriteLine(Cadena.ToString());
                                    }
                                }
                            }
                        }

                        #endregion Exportacion a un archivo de texto

                        Global.MensajeComunicacion("Se generó el archivo correctamente.");
                    }
                }


                if (codEEFF == "ERIN") // Estado de Resultado Integrales
                {
                    #region Nombres de Archivos

                    String NombreArchivo = String.Empty;

                    // Creando el Nombre del Asiento
                    if (dgvPivot.Columns.Count > Variables.Cero)
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00032400001111";
                    }
                    else
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00032400001011";
                    }

                    String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                    #endregion

                    if (!String.IsNullOrEmpty(RutaArchivoTexto))
                    {
                        #region Borrando los archivos si existieran

                        if (File.Exists(RutaArchivoTexto))
                        {
                            File.Delete(RutaArchivoTexto);
                        }

                        #endregion

                        #region Exportacion a un archivo de texto

                        StringBuilder Cadena = new StringBuilder();
                        String Periodo, Estado, Catalogo;
                        Int32 CodItem;

                        using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                        {
                            foreach (DataRow item in dtDatos.Rows)
                            {
                                Periodo = anio + mesFin + "00";
                                Catalogo = "01";
                                CodItem = Convert.ToInt32(item[1].ToString());
                                CodigoItem = item[2].ToString();
                                Monto = Math.Abs(Convert.ToDecimal(item[4].ToString()));
                                Estado = "1";

                                EEFFItemE oEEFFItem = AgenteContabilidad.Proxy.ObtenerEEFFItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idEEFF, CodItem);

                                if (oEEFFItem != null)
                                {
                                    if (oEEFFItem.codSunat != null && oEEFFItem.codSunat != "")
                                    {
                                        Cadena.Clear();

                                        Cadena.Append(Periodo).Append("|");
                                        Cadena.Append(Catalogo).Append("|");
                                        Cadena.Append(oEEFFItem.codSunat).Append("|");
                                        Cadena.Append(Monto.ToString("#####0.000")).Append("|");
                                        Cadena.Append(Estado).Append("|");

                                        oSw.WriteLine(Cadena.ToString());
                                    }
                                }
                            }
                        }

                        #endregion Exportacion a un archivo de texto

                        Global.MensajeComunicacion("Se generó el archivo correctamente.");
                    }
                }

                if (codEEFF == "EFEI") // Estado de Flujo de Efectivo Metodo Indirecto
                {
                    #region Nombres de Archivos

                    String NombreArchivo = String.Empty;

                    // Creando el Nombre del Asiento
                    if (dgvPivot.Columns.Count > Variables.Cero)
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00032500001111";
                    }
                    else
                    {
                        NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anio + mesFin + "00032500001011";
                    }

                    String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                    #endregion

                    if (!String.IsNullOrEmpty(RutaArchivoTexto))
                    {
                        #region Borrando los archivos si existieran

                        if (File.Exists(RutaArchivoTexto))
                        {
                            File.Delete(RutaArchivoTexto);
                        }

                        #endregion

                        #region Exportacion a un archivo de texto

                        StringBuilder Cadena = new StringBuilder();
                        String Periodo, Estado, Catalogo;
                        Int32 CodItem;

                        using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                        {
                            foreach (DataRow item in dtDatos.Rows)
                            {
                                Periodo = anio + mesFin + "00";
                                Catalogo = "01";
                                CodItem = Convert.ToInt32(item[1].ToString());
                                CodigoItem = item[2].ToString();
                                Monto = Math.Abs(Convert.ToDecimal(item[4].ToString()));
                                Estado = "1";

                                EEFFItemE oEEFFItem = AgenteContabilidad.Proxy.ObtenerEEFFItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idEEFF, CodItem);

                                if (oEEFFItem != null)
                                {
                                    if (oEEFFItem.codSunat != null && oEEFFItem.codSunat != "")
                                    {
                                        Cadena.Clear();

                                        Cadena.Append(Periodo).Append("|");
                                        Cadena.Append(Catalogo).Append("|");
                                        Cadena.Append(oEEFFItem.codSunat).Append("|");
                                        Cadena.Append(Monto.ToString("#####0.000")).Append("|");
                                        Cadena.Append(Estado).Append("|");

                                        oSw.WriteLine(Cadena.ToString());
                                    }
                                }
                            }
                        }

                        #endregion Exportacion a un archivo de texto

                        Global.MensajeComunicacion("Se generó el archivo correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(String.Format(ex.Message + " Revisar la linea {0} con Cód.Uni.Ope. {1}", Linea.ToString(), Correlativo));
            }
        }

        private void cboEEFF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                btPle.Enabled = ((EEFFE)cboEEFF.SelectedItem).indComparativo;
                codEEFF = ((EEFFE)cboEEFF.SelectedItem).TipoSeccion;

                if (((EEFFE)cboEEFF.SelectedItem).idEEFF == 1)
                {
                    if (rdbTipoReporteCCostos.Checked)
                    {
                        chbAcumulado.Visible = false;
                    }
                    else
                    {
                        chbAcumulado.Visible = true;
                    }
                }
                else
                {
                    chbAcumulado.Visible = false;
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
