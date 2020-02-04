using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.CtasPorCobrar.Reportes
{
    public partial class frmReporteLetrasPorEstado : FrmMantenimientoBase
    {

        public frmReporteLetrasPorEstado()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            BuscarImagen();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<LetrasCanjeUnionE> oListaLetrasReporte = null;
        String RutaGeneral = String.Empty;
        String RutaImagen = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        int tipoProceso = Variables.Cero; // 1 buscar; 0 exportar
        Int32 letra = 0;

        #endregion

        #region Procedimientos Usuario

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

                    if (rdbPorAceptar.Checked == true)
                    {
                        TituloGeneral = " LETRAS POR ACEPTAR ";
                    }
                    else
                    {
                        TituloGeneral = " LETRAS ACEPTADAS ";
                    }
                  

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

                    #region Encabezado

                    PdfPTable tableEncabezado = new PdfPTable(2);
                    tableEncabezado.WidthPercentage = 100;
                    tableEncabezado.SetWidths(new float[] { 0.9f, 0.13f });                   

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

                    #region Titulos Principales

                    PdfPTable tableTitulos = new PdfPTable(2);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.03f, 0.2f });               

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
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral.PadLeft(63, ' '), null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, -1, "N", "N", 13f, 13f));
                    tableTitulos.CompleteRow();

                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S2"));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2", "N", 2f, 2f, "N", "S", "N", "N"));
                    tableTitulos.CompleteRow();

                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion 

                    #region Subtitulos

                    PdfPTable TablaDeta = new PdfPTable(13);
                    TablaDeta.WidthPercentage = 100;
                    TablaDeta.SetWidths(new float[] { 0.03f, 0.03f, 0.025f, 0.03f, 0.03f, 0.015f, 0.035f, 0.025f, 0.025f, 0.015f, 0.025f, 0.025f, 0.030f });

                    //TablaDeta.AddCell(ReaderHelper.NuevaCelda("Sucursal: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                    //TablaDeta.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionLocal.Nombre, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S6"));

                    //TablaDeta.AddCell(ReaderHelper.NuevaCelda("Periodo: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                    //TablaDeta.AddCell(ReaderHelper.NuevaCelda("De " + dtpFecIni.Value.ToString("d") + " al " + dtpFecFin.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 0, "S6"));

                    //TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S8"));
                    //TablaDeta.CompleteRow();

                    #endregion

                    #region Detalle
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("CANJE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("ZONA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("VENDEDOR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("RUC", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("CLIENTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("TIPO DOC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("NÚMERO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("EMISIÓN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("VENC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("MONEDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("IMPORTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("SALDO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("STATUS", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.CompleteRow();

                    Int32 ItemCorre = 1;

                    foreach (LetrasCanjeUnionE item in oListaLetrasReporte)
                    {
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.codCanje, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, -1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.nomZona, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, -1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.nomVendedor, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.ruc, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                        if (item.idDocumento == "LT")
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                        }
                        else
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numSerie + "-" + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                        }
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.fecDocumento.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.fecVencimiento.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.NomMoneda, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Importe.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.SaldoDoc.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.EstadoDocumento, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                        TablaDeta.CompleteRow();

                        ItemCorre++;
                    }

                    //////Ultimas filas
                    //TablaDeta.AddCell(ReaderHelper.NuevaCelda("Totales (S/.)", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, -1, "S7"));
                    //TablaDeta.AddCell(ReaderHelper.NuevaCelda(totSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2));
                    //TablaDeta.CompleteRow();

                    ////Linea en blanco
                    //TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S8", "N", 2f, 2f, "N", "S", "N", "N"));
                    //TablaDeta.CompleteRow();

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
            if (oListaLetrasReporte.Count > Variables.Cero)
            {
                if (!String.IsNullOrEmpty(Ruta))
                {
                    if (File.Exists(Ruta)) File.Delete(Ruta);

                    FileInfo newFile = new FileInfo(Ruta);

                    using (ExcelPackage oExcel = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("LETRAPORESTADO");

                        if (oHoja != null)
                        {
                            Int32 InicioLinea = 4;
                            Int32 TotColumnas = 13;

                            #region Titulos Principales

                            if (rdbPorAceptar.Checked == true)
                            {
                                oHoja.Cells["A1"].Value = " LETRAS POR ACEPTAR ";

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(245, 163, 113));
                                }
                            }
                            else
                            {
                                oHoja.Cells["A1"].Value = " LETRAS ACEPTADAS ";

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(245, 163, 113));
                                }
                            }

                            // Creando Encabezado;
                        


                            #endregion

                            #region Cabeceras del Detalle



                            // Primera
                            oHoja.Cells[InicioLinea, 1].Value = " CANJE";
                            oHoja.Cells[InicioLinea, 2].Value = " ZONA";
                            oHoja.Cells[InicioLinea, 3].Value = " VENDEDOR ";

                            oHoja.Cells[InicioLinea, 4].Value = " RUC";
                            oHoja.Cells[InicioLinea, 5].Value = " CLIENTE";

                            oHoja.Cells[InicioLinea, 6].Value = " TIPO DOC.";

                            oHoja.Cells[InicioLinea, 7].Value = " NÚMERO";
                            oHoja.Cells[InicioLinea, 8].Value = " EMISIÓN";
                            oHoja.Cells[InicioLinea, 9].Value = " VENCIMIENTO ";
                            oHoja.Cells[InicioLinea, 10].Value = " MONEDA ";

                            oHoja.Cells[InicioLinea, 11].Value = " IMPORTE ";

                            oHoja.Cells[InicioLinea, 12].Value = " SALDO ";

                            oHoja.Cells[InicioLinea, 13].Value = " STATUS ";


                            for (int i = 1; i <= 13; i++)
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

                            foreach (LetrasCanjeUnionE item in oListaLetrasReporte)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.codCanje;
                                oHoja.Cells[InicioLinea, 2].Value = item.nomZona;
                                oHoja.Cells[InicioLinea, 3].Value = item.nomVendedor;
                                oHoja.Cells[InicioLinea, 4].Value = item.ruc;
                                oHoja.Cells[InicioLinea, 5].Value = item.RazonSocial;
                                oHoja.Cells[InicioLinea, 6].Value = item.idDocumento;

                                if (item.idDocumento == "LT")
                                {
                                    oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 7].Value = item.numSerie + "-" + item.numDocumento;
                                }

                                oHoja.Cells[InicioLinea, 8].Value = item.fecDocumento;
                                oHoja.Cells[InicioLinea, 9].Value = item.fecVencimiento;
                                oHoja.Cells[InicioLinea, 10].Value = item.NomMoneda;
                                oHoja.Cells[InicioLinea, 11].Value = item.Importe;
                                oHoja.Cells[InicioLinea, 12].Value = item.SaldoDoc;
                                oHoja.Cells[InicioLinea, 13].Value = item.EstadoDocumento;

                                oHoja.Cells[InicioLinea, 11, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 8, InicioLinea, 9].Style.Numberformat.Format = "dd/MM/yyyy";

                                InicioLinea++;

                            }




                            #endregion

                            //Ajustando el ancho de las columnas automaticamente
                            oHoja.Cells.AutoFitColumns(0);

                            //Insertando Encabezado
                            //oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                            //Pie de Pagina(Derecho) "Número de paginas y el total"
                            oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                            //Pie de Pagina(centro)
                            oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                            //Otras Propiedades
                            //oHoja.Workbook.Properties.Title = TituloGeneral;
                            oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                            oHoja.Workbook.Properties.Subject = "Reportes";
                            //oHoja.Workbook.Properties.Keywords = "";
                            oHoja.Workbook.Properties.Category = "Módulo de Compras";
                            //oHoja.Workbook.Properties.Comments = NombrePestaña;

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
            }

        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                String Estado = "P";
                Int32 Persona = 0;

                if (!String.IsNullOrWhiteSpace(txtIdProveedor.Text))
                {
                    Persona = Convert.ToInt32(txtIdProveedor.Text);
                }

                if (rdbAceptado.Checked)
                {
                    Estado = "A";
                }
                else if (rbAmbos.Checked)
                {
                    Estado = "%";
                }

                if (tipoProceso == 1)
                {
                    //Obteniendo los datos de la BD
                    lblProcesando.Text = "Obteniendo las Letras Por Estado...";
                    oListaLetrasReporte = AgenteVentas.Proxy.ReporteCanjeLetraPorEstado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Persona, Estado);
                    lblProcesando.Text = "Armando el Reporte de Letras...";
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

        #endregion

        #region Procesos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaLetrasReporte.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Reporte De Letra Por Estado", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = Variables.Cero;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Importando las Letras Pro Estado a Excel...";
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

        #region Eventos

        private void frmReporteLetrasPorEstado_Load(object sender, EventArgs e)
        {
            Grid = true;
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

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void txtProveedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtProveedor.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtProveedor.TextChanged -= txtProveedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtProveedor.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtProveedor.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtProveedor.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Text = String.Empty;
                        txtProveedor.Text = String.Empty;
                        Global.MensajeFault("La razón social ingresada no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtProveedor.TextChanged += txtProveedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtProveedor.TextChanged += txtProveedor_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = String.Empty;
            txtProveedor.Text = String.Empty;
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtProveedor.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtProveedor.TextChanged -= txtProveedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtProveedor.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtProveedor.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtProveedor.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Text = String.Empty;
                        txtProveedor.Text = String.Empty;
                        Global.MensajeFault("El Ruc ingresado no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtProveedor.TextChanged += txtProveedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtProveedor.TextChanged += txtProveedor_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
