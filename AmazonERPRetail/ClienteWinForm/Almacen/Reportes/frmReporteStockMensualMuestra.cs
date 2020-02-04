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
using Entidades.Maestros;
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
    public partial class frmReporteStockMensualMuestra : FrmMantenimientoBase
    {

        public frmReporteStockMensualMuestra()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
            ImagenRuta();
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public String RutaImagen = @"C:\AmazonErp\Logo\";
        EmpresaImagenesE oEmpresaImagen = null;
        List<StockE> oReporteStock = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        //String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        //String Marque = String.Empty;
        string tipo = "buscar";
        Int32 Bloqueado = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
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

        void ImagenRuta()
        {
            oEmpresaImagen = AgenteMaestro.Proxy.ObtenerEmpresaSinImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (!Directory.Exists(RutaImagen))
            {
                Directory.CreateDirectory(RutaImagen);
            }

            if (oEmpresaImagen != null)
            {
                RutaImagen += oEmpresaImagen.Nombre + Convert.ToString(VariablesLocales.SesionUsuario.Empresa.IdEmpresa) + oEmpresaImagen.Extension; ;

                if (!File.Exists(RutaImagen))
                {
                    oEmpresaImagen = AgenteMaestro.Proxy.ObtenerEmpresaConImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    if (oEmpresaImagen.Imagen != null)
                    {
                        Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, RutaImagen);
                    }
                    else
                    {
                        RutaImagen = String.Empty;
                    }
                }
            }
            else
            {
                RutaImagen = String.Empty;
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\StockMensualMuestra " + Aleatorio.ToString();
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

                PaginaInicioStocksMENS ev = new PaginaInicioStocksMENS();
                ev.Anio = Convert.ToString(cboAño.SelectedValue);
                ev.Mes = Convert.ToInt32(cboMes.SelectedValue);
                ev.NombreAlmacen = (((AlmacenE)cboalmacen.SelectedItem).desAlmacen);
                ev.Block = Bloqueado;
                ev.FechaStock = Convert.ToDateTime(dtpFecha.Value);
                ev.RutaImagen = RutaImagen;
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo
                PdfPTable TablaCabDetalle = new PdfPTable(25);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.04f,0.04f, 0.04f, 0.04f, 0.02f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f });

                foreach (StockE item in oReporteStock)
                {
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Nivel1, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Nivel2, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Nivel3, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomCorto, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomcomercial, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomColor, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.hibop, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.otros, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.cacm, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.patron, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Observacion, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.LoteProveedor, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PorcentajeGerminacion.Value.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idPersona.ToString(), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.NombreOrigen, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecPrueba.Value.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PesoUnitario.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecProceso.Value.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.EntregadoPor, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 1));

                    TablaCabDetalle.CompleteRow();
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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String nombreMes = cboMes.Text;

            TituloGeneral = " Stock Muestra " + Anio + " - " + nombreMes;
            NombrePestaña = " Stock Muestra ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 5;
                    Int32 TotColumnas = 25;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A2"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(81, 175, 92));
                    }

                    oHoja.Cells["A3"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(81, 175, 92));
                    }

                    #endregion Titulos Principales

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " LOTE ";
                    oHoja.Cells[InicioLinea, 2].Value = " FAMILIA ";
                    oHoja.Cells[InicioLinea, 3].Value = " TIPO";
                    oHoja.Cells[InicioLinea,4].Value = " CULTIVO ";
                    oHoja.Cells[InicioLinea, 5].Value = " MTC ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea,1,InicioLinea,5])
                    {
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(10, 246, 89));
                    }

                    oHoja.Cells[InicioLinea, 6].Value = " NOMBRE COMERCIAL ";
                    oHoja.Cells[InicioLinea, 7].Value = " COLOR";
                    oHoja.Cells[InicioLinea, 8].Value = " HIB/OP ";
                    oHoja.Cells[InicioLinea, 9].Value = " OTROS ";
                    oHoja.Cells[InicioLinea, 10].Value = " CA/CM ";
                    oHoja.Cells[InicioLinea, 11].Value = " PATRON ";
                    oHoja.Cells[InicioLinea, 12].Value = " OBSERVACION ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea,6,InicioLinea, 12])
                    {
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(10, 176, 240));
                    }

                    oHoja.Cells[InicioLinea, 13].Value = " LOTE PROVEED ";
                    oHoja.Cells[InicioLinea, 14].Value = " GERM ";
                    oHoja.Cells[InicioLinea, 15].Value = " RUC/DNI ";
                    oHoja.Cells[InicioLinea, 16].Value = " PROVEEDOR";
                    oHoja.Cells[InicioLinea, 17].Value = " ORIGEN ";
                    oHoja.Cells[InicioLinea, 18].Value = " FECHA DE PRUEBA ";
                    oHoja.Cells[InicioLinea, 19].Value = " PRESENTACION ";
                    oHoja.Cells[InicioLinea, 20].Value = " PESO ";
                    oHoja.Cells[InicioLinea, 21].Value = " UNI. MEDIDA ";
                    oHoja.Cells[InicioLinea, 22].Value = " CANT-STOCK ";
                    oHoja.Cells[InicioLinea, 23].Value = " PESO UNIT. REF KG ";
                    oHoja.Cells[InicioLinea, 24].Value = " INGRESO ALMACEN ";
                    oHoja.Cells[InicioLinea, 25].Value = " ENTREGADO POR ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea,13,InicioLinea, 25])
                    {
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(20, 236, 236));
                    }

                    for (int i = 1; i <= 25; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    //Aumentando una Fila mas continuar con el detalle


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle

                    foreach (StockE item in oReporteStock)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.Lote;
                        oHoja.Cells[InicioLinea, 2].Value = item.Nivel1;

                        oHoja.Cells[InicioLinea, 3].Value = item.Nivel2;
                        oHoja.Cells[InicioLinea, 4].Value = item.Nivel3;
                        oHoja.Cells[InicioLinea, 5].Value = item.nomCorto;
                        oHoja.Cells[InicioLinea, 6].Value = item.nomcomercial;
                        oHoja.Cells[InicioLinea, 7].Value = item.nomColor;
                        oHoja.Cells[InicioLinea, 8].Value = item.hibop;
                        oHoja.Cells[InicioLinea, 9].Value = item.otros;
                        oHoja.Cells[InicioLinea, 10].Value = item.cacm;
                        oHoja.Cells[InicioLinea, 11].Value = item.patron;
                        oHoja.Cells[InicioLinea, 12].Value = item.Observacion;
                        oHoja.Cells[InicioLinea, 13].Value = item.LoteProveedor;

                        using (ExcelRange Rango = oHoja.Cells[1,13])
                        {
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        }

                            oHoja.Cells[InicioLinea, 14].Value = item.PorcentajeGerminacion.Value;

                        oHoja.Cells[InicioLinea, 15].Value = item.idPersona;

                        oHoja.Cells[InicioLinea, 16].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 17].Value = item.NombreOrigen;
                        oHoja.Cells[InicioLinea, 18].Value = item.fecPrueba;
                        oHoja.Cells[InicioLinea, 19].Value = item.nomUMedidaPres;

                        using (ExcelRange Rango = oHoja.Cells[16, 19])
                        {
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 20].Value = item.Contenido;

                        oHoja.Cells[InicioLinea, 21].Value = item.nomUMedidaEnv;

                        using (ExcelRange Rango = oHoja.Cells[21,21])
                        {
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        }
                        oHoja.Cells[InicioLinea, 22].Value = item.canStock;
                        oHoja.Cells[InicioLinea, 23].Value = item.PesoUnitario;
                        oHoja.Cells[InicioLinea, 24].Value = item.fecProceso;
                        oHoja.Cells[InicioLinea, 25].Value = item.EntregadoPor;


                        using (ExcelRange Rango = oHoja.Cells[24, 25])
                        {
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.000";
                        oHoja.Cells[InicioLinea, 22].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 23].Style.Numberformat.Format = "###,###,##0.00";
                        InicioLinea++;

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
                if (oReporteStock == null || oReporteStock.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String Mes = cboMes.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Stock Mensuales Muestra" + "-" + VariablesLocales.SesionUsuario.Empresa.NombreComercial + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    lblProcesando.Visible = true;
                    btBuscar.Enabled = true;
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
                Int32 indfecha = 0;
                if (chkFecha.Checked == true)
                {
                    indfecha = 1;
                }
                else
                {
                    indfecha = 0;
                }
                string Fecha = dtpFecha.Value.ToString("yyyyMMdd");

                lblProcesando.Text = "Obteniendo el Reporte Stock Mensual...";
                oReporteStock = AgenteAlmacen.Proxy.ListarReporteStockMensualMuestra(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Almacen, Anio, Mes, indfecha, Fecha);
                lblProcesando.Text = "Armando el Reporte...";
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

        private void frmReporteStockMensualMuestra_Load(object sender, EventArgs e)
        {
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
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

        private void frmReporteStockMensualMuestra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }


        #endregion

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
                cboalmacen.Enabled = false;
                cboalmacen.SelectedIndex = 0;
            }
            else
            {
                cboalmacen.Enabled = true;
                cboalmacen.DataSource = null;
                Int32 tipalm = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
                List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipalm);
                AlmacenE oItem = new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Todos };
                oListaAlmacen.Add(oItem);
                ComboHelper.LlenarCombos<AlmacenE>(cboalmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
            }
        }
    }
}



#region Pdf Inicio

class PaginaInicioStocksMENS : PdfPageEventHelper
{
    public DateTime FechaStock { get; set; }
    public Int32 Block { get; set; }
    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreAlmacen { get; set; }
    public String RutaImagen { get; set; }

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

        TituloGeneral = "STOCK DE ARTICULOS DE " + NombreAlmacen.ToUpper();

        if (Block == 1)
        {
            SubTitulo = "Stock al : " + FechaStock.ToString("d");
        }
        else
        {
            SubTitulo = "AÑO: " + Anio.ToUpper() + " - MES: " + NombreMes;
        }

        PdfPTable table2 = new PdfPTable(2);

        table2.WidthPercentage = 100;
        table2.SetWidths(new float[] { 0.18f, 0.85f });
        table2.HorizontalAlignment = Element.ALIGN_LEFT;

        if (!String.IsNullOrEmpty(RutaImagen))
        {
            table2.AddCell(ReaderHelper.ImagenCell(RutaImagen, 100, 5, Variables.SI, 1));
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

        PdfPTable TablaCabDetalle = new PdfPTable(25);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] {0.04f, 0.04f, 0.04f, 0.04f,0.02f,0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f });

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FAMILIA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIPO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CULTIVO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MCT", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NOMBRE COMERCIAL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COLOR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("HIB/OP", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OTROS", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CA/CM", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PATRON", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OBSERVACION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE PROVEED", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("GERM", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RUC/DNI", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PROVEEDOR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ORIGEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA DE PRUEBA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PRESENTACION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PESO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNI.MEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANT-STOCK", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PESO UNIT.REF KG", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("INGRESO ALMACEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ENTREGADO POR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

    }
}

#endregion
