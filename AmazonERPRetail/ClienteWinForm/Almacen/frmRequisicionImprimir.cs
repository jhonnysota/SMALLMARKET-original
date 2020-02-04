//using Negocio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Winform;
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
using ClienteWinForm;

namespace ClienteWinForm.Almacen
{
    public partial class frmRequisicionImprimir : Form
    {
        public frmRequisicionImprimir()
        {
            InitializeComponent();
        }



        public frmRequisicionImprimir(List<RequisicionE> oLista_, RequisicionE oReq_)
            : this()
        {
            oLista = oLista_;
            oReq = oReq_;
        }

        String RutaGeneral;
        List<RequisicionE> oLista;
        RequisicionE oReq;
        private void frmRequisicionImprimir_Load(object sender, EventArgs e)
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
                    String NombreReporte = @"\" + "_" + VariablesLocales.FechaHoy.Year.ToString() + "_" + VariablesLocales.FechaHoy.Month.ToString() + "_" + VariablesLocales.FechaHoy.Day.ToString() + "_" + VariablesLocales.FechaHoy.Hour.ToString() + "_" + VariablesLocales.FechaHoy.Minute.ToString();
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

                        int Columnas = 4;

                        float[] ArrayColumnas = new float[] {0.05f, 0.05f, 0.14f, 0.04f };
                        String[] ArrayTitulos = new String[] { "ITEM" ,"Codigo", "Descripcion", "Cantidad" };
                        String Titulo = "Orden de Trabajo Interno";
                        String SubTitulo = "Decreto Supremo No.004-2006-TR";
                        String SubPeriodo = String.Empty;



                        int WidthPercentage = 100;

                        PaginaRequisicionImprimir ev = new PaginaRequisicionImprimir();

                        ev.Columnas = Columnas;
                        ev.ArrayColumnas = ArrayColumnas;
                        ev.ArrayTitulos = ArrayTitulos;
                        ev.Titulo = Titulo;
                        ev.oLista = oLista;
                        ev.SubTitulo = SubTitulo;
                        ev.SubPeriodo = SubPeriodo;
                        ev.oReq = oReq;
                        ev.WidthPercentage = WidthPercentage;


                        oPdfw.PageEvent = ev;

                        docPdf.Open();




                        #region Formatos


                        PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                        TablaCabDetalle.WidthPercentage = WidthPercentage;
                        TablaCabDetalle.SetWidths(ArrayColumnas);

                        for (int i = 0; i < oReq.ListaRequisicionItem.Count; i++)
                        {
                            cell = new PdfPCell(new Paragraph(oReq.ListaRequisicionItem[i].idRequisicion.ToString(), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oReq.ListaRequisicionItem[i].idArticulo.ToString(), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oReq.ListaRequisicionItem[i].DesArticulo.ToString(), FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);
                             
                            cell = new PdfPCell(new Paragraph(oReq.ListaRequisicionItem[i].CantidadOrdenada.ToString("N2") , FontFactory.GetFont("Arial", 7f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                        }


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

class PaginaRequisicionImprimir : PdfPageEventHelper
{
    public List<RequisicionE> oLista { get; set; }
    public RequisicionE oReq { get; set; }
    public int Columnas { get; set; }
    public float[] ArrayColumnas { get; set; }
    public String[] ArrayTitulos { get; set; }
    public String Titulo { get; set; }
    public String SubTitulo { get; set; }
    public String SubPeriodo { get; set; }
    public int WidthPercentage { get; set; }


    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        //Chunk ch = new Chunk("This is my Stack Overflow Header on page " + writer.PageNumber);
        //document.Add(ch);

        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;
        BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.28f, 0.38f, 0.33f });
        //table.HorizontalAlignment = Element.ALIGN_CENTER;

        #region Titulos Principales

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda("REQUERIMIENTO DE COMPRA", null, "S", null, FontFactory.GetFont("Arial", 14.25f, iTextSharp.text.Font.BOLD), 1, 0,"N","N",2,2,"N","S","N","N"));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda("Sucursal Solicitante : " + oReq.DesLocal, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1,0));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f),1,0));
        table.AddCell(ReaderHelper.NuevaCelda("Sucursal Atención : " + oReq.DesLocalAtencion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 0));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda("N° Requerimiento : "  + oReq.SiglaSucursal + "/" + "RC" + "/" + oReq.idRequisicion + "/"+ oReq.FechaSolicitud.Value.ToString("YYYY") , null, "N", null, FontFactory.GetFont("Arial", 7.25f),1,-1));
        table.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, -1));
        table.AddCell(ReaderHelper.NuevaCelda("Fecha Solicitud : " + oReq.FechaSolicitud.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, -1));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda("Fecha Requerida : " + oReq.FechaRequerida.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, -1));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, -1));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, -1));
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph( "Observaciones : " +oReq.Observacion, FontFactory.GetFont("Arial", 7.25f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        cell.Colspan = 6;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph("Centro de Costos: " + oReq.desCCostos, FontFactory.GetFont("Arial", 7.25f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        cell.Colspan = 3;
        table.AddCell(cell);
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
                cell = new PdfPCell(new Paragraph(ArrayTitulos[i], FontFactory.GetFont("Arial", 9f))) {  HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
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