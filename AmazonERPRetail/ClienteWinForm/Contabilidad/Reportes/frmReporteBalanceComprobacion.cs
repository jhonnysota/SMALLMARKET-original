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
using Entidades.Generales;
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
    public partial class frmReporteBalanceComprobacion : FrmMantenimientoBase
    {

        #region Constructor
        public frmReporteBalanceComprobacion()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            //Global.CrearToolTip(btPle, "Importar para el PLE");
            //Global.CrearToolTip(btPdb, "Importar para el PDB");
            LlenarCombos();
            Nivel();
        }
        
        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<BalanceComprobacionE> oListaBalanceComprobacion = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        string Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        Decimal TotMayorDebe;
        Decimal TotMayorHaber;
        Decimal TotActualDebe;
        Decimal TotActualHaber;
        Decimal TotInvenActivo;
        Decimal TotInvenPasivo;
        Decimal TotFuncionPerdida;
        Decimal TotFuncionGanancia;
        Decimal TotNaturalezaPerdida;
        Decimal TotNaturalezaGanancia;
        Decimal ParPas;
        Decimal ParPer1;
        Decimal ParPer2;
        Decimal TotalEmpresa1;
        Decimal TotalEmpresa2;
        Decimal TotalEmpresa3;
        Decimal TotalEmpresa4;
        Decimal TotalEmpresa5;
        Decimal TotalEmpresa6;
        Decimal a;
        Decimal b;
        Decimal c;
        Decimal d;
        Decimal e;
        Decimal f;
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

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMonedas.DataSource = (from x in ListaMoneda
                                     where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                     orderby x.idMoneda
                                     select x).ToList();
            cboMonedas.ValueMember = "idMoneda";
            cboMonedas.DisplayMember = "desMoneda";

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

            //////Formato///////
            cboFormato.DataSource = Global.CargarMA();
            cboFormato.ValueMember = "id";
            cboFormato.DisplayMember = "Nombre";


        }

        void Nivel()
        {
            try
            {
                nudNivel.Value = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
                nudNivel.Minimum = 1;
                nudNivel.Maximum = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\BalanceComprobacion " + Aleatorio.ToString();
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

                PaginaInicioBalance ev = new PaginaInicioBalance();
                ev.Anio = Convert.ToString(cboAño.SelectedValue);
                ev.Mes = Convert.ToInt32(cboMes.SelectedValue);
                ev.Formato = Convert.ToString(cboFormato.SelectedValue);
                ev.Mon = cboMonedas.SelectedValue.ToString();
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(12);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.040f, 0.200f, 0.071f, 0.071f, 0.071f, 0.071f, 0.071f, 0.071f, 0.071f, 0.071f, 0.071f, 0.071f });

                TotMayorDebe = 0;
                TotMayorHaber = 0;
                TotActualDebe = 0;
                TotActualHaber = 0;
                TotInvenActivo = 0;
                TotInvenPasivo = 0;
                TotFuncionPerdida = 0;
                TotFuncionGanancia =  0;
                TotNaturalezaPerdida = 0;
                TotNaturalezaGanancia = 0;
                ParPas = 0;
                ParPer1 = 0;
                ParPer2 = 0;
                TotalEmpresa1 = 0;
                TotalEmpresa2 = 0;
                TotalEmpresa3 = 0;
                TotalEmpresa4 = 0;
                TotalEmpresa5 = 0;
                TotalEmpresa6 = 0;

                a = 0;
                b = 0;
                c = 0;
                d = 0;
                e = 0;
                f = 0;

                foreach (BalanceComprobacionE item in oListaBalanceComprobacion)
                {
                    TotMayorDebe = TotMayorDebe + item.MayorDebe;
                    TotMayorHaber = TotMayorHaber + item.MayorHaber;

                    TotActualDebe = TotActualDebe + item.SaldoActualDebe;
                    TotActualHaber = TotActualHaber + item.SaldoActualHaber;

                    TotInvenActivo = TotInvenActivo + item.InvenActivo;
                    TotInvenPasivo = TotInvenPasivo + item.InvenPasivo;

                    TotFuncionPerdida = TotFuncionPerdida + item.PorFuncionPerdida;
                    TotFuncionGanancia = TotFuncionGanancia + item.PorFuncionGanancia;

                    TotNaturalezaPerdida = TotNaturalezaPerdida + item.PorNaturalezaPerdida;
                    TotNaturalezaGanancia = TotNaturalezaGanancia + item.PorNaturalezaGanancia;

                    cell = new PdfPCell(new Paragraph(item.CodCuenta, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.DesCuenta, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.MayorDebe.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.MayorHaber.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.SaldoActualDebe.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.SaldoActualHaber.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.InvenActivo.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.InvenPasivo.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.PorFuncionPerdida.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.PorFuncionGanancia.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.PorNaturalezaPerdida.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.PorNaturalezaGanancia.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();
                }

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph("-----------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("------------------------------------------------------------------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                TablaCabDetalle.AddCell(cell);
                TablaCabDetalle.CompleteRow();

                ParPas = TotInvenActivo - TotInvenPasivo;

                if (ParPas < 0)
                {
                    a = ParPas * -1;
                    b = 0;
                }
                else
                {
                   a = 0;
                   b = ParPas;
                }

                ParPer1 = TotFuncionPerdida - TotFuncionGanancia;

                if (ParPer1 < 0)
                {
                    c = ParPer1 * -1;
                    d = 0;
                }
                else
                {
                    c = 0;
                    d = ParPer1;
                }

                ParPer2 = TotNaturalezaPerdida - TotNaturalezaGanancia;

                if (ParPer2 < 0)
                {
                    e = ParPer2 * -1;
                    f = 0;
                }
                else
                {
                    e = 0;
                    f = ParPer2;
                }

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Parciales", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotMayorDebe.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotMayorHaber.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotActualDebe.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotActualHaber.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotInvenActivo.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotInvenPasivo.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotFuncionPerdida.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotFuncionGanancia.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotNaturalezaPerdida.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotNaturalezaGanancia.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                TablaCabDetalle.AddCell(cell);
                TablaCabDetalle.CompleteRow();

                TotalEmpresa1 = a + TotInvenActivo;
                TotalEmpresa2 = b + TotInvenPasivo;
                TotalEmpresa3 = c + TotFuncionPerdida;
                TotalEmpresa4 = d + TotFuncionGanancia;
                TotalEmpresa5 = e + TotNaturalezaPerdida;
                TotalEmpresa6 = f + TotNaturalezaGanancia;

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("**UTILIDAD(PERDIDA)**", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(a.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(b.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(c.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(d.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(e.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(f.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("**TOTALEMPRESA**", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalEmpresa1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalEmpresa2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalEmpresa3.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalEmpresa4.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalEmpresa5.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalEmpresa6.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("----------------------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                TablaCabDetalle.AddCell(cell);

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
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);              
                String Mes = Convert.ToString(cboMes.SelectedValue);
                String Version = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                String idMoneda = cboMonedas.SelectedValue.ToString();
                Int32 Nivel = Convert.ToInt32(nudNivel.Value);
                String Formato = Convert.ToString(cboFormato.SelectedValue);
                Anio = Convert.ToString(cboAño.SelectedValue);

                lblProcesando.Text = "Obteniendo el Balance de Comprobacion...";
                oListaBalanceComprobacion = AgenteContabilidad.Proxy.ListarBalanceComprobacionAcumulado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, Anio, Mes, Version, idMoneda, Nivel, Formato);
                lblProcesando.Text = "Armando el Balance...";

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
                Global.MensajeComunicacion("Balance Exportado...");
            }
        }

        #endregion

        #region Eventos Exportar Excel

        public override void Exportar()
        {
            try
            {
                if (oListaBalanceComprobacion == null || oListaBalanceComprobacion.Count == Variables.Cero)
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
                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Balance Comprobacion" + NombreLocal + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

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
            String nombreMes = cboMes.Text;



            TituloGeneral = " Balance Comprobacion " + " Al Año " + Anio + " Del Mes " + nombreMes;
            NombrePestaña = " Balance Comprobacion";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 12;

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
                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " SUMAS DEL MAYOR ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 4])
                    {
                        Rango.Merge = true;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                    }

                    oHoja.Cells[InicioLinea, 4].Value = "  ";

                    oHoja.Cells[InicioLinea, 5].Value = " SALDOS ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea, 6])
                    {
                        Rango.Merge = true;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                    }

                    oHoja.Cells[InicioLinea, 6].Value = " ";

                    oHoja.Cells[InicioLinea, 7].Value = " INVENTARIO ";
                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea, 8])
                    {
                        Rango.Merge = true;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                    }
                    oHoja.Cells[InicioLinea, 8].Value = "  ";

                    oHoja.Cells[InicioLinea, 9].Value = " RESULTADO POR FUNCION ";
                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, InicioLinea, 10])
                    {
                        Rango.Merge = true;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    }

                    oHoja.Cells[InicioLinea, 10].Value = " ";
                    oHoja.Cells[InicioLinea, 11].Value = "RESULTADO POR NATURALEZA";
                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 11, InicioLinea, 12])
                    {
                        Rango.Merge = true;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    }

                    oHoja.Cells[InicioLinea, 12].Value = " ";

                    for (int i = 1; i <= 12; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }




                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    //Segunda
                    oHoja.Cells[InicioLinea, 1].Value = " Cuenta ";
                    oHoja.Cells[InicioLinea, 2].Value = " DETALLE ";
                    oHoja.Cells[InicioLinea, 3].Value = " DEBE ";
                    oHoja.Cells[InicioLinea, 4].Value = " HABER ";
                    oHoja.Cells[InicioLinea, 5].Value = " DEUDOR ";
                    oHoja.Cells[InicioLinea, 6].Value = " ACREEDOR ";
                    oHoja.Cells[InicioLinea, 7].Value = " ACTIVO ";
                    oHoja.Cells[InicioLinea, 8].Value = " PASIVO ";
                    oHoja.Cells[InicioLinea, 9].Value = " PERDIDA ";
                    oHoja.Cells[InicioLinea, 10].Value = " GANANCIA ";
                    oHoja.Cells[InicioLinea, 11].Value = " PERDIDA ";
                    oHoja.Cells[InicioLinea, 12].Value = " GANANCIA ";


                    for (int i = 1; i <= 12; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    //Int32 col = 1;

                    foreach (BalanceComprobacionE item in oListaBalanceComprobacion)
                    {

                        oHoja.Cells[InicioLinea, 1].Value = item.CodCuenta;
                        oHoja.Cells[InicioLinea, 2].Value = item.DesCuenta;
                        oHoja.Cells[InicioLinea, 3].Value = item.MayorDebe;
                        oHoja.Cells[InicioLinea, 4].Value = item.MayorHaber;
                        oHoja.Cells[InicioLinea, 5].Value = item.SaldoActualDebe;
                        oHoja.Cells[InicioLinea, 6].Value = item.SaldoActualHaber;
                        oHoja.Cells[InicioLinea, 7].Value = item.InvenActivo;
                        oHoja.Cells[InicioLinea, 8].Value = item.InvenPasivo;
                        oHoja.Cells[InicioLinea, 9].Value = item.PorFuncionPerdida;
                        oHoja.Cells[InicioLinea, 10].Value = item.PorFuncionGanancia;
                        oHoja.Cells[InicioLinea, 11].Value = item.PorNaturalezaPerdida;
                        oHoja.Cells[InicioLinea, 12].Value = item.PorNaturalezaGanancia;






                        // FORMAT 


                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";


                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;


                    // totales

                    oHoja.Cells[InicioLinea, 2].Value = "PARCIALES";
                    oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    oHoja.Cells[InicioLinea, 3].Value = oListaBalanceComprobacion.Sum(x => x.MayorDebe);
                    oHoja.Cells[InicioLinea, 4].Value = oListaBalanceComprobacion.Sum(x => x.MayorHaber);
                    oHoja.Cells[InicioLinea, 5].Value = oListaBalanceComprobacion.Sum(x => x.SaldoActualDebe);
                    oHoja.Cells[InicioLinea, 6].Value = oListaBalanceComprobacion.Sum(x => x.SaldoActualHaber);
                    oHoja.Cells[InicioLinea, 7].Value = oListaBalanceComprobacion.Sum(x => x.InvenActivo);
                    oHoja.Cells[InicioLinea, 8].Value = oListaBalanceComprobacion.Sum(x => x.InvenPasivo);
                    oHoja.Cells[InicioLinea, 9].Value = oListaBalanceComprobacion.Sum(x => x.PorFuncionPerdida);
                    oHoja.Cells[InicioLinea, 10].Value = oListaBalanceComprobacion.Sum(x => x.PorFuncionGanancia);
                    oHoja.Cells[InicioLinea, 11].Value = oListaBalanceComprobacion.Sum(x => x.PorNaturalezaPerdida);
                    oHoja.Cells[InicioLinea, 12].Value = oListaBalanceComprobacion.Sum(x => x.PorNaturalezaGanancia);

                    oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";


                    InicioLinea++;



                    oHoja.Cells[InicioLinea, 6].Value = "UTILIDAD(PERDIDA)";
                    oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                    decimal A = oListaBalanceComprobacion.Sum(x => x.InvenActivo);
                    decimal B = oListaBalanceComprobacion.Sum(x => x.InvenPasivo);
                    decimal TOTALA = A;
                    decimal TOTALB = B;


                    if (A < B)
                    {
                        oHoja.Cells[InicioLinea, 7].Value = B - A;
                        TOTALA += (B - A);
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 7].Value = 0.00;
                    }





                    if (B < A)
                    {
                        oHoja.Cells[InicioLinea, 8].Value = A - B;
                        TOTALB += (A - B);
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 8].Value = 0.00;
                    }





                    decimal C = oListaBalanceComprobacion.Sum(x => x.PorFuncionPerdida);
                    decimal D = oListaBalanceComprobacion.Sum(x => x.PorFuncionGanancia);
                    decimal TOTALC = C;
                    decimal TOTALD = D;

                    if (C < D)
                    {
                        oHoja.Cells[InicioLinea, 9].Value = D - C;
                        TOTALC += (D - C);
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 9].Value = 0.00;
                    }


                    if (D < C)
                    {
                        oHoja.Cells[InicioLinea, 10].Value = C - D;

                        TOTALC += (C - D);
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 10].Value = 0.00;
                    }



                    decimal E = oListaBalanceComprobacion.Sum(x => x.PorNaturalezaPerdida);
                    decimal F = oListaBalanceComprobacion.Sum(x => x.PorNaturalezaGanancia);
                    decimal TOTALE = E;
                    decimal TOTALF = F;

                    if (E < F)
                    {
                        oHoja.Cells[InicioLinea, 11].Value = F - E;
                        TOTALE += (F - E);
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 11].Value = 0.00;
                    }



                    if (F < E)
                    {
                        oHoja.Cells[InicioLinea, 12].Value = E - F;

                        TOTALF += (E - F);
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 12].Value = 0.00;
                    }

                    oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                    InicioLinea++;





                    oHoja.Cells[InicioLinea, 6].Value = "TOTALEMPRESA";
                    oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;





                    oHoja.Cells[InicioLinea, 7].Value = TOTALA;

                    oHoja.Cells[InicioLinea, 8].Value = TOTALB;



                    oHoja.Cells[InicioLinea, 9].Value = TOTALC;

                    oHoja.Cells[InicioLinea, 10].Value = TOTALD;



                    oHoja.Cells[InicioLinea, 11].Value = TOTALE;

                    oHoja.Cells[InicioLinea, 12].Value = TOTALF;

                    oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

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
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteBalanceComprobacion_Load(object sender, EventArgs e)
        {
            //cboAño.SelectedValue = Convert.ToInt32(Anio);
            cboAño.SelectedValue = VariablesLocales.PeriodoContable.AnioPeriodo;
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
        }

        private void frmReporteBalanceComprobacion_FormClosing(object sender, FormClosingEventArgs e)
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

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        #endregion

    }
}

#region Inicio Pdf

class PaginaInicioBalance : PdfPageEventHelper
{
    //public DateTime Per { get; set; }
    public String Mon { get; set; }
    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreMes { get; set; }
    public String Formato { get; set; }
    public String NombreFormato { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

        if (Formato == "M")
        {
            NombreFormato = "MENSUAL";
        }
        else
        {
            NombreFormato = "ACUMULADO";
        }

        NombreMes = FechasHelper.NombreMes(Mes).ToUpper();
        TituloGeneral = "BALANCE DE COMPROBACION " + NombreFormato.ToUpper() + " AL AÑO " + Anio.ToUpper() + " DEL MES " + NombreMes.ToUpper();

        if (Mon == Variables.Soles)
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

        PdfPTable TablaCabDetalle = new PdfPTable(12);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.3f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f });

        #region Primera Linea

        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);


        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Sumas del Mayor ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("S a l d o s", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("I n v e n t a r i o", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Resultado Por Funcion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Resultado por Naturaleza", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);





        TablaCabDetalle.CompleteRow();

        #endregion

        #region Segunda Linea

        cell = new PdfPCell(new Paragraph("CUENTA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("DETALLE", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("D e b e", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("H a b e r", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Deudor", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Acreedor", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Activo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Pasivo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Perdida", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Ganancia", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Perdida", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Ganancia", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);




        TablaCabDetalle.CompleteRow();

        #endregion

        #region Tercera Linea

        //cell = new PdfPCell(new Paragraph("DEL", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("AL", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("TIPO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("NUMERO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //TablaCabDetalle.AddCell(cell);

        //TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}

#endregion