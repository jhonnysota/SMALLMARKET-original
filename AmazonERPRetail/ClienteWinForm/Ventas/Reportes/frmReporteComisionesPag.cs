﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;

#endregion

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteComisionesPag : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteComisionesPag()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }
 
	    #endregion

        #region Variables
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<ComisionesCalE> oListaComisionesCal = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        string tipo = "buscar";
        String Marque = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ////Sucursales
            //List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
            //                                             where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
            //                                             select x).ToList();
            //LocalE ItemLocal = new LocalE { IdLocal = Variables.ValorCero, Nombre = Variables.Todos };
            //listaLocales.Add(ItemLocal);
            //listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            //ComboHelper.RellenarCombos<LocalE>(cboSucursales, listaLocales, "idLocal", "Nombre", false);

            //////Periodo/////////
            //////Periodo/////////
            List<PeriodoComisionE> ListaComision = AgenteVentas.Proxy.ListarPeriodoComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            //PeriodoComisionE Fila = new PeriodoComisionE();
            //Fila.idPeriodo = Variables.ValorCero;
            //Fila.Mes = "<<SELECCIONE>>";
            //ListaComision.Add(Fila);
   

            List<VendedoresE> ListaVendedores = AgenteMaestro.Proxy.BusquedaVendedores(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            VendedoresE Fila = new VendedoresE();
            Fila.idVendedor = Variables.Cero;
            Fila.NombresCom = "<<TODOS>>";
            ListaVendedores.Add(Fila);
            ComboHelper.RellenarCombos<VendedoresE>(cboVendedor, (from x in ListaVendedores orderby x.idVendedor select x).ToList(), "idPersona", "NombresCom", false);
           
          
        }

        #endregion

        #region Procedimientos de Pdf

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\CalculoDeComisionesAPagar";
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
                PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                if (docPdf.IsOpen())
                {
                    docPdf.CloseDocument();
                }

                PaginaInicioComisionesPag ev = new PaginaInicioComisionesPag();
                ev.FechaCog = dtpFechaCog.Value.ToString("d");


                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle
                Decimal total1 = 0;
                Decimal total2 = 0;
                

                int Columnas = 9;
                PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.2f, 0.1f, 0.25f, 0.1f, 0.1f, 0.1f });


                string RazonSocial = "-1";


                foreach (ComisionesCalE item in oListaComisionesCal)
                {
                    

                    total1 = total1 + item.TotTotal;
                    total2 = total2 + item.ComisionDocumento;



                    if (RazonSocial == "-1")
                    {

                        RazonSocial = item.RazonSocial.ToString();

                        cell = new PdfPCell(new Paragraph("Vendedor : " + item.RazonSocial.ToString(), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = Columnas;
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }


                    if (RazonSocial != item.RazonSocial.ToString())
                    {

                        cell = new PdfPCell(new Paragraph(" Sub Total : ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        cell.Colspan = 7;
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(oListaComisionesCal.Where(x => x.RazonSocial == RazonSocial).Sum(x => x.TotTotal).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(oListaComisionesCal.Where(x => x.RazonSocial == RazonSocial).Sum(x => x.ComisionDocumento).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();



                        RazonSocial = item.RazonSocial.ToString();

                        cell = new PdfPCell(new Paragraph("Vendedor : " + item.RazonSocial.ToString(), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = Columnas;
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }

                    cell = new PdfPCell(new Paragraph(item.idDocumento.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.numSerie.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.numDocumento.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.FecEmision.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.numRuc.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.RazonSocialDocumento.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    if (item.idMoneda == "01")
                    {
                        String idMon = "Soles Peruanos";


                        cell = new PdfPCell(new Paragraph(idMon.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);
                    }
                    if (item.idMoneda == "02")
                    {
                        String idMon = "Dolares Estadounidenses";


                        cell = new PdfPCell(new Paragraph(idMon.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);
                    }

                    cell = new PdfPCell(new Paragraph(item.TotTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.ComisionDocumento.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);




                    TablaCabDetalle.CompleteRow();
                }



                cell = new PdfPCell(new Paragraph("Sub Total : ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                cell.Colspan = 7;
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(oListaComisionesCal.Where(x => x.RazonSocial == RazonSocial).Sum(x => x.TotTotal).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(oListaComisionesCal.Where(x => x.RazonSocial == RazonSocial).Sum(x => x.ComisionDocumento).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph("------------------------------------", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                cell.Colspan = 7;
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph("-------------------------------------", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph("-------------------------------------", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph("Total : ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                cell.Colspan = 7;
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(total1.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(total2.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();



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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {

                Int32 Vendedor = Convert.ToInt32(cboVendedor.SelectedValue);
                DateTime FechaCog = dtpFechaCog.Value.Date;

                lblProcesando.Text = "Obteniendo las Comisiones Para Pagar...";
                oListaComisionesCal = AgenteVentas.Proxy.ListarComisionPag(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Vendedor, FechaCog);
                lblProcesando.Text = "Armando Las Comisiones Para Pagar...";
                ConvertirApdf();
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

            _bw.CancelAsync();
            _bw.Dispose();

            if (tipo == "buscar")
            {
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }
            else
            {
                Global.MensajeComunicacion("Comisiones Para Pagar Exportado...");
            }
        }

        #endregion

        #region Exportar Excel

        public override void Exportar()
        {
            try
            {
                if (oListaComisionesCal == null || oListaComisionesCal.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }


                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Comisiones Para Pagar "  + "-", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    lblProcesando.Visible = true;
                    btBuscar.Enabled = true;
                    Marque = "Importando los registros a Excel...";
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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;


            TituloGeneral = " Comisiones Para Pagar Del Periodo" ;
            NombrePestaña = " Comisiones Para Pagar Del Periodo" ; 

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 9;

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
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "Documento";

                    oHoja.Cells[InicioLinea, 2].Value = " Numero De Serie";

                    oHoja.Cells[InicioLinea, 3].Value = " Numero Documento";

                    oHoja.Cells[InicioLinea, 4].Value = " Fecha Emisión ";

                    oHoja.Cells[InicioLinea, 5].Value = " Numero RUC ";

                    oHoja.Cells[InicioLinea, 6].Value = " Razon Social Doc.";

                    oHoja.Cells[InicioLinea, 7].Value = " Moneda ";

                    oHoja.Cells[InicioLinea, 8].Value = " Totales ";

                    oHoja.Cells[InicioLinea, 9].Value = " Comision ";

                    for (int i = 1; i <= 9; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    #endregion

                    #region Detallado
                    //Int32 col = 1;
                    string RazonSocial = "-1";
                    Decimal total1 = 0;
                    Decimal total2 = 0;

                    foreach (ComisionesCalE item in oListaComisionesCal)
                    {

                        total1 = total1 + item.TotTotal;
                        total2 = total2 + item.ComisionDocumento;

                        if (RazonSocial == "-1")
                        {
                            RazonSocial = item.RazonSocial.ToString();
                            oHoja.Cells[InicioLinea, 1].Value = "Vendedor : " + item.RazonSocial;
                            InicioLinea++;
                        }

                        if (RazonSocial != item.RazonSocial.ToString())
                        {
                            oHoja.Cells[InicioLinea, 7].Value = " Sub Total : ";
                            oHoja.Cells[InicioLinea, 8].Value = oListaComisionesCal.Where(x => x.RazonSocial == RazonSocial).Sum(x => x.TotTotal);
                            oHoja.Cells[InicioLinea, 9].Value =   oListaComisionesCal.Where(x => x.RazonSocial == RazonSocial).Sum(x => x.ComisionDocumento);
                            oHoja.Cells[InicioLinea, 8, InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                            InicioLinea++;

                            RazonSocial = item.RazonSocial.ToString();
                            oHoja.Cells[InicioLinea, 1].Value = "Vendedor : " + item.RazonSocial;
                            InicioLinea++;
                        }              
                       
                        oHoja.Cells[InicioLinea, 1].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 2].Value = item.numSerie;
                        oHoja.Cells[InicioLinea, 3].Value = item.numDocumento;

                        oHoja.Cells[InicioLinea, 4].Value = item.FecEmision;
                        oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "dd/MM/yyyy";

                        oHoja.Cells[InicioLinea, 5].Value = item.numRuc;

                        oHoja.Cells[InicioLinea,6].Value = item.RazonSocialDocumento;


                        if (item.idMoneda == "01")
                        {
                            String idMon = "Soles Peruanos";


                            oHoja.Cells[InicioLinea, 7].Value = idMon;
                        }
                        if (item.idMoneda == "02")
                        {
                            String idMon = "Dolares Estadounidenses";


                            oHoja.Cells[InicioLinea, 7].Value = idMon;
                        }


                        oHoja.Cells[InicioLinea, 8].Value = item.TotTotal;
                        oHoja.Cells[InicioLinea, 9].Value = item.ComisionDocumento;


                        oHoja.Cells[InicioLinea, 8, InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;

                    }

                    oHoja.Cells[InicioLinea, 7].Value = " Sub Total : ";
                    oHoja.Cells[InicioLinea, 8].Value = oListaComisionesCal.Where(x => x.RazonSocial == RazonSocial).Sum(x => x.TotTotal);
                    oHoja.Cells[InicioLinea, 9].Value = oListaComisionesCal.Where(x => x.RazonSocial == RazonSocial).Sum(x => x.ComisionDocumento);
                    oHoja.Cells[InicioLinea, 8, InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 7].Value = "Total : ";
                    oHoja.Cells[InicioLinea, 8].Value = total1;
                    oHoja.Cells[InicioLinea, 9].Value = total2;
                    oHoja.Cells[InicioLinea, 8, InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;




                    

                    //FIN SUMATORIA //



                    #endregion

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

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
                    oHoja.Workbook.Properties.Category = "Modulo de Comisiones";
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

        #endregion

        #region eventos 

        private void frmReporteComisionesPag_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void frmReporteComisionesPag_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }       

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "buscar";
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

        #endregion

    }
}




#region Inicio Pdf

class PaginaInicioComisionesPag : PdfPageEventHelper
{
    public String FechaCog { get; set; }
    public String Nombre { get; set; }


    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        //Chunk ch = new Chunk("This is my Stack Overflow Header on page " + writer.PageNumber);
        //document.Add(ch);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

           



        TituloGeneral = "Resumen De Comisiones Para Pagar " + "Con Fecha De " + FechaCog.ToUpper();

        SubTitulo = "Fecha : " + FechaCog.ToUpper(); ;


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

        PdfPTable TablaCabDetalle = new PdfPTable(9);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.2f, 0.1f, 0.25f, 0.1f, 0.1f, 0.1f });

        #region Primera Linea


        cell = new PdfPCell(new Paragraph("Documento", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Numero de Serie", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Numero Documento", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Fecha Emision", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Numero de RUC", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Razon Social Doc.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Moneda", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Total", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Comision", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);



        TablaCabDetalle.CompleteRow();

        #endregion

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF


    }

}

#endregion