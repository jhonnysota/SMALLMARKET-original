using ClienteWinForm;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas
{
    public partial class frmReporteGuiaPorFacturar : FrmMantenimientoBase
    {
        public frmReporteGuiaPorFacturar()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<EmisionDocumentoDetE> oEmisionDocumento = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        String Marque = String.Empty;
        string tipo = "buscar";


        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\DiferenciaCambio " + Aleatorio.ToString();
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

                FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                if (docPdf.IsOpen())
                {
                    docPdf.CloseDocument();
                }

                PaginaInicialGuiaPorFacturar ev = new PaginaInicialGuiaPorFacturar();
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(10);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.2f, 0.1f, 0.1f, 0.3f, 0.1f, 0.1f, 0.1f });
                String CodAnterior = String.Empty;
                Decimal Diferencia = 0;
                String numDocumento = String.Empty;

                foreach (EmisionDocumentoDetE item in oEmisionDocumento)
                {

                    Diferencia = item.Cantidad - item.CantFactura;

                    if (item.Item != "001")
                    {
                        numDocumento = item.numDocumento;

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Item, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.nomArticulo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(item.Cantidad.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.CantFactura.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(Diferencia.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();

                    }

                    else if (item.Item == "001")
                    {
                        cell = new PdfPCell(new Paragraph(item.idDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(item.numSerie, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(item.numDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(item.razonSocial, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(item.fecEmision.ToString("d"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Item, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.nomArticulo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(item.Cantidad.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.CantFactura.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(Diferencia.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
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
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                Int32 idLocal = Convert.ToInt32(cboSucursal.SelectedValue);
                DateTime INI = dtpFechaInicio.Value;
                DateTime Fin = dtpFechaFin.Value;

                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo Guia Por Facturar...";
                oEmisionDocumento = AgenteVentas.Proxy.ReporteGuiaPorFacturar(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, INI, Fin);
                lblProcesando.Text = "Armando el Reporte...";
                //Generando el PDF
                ConvertirApdf();
            }
            else
            {
                ExportarExcel(RutaGeneral);
            }
        }

        public override void Exportar()
        {
            try
            {
                if (oEmisionDocumento == null || oEmisionDocumento.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = cboSucursal.Text;
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + cboSucursal.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Ajuste Diferencia De Cambio" + NombreLocal + "-" , "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    lblProcesando.Visible = true;
                    btBuscar.Enabled = true;
                    Marque = "Importando los registros a Excel...";
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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = " Guia Por Facturar";
            NombrePestaña = " Guia Por Facturar";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
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

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " DOCUMENTO ";
                    oHoja.Cells[InicioLinea, 2].Value = " SERIE ";
                    oHoja.Cells[InicioLinea, 3].Value = " NRO. DOCUMENTO ";
                    oHoja.Cells[InicioLinea, 4].Value = " RAZON SOCIAL ";
                    oHoja.Cells[InicioLinea, 5].Value = " FECHA EMISION ";
                    oHoja.Cells[InicioLinea, 6].Value = " ITEM ";
                    oHoja.Cells[InicioLinea, 7].Value = " NOMBRE ARTICULO ";
                    oHoja.Cells[InicioLinea, 8].Value = " CANTIDAD ";
                    oHoja.Cells[InicioLinea, 9].Value = " CANT. FACTURA ";
                    oHoja.Cells[InicioLinea, 10].Value = " RESTO ";



                    for (int i = 1; i <= 10; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }




                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    #endregion

                    Decimal Dif;

                    foreach (EmisionDocumentoDetE item in oEmisionDocumento)
                    {
                        Dif = item.Cantidad - item.CantFactura;

                        oHoja.Cells[InicioLinea, 1].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 2].Value = item.numSerie;
                        oHoja.Cells[InicioLinea, 3].Value = item.numDocumento;
                        oHoja.Cells[InicioLinea, 4].Value = item.razonSocial;
                        oHoja.Cells[InicioLinea, 5].Value = item.fecEmision;
                        oHoja.Cells[InicioLinea, 6].Value = item.Item;
                        oHoja.Cells[InicioLinea, 7].Value = item.nomArticulo;
                        oHoja.Cells[InicioLinea, 8].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 9].Value = item.CantFactura;
                        oHoja.Cells[InicioLinea, 10].Value = Dif;

                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "dd/MM/yyyy";
                        // FORMAT 

                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.000";
                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.000";
                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

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
                }
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

            //Mostrando el reporte en un web browser
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
                Global.MensajeComunicacion("Diferencia Cambio Exportado...");
            }
        }


        #endregion

        private void frmReporteGuiaPorFacturar_Load(object sender, EventArgs e)
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
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;
        }

        private void frmReporteDifCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                    tipo = "buscar";
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
    }

}


internal class PaginaInicialGuiaPorFacturar : PdfPageEventHelper
{
    public String NombreMes { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

        TituloGeneral = "Guia Por Facturar" ;

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.9f, 0.1f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha: " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Hora:   " + HoraActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        //cell.Colspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Pag.    " + writer.PageNumber, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        //cell.Colspan = 2;
        table.AddCell(cell);

        table.CompleteRow(); //Fila completada 

        #endregion

        #region Subtitulos

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada 

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(10);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.2f, 0.1f, 0.1f, 0.3f, 0.1f, 0.1f, 0.1f });

        #region Primera Linea

        cell = new PdfPCell(new Paragraph(" Documento ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Serie ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Num.Documento ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Razon Social", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Fecha Emisión", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Item", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Nombre Articulo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Cantidad", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Cant. Factura", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Resto", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);





        TablaCabDetalle.CompleteRow();

        #endregion


        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}