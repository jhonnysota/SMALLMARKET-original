using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Ventas;
using ClienteWinForm;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteAnticipos : FrmMantenimientoBase
    {

        public frmReporteAnticipos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            
            LlenarCombos();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<AnticiposE> oAnticipos = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marque = String.Empty;
        String tipo = "B";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /// Monedas ///
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            /// Tipo Anticipos ///
            cboEstados.DataSource = Global.CargarTipoAnticipo();
            cboEstados.ValueMember = "id";
            cboEstados.DisplayMember = "Nombre";
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Anticipos " + Aleatorio.ToString();
            String Extension = ".pdf";
            BaseColor ColorLetra = new BaseColor(7, 43, 118);
            BaseColor ColorAnticipo = new BaseColor(198, 224, 180);

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio si no existe...
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

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                    oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    PaginaInicialAnticipos ev = new PaginaInicialAnticipos();
                    //Parametros que pasará al PDF
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    PdfPTable TablaCabDetalle = new PdfPTable(12);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.035f, 0.05f, 0.035f, 0.045f, 0.045f, 0.05f, 0.18f, 0.2f, 0.035f, 0.04f, 0.04f, 0.04f });
                    List<String> Titulos = new List<String>() { "Fecha", "Banco", "Detalle", "N° Docum.", "Docum Ref.", "RUC/DNI", "Cliente", "Concepto", "Moneda", "Debe", "Haber", "Saldo" };

                    foreach (AnticiposE item in oAnticipos)
                    {
                        if (item.Tipo == "C")
                        {
                            foreach (String tit in Titulos)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(tit, null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 3f, 3f));
                            }

                            TablaCabDetalle.CompleteRow();
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocAnticipo != "x" ? item.fecEmision.ToString("d") : "", item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Banco, item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Tipo == "C" ? "ANTI" : item.Tipo == "D" ? "APLIC" : "", item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, ColorLetra), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocAnticipo != "x" ? item.idDocAnticipo + "/" + Global.Derecha(item.numSerieAnticipo, 3) + "-" + Global.Derecha(item.numDocAnticipo, 5) : "", item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));

                        if (item.Tipo == "C" || item.Tipo == "x")
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N"));
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocFactura + "/" + Global.Derecha(item.numSerieFactura, 3) + "-" + Global.Derecha(item.numDocFactura, 5), item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, ColorLetra), 5, 1, "N", "N"));
                        }

                        if (item.Tipo != "x")
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RUC, item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Debe > 0 ? item.Debe.ToString("N2") : String.Empty, item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Haber > 0 ? item.Haber.ToString("N2") : String.Empty, item.Tipo == "C" ? ColorAnticipo : null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalSaldoTmp.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, (item.CambiarColor == true ? BaseColor.RED : BaseColor.BLACK)), 5, 2, "N", "N"));

                            TablaCabDetalle.CompleteRow();
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Debe > 0 ? item.Debe.ToString("N2") : String.Empty, null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 2, 2, "S", "S", "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Haber > 0 ? item.Haber.ToString("N2") : String.Empty, null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 2, 2, "S", "S", "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));

                            TablaCabDetalle.CompleteRow();

                            //Fila en blanco
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S12"));
                            TablaCabDetalle.CompleteRow();
                        }
                    }

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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Reporte de Anticipos Recibidos";
            NombrePestaña = "Anticipos";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);
            
            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 FilaNumero = 1;
                    Int32 TotColumnas = 12;

                    #region Titulo Principal

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[FilaNumero, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 12.25f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 192, 0));
                    }

                    oHoja.Row(FilaNumero).Height = 20;

                    #endregion

                    List<String> Titulos = new List<String>() { "Fecha", "Banco", "Detalle", "N° Docum.", "Docum Ref.", "RUC/DNI", "Cliente", "Concepto", "Moneda", "Debe", "Haber", "Saldo" };

                    foreach (AnticiposE item in oAnticipos)
                    {
                        #region Cabecera

                        if (item.Tipo == "C")
                        {
                            FilaNumero += 2;
                            oHoja.Row(FilaNumero).Height = 15;

                            for (int i = 0; i < TotColumnas; i++)
                            {
                                oHoja.Cells[FilaNumero, i + 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8.25f, FontStyle.Bold));
                                oHoja.Cells[FilaNumero, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[FilaNumero, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                                oHoja.Cells[FilaNumero, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[FilaNumero, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[FilaNumero, i + 1].Value = Titulos[i];

                                if (i != 11)
                                {
                                    oHoja.Cells[FilaNumero + 1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[FilaNumero + 1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(198, 224, 180));
                                }
                            }
                        }

                        #endregion

                        #region Detalle

                        FilaNumero += 1;

                        oHoja.Cells[FilaNumero, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[FilaNumero, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[FilaNumero, 1].Value = item.numDocAnticipo != "x" ? item.fecEmision : (DateTime?)null;
                        oHoja.Cells[FilaNumero, 2].Value = item.Banco;

                        oHoja.Cells[FilaNumero, 3].Style.Font.Color.SetColor(Color.FromArgb(7, 43, 118));
                        oHoja.Cells[FilaNumero, 3].Style.Font.Bold = true;
                        oHoja.Cells[FilaNumero, 3].Value = item.Tipo == "C" ? "ANTI" : item.Tipo == "D" ? "APLIC" : String.Empty;
                        oHoja.Cells[FilaNumero, 4].Value = item.numDocAnticipo != "x" ? item.idDocAnticipo + "/" + Global.Derecha(item.numSerieAnticipo, 3) + "-" + Global.Derecha(item.numDocAnticipo, 5) : String.Empty;

                        oHoja.Cells[FilaNumero, 5].Style.Font.Color.SetColor(Color.FromArgb(7, 43, 118));
                        oHoja.Cells[FilaNumero, 5].Style.Font.Bold = true;

                        if (item.Tipo == "C" || item.Tipo == "x")
                        {
                            oHoja.Cells[FilaNumero, 5].Value = String.Empty;
                        }
                        else
                        {
                            oHoja.Cells[FilaNumero, 5].Value = item.idDocFactura + "/" + Global.Derecha(item.numSerieFactura, 3) + "-" + Global.Derecha(item.numDocFactura, 5);
                        }

                        oHoja.Cells[FilaNumero, 6].Value = item.RUC;
                        oHoja.Cells[FilaNumero, 7].Value = item.Tipo == "x" ? "" : item.RazonSocial;
                        oHoja.Cells[FilaNumero, 8].Value = item.nomArticulo;
                        oHoja.Cells[FilaNumero, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[FilaNumero, 9].Value = item.desMoneda; 

                        #endregion

                        #region Montos

                        oHoja.Cells[FilaNumero, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaNumero, 10].Style.Numberformat.Format = "###,###,##0.00";

                        if (item.Debe > 0)
                        {
                            oHoja.Cells[FilaNumero, 10].Value = item.Debe;
                        }
                        else
                        {
                            oHoja.Cells[FilaNumero, 10].Value = String.Empty;
                        }

                        oHoja.Cells[FilaNumero, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaNumero, 11].Style.Numberformat.Format = "###,###,##0.00";

                        if (item.Haber > 0)
                        {
                            oHoja.Cells[FilaNumero, 11].Value = item.Haber;
                        }
                        else
                        {
                            oHoja.Cells[FilaNumero, 11].Value = String.Empty;
                        }

                        oHoja.Cells[FilaNumero, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaNumero, 12].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[FilaNumero, 12].Value = item.TotalSaldoTmp;

                        if (item.Tipo == "x")
                        {
                            oHoja.Cells[FilaNumero, 8].Style.Font.Bold = true;
                            oHoja.Cells[FilaNumero, 10].Style.Font.Bold = true;
                            oHoja.Cells[FilaNumero, 10].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            oHoja.Cells[FilaNumero, 10].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                            oHoja.Cells[FilaNumero, 11].Style.Font.Bold = true;
                            oHoja.Cells[FilaNumero, 11].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            oHoja.Cells[FilaNumero, 11].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                            oHoja.Cells[FilaNumero, 12].Style.Font.Bold = true;
                            oHoja.Cells[FilaNumero, 12].Value = "";
                        } 

                        #endregion
                    }

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();
                    oHoja.Column(7).Width = 40;
                    oHoja.Column(8).Width = 40;

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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
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

        public override void Exportar()
        {
            try
            {
                if (oAnticipos == null || oAnticipos.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Anticipos " + cboEstados.Text.ToString() + " en " + ((MonedasE)cboMoneda.SelectedItem).desMoneda, "Archivos Excel (*.xlsx)|*.xlsx");

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
                if (tipo == "B")
                {
                    DateTime FechaIni = dtpInicio.Value;
                    DateTime FechaFin = dtpFinal.Value;
                    Int32 Tipo = Convert.ToInt32(cboEstados.SelectedValue);
                    String Moneda = Convert.ToString(cboMoneda.SelectedValue);
                    Int32 idPersona = Convert.ToInt32(txtRazonSocial.Tag);

                    lblProcesando.Text = "Obteniendo Anticipos...";

                    if (Tipo == 0)
                    {
                        oAnticipos = AgenteVentas.Proxy.ReporteAnticipos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, FechaIni, FechaFin, Moneda, idPersona, false, false);
                    }
                    else
                    {
                        oAnticipos = AgenteVentas.Proxy.ReporteAnticipos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, FechaIni, FechaFin, Moneda, idPersona, false, true);
                    }

                    lblProcesando.Text = "Armando el Reporte...";
                    
                    //Generando el PDF
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
            btBuscar.Enabled = true;
            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeError(String.Format("Ha ocurrido la excepción: {0}", e.Error.Message));
            }
            else
            {
                if (tipo == "B")
                {
                    if (!String.IsNullOrEmpty(RutaGeneral) && oAnticipos.Count > 0)
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                    }
                    else
                    {
                        Global.QuitarReferenciaWebBrowser(wbNavegador);
                        RutaGeneral = String.Empty;
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Anticipos Exportado...");
                } 
            }
        }

        #endregion

        #region Eventos

        private void frmReporteAnticipos_Load(object sender, EventArgs e)
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

            txtRazonSocial.Tag = 0;
        }

        private void btBuscar_Click(object sender, EventArgs e)
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

        private void frmReporteDifCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                txtRazonSocial.Tag = 0;
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > 1)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRazonSocial.Tag = oFrm.oPersona.IdPersona;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRazonSocial.Tag = oListaPersonas[0].IdPersona;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRazonSocial.Tag = 0;
                        txtRazonSocial.Text = String.Empty;

                        Global.MensajeFault("La Razón Social ingresado no existe");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        } 

        #endregion

    }
}

public class PaginaInicialAnticipos : PdfPageEventHelper
{

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        #region Variables

        BaseColor ColorTit = new BaseColor(255, 192, 0);
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

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda("REPORTE DE ANTICIPOS RECIBIDOS", ColorTit, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 5f, 5f));
        table.CompleteRow();

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        table.CompleteRow();

        document.Add(table); //Añadiendo la tabla al documento PDF
    }

}