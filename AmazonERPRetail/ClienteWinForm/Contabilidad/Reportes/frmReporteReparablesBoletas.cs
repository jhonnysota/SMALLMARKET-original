using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Negocio;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ClienteWinForm;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReparablesBoletas : FrmMantenimientoBase
    {

        #region Constructor

        public frmReparablesBoletas()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<ReparablesE> oReparables = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        String Descripcion;
        String NomConcepto;
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
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);

            if (listaLocales.Count == 2)
            {
                cboSucursal.SelectedIndex = 1;
                cboSucursal.Enabled = false;
            }
            else
            {
                cboSucursal.Enabled = true;
            }

            /////MES INICIO////
            cboInicio.DataSource = FechasHelper.CargarMesesContable("MA");
            cboInicio.ValueMember = "MesId";
            cboInicio.DisplayMember = "MesDes";
            cboInicio.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////MES FINAL////
            cboFin.DataSource = FechasHelper.CargarMesesContable("MA");
            cboFin.ValueMember = "MesId";
            cboFin.DisplayMember = "MesDes";
            cboFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\ReporteReparablesBoletas " + Aleatorio.ToString();
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

                PaginaInicioReparables Inicio = new PaginaInicioReparables();
                Inicio.MesInicio = Convert.ToInt32(cboInicio.SelectedValue);
                Inicio.MesFin = Convert.ToInt32(cboFin.SelectedValue);
                Inicio.Anio = VariablesLocales.PeriodoContable.AnioPeriodo;

                if (chkReparable.Checked)
                {
                    Inicio.TipoReparable = "R";
                }
                else
                {
                    Inicio.TipoReparable = "B";
                }

                oPdfw.PageEvent = Inicio;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(7);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.1f, 0.4f, 0.1f, 0.1f });

                oReparables = (from x in oReparables orderby x.idConceptoRep select x).ToList();

                Int32 Contador = 0;
                String CODCUENTA = "";
                Decimal CuentaTotDebe = 0;
                Decimal CuentaTotHaber = 0;
                Decimal GeneralTotDebe = 0;
                Decimal GeneralTotHaber = 0;
                Int32 idConceptoRep = 0;
                Int32 idConceptoRepTmp = 0;
                String CODCUENTATmp = "";

                for (int i = 0; i < oReparables.Count; i++)
                {
                    idConceptoRep = oReparables[i].idConceptoRep;
                    NomConcepto = oReparables[i].nomConcepto;

                    if (idConceptoRepTmp != idConceptoRep)
                    {
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);

                        cell = CellPdf(idConceptoRep.ToString("") + " " + NomConcepto, 0, 0, "l", "bold");
                        TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", "");
                        TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", "");
                        TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();

                        idConceptoRepTmp = idConceptoRep;
                    }

                    CODCUENTA = oReparables[i].codCuenta;
                    Descripcion = oReparables[i].Descripcion;

                    if (CODCUENTATmp != CODCUENTA)
                    {
                        if (CuentaTotDebe > 0 || CuentaTotHaber > 0)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), -1, -1, "S4"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Total Cuenta: ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 102)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CuentaTotDebe.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 102)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CuentaTotHaber.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 102)), 5, 2));
                            TablaCabDetalle.CompleteRow();

                            CuentaTotDebe = 0;
                            CuentaTotHaber = 0;
                        }

                        cell = CellPdf(CODCUENTA, 0, 0, "l", "bold"); 
                        TablaCabDetalle.AddCell(cell);

                        cell = CellPdf(Descripcion, 0, 0, "l", "bold"); 
                        cell.Colspan = 6;

                        TablaCabDetalle.AddCell(cell);

                        CODCUENTATmp = CODCUENTA;

                        TablaCabDetalle.CompleteRow();
                    }

                    GeneralTotDebe += (oReparables[i].indDebeHaber == "D" ? oReparables[i].impSoles : 0 );
                    GeneralTotHaber += (oReparables[i].indDebeHaber == "H" ? oReparables[i].impSoles : 0);

                    CuentaTotDebe += (oReparables[i].indDebeHaber == "D" ? oReparables[i].impSoles : 0);
                    CuentaTotHaber += (oReparables[i].indDebeHaber == "H" ? oReparables[i].impSoles : 0);

                    cell = CellPdf(oReparables[i].idComprobante+" "+oReparables[i].numFile+" "+oReparables[i].numVoucher, 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oReparables[i].fecOperacion.ToString("dd/MM/yyyy"), 0, 0, "c", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oReparables[i].fecDocumento.ToString("dd/MM/yyyy"), 0, 0, "c", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oReparables[i].idDOCUMENTO+" "+oReparables[i].numDocumento, 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oReparables[i].GlosaGeneral, 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf((oReparables[i].indDebeHaber=="D"? oReparables[i].impSoles.ToString("N2"):"0.00"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf((oReparables[i].indDebeHaber == "H" ? oReparables[i].impSoles.ToString("N2") : "0.00"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

                    Contador++;
                }

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), -1, -1, "S4"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Total Cuenta: ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 102)), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CuentaTotDebe.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 102)), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CuentaTotHaber.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 102)), 5, 2));
                TablaCabDetalle.CompleteRow();
                
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), -1, -1, "S4"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Total General: ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(GeneralTotDebe.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(GeneralTotHaber.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2));
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

        PdfPCell CellPdf(String titulo, int size, int border, String align, String bold)
        {
            if (border < 0)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 5f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    BaseColor.BLACK))) { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 5f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    BaseColor.BLACK))) { Border = border, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            String Mes = cboInicio.Text;
            String MesFin = cboFin.Text;

            TituloGeneral = " Reparables y Boletas " + " Al Año " + Anio + "del Mes" + Mes + " Al Mes " + MesFin;
            NombrePestaña = " Reparables y Boletas ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 7;

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
                    oHoja.Cells[InicioLinea, 1].Value = " CUENTA ";
                    oHoja.Cells[InicioLinea, 2].Value = "  ";
                    oHoja.Cells[InicioLinea, 3].Value = "  ";

                    oHoja.Cells[InicioLinea, 4].Value = "  ";

                    oHoja.Cells[InicioLinea, 5].Value = "  ";


                    oHoja.Cells[InicioLinea, 6].Value = " (SOLES) ";
                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, InicioLinea, 7])
                    {
                        Rango.Merge = true;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    }
                    oHoja.Cells[InicioLinea, 7].Value = " ";

                    for (int i = 1; i <= 7; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    //Segunda
                    oHoja.Cells[InicioLinea, 1].Value = " VOUCHER ";
                    oHoja.Cells[InicioLinea, 2].Value = " FEC. VOUCHER ";
                    oHoja.Cells[InicioLinea, 3].Value = " FECHA ";
                    oHoja.Cells[InicioLinea, 4].Value = " DOCUMENTO ";
                    oHoja.Cells[InicioLinea, 5].Value = " GLOSA ";
                    oHoja.Cells[InicioLinea, 6].Value = " DEBE ";
                    oHoja.Cells[InicioLinea, 7].Value = " SOLES ";

                    for (int i = 1; i <= 7; i++)
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

                    #region Formato Excel

                    

                    oReparables = (from x in oReparables orderby x.idConceptoRep select x).ToList();

                    int Contador = 0;
                    String CODCUENTA = "";


                    decimal TotDebe = 0;
                    decimal TotHaber = 0;

                    int idConceptoRep = 0;

                    Int32 idConceptoRepTmp = 0;
                    String CODCUENTATmp = "";

                    foreach (ReparablesE item in oReparables)
                    {


                        
                            idConceptoRep = item.idConceptoRep;
                            NomConcepto = item.nomConcepto;

                            if (idConceptoRepTmp != idConceptoRep)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = "";
                                oHoja.Cells[InicioLinea, 2].Value = "";
                                oHoja.Cells[InicioLinea, 3].Value = "";
                                oHoja.Cells[InicioLinea, 4].Value =  idConceptoRep;
                                oHoja.Cells[InicioLinea, 5].Value =  NomConcepto;
                                oHoja.Cells[InicioLinea, 6].Value =  "";
                                oHoja.Cells[InicioLinea, 7].Value = "";

                                idConceptoRepTmp = idConceptoRep;
                                InicioLinea++;
                            }

                            CODCUENTA = item.codCuenta;
                            Descripcion = item.Descripcion;

                            if (CODCUENTATmp != CODCUENTA)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = CODCUENTA;
                                oHoja.Cells[InicioLinea, 2].Value = Descripcion;
                                oHoja.Cells[InicioLinea, 3].Value = "";
                                oHoja.Cells[InicioLinea, 4].Value = "";
                                oHoja.Cells[InicioLinea, 5].Value = "";
                                oHoja.Cells[InicioLinea, 6].Value = "";
                                oHoja.Cells[InicioLinea, 7].Value = "";

                                CODCUENTATmp = CODCUENTA;
                                for (int i = 1; i <= 7; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(217, 217, 217));
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);                                
                                }


                                InicioLinea++;
                            }

                            TotDebe = TotDebe + item.impSoles;
                            TotHaber = TotHaber + item.impDolares;

                            oHoja.Cells[InicioLinea, 1].Value = item.idComprobante + " " + item.numFile + " " + item.numVoucher;
                            oHoja.Cells[InicioLinea, 2].Value = item.fecOperacion;
                            oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 3].Value = item.fecDocumento;
                            oHoja.Cells[InicioLinea, 4].Value = item.idDOCUMENTO + "     " + item.numDocumento;
                            oHoja.Cells[InicioLinea, 5].Value = item.GlosaGeneral;
                            oHoja.Cells[InicioLinea, 6].Value = item.impSoles;
                            oHoja.Cells[InicioLinea, 7].Value = item.impDolares;

                            oHoja.Cells[InicioLinea,2,InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";

                            oHoja.Cells[InicioLinea, 6, InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";



                            Contador++;
                            InicioLinea++;
                        


                       
                    }


                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;


                    oHoja.Cells[InicioLinea, 1].Value = "";
                    oHoja.Cells[InicioLinea, 2].Value = "";
                    oHoja.Cells[InicioLinea, 3].Value = "";
                    oHoja.Cells[InicioLinea, 4].Value = "";
                    oHoja.Cells[InicioLinea, 5].Value = " TOTAL :";
                    oHoja.Cells[InicioLinea, 6].Value = TotDebe;
                    oHoja.Cells[InicioLinea, 7].Value = TotHaber;


                    oHoja.Cells[InicioLinea, 6 , InicioLinea , 7].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;



                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;




                    //FIN SUMATORIA //


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
                    #endregion
                }
            }
        }

        #endregion

        #region Eventos De Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {

            if (tipo == "buscar")
            {
                Int32 idLocal = Convert.ToInt32(cboSucursal.SelectedValue);
                String Anio = VariablesLocales.PeriodoContable.AnioPeriodo;
                String Inicio = Convert.ToString(cboInicio.SelectedValue);
                String Fin = Convert.ToString(cboFin.SelectedValue);
                String TipoReparable = "";

                if (chkReparable.Checked)
                {
                    TipoReparable = "R";
                }
                else
                {
                    TipoReparable = "B";
                }

                lblProcesando.Text = "Obteniendo Datos de Vouchers Reparables...";
                oReparables = AgenteContabilidad.Proxy.ListarReparablesBoletas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, Anio, Inicio, Fin, TipoReparable);
                lblProcesando.Text = "Armando el Reporte...";
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
                Global.MensajeComunicacion("Reparables Boletas Exportado...");
            }
        }

        #endregion

        #region Eventos

        private void frmReparablesBoletas_Load(object sender, EventArgs e)
        {
            //Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 133);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;
        }

        private void frmReparablesBoletas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
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

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        }

        #endregion

        #region FormatoExcel

        public override void Exportar()
        {
            try
            {
                if (oReparables == null || oReparables.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = cboSucursal.Text;
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + cboSucursal.Text;

                String Mes = cboInicio.Text;
                String MesFin = cboFin.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", " Reparables Y Boletas " + NombreLocal + "-" + " Del " + Mes + " Al " + MesFin, "Archivos Excel (*.xlsx)|*.xlsx");

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

        #endregion

    }
}              
internal class PaginaInicioReparables : PdfPageEventHelper
{

    public String Anio { get; set; }
    public Int32 MesInicio { get; set; }
    public Int32 MesFin { get; set; }
    public String TipoReparable { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        String NomReparable = String.Empty;
        String NombreMes = String.Empty;
        String NombreMesFin = String.Empty;
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

        if (TipoReparable == "R")
        {
            NomReparable = "REPARABLE";
        }
        else
        {
            NomReparable = "BOLETAS";
        }

        NombreMes = Global.PrimeraMayuscula(FechasHelper.NombreMes(MesInicio));
        NombreMesFin = Global.PrimeraMayuscula(FechasHelper.NombreMes(MesFin));

        TituloGeneral = "DETALLE DE " + NomReparable;

        SubTitulo = " De " + NombreMes + " a " + NombreMesFin + " del " + Anio;

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.85f, 0.15f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 6, 0));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        table.AddCell(ReaderHelper.NuevaCelda("Pag.    " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        table.CompleteRow(); //Fila completada 

        #endregion

        #region Subtitulos

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2"));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RUC:  " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2"));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2"));
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8f), -1, -1, "S2"));
        table.CompleteRow(); //Fila completada

        document.Add(table); //Añadiendo la tabla al documento PDF

        #endregion

        #region Cabecera del Detalle

        BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
        PdfPTable TablaCabDetalle = new PdfPTable(7);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.1f, 0.4f, 0.1f, 0.1f });

        #region Primera Linea

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Voucher", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Fec. Voucher", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Fecha", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Documento", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Glosa", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("(Soles)", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
        TablaCabDetalle.CompleteRow();

        #endregion

        #region Segunda Linea

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Debe", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Haber", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}
 