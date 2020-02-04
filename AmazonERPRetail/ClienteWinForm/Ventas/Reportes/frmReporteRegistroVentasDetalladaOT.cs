using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm;
using ClienteWinForm.Busquedas;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteRegistroVentasDetalladaOT : FrmMantenimientoBase
    {

        public frmReporteRegistroVentasDetalladaOT()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        #region Variables
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<EmisionDocumentoE> oListaRegistrosVentaDetallada = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        string tipo = "buscar";
        String Marque = String.Empty;

        #endregion

        #region Procedimientos de Pdf

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A3.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Venta Detallada Por OT " + Aleatorio.ToString();
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

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

                InicioVentaDetalladaOT ev = new InicioVentaDetalladaOT();
                ev.Periodo = dtpInicio.Value.Date.ToString("dd/MM/yyyy") + " al " + dtpFin.Value.Date.ToString("d//MM/yyyy");
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle
                Decimal tot1 = 0;
                Decimal tot2 = 0;
                int Columnas = 16;
                PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.06f, 0.1f, 0.05f, 0.1f, 0.08f, 0.12f, 0.08f, 0.05f, 0.35f, 0.4f, 0.1f, 0.4f, 0.09f, 0.09f, 0.09f, 0.06f });

                foreach (EmisionDocumentoE item in oListaRegistrosVentaDetallada)
                {
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Anio, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Mov, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numSerie + " - " + item.numDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    //Por revisar//TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecEmision.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Guia, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Pedido, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nroOt.ToString(), null, "N", null, FontFactory.GetFont("Arial", 5f), 5,1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nroOtItem.ToString(), null, "N", null, FontFactory.GetFont("Arial", 5f), 5,1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Glosa, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Ruc, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Soles.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    tot1 += item.Soles;
                    tot2 += item.Dolares;
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Dolares.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomVendedor, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desEstablecimiento, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desZonaTrabajo, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCondicion, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaPago, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.OPeracion, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));


                    TablaCabDetalle.CompleteRow();
                }
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), 5, 1, "S13"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("_______________", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("_______________", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), 5, 1));
                TablaCabDetalle.CompleteRow();

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTALES", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2, "S13"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(tot1.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(tot2.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), 5, 1));
                TablaCabDetalle.CompleteRow();

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), 5, 1, "S13"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("_______________", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("_______________", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), 5, 1));
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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                Int32 Vendedor = 0;
                Int32 Cliente = 0;

                if (txtIdVendedor.Text != "")
                {
                    Vendedor = Convert.ToInt32(txtIdVendedor.Text);
                }

                if (txtIdCliente.Text != "")
                {
                    Cliente = Convert.ToInt32(txtIdCliente.Text);
                }
       
                lblProcesando.Text = "Obteniendo los Registros de Ventas Detallada...";
                oListaRegistrosVentaDetallada = AgenteVentas.Proxy.ListarReporteVentasDetalladaOT(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, dtpInicio.Value.ToString("yyyyMMdd"), dtpFin.Value.ToString("yyyyMMdd"), Vendedor, Cliente);
                lblProcesando.Text = "Armando Las Ventas Detallada...";
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
                Global.MensajeComunicacion("Registros de Ventas Detallado Exportado...");
            }
        }

        void CambioVendedor()
        {
            txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;
            txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
            if (chkVendedores.Checked == true)
            {
                txtNombresVendedor.Enabled = false;
                txtNroDocumentoVen.Enabled = false;
                txtNombresVendedor.BackColor = SystemColors.InactiveCaption;
                txtNroDocumentoVen.BackColor = SystemColors.InactiveCaption;
            }
            else
            {
                txtNombresVendedor.Clear();
                txtNroDocumentoVen.Clear();
                txtNombresVendedor.Enabled = true;
                txtNroDocumentoVen.Enabled = true;
                txtNombresVendedor.BackColor = Color.WhiteSmoke;
                txtNroDocumentoVen.BackColor = Color.WhiteSmoke;
            }
            txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;
            txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
        }

        void CambioCliente()
        {
            txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
            txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;
            if (chbClientes.Checked == true)
            {
                txtRazonCliente.Enabled = false;
                txtRucCLiente.Enabled = false;
                txtRucCLiente.BackColor = SystemColors.InactiveCaption;
                txtRazonCliente.BackColor = SystemColors.InactiveCaption;
            }
            else
            {
                txtRazonCliente.Clear();
                txtRucCLiente.Clear();
                txtRazonCliente.Enabled = true;
                txtRucCLiente.Enabled = true;
                txtRucCLiente.BackColor = Color.WhiteSmoke;
                txtRazonCliente.BackColor = Color.WhiteSmoke;
            }
            txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
            txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;
        }

        void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Cli)
            {
                ClienteE oCliente = new ClienteE()
                {
                    idPersona = oListaPersonasTmp[0].IdPersona,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    SiglaComercial = oListaPersonasTmp[0].RazonSocial,
                    TipoCliente = 0,
                    fecInscripcion = (Nullable<DateTime>)null,
                    fecInicioEmpresa = (Nullable<DateTime>)null,
                    tipConstitucion = 0,
                    tipRegimen = 0,
                    catCliente = 0,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                };

                AgenteMaestro.Proxy.InsertarCliente(oCliente);
            }
        }

        #endregion

        #region Exportar Excel

        public override void Exportar()
        {
            try
            {
                if (oListaRegistrosVentaDetallada == null || oListaRegistrosVentaDetallada.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro De Ventas Detallada Por OT", "Archivos Excel (*.xlsx)|*.xlsx");

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
            DateTime Ini = Convert.ToDateTime(dtpInicio.Value);
            DateTime Fin = Convert.ToDateTime(dtpFin.Value);

            TituloGeneral = "REPORTE DE VENTAS DETALLADO POR OT";
            NombrePestaña = "REPORTE DETALLADO POR OT" ;

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 16;

                    #region Titulos Principales

                    // Creando Encabezado
                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 18, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(58, 58, 56));
                    }

                    oHoja.Cells["A2"].Value = "DEL " + Ini.ToString("d") + " AL " + Fin.ToString("d");

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(117, 113, 113));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "AÑO FACT.";
                    oHoja.Cells[InicioLinea, 2].Value = "ESTADO";
                    oHoja.Cells[InicioLinea, 3].Value = "TIP.DOC";
                    oHoja.Cells[InicioLinea, 4].Value = "N° DOC.";
                    oHoja.Cells[InicioLinea, 5].Value = "FEC. VENTA";
                    oHoja.Cells[InicioLinea, 6].Value = "GUIA REMISION";
                    oHoja.Cells[InicioLinea, 7].Value = "OT";                    
                    oHoja.Cells[InicioLinea, 8].Value = "OT ITEM";
                    oHoja.Cells[InicioLinea, 9].Value = "OC";
                    oHoja.Cells[InicioLinea, 10].Value = "CLIENTE FACTURADO";
                    oHoja.Cells[InicioLinea, 11].Value = "RUC" ;
                    oHoja.Cells[InicioLinea, 12].Value = "DESCRIPCION DEL PRODUCTO X ITEM";
                    oHoja.Cells[InicioLinea, 13].Value = "CANTIDAD";
                    oHoja.Cells[InicioLinea, 14].Value = "TOTAL (INC.)";
                    oHoja.Cells[InicioLinea, 15].Value = "TOTAL (INC.)";
                    oHoja.Cells[InicioLinea, 16].Value = "T.C.";
                    //oHoja.Cells[InicioLinea, 17].Value = "MON.";

                    for (int i = 1; i <= 16; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(208, 206, 206));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Detallado
                    Decimal tot1 = 0;
                    Decimal tot2 = 0;
                    foreach (EmisionDocumentoE item in oListaRegistrosVentaDetallada)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.Anio;
                        oHoja.Cells[InicioLinea, 2].Value = item.Mov;
                        oHoja.Cells[InicioLinea, 3].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 4].Value = item.numSerie + " - " + item.numDocumento;
                        oHoja.Cells[InicioLinea, 5].Value = item.fecEmision;
                        oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[InicioLinea, 6].Value = item.Guia;
                        oHoja.Cells[InicioLinea, 7].Value = item.nroOt;
                        oHoja.Cells[InicioLinea, 8].Value = item.nroOtItem;
                        oHoja.Cells[InicioLinea, 9].Value = item.Glosa;
                        oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 11].Value = item.Ruc;
                        oHoja.Cells[InicioLinea, 12].Value = item.nomArticulo;
                        oHoja.Cells[InicioLinea, 13].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 14].Value = item.Soles;

                        oHoja.Cells[InicioLinea, 15].Value = item.Dolares;
                        oHoja.Cells[InicioLinea, 16].Value = item.tipCambio;
                        //oHoja.Cells[InicioLinea, 17].Value = item.desMoneda;
                        tot1 += item.Soles;
                        tot2 += item.Dolares;


                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.000";
                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 13].Value = "TOTALES";
                    oHoja.Cells[InicioLinea, 14].Value = tot1;
                    oHoja.Cells[InicioLinea, 15].Value = tot2;
                    oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
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

        #region Eventos

        private void frmReporteRegistroVentasDetalladaOT_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            CambioCliente();
            CambioVendedor();

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

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void txtNroDocumentoVen_TextChanged(object sender, EventArgs e)
        {
            txtIdVendedor.Text = String.Empty;
            txtNombresVendedor.Text = String.Empty;
        }

        private void chbClientes_CheckedChanged(object sender, EventArgs e)
        {
            CambioCliente();
        }

        private void chkVendedores_CheckedChanged(object sender, EventArgs e)
        {
            CambioVendedor();
        }

        private void txtNombresVendedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()) && String.IsNullOrEmpty(txtNroDocumentoVen.Text.Trim()))
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtNombresVendedor.Text.Trim(), "");

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Vendedor");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            txtIdVendedor.Text = oFrm.oPersona.IdPersona.ToString();

                            if (String.IsNullOrEmpty(oFrm.oPersona.RazonSocial.Trim()))
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.ApePaterno + " " + oFrm.oPersona.ApeMaterno + " " + oFrm.oPersona.Nombres;
                            }
                            else
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                            }
                        }
                        else
                        {
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtIdVendedor.Text = oListaPersonas[0].IdPersona.ToString();

                        if (String.IsNullOrEmpty(oListaPersonas[0].RazonSocial.Trim()))
                        {
                            txtNombresVendedor.Text = oListaPersonas[0].ApePaterno + " " + oListaPersonas[0].ApeMaterno + " " + oListaPersonas[0].Nombres;
                        }
                        else
                        {
                            txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                        }
                    }
                    else
                    {
                        Global.MensajeFault("El nombre ingresado no existe.");
                        txtIdVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Text = String.Empty;
                        txtNombresVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Focus();
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtNombresVendedor_TextChanged(object sender, EventArgs e)
        {
            txtIdVendedor.Text = String.Empty;
            txtNroDocumentoVen.Text = String.Empty;
        }

        private void txtNroDocumentoVen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNroDocumentoVen.Text.Trim()) && String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()))
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", txtNroDocumentoVen.Text.Trim());

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            txtIdVendedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtIdVendedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Nro. de Documento ingresado no existe");
                        txtIdVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Text = String.Empty;
                        txtNombresVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Focus();
                        return;
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonCliente_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = String.Empty;
            txtRucCLiente.Text = String.Empty;
        }

        private void txtRazonCliente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonCliente.Text.Trim()) && string.IsNullOrEmpty(txtIdCliente.Text.Trim()) && string.IsNullOrEmpty(txtRucCLiente.Text.Trim()))
                {
                    txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonCliente.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRucCLiente.Text = oFrm.oPersona.RUC;
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRucCLiente.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdCliente.Text = String.Empty;
                        txtIdCliente.Text = String.Empty;
                        txtRazonCliente.Text = String.Empty;
                        txtRazonCliente.Focus();
                    }

                    txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRucCLiente_TextChanged(object sender, EventArgs e)
        {
            txtRazonCliente.Text = String.Empty;
            txtIdCliente.Text = String.Empty;
        }

        private void txtRucCLiente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRucCLiente.Text.Trim()) && string.IsNullOrEmpty(txtIdCliente.Text.Trim()) && string.IsNullOrEmpty(txtRazonCliente.Text.Trim()))
                {
                    txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucCLiente.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucCLiente.Text = oFrm.oPersona.RUC;
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRucCLiente.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRucCLiente.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRucCLiente.Text = String.Empty;
                        txtRazonCliente.Text = String.Empty;
                        txtRucCLiente.Focus();
                        return;
                    }

                    txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;

                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        #endregion


    }
}

#region Inicio Pdf

class InicioVentaDetalladaOT : PdfPageEventHelper
{
    public String Periodo { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        #region Variables

        BaseColor colCabDetalle = BaseColor.LIGHT_GRAY;
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

        #endregion Variables

        TituloGeneral = "REPORTE DE VENTAS";
        SubTitulo = "DEL " + Periodo;

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

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f, "S2"));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow();
        
        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(16);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.06f, 0.1f, 0.05f, 0.1f, 0.08f, 0.12f, 0.08f, 0.05f, 0.35f, 0.4f, 0.1f, 0.4f, 0.09f, 0.09f, 0.09f, 0.06f });

        #region Primera Linea

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), 5, 1, "S16"));
        TablaCabDetalle.CompleteRow();
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("AÑO FACT.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ESTADO", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIPO DOC", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N° DOC.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FEC. VENTA", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("GUIA REMISION", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        /* TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PEDIDO", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1))*/
        ;
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OT", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OT ITEM", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OC", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CLIENTE FACTURADO", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1)); ;
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RUC", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1)); ;
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION DEL PRODUCTO X ITEM", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1)); ;
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANTIDAD", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL (INC.)", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL (INC.)", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MON.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VENDEDOR", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ZONA", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ZONA DE INFLUENCIA", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONDICION", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FEC.PAGO", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OP-BANCO", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

        TablaCabDetalle.CompleteRow();

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), 5, 1, "S16"));
        TablaCabDetalle.CompleteRow();

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

        #endregion
    }

}

#endregion