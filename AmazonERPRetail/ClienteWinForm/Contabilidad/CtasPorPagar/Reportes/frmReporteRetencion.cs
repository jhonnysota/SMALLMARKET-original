using ClienteWinForm;
using Entidades.CtasPorPagar;
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

namespace ClienteWinForm.Contabilidad.CtasPorPagar.Reportes
{
    public partial class frmReporteRetencion : FrmMantenimientoBase
    {
        public frmReporteRetencion()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        List<RetencionE> oReporteRET = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Marque = String.Empty;
        string tipo = "buscar";
        String TipoPDF = String.Empty;

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

            if (listaLocales.Count == 2)
            {
                cboSucursales.SelectedValue = 1;
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\Retencion";
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

                PaginaInicioRetenciones ev = new PaginaInicioRetenciones();
                ev.TipoPDF = "DETALLADO";
                ev.Fecha = dtpFecha.Value;
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle
                if (TipoPDF == "DETALLADO")
                {                  
                 PdfPTable TablaCabDetalle = new PdfPTable(15);
                 TablaCabDetalle.WidthPercentage = 100;
                 TablaCabDetalle.SetWidths(new float[] { 0.0041f, 0.0084f, 0.0275f, 0.01f, 0.0116f, 0.0116f, 0.0116f, 0.0125f, 0.0125f, 0.02f, 0.01f, 0.005f,0.006f, 0.01f, 0.01f });

                 Decimal subtotal = 0;
                 String Numerocompreteant = String.Empty;
                 String Numerocompretenew = String.Empty;
                 String SerieNew = String.Empty;
                 String NumeroNew = String.Empty;
                 DateTime FechaNew = VariablesLocales.FechaHoy;
                 decimal Retenido = 0;
                 decimal Base = 0;
                 decimal total1 = 0;
                 decimal total2 = 0;
                 int UltimaLinea = oReporteRET.Count();

                    foreach (RetencionE item in oReporteRET)
                    {
                        #region Solo la Primera vez Inicializa
                        if (Numerocompretenew == String.Empty)
                        {
                            Numerocompretenew = item.numeroCompRete;
                        }
                        #endregion Fin Inicializacion

                        #region Pie de Retencion
                        if (item.numeroCompRete != Numerocompretenew)
                        {
                            Numerocompretenew = item.numeroCompRete;
                            subtotal = 0;

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(FechaNew.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(SerieNew, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(NumeroNew, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(Retenido.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(Base.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            total1 += Retenido;
                            total2 += Base;

                            TablaCabDetalle.CompleteRow();
                        }
                        #endregion Pie de Retencion

                        #region Detalle de Retencion
                        subtotal = subtotal + (item.Haber - item.Debe);

                        SerieNew = item.serieCompRete;
                        NumeroNew= item.numeroCompRete;
                        FechaNew = item.Fecha;
                        Retenido = item.MontoRetenido;
                        Base     = item.MontoBase;

                        cell = new PdfPCell(new Paragraph(item.td_proveedor, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.ruc, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.razonsocial, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.FecDocumento.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.CodigoSunat, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.serDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.numDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Debe.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Haber.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(subtotal.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        #endregion Detalle de Retencion
                    }

                    #region Pie de Retencion
                    if (UltimaLinea > 0)
                    {
                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(FechaNew.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(SerieNew, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(NumeroNew, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Retenido.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Base.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        total1 += Retenido;
                        total2 += Base;

                        TablaCabDetalle.CompleteRow();
                    }
                    #endregion Pie de Retencion

                    #region Totales

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                         cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);


                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(total1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(total2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion Totales

                }
                #endregion Detalle


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

        void ConvertirAPle()
        {
            try
            {
                #region Validaciones

                if (oReporteRET.Count == Variables.Cero || oReporteRET == null)
                {
                    Global.MensajeFault("No hay datos para exportar al Libro Retencion.");
                    return;
                }

                if (Global.MensajeConfirmacion("Desea generar el Archivo del Libro Retenciones para el PLE") == DialogResult.No)
                {
                    return;
                }

                #endregion Validaciones

                String RutaArchivoTexto = String.Empty;

                if (dtpFecha.Value.Month < 10)
                {
                    String NombreArchivo = "0626" + VariablesLocales.SesionUsuario.Empresa.RUC + dtpFecha.Value.Year + "0" + dtpFecha.Value.Month;
                    // "0626RRRRRRRRRRRAAAAMM";
                    RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");
                }

                if (dtpFecha.Value.Month >= 10)
                {
                    String NombreArchivo = "0626" + VariablesLocales.SesionUsuario.Empresa.RUC + dtpFecha.Value.Year + dtpFecha.Value.Month;
                    // "0626RRRRRRRRRRRAAAAMM";
                    RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");
                }

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    #region Exportacion a un archivo de texto

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        StringBuilder Cadena = new StringBuilder();

                        foreach (RetencionE item in oReporteRET)
                        {
                                Cadena.Append(item.Linea);
                                oSw.WriteLine(Cadena.ToString());
                                Cadena.Clear();
                        }

                        RutaArchivoTexto = String.Empty;
                    }

                    #endregion

                    Global.MensajeComunicacion("Se generó el archivo correctamente.");
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

            TituloGeneral = " Registro de Regimen de Retenciones ";
            NombrePestaña = " mes" + dtpFecha.Value.Month + " Año " + dtpFecha.Value.Year;

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 15;

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

                    #region Cabeceras del Detalle

                    // PRIMERA

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 3])//
                    {
                        Rango.Merge = true;
                        Rango.Value = " INFORMACION DEL PROVEEDOR ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    oHoja.Cells[InicioLinea, 4].Value = " FECHA TRANSACCION ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea,7])//
                    {
                        Rango.Merge = true;
                        Rango.Value = " COMPROBANTE DE PAGO O DOCUMENTO SUSTENTATORIO ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, InicioLinea, 9])//
                    {
                        Rango.Merge = true;
                        Rango.Value = " IMPORTE DE TRANSACCION ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    oHoja.Cells[InicioLinea, 10].Value = " ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 11, InicioLinea, 15])//
                    {
                        Rango.Merge = true;
                        Rango.Value = " RETENCION ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    oHoja.Row(InicioLinea).Height = 30;

                    for (int i = 1; i <= 15; i++)
                    {

                            oHoja.Cells[InicioLinea , i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea , i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea , i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea , i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea , i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
              

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    // SEGUNDA LINEA
      
                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 2])//
                    {
                        Rango.Merge = true;
                        Rango.Value = "  Doc. Identidad ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }


                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea,4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = " ";
                    oHoja.Cells[InicioLinea, 7].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = " ";
                    oHoja.Cells[InicioLinea, 9].Value = " ";
                    oHoja.Cells[InicioLinea, 10].Value = " ";
                    oHoja.Cells[InicioLinea, 12].Value = " ";
                    oHoja.Cells[InicioLinea, 13].Value = " ";
                    oHoja.Cells[InicioLinea, 14].Value = " ";
                    oHoja.Cells[InicioLinea, 15].Value = " ";

                    for (int i = 1; i <= 15; i++)
                    {

                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    oHoja.Cells[InicioLinea, 3, InicioLinea, 14].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    // TERCERA LINEA
                    oHoja.Cells[InicioLinea, 1].Value = " Tipo";
                    oHoja.Cells[InicioLinea, 2].Value = " Numero";
                    oHoja.Cells[InicioLinea, 3].Value = " Apellidos y nombres o razon social";
                    oHoja.Cells[InicioLinea, 4].Value = " Fecha ";
                    oHoja.Cells[InicioLinea, 5].Value = " Tipo ";
                    oHoja.Cells[InicioLinea, 6].Value = " Serie ";
                    oHoja.Cells[InicioLinea, 7].Value = " Nro ";
                    oHoja.Cells[InicioLinea, 8].Value = " Debe ";
                    oHoja.Cells[InicioLinea, 9].Value = " Haber ";
                    oHoja.Cells[InicioLinea, 10].Value = " Saldo ";
                    oHoja.Cells[InicioLinea, 11].Value = " Fecha ";
                    oHoja.Cells[InicioLinea, 12].Value = " Serie ";
                    oHoja.Cells[InicioLinea, 13].Value = " Nro Comprobante ";
                    oHoja.Cells[InicioLinea, 14].Value = " Importe Retenido ";
                    oHoja.Cells[InicioLinea, 15].Value = " Total Pagado ";

                    for (int i = 1; i <= 15; i++)
                    {

                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
                    oHoja.Cells[InicioLinea, 1, InicioLinea, 15].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Variables

                    Decimal subtotal = 0;
                    String Numerocompreteant = String.Empty;
                    String Numerocompretenew = String.Empty;
                    String SerieNew = String.Empty;
                    String NumeroNew = String.Empty;
                    DateTime FechaNew = VariablesLocales.FechaHoy;
                    decimal Retenido = 0;
                    decimal Base = 0;
                    decimal total1 = 0;
                    decimal total2 = 0;
                    int UltimaLinea = oReporteRET.Count();

                    #endregion

                    foreach (RetencionE item in oReporteRET)
                    {
                        #region Solo la Primera vez Inicializa
                        if (Numerocompretenew == String.Empty)
                        {
                            Numerocompretenew = item.numeroCompRete;
                        }
                        #endregion

                        #region pie de retencion


                        if (item.numeroCompRete != Numerocompretenew)
                        {
                            Numerocompretenew = item.numeroCompRete;
                            subtotal = 0;
                            oHoja.Cells[InicioLinea, 1].Value = "";

                            oHoja.Cells[InicioLinea, 2].Value = "";

                            oHoja.Cells[InicioLinea, 3].Value = "";

                            oHoja.Cells[InicioLinea, 4].Value = "";

                            oHoja.Cells[InicioLinea, 5].Value = "";

                            oHoja.Cells[InicioLinea, 6].Value = "";

                            oHoja.Cells[InicioLinea, 7].Value = "";

                            oHoja.Cells[InicioLinea, 8].Value = "";

                            oHoja.Cells[InicioLinea, 9].Value = "";

                            oHoja.Cells[InicioLinea, 10].Value = "";

                            oHoja.Cells[InicioLinea, 11].Value = FechaNew.ToString("dd/MM/yyyy");


                            oHoja.Cells[InicioLinea, 12].Value = SerieNew;

                            oHoja.Cells[InicioLinea, 13].Value = NumeroNew;

                            oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(Retenido.ToString("N2"));

                            oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(Base.ToString("N2"));

                            oHoja.Cells[InicioLinea, 14, InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                            total1 += Retenido;
                            total2 += Base;

                            InicioLinea++;
                        }
                            #endregion

                        #region Detalle de Retencion
                            subtotal = subtotal + (item.Haber - item.Debe);

                            SerieNew = item.serieCompRete;
                            NumeroNew = item.numeroCompRete;
                            FechaNew = item.Fecha;
                            Retenido = item.MontoRetenido;
                            Base = item.MontoBase;

                            oHoja.Cells[InicioLinea, 1].Value = item.td_proveedor;

                            oHoja.Cells[InicioLinea, 2].Value = item.ruc;

                            oHoja.Cells[InicioLinea, 3].Value = item.razonsocial;

                            oHoja.Cells[InicioLinea, 4].Value = item.FecDocumento.ToString("d");

                            oHoja.Cells[InicioLinea, 5].Value = item.CodigoSunat;

                            oHoja.Cells[InicioLinea, 6].Value = item.serDocumento;

                            oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;

                            oHoja.Cells[InicioLinea, 8].Value = Convert.ToDecimal(item.Debe.ToString("N2"));


                            oHoja.Cells[InicioLinea, 9].Value = Convert.ToDecimal(item.Haber.ToString("N2"));

                            oHoja.Cells[InicioLinea, 10].Value = Convert.ToDecimal(subtotal.ToString("N2"));

                        oHoja.Cells[InicioLinea, 8, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;




                            #endregion
                    }

                    #region Pie de Retencion
                    if (UltimaLinea > 0)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = "";

                        oHoja.Cells[InicioLinea, 2].Value = "";

                        oHoja.Cells[InicioLinea, 3, InicioLinea, 4].Value = "";

                        oHoja.Cells[InicioLinea, 5].Value = "";

                        oHoja.Cells[InicioLinea, 6].Value = "";

                        oHoja.Cells[InicioLinea, 7].Value = "";

                        oHoja.Cells[InicioLinea, 8].Value = "";

                        oHoja.Cells[InicioLinea, 9].Value = "";


                        oHoja.Cells[InicioLinea, 10].Value = "";

                        //datos

                        oHoja.Cells[InicioLinea, 11].Value = FechaNew.ToString("dd/MM/yyyy");


                        oHoja.Cells[InicioLinea, 12].Value = SerieNew;

                        oHoja.Cells[InicioLinea, 13].Value = NumeroNew;

                        oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(Retenido.ToString("N2"));

                        oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(Base.ToString("N2"));

                        oHoja.Cells[InicioLinea, 14, InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";

                        total1 += Retenido;
                        total2 += Base;

                        InicioLinea++;


                    }

                    #endregion


                    oHoja.Cells[InicioLinea, 1].Value = "";

                    oHoja.Cells[InicioLinea, 2].Value = "";

                    oHoja.Cells[InicioLinea, 3, InicioLinea, 4].Value = "";

                    oHoja.Cells[InicioLinea, 5].Value = "";

                    oHoja.Cells[InicioLinea, 6].Value = "";

                    oHoja.Cells[InicioLinea, 7].Value = "";

                    oHoja.Cells[InicioLinea, 8].Value = "";

                    oHoja.Cells[InicioLinea, 9].Value = "";


                    oHoja.Cells[InicioLinea, 10].Value = "";

                    oHoja.Cells[InicioLinea, 11].Value = "";


                    oHoja.Cells[InicioLinea, 12].Value = "";

                    oHoja.Cells[InicioLinea, 13].Value = "";

                    oHoja.Cells[InicioLinea, 14].Value = "-----------------------";

                    oHoja.Cells[InicioLinea, 15].Value = "-----------------------";

                    InicioLinea++;


                    oHoja.Cells[InicioLinea, 1].Value = "";

                    oHoja.Cells[InicioLinea, 2].Value = "";

                    oHoja.Cells[InicioLinea, 3, InicioLinea, 4].Value = "";

                    oHoja.Cells[InicioLinea, 5].Value = "";

                    oHoja.Cells[InicioLinea, 6].Value = "";

                    oHoja.Cells[InicioLinea, 7].Value = "";

                    oHoja.Cells[InicioLinea, 8].Value = "";

                    oHoja.Cells[InicioLinea, 9].Value = "";


                    oHoja.Cells[InicioLinea, 10].Value = "";

                    oHoja.Cells[InicioLinea, 11].Value = "";


                    oHoja.Cells[InicioLinea, 12].Value = "";

                    oHoja.Cells[InicioLinea, 13].Value = "";

                    oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(total1.ToString("N2"));

                    oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(total2.ToString("N2"));
                    oHoja.Cells[InicioLinea, 14, InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;

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

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oReporteRET == null || oReporteRET.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = cboSucursales.Text;
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + cboSucursales.Text;


                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Retenciones libros" + NombreLocal + "-" , "Archivos Excel (*.xlsx)|*.xlsx");

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
                    lblProcesando.Text = "Obteniendo el Reporte Libros Retenciones...";
                    oReporteRET = AgenteCtasPorPagar.Proxy.LibroRetenciones(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpFecha.Value.Date, dtpFin.Value.Date);
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
                if (TipoPDF == "DETALLADO")
                {
                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                    }
                }
            }
            else
            {
                Global.MensajeComunicacion("Libros Retencione Exportado...");
            }
        }

        #endregion

        private void frmReporteRetencion_Load(object sender, EventArgs e)
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

        private void frmReporteRetencion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                tipo = "buscar";
                if (rboDetallado.Checked == true)
                {
                    TipoPDF = "DETALLADO";
                }
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






        #region Pdf Inicio


        public class PaginaInicioRetenciones : PdfPageEventHelper
        {
            public String TipoPDF { get; set; }
            public DateTime Fecha { get; set;  }

            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);


                string NOMBREMES = string.Empty;
                String TituloGeneral = String.Empty;
                String SubTitulo = String.Empty;
                String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
                String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
                PdfPCell cell = null;


                if (Fecha.Month == 0)
                {
                    NOMBREMES = "APERTURA";
                }

                if (Fecha.Month == 1)
                {
                    NOMBREMES = "ENERO";
                }
                if (Fecha.Month == 2)
                {
                    NOMBREMES = "FEBRERO";
                }
                if (Fecha.Month == 3)
                {
                    NOMBREMES = "MARZO";
                }
                if (Fecha.Month == 4)
                {
                    NOMBREMES = "ABRIL";
                }
                if (Fecha.Month == 5)
                {
                    NOMBREMES = "MAYO";
                }
                if (Fecha.Month == 6)
                {
                    NOMBREMES = "JUNIO";
                }
                if (Fecha.Month == 7)
                {
                    NOMBREMES = "JULIO";
                }
                if (Fecha.Month == 8)
                {
                    NOMBREMES = "AGOSTO";
                }
                if (Fecha.Month == 9)
                {
                    NOMBREMES = "SETIEMBRE";
                }
                if (Fecha.Month == 10)
                {
                    NOMBREMES = "OCTUBRE";
                }
                if (Fecha.Month == 11)
                {
                    NOMBREMES = "NOVIEMBRE";
                }
                if (Fecha.Month == 12)
                {
                    NOMBREMES = "DICIEMBRE";
                }
                if (Fecha.Month == 13)
                {
                    NOMBREMES = "CIERRE";

                }

                    TituloGeneral = "REGISTRO DEL RÉGIMEN DE RETENCIONES";
                SubTitulo = "MES " + NOMBREMES + "  AÑO " + Fecha.Year;

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

                if (TipoPDF == "DETALLADO")
                {
                    #region Cabecera del Detalle

                    PdfPTable TablaCabDetalle = new PdfPTable(14);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.0041f,0.0084f, 0.0275f, 0.01f, 0.0116f, 0.0116f, 0.0116f, 0.0125f, 0.0125f, 0.02f, 0.01f, 0.01f, 0.01f, 0.01f });

                    #region Primera Linea

                    cell = new PdfPCell(new Paragraph("Informacion del Proveedor", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 3;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Fecha Transaccion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Comprobante de Pago o Documento Sustentatorio", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 3;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Importe de Transaccion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 2;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Saldo Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Retencion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 3;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Total Pagado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    #endregion

                    #region Segunda Linea

                    cell = new PdfPCell(new Paragraph("Doc.Identidad", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan =2;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Apellidos y Nombres o Razon Social", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Tipo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Serie", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Nro.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Debe", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Haber", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Fecha", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Nro. Comprobante", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Importe Retenido", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    #endregion


                    #region Tercer Linea

                    cell = new PdfPCell(new Paragraph("Tipo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Numero", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                    cell.Colspan = 1;
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    #endregion


                    document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion
                }
            }
        }

        #endregion

        private void btPle_Click(object sender, EventArgs e)
        {
            oReporteRET = AgenteCtasPorPagar.Proxy.LibroRetencionLe(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpFecha.Value.Date, dtpFin.Value.Date);
            lblProcesando.Text = "Armando el PLE...";
            ConvertirAPle();
        }
    }




}



