using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Maestros;
using ClienteWinForm.Busquedas;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoOrdenPago : FrmMantenimientoBase
    {

        public frmListadoOrdenPago()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
            
            FormatoGrid(dgvOrdenPago, true);
            LlenarCombo();
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        List<OrdenPagoE> ListaOrdenPago = null;
        OrdenPagoE oOrdenPago = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        String RutaPdf = String.Empty;
        Boolean Ordenar = false;

        #endregion

        #region Procedimientos de Usuario

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Orden de Pago";
            NombrePestaña = " Orden de Pago";

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 17;
                    Int32 TotColumnas = 10;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
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

                    oHoja.Cells[3, 1].Value = "Numero OP :" + oOrdenPago.idOrdenPago;
                    oHoja.Cells[4, 1].Value = "Fecha  :" + oOrdenPago.Fecha.ToString("d");
                    oHoja.Cells[5, 1].Value = "Proveedor :" + oOrdenPago.RazonSocial;
                    oHoja.Cells[6, 1].Value = "Beneficiario :" + oOrdenPago.idPersonaBeneficiario.ToString() + " " + oOrdenPago.NombreBen;
                    oHoja.Cells[9, 1].Value = "Moneda  :" + oOrdenPago.desMoneda;
                    oHoja.Cells[11, 1].Value = "Monto :" + oOrdenPago.Monto;
                    oHoja.Cells[12, 1].Value = "Glosa : " + oOrdenPago.Glosa;
                    oHoja.Cells[13, 1].Value = "Tipo De Pago : " + oOrdenPago.codTipoPago;
                    oHoja.Cells[14, 1].Value = "Forma De Pago : " + oOrdenPago.codFormaPago;

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " Item ";
                    oHoja.Cells[InicioLinea, 2].Value = " Fecha ";
                    oHoja.Cells[InicioLinea, 3].Value = " Razon Social";
                    oHoja.Cells[InicioLinea, 4].Value = " Tipo Documento  ";
                    oHoja.Cells[InicioLinea, 5].Value = " Serie  ";
                    oHoja.Cells[InicioLinea, 6].Value = " Numero ";
                    oHoja.Cells[InicioLinea, 7].Value = " Moneda ";
                    oHoja.Cells[InicioLinea, 8].Value = " Monto ";
                    oHoja.Cells[InicioLinea, 9].Value = " Concepto ";
                    oHoja.Cells[InicioLinea, 10].Value = " Descripcion ";

                    for (int i = 1; i <= 10; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Formato Excel

                    foreach (OrdenPagoDetE item in oOrdenPago.ListaOrdenPago)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.idOrdenPagoItem;
                        oHoja.Cells[InicioLinea, 2].Value = item.Fecha;
                        oHoja.Cells[InicioLinea, 3].Value = item.desProveedor;
                        oHoja.Cells[InicioLinea, 4].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 5].Value = item.serDocumento;
                        oHoja.Cells[InicioLinea, 6].Value = item.numDocumento;
                        oHoja.Cells[InicioLinea, 7].Value = item.desMoneda;
                        oHoja.Cells[InicioLinea, 8].Value = item.Monto;
                        oHoja.Cells[InicioLinea, 9].Value = item.Concepto;
                        oHoja.Cells[InicioLinea, 10].Value = item.Descripcion;

                        oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                    }

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

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
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();
                    Global.MensajeComunicacion("Exportacion Guardada");

                    #endregion
                }
            }
        }

        void CrearPdf(OrdenPagoE OrdenP)
        {
            String ConDetalle = Variables.NO;
            Document DocumentoPdf = null;

            if (OrdenP.ListaOrdenPago.Count > 0)
            {
                ConDetalle = Variables.SI;
            }

            DocumentoPdf = new Document((ConDetalle == "S" ? PageSize.A4.Rotate() : PageSize.A4), 15f, 15f, 15f, 15f);

            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Orden de Pago " + OrdenP.codOrdenPago + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Tesoreria");
            DocumentoPdf.AddSubject("Ordenes de Pago");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = " ORDEN DE PAGO N° " + OrdenP.codOrdenPago;

                    BaseColor ColorFondo = new BaseColor(169, 208, 142); //Gris Claro
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    if (ConDetalle == Variables.NO)
                    {
                        cb.RoundRectangle(12f, 748f, 570f, 41f, 10f);
                    }
                    else
                    {
                        cb.RoundRectangle(12f, 483.5f, 815f, 60f, 10f);
                    }

                    cb.SetLineWidth(1.5f);
                    cb.Stroke();

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

                    PdfPTable tableTitulos = new PdfPTable(4);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 5f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 13f, 13f, "N", "N"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha:\n" + OrdenP.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", (ConDetalle == "N" ? 8.25f : 10.25f)), 5, 1, "N", "N", 10f, 10f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(6);
                    tableSub.WidthPercentage = 97;
                    tableSub.SetWidths(new float[] { 0.1f, 0.01f, 0.4f, 0.12f, 0.01f, 0.15f });

                    #region Subtitulos

                    if (ConDetalle == Variables.NO)
                    {
                        tableSub.AddCell(ReaderHelper.NuevaCelda("Auxiliar", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenP.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda("RUC", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenP.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                        tableSub.CompleteRow();

                        tableSub.AddCell(ReaderHelper.NuevaCelda("Beneficiario", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenP.idPersonaBeneficiario.ToString() + " - " + OrdenP.NombreBen, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                        tableSub.CompleteRow();

                        tableSub.AddCell(ReaderHelper.NuevaCelda("Monto", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda((OrdenP.idMoneda == Variables.Soles ? "S/. " : "US$ ") + "  " + OrdenP.Monto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                        tableSub.CompleteRow();

                        tableSub.AddCell(ReaderHelper.NuevaCelda("Glosa", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenP.Glosa, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                        tableSub.CompleteRow();
                    }
                    else
                    {
                        tableSub.AddCell(ReaderHelper.NuevaCelda("Sucursal", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionLocal.Nombre, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    }

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    if (ConDetalle == Variables.SI)
                    {
                        PdfPTable TableDeta = new PdfPTable(15);
                        TableDeta.WidthPercentage = 100;
                        TableDeta.SetWidths(new float[] { 0.04f, 0.075f, 0.035f, 0.1f, 0.4f, 0.3f, 0.045f, 0.09f, 0.045f, 0.08f, 0.1f, 0.15f, 0.048f, 0.067f, 0.067f });
                        String M1 = (from z in VariablesLocales.ListaMonedas where z.idMoneda == Variables.Soles select z.desAbreviatura).FirstOrDefault();
                        String M2 = (from z in VariablesLocales.ListaMonedas where z.idMoneda == Variables.Dolares select z.desAbreviatura).FirstOrDefault();

                        #region Detalle

                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Documento", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Concepto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Mon.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Total", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Detalle de Pago", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Detracción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S3", "N", 4f, 4f));
                        TableDeta.CompleteRow();

                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Emisión", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("TD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Nro Doc.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Tercero", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));

                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Mon.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("T.Pago", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("F.Pago", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Cta.Proveedor", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("%", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Imp." + M1, ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Imp." + M2, ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.CompleteRow();

                        Int32 ItemCorre = 1;
                        Decimal totSoles = 0;
                        Decimal totDolares = 0;

                        foreach (OrdenPagoDetE item in OrdenP.ListaOrdenPago)
                        {
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(ItemCorre.ToString("00"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Fecha.ToString("dd/MM/yyyy"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.serDocumento + "-" + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desProveedor, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Concepto, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desMonedaBanco, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda((item.idMoneda == "01" ? item.Monto - item.MontoDetraS : item.Monto - item.MontoDetraD).ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda((item.Dias == 0 ? "CONTADO" : item.Dias.ToString() + " DIAS"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desBanco + " " + item.numCtaBancaria, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.porDetraccion.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.MontoDetraS.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.MontoDetraD.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.CompleteRow();

                            if (item.idMoneda == Variables.Soles)
                            {
                                totSoles += item.Monto;
                            }
                            else
                            {
                                totDolares += item.Monto;
                            }

                            ItemCorre++;
                        }

                        ////Ultimas filas
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Totales   ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S8"));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("S/.", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(totSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Totales Detracción", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S2"));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(OrdenP.ListaOrdenPago.Sum(x => x.MontoDetraS).ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(OrdenP.ListaOrdenPago.Sum(x => x.MontoDetraD).ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.CompleteRow();

                        TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S8"));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("US$", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(totDolares.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S5"));
                        TableDeta.CompleteRow();

                        DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                        #endregion 
                    }

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

        void LlenarCombo()
        {
            cboEstados.DataSource = Global.CargarEstados();
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "id";

            cboEstados.SelectedValue = "P";

            ///Locales////
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);
            cboSucursal.SelectedValue = Convert.ToInt32(VariablesLocales.SesionLocal.IdLocal);
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenPago);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                oFrm = new frmOrdenPago()
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                String Estado = cboEstados.SelectedValue.ToString();

                if (Estado == "0")
                {
                    Estado = "%";
                }

                ListaOrdenPago = AgenteTesoreria.Proxy.ListarOrdenPago(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboSucursal.SelectedValue), txtNroOp.Text.Trim(),
                                                            dtpFecIni.Value.Date, dtpFecFin.Value.Date, Estado);

                if (!String.IsNullOrWhiteSpace(txtRazonSocial.Text))
                {
                    ListaOrdenPago = (from x in ListaOrdenPago where x.RazonSocial.ToUpper().Contains(txtRazonSocial.Text.ToUpper()) select x).ToList();
                }

                bsOrdenPago.DataSource = ListaOrdenPago;
                bsOrdenPago.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsOrdenPago.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenPago);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmOrdenPago(((OrdenPagoE)bsOrdenPago.Current).idOrdenPago)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsOrdenPago.Count > Variables.Cero)
                {
                    Int32 resp = 0;

                    if (((OrdenPagoE)bsOrdenPago.Current).VieneDe == "M")
                    {
                        if (((OrdenPagoE)bsOrdenPago.Current).indEstado == "A")
                        {
                            if (Global.MensajeConfirmacion("La O.P. ya se encuentra anulada, desea eliminarla?") == DialogResult.Yes)
                            {
                                resp = AgenteTesoreria.Proxy.EliminarOrdenPago(((OrdenPagoE)bsOrdenPago.Current).idOrdenPago);

                                if (resp > 0)
                                {
                                    Buscar();
                                    Global.MensajeComunicacion("Se eliminó la O.P.");
                                }
                            }
                        }
                        else
                        {
                            resp = AgenteTesoreria.Proxy.ObtenerOpProgramaPago(((OrdenPagoE)bsOrdenPago.Current).idEmpresa, ((OrdenPagoE)bsOrdenPago.Current).idLocal, ((OrdenPagoE)bsOrdenPago.Current).idOrdenPago);

                            if (resp == 0)
                            {
                                if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                                {
                                    AgenteTesoreria.Proxy.CambiarEstadoOP(((OrdenPagoE)bsOrdenPago.Current).idOrdenPago, "A", VariablesLocales.SesionUsuario.Credencial);
                                    Buscar();
                                    Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                                    base.Anular();
                                }
                            }
                            else
                            {
                                Global.MensajeComunicacion(String.Format("No se puede anular la O.P. {0}, porque se encuentra en la Programación de Pagos.", ((OrdenPagoE)bsOrdenPago.Current).codOrdenPago));
                            }
                        } 
                    }
                    else
                    {
                        resp = AgenteTesoreria.Proxy.ObtenerOpProgramaPago(((OrdenPagoE)bsOrdenPago.Current).idEmpresa, ((OrdenPagoE)bsOrdenPago.Current).idLocal, ((OrdenPagoE)bsOrdenPago.Current).idOrdenPago);

                        if (resp == 0)
                        {
                            Global.MensajeComunicacion(String.Format("No se puede anular o eliminar la O.P. {0}, porque este registro viene desde otro Módulo.", ((OrdenPagoE)bsOrdenPago.Current).codOrdenPago));
                        }
                        else
                        {
                            Global.MensajeComunicacion(String.Format("No se puede anular la O.P. {0}, porque se encuentra en la Programación de Pagos.", ((OrdenPagoE)bsOrdenPago.Current).codOrdenPago));
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
                oOrdenPago = AgenteTesoreria.Proxy.ObtenerOrdenPagoCompleto(((OrdenPagoE)bsOrdenPago.Current).idOrdenPago);

                if (oOrdenPago == null || oOrdenPago.ListaOrdenPago.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", " Orden De Pago ", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    //tipo = "exportar";
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

        public override void Imprimir()
        {
            try
            {
                if (bsOrdenPago.Count > 0)
                {
                    OrdenPagoE oOrdenPago = AgenteTesoreria.Proxy.ObtenerOrdenPagoCompleto(((OrdenPagoE)bsOrdenPago.Current).idOrdenPago, Variables.SI);
                    frmImpresionBase oFrm = new frmImpresionBase(oOrdenPago, "Vista Previa de la Orden de Pago");
                    oFrm.MdiParent = MdiParent;
                    oFrm.Show();
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
            ExportarExcel(RutaGeneral);
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bw.CancelAsync();
            _bw.Dispose();
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmOrdenPago oFrm = sender as frmOrdenPago;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoOrdenPago_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();

            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvOrdenPago.Columns[0].Visible = false;
            }
        }

        private void dgvOrdenPago_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void mandarPorCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                OrdenPagoE oOrdenPago = AgenteTesoreria.Proxy.ObtenerOrdenPagoCompleto(((OrdenPagoE)bsOrdenPago.Current).idOrdenPago, Variables.SI);

                if (oOrdenPago != null)
                {
                    CrearPdf(oOrdenPago);
                    frmEnvioCorreos oFrm = new frmEnvioCorreos(oOrdenPago, RutaPdf);
                    oFrm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsOrdenPago_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (bsOrdenPago.Current != null)
            {
                lblRegistros.Text = String.Format("Registros {0}", ListaOrdenPago.Count.ToString()); 
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtRuc.Text.Trim()) && String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
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
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            dgvOrdenPago.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Text = String.Empty;
        }

        private void dgvOrdenPago_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((String)dgvOrdenPago.Rows[e.RowIndex].Cells["indEstado"].Value == "A")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
                else if ((String)dgvOrdenPago.Rows[e.RowIndex].Cells["indEstado"].Value == "C")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorCerrado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboEstados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvOrdenPago_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (ListaOrdenPago != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // Por orden de pago
                        if (e.ColumnIndex == dgvOrdenPago.Columns["codOrdenPago"].Index)
                        {
                            if (Ordenar)
                            {
                                ListaOrdenPago = (from x in ListaOrdenPago orderby x.codOrdenPago ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                ListaOrdenPago = (from x in ListaOrdenPago orderby x.codOrdenPago descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        // Por razón social
                        if (e.ColumnIndex == dgvOrdenPago.Columns["RAZONSOCIAL"].Index)
                        {
                            if (Ordenar)
                            {
                                ListaOrdenPago = (from x in ListaOrdenPago orderby x.RazonSocial ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                ListaOrdenPago = (from x in ListaOrdenPago orderby x.RazonSocial descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        // Por fecha
                        if (e.ColumnIndex == dgvOrdenPago.Columns["Fecha"].Index)
                        {
                            if (Ordenar)
                            {
                                ListaOrdenPago = (from x in ListaOrdenPago orderby x.Fecha ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                ListaOrdenPago = (from x in ListaOrdenPago orderby x.Fecha descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        // Por monto
                        if (e.ColumnIndex == dgvOrdenPago.Columns["Monto"].Index)
                        {
                            if (Ordenar)
                            {
                                ListaOrdenPago = (from x in ListaOrdenPago orderby x.Monto ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                ListaOrdenPago = (from x in ListaOrdenPago orderby x.Monto descending select x).ToList();
                                Ordenar = true;
                            }
                        }
                    }

                    bsOrdenPago.DataSource = ListaOrdenPago;
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
