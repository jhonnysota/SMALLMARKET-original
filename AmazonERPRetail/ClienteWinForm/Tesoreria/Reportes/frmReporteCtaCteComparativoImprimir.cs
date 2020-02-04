using ClienteWinForm;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

namespace ClienteWinForm.Tesoreria.Reportes
{
    public partial class frmReporteCtaCteComparativoImprimir : FrmMantenimientoBase
    {
        String RutaGeneral = String.Empty;
        List<CtaCteE> oListaCtaCteComp = new List<CtaCteE>();
        public frmReporteCtaCteComparativoImprimir()
        {
            InitializeComponent();
        }

        private void frmReporteCtaCteComparativoImprimir_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            if (!String.IsNullOrEmpty(RutaGeneral))
            {
                wbNavegador.Navigate(RutaGeneral);
                RutaGeneral = "";
            }

            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        public frmReporteCtaCteComparativoImprimir(List<CtaCteE> OlistaCtaCte)
         : this()
        {
            oListaCtaCteComp = OlistaCtaCte;
            

            ConvertirApdf();
        }


        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\BalanceCCostoComprobacion " + Aleatorio.ToString();
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

                PaginaInicioCtaCteComparativo ev = new PaginaInicioCtaCteComparativo();
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(15);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.1f, 0.4f, 0.07f, 0.05f, 0.08f, 0.08f, 0.08f, 0.05f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f });
                Decimal Total1Sol = 0;
                Decimal Total2Sol = 0;
                Decimal Total3Dol = 0;
                Decimal Total4Dol = 0;
                Decimal Cantcero = 0;

                Decimal Total1SolSUB = 0;
                Decimal Total2SolSUB = 0;
                Decimal Total3DolSUB = 0;
                Decimal Total4DolSUB = 0;
                Decimal ColDif1 = 0;
                Decimal ColDif2 = 0;
                Decimal Total5Dif1 = 0;
                Decimal Total6Dif2 = 0;

                int contador = 0;
                string CodCuenta = "";
                // ==========================

                for (int i = 0; i < oListaCtaCteComp.Count; i++)
                {

                    if (contador == 0)
                    {
                        CodCuenta = oListaCtaCteComp[i].codCuenta;
                    }

                    if (CodCuenta != oListaCtaCteComp[i].codCuenta)
                    {
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 15;
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph("SUB-TOTAL", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        cell.Colspan = 9;
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(Total1SolSUB.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(Total2SolSUB.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(Total3DolSUB.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(Total4DolSUB.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        Total5Dif1 = Total1SolSUB - Total2SolSUB;
                        Total6Dif2 = Total3DolSUB - Total4DolSUB;
                        cell = new PdfPCell(new Paragraph(Total5Dif1.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(Total6Dif2.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        CodCuenta = oListaCtaCteComp[i].codCuenta;

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 15;
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        Total1SolSUB = 0;
                        Total2SolSUB = 0;
                        Total3DolSUB = 0;
                        Total4DolSUB = 0;
                        Total5Dif1 = 0;
                        Total6Dif2 = 0;
                    }



                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].codCuenta, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].RUC, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].RazonSocial, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].idDocumento, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].numSerie, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].numDocumento, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].FechaDocumento.ToString("d"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].FechaVencimiento.Value.ToString("d"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].idMoneda, FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    if (oListaCtaCteComp[i].idMoneda == Variables.Soles)
                    {
                        cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].SaldoOperativo.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Total1Sol += oListaCtaCteComp[i].SaldoOperativo;

                        cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].SaldoContable.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Total2Sol += oListaCtaCteComp[i].SaldoContable;

                        cell = new PdfPCell(new Paragraph(Cantcero.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Cantcero.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Total5Dif1 = oListaCtaCteComp[i].SaldoOperativo - oListaCtaCteComp[i].SaldoContable;

                        cell = new PdfPCell(new Paragraph(Total5Dif1.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Cantcero.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Total1SolSUB += oListaCtaCteComp[i].SaldoOperativo;
                        Total2SolSUB += oListaCtaCteComp[i].SaldoContable;

                        ColDif1 += Total5Dif1;
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph(Cantcero.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Cantcero.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].SaldoOperativo.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Total3Dol += oListaCtaCteComp[i].SaldoOperativo;

                        cell = new PdfPCell(new Paragraph(oListaCtaCteComp[i].SaldoContable.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Total6Dif2 = oListaCtaCteComp[i].SaldoOperativo - oListaCtaCteComp[i].SaldoContable;

                        cell = new PdfPCell(new Paragraph(Cantcero.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Total6Dif2.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        Total4Dol += oListaCtaCteComp[i].SaldoContable;

                        Total3DolSUB += oListaCtaCteComp[i].SaldoOperativo;
                        Total4DolSUB += oListaCtaCteComp[i].SaldoContable;
                        ColDif2 += Total6Dif2;

                    }
                    TablaCabDetalle.CompleteRow();




                    contador++;
                }

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                cell.Colspan = 15;
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph("SUB-TOTAL", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                cell.Colspan = 9;
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(Total1SolSUB.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(Total2SolSUB.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(Total3DolSUB.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(Total4DolSUB.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                Total5Dif1 = Total1SolSUB - Total2SolSUB;
                Total6Dif2 = Total3DolSUB - Total4DolSUB;
                cell = new PdfPCell(new Paragraph(Total5Dif1.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(Total6Dif2.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                cell.Colspan = 15;
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph(" TOTALES ", FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                cell.Colspan = 9;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Total1Sol.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Total2Sol.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Total3Dol.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Total4Dol.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(ColDif1.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(ColDif2.ToString("N2"), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

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
            }
        }

        PdfPCell CellPdf(string titulo, int size, int border, string align, string bold)
        {
            if (border < 0)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 5f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 5f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { Border = border, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }
    }
}



#region Inicio Pdf

class PaginaInicioCtaCteComparativo : PdfPageEventHelper
{
    public String Formato { get; set; }
    public String NombreFormato { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        //Chunk ch = new Chunk("This is my Stack Overflow Header on page " + writer.PageNumber);
        //document.Add(ch);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;


        TituloGeneral = " CUENTA CORRIENTE COMPARATIVO ";

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

        PdfPTable TablaCabDetalle = new PdfPTable(15);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.1f, 0.4f, 0.07f, 0.05f, 0.08f, 0.08f, 0.08f, 0.05f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f });

        #region Primera Linea

        cell = new PdfPCell(new Paragraph(" Cod. Cuenta", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" RUC", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Razon Social", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Documento", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Num. Serie", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Num. Doc.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Fecha Doc.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Fecha Ven.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Moneda", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Saldo Op. Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Saldo Con. Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Saldo Op. Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Saldo Con. Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Diferencia Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Diferencia Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}

#endregion