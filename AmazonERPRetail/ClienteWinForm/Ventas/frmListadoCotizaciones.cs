using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Maestros;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoCotizaciones : FrmMantenimientoBase
    {

        public frmListadoCotizaciones()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new System.Drawing.Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvCotizaciones, true);
            LlenarCombo();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<PedidoCabE> oListaCotizaciones = null;
        String RutaPdf = String.Empty;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        Boolean indCarteraClientes = true;

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ParTabla> oLista = new List<ParTabla>();
            oLista.Add(new ParTabla() { IdParTabla = 0, Nombre = "NACIONAL" });
            oLista.Add(new ParTabla() { IdParTabla = 1, Nombre = "EXPORTACION" });

            ComboHelper.LlenarCombos<ParTabla>(cboTipo, oLista, "IdParTabla", "Nombre");
        }

        void CrearPdf(PedidoCabE oPedido)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Cotizacion " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Cotizaciones");
            DocumentoPdf.AddSubject("Cotizaciones");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                Decimal TipoCambio = Variables.Cero;
                TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Convert.ToDateTime(oPedido.FecPedido).ToString("yyyyMMdd"));
                Int32 Dias = AgenteVentas.Proxy.ObtenerDiasVencimiento(Convert.ToInt32(oPedido.idTipCondicion), Convert.ToInt32(oPedido.idCondicion));
                List<BancosCuentasE> oListaCuentas = AgenteMaestro.Proxy.ListarCuentasParaDoc(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oTica != null)
                {
                    TipoCambio = oTica.valVenta;
                }

                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    InicioCabeceraCotizacion pagInicio = new InicioCabeceraCotizacion();
                    oPdfw.PageEvent = pagInicio;

                    DocumentoPdf.Open();

                    //Cabecera del Reporte
                    float[] AnchoColumnas = new float[] { 0.5f, 0.5f };
                    PdfPTable Tabla = new PdfPTable(2);
                    Tabla.WidthPercentage = 100;
                    Tabla.SetWidths(AnchoColumnas);

                    #region Cabecera

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        switch (VariablesLocales.SesionUsuario.Empresa.RUC)
                        {
                            case "20502647009": //AgroGenesis - HuertoGenesis - Viveros - Jeritec - AyV Seeds - Power Seeds
                            case "20523020561":
                            case "20517933318":
                            case "20552695217":
                            case "20552186681":
                            case "20552690410":
                                CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 250f, 1, "N"));
                                break;
                            default: //Otras Empresas...
                                CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 200f, 1, "N"));
                                break;
                        }
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    }

                    CeldaImagen.Rowspan = 5;
                    Tabla.AddCell(CeldaImagen);

                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.sTelefonos, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Correo-e: " + VariablesLocales.SesionUsuario.Empresa.sEmail, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.sWeb, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                    Tabla.CompleteRow();

                    #endregion

                    DocumentoPdf.Add(Tabla);

                    #region Titulo

                    Tabla = new PdfPTable(2);
                    AnchoColumnas = new float[] { 0.8f, 0.2f };
                    Tabla.WidthPercentage = 95;
                    Tabla.SetWidths(AnchoColumnas);
                    Tabla.HorizontalAlignment = Element.ALIGN_CENTER;

                    Tabla.AddCell(ReaderHelper.NuevaCelda("                              COTIZACION", null, "N", null, FontFactory.GetFont("Arial Black", 15.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("N° " + oPedido.codPedidoCad, null, "S", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                    Tabla.CompleteRow();

                    #endregion

                    DocumentoPdf.Add(Tabla);

                    #region SubTitulos

                    Tabla = new PdfPTable(4)
                    {
                        WidthPercentage = 95
                    };
                    Tabla.SetWidths(new float[] { 0.049f, 0.3f, 0.04f, 0.12f });
                    Tabla.HorizontalAlignment = Element.ALIGN_CENTER;

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Razón Social ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desFacturar, null, "S", null, FontFactory.GetFont("Arial", 7.50f, iTextSharp.text.Font.BOLD), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Atención ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.Observacion, null, "S", null, FontFactory.GetFont("Arial", 7.50f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("RUC " + oPedido.RucCliente, null, "S", null, FontFactory.GetFont("Arial", 7.50f, iTextSharp.text.Font.BOLD)));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Dirección ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.DireccionCompleta, null, "S", null, FontFactory.GetFont("Arial", 7.50f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Moneda ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda((oPedido.idMoneda == Variables.Soles ? "Soles (S/.)" : "Dólares Americanos (US$)"), null, "S", null, FontFactory.GetFont("Arial", 7.50f), -1, -1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Fecha   " + Convert.ToDateTime(oPedido.FecPedido).ToLongDateString(), null, "S", null, FontFactory.GetFont("Arial", 7.50f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), -1, -1, "S4", "N", 0f, 0f));
                    Tabla.CompleteRow();

                    #endregion SubTitulos

                    DocumentoPdf.Add(Tabla); //Añadiendo la tabla al documento PDF

                    #region Condiciones

                    Tabla = new PdfPTable(2);
                    Tabla.WidthPercentage = 95;
                    Tabla.SetWidths(new float[] { 0.002f, 0.09f });
                    Tabla.HorizontalAlignment = Element.ALIGN_CENTER;

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Condiciones ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 1.2f, 1.2f, "S", "N", "S", "S"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Válidez de la cotización  " + Dias.ToString() + " dias.", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "S", "N"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Pago  " + oPedido.desCondicion, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "S", "N"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Plazo de entrega  " + oPedido.PuntoLlegada, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "S", "N"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Los precios unitarios NO incluyen IGV ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "S", "N"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Puesto en nuestro almacén ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "N", "S", "N"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "S", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("DESPACHO: Local: Sin costo a distritos aledaños anuestra oficina principal.\n                      Provincia: Flete pago en destino. La mercaderia viaja por cuenta y riesgo del cliente.", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 1.2f, 1.2f, "N", "S", "S", "N"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), -1, -1, "S2", "N", 0f, 0f));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion

                    Tabla = new PdfPTable(8);
                    Tabla.WidthPercentage = 95;
                    Tabla.SetWidths(new float[] { 0.03f, 0.03f, 0.045f, 0.07f, 0.35f, 0.06f, 0.07f, 0.15f });
                    Tabla.HorizontalAlignment = Element.ALIGN_CENTER;
                    Decimal porIgv = VariablesLocales.oListaImpuestos[0].Porcentaje;

                    string RutaFisica = @"C:\AmazonErp\Imagenes\" + VariablesLocales.SesionUsuario.Empresa.RUC + @"\Articulos\";

                    if (!Directory.Exists(RutaFisica))
                    {
                        Directory.CreateDirectory(RutaFisica);
                    }

                    #region Detalle

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Item", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("U.M.", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Cant.", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Cód.Articulo", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Descripción", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Precio Unitario", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Precio Total", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Imagen", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.CompleteRow();

                    CeldaImagen = null;
                    String RutaTemp = String.Empty;
                    String Archivo = String.Empty;

                    foreach (PedidoDetE item in oPedido.ListaPedidoDet)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.idItem.ToString("00"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desUnidadMed, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 1));

                        if (item.indCalculo)
                        {
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        }
                        else
                        {
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto + " (BONIFICACION)", null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        }

                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitario.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda((item.Cantidad * item.PrecioUnitario).ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));

                        #region Imagen

                        item.oArticulo.RutaImagen = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\Articulos";
                        Archivo = item.oArticulo.NombreImagen + item.oArticulo.Extension;

                        if (!String.IsNullOrWhiteSpace(Archivo.Trim()))
                        {
                            if (!File.Exists(RutaFisica + Archivo))
                            {
                                item.oArticulo = AgenteMaestro.Proxy.ObtenerImagenArticulo(item.oArticulo);

                                if (item.oArticulo != null)
                                {
                                    File.WriteAllBytes(RutaFisica + Archivo, item.oArticulo.Imagen);
                                    RutaTemp = RutaFisica + Archivo;
                                }
                                else
                                {
                                    RutaTemp = String.Empty;
                                }
                            }
                            else
                            {
                                RutaTemp = RutaFisica + Archivo;
                            }
                        }
                        else
                        {
                            RutaTemp = String.Empty;
                        }

                        if (File.Exists(RutaTemp))
                        {
                            CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaTemp, 80f, 1, "S"));
                        }
                        else
                        {
                            CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                        }

                        Tabla.AddCell(CeldaImagen);

                        #endregion

                        Tabla.CompleteRow();
                    }

                    #endregion Detalle

                    #region Final

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Son:", null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "N", "N", 2, 2, "N", "S", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(NumeroLetras.enLetras(oPedido.totTotal.ToString()), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLDITALIC, BaseColor.RED), -1, -1, "S4", "N", 2, 2, "S", "S", "N", "N"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Sub Total", null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 2, 2, "S", "S", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totsubTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 2, 2, "S", "S", "S", "N"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    Tabla = new PdfPTable(5);
                    Tabla.WidthPercentage = 95;
                    Tabla.SetWidths(new float[] { 0.28f, 0.049f, 0.04f, 0.046f, 0.095f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("I.G.V. % ", null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 2, 2, "N", "S", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(porIgv.ToString("N0"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 2, 2, "S", "S", "N", "N"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totIgv.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 2, 2, "S", "S", "S", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("TOTAL ", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 2, 2, "N", "S", "N", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 2, 2, "N", "S", "N", "N"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 2, 2, "S", "S", "S", "S"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), -1, -1, "S5", "N", 0f, 0f));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Remitir Orden de Compra/Servicio a nombre de " + VariablesLocales.SesionUsuario.Empresa.RazonSocial + " vía correo electrónico a " + VariablesLocales.SesionUsuario.Empresa.sEmail + (!string.IsNullOrWhiteSpace(oPedido.EmailVendedor) ? ", " + oPedido.EmailVendedor : ""), null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S5"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Hacer depósito bancario a nombre de " + VariablesLocales.SesionUsuario.Empresa.RazonSocial + " según:", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S5"));

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), -1, -1, "S5", "N", 0f, 0f));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    Tabla = new PdfPTable(4);
                    Tabla.WidthPercentage = 95;
                    Tabla.SetWidths(new float[] { 0.25f, 0.2f, 0.28f, 0.28f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Banco", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Tipo de Cuenta", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("N° de Cuenta", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Código de Cta. Interbancaria", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    Tabla.CompleteRow();

                    //Detalle de Cuentas
                    if (oListaCuentas.Count > 0)
                    {
                        foreach (BancosCuentasE item in oListaCuentas)
                        {
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.desTipCuenta, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.numCuenta, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.numCuentaInter, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                        }

                        Tabla.CompleteRow();
                    }

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), -1, -1, "S4", "N", 0f, 0f));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Posteriormente enviar voucher de depósito correspondiente a " + (VariablesLocales.oVenParametros != null ? VariablesLocales.oVenParametros.CorreoCobranza : "") + ", haciendo referencia", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S4"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("al N° de Orden Compra/Servicio.", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S4"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Para despachos a provincias enviar instrucciones precisando: ", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S4"));

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), -1, -1, "S4", "N", 0f, 0f));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("    \u2022 Ciudad destino", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S4"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("    \u2022 Nombre de empresa de transportes", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S4"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("    \u2022 Nombre de persona que recogerá el envío", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S4"));

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), -1, -1, "S4", "N", 0f, 0f));
                    Tabla.CompleteRow();
                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), -1, -1, "S4", "N", 0f, 0f));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Sin otro particular quedamos de ustedes a la espera de sus gratas órdenes.", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S4"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Atentamente.", null, "N", null, FontFactory.GetFont("Arial", 7.5f), -1, -1, "S4"));

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13.25f), -1, -1, "S4", "N", 0f, 0f));
                    Tabla.CompleteRow();
                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13.25f), -1, -1, "S4", "N", 0f, 0f));
                    Tabla.CompleteRow();

                    //Firma
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.Vendedor, null, "N", null, FontFactory.GetFont("Arial", 7.5f, iTextSharp.text.Font.BOLD), -1, -1, "S4", "N", 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.5f, iTextSharp.text.Font.BOLD), -1, -1, "S4", "N", 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Ejecutivo Comercial", null, "N", null, FontFactory.GetFont("Arial", 7.5f, iTextSharp.text.Font.BOLD), -1, -1, "S4", "N", 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Teléfono: (051)", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S4", "N", 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Móvil: " + oPedido.telVendedor, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S4", "N", 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("Correo: " + oPedido.EmailVendedor, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S4", "N", 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.sWeb, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S4", "N", 1, 1));

                    DocumentoPdf.Add(Tabla);

                    #endregion Final

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //Establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    DocumentoPdf.Close();
                }
            }
        }

        void VerificarVendedor(Int32 IdPersona)
        {
            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                txtNombresVendedor.Tag = string.Empty;
                txtNroDocumentoVen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtNombresVendedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                VendedoresE oVendedor = AgenteMaestro.Proxy.RecuperarVendedorPorId(VariablesLocales.SesionUsuario.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oVendedor != null)
                {
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;

                    txtNombresVendedor.Tag = oVendedor.idPersona.ToString();
                    txtNombresVendedor.Text = oVendedor.RazonSocial;
                    txtNroDocumentoVen.Text = oVendedor.NroDocumento;
                    indCarteraClientes = oVendedor.ManejaCartera;

                    if (oVendedor.indSupervisor)
                    {
                        txtNroDocumentoVen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNombresVendedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }

                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                }
                else
                {
                    txtNombresVendedor.Tag = string.Empty;
                }

                oVendedor = null;
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCotizacion);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmCotizacion()
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsCotizacion.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCotizacion);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    PedidoCabE current = (PedidoCabE)bsCotizacion.Current;

                    if (current != null)
                    {
                        oFrm = new frmCotizacion(current.idEmpresa, current.idLocal, current.idPedido)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                Int32 idLocal = VariablesLocales.SesionLocal.IdLocal;
                String codPedidoCad = String.IsNullOrEmpty(txtPedido.Text.Trim()) ? "%" : txtPedido.Text.Trim();
                string fecInicio = dtpInicio.Value.ToString("yyyyMMdd");
                string fecFinal = dtpFin.Value.ToString("yyyyMMdd");
                String RazonSocial = String.IsNullOrEmpty(txtDescripcion.Text.Trim()) ? String.Empty : txtDescripcion.Text.Trim();
                string Tipo = "C"; //Empieza en Cotizado...
                Int32 idVendedor = String.IsNullOrWhiteSpace(txtNombresVendedor.Tag.ToString()) ? 0 : Convert.ToInt32(txtNombresVendedor.Tag);

                bsCotizacion.DataSource = oListaCotizaciones = AgenteVentas.Proxy.ListarPedidoNacional(idEmpresa, idLocal, codPedidoCad, fecInicio, fecFinal, RazonSocial, Tipo, idVendedor, "");
                bsCotizacion.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {
                if (bsCotizacion.List.Count > Variables.Cero)
                {
                    PedidoCabE oPedido = AgenteVentas.Proxy.RecuperarPedidoNacional(((PedidoCabE)bsCotizacion.Current).idEmpresa, ((PedidoCabE)bsCotizacion.Current).idLocal, ((PedidoCabE)bsCotizacion.Current).idPedido);

                    if (oPedido != null)
                    {
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionBase);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmImpresionBase(oPedido, "Vista Previa de la Cotización");
                        oFrm.MdiParent = MdiParent;
                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (((PedidoCabE)bsCotizacion.Current).Estado == EnumEstadoDocumentos.C.ToString())
                {
                    Global.MensajeComunicacion(String.Format("Antes de eliminar la cotización {0} tiene que eliminar el Pedido", ((PedidoCabE)bsCotizacion.Current).codPedidoCad));
                    return;
                }

                if (((PedidoCabE)bsCotizacion.Current).Estado == EnumEstadoDocumentos.P.ToString())
                {
                    if (Global.MensajeConfirmacion(String.Format("Desea eliminar la cotización {0}", ((PedidoCabE)bsCotizacion.Current).codPedidoCad)) == DialogResult.Yes)
                    {
                        Int32 resp = AgenteVentas.Proxy.EliminarTodoPedido(((PedidoCabE)bsCotizacion.Current).idEmpresa, ((PedidoCabE)bsCotizacion.Current).idPedido, ((PedidoCabE)bsCotizacion.Current).idLocal);

                        if (resp > 0)
                        {
                            Global.MensajeComunicacion("La cotización se eliminó correctamente.");
                            oListaCotizaciones.Remove((PedidoCabE)bsCotizacion.Current);
                            bsCotizacion.DataSource = oListaCotizaciones;
                            bsCotizacion.ResetBindings(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCotizacion oFrm = sender as frmCotizacion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoCotizaciones_Load(object sender, EventArgs e)
        {
            Grid = true;

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            VerificarVendedor(VariablesLocales.SesionUsuario.IdPersona);
        }

        private void txtNroDocumentoVen_TextChanged(object sender, EventArgs e)
        {
            txtNombresVendedor.Tag = String.Empty;
            txtNombresVendedor.Text = String.Empty;
        }

        private void txtNombresVendedor_TextChanged(object sender, EventArgs e)
        {
            txtNombresVendedor.Tag = String.Empty;
            txtNroDocumentoVen.Text = String.Empty;
        }

        private void bsCotizacion_ListChanged(object sender, ListChangedEventArgs e)
        {
            lblRegistros.Text = String.Format("Registros {0}", bsCotizacion.List.Count);
        }

        private void dgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void tsmiCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaCotizaciones != null && oListaCotizaciones.Count > Variables.Cero)
                {
                    //Global.MensajeComunicacion("En mantenimiento.");
                    if (((PedidoCabE)bsCotizacion.Current).Estado == EnumEstadoDocumentos.C.ToString())
                    {
                        Global.MensajeComunicacion(String.Format("La cotización {0} ha sido cerrada. No se puede hacer ninguna modificación.", ((PedidoCabE)bsCotizacion.Current).codPedidoCad));
                        return;
                    }

                    Int32 resp = AgenteVentas.Proxy.CrearPedido(((PedidoCabE)bsCotizacion.Current).idEmpresa, ((PedidoCabE)bsCotizacion.Current).idLocal,
                                                                ((PedidoCabE)bsCotizacion.Current).idPedido, VariablesLocales.SesionUsuario.Credencial);

                    if (resp > 0)
                    {
                        Global.MensajeComunicacion("Se creó el Pedido correctamente.");
                        Buscar();
                    }
                    //if (((PedidoCabE)bsCotizacion.Current).NemoTipoDoc == "TIPFACT" || ((PedidoCabE)bsPedidos.Current).NemoTipoDoc == "TIPBOL" || ((PedidoCabE)bsPedidos.Current).NemoTipoDoc == "TIPGUI")
                    //{
                    //    frmDetalleCrearDocumentos oFrm = new frmDetalleCrearDocumentos((PedidoCabE)bsPedidos.Current, ((PedidoCabE)bsPedidos.Current).codPedidoCad);

                    //    if (oFrm.ShowDialog() == DialogResult.OK)
                    //    {
                    //        Global.MensajeComunicacion("Los documentos se crearon correctamente");
                    //        Buscar();
                    //    }
                    //}
                    //else
                    //{
                    //    Global.MensajeComunicacion("Debe escoger un tipo de comprobante en el pedido antes de crear el documento de venta.");
                    //}
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaCotizaciones != null && oListaCotizaciones.Count > Variables.Cero)
                {
                    Boolean ValorRetorno = AgenteVentas.Proxy.CopiarPedido(((PedidoCabE)bsCotizacion.Current).idEmpresa, ((PedidoCabE)bsCotizacion.Current).idLocal, ((PedidoCabE)bsCotizacion.Current).idPedido, "C", VariablesLocales.SesionUsuario.Credencial, VariablesLocales.FechaHoy);

                    if (ValorRetorno)
                    {
                        Global.MensajeComunicacion("La cotización fue copiada con éxito...");
                        Buscar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiMandar_Click(object sender, EventArgs e)
        {
            try
            {
                RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                PedidoCabE oPedido = AgenteVentas.Proxy.RecuperarPedidoNacional(((PedidoCabE)bsCotizacion.Current).idEmpresa, ((PedidoCabE)bsCotizacion.Current).idLocal, ((PedidoCabE)bsCotizacion.Current).idPedido);

                if (oPedido != null)
                {
                    CrearPdf(oPedido);

                    frmEnvioCorreos oFrm = new frmEnvioCorreos(oPedido, RutaPdf);
                    oFrm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtNroDocumentoVen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNroDocumentoVen.Text.Trim()) && String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()))
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", txtNroDocumentoVen.Text.Trim());

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            txtNombresVendedor.Tag = oFrm.oPersona.IdPersona.ToString();
                            txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                            indCarteraClientes = oFrm.oPersona.ManejaCartera;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtNombresVendedor.Tag = oListaPersonas[0].IdPersona.ToString();
                        txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                        indCarteraClientes = oListaPersonas[0].ManejaCartera;
                    }
                    else
                    {
                        Global.MensajeFault("El Nro. de Documento ingresado no existe");
                        txtNombresVendedor.Tag = String.Empty;
                        txtNroDocumentoVen.Text = String.Empty;
                        txtNombresVendedor.Text = String.Empty;
                        indCarteraClientes = false;
                        txtNroDocumentoVen.Focus();
                        return;
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtNombresVendedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()) && String.IsNullOrEmpty(txtNroDocumentoVen.Text.Trim()))
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtNombresVendedor.Text.Trim(), "");

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Vendedor");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            txtNombresVendedor.Tag = oFrm.oPersona.IdPersona.ToString();
                            indCarteraClientes = oFrm.oPersona.ManejaCartera;

                            if (String.IsNullOrEmpty(oFrm.oPersona.RazonSocial.Trim()))
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.ApePaterno + " " + oFrm.oPersona.ApeMaterno + " " + oFrm.oPersona.Nombres;
                            }
                            else
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                            }
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtNombresVendedor.Tag = oListaPersonas[0].IdPersona.ToString();
                        indCarteraClientes = oListaPersonas[0].ManejaCartera;

                        if (String.IsNullOrEmpty(oListaPersonas[0].RazonSocial.Trim()))
                        {
                            txtNombresVendedor.Text = oListaPersonas[0].ApePaterno + " " + oListaPersonas[0].ApeMaterno + " " + oListaPersonas[0].Nombres;
                        }
                        else
                        {
                            txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                        }
                    }
                    else
                    {
                        Global.MensajeFault("El nombre ingresado no existe.");
                        txtNombresVendedor.Tag = String.Empty;
                        txtNroDocumentoVen.Text = String.Empty;
                        txtNombresVendedor.Text = String.Empty;
                        indCarteraClientes = false;
                        txtNroDocumentoVen.Focus();
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvCotizaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((String)dgvCotizaciones.Rows[e.RowIndex].Cells["Estado"].Value == "C")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorCerrado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
