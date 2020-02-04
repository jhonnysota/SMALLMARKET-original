using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Negocio;

#endregion

#region Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteRegistroComprasLe : FrmMantenimientoBase
    {

        public frmReporteRegistroComprasLe()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            Global.CrearToolTip(btPle, "Importar para el PLE");
            Global.CrearToolTip(btPdb, "Importar para el PDB");
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroComprasE> oListaRegistroCompras = null;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();

        int tipoProceso = Variables.Cero; // 1 buscar; 0 exportar
        Int32 letra = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> ListaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();

            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            ListaLocales.Add(ItemLocal);
            ListaLocales = (from x in ListaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, ListaLocales, "idLocal", "Nombre", false);

            if (ListaLocales.Count == 2)
            {
                cboSucursales.SelectedValue = 1;
            }

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMonedas.DataSource = (from x in ListaMoneda
                                     where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                     orderby x.idMoneda
                                     select x).ToList();
            cboMonedas.ValueMember = "idMoneda";
            cboMonedas.DisplayMember = "desMoneda";
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A3.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Registro de Compras de " + FechasHelper.NombreMes(dtpFecIni.Value.Month) + " " + Aleatorio.ToString();
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

                FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 0.85f);

                oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                if (docPdf.IsOpen())
                {
                    docPdf.CloseDocument();
                }

                PaginaInicialRegistroCompras ev = new PaginaInicialRegistroCompras();
                ev.Periodo = dtpFecIni.Value.Date;
                ev.Moneda = cboMonedas.SelectedValue.ToString();
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(28);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.11f, 0.074f, 0.074f, 0.037f, 0.05f, 0.06f, 0.085f, 0.037f, 0.13f, 0.55f, 0.09f, 0.09f, 0.09f, 0.081f, 0.081f, 0.081f, 0.09f, 0.048f, 0.048f, 0.11f,
                                                        0.1f, 0.08f, 0.074f, 0.07f, 0.074f, 0.037f, 0.05f, 0.085f });

                foreach (RegistroComprasE item in oListaRegistroCompras)
                {
                    if (item.RazonSocial.Contains("TOTALES ACUMULADOS"))
                    {
                        cell = new PdfPCell(new Paragraph("  ", FontFactory.GetFont("Arial", 3f))) { Border = 1, BorderWidthTop = 1, HorizontalAlignment = Element.ALIGN_CENTER };
                        cell.Colspan = 28;
                        TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();
                    }

                    cell = new PdfPCell(new Paragraph(item.Correlativo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    
                    if (item.fecDocumento != null)
                    {
                        cell = new PdfPCell(new Paragraph(item.fecDocumento.Value.ToString("dd/MM/yy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    }

                    TablaCabDetalle.AddCell(cell);

                    if (item.fecVencimiento != null)
                    {
                        cell = new PdfPCell(new Paragraph(Convert.ToDateTime(item.fecVencimiento).ToString("dd/MM/yy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    }
                    
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.tipDocumentoVenta, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.serDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.AnioDua, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.numDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.tipDocPersona, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);
                    
                    if (item.RUC != null)
                    {
                        cell = new PdfPCell(new Paragraph(item.RUC.ToString().Replace("-", "").Replace(".", "").Replace(" ", ""), FontFactory.GetFont("Arial", 5f))) { Border = 0 };    
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0 };    
                    }

                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.RazonSocial, FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.BaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.IgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.BaseGravadoNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.IgvGravadoNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.BaseSinDerecho.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.IgvSinDerecho.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.BaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.ISC.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Otros.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Total.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.docDomiciliado, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.numDetraccion, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    if (item.fecDetraccion != null)
                    {
                        cell = new PdfPCell(new Paragraph(Convert.ToDateTime(item.fecDetraccion).ToString("dd/MM/yy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };    
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                    }
                    
                    TablaCabDetalle.AddCell(cell);

                    if (item.tipCambio > Variables.Cero)
                    {
                        cell = new PdfPCell(new Paragraph(item.tipCambio.ToString("N3"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };    
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph("0.000", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    }
                    
                    TablaCabDetalle.AddCell(cell);

                    if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "97")
                    {
                        cell = new PdfPCell(new Paragraph(Convert.ToDateTime(item.fecDocumentoRef).ToString("dd/MM/yy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.idDocumentoRef, FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.serDocumentoRef, FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.numDocumentoRef, FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);
                    }

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
                fsNuevoArchivo.Close();
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Registros de Compras";
            NombrePestaña = "Compras";

            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);
                List<RegistroComprasE> oListaDuas = null;

                List <RegistroComprasE> oListaNacionales = new List<RegistroComprasE>(from x in oListaRegistroCompras
                                                                                     where (x.tipDocumentoVenta != "00"
                                                                                     && x.tipDocumentoVenta != "91"
                                                                                     && x.tipDocumentoVenta != "97"
                                                                                     && x.tipDocumentoVenta != "98"
                                                                                     && x.tipDocumentoVenta != null)
                                                                                     select x).ToList();

                List<RegistroComprasE> oListaImportadas = new List<RegistroComprasE>(from x in oListaRegistroCompras
                                                                                     where x.tipDocumentoVenta == "91"
                                                                                     || x.tipDocumentoVenta == "97"
                                                                                     || x.tipDocumentoVenta == "98"
                                                                                     select x).ToList();

                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                {
                    oListaDuas = new List<RegistroComprasE>(from x in oListaRegistroCompras
                                                            where x.tipDocumentoVenta == "50"
                                                            || x.tipDocumentoVenta == "91"
                                                            select x).ToList();
                }
               
                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 28;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                    
                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 20, FontStyle.Bold));
                        //Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 219, 219));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 18, FontStyle.Regular));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
                    }

                    #endregion

                    #region Cabecera

                    #region Primera Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[4, 1, 6, 1])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Cod. Uni. de la Ope.";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 2, 6, 2])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Fecha de Emisiòn del Documento";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 3, 6, 3])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Fecha de Venc. y/o Pago";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 4, 5, 6])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Comprobante de Pago ó Documento ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 7, 6, 7])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Nro. Comprobante de Pago";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 8, 4, 10])//
                    {
                        Rango.Merge = true;
                        Rango.Value = "Información del Proveedor";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 11, 5, 12])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 13, 5, 14])//
                    {
                        Rango.Merge = true;
                        Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación y a Operaciones no Gravadas";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 15, 5, 16])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones no Gravadas ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 17, 6, 17])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Valor de las Adquisiciones no Gravadas";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 18, 6, 18])
                    {
                        Rango.Merge = true;
                        Rango.Value = "ISC";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 19, 6, 19])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Otros Tributos y Cargos";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 20, 6, 20])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Importe Total";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 21, 6, 21])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Nº de Comprobantes de Pago Emitido por Sujeto no Domiciliario";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 22, 5, 23])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Costancia de Déposito de Detración";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 24, 6, 24])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Tipo de Cambio";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 25, 6, 28])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Referencia  de Comprobantes de Pago o Documento Original que se modififca";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    #endregion

                    InicioLinea++;

                    #region Segunda Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[5, 8, 5, 9])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Doc de Identidad";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 10, 6, 10])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Apellidos y Nombres ó Razon Social";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    #endregion

                    InicioLinea++;

                    #region Tercera Linea Cabecera

                    oHoja.Row(6).Height = 30;

                    oHoja.Cells[InicioLinea, 4].Value = "Tipo";
                    oHoja.Cells[InicioLinea, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 5].Value = "Serie o Cod de la Dep. Adu.";
                    oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 6].Value = "Año de la Emision de la Dua";
                    oHoja.Cells[InicioLinea, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 6].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 8].Value = "Tipo";
                    oHoja.Cells[InicioLinea, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 9].Value = "Nùmero";
                    oHoja.Cells[InicioLinea, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 11].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 11].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 12].Value = "IGV";
                    oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 13].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 13].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 13].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 14].Value = "IGV";
                    oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 14].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 15].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 15].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 15].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 16].Value = "IGV";
                    oHoja.Cells[InicioLinea, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 16].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 16].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 16].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 22].Value = "Número";
                    oHoja.Cells[InicioLinea, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 22].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 22].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 22].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 23].Value = "Fecha de Emisión";
                    oHoja.Cells[InicioLinea, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 23].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 23].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 23].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 25].Value = "Fecha";
                    oHoja.Cells[InicioLinea, 25].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 25].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 25].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 25].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 26].Value = "Tipo";
                    oHoja.Cells[InicioLinea, 26].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 26].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 26].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 26].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 26].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 27].Value = "Serie";
                    oHoja.Cells[InicioLinea, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 27].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 27].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 27].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 28].Value = "Nº Documento";
                    oHoja.Cells[InicioLinea, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 28].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 28].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 28].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    #endregion

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #region Detalle

                    foreach (RegistroComprasE item in oListaRegistroCompras)
                    {
                        if (!item.RazonSocial.Contains("TOTALES ACUMULADOS"))
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.Correlativo;
                            oHoja.Cells[InicioLinea, 2].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                            
                            if (item.fecVencimiento != null)
                            {
                                oHoja.Cells[InicioLinea, 3].Value = Convert.ToDateTime(item.fecVencimiento).ToString("d");
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 3].Value = " ";
                            }

                            oHoja.Cells[InicioLinea, 4].Value = item.tipDocumentoVenta;
                            oHoja.Cells[InicioLinea, 5].Value = item.serDocumento;
                            oHoja.Cells[InicioLinea, 6].Value = item.Dua;
                            oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;
                            oHoja.Cells[InicioLinea, 8].Value = item.tipDocPersona;
                            oHoja.Cells[InicioLinea, 9].Value = item.RUC;
                            oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;

                            oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 11].Value = item.BaseGravado;
                            oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 12].Value = item.IgvGrabado;
                            oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 13].Value = item.BaseGravadoNoGravado;
                            oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 14].Value = item.IgvGravadoNoGravado;
                            oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 15].Value = item.BaseSinDerecho;
                            oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 16].Value = item.IgvSinDerecho;
                            oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 17].Value = item.BaseNoGravado;
                            oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 18].Value = item.ISC;
                            oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 19].Value = item.Otros;
                            oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 20].Value = item.Total;

                            oHoja.Cells[InicioLinea, 21].Value = item.docDomiciliado;
                            oHoja.Cells[InicioLinea, 22].Value = item.numDetraccion;

                            if (item.fecDetraccion != null)
                            {
                                oHoja.Cells[InicioLinea, 23].Value = Convert.ToDateTime(item.fecDetraccion).ToString("d");    
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 23].Value = " ";
                            }

                            oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "##0.00";
                            oHoja.Cells[InicioLinea, 24].Value = item.tipCambio;

                            if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "08" || item.tipDocumentoVenta == "97")
                            {
                                oHoja.Cells[InicioLinea, 25].Value = Convert.ToDateTime(item.fecDocumentoRef).ToString("d");
                                oHoja.Cells[InicioLinea, 26].Value = item.idDocumentoRef;
                                oHoja.Cells[InicioLinea, 27].Value = item.serDocumentoRef;
                                oHoja.Cells[InicioLinea, 28].Value = item.numDocumentoRef;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 25].Value = " ";
                                oHoja.Cells[InicioLinea, 26].Value = " ";
                                oHoja.Cells[InicioLinea, 27].Value = " ";
                                oHoja.Cells[InicioLinea, 27].Value = " ";
                            } 
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;
                            
                            oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 11].Value = item.BaseGravado;
                            oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 12].Value = item.IgvGrabado;
                            oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 13].Value = item.BaseGravadoNoGravado;
                            oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 14].Value = item.IgvGravadoNoGravado;
                            oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 15].Value = item.BaseSinDerecho;
                            oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 16].Value = item.IgvSinDerecho;
                            oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 17].Value = item.BaseNoGravado;
                            oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 18].Value = item.ISC;
                            oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 19].Value = item.Otros;
                            oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 20].Value = item.Total;

                            oHoja.Cells[InicioLinea + 1, 1, InicioLinea + 1, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;
                        }

                        InicioLinea++;
                    }

                    #endregion

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();

                    if (oListaImportadas.Count > Variables.Cero)
                    {
                        CargarOtros(oExcel, "Importadas", oListaImportadas);
                    }

                    if (oListaNacionales.Count > Variables.Cero)
                    {
                        CargarOtros(oExcel, "Nacionales", oListaNacionales);
                    }

                    if (oListaDuas != null && oListaDuas.Count > Variables.Cero)
                    {
                        CargarOtros(oExcel, "Duas", oListaDuas);
                    }

                    #region Propiedades del Excel

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
                    oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;
                    
                    #endregion
                    
                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        void ExportarExcelNoDom(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Registro Verificación Compras No Domiciliado - PLE";
            NombrePestaña = "Compras No Dom.";

            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);
                string mes = FechasHelper.NombreMes(dtpFecIni.Value.Month);
                string anio = dtpFecIni.Value.ToString("yyyy");

                if (oHoja != null)
                {
                    Int32 InicioLinea = 6;
                    Int32 TotColumnas = 36;

                    #region Titulos Principales

                    //Primera linea
                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, 3])
                    {
                        Rango.Merge = true;
                        Rango.Value = TituloGeneral;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));
                    }

                    oHoja.Cells["AF1"].Value = "Emitido por el software INDUSOFT®";
                    oHoja.Cells["AF1"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));

                    //Alto de linea
                    oHoja.Row(1).Height = 12.75;

                    oHoja.Cells["A2"].Value = "Razón Social:";
                    oHoja.Cells["A2"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));

                    oHoja.Cells["B2"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                    oHoja.Cells["B2"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));
                    oHoja.Row(2).Height = 12.75;

                    oHoja.Cells["A3"].Value = "Mes de Proceso:";
                    oHoja.Cells["A3"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));

                    oHoja.Cells["B3"].Value = mes + " " + anio;
                    oHoja.Cells["B3"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));
                    oHoja.Row(3).Height = 12.75;

                    oHoja.Cells["A4"].Value = "Expresado en:";
                    oHoja.Cells["A4"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));

                    oHoja.Cells["B4"].Value = cboMonedas.SelectedValue.ToString() == Variables.Soles ? " SOLES" : " DOLARES";
                    oHoja.Cells["B4"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));
                    oHoja.Row(4).Height = 12.75;

                    oHoja.Cells["A5"].Value = "Fecha Reporte:";
                    oHoja.Cells["A5"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));

                    oHoja.Cells["B5"].Value = VariablesLocales.FechaHoy.ToString();
                    oHoja.Cells["B5"].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));
                    oHoja.Row(6).Height = 12.75;

                    #endregion

                    #region Cabecera del detalle

                    //Alto de la fila
                    oHoja.Row(InicioLinea).Height = 76.50;

                    oHoja.Cells[InicioLinea, 1].Value = "PERIODO";
                    oHoja.Cells[InicioLinea, 2].Value = "NUMERO CORRELATIVO Ó CODIGO UNICO DE LA OPERACIÓN";
                    oHoja.Cells[InicioLinea, 3].Value = "SECUENCIA";
                    oHoja.Cells[InicioLinea, 4].Value = "FECHA DE EMISION DEL COMPROBANTE DE PAGO O DOCUMENTO";
                    oHoja.Cells[InicioLinea, 5].Value = "TIPO COMPROBANTE DE PAGO O DOCUMENTO";
                    oHoja.Cells[InicioLinea, 6].Value = "SERIE DE COMPROBANTE DE PAGO O DOCUMENTO";
                    oHoja.Cells[InicioLinea, 7].Value = "NUMERO DE COMPROBANTE DE PAGO O DOCUMENTO";
                    oHoja.Cells[InicioLinea, 8].Value = "VALOR DE LAS ADQUISICIONES";
                    oHoja.Cells[InicioLinea, 9].Value = "OTROS CONCEPTOS, TRIBUTOS Y CARGOS QUE NO FORMAN PARTE DE LA BASE IMPONIBLE";
                    oHoja.Cells[InicioLinea, 10].Value = "IMPORTE TOTAL DE LAS ADQUISICIONES";
                    oHoja.Cells[InicioLinea, 11].Value = "TIPO COMPROBANTE DE PAGO O DOCUMENTO QUE SUSTENTA EL CREDITO FISCAL";
                    oHoja.Cells[InicioLinea, 12].Value = "SERIE COMPROBANTE DE PAGO O DOCUMENTO QUE SUSTENTA EL CREDITO FISCAL";
                    oHoja.Cells[InicioLinea, 13].Value = "AÑO DUAL O DSI COMPROBANTE DE PAGO O DOCUMENTO QUE SUSTENTA EL CREDITO FISCAL";
                    oHoja.Cells[InicioLinea, 14].Value = "NUMERO COMPROBANTE DE PAGO O DOCUMENTO QUE SUSTENTA EL CREDITO FISCAL";
                    oHoja.Cells[InicioLinea, 15].Value = "MONTO RETENCION IGV";
                    oHoja.Cells[InicioLinea, 16].Value = "CODIGO DE MONEDA";
                    oHoja.Cells[InicioLinea, 17].Value = "TIPO DE CAMBIO";
                    oHoja.Cells[InicioLinea, 18].Value = "PAIS DE RESIDENCIA DEL SUJETO NO DOMICILIADO";
                    oHoja.Cells[InicioLinea, 19].Value = "APELLIDOS Y NOMBRES DENOMINACION O RAZON SOCIAL DEL SUJETO NO DOMICILIADO";
                    oHoja.Cells[InicioLinea, 20].Value = "DOMICILIO DEL SUJETO NO DOMICILIADO";
                    oHoja.Cells[InicioLinea, 21].Value = "DOCUMENTO DE IDENTIFICACION DEL SUJETO NO DOMICILIADO";
                    oHoja.Cells[InicioLinea, 22].Value = "DOCUMENTO DE IDENTIFICACION FISCAL DEL BENEFICIARIO EFECTIVO DE LOS PAGO";
                    oHoja.Cells[InicioLinea, 23].Value = "APELLIDOS Y NOMBRES DENOMINACION O RAZON SOCIAL DEL BENEFICIARIO EFECTIVO DE LOS PAGO";
                    oHoja.Cells[InicioLinea, 24].Value = "PAIS DE RESIDENCIA DEL BENEFICIARIO EFECTIVO DE LOS PAGO";
                    oHoja.Cells[InicioLinea, 25].Value = "VINCULO ENTRE EL CONTRIBUYENTE Y EL RESIDENTE EN EL EXTRANJERO";
                    oHoja.Cells[InicioLinea, 26].Value = "RENTA BRUTA";
                    oHoja.Cells[InicioLinea, 27].Value = "DEDUCCIONES / COSTO DE ENAJENACION DE BIENES DE CAPITAL";
                    oHoja.Cells[InicioLinea, 28].Value = "RENTA NETA";
                    oHoja.Cells[InicioLinea, 29].Value = "TASA DE RETENCION";
                    oHoja.Cells[InicioLinea, 30].Value = "IMPUESTO RETENIDO";
                    oHoja.Cells[InicioLinea, 31].Value = "CONVENIOS PARA EVITAR DOBLE IMPOSICION";
                    oHoja.Cells[InicioLinea, 32].Value = "EXONERACION APLICADA";
                    oHoja.Cells[InicioLinea, 33].Value = "TIPO DE RENTA";
                    oHoja.Cells[InicioLinea, 34].Value = "MODALIDAD DEL SERVICIO PRESTADO POR EL NO DOMICILIADO";
                    oHoja.Cells[InicioLinea, 35].Value = "APLICACION DEL PENULTIMO PARRAFO DEL ART.76° DE LA LEY DEL IMPUESTO A LA RENTA";
                    oHoja.Cells[InicioLinea, 36].Value = "ESTADO QUE IDENTIFICA LA OPORTUNIDAD DE LA ANOTACION O INDICACION SI ESTA CORRESPONDE A UN AJUSTE";

                    oHoja.Column(1).Width = 16;
                    oHoja.Column(2).Width = 21;
                    oHoja.Column(3).Width = 21;
                    oHoja.Column(4).Width = 21;
                    oHoja.Column(5).Width = 21;
                    oHoja.Column(6).Width = 21;
                    oHoja.Column(7).Width = 21;
                    oHoja.Column(8).Width = 21;
                    oHoja.Column(9).Width = 21;
                    oHoja.Column(10).Width = 21;
                    oHoja.Column(11).Width = 21;
                    oHoja.Column(12).Width = 21;
                    oHoja.Column(13).Width = 21;
                    oHoja.Column(14).Width = 21;
                    oHoja.Column(15).Width = 21;
                    oHoja.Column(16).Width = 21;
                    oHoja.Column(17).Width = 21;
                    oHoja.Column(18).Width = 55;
                    oHoja.Column(19).Width = 55;
                    oHoja.Column(20).Width = 55;
                    oHoja.Column(21).Width = 55;
                    oHoja.Column(22).Width = 55;
                    oHoja.Column(23).Width = 55;
                    oHoja.Column(24).Width = 55;
                    oHoja.Column(25).Width = 21;
                    oHoja.Column(26).Width = 21;
                    oHoja.Column(27).Width = 21;
                    oHoja.Column(28).Width = 21;
                    oHoja.Column(29).Width = 21;
                    oHoja.Column(30).Width = 21;
                    oHoja.Column(31).Width = 21;
                    oHoja.Column(32).Width = 21;
                    oHoja.Column(33).Width = 21;
                    oHoja.Column(34).Width = 21;
                    oHoja.Column(35).Width = 21;
                    oHoja.Column(36).Width = 21;

                    for (int c = 1; c < TotColumnas + 1; c++)
                    {
                        for (int f = InicioLinea; f < InicioLinea + 2; f++)
                        {
                            if (f == 8)
                            {
                                oHoja.Cells[f, c].Value = c;
                                oHoja.Cells[f, c].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            }
                            else
                            {
                                oHoja.Cells[f, c].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            }

                            oHoja.Cells[f, c].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10, FontStyle.Bold));
                            oHoja.Cells[f, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[f, c].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            oHoja.Cells[f, c].Style.WrapText = true;
                        }
                    }

                    InicioLinea++;
                    oHoja.Row(InicioLinea).Height = 12.75;

                    #endregion Cabecera del detalle

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #region Detalle
                    int Inicio = InicioLinea;
                    int Final = 0;

                    foreach (RegistroComprasE item in oListaRegistroCompras)
                    {
                        oHoja.Row(InicioLinea).Height = 12.75;

                        if (!item.RazonSocial.Contains("TOTALES ACUMULADOS"))
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.Periodo;
                            oHoja.Cells[InicioLinea, 2].Value = item.Correlativo;
                            oHoja.Cells[InicioLinea, 3].Value = item.PrimerDigito;
                            oHoja.Cells[InicioLinea, 4].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                            oHoja.Cells[InicioLinea, 5].Value = item.tipDocumentoVenta;
                            oHoja.Cells[InicioLinea, 6].Value = item.serDocumento;
                            oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;

                            oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 8].Value = item.Total;

                            //oHoja.Cells[InicioLinea, 8].Value = item.tipDocPersona;
                            oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 9].Value = 0;

                            oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 10].Value = item.Total;

                            oHoja.Cells[InicioLinea, 11].Value = item.idDocumentoRef;
                            oHoja.Cells[InicioLinea, 12].Value = item.depAduanera;
                            oHoja.Cells[InicioLinea, 13].Value = item.AnioDua;
                            oHoja.Cells[InicioLinea, 14].Value = item.nroDua;

                            oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 15].Value = 0;

                            oHoja.Cells[InicioLinea, 16].Value = item.Moneda;

                            oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "##0.000";
                            oHoja.Cells[InicioLinea, 17].Value = item.tipCambio;

                            oHoja.Cells[InicioLinea, 18].Value = item.PaisOrigen;
                            oHoja.Cells[InicioLinea, 19].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 20].Value = item.Direccion;
                            oHoja.Cells[InicioLinea, 21].Value = item.RUC;
                            oHoja.Cells[InicioLinea, 22].Value = item.IdentiBeneficiario;
                            oHoja.Cells[InicioLinea, 23].Value = item.RazonBeneficiario;
                            oHoja.Cells[InicioLinea, 24].Value = item.PaisBeneficiario;
                            oHoja.Cells[InicioLinea, 25].Value = item.VinculacionEconomica;

                            oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 26].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 26].Value = item.RentaBruta;

                            oHoja.Cells[InicioLinea, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 27].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 27].Value = item.EnajenacionBienes;

                            oHoja.Cells[InicioLinea, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 28].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 28].Value = item.RentaNeta;

                            oHoja.Cells[InicioLinea, 29].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 29].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 29].Value = item.TasaRetencion;

                            oHoja.Cells[InicioLinea, 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 30].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 30].Value = item.ImpuestoRetenido;

                            oHoja.Cells[InicioLinea, 31].Value = item.ConvenioDobImpo;
                            oHoja.Cells[InicioLinea, 32].Value = item.ExoneracionApli;
                            oHoja.Cells[InicioLinea, 33].Value = item.TipoRenta;
                            oHoja.Cells[InicioLinea, 34].Value = item.ModalidadServicio;
                            oHoja.Cells[InicioLinea, 35].Value = item.LeyImpuestoRenta;
                            oHoja.Cells[InicioLinea, 36].Value = item.Estado;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                            oHoja.Cells[InicioLinea, 7].Value = "    TOTALES";

                            oHoja.Cells[InicioLinea, 8, InicioLinea, 8].Formula = string.Format("SUBTOTAL(9,{0})", new ExcelAddress(Inicio, 8, Final - 1, 8).Address);
                            oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                            oHoja.Cells[InicioLinea, 9, InicioLinea, 9].Formula = string.Format("SUBTOTAL(9,{0})", new ExcelAddress(Inicio, 9, Final - 1, 9).Address);
                            oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                            oHoja.Cells[InicioLinea, 10, InicioLinea, 10].Formula = string.Format("SUBTOTAL(9,{0})", new ExcelAddress(Inicio, 10, Final - 1, 10).Address);
                            oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                        }

                        for (int i = 1; i < TotColumnas + 1; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 10));
                        }

                        InicioLinea++;
                        Final = InicioLinea;
                    }

                    #endregion

                    #region Propiedades del Excel

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
                    oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    #endregion

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        void ExportarExcelFile(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Registros de Compras";
            NombrePestaña = "Compras";

            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);
                List<RegistroComprasE> oListaDuas = null;

                List<RegistroComprasE> oListaNacionales = new List<RegistroComprasE>(from x in oListaRegistroCompras
                                                                                     where (x.tipDocumentoVenta != "00"
                                                                                     && x.tipDocumentoVenta != "91"
                                                                                     && x.tipDocumentoVenta != "97"
                                                                                     && x.tipDocumentoVenta != "98"
                                                                                     && x.tipDocumentoVenta != null)
                                                                                     select x).ToList();

                List<RegistroComprasE> oListaImportadas = new List<RegistroComprasE>(from x in oListaRegistroCompras
                                                                                     where x.tipDocumentoVenta == "91"
                                                                                     || x.tipDocumentoVenta == "97"
                                                                                     || x.tipDocumentoVenta == "98"
                                                                                     select x).ToList();

                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                {
                    oListaDuas = new List<RegistroComprasE>(from x in oListaRegistroCompras
                                                            where x.tipDocumentoVenta == "50"
                                                            || x.tipDocumentoVenta == "91"
                                                            select x).ToList();
                }

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 28;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 20, FontStyle.Bold));
                        //Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 219, 219));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 18, FontStyle.Regular));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
                    }

                    #endregion

                    #region Cabecera

                    #region Primera Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[4, 1, 6, 1])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Cod. Uni. de la Ope.";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 2, 6, 2])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Fecha de Emisiòn del Documento";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 3, 6, 3])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Fecha de Venc. y/o Pago";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 4, 5, 6])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Comprobante de Pago ó Documento ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 7, 6, 7])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Nro. Comprobante de Pago";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 8, 4, 10])//
                    {
                        Rango.Merge = true;
                        Rango.Value = "Información del Proveedor";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 11, 5, 12])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 13, 5, 14])//
                    {
                        Rango.Merge = true;
                        Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación y a Operaciones no Gravadas";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 15, 5, 16])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación y a Operaciones no Gravadas ";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 17, 6, 17])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Valor de las Adquisiciones no Gravadas";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 18, 6, 18])
                    {
                        Rango.Merge = true;
                        Rango.Value = "ISC";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 19, 6, 19])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Otros Tributos y Cargos";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 20, 6, 20])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Importe Total";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 21, 6, 21])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Nº de Comprobantes de Pago Emitido por Sujeto no Domiciliario";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 22, 5, 23])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Costancia de Déposito de Detración";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 24, 6, 24])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Tipo de Cambio";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 25, 6, 28])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Referencia  de Comprobantes de Pago o Documento Original que se modififca";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    #endregion

                    InicioLinea++;

                    #region Segunda Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[5, 8, 5, 9])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Doc de Identidad";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 10, 6, 10])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Apellidos y Nombres ó Razon Social";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    #endregion

                    InicioLinea++;

                    #region Tercera Linea Cabecera

                    oHoja.Row(6).Height = 30;

                    oHoja.Cells[InicioLinea, 4].Value = "Tipo";
                    oHoja.Cells[InicioLinea, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 5].Value = "Serie o Cod de la Dep. Adu.";
                    oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 6].Value = "Año de la Emision de la Dua";
                    oHoja.Cells[InicioLinea, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 6].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 8].Value = "Tipo";
                    oHoja.Cells[InicioLinea, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 9].Value = "Nùmero";
                    oHoja.Cells[InicioLinea, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 11].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 11].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 12].Value = "IGV";
                    oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 13].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 13].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 13].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 14].Value = "IGV";
                    oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 14].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 15].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 15].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 15].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 16].Value = "IGV";
                    oHoja.Cells[InicioLinea, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 16].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 16].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 16].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 22].Value = "Número";
                    oHoja.Cells[InicioLinea, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 22].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 22].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 22].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 23].Value = "Fecha de Emisión";
                    oHoja.Cells[InicioLinea, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 23].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 23].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 23].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 25].Value = "Fecha";
                    oHoja.Cells[InicioLinea, 25].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 25].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 25].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 25].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 26].Value = "Tipo";
                    oHoja.Cells[InicioLinea, 26].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 26].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 26].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 26].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 26].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 27].Value = "Serie";
                    oHoja.Cells[InicioLinea, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 27].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 27].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 27].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 28].Value = "Nº Documento";
                    oHoja.Cells[InicioLinea, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 28].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 28].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 28].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    #endregion

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #region Detalle

                    int contador = 0;
                    string codCostos_Anterior = "";

                    Decimal SubTot1 = 0;
                    Decimal SubTot2 = 0;
                    Decimal SubTot3 = 0;
                    Decimal SubTot4 = 0;
                    Decimal SubTot5 = 0;
                    Decimal SubTot6 = 0;
                    Decimal SubTot7 = 0;
                    Decimal SubTot8 = 0;
                    Decimal SubTot9 = 0;
                    Decimal SubTot10 = 0;

                    oListaRegistroCompras = oListaRegistroCompras.OrderBy(x => x.Correlativo).ToList();
                    oListaRegistroCompras = oListaRegistroCompras.OrderBy(x => x.numFile).ToList();

                    foreach (RegistroComprasE item in oListaRegistroCompras)
                    {
                        if (!item.RazonSocial.Contains("TOTALES ACUMULADOS"))
                        {
                            if (contador == 0)
                            {
                                codCostos_Anterior = item.numFile;

                                oHoja.Cells[InicioLinea, 1].Value = item.numFile;
                                oHoja.Cells[InicioLinea, 2].Value = item.desFile;
                                oHoja.Cells[InicioLinea, 3].Value = "";
                                oHoja.Cells[InicioLinea, 4].Value = "";
                                oHoja.Cells[InicioLinea, 5].Value = "";
                                oHoja.Cells[InicioLinea, 6].Value = "";
                                oHoja.Cells[InicioLinea, 7].Value = "";
                                oHoja.Cells[InicioLinea, 8].Value = "";
                                oHoja.Cells[InicioLinea, 9].Value = "";
                                oHoja.Cells[InicioLinea, 10].Value = "";
                                oHoja.Cells[InicioLinea, 11].Value = "";
                                oHoja.Cells[InicioLinea, 12].Value = "";
                                oHoja.Cells[InicioLinea, 13].Value = "";
                                oHoja.Cells[InicioLinea, 14].Value = "";
                                oHoja.Cells[InicioLinea, 15].Value = "";
                                oHoja.Cells[InicioLinea, 16].Value = "";
                                oHoja.Cells[InicioLinea, 17].Value = "";
                                oHoja.Cells[InicioLinea, 18].Value = "";
                                oHoja.Cells[InicioLinea, 19].Value = "";
                                oHoja.Cells[InicioLinea, 20].Value = "";
                                oHoja.Cells[InicioLinea, 21].Value = "";
                                oHoja.Cells[InicioLinea, 22].Value = "";
                                oHoja.Cells[InicioLinea, 23].Value = "";
                                oHoja.Cells[InicioLinea, 24].Value = "";
                                oHoja.Cells[InicioLinea, 25].Value = "";
                                oHoja.Cells[InicioLinea, 26].Value = "";
                                oHoja.Cells[InicioLinea, 27].Value = "";
                                oHoja.Cells[InicioLinea, 28].Value = "";

                                for (int i = 1; i <= 2; i++)
                                {

                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                                }

                                InicioLinea++;


                                oHoja.Cells[InicioLinea, 1].Value = item.Correlativo;
                                oHoja.Cells[InicioLinea, 2].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");

                                if (item.fecVencimiento != null)
                                {
                                    oHoja.Cells[InicioLinea, 3].Value = Convert.ToDateTime(item.fecVencimiento).ToString("d");
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                }

                                oHoja.Cells[InicioLinea, 4].Value = item.tipDocumentoVenta;
                                oHoja.Cells[InicioLinea, 5].Value = item.serDocumento;
                                oHoja.Cells[InicioLinea, 6].Value = item.Dua;
                                oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;
                                oHoja.Cells[InicioLinea, 8].Value = item.tipDocPersona;
                                oHoja.Cells[InicioLinea, 9].Value = item.RUC;
                                oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;

                                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 11].Value = item.BaseGravado;
                                oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 12].Value = item.IgvGrabado;
                                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 13].Value = item.BaseGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 14].Value = item.IgvGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 15].Value = item.BaseSinDerecho;
                                oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 16].Value = item.IgvSinDerecho;
                                oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 17].Value = item.BaseNoGravado;
                                oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 18].Value = item.ISC;
                                oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 19].Value = item.Otros;
                                oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 20].Value = item.Total;

                                oHoja.Cells[InicioLinea, 21].Value = item.docDomiciliado;
                                oHoja.Cells[InicioLinea, 22].Value = item.numDetraccion;

                                if (item.fecDetraccion != null)
                                {
                                    oHoja.Cells[InicioLinea, 23].Value = Convert.ToDateTime(item.fecDetraccion).ToString("d");
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 23].Value = " ";
                                }

                                oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "##0.00";
                                oHoja.Cells[InicioLinea, 24].Value = item.tipCambio;

                                if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "08" || item.tipDocumentoVenta == "97")
                                {
                                    oHoja.Cells[InicioLinea, 25].Value = Convert.ToDateTime(item.fecDocumentoRef).ToString("d");
                                    oHoja.Cells[InicioLinea, 26].Value = item.idDocumentoRef;
                                    oHoja.Cells[InicioLinea, 27].Value = item.serDocumentoRef;
                                    oHoja.Cells[InicioLinea, 28].Value = item.numDocumentoRef;
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 25].Value = " ";
                                    oHoja.Cells[InicioLinea, 26].Value = " ";
                                    oHoja.Cells[InicioLinea, 27].Value = " ";
                                    oHoja.Cells[InicioLinea, 28].Value = " ";
                                }

                                SubTot1 += item.BaseGravado;
                                SubTot2 += item.IgvGrabado;
                                SubTot3 += item.BaseGravadoNoGravado;
                                SubTot4 += item.IgvGravadoNoGravado;
                                SubTot5 += item.BaseSinDerecho;
                                SubTot6 += item.IgvSinDerecho;
                                SubTot7 += item.BaseNoGravado;
                                SubTot8 += item.ISC;
                                SubTot9 += item.Otros;
                                SubTot10 += item.Total;

                                InicioLinea++;
                            }

                            if (contador > 0 && codCostos_Anterior == item.numFile)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.Correlativo;
                                oHoja.Cells[InicioLinea, 2].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");

                                if (item.fecVencimiento != null)
                                {
                                    oHoja.Cells[InicioLinea, 3].Value = Convert.ToDateTime(item.fecVencimiento).ToString("d");
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                }

                                oHoja.Cells[InicioLinea, 4].Value = item.tipDocumentoVenta;
                                oHoja.Cells[InicioLinea, 5].Value = item.serDocumento;
                                oHoja.Cells[InicioLinea, 6].Value = item.Dua;
                                oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;
                                oHoja.Cells[InicioLinea, 8].Value = item.tipDocPersona;
                                oHoja.Cells[InicioLinea, 9].Value = item.RUC;
                                oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;

                                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 11].Value = item.BaseGravado;
                                oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 12].Value = item.IgvGrabado;
                                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 13].Value = item.BaseGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 14].Value = item.IgvGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 15].Value = item.BaseSinDerecho;
                                oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 16].Value = item.IgvSinDerecho;
                                oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 17].Value = item.BaseNoGravado;
                                oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 18].Value = item.ISC;
                                oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 19].Value = item.Otros;
                                oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 20].Value = item.Total;

                                oHoja.Cells[InicioLinea, 21].Value = item.docDomiciliado;
                                oHoja.Cells[InicioLinea, 22].Value = item.numDetraccion;

                                if (item.fecDetraccion != null)
                                {
                                    oHoja.Cells[InicioLinea, 23].Value = Convert.ToDateTime(item.fecDetraccion).ToString("d");
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 23].Value = " ";
                                }

                                oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "##0.00";
                                oHoja.Cells[InicioLinea, 24].Value = item.tipCambio;

                                if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "08")
                                {
                                    oHoja.Cells[InicioLinea, 25].Value = Convert.ToDateTime(item.fecDocumentoRef).ToString("d");
                                    oHoja.Cells[InicioLinea, 26].Value = item.idDocumentoRef;
                                    oHoja.Cells[InicioLinea, 27].Value = item.serDocumentoRef;
                                    oHoja.Cells[InicioLinea, 28].Value = item.numDocumentoRef;
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 25].Value = " ";
                                    oHoja.Cells[InicioLinea, 26].Value = " ";
                                    oHoja.Cells[InicioLinea, 27].Value = " ";
                                    oHoja.Cells[InicioLinea, 28].Value = " ";
                                }

                                SubTot1 += item.BaseGravado;
                                SubTot2 += item.IgvGrabado;
                                SubTot3 += item.BaseGravadoNoGravado;
                                SubTot4 += item.IgvGravadoNoGravado;
                                SubTot5 += item.BaseSinDerecho;
                                SubTot6 += item.IgvSinDerecho;
                                SubTot7 += item.BaseNoGravado;
                                SubTot8 += item.ISC;
                                SubTot9 += item.Otros;
                                SubTot10 += item.Total;

                                InicioLinea++;
                            }

                            if (contador > 0 && codCostos_Anterior != item.numFile)
                            {
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                                InicioLinea++;


                                oHoja.Cells[InicioLinea, 1].Value = "";
                                oHoja.Cells[InicioLinea, 2].Value = "";
                                oHoja.Cells[InicioLinea, 3].Value = "";
                                oHoja.Cells[InicioLinea, 4].Value = "";
                                oHoja.Cells[InicioLinea, 5].Value = "";
                                oHoja.Cells[InicioLinea, 6].Value = "";
                                oHoja.Cells[InicioLinea, 7].Value = "";
                                oHoja.Cells[InicioLinea, 8].Value = "";
                                oHoja.Cells[InicioLinea, 9].Value = "";
                                oHoja.Cells[InicioLinea, 10].Value = "SUB TOTALES";
                                oHoja.Cells[InicioLinea, 11].Value = SubTot1;
                                oHoja.Cells[InicioLinea, 12].Value = SubTot2;
                                oHoja.Cells[InicioLinea, 13].Value = SubTot3;
                                oHoja.Cells[InicioLinea, 14].Value = SubTot4;
                                oHoja.Cells[InicioLinea, 15].Value = SubTot5;
                                oHoja.Cells[InicioLinea, 16].Value = SubTot6;
                                oHoja.Cells[InicioLinea, 17].Value = SubTot7;
                                oHoja.Cells[InicioLinea, 18].Value = SubTot8;
                                oHoja.Cells[InicioLinea, 19].Value = SubTot9;
                                oHoja.Cells[InicioLinea, 20].Value = SubTot10;
                                oHoja.Cells[InicioLinea, 21].Value = "";
                                oHoja.Cells[InicioLinea, 22].Value = "";
                                oHoja.Cells[InicioLinea, 23].Value = "";
                                oHoja.Cells[InicioLinea, 24].Value = "";
                                oHoja.Cells[InicioLinea, 25].Value = "";
                                oHoja.Cells[InicioLinea, 26].Value = "";
                                oHoja.Cells[InicioLinea, 27].Value = "";
                                oHoja.Cells[InicioLinea, 28].Value = "";

                                for (int i = 10; i <= 20; i++)
                                {

                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                                }

                                SubTot1 = 0;
                                SubTot2 = 0;
                                SubTot3 = 0;
                                SubTot4 = 0;
                                SubTot5 = 0;
                                SubTot6 = 0;
                                SubTot7 = 0;
                                SubTot8 = 0;
                                SubTot9 = 0;
                                SubTot10 = 0;


                                // FORMAT 
                                oHoja.Cells[InicioLinea, 11, InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";

                                InicioLinea++;


                                codCostos_Anterior = item.numFile;

                                oHoja.Cells[InicioLinea, 1].Value = item.numFile;
                                oHoja.Cells[InicioLinea, 2].Value = item.desFile;
                                oHoja.Cells[InicioLinea, 3].Value = "";
                                oHoja.Cells[InicioLinea, 4].Value = "";
                                oHoja.Cells[InicioLinea, 5].Value = "";
                                oHoja.Cells[InicioLinea, 6].Value = "";
                                oHoja.Cells[InicioLinea, 7].Value = "";
                                oHoja.Cells[InicioLinea, 8].Value = "";
                                oHoja.Cells[InicioLinea, 9].Value = "";
                                oHoja.Cells[InicioLinea, 10].Value = "";
                                oHoja.Cells[InicioLinea, 11].Value = "";
                                oHoja.Cells[InicioLinea, 12].Value = "";

                                for (int i = 1; i <= 2; i++)
                                {

                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                                }

                                InicioLinea++;

                                oHoja.Cells[InicioLinea, 1].Value = item.Correlativo;
                                oHoja.Cells[InicioLinea, 2].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");

                                if (item.fecVencimiento != null)
                                {
                                    oHoja.Cells[InicioLinea, 3].Value = Convert.ToDateTime(item.fecVencimiento).ToString("d");
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                }

                                oHoja.Cells[InicioLinea, 4].Value = item.tipDocumentoVenta;
                                oHoja.Cells[InicioLinea, 5].Value = item.serDocumento;
                                oHoja.Cells[InicioLinea, 6].Value = item.Dua;
                                oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;
                                oHoja.Cells[InicioLinea, 8].Value = item.tipDocPersona;
                                oHoja.Cells[InicioLinea, 9].Value = item.RUC;
                                oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;

                                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 11].Value = item.BaseGravado;
                                oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 12].Value = item.IgvGrabado;
                                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 13].Value = item.BaseGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 14].Value = item.IgvGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 15].Value = item.BaseSinDerecho;
                                oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 16].Value = item.IgvSinDerecho;
                                oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 17].Value = item.BaseNoGravado;
                                oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 18].Value = item.ISC;
                                oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 19].Value = item.Otros;
                                oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 20].Value = item.Total;

                                oHoja.Cells[InicioLinea, 21].Value = item.docDomiciliado;
                                oHoja.Cells[InicioLinea, 22].Value = item.numDetraccion;

                                if (item.fecDetraccion != null)
                                {
                                    oHoja.Cells[InicioLinea, 23].Value = Convert.ToDateTime(item.fecDetraccion).ToString("d");
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 23].Value = " ";
                                }

                                oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "##0.00";
                                oHoja.Cells[InicioLinea, 24].Value = item.tipCambio;

                                if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "08" || item.tipDocumentoVenta == "97")
                                {
                                    oHoja.Cells[InicioLinea, 25].Value = Convert.ToDateTime(item.fecDocumentoRef).ToString("d");
                                    oHoja.Cells[InicioLinea, 26].Value = item.idDocumentoRef;
                                    oHoja.Cells[InicioLinea, 27].Value = item.serDocumentoRef;
                                    oHoja.Cells[InicioLinea, 28].Value = item.numDocumentoRef;
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 25].Value = " ";
                                    oHoja.Cells[InicioLinea, 26].Value = " ";
                                    oHoja.Cells[InicioLinea, 27].Value = " ";
                                    oHoja.Cells[InicioLinea, 28].Value = " ";
                                }

                                SubTot1 += item.BaseGravado;
                                SubTot2 += item.IgvGrabado;
                                SubTot3 += item.BaseGravadoNoGravado;
                                SubTot4 += item.IgvGravadoNoGravado;
                                SubTot5 += item.BaseSinDerecho;
                                SubTot6 += item.IgvSinDerecho;
                                SubTot7 += item.BaseNoGravado;
                                SubTot8 += item.ISC;
                                SubTot9 += item.Otros;
                                SubTot10 += item.Total;


                                InicioLinea++;
                            }
                        }
                        if (item.RazonSocial == "TOTALES ACUMULADOS")
                        {
                            item.Total = 0;
                            item.BaseGravado = 0;
                            item.IgvGrabado = 0;
                            item.BaseNoGravado = 0;
                            item.VariacionIgv = 0;
                            contador++;
                        }
                        if (item.RazonSocial != "TOTALES ACUMULADOS")
                        {
                            contador++;
                        }

                    }

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = "";
                    oHoja.Cells[InicioLinea, 2].Value = "";
                    oHoja.Cells[InicioLinea, 3].Value = "";
                    oHoja.Cells[InicioLinea, 4].Value = "";
                    oHoja.Cells[InicioLinea, 5].Value = "";
                    oHoja.Cells[InicioLinea, 6].Value = "";
                    oHoja.Cells[InicioLinea, 7].Value = "";
                    oHoja.Cells[InicioLinea, 8].Value = "";
                    oHoja.Cells[InicioLinea, 9].Value = "";
                    oHoja.Cells[InicioLinea, 10].Value = "SUB TOTALES";
                    oHoja.Cells[InicioLinea, 11].Value = SubTot1;
                    oHoja.Cells[InicioLinea, 12].Value = SubTot2;
                    oHoja.Cells[InicioLinea, 13].Value = SubTot3;
                    oHoja.Cells[InicioLinea, 14].Value = SubTot4;
                    oHoja.Cells[InicioLinea, 15].Value = SubTot5;
                    oHoja.Cells[InicioLinea, 16].Value = SubTot6;
                    oHoja.Cells[InicioLinea, 17].Value = SubTot7;
                    oHoja.Cells[InicioLinea, 18].Value = SubTot8;
                    oHoja.Cells[InicioLinea, 19].Value = SubTot9;
                    oHoja.Cells[InicioLinea, 20].Value = SubTot10;
                    oHoja.Cells[InicioLinea, 21].Value = "";
                    oHoja.Cells[InicioLinea, 22].Value = "";
                    oHoja.Cells[InicioLinea, 23].Value = "";
                    oHoja.Cells[InicioLinea, 24].Value = "";
                    oHoja.Cells[InicioLinea, 25].Value = "";
                    oHoja.Cells[InicioLinea, 26].Value = "";
                    oHoja.Cells[InicioLinea, 27].Value = "";
                    oHoja.Cells[InicioLinea, 28].Value = "";

                    for (int i = 10; i <= 20; i++)
                    {

                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                    }

                    SubTot1 = 0;
                    SubTot2 = 0;
                    SubTot3 = 0;
                    SubTot4 = 0;
                    SubTot5 = 0;
                    SubTot6 = 0;
                    SubTot7 = 0;
                    SubTot8 = 0;
                    SubTot9 = 0;
                    SubTot10 = 0;


                    // FORMAT 
                    oHoja.Cells[InicioLinea, 11, InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;



                    // totales
                    oHoja.Cells[InicioLinea, 1].Value = "";
                    oHoja.Cells[InicioLinea, 2].Value = "";
                    oHoja.Cells[InicioLinea, 3].Value = "";
                    oHoja.Cells[InicioLinea, 4].Value = "";
                    oHoja.Cells[InicioLinea, 5].Value = "";
                    oHoja.Cells[InicioLinea, 6].Value = "";
                    oHoja.Cells[InicioLinea, 7].Value = "";
                    oHoja.Cells[InicioLinea, 8].Value = "";
                    oHoja.Cells[InicioLinea, 9].Value = "";
                    oHoja.Cells[InicioLinea, 10].Value = "TOTAL GENERAL";
                    oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    oHoja.Cells[InicioLinea, 11].Value = oListaRegistroCompras.Sum(x => x.BaseGravado);
                    oHoja.Cells[InicioLinea, 12].Value = oListaRegistroCompras.Sum(x => x.IgvGrabado);
                    oHoja.Cells[InicioLinea, 13].Value = oListaRegistroCompras.Sum(x => x.BaseGravadoNoGravado);
                    oHoja.Cells[InicioLinea, 14].Value = oListaRegistroCompras.Sum(x => x.IgvGravadoNoGravado);
                    oHoja.Cells[InicioLinea, 15].Value = oListaRegistroCompras.Sum(x => x.BaseSinDerecho);
                    oHoja.Cells[InicioLinea, 16].Value = oListaRegistroCompras.Sum(x => x.IgvSinDerecho);
                    oHoja.Cells[InicioLinea, 17].Value = oListaRegistroCompras.Sum(x => x.BaseNoGravado);
                    oHoja.Cells[InicioLinea, 18].Value = oListaRegistroCompras.Sum(x => x.ISC);
                    oHoja.Cells[InicioLinea, 19].Value = oListaRegistroCompras.Sum(x => x.Otros);
                    oHoja.Cells[InicioLinea, 20].Value = oListaRegistroCompras.Sum(x => x.Total);
                    oHoja.Cells[InicioLinea, 21].Value = "";
                    oHoja.Cells[InicioLinea, 22].Value = "";
                    oHoja.Cells[InicioLinea, 23].Value = "";
                    oHoja.Cells[InicioLinea, 24].Value = "";
                    oHoja.Cells[InicioLinea, 25].Value = "";
                    oHoja.Cells[InicioLinea, 26].Value = "";
                    oHoja.Cells[InicioLinea, 27].Value = "";
                    oHoja.Cells[InicioLinea, 28].Value = "";

                    // FORMAT 
                    oHoja.Cells[InicioLinea, 11, InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";


                    InicioLinea++;








                    //FIN SUMATORIA //

                    #endregion

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();

                        if (oListaImportadas.Count > Variables.Cero)
                        {
                            CargarOtros(oExcel, "Importadas", oListaImportadas);
                        }

                        if (oListaNacionales.Count > Variables.Cero)
                        {
                            CargarOtros(oExcel, "Nacionales", oListaNacionales);
                        }

                        if (oListaDuas != null && oListaDuas.Count > Variables.Cero)
                        {
                            CargarOtros(oExcel, "Duas", oListaDuas);
                        }

                        #region Propiedades del Excel

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
                        oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

                        // Establecer algunos valores de las propiedades extendidas
                        oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                        //Propiedades para imprimir
                        oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                        oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                        #endregion

                        //Guardando el excel
                        oExcel.Save();
                    
                }
            }
        }

        void CargarOtros(ExcelPackage oExcel, String NombrePestaña, List<RegistroComprasE> oListaTmp)
        { 
            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

            Int32 Fila = 1;
            //Int32 TotColumnas = 28;

            #region Cabecera

            #region Primera Linea Cabecera

            using (ExcelRange Rango = oHoja.Cells[Fila, 1, 3, 1])
            {
                Rango.Merge = true;
                Rango.Value = "Cod. Uni. de la Ope.";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 2, 3, 2])
            {
                Rango.Merge = true;
                Rango.Value = "Fecha de Emisión del Documento";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 3, 3, 3])
            {
                Rango.Merge = true;
                Rango.Value = "Fecha de Venc. y/o Pago";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 4, 2, 6])
            {
                Rango.Merge = true;
                Rango.Value = "Comprobante de Pago ó Documento";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 7, 3, 7])
            {
                Rango.Merge = true;
                Rango.Value = "Nro. Comprobante de Pago";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 8, Fila, 10])
            {
                Rango.Merge = true;
                Rango.Value = "Información del Proveedor";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 11, 2, 12])
            {
                Rango.Merge = true;
                Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 13, 2, 14])
            {
                Rango.Merge = true;
                Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación y a Operaciones no Gravadas";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 15, 2, 16])
            {
                Rango.Merge = true;
                Rango.Value = "Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación y a Operaciones no Gravadas ";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 17, 3, 17])
            {
                Rango.Merge = true;
                Rango.Value = "Valor de las Adquisiciones no Gravadas";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 18, 3, 18])
            {
                Rango.Merge = true;
                Rango.Value = "ISC";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 19, 3, 19])
            {
                Rango.Merge = true;
                Rango.Value = "Otros Tributos y Cargos";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 20, 3, 20])
            {
                Rango.Merge = true;
                Rango.Value = "Importe Total";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 21, 3, 21])
            {
                Rango.Merge = true;
                Rango.Value = "Nº de Comprobantes de Pago Emitido por Sujeto no Domiciliario";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 22, 2, 23])
            {
                Rango.Merge = true;
                Rango.Value = "Costancia de Déposito de Detración";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 24, 3, 24])
            {
                Rango.Merge = true;
                Rango.Value = "Tipo de Cambio";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 25, 3, 28])
            {
                Rango.Merge = true;
                Rango.Value = "Referencia  de Comprobantes de Pago o Documento Original que se modififca";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            #endregion

            Fila++;

            #region Segunda Linea Cabecera

            using (ExcelRange Rango = oHoja.Cells[Fila, 8, Fila, 9])
            {
                Rango.Merge = true;
                Rango.Value = "Doc. de Identidad";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            using (ExcelRange Rango = oHoja.Cells[Fila, 10, 3, 10])
            {
                Rango.Merge = true;
                Rango.Value = "Apellidos y Nombres ó Razón Social";
                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                Rango.Style.Font.Bold = true;
                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
            }

            #endregion

            Fila++;

            #region Tercera Linea Cabecera

            oHoja.Row(Fila).Height = 30;

            oHoja.Cells[Fila, 4].Value = "Tipo";
            oHoja.Cells[Fila, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 4].Style.Font.Bold = true;
            oHoja.Cells[Fila, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 5].Value = "Serie o Cod de la Dep. Adu.";
            oHoja.Cells[Fila, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 5].Style.Font.Bold = true;
            oHoja.Cells[Fila, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 6].Value = "Año de la Emision de la Dua";
            oHoja.Cells[Fila, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 6].Style.Font.Bold = true;
            oHoja.Cells[Fila, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 8].Value = "Tipo";
            oHoja.Cells[Fila, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 8].Style.Font.Bold = true;
            oHoja.Cells[Fila, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 9].Value = "Nùmero";
            oHoja.Cells[Fila, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 9].Style.Font.Bold = true;
            oHoja.Cells[Fila, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 11].Value = "Base Imponible";
            oHoja.Cells[Fila, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 11].Style.Font.Bold = true;
            oHoja.Cells[Fila, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 12].Value = "IGV";
            oHoja.Cells[Fila, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 12].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 12].Style.Font.Bold = true;
            oHoja.Cells[Fila, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 13].Value = "Base Imponible";
            oHoja.Cells[Fila, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 13].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 13].Style.Font.Bold = true;
            oHoja.Cells[Fila, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 14].Value = "IGV";
            oHoja.Cells[Fila, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 14].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 14].Style.Font.Bold = true;
            oHoja.Cells[Fila, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 14].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 15].Value = "Base Imponible";
            oHoja.Cells[Fila, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 15].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 15].Style.Font.Bold = true;
            oHoja.Cells[Fila, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 15].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 16].Value = "IGV";
            oHoja.Cells[Fila, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 16].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 16].Style.Font.Bold = true;
            oHoja.Cells[Fila, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 16].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 22].Value = "Número";
            oHoja.Cells[Fila, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 22].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 22].Style.Font.Bold = true;
            oHoja.Cells[Fila, 22].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 23].Value = "Fecha de Emisión";
            oHoja.Cells[Fila, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 23].Style.Font.Bold = true;
            oHoja.Cells[Fila, 23].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 23].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 25].Value = "Fecha";
            oHoja.Cells[Fila, 25].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 25].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 25].Style.Font.Bold = true;
            oHoja.Cells[Fila, 25].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 26].Value = "Tipo";
            oHoja.Cells[Fila, 26].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 26].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 26].Style.Font.Bold = true;
            oHoja.Cells[Fila, 26].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 26].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 27].Value = "Serie";
            oHoja.Cells[Fila, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 27].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 27].Style.Font.Bold = true;
            oHoja.Cells[Fila, 27].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            oHoja.Cells[Fila, 28].Value = "Nº Documento";
            oHoja.Cells[Fila, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
            oHoja.Cells[Fila, 28].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
            oHoja.Cells[Fila, 28].Style.Font.Bold = true;
            oHoja.Cells[Fila, 28].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            oHoja.Cells[Fila, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            oHoja.Cells[Fila, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

            #endregion
                    
            #endregion

            //Aumentando una Fila mas continuar con el detalle
            Fila++;

            #region Detalle

            foreach (RegistroComprasE item in oListaTmp)
            {
                oHoja.Cells[Fila, 1].Value = item.Correlativo;
                oHoja.Cells[Fila, 2].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");

                if (item.fecVencimiento != null)
                {
                    oHoja.Cells[Fila, 3].Value = Convert.ToDateTime(item.fecVencimiento).ToString("d");    
                }
                else
                {
                    oHoja.Cells[Fila, 3].Value = " ";
                }

                oHoja.Cells[Fila, 4].Value = item.tipDocumentoVenta;
                oHoja.Cells[Fila, 5].Value = item.serDocumento;
                oHoja.Cells[Fila, 6].Value = item.Dua;
                oHoja.Cells[Fila, 7].Value = item.numDocumento;
                oHoja.Cells[Fila, 8].Value = item.tipDocPersona;
                oHoja.Cells[Fila, 9].Value = item.RUC;
                oHoja.Cells[Fila, 10].Value = item.RazonSocial;

                oHoja.Cells[Fila, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 11].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 11].Value = item.BaseGravado;
                oHoja.Cells[Fila, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 12].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 12].Value = item.IgvGrabado;
                oHoja.Cells[Fila, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 13].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 13].Value = item.BaseGravadoNoGravado;
                oHoja.Cells[Fila, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 14].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 14].Value = item.IgvGravadoNoGravado;
                oHoja.Cells[Fila, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 15].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 15].Value = item.BaseSinDerecho;
                oHoja.Cells[Fila, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 16].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 16].Value = item.IgvSinDerecho;
                oHoja.Cells[Fila, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 17].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 17].Value = item.BaseNoGravado;
                oHoja.Cells[Fila, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 18].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 18].Value = item.ISC;
                oHoja.Cells[Fila, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 19].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 19].Value = item.Otros;
                oHoja.Cells[Fila, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                oHoja.Cells[Fila, 20].Style.Numberformat.Format = "###,###,##0.00";
                oHoja.Cells[Fila, 20].Value = item.Total;

                oHoja.Cells[Fila, 21].Value = item.docDomiciliado;
                oHoja.Cells[Fila, 22].Value = item.numDetraccion;

                if (item.fecDetraccion != null)
                {
                    oHoja.Cells[Fila, 23].Value = Convert.ToDateTime(item.fecDetraccion).ToString("d");    
                }
                else
                {
                    oHoja.Cells[Fila, 23].Value = " ";
                }
                            
                oHoja.Cells[Fila, 24].Value = item.tipCambio;

                if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "08" || item.tipDocumentoVenta == "97")
                {
                    oHoja.Cells[Fila, 25].Value = Convert.ToDateTime(item.fecDocumentoRef).ToString("d");
                    oHoja.Cells[Fila, 26].Value = item.idDocumentoRef;
                    oHoja.Cells[Fila, 27].Value = item.serDocumentoRef;
                    oHoja.Cells[Fila, 28].Value = item.numDocumentoRef;
                }
                else
                {
                    oHoja.Cells[Fila, 25].Value = " ";
                    oHoja.Cells[Fila, 26].Value = " ";
                    oHoja.Cells[Fila, 27].Value = " ";
                    oHoja.Cells[Fila, 27].Value = " ";
                } 
             
                Fila++;
            }

            #endregion Detalle

            //Ajustando el ancho de las columnas automaticamente
            oHoja.Cells.AutoFitColumns();
        }

        #endregion

        #region Procesos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaRegistroCompras.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string dia = VariablesLocales.FechaHoy.Date.Day.ToString("00");
                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Compras (" + dia + "-" + mes + "-" + anio + ")", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = Variables.Cero;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Importando los Registro de Compras a Excel...";
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
            DateTime fecInicial = dtpFecIni.Value.Date;
            DateTime fecFin = dtpFecFin.Value.Date;
            String idMoneda = cboMonedas.SelectedValue.ToString();
            Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
            String indCompras = Variables.NO;

            if (rbSi.Checked)
            {
                indCompras = "I";
            }

            if (rbSolo.Checked)
            {
                indCompras = Variables.SI;
            }

            if (tipoProceso == 1 || tipoProceso == 2)
            {
                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el Registro de Compras...";
                if (tipoProceso == 1)
                {
                    oListaRegistroCompras = AgenteContabilidad.Proxy.RegistroDeComprasLe(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, fecInicial, fecFin, idMoneda, indCompras);
                }
                else
                {
                    oListaRegistroCompras = AgenteContabilidad.Proxy.RegistroDeComprasLeNoDom(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, fecInicial, fecFin, idMoneda);
                }

                    if (oListaRegistroCompras.Count > Variables.Cero)
                    {
                        RegistroComprasE oRegComprasTotal = new RegistroComprasE()
                        {
                            fecDocumento = (Nullable<DateTime>)null,
                            fecVencimiento = (Nullable<DateTime>)null,
                            RazonSocial = "         TOTALES ACUMULADOS >>>>>>>>>>",
                            BaseGravado = (from x in oListaRegistroCompras select x.BaseGravado).Sum(),
                            IgvGrabado = (from x in oListaRegistroCompras select x.IgvGrabado).Sum(),
                            BaseGravadoNoGravado = (from x in oListaRegistroCompras select x.BaseGravadoNoGravado).Sum(),
                            IgvGravadoNoGravado = (from x in oListaRegistroCompras select x.IgvGravadoNoGravado).Sum(),
                            BaseSinDerecho = (from x in oListaRegistroCompras select x.BaseSinDerecho).Sum(),
                            IgvSinDerecho = (from x in oListaRegistroCompras select x.IgvSinDerecho).Sum(),
                            BaseNoGravado = (from x in oListaRegistroCompras select x.BaseNoGravado).Sum(),
                            ISC = (from x in oListaRegistroCompras select x.ISC).Sum(),
                            Otros = (from x in oListaRegistroCompras select x.Otros).Sum(),
                            Total = (from x in oListaRegistroCompras select x.Total).Sum(),
                         };                     

                    oListaRegistroCompras.Add(oRegComprasTotal);
                }
                
                lblProcesando.Text = "Armando el Reporte de Registro de Compras...";
                ConvertirApdf();//Generando el PDF
            }
            else if (tipoProceso == 3)
            {
                ExportarExcelNoDom(RutaGeneral);
            }
            else if(tipoProceso == 4)
            {
                oListaRegistroCompras = new List<RegistroComprasE>();
                oListaRegistroCompras = AgenteContabilidad.Proxy.RegistroDeComprasLe(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, fecInicial, fecFin, idMoneda, indCompras);
                ExportarExcelFile(RutaGeneral);
            }
            else 
            {
                ExportarExcel(RutaGeneral);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;
            btPle.Enabled = true;
            btPdb.Enabled = true;
            btExcelNoDom.Enabled = true;
            pnlParametros.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (tipoProceso == 1 || tipoProceso == 2)
            {
                //Mostrando el reporte en un web browser
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                    tipoProceso = 0;
                }
            }
            else
            {
                Global.MensajeComunicacion("Exportación Exitosa.");
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmReporteRegistroComprasLe_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
            {
                pnlOtros.Visible = true;
                btNoDom.Visible = false;
                btExcelNoDom.Visible = false;
            }
            else
            {
                pnlOtros.Visible = false;
                btNoDom.Visible = true;
                btExcelNoDom.Visible = true;
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFecIni.Value.Year != dtpFecFin.Value.Year)
                {
                    Global.MensajeComunicacion("No puede ser diferente año");
                    return;
                }

                if (dtpFecIni.Value.Month != dtpFecFin.Value.Month)
                {
                    Global.MensajeComunicacion("No puede ser diferente mes");
                    return;
                }

                tipoProceso = 1;
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                btPle.Enabled = false;
                btPdb.Enabled = false;
                
                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                btPle.Enabled = true;
                btPdb.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void btPle_Click(object sender, EventArgs e)
        {
            Int32 Linea = Variables.Cero;
            String Correlativo = String.Empty;

            try
            {
                #region Validaciones

                if (oListaRegistroCompras != null)
                {
                    if (oListaRegistroCompras.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar al Libro Electrónico.");
                        return;
                    }
                }
                else
                {
                    Global.MensajeFault("No hay datos para exportar al Libro Electrónico.");
                    return;
                }

                if (Global.MensajeConfirmacion("Desea generar el Archivo del Registro de Compras para el PLE") == DialogResult.No)
                {
                    return;
                } 

                #endregion

                #region Nombres de Archivos

                String NombreArchivo = String.Empty;
                String NombreArchivo2 = String.Empty;

                // Nacionales
                if (oListaRegistroCompras.Count > Variables.Cero)
                {
                    NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + oListaRegistroCompras[0].Periodo.Substring(0, 4) + oListaRegistroCompras[0].Periodo.Substring(4, 2) + "00080100001111";
                }
                else
                {
                    NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + oListaRegistroCompras[0].Periodo.Substring(0, 4) + oListaRegistroCompras[0].Periodo.Substring(4, 2) + "00080100001011";
                }

                //No Domiciliados
                Int32 cantNoDomiciliados = (from x in oListaRegistroCompras
                                            where (x.tipDocumentoVenta == "91" || x.tipDocumentoVenta == "97" || x.tipDocumentoVenta == "98")
                                            //|| (x.idDocumentoRef == "91" || x.idDocumentoRef == "97" || x.idDocumentoRef == "98")
                                            select x).Count();

                if (cantNoDomiciliados > Variables.Cero)
                {
                    NombreArchivo2 = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + oListaRegistroCompras[0].Periodo.Substring(0, 4) + oListaRegistroCompras[0].Periodo.Substring(4, 2) + "00080200001111.txt";
                }
                else
                {
                    NombreArchivo2 = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + oListaRegistroCompras[0].Periodo.Substring(0, 4) + oListaRegistroCompras[0].Periodo.Substring(4, 2) + "00080200001011.txt";
                }

                String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");
                String RutaArchivoTexto2 = RutaArchivoTexto.Replace(NombreArchivo + ".txt", NombreArchivo2);

                #endregion

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    #region Borrando los archivos si existieran

                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    if (File.Exists(RutaArchivoTexto2))
                    {
                        File.Delete(RutaArchivoTexto2);
                    }
                    
                    #endregion

                    #region Exportacion a un archivo de texto

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        using (StreamWriter oSw2 = new StreamWriter(RutaArchivoTexto2, true, Encoding.Default))
                        {
                            #region Variables
                            
                            StringBuilder Cadena = new StringBuilder();

                            String fecDocumento = String.Empty;
                            String fecVencimiento = String.Empty;
                            String tipDocumento = String.Empty;
                            String Serie_ = String.Empty;
                            String AnioEmisDua = String.Empty;
                            String numDocumento_ = String.Empty;
                            String OperacionesDiarias = String.Empty;
                            String tipDocPersona_ = String.Empty;
                            String numDocIdentidad = String.Empty;
                            String RazonSocial_ = String.Empty;
                            String tipDocVentaRef = String.Empty;
                            String SerieRef = String.Empty;
                            String NumeroRef = String.Empty;
                            String fecRef = String.Empty;
                            String fecDetraccion = String.Empty;
                            String numDetraccion = String.Empty;
                            String MarcaDetraccion = String.Empty;
                            String Dua_ = String.Empty;
                            String TipoCambio = String.Empty;
                            String Convenio = "00";
                            String Exoneracion = String.Empty;
                            String ModalidadServicio = "1";
                            String Aplicacionart76 = String.Empty;
                            String Estado = "1";
                            String DepAduanera_ = String.Empty;
                            #endregion

                            foreach (RegistroComprasE item in oListaRegistroCompras)
                            {
                                if (item.fecDocumento != null && item.tipDocumentoVenta != null && item.tipDocPersona != null)
                                {
                                    Linea++;
                                    Correlativo = item.Correlativo;
                                    tipDocumento = item.tipDocumentoVenta.Trim();

                                    /*
                                        *  Otros
                                        *  Comprobante de No Domiciliado
                                        *  Nota de Crédito - No Domiciliado
                                        *  Nota de Débito - No Domiciliado
                                    */
                                    // NO DOMICILIADOS
                                    if (tipDocumento == ".00" || 
                                        tipDocumento == "91" || 
                                        tipDocumento == "97" || 
                                        tipDocumento == "98")
                                    {
                                        #region Fechas

                                        if (item.fecDocumento != null)
                                        {
                                            fecDocumento = Convert.ToDateTime(item.fecDocumento).ToString("d");
                                        }
                                        else
                                        {
                                            fecDocumento = String.Empty;
                                        }

                                        if (String.IsNullOrEmpty(fecDocumento))
                                        {
                                            throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2} no tiene fecha de emisión revisar.", item.Correlativo, item.serDocumento, item.numDocumento));
                                        }

                                        #endregion

                                        #region Serie del Documento

                                        Serie_ = String.Empty;

                                        //if (Global.EsNumero(item.serDocumento.Substring(0, 1)))
                                        //{
                                        //    Serie_ = item.serDocumento.Trim();

                                        //    if (!String.IsNullOrEmpty(Serie_))
                                        //    {
                                        //        if (Serie_.Length <= 20)
                                        //        {
                                        //            Serie_ = item.serDocumento.Trim(); //String.Format("{0:00000000000000000000}", Convert.ToInt32(item.serDocumento));
                                        //        }
                                        //        else
                                        //        {
                                        //            Serie_ = Global.Derecha(Serie_, 20);
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        Serie_ = String.Empty;
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    if (!String.IsNullOrEmpty(item.serDocumento))
                                        //    {
                                        //        Serie_ = item.serDocumento.Trim();
                                        //    }
                                        //    else
                                        //    {
                                        //        Serie_ = String.Empty;
                                        //    }
                                        //}

                                        #endregion

                                        #region Número del Documento

                                        if (item.numDocumento.Trim().Length <= 20)
                                        {
                                            numDocumento_ = item.numDocumento.Trim(); // String.Format("{0:00000000000000000000}", Convert.ToInt32(item.numDocumento));
                                        }
                                        else
                                        {
                                            numDocumento_ = Global.Derecha(item.numDocumento.Trim(), 20);
                                        }

                                        #endregion

                                        #region Identificacion del Auxiliar o Persona

                                        tipDocPersona_ = item.tipDocPersona.Trim();
                                        RazonSocial_ = item.RazonSocial;

                                        if (RazonSocial_.Length > 100)
                                        {
                                            RazonSocial_ = RazonSocial_.Substring(0, 100);
                                        }

                                        numDocIdentidad = item.RUC.Trim().ToString().Replace("-", "").Replace(".", "").Replace(" ", "");

                                        #endregion

                                        #region Documento de Referencia

                                        if (item.idDocumentoRef == "00" ||
                                            item.idDocumentoRef == "46" || 
                                            item.idDocumentoRef == "50" || 
                                            item.idDocumentoRef == "51" || 
                                            item.idDocumentoRef == "52" ||
                                            item.idDocumentoRef == "53")
                                        {
                                            fecRef = Convert.ToDateTime(item.fecDocumentoRef).ToString("dd/MM/yyyy");
                                            tipDocVentaRef = item.idDocumentoRef;

                                            #region Serie

                                            if (!String.IsNullOrEmpty(item.serDocumentoRef.Trim()) && item.serDocumentoRef.Length > 0)
                                            {
                                                if (Global.EsNumero(item.serDocumentoRef.Substring(0, 1)))
                                                {
                                                    if (tipDocVentaRef == "50" || tipDocVentaRef == "51" || tipDocVentaRef == "52" || tipDocVentaRef == "53")
                                                    {
                                                        SerieRef = item.serDocumentoRef.Trim();

                                                        if (SerieRef.Length < 3)
                                                        {
                                                            SerieRef = String.Format("{0:000}", Convert.ToInt32(SerieRef));
                                                        }
                                                        else
                                                        {
                                                            SerieRef = Global.Derecha(item.serDocumentoRef.Trim(), 3);
                                                        }
                                                    }
                                                    else if (tipDocVentaRef == "00")
                                                    {
                                                        SerieRef = item.serDocumentoRef;

                                                        if (!String.IsNullOrEmpty(SerieRef.Trim()))
                                                        {
                                                            if (SerieRef.Length <= 20)
                                                            {
                                                                SerieRef = item.serDocumentoRef.Trim(); // String.Format("{0:00000000000000000000}", Convert.ToInt32(item.serDocumentoRef));
                                                            }
                                                            else
                                                            {
                                                                SerieRef = Global.Derecha(item.serDocumentoRef.Trim(), 20);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            SerieRef = String.Empty;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    SerieRef = item.serDocumentoRef.Trim();
                                                }
                                            }
                                            else
                                            {
                                                SerieRef = String.Empty;
                                            }

                                            #endregion

                                            #region Número

                                            if (tipDocVentaRef == "50" || tipDocVentaRef == "51" || tipDocVentaRef == "52" || tipDocVentaRef == "53")
                                            {
                                                NumeroRef = item.numDocumentoRef.Trim();

                                                if (!String.IsNullOrEmpty(item.numDocumentoRef.Trim()) && item.numDocumentoRef.Length > 0)
                                                {
                                                    if (item.numDocumentoRef.Length < 6)
                                                    {
                                                        NumeroRef = String.Format("{0:000000}", Convert.ToInt32(NumeroRef));
                                                    }
                                                    else
                                                    {
                                                        NumeroRef = Global.Derecha(NumeroRef, 6);
                                                    }
                                                }
                                                else
                                                {
                                                    NumeroRef = String.Empty;
                                                }
                                            }
                                            else if (tipDocVentaRef == "00")
                                            {
                                                NumeroRef = item.numDocumentoRef.Trim();

                                                if (NumeroRef.Length <= 20)
                                                {
                                                    NumeroRef = item.numDocumentoRef.Trim(); //String.Format("{0:00000000000000000000}", Convert.ToInt32(item.numDocumentoRef));
                                                }
                                                else
                                                {
                                                    NumeroRef = Global.Derecha(item.numDocumentoRef.Trim(), 20);
                                                }
                                            }

                                            #endregion

                                            #region DUA

                                            if (item.idDocumentoRef == "50" || item.idDocumentoRef == "52")
                                            {
                                                Dua_ = item.Dua;

                                                if (String.IsNullOrEmpty(Dua_))
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2} necesita DUA.", item.Correlativo, item.serDocumentoRef, item.numDocumentoRef));
                                                }
                                            }
                                            else
                                            {
                                                Dua_ = String.Empty;
                                            }

                                            #endregion
                                        }
                                        else
                                        {
                                            fecRef = "01/01/0001";
                                            tipDocVentaRef = String.Empty;
                                            SerieRef = String.Empty;
                                            NumeroRef = String.Empty;
                                            Dua_ = String.Empty;
                                            
                                        }

                                        #endregion

                                        #region Año de Emision de la Dua

                                        if (item.idDocumentoRef == "50" || item.idDocumentoRef == "52")
                                        {
                                            AnioEmisDua = item.AnioDua;

                                            if (String.IsNullOrEmpty(AnioEmisDua))
                                            {
                                                throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, es obligatorio colocar el Año de Emisión de la Dua", item.Correlativo, item.serDocumento, item.numDocumento));
                                            }
                                        }
                                        else
                                        {
                                            AnioEmisDua = String.Empty;
                                        }

                                        #endregion


                                        #region Dependencia Aduanera

                                        if (item.idDocumentoRef == "50" || item.idDocumentoRef == "52")
                                        {
                                            DepAduanera_ = item.depAduanera;

                                            if (String.IsNullOrEmpty(DepAduanera_))
                                            {
                                                throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, es obligatorio colocar Dependencia Aduanera", item.Correlativo, item.serDocumento, item.numDocumento));
                                            }
                                        }
                                        else
                                        {
                                            DepAduanera_ = String.Empty;
                                        }

                                        #endregion

                                        #region Tipo de Cambio

                                        if (item.Moneda != "PEN")
                                        {
                                            TipoCambio = item.tipCambio.ToString("#####0.000");
                                        }
                                        else
                                        {
                                            TipoCambio = "0.000";
                                        }

                                        #endregion

                                        #region Detraccion

                                        if (item.flagDetraccion == Variables.SI)
                                        {
                                            fecDetraccion = Convert.ToDateTime(item.fecDetraccion).ToString("dd/MM/yyyy");
                                            numDetraccion = item.numDetraccion;
                                            MarcaDetraccion = "1";
                                        }
                                        else
                                        {
                                            fecDetraccion = "01/01/0001";
                                            numDetraccion = String.Empty;
                                            MarcaDetraccion = String.Empty;
                                        }

                                        #endregion

                                        if (String.IsNullOrEmpty(item.PaisOrigen))
                                        {
                                            throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2} es obligatorio colocar el pais de origen", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim()));
                                        }

                                        Estado = "0";

                                        Cadena.Append(item.Periodo).Append("|").Append(Correlativo).Append("|").Append(item.PrimerDigito).Append("|").Append(fecDocumento).Append("|");
                                        Cadena.Append(item.tipDocumentoVenta).Append("|").Append(Serie_).Append("|").Append(numDocumento_).Append("|");
                                        Cadena.Append(item.BaseNoGravado.ToString("#####0.00")).Append("|");
                                        Cadena.Append(item.Otros.ToString("#####0.00")).Append("|");
                                        Cadena.Append(item.Total.ToString("#####0.00")).Append("|");
                                        Cadena.Append(tipDocVentaRef).Append("|");
                                        Cadena.Append(DepAduanera_).Append("|");
                                        Cadena.Append(AnioEmisDua).Append("|");
                                        Cadena.Append(Dua_).Append("|");
                                        //Cadena.Append(NumeroRef).Append("|");
                                        Cadena.Append("0.00").Append("|").Append(item.Moneda).Append("|").Append(TipoCambio).Append("|").Append(item.PaisOrigen).Append("|").Append(RazonSocial_).Append("|");
                                        Cadena.Append(String.Empty).Append("|").Append(numDocIdentidad).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|");
                                        Cadena.Append(String.Empty).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|");
                                        Cadena.Append(String.Empty).Append("|").Append(Convenio).Append("|").Append(Exoneracion).Append("|").Append(item.TipoRenta).Append("|").Append(ModalidadServicio).Append("|");
                                        Cadena.Append(Aplicacionart76).Append("|").Append(Estado).Append("|");

                                        oSw2.WriteLine(Cadena.ToString());
                                    }
                                    else //PLE
                                    {
                                        #region Fechas

                                        if (item.fecDocumento != null)
                                        {
                                            fecDocumento = Convert.ToDateTime(item.fecDocumento).ToString("d");
                                        }
                                        else
                                        {
                                            fecDocumento = String.Empty;
                                        }

                                        if (String.IsNullOrEmpty(fecDocumento))
                                        {
                                            throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, no tiene fecha de emisión.", item.Correlativo, item.serDocumento, item.numDocumento));
                                        }

                                        if (item.tipDocumentoVenta.Trim() == "14")
                                        {
                                            if (item.fecVencimiento != null)
                                            {
                                                fecVencimiento = Convert.ToDateTime(item.fecVencimiento).ToString("d");
                                            }
                                            else
                                            {
                                                throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, es necesario colocar la fecha de vencimiento.", item.Correlativo, item.serDocumento, item.numDocumento));
                                            } 
                                        }
                                        else
                                        {
                                            fecVencimiento = String.Empty;
                                        }

                                        #endregion

                                        #region Serie del Documento

                                        if (tipDocumento == "05" || tipDocumento == "55")
                                        {
                                            if (tipDocumento == "05")
                                            {
                                                /*Consignar Tipo de Boleto:
                                                    1= Boleto Manual
                                                    2= Boleto Automático
                                                    3= Boleto Electrónico
                                                    4= Otros
                                                 */

                                                Serie_ = "3";
                                            }
                                            else
                                            {
                                                /*Consignar Tipo de Boleto:
                                                    1= Boleto Pre-Impreso
                                                    2= Boleto Electrónico
                                                 */

                                                Serie_ = "2";
                                            }
                                        }
                                        else
                                        {
                                            if (item.serDocumento.Length > 0 && Global.EsNumero(item.serDocumento.Substring(0, 1)))
                                            {
                                                Serie_ = item.serDocumento.Trim();

                                                //Igual a 3 caracteres
                                                if (tipDocumento == "50" || // Dua
                                                    tipDocumento == "51" || // 
                                                    tipDocumento == "52" || // Despacho Simplificado
                                                    tipDocumento == "53" || // Declaracion Mensajeria o Courier
                                                    tipDocumento == "54.")   // Liquidacion de Cobranza
                                                {
                                                    Serie_ = item.depAduanera;

                                                    if (String.IsNullOrEmpty(Serie_))
                                                    {
                                                        throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, tiene que tener Dependencia Aduanera", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim()));
                                                    }
                                                }//Igual a 4 Caracteres
                                                else if (tipDocumento == "01" || tipDocumento == "02" || tipDocumento == "03" || tipDocumento == "04" || tipDocumento == "06" 
                                                    || tipDocumento == "07" || tipDocumento == "08" || tipDocumento == "10" || tipDocumento == "22" || tipDocumento == "34" 
                                                    || tipDocumento == "35" || tipDocumento == "36" || tipDocumento == "46" || tipDocumento == "48" || tipDocumento == "56" 
                                                    || tipDocumento == "89")
                                                {
                                                    if (Serie_.Length < 4)
                                                    {
                                                        Serie_ = String.Format("{0:0000}", Convert.ToInt32(Serie_));
                                                    }
                                                    else
                                                    {
                                                        Serie_ = Global.Derecha(Serie_, 4);
                                                    }
                                                } //Hasta 4 caracteres
                                                else if (tipDocumento == "23" || tipDocumento == "25") 
                                                {
                                                    if (Serie_.Length > 4)
                                                    {
                                                        Serie_ = Global.Derecha(Serie_, 4);
                                                    }

                                                    if (!Global.EsNumero(Serie_))
                                                    {
                                                        throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, la serie tiene que ser solo números", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim()));
                                                    }
                                                }//Hasta 20 caracteres
                                                else if (tipDocumento == "00" || tipDocumento == "11" || tipDocumento == "13" || tipDocumento == "14" || tipDocumento == "15" 
                                                    || tipDocumento == "16" || tipDocumento == "17" || tipDocumento == "18" || tipDocumento == "19" || tipDocumento == "21" 
                                                    || tipDocumento == "24" || tipDocumento == "26" || tipDocumento == "27" || tipDocumento == "28" || tipDocumento == "29" 
                                                    || tipDocumento == "30" || tipDocumento == "32" || tipDocumento == "37" || tipDocumento == "42" || tipDocumento == "43"
                                                    || tipDocumento == "44" || tipDocumento == "45" || tipDocumento == "49" || tipDocumento == "87" || tipDocumento == "88" 
                                                    || tipDocumento == "91" || tipDocumento == "96" || tipDocumento == "97" || tipDocumento == "98")
                                                {
                                                    if (Serie_.Length > 20)
                                                    {
                                                        Serie_ = Global.Derecha(Serie_, 20);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Igual a 3 caracteres
                                                if (tipDocumento == "50" || // Dua
                                                    tipDocumento == "51" || 
                                                    tipDocumento == "52" || 
                                                    tipDocumento == "53" || 
                                                    tipDocumento == "54.")
                                                {
                                                    Serie_ = item.depAduanera;

                                                    if (String.IsNullOrEmpty(Serie_))
                                                    {
                                                        throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, tiene que tener Dependencia Aduanera", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim()));
                                                    }
                                                }
                                                else
                                                {
                                                    Serie_ = item.serDocumento.Trim();
                                                }                                                
                                            }
                                        }

                                        #endregion

                                        #region Año de Emision de la Dua

                                        if (tipDocumento == "50" || tipDocumento == "52")
                                        {
                                            AnioEmisDua = item.AnioDua;

                                            if (String.IsNullOrEmpty(AnioEmisDua))
                                            {
                                                throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, es obligatorio colocar el Año de Emisión de la Dua", item.Correlativo, item.serDocumento, item.numDocumento));
                                            }
                                        }
                                        else
                                        {
                                            AnioEmisDua = String.Empty;
                                        }

                                        #endregion

                                        #region Número del Documento

                                        numDocumento_ = item.numDocumento.Trim();

                                        //Hasta 8 digitos
                                        if (tipDocumento == "01" || tipDocumento == "03" || tipDocumento == "04" || tipDocumento == "06" || tipDocumento == "07" 
                                            || tipDocumento == "08" || tipDocumento == "36")
                                        {
                                            if (numDocumento_.Length < 8)
                                            {
                                                numDocumento_ = String.Format("{0:00000000}", Convert.ToInt32(numDocumento_));
                                            }
                                            else
                                            {
                                                numDocumento_ = Global.Derecha(numDocumento_, 8);
                                            }
                                        }//Hasta 7 digitos
                                        else if (tipDocumento == "02" || tipDocumento == "23" || tipDocumento == "25" || tipDocumento == "34" || tipDocumento == "35" 
                                            || tipDocumento == "48" || tipDocumento == "89")
                                        {
                                            if (item.numDocumento.Length < 7)
                                            {
                                                numDocumento_ = String.Format("{0:0000000}", Convert.ToInt32(numDocumento_));
                                            }
                                            else
                                            {
                                                numDocumento_ = Global.Derecha(numDocumento_, 7);
                                            }
                                        }//Hasta 6 digitos
                                        else if (tipDocumento == "50" || tipDocumento == "51" || tipDocumento == "52" || tipDocumento == "53")
                                        {
                                            if (item.numDocumento.Length < 6)
                                            {
                                                numDocumento_ = String.Format("{0:000000}", Convert.ToInt32(numDocumento_));
                                            }
                                            else
                                            {
                                                numDocumento_ = Global.Derecha(numDocumento_, 6);
                                            }
                                        }//Hasta 11 digitos
                                        else if (tipDocumento == "05" || tipDocumento == "55" || tipDocumento == "56")
                                        {
                                            if (item.numDocumento.Length > 11)
                                            {
                                                numDocumento_ = Global.Derecha(numDocumento_, 11);
                                            }
                                        } //Igual a 15 digitos
                                        else if (tipDocumento == "11")
                                        {
                                            if (item.numDocumento.Length > 15)
                                            {
                                                numDocumento_ = Global.Derecha(numDocumento_, 15);
                                            }
                                        }//Hasta 20 digitos
                                        else if (tipDocumento == "00" || tipDocumento == "10" || tipDocumento == "12" || tipDocumento == "13" || tipDocumento == "14" 
                                            || tipDocumento == "15" || tipDocumento == "16" || tipDocumento == "17" || tipDocumento == "18" || tipDocumento == "19" 
                                            || tipDocumento == "21" || tipDocumento == "22" || tipDocumento == "24" || tipDocumento == "26" || tipDocumento == "27" 
                                            || tipDocumento == "28" || tipDocumento == "29" || tipDocumento == "30" || tipDocumento == "32" || tipDocumento == "37"
                                            || tipDocumento == "42" || tipDocumento == "43" || tipDocumento == "44" || tipDocumento == "45" || tipDocumento == "46" 
                                            || tipDocumento == "49" || tipDocumento == "54" || tipDocumento == "87" || tipDocumento == "88" || tipDocumento == "91" 
                                            || tipDocumento == "96" || tipDocumento == "97" || tipDocumento == "98")
                                        {
                                            if (item.numDocumento.Length > 20)
                                            {
                                                numDocumento_ = Global.Derecha(item.numDocumento, 20);
                                            }
                                        }

                                        #endregion

                                        #region Identificacion del Auxiliar o Persona

                                        Boolean indPersona = false;

                                        if (tipDocumento == "00" ||
                                            tipDocumento == "03" ||
                                            tipDocumento == "05" || 
                                            tipDocumento == "06" ||
                                            tipDocumento == "07" ||
                                            tipDocumento == "08" ||
                                            tipDocumento == "11" || 
                                            tipDocumento == "12" || 
                                            tipDocumento == "13" || 
                                            tipDocumento == "14" ||
                                            tipDocumento == "15" ||
                                            tipDocumento == "16" ||
                                            tipDocumento == "18" ||
                                            tipDocumento == "19" ||
                                            tipDocumento == "22" ||
                                            tipDocumento == "23" ||
                                            tipDocumento == "26" ||
                                            tipDocumento == "28" ||
                                            tipDocumento == "30" ||
                                            tipDocumento == "34" ||
                                            tipDocumento == "35" ||
                                            tipDocumento == "36" ||
                                            tipDocumento == "37" ||
                                            tipDocumento == "55" ||
                                            tipDocumento == "56" ||
                                            tipDocumento == "87" ||
                                            tipDocumento == "88" || 
                                            tipDocumento == "91" || 
                                            tipDocumento == "97" ||
                                            tipDocumento == "98")
                                        {
                                            indPersona = false;
                                            tipDocPersona_ = String.Empty;
                                            numDocIdentidad = String.Empty;
                                            RazonSocial_ = String.Empty;
                                        }
                                        else
                                        {
                                            indPersona = true;
                                        }

                                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20476115711" || // SC Ingenieria
                                            VariablesLocales.SesionUsuario.Empresa.RUC == "20518390059" || // Siasmin
                                            VariablesLocales.SesionUsuario.Empresa.RUC == "20536039717" || // Nevados
                                            VariablesLocales.SesionUsuario.Empresa.RUC == "20543435661" || // Portafolio
                                            VariablesLocales.SesionUsuario.Empresa.RUC == "20515657119")  // Assa
                                        {
                                            indPersona = true;
                                        }


                                        #region Validando y Identificando Auxiliar o Persona

                                        if (indPersona)
                                        {
                                            tipDocPersona_ = item.tipDocPersona;

                                            if (item.RazonSocial.Length > 100)
                                            {
                                                RazonSocial_ = item.RazonSocial.Substring(0, 100);    
                                            }
                                            else
                                            {
                                                RazonSocial_ = item.RazonSocial;
                                            }

                                            if (String.IsNullOrEmpty(RazonSocial_))
                                            {
                                                throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, es obligatorio la Razón Social.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim()));
                                            }

                                            if (tipDocPersona_ == "0") //Otros
                                            {
                                                if (item.RUC.Length > 15) //Alfanumérico, longitud variable hasta 15 caracteres...
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} Otros no permite mas de 15 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else
                                                {
                                                    numDocIdentidad = item.RUC.ToString().Replace("-", "").Replace(".", "").Replace(" ", "");
                                                }
                                            }
                                            else if (tipDocPersona_ == "1") //DNI
                                            {
                                                if (item.RUC.Length > 8) //Númerico, longitud fija 8 caracteres...
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} DNI no permite más de 8 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else if (item.RUC.Length < 8)
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} DNI no permite menos de 8 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else
                                                {
                                                    if (!Global.EsNumero(item.RUC))
                                                    {
                                                        throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} DNI sólo permite números.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                    }
                                                    else
                                                    {
                                                        numDocIdentidad = item.RUC;
                                                    }
                                                }
                                            }
                                            else if (tipDocPersona_ == "4") //Carnet de Extranjeria
                                            {
                                                if (item.RUC.Length > 12) //Alfanumérico, longitud variable hasta 12 caracteres...
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} Carnet de Extranjeria no permite más de 12 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else
                                                {
                                                    numDocIdentidad = item.RUC.ToString().Replace("-", "").Replace(".", "").Replace(" ", "");
                                                }
                                            }
                                            else if (tipDocPersona_ == "6") //RUC
                                            {
                                                if (item.RUC.Length > 11) //Númerico, longitud fija 11 caracteres...
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} RUC no permite más de 11 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else if (item.RUC.Length < 11)
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} RUC no permite menos de 11 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else
                                                {
                                                    if (!Global.EsNumero(item.RUC))
                                                    {
                                                        throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} RUC sólo permite números.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                    }
                                                    else
                                                    {
                                                        numDocIdentidad = item.RUC;
                                                    }
                                                }
                                            }
                                            else if (tipDocPersona_ == "7") //Pasaporte
                                            {
                                                if (item.RUC.Length > 12) //Alfanumérico, longitud variable hasta 12 caracteres...
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} Pasaporte no permite más de 12 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else
                                                {
                                                    numDocIdentidad = item.RUC.ToString().Replace("-", "").Replace(".", "").Replace(" ", "");
                                                }
                                            }
                                            else if (tipDocPersona_ == "A") //Cédula Diplomática
                                            {
                                                if (item.RUC.Length > 15) //Númerico, longitud fija 15 caracteres...
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} Cédula Diplomática no permite más de 15 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else if (item.RUC.Length < 15)
                                                {
                                                    throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} Cédula Diplomática no permite menos de 15 caracteres.", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                }
                                                else
                                                {
                                                    if (!Global.EsNumero(item.RUC))
                                                    {
                                                        throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona {3} Cédula Diplomática sólo permite números", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim(), tipDocPersona_));
                                                    }
                                                    else
                                                    {
                                                        numDocIdentidad = item.RUC.ToString().Replace("-", "").Replace(".", "").Replace(" ", "");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, el tipo de documento de la persona desconocido", item.Correlativo, item.serDocumento.Trim(), item.numDocumento.Trim()));
                                            }
                                        }

                                        #endregion

                                        #endregion

                                        #region Documento de Referencia

                                        if (tipDocumento == "07" || tipDocumento == "08" || tipDocumento == "87" || tipDocumento == "88" || tipDocumento == "97" || tipDocumento == "98")
                                        {
                                            if (item.fecDocumentoRef == null)
                                            {
                                                throw new Exception(String.Format("En el Cód. Uni. Ope. {0} con el documento {1}-{2}, es obligatorio colocar la fecha del doc. de referencia", item.Correlativo, item.serDocumento, item.numDocumento));
                                            }

                                            fecRef = Convert.ToDateTime(item.fecDocumentoRef).ToString("dd/MM/yyyy");
                                            tipDocVentaRef = item.idDocumentoRef.Trim();

                                            #region Serie

                                            if (tipDocVentaRef == "05" || tipDocVentaRef == "55")
                                            {
                                                if (tipDocVentaRef == "05")
                                                {
                                                    /*Consignar Tipo de Boleto:
                                                        1= Boleto Manual
                                                        2= Boleto Automático
                                                        3= Boleto Electrónico
                                                        4= Otros*/

                                                    SerieRef = "3";
                                                }
                                                else
                                                {
                                                    /*Consignar Tipo de Boleto:
                                                        1= Boleto Pre-Impreso
                                                        2= Boleto Electrónico*/

                                                    SerieRef = "2";
                                                }
                                            }
                                            else
                                            {
                                                if (Global.EsNumero(item.serDocumentoRef.Substring(0, 1)))
                                                {
                                                    SerieRef = item.serDocumentoRef.Trim();

                                                    if (tipDocVentaRef == "50" || tipDocVentaRef == "51" || tipDocVentaRef == "52" || tipDocVentaRef == "53" || tipDocVentaRef == "54")
                                                    {
                                                        if (SerieRef.Length < 3)
                                                        {
                                                            SerieRef = String.Format("{0:000}", Convert.ToInt32(item.serDocumentoRef));
                                                        }
                                                        else
                                                        {
                                                            SerieRef = Global.Derecha(item.serDocumentoRef, 3);
                                                        }
                                                    }
                                                    else if (tipDocVentaRef == "01" || tipDocVentaRef == "02" || tipDocVentaRef == "03" || tipDocVentaRef == "04" || tipDocVentaRef == "06"
                                                        || tipDocVentaRef == "07" || tipDocVentaRef == "08" || tipDocVentaRef == "10" || tipDocVentaRef == "22" || tipDocVentaRef == "34"
                                                        || tipDocVentaRef == "35" || tipDocVentaRef == "36" || tipDocVentaRef == "46" || tipDocVentaRef == "48" || tipDocVentaRef == "56"
                                                        || tipDocVentaRef == "89" || tipDocVentaRef == "23" || tipDocVentaRef == "25") //Hasta 4 caracteres
                                                    {
                                                        if (SerieRef.Length < 4)
                                                        {
                                                            SerieRef = String.Format("{0:0000}", Convert.ToInt32(item.serDocumentoRef));
                                                        }
                                                        else
                                                        {
                                                            SerieRef = Global.Derecha(item.serDocumentoRef, 4);
                                                        }
                                                    }
                                                    else if (tipDocVentaRef == "00" || tipDocVentaRef == "11" || tipDocVentaRef == "13" || tipDocVentaRef == "14" || tipDocVentaRef == "15"
                                                        || tipDocVentaRef == "16" || tipDocVentaRef == "17" || tipDocVentaRef == "18" || tipDocVentaRef == "19" || tipDocVentaRef == "21"
                                                        || tipDocVentaRef == "24" || tipDocVentaRef == "26" || tipDocVentaRef == "27" || tipDocVentaRef == "28" || tipDocVentaRef == "29"
                                                        || tipDocVentaRef == "30" || tipDocVentaRef == "32" || tipDocVentaRef == "37" || tipDocVentaRef == "42" || tipDocVentaRef == "43"
                                                        || tipDocVentaRef == "44" || tipDocVentaRef == "45" || tipDocVentaRef == "49" || tipDocVentaRef == "87" || tipDocVentaRef == "88"
                                                        || tipDocVentaRef == "91" || tipDocVentaRef == "96" || tipDocVentaRef == "97" || tipDocVentaRef == "98")
                                                    {
                                                        if (!String.IsNullOrEmpty(Serie_.Trim()))
                                                        {
                                                            if (SerieRef.Length < 20)
                                                            {
                                                                SerieRef = String.Format("{0:00000000000000000000}", Convert.ToInt32(item.serDocumentoRef));
                                                            }
                                                            else
                                                            {
                                                                SerieRef = Global.Derecha(item.serDocumentoRef, 20);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            SerieRef = String.Empty;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    SerieRef = item.serDocumentoRef;
                                                }
                                            }

                                            #endregion

                                            #region Número

                                            NumeroRef = item.numDocumentoRef;

                                            if (tipDocVentaRef == "01" || tipDocVentaRef == "03" || tipDocVentaRef == "04" || tipDocVentaRef == "06" || tipDocVentaRef == "07" || tipDocVentaRef == "08"
                                                || tipDocVentaRef == "36")
                                            {
                                                if (item.numDocumentoRef.Length < 8)
                                                {
                                                    NumeroRef = String.Format("{0:00000000}", Convert.ToInt32(item.numDocumentoRef));
                                                }
                                                else
                                                {
                                                    NumeroRef = Global.Derecha(item.numDocumentoRef, 8);
                                                }
                                            }
                                            else if (tipDocVentaRef == "23" || tipDocVentaRef == "25" || tipDocVentaRef == "34" || tipDocVentaRef == "35" || tipDocVentaRef == "48" || tipDocVentaRef == "89")
                                            {
                                                if (item.numDocumento.Length < 7)
                                                {
                                                    NumeroRef = String.Format("{0:0000000}", Convert.ToInt32(item.numDocumentoRef));
                                                }
                                                else
                                                {
                                                    NumeroRef = Global.Derecha(item.numDocumentoRef, 7);
                                                }
                                            }
                                            else if (tipDocVentaRef == "50" || tipDocVentaRef == "51" || tipDocVentaRef == "52" || tipDocVentaRef == "53")
                                            {
                                                if (item.numDocumentoRef.Length < 6)
                                                {
                                                    NumeroRef = String.Format("{0:000000}", Convert.ToInt32(item.numDocumentoRef));
                                                }
                                                else
                                                {
                                                    NumeroRef = Global.Derecha(item.numDocumentoRef, 6);
                                                }
                                            }
                                            else if (tipDocVentaRef == "55" || tipDocVentaRef == "56")
                                            {
                                                if (item.numDocumentoRef.Length > 11)
                                                {
                                                    NumeroRef = Global.Derecha(item.numDocumentoRef, 11);
                                                }
                                            }
                                            else if (tipDocVentaRef == "11")
                                            {
                                                if (item.numDocumentoRef.Length > 15)
                                                {
                                                    NumeroRef = Global.Derecha(item.numDocumentoRef, 15);
                                                }
                                            }
                                            else if (tipDocVentaRef == "00" || tipDocVentaRef == "10" || tipDocVentaRef == "12" || tipDocVentaRef == "13" || tipDocVentaRef == "14" || tipDocVentaRef == "15"
                                                || tipDocVentaRef == "16" || tipDocVentaRef == "17" || tipDocVentaRef == "18" || tipDocVentaRef == "19" || tipDocVentaRef == "21" || tipDocVentaRef == "22"
                                                || tipDocVentaRef == "24" || tipDocVentaRef == "26" || tipDocVentaRef == "27" || tipDocVentaRef == "28" || tipDocVentaRef == "29" || tipDocVentaRef == "30"
                                                || tipDocVentaRef == "32" || tipDocVentaRef == "37" || tipDocVentaRef == "42" || tipDocVentaRef == "43" || tipDocVentaRef == "44" || tipDocVentaRef == "45"
                                                || tipDocVentaRef == "46" || tipDocVentaRef == "49" || tipDocVentaRef == "54" || tipDocVentaRef == "87" || tipDocVentaRef == "88" || tipDocVentaRef == "91"
                                                || tipDocVentaRef == "96" || tipDocVentaRef == "97" || tipDocVentaRef == "98")
                                            {
                                                if (item.numDocumentoRef.Length > 20)
                                                {
                                                //    NumeroRef = String.Format("{0:00000000000000000000}", Convert.ToInt32(item.numDocumentoRef));
                                                //}
                                                //else
                                                //{
                                                    NumeroRef = Global.Derecha(item.numDocumentoRef, 20);
                                                }
                                            }

                                            #endregion
                                        }
                                        else
                                        {
                                            fecRef = "01/01/0001";
                                            tipDocVentaRef = String.Empty;
                                            SerieRef = String.Empty;
                                            NumeroRef = String.Empty;
                                        }

                                        #endregion

                                        #region Detraccion

                                        if (item.flagDetraccion == Variables.SI)
                                        {
                                            fecDetraccion = Convert.ToDateTime(item.fecDetraccion).ToString("dd/MM/yyyy");
                                            numDetraccion = item.numDetraccion;
                                            MarcaDetraccion = "1";
                                        }
                                        else
                                        {
                                            fecDetraccion = "01/01/0001";
                                            numDetraccion = String.Empty;
                                            MarcaDetraccion = String.Empty;
                                        }

                                        #endregion

                                        #region Estado

                                        /*	
                                           Registrar '0' cuando el Comprobante de Pago o documento no da derecho al crédito fiscal.
                                           Registrar '1' cuando se anota el Comprobante de Pago o documento en el periodo que se emitió o que se pagó el impuesto, según corresponda, 
                                                         y da derecho al crédito fiscal.
                                           Registrar '6' cuando la fecha de emisión del Comprobante de Pago o de pago del impuesto, por operaciones que dan derecho a crédito fiscal, 
                                                         es anterior al periodo de anotación y esta se produce dentro de los doce meses siguientes a la emisión o pago del impuesto, según corresponda.
                                           Registrar '7' cuando la fecha de emisión del Comprobante de Pago o pago del impuesto, por operaciones que no dan derecho a crédito fiscal, 
                                                         es anterior al periodo de anotación y esta se produce luego de los doce meses siguientes a la emisión o pago del impuesto, según corresponda.
                                           Registrar '9' cuando se realice un ajuste o rectificación en la anotación de la información de una operación registrada en un periodo anterior. 
                                         */

                                        //Documentos que no dan derecho a crédito fiscal
                                        if (tipDocumento == "03" || tipDocumento == "02" || tipDocumento == "10" || tipDocumento == "15"
                                            || tipDocumento == "16" || tipDocumento == "17" || tipDocumento == "19" || tipDocumento == "26"
                                            || tipDocumento == "29" || tipDocumento == "44" || tipDocumento == "45")
                                        {
                                            Estado = "0";
                                        }
                                        else
                                        {
                                            if (item.fecDocumento.Value.ToString("yyyyMM") == item.Periodo.Substring(0, 6))
                                            {
                                                Estado = "1";
                                            }
                                            else                                       
                                            {
                                                Int64 Meses = 0;

                                               if (item.fecDocumento.Value.ToString("yyyy") == item.Periodo.Substring(0, 4))
                                                {
                                                    Meses = Convert.ToInt64(item.Periodo.Substring(0, 6)) - Convert.ToInt32(item.fecDocumento.Value.ToString("yyyyMM"));
                                                }
                                               else
                                                {
                                                    Meses = (12 - Convert.ToInt32(item.fecDocumento.Value.Month)) + Convert.ToInt64(item.Periodo.Substring(4, 2));
                                                }

                                               if (Meses <= 12)
                                                {
                                                    Estado = "6";  // Menor Igual a 12 Meses 
                                                }
                                                else
                                                {
                                                    Estado = "7";  // Mayor a 12 Meses
                                                }
                                            }
                                        } 

                                        #endregion            

                                        Cadena.Append(item.Periodo).Append("|").Append(item.Correlativo).Append("|").Append(item.PrimerDigito).Append("|").Append(fecDocumento).Append("|");
                                        Cadena.Append(fecVencimiento).Append("|").Append(tipDocumento).Append("|").Append(Serie_).Append("|").Append(AnioEmisDua).Append("|");
                                        Cadena.Append(numDocumento_).Append("|").Append(OperacionesDiarias).Append("|").Append(tipDocPersona_).Append("|").Append(numDocIdentidad).Append("|");
                                        Cadena.Append(RazonSocial_).Append("|").Append(item.BaseGravado.ToString("#####0.00")).Append("|").Append(item.IgvGrabado.ToString("#####0.00")).Append("|").Append(item.BaseGravadoNoGravado.ToString("#####0.00")).Append("|");
                                        Cadena.Append(item.IgvGravadoNoGravado.ToString("#####0.00")).Append("|").Append(item.BaseSinDerecho.ToString("#####0.00")).Append("|").Append(item.IgvSinDerecho.ToString("#####0.00")).Append("|").Append(item.BaseNoGravado.ToString("#####0.00")).Append("|");
                                        Cadena.Append(item.ISC.ToString("#####0.00")).Append("|").Append(item.Otros.ToString("#####0.00")).Append("|").Append(item.Total.ToString("#####0.00")).Append("|").Append(item.Moneda).Append("|");
                                        Cadena.Append(item.tipCambio.ToString("#####0.000")).Append("|").Append(fecRef).Append("|").Append(tipDocVentaRef).Append("|").Append(SerieRef).Append("|");
                                        Cadena.Append(String.Empty).Append("|").Append(NumeroRef).Append("|").Append(fecDetraccion).Append("|").Append(numDetraccion).Append("|");
                                        Cadena.Append(MarcaDetraccion).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|");
                                        Cadena.Append(String.Empty).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|");
                                        Cadena.Append(String.Empty).Append("|").Append(Estado).Append("|");

                                        oSw.WriteLine(Cadena.ToString());
                                    }                                    
                                }

                                Cadena.Clear();
                            }
                        }

                        RutaArchivoTexto = String.Empty;
                        RutaArchivoTexto2 = String.Empty;
                    }

                    #endregion Exportacion a un archivo de texto

                    Global.MensajeComunicacion("Se generó el archivo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(String.Format(ex.Message + " Revisar la linea {0} con Cód.Uni.Ope. {1}", Linea.ToString(), Correlativo));
            }
        }

        private void btPdb_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones
                
                if (oListaRegistroCompras != null)
                {
                    if (oListaRegistroCompras.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar el Registro de Compras al PDB.");
                        return;
                    }
                }
                else
                {
                    Global.MensajeFault("No hay datos para exportar el Registro de Compras al PDB.");
                    return;
                }

                if (Global.MensajeConfirmacion("Desea generar el archivo para el PDB") == DialogResult.No)
                {
                    return;
                } 

                #endregion

                String NombreArchivo = "C" + VariablesLocales.SesionUsuario.Empresa.RUC + oListaRegistroCompras[0].Periodo.Substring(0, 4) + oListaRegistroCompras[0].Periodo.Substring(4, 2);
                String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    #region Exportacion a un archivo de texto

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        #region Variables

                        StringBuilder Cadena = new StringBuilder();

                        String TipoCompra = String.Empty;
                        String tipComprobantePago = String.Empty;
                        String fecDocumento = String.Empty;
                        String SerieDoc = String.Empty;
                        String NumeroDoc = String.Empty;
                        String tipPersona = String.Empty;
                        String RazonSocial_ = String.Empty;
                        String ApePaterno_ = String.Empty;
                        String ApeMaterno_ = String.Empty;
                        String Nombre1 = String.Empty;
                        String Nombre2 = String.Empty;
                        String Moneda_ = String.Empty;
                        String codDestino = String.Empty;
                        String numDestino = String.Empty;
                        String sBaseImponible = String.Empty;
                        String sIgv = String.Empty;
                        String sIsc = String.Empty;
                        String sOtros = String.Empty;
                        String FlagDetraccion = String.Empty;
                        String codDetraccion = String.Empty;
                        String numDetraccion = String.Empty;
                        String tipDocVentaRef = String.Empty;
                        String SerieRef = String.Empty;
                        String NumeroRef = String.Empty;
                        String fecRef = String.Empty;
                        String MontoReferencia = String.Empty;
                        String IgvReferencia = String.Empty;
                        Boolean EsGravado = false;
                        Boolean EsNoGravado = false;
                        Int32 MasDestino = Variables.Cero; 

                        #endregion

                        foreach (RegistroComprasE item in oListaRegistroCompras)
                        {
                            if (item.fecDocumento != null && item.tipDocumentoVenta != null && item.tipDocPersona != null)
                            {
                                #region Tipo de Compra

                                if (item.tipDocumentoVenta == "50" || item.tipDocumentoVenta == "52" || item.tipDocumentoVenta == "53" || item.tipDocumentoVenta == "54" || item.tipDocumentoVenta == "91" ||
                                                        item.tipDocumentoVenta == "97" || item.tipDocumentoVenta == "98")
                                {
                                    TipoCompra = "02";
                                    tipComprobantePago = item.tipDocumentoVenta;
                                }
                                else
                                {
                                    TipoCompra = "01";
                                    tipComprobantePago = item.tipDocumentoVenta;
                                }

                                #endregion

                                fecDocumento = Convert.ToDateTime(item.fecDocumento).ToString("d");

                                #region Comprobante de Pago

                                #region Serie

                                if (tipComprobantePago == "01" || tipComprobantePago == "03" || tipComprobantePago == "04" || tipComprobantePago == "07" || tipComprobantePago == "08"
                                    || tipComprobantePago == "55")
                                {
                                    SerieDoc = item.serDocumento.Trim();

                                    if (Global.EsNumero(SerieDoc.Substring(0, 1)))
                                    {
                                        if (SerieDoc.Length > 4)
                                        {
                                            SerieDoc = Global.Derecha(item.serDocumento.Trim(), 4);
                                        }
                                        else if (SerieDoc.Length < 4)
                                        {
                                            SerieDoc = String.Format("{0:0000}", Convert.ToInt32(item.serDocumento.Trim()));
                                        }
                                    }
                                }
                                else if (tipComprobantePago == "10" || tipComprobantePago == "12")
                                {
                                    SerieDoc = String.Empty;
                                }
                                else if (tipComprobantePago == "50" || tipComprobantePago == "52" || tipComprobantePago == "53" || tipComprobantePago == "54")
                                {
                                    SerieDoc = "235" + item.Anio + item.numDocumento;
                                }
                                else if (tipComprobantePago == "91" || tipComprobantePago == "98")
                                {
                                    SerieDoc = "1662";
                                }
                                else
                                {
                                    SerieDoc = item.serDocumento.Trim();

                                    if (SerieDoc.Length > 10)
                                    {
                                        SerieDoc = Global.Derecha(item.serDocumento.Trim(), 10);
                                    }
                                }

                                #endregion

                                #region Número

                                if (tipComprobantePago == "12")
                                {
                                    NumeroDoc = item.numDocumento;

                                    if (NumeroDoc.Length > 20)
                                    {
                                        NumeroDoc = Global.Derecha(item.numDocumento.Trim(), 20);
                                    }
                                }
                                else if (tipComprobantePago == "91" || tipComprobantePago == "98")
                                {
                                    NumeroDoc = "1662";
                                }
                                else if (tipComprobantePago == "50" || tipComprobantePago == "52" || tipComprobantePago == "53" || tipComprobantePago == "54")
                                {
                                    NumeroDoc = String.Empty;
                                }
                                else
                                {
                                    NumeroDoc = item.numDocumento.Trim();

                                    if (!Global.EsNumero(NumeroDoc))
                                    {
                                        throw new Exception(String.Format("El N° del documento deben ser solo números {0}", NumeroDoc));
                                    }

                                    if (NumeroDoc.Length > 20)
                                    {
                                        NumeroDoc = Global.Derecha(item.numDocumento.Trim(), 20);
                                    }
                                }

                                #endregion

                                #endregion

                                #region Tipo Persona

                                if (item.tipDocPersona == "6")
                                {
                                    tipPersona = "02";
                                }
                                else if (item.tipDocPersona == "7")
                                {
                                    tipPersona = "03";
                                }
                                else if (item.tipDocPersona == "0")
                                {
                                    tipPersona = "03";
                                }
                                else
                                {
                                    throw new Exception("Tipo de documento desconocido.");
                                }

                                #endregion

                                #region Razon Social

                                if (tipPersona == "02" || tipPersona == "03")
                                {
                                    RazonSocial_ = item.RazonSocial;
                                    ApePaterno_ = String.Empty;
                                    ApeMaterno_ = String.Empty;
                                    Nombre1 = String.Empty;
                                    Nombre2 = String.Empty;
                                }
                                else
                                {
                                    List<String> Nombres = new List<String>(item.Nombres.Split(' '));
                                    ApePaterno_ = item.ApePat;
                                    ApeMaterno_ = item.ApeMat;

                                    if (Nombres.Count > Variables.Cero)
                                    {
                                        if (Nombres.Count == 1)
                                        {
                                            Nombre1 = Nombres[0].Trim();
                                        }
                                        else
                                        {
                                            Nombre1 = Nombres[0].Trim();
                                            Nombre2 = Nombres[1].Trim();
                                        }
                                    }

                                    RazonSocial_ = String.Empty;
                                }

                                #endregion

                                #region Moneda

                                if (item.Moneda == "PEN")
                                {
                                    Moneda_ = "1";
                                }
                                else if (item.Moneda == "USD")
                                {
                                    Moneda_ = "2";
                                }
                                else
                                {
                                    Moneda_ = "9";
                                }

                                #endregion

                                #region Es Gravado o no, Si tiene mas de un destino

                                if (item.BaseGravado != 0)
                                {
                                    EsGravado = true;
                                    MasDestino++;
                                }
                                else
                                {
                                    EsGravado = false;
                                }

                                if (item.BaseGravadoNoGravado != 0)
                                {
                                    MasDestino++;
                                }

                                if (item.BaseSinDerecho != 0)
                                {
                                    MasDestino++;
                                }

                                if (item.BaseNoGravado != 0)
                                {
                                    MasDestino++;
                                }

                                #endregion

                                if ((item.IgvGrabado != 0 && item.BaseGravado != 0 && item.BaseGravadoNoGravado != 0) || (item.IgvGrabado != 0 && item.BaseGravado != 0))
                                {
                                    #region Montos

                                    EsNoGravado = true;

                                    if (EsGravado)
                                    {
                                        numDestino = "1";

                                        if (MasDestino > 1)
                                        {
                                            codDestino = "5";
                                        }
                                        else
                                        {
                                            codDestino = "1";
                                        }

                                        sBaseImponible = Math.Abs(item.BaseGravado).ToString("#####0.00");
                                        sIgv = Math.Abs(item.IgvGrabado).ToString("#####0.00");

                                        if (item.tipDocumentoVenta == "50")
                                        {
                                            sBaseImponible = String.Empty;
                                        }

                                        EsGravado = false;
                                        EsNoGravado = false;
                                    }

                                    if (item.tipDocumentoVenta == "05")
                                    {
                                        sIsc = String.Empty;
                                    }
                                    else
                                    {
                                        sIsc = Math.Abs(item.ISC).ToString("#####0.00");
                                    }

                                    sOtros = Math.Abs(item.Otros).ToString("#####0.00");

                                    if (EsNoGravado)
                                    {
                                        numDestino = "4";

                                        if (MasDestino > 1)
                                        {
                                            codDestino = "5";
                                        }
                                        else
                                        {
                                            codDestino = "4";
                                        }

                                        sBaseImponible = Math.Abs(item.BaseNoGravado).ToString("#####0.00");
                                        sIgv = "0.00";
                                    }

                                    #endregion

                                    #region Detracciones

                                    if (item.flagDetraccion == Variables.SI)
                                    {
                                        FlagDetraccion = "1";

                                        if (item.codTasa == "001")
                                        {
                                            codDetraccion = "00101";
                                        }
                                        else if (item.codTasa == "010")
                                        {
                                            codDetraccion = "01001";
                                        }
                                        else if (item.codTasa == "012")
                                        {
                                            codDetraccion = "01203";
                                        }
                                        else if (item.codTasa == "019")
                                        {
                                            codDetraccion = "01903";
                                        }
                                        else if (item.codTasa == "020")
                                        {
                                            codDetraccion = "02003";
                                        }
                                        else if (item.codTasa == "021")
                                        {
                                            codDetraccion = "02103";
                                        }
                                        else if (item.codTasa == "022")
                                        {
                                            codDetraccion = "02203";
                                        }
                                        else if (item.codTasa == "026")
                                        {
                                            codDetraccion = "02602";
                                        }
                                        else if (item.codTasa == "027")
                                        {
                                            codDetraccion = "02702";
                                        }
                                        else if (item.codTasa == "030")
                                        {
                                            codDetraccion = "03002";
                                        }
                                        else if (item.codTasa == "037")
                                        {
                                            codDetraccion = "03703";
                                        }

                                        if (String.IsNullOrEmpty(item.numDetraccion))
                                        {
                                            numDetraccion = Variables.Cero.ToString();
                                        }
                                        else
                                        {
                                            numDetraccion = item.numDetraccion;
                                        }
                                    }
                                    else
                                    {
                                        FlagDetraccion = "0";
                                        codDetraccion = String.Empty;
                                        numDetraccion = String.Empty;
                                    }

                                    #endregion

                                    #region Documento de Referencia

                                    if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "08" || item.tipDocumentoVenta == "87" || item.tipDocumentoVenta == "88"
                                        || item.tipDocumentoVenta == "97" || item.tipDocumentoVenta == "98")
                                    {
                                        fecRef = Convert.ToDateTime(item.fecDocumentoRef).ToString("dd/MM/yyyy");
                                        tipDocVentaRef = item.idDocumentoRef;
                                        SerieRef = item.serDocumentoRef;
                                        NumeroRef = item.numDocumentoRef;
                                        MontoReferencia = sBaseImponible;
                                        IgvReferencia = sIgv;
                                    }
                                    else
                                    {
                                        fecRef = String.Empty;
                                        tipDocVentaRef = String.Empty;
                                        SerieRef = String.Empty;
                                        NumeroRef = String.Empty;
                                        MontoReferencia = String.Empty;
                                        IgvReferencia = String.Empty;
                                    }

                                    #endregion

                                    Cadena.Append(TipoCompra).Append("|").Append(tipComprobantePago).Append("|").Append(fecDocumento).Append("|").Append(SerieDoc).Append("|").Append(NumeroDoc).Append("|");
                                    Cadena.Append(tipPersona).Append("|").Append(item.tipDocPersona).Append("|").Append(item.RUC).Append("|").Append(RazonSocial_).Append("|").Append(ApePaterno_).Append("|");
                                    Cadena.Append(ApeMaterno_).Append("|").Append(Nombre1).Append("|").Append(Nombre2).Append("|").Append(Moneda_).Append("|").Append(codDestino).Append("|");
                                    Cadena.Append(numDestino).Append("|").Append(sBaseImponible).Append("|").Append(sIsc).Append("|").Append(sIgv).Append("|").Append(sOtros).Append("|");
                                    Cadena.Append(FlagDetraccion).Append("|").Append(codDetraccion).Append("|").Append(numDetraccion).Append("|").Append("0").Append("|").Append(tipDocVentaRef).Append("|");
                                    Cadena.Append(SerieRef).Append("|").Append(NumeroRef).Append("|").Append(fecRef).Append("|").Append(MontoReferencia).Append("|").Append(IgvReferencia).Append("|");

                                    oSw.WriteLine(Cadena.ToString());
                                    Cadena.Clear();
                                }
                            }

                            MasDestino = 0;
                        }

                        RutaArchivoTexto = String.Empty;
                    }

                    #endregion

                    Global.MensajeComunicacion("Se generó el archivo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void frmReporteRegistroComprasLe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String dia = dtpFecFin.Value.Day.ToString();
                dtpFecFin.Value = Convert.ToDateTime(dia + "/" + dtpFecIni.Value.Month.ToString("00") + "/" + dtpFecIni.Value.Year.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                letra += 1;

                if (letra == Marque.Length)
                {
                    lblProcesando.Text = String.Empty;
                    letra = 0;
                }
                else
                {
                    lblProcesando.Text += Marque.Substring(letra - 1, 1);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btNoDom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFecIni.Value.Year != dtpFecFin.Value.Year)
                {
                    Global.MensajeComunicacion("No puede ser diferente año");
                    return;
                }

                if (dtpFecIni.Value.Month != dtpFecFin.Value.Month)
                {
                    Global.MensajeComunicacion("No puede ser diferente mes");
                    return;
                }

                tipoProceso = 2; //Reporte no domiciliado
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                btPle.Enabled = false;
                btPdb.Enabled = false;
                btExcelNoDom.Enabled = false;
                pnlParametros.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                btPle.Enabled = true;
                btPdb.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void btExcelNoDom_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaRegistroCompras.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Compras No Domicialiado " + mes + "-" + anio, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = 3;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Importando los Registro de Compras a Excel...";
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

        private void ExcelFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaRegistroCompras == null)
                {
                    Global.MensajeFault("No hay Registros para exportar a Excel.");
                    return;
                }
                if (oListaRegistroCompras.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Compras Alineado Por File " + mes + "-" + anio, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = 4;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Importando los Registro de Compras a Excel...";
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

        #endregion Eventos

    }

    internal class PaginaInicialRegistroCompras : PdfPageEventHelper
    {
        public DateTime Periodo { get; set; }
        public String Moneda { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            
            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            Boolean MostrarFecPrint = VariablesLocales.oConParametros.MostrarFechaPrint;
            PdfPCell cell = null;

            TituloGeneral = "REGISTRO DE COMPRAS MES " + FechasHelper.NombreMes(Periodo.Month).ToUpper() + " " + Periodo.Year;

            if (Moneda == Variables.Soles)
            {
                SubTitulo = "EXPRESADO EN SOLES";
            }
            else
            {
                SubTitulo = "EXPRESADO EN DOLARES";
            }

            //Cabecera del Reporte
            PdfPTable table = new PdfPTable(2);

            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 0.9f, 0.1f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            #region Titulos Principales

            cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph(MostrarFecPrint ? "Fecha: " + FechaActual : "", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph(MostrarFecPrint ? "Hora:   " + HoraActual : "", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
            //cell.Colspan = 2;
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Pag.    " + writer.PageNumber, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            //cell.Colspan = 2;
            table.AddCell(cell);

            table.CompleteRow(); //Fila completada 

            #endregion

            #region Subtitulos

            cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada 

            #endregion

            document.Add(table); //Añadiendo la tabla al documento PDF

            #region Cabecera del Detalle

            PdfPTable TablaCabDetalle = new PdfPTable(28);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.11f, 0.074f, 0.074f, 0.037f, 0.05f, 0.06f, 0.085f, 0.037f, 0.13f, 0.55f, 0.09f, 0.09f, 0.09f, 0.081f, 0.081f, 0.081f, 0.09f, 0.048f, 0.048f, 0.11f,
                                                        0.1f, 0.08f, 0.074f, 0.07f, 0.074f, 0.037f, 0.05f, 0.085f });

            #region Primera Linea

            //Columna 1
            cell = new PdfPCell(new Paragraph("Cod. Uni. de la Ope.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 2
            cell = new PdfPCell(new Paragraph("Fecha de Emisión del Doc.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 3
            cell = new PdfPCell(new Paragraph("Fecha de Venc. y/o Pago", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 4, 5, 6
            cell = new PdfPCell(new Paragraph("Comprobante de Pago ó Documento", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 7
            cell = new PdfPCell(new Paragraph("Nro. Comprobante de Pago", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 8, 9, 10
            cell = new PdfPCell(new Paragraph("Información del Proveedor", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 11, 12
            cell = new PdfPCell(new Paragraph("Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 13, 14
            cell = new PdfPCell(new Paragraph("Adquisiciones Gravadas Destinadas a Operaciones Gravadas y/o Exportación y a Operaciones no Gravadas", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 15, 16
            cell = new PdfPCell(new Paragraph("Adquisiciones Gravadas Destinadas a Operaciones No Gravadas", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 17
            cell = new PdfPCell(new Paragraph("Valor de las Adquisiciones no Gravadas", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 18
            cell = new PdfPCell(new Paragraph("ISC", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 19
            cell = new PdfPCell(new Paragraph("Otros Tributos y Cargos", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 20
            cell = new PdfPCell(new Paragraph("Importe Total", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 21
            cell = new PdfPCell(new Paragraph("N° de Comprobante de Pago Emitido por Sujeto no Domiciliado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 22, 23
            cell = new PdfPCell(new Paragraph("Contancia de Déposito de Detracción", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 24
            cell = new PdfPCell(new Paragraph("Tipo de Cambio", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 3;
            TablaCabDetalle.AddCell(cell);
            //Columna 25, 26, 27, 28
            cell = new PdfPCell(new Paragraph("Referencia de Comprobante de Pago o Documento Original que se modifica", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 4;
            TablaCabDetalle.AddCell(cell);

            TablaCabDetalle.CompleteRow();

            #endregion

            #region Segunda Linea
            //Columna 4
            cell = new PdfPCell(new Paragraph("Tipo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 5
            cell = new PdfPCell(new Paragraph("Serie o Cód. de la Dep. Adu.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 6
            cell = new PdfPCell(new Paragraph("Año de la Emis. de la Dua", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 8, 9
            cell = new PdfPCell(new Paragraph("Doc. de Identidad", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 10
            cell = new PdfPCell(new Paragraph("Apellidos y Nombres ó Razón Social", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 22
            cell = new PdfPCell(new Paragraph("Número", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 23
            cell = new PdfPCell(new Paragraph("Fecha de Emisión", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 25
            cell = new PdfPCell(new Paragraph("Fecha", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 26
            cell = new PdfPCell(new Paragraph("Tipo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 27
            cell = new PdfPCell(new Paragraph("Serie", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 28
            cell = new PdfPCell(new Paragraph("N° Documento", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Rowspan = 2;
            TablaCabDetalle.AddCell(cell);

            TablaCabDetalle.CompleteRow();

            #endregion

            #region Tercera Linea

            cell = new PdfPCell(new Paragraph("Tipo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Número", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Base Imponib.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("IGV", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Base Imponib.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("IGV", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Base Imponib.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("IGV", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            TablaCabDetalle.CompleteRow();

            #endregion

            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

            #endregion

        }

    }

}


