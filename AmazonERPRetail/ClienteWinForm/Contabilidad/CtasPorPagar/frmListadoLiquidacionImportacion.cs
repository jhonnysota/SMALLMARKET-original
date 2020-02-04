using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Contabilidad.Reportes;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmListadoLiquidacionImportacion : FrmMantenimientoBase
    {

        public frmListadoLiquidacionImportacion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvLiquidacion, true);
            LlenarCombo();
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        List<LiquidacionImportacionE> ListaLiquidacion = null;
        String RutaPdf = String.Empty;
        String RutaImagen = String.Empty;
        String RutaGeneral = String.Empty;
        //UsuarioFondoFijoE oFondoSeg = null;

        #endregion

        #region Procedimientos de Usuario

        void BuscarImagen()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void LlenarCombo()
        {
            cboEstados.DataSource = Global.CargarEstados("N");
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "id";

            cboEstados.SelectedValue = "P";
        }

        void CrearPdf(LiquidacionE oLiqui)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Liquidación " + Aleatorio.ToString();
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
            DocumentoPdf.AddSubject("Liquidacion");

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
                    String Subtitulo = String.Empty;

                    TituloGeneral = oLiqui.Titulo;
                    Subtitulo = oLiqui.idLiquidacion.ToString("00000") + " - AÑO - " + oLiqui.Fecha.ToString("yyyy");

                    BaseColor ColorFondo = new BaseColor(Color.LightGray); //Gris Claro
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
                    cb.RoundRectangle(12f, 748f, 570f, 41f, 10f);
                    cb.SetLineWidth(0.5f);
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
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f));
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha:\n" + oLiqui.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S1"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(Subtitulo, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S1"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(4);
                    tableSub.WidthPercentage = 97;
                    tableSub.SetWidths(new float[] { 0.1f, 0.5f, 0.2f, 0.4f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Persona: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Periodo: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Del " + oLiqui.PeriodoIni.Day + " " + FechasHelper.NombreMes(oLiqui.PeriodoIni.Month) + " " + oLiqui.PeriodoIni.Year + " Al " + oLiqui.PeriodoFin.Day + " " + FechasHelper.NombreMes(oLiqui.PeriodoFin.Month) + " " + oLiqui.PeriodoFin.Year, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("O.P.: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.codOrdenPago, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("RUC/DNI: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta = new PdfPTable(13);
                    TableDeta.WidthPercentage = 98;
                    TableDeta.SetWidths(new float[] { 0.04f, 0.07f, 0.04f, 0.08f, 0.26f, 0.1f, 0.04f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f });

                    #region Detalle

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Fecha Doc", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Documento", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Razón Social y/o Nombre", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Detalle/Concepto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Mon", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Valor Venta S/", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("IGV S/", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Precio Venta S/.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Valor Venta US$.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("IGV US$", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Precio Venta US$.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.CompleteRow();

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("T.D.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Número", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    Decimal TOTVVSOLES = 0;
                    Decimal TOTALIGVSOLES = 0;
                    Decimal TOTALSOLES = 0;
                    Decimal TOTVVDOLARES = 0;
                    Decimal IGVDOLARES = 0;
                    Decimal TOTALDOLARES = 0;
                    Int32 Correlativo = 1;

                    foreach (LiquidacionDetE item in oLiqui.ListaLiquidacionDet)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(Correlativo.ToString(), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.Value.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.numSerie + "-" + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Glosa, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.VVentaSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.IgvSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.TotalSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.VVentaDolar.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.IgvDolar.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.TotalDolar.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));

                        TOTVVSOLES += item.VVentaSoles;
                        TOTALIGVSOLES += item.IgvSoles;
                        TOTALSOLES += item.TotalSoles;
                        TOTVVDOLARES += item.VVentaDolar;
                        IGVDOLARES += item.IgvDolar;
                        TOTALDOLARES += item.TotalDolar;
                        Correlativo++;
                        TableDeta.CompleteRow();
                    }

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S13"));
                    TableDeta.CompleteRow();

                    ////Ultima Fila
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "S5"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("<< TOTALES >>", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTVVSOLES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTALIGVSOLES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTALSOLES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTVVDOLARES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(IGVDOLARES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTALDOLARES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

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

        void ExportarExcel(String Ruta, LiquidacionE oLiqui)
        {
            String NombrePestaña = String.Empty;
            String TituloGeneral = String.Empty;
            String Subtitulo = String.Empty;

            Subtitulo = oLiqui.idLiquidacion.ToString("00000") + "  -  " + "AÑO -" + oLiqui.Fecha.ToString("yyyy");
            TituloGeneral = oLiqui.Titulo;
            NombrePestaña = oLiqui.Titulo;

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 7;
                    Int32 TotColumnas = 13;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.White);
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

                    oHoja.Cells["A2"].Value = oLiqui.idLiquidacion.ToString("00000") + " - " + "AÑO " + oLiqui.Fecha.ToString("yyyy") + " Fecha Liquidacion: " + oLiqui.Fecha.ToString("d");

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 12, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.White);
                    }

                    oHoja.Cells["A4"].Value = "Persona: " + oLiqui.RazonSocial;
                    oHoja.Cells["A4"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));
                    oHoja.Cells["F4"].Value = "RUC/DNI: " + oLiqui.RUC;
                    oHoja.Cells["F4"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));
                    oHoja.Cells["A5"].Value = "O.P.: " + oLiqui.codOrdenPago;
                    oHoja.Cells["A5"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));
                    oHoja.Cells["F5"].Value = "Periodo: " + "Del " + oLiqui.PeriodoIni.Day + " " + FechasHelper.NombreMes(oLiqui.PeriodoIni.Month) + " " + oLiqui.PeriodoIni.Year + " Al " + oLiqui.PeriodoFin.Day + " " + FechasHelper.NombreMes(oLiqui.PeriodoFin.Month) + " " + oLiqui.PeriodoFin.Year;
                    oHoja.Cells["F5"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "Item";
                    oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Merge = true;
                    oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 2].Value = "Fecha Doc.";
                    oHoja.Cells[InicioLinea, 2, InicioLinea + 1, 2].Merge = true;
                    oHoja.Cells[InicioLinea, 2, InicioLinea + 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 2, InicioLinea + 1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[InicioLinea, 2, InicioLinea + 1, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 3].Value = "Documento";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 4])
                    {
                        Rango.Merge = true;
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    oHoja.Cells[InicioLinea, 5].Value = "Razon Social y/o Nombre";
                    oHoja.Cells[InicioLinea, 5, InicioLinea + 1, 5].Merge = true;
                    oHoja.Cells[InicioLinea, 5, InicioLinea + 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 5, InicioLinea + 1, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[InicioLinea, 5, InicioLinea + 1, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 6].Value = "Detalle/Concepto";
                    oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6].Merge = true;
                    oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 7].Value = "Moneda";
                    oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7].Merge = true;
                    oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 8].Value = "Valor Venta S/";
                    oHoja.Cells[InicioLinea, 8, InicioLinea + 1, 8].Merge = true;
                    oHoja.Cells[InicioLinea, 8, InicioLinea + 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 8, InicioLinea + 1, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 8, InicioLinea + 1, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 9].Value = "IGV S/";
                    oHoja.Cells[InicioLinea, 9, InicioLinea + 1, 9].Merge = true;
                    oHoja.Cells[InicioLinea, 9, InicioLinea + 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 9, InicioLinea + 1, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 9, InicioLinea + 1, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 10].Value = "Precio Venta S/";
                    oHoja.Cells[InicioLinea, 10, InicioLinea + 1, 10].Merge = true;
                    oHoja.Cells[InicioLinea, 10, InicioLinea + 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 10, InicioLinea + 1, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 10, InicioLinea + 1, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 11].Value = "Valor Venta US$";
                    oHoja.Cells[InicioLinea, 11, InicioLinea + 1, 11].Merge = true;
                    oHoja.Cells[InicioLinea, 11, InicioLinea + 1, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 11, InicioLinea + 1, 11].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 11, InicioLinea + 1, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 11, InicioLinea + 1, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 12].Value = "IGV US$";
                    oHoja.Cells[InicioLinea, 12, InicioLinea + 1, 12].Merge = true;
                    oHoja.Cells[InicioLinea, 12, InicioLinea + 1, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 12, InicioLinea + 1, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 12, InicioLinea + 1, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 13].Value = "Precio Venta US$.";
                    oHoja.Cells[InicioLinea, 13, InicioLinea + 1, 13].Merge = true;
                    oHoja.Cells[InicioLinea, 13, InicioLinea + 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 13, InicioLinea + 1, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 13, InicioLinea + 1, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    for (int i = 1; i <= 13; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 3].Value = "Tipo";
                    oHoja.Cells[InicioLinea, 4].Value = "Número";

                    for (int i = 3; i <= 4; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Detalle

                    Decimal TOTVVSOLES = 0;
                    Decimal TOTALIGVSOLES = 0;
                    Decimal TOTALSOLES = 0;
                    Decimal TOTVVDOLARES = 0;
                    Decimal IGVDOLARES = 0;
                    Decimal TOTALDOLARES = 0;
                    Int32 Correlativo = 1;

                    foreach (LiquidacionDetE item in oLiqui.ListaLiquidacionDet)
                    {
                        oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 1].Value = Correlativo;
                        oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 2].Value = item.FechaDocumento;
                        oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 3].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 4].Value = item.numSerie + "-" + item.numDocumento;
                        oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 5].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 6].Value = item.Glosa;
                        oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 7].Value = item.desMoneda;
                        oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 8].Value = item.VVentaSoles;
                        oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 9].Value = item.IgvSoles;
                        oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 10].Value = item.TotalSoles;
                        oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 11].Value = item.VVentaDolar;
                        oHoja.Cells[InicioLinea, 12].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 12].Value = item.IgvDolar;
                        oHoja.Cells[InicioLinea, 13].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[InicioLinea, 13].Value = item.TotalDolar;

                        TOTVVSOLES += item.VVentaSoles;
                        TOTALIGVSOLES += item.IgvSoles;
                        TOTALSOLES += item.TotalSoles;
                        TOTVVDOLARES += item.VVentaDolar;
                        IGVDOLARES += item.IgvDolar;
                        TOTALDOLARES += item.TotalDolar;

                        oHoja.Cells[InicioLinea, 8, InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";

                        InicioLinea++;
                        Correlativo++;
                    }

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 7].Value = "TOTALES";
                    oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 8].Value = TOTVVSOLES;
                    oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 9].Value = TOTALIGVSOLES;
                    oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 10].Value = TOTALSOLES;
                    oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 11].Value = TOTVVDOLARES;
                    oHoja.Cells[InicioLinea, 12].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 12].Value = IGVDOLARES;
                    oHoja.Cells[InicioLinea, 13].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 13].Value = TOTALDOLARES;

                    oHoja.Cells[InicioLinea, 8, InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);
                    oHoja.Column(1).Width = 5;
                    oHoja.Column(5).Width = 40;
                    oHoja.Column(6).Width = 40;
                    oHoja.Row(7).Height = 18;
                    oHoja.Row(8).Height = 18;

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
                    oHoja.Workbook.Properties.Category = "Modulo de Tesoreria";
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

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLiquidacionImportacion);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmLiquidacionImportacion()
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
                dgvLiquidacion.SuspendLayout();
                //Abierto Inicialmente
                Boolean est1 = false;
                Boolean est2 = false;
                Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                Int32 idLocal = VariablesLocales.SesionLocal.IdLocal;

                //Cerrados
                if (cboEstados.SelectedValue.ToString() == "C")
                {
                    est1 = true;
                    est2 = true;
                }

                //Ambos casos
                if (cboEstados.SelectedValue.ToString() == "0")
                {
                    est1 = false;
                    est2 = true;
                }

                bsLiquidacion.DataSource = ListaLiquidacion = AgenteCtasPorPagar.Proxy.ListarLiquidacionImportacion(idEmpresa, idLocal, dtpFecIni.Value.Date, dtpFecFin.Value.Date, est1, est2, chkDetallado.Checked);
                bsLiquidacion.ResetBindings(false);
                dgvLiquidacion.ResumeLayout();
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLiquidacionImportacion);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmLiquidacionImportacion((LiquidacionImportacionE)bsLiquidacion.Current)
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

        public override void Anular()
        {
            try
            {
                if (bsLiquidacion.Count > Variables.Cero)
                {
                    LiquidacionImportacionE current = (LiquidacionImportacionE)bsLiquidacion.Current;

                    if (current != null)
                    {
                        if (current.Estado)
                        {
                            Global.MensajeAdvertencia("Debe abrir primero la Liquidación, antes de eliminarla");
                            return;
                        }

                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                        {
                            AgenteCtasPorPagar.Proxy.EliminarLiquidacionImportacion(current.idLiquidacion);
                            Buscar();
                            Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                        } 
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
                if (bsLiquidacion.Count > 0)
                {
                    LiquidacionImportacionE oLiquidacion = AgenteCtasPorPagar.Proxy.ObtenerLiquidacionImportacion(((LiquidacionImportacionE)bsLiquidacion.Current).idLiquidacion);

                    frmImpresionBase oFrm = new frmImpresionBase(oLiquidacion, "Vista Previa de Liquidación de Importación")
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.Show();
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
                if (bsLiquidacion.Count > 0)
                {
                    //LiquidacionE oLiquidacion = AgenteCtasPorPagar.Proxy.ObtenerLiquidacionCompleta(((LiquidacionE)bsLiquidacion.Current).idEmpresa, ((LiquidacionE)bsLiquidacion.Current).idLocal, ((LiquidacionE)bsLiquidacion.Current).idLiquidacion);
                    //if (rbFijos.Checked)
                    //{
                    //    oLiquidacion.Titulo = "LIQUIDACIÓN DE FONDOS FIJOS";
                    //}
                    //else if (rbRendir.Checked)
                    //{
                    //    oLiquidacion.Titulo = "LIQUIDACIÓN DE ENTREGAS A RENDIR / VIÁTICOS";
                    //}

                    //if (oLiquidacion.ListaLiquidacionDet == null || oLiquidacion.ListaLiquidacionDet.Count == Variables.Cero)
                    //{
                    //    Global.MensajeFault("No hay datos para exportar a Excel.");
                    //    return;
                    //}

                    RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", "Liquidaciones", "Archivos Excel (*.xlsx)|*.xlsx");
                    //ExportarExcel(RutaGeneral, oLiquidacion);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmLiquidacionImportacion oFrm = sender as frmLiquidacionImportacion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoLiquidacionImportacion_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            cboEstados_SelectionChangeCommitted(new object(), new EventArgs());
        }

        private void bsLiquidacion_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                if (bsLiquidacion.Count > 0)
                {
                    lblTitulo.Text = "Registros " + bsLiquidacion.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvLiquidacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((Boolean)dgvLiquidacion.Rows[e.RowIndex].Cells["Estado"].Value == true)
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
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLiquidacion.Current is LiquidacionImportacionE current)
                {
                    //Para obtener el estado correcto
                    current = AgenteCtasPorPagar.Proxy.ObtenerLiquidacionImportacion(current.idLiquidacion, "N");

                    if (!current.Estado) //0 ó false=Abierto - 1 ó true=Cerrado
                    {
                        if (!String.IsNullOrWhiteSpace(current.numVoucher))
                        {
                            VoucherE voucher = new ContabilidadServiceAgent().Proxy.ObtenerVoucherPorCodigo(current.idEmpresa, current.idLocal, current.AnioPeriodo, current.MesPeriodo, current.numVoucher, current.idComprobante, current.numFile, "N");

                            if (voucher != null)
                            {
                                Global.MensajeAdvertencia("El voucher de esta liquidación ya esta siendo utilizado, debe ingresar uno nuevo limpiando primero el número del voucher actual.");
                                return;
                            }
                        }

                        Int32 resp = AgenteCtasPorPagar.Proxy.CerrarLiquidacionImportacion(current, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("La liquidación se cerró correctamente.");
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("La liquidación ya se encuentra cerrada.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLiquidacion.Current is LiquidacionImportacionE current)
                {
                    if (current.Estado) //0 ó false=Abierto  1 ó true=Cerrado
                    {
                        AgenteCtasPorPagar.Proxy.AbrirLiquidacionImportacion(current, VariablesLocales.SesionUsuario.Credencial);
                        Buscar();
                        Global.MensajeComunicacion("La liquidación se abrió correctamente.");
                    }
                    else
                    {
                        Global.MensajeComunicacion("La liquidación ya se encuentra abierta.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLiquidacion.Current is LiquidacionImportacionE current)
                {
                    if (!String.IsNullOrWhiteSpace(current.numVoucher) && !String.IsNullOrWhiteSpace(current.AnioPeriodo))
                    {
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        VoucherE VoucherRep = new VoucherE
                        {
                            AnioPeriodo = current.AnioPeriodo,
                            numVoucher = current.numVoucher,
                            idComprobante = current.idComprobante,
                            numFile = current.numFile,
                            MesPeriodo = current.MesPeriodo,
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            idLocal = VariablesLocales.SesionLocal.IdLocal
                        };

                        oFrm = new frmImpresionVoucher("N", VoucherRep)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show();
                    }
                    else
                    {
                        Global.MensajeComunicacion("No se ha generado ningún comprobante para este registro.");
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLiquidacion.Current is LiquidacionImportacionE current)
                {
                    if (!current.Estado)
                    {
                        AgenteCtasPorPagar.Proxy.LimpiarVoucherLiquiImportacion(current.idLiquidacion, VariablesLocales.SesionUsuario.Credencial);
                        Buscar();
                        Global.MensajeComunicacion("Número Borrado.");
                    }
                    else
                    {
                        Global.MensajeComunicacion("Debe volver Abrir la Liquidación antes de limpiar el voucher.");
                    } 
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
