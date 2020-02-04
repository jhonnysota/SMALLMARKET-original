using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteContaVsAlmacenes : FrmMantenimientoBase
    {

        public frmReporteContaVsAlmacenes()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        readonly BackgroundWorker _bw = new BackgroundWorker();
        List<Con_SaldosE> ListaSaldos = null;
        List<kardexE> ListaKardex = null;
        List<AlmacenArticuloLoteE> ListaArticulos = null;
        List<ItemsSaldo> ReporteFinal = null;
        String RutaGeneral = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////Mes Inicio////
            cboInicioMes.DataSource = FechasHelper.CargarMesesContable("MA");
            cboInicioMes.ValueMember = "MesId";
            cboInicioMes.DisplayMember = "MesDes";

            /////Mes Final////
            //cboFinMes.DataSource = FechasHelper.CargarMesesContable("MA");
            //cboFinMes.ValueMember = "MesId";
            //cboFinMes.DisplayMember = "MesDes";

            /////Años/////
            Int32 anioFin = Convert.ToInt32(VariablesLocales.FechaHoy.ToString("yyyy"));
            Int32 anioInicio = anioFin - 10;

            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";

            cboAnio.SelectedValue = Convert.ToInt32(anioFin);
            cboInicioMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;
            //cboFinMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;
        }

        void ConvertirApdf(List<ItemsSaldo> Reporte)
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Comparativo " + Aleatorio.ToString();
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio si existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            docPdf.AddCreationDate();
            docPdf.AddAuthor("AMAZONTIC SAC");
            docPdf.AddCreator("AMAZONTIC SAC");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                // Para la creación del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    #region Variables

                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);
                    BaseColor col1 = new BaseColor(Color.FromArgb(191, 191, 191));
                    BaseColor col2 = new BaseColor(Color.FromArgb(132, 151, 176));
                    PdfPTable TablaCabDetalle = null;
                    float[] AnchoColumnas = null;
                    Int32 Cols = 0;
                    Decimal SaldoS = 0;
                    Decimal SaldoD = 0;
                    Decimal TotalS = 0;
                    Decimal TotalD = 0;

                    #endregion

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    Cols = 10;

                    TablaCabDetalle = new PdfPTable(Cols)
                    {
                        WidthPercentage = 100
                    };

                    AnchoColumnas = new float[] { 0.07f, 0.35f, 0.1f, 0.1f, 0.08f, 0.22f, 0.07f, 0.35f, 0.1f, 0.1f };

                    TablaCabDetalle.SetWidths(AnchoColumnas);

                    //Parámetros que pasará al inicio del PDF
                    oPdfw.PageEvent = new PagRegInicioContaAlmacen
                    {
                        Periodo = cboInicioMes.Text.ToString().ToUpper(),
                        AnchoCols = AnchoColumnas,
                        Columnas = Cols,
                        colCabDetalle1 = col1,
                        colCabDetalle2 = col2
                    };

                    docPdf.Open();

                    //Recorriendo los items
                    foreach (ItemsSaldo item in Reporte)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CtaDestino, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCtaDestino, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.SaldoS, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.SaldoD, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));

                        if (item.codAlmacen != "1000")
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codAlmacen, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desAlmacen, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CtaDestino2, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCtaDestino2, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalS, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalD, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 2f, "S", "S", "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0, "N", "N", 4f, 2f, "S", "S", "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 2f, "S", "S", "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCtaDestino2, null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0, "N", "N", 4f, 2f, "S", "S", "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalS, null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 2f, "S", "S", "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalD, null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 2f, "S", "S", "N", "N"));
                        }

                        TablaCabDetalle.CompleteRow();

                        if (!String.IsNullOrWhiteSpace(item.SaldoS) && item.codAlmacen != "1000")
                        {
                            SaldoS += Decimal.Round(Convert.ToDecimal(item.SaldoS), 2, MidpointRounding.AwayFromZero);
                        }

                        if (!String.IsNullOrWhiteSpace(item.SaldoD) && item.codAlmacen != "1000")
                        {
                            SaldoD += Decimal.Round(Convert.ToDecimal(item.SaldoD), 2, MidpointRounding.AwayFromZero);
                        }

                        if (!String.IsNullOrWhiteSpace(item.TotalS) && item.codAlmacen != "1000")
                        {
                            TotalS += Decimal.Round(Convert.ToDecimal(item.TotalS), 2, MidpointRounding.AwayFromZero);
                        }

                        if (!String.IsNullOrWhiteSpace(item.TotalD) && item.codAlmacen != "1000")
                        {
                            TotalD += Decimal.Round(Convert.ToDecimal(item.TotalD), 2, MidpointRounding.AwayFromZero);
                        }
                    }

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 5, 5, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Total => ", col1, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 5, 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SaldoS.ToString("N2"), col1, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2, "N", "N", 5, 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SaldoD.ToString("N2"), col1, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2, "N", "N", 5, 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 5, 5, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 5, 5, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 5, 5, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Total => ", col2, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 5, 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalS.ToString("N2"), col2, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2, "N", "N", 5, 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalD.ToString("N2"), col2, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2, "N", "N", 5, 5));

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                }
            }
        }

        void ExportarExcel(List<ItemsSaldo> Reporte, String Ruta)
        {
            #region Variables

            String TituloGeneral = "COMPARACION DE CONTABILIDAD VS ALMACENES";
            String SubTitulos = "(" + cboInicioMes.Text.ToString().ToUpper() + ")";
            String NombrePestaña = "Comparativo";
            Int32 totColumnas = 10;
            Int32 FilaIni = 4;
            Color col1 = Color.FromArgb(191, 191, 191);
            Color col2 = Color.FromArgb(132, 151, 176);

            #endregion

            //Creando el directorio si existe...
            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo NuevoArchivo = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(NuevoArchivo))
            {
                using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña))
                {
                    #region Variables

                    Decimal SaldoS = 0;
                    Decimal SaldoD = 0;
                    Decimal TotalS = 0;
                    Decimal TotalD = 0;

                    #endregion

                    #region Titulos

                    oHoja.Cells["A1"].Value = TituloGeneral;
                    oHoja.Row(1).Height = 30;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 15, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    }

                    oHoja.Cells["A2"].Value = SubTitulos;
                    oHoja.Row(2).Height = 16;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, totColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 11, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    }

                    #endregion

                    #region Cabecera del Detalle

                    oHoja.Row(FilaIni).Height = 20;

                    oHoja.Cells[FilaIni, 1].Value = "Cuenta";
                    oHoja.Cells[FilaIni, 2].Value = "Des. Cuenta";
                    oHoja.Cells[FilaIni, 3].Value = "Saldo S/";
                    oHoja.Cells[FilaIni, 4].Value = "Saldo US$";
                    oHoja.Cells[FilaIni, 5].Value = "Cód.Alm.";
                    oHoja.Cells[FilaIni, 6].Value = "Almacén";
                    oHoja.Cells[FilaIni, 7].Value = "Cuenta";
                    oHoja.Cells[FilaIni, 8].Value = "Des. Cuenta";
                    oHoja.Cells[FilaIni, 9].Value = "Total S/";
                    oHoja.Cells[FilaIni, 10].Value = "Total US$";

                    for (int i = 1; i <= totColumnas; i++)
                    {
                        oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        oHoja.Cells[FilaIni, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[FilaIni, i].Style.Fill.PatternType = ExcelFillStyle.Solid;

                        if (i <= 4)
                        {
                            oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(col1);
                        }
                        else
                        {
                            oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(col2);
                        }
                    }

                    #region Ancho de Columnas

                    oHoja.Column(1).Width = 8;
                    oHoja.Column(2).Width = 43;
                    oHoja.Column(3).Width = 12;
                    oHoja.Column(4).Width = 12;
                    oHoja.Column(5).Width = 8;
                    oHoja.Column(6).Width = 30;
                    oHoja.Column(7).Width = 8;
                    oHoja.Column(8).Width = 43;
                    oHoja.Column(9).Width = 12;
                    oHoja.Column(10).Width = 12;

                    #endregion

                    #endregion

                    FilaIni++;

                    foreach (ItemsSaldo item in Reporte)
                    {
                        oHoja.Cells[FilaIni, 1].Value = item.CtaDestino;
                        oHoja.Cells[FilaIni, 2].Value = item.desCtaDestino;

                        if (!String.IsNullOrWhiteSpace(item.SaldoS))
                        {
                            oHoja.Cells[FilaIni, 3].Value = Convert.ToDecimal(item.SaldoS);
                            SaldoS += Convert.ToDecimal(item.SaldoS);
                        }

                        if (!String.IsNullOrWhiteSpace(item.SaldoD))
                        {
                            oHoja.Cells[FilaIni, 4].Value = Convert.ToDecimal(item.SaldoD);
                            SaldoD += Convert.ToDecimal(item.SaldoD);
                        }

                        if (item.codAlmacen != "1000")
                        {
                            oHoja.Cells[FilaIni, 5].Value = item.codAlmacen;
                            oHoja.Cells[FilaIni, 6].Value = item.desAlmacen;
                            oHoja.Cells[FilaIni, 7].Value = item.CtaDestino2;
                            oHoja.Cells[FilaIni, 8].Value = item.desCtaDestino2;

                            if (!String.IsNullOrWhiteSpace(item.TotalS))
                            {
                                oHoja.Cells[FilaIni, 9].Value = Convert.ToDecimal(item.TotalS);
                                TotalS += Convert.ToDecimal(item.TotalS);
                            }

                            if (!String.IsNullOrWhiteSpace(item.TotalD))
                            {
                                oHoja.Cells[FilaIni, 10].Value = Convert.ToDecimal(item.TotalD);
                                TotalD += Convert.ToDecimal(item.TotalD);
                            }
                        }
                        else
                        {
                            oHoja.Cells[FilaIni, 5].Value = "";
                            oHoja.Cells[FilaIni, 6].Value = "";
                            oHoja.Cells[FilaIni, 7].Value = "";
                            oHoja.Cells[FilaIni, 8].Value = item.desCtaDestino2;

                            if (!String.IsNullOrWhiteSpace(item.TotalS))
                            {
                                oHoja.Cells[FilaIni, 9].Value = Convert.ToDecimal(item.TotalS);
                            }

                            if (!String.IsNullOrWhiteSpace(item.TotalD))
                            {
                                oHoja.Cells[FilaIni, 10].Value = Convert.ToDecimal(item.TotalD);
                            }
                        }

                        #region Formateo

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                            if (i == 3 || i == 4 || i == 9 || i == 10)
                            {
                                oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                            }

                            if (i == 1 || i == 7)
                            {
                                oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            if (item.codAlmacen == "1000" && i > 4)
                            {
                                oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                oHoja.Cells[FilaIni, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                oHoja.Cells[FilaIni, i].Style.Font.Bold = true;
                            }
                        }

                        #endregion

                        FilaIni++;
                    }

                    #region Totales

                    oHoja.Cells[FilaIni, 1].Value = " ";
                    oHoja.Cells[FilaIni, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    oHoja.Cells[FilaIni, 2].Value = "Total => ";
                    oHoja.Cells[FilaIni, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    oHoja.Cells[FilaIni, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[FilaIni, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[FilaIni, 2].Style.Fill.BackgroundColor.SetColor(col1);
                    oHoja.Cells[FilaIni, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));

                    oHoja.Cells[FilaIni, 3].Value = SaldoS;
                    oHoja.Cells[FilaIni, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[FilaIni, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[FilaIni, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[FilaIni, 3].Style.Fill.BackgroundColor.SetColor(col1);
                    oHoja.Cells[FilaIni, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));

                    oHoja.Cells[FilaIni, 4].Value = SaldoD;
                    oHoja.Cells[FilaIni, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[FilaIni, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[FilaIni, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[FilaIni, 4].Style.Fill.BackgroundColor.SetColor(col1);
                    oHoja.Cells[FilaIni, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));

                    oHoja.Cells[FilaIni, 5].Value = " ";
                    oHoja.Cells[FilaIni, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oHoja.Cells[FilaIni, 6].Value = " ";
                    oHoja.Cells[FilaIni, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oHoja.Cells[FilaIni, 7].Value = " ";
                    oHoja.Cells[FilaIni, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    oHoja.Cells[FilaIni, 8].Value = "Total => ";
                    oHoja.Cells[FilaIni, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    oHoja.Cells[FilaIni, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[FilaIni, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[FilaIni, 8].Style.Fill.BackgroundColor.SetColor(col2);
                    oHoja.Cells[FilaIni, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));

                    oHoja.Cells[FilaIni, 9].Value = TotalS;
                    oHoja.Cells[FilaIni, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[FilaIni, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[FilaIni, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[FilaIni, 9].Style.Fill.BackgroundColor.SetColor(col2);
                    oHoja.Cells[FilaIni, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));

                    oHoja.Cells[FilaIni, 10].Value = TotalD;
                    oHoja.Cells[FilaIni, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[FilaIni, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[FilaIni, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[FilaIni, 10].Style.Fill.BackgroundColor.SetColor(col2);
                    oHoja.Cells[FilaIni, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold)); 

                    #endregion

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Módulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                    //Guardando el excel
                    oExcel.Save();
                } 
            }
        }

        #endregion

        #region Eventos Heredados

        public override void Buscar()
        {
            Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            Int32 Corre = 0;
            ReporteFinal = new List<ItemsSaldo>();
            lblProcesando.Text = "Obteniendo los Movimientos...";
            ListaSaldos = AgenteContabilidad.Proxy.SaldoContableApertura(idEmpresa, cboAnio.SelectedValue.ToString(), cboInicioMes.SelectedValue.ToString());

            if (Convert.ToString(cboInicioMes.SelectedValue) == "00")
            {
                ListaKardex = AgenteAlmacen.Proxy.KardexVsSaldo(idEmpresa, cboAnio.SelectedValue.ToString(), "01");
            }
            else
            {
                ListaArticulos = AgenteAlmacen.Proxy.AlmacenArticuloVsSaldos(idEmpresa, cboAnio.SelectedValue.ToString(), cboInicioMes.SelectedValue.ToString());
            }

            lblProcesando.Text = "Armando el Reporte...";

            //Llenando la lista
            if (ListaSaldos != null && ListaSaldos.Count > 0)
            {
                if (Convert.ToString(cboInicioMes.SelectedValue) == "00")
                {
                    if (ListaSaldos.Count > ListaKardex.Count)
                    {
                        foreach (Con_SaldosE item in ListaSaldos)
                        {
                            ItemsSaldo items = new ItemsSaldo()
                            {
                                CtaDestino = item.codCuenta,
                                desCtaDestino = item.desCuenta,
                                SaldoS = item.SAL_ACTUAL_SOLES.ToString("N2"),
                                SaldoD = item.SAL_ACTUAL_DOLARES.ToString("N2"),
                                codAlmacen = String.Empty,
                                desAlmacen = String.Empty,
                                CtaDestino2 = String.Empty,
                                desCtaDestino2 = String.Empty,
                                TotalS =  String.Empty,
                                TotalD = String.Empty
                            };

                            ReporteFinal.Add(items);
                        }

                        if (ReporteFinal.Count > 0)
                        {
                            foreach (kardexE item in ListaKardex)
                            {
                                ReporteFinal[Corre].codAlmacen = item.idAlmacen.ToString();
                                ReporteFinal[Corre].desAlmacen = item.desAlmacen;
                                ReporteFinal[Corre].CtaDestino2 = item.codCuentaDestino;
                                ReporteFinal[Corre].desCtaDestino2 = item.desCtaDestino;
                                ReporteFinal[Corre].TotalS = item.TotalSoles.ToString("N2");
                                ReporteFinal[Corre].TotalD = item.TotalDolar.ToString("N2");

                                Corre++;
                            }
                        }
                    }
                    else
                    {
                        foreach (kardexE item in ListaKardex)
                        {
                            ItemsSaldo items = new ItemsSaldo()
                            {
                                CtaDestino = String.Empty,
                                desCtaDestino = String.Empty,
                                SaldoS = String.Empty,
                                SaldoD = String.Empty,
                                codAlmacen = item.idAlmacen.ToString(),
                                desAlmacen = item.desAlmacen,
                                CtaDestino2 = item.codCuentaDestino,
                                desCtaDestino2 = item.desCtaDestino,
                                TotalS = item.TotalSoles.ToString("N2"),
                                TotalD = item.TotalDolar.ToString("N2")
                            };

                            ReporteFinal.Add(items);
                        }

                        if (ReporteFinal.Count > 0)
                        {
                            foreach (Con_SaldosE item in ListaSaldos)
                            {
                                ReporteFinal[Corre].CtaDestino = item.codCuenta;
                                ReporteFinal[Corre].desCtaDestino = item.desCuenta;
                                ReporteFinal[Corre].SaldoS = item.SAL_ACTUAL_SOLES.ToString("N2");
                                ReporteFinal[Corre].SaldoD = item.SAL_ACTUAL_DOLARES.ToString("N2");

                                Corre++;
                            }
                        }
                    }
                }
                else
                {
                    if (ListaSaldos.Count > ListaArticulos.Count)
                    {
                        foreach (Con_SaldosE item in ListaSaldos)
                        {
                            ItemsSaldo itemSaldo = new ItemsSaldo()
                            {
                                CtaDestino = item.codCuenta,
                                desCtaDestino = item.desCuenta,
                                SaldoS = item.SAL_ACTUAL_SOLES.ToString("N2"),
                                SaldoD = item.SAL_ACTUAL_DOLARES.ToString("N2"),
                                codAlmacen = String.Empty,
                                desAlmacen = String.Empty,
                                CtaDestino2 = String.Empty,
                                desCtaDestino2 = String.Empty,
                                TotalS = String.Empty,
                                TotalD = String.Empty
                            };

                            ReporteFinal.Add(itemSaldo);
                        }

                        if (ReporteFinal.Count > 0)
                        {
                            foreach (AlmacenArticuloLoteE item in ListaArticulos)
                            {
                                ReporteFinal[Corre].codAlmacen = item.idAlmacen.ToString();
                                ReporteFinal[Corre].desAlmacen = item.desAlmacen;
                                ReporteFinal[Corre].CtaDestino2 = item.codCuentaDestino;
                                ReporteFinal[Corre].desCtaDestino2 = item.desCtaDestino;
                                ReporteFinal[Corre].TotalS = item.TotalSoles.ToString("N2");
                                ReporteFinal[Corre].TotalD = item.TotalDolar.ToString("N2");

                                Corre++;
                            }
                        }
                    }
                    else
                    {
                        foreach (AlmacenArticuloLoteE item in ListaArticulos)
                        {
                            ItemsSaldo items = new ItemsSaldo()
                            {
                                CtaDestino = String.Empty,
                                desCtaDestino = String.Empty,
                                SaldoS = String.Empty,
                                SaldoD = String.Empty,
                                codAlmacen = item.idAlmacen.ToString(),
                                desAlmacen = item.desAlmacen,
                                CtaDestino2 = item.codCuentaDestino,
                                desCtaDestino2 = item.desCtaDestino,
                                TotalS = item.TotalSoles.ToString("N2"),
                                TotalD = item.TotalDolar.ToString("N2")
                            };

                            ReporteFinal.Add(items);
                        }

                        if (ReporteFinal.Count > 0)
                        {
                            foreach (Con_SaldosE item in ListaSaldos)
                            {
                                ReporteFinal[Corre].CtaDestino = item.codCuenta;
                                ReporteFinal[Corre].desCtaDestino = item.desCuenta;
                                ReporteFinal[Corre].SaldoS = item.SAL_ACTUAL_SOLES.ToString("N2");
                                ReporteFinal[Corre].SaldoD = item.SAL_ACTUAL_DOLARES.ToString("N2");

                                Corre++;
                            }
                        }
                    }
                }

                if (ReporteFinal.Count > 0)
                {
                    ConvertirApdf(ReporteFinal);
                }
            }
        }

        public override void Exportar()
        {
            try
            {
                if (ReporteFinal == null || ReporteFinal.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreArchivo = "Comparativo " + cboInicioMes.Text.ToString().ToUpper() + "-" + cboAnio.SelectedValue.ToString();
                String RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrWhiteSpace(RutaExcel))
                {
                    ExportarExcel(ReporteFinal, RutaExcel);
                    Global.MensajeComunicacion("Información exportada");
                }
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
                Buscar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                ////Mostrando el reporte en un web browser
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteContaVsAlmacenes_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void frmReporteContaVsAlmacenes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void cboInicioMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (Convert.ToString(cboInicioMes.SelectedValue) == "00")
            //{
            //    cboFinMes.Enabled = false;
            //    cboFinMes.SelectedValue = "01";
            //}
            //else
            //{
            //    cboFinMes.Enabled = true;
            //}
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

    }

    class ItemsSaldo
    {
        public String CtaDestino { get; set; }
        public String desCtaDestino { get; set; }
        public String SaldoS { get; set; }
        public String SaldoD { get; set; }
        public String codAlmacen { get; set; }
        public String desAlmacen { get; set; }
        public String CtaDestino2 { get; set; }
        public String desCtaDestino2 { get; set; }
        public String TotalS { get; set; }
        public String TotalD { get; set; }
    }

    class PagRegInicioContaAlmacen : PdfPageEventHelper
    {
        public String Periodo { get; set; }
        public Int32 Columnas { get; set; }
        public float[] AnchoCols { get; set; }
        public BaseColor colCabDetalle1 { get; set; }
        public BaseColor colCabDetalle2 { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            PdfPTable table = null;

            #endregion Variables

            //Para el encabezado
            table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            if (writer.PageNumber == 1)
            {
                #region Encabezado de página

                table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                #endregion

                #region Titulo Principal

                table.AddCell(ReaderHelper.NuevaCelda("COMPARACION DE CONTABILIDAD VS ALMACENES", null, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                table.AddCell(ReaderHelper.NuevaCelda("(" + Periodo + ")", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                //Fila en blanco
                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N"));

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF

                #region Cabecera del Detalle

                table = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };

                table.SetWidths(AnchoCols);

                table.AddCell(ReaderHelper.NuevaCelda("Cuenta", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Des. Cuenta", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Saldo S/", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Saldo US$", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Cód.Alm.", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Almacén", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Cuenta", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Des. Cuenta", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Total S/", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("Total US$", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));

                table.CompleteRow();

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF
            }
            else
            {
                #region Encabezado de Página

                table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow(); 

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF

                #region Cabecera del Detalle

                table = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };

                table.SetWidths(AnchoCols);

                table.AddCell(ReaderHelper.NuevaCelda("Cuenta", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Des. Cuenta", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Saldo S/", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Saldo US$", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Cód.Alm.", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Almacén", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Cuenta", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Des. Cuenta", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total S/", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total US$", colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));

                table.CompleteRow();

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF
            }
        }
    }

}
