using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

#region Del Proyecto

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#endregion

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmImpresionVoucher : FrmMantenimientoBase
    {

        #region Constructores
        
        public frmImpresionVoucher()
        {
            InitializeComponent();
            Global.AjustarResolucion(this);

            //Location = new Point(0, 0);
            //Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        public frmImpresionVoucher(String Tipo, List<VoucherE> OV)
            : this()
        {
            oListatVoucherCabezal = OV;
            foreach (VoucherE oVI in OV)
            {
                if (Tipo == "N")
                {
                    oListaVoucherDetalle =  oVI.ListaVouchers = AgenteContabilidad.Proxy.VoucherDetalle(oVI.idEmpresa, oVI.idLocal, oVI.AnioPeriodo, oVI.MesPeriodo, oVI.numVoucher, oVI.idComprobante, oVI.numFile);
                }
                else
                {
                    oListaVoucherDetalle =  oVI.ListaVouchers = AgenteContabilidad.Proxy.VoucherDetalleEgreso(oVI.idEmpresa, oVI.idLocal, oVI.AnioPeriodo, oVI.MesPeriodo, oVI.numVoucher, oVI.idComprobante, oVI.numFile);
                }
            }


            if (oListatVoucherCabezal.Count == Variables.Cero)
            {
                Global.MensajeComunicacion("No hay datos para la impresión.");
            }
            else
            {
                ConvertirApdf(Tipo);
            }
        }


        public frmImpresionVoucher(String Tipo, VoucherE oVI)
            : this()
        {
            if (Tipo == "N")
            {
                oListaVoucherDetalle = AgenteContabilidad.Proxy.VoucherDetalle(oVI.idEmpresa, oVI.idLocal, oVI.AnioPeriodo, oVI.MesPeriodo, oVI.numVoucher, oVI.idComprobante, oVI.numFile);
            }
            else
            {
                oListaVoucherDetalle = AgenteContabilidad.Proxy.VoucherDetalleEgreso(oVI.idEmpresa, oVI.idLocal, oVI.AnioPeriodo, oVI.MesPeriodo, oVI.numVoucher, oVI.idComprobante, oVI.numFile);
            }


            if (oListaVoucherDetalle.Count == Variables.Cero)
            {
                Global.MensajeComunicacion("No hay datos para la impresión.");
            }
            else
            {
                ConvertirApdf(Tipo);
            }
        }

        public frmImpresionVoucher(String Tipo, List<VoucherItemE> oListaVoucherDetalle_,String TipoForm_, ProgramaPagoE oProgramaTmp_)
         : this()
        {
            
            oListaVoucherDetalle = oListaVoucherDetalle_;
            oPrograma = oProgramaTmp_;
            TipoForm = TipoForm_;

            if (oListaVoucherDetalle.Count == Variables.Cero)
            {
                Global.MensajeComunicacion("No hay datos para la impresión.");
            }
            else
            {
                ConvertirApdf(Tipo);
            }
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<VoucherItemE> oListaVoucherDetalle = new List<VoucherItemE>();
        List<VoucherE> oListatVoucherCabezal = new List<VoucherE>();
        ProgramaPagoE oPrograma = new ProgramaPagoE();
        String RutaTemp = String.Empty;
        String TipoForm = String.Empty;
        #endregion

        #region Procedimientos de Usuario

        PlanCuentasE ObtenerPlanCuenta(String Cuenta)
        {
            PlanCuentasE Plan = new PlanCuentasE();
            Plan = AgenteContabilidad.Proxy.ObtenerPlanCuentasPorCodigo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, Cuenta);

            return Plan;
        }

        void ConvertirApdf(String Tipo)
        {
            try
            {
                if (Tipo == "N")
                {
                    #region Voucher Normal

                    Document docPdf = new Document(PageSize.A4, 5f, 5f, 10f, 10f);
                    Guid Aleatorio = Guid.NewGuid();
                    String NombreReporte = @"\VoucherTmp " + Aleatorio.ToString();
                    String Extension = ".pdf";
                    BaseColor ColorFondo = new BaseColor(208, 206, 206); //Gris Claro
                    RutaTemp = @"C:\AmazonErp\ArchivosTemporales";

                    //TAMANÑO DE LETRA - DETALLE para los dos formatos
                    float SizeLetra = 7.5f;

                    if (!Directory.Exists(RutaTemp))
                    {
                        Directory.CreateDirectory(RutaTemp);
                    }

                    docPdf.AddCreationDate();
                    docPdf.AddAuthor("AMAZONTIC SAC");
                    docPdf.AddCreator("AMAZONTIC SAC");

                    if (!String.IsNullOrEmpty(RutaTemp.Trim()))
                    {
                        PdfPCell cell = null;
                        Phrase phrase = null;

                        //Creacion del archivo pdf
                        RutaTemp += NombreReporte + Extension;

                        if (File.Exists(RutaTemp))
                        {
                            if (docPdf.IsOpen())
                            {
                                docPdf.Close();
                            }

                            File.Delete(RutaTemp);
                        }

                        FileStream NuevoArchivo = new FileStream(RutaTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, NuevoArchivo);

                        oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                        oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                        oPdfw.ViewerPreferences = PdfWriter.HideMenubar;
                        //oPdfw.ViewerPreferences = PdfWriter.HideWindowUI;

                        //Esto crea un nuevo destino para enviar la acción cuando se abra el documento. 
                        //Se usa doc.PageSize.Height para establecer la coordenada en la parte superior de la página. 
                        //PdfDestination.XYZ es un tipo PdfDestination específica que nos permite establecer la ubicación y el zoom(100%).
                        PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                        //Abre el documento
                        docPdf.Open();

                        #region Titulos

                        if (oListatVoucherCabezal.Count > 1)
                        {
                            foreach (VoucherE item1 in oListatVoucherCabezal)
                            {

                                //Cabecera del Reporte
                                PdfPTable TablaTitulos = new PdfPTable(3);
                                TablaTitulos.WidthPercentage = 100;

                                //Para el lado Izquierdo
                                phrase = new Phrase();
                                phrase.Add(new Chunk(VariablesLocales.SesionUsuario.Empresa.RazonSocial + "\n", FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                                phrase.Add(new Chunk(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta + "\n", FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                                phrase.Add(new Chunk("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC + "\n", FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                                cell = new PdfPCell(phrase) { Border = 0 };
                                //Añadiendo la celda a la tabla
                                TablaTitulos.AddCell(cell);

                                //En medio
                                phrase = new Phrase();
                                phrase.Add(new Chunk("LIBRO " + item1.idComprobante + " " + item1.descomprobante + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                                phrase.Add(new Chunk("FILE " + item1.numFile + " " + item1.desFile + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                                phrase.Add(new Chunk("Del año: " + item1.AnioPeriodo + "-Periodo " + item1.MesPeriodo + "-Voucher " + item1.numVoucher + "\n", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                                //Formateando la celda...
                                cell = new PdfPCell(phrase) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
                                //Añadiendo la celda a la tabla
                                TablaTitulos.AddCell(cell);

                                //Para el lado derecho
                                phrase = new Phrase();
                                phrase.Add(new Chunk("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                                phrase.Add(new Chunk("Hora: " + DateTime.Now.ToString("hh:mm:ss") + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                                phrase.Add(new Chunk("Pag. " + oPdfw.PageNumber + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                                cell = new PdfPCell(phrase) { Border = 0 };
                                //Formateando la celda
                                cell.PaddingLeft = 85f;
                                //Añadiendo la celda a la tabla
                                TablaTitulos.AddCell(cell);

                                TablaTitulos.CompleteRow();

                                #endregion

                                #region SubTitulos

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 3.25f))) { Border = 0 };
                                cell.Colspan = 3;
                                TablaTitulos.AddCell(cell);
                                TablaTitulos.CompleteRow();

                                phrase = new Phrase();
                                phrase.Add(new Chunk("Moneda:       ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                                phrase.Add(new Chunk(item1.desMoneda, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                                cell = new PdfPCell(phrase) { Border = 0 };
                                cell.Colspan = 3;
                                TablaTitulos.AddCell(cell);
                                TablaTitulos.CompleteRow();

                                phrase = new Phrase();
                                phrase.Add(new Chunk("Fecha Doc:  ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                                phrase.Add(new Chunk(Convert.ToDateTime(item1.fecOperacion).ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                phrase.Add(new Chunk("   Glosa:  ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                                phrase.Add(new Chunk(item1.GlosaGeneral, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                cell = new PdfPCell(phrase) { Border = 0 };
                                cell.Colspan = 3;
                                TablaTitulos.AddCell(cell);
                                TablaTitulos.CompleteRow();

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 3.25f))) { Border = 0 };
                                cell.Colspan = 3;
                                TablaTitulos.AddCell(cell);
                                TablaTitulos.CompleteRow();

                                docPdf.Add(TablaTitulos);

                                #endregion

                                #region Para el Detalle

                                #region Cabecera del Detalle

                                PdfPTable TablaDetalle = new PdfPTable(13);
                                TablaDetalle.WidthPercentage = 100;
                                TablaDetalle.SetWidths(new float[] { 0.055f, 0.095f, 0.35f, 0.017f, 0.4f, 0.065f, 0.2f, 0.121f, 0.08f, 0.15f, 0.15f, 0.15f, 0.15f });

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("IT", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "S"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("COD.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("CUENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("R", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("AUXILIAR", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("C.C.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DOCUMENTO", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("FEC. EMIS.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("SOLES S/.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "S2", "N", 2, 2, "S", "N", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DOLARES US$", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "S2", "N", 2, 2, "S", "N", "S", "N"));

                                TablaDetalle.CompleteRow();

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DEBE", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 1, 1, "N", "N", 2, 2, "N", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("HABER", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 1, 1, "N", "N", 2, 2, "N", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DEBE", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 1, 1, "N", "N", 2, 2, "N", "S", "N", "N"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("HABER", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 1, 1, "N", "N", 2, 2, "N", "S", "S", "N"));

                                TablaDetalle.CompleteRow();

                                #endregion

                                #region Detalle

                                String fecVencimiento = String.Empty;
                                String fecDocumento = String.Empty;
                                String numDocumento = String.Empty;
                                Decimal DebeSoles = Variables.Cero;
                                Decimal DebeDolares = Variables.Cero;
                                Decimal HaberSoles = Variables.Cero;
                                Decimal HaberDolares = Variables.Cero;

                                foreach (VoucherItemE item in item1.ListaVouchers)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.numItem.Substring(2, 3), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.codCuenta, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta.Substring(0, (item.desCuenta.Length >= 22 ? 22 : item.desCuenta.Length)), null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.indReparable, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial.Substring(0, (item.RazonSocial.Length >= 22 ? 22 : item.RazonSocial.Length)), null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.idCCostos, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));

                                    if (!String.IsNullOrEmpty(item.idDocumento))
                                    {
                                        numDocumento = item.idDocumento + " ";
                                    }

                                    if (!String.IsNullOrEmpty(item.serDocumento))
                                    {
                                        if (item.serDocumento != "0000")
                                            numDocumento += item.serDocumento + "-";
                                    }

                                    if (!String.IsNullOrEmpty(item.numDocumento))
                                    {
                                        numDocumento += item.numDocumento;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(numDocumento, null, "N", null, FontFactory.GetFont("Arial", 6.25f)));

                                    if (item.fecDocumento != null)
                                    {
                                        fecDocumento = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                                    }
                                    else
                                    {
                                        fecDocumento = String.Empty;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(fecDocumento, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));

                                    if (item.indDebeHaber == Variables.Haber)
                                    {
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));

                                        HaberSoles += item.impSoles;
                                        HaberDolares += item.impDolares;
                                    }
                                    else
                                    {
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));

                                        DebeSoles += item.impSoles;
                                        DebeDolares += item.impDolares;
                                    }

                                    TablaDetalle.CompleteRow();
                                    numDocumento = String.Empty;
                                }

                                #endregion

                                #region Totales

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(DebeSoles.ToString("N2"), FontFactory.GetFont("Arial", 6.25f))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(HaberSoles.ToString("N2"), FontFactory.GetFont("Arial", 6.25f))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(DebeDolares.ToString("N2"), FontFactory.GetFont("Arial", 6.25f))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(HaberDolares.ToString("N2"), FontFactory.GetFont("Arial", 6.25f))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaDetalle.AddCell(cell);

                                TablaDetalle.CompleteRow();

                                #endregion

                                #region Espacios en Blanco

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                                cell.Colspan = 13;
                                TablaDetalle.AddCell(cell);
                                TablaDetalle.CompleteRow();

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                                cell.Colspan = 13;
                                TablaDetalle.AddCell(cell);
                                TablaDetalle.CompleteRow();

                                //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                                //cell.Colspan = 12;
                                //TablaDetalle.AddCell(cell);
                                //TablaDetalle.CompleteRow();

                                //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                                //cell.Colspan = 12;
                                //TablaDetalle.AddCell(cell);
                                //TablaDetalle.CompleteRow();

                                #endregion

                                Int32 LenUsuario = item1.UsuarioRegistro.Length;
                                String Elaborado = "ELABORADO POR: " + item1.UsuarioRegistro;
                                String FechaHora = "FECHA Y HORA: " + Convert.ToDateTime(item1.FechaModificacion).ToString("dd/MM/yyyy hh:mm:ss");
                                String Rayitas = "--------------------------------------------------";
                                String Recibi = " RECIBI CONFORME \n";

                                phrase = new Phrase();
                                phrase.Add(new Chunk(Rayitas + String.Empty.PadLeft(40, ' '), FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                                phrase.Add(new Chunk(Rayitas + "\n", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                                phrase.Add(new Chunk(Elaborado, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));

                                if (LenUsuario > 5)
                                {
                                    phrase.Add(new Chunk(String.Empty.PadLeft(((70 - LenUsuario) - LenUsuario) - 1, ' ') + Recibi, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                }
                                else
                                {
                                    phrase.Add(new Chunk(String.Empty.PadLeft(((70 - LenUsuario) - LenUsuario) - 2, ' ') + Recibi, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                }

                                phrase.Add(new Chunk(FechaHora, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                phrase.Add(new Chunk(String.Empty.PadLeft(75 - FechaHora.Length, ' ') + "DNI ", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                //Formateando la celda...
                                cell = new PdfPCell(phrase) { Border = 0 };
                                cell.Colspan = 13;
                                cell.PaddingLeft = 145f;
                                TablaDetalle.AddCell(cell);
                                TablaDetalle.CompleteRow();

                                // lineas blancas
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = 13;
                                TablaDetalle.AddCell(cell);
                                TablaDetalle.CompleteRow();
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = 13;
                                TablaDetalle.AddCell(cell);
                                TablaDetalle.CompleteRow();
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = 13;
                                TablaDetalle.AddCell(cell);
                                TablaDetalle.CompleteRow();
                                // ------------------------------------------

                                phrase = new Phrase();
                                phrase.Add(new Chunk(Rayitas + String.Empty.PadLeft(40, ' '), FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                                phrase.Add(new Chunk(Rayitas + "\n", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                                phrase.Add(new Chunk("REVISADO POR :" + String.Empty.PadLeft(73, ' '), FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                phrase.Add(new Chunk("AUTORIZADO POR : " + "\n", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                phrase.Add(new Chunk("PSC" + String.Empty.PadLeft(98, ' '), FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                phrase.Add(new Chunk("EFT", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                ////Formateando la celda...
                                cell = new PdfPCell(phrase) { Border = 0 };
                                cell.Colspan = 13;
                                cell.PaddingLeft = 145f;
                                TablaDetalle.AddCell(cell);
                                TablaDetalle.CompleteRow();

                                // ------------------------------------------
                                // ------------------------------------------

                                docPdf.Add(TablaDetalle);
                                docPdf.NewPage();
                            }
                        }
                        else
                        {

                            //Cabecera del Reporte
                            PdfPTable TablaTitulos = new PdfPTable(3);
                            TablaTitulos.WidthPercentage = 100;

                            //Para el lado Izquierdo
                            phrase = new Phrase();
                            phrase.Add(new Chunk(VariablesLocales.SesionUsuario.Empresa.RazonSocial + "\n", FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta + "\n", FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC + "\n", FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            cell = new PdfPCell(phrase) { Border = 0 };
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);

                            //En medio
                            phrase = new Phrase();
                            phrase.Add(new Chunk("LIBRO " + oListaVoucherDetalle[0].idComprobante + " " + oListaVoucherDetalle[0].desComprobante + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("FILE " + oListaVoucherDetalle[0].numFile + " " + oListaVoucherDetalle[0].desFile + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Del año: " + oListaVoucherDetalle[0].AnioPeriodo + "-Periodo " + oListaVoucherDetalle[0].MesPeriodo + "-Voucher " + oListaVoucherDetalle[0].numVoucher + "\n", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            //Formateando la celda...
                            cell = new PdfPCell(phrase) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);

                            //Para el lado derecho
                            phrase = new Phrase();
                            phrase.Add(new Chunk("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Hora: " + DateTime.Now.ToString("hh:mm:ss") + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Pag. " + oPdfw.PageNumber + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            cell = new PdfPCell(phrase) { Border = 0 };
                            //Formateando la celda
                            cell.PaddingLeft = 85f;
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);

                            TablaTitulos.CompleteRow();

                            #endregion

                            #region SubTitulos

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 3.25f))) { Border = 0 };
                            cell.Colspan = 3;
                            TablaTitulos.AddCell(cell);
                            TablaTitulos.CompleteRow();

                            phrase = new Phrase();
                            phrase.Add(new Chunk("Moneda:       ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk(oListaVoucherDetalle[0].desMoneda, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            cell = new PdfPCell(phrase) { Border = 0 };
                            cell.Colspan = 3;
                            TablaTitulos.AddCell(cell);
                            TablaTitulos.CompleteRow();

                            phrase = new Phrase();
                            phrase.Add(new Chunk("Fecha Doc:  ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            phrase.Add(new Chunk(Convert.ToDateTime(oListaVoucherDetalle[0].fecOperacion).ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            phrase.Add(new Chunk("   Glosa:  ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            phrase.Add(new Chunk(oListaVoucherDetalle[0].GlosaGeneral, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            cell = new PdfPCell(phrase) { Border = 0 };
                            cell.Colspan = 3;
                            TablaTitulos.AddCell(cell);
                            TablaTitulos.CompleteRow();

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 3.25f))) { Border = 0 };
                            cell.Colspan = 3;
                            TablaTitulos.AddCell(cell);
                            TablaTitulos.CompleteRow();

                            docPdf.Add(TablaTitulos);

                            #endregion

                            #region Para el Detalle

                            #region Cabecera del Detalle

                            PdfPTable TablaDetalle = new PdfPTable(13);
                            TablaDetalle.WidthPercentage = 100;
                            TablaDetalle.SetWidths(new float[] { 0.055f, 0.095f, 0.35f, 0.017f, 0.4f, 0.065f, 0.2f, 0.121f, 0.08f, 0.15f, 0.15f, 0.15f, 0.15f });

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("IT", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "S"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("COD.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("CUENTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("R", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("AUXILIAR", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("C.C.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DOCUMENTO", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("FEC. EMIS.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "N", "S2", 2, 2, "S", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("SOLES S/.", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "S2", "N", 2, 2, "S", "N", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DOLARES US$", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 5, 1, "S2", "N", 2, 2, "S", "N", "S", "N"));

                            TablaDetalle.CompleteRow();

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DEBE", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 1, 1, "N", "N", 2, 2, "N", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("HABER", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 1, 1, "N", "N", 2, 2, "N", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DEBE", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 1, 1, "N", "N", 2, 2, "N", "S", "N", "N"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("HABER", ColorFondo, "S", null, FontFactory.GetFont("Arial", SizeLetra), 1, 1, "N", "N", 2, 2, "N", "S", "S", "N"));

                            TablaDetalle.CompleteRow();

                            #endregion

                            #region Detalle

                            String fecVencimiento = String.Empty;
                            String fecDocumento = String.Empty;
                            String numDocumento = String.Empty;
                            Decimal DebeSoles = Variables.Cero;
                            Decimal DebeDolares = Variables.Cero;
                            Decimal HaberSoles = Variables.Cero;
                            Decimal HaberDolares = Variables.Cero;

                            foreach (VoucherItemE item in oListaVoucherDetalle)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.numItem.Substring(2, 3), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.codCuenta, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta.Substring(0, (item.desCuenta.Length >= 22 ? 22 : item.desCuenta.Length)), null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.indReparable, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial.Substring(0, (item.RazonSocial.Length >= 22 ? 22 : item.RazonSocial.Length)), null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.idCCostos, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));

                                if (!String.IsNullOrEmpty(item.idDocumento))
                                {
                                    numDocumento = item.idDocumento + " ";
                                }

                                if (!String.IsNullOrEmpty(item.serDocumento))
                                {
                                    if (item.serDocumento != "0000")
                                        numDocumento += item.serDocumento + "-";
                                }

                                if (!String.IsNullOrEmpty(item.numDocumento))
                                {
                                    numDocumento += item.numDocumento;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(numDocumento, null, "N", null, FontFactory.GetFont("Arial", 6.25f)));

                                if (item.fecDocumento != null)
                                {
                                    fecDocumento = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                                }
                                else
                                {
                                    fecDocumento = String.Empty;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(fecDocumento, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));

                                if (item.indDebeHaber == Variables.Haber)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));

                                    HaberSoles += item.impSoles;
                                    HaberDolares += item.impDolares;
                                }
                                else
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));

                                    DebeSoles += item.impSoles;
                                    DebeDolares += item.impDolares;
                                }

                                TablaDetalle.CompleteRow();
                                numDocumento = String.Empty;
                            }

                            #endregion

                            #region Totales

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, BorderWidthTop = 0.5f };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(DebeSoles.ToString("N2"), FontFactory.GetFont("Arial", 6.25f))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(HaberSoles.ToString("N2"), FontFactory.GetFont("Arial", 6.25f))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(DebeDolares.ToString("N2"), FontFactory.GetFont("Arial", 6.25f))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(HaberDolares.ToString("N2"), FontFactory.GetFont("Arial", 6.25f))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaDetalle.AddCell(cell);

                            TablaDetalle.CompleteRow();

                            #endregion

                            #region Espacios en Blanco

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                            cell.Colspan = 13;
                            TablaDetalle.AddCell(cell);
                            TablaDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                            cell.Colspan = 13;
                            TablaDetalle.AddCell(cell);
                            TablaDetalle.CompleteRow();

                            //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                            //cell.Colspan = 12;
                            //TablaDetalle.AddCell(cell);
                            //TablaDetalle.CompleteRow();

                            //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                            //cell.Colspan = 12;
                            //TablaDetalle.AddCell(cell);
                            //TablaDetalle.CompleteRow();

                            #endregion

                            Int32 LenUsuario = oListaVoucherDetalle[0].UsuarioRegistro.Length;
                            String Elaborado = "ELABORADO POR: " + oListaVoucherDetalle[0].UsuarioRegistro;
                            String FechaHora = "FECHA Y HORA: " + Convert.ToDateTime(oListaVoucherDetalle[0].FechaModificacion).ToString("dd/MM/yyyy hh:mm:ss");
                            String Rayitas = "--------------------------------------------------";
                            String Recibi = " RECIBI CONFORME \n";

                            phrase = new Phrase();
                            phrase.Add(new Chunk(Rayitas + String.Empty.PadLeft(40, ' '), FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            phrase.Add(new Chunk(Rayitas + "\n", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            phrase.Add(new Chunk(Elaborado, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));

                            if (LenUsuario > 5)
                            {
                                phrase.Add(new Chunk(String.Empty.PadLeft(((70 - LenUsuario) - LenUsuario) - 1, ' ') + Recibi, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            }
                            else
                            {
                                phrase.Add(new Chunk(String.Empty.PadLeft(((70 - LenUsuario) - LenUsuario) - 2, ' ') + Recibi, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            }

                            phrase.Add(new Chunk(FechaHora, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            phrase.Add(new Chunk(String.Empty.PadLeft(75 - FechaHora.Length, ' ') + "DNI ", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            //Formateando la celda...
                            cell = new PdfPCell(phrase) { Border = 0 };
                            cell.Colspan = 13;
                            cell.PaddingLeft = 145f;
                            TablaDetalle.AddCell(cell);
                            TablaDetalle.CompleteRow();

                            // lineas blancas
                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 13;
                            TablaDetalle.AddCell(cell);
                            TablaDetalle.CompleteRow();
                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 13;
                            TablaDetalle.AddCell(cell);
                            TablaDetalle.CompleteRow();
                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 13;
                            TablaDetalle.AddCell(cell);
                            TablaDetalle.CompleteRow();
                            // ------------------------------------------

                            phrase = new Phrase();
                            phrase.Add(new Chunk(Rayitas + String.Empty.PadLeft(40, ' '), FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            phrase.Add(new Chunk(Rayitas + "\n", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            phrase.Add(new Chunk("REVISADO POR :" + String.Empty.PadLeft(73, ' '), FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            phrase.Add(new Chunk("AUTORIZADO POR : " + "\n", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            phrase.Add(new Chunk("PSC" + String.Empty.PadLeft(98, ' '), FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            phrase.Add(new Chunk("EFT", FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            ////Formateando la celda...
                            cell = new PdfPCell(phrase) { Border = 0 };
                            cell.Colspan = 13;
                            cell.PaddingLeft = 145f;
                            TablaDetalle.AddCell(cell);
                            TablaDetalle.CompleteRow();

                            // ------------------------------------------
                            // ------------------------------------------

                            docPdf.Add(TablaDetalle);
                            docPdf.NewPage();

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
                    else
                    {
                        RutaTemp = String.Empty;
                    }  

                    #endregion
                }
                else
                {
                    #region Voucher Egreso

                    Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    Guid Aleatorio = Guid.NewGuid();
                    String NombreReporte = @"\VoucherEgresoTmp " + Aleatorio.ToString();
                    String Extension = ".pdf";
                    RutaTemp = @"C:\AmazonErp\ArchivosTemporales";

                    //TAMANÑO DE LETRA - DETALLE para los dos formatos
                    float SizeLetra = 9f;

                    if (!Directory.Exists(RutaTemp))
                    {
                        Directory.CreateDirectory(RutaTemp);
                    }

                    docPdf.AddCreationDate();
                    docPdf.AddAuthor("AMAZONTIC SAC");
                    docPdf.AddCreator("AMAZONTIC SAC");

                    if (!String.IsNullOrEmpty(RutaTemp.Trim()))
                    {
                        PdfPCell cell = null;
                        Phrase phrase = null;

                        //Creacion del archivo pdf
                        RutaTemp += NombreReporte + Extension;

                        if (File.Exists(RutaTemp))
                        {
                            if (docPdf.IsOpen())
                            {
                                docPdf.Close();
                            }

                            File.Delete(RutaTemp);
                        }

                        FileStream NuevoArchivo = new FileStream(RutaTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, NuevoArchivo);

                        //con esto conseguiremos que el documento sea presentada de dos en dos 
                        oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                        oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                        oPdfw.ViewerPreferences = PdfWriter.HideMenubar;
                        oPdfw.ViewerPreferences = PdfWriter.HideWindowUI;

                        //Esto crea un nuevo destino para enviar la acción cuando se abra el documento. 
                        //Se usa doc.PageSize.Height para establecer la coordenada en la parte superior de la página. 
                        //PdfDestination.XYZ es un tipo PdfDestination específica que nos permite establecer la ubicación y el zoom(100%).
                        PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                        //Abre el documento
                        docPdf.Open();

                        // ========================================
                        // ALDEASA
                        // ========================================
                        String Moneda = "";
                        String desMoneda = "";
                        String RazonSocial = "";
                        String codCuenta = "";
                        String documento = "";

                        Decimal Importe_S = 0;
                        Decimal Importe_D = 0;

                        if (VariablesLocales.SesionUsuario.Empresa.IdEmpresa == 3)
                        {
                            foreach (VoucherItemE item in oListaVoucherDetalle)
                            {
                                if (item.codCuenta.Substring(0,3) == "104")
                                {
                                    RazonSocial = item.RazonSocial;
                                    codCuenta = item.codCuenta;
                                    Importe_S += item.impSoles;
                                    Importe_D += item.impDolares;

                                    documento =item.idDocumento+' '+item.serDocumento+' '+item.numDocumento;
                                }
                            }

                            if (codCuenta != "")
                            {
                                PlanCuentasE oCuenta = ObtenerPlanCuenta(codCuenta);

                                Moneda = oCuenta.idMoneda;

                                if (Moneda == "01")
                                    desMoneda = "S/.";
                                if (Moneda == "02")
                                    desMoneda = "US$";
                                if (Moneda == "03")
                                {
                                    desMoneda = "S/.";
                                    Moneda = "01";
                                }
                            }
                        }
                        // ========================================

                        #region Titulos

                        if (TipoForm == "PP")
                        {
                            //Cabecera del Reporte
                            PdfPTable TablaTitulos = new PdfPTable(3);
                            TablaTitulos.WidthPercentage = 100;

                            //Para el lado Izquierdo
                            phrase = new Phrase();
                            phrase.Add(new Chunk(VariablesLocales.SesionUsuario.Empresa.RazonSocial + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            cell = new PdfPCell(phrase) { Border = 0 };
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);

                            //En medio
                            phrase = new Phrase();
                            phrase.Add(new Chunk("TESORERIA : " + oPrograma.Fecha.ToString("d") + "\n", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Voucher N°: " + oListaVoucherDetalle[0].numVoucher + "\n", FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            //Formateando la celda...
                            cell = new PdfPCell(phrase) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);

                            //Para el lado derecho
                            phrase = new Phrase();
                            phrase.Add(new Chunk("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Hora: " + DateTime.Now.ToString("hh:mm:ss") + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Pag. " + oPdfw.PageNumber + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            cell = new PdfPCell(phrase) { Border = 0 };
                            //Formateando la celda
                            cell.PaddingLeft = 85f;
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);
                            TablaTitulos.CompleteRow();

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 3.25f))) { Border = 0, BorderWidthBottom = 0.5f };
                            cell.Colspan = 3;
                            TablaTitulos.AddCell(cell);
                            TablaTitulos.CompleteRow();

                            docPdf.Add(TablaTitulos);
                        }
                        else
                        {
                            //Cabecera del Reporte
                            PdfPTable TablaTitulos = new PdfPTable(3);
                            TablaTitulos.WidthPercentage = 100;

                            //Para el lado Izquierdo
                            phrase = new Phrase();
                            phrase.Add(new Chunk(VariablesLocales.SesionUsuario.Empresa.RazonSocial + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            cell = new PdfPCell(phrase) { Border = 0 };
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);

                            //En medio
                            phrase = new Phrase();
                            phrase.Add(new Chunk("LIBRO : " + oListaVoucherDetalle[0].idComprobante + " " + oListaVoucherDetalle[0].desComprobante + "\n", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("FILE : " + oListaVoucherDetalle[0].numFile + " " + oListaVoucherDetalle[0].desFile + "\n", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Voucher N°: " + oListaVoucherDetalle[0].numVoucher + "\n", FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            //Formateando la celda...
                            cell = new PdfPCell(phrase) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);

                            //Para el lado derecho
                            phrase = new Phrase();
                            phrase.Add(new Chunk("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Hora: " + DateTime.Now.ToString("hh:mm:ss") + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                            phrase.Add(new Chunk("Pag. " + oPdfw.PageNumber + "\n", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                            cell = new PdfPCell(phrase) { Border = 0 };
                            //Formateando la celda
                            cell.PaddingLeft = 85f;
                            //Añadiendo la celda a la tabla
                            TablaTitulos.AddCell(cell);
                            TablaTitulos.CompleteRow();

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 3.25f))) { Border = 0, BorderWidthBottom = 0.5f };
                            cell.Colspan = 3;
                            TablaTitulos.AddCell(cell);
                            TablaTitulos.CompleteRow();

                            docPdf.Add(TablaTitulos);
                        }

                       

                        #endregion

                        #region SubTitulos

                        PdfPTable TablaSubtitulos = new PdfPTable(3);
                        TablaSubtitulos.WidthPercentage = 100;
                        TablaSubtitulos.SetWidths(new float[] { 3f, 1.1f, 1.5f });

                        phrase = new Phrase();
                        phrase.Add(new Chunk("GIRADO A:  ", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk((RazonSocial==""? oListaVoucherDetalle[0].RazonSocial:RazonSocial), FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0, BorderWidthLeft = 0.5f };

                        TablaSubtitulos.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("IMPORTE " +(Moneda==""? (oListaVoucherDetalle[0].idMoneda == "01" ? "S/." : (oListaVoucherDetalle[0].idMoneda == "02" ? "US$" : "")) :desMoneda) + ":", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0 };

                        TablaSubtitulos.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk((Moneda=="" ? oListaVoucherDetalle[0].Importe.ToString("N2") : (Moneda == "01" ? Importe_S.ToString("N2") : (Moneda == "02" ? Importe_D.ToString("N2") : Importe_S.ToString("N2")))), FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0, BorderWidthRight = 0.5f };

                        TablaSubtitulos.AddCell(cell);
                        TablaSubtitulos.CompleteRow();

                        phrase = new Phrase();
                        phrase.Add(new Chunk("DOC./RUC:  ", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(oListaVoucherDetalle[0].Ruc, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0, BorderWidthLeft = 0.5f };

                        TablaSubtitulos.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(oListaVoucherDetalle[0].desDocumento + ":", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0 };

                        TablaSubtitulos.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk( (documento==""? oListaVoucherDetalle[0].numDocumento:documento), FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0, BorderWidthRight = 0.5f };

                        TablaSubtitulos.AddCell(cell);
                        TablaSubtitulos.CompleteRow();

                        phrase = new Phrase();
                        phrase.Add(new Chunk("BANCO:       ", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(oListaVoucherDetalle[0].desCuenta, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0, BorderWidthLeft = 0.5f };

                        TablaSubtitulos.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("FECHA:", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0 };

                        TablaSubtitulos.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(Convert.ToDateTime(oListaVoucherDetalle[0].fecOperacion).ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0, BorderWidthRight = 0.5f };

                        TablaSubtitulos.AddCell(cell);
                        TablaSubtitulos.CompleteRow();

                        phrase = new Phrase();
                        phrase.Add(new Chunk("GLOSA:       ", FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(oListaVoucherDetalle[0].GlosaGeneral, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        cell = new PdfPCell(phrase) { Border = 0, BorderWidthLeft = 0.5f, BorderWidthRight = 0.5f };
                        cell.Colspan = 3;

                        TablaSubtitulos.AddCell(cell);
                        TablaSubtitulos.CompleteRow();

                        docPdf.Add(TablaSubtitulos);

                        #endregion

                        #region Para el Detalle

                        #region Cabecera del Detalle
                        int TotalColumnasEgreso = 10;

                        PdfPTable TablaDetalle = new PdfPTable(TotalColumnasEgreso);
                        TablaDetalle.WidthPercentage = 100;
                        TablaDetalle.SetWidths(new float[] { 0.09f, 0.12f,  0.45f, 0.25f, 0.12f, 0.08f, 0.15f, 0.08f, 0.13f, 0.13f });
                        // 0.04f,
                        // 0.12f,

                        // Linea en Blanco
                        cell = new PdfPCell(new Paragraph(String.Empty.PadLeft(285, '-'), FontFactory.GetFont("Batang", 6f))) { Border = 0, BorderWidthLeft = 0.5f, BorderWidthRight = 0.5f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph("IT", FontFactory.GetFont("Arial", 8f))) { Border = 0, BorderWidthLeft = 0.5f, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("CUENTA", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        //cell = new PdfPCell(new Paragraph("R", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        //TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("AUXILIAR", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("DOCUMENTO", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("DCMTO. EMISION", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        //cell = new PdfPCell(new Paragraph("DCMTO. VCMTO.", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        //TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("T.C.", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("IMPORTE DOLARES", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("IND CTA", FontFactory.GetFont("Arial", 8f))) { Border = 0, Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("NUEVOS SOLES", FontFactory.GetFont("Arial", 8f))) { Border = 0, BorderWidthRight = 0.5f, Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };

                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph("Debe", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Haber", FontFactory.GetFont("Arial", 8f))) { Border = 0, BorderWidthRight = 0.5f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        TablaDetalle.AddCell(cell);

                        TablaDetalle.CompleteRow();

                        // Linea en Blanco
                        cell = new PdfPCell(new Paragraph(String.Empty.PadLeft(285, '-'), FontFactory.GetFont("Batang", 6f))) { Border = 0, BorderWidthLeft = 0.5f, BorderWidthRight = 0.5f, BorderWidthBottom = 0.5f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        #endregion

                        #region Detalle

                        String fecVencimiento = String.Empty;
                        String fecDocumento = String.Empty;
                        String numDocumento = String.Empty;
                        Decimal DebeSoles = Variables.Cero;
                        Decimal HaberSoles = Variables.Cero;

                        foreach (VoucherItemE item in oListaVoucherDetalle)
                        {
                            cell = new PdfPCell(new Paragraph(item.numItem.Substring(2,3), FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.codCuenta, FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaDetalle.AddCell(cell);

                            //cell = new PdfPCell(new Paragraph(item.indReparable, FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            //TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.RazonSocial, FontFactory.GetFont("Arial", 8f))) { Border = 0 };
                            TablaDetalle.AddCell(cell);

                            if (!String.IsNullOrEmpty(item.idDocumento))
                            {
                                numDocumento = item.idDocumento + " ";
                            }

                            if (!String.IsNullOrEmpty(item.serDocumento))
                            {
                                if (item.serDocumento != "0000")
                                numDocumento += item.serDocumento + "-";
                            }

                            if (!String.IsNullOrEmpty(item.numDocumento))
                            {
                                numDocumento += item.numDocumento;
                            }

                            cell = new PdfPCell(new Paragraph(numDocumento, FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaDetalle.AddCell(cell);

                            if (item.fecDocumento != null)
                            {
                                fecDocumento = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                            }
                            else
                            {
                                fecDocumento = String.Empty;
                            }

                            cell = new PdfPCell(new Paragraph(fecDocumento, FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaDetalle.AddCell(cell);

                            if (item.fecVencimiento != null)
                            {
                                fecVencimiento = Convert.ToDateTime(item.fecVencimiento).ToString("dd/MM/yy");
                            }
                            else
                            {
                                fecVencimiento = String.Empty;
                            }

                            //cell = new PdfPCell(new Paragraph(fecVencimiento, FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            //TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.tipCambio.ToString("N3"), FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.impDolares.ToString("N2"), FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.indDebeHaber, FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaDetalle.AddCell(cell);

                            if (item.indDebeHaber == Variables.Haber)
                            {
                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.impSoles.ToString("N2"), FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaDetalle.AddCell(cell);

                                HaberSoles += item.impSoles;
                                //HaberDolares += item.impDolares;
                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph(item.impSoles.ToString("N2"), FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaDetalle.AddCell(cell);

                                DebeSoles += item.impSoles;
                                //DebeDolares += item.impDolares;
                            }

                            TablaDetalle.CompleteRow();
                            numDocumento = String.Empty;
                        }

                        #endregion

                        #region Totales

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 2.5f))) { Border = 0 };
                        cell.Colspan = TotalColumnasEgreso-2;
                        TablaDetalle.AddCell(cell);



                        cell = new PdfPCell(new Paragraph(DebeSoles.ToString("N2"), FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(HaberSoles.ToString("N2"), FontFactory.GetFont("Arial", SizeLetra))) { Border = 0, BorderWidthTop = 0.5f, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaDetalle.AddCell(cell);

                        TablaDetalle.CompleteRow();

                        #endregion

                        #region Espacios en Blanco

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 2.25f))) { Border = 0 };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 9.25f))) { Border = 0 };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        #endregion

                        Int32 LenUsuario = oListaVoucherDetalle[0].UsuarioRegistro.Length;
                        String Elaborado = "ELABORADO POR:";
                        String Rayitas = "--------------------------------------------------";
                        String Recibi = "RECIBIDO POR:\n";

                        phrase = new Phrase();
                        phrase.Add(new Chunk(Rayitas + String.Empty.PadLeft(40, ' '), FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(Rayitas + "\n", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(Elaborado, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(String.Empty.PadLeft(46, ' ') + Recibi, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(oListaVoucherDetalle[0].UsuarioRegistro, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(String.Empty.PadLeft(72 - oListaVoucherDetalle[0].UsuarioRegistro.Length, ' ') + "DNI ", FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        ////Formateando la celda...
                        cell = new PdfPCell(phrase) { Border = 0 };
                        cell.Colspan = TotalColumnasEgreso;
                        cell.PaddingLeft = 145f;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        // ------------------------------------------
                        // henry 
                        // ------------------------------------------

                        // lineas blancas
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        cell.Colspan = TotalColumnasEgreso;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();
                        // ------------------------------------------

                        phrase = new Phrase();
                        phrase.Add(new Chunk(Rayitas + String.Empty.PadLeft(40, ' '), FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk(Rayitas + "\n", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk("REVISADO POR :" + String.Empty.PadLeft(49, ' '), FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk("AUTORIZADO POR : " + "\n", FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk("PSC" + String.Empty.PadLeft(71, ' '), FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        phrase.Add(new Chunk("EFT", FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                        ////Formateando la celda...
                        cell = new PdfPCell(phrase) { Border = 0 };
                        cell.Colspan = TotalColumnasEgreso;
                        cell.PaddingLeft = 145f;
                        TablaDetalle.AddCell(cell);
                        TablaDetalle.CompleteRow();

                        // ------------------------------------------
                        // ------------------------------------------
                        docPdf.Add(TablaDetalle);

                        #endregion

                        // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                        PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                        //establecer la acción abierta para nuestro objeto escritor
                        oPdfw.SetOpenAction(action);

                        //Liberando memoria
                        oPdfw.Flush();
                        docPdf.Close();
                    }
                    else
                    {
                        RutaTemp = String.Empty;
                    } 

                    #endregion
                }
            }
            catch (DocumentException ex)
            {
                throw new DocumentException(ex.Message);
            }
            catch (IOException IOex)
            {
                throw new IOException(IOex.Message);
            }
        }

        #endregion

        #region Eventos
        
        private void frmImpresionVoucher_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            if (!String.IsNullOrEmpty(RutaTemp))
            {
                wbPdf.Navigate(RutaTemp);
            }

            WindowState = FormWindowState.Maximized;
        } 

        #endregion

    }
}
