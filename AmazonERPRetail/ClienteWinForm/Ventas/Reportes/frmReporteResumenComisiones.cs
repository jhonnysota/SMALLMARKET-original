using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteResumenComisiones : FrmMantenimientoBase
    {
        public frmReporteResumenComisiones()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<comisionE> oReporteC= null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Marque = String.Empty;
        string tipo = "buscar";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {



            //////Periodo/////////
            List<PeriodoComisionE> ListaComision = AgenteVentas.Proxy.ListarPeriodoComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            //PeriodoComisionE Fila = new PeriodoComisionE();
            //Fila.idPeriodo = Variables.ValorCero;
            //Fila.Mes = "<<SELECCIONE>>";
            //ListaComision.Add(Fila);
            ComboHelper.RellenarCombos<PeriodoComisionE>(cboPeriodo, (from x in ListaComision orderby x.Nombre select x).ToList(), "idPeriodo", "Nombre", false);

        }

        #endregion

        #region Procedimientos de Usuario

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\ResumenComisiones";
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

                PaginaInicioResumenComisiones ev = new PaginaInicioResumenComisiones();
                ev.Periodo = Convert.ToString(cboPeriodo.Text);
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(11);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.05f, 0.1f, 0.1f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f });

                Decimal CategoriaTotal = 0;
                Decimal CategoriaTotal1 = 0;
                Decimal CategoriaTotal2 = 0;
                Decimal Subjetivo = 0;



                foreach (comisionE item in oReporteC)
                {

                    CategoriaTotal = CategoriaTotal + item.Categoria;

                    CategoriaTotal1 = CategoriaTotal1 + item.Categoria1;

                    CategoriaTotal2 = CategoriaTotal2 + item.Categoria2;

                    Subjetivo = Subjetivo + item.Subjetivo;


                    cell = new PdfPCell(new Paragraph(item.Nombres.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.ApeMaterno.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.ApePaterno.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.NroDocumento.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.idEmpresa.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.idPeriodo.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.idVendedor.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Categoria.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Categoria1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Categoria2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Subjetivo.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);




                    TablaCabDetalle.CompleteRow();
                }

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("------------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("------------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("------------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("------------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);


                TablaCabDetalle.CompleteRow();




                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(CategoriaTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(CategoriaTotal1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(CategoriaTotal2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Subjetivo.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
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
                fsNuevoArchivo.Close();
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                Int32 Periodo = Convert.ToInt32(cboPeriodo.SelectedValue);

                lblProcesando.Text = "Obteniendo el Resumen De Comisiones...";
                oReporteC = AgenteVentas.Proxy.ResumenComisiones(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Periodo);
                lblProcesando.Text = "Armando el Resumen...";
                ConvertirApdf();
            }
            else
            {
                ExportarExcel(RutaGeneral);
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
            //btPle.Enabled = true;
            //btPdb.Enabled = true;

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
                Global.MensajeComunicacion("Resumen Comisiones Exportado...");
            }
        }

        #endregion

        #region Eventos

        private void frmReporteResumenComisiones_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        private void frmReporteComprasVarias_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void btBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                tipo = "buscar";
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                //btPle.Enabled = false;
                //btPdb.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                //btPle.Enabled = true;
                //btPdb.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region FormatoExcel

        public override void Exportar()
        {
            try
            {
                if (oReporteC == null || oReporteC.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = cboPeriodo.Text;
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + cboPeriodo.Text;


                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Resumen Comisiones"  + "-" , "Archivos Excel (*.xlsx)|*.xlsx");

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
          



            TituloGeneral = " Resumen Comisiones";
            NombrePestaña = " Resumen Comisiones ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 11;

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

                   

                    //PRIMERA


                    oHoja.Cells[InicioLinea, 1].Value = " NOMBRES ";
                    oHoja.Cells[InicioLinea, 2].Value = " APE. MATERNO ";
                    oHoja.Cells[InicioLinea, 3].Value = " APE. PATERNO ";
                    oHoja.Cells[InicioLinea, 4].Value = " NRO. DOCUMENTO ";
                    oHoja.Cells[InicioLinea, 5].Value = " EMPRESA ";
                    oHoja.Cells[InicioLinea, 6].Value = " PERIODO ";
                    oHoja.Cells[InicioLinea, 7].Value = " VENDEDOR ";
                    oHoja.Cells[InicioLinea, 8].Value = " CATEGORIA ";
                    oHoja.Cells[InicioLinea, 9].Value = " CATEGORIA 1 ";
                    oHoja.Cells[InicioLinea, 10].Value = " CATEGORIA 2 ";
                    oHoja.Cells[InicioLinea, 11].Value = " SUBJETIVO ";



                    for (int i = 1; i <= 11; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

        #endregion

        #region Formato Excel

                    //Int32 col = 1;

                    Decimal CategoriaTotal = 0;
                    Decimal CategoriaTotal1 = 0;
                    Decimal CategoriaTotal2 = 0;
                    Decimal Subjetivo = 0;


                    foreach (comisionE item in oReporteC)
                    {
                        

                        oHoja.Cells[InicioLinea, 1].Value = item.Nombres;
                        oHoja.Cells[InicioLinea, 2].Value = item.ApeMaterno;
                        oHoja.Cells[InicioLinea, 3].Value = item.ApePaterno;
                        oHoja.Cells[InicioLinea, 4].Value = item.NroDocumento;
                        oHoja.Cells[InicioLinea, 5].Value = item.idEmpresa;
                        oHoja.Cells[InicioLinea, 6].Value = item.idPeriodo;
                        oHoja.Cells[InicioLinea, 7].Value = item.idVendedor;
                        oHoja.Cells[InicioLinea, 8].Value = item.Categoria;
                        oHoja.Cells[InicioLinea, 9].Value = item.Categoria1;
                        oHoja.Cells[InicioLinea, 10].Value = item.Categoria2;
                        oHoja.Cells[InicioLinea, 11].Value = item.Subjetivo;



                        // FORMAT 
                        
                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";




                        CategoriaTotal = CategoriaTotal + item.Categoria;

                        CategoriaTotal1 = CategoriaTotal1 + item.Categoria1;

                        CategoriaTotal2 = CategoriaTotal2 + item.Categoria2;

                        Subjetivo = Subjetivo + item.Subjetivo; 

                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 8].Value = CategoriaTotal;
                    oHoja.Cells[InicioLinea, 9].Value = CategoriaTotal1;
                    oHoja.Cells[InicioLinea, 10].Value = CategoriaTotal2;
                    oHoja.Cells[InicioLinea, 11].Value = Subjetivo;


                    InicioLinea++;

                    //FIN SUMATORIA //


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

                    #endregion

        

       



    }
}



         #region Pdf Inicio


class PaginaInicioResumenComisiones : PdfPageEventHelper
{
    public String Periodo { get; set; }




    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        //Chunk ch = new Chunk("This is my Stack Overflow Header on page " + writer.PageNumber);
        //document.Add(ch);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;




        TituloGeneral = "Resumen De Comisiones " + "Con Fecha De " + FechaActual.ToUpper();

        SubTitulo = "Periodo : " + Periodo.ToUpper() ;


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

        PdfPTable TablaCabDetalle = new PdfPTable(11);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.05f, 0.1f, 0.1f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f });

        #region Primera Linea

        cell = new PdfPCell(new Paragraph("NOMBRES", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("APE. MATERNO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("APE. PATERNO ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("NRO. DOCUMENTO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("EMPRESA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("PERIODO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("VENDEDOR", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("CATEGORIA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("CATEGORIA 1", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("CATEGORIA 2", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("SUBJETIVO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);




        TablaCabDetalle.CompleteRow();

        #endregion

        //#region Segunda Linea

        //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 1;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 1;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 1;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 1;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("Gravado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 3;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("No Gravado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 3;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("IGV", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 3;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 1;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("Gravado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 3;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("No Gravado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 3;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("IGV", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 3;
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 1;
        //TablaCabDetalle.AddCell(cell);

        //TablaCabDetalle.CompleteRow();

        //#endregion



        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}
#endregion