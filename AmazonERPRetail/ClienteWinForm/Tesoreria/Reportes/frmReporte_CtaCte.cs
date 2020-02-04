using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

#region Del Proyecto

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;
using Infraestructura.Winform;

#endregion

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

#region Para Excel

using OfficeOpenXml.Style;
using OfficeOpenXml;

#endregion

namespace ClienteWinForm.Tesoreria.Reportes
{
    public partial class frmReporte_CtaCte : FrmMantenimientoBase
    {

        public frmReporte_CtaCte()
        {
            InitializeComponent();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        List<CtaCteE> oListaCtaCte = null;
        String RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        Int32 idPersona = 0;
        String RutaTemp = "";
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Int32 TipoReporte = 0;
        float[] CabeceraDocumentos = new float[] { 0.09f, 0.09f, 0.04f, 0.12f, 0.06f, 0.08f, 0.08f, 0.08f, 0.04f, 0.05f, 0.12f, 0.12f };
        float[] CabeceraDetalle = new float[] { 0.08f, 0.08f, 0.08f, 0.06f, 0.07f, 0.07f, 0.04f, 0.04f, 0.07f, 0.07f, 0.07f };
        List<CtaCteE> ListaFilt = new List<CtaCteE>();
        string tipoAccion = String.Empty;
        Int32 idSistema = 0;

        #endregion

        #region Procedimientos de Usuario

        void ConvertirApdf(Int32 Reporte)
        {
            try
            {
                Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                Guid Aleatorio = Guid.NewGuid();
                String NombreReporte = String.Empty; //@"\Reporte CtaCte " + Aleatorio.ToString();
                String Extension = ".pdf";
                String TituloGeneral = "";
                String Fechas = "";
                iTextSharp.text.Font LetraNegrita = FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font LetraNormal = FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font FuenteCabecera = FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font FuenteDetalle = FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.NORMAL);
                BaseColor color = new BaseColor(ColorTranslator.FromHtml("#CBCBCB"));
                List<CtaCteE> ListaCtaCteTmp = null;

                RutaTemp = @"C:\AmazonErp\ArchivosTemporales";

                if (!Directory.Exists(RutaTemp))
                {
                    Directory.CreateDirectory(RutaTemp);
                }

                docPdf.AddCreationDate();
                docPdf.AddAuthor("AMAZONTIC SAC");
                docPdf.AddCreator("AMAZONTIC SAC");

                if (Reporte == 0)
                {
                    #region Por Documento Nuevo

                    NombreReporte = @"\Reporte CtaCte " + Aleatorio.ToString();

                    if (!String.IsNullOrEmpty(RutaTemp.Trim()))
                    {
                        if (rbPorDocumentos.Checked)
                        {
                            TituloGeneral = "CUENTA CORRIENTE RESUMIDA";
                            Fechas = "(Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + ")";
                        }

                        //Creacion del archivo pdf
                        RutaTemp += NombreReporte + Extension;

                        if (File.Exists(RutaTemp))
                        {
                            File.Delete(RutaTemp);
                        }

                        FileStream fsNuevoArchivo = new FileStream(RutaTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                        PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                        oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                        if (docPdf.IsOpen())
                        {
                            docPdf.CloseDocument();
                        }

                        PagEncabezadoCtaCte ev = new PagEncabezadoCtaCte();
                        oPdfw.PageEvent = ev;

                        docPdf.Open();

                        //Cabecera del Reporte
                        PdfPTable table = new PdfPTable(2);

                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 0.35f, 0.65f });
                        table.HorizontalAlignment = Element.ALIGN_LEFT;

                        //Logo de la Empresa
                        if (!File.Exists(RutaImagen))
                        {
                            RutaImagen = ReaderHelper.RevisarLogo(RutaImagen, Properties.Resources.interrogacion);
                        }

                        //Lado Derecho
                        PdfPCell CeldaImagen = null;

                        if (File.Exists(RutaImagen))
                        {
                            //CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 180f, 1, "S", 1));
                            System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                            CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 3f, 170f, 40f, 1, 1, "S", 1f));
                            Img = null;
                        }
                        else
                        {
                            CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1));
                        }

                        CeldaImagen.Rowspan = 2;
                        table.AddCell(CeldaImagen);

                        //Lado Izquierdo
                        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 0, 4, "S", "N", "S", "N", 1));
                        table.AddCell(ReaderHelper.NuevaCelda(Fechas, null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 3, 0, "N", "S", "S", "N", 1));
                        table.CompleteRow(); //Fila completada

                        //Espacio en Blanco
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                        docPdf.Add(table);

                        //Obteniendo una lista temporal para la cabecera...
                        List<CtaCteE> oListaCabeceras = oListaCtaCte.GroupBy(x => x.idPersona).Select(g => g.First()).ToList();
                        Decimal totDocS = 0;
                        Decimal totDocD = 0;
                        Decimal TotalSaldoS = 0;
                        Decimal TotalSaldoD = 0;

                        //Sub Titulos
                        foreach (CtaCteE itemCab in oListaCabeceras)
                        {
                            #region Subtitulos

                            PdfPTable TablaSubTitulos = new PdfPTable(4);
                            TablaSubTitulos.WidthPercentage = 100;
                            TablaSubTitulos.SetWidths(new float[] { 0.1f, 0.7f, 0.1f, 0.1f });

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("CLIENTE: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.RazonSocial, null, "N", null, LetraNormal));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("RUC: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.RUC, null, "N", null, LetraNormal));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("DIRECCION: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.Direccion, null, "N", null, LetraNormal, -1, -1, "S4"));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            docPdf.Add(TablaSubTitulos); //Añadiendo la tabla al documento PDF...
                            TablaSubTitulos = null;

                            #endregion

                            ListaCtaCteTmp = oListaCtaCte.Where(x => x.idPersona == itemCab.idPersona).ToList();
                            PdfPTable TablaDetalle = new PdfPTable(12);
                            TablaDetalle.SetWidths(CabeceraDocumentos);
                            TablaDetalle.WidthPercentage = 100;

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Operación", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Registro", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TD", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Documento", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Serie", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Número", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Emisión", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Venc.", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Mon.", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Soles", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Dolares", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.CompleteRow();

                            if (ListaCtaCteTmp.Count > 0)
                            {
                                totDocS = 0;
                                totDocD = 0;

                                foreach (CtaCteE item in ListaCtaCteTmp)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaCancelacion.ToString("dd/MM/yyyy"), null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaRegistro.Value.ToString("dd/MM/yyyy"), null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FuenteDetalle));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desDocumento, null, "S", null, FuenteDetalle));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.numSerie, null, "S", null, FuenteDetalle));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocumento, null, "S", null, FuenteDetalle));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.ToString("dd/MM/yyyy"), null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaVencimiento.Value.ToString("dd/MM/yyyy"), null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.TipoCambio.ToString("N3"), null, "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Saldo.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.SaldoD.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.CompleteRow();

                                    totDocS += item.Saldo;
                                    totDocD += item.SaldoD;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S8"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL ", color, "S", null, FuenteDetalle, 5, 1, "S2"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(totDocS.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(totDocD.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.CompleteRow();

                                //Fila en blanco
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S12"));
                                TablaDetalle.CompleteRow();
                            }

                            docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF 
                        }

                        TotalSaldoS = oListaCtaCte.Sum(s => s.Saldo);
                        TotalSaldoD = oListaCtaCte.Sum(s => s.SaldoD);

                        PdfPTable TablaTotales = new PdfPTable(12);
                        TablaTotales.SetWidths(CabeceraDocumentos);
                        TablaTotales.WidthPercentage = 100;

                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FuenteDetalle, 5, 1, "S6"));
                        TablaTotales.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL ", color, "S", null, FuenteCabecera, 5, 1, "S4"));
                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(TotalSaldoS.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(TotalSaldoD.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                        TablaTotales.CompleteRow();

                        docPdf.Add(TablaTotales); //Añadiendo la tabla al documento PDF 

                        // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                        PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                        //establecer la acción abierta para nuestro objeto escritor
                        oPdfw.SetOpenAction(action);

                        //Liberando memoria
                        oPdfw.Flush();
                        docPdf.Close();
                        fsNuevoArchivo.Close();
                    }
                    else
                    {
                        RutaTemp = "";
                    }

                    #endregion
                }
                else
                {
                    #region Por Documento Detallado

                    NombreReporte = @"\Reporte CtaCte Detallado " + Aleatorio.ToString();

                    if (!String.IsNullOrEmpty(RutaTemp.Trim()))
                    {
                        if (rbDetalle.Checked)
                        {   
                            TituloGeneral = "CUENTA CORRIENTE POR DOCUMENTO DETALLADO";
                            Fechas = "( Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + " )";
                        }

                        //Creacion del archivo pdf
                        RutaTemp += NombreReporte + Extension;

                        if (File.Exists(RutaTemp))
                        {
                            File.Delete(RutaTemp);
                        }

                        FileStream fsNuevoArchivo = new FileStream(RutaTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                        PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                        oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                        oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                        oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                        if (docPdf.IsOpen())
                        {
                            docPdf.CloseDocument();
                        }

                        PagEncabezadoCtaCte ev = new PagEncabezadoCtaCte();
                        oPdfw.PageEvent = ev;

                        docPdf.Open();

                        //Cabecera del Reporte
                        PdfPTable table = new PdfPTable(2);
                        
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 0.35f, 0.65f });
                        table.HorizontalAlignment = Element.ALIGN_LEFT;

                        //Logo de la Empresa
                        if (!File.Exists(RutaImagen))
                        {
                            RutaImagen = ReaderHelper.RevisarLogo(RutaImagen, Properties.Resources.interrogacion);
                        }

                        //Lado Derecho
                        PdfPCell CeldaImagen = null;

                        if (File.Exists(RutaImagen))
                        {
                            //CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 180f, 1, "S", 1));
                            System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                            CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 3f, 170f, 40f, 1, 1, "S", 1f));
                            Img = null;
                        }
                        else
                        {
                            CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1));
                        }

                        CeldaImagen.Rowspan = 2;
                        table.AddCell(CeldaImagen);

                        //Lado Izquierdo
                        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 0, 4, "S", "N", "S", "N", 1));
                        table.AddCell(ReaderHelper.NuevaCelda(Fechas, null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 3, 0, "N", "S", "S", "N", 1));
                        table.CompleteRow(); //Fila completada

                        //Espacio en Blanco
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                        docPdf.Add(table);

                        //Obteniendo una lista temporal para la cabecera...
                        List<CtaCteE> oListaCabeceras = oListaCtaCte.GroupBy(x => x.idPersona).Select(g => g.First()).ToList();

                        //Sub Titulos
                        foreach (CtaCteE itemCab in oListaCabeceras)
                        {
                            #region Subtitulos

                            PdfPTable TablaSubTitulos = new PdfPTable(4);
                            TablaSubTitulos.WidthPercentage = 100;
                            TablaSubTitulos.SetWidths(new float[] { 0.1f, 0.7f, 0.1f, 0.1f });

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("CLIENTE: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.RazonSocial, null, "N", null, LetraNormal));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("RUC: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.RUC, null, "N", null, LetraNormal));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("DIRECCION: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.Direccion, null, "N", null, LetraNormal, -1, -1, "S4"));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            docPdf.Add(TablaSubTitulos); //Añadiendo la tabla al documento PDF...
                            TablaSubTitulos = null;

                            #endregion

                            //Detalle
                            ListaCtaCteTmp = oListaCtaCte.Where(x => x.idPersona == itemCab.idPersona).ToList();
                            PdfPTable TablaDetalle = new PdfPTable(11);
                            TablaDetalle.SetWidths(CabeceraDetalle);
                            TablaDetalle.WidthPercentage = 100;

                            //Cabecera del Detalle
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Operación", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Registro", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Fec.Mov", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TD.Mov", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Ser.Mov", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Núm.Mov", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Mon.", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Cargo", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Abono", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Saldo", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.CompleteRow();

                            Decimal Abono = 0;
                            Decimal Cargo = 0;

                            if (ListaCtaCteTmp.Count > 0)
                            {
                                Abono = 0;
                                Cargo = 0;

                                foreach (CtaCteE item in ListaCtaCteTmp)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaCancelacion.ToString("dd/MM/yyyy"), null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaRegistro.Value.ToString("dd/MM/yyyy"), null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaMovimiento.Value.ToString("dd/MM/yyyy"), null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoMov, null, "S", null, FuenteDetalle));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.SerieMov, null, "S", null, FuenteDetalle));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.NumeroMov, null, "S", null, FuenteDetalle));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.TipoCambio.ToString("N3"), null, "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cargo.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Abono.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Saldo.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.CompleteRow();

                                    Cargo += item.Cargo;
                                    Abono += item.Abono;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S7"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL ", color, "S", null, FuenteDetalle, 5, 1, "S2"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Cargo.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Abono.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.CompleteRow();

                                //Fila en blanco
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S11"));
                                TablaDetalle.CompleteRow();
                            }

                            docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF
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
                    else
                    {
                        RutaTemp = "";
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

        void ExportarExcel(String Ruta, Int32 idSistema)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String subTitulo = String.Empty;
            DateTime Inicio = dtpFecIni.Value.Date;

            switch (TipoReporte)
            {
                case 1:
                    if (chkHistorico.Checked == true)
                    {
                        TituloGeneral = "CTA.CORRIENTE DETALLADA (Historico)";
                    }
                    else
                    {
                        TituloGeneral = "CTA.CORRIENTE DETALLADA";
                    }
                    NombrePestaña = "Detallado";
                    break;
                case 2:
                    TituloGeneral = "RESUMEN - CUENTAS POR COBRAR";
                    NombrePestaña = "Resumen";
                    break;
                case 3:
                    TituloGeneral = "CONTROL DE LETRAS POR COBRAR";
                    NombrePestaña = "Ctrl.Letras";
                    break;
                default:
                    TituloGeneral = "CUENTA CORRIENTE DETALLADO POR DOCUMENTO";
                    NombrePestaña = "Detallado";
                    break;
            }

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);
                subTitulo = "(Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + ")";

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 0;
                    List<CtaCteE> ListaCtaCteTmp = null;
                    String Ruc = VariablesLocales.SesionUsuario.Empresa.RUC;

                    //Todo Genesis
                    if (Ruc == "20502647009" || Ruc == "20523020561" || Ruc == "20517933318" || Ruc == "20552695217" || Ruc == "20552186681" || Ruc == "20552690410" || Ruc == "20513078952" || Ruc == "20601712513" || Ruc == "20553661529")
                    {
                        TotColumnas = 16;
                    }
                    else
                    {
                        TotColumnas = 12;
                    }

                    #region Titulos Principales

                    //Alto de las filas
                    oHoja.Row(1).Height = 20;
                    oHoja.Row(2).Height = 20;
                    oHoja.Row(4).Height = 18;

                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 17, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    oHoja.Cells["A2"].Value = subTitulo;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    #endregion

                    //Logo de la Empresa
                    if (File.Exists(RutaImagen))
                    {
                        VariablesLocales.ImagenExcel(oHoja, 0, 0, RutaImagen);
                    }

                    if (TipoReporte == 1)
                    {
                        //Ancho de las columnas
                        oHoja.Column(1).Width = 11;
                        oHoja.Column(2).Width = 11;
                        oHoja.Column(3).Width = 8;
                        oHoja.Column(4).Width = 12;
                        oHoja.Column(5).Width = 11;
                        oHoja.Column(6).Width = 11;
                        oHoja.Column(7).Width = 10.5;
                        oHoja.Column(8).Width = 10.5;
                        oHoja.Column(9).Width = 10.5;
                        oHoja.Column(10).Width = 10.5;
                        oHoja.Column(11).Width = 10.5;
                        oHoja.Column(12).Width = 10.5;
                        oHoja.Column(13).Width = 12;
                        oHoja.Column(14).Width = 10;
                        oHoja.Column(15).Width = 12;
                        oHoja.Column(16).Width = 15;
                        oHoja.Column(17).Width = 10;
                        oHoja.Column(18).Width = 15;

                        //Obteniendo una lista temporal para la cabecera...
                        List<CtaCteE> oListaCabeceras = oListaCtaCte.GroupBy(x => x.idPersona).Select(g => g.First()).ToList();

                        foreach (CtaCteE itemCab in oListaCabeceras)
                        {
                            #region Subtitulos

                            TotColumnas = 4;

                            oHoja.Cells[InicioLinea, 1].Value = (idSistema == 2 ? "CLIENTE: " : "PROVEEDOR: ");
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 2].Value = itemCab.RazonSocial;
                            oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));
                            oHoja.Cells[InicioLinea, 9].Value = "RUC: ";
                            oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 10].Value = itemCab.RUC;
                            oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));
                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1].Value = "DIRECCION: ";
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 2].Value = itemCab.Direccion;
                            oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));
                            InicioLinea++;

                            InicioLinea++;

                            #endregion

                            #region Detalle

                            ListaCtaCteTmp = oListaCtaCte.Where(x => x.idPersona == itemCab.idPersona).ToList();
                            TotColumnas = (idSistema == 2 ? 18 : 12);

                            //Cabecera del Detalle
                            oHoja.Cells[InicioLinea, 1].Value = "Fecha Mov.";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            oHoja.Cells[InicioLinea, 2].Value = "T.D.";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea + 1, 2])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            oHoja.Cells[InicioLinea, 3].Value = "SERIE";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea + 1, 3])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            oHoja.Cells[InicioLinea, 4].Value = "NUMERO";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 4, InicioLinea + 1, 4])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            oHoja.Cells[InicioLinea, 5].Value = "EMIS.";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea + 1, 5])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            oHoja.Cells[InicioLinea, 6].Value = "VCMT.";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            oHoja.Cells[InicioLinea, 7].Value = "SOLES";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea, 9])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            oHoja.Cells[InicioLinea, 10].Value = "DOLARES";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 10, InicioLinea, 12])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            if (idSistema == 2)
                            {
                                oHoja.Cells[InicioLinea, 13].Value = "N° UNICO";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 13, InicioLinea + 1, 13])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }

                                oHoja.Cells[InicioLinea, 14].Value = "DIAS MORA";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 14, InicioLinea + 1, 14])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }

                                oHoja.Cells[InicioLinea, 15].Value = "DEPOS.";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 15, InicioLinea + 1, 15])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }

                                oHoja.Cells[InicioLinea, 16].Value = "BANCO";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 16, InicioLinea + 1, 16])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }

                                oHoja.Cells[InicioLinea, 17].Value = "ESTADO";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 17, InicioLinea + 1, 17])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }

                                oHoja.Cells[InicioLinea, 18].Value = "VENDEDOR";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 18, InicioLinea + 1, 18])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }

                                InicioLinea++;
                                oHoja.Cells[InicioLinea, 7].Value = "CARGO";
                                oHoja.Cells[InicioLinea, 8].Value = "ABONO";
                                oHoja.Cells[InicioLinea, 9].Value = "SALDO";
                                oHoja.Cells[InicioLinea, 10].Value = "CARGO";
                                oHoja.Cells[InicioLinea, 11].Value = "ABONO";
                                oHoja.Cells[InicioLinea, 12].Value = "SALDO";

                                for (int i = 1; i <= TotColumnas; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                }

                                InicioLinea++;
                            }
                            else
                            {
                                for (int i = 1; i <= TotColumnas; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                }

                                InicioLinea++;
                                oHoja.Cells[InicioLinea, 7].Value = "CARGO";
                                oHoja.Cells[InicioLinea, 8].Value = "ABONO";
                                oHoja.Cells[InicioLinea, 9].Value = "SALDO";
                                oHoja.Cells[InicioLinea, 10].Value = "BANCO";
                                oHoja.Cells[InicioLinea, 11].Value = "ABONO";
                                oHoja.Cells[InicioLinea, 12].Value = "SALDO";

                                for (int i = 1; i <= TotColumnas; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                }

                                InicioLinea++;
                            }

                            Decimal AbonoS = 0;
                            Decimal CargoS = 0;
                            Decimal SaldoS = 0;
                            Decimal AbonoD = 0;
                            Decimal CargoD = 0;
                            Decimal SaldoD = 0;

                            if (ListaCtaCteTmp.Count > 0)
                            {
                                AbonoS = 0;
                                CargoS = 0;
                                SaldoS = 0;
                                AbonoD = 0;
                                CargoD = 0;
                                SaldoD = 0;

                                foreach (CtaCteE item in ListaCtaCteTmp)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.FechaMovimiento.Value.ToString("dd/MM/yy");
                                    oHoja.Cells[InicioLinea, 2].Value = item.idDocumentoMov;
                                    oHoja.Cells[InicioLinea, 3].Value = item.SerieMov;
                                    oHoja.Cells[InicioLinea, 4].Value = item.NumeroMov;
                                    oHoja.Cells[InicioLinea, 5].Value = item.FechaDocumento.ToString("dd/MM/yy");
                                    oHoja.Cells[InicioLinea, 6].Value = item.FechaVencimiento.Value.ToString("dd/MM/yy");
                                    oHoja.Cells[InicioLinea, 7].Value = item.Cargo;
                                    oHoja.Cells[InicioLinea, 8].Value = item.Abono;
                                    oHoja.Cells[InicioLinea, 9].Value = item.Saldo;
                                    oHoja.Cells[InicioLinea, 10].Value = item.CargoD;
                                    oHoja.Cells[InicioLinea, 11].Value = item.AbonoD;
                                    oHoja.Cells[InicioLinea, 12].Value = item.SaldoD;

                                    oHoja.Cells[InicioLinea, 7, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                                    if (idSistema == 2)
                                    {
                                        oHoja.Cells[InicioLinea, 13].Value = item.nroUnico;
                                        oHoja.Cells[InicioLinea, 14].Value = item.DiasMora.ToString();
                                        oHoja.Cells[InicioLinea, 15].Value = item.tipDeposito;
                                        oHoja.Cells[InicioLinea, 16].Value = item.desBanco;
                                        oHoja.Cells[InicioLinea, 17].Value = item.EstadoDoc;
                                        oHoja.Cells[InicioLinea, 18].Value = item.nomVendedor;

                                        oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    }

                                    for (int i = 1; i <= TotColumnas; i++)
                                    {
                                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                        if (item.TipoAC == "C")
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 230, 153));
                                        }

                                        if (item.TipoAC == "A")
                                        {
                                            if (item.Abono > 0)
                                            {
                                                if (i == 8)
                                                {
                                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));
                                                }
                                            }

                                            if (item.AbonoD > 0)
                                            {
                                                if (i == 11)
                                                {
                                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(198, 224, 180));
                                                }
                                            }
                                        }
                                    }

                                    InicioLinea++;

                                    CargoS += item.Cargo;
                                    AbonoS += item.Abono;
                                    CargoD += item.CargoD;
                                    AbonoD += item.AbonoD;
                                }

                                InicioLinea++;

                                SaldoS = CargoS - AbonoS;
                                SaldoD = CargoD - AbonoD;

                                //Totales
                                oHoja.Cells[InicioLinea, 1].Value = " ";
                                oHoja.Cells[InicioLinea, 2].Value = " ";
                                oHoja.Cells[InicioLinea, 3].Value = "TOTAL CLIENTE";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                }

                                oHoja.Cells[InicioLinea, 7].Value = CargoS;
                                oHoja.Cells[InicioLinea, 8].Value = AbonoS;
                                oHoja.Cells[InicioLinea, 9].Value = SaldoS;
                                oHoja.Cells[InicioLinea, 10].Value = CargoD;
                                oHoja.Cells[InicioLinea, 11].Value = AbonoD;
                                oHoja.Cells[InicioLinea, 12].Value = SaldoD;

                                oHoja.Cells[InicioLinea, 7, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                                if (idSistema == 2)
                                {
                                    oHoja.Cells[InicioLinea, 13].Value = " ";
                                    oHoja.Cells[InicioLinea, 14].Value = " ";
                                    oHoja.Cells[InicioLinea, 15].Value = " ";
                                    oHoja.Cells[InicioLinea, 16].Value = " ";
                                    oHoja.Cells[InicioLinea, 17].Value = " ";
                                    oHoja.Cells[InicioLinea, 18].Value = " ";
                                }

                                for (int i = 3; i <= 12; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                }

                                InicioLinea++;
                                InicioLinea++;
                            }

                            #endregion
                        }

                        oHoja.Cells[InicioLinea, 3].Value = " TOTAL GENERAL ";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 7].Value = oListaCtaCte.Sum(x => x.Cargo);
                        oHoja.Cells[InicioLinea, 8].Value = oListaCtaCte.Sum(x => x.Abono);
                        oHoja.Cells[InicioLinea, 9].Value = oListaCtaCte.Sum(x => x.Saldo);
                        oHoja.Cells[InicioLinea, 10].Value = oListaCtaCte.Sum(x => x.CargoD);
                        oHoja.Cells[InicioLinea, 11].Value = oListaCtaCte.Sum(x => x.AbonoD);
                        oHoja.Cells[InicioLinea, 12].Value = oListaCtaCte.Sum(x => x.SaldoD);

                        oHoja.Cells[InicioLinea, 7, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                        if (idSistema == 2)
                        {
                            oHoja.Cells[InicioLinea, 13].Value = " ";
                            oHoja.Cells[InicioLinea, 14].Value = " ";
                            oHoja.Cells[InicioLinea, 15].Value = " ";
                            oHoja.Cells[InicioLinea, 16].Value = " ";
                            oHoja.Cells[InicioLinea, 17].Value = " ";
                        }

                        for (int i = 3; i <= 12; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        InicioLinea++;
                    }
                    else if (TipoReporte == 2)
                    {
                        TotColumnas = 17;
                        oHoja.Cells[InicioLinea, 1].Value = "SUCURSAL";
                        oHoja.Cells[InicioLinea, 2].Value = "RUC/DNI";
                        oHoja.Cells[InicioLinea, 3].Value = "CLIENTE";
                        oHoja.Cells[InicioLinea, 4].Value = "T/D";
                        oHoja.Cells[InicioLinea, 5].Value = "SERIE";
                        oHoja.Cells[InicioLinea, 6].Value = "N°DOCUM.";
                        oHoja.Cells[InicioLinea, 7].Value = "FECHA";
                        oHoja.Cells[InicioLinea, 8].Value = "VENC.";
                        oHoja.Cells[InicioLinea, 9].Value = "DIAS MORA";
                        oHoja.Cells[InicioLinea, 10].Value = "MON.";
                        oHoja.Cells[InicioLinea, 11].Value = "IMPORTE";
                        oHoja.Cells[InicioLinea, 12].Value = "SALDO SOL.";
                        oHoja.Cells[InicioLinea, 13].Value = "SALDO DOL.";
                        oHoja.Cells[InicioLinea, 14].Value = "N°PEDIDO";
                        oHoja.Cells[InicioLinea, 15].Value = "VENDEDOR";
                        oHoja.Cells[InicioLinea, 16].Value = "COND.VENTA";
                        oHoja.Cells[InicioLinea, 17].Value = "ESPECIE";

                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        InicioLinea++;


                        Decimal saldosol = 0;
                        Decimal saldodol = 0;
                        foreach (CtaCteE item in oListaCtaCte)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.desLocal;
                            oHoja.Cells[InicioLinea, 2].Value = item.RUC;
                            oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 4].Value = item.idDocumento;
                            oHoja.Cells[InicioLinea, 5].Value = item.numSerie;
                            oHoja.Cells[InicioLinea, 6].Value = item.numDocumento;
                            oHoja.Cells[InicioLinea, 7].Value = item.FechaDocumento;
                            oHoja.Cells[InicioLinea, 8].Value = item.FechaVencimiento;
                            oHoja.Cells[InicioLinea, 9].Value = item.DiasMora;
                            oHoja.Cells[InicioLinea, 10].Value = item.desMoneda;
                            oHoja.Cells[InicioLinea, 11].Value = item.Importe;
                            if (item.idMoneda == Variables.Soles)
                            {
                                oHoja.Cells[InicioLinea, 12].Value = item.Saldo;
                                saldosol += item.Saldo;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 12].Value = "0.00";
                            }

                            if (item.idMoneda == Variables.Dolares)
                            {
                                oHoja.Cells[InicioLinea, 13].Value = item.Saldo;
                                saldodol += item.Saldo;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 13].Value = "0.00";
                            }



                            oHoja.Cells[InicioLinea, 14].Value = item.codPedido;
                            oHoja.Cells[InicioLinea, 15].Value = item.nomVendedor;
                            oHoja.Cells[InicioLinea, 16].Value = item.desCondicion;
                            oHoja.Cells[InicioLinea, 17].Value = item.Especie;

                            for (int i = 1; i <= TotColumnas; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f));
                                oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                if (i == 4 || i == 7 || i == 8 || i == 10 || i == 14)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                }

                                if (i == 7 || i == 8)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "dd/MM/yyyy";
                                }

                                if (i == 12 || i == 13)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                                }
                            }

                            InicioLinea++;
                        }
                        oHoja.Cells[InicioLinea, 12].Value = saldosol;
                        oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 13].Value = saldodol;
                        oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;

                        //Ajustando el ancho de las columnas automaticamente
                        oHoja.Cells.AutoFitColumns();
                    }
                    else if (TipoReporte == 3)
                    {
                        TotColumnas = 14;
 
                        oHoja.Cells[InicioLinea, 1].Value = "SUCURSAL";
                        oHoja.Cells[InicioLinea, 2].Value = "RUC/DNI";
                        oHoja.Cells[InicioLinea, 3].Value = "CLIENTE";
                        oHoja.Cells[InicioLinea, 4].Value = "N°Letra";
                        oHoja.Cells[InicioLinea, 5].Value = "REF. DOCUM.";
                        oHoja.Cells[InicioLinea, 6].Value = "FECHA";
                        oHoja.Cells[InicioLinea, 7].Value = "F.VENC.";
                        oHoja.Cells[InicioLinea, 8].Value = "DIAS X VENCER";
                        oHoja.Cells[InicioLinea, 9].Value = "MONEDA";
                        oHoja.Cells[InicioLinea, 10].Value = "IMPORTE";
                        oHoja.Cells[InicioLinea, 11].Value = "STATUS";
                        oHoja.Cells[InicioLinea, 12].Value = "BANCO";
                        oHoja.Cells[InicioLinea, 13].Value = "N°UNICO";
                        oHoja.Cells[InicioLinea, 14].Value = "F.PAGO";

                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        InicioLinea++;

                        foreach (CtaCteE item in oListaCtaCte)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.desLocal;
                            oHoja.Cells[InicioLinea, 2].Value = item.RUC;
                            oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 4].Value = item.numDocumento;
                            oHoja.Cells[InicioLinea, 5].Value = item.DocReferencia;
                            oHoja.Cells[InicioLinea, 6].Value = item.FechaDocumento;
                            oHoja.Cells[InicioLinea, 7].Value = item.FechaVencimiento;
                            oHoja.Cells[InicioLinea, 8].Value = item.DiasMora;
                            oHoja.Cells[InicioLinea, 9].Value = item.desMoneda;
                            oHoja.Cells[InicioLinea, 10].Value = item.Importe;
                            oHoja.Cells[InicioLinea, 11].Value = item.Estatus;
                            oHoja.Cells[InicioLinea, 12].Value = item.desBanco;
                            oHoja.Cells[InicioLinea, 13].Value = item.nroUnico;
                            oHoja.Cells[InicioLinea, 14].Value = "";

                            for (int i = 1; i <= TotColumnas; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f));
                                oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                if (i == 6 || i == 7 || i == 9)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                }

                                if (i == 6 || i == 7)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "dd/MM/yyyy";
                                }

                                if (i == 10)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                                }
                            }

                            InicioLinea++;
                        }

                        //Ajustando el ancho de las columnas automaticamente
                        oHoja.Cells.AutoFitColumns();
                    }

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
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
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        void ExportarExcel2(String Ruta, Int32 idSistema)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            DateTime Inicio = dtpFecIni.Value.Date;

            TituloGeneral = "CUENTA CORRIENTE DETALLADO ";
            NombrePestaña = "Cuenta Corriente";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = (idSistema == 2 ? 16 : 11);
                    List<CtaCteE> ListaCtaCteTmp = null;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 145));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 16, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(191, 191, 191));
                    }

                    #endregion

                    if (TipoReporte == 4)
                    {
                        //Obteniendo una lista temporal para la cabecera...
                        List<CtaCteE> oListaCabeceras = oListaCtaCte.GroupBy(x => x.idPersona).Select(g => g.First()).ToList();

                        foreach (CtaCteE itemCab in oListaCabeceras)
                        {
                            #region Subtitulos

                            oHoja.Cells[InicioLinea, 1].Value = (idSistema == 2 ? "CLIENTE: " : "PROVEEDOR: ");
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 2].Value = itemCab.RazonSocial;
                            oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 9].Value = "RUC: " + itemCab.RUC;
                            oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1].Value = "DIRECCION: ";
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 2].Value = itemCab.Direccion;
                            oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8f, FontStyle.Bold));
                            InicioLinea++;
                            InicioLinea++;

                            #endregion

                            #region Detalle

                            ListaCtaCteTmp = oListaCtaCte.Where(x => x.idPersona == itemCab.idPersona).ToList();

                            String PasoDet = "S";

                            if (ListaCtaCteTmp.Count > 0)
                            {
                                foreach (CtaCteE item in ListaCtaCteTmp)
                                {
                                    if (item.TipoAC == "C")
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = "Sucursal";
                                        oHoja.Cells[InicioLinea, 2].Value = "N° Pedido";
                                        oHoja.Cells[InicioLinea, 3, InicioLinea, 5].Merge = true;
                                        oHoja.Cells[InicioLinea, 3].Value = "Motivo";
                                        oHoja.Cells[InicioLinea, 6].Value = "T.D.";
                                        oHoja.Cells[InicioLinea, 7].Value = "Serie";
                                        oHoja.Cells[InicioLinea, 8].Value = "Número";
                                        oHoja.Cells[InicioLinea, 9].Value = "Emis.";
                                        oHoja.Cells[InicioLinea, 10].Value = "Vcmto.";
                                        oHoja.Cells[InicioLinea, 11].Value = "Mon.";
                                        oHoja.Cells[InicioLinea, 12].Value = "Condición Pago";
                                        oHoja.Cells[InicioLinea, 13].Value = "Ti.Ca.";
                                        oHoja.Cells[InicioLinea, 14].Value = "Cargo";
                                        oHoja.Cells[InicioLinea, 15].Value = "Abono";
                                        oHoja.Cells[InicioLinea, 16].Value = "Detracción";

                                        for (int i = 1; i <= TotColumnas; i++)
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7f, FontStyle.Bold));
                                            oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.White);
                                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 112, 192));
                                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                        }

                                        InicioLinea++;

                                        oHoja.Cells[InicioLinea, 1].Value = item.desLocal;
                                        oHoja.Cells[InicioLinea, 2].Value = item.codPedido;
                                        oHoja.Cells[InicioLinea, 3, InicioLinea, 5].Merge = true;
                                        oHoja.Cells[InicioLinea, 3].Value = item.Motivo;
                                        oHoja.Cells[InicioLinea, 6].Value = item.idDocumentoMov;
                                        oHoja.Cells[InicioLinea, 7].Value = item.SerieMov;
                                        oHoja.Cells[InicioLinea, 8].Value = item.NumeroMov;
                                        oHoja.Cells[InicioLinea, 9].Value = item.FechaDocumento;
                                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[InicioLinea, 10].Value = item.FechaVencimiento.Value;
                                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[InicioLinea, 11].Value = item.desMoneda;
                                        oHoja.Cells[InicioLinea, 12].Value = item.desCondicion;
                                        oHoja.Cells[InicioLinea, 13].Value = item.TipoCambio;
                                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "##0.000";
                                        oHoja.Cells[InicioLinea, 14].Value = item.Cargo;
                                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                        oHoja.Cells[InicioLinea, 15].Value = 0;
                                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                        oHoja.Cells[InicioLinea, 16].Value = item.TieneDetra == true ? "SI" : "NO";

                                        PasoDet = "S";

                                        for (int i = 1; i <= TotColumnas; i++)
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7f, FontStyle.Bold));
                                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                        }
                                    }
                                    else
                                    {
                                        if (PasoDet == "S")
                                        {
                                            oHoja.Cells[InicioLinea, 1].Value = "Sucursal";
                                            oHoja.Cells[InicioLinea, 2].Value = "N° Ingreso";
                                            oHoja.Cells[InicioLinea, 3].Value = "T.D.";
                                            oHoja.Cells[InicioLinea, 4].Value = "Serie";
                                            oHoja.Cells[InicioLinea, 5].Value = "Número";
                                            oHoja.Cells[InicioLinea, 6, InicioLinea, 8].Merge = true;
                                            oHoja.Cells[InicioLinea, 6].Value = "Forma de Pago";
                                            oHoja.Cells[InicioLinea, 9].Value = "Fec.Oper.";
                                            oHoja.Cells[InicioLinea, 10].Value = "Nro.Operación";
                                            oHoja.Cells[InicioLinea, 11].Value = "Mon.";
                                            oHoja.Cells[InicioLinea, 12].Value = "Cuenta Bancaria";
                                            oHoja.Cells[InicioLinea, 13].Value = "Ti.Ca.";
                                            oHoja.Cells[InicioLinea, 14].Value = "Cargo";
                                            oHoja.Cells[InicioLinea, 15].Value = "Abono";
                                            oHoja.Cells[InicioLinea, 16].Value = "Monto Recibido";

                                            PasoDet = "N";

                                            for (int i = 1; i <= TotColumnas; i++)
                                            {
                                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7f, FontStyle.Bold));
                                                oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(146, 208, 80)); //Verde claro
                                                oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                            }

                                            InicioLinea++;
                                        }

                                        oHoja.Cells[InicioLinea, 1].Value = item.desLocal;
                                        oHoja.Cells[InicioLinea, 2].Value = item.nroUnico;
                                        oHoja.Cells[InicioLinea, 3].Value = item.idDocumentoMov;
                                        oHoja.Cells[InicioLinea, 4].Value = item.SerieMov;
                                        oHoja.Cells[InicioLinea, 5].Value = item.NumeroMov;
                                        oHoja.Cells[InicioLinea, 6, InicioLinea, 8].Merge = true;
                                        oHoja.Cells[InicioLinea, 6].Value = item.desFormaPago;
                                        oHoja.Cells[InicioLinea, 9].Value = item.FechaMovimiento.Value;
                                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "dd/MM/yyyy";
                                        oHoja.Cells[InicioLinea, 10].Value = String.IsNullOrWhiteSpace(item.numLetras) ? item.NroOperacion : item.numLetras;
                                        oHoja.Cells[InicioLinea, 11].Value = item.desMonedaRecibida;
                                        oHoja.Cells[InicioLinea, 12].Value = item.desBanco;
                                        oHoja.Cells[InicioLinea, 13].Value = item.TipoCambio;
                                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "##0.000";
                                        oHoja.Cells[InicioLinea, 14].Value = 0;
                                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                        oHoja.Cells[InicioLinea, 15].Value = item.Abono;
                                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                        oHoja.Cells[InicioLinea, 16].Value = item.MontoRecibido;
                                        oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";

                                        for (int i = 1; i <= TotColumnas; i++)
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7f));
                                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                        }
                                    }

                                    InicioLinea++;
                                }

                                InicioLinea++;
                            }

                            #endregion
                        }

                        InicioLinea++;
                    }

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();
                    oHoja.Column(2).Width = 12;
                    oHoja.Column(9).Width = 9;

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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
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

        void MostrarReporte(Int32 idSistema)
        {
            #region Variables

            if (chbVen.Checked == false)
            {
                oListaCtaCte = null;
                oListaCtaCte = ListaFilt;
            }       
            
            Document docPdf = new Document((TipoReporte == 1 ? PageSize.A4 : PageSize.A4.Rotate()), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = String.Empty;
            String Extension = ".pdf";
            String TituloGeneral = String.Empty;
            String Fechas = String.Empty;
            iTextSharp.text.Font LetraNegrita = FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font LetraNormal = FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font FuenteCabecera = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font FuenteDetalle = FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL);
            float[] cabAnchoDetVentas = new float[] { 0.05f, 0.02f, 0.033f, 0.06f, 0.048f, 0.048f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.06f, 0.03f, 0.05f, 0.04f, 0.04f, 0.06f };
            float[] cabAnchoDetCompras = new float[] { 0.05f, 0.02f, 0.035f, 0.06f, 0.048f, 0.048f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f };
            BaseColor color = new BaseColor(Color.Silver);
            BaseColor ColorCeldaS = new BaseColor(189, 215, 238);
            BaseColor ColorCeldaD = new BaseColor(198, 224, 180);
            BaseColor ColorCargos = new BaseColor(255, 230, 153);
            List<CtaCteE> ListaCtaCteTmp = null; 

            #endregion

            RutaTemp = @"C:\AmazonErp\ArchivosTemporales";

            if (!Directory.Exists(RutaTemp))
            {
                Directory.CreateDirectory(RutaTemp);
            }

            docPdf.AddCreationDate();
            docPdf.AddAuthor("AMAZONTIC SAC");
            docPdf.AddCreator("AMAZONTIC SAC");

            String TipoCta;
            TipoCta = idSistema == 2 ? "COBRAR " : "PAGAR ";

            if (TipoReporte == 1)
            {
                if (rbPorDocumentos.Checked)
                {
                    NombreReporte = @"\Reporte CtaCte " + Aleatorio.ToString();
                    TituloGeneral = "CUENTA CORRIENTE RESUMIDA";
                    Fechas = "(Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + ")";
                }
                else
                {
                    NombreReporte = @"\Reporte CtaCte Detallado " + Aleatorio.ToString();
                    if (chkHistorico.Checked == true)
                    {
                        TituloGeneral = "CTA.CORRIENTE DETALLADA (Historico)";
                    }
                    else
                    {
                        TituloGeneral = "CTA.CORRIENTE DETALLADA";
                    }

                    Fechas = "(Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + ")";
                }
            }
            else if (TipoReporte == 2)
            {            
                NombreReporte = @"\Resumen Ctas Por " + TipoCta + Aleatorio.ToString();
                TituloGeneral = "RESUMEN - CUENTAS POR " + TipoCta;
                Fechas = "(Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + ")";
            }
            else if (TipoReporte == 3)
            {
                NombreReporte = @"\Reporte Control de letras por " + TipoCta + Aleatorio.ToString();
                TituloGeneral = "REPORTE - CONTROL DE LETRAS POR "+TipoCta;
                Fechas = "(Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + ")";
            }

            if (!String.IsNullOrWhiteSpace(RutaTemp.Trim()))
            {
                //Creacion del archivo pdf
                RutaTemp += NombreReporte + Extension;

                if (File.Exists(RutaTemp))
                {
                    File.Delete(RutaTemp);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    oPdfw.PageEvent = new PagEncabezadoCtaCte();

                    docPdf.Open();

                    #region Cabecera del Reporte

                    PdfPTable table = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    table.SetWidths(new float[] { 0.35f, 0.65f });
                    table.HorizontalAlignment = Element.ALIGN_LEFT;

                    //Logo de la Empresa
                    if (!File.Exists(RutaImagen))
                    {
                        RutaImagen = ReaderHelper.RevisarLogo(RutaImagen, Properties.Resources.interrogacion);
                    }

                    //Lado Derecho
                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        //CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 180f, 1, "S", 1));
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 3f, 170f, 40f, 1, 1, "S", 1f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    CeldaImagen.Rowspan = 2;
                    table.AddCell(CeldaImagen);

                    //Lado Izquierdo
                    table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 0, 4, "S", "N", "S", "N", 1));
                    table.AddCell(ReaderHelper.NuevaCelda(Fechas, null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 3, 0, "N", "S", "S", "N", 1));
                    table.CompleteRow(); //Fila completada

                    //Espacio en Blanco
                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    docPdf.Add(table);

                    #endregion

                    if (TipoReporte == 1)
                    {
                        //Obteniendo una lista temporal para la cabecera...
                        List<CtaCteE> oListaCabeceras = oListaCtaCte.GroupBy(x => x.idPersona).Select(g => g.First()).ToList();

                        //Recorriendo la Lista temporal de Clientes
                        foreach (CtaCteE itemCab in oListaCabeceras)
                        {
                            #region Subtitulos

                            PdfPTable TablaSubTitulos = new PdfPTable(4)
                            {
                                WidthPercentage = 100
                            };

                            TablaSubTitulos.SetWidths(new float[] { 0.1f, 0.7f, 0.1f, 0.1f });

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(idSistema == 2 ? "CLIENTE: " : "PROVEEDOR: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.RazonSocial, null, "N", null, LetraNormal));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("RUC: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.RUC, null, "N", null, LetraNormal));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("DIRECCION: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.Direccion, null, "N", null, LetraNormal, -1, -1, "S4"));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            docPdf.Add(TablaSubTitulos); //Añadiendo la tabla al documento PDF...
                            TablaSubTitulos = null;

                            #endregion

                            #region Detalle

                            ListaCtaCteTmp = oListaCtaCte.Where(x => x.idPersona == itemCab.idPersona).ToList();


                            PdfPTable TablaDetalle = new PdfPTable(idSistema == 2 ? 18 : 12);
                            TablaDetalle.SetWidths(idSistema == 2 ? cabAnchoDetVentas : cabAnchoDetCompras);
                            TablaDetalle.WidthPercentage = 100;



                            //Cabecera del Detalle                            
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Fecha Mov.", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("T.D.", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("SERIE", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("NUMERO", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("VCMT.", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("SOLES", color, "S", null, FuenteCabecera, 5, 1, "S3"));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DOLARES", color, "S", null, FuenteCabecera, 5, 1, "S3"));

                            if (idSistema == 2)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("N° UNICO", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DIAS MORA", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("DEPOS.", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("BANCO", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("ESTADO", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("VENDEDOR", color, "S", null, FuenteCabecera, 5, 1, "N", "S2"));
                                TablaDetalle.CompleteRow();
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("CARGO", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("ABONO", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("CARGO", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("ABONO", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO", color, "S", null, FuenteCabecera, 5, 1));
                            TablaDetalle.CompleteRow();

                            Decimal AbonoS = 0;
                            Decimal CargoS = 0;
                            Decimal SaldoS = 0;
                            Decimal AbonoD = 0;
                            Decimal CargoD = 0;
                            Decimal SaldoD = 0;

                            if (ListaCtaCteTmp.Count > 0)
                            {
                                AbonoS = 0;
                                CargoS = 0;
                                SaldoS = 0;
                                AbonoD = 0;
                                CargoD = 0;
                                SaldoD = 0;

                                foreach (CtaCteE item in ListaCtaCteTmp)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaMovimiento.Value.ToString("dd/MM/yy"), (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoMov, (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.SerieMov, (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.NumeroMov, (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.ToString("dd/MM/yy"), (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaVencimiento.Value.ToString("dd/MM/yy"), (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cargo.ToString("N2"), (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Abono.ToString("N2"), (item.TipoAC == "A" ? (item.Abono > 0 ? ColorCeldaS : null) : ColorCargos), "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Saldo.ToString("N2"), (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.CargoD.ToString("N2"), (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.AbonoD.ToString("N2"), (item.TipoAC == "A" ? (item.AbonoD > 0 ? ColorCeldaD : null) : ColorCargos), "S", null, FuenteDetalle, 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.SaldoD.ToString("N2"), (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 2));

                                    if (idSistema == 2)
                                    {
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nroUnico, (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.DiasMora.ToString(), (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipDeposito, (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desBanco, (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.EstadoDoc, (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomVendedor, (item.TipoAC == "A" ? null : ColorCargos), "S", null, FuenteDetalle, 5, 1));
                                    }

                                    TablaDetalle.CompleteRow();

                                    CargoS += item.Cargo;
                                    AbonoS += item.Abono;
                                    CargoD += item.CargoD;
                                    AbonoD += item.AbonoD;
                                }

                                //Fila en blanco
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, (idSistema == 2 ? "S18" : "S12"), "N", 0, 0));
                                TablaDetalle.CompleteRow();

                                SaldoS = CargoS - AbonoS;
                                SaldoD = CargoD - AbonoD;

                                //Totales
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FuenteDetalle, 5, 1, "S3"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL CLIENTE", color, "S", null, FuenteDetalle, 5, 1, "S3"));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(CargoS.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(AbonoS.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(SaldoS.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(CargoD.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(AbonoD.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(SaldoD.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));

                                if (idSistema == 2)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FuenteDetalle, 5, 1, "S6"));
                                }

                                TablaDetalle.CompleteRow();

                                ////Fila en blanco
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 1.25f), 5, 1, (idSistema == 2 ? "S18" : "S12")));
                                TablaDetalle.CompleteRow();
                            }

                            #endregion

                            docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF
                        }

                        #region Total General

                        PdfPTable TablaTotales = new PdfPTable(idSistema == 2 ? 18 : 12);
                        TablaTotales.SetWidths(idSistema == 2 ? cabAnchoDetVentas : cabAnchoDetCompras);
                        TablaTotales.WidthPercentage = 100;

                        Decimal TAbonoS = 0;
                        Decimal TCargoS = 0;
                        Decimal TSaldoS = 0;
                        Decimal TAbonoD = 0;
                        Decimal TCargoD = 0;
                        Decimal TSaldoD = 0;

                        TCargoS = oListaCtaCte.Sum(x => x.Cargo);
                        TAbonoS = oListaCtaCte.Sum(x => x.Abono);

                        TCargoD = oListaCtaCte.Sum(x => x.CargoD);
                        TAbonoD = oListaCtaCte.Sum(x => x.AbonoD);

                        TSaldoS = TCargoS - TAbonoS;
                        TSaldoD = TCargoD - TAbonoD;

                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S3"));
                        TablaTotales.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL ", color, "S", null, FuenteCabecera, 5, 1, "S3"));
                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(TCargoS.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(TAbonoS.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));

                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(TSaldoS.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));

                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(TCargoD.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));
                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(TAbonoD.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));

                        TablaTotales.AddCell(ReaderHelper.NuevaCelda(TSaldoD.ToString("N2"), color, "S", null, FuenteDetalle, 5, 2));

                        if (idSistema == 2)
                        {
                            TablaTotales.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, "S6"));
                        }

                        TablaTotales.CompleteRow();

                        #endregion

                        docPdf.Add(TablaTotales);
                    }
                    else if (TipoReporte == 2)
                    {
                        Int32 totCol = 0;
                        float[] AnchoCol = null;
                        String Ruc = VariablesLocales.SesionUsuario.Empresa.RUC;

                        //Todo Genesis
                        if (Ruc == "20502647009" || Ruc == "20523020561" || Ruc == "20517933318" || Ruc == "20552695217" || Ruc == "20552186681" || Ruc == "20552690410" || Ruc == "20513078952" || Ruc == "20601712513" || Ruc == "20553661529")
                        {
                            totCol = 17;
                            AnchoCol = new float[] { 0.1f, 0.1f, 0.25f, 0.03f, 0.05f, 0.08f, 0.08f, 0.08f, 0.05f, 0.05f, 0.08f, 0.08f, 0.08f, 0.1f, 0.2f, 0.2f, 0.1f };
                        }
                        else //El resto
                        {
                            totCol = 16;
                            AnchoCol = new float[] { 0.1f, 0.1f, 0.25f, 0.03f, 0.05f, 0.08f, 0.08f, 0.08f, 0.05f, 0.05f, 0.08f, 0.08f, 0.08f, 0.1f, 0.2f, 0.2f };
                        }

                        PdfPTable TablaCabDetalle = new PdfPTable(totCol)
                        {
                            WidthPercentage = 100
                        };

                        TablaCabDetalle.SetWidths(AnchoCol);

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SUCURSAL", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RUC/DNI", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CLIENTE", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T/D", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SERIE", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N°DOCUM.", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VENC.", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DIAS MORA", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MONEDA", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IMPORTE", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO SOL.", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO DOL.", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N°PEDIDO", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VENDEDOR", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COND.VENTA", color, "S", null, FuenteCabecera, 5, 1));

                        if (totCol == 17)
                        {

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ESPECIE", color, "S", null, FuenteCabecera, 5, 1));
                        }

                        TablaCabDetalle.CompleteRow();

                        Decimal VarSoles = 0;
                        Decimal VarDol = 0;
                        Decimal VarCero = 0;

                        foreach (CtaCteE item in oListaCtaCte)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desLocal, null, "S", null, FuenteDetalle));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RUC, null, "S", null, FuenteDetalle));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FuenteDetalle));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numSerie, null, "S", null, FuenteDetalle, 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocumento, null, "S", null, FuenteDetalle, 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.ToString("d"), null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaVencimiento.Value.ToString("d"), null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DiasMora.ToString(), null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Importe.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                            if (item.idMoneda == Variables.Soles)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Saldo.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                VarSoles += item.Saldo;
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(VarCero.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                            }

                            if (item.idMoneda == Variables.Dolares)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Saldo.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                VarDol += item.Saldo;
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(VarCero.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                            }
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codPedido, null, "S", null, FuenteDetalle, 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomVendedor, null, "S", null, FuenteDetalle, 5, -1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCondicion, null, "S", null, FuenteDetalle, 5, 0));

                            if (totCol == 17)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Especie, null, "S", null, FuenteDetalle, 5, 0));
                            }

                            TablaCabDetalle.CompleteRow();
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FuenteDetalle, -1, -1, "S11"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(VarSoles.ToString("N2"), null, "S", null, FuenteDetalle,-1,2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(VarDol.ToString("N2"), null, "S", null, FuenteDetalle,-1,2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FuenteDetalle, -1, -1, "S4"));
                        TablaCabDetalle.CompleteRow();

                        docPdf.Add(TablaCabDetalle);
                    }
                    else if (TipoReporte == 3)
                    {
                        PdfPTable TablaCabDetalle = new PdfPTable(14)
                        {
                            WidthPercentage = 100
                        };

                        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.3f, 0.1f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f });

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SUCURSAL", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RUC/DNI", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CLIENTE", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N°Letra", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("REF. DOCUM.", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("EMISIÓN", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("F.VENCIMIENTO", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DIAS X VENCER", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MONEDA", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IMPORTE", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("STATUS", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("BANCO", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N°UNICO", color, "S", null, FuenteCabecera, 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("F.PAGO", color, "S", null, FuenteCabecera, 5, 1));

                        TablaCabDetalle.CompleteRow();

                        foreach (CtaCteE item in oListaCtaCte)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desLocal, null, "S", null, FuenteDetalle));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RUC, null, "S", null, FuenteDetalle));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "S", null, FuenteDetalle));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocumento, null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DocReferencia, null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.ToString("d"), null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaVencimiento.Value.ToString("d"), null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DiasMora.ToString(), null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Importe.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Estatus, null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desBanco, null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nroUnico, null, "S", null, FuenteDetalle, 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "S", null, FuenteDetalle, 5, 1));

                            TablaCabDetalle.CompleteRow();
                        }

                        docPdf.Add(TablaCabDetalle);
                    }

                    //Crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //Establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close(); 
                }
            }
        }

        void MostrarReporte2(Int32 idSistema)
        {

            #region Variables

            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = String.Empty;
            String Extension = ".pdf";
            String TituloGeneral = String.Empty;
            String Fechas = String.Empty;

            float[] cabAnchoDetVentas = new float[] { 0.035f, 0.035f, 0.01f, 0.02f, 0.035f, 0.01f, 0.02f, 0.035f, 0.02f, 0.035f, 0.01f, 0.045f, 0.015f, 0.025f, 0.025f, 0.03f };
            float[] cabAnchoDetCompras = new float[] { 0.02f, 0.035f, 0.06f, 0.048f, 0.048f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f };
            BaseColor ColorSub1 = new BaseColor(Color.FromArgb(0, 112, 192)); //Azul claro
            iTextSharp.text.Font LetraNegritaBlanco = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font LetraNegritaNegro = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font FuenteDetalle = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL);
            BaseColor ColorSub2 = new BaseColor(146, 208, 80); //Verde claro
            iTextSharp.text.Font LetraNegrita = FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font LetraNormal = FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL);

            List<CtaCteE> ListaCtaCteTmp = null;

            #endregion

            RutaTemp = @"C:\AmazonErp\ArchivosTemporales";

            if (!Directory.Exists(RutaTemp))
            {
                Directory.CreateDirectory(RutaTemp);
            }

            docPdf.AddCreationDate();
            docPdf.AddAuthor("AMAZONTIC SAC");
            docPdf.AddCreator("AMAZONTIC SAC");

            if (TipoReporte == 4)
            {
                if (rbPorDocumentos.Checked)
                {
                    NombreReporte = @"\Reporte CtaCte " + Aleatorio.ToString();
                    TituloGeneral = "CUENTA CORRIENTE RESUMIDA";
                    Fechas = "(Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + ")";
                }
                else
                {
                    NombreReporte = @"\Reporte CtaCte Detallado " + Aleatorio.ToString();
                    TituloGeneral = "CUENTA CORRIENTE DETALLADA";
                    Fechas = "(Al " + dtpFecIni.Value.ToString("dd/MM/yyyy") + ")";
                }
            }

            if (!String.IsNullOrWhiteSpace(RutaTemp.Trim()))
            {
                //Creacion del archivo pdf
                RutaTemp += NombreReporte + Extension;

                if (File.Exists(RutaTemp))
                {
                    File.Delete(RutaTemp);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    oPdfw.PageEvent = new PagEncabezadoCtaCte();

                    docPdf.Open();

                    #region Cabecera del Reporte

                    PdfPTable table = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    table.SetWidths(new float[] { 0.35f, 0.65f });
                    table.HorizontalAlignment = Element.ALIGN_LEFT;

                    //Logo de la Empresa
                    if (!File.Exists(RutaImagen))
                    {
                        RutaImagen = ReaderHelper.RevisarLogo(RutaImagen, Properties.Resources.interrogacion);
                    }

                    //Lado Derecho
                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        System.Drawing.Image Img = System.Drawing.Image.FromFile(RutaImagen);
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 3f, 170f, 40f, 1, 1, "S", 1f));
                        Img = null;
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    CeldaImagen.Rowspan = 2;
                    table.AddCell(CeldaImagen);

                    //Lado Izquierdo
                    table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 11.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 0, 4, "S", "N", "S", "N", 1));
                    table.AddCell(ReaderHelper.NuevaCelda(Fechas, null, "S", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 3, 0, "N", "S", "S", "N", 1));
                    table.CompleteRow(); //Fila completada

                    //Espacio en Blanco
                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    docPdf.Add(table);

                    #endregion

                    if (TipoReporte == 4)
                    {
                        //Obteniendo una lista temporal para la cabecera...
                        List<CtaCteE> oListaCabeceras = oListaCtaCte.GroupBy(x => x.idPersona).Select(g => g.First()).ToList();

                        //Recorriendo la Lista temporal de Clientes
                        foreach (CtaCteE itemCab in oListaCabeceras)
                        {
                            #region Subtitulos

                            PdfPTable TablaSubTitulos = new PdfPTable(4)
                            {
                                WidthPercentage = 100
                            };

                            TablaSubTitulos.SetWidths(new float[] { 0.1f, 0.7f, 0.1f, 0.1f });

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(idSistema == 2 ? "CLIENTE: " : "PROVEEDOR: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.RazonSocial, null, "N", null, LetraNormal));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("RUC: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.RUC, null, "N", null, LetraNormal));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda("DIRECCION: ", null, "N", null, LetraNegrita));
                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(itemCab.Direccion, null, "N", null, LetraNormal, -1, -1, "S4"));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            TablaSubTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                            TablaSubTitulos.CompleteRow(); //Fila completada

                            docPdf.Add(TablaSubTitulos); //Añadiendo la tabla al documento PDF...
                            TablaSubTitulos = null;

                            #endregion

                            #region Detalle

                            ListaCtaCteTmp = oListaCtaCte.Where(x => x.idPersona == itemCab.idPersona).ToList();
                            PdfPTable TablaDetalle = new PdfPTable(idSistema == 2 ? 16 : 11);
                            TablaDetalle.SetWidths(idSistema == 2 ? cabAnchoDetVentas : cabAnchoDetCompras);
                            TablaDetalle.WidthPercentage = 100;

                            String idDoc = String.Empty;
                            String Serie = String.Empty;
                            String Numero = String.Empty;
                            String PasoDet = "S";

                            if (ListaCtaCteTmp.Count > 0)
                            {
                                foreach (CtaCteE item in ListaCtaCteTmp)
                                {
                                    if (item.TipoAC == "C")
                                    {
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Sucursal", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("N° Pedido", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Motivo", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1, "S3"));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("T.D.", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Serie", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Número", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Emis.", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Vcmto.", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Mon.", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Condición Pago", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Ti.Ca.", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Cargo", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Abono", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Detracción", ColorSub1, "S", null, LetraNegritaBlanco, 5, 1));

                                        TablaDetalle.CompleteRow();

                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desLocal, null, "S", null, LetraNegritaNegro, 5, 0));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.codPedido, null, "S", null, LetraNegritaNegro, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Motivo, null, "S", null, LetraNegritaNegro, 5, 0, "S3"));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoMov, null, "S", null, LetraNegritaNegro, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.SerieMov, null, "S", null, LetraNegritaNegro, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.NumeroMov, null, "S", null, LetraNegritaNegro, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaDocumento.ToString("dd/MM/yyyy"), null, "S", null, LetraNegritaNegro, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaVencimiento.Value.ToString("dd/MM/yyyy"), null, "S", null, LetraNegritaNegro, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "S", null, LetraNegritaNegro, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCondicion, null, "S", null, LetraNegritaNegro, 5, 0));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.TipoCambio.ToString("N3"), null, "S", null, LetraNegritaNegro, 5, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cargo.ToString("N2"), null, "S", null, LetraNegritaNegro, 5, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "S", null, LetraNegritaNegro, 5, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda((item.TieneDetra == true ? "SI" : "NO"), null, "S", null, LetraNegritaNegro, 5, 1));
                                        
                                        PasoDet = "S";
                                    }
                                    else
                                    {
                                        if (PasoDet == "S")
                                        {
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Sucursal", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("N° Ingreso", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("T.D.", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Serie", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Número", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Forma de Pago", ColorSub2, "S", null, LetraNegritaNegro, 5, 1, "S3"));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Fec.Oper.", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Nro.Operación", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Mon.", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Cuenta Bancaria", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Ti.Ca.", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Cargo", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Abono", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));
                                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("Monto Recibido", ColorSub2, "S", null, LetraNegritaNegro, 5, 1));

                                            TablaDetalle.CompleteRow();
                                            PasoDet = "N";
                                        }

                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desLocal, null, "S", null, FuenteDetalle, 5, 0));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nroUnico, null, "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoMov, null, "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.SerieMov, null, "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.NumeroMov, null, "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desFormaPago, null, "S", null, FuenteDetalle, 5, 0, "S3"));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaMovimiento.Value.ToString("dd/MM/yyyy"), null, "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(String.IsNullOrWhiteSpace(item.numLetras) ? item.NroOperacion : item.numLetras, null, "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMonedaRecibida, null, "S", null, FuenteDetalle, 5, 1));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.desBanco, null, "S", null, FuenteDetalle, 5, 0));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.TipoCambio.ToString("N3"), null, "S", null, FuenteDetalle, 5, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "S", null, FuenteDetalle, 5, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.Abono.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.MontoRecibido.ToString("N2"), null, "S", null, FuenteDetalle, 5, 2));
                                    }
                                    
                                    TablaDetalle.CompleteRow();
                                }

                                //Fila en blanco
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 5, 1, (idSistema == 2 ? "S16" : "S11"), "N", 0, 0));
                                TablaDetalle.CompleteRow();
                            }

                            #endregion

                            docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF
                        }
                    }

                    //Crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //Establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaCtaCte == null || oListaCtaCte.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String nomArchivo = String.Empty;

                switch (TipoReporte)
                {
                    case 1:
                        nomArchivo = "Cta.Cte. Detallada de " + VariablesLocales.SesionUsuario.Empresa.NombreComercial;
                        break;
                    case 2:
                        nomArchivo = "Ctas. por Cobrar de " + VariablesLocales.SesionUsuario.Empresa.NombreComercial;
                        break;
                    case 3:
                        nomArchivo = "Control de Letras por Cobrar de " + VariablesLocales.SesionUsuario.Empresa.NombreComercial;
                        break;
                    default:
                        nomArchivo = "Cta.Cte. de " + VariablesLocales.SesionUsuario.Empresa.NombreComercial;
                        break;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", nomArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrWhiteSpace(RutaGeneral))
                {
                    if (TipoReporte != 4)
                    {
                        ExportarExcel(RutaGeneral, idSistema);
                    }
                    else
                    {
                        ExportarExcel2(RutaGeneral, idSistema);
                    }

                    Global.MensajeComunicacion("Registros exportados...");
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
                if (tipoAccion == "buscar")
                {
                    if (TipoReporte == 1)
                    {
                        if (rbPorDocumentos.Checked)
                        {
                            oListaCtaCte = AgenteTesoreria.Proxy.ObtenerMaeCtaCtePorParametros(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idPersona, dtpFecIni.Value.Date, idSistema);
                        }
                        else
                        {
                            Boolean Historico;

                            if (chkHistorico.Checked == true)
                            {
                                Historico = true;
                            }
                            else
                            {
                                Historico = false;
                            }

                            oListaCtaCte = AgenteTesoreria.Proxy.MaeCtaCteDetalladoVentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idPersona, dtpFecIni.Value.Date, idSistema, Historico);
                        }

                        oListaCtaCte = oListaCtaCte.OrderBy(x => x.RazonSocial).ToList();
                    }
                    else if (TipoReporte == 2)
                    {
                        oListaCtaCte = AgenteTesoreria.Proxy.ObtenerMaeCtaCteResumen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idPersona, dtpFecIni.Value.Date, idSistema);

                        if (chbVen.Checked == false)
                        {
                             ListaFilt = (from item in oListaCtaCte where item.idVendedor == Convert.ToInt32(txtidauxiliar2.Text) select item).ToList();
                        }

                    }
                    else if (TipoReporte == 3)
                    {
                        oListaCtaCte = AgenteTesoreria.Proxy.ObtenerMaeCtaCteLetras(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idPersona, dtpFecIni.Value.Date, idSistema);
                    }
                    else if (TipoReporte == 4)
                    {
                        oListaCtaCte = AgenteTesoreria.Proxy.CtaCteDetalladoVentas2(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idPersona, dtpFecIni.Value.Date, idSistema);
                    }

                    if (oListaCtaCte.Count > 0 && oListaCtaCte != null)
                    {
                        if (TipoReporte == 1)
                        {
                            if (rbPorDocumentos.Checked)
                            {
                                ConvertirApdf(0);
                            }
                            else
                            {
                                MostrarReporte(idSistema);
                            }
                        }
                        else
                        {
                            if (TipoReporte == 4)
                            {
                                MostrarReporte2(idSistema);
                            }
                            else
                            {
                                MostrarReporte(idSistema);
                            }
                        }
                    }
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
            btBuscar.Enabled = true;

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                if (tipoAccion == "buscar")
                {
                    if (oListaCtaCte == null || oListaCtaCte.Count == 0)
                    {
                        RutaTemp = "";
                        Global.MensajeComunicacion("No hay datos para mostrar. La pantalla pertenece a la busqueda anterior.");
                    }

                    if (!String.IsNullOrEmpty(RutaTemp))
                    {
                        wbNavegador.Navigate(RutaTemp);
                        RutaTemp = "";
                    }
                }
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        #endregion

        #region Eventos

        private void frmReporteCtaCte_Load(object sender, EventArgs e)
        {
            lblDe.Text = "Al ";
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = true;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            idSistema = idSistemaForm;

            if (idSistema == 2)
            {
                chbProveedor.Text = "Todos los Clientes";
            }
            else
            {
                chbProveedor.Text = "Todos los Proveedores";
            }
        }
        
        private void rbDetalle_CheckedChanged(object sender, EventArgs e)
        {
            oListaCtaCte = null;
        }

        private void chbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            txtRuc.TextChanged -= txtRuc_TextChanged;
            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

            if (chbProveedor.Checked)
            {
                txtIdAuxiliar.Text = "0";
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else
            {
                txtIdAuxiliar.Text = "0";
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }

            txtRuc.TextChanged += txtRuc_TextChanged;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
        }

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {
            oListaCtaCte = null;
        }

        private void rbPorDocumentos_CheckedChanged(object sender, EventArgs e)
        {
                       
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRuc.Text) && string.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonSocial.Text) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipoAccion = "buscar";
                if (rbCCDet.Checked == true)
                {
                    TipoReporte = 1;
                }
                else if (rbCPC.Checked == true)
                {
                    TipoReporte = 2;
                }
                else if (rbCLC.Checked == true)
                {
                    TipoReporte = 3;
                }
                else if (rbCC.Checked == true)
                {
                    TipoReporte = 4;
                }
                    
                pbProgress.Visible = true;
                btBuscar.Enabled = false;

                if (!chbProveedor.Checked && String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    Global.MensajeComunicacion("El check de auxiliar esta desabilitado, debe escoger un auxiliar.");
                    return;
                }

                idPersona = Convert.ToInt32(txtIdAuxiliar.Text);

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chbVen_CheckedChanged(object sender, EventArgs e)
        {
            txtRucVen.TextChanged -= txtRucVen_TextChanged;
            txtRazonSocialVen.TextChanged -= txtRazonSocialVen_TextChanged;

            if (chbVen.Checked)
            {
                txtidauxiliar2.Text = "0";
                txtRucVen.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtRazonSocialVen.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else
            {
                txtidauxiliar2.Text = "0";
                txtRucVen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocialVen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }

            txtRucVen.TextChanged += txtRucVen_TextChanged;
            txtRazonSocialVen.TextChanged += txtRazonSocialVen_TextChanged;
        }

        private void txtRucVen_TextChanged(object sender, EventArgs e)
        {
            txtidauxiliar2.Text = String.Empty;
            txtRazonSocialVen.Text = String.Empty;
        }

        private void txtRazonSocialVen_TextChanged(object sender, EventArgs e)
        {
            txtidauxiliar2.Text = String.Empty;
            txtRucVen.Text = String.Empty;
        }

        private void txtRucVen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRucVen.Text.Trim()) && string.IsNullOrEmpty(txtRazonSocialVen.Text.Trim()))
                {
                    txtRucVen.TextChanged -= txtRucVen_TextChanged;
                    txtRazonSocialVen.TextChanged -= txtRazonSocialVen_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", txtRucVen.Text.Trim());
                    //List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucVen.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtidauxiliar2.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRucVen.Text = oFrm.oPersona.RUC;
                            txtRazonSocialVen.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocialVen.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtidauxiliar2.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRucVen.Text = oListaPersonas[0].RUC;
                        txtRazonSocialVen.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtidauxiliar2.Text = String.Empty;
                        txtRucVen.Text = String.Empty;
                        txtRazonSocialVen.Text = String.Empty;
                        txtRucVen.Focus();
                    }

                    txtRucVen.TextChanged += txtRucVen_TextChanged;
                    txtRazonSocialVen.TextChanged += txtRazonSocialVen_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRucVen.TextChanged += txtRucVen_TextChanged;
                txtRazonSocialVen.TextChanged += txtRazonSocialVen_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocialVen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonSocialVen.Text.Trim()) && string.IsNullOrEmpty(txtRucVen.Text.Trim()))
                {
                    txtRucVen.TextChanged -= txtRucVen_TextChanged;
                    txtRazonSocialVen.TextChanged -= txtRazonSocialVen_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtRazonSocialVen.Text.Trim(), "");

                    //List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocialVen.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtidauxiliar2.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRucVen.Text = oFrm.oPersona.RUC;
                            txtRazonSocialVen.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocialVen.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtidauxiliar2.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRucVen.Text = oListaPersonas[0].RUC;
                        txtRazonSocialVen.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtidauxiliar2.Text = String.Empty;
                        txtRucVen.Text = String.Empty;
                        txtRazonSocialVen.Text = String.Empty;
                        txtRucVen.Focus();
                    }

                    txtRucVen.TextChanged += txtRucVen_TextChanged;
                    txtRazonSocialVen.TextChanged += txtRazonSocialVen_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbCCDet_CheckedChanged(object sender, EventArgs e)
        {
            chkHistorico.Visible = true;
        }

        private void rbCPC_CheckedChanged(object sender, EventArgs e)
        {
            chkHistorico.Visible = false;

            if (rbCPC.Checked == true && idSistema == 2)
            {
                chbVen.Visible = true;
                txtRucVen.Visible = true;
                txtRazonSocialVen.Visible = true;
            }
            else
            {
                chbVen.Visible = false;
                txtRucVen.Visible = false;
                txtRazonSocialVen.Visible = false;
            }
        }

        private void rbCLC_CheckedChanged(object sender, EventArgs e)
        {
            chkHistorico.Visible = false;
        }

        private void rbCC_CheckedChanged(object sender, EventArgs e)
        {
            chkHistorico.Visible = false;
        }

        #endregion
    }

    class PagEncabezadoCtaCte : PdfPageEventHelper
    {

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            BaseColor colCabDetalle = BaseColor.LIGHT_GRAY;
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

            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
            table.CompleteRow();

            document.Add(table); //Añadiendo la tabla al documento PDF
        }

    }
}

