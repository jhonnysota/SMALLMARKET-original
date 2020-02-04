using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
//using Entidades.Asistencia;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Negocio;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ClienteWinForm;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReportePublicidadPendiente : FrmMantenimientoBase
    {
        #region Constructor

        public frmReportePublicidadPendiente()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            //Global.CrearToolTip(btPle, "Importar para el PLE");
            //Global.CrearToolTip(btPdb, "Importar para el PDB");
            LlenarCombos();
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<PublicidadE> oReporteV= null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Marque = String.Empty;
        string tipo = "buscar";

        #endregion

        #region Procedimientos de Usuario Llenar botones

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, listaLocales, "idLocal", "Nombre", false);
                    
        }

        #endregion

        #region Procedimientos de Usuario

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\PublicidadPendiente";
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

                PaginaInicioPublicidad ev = new PaginaInicioPublicidad();
                ev.Fec = dtpFec.Value.Date;
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(7);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.2f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f });

                Decimal Total1 = 0;
                Decimal Total2 = 0;




                foreach (PublicidadE item in oReporteV)
                {
                    
                    cell = new PdfPCell(new Paragraph(item.RUC, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Glosa, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.TipoCuenta, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(Convert.ToDateTime(item.Fecha).ToString("d"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Documento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Dolar.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Soles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    
                    TablaCabDetalle.CompleteRow();

                    Total1 = Total1 + item.Dolar;

                    Total2 = Total2 + item.Soles;

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

                cell = new PdfPCell(new Paragraph("-----------------------------------------------------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------------------------------------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
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

                cell = new PdfPCell(new Paragraph(Total1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Total2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
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
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                DateTime fec = dtpFec.Value.Date;
           

                lblProcesando.Text = "Obteniendo la Publicidad Pendiente...";
                oReporteV = AgenteContabilidad.Proxy.ListarReportePublicidad(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, fec);
                lblProcesando.Text = "Armando la Publicidad...";
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
                Global.MensajeComunicacion("Balance Exportado...");
            }
        }

        #endregion

        #region Eventos

        private void frmReportePublicidadPendiente_Load(object sender, EventArgs e)
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

        private void frmReportePublicidadPendiente_FormClosing(object sender, FormClosingEventArgs e)
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

        #region FormatoExcel Cabecera

        public override void Exportar()
        {
            try
            {
                if (oReporteV == null || oReporteV.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = cboSucursales.Text;
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + cboSucursales.Text;

                DateTime Fec = dtpFec.Value.Date;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Compras Varias" + NombreLocal + "-", "Archivos Excel (*.xlsx)|*.xlsx");

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
            DateTime fEC = dtpFec.Value.Date;



            TituloGeneral = " Publicidad Pendiente " + " Con Fecha " + fEC.Day;
            NombrePestaña = " Publicidad Pendiente ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 7;

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
                    oHoja.Cells[InicioLinea, 1].Value = " Code ";

                    oHoja.Cells[InicioLinea, 2].Value = " Concepto ";

                    oHoja.Cells[InicioLinea, 3].Value = " Source ";

                    oHoja.Cells[InicioLinea, 4].Value = " Fecha ";

                    oHoja.Cells[InicioLinea, 5].Value = " Factura ";
                    
                    oHoja.Cells[InicioLinea, 6].Value = " Amount Doc ";

                    oHoja.Cells[InicioLinea, 7].Value = " Amount Loc ";

                    

                    for (int i = 1; i <= 7; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    


                    #endregion

                  

                    #endregion

        #region Formato Excel Cuerpo

                    Decimal TotalS = 0;
                    Decimal TotalD = 0;

                    foreach (PublicidadE item in oReporteV)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.RUC;
                        oHoja.Cells[InicioLinea, 2].Value = item.Glosa;
                        oHoja.Cells[InicioLinea, 3].Value = item.TipoCuenta;
                        oHoja.Cells[InicioLinea, 4].Value = item.Fecha;
                        oHoja.Cells[InicioLinea, 5].Value = item.Documento;
                        oHoja.Cells[InicioLinea, 6].Value = item.Dolar;
                        oHoja.Cells[InicioLinea, 7].Value = item.Soles;

                        TotalD = TotalS + item.Dolar;
                      
                        TotalS = TotalD + item.Soles;

                        // FORMAT 
                        oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 5].Value = "TOTALES";
                    oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    oHoja.Cells[InicioLinea, 6].Value = TotalD;
                    oHoja.Cells[InicioLinea, 7].Value = TotalS;
                    oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

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


class PaginaInicioPublicidad : PdfPageEventHelper
{
    public DateTime Fec { get; set; }



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



        TituloGeneral = "Publicidad Pendiente Del Mes " + FechasHelper.NombreMes(Fec.Month).ToUpper() + " " + Fec.Year;



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

        PdfPTable TablaCabDetalle = new PdfPTable(7);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.2f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f });

        #region Primera Linea

        cell = new PdfPCell(new Paragraph("CODE", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("CONCEPTO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("SOURCE ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("FECHA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("FACTURA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("AMOUNT DOC", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("AMOUNT LOC", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);
          


        TablaCabDetalle.CompleteRow();

        #endregion
                        
        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}
#endregion