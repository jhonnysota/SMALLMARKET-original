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
using Entidades.Maestros;
using ClienteWinForm;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteHojaCosto : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteHojaCosto()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarTipoArticulo();
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<HojaCostoE> oReporteHojaCosto = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Marque = String.Empty;
        string tipo = "buscar";
        Int32 idArticulo = 0;

        #endregion

        private void LlenarTipoArticulo()
        {
            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione });
            ComboHelper.LlenarCombos(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
        }

        #region Procedimientos Heredados

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

                PaginaIniciohojaCostos ev = new PaginaIniciohojaCostos();

                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Detalle
                
                    PdfPTable TablaCabDetalle = new PdfPTable(18);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.17f, 0.17f, 0.1f, 0.2f, 0.4f, 0.17f, 0.4f, 0.12f, 0.12f, 0.12f, 0.1f, 0.1f, 0.12f, 0.1f, 0.1f, 0.12f, 0.1f, 0.14f });

                foreach (HojaCostoE item in oReporteHojaCosto)
                {
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaIngreso.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f),5,1)); 
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DUA, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1)); 
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FactComercial, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, -1)); //LOTEALMACEN
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, -1));//STOCK

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//STOCK
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, -1));//STOCK

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, -1));//CONTE
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//CONTE

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//UNIDADMED
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.cantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, -1));//CONTE
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FobUnitario.ToString("N4"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, -1));//U.M.PRESE
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CostoUnitarioME.ToString("N4"), null, "N", null, FontFactory.GetFont("Arial", 5f),5,-1));//NOMBRE ORIGEN
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Factor.ToString("N4"), null, "N", null, FontFactory.GetFont("Arial", 5f),5,-1));//NOMBRE PROCEDENCIA
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ValorFob.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f),5,-1));//LOTEPROVEEDOR
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CostoTotalME.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, -1));//BATCH
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DesTransporte, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//PORCENTGERM
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.NomTipoArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));//FECHADEPRUEBA

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

        void ExportarExcel(String Ruta)
        {
            string TituloGeneral = " Consulta de Importaciones (Expresado en ME)";
            string NombrePestaña = " Consulta de Importaciones ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 18;

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
                    oHoja.Cells[InicioLinea, 1].Value = " Fecha Hoja De Costo ";
                    oHoja.Cells[InicioLinea, 2].Value = " Fecha Ing. Alm. ";
                        oHoja.Cells[InicioLinea, 3].Value = " DUA ";
                        oHoja.Cells[InicioLinea, 4].Value = " Factura ";
                        oHoja.Cells[InicioLinea, 5].Value = " Proveedor ";

                        oHoja.Cells[InicioLinea, 6].Value = " Cod. Articulo ";
                        oHoja.Cells[InicioLinea, 7].Value = " Articulo";
                        oHoja.Cells[InicioLinea, 8].Value = " Cant. Present. ";

                        oHoja.Cells[InicioLinea, 9].Value = " Und. Medida ";

                        oHoja.Cells[InicioLinea, 10].Value = " Envas de Present. ";

                        oHoja.Cells[InicioLinea, 11].Value = " Cant. ";
                        oHoja.Cells[InicioLinea, 12].Value = " FOB ";


                        oHoja.Cells[InicioLinea, 13].Value = " Costo P.Almacen ";

                        oHoja.Cells[InicioLinea, 14].Value = " Factor ";
                        oHoja.Cells[InicioLinea, 15].Value = " Total FOB";
                        oHoja.Cells[InicioLinea, 16].Value = " Total Costo P.Almacen ";

                        oHoja.Cells[InicioLinea, 17].Value = " Transporte ";
                        oHoja.Cells[InicioLinea, 18].Value = " Tipo Alm. ";

                        for (int i = 1; i <= 18; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }



                    //Aumentando una Fila mas continuar con el detalle


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle



                        foreach (HojaCostoE item in oReporteHojaCosto)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.Fecha;

                            oHoja.Cells[InicioLinea, 2].Value = item.FechaIngreso;
                            oHoja.Cells[InicioLinea, 3].Value = item.DUA;
                            oHoja.Cells[InicioLinea, 4].Value = item.FactComercial;

                            oHoja.Cells[InicioLinea, 5].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 6].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 7].Value = item.nomArticulo;

                            oHoja.Cells[InicioLinea, 8].Value = item.Contenido;
                            oHoja.Cells[InicioLinea, 9].Value = item.nomUMedidaEnv;

                            oHoja.Cells[InicioLinea, 10].Value = item.nomUMedidaPres;
                            oHoja.Cells[InicioLinea, 11].Value = item.cantidad;

                            oHoja.Cells[InicioLinea, 12].Value = item.FobUnitario;

                            oHoja.Cells[InicioLinea, 13].Value = item.CostoUnitarioME;
                            oHoja.Cells[InicioLinea, 14].Value = item.Factor;
                            oHoja.Cells[InicioLinea, 15].Value = item.ValorFob;

                            oHoja.Cells[InicioLinea, 16].Value = item.CostoTotalME;
                            oHoja.Cells[InicioLinea, 17].Value = item.DesTransporte;
                            oHoja.Cells[InicioLinea, 18].Value = item.NomTipoArticulo;

                            oHoja.Cells[InicioLinea, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.0000";
                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.0000";
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.0000";
                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
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
               
        public override void Exportar()
        {
            try
            {
                if (oReporteHojaCosto == null || oReporteHojaCosto.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Hoja de Costos en" + "-" + VariablesLocales.SesionUsuario.Empresa.NombreComercial + "-" , "Archivos Excel (*.xlsx)|*.xlsx");

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
                string Fecha = dtpFechaIni.Value.ToString("yyyyMMdd");
                string FechaFin = dtpFechaFin.Value.ToString("yyyyMMdd");
                String Proveedor = txtProveedor.Text;
                String articulo = txtArt.Text;
                String Desart = txtNomArt.Text;
                lblProcesando.Text = "Obteniendo el Reporte Hoja Costo...";
                oReporteHojaCosto = AgenteAlmacen.Proxy.ReporteHojaCosto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,Fecha,FechaFin, Proveedor, articulo, Desart);
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
                Global.MensajeComunicacion("Hoja de Costo Exportado...");
            }
        }

        private void frmReporteHojaCosto_Load(object sender, EventArgs e)
        {
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

        private void frmReporteHojaCosto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
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

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == false)
            {
                btProveedor.Enabled = true;
            }
            if (chkTodos.Checked == true)
            {
                btProveedor.Enabled = false;
            }
        }

        #endregion

        private void btProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaProveedor oFrm = new frmBusquedaProveedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProveedor != null)
                {
                    txtidProveedor.Text = oFrm.oProveedor.IdPersona.ToString();
                    txtProveedor.Text = oFrm.oProveedor.RazonSocial;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked)
            {
                cboAlmacen.Enabled = false;
                idArticulo = 0;
                txtArt.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtNomArt.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else
            {
                cboAlmacen.Enabled = true;
                txtArt.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txtNomArt.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txtArt.Focus();
            }
        }

        private void txtArt_TextChanged(object sender, EventArgs e)
        {
            idArticulo = 0;
            txtNomArt.Text = string.Empty;
        }

        private void txtNomArt_TextChanged(object sender, EventArgs e)
        {
            idArticulo = 0;
            txtArt.Text = string.Empty;
        }

        private void txtArt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtArt.Text.Trim()) && string.IsNullOrEmpty(txtNomArt.Text.Trim()))
                {
                    txtArt.TextChanged -= txtArt_TextChanged;
                    txtNomArt.TextChanged -= txtNomArt_TextChanged;

                    List<ArticuloServE> oListaArticulo = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                    txtArt.Text.Trim(), "");
                    if (oListaArticulo.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulo);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            idArticulo = oFrm.oArticulo.idArticulo;
                            txtArt.Text = oFrm.oArticulo.codArticulo;
                            txtNomArt.Text = oFrm.oArticulo.nomArticulo;
                        }
                    }
                    else if (oListaArticulo.Count == 1)
                    {
                        idArticulo = oListaArticulo[0].idArticulo;
                        txtArt.Text = oListaArticulo[0].codArticulo;
                        txtNomArt.Text = oListaArticulo[0].nomArticulo;
                    }
                    else
                    {
                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                        idArticulo = 0;
                        txtArt.Text = string.Empty;
                        txtNomArt.Text = string.Empty;
                        txtArt.Focus();
                    }

                    txtArt.TextChanged += txtArt_TextChanged;
                    txtNomArt.TextChanged += txtNomArt_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtNomArt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNomArt.Text.Trim()) && string.IsNullOrEmpty(txtArt.Text.Trim()))
                {
                    txtArt.TextChanged -= txtArt_TextChanged;
                    txtNomArt.TextChanged -= txtNomArt_TextChanged;

                    List<ArticuloServE> oListaArticulo = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                    "", txtNomArt.Text.Trim());
                    if (oListaArticulo.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulo);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            idArticulo = oFrm.oArticulo.idArticulo;
                            txtArt.Text = oFrm.oArticulo.codArticulo;
                            txtNomArt.Text = oFrm.oArticulo.nomArticulo;
                        }
                    }
                    else if (oListaArticulo.Count == 1)
                    {
                        idArticulo = oListaArticulo[0].idArticulo;
                        txtArt.Text = oListaArticulo[0].codArticulo;
                        txtNomArt.Text = oListaArticulo[0].nomArticulo;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                        idArticulo = 0;
                        txtArt.Text = string.Empty;
                        txtNomArt.Text = string.Empty;
                        txtNomArt.Focus();
                    }

                    txtArt.TextChanged += txtArt_TextChanged;
                    txtNomArt.TextChanged += txtNomArt_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

    }
}



#region Pdf Inicio

class PaginaIniciohojaCostos : PdfPageEventHelper
{
    public String TipoReport { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {

        base.OnStartPage(writer, document);

        String NombreMes = String.Empty;
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro

        TituloGeneral = "Consulta de Importaciones (EXPRESADO EN ME) ";



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

        PdfPTable TablaCabDetalle = new PdfPTable(18);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.17f, 0.17f, 0.1f, 0.2f, 0.4f, 0.17f, 0.4f, 0.12f, 0.12f, 0.12f, 0.1f, 0.1f, 0.12f, 0.1f, 0.1f, 0.12f, 0.1f, 0.14f });

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA HOJA DE COSTO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA ING. ALM.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DUA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FACTURA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PROVEEDOR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COD. ARTICULO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ARTICULO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANT. PRESENT.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UND. MEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ENVASE DE PRESENT.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANT.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FOB", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COSTO P. ALMACEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FACTOR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL FOB", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL COSTO P. ALMACEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TRANSPORTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIPO ALM.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.CompleteRow();
        document.Add(TablaCabDetalle);

        #endregion

        //Añadiendo la tabla al documento PDF

    }
}

#endregion