using Entidades.Ventas;
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

namespace ClienteWinForm.Ventas.Comisiones
{
    public partial class frmImpresionComisionesconfiguracion : FrmMantenimientoBase
    {
        public frmImpresionComisionesconfiguracion()
        {
            InitializeComponent();
        }

        // ========================
        // CONSTRUCTOR
        // ========================

        public frmImpresionComisionesconfiguracion(ComisionesConfiguracionE oenti_,List<ComisionesConfiguracionE> oListaVend, List<ComisionesConfiguracionE> oListaCrit, List<ComisionesConfiguracionE> oListaTar, List<ComisionesConfiguracionE> oListaLin, List<ComisionesConfiguracionE> oListaCat)
            :this()
        {
            oEntidad = oenti_;
            oListaCategoria = oListaCat;
            oListaLinea = oListaLin;
            oListaTarifario = oListaTar;
            oListaCriterio = oListaCrit;
            oListaVendedor = oListaVend;
        }

        ComisionesConfiguracionE oEntidad;

        List<ComisionesConfiguracionE> oListaCategoria = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaLineaGeneral = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaLinea = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaTarifarioGeneral = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaTarifario = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaCriterio = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaVendedor = new List<ComisionesConfiguracionE>();
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        string RutaGeneral = string.Empty;
        String RutaTemp = String.Empty;
 
        private void frmImpresionComisionesconfiguracion_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            oListaLineaGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "linea");
            oListaTarifarioGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "tarifario");
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
            ConvertirApdf();
        }




        #region crear PDF

        void ConvertirApdf()
        {


            // =============================================================================

            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            String NombreReporte = @"\ImpresionesConfiguracion" + oEntidad.NombreZona;
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";
            //String RutaImagen = @"C:\AmazonErp\Logo\Logo.png";

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

                    TituloGeneral = "Comisiones Configuracion Con Nombre del Vendedor: " + oEntidad.desPersona;

                String SubTitulo = String.Empty;
                PdfPCell cell = null;

                #region Config

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

                docPdf.Open();

                #endregion

                DateTime FechaActual = VariablesLocales.FechaHoy.Date;
                int size = 8;

                PdfPTable tabletit = new PdfPTable(3);

                tabletit.WidthPercentage = 100;
                tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                tabletit.HorizontalAlignment = Element.ALIGN_CENTER;


                cell = CellPdf(" ", size, false, "", "");
                tabletit.AddCell(cell);
                cell = CellPdf("CALCULO DE COMISIONES", 15, false, "", "bold");
                tabletit.AddCell(cell);
                cell = CellPdf(" ", size, false, "", "");
                tabletit.AddCell(cell);
                tabletit.CompleteRow();

                foreach (ComisionesConfiguracionE item in oListaVendedor)
                {

                    cell = CellPdf(item.desPersona, 12, false, "", "bold");
                    tabletit.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    tabletit.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    tabletit.AddCell(cell);
                    tabletit.CompleteRow();
                }
                docPdf.Add(tabletit);


                PdfPTable table = new PdfPTable(5);

                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 0.2f, 0.3f, 0.3f,0.3f,0.5f });
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                int idCategoriaSeleccionada = 0;
                int idCategoriaSeleccionada1 = 0;
                decimal meta = 0;
                decimal resultado = 0;
                decimal cumplimiento = 0;
                decimal comision = 0;
                // ===========================================

            


                foreach (ComisionesConfiguracionE item2 in oListaCategoria)
                {                  


                    cell = CellPdf(" Categoria: ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(item2.idCategoria.ToString() + "    " + item2.desCategoria, size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    table.CompleteRow();

                    cell = CellPdf(" Linea", size, true, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" Meta en 9L", size, true, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" Resultado", size, true, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" Cumplimiento", size, true, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" Comision Asociada Segun Acuerdo", size, true, "", "");
                    table.AddCell(cell);
                    table.CompleteRow();

                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    table.CompleteRow();

                    idCategoriaSeleccionada = item2.idCategoria;
                    oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();
                    oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();
                    foreach (ComisionesConfiguracionE item in oListaLinea)
                    {
                        

                        cell = CellPdf(item.desLinea, size, false, "c", "");
                        table.AddCell(cell);
                        cell = CellPdf(item.Meta.ToString("N2"), size, false, "r", "");
                        table.AddCell(cell);
                        cell = CellPdf(item.Resultado.ToString("N2"), size, false, "r", "");
                        table.AddCell(cell);
                        cell = CellPdf(item.Porcentaje.ToString("N2"), size, false, "r", "");
                        table.AddCell(cell);
                        cell = CellPdf(item.Pago.ToString("N2"), size, false, "r", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        comision += item.Pago;
                        meta += item.Meta;
                        resultado += item.Resultado;
                        cumplimiento += item.Porcentaje;

                    }
                    idCategoriaSeleccionada1++;

                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf("_______________", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf("_______________", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf("_____________________", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf("______________________________", size, false, "", "");
                    table.AddCell(cell);
                    table.CompleteRow();
                    
                    cell = CellPdf("Total", size, false, "c", "bold");
                        table.AddCell(cell);
                        cell = CellPdf(meta.ToString(), size, false, "r", "bold");
                        table.AddCell(cell);
                        cell = CellPdf(resultado.ToString(), size, false, "r", "bold");
                        table.AddCell(cell);
                        cell = CellPdf(cumplimiento.ToString() + "%", size, false, "r", "bold");
                        table.AddCell(cell);
                        cell = CellPdf(comision.ToString(), size, false, "r", "bold");
                        table.AddCell(cell);
                        table.CompleteRow();
                        idCategoriaSeleccionada1++;
                }


                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                table.CompleteRow();

                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                cell = CellPdf("Elementos Subjetivos ", size, true, "c", "");
                table.AddCell(cell);
                cell = CellPdf(" ", size, false, "", "");
                table.AddCell(cell);
                table.CompleteRow();

                foreach (ComisionesConfiguracionE item in oListaCriterio)
                {

                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(item.desParTabla, size, true, "c", "");
                    table.AddCell(cell);
                    cell = CellPdf(item.Comision.ToString("N2"), size, false, "r", "");
                    table.AddCell(cell);
                    table.CompleteRow();

                    comision += item.Comision;

                }


                foreach (ComisionesConfiguracionE item in oListaVendedor)
                {
                    cell = CellPdf(" ", size, false, "c", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "c", "");
                    table.AddCell(cell);
                    cell = CellPdf("Total comision", size, true, "c", "");
                    table.AddCell(cell);
                    cell = CellPdf(item.desPersona, size, true, "c", "");
                    table.AddCell(cell);
                    cell = CellPdf(comision.ToString("N2"), size, false, "r", "bold");
                    table.AddCell(cell);
                    table.CompleteRow();
                }


                docPdf.Add(table);
                // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                //establecer la acción abierta para nuestro objeto escritor
                oPdfw.SetOpenAction(action);

                //Liberando memoria
                oPdfw.Flush();
                docPdf.Close();
                fsNuevoArchivo.Close();
                wbNavegador.Navigate(RutaGeneral);
            }
        }

        PdfPCell CellPdf(string titulo, int size, Boolean border, string align, string bold)
        {
            if (!border)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { Border = 0, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        #endregion


        #region excel

        public override void Exportar()
        {
            try
            {
                if (oEntidad == null )
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }
                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Calculo de Comisiones" , "Archivos Excel (*.xlsx)|*.xlsx");

                ExportarExcel(RutaGeneral);
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



            TituloGeneral = " Calculo de Comisiones ";
            NombrePestaña = " Comisiones Configuracion ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 5;
                    Int32 TotColumnas = 5;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    foreach (ComisionesConfiguracionE item in oListaVendedor)
                    {
                        oHoja.Cells["A3"].Value = item.desPersona;

                        using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                        }
                    }

                    #endregion

                    #region Cabeceras del Detalle


                    int idCategoriaSeleccionada = 0;
                    int idCategoriaSeleccionada1 = 0;
                    decimal meta = 0;
                    decimal resultado = 0;
                    decimal cumplimiento = 0;
                    decimal comision = 0;



                    foreach (ComisionesConfiguracionE item2 in oListaCategoria)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = " Categoria: ";
                        oHoja.Cells[InicioLinea, 2].Value = item2.idCategoria;
                        oHoja.Cells[InicioLinea, 3].Value = " ";
                        oHoja.Cells[InicioLinea, 4].Value = " ";
                        oHoja.Cells[InicioLinea, 5].Value = " ";
                        oHoja.Cells[InicioLinea, 1, InicioLinea, 2].Style.Font.Bold = true;
                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 1].Value = " Linea ";
                        oHoja.Cells[InicioLinea, 2].Value = " Meta en 9L";
                        oHoja.Cells[InicioLinea, 3].Value = " Resultado ";
                        oHoja.Cells[InicioLinea, 4].Value = " Cumplimiento ";
                        oHoja.Cells[InicioLinea, 5].Value = " Comision Asociada Segun Acuerdo";
                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 1].Value = " ";
                        oHoja.Cells[InicioLinea, 2].Value = " ";
                        oHoja.Cells[InicioLinea, 3].Value = " ";
                        oHoja.Cells[InicioLinea, 4].Value = " ";
                        oHoja.Cells[InicioLinea, 5].Value = " ";
                        InicioLinea++;

                        idCategoriaSeleccionada = item2.idCategoria;
                        oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();
                        oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();
                        foreach (ComisionesConfiguracionE item in oListaLinea)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.desLinea;
                            oHoja.Cells[InicioLinea, 2].Value = item.Meta.ToString("N2");
                            oHoja.Cells[InicioLinea, 3].Value = item.Resultado.ToString("N2");
                            oHoja.Cells[InicioLinea, 4].Value = item.Porcentaje.ToString("N2");
                            oHoja.Cells[InicioLinea, 5].Value = item.Pago.ToString("N2");

                            oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                            InicioLinea++;

                            comision += item.Pago;
                            meta += item.Meta;
                            resultado += item.Resultado;
                            cumplimiento += item.Porcentaje;
                        }
                        idCategoriaSeleccionada1++;

                            oHoja.Cells[InicioLinea, 1].Value = " ";
                            oHoja.Cells[InicioLinea, 2].Value = " ";
                            oHoja.Cells[InicioLinea, 3].Value = " ";
                            oHoja.Cells[InicioLinea, 4].Value = " ";
                            oHoja.Cells[InicioLinea, 5].Value = " ";
                            InicioLinea++;
                            oHoja.Cells[InicioLinea, 1].Value = "Total";
                            oHoja.Cells[InicioLinea, 2].Value = meta.ToString("N2");
                        oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 3].Value = resultado.ToString("N2");
                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 4].Value = cumplimiento.ToString("N2") + "%";
                        oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 5].Value = comision.ToString("N2");                                  
                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 2, InicioLinea,5].Style.Font.Bold = true;

                        InicioLinea++;
                            idCategoriaSeleccionada1++;

                        oHoja.Cells[InicioLinea, 1].Value = " ";
                        oHoja.Cells[InicioLinea, 2].Value = " ";
                        oHoja.Cells[InicioLinea, 3].Value = " ";
                        oHoja.Cells[InicioLinea, 4].Value = " ";
                        oHoja.Cells[InicioLinea, 5].Value = " ";
                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = "Elementos Subjetivos";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    InicioLinea++;

                    foreach (ComisionesConfiguracionE item in oListaCriterio)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = " ";
                        oHoja.Cells[InicioLinea, 2].Value = " ";
                        oHoja.Cells[InicioLinea, 3].Value = " ";
                        oHoja.Cells[InicioLinea, 4].Value = item.desParTabla;
                        oHoja.Cells[InicioLinea, 5].Value = item.Comision.ToString("N2");


                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                        comision += item.Comision;
                    }

                    foreach (ComisionesConfiguracionE item in oListaVendedor)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = " ";
                        oHoja.Cells[InicioLinea, 2].Value = " ";
                        oHoja.Cells[InicioLinea, 3].Value = "Total comision";
                        oHoja.Cells[InicioLinea, 4].Value = item.desPersona;
                        oHoja.Cells[InicioLinea, 5].Value = comision.ToString("N2");

                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;

                        InicioLinea++;
                    }

                    //Aumentando una Fila mas continuar con el detalle
                


                    #endregion


                    //FIN SUMATORIA //

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

    }
}
