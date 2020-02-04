using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Generales;
using ClienteWinForm.Impresion;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteFacturaExportacion : FrmMantenimientoBase
    {
        #region Constructor

        public frmReporteFacturaExportacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            DocumentoPrevio = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);

            oEmpresaImagen = AgenteMaestro.Proxy.ObtenerEmpresaSinImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (!Directory.Exists(RutaImagen))
            {
                Directory.CreateDirectory(RutaImagen);
            }

            if (oEmpresaImagen != null)
            {
                RutaImagen += oEmpresaImagen.Nombre + Convert.ToString(VariablesLocales.SesionUsuario.Empresa.IdEmpresa) + oEmpresaImagen.Extension; ;

                if (!File.Exists(RutaImagen))
                {
                    oEmpresaImagen = AgenteMaestro.Proxy.ObtenerEmpresaConImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    if (oEmpresaImagen.Imagen != null)
                    {
                        Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, RutaImagen);
                    }
                    else
                    {
                        RutaImagen = String.Empty;
                    }
                }
            }
            else
            {
                RutaImagen = String.Empty;
            }
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        EmisionDocumentoE DocumentoPrevio = null;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        EmpresaImagenesE oEmpresaImagen = null;
        string RutaGeneral;

        #endregion

        #region Procedimientos de Usuario

        void LlenarDatos()
        {
            try
            {
                Location = new Point(0, 0);
                Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

                if (DocumentoPrevio.ListaItemsDocumento != null && DocumentoPrevio.ListaItemsDocumento.Count > 0)
                {
                    Global.QuitarReferenciaWebBrowser(wbNavegador);

                    //Para la creación de la carpeta donde se van a grabar los recibos por retenciones
                    String Anio = ""; // DocumentoPrevio.fecEmision.ToString("yyyy"); //Por revisar
                    String Mes = "";// Global.PrimeraMayuscula(FechasHelper.NombreMes(DocumentoPrevio.fecEmision.Month)); //Por revisar
                    String RutaCopiaArchivos = @"C:\AmazonErp\Comprobantes Electronicos\" + Anio + @"\" + Mes + @"\";
                    String NombreReporte = DocumentoPrevio.numSerie + "-" + DocumentoPrevio.numDocumento + " " + DocumentoPrevio.Ruc + " " + DocumentoPrevio.RazonSocial;
                    String Extension = ".pdf";
                    //Documento PDF
                    Document docPdf = new Document(PageSize.A4.Rotate(), 30f, 30f, 30f, 30f);
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

                        docPdf.Open();

                        #region Detalle

                        BaseColor ColorFondo = new BaseColor(249, 193, 53);
                        BaseColor ColorLetra = new BaseColor(80, 150, 30);
                        int Columnas = 3;
                        int WidthPercentage = 100;
                        PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                        TablaCabDetalle.WidthPercentage = WidthPercentage;
                        TablaCabDetalle.SetWidths(new float[] { 0.3f, 0.3f, 0.4f });


                        TablaCabDetalle.AddCell(ReaderHelper.ImagenCell(RutaImagen, 180, Element.ALIGN_CENTER, Variables.NO, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.Direccion + "-" + VariablesLocales.SesionUsuario.Empresa.Distrito + "-" + VariablesLocales.SesionUsuario.Empresa.Departamento + "-" + VariablesLocales.SesionUsuario.Empresa.Provincia + VariablesLocales.SesionUsuario.Empresa.Direccion + "-" + VariablesLocales.SesionUsuario.Empresa.Distrito + "-"
                                                + VariablesLocales.SesionUsuario.Empresa.Departamento + "-" + VariablesLocales.SesionUsuario.Empresa.Provincia + "Telefax: " + VariablesLocales.SesionUsuario.Empresa.sFax + " / " + VariablesLocales.SesionUsuario.Empresa.sTelefonos
                                                + "E-mail: " + VariablesLocales.SesionUsuario.Empresa.sEmail + " / " + VariablesLocales.SesionUsuario.Empresa.sEmailFe + VariablesLocales.SesionUsuario.Empresa.sWeb, null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra), 1, 1, "N", "N"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("R.U.C.  " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "S", ColorLetra, FontFactory.GetFont("Arial", 16f, ColorLetra), 1, 1, "S3", "N", 2, 2, "S", "N"));
                        TablaCabDetalle.CompleteRow();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FACTURA", ColorFondo, "S", ColorLetra, FontFactory.GetFont("Arial", 16f, ColorLetra), 1, 1, "N", "N", 2, 2, "N", "N"));
                        TablaCabDetalle.CompleteRow();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra), 1, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.numSerie + "-" + "  N° " + DocumentoPrevio.numDocumento, null, "S", ColorLetra, FontFactory.GetFont("Arial", 16f, ColorLetra), 1, 1, "N", "N", 2, 2, "N"));
                        TablaCabDetalle.CompleteRow();

                        docPdf.Add(TablaCabDetalle);

                        PdfPTable TablaCabDetalle2 = new PdfPTable(1);
                        TablaCabDetalle2.WidthPercentage = WidthPercentage;
                        TablaCabDetalle2.SetWidths(new float[] { 1f });
                        //Por revisar//TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Fecha, " + DocumentoPrevio.fecEmision.Day + " de " + Global.PrimeraMayuscula(FechasHelper.NombreMes(DocumentoPrevio.fecEmision.Month)) + " del " + DocumentoPrevio.fecEmision.ToString("yyyy"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra)));
                        TablaCabDetalle2.CompleteRow();
                        docPdf.Add(TablaCabDetalle2);


                        PdfPTable TablaCabDetalle3 = new PdfPTable(4);
                        TablaCabDetalle3.WidthPercentage = WidthPercentage;
                        TablaCabDetalle3.SetWidths(new float[] { 0.05f, 0.55f, 0.09f, 0.31f });

                        TablaCabDetalle3.AddCell(ReaderHelper.NuevaCelda("Señor(es): ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra)));
                        TablaCabDetalle3.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle3.AddCell(ReaderHelper.NuevaCelda("R.U.C. N°: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra)));
                        TablaCabDetalle3.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.Ruc, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle3.CompleteRow();

                        TablaCabDetalle3.AddCell(ReaderHelper.NuevaCelda("Dirección: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra)));
                        TablaCabDetalle3.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.Direccion, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle3.AddCell(ReaderHelper.NuevaCelda("Guia de Remisión: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra)));
                        TablaCabDetalle3.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.Guia, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle3.CompleteRow();

                        docPdf.Add(TablaCabDetalle3);

                        PdfPTable TablaCabDetalle4 = new PdfPTable(4);
                        TablaCabDetalle4.WidthPercentage = WidthPercentage;
                        TablaCabDetalle4.SetWidths(new float[] { 0.15f, 0.45f, 0.15f, 0.25f });

                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("CANT. ", ColorFondo, "S", ColorLetra, FontFactory.GetFont("Arial", 14f, ColorLetra), 1, 1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", ColorLetra, FontFactory.GetFont("Arial", 14f, ColorLetra), 1, 1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("P.UNIT. ", ColorFondo, "S", ColorLetra, FontFactory.GetFont("Arial", 14f, ColorLetra), 1, 1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("IMPORTE", ColorFondo, "S", ColorLetra, FontFactory.GetFont("Arial", 14f, ColorLetra), 1, 1));
                        TablaCabDetalle4.CompleteRow();


                        for (int i = 0; i < 10;)
                        {

                            if (DocumentoPrevio.ListaItemsDocumento.Count > i)
                            {
                                TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].Cantidad.ToString("N2"), null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "N"));
                                TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].nomArticulo, null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                                TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].PesoUnitario.Value.ToString("N2"), null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "N"));
                                TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.ListaItemsDocumento[i].PrecioSinImpuesto.ToString("N2"), null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "N"));
                            }
                            else
                            {
                                TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "N"));
                                TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 2, 2, "N", "N"));
                                TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "N"));
                                TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "N"));
                            }

                            TablaCabDetalle.CompleteRow();
                            i++;
                        }

                        String Total = NumeroLetras.enLetras(DocumentoPrevio.totTotal.ToString());

                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "S"));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "S"));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "S"));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2, "N", "S"));
                        TablaCabDetalle4.CompleteRow();

                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.CompleteRow();

                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("SON: ", null, "N", null, FontFactory.GetFont("Arial", 14f, ColorLetra), -1, -1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(Total, null, "N", null, FontFactory.GetFont("Arial", 14f), -1, -1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("SUB-TOTAL", null, "N", null, FontFactory.GetFont("Arial", 12f, ColorLetra), -1, -1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.totsubTotal.ToString("N2"), null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2));
                        TablaCabDetalle4.CompleteRow();

                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("Cancelado ", null, "N", null, FontFactory.GetFont("Arial", 12f, ColorLetra)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("I.G.V.  %", null, "N", null, FontFactory.GetFont("Arial", 14f, ColorLetra)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.totIgv.Value.ToString("N2"), null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2));
                        TablaCabDetalle4.CompleteRow();

                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("Lima............de...........................del 20....... ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra), 1, 1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("TOTAL   ", null, "N", null, FontFactory.GetFont("Arial", 14f, ColorLetra)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(DocumentoPrevio.totTotal.ToString("N2"), null, "S", ColorLetra, FontFactory.GetFont("Arial", 7.25f), 1, 1, "N", "N", 2, 2));
                        TablaCabDetalle4.CompleteRow();


                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("........................................", null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra), 1, 1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.CompleteRow();

                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda("p.SERVICIOS COMPLETO EN INGENIERIA S.R.L", null, "N", null, FontFactory.GetFont("Arial", 7.25f, ColorLetra), 1, 1));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        TablaCabDetalle4.CompleteRow();


                        docPdf.Add(TablaCabDetalle4);

                        //PdfPTable TablaCabDetalle2 = new PdfPTable(3);
                        //TablaCabDetalle2.WidthPercentage = WidthPercentage;
                        //TablaCabDetalle2.SetWidths(new float[] { 0.2f, 0.6f, 0.2f });

                        //TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S3"));
                        //TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda("Representación Impresa del Comprobante Electrónico. Resolución de Superintendencia N°274-2015/SUNAT ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S3"));
                        //TablaCabDetalle2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S3"));
                        //TablaCabDetalle2.CompleteRow();
                        //docPdf.Add(TablaCabDetalle2);


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
                        wbNavegador.Navigate(RutaGeneral);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        Boolean VerificarImpresora(string Nombre)
        {
            try
            {
                Boolean Encontro = false;

                if (String.IsNullOrEmpty(Nombre))
                {
                    Global.MensajeComunicacion("El documento no tiene asignado una impresora...");
                    return false;
                }

                foreach (String NombreImpresora in PrinterSettings.InstalledPrinters)
                {
                    if (Nombre == NombreImpresora)
                    {
                        Encontro = true;
                        break;
                    }
                }

                if (!Encontro)
                {
                    Global.MensajeComunicacion("La impresora asignada a este documento no se encuentra.\n\rVerifique si se encuentra encendida.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
                return false;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Imprimir()
        {
            try
            {
                frmEscogerImpresora oFrm = new frmEscogerImpresora();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oImpresora != null)
                {
                    string NombreImpresora = oFrm.oImpresora.Descripcion;

                    if (!VerificarImpresora(NombreImpresora))
                    {
                        return;
                    }

                    if (oFrm.oImpresora.PorDefecto) //Solo cuando la impresora es la principal se emite y es matricial
                    {
                        if (oFrm.oImpresora.EsMatricial)
                        {
                            //Cambiando el estado del documento si es la primera vez...
                            if (DocumentoPrevio.indEstado == EnumEstadoDocumentos.C.ToString())
                            {
                                AgenteVentas.Proxy.CambiarEstadoDocumento(DocumentoPrevio.idEmpresa, DocumentoPrevio.idLocal, DocumentoPrevio.idDocumento, DocumentoPrevio.numSerie, DocumentoPrevio.numDocumento, EnumEstadoDocumentos.E.ToString(), VariablesLocales.SesionUsuario.Credencial);
                            }

                            //Imprimiendo...
                            ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirFacturas(DocumentoPrevio, NombreImpresora);
                        }
                        //else
                        //{
                        //    printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                        //    printDocumento.DocumentName = "Impresion de Factura";
                        //    printDocumento.Print();
                        //}
                    }
                    else
                    {
                        if (oFrm.oImpresora.EsMatricial)
                        {
                            //Imprimiendo...
                            ImpresionManager.RecuperarUtilImpresion(VariablesLocales.SesionUsuario.Empresa.RUC).ImprimirFacturas(DocumentoPrevio, NombreImpresora);
                        }
                        //else
                        //{
                        //    printDocumento.PrinterSettings.PrinterName = NombreImpresora;
                        //    printDocumento.DocumentName = "Impresion de Factura";
                        //    printDocumento.Print();
                        //}
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
                DialogResult = DialogResult.Cancel;
            }
        }

        #endregion

        #region Eventos

        private void frmReporteFacturaExportacion_Load(object sender, EventArgs e)
        {
            LlenarDatos();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        #endregion

    }
}
