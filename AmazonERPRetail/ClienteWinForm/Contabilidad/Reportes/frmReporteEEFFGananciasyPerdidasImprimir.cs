using Infraestructura.Enumerados;
using Infraestructura.Winform;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.IO;

using ClienteWinForm;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEEFFGananciasyPerdidasImprimir : FrmMantenimientoBase
    {
        String RutaGeneral = String.Empty;

        DataTable oDatos;

        String NombreItem = "";
        String NombreMes = "";

        public frmReporteEEFFGananciasyPerdidasImprimir()
        {
            InitializeComponent();
        }

        private void frmReporteEEFFGananciasyPerdidasImprimir_Load(object sender, EventArgs e)
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

        public frmReporteEEFFGananciasyPerdidasImprimir(DataTable dtDatos,String NombreItem_,String NombreMes_)
            :this()
        {
            oDatos = dtDatos;

            NombreItem = NombreItem_;
            NombreMes = NombreMes_;

            ConvertirApdf();
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document((oDatos.Columns.Count>11 ? PageSize.A4.Rotate() : PageSize.A4), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\EEFFGananciayPerdidasImprimir" + NombreMes + " " + Aleatorio.ToString();
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

                // -----------------------------------------------
                // Para la creacion del archivo pdf
                // -----------------------------------------------

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

                PaginaCabeceraReporteEEFFGananciasyPerdidasImprimir ev = new PaginaCabeceraReporteEEFFGananciasyPerdidasImprimir();

                //Parametros Que Pasaras Al PDF
                ev.oDatos = oDatos;
                ev.TotalColumnas = oDatos.Columns.Count;
                ev.WidthTabla = 100;
                ev.NombreItem = NombreItem;
                ev.mes = NombreMes;

                float[] columnasFloat = new float[oDatos.Columns.Count-2] ;
 
                for( int i = 0; i < oDatos.Columns.Count-2; i ++)
                {
                    columnasFloat[i] = (i==0? 0.5f :(i==1? 2.5f : 0.70f ));
                }

                ev.tamano_cabecera = columnasFloat;

                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable tablacabdetalle = new PdfPTable(oDatos.Columns.Count-2);
                tablacabdetalle.WidthPercentage = 100;
                tablacabdetalle.SetWidths(columnasFloat);

                int InicioLinea=1;

                foreach (DataRow item in oDatos.Rows)
                {
                    for (int i = 2; i < oDatos.Columns.Count; i++)
                    {
                        
                        //oHoja.Cells[InicioLinea, i - 1].Value = item[i];
                        if (i == 2)
                            cell = PdfPCell(item[i].ToString(), 6f, "center", (item[0].ToString() == "TOT" ? "bold" : ""));
                        else if (i == 3)
                            cell = PdfPCell(item[i].ToString(), 6f, "left", (item[0].ToString() == "TOT" ? "bold" : ""));
                        else
                            cell = PdfPCell(item[i].ToString(), 6f, "rigth", (item[0].ToString() == "TOT" ? "bold" :""));

                        tablacabdetalle.AddCell(cell);
                    }

                    tablacabdetalle.CompleteRow();

                    InicioLinea++;
                }

                docPdf.Add(tablacabdetalle); //Añadiendo la tabla al documento PDF


                // ----------------------------------------
                // END FOR 
                // ----------------------------------------


                
                // ----------------------------------------


                

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

        PdfPCell PdfPCell(string texto, float tamano_letra, string align, string negrita)
        {
            return new PdfPCell(new Paragraph(texto, FontFactory.GetFont("Arial", tamano_letra, (negrita == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)))) { Border = 0, HorizontalAlignment = (align == "center" ? Element.ALIGN_CENTER : (align == "left" ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        PdfPCell PdfPCell_(string texto, float tamano_letra, string align, string negrita)
        {
            return new PdfPCell(new Paragraph(texto, FontFactory.GetFont("Arial", tamano_letra, (negrita == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)))) { HorizontalAlignment = (align == "center" ? Element.ALIGN_CENTER : (align == "left" ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }
    }
}

class PaginaCabeceraReporteEEFFGananciasyPerdidasImprimir : PdfPageEventHelper
{
    public float[] tamano_cabecera { get; set; }
    public int TotalColumnas { get; set; }
    public int WidthTabla { get; set; }
    public String NombreItem { get; set; }

    public String mes { get; set; }
    public String ano { get; set; }

    public DataTable oDatos { get; set; }

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

        TituloGeneral = NombreItem + " - " + FechasHelper.NombreMes(Convert.ToInt32(mes)).ToUpper(); ;

        //string nombre_mes = (Convert.ToInt32(mes_ini) == 0 ? "APERTURA" : (Convert.ToInt32(mes_ini) == 13 ? "CIERRE" : Global.NombreMes(Convert.ToInt32(mes_ini))));
        //string nombres_mes_fin = (Convert.ToInt32(mes_fin) == 0 ? "APERTURA" : (Convert.ToInt32(mes_fin) == 13 ? "CIERRE" : Global.NombreMes(Convert.ToInt32(mes_fin))));

        //SubTitulo = "Del Mes de " + nombre_mes + " a " + nombres_mes_fin.ToUpper() + " del " + ano;
        SubTitulo = "";

        // ======================================
        // Cabecera del Reporte
        // ======================================

        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.9f, 0.15f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;


        #region Cabacera Pagina

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 5.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha : " + FechaActual, FontFactory.GetFont("Arial", 5.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);

        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 5.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Hora :   " + HoraActual, FontFactory.GetFont("Arial", 5.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 5.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Pag. :   " + writer.PageNumber, FontFactory.GetFont("Arial", 5.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5.5f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada 

        #endregion


        #region Titulos Principales

        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 8, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);

        table.CompleteRow(); //Fila completada 

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF


        #region Cabecera del Detalle


        // ====================
        // TABLA CABECERA
        // ====================

        PdfPTable TablaCabDetalle = new PdfPTable(this.TotalColumnas-2);
        TablaCabDetalle.WidthPercentage = this.WidthTabla;
        TablaCabDetalle.SetWidths(this.tamano_cabecera);

        #region Titulos

        for (Int32 i = 2; i < oDatos.Columns.Count; i++)
        {

            cell = new PdfPCell(new Paragraph(oDatos.Columns[i].ColumnName.Replace("-","\n") , FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            //cell.Colspan = 3;
            TablaCabDetalle.AddCell(cell);
        }

        TablaCabDetalle.CompleteRow();


        #endregion


        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}
