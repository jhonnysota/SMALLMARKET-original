using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

#region Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;

#endregion

namespace ClienteWinForm.Contabilidad.CtasPorPagar.Reportes
{
    public partial class frmReporteMovilidades : FrmMantenimientoBase
    {

        public frmReporteMovilidades()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            BuscarImagen();
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar{ get { return new CtasPorPagarServiceAgent(); } }
        List<MovilidadDetE> oListaMovilidades = null;
        MovilidadE oTmp = new MovilidadE();
        String RutaGeneral = String.Empty;
        String RutaImagen = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        int tipoProceso = Variables.Cero; // 1 buscar; 0 exportar
        Int32 letra = 0;

        #endregion

        #region Procedimientos de Usuario

        void BuscarImagen()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void ConvertirApdf()
        {
            Document DocumentoPdf = new Document(PageSize.A4.Rotate(), 15f, 15f, 15f, 15f);

            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Movilidad " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Tesoreria");
            DocumentoPdf.AddSubject("Movilidades");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = "PLANILLA DE MOVILIDAD";

                    BaseColor ColorFondo = BaseColor.LIGHT_GRAY; //Gris Claro
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfPTable tableEncabezado = new PdfPTable(2);
                    tableEncabezado.WidthPercentage = 100;
                    tableEncabezado.SetWidths(new float[] { 0.9f, 0.13f });

                    #region Encabezado

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    //Filas en blanco
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f), -1, -1, "S4"));
                    tableEncabezado.CompleteRow();

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(2);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.03f, 0.2f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f));
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral.PadLeft(82, ' '), null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, -1, "N", "N", 13f, 13f));
                    tableTitulos.CompleteRow();
                    
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("De " + dtpFecIni.Value.ToString("d") + " al " + dtpFecFin.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S2"));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2", "N", 2f, 2f, "N", "S", "N", "N"));
                    tableTitulos.CompleteRow();

                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    #region Subtitulos

                    PdfPTable TablaDeta = new PdfPTable(8);
                    TablaDeta.WidthPercentage = 100;
                    TablaDeta.SetWidths(new float[] { 0.02f, 0.05f, 0.25f, 0.05f, 0.1f, 0.2f, 0.2f, 0.05f });                    

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Sucursal: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionLocal.Nombre, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S6"));

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Periodo: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("De " + dtpFecIni.Value.ToString("d") + " al " + dtpFecFin.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 0, "S6"));

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S8"));
                    TablaDeta.CompleteRow();

                    #endregion

                    #region Detalle

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Nro.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Fecha", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Empleado", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("DNI", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Area", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Desplazamiento", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Monto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.CompleteRow();

                    Int32 ItemCorre = 1;
                    Decimal totSoles = 0;

                    foreach (MovilidadDetE item in oListaMovilidades)
                    {
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(ItemCorre.ToString("00"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Fecha.ToString("dd/MM/yyyy"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.RUC, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.desCCostos, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Desplazamiento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.MotivoDestino, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TablaDeta.CompleteRow();

                        ItemCorre++;
                        totSoles += item.Monto;
                    }

                    ////Ultimas filas
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Totales (S/.)", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, -1, "S7"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(totSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaDeta.CompleteRow();

                    //Linea en blanco
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S8", "N", 2f, 2f, "N", "S", "N", "N"));
                    TablaDeta.CompleteRow();

                    DocumentoPdf.Add(TablaDeta); //Añadiendo la tabla al documento PDF

                    #endregion

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //Establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    DocumentoPdf.Close();
                }
            }
        }

        void ExportarExcel(String Ruta)
        {
            //String TituloGeneral = String.Empty;
            //String NombrePestaña = String.Empty;

            //TituloGeneral = "Registros de Compras";
            //NombrePestaña = "Compras";

            //if (File.Exists(Ruta))
            //{
            //    File.Delete(Ruta);
            //}

            //FileInfo newFile = new FileInfo(Ruta);

            //using (ExcelPackage oExcel = new ExcelPackage(newFile))
            //{
            //    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);
            //    List<RegistroComprasE> oListaDuas = null;

            //    List<RegistroComprasE> oListaNacionales = new List<RegistroComprasE>(from x in oListaMovilidades
            //                                                                         where (x.tipDocumentoVenta != "00"
            //                                                                         && x.tipDocumentoVenta != "91"
            //                                                                         && x.tipDocumentoVenta != "97"
            //                                                                         && x.tipDocumentoVenta != "98"
            //                                                                         && x.tipDocumentoVenta != null)
            //                                                                         select x).ToList();

            //    List<RegistroComprasE> oListaImportadas = new List<RegistroComprasE>(from x in oListaMovilidades
            //                                                                         where x.tipDocumentoVenta == "91"
            //                                                                         || x.tipDocumentoVenta == "97"
            //                                                                         || x.tipDocumentoVenta == "98"
            //                                                                         select x).ToList();

            //    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
            //    {
            //        oListaDuas = new List<RegistroComprasE>(from x in oListaMovilidades
            //                                                where x.tipDocumentoVenta == "50"
            //                                                || x.tipDocumentoVenta == "91"
            //                                                select x).ToList();
            //    }

            //    if (oHoja != null)
            //    {
            //        Int32 InicioLinea = 4;
            //        Int32 TotColumnas = 28;

            //        #region Titulos Principales

            //        // Creando Encabezado;
            //        oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

            //        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
            //        {
            //            Rango.Merge = true;
            //            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 20, FontStyle.Bold));
            //            //Rango.Style.Font.Color.SetColor(Color.White);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 219, 219));
            //        }

            //        oHoja.Cells["A2"].Value = TituloGeneral;

            //        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
            //        {
            //            Rango.Merge = true;
            //            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 18, FontStyle.Regular));
            //            Rango.Style.Font.Color.SetColor(Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
            //        }

            //        #endregion

            //        #region Cabecera

            //        #region Primera Linea Cabecera

            //        using (ExcelRange Rango = oHoja.Cells[4, 1, 6, 1])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Cod. Uni. de la Ope.";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 2, 6, 2])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Fecha de Emisiòn del Documento";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 3, 6, 3])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Fecha de Venc. y/o Pago";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 4, 5, 6])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Comprobante de Pago ó Documento ";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 7, 6, 7])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Nro. Comprobante de Pago";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 8, 4, 10])//
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Información del Proveedor";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 11, 5, 12])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 13, 5, 14])//
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación y a Operaciones no Gravadas";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 15, 5, 16])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones no Gravadas ";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 17, 6, 17])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Valor de las Adquisiciones no Gravadas";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 18, 6, 18])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "ISC";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 19, 6, 19])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Otros Tributos y Cargos";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 20, 6, 20])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Importe Total";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 21, 6, 21])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Nº de Comprobantes de Pago Emitido por Sujeto no Domiciliario";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 22, 5, 23])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Costancia de Déposito de Detración";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 24, 6, 24])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Tipo de Cambio";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[4, 25, 6, 28])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Referencia  de Comprobantes de Pago o Documento Original que se modififca";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        #endregion

            //        InicioLinea++;

            //        #region Segunda Linea Cabecera

            //        using (ExcelRange Rango = oHoja.Cells[5, 8, 5, 9])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Doc de Identidad";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        using (ExcelRange Rango = oHoja.Cells[5, 10, 6, 10])
            //        {
            //            Rango.Merge = true;
            //            Rango.Value = "Apellidos y Nombres ó Razon Social";
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //            Rango.Style.Font.Bold = true;
            //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            //        }

            //        #endregion

            //        InicioLinea++;

            //        #region Tercera Linea Cabecera

            //        oHoja.Row(6).Height = 30;

            //        oHoja.Cells[InicioLinea, 4].Value = "Tipo";
            //        oHoja.Cells[InicioLinea, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 5].Value = "Serie o Cod de la Dep. Adu.";
            //        oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 6].Value = "Año de la Emision de la Dua";
            //        oHoja.Cells[InicioLinea, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 6].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 8].Value = "Tipo";
            //        oHoja.Cells[InicioLinea, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 9].Value = "Nùmero";
            //        oHoja.Cells[InicioLinea, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 11].Value = "Base Imponible";
            //        oHoja.Cells[InicioLinea, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 11].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 12].Value = "IGV";
            //        oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 13].Value = "Base Imponible";
            //        oHoja.Cells[InicioLinea, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 13].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 13].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 14].Value = "IGV";
            //        oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 14].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 15].Value = "Base Imponible";
            //        oHoja.Cells[InicioLinea, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 15].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 15].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 16].Value = "IGV";
            //        oHoja.Cells[InicioLinea, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 16].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 16].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 16].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 22].Value = "Número";
            //        oHoja.Cells[InicioLinea, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 22].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 22].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 22].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 23].Value = "Fecha de Emisión";
            //        oHoja.Cells[InicioLinea, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 23].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 23].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 23].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 25].Value = "Fecha";
            //        oHoja.Cells[InicioLinea, 25].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 25].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 25].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 25].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 26].Value = "Tipo";
            //        oHoja.Cells[InicioLinea, 26].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 26].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 26].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 26].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 26].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 27].Value = "Serie";
            //        oHoja.Cells[InicioLinea, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 27].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 27].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 27].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        oHoja.Cells[InicioLinea, 28].Value = "Nº Documento";
            //        oHoja.Cells[InicioLinea, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        oHoja.Cells[InicioLinea, 28].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            //        oHoja.Cells[InicioLinea, 28].Style.Font.Bold = true;
            //        oHoja.Cells[InicioLinea, 28].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //        oHoja.Cells[InicioLinea, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //        oHoja.Cells[InicioLinea, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            //        #endregion

            //        #endregion

            //        //Aumentando una Fila mas continuar con el detalle
            //        InicioLinea++;

            //        #region Detalle

            //        foreach (RegistroComprasE item in oListaMovilidades)
            //        {
            //            if (!item.RazonSocial.Contains("TOTALES ACUMULADOS"))
            //            {
            //                oHoja.Cells[InicioLinea, 1].Value = item.Correlativo;
            //                oHoja.Cells[InicioLinea, 2].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");

            //                if (item.fecVencimiento != null)
            //                {
            //                    oHoja.Cells[InicioLinea, 3].Value = Convert.ToDateTime(item.fecVencimiento).ToString("d");
            //                }
            //                else
            //                {
            //                    oHoja.Cells[InicioLinea, 3].Value = " ";
            //                }

            //                oHoja.Cells[InicioLinea, 4].Value = item.tipDocumentoVenta;
            //                oHoja.Cells[InicioLinea, 5].Value = item.serDocumento;
            //                oHoja.Cells[InicioLinea, 6].Value = item.Dua;
            //                oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;
            //                oHoja.Cells[InicioLinea, 8].Value = item.tipDocPersona;
            //                oHoja.Cells[InicioLinea, 9].Value = item.RUC;
            //                oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;

            //                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 11].Value = item.BaseGravado;
            //                oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 12].Value = item.IgvGrabado;
            //                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 13].Value = item.BaseGravadoNoGravado;
            //                oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 14].Value = item.IgvGravadoNoGravado;
            //                oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 15].Value = item.BaseSinDerecho;
            //                oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 16].Value = item.IgvSinDerecho;
            //                oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 17].Value = item.BaseNoGravado;
            //                oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 18].Value = item.ISC;
            //                oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 19].Value = item.Otros;
            //                oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 20].Value = item.Total;

            //                oHoja.Cells[InicioLinea, 21].Value = item.docDomiciliado;
            //                oHoja.Cells[InicioLinea, 22].Value = item.numDetraccion;

            //                if (item.fecDetraccion != null)
            //                {
            //                    oHoja.Cells[InicioLinea, 23].Value = Convert.ToDateTime(item.fecDetraccion).ToString("d");
            //                }
            //                else
            //                {
            //                    oHoja.Cells[InicioLinea, 23].Value = " ";
            //                }

            //                oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "##0.00";
            //                oHoja.Cells[InicioLinea, 24].Value = item.tipCambio;

            //                if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "08")
            //                {
            //                    oHoja.Cells[InicioLinea, 25].Value = Convert.ToDateTime(item.fecDocumentoRef).ToString("d");
            //                    oHoja.Cells[InicioLinea, 26].Value = item.idDocumentoRef;
            //                    oHoja.Cells[InicioLinea, 27].Value = item.serDocumentoRef;
            //                    oHoja.Cells[InicioLinea, 28].Value = item.numDocumentoRef;
            //                }
            //                else
            //                {
            //                    oHoja.Cells[InicioLinea, 25].Value = " ";
            //                    oHoja.Cells[InicioLinea, 26].Value = " ";
            //                    oHoja.Cells[InicioLinea, 27].Value = " ";
            //                    oHoja.Cells[InicioLinea, 27].Value = " ";
            //                }
            //            }
            //            else
            //            {
            //                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Font.Bold = true;
            //                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;

            //                oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;
            //                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 11].Value = item.BaseGravado;
            //                oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 12].Value = item.IgvGrabado;
            //                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 13].Value = item.BaseGravadoNoGravado;
            //                oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 14].Value = item.IgvGravadoNoGravado;
            //                oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 15].Value = item.BaseSinDerecho;
            //                oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 16].Value = item.IgvSinDerecho;
            //                oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 17].Value = item.BaseNoGravado;
            //                oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 18].Value = item.ISC;
            //                oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 19].Value = item.Otros;
            //                oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //                oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
            //                oHoja.Cells[InicioLinea, 20].Value = item.Total;

            //                oHoja.Cells[InicioLinea + 1, 1, InicioLinea + 1, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;
            //            }

            //            InicioLinea++;
            //        }

            //        #endregion

            //        //Ajustando el ancho de las columnas automaticamente
            //        oHoja.Cells.AutoFitColumns();

            //        if (oListaImportadas.Count > Variables.Cero)
            //        {
            //            CargarOtros(oExcel, "Importadas", oListaImportadas);
            //        }

            //        if (oListaNacionales.Count > Variables.Cero)
            //        {
            //            CargarOtros(oExcel, "Nacionales", oListaNacionales);
            //        }

            //        if (oListaDuas != null && oListaDuas.Count > Variables.Cero)
            //        {
            //            CargarOtros(oExcel, "Duas", oListaDuas);
            //        }

            //        #region Propiedades del Excel

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

            //        #endregion

            //        //Guardando el excel
            //        oExcel.Save();
            //    }
            //}
        }

        #endregion

        #region Procesos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaMovilidades.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string dia = VariablesLocales.FechaHoy.Date.Day.ToString("00");
                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Compras (" + dia + "-" + mes + "-" + anio + ")", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = Variables.Cero;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Importando los Registro de Compras a Excel...";
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
                DateTime fecInicial = dtpFecIni.Value.Date;
                DateTime fecFin = dtpFecFin.Value.Date;

                if (tipoProceso == 1)
                {
                    //Obteniendo los datos de la BD
                    lblProcesando.Text = "Obteniendo las Movilidades...";
                    oListaMovilidades = AgenteCtasPorPagar.Proxy.MovilidadDetReporte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, fecInicial, fecFin);
                    lblProcesando.Text = "Armando el Reporte de Movilidades...";
                    ConvertirApdf();//Generando el PDF
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
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;
            
            pnlParametros.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (tipoProceso == 1)
            {
                //Mostrando el reporte en un web browser
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                    tipoProceso = 0;
                }
            }
            else
            {
                Global.MensajeComunicacion("Exportación Exitosa.");
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmReporteMovilidades_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                letra += 1;

                if (letra == Marque.Length)
                {
                    lblProcesando.Text = String.Empty;
                    letra = 0;
                }
                else
                {
                    lblProcesando.Text += Marque.Substring(letra - 1, 1);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipoProceso = 1; //Reporte en Pdf
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                btExcel.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                btExcel.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Global.MensajeComunicacion("En Construccion...");
                //if (oListaMovilidades == null)
                //{
                //    Global.MensajeFault("No hay Registros para exportar a Excel.");
                //    return;
                //}
                //if (oListaMovilidades.Count == Variables.Cero)
                //{
                //    Global.MensajeFault("No hay datos para exportar a Excel.");
                //    return;
                //}

                //string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                //string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                //RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Compras Alineado Por File " + mes + "-" + anio, "Archivos Excel (*.xlsx)|*.xlsx");

                //if (!String.IsNullOrEmpty(RutaGeneral))
                //{
                //    tipoProceso = 1;
                //    lblProcesando.Visible = true;
                //    timer.Enabled = true;
                //    Marque = "Importando el Registro de Movilidades a Excel...";
                //    pbProgress.Visible = true;
                //    Cursor = Cursors.WaitCursor;

                //    _bw.RunWorkerAsync();
                //}
                //else
                //{
                //    if (_bw.IsBusy)
                //    {
                //        _bw.CancelAsync();
                //    }
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

    }
}
