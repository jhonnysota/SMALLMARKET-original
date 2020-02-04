using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

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

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoPedidos : FrmMantenimientoBase
    {

        public frmListadoPedidos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new System.Drawing.Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvPedidos, true);
            LlenarCombo();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<PedidoCabE> oListaPedidos = null;
        String RutaPdf = String.Empty;
        String RutaImagen = String.Empty;
        Boolean indCarteraClientes = true;

        List<UsuarioImpresorasE> oListaImpresoras = null;
        ImpresionBarrasDetDetE oLineaImpresion = null;
        String LetraCodBarras = VariablesLocales.oVenParametros.FontPrintBarras;
        Int32 DigitosCodBarras = VariablesLocales.oVenParametros.digBarras;

        #endregion Variables

        #region Procedimientos de Usuario

        private void LlenarCombo()
        {
            List<ParTabla> oLista = new List<ParTabla>
            {
                new ParTabla() { ValorCadena = "C", Nombre = "COTIZADO" },
                new ParTabla() { ValorCadena = "P", Nombre = "PEDIDO" },
                new ParTabla() { ValorCadena = "F", Nombre = "FACTURADO" }
            };

            ComboHelper.LlenarCombos<ParTabla>(cboEstados, oLista, "ValorCadena", "Nombre");
        }

        private void CrearPdf(PedidoCabE oPedido)
        {
            Document DocumentoPdf = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            String NombreReporte = "Pedido " + oPedido.codPedidoCad;
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
                TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Convert.ToDateTime(oPedido.FecPedido).ToString("yyyMMdd"));

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

                    Tabla = new PdfPTable(6);
                    Tabla.WidthPercentage = 100;
                    //Tabla.SetWidths(new float[] { 0.08f, 0.08f, 0.09f, 0.3f/*,0.0f*//*, 0.00f*/, 0.06f, 0.06f }); JOSE SALAZAR
                    Tabla.SetWidths(new float[] { 0.05f, 0.05f, 0.09f, 0.35f, 0.06f, 0.06f }); //JHONNY SOTA 

                    Tabla.AddCell(ReaderHelper.NuevaCelda("CANTIDAD ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("UNIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("CODIGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION                       ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("PRECIO UNITARIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1));
                    Tabla.CompleteRow();
                    
                    foreach (PedidoDetE item in oPedido.ListaPedidoDet)
                    {
                        Tabla.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N0"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 1, 2));
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

        private void VerificarVendedor(Int32 IdPersona)
        {
            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                txtNombresVendedor.Tag = string.Empty;
                txtNombresVendedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                VendedoresE oVendedor = AgenteMaestro.Proxy.RecuperarVendedorPorId(VariablesLocales.SesionUsuario.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oVendedor != null)
                {
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    txtNombresVendedor.Tag = oVendedor.idPersona.ToString();
                    txtNombresVendedor.Text = oVendedor.RazonSocial;
                    indCarteraClientes = oVendedor.ManejaCartera;

                    if (oVendedor.indSupervisor)
                    {
                        txtNombresVendedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }

                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
                else
                {
                    txtNombresVendedor.Tag = string.Empty;
                    txtNombresVendedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPedidos);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPedidos()
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
                if (bsPedidos.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPedidos);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }
                    
                    PedidoCabE current = (PedidoCabE)bsPedidos.Current;

                    if (current != null)
                    {
                        oFrm = new frmPedidos(current.idEmpresa, current.idLocal, current.idPedido)
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
                string Tipo = "C"; //Empieza por fecha de Cotizado...
                Int32 idVendedor = String.IsNullOrWhiteSpace(txtNombresVendedor.Tag.ToString()) ? 0 : Convert.ToInt32(txtNombresVendedor.Tag);

                if (RbPedido.Checked)//Por fecha de pedido
                {
                    Tipo = "P";
                }

                if (RbFactura.Checked)//Por fecha de factura
                {
                    Tipo = "F";
                }

                if (RbEntrega.Checked)//Por fecha de entrega
                {
                    Tipo = "E";
                }

                bsPedidos.DataSource = oListaPedidos = AgenteVentas.Proxy.ListarPedidoNacional(idEmpresa, idLocal, codPedidoCad, fecInicio, fecFinal, RazonSocial, Tipo, idVendedor, cboEstados.SelectedValue.ToString());
                bsPedidos.ResetBindings(false);
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
                if (bsPedidos.List.Count > Variables.Cero)
                {
                    PedidoCabE oPedido = AgenteVentas.Proxy.RecuperarPedidoNacional(((PedidoCabE)bsPedidos.Current).idEmpresa, ((PedidoCabE)bsPedidos.Current).idLocal, ((PedidoCabE)bsPedidos.Current).idPedido);

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

                        oFrm = new frmImpresionBase(oPedido, "Vista Previo del Pedido")
                        {
                            MdiParent = MdiParent
                        };
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
                if (((PedidoCabE)bsPedidos.Current).Estado == EnumEstadoDocumentos.C.ToString() && !String.IsNullOrEmpty(((PedidoCabE)bsPedidos.Current).nroFactura) && !String.IsNullOrEmpty(((PedidoCabE)bsPedidos.Current).NroGuia))
                {
                    Global.MensajeComunicacion(String.Format("Antes de eliminar el Pedido {0} tiene que anular los documentos de Ventas asociados", ((PedidoCabE)bsPedidos.Current).codPedidoCad));
                    return;
                }

                if (((PedidoCabE)bsPedidos.Current).Estado == EnumEstadoDocumentos.P.ToString())
                {
                    if (Global.MensajeConfirmacion(String.Format("Desea eliminar el Pedido {0}", ((PedidoCabE)bsPedidos.Current).codPedidoCad)) == DialogResult.Yes)
                    {
                        String BorrarCoti = "N";

                        if (((PedidoCabE)bsPedidos.Current).idPedidoEnlace > 0)
                        {
                            BorrarCoti = "S";
                        }

                        Int32 resp = AgenteVentas.Proxy.EliminarTodoPedido(((PedidoCabE)bsPedidos.Current).idEmpresa, ((PedidoCabE)bsPedidos.Current).idPedido, ((PedidoCabE)bsPedidos.Current).idLocal, BorrarCoti, ((PedidoCabE)bsPedidos.Current).idPedidoEnlace);

                        if (resp > 0)
                        {
                            Global.MensajeComunicacion("El Pedido se eliminó correctamente.");
                            oListaPedidos.Remove((PedidoCabE)bsPedidos.Current);
                            bsPedidos.DataSource = oListaPedidos;
                            bsPedidos.ResetBindings(false);
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
            frmPedidos oFrm = sender as frmPedidos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void ImprimirBarras_Print(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Image oImg = null;
            System.Drawing.Font fTitColor = new System.Drawing.Font(LetraCodBarras, 7.25f, FontStyle.Bold); //Letra anterior Consola
            System.Drawing.Font fTit1 = new System.Drawing.Font(LetraCodBarras, 15.25f, FontStyle.Bold);
            System.Drawing.Font fTitTalla = new System.Drawing.Font(LetraCodBarras, 25, FontStyle.Bold);
            System.Drawing.Font fTArti = new System.Drawing.Font(LetraCodBarras, 10, FontStyle.Bold);
            System.Drawing.Font fTCodBarras = new System.Drawing.Font(LetraCodBarras, 11, FontStyle.Bold);
            String NombreArticulo = String.Empty;

            using (SolidBrush sb = new SolidBrush(Color.Black))
            {
                using (Graphics g = e.Graphics)
                {
                    g.PageUnit = GraphicsUnit.Millimeter;
                    String Barras = oLineaImpresion.codBarras;

                    if (Barras.Length < DigitosCodBarras)
                    {
                        String tmp = oLineaImpresion.codBarras;
                        Barras = tmp.PadLeft(DigitosCodBarras, '0');
                    }

                    oImg = ReaderHelper.Code128(Barras, (int)ReaderHelper.TiposCode128.CODE128, false, 36);

                    g.DrawString(oLineaImpresion.desModelo, fTit1, sb, 1.5f, 0); //1
                    g.DrawString(oLineaImpresion.desModelo, fTit1, sb, 56f, 0); //2

                    g.DrawString(oLineaImpresion.abrevMaterial, fTit1, sb, 13f, 0); //1
                    g.DrawString(oLineaImpresion.abrevMaterial, fTit1, sb, 67.4f, 0); //2

                    g.DrawString(oLineaImpresion.desColor, fTitColor, sb, 20f, 0.8f); //1
                    g.DrawString(oLineaImpresion.desColor, fTitColor, sb, 74.5f, 0.8f); //2

                    g.DrawString(oLineaImpresion.fecImpresion.ToString("d"), fTitColor, sb, 20f, 2.8f); //1
                    g.DrawString(oLineaImpresion.fecImpresion.ToString("d"), fTitColor, sb, 74.5f, 2.8f); //2

                    g.DrawString(oLineaImpresion.Talla.ToString(), fTitTalla, sb, 39f, -2.3f); //1
                    g.DrawString(oLineaImpresion.Talla.ToString(), fTitTalla, sb, 92.7f, -2.3f); //2

                    if (oLineaImpresion.nomArticulo.Length > 30)
                    {
                        NombreArticulo = oLineaImpresion.nomArticulo.Substring(0, 30);
                    }
                    else
                    {
                        NombreArticulo = oLineaImpresion.nomArticulo;
                    }

                    g.DrawString(NombreArticulo, fTArti, sb, 1.5f, 6); //1
                    g.DrawString(NombreArticulo, fTArti, sb, 55.3f, 6); //2

                    g.DrawImage(oImg, 6.5f, 10);
                    g.DrawImage(oImg, 60.5f, 10);

                    g.DrawString(Barras, fTCodBarras, sb, 5.2f, 19); //1
                    g.DrawString(Barras, fTCodBarras, sb, 59.2f, 19); //2
                }
            }
        }

        #endregion

        #region Eventos

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            Grid = true;

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410") // Power seed
            {
                tsmiGeneraOC.Visible = true;
            }

            if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
            {
                oListaImpresoras = AgenteGeneral.Proxy.ListarUsuarioImpresoras(VariablesLocales.SesionUsuario.IdPersona);
                tssLineamprimirBarras.Visible = true;
                tsmiImprimirBarras.Visible = true;
            }

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            VerificarVendedor(VariablesLocales.SesionUsuario.IdPersona);
        }

        private void tsmiCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaPedidos != null && oListaPedidos.Count > Variables.Cero)
                {
                    if (((PedidoCabE)bsPedidos.Current).Estado == EnumEstadoDocumentos.C.ToString())
                    {
                        Global.MensajeComunicacion(String.Format("El registro {0} tiene que estar como Pedido antes de crear los documentos.", ((PedidoCabE)bsPedidos.Current).codPedidoCad));
                        return;
                    }

                    if (((PedidoCabE)bsPedidos.Current).Estado == EnumEstadoDocumentos.F.ToString())
                    {
                        Global.MensajeComunicacion(String.Format("El registro {0} ya se encuentra facturado.", ((PedidoCabE)bsPedidos.Current).codPedidoCad));
                        return;
                    }

                    if (((PedidoCabE)bsPedidos.Current).NemoTipoDoc == "TIPFACT" || ((PedidoCabE)bsPedidos.Current).NemoTipoDoc == "TIPBOL" || ((PedidoCabE)bsPedidos.Current).NemoTipoDoc == "TIPGUI")
                    {
                        frmDetalleCrearDocumentos oFrm = new frmDetalleCrearDocumentos((PedidoCabE)bsPedidos.Current, ((PedidoCabE)bsPedidos.Current).codPedidoCad);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            Global.MensajeComunicacion("Los documentos se crearon correctamente");
                            Buscar();
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("Debe escoger un tipo de comprobante en el pedido antes de crear el documento de venta.");
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
                PedidoCabE oPedido = AgenteVentas.Proxy.RecuperarPedidoNacional(((PedidoCabE)bsPedidos.Current).idEmpresa, ((PedidoCabE)bsPedidos.Current).idLocal, ((PedidoCabE)bsPedidos.Current).idPedido);

                if (oPedido != null)
                {
                    CrearPdf(oPedido);

                    frmEnvioCorreos oFrm = new frmEnvioCorreos(oPedido, RutaPdf);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CorreoEnviado)
                    {
                        Int32 resp = AgenteVentas.Proxy.ActualizarEnvio(((PedidoCabE)bsPedidos.Current).idPedido, true);

                        if (resp > 0)
                        {
                            ((PedidoCabE)bsPedidos.Current).CorreoEnviado = true;
                            bsPedidos.ResetBindings(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsPedidos_ListChanged(object sender, ListChangedEventArgs e)
        {
            LblRegistros.Text = String.Format("Registros {0}", bsPedidos.List.Count);
        }

        private void dgvPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void tsmiCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaPedidos != null && oListaPedidos.Count > Variables.Cero)
                {
                    Boolean ValorRetorno = AgenteVentas.Proxy.CopiarPedido(((PedidoCabE)bsPedidos.Current).idEmpresa, ((PedidoCabE)bsPedidos.Current).idLocal, ((PedidoCabE)bsPedidos.Current).idPedido, "P", VariablesLocales.SesionUsuario.Credencial, VariablesLocales.FechaHoy);

                    if (ValorRetorno)
                    {
                        Global.MensajeComunicacion("El pedido fue copiado con éxito...");
                        Buscar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiGeneraOC_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaPedidos != null && oListaPedidos.Count > Variables.Cero)
                {
                    String resp = AgenteVentas.Proxy.GenerarPedidoOrdenCompra(((PedidoCabE)bsPedidos.Current).idEmpresa, ((PedidoCabE)bsPedidos.Current).idLocal, 
                                                                                ((PedidoCabE)bsPedidos.Current).idPedido, VariablesLocales.SesionUsuario.Credencial);
                    if (!String.IsNullOrWhiteSpace(resp))
                    {
                        if (String.IsNullOrWhiteSpace(((PedidoCabE)bsPedidos.Current).numOrdenCompra.Trim()))
                        {
                            Global.MensajeComunicacion(String.Format("Se generó la Orden de Compra {0} correctamente.", resp));
                        }
                        else
                        {
                            Global.MensajeComunicacion(String.Format("Se actualizó la Orden de Compra {0}.", resp));
                        }

                        ((PedidoCabE)bsPedidos.Current).numOrdenCompra = resp;
                        bsPedidos.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((String)dgvPedidos.Rows[e.RowIndex].Cells["Estado"].Value == "P")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorCerrado;
                    }
                }

                if ((String)dgvPedidos.Rows[e.RowIndex].Cells["Estado"].Value == "F")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorFacturado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btDesvincular_Click(object sender, EventArgs e)
        {
            try
            {
                ((PedidoCabE)bsPedidos.Current).nroFactura = string.Empty;
                ((PedidoCabE)bsPedidos.Current).NroGuia = string.Empty;
                ((PedidoCabE)bsPedidos.Current).FecFactura = null;

                AgenteVentas.Proxy.ActualizarDocumentosPed((PedidoCabE)bsPedidos.Current);
                bsPedidos.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtNombresVendedor_TextChanged(object sender, EventArgs e)
        {
            txtNombresVendedor.Tag = String.Empty;
        }

        private void txtNombresVendedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()))
                {
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtNombresVendedor.Text.Trim(), "");

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Vendedor");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
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
                        txtNombresVendedor.Text = String.Empty;
                        indCarteraClientes = false;
                    }

                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiImprimirBarras_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaImpresoras.Count == 0)
                {
                    Global.MensajeAdvertencia("No existe ningúna impresora configurada.");
                    return;
                }

                UsuarioImpresorasE impresorasE = oListaImpresoras.Find
                (
                    delegate (UsuarioImpresorasE imp) { return imp.ParaBarras == true; }
                );

                if (impresorasE == null)
                {
                    Global.MensajeAdvertencia("No existe ningúna impresora para la impresión de Código de Barras.");
                    return;
                }

                PedidoCabE current = (PedidoCabE)bsPedidos.Current;

                if (current != null)
                {
                    List<ImpresionBarrasDetDetE> oListaTemp = AgenteVentas.Proxy.InsertarImpresionBarrasPedido(current.idEmpresa, current.idLocal, current.idPedido, VariablesLocales.SesionUsuario.Credencial);

                    if (oListaTemp != null && oListaTemp.Count > 0)
                    {
                        foreach (ImpresionBarrasDetDetE item in oListaTemp)
                        {
                            oLineaImpresion = item;

                            for (int i = 1; i <= item.Cantidad; i++)
                            {
                                PrintDocument printDocument1 = new PrintDocument();
                                PaperSize psize = new PaperSize("", 720, 90); // Tamaño de la Hoja

                                printDocument1.PrintPage += new PrintPageEventHandler(ImprimirBarras_Print);

                                printDocument1.PrintController = new StandardPrintController();
                                printDocument1.DefaultPageSettings.Margins.Left = 0;
                                printDocument1.DefaultPageSettings.Margins.Right = 0;
                                printDocument1.DefaultPageSettings.Margins.Top = 0;
                                printDocument1.DefaultPageSettings.Margins.Bottom = 0;

                                printDocument1.DefaultPageSettings.PaperSize = psize;
                                printDocument1.PrinterSettings.PrinterName = impresorasE.Descripcion;
                                printDocument1.Print();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TsmiConvertir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsPedidos.Current != null)
                {
                    if (Global.MensajeConfirmacion("Desea pasar la cotización a pedido?") == DialogResult.Yes)
                    {
                        int resp = AgenteVentas.Proxy.ConvertirCotiPed(((PedidoCabE)bsPedidos.Current).idPedido);

                        if (resp > 0)
                        {
                            Buscar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}
