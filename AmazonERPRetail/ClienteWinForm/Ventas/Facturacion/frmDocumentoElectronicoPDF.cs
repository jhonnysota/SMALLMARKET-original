using System;
using System.Drawing;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;
using ClienteWinForm;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmDocumentoElectronicoPDF : FrmMantenimientoBase
    {

        #region Constructores

        public frmDocumentoElectronicoPDF()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmDocumentoElectronicoPDF(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero, String tipotit)
            : this()
        {
            DocumentoPrevio = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);

            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            Titulo = tipotit;
        }

        #endregion

        #region Variables
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        EmisionDocumentoE DocumentoPrevio = null;
        String Titulo = String.Empty;
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        String RutaGeneral;
        //EmpresaImagenesE oEmpresaImagen = null;
        String RutaImagen = @"C:\AmazonErp\Logo\";

        #endregion

        private void frmRetencionImprimir_Load(object sender, EventArgs e)
        {
            try
            {
                Location = new Point(0, 0);
                Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

                if (DocumentoPrevio.ListaItemsDocumento != null && DocumentoPrevio.ListaItemsDocumento.Count > 0)
                {
                    Global.QuitarReferenciaWebBrowser(wbNavegador);

                    //Para la creación de la carpeta donde se van a grabar los recibos por retenciones
                    String Anio = DocumentoPrevio.fecEmision;  //Por revisar
                    String Mes = "";  //Por revisar Global.PrimeraMayuscula(FechasHelper.NombreMes(DocumentoPrevio.fecEmision.Month));
                    String RutaCopiaArchivos = @"C:\AmazonErp\Comprobantes Electronicos\" + Anio + @"\" + Mes + @"\";
                    String NombreReporte = "Documento Electronico";
                    String Extension = ".pdf";
                    //Documento PDF
                    Document docPdf = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                    //PdfPCell cell = null;
                    RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

                    //Creando el directorio si no existe...
                    if (!Directory.Exists(RutaGeneral))
                    {
                        Directory.CreateDirectory(RutaGeneral);
                    }

                    //Creando el directorio para las copias de los archivos, si en caso no exista...
                    if (!Directory.Exists(RutaCopiaArchivos))
                    {
                        Directory.CreateDirectory(RutaCopiaArchivos);
                    }

                    docPdf.AddCreationDate();
                    docPdf.AddAuthor("AMAZONTIC SAC");
                    docPdf.AddCreator("AMAZONTIC SAC");

                    if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
                    {
                        String TituloGeneral = String.Empty;

                        //Para la creacion del archivo pdf
                        RutaGeneral += NombreReporte + Extension;
                        RutaCopiaArchivos += NombreReporte + Extension;

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

                        int Columnas = 9;
                        float[] ArrayColumnas = new float[] { 0.1f, 0.15f, 0.4f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f };
                        int WidthPercentage = 100;

                        PaginaInicioMantenimientoReporteDocPDF ev = new PaginaInicioMantenimientoReporteDocPDF();
                        
                        ev.Columnas = Columnas;
                        ev.ArrayColumnas = ArrayColumnas;
                        //ev.ArrayTitulos = ArrayTitulos;
                        ev.Imagen = RutaImagen;
                        ev.WidthPercentage = WidthPercentage;
                        ev.oEntidad = DocumentoPrevio;
                        ev.titulo = Titulo;
                        oPdfw.PageEvent = ev;

                        docPdf.Open();

                        #region Detalle

                        PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                        TablaCabDetalle.WidthPercentage = WidthPercentage;
                        TablaCabDetalle.SetWidths(ArrayColumnas);

                        for (int i = 0; i < DocumentoPrevio.ListaItemsDocumento.Count; i++)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].Item, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].codArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].desUMedida, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, -1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].PrecioConImpuesto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].PrecioSinImpuesto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].CantidadUnit.Value.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].Dscto1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].Total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 2));

                            TablaCabDetalle.CompleteRow();

          
                        }

                        #region  Espacios En Blanco 

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 1)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 2)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 3)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 4)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 5)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 6)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 7)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 8)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 9)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 10)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 11)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 12)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 13)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 14)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 15)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 16)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 17)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 18)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 19)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 20)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 21)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 22)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 23)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        if (DocumentoPrevio.ListaItemsDocumento.Count == 24)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S9"));
                        }

                        #endregion

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SON :", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S9"));

                        docPdf.Add(TablaCabDetalle);



                        PdfPTable TablaCabDetalle2 = new PdfPTable(3);
                        TablaCabDetalle2.WidthPercentage = WidthPercentage;
                        TablaCabDetalle2.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("NO SE ACEPTAN DEVOLUCIONES", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1,"N","N",2,2,"S","N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("CANCELADO/CANJEADO", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "S", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" SUB TOTAL           ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "S", "N"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("DESPUES DE 48 HORAS DE HABER", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("LIMA...... de ....................del 20....", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("TOTAL OP. INAFECTA", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1 ,"N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("RECIBIDO LA MERCADERIA.", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" TOTAL OP. GRAVADA", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(".............................", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" IGV ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("SI LA FACTURA NO ES CANCELADA", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("p.JAS IMPORTACIONES S.A.C.", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" IMPORTE TOTAL", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("DENTRO DEL PLAZO INDICADO, SE", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("PROCEDERA A COBRAR INTERESES", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("DEL 1.5% DIARIO DEL VALOR TOTAL.", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "S"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 0,"N","N",2,2,"N","S"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "S"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1,"S3"));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("BANCO DEL CRÉDITO DEL PERU", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("BANCO SCOTIABANK", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1,"N","N",2,2,"S","N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Cta.Cte ME US$ 192-2015569-1-91", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Cta.Cte. ME US$ 000-3180141", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("CCI 002-193-002015569 191-16", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("CCI 009-231-000003180141-28", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Cta.Cte.ME S/ 193-2023016-0-04", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Cta. Cte. MN S/. 000-5610494", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("CCI 002-193-002023016004-14", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("CCI 009-231-000005610494-26", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Swift:BCPLPEPL", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Swift:BSUDPEPL", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Direccion del Banco", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Dirección del Banco:", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        TablaCabDetalle2.CompleteRow();

                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Centenario 156-La Molina 15026,Perú", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Av.Dionisio Derteano 102, San Isidro Lima 27,Perú", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1,"N","N",2,2,"N","S"));
                        TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        TablaCabDetalle2.CompleteRow();

                        docPdf.Add(TablaCabDetalle2);
                        //Añadiendo la tabla al documento PDF

                        #endregion

                        // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                        PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                        //establecer la acción abierta para nuestro objeto escritor
                        oPdfw.SetOpenAction(action);

                        //Liberando memoria
                        oPdfw.Flush();
                        docPdf.Close();
                        fsNuevoArchivo.Close();

                        //Copiando el archivo a otro directorio
                        if (File.Exists(RutaGeneral))
                        {
                            File.Copy(RutaGeneral, RutaCopiaArchivos, true);
                        }

                        //Mostrando el archivos en el navegador y limpiando la variable ruta general
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

class PaginaInicioMantenimientoReporteDocPDF : PdfPageEventHelper
{
    public String Imagen { get; set; }
    public int Columnas { get; set; }
    public float[] ArrayColumnas { get; set; }
    public String[] ArrayTitulos { get; set; }
    public int WidthPercentage { get; set; }
    public String titulo { get; set; }    
    public EmisionDocumentoE oEntidad { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        //PdfPCell cell = null;
        BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
        PdfPCell cell = null;
        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);
        String TITNom = String.Empty;

        table.WidthPercentage = 100;
        table.SetWidths(new float[] {0.6f,0.05f, 0.35f });

        if (titulo == "F")
        {
            TITNom = "FACTURA ELECTRÓNICA";
        }
        if (titulo == "B")
        {
            TITNom = "BOLETA DE VENTA ELECTRÓNICA";
        }
        if (titulo == "NC")
        {
            TITNom = "NOTA DE CRÉDITO ELECTRÓNICA";
        }
        if (titulo == "ND")
        {
            TITNom = "NOTA DE DÉBITO ELECTRÓNICA";
        }

        #region Titulos Principales

        PdfPCell NuevaCeldaImagen = ReaderHelper.ImagenCell(Imagen, 85, 4, Variables.NO, 0); //Imagen de Ventura
        NuevaCeldaImagen.Rowspan = 4;
        table.AddCell(NuevaCeldaImagen);

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 15.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1, 2));
        table.AddCell(ReaderHelper.NuevaCelda("R.U.C. N° " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "S", null, FontFactory.GetFont("Arial", 13.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1, 5, "S", "N"));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "N","S2"));
        table.AddCell(ReaderHelper.NuevaCelda(TITNom, null, "S", null, FontFactory.GetFont("Arial", 13.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1, 2, "N", "N"));
        table.CompleteRow();
        
        table.AddCell(ReaderHelper.NuevaCelda("N° " + oEntidad.numSerie + "-" + oEntidad.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 13.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1, 2,"N","N"));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 15.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1, 2, "N", "N","N","N"));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 13.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1, 5, "N", "S"));
        table.CompleteRow();

        //Linea en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f, iTextSharp.text.Font.NORMAL), 1, 1, "S3"));
        table.CompleteRow();

        document.Add(table);

        PdfPTable table2 = new PdfPTable(4);

        table2.WidthPercentage = 100;
        table2.SetWidths(new float[] { 0.15f, 0.35f, 0.15f,0.35f });

        //Subtitulos
        table2.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),-1,-1,"S3", "N",2,2,"S","N","S","S"));
        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
        table2.CompleteRow();

        table2.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RUC, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S3","N",2,2,"N","N","S","S"));
        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
        table2.CompleteRow();

        table2.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3","N",2,2,"N","S","S","S"));
        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
        table2.CompleteRow();

        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
        table2.CompleteRow();

        table2.AddCell(ReaderHelper.NuevaCelda("Nombre/RazonSocial: ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),-1,-1,"N","N",2,2,"S","N","N","S"));
        table2.AddCell(ReaderHelper.NuevaCelda(oEntidad.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "S", "N", "S", "N"));
        table2.AddCell(ReaderHelper.NuevaCelda("RUC: ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 2, 2, "S", "N", "N", "S"));
        table2.AddCell(ReaderHelper.NuevaCelda(oEntidad.Ruc, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "S", "N", "S", "N"));
        table2.CompleteRow();

        table2.AddCell(ReaderHelper.NuevaCelda("Dirección: ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),-1,-1,"N","N",2,2,"N","N","N","S"));
        table2.AddCell(ReaderHelper.NuevaCelda(oEntidad.Direccion, null, "S", null, FontFactory.GetFont("Arial", 7.25f),-1,-1,"N","N",2,2,"N","N","S","N"));
        table2.AddCell(ReaderHelper.NuevaCelda("Fecha Emisión: ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),-1,-1,"N","N",2,2,"N","N","N","S"));
        //Por revisar//table2.AddCell(ReaderHelper.NuevaCelda(oEntidad.fecEmision.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 7.25f),-1,-1,"N","N",2,2,"N","N","S","N"));
        table2.CompleteRow();

        table2.AddCell(ReaderHelper.NuevaCelda("Moneda: ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),-1,-1,"N","N",2,2,"N","S","N","S"));
        table2.AddCell(ReaderHelper.NuevaCelda(oEntidad.desMoneda, null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),-1,-1,"N","N",2,2,"N","S","S","N"));
        table2.AddCell(ReaderHelper.NuevaCelda("", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),-1,-1,"N","N",2,2,"N","S","N","N"));
        table2.AddCell(ReaderHelper.NuevaCelda("", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 2, 2, "N", "S", "S", "N"));
        table2.CompleteRow();

        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
        table2.CompleteRow();

        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
        table2.CompleteRow();

        #endregion

        document.Add(table2); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        if (Columnas > 0)
        {
            PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
            TablaCabDetalle.WidthPercentage = WidthPercentage;
            TablaCabDetalle.SetWidths(ArrayColumnas);


            #region Segunda Linea

            cell = new PdfPCell(new Paragraph("Item", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Código", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Descripción", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Und.", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Cantidad", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("V.Unitario", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("P.Unitario", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Descuento", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Valor Venta", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            TablaCabDetalle.CompleteRow();

            #endregion

            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
        }

        #endregion

    }
}

#endregion