using Entidades.Almacen;
using Entidades.Generales;
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

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteListarTransferencia : FrmMantenimientoBase
    {

        public frmReporteListarTransferencia()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        readonly BackgroundWorker _bw = new BackgroundWorker();
        List<kardexE> ReporteTransf = null;
        String RutaGeneral = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Tipo de Articulos
            List<ParTabla> ListaTipos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaTipos.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboAlmacen, (from x in ListaTipos orderby x.IdParTabla select x).ToList());
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\StockMensual " + Aleatorio.ToString();
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

                    Int32 Columnas = 0;
                    float[] AnchosCol = null;
                    BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo

                    Columnas = 20;
                    AnchosCol = new float[] { 0.02f, 0.02f, 0.01f, 0.01f, 0.02f, 0.01f, 0.01f, 0.01f, 0.02f, 0.05f, 0.025f, 0.025f, 0.025f, 0.01f, 0.01f, 0.02f, 0.025f, 0.025f, 0.025f, 0.025f };

                    oPdfw.PageEvent = new PaginaIniTranf
                    {
                        totColumnas = Columnas,
                        AnchoCol = AnchosCol
                    };

                    docPdf.Open();

                    #region Detalle

                    PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
                    {
                        WidthPercentage = 100
                    };

                    TablaCabDetalle.SetWidths(AnchosCol);

                    Decimal Total1 = 0;
                    Decimal Total2 = 0;
                    Decimal TotalDiferencia = 0;

                    foreach (kardexE item in ReporteTransf)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecProceso.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.AlmacenOrigen, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.serDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoAlmacen.ToString(), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.NumItemOrg, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idArticulo.ToString(), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.LoteOrg, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DesArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, null),-1,-1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CantidadOrg, null, "N", null, FontFactory.GetFont("Arial", 5f, null),-1,2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ImpCostoPromUnitarioBaseOrg.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, null),-1,2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, null),-1,2));
                        Total1 += item.Total;
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.AlmacenDestino, null, "N", null, FontFactory.GetFont("Arial", 5f,  null), -1,-1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.NumItemDst, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.LoteDst, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CantidadDst, null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ImpCostoPromUnitarioBaseDst.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalIngreso.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                        Total2 += item.TotalIngreso;
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Diferencia.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                        TotalDiferencia += item.Diferencia;

                        TablaCabDetalle.CompleteRow();
                    }

                    #endregion

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1, "S12"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("_________________", null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1, "S5"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("_________________", null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("_________________", null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                    TablaCabDetalle.CompleteRow();

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1,"S12"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Total1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, -1, "S5"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Total2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalDiferencia.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, null), -1, 2));

                    TablaCabDetalle.CompleteRow();

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF


                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                }
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = " TRANFERENCIAS ENTRE ALMACENES ";
            NombrePestaña = " Reporte Transf. ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 20;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(81, 175, 92));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(81, 175, 92));
                    }

                    #endregion Titulos Principales

                    #region Cabeceras del Detalle


                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "FECHA PROCESO";
                    oHoja.Cells[InicioLinea, 2].Value = "ALMACEN ORIGEN";
                    oHoja.Cells[InicioLinea, 3].Value = "ID DOCUMENTO";
                    oHoja.Cells[InicioLinea, 4].Value = "SERIE DOCUMENTO";
                    oHoja.Cells[InicioLinea, 5].Value = "NUM. DOCUMENTO";
                    oHoja.Cells[InicioLinea, 6].Value = "DOCUMENTO ALMACEN";
                    oHoja.Cells[InicioLinea, 7].Value = "NUM ITEM ORIGEN";
                    oHoja.Cells[InicioLinea, 8].Value = "ID ARTICULO";
                    oHoja.Cells[InicioLinea, 9].Value = "LOTE ORIGEN";
                    oHoja.Cells[InicioLinea, 10].Value = "DESCRIPCION ARTICULO";
                    oHoja.Cells[InicioLinea, 11].Value = "CANTIDAD ORIGEN";
                    oHoja.Cells[InicioLinea, 12].Value = "IMP. COSTO ORIGEN";
                    oHoja.Cells[InicioLinea, 13].Value = "TOTAL ORIGEN";
                    oHoja.Cells[InicioLinea, 14].Value = "ALMACEN DESTINO";
                    oHoja.Cells[InicioLinea, 15].Value = "NUM ITEM DESTINO";
                    oHoja.Cells[InicioLinea, 16].Value = "LOTE DESTINO";
                    oHoja.Cells[InicioLinea, 17].Value = "CANTIDAD DESTINO";
                    oHoja.Cells[InicioLinea, 18].Value = "IMP. COSTO DESTINO";
                    oHoja.Cells[InicioLinea, 19].Value = "TOTAL";
                    oHoja.Cells[InicioLinea, 20].Value = "DIFERENCIA";


                    for (int i = 1; i <= TotColumnas; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle

                    Decimal Total1 = 0;
                    Decimal Total2 = 0;
                    Decimal TotalDiferencia = 0;

                    foreach (kardexE item in ReporteTransf)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.fecProceso;
                        oHoja.Cells[InicioLinea, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[InicioLinea, 2].Value = item.AlmacenOrigen;
                        oHoja.Cells[InicioLinea, 3].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 4].Value = item.serDocumento;
                        oHoja.Cells[InicioLinea, 5].Value = item.numDocumento;
                        oHoja.Cells[InicioLinea, 6].Value = item.idDocumentoAlmacen;
                        oHoja.Cells[InicioLinea, 7].Value = item.NumItemOrg;
                        oHoja.Cells[InicioLinea, 8].Value = item.idArticulo;
                        oHoja.Cells[InicioLinea, 9].Value = item.LoteOrg;
                        oHoja.Cells[InicioLinea, 10].Value = item.DesArticulo;
                        oHoja.Cells[InicioLinea, 11].Value = item.CantidadOrg;
                        oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 12].Value = item.ImpCostoPromUnitarioBaseOrg;
                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.000";
                        oHoja.Cells[InicioLinea, 13].Value = item.Total;
                        Total1 += item.Total;
                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.000";
                        oHoja.Cells[InicioLinea, 14].Value = item.AlmacenDestino;
                        oHoja.Cells[InicioLinea, 15].Value = item.NumItemDst;
                        oHoja.Cells[InicioLinea, 16].Value = item.LoteDst;
                        oHoja.Cells[InicioLinea, 17].Value = item.CantidadDst;
                        oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 18].Value = item.ImpCostoPromUnitarioBaseDst;
                        oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 19].Value = item.TotalIngreso;
                        oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                        Total2 += item.TotalIngreso;
                        oHoja.Cells[InicioLinea, 20].Value = item.Diferencia;
                        oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                        TotalDiferencia += item.Diferencia;


                        InicioLinea++;
                    }
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 13].Value = Total1;
                    oHoja.Cells[InicioLinea, 19].Value = Total2;
                    oHoja.Cells[InicioLinea, 20].Value = TotalDiferencia;

                    oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";

                    InicioLinea++;

                    #endregion

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
                    oHoja.Workbook.Properties.Category = "Modulo de Almacén";
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

        #region Eventos Heredados

        public override void Buscar()
        {
            Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            lblProcesando.Text = "Obteniendo Las Tranferencias...";
            ReporteTransf = AgenteAlmacen.Proxy.ListarTransferencia(idEmpresa, Convert.ToInt32(cboAlmacen.SelectedValue), dtpInicio.Value.ToString("yyyyMMdd"), dtpFinal.Value.ToString("yyyyMMdd"));
            lblProcesando.Text = "Armando el Reporte...";

            if (ReporteTransf.Count > 0)
            {
                ConvertirApdf();
            }
            else
            {
                Global.MensajeComunicacion("No hay información con el Tipo de Articulo escogido.");
            }
        }

        public override void Exportar()
        {
            try
            {
                if (ReporteTransf == null || ReporteTransf.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreArchivo = "TRANFERENCIAS ENTRE ALMACENES ";
                NombreArchivo = NombreArchivo.Replace("<<", "-").Replace(">>", "-");
                String RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrWhiteSpace(RutaExcel))
                {
                    ExportarExcel(RutaExcel);
                    Global.MensajeComunicacion("Información exportada");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Buscar();
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
            //panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                ////Mostrando el reporte en un web browser
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteListarTransferencia_Load(object sender, EventArgs e)
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

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
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

        #endregion

    }

    #region Pdf Inicio

    class PaginaIniTranf : PdfPageEventHelper
    {

        
        public Int32 totColumnas { get; set; }
        public float[] AnchoCol { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {

            base.OnStartPage(writer, document);

            String NombreMes = String.Empty;
            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro

            //Nombre del Mes

            TituloGeneral = " TRANFERENCIAS ENTRE ALMACENES ";


            SubTitulo = " ";



            //Cabecera del Reporte
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.9f, 0.1f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            #region Titulos Principales

            table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD), 5, 1));
            table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 6, 0));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD), 1, 1));
            table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
            table.AddCell(ReaderHelper.NuevaCelda("Pag.    " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
            table.CompleteRow(); //Fila completada 

            #endregion

            #region Subtitulos

            table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2"));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda("RUC:  " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2"));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2"));
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f), -1, -1, "S2"));
            table.CompleteRow(); //Fila completada

            #endregion

            document.Add(table); //Añadiendo la tabla al documento PDF

            #region Cabecera del Detalle

            PdfPTable TablaCabDetalle = null;


            TablaCabDetalle = new PdfPTable(totColumnas)
            {
                WidthPercentage = 100
            };

            TablaCabDetalle.SetWidths(AnchoCol);

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FEC. PROCESO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ALMACEN ORIGEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DOC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SER. DOC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUM. DOC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DOC. ALM.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ITEM ORG.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ID ART.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE ORG.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ARTICULO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANT. ORG.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IMP. COSTO ORG.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ALM. DST.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ITEM DST.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE DST.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANT. DST.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IMP. COSTO DST.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DIFERENCIA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

            TablaCabDetalle.CompleteRow();



            #endregion

            //Añadiendo la tabla al documento PDF
            document.Add(TablaCabDetalle);

        }
    }

    #endregion

}
