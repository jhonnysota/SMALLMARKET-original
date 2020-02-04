using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Maestros;
using ClienteWinForm;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

using System.Windows.Forms.DataVisualization.Charting;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteRentabilidad : FrmMantenimientoBase
    {

        public frmReporteRentabilidad()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
            ImagenRuta();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public String RutaImagen = @"C:\AmazonErp\Logo\";
        List<RentabilidadE> Orenta = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        //int anioInicio = 0;
        //int anioFin = 0;
        String Marque = String.Empty;
        string tipo = "buscar";
        String TipoReporte = "1";
        String FormatoExcel = "1";

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

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                     where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                     orderby x.idMoneda
                                     select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            cboMoneda.SelectedIndex = 1;
        }

        void ImagenRuta()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 40f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Rentabilidad " + Aleatorio.ToString();
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

                PaginaInicioReporteRentabilidad ev = new PaginaInicioReporteRentabilidad();
                ev.TipoReport = TipoReporte;
                ev.FechaStock = Convert.ToDateTime(dtpFechaIni.Value);

                ev.NombreAlmacen = (((LocalE)cboSucursal.SelectedItem).Nombre);
                ev.RutaImagen = RutaImagen;
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo
                PdfPTable TablaCabDetalle = new PdfPTable(10);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.1f,0.08f, 0.22f, 0.08f, 0.06f, 0.08f, 0.06f, 0.08f, 0.08f, 0.06f });

                Orenta = (from x in Orenta orderby x.nomCategoria select x).ToList();

                int contador = 0;
                string Categoria = "";
                Decimal TOTAL1= 0;
                Decimal TOTAL2 = 0;
                Decimal TOTAL3 = 0;
                Decimal TOTAL4 = 0;

                Decimal SubTotalCantidad = 0;
                Decimal SubTotalValorVenta = 0;
                Decimal SubTotalCosto = 0;
                Decimal SubTotalUtilidadBruta = 0;
                Decimal MargenCat = 0;


                for (int i = 0; i < Orenta.Count; i++)
                {
                    if (contador == 0)
                    {
                        Categoria = Orenta[i].nomCategoria;
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Categoria, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5,-1,"S10"));
                        TablaCabDetalle.CompleteRow();
                    }

                    if (Categoria != Orenta[i].nomCategoria)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SUB-TOTALES", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalCantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalValorVenta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalCosto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalUtilidadBruta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));

                        MargenCat = 0;

                        if (SubTotalValorVenta != 0)
                        {
                            MargenCat = Math.Round((SubTotalUtilidadBruta / SubTotalValorVenta * 100), 2);
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MargenCat.ToString("N2") + "%", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.CompleteRow();

                        Categoria = Orenta[i].nomCategoria;
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Categoria, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1, "S10"));
                        TablaCabDetalle.CompleteRow();                      

                        SubTotalCantidad = 0;
                        SubTotalValorVenta = 0;
                        SubTotalCosto = 0;
                        SubTotalUtilidadBruta = 0;
                    }

                    Decimal PrecioUnitarioPromedio = 0;
                    Decimal CostoUnitarioPromedio  = 0;

                    if (Orenta[i].Cantidad != 0 && Orenta[i].TotalCosto != 0)
                    {
                        PrecioUnitarioPromedio = Orenta[i].ValorVenta / Orenta[i].Cantidad;
                    }

                    if (Orenta[i].Cantidad != 0 && Orenta[i].TotalCosto != 0)
                    {
                        CostoUnitarioPromedio = Orenta[i].TotalCosto / Orenta[i].Cantidad;
                    }

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Orenta[i].codArticulo, null, "N", null, FontFactory.GetFont("Arial", 6f), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Orenta[i].nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 6f), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Orenta[i].Cantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(PrecioUnitarioPromedio.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Orenta[i].ValorVenta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CostoUnitarioPromedio.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5,2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Orenta[i].TotalCosto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                    Orenta[i].UtilidadBruta = Orenta[i].ValorVenta - Orenta[i].TotalCosto;
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Orenta[i].UtilidadBruta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));

                    Decimal Margen = 0;

                    if (Orenta[i].ValorVenta != 0)
                    {
                     if (Orenta[i].UtilidadBruta >= 0)
                      { 
                      Margen = Math.Round((Orenta[i].UtilidadBruta / Orenta[i].ValorVenta * 100),2);
                      }
                     else
                      {
                      Margen = Math.Round((Orenta[i].UtilidadBruta / Orenta[i].ValorVenta * 100), 2) * -1; 
                      }
                    }

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Margen.ToString("N2") + "%", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 2));
                    TablaCabDetalle.CompleteRow();

                    TOTAL1 += Orenta[i].Cantidad;
                    TOTAL2 += Orenta[i].ValorVenta;
                    TOTAL3 += Orenta[i].TotalCosto;
                    TOTAL4 += Orenta[i].UtilidadBruta;

                    SubTotalCantidad += Orenta[i].Cantidad;
                    SubTotalValorVenta += Orenta[i].ValorVenta;
                    SubTotalCosto += Orenta[i].TotalCosto;
                    SubTotalUtilidadBruta += Orenta[i].UtilidadBruta;

                    contador++;
                }

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SUB-TOTALES", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalCantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalValorVenta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalCosto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SubTotalUtilidadBruta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));

                MargenCat = 0;

                if (SubTotalValorVenta != 0)
                {
                    MargenCat = Math.Round(((SubTotalValorVenta - SubTotalCosto) / SubTotalValorVenta * 100), 2);
                }

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MargenCat.ToString("N2") + "%", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.CompleteRow();

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1,"S10"));
                TablaCabDetalle.CompleteRow();

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTALES", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TOTAL1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TOTAL2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TOTAL3.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TOTAL4.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));

                MargenCat = 0;

                if (TOTAL2 != 0)
                {
                    MargenCat = Math.Round(((TOTAL2 - TOTAL3) / TOTAL2 * 100), 2);
                }

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MargenCat.ToString("N2") + "%", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.CompleteRow();

                #endregion

                docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

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
            String SubTitulo = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = " Rentabilidad Por Linea De Productos ";
            SubTitulo = "Expresado en Dolares Americanos";
            NombrePestaña = " Rentabilidad ";

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

                    oHoja.Cells["A3"].Value = SubTitulo;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas])
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
                    oHoja.Cells[InicioLinea, 1].Value = " CATEGORIA ";
                    oHoja.Cells[InicioLinea, 2].Value = " COD. ARTICULO ";
                    oHoja.Cells[InicioLinea, 3].Value = " ARTICULO ";
                    oHoja.Cells[InicioLinea, 4].Value = " CANTIDAD ";
                    oHoja.Cells[InicioLinea, 5].Value = " PRECIO UNIT. PROMEDIO";
                    oHoja.Cells[InicioLinea, 6].Value = " VALOR VENTA ";
                    oHoja.Cells[InicioLinea, 7].Value = " COSTO UNIT. PROM. ";
                    oHoja.Cells[InicioLinea, 8].Value = " COSTO";
                    oHoja.Cells[InicioLinea, 9].Value = " UTILIDAD BRUTA ";
                    oHoja.Cells[InicioLinea, 10].Value = " % UTIL ";

                    for (int i = 1; i <= 10; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    //Aumentando una Fila mas continuar con el detalle


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle

                    Orenta = (from x in Orenta orderby x.nomCategoria select x).ToList();

                    int contador = 0;
                    string Categoria = "";
                    Decimal TOTAL1 = 0;
                    Decimal TOTAL2 = 0;
                    Decimal TOTAL3 = 0;
                    Decimal TOTAL4 = 0;

                    Decimal SubTotalCantidad = 0;
                    Decimal SubTotalValorVenta = 0;
                    Decimal SubTotalCosto = 0;
                    Decimal SubTotalUtilidadBruta = 0;
                    Decimal MargenCat = 0;

                    for (int i = 0; i < Orenta.Count; i++)
                    {


                        if (contador == 0)
                        {
                            Categoria = Orenta[i].nomCategoria;
                            oHoja.Cells[InicioLinea, 1].Value = Categoria;
                            InicioLinea++;
                        }

                        if (Categoria != Orenta[i].nomCategoria)
                        {


                            oHoja.Cells[InicioLinea, 1].Value = " ";
                            oHoja.Cells[InicioLinea, 2].Value = " ";
                            oHoja.Cells[InicioLinea, 3].Value = "SUB-TOTALES";
                            oHoja.Cells[InicioLinea, 4].Value = SubTotalCantidad;
                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 5].Value = " ";
                            oHoja.Cells[InicioLinea, 6].Value = SubTotalValorVenta;
                            oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 7].Value = " ";
                            oHoja.Cells[InicioLinea, 8].Value = SubTotalCosto;
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 9].Value = SubTotalUtilidadBruta;
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                            MargenCat = 0;
                            if (SubTotalValorVenta != 0)
                            {
                                MargenCat = Math.Round((SubTotalUtilidadBruta / SubTotalValorVenta * 100), 2);
                            }
                            oHoja.Cells[InicioLinea, 10].Value = MargenCat;
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            oHoja.Cells[InicioLinea, 1, InicioLinea,10].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 11, FontStyle.Bold));
                            InicioLinea++;

                            Categoria = Orenta[i].nomCategoria;
                            oHoja.Cells[InicioLinea, 1].Value = Categoria;
                            InicioLinea++;
                            SubTotalCantidad = 0;
                            SubTotalValorVenta = 0;
                            SubTotalCosto = 0;
                            SubTotalUtilidadBruta = 0;
                        }

                        Decimal PrecioUnitarioPromedio = 0;
                        Decimal CostoUnitarioPromedio = 0;

                        if (Orenta[i].Cantidad != 0 && Orenta[i].ValorVenta != 0)
                        {
                            PrecioUnitarioPromedio = Orenta[i].ValorVenta / Orenta[i].Cantidad;
                        }

                        if (Orenta[i].Cantidad != 0 && Orenta[i].TotalCosto != 0)
                        {
                            CostoUnitarioPromedio = Orenta[i].TotalCosto / Orenta[i].Cantidad;
                        }

                        oHoja.Cells[InicioLinea, 1].Value =  " ";
                        oHoja.Cells[InicioLinea, 2].Value = Orenta[i].codArticulo;
                        oHoja.Cells[InicioLinea, 3].Value = Orenta[i].nomArticulo;
                        oHoja.Cells[InicioLinea, 4].Value = Orenta[i].Cantidad;
                        oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 5].Value = PrecioUnitarioPromedio;
                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 6].Value = Orenta[i].ValorVenta;
                        oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";                       
                        oHoja.Cells[InicioLinea, 7].Value = CostoUnitarioPromedio;
                        oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 8].Value = Orenta[i].TotalCosto;
                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                        Orenta[i].UtilidadBruta = Orenta[i].ValorVenta - Orenta[i].TotalCosto;
                        oHoja.Cells[InicioLinea, 9].Value = Orenta[i].UtilidadBruta;
                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                        Decimal Margen = 0;

                        if (Orenta[i].ValorVenta != 0)
                        {
                            if (Orenta[i].UtilidadBruta >= 0)
                            {
                                Margen = Math.Round((Orenta[i].UtilidadBruta / Orenta[i].ValorVenta * 100), 2);
                            }
                            else
                            {
                                Margen = Math.Round((Orenta[i].UtilidadBruta / Orenta[i].ValorVenta * 100), 2) * -1;
                            }
                        }

                        oHoja.Cells[InicioLinea, 10].Value = Margen;
                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                        TOTAL1 += Orenta[i].Cantidad;
                        TOTAL2 += Orenta[i].ValorVenta;
                        TOTAL3 += Orenta[i].TotalCosto;
                        TOTAL4 += Orenta[i].UtilidadBruta;

                        SubTotalCantidad += Orenta[i].Cantidad;
                        SubTotalValorVenta += Orenta[i].ValorVenta;
                        SubTotalCosto += Orenta[i].TotalCosto;
                        SubTotalUtilidadBruta += Orenta[i].UtilidadBruta;
                        InicioLinea++;
                        contador++;
                    }


                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = "SUB-TOTALES";
                    oHoja.Cells[InicioLinea, 4].Value = SubTotalCantidad;
                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = SubTotalValorVenta;
                    oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 7].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = SubTotalCosto;
                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 9].Value = SubTotalUtilidadBruta;
                    oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                    MargenCat = 0;
                    if (SubTotalValorVenta != 0)
                    {
                        MargenCat = Math.Round(((SubTotalValorVenta - SubTotalCosto) / SubTotalValorVenta * 100), 2);
                    }
                    oHoja.Cells[InicioLinea, 10].Value = MargenCat;
                    oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 1, InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 11, FontStyle.Bold));
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = "TOTALES";
                    oHoja.Cells[InicioLinea, 4].Value = TOTAL1;
                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = TOTAL2;
                    oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 7].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = TOTAL3;
                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 9].Value = TOTAL4;
                    oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                    MargenCat = 0;
                    if (TOTAL2 != 0)
                    {
                        MargenCat = Math.Round(((TOTAL2 - TOTAL3) / TOTAL2 * 100), 2);
                    }
                    oHoja.Cells[InicioLinea, 10].Value = MargenCat;
                    oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 1, InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 11, FontStyle.Bold));
                    InicioLinea++;
    

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

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (Orenta == null || Orenta.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }



                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Rentabilidad" + "-" + VariablesLocales.SesionUsuario.Empresa.NombreComercial , "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    FormatoExcel = "1";
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
            if (tipo == "buscar")
            {
                Int32 Sucursal = Convert.ToInt32(cboSucursal.SelectedValue);
                string Fechaini = dtpFechaIni.Value.ToString("yyyyMMdd");
                string FechaFin = dtoFechaFin.Value.ToString("yyyyMMdd");
                String Moneda = Convert.ToString(cboMoneda.SelectedValue);

                lblProcesando.Text = "Obteniendo el Rentabilidad...";
                Orenta = AgenteVentas.Proxy.ListarReporteRentabilidadPorProducto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Sucursal, Fechaini, FechaFin, Moneda);
                lblProcesando.Text = "Armando el Reporte...";
                ConvertirApdf();
            }
            else
            {
                if (FormatoExcel == "1")
                {
                    ExportarExcel(RutaGeneral);
                }
                else if (FormatoExcel == "2")
                {
                    ExportarExcel(RutaGeneral);
                }
            }
        }

        void MostarGrafico()
        {
            // Grafico
            List<String> RSeries = new List<string>();
            List<Decimal> RPuntos = new List<decimal>();
            String Categoria = "";
            int contador = 0;
            //Decimal SubTotalValorVenta = 0;
            //Decimal SubTotalUtilidadBruta = 0;
            Decimal SubTotalValorVentaULT = 0;
            Decimal SubTotalUtilidadBrutaULT = 0;

            for (int i = 0; i < Orenta.Count; i++)
            {
                if (contador == 0)
                {
                    Categoria = Orenta[i].nomCategoria;
                    RSeries.Add(Categoria);
                }

                if (Categoria != Orenta[i].nomCategoria)
                {
                    Categoria = Orenta[i].nomCategoria;
                    RSeries.Add(Categoria);

                    Decimal Margen = 0;
                    //SubTotalValorVenta += Orenta[i].ValorVenta;
                    //SubTotalUtilidadBruta += Orenta[i].UtilidadBruta;

                    if (SubTotalValorVentaULT != 0)
                    {
                        Margen = Math.Round((SubTotalUtilidadBrutaULT / SubTotalValorVentaULT * 100), 2);
                    }                               
                    RPuntos.Add(Margen);

                    //SubTotalValorVenta = 0;
                    //SubTotalUtilidadBruta = 0;
                    SubTotalValorVentaULT = 0;
                    SubTotalUtilidadBrutaULT = 0;
                }
                SubTotalValorVentaULT += Orenta[i].ValorVenta;
                SubTotalUtilidadBrutaULT += Orenta[i].UtilidadBruta;
                contador++;
            }

            Decimal Margen2 = 0;

            if (SubTotalValorVentaULT != 0)
            {
                Margen2 = Math.Round((SubTotalUtilidadBrutaULT / SubTotalValorVentaULT * 100),2);
            }

            RPuntos.Add(Margen2);

            Grafico.Palette = ChartColorPalette.Pastel;
            Grafico.Titles.Clear();
            Title Titulo = Grafico.Titles.Add("RENTABILIDAD POR CATEGORIA");
            Titulo.Font = new System.Drawing.Font("Arial", 16, FontStyle.Bold);

            Grafico.Series[0].Points.Clear();
            Grafico.Series[0].ChartType = SeriesChartType.Pie;
            Grafico.ChartAreas[0].Area3DStyle.Enable3D = true;

            for (int i = 0; i < RSeries.Count; i++)
            {
                Grafico.Series[0].Points.Add(Convert.ToDouble(RPuntos[i]));
                Grafico.Series[0].Points[i].Label = RPuntos[i].ToString() + "%";
                Grafico.Series[0].Points[i].LegendText = RPuntos[i].ToString("##0.00") + "%" + " "+ RSeries[i];
            }
        }

        void MostarGraficoBarra()
        {
            // Grafico
            List<String> RSeries = new List<string>();
            List<Decimal> RPuntos = new List<decimal>();
            String Categoria = "";
            int contador = 0;
            //Decimal SubTotalValorVenta = 0;
            //Decimal SubTotalUtilidadBruta = 0;
            Decimal SubTotalValorVentaULT = 0;
            Decimal SubTotalUtilidadBrutaULT = 0;

            for (int i = 0; i < Orenta.Count; i++)
            {
                if (contador == 0)
                {
                    Categoria = Orenta[i].nomCategoria;
                    RSeries.Add(Categoria);
                }

                if (Categoria != Orenta[i].nomCategoria)
                {
                    Categoria = Orenta[i].nomCategoria;
                    RSeries.Add(Categoria);

                    Decimal Margen = 0;
                    //SubTotalValorVenta += Orenta[i].ValorVenta;
                    //SubTotalUtilidadBruta += Orenta[i].UtilidadBruta;

                    if (SubTotalValorVentaULT != 0)
                    {
                        Margen = Math.Round((SubTotalUtilidadBrutaULT / SubTotalValorVentaULT * 100), 2);
                    }
                    RPuntos.Add(Margen);

                    //SubTotalValorVenta = 0;
                    //SubTotalUtilidadBruta = 0;
                    SubTotalValorVentaULT = 0;
                    SubTotalUtilidadBrutaULT = 0;
                }
                SubTotalValorVentaULT += Orenta[i].ValorVenta;
                SubTotalUtilidadBrutaULT += Orenta[i].UtilidadBruta;
                contador++;
            }

            Decimal Margen2 = 0;

            if (SubTotalValorVentaULT != 0)
            {
                Margen2 = Math.Round((SubTotalUtilidadBrutaULT / SubTotalValorVentaULT * 100), 2);
            }

            RPuntos.Add(Margen2);

            Grafico.Palette = ChartColorPalette.Pastel;
            Grafico.Titles.Clear();
            Title Titulo = Grafico.Titles.Add("RENTABILIDAD POR CATEGORIA");
            Titulo.Font = new System.Drawing.Font("Arial", 16, FontStyle.Bold);

            Grafico.Series[0].Points.Clear();
            Grafico.Series[0].ChartType = SeriesChartType.Bar;
            Grafico.ChartAreas[0].Area3DStyle.Enable3D = true;

            for (int i = 0; i < RSeries.Count; i++)
            {
                Grafico.Series[0].Points.Add(Convert.ToDouble(RPuntos[i]));
                Grafico.Series[0].Points[i].Label = RPuntos[i].ToString() + "%";
                Grafico.Series[0].Points[i].LegendText = RPuntos[i].ToString("##0.00") + "%" + " " + RSeries[i];
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
                    MostarGrafico();
                }
            }
            else
            {
                Global.MensajeComunicacion("Rentabilidad Por Producto Exportado...");
            }
        }

        #endregion

        #region Eventos 

        private void frmReporteStockMensual_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void frmReporteRentabilidad_Load(object sender, EventArgs e)
        {
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
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;
        }

        private void btBuscar_Click_1(object sender, EventArgs e)
        {
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

        private void btExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        #endregion

    }
}


#region Pdf Inicio

class PaginaInicioReporteRentabilidad : PdfPageEventHelper
{

    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreAlmacen { get; set; }
    public String RutaImagen { get; set; }
    public Int32 IndFecha { get; set; }
    public DateTime FechaStock { get; set; }
    public String TipoReport { get; set; }

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
        NombreMes = FechasHelper.NombreMes(Mes).ToUpper();

        TituloGeneral = "RENTABILIDAD POR LINEA DE PRODUCTOS  ";
        SubTitulo = "EXPRESADO EN DOLARES AMERICANOS";


        PdfPTable table2 = new PdfPTable(2);

        table2.WidthPercentage = 100;
        table2.SetWidths(new float[] { 0.18f, 0.85f });
        table2.HorizontalAlignment = Element.ALIGN_LEFT;

        if (!String.IsNullOrEmpty(RutaImagen))
        {
            PdfPCell CeldaImagen = null;

            if (File.Exists(RutaImagen))
            {
                System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 85f, 30f, 1, 1, "S", 1f));
                Img = null;
            }
            else
            {
                CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
            }

            table2.AddCell(CeldaImagen);//ReaderHelper.ImagenCell(RutaImagen, 100, 5, Variables.SI, 1));
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
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
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

        PdfPTable TablaCabDetalle = new PdfPTable(10);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.1f,0.08f,0.22f,0.08f,0.06f,0.08f, 0.06f, 0.08f,0.08f,0.06f });

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CATEGORIA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COD. ARTICULO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ARTICULO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANTIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PREC. UNIT. PROM.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COSTO UNIT. PROM.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COSTO ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UTILIDAD BRUTA ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("% RENTAB.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.CompleteRow();
        document.Add(TablaCabDetalle);

        #endregion

        //Añadiendo la tabla al documento PDF

    }
}

#endregion

