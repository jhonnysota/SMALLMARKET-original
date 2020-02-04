using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm;
using ClienteWinForm.Busquedas;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

#region Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteLibroMayor : FrmMantenimientoBase
    {

        public frmReporteLibroMayor()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        List<RegistroDiarioE> oListaRegistroDeDiario = null;
        //List<RegistroDiarioE> listRegistroDiario = null;
        String Formato2 = "N";
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        Int32 letra = 0;
        int tipoProceso = 0; // 1 buscar; 0 exportar;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataTable oDt2 = FechasHelper.CargarMesesContable("MA");

            cboPeriodoIni.DataSource = oDt;
            cboPeriodoIni.ValueMember = "MesId";
            cboPeriodoIni.DisplayMember = "MesDes";
            cboPeriodoIni.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            cboPeriodoFin.DataSource = oDt2;
            cboPeriodoFin.ValueMember = "MesId";
            cboPeriodoFin.DisplayMember = "MesDes";
            cboPeriodoFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, listaLocales, "idLocal", "Nombre", false);

            if (listaLocales.Count == 2)
            {
                cboSucursales.SelectedValue = 1;
            }

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

        }

        void ListaReporte()
        {
            try
            {
                String fecInicial = cboPeriodoIni.SelectedValue.ToString();
                String fecFin = cboPeriodoFin.SelectedValue.ToString();
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                String codCuentaIni = txtCuentaIni.Text;
                String codCuentaFin = txtCuentaFin.Text;
                String anio = Convert.ToString(cboAño.SelectedValue);

                Int32 cantReg = AgenteContabilidad.Proxy.CantidadRegistroMayor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, anio, fecInicial, fecFin, codCuentaIni, codCuentaFin);

                if (cantReg > 0)
                {
                    Int32 Factor = 1000;
                    Decimal Paginas = cantReg / Factor;
                    Int32 totPaginas = Convert.ToInt32(Paginas);
                    Int32 registros = 0;

                    oListaRegistroDeDiario = new List<RegistroDiarioE>();
                    //lblRegistros.Text = String.Format("Cantidad de Registros: {0}", cantReg.ToString());

                    for (int i = 0; i <= totPaginas; i++)
                    {
                        List<RegistroDiarioE> LibroTmp = AgenteContabilidad.Proxy.ObtenerLibroMayor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, anio, fecInicial, fecFin, codCuentaIni, codCuentaFin, i, Factor); //ObtenerMayor(idEmpresa, idLocal, numVerPlanCuenta, anioPeriodo, fecIni, fecFin, codCuentaIni, codCuentaFin, i, 1000);

                        if (LibroTmp != null && LibroTmp.Count > 0)
                        {
                            registros += LibroTmp.Count;
                            lblProceso.Text = String.Format("Obteniendo {0} registros de {1}", registros.ToString(), cantReg.ToString());
                            lblProceso.Refresh();
                            oListaRegistroDeDiario.AddRange(LibroTmp);
                         
                        }
                    }

                    Decimal TotalDebe = oListaRegistroDeDiario.Where(x => x.indDebeHaber == "D").Sum(x => x.impSoles);
                    Decimal TotalHaber = oListaRegistroDeDiario.Where(x => x.indDebeHaber == "H").Sum(x => x.impSoles);

                    lblDebe.Text = TotalDebe.ToString("N2");
                    lblHaber.Text = TotalHaber.ToString("N2");

                    Decimal Tot = oListaRegistroDeDiario.Count();

                    //Obteniendo los datos de la BD
                    //oListaRegistroDeDiario = AgenteContabilidad.Proxy.ObtenerLibroMayor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, VariablesLocales.PeriodoContable.AnioPeriodo, fecInicial, fecFin, codCuentaIni, codCuentaFin, cantReg);
                }
                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20476115711") //
            {
                docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            }
            else
            {
                docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            }

            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Libro Mayor " + FechasHelper.NombreMes(Convert.ToInt32(cboPeriodoIni.SelectedValue.ToString())) + Aleatorio.ToString();
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

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 0.85f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    oPdfw.PageEvent = new PaginaInicialLibroMayor
                    {
                        Periodo = cboPeriodoIni.SelectedValue.ToString(),
                        PeriodoFin = cboPeriodoFin.SelectedValue.ToString()
                    };

                    docPdf.Open();

                    #region Variables
                    int cntRegistro = oListaRegistroDeDiario.Count - 1;
                    int i = -1;
                    int x = 0;

                    Decimal mtoDebeAper_S = 0;
                    Decimal mtoHabeAper_S = 0;

                    Decimal mtoDebeAper_D = 0;
                    Decimal mtoHabeAper_D = 0;

                    Decimal mtoDebeAper_S1 = 0;
                    Decimal mtoHabeAper_S1 = 0;
                    Decimal mtoDebeAper_D1 = 0;
                    Decimal mtoHabeAper_D1 = 0;

                    Decimal mtoDebeAper_S2 = 0;
                    Decimal mtoHabeAper_S2 = 0;
                    Decimal mtoDebeAper_D2 = 0;
                    Decimal mtoHabeAper_D2 = 0;

                    Decimal mtoDebeAper_S3 = 0;
                    Decimal mtoHabeAper_S3 = 0;
                    Decimal mtoDebeAper_D3 = 0;
                    Decimal mtoHabeAper_D3 = 0;

                    Decimal mtoDebeAper_S_Prov = 0;
                    Decimal mtoHabeAper_S_Prov = 0;
                    Decimal mtoDebeAper_D_Prov = 0;
                    Decimal mtoHabeAper_D_Prov = 0;

                    Decimal AntmtoDebeAper_S = 0;
                    Decimal AntmtoHabeAper_S = 0;
                    Decimal AntmtoDebeAper_D = 0;
                    Decimal AntmtoHabeAper_D = 0;

                    Decimal AntmtoDebeAper_S1 = 0;
                    Decimal AntmtoHabeAper_S1 = 0;
                    Decimal AntmtoDebeAper_D1 = 0;
                    Decimal AntmtoHabeAper_D1 = 0;

                    Decimal AntmtoDebeAper_S2 = 0;
                    Decimal AntmtoHabeAper_S2 = 0;
                    Decimal AntmtoDebeAper_D2 = 0;
                    Decimal AntmtoHabeAper_D2 = 0;

                    Decimal AntmtoDebeAper_S3 = 0;
                    Decimal AntmtoHabeAper_S3 = 0;
                    Decimal AntmtoDebeAper_D3 = 0;
                    Decimal AntmtoHabeAper_D3 = 0;

                    Decimal totDebe_S = 0;
                    Decimal totHaber_S = 0;
                    Decimal totDebe_D = 0;
                    Decimal totHaber_D = 0;

                    Decimal totSubCtaDebe = 0;
                    Decimal totSubCtaHaber = 0;

                    String RUC = "";
                    String codCuenta = "";
                    String desCuenta = "";

                    String Nivel1 = "";
                    String cDesCta1 = "";

                    String Nivel2 = "";
                    String cDesCta2 = "";

                    String Nivel3 = "";
                    String cDesCta3 = "";
                    float[] WidthColumna = new float[] { 0.12f, 0.2f, 0.05f, 0.15f, 0.1f, 0.4f, 0.13f, 0.13f, 0.13f, 0.13f };

                    #endregion

                    PdfPTable TablaCabDetalle = new PdfPTable(10)
                    {
                        WidthPercentage = 100
                    };

                    TablaCabDetalle.SetWidths(WidthColumna);

                    if (chbProveedor.Checked)
                    {
                        oListaRegistroDeDiario = (from xx in oListaRegistroDeDiario
                                                  orderby xx.codCuenta, xx.RazonSocial, xx.idDocumento, xx.serDocumento, xx.numDocumento, xx.MesPeriodo
                                                  select xx).ToList();
                    }

                    panel3.SuspendLayout();

                    Decimal TotalDebeSoles = 0;
                    Decimal TotalHaberSoles = 0;
                    Decimal TotalDebeDolar = 0;
                    Decimal TotalHaberDolar = 0;

                    foreach (RegistroDiarioE item in oListaRegistroDeDiario)
                    {
                        if (item.idComprobante.Trim().Length > 0 && item.idLocal != 0)
                        {
                            i++;
                            x = i - 1;

                            if (i == 0)
                            {
                                if (chbVerNiveles.Checked)
                                {
                                    // CUENTA SUPERIOR 1
                                    cell = new PdfPCell(new Paragraph(item.Nivel1, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(item.cDesCta1, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    cell.Colspan = 9;
                                    TablaCabDetalle.AddCell(cell);

                                    Nivel1 = item.Nivel1;
                                    cDesCta1 = item.cDesCta1;

                                    TablaCabDetalle.CompleteRow();

                                    // CUENTA SUPERIOR 2
                                    cell = new PdfPCell(new Paragraph(item.Nivel2, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(item.cDesCta2, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    cell.Colspan = 9;
                                    TablaCabDetalle.AddCell(cell);

                                    Nivel2 = item.Nivel2;
                                    cDesCta2 = item.cDesCta2;

                                    TablaCabDetalle.CompleteRow();

                                    // CUENTA SUPERIOR 3
                                    cell = new PdfPCell(new Paragraph(item.Nivel3, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(item.cDesCta3, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    cell.Colspan = 9;
                                    TablaCabDetalle.AddCell(cell);

                                    Nivel3 = item.Nivel3;
                                    cDesCta3 = item.cDesCta3;

                                    TablaCabDetalle.CompleteRow();
                                }

                                // CUENTA
                                cell = new PdfPCell(new Paragraph(item.codCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.desCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                cell.Colspan = 9;
                                TablaCabDetalle.AddCell(cell);

                                codCuenta = item.codCuenta;
                                desCuenta = item.desCuenta;

                                TablaCabDetalle.CompleteRow();
                            }
                            else
                            {
                                if (chbVerNiveles.Checked)
                                {
                                    if (Nivel1 != item.Nivel1)
                                    {
                                        #region Total Cuenta

                                        // TOTAL CUENTA
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(codCuenta + " " + desCuenta + " - Movimientos Cuenta: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ACTUAL CUENTA
                                        totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                                        totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                                        Decimal a = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                                        Decimal b = (totDebe_S - totHaber_S < 0 ? Math.Abs(totDebe_S - totHaber_S) : 0);

                                        totSubCtaDebe += a;
                                        totSubCtaHaber += b;

                                        totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                                        totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                                        Decimal c = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                                        Decimal d = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(b.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(d.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S = item.antSolesDebe;
                                        AntmtoHabeAper_S = item.antSolesHaber;

                                        AntmtoDebeAper_D = item.antDolarDebe;
                                        AntmtoHabeAper_D = item.antDolarHaber;

                                        mtoDebeAper_S = 0;
                                        mtoHabeAper_S = 0;
                                        mtoDebeAper_D = 0;
                                        mtoHabeAper_D = 0;

                                        #endregion

                                        #region Total Cuenta 3

                                        // TOTAL CUENTA 3
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };

                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(Nivel3 + " " + cDesCta3 + " - Movimientos :", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta 2
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior :", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ACTUAL CUENTA 2
                                        Decimal totDebe_S3 = mtoDebeAper_S3 + AntmtoDebeAper_S3;
                                        Decimal totHaber_S3 = mtoHabeAper_S3 + AntmtoHabeAper_S3;

                                        Decimal a3 = (totDebe_S3 - totHaber_S3 > 0 ? totDebe_S3 - totHaber_S3 : 0);
                                        Decimal b3 = (totDebe_S3 - totHaber_S3 < 0 ? Math.Abs(totDebe_S3 - totHaber_S3) : 0);

                                        Decimal totDebe_D3 = mtoDebeAper_D3 + AntmtoDebeAper_D3;
                                        Decimal totHaber_D3 = mtoHabeAper_D3 + AntmtoHabeAper_D3;

                                        Decimal c3 = (totDebe_D3 - totHaber_D3 > 0 ? totDebe_D3 - totHaber_D3 : 0);
                                        Decimal d3 = (0 > totDebe_D3 - totHaber_D3 ? Math.Abs(totDebe_D3 - totHaber_D3) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(b3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(d3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S3 = item.antSolesDebe3;
                                        AntmtoHabeAper_S3 = item.antSolesHaber3;

                                        AntmtoDebeAper_D3 = item.antDolarDebe3;
                                        AntmtoHabeAper_D3 = item.antDolarHaber3;

                                        mtoDebeAper_S3 = 0;
                                        mtoHabeAper_S3 = 0;
                                        mtoDebeAper_D3 = 0;
                                        mtoHabeAper_D3 = 0;

                                        #endregion

                                        #region Total Cuenta 2

                                        // TOTAL CUENTA 2
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(Nivel2 + " " + cDesCta2 + " - Movimientos :", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta 2
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior :", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ACTUAL CUENTA 2
                                        Decimal totDebe_S2 = mtoDebeAper_S2 + AntmtoDebeAper_S2;
                                        Decimal totHaber_S2 = mtoHabeAper_S2 + AntmtoHabeAper_S2;

                                        Decimal a2 = (totDebe_S2 - totHaber_S2 > 0 ? totDebe_S2 - totHaber_S2 : 0);
                                        Decimal b2 = (totDebe_S2 - totHaber_S2 < 0 ? Math.Abs(totDebe_S2 - totHaber_S2) : 0);

                                        Decimal totDebe_D2 = mtoDebeAper_D2 + AntmtoDebeAper_D2;
                                        Decimal totHaber_D2 = mtoHabeAper_D2 + AntmtoHabeAper_D2;

                                        Decimal c2 = (totDebe_D2 - totHaber_D2 > 0 ? totDebe_D2 - totHaber_D2 : 0);
                                        Decimal d2 = (0 > totDebe_D2 - totHaber_D2 ? Math.Abs(totDebe_D2 - totHaber_D2) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(b2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(d2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S2 = item.antSolesDebe2;
                                        AntmtoHabeAper_S2 = item.antSolesHaber2;

                                        AntmtoDebeAper_D2 = item.antDolarDebe2;
                                        AntmtoHabeAper_D2 = item.antDolarHaber2;

                                        mtoDebeAper_S = 0;
                                        mtoHabeAper_S = 0;
                                        mtoDebeAper_D = 0;
                                        mtoHabeAper_D = 0;

                                        mtoDebeAper_S2 = 0;
                                        mtoHabeAper_S2 = 0;
                                        mtoDebeAper_D2 = 0;
                                        mtoHabeAper_D2 = 0;

                                        #endregion

                                        #region Total Cuenta 1

                                        // TOTAL CUENTA 1
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(Nivel1 + " " + cDesCta1 + " - Movimientos :", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta 1
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S1).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S1).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D1).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D1).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ACTUAL CUENTA 1
                                        Decimal totDebe_S1 = mtoDebeAper_S1 + AntmtoDebeAper_S1;
                                        Decimal totHaber_S1 = mtoHabeAper_S1 + AntmtoHabeAper_S1;

                                        Decimal a1 = (totDebe_S1 - totHaber_S1 > 0 ? totDebe_S1 - totHaber_S1 : 0);
                                        Decimal b1 = (totDebe_S1 - totHaber_S1 < 0 ? Math.Abs(totDebe_S1 - totHaber_S1) : 0);

                                        Decimal totDebe_D1 = mtoDebeAper_D1 + AntmtoDebeAper_D1;
                                        Decimal totHaber_D1 = mtoHabeAper_D1 + AntmtoHabeAper_D1;

                                        Decimal c1 = (totDebe_D1 - totHaber_D1 > 0 ? totDebe_D1 - totHaber_D1 : 0);
                                        Decimal d1 = (0 > totDebe_D1 - totHaber_D1 ? Math.Abs(totDebe_D1 - totHaber_D1) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual :", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(b1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(d1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        mtoDebeAper_S = 0;
                                        mtoHabeAper_S = 0;
                                        mtoDebeAper_D = 0;
                                        mtoHabeAper_D = 0;

                                        mtoDebeAper_S2 = 0;
                                        mtoHabeAper_S2 = 0;
                                        mtoDebeAper_D2 = 0;
                                        mtoHabeAper_D2 = 0;

                                        mtoDebeAper_S1 = 0;
                                        mtoHabeAper_S1 = 0;
                                        mtoDebeAper_D1 = 0;
                                        mtoHabeAper_D1 = 0;

                                        #endregion

                                        // CUENTA SUPERIOR 1
                                        cell = new PdfPCell(new Paragraph(item.Nivel1, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.cDesCta1, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        Nivel1 = item.Nivel1;
                                        cDesCta1 = item.cDesCta1;

                                        TablaCabDetalle.CompleteRow();

                                        // CUENTA SUPERIOR 2
                                        cell = new PdfPCell(new Paragraph(item.Nivel2, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.cDesCta2, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        Nivel2 = item.Nivel2;
                                        cDesCta2 = item.cDesCta2;

                                        TablaCabDetalle.CompleteRow();

                                        // CUENTA SUPERIOR 3
                                        cell = new PdfPCell(new Paragraph(item.Nivel3, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.cDesCta3, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        Nivel3 = item.Nivel3;
                                        cDesCta3 = item.cDesCta3;

                                        TablaCabDetalle.CompleteRow();

                                        // CUENTA
                                        cell = new PdfPCell(new Paragraph(item.codCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.desCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        codCuenta = item.codCuenta;
                                        desCuenta = item.desCuenta;

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S = item.antSolesDebe;
                                        AntmtoHabeAper_S = item.antSolesHaber;
                                        AntmtoDebeAper_D = item.antDolarDebe;
                                        AntmtoHabeAper_D = item.antDolarHaber;
                                    }

                                    if (Nivel2 != item.Nivel2)
                                    {
                                        #region Total Cuenta

                                        // TOTAL CUENTA
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(codCuenta + " " + desCuenta + " - Movimientos Cuenta: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                                        totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                                        Decimal a = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                                        Decimal b = (totDebe_S - totHaber_S < 0 ? Math.Abs(totDebe_S - totHaber_S) : 0);

                                        totSubCtaDebe += a;
                                        totSubCtaHaber += b;

                                        totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                                        totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                                        Decimal c = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                                        Decimal d = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(b.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(d.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S = item.antSolesDebe;
                                        AntmtoHabeAper_S = item.antSolesHaber;

                                        AntmtoDebeAper_D = item.antDolarDebe;
                                        AntmtoHabeAper_D = item.antDolarHaber;

                                        #endregion

                                        #region Total Cuenta 3

                                        // TOTAL CUENTA 3
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };

                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(Nivel3 + " " + cDesCta3 + " - Movimientos: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta 2
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ACTUAL CUENTA 2
                                        Decimal totDebe_S3 = mtoDebeAper_S3 + AntmtoDebeAper_S3;
                                        Decimal totHaber_S3 = mtoHabeAper_S3 + AntmtoHabeAper_S3;

                                        Decimal a3 = (totDebe_S3 - totHaber_S3 > 0 ? totDebe_S3 - totHaber_S3 : 0);
                                        Decimal b3 = (totDebe_S3 - totHaber_S3 < 0 ? Math.Abs(totDebe_S3 - totHaber_S3) : 0);

                                        Decimal totDebe_D3 = mtoDebeAper_D3 + AntmtoDebeAper_D3;
                                        Decimal totHaber_D3 = mtoHabeAper_D3 + AntmtoHabeAper_D3;

                                        Decimal c3 = (totDebe_D3 - totHaber_D3 > 0 ? totDebe_D3 - totHaber_D3 : 0);
                                        Decimal d3 = (0 > totDebe_D3 - totHaber_D3 ? Math.Abs(totDebe_D3 - totHaber_D3) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual:", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(b3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(d3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S3 = item.antSolesDebe3;
                                        AntmtoHabeAper_S3 = item.antSolesHaber3;
                                        AntmtoDebeAper_D3 = item.antDolarDebe3;
                                        AntmtoHabeAper_D3 = item.antDolarHaber3;

                                        mtoDebeAper_S3 = 0;
                                        mtoHabeAper_S3 = 0;
                                        mtoDebeAper_D3 = 0;
                                        mtoHabeAper_D3 = 0;

                                        #endregion

                                        #region Total Cuenta 2

                                        // TOTAL CUENTA 2
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };

                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(Nivel2 + " " + cDesCta2 + " - Movimientos: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta 2
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ACTUAL CUENTA 2
                                        Decimal totDebe_S2 = mtoDebeAper_S2 + AntmtoDebeAper_S2;
                                        Decimal totHaber_S2 = mtoHabeAper_S2 + AntmtoHabeAper_S2;

                                        Decimal a2 = (totDebe_S2 - totHaber_S2 > 0 ? totDebe_S2 - totHaber_S2 : 0);
                                        Decimal b2 = (totDebe_S2 - totHaber_S2 < 0 ? Math.Abs(totDebe_S2 - totHaber_S2) : 0);

                                        Decimal totDebe_D2 = mtoDebeAper_D2 + AntmtoDebeAper_D2;
                                        Decimal totHaber_D2 = mtoHabeAper_D2 + AntmtoHabeAper_D2;

                                        Decimal c2 = (totDebe_D2 - totHaber_D2 > 0 ? totDebe_D2 - totHaber_D2 : 0);
                                        Decimal d2 = (0 > totDebe_D2 - totHaber_D2 ? Math.Abs(totDebe_D2 - totHaber_D2) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(b2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(d2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S2 = item.antSolesDebe2;
                                        AntmtoHabeAper_S2 = item.antSolesHaber2;
                                        AntmtoDebeAper_D2 = item.antDolarDebe2;
                                        AntmtoHabeAper_D2 = item.antDolarHaber2;

                                        #endregion

                                        // CUENTA SUPERIOR 2
                                        cell = new PdfPCell(new Paragraph(item.Nivel2, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.cDesCta2, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        Nivel2 = item.Nivel2;
                                        cDesCta2 = item.cDesCta2;

                                        TablaCabDetalle.CompleteRow();

                                        // CUENTA SUPERIOR 3
                                        cell = new PdfPCell(new Paragraph(item.Nivel3, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.cDesCta3, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        Nivel3 = item.Nivel3;
                                        cDesCta3 = item.cDesCta3;

                                        TablaCabDetalle.CompleteRow();

                                        // CUENTA
                                        cell = new PdfPCell(new Paragraph(item.codCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.desCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        codCuenta = item.codCuenta;
                                        desCuenta = item.desCuenta;

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S = item.antSolesDebe;
                                        AntmtoHabeAper_S = item.antSolesHaber;
                                        AntmtoDebeAper_D = item.antDolarDebe;
                                        AntmtoHabeAper_D = item.antDolarHaber;

                                        mtoDebeAper_S = 0;
                                        mtoHabeAper_S = 0;
                                        mtoDebeAper_D = 0;
                                        mtoHabeAper_D = 0;

                                        mtoDebeAper_S2 = 0;
                                        mtoHabeAper_S2 = 0;
                                        mtoDebeAper_D2 = 0;
                                        mtoHabeAper_D2 = 0;
                                    }

                                    if (Nivel3 != item.Nivel3)
                                    {
                                        #region Total Cuenta

                                        // TOTAL CUENTA
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(codCuenta + " " + desCuenta + " - Movimientos Cuenta: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);
                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ACTUAL CUENTA
                                        totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                                        totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                                        Decimal a = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                                        Decimal b = (totDebe_S - totHaber_S < 0 ? Math.Abs(totDebe_S - totHaber_S) : 0);

                                        totSubCtaDebe += a;
                                        totSubCtaHaber += b;

                                        totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                                        totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                                        Decimal c = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                                        Decimal d = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(b.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(d.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S = item.antSolesDebe;
                                        AntmtoHabeAper_S = item.antSolesHaber;
                                        AntmtoDebeAper_D = item.antDolarDebe;
                                        AntmtoHabeAper_D = item.antDolarHaber;

                                        #endregion

                                        #region Total Cuenta 3

                                        // TOTAL CUENTA 3
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 10;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(Nivel3 + " " + cDesCta3 + " - Movimientos: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        cell.Colspan = 4;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ANTERIOR Cuenta 2
                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        // TOTAL SALDO ACTUAL CUENTA 2
                                        Decimal totDebe_S3 = mtoDebeAper_S3 + AntmtoDebeAper_S3;
                                        Decimal totHaber_S3 = mtoHabeAper_S3 + AntmtoHabeAper_S3;

                                        Decimal a3 = (totDebe_S3 - totHaber_S3 > 0 ? totDebe_S3 - totHaber_S3 : 0);
                                        Decimal b3 = (totDebe_S3 - totHaber_S3 < 0 ? Math.Abs(totDebe_S3 - totHaber_S3) : 0);

                                        Decimal totDebe_D3 = mtoDebeAper_D3 + AntmtoDebeAper_D3;
                                        Decimal totHaber_D3 = mtoHabeAper_D3 + AntmtoHabeAper_D3;

                                        Decimal c3 = (totDebe_D3 - totHaber_D3 > 0 ? totDebe_D3 - totHaber_D3 : 0);
                                        Decimal d3 = (0 > totDebe_D3 - totHaber_D3 ? Math.Abs(totDebe_D3 - totHaber_D3) : 0);

                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(a3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(b3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(c3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(d3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        AntmtoDebeAper_S3 = item.antSolesDebe3;
                                        AntmtoHabeAper_S3 = item.antSolesHaber3;
                                        AntmtoDebeAper_D3 = item.antDolarDebe3;
                                        AntmtoHabeAper_D3 = item.antDolarHaber3;

                                        #endregion

                                        // CUENTA SUPERIOR 3
                                        cell = new PdfPCell(new Paragraph(item.Nivel3, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.cDesCta3, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        Nivel3 = item.Nivel3;
                                        cDesCta3 = item.cDesCta3;

                                        TablaCabDetalle.CompleteRow();

                                        // CUENTA
                                        cell = new PdfPCell(new Paragraph(item.codCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.desCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        codCuenta = item.codCuenta;
                                        desCuenta = item.desCuenta;

                                        TablaCabDetalle.CompleteRow();

                                        mtoDebeAper_S = 0;
                                        mtoHabeAper_S = 0;
                                        mtoDebeAper_D = 0;
                                        mtoHabeAper_D = 0;

                                        AntmtoDebeAper_S = 0;
                                        AntmtoHabeAper_S = 0;
                                        AntmtoDebeAper_D = 0;
                                        AntmtoHabeAper_D = 0;

                                        mtoDebeAper_S3 = 0;
                                        mtoHabeAper_S3 = 0;
                                        mtoDebeAper_D3 = 0;
                                        mtoHabeAper_D3 = 0;
                                    }
                                }

                                if (codCuenta != item.codCuenta)
                                {
                                    #region Total Cuenta

                                    // TOTAL CUENTA
                                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    cell.Colspan = 10;
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(codCuenta + " " + desCuenta + " - Movimientos Cuenta: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                    cell.Colspan = 4;
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(mtoDebeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(mtoHabeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(mtoDebeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);
                                    cell = new PdfPCell(new Paragraph(mtoHabeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    // TOTAL SALDO ANTERIOR Cuenta
                                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    cell.Colspan = 5;
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    // TOTAL SALDO ACTUAL CUENTA
                                    totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                                    totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                                    Decimal a = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                                    Decimal b = (totDebe_S - totHaber_S < 0 ? Math.Abs(totDebe_S - totHaber_S) : 0);

                                    totSubCtaDebe += a;
                                    totSubCtaHaber += b;

                                    totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                                    totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                                    Decimal c = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                                    Decimal d = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    cell.Colspan = 5;
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(a.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(b.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(c.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(d.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    AntmtoDebeAper_S = item.antSolesDebe;
                                    AntmtoHabeAper_S = item.antSolesHaber;
                                    AntmtoDebeAper_D = item.antDolarDebe;
                                    AntmtoHabeAper_D = item.antDolarHaber;

                                    #endregion

                                    // CUENTA
                                    cell = new PdfPCell(new Paragraph(item.codCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(item.desCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    cell.Colspan = 9;
                                    TablaCabDetalle.AddCell(cell);

                                    codCuenta = item.codCuenta;
                                    desCuenta = item.desCuenta;

                                    TablaCabDetalle.CompleteRow();

                                    AntmtoDebeAper_S = item.antSolesDebe;
                                    AntmtoHabeAper_S = item.antSolesHaber;
                                    AntmtoDebeAper_D = item.antDolarDebe;
                                    AntmtoHabeAper_D = item.antDolarHaber;

                                    mtoDebeAper_S = 0;
                                    mtoHabeAper_S = 0;
                                    mtoDebeAper_D = 0;
                                    mtoHabeAper_D = 0;
                                }
                            }

                            #region PROVEEDORES

                            if (chbProveedor.Checked && item.Ruc.Trim().Length > 0)
                            {
                                if (i == 0)
                                {
                                    RUC = item.Ruc;
                                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                    TablaCabDetalle.AddCell(cell);

                                    cell = new PdfPCell(new Paragraph(item.Ruc + " - " + item.RazonSocial, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                    cell.Colspan = 9;
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();
                                }
                                else
                                {
                                    if (RUC != item.Ruc)
                                    {
                                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Movimientos Proveedor: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S_Prov.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S_Prov.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D_Prov.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D_Prov.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 5;
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph("Saldo: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((mtoDebeAper_S_Prov > mtoHabeAper_S_Prov ? mtoDebeAper_S_Prov - mtoHabeAper_S_Prov : 0).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((mtoHabeAper_S_Prov > mtoDebeAper_S_Prov ? mtoHabeAper_S_Prov - mtoDebeAper_S_Prov : 0).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((mtoDebeAper_D_Prov > mtoHabeAper_D_Prov ? mtoDebeAper_D_Prov - mtoHabeAper_D_Prov : 0).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph((mtoHabeAper_D_Prov > mtoDebeAper_D_Prov ? mtoHabeAper_D_Prov - mtoDebeAper_D_Prov : 0).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();

                                        mtoDebeAper_S_Prov = 0;
                                        mtoHabeAper_S_Prov = 0;

                                        mtoDebeAper_D_Prov = 0;
                                        mtoHabeAper_D_Prov = 0;

                                        RUC = item.Ruc;

                                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                                        TablaCabDetalle.AddCell(cell);

                                        cell = new PdfPCell(new Paragraph(item.Ruc + " - " + item.RazonSocial, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                        cell.Colspan = 9;
                                        TablaCabDetalle.AddCell(cell);

                                        TablaCabDetalle.CompleteRow();
                                    }
                                }
                            }

                            #endregion

                            AntmtoDebeAper_S = item.antSolesDebe;
                            AntmtoHabeAper_S = item.antSolesHaber;
                            AntmtoDebeAper_D = item.antDolarDebe;
                            AntmtoHabeAper_D = item.antDolarHaber;

                            AntmtoDebeAper_S1 = item.antSolesDebe1;
                            AntmtoHabeAper_S1 = item.antSolesHaber1;
                            AntmtoDebeAper_D1 = item.antDolarDebe1;
                            AntmtoHabeAper_D1 = item.antDolarHaber1;

                            AntmtoDebeAper_S2 = item.antSolesDebe2;
                            AntmtoHabeAper_S2 = item.antSolesHaber2;
                            AntmtoDebeAper_D2 = item.antDolarDebe2;
                            AntmtoHabeAper_D2 = item.antDolarHaber2;

                            AntmtoDebeAper_S3 = item.antSolesDebe3;
                            AntmtoHabeAper_S3 = item.antSolesHaber3;
                            AntmtoDebeAper_D3 = item.antDolarDebe3;
                            AntmtoHabeAper_D3 = item.antDolarHaber3;

                            if (item.fecOperacion != null)
                            {
                                string fecvou = item.fecOperacion.Value.ToString("dd/MM/yy");
                                cell = new PdfPCell(new Paragraph(fecvou, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            }

                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.idComprobante + "-" + item.numVoucher + "-" + item.numFile + "-" + item.numItem, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.idDocumento, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph((item.serDocumento == "0000" ? "" : item.serDocumento) + "  " + item.numDocumento, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            if (item.fecDocumento != null)
                            {
                                string fecDoc = item.fecDocumento.Value.ToString("dd/MM/yy");
                                cell = new PdfPCell(new Paragraph(fecDoc, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            }

                            TablaCabDetalle.AddCell(cell);

                            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20476115711") //S.C. INGENIERIA SRL
                            {
                                cell = new PdfPCell(new Paragraph(item.GlosaGeneral.Substring(0, (item.GlosaGeneral.Length > 35 ? 35 : item.GlosaGeneral.Length)), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph(Global.DejarSoloUnEspacio(item.GlosaGeneral.Trim()), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            }

                            TablaCabDetalle.AddCell(cell);

                            if (item.indDebeHaber == "D")
                            {
                                cell = new PdfPCell(new Paragraph((item.impSoles).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph((item.impSoles).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            if (item.indDebeHaber == "D")
                            {
                                cell = new PdfPCell(new Paragraph((item.impDolares).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph((item.impDolares).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            String saldodebe = "";
                            String saldohaber = "";

                            if (item.indDebeHaber == "D" && item.idComprobante != "00")
                            {
                                mtoDebeAper_S += item.impSoles;
                                mtoDebeAper_S1 += item.impSoles;
                                mtoDebeAper_S2 += item.impSoles;
                                mtoDebeAper_S3 += item.impSoles;

                                mtoDebeAper_D += item.impDolares;
                                mtoDebeAper_D1 += item.impDolares;
                                mtoDebeAper_D2 += item.impDolares;
                                mtoDebeAper_D3 += item.impDolares;

                                mtoDebeAper_S_Prov += item.impSoles;
                                mtoDebeAper_D_Prov += item.impDolares;

                                saldodebe = (item.impSoles).ToString("N2");
                                saldohaber = "0.00";

                                TotalDebeSoles  += item.impSoles;                            
                                TotalDebeDolar  += item.impDolares;
                            }
                            else
                            {
                                mtoHabeAper_S += item.impSoles;
                                mtoHabeAper_S1 += item.impSoles;
                                mtoHabeAper_S2 += item.impSoles;
                                mtoHabeAper_S3 += item.impSoles;

                                mtoHabeAper_D += item.impDolares;
                                mtoHabeAper_D1 += item.impDolares;
                                mtoHabeAper_D2 += item.impDolares;
                                mtoHabeAper_D3 += item.impDolares;

                                mtoHabeAper_S_Prov += item.impSoles;
                                mtoHabeAper_D_Prov += item.impDolares;

                                saldodebe = "0.00";
                                saldohaber = (item.impSoles).ToString("N2");

                                TotalHaberSoles += item.impSoles;
                                TotalHaberDolar += item.impDolares;
                            }

                            TablaCabDetalle.CompleteRow();
                        }
                    }

                    // TOTAL PROVEEDOR
                    if (chbProveedor.Checked)
                    {
                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Movimientos Proveedor: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S_Prov.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S_Prov.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D_Prov.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D_Prov.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Saldo: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((mtoDebeAper_S_Prov > mtoHabeAper_S_Prov ? mtoDebeAper_S_Prov - mtoHabeAper_S_Prov : 0).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((mtoHabeAper_S_Prov > mtoDebeAper_S_Prov ? mtoHabeAper_S_Prov - mtoDebeAper_S_Prov : 0).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((mtoDebeAper_D_Prov > mtoHabeAper_D_Prov ? mtoDebeAper_D_Prov - mtoHabeAper_D_Prov : 0).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((mtoHabeAper_D_Prov > mtoDebeAper_D_Prov ? mtoHabeAper_D_Prov - mtoDebeAper_D_Prov : 0).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }

                    #region Total Cuenta

                    // TOTAL CUENTA
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    cell.Colspan = 10;
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(codCuenta + " " + desCuenta + " - Movimientos Cuenta: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = 4;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(mtoDebeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(mtoHabeAper_S.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(mtoDebeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(mtoHabeAper_D.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    // SALDO ANTERIOR CUENTA
                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    cell.Colspan = 5;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    // SALDO ACTUAL CUENTA
                    totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                    totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                    Decimal h = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                    Decimal j = (0 > totDebe_S - totHaber_S ? Math.Abs(totDebe_S - totHaber_S) : 0);

                    totSubCtaDebe += h;
                    totSubCtaHaber += j;

                    totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                    totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                    Decimal k = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                    Decimal l = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    cell.Colspan = 5;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(h.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(j.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(k.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(l.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    #endregion

                    if (chbVerNiveles.Checked)
                    {
                        #region Total Cuenta 3

                        // TOTAL CUENTA 3
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 10;
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Nivel3 + " " + cDesCta3 + " - Movimientos: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        cell.Colspan = 4;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // TOTAL SALDO ANTERIOR Cuenta 2
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D3).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // TOTAL SALDO ACTUAL CUENTA 2
                        Decimal totDebe_S3 = mtoDebeAper_S3 + AntmtoDebeAper_S3;
                        Decimal totHaber_S3 = mtoHabeAper_S3 + AntmtoHabeAper_S3;

                        Decimal a3 = (totDebe_S3 - totHaber_S3 > 0 ? totDebe_S3 - totHaber_S3 : 0);
                        Decimal b3 = (totDebe_S3 - totHaber_S3 < 0 ? Math.Abs(totDebe_S3 - totHaber_S3) : 0);

                        Decimal totDebe_D3 = mtoDebeAper_D3 + AntmtoDebeAper_D3;
                        Decimal totHaber_D3 = mtoHabeAper_D3 + AntmtoHabeAper_D3;

                        Decimal c3 = (totDebe_D3 - totHaber_D3 > 0 ? totDebe_D3 - totHaber_D3 : 0);
                        Decimal d3 = (0 > totDebe_D3 - totHaber_D3 ? Math.Abs(totDebe_D3 - totHaber_D3) : 0);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(a3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(b3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(c3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(d3.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        #endregion

                        #region Total Cuenta 2

                        // TOTAL CUENTA 2
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 10;
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Nivel2 + " " + cDesCta2 + " - Movimientos: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        cell.Colspan = 4;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // TOTAL SALDO ANTERIOR Cuenta 2
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D2).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // TOTAL SALDO ACTUAL CUENTA 2
                        Decimal totDebe_S2 = mtoDebeAper_S2 + AntmtoDebeAper_S2;
                        Decimal totHaber_S2 = mtoHabeAper_S2 + AntmtoHabeAper_S2;

                        Decimal a2 = (totDebe_S2 - totHaber_S2 > 0 ? totDebe_S2 - totHaber_S2 : 0);
                        Decimal b2 = (totDebe_S2 - totHaber_S2 < 0 ? Math.Abs(totDebe_S2 - totHaber_S2) : 0);

                        Decimal totDebe_D2 = mtoDebeAper_D2 + AntmtoDebeAper_D2;
                        Decimal totHaber_D2 = mtoHabeAper_D2 + AntmtoHabeAper_D2;

                        Decimal c2 = (totDebe_D2 - totHaber_D2 > 0 ? totDebe_D2 - totHaber_D2 : 0);
                        Decimal d2 = (0 > totDebe_D2 - totHaber_D2 ? Math.Abs(totDebe_D2 - totHaber_D2) : 0);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(a2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(b2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(c2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(d2.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        #endregion

                        #region Total Cuenta 1

                        // TOTAL CUENTA 1
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 10;
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(Nivel1 + " " + cDesCta1 + " - Movimientos: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        cell.Colspan = 4;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoDebeAper_S1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoHabeAper_S1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoDebeAper_D1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(mtoHabeAper_D1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // TOTAL SALDO ANTERIOR Cuenta 1
                        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Saldo Anterior: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_S1).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_S1).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoDebeAper_D1).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph((AntmtoHabeAper_D1).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // TOTAL SALDO ACTUAL CUENTA 1
                        Decimal totDebe_S1 = mtoDebeAper_S1 + AntmtoDebeAper_S1;
                        Decimal totHaber_S1 = mtoHabeAper_S1 + AntmtoHabeAper_S1;

                        Decimal a1 = (totDebe_S1 - totHaber_S1 > 0 ? totDebe_S1 - totHaber_S1 : 0);
                        Decimal b1 = (totDebe_S1 - totHaber_S1 < 0 ? Math.Abs(totDebe_S1 - totHaber_S1) : 0);

                        Decimal totDebe_D1 = mtoDebeAper_D1 + AntmtoDebeAper_D1;
                        Decimal totHaber_D1 = mtoHabeAper_D1 + AntmtoHabeAper_D1;

                        Decimal c1 = (totDebe_D1 - totHaber_D1 > 0 ? totDebe_D1 - totHaber_D1 : 0);
                        Decimal d1 = (0 > totDebe_D1 - totHaber_D1 ? Math.Abs(totDebe_D1 - totHaber_D1) : 0);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("Saldo Actual: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(a1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(b1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(c1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(d1.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        #endregion
                    }


                    #region Total Movimiento

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    cell.Colspan = 10;
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    cell.Colspan = 5;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Total Movimiento: ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(TotalDebeSoles.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(TotalHaberSoles.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(TotalDebeDolar.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(TotalHaberDolar.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    #endregion

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    panel3.ResumeLayout();

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

        void ObtenerDescripcionCuenta(TextBox txtcuenta, TextBox txtdescripcion)
        {
            if (txtcuenta.Text.Trim() != "")
            {
                txtdescripcion.Text = AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtcuenta.Text.ToString());
            }
            else
            {
                txtdescripcion.Text = "";
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Libro Mayor";
            NombrePestaña = "Mayor";

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
                    if (Formato2 == "N")
                    {
                        Int32 InicioLinea = 1;
                        Int32 TotColumnas = 27;

                        #region Cabecera

                        #region Primera Linea Cabecera

                        oHoja.Cells[InicioLinea, 1].Value = "Año";
                        oHoja.Cells[InicioLinea, 2].Value = "Periodo";
                        //oHoja.Cells[InicioLinea, 3].Value = "Mes";
                        oHoja.Cells[InicioLinea, 3].Value = "Libro";
                        oHoja.Cells[InicioLinea, 4].Value = "File";
                        oHoja.Cells[InicioLinea, 5].Value = "Comprobante";
                        oHoja.Cells[InicioLinea, 6].Value = "Item";
                        oHoja.Cells[InicioLinea, 7].Value = "Moneda";
                        oHoja.Cells[InicioLinea, 8].Value = "TC";
                        oHoja.Cells[InicioLinea, 9].Value = "Cuenta";
                        oHoja.Cells[InicioLinea, 10].Value = "RUC";
                        oHoja.Cells[InicioLinea, 11].Value = "RazonSocial";
                        oHoja.Cells[InicioLinea, 12].Value = "TD";
                        oHoja.Cells[InicioLinea, 13].Value = "SERIE";
                        oHoja.Cells[InicioLinea, 14].Value = "Documento";
                        oHoja.Cells[InicioLinea, 15].Value = "Fecha Doc.";
                        oHoja.Cells[InicioLinea, 16].Value = "Fecha";
                        oHoja.Cells[InicioLinea, 17].Value = "Glosa";
                        oHoja.Cells[InicioLinea, 18].Value = "Cuenta Descripcion";
                        oHoja.Cells[InicioLinea, 19].Value = "Debe/Haber";
                        oHoja.Cells[InicioLinea, 20].Value = "Importe Soles";
                        oHoja.Cells[InicioLinea, 21].Value = "Importe Dolares";
                        oHoja.Cells[InicioLinea, 22].Value = "Debe Soles";
                        oHoja.Cells[InicioLinea, 23].Value = "Haber Soles";
                        oHoja.Cells[InicioLinea, 24].Value = "Debe Dolares";
                        oHoja.Cells[InicioLinea, 25].Value = "Haber Dolares";
                        oHoja.Cells[InicioLinea, 26].Value = "Soles";
                        oHoja.Cells[InicioLinea, 27].Value = "Dolares";

                        for (int i = 1; i <= 21; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        for (int i = 22; i <= 25; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(239, 253, 105));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        for (int i = 26; i <= 27; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(104, 254, 154));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        // Auto Filtro
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                        #endregion

                        InicioLinea++;

                        #endregion

                        //Aumentando una Fila mas continuar con el detalle

                        #region Datos

                        int cntRegistro = oListaRegistroDeDiario.Count - 1;

                        foreach (RegistroDiarioE item in oListaRegistroDeDiario)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.AnioPeriodo;
                            oHoja.Cells[InicioLinea, 2].Value = item.MesPeriodo;
                            //oHoja.Cells[InicioLinea, 3].Value = item.desPeriodo;
                            oHoja.Cells[InicioLinea, 3].Value = item.idComprobante;
                            oHoja.Cells[InicioLinea, 4].Value = item.numFile;
                            oHoja.Cells[InicioLinea, 5].Value = item.numVoucher;
                            oHoja.Cells[InicioLinea, 6].Value = item.numItem;
                            oHoja.Cells[InicioLinea, 7].Value = item.desMoneda;
                            oHoja.Cells[InicioLinea, 8].Value = item.tipCambio;
                            oHoja.Cells[InicioLinea, 9].Value = item.codCuenta;
                            oHoja.Cells[InicioLinea, 10].Value = item.Ruc;
                            oHoja.Cells[InicioLinea, 11].Value = item.RazonSocial;

                            oHoja.Cells[InicioLinea, 12].Value = item.idDocumento;
                            oHoja.Cells[InicioLinea, 13].Value = item.serDocumento;
                            oHoja.Cells[InicioLinea, 14].Value = item.numDocumento;
                            oHoja.Cells[InicioLinea, 15].Value = (item.fecDocumento == null ? "" : (item.fecDocumento.Value.Year == 1900 ? "" : Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy")));
                            oHoja.Cells[InicioLinea, 16].Value = item.Fecha;
                            oHoja.Cells[InicioLinea, 17].Value = Global.DejarSoloUnEspacio(item.GlosaGeneral.Trim());
                            oHoja.Cells[InicioLinea, 18].Value = item.desCuenta;
                            oHoja.Cells[InicioLinea, 19].Value = item.indDebeHaber;

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 19])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 20].Value = item.impSoles;
                            oHoja.Cells[InicioLinea, 21].Value = item.impDolares;

                            if (item.indDebeHaber == "D")
                            {
                                oHoja.Cells[InicioLinea, 22].Value = item.impSoles;
                                oHoja.Cells[InicioLinea, 23].Value = 0;
                                oHoja.Cells[InicioLinea, 24].Value = item.impDolares;
                                oHoja.Cells[InicioLinea, 25].Value = 0;
                                oHoja.Cells[InicioLinea, 26].Value = item.impSoles;
                                oHoja.Cells[InicioLinea, 27].Value = item.impDolares;
                            }
                            if (item.indDebeHaber == "H")
                            {
                                oHoja.Cells[InicioLinea, 22].Value = 0;
                                oHoja.Cells[InicioLinea, 23].Value = item.impSoles;
                                oHoja.Cells[InicioLinea, 24].Value = 0;
                                oHoja.Cells[InicioLinea, 25].Value = item.impDolares;
                                oHoja.Cells[InicioLinea, 26].Value = 0 - item.impSoles;
                                oHoja.Cells[InicioLinea, 27].Value = 0 - item.impDolares;
                            }

                            oHoja.Cells[InicioLinea, 20, InicioLinea, 27].Style.Numberformat.Format = "###,###,##0.00";
                            InicioLinea++;
                        }

                        #endregion

                        //Linea
                        Int32 totFilas = InicioLinea;
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                        //Suma
                        InicioLinea++;
                    }

                    if (Formato2 == "S")
                    {
                        Int32 InicioLinea = 1;
                        Int32 TotColumnas = 10;

                        #region seg Cabecera

                        #region Primera Linea Cabecera

                        oHoja.Cells[InicioLinea, 1].Value = "FECHA OPERACIÓN";
                        oHoja.Column(1).Width = 17;
                        oHoja.Cells[InicioLinea, 2].Value = "NUMERO CORRELATIVO";
                        oHoja.Column(2).Width = 25;
                        oHoja.Cells[InicioLinea, 3].Value = "TD";
                        oHoja.Column(3).Width = 5;
                        oHoja.Cells[InicioLinea, 4].Value = "NUMERO DOCUMENTO";
                        oHoja.Column(4).Width = 22;
                        oHoja.Cells[InicioLinea, 5].Value = "FECHA";
                        oHoja.Column(5).Width = 9;
                        oHoja.Cells[InicioLinea, 6].Value = "GLOSA";
                        oHoja.Column(6).Width = 60;
                        oHoja.Cells[InicioLinea, 7].Value = "Movimiento Soles";
                        oHoja.Column(7).Width = 12;
                        oHoja.Column(8).Width = 12;

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea, 8])
                        {
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 9].Value = "Movimiento Dolares";
                        oHoja.Column(9).Width = 12;
                        oHoja.Column(10).Width = 12;

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, InicioLinea, 10])
                        {
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        for (int i = 1; i <= 10; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 7].Value = "DEBE";
                        oHoja.Cells[InicioLinea, 8].Value = "HABER";
                        oHoja.Cells[InicioLinea, 9].Value = "DEBE";
                        oHoja.Cells[InicioLinea, 10].Value = "HABER";

                        for (int i = 1; i <= 10; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        // Auto Filtro
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                        #endregion

                        InicioLinea++;

                        #endregion

                        #region Datos

                        #region Variables

                        int ia = -1;
                        int x = 0;

                        Decimal mtoDebeAper_S = 0;
                        Decimal mtoHabeAper_S = 0;

                        Decimal mtoDebeAper_D = 0;
                        Decimal mtoHabeAper_D = 0;

                        Decimal mtoDebeAper_S1 = 0;
                        Decimal mtoHabeAper_S1 = 0;
                        Decimal mtoDebeAper_D1 = 0;
                        Decimal mtoHabeAper_D1 = 0;

                        Decimal mtoDebeAper_S2 = 0;
                        Decimal mtoHabeAper_S2 = 0;
                        Decimal mtoDebeAper_D2 = 0;
                        Decimal mtoHabeAper_D2 = 0;

                        Decimal mtoDebeAper_S3 = 0;
                        Decimal mtoHabeAper_S3 = 0;
                        Decimal mtoDebeAper_D3 = 0;
                        Decimal mtoHabeAper_D3 = 0;

                        Decimal mtoDebeAper_S_Prov = 0;
                        Decimal mtoHabeAper_S_Prov = 0;
                        Decimal mtoDebeAper_D_Prov = 0;
                        Decimal mtoHabeAper_D_Prov = 0;

                        Decimal AntmtoDebeAper_S = 0;
                        Decimal AntmtoHabeAper_S = 0;
                        Decimal AntmtoDebeAper_D = 0;
                        Decimal AntmtoHabeAper_D = 0;

                        Decimal AntmtoDebeAper_S1 = 0;
                        Decimal AntmtoHabeAper_S1 = 0;
                        Decimal AntmtoDebeAper_D1 = 0;
                        Decimal AntmtoHabeAper_D1 = 0;

                        Decimal AntmtoDebeAper_S2 = 0;
                        Decimal AntmtoHabeAper_S2 = 0;
                        Decimal AntmtoDebeAper_D2 = 0;
                        Decimal AntmtoHabeAper_D2 = 0;

                        Decimal AntmtoDebeAper_S3 = 0;
                        Decimal AntmtoHabeAper_S3 = 0;
                        Decimal AntmtoDebeAper_D3 = 0;
                        Decimal AntmtoHabeAper_D3 = 0;

                        Decimal totDebe_S = 0;
                        Decimal totHaber_S = 0;
                        Decimal totDebe_D = 0;
                        Decimal totHaber_D = 0;

                        Decimal totSubCtaDebe = 0;
                        Decimal totSubCtaHaber = 0;

                        String RUC = "";
                        String codCuenta = "";
                        String desCuenta = "";

                        String Nivel1 = "";
                        String cDesCta1 = "";

                        String Nivel2 = "";
                        String cDesCta2 = "";

                        String Nivel3 = "";
                        String cDesCta3 = ""; 

                        #endregion

                        foreach (RegistroDiarioE item in oListaRegistroDeDiario)
                        {
                            if (item.idComprobante.Trim().Length > 0 && item.idLocal != 0)
                            {
                                ia++;
                                x = ia - 1;

                                if (ia == 0)
                                {
                                    if (chbVerNiveles.Checked)
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = item.Nivel1;
                                        oHoja.Cells[InicioLinea, 2].Value = item.cDesCta1;

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 9])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }

                                        Nivel1 = item.Nivel1;
                                        cDesCta1 = item.cDesCta1;

                                        InicioLinea++;

                                        oHoja.Cells[InicioLinea, 1].Value = item.Nivel2;
                                        oHoja.Cells[InicioLinea, 2].Value = item.cDesCta2;

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 9])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }

                                        Nivel2 = item.Nivel2;
                                        cDesCta2 = item.cDesCta2;

                                        InicioLinea++;

                                        oHoja.Cells[InicioLinea, 1].Value = item.Nivel3;
                                        oHoja.Cells[InicioLinea, 2].Value = item.cDesCta3;

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 9])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }

                                        Nivel3 = item.Nivel3;
                                        cDesCta3 = item.cDesCta3;

                                        InicioLinea++;
                                    }

                                    oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                                    oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;

                                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 9])
                                    {
                                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                    }

                                    codCuenta = item.codCuenta;
                                    desCuenta = item.desCuenta;

                                    InicioLinea++;
                                }
                                else
                                {
                                    if (chbVerNiveles.Checked)
                                    {
                                        if (Nivel1 != item.Nivel1)
                                        {
                                            #region Total Cuenta

                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Anterior: ";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ACTUAL CUENTA
                                            totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                                            totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                                            Decimal a = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                                            Decimal b = (totDebe_S - totHaber_S < 0 ? Math.Abs(totDebe_S - totHaber_S) : 0);

                                            totSubCtaDebe += a;
                                            totSubCtaHaber += b;

                                            totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                                            totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                                            Decimal c = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                                            Decimal d = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Actual: ";
                                            oHoja.Cells[InicioLinea, 7].Value = a;
                                            oHoja.Cells[InicioLinea, 8].Value = b;
                                            oHoja.Cells[InicioLinea, 9].Value = c;
                                            oHoja.Cells[InicioLinea, 10].Value = d;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            AntmtoDebeAper_S = item.antSolesDebe;
                                            AntmtoHabeAper_S = item.antSolesHaber;
                                            AntmtoDebeAper_D = item.antDolarDebe;
                                            AntmtoHabeAper_D = item.antDolarHaber;

                                            mtoDebeAper_S = 0;
                                            mtoHabeAper_S = 0;
                                            mtoDebeAper_D = 0;
                                            mtoHabeAper_D = 0;

                                            #endregion

                                            #region Total Cuenta 3

                                            // TOTAL CUENTA 3
                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = "";
                                            oHoja.Cells[InicioLinea, 2].Value = "";
                                            oHoja.Cells[InicioLinea, 3].Value = Nivel3 + " " + cDesCta3 + " - Movimientos :";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S3;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S3;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D3;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D3;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta 2
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Anterior :";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S3);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S3);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D3);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D3);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ACTUAL CUENTA 2
                                            Decimal totDebe_S3 = mtoDebeAper_S3 + AntmtoDebeAper_S3;
                                            Decimal totHaber_S3 = mtoHabeAper_S3 + AntmtoHabeAper_S3;

                                            Decimal a3 = (totDebe_S3 - totHaber_S3 > 0 ? totDebe_S3 - totHaber_S3 : 0);
                                            Decimal b3 = (totDebe_S3 - totHaber_S3 < 0 ? Math.Abs(totDebe_S3 - totHaber_S3) : 0);

                                            Decimal totDebe_D3 = mtoDebeAper_D3 + AntmtoDebeAper_D3;
                                            Decimal totHaber_D3 = mtoHabeAper_D3 + AntmtoHabeAper_D3;

                                            Decimal c3 = (totDebe_D3 - totHaber_D3 > 0 ? totDebe_D3 - totHaber_D3 : 0);
                                            Decimal d3 = (0 > totDebe_D3 - totHaber_D3 ? Math.Abs(totDebe_D3 - totHaber_D3) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Actual: ";
                                            oHoja.Cells[InicioLinea, 7].Value = a3;
                                            oHoja.Cells[InicioLinea, 8].Value = b3;
                                            oHoja.Cells[InicioLinea, 9].Value = c3;
                                            oHoja.Cells[InicioLinea, 10].Value = d3;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            AntmtoDebeAper_S3 = item.antSolesDebe3;
                                            AntmtoHabeAper_S3 = item.antSolesHaber3;
                                            AntmtoDebeAper_D3 = item.antDolarDebe3;
                                            AntmtoHabeAper_D3 = item.antDolarHaber3;

                                            mtoDebeAper_S3 = 0;
                                            mtoHabeAper_S3 = 0;
                                            mtoDebeAper_D3 = 0;
                                            mtoHabeAper_D3 = 0;

                                            #endregion

                                            #region Total Cuenta 2

                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = Nivel2 + " " + cDesCta2 + " - Movimientos :";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S2;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S2;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D2;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D2;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta 2
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Anterior :";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S2);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S2);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D2);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D2);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ACTUAL CUENTA 2
                                            Decimal totDebe_S2 = mtoDebeAper_S2 + AntmtoDebeAper_S2;
                                            Decimal totHaber_S2 = mtoHabeAper_S2 + AntmtoHabeAper_S2;

                                            Decimal a2 = (totDebe_S2 - totHaber_S2 > 0 ? totDebe_S2 - totHaber_S2 : 0);
                                            Decimal b2 = (totDebe_S2 - totHaber_S2 < 0 ? Math.Abs(totDebe_S2 - totHaber_S2) : 0);

                                            Decimal totDebe_D2 = mtoDebeAper_D2 + AntmtoDebeAper_D2;
                                            Decimal totHaber_D2 = mtoHabeAper_D2 + AntmtoHabeAper_D2;

                                            Decimal c2 = (totDebe_D2 - totHaber_D2 > 0 ? totDebe_D2 - totHaber_D2 : 0);
                                            Decimal d2 = (0 > totDebe_D2 - totHaber_D2 ? Math.Abs(totDebe_D2 - totHaber_D2) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Actual: ";
                                            oHoja.Cells[InicioLinea, 7].Value = a2;
                                            oHoja.Cells[InicioLinea, 8].Value = b2;
                                            oHoja.Cells[InicioLinea, 9].Value = c2;
                                            oHoja.Cells[InicioLinea, 10].Value = d2;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            AntmtoDebeAper_S2 = item.antSolesDebe2;
                                            AntmtoHabeAper_S2 = item.antSolesHaber2;
                                            AntmtoDebeAper_D2 = item.antDolarDebe2;
                                            AntmtoHabeAper_D2 = item.antDolarHaber2;

                                            mtoDebeAper_S = 0;
                                            mtoHabeAper_S = 0;
                                            mtoDebeAper_D = 0;
                                            mtoHabeAper_D = 0;

                                            mtoDebeAper_S2 = 0;
                                            mtoHabeAper_S2 = 0;
                                            mtoDebeAper_D2 = 0;
                                            mtoHabeAper_D2 = 0;

                                            #endregion

                                            #region Total Cuenta 1

                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = Nivel1 + " " + cDesCta1 + " - Movimientos :";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S1;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S1;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D1;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D1;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta 1
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Anterior: ";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S1);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S1);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D1);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D1);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ACTUAL CUENTA 1
                                            Decimal totDebe_S1 = mtoDebeAper_S1 + AntmtoDebeAper_S1;
                                            Decimal totHaber_S1 = mtoHabeAper_S1 + AntmtoHabeAper_S1;

                                            Decimal a1 = (totDebe_S1 - totHaber_S1 > 0 ? totDebe_S1 - totHaber_S1 : 0);
                                            Decimal b1 = (totDebe_S1 - totHaber_S1 < 0 ? Math.Abs(totDebe_S1 - totHaber_S1) : 0);

                                            Decimal totDebe_D1 = mtoDebeAper_D1 + AntmtoDebeAper_D1;
                                            Decimal totHaber_D1 = mtoHabeAper_D1 + AntmtoHabeAper_D1;

                                            Decimal c1 = (totDebe_D1 - totHaber_D1 > 0 ? totDebe_D1 - totHaber_D1 : 0);
                                            Decimal d1 = (0 > totDebe_D1 - totHaber_D1 ? Math.Abs(totDebe_D1 - totHaber_D1) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Actual :";
                                            oHoja.Cells[InicioLinea, 7].Value = a1;
                                            oHoja.Cells[InicioLinea, 8].Value = b1;
                                            oHoja.Cells[InicioLinea, 9].Value = c1;
                                            oHoja.Cells[InicioLinea, 10].Value = d1;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            mtoDebeAper_S = 0;
                                            mtoHabeAper_S = 0;
                                            mtoDebeAper_D = 0;
                                            mtoHabeAper_D = 0;

                                            mtoDebeAper_S2 = 0;
                                            mtoHabeAper_S2 = 0;
                                            mtoDebeAper_D2 = 0;
                                            mtoHabeAper_D2 = 0;

                                            mtoDebeAper_S1 = 0;
                                            mtoHabeAper_S1 = 0;
                                            mtoDebeAper_D1 = 0;
                                            mtoHabeAper_D1 = 0;

                                            #endregion

                                            // CUENTA SUPERIOR 1

                                            oHoja.Cells[InicioLinea, 1].Value = item.Nivel1;
                                            oHoja.Cells[InicioLinea, 2].Value = item.cDesCta1;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            Nivel1 = item.Nivel1;
                                            cDesCta1 = item.cDesCta1;

                                            InicioLinea++;

                                            // CUENTA SUPERIOR 2
                                            oHoja.Cells[InicioLinea, 1].Value = item.Nivel2;
                                            oHoja.Cells[InicioLinea, 2].Value = item.cDesCta2;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            Nivel2 = item.Nivel2;
                                            cDesCta2 = item.cDesCta2;

                                            InicioLinea++;

                                            // CUENTA SUPERIOR 3
                                            oHoja.Cells[InicioLinea, 1].Value = item.Nivel3;
                                            oHoja.Cells[InicioLinea, 2].Value = item.cDesCta3;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            Nivel3 = item.Nivel3;
                                            cDesCta3 = item.cDesCta3;

                                            InicioLinea++;

                                            // CUENTA
                                            oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                                            oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            codCuenta = item.codCuenta;
                                            desCuenta = item.desCuenta;

                                            InicioLinea++;

                                            AntmtoDebeAper_S = item.antSolesDebe;
                                            AntmtoHabeAper_S = item.antSolesHaber;
                                            AntmtoDebeAper_D = item.antDolarDebe;
                                            AntmtoHabeAper_D = item.antDolarHaber;
                                        }

                                        if (Nivel2 != item.Nivel2)
                                        {
                                            #region Total Cuenta

                                            oHoja.Cells[InicioLinea, 1].Value = item.desCuenta;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = codCuenta + " " + desCuenta + " - Movimientos Cuenta: ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Anterior: ";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                                            totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                                            Decimal a = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                                            Decimal b = (totDebe_S - totHaber_S < 0 ? Math.Abs(totDebe_S - totHaber_S) : 0);

                                            totSubCtaDebe += a;
                                            totSubCtaHaber += b;
                                            totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                                            totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                                            Decimal c = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                                            Decimal d = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Actual: ";
                                            oHoja.Cells[InicioLinea, 7].Value = a;
                                            oHoja.Cells[InicioLinea, 8].Value = b;
                                            oHoja.Cells[InicioLinea, 9].Value = c;
                                            oHoja.Cells[InicioLinea, 10].Value = d;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            AntmtoDebeAper_S = item.antSolesDebe;
                                            AntmtoHabeAper_S = item.antSolesHaber;
                                            AntmtoDebeAper_D = item.antDolarDebe;
                                            AntmtoHabeAper_D = item.antDolarHaber;

                                            #endregion

                                            #region Total Cuenta 3

                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = Nivel3 + " " + cDesCta3 + " - Movimientos: ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S3;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S3;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D3;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D3;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta 2

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Anterior: ";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S3);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S3);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D3);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D3);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ACTUAL CUENTA 2
                                            Decimal totDebe_S3 = mtoDebeAper_S3 + AntmtoDebeAper_S3;
                                            Decimal totHaber_S3 = mtoHabeAper_S3 + AntmtoHabeAper_S3;

                                            Decimal a3 = (totDebe_S3 - totHaber_S3 > 0 ? totDebe_S3 - totHaber_S3 : 0);
                                            Decimal b3 = (totDebe_S3 - totHaber_S3 < 0 ? Math.Abs(totDebe_S3 - totHaber_S3) : 0);

                                            Decimal totDebe_D3 = mtoDebeAper_D3 + AntmtoDebeAper_D3;
                                            Decimal totHaber_D3 = mtoHabeAper_D3 + AntmtoHabeAper_D3;

                                            Decimal c3 = (totDebe_D3 - totHaber_D3 > 0 ? totDebe_D3 - totHaber_D3 : 0);
                                            Decimal d3 = (0 > totDebe_D3 - totHaber_D3 ? Math.Abs(totDebe_D3 - totHaber_D3) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Actual: ";
                                            oHoja.Cells[InicioLinea, 7].Value = a3;
                                            oHoja.Cells[InicioLinea, 8].Value = b3;
                                            oHoja.Cells[InicioLinea, 9].Value = c3;
                                            oHoja.Cells[InicioLinea, 10].Value = d3;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            AntmtoDebeAper_S3 = item.antSolesDebe3;
                                            AntmtoHabeAper_S3 = item.antSolesHaber3;
                                            AntmtoDebeAper_D3 = item.antDolarDebe3;
                                            AntmtoHabeAper_D3 = item.antDolarHaber3;

                                            mtoDebeAper_S3 = 0;
                                            mtoHabeAper_S3 = 0;
                                            mtoDebeAper_D3 = 0;
                                            mtoHabeAper_D3 = 0;

                                            #endregion

                                            #region Total Cuenta 2

                                            // TOTAL CUENTA 2
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = Nivel2 + " " + cDesCta2 + " - Movimientos: ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S2;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S2;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D2;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D2;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta 2
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Anterior: ";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S2);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S2);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D2);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D2);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ACTUAL CUENTA 2
                                            Decimal totDebe_S2 = mtoDebeAper_S2 + AntmtoDebeAper_S2;
                                            Decimal totHaber_S2 = mtoHabeAper_S2 + AntmtoHabeAper_S2;

                                            Decimal a2 = (totDebe_S2 - totHaber_S2 > 0 ? totDebe_S2 - totHaber_S2 : 0);
                                            Decimal b2 = (totDebe_S2 - totHaber_S2 < 0 ? Math.Abs(totDebe_S2 - totHaber_S2) : 0);

                                            Decimal totDebe_D2 = mtoDebeAper_D2 + AntmtoDebeAper_D2;
                                            Decimal totHaber_D2 = mtoHabeAper_D2 + AntmtoHabeAper_D2;

                                            Decimal c2 = (totDebe_D2 - totHaber_D2 > 0 ? totDebe_D2 - totHaber_D2 : 0);
                                            Decimal d2 = (0 > totDebe_D2 - totHaber_D2 ? Math.Abs(totDebe_D2 - totHaber_D2) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Actual: ";
                                            oHoja.Cells[InicioLinea, 7].Value = a2;
                                            oHoja.Cells[InicioLinea, 8].Value = b2;
                                            oHoja.Cells[InicioLinea, 9].Value = c2;
                                            oHoja.Cells[InicioLinea, 10].Value = d2;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            AntmtoDebeAper_S2 = item.antSolesDebe2;
                                            AntmtoHabeAper_S2 = item.antSolesHaber2;
                                            AntmtoDebeAper_D2 = item.antDolarDebe2;
                                            AntmtoHabeAper_D2 = item.antDolarHaber2;

                                            #endregion

                                            // CUENTA SUPERIOR 2
                                            oHoja.Cells[InicioLinea, 1].Value = item.Nivel2;
                                            oHoja.Cells[InicioLinea, 2].Value = item.cDesCta2;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            Nivel2 = item.Nivel2;
                                            cDesCta2 = item.cDesCta2;

                                            InicioLinea++;

                                            // CUENTA SUPERIOR 3
                                            oHoja.Cells[InicioLinea, 1].Value = item.Nivel3;
                                            oHoja.Cells[InicioLinea, 2].Value = item.cDesCta3;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            Nivel3 = item.Nivel3;
                                            cDesCta3 = item.cDesCta3;

                                            InicioLinea++;

                                            // CUENTA
                                            oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                                            oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            codCuenta = item.codCuenta;
                                            desCuenta = item.desCuenta;

                                            InicioLinea++;

                                            AntmtoDebeAper_S = item.antSolesDebe;
                                            AntmtoHabeAper_S = item.antSolesHaber;
                                            AntmtoDebeAper_D = item.antDolarDebe;
                                            AntmtoHabeAper_D = item.antDolarHaber;

                                            mtoDebeAper_S = 0;
                                            mtoHabeAper_S = 0;
                                            mtoDebeAper_D = 0;
                                            mtoHabeAper_D = 0;

                                            mtoDebeAper_S2 = 0;
                                            mtoHabeAper_S2 = 0;
                                            mtoDebeAper_D2 = 0;
                                            mtoHabeAper_D2 = 0;
                                        }

                                        if (Nivel3 != item.Nivel3)
                                        {
                                            #region Total Cuenta

                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = codCuenta + " " + desCuenta + " - Movimientos Cuenta: ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Anterior: ";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ACTUAL CUENTA
                                            totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                                            totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                                            Decimal a = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                                            Decimal b = (totDebe_S - totHaber_S < 0 ? Math.Abs(totDebe_S - totHaber_S) : 0);

                                            totSubCtaDebe += a;
                                            totSubCtaHaber += b;

                                            totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                                            totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                                            Decimal c = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                                            Decimal d = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Actual: ";
                                            oHoja.Cells[InicioLinea, 7].Value = a;
                                            oHoja.Cells[InicioLinea, 8].Value = b;
                                            oHoja.Cells[InicioLinea, 9].Value = c;
                                            oHoja.Cells[InicioLinea, 10].Value = d;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            AntmtoDebeAper_S = item.antSolesDebe;
                                            AntmtoHabeAper_S = item.antSolesHaber;
                                            AntmtoDebeAper_D = item.antDolarDebe;
                                            AntmtoHabeAper_D = item.antDolarHaber;

                                            #endregion

                                            #region Total Cuenta 3

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = Nivel3 + " " + cDesCta3 + " - Movimientos: ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                            {
                                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S3;
                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S3;
                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D3;
                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D3;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ANTERIOR Cuenta 2
                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Anterior: ";
                                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S3);
                                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S3);
                                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D3);
                                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D3);
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            // TOTAL SALDO ACTUAL CUENTA 2
                                            Decimal totDebe_S3 = mtoDebeAper_S3 + AntmtoDebeAper_S3;
                                            Decimal totHaber_S3 = mtoHabeAper_S3 + AntmtoHabeAper_S3;

                                            Decimal a3 = (totDebe_S3 - totHaber_S3 > 0 ? totDebe_S3 - totHaber_S3 : 0);
                                            Decimal b3 = (totDebe_S3 - totHaber_S3 < 0 ? Math.Abs(totDebe_S3 - totHaber_S3) : 0);

                                            Decimal totDebe_D3 = mtoDebeAper_D3 + AntmtoDebeAper_D3;
                                            Decimal totHaber_D3 = mtoHabeAper_D3 + AntmtoHabeAper_D3;

                                            Decimal c3 = (totDebe_D3 - totHaber_D3 > 0 ? totDebe_D3 - totHaber_D3 : 0);
                                            Decimal d3 = (0 > totDebe_D3 - totHaber_D3 ? Math.Abs(totDebe_D3 - totHaber_D3) : 0);

                                            oHoja.Cells[InicioLinea, 1].Value = "";

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo Actual: ";
                                            oHoja.Cells[InicioLinea, 7].Value = a3;
                                            oHoja.Cells[InicioLinea, 8].Value = b3;
                                            oHoja.Cells[InicioLinea, 9].Value = c3;
                                            oHoja.Cells[InicioLinea, 10].Value = d3;
                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                            InicioLinea++;

                                            AntmtoDebeAper_S3 = item.antSolesDebe3;
                                            AntmtoHabeAper_S3 = item.antSolesHaber3;
                                            AntmtoDebeAper_D3 = item.antDolarDebe3;
                                            AntmtoHabeAper_D3 = item.antDolarHaber3;

                                            mtoDebeAper_S3 = 0;
                                            mtoHabeAper_S3 = 0;
                                            mtoDebeAper_D3 = 0;
                                            mtoHabeAper_D3 = 0;

                                            #endregion

                                            // CUENTA SUPERIOR 3
                                            oHoja.Cells[InicioLinea, 1].Value = item.Nivel3;
                                            oHoja.Cells[InicioLinea, 2].Value = item.cDesCta3;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            Nivel3 = item.Nivel3;
                                            cDesCta3 = item.cDesCta3;

                                            InicioLinea++;

                                            // CUENTA
                                            oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                                            oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;

                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            codCuenta = item.codCuenta;
                                            desCuenta = item.desCuenta;

                                            InicioLinea++;

                                            mtoDebeAper_S = 0;
                                            mtoHabeAper_S = 0;
                                            mtoDebeAper_D = 0;
                                            mtoHabeAper_D = 0;

                                            AntmtoDebeAper_S = 0;
                                            AntmtoHabeAper_S = 0;
                                            AntmtoDebeAper_D = 0;
                                            AntmtoHabeAper_D = 0;

                                            mtoDebeAper_S3 = 0;
                                            mtoHabeAper_S3 = 0;
                                            mtoDebeAper_D3 = 0;
                                            mtoHabeAper_D3 = 0;
                                        }
                                    }

                                    if (codCuenta != item.codCuenta)
                                    {
                                        #region Total Cuenta

                                        oHoja.Cells[InicioLinea, 1].Value = " ";

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }

                                        InicioLinea++;

                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";
                                        oHoja.Cells[InicioLinea, 3].Value = codCuenta + " " + desCuenta + " - Movimientos Cuenta: ";

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }

                                        oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S;
                                        oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S;
                                        oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D;
                                        oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D;
                                        oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                        InicioLinea++;

                                        // TOTAL SALDO ANTERIOR Cuenta
                                        oHoja.Cells[InicioLinea, 1].Value = " ";

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }

                                        oHoja.Cells[InicioLinea, 6].Value = "Saldo Anterior: ";
                                        oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S);
                                        oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S);
                                        oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D);
                                        oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D);
                                        oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                        InicioLinea++;

                                        // TOTAL SALDO ACTUAL CUENTA
                                        totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                                        totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                                        Decimal a = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                                        Decimal b = (totDebe_S - totHaber_S < 0 ? Math.Abs(totDebe_S - totHaber_S) : 0);

                                        totSubCtaDebe += a;
                                        totSubCtaHaber += b;

                                        totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                                        totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                                        Decimal c = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                                        Decimal d = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                                        oHoja.Cells[InicioLinea, 1].Value = "";

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }

                                        oHoja.Cells[InicioLinea, 6].Value = "Saldo Actual: ";
                                        oHoja.Cells[InicioLinea, 7].Value = a;
                                        oHoja.Cells[InicioLinea, 8].Value = b;
                                        oHoja.Cells[InicioLinea, 9].Value = c;
                                        oHoja.Cells[InicioLinea, 10].Value = d;
                                        oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                        InicioLinea++;

                                        AntmtoDebeAper_S = item.antSolesDebe;
                                        AntmtoHabeAper_S = item.antSolesHaber;
                                        AntmtoDebeAper_D = item.antDolarDebe;
                                        AntmtoHabeAper_D = item.antDolarHaber;

                                        #endregion

                                        // CUENTA
                                        oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                                        oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }

                                        codCuenta = item.codCuenta;
                                        desCuenta = item.desCuenta;

                                        InicioLinea++;

                                        AntmtoDebeAper_S = item.antSolesDebe;
                                        AntmtoHabeAper_S = item.antSolesHaber;
                                        AntmtoDebeAper_D = item.antDolarDebe;
                                        AntmtoHabeAper_D = item.antDolarHaber;

                                        mtoDebeAper_S = 0;
                                        mtoHabeAper_S = 0;
                                        mtoDebeAper_D = 0;
                                        mtoHabeAper_D = 0;
                                    }
                                }

                                #region PROVEEDORES

                                if (chbProveedor.Checked && item.Ruc.Trim().Length > 0)
                                {
                                    if (ia == 0)
                                    {
                                        RUC = item.Ruc;


                                        oHoja.Cells[InicioLinea, 1].Value = " ";


                                        oHoja.Cells[InicioLinea, 2].Value = item.Ruc + " - " + item.RazonSocial;
                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                        {
                                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                        }
                                        InicioLinea++;
                                    }
                                    else
                                    {
                                        if (RUC != item.Ruc)
                                        {
                                            oHoja.Cells[InicioLinea, 1].Value = "";
                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Movimientos Proveedor: ";

                                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S_Prov;

                                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S_Prov;

                                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D_Prov;

                                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D_Prov;

                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                                            InicioLinea++;


                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            oHoja.Cells[InicioLinea, 6].Value = "Saldo: ";

                                            oHoja.Cells[InicioLinea, 7].Value = (mtoDebeAper_S_Prov > mtoHabeAper_S_Prov ? mtoDebeAper_S_Prov - mtoHabeAper_S_Prov : 0);

                                            oHoja.Cells[InicioLinea, 8].Value = (mtoHabeAper_S_Prov > mtoDebeAper_S_Prov ? mtoHabeAper_S_Prov - mtoDebeAper_S_Prov : 0);

                                            oHoja.Cells[InicioLinea, 9].Value = (mtoDebeAper_D_Prov > mtoHabeAper_D_Prov ? mtoDebeAper_D_Prov - mtoHabeAper_D_Prov : 0);

                                            oHoja.Cells[InicioLinea, 10].Value = (mtoHabeAper_D_Prov > mtoDebeAper_D_Prov ? mtoHabeAper_D_Prov - mtoDebeAper_D_Prov : 0);

                                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                                            InicioLinea++;

                                            mtoDebeAper_S_Prov = 0;
                                            mtoHabeAper_S_Prov = 0;

                                            mtoDebeAper_D_Prov = 0;
                                            mtoHabeAper_D_Prov = 0;

                                            RUC = item.Ruc;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";

                                            oHoja.Cells[InicioLinea, 2].Value = item.Ruc + " - " + item.RazonSocial;
                                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 10])
                                            {
                                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                            }

                                            InicioLinea++;
                                        }
                                    }
                                }

                                #endregion

                                AntmtoDebeAper_S = item.antSolesDebe;
                                AntmtoHabeAper_S = item.antSolesHaber;
                                AntmtoDebeAper_D = item.antDolarDebe;
                                AntmtoHabeAper_D = item.antDolarHaber;

                                AntmtoDebeAper_S1 = item.antSolesDebe1;
                                AntmtoHabeAper_S1 = item.antSolesHaber1;
                                AntmtoDebeAper_D1 = item.antDolarDebe1;
                                AntmtoHabeAper_D1 = item.antDolarHaber1;

                                AntmtoDebeAper_S2 = item.antSolesDebe2;
                                AntmtoHabeAper_S2 = item.antSolesHaber2;
                                AntmtoDebeAper_D2 = item.antDolarDebe2;
                                AntmtoHabeAper_D2 = item.antDolarHaber2;

                                AntmtoDebeAper_S3 = item.antSolesDebe3;
                                AntmtoHabeAper_S3 = item.antSolesHaber3;
                                AntmtoDebeAper_D3 = item.antDolarDebe3;
                                AntmtoHabeAper_D3 = item.antDolarHaber3;

                                if (item.Fecha != null)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = Convert.ToDateTime(item.Fecha).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = " ";
                                }

                                oHoja.Cells[InicioLinea, 2].Value = item.idComprobante + " - " + item.numVoucher + " - " + item.numFile + " - " + item.numItem;
                                oHoja.Cells[InicioLinea, 3].Value = item.idDocumento;
                                oHoja.Cells[InicioLinea, 4].Value = (item.serDocumento == "0000" ? "" : item.serDocumento) + "  " + item.numDocumento;

                                if (item.fecDocumento != null)
                                {
                                    oHoja.Cells[InicioLinea, 5].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 5].Value = " ";
                                }

                                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20476115711") //S.C. INGENIERIA SRL
                                {
                                    oHoja.Cells[InicioLinea, 6].Value = item.GlosaGeneral.Substring(0, (item.GlosaGeneral.Length > 35 ? 35 : item.GlosaGeneral.Length));
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 6].Value = Global.DejarSoloUnEspacio(item.GlosaGeneral.Trim());
                                }

                                if (item.indDebeHaber == "D")
                                {
                                    oHoja.Cells[InicioLinea, 7].Value = (item.impSoles);
                                    oHoja.Cells[InicioLinea, 8].Value = 0;
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 7].Value = 0;
                                    oHoja.Cells[InicioLinea, 8].Value = (item.impSoles);
                                }

                                if (item.indDebeHaber == "D")
                                {
                                    oHoja.Cells[InicioLinea, 9].Value = (item.impDolares);
                                    oHoja.Cells[InicioLinea, 10].Value = 0;
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 9].Value = 0;
                                    oHoja.Cells[InicioLinea, 10].Value = (item.impDolares);
                                }

                                oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                Decimal saldodebe = 0;
                                Decimal saldohaber = 0;

                                if (item.indDebeHaber == "D" && item.idComprobante != "00")
                                {
                                    mtoDebeAper_S += item.impSoles;
                                    mtoDebeAper_S1 += item.impSoles;
                                    mtoDebeAper_S2 += item.impSoles;
                                    mtoDebeAper_S3 += item.impSoles;

                                    mtoDebeAper_D += item.impDolares;
                                    mtoDebeAper_D1 += item.impDolares;
                                    mtoDebeAper_D2 += item.impDolares;
                                    mtoDebeAper_D3 += item.impDolares;

                                    mtoDebeAper_S_Prov += item.impSoles;
                                    mtoDebeAper_D_Prov += item.impDolares;

                                    saldodebe = (item.impSoles);
                                    saldohaber = 0;
                                }
                                else
                                {
                                    mtoHabeAper_S += item.impSoles;
                                    mtoHabeAper_S1 += item.impSoles;
                                    mtoHabeAper_S2 += item.impSoles;
                                    mtoHabeAper_S3 += item.impSoles;

                                    mtoHabeAper_D += item.impDolares;
                                    mtoHabeAper_D1 += item.impDolares;
                                    mtoHabeAper_D2 += item.impDolares;
                                    mtoHabeAper_D3 += item.impDolares;

                                    mtoHabeAper_S_Prov += item.impSoles;
                                    mtoHabeAper_D_Prov += item.impDolares;

                                    saldodebe = 0;
                                    saldohaber = (item.impSoles);
                                }

                                InicioLinea++;
                            }
                        }

                        #region Total Cuenta

                        oHoja.Cells[InicioLinea, 1].Value = " ";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                        {
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        }

                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 1].Value = " ";
                        oHoja.Cells[InicioLinea, 2].Value = " ";
                        oHoja.Cells[InicioLinea, 3].Value = codCuenta + " " + desCuenta + " - Movimientos Cuenta: ";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                        {
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S;
                        oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S;
                        oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D;
                        oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D;
                        oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;

                        // SALDO ANTERIOR CUENTA
                        oHoja.Cells[InicioLinea, 1].Value = " ";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                        {
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 6].Value = " Saldo Anterior: ";
                        oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S);
                        oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S);
                        oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D);
                        oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D);
                        oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;

                        // SALDO ACTUAL CUENTA
                        totDebe_S = mtoDebeAper_S + AntmtoDebeAper_S;
                        totHaber_S = mtoHabeAper_S + AntmtoHabeAper_S;

                        Decimal h = (totDebe_S - totHaber_S > 0 ? totDebe_S - totHaber_S : 0);
                        Decimal j = (0 > totDebe_S - totHaber_S ? Math.Abs(totDebe_S - totHaber_S) : 0);

                        totSubCtaDebe += h;
                        totSubCtaHaber += j;

                        totDebe_D = mtoDebeAper_D + AntmtoDebeAper_D;
                        totHaber_D = mtoHabeAper_D + AntmtoHabeAper_D;

                        Decimal k = (totDebe_D - totHaber_D > 0 ? totDebe_D - totHaber_D : 0);
                        Decimal l = (0 > totDebe_D - totHaber_D ? Math.Abs(totDebe_D - totHaber_D) : 0);

                        oHoja.Cells[InicioLinea, 1].Value = "";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                        {
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells[InicioLinea, 6].Value = " Saldo Actual:";
                        oHoja.Cells[InicioLinea, 7].Value = h;
                        oHoja.Cells[InicioLinea, 8].Value = j;
                        oHoja.Cells[InicioLinea, 9].Value = k;
                        oHoja.Cells[InicioLinea, 10].Value = l;
                        oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;

                        #endregion

                        if (chbVerNiveles.Checked)
                        {
                            #region Total Cuenta 3

                            oHoja.Cells[InicioLinea, 1].Value = " ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                            {
                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            }

                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1].Value = " ";
                            oHoja.Cells[InicioLinea, 2].Value = " ";
                            oHoja.Cells[InicioLinea, 3].Value = Nivel3 + " " + cDesCta3 + " - Movimientos: ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                            {
                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S3;
                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S3;
                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D3;
                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D3;
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            // TOTAL SALDO ANTERIOR Cuenta 2
                            oHoja.Cells[InicioLinea, 1].Value = " ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Anterior:";
                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S3);
                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S3);
                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D3);
                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D3);
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            // TOTAL SALDO ACTUAL CUENTA 2
                            Decimal totDebe_S3 = mtoDebeAper_S3 + AntmtoDebeAper_S3;
                            Decimal totHaber_S3 = mtoHabeAper_S3 + AntmtoHabeAper_S3;

                            Decimal a3 = (totDebe_S3 - totHaber_S3 > 0 ? totDebe_S3 - totHaber_S3 : 0);
                            Decimal b3 = (totDebe_S3 - totHaber_S3 < 0 ? Math.Abs(totDebe_S3 - totHaber_S3) : 0);

                            Decimal totDebe_D3 = mtoDebeAper_D3 + AntmtoDebeAper_D3;
                            Decimal totHaber_D3 = mtoHabeAper_D3 + AntmtoHabeAper_D3;

                            Decimal c3 = (totDebe_D3 - totHaber_D3 > 0 ? totDebe_D3 - totHaber_D3 : 0);
                            Decimal d3 = (0 > totDebe_D3 - totHaber_D3 ? Math.Abs(totDebe_D3 - totHaber_D3) : 0);

                            oHoja.Cells[InicioLinea, 1].Value = "";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Actual:";
                            oHoja.Cells[InicioLinea, 7].Value = a3;
                            oHoja.Cells[InicioLinea, 8].Value = b3;
                            oHoja.Cells[InicioLinea, 9].Value = c3;
                            oHoja.Cells[InicioLinea, 10].Value = d3;
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            #endregion

                            #region Total Cuenta 2

                            oHoja.Cells[InicioLinea, 1].Value = " ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1].Value = " ";
                            oHoja.Cells[InicioLinea, 2].Value = " ";
                            oHoja.Cells[InicioLinea, 3].Value = Nivel2 + " " + cDesCta2 + " - Movimientos: ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S2;
                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S2;
                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D2;
                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D2;
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            // TOTAL SALDO ANTERIOR Cuenta 2
                            oHoja.Cells[InicioLinea, 1].Value = " ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Anterior:";
                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S2);
                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S2);
                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D2);
                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D2);
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            // TOTAL SALDO ACTUAL CUENTA 2
                            Decimal totDebe_S2 = mtoDebeAper_S2 + AntmtoDebeAper_S2;
                            Decimal totHaber_S2 = mtoHabeAper_S2 + AntmtoHabeAper_S2;

                            Decimal a2 = (totDebe_S2 - totHaber_S2 > 0 ? totDebe_S2 - totHaber_S2 : 0);
                            Decimal b2 = (totDebe_S2 - totHaber_S2 < 0 ? Math.Abs(totDebe_S2 - totHaber_S2) : 0);

                            Decimal totDebe_D2 = mtoDebeAper_D2 + AntmtoDebeAper_D2;
                            Decimal totHaber_D2 = mtoHabeAper_D2 + AntmtoHabeAper_D2;

                            Decimal c2 = (totDebe_D2 - totHaber_D2 > 0 ? totDebe_D2 - totHaber_D2 : 0);
                            Decimal d2 = (0 > totDebe_D2 - totHaber_D2 ? Math.Abs(totDebe_D2 - totHaber_D2) : 0);

                            oHoja.Cells[InicioLinea, 1].Value = "";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Actual: ";
                            oHoja.Cells[InicioLinea, 7].Value = a2;
                            oHoja.Cells[InicioLinea, 8].Value = b2;
                            oHoja.Cells[InicioLinea, 9].Value = c2;
                            oHoja.Cells[InicioLinea, 10].Value = d2;
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            #endregion

                            #region Total Cuenta 1

                            oHoja.Cells[InicioLinea, 1].Value = " ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 10])
                            {
                                Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            }

                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1].Value = " ";
                            oHoja.Cells[InicioLinea, 2].Value = " ";
                            oHoja.Cells[InicioLinea, 3].Value = Nivel1 + " " + cDesCta1 + " - Movimientos: ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 6])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 7].Value = mtoDebeAper_S1;
                            oHoja.Cells[InicioLinea, 8].Value = mtoHabeAper_S1;
                            oHoja.Cells[InicioLinea, 9].Value = mtoDebeAper_D1;
                            oHoja.Cells[InicioLinea, 10].Value = mtoHabeAper_D1;
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            // TOTAL SALDO ANTERIOR Cuenta 1
                            oHoja.Cells[InicioLinea, 1].Value = " ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Anterior: ";
                            oHoja.Cells[InicioLinea, 7].Value = (AntmtoDebeAper_S1);
                            oHoja.Cells[InicioLinea, 8].Value = (AntmtoHabeAper_S1);
                            oHoja.Cells[InicioLinea, 9].Value = (AntmtoDebeAper_D1);
                            oHoja.Cells[InicioLinea, 10].Value = (AntmtoHabeAper_D1);
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            // TOTAL SALDO ACTUAL CUENTA 1
                            Decimal totDebe_S1 = mtoDebeAper_S1 + AntmtoDebeAper_S1;
                            Decimal totHaber_S1 = mtoHabeAper_S1 + AntmtoHabeAper_S1;

                            Decimal a1 = (totDebe_S1 - totHaber_S1 > 0 ? totDebe_S1 - totHaber_S1 : 0);
                            Decimal b1 = (totDebe_S1 - totHaber_S1 < 0 ? Math.Abs(totDebe_S1 - totHaber_S1) : 0);

                            Decimal totDebe_D1 = mtoDebeAper_D1 + AntmtoDebeAper_D1;
                            Decimal totHaber_D1 = mtoHabeAper_D1 + AntmtoHabeAper_D1;

                            Decimal c1 = (totDebe_D1 - totHaber_D1 > 0 ? totDebe_D1 - totHaber_D1 : 0);
                            Decimal d1 = (0 > totDebe_D1 - totHaber_D1 ? Math.Abs(totDebe_D1 - totHaber_D1) : 0);

                            oHoja.Cells[InicioLinea, 1].Value = "";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 5])
                            {
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 6].Value = " Saldo Actual: ";
                            oHoja.Cells[InicioLinea, 7].Value = a1;
                            oHoja.Cells[InicioLinea, 8].Value = b1;
                            oHoja.Cells[InicioLinea, 9].Value = c1;
                            oHoja.Cells[InicioLinea, 10].Value = d1;
                            oHoja.Cells[InicioLinea, 7, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            #endregion
                        }

                        #endregion

                        //Linea
                        Int32 totFilas2 = InicioLinea;
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                        //Suma
                        InicioLinea++;
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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Generando el PDF
                if (tipoProceso == 1)
                {
                    lblProcesando.Text = "Obteniendo los registros para el Libro...";
                    ListaReporte();
                    lblProcesando.Text = "Armando el Reporte de Libro Mayor...";

                   if (oListaRegistroDeDiario != null)
                    {
                        ConvertirApdf();
                    }

                }
                else
                {
                    lblProcesando.Text = "Exportando a Excel el Libro Mayor.";
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
            Marque = String.Empty;
            timer.Enabled = false;
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;
            //lblRegistros.Text = String.Empty;
            lblProceso.Text = String.Empty;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                //Mostrando el reporte en un web browser
                if (tipoProceso == 1)
                {
                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                        tipoProceso = 0;
                        btPle.Enabled = true;
                        btExportar.Enabled = true;
                    }
                }

                if (tipoProceso == 2)
                {
                    Global.MensajeComunicacion("Registros Exportados...");
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteLibroMayor_Load(object sender, EventArgs e)
        {
            Grid = true;
            cboAño.SelectedValue = VariablesLocales.PeriodoContable.AnioPeriodo;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCuentaIni.Text.Trim().Length == 0)
                {
                    Global.MensajeFault("Debe de ingresar la Cuenta Inicio");
                    return;
                }
                if (txtCuentaFin.Text.Trim().Length == 0)
                {
                    Global.MensajeFault("Debe de ingresar la Cuenta Fin");
                    return;
                }

                tipoProceso = 1;

                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                btPle.Enabled = false;
                btExportar.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                Text = "Libro Mayor: " + cboSucursales.Text.ToString();
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

        private void btnBusquedaCuentaIni_Click(object sender, EventArgs e)
        {
            frmBuscarCuentas frm = new frmBuscarCuentas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCuentaIni.Text = frm.Cuentas.codCuenta;
                txtDesCuentaIni.Text = frm.Cuentas.Descripcion;
            }
        }

        private void btnBusquedaCuentaFin_Click(object sender, EventArgs e)
        {
            frmBuscarCuentas frm = new frmBuscarCuentas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCuentaFin.Text = frm.Cuentas.codCuenta;
                txtDesCuentaFin.Text = frm.Cuentas.Descripcion;
            }
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

        private void txtCuentaIni_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
        }

        private void txtCuentaFin_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
        } 

        private void btExportar_Click(object sender, EventArgs e)
        {
            cmsFormatos.Show(btExportar, new Point(0, btExportar.Height));
            //try
            //{
            //    if (oListaRegistroDeDiario.Count == Variables.Cero)
            //    {
            //        Global.MensajeFault("No hay datos para exportar a Excel.");
            //        return;
            //    }

            //    //String dia = VariablesLocales.FechaHoy.Date.Day.ToString("00");
            //    String mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
            //    String anio = VariablesLocales.FechaHoy.Date.Year.ToString();

            //    RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registros Importados Libro Mayor (" + mes + "_" + anio + ")", "Archivos Excel (*.xlsx)|*.xlsx");
            //    Formato2 = "S";
            //    if (!String.IsNullOrEmpty(RutaGeneral))
            //    {
            //        lblProcesando.Visible = true;
            //        timer.Enabled = true;
            //        Marque = "Importando los registros a Excel...";
            //        pbProgress.Visible = true;
            //        Cursor = Cursors.WaitCursor;

            //        _bw.RunWorkerAsync();
            //    }
            //    else
            //    {
            //        if (_bw.IsBusy)
            //        {
            //            _bw.CancelAsync();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeError(ex.Message);
            //}
        }

        private void btPle_Click(object sender, EventArgs e)
        {
            #region Variables

            String nomLibro = String.Empty;
            String MesReal = cboPeriodoFin.SelectedValue.ToString();
            String AnioReal = VariablesLocales.PeriodoContable.AnioPeriodo;
            String RutaArchivoTexto = String.Empty;
            Int32 LineaMsg = 0;

            #endregion Variables

            try
            {
                #region Validaciones

                if (oListaRegistroDeDiario == null || oListaRegistroDeDiario.Count == Variables.Cero)
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

                nomLibro = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + AnioReal + MesReal + "00060100001111";
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
                        //String DatoEst = String.Empty;
                        String Estado = String.Empty;

                        Decimal MontoDebe = Variables.ValorCeroDecimal;
                        Decimal MontoHaber = Variables.ValorCeroDecimal;

                        #endregion Variables

                        foreach (RegistroDiarioE item in oListaRegistroDeDiario)
                        {
                            LineaMsg++;

                            if (!String.IsNullOrWhiteSpace(item.idComprobante) && !String.IsNullOrWhiteSpace(item.numFile) && !String.IsNullOrWhiteSpace(item.numVoucher) && item.idLocal != 0)
                            {
                                //if (LineaMsg == 995)
                                //{
                                //    MessageBox.Show("revisar");
                                //}

                                Periodo = item.AnioPeriodo + item.MesPeriodo + "00";
                                codUniOpe = item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher + item.numItem;
                                Correlativo = item.Campo3;
                                codCuenta = item.codCuenta;
                                UnidadOpe = String.Empty;
                                codCentroC = String.Empty;

                                Moneda = "PEN";

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

                                fecContable = item.fecOperacion == null ? "" : item.fecOperacion.Value.ToString("dd/MM/yyyy");
                                fecVencimiento = String.Empty;
                                fecOperacion = item.fecOperacion == null ? "" : item.fecOperacion.Value.ToString("dd/MM/yyyy");

                                Glosa = Global.DejarSoloUnEspacio(item.GlosaGeneral.Trim());
                                if (String.IsNullOrEmpty(Glosa)) Glosa = item.desCuenta;
                                if (Glosa.Length > 100) Glosa = Global.Izquierda(Glosa, 100);

                                Glosa.Replace("%", String.Empty);
                                Glosa.Replace("$", String.Empty);
                                Glosa.Replace("/", String.Empty);
                                Glosa.Replace("+", String.Empty);
                                GlosaRefe = String.Empty;

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

                                if (Convert.ToDateTime(item.fecOperacion).ToString("yyyyMM") == AnioReal + MesReal)
                                {
                                    Estado = "1";
                                }
                                else
                                {
                                    Estado = "8";
                                }

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
                                    

                                    Linea.Append(Periodo).Append("|").Append(codUniOpe).Append("|").Append(Correlativo).Append("|");
                                    Linea.Append(codCuenta).Append("|").Append(UnidadOpe).Append("|").Append(codCentroC).Append("|");
                                    Linea.Append(Moneda).Append("|").Append(tipDocEmisor).Append("|").Append(numDocEmisor).Append("|");
                                    Linea.Append(idDocumento).Append("|").Append(serDocumento).Append("|").Append(numDocumento).Append("|");
                                    Linea.Append(fecContable).Append("|").Append(fecVencimiento).Append("|").Append(fecOperacion).Append("|");
                                    Linea.Append(Glosa).Append("|").Append(GlosaRefe).Append("|").Append(totDebe).Append("|");
                                    Linea.Append(totHaber).Append("||").Append(Estado).Append("|");

                                    oSw.WriteLine(Linea.ToString());
                                    Linea.Clear();
                                }

                                #endregion Insertar Linea 
                            }
                        }
                    }

                    Global.MensajeComunicacion("Archivo exportado...!!");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message + ' ' + LineaMsg.ToString());
            }
        }

        private void tsmFormato1_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaRegistroDeDiario.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String MesIni = cboPeriodoIni.SelectedValue.ToString();
                String MesFin = cboPeriodoFin.SelectedValue.ToString();
                String anio = VariablesLocales.FechaHoy.Date.Year.ToString();
                String NombreArchivo = String.Empty;

                if (MesIni == MesFin)
                {
                    NombreArchivo = String.Format("Registros Libro Mayor del Periodo {0}-{1} F1", MesIni, anio);
                }
                else
                {
                    NombreArchivo = String.Format("Registros Libro Mayor del Periodo {0}-{1} al Periodo {2}-{1} F1", MesIni, anio, MesFin);
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Formato2 = "N";
                    tipoProceso = 2;
                    lblProcesando.Visible = true;
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

        private void tsmFormato2_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaRegistroDeDiario.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String MesIni = cboPeriodoIni.SelectedValue.ToString();
                String MesFin = cboPeriodoFin.SelectedValue.ToString();
                String anio = VariablesLocales.FechaHoy.Date.Year.ToString();
                String NombreArchivo = String.Empty;

                if (MesIni == MesFin)
                {
                    NombreArchivo = String.Format("Registros Libro Mayor del Periodo {0}-{1} F2", MesIni, anio);
                }
                else
                {
                    NombreArchivo = String.Format("Registros Libro Mayor del Periodo {0}-{1} al Periodo {2}-{1} F2", MesIni, anio, MesFin);
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Formato2 = "S";
                    tipoProceso = 2;
                    lblProcesando.Visible = true;
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

        #endregion

    }
}

internal class PaginaInicialLibroMayor : PdfPageEventHelper
{

    public String Periodo { get; set; }
    public String PeriodoFin { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        String Anio = VariablesLocales.PeriodoContable.AnioPeriodo;
        PdfPCell cell = null;
        Boolean MostrarFecPrint = VariablesLocales.oConParametros.MostrarFechaPrint;

        TituloGeneral = "LIBRO MAYOR";

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2)
        {
            WidthPercentage = 100
        };
        table.SetWidths(new float[] { 0.9f, 0.13f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        if (Periodo != PeriodoFin)
        {
            SubTitulo = "De " + FechasHelper.NombreMes(Convert.ToInt32(Periodo)).ToUpper() + " a " + FechasHelper.NombreMes(Convert.ToInt32(PeriodoFin)).ToUpper();
        }
        else
        {
            SubTitulo = "De " + FechasHelper.NombreMes(Convert.ToInt32(Periodo)).ToUpper();
        }

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 5, 1));
        table.AddCell(ReaderHelper.NuevaCelda(MostrarFecPrint ? "Fecha: " + FechaActual : " ", null, "N", null, FontFactory.GetFont("Arial", 7), 6));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo + " del " + Anio, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1));
        table.AddCell(ReaderHelper.NuevaCelda(MostrarFecPrint ? "Hora: " + HoraActual : " ", null, "N", null, FontFactory.GetFont("Arial", 7)));
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
        table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 7)));
        table.CompleteRow(); //Fila completada 

        #endregion

        #region Subtitulos

        table.AddCell(ReaderHelper.NuevaCelda("RUC:   " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RAZON SOCIAL:  " + VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
        table.CompleteRow(); //Fila completada 

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        float[] WidthColumna = new float[] { 0.12f, 0.2f, 0.05f, 0.15f, 0.1f, 0.4f, 0.13f, 0.13f, 0.13f, 0.13f };

        PdfPTable TablaCabDetalle = new PdfPTable(10)
        {
            WidthPercentage = 100
        };
        TablaCabDetalle.SetWidths(WidthColumna);

        #region Primera Linea

        //Columna 1
        cell = new PdfPCell(new Paragraph("FECHA \n OPERACIÓN", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        //Columna 2
        cell = new PdfPCell(new Paragraph("NUMERO \n CORRELATIVO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        //Columna 3
        cell = new PdfPCell(new Paragraph("TD", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        //Columna 4
        cell = new PdfPCell(new Paragraph("NUMERO DOCUMENTO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        cell.Rowspan = 3;
        TablaCabDetalle.AddCell(cell);

        //Columna 5
        cell = new PdfPCell(new Paragraph("FECHA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        //Columna 6
        cell = new PdfPCell(new Paragraph("GLOSA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        cell.Rowspan = 2;
        TablaCabDetalle.AddCell(cell);

        //Columna 7, 8
        cell = new PdfPCell(new Paragraph("Movimiento Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        //Columna 9, 10
        cell = new PdfPCell(new Paragraph("Movimiento Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion

        #region Segunda Linea
        //Columna 7
        cell = new PdfPCell(new Paragraph("DEBE", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        TablaCabDetalle.AddCell(cell);

        //Columna 8
        cell = new PdfPCell(new Paragraph("HABER", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        TablaCabDetalle.AddCell(cell);

        //Columna 9
        cell = new PdfPCell(new Paragraph("DEBE", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        TablaCabDetalle.AddCell(cell);

        //Columna 10
        cell = new PdfPCell(new Paragraph("HABER", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}
