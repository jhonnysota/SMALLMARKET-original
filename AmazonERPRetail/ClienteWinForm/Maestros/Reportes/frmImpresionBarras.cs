using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Maestros.Reportes
{
    public partial class frmImpresionBarras : FrmMantenimientoBase
    {

        #region Constructores

        public frmImpresionBarras()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmImpresionBarras(List<ArticuloServE> oArtServ_)
            :this()
        {
            oListadoArticulos = oArtServ_;
        } 

        #endregion

        #region Variables

        List<ArticuloServE> oListadoArticulos = null;
        ArticuloServE ItemArticulo = null;
        String RutaGeneral;

        #endregion

        #region Procedimientos de Usuario

        void MostrarReportePDF(List<ArticuloServE> Listado)
        {
            //BaseColor colCabDetalle = BaseColor.LIGHT_GRAY;
            BaseColor ColorFondo = new BaseColor(219, 219, 219); //Gris Claro
            //Letra, Tamaño, Negrita, Color de letra
            //Font Letra = FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
            //Valores por defecto letra normal y color negro
            iTextSharp.text.Font Letra = FontFactory.GetFont("Arial", 6.25f);
            iTextSharp.text.Font LetraBarras = FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD);

            //Document docPdf = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            //Document docPdf = new Document();

            //Document docPdf = new Document(new iTextSharp.text.Rectangle(1, 1, 260, 275, 0));
            var pgSize = new iTextSharp.text.Rectangle(595, 842);
            Document docPdf = new Document(pgSize, 1, 1, 1, 1);

            Guid newGuid = Guid.NewGuid();
            String NombreReporte = @"\Articulos " + newGuid.ToString();
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            docPdf.AddCreationDate();
            docPdf.AddAuthor("AMAZONTIC SAC");
            docPdf.AddCreator("AMAZONTIC SAC");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
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

                //oPdfw.AddViewerPreference(PdfName.PICKTRAYBYPDFSIZE, PdfBoolean.PDFTRUE);

                oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                if (docPdf.IsOpen())
                {
                    docPdf.CloseDocument();
                }

                docPdf.Open();

                #endregion

                PdfPTable tableDetalle = new PdfPTable(1);

                tableDetalle.WidthPercentage = 100;
                //tableDetalle.SetWidths(new float[] { 0.015f, 0.06f });
                //tableDetalle.HorizontalAlignment = Element.ALIGN_LEFT;
                System.Drawing.Image oImg = null;

                foreach (ArticuloServE item in oListadoArticulos)
                {
                    ////Primera Linea
                    //tableDetalle.AddCell(ReaderHelper.NuevaCelda("Articulo", ColorFondo, "S", null, Letra, 5, 0, "N", "N",2f, 2f, "S", "N", "S", "S"));
                    //tableDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomCorto, null, "S", null, Letra, 5, 1, "N", "N", 2f, 2f, "S", "N", "S", "S"));
                    //tableDetalle.CompleteRow();

                    //Segunda Linea
                    //tableDetalle.AddCell(ReaderHelper.NuevaCelda("Cód. Barras", ColorFondo, "S", null, Letra, 5, 0, "N", "N", 2f, 2f, "S", "N", "S", "S"));
                    //Convirtiendo a Code 128
                    oImg = ReaderHelper.Code128(String.Format("Articulo {0}", item.codBarra) + item.codBarra, (int)ReaderHelper.TiposCode128.CODE128, true, 43);

                    //Revisando si no hay nada
                    if (oImg != null)
                    {
                        tableDetalle.AddCell(ReaderHelper.ImagenCellPorcentaje(oImg, 1, 0f, "S"));
                    }
                    else
                    {
                        tableDetalle.AddCell(ReaderHelper.NuevaCelda("NO TIENE", null, "S", null, LetraBarras, 5, 1, "N", "N", 4f, 3f));
                    }

                    tableDetalle.CompleteRow();

                    ////Tercera Linea
                    //tableDetalle.AddCell(ReaderHelper.NuevaCelda("Código", ColorFondo, "S", null, Letra, 5, 0, "N", "N", 2f, 2f));
                    //tableDetalle.AddCell(ReaderHelper.NuevaCelda(String.IsNullOrEmpty(item.codBarra.Trim()) ? "NO TIENE" : item.codBarra, null, "S", null, Letra, 5, 1, "N", "N", 2f, 2f));
                    //tableDetalle.CompleteRow();

                    //Linea en Blanco
                    //tableDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, Letra, 5, 1, "S2"));
                    //tableDetalle.CompleteRow();
                }

                docPdf.Add(tableDetalle);

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

        #endregion

        #region Eventos

        private void frmListadosArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
                Location = new Point(0, 0);
                Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

                //if (oListadoArticulos != null && oListadoArticulos.Count > 0)
                //{
                //    MostrarReportePDF(oListadoArticulos);
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Image oImg = null;
            System.Drawing.Font fTit0 = new System.Drawing.Font("Consolas", 7.25f, FontStyle.Bold);
            System.Drawing.Font fTit1 = new System.Drawing.Font("Consolas", 15.25f, FontStyle.Bold);
            System.Drawing.Font fTit2 = new System.Drawing.Font("Consolas", 18, FontStyle.Bold);
            System.Drawing.Font fTArti = new System.Drawing.Font("Consolas", 9, FontStyle.Bold);
            string NombreArticulo = String.Empty;

            using (SolidBrush sb = new SolidBrush(Color.Black))
            {
                using (Graphics g = e.Graphics)
                {
                    g.PageUnit = GraphicsUnit.Millimeter;
                    oImg = ReaderHelper.Code128(ItemArticulo.codArticulo, (int)ReaderHelper.TiposCode128.CODE128, true, 34);

                    g.DrawString("320", fTit1, sb, 1.5f, 0); //1
                    g.DrawString("320", fTit1, sb, 54.5f, 0); //2

                    g.DrawString(ItemArticulo.desMaterial, fTit1, sb, 12.7f, 0); //1
                    g.DrawString(ItemArticulo.desMaterial, fTit1, sb, 65f, 0); //2

                    g.DrawString(ItemArticulo.desColor, fTit0, sb, 16, 0.8f); //1
                    g.DrawString(ItemArticulo.desColor, fTit0, sb, 68.3f, 0.8f); //2

                    g.DrawString("03/04/2018", fTit0, sb, 16, 2.8f); //1
                    g.DrawString("03/04/2018", fTit0, sb, 68.3f, 2.8f); //2

                    g.DrawString("42", fTit2, sb, 39, 0); //1
                    g.DrawString("42", fTit2, sb, 91.3f, 0); //2

                    if (ItemArticulo.nomArticuloLargo.Length > 26)
                    {
                        NombreArticulo = ItemArticulo.nomArticuloLargo.Substring(0, 26);
                    }
                    else
                    {
                        NombreArticulo = ItemArticulo.nomArticuloLargo;
                    }

                    g.DrawString(NombreArticulo, fTArti, sb, 1.5f, 6); //1
                    g.DrawString(NombreArticulo, fTArti, sb, 55, 6); //2

                    g.DrawImage(oImg, 4, 10);
                    g.DrawImage(oImg, 60, 10);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<ArticuloServE> oListaTemp = new List<ArticuloServE>();

                oListaTemp.AddRange(oListadoArticulos);
                oListaTemp.AddRange(oListadoArticulos);
                oListaTemp.AddRange(oListadoArticulos);

                foreach (ArticuloServE item in oListaTemp)
                {
                    ItemArticulo = item;

                    PrintDocument printDocument1 = new PrintDocument();
                    PaperSize psize = new PaperSize("", 720, 90); // Tamaño de la Hoja

                    printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                    printDocument1.PrintController = new StandardPrintController();
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    printDocument1.DefaultPageSettings.Margins.Top = 0;
                    printDocument1.DefaultPageSettings.Margins.Bottom = 0;

                    printDocument1.DefaultPageSettings.PaperSize = psize;
                    printDocument1.Print(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

    }
}
