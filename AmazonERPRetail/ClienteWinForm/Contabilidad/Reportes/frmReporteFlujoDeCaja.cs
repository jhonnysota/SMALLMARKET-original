using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteFlujoDeCaja : FrmMantenimientoBase
    {

        #region Constructores

        public frmReporteFlujoDeCaja()
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
        List<FlujoDeCajaE> oListaReporte = null;
        Decimal numcero = 0;
        String Partida;
        //string idCCostos = "";
       // string fl_TipoReporte = "";
        //string idMoneda;
        string columnName;
        string anio;

        String RutaGeneral = String.Empty;
        int RowIndexPOS = -1;
        String TipoRep = String.Empty;

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {                        
                //idCCostos = "";
                Cursor = Cursors.WaitCursor;
                TipoRep = "rep";              
             
                if (ValidarGrabacion())
                {
                    timer.Enabled = true;
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
            //CerrarFormulario("frmReporteEEFFGananciasyPerdidasImprimir");

            //Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasImprimir);

            //if (oFrm != null)
            //{
            //    if (oFrm.WindowState == FormWindowState.Minimized)
            //    {
            //        oFrm.WindowState = FormWindowState.Normal;
            //    }

            //    oFrm.BringToFront();
            //    return;
            //}

            //oFrm = new frmReporteEEFFGananciasyPerdidasImprimir(dtDatos, desEEFF, mesFin);
            //oFrm.MdiParent = MdiParent;
            //oFrm.Show();
        }

        public override void Exportar()
        {
            try
            {
                try
                {
                    if (dgvPivot.RowCount == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }

                    String NombreArchivo = String.Empty;
                    String TituloGeneral = String.Empty;
                    String nomPestaña = String.Empty;

                    RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Reporte Flujo De Caja", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        timer.Enabled = true;
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

                    TituloGeneral = "Reporte De Flujos De Cajas";
                    nomPestaña = "Flujo De Caja";

                    RutaGeneral += NombreArchivo;

                    if (File.Exists(RutaGeneral)) File.Delete(RutaGeneral);
                    FileInfo newFile = new FileInfo(RutaGeneral);

                    using (ExcelPackage oExcel = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(nomPestaña);

                        if (oHoja != null)
                        {
                            Int32 InicioLinea = 4;
                            Int32 totColumnas = dgvPivot.ColumnCount;
                            //Creando el encabezado
                            oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                            using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britannic Bold", 22, FontStyle.Italic));
                                Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 207, 224));
                            }

                            oHoja.Cells["A2"].Value = TituloGeneral;

                            using (ExcelRange Rango = oHoja.Cells[2, 1, 2, totColumnas])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britannic Bold", 18, FontStyle.Italic));
                                Rango.Style.Font.Color.SetColor(Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 207, 224));
                            }

                            //Cabeceras del detalle
                            Int32 col = 1;
                            for (Int32 i = 0; i < totColumnas; i++)
                            {
                                //Nueva celda
                                String titDetalle = dgvPivot.Columns[i].HeaderText;

                                oHoja.Cells[InicioLinea, col].Value = titDetalle;
                                oHoja.Cells[InicioLinea, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(124, 135, 156));
                                oHoja.Cells[InicioLinea, col].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                col++;
                            }
                            //Autofiltro
                            oHoja.Cells[InicioLinea, 1, InicioLinea, totColumnas].AutoFilter = true;

                            //Aumentando una fila mas para continuar con el detalle
                            InicioLinea++;
                            String colum1;
                            String colum5;
                            String colum6;
                            col = 1;
                            for (int i = 0; i < dgvPivot.Rows.Count; i++)
                            {
                                for (int j = 0; j < totColumnas; j++)
                                {
                                    colum1 = Convert.ToString(oHoja.Cells[InicioLinea, 1].Value);
                                    colum5 = Convert.ToString(oHoja.Cells[InicioLinea, 5].Value);
                                    colum6 = Convert.ToString(oHoja.Cells[InicioLinea, 6].Value);
                        
                                    if (colum1 != "")
                                    {
                                        oHoja.Cells[InicioLinea, 1,InicioLinea,4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 1,InicioLinea,4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(243, 215, 197));
                                        oHoja.Cells[InicioLinea, 1, InicioLinea,4].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                        oHoja.Cells[InicioLinea, 5, InicioLinea, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 5, InicioLinea, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(188, 250, 252));
                                        oHoja.Cells[InicioLinea, 5, InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 255, 255));
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    }
                                    if (colum5 == "Total")
                                    {
                                        oHoja.Cells[InicioLinea, 1, InicioLinea,7].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, 1, InicioLinea,7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 1, InicioLinea,7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(243, 215, 197));
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(243, 215, 197));
                                        oHoja.Cells[InicioLinea, 8, InicioLinea,19].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    }
                                    if (colum5 == "")
                                    {
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 252, 36));
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 252, 36));
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    }
                                    if (colum6 == "Flujo Operativo")
                                    {
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(128, 214, 132));
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(128, 214, 132));
                                        oHoja.Cells[InicioLinea, 8, InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    }
                                    if (j >= 6)
                                    {
                                            Decimal valor = Convert.ToDecimal(dgvPivot[j, i].Value);

                                            if (valor == 0 || valor != 0)
                                            {
                                                oHoja.Cells[InicioLinea, col].Value = valor;
                                                oHoja.Cells[InicioLinea, col].Style.Numberformat.Format = "###,###,##0.00";
                                            }
                                    }
                                    else if (dgvPivot[j, i].Value is DateTime)
                                    {
                                        oHoja.Cells[InicioLinea, col].Value = dgvPivot[j, i].Value;
                                        oHoja.Cells[InicioLinea, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        oHoja.Cells[InicioLinea, col].Style.Numberformat.Format = "dd/MM/yyyy";
                                    }
                                    else
                                    {
                                        oHoja.Cells[InicioLinea, col].Style.Numberformat.Format = "@"; //Formato de texto
                                        oHoja.Cells[InicioLinea, col].Value = dgvPivot[j, i].Value.ToString();
                                    }

                                    col++;
                                }
                                col = 1;

                            
                                InicioLinea++;
                            }

                            //Linea
                            Int32 totFilas = InicioLinea;
                            oHoja.Cells[InicioLinea, 1, InicioLinea, totColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                            //Suma
                            InicioLinea++;

                            //Ajustando el ancho de las columnas automaticamente
                            oHoja.Cells.AutoFitColumns(0);

                            //Insertando Encabezado
                            oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                            //Pie de Pagina(Derecho) "Número de paginas y el total"
                            oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                            //Pie de Pagina(centro)
                            oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                            //Otras Propiedades
                            oHoja.Workbook.Properties.Title = TituloGeneral;
                            oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                            oHoja.Workbook.Properties.Subject = "Reportes";
                            //oHoja.Workbook.Properties.Keywords = "";
                            oHoja.Workbook.Properties.Category = "Modulo de Producción";
                            oHoja.Workbook.Properties.Comments = "Reporte de " + nomPestaña;

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
                catch (Exception ex)
                {
                    Global.MensajeError(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {

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
                    int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    int Local = Convert.ToInt32(cboSucursal.SelectedValue);


                    String MeAnioIni = String.Empty;

                    if (dtpFechaInicio.Value.Month > 9)
                    {
                        MeAnioIni = dtpFechaInicio.Value.Year + "-" + dtpFechaInicio.Value.Month;
                    }
                    else
                    {
                        MeAnioIni = dtpFechaInicio.Value.Year + "-" +  "0"+ dtpFechaInicio.Value.Month;
                    }

                    String MesAnioFin;

                    if (dtpFechaFin.Value.Month > 9)
                    {
                        MesAnioFin = dtpFechaFin.Value.Year + "-" + dtpFechaFin.Value.Month;
                    }
                    else
                    {
                        MesAnioFin = dtpFechaFin.Value.Year + "-" + "0" + dtpFechaFin.Value.Month;
                    }

                    oListaReporte = AgenteContabilidad.Proxy.ReporteFlujoCaja(idEmpresa, Local, MeAnioIni, MesAnioFin);
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
            timer.Enabled = false;
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
            #region Definicion Data Table
            dtDatos = new DataTable();
            DataRow dt = null;
            DataRow tot = null;
            DataRow FlujoOperativo = null;
            DataRow Datos1 = null;
            DataRow Datos2 = null;

            FlujoOperativo = dtDatos.NewRow();
            Datos1 = dtDatos.NewRow();
            Datos2 = dtDatos.NewRow();

            #endregion

            string CodPartida = "-";
            string Partida = "N-";
            string SubPartida = "--";
            string Identificador = "--";
            int solouno = 0;
            //Decimal DatosMes = 0;

            #region Definir Cabecera Dinamica
            List<FlujoDeCajaE> listaCabe;
            //listaCabe = oListaReporte.Where(x => x.IMPORTE != 0 ).GroupBy(x => x.SUB_PARTIDA).Select(w => w.First()).ToList();
            listaCabe = oListaReporte.Where(x => x.IMPORTE != 0).GroupBy(x => x.MES).Select(g => g.First()).OrderBy(x => x.MES).ToList();

            dtDatos.Columns.Add("IDENTIFICADOR");
            dtDatos.Columns.Add("COD_PARTIDA");
            dtDatos.Columns.Add("PARTIDA");
            dtDatos.Columns.Add("MOV");
            dtDatos.Columns.Add("SUB_PARTIDA");
            dtDatos.Columns.Add("SUB_PARTIDA_PRESU");
            dtDatos.Columns.Add("IMPORTE");

            for (int i = 0; i < listaCabe.Count; i++)
            {
             string mes = listaCabe[i].MES;
             dtDatos.Columns.Add(listaCabe[i].AÑO + " - " + mes.ToUpper());
            }

            #endregion

            #region Datos Iniciales para Empezar Listado
            List<FlujoDeCajaE> listaData = (from x in oListaReporte where x.IMPORTE != 0 select x).ToList();
            if (listaData.Count > 0)
             {
             CodPartida = listaData[0].COD_PARTIDA;
             Partida = listaData[0].PARTIDA;
             Identificador = listaData[0].IDENTIFICADOR;
             }
            #endregion

            for (int data = 0; data < listaData.Count; data++)
            {
                #region Sub-Total -- Acumular Mientras Partida es Diferente 

                if (CodPartida != listaData[data].COD_PARTIDA)
                {
                    tot = dtDatos.NewRow();
                    tot["IDENTIFICADOR"] = "";
                    tot["COD_PARTIDA"] = "";
                    tot["PARTIDA"] = "";
                    tot["MOV"] = "";
                    tot["SUB_PARTIDA"] = "Total";
                    tot["SUB_PARTIDA_PRESU"] = Partida;
                    tot["IMPORTE"] = "";

                    Decimal totalSub = 0;

                    for (int i = 0; i < listaCabe.Count; i++)
                    {
                        string mes = listaCabe[i].MES;
                        List<FlujoDeCajaE> item;
                        string NombreColumna = "";
                        NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
                        item = (from x in oListaReporte
                                where x.AÑO == listaCabe[i].AÑO &&
                                      x.MES == listaCabe[i].MES &&
                                      x.COD_PARTIDA == CodPartida
                                select x).ToList();

                        if (item != null && item.Count > 0)
                        {
                         tot[NombreColumna] = Convert.ToDecimal((from x in item select x.IMPORTE).Sum()).ToString("N2");
                         totalSub += Convert.ToDecimal(tot[NombreColumna]);
                        }
                        else
                        {
                         tot[NombreColumna] = numcero.ToString("N2");                    
                        }

                    }
                    tot["IMPORTE"] = Convert.ToDecimal(totalSub).ToString("N2");
                    dtDatos.Rows.Add(tot);

                    CodPartida = listaData[data].COD_PARTIDA;
                    Partida = listaData[data].PARTIDA;

                }

                #endregion

                #region Total - Ingresos Operacion Acumular Mientras Identificador es Diferente y == 0

                if (Identificador != listaData[data].IDENTIFICADOR && solouno == 0)
                {
                    tot = dtDatos.NewRow();
                    tot["IDENTIFICADOR"] = "";
                    tot["COD_PARTIDA"] = "";
                    tot["PARTIDA"] = "";
                    tot["MOV"] = "";
                    tot["SUB_PARTIDA"] = "";
                    tot["SUB_PARTIDA_PRESU"] = "Total Ingresos de Operación";
                    tot["IMPORTE"] = "";

                    Datos1["IDENTIFICADOR"] = "";
                    Datos1["COD_PARTIDA"] = "";
                    Datos1["PARTIDA"] = "";
                    Datos1["MOV"] = "";
                    Datos1["SUB_PARTIDA"] = "";
                    Datos1["SUB_PARTIDA_PRESU"] = "Flujo Operativo1";
                    Datos1["IMPORTE"] = "";

                    Decimal totalSub = 0;
                    Decimal totalDatos1 = 0;
                    for (int i = 0; i < listaCabe.Count; i++)
                    {
                        string mes = listaCabe[i].MES;
                        List<FlujoDeCajaE> item;
                        string NombreColumna = "";
                        NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
                        item = (from x in oListaReporte
                                where x.AÑO == listaCabe[i].AÑO &&
                                      x.MES == listaCabe[i].MES &&
                                      x.IDENTIFICADOR == Identificador
                                select x).ToList();

                        if (item != null && item.Count > 0)
                        {
                            tot[NombreColumna] = Convert.ToDecimal((from x in item select x.IMPORTE).Sum()).ToString("N2");
                            totalSub += ((from x in item select x.IMPORTE).Sum());
                            Datos1[NombreColumna] = tot[NombreColumna];
                            totalDatos1 += Convert.ToDecimal(tot[NombreColumna]);

                        }
                        else
                        {
                            tot[NombreColumna] = numcero.ToString("N2");
                            Datos1[NombreColumna] = numcero.ToString("N2");
                        }

                    }
                    tot["IMPORTE"] = Convert.ToDecimal(totalSub).ToString("N2");
                    Datos1["IMPORTE"] = Convert.ToDecimal(totalDatos1).ToString("N2");

                    dtDatos.Rows.Add(tot);

                    Identificador = listaData[data].IDENTIFICADOR;
                    solouno++;
                }

                #endregion

                #region Total - Egresos Operacion Acumular Mientras Identificador es Diferente y == 1

                if (Identificador != listaData[data].IDENTIFICADOR && solouno == 1)
                {
                    tot = dtDatos.NewRow();
                    tot["IDENTIFICADOR"] = "";
                    tot["COD_PARTIDA"] = "";
                    tot["PARTIDA"] = "";
                    tot["MOV"] = "";
                    tot["SUB_PARTIDA"] = "";
                    tot["SUB_PARTIDA_PRESU"] = "Total Egresos de Operación";
                    tot["IMPORTE"] = "";

                    Datos2["IDENTIFICADOR"] = "";
                    Datos2["COD_PARTIDA"] = "";
                    Datos2["PARTIDA"] = "";
                    Datos2["MOV"] = "";
                    Datos2["SUB_PARTIDA"] = "";
                    Datos2["SUB_PARTIDA_PRESU"] = "Flujo Operativo2";
                    Datos2["IMPORTE"] = "";

                    Decimal totalSub = 0;
                    Decimal totalDatos2 = 0;
                    for (int i = 0; i < listaCabe.Count; i++)
                    {
                        string mes = listaCabe[i].MES;
                        List<FlujoDeCajaE> item;
                        string NombreColumna = "";
                        NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
                        item = (from x in oListaReporte
                                where x.AÑO == listaCabe[i].AÑO &&
                                      x.MES == listaCabe[i].MES &&
                                      x.IDENTIFICADOR == Identificador
                                select x).ToList();

                        if (item != null && item.Count > 0)
                        {
                            tot[NombreColumna] = Convert.ToDecimal((from x in item select x.IMPORTE).Sum()).ToString("N2");
                            totalSub += ((from x in item select x.IMPORTE).Sum());
                            Datos2[NombreColumna] = tot[NombreColumna];
                            totalDatos2 += Convert.ToDecimal(tot[NombreColumna]);
                        }
                        else
                        {
                            tot[NombreColumna] = numcero.ToString("N2");
                            Datos2[NombreColumna] = numcero.ToString("N2");
                        }

                    }
                    tot["IMPORTE"] = Convert.ToDecimal(totalSub).ToString("N2");
                    Datos2["IMPORTE"] = Convert.ToDecimal(totalDatos2).ToString("N2");
                    dtDatos.Rows.Add(tot);

                    // Agregar Flujo Operativo 
                    FlujoOperativo["IDENTIFICADOR"] = "";
                    FlujoOperativo["COD_PARTIDA"] = "";
                    FlujoOperativo["PARTIDA"] = "";
                    FlujoOperativo["MOV"] = "";
                    FlujoOperativo["SUB_PARTIDA"] = "";
                    FlujoOperativo["SUB_PARTIDA_PRESU"] = "Flujo Operativo";
                    FlujoOperativo["IMPORTE"] = "";

                    for (int i = 0; i < listaCabe.Count; i++)
                     {
                      string mes = listaCabe[i].MES;
                      string NombreColumna = "";
                      NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
                      Decimal Valor1 = Convert.ToDecimal(Datos1[NombreColumna]);
                      Decimal Valor2 = Convert.ToDecimal(Datos2[NombreColumna]);
                      Decimal Tot = Valor1 + Valor2;
                      FlujoOperativo[NombreColumna] = Tot.ToString("N2");
                     }

                    Decimal Valor11 = Convert.ToDecimal(Datos1["IMPORTE"]);
                    Decimal Valor21 = Convert.ToDecimal(Datos2["IMPORTE"]);
                    Decimal Tot1 = Valor11 + Valor21;
                    FlujoOperativo["IMPORTE"] = Tot1.ToString("N2");

                    dtDatos.Rows.Add(FlujoOperativo);
                     
                    Identificador = listaData[data].IDENTIFICADOR;
                    solouno++;
                }

                #endregion

                #region Flujo de Inversion -- Acumular Mientras Identificador es Diferente y == 2

                if (Identificador != listaData[data].IDENTIFICADOR && solouno == 2)
                {
                    tot = dtDatos.NewRow();
                    tot["IDENTIFICADOR"] = "";
                    tot["COD_PARTIDA"] = "";
                    tot["PARTIDA"] = "";
                    tot["MOV"] = "";
                    tot["SUB_PARTIDA"] = "";
                    tot["SUB_PARTIDA_PRESU"] = "Flujo De Inversión";
                    tot["IMPORTE"] = "";
                    Decimal? totalSub = 0;
                    for (int i = 0; i < listaCabe.Count; i++)
                    {
                        string mes = listaCabe[i].MES;
                        List<FlujoDeCajaE> item;
                        string NombreColumna = "";
                        NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
                        item = (from x in oListaReporte
                                where x.AÑO == listaCabe[i].AÑO &&
                                      x.MES == listaCabe[i].MES &&
                                      x.IDENTIFICADOR == Identificador
                                select x).ToList();

                        if (item != null && item.Count > 0)
                        {
                            tot[NombreColumna] = Convert.ToDecimal((from x in item select x.IMPORTE).Sum()).ToString("N2");
                            totalSub += ((from x in item select x.IMPORTE).Sum());
                        }
                        else
                        {
                            tot[NombreColumna] = numcero.ToString("N2");
                        }

                    }
                    tot["IMPORTE"] = Convert.ToDecimal(totalSub).ToString("N2");
                    dtDatos.Rows.Add(tot);

                    Identificador = listaData[data].IDENTIFICADOR;
                    solouno++;
                }

                #endregion

                #region Flujo Financiero -- Acumular Mientras Identificador es Diferente y == 3

                if (Identificador != listaData[data].IDENTIFICADOR && solouno == 3)
                {
                    tot = dtDatos.NewRow();
                    tot["IDENTIFICADOR"] = "";
                    tot["COD_PARTIDA"] = "";
                    tot["PARTIDA"] = "";
                    tot["MOV"] = "";
                    tot["SUB_PARTIDA"] = "";
                    tot["SUB_PARTIDA_PRESU"] = "Flujo Financiero";
                    tot["IMPORTE"] = "";
                    Decimal? totalSub = 0;
                    for (int i = 0; i < listaCabe.Count; i++)
                    {
                        string mes = listaCabe[i].MES;
                        List<FlujoDeCajaE> item;
                        string NombreColumna = "";
                        NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
                        item = (from x in oListaReporte
                                where x.AÑO == listaCabe[i].AÑO &&
                                      x.MES == listaCabe[i].MES &&
                                      x.IDENTIFICADOR == Identificador
                                select x).ToList();

                        if (item != null && item.Count > 0)
                        {
                            tot[NombreColumna] = Convert.ToDecimal((from x in item select x.IMPORTE).Sum()).ToString("N2");
                            totalSub += ((from x in item select x.IMPORTE).Sum());
                        }
                        else
                        {
                            tot[NombreColumna] = numcero.ToString("N2");
                        }

                    }
                    tot["IMPORTE"] = Convert.ToDecimal(totalSub).ToString("N2");
                    dtDatos.Rows.Add(tot);

                    Identificador = listaData[data].IDENTIFICADOR;
                    solouno++;
                }

                #endregion

                #region Detalle -- Acumular Mientras SubPartida es Diferente

                if (SubPartida != listaData[data].SUB_PARTIDA)
               {

                dt = dtDatos.NewRow();
                SubPartida = listaData[data].SUB_PARTIDA;
                
                dt["IDENTIFICADOR"] = listaData[data].IDENTIFICADOR;
                dt["COD_PARTIDA"] = listaData[data].COD_PARTIDA;
                dt["PARTIDA"] = listaData[data].PARTIDA;
                dt["MOV"] = listaData[data].MOV;
                dt["SUB_PARTIDA"] = listaData[data].SUB_PARTIDA;
                dt["SUB_PARTIDA_PRESU"] = listaData[data].SUB_PARTIDA_PRESU;
            
                decimal Total = 0;

                for (int i = 0; i < listaCabe.Count; i++)
                 {
                  string mes = listaCabe[i].MES; 
                  List<FlujoDeCajaE> item;
                  string NombreColumna = "";
                  NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper(); 
                  item = (from x in oListaReporte
                         where x.AÑO == listaCabe[i].AÑO &&
                               x.MES == listaCabe[i].MES &&
                               x.SUB_PARTIDA == SubPartida
                        select x).ToList();

                  if (item != null && item.Count > 0)
                   {
                    dt[NombreColumna] = Convert.ToDecimal((from x in item select x.IMPORTE).Sum()).ToString("N2");
                    Total += (from x in item select x.IMPORTE).Sum();
                   }
                  else
                   {
                    dt[NombreColumna] = numcero.ToString("N2"); ;
                   }
                  }

                dt["IMPORTE"] = Convert.ToDecimal(Total).ToString("N2");
                dtDatos.Rows.Add(dt);

                }
              #endregion
            }

            #region Flujo Neto -- Acumular Mientras Identificador es Diferente y == 4
            if (solouno == 4)
            {

             DataRow FlujoNeto = null;
             FlujoNeto = dtDatos.NewRow();
             // Agregar Flujo Operativo 
             FlujoNeto["IDENTIFICADOR"] = "";
             FlujoNeto["COD_PARTIDA"] = "";
             FlujoNeto["PARTIDA"] = "";
             FlujoNeto["MOV"] = "";
             FlujoNeto["SUB_PARTIDA"] = "";
             FlujoNeto["SUB_PARTIDA_PRESU"] = "Flujo Neto";
             FlujoNeto["IMPORTE"] = "";

             for (int i = 0; i < listaCabe.Count; i++)
             {
              string mes = listaCabe[i].MES;
              string NombreColumna = "";
              NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
              Decimal ValorCero = 0;
              FlujoNeto[NombreColumna] = ValorCero.ToString("N2");
             }

            Decimal TotalFlujoNeto = 0;
             
            foreach (DataRow dtRow in dtDatos.Rows)
             {
              if (dtRow["SUB_PARTIDA"].ToString() == "0001" || 
                  dtRow["SUB_PARTIDA"].ToString() == "0002" ||
                  dtRow["SUB_PARTIDA"].ToString() == "0003" ||
                  dtRow["SUB_PARTIDA"].ToString() == "0004")
               {
                for (int i = 0; i < listaCabe.Count; i++)
                 {
                  string mes = listaCabe[i].MES;
                  string NombreColumna = "";
                  NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
                  Decimal ValorColumna = Convert.ToDecimal(FlujoNeto[NombreColumna]) + Convert.ToDecimal(dtRow[NombreColumna]);
                  FlujoNeto[NombreColumna] = ValorColumna.ToString("N2");  
                 }
               TotalFlujoNeto = TotalFlujoNeto + Convert.ToDecimal(dtRow["IMPORTE"]);
               }
             }

            FlujoNeto["IMPORTE"] = TotalFlujoNeto.ToString("N2");
            dtDatos.Rows.Add(FlujoNeto);

            DataRow SaldoFinal = null;
            SaldoFinal = dtDatos.NewRow();
            // Agregar Flujo Operativo 
            SaldoFinal["IDENTIFICADOR"] = "";
            SaldoFinal["COD_PARTIDA"] = "";
            SaldoFinal["PARTIDA"] = "";
            SaldoFinal["MOV"] = "";
            SaldoFinal["SUB_PARTIDA"] = "";
            SaldoFinal["SUB_PARTIDA_PRESU"] = "SALDO FINAL";
            SaldoFinal["IMPORTE"] = "";

            for (int i = 0; i < listaCabe.Count; i++)
             {
              string mes = listaCabe[i].MES;
              string NombreColumna = "";
              NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
              Decimal ValorCero = 0;
              SaldoFinal[NombreColumna] = ValorCero.ToString("N2");
             }

            Decimal TotalSaldoFinal = 0;

            foreach (DataRow dtRow in dtDatos.Rows)
            {
             if (dtRow["SUB_PARTIDA"].ToString() == "0000" ||
                 dtRow["SUB_PARTIDA"].ToString() == "0001" ||
                 dtRow["SUB_PARTIDA"].ToString() == "0002" ||
                 dtRow["SUB_PARTIDA"].ToString() == "0003" ||
                 dtRow["SUB_PARTIDA"].ToString() == "0004")
              {
               for (int i = 0; i < listaCabe.Count; i++)
               {
                string mes = listaCabe[i].MES;
                string NombreColumna = "";
                NombreColumna = listaCabe[i].AÑO + " - " + mes.ToUpper();
                Decimal ValorColumna = Convert.ToDecimal(SaldoFinal[NombreColumna]) + Convert.ToDecimal(dtRow[NombreColumna]);
                SaldoFinal[NombreColumna] = ValorColumna.ToString("N2");
               }
               TotalSaldoFinal = TotalSaldoFinal + Convert.ToDecimal(dtRow["IMPORTE"]);
              }
            }

            SaldoFinal["IMPORTE"] = TotalSaldoFinal.ToString("N2");
            dtDatos.Rows.Add(SaldoFinal);

            }
            #endregion

            #region Configurar Grid View

            tsmiExcel.Enabled = false;

            dgvPivot.DataSource = dtDatos;
            dgvPivot.GrupoColumnas = new String[] { "IDENTIFICADOR", "COD_PARTIDA","PARTIDA","MOV" };

            // Identificador
            dgvPivot.Columns[0].Frozen = true;
            dgvPivot.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPivot.Columns[0].Width = 20;
           
            // Codigo de Partida
            dgvPivot.Columns[1].Frozen = true;
            dgvPivot.Columns[1].Width = 30;
            dgvPivot.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Partida
            dgvPivot.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPivot.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPivot.Columns[2].Frozen = true;
            dgvPivot.Columns[2].Width = 150;

            // Movimiento Mes
            dgvPivot.Columns[3].Width = 40;
            dgvPivot.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPivot.Columns[3].Frozen = true;

            for (int i = 0; i < dgvPivot.Columns.Count; i++)
            {
                if (i <= 3)
                {
                    dgvPivot.Columns[i].DefaultCellStyle.BackColor = Color.Bisque;
                    dgvPivot.Columns[i].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                    dgvPivot.Columns[i].Frozen = true;
                }

                if (i == 4 )
                {
                    dgvPivot.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPivot.Columns[i].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                    dgvPivot.Columns[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                    dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPivot.Columns[i].Width = 70;
                    dgvPivot.Columns[i].Frozen = true;
                }

                if ( i == 5 )
                {
                    dgvPivot.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPivot.Columns[i].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                    dgvPivot.Columns[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                    dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvPivot.Columns[i].Width = 250;
                    dgvPivot.Columns[i].Frozen = true;
                }

                if (i == 6)
                {
                    dgvPivot.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPivot.Columns[i].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                    dgvPivot.Columns[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                    dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPivot.Columns[i].Width = 105;
                    dgvPivot.Columns[i].Frozen = true;
                }

                if (i > 6)
                {
                    dgvPivot.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPivot.Columns[i].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                    dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPivot.Columns[i].Width = 105;
                }
            }
            #endregion
        }

   



        void LlenarCombos()
        {

            Int32 Niveles = AgenteMaestro.Proxy.MaxNivelCCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ParTabla Item = null;
            List<ParTabla> Lista = new List<ParTabla>();

            for (int i = 1; i <= Niveles; i++)
            {
                Item = new ParTabla() { IdParTabla = i, Nombre = "Nivel " + i.ToString() };
                Lista.Add(Item);
            }

            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();

            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);

            if (listaLocales.Count == 2)
            {
                cboSucursal.SelectedValue = 1;
            }

        }

        void ExportarExcel(String Ruta)
        {
            //String TituloGeneral = String.Empty;
            //String NombrePestaña = String.Empty;

            //TituloGeneral =  " a " + FechasHelper.NombreMes(Convert.ToInt32(mesFin)) + " del " + anio;
            //NombrePestaña = "Reporte";

            //if (File.Exists(Ruta)) File.Delete(Ruta);
            //FileInfo newFile = new FileInfo(Ruta);

            //using (ExcelPackage oExcel = new ExcelPackage(newFile))
            //{
            //    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

            //    if (oHoja != null)
            //    {
            //        Int32 InicioLinea = 4;
            //        Int32 TotColumnas = dgvPivot.ColumnCount;

            //        #region Titulos Principales

            //        // Creando Encabezado;
            //        oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

            //        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas-2])
            //        {
            //            Rango.Merge = true;
            //            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
            //            Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
            //            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
            //        }

            //        oHoja.Cells["A2"].Value = TituloGeneral;

            //        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas-2])
            //        {
            //            Rango.Merge = true;
            //            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
            //            Rango.Style.Font.Color.SetColor(Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
            //        }

            //        #endregion

            //        #region Cabeceras del Detalle

            //        Int32 col = 1;

            //        for (Int32 i = 2; i < TotColumnas; i++)
            //        {
            //            //Nueva Celda
            //            String titDetalle = dgvPivot.Columns[i].HeaderText;

            //            oHoja.Cells[InicioLinea, col].Value = titDetalle;
            //            oHoja.Cells[InicioLinea, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            oHoja.Cells[InicioLinea, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
            //            oHoja.Cells[InicioLinea, col].Style.Font.Bold = true;
            //            oHoja.Cells[InicioLinea, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
            //            col++;
            //        }

            //        // Auto Filtro
            //        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas-2].AutoFilter = true;

            //        #endregion

            //        //Aumentando una Fila mas continuar con el detalle
            //        InicioLinea++;
            //        col = 1;

            //        foreach (DataRow item in dtDatos.Rows)
            //        {
            //            for (int i = 2; i < TotColumnas; i++)
            //            {
            //                oHoja.Cells[InicioLinea, i-1].Value = item[i];

            //                if (i == 4)
            //                {
            //                    oHoja.Cells[InicioLinea, i - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //                    oHoja.Cells[InicioLinea, i - 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.PaleTurquoise);
            //                }

            //                if (i >= 4)
            //                {
            //                    oHoja.Cells[InicioLinea, i-1].Style.Numberformat.Format = "###,###,##0.00";
            //                    oHoja.Cells[InicioLinea, i - 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            //                }
            //            }

            //            InicioLinea++;
            //        }

            //        //Linea
            //        Int32 totFilas = InicioLinea;
            //        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas-2].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

            //        InicioLinea++;

            //        //Ajustando el ancho de las columnas automaticamente
            //        oHoja.Cells.AutoFitColumns(0);

            //        //Insertando Encabezado
            //        oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
            //        //Pie de Pagina(Derecho) "Número de paginas y el total"
            //        oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
            //        //Pie de Pagina(centro)
            //        oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

            //        //Otras Propiedades
            //        oHoja.Workbook.Properties.Title = TituloGeneral;
            //        oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
            //        oHoja.Workbook.Properties.Subject = "Reportes";
            //        //oHoja.Workbook.Properties.Keywords = "";
            //        oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
            //        oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

            //        // Establecer algunos valores de las propiedades extendidas
            //        oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

            //        //Propiedades para imprimir
            //        oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
            //        oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

            //        //Guardando el excel
            //        oExcel.Save();
            //    }
            //}
        }

        #endregion

        #region Eventos

        private void frmReporteEEFFGananciasPerdidasMeses_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFechaInicio.Value = Convert.ToDateTime("01/01/" + Convert.ToString(DateTime.Now.Year));
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
            //int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            //int idLocal = VariablesLocales.SesionLocal.IdLocal;

            //int rowindex = dgvPivot.CurrentCell.RowIndex;
            //int columnindex = dgvPivot.CurrentCell.ColumnIndex;


            //// se valida que sea celda con valor
            //if (columnindex > 3 && columnindex < dgvPivot.Columns.Count && dgvPivot.Rows[rowindex].Cells[0].Value.ToString() == "DET")
            //{
            //    int idEEFFItem = Convert.ToInt32(dgvPivot.Rows[rowindex].Cells[1].Value.ToString());
            //    string desItem = dgvPivot.Rows[rowindex].Cells[3].Value.ToString();

            //    columnName = dgvPivot.Columns[columnindex].Name;
            //    string mes = (columnName.Contains("ENE") ? "01" : (columnName.Contains("FEB") ? "02" : (columnName.Contains("MAR") ? "03" : (columnName.Contains("ABR") ? "04" : (columnName.Contains("MAY") ? "05" : (columnName.Contains("JUN") ? "06" : (columnName.Contains("JUL") ? "07" : (columnName.Contains("AGO") ? "08" : (columnName.Contains("SEP") ? "09" : (columnName.Contains("OCT") ? "10" : (columnName.Contains("NOV") ? "11" : (columnName.Contains("DIC") ? "12" : "00"))))))))))));

            //    // =========================================================
            //    if (fl_TipoReporte != "0")
            //        idCCostos = columnName.Split('-')[0].Trim();

            //    List<VoucherItemE> oListaDetalle;

            //    if (fl_TipoReporte == "0")
            //    {
            //        oListaDetalle = AgenteContabilidad.Proxy.ListarRptEEFFGananciasPerdidasDetalle(
            //                            idEmpresa, idLocal, anio, mesInicial, mes, idEEFF, idEEFFItem, idCCostos, idMoneda, fl_TipoReporte);
            //    }
            //    else
            //    {
            //        oListaDetalle = AgenteContabilidad.Proxy.ListarRptEEFFGananciasPerdidasDetalle(idEmpresa, idLocal, anio, (fl_TipoReporte == "0" ? mesInicial : mesInicial), (fl_TipoReporte == "0" ? mes : mesFin), idEEFF, idEEFFItem, idCCostos, idMoneda, fl_TipoReporte);
            //    }

            //    if (oListaDetalle == null || oListaDetalle.Count == 0)
            //    {
            //        Global.MensajeFault("No hay registros Voucher");
            //        return;
            //    }

            //    // =========================================================

            //    CerrarFormulario("frmReporteEEFFGananciasyPerdidasDetalle");

            //    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasDetalle);

            //    if (oFrm != null)
            //    {
            //        if (oFrm.WindowState == FormWindowState.Minimized)
            //        {
            //            oFrm.WindowState = FormWindowState.Normal;
            //        }

            //        oFrm.BringToFront();
            //        return;
            //    }

            //    oFrm = new frmReporteEEFFGananciasyPerdidasDetalle(oListaDetalle, desItem);
            //    oFrm.MdiParent = this.MdiParent;
            //    oFrm.Show();
            //}
        }

        private void dgvPivot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvPivot.Rows[e.RowIndex].Cells[4].Value.ToString().Contains("Total"))
                    {
                        RowIndexPOS = e.RowIndex;

                        DataGridViewCellStyle StyleNegrita = new DataGridViewCellStyle();
                        StyleNegrita.Font = new Font(dgvPivot.Font, FontStyle.Bold);

                        e.CellStyle.ApplyStyle(StyleNegrita);
                        e.CellStyle.BackColor = Color.Bisque;
                    }                                                                                                                               
                    else
                    if (dgvPivot.Rows[e.RowIndex].Cells[5].Value.ToString().Contains("Total Ingresos de Operación") ||
                        dgvPivot.Rows[e.RowIndex].Cells[5].Value.ToString().Contains("Total Egresos de Operación")) 
                    {
                        RowIndexPOS = e.RowIndex;

                        DataGridViewCellStyle StyleNegrita = new DataGridViewCellStyle();
                        StyleNegrita.Font = new Font(dgvPivot.Font, FontStyle.Bold);

                        e.CellStyle.ApplyStyle(StyleNegrita);
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    else
                    if (dgvPivot.Rows[e.RowIndex].Cells[5].Value.ToString().Contains("Flujo Operativo") || 
                        dgvPivot.Rows[e.RowIndex].Cells[5].Value.ToString().Contains("Flujo De Inversión") ||
                        dgvPivot.Rows[e.RowIndex].Cells[5].Value.ToString().Contains("Flujo Financiero") ||
                        dgvPivot.Rows[e.RowIndex].Cells[5].Value.ToString().Contains("Flujo Neto") ||
                        dgvPivot.Rows[e.RowIndex].Cells[5].Value.ToString().Contains("SALDO FINAL"))
                    {
                        RowIndexPOS = e.RowIndex;

                        DataGridViewCellStyle StyleNegrita = new DataGridViewCellStyle();
                        StyleNegrita.Font = new Font(dgvPivot.Font, FontStyle.Bold);

                        e.CellStyle.ApplyStyle(StyleNegrita);
                        e.CellStyle.BackColor = Color.DarkSeaGreen;
                    }
                    else
                    {
                        RowIndexPOS = -1;
                    }

                    //if (RowIndexPOS > 0)
                    //{
                    //    e.CellStyle.BackColor = Color.Bisque;
                    //}
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnVerCuentas_Click(object sender, EventArgs e)
        {           
        }

        private void tsmiCuentas_Click(object sender, EventArgs e)
        {
            try
            {
                //List<EEFFItemCtaE> ListaEEFFItemCta = new List<EEFFItemCtaE>();
                //int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                //int rowindex = dgvPivot.CurrentCell.RowIndex;
                //int columnindex = dgvPivot.CurrentCell.ColumnIndex;
                //int idEEFFItem = Convert.ToInt32(dgvPivot.Rows[rowindex].Cells[1].Value.ToString());
                //string desItem = dgvPivot.Rows[rowindex].Cells[3].Value.ToString();
                //String Mostrar = Variables.NO;

                ////ES FORMULA
                //if (dgvPivot.Rows[rowindex].Cells[0].Value.ToString().Contains("TOT"))
                //{
                //    List<EEFFItemForE> ListaEEFFItemFor = AgenteContabilidad.Proxy.ListarEEFFItemFor(idEmpresa, idEEFF, idEEFFItem);

                //    foreach (EEFFItemForE item in ListaEEFFItemFor)
                //    {
                //        ListaEEFFItemCta.Add(new EEFFItemCtaE { CodPlaCta = item.secItem, desCuenta = item.desItem });
                //    }
                //}
                //else
                //{
                //    String Cabecera = dgvPivot.Columns[columnindex].HeaderText;
                //    List<String> oLista = new List<String>(Cabecera.Split('-'));

                //    if (oLista[0].ToString().Trim() == "TOTAL")
                //    {
                //        ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, VariablesLocales.SesionLocal.IdLocal, anio, mesFin);
                //        Mostrar = Variables.SI;
                //    }
                //    else
                //    {
                //        if (oLista.Count == 2)
                //        {
                //            string numMes = FechasHelper.NumeroMes(oLista[1].Trim());
                //            ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, VariablesLocales.SesionLocal.IdLocal, oLista[0].Trim(), numMes);
                //        }
                //        else
                //        {
                //            ListaEEFFItemCta = AgenteContabilidad.Proxy.ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, 0, "", "");
                //        }
                //    }
                //}

                //CerrarFormulario("frmReporteEEFFGananciasyPerdidasCta");

                //Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasCta);

                //if (oFrm != null)
                //{
                //    if (oFrm.WindowState == FormWindowState.Minimized)
                //    {
                //        oFrm.WindowState = FormWindowState.Normal;
                //    }

                //    oFrm.BringToFront();
                //    return;
                //}

                //oFrm = new frmReporteEEFFGananciasyPerdidasCta(ListaEEFFItemCta, desItem, Mostrar, anio, mesFin);
                //oFrm.MdiParent = MdiParent;
                //oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboNivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void rdbTipoReporteCCostos_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void lnkTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void chbindCCostos_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chbtipo_cambio_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void tsmiExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                //int idLocal = VariablesLocales.SesionLocal.IdLocal;
                //string PlanCuentasActual = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                //int rowindex = dgvPivot.CurrentCell.RowIndex;
                //int idEEFFItem = Convert.ToInt32(dgvPivot.Rows[rowindex].Cells[1].Value.ToString());
                //string desEEFFItem = dgvPivot.Rows[rowindex].Cells[3].Value.ToString();

                //List<ReporteEEFFItemE> oListaArchivo = AgenteContabilidad.Proxy.ListarReporteEEFFGananciasPerdidasArchivo(idEmpresa, idEEFF, idEEFFItem);

                //if (oListaArchivo == null || oListaArchivo.Count == 0)
                //{
                //    Global.MensajeFault("El item seleccionado no tiene valores asignados");
                //    return;
                //}

                //List<EEFFItemE> oListaItem = AgenteContabilidad.Proxy.ListarEEFFItem(idEmpresa, idEEFF);

                //for (int i = 5; i < dgvPivot.Columns.Count; i++)
                //{
                //    idCCostos = dgvPivot.Columns[i].Name.Split('-')[0].Trim();

                //    for (int lin = 0; lin < dgvPivot.RowCount; lin++)
                //    {
                //        int idItem = Convert.ToInt32(dgvPivot.Rows[lin].Cells[1].Value.ToString());
                //        string tipoValorExcel = oListaItem.Where(x => x.idEEFFItem == idItem).ToList()[0].TipoColumna;

                //        for (int n = 0; n < oListaArchivo.Count; n++)
                //        {
                //            if (oListaArchivo[n].desCCostos == idCCostos && oListaArchivo[n].idEEFFItem == idItem)
                //            {
                //                decimal valor = Convert.ToDecimal(dgvPivot.Rows[lin].Cells[i].Value.ToString());
                //                valor = decimal.Round(valor, 0);
                //                valor = (tipoValorExcel == "2" ? valor * -1 : valor);
                //                oListaArchivo[n].saldo_sol = valor;
                //            }
                //        }
                //    }
                //}

                //CerrarFormulario("frmReporteEEFFGananciasyPerdidasArchivo");

                //Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteEEFFGananciasyPerdidasArchivo);

                //if (oFrm != null)
                //{
                //    if (oFrm.WindowState == FormWindowState.Minimized)
                //    {
                //        oFrm.WindowState = FormWindowState.Normal;
                //    }

                //    oFrm.BringToFront();
                //    return;
                //}

                //oFrm = new frmReporteEEFFGananciasyPerdidasArchivo(oListaArchivo, idMoneda, desEEFFItem);
                //oFrm.MdiParent = MdiParent;
                //oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPivot_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            int idLocal = VariablesLocales.SesionLocal.IdLocal;

            int rowindex = dgvPivot.CurrentCell.RowIndex;
            int columnindex = dgvPivot.CurrentCell.ColumnIndex;


            // se valida que sea celda con valor
            if (columnindex > 6 && columnindex < dgvPivot.Columns.Count && dgvPivot.Rows[rowindex].Cells[3].Value.ToString() != "" )
            {
                String Mov = dgvPivot.Rows[rowindex].Cells[3].Value.ToString().Substring(0,1);
                Partida = dgvPivot.Rows[rowindex].Cells[4].Value.ToString();
                columnName = dgvPivot.Columns[columnindex].Name;
                string mes = (columnName.Contains("ENE") ? "01" : (columnName.Contains("FEB") ? "02" : (columnName.Contains("MAR") ? "03" : (columnName.Contains("ABR") ? "04" : (columnName.Contains("MAY") ? "05" : (columnName.Contains("JUN") ? "06" : (columnName.Contains("JUL") ? "07" : (columnName.Contains("AGO") ? "08" : (columnName.Contains("SET") ? "09" : (columnName.Contains("OCT") ? "10" : (columnName.Contains("NOV") ? "11" : (columnName.Contains("DIC") ? "12" : "00"))))))))))));

                // =========================================================

                anio = dtpFechaInicio.Value.Year.ToString();
                List<FlujoDeCajaE> oListaDetalle;


                    oListaDetalle = AgenteContabilidad.Proxy.ReporteFlujoCajaDetalle(idEmpresa, idLocal, anio,  mes, Mov, Partida);


                if (oListaDetalle == null || oListaDetalle.Count == 0)
                {
                    Global.MensajeFault("No hay registros");
                    return;
                }

                // =========================================================

                CerrarFormulario("frmReporteFlujoDeCajaDetalle");

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteFlujoDeCajaDetalle);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmReporteFlujoDeCajaDetalle(oListaDetalle);
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
        }

        #endregion
    }
}
