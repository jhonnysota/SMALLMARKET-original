using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using ClienteWinForm;
using Infraestructura;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Maestros.Reportes
{
    public partial class frmReporteMovilidadesDetalle : FrmMantenimientoBase
    {

        #region Constructores

        public frmReporteMovilidadesDetalle()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
            Font = new System.Drawing.Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        public frmReporteMovilidadesDetalle(MovilidadE oLista_)
            :this()
        {
            oListaMov = oLista_;
        }

        #endregion

        #region Variables

        String RutaGeneral = String.Empty;
        MovilidadE oListaMov = new MovilidadE();
        String RutaImagen = String.Empty; 

        #endregion

        private void frmReporteCCostos_Load(object sender, EventArgs e)
        {
            Global.QuitarReferenciaWebBrowser(wbNavegador);
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";     
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Movilidad Detalle " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

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

                oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                if (docPdf.IsOpen())
                {
                    docPdf.CloseDocument();
                }

                PaginaInicialMovilidadesDetalle ev = new PaginaInicialMovilidadesDetalle()
                {
                    rutaimagen = RutaImagen,
                    entidadtmp = oListaMov,
                    Fecha = oListaMov.Fecha
                };

                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaDeta = new PdfPTable(8);
                TablaDeta.WidthPercentage = 100;
                TablaDeta.SetWidths(new float[] { 0.02f, 0.05f, 0.25f, 0.05f, 0.1f, 0.2f, 0.2f, 0.05f });

                Int32 ItemCorre = 1;
                Decimal totSoles = 0;

                foreach (MovilidadDetE item in oListaMov.ListaMovilidadDet)
                {
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(ItemCorre.ToString("00"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Fecha.ToString("dd/MM/yyyy"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.RUC, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.desCCostos, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Desplazamiento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.MotivoDestino, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                    TablaDeta.CompleteRow();

                    ItemCorre++;
                    totSoles += item.Monto;
                }

                ////Ultimas filas
                TablaDeta.AddCell(ReaderHelper.NuevaCelda("Totales (S/.)", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, -1, "S7"));
                TablaDeta.AddCell(ReaderHelper.NuevaCelda(totSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaDeta.CompleteRow();

                //Linea en blanco
                TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S8", "N", 2f, 2f, "N", "S", "N", "N"));
                TablaDeta.CompleteRow();

                docPdf.Add(TablaDeta);

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
}


internal class PaginaInicialMovilidadesDetalle : PdfPageEventHelper
{
    public String rutaimagen { get; set; }
    public MovilidadE entidadtmp { get; set; }
    public DateTime Fecha { get; set; }


    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        //BaseColor colCabDetalle = BaseColor.LIGHT_GRAY;
        String TituloGeneral = String.Empty;
        //String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        BaseColor ColorFondo = BaseColor.LIGHT_GRAY;
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

        document.Add(table); //Añadiendo la tabla al documento PDF


        TituloGeneral = "PLANILLA DE MOVILIDAD\r\n" + Fecha.ToString("dd/MM/yyyy");
        //BaseColor ColorFondo = BaseColor.LIGHT_GRAY; //Gris Claro
        //SubTitulo = "En El Dia " + FechaActual;

        PdfPTable tableTitulos = new PdfPTable(2);
        tableTitulos.WidthPercentage = 100;
        tableTitulos.SetWidths(new float[] { 0.03f, 0.2f });

        #region Titulos Principales

        PdfPCell CeldaImagen = null;

        if (File.Exists(rutaimagen))
        {
            //CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(rutaimagen, 120f, 1, "N", 0, 8f));
            System.Drawing.Image Img = System.Drawing.Image.FromFile(rutaimagen);
            CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 135f, 30f));
            Img = null;
        }
        else
        {
            CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
        }

        tableTitulos.AddCell(CeldaImagen);
        tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral.PadLeft(82, ' '), null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, -1, "N", "N", 13f, 13f));
        tableTitulos.CompleteRow();

        tableTitulos.AddCell(ReaderHelper.NuevaCelda("Con Fecha de : " + Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S2"));
        tableTitulos.CompleteRow();

        //Lineas en Blanco
        tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2", "N", 2f, 2f, "N", "S", "N", "N"));
        tableTitulos.CompleteRow();

        tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2"));
        tableTitulos.CompleteRow();

        document.Add(tableTitulos); //Añadiendo la tabla al documento PDF

        #endregion Titulos Principales

        #region Subtitulos

        PdfPTable TablaDeta = new PdfPTable(8);
        TablaDeta.WidthPercentage = 100;
        TablaDeta.SetWidths(new float[] { 0.02f, 0.05f, 0.25f, 0.05f, 0.1f, 0.2f, 0.2f, 0.05f });

        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Sucursal: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionLocal.Nombre, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S6"));
        TablaDeta.CompleteRow();

        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Periodo: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Con La Fecha de " + Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 0, "S6"));

        TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S8"));
        TablaDeta.CompleteRow();

        #endregion

        #region TItulos

        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Nro.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Fecha", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Empleado", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda("DNI", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Area", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Desplazamiento", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
        TablaDeta.AddCell(ReaderHelper.NuevaCelda("Monto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
        TablaDeta.CompleteRow();


        document.Add(TablaDeta); //Añadiendo la tabla al documento PDF

        #endregion

    }

}
