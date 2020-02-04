using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmImpresionCanjeLetra : FrmMantenimientoBase
    {

        #region Constructores

        public frmImpresionCanjeLetra()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
            Font = new System.Drawing.Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        public frmImpresionCanjeLetra(List<LetrasCanjeUnionE> oListaLetras, String codCanje_)
            :this()
        {
            oListaLet = oListaLetras;
            codCanje = codCanje_;
        }

        #endregion

        #region Variables

        String RutaGeneral;
        String codCanje;
        List<LetrasCanjeUnionE> oListaLet = null;
        String RutaImagen = String.Empty; 

        #endregion

        private void frmImpresionCanjeLetra_Load(object sender, EventArgs e)
        {
            try
            {
                if (oListaLet != null)
                {
                    Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    String NombreReporte = @"\" + "_" + VariablesLocales.FechaHoy.Year.ToString() + "_" + VariablesLocales.FechaHoy.Month.ToString() + "_" + VariablesLocales.FechaHoy.Day.ToString() + "_" + VariablesLocales.FechaHoy.Hour.ToString() + "_" + VariablesLocales.FechaHoy.Minute.ToString();
                    String Extension = ".pdf";
                    RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";
                    Guid Aleatorio = Guid.NewGuid();
                    String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
                    String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
                    BaseColor ColorFondo = BaseColor.LIGHT_GRAY; //Gris Claro

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
                        
                        //Para la creacion del archivo pdf
                        RutaGeneral += NombreReporte + Extension;

                        if (File.Exists(RutaGeneral))
                        {
                            File.Delete(RutaGeneral);
                        }

                        TituloGeneral = " CANJE DE LETRA ";
                        
                        using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                            oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                            if (docPdf.IsOpen())
                            {
                                docPdf.CloseDocument();
                            }

                            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                            docPdf.Open();

                            PdfPTable tableEncabezado = new PdfPTable(2);
                            tableEncabezado.WidthPercentage = 100;
                            tableEncabezado.SetWidths(new float[] { 0.9f, 0.13f });

                            #region Encabezado

                            tableEncabezado.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                            tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                            tableEncabezado.CompleteRow(); //Fila completada

                            tableEncabezado.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                            tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                            tableEncabezado.CompleteRow(); //Fila completada

                            tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                            tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
                            tableEncabezado.CompleteRow(); //Fila completada

                            //Filas en blanco
                            tableEncabezado.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f), -1, -1, "S4"));
                            tableEncabezado.CompleteRow();

                            docPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                            #endregion Encabezado

                            PdfPTable tableTitulos = new PdfPTable(2);
                            tableTitulos.WidthPercentage = 100;
                            tableTitulos.SetWidths(new float[] { 0.03f, 0.2f });

                            #region Titulos Principales

                            PdfPCell CeldaImagen = null;

                            if (File.Exists(RutaImagen))
                            {
                                CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f));
                            }
                            else
                            {
                                CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                            }

                            tableTitulos.AddCell(CeldaImagen);
                            tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral.PadLeft(58, ' '), null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, -1, "N", "N", 13f, 13f));
                            tableTitulos.CompleteRow();

                            tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), 5, 1, "S2"));
                            tableTitulos.CompleteRow();

                            //Lineas en Blanco
                            tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                            String Subtitulo = " N° DE CANJE " + codCanje;
                            tableTitulos.AddCell(ReaderHelper.NuevaCelda(Subtitulo.PadLeft(58, ' '), null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, -1, "N", "N", 13f, 13f));
                            tableTitulos.CompleteRow();

                            tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2"));
                            tableTitulos.CompleteRow();

                            docPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                            #endregion Titulos Principales

                            #region Subtitulos

                            PdfPTable TablaDeta = new PdfPTable(12);
                            TablaDeta.WidthPercentage = 100;
                            TablaDeta.SetWidths(new float[] { 0.03f, 0.025f, 0.03f, 0.03f, 0.015f, 0.035f, 0.025f, 0.025f, 0.015f, 0.025f, 0.025f, 0.030f });

                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("ZONA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("VENDEDOR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("RUC", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("CLIENTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("TIPO DOC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("NÚMERO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("EMISIÓN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("VENC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("MONEDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("IMPORTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("SALDO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("STATUS", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                            TablaDeta.CompleteRow();

                            #endregion

                            #region Detalle

                            Int32 ItemCorre = 1;

                            foreach (LetrasCanjeUnionE item in oListaLet)
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.nomZona, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, -1));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.nomVendedor, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.ruc, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));

                                if (item.idDocumento == "LT")
                                {
                                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                                }
                                else
                                {
                                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numSerie + "-" + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                                }

                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.fecDocumento.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.fecVencimiento.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.NomMoneda, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Importe.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.SaldoDoc.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.EstadoDocumento, null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));

                                TablaDeta.CompleteRow();

                                ItemCorre++;
                            }

                            docPdf.Add(TablaDeta); //Añadiendo la tabla al documento PDF

                            #endregion

                            // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                            //establecer la acción abierta para nuestro objeto escritor
                            oPdfw.SetOpenAction(action);

                            //Liberando memoria
                            oPdfw.Flush();
                            docPdf.Close(); 
                        }

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

    }
}
