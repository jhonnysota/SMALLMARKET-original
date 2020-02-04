using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura.Enumerados;
using Infraestructura;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmErrores : FrmMantenimientoBase
    {
        
        #region Constructores

        public frmErrores()
        {
            InitializeComponent();
        }

        public frmErrores(String TipoDeError)
            :this()
        {
            ErrorEn = TipoDeError;
        }

        #endregion

        #region Variables

        String ErrorEn = String.Empty;
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        string RutaGeneral;
        String RutaTemp = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Errores " + Aleatorio.ToString();
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

                String SubTitulo = String.Empty;
                PdfPCell cell = null;

                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    docPdf.Open();

                    #region Articulos

                    if (ErrorEn == "ARTICULOS")
                    {
                        List<ErrorImportacionE> oListaError;
                        oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ArticuloServXLS");
                        DateTime FechaActual = VariablesLocales.FechaHoy.Date;
                        int size = 8;
                        //AlmacenE Almacen = AgenteAlmacen.Proxy.ObtenerAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oOrdenCompra.idAlmacenEntrega);
                        #region Titulos Principales
                        PdfPTable tabletit = new PdfPTable(3);

                        tabletit.WidthPercentage = 100;
                        tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                        tabletit.HorizontalAlignment = Element.ALIGN_LEFT;


                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL))) { Border = 0 };
                        tabletit.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
                        tabletit.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL))) { Border = 0 };
                        tabletit.AddCell(cell);
                        tabletit.CompleteRow(); //Fila completada

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL))) { Border = 0 };
                        tabletit.AddCell(cell);
                        cell = new PdfPCell(new Paragraph("Errores de Importación de Articulos", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
                        tabletit.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL))) { Border = 0 };
                        tabletit.AddCell(cell);
                        tabletit.CompleteRow();
                        docPdf.Add(tabletit);
                        #endregion

                        PdfPTable table = new PdfPTable(4);

                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 0.05f, 0.4f, 0.2f, 0.4f });
                        table.HorizontalAlignment = Element.ALIGN_CENTER;

                        // ===========================================

                        cell = CellPdf("Linea", size, true, "", "bold");
                        table.AddCell(cell);
                        cell = CellPdf("Nombre Campo", size, true, "", "bold");
                        table.AddCell(cell);
                        cell = CellPdf("Valor Campo", size, true, "", "bold");
                        table.AddCell(cell);
                        cell = CellPdf("Mensaje", size, true, "", "bold");
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
                        table.CompleteRow();



                        // ==============================
                        // SUB TITULO
                        // ==============================

                        foreach (ErrorImportacionE item in oListaError)
                        {
                            cell = CellPdf(item.Linea.ToString(), size, false, "", "");
                            table.AddCell(cell);
                            cell = CellPdf(item.NombreCampo, size, false, "", "");
                            table.AddCell(cell);
                            cell = CellPdf(item.ValorCampo, size, false, "", "");
                            table.AddCell(cell);
                            cell = CellPdf(item.Mensaje, size, false, "", "");
                            table.AddCell(cell);
                            table.CompleteRow();


                        }
                        docPdf.Add(table);
                    }

                    #endregion

                    #region Voucher JOSE SALAZAR

                    if (ErrorEn == "VOUCHER")
                    {
                        List<ErrorImportacionE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "VoucherXLS");

                        #region Titulos Principales

                        PdfPTable tabletit = new PdfPTable(3);

                        tabletit.WidthPercentage = 100;
                        tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                        tabletit.HorizontalAlignment = Element.ALIGN_LEFT;

                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        tabletit.AddCell(ReaderHelper.NuevaCelda("Errores de Importación de Voucher", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        docPdf.Add(tabletit);

                        #endregion

                        #region Detalle

                        if (oListaError.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(4);

                            table.WidthPercentage = 100;
                            table.SetWidths(new float[] { 0.1f, 0.2f, 0.2f, 0.5f });
                            table.HorizontalAlignment = Element.ALIGN_CENTER;

                            table.AddCell(ReaderHelper.NuevaCelda("Linea Excel", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Nombre Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Valor Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Mensaje", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S"));
                            table.CompleteRow();

                            foreach (ErrorImportacionE item in oListaError)
                            {
                                table.AddCell(ReaderHelper.NuevaCelda(item.Linea.ToString(), null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.NombreCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.ValorCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.Mensaje, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.CompleteRow();
                            }

                            docPdf.Add(table);
                        }

                        #endregion
                    }

                    #endregion

                    #region Ventas JOSE SALAZAR

                    if (ErrorEn == "VENTASDET")
                    {
                        List<ErrorImportGeneralE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportGeneral(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                VariablesLocales.SesionLocal.IdLocal,
                                                                                                                Convert.ToInt32(VariablesLocales.SesionUsuario.IdPersona),
                                                                                                                "VentasDetXLS");
                        #region Titulos Principales

                        PdfPTable tabletit = new PdfPTable(3);

                        tabletit.WidthPercentage = 100;
                        tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                        tabletit.HorizontalAlignment = Element.ALIGN_LEFT;

                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        tabletit.AddCell(ReaderHelper.NuevaCelda("Errores de la Importación de Ventas Detallada", null, "S", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S3", "N", 5, 2, "S", "S", "S", "S", 1));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        docPdf.Add(tabletit);

                        #endregion

                        #region Detalle

                        if (oListaError.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(4);

                            table.WidthPercentage = 100;
                            table.SetWidths(new float[] { 0.1f, 0.2f, 0.2f, 0.5f });
                            table.HorizontalAlignment = Element.ALIGN_CENTER;

                            table.AddCell(ReaderHelper.NuevaCelda("Linea Excel", BaseColor.BLACK, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S", 1));
                            table.AddCell(ReaderHelper.NuevaCelda("Nombre Campo", BaseColor.BLACK, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S", 1));
                            table.AddCell(ReaderHelper.NuevaCelda("Valor Campo", BaseColor.BLACK, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S", 1));
                            table.AddCell(ReaderHelper.NuevaCelda("Mensaje", BaseColor.BLACK, "S", BaseColor.WHITE, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S", 1));
                            table.CompleteRow();

                            foreach (ErrorImportGeneralE item in oListaError)
                            {
                                table.AddCell(ReaderHelper.NuevaCelda(item.Linea.ToString(), null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.NombreCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.ValorCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.Mensaje, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.CompleteRow();
                            }

                            docPdf.Add(table);
                        }

                        #endregion
                    }

                    #endregion

                    #region Clientes JOSE SALAZAR

                    if (ErrorEn == "CLIENTE")
                    {
                        List<ErrorImportacionE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ClienteXLS");

                        #region Titulos Principales

                        PdfPTable tabletit = new PdfPTable(3);

                        tabletit.WidthPercentage = 100;
                        tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                        tabletit.HorizontalAlignment = Element.ALIGN_LEFT;

                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        tabletit.AddCell(ReaderHelper.NuevaCelda("Errores de Importación de Cliente", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        docPdf.Add(tabletit);

                        #endregion

                        #region Detalle

                        if (oListaError.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(4);

                            table.WidthPercentage = 100;
                            table.SetWidths(new float[] { 0.1f, 0.2f, 0.2f, 0.5f });
                            table.HorizontalAlignment = Element.ALIGN_CENTER;

                            table.AddCell(ReaderHelper.NuevaCelda("Linea Excel", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Nombre Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Valor Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Mensaje", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S"));
                            table.CompleteRow();

                            foreach (ErrorImportacionE item in oListaError)
                            {
                                table.AddCell(ReaderHelper.NuevaCelda(item.Linea.ToString(), null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.NombreCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.ValorCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.Mensaje, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.CompleteRow();
                            }

                            docPdf.Add(table);
                        }

                        #endregion
                    }

                    #endregion

                    #region PlanContable JOSE SALAZAR

                    if (ErrorEn == "PLANCONTABLE")
                    {
                        List<ErrorImportacionE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "PlanContableXLS");

                        #region Titulos Principales

                        PdfPTable tabletit = new PdfPTable(3);

                        tabletit.WidthPercentage = 100;
                        tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                        tabletit.HorizontalAlignment = Element.ALIGN_LEFT;

                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        tabletit.AddCell(ReaderHelper.NuevaCelda("Errores de Importación de Cliente", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        docPdf.Add(tabletit);

                        #endregion

                        #region Detalle

                        if (oListaError.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(4);

                            table.WidthPercentage = 100;
                            table.SetWidths(new float[] { 0.1f, 0.2f, 0.2f, 0.5f });
                            table.HorizontalAlignment = Element.ALIGN_CENTER;

                            table.AddCell(ReaderHelper.NuevaCelda("Linea Excel", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Nombre Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Valor Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Mensaje", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S"));
                            table.CompleteRow();

                            foreach (ErrorImportacionE item in oListaError)
                            {
                                table.AddCell(ReaderHelper.NuevaCelda(item.Linea.ToString(), null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.NombreCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.ValorCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.Mensaje, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.CompleteRow();
                            }

                            docPdf.Add(table);
                        }

                        #endregion
                    }

                    #endregion

                    #region Presupuesto De Venta JOSE SALAZAR

                    if (ErrorEn == "PRESUPUESTO")
                    {
                        List<ErrorImportacionE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "PresupuestoXLS");

                        #region Titulos Principales

                        PdfPTable tabletit = new PdfPTable(3);

                        tabletit.WidthPercentage = 100;
                        tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                        tabletit.HorizontalAlignment = Element.ALIGN_LEFT;

                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        tabletit.AddCell(ReaderHelper.NuevaCelda("Errores de Importación de Cliente", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        docPdf.Add(tabletit);

                        #endregion

                        #region Detalle

                        if (oListaError.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(4);

                            table.WidthPercentage = 100;
                            table.SetWidths(new float[] { 0.1f, 0.2f, 0.2f, 0.5f });
                            table.HorizontalAlignment = Element.ALIGN_CENTER;

                            table.AddCell(ReaderHelper.NuevaCelda("Linea Excel", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Nombre Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Valor Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Mensaje", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S"));
                            table.CompleteRow();

                            foreach (ErrorImportacionE item in oListaError)
                            {
                                table.AddCell(ReaderHelper.NuevaCelda(item.Linea.ToString(), null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.NombreCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.ValorCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.Mensaje, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.CompleteRow();
                            }

                            docPdf.Add(table);
                        }

                        #endregion
                    }

                    #endregion

                    #region Balance JOSE SALAZAR

                    if (ErrorEn == "Balance")
                    {
                        List<ErrorImportGeneralE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportGeneral(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, VariablesLocales.SesionUsuario.IdPersona, "BalanceXLS");

                        #region Titulos Principales

                        PdfPTable tabletit = new PdfPTable(3)
                        {
                            WidthPercentage = 100
                        };

                        tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                        tabletit.HorizontalAlignment = Element.ALIGN_LEFT;

                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        tabletit.AddCell(ReaderHelper.NuevaCelda("Errores de Importación del Balance", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        docPdf.Add(tabletit);

                        #endregion

                        #region Detalle

                        if (oListaError.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(4)
                            {
                                WidthPercentage = 100
                            };

                            table.SetWidths(new float[] { 0.1f, 0.2f, 0.2f, 0.5f });
                            table.HorizontalAlignment = Element.ALIGN_CENTER;

                            table.AddCell(ReaderHelper.NuevaCelda("Linea Excel", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Nombre Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Valor Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Mensaje", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S"));
                            table.CompleteRow();

                            foreach (ErrorImportGeneralE item in oListaError)
                            {
                                table.AddCell(ReaderHelper.NuevaCelda(item.Linea.ToString(), null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.NombreCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.ValorCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.Mensaje, null, "N", null, FontFactory.GetFont("Arial", 8f)));

                                table.CompleteRow();
                            }

                            docPdf.Add(table);
                        }

                        #endregion
                    }

                    #endregion

                    #region Movimiento de Almacen - JOSE SALAZAR

                    if (ErrorEn == "MovXLS")
                    {
                        List<ErrorImportGeneralE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportGeneral(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, VariablesLocales.SesionUsuario.IdPersona, "MovimientosXLS");

                        #region Titulos Principales

                        PdfPTable tabletit = new PdfPTable(3)
                        {
                            WidthPercentage = 100
                        };

                        tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                        tabletit.HorizontalAlignment = Element.ALIGN_LEFT;

                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        tabletit.AddCell(ReaderHelper.NuevaCelda("Errores de Importación del Kardéx", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada
                        tabletit.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1, "S3"));
                        tabletit.CompleteRow(); //Fila completada

                        docPdf.Add(tabletit);

                        #endregion

                        #region Detalle

                        if (oListaError.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(4)
                            {
                                WidthPercentage = 100
                            };

                            table.SetWidths(new float[] { 0.1f, 0.2f, 0.2f, 0.5f });
                            table.HorizontalAlignment = Element.ALIGN_CENTER;

                            table.AddCell(ReaderHelper.NuevaCelda("Linea Excel", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Nombre Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Valor Campo", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "N"));
                            table.AddCell(ReaderHelper.NuevaCelda("Mensaje", BaseColor.BLACK, "S", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5, 3, "S", "S", "S", "S"));
                            table.CompleteRow();

                            foreach (ErrorImportGeneralE item in oListaError)
                            {
                                table.AddCell(ReaderHelper.NuevaCelda(item.Linea.ToString(), null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.NombreCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.ValorCampo, null, "N", null, FontFactory.GetFont("Arial", 8f)));
                                table.AddCell(ReaderHelper.NuevaCelda(item.Mensaje, null, "N", null, FontFactory.GetFont("Arial", 8f)));

                                table.CompleteRow();
                            }

                            docPdf.Add(table);
                        }

                        #endregion
                    }

                    #endregion

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close(); 
                }
                
                wbNavegador.Navigate(RutaGeneral);
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Errores De Importacion ";
            NombrePestaña = "Errores De Voucher";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    if (ErrorEn == "VOUCHER")
                    {

                        #region Voucher

                        Int32 InicioLinea = 4;
                        Int32 TotColumnas = 4;

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
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 214, 42));
                        }

                        oHoja.Cells["A2"].Value = "Errores De Importacion De Voucher";

                        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(3, 253, 9));
                        }

                        #endregion 

                        #region Cabeceras del Detalle

                        // PRIMERA
                        oHoja.Cells[InicioLinea, 1].Value = " Linea ";
                        oHoja.Column(1).Width = 25;
                        oHoja.Cells[InicioLinea, 2].Value = " Nombre Campo ";
                        oHoja.Column(2).Width = 23;
                        oHoja.Cells[InicioLinea, 3].Value = " Valor Campo ";
                        oHoja.Column(3).Width = 22;
                        oHoja.Cells[InicioLinea, 4].Value = " Mensaje ";
                        oHoja.Column(4).Width = 35;

                        for (int i = 1; i <= 4; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;

                        #endregion

                        #region Detalle
                        List<ErrorImportacionE> oListaError;
                        oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "VoucherXLS");
                        foreach (ErrorImportacionE item in oListaError)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.Linea;
                            oHoja.Column(1).Width = 25;
                            oHoja.Cells[InicioLinea, 2].Value = item.NombreCampo;
                            oHoja.Column(2).Width = 23;
                            oHoja.Cells[InicioLinea, 3].Value = item.ValorCampo;
                            oHoja.Column(3).Width = 22;
                            oHoja.Cells[InicioLinea, 4].Value = item.Mensaje;
                            oHoja.Column(4).Width = 35;


                            InicioLinea++;
                        }

                        #endregion 

                        #region Otros

                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                        InicioLinea++;

                        //Linea
                        Int32 totFilas = InicioLinea;
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                        //Suma
                        InicioLinea++;
                        #endregion

                        #endregion

                    }


                    if (ErrorEn == "ARTICULOS")
                    {

                        #region Articulos

                        Int32 InicioLinea = 4;
                        Int32 TotColumnas = 4;

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
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 214, 42));
                        }

                        oHoja.Cells["A2"].Value = "Errores De Importacion De Articulos";

                        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(3, 253, 9));
                        }

                        #endregion Principales

                        #region Cabeceras del Detalle

                        // PRIMERA
                        oHoja.Cells[InicioLinea, 1].Value = " Linea ";
                        oHoja.Column(1).Width = 25;
                        oHoja.Cells[InicioLinea, 2].Value = " Nombre Campo ";
                        oHoja.Column(2).Width = 23;
                        oHoja.Cells[InicioLinea, 3].Value = " Valor Campo ";
                        oHoja.Column(3).Width = 22;
                        oHoja.Cells[InicioLinea, 4].Value = " Mensaje ";
                        oHoja.Column(4).Width = 35;

                        for (int i = 1; i <= 4; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;

                        #endregion

                        #region Detalle
                        List<ErrorImportacionE> oListaError;
                        oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ArticuloServXLS");
                        foreach (ErrorImportacionE item in oListaError)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.Linea;
                            oHoja.Column(1).Width = 25;
                            oHoja.Cells[InicioLinea, 2].Value = item.NombreCampo;
                            oHoja.Column(2).Width = 23;
                            oHoja.Cells[InicioLinea, 3].Value = item.ValorCampo;
                            oHoja.Column(3).Width = 22;
                            oHoja.Cells[InicioLinea, 4].Value = item.Mensaje;
                            oHoja.Column(4).Width = 35;


                            InicioLinea++;
                        }

                        #endregion Detalle

                        #region Otros

                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                        InicioLinea++;

                        //Linea
                        Int32 totFilas = InicioLinea;
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                        //Suma
                        InicioLinea++;
                        #endregion

                        #endregion

                    }

                    if (ErrorEn == "PLANCONTABLE")
                    {

                        #region PlanContable

                        Int32 InicioLinea = 4;
                        Int32 TotColumnas = 4;

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
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 214, 42));
                        }

                        oHoja.Cells["A2"].Value = "Errores De Importacion De Plan Contable";

                        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(3, 253, 9));
                        }

                        #endregion 

                        #region Cabeceras del Detalle

                        // PRIMERA
                        oHoja.Cells[InicioLinea, 1].Value = " Linea ";
                        oHoja.Column(1).Width = 25;
                        oHoja.Cells[InicioLinea, 2].Value = " Nombre Campo ";
                        oHoja.Column(2).Width = 23;
                        oHoja.Cells[InicioLinea, 3].Value = " Valor Campo ";
                        oHoja.Column(3).Width = 22;
                        oHoja.Cells[InicioLinea, 4].Value = " Mensaje ";
                        oHoja.Column(4).Width = 35;

                        for (int i = 1; i <= 4; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;

                        #endregion

                        #region Detalle
                        List<ErrorImportacionE> oListaError;
                        oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "VoucherXLS");
                        foreach (ErrorImportacionE item in oListaError)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.Linea;
                            oHoja.Column(1).Width = 25;
                            oHoja.Cells[InicioLinea, 2].Value = item.NombreCampo;
                            oHoja.Column(2).Width = 23;
                            oHoja.Cells[InicioLinea, 3].Value = item.ValorCampo;
                            oHoja.Column(3).Width = 22;
                            oHoja.Cells[InicioLinea, 4].Value = item.Mensaje;
                            oHoja.Column(4).Width = 35;


                            InicioLinea++;
                        }

                        #endregion 

                        #region Otros

                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                        InicioLinea++;

                        //Linea
                        Int32 totFilas = InicioLinea;
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                        //Suma
                        InicioLinea++;
                        #endregion

                        #endregion

                    }

                    if (ErrorEn == "CLIENTE")
                    {
                        #region PlanContable

                        Int32 InicioLinea = 4;
                        Int32 TotColumnas = 4;

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
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 214, 42));
                        }

                        oHoja.Cells["A2"].Value = "Errores De Importacion De Plan Cliente";

                        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(3, 253, 9));
                        }

                        #endregion 

                        #region Cabeceras del Detalle

                        // PRIMERA
                        oHoja.Cells[InicioLinea, 1].Value = " Linea ";
                        oHoja.Column(1).Width = 25;
                        oHoja.Cells[InicioLinea, 2].Value = " Nombre Campo ";
                        oHoja.Column(2).Width = 23;
                        oHoja.Cells[InicioLinea, 3].Value = " Valor Campo ";
                        oHoja.Column(3).Width = 22;
                        oHoja.Cells[InicioLinea, 4].Value = " Mensaje ";
                        oHoja.Column(4).Width = 35;

                        for (int i = 1; i <= 4; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;

                        #endregion

                        #region Detalle
                        List<ErrorImportacionE> oListaError;
                        oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "VoucherXLS");
                        foreach (ErrorImportacionE item in oListaError)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.Linea;
                            oHoja.Column(1).Width = 25;
                            oHoja.Cells[InicioLinea, 2].Value = item.NombreCampo;
                            oHoja.Column(2).Width = 23;
                            oHoja.Cells[InicioLinea, 3].Value = item.ValorCampo;
                            oHoja.Column(3).Width = 22;
                            oHoja.Cells[InicioLinea, 4].Value = item.Mensaje;
                            oHoja.Column(4).Width = 35;


                            InicioLinea++;
                        }

                        #endregion 

                        #region Otros

                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                        InicioLinea++;

                        //Linea
                        Int32 totFilas = InicioLinea;
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                        //Suma
                        InicioLinea++;
                        #endregion

                        #endregion

                    }

                    //Ajustando el ancho de las columnas automaticamente
                    //oHoja.Cells.AutoFitColumns(0);

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
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                    //Guardando el excel
                    oExcel.Save();
                }
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

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                String RutaExcel = String.Empty;

                if (ErrorEn == "VOUCHER")
                {
                    List<ErrorImportacionE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "VoucherXLS");

                    if (oListaError == null || oListaError.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }

                    RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", "Errores De Importacion de Voucher", "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (ErrorEn == "ARTICULOS")
                {
                    List<ErrorImportacionE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ArticuloServXLS");

                    if (oListaError == null || oListaError.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }

                    RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", "Errores De Importacion de Articulos", "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (ErrorEn == "PLANCONTABLE")
                {
                    List<ErrorImportacionE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "PlanContableXLS");

                    if (oListaError == null || oListaError.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }

                    RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", "Errores De Importacion de Articulos", "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (ErrorEn == "CLIENTE")
                {
                    List<ErrorImportacionE> oListaError = oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ClienteXLS");

                    if (oListaError == null || oListaError.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }

                    RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", "Errores De Importacion de Articulos", "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (ErrorEn == "PRESUPUESTO")
                {
                    List<ErrorImportacionE> oListaError = AgenteContabilidad.Proxy.ListarErrorImportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "PresupuestoXLS");

                    if (oListaError == null || oListaError.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }

                    RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", "Errores De Importacion de Articulos", "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (!String.IsNullOrWhiteSpace(RutaExcel))
                {
                    ExportarExcel(RutaExcel); 
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmErrores_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            if (ErrorEn != "VENTASDET")
            {
                BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            }

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            ConvertirApdf();
        } 

        #endregion

    }

}


