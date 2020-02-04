using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmRegistroVentasReportes : FrmMantenimientoBase
    {

        public frmRegistroVentasReportes()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<RegistroVentasReporteE> oListaVentasRegistro = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string tipo = "buscar";
        String conFecha = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMonedas.DataSource = (from x in ListaMoneda
                                     where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                     orderby x.idMoneda
                                     select x).ToList();
            cboMonedas.ValueMember = "idMoneda";
            cboMonedas.DisplayMember = "desMoneda";
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = " Registro de Ventas";
            NombrePestaña = "Desde " + dtpInicio.Value.ToString("d") + " Hasta " + dtpFinal.Value.ToString("d"); ;

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 18;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "TD";
                    oHoja.Cells[InicioLinea, 2].Value = " SERIE";
                    oHoja.Cells[InicioLinea, 3].Value = " NUMERO";
                    oHoja.Cells[InicioLinea, 4].Value = " REFERENCIA";
                    oHoja.Cells[InicioLinea, 5].Value = " F.EMISION ";
                    oHoja.Cells[InicioLinea, 6].Value = " RUC ";
                    oHoja.Cells[InicioLinea, 7].Value = " CLIENTE ";
                    oHoja.Cells[InicioLinea, 8].Value = " MONEDA";
                    oHoja.Cells[InicioLinea, 9, InicioLinea, 13].Value = " BASE ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, InicioLinea, 13])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 14].Value = " I.S.C.";
                    oHoja.Cells[InicioLinea, 15].Value = " I.G.V.";
                    oHoja.Cells[InicioLinea, 16].Value = " TOTAL ";
                    oHoja.Cells[InicioLinea, 17].Value = " TIPO CAMBIO ";
                    oHoja.Cells[InicioLinea, 18].Value = " VALOR M.E. ";

                    for (int i = 1; i <= 18; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = " ";
                    oHoja.Cells[InicioLinea, 7].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = " ";
                    oHoja.Cells[InicioLinea, 9].Value = " AFECTO ";
                    oHoja.Cells[InicioLinea, 10].Value = " INAFECTO ";
                    oHoja.Cells[InicioLinea, 11].Value = " EXPORTACIÓN ";
                    oHoja.Cells[InicioLinea, 12].Value = " DESCUENTO ";
                    oHoja.Cells[InicioLinea, 13].Value = " VALOR VENTA";
                    oHoja.Cells[InicioLinea, 14].Value = " ";
                    oHoja.Cells[InicioLinea, 15].Value = " ";
                    oHoja.Cells[InicioLinea, 16].Value = " ";
                    oHoja.Cells[InicioLinea, 17].Value = " ";
                    oHoja.Cells[InicioLinea, 18].Value = " ";

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Detallado

                    int contador = 0;
                    string Doc = "";
                    Decimal TOTAL1 = 0;
                    Decimal TOTAL2 = 0;
                    Decimal TOTAL3 = 0;
                    Decimal TOTAL4 = 0;
                    Decimal TOTAL5 = 0;
                    Decimal TOTAL6 = 0;
                    Decimal TOTAL7 = 0;
                    Decimal TOTAL8 = 0;

                    Decimal SubTotalAfecto = 0;
                    Decimal SubTotalInafecto = 0;
                    Decimal SubTotalExportacion = 0;
                    Decimal SubTotalDescuento = 0;
                    Decimal SubTotalValorVenta = 0;
                    Decimal SubTotalISC = 0;
                    Decimal SubTotalIGV = 0;
                    Decimal SubTotalTotal = 0;

                    for (int i = 0; i < oListaVentasRegistro.Count; i++)
                    {
                        if (contador == 0)
                        {
                            Doc = oListaVentasRegistro[i].idDocumento;
                            oHoja.Cells[InicioLinea, 1].Value = Doc;
                            oHoja.Cells[InicioLinea, 2, InicioLinea, 18].Value = oListaVentasRegistro[i].DesDocumento;

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 18])
                            {
                                Rango.Merge = true;
                            }

                            InicioLinea++;
                        }

                        if (Doc != oListaVentasRegistro[i].idDocumento)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = " ";
                            oHoja.Cells[InicioLinea, 2].Value = " ";
                            oHoja.Cells[InicioLinea, 3].Value = " ";
                            oHoja.Cells[InicioLinea, 4].Value = " ";
                            oHoja.Cells[InicioLinea, 5].Value = " ";
                            oHoja.Cells[InicioLinea, 6].Value = " ";
                            oHoja.Cells[InicioLinea, 7].Value = "Totales Por Documento ====>";
                            oHoja.Cells[InicioLinea, 8].Value = " ";
                            oHoja.Cells[InicioLinea, 9].Value = SubTotalAfecto;
                            oHoja.Cells[InicioLinea, 10].Value = SubTotalInafecto;
                            oHoja.Cells[InicioLinea, 11].Value = SubTotalExportacion;
                            oHoja.Cells[InicioLinea, 12].Value = SubTotalDescuento;
                            SubTotalValorVenta = (SubTotalAfecto + SubTotalInafecto + SubTotalExportacion) - SubTotalDescuento;
                            oHoja.Cells[InicioLinea, 13].Value = SubTotalValorVenta;
                            oHoja.Cells[InicioLinea, 14].Value = SubTotalISC;
                            oHoja.Cells[InicioLinea, 15].Value = SubTotalIGV;
                            oHoja.Cells[InicioLinea, 16].Value = SubTotalTotal;
                            oHoja.Cells[InicioLinea, 17].Value = " ";
                            oHoja.Cells[InicioLinea, 18].Value = " ";
                            oHoja.Cells[InicioLinea, 9, InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                            InicioLinea++;

                            Doc = oListaVentasRegistro[i].idDocumento;
                            oHoja.Cells[InicioLinea, 1].Value = Doc;
                            oHoja.Cells[InicioLinea, 2, InicioLinea, 18].Value = oListaVentasRegistro[i].DesDocumento;

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 18])
                            {
                                Rango.Merge = true;
                            }

                            InicioLinea++;

                            SubTotalAfecto = 0;
                            SubTotalInafecto = 0;
                            SubTotalExportacion = 0;
                            SubTotalDescuento = 0;
                            SubTotalValorVenta = 0;
                            SubTotalISC = 0;
                            SubTotalIGV = 0;
                            SubTotalTotal = 0;
                        }

                        oHoja.Cells[InicioLinea, 1].Value = " ";
                        oHoja.Cells[InicioLinea, 2].Value = oListaVentasRegistro[i].numSerie;
                        oHoja.Cells[InicioLinea, 3].Value = oListaVentasRegistro[i].numDocumento;
                        oHoja.Cells[InicioLinea, 4].Value = " ";
                        oHoja.Cells[InicioLinea, 5].Value = oListaVentasRegistro[i].fecEmision.Value;
                        oHoja.Cells[InicioLinea, 6].Value = oListaVentasRegistro[i].Ruc;
                        oHoja.Cells[InicioLinea, 7].Value = oListaVentasRegistro[i].RazonSocial;
                        oHoja.Cells[InicioLinea, 8].Value = oListaVentasRegistro[i].desMoneda;
                        oHoja.Cells[InicioLinea, 9].Value = oListaVentasRegistro[i].BaseAfecta;
                        oHoja.Cells[InicioLinea, 10].Value = oListaVentasRegistro[i].BaseInafecta;
                        oHoja.Cells[InicioLinea, 11].Value = oListaVentasRegistro[i].BaseExportacion;
                        oHoja.Cells[InicioLinea, 12].Value = oListaVentasRegistro[i].dctoBaseImponible;

                        Decimal ValorVenta = (oListaVentasRegistro[i].BaseAfecta + oListaVentasRegistro[i].BaseInafecta + oListaVentasRegistro[i].BaseExportacion) - oListaVentasRegistro[i].dctoBaseImponible;

                        oHoja.Cells[InicioLinea, 13].Value = ValorVenta;
                        oHoja.Cells[InicioLinea, 14].Value = oListaVentasRegistro[i].Isc;
                        oHoja.Cells[InicioLinea, 15].Value = oListaVentasRegistro[i].Igv;
                        oHoja.Cells[InicioLinea, 16].Value = oListaVentasRegistro[i].Total;
                        oHoja.Cells[InicioLinea, 17].Value = oListaVentasRegistro[i].tipCambio;
                        oHoja.Cells[InicioLinea, 18].Value = oListaVentasRegistro[i].TotalME;
                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 9, InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.000";
                        InicioLinea++;

                        TOTAL1 += oListaVentasRegistro[i].BaseAfecta;
                        TOTAL2 += oListaVentasRegistro[i].BaseInafecta;
                        TOTAL3 += oListaVentasRegistro[i].BaseExportacion;
                        TOTAL4 += oListaVentasRegistro[i].dctoBaseImponible;
                        TOTAL5 += ValorVenta;
                        TOTAL6 += oListaVentasRegistro[i].Isc;
                        TOTAL7 += oListaVentasRegistro[i].Igv;
                        TOTAL8 += oListaVentasRegistro[i].Total;

                        SubTotalAfecto += oListaVentasRegistro[i].BaseAfecta;
                        SubTotalInafecto += oListaVentasRegistro[i].BaseInafecta;
                        SubTotalExportacion += oListaVentasRegistro[i].BaseExportacion;
                        SubTotalDescuento += oListaVentasRegistro[i].dctoBaseImponible;
                        SubTotalValorVenta += ValorVenta;
                        SubTotalISC += oListaVentasRegistro[i].Isc;
                        SubTotalIGV += oListaVentasRegistro[i].Igv;
                        SubTotalTotal += oListaVentasRegistro[i].Total;

                        contador++;
                    }

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = " ";
                    oHoja.Cells[InicioLinea, 7].Value = "Totales Por Documento ====>";
                    oHoja.Cells[InicioLinea, 8].Value = " ";
                    oHoja.Cells[InicioLinea, 9].Value = SubTotalAfecto;
                    oHoja.Cells[InicioLinea, 10].Value = SubTotalInafecto;
                    oHoja.Cells[InicioLinea, 11].Value = SubTotalExportacion;
                    oHoja.Cells[InicioLinea, 12].Value = SubTotalDescuento;
                    SubTotalValorVenta = (SubTotalAfecto + SubTotalInafecto + SubTotalExportacion) - SubTotalDescuento;
                    oHoja.Cells[InicioLinea, 13].Value = SubTotalValorVenta;
                    oHoja.Cells[InicioLinea, 14].Value = SubTotalISC;
                    oHoja.Cells[InicioLinea, 15].Value = SubTotalIGV;
                    oHoja.Cells[InicioLinea, 16].Value = SubTotalTotal;
                    oHoja.Cells[InicioLinea, 17].Value = " ";
                    oHoja.Cells[InicioLinea, 18].Value = " ";
                    oHoja.Cells[InicioLinea, 9, InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = " ";
                    oHoja.Cells[InicioLinea, 7].Value = "TOTALES =>";
                    oHoja.Cells[InicioLinea, 8].Value = " ";
                    oHoja.Cells[InicioLinea, 9].Value = TOTAL1;
                    oHoja.Cells[InicioLinea, 10].Value = TOTAL2;
                    oHoja.Cells[InicioLinea, 11].Value = TOTAL3;
                    oHoja.Cells[InicioLinea, 12].Value = TOTAL4;
                    TOTAL5 = (TOTAL1 + TOTAL2 + TOTAL3) - TOTAL4;
                    oHoja.Cells[InicioLinea, 13].Value = TOTAL5;
                    oHoja.Cells[InicioLinea, 14].Value = TOTAL6;
                    oHoja.Cells[InicioLinea, 15].Value = TOTAL7;
                    oHoja.Cells[InicioLinea, 16].Value = TOTAL8;
                    oHoja.Cells[InicioLinea, 17].Value = " ";
                    oHoja.Cells[InicioLinea, 18].Value = " ";
                    oHoja.Cells[InicioLinea, 9, InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;

                    #endregion

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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

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

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\OrdenTrabajo " + Aleatorio.ToString();
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
                String TituloGeneral = String.Empty;
                String SubTitulo = String.Empty;
                PdfPCell cell = null;

                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    conFecha = "S";
                    String Moneda_des = Convert.ToString(cboMonedas.SelectedValue);

                    if (Moneda_des == "01")
                    {
                        Moneda_des = "SOLES";
                    }
                    else
                    {
                        Moneda_des = "DOLARES";
                    }

                    PaginaInicioVentasReportes ev = new PaginaInicioVentasReportes()
                    {
                        FechaInicio = dtpInicio.Value,
                        FechaFin = dtpFinal.Value,
                        conFecha = conFecha,
                        MonedaDes = Moneda_des
                    };

                    oPdfw.PageEvent = ev;
                    docPdf.Open();

                    #region Detalle

                    int Columnas = 18;
                    PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
                    {
                        WidthPercentage = 100
                    };

                    TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.15f, 0.15f, 0.15f, 0.2f, 0.6f, 0.1f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f });
                    int contador = 0;
                    string Doc = "";
                    Decimal TOTAL1 = 0;
                    Decimal TOTAL2 = 0;
                    Decimal TOTAL3 = 0;
                    Decimal TOTAL4 = 0;
                    Decimal TOTAL5 = 0;
                    Decimal TOTAL6 = 0;
                    Decimal TOTAL7 = 0;
                    Decimal TOTAL8 = 0;

                    Decimal SubTotalAfecto = 0;
                    Decimal SubTotalInafecto = 0;
                    Decimal SubTotalExportacion = 0;
                    Decimal SubTotalDescuento = 0;
                    Decimal SubTotalValorVenta = 0;
                    Decimal SubTotalISC = 0;
                    Decimal SubTotalIGV = 0;
                    Decimal SubTotalTotal = 0;

                    for (int i = 0; i < oListaVentasRegistro.Count; i++)
                    {
                        if (contador == 0)
                        {
                            Doc = oListaVentasRegistro[i].idDocumento;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Doc, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].DesDocumento, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1, "S17"));
                            TablaCabDetalle.CompleteRow();
                        }

                        if (Doc != oListaVentasRegistro[i].idDocumento)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Totales Por Documento ====>", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalAfecto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalInafecto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalExportacion.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalDescuento.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                            SubTotalValorVenta = (SubTotalAfecto + SubTotalInafecto + SubTotalExportacion) - SubTotalDescuento;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalValorVenta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalISC.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalIGV.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalTotal.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                            TablaCabDetalle.CompleteRow();

                            Doc = oListaVentasRegistro[i].idDocumento;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Doc, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].DesDocumento, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1, "S17"));
                            TablaCabDetalle.CompleteRow();

                            SubTotalAfecto = 0;
                            SubTotalInafecto = 0;
                            SubTotalExportacion = 0;
                            SubTotalDescuento = 0;
                            SubTotalValorVenta = 0;
                            SubTotalISC = 0;
                            SubTotalIGV = 0;
                            SubTotalTotal = 0;
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].numSerie, null, "N", null, FontFactory.GetFont("Arial", 6f), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].numDocumento, null, "N", null, FontFactory.GetFont("Arial", 6f), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].fecEmision.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].Ruc, null, "N", null, FontFactory.GetFont("Arial", 6f), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6f), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].BaseAfecta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].BaseInafecta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].BaseExportacion.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].dctoBaseImponible.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));

                        Decimal ValorVenta = (oListaVentasRegistro[i].BaseAfecta + oListaVentasRegistro[i].BaseInafecta + oListaVentasRegistro[i].BaseExportacion) - oListaVentasRegistro[i].dctoBaseImponible;

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ValorVenta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].Isc.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].Igv.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].Total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVentasRegistro[i].TotalME.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                        TablaCabDetalle.CompleteRow();

                        TOTAL1 += oListaVentasRegistro[i].BaseAfecta;
                        TOTAL2 += oListaVentasRegistro[i].BaseInafecta;
                        TOTAL3 += oListaVentasRegistro[i].BaseExportacion;
                        TOTAL4 += oListaVentasRegistro[i].dctoBaseImponible;
                        TOTAL5 += ValorVenta;
                        TOTAL6 += oListaVentasRegistro[i].Isc;
                        TOTAL7 += oListaVentasRegistro[i].Igv;
                        TOTAL8 += oListaVentasRegistro[i].Total;

                        SubTotalAfecto += oListaVentasRegistro[i].BaseAfecta;
                        SubTotalInafecto += oListaVentasRegistro[i].BaseInafecta;
                        SubTotalExportacion += oListaVentasRegistro[i].BaseExportacion;
                        SubTotalDescuento += oListaVentasRegistro[i].dctoBaseImponible;
                        SubTotalValorVenta += ValorVenta;
                        SubTotalISC += oListaVentasRegistro[i].Isc;
                        SubTotalIGV += oListaVentasRegistro[i].Igv;
                        SubTotalTotal += oListaVentasRegistro[i].Total;

                        contador++;
                    }

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Totales Por Documento ====>", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2, "S7"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalAfecto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalInafecto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalExportacion.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalDescuento.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    SubTotalValorVenta = (SubTotalAfecto + SubTotalInafecto + SubTotalExportacion) - SubTotalDescuento;
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalValorVenta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalISC.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalIGV.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalTotal.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    TablaCabDetalle.CompleteRow();

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    cell.Colspan = 18;
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

                    cell = new PdfPCell(new Paragraph("TOTALES =>", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = 7;
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(TOTAL1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(TOTAL2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(TOTAL3.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(TOTAL4.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    TOTAL5 = (TOTAL1 + TOTAL2 + TOTAL3) - TOTAL4;
                    cell = new PdfPCell(new Paragraph(TOTAL5.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(TOTAL6.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(TOTAL7.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(TOTAL8.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion

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

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaVentasRegistro == null || oListaVentasRegistro.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Ventas", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    lblProcesando.Visible = true;
                    btBuscar.Enabled = true;
                    pbProgress.Visible = true;
                    Cursor = Cursors.WaitCursor;

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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (tipo == "buscar")
                {
                    DateTime fecIni;
                    DateTime fecFin;
                    Int32 idCliente;
                    Int32 idvendedor;

                    if (rbTodosCLientes.Checked)
                    {
                        idCliente = Variables.Cero;
                    }
                    else
                    {
                        idCliente = Convert.ToInt32(txtRuc.Tag);
                    }

                    if (tbtodosv.Checked)
                    {
                        idvendedor = Variables.Cero;
                    }
                    else
                    {
                        idvendedor = Convert.ToInt32(txtrucv.Tag);
                    }

                    fecIni = dtpInicio.Value.Date;
                    fecFin = dtpFinal.Value.Date;

                    lblProcesando.Text = "Obteniendo los Registros de Ventas...";
                    oListaVentasRegistro = AgenteVentas.Proxy.ReporteRegistroVentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, fecIni, fecFin, idvendedor, idCliente, cboMonedas.SelectedValue.ToString());
                    lblProcesando.Text = "Armando Las Ventas...";
                    ConvertirApdf();
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
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;
            pnlContenedor.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (tipo == "buscar")
            {
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }
            else
            {
                Global.MensajeComunicacion("Orden de Trabajo Exportado...");
            }
        }

        #endregion

        #region Eventos

        private void frmRegistroVentasReportes_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            pbProgress.Left = (pnlContenedor.Width - pbProgress.Width) / 2;
            pbProgress.Top = (pnlContenedor.Height - pbProgress.Height) / 2;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "buscar";
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                pnlContenedor.Cursor = Cursors.WaitCursor;
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

        private void rbTodosCLientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosCLientes.Checked)
            {
                txtRuc.Tag = 0;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
            }
            else
            {
                txtRuc.Tag = 0;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtRuc.Focus();
            }
        }

        private void tbtodosv_CheckedChanged(object sender, EventArgs e)
        {
            if (tbtodosv.Checked)
            {
                txtrucv.Tag = 0;
                txtrucv.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonsocialv.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
            }
            else
            {
                txtrucv.Tag = 0;
                txtrucv.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonsocialv.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtrucv.Focus();
            }
        }

        private void txtRuc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtrucv_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtrucv.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtrucv.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtrucv.Tag = oFrm.oPersona.IdPersona;
                            txtrucv.Text = oFrm.oPersona.RUC;
                            txtRazonsocialv.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonsocialv.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtrucv.Tag = oListaPersonas[0].IdPersona;
                        txtrucv.Text = oListaPersonas[0].RUC;
                        txtRazonsocialv.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtrucv.Tag = 0;
                        txtrucv.Text = String.Empty;
                        txtRazonsocialv.Text = String.Empty;
                        txtrucv.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (pnlContenedor.Width - lblProcesando.Width) / 2;
            lblProcesando.Top = ((pnlContenedor.Height - pbProgress.Height) + (pbProgress.Height + 150)) / 2;
        } 

        #endregion

    }

    #region Inicio Pdf

    class PaginaInicioVentasReportes : PdfPageEventHelper
    {

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String conFecha { get; set; }
        public String MonedaDes { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;
            String SubTitulo2 = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            BaseColor ColorCab = BaseColor.LIGHT_GRAY;

            TituloGeneral = "Registro de Ventas";

            if (conFecha == "S")
            {
                SubTitulo = "Desde " + FechaInicio.ToString("d") + " Hasta " + FechaFin.ToString("d");
            }
            else
            {
                SubTitulo = " ";
            }

            if (conFecha == "S")
            {
                SubTitulo2 = "Moneda Expresada en " + MonedaDes;
            }
            else
            {
                SubTitulo2 = " ";
            }

            #region Titulos Generales

            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

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

            table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f, "S2"));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda(SubTitulo2, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f, "S2"));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), -1, -1, "S2", "N"));
            table.CompleteRow();

            document.Add(table); //Añadiendo la tabla al documento PDF

            #endregion

            #region Cabecera del Detalle

            table = new PdfPTable(18)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.1f, 0.1f, 0.15f, 0.15f, 0.15f, 0.2f, 0.6f, 0.1f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f });

            #region Primera Linea

            table.AddCell(ReaderHelper.NuevaCelda("T.D.", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("SERIE", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("NUMERO", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("REFER.", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("F.EMISIÓN", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("RUC", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("CLIENTE", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("MON.", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("BASE", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S5"));
            table.AddCell(ReaderHelper.NuevaCelda("ISC", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("IGV", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("TOTAL", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("TIPO CAMBIO", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            table.AddCell(ReaderHelper.NuevaCelda("VALOR (M.E.)", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));

            table.CompleteRow();

            #endregion

            #region Segunda Linea

            table.AddCell(ReaderHelper.NuevaCelda("AFECTO", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
            table.AddCell(ReaderHelper.NuevaCelda("INAFECTO", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
            table.AddCell(ReaderHelper.NuevaCelda("EXPORT.", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
            table.AddCell(ReaderHelper.NuevaCelda("DSCTO", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
            table.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));

            table.CompleteRow();

            #endregion

            #endregion

            document.Add(table); //Añadiendo la tabla al documento PDF
        }
    }

    #endregion

}

