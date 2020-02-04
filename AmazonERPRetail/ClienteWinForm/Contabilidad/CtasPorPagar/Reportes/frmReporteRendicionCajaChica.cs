using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

#region Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;

#endregion

namespace ClienteWinForm.Contabilidad.CtasPorPagar.Reportes
{
    public partial class frmReporteRendicionCajaChica : FrmMantenimientoBase
    {

        public frmReporteRendicionCajaChica()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            BuscarImagen();
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        List<LiquidacionDetE> oListaLiquidaciones = null;
        String RutaGeneral = String.Empty;
        String RutaImagen = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();

        int tipoProceso = Variables.Cero; // 1 buscar; 0 exportar
        Int32 letra = 0;
        String TipoCaja = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void BuscarImagen()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void ConvertirApdf()
        {
            Document DocumentoPdf = new Document(PageSize.A4.Rotate(), 15f, 15f, 15f, 15f);

            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Rendicion " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Tesoreria");
            DocumentoPdf.AddSubject("Liquidaciones");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    if (cboTipo.SelectedIndex != -1)
                    {
                        if (cboTipo.SelectedIndex == 0)
                        {
                            TituloGeneral = " RENDICION DE CAJA CHICA ";
                        }
                        else if (cboTipo.SelectedIndex == 1)
                        {
                            TituloGeneral = " RENDICION DE CTAS. A RENDIR ";
                        }
                        else if (cboTipo.SelectedIndex == 2)
                        {
                            TituloGeneral = " RENDICION DE VIATICOS ";
                        } 
                    }
                    else
                    {
                        TituloGeneral = string.Empty;
                    }

                    BaseColor ColorFondo = BaseColor.LIGHT_GRAY; //Gris Claro
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfPTable tableEncabezado = new PdfPTable(2);
                    tableEncabezado.WidthPercentage = 100;
                    tableEncabezado.SetWidths(new float[] { 0.9f, 0.13f });

                    #region Encabezado

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    //Filas en blanco
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f), -1, -1, "S4"));
                    tableEncabezado.CompleteRow();

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(2);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.03f, 0.2f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f));
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral.PadLeft(82, ' '), null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, -1, "N", "N", 13f, 13f));
                    tableTitulos.CompleteRow();

                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("De " + dtpFecIni.Value.ToString("d") + " al " + dtpFecFin.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S2"));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2", "N", 2f, 2f, "N", "S", "N", "N"));
                    tableTitulos.CompleteRow();

                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable TablaDeta = new PdfPTable(10);
                    TablaDeta.WidthPercentage = 100;
                    TablaDeta.SetWidths(new float[] { 0.025f, 0.05f, 0.03f, 0.07f, 0.05f, 0.25f, 0.21f, 0.19f, 0.06f, 0.06f });

                    #region Subtitulos

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Periodo: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("De " + dtpFecIni.Value.ToString("d") + " al " + dtpFecFin.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 0, "S8"));

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S10"));
                    TablaDeta.CompleteRow();

                    #endregion

                    #region Detalle

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Nro.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Fecha", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Tipo", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Nro. Dcto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Compra/Gasto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Razón Social", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Concepto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Importe $", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Importe S/.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.CompleteRow();

                    Int32 ItemCorre = 1;
                    Decimal totGeneralSoles = 0;
                    Decimal totGeneralDolares = 0;
                    Int32 idLiquidacion = 0;

                    foreach (LiquidacionDetE item in oListaLiquidaciones)
                    {
                        if (item.RazonSocial != "X")
                        {
                            if (idLiquidacion != item.idLiquidacion)
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda("Id. " + ' ' + item.idLiquidacion.ToString() + "   Fec.Ope. " + item.Fecha.ToString("d") + "   Auxiliar " + item.desAuxiliar + "   Estado " + item.desEstado + "   Voucher " + item.Voucher, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, -1, "S10", "N", 4f, 4f));
                                TablaDeta.CompleteRow();
                            }

                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(ItemCorre.ToString("00"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.Value.ToString("dd/MM/yyyy"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));

                            if (String.IsNullOrWhiteSpace(item.numSerie) && String.IsNullOrWhiteSpace(item.numDocumento))
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            }

                            if (!String.IsNullOrWhiteSpace(item.numSerie) && String.IsNullOrWhiteSpace(item.numDocumento))
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numSerie, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            }

                            if (String.IsNullOrWhiteSpace(item.numSerie) && !String.IsNullOrWhiteSpace(item.numDocumento))
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            }

                            if (!String.IsNullOrWhiteSpace(item.numSerie) && !String.IsNullOrWhiteSpace(item.numDocumento))
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numSerie + "-" + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            }

                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.TipoLiqui, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Concepto, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Descripcion, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TablaDeta.CompleteRow();
                        }
                        else
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("Total Liquidación  ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.GREEN), 5, 2, "S8"));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.GREEN), 5, 2));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.GREEN), 5, 2));
                            TablaDeta.CompleteRow();
                        }
                        

                        ItemCorre++;
                        idLiquidacion = item.idLiquidacion;
                    }

                    //Ultima Fila
                    LiquidacionDetE UltimaFila = oListaLiquidaciones[oListaLiquidaciones.Count - 1];
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Total Liquidación  ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.GREEN), 5, 2, "S8"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(UltimaFila.impDolares.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.GREEN), 5, 2));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(UltimaFila.impSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.GREEN), 5, 2));
                    TablaDeta.CompleteRow();

                    //Fila Total General
                    //Linea en blanco
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S10", "N", 2f, 2f, "N", "S", "N", "N"));
                    TablaDeta.CompleteRow();

                    totGeneralSoles = oListaLiquidaciones.Where(w => w.RazonSocial != "X").Sum(x => x.impSoles);
                    totGeneralDolares = oListaLiquidaciones.Where(w => w.RazonSocial != "X").Sum(x => x.impDolares);

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Total General  ", null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD, BaseColor.BLUE), 5, 2, "S8"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(totGeneralDolares.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD, BaseColor.BLUE), 5, 2));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(totGeneralSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD, BaseColor.BLUE), 5, 2));
                    TablaDeta.CompleteRow();

                    //Linea en blanco
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S10", "N", 2f, 2f, "N", "S", "N", "N"));
                    TablaDeta.CompleteRow();

                    DocumentoPdf.Add(TablaDeta); //Añadiendo la tabla al documento PDF

                    #endregion

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //Establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    DocumentoPdf.Close();
                }
            }
        }

        void ExportarExcel(String Ruta)
        {
        }

        #endregion

        #region Procesos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaLiquidaciones.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string dia = VariablesLocales.FechaHoy.Date.Day.ToString("00");
                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Compras (" + dia + "-" + mes + "-" + anio + ")", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = Variables.Cero;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Importando los Registro de Compras a Excel...";
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
                DateTime fecInicial = dtpFecIni.Value.Date;
                DateTime fecFin = dtpFecFin.Value.Date;

                if (tipoProceso == 1)
                {
                    //Obteniendo los datos de la BD
                    lblProcesando.Text = "Obteniendo las Rendiciones...";
                    oListaLiquidaciones = AgenteCtasPorPagar.Proxy.LiquidacionRendicionCaja(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, fecInicial, fecFin, TipoCaja);

                    lblProcesando.Text = "Armando el Reporte de Rendición de Caja Chica...";
                    ConvertirApdf();//Generando el PDF
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

            pnlParametros.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (tipoProceso == 1)
            {
                //Mostrando el reporte en un web browser
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                    tipoProceso = 0;
                }
            }
            else
            {
                Global.MensajeComunicacion("Exportación Exitosa.");
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmReporteRendicionCajaChica_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            //Habilitando los eventos para trabajar en segundo plano...
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

            cboTipo.SelectedIndex = 0;
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                letra += 1;

                if (letra == Marque.Length)
                {
                    lblProcesando.Text = String.Empty;
                    letra = 0;
                }
                else
                {
                    lblProcesando.Text += Marque.Substring(letra - 1, 1);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipoProceso = 1; //Reporte en Pdf
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                btExcel.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                btExcel.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaLiquidaciones == null)
                {
                    Global.MensajeFault("No hay Registros para exportar a Excel.");
                    return;
                }
                if (oListaLiquidaciones.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Compras Alineado Por File " + mes + "-" + anio, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = 1;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Importando el Registro de Movilidades a Excel...";
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

        private void cboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex != -1)
            {
                if (cboTipo.SelectedIndex == 0)
                {
                    TipoCaja = string.Empty; //Caja Chica
                }
                else if (cboTipo.SelectedIndex == 0)
                {
                    TipoCaja = "C"; //Cuenta a rendir
                }
                else
                {
                    TipoCaja = "V"; //Viáticos
                } 
            }
        }

        #endregion

    }
}
