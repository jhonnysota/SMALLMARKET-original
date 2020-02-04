using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;

using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteConciliacionPrevia : FrmMantenimientoBase
    {

        #region Constructores

        public frmReporteConciliacionPrevia()
        {
            InitializeComponent();
        }

        public frmReporteConciliacionPrevia(List<ConciliadoDcmtoPendienteE> oLista_, String Bancotmp_, String Numcuenta_, DateTime Periodo_, String Moneda_)
            :this()
        {
            oListaConciliacion = oLista_;
            nomBanco = Bancotmp_;
            numCuenta = Numcuenta_;
            Periodo = Periodo_;
            Moneda = Moneda_;
        } 

        #endregion

        #region Variables

        String nomBanco = String.Empty;
        String numCuenta = String.Empty;
        DateTime Periodo;
        String Moneda = String.Empty;
        String RutaGeneral = String.Empty;
        List<ConciliadoDcmtoPendienteE> oListaConciliacion;

        #endregion

        #region Procedimientos Heredados

        public override void Imprimir()
        {
            if (oListaConciliacion != null && oListaConciliacion.Count > 0)
            {
                Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                Guid Aleatorio = Guid.NewGuid();
                String NombreReporte = @"\Conciliacion " + Aleatorio.ToString();
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

                        Int32 Columnas = 4;
                        float[] ArrayColumnas = new float[] { 0.1f, 0.15f, 0.55f, 0.2f };
                        String[] ArrayTitulos = new String[] { "FECHA", "REFERENCIA", "DESCRIPCION", Moneda.ToUpper() };
                        String SubPeriodo = String.Empty;

                        PagRegInicioConciliacionPrevia ev = new PagRegInicioConciliacionPrevia
                        {
                            Columnas = Columnas,
                            ArrayColumnas = ArrayColumnas,
                            ArrayTitulos = ArrayTitulos,
                            Banco = nomBanco,
                            BancoCuenta = numCuenta,
                            Periodo = Periodo.ToString("dd") + " DE " + FechasHelper.NombreMes(Periodo.Month).ToUpper() + " " + Periodo.ToString("yyyy"),
                            Moneda = Moneda
                        };

                        oPdfw.PageEvent = ev;
                        docPdf.Open();

                        #region Formatos

                        PdfPTable TablaDetalle = new PdfPTable(Columnas);
                        TablaDetalle.SetWidths(ArrayColumnas);
                        TablaDetalle.WidthPercentage = 100;

                        if (oListaConciliacion != null && oListaConciliacion.Count > 0)
                        {
                            List<ConciliadoDcmtoPendienteE> agrupado =
                            (
                                from row in oListaConciliacion
                                group row by new { row.desGlosa, row.Orden } into g
                                select new ConciliadoDcmtoPendienteE()
                                {
                                    Orden = g.Key.Orden,
                                    desGlosa = g.Key.desGlosa,
                                    impMonto = g.Sum(x => x.impMonto)
                                }
                            ).ToList();

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 8f), -1, -1, "S4", "N", 1.5f, 1.5f));
                            TablaDetalle.CompleteRow(); //Linea en blanco
                            Boolean Encontro = false;
                            foreach (ConciliadoDcmtoPendienteE item in agrupado)
                            {
                                Encontro = false;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD)));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Orden == "1" ? item.desGlosa + "al " + Periodo.ToString("dd.MM.yyyy") : item.desGlosa, null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));

                                if (item.impMonto == 0)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda("-", null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD), 5, 2));
                                }
                                else
                                {
                                    if (item.Orden == "2" || item.Orden == "3" || item.Orden == "6")
                                    {
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impMonto > 0 ? "(" + item.impMonto.ToString("N2") + ")" : "(" + (item.impMonto * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD), 5, 2));
                                    }
                                    else
                                    {
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda((item.impMonto < 0 ? (item.impMonto * -1).ToString("N2") : item.impMonto.ToString("N2")), null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD), 5, 2));
                                    }
                                }

                                TablaDetalle.CompleteRow();

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 8f), -1, -1, "S4", "N", 1.5f, 1.5f));
                                TablaDetalle.CompleteRow(); //Linea en blanco

                                foreach (ConciliadoDcmtoPendienteE Fila in oListaConciliacion)
                                {
                                    if (Fila.desGlosa == item.desGlosa && Fila.Orden != "1" && !Fila.Ignorar)
                                    {
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Fila.fecDocumento.Value.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Calibri", 7.25f), 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Fila.numDocumento, null, "N", null, FontFactory.GetFont("Calibri", 7.25f), 5, 0));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Fila.impMonto.ToString("N2"), null, "N", null, FontFactory.GetFont("Calibri", 7.25f), 5, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 7.25f), 5, 0));
                                        TablaDetalle.CompleteRow();
                                        Encontro = true;
                                    }
                                }

                                if (Encontro)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 8f), -1, -1, "S4", "N", 1.5f, 1.5f));
                                    TablaDetalle.CompleteRow(); //Linea en blanco 
                                }
                            }

                            Decimal tot1 = (from x in oListaConciliacion where x.Orden == "1" select x.impMonto).Sum();
                            Decimal tot2 = (from x in oListaConciliacion where x.Orden == "2" select x.impMonto).Sum(); //Negativo
                            Decimal tot3 = (from x in oListaConciliacion where x.Orden == "3" select x.impMonto).Sum(); //Negativo
                            Decimal tot4 = (from x in oListaConciliacion where x.Orden == "4" select x.impMonto).Sum();
                            Decimal tot5 = (from x in oListaConciliacion where x.Orden == "5" select x.impMonto).Sum();
                            Decimal tot6 = (from x in oListaConciliacion where x.Orden == "6" select x.impMonto).Sum(); //Negativo
                            Decimal TotalGeneral = tot1 + (tot2 > 0 ? tot2 * -1 : tot2) + (tot3 > 0 ? tot3 * -1 : tot3) + (tot4 < 0 ? tot4 * -1 : tot4) + (tot5 < 0 ? tot5 * -1 : tot5) + (tot6 > 0 ? tot6 * -1 : tot6);

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 8f), -1, -1, "S4", "N", 1.5f, 1.5f));
                            TablaDetalle.CompleteRow(); //Linea en blanco

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 8f), -1, -1, "S4", "N", 1.5f, 1.5f));
                            TablaDetalle.CompleteRow(); //Linea en blanco

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD)));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Saldo según libros al " + Periodo.ToString("dd.MM.yyyy"), null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneral > 0 ? TotalGeneral.ToString("N2") : "(" + (TotalGeneral * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaDetalle.CompleteRow();

                            docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF
                        }

                        #endregion

                        // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                        PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                        //establecer la acción abierta para nuestro objeto escritor
                        oPdfw.SetOpenAction(action);

                        //Liberando memoria
                        oPdfw.Flush();
                        docPdf.Close();
                    }

                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                    }
                }
            }
        }

        public override void Exportar()
        {
            if (oListaConciliacion != null && oListaConciliacion.Count > 0)
            {
                String NombreArchivo = String.Empty;
                String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Conciliación Bancaria", "Archivos Excel (*.xlsx)|*.xlsx");
                Int32 totColumnas = 4;

                if (!String.IsNullOrEmpty(RutaArchivo.Trim()))
                {
                    if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);
                    FileInfo newFile = new FileInfo(RutaArchivo);

                    using (ExcelPackage oExcel = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(nomBanco);

                        if (oHoja != null)
                        {
                            #region Titulos

                            oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                            using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 14, FontStyle.Bold));
                                //Rango.Style.Font.Color.SetColor(Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            }

                            oHoja.Cells["A3"].Value = "CTA.CTE. " + Moneda.ToUpper() + " N° " + numCuenta + " " + nomBanco.ToUpper();

                            using (ExcelRange Rango = oHoja.Cells[3, 1, 3, totColumnas])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9, FontStyle.Bold));
                                //Rango.Style.Font.Color.SetColor(Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            oHoja.Cells["A4"].Value = "AL " + Periodo.ToString("dd") + " DE " + FechasHelper.NombreMes(Periodo.Month).ToUpper() + " " + Periodo.ToString("yyyy");

                            using (ExcelRange Rango = oHoja.Cells[4, 1, 4, totColumnas])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9, FontStyle.Bold));
                                //Rango.Style.Font.Color.SetColor(Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            oHoja.Cells["A5"].Value = "(Expresado en " + Moneda.ToLower() + ")";

                            using (ExcelRange Rango = oHoja.Cells[5, 1, 5, totColumnas])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9));
                                //Rango.Style.Font.Color.SetColor(Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            #endregion

                            #region Detalle

                            Int32 Fila = 7;
                            Int32 FilTotalInicio = 0;

                            oHoja.Cells[Fila, 1].Value = "FECHA";
                            oHoja.Cells[Fila, 2].Value = "REFERENCIA";
                            oHoja.Cells[Fila, 3].Value = "DESCRIPCION";
                            oHoja.Cells[Fila, 4].Value = Moneda.ToUpper();

                            for (int i = 1; i <= totColumnas; i++)
                            {
                                oHoja.Cells[Fila, i].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9, FontStyle.Bold));
                                oHoja.Cells[Fila, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[Fila, i].Style.Font.Color.SetColor(Color.White);
                                oHoja.Cells[Fila, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 176, 240));
                                oHoja.Cells[Fila, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[Fila, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                oHoja.Cells[Fila, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            }

                            List<ConciliadoDcmtoPendienteE> Agrupado =
                            (
                                from row in oListaConciliacion
                                group row by new { row.desGlosa, row.Orden } into g
                                select new ConciliadoDcmtoPendienteE()
                                {
                                    Orden = g.Key.Orden,
                                    desGlosa = g.Key.desGlosa,
                                    impMonto = g.Sum(x => x.impMonto)
                                }
                            ).ToList();

                            Fila++;
                            FilTotalInicio = Fila;

                            foreach (ConciliadoDcmtoPendienteE item in Agrupado)
                            {
                                Fila++;

                                oHoja.Cells[Fila, 2].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9, FontStyle.Bold));
                                oHoja.Cells[Fila, 2].Value = item.Orden == "1" ? item.desGlosa + "al " + Periodo.ToString("dd.MM.yyyy") : item.desGlosa;

                                oHoja.Cells[Fila, 4].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9, FontStyle.Bold));
                                oHoja.Cells[Fila, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                if (item.impMonto == 0)
                                {
                                    oHoja.Cells[Fila, 4].Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* \"-\"??_-;_-@_-";//Para que el cero salga en formato de guión
                                    oHoja.Cells[Fila, 4].Value = item.impMonto;
                                }
                                else
                                {
                                    if (item.Orden == "2" || item.Orden == "3" || item.Orden == "6")
                                    {
                                        item.impMonto = item.impMonto > 0 ? item.impMonto * -1 : item.impMonto;
                                        oHoja.Cells[Fila, 4].Style.Numberformat.Format = "#,##0.00_);(#,##0.00)";//Para que el formato de los negativos salga entreparentesis
                                        oHoja.Cells[Fila, 4].Value = item.impMonto;
                                    }
                                    else
                                    {
                                        oHoja.Cells[Fila, 4].Style.Numberformat.Format = "#,##0.00";//Formato normal
                                        oHoja.Cells[Fila, 4].Value = item.impMonto > 0 ? item.impMonto : item.impMonto * -1;
                                    }
                                }

                                if (item.Orden == "1")
                                {
                                    Fila++;
                                }
                                else
                                {
                                    Fila += 2;
                                }

                                foreach (ConciliadoDcmtoPendienteE itemConci in oListaConciliacion)
                                {
                                    if (itemConci.desGlosa == item.desGlosa && itemConci.Orden != "1" && !itemConci.Ignorar)
                                    {
                                        oHoja.Cells[Fila, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        oHoja.Cells[Fila, 1].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9));
                                        oHoja.Cells[Fila, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[Fila, 1].Value = itemConci.fecDocumento;

                                        oHoja.Cells[Fila, 2].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9));
                                        oHoja.Cells[Fila, 2].Value = itemConci.numDocumento;

                                        oHoja.Cells[Fila, 3].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9));
                                        oHoja.Cells[Fila, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                        oHoja.Cells[Fila, 3].Style.Numberformat.Format = "#,##0.00";
                                        oHoja.Cells[Fila, 3].Value = itemConci.impMonto;

                                        Fila++;
                                    }
                                    else
                                    {
                                        if (itemConci.desGlosa == item.desGlosa && itemConci.Orden != "1" && itemConci.Ignorar)
                                        {
                                            Fila--;
                                        }
                                    }
                                }
                            }

                            #endregion

                            //Total Final
                            Fila += 3;
                            FilTotalInicio++;
                            oHoja.Cells[Fila, 2].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9, FontStyle.Bold));
                            oHoja.Cells[Fila, 2].Value = "Saldo según libros al " + Periodo.ToString("dd.MM.yyyy");
                            oHoja.Cells[Fila, 4].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 9, FontStyle.Bold));
                            oHoja.Cells[Fila, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[Fila, 4].Style.Numberformat.Format = "#,##0.00_);(#,##0.00)";
                            oHoja.Cells[Fila, 4].Formula = "SUM(D" + FilTotalInicio.ToString() + ":D" + (Fila - 3).ToString() + ")";

                            //Quitando las lineas de la hoja excel
                            oHoja.View.ShowGridLines = false;
                            //Ajustando el ancho de las columnas
                            oHoja.Column(1).Width = 11;
                            oHoja.Column(2).Width = 10;
                            oHoja.Column(3).Width = 40;
                            oHoja.Column(4).Width = 14;

                            oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                            //Pie de Pagina(centro)
                            oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                            //Otras Propiedades
                            //oHoja.Workbook.Properties.Title = TituloGeneral;
                            oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                            oHoja.Workbook.Properties.Subject = "Reportes";
                            //oHoja.Workbook.Properties.Keywords = "";
                            oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                            //oHoja.Workbook.Properties.Comments = NombrePestaña;

                            // Establecer algunos valores de las propiedades extendidas
                            oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                            //Propiedades para imprimir
                            oHoja.PrinterSettings.Orientation = eOrientation.Portrait;
                            oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                            //Guardando el excel
                            oExcel.Save();
                            Global.MensajeComunicacion("Datos Exportados...");
                        }
                    }
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteConciliacionPrevia_Load(object sender, EventArgs e)
        {
            try
            {
                //Ubicacion del Reporte
                Location = new Point(0, 0);
                Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

                BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                Imprimir();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

    }

    class PagRegInicioConciliacionPrevia : PdfPageEventHelper
    {
        #region Variables

        public int Columnas { get; set; }
        public float[] ArrayColumnas { get; set; }
        public String[] ArrayTitulos { get; set; }
        public String Banco { get; set; }
        public String BancoCuenta { get; set; }
        public String Periodo { get; set; }
        public String Moneda { get; set; }

        #endregion

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            BaseColor colCabDetalle = new BaseColor(0, 176, 240);
            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;

            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            #endregion Variables

            TituloGeneral = "CTA.CTE. " + Moneda.ToUpper() + " N° " + BancoCuenta + " " + Banco.ToUpper();
            SubTitulo = "AL " + Periodo;
            Moneda = "(Expresado en " + Moneda.ToLower() + ")";

            //Cabecera del Reporte
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100,
                Summary = "xxx"
            };

            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            #region Encabezado

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

            #region Titulos Principales

            table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Calibri", 9f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Calibri", 9f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda(Moneda, null, "N", null, FontFactory.GetFont("Calibri", 9f, iTextSharp.text.Font.NORMAL), 1, 1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.NORMAL), 1, 1, "S2", "N"));
            table.CompleteRow();

            document.Add(table); //Añadiendo la tabla al documento PDF 

            #endregion

            #region Cabeceras del Detalles

            table = new PdfPTable(Columnas)
            {
                WidthPercentage = 100
            };

            table.SetWidths(ArrayColumnas);
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            for (int i = 0; i < ArrayTitulos.Length; i++)
            {
                table.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos[i], colCabDetalle, "S", null, FontFactory.GetFont("Calibri", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 1, 1));
            }

            table.CompleteRow();

            document.Add(table);

            #endregion

        }

    }
}
