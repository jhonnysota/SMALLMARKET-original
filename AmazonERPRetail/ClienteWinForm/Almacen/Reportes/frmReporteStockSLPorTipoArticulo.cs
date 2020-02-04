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
using ClienteWinForm;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteStockSLPorTipoArticulo : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteStockSLPorTipoArticulo()
        {
   
                this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

                InitializeComponent();
                LlenarCombos();
                BuscarImagen();            
          
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public String RutaImagen = @"C:\AmazonErp\Logo\";
        List<AlmacenArticuloLoteE> oReporteStockSL = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String Marque = String.Empty;
        string tipo = "buscar";
        Int32 Bloqueado = 0;
       
        int idAlmacen = 0;

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


            cboTipoArticulo.DataSource = null;
            List<ParTabla> oListaTipoUnidad = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos };
            oListaTipoUnidad.Add(p);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in oListaTipoUnidad orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
            oListaTipoUnidad = null;

        }

        private void BuscarImagen()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        #endregion

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\STOCKMENSUALSLPORTIPOARTICULO " + Aleatorio.ToString();
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

                Int32 contador = 0;
                List<AlmacenArticuloLoteE> oReporteStockSLGroupBy = new List<AlmacenArticuloLoteE>();

                foreach (AlmacenArticuloLoteE item in oReporteStockSL)
                {
                  
                    if (idAlmacen != item.idAlmacen || contador == 0)
                    {
                        oReporteStockSLGroupBy.Add(item);
                    }
                    contador++;
                    idAlmacen = item.idAlmacen;
                }

                float[] colFloat = new float[3 + oReporteStockSLGroupBy.Count()];
                int CantCol = 3 + oReporteStockSLGroupBy.Count();

                for (int i = 0; i < CantCol; i++)
                {
                    if (i == 0)
                        colFloat[i] = 0.032f;
                    if (i == 1)
                        colFloat[i] = 0.40f;
                    if (i == 2)
                        colFloat[i] = 0.045f;
                    if (i >= 3)
                        colFloat[i] = 0.055f;
                }

                PaginaInicioStocksSLPorTipoArticulo ev = new PaginaInicioStocksSLPorTipoArticulo();
                ev.Anio = Convert.ToString(cboAño.SelectedValue);
                ev.Mes = Convert.ToInt32(cboMes.SelectedValue);
                ev.RutaImagen = RutaImagen;
                ev.NomAlmacen = ((ParTabla)cboTipoArticulo.SelectedItem).Descripcion;
                ev.Block = Bloqueado;
                ev.FechaStock = Convert.ToDateTime(dtpFecha.Value);
                ev.colFloat = colFloat;
                ev.CantCol = CantCol;
                ev.oReporteStockSLGroupBy_ = oReporteStockSLGroupBy;
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                // ===========
                // COLUMNAS
                // ===========

                PdfPTable TablaCabDetalle = new PdfPTable(CantCol)
                {
                    WidthPercentage = 100
                };                
                TablaCabDetalle.SetWidths(colFloat);

                // ===========
                // 
                // ===========

                int Count_Lineas = 0;
                String codArticulo = "";
                decimal CargaInicial = 0;
                decimal CantEntrada = 0;
                int idalm = 0;
                int Almacen = 0;

                // ===========
                // DETALLE
                // ===========

                List<AlmacenArticuloLoteE> oReporteStockSLPorArticulo = oReporteStockSL.GroupBy(y => y.idArticulo).Select(g => g.First()).OrderBy(x => x.desArticulo).ToList();

                foreach (AlmacenArticuloLoteE item in oReporteStockSLPorArticulo)
                {                    
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.5f), 5, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.5f), 5, 0));        

                    // Carga Inicial

                    CargaInicial = oReporteStockSL.Where(x => x.codArticulo == item.codArticulo).Sum(x => x.canStock);
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CargaInicial.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.5f), 5, 2));

                    // ===========
                    // FOR - MESES
                    // ===========
                    for (int i = 0; i < oReporteStockSLGroupBy.Count; i++)
                    {
                        Almacen = Convert.ToInt32(oReporteStockSLGroupBy[i].idAlmacen);
                        CantEntrada = 0;
                        // ===========
                        // FOR - FECHAS
                        // ===========
                        for (int itm = 0; itm < oReporteStockSL.Count; itm++)
                        {
                            if (oReporteStockSL[itm].codArticulo != null)
                            {
                                idalm = oReporteStockSL[itm].idAlmacen;

                                if (idalm == Almacen &&
                                        item.codArticulo == oReporteStockSL[itm].codArticulo)
                                {
                                    CantEntrada += oReporteStockSL[itm].canStock;
                                }
                            }
                        }
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CantEntrada.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.5f), 5, 2));


                    }

                    Count_Lineas++;
                    TablaCabDetalle.CompleteRow();
                    codArticulo = item.codArticulo;

                }
                // ==============
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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String nombreMes = cboMes.Text;

            TituloGeneral = " Stock Mensual Por Tipo Articulo a " + Anio + " - " + nombreMes;
            NombrePestaña = " Stock Mensual Por Tipo Articulo a " + Anio + " - " + nombreMes;

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
               
                    List<AlmacenArticuloLoteE> oReporteStockSLGroupBy = new List<AlmacenArticuloLoteE>();
                    Int32 contador = 0;

                    foreach (AlmacenArticuloLoteE item in oReporteStockSL)
                    {

                        if (idAlmacen != item.idAlmacen || contador == 0)
                        {
                            oReporteStockSLGroupBy.Add(item);
                        }
                        contador++;
                        idAlmacen = item.idAlmacen;
                    }

                    float[] colFloat = new float[3 + oReporteStockSLGroupBy.Count()];
                    int CantCol = 3 + oReporteStockSLGroupBy.Count();
                    Int32 TotColumnas = 3 + oReporteStockSLGroupBy.Count();
                    for (int i = 0; i < CantCol; i++)
                    {
                        if (i == 0)
                            colFloat[i] = 0.032f;
                        if (i == 1)
                            colFloat[i] = 0.40f;
                        if (i == 2)
                            colFloat[i] = 0.045f;
                        if (i >= 3)
                            colFloat[i] = 0.055f;
                    }

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
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

                    Int32 ColumnaAlmacen = 4;
                    BaseColor ColorDet = new BaseColor(170, 181, 191);
                    //PRIMERA

                    oHoja.Cells[InicioLinea, 1].Value = "Código";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 1])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 2].Value = "Descripción";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 3].Value = "Stock";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 3])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    
                    for (int i = 0; i < oReporteStockSLGroupBy.Count; i++)
                    {

                        oHoja.Cells[InicioLinea, i + ColumnaAlmacen].Value = oReporteStockSLGroupBy[i].desAlmacen;


                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, i + ColumnaAlmacen, InicioLinea, i + ColumnaAlmacen])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                        }
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Detalle

                  
                    String codArticulo = "";
                    decimal CargaInicial = 0;
                    decimal CantEntrada = 0;
                    int idalm = 0;
                    int Almacen = 0;


                    // ============
                    // GROUP BY ART
                    // ============

                    //List<AlmacenArticuloLoteE> oReporteStockSLPorArticulo = oReporteStockSL.GroupBy(x => x.codArticulo).ToList;
                    List<AlmacenArticuloLoteE> oReporteStockSLPorArticulo = oReporteStockSL.GroupBy(y => y.idArticulo).Select(g => g.First()).OrderBy(x => x.desArticulo).ToList();

                    foreach (AlmacenArticuloLoteE item in oReporteStockSLPorArticulo)
                    {
                        int Count_Lineas = 4;
                        // Carga Inicial

                        oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                        oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;

                        CargaInicial = oReporteStockSL.Where(x => x.codArticulo == item.codArticulo).Sum(x => x.canStock);
                     
                        oHoja.Cells[InicioLinea, 3].Value = CargaInicial;
                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        // ===========
                        // FOR - MESES
                        // ===========
                        for (int i = 0; i < oReporteStockSLGroupBy.Count; i++)
                        {
                            Almacen = Convert.ToInt32(oReporteStockSLGroupBy[i].idAlmacen);
                            CantEntrada = 0;
                           
                            // ===========
                            // FOR - FECHAS
                            // ===========
                            for (int itm = 0; itm < oReporteStockSL.Count; itm++)
                            {
                                if (oReporteStockSL[itm].codArticulo != null)
                                {
                                    idalm = oReporteStockSL[itm].idAlmacen;

                                    if (idalm == Almacen &&
                                            item.codArticulo == oReporteStockSL[itm].codArticulo)
                                    {
                                        CantEntrada += oReporteStockSL[itm].canStock;
                                    }
                                }
                            }
                            oHoja.Cells[InicioLinea, Count_Lineas].Value = CantEntrada;
                            oHoja.Cells[InicioLinea, Count_Lineas].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, Count_Lineas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            Count_Lineas++;
                        }                       
                        InicioLinea++;
                        codArticulo = item.codArticulo;

                    }
                    
                    #endregion

                    //Linea
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

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
                    oHoja.Workbook.Properties.Category = "Modulo de Almacen";
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
                    Int32 Almacen = Convert.ToInt32(cboTipoArticulo.SelectedValue);
                    Int32 indfecha = 0;

                    if (chkFecha.Checked)
                    {
                        indfecha = 1;
                    }
                    else
                    {
                        indfecha = 0;
                    }

                    string Fecha = dtpFecha.Value.ToString("yyyyMMdd");

                    lblProcesando.Text = "Obteniendo el Reporte Stock Mensual...";
                    oReporteStockSL = AgenteAlmacen.Proxy.ListarReporteStockSLPorTipoArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Almacen, Anio, Mes, indfecha, Fecha);
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

        private void frmReporteStockSLPorTipoArticulo_Load(object sender, EventArgs e)
        {
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

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

        private void frmReporteStockSLPorTipoArticulo_FormClosing(object sender, FormClosingEventArgs e)
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

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        }

        #endregion}

    }
}


#region Pdf Inicio

class PaginaInicioStocksSLPorTipoArticulo : PdfPageEventHelper
{

    public String Anio { get; set; }
    public DateTime FechaStock { get; set; }
    public Int32 Mes { get; set; }
    public Int32 Block { get; set; }
    public String NombreMes { get; set; }
    public String NomAlmacen { get; set; }
    public String RutaImagen { get; set; }
    public List<AlmacenArticuloLoteE> oReporteStockSLGroupBy_;
    public float[] colFloat;
    public int CantCol;
    Int32 CorrelativoAlmacen = 0;

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        BaseColor ColorDet = new BaseColor(170, 181, 191);
        //Meses
        NombreMes = FechasHelper.NombreMes(Mes).ToUpper();

        //Titulos Principales
        TituloGeneral = "STOCK POR TIPO ARTICULO " + NomAlmacen;

        if (Block == 1)
        {
            SubTitulo = "Stock al : " + FechaStock.ToString("d");
        }
        else
        {
            SubTitulo = "AÑO: " + Anio.ToUpper() + " - MES: " + NombreMes;
        }


        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
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

        // =============
        // COLUMNAS
        // =============
        PdfPTable TablaGeneral = new PdfPTable(CantCol)
        {
            WidthPercentage = 100
        };
        TablaGeneral.SetWidths(colFloat);

        // =============
        // PRIMER LINEA
        // =============
        #region Primera Linea
        
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Código", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Stock", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

        // ==========
        // FOR - MESES
        // ==========
        for (int i = 0; i < oReporteStockSLGroupBy_.Count; i++)
        {
            String NomAlmacen = oReporteStockSLGroupBy_[i].desAlmacen;

            TablaGeneral.AddCell(ReaderHelper.NuevaCelda(NomAlmacen , ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            CorrelativoAlmacen++;
        }

        TablaGeneral.CompleteRow();

        #endregion

        // ============
        // END DOCUMENT
        // ============
        document.Add(TablaGeneral); //Añadiendo la tabla al documento PDF

        #endregion

    }

}

#endregion