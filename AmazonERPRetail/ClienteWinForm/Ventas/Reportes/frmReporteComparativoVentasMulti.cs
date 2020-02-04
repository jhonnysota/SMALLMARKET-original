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
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteComparativoVentasMulti : FrmMantenimientoBase
    {

        #region Constructor 

        public frmReporteComparativoVentasMulti()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
        }

        #endregion

        #region variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<EmisionDocumentoE> oListaReporte = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
        string tipo = "buscar";
        String Marque = String.Empty;
        Int32 TipoReporte = 0;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////ANIOS/////
            //int anioFin = Convert.ToInt32(VariablesLocales.FechaHoy.Year);
            //int anioInicio = anioFin - 10;

            //cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            //cboAnio.ValueMember = "AnioId";
            //cboAnio.DisplayMember = "AnioDes";
            //cboAnio.SelectedValue = VariablesLocales.FechaHoy.Year;

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            //Tipo Reporte
            List<ParTabla> oListaReporte = new List<ParTabla>();
            oListaReporte.Add(new ParTabla() { IdParTabla = 1, Nombre = "VENTAS POR PRODUCTO POR VENDEDORES" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 2, Nombre = "VENTAS POR ESPECIE" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 3, Nombre = "VENTAS POR PRODUCTO" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 4, Nombre = "VENTAS POR ESPECIE POR DIVISION" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 5, Nombre = "VENTAS POR ESPECIE POR ZONA" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 6, Nombre = "VENTAS POR ESPECIE POR VENDEDOR" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 7, Nombre = "VENTAS POR PRODUCTO POR DIVISION" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 8, Nombre = "VENTAS POR PRODUCTO POR ZONAS" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 9, Nombre = "VENTAS POR PRODUCTO POR CLIENTE" });
            oListaReporte.Add(new ParTabla() { IdParTabla =10, Nombre = "VENTAS POR VENDEDOR" });
            oListaReporte.Add(new ParTabla() { IdParTabla =11, Nombre = "VENTAS POR CLIENTE" });

            ComboHelper.RellenarCombos<ParTabla>(cboTipoReporte, oListaReporte);

            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            listaLocales.Add(new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos });
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboLocal, listaLocales, "idLocal", "Nombre", false);


            ////FlagGrabado////
            cboPresentacion.DataSource = Global.CargarMontoCantidad();
            cboPresentacion.ValueMember = "id";
            cboPresentacion.DisplayMember = "Nombre";
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\" + ((ParTabla)cboTipoReporte.SelectedItem).Nombre + " " + Aleatorio.ToString() + ".pdf";
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
                #region Variables

                List<EmisionDocumentoE> oListaCabecera = null;
                List<EmisionDocumentoE> oListaArticulos = null;
                List<EmisionDocumentoE> oListaVendedores = null;
                String Mon = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                String Monedades = ((MonedasE)cboMoneda.SelectedItem).desMoneda;
                String presentacion = cboPresentacion.Text.ToString();
                String anio = dtpInicio.Value.ToString("yyyy");
                String Titulo = String.Empty;
                String Subtitulo = String.Empty;
                int Columnas = 0;
                String nomArticulo = String.Empty;
                String Vendedor = String.Empty;
                Decimal TotalFilaTotal = 0;
                Decimal TotalMes = 0;
                Decimal TotalGeneral = 0;
                string EsUltimo = "N";
                BaseColor ColorSubtitulo = new BaseColor(233, 240, 245); //Color Subtitulo
                BaseColor ColorLinea = new BaseColor(84, 139, 184); //ColorLinea
                BaseColor ColorCabDeta = new BaseColor(148, 182, 210);

                #endregion

                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte;

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
                if (cboMoneda.Enabled == true)
                {
                    Titulo = ((ParTabla)cboTipoReporte.SelectedItem).Nombre + " En " + presentacion + " (" + Mon + ") "  + Monedades;
                }
                else
                {
                    Titulo = ((ParTabla)cboTipoReporte.SelectedItem).Nombre + " En " + presentacion;
                }
     
                Subtitulo = "Año Facturacion : " + anio;

                oListaCabecera = oListaReporte.GroupBy(x => x.Mes).Select(g => g.First()).ToList();
                Columnas = oListaCabecera.Count + 2;

                float[] ArrayColumnas_ = new float[Columnas];
                String[] ArrayTitulos_ = new String[Columnas];
                int s = 0;

                for (int i = 0; i < oListaCabecera.Count + 2; i++)
                {
                    if (i == 0)
                    {
                        ArrayTitulos_[i] = "VENTA " + Mon;
                        ArrayColumnas_[i] = 0.52f;
                    }
                    else if (i == oListaCabecera.Count + 1)
                    {
                        ArrayTitulos_[i] = "TOTAL GENERAL";
                        ArrayColumnas_[i] = 0.10f;
                    }
                    else if (i > 0 && i < oListaCabecera.Count + 1)
                    {
                        ArrayTitulos_[i] = oListaCabecera[s].Mes.ToUpper();
                        ArrayColumnas_[i] = 0.10f;
                        s++;
                    }
                }

                docPdf.Open();

                #region Titulos Principales

                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 0.55f, 0.45f });
                table.HorizontalAlignment = Element.ALIGN_LEFT;

                table.AddCell(ReaderHelper.NuevaCelda(Titulo, null, "N", null, FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                table.CompleteRow();

                //Linea en blanco
                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                table.CompleteRow();

                table.AddCell(ReaderHelper.NuevaCelda(Subtitulo, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S2"));
                table.CompleteRow();

                //Linea en blanco
                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0, "S2"));
                table.CompleteRow();

                #endregion

                docPdf.Add(table);

                #region Cabecera del Detalle

                PdfPTable TablaCab = new PdfPTable(Columnas);
                TablaCab.WidthPercentage = 100;
                TablaCab.SetWidths(ArrayColumnas_);

                for (int i = 0; i < ArrayTitulos_.Length; i++)
                {
                    TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos_[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4, 3, "S", "N", "N", "N", 1f));
                }

                TablaCab.CompleteRow();

                #endregion

                docPdf.Add(TablaCab);

                #region Reporte 1

                if (TipoReporte == 1 || TipoReporte == 4 || TipoReporte == 5 || TipoReporte == 6 || TipoReporte == 7 || TipoReporte == 8 || TipoReporte == 9) // reporte agrupado.
                {
                    #region Detalle

                    PdfPTable TablaDetalle = new PdfPTable(Columnas)
                    {
                        WidthPercentage = 100
                    };
                    TablaDetalle.SetWidths(ArrayColumnas_);
                    
                    //Lista nueva agrupada por vendedor
                    oListaVendedores = oListaReporte.GroupBy(x => x.nomVendedor).Select(g => g.First()).ToList();

                    for (int v = 0; v < oListaVendedores.Count; v++)
                    {
                        if (v == oListaVendedores.Count - 1)
                        {
                            EsUltimo = "S";
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(oListaVendedores[v].nomVendedor, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0));

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMes = oListaReporte.Where(x => x.Mes == item.Mes && x.nomVendedor == oListaVendedores[v].nomVendedor).ToList().Sum(x => x.totTotal);
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMes.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));

                            TotalGeneral += TotalMes;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneral.ToString("N2"), ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaDetalle.CompleteRow();

                        TotalMes = 0;
                        TotalGeneral = 0;

                        //Sacando todos los articulos del vendedor
                        oListaArticulos = oListaReporte.Where(x => x.nomVendedor == oListaVendedores[v].nomVendedor).ToList();
                        //Agrupando la lista por articulo
                        oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                        for (int a = 0; a < oListaArticulos.Count; a++)
                        {
                            if (EsUltimo == "S" && a == oListaArticulos.Count - 1)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(oListaArticulos[a].nomArticulo, null, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f), 5, 0, "N", "N", 2, 2, "N", "S", "N", "N"));
                            }
                            else
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(oListaArticulos[a].nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                            }

                            //Meses
                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                TotalMes = oListaReporte.Where(x => x.nomVendedor == oListaVendedores[v].nomVendedor
                                                                && x.nomArticulo == oListaArticulos[a].nomArticulo
                                                                && x.Mes == oListaCabecera[c].Mes).ToList().Sum(x => x.totTotal);

                                if (EsUltimo == "S" && a == oListaArticulos.Count - 1)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMes.ToString("N2"), null, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f), 5, 2, "N", "N", 2, 2, "N", "S", "N", "N"));
                                }
                                else
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMes.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                                }

                                TotalFilaTotal += TotalMes;
                            }

                            // Total Fila
                            if (EsUltimo == "S" && a == oListaArticulos.Count - 1)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaTotal.ToString("N2"), ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f), 5, 2, "N", "N", 2, 2, "N", "S", "N", "N"));
                            }
                            else
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaTotal.ToString("N2"), ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                            }

                            TablaDetalle.CompleteRow();
                            TotalFilaTotal = 0;
                        }
                    }

                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "N", "S", "N", "N", 1f));

                    foreach (EmisionDocumentoE item in oListaCabecera)
                    {
                        TotalMes = oListaReporte.Where(x => x.Mes == item.Mes).ToList().Sum(x => x.totTotal);
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMes.ToString("N2"), ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 2, 2, "N", "N", 4, 4, "N", "S", "N", "N", 1f));

                        TotalGeneral += TotalMes;
                    }

                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneral.ToString("N2"), ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 2, 2, "N", "N", 4, 4, "N", "S", "N", "N", 1f));
                    TablaDetalle.CompleteRow();

                    #endregion

                    docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF
                }

                #endregion

                #region Reporte 3

                if (TipoReporte == 2 || TipoReporte == 3 || TipoReporte == 10 || TipoReporte == 11) // reporte simple.
                {
                    #region Detalle

                    PdfPTable TablaDetalle = new PdfPTable(Columnas)
                    {
                        WidthPercentage = 100
                    };

                    TablaDetalle.SetWidths(ArrayColumnas_);

                    //Lista nueva agrupada por articulo
                    oListaArticulos = oListaReporte.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                    for (int i = 0; i < oListaArticulos.Count; i++)
                    {
                        //Articulos
                        nomArticulo = oListaArticulos[i].nomArticulo;

                        if (i == oListaArticulos.Count - 1)
                        {
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(nomArticulo, null, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f), 5, 0, "N", "N", 2, 2, "N", "S", "N", "N"));
                        }
                        else
                        {
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }

                        //Meses
                        for (int c = 0; c < oListaCabecera.Count; c++)
                        {
                            TotalMes = oListaReporte.Where(x => x.nomArticulo == nomArticulo && x.Mes == oListaCabecera[c].Mes).ToList().Sum(x => x.totTotal);

                            if (i == oListaArticulos.Count - 1)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMes.ToString("N2"), null, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f), 5, 2, "N", "N", 2, 2, "N", "S", "N", "N"));
                            }
                            else
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMes.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                            }
                                
                            TotalFilaTotal += TotalMes;
                        }

                        //Total Fila
                        if (i == oListaArticulos.Count - 1)
                        {
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaTotal.ToString("N2"), ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f), 5, 2, "N", "N", 2, 2, "N", "S", "N", "N"));
                        }
                        else
                        {
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaTotal.ToString("N2"), ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        }
                            
                        TablaDetalle.CompleteRow();
                        TotalFilaTotal = 0;
                    }

                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "N", "S", "N", "N", 1f));

                    foreach (EmisionDocumentoE item in oListaCabecera)
                    {
                        TotalMes = oListaReporte.Where(x => x.Mes == item.Mes).ToList().Sum(x => x.totTotal);
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMes.ToString("N2"), ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 2, 2, "N", "N", 4, 4, "N", "S", "N", "N", 1f));

                        TotalGeneral += TotalMes;
                    }

                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneral.ToString("N2"), ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 2, 2, "N", "N", 4, 4, "N", "S", "N", "N", 1f));

                    TablaDetalle.CompleteRow();

                    #endregion

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
                fsNuevoArchivo.Close();
            }
        }

        void ExportarExcel(String Ruta)
        {
            List<EmisionDocumentoE> oListaCabecera = null;

            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            String Mon = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
            String anio = dtpInicio.Value.ToString("yyyy");
            String Titulo = String.Empty;
            String Subtitulo = "Año Facturacion : " + anio;

            TituloGeneral = ((ParTabla)cboTipoReporte.SelectedItem).Nombre + " (" + Mon + ") ";

            switch (Convert.ToInt32(cboTipoReporte.SelectedValue))
            {
                case 1:
                    NombrePestaña = "Vta Vend Prod";
                    break;
                case 2:
                    NombrePestaña = "Vta Especie";
                    break;
                case 3:
                    NombrePestaña = "Vta Prod";
                    break;
                case 4:
                    NombrePestaña = "Vta_Division";
                    break;
                case 5:
                    NombrePestaña = "Vta_Zona";
                    break;
                case 6:
                    NombrePestaña = "Vta_Vendedor";
                    break;
                case 7:
                    NombrePestaña = "Vta Div Prod";
                    break;
                case 8:
                    NombrePestaña = "Vta Zona Prod";
                    break;
                default:
                    break;
            }

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);
                Int32 InicioLinea = 5;
                Int32 ColumnasFIN = 0;
                Int32 columna = 0;
                Decimal TotalFilaTotal = 0;
                Decimal TotalMes = 0;
                Decimal TotalGeneral = 0;
                Int32 TotColumnas = 2;
                String nomArticulo = "";
                List<EmisionDocumentoE> oListaArticulos = null;
                List<EmisionDocumentoE> oListaVendedores = null;

                if (oHoja != null)
                {
                    oListaCabecera = oListaReporte.GroupBy(x => x.Mes).Select(g => g.First()).ToList();
                    ColumnasFIN = oListaCabecera.Count + 2;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, 2 + oListaCabecera.Count])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 15, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    }

                    oHoja.Row(2).Height = 11.25;

                    oHoja.Cells["A3"].Value = Subtitulo;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, 2 + oListaCabecera.Count])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                    }

                    oHoja.Row(4).Height = 11.25;

                    #endregion Titulos Principales

                    oHoja.Cells[InicioLinea, 1].Value = "VENTA " + Mon;
                    oHoja.Column(1).Width = 93;

                    #region Cabeceras del Detalle

                    for (int i = 0; i < oListaCabecera.Count + 2; i++)
                    {
                        if (columna < oListaCabecera.Count)
                        {
                            oHoja.Cells[InicioLinea, i + 2].Value = oListaCabecera[columna].Mes;
                        }

                        oHoja.Cells[InicioLinea, i + 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i + 1].Style.Font.Color.SetColor(Color.White);
                        oHoja.Cells[InicioLinea, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[InicioLinea, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        oHoja.Cells[InicioLinea, i + 1].Style.Border.Top.Color.SetColor(Color.FromArgb(84, 139, 184));
                        oHoja.Cells[InicioLinea, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[InicioLinea, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        columna++;
                        oHoja.Column(i + 2).Width = 10;
                    }

                    oHoja.Cells[InicioLinea, ColumnasFIN].Value = "Total General";

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Reporte 1

                   
                   if (TipoReporte == 1 || TipoReporte == 4 || TipoReporte == 5 || TipoReporte == 6 || TipoReporte == 7 || TipoReporte == 8) // reporte agrupado.
                   {
                      #region Detalle

                        oListaVendedores = oListaReporte.GroupBy(x => x.nomVendedor).Select(g => g.First()).ToList();
                        for (int v = 0; v < oListaVendedores.Count; v++)
                        {
                            //Nombre del Vendedor
                            oHoja.Cells[InicioLinea, 1].Value = oListaVendedores[v].nomVendedor;
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            //Totales por vendedor 
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                TotalMes = oListaReporte.Where(x => x.Mes == item.Mes && x.nomVendedor == oListaVendedores[v].nomVendedor).ToList().Sum(x => x.totTotal);

                                oHoja.Cells[InicioLinea, TotColumnas].Value = TotalMes;
                                oHoja.Cells[InicioLinea, TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, TotColumnas].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, TotColumnas].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, TotColumnas].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));

                                TotalGeneral += TotalMes;
                                TotColumnas++;
                            }

                            //Total de la fila
                            oHoja.Column(ColumnasFIN).Width = 12;
                            oHoja.Cells[InicioLinea, ColumnasFIN].Value = TotalGeneral;
                            oHoja.Cells[InicioLinea, ColumnasFIN].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, ColumnasFIN].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, ColumnasFIN].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, ColumnasFIN].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                          
                            //Variables a 0 para volver a usarlas
                            TotalMes = 0;
                            TotalGeneral = 0;
                            TotColumnas = 2;

                            //Sacando todos los articulos del vendedor
                            oListaArticulos = oListaReporte.Where(x => x.nomVendedor == oListaVendedores[v].nomVendedor).ToList();
                            //Agrupando la lista por articulo
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();
                            
                            InicioLinea++;
                            
                            //Recorriendo los articulos
                            for (int a = 0; a < oListaArticulos.Count; a++)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = oListaArticulos[a].nomArticulo;
                                oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 6));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMes = oListaReporte.Where(x => x.nomVendedor == oListaVendedores[v].nomVendedor
                                                                    && x.nomArticulo == oListaArticulos[a].nomArticulo
                                                                    && x.Mes == oListaCabecera[c].Mes).ToList().Sum(x => x.totTotal);

                                    oHoja.Cells[InicioLinea, TotColumnas].Value = TotalMes;
                                    oHoja.Cells[InicioLinea, TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, TotColumnas].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 6));

                                    TotColumnas++;
                                    TotalFilaTotal += TotalMes;
                                }

                                // Total Fila
                                oHoja.Cells[InicioLinea, ColumnasFIN].Value = TotalFilaTotal;
                                oHoja.Cells[InicioLinea, ColumnasFIN].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 6));
                                oHoja.Cells[InicioLinea, ColumnasFIN].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, ColumnasFIN].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[InicioLinea, ColumnasFIN].Style.Numberformat.Format = "###,###,##0.00";

                                TotalFilaTotal = 0;
                                InicioLinea++;
                                TotColumnas = 2;
                            }
                        }
                                          
                        oHoja.Cells[InicioLinea, 1].Value = "TOTAL GENERAL";
                        TotColumnas = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMes = oListaReporte.Where(x => x.Mes == item.Mes).ToList().Sum(x => x.totTotal);
                            oHoja.Cells[InicioLinea, TotColumnas].Value = TotalMes;

                            TotalGeneral += TotalMes;
                            TotColumnas++;
                        }

                        oHoja.Cells[InicioLinea, ColumnasFIN].Value = TotalGeneral;

                        for (int i = 1; i <= ColumnasFIN; i++)
                        {
                            if (i > 1)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                            }

                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[InicioLinea, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            oHoja.Cells[InicioLinea, i].Style.Border.Top.Color.SetColor(Color.FromArgb(84, 139, 184));
                            oHoja.Cells[InicioLinea, i].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            oHoja.Cells[InicioLinea, i].Style.Border.Bottom.Color.SetColor(Color.FromArgb(84, 139, 184));
                        }

                        //InicioLinea++;

                        #endregion
                    }

                    #endregion

                    #region Reporte 3

                    if (TipoReporte == 3 || TipoReporte == 2)
                    {
                        #region Detalle

                        //Lista nueva agrupada por articulo
                        oListaArticulos = oListaReporte.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();
                        //Un poco mas ancho la ultima columna
                        oHoja.Column(ColumnasFIN).Width = 12;

                        for (int i = 0; i < oListaArticulos.Count; i++)
                        {
                            //Articulos
                            nomArticulo = oListaArticulos[i].nomArticulo;
                            oHoja.Cells[InicioLinea, 1].Value = nomArticulo;
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 6.25f));

                            //Meses
                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                TotalMes = oListaReporte.Where(x => x.nomArticulo == nomArticulo && x.Mes == oListaCabecera[c].Mes).ToList().Sum(x => x.totTotal);

                                oHoja.Cells[InicioLinea, TotColumnas].Value = TotalMes;
                                oHoja.Cells[InicioLinea, TotColumnas].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 6.25f));
                                oHoja.Cells[InicioLinea, TotColumnas].Style.Numberformat.Format = "###,###,##0.00";

                                TotalFilaTotal += TotalMes;
                                TotColumnas++;
                            }

                            //Total Fila
                            oHoja.Cells[InicioLinea, ColumnasFIN].Value = TotalFilaTotal;
                            oHoja.Cells[InicioLinea, ColumnasFIN].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 6.25f));
                            oHoja.Cells[InicioLinea, ColumnasFIN].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, ColumnasFIN].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, ColumnasFIN].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                            InicioLinea++;
                            TotalFilaTotal = 0;
                            TotColumnas = 2;
                        }

                        oHoja.Cells[InicioLinea, 1].Value = "TOTAL GENERAL";

                        //Colocando los totales a la ultima fila
                        TotColumnas = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMes = oListaReporte.Where(x => x.Mes == item.Mes).ToList().Sum(x => x.totTotal);
                            oHoja.Cells[InicioLinea, TotColumnas].Value = TotalMes;

                            TotalGeneral += TotalMes;
                            TotColumnas++;
                        }

                        oHoja.Cells[InicioLinea, ColumnasFIN].Value = TotalGeneral;

                        //Formateando la última fila
                        for (int i = 1; i <= ColumnasFIN; i++)
                        {
                            if (i > 1)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                            }

                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[InicioLinea, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            oHoja.Cells[InicioLinea, i].Style.Border.Top.Color.SetColor(Color.FromArgb(84, 139, 184));
                            oHoja.Cells[InicioLinea, i].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            oHoja.Cells[InicioLinea, i].Style.Border.Bottom.Color.SetColor(Color.FromArgb(84, 139, 184));
                        }

                        #endregion
                    }

                    #endregion

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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
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

        void CambioCheck()
        {
            if (cboPresentacion.SelectedIndex == 0)
            {
                cboMoneda.Enabled = true;
            }
            if (cboPresentacion.SelectedIndex == 1)
            {
                cboMoneda.Enabled = false;
                cboMoneda.SelectedIndex = 1;
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

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", ((ParTabla)cboTipoReporte.SelectedItem).Nombre + " (" + ((MonedasE)cboMoneda.SelectedItem).desAbreviatura + ")", "Archivos Excel (*.xlsx)|*.xlsx");

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
                    int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    int Local = Convert.ToInt32(cboLocal.SelectedValue);
                    TipoReporte = Convert.ToInt32(cboTipoReporte.SelectedValue);
                    String Moneda = Convert.ToString(cboMoneda.SelectedValue);
                    Int32 Cantidad = Convert.ToInt32(cboPresentacion.SelectedValue);

                    oListaReporte = AgenteVentas.Proxy.ComparativoVentasMulti(idEmpresa, Local, dtpInicio.Value.ToString("yyyyMMdd"), dtpFinal.Value.ToString("yyyyMMdd"), Moneda, TipoReporte, Cantidad);
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

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
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
                    Global.MensajeComunicacion("Comparativo Exportado...");
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteComparativoVentasMulti_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            CambioCheck();
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;
            //cboAnio.SelectedValue = Convert.ToInt32(VariablesLocales.FechaHoy.Year);
            dtpInicio.Value = Convert.ToDateTime("01/01/" + Convert.ToString(VariablesLocales.FechaHoy.Year));
            cboMoneda.SelectedValue = Variables.Dolares;
            cboLocal.SelectedValue = Convert.ToInt32(VariablesLocales.SesionLocal.IdLocal);
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
                if (dtpInicio.Value.Year != dtpFinal.Value.Year)
                {
                    Global.MensajeComunicacion("Las fechas deben ser del mismo año.");
                    return;
                }

                tipo = "buscar";
                Global.QuitarReferenciaWebBrowser(wbNavegador);
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                lblProcesando.Text = "Obteniendo registros ...";
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboCantidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CambioCheck();
        }

        #endregion

    }
}
