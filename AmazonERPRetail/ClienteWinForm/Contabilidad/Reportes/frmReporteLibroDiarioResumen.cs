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
using ClienteWinForm;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteLibroDiarioResumen : FrmMantenimientoBase
    {

        public frmReporteLibroDiarioResumen()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroDiarioE> AgrupadorResumen = null;
        List<RegistroDiarioE> oListaRegistroDiario = null;
        List<RegistroDiarioE> oRegistroDiarioSimplificado = null;
        List<PlanCuentasE> PCRepSimplificado = null;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        Int32 letra = 0;
        Int32 tipoProceso = 0; //1 buscar; 0 exportar;
        String MensajeError = String.Empty;
        String TipoReporte = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();

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

            if (listaLocales.Count <= 2)
            {
                cboSucursales.SelectedValue = 1;
            }

            // Diario de Coprobantes
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioInicial, AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa), "idComprobante", "desComprobanteComp");
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioFinal, AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa), "idComprobante", "desComprobanteComp");
            
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMonedas.DataSource = (from x in ListaMoneda
                                     where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                     orderby x.idMoneda
                                     select x).ToList();
            cboMonedas.ValueMember = "idMoneda";
            cboMonedas.DisplayMember = "desMoneda";

            cboPeriodoIni.DataSource = FechasHelper.CargarMesesContable("PM");
            cboPeriodoIni.ValueMember = "MesId";
            cboPeriodoIni.DisplayMember = "MesDes";
            cboPeriodoIni.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            cboPeriodoFin.DataSource = FechasHelper.CargarMesesContable("PM");
            cboPeriodoFin.ValueMember = "MesId";
            cboPeriodoFin.DisplayMember = "MesDes";
            cboPeriodoFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = String.Empty;
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;

            if (cboPeriodoIni.SelectedValue.ToString() == cboPeriodoFin.SelectedValue.ToString())
            {
                NombreReporte = @"\Diario de " + cboPeriodoIni.Text + " " + Aleatorio.ToString();
                TituloCabecera = cboPeriodoIni.Text.ToUpper() + " " + VariablesLocales.PeriodoContable.AnioPeriodo;
            }
            else
            {
                NombreReporte = @"\Diario de " + cboPeriodoIni.Text + " al " + cboPeriodoFin.Text;
                TituloCabecera = cboPeriodoIni.Text.ToUpper().ToUpper() + " A " + cboPeriodoFin.Text.ToUpper() + " " + VariablesLocales.PeriodoContable.AnioPeriodo;
            }

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio si existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            docPdf.AddAuthor("AMAZONTIC SAC");
            docPdf.AddCreator("AMAZONTIC SAC");
            docPdf.AddCreationDate();
            docPdf.AddTitle("Libro Diario");
            docPdf.AddSubject("Para el PLE");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                String TituloGeneral = String.Empty;
                String SubTitulo = String.Empty;
                TipoReporte = "";
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
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    PaginaInicialRegistroDiarioResumen ev = new PaginaInicialRegistroDiarioResumen();
                    ev.Periodos = TituloCabecera;
                    ev.Moneda = cboMonedas.SelectedValue.ToString();
                    ev.Reporte = TipoReporte;
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Detalle

                    #region Variables

                    iTextSharp.text.Font Fuente = FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                    PdfPTable TablaCabDetalle = new PdfPTable(4);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] {  0.01f, 0.07f, 0.02f, 0.02f });

                    Int32 i = -1;
                    Int32 cntRegistro = AgrupadorResumen.Count - 1;
                    Decimal totDebe = Variables.Cero;
                    Decimal totHaber = Variables.Cero;
                    Decimal totVoucherD = Variables.Cero;
                    Decimal totVoucherH = Variables.Cero;
                    Decimal totGenD = Variables.Cero;
                    Decimal totGenH = Variables.Cero;
                    String Anio = AgrupadorResumen[0].AnioPeriodo;
                    String Mes = AgrupadorResumen[0].MesPeriodo;
                    String idComprobante = AgrupadorResumen[0].idComprobante;
                    String numFile = AgrupadorResumen[0].numFile;
                    String numVoucher = AgrupadorResumen[0].numVoucher;

                    #endregion Variables

                    foreach (RegistroDiarioE item in AgrupadorResumen)
                    {
                        i++;

                        #region Totales

                        if (item.idComprobante != idComprobante)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S1", "N", 0f, 0f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL " + AgrupadorResumen[i - 1].desComprobante + " >>>>", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, -1, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totDebe.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totHaber.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.CompleteRow();

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S11", "N", 0f, 0f));
                            TablaCabDetalle.CompleteRow();

                            totDebe = Variables.Cero;
                            totHaber = Variables.Cero;
                        }

                        #endregion Totales

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codCuenta, null, "N", null, Fuente, -1, 1, "N", "N", 1.5f, 1.5f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta, null, "N", null, Fuente, -1, -1, "N", "N", 1.5f, 1.5f));
                        #region Montos Debe Haber

                        if (cboMonedas.SelectedValue.ToString() == Variables.Soles.ToString())
                        {
                            if (item.indDebeHaber.ToString() == "D")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DebeSoles.ToString("N2"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                                totDebe += item.DebeSoles;
                                totVoucherD += item.DebeSoles;
                                totGenD += item.DebeSoles;
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.HaberSoles.ToString("N2"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                                totHaber += item.HaberSoles;
                                totVoucherH += item.HaberSoles;
                                totGenH += item.HaberSoles;
                            }
                        }
                        else
                        {
                            if (item.indDebeHaber.ToString() == "D")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DebeDolares.ToString("N2"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                                totDebe += item.DebeDolares;
                                totVoucherD += item.DebeDolares;
                                totGenD += item.DebeDolares;
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.HaberDolares.ToString("N2"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                                totHaber += item.HaberDolares;
                                totVoucherH += item.HaberDolares;
                                totGenH += item.HaberDolares;
                            }
                        }

                        #endregion Montos Debe Haber

                        TablaCabDetalle.CompleteRow();

                        Anio = item.AnioPeriodo;
                        Mes = item.MesPeriodo;
                        idComprobante = item.idComprobante;
                        numFile = item.numFile;
                        numVoucher = item.numVoucher;

                    }

                    #region Ultimas Lineas
                    
                    ////Ultima linea de total voucher
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S1", "N", 0f, 0f));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL VOUCHER >>>>", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totVoucherD.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totVoucherH.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    //TablaCabDetalle.CompleteRow();

                    //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S4", "N", 0f, 0f));
                    //TablaCabDetalle.CompleteRow();

                    //Ultima linea total comprobante
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S1", "N", 0f, 0f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL " + AgrupadorResumen[i - 1].desComprobante + " >>>>", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, -1, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totDebe.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totHaber.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "S1", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.CompleteRow();

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S4", "N", 0f, 0f));
                    TablaCabDetalle.CompleteRow();

                    //Ultima linea total general
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, -1, "S7", "N", 0f, 0f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL >>>>", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, -1, "S2", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGenD.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGenH.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.CompleteRow();

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
                    
                    #endregion Ultimas Lineas
                 

                    #endregion Detalle

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

        void ListaReporte()
        {
            try
            {
                String MesIni = cboPeriodoIni.SelectedValue.ToString();
                String MesFin = cboPeriodoFin.SelectedValue.ToString();
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);

                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el Registro de Diario...";
                String idComprobanteIni = cboDiarioInicial.SelectedValue.ToString();
                String idComprobanteFin = cboDiarioFinal.SelectedValue.ToString();

                oListaRegistroDiario = AgenteContabilidad.Proxy.RegistroDeDiarioPLE(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                      idLocal, MesIni, MesFin, VariablesLocales.PeriodoContable.AnioPeriodo,
                                                                                      VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                      idComprobanteIni, idComprobanteFin);

                AgrupadorResumen = (from x in oListaRegistroDiario
                                    group x by new { x.idComprobante,x.desComprobante, x.codCuenta, x.desCuenta, x.indDebeHaber, x.AnioPeriodo, x.MesPeriodo } into g
                                    select new RegistroDiarioE()
                                    {
                                        idComprobante = g.Key.idComprobante,
                                        desComprobante = g.Key.desComprobante,
                                        codCuenta = g.Key.codCuenta,
                                        desCuenta = g.Key.desCuenta,
                                        indDebeHaber = g.Key.indDebeHaber,
                                        AnioPeriodo = g.Key.AnioPeriodo,
                                        MesPeriodo = g.Key.MesPeriodo,
                                        DebeSoles = g.Where(x => x.indDebeHaber == "D").Sum(x => x.impSoles ),
                                        HaberSoles = g.Where(x => x.indDebeHaber == "H").Sum(x => x.impSoles),
                                        DebeDolares = g.Where(x => x.indDebeHaber == "D").Sum(x => x.impDolares),
                                        HaberDolares = g.Where(x => x.indDebeHaber == "H").Sum(x => x.impDolares),
                                    }).ToList();

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
            String Moneda = String.Empty;
            //var ListarPosTmp = PCRepSimplificado.GroupBy(x => x.Titulo).Select(p => p.First()).ToList();

            Moneda = cboMonedas.SelectedValue.ToString();

            if (cboPeriodoIni.SelectedValue.ToString() == cboPeriodoFin.SelectedValue.ToString())
            {
                TituloGeneral = "Periodo " + cboPeriodoIni.Text.ToUpper();
            }
            else
            {
                TituloGeneral = "Periodo " + cboPeriodoIni.Text.ToUpper() + " al " + cboPeriodoFin.Text.ToUpper();    
            }
            
            NombrePestaña = "Libro Diario";

            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {

                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 4;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(64, 64, 64));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    }

                    #endregion

                    #region Cabecera

                    #region Primera Linea Cabecera

                  

                    using (ExcelRange Rango = oHoja.Cells[4, 1, 4, 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Value = "CUENTA CONTABLE ASOCIADA A LA OPERACION";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 3, 4, 4])
                    {
                        Rango.Merge = true;
                        Rango.Value = "MOVIMIENTO";
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    #endregion

                    InicioLinea++;

                    #region Segunda Linea Cabecera

                   

                    oHoja.Cells[InicioLinea, 1].Value = "CODIGO";
                    oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 1].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 2].Value = "RAZON SOCIAL";
                    oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 2].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 3].Value = "DEBE";
                    oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 3].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 3].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 4].Value = "HABER";
                    oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    #endregion

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    int i = -1;
                    int x = 0;
                    int cntRegistro = AgrupadorResumen.Count - 1;
                    decimal totDebe = 0;
                    decimal totHaber = 0;
                    Decimal totGenD = Variables.Cero;
                    Decimal totGenH = Variables.Cero;

                    #region Carga Informacion a Excel

                    foreach (RegistroDiarioE item in AgrupadorResumen)
                    {
                        MensajeError = "Error en: Asiento " + item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher + "Correlativo: " + item.numItem + " Documento: " + item.idDocumento + " " + item.serDocumento + "-" + item.numDocumento;

                        //if (item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher == "1-04-01-000000031")
                        //{
                        //    MessageBox.Show("1-04-01-000000031");
                        //}

                        i++;
                        x = i + 1;
                        //oHoja.Cells[InicioLinea, 1].Value = item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher;
                        //oHoja.Cells[InicioLinea, 2].Value = Convert.ToDateTime(item.fecOperacion).ToString("dd/MM/yy");
                        //oHoja.Cells[InicioLinea, 3].Value = item.GlosaGeneral;
                        //oHoja.Cells[InicioLinea, 4].Value = item.desComprobante;
                        //oHoja.Cells[InicioLinea, 5].Value = item.numItem;

                        //oHoja.Cells[InicioLinea, 6].Value = item.idDocumento;
                        //oHoja.Cells[InicioLinea, 7].Value = item.serDocumento;
                        //oHoja.Cells[InicioLinea, 8].Value = item.numDocumento;
                        //oHoja.Cells[InicioLinea, 9].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                        //oHoja.Cells[InicioLinea, 10].Value = item.Ruc;
                        //oHoja.Cells[InicioLinea, 11].Value = item.RazonSocial;

                        oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                        oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;

                        if (Moneda == Variables.Soles.ToString())
                        {
                            if (item.indDebeHaber.ToString() == "D")
                            {
                                oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 3].Value = item.DebeSoles;
                                oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 4].Value = Variables.ValorCeroDecimal;
                                totDebe += (item.DebeSoles);
                                totGenD += item.DebeSoles;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 3].Value = Variables.ValorCeroDecimal;
                                oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 4].Value = item.HaberSoles;
                                totHaber += (item.HaberSoles);
                                totGenH += item.HaberSoles;
                            }
                        }
                        else if (Moneda != Variables.Soles.ToString())
                        {
                            if (item.indDebeHaber.ToString() == "D")
                            {
                                oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 3].Value = (item.DebeDolares);
                                oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 4].Value = Variables.ValorCeroDecimal;
                                totDebe += (item.DebeDolares);
                                totGenD += item.DebeDolares;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 3].Value = Variables.ValorCeroDecimal;
                                oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 4].Value = (item.HaberDolares);
                                totHaber += (item.HaberDolares);
                                totGenH += item.HaberDolares;
                            }
                        }

                        for (int c = 1; c <= TotColumnas; c++)
                        {
                            oHoja.Cells[InicioLinea, c].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                        }

                        InicioLinea++;

                        if (i < cntRegistro)
                        {
                            if (item.idComprobante != AgrupadorResumen[x].idComprobante)
                            {

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 2])
                                {
                                    Rango.Style.Font.Color.SetColor(Color.Red);
                                    Rango.Merge = true;
                                    Rango.Style.Font.Bold = true;
                                    Rango.Value = "TOTAL " + item.desComprobante;
                                }

                                oHoja.Cells[InicioLinea, 3].Style.Font.Color.SetColor(Color.Red);
                                oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 3].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 3].Value = Convert.ToDecimal(totDebe.ToString("N2"));

                                oHoja.Cells[InicioLinea, 4].Style.Font.Color.SetColor(Color.Red);
                                oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 4].Value = Convert.ToDecimal(totHaber.ToString("N2"));

                                totDebe = 0;
                                totHaber = 0;

                                InicioLinea++;
                            }
                        }
                        else
                        {

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 2])
                            {
                                Rango.Style.Font.Color.SetColor(Color.Red);
                                Rango.Merge = true;
                                Rango.Style.Font.Bold = true;
                                Rango.Value = "TOTAL " + item.desComprobante;
                            }

                            oHoja.Cells[InicioLinea, 3].Style.Font.Color.SetColor(Color.Red);
                            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 3].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, 3].Value = Convert.ToDecimal(totDebe.ToString("N2"));

                            oHoja.Cells[InicioLinea, 4].Style.Font.Color.SetColor(Color.Red);
                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, 4].Value = Convert.ToDecimal(totHaber.ToString("N2"));

                            totDebe = 0;
                            totHaber = 0;

                            InicioLinea++;
                        }
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 2])
                    {
                        Rango.Style.Font.Color.SetColor(Color.Blue);
                        Rango.Merge = true;
                        Rango.Style.Font.Bold = true;
                        Rango.Value = "TOTAL GENERAL ";
                    }

                    oHoja.Cells[InicioLinea, 3].Style.Font.Color.SetColor(Color.Red);
                    oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 3].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 3].Value = Convert.ToDecimal(totGenD.ToString("N2"));

                    oHoja.Cells[InicioLinea, 4].Style.Font.Color.SetColor(Color.Red);
                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 4].Value = Convert.ToDecimal(totGenH.ToString("N2"));

                    totGenD = 0;
                    totGenH = 0;

                    InicioLinea++;

                    #endregion

                    //Linea
                    //Int32 totFilas = InicioLinea;
                    //oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();
                    oHoja.Column(2).Width = 55;


                    #region Propiedades del Excel

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
                    //oHoja.Workbook.Properties.Keywords = String.Empty;
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                    #endregion

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        #endregion Procedimientos de Usuario

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ListaReporte();
                lblProcesando.Text = "Armando el Reporte de Registro de Diario...";
                
                if (oListaRegistroDiario.Count != 0)
                {
                    if (tipoProceso == 1)
                    {
                        //Generando el PDF
                        ConvertirApdf();
                    }
                    else
                    {
                        ExportarExcel(RutaGeneral);
                    }
                }
                else
                {
                    Global.MensajeComunicacion("No Existen Registros");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n\r" + MensajeError);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Marque = String.Empty;
            pbProgress.Visible = false;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            timer.Enabled = false;
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            pnlParametros.Enabled = true;
            btBuscar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                if (tipoProceso == 1)
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
                    Global.MensajeComunicacion("Diario exportado...!!!");
                }
            }
        }

        #endregion

        #region Procesos Heredados

        public override void Exportar()
        {
            try
            {
                if (TipoReporte != "S")
                {
                    if (oListaRegistroDiario.Count == Variables.Cero || oListaRegistroDiario == null)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }
                }
                else
                {
                    if (oRegistroDiarioSimplificado == null && oRegistroDiarioSimplificado.Count == 0)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }
                }

                String NombreArchivo = String.Empty;

                if (cboPeriodoIni.SelectedValue.ToString() == cboPeriodoFin.SelectedValue.ToString())
                {
                    NombreArchivo = "Libro Diario de " + cboPeriodoIni.Text.ToUpper() + "-" + VariablesLocales.PeriodoContable.AnioPeriodo;
                }
                else
                {
                    NombreArchivo = "Libro Diario de " + cboPeriodoIni.Text.ToUpper() + " al " + cboPeriodoFin.Text.ToUpper() + "-" + VariablesLocales.PeriodoContable.AnioPeriodo;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    lblProcesando.Text = String.Empty;
                    lblProcesando.Visible = true;
                    letra = 0;
                    timer.Enabled = true;
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

        #endregion Procesos Heredados

        #region Eventos

        private void frmReporteLibroDiario_Load(object sender, EventArgs e)
        {
            Grid = true;
            //dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;

            PCRepSimplificado = AgenteContabilidad.Proxy.PlanCuentasRepSimplificado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipoProceso = 1;
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                pnlParametros.Enabled = false;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                Text = "Reporte Diario Auxiliar Por Sucursal: " + cboSucursales.Text.ToString();
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

        private void timer_Tick(object sender, EventArgs e)
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

        #endregion Eventos

    }
}

internal class PaginaInicialRegistroDiarioResumen : PdfPageEventHelper
{
    public String Periodos { get; set; }
    public String Moneda { get; set; }
    public String Reporte { get; set; }
    public List<PlanCuentasE> oLista { get; set; }
    public Int32 NumColumn { get; set; }

    public float[] AnchoColumn { get; set; }
    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        BaseColor colFondo = BaseColor.WHITE;
        BaseColor colCabDetalle = BaseColor.LIGHT_GRAY;
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        Boolean MostrarFecPrint = VariablesLocales.oConParametros.MostrarFechaPrint;

        TituloGeneral = "LIBRO DIARIO " + Periodos;

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

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, colFondo, "N", null, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda(MostrarFecPrint ? "Fecha: " + FechaActual : " ", colFondo, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, colFondo, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, BaseColor.BLACK), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda(MostrarFecPrint ? "Hora:   " + HoraActual : " ", colFondo, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", colFondo, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        table.AddCell(ReaderHelper.NuevaCelda("Pag.    " + writer.PageNumber, colFondo, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
        table.CompleteRow(); //Fila completada 

        #endregion Titulos Principales

        #region Subtitulos

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, colFondo, "N", null, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), -1, -1, "S2", "N", 1.5f, 1.5f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, colFondo, "N", null, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), -1, -1, "S2", "N", 1.5f, 1.5f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, colFondo, "N", null, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), -1, -1, "S2", "N", 1.5f, 1.5f));
        table.CompleteRow(); //Fila completada

        //Espacio en blanco
        table.SpacingAfter = 10f;
        table.CompleteRow(); //Fila completada 

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(4);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] {  0.01f, 0.07f, 0.02f, 0.02f });

        #region Primera Linea

        //Columna 1, 2, 3
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CUENTA CONTABLE ASOCIADA A LA OPERACION", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL), 1, 1, "S2", "N", 3f, 5f));
        //Columna 4, 5
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTO", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL), 1, 1, "S2", "N", 3f, 5f));

        TablaCabDetalle.CompleteRow();

        #endregion Primera Linea

        #region Segunda Linea

        //Columna 1
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COD.", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));
        //Columna 2
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DENOMINACION", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));
        //Columna 4
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DEBE", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));
        //Columna 5
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("HABER", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));

        TablaCabDetalle.CompleteRow();

        #endregion Segunda Linea

        #endregion Cabecera del Detalle

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF


    }

}