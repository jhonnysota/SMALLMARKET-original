using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Maestros;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Almacen
{
    public partial class frmListadoOrdenDeCompra : FrmMantenimientoBase
    {

        public frmListadoOrdenDeCompra()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvListadoOC, true);
            AnchoColumnas();
            
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        Int32 idPersona = Variables.Cero;
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        List<UMedidaE> oListaUMedida;
        EmpresaImagenesE oEmpresaImagen = null;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        String RutaPdf = String.Empty;
        List<OrdenCompraE> oListaOrdenCompra;
        Boolean Ordenar = false;
        String Empresa = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvListadoOC.Columns[0].Width = 30; //ID
            dgvListadoOC.Columns[1 ].Width = 80; //Nro Orden de compra
            dgvListadoOC.Columns[2 ].Width = 80; //Tipo
            dgvListadoOC.Columns[3].Width = 75; //Tipo de Compra
            dgvListadoOC.Columns[4].Width = 70; //Fecha Emision
            dgvListadoOC.Columns[5].Width = 70; //Fecha Requerida
            dgvListadoOC.Columns[6].Width = 240; //Razon Social
            dgvListadoOC.Columns[7].Width = 80; //Estado
            dgvListadoOC.Columns[8].Width = 80; //Estado almacen
            dgvListadoOC.Columns[9].Width = 80; //Estado por Facturar
            dgvListadoOC.Columns[10].Width = 30; //Moneda
            dgvListadoOC.Columns[11].Width = 80; //Total
            dgvListadoOC.Columns[12].Width = 80; //Venta
            dgvListadoOC.Columns[13].Width = 80; //IGV
            dgvListadoOC.Columns[14].Width = 90; //Usuario Aprobaciónn
            dgvListadoOC.Columns[15].Width = 120; //Fecha de Aprobación
            dgvListadoOC.Columns[16].Width = 90; //Usuario Registro
            dgvListadoOC.Columns[17].Width = 120; //Fecha Registro
            dgvListadoOC.Columns[18].Width = 90; //Usuario Modificación
            dgvListadoOC.Columns[19].Width = 120; //Fecha Modificación
        }

        void CrearPdf(OrdenCompraE oOrdenCompra,String Empresa)
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            String NombreReporte = "Orden Compra " + oOrdenCompra.desCCostos.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            docPdf.AddAuthor(" ");
            docPdf.AddCreator(" ");
            docPdf.AddCreationDate();
            docPdf.AddTitle("Orden Compra");
            docPdf.AddSubject("Listado");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                String TituloGeneral = "    ORDEN DE COMPRA Nro. "+  VariablesLocales.SesionLocal.Siglas + " " + oOrdenCompra.numOrdenCompra;
                String SubTitulo = String.Empty;
                PdfPCell cell = null;

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
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    docPdf.Open();

                    #region Encabezado

                    DateTime FechaActual = VariablesLocales.FechaHoy.Date;
                    int size = 8;

                    if (Empresa == "")
                    {



                        PdfPTable table = new PdfPTable(3);

                        table.WidthPercentage = 70;
                        table.SetWidths(new float[] { 0.15f, 0.5f, 0.13f });
                        table.HorizontalAlignment = Element.ALIGN_CENTER;

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
                        table.CompleteRow();

                        // TITULO
                        oEmpresaImagen = AgenteMaestros.Proxy.ObtenerEmpresaSinImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                        RutaImagen += oEmpresaImagen.Nombre + oEmpresaImagen.Extension;

                        if (!File.Exists(RutaImagen))
                        {
                            oEmpresaImagen = AgenteMaestros.Proxy.ObtenerEmpresaConImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                            if (oEmpresaImagen.Imagen != null)
                            {
                                Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, RutaImagen);
                            }
                            else
                            {
                                RutaImagen = String.Empty;
                            }
                        }

                        cell = new PdfPCell();
                        cell = ReaderHelper.ImagenCell(RutaImagen, 80, Element.ALIGN_CENTER, Variables.SI, 1);
                        table.AddCell(cell);
                        cell = CellPdf(TituloGeneral, 13, true, "c", "bold");
                        table.AddCell(cell);
                        cell = CellPdf("Fecha Emisión: " + oOrdenCompra.fecEmision.Date.ToString("d"), 8, true, "c", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        // SUB TITULO
                        cell = CellPdf(VariablesLocales.SesionUsuario.Empresa.NombreComercial, size, false, "", "bold");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        cell = CellPdf("Telefonos :" + VariablesLocales.SesionUsuario.Empresa.sTelefonos, size - 1, false, "", "bold");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf("RUC : " + VariablesLocales.SesionUsuario.Empresa.RUC, size, false, "", "bold");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf("E-mail :" + VariablesLocales.SesionUsuario.Empresa.sEmail, size - 1, false, "", "bold");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        cell = CellPdf("", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        docPdf.Add(table);

                        // DATOS PRINCIPALES
                        PdfPTable tableDatos = new PdfPTable(6);

                        tableDatos.WidthPercentage = 70;
                        tableDatos.SetWidths(new float[] { 0.13f, 0.02f, 0.3f, 0.13f, 0.02f, 0.15f });
                        tableDatos.HorizontalAlignment = Element.ALIGN_CENTER;

                        Persona oProveedor = AgenteMaestros.Proxy.RecuperarPersonaPorID(oOrdenCompra.idProveedor);

                        cell = CellPdf("Proveedor", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oProveedor.RazonSocial, size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("RUC", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oProveedor.RUC, size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf("Dirección", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oProveedor.DireccionCompleta, size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("Telf", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oProveedor.Telefonos, size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf("Forma de Pago", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.desFormaPago, size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("Fecha Requerida", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(Convert.ToDateTime(oOrdenCompra.fecRequerida).ToString("d"), size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf("Plazo Pago", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoPago.ToString() + " días", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("Plazo de Entrega", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoEntrega.ToString() + " días", size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("Fecha de Solicitud", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(Convert.ToDateTime(oOrdenCompra.fecEmision).ToString("d"), size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        docPdf.Add(tableDatos);

                        // DETALLE
                        PdfPTable tableDetalle = new PdfPTable(6);

                        tableDetalle.WidthPercentage = 70;
                        tableDetalle.SetWidths(new float[] { 0.08f, 0.4f, 0.09f, 0.10f, 0.05f, 0.10f });
                        tableDetalle.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("Código", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Descripción", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Cantidad", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" Precio Unit.       US $", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Desc     (%)", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Importe Total     US $", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        List<OrdenCompraItemE> oItem = oOrdenCompra.ListaOrdenesCompras;
                        decimal TotalISC = 0;
                        decimal TotalIGV = 0;
                        decimal Total = 0;

                        if (oItem != null)
                        {
                            if (oItem.Count > 0)
                            {
                                for (int i = 0; i < oItem.Count; i++)
                                {
                                    cell = CellPdf(oItem[i].numItem, size, true, "", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].desArticulo, size, true, "", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].CanOrdenada.ToString() + " " + oListaUMedida.Where(x => x.idUMedida == oItem[i].idUMedidaCompra).ToList()[0].NomUMedidaCorto, size, true, "c", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].impPrecioUnitario.ToString(), size, true, "c", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].porDescuento.ToString(), size, true, "c", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].impTotalItem.ToString("N2"), size, true, "r", "");
                                    tableDetalle.AddCell(cell);
                                    tableDetalle.CompleteRow();

                                    TotalISC += oItem[i].impIsc;
                                    TotalIGV += oItem[i].impIgv;
                                    Total += oItem[i].impTotalItem;
                                }
                            }
                        }

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("US $", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle.AddCell(cell);

                        cell = CellPdf(Total.ToString("N2"), size, true, "r", "bold");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("I.S.C.  US $", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle.AddCell(cell);

                        cell = CellPdf(TotalISC.ToString("N2"), size, true, "r", "bold");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("IGV 18.00", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle.AddCell(cell);

                        cell = CellPdf(TotalIGV.ToString("N2"), size, true, "r", "bold");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Total", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle.AddCell(cell);

                        cell = CellPdf((TotalIGV + Total).ToString("N2"), size, true, "r", "bold");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();


                        docPdf.Add(tableDetalle);

                        #endregion

                        PdfPTable tableFinal = new PdfPTable(1);

                        tableFinal.WidthPercentage = 70;
                        tableFinal.SetWidths(new float[] { 0.50f });
                        tableFinal.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf(" ", size, false, "", "");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        cell = CellPdf("Son : " + Impresion.Mercantil.Impresion.enLetras(Total.ToString()) + " " + oOrdenCompra.desMoneda, size, false, "c", "bold");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        docPdf.Add(tableFinal);
                    }

                    else if(Empresa == "ASSA")
                    {
                        PdfPTable table = new PdfPTable(3);

                        table.WidthPercentage = 70;
                        table.SetWidths(new float[] { 0.15f, 0.5f, 0.13f });
                        table.HorizontalAlignment = Element.ALIGN_CENTER;

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
                        table.CompleteRow();

                        cell = new PdfPCell();
                        cell = ReaderHelper.ImagenCell(RutaImagen, 80, Element.ALIGN_CENTER, Variables.SI, 1);
                        table.AddCell(cell);
                        cell = CellPdf(TituloGeneral, 13, true, "c", "bold");
                        table.AddCell(cell);
                        cell = CellPdf("Fecha Emisión: " + oOrdenCompra.fecEmision.Date.ToString("d"), 8, true, "c", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf(VariablesLocales.SesionUsuario.Empresa.NombreComercial, size, false, "", "bold");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        cell = CellPdf("Telefonos :" + VariablesLocales.SesionUsuario.Empresa.sTelefonos, size - 1, false, "", "bold");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf("RUC : " + VariablesLocales.SesionUsuario.Empresa.RUC, size, false, "", "bold");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf("E-mail :" + VariablesLocales.SesionUsuario.Empresa.sEmail, size - 1, false, "", "bold");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        cell = CellPdf("", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        docPdf.Add(table);

                        PdfPTable tableDatos = new PdfPTable(6);

                        tableDatos.WidthPercentage = 70;
                        tableDatos.SetWidths(new float[] { 0.13f, 0.02f, 0.3f, 0.13f, 0.02f, 0.15f });
                        tableDatos.HorizontalAlignment = Element.ALIGN_CENTER;

                        Persona oProveedor = AgenteMaestros.Proxy.RecuperarPersonaPorID(oOrdenCompra.idProveedor);

                        cell = CellPdf("Proveedor", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oProveedor.RazonSocial, size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("RUC", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oProveedor.RUC, size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf("Dirección", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oProveedor.DireccionCompleta, size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("Telf", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oProveedor.Telefonos, size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf("Forma de Pago", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.desFormaPago, size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("Fecha Requerida", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(Convert.ToDateTime(oOrdenCompra.fecRequerida).ToString("d"), size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf("Plazo Pago", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoPago.ToString() + " días", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("Plazo de Entrega", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoEntrega.ToString() + " días", size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf("Doc. Retención", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoPago.ToString() + " días", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("Solicitante ", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.desResponsable.ToString() + " días", size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf("Moneda ", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.desMoneda.ToString() + " días", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf("C.Costo ", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.desCCostos.ToString() + " días", size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();



                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos.AddCell(cell);
                        tableDatos.CompleteRow();

                        docPdf.Add(tableDatos);

                        PdfPTable tableDetalle = new PdfPTable(7);
                        tableDetalle.WidthPercentage = 70;
                        tableDetalle.SetWidths(new float[] { 0.08f, 0.4f, 0.09f, 0.05f, 0.10f, 0.05f, 0.10f });
                        tableDetalle.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("Código", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Descripción", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Cantidad", size, true, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Und.", size, true, "c", "");
                        tableDetalle.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "S/.")
                        {
                            cell = CellPdf(" Costo Unit. S/", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "US$")
                        {
                            cell = CellPdf(" Costo Unit. US $", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "€")
                        {
                            cell = CellPdf(" Costo Unit. €", size, true, "c", "");
                        }

                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Desc     (%)", size, true, "c", "");
                        tableDetalle.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "S/.")
                        {
                            cell = CellPdf("Costo Total     S/", size, true, "c", "");
                        }
                        if (oOrdenCompra.desMoneda == "US$")
                        {
                            cell = CellPdf("Costo Total     US $", size, true, "c", "");
                        }
                        if (oOrdenCompra.desMoneda == "€")
                        {
                            cell = CellPdf("Costo Total  €", size, true, "c", "");
                        }

                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        List<OrdenCompraItemE> oItem = oOrdenCompra.ListaOrdenesCompras;
                        decimal TotalISC = 0;
                        decimal TotalIGV = 0;
                        decimal Total = 0;

                        if (oItem != null)
                        {
                            if (oItem.Count > 0)
                            {
                                for (int i = 0; i < oItem.Count; i++)
                                {
                                    cell = CellPdf(oItem[i].numItem, size, true, "", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].desArticulo, size, true, "", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].CanOrdenada.ToString(), size, true, "c", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oListaUMedida.Where(x => x.idUMedida == oItem[i].idUMedidaCompra).ToList()[0].NomUMedidaCorto, size, true, "c", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].impPrecioUnitario.ToString("N6"), size, true, "c", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].porDescuento.ToString(), size, true, "c", "");
                                    tableDetalle.AddCell(cell);
                                    cell = CellPdf(oItem[i].impTotalItem.ToString("N2"), size, true, "r", "");
                                    tableDetalle.AddCell(cell);
                                    tableDetalle.CompleteRow();

                                    TotalISC += oItem[i].impIsc;
                                    TotalIGV += oItem[i].impIgv;
                                    Total += oItem[i].impTotalItem;

                                    if (oOrdenCompra.TipoOrdenCompra == "9")
                                    {
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle.AddCell(cell);
                                        cell = CellPdf(oItem[i].desLarga, size, true, "", "");
                                        tableDetalle.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle.AddCell(cell);
                                        tableDetalle.CompleteRow();
                                    }
                                }
                            }
                        }

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "S/.")
                        {
                            cell = CellPdf("S/", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "US$")
                        {
                            cell = CellPdf("US $", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "€")
                        {
                            cell = CellPdf("€", size, false, "r", "bold");
                        }

                        cell.Colspan = 2;
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(Total.ToString("N2"), size, true, "r", "bold");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "S/.")
                        {
                            cell = CellPdf("I.S.C.  S/", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "US$")
                        {
                            cell = CellPdf("I.S.C.  US $", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "€")
                        {
                            cell = CellPdf("I.S.C.  €", size, false, "r", "bold");
                        }

                        cell.Colspan = 2;
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(TotalISC.ToString("N2"), size, true, "r", "bold");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("IGV 18 %", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(TotalIGV.ToString("N2"), size, true, "r", "bold");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Total", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle.AddCell(cell);
                        cell = CellPdf((oOrdenCompra.impTotal).ToString("N2"), size, true, "r", "bold");
                        tableDetalle.AddCell(cell);
                        tableDetalle.CompleteRow();




                        docPdf.Add(tableDetalle);

                        PdfPTable tableFinal = new PdfPTable(1);

                        tableFinal.WidthPercentage = 70;
                        tableFinal.SetWidths(new float[] { 0.50f });
                        tableFinal.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf(" ", size, false, "", "");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        cell = CellPdf("Son : " + Impresion.Mercantil.Impresion.enLetras(oOrdenCompra.impTotal.ToString()) + " " + oOrdenCompra.Moneda, size, false, "c", "bold");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        docPdf.Add(tableFinal);

                        PdfPTable pie1 = new PdfPTable(7);

                        pie1.WidthPercentage = 70;
                        pie1.SetWidths(new float[] { 0.08f, 0.4f, 0.09f, 0.05f, 0.10f, 0.05f, 0.10f });
                        pie1.HorizontalAlignment = Element.ALIGN_CENTER;


                        cell = CellPdf("Nota: Facturar a Nombre de : " + VariablesLocales.SesionUsuario.Empresa.RazonSocial, size, true, "l", "");
                        cell.Colspan = 7;
                        pie1.AddCell(cell);
                        pie1.CompleteRow();

                        cell = CellPdf("RUC : " + VariablesLocales.SesionUsuario.Empresa.RUC + " -  Dirección :" + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, size, true, "l", "");
                        cell.Colspan = 7;
                        pie1.AddCell(cell);
                        pie1.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        cell.Colspan = 7;
                        pie1.AddCell(cell);
                        pie1.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        cell.Colspan = 7;
                        pie1.AddCell(cell);
                        pie1.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        cell.Colspan = 7;
                        pie1.AddCell(cell);
                        pie1.CompleteRow();

                        docPdf.Add(pie1);

                        PdfPTable pie2 = new PdfPTable(3);

                        pie2.WidthPercentage = 70;
                        pie2.SetWidths(new float[] { 0.28f, 0.34f, 0.25f });
                        pie2.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("____________________________", size, false, "c", "");
                        pie2.AddCell(cell);

                        cell = CellPdf(" ", size, false, "", "");
                        pie2.AddCell(cell);

                        cell = CellPdf("_________________________", size, false, "c", "");
                        pie2.AddCell(cell);
                        pie2.CompleteRow();


                        cell = CellPdf("RESPONSABLE DE ÁREA", size, false, "c", "");
                        pie2.AddCell(cell);

                        cell = CellPdf(" ", size, false, "", "");
                        pie2.AddCell(cell);

                        cell = CellPdf("CHRISTIAN I. MEZA CÁCERES", size, false, "c", "");
                        pie2.AddCell(cell);
                        pie2.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        pie2.AddCell(cell);

                        cell = CellPdf(" ", size, false, "", "");
                        pie2.AddCell(cell);

                        cell = CellPdf("GERENTE GENERAL", size, false, "c", "");
                        pie2.AddCell(cell);
                        pie2.CompleteRow();

                        docPdf.Add(pie2);

                        PdfPTable pie3 = new PdfPTable(1);

                        pie3.WidthPercentage = 70;
                        pie3.SetWidths(new float[] { 1.00f });
                        pie3.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("CONSIDERACIONES PARA LA RECEPCION DE FACTURA:", size, false, "l", "bold");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf("LUGAR DE RECEPCION DE FACTURA: " + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, size, false, "l", "bold");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf("ADJUNTADO LO SIGUIENTE: ", size, false, "l", "bold");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf("1.- Orden de compra firmada por el Gerente ", size, false, "l", "");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf("2.- Si es venta: Guia de remision con nombres, firma y sello de recepcion del producto", size, false, "l", "");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf("3.- Si es servicio: Orden de servicio u acta de conformidad con la firma y sello del responsable que solicito el servicio ", size, false, "l", "");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf("4.- Y cualquier otro documento involucrado en la operación", size, false, "l", "");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf("5.- Horario de pago proveedores: Martes y Jueves 14:30 a 17:30 horas en Av.Arica 1301 Breña (2do Piso). Teléfono:425-0547 ", size, false, "l", "bold");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf("OBSERVACIONES: ", size, true, "l", "");
                        cell.Rowspan = 2;
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf(" ", size, true, "l", "");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        cell = CellPdf(" " + oOrdenCompra.RazonSocial, size, true, "l", "");
                        pie3.AddCell(cell);
                        pie3.CompleteRow();

                        docPdf.Add(pie3);
                    }

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //Establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                }
            }
        }

        PdfPCell CellPdf(string titulo, int size, Boolean border, string align, string bold)
        {
            if (!border)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        void CrearOrdenCompra(OrdenCompraE OrdenCompra)
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
                    RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

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
                    TableDeta1.SetWidths(new float[] { 0.05f, 0.4f,0.09f,0.05f,0.09f, 0.09f, 0.05f, 0.10f, 0.05f, 0.10f });

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
                        TableDeta1.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f),-1,2));
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
                            TableDeta1.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S8"));
                            TableDeta1.CompleteRow();
                        }

                        TotalISC += item.impIsc;
                        TotalIGV += item.impIgv;
                        Total += item.impTotalItem;
                    }
                    DocumentoPdf.Add(TableDeta1);

                    PdfPTable TableDeta = new PdfPTable(7);
                    TableDeta.WidthPercentage = 98;
                    TableDeta.SetWidths(new float[] { 0.05f, 0.4f, 0.09f, 0.05f, 0.10f, 0.05f, 0.10f });

                    ////Filas en blanco
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    TableDeta.CompleteRow();

                    //*************************************************** Totales ******************************************************//
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
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("I.G.V. " + VariablesLocales.oListaImpuestos[0].Porcentaje.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2"));
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
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.CompleteRow();



                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    ELABORADO POR : " + VariablesLocales.SesionUsuario.Credencial, null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("    RECIBI CONFORME   ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2, "S3"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.CompleteRow();

                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("     FECHA Y HORA " + VariablesLocales.FechaHoy.ToString("G"), null, "N", null, FontFactory.GetFont("Arial", 3.25f), -1, 2));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S3"));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
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

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = MdiChildren.FirstOrDefault(x => x is frmOrdenDeCompra);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                String TipoOrden = String.Empty;

                if (rboBienes.Checked)
                {
                    TipoOrden = "0";
                }

                if (rboServ.Checked)
                {
                    TipoOrden = "1";
                }

                oFrm = new frmOrdenDeCompra(TipoOrden)
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
                if (bsOrdenesCompras.Count > 0)
                {
                    Form oFrm = MdiChildren.FirstOrDefault(x => x is frmOrdenDeCompra);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmOrdenDeCompra((OrdenCompraE)bsOrdenesCompras.Current)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsOrdenesCompras.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        AgenteAlmacen.Proxy.EliminarOrdenCompra(((OrdenCompraE)bsOrdenesCompras.Current).idEmpresa, ((OrdenCompraE)bsOrdenesCompras.Current).idOrdenCompra);
                        Global.MensajeComunicacion(Mensajes.GeneracionOrdenCompra);
                        Buscar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {
                if (bsOrdenesCompras.Count > 0)
                {
                    Form oFrm = null;

                    OrdenCompraE oOrdenCompra = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(((OrdenCompraE)bsOrdenesCompras.Current).idEmpresa, ((OrdenCompraE)bsOrdenesCompras.Current).idOrdenCompra);

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" //TODO AGROGENESIS
                        || VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318"
                        || VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" 
                        || VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410"
                        || VariablesLocales.SesionUsuario.Empresa.RUC == "20513078952" || VariablesLocales.SesionUsuario.Empresa.RUC == "20601712513")
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionBase);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmImpresionBase(oOrdenCompra, "Vista Previa " + oOrdenCompra.numOrdenCompra);
                    }
                    else if(VariablesLocales.SesionUsuario.Empresa.RUC == "20515657119" || VariablesLocales.SesionUsuario.Empresa.RUC == "20543435661") //TODO ASSA
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenDeCompraPDF);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmOrdenDeCompraPDF(oOrdenCompra, oListaUMedida, "ASSA");
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20512340220" ) //TODO IRUDIAK
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenDeCompraPDF);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmOrdenDeCompraPDF(oOrdenCompra, oListaUMedida, "IRUDIAK");
                    }
                    else
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenDeCompraPDF);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmOrdenDeCompraPDF(oOrdenCompra, oListaUMedida);
                    }
                    
                    oFrm.MdiParent = MdiParent;
                    oFrm.Show();
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
                DateTime fecIni = dtpInicio.Value.Date;
                DateTime fecFin = dtpFinal.Value.Date;
                Int32 idProveedor = rbTodos.Checked ? Variables.Cero : idPersona;
                String rbo = String.Empty;

                if (rboBienes.Checked == true)
                {
                    rbo = "1";
                }

                if (rboServ.Checked == true)
                {
                    rbo = "9";
                }

                bsOrdenesCompras.DataSource = oListaOrdenCompra = AgenteAlmacen.Proxy.ListarOrdenCompra(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idProveedor, fecIni, fecFin,"", rbo);
                bsOrdenesCompras.ResetBindings(false);

                lblRegistros.Text = "Registros O.C. " + bsOrdenesCompras.Count.ToString();
                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmOrdenDeCompra oFrm = sender as frmOrdenDeCompra;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoOrdenDeCompra_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            oListaUMedida =  AgenteGenerales.Proxy.ListarUMedida("%");
        }

        private void btProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaProveedor oFrm = new frmBusquedaProveedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProveedor != null)
                {
                    idPersona = oFrm.oProveedor.IdPersona;
                    txtRuc.Text = oFrm.oProveedor.RUC;
                    txtRazonSocial.Text = oFrm.oProveedor.RazonSocial;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked)
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.Text = String.Empty;
                btProveedor.Enabled = false;
            }
            else
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btProveedor.Enabled = true;
                btProveedor.Focus();
            }
        }

        private void dgvListadoFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        } 

        private void dgvListadoOC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((String)dgvListadoOC.Rows[e.RowIndex].Cells["desTipEstado"].Value == "CERRADO")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorCerrado;
                }
            }
            else if ((String)dgvListadoOC.Rows[e.RowIndex].Cells["desTipEstado"].Value == "ANULADO")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
        }

        private void enviarPorCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OrdenCompraE oOrdenCompra = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(((OrdenCompraE)bsOrdenesCompras.Current).idEmpresa, ((OrdenCompraE)bsOrdenesCompras.Current).idOrdenCompra);

                if (oOrdenCompra != null)
                {
                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" //TODO AGROGENESIS
                        || VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318"
                        || VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681"
                        || VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410"
                        || VariablesLocales.SesionUsuario.Empresa.RUC == "20513078952" || VariablesLocales.SesionUsuario.Empresa.RUC == "20601712513")
                    {
                        CrearOrdenCompra(oOrdenCompra);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20515657119" || VariablesLocales.SesionUsuario.Empresa.RUC == "20543435661") //TODO ASSA
                    {
                        CrearPdf(oOrdenCompra,"ASSA");
                    }
                    else
                    {
                        CrearPdf(oOrdenCompra,"");
                    }

                    frmEnvioCorreos oFrm = new frmEnvioCorreos(oOrdenCompra, RutaPdf);
                    oFrm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvListadoOC_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaOrdenCompra.Count > 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Nro de Orden de Compra
                    if (e.ColumnIndex == dgvListadoOC.Columns["numOrdenCompra"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaOrdenCompra = (from x in oListaOrdenCompra orderby x.numOrdenCompra ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaOrdenCompra = (from x in oListaOrdenCompra orderby x.numOrdenCompra descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Fecha de emisión
                    if (e.ColumnIndex == dgvListadoOC.Columns["fecEmision"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaOrdenCompra = (from x in oListaOrdenCompra orderby x.fecEmision ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaOrdenCompra = (from x in oListaOrdenCompra orderby x.fecEmision descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Razón Social
                    if (e.ColumnIndex == dgvListadoOC.Columns["RazonSocial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaOrdenCompra = (from x in oListaOrdenCompra orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaOrdenCompra = (from x in oListaOrdenCompra orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }

                bsOrdenesCompras.DataSource = oListaOrdenCompra;
                bsOrdenesCompras.ResetBindings(false);
            }
        }

        #endregion

    }
}
