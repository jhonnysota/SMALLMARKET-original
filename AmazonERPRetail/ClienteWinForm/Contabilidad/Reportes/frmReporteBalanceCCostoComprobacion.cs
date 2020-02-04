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
    public partial class frmReporteBalanceCCostoComprobacion : FrmMantenimientoBase
    {
        #region Constructor
		
        public frmReporteBalanceCCostoComprobacion()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            //Global.CrearToolTip(btPle, "Importar para el PLE");
            //Global.CrearToolTip(btPdb, "Importar para el PDB");
            LlenarCombos();
        }
 
	    #endregion

        #region Variables
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
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
        string tipo = "buscar";
        String Marque = String.Empty;
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

            ///////CCOSTO///////
            cboCosto.DataSource = null;

            List<CCostosE> ListaCostos = AgenteMaestro.Proxy.ListarCCostosPorNivel(Convert.ToInt32(VariablesLocales.SesionLocal.IdEmpresa), 1);
            CCostosE CampoInicial = new CCostosE();
            CampoInicial.idCCostos = "%";
            CampoInicial.desCCostos = "<<<<<TODOS>>>>>";
            ListaCostos.Add(CampoInicial);
            ComboHelper.RellenarCombos<CCostosE>(cboCosto, ListaCostos, "idCCostos", "desCCostos", false);
            cboCosto.SelectedValue = "%";

            ////////FORMATO///////
            cboFormato.DataSource = Global.CargarMA();
            cboFormato.ValueMember = "id";
            cboFormato.DisplayMember = "Nombre";

            Int32 Niveles = AgenteMaestro.Proxy.MaxNivelCCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ParTabla Item = null;
            List<ParTabla> Lista = new List<ParTabla>();

            for (int i = 1; i <= Niveles; i++)
            {
                Item = new ParTabla() { IdParTabla = i, Nombre = "Nivel " + i.ToString() };
                Lista.Add(Item);
            }

            ComboHelper.LlenarCombos<ParTabla>(cboNivel, Lista);

            if (VariablesLocales.oConParametros != null)
            {
                if (VariablesLocales.oConParametros.numNivelCCosto > 0)
                {
                    cboNivel.SelectedValue = Convert.ToInt32(VariablesLocales.oConParametros.numNivelCCosto);
                   
                }
            }
        }

        #endregion
        
        #region Procedimientos de Usuario
        
        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\BalanceCCostoComprobacion " + Aleatorio.ToString();
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

                PaginaInicioBalanceCosto ev = new PaginaInicioBalanceCosto();
                ev.Anio = Convert.ToString(cboAño.SelectedValue);
                ev.Mes = Convert.ToInt32(cboMes.SelectedValue);
                ev.Formato = Convert.ToString(cboFormato.SelectedValue);
                //ev.Periodo = dtpFecIni.Value.Date;
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
                TotFuncionGanancia = 0;
                TotNaturalezaPerdida = 0;
                TotNaturalezaGanancia = 0;


                // ==========================
                // AGRUPAR DATOS
                // ==========================

                oListaBalanceComprobacion = (from x in oListaBalanceComprobacion orderby x.CodCostos select x).ToList();

                int contador = 0;
                string CCostos = "";
                string desCCostos = "";

                decimal subTotMayorDebe = 0;
                decimal subTotMayorHaber = 0;
                decimal subTotActualDebe = 0;
                decimal subTotActualHaber = 0;
                decimal subTotInvenActivo = 0;
                decimal subTotInvenPasivo = 0;
                decimal subTotFuncionPerdida = 0;
                decimal subTotFuncionGanancia = 0;
                decimal subTotNaturalezaPerdida = 0;
                decimal subTotNaturalezaGanancia = 0;

                string LineaSepradora = "----------------------------------";
                // ==========================

                for (int i = 0; i < oListaBalanceComprobacion.Count;i++ )
                {
                    // ====================================================
                    // PRIMERA LINEA - CARGAMOS DATOS
                    // ====================================================

                    if (contador == 0)
                    {
                        CCostos = oListaBalanceComprobacion[i].CodCostos;
                        desCCostos = oListaBalanceComprobacion[i].DesCostos;

                        cell = CellPdf(CCostos, 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(desCCostos, 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();
                    }

                    // ====================================================
                    // cambio de grupo
                    // ====================================================

                    if (CCostos != oListaBalanceComprobacion[i].CodCostos)
                    {
                        // ====================================================
                        // linea separadora
                        cell = CellPdf("-----------------", 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf("------------------------------------------------------------------------------------------", 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                        // ====================================================

                        cell = CellPdf(" ", 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(subTotMayorDebe.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(subTotMayorHaber.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);

                        cell = CellPdf(subTotActualDebe.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(subTotActualHaber.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);

                        cell = CellPdf(subTotInvenActivo.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(subTotInvenPasivo.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);

                        cell = CellPdf(subTotFuncionPerdida.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(subTotFuncionGanancia.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);

                        cell = CellPdf(subTotNaturalezaPerdida.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(subTotNaturalezaGanancia.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();

                        CCostos = oListaBalanceComprobacion[i].CodCostos;
                        desCCostos = oListaBalanceComprobacion[i].DesCostos;

                        cell = CellPdf(CCostos, 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(desCCostos, 0, 0, "l", "bold"); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        cell = CellPdf(" ", 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();

                        subTotMayorDebe = 0; subTotMayorHaber = 0;
                        subTotActualDebe = 0; subTotActualHaber = 0;
                        subTotInvenActivo = 0; subTotInvenPasivo = 0;
                        subTotFuncionPerdida = 0; subTotFuncionGanancia = 0;
                        subTotNaturalezaPerdida = 0; subTotNaturalezaGanancia = 0;
                    }
                    // ====================================================
                    // REGISTRO SIMPLE
                    // ====================================================

                    TotMayorDebe = TotMayorDebe + oListaBalanceComprobacion[i].MayorDebe;
                    TotMayorHaber = TotMayorHaber + oListaBalanceComprobacion[i].MayorHaber;

                    TotActualDebe = TotActualDebe + oListaBalanceComprobacion[i].SaldoActualDebe;
                    TotActualHaber = TotActualHaber + oListaBalanceComprobacion[i].SaldoActualHaber;

                    TotInvenActivo = TotInvenActivo + oListaBalanceComprobacion[i].InvenActivo;
                    TotInvenPasivo = TotInvenPasivo + oListaBalanceComprobacion[i].InvenPasivo;

                    TotFuncionPerdida = TotFuncionPerdida + oListaBalanceComprobacion[i].PorFuncionPerdida;
                    TotFuncionGanancia = TotFuncionGanancia + oListaBalanceComprobacion[i].PorFuncionGanancia;

                    TotNaturalezaPerdida = TotNaturalezaPerdida + oListaBalanceComprobacion[i].PorNaturalezaPerdida;
                    TotNaturalezaGanancia = TotNaturalezaGanancia + oListaBalanceComprobacion[i].PorNaturalezaGanancia;


                    cell = CellPdf(oListaBalanceComprobacion[i].CodCuenta, 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].DesCuenta, 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].MayorDebe.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].MayorHaber.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].SaldoActualDebe.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].SaldoActualHaber.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].InvenActivo.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].InvenPasivo.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].PorFuncionPerdida.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].PorFuncionGanancia.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].PorNaturalezaPerdida.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    cell = CellPdf(oListaBalanceComprobacion[i].PorNaturalezaGanancia.ToString("N2"), 0, 0, "r", ""); TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

                    // ====================================================
                    // SUB TOTALES DEL GRUPO CENTRO DE COSTOS
                    // ====================================================

                    subTotMayorDebe = subTotMayorDebe + oListaBalanceComprobacion[i].MayorDebe;
                    subTotMayorHaber = subTotMayorHaber + oListaBalanceComprobacion[i].MayorHaber;

                    subTotActualDebe = subTotActualDebe + oListaBalanceComprobacion[i].SaldoActualDebe;
                    subTotActualHaber = subTotActualHaber + oListaBalanceComprobacion[i].SaldoActualHaber;

                    subTotInvenActivo = subTotInvenActivo + oListaBalanceComprobacion[i].InvenActivo;
                    subTotInvenPasivo = subTotInvenPasivo + oListaBalanceComprobacion[i].InvenPasivo;

                    subTotFuncionPerdida = subTotFuncionPerdida + oListaBalanceComprobacion[i].PorFuncionPerdida;
                    subTotFuncionGanancia = subTotFuncionGanancia + oListaBalanceComprobacion[i].PorFuncionGanancia;

                    subTotNaturalezaPerdida = subTotNaturalezaPerdida + oListaBalanceComprobacion[i].PorNaturalezaPerdida;
                    subTotNaturalezaGanancia = subTotNaturalezaGanancia + oListaBalanceComprobacion[i].PorNaturalezaGanancia;

                    // ====================================================

                    contador++;
                }

                // ====================================================
                // linea separadora
                cell = CellPdf(" ", 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(" ", 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(LineaSepradora, 0, 0, "", ""); TablaCabDetalle.AddCell(cell);
                // ====================================================

                cell = CellPdf(" ", 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(" ", 0, 0, "l", ""); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(subTotMayorDebe.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(subTotMayorHaber.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);

                cell = CellPdf(subTotActualDebe.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(subTotActualHaber.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);

                cell = CellPdf(subTotInvenActivo.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(subTotInvenPasivo.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);

                cell = CellPdf(subTotFuncionPerdida.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(subTotFuncionGanancia.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);

                cell = CellPdf(subTotNaturalezaPerdida.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
                cell = CellPdf(subTotNaturalezaGanancia.ToString("N2"), 0, 0, "r", "bold"); TablaCabDetalle.AddCell(cell);
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


                //ParPas = ParPas + TotInvenActivo - TotInvenPasivo;


                //ParPer1 = ParPer1 + TotFuncionGanancia - TotFuncionPerdida;
              

                //ParPer2 = ParPer2 + TotNaturalezaGanancia - TotNaturalezaPerdida;
               
                
                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f,iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("TOTAL GENERAL", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotMayorDebe.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotMayorHaber.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotActualDebe.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotActualHaber.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotInvenActivo.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotInvenPasivo.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotFuncionPerdida.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotFuncionGanancia.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotNaturalezaPerdida.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotNaturalezaGanancia.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                TablaCabDetalle.AddCell(cell);



                TablaCabDetalle.CompleteRow();


                //TotalEmpresa2 = TotalEmpresa2 + ParPas + TotInvenPasivo;

                //TotalEmpresa3 = TotalEmpresa3 + ParPer1 + TotFuncionPerdida;

                //TotalEmpresa5 = TotalEmpresa5 + ParPer2 + TotNaturalezaPerdida;


                #region comentado
                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("**UTILIDAD(PERDIDA)**", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(ParPas.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(ParPer1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(ParPer2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                //TablaCabDetalle.AddCell(cell);




                //TablaCabDetalle.CompleteRow();


                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph("**TOTALEMPRESA**", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(TotInvenActivo.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(TotalEmpresa2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(TotalEmpresa3.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(TotFuncionGanancia.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(TotalEmpresa5.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                //TablaCabDetalle.AddCell(cell);

                //cell = new PdfPCell(new Paragraph(TotNaturalezaGanancia.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };

                //TablaCabDetalle.AddCell(cell);

                //TablaCabDetalle.CompleteRow();
                
#endregion

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

        PdfPCell CellPdf(string titulo, int size, int border, string align, string bold)
        {
            if (border<0)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 5f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK))) {  HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 5f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK))) { Border = border, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
            Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
            String Anio = Convert.ToString(cboAño.SelectedValue);
            String Mes = Convert.ToString(cboMes.SelectedValue); ;
            String Version = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            String idMoneda =  cboMonedas.SelectedValue.ToString();
            String Costo = Convert.ToString(cboCosto.SelectedValue);
            String Formato = Convert.ToString(cboFormato.SelectedValue);
            Int32 numNivel = Convert.ToInt32(cboNivel.SelectedValue);

                lblProcesando.Text = "Obteniendo el Balance de Comprobacion...";
            oListaBalanceComprobacion = AgenteContabilidad.Proxy.ListarBalanceComprobacionCCostoAcumulado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, Anio, Mes, Version, idMoneda, Costo,Formato,numNivel);
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
                Global.MensajeComunicacion("Balance Costos Exportado...");
            }
        }

        #endregion

        #region Exportar Excel
           
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

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Balance Comprobacion Por Centro De Costos" + NombreLocal + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

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



            TituloGeneral = " Balance Comprobacion Por Centro De Costos " + " Al Año " + Anio + " Del Mes " + nombreMes;
            NombrePestaña = " Balance Comprobacion Por Centro De Costos";

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

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion                                       

                    #region Detallado
                    int contador = 0;
                    string codCostos_Anterior="" ;

                    decimal MayorDebe = 0;
                    decimal MayorHaber = 0;
                    decimal SaldoActualDebe = 0;
                    decimal SaldoActualHaber = 0;
                    decimal InvenActivo = 0;
                    decimal InvenPasivo = 0;
                    decimal PorFuncionPerdida = 0;
                    decimal PorFuncionGanancia = 0;
                    decimal PorNaturalezaPerdida = 0;
                    decimal PorNaturalezaGanancia = 0;

                    oListaBalanceComprobacion = oListaBalanceComprobacion.OrderBy(x => x.CodCostos).ToList();
                    foreach (BalanceComprobacionE item in oListaBalanceComprobacion)
                    {

                        if(contador == 0)
                        {
                            codCostos_Anterior = item.CodCostos;

                            oHoja.Cells[InicioLinea, 1].Value = item.CodCostos;
                            oHoja.Cells[InicioLinea, 2].Value = item.DesCostos;
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

                            MayorDebe += item.MayorDebe;
                            MayorHaber += item.MayorHaber;
                            SaldoActualDebe += item.SaldoActualDebe;
                            SaldoActualHaber += item.SaldoActualHaber;
                            InvenActivo += item.InvenActivo;
                            InvenPasivo += item.InvenPasivo;
                            PorFuncionPerdida += item.PorFuncionPerdida;
                            PorFuncionGanancia += item.PorFuncionGanancia;
                            PorNaturalezaPerdida += item.PorNaturalezaPerdida;
                            PorNaturalezaGanancia += item.PorNaturalezaGanancia;

                            oHoja.Cells[InicioLinea, 3, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;
                           
                        }

                        if (contador > 0 && codCostos_Anterior == item.CodCostos)
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
                            oHoja.Cells[InicioLinea, 3, InicioLinea,12].Style.Numberformat.Format = "###,###,##0.00";

                            MayorDebe += item.MayorDebe;
                            MayorHaber += item.MayorHaber;
                            SaldoActualDebe += item.SaldoActualDebe;
                            SaldoActualHaber += item.SaldoActualHaber;
                            InvenActivo += item.InvenActivo;
                            InvenPasivo += item.InvenPasivo;
                            PorFuncionPerdida += item.PorFuncionPerdida;
                            PorFuncionGanancia += item.PorFuncionGanancia;
                            PorNaturalezaPerdida += item.PorNaturalezaPerdida;
                            PorNaturalezaGanancia += item.PorNaturalezaGanancia;

                            InicioLinea++;
                        }

                        if (contador > 0 && codCostos_Anterior != item.CodCostos)
                        {

                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                            InicioLinea++;
                            // SUB STOTTALES

                            oHoja.Cells[InicioLinea, 1].Value = "";
                            oHoja.Cells[InicioLinea, 2].Value = "SUB TOTALES";
                            oHoja.Cells[InicioLinea, 3].Value = MayorDebe;
                            oHoja.Cells[InicioLinea, 4].Value = MayorHaber;
                            oHoja.Cells[InicioLinea, 5].Value = SaldoActualDebe;
                            oHoja.Cells[InicioLinea, 6].Value = SaldoActualHaber;
                            oHoja.Cells[InicioLinea, 7].Value = InvenActivo;
                            oHoja.Cells[InicioLinea, 8].Value = InvenPasivo;
                            oHoja.Cells[InicioLinea, 9].Value = PorFuncionPerdida;
                            oHoja.Cells[InicioLinea, 10].Value = PorFuncionGanancia;
                            oHoja.Cells[InicioLinea, 11].Value = PorNaturalezaPerdida;
                            oHoja.Cells[InicioLinea, 12].Value = PorNaturalezaGanancia;

                            for (int i = 1; i <= 12; i++)
                            {

                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                            }

                            MayorDebe = 0;
                            MayorHaber = 0;
                            SaldoActualDebe = 0;
                            SaldoActualHaber = 0;
                            InvenActivo = 0;
                            InvenPasivo = 0;
                            PorFuncionPerdida = 0;
                            PorFuncionGanancia = 0;
                            PorNaturalezaPerdida = 0;
                            PorNaturalezaGanancia = 0;


                            // FORMAT 
                            oHoja.Cells[InicioLinea, 3, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;

                            codCostos_Anterior = item.CodCostos;

                            oHoja.Cells[InicioLinea, 1].Value = item.CodCostos;
                            oHoja.Cells[InicioLinea, 2].Value = item.DesCostos;
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

                            MayorDebe += item.MayorDebe;
                            MayorHaber += item.MayorHaber;
                            SaldoActualDebe += item.SaldoActualDebe;
                            SaldoActualHaber += item.SaldoActualHaber;
                            InvenActivo += item.InvenActivo;
                            InvenPasivo += item.InvenPasivo;
                            PorFuncionPerdida += item.PorFuncionPerdida;
                            PorFuncionGanancia += item.PorFuncionGanancia;
                            PorNaturalezaPerdida += item.PorNaturalezaPerdida;
                            PorNaturalezaGanancia += item.PorNaturalezaGanancia;

                            // FORMAT 
                            oHoja.Cells[InicioLinea, 3, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;
                        }


                        contador++;                                               
                    }


                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;

                    // SUB STOTTALES

                    oHoja.Cells[InicioLinea, 1].Value = "";
                    oHoja.Cells[InicioLinea, 2].Value = "SUB TOTALES";
                    oHoja.Cells[InicioLinea, 3].Value = MayorDebe;
                    oHoja.Cells[InicioLinea, 4].Value = MayorHaber;
                    oHoja.Cells[InicioLinea, 5].Value = SaldoActualDebe;
                    oHoja.Cells[InicioLinea, 6].Value = SaldoActualHaber;
                    oHoja.Cells[InicioLinea, 7].Value = InvenActivo;
                    oHoja.Cells[InicioLinea, 8].Value = InvenPasivo;
                    oHoja.Cells[InicioLinea, 9].Value = PorFuncionPerdida;
                    oHoja.Cells[InicioLinea, 10].Value = PorFuncionGanancia;
                    oHoja.Cells[InicioLinea, 11].Value = PorNaturalezaPerdida;
                    oHoja.Cells[InicioLinea, 12].Value = PorNaturalezaGanancia;

                    for (int i = 1; i <= 12; i++)
                    {

                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                    }

                    MayorDebe = 0;
                    MayorHaber = 0;
                    SaldoActualDebe = 0;
                    SaldoActualHaber = 0;
                    InvenActivo = 0;
                    InvenPasivo = 0;
                    PorFuncionPerdida = 0;
                    PorFuncionGanancia = 0;
                    PorNaturalezaPerdida = 0;
                    PorNaturalezaGanancia = 0;


                    // FORMAT 
                    oHoja.Cells[InicioLinea, 3, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                    InicioLinea++;



                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;

                    // totales

                    oHoja.Cells[InicioLinea, 2].Value = "TOTAL GENERAL";
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


                    // FORMAT 
                    oHoja.Cells[InicioLinea, 3, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                    
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
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments =  NombrePestaña ;

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

        private void frmReporteBalanceCCostoComprobacion_Load(object sender, EventArgs e)
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

        private void frmReporteBalanceCCostoComprobacion_FormClosing(object sender, FormClosingEventArgs e)
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


        #region Inicio Pdf

        class PaginaInicioBalanceCosto : PdfPageEventHelper
{
    public DateTime Per { get; set; }
    public String Mon { get; set; }
    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreMes { get; set; }
    public String Formato { get; set; }
    public String NombreFormato { get; set; }

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

        if (Formato == "M")
        {
            NombreFormato = "MENSUAL";
        }
        else 
        {
            NombreFormato = "ACUMULADO";
        }


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




        TituloGeneral = "BALANCE DE COMPROBACION " + NombreFormato.ToUpper() + " POR EL AÑO " + Anio.ToUpper() + " DEL MES " + NombreMes.ToUpper();

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
