using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteConsistenciaVoucher : FrmMantenimientoBase
    {

        public frmReporteConsistenciaVoucher()
        {
            InitializeComponent();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<ConsistenciaVoucherE> oListaReporte;
        string tipo;
        string RutaGeneral = "";
        string tipoAccion;
        int TotalColumnasDetalle = 12;
        int TotalColumnasResumen = 6;

        int WidthTablaDetalle = 100;
        int WidthTablaResumen = 80;

        float[] float_detalle = new float[] { 0.05f, 0.04f, 0.04f, 0.04f, 0.10f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f, 0.6f };
        float[] float_resumen = new float[] { 0.10f, 0.75f, 0.2f , 0.15f, 0.15f, 0.15f };

        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        #region Procedimientos de Usuario

        void ConvertirApdf()
        {
            Document docPdf = new Document((rdbCruze.Checked ? PageSize.A4 : PageSize.A4.Rotate()), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\ConsistenciaVoucher ";
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

                // -----------------------------------------------
                // Para la creacion del archivo pdf
                // -----------------------------------------------

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

                PaginaCabeceraReporteConsistenciaVoucher ev = new PaginaCabeceraReporteConsistenciaVoucher();

                //Parametros Que Pasaras Al PDF
                ev.tamano_cabecera = (tipoAccion == "detalle" ? float_detalle : float_resumen);
                ev.TotalColumnas = (tipoAccion == "detalle" ? TotalColumnasDetalle : TotalColumnasResumen);
                ev.WidthTabla = (tipoAccion == "detalle" ? WidthTablaDetalle : WidthTablaResumen);
                ev.Tipo_Reporte = tipoAccion;
                ev.desde = txtDesde.Value;
                ev.hasta = txtHasta.Value;

                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable tablacabdetalle = new PdfPTable((tipoAccion == "detalle" ? TotalColumnasDetalle : TotalColumnasResumen));
                tablacabdetalle.WidthPercentage = (tipoAccion == "detalle" ? WidthTablaDetalle : WidthTablaResumen); ;
                tablacabdetalle.SetWidths((tipoAccion == "detalle" ? float_detalle : float_resumen));

                foreach (ConsistenciaVoucherE item in oListaReporte)
                {
                    if (rdbDetalle.Checked)
                    {
                        cell = PdfPCell(item.AnioPeriodo, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.MesPeriodo, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.idComprobante, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.numFile, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.numVoucher, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.D_imp_Soles.ToString("N2"), 6f, "right", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.D_imp_Dolares.ToString("N2"), 6f, "right", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.H_imp_Soles.ToString("N2"), 6f, "right", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.H_imp_Dolares.ToString("N2"), 6f, "right", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell((item.D_imp_Soles - item.H_imp_Soles).ToString("N2"), 6f, "right", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell((item.D_imp_Dolares - item.H_imp_Dolares).ToString("N2"), 6f, "right", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.GlosaGeneral, 6f, "left", "");
                        tablacabdetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = PdfPCell(item.codCuentaDestino, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.desCuenta, 6f, "left", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.Diferencia.ToString("N2"), 6f, "right", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.numVoucher, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.idComprobante, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);

                        cell = PdfPCell(item.numFile, 6f, "center", "");
                        tablacabdetalle.AddCell(cell);
                    }

                    tablacabdetalle.CompleteRow();
                }

                docPdf.Add(tablacabdetalle); //Añadiendo la tabla al documento PDF

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

        PdfPCell PdfPCell(string texto, float tamano_letra, string align, string negrita)
        {
            return new PdfPCell(new Paragraph(texto, FontFactory.GetFont("Arial", tamano_letra, (negrita == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)))) { Border = 0, HorizontalAlignment = (align == "center" ? Element.ALIGN_CENTER : (align == "left" ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = " Reporte Consistencia ";
            NombrePestaña = " Reporte Consistencia ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    //Int32 TotColumnas = 10;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, (tipoAccion == "detalle" ? TotalColumnasDetalle : TotalColumnasResumen)])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, (tipoAccion == "detalle" ? TotalColumnasDetalle : TotalColumnasResumen)])
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
                    if (rdbDetalle.Checked)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = " Comprobante ";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 6].Value = " Total Cargo ";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, InicioLinea, 7])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }
                        oHoja.Cells[InicioLinea, 8].Value = " Total Abono";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, InicioLinea, 9])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }
                        oHoja.Cells[InicioLinea, 10].Value = " Diferencia";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 10, InicioLinea, 11])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 12].Value = " Observacion ";

                        for (int i = 1; i <= 12; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 1].Value = " Cuenta ";
                        oHoja.Cells[InicioLinea, 2].Value = " Descripción ";
                        oHoja.Cells[InicioLinea, 3].Value = " Diferencia";
                        oHoja.Cells[InicioLinea, 4].Value = " Num.Voucher";
                        oHoja.Cells[InicioLinea, 5].Value = " Comprobante";
                        oHoja.Cells[InicioLinea, 6].Value = " File";

                        for (int i = 1; i <= 6; i++)
                        {

                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region 2da linea Cabecera

                    // PRIMERA
                    if (rdbDetalle.Checked)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = " Año ";
                        oHoja.Cells[InicioLinea, 2].Value = " Mes ";
                        oHoja.Cells[InicioLinea, 3].Value = " Comp ";
                        oHoja.Cells[InicioLinea, 4].Value = " File ";
                        oHoja.Cells[InicioLinea, 5].Value = " Voucher ";
                        oHoja.Cells[InicioLinea, 6].Value = " S/. ";
                        oHoja.Cells[InicioLinea, 7].Value = " US$  ";
                        oHoja.Cells[InicioLinea, 8].Value = " S/. ";
                        oHoja.Cells[InicioLinea, 9].Value = " US$ ";
                        oHoja.Cells[InicioLinea, 10].Value = " S/. ";
                        oHoja.Cells[InicioLinea, 11].Value = " US$  ";

                        for (int i = 1; i <= 11; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    foreach (ConsistenciaVoucherE item in oListaReporte)
                    {
                        if (rdbDetalle.Checked)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.AnioPeriodo;
                            oHoja.Cells[InicioLinea, 2].Value = item.MesPeriodo;
                            oHoja.Cells[InicioLinea, 3].Value = item.idComprobante;
                            oHoja.Cells[InicioLinea, 4].Value = item.numFile;
                            oHoja.Cells[InicioLinea, 5].Value = item.numVoucher;
                            oHoja.Cells[InicioLinea, 6].Value = item.D_imp_Soles;
                            oHoja.Cells[InicioLinea, 7].Value = item.D_imp_Dolares;
                            oHoja.Cells[InicioLinea, 8].Value = item.H_imp_Soles;
                            oHoja.Cells[InicioLinea, 9].Value = item.H_imp_Dolares;
                            oHoja.Cells[InicioLinea, 10].Value = (item.D_imp_Soles - item.H_imp_Soles);
                            oHoja.Cells[InicioLinea, 11].Value = (item.D_imp_Dolares - item.H_imp_Dolares);
                            oHoja.Cells[InicioLinea, 12].Value = item.GlosaGeneral;

                            oHoja.Cells[InicioLinea, 6, InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.codCuentaDestino;
                            oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;
                            oHoja.Cells[InicioLinea, 3].Value = item.Diferencia;
                            oHoja.Cells[InicioLinea, 4].Value = item.numVoucher;
                            oHoja.Cells[InicioLinea, 5].Value = item.idComprobante;
                            oHoja.Cells[InicioLinea, 6].Value = item.numFile;

                            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                        }

                        InicioLinea++;
                    }

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, (tipoAccion == "detalle" ? TotalColumnasDetalle : TotalColumnasResumen)].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

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

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaReporte == null || oListaReporte.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = VariablesLocales.SesionLocal.NombreEmpresa;
                if (NombreLocal == "<<TODOS>>")
                {
                    NombreLocal = "-TODOS-";
                }
                else
                {
                    NombreLocal = "-" + VariablesLocales.SesionLocal.NombreEmpresa;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "ConsistenciaVoucher" + NombreLocal + "-", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    lblProcesando.Visible = true;
                    btBuscar.Enabled = true;
                    //Marque = "Importando los registros a Excel...";
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
                if (tipoAccion == "detalle")
                {
                    oListaReporte = AgenteContabilidad.Proxy.ConsistenciaVoucher(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                txtDesde.Value.Year.ToString(), txtHasta.Value.Year.ToString(),
                                                txtDesde.Value.Month.ToString("00"), txtHasta.Value.Month.ToString("00"));
                }
                else
                {
                    oListaReporte = AgenteContabilidad.Proxy.ConsistenciaVoucherDiferencia(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                   txtHasta.Value.Year.ToString(), txtHasta.Value.Month.ToString("00"));
                }

                if (oListaReporte != null && oListaReporte.Count >= 0)
                {

                    if (tipo == "pdf")
                    {
                        ConvertirApdf();
                    }
                    else
                    {
                        ExportarExcel(RutaGeneral);
                    }
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
            btBuscar.Enabled = true;
            panel1.Enabled = true;
            panel2.Enabled = true;

            if (oListaReporte == null || oListaReporte.Count == 0)
            {
                RutaGeneral = "";
                Global.MensajeComunicacion("No hay datos.");
            }

            if (!String.IsNullOrEmpty(RutaGeneral))
            {
                wbNavegador.Navigate(RutaGeneral);
                RutaGeneral = "";
            }

            _bw.CancelAsync();
            _bw.Dispose();

        }

        #endregion

        #region Eventos

        private void frmReporteCtaCtePendientes_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "pdf";
                if (rdbDetalle.Checked)
                    tipoAccion = "detalle";
                else
                    tipoAccion = "cruze";

                pbProgress.Visible = true;
                btBuscar.Enabled = false;
                panel1.Enabled = false;
                panel2.Enabled = false;


                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }

        private void rdbDetalle_CheckedChanged(object sender, EventArgs e)
        {
            lblDesde.Visible = true;
            txtDesde.Visible = true;
            lblhasta.Text = "Hasta: ";
        }

        private void rdbResumen_CheckedChanged(object sender, EventArgs e)
        {
            lblDesde.Visible = false;
            txtDesde.Visible = false;
            lblhasta.Text = "Mes/Año: ";
        } 

        #endregion

    }
}


class PaginaCabeceraReporteConsistenciaVoucher : PdfPageEventHelper
{
    public float[] tamano_cabecera  { get; set; }
    public int TotalColumnas        { get; set; }
    public int WidthTabla           { get; set; }
    public String Tipo_Reporte      { get; set; }

    public DateTime desde           { get; set; }
    public DateTime hasta        { get; set; }
    

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

        TituloGeneral = "CONSISTENCIA DE COMPROBANTES" ;

        SubTitulo = "Del " + desde.ToString("dd/MM/yyyy") + " al " + hasta.ToString("dd/MM/yyyy");

        if(Tipo_Reporte!="detalle")
            SubTitulo = " A " + FechasHelper.NombreMes(hasta.Month) + " del " + hasta.Year.ToString();


        // ======================================
        // Cabecera del Reporte
        // ======================================

        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.9f, 0.15f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;


        #region Cabacera Pagina

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha : " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);

        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC  " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };        
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Hora :   " + HoraActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Pag. :   " + writer.PageNumber, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada 

        #endregion


        #region Titulos Principales

        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 8, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);

        table.CompleteRow(); //Fila completada 

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF


        #region Cabecera del Detalle


        // ====================
        // TABLA CABECERA
        // ====================

        PdfPTable TablaCabDetalle = new PdfPTable(this.TotalColumnas);
        TablaCabDetalle.WidthPercentage = this.WidthTabla;
        TablaCabDetalle.SetWidths(this.tamano_cabecera);

        #region Primera Linea

        if (Tipo_Reporte == "detalle")
        {
            cell = new PdfPCell(new Paragraph("Comprobante", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 5;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Total Cargo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Total Abono", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Diferencia", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Observacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);


        }
        else
        {

            cell = new PdfPCell(new Paragraph("Cuenta", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Descripción", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Diferencia", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Num.Voucher", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Comprobante", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("File", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

        }

        TablaCabDetalle.CompleteRow();

        
        #endregion


        #region Segunda Linea

            if (Tipo_Reporte == "detalle")
            {

                cell = new PdfPCell(new Paragraph("Año", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Mes", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Comp", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("File", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Voucher", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("S/.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("US $", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("S/.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("US $", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("S/.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("US $", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();
            }


        

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}
