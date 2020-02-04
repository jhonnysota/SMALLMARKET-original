using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmComisionesConfiguracionImprimir : FrmMantenimientoBase
    {

        public frmComisionesConfiguracionImprimir()
        {
            InitializeComponent();
        }

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        String RutaGeneral;
        ComisionesConfiguracionE oEntidad;
        List<ComisionesConfiguracionE> oListaLineaGeneral = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaTarifarioGeneral = new List<ComisionesConfiguracionE>();

        public frmComisionesConfiguracionImprimir(ComisionesConfiguracionE oEntidad_) 
            : this()
        {
            oEntidad = oEntidad_;
            oEntidad.oListaCategoria = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "categoria");
            oListaLineaGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "linea");
            oListaTarifarioGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "tarifario");
            oEntidad.oListaCriterio = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "criterio");
            oEntidad.oListaVendedor = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "vendedor");

            //if (oEntidad.oListaCategoria != null && oEntidad.oListaCategoria.Count > 0)
            //    idCategoriaSeleccionada = oEntidad.oListaCategoria[0].idCategoria;
            //else
            //    idCategoriaSeleccionada = 0;

            //oEntidad.oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

            oEntidad.oListaLinea = oListaLineaGeneral;

            //oEntidad.oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

            oEntidad.oListaTarifario = oListaTarifarioGeneral;

        }

        private void frmComisionesConfiguracionImprimir_Load(object sender, EventArgs e)
        {
            try
            {
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                this.Location = new Point(0, 0);
                this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

                if (oEntidad != null && oEntidad.oListaCategoria.Count > 0)
                {

                    Global.QuitarReferenciaWebBrowser(wbNavegador);

                    Document docPdf = new Document((PageSize.A4), 10f, 10f, 10f, 10f);
                    String NombreReporte = @"\ComisionesConfiguracion";
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

                        int Columnas = 6;

                        float[] ArrayColumnas = new float[] { 0.18f, 0.4f };
                        String[] ArrayTitulos = new String[] { "Codigo", "Vendedor" };

                        float[] ArrayColumnas2 = new float[] { 0.18f, 0.4f };
                        String[] ArrayTitulos2 = new String[] { "Codigo", "Categoria" };

                        float[] ArrayColumnas3 = new float[] { 0.18f, 0.4f, 0.2f };
                        String[] ArrayTitulos3 = new String[] { "Codigo", "Elemento Subjetivo", "Comision" };

                        float[] ArrayColumnas4 = new float[] { 0.18f, 0.4f, 0.2f, 0.3f, 0.3f, 0.3f };
                        String[] ArrayTitulos4 = new String[] { "Codigo", "Linea", "Meta 9L", "Resultado 9L", "Porcentaje", "Pago" };

                        float[] ArrayColumnas5 = new float[] { 0.18f, 0.2f, 0.2f, 0.2f, 0.3f };
                        String[] ArrayTitulos5 = new String[] { "Codigo", "%Inicial", "%Fin", "Factor", "Comisión" };

                        String Titulo = "Comisiones Configuracion";
                        String SubTitulo = " ";

                        int WidthPercentage = (90);

                        PaginaInicioComisionesConfiguracionRequerimiento ev = new PaginaInicioComisionesConfiguracionRequerimiento();

                        ev.Columnas = Columnas;
                        ev.ArrayColumnas = ArrayColumnas;
                        ev.ArrayTitulos = ArrayTitulos;
                        ev.ArrayColumnas2 = ArrayColumnas2;
                        ev.ArrayTitulos2 = ArrayTitulos2;
                        ev.ArrayColumnas3 = ArrayColumnas3;
                        ev.ArrayTitulos3 = ArrayTitulos3;
                        ev.ArrayColumnas4 = ArrayColumnas4;
                        ev.ArrayTitulos4 = ArrayTitulos4;
                        ev.ArrayColumnas5 = ArrayColumnas5;
                        ev.ArrayTitulos5 = ArrayTitulos5;

                        ev.Titulo = Titulo;
                        ev.SubTitulo = SubTitulo;
                        ev.WidthPercentage = WidthPercentage;
                        ev.oEntidad = oEntidad;

                        oPdfw.PageEvent = ev;

                        docPdf.Open();

                        // ================
                        // DATA
                        // ================

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

class PaginaInicioComisionesConfiguracionRequerimiento : PdfPageEventHelper
{

    public int Columnas { get; set; }
    public float[] ArrayColumnas { get; set; }
    public String[] ArrayTitulos { get; set; }
    public float[] ArrayColumnas2 { get; set; }
    public String[] ArrayTitulos2 { get; set; }
    public float[] ArrayColumnas3 { get; set; }
    public String[] ArrayTitulos3 { get; set; }
    public float[] ArrayColumnas4 { get; set; }
    public String[] ArrayTitulos4 { get; set; }
    public float[] ArrayColumnas5 { get; set; }
    public String[] ArrayTitulos5 { get; set; }

    public String Titulo { get; set; }
    public String SubTitulo { get; set; }
    public int WidthPercentage { get; set; }
    public ComisionesConfiguracionE oEntidad { get; set; }


    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);


        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;



        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.15f, 0.5f, 0.12f });
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

        cell = new PdfPCell(new Paragraph((a.Length > 0 ? a.Substring(0, (a.Length > 30 ? 30 : a.Length)) : ""), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER };
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

            //PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
            //TablaCabDetalle.WidthPercentage = WidthPercentage;
            //TablaCabDetalle.SetWidths(new float[] { 0.18f, 0.4f });

            #region Primera Linea


            PdfPTable TablaDate1 = new PdfPTable(2);
            TablaDate1.WidthPercentage = 60;
            TablaDate1.SetWidths(ArrayColumnas);

            cell = new PdfPCell(new Paragraph("Nombre Zona :", FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaDate1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(oEntidad.NombreZona, FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_LEFT };
            TablaDate1.AddCell(cell);



            TablaDate1.CompleteRow();



            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaDate1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaDate1.AddCell(cell);


            TablaDate1.CompleteRow();


            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaDate1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaDate1.AddCell(cell);


            TablaDate1.CompleteRow();


            document.Add(TablaDate1); 


            PdfPTable TablaCabDetalle2 = new PdfPTable(2);
            TablaCabDetalle2.WidthPercentage = 60;
            TablaCabDetalle2.SetWidths(ArrayColumnas);



            for (int i = 0; i < ArrayTitulos.Length; i++)
            {
                cell = new PdfPCell(new Paragraph(ArrayTitulos[i], FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle2.AddCell(cell);
            }


            TablaCabDetalle2.CompleteRow();

            for (int i = 0; i < oEntidad.oListaVendedor.Count; i++)
            {

                cell = new PdfPCell(new Paragraph(oEntidad.oListaVendedor[i].idVendedor.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaVendedor[i].desPersona, FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle2.AddCell(cell);


                TablaCabDetalle2.CompleteRow();

            }

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle2.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle2.AddCell(cell);


            TablaCabDetalle2.CompleteRow();

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle2.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle2.AddCell(cell);


            TablaCabDetalle2.CompleteRow();


            document.Add(TablaCabDetalle2);






            //TABLA CATEGORIAS Y CRITERIO




            PdfPTable TablaCabDetalle3 = new PdfPTable(2);
            TablaCabDetalle3.WidthPercentage = 60;
            TablaCabDetalle3.SetWidths(ArrayColumnas2);


            cell = new PdfPCell(new Paragraph(" Categorias ", FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle3.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle3.AddCell(cell);

            TablaCabDetalle3.CompleteRow();

            for (int i = 0; i < ArrayTitulos2.Length; i++)
            {
                cell = new PdfPCell(new Paragraph(ArrayTitulos2[i], FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle3.AddCell(cell);
            }

            TablaCabDetalle3.CompleteRow();

            for (int i = 0; i < oEntidad.oListaCategoria.Count; i++)
            {
                cell = new PdfPCell(new Paragraph(oEntidad.oListaCategoria[i].idCategoria.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle3.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaCategoria[i].desCategoria.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle3.AddCell(cell);
                
            }
            TablaCabDetalle3.CompleteRow();

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle3.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle3.AddCell(cell);

            TablaCabDetalle3.CompleteRow();

            document.Add(TablaCabDetalle3);


            PdfPTable TablaCabDetalle4 = new PdfPTable(3);
            TablaCabDetalle4.WidthPercentage = 60;
            TablaCabDetalle4.SetWidths(ArrayColumnas3);




            cell = new PdfPCell(new Paragraph(" Criterio Subjetivo ", FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle4.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle4.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle4.AddCell(cell);
            TablaCabDetalle4.CompleteRow();

            for (int i = 0; i < ArrayTitulos3.Length; i++)
            {
                cell = new PdfPCell(new Paragraph(ArrayTitulos3[i], FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle4.AddCell(cell);
            }
            TablaCabDetalle4.CompleteRow();

            Decimal Criterio = 0;

            for (int i = 0; i < oEntidad.oListaCriterio.Count; i++)
            {
                cell = new PdfPCell(new Paragraph(oEntidad.oListaCriterio[i].idParTabla.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle4.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaCriterio[i].desParTabla.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle4.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaCriterio[i].Comision.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle4.AddCell(cell);

                Criterio = Criterio + oEntidad.oListaCriterio[i].Comision;

            }

            TablaCabDetalle4.CompleteRow();


            


            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle4.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle4.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Criterio.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle4.AddCell(cell);

            TablaCabDetalle4.CompleteRow();

            document.Add(TablaCabDetalle4);



            PdfPTable TablaCabDetalle5 = new PdfPTable(6);
            TablaCabDetalle5.WidthPercentage = 60;
            TablaCabDetalle5.SetWidths(ArrayColumnas4);

            cell = new PdfPCell(new Paragraph(" Linea Por Categoria ", FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            TablaCabDetalle5.CompleteRow();

            Decimal Tot1=0, Tot2=0, Tot3=0, Tot4=0;
            Decimal Sub1 = 0, Sub2 = 0, Sub3 = 0, Sub4 = 0;
            Int32 Ingresa = 0;


            for (int i = 0; i < oEntidad.oListaLinea.Count; i++)
            {
                if (Ingresa != oEntidad.oListaLinea[i].idCategoria)
                {
                    if (Ingresa != 0)
                    {
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle5.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Sub-Total:", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle5.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Sub1.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle5.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Sub2.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle5.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle5.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Sub4.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle5.AddCell(cell);

                        TablaCabDetalle5.CompleteRow();

                    }

                    for (int J = 0; J < ArrayTitulos4.Length; J++)
                    {
                        cell = new PdfPCell(new Paragraph(ArrayTitulos4[J], FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_MIDDLE };
                        TablaCabDetalle5.AddCell(cell);
                    }
                 TablaCabDetalle5.CompleteRow();
                 Ingresa = oEntidad.oListaLinea[i].idCategoria;
                 Sub1 = Sub2 = Sub3 = Sub4 = 0;
                }

                cell = new PdfPCell(new Paragraph(oEntidad.oListaLinea[i].idLinea.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle5.AddCell(cell);
          
                cell = new PdfPCell(new Paragraph(oEntidad.oListaLinea[i].desLinea.ToString(), FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaLinea[i].Meta.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaLinea[i].Resultado.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaLinea[i].Porcentaje.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaLinea[i].Pago.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                Sub1 = Sub1 + oEntidad.oListaLinea[i].Meta;
                Sub2 = Sub2 + oEntidad.oListaLinea[i].Resultado;
                Sub3 = Sub3 + oEntidad.oListaLinea[i].Porcentaje;
                Sub4 = Sub4 + oEntidad.oListaLinea[i].Pago;

                Tot1 = Tot1 + oEntidad.oListaLinea[i].Meta;
                Tot2 = Tot2 + oEntidad.oListaLinea[i].Resultado;
                Tot3 = Tot3 + oEntidad.oListaLinea[i].Porcentaje;
                Tot4 = Tot4 + oEntidad.oListaLinea[i].Pago;

            }

            TablaCabDetalle5.CompleteRow();

            // SubTotales
            if (Ingresa != 0)
            {
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Sub-Total:", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Sub1.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Sub2.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Sub4.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle5.AddCell(cell);

                TablaCabDetalle5.CompleteRow();

            }

            // Totales

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Totales:", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Tot1.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Tot2.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Tot4.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            TablaCabDetalle5.CompleteRow();


            Decimal TotGral = Tot4 + Criterio;

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Total Comision:", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            cell = new PdfPCell(new Paragraph(TotGral.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle5.AddCell(cell);

            TablaCabDetalle5.CompleteRow();


            document.Add(TablaCabDetalle5);




            PdfPTable TablaCabDetalle6 = new PdfPTable(5);
            TablaCabDetalle6.WidthPercentage = 60;
            TablaCabDetalle6.SetWidths(ArrayColumnas5);

            cell = new PdfPCell(new Paragraph(" Tarifario ", FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle6.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle6.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle6.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle6.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
            TablaCabDetalle6.AddCell(cell);

            TablaCabDetalle6.CompleteRow();


            Ingresa = 0;


            for (int i = 0; i < oEntidad.oListaTarifario.Count; i++)
            {
                if (Ingresa != oEntidad.oListaTarifario[i].idCategoria)
                {
                    for (int j = 0; j < ArrayTitulos5.Length; j++)
                    {
                        cell = new PdfPCell(new Paragraph(ArrayTitulos5[j], FontFactory.GetFont("Arial", 5f, BaseColor.WHITE))) { BackgroundColor = BaseColor.GRAY, HorizontalAlignment = Element.ALIGN_MIDDLE };
                        TablaCabDetalle6.AddCell(cell);
                    }
                    TablaCabDetalle6.CompleteRow();
                    Ingresa = oEntidad.oListaTarifario[i].idCategoria;
                }

                cell = new PdfPCell(new Paragraph(oEntidad.oListaTarifario[i].idComisionTarifario.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle6.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaTarifario[i].RangoIni.ToString(), FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle6.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaTarifario[i].RangoFin.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle6.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaTarifario[i].Factor.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle6.AddCell(cell);

                cell = new PdfPCell(new Paragraph(oEntidad.oListaTarifario[i].Comision.ToString(), FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle6.AddCell(cell);
            }

            TablaCabDetalle6.CompleteRow();


           

            document.Add(TablaCabDetalle6);
            #endregion
        }
        #endregion

    }

}



#endregion