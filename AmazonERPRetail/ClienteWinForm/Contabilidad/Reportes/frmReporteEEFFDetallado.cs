using ClienteWinForm;
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
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEEFFDetallado : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteEEFFDetallado()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        #endregion

        #region Variables
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        String RutaPdf = String.Empty;
        List<EEFFE> oListaEEFFDETALLADO = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        string Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        string tipo = "buscar";
        String Marque = String.Empty;
        //EmpresaImagenesE oEmpresaImagen = null;
        //EmpresaImagenesE oEmpresaImagen2 = null;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        String tipoBotton = String.Empty;
        #endregion

        #region Combos

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


            List<EEFFE> oListaEEFF = AgenteContabilidad.Proxy.ListarEEFF(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, "", true);

            oListaEEFF.Add(new EEFFE { idEEFF = 0, desSeccion = "<SELECCIONE>" });

            ComboHelper.LlenarCombos<EEFFE>(cboEEFF, oListaEEFF.OrderBy(x => x.idEEFF).ToList(), "idEEFF", "desSeccion");


        }

        #endregion

        #region Procedimientos PDF Usuario

        void ConvertirApdfDetallado()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\eeffDetallado " + Aleatorio.ToString();
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
                //PdfPCell cell = null;

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
                             
                RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                String TipoReporte = ((EEFFE)cboEEFF.SelectedItem).tipoReporte;

                // Detalle para Reporte tipo Balance
                if (TipoReporte == "B")
                {
                    PaginaInicioBalanceDetallado ev = new PaginaInicioBalanceDetallado();
                    ev.Anio = Convert.ToString(cboAño.SelectedValue);
                    ev.Mes = Convert.ToInt32(cboMes.SelectedValue);

                    String secciondescripcion = ((EEFFE)cboEEFF.SelectedItem).desSeccion;
                    ev.destit = secciondescripcion;
                    ev.rutaimagen = RutaImagen;
                    oPdfw.PageEvent = ev;

                    #region Reporte Detallado del Balance

                    #region Variables Iniciales

                    docPdf.Open();

                    PdfPTable TablaCabDetalle = new PdfPTable(4);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.5f, 0.1f, 0.1f });

                    int contador = 0;
                    int ContadorTotal = 0;
                    string seccion = "";
                    string descripcion = "";
                    string sec = "";
                    string tabla = "";
                    decimal subTotDeu = 0;
                    decimal subTotAcree = 0;
                    decimal subsubDeu = 0;
                    decimal subsubAcree = 0;

                    decimal total1 = 0;
                    decimal total2 = 0;
                    decimal TotalPasPatrimonioDebe = 0;
                    decimal TotalPasPatrimonioHaber = 0;

                    string LineaSepradoraig = "=================";
                    int detalledeuno = 0;
                    string LineaSepradora = "-----------------------------";
                    iTextSharp.text.Font Fuente = FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                    #endregion 

                    oListaEEFFDETALLADO = (from x in oListaEEFFDETALLADO where ((x.TipoTabla == "DET" && (x.Deudor != 0 || x.Acreedor != 0)) || x.TipoTabla == "TOT" || x.TipoTabla == "TIT") select x).ToList();

                    for (int i = 0; i < oListaEEFFDETALLADO.Count; i++)
                    {
                        #region Primera Linea Impresion de Titulos 

                        if (oListaEEFFDETALLADO[i].TipoTabla == "TIT")
                        {
                            seccion = oListaEEFFDETALLADO[i].secitem;
                            descripcion = oListaEEFFDETALLADO[i].desitem;

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(seccion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD),-1, 1, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(descripcion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.CompleteRow();
                            detalledeuno = 0;
                        }

                        #endregion

                        #region Detalle

                        if (oListaEEFFDETALLADO[i].TipoTabla == "DET" )
                        {

                            if (detalledeuno == 0)
                            {
                                seccion = oListaEEFFDETALLADO[i].secitem;
                                descripcion = oListaEEFFDETALLADO[i].desitem;

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(seccion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(descripcion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();
                            }

                            detalledeuno++;

                            #region Segunda Totalizacion

                            if (oListaEEFFDETALLADO[i].TipoTabla == tabla)
                            {

                                if (oListaEEFFDETALLADO[i].secitem != sec)
                                {

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.CompleteRow();


                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));

                                    if (subsubDeu > subsubAcree)
                                    {
                                        decimal total = subsubDeu - subsubAcree;
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    }

                                    if (subsubAcree == subsubDeu)
                                    {
                                        decimal total = subsubDeu - subsubAcree;
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    }

                                    if (subsubAcree > subsubDeu)
                                    {
                                        decimal total = subsubAcree - subsubDeu;
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    }

                                    TablaCabDetalle.CompleteRow();

                                    subTotDeu = subTotDeu + subsubDeu;
                                    subTotAcree = subTotAcree + subsubAcree;
                                    subsubDeu = 0;
                                    subsubAcree = 0;

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.CompleteRow();

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].secitem, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].desitem, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.CompleteRow();
                               
                                }
                            }

                            #endregion

                            sec = oListaEEFFDETALLADO[i].secitem;
                            tabla = oListaEEFFDETALLADO[i].TipoTabla;

                        }

                        #endregion

                        #region Detalle por Cuenta

                        if (oListaEEFFDETALLADO[i].CodPlaCta != null)
                        {
                            if (oListaEEFFDETALLADO[i].TipoTabla == "DET")
                            {

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].CodPlaCta + "  " + oListaEEFFDETALLADO[i].Descripcion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].Deudor.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].Acreedor.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();

                                subsubDeu += oListaEEFFDETALLADO[i].Deudor;
                                subsubAcree += oListaEEFFDETALLADO[i].Acreedor;

                            }
                        }

                        #endregion

                        #region Totales

                        if (oListaEEFFDETALLADO[i].TipoTabla == "TOT")
                        {
                            #region Total General por Activo o Pasivo
                            if (tabla == oListaEEFFDETALLADO[i].TipoTabla)
                            {

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));

                                if (total1 > total2)
                                {
                                    decimal total = total1 - total2;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                }

                                if (total2 > total1)
                                {
                                    decimal total = total2 - total1;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                }
                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();

                                ContadorTotal = ContadorTotal + 1;

                                if (ContadorTotal == 2 || ContadorTotal == 3)
                                {
                                    TotalPasPatrimonioDebe = TotalPasPatrimonioDebe + total1;
                                    TotalPasPatrimonioHaber = TotalPasPatrimonioHaber + total2;

                                   if (ContadorTotal == 3)
                                   {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL PASIVO Y PATRIMONIO ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));

                                        if (TotalPasPatrimonioDebe > TotalPasPatrimonioHaber)
                                        {
                                            decimal total = TotalPasPatrimonioDebe - TotalPasPatrimonioHaber;
                                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                        }

                                        if (TotalPasPatrimonioHaber > TotalPasPatrimonioDebe)
                                        {
                                            decimal total = TotalPasPatrimonioHaber - TotalPasPatrimonioDebe;
                                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                        }
                                        TablaCabDetalle.CompleteRow();

                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                        TablaCabDetalle.CompleteRow();

                                    }
                                }

                                total1 = 0;
                                total2 = 0;

                            }
                            #endregion

                            #region Totales Parciales
                            else
                            {
                                #region Primera Totalizacion

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));

                                if (subsubDeu > subsubAcree)
                                {
                                    decimal total = subsubDeu - subsubAcree;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                }

                                if (subsubAcree == subsubDeu)
                                {
                                    decimal total = subsubDeu - subsubAcree;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                }

                                if (subsubAcree > subsubDeu)
                                {
                                    decimal total = subsubAcree - subsubDeu;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                }
                                TablaCabDetalle.CompleteRow();

                                subTotDeu = subTotDeu + subsubDeu;
                                subTotAcree = subTotAcree + subsubAcree;

                                subsubAcree = 0;
                                subsubDeu   = 0;

                                #endregion

                                #region Segunda Totalizacion
                               
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();


                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradora, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradora, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].secitem, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].desitem, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));

                                if (subTotDeu > subTotAcree)
                                {
                                    decimal total = subTotDeu - subTotAcree;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                }

                                if (subTotAcree == subTotDeu)
                                {
                                    decimal total = subTotAcree - subTotDeu;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N")); ;
                                }

                                if (subTotAcree > subTotDeu)
                                {
                                    decimal total = subTotAcree - subTotDeu;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                }

                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradora, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradora, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();

                                total1 = total1 + subTotDeu;
                                total2 = total2 + subTotAcree;

                                subTotAcree = 0;
                                subTotDeu = 0;

                                #endregion

                                tabla = oListaEEFFDETALLADO[i].TipoTabla;
                              
                            }
                            #endregion 
                        }

                        #endregion

                        contador++;
                    }

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion

                }
                
                // Detalle para Reporte tipo EEPP
                if(TipoReporte == "R")
                {
                    PaginaInicioEEGGYPGDetallado ev = new PaginaInicioEEGGYPGDetallado();
                    ev.Anio = Convert.ToString(cboAño.SelectedValue);
                    ev.Mes = Convert.ToInt32(cboMes.SelectedValue);

                    String secciondescripcion = ((EEFFE)cboEEFF.SelectedItem).desSeccion;
                    ev.destit = secciondescripcion;
                    ev.rutaimagen = RutaImagen;
                    oPdfw.PageEvent = ev;

                #region Detalle

                    docPdf.Open();

                    PdfPTable TablaCabDetalle = new PdfPTable(6);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.5f, 0.1f, 0.1f, 0.1f, 0.1f });


                    // ==========================
                    // AGRUPAR DATOS
                    // ==========================

                    int contador = 0;
                    string seccion = "";
                    string descripcion = "";
                    string sec = "";
                    string tabla = "";
                    decimal subTotante = 0;
                    decimal subTotanteacum = 0;
                    decimal subTotactu = 0;
                    decimal subTotactuacum = 0;


                    decimal subsubDeu = 0;
                    decimal subsubAcree = 0;
                    decimal submesAnte = 0;
                    decimal subacumAnte = 0;

                    string LineaSepradoraig = "=============";
                    int detalledeuno = 0;
                    string LineaSepradora = "------------------------";
                    // ==========================

                    oListaEEFFDETALLADO = (from x in oListaEEFFDETALLADO where ((x.TipoTabla == "DET" && (x.Deudor != 0 || x.Acreedor != 0)) || x.TipoTabla == "TOT" || x.TipoTabla == "TIT") select x).ToList();


                    for (int i = 0; i < oListaEEFFDETALLADO.Count; i++)
                    {
                        // ====================================================
                        // PRIMERA LINEA - CARGAMOS DATOS
                        // ====================================================

                        if (oListaEEFFDETALLADO[i].TipoTabla == "TIT")
                        {
                            seccion = oListaEEFFDETALLADO[i].secitem;
                            descripcion = oListaEEFFDETALLADO[i].desitem;

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(seccion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(descripcion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            TablaCabDetalle.CompleteRow();
                            detalledeuno = 0;
                        }

                        if (oListaEEFFDETALLADO[i].TipoTabla == "DET")
                        {

                            if (detalledeuno == 0)
                            {

                                seccion = oListaEEFFDETALLADO[i].secitem;
                                descripcion = oListaEEFFDETALLADO[i].desitem;

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();

                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(seccion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(descripcion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();
                            }
                            detalledeuno++;


                            if (oListaEEFFDETALLADO[i].TipoTabla == tabla)
                            {

                                if (oListaEEFFDETALLADO[i].secitem != sec)
                                {

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.CompleteRow();


                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    decimal total1 = submesAnte;
                                    decimal total2 = subacumAnte;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    decimal total3 = subsubDeu;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total3.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    decimal total4 = subsubAcree;
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total4.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.CompleteRow();

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.CompleteRow();

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].secitem, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].desitem, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                    TablaCabDetalle.CompleteRow();

                                    subsubDeu = 0;
                                    subsubAcree = 0;
                                }
                            }

                            subsubDeu += oListaEEFFDETALLADO[i].MesAnterior;
                            subsubAcree += oListaEEFFDETALLADO[i].MesAnteriorAcumulado;
                            submesAnte += oListaEEFFDETALLADO[i].MesActual;
                            subacumAnte += oListaEEFFDETALLADO[i].MesActualAcumulado;

                            sec = oListaEEFFDETALLADO[i].secitem;
                            tabla = oListaEEFFDETALLADO[i].TipoTabla;

                        }


                        // ====================================================
                        // cambio de grupo
                        // ====================================================
                        if (oListaEEFFDETALLADO[i].CodPlaCta != null)
                        {
                            if (oListaEEFFDETALLADO[i].TipoTabla == "DET")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].CodPlaCta + "  " + oListaEEFFDETALLADO[i].Descripcion, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].MesAnterior.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].MesAnteriorAcumulado.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].MesActual.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].MesActualAcumulado.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.CompleteRow();
                            }
                        }


                        subTotante = subTotante + oListaEEFFDETALLADO[i].MesAnterior;
                        subTotanteacum = subTotanteacum + oListaEEFFDETALLADO[i].MesAnteriorAcumulado;
                        subTotactu = subTotactu + oListaEEFFDETALLADO[i].MesActual;
                        subTotactuacum = subTotactuacum + oListaEEFFDETALLADO[i].MesActualAcumulado;



                        if (oListaEEFFDETALLADO[i].TipoTabla == "TOT")
                        {

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradora, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradora, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradora, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradora, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.CompleteRow();

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].secitem, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 1, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(oListaEEFFDETALLADO[i].desitem, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            decimal total1 = subTotante;
                            decimal total2 = subTotanteacum;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            decimal total3 = subTotactu;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total3.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));                       
                            decimal total4 = subTotactuacum;
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(total4.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.CompleteRow();


                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(LineaSepradoraig, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            TablaCabDetalle.CompleteRow();

                        }

                        contador++;
                    }

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion

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
        }

        void ConvertirApdfResumen()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\eeffResumido " + Aleatorio.ToString();
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";
            Int32 idEEFF = Convert.ToInt32(cboEEFF.SelectedValue);
            if (idEEFF != 1)
            {
                docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            }

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

                RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                String TipoReporte = ((EEFFE)cboEEFF.SelectedItem).tipoReporte;

                if (TipoReporte == "B")
                {
                    PaginaInicioEEFFdetallado2 ev = new PaginaInicioEEFFdetallado2();
                    ev.Anio = Convert.ToString(cboAño.SelectedValue);
                    ev.Mes = Convert.ToInt32(cboMes.SelectedValue);
                    String secciondescripcion = ((EEFFE)cboEEFF.SelectedItem).desSeccion;
                    ev.destit = secciondescripcion;

                    ev.rutaimagen = RutaImagen;
                    oPdfw.PageEvent = ev;
                }
                else if (TipoReporte == "R")
                {
                    PaginaInicioEEGGYPG2 ev = new PaginaInicioEEGGYPG2();
                    ev.Anio = Convert.ToString(cboAño.SelectedValue);
                    ev.Mes = Convert.ToInt32(cboMes.SelectedValue);

                    String secciondescripcion = ((EEFFE)cboEEFF.SelectedItem).desSeccion;
                    ev.destit = secciondescripcion;
                    ev.rutaimagen = RutaImagen;
                    oPdfw.PageEvent = ev;

                }



                docPdf.Open();

                #region Detalle




                // ==========================
                // AGRUPAR DATOS
                // ==========================

                // ==========================

                #region pdf (sinterminar)
                //foreach (EEFFE item in oListaEEFFDETALLADO)
                //{

                //    if (item.CodPlaCta == "")
                //    {
                //        if (item.TipoTabla == "TIT")
                //        {
                //      
                //        }
                //    }               

                //        if (item.TipoTabla == "DET")
                //        {

                //            if (item.Deudor > item.Acreedor)
                //            {
                //                totalacumulado += item.Deudor - item.Acreedor;
                //            }

                //            if (item.Acreedor == item.Deudor)
                //            {
                //                totaldentico = totalacumulado;
                //            }


                //            if (item.Acreedor > item.Deudor)
                //            {
                //                totalacumulado += item.Deudor  - item.Acreedor;
                //            }
                //        }





                //    if (item.CodPlaCta != "")
                //    {
                //            if (item.TipoTabla == "DET")
                //            {
                //                if (registroacum.desitem !=  item.desitem)
                //                {

                //                   if (registroacum.desitem != null)
                //                  {
                //                    cell = CellPdf(registroacum.desitem, 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                //                    cell = CellPdf(totalacumulado.ToString("N2"), 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                //                    TablaCabDetalle.CompleteRow();
                //                    registroacum.desitem = null;
                //                   }
                //                }
                //            }
                //    }
                //    if (item.TipoTabla == "DET")
                //    {
                //        registroacum.desitem = item.desitem;

                //    }

                //    if (totaldentico != totalacumulado)
                //    {
                //        totaltodos += totalacumulado;

                //    }

                //    //totalacumulado = 0;

                //    if (item.TipoTabla == "TOT")
                //    {
                //        cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        TablaCabDetalle.CompleteRow();
                //        cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        TablaCabDetalle.CompleteRow();

                //        cell = CellPdf(item.desitem, 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        cell = CellPdf(totaltodos.ToString("N2"), 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        TablaCabDetalle.CompleteRow();
                //        cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        TablaCabDetalle.CompleteRow();
                //        cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //        TablaCabDetalle.CompleteRow();
                //        totalacumulado = 0;
                //    }



                //    if (item.TipoTabla == repetidotot)
                //    {
                //        if (item.TipoTabla == "TOT")
                //        {

                //            cell = CellPdf(" ", 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                //            cell = CellPdf(" ", 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                //            TablaCabDetalle.CompleteRow();

                //            cell = CellPdf(" ", 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                //            cell = CellPdf(" ", 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                //            TablaCabDetalle.CompleteRow();

                //            cell = CellPdf(item.desitem, 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //            totalgeneral += totaltodos;
                //            cell = CellPdf(totalgeneral.ToString("N2"), 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //            TablaCabDetalle.CompleteRow();


                //            cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //            cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                //            TablaCabDetalle.CompleteRow();
                //        }
                //    }

                //    repetidotot = item.TipoTabla;

                //}


                #endregion

                #region Resumido Balance General

               

                if (idEEFF == 1)
                {

                    List<EEFFELIST> Lista3 = new List<EEFFELIST>();
                    EEFFE TotActivo = (from x in oListaEEFFDETALLADO where x.Columna == 1 && x.desitem == "TOTAL ACTIVO CORRIENTE" select x).SingleOrDefault();
                    EEFFE TotPasivo = (from x in oListaEEFFDETALLADO where x.Columna == 2 && x.desitem == "TOTAL PASIVO CORRIENTE" select x).SingleOrDefault();
                    EEFFE TotActFijo = (from x in oListaEEFFDETALLADO where x.Columna == 1 && x.desitem == "TOTAL ACTIVO FIJO NETO" select x).SingleOrDefault();
                    EEFFE TotPatrimonio = (from x in oListaEEFFDETALLADO where x.Columna == 2 && x.desitem == "TOTAL PATRIMONIO" select x).SingleOrDefault();

                    if (TotActivo == null)
                    {
                        EEFFE ItemActivo = new EEFFE();
                        ItemActivo.Descripcion = "A";
                        ItemActivo.secitem = "0000";
                        TotActivo = ItemActivo;
                    }

                    if (TotPasivo == null)
                    {
                        EEFFE ItemPasivo = new EEFFE();
                        ItemPasivo.Descripcion = "A";
                        ItemPasivo.secitem = "0000";
                        TotPasivo = ItemPasivo;
                    }

                    if (TotActFijo == null)
                    {
                        EEFFE ItemActFijo = new EEFFE();
                        ItemActFijo.Descripcion = "A";
                        ItemActFijo.secitem = "0000";
                        TotActFijo = ItemActFijo;
                    }

                    if (TotPatrimonio == null)
                    {
                        EEFFE ItemPatrimonio = new EEFFE();
                        ItemPatrimonio.Descripcion = "A";
                        ItemPatrimonio.secitem = "0000";
                        TotPatrimonio = ItemPatrimonio;
                    }


                    List<EEFFE> Lista1 = new List<EEFFE>(from x in oListaEEFFDETALLADO where x.Columna == 1 && Convert.ToInt32(x.secitem) < Convert.ToInt32(TotActivo.secitem) select x).ToList();
                    List<EEFFE> Lista2 = new List<EEFFE>(from x in oListaEEFFDETALLADO where x.Columna == 2 && Convert.ToInt32(x.secitem) < Convert.ToInt32(TotPasivo.secitem) select x).ToList();

                    Int32 L1 = Lista1.Count();
                    Int32 L2 = Lista2.Count();

                    for (int i = Lista1.Count(); i <= L1; i++)
                    {
                        EEFFE NuevoItem = new EEFFE();
                        NuevoItem.Descripcion = "A";
                        Lista2.Add(NuevoItem);
                    }

                    for (int i = Lista2.Count(); i <= L2; i++)
                    {
                        EEFFE NuevoItem = new EEFFE();
                        NuevoItem.Descripcion = "B";
                        Lista1.Add(NuevoItem);
                    }


                    foreach (EEFFE item in oListaEEFFDETALLADO)
                    {
                        if (item.Columna == 1 && Convert.ToInt32(item.secitem) >= Convert.ToInt32(TotActivo.secitem) && Convert.ToInt32(item.secitem) < Convert.ToInt32(TotActFijo.secitem))
                        {
                            Lista1.Add(item);
                        }
                        if (item.Columna == 2 && Convert.ToInt32(item.secitem) >= Convert.ToInt32(TotPasivo.secitem) && Convert.ToInt32(item.secitem) < Convert.ToInt32(TotPatrimonio.secitem))
                        {
                            Lista2.Add(item);
                        }
                    }

                    L1 = Lista1.Count();
                    L2 = Lista2.Count();

                    for (int i = Lista1.Count(); i < L2; i++)
                    {
                        EEFFE NuevoItem = new EEFFE();
                        NuevoItem.TipoTabla = "DET";
                        NuevoItem.Descripcion = "A";
                        Lista1.Add(NuevoItem);
                    }

                    for (int i = Lista2.Count(); i < L1; i++)
                    {
                        EEFFE NuevoItem = new EEFFE();
                        NuevoItem.TipoTabla = "DET";
                        NuevoItem.Descripcion = "B";
                        Lista2.Add(NuevoItem);
                    }

                    foreach (EEFFE item in oListaEEFFDETALLADO)
                    {
                        if (item.Columna == 1 && Convert.ToInt32(item.secitem) >= Convert.ToInt32(TotActFijo.secitem))
                        {
                            Lista1.Add(item);
                        }
                        if (item.Columna == 2 && Convert.ToInt32(item.secitem) >= Convert.ToInt32(TotPatrimonio.secitem))
                        {
                            Lista2.Add(item);
                        }
                    }



                    foreach (EEFFE item in Lista1)
                    {
                        EEFFELIST nueva = new EEFFELIST();

                        nueva.TipoTabla1 = item.TipoTabla;
                        nueva.Acreedor1 = item.Acreedor;
                        nueva.Columna1 = item.Columna;
                        nueva.Deudor1 = item.Deudor;
                        nueva.descripcion1 = item.desitem;
                        Lista3.Add(nueva);
                    }


                    Int32 Contador = -1;

                    foreach (EEFFE item in Lista2)
                    {
                        Contador++;

                        EEFFELIST nueva = new EEFFELIST();

                        if (Contador < Lista1.Count)
                        {
                            Lista3[Contador].TipoTabla2 = item.TipoTabla;
                            Lista3[Contador].descripcion2 = item.desitem;
                            Lista3[Contador].Columna2 = item.Columna;
                            Lista3[Contador].Deudor2 = item.Deudor;
                            Lista3[Contador].Acreedor2 = item.Acreedor;
                        }
                        else
                        {
                            nueva.TipoTabla2 = item.TipoTabla;
                            nueva.descripcion2 = item.Descripcion;
                            nueva.Columna2 = item.Columna;
                            nueva.Deudor2 = item.Deudor;
                            nueva.Acreedor2 = item.Acreedor;
                            Lista3.Add(nueva);
                        }
                    }

                    //Nueva instancia
                    PdfPTable oTablaDetalle = new PdfPTable(2);
                    oTablaDetalle.WidthPercentage = 100;
                    oTablaDetalle.SetWidths(new float[] { 0.5f, 0.5f });
                    PdfPCell cell = null;
                    //Nuevas celdas
                    PdfPCell Celda1 = new PdfPCell() { Border = 0 };
                    PdfPCell Celda2 = new PdfPCell() { Border = 0 };
                    String Alineado = String.Empty;
                    Int32 filastotales1 = 0;
                    Int32 filastotales2 = 0;
                    Int32 FilaTotal = 0;
                    Int32 numindicafindet = 0;

                    foreach (EEFFE item in oListaEEFFDETALLADO)
                    {
                        if (item.TipoTabla == "DET")
                        {
                            
                            if (numindicafindet != 1)
                            {
                                if (item.Columna == 1)
                                {
                                    filastotales1++;
                                }
                                else
                                {
                                    filastotales2++;
                                }
                            }
                        }
                        if (item.TipoTabla == "TOT")
                        {
                            numindicafindet = 1;
                        }
                    }

                    if (filastotales1 >= filastotales2)
                    {
                        FilaTotal = filastotales1;
                    }
                    else if(filastotales2 >= filastotales1)
                    {
                        FilaTotal = filastotales2;
                    }
                    

                    //Añadiendo elementos tipo Pdf Table a las celdas
                    Celda1.AddElement(PrintVertical(Lista3, 1, FilaTotal)); //Activo
                    Celda2.AddElement(PrintVertical(Lista3, 2, FilaTotal)); //Pasivo




                    //Añadiendo a la tabla detalle las celdas creadas...
                    oTablaDetalle.AddCell(Celda1);
                    oTablaDetalle.AddCell(Celda2);

                    oTablaDetalle.CompleteRow();

                    PdfPTable TablaCabDetalle = new PdfPTable(4);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.35f, 0.15f, 0.35f, 0.15f });

                    for (int i = 0; i < Lista3.Count; i++)
                    {
                        Int32 rere = Lista3.Count;
                        rere--;
                        if (i == rere)
                        {
                            if (Lista3[i].descripcion1 != null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("____________________", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            }
                            if (Lista3[i].descripcion2 != null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("____________________", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            }
                            TablaCabDetalle.CompleteRow();


                            if (Lista3[i].descripcion1 != null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Lista3[i].descripcion1, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                if (Lista3[i].Deudor1 > Lista3[i].Acreedor1)
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Lista3[i].Deudor1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                }
                                else
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Lista3[i].Acreedor1.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                }
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            }
                            if (Lista3[i].descripcion2 != null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Lista3[i].descripcion2, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                if (Lista3[i].Deudor2 > Lista3[i].Acreedor2)
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Lista3[i].Deudor2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                }
                                else
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Lista3[i].Acreedor2.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                }
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            }
                            TablaCabDetalle.CompleteRow();


                            if (Lista3[i].descripcion1 != null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("===================", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, 2, "N", "N"));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N"));
                            }
                            if (Lista3[i].descripcion2 != null)
                            {
                                cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                                cell = CellPdf("===================", 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                            }
                            else
                            {
                                cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                                cell = CellPdf(" ", 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                            }
                            TablaCabDetalle.CompleteRow();
                        }
                    }


                    docPdf.Add(oTablaDetalle); //Añadiendo la tabla al documento PDF

                    docPdf.Add(TablaCabDetalle);
                }


                #endregion

                #region Reporte Resumen Funcion y Naturaleza

                if (idEEFF == 3 || idEEFF == 4)
                {

                    String nombremes = FechasHelper.NombreMes(Convert.ToInt32(cboMes.SelectedValue));
                    String anio = Convert.ToString(cboAño.SelectedValue);
                    Decimal Acreedor = 0;
                    Decimal Deudor = 0;
                    Decimal totalmes = 0;
                    Decimal TotaltotMes = 0;
                    String Tipotabla = "";
                    String TipoResTotal = "";

                    PdfPTable TablaCabDetalle = new PdfPTable(3);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.25f, 0.15f, 0.15f });
                    PdfPCell cell = null;

                    cell = new PdfPCell(new Paragraph("Descripcion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(nombremes+ " - " +anio, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) {  HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("PORCENTAJE", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) {  HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    for (int i = 0; i < oListaEEFFDETALLADO.Count; i++)
                    {
                                

                        if (oListaEEFFDETALLADO[i].TipoTabla == "DET")
                        {
                            cell = new PdfPCell(new Paragraph(oListaEEFFDETALLADO[i].desitem, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);
                            if (oListaEEFFDETALLADO[i].Deudor > oListaEEFFDETALLADO[i].Acreedor)
                            {
                                cell = new PdfPCell(new Paragraph(oListaEEFFDETALLADO[i].Deudor.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("100%", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                Deudor += oListaEEFFDETALLADO[i].Deudor;
                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph( "("+oListaEEFFDETALLADO[i].Acreedor.ToString("N2") + ")", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("100%", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                Acreedor += oListaEEFFDETALLADO[i].Acreedor;
                            }                   
                            TablaCabDetalle.CompleteRow();
                            Tipotabla = oListaEEFFDETALLADO[i].TipoTabla;
                        }

                        if (oListaEEFFDETALLADO[i].TipoTabla == "TOT")
                        {
                            if (Tipotabla == oListaEEFFDETALLADO[i].TipoTabla)
                            {
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("____________________", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("____________________", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                cell = new PdfPCell(new Paragraph(oListaEEFFDETALLADO[i].desitem, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                if (TipoResTotal == "NEG")
                                {
                                    cell = new PdfPCell(new Paragraph("( " +Math.Abs(TotaltotMes).ToString("N2")+ " )", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                    TablaCabDetalle.AddCell(cell);
                                }
                                else
                                {
                                    cell = new PdfPCell(new Paragraph(TotaltotMes.ToString("N2"), FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                    TablaCabDetalle.AddCell(cell);
                                }                               

                                cell = new PdfPCell(new Paragraph("100 % ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                TotaltotMes = 0;


                            }
                            else
                            {

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("____________________", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("____________________", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();


                                cell = new PdfPCell(new Paragraph(oListaEEFFDETALLADO[i].desitem, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                if (Deudor > Acreedor)
                                {
                                    totalmes = Deudor - Acreedor;
                                    cell = new PdfPCell(new Paragraph(totalmes.ToString("N2"), FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                    TablaCabDetalle.AddCell(cell);
                                    TotaltotMes += totalmes;
                                    TipoResTotal = "POS";
                                }
                                else
                                {
                                    totalmes = Acreedor - Deudor;
                                    cell = new PdfPCell(new Paragraph("( " + totalmes.ToString("N2") + " )", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                    TablaCabDetalle.AddCell(cell);
                                    TotaltotMes -= totalmes;
                                    TipoResTotal = "NEG";
                                }                                
                                totalmes = 0;
                                Acreedor = 0;
                                Deudor = 0;

                                cell = new PdfPCell(new Paragraph("100 % ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                              
                            }

                            Tipotabla = oListaEEFFDETALLADO[i].TipoTabla;
                        }            

                    }

                    docPdf.Add(TablaCabDetalle);
                }

                #endregion

                #endregion

                // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                //establecer la acción abierta para nuestro objeto escritor
                oPdfw.SetOpenAction(action);

                //Liberando memoria
                oPdfw.Flush();
                docPdf.Close();
                fsNuevoArchivo.Close();
                wbNavegador.Navigate(RutaGeneral);
            }
        }

        PdfPTable PrintVertical(List<EEFFELIST> oConcepto, Int32 Grupo, Int32 Filas)
        {
            PdfPTable tDetalle = new PdfPTable(2);
            PdfPCell cell = null;
            Int32 ultnoconta = 0;
            tDetalle.WidthPercentage = 100;
            tDetalle.SetWidths(new float[] { 0.75f, 0.25f });
            tDetalle.AddCell(ReaderHelper.NuevaCelda((""), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            tDetalle.CompleteRow();
            if (Grupo == 1) //-- "ACTIVO"
            {
                if (oConcepto != null && oConcepto.Count > 0)
                {
                    for (int i = 0; i < oConcepto.Count; i++)
                    {
                        ultnoconta = oConcepto.Count;
                        ultnoconta--;
                        if (i != ultnoconta)
                        {

                            if (oConcepto[i].TipoTabla1 == "TIT")
                            {
                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                tDetalle.CompleteRow();

                                cell = CellPdf(oConcepto[i].descripcion1, 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                tDetalle.CompleteRow();
                            }



                            if (oConcepto[i].TipoTabla1 == "DET")
                            {
                                cell = CellPdf(oConcepto[i].descripcion1, 0, 0, "l", ""); tDetalle.AddCell(cell);
                                if (oConcepto[i].Deudor1 > oConcepto[i].Acreedor1)
                                {
                                    cell = CellPdf(oConcepto[i].Deudor1.ToString("N2"), 0, 0, "r", ""); tDetalle.AddCell(cell);
                                }
                                else
                                {
                                    cell = CellPdf("(" + oConcepto[i].Acreedor1.ToString("N2") + ")", 0, 0, "r", ""); tDetalle.AddCell(cell);
                                }
                                tDetalle.CompleteRow();
                                Filas--;
                            }

                            if (oConcepto[i].TipoTabla1 == "TOT")
                            {
                                if (Filas > 0)
                                {
                                    for (int s = 0; s < Filas; s++)
                                    {
                                        cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                        cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                        tDetalle.CompleteRow();                                        
                                    }
                                    Filas = 0;
                                }                              
                            }

                            if (oConcepto[i].TipoTabla1 == "TOT")
                            {

                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                cell = CellPdf("____________________", 0, 0, "r", "bold"); tDetalle.AddCell(cell);
                                tDetalle.CompleteRow();


                                cell = CellPdf(oConcepto[i].descripcion1, 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                if (oConcepto[i].Deudor1 > oConcepto[i].Acreedor1)
                                {
                                    cell = CellPdf(oConcepto[i].Deudor1.ToString("N2"), 0, 0, "r", "bold"); tDetalle.AddCell(cell);
                                }
                                else
                                {
                                    cell = CellPdf(oConcepto[i].Acreedor1.ToString("N2"), 0, 0, "r", "bold"); tDetalle.AddCell(cell);
                                }

                                tDetalle.CompleteRow();


                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                cell = CellPdf("____________________", 0, 0, "r", "bold"); tDetalle.AddCell(cell);
                                tDetalle.CompleteRow();
                            }
                        }
                    }
                
                }
            }

            if (Grupo == 2) //-- "PASIVO"
            {

                if (oConcepto != null && oConcepto.Count > 0)
                {
                    for (int i = 0; i < oConcepto.Count; i++)
                    {

                        ultnoconta = oConcepto.Count;
                        ultnoconta--;
                        if (i != ultnoconta)
                        {

                            if (oConcepto[i].TipoTabla2 == "TIT")
                            {
                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                tDetalle.CompleteRow();

                                cell = CellPdf(oConcepto[i].descripcion2, 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                tDetalle.CompleteRow();

                            }

                            if (oConcepto[i].TipoTabla2 == "DET")
                            {
                                cell = CellPdf(oConcepto[i].descripcion2, 0, 0, "l", ""); tDetalle.AddCell(cell);
                                if (oConcepto[i].Deudor2 > oConcepto[i].Acreedor2)
                                {
                                    cell = CellPdf(oConcepto[i].Deudor2.ToString("N2"), 0, 0, "r", ""); tDetalle.AddCell(cell);
                                }
                                else
                                {
                                    cell = CellPdf("(" + oConcepto[i].Acreedor2.ToString("N2") + ")", 0, 0, "r", ""); tDetalle.AddCell(cell);
                                }
                                tDetalle.CompleteRow();
                                Filas--;
                            }

                            if (oConcepto[i].TipoTabla2 == "TOT")
                            {
                                if (Filas > 0)
                                {
                                    for (int s = 0; s < Filas; s++)
                                    {
                                        cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                        cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                        tDetalle.CompleteRow();
                                    }
                                    Filas = 0;
                                }
                            }

                            if (oConcepto[i].TipoTabla2 == "TOT")
                            {

                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                cell = CellPdf("____________________", 0, 0, "r", "bold"); tDetalle.AddCell(cell);
                                tDetalle.CompleteRow();


                                cell = CellPdf(oConcepto[i].descripcion2, 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                if (oConcepto[i].Deudor2 > oConcepto[i].Acreedor2)
                                {
                                    cell = CellPdf(oConcepto[i].Deudor2.ToString("N2"), 0, 0, "r", "bold"); tDetalle.AddCell(cell);
                                }
                                else
                                {
                                    cell = CellPdf(oConcepto[i].Acreedor2.ToString("N2"), 0, 0, "r", "bold"); tDetalle.AddCell(cell);
                                }

                                tDetalle.CompleteRow();


                                cell = CellPdf(" ", 0, 0, "l", "bold"); tDetalle.AddCell(cell);
                                cell = CellPdf("____________________", 0, 0, "r", "bold"); tDetalle.AddCell(cell);
                                tDetalle.CompleteRow();
                            }
                        }

                    }
                }
            }
        

            return tDetalle;
        }

        PdfPCell CellPdf(string titulo, int size, int border, string align, string bold)
        {
            if (border < 0)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 7f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 7f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { Border = border, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        #endregion

        #region Exportar Excel

        public override void Exportar()
        {
            try
            {
                if (oListaEEFFDETALLADO == null || oListaEEFFDETALLADO.Count == Variables.Cero)
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

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Estados Financieros Detallado " + NombreLocal + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    lblProcesando.Visible = true;
                    btDetallado.Enabled = true;
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



            TituloGeneral = " Estados Financieros Detallado " + " Al Año " + Anio + " Del Mes " + nombreMes;
            NombrePestaña = " Estados Financieros Detallado ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
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

                    String TipoReporte = ((EEFFE)cboEEFF.SelectedItem).tipoReporte;

                    Int32 idEEFF = Convert.ToInt32(cboEEFF.SelectedValue);                 

                    if (TipoReporte == "B")
                    {
                        if (idEEFF == 3 || idEEFF == 4)
                        {
                            TotColumnas = 3;
                            //Segunda
                            oHoja.Cells[InicioLinea, 1].Value = " DESCRIPCIÓN ";
                            oHoja.Cells[InicioLinea, 2].Value = " MES ";
                            oHoja.Cells[InicioLinea, 3].Value = " TOTAL ";


                            for (int i = 1; i <= 3; i++)
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
                        }

                        if (idEEFF == 1)
                        {
                            // PRIMERA
                            oHoja.Cells[InicioLinea, 1].Value = " ";
                            oHoja.Cells[InicioLinea, 2].Value = " ";
                            oHoja.Cells[InicioLinea, 3].Value = " ***** SALDO ACTUAL ***** ";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 4])
                            {
                                Rango.Merge = true;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                            }


                            for (int i = 1; i <= 4; i++)
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
                            oHoja.Cells[InicioLinea, 2].Value = " Descripcion ";
                            oHoja.Cells[InicioLinea, 3].Value = " Deudor ";
                            oHoja.Cells[InicioLinea, 4].Value = " Acreedor ";


                            for (int i = 1; i <= 4; i++)
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
                        }                      
                    }

                    if (TipoReporte == "R")
                    {
                        TotColumnas = 6;
                        //Segunda
                        oHoja.Cells[InicioLinea, 1].Value = " Cuenta ";
                        oHoja.Cells[InicioLinea, 2].Value = " Descripcion ";
                        oHoja.Cells[InicioLinea, 3].Value = " Mes Anterior ";
                        oHoja.Cells[InicioLinea, 4].Value = " Acum. Anterior ";
                        oHoja.Cells[InicioLinea, 5].Value = " Deudor ";
                        oHoja.Cells[InicioLinea, 6].Value = " Acreedor ";


                        for (int i = 1; i <= 6; i++)
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

                    }

                    #endregion

                    #region Detalles

                    if (TipoReporte == "B")
                    {
                        #region Detalle Naturaleza o Funcion

                        if (idEEFF == 3 || idEEFF == 4)
                        {                                                     
                            foreach (EEFFE item in oListaEEFFDETALLADO)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.desitem;
                                oHoja.Cells[InicioLinea, 2].Value = item.Deudor;
                                oHoja.Cells[InicioLinea, 3].Value = item.Acreedor;
                                oHoja.Cells[InicioLinea, 2, InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                InicioLinea++;
                            }                          
                        }

                        #endregion

                        #region Balance General

                        if (idEEFF == 1)
                        {

                            #region Detallado

                            int contador = 0;
                            string seccion = "";
                            string descripcion = "";
                            string tabla = "";
                            decimal subTotDeu = 0;
                            decimal subTotAcree = 0;
                            int detalledeuno = 0;
                            string sec = "";
                            decimal subsubDeu = 0;
                            decimal subsubAcree = 0;
                            decimal total1 = 0;
                            decimal total2 = 0;
                            decimal TotalPasPatrimonioDebe = 0;
                            decimal TotalPasPatrimonioHaber = 0;
                            int ContadorTotal = 0;

                            foreach (EEFFE item in oListaEEFFDETALLADO)
                            {                    

                                #region Primera Linea Impresion de Titulos 

                                if (item.TipoTabla == "TIT")
                                {
                                    seccion = item.secitem;
                                    descripcion = item.desitem;

                                    oHoja.Cells[InicioLinea, 1].Value = seccion;
                                    oHoja.Cells[InicioLinea, 2].Value = descripcion;
                                    oHoja.Cells[InicioLinea, 3].Value = "";
                                    oHoja.Cells[InicioLinea, 4].Value = "";

                                    for (int i = 1; i <= 2; i++)
                                    {
                                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    }

                                    InicioLinea++;
                                    detalledeuno = 0;
                                }

                                #endregion                                                                

                                #region Detalle

                                if (item.TipoTabla == "DET")
                                {
                                    if (detalledeuno == 0)
                                    {
                                        seccion = item.secitem;
                                        descripcion = item.desitem;

                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";
                                        oHoja.Cells[InicioLinea, 3].Value = " ";
                                        oHoja.Cells[InicioLinea, 4].Value = " ";

                                        InicioLinea++;

                                        oHoja.Cells[InicioLinea, 1].Value = seccion;
                                        oHoja.Cells[InicioLinea, 2].Value = descripcion;
                                        oHoja.Cells[InicioLinea, 3].Value = " ";
                                        oHoja.Cells[InicioLinea, 4].Value = " ";

                                        InicioLinea++;
                                    }
                                    detalledeuno++;

                                    #region Segunda Totalizacion

                                    if (item.TipoTabla == tabla)
                                    {
                                        if (item.secitem != sec)
                                        {

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = " ";
                                            oHoja.Cells[InicioLinea, 4].Value = " ";
                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            if (subsubDeu > subsubAcree)
                                            {
                                                decimal total = subsubDeu - subsubAcree;
                                                oHoja.Cells[InicioLinea, 3].Value = total;
                                                oHoja.Cells[InicioLinea, 4].Value = " ";
                                                oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                            }

                                            if (subsubAcree == subsubDeu)
                                            {
                                                decimal total = subsubDeu - subsubAcree;
                                                oHoja.Cells[InicioLinea, 3].Value = total;
                                                oHoja.Cells[InicioLinea, 4].Value = total;
                                                oHoja.Cells[InicioLinea, 3, InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                            }

                                            if (subsubAcree > subsubDeu)
                                            {
                                                decimal total = subsubAcree - subsubDeu;
                                                oHoja.Cells[InicioLinea, 3].Value = " ";
                                                oHoja.Cells[InicioLinea, 4].Value = total;
                                                oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                            }

                                            subTotDeu = subTotDeu + subsubDeu;
                                            subTotAcree = subTotAcree + subsubAcree;
                                            subsubDeu = 0;
                                            subsubAcree = 0;

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = " ";
                                            oHoja.Cells[InicioLinea, 4].Value = " ";

                                            InicioLinea++;

                                            oHoja.Cells[InicioLinea, 1].Value = item.secitem;
                                            oHoja.Cells[InicioLinea, 2].Value = item.desitem;
                                            oHoja.Cells[InicioLinea, 3].Value = " ";
                                            oHoja.Cells[InicioLinea, 4].Value = " ";

                                            InicioLinea++;
                                        }
                                    }

                                    sec = item.secitem;
                                    tabla = item.TipoTabla;

                                    #endregion
                                }

                                #endregion

                                #region Detalle por Cuenta

                                if (item.CodPlaCta != null)
                                {
                                    if (item.TipoTabla == "DET")
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = item.CodPlaCta + "  " + item.Descripcion;
                                        oHoja.Cells[InicioLinea, 3].Value = item.Deudor;
                                        oHoja.Cells[InicioLinea, 4].Value = item.Acreedor;
                                        oHoja.Cells[InicioLinea, 3, InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                        InicioLinea++;

                                        subsubDeu += item.Deudor;
                                        subsubAcree += item.Acreedor;
                                    }
                                }

                                #endregion

                                #region Totales

                                if (item.TipoTabla == "TOT")
                                {
                                    #region Total General por Activo o Pasivo
                                    if (tabla == item.TipoTabla)
                                    {


                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";
                                        oHoja.Cells[InicioLinea, 3].Value = " ";
                                        oHoja.Cells[InicioLinea, 4].Value = " ";
                                        InicioLinea++;


                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";

                                        if (total1 > total2)
                                        {
                                            decimal total = total1 - total2;
                                            oHoja.Cells[InicioLinea, 3].Value = total;
                                            oHoja.Cells[InicioLinea, 4].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                        }

                                        if (total2 > total1)
                                        {
                                            decimal total = total2 - total1;
                                            oHoja.Cells[InicioLinea, 3].Value = " ";
                                            oHoja.Cells[InicioLinea, 4].Value = total;
                                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                        }                                  
                                        InicioLinea++;


                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";
                                        oHoja.Cells[InicioLinea, 3].Value = " ";
                                        oHoja.Cells[InicioLinea, 4].Value = " ";
                                        InicioLinea++;

                                        ContadorTotal = ContadorTotal + 1;

                                        if (ContadorTotal == 2 || ContadorTotal == 3)
                                        {
                                            TotalPasPatrimonioDebe = TotalPasPatrimonioDebe + total1;
                                            TotalPasPatrimonioHaber = TotalPasPatrimonioHaber + total2;

                                            if (ContadorTotal == 3)
                                            {
                                                oHoja.Cells[InicioLinea, 1].Value = " ";
                                                oHoja.Cells[InicioLinea, 2].Value = "TOTAL PASIVO Y PATRIMONIO";
                                         

                                                if (TotalPasPatrimonioDebe > TotalPasPatrimonioHaber)
                                                {
                                                    decimal total = TotalPasPatrimonioDebe - TotalPasPatrimonioHaber;
                                                    oHoja.Cells[InicioLinea, 3].Value = total;
                                                    oHoja.Cells[InicioLinea, 4].Value = " ";
                                                    oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                                }

                                                if (TotalPasPatrimonioHaber > TotalPasPatrimonioDebe)
                                                {
                                                    decimal total = TotalPasPatrimonioHaber - TotalPasPatrimonioDebe;
                                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                                    oHoja.Cells[InicioLinea, 4].Value = total;
                                                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                                }                                              
                                                InicioLinea++;

                                                oHoja.Cells[InicioLinea, 1].Value = " ";
                                                oHoja.Cells[InicioLinea, 2].Value = " ";
                                                oHoja.Cells[InicioLinea, 3].Value = " ";
                                                oHoja.Cells[InicioLinea, 4].Value = " ";
                                                InicioLinea++;

                                            }
                                        }

                                        total1 = 0;
                                        total2 = 0;

                                    }
                                    #endregion

                                    #region Totales Parciales
                                    else
                                    {
                                        #region Primera Totalizacion

                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";
                                        oHoja.Cells[InicioLinea, 3].Value = " ";
                                        oHoja.Cells[InicioLinea, 4].Value = " ";
                                        InicioLinea++;


                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";

                                        if (subsubDeu > subsubAcree)
                                        {
                                            decimal total = subsubDeu - subsubAcree;
                                            oHoja.Cells[InicioLinea, 3].Value = total;
                                            oHoja.Cells[InicioLinea, 4].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                                        }

                                        if (subsubAcree == subsubDeu)
                                        {
                                            decimal total = subsubDeu - subsubAcree;
                                            oHoja.Cells[InicioLinea, 3].Value = total;
                                            oHoja.Cells[InicioLinea, 4].Value = total;
                                            oHoja.Cells[InicioLinea, 3, InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                        }

                                        if (subsubAcree > subsubDeu)
                                        {
                                            decimal total = subsubAcree - subsubDeu;
                                            oHoja.Cells[InicioLinea, 3].Value = " ";
                                            oHoja.Cells[InicioLinea, 4].Value = total;
                                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                        }
                                        InicioLinea++;

                                        subTotDeu = subTotDeu + subsubDeu;
                                        subTotAcree = subTotAcree + subsubAcree;

                                        subsubAcree = 0;
                                        subsubDeu = 0;

                                        #endregion

                                        #region Segunda Totalizacion


                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";
                                        oHoja.Cells[InicioLinea, 3].Value = " ";
                                        oHoja.Cells[InicioLinea, 4].Value = " ";
                                        InicioLinea++;


                                        oHoja.Cells[InicioLinea, 1].Value = item.secitem;
                                        oHoja.Cells[InicioLinea, 2].Value = item.desitem;
    
                                        if (subTotDeu > subTotAcree)
                                        {
                                            decimal total = subTotDeu - subTotAcree;
                                            oHoja.Cells[InicioLinea, 3].Value = total;
                                            oHoja.Cells[InicioLinea, 4].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                                        }

                                        if (subTotAcree == subTotDeu)
                                        {
                                            decimal total = subTotAcree - subTotDeu;
                                            oHoja.Cells[InicioLinea, 3].Value = total;
                                            oHoja.Cells[InicioLinea, 4].Value = total;
                                            oHoja.Cells[InicioLinea, 3, InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                        }

                                        if (subTotAcree > subTotDeu)
                                        {
                                            decimal total = subTotAcree - subTotDeu;
                                            oHoja.Cells[InicioLinea, 3].Value = " ";
                                            oHoja.Cells[InicioLinea, 4].Value = total;
                                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                        }

                                        InicioLinea++;

                                        total1 = total1 + subTotDeu;
                                        total2 = total2 + subTotAcree;

                                        subTotAcree = 0;
                                        subTotDeu = 0;

                                        #endregion

                                        tabla = item.TipoTabla;

                                    }
                                    #endregion
                                }

                                #endregion                                

                                contador++;
                            }

                            #endregion

                        }

                        #endregion

                    }

                    if (TipoReporte == "R")
                    {

                        #region Detallado

                        int contador = 0;
                        string seccion = "";
                        string descripcion = "";

                        decimal subTotante = 0;
                        decimal subTotanteacum= 0;
                        decimal subTotmesante = 0;
                        decimal subTotAcumAnte = 0;
                        int detalledeuno = 0;


                        foreach (EEFFE item in oListaEEFFDETALLADO)
                        {

                            if (item.TipoTabla == "TIT")
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.secitem;
                                oHoja.Cells[InicioLinea, 2].Value = item.desitem;
                                oHoja.Cells[InicioLinea, 3].Value = "";
                                oHoja.Cells[InicioLinea, 4].Value = "";

                                for (int i = 1; i <= 2; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                }

                                InicioLinea++;
                                detalledeuno = 0;
                            }

                            if (item.TipoTabla == "DET")
                            {
                                if (detalledeuno == 0)
                                {
                                    seccion = item.secitem;
                                    descripcion = item.desitem;

                                    oHoja.Cells[InicioLinea, 1].Value = seccion;
                                    oHoja.Cells[InicioLinea, 2].Value = descripcion;
                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                    oHoja.Cells[InicioLinea, 4].Value = " ";


                                    // FORMAT 



                                    InicioLinea++;
                                }
                                detalledeuno++;
                            }


                    

                            if (item.CodPlaCta != null)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = " ";
                                oHoja.Cells[InicioLinea, 2].Value = " ";
                                oHoja.Cells[InicioLinea, 3].Value = " ";
                                oHoja.Cells[InicioLinea, 4].Value = " ";
                                oHoja.Cells[InicioLinea, 5].Value = " ";
                                oHoja.Cells[InicioLinea, 6].Value = " ";
                                InicioLinea++;

                                oHoja.Cells[InicioLinea, 1].Value = " ";
                                oHoja.Cells[InicioLinea, 2].Value = item.CodPlaCta + "    " + item.Descripcion;
                                oHoja.Cells[InicioLinea, 3].Value = item.MesAnterior;
                                oHoja.Cells[InicioLinea, 4].Value = item.MesAnteriorAcumulado;
                                oHoja.Cells[InicioLinea, 5].Value = item.MesActual;
                                oHoja.Cells[InicioLinea, 6].Value = item.MesActualAcumulado;

                                oHoja.Cells[InicioLinea, 3, InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";

                                InicioLinea++;
                            }
                            subTotante = subTotante + item.MesAnterior;
                            subTotanteacum = subTotanteacum + item.MesAnteriorAcumulado;
                            subTotmesante = subTotmesante + item.MesActual;
                            subTotAcumAnte = subTotAcumAnte + item.MesActualAcumulado;

                            if (item.TipoTabla == "TOT")
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.secitem;
                                oHoja.Cells[InicioLinea, 2].Value = item.desitem;

                                decimal total1 = subTotmesante ;
                                oHoja.Cells[InicioLinea, 3].Value = total1;

                                decimal total2 = subTotAcumAnte;
                                oHoja.Cells[InicioLinea, 4].Value = total2;
                                                    
                                    
                                decimal total3 = subTotante;
                                oHoja.Cells[InicioLinea, 5].Value = total3;

 
                                decimal total4 = subTotanteacum;
                                oHoja.Cells[InicioLinea, 6].Value = total4;

                                InicioLinea++;
                            }


                            contador++;
                        }

                    }

                    #endregion

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

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                String Version = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String Mes = Convert.ToString(cboMes.SelectedValue); ;
                String TipoSeccion = ((EEFFE)cboEEFF.SelectedItem).TipoSeccion; //Convert.ToString(cboEEFF.SelectedValue);
                Int32 idEEFF = Convert.ToInt32(cboEEFF.SelectedValue); // ((EEFFE)cboEEFF.SelectedItem).TipoSeccion;

                if (TipoSeccion != null)
                {
                    if (tipoBotton == "R")
                    {

                        lblProcesando.Text = "Obteniendo el Balance Tipo Resumen...";
                        oListaEEFFDETALLADO = AgenteContabilidad.Proxy.ListarBalanceGeneralResumen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Version, idEEFF, Anio, Mes);
                        lblProcesando.Text = "Armando el Balance Tipo Resumen...";
                        ConvertirApdfResumen();
                    }

                    if (tipoBotton == "D")
                    {

                        lblProcesando.Text = "Obteniendo el Datos ....";
                        oListaEEFFDETALLADO = AgenteContabilidad.Proxy.ListarBalanceGeneral(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipoSeccion, Anio, Mes);
                        lblProcesando.Text = "Armando el Reporte  ....";
                        ConvertirApdfDetallado();
                    }

                }
                else
                {
                    Global.MensajeComunicacion("Seleccione Primero un Estado Financiero !!!...");
                }
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
            btDetallado.Enabled = true;
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
                Global.MensajeComunicacion("Estados Financieros Detallado Exportado...");
            }
        }

        #endregion

        #region Eventos

        private void btResumen_Click(object sender, EventArgs e)
        {
            try
            {
                tipoBotton = "R";
                tipo = "buscar";
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btDetallado.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btDetallado.Enabled = true;
                Global.MensajeError(ex.Message);
            }

        }

        private void btDetallado_Click(object sender, EventArgs e)
        {        
            try
            {
                tipoBotton = "D";
                tipo = "buscar";
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btDetallado.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btDetallado.Enabled = true;
                Global.MensajeError(ex.Message);
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
                btDetallado.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btDetallado.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void frmReporteEEFFDetallado_Load(object sender, EventArgs e)
        {
            cboAño.SelectedValue = Convert.ToInt32(Anio);
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

        private void frmReporteEEFFDetallado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
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



// Para el Balance de General

// Resumen
#region Inicio Pdf

class PaginaInicioEEFFdetallado2 : PdfPageEventHelper
{
    public DateTime Per { get; set; }
    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreMes { get; set; }
    public String destit { get; set; }
    public String rutaimagen { get; set; }
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




        if (Mes == 0)
        {
            NombreMes = "APERTURA";
        }
        if (Mes == 1)
        {
            NombreMes = "ENERO";
        }
        if (Mes == 2)
        {
            NombreMes = "FEBRERO";
        }
        if (Mes == 3)
        {
            NombreMes = "MARZO";
        }
        if (Mes == 4)
        {
            NombreMes = "ABRIL";
        }
        if (Mes == 5)
        {
            NombreMes = "MAYO";
        }
        if (Mes == 6)
        {
            NombreMes = "JUNIO";
        }
        if (Mes == 7)
        {
            NombreMes = "JULIO";
        }
        if (Mes == 8)
        {
            NombreMes = "AGOSTO";
        }
        if (Mes == 9)
        {
            NombreMes = "SETIEMBRE";
        }
        if (Mes == 10)
        {
            NombreMes = "OCTUBRE";
        }
        if (Mes == 11)
        {
            NombreMes = "NOVIEMBRE";
        }
        if (Mes == 12)
        {
            NombreMes = "DICIEMBRE";
        }
        if (Mes == 13)
        {
            NombreMes = "CIERRE";
        }




        TituloGeneral = destit;

        SubTitulo = " AL MES " + NombreMes.ToUpper() + " " + Anio.ToUpper() ;
        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.25f, 0.9f, 0.1f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell();
        if (rutaimagen != "")
        {
            System.Drawing.Image Img = System.Drawing.Image.FromFile(rutaimagen);
            cell = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 85f, 30f, 1, 1, "S", 1f));
            Img = null;
            table.AddCell(cell);
        }
        else
        {
            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
        }

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph("(EXPRESADO EN SOLES)", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();  //Fila completada

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        table.AddCell(cell);
        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        //cell.Colspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        //cell.Colspan = 2;
        table.AddCell(cell);

        table.CompleteRow(); //Fila completada 

        #endregion

        #region Subtitulos

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

    }

}

#endregion

// Detallado
#region Inicio Pdf

class PaginaInicioBalanceDetallado : PdfPageEventHelper
{
    public DateTime Per { get; set; }
    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreMes { get; set; }

    public String destit { get; set; }
    public String rutaimagen { get; set; }
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

        if (Mes == 0)
        {
            NombreMes = "APERTURA";
        }
        if (Mes == 1)
        {
            NombreMes = "ENERO";
        }
        if (Mes == 2)
        {
            NombreMes = "FEBRERO";
        }
        if (Mes == 3)
        {
            NombreMes = "MARZO";
        }
        if (Mes == 4)
        {
            NombreMes = "ABRIL";
        }
        if (Mes == 5)
        {
            NombreMes = "MAYO";
        }
        if (Mes == 6)
        {
            NombreMes = "JUNIO";
        }
        if (Mes == 7)
        {
            NombreMes = "JULIO";
        }
        if (Mes == 8)
        {
            NombreMes = "AGOSTO";
        }
        if (Mes == 9)
        {
            NombreMes = "SETIEMBRE";
        }
        if (Mes == 10)
        {
            NombreMes = "OCTUBRE";
        }
        if (Mes == 11)
        {
            NombreMes = "NOVIEMBRE";
        }
        if (Mes == 12)
        {
            NombreMes = "DICIEMBRE";
        }
        if (Mes == 13)
        {
            NombreMes = "CIERRE";
        }

        TituloGeneral = destit +" DETALLADO" ;

        SubTitulo =  " AL MES " + NombreMes.ToUpper() +" " + Anio.ToUpper();

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.25f, 0.9f, 0.1f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell();
        if (rutaimagen != "")
         {
            System.Drawing.Image Img = System.Drawing.Image.FromFile(rutaimagen);
            cell = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 85f, 30f, 1, 1, "S", 1f));
            Img = null;
            table.AddCell(cell);
        }
        else
        {
            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
        }
        

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada


        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph("(EXPRESADO EN SOLES)", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        #endregion

        #region Subtitulos

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(4);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.5f, 0.1f, 0.1f});

        #region Primera Linea

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("** Saldo Actual **", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);


        TablaCabDetalle.CompleteRow();

        #endregion

        #region Segunda Linea

        cell = new PdfPCell(new Paragraph("CUENTA ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("DESCRIPCION ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("DEUDOR", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("ACREEDOR", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);




        TablaCabDetalle.CompleteRow();


        document.Add(TablaCabDetalle);

        #endregion

        #endregion

    }

}

#endregion


// Para los EPYGG

// Resumen
#region Inicio Pdf

class PaginaInicioEEGGYPG2 : PdfPageEventHelper
{
    public DateTime Per { get; set; }
    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreMes { get; set; }
    public String destit { get; set; }
    public String rutaimagen { get; set; }
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




        if (Mes == 0)
        {
            NombreMes = "APERTURA";
        }
        if (Mes == 1)
        {
            NombreMes = "ENERO";
        }
        if (Mes == 2)
        {
            NombreMes = "FEBRERO";
        }
        if (Mes == 3)
        {
            NombreMes = "MARZO";
        }
        if (Mes == 4)
        {
            NombreMes = "ABRIL";
        }
        if (Mes == 5)
        {
            NombreMes = "MAYO";
        }
        if (Mes == 6)
        {
            NombreMes = "JUNIO";
        }
        if (Mes == 7)
        {
            NombreMes = "JULIO";
        }
        if (Mes == 8)
        {
            NombreMes = "AGOSTO";
        }
        if (Mes == 9)
        {
            NombreMes = "SETIEMBRE";
        }
        if (Mes == 10)
        {
            NombreMes = "OCTUBRE";
        }
        if (Mes == 11)
        {
            NombreMes = "NOVIEMBRE";
        }
        if (Mes == 12)
        {
            NombreMes = "DICIEMBRE";
        }
        if (Mes == 13)
        {
            NombreMes = "CIERRE";
        }




        TituloGeneral = destit;

        SubTitulo = " AL MES " + NombreMes.ToUpper() + " " + Anio.ToUpper();
        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.25f, 0.9f, 0.1f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell();
        if (rutaimagen != "")
        {
            System.Drawing.Image Img = System.Drawing.Image.FromFile(rutaimagen);
            cell = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 85f, 30f, 1, 1, "S", 1f));
            Img = null;
            table.AddCell(cell);
        }
        else
        {
            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
        }

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();
        
        cell = new PdfPCell(new Paragraph("(EXPRESADO EN SOLES)", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        table.AddCell(cell);
        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
        //cell.Colspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        //cell.Colspan = 2;
        table.AddCell(cell);

        table.CompleteRow(); //Fila completada 

        #endregion

        #region Subtitulos

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada


        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF


    }

}

#endregion

// Detallado
#region Inicio Pdf

class PaginaInicioEEGGYPGDetallado : PdfPageEventHelper
{
    public DateTime Per { get; set; }
    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreMes { get; set; }

    public String destit { get; set; }
    public String rutaimagen { get; set; }
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




        if (Mes == 0)
        {
            NombreMes = "APERTURA";
        }
        if (Mes == 1)
        {
            NombreMes = "ENERO";
        }
        if (Mes == 2)
        {
            NombreMes = "FEBRERO";
        }
        if (Mes == 3)
        {
            NombreMes = "MARZO";
        }
        if (Mes == 4)
        {
            NombreMes = "ABRIL";
        }
        if (Mes == 5)
        {
            NombreMes = "MAYO";
        }
        if (Mes == 6)
        {
            NombreMes = "JUNIO";
        }
        if (Mes == 7)
        {
            NombreMes = "JULIO";
        }
        if (Mes == 8)
        {
            NombreMes = "AGOSTO";
        }
        if (Mes == 9)
        {
            NombreMes = "SETIEMBRE";
        }
        if (Mes == 10)
        {
            NombreMes = "OCTUBRE";
        }
        if (Mes == 11)
        {
            NombreMes = "NOVIEMBRE";
        }
        if (Mes == 12)
        {
            NombreMes = "DICIEMBRE";
        }
        if (Mes == 13)
        {
            NombreMes = "CIERRE";
        }




        TituloGeneral = destit + " DETALLADO";

        SubTitulo = " AL MES " + NombreMes.ToUpper() + " " + Anio.ToUpper();

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.25f, 0.9f, 0.1f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell();
        if (rutaimagen != "")
        {
            System.Drawing.Image Img = System.Drawing.Image.FromFile(rutaimagen);
            cell = new PdfPCell(ReaderHelper.ImagenCellAbosoluta(Img, 1, 4f, 85f, 30f, 1, 1, "S", 1f));
            Img = null;
            table.AddCell(cell);
        }
        else
        {
            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
        }




        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph("(EXPRESADO EN SOLES)", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        #endregion

        #region Subtitulos

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 3;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada



        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(6);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.5f, 0.1f, 0.1f, 0.1f, 0.1f });

        #region Primera Linea

        //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //TablaCabDetalle.AddCell(cell);

        //cell = new PdfPCell(new Paragraph("** Saldo Actual **", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Colspan = 2;
        //TablaCabDetalle.AddCell(cell);


        //TablaCabDetalle.CompleteRow();

        #endregion

        #region Segunda Linea

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("MES ANTERIOR", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("ACUM. ANTERIOR", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("DEL MES", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("ACUMULADO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();


        document.Add(TablaCabDetalle);

        #endregion

        #endregion

    }

}

#endregion



