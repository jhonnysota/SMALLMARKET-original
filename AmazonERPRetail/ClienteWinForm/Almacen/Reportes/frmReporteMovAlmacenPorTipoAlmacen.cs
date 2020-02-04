using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteMovAlmacenPorTipoAlmacen : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteMovAlmacenPorTipoAlmacen()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<MovimientoAlmacenE> ListaMovimientos = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String AdquirirRutaGeneral = String.Empty;

        #endregion

        #region Procedimiento de Usuario

        void LlenarCombos()
        {
            List<ParTabla> ListarTipoMovimiento = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPMOVALM");
            ComboHelper.RellenarCombos<ParTabla>(cboTipoMovimiento, (from x in ListarTipoMovimiento
                                                                     where (x.NemoTecnico == "EG" || x.NemoTecnico == "EGR") ||
                                                                           (x.NemoTecnico == "IN" || x.NemoTecnico == "ING")
                                                                     orderby x.IdParTabla
                                                                     select x).ToList(), "IdParTabla", "Nombre", false);

            //cboTipoMovimiento_SelectionChangeCommitted(new object(), new EventArgs());

            //Tipo de Articulos
            List<ParTabla> ListaTipos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaTipos.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaTipos orderby x.IdParTabla select x).ToList());
        }

        void LlenarOperaciones()
        {
            try
            {
                List<OperacionE> ListaOp = AgenteAlmacen.Proxy.ListarOperacionPorTipoArticulo(Convert.ToInt32(cboTipoAlmacen.SelectedValue), VariablesLocales.SesionLocal.IdEmpresa, Convert.ToInt32(cboTipoMovimiento.SelectedValue));
                ListaOp.Add(new OperacionE { idOperacion = Variables.Cero, desOperacion = Variables.Todos });
                ComboHelper.RellenarCombos<OperacionE>(cboOperaciones, (from x in ListaOp orderby x.desOperacion select x).ToList(), "idOperacion", "desOperacion", false);

                if (Convert.ToInt32(cboTipoAlmacen.SelectedValue) > 0)
                {
                    if (ListaOp.Count == 1)
                    {
                        cboOperaciones.Enabled = false;
                    }
                    else if (ListaOp.Count == 2)
                    {
                        cboOperaciones.Enabled = false;
                        cboOperaciones.SelectedIndex = 1;
                    }
                    else
                    {
                        cboOperaciones.Enabled = true;
                    } 
                }
                else
                {
                    cboOperaciones.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ConvertirApdf(List<MovimientoAlmacenE> Reporte)
        {
            Document docPdf = new Document(PageSize.A3.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Movimiento de Almacen " + Aleatorio.ToString();
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
                // Para la creación del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    #region Variables

                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);
                    PdfPTable TablaCabDetalle = null;

                    BaseColor FontColorSub = new BaseColor(Color.Navy);
                    BaseColor FontColorTot = new BaseColor(Color.DarkGreen);
                    iTextSharp.text.Font LetraDet = FontFactory.GetFont("Arial", 6.25f);
                    iTextSharp.text.Font LetraDetNegrita = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, FontColorSub);
                    iTextSharp.text.Font LetraDetNegritaTot = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, FontColorTot);
                    iTextSharp.text.Font LetraPrecio = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.RED);

                    float[] AnchoColumnas = new float[] { 0.12f, 0.05f, 0.04f, 0.023f, 0.017f, 0.05f, 0.05f, 0.04f, 0.035f, 0.05f, 0.22f, 0.027f, 0.056f, 0.056f, 0.056f, 0.056f, 0.056f, 0.056f, 0.056f, 0.056f, 0.025f, 0.04f };
                    Int32 Columnas = 22;
                    Decimal totColMovS = 0; //Total de la columna CostoMovS
                    Decimal totColMovD = 0; //Total de la columna CostoMovD
                    Decimal TotalColMovS = 0; //Total de la columna CostoTotalMovS
                    Decimal TotalColMovD = 0; //Total de la columna CostoTotalMovD

                    Decimal totColKarS = 0; //Total de la columna CostoKarS
                    Decimal totColKarD = 0; //Total de la columna CostoKarD
                    Decimal TotalColKarS = 0; //Total de la columna CostoTotalKarS
                    Decimal TotalColKarD = 0; //Total de la columna CostoTotalKarD

                    Decimal totGenColMovS = 0; //Total general de la columna CostoMovS
                    Decimal totGenColMovD = 0; //Total general de la columna CostoMovD
                    Decimal TotalGenColMovS = 0; //Total general de la columna CostoTotalMovS
                    Decimal TotalGenColMovD = 0; //Total general de la columna CostoTotalMovD

                    Decimal totColKarGenS = 0; //Total general de la columna CostoKarS
                    Decimal totColKarGenD = 0; //Total general de la columna CostoKarD
                    Decimal TotalGenColKarS = 0; //Total general de la columna CostoTotalKarS
                    Decimal TotalGenColKarD = 0; //Total general de la columna CostoTotalKarD

                    #endregion

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    //Total de columnas
                    TablaCabDetalle = new PdfPTable(Columnas)
                    {
                        WidthPercentage = 100
                    };

                    //Total de anchos para las columnas
                    TablaCabDetalle.SetWidths(AnchoColumnas);

                    //Parámetros que pasará al inicio del PDF
                    oPdfw.PageEvent = new PagInicioMovAlmacenDeta
                    {
                        tipArticulo = ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre,
                        Periodo = ((ParTabla)cboTipoMovimiento.SelectedItem).Nombre + " Del " + dtpInicio.Value.ToString("dd/MM/yyyy") + " al " + dtpFinal.Value.ToString("dd/MM/yyyy"),
                        AnchoCols = AnchoColumnas,
                        Columnas = Columnas
                    };

                    docPdf.Open();

                    //Lista agrupado por Documento de Almacén
                    List<MovimientoAlmacenE> ListaTipoMovAgrupado = Reporte.GroupBy(x => x.idDocumentoAlmacen).Select(p => p.First()).ToList();

                    foreach (MovimientoAlmacenE item in ListaTipoMovAgrupado)
                    {
                        //Creando nueva lista por documento de almacén
                        List<MovimientoAlmacenE> ListaItemsDocumentos = Reporte.Where(z => z.idDocumentoAlmacen == item.idDocumentoAlmacen).ToList();
                        Int32 TotFilMerge = ListaItemsDocumentos.Count;

                        //Añadiendo las primeras columnas
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desOperacion, null, "N", null, LetraDet, 5, 0, "N", "S" + TotFilMerge.ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Correlativo, null, "N", null, LetraDet, 5, 1, "N", "S" + TotFilMerge.ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(item.fecProceso).ToString("dd/MM/yyyy"), null, "N", null, LetraDet, 5, 1, "N", "S" + TotFilMerge.ToString()));

                        //Recorriendo la lista
                        foreach (MovimientoAlmacenE itemDet in ListaItemsDocumentos)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.numItem, null, "N", null, LetraDet, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((itemDet.idDocumento == "0" ? String.Empty : itemDet.idDocumento), null, "N", null, LetraDet, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.serDocumento, null, "N", null, LetraDet, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.numDocumento, null, "N", null, LetraDet, 5, 0));
                            //Por revisar//TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((itemDet.fecDocumento == null ? String.Empty : itemDet.fecDocumento.Value.ToString("dd/MM/yyyy")), null, "N", null, LetraDet, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.Lote, null, "N", null, LetraDet, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.codArticulo, null, "N", null, LetraDet, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.nomArticulo, null, "N", null, LetraDet, 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.Cantidad.ToString("N2"), null, "N", null, LetraDet, 5, 2));
                            //Movimiento
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.CostoMovS.ToString("N6"), null, "N", null, LetraDet, 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.CostoMovD.ToString("N6"), null, "N", null, LetraDet, 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.CostoTotalMovS.ToString("N6"), null, "N", null, LetraDet, 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.CostoTotalMovD.ToString("N6"), null, "N", null, LetraDet, 5, 2));
                            //Kárdex
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.CostoKarS.ToString("N6"), null, "N", null, LetraDet, 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.CostoKarD.ToString("N6"), null, "N", null, LetraDet, 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.CostoTotalKarS.ToString("N6"), null, "N", null, LetraDet, 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.CostoTotalKarD.ToString("N6"), null, "N", null, LetraDet, 5, 2));

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.desMonedaPrecio, null, "N", null, (itemDet.VaEnRojo == true ? LetraPrecio : LetraDet), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemDet.Precio.ToString("N6"), null, "N", null, (itemDet.VaEnRojo == true ? LetraPrecio : LetraDet), 5, 2));

                            //Sumando para la fila de total por documento
                            totColMovS += Decimal.Round(itemDet.CostoMovS, 6, MidpointRounding.AwayFromZero);
                            totColMovD += Decimal.Round(itemDet.CostoMovD, 6, MidpointRounding.AwayFromZero);
                            TotalColMovS += Decimal.Round(itemDet.CostoTotalMovS, 6, MidpointRounding.AwayFromZero);
                            TotalColMovD += Decimal.Round(itemDet.CostoTotalMovD, 6, MidpointRounding.AwayFromZero);

                            totColKarS += Decimal.Round(itemDet.CostoKarS, 6, MidpointRounding.AwayFromZero);
                            totColKarD += Decimal.Round(itemDet.CostoKarD, 6, MidpointRounding.AwayFromZero);
                            TotalColKarS += Decimal.Round(itemDet.CostoTotalKarS, 6, MidpointRounding.AwayFromZero);
                            TotalColKarD += Decimal.Round(itemDet.CostoTotalKarD, 6, MidpointRounding.AwayFromZero);

                            TablaCabDetalle.CompleteRow();
                        }

                        //Total Movimiento
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL DOCUMENTO >>>>>>>>>>> ", null, "S", FontColorSub, LetraDetNegrita, 5, 2, "S" + (Columnas - 10).ToString(), "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totColMovS.ToString("N6"), null, "S", FontColorSub, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totColMovD.ToString("N6"), null, "S", FontColorSub, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalColMovS.ToString("N6"), null, "S", FontColorSub, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalColMovD.ToString("N6"), null, "S", FontColorSub, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totColKarS.ToString("N6"), null, "S", FontColorSub, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totColKarD.ToString("N6"), null, "S", FontColorSub, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalColKarS.ToString("N6"), null, "S", FontColorSub, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalColKarD.ToString("N6"), null, "S", FontColorSub, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f));

                        TablaCabDetalle.CompleteRow();

                        //Linea en blanco
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraDetNegrita, 5, 2, "S" + Columnas.ToString(), "N", 3f, 3f));
                        TablaCabDetalle.CompleteRow();

                        //Sumando para el total general
                        totGenColMovS += Decimal.Round(totColMovS, 6, MidpointRounding.AwayFromZero);
                        totGenColMovD += Decimal.Round(totColMovD, 6, MidpointRounding.AwayFromZero);
                        TotalGenColMovS += Decimal.Round(TotalColMovS, 6, MidpointRounding.AwayFromZero);
                        TotalGenColMovD += Decimal.Round(TotalColMovD, 6, MidpointRounding.AwayFromZero);
                        totColKarGenS += Decimal.Round(totColKarS, 6, MidpointRounding.AwayFromZero);
                        totColKarGenD += Decimal.Round(totColKarD, 6, MidpointRounding.AwayFromZero);
                        TotalGenColKarS += Decimal.Round(TotalColKarS, 6, MidpointRounding.AwayFromZero);
                        TotalGenColKarD += Decimal.Round(TotalColKarD, 6, MidpointRounding.AwayFromZero);

                        //Limpiando las variables del detalle
                        totColMovS = 0;
                        totColMovD = 0;
                        TotalColMovS = 0;
                        TotalColMovD = 0;
                        totColKarS = 0;
                        totColKarD = 0;
                        TotalColKarS = 0;
                        TotalColKarD = 0;
                    }

                    #region Total General

                    //Total Movimiento
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL >>>>>>>>>>> ", null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "S" + (Columnas - 10).ToString(), "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGenColMovS.ToString("N6"), null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGenColMovD.ToString("N6"), null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGenColMovS.ToString("N6"), null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGenColMovD.ToString("N6"), null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totColKarGenS.ToString("N6"), null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totColKarGenD.ToString("N6"), null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGenColKarS.ToString("N6"), null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGenColKarD.ToString("N6"), null, "S", FontColorTot, LetraDetNegritaTot, 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraDetNegrita, 5, 2, "N", "N", 3f, 3f));

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
                }
            }
        }

        void ExportarExcel(List<MovimientoAlmacenE> Reporte, String Ruta)
        {
            #region Variables

            String NombrePestaña = "Movimientos";

            #endregion

            //Creando el directorio si existe...
            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo NuevoArchivo = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(NuevoArchivo))
            {
                using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña))
                {
                    #region Variables

                    String TituloGeneral = "MOVIMIENTO DE ALMACEN POR TIPO DE ARTICULO - " + ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre;
                    String SubTitulos = "(" + ((ParTabla)cboTipoMovimiento.SelectedItem).Nombre + " Del " + dtpInicio.Value.ToString("dd/MM/yyyy") + " al " + dtpFinal.Value.ToString("dd/MM/yyyy") + ")";
                    Int32 totCols = 22;
                    Int32 FilaIni = 4;
                    Color col1 = Color.FromArgb(191, 191, 191);
                    Color col2 = Color.FromArgb(132, 151, 176);

                    Decimal totColMovS = 0; //Total de la columna CostoMovS
                    Decimal totColMovD = 0; //Total de la columna CostoMovD
                    Decimal TotalColMovS = 0; //Total de la columna CostoTotalMovS
                    Decimal TotalColMovD = 0; //Total de la columna CostoTotalMovD

                    Decimal totColKarS = 0; //Total de la columna CostoKarS
                    Decimal totColKarD = 0; //Total de la columna CostoKarD
                    Decimal TotalColKarS = 0; //Total de la columna CostoTotalKarS
                    Decimal TotalColKarD = 0; //Total de la columna CostoTotalKarD

                    Decimal totGenColMovS = 0; //Total general de la columna CostoMovS
                    Decimal totGenColMovD = 0; //Total general de la columna CostoMovD
                    Decimal TotalGenColMovS = 0; //Total general de la columna CostoTotalMovS
                    Decimal TotalGenColMovD = 0; //Total general de la columna CostoTotalMovD

                    Decimal totColKarGenS = 0; //Total general de la columna CostoKarS
                    Decimal totColKarGenD = 0; //Total general de la columna CostoKarD
                    Decimal TotalGenColKarS = 0; //Total general de la columna CostoTotalKarS
                    Decimal TotalGenColKarD = 0; //Total general de la columna CostoTotalKarD

                    #endregion

                    #region Titulos

                    if (Convert.ToInt32(cboTipoAlmacen.SelectedValue) == 0)
                    {
                        TituloGeneral = TituloGeneral.Replace("<<", "").Replace(">>", "").Trim();
                    }

                    oHoja.Cells["A1"].Value = TituloGeneral;
                    oHoja.Row(1).Height = 30;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totCols])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    oHoja.Cells["A2"].Value = SubTitulos;
                    oHoja.Row(2).Height = 16;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, totCols])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 11, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    #endregion

                    #region Cabecera del Detalle

                    oHoja.Row(FilaIni).Height = 20;
                    oHoja.Row(FilaIni + 1).Height = 20;

                    oHoja.Cells[FilaIni, 1, FilaIni + 1, 1].Merge = true;
                    oHoja.Cells[FilaIni, 1, FilaIni + 1, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 1].Value = "OPERACION";
                    oHoja.Cells[FilaIni, 2, FilaIni + 1, 2].Merge = true;
                    oHoja.Cells[FilaIni, 2, FilaIni + 1, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 2].Value = "COD.ALMACEN";
                    oHoja.Cells[FilaIni, 3, FilaIni + 1, 3].Merge = true;
                    oHoja.Cells[FilaIni, 3, FilaIni + 1, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 3].Value = "FEC.PROC.";
                    oHoja.Cells[FilaIni, 4, FilaIni + 1, 4].Merge = true;
                    oHoja.Cells[FilaIni, 4, FilaIni + 1, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 4].Value = "ITEM";
                    oHoja.Cells[FilaIni, 5, FilaIni + 1, 5].Merge = true;
                    oHoja.Cells[FilaIni, 5, FilaIni + 1, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 5].Value = "T.D.";
                    oHoja.Cells[FilaIni, 6, FilaIni + 1, 6].Merge = true;
                    oHoja.Cells[FilaIni, 6, FilaIni + 1, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 6].Value = "SERIE";
                    oHoja.Cells[FilaIni, 7, FilaIni + 1, 7].Merge = true;
                    oHoja.Cells[FilaIni, 7, FilaIni + 1, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 7].Value = "NUMERO";
                    oHoja.Cells[FilaIni, 8, FilaIni + 1, 8].Merge = true;
                    oHoja.Cells[FilaIni, 8, FilaIni + 1, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 8].Value = "FEC.DOCU.";
                    oHoja.Cells[FilaIni, 9, FilaIni + 1, 9].Merge = true;
                    oHoja.Cells[FilaIni, 9, FilaIni + 1, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 9].Value = "LOTE";
                    oHoja.Cells[FilaIni, 10, FilaIni + 1, 10].Merge = true;
                    oHoja.Cells[FilaIni, 10, FilaIni + 1, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 10].Value = "COD.ARTICULO";
                    oHoja.Cells[FilaIni, 11, FilaIni + 1, 11].Merge = true;
                    oHoja.Cells[FilaIni, 11, FilaIni + 1, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 11].Value = "ARTICULO";
                    oHoja.Cells[FilaIni, 12, FilaIni + 1, 12].Merge = true;
                    oHoja.Cells[FilaIni, 12, FilaIni + 1, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 12].Value = "CANTIDAD";
                    oHoja.Cells[FilaIni, 13, FilaIni, 16].Merge = true;
                    oHoja.Cells[FilaIni, 13, FilaIni, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 13].Value = "COSTO MOVIMIENTO ALMACEN";
                    oHoja.Cells[FilaIni, 17, FilaIni, 20].Merge = true;
                    oHoja.Cells[FilaIni, 17, FilaIni, 20].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 17].Value = "COSTO MOVIMIENTO KARDEX";

                    oHoja.Cells[FilaIni + 1, 13].Value = "S/";
                    oHoja.Cells[FilaIni + 1, 14].Value = "US$";
                    oHoja.Cells[FilaIni + 1, 15].Value = "Total S/";
                    oHoja.Cells[FilaIni + 1, 16].Value = "Total US$";
                    oHoja.Cells[FilaIni + 1, 17].Value = "S/";
                    oHoja.Cells[FilaIni + 1, 18].Value = "US$";
                    oHoja.Cells[FilaIni + 1, 19].Value = "Total S/";
                    oHoja.Cells[FilaIni + 1, 20].Value = "Total US$";

                    oHoja.Cells[FilaIni, 21, FilaIni + 1, 21].Merge = true;
                    oHoja.Cells[FilaIni, 21, FilaIni + 1, 21].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 21].Value = "MON.MER.";

                    oHoja.Cells[FilaIni, 22, FilaIni + 1, 22].Merge = true;
                    oHoja.Cells[FilaIni, 22, FilaIni + 1, 22].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[FilaIni, 22].Value = "PRECIO MERCADO";

                    #region Formateo de Cabeceras

                    for (int i = 1; i <= totCols; i++)
                    {
                        oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[FilaIni, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[FilaIni, i].Style.WrapText = true;

                        if (i <= 16)
                        {
                            oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(col1);

                            if (i == 13 || i == 14 || i == 15 || i == 16)
                            {
                                //Ultima fila de la cabecera
                                oHoja.Cells[FilaIni + 1, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[FilaIni + 1, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                oHoja.Cells[FilaIni + 1, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                oHoja.Cells[FilaIni + 1, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                oHoja.Cells[FilaIni + 1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[FilaIni + 1, i].Style.Fill.BackgroundColor.SetColor(col1);
                            }
                        }
                        else
                        {
                            if (i == 21 || i == 22)
                            {
                                oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(146, 208, 80));
                            }
                            else
                            {
                                oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(col2);
                            }

                            //Ultima fila de la cabecera
                            oHoja.Cells[FilaIni + 1, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[FilaIni + 1, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[FilaIni + 1, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            oHoja.Cells[FilaIni + 1, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[FilaIni + 1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[FilaIni + 1, i].Style.Fill.BackgroundColor.SetColor(col2);
                        }
                    }

                    #endregion

                    #region Ancho de Columnas

                    oHoja.Column(1).Width = 20; //Operación
                    oHoja.Column(2).Width = 13; //Cód de almacén
                    oHoja.Column(3).Width = 9; //Fecha de proceso
                    oHoja.Column(4).Width = 5; //Item
                    oHoja.Column(5).Width = 4; //Tipo de documento
                    oHoja.Column(6).Width = 5; //Serie
                    oHoja.Column(7).Width = 9; //Número
                    oHoja.Column(8).Width = 9; //Fecha del documento
                    oHoja.Column(9).Width = 10; //Lote
                    oHoja.Column(10).Width = 13; //Cód de articulo
                    oHoja.Column(11).Width = 50; //Articulo
                    oHoja.Column(12).Width = 8.8; //cantidad

                    for (int i = 13; i < totCols - 1; i++)
                    {
                        oHoja.Column(i).Width = 14;
                    }

                    oHoja.Column(21).Width = 8; //Precio
                    oHoja.Column(22).Width = 10; //Precio

                    #endregion

                    #endregion

                    FilaIni += 2;

                    //Lista agrupado por Documento de Almacén
                    List<MovimientoAlmacenE> ListaTipoMovAgrupado = Reporte.GroupBy(x => x.idDocumentoAlmacen).Select(p => p.First()).ToList();

                    foreach (MovimientoAlmacenE item in ListaTipoMovAgrupado)
                    {
                        //Creando nueva lista por documento de almacén
                        List<MovimientoAlmacenE> ListaItemsDocumentos = Reporte.Where(z => z.idDocumentoAlmacen == item.idDocumentoAlmacen).ToList();
                        Int32 TotFilMerge = ListaItemsDocumentos.Count;

                        //Añadiendo las primeras columnas
                        oHoja.Cells[FilaIni, 1, FilaIni + (TotFilMerge - 1), 1].Merge = true;
                        oHoja.Cells[FilaIni, 1, FilaIni + (TotFilMerge - 1), 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[FilaIni, 1, FilaIni + (TotFilMerge - 1), 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[FilaIni, 1, FilaIni + (TotFilMerge - 1), 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[FilaIni, 1].Value = item.desOperacion;
                        oHoja.Cells[FilaIni, 2, FilaIni + (TotFilMerge - 1), 2].Merge = true;
                        oHoja.Cells[FilaIni, 2, FilaIni + (TotFilMerge - 1), 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[FilaIni, 2, FilaIni + (TotFilMerge - 1), 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[FilaIni, 2, FilaIni + (TotFilMerge - 1), 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[FilaIni, 2].Value = item.Correlativo;
                        oHoja.Cells[FilaIni, 3, FilaIni + (TotFilMerge - 1), 3].Merge = true;
                        oHoja.Cells[FilaIni, 3, FilaIni + (TotFilMerge - 1), 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        oHoja.Cells[FilaIni, 3, FilaIni + (TotFilMerge - 1), 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[FilaIni, 3, FilaIni + (TotFilMerge - 1), 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[FilaIni, 3, FilaIni + (TotFilMerge - 1), 3].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[FilaIni, 3].Value = item.fecProceso;

                        //Recorriendo la lista
                        foreach (MovimientoAlmacenE itemDet in ListaItemsDocumentos)
                        {
                            oHoja.Cells[FilaIni, 4].Value = itemDet.numItem;
                            oHoja.Cells[FilaIni, 5].Value = itemDet.idDocumento.Trim() == "0" ? String.Empty : itemDet.idDocumento;
                            oHoja.Cells[FilaIni, 6].Value = itemDet.serDocumento;
                            oHoja.Cells[FilaIni, 7].Value = itemDet.numDocumento;
                            oHoja.Cells[FilaIni, 8].Value = itemDet.fecDocumento;
                            oHoja.Cells[FilaIni, 9].Value = itemDet.Lote;
                            oHoja.Cells[FilaIni, 10].Value = itemDet.codArticulo;
                            oHoja.Cells[FilaIni, 11].Value = itemDet.nomArticulo;
                            oHoja.Cells[FilaIni, 12].Value = itemDet.Cantidad;

                            oHoja.Cells[FilaIni, 13].Value = itemDet.CostoMovS;
                            oHoja.Cells[FilaIni, 14].Value = itemDet.CostoMovD;
                            oHoja.Cells[FilaIni, 15].Value = itemDet.CostoTotalMovS;
                            oHoja.Cells[FilaIni, 16].Value = itemDet.CostoTotalMovD;

                            oHoja.Cells[FilaIni, 17].Value = itemDet.CostoKarS;
                            oHoja.Cells[FilaIni, 18].Value = itemDet.CostoKarD;
                            oHoja.Cells[FilaIni, 19].Value = itemDet.CostoTotalKarS;
                            oHoja.Cells[FilaIni, 20].Value = itemDet.CostoTotalKarD;

                            oHoja.Cells[FilaIni, 21].Value = itemDet.desMonedaPrecio;
                            oHoja.Cells[FilaIni, 22].Value = itemDet.Precio;

                            totColMovS += Decimal.Round(itemDet.CostoMovS, 6, MidpointRounding.AwayFromZero);
                            totColMovD += Decimal.Round(itemDet.CostoMovD, 6, MidpointRounding.AwayFromZero);
                            TotalColMovS += Decimal.Round(itemDet.CostoTotalMovS, 6, MidpointRounding.AwayFromZero);
                            TotalColMovD += Decimal.Round(itemDet.CostoTotalMovD, 6, MidpointRounding.AwayFromZero);

                            totColKarS += Decimal.Round(itemDet.CostoKarS, 6, MidpointRounding.AwayFromZero);
                            totColKarD += Decimal.Round(itemDet.CostoKarD, 6, MidpointRounding.AwayFromZero);
                            TotalColKarS += Decimal.Round(itemDet.CostoTotalKarS, 6, MidpointRounding.AwayFromZero);
                            TotalColKarD += Decimal.Round(itemDet.CostoTotalKarD, 6, MidpointRounding.AwayFromZero);

                            #region Formateo de columnas

                            for (int i = 4; i <= totCols; i++)
                            {
                                oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                                if (i == 4 || i == 5 || i == 6 || i == 8 || i == 9)
                                {
                                    oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                }

                                if (i == 8)
                                {
                                    oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "dd/MM/yyyy";
                                }

                                if (i >= 12 && i <= 20)
                                {
                                    oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    if (i == 12)
                                    {
                                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                                    }
                                    else
                                    {
                                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,###,##0.000000";
                                    }
                                }

                                if (i == 21 || i == 22)
                                {
                                    if (itemDet.VaEnRojo)
                                    {
                                        oHoja.Cells[FilaIni, i].Style.Font.Color.SetColor(Color.Red);
                                    }
                                    else
                                    {
                                        oHoja.Cells[FilaIni, i].Style.Font.Color.SetColor(Color.Black);
                                    }
                                }
                            }

                            #endregion

                            FilaIni++; //Aumentando un fila
                        }

                        #region Total Movimiento

                        oHoja.Cells[FilaIni, 1, FilaIni, totCols - 10].Merge = true;
                        oHoja.Cells[FilaIni, 1, FilaIni, totCols - 10].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        oHoja.Cells[FilaIni, 1, FilaIni, totCols - 10].Style.Border.Top.Color.SetColor(Color.Navy);
                        oHoja.Cells[FilaIni, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaIni, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, 1].Style.Font.Color.SetColor(Color.Navy);
                        oHoja.Cells[FilaIni, 1].Value = "TOTAL DOCUMENTO >>>>>>>>>>> ";

                        oHoja.Cells[FilaIni, 13].Value = totColMovS;
                        oHoja.Cells[FilaIni, 14].Value = totColMovD;
                        oHoja.Cells[FilaIni, 15].Value = TotalColMovS;
                        oHoja.Cells[FilaIni, 16].Value = TotalColMovD;

                        oHoja.Cells[FilaIni, 17].Value = totColKarS;
                        oHoja.Cells[FilaIni, 18].Value = totColKarD;
                        oHoja.Cells[FilaIni, 19].Value = TotalColKarS;
                        oHoja.Cells[FilaIni, 20].Value = TotalColKarD;

                        //Formateo
                        for (int i = 13; i < totCols - 1; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Color.SetColor(Color.Navy);
                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,###,##0.000000";
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Font.Color.SetColor(Color.Navy);
                        }
                        
                        #endregion

                        //Sumando para el total general
                        totGenColMovS += Decimal.Round(totColMovS, 6, MidpointRounding.AwayFromZero);
                        totGenColMovD += Decimal.Round(totColMovD, 6, MidpointRounding.AwayFromZero);
                        TotalGenColMovS += Decimal.Round(TotalColMovS, 6, MidpointRounding.AwayFromZero);
                        TotalGenColMovD += Decimal.Round(TotalColMovD, 6, MidpointRounding.AwayFromZero);

                        totColKarGenS += Decimal.Round(totColKarS, 6, MidpointRounding.AwayFromZero);
                        totColKarGenD += Decimal.Round(totColKarD, 6, MidpointRounding.AwayFromZero);
                        TotalGenColKarS += Decimal.Round(TotalColKarS, 6, MidpointRounding.AwayFromZero);
                        TotalGenColKarD += Decimal.Round(TotalColKarD, 6, MidpointRounding.AwayFromZero);

                        //Limpiando las variables del detalle
                        totColMovS = 0;
                        totColMovD = 0;
                        totColKarS = 0;
                        totColKarD = 0;
                        TotalColKarS = 0;
                        TotalColKarD = 0;

                        FilaIni += 2;
                    }

                    #region Total General

                    oHoja.Cells[FilaIni, 1, FilaIni, totCols - 10].Merge = true;
                    oHoja.Cells[FilaIni, 1, FilaIni, totCols - 10].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oHoja.Cells[FilaIni, 1, FilaIni, totCols - 10].Style.Border.Top.Color.SetColor(Color.DarkGreen);
                    oHoja.Cells[FilaIni, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[FilaIni, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[FilaIni, 1].Style.Font.Color.SetColor(Color.DarkGreen);
                    oHoja.Cells[FilaIni, 1].Value = "TOTAL GENERAL >>>>>>>>>>> ";

                    oHoja.Cells[FilaIni, 13].Value = totGenColMovS;
                    oHoja.Cells[FilaIni, 14].Value = totGenColMovD;
                    oHoja.Cells[FilaIni, 15].Value = TotalGenColMovS;
                    oHoja.Cells[FilaIni, 16].Value = TotalGenColMovD;

                    oHoja.Cells[FilaIni, 17].Value = totColKarGenS;
                    oHoja.Cells[FilaIni, 18].Value = totColKarGenD;
                    oHoja.Cells[FilaIni, 19].Value = TotalGenColKarS;
                    oHoja.Cells[FilaIni, 20].Value = TotalGenColKarD;

                    //Formateo
                    for (int i = 13; i < totCols - 1; i++)
                    {
                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        oHoja.Cells[FilaIni, i].Style.Border.Top.Color.SetColor(Color.DarkGreen);
                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,###,##0.000000";
                        oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, i].Style.Font.Color.SetColor(Color.DarkGreen);
                    } 

                    #endregion

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Módulo de Almacén";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            lblProcesando.Text = "Obteniendo los Movimientos...";
            ListaMovimientos = AgenteAlmacen.Proxy.MovimientoAlmacenPorTipArticulo(idEmpresa, Convert.ToInt32(cboTipoMovimiento.SelectedValue), Convert.ToInt32(cboAlmacen.SelectedValue), Convert.ToInt32(cboTipoAlmacen.SelectedValue), Convert.ToInt32(cboOperaciones.SelectedValue), dtpInicio.Value.ToString("yyyyMMdd"), dtpFinal.Value.ToString("yyyyMMdd"));
            lblProcesando.Text = "Armando el Reporte...";

            if (ListaMovimientos.Count > 0)
            {
                ConvertirApdf(ListaMovimientos);
            }
            else
            {
                Global.MensajeComunicacion("No hay información con el Tipo de Articulo y Almacén escogidos.");
            }
        }

        public override void Exportar()
        {
            try
            {
                if (ListaMovimientos == null || ListaMovimientos.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreArchivo = "MOVIMIENTOS DE ALMACEN DETALLADO " + ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre.ToUpper() + " del " + dtpInicio.Value.ToString("dd-MM-yy") + " al " + dtpFinal.Value.ToString("dd-MM-yy");
                NombreArchivo = NombreArchivo.Replace("<<", "-").Replace(">>", "-");
                String RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrWhiteSpace(RutaExcel))
                {
                    ExportarExcel(ListaMovimientos, RutaExcel);
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
            btObtener.Enabled = true;

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

        private void frmReporteKardex_Load(object sender, EventArgs e)
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

            cboTipoAlmacen_SelectionChangeCommitted(new Object(), new EventArgs());
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia(VariablesLocales.FechaHoy.ToString("MM"), VariablesLocales.FechaHoy.ToString("yyyy")));
        }

        private void btObtener_Click(object sender, EventArgs e)
        {
            try
            {
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                btObtener.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btObtener.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoMovimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenarOperaciones();
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<AlmacenE> ListaAlmacenes = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoAlmacen.SelectedValue));
                ListaAlmacenes.Add(new AlmacenE() { idAlmacen = 0, desAlmacen = Variables.Todos });
                ComboHelper.RellenarCombos<AlmacenE>(cboAlmacen, ListaAlmacenes.OrderBy(x => x.idAlmacen).ToList(), "idAlmacen", "desAlmacen");

                if (ListaAlmacenes.Count == 1)
                {
                    cboAlmacen.Enabled = false;
                }
                else if (ListaAlmacenes.Count == 2)
                {
                    cboAlmacen.Enabled = false;
                    cboAlmacen.SelectedIndex = 1;
                }
                else
                {
                    cboAlmacen.Enabled = true;
                }

                LlenarOperaciones();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        #endregion

    }

    class PagInicioMovAlmacenDeta : PdfPageEventHelper
    {
        public String tipArticulo { get; set; }
        public String Periodo { get; set; }
        public Int32 Columnas { get; set; }
        public float[] AnchoCols { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            iTextSharp.text.Font LetraCab = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD);
            PdfPTable table = null;
            BaseColor colCabDetalle1 = new BaseColor(Color.FromArgb(191, 191, 191)); //Plomo claro
            BaseColor colCabDetalle2 = new BaseColor(Color.FromArgb(132, 151, 176)); //
            BaseColor colCabDetPrecio = new BaseColor(Color.FromArgb(146, 208, 80)); //Verde claro

            #endregion Variables

            //Para el encabezado
            table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            tipArticulo = tipArticulo.Replace("<<", "").Replace(">>", "").Trim();

            #region Encabezado de página

            table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            #endregion

            if (writer.PageNumber == 1)
            {
                #region Titulo Principal

                table.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTO DE ALMACEN POR TIPO DE ARTICULO DETALLADO - " + tipArticulo, null, "N", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                table.AddCell(ReaderHelper.NuevaCelda("(" + Periodo + ")", null, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                //Fila en blanco
                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N"));

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF

                #region Cabecera del Detalle

                table = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };

                table.SetWidths(AnchoCols);

                table.AddCell(ReaderHelper.NuevaCelda("OPERACION", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("COD.ALMAC.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("FEC.PRO.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("ITEM", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("T.D.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("SERIE", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("NUMERO", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("FEC.DOC.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("LOTE", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("COD.ARTI.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("ARTICULO", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("CANT.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("COSTO MOVIMIENTO ALMACEN", colCabDetalle1, "S", null, LetraCab, 5, 1, "S4"));
                table.AddCell(ReaderHelper.NuevaCelda("COSTO MOVIMIENTO KARDEX", colCabDetalle2, "S", null, LetraCab, 5, 1, "S4"));
                table.AddCell(ReaderHelper.NuevaCelda("MON.MER.", colCabDetPrecio, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("PRECIO MERCADO", colCabDetPrecio, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));

                table.AddCell(ReaderHelper.NuevaCelda("S/", colCabDetalle1, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("US$", colCabDetalle1, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total S/", colCabDetalle1, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total US$", colCabDetalle1, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("S/", colCabDetalle2, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("US$", colCabDetalle2, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total S/", colCabDetalle2, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total US$", colCabDetalle2, "S", null, LetraCab, 5, 1));

                table.CompleteRow();

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF
            }
            else
            {
                document.Add(table); //Añadiendo la tabla al documento PDF

                #region Cabecera del Detalle

                table = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };

                table.SetWidths(AnchoCols);

                table.AddCell(ReaderHelper.NuevaCelda("OPERACION", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("COD.ALMAC.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("FEC.PRO.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("ITEM", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("T.D.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("SERIE", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("NUMERO", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("FEC.DOC.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("LOTE", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("COD.ARTI.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("ARTICULO", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("CANT.", colCabDetalle1, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("COSTO MOVIMIENTO ALMACEN", colCabDetalle1, "S", null, LetraCab, 5, 1, "S4"));
                table.AddCell(ReaderHelper.NuevaCelda("COSTO MOVIMIENTO KARDEX", colCabDetalle2, "S", null, LetraCab, 5, 1, "S4"));
                table.AddCell(ReaderHelper.NuevaCelda("MON.MER.", colCabDetPrecio, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("PRECIO MERCADO", colCabDetPrecio, "S", null, LetraCab, 5, 1, "N", "S2", 5f, 5f));

                table.AddCell(ReaderHelper.NuevaCelda("S/", colCabDetalle1, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("US$", colCabDetalle1, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total S/", colCabDetalle2, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total US$", colCabDetalle2, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("S/", colCabDetalle2, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("US$", colCabDetalle2, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total S/", colCabDetalle2, "S", null, LetraCab, 5, 1));
                table.AddCell(ReaderHelper.NuevaCelda("Total US$", colCabDetalle2, "S", null, LetraCab, 5, 1));

                table.CompleteRow();

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF
            }
        }
    }

}