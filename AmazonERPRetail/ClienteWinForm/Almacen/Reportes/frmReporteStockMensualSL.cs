using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteStockMensualSL : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteStockMensualSL()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
            ImagenRuta();
            
        }

        #endregion

        #region Variables
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public String RutaImagen = @"C:\AmazonErp\Logo\";
        List<StockE> oReporteStockSL = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        //String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String Marque = String.Empty;
        string tipo = "buscar";
        Int32 Bloqueado = 0;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            /////MES////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboMes.DataSource = oDt;
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = VariablesLocales.FechaHoy.ToString("MM");

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Todos });
            ComboHelper.LlenarCombos(CboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");

            cboTipoAlmacen.DataSource = null;
            List<ParTabla> ListaOperacion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaOperacion.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaOperacion orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        private void ImagenRuta()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        private void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\StockMensualSL " + Aleatorio.ToString();
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio si existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            docPdf.AddCreationDate();
            docPdf.AddAuthor("AMAZONTIC SA");
            docPdf.AddCreator("AMAZONTIC SA");

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
                    Boolean CtrlTotal = true;

                    if (CtrlTotal)
                    {
                        Columnas = 9;
                        AnchosCol = new float[] { 0.011f, 0.09f, 0.05f, 0.014f, 0.011f, 0.011f, 0.011f, 0.015f, 0.015f };
                    }
                    else
                    {
                        Columnas = 7;
                        AnchosCol = new float[] { 0.011f, 0.09f, 0.05f, 0.014f, 0.011f, 0.011f, 0.011f };
                    }

                    oPdfw.PageEvent = new PaginaInicioStocksSL
                    {
                        Anio = Convert.ToString(cboAño.SelectedValue),
                        Mes = Convert.ToInt32(cboMes.SelectedValue),
                        RutaImagen = RutaImagen,
                        NomAlmacen = ((AlmacenE)CboAlmacen.SelectedItem).desAlmacen,
                        Block = Bloqueado,
                        FechaStock = Convert.ToDateTime(dtpFecha.Value),
                        totColumnas = Columnas,
                        AnchoCol = AnchosCol,
                        ControlTot = CtrlTotal
                    };

                    docPdf.Open();

                    #region Detalle

                    PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
                    {
                        WidthPercentage = 100
                    };

                    TablaCabDetalle.SetWidths(AnchosCol);

                    foreach (StockE item in oReporteStockSL)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f), 1, 1));//, "N", "N", 3.5f, 3.5f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f)));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f)));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedida, null, "N", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f), 1, 1));

                        if (CtrlTotal)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CostoUnitPromBase.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CostoUnitPromSecu.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2)); 
                        }

                        TablaCabDetalle.CompleteRow();
                    }

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
                }
            }
        }

        private void ExportarExcel(String Ruta)
        {
            string nombreMes = cboMes.Text;
            string TituloGeneral = "Stock a " + Anio + " - " + nombreMes;
            string NombrePestaña = "Stock a ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Boolean CtrlTotal = true;
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = CtrlTotal == true ? 9 : 7;

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
                    oHoja.Cells[InicioLinea, 1].Value = "CODIGO";
                    oHoja.Cells[InicioLinea, 2].Value = "DESCRIPCION";
                    oHoja.Cells[InicioLinea, 3].Value = "RAZON SOCIAL";
                    oHoja.Cells[InicioLinea, 4].Value = "CAN.STOCK";
                    oHoja.Cells[InicioLinea, 5].Value = "UNIDAD MED.";
                    oHoja.Cells[InicioLinea, 6].Value = "CONTENIDO";
                    oHoja.Cells[InicioLinea, 7].Value = "UNIDAD PRES.";

                    if (CtrlTotal)
                    {
                        oHoja.Cells[InicioLinea, 8].Value = " COST.UNIT.BASE ";
                        oHoja.Cells[InicioLinea, 9].Value = " COST.UNIT.SEC. ";
                    }

                    for (int i = 1; i <= TotColumnas; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle

                    foreach (StockE item in oReporteStockSL)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                        oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                        oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 4].Value = item.canStock;
                        oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 5].Value = item.nomUMedida;
                        oHoja.Cells[InicioLinea, 6].Value = item.Contenido;
                        oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 7].Value = item.nomUMedidaPres;
                        
                        if (CtrlTotal)
                        {
                            oHoja.Cells[InicioLinea, 8].Value = item.CostoUnitPromBase;
                            oHoja.Cells[InicioLinea, 9].Value = item.CostoUnitPromSecu;
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                        }
                        
                        InicioLinea++;
                    }

                    #endregion

                    //Linea
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

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
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SA";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Módulo de Almacen";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SA";

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
                if (oReporteStockSL == null || oReporteStockSL.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String Mes = cboMes.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Stock Mensuales Sin Lote" + "-" + VariablesLocales.SesionUsuario.Empresa.NombreComercial + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (tipo == "buscar")
                {
                    String Anio = Convert.ToString(cboAño.SelectedValue);
                    String Mes = Convert.ToString(cboMes.SelectedValue);
                    Int32 Almacen = Convert.ToInt32(CboAlmacen.SelectedValue);
                    int indfecha = chkFecha.Checked == true ? 1 : 0;
                    string Fecha = dtpFecha.Value.ToString("yyyyMMdd");

                    lblProcesando.Text = "Obteniendo el Reporte Stock Mensual...";
                    oReporteStockSL = AgenteAlmacen.Proxy.ListarReporteStockMensualSL(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Almacen, Anio, Mes, indfecha, Fecha);
                    lblProcesando.Text = "Armando el Reporte...";
                    ConvertirApdf();
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
                Global.MensajeComunicacion("Stock Mensual Exportado...");
            }
        }

        #endregion

        #region Eventos

        private void frmReporteStockMensualSL_Load(object sender, EventArgs e)
        {
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            CboAlmacen.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Ubicacion del Reporte
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void frmReporteStockMensualSL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_bw.IsBusy)
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

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked == true)
            {
                dtpFecha.Enabled = true;
                cboMes.Enabled = false;
                cboAño.Enabled = false;
            }
            else
            {
                cboMes.Enabled = true;
                cboAño.Enabled = true;
                dtpFecha.Enabled = false;
            }

            if (chkFecha.Checked == true)
            {
                Bloqueado = 1;
            }
            else
            {
                Bloqueado = 0;
            }
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoAlmacen.SelectedIndex == 0)
            {
                CboAlmacen.Enabled = false;
                CboAlmacen.SelectedIndex = 0;
            }
            else
            {
                CboAlmacen.Enabled = true;
                CboAlmacen.DataSource = null;
                Int32 tipalm = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
                List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipalm);
                oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Todos });
                ComboHelper.LlenarCombos<AlmacenE>(CboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
            }
        }

        #endregion

    }
}

#region Pdf Inicio

class PaginaInicioStocksSL : PdfPageEventHelper
{
    public String Anio { get; set; }
    public DateTime FechaStock { get; set; }
    public Int32 Mes { get; set; }
    public Int32 Block { get; set; }
    public String NombreMes { get; set; }
    public String NomAlmacen { get; set; }
    public String RutaImagen { get; set; }
    public Int32 totColumnas { get; set; }
    public float[] AnchoCol { get; set; }
    public Boolean ControlTot { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

        //Meses
        NombreMes = FechasHelper.NombreMes(Mes).ToUpper();

        //Titulos Principales
        TituloGeneral = "STOCK DE ARTICULOS " + NomAlmacen;

        if (Block == 1)
        {
            SubTitulo = "Stock al : " + FechaStock.ToString("d");
        } 
        else
        {
            SubTitulo = "AÑO: " + Anio.ToUpper() + " - MES: " + NombreMes;
        }

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3)
        {
            WidthPercentage = 100
        };

        table.SetWidths(new float[] { 0.18f, 0.9f, 0.13f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Imagen

        PdfPCell CeldaImagen = null;

        if (!String.IsNullOrEmpty(RutaImagen))
        {
            CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 85f, 1, "S", 1));
        }
        else
        {
            CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
        }

        CeldaImagen.Rowspan = 3;
        CeldaImagen.PaddingBottom = 0f;
        table.AddCell(CeldaImagen); 

        #endregion

        #region Titulos Principales

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N"));//, 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));//, 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 1, 1));//, 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Hora:   " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));//, 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        table.AddCell(ReaderHelper.NuevaCelda("Pag.    " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, -1, "S3"));
        table.CompleteRow(); //Fila completada

        #endregion

        #region Subtitulos

        table.AddCell(ReaderHelper.NuevaCelda("Razón Social: " + VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), -1, -1, "S3"));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RUC:     " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), -1, -1, "S3"));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("Direccción: " + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), -1, -1, "S3"));
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f), -1, -1, "S3"));
        table.CompleteRow(); //Fila completada

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(totColumnas)
        {
            WidthPercentage = 100
        };

        TablaCabDetalle.SetWidths(AnchoCol);

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RAZON SOCIAL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CAN.STOCK", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNI.MED.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONTE.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNI.PRES.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));

        if (ControlTot)
        {
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COST.UNIT.BASE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COST.UNIT.SEC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 3.5f, 3.5f));
        }

        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

    }

}

#endregion