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
    public partial class frmReporteDAOTCompras: FrmMantenimientoBase
    {

        public frmReporteDAOTCompras()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            //Global.CrearToolTip(btPle, "Importar para el PLE");
            //Global.CrearToolTip(btPdb, "Importar para el PDB");
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
                Decimal CantTotal = Convert.ToDecimal(txtValorAconsiderar.Text);
                String Considerar = "S";

                if (txtValorAconsiderar.Text.First() == '0')
                {
                    Considerar = "N";
                }

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

                PaginaInicialRegistroComprasDAOT ev = new PaginaInicialRegistroComprasDAOT();
                ev.Periodo = dtpFecIni.Value.Date;
                ev.Fin = dtpFecFin.Value.Date;
                ev.Moneda = cboMonedas.SelectedValue.ToString();
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(14);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.037f, 0.13f, 0.55f, 0.09f, 0.09f, 0.09f, 0.081f, 0.081f, 0.081f, 0.09f, 0.055f, 0.048f, 0.048f, 0.11f });

                foreach (RegistroComprasE item in oListaRegistroCompras)
                {
                    Decimal CantidadSuma = 0;
                    CantidadSuma = item.BaseGravado + item.BaseGravadoNoGravado + item.BaseNoGravado + item.BaseSinDerecho;
                    if (item.RazonSocial == "Totales Acumulados")
                    {
                        cell = new PdfPCell(new Paragraph("  ", FontFactory.GetFont("Arial", 6f))) { Border = 1, BorderWidthTop = 1, HorizontalAlignment = Element.ALIGN_CENTER };
                        cell.Colspan = 14;
                        TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();
                    }

                    if (CantidadSuma >= CantTotal)
                    {
                        cell = new PdfPCell(new Paragraph(item.tipDocPersona, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        if (item.RUC != null)
                        {
                            cell = new PdfPCell(new Paragraph(item.RUC.ToString().Replace("-", "").Replace(".", "").Replace(" ", ""), FontFactory.GetFont("Arial", 6f))) { Border = 0 };
                        }
                        else
                        {
                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0 };
                        }

                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.RazonSocial, FontFactory.GetFont("Arial", 6f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.IgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseGravadoNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.IgvGravadoNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseSinDerecho.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.IgvSinDerecho.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.OtrosConceptos.ToString("N2"), FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.ISC.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Otros.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Total.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }
                    else if (Considerar == "N")
                    {
                        cell = new PdfPCell(new Paragraph(item.tipDocPersona, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        if (item.RUC != null)
                        {
                            cell = new PdfPCell(new Paragraph(item.RUC.ToString().Replace("-", "").Replace(".", "").Replace(" ", ""), FontFactory.GetFont("Arial", 6f))) { Border = 0 };
                        }
                        else
                        {
                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0 };
                        }

                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.RazonSocial, FontFactory.GetFont("Arial", 6f))) { Border = 0 };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.IgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseGravadoNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.IgvGravadoNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseSinDerecho.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.IgvSinDerecho.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.OtrosConceptos.ToString("N2"), FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.ISC.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Otros.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Total.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }
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

            TituloGeneral = "DAOT de Compras";
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
                    Int32 TotColumnas = 14;
                    Decimal CantTotal = Convert.ToDecimal(txtValorAconsiderar.Text);
                    String Considerar = "S";

                    if (txtValorAconsiderar.Text.First() == '0')
                    {
                        Considerar = "N";
                    }

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

                    //using (ExcelRange Rango = oHoja.Cells[4, 1, 6, 1])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Cod. Uni. de la Ope.";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    //using (ExcelRange Rango = oHoja.Cells[4, 2, 6, 2])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Fecha de Emisiòn del Documento";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    //using (ExcelRange Rango = oHoja.Cells[4, 3, 6, 3])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Fecha de Venc. y/o Pago";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    //using (ExcelRange Rango = oHoja.Cells[4, 4, 5, 6])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Comprobante de Pago ó Documento ";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    //using (ExcelRange Rango = oHoja.Cells[4, 7, 6, 7])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Nro. Comprobante de Pago";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    using (ExcelRange Rango = oHoja.Cells[4, 1, 4,3])
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

                    using (ExcelRange Rango = oHoja.Cells[4, 4, 5, 5])
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

                    using (ExcelRange Rango = oHoja.Cells[4, 6, 5, 7])//
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

                    using (ExcelRange Rango = oHoja.Cells[4, 8, 5, 9])
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

                    using (ExcelRange Rango = oHoja.Cells[4,10, 6, 10])
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

                    using (ExcelRange Rango = oHoja.Cells[4, 11, 6, 11])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Total Bases";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 12, 6, 12])
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

                    using (ExcelRange Rango = oHoja.Cells[4, 13, 6, 13])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Otros Atributos";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }


                    using (ExcelRange Rango = oHoja.Cells[4, 14, 6, 14])
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

                    //using (ExcelRange Rango = oHoja.Cells[4, 21, 6, 21])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Nº de Comprobantes de Pago Emitido por Sujeto no Domiciliario";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    //using (ExcelRange Rango = oHoja.Cells[4, 22, 5, 23])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Costancia de Déposito de Detración";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    //using (ExcelRange Rango = oHoja.Cells[4, 24, 6, 24])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Tipo de Cambio";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    //using (ExcelRange Rango = oHoja.Cells[4, 25, 6, 28])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Value = "Referencia  de Comprobantes de Pago o Documento Original que se modififca";
                    //    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //    Rango.Style.Font.Bold = true;
                    //    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    //}

                    #endregion

                    InicioLinea++;

                    #region Segunda Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[5, 1, 5, 2])
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

                    using (ExcelRange Rango = oHoja.Cells[5, 3, 6, 3])
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

                    //oHoja.Row(6).Height = 30;

                    //oHoja.Cells[InicioLinea, 4].Value = "Tipo";
                    //oHoja.Cells[InicioLinea, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    //oHoja.Cells[InicioLinea, 5].Value = "Serie o Cod de la Dep. Adu.";
                    //oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    //oHoja.Cells[InicioLinea, 6].Value = "Año de la Emision de la Dua";
                    //oHoja.Cells[InicioLinea, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 6].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 1].Value = "Tipo";
                    oHoja.Cells[InicioLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 1].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 2].Value = "Nùmero";
                    oHoja.Cells[InicioLinea, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 2].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 4].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 5].Value = "IGV";
                    oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 6].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 6].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 7].Value = "IGV";
                    oHoja.Cells[InicioLinea, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 7].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 7].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 8].Value = "Base Imponible";
                    oHoja.Cells[InicioLinea, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 9].Value = "IGV";
                    oHoja.Cells[InicioLinea, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    //oHoja.Cells[InicioLinea, 22].Value = "Número";
                    //oHoja.Cells[InicioLinea, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 22].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 22].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 22].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    //oHoja.Cells[InicioLinea, 23].Value = "Fecha de Emisión";
                    //oHoja.Cells[InicioLinea, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 23].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 23].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 23].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    //oHoja.Cells[InicioLinea, 25].Value = "Fecha";
                    //oHoja.Cells[InicioLinea, 25].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 25].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 25].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 25].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    //oHoja.Cells[InicioLinea, 26].Value = "Tipo";
                    //oHoja.Cells[InicioLinea, 26].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 26].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 26].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 26].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 26].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    //oHoja.Cells[InicioLinea, 27].Value = "Serie";
                    //oHoja.Cells[InicioLinea, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 27].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 27].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 27].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 27].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    //oHoja.Cells[InicioLinea, 28].Value = "Nº Documento";
                    //oHoja.Cells[InicioLinea, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //oHoja.Cells[InicioLinea, 28].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    //oHoja.Cells[InicioLinea, 28].Style.Font.Bold = true;
                    //oHoja.Cells[InicioLinea, 28].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    //oHoja.Cells[InicioLinea, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    //oHoja.Cells[InicioLinea, 28].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    #endregion

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #region Detalle

                    foreach (RegistroComprasE item in oListaRegistroCompras)
                    {
                        Decimal CantidadSuma = 0;
                        CantidadSuma = item.BaseGravado + item.BaseGravadoNoGravado + item.BaseNoGravado + item.BaseSinDerecho;
                        if (!item.RazonSocial.Contains("TOTALES ACUMULADOS"))
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.tipDocPersona;
                            oHoja.Cells[InicioLinea, 2].Value = item.RUC;
                            oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;

                            oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 4].Value = item.BaseGravado;
                            oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 5].Value = item.IgvGrabado;
                            oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 6].Value = item.BaseGravadoNoGravado;
                            oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 7].Value = item.IgvGravadoNoGravado;
                            oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 8].Value = item.BaseSinDerecho;
                            oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 9].Value = item.IgvSinDerecho;
                            oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 10].Value = item.BaseNoGravado;
                            oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 11].Value = item.OtrosConceptos;
                            oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 12].Value = item.ISC;
                            oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 13].Value = item.Otros;
                            oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 14].Value = item.Total;
                            InicioLinea++;
                        }
                        else
                        {                         
                            if (CantidadSuma >= CantTotal)
                            {
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;

                                oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;
                                oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 4].Value = item.BaseGravado;
                                oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 5].Value = item.IgvGrabado;
                                oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 6].Value = item.BaseGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 7].Value = item.IgvGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 8].Value = item.BaseSinDerecho;
                                oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 9].Value = item.IgvSinDerecho;
                                oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 10].Value = item.BaseNoGravado;
                                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 11].Value = item.OtrosConceptos;
                                oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 12].Value = item.ISC;
                                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 13].Value = item.Otros;
                                oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 14].Value = item.Total;

                                oHoja.Cells[InicioLinea + 1, 1, InicioLinea + 1, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;
                                InicioLinea++;
                            }
                            else if(Considerar == "N")
                            {
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;

                                oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;
                                oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 4].Value = item.BaseGravado;
                                oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 5].Value = item.IgvGrabado;
                                oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 6].Value = item.BaseGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 7].Value = item.IgvGravadoNoGravado;
                                oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 8].Value = item.BaseSinDerecho;
                                oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 9].Value = item.IgvSinDerecho;
                                oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 10].Value = item.BaseNoGravado;
                                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 11].Value = item.OtrosConceptos;
                                oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 12].Value = item.ISC;
                                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 13].Value = item.Otros;
                                oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 14].Value = item.Total;

                                oHoja.Cells[InicioLinea + 1, 1, InicioLinea + 1, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;
                                InicioLinea++;
                            }
                        }

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

                if (item.tipDocumentoVenta == "07" || item.tipDocumentoVenta == "08")
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

                string anio = dtpFecIni.Value.ToString("YYYY");         

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "DAOT Compras Año " + anio , "Archivos Excel (*.xlsx)|*.xlsx");

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
            List<RegistroComprasE> oListaAgrupado = new List<RegistroComprasE>();

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

                oListaAgrupado = oListaRegistroCompras.GroupBy(x => x.RUC).Select(g => g.First()).OrderBy(x => x.RUC).ToList();

                if (oListaRegistroCompras.Count > Variables.Cero)
                    {

                    foreach (RegistroComprasE item in oListaAgrupado)
                    {
                        item.BaseGravado = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.BaseGravado).Sum();
                        item.IgvGrabado = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.IgvGrabado).Sum();
                        item.BaseGravadoNoGravado = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.BaseGravadoNoGravado).Sum();
                        item.IgvGravadoNoGravado = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.IgvGravadoNoGravado).Sum();
                        item.BaseSinDerecho = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.BaseSinDerecho).Sum();
                        item.IgvSinDerecho = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.IgvSinDerecho).Sum();
                        item.BaseNoGravado = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.BaseNoGravado).Sum();

                        //  Total Base
                        item.OtrosConceptos = item.BaseGravado + item.BaseGravadoNoGravado + item.BaseSinDerecho + item.BaseNoGravado;

                        item.ISC = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.ISC).Sum();
                        item.Otros = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.Otros).Sum();
                        item.Total = (from x in oListaRegistroCompras where x.RUC == item.RUC select x.Total).Sum();
                    }

                    oListaAgrupado = oListaAgrupado.OrderByDescending(x => x.OtrosConceptos).ToList();

                    oListaRegistroCompras = new List<RegistroComprasE>(oListaAgrupado);

                    RegistroComprasE oRegComprasTotal = new RegistroComprasE()
                        {
                            fecDocumento = (Nullable<DateTime>)null,
                            fecVencimiento = (Nullable<DateTime>)null,
                            RazonSocial = "Totales Acumulados",
                            BaseGravado = (from x in oListaAgrupado select x.BaseGravado).Sum(),
                            IgvGrabado = (from x in oListaAgrupado select x.IgvGrabado).Sum(),
                            BaseGravadoNoGravado = (from x in oListaAgrupado select x.BaseGravadoNoGravado).Sum(),
                            IgvGravadoNoGravado = (from x in oListaAgrupado select x.IgvGravadoNoGravado).Sum(),
                            BaseSinDerecho = (from x in oListaAgrupado select x.BaseSinDerecho).Sum(),
                            IgvSinDerecho = (from x in oListaAgrupado select x.IgvSinDerecho).Sum(),
                            BaseNoGravado = (from x in oListaAgrupado select x.BaseNoGravado).Sum(),

                            OtrosConceptos = (from x in oListaAgrupado select x.OtrosConceptos).Sum(),

                            ISC = (from x in oListaAgrupado select x.ISC).Sum(),
                            Otros = (from x in oListaAgrupado select x.Otros).Sum(),
                            Total = (from x in oListaAgrupado select x.Total).Sum(),
                         };                     

                    oListaRegistroCompras.Add(oRegComprasTotal);
                }
                
                lblProcesando.Text = "Armando el Reporte de Registro de Compras...";

                ConvertirApdf();//Generando el PDF
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
            //btPle.Enabled = true;
            //btPdb.Enabled = true;
            //btExcelNoDom.Enabled = true;
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
                //btNoDom.Visible = false;
                //btExcelNoDom.Visible = false;
            }
            else
            {
                pnlOtros.Visible = false;
                //btNoDom.Visible = true;
                //btExcelNoDom.Visible = true;
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dtpFecIni.Value.Year != dtpFecFin.Value.Year)
                //{
                //    Global.MensajeComunicacion("No puede ser diferente año");
                //    return;
                //}

                //if (dtpFecIni.Value.Month != dtpFecFin.Value.Month)
                //{
                //    Global.MensajeComunicacion("No puede ser diferente mes");
                //    return;
                //}

                tipoProceso = 1;
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                //btPle.Enabled = false;
                //btPdb.Enabled = false;
                
                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                //btPle.Enabled = true;
                //btPdb.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void btPle_Click(object sender, EventArgs e)
        {

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
                //btPle.Enabled = false;
                //btPdb.Enabled = false;
                //btExcelNoDom.Enabled = false;
                pnlParametros.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                //btPle.Enabled = true;
                //btPdb.Enabled = true;
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

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "DAOT Compras " + anio, "Archivos Excel (*.xlsx)|*.xlsx");

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

        private void btPle_Click_1(object sender, EventArgs e)
        {
            #region Variables

            String nomLibro = String.Empty;
            Int32 Correlativo = 1;
            Decimal CantTotal = Convert.ToDecimal(txtValorAconsiderar.Text);
            String Considerar = "S";

            if (txtValorAconsiderar.Text.First() == '0')
            {
                Considerar = "N";
            }
            String Anio = Convert.ToString(dtpFecIni.Value.Year);
            Int32 DiaReal = FechasHelper.ObtenerUltimoDia(VariablesLocales.FechaHoy).Day;
            String RutaArchivoTexto = String.Empty;

            #endregion Variables

            try
            {
                #region Validaciones

                if (oListaRegistroCompras == null || oListaRegistroCompras.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay registros a exportar.");
                    return;
                }

                #endregion



                RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", "Costos", "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    //Borrando el archivo...
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        #region Variables

                        StringBuilder Linea = new StringBuilder();

                        #endregion Variables

                        foreach (RegistroComprasE item in oListaRegistroCompras)
                        {
                            #region Insertar Linea
                            Decimal CantidadSuma = 0;
                            CantidadSuma = item.BaseGravado + item.BaseGravadoNoGravado + item.BaseNoGravado + item.BaseSinDerecho;
                            if (CantidadSuma >= CantTotal)
                            {
                                if (item.tipoPersoneriaDaot != null)
                                {
                                    if (item.tipoPersoneriaDaot == "01" || item.tipoPersoneriaDaot == "02" || item.tipoPersoneriaDaot == "03")
                                    {
                                        if (item.tipoPersoneriaDaot == "02" || item.tipoPersoneriaDaot == "03")
                                        {
                                            Linea.Append(Correlativo).Append("|").Append("6").Append("|").Append(VariablesLocales.SesionUsuario.Empresa.RUC).Append("|");
                                            Linea.Append(Anio).Append("|").Append(item.tipoPersoneriaDaot).Append("|").Append(item.tipDocPersona).Append("|");
                                            Linea.Append(item.RUC).Append("|").Append(Convert.ToInt32(CantidadSuma)).Append("|").Append("|").Append("|").Append("|").Append("|").Append(item.RazonSocial).Append("|");
                                        }
                                        else if (item.tipoPersoneriaDaot == "01")
                                        {

                                            String NombresPart = item.Nombres;
                                            String[] Parte = NombresPart.Split(' ');
                                            String part1 = String.Empty;
                                            String part2 = String.Empty;
                                            if (NombresPart.Contains(" "))
                                            {
                                                part1 = Parte[0];
                                                part2 = Parte[1];
                                            }
                                            else
                                            {
                                                part1 = Parte[0];
                                            }


                                            Linea.Append(Correlativo).Append("|").Append("6").Append("|").Append(VariablesLocales.SesionUsuario.Empresa.RUC).Append("|");
                                            Linea.Append(Anio).Append("|").Append(item.tipoPersoneriaDaot).Append("|").Append(item.tipDocPersona).Append("|");
                                            Linea.Append(item.RUC).Append("|").Append(Convert.ToInt32(CantidadSuma)).Append("|").Append(part1).Append("|").Append(part2).Append("|").Append(item.ApePat).Append("|").Append(item.ApeMat).Append("|").Append(item.RazonSocial).Append("|");
                                        }
                                        oSw.WriteLine(Linea.ToString());
                                        Linea.Clear();
                                        Correlativo++;
                                    }
                                }
                            }
                            else if(Considerar == "N")
                            {
                                if (item.tipoPersoneriaDaot != null)
                                {
                                    if (item.tipoPersoneriaDaot == "01" || item.tipoPersoneriaDaot == "02" || item.tipoPersoneriaDaot == "03")
                                    {
                                        if (item.tipoPersoneriaDaot == "02" || item.tipoPersoneriaDaot == "03")
                                        {
                                            Linea.Append(Correlativo).Append("|").Append("6").Append("|").Append(VariablesLocales.SesionUsuario.Empresa.RUC).Append("|");
                                            Linea.Append(Anio).Append("|").Append(item.tipoPersoneriaDaot).Append("|").Append(item.tipDocPersona).Append("|");
                                            Linea.Append(item.RUC).Append("|").Append(Convert.ToInt32(CantidadSuma)).Append("|").Append("|").Append("|").Append("|").Append("|").Append(item.RazonSocial).Append("|");
                                        }
                                        else if (item.tipoPersoneriaDaot == "01")
                                        {

                                            String NombresPart = item.Nombres;
                                            String[] Parte = NombresPart.Split(' ');
                                            String part1 = String.Empty;
                                            String part2 = String.Empty;
                                            if (NombresPart.Contains(" "))
                                            {
                                                part1 = Parte[0];
                                                part2 = Parte[1];
                                            }
                                            else
                                            {
                                                part1 = Parte[0];
                                            }


                                            Linea.Append(Correlativo).Append("|").Append("6").Append("|").Append(VariablesLocales.SesionUsuario.Empresa.RUC).Append("|");
                                            Linea.Append(Anio).Append("|").Append(item.tipoPersoneriaDaot).Append("|").Append(item.tipDocPersona).Append("|");
                                            Linea.Append(item.RUC).Append("|").Append(Convert.ToInt32(CantidadSuma)).Append("|").Append(part1).Append("|").Append(part2).Append("|").Append(item.ApePat).Append("|").Append(item.ApeMat).Append("|").Append(item.RazonSocial).Append("|");
                                        }
                                        oSw.WriteLine(Linea.ToString());
                                        Linea.Clear();
                                        Correlativo++;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
    }

    internal class PaginaInicialRegistroComprasDAOT : PdfPageEventHelper
    {
        public DateTime Periodo { get; set; }

        public DateTime Fin { get; set; }
        
        public String Moneda { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            
            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            PdfPCell cell = null;

            TituloGeneral = "DAOT DE COMPRAS MES " + Periodo.Date.ToString("d") + " Al " + Fin.Date.ToString("d");

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
            cell = new PdfPCell(new Paragraph("Fecha: " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("Hora:   " + HoraActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
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

            PdfPTable TablaCabDetalle = new PdfPTable(14);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] {  0.037f, 0.13f, 0.55f, 0.09f, 0.09f, 0.09f, 0.081f, 0.081f, 0.081f, 0.09f, 0.048f, 0.048f, 0.048f, 0.11f });

            #region Primera Linea


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
            cell = new PdfPCell(new Paragraph("Total Bases", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
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
           

            TablaCabDetalle.CompleteRow();

            #endregion

            #region Segunda Linea

            //Columna 8, 9
            cell = new PdfPCell(new Paragraph("Doc. de Identidad", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);
            //Columna 10
            cell = new PdfPCell(new Paragraph("Apellidos y Nombres ó Razón Social", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
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


