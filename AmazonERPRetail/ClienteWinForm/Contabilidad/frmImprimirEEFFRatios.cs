using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using ClienteWinForm;

using iTextSharp.text;
using iTextSharp.text.pdf;

using org.mariuszgromada.math.mxparser;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImprimirEEFFRatios : Form
    {

        #region Constructores

        public frmImprimirEEFFRatios()
        {
            InitializeComponent();
            ImagenRuta();
        }

        public frmImprimirEEFFRatios(List<EEFFRatiosE> oLista_)
          :this()
        {
            oListaRatios = oLista_;
        }

        public frmImprimirEEFFRatios(List<ReporteEEFFItemE> oLista, String Anio)
          :this()
        {
            oListaEEFF = oLista;
            Anio_ = Anio;
            oListaRatios = AgenteContabilidad.Proxy.ListarEEFFRatios(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        String RutaGeneral;
        List<EEFFRatiosE> oListaRatios = null;
        List<ReporteEEFFItemE> oListaEEFF = null;
        public String RutaImagen = String.Empty;
        String Anio_ = "";

        #endregion

        #region Procedimientos de Usuario

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
                Guid Aleatorio = Guid.NewGuid();
                String NombreReporte = "Ratios " + Aleatorio.ToString();
                String Extension = ".pdf";
                RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";
                BaseColor ColorFondo = new BaseColor(47, 117, 181);
                BaseColor ColorFondo2 = new BaseColor(189, 215, 238);
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

                    int Columnas = 3;
                    float[] ArrayColumnas = new float[] { 0.15f, 0.47f, 0.1f };
                    int WidthPercentage = 100;

                    PaginaEEFFRatios ev = new PaginaEEFFRatios()
                    {
                        Periodo = Anio_
                    };

                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Formatos

                    PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                    TablaCabDetalle.WidthPercentage = WidthPercentage;
                    TablaCabDetalle.SetWidths(ArrayColumnas);

                    //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    //cell.Colspan = Columnas;
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                    TablaCabDetalle.CompleteRow();

                    String NumeroTablaEspacio = "";
                    //Decimal R1 = 0;
                    //Decimal R2 = 0;
                    //Decimal R3 = 0;
                    String Formula = String.Empty;

                    for (int i = 0; i < oListaRatios.Count; i++)
                    {
                        NumeroTablaEspacio = oListaRatios[i].TipoTabla;

                        if (NumeroTablaEspacio == "TIT")
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                            TablaCabDetalle.CompleteRow();
                        }

                        if (oListaRatios[i].TipoTabla == "TIT")
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaRatios[i].desItem, ColorFondo, "S", ColorFondo, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaRatios[i].desGlosa, null, "S", ColorFondo, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaRatios[i].desItem, ColorFondo2, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                            //cell = new PdfPCell(new Paragraph(oListaRatios[i].desItem.ToString(), FontFactory.GetFont("Arial", 7.25f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            //TablaCabDetalle.AddCell(cell);
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaRatios[i].desGlosa, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                            //cell = new PdfPCell(new Paragraph(oListaRatios[i].desGlosa.ToString(), FontFactory.GetFont("Arial", 7.25f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            //TablaCabDetalle.AddCell(cell);
                        }

                        if (!String.IsNullOrWhiteSpace(oListaRatios[i].Formula))
                        {
                            //ReporteEEFFItemE EEFFItem = null;
                            //Decimal Valor1 = 0;
                            //Decimal Valor2 = 0;
                            //Decimal Valor3 = 0;
                            //Decimal Valor4 = 0;
                            String Resultado = String.Empty;
                            Expression Calc = null;
                            double ImporteCalculado = 0;
                            String Importe = String.Empty;

                            Formula = FormulaExpresion(oListaRatios[i], oListaEEFF);

                            //Metiendo la fórmula, para obtener el cálculo...
                            if (!String.IsNullOrWhiteSpace(Formula))
                            {
                                if (Formula.Contains("%"))
                                {
                                    Importe = Formula;
                                }
                                else
                                {
                                    Calc = new Expression(Formula.Trim());
                                    //Obteniendo el cálculo...
                                    ImporteCalculado = Calc.calculate();
                                    Importe = ImporteCalculado.ToString("N2");
                                }
                            }
                            else
                            {
                                Importe = String.Empty;
                            }

                            //switch (oListaRatios[i].secItem)
                            //{
                            //    case "R0020": // 00024/00070

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00024" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00070" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            Resultado = (Valor1 / Valor2).ToString("N2");
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0030": // (00024-00020)/00070

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00024" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00020" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00070" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor3 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0 && Valor3 != 0)
                            //        {
                            //            Resultado = ((Valor1 - Valor2) / Valor3).ToString("N2");
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0040": // 00024/00070 Incoherente

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //           delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00024" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //           delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00070" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            Resultado = (Valor1 + Valor2).ToString("N2");
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0110": // 365/(00001GP/00013)

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00001" && eeff.TipoReporte == "GAPER"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00013" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            R1 = 365 / (Valor1 / Valor2);
                            //            Resultado = R1.ToString("N2");
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0120": // 365/(00016GP/00063)

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00016" && eeff.TipoReporte == "GAPER"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00063" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            R2 = 365 / (Valor1 / Valor2);
                            //            Resultado = R2.ToString("N2");
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0130": // 365/(00016GP/00020)

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00016" && eeff.TipoReporte == "GAPER"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00020" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            R3 = 365 / (Valor1 / Valor2);
                            //            Resultado = R3.ToString("N2");
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0140": //R0130+R0110-R0120

                            //        if (R1 != 0 && R2 != 0 && R3 != 0)
                            //        {
                            //            Resultado = (R3 + R1 - R2).ToString("N2");
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0170": //00082/00037

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00082" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00037" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            Resultado = (Valor1 / Valor2).ToString("N2") + "%";
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0180": // 00090/00037

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00090" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00037" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            Resultado = (Valor1 / Valor2).ToString("N2") + "%";
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0190": // 00082/00090

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00082" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00090" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            Resultado = (Valor1 / Valor2).ToString("N2");
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0210": // 00017GPV

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00017" && eeff.TipoReporte == "GAPER"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Resultado = EEFFItem.Analisis2V;
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0220": // 00025GPV

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00025" && eeff.TipoReporte == "GAPER"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Resultado = EEFFItem.Analisis2V;
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0230": // 00042GPV

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00042" && eeff.TipoReporte == "GAPER"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Resultado = EEFFItem.Analisis2V;
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0240": // 00089+(00030GP+00031GP)/00037

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00089" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00030" && eeff.TipoReporte == "GAPER"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00031" && eeff.TipoReporte == "GAPER"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor3 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00037" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor4 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0 && Valor3 != 0 && Valor4 != 0)
                            //        {
                            //            Resultado = (((Valor1 + (Valor2 + Valor3)) / Valor4) * -100).ToString("N2") + "%";
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    case "R0250": // 00089/00090

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00089" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor1 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        EEFFItem = oListaEEFF.Find
                            //        (
                            //            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == "00090" && eeff.TipoReporte == "BAL"; }
                            //        );

                            //        if (EEFFItem != null)
                            //        {
                            //            Valor2 = Convert.ToDecimal(EEFFItem.Anio2);
                            //        }

                            //        if (Valor1 != 0 && Valor2 != 0)
                            //        {
                            //            Resultado = ((Valor1 / Valor2) * 100).ToString("N2") + "%";
                            //        }
                            //        else
                            //        {
                            //            Resultado = String.Empty;
                            //        }

                            //        break;
                            //    default:
                            //        break;
                            //}

                            oListaRatios[i].Monto = Convert.ToDecimal(ImporteCalculado);

                            cell = new PdfPCell(new Paragraph(Importe, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        }
                        else
                        {
                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        }

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

        String FormulaExpresion(EEFFRatiosE oRatio, List<ReporteEEFFItemE> ListaEEFFDet)
        {
            String Formula = oRatio.Formula;
            String FormulaDevuelta = String.Empty;
            Boolean ContieneLetra = Formula.Contains("G") ? true : (Formula.Contains("R") ? true : false);
            string Clave = String.Empty;
            decimal Importe = 0;
            String Concepto = String.Empty;
            Int32 TotalCaracteres = !String.IsNullOrWhiteSpace(Formula) ? Formula.Length : 0;
            Int32 canCaracteresConcepto = 5;
            ReporteEEFFItemE DetalleEEFF = null;

            if (Formula.Trim() == "(00089+(00030GPH+00031GPH)/00037)*(-100)")
            {
                MessageBox.Show("aqui");
            }
            if (TotalCaracteres > 0)
            {
                if (!ContieneLetra)
                {
                    for (int Item = 0; Item <= TotalCaracteres; Item++)
                    {
                        Clave = String.Empty;

                        if (Item != TotalCaracteres)
                        {
                            Clave = Formula.Substring(Item, 1);

                            if (Global.EsNumero(Clave))
                            {
                                Concepto += Clave;
                            }
                            else
                            {
                                FormulaDevuelta += Concepto.Trim();
                                FormulaDevuelta += Clave.Trim();

                                DetalleEEFF = oListaEEFF.Find
                                (
                                    delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "BAL"; }
                                );

                                if (DetalleEEFF != null)
                                {
                                    Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                    if (Importe < 0)
                                    {
                                        FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                    }
                                    else
                                    {
                                        FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                    }
                                }

                                Concepto = String.Empty;
                            }
                        }
                        else
                        {
                            FormulaDevuelta += Concepto;
                            FormulaDevuelta += Clave;

                            DetalleEEFF = oListaEEFF.Find
                            (
                                delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "BAL"; }
                            );

                            if (DetalleEEFF != null)
                            {
                                Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                if (Importe < 0)
                                {
                                    FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                }
                                else
                                {
                                    FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                }
                            }
                        }
                    } 
                }
                else
                {
                    FormulaDevuelta = String.Empty;
                    Int32 Posicion = Formula.IndexOf("GPH"); //Buscando en la fórmula si hay Gasto o Perdida Horizontal

                    if (Posicion > 0)
                    {
                        //Obteniendo el concepto para poder hacer la busqueda
                        Concepto = Formula.Substring(Posicion - canCaracteresConcepto, canCaracteresConcepto);

                        DetalleEEFF = oListaEEFF.Find
                        (
                            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "GAPER"; }
                        );

                        if (DetalleEEFF != null)
                        {
                            Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                            if (Importe < 0)
                            {
                                Formula = Formula.Replace(Concepto + "GPH", "(" + Importe.ToString() + ")");
                            }
                            else
                            {
                                Formula = Formula.Replace(Concepto + "GPH", Importe.ToString());
                            }
                        }

                        //Buscando siguiente incidencia
                        Posicion = Formula.IndexOf("GPH", Posicion); //Buscando en la fórmula si hay Gasto o Perdida Horizontal

                        if (Posicion > 0)
                        {
                            Concepto = Formula.Substring(Posicion - canCaracteresConcepto, canCaracteresConcepto);

                            DetalleEEFF = oListaEEFF.Find
                            (
                                delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "GAPER"; }
                            );

                            if (DetalleEEFF != null)
                            {
                                Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                if (Importe < 0)
                                {
                                    Formula = Formula.Replace(Concepto + "GPH", "(" + Importe.ToString() + ")");
                                }
                                else
                                {
                                    Formula = Formula.Replace(Concepto + "GPH", Importe.ToString());
                                }
                            }

                            //Obteniendo el total de caracteres
                            TotalCaracteres = !String.IsNullOrWhiteSpace(Formula) ? Formula.Length : 0;
                            Concepto = String.Empty;

                            for (int Item = 0; Item <= TotalCaracteres; Item++)
                            {
                                Clave = String.Empty;

                                if (Item != TotalCaracteres)
                                {
                                    Clave = Formula.Substring(Item, 1);

                                    if (Global.EsNumero(Clave))
                                    {
                                        Concepto += Clave;
                                    }
                                    else
                                    {
                                        FormulaDevuelta += Concepto.Trim();
                                        FormulaDevuelta += Clave.Trim();

                                        DetalleEEFF = oListaEEFF.Find
                                        (
                                            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "BAL"; }
                                        );

                                        if (DetalleEEFF != null)
                                        {
                                            Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                            if (Importe < 0)
                                            {
                                                FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                            }
                                            else
                                            {
                                                FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                            }
                                        }

                                        Concepto = String.Empty;
                                    }
                                }
                                else
                                {
                                    FormulaDevuelta += Concepto;
                                    FormulaDevuelta += Clave;

                                    DetalleEEFF = oListaEEFF.Find
                                    (
                                        delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "BAL"; }
                                    );

                                    if (DetalleEEFF != null)
                                    {
                                        Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                        if (Importe < 0)
                                        {
                                            FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                        }
                                        else
                                        {
                                            FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Obteniendo el total de caracteres
                            TotalCaracteres = !String.IsNullOrWhiteSpace(Formula) ? Formula.Length : 0;
                            Concepto = String.Empty;

                            for (int Item = 0; Item <= TotalCaracteres; Item++)
                            {
                                Clave = String.Empty;

                                if (Item != TotalCaracteres)
                                {
                                    Clave = Formula.Substring(Item, 1);

                                    if (Global.EsNumero(Clave))
                                    {
                                        Concepto += Clave;
                                    }
                                    else
                                    {
                                        FormulaDevuelta += Concepto.Trim();
                                        FormulaDevuelta += Clave.Trim();

                                        DetalleEEFF = oListaEEFF.Find
                                        (
                                            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "BAL"; }
                                        );

                                        if (DetalleEEFF != null)
                                        {
                                            Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                            if (Importe < 0)
                                            {
                                                FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                            }
                                            else
                                            {
                                                FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                            }
                                        }

                                        Concepto = String.Empty;
                                    }
                                }
                                else
                                {
                                    FormulaDevuelta += Concepto;
                                    FormulaDevuelta += Clave;

                                    DetalleEEFF = oListaEEFF.Find
                                    (
                                        delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "BAL"; }
                                    );

                                    if (DetalleEEFF != null)
                                    {
                                        Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                        if (Importe < 0)
                                        {
                                            FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                        }
                                        else
                                        {
                                            FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else /****************************************************************************************************************************************/
                    {
                        FormulaDevuelta = String.Empty;
                        Posicion = Formula.IndexOf("GPV"); //Buscando en la fórmula si hay Gasto o Perdida Vertical
                        
                        if (Posicion > 0)
                        {
                            //Obteniendo el concepto para poder hacer la busqueda
                            Concepto = Formula.Substring(Posicion - canCaracteresConcepto, canCaracteresConcepto);

                            DetalleEEFF = oListaEEFF.Find
                            (
                                delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "GAPER"; }
                            );

                            if (DetalleEEFF != null)
                            {
                                //Importe = Convert.ToDecimal(DetalleEEFF.Analisis2V);
                                String cadImporte = DetalleEEFF.Analisis2V;

                                //if (Importe < 0)
                                //{
                                //    Formula = Formula.Replace(Concepto + "GPV", "(" + Importe.ToString() + ")");
                                //}
                                //else
                                //{
                                    Formula = Formula.Replace(Concepto + "GPV", cadImporte);
                                //}
                            }

                            //Buscando siguiente incidencia
                            Posicion = Formula.IndexOf("GPV", Posicion); //Buscando en la fórmula si hay Gasto o Perdida Horizontal

                            if (Posicion > 0)
                            {
                                Concepto = Formula.Substring(Posicion - canCaracteresConcepto, canCaracteresConcepto);

                                DetalleEEFF = oListaEEFF.Find
                                (
                                    delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "GAPER"; }
                                );

                                if (DetalleEEFF != null)
                                {
                                    //Importe = Convert.ToDecimal(DetalleEEFF.Analisis2V);
                                    String cadImporte = DetalleEEFF.Analisis2V;

                                    Formula = Formula.Replace(Concepto + "GPV", cadImporte);
                                    //if (Importe < 0)
                                    //{
                                    //    Formula = Formula.Replace(Concepto, "(" + Importe.ToString() + ")");
                                    //}
                                    //else
                                    //{
                                    //    Formula = Formula.Replace(Concepto, Importe.ToString());
                                    //}
                                }
                            }
                            else
                            {
                                //Obteniendo el total de caracteres
                                TotalCaracteres = !String.IsNullOrWhiteSpace(Formula) ? Formula.Length : 0;
                                Concepto = String.Empty;

                                for (int Item = 0; Item <= TotalCaracteres; Item++)
                                {
                                    Clave = String.Empty;

                                    if (Item != TotalCaracteres)
                                    {
                                        Clave = Formula.Substring(Item, 1);

                                        if (Global.EsNumero(Clave))
                                        {
                                            Concepto += Clave;
                                        }
                                        else
                                        {
                                            FormulaDevuelta += Concepto.Trim();
                                            FormulaDevuelta += Clave.Trim();

                                            DetalleEEFF = oListaEEFF.Find
                                            (
                                                delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "BAL"; }
                                            );

                                            if (DetalleEEFF != null)
                                            {
                                                Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                                if (Importe < 0)
                                                {
                                                    FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                                }
                                                else
                                                {
                                                    FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                                }
                                            }

                                            Concepto = String.Empty;
                                        }
                                    }
                                    else
                                    {
                                        FormulaDevuelta += Concepto;
                                        FormulaDevuelta += Clave;

                                        DetalleEEFF = oListaEEFF.Find
                                        (
                                            delegate (ReporteEEFFItemE eeff) { return eeff.secItem == Concepto && eeff.TipoReporte == "BAL"; }
                                        );

                                        if (DetalleEEFF != null)
                                        {
                                            Importe = Convert.ToDecimal(DetalleEEFF.Anio2);

                                            if (Importe < 0)
                                            {
                                                FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                            }
                                            else
                                            {
                                                FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else /////////////Ratios
                        {
                            for (int Item = 0; Item <= TotalCaracteres; Item++)
                            {
                                Clave = String.Empty;

                                if (Item != TotalCaracteres)
                                {
                                    Clave = Formula.Substring(Item, 1);

                                    if (Concepto.Length != canCaracteresConcepto)//Global.EsNumero(Clave))
                                    {
                                        Concepto += Clave;
                                    }
                                    else
                                    {
                                        FormulaDevuelta += Concepto.Trim();
                                        FormulaDevuelta += Clave.Trim();

                                        EEFFRatiosE DetalleRatio = oListaRatios.Find
                                        (
                                            delegate (EEFFRatiosE eeff) { return eeff.secItem == Concepto; }
                                        );

                                        if (DetalleRatio != null)
                                        {
                                            Importe = Convert.ToDecimal(DetalleRatio.Monto);

                                            if (Importe < 0)
                                            {
                                                FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                            }
                                            else
                                            {
                                                FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                            }
                                        }

                                        Concepto = String.Empty;
                                    }
                                }
                                else
                                {
                                    FormulaDevuelta += Concepto;
                                    FormulaDevuelta += Clave;

                                    EEFFRatiosE DetalleRatio = oListaRatios.Find
                                    (
                                        delegate (EEFFRatiosE eeff) { return eeff.secItem == Concepto; }
                                    );

                                    if (DetalleRatio != null)
                                    {
                                        Importe = Convert.ToDecimal(DetalleRatio.Monto);

                                        if (Importe < 0)
                                        {
                                            FormulaDevuelta = FormulaDevuelta.Replace(Concepto, "(" + Importe.ToString() + ")");
                                        }
                                        else
                                        {
                                            FormulaDevuelta = FormulaDevuelta.Replace(Concepto, Importe.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return FormulaDevuelta;
        }

        #endregion

        private void frmImprimirEEFFRatios_Load(object sender, EventArgs e)
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

class PaginaEEFFRatios : PdfPageEventHelper
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

        TituloGeneral = "RATIOS";
        SubTitulo = "Periodo: " + Periodo;

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

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 15.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f, "S2"));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow();

        document.Add(table); //Añadiendo la tabla al documento PDF
    }

}

#endregion