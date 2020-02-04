using ClienteWinForm;
using ClienteWinForm.Busquedas;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteInventarioBalanceCta : FrmMantenimientoBase
    {
        public frmReporteInventarioBalanceCta()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<InventarioBalanceE> oInventario = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        string Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String Marque = String.Empty;
        string tipo = "buscar";


        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, listaLocales, "idLocal", "Nombre", false);

            /////MES////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboMes.DataSource = oDt;
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;


            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;


            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String Mes = Convert.ToString(cboMes.SelectedValue);
                String Version = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                String codigo = txtInicioCuenta.Text;
                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el Registro de Inventario...";
                oInventario = AgenteContabilidad.Proxy.ReporteInventarioBalance(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, Anio, Mes, Version, codigo);

                lblProcesando.Text = "Armando el Reporte...";
                //Generando el PDF
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

            _bw.CancelAsync();
            _bw.Dispose();

            //Mostrando el reporte en un web browser
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
                Global.MensajeComunicacion("Inventario Balance Exportado...");
            }
        }

        #endregion

        #region Reportes

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\DiferenciaCambio " + Aleatorio.ToString();
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

                PaginaInicialInventarioBalance ev = new PaginaInicialInventarioBalance();
                //Parametros Que Pasaras Al PDF
                ev.Anio = Convert.ToString(cboAño.SelectedValue);
                //ev.Mes = Convert.ToInt32(cboMes.SelectedValue);
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(8);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f, 0.2f, 0.1f });

                Decimal d = 0;
                Decimal h = 0;

                foreach (InventarioBalanceE item in oInventario)
                {
                    d += item.debe;
                    h += item.haber;

                    cell = new PdfPCell(new Paragraph(item.Periodo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.codCuenta, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.codigoBanco, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.num_cuenta, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.codigoMoneda, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(Math.Abs(item.debe).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(Math.Abs(item.haber).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.Estado, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();
                }


                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("_________", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("_____________ ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("_____________ ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Totales", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Math.Abs(d).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Math.Abs(h).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String nombreMes = cboMes.Text;

            TituloGeneral = " Inventario Balance Cta " + " Al Año " + Anio + " Del Mes " + nombreMes;
            NombrePestaña = " Inventario Balance Cta ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 7;
                    Int32 TotColumnas = 8;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = "Libro De Inventarios y Balances ";

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = "Detalle Del Saldo De Cuenta 10 - Efectivo Y Equivalentes De Efectivo";

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }
                   
                    oHoja.Cells["A3"].Value =  "Ejercicio " + " " + VariablesLocales.FechaHoy.ToString("yyyy");

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A4"].Value ="RUC " + " " + VariablesLocales.SesionUsuario.Empresa.RUC;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    oHoja.Cells["A5"].Value = "Razon Social " + " " +  VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1, InicioLinea, 2].Value = "";

                    oHoja.Cells[InicioLinea, 3, InicioLinea, 6].Value = " Referencia De La cuenta ";

                    oHoja.Cells[InicioLinea, 7, InicioLinea , 8].Value = " Saldo COntable Final ";




                    for (int i = 1; i <= 8; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }




                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "Periodo";
                    oHoja.Cells[InicioLinea, 2].Value = "Codigo de la Cuenta";
                    oHoja.Cells[InicioLinea, 3].Value = "Entidad Financiera";
                    oHoja.Cells[InicioLinea, 4].Value = "Numero De La Cuenta";
                    oHoja.Cells[InicioLinea, 5].Value = "Tipo De Moneda";
                    oHoja.Cells[InicioLinea, 6].Value = "Deudor";
                    oHoja.Cells[InicioLinea, 7].Value = "Acreedor";
                    oHoja.Cells[InicioLinea, 8].Value = "Estado";




                    for (int i = 1; i <= 8; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }




                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    #endregion

                    Decimal d = 0;
                    Decimal h = 0;

                    foreach (InventarioBalanceE item in oInventario)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.Periodo;
                        oHoja.Cells[InicioLinea, 2].Value = item.codCuenta;
                        oHoja.Cells[InicioLinea, 3].Value = item.codigoBanco;
                        oHoja.Cells[InicioLinea, 4].Value = item.num_cuenta;
                        oHoja.Cells[InicioLinea, 5].Value = item.codigoMoneda;
                        oHoja.Cells[InicioLinea, 6].Value = item.Estado;
                        oHoja.Cells[InicioLinea, 7].Value = Math.Abs(item.debe);
                        oHoja.Cells[InicioLinea, 8].Value = Math.Abs(item.haber);
                    
                        d += item.debe;
                        h += item.haber;

                        // FORMAT 
                        oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                    }
                    //FIN SUMATORIA //

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = "";
                    oHoja.Cells[InicioLinea, 2].Value = "";
                    oHoja.Cells[InicioLinea, 3].Value = "";
                    oHoja.Cells[InicioLinea, 4].Value = "";
                    oHoja.Cells[InicioLinea, 5].Value = "";
                    oHoja.Cells[InicioLinea, 6].Value = "";
                    oHoja.Cells[InicioLinea, 7].Value = d;
                    oHoja.Cells[InicioLinea, 8].Value = h;
                    oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;

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

        void buscarcuenta()
        {
            List<PlanCuentasE> PlancuentaLista = null;
            PlancuentaLista = AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, "1", 2, 1);
            foreach (PlanCuentasE item in PlancuentaLista)
            {
                if (item.codCuenta == txtInicioCuenta.Text)
                {
                    txtDesCuentaIni.Text = item.Descripcion;
                }
            }
        }

        #endregion

        #region Eventos 

        private void btProveedor_Click(object sender, EventArgs e)
        {
            frmBuscarCuentasExac frm = new frmBuscarCuentasExac();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtInicioCuenta.Text = frm.Cuentas.codCuenta;
                txtDesCuentaIni.Text = frm.Cuentas.Descripcion;
            }
        }

        private void frmReporteInventarioBalanceCta_Load(object sender, EventArgs e)
        {
            
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            cboMes.SelectedIndex = 13;
            txtInicioCuenta.Text = "10";
            buscarcuenta();
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
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

                    Global.QuitarReferenciaWebBrowser(wbNavegador);

                    _bw.RunWorkerAsync();
                
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        public override void Exportar()
        {
            try
            {
                if (oInventario == null || oInventario.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = cboSucursales.Text;
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + cboSucursales.Text;

                String Mes = cboMes.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Inventario Balance" + NombreLocal + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

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

        private void frmReporteDifCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        #endregion

        private void btPle_Click(object sender, EventArgs e)
        {
            #region Variables

            String nomLibro = String.Empty;
            String MesReal = cboMes.SelectedValue.ToString();
            String AnioReal = cboAño.SelectedValue.ToString();
            Int32 DiaReal = FechasHelper.ObtenerUltimoDia(VariablesLocales.FechaHoy).Day;
            String RutaArchivoTexto =   String.Empty;
            String Dato = "1";
            String nLibro = "030200";

            #endregion Variables

            try
            {
                #region Validaciones

                if (oInventario == null || oInventario.Count == Variables.Cero)
                {
                    Dato = "0";
                }

                #endregion

                if (Global.MensajeConfirmacion("Desea generar el Inventario Balance Cuenta para el PLE.") == DialogResult.No)
                {
                    return;
                }

                nomLibro = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + AnioReal + "12" + "31" + nLibro + "011" + Dato + "11";
                RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", nomLibro, "Documentos de Texto (*.txt)|*.txt");

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

                        foreach (InventarioBalanceE item in oInventario)
                        {
                            #region Insertar Linea

                                Linea.Append(item.Periodo).Append("|").Append(item.codCuenta).Append("|").Append(item.codigoBanco).Append("|");
                                Linea.Append(item.num_cuenta).Append("|").Append(item.codigoMoneda).Append("|").Append(item.Estado).Append("|");
                              Linea.Append(Math.Abs(item.debe)).Append("|").Append(Math.Abs(item.haber)).Append("|");

                                oSw.WriteLine(Linea.ToString());
                                Linea.Clear();

                            #endregion Insertar Linea
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtInicioCuenta_Validating(object sender, CancelEventArgs e)
        {
            List<PlanCuentasE> PlancuentaLista = null;
            PlancuentaLista = AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, "1", 2, 1);
            foreach (PlanCuentasE item in PlancuentaLista)
            {
                if (item.codCuenta == txtInicioCuenta.Text)
                {
                    txtDesCuentaIni.Text = item.Descripcion;
                }
            }

        }

        private void txtInicioCuenta_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaIni.Text = String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}

internal class PaginaInicialInventarioBalance : PdfPageEventHelper
{
    //public DateTime Per { get; set; }
    public String Anio { get; set; }
    //public Int32 Mes { get; set; }
    //public String NombreMes { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

        TituloGeneral = "Libros De Inventarios Y Balances";
        SubTitulo = "Detalle Del Saldo De La Cuenta 10 - Efectivo Y Equivalentes De Efectivo";

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.9f, 0.1f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha: " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial",8.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
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

        document.Add(table);

        #endregion

        #region Subtitulos

        PdfPTable table2 = new PdfPTable(2);

        table2.WidthPercentage = 100;
        table2.SetWidths(new float[] { 0.3f, 0.7f });
        table2.HorizontalAlignment = Element.ALIGN_LEFT;
        

        cell = new PdfPCell(new Paragraph("Ejercicio :", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table2.AddCell(cell);



        cell = new PdfPCell(new Paragraph(VariablesLocales.FechaHoy.ToString("yyyy"), FontFactory.GetFont("Arial", 8, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table2.AddCell(cell);
        table2.CompleteRow();   

        cell = new PdfPCell(new Paragraph("RUC : ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table2.AddCell(cell);

        cell = new PdfPCell(new Paragraph( VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table2.AddCell(cell);
        table2.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph("Razon Social", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table2.AddCell(cell);

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table2.AddCell(cell);
        table2.CompleteRow(); //Fila completada

        document.Add(table2);

        #endregion

        //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(8);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f, 0.2f, 0.1f });

        #region Segunda Linea

        cell = new PdfPCell(new Paragraph(" Periodo ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Cuenta ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Entidad Financiera ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Numero De La Cuenta ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Tipo De Moneda ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);       

        cell = new PdfPCell(new Paragraph(" Deudor ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Acreedor ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" Estado ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion


        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}