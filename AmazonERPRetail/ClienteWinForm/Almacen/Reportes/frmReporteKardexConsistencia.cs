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
    public partial class frmReporteKardexConsistencia : FrmMantenimientoBase
    {

        public frmReporteKardexConsistencia()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        readonly BackgroundWorker _bw = new BackgroundWorker();
        List<kardexE> ReporteFinal = null;
        String RutaGeneral = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////Mes Inicio////
            cboInicioMes.DataSource = FechasHelper.CargarMeses(1, true, "MA");
            cboInicioMes.ValueMember = "MesId";
            cboInicioMes.DisplayMember = "MesDes";

            /////Mes Fin////
            cbofinMes.DataSource = FechasHelper.CargarMeses(1, true, "MA");
            cbofinMes.ValueMember = "MesId";
            cbofinMes.DisplayMember = "MesDes";

            /////Años/////
            Int32 anioFin = Convert.ToInt32(VariablesLocales.FechaHoy.ToString("yyyy"));
            Int32 anioInicio = anioFin - 5;

            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";

            cboAnio.SelectedValue = Convert.ToInt32(anioFin);
            cboInicioMes.SelectedValue = VariablesLocales.FechaHoy.ToString("MM");
            cbofinMes.SelectedValue = VariablesLocales.FechaHoy.ToString("MM");

            //Tipo de Articulos
            List <ParTabla> ListaTipos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaTipos.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaTipos orderby x.IdParTabla select x).ToList());

            ListaTipos = null;
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Consistencia De Kardex " + Aleatorio.ToString();
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

                oPdfw.PageEvent = new PagInicioKardexConsistencia
                {
                    tipMov = ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre,
                    Periodo = " A " + cbofinMes.Text.ToString().ToUpper() + " - " + cboAnio.SelectedValue.ToString(),
                };

                docPdf.Open();

                #region Detalle

                BaseColor ColorLetra = new BaseColor(255, 0, 0); // Rojo
                PdfPTable TablaCabDetalle = new PdfPTable(8);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.03f, 0.1f, 0.03f, 0.04f, 0.22f, 0.06f, 0.06f, 0.06f });



                for (int i = 0; i < ReporteFinal.Count; i++)
                {
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ReporteFinal[i].idAlmacen.ToString(), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ReporteFinal[i].desAlmacen, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ReporteFinal[i].idArticulo.ToString(), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ReporteFinal[i].codArticulo, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ReporteFinal[i].nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, -1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ReporteFinal[i].KardexSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ReporteFinal[i].StockSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ReporteFinal[i].Diferencia.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2));
                    TablaCabDetalle.CompleteRow();
                }
                

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

        void ExportarExcel(List<kardexE> Reporte, String Ruta)
        {
            #region Variables

            String NombrePestaña = "CONSISTENCIA";
            Int32 totCols = 8;
            Int32 FilaIni = 5;

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

                    String TituloGeneral = "CONSISTENCIA DE KARDEX - " + ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre;
                    String SubTitulos = String.Empty;
                    if (cboInicioMes.Text.ToString().ToUpper() == cbofinMes.Text.ToString().ToUpper())
                    {
                        SubTitulos = "(" + " AL " + cbofinMes.Text.ToString().ToUpper() + "-" + cboAnio.SelectedValue.ToString() + ")";
                    }
                    else
                    {
                        SubTitulos = "(" + cboInicioMes.Text.ToString().ToUpper() + " AL " + cbofinMes.Text.ToString().ToUpper() + "-" + cboAnio.SelectedValue.ToString() + ")";
                    }


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

                    oHoja.Cells[FilaIni, 1].Value = "ALMACEN";
                    oHoja.Cells[FilaIni, 2].Value = "DESCRIPCION ALMACEN";
                    oHoja.Cells[FilaIni, 3].Value = "ARTICULO";
                    oHoja.Cells[FilaIni, 4].Value = "COD. ARTICULO";
                    oHoja.Cells[FilaIni, 5].Value = "NOM. ARTICULO";
                    oHoja.Cells[FilaIni, 6].Value = "KARDEX";
                    oHoja.Cells[FilaIni, 7].Value = "STOCK";
                    oHoja.Cells[FilaIni, 8].Value = "DIFERENCIA";



                    for (int i = 1; i <= totCols; i++)
                    {
                        oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[FilaIni, i].Style.Font.Bold = true;
                        oHoja.Cells[FilaIni, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    oHoja.Column(1).Width = 10; //ALMACEN
                    oHoja.Column(2).Width = 30; //DESCRIPCION ALMACEN
                    oHoja.Column(3).Width = 10; //ARTICULO
                    oHoja.Column(4).Width = 18; //COD. ARTICULO
                    oHoja.Column(5).Width = 48; //NOM. ARTICULO
                    oHoja.Column(6).Width = 15; //KARDEX
                    oHoja.Column(7).Width = 15; //STOCK
                    oHoja.Column(8).Width = 15; //DIFERENCIA

                    FilaIni++;

                    #endregion

                    foreach (kardexE item in Reporte)
                    {
                        oHoja.Cells[FilaIni, 1].Value = item.idAlmacen;
                        oHoja.Cells[FilaIni, 2].Value = item.desAlmacen;
                        oHoja.Cells[FilaIni, 3].Value = item.idArticulo;
                        oHoja.Cells[FilaIni, 4].Value = item.codArticulo;
                        oHoja.Cells[FilaIni, 5].Value = item.nomArticulo;
                        oHoja.Cells[FilaIni, 6].Value = item.KardexSoles;
                        oHoja.Cells[FilaIni, 6].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[FilaIni, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaIni, 7].Value = item.StockSoles;
                        oHoja.Cells[FilaIni, 7].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[FilaIni, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaIni, 8].Value = item.Diferencia;
                        oHoja.Cells[FilaIni, 8].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[FilaIni, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        FilaIni++;
                    }

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

        #region Eventos Heredados

        public override void Buscar()
        {
            Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            lblProcesando.Text = "Obteniendo las Consistencias...";
            ReporteFinal = AgenteAlmacen.Proxy.KardexConsistencia(idEmpresa, cboAnio.SelectedValue.ToString(), cboInicioMes.SelectedValue.ToString(), cbofinMes.SelectedValue.ToString(), Convert.ToInt32(cboTipoAlmacen.SelectedValue), Convert.ToInt32(cboAlmacen.SelectedValue));
            lblProcesando.Text = "Armando el Reporte...";

            if (ReporteFinal.Count > 0)
            {
                ConvertirApdf();
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
                if (ReporteFinal == null || ReporteFinal.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreArchivo = "CONSISTENCIA DE KARDEX " + ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre.ToUpper() + " " + cboInicioMes.Text.ToString().ToUpper() + " AL " + cbofinMes.Text.ToString().ToUpper() + "-" + cboAnio.SelectedValue.ToString();
                NombreArchivo = NombreArchivo.Replace("<<", "-").Replace(">>", "-");
                String RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrWhiteSpace(RutaExcel))
                {
                    ExportarExcel(ReporteFinal, RutaExcel);
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
            //panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

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

        private void frmReporteMovAlmacenPorTipoAlmacen_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }

    class PagInicioKardexConsistencia : PdfPageEventHelper
    {
        public String tipMov { get; set; }
        public String Periodo { get; set; }


        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            PdfPTable table = null;
            BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
            #endregion Variables

            //Para el encabezado
            table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            tipMov = tipMov.Replace("<<", "").Replace(">>", "").Trim();


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

            #region Titulo Principal

            table.AddCell(ReaderHelper.NuevaCelda("CONSISTENCIA DE KARDEX - " + tipMov, null, "N", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            table.AddCell(ReaderHelper.NuevaCelda("(" + Periodo + ")", null, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            //Fila en blanco
            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N"));
            table.CompleteRow();

            #endregion

            document.Add(table); //Añadiendo la tabla al documento PDF

            #region Cabecera del Detalle

            PdfPTable TablaCabDetalle = new PdfPTable(8);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.03f, 0.1f, 0.03f, 0.04f, 0.22f, 0.06f, 0.06f, 0.06f });

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Almacen", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Decripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Articulo", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Cod. Articulo", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Nom. Articulo", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Kardex", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Stock", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Diferencia ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));           
            TablaCabDetalle.CompleteRow();
            document.Add(TablaCabDetalle);

            #endregion

        }
    }

}
