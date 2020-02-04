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
    public partial class frmReporteLibroDiario : FrmMantenimientoBase
    {

        public frmReporteLibroDiario()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.CrearToolTip(btPle, "Generar Libro Diario para el PLE");
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
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
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;

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

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;
            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

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
                    
                    PaginaInicialRegistroDiario ev = new PaginaInicialRegistroDiario();
                    ev.Periodos = TituloCabecera;
                    ev.Moneda = cboMonedas.SelectedValue.ToString();
                    ev.Reporte = TipoReporte;
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Detalle

                    #region Variables

                    iTextSharp.text.Font Fuente = FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                    PdfPTable TablaCabDetalle = new PdfPTable(11);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.022f, 0.013f, 0.07f, 0.032f, 0.015f, 0.03f, 0.01f, 0.07f, 0.01f, 0.02f, 0.02f });

                    Int32 i = -1;
                    Int32 cntRegistro = oListaRegistroDiario.Count - 1;
                    Decimal totDebe = Variables.Cero;
                    Decimal totHaber = Variables.Cero;
                    Decimal totVoucherD = Variables.Cero;
                    Decimal totVoucherH = Variables.Cero;
                    Decimal totGenD = Variables.Cero;
                    Decimal totGenH = Variables.Cero;
                    String Anio = oListaRegistroDiario[0].AnioPeriodo;
                    String Mes = oListaRegistroDiario[0].MesPeriodo;
                    String idComprobante = oListaRegistroDiario[0].idComprobante;
                    String numFile = oListaRegistroDiario[0].numFile;
                    String numVoucher = oListaRegistroDiario[0].numVoucher;

                    #endregion Variables

                    panel3.SuspendLayout();

                    foreach (RegistroDiarioE item in oListaRegistroDiario)
                    {
                        i++;

                        #region Totales

                        if (Anio + Mes + idComprobante + numFile + numVoucher != item.AnioPeriodo + item.MesPeriodo + item.idComprobante + item.numFile + item.numVoucher)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S7", "N", 0f, 0f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL VOUCHER >>>>", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totVoucherD.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totVoucherH.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.CompleteRow();

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S11", "N", 0f, 0f));
                            TablaCabDetalle.CompleteRow();

                            totVoucherD = Variables.Cero;
                            totVoucherH = Variables.Cero;
                        }

                        if (item.idComprobante != idComprobante)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S7", "N", 0f, 0f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL " + oListaRegistroDiario[i - 1].desComprobante + " >>>>", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, -1, "S2", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totDebe.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totHaber.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                            TablaCabDetalle.CompleteRow();

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S11", "N", 0f, 0f));
                            TablaCabDetalle.CompleteRow();

                            totDebe = Variables.Cero;
                            totHaber = Variables.Cero;
                        } 

                        #endregion Totales

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher, null, "N", null, Fuente, -1, 1, "N", "N", 1.5f, 1.5f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(item.fecOperacion).ToString("dd/MM/yy"), null, "N", null, Fuente, -1, 1, "N", "N", 1.5f, 1.5f));

                        if (item.GlosaGeneral.Length > 55)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.GlosaGeneral.Substring(0, 50), null, "N", null, Fuente, -1, 0, "N", "N", 1.5f, 1.5f));    
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.GlosaGeneral, null, "N", null, Fuente, -1, 0, "N", "N", 1.5f, 1.5f));
                        }
                        
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desComprobante, null, "N", null, Fuente, -1, -1, "N", "N", 1.5f, 1.5f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numItem, null, "N", null, Fuente, -1, 1, "N", "N", 1.5f, 1.5f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento + item.serDocumento + "-" + item.numDocumento, null, "N", null, Fuente, -1, -1, "N", "N", 1.5f, 1.5f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codCuenta, null, "N", null, Fuente, -1, 1, "N", "N", 1.5f, 1.5f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta, null, "N", null, Fuente, -1, -1, "N", "N", 1.5f, 1.5f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                        #region Montos Debe Haber

                        if (cboMonedas.SelectedValue.ToString() == Variables.Soles.ToString())
                        {
                            if (item.indDebeHaber.ToString() == "D")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                                totDebe += item.impSoles;
                                totVoucherD += item.impSoles;
                                totGenD += item.impSoles;
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                                totHaber += item.impSoles;
                                totVoucherH += item.impSoles;
                                totGenH += item.impSoles;
                            }
                        }
                        else
                        {
                            if (item.indDebeHaber.ToString() == "D")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                                totDebe += item.impDolares;
                                totVoucherD += item.impDolares;
                                totGenD += item.impDolares;
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, Fuente, -1, 2, "N", "N", 1.5f, 1.5f));

                                totHaber += item.impDolares;
                                totVoucherH += item.impDolares;
                                totGenH += item.impDolares;
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
                    //Ultima linea de total voucher
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S7", "N", 0f, 0f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL VOUCHER >>>>", null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totVoucherD.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totVoucherH.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.CompleteRow();

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S11", "N", 0f, 0f));
                    TablaCabDetalle.CompleteRow();

                    //Ultima linea total comprobante
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S7", "N", 0f, 0f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL " + oListaRegistroDiario[i - 1].desComprobante + " >>>>", null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, -1, "S2", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totDebe.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totHaber.ToString("N2"), null, "S", new iTextSharp.text.BaseColor(0, 0, 102), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 102)), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.CompleteRow();

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "S11", "N", 0f, 0f));
                    TablaCabDetalle.CompleteRow();

                    //Ultima linea total general
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", iTextSharp.text.BaseColor.RED, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED), -1, -1, "S7", "N", 0f, 0f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL >>>>", null, "S", iTextSharp.text.BaseColor.RED, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED), -1, -1, "S2", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGenD.ToString("N2"), null, "S", iTextSharp.text.BaseColor.RED, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGenH.ToString("N2"), null, "S", iTextSharp.text.BaseColor.RED, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED), -1, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.CompleteRow();

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion Ultimas Lineas

                    panel3.ResumeLayout();

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
                String anio = Convert.ToString(cboAño.SelectedValue);
                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el Registro de Diario...";
                String idComprobanteIni = cboDiarioInicial.SelectedValue.ToString();
                String idComprobanteFin = cboDiarioFinal.SelectedValue.ToString();

                oListaRegistroDiario = AgenteContabilidad.Proxy.RegistroDeDiarioPLE(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                      idLocal, MesIni, MesFin, anio,
                                                                                      VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                      idComprobanteIni, idComprobanteFin);
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
            var ListarPosTmp = PCRepSimplificado.GroupBy(x => x.Titulo).Select(p => p.First()).ToList();

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
                    if (TipoReporte == "S")
                    {
                        Int32 InicioLinea = 10;
                        Int32 TotColumnas = PCRepSimplificado.Count + 2;
                      

                        #region Titulos Principales



                        // Creando Encabezado;
                        oHoja.Cells["A1"].Value = "FORMATO 5.2: LIBRO DIARIO -FORMATO SIMPLIFICADO" ;

                        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                            Rango.Style.Font.Color.SetColor(Color.White);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(64, 64, 64));
                        }

                        oHoja.Cells["A3"].Value = TituloGeneral;

                        using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                        }

                        oHoja.Cells["A4"].Value = "RUC :" + VariablesLocales.SesionUsuario.Empresa.RUC;

                        using (ExcelRange Rango = oHoja.Cells[4, 1, 4, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                        }


                        oHoja.Cells["A6"].Value = "Razon Social: " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                        using (ExcelRange Rango = oHoja.Cells[6, 1, 6, TotColumnas])
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

                        using (ExcelRange Rango = oHoja.Cells[8, 1, 9, 1])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Value = "FECHA O PERIODO";
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        using (ExcelRange Rango = oHoja.Cells[8, 2, 9, 2])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Value = "OPERACION MENSUAL";
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }


                        int ColumnIni = 3;
                        int ColumnaFinal = 2;
                        foreach (var item in ListarPosTmp)
                        {
                            Int32 count = (from y in PCRepSimplificado where y.Titulo == item.Titulo select y).Count();
                            ColumnaFinal += count;
                            using (ExcelRange Rango = oHoja.Cells[8, ColumnIni, 8, ColumnaFinal])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Value = item.Titulo;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }                          
                            ColumnIni += count ;

                        }


                        int ColumnIni2 = 3;
                        foreach (PlanCuentasE item in PCRepSimplificado)
                        {
                            using (ExcelRange Rango = oHoja.Cells[9, ColumnIni2, 9, ColumnIni2])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Value = item.codCuenta;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }
                            ColumnIni2++;
                        }

                        #endregion

                        #endregion

                        #region Carga Informacion a Excel

                        foreach (RegistroDiarioE item in oRegistroDiarioSimplificado)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.fecOperacion.Value;
                            oHoja.Cells[InicioLinea, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 2].Value = item.GlosaGeneral;

                            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecOperacion.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.GlosaGeneral, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            int n = 3;
                            Decimal Valcero = 0;
                            foreach (PlanCuentasE Fila in PCRepSimplificado)
                            {
                                Int32 digitos = Fila.codCuenta.Length;

                                if (Fila.codCuenta == item.codCuenta.Substring(0, digitos))
                                {
                                    if (cboMonedas.SelectedValue.ToString() == "01")
                                    {
                                        oHoja.Cells[InicioLinea, n].Value = item.impSoles;
                                    }
                                    else
                                    {
                                        oHoja.Cells[InicioLinea, n].Value = item.impDolares;
                                    }
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, n].Value = Valcero;                                   
                                }
                                oHoja.Cells[InicioLinea, n].Style.Numberformat.Format = "###,###,##0.00";
                                n++;
                            }

                            InicioLinea++;
                        }
                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 2].Value = "TOTALES";

                        int j = 3;
                        for (int i = 0; i < PCRepSimplificado.Count; i++)
                        {
                            Int32 digitos = PCRepSimplificado[i].codCuenta.Length;
                           
                            if (cboMonedas.SelectedValue.ToString() == "01")
                            {
                                oHoja.Cells[InicioLinea, j].Value = oRegistroDiarioSimplificado.Where(x => x.codCuenta.Substring(0, digitos) == PCRepSimplificado[i].codCuenta).ToList().Sum(x => x.impSoles);
                                //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oRegistroDiarioSimplificado.Where(x => x.codCuenta.Substring(0, digitos) == PCRepSimplificado[i].codCuenta).ToList().Sum(x => x.impSoles).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, j].Value = oRegistroDiarioSimplificado.Where(x => x.codCuenta.Substring(0, digitos) == PCRepSimplificado[i].codCuenta).ToList().Sum(x => x.impDolares);
                                //TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oRegistroDiarioSimplificado.Where(x => x.codCuenta.Substring(0, digitos) == PCRepSimplificado[i].codCuenta).ToList().Sum(x => x.impDolares).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            }
                            oHoja.Cells[InicioLinea, j].Style.Numberformat.Format = "###,###,##0.00";
                            j++;
                        }
                        InicioLinea++;

                        #endregion

                        //Suma
                        InicioLinea++;

                        //Ajustando el ancho de las columnas automaticamente
                        oHoja.Cells.AutoFitColumns();
                        oHoja.Column(2).Width = 63;
                        oHoja.Column(1).Width = 33;
                        //oHoja.Column(13).Width = 55;
                    }
                    else
                    {
                        Int32 InicioLinea = 4;
                        Int32 TotColumnas = 16;

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

                        using (ExcelRange Rango = oHoja.Cells[4, 1, 5, 1])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Value = "NUMERO CORRELATIVO DEL ASIENTO";
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        using (ExcelRange Rango = oHoja.Cells[4, 2, 5, 2])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Value = "FECHA DE OPERACION";
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }
                        using (ExcelRange Rango = oHoja.Cells[4, 3, 5, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Value = "GLOSA O DESCRIPCION DE LA OPERACION";
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        using (ExcelRange Rango = oHoja.Cells[4, 4, 4, 9])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Value = "REFERENCIA DE LA OPERACION";
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        using (ExcelRange Rango = oHoja.Cells[4, 10, 4, 11])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Value = "ANEXO";
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        using (ExcelRange Rango = oHoja.Cells[4, 12, 4, 14])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Value = "CUENTA CONTABLE ASOCIADA A LA OPERACION";
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        using (ExcelRange Rango = oHoja.Cells[4, 15, 4, 16])
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

                        oHoja.Cells[InicioLinea, 4].Value = "CODIGO DEL LIBR O REGISTRO";
                        oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 5].Value = "NUMERO CORRELATIVO";
                        oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 6].Value = "TD";
                        oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 6].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 7].Value = "Serie";
                        oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 7].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 7].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 8].Value = "Numero";
                        oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 9].Value = "Fecha Doc.";
                        oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 10].Value = "Ruc";
                        oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 10].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 10].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 11].Value = "Razon Social";
                        oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 11].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 12].Value = "CODIGO";
                        oHoja.Cells[InicioLinea, 12].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 13].Value = "DENOMINACION";
                        oHoja.Cells[InicioLinea, 13].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 13].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 13].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 14].Value = "TC";
                        oHoja.Cells[InicioLinea, 14].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 15].Value = "DEBE";
                        oHoja.Cells[InicioLinea, 15].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 15].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 15].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        oHoja.Cells[InicioLinea, 16].Value = "HABER";
                        oHoja.Cells[InicioLinea, 16].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, 16].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, 16].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                        #endregion

                        // Auto Filtro
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                        #endregion

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;

                        int i = -1;
                        int x = 0;
                        int cntRegistro = oListaRegistroDiario.Count - 1;
                        decimal totDebe = 0;
                        decimal totHaber = 0;

                        #region Carga Informacion a Excel

                        foreach (RegistroDiarioE item in oListaRegistroDiario)
                        {
                            MensajeError = "Error en: Asiento " + item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher + "Correlativo: " + item.numItem + " Documento: " + item.idDocumento + " " + item.serDocumento + "-" + item.numDocumento;

                            //if (item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher == "1-04-01-000000031")
                            //{
                            //    MessageBox.Show("1-04-01-000000031");
                            //}

                            i++;
                            x = i + 1;
                            oHoja.Cells[InicioLinea, 1].Value = item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher;
                            oHoja.Cells[InicioLinea, 2].Value = Convert.ToDateTime(item.fecOperacion).ToString("dd/MM/yy");
                            oHoja.Cells[InicioLinea, 3].Value = item.GlosaGeneral;
                            oHoja.Cells[InicioLinea, 4].Value = item.desComprobante;
                            oHoja.Cells[InicioLinea, 5].Value = item.numItem;

                            oHoja.Cells[InicioLinea, 6].Value = item.idDocumento;
                            oHoja.Cells[InicioLinea, 7].Value = item.serDocumento;
                            oHoja.Cells[InicioLinea, 8].Value = item.numDocumento;
                            oHoja.Cells[InicioLinea, 9].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                            oHoja.Cells[InicioLinea, 10].Value = item.Ruc;
                            oHoja.Cells[InicioLinea, 11].Value = item.RazonSocial;

                            oHoja.Cells[InicioLinea, 12].Value = item.codCuenta;
                            oHoja.Cells[InicioLinea, 13].Value = item.GlosaGeneral;
                            oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(item.tipCambio);

                            if (Moneda == Variables.Soles.ToString())
                            {
                                if (item.indDebeHaber.ToString() == "D")
                                {
                                    oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 15].Value = item.impSoles;
                                    oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 16].Value = Variables.ValorCeroDecimal;
                                    totDebe += (item.impSoles);
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 15].Value = Variables.ValorCeroDecimal;
                                    oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 16].Value = item.impSoles;
                                    totHaber += (item.impSoles);
                                }
                            }
                            else if (Moneda != Variables.Soles.ToString())
                            {
                                if (item.indDebeHaber.ToString() == "D")
                                {
                                    oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 15].Value = (item.impDolares);
                                    oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 16].Value = Variables.ValorCeroDecimal;
                                    totDebe += (item.impDolares);
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 15].Value = Variables.ValorCeroDecimal;
                                    oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 16].Value = (item.impDolares);
                                    totHaber += (item.impDolares);
                                }
                            }

                            for (int c = 1; c <= TotColumnas; c++)
                            {
                                oHoja.Cells[InicioLinea, c].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                            }

                            InicioLinea++;

                            if (i < cntRegistro)
                            {
                                if (item.idComprobante != oListaRegistroDiario[x].idComprobante)
                                {
                                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 12])
                                    {
                                        Rango.Merge = true;
                                        Rango.Value = String.Empty;
                                    }

                                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 13, InicioLinea, 14])
                                    {
                                        Rango.Style.Font.Color.SetColor(Color.Red);
                                        Rango.Merge = true;
                                        Rango.Style.Font.Bold = true;
                                        Rango.Value = "TOTAL " + item.desComprobante;
                                    }

                                    oHoja.Cells[InicioLinea, 15].Style.Font.Color.SetColor(Color.Red);
                                    oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 15].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(totDebe.ToString("N2"));

                                    oHoja.Cells[InicioLinea, 16].Style.Font.Color.SetColor(Color.Red);
                                    oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 16].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, 16].Value = Convert.ToDecimal(totHaber.ToString("N2"));

                                    totDebe = 0;
                                    totHaber = 0;

                                    InicioLinea++;
                                }
                            }
                            else
                            {
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 12])
                                {
                                    Rango.Style.Font.Color.SetColor(Color.Red);
                                    Rango.Merge = true;
                                    Rango.Value = String.Empty;
                                }

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 13, InicioLinea, 14])
                                {
                                    Rango.Style.Font.Color.SetColor(Color.Red);
                                    Rango.Merge = true;
                                    Rango.Style.Font.Bold = true;
                                    Rango.Value = "TOTAL " + item.desComprobante;
                                }

                                oHoja.Cells[InicioLinea, 15].Style.Font.Color.SetColor(Color.Red);
                                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 15].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(totDebe.ToString("N2"));

                                oHoja.Cells[InicioLinea, 16].Style.Font.Color.SetColor(Color.Red);
                                oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 16].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 16].Value = Convert.ToDecimal(totHaber.ToString("N2"));

                                totDebe = 0;
                                totHaber = 0;

                                InicioLinea++;
                            }
                        }

                        #endregion

                        //Linea
                        //Int32 totFilas = InicioLinea;
                        //oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                        //Suma
                        InicioLinea++;

                        //Ajustando el ancho de las columnas automaticamente
                        oHoja.Cells.AutoFitColumns();
                        oHoja.Column(3).Width = 55;
                        oHoja.Column(11).Width = 42;
                        oHoja.Column(13).Width = 55;
                    }

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
            btPle.Enabled = true;

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
            cboAño.SelectedValue = VariablesLocales.PeriodoContable.AnioPeriodo;
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
            cmsFormatos.Show(btBuscar, new Point(0, btBuscar.Height));
        }

        private void btPle_Click(object sender, EventArgs e)
        {
            cmsFormatoPle.Show(btPle, new Point(0, btPle.Height));
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

        private void tsmFormato1_Click(object sender, EventArgs e)
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
                btPle.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                Text = "Reporte Diario Auxiliar Por Sucursal: " + cboSucursales.Text.ToString();
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                btPle.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmFormato2_Click(object sender, EventArgs e)
        {
            try
            {
                if (PCRepSimplificado != null && PCRepSimplificado.Count > 0)
                {
                    String MesIni = cboPeriodoIni.SelectedValue.ToString();
                    String MesFin = cboPeriodoFin.SelectedValue.ToString();
                    Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);

                    //Obteniendo los datos de la BD
                    lblProcesando.Text = "Obteniendo el Registro de Diario...";
                    String idComprobanteIni = cboDiarioInicial.SelectedValue.ToString();
                    String idComprobanteFin = cboDiarioFinal.SelectedValue.ToString();

                    oRegistroDiarioSimplificado = AgenteContabilidad.Proxy.RegistroDeDiarioSimplificado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                      idLocal, MesIni, MesFin, VariablesLocales.PeriodoContable.AnioPeriodo,
                                                                                      VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                      idComprobanteIni, idComprobanteFin);

                    if (oRegistroDiarioSimplificado != null && oRegistroDiarioSimplificado.Count > 0)
                    {
                        Document docPdf = new Document(PageSize.A1.Rotate(), 10f, 10f, 10f, 10f);
                        Guid Aleatorio = Guid.NewGuid();
                        String NombreReporte = String.Empty;
                        String Extension = ".pdf";
                        String TituloCabecera = String.Empty;

                        if (cboPeriodoIni.SelectedValue.ToString() == cboPeriodoFin.SelectedValue.ToString())
                        {
                            NombreReporte = @"\Diario Simplificado de " + cboPeriodoIni.Text + " " + Aleatorio.ToString();
                            TituloCabecera = cboPeriodoIni.Text.ToUpper() + " " + VariablesLocales.PeriodoContable.AnioPeriodo;
                        }
                        else
                        {
                            NombreReporte = @"\Diario Simplificado de " + cboPeriodoIni.Text + " al " + cboPeriodoFin.Text;
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
                        docPdf.AddTitle("Libro Diario Simplificado");
                        docPdf.AddSubject("Para el PLE");

                        if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
                        {
                            String TituloGeneral = String.Empty;
                            String SubTitulo = String.Empty;
                            TipoReporte = "S";
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

                                Int32 numColumn = PCRepSimplificado.Count + 2;
                                float[] AnchoCol = new float[numColumn];

                                for (int i = 0; i < numColumn; i++)
                                {
                                    if (i == 0)
                                    {
                                        AnchoCol[i] = 0.05f;
                                    }
                                    else if (i == 1)
                                    {
                                        AnchoCol[i] = 0.1f;
                                    }
                                    else
                                    {
                                        AnchoCol[i] = 0.04f;
                                    }
                                }

                                PaginaInicialRegistroDiario ev = new PaginaInicialRegistroDiario
                                {
                                    Periodos = TituloCabecera,
                                    Moneda = cboMonedas.SelectedValue.ToString(),
                                    Reporte = TipoReporte,
                                    Lista = PCRepSimplificado,
                                    NumColumn = numColumn,
                                    AnchoColumn = AnchoCol
                                };

                                oPdfw.PageEvent = ev;

                                docPdf.Open();

                                iTextSharp.text.Font Fuente = FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                                PdfPTable TablaCabDetalle = new PdfPTable(numColumn)
                                {
                                    WidthPercentage = 100
                                };

                                TablaCabDetalle.SetWidths(AnchoCol);

                                foreach (RegistroDiarioE item in oRegistroDiarioSimplificado)
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecOperacion.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.GlosaGeneral, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));

                                    foreach (PlanCuentasE Fila in PCRepSimplificado)
                                    {
                                        Int32 digitos = Fila.codCuenta.Length;

                                        if (Fila.codCuenta == item.codCuenta.Substring(0,digitos))
                                        {
                                            if (cboMonedas.SelectedValue.ToString() == "01")
                                            {
                                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                            }
                                            else
                                            {
                                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                            }
                                        }
                                        else
                                        {
                                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                        }
                                    }

                                    TablaCabDetalle.CompleteRow();
                                }

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTALES", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2", "N"));

                                for (int i = 0; i < PCRepSimplificado.Count; i++)
                                {
                                    Int32 digitos = PCRepSimplificado[i].codCuenta.Length;

                                    if (cboMonedas.SelectedValue.ToString() == "01")
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oRegistroDiarioSimplificado.Where(x => x.codCuenta.Substring(0,digitos) == PCRepSimplificado[i].codCuenta).ToList().Sum(x => x.impSoles).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    }
                                    else
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oRegistroDiarioSimplificado.Where(x => x.codCuenta.Substring(0, digitos) == PCRepSimplificado[i].codCuenta).ToList().Sum(x => x.impDolares).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    }
                                }

                                TablaCabDetalle.CompleteRow();

                                docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                                PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                                //Crear una nueva acción para enviar el documento a nuestro nuevo destino.
                                //Establecer la acción abierta para nuestro objeto escritor
                                oPdfw.SetOpenAction(action);

                                //Liberando memoria
                                oPdfw.Flush();
                                docPdf.Close();
                            }
                        }


                        //Mostrando el reporte en un web browser
                        if (!String.IsNullOrEmpty(RutaGeneral))
                        {
                            wbNavegador.Navigate(RutaGeneral);
                            RutaGeneral = String.Empty;
                            tipoProceso = 0;
                        } 
                    }
                }
                else
                {
                    Global.MensajeAdvertencia("No hay Plan Contable para el Diario Simplificado");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiDiario_Click(object sender, EventArgs e)
        {
            #region Variables

            String nomLibro = String.Empty;
            String MesReal = cboPeriodoFin.SelectedValue.ToString();
            String AnioReal = VariablesLocales.PeriodoContable.AnioPeriodo;
            String RutaArchivoTexto = String.Empty;

            #endregion Variables

            try
            {
                #region Validaciones

                if (oListaRegistroDiario == null || oListaRegistroDiario.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay registros a exportar.");
                    return;
                }

                if (cboPeriodoIni.SelectedValue.ToString() != cboPeriodoFin.SelectedValue.ToString())
                {
                    Global.MensajeFault("Tiene que definir el mismo periodo en la busqueda.");
                    return;
                }

                #endregion

                if (Global.MensajeConfirmacion("Desea generar el Lbro Diario para el PLE.") == DialogResult.No)
                {
                    return;
                }

                nomLibro = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + AnioReal + MesReal + "00050100001111";
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
                        String Periodo = String.Empty;
                        String codUniOpe = String.Empty;
                        String Correlativo = String.Empty;
                        String codCuenta = String.Empty;
                        String UnidadOpe = String.Empty;
                        String codCentroC = String.Empty;
                        String Moneda = String.Empty;
                        String tipDocEmisor = String.Empty;
                        String numDocEmisor = String.Empty;
                        String idDocumento = String.Empty;
                        String serDocumento = String.Empty;
                        String numDocumento = String.Empty;
                        String fecContable = String.Empty;
                        String fecVencimiento = String.Empty;
                        String fecOperacion = String.Empty;
                        String Glosa = String.Empty;
                        String GlosaRefe = String.Empty;
                        String totDebe = String.Empty;
                        String totHaber = String.Empty;
                        String DatoEst = String.Empty;
                        String Estado = String.Empty;

                        Decimal MontoDebe = Variables.ValorCeroDecimal;
                        Decimal MontoHaber = Variables.ValorCeroDecimal;

                        #endregion Variables

                        foreach (RegistroDiarioE item in oListaRegistroDiario)
                        {
                            #region Datos

                            Periodo = item.AnioPeriodo + item.MesPeriodo + "00";
                            codUniOpe = item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher + item.numItem;
                            Correlativo = item.Campo3;
                            codCuenta = item.codCuenta;
                            UnidadOpe = String.Empty;
                            codCentroC = String.Empty;

                            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                            {
                                Moneda = "PEN";
                            }
                            else
                            {
                                Moneda = "USD";
                            }

                            tipDocEmisor = item.TD;
                            numDocEmisor = item.Ruc;
                            idDocumento = item.codSunat;
                            serDocumento = item.serDocumento;
                            numDocumento = item.numDocumento;

                            if (String.IsNullOrEmpty(tipDocEmisor)) tipDocEmisor = String.Empty;
                            if (String.IsNullOrEmpty(numDocEmisor)) numDocEmisor = Variables.Cero.ToString();
                            if (String.IsNullOrEmpty(idDocumento)) idDocumento = String.Empty;
                            if (String.IsNullOrEmpty(serDocumento)) serDocumento = String.Empty;
                            if (String.IsNullOrEmpty(numDocumento)) numDocumento = Variables.Cero.ToString();

                            fecContable = item.fecOperacion.Value.ToString("dd/MM/yyyy");
                            fecVencimiento = String.Empty;
                            fecOperacion = item.fecOperacion.Value.ToString("dd/MM/yyyy");

                            Glosa = item.GlosaGeneral.Trim();
                            if (String.IsNullOrEmpty(Glosa)) Glosa = item.desCuenta;
                            if (Glosa.Length > 100) Glosa = Global.Izquierda(Glosa, 100);

                            Glosa.Replace("%", String.Empty);
                            Glosa.Replace("$", String.Empty);
                            Glosa.Replace("/", String.Empty);
                            Glosa.Replace("+", String.Empty);

                            GlosaRefe = String.Empty;

                            #region Montos Debe y Haber

                            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                            {
                                if (item.indDebeHaber == Variables.Debe)
                                {
                                    MontoDebe = item.impSoles;
                                    MontoHaber = Variables.ValorCeroDecimal;
                                }
                                else
                                {
                                    MontoDebe = Variables.ValorCeroDecimal;
                                    MontoHaber = item.impSoles;
                                }

                                if (MontoDebe < 0)
                                {
                                    MontoHaber = MontoDebe * -1;
                                    MontoDebe = item.impSoles;
                                }
                                else if (MontoHaber < 0)
                                {
                                    MontoDebe = MontoDebe * -1;
                                    MontoHaber = item.impSoles;
                                }
                            }
                            else
                            {
                                if (item.indDebeHaber == Variables.Debe)
                                {
                                    MontoDebe = item.impDolares;
                                    MontoHaber = Variables.ValorCeroDecimal;
                                }
                                else
                                {
                                    MontoDebe = Variables.ValorCeroDecimal;
                                    MontoHaber = item.impDolares;
                                }

                                if (MontoDebe < 0)
                                {
                                    MontoHaber = MontoDebe * -1;
                                    MontoDebe = item.impDolares;
                                }
                                else if (MontoHaber < 0)
                                {
                                    MontoDebe = MontoDebe * -1;
                                    MontoHaber = item.impDolares;
                                }
                            }

                            if (MontoDebe == Variables.Cero)
                            {
                                totDebe = "0.00";
                            }
                            else
                            {
                                totDebe = MontoDebe.ToString();
                            }

                            if (MontoHaber == Variables.Cero)
                            {
                                totHaber = "0.00";
                            }
                            else
                            {
                                totHaber = MontoHaber.ToString();
                            }

                            #endregion Montos Debe y Haber

                            if (item.idComprobante == Variables.RegistroVenta) DatoEst = "140100&" + Periodo + "&" + codUniOpe + "&" + Correlativo;
                            if (item.idComprobante == Variables.RegistroCompra) DatoEst = "080100&" + Periodo + "&" + codUniOpe + "&" + Correlativo;

                            if (Convert.ToDateTime(item.fecOperacion).ToString("yyyyMM") == AnioReal + MesReal)
                            {
                                Estado = "1";
                            }
                            else
                            {
                                Estado = "8";
                            }

                            #endregion Datos

                            #region Insertar Linea

                            if ((MontoDebe + MontoHaber) > 0)
                            {
                                if (String.IsNullOrEmpty(idDocumento)) idDocumento = "00";

                                if (serDocumento.Length < 4 && idDocumento != "00") serDocumento = Global.Derecha("0000" + serDocumento, 4);

                                if (idDocumento == "00")
                                {
                                    serDocumento = String.Empty;
                                    numDocumento = Variables.Cero.ToString();
                                }

                                if (tipDocEmisor == Variables.Cero.ToString()) numDocEmisor = Variables.Cero.ToString();

                                Linea.Append(Periodo).Append("|").Append(codUniOpe).Append("|").Append(Correlativo).Append("|");
                                Linea.Append(codCuenta).Append("|").Append(UnidadOpe).Append("|").Append(codCentroC).Append("|");
                                Linea.Append(Moneda).Append("|").Append(tipDocEmisor).Append("|").Append(numDocEmisor).Append("|");
                                Linea.Append(idDocumento).Append("|").Append(serDocumento).Append("|").Append(numDocumento).Append("|");
                                Linea.Append(fecContable).Append("|").Append(fecVencimiento).Append("|").Append(fecOperacion).Append("|");
                                Linea.Append(Glosa).Append("|").Append(GlosaRefe).Append("|").Append(totDebe).Append("|");
                                Linea.Append(totHaber).Append("|").Append(DatoEst).Append("|").Append(Estado).Append("|");

                                oSw.WriteLine(Linea.ToString());
                                Linea.Clear();
                            }

                            #endregion Insertar Linea
                        }

                        Global.MensajeComunicacion("Libro exportado");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiSimplificado_Click(object sender, EventArgs e)
        {
            #region Variables

            String nomLibro = String.Empty;
            String MesReal = cboPeriodoFin.SelectedValue.ToString();
            String AnioReal = VariablesLocales.PeriodoContable.AnioPeriodo;
            String RutaArchivoTexto = String.Empty;

            #endregion Variables

            try
            {
                #region Validaciones

                if (oListaRegistroDiario == null || oListaRegistroDiario.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay registros a exportar.");
                    return;
                }

                if (cboPeriodoIni.SelectedValue.ToString() != cboPeriodoFin.SelectedValue.ToString())
                {
                    Global.MensajeFault("Tiene que definir el mismo periodo en la busqueda.");
                    return;
                }

                #endregion

                if (Global.MensajeConfirmacion("Desea generar el Libro Diario Simplificado para el PLE.") == DialogResult.No)
                {
                    return;
                }

                nomLibro = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + AnioReal + MesReal + "00050200001111";
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
                        String Periodo = String.Empty;
                        String codUniOpe = String.Empty;
                        String Correlativo = String.Empty;
                        String codCuenta = String.Empty;
                        String UnidadOpe = String.Empty;
                        String codCentroC = String.Empty;
                        String Moneda = String.Empty;
                        String tipDocEmisor = String.Empty;
                        String numDocEmisor = String.Empty;
                        String idDocumento = String.Empty;
                        String serDocumento = String.Empty;
                        String numDocumento = String.Empty;
                        String fecContable = String.Empty;
                        String fecVencimiento = String.Empty;
                        String fecOperacion = String.Empty;
                        String Glosa = String.Empty;
                        String GlosaRefe = String.Empty;
                        String totDebe = String.Empty;
                        String totHaber = String.Empty;
                        String DatoEst = String.Empty;
                        String Estado = String.Empty;

                        Decimal MontoDebe = Variables.ValorCeroDecimal;
                        Decimal MontoHaber = Variables.ValorCeroDecimal;

                        #endregion Variables

                        foreach (RegistroDiarioE item in oListaRegistroDiario)
                        {
                            #region Datos

                            Periodo = item.AnioPeriodo + item.MesPeriodo + "00";
                            codUniOpe = item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher + item.numItem;
                            Correlativo = item.Campo3;
                            codCuenta = item.codCuenta;
                            UnidadOpe = String.Empty;
                            codCentroC = String.Empty;

                            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                            {
                                Moneda = "PEN";
                            }
                            else
                            {
                                Moneda = "USD";
                            }

                            tipDocEmisor = item.TD;
                            numDocEmisor = item.Ruc;
                            idDocumento = item.codSunat;
                            serDocumento = item.serDocumento;
                            numDocumento = item.numDocumento;

                            if (String.IsNullOrEmpty(tipDocEmisor)) tipDocEmisor = String.Empty;
                            if (String.IsNullOrEmpty(numDocEmisor)) numDocEmisor = Variables.Cero.ToString();
                            if (String.IsNullOrEmpty(idDocumento)) idDocumento = String.Empty;
                            if (String.IsNullOrEmpty(serDocumento)) serDocumento = String.Empty;
                            if (String.IsNullOrEmpty(numDocumento)) numDocumento = Variables.Cero.ToString();

                            fecContable = item.fecOperacion.Value.ToString("dd/MM/yyyy");
                            fecVencimiento = String.Empty;
                            fecOperacion = item.fecOperacion.Value.ToString("dd/MM/yyyy");

                            Glosa = item.GlosaGeneral.Trim();
                            if (String.IsNullOrEmpty(Glosa)) Glosa = item.desCuenta;
                            if (Glosa.Length > 100) Glosa = Global.Izquierda(Glosa, 100);

                            Glosa.Replace("%", String.Empty);
                            Glosa.Replace("$", String.Empty);
                            Glosa.Replace("/", String.Empty);
                            Glosa.Replace("+", String.Empty);

                            GlosaRefe = String.Empty;

                            #region Montos Debe y Haber

                            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                            {
                                if (item.indDebeHaber == Variables.Debe)
                                {
                                    MontoDebe = item.impSoles;
                                    MontoHaber = Variables.ValorCeroDecimal;
                                }
                                else
                                {
                                    MontoDebe = Variables.ValorCeroDecimal;
                                    MontoHaber = item.impSoles;
                                }

                                if (MontoDebe < 0)
                                {
                                    MontoHaber = MontoDebe * -1;
                                    MontoDebe = item.impSoles;
                                }
                                else if (MontoHaber < 0)
                                {
                                    MontoDebe = MontoDebe * -1;
                                    MontoHaber = item.impSoles;
                                }
                            }
                            else
                            {
                                if (item.indDebeHaber == Variables.Debe)
                                {
                                    MontoDebe = item.impDolares;
                                    MontoHaber = Variables.ValorCeroDecimal;
                                }
                                else
                                {
                                    MontoDebe = Variables.ValorCeroDecimal;
                                    MontoHaber = item.impDolares;
                                }

                                if (MontoDebe < 0)
                                {
                                    MontoHaber = MontoDebe * -1;
                                    MontoDebe = item.impDolares;
                                }
                                else if (MontoHaber < 0)
                                {
                                    MontoDebe = MontoDebe * -1;
                                    MontoHaber = item.impDolares;
                                }
                            }

                            if (MontoDebe == Variables.Cero)
                            {
                                totDebe = "0.00";
                            }
                            else
                            {
                                totDebe = MontoDebe.ToString();
                            }

                            if (MontoHaber == Variables.Cero)
                            {
                                totHaber = "0.00";
                            }
                            else
                            {
                                totHaber = MontoHaber.ToString();
                            }

                            #endregion Montos Debe y Haber

                            if (item.idComprobante == Variables.RegistroVenta) DatoEst = "140100&" + Periodo + "&" + codUniOpe + "&" + Correlativo;
                            if (item.idComprobante == Variables.RegistroCompra) DatoEst = "080100&" + Periodo + "&" + codUniOpe + "&" + Correlativo;

                            if (Convert.ToDateTime(item.fecOperacion).ToString("yyyyMM") == AnioReal + MesReal)
                            {
                                Estado = "1";
                            }
                            else
                            {
                                Estado = "8";
                            }

                            #endregion Datos

                            #region Insertar Linea

                            if ((MontoDebe + MontoHaber) > 0)
                            {
                                if (String.IsNullOrEmpty(idDocumento)) idDocumento = "00";

                                if (serDocumento.Length < 4 && idDocumento != "00") serDocumento = Global.Derecha("0000" + serDocumento, 4);

                                if (idDocumento == "00")
                                {
                                    serDocumento = String.Empty;
                                    numDocumento = Variables.Cero.ToString();
                                }

                                if (tipDocEmisor == Variables.Cero.ToString()) numDocEmisor = Variables.Cero.ToString();

                                Linea.Append(Periodo).Append("|").Append(codUniOpe).Append("|").Append(Correlativo).Append("|");
                                Linea.Append(codCuenta).Append("|").Append(UnidadOpe).Append("|").Append(codCentroC).Append("|");
                                Linea.Append(Moneda).Append("|").Append(tipDocEmisor).Append("|").Append(numDocEmisor).Append("|");
                                Linea.Append(idDocumento).Append("|").Append(serDocumento).Append("|").Append(numDocumento).Append("|");
                                Linea.Append(fecContable).Append("|").Append(fecVencimiento).Append("|").Append(fecOperacion).Append("|");
                                Linea.Append(Glosa).Append("|").Append(GlosaRefe).Append("|").Append(totDebe).Append("|");
                                Linea.Append(totHaber).Append("|").Append(DatoEst).Append("|").Append(Estado).Append("|");

                                oSw.WriteLine(Linea.ToString());
                                Linea.Clear();
                            }

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

        #endregion Eventos

    }
}

internal class PaginaInicialRegistroDiario : PdfPageEventHelper
{
    public String Periodos { get; set; }
    public String Moneda { get; set; }
    public String Reporte { get; set; }
    public List<PlanCuentasE> Lista { get; set; }
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
        if (Reporte == "")
        {
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };
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

            PdfPTable TablaCabDetalle = new PdfPTable(11);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.022f, 0.013f, 0.07f, 0.032f, 0.015f, 0.03f, 0.01f, 0.07f, 0.01f, 0.02f, 0.02f });

            #region Primera Linea

            //Columna 1, 2, 3
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUMERO CORRELATIVO DEL ASIENTO", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL), 1, 1, "N", "S2", 0f, 9f));
            //Columna 4
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA DE OPERA-CION", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL), 1, 1, "N", "S2", 0f, 9f));
            //Columna 5
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("GLOSA O DESCRIPCIÓN DE LA OPERACION", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL), 1, 1, "N", "S2", 0f, 15f));
            //Columna 6, 7, 8
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("REFERENCIA DE LA OPERACION", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL), 1, 1, "S3", "N", 3f, 5f));
            //Columna 9, 10, 11
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CUENTA CONTABLE ASOCIADA A LA OPERACION", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL), 1, 1, "S3", "N", 3f, 5f));
            //Columna 12, 13
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTO", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.NORMAL), 1, 1, "S2", "N", 3f, 5f));

            TablaCabDetalle.CompleteRow();

            #endregion Primera Linea

            #region Segunda Linea

            //Columna 6
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO DEL LIBRO Ó REGISTRO", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 5f));
            //Columna 7
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUMERO CORRELA.", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 5f));
            //Columna 8
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUMERO DEL DOCUMENTO SUSTENTARIO", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 3f, 4f));
            //Columna 9
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COD.", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));
            //Columna 10
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DENOMINACION", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));
            //Columna 11
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));
            //Columna 12
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DEBE", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));
            //Columna 13
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("HABER", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 0f, 9f));

            TablaCabDetalle.CompleteRow();

            #endregion Segunda Linea

            #endregion Cabecera del Detalle

            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
        }
        else if(Reporte == "S")
        {
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

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

            PdfPTable TablaCabDetalle = new PdfPTable(NumColumn);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(AnchoColumn);

            //Columna 1
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA O PERIODO", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "S2"));
            //Columna 2
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OPERACIÓN MENSUAL", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "S2"));

            var ListarPosTmp = Lista.GroupBy(x => x.Titulo).Select(p => p.First()).ToList();

            foreach (var item in ListarPosTmp)
            {
                Int32 count = (from x in Lista where x.Titulo == item.Titulo select x).Count();

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Titulo, colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "S" + count.ToString(), "N"));
            }

            foreach (PlanCuentasE item in Lista)
            {

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codCuenta, colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N"));

            }

            TablaCabDetalle.CompleteRow();

            #endregion Cabecera del Detalle

            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
        }

    }

}