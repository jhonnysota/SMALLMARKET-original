using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text.pdf;
using iTextSharp.text;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteCostoVentas : FrmMantenimientoBase
    {

        public frmReporteCostoVentas()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            BuscarImagen();
            LlenarCombo();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        String RutaImagen = string.Empty;// VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marque = String.Empty;
        List<CostoVentaE> oListaCostos = null;
        String RutaArchivo = String.Empty;
        string tipo = "buscar";
        String RutaGeneral = String.Empty;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ParTabla> ListarTipoAlmacenes = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("TIPART");
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListarTipoAlmacenes orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);

            ////Tipo Operación////
            cboOperacion.DataSource = Global.CargarTipoOpe();
            cboOperacion.ValueMember = "id";
            cboOperacion.DisplayMember = "Nombre";
        }

        void BuscarImagen()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void ConvertirApdf()
        {
            try
            {
                Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                Guid Aleatorio = Guid.NewGuid();
                String NombreReporte = "Reporte Costo Ventas " + Aleatorio.ToString();
                String Extension = ".pdf";
                String TituloGeneral = "";
                String Fechas = "";
                iTextSharp.text.Font LetraCabTot = FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font LetraSub = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font LetraDet = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL);
                BaseColor ColorCabTot = new BaseColor(189, 215, 238);
                BaseColor ColorSub = new BaseColor(208, 206, 206);
                List<CostoVentaE> ListaCostosTmp = null;

                RutaArchivo = @"C:\AmazonErp\ArchivosTemporales\";

                if (!Directory.Exists(RutaArchivo))
                {
                    Directory.CreateDirectory(RutaArchivo);
                }

                docPdf.AddCreationDate();
                docPdf.AddAuthor("AMAZONTIC SAC");
                docPdf.AddCreator("AMAZONTIC SAC");

                #region Por Documento Detallado

                if (!String.IsNullOrEmpty(RutaArchivo.Trim()))
                {
                    TituloGeneral = "REPORTE DE COSTOS DE VENTAS";
                    Fechas = String.Format("(Del {0} al {1})", dtpFecIni.Value.ToString("dd/MM/yyyy"), dtpFecFin.Value.ToString("dd/MM/yyyy"));

                    //Creacion del archivo pdf
                    RutaArchivo += NombreReporte + Extension;

                    if (File.Exists(RutaArchivo))
                    {
                        File.Delete(RutaArchivo);
                    }

                    FileStream fsNuevoArchivo = new FileStream(RutaArchivo, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                    oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    PagEncabezadoCostoVenta ev = new PagEncabezadoCostoVenta();
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    //Cabecera del Reporte
                    PdfPTable oTablaTitulos = new PdfPTable(2);

                    oTablaTitulos.WidthPercentage = 100;
                    oTablaTitulos.SetWidths(new float[] { 0.35f, 0.65f });
                    oTablaTitulos.HorizontalAlignment = Element.ALIGN_LEFT;

                    ////Logo de la Empresa
                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 135f, 30f, 1, 1, "S", 1));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    CeldaImagen.Rowspan = 2;
                    oTablaTitulos.AddCell(CeldaImagen);

                    //Lado Izquierdo
                    oTablaTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 0, 4, "S", "N", "S", "N", 1));
                    oTablaTitulos.AddCell(ReaderHelper.NuevaCelda(Fechas, null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 3, 0, "N", "S", "S", "N", 1));
                    oTablaTitulos.CompleteRow(); //Fila completada

                    //Espacio en Blanco
                    oTablaTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    docPdf.Add(oTablaTitulos);

                    //Obteniendo una lista temporal para la cabecera...
                    List<CostoVentaE> oListaCabeceras = oListaCostos.GroupBy(x => x.nomCategoria + x.codCuentaConsumo + x.codCuentaDestino).Select(g => g.First()).ToList();
                    
                    Decimal totCant = 0;
                    Decimal totCosto = 0;
                    Decimal totCostoRef = 0;

                    //Sub Titulos
                    foreach (CostoVentaE itemCab in oListaCabeceras)
                    {
                        #region Subtitulos

                        PdfPTable TablaSubTitulos = new PdfPTable(1);
                        TablaSubTitulos.WidthPercentage = 100;
                        TablaSubTitulos.SetWidths(new float[] { 0.1f });

                        TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(string.Format("Categoria: {0}     Cuentas Contables: {1} - {2}", itemCab.nomCategoria, itemCab.codCuentaConsumo, itemCab.codCuentaDestino), ColorCabTot, "S", null, LetraCabTot, 5, 0, "N", "N", 5, 5));
                        TablaSubTitulos.CompleteRow(); //Fila completada

                        docPdf.Add(TablaSubTitulos); //Añadiendo la tabla al documento PDF...
                        TablaSubTitulos = null;

                        #endregion

                        //Detalle
                        ListaCostosTmp = oListaCostos.Where(x => x.nomCategoria == itemCab.nomCategoria && x.codCuentaConsumo == itemCab.codCuentaConsumo && x.codCuentaDestino == itemCab.codCuentaDestino).ToList();
                        PdfPTable TablaDetalle = new PdfPTable(11);
                        TablaDetalle.SetWidths(new float[] { 0.05f, 0.18f, 0.03f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.07f, 0.05f, 0.04f });
                        TablaDetalle.WidthPercentage = 100;

                        //Cabecera del Detalle
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Código", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Articulo", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Cant.", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Costo Unit.S/.", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Tot. Costo S/.", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Costo Unit. US$", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Tot. Costo US$", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Movimiento", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Doc.Almacén", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Fec.Almacén", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Lote", ColorSub, "S", null, LetraSub, 5, 1, "N", "N", 3, 3));
                        TablaDetalle.CompleteRow();

                        Decimal subtotCant = 0;
                        Decimal subtotCosto = 0;
                        Decimal subtotCostoRef = 0;

                        if (ListaCostosTmp.Count > 0)
                        {
                            foreach (CostoVentaE item in ListaCostosTmp)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "S", null, LetraDet, 5, 1));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "S", null, LetraDet, 5, 0));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N2"), null, "S", null, LetraDet, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoPromUnitarioBase.ToString("N2"), null, "S", null, LetraDet, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.totCosto.ToString("N2"), null, "S", null, LetraDet, 5, 2));

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impCostoPromUnitarioRefe.ToString("N2"), null, "S", null, LetraDet, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.totCostoRefe.ToString("N2"), null, "S", null, LetraDet, 5, 2));

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desTipMovimiento, null, "S", null, LetraDet, 5, 0));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.codMovAlmacen, null, "S", null, LetraDet, 5, 1));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecProceso.ToString("dd/MM/yyyy"), null, "S", null, LetraDet, 5, 1));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "S", null, LetraDet, 5, 0));
                                TablaDetalle.CompleteRow();

                                subtotCant += item.Cantidad;
                                subtotCosto += item.totCosto;
                                subtotCostoRef += item.totCostoRefe;
                            }

                            //Ultima linea...
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraCabTot, 5, 1, "N", "N", 5, 5));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL CATEGORIA", ColorCabTot, "S", null, LetraCabTot, 5, 1, "N", "N", 5, 5));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(subtotCant.ToString("N2"), ColorCabTot, "S", null, LetraCabTot, 5, 2, "N", "N", 5, 5));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraCabTot, 5, 1, "N", "N", 5, 5));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(subtotCosto.ToString("N2"), ColorCabTot, "S", null, LetraCabTot, 5, 2, "N", "N", 5, 5));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraCabTot, 5, 1, "N", "N", 5, 5));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(subtotCostoRef.ToString("N2"), ColorCabTot, "S", null, LetraCabTot, 5, 2, "N", "N", 5, 5));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraCabTot, 5, 1, "S4", "N", 5, 5));
                            TablaDetalle.CompleteRow();

                            totCant += subtotCant;
                            totCosto += subtotCosto;
                            totCostoRef += subtotCostoRef;

                            //Fila en blanco
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S11"));
                            TablaDetalle.CompleteRow();
                        }

                        docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF
                    }

                    PdfPTable TablaDetalletot = new PdfPTable(11);
                    TablaDetalletot.SetWidths(new float[] { 0.05f, 0.18f, 0.03f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.07f, 0.05f, 0.04f });
                    TablaDetalletot.WidthPercentage = 100;

                    TablaDetalletot.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraCabTot, 5, 1, "N", "N", 5, 5));
                    TablaDetalletot.AddCell(ReaderHelper.NuevaCelda("TOTALES", ColorCabTot, "S", null, LetraCabTot, 5, 1, "N", "N", 5, 5));
                    TablaDetalletot.AddCell(ReaderHelper.NuevaCelda(totCant.ToString("N2"), ColorCabTot, "S", null, LetraCabTot, 5, 2, "N", "N", 5, 5));
                    TablaDetalletot.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraCabTot, 5, 1, "N", "N", 5, 5));
                    TablaDetalletot.AddCell(ReaderHelper.NuevaCelda(totCosto.ToString("N2"), ColorCabTot, "S", null, LetraCabTot, 5, 2, "N", "N", 5, 5));
                    TablaDetalletot.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraCabTot, 5, 1, "N", "N", 5, 5));
                    TablaDetalletot.AddCell(ReaderHelper.NuevaCelda(totCostoRef.ToString("N2"), ColorCabTot, "S", null, LetraCabTot, 5, 2, "N", "N", 5, 5));
                    TablaDetalletot.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, LetraCabTot, 5, 1, "S4", "N", 5, 5));
                    TablaDetalletot.CompleteRow();

                    docPdf.Add(TablaDetalletot);

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                    fsNuevoArchivo.Close();
                }
                else
                {
                    RutaArchivo = String.Empty;
                }

                #endregion
            }
            catch (DocumentException ex)
            {
                throw new DocumentException(ex.Message);
            }
            catch (IOException IOex)
            {
                throw new IOException(IOex.Message);
            }
        }

        public override void Exportar()
        {
            try
            {
                if (oListaCostos == null || oListaCostos.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Costo Ventas" , "Archivos Excel (*.xlsx)|*.xlsx");

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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = " REPORTE DE COSTOS DE VENTAS ";
            NombrePestaña = " REPORTE DE COSTOS DE VENTAS ";

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
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    #endregion Titulos Principales                   

                    #region Variables

                    List<CostoVentaE> oListaCabeceras = oListaCostos.GroupBy(x => x.nomCategoria + x.codCuentaConsumo + x.codCuentaDestino).Select(g => g.First()).ToList();
                    List<CostoVentaE> ListaCostosTmp = null;
                    #endregion

                    Decimal totCant = 0;
                    Decimal totCosto = 0;
                    Decimal totCostoRef = 0;

                    foreach (CostoVentaE itemCab in oListaCabeceras)
                    {

                        #region Cabeceras del Detalle

                        // PRIMERA
                        oHoja.Cells[InicioLinea, 1].Value = string.Format("Categoria: {0}     Cuentas Contables: {1} - {2}", itemCab.nomCategoria, itemCab.codCuentaConsumo, itemCab.codCuentaDestino);

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 1].Value = " Código ";
                        oHoja.Cells[InicioLinea, 2].Value = " Articulo ";
                        oHoja.Cells[InicioLinea, 3].Value = " Cant. ";
                        oHoja.Cells[InicioLinea, 4].Value = " Costo Unit. S/.";
                        oHoja.Cells[InicioLinea, 5].Value = " Tot. Costo S/.";
                        oHoja.Cells[InicioLinea, 6].Value = " Costo Unit. US$ ";
                        oHoja.Cells[InicioLinea, 7].Value = " Tot. Costo US$ ";
                        oHoja.Cells[InicioLinea, 8].Value = " Movimiento ";
                        oHoja.Cells[InicioLinea, 9].Value = " Doc.Almacén ";
                        oHoja.Cells[InicioLinea, 10].Value = " Fec.Almacén ";
                        oHoja.Cells[InicioLinea, 11].Value = " Lote ";



                        for (int i = 1; i <= 11; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;


                        #endregion
                        ListaCostosTmp = oListaCostos.Where(x => x.nomCategoria == itemCab.nomCategoria && x.codCuentaConsumo == itemCab.codCuentaConsumo && x.codCuentaDestino == itemCab.codCuentaDestino).ToList();

                        Decimal subtotCant = 0;
                        Decimal subtotCosto = 0;
                        Decimal subtotCostoRef = 0;

                        if (ListaCostosTmp.Count > 0)
                        {
                            foreach (CostoVentaE item in ListaCostosTmp)
                            {

                                oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                                oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 2].Value = item.nomArticulo;
                                oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 3].Value = item.Cantidad;
                                oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 4].Value = item.impCostoPromUnitarioBase;
                                oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 5].Value = item.totCosto;
                                oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 6].Value = item.impCostoPromUnitarioRefe;
                                oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 7].Value = item.totCostoRefe;
                                oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 8].Value = item.desTipMovimiento;
                                oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 9].Value = item.codMovAlmacen;
                                oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 10].Value = item.fecProceso;
                                oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 11].Value = item.Lote;

                                oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 3, InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

                                subtotCant += item.Cantidad;
                                subtotCosto += item.totCosto;
                                subtotCostoRef += item.totCostoRefe;
                                InicioLinea++;
                            }

                            totCant += subtotCant;
                            totCosto += subtotCosto;
                            totCostoRef += subtotCostoRef;

                            oHoja.Cells[InicioLinea, 2].Value = "TOTAL CATEGORIA";
                            oHoja.Cells[InicioLinea, 3].Value = subtotCant;
                            oHoja.Cells[InicioLinea, 4].Value = " ";
                            oHoja.Cells[InicioLinea, 5].Value = subtotCosto;
                            oHoja.Cells[InicioLinea, 6].Value = " ";
                            oHoja.Cells[InicioLinea, 7].Value = subtotCostoRef;
                            oHoja.Cells[InicioLinea, 3, InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                            InicioLinea++;
                            InicioLinea++;
                        }
                    }
                        oHoja.Cells[InicioLinea, 2].Value = "TOTALES";
                        oHoja.Cells[InicioLinea, 3].Value = totCant;
                        oHoja.Cells[InicioLinea, 4].Value = " ";
                        oHoja.Cells[InicioLinea, 5].Value = totCosto;
                        oHoja.Cells[InicioLinea, 6].Value = " ";
                        oHoja.Cells[InicioLinea, 7].Value = totCostoRef;
                        oHoja.Cells[InicioLinea, 3, InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                        InicioLinea++;
                        InicioLinea++;

 

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
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

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {

                lblProcesando.Text = "Obteniendo los registros Costos de Ventas...";
                if (tipo == "buscar")
                {
                    oListaCostos = AgenteContabilidad.Proxy.ReporteCostoVentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoAlmacen.SelectedValue), Convert.ToString(cboOperacion.SelectedValue), dtpFecIni.Value.Date, dtpFecFin.Value.Date);

                    if (oListaCostos.Count > 0 && oListaCostos != null)
                    {
                        lblProcesando.Text = "Armando el reporte...";


                        ConvertirApdf();



                    }
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
            btBuscar.Enabled = true;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;

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
                if (oListaCostos == null || oListaCostos.Count == 0)
                {
                    RutaArchivo = String.Empty;
                    Global.MensajeComunicacion("No hay datos para mostrar. La pantalla pertenece a la busqueda anterior.");
                }

                if (!String.IsNullOrEmpty(RutaArchivo))
                {
                    wbNavegador.Navigate(RutaArchivo);
                    RutaArchivo = String.Empty;
                }
            }                   

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
                Global.MensajeComunicacion("Costo Ventas Exportada...");
            }
        }

        #endregion

        #region Eventos

        private void frmReporteCostoVentas_Load(object sender, EventArgs e)
        {
            Grid = true;

            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;

            //BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            dtpFecFin.Value = Convert.ToDateTime(FechasHelper.ObtenerUltimoDia(dtpFecIni.Value));

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (panel3.Width - pbProgress.Width) / 2;
            pbProgress.Top = (panel3.Height - pbProgress.Height) / 2;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "buscar";
                Cursor = Cursors.WaitCursor;
                pbProgress.Visible = true;
                btBuscar.Enabled = false;
                lblProcesando.Visible = true;
                

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (panel3.Width - lblProcesando.Width) / 2;
            lblProcesando.Top = ((panel3.Height + pbProgress.Height + 20) - lblProcesando.Height) / 2;
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaCostos == null || oListaCostos.Count == 0)
                {
                    Global.MensajeFault("No hay datos para generar el Asiento de Costos");
                    return;
                }

                Int32 resp = AgenteContabilidad.Proxy.GenerarAsientoCostoVentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(cboTipoAlmacen.SelectedValue), Convert.ToString(cboOperacion.SelectedValue), VariablesLocales.SesionUsuario.Empresa.RUC, dtpFecIni.Value.Date, dtpFecFin.Value.Date, VariablesLocales.SesionUsuario.Credencial);

                if (resp > 0)
                {
                    Global.MensajeComunicacion("El asiento se generó correctamente.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }

    class PagEncabezadoCostoVenta : PdfPageEventHelper
    {

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            BaseColor colCabDetalle = BaseColor.LIGHT_GRAY;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            #endregion Variables

            //Cabecera del Reporte
            PdfPTable table = new PdfPTable(2);

            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

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

            document.Add(table); //Añadiendo la tabla al documento PDF
        }

    }
}
