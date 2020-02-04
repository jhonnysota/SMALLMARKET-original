using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm;
using ClienteWinForm.Busquedas;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteOT : FrmMantenimientoBase
    {

        public frmReporteOT()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        #region Variables
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<OrdenTrabajoServicioItemE> oListaOrdenesTrabajoServ = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        string tipo = "buscar";
        String Marque = String.Empty;
        String conFecha = String.Empty;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ////FlagGrabado////
            cboEstado.DataSource = Global.CargarPC();
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "Nombre";


            List<Area> ListaAreas = VariablesLocales.SesionUsuario.UsuarioAreas;

            Area oArea = new Area() { idArea = 0, descripcion = Variables.Todos };
            ListaAreas.Add(oArea);
            ComboHelper.RellenarCombos<Area>(cboAreas, (from x in ListaAreas orderby x.idArea select x).ToList(), "idArea", "descripcion", false);
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\OrdenTrabajo";
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
                
                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    if (rbTodas.Checked == true)
                    {
                        conFecha = "N";
                    }
                    else
                    {
                        conFecha = "S";
                    }

                    oPdfw.PageEvent = new PaginaInicioOrdenTrabajo()
                    {
                        Estado = Convert.ToString(cboEstado.SelectedValue),
                        FechaInicio = dtpInicio.Value,
                        FechaFin = dtpFinal.Value,
                        conFecha = conFecha
                    };

                    docPdf.Open();

                    #region Detalle

                    int Columnas = 13;
                    PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.06f, 0.025f, 0.05f, 0.035f, 0.1f, 0.05f, 0.15f, 0.1f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f });
                    Decimal CantSoles = 0;
                    Decimal CantDolar = 0;

                    foreach (OrdenTrabajoServicioItemE item in oListaOrdenesTrabajoServ)
                    {
                        cell = new PdfPCell(new Paragraph(item.desArea, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.numeroOT.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.FechaEmision.Value.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.ruc, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.RazonSocial, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Cotizacion, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Descripcion, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.nomArticulo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Cantidad.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        if (item.idMoneda == "01")
                        {
                            cell = new PdfPCell(new Paragraph(item.ValorVenta.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            CantSoles += item.ValorVenta;
                        }
                        else
                        {
                            cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.ValorVenta.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);
                            CantDolar += item.ValorVenta;
                        }

                        cell = new PdfPCell(new Paragraph(item.SolicitudFactura, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Factura, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    cell.Colspan = 13;
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

                    cell = new PdfPCell(new Paragraph("TOTALES =>", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = 9;
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(CantSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(CantDolar.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);
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
                }
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = " Orden De Trabajo";
            NombrePestaña = " Orden De Trabajo";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 13;

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
                    oHoja.Cells[InicioLinea, 1].Value = "Descripcion";
                    oHoja.Cells[InicioLinea, 2].Value = " Orden De Trabajo";
                    oHoja.Cells[InicioLinea, 3].Value = " Fecha De Emision";
                    oHoja.Cells[InicioLinea, 4].Value = " RUC";
                    oHoja.Cells[InicioLinea, 5].Value = " Razon Social ";
                    oHoja.Cells[InicioLinea, 6].Value = " Fecha Entrega ";
                    oHoja.Cells[InicioLinea, 7].Value = " Descripcion Orden ";
                    oHoja.Cells[InicioLinea, 8].Value = " Nombre Articulo";
                    oHoja.Cells[InicioLinea, 9].Value = " Cantidad ";
                    oHoja.Cells[InicioLinea, 10].Value = " Valor Venta Soles";
                    oHoja.Cells[InicioLinea, 11].Value = " Valor Venta Dolares";
                    oHoja.Cells[InicioLinea, 12].Value = " SOLICITUD ";
                    oHoja.Cells[InicioLinea, 13].Value = " FACTURA ";

                    for (int i = 1; i <= 13; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Detallado
                    
                    Decimal CantSoles = 0;
                    Decimal CantDolar = 0;
                    Decimal Valcero = 0;

                    foreach (OrdenTrabajoServicioItemE item in oListaOrdenesTrabajoServ)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.desArea;
                        oHoja.Cells[InicioLinea, 2].Value = item.numeroOT;
                        oHoja.Cells[InicioLinea, 3].Value = item.FechaEmision;
                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 4].Value = item.ruc;
                        oHoja.Cells[InicioLinea, 5].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 6].Value = item.FechaEntrega;
                        oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 7].Value = item.Descripcion;
                        oHoja.Cells[InicioLinea, 8].Value = item.nomArticulo;
                        oHoja.Cells[InicioLinea, 9].Value = item.Cantidad;

                        if (item.idMoneda == "01")
                        {
                            oHoja.Cells[InicioLinea, 10].Value = item.ValorVenta;
                            oHoja.Cells[InicioLinea, 11].Value = Valcero;
                            CantSoles += item.ValorVenta;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 10].Value = Valcero;
                            oHoja.Cells[InicioLinea, 11].Value = item.ValorVenta;
                            CantDolar += item.ValorVenta;
                        }

                        oHoja.Cells[InicioLinea, 12].Value = item.SolicitudFactura;
                        oHoja.Cells[InicioLinea, 13].Value = item.Factura;

                        oHoja.Cells[InicioLinea, 10, InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 9].Value = "TOTALES";
                    oHoja.Cells[InicioLinea, 10].Value = CantSoles;
                    oHoja.Cells[InicioLinea, 11].Value = CantDolar;
                    oHoja.Cells[InicioLinea, 10, InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;

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
                    oHoja.Workbook.Properties.Category = "Modulo de Comisiones";
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

        #region Procedimiento Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaOrdenesTrabajoServ == null || oListaOrdenesTrabajoServ.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }


                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Reporte Orden De Trabajo", "Archivos Excel (*.xlsx)|*.xlsx");

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
                    DateTime fecIni;
                    DateTime fecFin;
                    Int32 idCliente;
                    String Estado = Convert.ToString(cboEstado.SelectedValue);

                    if (rbTodosCLientes.Checked)
                    {
                        idCliente = Variables.Cero;
                    }
                    else
                    {
                        idCliente = !String.IsNullOrEmpty(txtIdAuxiliar.Text) ? Convert.ToInt32(txtIdAuxiliar.Text) : Variables.Cero;
                    }

                    if (rbTodas.Checked)
                    {
                        fecIni = Convert.ToDateTime("01/01/1900");
                        fecFin = Convert.ToDateTime("31/12/2999");
                    }
                    else
                    {
                        fecIni = dtpInicio.Value.Date;
                        fecFin = dtpFinal.Value.Date;
                    }

                    Int32 Areas;

                    if (chkAreas.Checked == false)
                    {
                        Areas = Convert.ToInt32(cboAreas.SelectedValue);
                    }
                    else
                    {
                        Areas = 0;
                    }

                    lblProcesando.Text = "Obteniendo las Ordenes de Trabajo...";
                    oListaOrdenesTrabajoServ = AgenteVentas.Proxy.ListarReporteOTPorEstado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Estado, idCliente, Areas, fecIni, fecFin);
                    lblProcesando.Text = "Armando Las Ordenes...";
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
                    Global.MensajeComunicacion("Orden de Trabajo Exportado...");
                }
            }
        }

        #endregion

        #region Eventos

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

        private void frmReporteOT_Load(object sender, EventArgs e)
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
        }

        private void chkAreas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAreas.Checked)
            {
                cboAreas.Enabled = false;
                cboAreas.SelectedValue = 0;
                Buscar();
            }
            else
            {
                cboAreas.Enabled = true;
                Buscar();
            }
        }

        private void rbDesde_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = rbDesde.Checked;
            dtpFinal.Enabled = rbDesde.Checked;
        }

        private void rbTodosCLientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosCLientes.Checked)
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);

            }
            else
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);

                txtRuc.Focus();
            }
        }

        private void txtIdAuxiliar_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdAuxiliar.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ID", txtIdAuxiliar.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El ID del Auxiliar ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtIdAuxiliar.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

    }
}

#region Inicio Pdf

class PaginaInicioOrdenTrabajo : PdfPageEventHelper
{
    public String Estado { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public String conFecha { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;
        String EstadoDes = String.Empty ;

        if (Estado == "P")
        {
            EstadoDes = "PENDIENTE";
        }
        else
        {
            EstadoDes = "CERRADO";
        }

        TituloGeneral = "Ordenes De Trabajo " + EstadoDes;

        if (conFecha == "S")
        {
            SubTitulo = "Desde " + FechaInicio.ToString("d") + " Hasta " + FechaFin.ToString("d");
        }
        else
        {
            SubTitulo = " ";
        }

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

        PdfPTable TablaCabDetalle = new PdfPTable(13);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.06f, 0.025f, 0.05f, 0.035f, 0.1f, 0.05f, 0.15f, 0.1f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f });

        #region Primera Linea

        cell = new PdfPCell(new Paragraph("Area Y/o C.Costo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Orden De Trabajo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Fecha Emisión", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("RUC", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Razon Social", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Cotizacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Descripcion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Nombre Articulo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Cantidad", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Valor Venta Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Valor Venta Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("SOLICITUD", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("FACTURA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);


        TablaCabDetalle.CompleteRow();

        #endregion

        #endregion        

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

    }

}

#endregion
