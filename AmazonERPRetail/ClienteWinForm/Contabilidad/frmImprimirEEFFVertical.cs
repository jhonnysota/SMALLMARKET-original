using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using ClienteWinForm;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImprimirEEFFVertical : Form
    {

        public frmImprimirEEFFVertical()
        {
            InitializeComponent();
            ImagenRuta();
        }

        public frmImprimirEEFFVertical(List<EEFFRatiosE> oLista_)
          :this()
        {
            oListaRatios = oLista_;
        }

        public frmImprimirEEFFVertical(List<ReporteEEFFItemE> oLista,String Anio)
          :this()
        {
            oListaEEFF = oLista;
            Anio_ = Anio;
            oListaRatios = AgenteContabilidad.Proxy.ListarEEFFRatios(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        String RutaGeneral;
        List<EEFFRatiosE> oListaRatios;
        List<ReporteEEFFItemE> oListaEEFF = null;
        public String RutaImagen = String.Empty;
        String Anio_ = "";

        void ImagenRuta()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void CrearReporte()
        {
            if (oListaRatios != null && oListaRatios.Count > 0)
            {
                Global.QuitarReferenciaWebBrowser(wbNavegador);

                Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                String NombreReporte = @"\" + "_" + VariablesLocales.FechaHoy.Year.ToString() + "_" + VariablesLocales.FechaHoy.Month.ToString() + "_" + VariablesLocales.FechaHoy.Day.ToString() + "_" + VariablesLocales.FechaHoy.Hour.ToString() + "_" + VariablesLocales.FechaHoy.Minute.ToString();
                String Extension = ".pdf";
                RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";
                BaseColor ColorFondo = new BaseColor(229, 112, 59);
                BaseColor ColorLetra = new BaseColor(255, 255, 255);

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
                    //String SubTitulo = String.Empty;
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

                    int Columnas = 4;

                    float[] ArrayColumnas = new float[] { 0.15f, 0.47f, 0.1f, 0.1f };

                    int WidthPercentage = 100;

                    String AnioAnterior = Convert.ToString(Convert.ToInt32(Anio_) - 1);

                    PaginaEEFFVertical ev = new PaginaEEFFVertical();

                    ev.Periodo = Anio_;

                    //ev.Columnas = Columnas;
                    //ev.ArrayColumnas = ArrayColumnas;
                    //ev.WidthPercentage = WidthPercentage;
                    //ev.RutaImagen = RutaImagen;

                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Formatos

                    PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                    TablaCabDetalle.WidthPercentage = WidthPercentage;
                    TablaCabDetalle.SetWidths(ArrayColumnas);

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    cell.Colspan = Columnas;
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

                    String NumeroTablaEspacio = "";
                   
                    for (int i = 0; i < oListaEEFF.Count; i++)
                    {

                        if (oListaEEFF[i].TipoTabla == "TIT" && oListaEEFF[i].desItem == "ACTIVO")
                        {
                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("BALANCE GENERAL", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(AnioAnterior, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(Anio_, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                        }

                        if (oListaEEFF[i].TipoTabla == "DET" && oListaEEFF[i].desItem == "VENTAS")
                        {
                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("ESTADO DE GANANCIA Y PERDIDAS", FontFactory.GetFont("Arial", 9f,iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(AnioAnterior, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(Anio_, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                        }


                        NumeroTablaEspacio = oListaEEFF[i].TipoTabla;

                        if (NumeroTablaEspacio == "TIT")
                        {
                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = Columnas;
                            TablaCabDetalle.AddCell(cell);
                            TablaCabDetalle.CompleteRow();
                        }

                        if (oListaEEFF[i].TipoTabla == "TIT" || oListaEEFF[i].TipoTabla == "TOT")
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFF[i].desItem.ToString(), ColorFondo, "S", ColorLetra, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, -1));

                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);
                        }
                        else
                        {
                            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaEEFF[i].desItem.ToString(), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);
                        }
               
                        cell = new PdfPCell(new Paragraph(oListaEEFF[i].Analisis1V, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(oListaEEFF[i].Analisis2V, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }

                    docPdf.Add(TablaCabDetalle);

                    #endregion

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                    fsNuevoArchivo.Close();


                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                    }
                }
            }
        }

        private void frmImprimirEEFFVertical_Load(object sender, EventArgs e)
        {
            try
            {
                //Ubicacion del Reporte
                Location = new Point(0, 0);
                Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
                CrearReporte();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
    }
}

#region Inicio Pdf

//class PaginaEEFFRatios : PdfPageEventHelper
//{
//    public int Columnas { get; set; }
//    public float[] ArrayColumnas { get; set; }
//    public String[] ArrayTitulos { get; set; }
//    public int WidthPercentage { get; set; }
//    public String RutaImagen { get; set; }


//    public override void OnStartPage(PdfWriter writer, Document document)
//    {
//        base.OnStartPage(writer, document);

//        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
//        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
//        PdfPCell cell = null;
//        String TituloGeneral = String.Empty;
//        String SubTitulo = String.Empty;
//        #region Cabecera del Detalle

//        if (Columnas > 0)
//        {

//            PdfPTable table2 = new PdfPTable(2);

//            table2.WidthPercentage = 100;
//            table2.SetWidths(new float[] { 0.25f, 0.75f });
//            table2.HorizontalAlignment = Element.ALIGN_LEFT;

//            if (!String.IsNullOrEmpty(RutaImagen))
//            {
//                table2.AddCell(ReaderHelper.ImagenCell(RutaImagen, 100, 5, Variables.SI, 1));
//                table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f), 1, 1));
//            }
//            else
//            {
//                table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f), 1, 1));
//                table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f), 1, 1));
//            }

//            table2.CompleteRow(); //Fila Completa...
//            document.Add(table2);

//            TituloGeneral = " RATIOS ";

//            SubTitulo = "AÑO: " + "2017" ;

//            PdfPTable table = new PdfPTable(1);

//            table.WidthPercentage = 100;
//            table.SetWidths(new float[] { 0.9f });
//            table.HorizontalAlignment = Element.ALIGN_LEFT;

//            #region Titulos Principales

//            table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD), 5, 1));
//            table.CompleteRow(); //Fila completada

//            table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD), 1, 1));
//            table.CompleteRow(); //Fila completada
//            document.Add(table);

//            #endregion


//        }
//        #endregion

//    }

//}

class PaginaEEFFVertical : PdfPageEventHelper
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

        TituloGeneral = "           ANALISIS VERTICAL";
        SubTitulo     = "            Periodo: " + Periodo;

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

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 0.47f, 0.47f));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 0.47f, 0.47f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f, "S2"));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow();

        document.Add(table); //Añadiendo la tabla al documento PDF
    }

}

#endregion