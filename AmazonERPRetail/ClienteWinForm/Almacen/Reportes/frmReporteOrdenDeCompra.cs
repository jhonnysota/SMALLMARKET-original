using ClienteWinForm;
using Entidades.Almacen;
using Entidades.Maestros;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteOrdenDeCompra : FrmMantenimientoBase
    {
        public frmReporteOrdenDeCompra()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        #region Variables


        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<OrdenCompraE> oListaOrdenCompra = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        String Marque = String.Empty;
        string tipo = "buscar";
        //OrdenCompraE oRegOrdenCompra;
        Int32 idTipo = 0;

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
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, listaLocales, "idLocal", "Nombre", false);
        }

        #endregion

        #region Impresiones

        public override void Exportar()
        {
            try
            {
                if (oListaOrdenCompra == null || oListaOrdenCompra.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = cboSucursales.Text;
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + cboSucursales.Text;
                

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Orden De Compra Pendientes" + NombreLocal + "-" , "Archivos Excel (*.xlsx)|*.xlsx");

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



            TituloGeneral = " Ajuste Diferencia De Cambio " + "Del" + dtpFecIni.Value.Date + "Al"  + dtpFecFin.Value.Date;
            NombrePestaña = " Ajuste Diferencia De Cambio ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 8;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " Nro O/C ";
                    oHoja.Cells[InicioLinea, 2].Value = " Fecha Emision O/C ";
                    oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                    oHoja.Cells[InicioLinea, 3].Value = " Requisicion ";
                    oHoja.Cells[InicioLinea, 4].Value = " Modalidad ";
                    oHoja.Cells[InicioLinea, 5].Value = " Nro. Licitacion ";
                    oHoja.Cells[InicioLinea, 6].Value = " Costo Orden S/";
                    oHoja.Cells[InicioLinea, 7].Value = " Compra US $";
                    oHoja.Cells[InicioLinea, 8].Value = " Estado ";



                    for (int i = 1; i <= 8; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }




                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    #endregion


                    #region Detallado
                    int contador = 0;
                    string Proveedor = "";
                    String Mon =String.Empty;
                    decimal SubTotal1 = 0;
                    decimal SubTotal2 = 0;

                    foreach (OrdenCompraE item in oListaOrdenCompra)
                    {
                        Mon = item.idMoneda;
                        if (contador == 0)
                        {
                            Proveedor = item.RazonSocial;

                            oHoja.Cells[InicioLinea, 1].Value = "Proveedor : ";
                            oHoja.Cells[InicioLinea, 2].Value = Proveedor;
                            oHoja.Cells[InicioLinea, 3].Value = "";
                            oHoja.Cells[InicioLinea, 4].Value = "";
                            oHoja.Cells[InicioLinea, 5].Value = "";
                            oHoja.Cells[InicioLinea, 6].Value = "";
                            oHoja.Cells[InicioLinea, 7].Value = "";
                            oHoja.Cells[InicioLinea, 8].Value = "";

                            for (int i = 1; i <= 2; i++)
                            {

                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                            }

                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1].Value = "Solicitante : ";
                            oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                            oHoja.Cells[InicioLinea, 5].Value = "";
                            oHoja.Cells[InicioLinea, 6].Value = "";
                            oHoja.Cells[InicioLinea, 7].Value = "";
                            oHoja.Cells[InicioLinea, 8].Value = "";

                            for (int i = 1; i <= 2; i++)
                            {

                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                            }

                            InicioLinea++;

                            //Linea Normal

                            oHoja.Cells[InicioLinea, 1].Value = item.numOrdenCompra;
                            oHoja.Cells[InicioLinea, 2].Value = item.fecEmision;
                            oHoja.Cells[InicioLinea, 3].Value = item.RUC;
                            oHoja.Cells[InicioLinea, 4].Value = item.desFormaPago;
                            oHoja.Cells[InicioLinea, 5].Value = " ";
                            if (item.idMoneda == "01")
                            {
                                oHoja.Cells[InicioLinea, 6].Value = item.impTotalitem;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 6].Value = 0.00;
                            }

                            if (item.idMoneda == "02")
                            {
                                oHoja.Cells[InicioLinea, 7].Value = item.impTotalitem;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 7].Value = 0.00;
                            }
                            oHoja.Cells[InicioLinea, 8].Value = idTipo;

                            if (item.idMoneda == "01")
                            {
                                SubTotal1 += item.impTotalitem;
                            }
                            if (item.idMoneda == "02")
                            {
                                SubTotal2 += item.impTotalitem;
                            }

                            oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 6, InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                        }

                        if (contador > 0 && Proveedor == item.RazonSocial)
                        {
                            //LINRA NORMAL ULTIMA

                            oHoja.Cells[InicioLinea, 1].Value = item.numOrdenCompra;
                            oHoja.Cells[InicioLinea, 2].Value = item.fecEmision;
                            oHoja.Cells[InicioLinea, 3].Value = item.RUC;
                            oHoja.Cells[InicioLinea, 4].Value = item.desFormaPago;
                            oHoja.Cells[InicioLinea, 5].Value = " ";
                            if (item.idMoneda == "01")
                            {
                                oHoja.Cells[InicioLinea, 6].Value = item.impTotalitem;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 6].Value = 0.00;
                            }

                            if (item.idMoneda == "02")
                            {
                                oHoja.Cells[InicioLinea, 7].Value = item.impTotalitem;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 7].Value = 0.00;
                            }
                            oHoja.Cells[InicioLinea, 8].Value = idTipo;

                            oHoja.Cells[InicioLinea, 6, InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                            if (item.idMoneda == "01")
                            {
                                SubTotal1 += item.impTotalitem;
                            }
                            if (item.idMoneda == "02")
                            {
                                SubTotal2 += item.impTotalitem;
                            }

                            InicioLinea++;
                        }

                        if (contador > 0 && Proveedor != item.RazonSocial)
                        {

                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                            InicioLinea++;
                            // SUB STOTTALES

                            oHoja.Cells[InicioLinea, 1].Value = "";
                            oHoja.Cells[InicioLinea, 2].Value = "";
                            oHoja.Cells[InicioLinea, 3].Value = "";
                            oHoja.Cells[InicioLinea, 4].Value = "";
                            oHoja.Cells[InicioLinea, 5].Value = "Total Proveedor";
                            oHoja.Cells[InicioLinea, 6].Value = SubTotal1;
                            oHoja.Cells[InicioLinea, 7].Value = SubTotal2;
                            oHoja.Cells[InicioLinea, 8].Value = "";

                            for (int i = 1; i <= 8; i++)
                            {

                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                            }

                            SubTotal1 = 0;
                            SubTotal2 = 0;


                            // FORMAT 
                            oHoja.Cells[InicioLinea, 3, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            Proveedor = item.RazonSocial;

                            oHoja.Cells[InicioLinea, 1].Value = "Proveedor :";
                            oHoja.Cells[InicioLinea, 2].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 5].Value = "";
                            oHoja.Cells[InicioLinea, 6].Value = "";
                            oHoja.Cells[InicioLinea, 7].Value = "";
                            oHoja.Cells[InicioLinea, 8].Value = "";

                            for (int i = 1; i <= 2; i++)
                            {

                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                            }

                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1].Value = "Solicitante :";
                            oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                            oHoja.Cells[InicioLinea, 5].Value = "";
                            oHoja.Cells[InicioLinea, 6].Value = "";
                            oHoja.Cells[InicioLinea, 7].Value = "";
                            oHoja.Cells[InicioLinea, 8].Value = "";

                            for (int i = 1; i <= 2; i++)
                            {

                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                            }

                            InicioLinea++;


                            oHoja.Cells[InicioLinea, 1].Value = item.numOrdenCompra;
                            oHoja.Cells[InicioLinea, 2].Value = item.fecEmision;
                            oHoja.Cells[InicioLinea, 3].Value = item.RUC;
                            oHoja.Cells[InicioLinea, 4].Value = item.desFormaPago;
                            oHoja.Cells[InicioLinea, 5].Value = "";
                            if (item.idMoneda == "01")
                            {
                                oHoja.Cells[InicioLinea, 6].Value = item.impTotalitem;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 6].Value = 0.00;
                            }

                            if (item.idMoneda == "02")
                            {
                                oHoja.Cells[InicioLinea, 7].Value = item.impTotalitem;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 7].Value = 0.00;
                            }
                            oHoja.Cells[InicioLinea, 8].Value = idTipo;

                            if (item.idMoneda == "01")
                            {
                                SubTotal1 += item.impTotalitem;
                            }
                            if (item.idMoneda == "02")
                            {
                                SubTotal2 += item.impTotalitem;
                            }


                            // FORMAT 
                            oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea,6, InicioLinea,7].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;
                        }


                        contador++;
                    }


                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;



                    // totales

                    oHoja.Cells[InicioLinea, 2].Value = "";               
                    oHoja.Cells[InicioLinea, 3].Value = "";
                    oHoja.Cells[InicioLinea, 4].Value = "";
                    oHoja.Cells[InicioLinea, 5].Value = "TOTAL GENERAL";
                    oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    if (Mon == "01")
                    {
                        oHoja.Cells[InicioLinea, 6].Value = oListaOrdenCompra.Sum(x => x.impTotalitem);
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 6].Value = "0.00";
                    }

                    if (Mon == "02")
                    {
                        oHoja.Cells[InicioLinea, 7].Value = oListaOrdenCompra.Sum(x => x.impTotalitem);
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 7].Value = "0.00";
                    }
                    oHoja.Cells[InicioLinea, 8].Value = "";


                    // FORMAT 
                    oHoja.Cells[InicioLinea,6, InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";


                    InicioLinea++;
                    
                    //FIN SUMATORIA //



                    #endregion

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
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

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            String NombreReporte = @"\OrdenDeCompra ";
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
                PdfPCell cell = null;

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

                PaginaInicialOrdenCompra ev = new PaginaInicialOrdenCompra();
                DateTime FechaIni = Convert.ToDateTime(dtpFecIni.Value.Date);
                ev.FechaIni = FechaIni;
                DateTime FechaFin = Convert.ToDateTime(dtpFecFin.Value.Date);
                ev.FechaFin = FechaFin;
                //Parametros Que Pasaras Al PDF
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(8);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.08f, 0.1f, 0.1f, 0.15f, 0.08f, 0.08f, 0.08f });

                Decimal subtotal1 = 0;
                Decimal subtotal2 = 0;
                string LineaSepradora = "----------------------------------";
                int contador = 0;
                string Proveedor = "";
                string Solicitante = "";

                for (int i = 0; i < oListaOrdenCompra.Count; i++)
                {
                    // ====================================================
                    // PRIMERA LINEA - CARGAMOS DATOS
                    // ====================================================

                    if (contador == 0)
                    {
                        Proveedor = oListaOrdenCompra[i].RazonSocial;
                        Solicitante = oListaOrdenCompra[i].desArticulo;

                        cell = new PdfPCell(new Paragraph("Proveedor :", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Proveedor, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        cell.Colspan = 2;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();


                        cell = new PdfPCell(new Paragraph("Solicitante: ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Solicitante, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        cell.Colspan = 2;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }

                    // ====================================================
                    // cambio de grupo
                    // ====================================================

                    if (Proveedor != oListaOrdenCompra[i].RazonSocial)
                    {
                        // ====================================================
                        // linea separadora
                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("-----------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("-----------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        // ====================================================

                        Proveedor = oListaOrdenCompra[i].RazonSocial;
                        Solicitante = oListaOrdenCompra[i].desArticulo;

                        cell = new PdfPCell(new Paragraph("Proveedor :", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Proveedor, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        cell.Colspan = 2;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();


                        cell = new PdfPCell(new Paragraph("Solicitante: ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Solicitante, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        cell.Colspan = 2;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }
                    // ====================================================
                    // REGISTRO SIMPLE
                    // ====================================================
                    cell = new PdfPCell(new Paragraph(oListaOrdenCompra[i].numOrdenCompra, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(oListaOrdenCompra[i].fecEmision.ToString("d"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(oListaOrdenCompra[i].RUC, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(oListaOrdenCompra[i].desFormaPago, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    if (oListaOrdenCompra[i].idMoneda == "01")
                    {
                        cell = new PdfPCell(new Paragraph(oListaOrdenCompra[i].impTotalitem.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph(" 0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }

                    if (oListaOrdenCompra[i].idMoneda == "02")
                    {
                        cell = new PdfPCell(new Paragraph(oListaOrdenCompra[i].impTotalitem.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }
                    cell = new PdfPCell(new Paragraph(idTipo.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    
                    TablaCabDetalle.CompleteRow();


                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(LineaSepradora, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(LineaSepradora, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(LineaSepradora, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();




                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("TotalProveedor: ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    if (oListaOrdenCompra[i].idMoneda == "01")
                    {

                        cell = new PdfPCell(new Paragraph(oListaOrdenCompra[i].impTotalitem.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }

                    if (oListaOrdenCompra[i].idMoneda == "02")
                    {
                        cell = new PdfPCell(new Paragraph(oListaOrdenCompra[i].impTotalitem.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    // ====================================================
                    // SUB TOTALES DEL GRUPO CENTRO DE COSTOS
                    // ====================================================
                    if (oListaOrdenCompra[i].idMoneda == "01")
                    {
                        subtotal1 = subtotal1 + oListaOrdenCompra[i].impTotalitem;

                    }

                    if (oListaOrdenCompra[i].idMoneda == "02")
                    {
                        subtotal2 = subtotal2 + oListaOrdenCompra[i].impTotalitem;
                    }


                    // ====================================================

                    contador++;
                }


                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();





                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("TOTAL GENERAL", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(subtotal1.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(subtotal2.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

              

                TablaCabDetalle.CompleteRow();




                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

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


        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                
                if (rboPendiente.Checked == true)
                {
                    idTipo = 1;
                }
                if (rboTotal.Checked == true)
                {
                    idTipo = 2;
                }

                Int32 idPer = 0;
                if (txtidProveedor.Text != "")
                {
                    idPer = Convert.ToInt32(txtidProveedor.Text);
                }
                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el Orden De Compra Pendiente...";
                oListaOrdenCompra = AgenteAlmacen.Proxy.ListarOrdenCompraPendientes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idTipo, idPer);

                lblProcesando.Text = "Armando el Reporte...";
                //Generando el PDF
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
                Global.MensajeComunicacion("Orden De Compra...");
            }
        }


        #endregion

        #region Eventos

        private void frmReporteOrdenDeCompra_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

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


        private void frmReporteDifCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void chkRetencion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked ==  false)
            {
                btProveedor.Enabled = true;
            }
            if (chkTodos.Checked == true)
            {
                btProveedor.Enabled = false;
            }
        }


        #endregion

    }
}



internal class PaginaInicialOrdenCompra : PdfPageEventHelper
{
    public String Anio { get; set; }
    public DateTime FechaIni { get; set; }
    public DateTime FechaFin { get; set; }


    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;

        PdfPCell cell = null;

        TituloGeneral = "Seguimiento De Ordenes De Compra " ;

        SubTitulo = "Del: " + FechaIni.ToString("d") + "Al: " + FechaFin.ToString("d");

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.9f, 0.1f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha: " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Hora:   " + HoraActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        //cell.Colspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Pag.    " + writer.PageNumber, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        //cell.Colspan = 2;
        table.AddCell(cell);

        table.CompleteRow(); //Fila completada 

        #endregion

        #region Subtitulos

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada 

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(8);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.08f, 0.1f, 0.1f, 0.15f, 0.08f, 0.08f, 0.08f });

        #region Primera Linea

        cell = new PdfPCell(new Paragraph(" Nro O/C ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Fecha Emision O/C ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Requisicion ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Modalidad", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Nro. Licitacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Costo Orden S/.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Compra US $", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Estado ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion


        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}