using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
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
using Entidades.Almacen;
using ClienteWinForm;
using Entidades.Generales;

#endregion

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteStockMensual : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteStockMensual()
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
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public String RutaImagen = @"C:\AmazonErp\Logo\";
        List<StockE> oReporteStock = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        string tipo = "buscar";
        String TipoReporte = "1";
        String FormatoExcel = "1";

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            /////MES////
            cboMes.DataSource = FechasHelper.CargarMesesContable("MA");
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
            ComboHelper.LlenarCombos(cboalmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");

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
                    //Boolean CtrlTotal = true;
                    BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo

                    if (TipoReporte == "1")
                    {
                        //if (CtrlTotal)
                        //{
                            Columnas = 14;
                            AnchosCol = new float[] { 0.04f, 0.160f, 0.039f, 0.039f, 0.039f, 0.039f, 0.039f, 0.025f, 0.025f, 0.025f, 0.1f, 0.039f, 0.05f, 0.05f};
                        //}
                        //else
                        //{
                        //    Columnas = 17;
                        //    AnchosCol = new float[] { 0.04f, 0.140f, 0.033f, 0.033f, 0.033f, 0.038f, 0.030f, 0.027f, 0.046f, 0.046f, 0.05f, 0.1f, 0.046f, 0.030f, 0.028f, 0.033f, 0.033f };
                        //}

                        oPdfw.PageEvent = new PaginaInicioStocks
                        {
                            Anio = Convert.ToString(cboAño.SelectedValue),
                            Mes = Convert.ToInt32(cboMes.SelectedValue),
                            TipoReport = TipoReporte,
                            IndFecha = chkFecha.Checked == true ? 1 : 0,
                            FechaStock = Convert.ToDateTime(dtpFecha.Value),
                            NombreAlmacen = (((AlmacenE)cboalmacen.SelectedItem).desAlmacen),
                            RutaImagen = RutaImagen,
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

                        foreach (StockE item in oReporteStock)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));//CODIGO
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)))); //DESCRIPCION
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStockUD.ToString("N"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStockUD < 0 ? ColorLetra : null)), -1, 2));//STOCKUD

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVenta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CostoUnitPromBase.ToString("N4"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CostoUnitPromSecu.ToString("N4"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE 

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedida, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));//UNIDADMED
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));//U.M.PRESE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null))));//RAZON SOCIAL
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.LoteProveedor, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null))));//LOTEPROVEEDOR
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecPrueba.Value.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));//FECHADEPRUEBA
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecProceso.Value.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));//FECHAPROCESO

                            TablaCabDetalle.CompleteRow();
                        }

                        #endregion

                        docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
                    }
                    //else if (TipoReporte == "2")
                    //{
                    //    if (CtrlTotal)
                    //    {
                    //        Columnas = 9;
                    //        AnchosCol = new float[] { 0.04f, 0.140f, 0.033f, 0.033f, 0.033f, 0.033f, 0.033f, 0.038f, 0.038f };
                    //    }
                    //    else
                    //    {
                    //        Columnas = 7;
                    //        AnchosCol = new float[] { 0.04f, 0.140f, 0.033f, 0.033f, 0.033f, 0.033f, 0.033f };
                    //    }

                    //    oPdfw.PageEvent = new PaginaInicioStocks
                    //    {
                    //        Anio = Convert.ToString(cboAño.SelectedValue),
                    //        Mes = Convert.ToInt32(cboMes.SelectedValue),
                    //        TipoReport = TipoReporte,
                    //        IndFecha = chkFecha.Checked == true ? 1 : 0,
                    //        FechaStock = Convert.ToDateTime(dtpFecha.Value),
                    //        NombreAlmacen = (((AlmacenE)cboalmacen.SelectedItem).desAlmacen),
                    //        RutaImagen = RutaImagen,
                    //        totColumnas = Columnas,
                    //        AnchoCol = AnchosCol
                    //    };

                    //    docPdf.Open();

                    //    #region Detalle

                    //    PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
                    //    {
                    //        WidthPercentage = 100
                    //    };

                    //    TablaCabDetalle.SetWidths(AnchosCol);

                    //    foreach (StockE item in oReporteStock)
                    //    {
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));//CODIGO
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)))); //DESCRIPCION
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1)); //LOTEALMACEN
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1)); //LOTEALMACEN
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1)); //LOTEALMACEN
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.LoteAlmacen, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1)); //LOTEALMACEN
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1)); //LOTEALMACEN
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStockUD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStockUD < 0 ? ColorLetra : null)), -1, 1)); //LOTEALMACEN
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CostoUnitPromBase.ToString("N4"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//COSTOSOLES
                    //        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CostoUnitPromSecu.ToString("N4"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//COSTODOLARES 

                    //        TablaCabDetalle.CompleteRow();
                    //    }

                    //    #endregion

                    //    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
                    //}

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
            string TituloGeneral = " Stock Al. " + Anio + " - " + nombreMes;
            string NombrePestaña = "Stock";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Boolean CtrlTotal = true;
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 0;

                    if (FormatoExcel == "1")
                    {
                        TotColumnas = 16;
                        //TotColumnas = 23;
                        //TotColumnas = CtrlTotal == true ? 23 : 20;
                    }
                    else if(FormatoExcel == "2")
                    {
                        TotColumnas = CtrlTotal == true ? 9 : 7;
                    }
                   
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

                    if (FormatoExcel == "1")
                    {
                        // PRIMERA
                        oHoja.Cells[InicioLinea, 1].Value = "CODIGO";
                        oHoja.Cells[InicioLinea, 2].Value = "NOMBRE";
                        oHoja.Cells[InicioLinea, 3].Value = "CAN.STOCK";
                        oHoja.Cells[InicioLinea, 4].Value = "CAN.STOCK UD";

                        if (CtrlTotal)
                        {
                            oHoja.Cells[InicioLinea, 5].Value = "VALOR VENTA";
                            oHoja.Cells[InicioLinea, 6].Value = "COSTO UNIT. SOLES";
                            oHoja.Cells[InicioLinea, 7].Value = "COSTO UNIT. DOLAR";
                            oHoja.Cells[InicioLinea, 8].Value = "COSTO TOTAL SOLES";
                            oHoja.Cells[InicioLinea, 9].Value = "COSTO TOTAL DOLAR";
                            oHoja.Cells[InicioLinea, 10].Value = "UNID. EMPAQUE";
                            oHoja.Cells[InicioLinea, 11].Value = "FRACCION";
                            oHoja.Cells[InicioLinea, 12].Value = "UNID. FRACCION";
                            oHoja.Cells[InicioLinea, 13].Value = "LABORATORIO";
                            oHoja.Cells[InicioLinea, 14].Value = "LOTE PROVEEDOR";
                            oHoja.Cells[InicioLinea, 15].Value = "FECHA DE VENCIMIENTO";
                            oHoja.Cells[InicioLinea, 16].Value = "FECHA DE PROCESO"; 
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 9].Value = "UNIDAD MED.";
                            oHoja.Cells[InicioLinea, 10].Value = "UNIDAD ENV.";
                            oHoja.Cells[InicioLinea, 11].Value = "CONTENIDO";
                            oHoja.Cells[InicioLinea, 12].Value = "UNIDAD PRES.";
                            oHoja.Cells[InicioLinea, 13].Value = "NOMBRE ORIGEN";
                            oHoja.Cells[InicioLinea, 14].Value = "NOMBRE PROCEDENCIA";
                            oHoja.Cells[InicioLinea, 15].Value = "RAZON SOCIAL";
                            oHoja.Cells[InicioLinea, 16].Value = "LOTE PROVEEDOR";
                            oHoja.Cells[InicioLinea, 17].Value = "BATCH";
                            oHoja.Cells[InicioLinea, 18].Value = "PORCENTAJE GERMINACION";
                            oHoja.Cells[InicioLinea, 19].Value = "FECHA DE PRUEBA";
                            oHoja.Cells[InicioLinea, 20].Value = "FECHA DE PROCESO";
                        }

                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }
                    }
                    else if (FormatoExcel == "2")
                    {
                        // PRIMERA
                        oHoja.Cells[InicioLinea, 1].Value = "CODIGO";
                        oHoja.Cells[InicioLinea, 2].Value = "DESCRIPCION";
                        oHoja.Cells[InicioLinea, 3].Value = "UNIDAD ENV.";
                        oHoja.Cells[InicioLinea, 4].Value = "CONTENIDO";
                        oHoja.Cells[InicioLinea, 5].Value = "UNIDAD PRES.";
                        oHoja.Cells[InicioLinea, 6].Value = "LOTE ALMACEN";
                        oHoja.Cells[InicioLinea, 7].Value = "CANTIDAD";

                        if (CtrlTotal)
                        {
                            oHoja.Cells[InicioLinea, 8].Value = "COSTO SOLES";
                            oHoja.Cells[InicioLinea, 9].Value = "COSTO DOLARES";
                        }

                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle

                    if (FormatoExcel == "1")
                    {
                        foreach (StockE item in oReporteStock)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                            oHoja.Cells[InicioLinea, 3].Value = item.canStock;
                            oHoja.Cells[InicioLinea, 4].Value = item.canStockUD;

                            if (CtrlTotal)
                            {
                                oHoja.Cells[InicioLinea, 5].Value = item.ValorVenta;
                                oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 6].Value = item.CostoUnitPromBase;
                                oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.0000";
                                oHoja.Cells[InicioLinea, 7].Value = item.CostoUnitPromSecu;
                                oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.0000";
                                oHoja.Cells[InicioLinea, 8].Value = item.CostoTotPromBase;
                                oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.0000";
                                oHoja.Cells[InicioLinea, 9].Value = item.CostoTotPromSecu;
                                oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.0000";
                                oHoja.Cells[InicioLinea, 10].Value = item.nomUMedida;
                                oHoja.Cells[InicioLinea, 11].Value = item.Contenido;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 12].Value = item.nomUMedidaEnv;
                                oHoja.Cells[InicioLinea, 13].Value = item.RazonSocial;
                                oHoja.Cells[InicioLinea, 14].Value = item.LoteProveedor;
                                oHoja.Cells[InicioLinea, 15].Value = item.fecPrueba;
                                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 16].Value = item.fecProceso;
                                oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "dd/MM/yyyy"; 
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 9].Value = item.nomUMedida;
                                oHoja.Cells[InicioLinea, 10].Value = item.nomUMedidaEnv;
                                oHoja.Cells[InicioLinea, 11].Value = item.Contenido;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 12].Value = item.nomUMedidaPres;
                                oHoja.Cells[InicioLinea, 13].Value = item.NombreOrigen;
                                oHoja.Cells[InicioLinea, 14].Value = item.NombreProcedencia;
                                oHoja.Cells[InicioLinea, 15].Value = item.RazonSocial;
                                oHoja.Cells[InicioLinea, 16].Value = item.LoteProveedor;
                                oHoja.Cells[InicioLinea, 17].Value = item.Batch;
                                oHoja.Cells[InicioLinea, 18].Value = item.PorcentajeGerminacion.Value;
                                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 19].Value = item.fecPrueba;
                                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 20].Value = item.fecProceso;
                                oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "dd/MM/yyyy";
                            }

                            InicioLinea++;
                        }
                    }
                    else if (FormatoExcel == "2")
                    {
                        foreach (StockE item in oReporteStock)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                            oHoja.Cells[InicioLinea, 3].Value = item.nomUMedidaEnv;
                            oHoja.Cells[InicioLinea, 4].Value = item.Contenido;
                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 5].Value = item.nomUMedidaPres;
                            oHoja.Cells[InicioLinea, 6].Value = item.LoteAlmacen;
                            oHoja.Cells[InicioLinea, 7].Value = item.canStock;
                            oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.0000";

                            if (CtrlTotal)
                            {
                                oHoja.Cells[InicioLinea, 8].Value = item.CostoUnitPromBase;
                                oHoja.Cells[InicioLinea, 9].Value = item.CostoUnitPromSecu;
                                oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.0000"; 
                            }

                            InicioLinea++;
                        }
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

        private void Exportar2()
        {
            try
            {
                if (oReporteStock == null || oReporteStock.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String Mes = cboMes.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Stock Mensuales" + "-" + VariablesLocales.SesionUsuario.Empresa.NombreComercial + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    FormatoExcel = "2";
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

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oReporteStock == null || oReporteStock.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String Mes = cboMes.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Stock Mensuales" + "-" + VariablesLocales.SesionUsuario.Empresa.NombreComercial + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    FormatoExcel = "1";
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
            if (tipo == "buscar")
            {
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String Mes = Convert.ToString(cboMes.SelectedValue);
                Int32 Almacen = Convert.ToInt32(cboalmacen.SelectedValue);
                int indfecha = chkFecha.Checked ? 1 : 0;
                string Fecha = dtpFecha.Value.ToString("yyyyMMdd");

                lblProcesando.Text = "Obteniendo el Reporte Stock Mensual...";
                oReporteStock = AgenteAlmacen.Proxy.ListarReporteStockMensual(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Almacen, Anio, Mes, indfecha, Fecha);

                if (TipoReporte == "2")
                {
                    List<StockE> oReporteStockAgrupado =
                         (
                           from x in oReporteStock
                           where (x.canStock != Variables.Cero)
                           group x by new { x.codArticulo, x.LoteAlmacen, x.Nombre, x.CostoUnitPromBase, x.CostoUnitPromSecu, x.nomUMedidaEnv, x.nomUMedidaPres, x.Contenido }
                           into g
                           select new StockE()
                           {
                               codArticulo = g.Key.codArticulo,
                               LoteAlmacen = g.Key.LoteAlmacen,
                               Nombre = g.Key.Nombre,
                               nomUMedidaEnv = g.Key.nomUMedidaEnv,
                               nomUMedidaPres = g.Key.nomUMedidaPres,
                               Contenido = g.Key.Contenido,
                               CostoUnitPromBase = g.Key.CostoUnitPromBase,
                               CostoUnitPromSecu = g.Key.CostoUnitPromSecu,
                               canStock = g.Sum(x => x.canStock)
                           }
                         ).ToList();

                    oReporteStock = oReporteStockAgrupado.OrderBy(x => x.LoteAlmacen).ToList();
                }

                lblProcesando.Text = "Armando el Reporte...";
                ConvertirApdf();
            }
            else
            {
                if (FormatoExcel == "1")
                {
                    ExportarExcel(RutaGeneral);
                }
                else if(FormatoExcel == "2")
                {
                    ExportarExcel(RutaGeneral);
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

        private void frmReporteStockMensual_Load(object sender, EventArgs e)
        {
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            cboalmacen.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Ubicacion del Reporte
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void frmReporteStockMensual_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            //cmsPDF.Show(btBuscar, new Point(0, btExportar.Height));
            try
            {
                tipo = "buscar";
                TipoReporte = "1";
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
            if (chkFecha.Checked)
            {
                dtpFecha.Enabled = true;
                cboAño.Enabled = false;
                cboMes.Enabled = false;
            }
            else
            {
                dtpFecha.Enabled = false;
                cboAño.Enabled = true;
                cboMes.Enabled = true;
            }
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            //cmsFormatosExcel.Show(btExportar, new Point(0, btExportar.Height));
            try
            {
                Exportar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoAlmacen.SelectedIndex == 0)
            {
                cboalmacen.Enabled = false;
                cboalmacen.SelectedIndex = 0;
            }
            else
            {
                cboalmacen.Enabled = true;
                cboalmacen.DataSource = null;
                Int32 tipalm = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
                List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipalm);
                oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Todos });
                ComboHelper.LlenarCombos<AlmacenE>(cboalmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
            }
        }

        #endregion

    }
}

#region Pdf Inicio

class PaginaInicioStocks : PdfPageEventHelper
{

    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreAlmacen { get; set; }
    public String RutaImagen { get; set; }
    public Int32 IndFecha { get; set; }
    public DateTime FechaStock { get; set; }
    public String TipoReport { get; set; }
    public Int32 totColumnas { get; set; }
    public float[] AnchoCol { get; set; }
    //public Boolean ControlTot { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {

        base.OnStartPage(writer, document);

        String NombreMes = FechasHelper.NombreMes(Mes).ToUpper();
        String TituloGeneral = "STOCK DE ARTICULOS DE " + NombreAlmacen.ToUpper();
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro

        //Nombre del Mes
        if (IndFecha == 0)
        {
            SubTitulo = "AÑO: " + Anio + " MES: " + NombreMes;
        }
        else
        {
            SubTitulo = "Stock al : " + FechaStock.ToString("d");
        }

        PdfPTable table2 = new PdfPTable(2)
        {
            WidthPercentage = 100
        };

        table2.SetWidths(new float[] { 0.18f, 0.85f });
        table2.HorizontalAlignment = Element.ALIGN_LEFT;

        PdfPCell CeldaImagen = null;

        if (File.Exists(RutaImagen))
        {
            //table2.AddCell(ReaderHelper.ImagenCell(RutaImagen, 100, 5, Variables.SI, 1));
            System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
            CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 5f, 160, 40));

            table2.AddCell(CeldaImagen);
            table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f), 1, 1));
        }
        else
        {
            table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f), 1, 1));
            table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f), 1, 1));
        }

        table2.CompleteRow(); //Fila Completa...
        document.Add(table2);

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

        if (TipoReport == "1")
        {
            TablaCabDetalle = new PdfPTable(totColumnas)
            {
                WidthPercentage = 100
            };

            TablaCabDetalle.SetWidths(AnchoCol);

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE ALMACEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("STOCK", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("STOCK UD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MON.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COSTO SOLES", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COSTO DOLARES", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("U.M. ALM.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONT.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("U.M. DET.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NOMBRE ORIGEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NOMBRE PROCEDENCIA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LABORATORIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE PROVEEDOR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("BATCH", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("% GERMIN.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA VENC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA PROC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

            TablaCabDetalle.CompleteRow();
        }
        //else if (TipoReport == "2")
        //{
        //    TablaCabDetalle = new PdfPTable(totColumnas)
        //    {
        //        WidthPercentage = 100
        //    };

        //    TablaCabDetalle.SetWidths(AnchoCol);
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));   
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNIDAD ENV.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONTENIDO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNIDAD PRES.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE ALMACEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANTIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COSTO SOLES", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COSTO DOLARES", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

        //    TablaCabDetalle.CompleteRow();
        //}

        #endregion

        //Añadiendo la tabla al documento PDF
        document.Add(TablaCabDetalle);

    }
}

#endregion