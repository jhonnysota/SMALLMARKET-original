using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Almacen
{
    public partial class frmOrdenDeCompraPDF : FrmMantenimientoBase
    {

        #region Constructores

        public frmOrdenDeCompraPDF()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmOrdenDeCompraPDF(OrdenCompraE oItem, List<UMedidaE> oListaUM)
            :this()
        {
            oOrdenCompra = oItem;
            oListaUMedida = oListaUM;

            oEmpresaImagen = AgenteMaestros.Proxy.ObtenerEmpresaSinImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oEmpresaImagen2 = AgenteMaestros.Proxy.ObtenerEmpresaSinImagenes(1, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (!Directory.Exists(RutaImagen))
            {
                Directory.CreateDirectory(RutaImagen);
            }

            if (oEmpresaImagen != null)
            {
                RutaImagen += oEmpresaImagen.Nombre + oEmpresaImagen.Extension;
                RutaImagen2 += oEmpresaImagen2.Nombre + oEmpresaImagen2.Extension;
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

                if (!File.Exists(RutaImagen2))
                {
                    oEmpresaImagen2 = AgenteMaestros.Proxy.ObtenerEmpresaConImagenes(1, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    if (oEmpresaImagen2.Imagen != null)
                    {
                        Global.EscribirImagenEnFile(oEmpresaImagen2.Imagen, RutaImagen2);
                    }
                    else
                    {
                        RutaImagen2 = String.Empty;
                    }
                }


                ConvertirApdf();

                wbNavegador.Navigate(RutaGeneral);
            }


        }

        public frmOrdenDeCompraPDF(OrdenCompraE oItem, List<UMedidaE> oListaUM, String NombreEmpresa)
           :this()
        {
            NomEmpresa = NombreEmpresa;
            oOrdenCompra = oItem;
            oListaUMedida = oListaUM;

            oEmpresaImagen = AgenteMaestros.Proxy.ObtenerEmpresaSinImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oEmpresaImagen2 = AgenteMaestros.Proxy.ObtenerEmpresaSinImagenes(1, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (!Directory.Exists(RutaImagen))
            {
                Directory.CreateDirectory(RutaImagen);
            }

            if (oEmpresaImagen != null)
            {
                RutaImagen += oEmpresaImagen.Nombre + oEmpresaImagen.Extension;
                RutaImagen2 += oEmpresaImagen2.Nombre + oEmpresaImagen2.Extension;
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

                if (!File.Exists(RutaImagen2))
                {
                    oEmpresaImagen2 = AgenteMaestros.Proxy.ObtenerEmpresaConImagenes(1, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    if (oEmpresaImagen2.Imagen != null)
                    {
                        Global.EscribirImagenEnFile(oEmpresaImagen2.Imagen, RutaImagen2);
                    }
                    else
                    {
                        RutaImagen2 = String.Empty;
                    }
                }


                ConvertirApdf();

                wbNavegador.Navigate(RutaGeneral);
            }


        } 

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        OrdenCompraE oOrdenCompra;
        string RutaGeneral;
        List<UMedidaE> oListaUMedida;
        String RutaTemp = String.Empty;
        EmpresaImagenesE oEmpresaImagen = null;
        EmpresaImagenesE oEmpresaImagen2 = null;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        String RutaImagen2 = @"C:\AmazonErp\Logo\";
        String NomEmpresa = String.Empty;

        #endregion

        #region crear PDF

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            Guid NombreAleatorio = Guid.NewGuid();
            String NombreReporte = @"\Orden_Compra_" + NombreAleatorio.ToString();
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

                if (oOrdenCompra.TipoOrdenCompra == "1")
                {
                    TituloGeneral = " ORDEN DE COMPRA Nro. " + VariablesLocales.SesionLocal.Siglas  + " "+ oOrdenCompra.numOrdenCompra;
                }

                if (oOrdenCompra.TipoOrdenCompra == "9")
                {
                    TituloGeneral = " ORDEN DE SERVICIO Nro. " + VariablesLocales.SesionLocal.Siglas + " "+ oOrdenCompra.numOrdenCompra;
                }

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

                #region Empresa Aleatoria

                if (NomEmpresa == "")
                {

                    if (VariablesLocales.SesionUsuario.Empresa.RUC != "20523201868")
                    {
                        if (VariablesLocales.SesionUsuario.Empresa.RUC != "20601328179")
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

                            if (oOrdenCompra.desMoneda == "Sol Peruano")
                            {
                                cell = CellPdf(" Precio Unit. S/", size, true, "c", "");
                            }

                            if (oOrdenCompra.desMoneda == "Dólares Americanos")
                            {
                                cell = CellPdf(" Precio Unit. US $", size, true, "c", "");
                            }

                            if (oOrdenCompra.desMoneda == "Euros")
                            {
                                cell = CellPdf(" Precio Unit. €", size, true, "c", "");
                            }

                            tableDetalle.AddCell(cell);
                            cell = CellPdf("Desc     (%)", size, true, "c", "");
                            tableDetalle.AddCell(cell);

                            if (oOrdenCompra.desMoneda == "Sol Peruano")
                            {
                                cell = CellPdf("Importe Total     S/", size, true, "c", "");
                            }
                            if (oOrdenCompra.desMoneda == "Dólares Americanos")
                            {
                                cell = CellPdf("Importe Total     US $", size, true, "c", "");
                            }
                            if (oOrdenCompra.desMoneda == "Euros")
                            {
                                cell = CellPdf("Importe Total  €", size, true, "c", "");
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

                            if (oOrdenCompra.desMoneda == "Sol Peruano")
                            {
                                cell = CellPdf("S/", size, false, "r", "bold");
                            }

                            if (oOrdenCompra.desMoneda == "Dólares Americanos")
                            {
                                cell = CellPdf("US $", size, false, "r", "bold");
                            }

                            if (oOrdenCompra.desMoneda == "Euros")
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

                            if (oOrdenCompra.desMoneda == "Sol Peruano")
                            {
                                cell = CellPdf("I.S.C.  S/", size, false, "r", "bold");
                            }

                            if (oOrdenCompra.desMoneda == "Dólares Americanos")
                            {
                                cell = CellPdf("I.S.C.  US $", size, false, "r", "bold");
                            }

                            if (oOrdenCompra.desMoneda == "Euros")
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

                            cell = CellPdf("Son : " + Impresion.Mercantil.Impresion.enLetras(oOrdenCompra.impTotal.ToString()) + " " + oOrdenCompra.desMoneda, size, false, "c", "bold");
                            tableFinal.AddCell(cell);
                            tableFinal.CompleteRow();

                            cell = CellPdf(" ", size, false, "", "");
                            tableFinal.AddCell(cell);
                            tableFinal.CompleteRow();

                            cell = CellPdf(" ", size, false, "", "");
                            tableFinal.AddCell(cell);
                            tableFinal.CompleteRow();

                            docPdf.Add(tableFinal);
                        }
                    }

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868") //INTERMETALS
                    {
                        PdfPTable table2 = new PdfPTable(3);

                        table2.WidthPercentage = 70;
                        table2.SetWidths(new float[] { 0.15f, 0.5f, 0.13f });
                        table2.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        table2.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        table2.CompleteRow();

                        cell = new PdfPCell();
                        cell = ReaderHelper.ImagenCell(RutaImagen, 80, Element.ALIGN_CENTER, Variables.SI, 1);
                        table2.AddCell(cell);
                        cell = CellPdf(TituloGeneral, 13, true, "c", "bold");
                        table2.AddCell(cell);
                        cell = CellPdf("Fecha Emisión: " + oOrdenCompra.fecEmision.Date.ToString("d"), 8, true, "c", "");
                        table2.AddCell(cell);
                        table2.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        table2.CompleteRow();

                        cell = CellPdf(VariablesLocales.SesionUsuario.Empresa.NombreComercial, size, false, "", "bold");
                        cell.Colspan = 2;
                        table2.AddCell(cell);
                        cell = CellPdf("Telefonos :" + VariablesLocales.SesionUsuario.Empresa.sTelefonos, size - 1, false, "", "bold");
                        table2.AddCell(cell);
                        table2.CompleteRow();

                        cell = CellPdf("RUC : " + VariablesLocales.SesionUsuario.Empresa.RUC, size, false, "", "bold");
                        cell.Colspan = 2;
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        table2.CompleteRow();

                        cell = CellPdf("E-mail :" + VariablesLocales.SesionUsuario.Empresa.sEmail, size - 1, false, "", "bold");
                        cell.Colspan = 2;
                        table2.AddCell(cell);
                        cell = CellPdf("", size, false, "", "");
                        table2.AddCell(cell);
                        table2.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table2.AddCell(cell);
                        table2.CompleteRow();

                        docPdf.Add(table2);

                        PdfPTable tableDatos2 = new PdfPTable(6);

                        tableDatos2.WidthPercentage = 70;
                        tableDatos2.SetWidths(new float[] { 0.13f, 0.02f, 0.3f, 0.13f, 0.02f, 0.15f });
                        tableDatos2.HorizontalAlignment = Element.ALIGN_CENTER;

                        Persona oProveedor2 = AgenteMaestros.Proxy.RecuperarPersonaPorID(oOrdenCompra.idProveedor);

                        cell = CellPdf("Proveedor", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(oProveedor2.RazonSocial, size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf("RUC", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(oProveedor2.RUC, size, false, "", "");
                        tableDatos2.AddCell(cell);
                        tableDatos2.CompleteRow();

                        cell = CellPdf("Dirección", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(oProveedor2.DireccionCompleta, size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf("Telf", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(oProveedor2.Telefonos, size, false, "", "");
                        tableDatos2.AddCell(cell);
                        tableDatos2.CompleteRow();

                        cell = CellPdf("Forma de Pago", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.desFormaPago, size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf("Fecha Requerida", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(Convert.ToDateTime(oOrdenCompra.fecRequerida).ToString("d"), size, false, "", "");
                        tableDatos2.AddCell(cell);
                        tableDatos2.CompleteRow();

                        cell = CellPdf("Plazo Pago", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoPago.ToString() + " días", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf("Plazo de Entrega", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoEntrega.ToString() + " días", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        tableDatos2.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf("Fecha de Solicitud", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(Convert.ToDateTime(oOrdenCompra.fecEmision).ToString("d"), size, false, "", "");
                        tableDatos2.AddCell(cell);
                        tableDatos2.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        tableDatos2.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos2.AddCell(cell);
                        tableDatos2.CompleteRow();

                        docPdf.Add(tableDatos2);

                        PdfPTable tableDetalle2 = new PdfPTable(7);

                        tableDetalle2.WidthPercentage = 70;
                        tableDetalle2.SetWidths(new float[] { 0.08f, 0.4f, 0.09f, 0.05f, 0.10f, 0.05f, 0.10f });
                        tableDetalle2.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("Código", size, true, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf("Descripción", size, true, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf("Cantidad", size, true, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf("Und.", size, true, "c", "");
                        tableDetalle2.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf(" Precio Unit.       S/", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf(" Precio Unit.       US $", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf(" Precio Unit.       €", size, true, "c", "");
                        }

                        tableDetalle2.AddCell(cell);
                        cell = CellPdf("Desc     (%)", size, true, "c", "");
                        tableDetalle2.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("Importe Total     S/", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("Importe Total     US $", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf("Importe Total     €", size, true, "c", "");
                        }

                        tableDetalle2.AddCell(cell);
                        tableDetalle2.CompleteRow();

                        List<OrdenCompraItemE> oItem2 = oOrdenCompra.ListaOrdenesCompras;
                        decimal TotalISC2 = 0;
                        decimal TotalIGV2 = 0;
                        decimal Total2 = 0;

                        if (oItem2 != null)
                        {
                            if (oItem2.Count > 0)
                            {
                                for (int i = 0; i < oItem2.Count; i++)
                                {
                                    cell = CellPdf(oItem2[i].numItem, size, true, "", "");
                                    tableDetalle2.AddCell(cell);
                                    cell = CellPdf(oItem2[i].desArticulo, size, true, "", "");
                                    tableDetalle2.AddCell(cell);
                                    cell = CellPdf(oItem2[i].CanOrdenada.ToString(), size, true, "c", "");
                                    tableDetalle2.AddCell(cell);
                                    cell = CellPdf(oListaUMedida.Where(x => x.idUMedida == oItem2[i].idUMedidaCompra).ToList()[0].NomUMedidaCorto, size, true, "c", "");
                                    tableDetalle2.AddCell(cell);
                                    cell = CellPdf(oItem2[i].impPrecioUnitario.ToString("N6"), size, true, "c", "");
                                    tableDetalle2.AddCell(cell);
                                    cell = CellPdf(oItem2[i].porDescuento.ToString(), size, true, "c", "");
                                    tableDetalle2.AddCell(cell);
                                    cell = CellPdf(oItem2[i].impVentaItem.ToString("N2"), size, true, "r", "");
                                    tableDetalle2.AddCell(cell);
                                    tableDetalle2.CompleteRow();

                                    TotalISC2 += oItem2[i].impIsc;
                                    TotalIGV2 += oItem2[i].impIgv;
                                    Total2 += oItem2[i].impVentaItem;

                                    if (oOrdenCompra.TipoOrdenCompra == "9")
                                    {
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle2.AddCell(cell);
                                        cell = CellPdf(oItem2[i].desLarga, size, true, "", "");
                                        tableDetalle2.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle2.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle2.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle2.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle2.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle2.AddCell(cell);
                                        tableDetalle2.CompleteRow();
                                    }
                                }
                            }
                        }

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        tableDetalle2.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("S/", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("US $", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf("€", size, false, "r", "bold");
                        }

                        cell.Colspan = 2;
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(Total2.ToString("N2"), size, true, "r", "bold");
                        tableDetalle2.AddCell(cell);
                        tableDetalle2.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("I.S.C. S/ ", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("I.S.C. US $ ", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf("I.S.C. € ", size, false, "r", "bold");
                        }

                        cell.Colspan = 2;
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(TotalISC2.ToString("N2"), size, true, "r", "bold");
                        tableDetalle2.AddCell(cell);
                        tableDetalle2.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf("IGV 18.00", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(TotalIGV2.ToString("N2"), size, true, "r", "bold");
                        tableDetalle2.AddCell(cell);
                        tableDetalle2.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf("Total", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle2.AddCell(cell);
                        cell = CellPdf((oOrdenCompra.impTotal).ToString("N2"), size, true, "r", "bold");
                        tableDetalle2.AddCell(cell);
                        tableDetalle2.CompleteRow();

                        docPdf.Add(tableDetalle2);

                        PdfPTable tableFinal2 = new PdfPTable(1);

                        tableFinal2.WidthPercentage = 70;
                        tableFinal2.SetWidths(new float[] { 0.50f });
                        tableFinal2.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf(" ", size, false, "", "");
                        tableFinal2.AddCell(cell);
                        tableFinal2.CompleteRow();

                        cell = CellPdf("Son : " + Impresion.Mercantil.Impresion.enLetras(oOrdenCompra.impTotal.ToString()) + " " + oOrdenCompra.desMoneda, size, false, "c", "bold");
                        tableFinal2.AddCell(cell);
                        tableFinal2.CompleteRow();

                        docPdf.Add(tableFinal2);

                        PdfPTable tableObs = new PdfPTable(2);

                        tableObs.WidthPercentage = 70;
                        tableObs.SetWidths(new float[] { 0.2f, 0.8f });
                        tableObs.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("OBSERVACIONES:", size, false, "c", "bold");
                        tableObs.AddCell(cell);

                        cell = CellPdf("Facturar a : " + VariablesLocales.SesionUsuario.Empresa.RUC + VariablesLocales.SesionUsuario.Empresa.RazonSocial, size, true, "l", "bold");
                        tableObs.AddCell(cell);
                        tableObs.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableObs.AddCell(cell);

                        cell = CellPdf(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, size, true, "l", "bold");
                        tableObs.AddCell(cell);
                        tableObs.CompleteRow();

                        docPdf.Add(tableObs);

                        PdfPTable tableETS = new PdfPTable(2);

                        tableETS.WidthPercentage = 70;
                        tableETS.SetWidths(new float[] { 0.2f, 0.8f });
                        tableETS.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("Dirección De Entrega:", size, true, "c", "bold");
                        tableETS.AddCell(cell);

                        cell = CellPdf(oOrdenCompra.LugarEntrega, size, true, "l", "bold");
                        tableETS.AddCell(cell);
                        tableETS.CompleteRow();

                        cell = CellPdf("Condicion De Pago : ", size, true, "c", "bold");
                        tableETS.AddCell(cell);

                        cell = CellPdf(oOrdenCompra.desFormaPago, size, true, "l", "bold");
                        tableETS.AddCell(cell);
                        tableETS.CompleteRow();

                        cell = CellPdf("Tiempo De Entrega : ", size, true, "c", "bold");
                        tableETS.AddCell(cell);

                        cell = CellPdf(oOrdenCompra.numPlazoPago.ToString() + " días", size, true, "l", "bold");
                        tableETS.AddCell(cell);
                        tableETS.CompleteRow();

                        docPdf.Add(tableETS);

                        PdfPTable tableCON = new PdfPTable(2);

                        tableCON.WidthPercentage = 70;
                        tableCON.SetWidths(new float[] { 0.2f, 0.8f });
                        tableCON.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("Condiciones:", size, false, "l", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf(" ", size, false, "", "");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf("Ordenes : ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf("Estrictamente no nos responsabilizamos por el pago de Facturas que no esten amparadas por una Orden de Compra", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf("Calidad : ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf(" En este caso de que la calidad, cantidad o marca de los productos y/o materiales que nos envia, no estén de acuerdo a lo especificado en esta orden de compra, seran devuelto a la firma Vendedora, por su cuenta y riesgo.", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf("Despachos : ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf("El envío de los materiales solicitados en esta Orden, debe efectuarse en la fecha y lugar indicado. Nos reservamos el derecho de rechazar los materiales llegados despues de la fecha establecida como plazo de entrega.", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf("Precios : ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf("No estamos obligados a pagar un mayor precio de lo estipulado en esta Orden.", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf("Penalidad : ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf("Nos reservamos el derecho de cancelar y/o reclamar pagos de daños y perjuicios, si no cumplimos los terminos y condiciones aceptadas en esta Orden.", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf("Indicaciones : ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf("Junto con la mercaderia enviar 1 copia de la orden de compra, guia de remision, factura y certificado de calidad respectivo de lo contrario no se recepcionara la mercaderia.aceptadas en esta Orden.", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf(" ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf("INTERMETALS R&D S.A.C. PODRÁ  ANULAR  LA  PRESENTE  ORDEN  DE  COMPRA  EN  CASO  DE  HABER  INCUMPLIMIENTO POR PARTE DEL PROVEEDOR EN LOS PLAZOS DE ENTREGA O INCONFORMIDADES EN EL PRODUCTO APROBADO EN LA ORDEN DE COMPRA.", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf(" ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf("INTERMETALS R&D S.A.C. TRASPASARÁ  TODO  PERJUICIO  ECONÓMICO  QUE  PUDIERA  CAUSAR  EL  INCUMPLIMIENTO  POR PARTE DEL PROVEEDOR EN LOS PLAZOS DE ENTREGA O INCORFORMIDADES EN EL PRODUCTO APROBADO EN LA ORDEN DE COMPRA.", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();

                        cell = CellPdf(" ", size, true, "c", "bold");
                        tableCON.AddCell(cell);

                        cell = CellPdf("PENALIDADES  POR  PLAZOS  DE  ENTREGA:  1%  POR  CADA  DIA  DE  INCUMPLIMIENTO  EN  LA  ORDEN  DE  COMPRA  Y  3%  POR CADA DIA A PARTIR DEL 5TO DIA DE INCUMPLIMIENTO.", size, true, "l", "bold");
                        tableCON.AddCell(cell);
                        tableCON.CompleteRow();



                        docPdf.Add(tableCON);

                        PdfPTable tableImagen = new PdfPTable(1);

                        tableImagen.WidthPercentage = 70;
                        tableImagen.SetWidths(new float[] { 3f });
                        tableImagen.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = new PdfPCell();
                        cell = ReaderHelper.ImagenCell(RutaImagen2, 400, Element.ALIGN_CENTER, Variables.NO, 1);
                        tableImagen.AddCell(cell);
                        tableImagen.CompleteRow();
                        docPdf.Add(tableImagen);
                    }

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179") //FFS INDUSTRY PERU S.A.C.
                    {
                        PdfPTable table3 = new PdfPTable(3);

                        table3.WidthPercentage = 70;
                        table3.SetWidths(new float[] { 0.15f, 0.5f, 0.13f });
                        table3.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        table3.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        table3.CompleteRow();

                        cell = new PdfPCell();
                        cell = ReaderHelper.ImagenCell(RutaImagen, 80, Element.ALIGN_CENTER, Variables.SI, 1);
                        table3.AddCell(cell);
                        cell = CellPdf(TituloGeneral, 13, true, "c", "bold");
                        table3.AddCell(cell);
                        cell = CellPdf("Fecha Emisión: " + oOrdenCompra.fecEmision.Date.ToString("d"), 8, true, "c", "");
                        table3.AddCell(cell);
                        table3.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        table3.CompleteRow();

                        cell = CellPdf(VariablesLocales.SesionUsuario.Empresa.NombreComercial, size, false, "", "bold");
                        cell.Colspan = 2;
                        table3.AddCell(cell);
                        cell = CellPdf("Telefonos :" + VariablesLocales.SesionUsuario.Empresa.sTelefonos, size - 1, false, "", "bold");
                        table3.AddCell(cell);
                        table3.CompleteRow();

                        cell = CellPdf("RUC : " + VariablesLocales.SesionUsuario.Empresa.RUC, size, false, "", "bold");
                        cell.Colspan = 2;
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        table3.CompleteRow();

                        cell = CellPdf("E-mail :" + VariablesLocales.SesionUsuario.Empresa.sEmail, size - 1, false, "", "bold");
                        cell.Colspan = 2;
                        table3.AddCell(cell);
                        cell = CellPdf("", size, false, "", "");
                        table3.AddCell(cell);
                        table3.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table3.AddCell(cell);
                        table3.CompleteRow();

                        docPdf.Add(table3);

                        PdfPTable tableDatos3 = new PdfPTable(6);

                        tableDatos3.WidthPercentage = 70;
                        tableDatos3.SetWidths(new float[] { 0.13f, 0.02f, 0.3f, 0.13f, 0.02f, 0.15f });
                        tableDatos3.HorizontalAlignment = Element.ALIGN_CENTER;

                        Persona oProveedor3 = AgenteMaestros.Proxy.RecuperarPersonaPorID(oOrdenCompra.idProveedor);

                        cell = CellPdf("Proveedor", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(oProveedor3.RazonSocial, size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf("RUC", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(oProveedor3.RUC, size, false, "", "");
                        tableDatos3.AddCell(cell);
                        tableDatos3.CompleteRow();

                        cell = CellPdf("Dirección", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(oProveedor3.DireccionCompleta, size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf("Telf", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(oProveedor3.Telefonos, size, false, "", "");
                        tableDatos3.AddCell(cell);
                        tableDatos3.CompleteRow();

                        cell = CellPdf("Forma de Pago", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.desFormaPago, size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf("Fecha Requerida", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(Convert.ToDateTime(oOrdenCompra.fecRequerida).ToString("d"), size, false, "", "");
                        tableDatos3.AddCell(cell);
                        tableDatos3.CompleteRow();

                        cell = CellPdf("Plazo Pago", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoPago.ToString() + " días", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf("Plazo de Entrega", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.numPlazoEntrega.ToString() + " días", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        tableDatos3.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf("Fecha de Solicitud", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(Convert.ToDateTime(oOrdenCompra.fecEmision).ToString("d"), size, false, "", "");
                        tableDatos3.AddCell(cell);
                        tableDatos3.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        tableDatos3.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tableDatos3.AddCell(cell);
                        tableDatos3.CompleteRow();

                        docPdf.Add(tableDatos3);

                        PdfPTable tableDetalle3 = new PdfPTable(7);

                        tableDetalle3.WidthPercentage = 70;
                        tableDetalle3.SetWidths(new float[] { 0.08f, 0.4f, 0.09f, 0.05f, 0.10f, 0.05f, 0.10f });
                        tableDetalle3.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("Código", size, true, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf("Descripción", size, true, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf("Cantidad", size, true, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf("Und.", size, true, "c", "");
                        tableDetalle3.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf(" Precio Unit.       S/", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf(" Precio Unit.       US $", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf(" Precio Unit.       €", size, true, "c", "");
                        }

                        tableDetalle3.AddCell(cell);
                        cell = CellPdf("Desc     (%)", size, true, "c", "");
                        tableDetalle3.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("Importe Total     S/", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("Importe Total     US $", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf("Importe Total     €", size, true, "c", "");
                        }

                        tableDetalle3.AddCell(cell);
                        tableDetalle3.CompleteRow();

                        List<OrdenCompraItemE> oItem3 = oOrdenCompra.ListaOrdenesCompras;
                        decimal TotalISC3 = 0;
                        decimal TotalIGV3 = 0;
                        decimal Total3 = 0;

                        if (oItem3 != null)
                        {
                            if (oItem3.Count > 0)
                            {
                                for (int i = 0; i < oItem3.Count; i++)
                                {
                                    cell = CellPdf(oItem3[i].numItem, size, true, "", "");
                                    tableDetalle3.AddCell(cell);
                                    cell = CellPdf(oItem3[i].desArticulo, size, true, "", "");
                                    tableDetalle3.AddCell(cell);
                                    cell = CellPdf(oItem3[i].CanOrdenada.ToString(), size, true, "c", "");
                                    tableDetalle3.AddCell(cell);
                                    cell = CellPdf(oListaUMedida.Where(x => x.idUMedida == oItem3[i].idUMedidaCompra).ToList()[0].NomUMedidaCorto, size, true, "c", "");
                                    tableDetalle3.AddCell(cell);
                                    cell = CellPdf(oItem3[i].impPrecioUnitario.ToString("N6"), size, true, "c", "");
                                    tableDetalle3.AddCell(cell);
                                    cell = CellPdf(oItem3[i].porDescuento.ToString(), size, true, "c", "");
                                    tableDetalle3.AddCell(cell);
                                    cell = CellPdf(oItem3[i].impVentaItem.ToString("N2"), size, true, "r", "");
                                    tableDetalle3.AddCell(cell);
                                    tableDetalle3.CompleteRow();

                                    TotalISC3 += oItem3[i].impIsc;
                                    TotalIGV3 += oItem3[i].impIgv;
                                    Total3 += oItem3[i].impVentaItem;

                                    if (oOrdenCompra.TipoOrdenCompra == "9")
                                    {
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle3.AddCell(cell);
                                        cell = CellPdf(oItem3[i].desLarga, size, true, "", "");
                                        tableDetalle3.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle3.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle3.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle3.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle3.AddCell(cell);
                                        cell = CellPdf(" ", size, false, "c", "");
                                        tableDetalle3.AddCell(cell);
                                        tableDetalle3.CompleteRow();
                                    }
                                }
                            }
                        }

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        tableDetalle3.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("S/", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("US $", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf("€", size, false, "r", "bold");
                        }

                        cell.Colspan = 2;
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(Total3.ToString("N2"), size, true, "r", "bold");
                        tableDetalle3.AddCell(cell);
                        tableDetalle3.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("I.S.C.  S/", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("I.S.C.  US $", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf("I.S.C.  €", size, false, "r", "bold");
                        }

                        cell.Colspan = 2;
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(TotalISC3.ToString("N2"), size, true, "r", "bold");
                        tableDetalle3.AddCell(cell);
                        tableDetalle3.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf("IGV 18.00", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(TotalIGV3.ToString("N2"), size, true, "r", "bold");
                        tableDetalle3.AddCell(cell);
                        tableDetalle3.CompleteRow();

                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf("Total", size, false, "r", "bold");
                        cell.Colspan = 2;
                        tableDetalle3.AddCell(cell);
                        cell = CellPdf((oOrdenCompra.impTotal).ToString("N2"), size, true, "r", "bold");
                        tableDetalle3.AddCell(cell);
                        tableDetalle3.CompleteRow();

                        docPdf.Add(tableDetalle3);

                        PdfPTable tableFinal3 = new PdfPTable(1);

                        tableFinal3.WidthPercentage = 70;
                        tableFinal3.SetWidths(new float[] { 0.50f });
                        tableFinal3.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf(" ", size, false, "", "");
                        tableFinal3.AddCell(cell);
                        tableFinal3.CompleteRow();

                        cell = CellPdf("Son : " + Impresion.Mercantil.Impresion.enLetras(oOrdenCompra.impTotal.ToString()) + " " + oOrdenCompra.desMoneda, size, false, "c", "bold");
                        tableFinal3.AddCell(cell);
                        tableFinal3.CompleteRow();

                        docPdf.Add(tableFinal3);

                        PdfPTable tableObs2 = new PdfPTable(2);

                        tableObs2.WidthPercentage = 70;
                        tableObs2.SetWidths(new float[] { 0.2f, 0.8f });
                        tableObs2.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("OBSERVACIONES:", size, false, "c", "bold");
                        tableObs2.AddCell(cell);

                        cell = CellPdf("Facturar a : " + VariablesLocales.SesionUsuario.Empresa.RUC + VariablesLocales.SesionUsuario.Empresa.RazonSocial, size, true, "l", "bold");
                        tableObs2.AddCell(cell);
                        tableObs2.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableObs2.AddCell(cell);

                        cell = CellPdf(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, size, true, "l", "bold");
                        tableObs2.AddCell(cell);
                        tableObs2.CompleteRow();

                        docPdf.Add(tableObs2);

                        PdfPTable tableETS2 = new PdfPTable(2);

                        tableETS2.WidthPercentage = 70;
                        tableETS2.SetWidths(new float[] { 0.2f, 0.8f });
                        tableETS2.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("Dirección De Entrega:", size, true, "c", "bold");
                        tableETS2.AddCell(cell);

                        cell = CellPdf(oOrdenCompra.LugarEntrega, size, true, "l", "bold");
                        tableETS2.AddCell(cell);
                        tableETS2.CompleteRow();

                        cell = CellPdf("Condicion De Pago : ", size, true, "c", "bold");
                        tableETS2.AddCell(cell);

                        cell = CellPdf(oOrdenCompra.desFormaPago, size, true, "l", "bold");
                        tableETS2.AddCell(cell);
                        tableETS2.CompleteRow();

                        cell = CellPdf("Tiempo De Entrega : ", size, true, "c", "bold");
                        tableETS2.AddCell(cell);

                        cell = CellPdf(oOrdenCompra.numPlazoPago.ToString() + " días", size, true, "l", "bold");
                        tableETS2.AddCell(cell);
                        tableETS2.CompleteRow();

                        docPdf.Add(tableETS2);

                        PdfPTable tableCON2 = new PdfPTable(2);

                        tableCON2.WidthPercentage = 70;
                        tableCON2.SetWidths(new float[] { 0.2f, 0.8f });
                        tableCON2.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf("Condiciones:", size, false, "l", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf(" ", size, false, "", "");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf("Ordenes : ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf("Estrictamente no nos responsabilizamos por el pago de Facturas que no esten amparadas por una Orden de Compra", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf("Calidad : ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf(" En este caso de que la calidad, cantidad o marca de los productos y/o materiales que nos envia, no estén de acuerdo a lo especificado en esta orden de compra, seran devuelto a la firma Vendedora, por su cuenta y riesgo.", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf("Despachos : ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf("El envío de los materiales solicitados en esta Orden, debe efectuarse en la fecha y lugar indicado. Nos reservamos el derecho de rechazar los materiales llegados despues de la fecha establecida como plazo de entrega.", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf("Precios : ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf("No estamos obligados a pagar un mayor precio de lo estipulado en esta Orden.", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf("Penalidad : ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf("Nos reservamos el derecho de cancelar y/o reclamar pagos de daños y perjuicios, si no cumplimos los terminos y condiciones aceptadas en esta Orden.", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf("Indicaciones : ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf("Junto con la mercaderia enviar 1 copia de la orden de compra, guia de remision, factura y certificado de calidad respectivo de lo contrario no se recepcionara la mercaderia.aceptadas en esta Orden.", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf(" ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf("FFS INDUSTRY PERU S.A.C. PODRÁ  ANULAR  LA  PRESENTE  ORDEN  DE  COMPRA  EN  CASO  DE  HABER  INCUMPLIMIENTO POR PARTE DEL PROVEEDOR EN LOS PLAZOS DE ENTREGA O INCONFORMIDADES EN EL PRODUCTO APROBADO EN LA ORDEN DE COMPRA.", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf(" ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf("FFS INDUSTRY PERU S.A.C. TRASPASARÁ  TODO  PERJUICIO  ECONÓMICO  QUE  PUDIERA  CAUSAR  EL  INCUMPLIMIENTO  POR PARTE DEL PROVEEDOR EN LOS PLAZOS DE ENTREGA O INCORFORMIDADES EN EL PRODUCTO APROBADO EN LA ORDEN DE COMPRA.", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        cell = CellPdf(" ", size, true, "c", "bold");
                        tableCON2.AddCell(cell);

                        cell = CellPdf("PENALIDADES  POR  PLAZOS  DE  ENTREGA:  1%  POR  CADA  DIA  DE  INCUMPLIMIENTO  EN  LA  ORDEN  DE  COMPRA  Y  3%  POR CADA DIA A PARTIR DEL 5TO DIA DE INCUMPLIMIENTO.", size, true, "l", "bold");
                        tableCON2.AddCell(cell);
                        tableCON2.CompleteRow();

                        docPdf.Add(tableCON2);

                        PdfPTable tableImagen2 = new PdfPTable(1);

                        tableImagen2.WidthPercentage = 70;
                        tableImagen2.SetWidths(new float[] { 3f });
                        tableImagen2.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = new PdfPCell();
                        cell = ReaderHelper.ImagenCell(RutaImagen2, 110, Element.ALIGN_CENTER, Variables.NO, 1);
                        tableImagen2.AddCell(cell);
                        tableImagen2.CompleteRow();
                        docPdf.Add(tableImagen2);
                    }

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                    fsNuevoArchivo.Close();
                }

                #endregion

                #region Empresa IRUDIAK

                if (NomEmpresa == "IRUDIAK")
                {

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20512340220")
                    {
                        PdfPTable table = new PdfPTable(3);

                        table.WidthPercentage = 70;
                        table.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
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
                        cell = ReaderHelper.ImagenCell(RutaImagen, 80, Element.ALIGN_CENTER, Variables.NO, 1);
                        cell.Rowspan = 2;
                        table.AddCell(cell);

                        cell = CellPdf(" ", 13, false, "c", "bold");
                        table.AddCell(cell);

                        table.AddCell(ReaderHelper.NuevaCelda("ORDEN DE COMPRA", null, "N", null, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD), 5, -1, "N", "N",0,6));
                        table.CompleteRow();


                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.AddCell(ReaderHelper.NuevaCelda(oOrdenCompra.numOrdenCompra,null, "N", null, FontFactory.GetFont("Arial", 8), 5,-1,"N","N",6,0));
                        table.CompleteRow();


                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        table.CompleteRow();


                        cell = CellPdf(VariablesLocales.SesionUsuario.Empresa.RazonSocial, size, false, "", "bold");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        cell = CellPdf("Fecha OC: " + oOrdenCompra.fecEmision.ToString("d"), size - 1, false, "", "bold");
                        table.AddCell(cell);
                        table.CompleteRow();

                    

                        cell = CellPdf("RUC : " + VariablesLocales.SesionUsuario.Empresa.RUC, size, false, "", "bold");
                        cell.Colspan = 2;
                        table.AddCell(cell);
                        cell = CellPdf("Telefonos :" + VariablesLocales.SesionUsuario.Empresa.sTelefonos, size - 1, false, "", "bold");
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

                        cell = CellPdf("Observacion", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(":", size, false, "", "bold");
                        tableDatos.AddCell(cell);
                        cell = CellPdf(oOrdenCompra.Observacion, size, false, "", "");
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

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf(" Precio Unit. S/", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf(" Precio Unit. US $", size, true, "c", "");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf(" Precio Unit. €", size, true, "c", "");
                        }

                        tableDetalle.AddCell(cell);
                        cell = CellPdf("Desc     (%)", size, true, "c", "");
                        tableDetalle.AddCell(cell);

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("Importe Total     S/", size, true, "c", "");
                        }
                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("Importe Total     US $", size, true, "c", "");
                        }
                        if (oOrdenCompra.desMoneda == "Euros")
                        {
                            cell = CellPdf("Importe Total  €", size, true, "c", "");
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

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("S/", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("US $", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
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

                        if (oOrdenCompra.desMoneda == "Sol Peruano")
                        {
                            cell = CellPdf("I.S.C.  S/", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Dólares Americanos")
                        {
                            cell = CellPdf("I.S.C.  US $", size, false, "r", "bold");
                        }

                        if (oOrdenCompra.desMoneda == "Euros")
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

                        cell = CellPdf("Son : " + Impresion.Mercantil.Impresion.enLetras(oOrdenCompra.impTotal.ToString()) + " " + oOrdenCompra.desMoneda, size, false, "c", "bold");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        tableFinal.AddCell(cell);
                        tableFinal.CompleteRow();

                        docPdf.Add(tableFinal);


                        PdfPTable TableObservaciones = new PdfPTable(1);

                        TableObservaciones.WidthPercentage = 70;
                        TableObservaciones.SetWidths(new float[] { 1f });
                        TableObservaciones.HorizontalAlignment = Element.ALIGN_CENTER;


                        cell = CellPdf("Observaciones", size, false, "l", "bold");
                        TableObservaciones.AddCell(cell);
                        TableObservaciones.CompleteRow();

                        cell = CellPdf("1.-El comprobante de pago deberá especificar el Nro. De La Orden de Compra, Nro de presupuestoy motivo", size, false, "l", "");
                        TableObservaciones.AddCell(cell);
                        TableObservaciones.CompleteRow();

                        cell = CellPdf("2.-La fecha de comprobante de pago debe corresponder al mes de la Orden de Compra.", size, false, "l", "");
                        TableObservaciones.AddCell(cell);
                        TableObservaciones.CompleteRow();

                        cell = CellPdf("3.-Los fatos PRECIO UNITARIO y TOTALES del comprobante de pago deberán coincidir con esta Orden de", size, false, "l", "");
                        TableObservaciones.AddCell(cell);
                        TableObservaciones.CompleteRow();

                        cell = CellPdf("compra. De haber cambios deberán solicitar una NUEVA orden de compra y la anulación de la primera.", size, false, "l", "");
                        TableObservaciones.AddCell(cell);
                        TableObservaciones.CompleteRow();

                        cell = CellPdf("4.-En el caso de RECIBO POR HONORARIOS la retención del 8% del IMPUESTO A LA RENTA DE 4TA", size, false, "l", "");
                        TableObservaciones.AddCell(cell);
                        TableObservaciones.CompleteRow();

                        cell = CellPdf("CATEGORIA see realizara cuando el monto exeda de S/1,500 soles", size, false, "l", "");
                        TableObservaciones.AddCell(cell);
                        TableObservaciones.CompleteRow();

                        cell = CellPdf("5.-Los comprobantes de pago deben tener todos los requisitos de ley y datos actualizados", size, false, "l", "");
                        TableObservaciones.AddCell(cell);
                        TableObservaciones.CompleteRow();

                        docPdf.Add(TableObservaciones);

                        PdfPTable TableFirmas = new PdfPTable(3);

                        TableFirmas.WidthPercentage = 70;
                        TableFirmas.SetWidths(new float[] { 0.2f, 0.3f, 0.5f });
                        TableFirmas.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf(" ", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        cell = CellPdf(" ", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        cell = CellPdf(" ", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        TableFirmas.CompleteRow();

                        cell = CellPdf(" ", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        cell = CellPdf(" ", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        cell = CellPdf(" ", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        TableFirmas.CompleteRow();

                        cell = CellPdf("_______________", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        cell = CellPdf("_______________", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        cell = CellPdf("_______________", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        TableFirmas.CompleteRow();

                        cell = CellPdf("Preparado", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        cell = CellPdf("Autorizado", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        cell = CellPdf("Recibido", size, false, "l", "");
                        TableFirmas.AddCell(cell);
                        TableFirmas.CompleteRow();

                        docPdf.Add(TableFirmas);

                    }

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                    fsNuevoArchivo.Close();
                }

                #endregion

                #region Empresa ASSA

                if (NomEmpresa == "ASSA")
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

                    cell = CellPdf("Doc. Ret.", size, false, "", "bold");
                    tableDatos.AddCell(cell);
                    cell = CellPdf(":", size, false, "", "bold");
                    tableDatos.AddCell(cell);
                    cell = CellPdf(oOrdenCompra.numPlazoPago.ToString() , size, false, "", "");
                    tableDatos.AddCell(cell);
                    cell = CellPdf("Solicitante ", size, false, "", "bold");
                    tableDatos.AddCell(cell);
                    cell = CellPdf(":", size, false, "", "bold");
                    tableDatos.AddCell(cell);
                    cell = CellPdf(oOrdenCompra.desResponsable.ToString() , size, false, "", "");
                    tableDatos.AddCell(cell);
                    tableDatos.CompleteRow();

                    cell = CellPdf("Moneda ", size, false, "", "bold");
                    tableDatos.AddCell(cell);
                    cell = CellPdf(":", size, false, "", "bold");
                    tableDatos.AddCell(cell);
                    cell = CellPdf(oOrdenCompra.desMoneda.ToString(), size, false, "", "");
                    tableDatos.AddCell(cell);
                    cell = CellPdf("C.Costo ", size, false, "", "bold");
                    tableDatos.AddCell(cell);
                    cell = CellPdf(":", size, false, "", "bold");
                    tableDatos.AddCell(cell);
                    cell = CellPdf(oOrdenCompra.desCCostos.ToString(), size, false, "", "");
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
                    pie3.SetWidths(new float[] { 1.00f});
                    pie3.HorizontalAlignment = Element.ALIGN_CENTER;

                    cell = CellPdf("CONSIDERACIONES PARA LA RECEPCION DE FACTURA:", size, false, "l", "bold");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf("LUGAR DE RECEPCION DE FACTURA: " + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, size, false, "l", "bold");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf("ADJUNTADO LO SIGUIENTE: " , size, false, "l", "bold");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf("1.- Orden de compra firmada por el Gerente " , size, false, "l", "");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf("2.- Si es venta: Guia de remision con nombres, firma y sello de recepcion del producto" , size, false, "l", "");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf("3.- Si es servicio: Orden de servicio u acta de conformidad con la firma y sello del responsable que solicito el servicio ", size, false, "l", "");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf("4.- Y cualquier otro documento involucrado en la operación" , size, false, "l", "");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf("5.- Horario de pago proveedores: Martes y Jueves 14:30 a 17:30 horas en Av.Arica 1301 Breña (2do Piso). Teléfono:425-0547 " , size, false, "l", "bold");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf("OBSERVACIONES: ", size, true, "l", "");
                    cell.Rowspan = 2;
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf(" " + oOrdenCompra.Observacion, size, true, "l", "");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    cell = CellPdf(" " + oOrdenCompra.RazonSocial, size, true, "l", "");
                    pie3.AddCell(cell);
                    pie3.CompleteRow();

                    docPdf.Add(pie3);

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                    fsNuevoArchivo.Close();
                }

                #endregion

            }
        }

        PdfPCell CellPdf(string titulo,int size,Boolean border,string align,string bold)
        {
            if(! border)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold=="bold"? iTextSharp.text.Font.BOLD: iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        #endregion

        #region Eventos

        private void frmOrdenDeCompraPDF_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        } 

        #endregion

    }
}
