using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Maestros;
//using Entidades.Asistencia;
using Entidades.Almacen;
using Entidades.Tesoreria;
using Entidades.CtasPorPagar;
using Entidades.CtasPorCobrar;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm
{
    public partial class frmImpresionBase : FrmMantenimientoBase
    {

        #region Constructores
        
        public frmImpresionBase()
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

        //Impresión de los Pedidos
        public frmImpresionBase(PedidoCabE oPedidoTemporal, String Titulo = "Impresión de Pedido")
            :this()
        {
            oPedido = oPedidoTemporal;
            Text = Titulo;

            BuscarImagen();
        }

        //Impresión de la Bonificación
        //public frmImpresionBase(BonificacionE oBonificacionTemporal, String Titulo = "")
        //    :this()
        //{
        //    oBonificacion = oBonificacionTemporal;
        //    Text = Titulo;

        //    BuscarImagen();
        //}

        //Impresión del Requerimiento
        //public frmImpresionBase(RequerimientosE RequerimientoTemporal, String Titulo = "")
        //    :this()
        //{
        //    oRequerimiento = RequerimientoTemporal;
        //    Text = Titulo;
        //}

        //Impresión de Movimiento de Almacén desde el listado o la hoja de costo
        public frmImpresionBase(MovimientoAlmacenE MovimientoTemporal, String Titulo = "", String Varios = "N")
            :this()
        {
            oMovimientoAlmacen = MovimientoTemporal;
            Text = Titulo;
        }

        //Impresión de la O.C.
        public frmImpresionBase(OrdenCompraE OCTemporal, String Titulo = "")
            :this()
        {
            oOrdenCompra = OCTemporal;
            Text = Titulo;
            BuscarImagen();
        }

        //Impresión desde el listado de las conversiones de almacén
        public frmImpresionBase(OrdenConversionE oItem, String Titulo = "")
            :this()
        {
            OrdenConversion = oItem;
            Text = Titulo;
            BuscarImagen();
        }

        //Impresión de la Orden de Pago
        public frmImpresionBase(OrdenPagoE OPTemporal, String Titulo = "")
            :this()
        {
            OrdenPago = OPTemporal;
            Text = Titulo;
            BuscarImagen();
        }

        //Impresión de la Liquidacion
        public frmImpresionBase(LiquidacionE LiquiTemporal, String Titulo = "")
            :this()
        {
            oLiquidacion = LiquiTemporal;
            Text = Titulo;
            BuscarImagen();
        }

        //Impresión de la O.T.S
        public frmImpresionBase(OrdenTrabajoServicioE OrdenTrabajoserv_, String Titulo = "")
            :this()
        {
            oOrdenTrabajoServ = OrdenTrabajoserv_;
            Text = Titulo;
            BuscarImagen();
        }

        //Impresión de Solicitud de Adelanto a proveedor
        public frmImpresionBase(SolicitudProveedorE SolicitudTemporal, String Titulo = "")
            :this()
        {
            oSolicitud = SolicitudTemporal;
            Text = Titulo;
            BuscarImagen();
        }

        //Impresión de Rendición de Solicitud de Adelanto a proveedor
        public frmImpresionBase(List<SolicitudProveedorRendicionDetE> RendicionTemporal, String Titulo = "")
            :this()
        {
            oListaRendiciones = RendicionTemporal;
            Text = Titulo;
            BuscarImagen();
        }

        //Impresión de Conciliados y no Conciliados de Cobranzas
        public frmImpresionBase(List<CobranzasItemE> ListaCobranzas_, String Titulo = "")
            :this()
        {
            ListaCobranzas = ListaCobranzas_;
            Text = Titulo;
            BuscarImagen();
        }

        //Impresión de la Liquidacion de Importación
        public frmImpresionBase(LiquidacionImportacionE LiquiTemporal, String Titulo = "")
            :this()
        {
            oLiquidacionImpo = LiquiTemporal;
            Text = Titulo;
            BuscarImagen();
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        PedidoCabE oPedido = null;
        //BonificacionE oBonificacion = null;
        //RequerimientosE oRequerimiento = null;        
        MovimientoAlmacenE oMovimientoAlmacen = null;
        OrdenCompraE oOrdenCompra = null;
        OrdenConversionE OrdenConversion = null;
        OrdenPagoE OrdenPago = null;
        LiquidacionE oLiquidacion = null;
        OrdenTrabajoServicioE oOrdenTrabajoServ = null;
        SolicitudProveedorE oSolicitud = null;
        List<SolicitudProveedorRendicionDetE> oListaRendiciones = null;
        List<CobranzasItemE> ListaCobranzas = null;
        LiquidacionImportacionE oLiquidacionImpo = null;

        String RutaPdf = String.Empty;
        String RutaImagen = @"C:\AmazonErp\Logo\";

        #endregion

        #region Procedimientos de Usuario

        void BuscarImagen()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void CrearPrevioPedidoNormal(PedidoCabE oPedido)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Pedido " + Aleatorio.ToString();
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
            DocumentoPdf.AddTitle("Pedidos");
            DocumentoPdf.AddSubject("Pedidos");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                Decimal TipoCambio = Variables.Cero;
                TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Convert.ToDateTime(oPedido.FecPedido).ToString("yyyyMMdd"));

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
                    //Decimal Total = Variables.Cero;
                    BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    #region Encabezado

                    float[] AnchoColumnas = new float[] { 0.7f, 0.35f };
                    PdfPTable Tabla = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };
                    Tabla.SetWidths(AnchoColumnas);

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 5f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    }

                    CeldaImagen.Rowspan = 3;
                    Tabla.AddCell(CeldaImagen);

                    Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C. N° " + VariablesLocales.SesionUsuario.Empresa.RUC, ColorFondo, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("PEDIDO", ColorFondo, "N", null, FontFactory.GetFont("Arial", 14.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.codPedidoCad, ColorFondo, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(oPedido.FecPedido).ToLongDateString().ToUpper(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion Encabezado

                    #region SubTitulos

                    Tabla = new PdfPTable(4);
                    Tabla.WidthPercentage = 100;
                    Tabla.SetWidths(new float[] { 0.05f, 0.3f, 0.04f, 0.05f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Señor(es): ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desFacturar, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Dirección: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C.: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.RucCliente, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Entrega: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.PuntoLlegada, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Condicion: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desCondicion, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("T.Cambio: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(TipoCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Vendedor: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.Vendedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion SubTitulos

                    #region Detalle

                    //Tabla = new PdfPTable(8)
                    //{
                    //    WidthPercentage = 100
                    //};
                    //Tabla.SetWidths(new float[] { 0.06f, 0.05f, 0.09f, 0.3f, 0.1f , 0.09f, 0.06f, 0.06f });

                    //Tabla.AddCell(ReaderHelper.NuevaCelda("CANT. PEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("LOTE ALMACEN  12121", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("LOTE PROVEEDOR", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("PRECIO UNITARIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    //Tabla.CompleteRow();


                    Tabla = new PdfPTable(6);
                    Tabla.WidthPercentage = 100;
                    //Tabla.SetWidths(new float[] { 0.08f, 0.08f, 0.09f, 0.3f, 0.06f, 0.06f });
                    Tabla.SetWidths(new float[] { 0.05f, 0.05f, 0.09f, 0.35f, 0.06f, 0.06f });
                    Tabla.AddCell(ReaderHelper.NuevaCelda("CANTIDAD ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION                       ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("PRECIO UNITARIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    foreach (PedidoDetE item in oPedido.ListaPedidoDet)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N0"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 1,1 ));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desUnidadMed, null, "N", null, FontFactory.GetFont("Arial", 8.25f),-2,1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        //Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));

                        if (item.indCalculo)
                        {
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        }
                        else
                        {
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto + " (BONIFICACION)", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        }

                        //Tabla.AddCell(ReaderHelper.NuevaCelda(item.SiglaEmpresa + "-" + item.LoteAlmacen, null, "N", null, FontFactory.GetFont("Arial", 7.25f),1,1));
                        //Tabla.AddCell(ReaderHelper.NuevaCelda(item.LoteProveedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        
                        
                        
                        
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitario.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));

                        Tabla.AddCell(ReaderHelper.NuevaCelda((item.Cantidad * item.PrecioUnitario).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));

                        Tabla.CompleteRow();
                    }

                    #endregion Detalle

                    #region Final

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1,"S8"));
                
                    Tabla.CompleteRow();


                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("SUBTOTAL:  "+oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totsubTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));



                    Tabla.CompleteRow();
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("IGV     :  " + oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totIgv.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));

                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("TOTAL   :  " + oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));


                    Tabla.CompleteRow();
                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S8"));
                    Tabla.CompleteRow();
                    //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S8"));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S8"));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("  "   ,  RUC: " + oPedido.RucTransporte, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 1, 1, "S8"));
                    Tabla.CompleteRow();

                    //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("ATENCION: " + oPedido.Observacion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S8"));
                    Tabla.CompleteRow();

                    //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    //Tabla.AddCell(ReaderHelper.NuevaCelda("GUIA N°: " + oPedido.NroGuia, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("INDICACIONES: " + oPedido.Indicaciones, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S7"));
                    Tabla.CompleteRow();

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

        void CrearPrevioPedidoCalzado(PedidoCabE oPedido)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Pedido " + Aleatorio.ToString();
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
            DocumentoPdf.AddTitle("Pedidos");
            DocumentoPdf.AddSubject("Pedidos");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                Decimal TipoCambio = Variables.Cero;
                TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Convert.ToDateTime(oPedido.FecPedido).ToString("yyyyMMdd"));

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
                    BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    #region Encabezado

                    float[] AnchoColumnas = new float[] { 0.7f, 0.35f };
                    PdfPTable Tabla = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    Tabla.SetWidths(AnchoColumnas);

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 5f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    }

                    CeldaImagen.Rowspan = 3;
                    Tabla.AddCell(CeldaImagen);

                    Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C. N° " + VariablesLocales.SesionUsuario.Empresa.RUC, ColorFondo, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("PEDIDO", ColorFondo, "N", null, FontFactory.GetFont("Arial", 14.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.codPedidoCad, ColorFondo, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(oPedido.FecPedido).ToLongDateString().ToUpper(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion Encabezado

                    #region SubTitulos

                    Tabla = new PdfPTable(4)
                    {
                        WidthPercentage = 100
                    };

                    Tabla.SetWidths(new float[] { 0.05f, 0.3f, 0.04f, 0.05f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Señor(es): ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desFacturar, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Dirección: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C.: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.RucCliente, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Entrega: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.PuntoLlegada, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Condicion: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desCondicion, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("T.Cambio: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(TipoCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Vendedor: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.Vendedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion SubTitulos

                    #region Detalle

                    Tabla = new PdfPTable(7)
                    {
                        WidthPercentage = 100
                    };

                    Tabla.SetWidths(new float[] { 0.06f, 0.05f, 0.09f, 0.4f, 0.07f, 0.06f, 0.06f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda("CANT. PEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("TALLA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("PRECIO UNITARIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    foreach (PedidoDetE item in oPedido.ListaPedidoDet)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desUnidadMed, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));

                        if (item.indCalculo)
                        {
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        }
                        else
                        {
                            Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto + " (BONIFICACION)", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        }

                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitario.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda((item.Cantidad * item.PrecioUnitario).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));

                        Tabla.CompleteRow();
                    }

                    #endregion Detalle

                    #region Final

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S7"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S4"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("SUBTOTAL ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totsubTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S4"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("IGV ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totIgv.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S4"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("TOTAL ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S7"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("TRANSPORTISTA: " + oPedido.RazonSocialTransporte + "     RUC: " + oPedido.RucTransporte, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S7"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("ATENCION: " + oPedido.Observacion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S7"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("GUIA N°: " + oPedido.NroGuia, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("INDICACIONES: " + oPedido.Indicaciones, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S7"));
                    Tabla.CompleteRow();

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

        void CrearPrevioPedidoOtrowss(PedidoCabE oPedido)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Pedido " + Aleatorio.ToString();
            String Extension = ".pdf";
            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Pedidos");
            DocumentoPdf.AddSubject("Pedidos");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                Decimal TipoCambio = Variables.Cero;
                TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Convert.ToDateTime(oPedido.FecPedido).ToString("yyyyMMdd"));

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
                    //Decimal Total = Variables.Cero;
                    BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    #region Encabezado

                    float[] AnchoColumnas = new float[] { 0.7f, 0.35f };
                    PdfPTable Tabla = new PdfPTable(2);
                    Tabla.WidthPercentage = 100;
                    Tabla.SetWidths(AnchoColumnas);

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        //switch (VariablesLocales.SesionUsuario.Empresa.RUC)
                        //{
                        //    case "20502647009": //AgroGenesis - HuertoGenesis - Viveros
                        //    case "20523020561":
                        //    case "20517933318":
                        //        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 250f, 1, "N"));
                        //        break;
                        //    case "20552695217": //Jeritec - AyV Seeds - Power Seeds
                        //    case "20552186681":
                        //    case "20552690410":
                        //        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 150f, 1, "N"));
                        //        break;
                        //    default: //Otras Empresas...
                        //        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 200f, 1, "N"));
                        //        break;
                        //}
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 5f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    }

                    CeldaImagen.Rowspan = 3;
                    Tabla.AddCell(CeldaImagen);

                    Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C. N° " + VariablesLocales.SesionUsuario.Empresa.RUC, ColorFondo, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("ORDEN DE TRABAJO", ColorFondo, "N", null, FontFactory.GetFont("Arial", 14.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.codPedidoCad, ColorFondo, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(oPedido.FecPedido).ToLongDateString().ToUpper(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion Encabezado

                    #region SubTitulos

                    Tabla = new PdfPTable(4);
                    Tabla.WidthPercentage = 100;
                    Tabla.SetWidths(new float[] { 0.05f, 0.3f, 0.04f, 0.05f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Señor(es): ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));

                    if (oPedido.idNotificar != null && oPedido.idNotificar > Variables.Cero)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desNotificador, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }
                    else
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desFacturar, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }

                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Dirección: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));

                    if (oPedido.idNotificar != null && oPedido.idNotificar > Variables.Cero)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.dirNotificador, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }
                    else
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }

                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C.: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));

                    if (oPedido.idNotificar != null && oPedido.idNotificar > Variables.Cero)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.RucNotificador, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }
                    else
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.RucCliente, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }

                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Entrega: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.PuntoLlegada, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Condicion: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desCondicion, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("T.Cambio: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(TipoCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Vendedor: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.Vendedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion SubTitulos

                    #region Detalle

                    Tabla = new PdfPTable(8)
                    {
                        WidthPercentage = 100
                    };
                    Tabla.SetWidths(new float[] { 0.06f, 0.05f, 0.075f, 0.35f, 0.08f, 0.08f, 0.06f, 0.06f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda("CANT. PEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("LOTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("LOTE PROV.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("PRECIO UNITARIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    foreach (PedidoDetE item in oPedido.ListaPedidoDet)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N0"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desUnidadMed, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.LoteProveedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitario.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda((item.Cantidad * item.PrecioUnitario).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));

                        Tabla.CompleteRow();
                        //Total += item.Cantidad * item.PrecioUnitario;
                    }

                    #endregion Detalle

                    #region Final

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S8"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S5"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("      SUBTOTAL ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totsubTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S5"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("      IGV ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totIgv.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S5"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("      TOTAL ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S8"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("TRANSPORTISTA: " + oPedido.RazonSocialTransporte, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S8"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("ATENCION: " + oPedido.Observacion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S8"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("GUIA N°: " + oPedido.NroGuia, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S7"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("INDICACIONES: " + oPedido.Indicaciones, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S6"));
                    Tabla.CompleteRow();

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

        void CrearPrevioPedidoOtro(PedidoCabE oPedido)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Pedido " + Aleatorio.ToString();
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
            DocumentoPdf.AddTitle("Pedidos");
            DocumentoPdf.AddSubject("Pedidos");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                Decimal TipoCambio = Variables.Cero;
                TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Convert.ToDateTime(oPedido.FecPedido).ToString("yyyyMMdd"));

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
                    //Decimal Total = Variables.Cero;
                    BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    #region Encabezado

                    float[] AnchoColumnas = new float[] { 0.7f, 0.35f };
                    PdfPTable Tabla = new PdfPTable(2);
                    Tabla.WidthPercentage = 100;
                    Tabla.SetWidths(AnchoColumnas);

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 5f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    }

                    CeldaImagen.Rowspan = 3;
                    Tabla.AddCell(CeldaImagen);

                    Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C. N° " + VariablesLocales.SesionUsuario.Empresa.RUC, ColorFondo, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("PEDIDO", ColorFondo, "N", null, FontFactory.GetFont("Arial", 14.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.codPedidoCad, ColorFondo, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(oPedido.FecPedido).ToLongDateString().ToUpper(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion Encabezado

                    #region SubTitulos

                    Tabla = new PdfPTable(4);
                    Tabla.WidthPercentage = 100;
                    Tabla.SetWidths(new float[] { 0.05f, 0.3f, 0.04f, 0.05f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Señor(es): ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));

                    if (oPedido.idNotificar != null && oPedido.idNotificar > Variables.Cero)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desNotificador, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }
                    else
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desFacturar, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }

                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Dirección: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));

                    if (oPedido.idNotificar != null && oPedido.idNotificar > Variables.Cero)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.dirNotificador, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }
                    else
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }

                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C.: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));

                    if (oPedido.idNotificar != null && oPedido.idNotificar > Variables.Cero)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.RucNotificador, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }
                    else
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.RucCliente, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    }

                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Entrega: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.PuntoLlegada, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Condicion: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desCondicion, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("T.Cambio: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(TipoCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda("Vendedor: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.Vendedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
                    Tabla.CompleteRow();

                    DocumentoPdf.Add(Tabla);

                    #endregion SubTitulos

                    #region Detalle

                    Tabla = new PdfPTable(9)
                    {
                        WidthPercentage = 100
                    };
                    Tabla.SetWidths(new float[] { 0.06f, 0.05f, 0.075f, 0.25f,0.1f, 0.08f, 0.08f, 0.06f, 0.06f });

                    Tabla.AddCell(ReaderHelper.NuevaCelda("CANT. PEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("LOTE ALMACEN", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("LOTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("LOTE PROV.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("PRECIO UNITARIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();

                    foreach (PedidoDetE item in oPedido.ListaPedidoDet)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N0"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desUnidadMed, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.SiglaEmpresa + "-" + item.LoteAlmacen, null, "N", null, FontFactory.GetFont("Arial", 7.25f),1,1));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.LoteProveedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitario.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                        Tabla.AddCell(ReaderHelper.NuevaCelda((item.Cantidad * item.PrecioUnitario).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));

                        Tabla.CompleteRow();
                        //Total += item.Cantidad * item.PrecioUnitario;
                    }

                    #endregion Detalle

                    #region Final

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S9"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S6"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("      SUBTOTAL ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totsubTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S6"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("      IGV ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totIgv.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S6"));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("      TOTAL ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.AddCell(ReaderHelper.NuevaCelda(oPedido.totTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S9"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("TRANSPORTISTA: " + oPedido.RazonSocialTransporte + "     RUC: " + oPedido.RucTransporte, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S8"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S9"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("ATENCION: " + oPedido.Observacion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S8"));
                    Tabla.CompleteRow();

                    //Linea en blanco
                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S9"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("GUIA N°: " + oPedido.NroGuia, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S8"));
                    Tabla.CompleteRow();

                    Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("INDICACIONES: " + oPedido.Indicaciones, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S8"));
                    Tabla.CompleteRow();

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

        //void CrearPrevioBonificacion(BonificacionE oBonificacion_)
        //{
        //    Document DocumentoPdf = new Document(PageSize.A4, 25f, 25f, 30f, 30f);
        //    Guid Aleatorio = Guid.NewGuid();
        //    String NombreReporte = "Pedido " + Aleatorio.ToString();
        //    String Extension = ".pdf";
        //    String TituloCabecera = String.Empty;

        //    RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

        //    //Creando el directorio sino existe...
        //    if (!Directory.Exists(RutaPdf))
        //    {
        //        Directory.CreateDirectory(RutaPdf);
        //    }

        //    DocumentoPdf.AddAuthor("AMAZONTIC SAC");
        //    DocumentoPdf.AddCreator("AMAZONTIC SAC");
        //    DocumentoPdf.AddCreationDate();
        //    DocumentoPdf.AddTitle("Asistencia");
        //    DocumentoPdf.AddSubject("Asistencia");

        //    if (!String.IsNullOrEmpty(RutaPdf.Trim()))
        //    {

        //        ////Para la creacion del archivo pdf
        //        RutaPdf += NombreReporte + Extension;

        //        if (File.Exists(RutaPdf))
        //        {
        //            File.Delete(RutaPdf);
        //        }

        //        using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        //        {
        //            BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
        //            //iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
        //            PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
        //            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

        //            oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
        //            oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

        //            if (DocumentoPdf.IsOpen())
        //            {
        //                DocumentoPdf.CloseDocument();
        //            }

        //            DocumentoPdf.Open();

        //            #region Encabezado

        //            float[] AnchoColumnas = new float[] { 0.12f, 0.7f };
        //            PdfPTable Tabla = new PdfPTable(2);
        //            Tabla.WidthPercentage = 100;
        //            Tabla.SetWidths(AnchoColumnas);

        //            PdfPCell CeldaImagen = null;

        //            if (File.Exists(RutaImagen))
        //            {
        //                switch (VariablesLocales.SesionUsuario.Empresa.RUC)
        //                {
        //                    case "20502647009": //AgroGenesis - HuertoGenesis - Viveros
        //                    case "20523020561":
        //                    case "20517933318":
        //                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 125f, 1, "N"));
        //                        break;
        //                    case "20552695217": //Jeritec - AyV Seeds - Power Seeds
        //                    case "20552186681":
        //                    case "20552690410":
        //                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 100f, 1, "N"));
        //                        break;
        //                    default: //Otras Empresas...
        //                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 100f, 1, "N"));
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            }

        //            CeldaImagen.Rowspan = 2;
        //            Tabla.AddCell(CeldaImagen);

        //            Tabla.AddCell(ReaderHelper.NuevaCelda("SISTEMA DE CONTROL DE ASISTENCIA", null, "N", null, FontFactory.GetFont("Arial", 14.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            Tabla.CompleteRow();

        //            Tabla.AddCell(ReaderHelper.NuevaCelda("BONIFICACIONES A TRABAJADORES", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            Tabla.CompleteRow();

        //            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f), 1, 1, "S2"));
        //            Tabla.CompleteRow();

        //            DocumentoPdf.Add(Tabla);

        //            #endregion Encabezado

        //            #region SubTitulos

        //            Tabla = new PdfPTable(3);
        //            Tabla.WidthPercentage = 100;
        //            Tabla.SetWidths(new float[] { 0.1f, 0.35f, 0.1f });

        //            Tabla.AddCell(ReaderHelper.NuevaCelda("Concepto Bonificación: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD)));
        //            Tabla.AddCell(ReaderHelper.NuevaCelda(oBonificacion_.desBoniActividad, null, "N", null, FontFactory.GetFont("Arial", 8.25f)));
        //            Tabla.AddCell(ReaderHelper.NuevaCelda("Fecha: " + oBonificacion_.Fecha.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD)));
        //            Tabla.CompleteRow();

        //            Tabla.AddCell(ReaderHelper.NuevaCelda("Descripción: ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD)));
        //            Tabla.AddCell(ReaderHelper.NuevaCelda(oBonificacion_.Descripcion, null, "N", null, FontFactory.GetFont("Arial", 8.25f), -1, -1, "S2"));
        //            Tabla.CompleteRow();

        //            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f), -1, -1, "S3"));
        //            Tabla.CompleteRow();

        //            DocumentoPdf.Add(Tabla);

        //            #endregion SubTitulos

        //            #region Detalle

        //            Tabla = new PdfPTable(5);
        //            Tabla.WidthPercentage = 100;
        //            Tabla.SetWidths(new float[] { 0.04f, 0.08f, 0.5f, 0.09f, 0.09f });

        //            Tabla.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 5, 5));
        //            Tabla.AddCell(ReaderHelper.NuevaCelda("Nro.Doc", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 5, 5));
        //            Tabla.AddCell(ReaderHelper.NuevaCelda("Apellidos y Nombres", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 5, 5));
        //            Tabla.AddCell(ReaderHelper.NuevaCelda("Cantidad", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 5, 5));
        //            Tabla.AddCell(ReaderHelper.NuevaCelda("Monto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 5, 5));
        //            Tabla.CompleteRow();

        //            foreach (BonificacionDetalleE item in oBonificacion_.oListaBonificacion)
        //            {
        //                Tabla.AddCell(ReaderHelper.NuevaCelda(String.Format("{0:000}", item.Item), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
        //                Tabla.AddCell(ReaderHelper.NuevaCelda(item.nroDocumento, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
        //                Tabla.AddCell(ReaderHelper.NuevaCelda(item.desPersona, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //                Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 2));
        //                Tabla.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 2));

        //                Tabla.CompleteRow();
        //            }

        //            #endregion Detalle

        //            #region Final

        //            Tabla.AddCell(ReaderHelper.NuevaCelda("".PadRight(210, '-'), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1, "S5"));
        //            Tabla.CompleteRow();

        //            Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            Tabla.AddCell(ReaderHelper.NuevaCelda("INDICACIONES: " + oPedido.Indicaciones, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S6"));
        //            Tabla.CompleteRow();

        //            DocumentoPdf.Add(Tabla);

        //            #endregion Final

        //            // crear una nueva acción para enviar el documento a nuestro nuevo destino.
        //            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

        //            //Establecer la acción abierta para nuestro objeto escritor
        //            oPdfw.SetOpenAction(action);

        //            //Liberando memoria
        //            oPdfw.Flush();
        //            DocumentoPdf.Close();
        //        }
        //    }
        //}

        //void CrearPrevioRequerimiento(RequerimientosE oReque)
        //{
        //    Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
        //    Guid Aleatorio = Guid.NewGuid();
        //    String NombreReporte = "Requerimiento " + Aleatorio.ToString();
        //    String Extension = ".pdf";
        //    String TituloCabecera = String.Empty;
        //    String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        //    String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

        //    RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

        //    //Creando el directorio sino existe...
        //    if (!Directory.Exists(RutaPdf))
        //    {
        //        Directory.CreateDirectory(RutaPdf);
        //    }

        //    DocumentoPdf.AddAuthor("AMAZONTIC SAC");
        //    DocumentoPdf.AddCreator("AMAZONTIC SAC");
        //    DocumentoPdf.AddCreationDate();
        //    DocumentoPdf.AddTitle("Requerimientos");
        //    DocumentoPdf.AddSubject("Requerimientos");

        //    if (!String.IsNullOrEmpty(RutaPdf.Trim()))
        //    {
        //        //Para la creacion del archivo pdf
        //        RutaPdf += NombreReporte + Extension;

        //        if (File.Exists(RutaPdf))
        //        {
        //            File.Delete(RutaPdf);
        //        }

        //        using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        //        {
        //            //BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
        //            iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
        //            PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
        //            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

        //            oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
        //            oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

        //            if (DocumentoPdf.IsOpen())
        //            {
        //                DocumentoPdf.CloseDocument();
        //            }

        //            DocumentoPdf.Open();

        //            PdfContentByte cb = oPdfw.DirectContent;

        //            //Bottom left coordinates followed by width, height and radius of corners
        //            cb.RoundRectangle(15f, 728f, 570f, 20f, 5f);
        //            cb.Stroke();

        //            #region Encabezado

        //            PdfPTable table = new PdfPTable(2);
        //            table.WidthPercentage = 100;
        //            table.SetWidths(new float[] { 0.9f, 0.13f });
        //            table.HorizontalAlignment = Element.ALIGN_LEFT;

        //            table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        //            table.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        //            table.CompleteRow(); //Fila completada

        //            table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        //            table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        //            table.CompleteRow(); //Fila completada

        //            table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        //            table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
        //            table.CompleteRow(); //Fila completada

        //            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        //            table.CompleteRow();

        //            table.AddCell(ReaderHelper.NuevaCelda("REQUERIMIENTO N° " + oReque.numRequeri2 + "                                      Fec.Reque.: " + oReque.fecRequeri.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 1.2f, 1.2f));
        //            table.CompleteRow();

        //            table.AddCell(ReaderHelper.NuevaCelda("Centro Costo: " + oReque.desCCostos, null, "N", null, FontFactory.GetFont("Arial", 8.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        //            table.CompleteRow();

        //            table.AddCell(ReaderHelper.NuevaCelda("Observación: " + oReque.Glosa, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        //            table.CompleteRow();

        //            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        //            table.CompleteRow();

        //            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        //            table.CompleteRow();

        //            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        //            table.CompleteRow();

        //            DocumentoPdf.Add(table); //Añadiendo la tabla al documento PDF

        //            #endregion Encabezado

        //            #region SubTitulos

        //            PdfPTable TableDeta = new PdfPTable(6);
        //            TableDeta.WidthPercentage = 100;
        //            TableDeta.SetWidths(new float[] { 0.1f, 0.1f, 0.2f, 0.1f, 0.1f, 0.1f });
        //            //table.HorizontalAlignment = Element.ALIGN_LEFT;

        //            TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
        //            TableDeta.AddCell(ReaderHelper.NuevaCelda("Código", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
        //            TableDeta.AddCell(ReaderHelper.NuevaCelda("Articulo", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
        //            TableDeta.AddCell(ReaderHelper.NuevaCelda("Lote", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
        //            TableDeta.AddCell(ReaderHelper.NuevaCelda("Cantidad", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
        //            TableDeta.AddCell(ReaderHelper.NuevaCelda("U.Med.", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
        //            //TableDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
        //            TableDeta.CompleteRow();

        //            TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "S7", "N", 1.2f, 1.2f));
        //            TableDeta.CompleteRow();

        //            foreach (RequerimientosItemE item in oReque.ListaRequerimientosItems)
        //            {
        //                TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Item.ToString("000"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
        //                TableDeta.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
        //                TableDeta.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
        //                TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
        //                TableDeta.AddCell(ReaderHelper.NuevaCelda(item.cantRequerida.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
        //                TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));

        //                TableDeta.CompleteRow();
        //            }

        //            DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

        //            //Tabla = new PdfPTable(4);
        //            //Tabla.WidthPercentage = 100;
        //            //Tabla.SetWidths(new float[] { 0.05f, 0.3f, 0.04f, 0.05f });

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("Señor(es): ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.desFacturar, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("Dirección: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("R.U.C.: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.RucCliente, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("Entrega: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.PuntoLlegada, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("Condicion: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.desCondicion, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("T.Cambio: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(TipoCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("Vendedor: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.Vendedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S3"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S4"));
        //            //Tabla.CompleteRow();

        //            //DocumentoPdf.Add(Tabla);

        //            //#endregion SubTitulos

        //            //#region Detalle

        //            //Tabla = new PdfPTable(7);
        //            //Tabla.WidthPercentage = 100;
        //            //Tabla.SetWidths(new float[] { 0.06f, 0.05f, 0.09f, 0.4f, 0.09f, 0.06f, 0.06f });

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("CANTIDAD PEDIDA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("LOTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("PRECIO UNITARIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
        //            //Tabla.CompleteRow();

        //            //foreach (PedidoDetE item in oReque.ListaPedidoDet)
        //            //{
        //            //    Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N0"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
        //            //    Tabla.AddCell(ReaderHelper.NuevaCelda(item.desUnidadMed, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));
        //            //    Tabla.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 1, 1));

        //            //    if (item.indCalculo)
        //            //    {
        //            //        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //    }
        //            //    else
        //            //    {
        //            //        Tabla.AddCell(ReaderHelper.NuevaCelda(item.desArticuloCompuesto + " (BONIFICACION)", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //    }

        //            //    Tabla.AddCell(ReaderHelper.NuevaCelda(item.LoteProveedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //    Tabla.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitario.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
        //            //    Tabla.AddCell(ReaderHelper.NuevaCelda((item.Cantidad * item.PrecioUnitario).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));

        //            //    Tabla.CompleteRow();
        //            //}

        //            //#endregion Detalle

        //            //#region Final

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S7"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S4"));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("SUBTOTAL ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.totsubTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S4"));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("ISC ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.totIsc.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S4"));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("IGV ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.totIgv.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S4"));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("TOTAL ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(oReque.totTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
        //            //Tabla.CompleteRow();

        //            ////Linea en blanco
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S7"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("TRANSPORTISTA: " + oReque.RazonSocialTransporte, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S6"));
        //            //Tabla.CompleteRow();

        //            ////Linea en blanco
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S7"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("ATENCION: " + oReque.Observacion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S6"));
        //            //Tabla.CompleteRow();

        //            ////Linea en blanco
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S7"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("GUIA N°: " + oReque.NroGuia, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S6"));
        //            //Tabla.CompleteRow();

        //            //Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        //            //Tabla.AddCell(ReaderHelper.NuevaCelda("INDICACIONES: " + oReque.Indicaciones, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S6"));
        //            //Tabla.CompleteRow();

        //            //DocumentoPdf.Add(Tabla);

        //            #endregion Final

        //            // crear una nueva acción para enviar el documento a nuestro nuevo destino.
        //            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

        //            //Establecer la acción abierta para nuestro objeto escritor
        //            oPdfw.SetOpenAction(action);

        //            //Liberando memoria
        //            oPdfw.Flush();
        //            DocumentoPdf.Close();
        //        }
        //    }
        //}

        void CrearPrevioMovimientosAlmacen(List<MovimientoAlmacenE> oListaMovi)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Movimiento por OC " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Movimientos en Almacén");
            DocumentoPdf.AddSubject("Movimientos en Almacén");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    //BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;
                    cb.RoundRectangle(11.5f, 739f, 572f, 20f, 5f); //728f

                    //Color de linea
                    //cb.SetColorStroke(new CMYKColor(1f, 0f, 0f, 0f));
                    //cb.SetCMYKColorStroke(255, 255, 0, 0);
                    //cb.SetRGBColorStroke(0, 0, 0);
                    ////Color de fondo
                    //cb.SetColorFill(new CMYKColor(0f, 0f, 1f, 0f));
                    //cb.SetCMYKColorFill(0, 255, 255, 0);
                    cb.SetRGBColorFill(208, 206, 206);
                    cb.SetLineWidth(0.5f);
                    cb.ClosePathFillStroke();
                    cb.Fill();
                    cb.Stroke();

                    #region Encabezado

                    PdfPTable table = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };
                    table.SetWidths(new float[] { 0.9f, 0.13f });
                    table.HorizontalAlignment = Element.ALIGN_LEFT;

                    table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.CompleteRow(); //Fila completada

                    table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.CompleteRow(); //Fila completada

                    table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow(); //Fila completada

                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    table.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTOS EN ALMACEN", null, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    table.AddCell(ReaderHelper.NuevaCelda("N° O.C. " + oListaMovi[0].numOrdenCompra, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    //Lineas en Blanco
                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    DocumentoPdf.Add(table); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable TableDeta = new PdfPTable(8);
                    TableDeta.WidthPercentage = 100;
                    TableDeta.SetWidths(new float[] { 0.1f, 0.1f, 0.2f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f });

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Fec.Proceso", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("ID.", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("N° Correlativo", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Fec.Doc.", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Tip.Doc.", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Num.Doc.", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("T.D.Ref.", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Num.Doc.Ref", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 1.2f, 1.2f));
                    TableDeta.CompleteRow();

                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "S8", "N", 1.2f, 1.2f));
                    TableDeta.CompleteRow();

                    foreach (MovimientoAlmacenE item in oListaMovi)
                    {
                        //Por revisar//TableDeta.AddCell(ReaderHelper.NuevaCelda(item.fecProceso.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoAlmacen.ToString(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.numCorrelativo, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
                        //Por revisar//TableDeta.AddCell(ReaderHelper.NuevaCelda((item.fecDocumento == null ? " " : item.fecDocumento.Value.ToString("d")), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(String.IsNullOrWhiteSpace(item.serDocumento.Trim()) ? item.numDocumento : item.serDocumento + "-" + item.numDocumento, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoRef, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(String.IsNullOrWhiteSpace(item.SerieDocumentoRef.Trim()) ? item.NumeroDocumentoRef : item.SerieDocumentoRef + "-" + item.NumeroDocumentoRef, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "N", "N", 1.2f, 1.2f));

                        TableDeta.CompleteRow();
                    }

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

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

        void CrearPrevioMovimientosAlmacen(MovimientoAlmacenE oMovi)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Movimiento por OC " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Movimientos en Almacén");
            DocumentoPdf.AddSubject("Movimientos en Almacén");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String Docum = String.Empty;
                    String DocumRef = String.Empty;
                    BaseColor ColorFondo = new BaseColor(Color.Gray); //Gris Claro
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfPTable table = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    table.SetWidths(new float[] { 0.9f, 0.13f });
                    table.HorizontalAlignment = Element.ALIGN_LEFT;

                    #region Encabezado

                    table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.CompleteRow(); //Fila completada

                    table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.CompleteRow(); //Fila completada

                    table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow(); //Fila completada

                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    #endregion Encabezado

                    #region Titulos Principales

                    table.AddCell(ReaderHelper.NuevaCelda("Movimientos de Almacén", null, "N", null, FontFactory.GetFont("Arial", 13.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    table.AddCell(ReaderHelper.NuevaCelda(oMovi.Correlativo, null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    //Lineas en Blanco
                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 10.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                    table.CompleteRow();

                    DocumentoPdf.Add(table); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    #region Subtitulos

                    PdfPTable TablaSub = new PdfPTable(4);
                    TablaSub.WidthPercentage = 95;
                    TablaSub.SetWidths(new float[] { 0.15f, 0.4f, 0.11f, 0.2f });

                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" Almacén", ColorFondo, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0, "N", "N", 6f, 3f, "S", "S", "S", "S", 1.5f));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda("  " + oMovi.desAlmacen, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "N", "N", 6f, 3f));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" Fecha", ColorFondo, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0, "N", "N", 6f, 3f, "S", "S", "S", "S", 1.5f));
                    //Por revisar//TablaSub.AddCell(ReaderHelper.NuevaCelda("  " + oMovi.fecProceso.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "N", "N", 6f, 3f));
                    TablaSub.CompleteRow();

                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" Proveedor/Cliente", ColorFondo, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0, "N", "N", 6f, 3f, "S", "S", "S", "S", 1.5f));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda("  " + oMovi.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "N", "N", 6f, 3f));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" Operación", ColorFondo, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0, "N", "N", 6f, 3f, "S", "S", "S", "S", 1.5f));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda("  " + oMovi.desOperacion, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "N", "N", 6f, 3f));
                    TablaSub.CompleteRow();

                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" Doc. y Doc. Referencia", ColorFondo, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0, "N", "N", 6f, 3f, "S", "S", "S", "S", 1.5f));

                    if (!String.IsNullOrWhiteSpace(oMovi.serDocumento.Trim()))
                    {
                        Docum = oMovi.idDocumento + " " + oMovi.serDocumento + "-" + oMovi.numDocumento;
                    }
                    else
                    {
                        Docum = oMovi.idDocumento + " " + oMovi.numDocumento;
                    }

                    if (!String.IsNullOrWhiteSpace(oMovi.SerieDocumentoRef.Trim()))
                    {
                        if (oMovi.idDocumentoRef.Trim() == "0")
                        {
                            DocumRef = String.Empty;
                        }
                        else
                        {
                            DocumRef = " Ref. " + oMovi.idDocumentoRef + " " + oMovi.SerieDocumentoRef + "-" + oMovi.NumeroDocumentoRef;
                        }
                    }
                    else
                    {
                        if (oMovi.idDocumentoRef.Trim() == "0")
                        {
                            DocumRef = String.Empty;
                        }
                        else
                        {
                            DocumRef = " Ref. " + oMovi.idDocumentoRef + " " + oMovi.NumeroDocumentoRef;
                        }
                    }

                    TablaSub.AddCell(ReaderHelper.NuevaCelda("  " + Docum + DocumRef, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "N", "N", 6f, 3f));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" Fecha Doc.", ColorFondo, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0, "N", "N", 6f, 3f, "S", "S", "S", "S", 1.5f));
                    //Por revisar//TablaSub.AddCell(ReaderHelper.NuevaCelda((oMovi.fecDocumento != null ? "  " + oMovi.fecDocumento.Value.ToString("d") : ""), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "N", "N", 6f, 3f));
                    TablaSub.CompleteRow();

                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" Glosa", ColorFondo, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0, "N", "N", 6f, 3f, "S", "S", "S", "S", 1.5f));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda("  " + oMovi.Glosa, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" Orden De Compra", ColorFondo, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 0, "N", "N", 6f, 3f, "S", "S", "S", "S", 1.5f));
                    TablaSub.AddCell(ReaderHelper.NuevaCelda("  " + oMovi.numOrdenCompra, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "N", "N", 6f, 3f));
                    TablaSub.CompleteRow();

                    //Fila en blanco"
                    TablaSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "S4"));

                    DocumentoPdf.Add(TablaSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta = new PdfPTable(9)
                    {
                        WidthPercentage = 100
                    };

                    TableDeta.SetWidths(new float[] { 0.020f, 0.03f, 0.033f, 0.19f, 0.033f, 0.038f, 0.033f, 0.03f, 0.038f });

                    #region Detalle

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Lote Interno", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Código", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Unid. Med. Env.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Contenido", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Unid. Med. Pres.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Lote Almacen", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Cantidad", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    foreach (MovimientoAlmacenItemE item in oMovi.ListaAlmacenItem)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.numItem, null, "S", null, FuenteEstandar, 5, 1));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "S", null, FuenteEstandar, 5, 0));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "S", null, FuenteEstandar, 5, 1));

                        if (item.oArticulo != null)
                        {
                            if (!String.IsNullOrWhiteSpace(item.oArticulo.nomUMedidaPres.Trim()))
                            {
                                TableDeta.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo + " x " + item.oArticulo.Cantidad.ToString("N2") + " " + item.oArticulo.nomUMedidaPres, null, "S", null, FuenteEstandar, 5, 0));
                            }
                            else
                            {
                                TableDeta.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "S", null, FuenteEstandar, 5, 0));
                            }
                        }
                        else
                        {
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "S", null, FuenteEstandar, 5, 0));
                        }

                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.oArticulo.nomUMedidaEnv, null, "S", null, FuenteEstandar, 5, 0));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.oArticulo.Contenido.ToString("N2"), null, "S", null, FuenteEstandar, 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.oArticulo.nomUMedidaPres, null, "S", null, FuenteEstandar, 5, 0));                          
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.oLoteEntidad.LoteAlmacen, null, "S", null, FuenteEstandar, 5, 0));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N3"), null, "S", null, FuenteEstandar, 5, 2));

                        TableDeta.CompleteRow();
                    }

                    //Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 2, "S9"));
                    TableDeta.CompleteRow();
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 2, "S9"));
                    TableDeta.CompleteRow();

                    #endregion

                    #region Firma

                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S4", "N", 2, 2, "N", "S", "N", "N"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    TableDeta.CompleteRow();

                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(oMovi.NombreCompleto, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S4"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
                    TableDeta.CompleteRow(); 

                    #endregion

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

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

        void CrearPrevioMovimientosOC(OrdenCompraE OrdenCompra)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Orden de Compra " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Almacenes");
            DocumentoPdf.AddSubject("Ordenes de Compra");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    if (OrdenCompra.TipoOrdenCompra == "1")
                    {
                        TituloGeneral = "ORDEN DE COMPRA N° " + OrdenCompra.numOrdenCompra;
                    }

                    if (OrdenCompra.TipoOrdenCompra == "9")
                    {
                        TituloGeneral = "ORDEN DE SERVICIO N° " + OrdenCompra.numOrdenCompra;
                    }

                    BaseColor ColorFondo = new BaseColor(Color.LightGray); //Gris Claro
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    cb.RoundRectangle(12f, 752f, 570f, 41f, 10f);
                    cb.SetLineWidth(0.5f);
                    cb.Stroke();

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
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f), -1, -1, "S4"));
                    tableEncabezado.CompleteRow();

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(4);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f));
                        //switch (VariablesLocales.SesionUsuario.Empresa.RUC)
                        //{
                        //    case "20502647009": //AgroGenesis - HuertoGenesis - Viveros
                        //    case "20523020561":
                        //    case "20517933318":
                        //        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 250f, 1, "N"));
                        //        break;
                        //    case "20552695217": //Jeritec - AyV Seeds - Power Seeds
                        //    case "20552186681":
                        //    case "20552690410":
                        //        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f));
                        //        break;
                        //    default: //Otras Empresas...
                        //        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 200f, 1, "N"));
                        //        break;
                        //}
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 14f, 14f, "N", "N"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha Emisión:\n" + OrdenCompra.fecEmision.Date.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "N", "N", 8f, 8f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(6);
                    tableSub.WidthPercentage = 97;
                    tableSub.SetWidths(new float[] { 0.1f, 0.01f, 0.4f, 0.1f, 0.01f, 0.15f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Proveedor", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("RUC", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Forma de Pago", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.desFormaPago, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Fecha Requerida", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda((OrdenCompra.fecRequerida != null ? OrdenCompra.fecRequerida.Value.ToString("d") : " "), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Plazo Pago", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.numPlazoPago.ToString(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Plazo de Entrega", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.numPlazoEntrega.ToString(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Dirección", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.dirProveedor, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Dirección Entrega", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.LugarEntrega, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Contacto", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.NomContacto, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta1 = new PdfPTable(10);
                    TableDeta1.WidthPercentage = 98;
                    TableDeta1.SetWidths(new float[] { 0.05f, 0.5f, 0.09f, 0.05f, 0.09f, 0.09f, 0.05f, 0.10f, 0.05f, 0.10f });

                    #region Detalle

                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Uni.Med.Envase", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Contenido", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Uni.Med.Pres.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Cantidad", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Und.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Precio Unit. " + OrdenCompra.desMoneda, ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Desc (%)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.AddCell(ReaderHelper.NuevaCelda("Importe Total     " + OrdenCompra.desMoneda, ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta1.CompleteRow();

                    decimal TotalISC = 0;
                    decimal TotalIGV = 0;
                    decimal Total = 0;

                    foreach (OrdenCompraItemE item in OrdenCompra.ListaOrdenesCompras)
                    {
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.numItem, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "S", null, FontFactory.GetFont("Arial", 6.25f),5,1));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "S", null, FontFactory.GetFont("Arial", 6.25f),5,1));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.CanOrdenada.ToString("N4"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.nomUMedida, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.impPrecioUnitario.ToString("N6"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.porDescuento.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.impTotalItem.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta1.CompleteRow();

                        if (OrdenCompra.TipoOrdenCompra == "9")
                        {
                            TableDeta1.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                            TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.desLarga, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                            TableDeta1.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "8"));
                            TableDeta1.CompleteRow();
                        }

                        TotalISC += item.impIsc;
                        TotalIGV += item.impIgv;
                        Total += item.impTotalItem;
                    }

                    DocumentoPdf.Add(TableDeta1);

                    PdfPTable TableDeta = new PdfPTable(7);
                    TableDeta.WidthPercentage = 98;
                    TableDeta.SetWidths(new float[] { 0.05f, 0.5f, 0.09f, 0.05f, 0.10f, 0.05f, 0.10f });

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    TableDeta.CompleteRow();

                    //****************************************************** Totales ******************************************************//
                    //SubTotal
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "S4"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(Total.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                    TableDeta.CompleteRow();

                    //ISC
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "S4"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("I.S.C. " + OrdenCompra.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TotalISC.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                    TableDeta.CompleteRow();

                    //IGV
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "S4"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("I.G.V. " + VariablesLocales.oListaImpuestos[0].Porcentaje.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD),-1, 2, "S2"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TotalIGV.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                    TableDeta.CompleteRow();

                    //Total
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "S4"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("TOTAL " + OrdenCompra.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.impTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                    TableDeta.CompleteRow();



                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    TableDeta.CompleteRow();

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    TableDeta.CompleteRow();

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2, "S7"));
                    TableDeta.CompleteRow();



                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    ..................................................   ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    ..................................................   ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2, "S3"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.CompleteRow();



                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    ELABORADO POR : " + VariablesLocales.SesionUsuario.Credencial, null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    RECIBI CONFORME   ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2, "S3"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.CompleteRow();

                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("     FECHA Y HORA " + VariablesLocales.FechaHoy.ToString("G"), null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S3"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.CompleteRow();

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    TableDeta.CompleteRow();

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    TableDeta.CompleteRow();

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    TableDeta.CompleteRow();


                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    ..................................................   ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    ..................................................   ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2, "S3"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.CompleteRow();


                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    REVISADO POR : ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    AUTORIZADO POR :", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2, "S3"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.CompleteRow();

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                    #endregion

                    //PdfPTable TableFirmas = new PdfPTable(3);
                    //TableFirmas.WidthPercentage = 80;
                    //TableFirmas.SetWidths(new float[] { 0.1f, 0.1f, 0.1f });

                    //#region Firmas

                    //TableFirmas.AddCell(ReaderHelper.NuevaCelda("________________", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    //TableFirmas.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1, "N", "N"));
                    //TableFirmas.AddCell(ReaderHelper.NuevaCelda("________________", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    //TableFirmas.CompleteRow();

                    //TableFirmas.AddCell(ReaderHelper.NuevaCelda("SOLICITANTE", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    //TableFirmas.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    //TableFirmas.AddCell(ReaderHelper.NuevaCelda("RECIBIDO", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    //TableFirmas.CompleteRow();

                    //DocumentoPdf.Add(TableFirmas); //Añadiendo la tabla al documento PDF 

                    //#endregion

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

        void CrearPrevioCotizacion(PedidoCabE oPedido)
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
                TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Convert.ToDateTime(oPedido.FecPedido).ToString("yyyyMMdd"));
                Int32 Dias = AgenteVentas.Proxy.ObtenerDiasVencimiento(Convert.ToInt32(oPedido.idTipCondicion), Convert.ToInt32(oPedido.idCondicion));
                List<BancosCuentasE> oListaCuentas = AgenteMaestros.Proxy.ListarCuentasParaDoc(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oTica != null)
                {
                    decimal TipoCambio = oTica.valVenta;
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

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

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

                    Tabla = new PdfPTable(4);
                    Tabla.WidthPercentage = 95;
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
                                item.oArticulo = AgenteMaestros.Proxy.ObtenerImagenArticulo(item.oArticulo);

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

        void CrearPrevioOrdenConversion(OrdenConversionE Orden)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Orden de Conversion " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Almacenes");
            DocumentoPdf.AddSubject("Ordenes de Conversión");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = "ORDEN DE CONVERSION N° " + Orden.Numero;

                    BaseColor ColorFondo = new BaseColor(Color.LightGray); //Gris Claro
                    //iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    cb.RoundRectangle(12f, 752f, 570f, 41f, 10f);
                    cb.SetLineWidth(0.5f);
                    cb.Stroke();

                    PdfPTable tableEncabezado = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };
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
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f), -1, -1, "S4"));
                    tableEncabezado.CompleteRow();

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(4)
                    {
                        WidthPercentage = 100
                    };
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

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
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 14f, 14f, "N", "N"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha:\n" + Orden.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "N", "N", 8f, 8f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(6)
                    {
                        WidthPercentage = 97
                    };
                    tableSub.SetWidths(new float[] { 0.1f, 0.01f, 0.4f, 0.12f, 0.01f, 0.15f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "N", "N", 1f, 1f));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "N", "N", 1f, 1f));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 1f, 1f));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Fecha De La Conversion", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "N", "N", 1f, 1f));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0, "N", "N", 1f, 1f));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(Orden.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 1f, 1f));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    #region Salidas

                    PdfPTable TableDetaSal = new PdfPTable(13)
                    {
                        WidthPercentage = 98
                    };
                    TableDetaSal.SetWidths(new float[] { 0.1f, 0.13f, 0.14f, 0.14f, 0.4f, 0.13f, 0.1f, 0.15f, 0.15f, 0.15f,0.15f, 0.15f, 0.15f });

                    #region Detalle 1

                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("ORDEN CONVERSION SALIDAS", ColorFondo, "S", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 5, 1, "S13", "N", 4f, 4f));
                    TableDetaSal.CompleteRow();

                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Almacen", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Lote Interno", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Código", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Unidad Env.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Contenido", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Unidad Pres.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Lote Almacen", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Cantidad", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Peso Unitario", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Peso Total", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("Stock", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.CompleteRow();

                    Decimal TotalCantidad = 0;
                    Decimal TotalPesos = 0;
                    int Correlativo = 1;

                    foreach (OrdenConversionSalidaE item in Orden.ListaConverSalida)
                    {
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(Correlativo.ToString(), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.nomAlmacen, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.NombreArt, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.contenido.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.LoteAlmacen, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.CantSolicitada.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.PesoUnitario.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.TotalPeso.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDetaSal.AddCell(ReaderHelper.NuevaCelda(item.Stock.Value.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDetaSal.CompleteRow();

                        Correlativo++;
                        TotalCantidad += item.CantSolicitada;
                        TotalPesos += item.TotalPeso;
                    }

                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda("SUB TOTAL:", null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(TotalCantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(TotalPesos.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4f, 4f));
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDetaSal.CompleteRow();

                    ////Filas en blanco
                    TableDetaSal.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S13"));
                    TableDetaSal.CompleteRow();

                    DocumentoPdf.Add(TableDetaSal);

                    #endregion

                    #endregion

                    #region Entradas

                    PdfPTable TableDeta = new PdfPTable(13)
                    {
                        WidthPercentage = 98
                    };

                    TableDeta.SetWidths(new float[] { 0.13f, 0.08f, 0.15f, 0.15f, 0.4f, 0.13f, 0.1f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f });

                    #region Detalle 2

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("ORDEN CONVERSION ENTRADAS", ColorFondo, "S", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 5, 1, "S13", "N", 4f, 4f));
                    TableDeta.CompleteRow();
            
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Almacen", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Lote Interno", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Código", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Unidad Env.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Contenido", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Unidad Pres.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Lote Almacen", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Cantidad", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Peso Unitario", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Peso Total", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Stock", ColorFondo, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    Decimal TotalCantidad2 = 0;
                    Decimal TotalPesos2 = 0;
                    Int32 ItemCorre = 1;

                    foreach (OrdenConversionDetalleE item in Orden.ListaConverDetalle)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(ItemCorre.ToString(), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.nomAlmacen, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.NombreArt, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.contenido.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.LoteAlmacen, null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.PesoUnitario.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.TotalPeso.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("0", null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2, "N", "N", 4f, 4f));
                        TableDeta.CompleteRow();

                        TotalCantidad2 += item.Cantidad;
                        TotalPesos2 += item.TotalPeso;
                        ItemCorre++;
                    }

                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("SUB TOTAL:", null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TotalCantidad2.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TotalPesos2.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S13"));
                    TableDeta.CompleteRow();
                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                    #endregion

                    #endregion

                    #region Firma

                    PdfPTable TableFirmas = new PdfPTable(3)
                    {
                        WidthPercentage = 80
                    };

                    TableFirmas.SetWidths(new float[] { 0.1f, 0.1f, 0.1f });

                    TableFirmas.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    TableFirmas.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1, "N", "N"));
                    TableFirmas.AddCell(ReaderHelper.NuevaCelda("________________", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    TableFirmas.CompleteRow();

                    TableFirmas.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    TableFirmas.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    TableFirmas.AddCell(ReaderHelper.NuevaCelda(Orden.NombreCompleto, null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, 1));
                    TableFirmas.CompleteRow();

                    DocumentoPdf.Add(TableFirmas); //Añadiendo la tabla al documento PDF 

                    #endregion

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

        void CrearPrevioOrdenPago(OrdenPagoE OrdenP)
        {
            String ConDetalle = Variables.NO;
            Document DocumentoPdf = null;

            if (OrdenP.ListaOrdenPago.Count > 0)
            {
                ConDetalle = Variables.SI;
            }

            DocumentoPdf = new Document((ConDetalle == "S" ? PageSize.A4.Rotate() : PageSize.A4), 15f, 15f, 15f, 15f);

            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Orden de Pago " + OrdenP.codOrdenPago + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Tesoreria");
            DocumentoPdf.AddSubject("Ordenes de Pago");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = " ORDEN DE PAGO N° " + OrdenP.codOrdenPago;

                    BaseColor ColorFondo = new BaseColor(169, 208, 142); //Gris Claro
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    if (ConDetalle == Variables.NO)
                    {
                        cb.RoundRectangle(12f, 748f, 570f, 41f, 10f);
                    }
                    else
                    {
                        cb.RoundRectangle(12f, 483.5f, 815f, 60f, 10f);
                    }

                    cb.SetLineWidth(1.5f);
                    cb.Stroke();

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

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(4);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 5f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 13f, 13f, "N", "N"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha:\n" + OrdenP.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", (ConDetalle == "N" ? 8.25f : 10.25f)), 5, 1, "N", "N", 10f, 10f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(6);
                    tableSub.WidthPercentage = 97;
                    tableSub.SetWidths(new float[] { 0.1f, 0.01f, 0.4f, 0.12f, 0.01f, 0.15f });

                    #region Subtitulos

                    if (ConDetalle == Variables.NO)
                    {
                        tableSub.AddCell(ReaderHelper.NuevaCelda("Auxiliar", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenP.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda("RUC", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenP.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                        tableSub.CompleteRow();

                        tableSub.AddCell(ReaderHelper.NuevaCelda("Beneficiario", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenP.idPersonaBeneficiario.ToString() + " - " + OrdenP.NombreBen, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                        tableSub.CompleteRow();

                        tableSub.AddCell(ReaderHelper.NuevaCelda("Monto", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda((OrdenP.idMoneda == Variables.Soles ? "S/. " : "US$ ") + "  " + OrdenP.Monto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                        tableSub.CompleteRow();

                        tableSub.AddCell(ReaderHelper.NuevaCelda("Glosa", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(OrdenP.Glosa, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                        tableSub.CompleteRow(); 
                    }
                    else
                    {
                        tableSub.AddCell(ReaderHelper.NuevaCelda("Sucursal", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 0));
                        tableSub.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionLocal.Nombre, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    }

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    if (ConDetalle == Variables.SI)
                    {
                        PdfPTable TableDeta = new PdfPTable(15);
                        TableDeta.WidthPercentage = 100;
                        TableDeta.SetWidths(new float[]{ 0.04f, 0.075f, 0.035f, 0.1f, 0.4f, 0.3f, 0.045f, 0.09f, 0.045f, 0.08f, 0.1f, 0.15f, 0.048f, 0.067f, 0.067f });
                        String M1 = (from z in VariablesLocales.ListaMonedas where z.idMoneda == Variables.Soles select z.desAbreviatura).FirstOrDefault();
                        String M2 = (from z in VariablesLocales.ListaMonedas where z.idMoneda == Variables.Dolares select z.desAbreviatura).FirstOrDefault();

                        #region Detalle

                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Documento", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Concepto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Mon.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Total", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Detalle de Pago", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Detracción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S3", "N", 4f, 4f));
                        TableDeta.CompleteRow();

                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Emisión", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("TD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Nro Doc.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Tercero", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Mon.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("T.Pago", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("F.Pago", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Cta.Proveedor", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("%", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Imp." + M1, ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Imp." + M2, ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                        TableDeta.CompleteRow();

                        Int32 ItemCorre = 1;
                        Decimal totSoles = 0;
                        Decimal totDolares = 0;

                        foreach (OrdenPagoDetE item in OrdenP.ListaOrdenPago)
                        {
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(ItemCorre.ToString("00"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Fecha.ToString("dd/MM/yyyy"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.serDocumento + "-" + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desProveedor, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Concepto, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desMonedaBanco, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda((item.idMoneda == "01" ? item.Monto - item.MontoDetraS : item.Monto - item.MontoDetraD).ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda((item.Dias == 0 ? "CONTADO" : item.Dias.ToString() + " DIAS"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desBanco + " " + item.numCtaBancaria, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.porDetraccion.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.MontoDetraS.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.AddCell(ReaderHelper.NuevaCelda(item.MontoDetraD.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                            TableDeta.CompleteRow();

                            if (item.idMoneda == Variables.Soles)
                            {
                                totSoles += item.Monto;
                            }
                            else
                            {
                                totDolares += item.Monto;
                            }

                            ItemCorre++;
                        }

                        ////Ultimas filas
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Totales   ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S8"));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("S/.", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(totSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("Totales Detracción", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S2"));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(OrdenP.ListaOrdenPago.Sum(x => x.MontoDetraS).ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(OrdenP.ListaOrdenPago.Sum(x => x.MontoDetraD).ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.CompleteRow();

                        TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S8"));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda("US$", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(totDolares.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S5"));
                        TableDeta.CompleteRow();

                        DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                        #endregion 
                    }

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

        void CrearPrevioOrdenTrabajoServ(OrdenTrabajoServicioE oOrdenTrabajoServ)
        {
            String ConDetalle = Variables.NO;
            Document DocumentoPdf = null;           

            if (oOrdenTrabajoServ.ListaItemsOrdenTrabajo.Count > 0)
            {
                ConDetalle = Variables.SI;
            }

            DocumentoPdf = new Document((ConDetalle == "S" ? PageSize.A4.Rotate() : PageSize.A4), 15f, 15f, 15f, 15f);

            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Orden de Trabajo " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Ventas");
            DocumentoPdf.AddSubject("Ordenes de Trabajo");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = " ORDEN DE TRABAJO " ;

                    BaseColor ColorFondo = new BaseColor(169, 208, 142); //Gris Claro
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    if (ConDetalle == Variables.NO)
                    {
                        cb.RoundRectangle(12f, 748f, 570f, 41f, 10f);
                    }
                    else
                    {
                        cb.RoundRectangle(12f, 500f, 815f, 41f, 10f);
                    }

                    cb.SetLineWidth(0.5f);
                    cb.Stroke();

                    PdfPTable tableEncabezado = new PdfPTable(2);
                    tableEncabezado.WidthPercentage = 100;
                    tableEncabezado.SetWidths(new float[] { 0.9f, 0.13f });

                    #region Encabezado

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); 

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow();

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); 

                    //Filas en blanco
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f), -1, -1, "S4"));
                    tableEncabezado.CompleteRow();

                    DocumentoPdf.Add(tableEncabezado);

                    #endregion Encabezado

                    #region Titulos Principales

                    PdfPTable tableTitulos = new PdfPTable(4);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        //CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f));
                        //ReaderHelper.ImagenCellAbosoluta
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 135f, 30f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 14f, 14f, "N", "N"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha Emisión:\n" + oOrdenTrabajoServ.FechaEmision.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "N", "N", 8f, 8f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos);



                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(6);
                    tableSub.WidthPercentage = 97;
                    tableSub.SetWidths(new float[] { 0.1f, 0.01f, 0.4f, 0.1f, 0.01f, 0.15f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Proveedor", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("RUC", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Area", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.desArea, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Fecha Emisión", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda((oOrdenTrabajoServ.FechaEmision != null ? oOrdenTrabajoServ.FechaEmision.ToString("d") : " "), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Dirección", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.Direccion.ToString(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Estado", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.Estado, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Observaciones", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.Observacion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta = new PdfPTable(12);
                    TableDeta.WidthPercentage = 100;
                    TableDeta.SetWidths(new float[] { 0.05f, 0.1f,0.15f, 0.15f, 0.15f,   0.05f,   0.05f, 0.1f, 0.05f, 0.05f ,0.05f, 0.05f });

                    #region Detalle

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Codigo", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Servicio", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Centro de Costos", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Fec. Entrega", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Cantidad", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Moneda", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Precio Unit. " , ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Valor Venta", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("IGV", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Importe Total " , ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
       
                    TableDeta.CompleteRow();



                    foreach (OrdenTrabajoServicioItemE item in oOrdenTrabajoServ.ListaItemsOrdenTrabajo)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Item, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desCostos, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Descripcion, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda((item.FechaEntrega != null ? item.FechaEntrega.Value.ToString("d") : " "), null, "S", null, FontFactory.GetFont("Arial", 6.25f)));


                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f),-1,2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Moneda, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitario.ToString("N6"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.ValorVenta.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Igv.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Total.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.CompleteRow();

                    }

                    //////Filas en blanco
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    //TableDeta.CompleteRow();

                    ////****************************************************** Totales ******************************************************//
                    ////IGV
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "S4"));
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda("I.G.V. " + VariablesLocales.oListaImpuestos[0].Porcentaje.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2"));
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(TotalIGV.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                    //TableDeta.CompleteRow();

                    ////Total
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "S4"));
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda("TOTAL " + OrdenCompra.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2"));
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.impTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                    //TableDeta.CompleteRow();

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                    #endregion

                    //#endregion

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

        void CrearPrevioLiquidacion(LiquidacionE oLiqui)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Liquidación " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Tesoreria");
            DocumentoPdf.AddSubject("Liquidacion");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;
                    String Subtitulo = String.Empty;

                    TituloGeneral = oLiqui.Titulo;
                    Subtitulo = oLiqui.idLiquidacion.ToString("00000") + " - AÑO - " + oLiquidacion.Fecha.ToString("yyyy");

                    BaseColor ColorFondo = new BaseColor(Color.LightGray); //Gris Claro
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    cb.RoundRectangle(12f, 748f, 570f, 41f, 10f);
                    cb.SetLineWidth(0.5f);
                    cb.Stroke();

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

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(4);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 135f, 30f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha:\n" + oLiqui.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1));
                    tableTitulos.CompleteRow();
                    
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(Subtitulo, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(4);
                    tableSub.WidthPercentage = 97;
                    tableSub.SetWidths(new float[] { 0.1f, 0.5f, 0.2f, 0.4f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Persona: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("RUC/DNI: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("O.P.: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.codOrdenPago, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Periodo: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Del " + oLiqui.PeriodoIni.Day + " " + FechasHelper.NombreMes(oLiqui.PeriodoIni.Month) + " " + oLiqui.PeriodoIni.Year + " Al " + oLiqui.PeriodoFin.Day + " " + FechasHelper.NombreMes(oLiqui.PeriodoFin.Month) + " " + oLiqui.PeriodoFin.Year, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta = new PdfPTable(13);
                    TableDeta.WidthPercentage = 100;
                    TableDeta.SetWidths(new float[] { 0.04f, 0.07f, 0.035f, 0.08f, 0.26f, 0.1f, 0.04f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f });

                    #region Detalle

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Fecha Doc", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Documento", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Razón Social y/o Nombre", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Detalle/Concepto", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Mon", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Valor Venta S/", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("IGV S/", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Precio Venta S/.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Valor Venta US$.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("IGV US$", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Precio Venta US$.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.CompleteRow();

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("T.D.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Número", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    Decimal TOTVVSOLES = 0;
                    Decimal TOTALIGVSOLES = 0;
                    Decimal TOTALSOLES = 0;
                    Decimal TOTVVDOLARES = 0;
                    Decimal IGVDOLARES = 0;
                    Decimal TOTALDOLARES = 0;
                    Int32 Correlativo = 1;

                    foreach (LiquidacionDetE item in oLiqui.ListaLiquidacionDet)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(Correlativo.ToString(), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.Value.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.numSerie + "-" + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Glosa, null, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.VVentaSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.IgvSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.TotalSoles.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.VVentaDolar.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.IgvDolar.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.TotalDolar.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));

                        TOTVVSOLES += item.VVentaSoles;
                        TOTALIGVSOLES += item.IgvSoles;
                        TOTALSOLES += item.TotalSoles;
                        TOTVVDOLARES += item.VVentaDolar;
                        IGVDOLARES += item.IgvDolar;
                        TOTALDOLARES += item.TotalDolar;
                        Correlativo++;
                        TableDeta.CompleteRow();
                    }

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S13"));
                    TableDeta.CompleteRow();

                    ////Ultima Fila
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "S5"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("<< TOTALES >>", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTVVSOLES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTALIGVSOLES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTALSOLES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTVVDOLARES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(IGVDOLARES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(TOTALDOLARES.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                    #endregion

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

        void CrearPrevioSolicitud(SolicitudProveedorE oSolicitud_)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "SolicitudProveedor " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Tesoreria");
            DocumentoPdf.AddSubject("Solicitud de Proveedor");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    if (oSolicitud_.TipoSolicitud == "P")
                    {
                        TituloGeneral = "SOLICITUD DE FONDO - PERSONAL";
                    }
                    else if(oSolicitud_.TipoSolicitud == "T")
                    {
                        TituloGeneral = "SOLICITUD DE FONDO - TERCERO";
                    }
                    else
                    {
                        TituloGeneral = "SOLICITUD DE ADELANTO - PROVEEDOR";
                    }

                    BaseColor ColorFondo = new BaseColor(189, 215, 238);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    cb.RoundRectangle(12f, 728f, 570f, 60f, 10f);
                    cb.SetLineWidth(0.5f);
                    cb.Stroke();

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

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(4);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        //System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);

                        //if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217") //Solo para Jeritec porque su imagen es un alto
                        //{
                        //    CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellPorcentaje(Img, 1, 5f, "S", 130));
                        //}
                        //else
                        //{
                        //    CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellPorcentaje(Img, 1, 10f, "S", 180));
                        //}

                        //Img = null;

                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 5f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD, new BaseColor(84, 130, 53)), 5, 1, "S3", "N", 13f, 13f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(6);
                    tableSub.WidthPercentage = 97;
                    tableSub.SetWidths(new float[] { 0.1f, 0.01f, 0.4f, 0.12f, 0.01f, 0.15f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Nro Documento", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.codSolicitud, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Fecha", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.Fecha.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Proveedor", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Sucursal", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.desLocal, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Cuenta", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.ctaBancaria, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Orden Pago", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.codOrdenPago, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Monto", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.desMoneda+' '+oSolicitud_.impTotal.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Tasa", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.oListaSolicitudes[0].Tasa.ToString("N2") + "%", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Nro. O/S - O/C", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.Pedido, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Descripción", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "S5"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(oSolicitud_.Descripcion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S6"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    //tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S6"));
                    //tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Detalle: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta = new PdfPTable(4);
                    TableDeta.WidthPercentage = 90;
                    TableDeta.SetWidths(new float[] { 0.05f, 0.05f, 0.25f, 0.05f });

                    #region Detalle

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("LINEA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("CANTIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("PRODUCTO/SERVICIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("MONTO TOTAL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    foreach (SolicitudProveedorDetE item in oSolicitud_.oListaSolicitudes)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Item.ToString(), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString(), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desConcepto, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Importe.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 3f, 3f));

                        tableSub.CompleteRow();
                    }

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                    #endregion

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

        void CrearPrevioRendiciones(List<SolicitudProveedorRendicionDetE> oListaRendiciones_)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Rendicion " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Tesoreria");
            DocumentoPdf.AddSubject("Rendición de Proveedor");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = "RENDICION DE ADELANTO PROVEEDOR";

                    BaseColor ColorFondo = new BaseColor(189, 215, 238);
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    cb.RoundRectangle(12f, 728f, 570f, 60f, 10f);
                    cb.SetLineWidth(0.5f);
                    cb.Stroke();

                    PdfPTable tableEncabezado = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };
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

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(4)
                    {
                        WidthPercentage = 100
                    };
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);

                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217") //Solo para Jeritec porque su imagen es un alto
                        {
                            CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellPorcentaje(Img, 1, 5f, "S", 130));
                        }
                        else
                        {
                            CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellPorcentaje(Img, 1, 10f, "S", 180));
                        }

                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD, new BaseColor(84, 130, 53)), 5, 1, "S3", "N", 13f, 13f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(6)
                    {
                        WidthPercentage = 100
                    };
                    tableSub.SetWidths(new float[] { 0.1f, 0.01f, 0.4f, 0.08f, 0.01f, 0.19f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Nro Documento", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].codSolicitud, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Proveedor", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Fecha Registro", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].fecOperacion.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Monto Depositado", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].desMoneda + " " + oListaRendiciones_[0].MontoDepositado.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Registrado por", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].UsuarioRegistro, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Monto Rendido", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].desMoneda + " " + oListaRendiciones_.Sum(x => x.MontoRec).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));

                    tableSub.AddCell(ReaderHelper.NuevaCelda("C.Bancaria", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].ctaBanco, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Saldo por Rendir", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    //tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].desMoneda + " " + (oListaRendiciones_.Sum(x => x.MontoRec) - oListaRendiciones_[0].MontoDepositado).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].desMoneda + " " + oListaRendiciones_[0].SaldoSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Sucursal", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].desLocal, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Descripción", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "S5"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(oListaRendiciones_[0].Glosa, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S6"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Detalle: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta = new PdfPTable(6)
                    {
                        WidthPercentage = 100
                    };
                    TableDeta.SetWidths(new float[] { 0.02f, 0.04f, 0.02f, 0.05f, 0.3f, 0.05f });

                    #region Detalle

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("ITEM", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("FECHA EMISION", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("TIPO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("NRO DOCUMENTO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("CONCEPTO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("IMPORTE TOTAL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    foreach (SolicitudProveedorRendicionDetE item in oListaRendiciones_)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Item.ToString(), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.fecDocumento.ToString("dd/MM/yyyy"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.numSerie + "-" + item.numDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desConcepto, null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.MontoDoc.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2, "N", "N", 3f, 3f));

                        tableSub.CompleteRow();
                    }

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                    #endregion

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

        void CrearPrevioConciliadosYnoConciliados(List<CobranzasItemE> ListaCobranzasItems)
        {
            Document DocumentoPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Conciliacion Cobranzas " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Cobranzas");
            DocumentoPdf.AddSubject("Reporte Conciliados");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = "REPORTE DE COBRANZAS CONCILIADAS Y NO CONCILIADAS";

                    BaseColor ColorFondo1 = new BaseColor(0, 102, 204); //Cabeceras del detalle conciliados
                    BaseColor ColorLetraDet = new BaseColor(0, 0, 128); //Letra del detalle
                    BaseColor ColorLetraTitulos = new BaseColor(0, 51, 102); //Letra del titulo
                    BaseColor ColorLetraSub = new BaseColor(51, 51, 153); //Letra del subtitulo

                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    #region Encabezado

                    PdfPTable tableEncabezado = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    tableEncabezado.SetWidths(new float[] { 0.9f, 0.13f });

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

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    #region Titulos Principales

                    PdfPTable tableTitulos = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    tableTitulos.SetWidths(new float[] { 0.03f, 0.2f });
                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f)) { Rowspan = 2 };
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                        CeldaImagen.Rowspan = 2;
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 1, "N", "N", 4f, 5f));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD, ColorLetraSub), 5, 1, "N", "N", 5f, 5f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion 

                    #region Detalle

                    PdfPTable TablaDeta = new PdfPTable(11)
                    {
                        WidthPercentage = 100
                    };

                    TablaDeta.SetWidths(new float[] { 0.2f, 0.03f, 0.05f, 0.07f, 0.06f, 0.12f, 0.02f, 0.2f, 0.05f, 0.07f, 0.06f });
                    List<String> ListaTitulos = new List<String>
                    {
                        "Cuenta Bancaria",
                        "Mon.",
                        "Fec. Cob.",
                        "N° de Operación",
                        "Importe",
                        "Núm.Doc.",
                        "Glosa"
                    };

                    List<CobranzasItemE> Lista1 = ListaCobranzasItems.Where(x => x.Orden == 1).ToList();
                    List<CobranzasItemE> Lista2 = ListaCobranzasItems.Where(x => x.Orden == 2).ToList();
                    List<CobranzasItemE> Lista3 = (from x in ListaCobranzasItems where x.Orden == 3 select x).ToList();
                    List<CobranzasItemE> Lista4 = (from x in ListaCobranzasItems where x.Orden == 4 select x).ToList();
                    Int32 ItemCorre = 1;

                    if (Lista1.Count > 0)
                    {
                        #region Titulos del detalle

                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("LIBRO BANCO CONCILIADO", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S6", "N", 5f, 5f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("N°", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "S2", 5f, 5f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("EE.CC. CONCILIADO", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S4", "N", 5f, 5f));

                        TablaDeta.CompleteRow();

                        //Titulos Lista 1
                        foreach (String item in (from x in ListaTitulos where x != "Glosa" select x).ToList())
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item, ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                        }

                        //Titulos Lista 2
                        foreach (String item in (from x in ListaTitulos where x != "Mon." && x != "Núm.Doc." && x != "Glosa" select x).ToList())
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item, ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                        }

                        TablaDeta.CompleteRow();

                        #endregion

                        #region Detalle

                        //Lista 1
                        foreach (CobranzasItemE item in Lista1)
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.CuentaBancaria, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                            if (item.fecCobranza == null)
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 1));
                            }
                            else
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.fecCobranza.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                            }

                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Operacion, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.codPlanilla, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(ItemCorre.ToString(), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));

                            ItemCorre++;

                            //Lista 2
                            foreach (CobranzasItemE item2 in Lista2)
                            {
                                if (item.fecCobranza.Value.ToString("dd/MM/yy") == item2.fecCobranza.Value.ToString("dd/MM/yy") && item.Operacion == item2.Operacion && item.Monto == item2.Monto)
                                {
                                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item2.CuentaBancaria, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                                    if (item.fecCobranza == null)
                                    {
                                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 1));
                                    }
                                    else
                                    {
                                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item2.fecCobranza.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                                    }

                                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item2.Operacion, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(item2.Monto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));
                                    break;
                                }
                            }
                        }
                        
                        #endregion
                    }

                    if (Lista3.Count > 0)
                    {
                        //Fila en blanco
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "S11"));

                        #region Titulos del detalle

                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("LIBRO BANCO NO CONCILIADO", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S6", "N", 5f, 5f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S5", "N", 5f, 5f));
                        TablaDeta.CompleteRow();

                        //Titulos
                        foreach (String item in (from x in ListaTitulos where x != "Glosa" select x).ToList())
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item, ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                        }

                        //Titulos en blanco
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S5", "N", 5f, 5f));
                        TablaDeta.CompleteRow();

                        #endregion

                        #region Detalle

                        foreach (CobranzasItemE item in Lista3)
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.CuentaBancaria, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                            if (item.fecCobranza == null)
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 1));
                            }
                            else
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.fecCobranza.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                            }

                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Operacion, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.codPlanilla, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                            //Titulos en blanco
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 1, "S5", "N", 5f, 5f));
                            TablaDeta.CompleteRow();
                        }

                        #endregion
                    }

                    if (Lista4.Count > 0)
                    {
                        //Fila en blanco
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0, "S11"));

                        #region Titulos del detalle

                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("EE.CC. NO CONCILADO", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S6", "N", 5f, 5f));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S5", "N", 5f, 5f));
                        TablaDeta.CompleteRow();

                        //Titulos
                        foreach (String item in (from x in ListaTitulos where x != "Núm.Doc." select x).ToList())
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item, ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                        }

                        //Titulos en blanco
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S5", "N", 5f, 5f));
                        TablaDeta.CompleteRow();

                        #endregion

                        #region Detalle
                        
                        foreach (CobranzasItemE item in Lista4)
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.CuentaBancaria, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                            if (item.fecCobranza == null)
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 1));
                            }
                            else
                            {
                                TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.fecCobranza.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                            }

                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Operacion, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.GlosaBanco, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                            //Titulos en blanco
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 1, "S5", "N", 5f, 5f));
                            TablaDeta.CompleteRow();
                        } 

                        #endregion
                    }

                    DocumentoPdf.Add(TablaDeta); //Añadiendo la tabla al documento PDF

                    #endregion

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

        void CrearPrevioLiquidacionImportacion(LiquidacionImportacionE oLiqui)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Liquidación Importación " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Tesoreria");
            DocumentoPdf.AddSubject("Liquidacion");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = "Liquidación de Importación";
                    String Subtitulo = oLiqui.codLiquidacion + " - AÑO - " + oLiqui.Fecha.ToString("yyyy");

                    BaseColor ColorFondo = new BaseColor(Color.LightGray); //Gris Claro
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    cb.RoundRectangle(12f, 748f, 570f, 41f, 10f);
                    cb.SetLineWidth(0.5f);
                    cb.Stroke();

                    PdfPTable tableEncabezado = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

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

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    PdfPTable tableTitulos = new PdfPTable(4)
                    {
                        WidthPercentage = 100
                    };

                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    #region Titulos Principales

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 135f, 30f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha:\n" + oLiqui.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1));
                    tableTitulos.CompleteRow();

                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(Subtitulo, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(4)
                    {
                        WidthPercentage = 97
                    };

                    tableSub.SetWidths(new float[] { 0.1f, 0.7f, 0.12f, 0.29f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Proveedor: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("RUC/DNI: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Monto: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.desMoneda + " " + oLiqui.Importe.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Liquidación: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda((String.IsNullOrWhiteSpace(oLiqui.numSerie) ? oLiqui.numDocumento : oLiqui.numSerie + "-" + oLiqui.numDocumento), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Glosa: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oLiqui.Glosa.Trim(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S3"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta = new PdfPTable(9)
                    {
                        WidthPercentage = 100
                    };

                    TableDeta.SetWidths(new float[] { 0.03f, 0.05f, 0.035f, 0.08f, 0.39f, 0.03f, 0.07f, 0.03f, 0.07f });

                    #region Detalle

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Fecha Doc", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Documento", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Razón Social y/o Nombre", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Mon", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Importe S/.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("T.C.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Importe US$.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4f, 4f));
                    TableDeta.CompleteRow();

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("T.D.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Número", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    Decimal totSoles = 0;
                    Decimal totDolares = 0;
                    Int32 Correlativo = 1;

                    foreach (LiquidacionImportacionDetE item in oLiqui.oListaImportacionesDet)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(Correlativo.ToString(), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda((String.IsNullOrWhiteSpace(item.numSerie) ? item.numDocumento :item.numSerie + "-" + item.numDocumento), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.SolesRec.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.TipoCambio.ToString("N3"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.DolaresRec.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "N", "N", 3f, 3f));

                        totSoles += item.SolesRec;
                        totDolares += item.DolaresRec;
                        Correlativo++;
                        TableDeta.CompleteRow();
                    }

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S13"));
                    TableDeta.CompleteRow();

                    ////Ultima Fila
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "S4"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("<< TOTALES >>", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(totSoles.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(totDolares.ToString("N2"), ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 4f, 4f));
                    TableDeta.CompleteRow();

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                    #endregion

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

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (OrdenPago != null)
                {
                    String TituloGeneral = "ORDEN DE PAGO N° " + OrdenPago.codOrdenPago;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar en ", TituloGeneral, "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrWhiteSpace(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo))
                        {
                            File.Delete(RutaArchivo);
                        }

                        FileInfo Archivo = new FileInfo(RutaArchivo);

                        if (Archivo == null)
                        {
                            Global.MensajeFault("No se puede crear el archivo excel. Revise la ruta donde guarda el archivo.");
                            return;
                        }

                        using (ExcelPackage oExcel = new ExcelPackage(Archivo))
                        {
                            using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("O.P."))
                            {
                                if (oHoja != null)
                                {
                                    Int32 InicioLinea = 3;
                                    Int32 TotColumnas = 14;

                                    #region Encabezado

                                    // Creando Encabezado;
                                    oHoja.Cells["A1"].Value = TituloGeneral;

                                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                    {
                                        Rango.Merge = true;
                                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                                    }

                                    #endregion

                                    oHoja.Cells[InicioLinea, 1].Value = "SUCURSAL: " + VariablesLocales.SesionLocal.Nombre;
                                    oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));

                                    InicioLinea += 2;

                                    oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Merge = true;
                                    oHoja.Cells[InicioLinea, 1].Value = "Item";
                                    oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 2, InicioLinea, 5].Merge = true;
                                    oHoja.Cells[InicioLinea, 2].Value = "Documento";
                                    oHoja.Cells[InicioLinea, 2, InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6].Merge = true;
                                    oHoja.Cells[InicioLinea, 6].Value = "Concepto";
                                    oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7].Merge = true;
                                    oHoja.Cells[InicioLinea, 7].Value = "Mon.";
                                    oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 8, InicioLinea + 1, 8].Merge = true;
                                    oHoja.Cells[InicioLinea, 8].Value = "T. Doc";
                                    oHoja.Cells[InicioLinea, 8, InicioLinea + 1, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 9, InicioLinea, 12].Merge = true;
                                    oHoja.Cells[InicioLinea, 9].Value = "Detalle de Pago";
                                    oHoja.Cells[InicioLinea, 9, InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 13, InicioLinea, 14].Merge = true;
                                    oHoja.Cells[InicioLinea, 13].Value = "Detracción";
                                    oHoja.Cells[InicioLinea, 13, InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    InicioLinea++;

                                    oHoja.Cells[InicioLinea, 2].Value = "Emisión";
                                    oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 3].Value = "Tipo";
                                    oHoja.Cells[InicioLinea, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 4].Value = "Nro Doc.";
                                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 5].Value = "Tercero";
                                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 9].Value = "Mon.";
                                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 10].Value = "T.Pago";
                                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 11].Value = "F.Pago";
                                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 12].Value = "Cta. Proveedor";
                                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 13].Value = "%";
                                    oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea, 14].Value = "Monto";
                                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                    oHoja.Cells[InicioLinea - 1, 1, InicioLinea, 14].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                                    oHoja.Cells[InicioLinea - 1, 1, InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea - 1, 1, InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(169, 208, 142));
                                    oHoja.Cells[InicioLinea - 1, 1, InicioLinea, 14].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                                    oHoja.Cells[InicioLinea - 1, 1, InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                    InicioLinea++;
                                    Int32 Correlativo = 1;
                                    int pr = InicioLinea;

                                    foreach (OrdenPagoDetE item in OrdenPago.ListaOrdenPago)
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = Correlativo;
                                        oHoja.Cells[InicioLinea, 2].Value = item.Fecha;
                                        oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        oHoja.Cells[InicioLinea, 3].Value = item.idDocumento;
                                        oHoja.Cells[InicioLinea, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        oHoja.Cells[InicioLinea, 4].Value = item.serDocumento + "-" + item.numDocumento;
                                        oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        oHoja.Cells[InicioLinea, 5].Value = item.desProveedor;
                                        oHoja.Cells[InicioLinea, 6].Value = item.Concepto;
                                        oHoja.Cells[InicioLinea, 7].Value = item.desMoneda;
                                        oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        oHoja.Cells[InicioLinea, 8].Value = item.Monto;
                                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,##0.00";
                                        oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                        oHoja.Cells[InicioLinea, 9].Value = item.desMonedaBanco;
                                        oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        oHoja.Cells[InicioLinea, 10].Value = item.Monto - item.MontoDetraS;
                                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,##0.00";
                                        oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                        oHoja.Cells[InicioLinea, 11].Value = item.Dias == 0 ? "CONTADO" : item.Dias.ToString() + " DIAS";
                                        oHoja.Cells[InicioLinea, 12].Value = item.desBanco + " " + item.numCtaBancaria;
                                        oHoja.Cells[InicioLinea, 13].Value = item.porDetraccion;
                                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,##0.00";
                                        oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                        oHoja.Cells[InicioLinea, 14].Value = item.MontoDetraS;
                                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,##0.00";
                                        oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                        Correlativo++;
                                        InicioLinea++;
                                    }

                                    using (ExcelRange Rng = oHoja.Cells[pr, 1, InicioLinea - 1, 14])
                                    {
                                        Rng.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10));
                                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    }

                                    oHoja.Column(1).Width = 5.57f;
                                    oHoja.Column(2).Width = 10.43;
                                    oHoja.Column(3).Width = 5.71;
                                    oHoja.Column(4).Width = 15;
                                    oHoja.Column(5).Width = 38.50;
                                    oHoja.Column(6).Width = 30.50;
                                    oHoja.Column(7).Width = 5.43;
                                    oHoja.Column(8).Width = 10.71;
                                    oHoja.Column(9).Width = 5.43;
                                    oHoja.Column(10).Width = 10.71;
                                    oHoja.Column(11).Width = 12.71;
                                    oHoja.Column(12).Width = 21.5;
                                    oHoja.Column(13).Width = 5.50;
                                    oHoja.Column(14).Width = 10.71;

                                    //Insertando Encabezado
                                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                                    //Pie de Pagina(centro)
                                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                                    //Otras Propiedades
                                    oHoja.Workbook.Properties.Title = TituloGeneral;
                                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                    oHoja.Workbook.Properties.Subject = "Ordenes de Pago";
                                    //oHoja.Workbook.Properties.Keywords = "";
                                    oHoja.Workbook.Properties.Category = "Módulo de Tesoreria";
                                    oHoja.Workbook.Properties.Comments = "Tesoreria";

                                    // Establecer algunos valores de las propiedades extendidas
                                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                                    //Propiedades para imprimir
                                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                                    //Guardando el excel
                                    oExcel.Save();
                                }
                            }
                        }

                        Global.MensajeComunicacion("Se exportó correctamente a excel.");
                    }
                }

                if (ListaCobranzas != null && ListaCobranzas.Count > 0)
                {
                    String RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", "Reporte de Conciliados y No Conciliados", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaExcel))
                    {
                        Cursor = Cursors.WaitCursor;

                        if (File.Exists(RutaExcel)) File.Delete(RutaExcel);

                        FileInfo newFile = new FileInfo(RutaExcel);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Conciliados");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 InicioLinea2 = InicioLinea;
                                Int32 TotColumnas = 11;

                                #region Titulos Principales

                                oHoja.Cells["A1"].Value = "REPORTE COBRANZAS CONCILIADAS Y NO CONCILIADAS";
                                oHoja.Row(1).Height = 25;

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                                }

                                oHoja.Cells["A2"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                                oHoja.Row(2).Height = 25;

                                using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 12, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.FromArgb(51, 51, 153));
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                                }

                                #endregion

                                #region Titulos del detalle

                                oHoja.Cells["A4"].Value = "LIBRO BANCO CONCILIADO";
                                oHoja.Row(InicioLinea).Height = 20;

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 6])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.White);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                }

                                oHoja.Cells["G4"].Value = "N°";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.White);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                }

                                oHoja.Cells["H4"].Value = "EE.CC. CONCILIADO";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, InicioLinea, 11])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.White);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                }

                                InicioLinea++;

                                List<String> ListaTitulos = new List<String>
                                {
                                    "Cuenta Bancaria",
                                    "Mon.",
                                    "Fec. Cob.",
                                    "N° de Operación",
                                    "Importe",
                                    "Núm.Doc.",
                                    "Glosa"
                                }; 

                                #endregion

                                List<CobranzasItemE> Lista1 = ListaCobranzas.Where(x => x.Orden == 1).ToList();
                                List<CobranzasItemE> Lista2 = ListaCobranzas.Where(x => x.Orden == 2).ToList();
                                List<CobranzasItemE> Lista3 = (from x in ListaCobranzas where x.Orden == 3 select x).ToList();
                                List<CobranzasItemE> Lista4 = (from x in ListaCobranzas where x.Orden == 4 select x).ToList();
                                Int32 ItemCorre = 1;

                                if (Lista1.Count > 0)
                                {
                                    #region Titulos del detalle

                                    for (int i = 0; i < ListaTitulos.Count; i++)
                                    {
                                        if (i != 6)
                                        {
                                            oHoja.Cells[InicioLinea, i + 1].Value = ListaTitulos[i];
                                            oHoja.Cells[InicioLinea, i + 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                            oHoja.Cells[InicioLinea, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            oHoja.Cells[InicioLinea, i + 1].Style.Font.Color.SetColor(Color.White);
                                            oHoja.Cells[InicioLinea, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                            oHoja.Cells[InicioLinea, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                            oHoja.Cells[InicioLinea, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            oHoja.Cells[InicioLinea, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        }
                                    }

                                    #endregion

                                    #region Detalle

                                    InicioLinea2 = InicioLinea;
                                    InicioLinea++;

                                    foreach (CobranzasItemE item in Lista1)
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = item.CuentaBancaria;
                                        oHoja.Cells[InicioLinea, 2].Value = item.desMoneda;

                                        if (item.fecCobranza == null)
                                        {
                                            oHoja.Cells[InicioLinea, 3].Value = "";
                                        }
                                        else
                                        {
                                            oHoja.Cells[InicioLinea, 3].Value = item.fecCobranza;
                                        }

                                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[InicioLinea, 4].Value = item.Operacion;
                                        oHoja.Cells[InicioLinea, 5].Value = item.Monto;
                                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                                        oHoja.Cells[InicioLinea, 6].Value = item.codPlanilla;
                                        oHoja.Cells[InicioLinea, 7].Value = ItemCorre;

                                        ItemCorre++;

                                        for (int i = 1; i <= 7; i++)
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                                            oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.FromArgb(0, 0, 128));

                                            if (i == 2 || i == 3 || i == 4)
                                            {
                                                oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }
                                        }

                                        InicioLinea++;
                                    }

                                    #endregion
                                }

                                if (Lista2.Count > 0)
                                {
                                    #region Titulos del detalle

                                    for (int i = 0; i < ListaTitulos.Count; i++)
                                    {
                                        if (i != 1 && i != 5 && i != 6)
                                        {
                                            oHoja.Cells[InicioLinea2, i + (i == 0 ? 8 : 7)].Value = ListaTitulos[i];
                                            oHoja.Cells[InicioLinea2, i + (i == 0 ? 8 : 7)].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                            oHoja.Cells[InicioLinea2, i + (i == 0 ? 8 : 7)].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            oHoja.Cells[InicioLinea2, i + (i == 0 ? 8 : 7)].Style.Font.Color.SetColor(Color.White);
                                            oHoja.Cells[InicioLinea2, i + (i == 0 ? 8 : 7)].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                            oHoja.Cells[InicioLinea2, i + (i == 0 ? 8 : 7)].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                            oHoja.Cells[InicioLinea2, i + (i == 0 ? 8 : 7)].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            oHoja.Cells[InicioLinea2, i + (i == 0 ? 8 : 7)].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        }
                                    }

                                    #endregion

                                    #region Detalle

                                    InicioLinea2++;

                                    foreach (CobranzasItemE item in Lista2)
                                    {
                                        oHoja.Cells[InicioLinea2, 8].Value = item.CuentaBancaria;

                                        if (item.fecCobranza == null)
                                        {
                                            oHoja.Cells[InicioLinea2, 9].Value = "";
                                        }
                                        else
                                        {
                                            oHoja.Cells[InicioLinea2, 9].Value = item.fecCobranza;
                                        }

                                        oHoja.Cells[InicioLinea2, 9].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[InicioLinea2, 10].Value = item.Operacion;
                                        oHoja.Cells[InicioLinea2, 11].Value = item.Monto;
                                        oHoja.Cells[InicioLinea2, 11].Style.Numberformat.Format = "###,###,##0.00";

                                        //Formato a l fila actual
                                        for (int i = 8; i <= 11; i++)
                                        {
                                            oHoja.Cells[InicioLinea2, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                                            oHoja.Cells[InicioLinea2, i].Style.Font.Color.SetColor(Color.FromArgb(0, 0, 128));

                                            if (i == 9 || i == 10)
                                            {
                                                oHoja.Cells[InicioLinea2, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }
                                        }

                                        InicioLinea2++;
                                    }

                                    #endregion
                                }

                                if (Lista3.Count > 0)
                                {
                                    //Aumentando una Fila mas continuar con el detalle
                                    InicioLinea += 2;

                                    oHoja.Cells[InicioLinea, 1].Value = "LIBRO BANCO NO CONCILIADO";
                                    oHoja.Row(InicioLinea).Height = 20;

                                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 6])
                                    {
                                        Rango.Merge = true;
                                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                        Rango.Style.Font.Color.SetColor(Color.White);
                                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                    }

                                    InicioLinea++;

                                    #region Titulos del detalle

                                    for (int i = 0; i < ListaTitulos.Count; i++)
                                    {
                                        if (i != 6)
                                        {
                                            oHoja.Cells[InicioLinea, i + 1].Value = ListaTitulos[i];
                                            oHoja.Cells[InicioLinea, i + 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                            oHoja.Cells[InicioLinea, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            oHoja.Cells[InicioLinea, i + 1].Style.Font.Color.SetColor(Color.White);
                                            oHoja.Cells[InicioLinea, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                            oHoja.Cells[InicioLinea, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                            oHoja.Cells[InicioLinea, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            oHoja.Cells[InicioLinea, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        }
                                    }

                                    #endregion

                                    InicioLinea++;

                                    #region Detalle

                                    foreach (CobranzasItemE item in Lista3)
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = item.CuentaBancaria;
                                        oHoja.Cells[InicioLinea, 2].Value = item.desMoneda;

                                        if (item.fecCobranza == null)
                                        {
                                            oHoja.Cells[InicioLinea, 3].Value = "";
                                        }
                                        else
                                        {
                                            oHoja.Cells[InicioLinea, 3].Value = item.fecCobranza;
                                        }

                                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[InicioLinea, 4].Value = item.Operacion;
                                        oHoja.Cells[InicioLinea, 5].Value = item.Monto;
                                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                                        oHoja.Cells[InicioLinea, 6].Value = item.codPlanilla;

                                        //Formato a l fila actual
                                        for (int i = 1; i <= 6; i++)
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                                            oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.FromArgb(0, 0, 128));

                                            if (i == 2 || i == 3 || i == 4)
                                            {
                                                oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }
                                        }

                                        InicioLinea++;
                                    }

                                    #endregion
                                }

                                if (Lista4.Count > 0)
                                {
                                    //Aumentando una Fila mas continuar con el detalle
                                    InicioLinea++;

                                    oHoja.Cells[InicioLinea, 1].Value = "EE.CC. NO CONCILADO";
                                    oHoja.Row(InicioLinea).Height = 20;

                                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 6])
                                    {
                                        Rango.Merge = true;
                                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                        Rango.Style.Font.Color.SetColor(Color.White);
                                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                    }

                                    InicioLinea++;

                                    #region Titulos del detalle

                                    for (int i = 0; i < ListaTitulos.Count; i++)
                                    {
                                        if (i != 5)
                                        {
                                            oHoja.Cells[InicioLinea, (i == 6 ? 6 : i + 1)].Value = ListaTitulos[i];
                                            oHoja.Cells[InicioLinea, (i == 6 ? 6 : i + 1)].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                            oHoja.Cells[InicioLinea, (i == 6 ? 6 : i + 1)].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            oHoja.Cells[InicioLinea, (i == 6 ? 6 : i + 1)].Style.Font.Color.SetColor(Color.White);
                                            oHoja.Cells[InicioLinea, (i == 6 ? 6 : i + 1)].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                            oHoja.Cells[InicioLinea, (i == 6 ? 6 : i + 1)].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                            oHoja.Cells[InicioLinea, (i == 6 ? 6 : i + 1)].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            oHoja.Cells[InicioLinea, (i == 6 ? 6 : i + 1)].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                        }
                                    }

                                    #endregion

                                    InicioLinea++;

                                    #region Detalle

                                    foreach (CobranzasItemE item in Lista4)
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = item.CuentaBancaria;
                                        oHoja.Cells[InicioLinea, 2].Value = item.desMoneda;

                                        if (item.fecCobranza == null)
                                        {
                                            oHoja.Cells[InicioLinea, 3].Value = "";
                                        }
                                        else
                                        {
                                            oHoja.Cells[InicioLinea, 3].Value = item.fecCobranza;
                                        }

                                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[InicioLinea, 4].Value = item.Operacion;
                                        oHoja.Cells[InicioLinea, 5].Value = item.Monto;
                                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                                        oHoja.Cells[InicioLinea, 6].Value = item.GlosaBanco;

                                        //Formato a l fila actual
                                        for (int i = 1; i <= 6; i++)
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                                            oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.FromArgb(0, 0, 128));

                                            if (i == 2 || i == 3 || i == 4)
                                            {
                                                oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }
                                        }

                                        InicioLinea++;
                                    }

                                    #endregion
                                }


                                //Ajustando el ancho de las columnas automaticamente
                                oHoja.Cells.AutoFitColumns();

                                //Insertando Encabezado
                                //Pie de Pagina(Derecho) "Número de paginas y el total"
                                oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                                //Pie de Pagina(centro)
                                oHoja.HeaderFooter.OddFooter.CenteredText = "Cobranzas Conciliadas"; //ExcelHeaderFooter.SheetName;

                                //Otras Propiedades
                                //oHoja.Workbook.Properties.Title = TituloGeneral;
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Módulo de Cobranzas";
                                //oHoja.Workbook.Properties.Comments = NombrePestaña;

                                // Establecer algunos valores de las propiedades extendidas
                                oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                                //Propiedades para imprimir
                                oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                                oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                                //Guardando el excel
                                oExcel.Save();
                            }
                        }

                        Cursor = Cursors.Arrow;
                        Global.MensajeComunicacion("Conciliación exportada a Excel");
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmImpresionBase_Load(object sender, EventArgs e)
        {
            Grid = false;

            try
            {
                #region Pedidos

                if (oPedido != null)
                {
                    if (oPedido.indCotPed == "P" || oPedido.indCotPed == "V")
                    {
                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009") //AgroGenesis
                        {
                            CrearPrevioPedidoOtro(oPedido);
                        }
                        else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20519167434") //wss peru
                        {
                            CrearPrevioPedidoOtrowss(oPedido);
                        }
                        //else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20216789611") //Tacama
                        //{
                        //    CrearPrevioPedidoTacama(oPedido);
                        //}
                        else //Para el resto de empresas...
                        {
                            if (!VariablesLocales.SesionUsuario.Empresa.indCalzado)
                            {
                                CrearPrevioPedidoNormal(oPedido);
                            }
                            else
                            {
                                CrearPrevioPedidoCalzado(oPedido);
                            }
                        }
                    }
                    else
                    {
                        CrearPrevioCotizacion(oPedido);
                    }

                    if (!string.IsNullOrEmpty(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Bonificacion

                //if (oBonificacion != null)
                //{
                //    CrearPrevioBonificacion(oBonificacion);

                //    if (!string.IsNullOrEmpty(RutaPdf))
                //    {
                //        wbNavegador.Navigate(RutaPdf);
                //    }
                //}

                #endregion

                #region Requerimientos

                //if (oRequerimiento != null)
                //{
                //    CrearPrevioRequerimiento(oRequerimiento);

                //    if (!String.IsNullOrWhiteSpace(RutaPdf))
                //    {
                //        wbNavegador.Navigate(RutaPdf);
                //    }
                //}

                #endregion

                #region Movimientos en Almacén(Hoja de Costo)

                //if (oMoviAlmacen != null && oMoviAlmacen.Count > 0)
                //{
                //    CrearPrevioMovimientosAlmacen(oMoviAlmacen);

                //    if (!string.IsNullOrEmpty(RutaPdf))
                //    {
                //        wbNavegador.Navigate(RutaPdf);
                //    }
                //}

                if (oMovimientoAlmacen != null)
                {
                    CrearPrevioMovimientosAlmacen(oMovimientoAlmacen);

                    if (!string.IsNullOrEmpty(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Ordenes de Compras

                if (oOrdenCompra != null)
                {
                    CrearPrevioMovimientosOC(oOrdenCompra);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Ordenes de Conversion

                if (OrdenConversion != null)
                {
                    CrearPrevioOrdenConversion(OrdenConversion);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Ordenes de Pago

                if (OrdenPago != null)
                {
                    CrearPrevioOrdenPago(OrdenPago);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }

                    BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
                }

                #endregion

                #region Liquidacion

                if (oLiquidacion != null)
                {
                    CrearPrevioLiquidacion(oLiquidacion);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Ordenes Trabajo Servicio

                if (oOrdenTrabajoServ != null)
                {
                    BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
                    CrearPrevioOrdenTrabajoServ(oOrdenTrabajoServ);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Solicitud de Adelanto a Proveedor

                if (oSolicitud != null)
                {
                    CrearPrevioSolicitud(oSolicitud);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Rendición de Adelanto a Proveedor

                if (oListaRendiciones != null)
                {
                    CrearPrevioRendiciones(oListaRendiciones);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Conciliados y no conciliados

                if (ListaCobranzas != null)
                {
                    BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
                    CrearPrevioConciliadosYnoConciliados(ListaCobranzas);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                #region Liquidacion de Importacion

                if (oLiquidacionImpo != null)
                {
                    CrearPrevioLiquidacionImportacion(oLiquidacionImpo);

                    if (!String.IsNullOrWhiteSpace(RutaPdf))
                    {
                        wbNavegador.Navigate(RutaPdf);
                    }
                }

                #endregion

                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}

class InicioCabeceraCotizacion : PdfPageEventHelper
{
    PdfContentByte cb;
    PdfTemplate template;

    public override void OnOpenDocument(PdfWriter writer, Document document)
    {
        cb = writer.DirectContent;
        template = cb.CreateTemplate(50, 50);
    }

    public override void OnCloseDocument(PdfWriter writer, Document document)
    {
        base.OnCloseDocument(writer, document);
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 5f, iTextSharp.text.Font.NORMAL);
        template.BeginText();
        template.SetFontAndSize(bfTimes, times.Size);
        template.SetTextMatrix(0, 0);
        template.ShowText("" + (writer.PageNumber)); //(writer.PageNumber - 1));
        template.EndText();
    }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
    }

    public override void OnEndPage(PdfWriter writer, Document document)
    {
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 5f, iTextSharp.text.Font.NORMAL);

        base.OnEndPage(writer, document);
        iTextSharp.text.Rectangle page = document.PageSize;
        int pageN = writer.PageNumber;
        String text = "Hoja N° " + pageN.ToString().PadRight(350, ' ') + "Pág. " + pageN.ToString() + " de ";

        float len = bfTimes.GetWidthPoint(text, times.Size);
        iTextSharp.text.Rectangle pageSize = document.PageSize;
        cb.BeginText();
        cb.SetFontAndSize(bfTimes, times.Size);
        cb.SetTextMatrix(page.Width - document.RightMargin - (len + 10), pageSize.GetTop(document.TopMargin) + 6);
        cb.ShowText(text);
        cb.EndText();
        cb.AddTemplate(template, page.Width - document.RightMargin - 10, pageSize.GetTop(document.TopMargin) + 6);
    }

    //    public String RutaImagen { get; set; }
    //    public PedidoCabE oPedidoCoti { get; set; }
    //    public Decimal TipoCambio { get; set; }

    //    public override void OnStartPage(PdfWriter writer, Document DocumentoPdf)
    //    {
    //        base.OnStartPage(writer, DocumentoPdf);

    //        //Cabecera del Reporte
    //        float[] AnchoColumnas = new float[] { 0.5f, 0.5f };
    //        PdfPTable Tabla = new PdfPTable(2);
    //        Tabla.WidthPercentage = 100;
    //        Tabla.SetWidths(AnchoColumnas);

    //        #region Cabecera

    //        PdfPCell CeldaImagen = null;

    //        if (File.Exists(RutaImagen))
    //        {
    //            switch (VariablesLocales.SesionUsuario.Empresa.RUC)
    //            {
    //                case "20502647009": //AgroGenesis - HuertoGenesis - Viveros - Jeritec - AyV Seeds - Power Seeds
    //                case "20523020561":
    //                case "20517933318":
    //                case "20552695217":
    //                case "20552186681":
    //                case "20552690410":
    //                    CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 250f, 1, "N"));
    //                    break;
    //                default: //Otras Empresas...
    //                    CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 200f, 1, "N"));
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 1, 1));
    //        }

    //        CeldaImagen.Rowspan = 5;
    //        Tabla.AddCell(CeldaImagen);

    //        Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.sTelefonos, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda("Correo-e: " + VariablesLocales.SesionUsuario.Empresa.sEmail, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.sWeb, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
    //        Tabla.CompleteRow(); 

    //        #endregion

    //        DocumentoPdf.Add(Tabla);

    //        #region Titulo

    //        Tabla = new PdfPTable(2);
    //        AnchoColumnas = new float[] { 0.8f, 0.2f };
    //        Tabla.WidthPercentage = 95;
    //        Tabla.SetWidths(AnchoColumnas);

    //        Tabla.AddCell(ReaderHelper.NuevaCelda("                              COTIZACION", null, "N", null, FontFactory.GetFont("Arial Black", 15.25f, iTextSharp.text.Font.BOLD), 5, 1));
    //        Tabla.AddCell(ReaderHelper.NuevaCelda("N° " + oPedidoCoti.codPedidoCad, null, "S", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 5, 1));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
    //        Tabla.CompleteRow(); 

    //        #endregion

    //        DocumentoPdf.Add(Tabla);

    //        #region SubTitulos

    //        Tabla = new PdfPTable(4);
    //        Tabla.WidthPercentage = 95;
    //        Tabla.SetWidths(new float[] { 0.045f, 0.3f, 0.04f, 0.09f });

    //        Tabla.AddCell(ReaderHelper.NuevaCelda("Razón Social ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
    //        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedidoCoti.desFacturar, null, "S", null, FontFactory.GetFont("Arial", 7.50f, iTextSharp.text.Font.BOLD), -1, -1, "S3"));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda("Atención ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
    //        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedidoCoti.Observacion, null, "S", null, FontFactory.GetFont("Arial", 7.50f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
    //        Tabla.AddCell(ReaderHelper.NuevaCelda("RUC " + oPedidoCoti.RucCliente, null, "S", null, FontFactory.GetFont("Arial", 7.50f, iTextSharp.text.Font.BOLD)));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda("Dirección ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
    //        Tabla.AddCell(ReaderHelper.NuevaCelda(oPedidoCoti.DireccionCompleta, null, "S", null, FontFactory.GetFont("Arial", 7.50f), -1, -1, "S3"));
    //        Tabla.CompleteRow();

    //        Tabla.AddCell(ReaderHelper.NuevaCelda("Moneda ", null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
    //        Tabla.AddCell(ReaderHelper.NuevaCelda((oPedidoCoti.idMoneda == Variables.Soles ? "Soles (S/.)" : "Dólares Americanos (US$)"), null, "S", null, FontFactory.GetFont("Arial", 7.50f), -1, -1));
    //        Tabla.AddCell(ReaderHelper.NuevaCelda("Fecha " + oPedidoCoti.Fecha.ToLongDateString(), null, "S", null, FontFactory.GetFont("Arial", 7.50f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
    //        Tabla.CompleteRow();

    //        //Linea en blanco
    //        Tabla.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), -1, -1, "S4", "N", 0f, 0f));
    //        Tabla.CompleteRow();

    //        #endregion SubTitulos

    //        DocumentoPdf.Add(Tabla); //Añadiendo la tabla al documento PDF
    //    }

}