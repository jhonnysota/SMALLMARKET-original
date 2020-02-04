using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using ClienteWinForm;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteControlGuias : FrmMantenimientoBase
    {

        public frmReporteControlGuias()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<EmisionDocumentoE> oGuiasVentas = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marque = String.Empty;
        String tipo = "B";

        #endregion

        #region Procedimientos de Usuario

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A1.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\ControlGuias " + Aleatorio.ToString();
            String Extension = ".pdf";
            BaseColor ColorCab = new BaseColor(Color.Silver);

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio si no existe...
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

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                    oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    PaginaInicialControlGuias ev = new PaginaInicialControlGuias();
                    //Parametros que pasará al PDF
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Titulos del detalle

                    PdfPTable TablaCabDetalle = new PdfPTable(44)
                    {
                        WidthPercentage = 100
                    };

                    TablaCabDetalle.SetWidths(new float[] { 0.037f, 0.015f, 0.02f, 0.025f, 0.03f, 0.03f, 0.037f, 0.15f, 0.15f, 0.15f, 0.04f, 0.08f, 0.08f, 0.04f,
                                                            0.035f, 0.028f, 0.02f, 0.03f, 0.13f, 0.025f, 0.033f, 0.025f, 0.025f, 0.035f, 0.015f, 0.02f, 0.025f,
                                                            0.028f, 0.037f, 0.13f, 0.028f, 0.02f, 0.03f, 0.13f, 0.025f, 0.033f, 0.02f, 0.025f, 0.025f, 0.025f, 0.018f,
                                                            0.025f, 0.025f, 0.025f });
                    List<String> Titulos = new List<String>()
                    {
                        "Estado", "T.D.", "Serie", "Número", "F.Emis.", "F.Trasl.", "Ruc", "Razón Social", "Punto de Partida", "Punto de Llegada", "Motivo Traslado", "Referencia", "Movimiento", "N° Doc.Sal.Almacen",
                        "N° Pedido", "Código", "Cant.", "Und.Enva.", "Descripción", "Cant.Pres.", "Und.Pres.", "Peso Total", "Lote", "Estado", "T.D.", "Serie", "Número",
                        "F.Emis." , "Num. Ruc Fact.", "Razon Social Fact", "Código", "Cant.", "Und.Env.", "Descripción", "Cant.Pres.", "Und.Pres.", "Mon.", "Sub Total $", "IGV $", "Total $", "T.C.",
                        "Sub Total S/", "IGV S/", "Total S/"
                    };

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("GUIAS DE REMISION", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S24", "N", 5, 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COMPROBANTES DE PAGO", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S20", "N", 5, 5));
                    TablaCabDetalle.CompleteRow();

                    foreach (String item in Titulos)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item, ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    #endregion

                    #region Detalle

                    foreach (EmisionDocumentoE item in oGuiasVentas)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.indEstado, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numSerie, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocumento, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        //Por revisar//TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecEmision.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                        if (item.fecVencimiento != null)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecTraslado.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numRuc, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                        if (item.PuntoPartida.Length > 65)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PuntoPartida.Substring(0, 65), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PuntoPartida, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }

                        if (item.PuntoLlegada.Length > 65)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PuntoLlegada.Substring(0, 65), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PuntoLlegada, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }



                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desTraslado, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.OtroTipoTraslado, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Tipo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codDocumentoAlmacen, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Pedido, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedida, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PesoBruto, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Lote, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.EstadoFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numSerieFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocumentoFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                        if (item.fecEmisionFact != null)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecEmisionFact.Value.ToString("dd/MM/yy"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        }
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numRucFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocialFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticuloFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CantidadFact.ToString(), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomMedidaEnvFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticuloFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ContenidoPres.ToString(), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomMedidaPresFact, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.subTotalDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.IgvDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.subTotalSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.IgvSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalS.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 2));

                        TablaCabDetalle.CompleteRow();
                    }

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF 

                    #endregion

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                }
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = "REPORTE DE CONTROL DE GUIAS DE VENTAS";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            if (newFile == null)
            {
                throw new Exception("El archivo no existe en la ruta especificada.");
            }

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(VariablesLocales.SesionUsuario.Empresa.NombreComercial);

                if (oHoja != null)
                {
                    Int32 Fila = 1;
                    Int32 TotColumnas = 44;
                    Int32 Col = 1;

                    #region Titulo Principal

                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[Fila, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    }

                    //Alto de la fila principal
                    oHoja.Row(Fila).Height = 30;

                    #endregion

                    #region Titulos del detalle

                    //Aumentando 2 filas
                    Fila += 2;
                    //Alto de la fila
                    oHoja.Row(Fila).Height = 20;

                    using (ExcelRange Rango = oHoja.Cells[Fila, 1, Fila, 23])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Value = "GUIAS DE REMISION";
                    }

                    using (ExcelRange Rango = oHoja.Cells[Fila, 24, Fila, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Value = "COMPROBANTES DE PAGO";
                    }

                    //Aumentando 1 fila
                    Fila += 1;
                    //Alto de la fila
                    oHoja.Row(Fila).Height = 20;

                    List<String> Titulos = new List<String>()
                    {
                        "Estado", "T.D.", "Serie", "Número", "F.Emis.", "F.Trasl.", "Ruc", "Razón Social", "Punto de Partida", "Punto de Llegada", "Motivo Traslado" , "Referencia", "Movimiento", "N° Doc.Sal.Almacen",
                        "N° Pedido", "Código", "Cant.", "Und.Enva.", "Descripción", "Cant.Pres.", "Und.Pres.", "Peso Total", "Lote", "Estado", "T.D.", "Serie", "Número",
                        "F.Emis.", "Num. Ruc Fact.", "Razon Social Fact","Código", "Cant.", "Und.Env.", "Descripción", "Cant.Pres.", "Und.Pres.", "Mon.", "Sub Total $", "IGV $", "Total $", "T.C.",
                        "Sub Total S/", "IGV S/", "Total S/"
                    };

                    foreach (String item in Titulos)
                    {
                        oHoja.Cells[Fila, Col].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                        oHoja.Cells[Fila, Col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[Fila, Col].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        oHoja.Cells[Fila, Col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        oHoja.Cells[Fila, Col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[Fila, Col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[Fila, Col].Value = item;

                        Col++;
                    }

                    #endregion

                    #region Detalle

                    //Aumentando 1 fila
                    Fila += 1;

                    foreach (EmisionDocumentoE item in oGuiasVentas)
                    {
                        oHoja.Cells[Fila, 1].Value = item.indEstado;
                        oHoja.Cells[Fila, 2].Value = item.idDocumento;
                        oHoja.Cells[Fila, 3].Value = item.numSerie;
                        oHoja.Cells[Fila, 4].Value = item.numDocumento;
                        oHoja.Cells[Fila, 5].Value = item.fecEmision;
                        oHoja.Cells[Fila, 6].Value = item.fecTraslado;
                        oHoja.Cells[Fila, 7].Value = item.numRuc;
                        oHoja.Cells[Fila, 8].Value = item.RazonSocial;
                        oHoja.Cells[Fila, 9].Value = item.PuntoPartida;
                        oHoja.Cells[Fila, 10].Value = item.PuntoLlegada;
                        oHoja.Cells[Fila, 11].Value = item.desTraslado;
                        oHoja.Cells[Fila, 12].Value = item.OtroTipoTraslado;
                        oHoja.Cells[Fila, 13].Value = item.Tipo;
                        oHoja.Cells[Fila, 14].Value = item.codDocumentoAlmacen;
                        oHoja.Cells[Fila, 15].Value = item.Pedido;
                        oHoja.Cells[Fila, 16].Value = item.codArticulo;
                        oHoja.Cells[Fila, 17].Value = item.Cantidad;
                        oHoja.Cells[Fila, 18].Value = item.nomUMedida;
                        oHoja.Cells[Fila, 19].Value = item.nomArticulo;
                        oHoja.Cells[Fila, 20].Value = item.Contenido;
                        oHoja.Cells[Fila, 21].Value = item.nomUMedidaPres;
                        oHoja.Cells[Fila, 22].Value = item.PesoBruto;
                        oHoja.Cells[Fila, 23].Value = item.Lote;
                        oHoja.Cells[Fila, 24].Value = item.EstadoFact;
                        oHoja.Cells[Fila, 25].Value = item.idDocumentoFact;
                        oHoja.Cells[Fila, 26].Value = item.numSerieFact;
                        oHoja.Cells[Fila, 27].Value = item.numDocumentoFact;
                        oHoja.Cells[Fila, 28].Value = item.fecEmisionFact;
                        oHoja.Cells[Fila, 29].Value = item.numRucFact;
                        oHoja.Cells[Fila, 30].Value = item.RazonSocialFact;
                        oHoja.Cells[Fila, 31].Value = item.codArticuloFact;
                        oHoja.Cells[Fila, 32].Value = item.CantidadFact;
                        oHoja.Cells[Fila, 33].Value = item.nomMedidaEnvFact;
                        oHoja.Cells[Fila, 34].Value = item.nomArticuloFact;
                        oHoja.Cells[Fila, 35].Value = item.ContenidoPres;
                        oHoja.Cells[Fila, 36].Value = item.nomMedidaPresFact;
                        oHoja.Cells[Fila, 37].Value = item.desMoneda;
                        oHoja.Cells[Fila, 38].Value = item.subTotalDol;
                        oHoja.Cells[Fila, 39].Value = item.IgvDol;
                        oHoja.Cells[Fila, 40].Value = item.TotalD;
                        oHoja.Cells[Fila, 41].Value = item.tipCambio;
                        oHoja.Cells[Fila, 42].Value = item.subTotalSol;
                        oHoja.Cells[Fila, 43].Value = item.IgvSol;
                        oHoja.Cells[Fila, 44].Value = item.TotalS;

                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[Fila, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7f));

                            if (i == 5 || i == 6 || i == 28)
                            {
                                oHoja.Cells[Fila, i].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[Fila, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            if (i == 17 || i == 20 || i == 32 || i == 35 || i == 38 || i == 39 || i == 40 || i == 41 || i == 42 || i == 43 || i == 44)
                            {
                                oHoja.Cells[Fila, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                if (i == 41)
                                {
                                    oHoja.Cells[Fila, i].Style.Numberformat.Format = "##0.000";
                                }
                                else
                                {
                                    oHoja.Cells[Fila, i].Style.Numberformat.Format = "###,###,##0.00";
                                }
                            }
                        }

                        Fila += 1;
                    } 

                    #endregion

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();

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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
                    oHoja.Workbook.Properties.Comments = VariablesLocales.SesionUsuario.Empresa.NombreComercial;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A2;

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oGuiasVentas == null || oGuiasVentas.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Reporte de Control de Guias ", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    btBuscar.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Exportar, false);
                    pbProgress.Visible = true;

                    Cursor = Cursors.WaitCursor;

                    _bw.RunWorkerAsync();
                }
                else
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (tipo == "B")
                {
                    string FechaIni = dtpInicio.Value.ToString("yyyyMMdd");
                    string FechaFin = dtpFinal.Value.ToString("yyyyMMdd");

                    lblProcesando.Text = "Obteniendo Documentos...";
                    oGuiasVentas = AgenteVentas.Proxy.ControlGuiasVenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, "GV", FechaIni, FechaFin);
                    lblProcesando.Text = "Armando el Reporte...";

                    //Generando el PDF
                    ConvertirApdf();
                }
                else
                {
                    ExportarExcel(RutaGeneral);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeError(String.Format("Ha ocurrido la excepción: {0}", e.Error.Message));
            }
            else
            {
                if (tipo == "B")
                {
                    if (!String.IsNullOrEmpty(RutaGeneral) && oGuiasVentas.Count > 0)
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                    }
                    else
                    {
                        Global.QuitarReferenciaWebBrowser(wbNavegador);
                        RutaGeneral = String.Empty;
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Guias de Ventas exportadas...");
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteControlGuias_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;

            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "B";
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void frmReporteControlGuias_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        } 

        #endregion

    }
}

public class PaginaInicialControlGuias : PdfPageEventHelper
{

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        #region Variables

        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

        #endregion Variables

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2)
        {
            WidthPercentage = 100
        };

        table.SetWidths(new float[] { 0.9f, 0.13f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda("REPORTE DE CONTROL DE GUIAS DE VENTAS", null, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 5f, 5f));
        table.CompleteRow();

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        table.CompleteRow();

        document.Add(table); //Añadiendo la tabla al documento PDF
    }

}