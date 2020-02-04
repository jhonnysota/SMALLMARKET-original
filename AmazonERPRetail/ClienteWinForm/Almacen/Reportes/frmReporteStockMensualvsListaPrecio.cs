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

//using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Negocio;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Entidades.Almacen;
using ClienteWinForm;

#endregion

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteStockMensualvsListaPrecio : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteStockMensualvsListaPrecio()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
            ImagenRuta();
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public String RutaImagen = @"C:\AmazonErp\Logo\";
        List<StockE> oReporteStock = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        Int32 TipoOrden = 1;
        String Marque = String.Empty;
        string tipo = "buscar";

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

            /////Almacenes/////
            List<AlmacenE> ListarTipoAlmacen = AgenteAlmacen.Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", 0, false, false);
            ComboHelper.RellenarCombos<AlmacenE>(cboalmacen, (from x in ListarTipoAlmacen orderby x.desAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
        }

        void ImagenRuta()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
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

                PaginaInicioStocksvsListaPrecio ev = new PaginaInicioStocksvsListaPrecio();
                ev.Anio = Convert.ToString(cboAño.SelectedValue);
                ev.Mes = Convert.ToInt32(cboMes.SelectedValue);

                if (chkFecha.Checked)
                {
                    ev.IndFecha = 1;
                }
                else
                {
                    ev.IndFecha = 0;
                }

                ev.FechaStock = Convert.ToDateTime(dtpFecha.Value);
                ev.TipoOrden_ = TipoOrden;
                ev.NombreAlmacen = (((AlmacenE)cboalmacen.SelectedItem).desAlmacen);
                ev.RutaImagen = RutaImagen;
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle



                if (TipoOrden == 2)
                {
                    //oReporteStock = oReporteStock.GroupBy(y => y.idArticulo).Select(g => g.First()).OrderBy(x => x.desArticulo).ToList();

                    if (!chkCero.Checked)
                    {
                        List<StockE> oReporteStockAgrupado =
                        (
                            from x in oReporteStock
                            where (x.canStock != Variables.Cero)
                            group x by new { x.idArticulo, x.codArticulo, x.NomEspecie, x.desArticulo, x.nomUMedidaEnv, x.Contenido, x.nomUMedidaPres, x.ValorVentaL1, x.ValorVentaL2, x.ValorVentaL3 }
                            into g
                            select new StockE()
                            {
                                idArticulo = g.Key.idArticulo,
                                codArticulo = g.Key.codArticulo,
                                desArticulo = g.Key.NomEspecie + " " + g.Key.desArticulo,
                                nomUMedidaEnv = g.Key.nomUMedidaEnv,
                                Contenido = g.Key.Contenido,
                                nomUMedidaPres = g.Key.nomUMedidaPres,
                                canStock = g.Sum(x => x.canStock),
                                ValorVentaL1 = g.Key.ValorVentaL1,
                                ValorVentaL2 = g.Key.ValorVentaL2,
                                ValorVentaL3 = g.Key.ValorVentaL3
                            }
                        ).ToList();

                        oReporteStockAgrupado = oReporteStockAgrupado.OrderBy(x => x.desArticulo).ToList();

                        BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo
                        PdfPTable TablaCabDetalle = new PdfPTable(9)
                        {
                            WidthPercentage = 100
                        };

                        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.3f, 0.1f, 0.1f, 0.1f, 0.13f, 0.13f, 0.13f, 0.13f });

                        foreach (StockE item in oReporteStockAgrupado)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//CODIGO
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //DESCRIPCION
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //LOTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2)); //STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//UNIDADMED
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL3.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//U.M.PRESE
                            TablaCabDetalle.CompleteRow();
                        }
                        docPdf.Add(TablaCabDetalle);
                    }
                    else if (chkCero.Checked == true)
                    {
                        List<StockE> oReporteStockAgrupado =
                            (
                              from x in oReporteStock
                              group x by new { x.idArticulo, x.codArticulo, x.NomEspecie, x.desArticulo, x.nomUMedidaEnv, x.Contenido, x.nomUMedidaPres, x.ValorVentaL1, x.ValorVentaL2, x.ValorVentaL3 }
                              into g
                              select new StockE()
                              {
                                  idArticulo = g.Key.idArticulo,
                                  codArticulo = g.Key.codArticulo,
                                  desArticulo = g.Key.NomEspecie + " " + g.Key.desArticulo,
                                  nomUMedidaEnv = g.Key.nomUMedidaEnv,
                                  Contenido = g.Key.Contenido,
                                  nomUMedidaPres = g.Key.nomUMedidaPres,
                                  canStock = g.Sum(x => x.canStock),
                                  ValorVentaL1 = g.Key.ValorVentaL1,
                                  ValorVentaL2 = g.Key.ValorVentaL2,
                                  ValorVentaL3 = g.Key.ValorVentaL3
                              }
                            ).ToList();

                        oReporteStockAgrupado = oReporteStockAgrupado.OrderBy(x => x.desArticulo).ToList();

                        BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo
                        PdfPTable TablaCabDetalle = new PdfPTable(9);
                        TablaCabDetalle.WidthPercentage = 100;
                        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.3f, 0.1f, 0.1f, 0.1f, 0.13f, 0.13f, 0.13f, 0.13f });

                        foreach (StockE item in oReporteStockAgrupado)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//CODIGO
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //DESCRIPCION
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //LOTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2)); //STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//UNIDADMED
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL3.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//U.M.PRESE
                            TablaCabDetalle.CompleteRow();
                        }
                        docPdf.Add(TablaCabDetalle);
                    }
                }
                else if(TipoOrden == 3)
                {
                    if (!chkCero.Checked)
                    {
                        List<StockE> oReporteStockAgrupado =
                        (
                            from x in oReporteStock
                            where (x.canStock != Variables.Cero)
                            group x by new { x.idArticulo, x.codArticulo, x.NomEspecie, x.desArticulo, x.nomUMedidaEnv, x.Contenido, x.nomUMedidaPres, x.ValorVentaL1, x.CostoUnitPromSecu }
                            into g
                            select new StockE()
                            {
                                idArticulo = g.Key.idArticulo,
                                codArticulo = g.Key.codArticulo,
                                desArticulo = g.Key.NomEspecie + " " + g.Key.desArticulo,
                                nomUMedidaEnv = g.Key.nomUMedidaEnv,
                                Contenido = g.Key.Contenido,
                                nomUMedidaPres = g.Key.nomUMedidaPres,
                                canStock = g.Sum(x => x.canStock),
                                ValorVentaL1 = g.Key.ValorVentaL1,
                                Costo = g.Key.CostoUnitPromSecu
                            }
                        ).ToList();

                        oReporteStockAgrupado = oReporteStockAgrupado.OrderBy(x => x.desArticulo).ToList();

                        BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo
                        PdfPTable TablaCabDetalle = new PdfPTable(10)
                        {
                            WidthPercentage = 100
                        };

                        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.3f, 0.1f, 0.1f, 0.1f, 0.13f, 0.13f, 0.13f, 0.13f , 0.13f });

                        foreach (StockE item in oReporteStockAgrupado)
                        {
                            Decimal MargenUtilidad = 0;
                            Decimal UtilidadBruta = 0;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//CODIGO
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //DESCRIPCION
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //LOTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2)); //STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE             
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Costo.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//UNIDADMED
                            MargenUtilidad = item.ValorVentaL1 - item.Costo;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MargenUtilidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//U.M.PRESE

                            if (item.ValorVentaL1 != 0)
                            {
                                UtilidadBruta = (MargenUtilidad / item.ValorVentaL1) * 100;
                            }
                            else
                            {
                                UtilidadBruta = 0;
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(UtilidadBruta.ToString("N2") + " %", null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//U.M.PRESE
                            TablaCabDetalle.CompleteRow();
                        }
                        docPdf.Add(TablaCabDetalle);
                    }
                    else if (chkCero.Checked == true)
                    {
                        List<StockE> oReporteStockAgrupado =
                            (
                              from x in oReporteStock
                              group x by new { x.idArticulo, x.codArticulo, x.NomEspecie, x.desArticulo, x.nomUMedidaEnv, x.Contenido, x.nomUMedidaPres, x.ValorVentaL1, x.CostoUnitPromSecu }
                              into g
                              select new StockE()
                              {
                                  idArticulo = g.Key.idArticulo,
                                  codArticulo = g.Key.codArticulo,
                                  desArticulo = g.Key.NomEspecie + " " + g.Key.desArticulo,
                                  nomUMedidaEnv = g.Key.nomUMedidaEnv,
                                  Contenido = g.Key.Contenido,
                                  nomUMedidaPres = g.Key.nomUMedidaPres,
                                  canStock = g.Sum(x => x.canStock),
                                  ValorVentaL1 = g.Key.ValorVentaL1,
                                  Costo = g.Key.CostoUnitPromSecu
                              }
                            ).ToList();

                        oReporteStockAgrupado = oReporteStockAgrupado.OrderBy(x => x.desArticulo).ToList();

                        BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo
                        PdfPTable TablaCabDetalle = new PdfPTable(10);
                        TablaCabDetalle.WidthPercentage = 100;
                        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.3f, 0.1f, 0.1f, 0.1f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f });

                        foreach (StockE item in oReporteStockAgrupado)
                        {
                            Decimal MargenUtilidad = 0;
                            Decimal UtilidadBruta = 0;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//CODIGO
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //DESCRIPCION
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //LOTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2)); //STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE             
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Costo.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//UNIDADMED
                            MargenUtilidad = item.ValorVentaL1 - item.Costo;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MargenUtilidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//U.M.PRESE

                            if (item.ValorVentaL1 != 0)
                            {
                                UtilidadBruta = (MargenUtilidad / item.ValorVentaL1) * 100;
                            }
                            else
                            {
                                UtilidadBruta = 0;
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(UtilidadBruta.ToString("N2") + " %", null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//U.M.PRESE
                            TablaCabDetalle.CompleteRow();
                        }


                        docPdf.Add(TablaCabDetalle);
                    }
                }

                else if (TipoOrden == 1)
                {
                    BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo
                    PdfPTable TablaCabDetalle = new PdfPTable(11);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.3f, 0.1f, 0.1f, 0.1f, 0.15f, 0.15f, 0.13f, 0.13f, 0.13f, 0.13f });

                    if (chkCero.Checked == false)
                    {
                        foreach (StockE item in oReporteStock)
                        {

                            if (item.canStock != Variables.Cero)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//CODIGO
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.NomEspecie + " " + item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //DESCRIPCION
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1)); //LOTE
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2)); //STOCK
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//STOCK
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//STOCK
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.LoteAlmacen, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), 5, 1));//CONTE
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//UNIDADMED
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//CONTE
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL3.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.canStock < 0 ? ColorLetra : null)), -1, 2));//U.M.PRESE
                                TablaCabDetalle.CompleteRow();
                            }
                        }
                        docPdf.Add(TablaCabDetalle);

                    }
                    else if (chkCero.Checked == true)
                    {

                        foreach (StockE item in oReporteStock)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//CODIGO
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.NomEspecie + " " + item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1)); //DESCRIPCION
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1)); //LOTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2)); //STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//STOCK
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.LoteAlmacen, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.canStock.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2));//UNIDADMED
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2));//CONTE
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorVentaL3.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), -1, 2));//U.M.PRESE
                            TablaCabDetalle.CompleteRow();
                        }
                        docPdf.Add(TablaCabDetalle);

                    }
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
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String nombreMes = cboMes.Text;

            TituloGeneral = " Stock Alt. " + Anio + " - " + nombreMes;
            NombrePestaña = " Stock Alt. ";

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

                    // PRIMERA
                    if (TipoOrden == 1)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = " CODIGO ";
                        oHoja.Cells[InicioLinea, 2].Value = "DESCRIPCION";
                        oHoja.Cells[InicioLinea, 3].Value = "UND. MEDIDA";
                        oHoja.Cells[InicioLinea, 4].Value = "CONTENIDO";

                        oHoja.Cells[InicioLinea, 5].Value = "PRESENT.";
                        oHoja.Cells[InicioLinea, 6].Value = "LOTE PROVEED.";
                        oHoja.Cells[InicioLinea, 7].Value = "LOTE ALMACEN";

                        oHoja.Cells[InicioLinea, 8].Value = "STOCK";

                        oHoja.Cells[InicioLinea, 9].Value = "L.P(Distrib.)";

                        oHoja.Cells[InicioLinea, 10].Value = "L.P(Público)";
                        oHoja.Cells[InicioLinea, 11].Value = "L.P(VG)";


                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }
                    else if(TipoOrden == 2)
                    {

  

                        TotColumnas = 9;
                        oHoja.Cells[InicioLinea, 1].Value = " CODIGO ";
                        oHoja.Cells[InicioLinea, 2].Value = "DESCRIPCION";
                        oHoja.Cells[InicioLinea, 3].Value = "UND. MEDIDA";
                        oHoja.Cells[InicioLinea, 4].Value = "CONTENIDO";

                        oHoja.Cells[InicioLinea, 5].Value = "PRESENT.";

                        oHoja.Cells[InicioLinea, 6].Value = "STOCK";

                        oHoja.Cells[InicioLinea, 7].Value = "L.P(Distrib.)";

                        oHoja.Cells[InicioLinea, 8].Value = "L.P(Público)";
                        oHoja.Cells[InicioLinea, 9].Value = "L.P(VG)";


                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }
                    else if (TipoOrden == 3)
                    {
                        TotColumnas = 10;
                        oHoja.Cells[InicioLinea, 1].Value = " CODIGO ";
                        oHoja.Cells[InicioLinea, 2].Value = "DESCRIPCION";
                        oHoja.Cells[InicioLinea, 3].Value = "UND. MEDIDA";
                        oHoja.Cells[InicioLinea, 4].Value = "CONTENIDO";
                        oHoja.Cells[InicioLinea, 5].Value = "PRESENT.";
                        oHoja.Cells[InicioLinea, 6].Value = "STOCK";
                        oHoja.Cells[InicioLinea, 7].Value = "COSTO";
                        oHoja.Cells[InicioLinea, 8].Value = "L.P.(DISTRIB.)";
                        oHoja.Cells[InicioLinea, 9].Value = "MAR. UTILIZADA";
                        oHoja.Cells[InicioLinea, 10].Value = "% UTILIDAD BRUTA";    


                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }


                    //Aumentando una Fila mas continuar con el detalle


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle

                    if (TipoOrden == 1)
                    {

                     

                        foreach (StockE item in oReporteStock)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 2].Value = item.NomEspecie + ' ' + item.desArticulo;
                            oHoja.Cells[InicioLinea, 3].Value = item.nomUMedidaEnv;

                            oHoja.Cells[InicioLinea, 4].Value = item.Contenido;
                            oHoja.Cells[InicioLinea, 5].Value = item.nomUMedidaPres;
                            oHoja.Cells[InicioLinea, 6].Value = item.Lote;

                            oHoja.Cells[InicioLinea, 7].Value = item.LoteAlmacen;
                            oHoja.Cells[InicioLinea, 8].Value = item.canStock;

                            oHoja.Cells[InicioLinea, 9].Value = item.ValorVentaL1;
                            oHoja.Cells[InicioLinea, 10].Value = item.ValorVentaL2;

                            oHoja.Cells[InicioLinea, 11].Value = item.ValorVentaL3;

                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.000";
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.000";
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.0000";
                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.0000";
                            InicioLinea++;

                        }
                    }

                    if (TipoOrden == 2)
                    {
                        List<StockE> oReporteStockAgrupado =
                    (
                      from x in oReporteStock
                      where (x.canStock >= Variables.Cero)
                      group x by new { x.idArticulo, x.codArticulo, x.NomEspecie, x.desArticulo, x.nomUMedidaEnv, x.Contenido, x.nomUMedidaPres, x.ValorVentaL1, x.ValorVentaL2, x.ValorVentaL3 }
                      into g
                      select new StockE()
                      {
                          idArticulo = g.Key.idArticulo,
                          codArticulo = g.Key.codArticulo,
                          desArticulo = g.Key.NomEspecie + " " + g.Key.desArticulo,
                          nomUMedidaEnv = g.Key.nomUMedidaEnv,
                          Contenido = g.Key.Contenido,
                          nomUMedidaPres = g.Key.nomUMedidaPres,
                          canStock = g.Sum(x => x.canStock),
                          ValorVentaL1 = g.Key.ValorVentaL1,
                          ValorVentaL2 = g.Key.ValorVentaL2,
                          ValorVentaL3 = g.Key.ValorVentaL3
                      }
                    ).ToList();

                        oReporteStockAgrupado = oReporteStockAgrupado.OrderBy(x => x.desArticulo).ToList();
                        foreach (StockE item in oReporteStockAgrupado)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                            oHoja.Cells[InicioLinea, 3].Value = item.nomUMedidaEnv;

                            oHoja.Cells[InicioLinea, 4].Value = item.Contenido;
                            oHoja.Cells[InicioLinea, 5].Value = item.nomUMedidaPres;
                            oHoja.Cells[InicioLinea, 6].Value = item.canStock;

                            oHoja.Cells[InicioLinea, 7].Value = item.ValorVentaL1;
                            oHoja.Cells[InicioLinea, 8].Value = item.ValorVentaL2;

                            oHoja.Cells[InicioLinea, 9].Value = item.ValorVentaL3;

                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.000";
                            oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.000";
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.0000";
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.0000";
                            InicioLinea++;

                        }
                    }


                    if (TipoOrden == 3)
                    {
                        List<StockE> oReporteStockAgrupado =
                    (
                      from x in oReporteStock
                      where (x.canStock >= Variables.Cero)
                      group x by new { x.idArticulo, x.codArticulo, x.NomEspecie, x.desArticulo, x.nomUMedidaEnv, x.Contenido, x.nomUMedidaPres, x.ValorVentaL1, x.CostoUnitPromSecu }
                      into g
                      select new StockE()
                      {
                          idArticulo = g.Key.idArticulo,
                          codArticulo = g.Key.codArticulo,
                          desArticulo = g.Key.NomEspecie + " " + g.Key.desArticulo,
                          nomUMedidaEnv = g.Key.nomUMedidaEnv,
                          Contenido = g.Key.Contenido,
                          nomUMedidaPres = g.Key.nomUMedidaPres,
                          canStock = g.Sum(x => x.canStock),
                          ValorVentaL1 = g.Key.ValorVentaL1,
                          Costo = g.Key.CostoUnitPromSecu
                      }
                    ).ToList();

                        oReporteStockAgrupado = oReporteStockAgrupado.OrderBy(x => x.desArticulo).ToList();
                        foreach (StockE item in oReporteStockAgrupado)
                        {
                            Decimal MargenUtilidad = 0;
                            Decimal UtilidadBruta = 0;

                            oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                            oHoja.Cells[InicioLinea, 3].Value = item.nomUMedidaEnv;

                            oHoja.Cells[InicioLinea, 4].Value = item.Contenido;
                            oHoja.Cells[InicioLinea, 5].Value = item.nomUMedidaPres;
                            oHoja.Cells[InicioLinea, 6].Value = item.canStock;

                            oHoja.Cells[InicioLinea, 7].Value = item.Costo;
                            oHoja.Cells[InicioLinea, 8].Value = item.ValorVentaL1;

                            MargenUtilidad = item.ValorVentaL1 - item.Costo;
                          
                            if (item.ValorVentaL1 != 0)
                            {
                                UtilidadBruta = (MargenUtilidad / item.ValorVentaL1) * 100;
                            }
                            else
                            {
                                UtilidadBruta = 0;
                            }


                            oHoja.Cells[InicioLinea, 9].Value = MargenUtilidad;
                            oHoja.Cells[InicioLinea, 10].Value = UtilidadBruta;

                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.000";
                            oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.000";
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea,10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;


                        }
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

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Stock Mensuales VS Lista de Precios ", "Archivos Excel (*.xlsx)|*.xlsx");

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
            if (tipo == "buscar")
            {
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String Mes = Convert.ToString(cboMes.SelectedValue);
                Int32 Almacen = Convert.ToInt32(cboalmacen.SelectedValue);
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
                oReporteStock = AgenteAlmacen.Proxy.ListarReporteStockMensual(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Almacen, Anio, Mes, indfecha, Fecha);
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

        private void frmReporteStockMensual_Load(object sender, EventArgs e)
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
            cmsImprimir.Show(btBuscar, new Point(0, btBuscar.Height));
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

        private void stockMensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TipoOrden = 1;
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

        private void stockMensualPorArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TipoOrden = 2;
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

        private void chkCero_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    tipo = "buscar";
            //    pbProgress.Visible = true;
            //    lblProcesando.Visible = true;
            //    Cursor = Cursors.WaitCursor;
            //    panel3.Cursor = Cursors.WaitCursor;
            //    btBuscar.Enabled = false;

            //    Global.QuitarReferenciaWebBrowser(wbNavegador);

            //    _bw.RunWorkerAsync();
            //}
            //catch (Exception ex)
            //{
            //    btBuscar.Enabled = true;
            //    Global.MensajeError(ex.Message);
            //}
        }

        private void stockMensualPorArticuloConCostoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TipoOrden = 3;
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

        #endregion


    }
}

#region Pdf Inicio

class PaginaInicioStocksvsListaPrecio : PdfPageEventHelper
{

    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreAlmacen { get; set; }
    public String RutaImagen { get; set; }
    public Int32 IndFecha { get; set; }
    public DateTime FechaStock { get; set; }
    public Int32 TipoOrden_ { get; set; }

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

        if (IndFecha == 0)
        {
            SubTitulo = "AÑO: " + Anio + " MES: " + NombreMes;
        }
        else
        {
            SubTitulo = "Stock al : " + FechaStock.ToString("d");
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


        if (TipoOrden_ == 1)
        {
            PdfPTable TablaCabDetalle = new PdfPTable(11);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.3f, 0.1f, 0.1f, 0.1f, 0.15f, 0.15f, 0.13f, 0.13f, 0.13f, 0.13f });

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UND. MEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONTENIDO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PRESENT.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE PROVEED.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE ALMACEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("STOCK", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("L.P(Distrib.)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("L.P(Público)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("L.P(VG)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.CompleteRow();
            document.Add(TablaCabDetalle);
        }



        if(TipoOrden_ == 2)
        {
            PdfPTable TablaCabDetalle = new PdfPTable(9);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.3f, 0.1f, 0.1f, 0.1f, 0.13f, 0.13f, 0.13f, 0.13f });

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UND. MEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONTENIDO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PRESENT.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("STOCK", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("L.P(Distrib.)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("L.P(Público)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("L.P(VG)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.CompleteRow();
            document.Add(TablaCabDetalle);
        }

        if (TipoOrden_ == 3)
        {
            PdfPTable TablaCabDetalle = new PdfPTable(10);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.3f, 0.1f, 0.1f, 0.1f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f });

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UND. MEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONTENIDO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PRESENT.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("STOCK", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COSTO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("L.P.(DISTRIB.)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MAR. UTILIZADA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("% UTILIDAD BRUTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.CompleteRow();
            document.Add(TablaCabDetalle);
        }

        #endregion

        //Añadiendo la tabla al documento PDF

    }
}

#endregion