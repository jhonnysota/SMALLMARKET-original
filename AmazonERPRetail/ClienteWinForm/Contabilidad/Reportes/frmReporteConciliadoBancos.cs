using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Entidades.Contabilidad;
using ClienteWinForm;
using Infraestructura;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteConciliadoBancos : Form
    {

        #region Constructores

        public frmReporteConciliadoBancos()
        {
            InitializeComponent();
        }

        public frmReporteConciliadoBancos(List<ConciliadoDcmtoPendienteE> oLista_, String Monto, String Bancotmp_, String Numcuenta_, String Periodo_, String Moneda_)
           :this()
        {
            oLista = oLista_;
            Montosub = Convert.ToDecimal(Monto);
            Banco = Bancotmp_;
            Numcuenta = Numcuenta_;
            Periodo = Periodo_;
            Moneda = Moneda_;
        }

        #endregion

        #region Variables

        String Banco, Numcuenta, Periodo, Moneda;
        String RutaGeneral;
        List<ConciliadoDcmtoPendienteE> oLista;
        Decimal Montosub = 0; 

        #endregion

        private void frmReporteConciliadoBancos_Load(object sender, EventArgs e)
        {
            try
            {
                //Ubicacion del Reporte
                Location = new Point(0, 0);
                Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

                if (oLista != null && oLista.Count > 0)
                {
                    Global.QuitarReferenciaWebBrowser(wbNavegador);

                    Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    Guid Aleatorio = Guid.NewGuid();
                    String NombreReporte = @"\Conciliacion " + Aleatorio.ToString();
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

                        int Columnas = 5;

                        float[] ArrayColumnas = new float[] { 0.1f, 0.2f, 0.4f, 0.2f , 0.2f };
                        String[] ArrayTitulos = new String[] { "FECHA", "DOCUMENTO", "DESCRIPCION", "DEPOSITOS NO REALIZADOS" , "CHEQUES NO COBRADOS"};
                        String Titulo = "CONCILIACION BANCARIA";
                        String SubPeriodo = String.Empty;
                        int WidthPercentage = 100;

                        PaginaConciliadoBancos ev = new PaginaConciliadoBancos
                        {
                            Columnas = Columnas,
                            ArrayColumnas = ArrayColumnas,
                            ArrayTitulos = ArrayTitulos,
                            Titulo = Titulo,
                            Bancotra = Banco,
                            //ev.oLista = oLista;
                            //ev.SubPeriodo = SubPeriodo;
                            Numcuenta = Numcuenta,
                            WidthPercentage = WidthPercentage,
                            Periodo = Periodo,
                            Moneda = Moneda
                        };

                        oPdfw.PageEvent = ev;

                        docPdf.Open();

                        #region Formatos

                        PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                        TablaCabDetalle.WidthPercentage = WidthPercentage;
                        TablaCabDetalle.SetWidths(ArrayColumnas);

                        Decimal Debetotal = 0;
                        Decimal Habertotal = 0;

                        for (int i = 0; i < oLista.Count; i++)
                        {
                            if (oLista[i].Orden != "1")
                            {
                                cell = new PdfPCell(new Paragraph(oLista[i].fecDocumento.Value.ToString("d"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].idDocumento + " " + oLista[i].serDocumento + " " + oLista[i].numDocumento, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].desGlosa, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].Debe.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].Haber.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                cell.Colspan = 2;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].desGlosa, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].Debe.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].Haber.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                            }

                            Debetotal += oLista[i].Debe;
                            Habertotal += oLista[i].Haber;
                        }

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 3;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Debetotal.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Habertotal.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 2;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("SALDO SEGÚN CONCILIACION ==>", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Decimal SegunCon = Debetotal - Habertotal;

                        cell = new PdfPCell(new Paragraph(SegunCon.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Decimal NegCon = SegunCon - Montosub;

                        cell = new PdfPCell(new Paragraph(NegCon.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 2;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("SALDO SEGÚN LIBRO ==>", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Montosub.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
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
                        fsNuevoArchivo.Close();

                        if (!String.IsNullOrEmpty(RutaGeneral))
                        {
                            wbNavegador.Navigate(RutaGeneral);
                            RutaGeneral = String.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

    }
}

#region Inicio Pdf

class PaginaConciliadoBancos : PdfPageEventHelper
{
    //public List<ConciliadoDcmtoPendienteE> oLista { get; set; }
    public int Columnas { get; set; }
    public float[] ArrayColumnas { get; set; }
    public String[] ArrayTitulos { get; set; }
    public String Titulo { get; set; }
    public String Bancotra { get; set; }
    public String Numcuenta { get; set; }
    public String Periodo { get; set; }
    public String Moneda { get; set; }
    public int WidthPercentage { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;
        BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3)
        {
            WidthPercentage = 100
        };

        table.SetWidths(new float[] { 0.28f, 0.38f, 0.33f });

        #region Titulos Principales

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda(Titulo, null, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 5, 1));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda(Bancotra + " "  + Moneda + " "+ Numcuenta, null, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 5, 1));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.PeriodoContable.AnioPeriodo  + "-" + Periodo, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 0));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.CompleteRow();

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        if (Columnas > 0)
        {

            PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
            TablaCabDetalle.WidthPercentage = WidthPercentage;
            TablaCabDetalle.SetWidths(ArrayColumnas);

            #region Primera Linea


            for (int i = 0; i < ArrayTitulos.Length; i++)
            {
                cell = new PdfPCell(new Paragraph(ArrayTitulos[i], FontFactory.GetFont("Arial", 7f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);
            }

            TablaCabDetalle.CompleteRow();

            #endregion


            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF


        }
        #endregion

    }

}

#endregion
