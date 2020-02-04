using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteOcPorNotaIngreso : FrmMantenimientoBase
    {

        public frmReporteOcPorNotaIngreso()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<OrdenCompraE> oListaOC = null;
        String RutaGeneral = String.Empty;
        Int32 tipoProceso = 0;
        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        #region Procedimientos de Usuario

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String Subtitulo = String.Empty;

            TituloGeneral = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
            Subtitulo = "NOTAS DE INGRESO DEL " + dtpInicio.Value.ToString("dd/MM/yyyy") + " AL " + dtpFinal.Value.ToString("dd/MM/yyyy");

            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("O.C. x N.I.");

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 21;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = TituloGeneral;
                    oHoja.Row(1).Height = 31.50;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 20, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(64, 64, 64));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    oHoja.Cells["A2"].Value = Subtitulo;
                    oHoja.Row(2).Height = 20.25;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 11, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    //PRIMERA
                    oHoja.Row(4).Height = 24;
                    oHoja.Cells["A4"].Value = "ORDEN DE COMPRA";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(174, 170, 170));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    oHoja.Cells["F4"].Value = "INGRESOS AL ALMACEN";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, InicioLinea, 15])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(174, 170, 170));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    oHoja.Cells["P4"].Value = "PROVISION";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 16, InicioLinea, 21])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(174, 170, 170));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    InicioLinea++;

                    //SEGUNDA
                    oHoja.Row(5).Height = 23.25;

                    oHoja.Cells[InicioLinea, 1].Value = "Fec.O.C.";
                    oHoja.Cells[InicioLinea, 2].Value = "N° Compra";
                    oHoja.Cells[InicioLinea, 3].Value = "Razón Social";
                    oHoja.Cells[InicioLinea, 4].Value = "N.I.";
                    oHoja.Cells[InicioLinea, 5].Value = "Imp.OC.";
                    oHoja.Cells[InicioLinea, 6].Value = "Doc.Alm.";
                    oHoja.Cells[InicioLinea, 7].Value = "Item";
                    oHoja.Cells[InicioLinea, 8].Value = "Cód.Articulo";
                    oHoja.Cells[InicioLinea, 9].Value = "Descripción";
                    oHoja.Cells[InicioLinea, 10].Value = "Fec.Alm.";
                    oHoja.Cells[InicioLinea, 11].Value = "Cant.";
                    oHoja.Cells[InicioLinea, 12].Value = "Costo Unit. S/.";
                    oHoja.Cells[InicioLinea, 13].Value = "Costo Unit. US$";
                    oHoja.Cells[InicioLinea, 14].Value = "Total S/.";
                    oHoja.Cells[InicioLinea, 15].Value = "Total US$";
                    oHoja.Cells[InicioLinea, 16].Value = "Documento";
                    oHoja.Cells[InicioLinea, 17].Value = "Imp.Doc. S/.";
                    oHoja.Cells[InicioLinea, 18].Value = "Imp.Doc. US$";
                    oHoja.Cells[InicioLinea, 19].Value = "Voucher";
                    oHoja.Cells[InicioLinea, 20].Value = "Cuenta";
                    oHoja.Cells[InicioLinea, 21].Value = "Cta.Dest.";

                    for (int i = 1; i <= 21; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(208, 206, 206));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle

                    foreach (OrdenCompraE item in oListaOC)
                    {
                        if (item.numOrdenCompra == "X")
                        {
                            oHoja.Cells[InicioLinea, 10, InicioLinea, 11].Merge = true;
                            oHoja.Cells[InicioLinea, 10].Value = "TOTAL >>>";
                            oHoja.Cells[InicioLinea, 12].Value = item.impCostoS;
                            oHoja.Cells[InicioLinea, 13].Value = item.impCostoD;
                            oHoja.Cells[InicioLinea, 14].Value = item.impCostoTotS;
                            oHoja.Cells[InicioLinea, 15].Value = item.impCostoTotD;

                            for (int i = 10; i <= 15; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(208, 206, 206));

                                if (i != 10 && i != 11)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                }
                            }

                            InicioLinea ++;
                        }
                        else if (item.numOrdenCompra == "XX")
                        {
                            oHoja.Cells[InicioLinea, 10, InicioLinea, 11].Merge = true;
                            oHoja.Cells[InicioLinea, 10].Value = "TOTAL GENERAL";
                            oHoja.Cells[InicioLinea, 12].Value = item.impCostoS;
                            oHoja.Cells[InicioLinea, 13].Value = item.impCostoD;
                            oHoja.Cells[InicioLinea, 14].Value = item.impCostoTotS;
                            oHoja.Cells[InicioLinea, 15].Value = item.impCostoTotD;

                            for (int i = 10; i <= 15; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9f, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(174, 170, 170));

                                if (i != 10 && i != 11)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                }
                            }
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.fecEmision;
                            oHoja.Cells[InicioLinea, 2].Value = item.numOrdenCompra;
                            oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 4].Value = item.tipCompra;
                            oHoja.Cells[InicioLinea, 5].Value = item.impVenta;
                            oHoja.Cells[InicioLinea, 6].Value = item.idDocumentoAlmacen;
                            oHoja.Cells[InicioLinea, 7].Value = item.numItem;
                            oHoja.Cells[InicioLinea, 8].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 9].Value = item.desArticulo;
                            oHoja.Cells[InicioLinea, 10].Value = item.fecAlmacen;
                            oHoja.Cells[InicioLinea, 11].Value = item.CanOrdenada;
                            oHoja.Cells[InicioLinea, 12].Value = item.impCostoS;
                            oHoja.Cells[InicioLinea, 13].Value = item.impCostoD;
                            oHoja.Cells[InicioLinea, 14].Value = item.impCostoTotS;
                            oHoja.Cells[InicioLinea, 15].Value = item.impCostoTotD;
                            oHoja.Cells[InicioLinea, 16].Value = item.idDocumento + " " + item.numSerie + " " + item.numDocumento;
                            oHoja.Cells[InicioLinea, 17].Value = item.impDocSoles;
                            oHoja.Cells[InicioLinea, 18].Value = item.impDocDolar;
                            oHoja.Cells[InicioLinea, 19].Value = item.Voucher;
                            oHoja.Cells[InicioLinea, 20].Value = item.Cuenta;
                            oHoja.Cells[InicioLinea, 21].Value = item.CuentaDestino;

                            oHoja.Cells[InicioLinea, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            for (int i = 1; i <= TotColumnas; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7.5f));
                            }
                        }

                        InicioLinea++;
                    }

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();

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
                    oHoja.Workbook.Properties.Category = "Módulo de Almacén";
                    oHoja.Workbook.Properties.Comments = "Ordenes de Compra x N.I.";

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();

                    #endregion
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Imprimir()
        {
            try
            {
                if (oListaOC != null && oListaOC.Count > 0)
                {
                    Document docPdf = new Document(PageSize.A3.Rotate(), 10f, 10f, 10f, 10f);
                    Guid Aleatorio = Guid.NewGuid();
                    String NombreReporte = "Ordenes Compra " + Aleatorio.ToString();
                    String Extension = ".pdf";
                    RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

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

                        //Para la creacion del archivo pdf
                        RutaGeneral += NombreReporte + Extension;

                        if (File.Exists(RutaGeneral))
                        {
                            File.Delete(RutaGeneral);
                        }

                        FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                        PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 0.696f);

                        oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                        oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                        oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                        if (docPdf.IsOpen())
                        {
                            docPdf.CloseDocument();
                        }

                        int Columnas = 21;

                        #region Detalle

                        float[] AnchoColumna = new float[] { 0.03f, 0.029f, 0.1f, 0.013f, 0.028f, 0.028f, 0.018f, 0.04f, 0.1f, 0.03f, 0.025f, 0.03f, 0.03f, 0.03f, 0.03f, 0.05f, 0.03f, 0.03f, 0.045f, 0.03f, 0.03f };
                        PagRegOrdenesCompras ev = new PagRegOrdenesCompras();
                        ev.fecInicio = dtpInicio.Value.Date;
                        ev.fecFinal = dtpFinal.Value.Date;
                        ev.cols = AnchoColumna;
                        oPdfw.PageEvent = ev;

                        docPdf.Open();

                        PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                        TablaCabDetalle.WidthPercentage = 100;
                        TablaCabDetalle.SetWidths(AnchoColumna);

                        foreach (OrdenCompraE item in oListaOC)
                        {
                            if (item.numOrdenCompra == "X")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 1, "S9"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL >>>", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoS.ToString("N3"), new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoD.ToString("N3"), new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoTotS.ToString("N3"), new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoTotD.ToString("N3"), new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 1, "S6"));
                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S23"));
                                TablaCabDetalle.CompleteRow();
                            }
                            else if (item.numOrdenCompra == "XX")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 1, "S9"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL >>>", new BaseColor(174, 170, 170), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoS.ToString("N3"), new BaseColor(174, 170, 170), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoD.ToString("N3"), new BaseColor(174, 170, 170), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoTotS.ToString("N3"), new BaseColor(174, 170, 170), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoTotD.ToString("N3"), new BaseColor(174, 170, 170), "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4, 3));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 1, "S6"));
                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S23"));
                                TablaCabDetalle.CompleteRow();
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecEmision.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numOrdenCompra, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCompra, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impVenta.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoAlmacen.ToString(), null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numItem, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecAlmacen.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CanOrdenada.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoS.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoD.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoTotS.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoTotD.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento + " " + item.numSerie + " " + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDocSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDocSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Voucher, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cuenta, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CuentaDestino, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaCabDetalle.CompleteRow();
                            }
                        }

                        docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF                                           

                        #endregion

                        // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                        PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                        //establecer la acción abierta para nuestro objeto escritor
                        oPdfw.SetOpenAction(action);

                        //Liberando memoria
                        oPdfw.Flush();
                        docPdf.Close();
                        fsNuevoArchivo.Close();

                        if (!String.IsNullOrEmpty(RutaGeneral))
                        {
                            wbNavegador.Navigate(RutaGeneral);
                            RutaGeneral = String.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Exportar()
        {
            try
            {
                if (oListaOC == null || oListaOC.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String fec1 = dtpInicio.Value.ToString("dd-MM-yyyy");
                String fec2 = dtpFinal.Value.ToString("dd-MM-yyyy");

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en ", "Ordenes de Compra de " + fec1 + " al " + fec2, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = 2;
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
                string Inicio = dtpInicio.Value.ToString("yyyyMMdd");
                string Fin = dtpFinal.Value.ToString("yyyyMMdd");

                oListaOC = AgenteAlmacen.Proxy.OrdenCompraPorNotaIngreso(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, Inicio, Fin);

                if (tipoProceso == 1)
                {
                    Imprimir();
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
            Cursor = Cursors.Arrow;
            btObtener.Enabled = true;

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
                if (tipoProceso == 1)
                {
                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Exportación exitósa...");
                }

                btObtener.Enabled = true;
                btExportar.Enabled = true;
            }
        }

        #endregion

        #region Eventos

        private void frmReporteOcPorNotaIngreso_Load(object sender, EventArgs e)
        {
            Grid = false;

            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            dtpFinal.Value = Convert.ToDateTime(FechasHelper.ObtenerUltimoDia(dtpInicio.Value));
        }

        private void btObtener_Click(object sender, EventArgs e)
        {
            try
            {
                tipoProceso = 1;

                Cursor = Cursors.WaitCursor;
                btObtener.Enabled = false;
                btExportar.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                btObtener.Enabled = false;
                Exportar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

    }

    class PagRegOrdenesCompras: PdfPageEventHelper
    {
        public float[] cols { get; set; }
        public DateTime fecInicio { get; set; }
        public DateTime fecFinal { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;

            #endregion Variables

            TituloGeneral = "ORDENES DE COMPRA POR NOTAS DE INGRESO";
            SubTitulo = "DEL " + fecInicio.ToString("d") + " AL " + fecFinal.ToString("d");

            //Encabezado del reporte
            PdfPTable table = new PdfPTable(2);

            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + VariablesLocales.FechaHoy.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Hora: " + VariablesLocales.FechaHoy.ToString("hh:mm:ss tt"), null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            document.Add(table); //Añadiendo la tabla al documento PDF

            PdfPTable tablaTitulos = new PdfPTable(21);
            tablaTitulos.WidthPercentage = 100;
            tablaTitulos.SetWidths(cols);

            tablaTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 5, 1, "S23", "N"));
            tablaTitulos.CompleteRow();
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "S23", "N"));
            tablaTitulos.CompleteRow();

            //Fila en blanco
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "S23", "N"));
            tablaTitulos.CompleteRow();
            
            //Cabecera del detalle
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("ORDEN DE COMPRA", new BaseColor(174, 170,170), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S5", "N", 5, 5));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("INGRESO AL ALMACEN", new BaseColor(174, 170, 170), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S10", "N", 5, 5));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("PROVISION", new BaseColor(174, 170, 170), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S6", "N", 5, 5));
            tablaTitulos.CompleteRow();

            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Fec.O.C.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("N° O.C.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Razón Social", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("N.I.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Imp.O.C.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Doc.Alm.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Item", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Cód.Articulo", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Descripción", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Fec.Alm.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Cant.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Costo Unit. S/.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Costo Unit. US$", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Total S/.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Total US$", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Documento", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Imp.Doc. S/.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Imp.Doc. US$", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Voucher", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Cuenta", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.AddCell(ReaderHelper.NuevaCelda("Cta.Dest.", new BaseColor(208, 206, 206), "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
            tablaTitulos.CompleteRow();

            document.Add(tablaTitulos); //Añadiendo la tabla al documento PDF
        }

    }

}
