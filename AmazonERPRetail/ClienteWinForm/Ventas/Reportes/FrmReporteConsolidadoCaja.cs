using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class FrmReporteConsolidadoCaja : FrmMantenimientoBase
    {

        public FrmReporteConsolidadoCaja()
        {
            InitializeComponent();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<EmisionDocumentoCancelacionE> ListaCancelaciones = null;
        string RutaGeneral = string.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string Marque = string.Empty;
        string tipo = "B";

        #endregion

        #region Procedimientos de Usuario

        private void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            string NombreReporte = @"\Consolidado Caja " + Aleatorio.ToString();
            string Extension = ".pdf";
            BaseColor ColorLetra = new BaseColor(7, 43, 118);
            BaseColor ColorCab = new BaseColor(Color.LightGray);

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio si no existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            docPdf.AddCreationDate();
            docPdf.AddAuthor("AMAZONTIC S.A.C.");
            docPdf.AddCreator("AMAZONTIC S.A.C.");

            if (!string.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                string TituloGeneral = string.Empty;
                string SubTitulo = string.Empty;

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

                    //Parametros que pasará al PDF
                    oPdfw.PageEvent = new PaginaInicialConsolCaja
                    {
                        FechaDoc = Convert.ToDateTime(ListaCancelaciones[0].Fecha)
                    };

                    docPdf.Open();

                    PdfPTable TablaCabDetalle = new PdfPTable(7)
                    {
                        WidthPercentage = 100
                    };
                    TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.12f, 0.3f, 0.1f, 0.1f, 0.1f, 0.13f });

                    #region Titulos del detalle

                    List<string> Titulos = new List<string>() { "TIPO", "DOCUMENTO", "CLIENTE", "ANULADO", "TOTAL", "PAGO", "MEDIO P." };

                    foreach (String tit in Titulos)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(tit, ColorCab, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    }

                    #endregion

                    #region Detalle

                    var listaAgrupada = ListaCancelaciones.GroupBy(x => x.idDocumento + x.numSerie + x.numDocumento);
                    int conta = 0;
                    decimal totPago = 0;
                    decimal totDoc = 0;

                    foreach (var grupo in listaAgrupada)
                    {
                        foreach (var item in grupo)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, FontFactory.GetFont("Arial", 7.25f, (item.Estado == "S" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numSerie + " " + item.numDocumento, null, "N", null, FontFactory.GetFont("Arial", 7.25f, (item.Estado == "S" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f, (item.Estado == "S" ? BaseColor.RED : BaseColor.BLACK)), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Estado, null, "N", null, FontFactory.GetFont("Arial", 7.25f, (item.Estado == "S" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((conta == 0 ? item.TotalDoc.ToString("N2") : "-"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, (item.Estado == "S" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.MontoAplicar.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, (item.Estado == "S" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMedioPago, null, "N", null, FontFactory.GetFont("Arial", 7.25f, (item.Estado == "S" ? BaseColor.RED : BaseColor.BLACK)), 5, 0, "N", "N"));

                            TablaCabDetalle.CompleteRow();

                            if (item.Estado != "S")
                            {
                                totPago += item.MontoAplicar; 
                            }

                            if (conta == 0)
                            {
                                if (item.Estado != "S")
                                {
                                    totDoc += item.TotalDoc; 
                                }
                            }

                            conta++;
                        }

                        conta = 0;
                    }

                    //Totales
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S4"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totDoc.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 2f, 2f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totPago.ToString("###,##0.00"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 2f, 2f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                    TablaCabDetalle.CompleteRow();
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 12.25f), 5, 1, "S7"));
                    TablaCabDetalle.CompleteRow(); 

                    #endregion

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #region Resumen

                    TablaCabDetalle = new PdfPTable(10)
                    {
                        WidthPercentage = 100
                    };
                    TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f });

                    var listaMediosPago = ListaCancelaciones.Where(d => d.Estado != "S").GroupBy(x => x.desMedioPago).Select(group => new { group.Key, totMedioPago = group.Sum(s => s.MontoAplicar) });

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S2"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RESUMEN DE PAGOS", ColorCab, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S6"));

                    foreach (var item in listaMediosPago)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S2"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Key.ToString(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.totMedioPago.ToString("###,##0.00"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S6"));

                        TablaCabDetalle.CompleteRow();
                    }

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S3"));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(listaMediosPago.Sum(x => x.totMedioPago).ToString("###,##0.00"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2, "N", "N", 2f, 2f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S6"));
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

        private void ExportarExcel(string Ruta)
        {
            //string TituloGeneral = string.Empty;
            //string NombrePestaña = string.Empty;

            //TituloGeneral = "Reporte de Anticipos Recibidos";
            //NombrePestaña = "Anticipos";

            //if (File.Exists(Ruta)) File.Delete(Ruta);
            //FileInfo newFile = new FileInfo(Ruta);

            //using (ExcelPackage oExcel = new ExcelPackage(newFile))
            //{
            //    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

            //    if (oHoja != null)
            //    {
            //        Int32 FilaNumero = 1;
            //        Int32 TotColumnas = 12;

            //        #region Titulo Principal

            //        // Creando Encabezado;
            //        oHoja.Cells["A1"].Value = TituloGeneral;

            //        using (ExcelRange Rango = oHoja.Cells[FilaNumero, 1, 1, TotColumnas])
            //        {
            //            Rango.Merge = true;
            //            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 12.25f, FontStyle.Bold));
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 192, 0));
            //        }

            //        oHoja.Row(FilaNumero).Height = 20;

            //        #endregion

            //        List<string> Titulos = new List<string>() { "Fecha", "Banco", "Detalle", "N° Docum.", "Docum Ref.", "RUC/DNI", "Cliente", "Concepto", "Moneda", "Debe", "Haber", "Saldo" };

            //        foreach (EmisionDocumentoCancelacionE item in ListaCancelaciones)
            //        {
            //            //#region Cabecera

            //            //if (item.Tipo == "C")
            //            //{
            //            //    FilaNumero += 2;
            //            //    oHoja.Row(FilaNumero).Height = 15;

            //            //    for (int i = 0; i < TotColumnas; i++)
            //            //    {
            //            //        oHoja.Cells[FilaNumero, i + 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8.25f, FontStyle.Bold));
            //            //        oHoja.Cells[FilaNumero, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            //        oHoja.Cells[FilaNumero, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
            //            //        oHoja.Cells[FilaNumero, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //            //        oHoja.Cells[FilaNumero, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            //        oHoja.Cells[FilaNumero, i + 1].Value = Titulos[i];

            //            //        if (i != 11)
            //            //        {
            //            //            oHoja.Cells[FilaNumero + 1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            //            oHoja.Cells[FilaNumero + 1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(198, 224, 180));
            //            //        }
            //            //    }
            //            //}

            //            //#endregion

            //            //#region Detalle

            //            //FilaNumero += 1;

            //            //oHoja.Cells[FilaNumero, 1].Style.Numberformat.Format = "dd/MM/yyyy";
            //            //oHoja.Cells[FilaNumero, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            //oHoja.Cells[FilaNumero, 1].Value = item.numDocAnticipo != "x" ? item.fecEmision : (DateTime?)null;
            //            //oHoja.Cells[FilaNumero, 2].Value = item.Banco;

            //            //oHoja.Cells[FilaNumero, 3].Style.Font.Color.SetColor(Color.FromArgb(7, 43, 118));
            //            //oHoja.Cells[FilaNumero, 3].Style.Font.Bold = true;
            //            //oHoja.Cells[FilaNumero, 3].Value = item.Tipo == "C" ? "ANTI" : item.Tipo == "D" ? "APLIC" : string.Empty;
            //            //oHoja.Cells[FilaNumero, 4].Value = item.numDocAnticipo != "x" ? item.idDocAnticipo + "/" + Global.Derecha(item.numSerieAnticipo, 3) + "-" + Global.Derecha(item.numDocAnticipo, 5) : string.Empty;

            //            //oHoja.Cells[FilaNumero, 5].Style.Font.Color.SetColor(Color.FromArgb(7, 43, 118));
            //            //oHoja.Cells[FilaNumero, 5].Style.Font.Bold = true;

            //            //if (item.Tipo == "C" || item.Tipo == "x")
            //            //{
            //            //    oHoja.Cells[FilaNumero, 5].Value = string.Empty;
            //            //}
            //            //else
            //            //{
            //            //    oHoja.Cells[FilaNumero, 5].Value = item.idDocFactura + "/" + Global.Derecha(item.numSerieFactura, 3) + "-" + Global.Derecha(item.numDocFactura, 5);
            //            //}

            //            //oHoja.Cells[FilaNumero, 6].Value = item.RUC;
            //            //oHoja.Cells[FilaNumero, 7].Value = item.Tipo == "x" ? "" : item.RazonSocial;
            //            //oHoja.Cells[FilaNumero, 8].Value = item.nomArticulo;
            //            //oHoja.Cells[FilaNumero, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            //oHoja.Cells[FilaNumero, 9].Value = item.desMoneda;

            //            //#endregion

            //            //#region Montos

            //            //oHoja.Cells[FilaNumero, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //            //oHoja.Cells[FilaNumero, 10].Style.Numberformat.Format = "###,###,##0.00";

            //            //if (item.Debe > 0)
            //            //{
            //            //    oHoja.Cells[FilaNumero, 10].Value = item.Debe;
            //            //}
            //            //else
            //            //{
            //            //    oHoja.Cells[FilaNumero, 10].Value = string.Empty;
            //            //}

            //            //oHoja.Cells[FilaNumero, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //            //oHoja.Cells[FilaNumero, 11].Style.Numberformat.Format = "###,###,##0.00";

            //            //if (item.Haber > 0)
            //            //{
            //            //    oHoja.Cells[FilaNumero, 11].Value = item.Haber;
            //            //}
            //            //else
            //            //{
            //            //    oHoja.Cells[FilaNumero, 11].Value = string.Empty;
            //            //}

            //            //oHoja.Cells[FilaNumero, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            //            //oHoja.Cells[FilaNumero, 12].Style.Numberformat.Format = "###,###,##0.00";
            //            //oHoja.Cells[FilaNumero, 12].Value = item.TotalSaldoTmp;

            //            //if (item.Tipo == "x")
            //            //{
            //            //    oHoja.Cells[FilaNumero, 8].Style.Font.Bold = true;
            //            //    oHoja.Cells[FilaNumero, 10].Style.Font.Bold = true;
            //            //    oHoja.Cells[FilaNumero, 10].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //            //    oHoja.Cells[FilaNumero, 10].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
            //            //    oHoja.Cells[FilaNumero, 11].Style.Font.Bold = true;
            //            //    oHoja.Cells[FilaNumero, 11].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //            //    oHoja.Cells[FilaNumero, 11].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
            //            //    oHoja.Cells[FilaNumero, 12].Style.Font.Bold = true;
            //            //    oHoja.Cells[FilaNumero, 12].Value = "";
            //            //}

            //            //#endregion
            //        }

            //        //Ajustando el ancho de las columnas automaticamente
            //        oHoja.Cells.AutoFitColumns();
            //        oHoja.Column(7).Width = 40;
            //        oHoja.Column(8).Width = 40;

            //        //Insertando Encabezado
            //        oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
            //        //Pie de Pagina(Derecho) "Número de paginas y el total"
            //        oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
            //        //Pie de Pagina(centro)
            //        oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

            //        //Otras Propiedades
            //        oHoja.Workbook.Properties.Title = TituloGeneral;
            //        oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
            //        oHoja.Workbook.Properties.Subject = "Reportes";
            //        oHoja.Workbook.Properties.Category = "Modulo de Ventas";
            //        oHoja.Workbook.Properties.Comments = NombrePestaña;

            //        // Establecer algunos valores de las propiedades extendidas
            //        oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

            //        //Propiedades para imprimir
            //        oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
            //        oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

            //        //Guardando el excel
            //        oExcel.Save();
            //    }
            //}
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (ListaCancelaciones == null || ListaCancelaciones.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Consolidado de Caja", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!string.IsNullOrEmpty(RutaGeneral))
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

        private void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (tipo == "B")
                {
                    DateTime FechaIni = dtpInicio.Value;
                    lblProcesando.Text = "Obteniendo Información...";
                    ListaCancelaciones = AgenteVentas.Proxy.ReporteConsolidadoCaja(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, FechaIni.ToString("yyyyMMdd"));

                    if (ListaCancelaciones.Count > 0)
                    {
                        lblProcesando.Text = "Armando el Reporte...";
                        //Generando el PDF
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

        private void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblProcesando.Text = string.Empty;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;
            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeError(string.Format("Ha ocurrido la excepción: {0}", e.Error.Message));
            }
            else
            {
                if (tipo == "B")
                {
                    if (!string.IsNullOrEmpty(RutaGeneral) && ListaCancelaciones.Count > 0)
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = string.Empty;
                    }
                    else
                    {
                        Global.MensajeComunicacion("No hay información para la fecha escogida...");
                        Global.QuitarReferenciaWebBrowser(wbNavegador);
                        RutaGeneral = string.Empty;
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Información Exportada...");
                }
            }
        }

        #endregion

        #region Eventos

        private void FrmReporteConsolidadoCaja_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, false);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;
        }

        private void LblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "B";
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
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

    public class PaginaInicialConsolCaja : PdfPageEventHelper
    {
        public DateTime FechaDoc { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            BaseColor ColorTit = new BaseColor(255, 192, 0);
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            #endregion Variables

            //Cabecera del Reporte
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };
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

            //Fila en blanco
            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda("REPORTE CONSOLIDADO DE CAJA", null, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 5f, 5f));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda("FECHA: " + FechaDoc.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 5f, 5f));
            table.CompleteRow();

            //Fila en blanco
            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            document.Add(table); //Añadiendo la tabla al documento PDF
        }

    }
}
