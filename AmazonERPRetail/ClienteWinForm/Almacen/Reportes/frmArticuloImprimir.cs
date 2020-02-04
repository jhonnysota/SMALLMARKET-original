using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmArticuloImprimir : FrmMantenimientoBase
    {
        
        List<ArticuloServE> oLista;
        String TipoReporte;
        String RutaGeneral;

        public frmArticuloImprimir()
        {
            InitializeComponent();
        }

        public frmArticuloImprimir(List<ArticuloServE> oLista_, String TipoReporte_)
            : this()
        {
            oLista = oLista_;
            TipoReporte = TipoReporte_;
        }

        private void frmCronogramaImprimir_Load(object sender, EventArgs e)
        {
            try
            {
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                this.Location = new Point(0, 0);
                this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

                if (oLista != null && oLista.Count > 0)
                {
                    Global.QuitarReferenciaWebBrowser(wbNavegador);
                    Document docPdf = new Document((PageSize.A4), 10f, 10f, 10f, 10f);
                    String NombreReporte = @"\Articulo_Reporte";
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

                        oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                        if (docPdf.IsOpen())
                        {
                            docPdf.CloseDocument();
                        }

                        int Columnas = 4;

                        float[] ArrayColumnas = new float[] { 0.2f, 0.06f, 0.45f, 0.07f };
                        String[] ArrayTitulos = new String[] { "Clase", "Código", "Descripción", "Stock" };
                        String Titulo = "Stock de Articulos";
                        String SubTitulo = " ";

                        int WidthPercentage = (80);

                        PaginaInicioArticuloReporteCronograma ev = new PaginaInicioArticuloReporteCronograma
                        {
                            Columnas = Columnas,
                            ArrayColumnas = ArrayColumnas,
                            ArrayTitulos = ArrayTitulos,
                            Titulo = Titulo,
                            SubTitulo = SubTitulo,
                            WidthPercentage = WidthPercentage
                        };

                        oPdfw.PageEvent = ev;

                        docPdf.Open();

                        #region Detalle                                    

                        if (TipoReporte == "")
                        {
                            PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                            TablaCabDetalle.WidthPercentage = WidthPercentage;
                            TablaCabDetalle.SetWidths(ArrayColumnas);

                            for (int i = 0; i < oLista.Count; i++)
                            {
                                cell = new PdfPCell(new Paragraph(oLista[i].desTipoArticulo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].codArticulo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(oLista[i].nomArticulo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);


                                cell = new PdfPCell(new Paragraph(oLista[i].Cantidad.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                            }

                            docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
                        }

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

class PaginaInicioArticuloReporteCronograma : PdfPageEventHelper
{

    public int Columnas { get; set; }
    public float[] ArrayColumnas { get; set; }
    public String[] ArrayTitulos { get; set; }
    public String Titulo { get; set; }
    public String SubTitulo { get; set; }
    public int WidthPercentage { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        //Chunk ch = new Chunk("This is my Stack Overflow Header on page " + writer.PageNumber);
        //document.Add(ch);

        //String TituloGeneral = String.Empty;
        //String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] {0.15f, 0.5f, 0.12f });
        table.HorizontalAlignment = Element.ALIGN_CENTER;

        #region Titulos Principales



        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha : " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada


        cell = new PdfPCell(new Paragraph("RUC : " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Hora :   " + HoraActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        string a = VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

        cell = new PdfPCell(new Paragraph( (a.Length>0?a.Substring(0,(a.Length>30?30:a.Length)):"") , FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Pag. : " + writer.PageNumber, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("       " + Titulo, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada


        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("       " + SubTitulo, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada


        // fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

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
                cell = new PdfPCell(new Paragraph(ArrayTitulos[i], FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
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