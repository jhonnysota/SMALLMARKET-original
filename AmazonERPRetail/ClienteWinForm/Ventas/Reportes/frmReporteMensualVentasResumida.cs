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
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteMensualVentasResumida : FrmMantenimientoBase
    {

        public frmReporteMensualVentasResumida()
        {
            InitializeComponent();
        }

        #region variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        List<EmisionDocumentoE> oListaVentas = null;
        List<EmisionDocumentoE> oListaCabecera = null;

        readonly BackgroundWorker _bw = new BackgroundWorker();

        String RutaGeneral;
        String Marque = String.Empty;
        int idEmpresa;
        int idLocal;
        String VerPlanCuenta;
        String Anio;
        String mesIni;
        String mesFin;
        String idMoneda;
        String tipo = "buscar";
        String desMoneda;
        String moneda;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////ANIOS/////
            int anioFin = Convert.ToInt32(VariablesLocales.FechaHoy.Year);
            int anioInicio = anioFin - 10;


            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
            cboAnio.SelectedValue = VariablesLocales.FechaHoy.Year;

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            /////PERIODO////
            DataTable oDt = FechasHelper.CargarMeses(1, true, "MA");
            DataTable oDt2 = FechasHelper.CargarMeses(1, true, "MA");

            oDt.DefaultView.Sort = "MesId";
            oDt2.DefaultView.Sort = "MesId";

            cboPeriodoIni.DataSource = oDt;
            cboPeriodoIni.ValueMember = "MesId";
            cboPeriodoIni.DisplayMember = "MesDes";
            cboPeriodoIni.SelectedValue = "01";

            cboFin.DataSource = oDt2;
            cboFin.ValueMember = "MesId";
            cboFin.DisplayMember = "MesDes";
            cboFin.SelectedValue = "12";
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\RegistroVentasResumida";
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

                // =======================
                // DETALLE
                // =======================
                BaseColor color = new BaseColor(ColorTranslator.FromHtml("#CBCBCB"));
                int Columnas = 10;
                float[] ArrayColumnas = new float[] { 0.04f, 0.1f, 0.08f, 0.1f, 0.1f, 0.1f, 0.1f, 0.05f, 0.1f, 0.5f };
                String[] ArrayTitulos = new String[] { "TD", "Documento", "Fecha", "Base \n Grabado", "Base no \n Grabado", "IGV", "Total", "TC", "Comprobante", "Glosa" };

                String Titulo = String.Empty;
                String SubTitulo = " De " + FechasHelper.NombreMes(Convert.ToInt32(mesIni)).ToUpper() + " a " + FechasHelper.NombreMes(Convert.ToInt32(mesFin)).ToUpper() + " del " + Anio;
                Titulo = "Cuadros De Ventas en (" + desMoneda + ") " + Anio;

                oListaCabecera = oListaVentas.GroupBy(x => x.Mes).Select(g => g.First()).OrderBy(x => x.Mes).ToList();

                Columnas = oListaCabecera.Count + 3;

                float[] ArrayColumnas_ = new float[oListaCabecera.Count + 3];
                String[] ArrayTitulos_ = new String[oListaCabecera.Count + 3];

                for (int i = 0; i < oListaCabecera.Count + 3; i++)
                {
                    if (i == 0)
                    {
                        ArrayTitulos_[i] = "RUC";
                        ArrayColumnas_[i] = 0.1f;
                    }
                    else if (i == 1)
                    {
                        ArrayTitulos_[i] = "Razon Social";
                        ArrayColumnas_[i] = 0.25f;
                    }
                    else if (i == 2)
                    {
                        ArrayTitulos_[i] = "Total";
                        ArrayColumnas_[i] = 0.1f;
                    }
                    else
                    {
                        ArrayTitulos_[i] = oListaCabecera[i - 3].nomMes.ToUpper();
                        ArrayColumnas_[i] = 0.09f;
                    }
                }

                ArrayColumnas = ArrayColumnas_;
                ArrayTitulos = ArrayTitulos_;


                PaginaInicioReportePorProveedores ev = new PaginaInicioReportePorProveedores()
                {
                    Anio = Anio,
                    MesIni = mesIni,
                    MesFin = mesFin,

                    Columnas = Columnas,
                    ArrayColumnas = ArrayColumnas,
                    ArrayTitulos = ArrayTitulos,
                    Titulo = Titulo,
                    SubTitulo = SubTitulo
                };
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };
                TablaCabDetalle.SetWidths(ArrayColumnas);

                String ruc = "";
                Decimal TotalFilaTotal = 0;

                for (int i = 0; i < oListaVentas.Count; i++)
                {
                    if (ruc == "")
                    {
                        ruc = oListaVentas[i].numRuc;
                    }

                    if (i == 0 || ruc != oListaVentas[i].numRuc)
                    {
                        ruc = oListaVentas[i].numRuc;

                        cell = new PdfPCell(new Paragraph(oListaVentas[i].numRuc, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((oListaCabecera.Count > 9 ? oListaVentas[i].RazonSocial.Substring(0, (oListaVentas[i].RazonSocial.Length < 25 ? oListaVentas[i].RazonSocial.Length : 25)) : oListaVentas[i].RazonSocial), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(oListaVentas.Where(x => x.numRuc == ruc).ToList().Sum(x => x.totTotal).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        TotalFilaTotal += oListaVentas[i].totTotal;

                        for (int c = 0; c < oListaCabecera.Count; c++)
                        {
                            cell = new PdfPCell(new Paragraph(oListaVentas.Where(x => x.numRuc == ruc &&
                                                                                        x.Mes == oListaCabecera[c].Mes
                                                                                        ).ToList().Sum(x => x.totTotal).ToString("N2"), FontFactory.GetFont("Arial", 5f)))
                            { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);
                        }

                        TablaCabDetalle.CompleteRow();
                    }
                }

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                for (int c = 0; c < oListaCabecera.Count; c++)
                {

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD)))
                    { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                }

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("<< TOTALES >>", FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_LEFT };
                cell.BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#CBCBCB"));
                TablaCabDetalle.AddCell(cell);

                TotalFilaTotal = 0;

                for (int c = 0; c < oListaCabecera.Count; c++)
                {
                   TotalFilaTotal += oListaVentas.Where(x => x.Mes == oListaCabecera[c].Mes).ToList().Sum(x => x.totTotal);
                }

                cell = new PdfPCell(new Paragraph(TotalFilaTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                cell.BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#CBCBCB"));
                TablaCabDetalle.AddCell(cell);

                for (int c = 0; c < oListaCabecera.Count; c++)
                {
                    cell = new PdfPCell(new Paragraph(oListaVentas.Where(x => x.Mes == oListaCabecera[c].Mes).ToList().Sum(x => x.totTotal).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD)))
                    { HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#CBCBCB"));
                    TablaCabDetalle.AddCell(cell);
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
                fsNuevoArchivo.Close();
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Cuadros De Ventas en (" + desMoneda + ") " + Anio;
            NombrePestaña = "Cuadros De Ventas en (" + desMoneda + ") " + Anio;

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 12;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(38, 38, 38));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(89, 89, 89));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    oListaCabecera = oListaVentas.GroupBy(x => x.Mes).Select(g => g.First()).OrderBy(x => x.Mes).ToList();
                    TotColumnas = 4;

                    oHoja.Cells[InicioLinea, 1].Value = " RUC ";
                    oHoja.Cells[InicioLinea, 2].Value = " Razon Social ";
                    oHoja.Cells[InicioLinea, 3].Value = " Total ";

                    for (int i = 1; i <= 3; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(128, 128, 128));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    Int32 LineaDeMes = 4;

                    for (int i = 0; i < oListaCabecera.Count; i++)
                    {
                        using (ExcelRange Rango = oHoja.Cells[4, LineaDeMes, 4, LineaDeMes])
                        {
                            Rango.Value = oListaCabecera[i].nomMes;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(128, 129, 128));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                            LineaDeMes++;
                        }

                    }

                    InicioLinea++;

                    #endregion

                    #region Formato Excel

                    String ruc = "";
                    Decimal TotalFilaTotal = 0;

                    for (int i = 0; i < oListaVentas.Count; i++)
                    {
                        if (ruc == "")
                        {
                            ruc = oListaVentas[i].numRuc;
                        }

                        if (i == 0 || ruc != oListaVentas[i].numRuc)
                        {
                            ruc = oListaVentas[i].numRuc;
                            oHoja.Cells[InicioLinea, 1].Value = oListaVentas[i].numRuc;
                            oHoja.Cells[InicioLinea, 2].Value = oListaCabecera.Count > 9 ? oListaVentas[i].RazonSocial.Substring(0, (oListaVentas[i].RazonSocial.Length < 25 ? oListaVentas[i].RazonSocial.Length : 25)) : oListaVentas[i].RazonSocial;
                            oHoja.Cells[InicioLinea, 3].Value = oListaVentas.Where(x => x.numRuc == ruc).ToList().Sum(x => x.totTotal);
                            oHoja.Cells[InicioLinea, 3].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                            TotalFilaTotal += oListaVentas[i].totTotal;

                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                oHoja.Cells[InicioLinea, c + TotColumnas].Value = oListaVentas.Where(x => x.numRuc == ruc &&
                                                                                             x.Mes == oListaCabecera[c].Mes
                                                                                            ).ToList().Sum(x => x.totTotal);
                                oHoja.Cells[InicioLinea, c + TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                            }

                            InicioLinea++;
                        }
                    }

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 1].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    oHoja.Cells[InicioLinea, 2].Value = "<< TOTALES >>";
                    oHoja.Cells[InicioLinea, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 2].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    TotalFilaTotal = 0; 

                    for (int c = 0; c < oListaCabecera.Count; c++)
                    {
                       TotalFilaTotal += oListaVentas.Where(x => x.Mes == oListaCabecera[c].Mes).ToList().Sum(x => x.totTotal);
                    }

                    oHoja.Cells[InicioLinea, 3].Value = TotalFilaTotal;
                    oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 3].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    int b = 4;
                    for (int c = 0; c < oListaCabecera.Count; c++)
                    {
                        oHoja.Cells[InicioLinea, b].Value = oListaVentas.Where(x => x.Mes == oListaCabecera[c].Mes).ToList().Sum(x => x.totTotal);
                        oHoja.Cells[InicioLinea, b].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, b].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, b].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, b].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, b].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        b++;
                    }

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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();

                    #endregion
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaVentas == null || oListaVentas.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = Convert.ToString(VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString());

                if (NombreLocal == "<<TODOS>>")
                {
                    NombreLocal = "-TODOS-";
                }
                else
                {
                    NombreLocal = "-" + Convert.ToString(VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString());
                }

                String Mes = Convert.ToString(cboPeriodoIni.Text);
                String MesFin = Convert.ToString(cboFin.Text);

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registros Ventas" + NombreLocal + "-" + "Desde el Mes" + mesIni + " Hasta El Mes" + MesFin, "Archivos Excel (*.xlsx)|*.xlsx");

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
                    idMoneda = Convert.ToString(cboMoneda.SelectedValue);
                    oListaVentas = AgenteVentas.Proxy.ReporteMensualVentasResumida(idEmpresa, idLocal, Anio, mesIni, mesFin, idMoneda, Convert.ToInt32(txtRuc.Tag));
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
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteMensualVentasResumida_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

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
            LlenarCombos();
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
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                lblProcesando.Text = "Obteniendo registros ...";
                desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                idLocal = VariablesLocales.SesionLocal.IdLocal;
                VerPlanCuenta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                Anio = cboAnio.SelectedValue.ToString();
                mesIni = cboPeriodoIni.SelectedValue.ToString();
                mesFin = cboFin.SelectedValue.ToString();
                moneda = cboMoneda.SelectedValue.ToString();

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = string.Empty;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazonSocial.Text = string.Empty;
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRuc.Text.Trim()) && string.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClientes.Checked)
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        } 

        #endregion

    }
}
