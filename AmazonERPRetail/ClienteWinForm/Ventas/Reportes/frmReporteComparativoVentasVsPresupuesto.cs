using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteComparativoVentasVsPresupuesto : FrmMantenimientoBase
    {

        #region Constructor 

        public frmReporteComparativoVentasVsPresupuesto()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
        }

        #endregion

        #region variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<EmisionDocumentoE> oListaReporte = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
        string tipo = "buscar";
        String Marque = String.Empty;
        Int32 TipoReporte = 0;
        Int32 Presentacion = 0;
        float[] ArrayColumnas = null;
        String Titulo = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desAbreviatura";

            //Tipo Reporte
            List<ParTabla> oListaReporte = new List<ParTabla>
            {
                new ParTabla() { IdParTabla = 1, Nombre = "COMPARATIVO VENTAS POR PRODUCTO POR VENDEDORES" },
                new ParTabla() { IdParTabla = 2, Nombre = "COMPARATIVO VENTAS POR ESPECIE" },
                new ParTabla() { IdParTabla = 3, Nombre = "COMPARATIVO VENTAS POR PRODUCTO" },
                new ParTabla() { IdParTabla = 4, Nombre = "COMPARATIVO VENTAS POR ESPECIE POR DIVISION" },
                new ParTabla() { IdParTabla = 5, Nombre = "COMPARATIVO VENTAS POR ESPECIE POR ZONA" },
                new ParTabla() { IdParTabla = 6, Nombre = "COMPARATIVO VENTAS POR ESPECIE POR VENDEDOR" },
                new ParTabla() { IdParTabla = 7, Nombre = "COMPARATIVO VENTAS POR PRODUCTO POR DIVISION" },
                new ParTabla() { IdParTabla = 8, Nombre = "COMPARATIVO VENTAS POR PRODUCTO POR ZONAS" }
            };

            ComboHelper.RellenarCombos<ParTabla>(cboTipoReporte, oListaReporte);

            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            listaLocales.Add(new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos });
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboLocal, listaLocales, "idLocal", "Nombre", false);

            //Presentación
            cboPresentacion.DataSource = Global.CargarMontoCantidad();
            cboPresentacion.ValueMember = "id";
            cboPresentacion.DisplayMember = "Nombre";

            //Vendedores
            List<VendedoresE> oListaVendedores = AgenteMaestro.Proxy.BusquedaVendedores(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListaVendedores.Add(new VendedoresE() { idPersona = Variables.Cero, RazonSocial = "<< ESCOGER VENDEDOR >>" });
            ComboHelper.LlenarCombos<VendedoresE>(cboVendedor, (from x in oListaVendedores orderby x.idPersona select x).ToList(), "idPersona", "RazonSocial");
        }

        void ConvertirApdf()
        {
            List<EmisionDocumentoE> oListaCabecera =  oListaReporte.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();
            Document docPdf = new Document((oListaCabecera.Count <= 5 ? PageSize.A3.Rotate() : PageSize.A2.Rotate()), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\" + ((ParTabla)cboTipoReporte.SelectedItem).Nombre + " " + Aleatorio.ToString() + ".pdf";
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
                #region Variables
                
                List<EmisionDocumentoE> oListaArticulos = null;
                String Mon = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                String presentacion = cboPresentacion.Text.ToString();
                String anio = dtpInicio.Value.ToString("yyyy");
                
                String Subtitulo = String.Empty;
                int Columnas = 0;
                String nomArticulo = String.Empty;
                String Vendedor = String.Empty;
                String Division = String.Empty;
                String Zona = String.Empty;

                Decimal TotalFilaVC = 0;
                Decimal TotalFilaPron = 0;
                Decimal TotalFilaVar = 0;
                Decimal TotalFilaPor = 0;
                Decimal TotalMesVC = 0;
                Decimal TotalMesPron = 0;
                Decimal TotalMesVar = 0;
                Decimal TotalMesVarPor = 0;
                Decimal TotalGeneralVC = 0;
                Decimal TotalGeneralPron = 0;
                Decimal TotalGeneralVar = 0;
                Decimal TotalGeneralVarPor = 0;
                Decimal MesVC = 0;
                Decimal MesPro = 0;
                Decimal MesVar = 0;
                Decimal MesVarPor = 0;
                PdfPTable TablaDetalle = null;

                BaseColor ColorSubtitulo = new BaseColor(233, 240, 245); //Color Subtitulo
                BaseColor ColorLinea = new BaseColor(84, 139, 184); //ColorLinea
                BaseColor ColorCabDeta = new BaseColor(148, 182, 210);

                //Meses para el filtro de la nueva lista
                Int32 MesIni = dtpInicio.Value.Month;
                Int32 MesFin = dtpFinal.Value.Month;

                #endregion

                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    docPdf.Open();

                    #region Titulos Principales

                    if (cboMoneda.Enabled)
                    {
                        Titulo = ((ParTabla)cboTipoReporte.SelectedItem).Nombre + " En " + presentacion + " (" + Mon + ")";
                    }
                    else
                    {
                        Titulo = ((ParTabla)cboTipoReporte.SelectedItem).Nombre + " En " + presentacion;
                    }

                    Subtitulo = "Año Facturación: " + anio;

                    PdfPTable table = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    table.SetWidths(new float[] { 0.55f, 0.45f });
                    table.HorizontalAlignment = Element.ALIGN_LEFT;

                    table.AddCell(ReaderHelper.NuevaCelda(Titulo.ToUpper(), null, "N", null, FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                    table.CompleteRow();

                    //Linea en blanco
                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD), 5, 0, "S2"));
                    table.CompleteRow();

                    table.AddCell(ReaderHelper.NuevaCelda(Subtitulo, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S2"));
                    table.CompleteRow();

                    //Linea en blanco
                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0, "S2"));
                    table.CompleteRow();

                    #endregion

                    docPdf.Add(table);

                    #region Reporte 1

                    if (TipoReporte == 1)
                    {
                        //Variable para sacar con las fechas indicadas
                        List<EmisionDocumentoE> oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                                                          where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                                                          orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                                                          select x).ToList());
                        //Nueva agrupación con la nueva lista creada
                        oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();

                        #region Cabecera del Detalle

                        Columnas = (oListaCabecera.Count * 4) + 5;
                        docPdf.Add(DetalleCabeceras(oListaCabecera));

                        #endregion

                        #region Detalle

                        TablaDetalle = new PdfPTable(Columnas)
                        {
                            WidthPercentage = 100
                        };

                        TablaDetalle.SetWidths(ArrayColumnas);

                        //Lista nueva agrupada por Vendedor
                        List<EmisionDocumentoE> oListaVendedor = oListaReal.GroupBy(x => x.nomVendedor).Select(g => g.First()).ToList(); //oListaReporte.GroupBy(x => x.nomVendedor).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaVendedor.Count; i++)
                        {
                            //Para poder colocar la linea Bottom de la cabecera del detalle
                            if (i == 0)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSubtitulo, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.CompleteRow();
                            }

                            //Vendedor
                            Vendedor = oListaVendedor[i].nomVendedor;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Vendedor, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0));

                            //Subtitulo del detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.nomVendedor == Vendedor && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.nomVendedor == Vendedor && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesPro.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesPro >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                MesVar = MesVC - MesPro;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVar >= 0 ? MesVar.ToString("N2") : "(" + (MesVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100M;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVarPor >= 0 ? MesVarPor.ToString("N2") + "%" : "(" + (MesVarPor * -1).ToString("N2") + "%)", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                //TotalGeneralVC += MesVC;
                                //TotalGeneralPron += MesVar;
                            }

                            #region Totales del subtitulo

                            TotalGeneralVC = oListaReporte.Where(x => x.nomVendedor == Vendedor && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.nomVendedor == Vendedor && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar >= 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor >= 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.CompleteRow(); 

                            #endregion

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            //1 - Agrupando articulos por vendedor
                            oListaArticulos = oListaReal.Where(x => x.nomVendedor == Vendedor).ToList(); //oListaReporte.Where(x => x.nomVendedor == Vendedor).ToList();
                            //2 - Agrupando la lista por articulos(Especie)
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList(); //oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                //Articulo
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.nomVendedor == Vendedor//oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.nomVendedor == Vendedor//oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                    //TotalFilaVC += TotalMesVC;
                                    //TotalFilaPron += TotalMesPron;
                                    //TotalFilaVar += TotalMesVar;
                                    //TotalFilaPor += TotalMesVarPor;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaPor = 0;
                                }

                                //Total Fila
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                TablaDetalle.CompleteRow();

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaPor = 0;
                            }
                        }

                        //Linea Final
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal); //oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal); //oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC > 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron > 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar > 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor > 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                            //TotalGeneralVC += TotalMesVC;
                            //TotalGeneralPron += TotalMesPron;
                            //TotalGeneralVar += TotalMesVar;
                            //TotalGeneralVarPor += TotalMesVarPor;
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC > 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalGeneralVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron > 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalGeneralPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar > 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor > 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        TablaDetalle.CompleteRow();

                        docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                        #endregion
                    }

                    #endregion

                    #region Reporte 2

                    if (TipoReporte == 2)
                    {
                        //Variable para sacar con las fechas indicadas
                        List<EmisionDocumentoE> oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                                                          where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                                                          orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                                                          select x).ToList());
                        //Nueva agrupación con la nueva lista creada
                        oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();

                        #region Cabecera del Detalle

                        Columnas = (oListaCabecera.Count * 4) + 5; //Total de columnas
                        docPdf.Add(DetalleCabeceras(oListaCabecera)); //Agregando las cabeceras del detalle

                        #endregion

                        #region Detalle

                        TablaDetalle = new PdfPTable(Columnas)
                        {
                            WidthPercentage = 100
                        };

                        TablaDetalle.SetWidths(ArrayColumnas);

                        //Lista nueva agrupada por Especie
                        List<EmisionDocumentoE> oListaEspecies = oListaReal.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList(); //oListaReporte.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaEspecies.Count; i++)
                        {
                            if (i == 0)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.CompleteRow();
                            }

                            //Articulos
                            nomArticulo = oListaEspecies[i].nomArticulo;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), 5, 0));

                            //Meses
                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                TotalMesVC = oListaReal.Where(x => x.nomArticulo == nomArticulo //oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                && x.nomMes == oListaCabecera[c].nomMes
                                                                && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalMesPron = oListaReal.Where(x => x.nomArticulo == nomArticulo //oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                && x.nomMes == oListaCabecera[c].nomMes
                                                                && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalMesVar = TotalMesVC - TotalMesPron;

                                if (TotalMesPron > 0)
                                {
                                    TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                }
                                else
                                {
                                    TotalMesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            }

                            //Agregado
                            TotalFilaVC = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalFilaPron = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TotalFilaVar = TotalFilaVC - TotalFilaPron;

                            if (TotalFilaPron > 0)
                            {
                                TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                            }
                            else
                            {
                                TotalFilaPor = 0;
                            }

                            //Total Fila
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            TablaDetalle.CompleteRow();
                            TotalFilaVC = 0;
                            TotalFilaPron = 0;
                            TotalFilaVar = 0;
                            TotalFilaPor = 0;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC > 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron > 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar > 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor > 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC > 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalGeneralVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron > 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalGeneralPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar > 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor > 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        TablaDetalle.CompleteRow();

                        docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                        #endregion
                    }

                    #endregion

                    #region Reporte 3

                    if (TipoReporte == 3)
                    {
                        //Variable para sacar con las fechas indicadas
                        List<EmisionDocumentoE> oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                                                          where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                                                          orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                                                          select x).ToList());
                        //Nueva agrupación con la nueva lista creada
                        oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();

                        if (Presentacion == 1 || Presentacion == 2)
                        {
                            #region Cabecera del Detalle

                            Columnas = (oListaCabecera.Count * 4) + 5;
                            docPdf.Add(DetalleCabeceras(oListaCabecera));

                            #endregion

                            #region Detalle

                            TablaDetalle = new PdfPTable(Columnas)
                            {
                                WidthPercentage = 100
                            };

                            TablaDetalle.SetWidths(ArrayColumnas);

                            //Lista nueva agrupada por articulo
                            oListaArticulos = oListaReal.GroupBy(x => new { x.nomArticulo }).Select(g => g.First()).ToList();

                            for (int i = 0; i < oListaArticulos.Count; i++)
                            {
                                if (i == 0)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                    TablaDetalle.CompleteRow();
                                }

                                //Articulos
                                nomArticulo = oListaArticulos[i].nomArticulo;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                    //TotalFilaVC += TotalMesVC;
                                    //TotalFilaPron += TotalMesPron;
                                    //TotalFilaVar += TotalMesVar;
                                    //TotalFilaPor += TotalMesVarPor;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaPor = 0;
                                }

                                //Total Fila
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                TablaDetalle.CompleteRow();
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TotalMesVar = TotalMesVC - TotalMesPron;

                                if (TotalMesPron > 0)
                                {
                                    TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                }
                                else
                                {
                                    TotalMesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                                //TotalGeneralVC += TotalMesVC;
                                //TotalGeneralPron += TotalMesPron;
                                //TotalGeneralVar += TotalMesVar;
                                //TotalGeneralVarPor += TotalMesVarPor;
                            }

                            //Agregado
                            TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron > 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC >= 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron >= 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar >= 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor >= 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                            TablaDetalle.CompleteRow();

                            docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                            #endregion 
                        }

                        if (Presentacion == 3)
                        {
                            #region Cabecera del Detalle

                            Columnas = (oListaCabecera.Count * 4) + 6; //Total de columnas

                            #region Comentado
                            //ArrayColumnas = new float[Columnas]; //Para crear el tamaño de las columnas
                            //ArrayTitulos = new String[oListaCabecera.Count + 3]; //Titulos para la primera linea de las cabecera
                            //ArrayTitulos_2 = new String[Columnas - 2]; //Titulos para la segunda linea de las cabecera
                            //s = 0;
                            //w = 0;

                            //for (int i = 0; i < Columnas; i++)
                            //{
                            //    if (i == 0)
                            //    {
                            //        ArrayTitulos[i] = "DESCRIPCIÓN";
                            //        ArrayColumnas[i] = 0.45f;
                            //    }
                            //    else if (i == 1)
                            //    {
                            //        ArrayTitulos[i] = "UN M.";
                            //        ArrayColumnas[i] = 0.1f;
                            //    }
                            //    else if (i == (oListaCabecera.Count + 2))
                            //    {
                            //        ArrayTitulos[i] = "TOTAL GENERAL";
                            //        ArrayColumnas[i] = 0.09f;

                            //        ArrayTitulos_2[w] = "VENTA";
                            //        ArrayTitulos_2[w + 1] = "PRON";
                            //        ArrayTitulos_2[w + 2] = "VAR";
                            //        ArrayTitulos_2[w + 3] = "VAR %";
                            //    }
                            //    else if (i > 1 && i <= oListaCabecera.Count + 1)
                            //    {
                            //        ArrayTitulos[i] = oListaCabecera[s].nomMes.ToUpper();
                            //        ArrayColumnas[i] = 0.09f;

                            //        ArrayTitulos_2[w] = "VENTA";
                            //        ArrayTitulos_2[w + 1] = "PRON";
                            //        ArrayTitulos_2[w + 2] = "VAR";
                            //        ArrayTitulos_2[w + 3] = "VAR %";

                            //        w++;
                            //        w++;
                            //        w++;
                            //        w++;
                            //        s++;
                            //    }
                            //    else
                            //    {
                            //        ArrayColumnas[i] = 0.09f;
                            //    }
                            //}

                            //PdfPTable TablaCab = new PdfPTable(Columnas)
                            //{
                            //    WidthPercentage = 100
                            //};

                            //TablaCab.SetWidths(ArrayColumnas);

                            ////Primera Linea Cabecera
                            //for (int i = 0; i < ArrayTitulos.Length; i++)
                            //{
                            //    if (i == 0 || i == 1)
                            //    {
                            //        TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "S2", 4, 3, "S", "S", "S", "S", 1f));
                            //    }
                            //    else
                            //    {
                            //        TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S4", "N", 4, 3, "S", "S", "S", "S", 1f));
                            //    }
                            //}

                            //TablaCab.CompleteRow();

                            ////Segunda Linea Cabecera
                            //for (int i = 0; i < ArrayTitulos_2.Length; i++)
                            //{
                            //    TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos_2[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4, 3, "S", "S", "S", "S", 1f));
                            //}

                            //TablaCab.CompleteRow();
                            //docPdf.Add(TablaCab); 
                            #endregion

                            docPdf.Add(DetalleCabeceras(oListaCabecera));

                            #endregion

                            #region Detalle

                            TablaDetalle = new PdfPTable(Columnas)
                            {
                                WidthPercentage = 100
                            };

                            TablaDetalle.SetWidths(ArrayColumnas);

                            //Lista nueva agrupada por articulo
                            oListaArticulos = oListaReal.GroupBy(x => new { x.codArticulo, x.nomArticulo, x.nomUMedida }).Select(g => g.First()).ToList();

                            for (int i = 0; i < oListaArticulos.Count; i++)
                            {
                                if (i == 0)
                                {
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                    TablaDetalle.CompleteRow();
                                }

                                //Articulos y Unidad de medida
                                nomArticulo = oListaArticulos[i].nomArticulo;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD), 5, 0));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(oListaArticulos[i].nomUMedida, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.nomUMedida == oListaArticulos[i].nomUMedida
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.nomUMedida == oListaArticulos[i].nomUMedida
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaPor = 0;
                                }

                                //Total Fila
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                TablaDetalle.CompleteRow();
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "S2", "N", 4, 4, "N", "S", "N", "N", 1f));

                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                TotalMesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalMesPron = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TotalMesVar = TotalMesVC - TotalMesPron;

                                if (TotalMesPron > 0)
                                {
                                    TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                }
                                else
                                {
                                    TotalMesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            }

                            //Agregado
                            TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron > 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC >= 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron >= 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar >= 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor >= 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                            TablaDetalle.CompleteRow();

                            docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                            #endregion 
                        }
                    }

                    #endregion

                    #region Reporte 4

                    if (TipoReporte == 4)
                    {
                        //Variable para sacar con las fechas indicadas
                        List<EmisionDocumentoE> oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                                                          where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                                                          orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                                                          select x).ToList());
                        //Nueva agrupación con la nueva lista creada
                        oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();

                        #region Cabecera del Detalle

                        Columnas = (oListaCabecera.Count * 4) + 5; //Total de columnas
                        docPdf.Add(DetalleCabeceras(oListaCabecera)); //Agregando las cabeceras del detalle

                        #endregion

                        #region Detalle

                        TablaDetalle = new PdfPTable(Columnas)
                        {
                            WidthPercentage = 100
                        };

                        TablaDetalle.SetWidths(ArrayColumnas);

                        //Lista nueva agrupada por División
                        List<EmisionDocumentoE> oListaDivision = oListaReal.GroupBy(x => x.desDivision).Select(g => g.First()).ToList();
                            
                        for (int i = 0; i < oListaDivision.Count; i++)
                        {
                            if (i == 0)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSubtitulo, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.CompleteRow();
                            }

                            //División
                            Division = oListaDivision[i].desDivision;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Division, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0));

                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.desDivision == Division && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.desDivision == Division && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesPro.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesPro >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                MesVar = MesVC - MesPro;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVar >= 0 ? MesVar.ToString("N2") : "(" + (MesVar * - 1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVarPor >= 0 ? MesVarPor.ToString("N2") + "%" : "(" + (MesVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            }

                            #region Totales del subtitulo

                            TotalGeneralVC = oListaReporte.Where(x => x.desDivision == Division && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.desDivision == Division && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar >= 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor >= 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.CompleteRow();

                            #endregion

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            //1 - Agrupando por división
                            oListaArticulos = oListaReal.Where(x => x.desDivision == Division).ToList();
                            //2 - Agrupando la lista por articulos(Especie)
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                //Articulo
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaPor = 0;
                                }

                                //Total Fila
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                TablaDetalle.CompleteRow();

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaPor = 0;
                            }
                        }

                        //Linea Final
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC > 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron > 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar > 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor > 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC > 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalGeneralVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron > 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalGeneralPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar > 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor > 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        TablaDetalle.CompleteRow();

                        docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                        #endregion
                    }

                    #endregion

                    #region Reporte 5

                    if (TipoReporte == 5)
                    {
                        //Variable para sacar con las fechas indicadas
                        List<EmisionDocumentoE> oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                                                          where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                                                          orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                                                          select x).ToList());
                        //Nueva agrupación con la nueva lista creada
                        oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();

                        #region Cabecera del Detalle

                        Columnas = (oListaCabecera.Count * 4) + 5; //Total de columnas
                        docPdf.Add(DetalleCabeceras(oListaCabecera)); //Agregando las cabeceras del detalle

                        #endregion

                        #region Detalle

                        TablaDetalle = new PdfPTable(Columnas)
                        {
                            WidthPercentage = 100
                        };

                        TablaDetalle.SetWidths(ArrayColumnas);

                        //Lista nueva agrupada por Zona de Trabajo
                        List<EmisionDocumentoE> oListaZonas = oListaReal.GroupBy(x => x.desZonaTrabajo).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaZonas.Count; i++)
                        {
                            //Para poder colocar la linea Bottom de la cabecera del detalle
                            if (i == 0)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSubtitulo, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.CompleteRow();
                            }

                            //Zona de trabajo
                            Zona = oListaZonas[i].desZonaTrabajo;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Zona, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0));

                            //Recorriendo para colocar el subtitulo del detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.desZonaTrabajo == Zona && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.desZonaTrabajo == Zona && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesPro.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesPro >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                MesVar = MesVC - MesPro;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVar >= 0 ? MesVar.ToString("N2") : "(" + (MesVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVarPor >= 0 ? MesVarPor.ToString("N2") + "%" : "(" + (MesVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            }

                            #region Totales del subtitulo

                            TotalGeneralVC = oListaReporte.Where(x => x.desZonaTrabajo == Zona && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.desZonaTrabajo == Zona && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar >= 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor >= 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.CompleteRow();

                            #endregion

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            //1 - Agrupando por zona de trabajo
                            oListaArticulos = oListaReal.Where(x => x.desZonaTrabajo == Zona).ToList();
                            //2 - Agrupando la lista por articulos(Especie)
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                //Articulo
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.desDivision == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                }
                                
                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaPor = 0;
                                }

                                //Total Fila
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                TablaDetalle.CompleteRow();

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaPor = 0;
                            }
                        }

                        //Linea Final
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC > 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron > 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar > 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor > 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC > 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalGeneralVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron > 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalGeneralPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar > 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor > 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        TablaDetalle.CompleteRow();

                        docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                        #endregion
                    }

                    #endregion

                    #region Reporte 6

                    if (TipoReporte == 6)
                    {
                        //Variable para sacar con las fechas indicadas
                        List<EmisionDocumentoE> oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                                                          where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                                                          orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                                                          select x).ToList());
                        //Nueva agrupación con la nueva lista creada
                        oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();

                        #region Cabecera del Detalle

                        Columnas = (oListaCabecera.Count * 4) + 5; //Total de columnas
                        docPdf.Add(DetalleCabeceras(oListaCabecera)); //Agregando las cabeceras del detalle

                        #endregion

                        #region Detalle

                        TablaDetalle = new PdfPTable(Columnas)
                        {
                            WidthPercentage = 100
                        };

                        TablaDetalle.SetWidths(ArrayColumnas);

                        //Lista nueva agrupada por Vendedor
                        List<EmisionDocumentoE> oListaVendedor = oListaReal.GroupBy(x => x.nomVendedor).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaVendedor.Count; i++)
                        {
                            //Para poder colocar la linea Bottom de la cabecera del detalle
                            if (i == 0)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSubtitulo, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.CompleteRow();
                            }

                            //Vendedor
                            Vendedor = oListaVendedor[i].nomVendedor;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Vendedor, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0));

                            //Recorriendo para colocar el subtitulo del detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.nomVendedor == Vendedor && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.nomVendedor == Vendedor && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesPro.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesPro >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                MesVar = MesVC - MesPro;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVar >= 0 ? MesVar.ToString("N2") : "(" + (MesVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVarPor >= 0 ? MesVarPor.ToString("N2") + "%" : "(" + (MesVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            }

                            #region Totales del subtitulo

                            TotalGeneralVC = oListaReporte.Where(x => x.nomVendedor == Vendedor && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.nomVendedor == Vendedor && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar >= 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor >= 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.CompleteRow();

                            #endregion

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            //1 - Agrupando ariculos por vendedor
                            oListaArticulos = oListaReal.Where(x => x.nomVendedor == Vendedor).ToList();
                            //2 - Agrupando la lista por articulos(Especie)
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                //Articulo
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaPor = 0;
                                }

                                //Total Fila
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                TablaDetalle.CompleteRow();

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaPor = 0;
                            }
                        }

                        //Linea Final
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC > 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron > 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar > 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor > 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC > 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalGeneralVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron > 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalGeneralPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar > 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor > 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        TablaDetalle.CompleteRow();

                        docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                        #endregion
                    }

                    #endregion

                    #region Reporte 7

                    if (TipoReporte == 7)
                    {
                        //Variable para sacar con las fechas indicadas
                        List<EmisionDocumentoE> oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                                                          where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                                                          orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                                                          select x).ToList());
                        //Nueva agrupación con la nueva lista creada
                        oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();

                        #region Cabecera del Detalle

                        Columnas = (oListaCabecera.Count * 4) + 5; //Total de columnas
                        docPdf.Add(DetalleCabeceras(oListaCabecera)); //Agregando las cabeceras del detalle

                        #endregion

                        #region Detalle

                        TablaDetalle = new PdfPTable(Columnas)
                        {
                            WidthPercentage = 100
                        };

                        TablaDetalle.SetWidths(ArrayColumnas);

                        //Lista nueva agrupada por División
                        List<EmisionDocumentoE> oListaDivision = oListaReal.GroupBy(x => x.desDivision).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaDivision.Count; i++)
                        {
                            //Para poder colocar la linea Bottom de la cabecera del detalle
                            if (i == 0)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSubtitulo, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.CompleteRow();
                            }

                            //División
                            Division = oListaDivision[i].desDivision;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Division, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0));

                            //Recorriendo para colocar el subtitulo del detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.desDivision == Division && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.desDivision == Division && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesPro.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesPro >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                MesVar = MesVC - MesPro;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVar >= 0 ? MesVar.ToString("N2") : "(" + (MesVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVarPor >= 0 ? MesVarPor.ToString("N2") + "%" : "(" + (MesVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            }

                            #region Totales del subtitulo

                            TotalGeneralVC = oListaReporte.Where(x => x.desDivision == Division && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.desDivision == Division && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar >= 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor >= 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.CompleteRow();

                            #endregion

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            //1 - Agrupando articulos por división
                            oListaArticulos = oListaReal.Where(x => x.desDivision == Division).ToList();
                            //2 - Agrupando la lista por articulos
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                //Articulo
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReporte.Where(x => x.desDivision == Division
                                                                        && x.nomArticulo == item.nomArticulo
                                                                        && x.nomMes == oListaCabecera[c].nomMes
                                                                        && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReporte.Where(x => x.desDivision == Division
                                                                        && x.nomArticulo == item.nomArticulo
                                                                        && x.nomMes == oListaCabecera[c].nomMes
                                                                        && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaPor = 0;
                                }

                                //Total Fila
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                TablaDetalle.CompleteRow();

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaPor = 0;
                            }
                        }

                        //Linea Final
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC > 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron > 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar > 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor > 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC > 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalGeneralVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron > 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalGeneralPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar > 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor > 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        TablaDetalle.CompleteRow();

                        docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                        #endregion
                    }

                    #endregion

                    #region Reporte 8

                    if (TipoReporte == 8)
                    {
                        //Variable para sacar con las fechas indicadas
                        List<EmisionDocumentoE> oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                                                          where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                                                          orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                                                          select x).ToList());
                        //Nueva agrupación con la nueva lista creada
                        oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();

                        #region Cabecera del Detalle

                        Columnas = (oListaCabecera.Count * 4) + 5; //Total de columnas
                        docPdf.Add(DetalleCabeceras(oListaCabecera)); //Agregando las cabeceras del detalle

                        #endregion

                        #region Detalle

                        TablaDetalle = new PdfPTable(Columnas)
                        {
                            WidthPercentage = 100
                        };

                        TablaDetalle.SetWidths(ArrayColumnas);

                        //Lista nueva agrupada por Zona de Trabajo
                        List<EmisionDocumentoE> oListaZonas = oListaReal.GroupBy(x => x.desZonaTrabajo).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaZonas.Count; i++)
                        {
                            //Para poder colocar la linea Bottom de la cabecera del detalle
                            if (i == 0)
                            {
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S" + (Columnas - 4).ToString(), "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSubtitulo, "S", ColorLinea, FontFactory.GetFont("Arial", 1.25f), 5, 2, "S4", "N", 0f, 0f, "S", "N", "N", "N", 1f));
                                TablaDetalle.CompleteRow();
                            }

                            //Zona de trabajo
                            Zona = oListaZonas[i].desZonaTrabajo;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(Zona, ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 0));

                            //Recorriendo para colocar el subtitulo del detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.desZonaTrabajo == Zona && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.desZonaTrabajo == Zona && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesPro.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesPro >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                MesVar = MesVC - MesPro;
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVar >= 0 ? MesVar.ToString("N2") : "(" + (MesVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(MesVarPor >= 0 ? MesVarPor.ToString("N2") + "%" : "(" + (MesVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (MesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            }

                            #region Totales del Subtitulo

                            TotalGeneralVC = oListaReporte.Where(x => x.desZonaTrabajo == Zona && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.desZonaTrabajo == Zona && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron.ToString("N2"), ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar >= 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor >= 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + ")%", ColorSubtitulo, "N", null, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                            TablaDetalle.CompleteRow();

                            #endregion

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            //1 - Agrupando articulos por zona de trabajo
                            oListaArticulos = oListaReal.Where(x => x.desZonaTrabajo == Zona).ToList();
                            //2 - Agrupando la lista por articulos
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                //Articulo
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5.25f), 5, 0));

                                //Meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC >= 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron >= 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar >= 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                    TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor >= 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", null, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.desZonaTrabajo == Zona
                                                                        && x.nomArticulo == item.nomArticulo
                                                                        && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.desZonaTrabajo == Zona
                                                                        && x.nomArticulo == item.nomArticulo
                                                                        && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaPor = 0;
                                }

                                //Total Fila
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVC >= 0 ? TotalFilaVC.ToString("N2") : "(" + (TotalFilaVC * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPron >= 0 ? TotalFilaPron.ToString("N2") : "(" + (TotalFilaPron * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaVar >= 0 ? TotalFilaVar.ToString("N2") : "(" + (TotalFilaVar * -1).ToString("N2") + ")", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));
                                TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFilaPor >= 0 ? TotalFilaPor.ToString("N2") + "%" : "(" + (TotalFilaPor * -1).ToString("N2") + "%)", ColorCabDeta, "N", null, FontFactory.GetFont("Arial", 5.25f, (TotalFilaPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 5, 2));

                                TablaDetalle.CompleteRow();

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaPor = 0;
                            }
                        }

                        //Linea Final
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReal.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVC > 0 ? TotalMesVC.ToString("N2") : "(" + (TotalMesVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesPron > 0 ? TotalMesPron.ToString("N2") : "(" + (TotalMesPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVar > 0 ? TotalMesVar.ToString("N2") : "(" + (TotalMesVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                            TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalMesVarPor > 0 ? TotalMesVarPor.ToString("N2") + "%" : "(" + (TotalMesVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalMesVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVC > 0 ? TotalGeneralVC.ToString("N2") : "(" + (TotalGeneralVC * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVC >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralPron > 0 ? TotalGeneralPron.ToString("N2") : "(" + (TotalGeneralPron * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralPron >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVar > 0 ? TotalGeneralVar.ToString("N2") : "(" + (TotalGeneralVar * -1).ToString("N2") + ")", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVar >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));
                        TablaDetalle.AddCell(ReaderHelper.NuevaCelda(TotalGeneralVarPor > 0 ? TotalGeneralVarPor.ToString("N2") + "%" : "(" + (TotalGeneralVarPor * -1).ToString("N2") + "%)", ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 5.25f, iTextSharp.text.Font.BOLD, (TotalGeneralVarPor >= 0 ? BaseColor.BLACK : BaseColor.RED)), 2, 2, "N", "N", 4, 4, "S", "S", "S", "S", 1f));

                        TablaDetalle.CompleteRow();

                        docPdf.Add(TablaDetalle); //Añadiendo la tabla al documento PDF

                        #endregion
                    }

                    #endregion

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

        void ExportarExcel(String Ruta)
        {
            List<EmisionDocumentoE> oListaCabecera = null;
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String Mon = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
            String anio = dtpInicio.Value.ToString("yyyy");
            String Subtitulo = "Año Facturación: " + anio;

            TituloGeneral = Titulo.ToUpper();

            #region Nombre Pestaña Excel

            switch (Convert.ToInt32(cboTipoReporte.SelectedValue))
            {
                case 1:
                    NombrePestaña = "Vta.Vend.Prod.";
                    break;
                case 2:
                    NombrePestaña = "Vta.Especie";
                    break;
                case 3:
                    NombrePestaña = "Vta.Prod.";
                    break;
                case 4:
                    NombrePestaña = "Vta.Esp.Div.";
                    break;
                case 5:
                    NombrePestaña = "Vta.Esp.Zon.";
                    break;
                case 6:
                    NombrePestaña = "Vta.Esp.Vend.";
                    break;
                case 7:
                    NombrePestaña = "Vta.Prod.Div.";
                    break;
                case 8:
                    NombrePestaña = "Vta.Prod.Zon.";
                    break;
                default:
                    break;
            } 

            #endregion

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);
            
            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                #region Variables

                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);
                List<EmisionDocumentoE> oListaArticulos = null;
                String Vendedor = String.Empty;
                String Division = String.Empty;
                String Zona = String.Empty;
                String nomArticulo = String.Empty;
                Int32 IniLinea = 1; //Linea 1
                Int32 totColumnasGen = 0;

                Decimal TotalFilaVC = 0;
                Decimal TotalFilaPron = 0;
                Decimal TotalFilaVar = 0;
                Decimal TotalFilaVarPor = 0;
                Decimal TotalMesVC = 0;
                Decimal TotalMesPron = 0;
                Decimal TotalMesVar = 0;
                Decimal TotalMesVarPor = 0;
                Decimal TotalGeneralVC = 0;
                Decimal TotalGeneralPron = 0;
                Decimal TotalGeneralVar = 0;
                Decimal TotalGeneralVarPor = 0;
                Decimal MesVC = 0;
                Decimal MesPro = 0;
                Decimal MesVar = 0;
                Decimal MesVarPor = 0;

                //Meses para el filtro de la nueva lista
                Int32 MesIni = dtpInicio.Value.Month;
                Int32 MesFin = dtpFinal.Value.Month;
                List<EmisionDocumentoE> oListaReal = null;

                #endregion

                if (oHoja != null)
                {
                    //Variable para sacar con las fechas indicadas
                    oListaReal = new List<EmisionDocumentoE>((from x in oListaReporte
                                                              where Convert.ToInt32(x.Mes) >= MesIni && Convert.ToInt32(x.Mes) <= MesFin
                                                              orderby x.Mes, x.nomVendedor, x.nomArticulo, x.Tipo
                                                              select x).ToList());

                    //Nueva agrupación con la nueva lista creada
                    oListaCabecera = oListaReal.GroupBy(x => x.nomMes).Select(g => g.First()).ToList();
                    totColumnasGen = (oListaCabecera.Count * 4) + (Presentacion == 3 ? 6 : 5);

                    #region Titulos Principales

                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[IniLinea, 1, IniLinea, totColumnasGen])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 13, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    oHoja.Row(IniLinea).Height = 20.25;
                    IniLinea++; //Linea 2
                    oHoja.Row(IniLinea).Height = 11.25;
                    IniLinea++; //Linea 3
                    oHoja.Cells["A3"].Value = Subtitulo;

                    using (ExcelRange Rango = oHoja.Cells[IniLinea, 1, IniLinea, totColumnasGen])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                    }

                    IniLinea++; //Linea 4
                    oHoja.Row(IniLinea).Height = 11.25;

                    #endregion Titulos Principales

                    #region Cabeceras del Detalle

                    IniLinea++; //Linea 5
                    oHoja.Cells["A5"].Value = "DESCRIPCION";
                    
                    using (ExcelRange Rango = oHoja.Cells[IniLinea, 1, IniLinea + 1, 1])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    if (Presentacion == 3)
                    {
                        oHoja.Cells["B5"].Value = "UN M.";

                        using (ExcelRange Rango = oHoja.Cells[IniLinea, 2, IniLinea + 1, 2])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.White);
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }
                    }

                    Int32 ColTmp = (Presentacion == 3 ? 3 : 2);
                    Int32 ColSub = (Presentacion == 3 ? 3 : 2);
                    String[] SubTitulos = new String[] { "VENTA", "PRON", "VAR", "VAR %" };

                    foreach (EmisionDocumentoE item in oListaCabecera)
                    {
                        oHoja.Cells[IniLinea, ColTmp].Value = item.nomMes;

                        using (ExcelRange Rango = oHoja.Cells[IniLinea, ColTmp, IniLinea, ColTmp + 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.White);
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        foreach (String itemSub in SubTitulos)
                        {
                            oHoja.Cells[IniLinea + 1, ColSub].Value = itemSub;
                            oHoja.Cells[IniLinea + 1, ColSub].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea + 1, ColSub].Style.Font.Color.SetColor(Color.White);
                            oHoja.Cells[IniLinea + 1, ColSub].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea + 1, ColSub].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea + 1, ColSub].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            oHoja.Cells[IniLinea + 1, ColSub].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[IniLinea + 1, ColSub].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            ColSub++;
                        }

                        ColTmp += 4;
                    }

                    #region Ultima Columna

                    oHoja.Cells[IniLinea, ColTmp].Value = "TOTAL GENERAL";

                    using (ExcelRange Rango = oHoja.Cells[IniLinea, ColTmp, IniLinea, ColTmp + 3])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    foreach (String itemSub in SubTitulos)
                    {
                        oHoja.Cells[IniLinea + 1, ColSub].Value = itemSub;
                        oHoja.Cells[IniLinea + 1, ColSub].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea + 1, ColSub].Style.Font.Color.SetColor(Color.White);
                        oHoja.Cells[IniLinea + 1, ColSub].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea + 1, ColSub].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea + 1, ColSub].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        oHoja.Cells[IniLinea + 1, ColSub].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[IniLinea + 1, ColSub].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        ColSub++;
                    }

                    #endregion

                    #endregion Cabeceras del Detalle
                    
                    #region Reporte 1

                    if (TipoReporte == 1)
                    {
                        IniLinea += 2;

                        #region Detalle

                        //Lista nueva agrupada por Vendedor
                        List<EmisionDocumentoE> oListaVendedor = oListaReal.GroupBy(x => x.nomVendedor).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaVendedor.Count; i++)
                        {
                            ColTmp = 2;

                            #region SubTitulos

                            //Vendedor
                            Vendedor = oListaVendedor[i].nomVendedor;

                            oHoja.Cells[IniLinea, 1].Value = Vendedor;
                            oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));

                            //Recorriendo para colocar el subtitulo del Detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.nomVendedor == Vendedor && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.nomVendedor == Vendedor && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                MesVar = MesVC - MesPro;

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesPro;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)"; // "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                ColTmp++;
                            }

                            TotalGeneralVC = oListaReporte.Where(x => x.nomVendedor == Vendedor && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.nomVendedor == Vendedor && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Pronostico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            IniLinea++;

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            #endregion

                            #region Detalle

                            //1 - Agrupando ariculos por vendedor
                            oListaArticulos = oListaReal.Where(x => x.nomVendedor == Vendedor).ToList();
                            //2 - Agrupando la lista por articulos(Especie)
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                ColTmp = 2; //Inicializando la columna en 2

                                //Articulo
                                oHoja.Cells[IniLinea, 1].Value = item.nomArticulo;
                                oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                //Los meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    //Ventas - Cantidad
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Pronóstico
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación Porcentaje
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    ColTmp++;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                        && x.nomArticulo == item.nomArticulo
                                                                        && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                        && x.nomArticulo == item.nomArticulo
                                                                        && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                                IniLinea++;

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaVarPor = 0;
                            } 

                            #endregion
                        }

                        #region Linea Final

                        oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                        oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        ColTmp = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp++;
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        //Ventas - Cantidad
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Pronóstico
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación Porcentaje
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184)); 
                        
                        #endregion

                        #endregion
                    }

                    #endregion

                    #region Reporte 2

                    if (TipoReporte == 2)
                    {
                        IniLinea += 2;

                        #region Detalle

                        //Lista nueva agrupada por Especie
                        List<EmisionDocumentoE> oListaEspecies = oListaReal.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaEspecies.Count; i++)
                        {
                            ColTmp = 2;

                            #region Detalle

                            //Articulo
                            nomArticulo = oListaEspecies[i].nomArticulo;

                            oHoja.Cells[IniLinea, 1].Value = nomArticulo;
                            oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                            //Los meses
                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                TotalMesVC = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                && x.nomMes == oListaCabecera[c].nomMes
                                                                && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalMesPron = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                && x.nomMes == oListaCabecera[c].nomMes
                                                                && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalMesVar = TotalMesVC - TotalMesPron;

                                if (TotalMesPron > 0)
                                {
                                    TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                }
                                else
                                {
                                    TotalMesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                ColTmp++;
                            }

                            //Agregado
                            TotalFilaVC = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalFilaPron = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TotalFilaVar = TotalFilaVC - TotalFilaPron;

                            if (TotalFilaPron > 0)
                            {
                                TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                            }
                            else
                            {
                                TotalFilaVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                            IniLinea++;

                            //Limpiando las variables
                            TotalFilaVC = 0;
                            TotalFilaPron = 0;
                            TotalFilaVar = 0;
                            TotalFilaVarPor = 0;

                            #endregion
                        }

                        #region Linea Final

                        oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                        oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        ColTmp = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp++;
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        //Ventas - Cantidad
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Pronóstico
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación Porcentaje
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        #endregion

                        #endregion

                    }

                    #endregion

                    #region Reporte 3

                    if (TipoReporte == 3)
                    {
                        IniLinea += 2;

                        if (Presentacion == 1 || Presentacion == 2)
                        {
                            #region Detalle

                            //Lista nueva agrupada por articulo
                            oListaArticulos = oListaReal.GroupBy(x => new { x.nomArticulo }).Select(g => g.First()).ToList();

                            for (int i = 0; i < oListaArticulos.Count; i++)
                            {
                                ColTmp = 2;

                                #region Detalle

                                //Articulo
                                nomArticulo = oListaArticulos[i].nomArticulo;

                                oHoja.Cells[IniLinea, 1].Value = nomArticulo;
                                oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                //Los meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    //Ventas - Cantidad
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Pronóstico
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación Porcentaje
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    ColTmp++;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                                IniLinea++;

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaVarPor = 0;

                                #endregion
                            }

                            #region Linea Final

                            oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                            oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp = 2;

                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TotalMesVar = TotalMesVC - TotalMesPron;

                                if (TotalMesPron > 0)
                                {
                                    TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                }
                                else
                                {
                                    TotalMesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                                ColTmp++;
                            }

                            //Agregado
                            TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron > 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            #endregion

                            #endregion 
                        }
                        else
                        {
                            #region Detalle

                            //Lista nueva agrupada por articulo y unidad de Medida
                            oListaArticulos = oListaReal.GroupBy(x => new { x.nomArticulo, x.nomUMedida }).Select(g => g.First()).ToList();

                            for (int i = 0; i < oListaArticulos.Count; i++)
                            {
                                ColTmp = 3;

                                #region Detalle

                                //Articulo
                                oHoja.Cells[IniLinea, 1].Value = nomArticulo = oListaArticulos[i].nomArticulo;
                                oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                //Unidad de Medida
                                oHoja.Cells[IniLinea, 2].Value = oListaArticulos[i].nomUMedida;
                                oHoja.Cells[IniLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                //Los meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.nomUMedida == oListaArticulos[i].nomUMedida
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.nomUMedida == oListaArticulos[i].nomUMedida
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    //Ventas - Cantidad
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Pronóstico
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación Porcentaje
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    ColTmp++;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.nomArticulo == nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                                IniLinea++;

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaVarPor = 0;

                                #endregion
                            }

                            #region Linea Final

                            oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                            oHoja.Cells[IniLinea, 1, IniLinea, 2].Merge = true;
                            oHoja.Cells[IniLinea, 1, IniLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, 1, IniLinea, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, 1, IniLinea, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, 1, IniLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp = 3;

                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                TotalMesVar = TotalMesVC - TotalMesPron;

                                if (TotalMesPron > 0)
                                {
                                    TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                }
                                else
                                {
                                    TotalMesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                                ColTmp++;
                            }

                            //Agregado
                            TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron > 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            #endregion

                            #endregion 
                        }
                    }

                    #endregion

                    #region Reporte 4

                    if (TipoReporte == 4)
                    {
                        IniLinea += 2;

                        #region Detalle

                        //Lista nueva agrupada por División
                        List<EmisionDocumentoE> oListaDivision = oListaReal.GroupBy(x => x.desDivision).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaDivision.Count; i++)
                        {
                            ColTmp = 2;

                            #region SubTitulos

                            //División
                            Division = oListaDivision[i].desDivision;

                            oHoja.Cells[IniLinea, 1].Value = Division;
                            oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));

                            //Recorriendo para colocar el subtitulo del Detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.desDivision == Division && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.desDivision == Division && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                MesVar = MesVC - MesPro;

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Pronostico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesPro;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)"; // "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                ColTmp++;
                            }

                            TotalGeneralVC = oListaReporte.Where(x => x.desDivision == Division && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.desDivision == Division && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Pronostico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";// "#,##0.00;[Red](#,##0.00)";// "###,###,##0.00";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            IniLinea++;

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            #endregion

                            #region Detalle

                            //1 - Agrupando por división
                            oListaArticulos = oListaReal.Where(x => x.desDivision == Division).ToList();
                            //2 - Agrupando la lista por articulos(Especie)
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                ColTmp = 2; //Inicializando la columna en 2

                                //Articulo
                                oHoja.Cells[IniLinea, 1].Value = item.nomArticulo;
                                oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                //Los meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    //Ventas - Cantidad
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Pronóstico
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación Porcentaje
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    ColTmp++;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                                IniLinea++;

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaVarPor = 0;
                            }

                            #endregion
                        }

                        #region Linea Final

                        oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                        oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        ColTmp = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp++;
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        //Ventas - Cantidad
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Pronóstico
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación Porcentaje
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        #endregion

                        #endregion
                    }

                    #endregion

                    #region Reporte 5

                    if (TipoReporte == 5)
                    {
                        IniLinea += 2;

                        #region Detalle

                        //Lista nueva agrupada por Zona de Trabajo
                        List<EmisionDocumentoE> oListaZonas = oListaReal.GroupBy(x => x.desZonaTrabajo).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaZonas.Count; i++)
                        {
                            ColTmp = 2;

                            #region SubTitulos

                            //Zona de trabajo
                            Zona = oListaZonas[i].desZonaTrabajo;

                            oHoja.Cells[IniLinea, 1].Value = Zona;
                            oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));

                            //Recorriendo para colocar el subtitulo del Detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.desZonaTrabajo == Zona && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.desZonaTrabajo == Zona && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                MesVar = MesVC - MesPro;

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Pronostico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesPro;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                ColTmp++;
                            }

                            TotalGeneralVC = oListaReporte.Where(x => x.desZonaTrabajo == Zona && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.desZonaTrabajo == Zona && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Pronostico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            IniLinea++;

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            #endregion

                            #region Detalle

                            //1 - Agrupando por zona de trabajo
                            oListaArticulos = oListaReal.Where(x => x.desZonaTrabajo == Zona).ToList();
                            //2 - Agrupando la lista por articulos(Especie)
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                ColTmp = 2; //Inicializando la columna en 2

                                //Articulo
                                oHoja.Cells[IniLinea, 1].Value = item.nomArticulo;
                                oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                //Los meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    //Ventas - Cantidad
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Pronóstico
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación Porcentaje
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    ColTmp++;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                                IniLinea++;

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaVarPor = 0;
                            }

                            #endregion
                        }

                        #region Linea Final

                        oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                        oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        ColTmp = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp++;
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        //Ventas - Cantidad
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Pronóstico
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación Porcentaje
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        #endregion

                        #endregion
                    }

                    #endregion

                    #region Reporte 6

                    if (TipoReporte == 6)
                    {
                        IniLinea += 2;

                        #region Detalle

                        // Lista nueva agrupada por Vendedor
                        List<EmisionDocumentoE> oListaVendedor = oListaReal.GroupBy(x => x.nomVendedor).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaVendedor.Count; i++)
                        {
                            ColTmp = 2;

                            #region SubTitulos

                            //Vendedor
                            Vendedor = oListaVendedor[i].nomVendedor;

                            oHoja.Cells[IniLinea, 1].Value = Vendedor;
                            oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));

                            //Recorriendo para colocar el subtitulo del Detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.nomVendedor == Vendedor && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.nomVendedor == Vendedor && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                MesVar = MesVC - MesPro;

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Pronostico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesPro;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                ColTmp++;
                            }

                            TotalGeneralVC = oListaReporte.Where(x => x.nomVendedor == Vendedor && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.nomVendedor == Vendedor && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Pronostico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            IniLinea++;

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            #endregion

                            #region Detalle

                            //1 - Agrupando ariculos por vendedor
                            oListaArticulos = oListaReal.Where(x => x.nomVendedor == Vendedor).ToList();
                            //2 - Agrupando la lista por articulos(Especie)
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                ColTmp = 2; //Inicializando la columna en 2

                                //Articulo
                                oHoja.Cells[IniLinea, 1].Value = item.nomArticulo;
                                oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                //Los meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.nomVendedor == Vendedor
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    //Ventas - Cantidad
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Pronóstico
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación Porcentaje
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    ColTmp++;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                        && x.nomArticulo == item.nomArticulo
                                                                        && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.nomVendedor == Vendedor
                                                                        && x.nomArticulo == item.nomArticulo
                                                                        && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                                IniLinea++;

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaVarPor = 0;
                            }

                            #endregion
                        }

                        #region Linea Final

                        oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                        oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        ColTmp = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp++;
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        //Ventas - Cantidad
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Pronóstico
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación Porcentaje
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        #endregion

                        #endregion
                    }

                    #endregion

                    #region Reporte 7

                    if (TipoReporte == 7)
                    {
                        IniLinea += 2;

                        #region Detalle

                        //Lista nueva agrupada por División
                        List<EmisionDocumentoE> oListaDivision = oListaReal.GroupBy(x => x.desDivision).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaDivision.Count; i++)
                        {
                            ColTmp = 2;

                            #region SubTitulos

                            //División
                            Division = oListaDivision[i].desDivision;

                            oHoja.Cells[IniLinea, 1].Value = Division;
                            oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));

                            //Recorriendo para colocar el subtitulo del Detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.desDivision == Division && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.desDivision == Division && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                MesVar = MesVC - MesPro;

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Pronostico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesPro;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                ColTmp++;
                            }

                            TotalGeneralVC = oListaReporte.Where(x => x.desDivision == Division && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.desDivision == Division && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Pronostico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            IniLinea++;

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            #endregion

                            #region Detalle

                            //1 - Agrupando articulos por división
                            oListaArticulos = oListaReal.Where(x => x.desDivision == Division).ToList();
                            //2 - Agrupando la lista por articulos
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                ColTmp = 2; //Inicializando la columna en 2

                                //Articulo
                                oHoja.Cells[IniLinea, 1].Value = item.nomArticulo;
                                oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                //Los meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    //Ventas - Cantidad
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Pronóstico
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación Porcentaje
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    ColTmp++;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.desDivision == Division
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                                IniLinea++;

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaVarPor = 0;
                            }

                            #endregion
                        }

                        #region Linea Final

                        oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                        oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        ColTmp = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp++;
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        //Ventas - Cantidad
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Pronóstico
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación Porcentaje
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        #endregion

                        #endregion
                    }

                    #endregion

                    #region Reporte 8

                    if (TipoReporte == 8)
                    {
                        IniLinea += 2;

                        #region Detalle

                        //Lista nueva agrupada por Zona de Trabajo
                        List<EmisionDocumentoE> oListaZonas = oListaReal.GroupBy(x => x.desZonaTrabajo).Select(g => g.First()).ToList();

                        for (int i = 0; i < oListaZonas.Count; i++)
                        {
                            ColTmp = 2;

                            #region SubTitulos

                            //Zona de trabajo
                            Zona = oListaZonas[i].desZonaTrabajo;

                            oHoja.Cells[IniLinea, 1].Value = Zona;
                            oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));

                            //Recorriendo para colocar el subtitulo del Detalle
                            foreach (EmisionDocumentoE item in oListaCabecera)
                            {
                                MesVC = oListaReal.Where(x => x.nomMes == item.nomMes && x.desZonaTrabajo == Zona && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                MesPro = oListaReal.Where(x => x.nomMes == item.nomMes && x.desZonaTrabajo == Zona && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                                MesVar = MesVC - MesPro;

                                if (MesPro != 0)
                                {
                                    MesVarPor = (MesVar / MesPro) * 100;
                                }
                                else
                                {
                                    MesVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Pronostico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesPro;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = MesVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                ColTmp++;
                            }

                            TotalGeneralVC = oListaReporte.Where(x => x.desZonaTrabajo == Zona && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalGeneralPron = oListaReporte.Where(x => x.desZonaTrabajo == Zona && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                            if (TotalGeneralPron != 0)
                            {
                                TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100;
                            }
                            else
                            {
                                TotalGeneralVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Pronostico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 240, 245));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            IniLinea++;

                            TotalGeneralVC = 0;
                            TotalGeneralPron = 0;
                            TotalGeneralVar = 0;
                            TotalGeneralVarPor = 0;

                            #endregion

                            #region Detalle

                            //1 - Agrupando articulos por zona de trabajo
                            oListaArticulos = oListaReal.Where(x => x.desZonaTrabajo == Zona).ToList();
                            //2 - Agrupando la lista por articulos
                            oListaArticulos = oListaArticulos.GroupBy(x => x.nomArticulo).Select(g => g.First()).ToList();

                            foreach (EmisionDocumentoE item in oListaArticulos)
                            {
                                ColTmp = 2; //Inicializando la columna en 2

                                //Articulo
                                oHoja.Cells[IniLinea, 1].Value = item.nomArticulo;
                                oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                //Los meses
                                for (int c = 0; c < oListaCabecera.Count; c++)
                                {
                                    TotalMesVC = oListaReal.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                    TotalMesPron = oListaReal.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.nomMes == oListaCabecera[c].nomMes
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                    TotalMesVar = TotalMesVC - TotalMesPron;

                                    if (TotalMesPron > 0)
                                    {
                                        TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                                    }
                                    else
                                    {
                                        TotalMesVarPor = 0;
                                    }

                                    //Ventas - Cantidad
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Pronóstico
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    //Variación Porcentaje
                                    ColTmp++;
                                    oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                                    oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                    oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                    oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    ColTmp++;
                                }

                                //Agregado
                                TotalFilaVC = oListaReporte.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                                TotalFilaPron = oListaReporte.Where(x => x.desZonaTrabajo == Zona
                                                                    && x.nomArticulo == item.nomArticulo
                                                                    && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);

                                TotalFilaVar = TotalFilaVC - TotalFilaPron;

                                if (TotalFilaPron > 0)
                                {
                                    TotalFilaVarPor = (TotalFilaVar / TotalFilaPron) * 100M;
                                }
                                else
                                {
                                    TotalFilaVarPor = 0;
                                }

                                //Ventas - Cantidad
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVC;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Pronóstico
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaPron;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVar;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                                //Variación Porcentaje
                                ColTmp++;
                                oHoja.Cells[IniLinea, ColTmp].Value = TotalFilaVarPor / 100M;
                                oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                                oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));

                                IniLinea++;

                                //Limpiando las variables
                                TotalFilaVC = 0;
                                TotalFilaPron = 0;
                                TotalFilaVar = 0;
                                TotalFilaVarPor = 0;
                            }

                            #endregion
                        }

                        #region Linea Final

                        oHoja.Cells[IniLinea, 1].Value = "TOTAL GENERAL";
                        oHoja.Cells[IniLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        ColTmp = 2;

                        foreach (EmisionDocumentoE item in oListaCabecera)
                        {
                            TotalMesVC = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                            TotalMesPron = oListaReporte.Where(x => x.nomMes == item.nomMes && x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                            TotalMesVar = TotalMesVC - TotalMesPron;

                            if (TotalMesPron > 0)
                            {
                                TotalMesVarPor = (TotalMesVar / TotalMesPron) * 100M;
                            }
                            else
                            {
                                TotalMesVarPor = 0;
                            }

                            //Ventas - Cantidad
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVC;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Pronóstico
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesPron;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVar;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                            //Variación Porcentaje
                            ColTmp++;
                            oHoja.Cells[IniLinea, ColTmp].Value = TotalMesVarPor / 100M;
                            oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                            oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                            oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                            ColTmp++;
                        }

                        //Agregado
                        TotalGeneralVC = oListaReporte.Where(x => x.Tipo == "Ventas").ToList().Sum(x => x.totTotal);
                        TotalGeneralPron = oListaReporte.Where(x => x.Tipo == "Presupuesto").ToList().Sum(x => x.totTotal);
                        TotalGeneralVar = TotalGeneralVC - TotalGeneralPron;

                        if (TotalGeneralPron > 0)
                        {
                            TotalGeneralVarPor = (TotalGeneralVar / TotalGeneralPron) * 100M;
                        }
                        else
                        {
                            TotalGeneralVarPor = 0;
                        }

                        //Ventas - Cantidad
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVC;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Pronóstico
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralPron;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVar;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00_);[RED](#,##0.00)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));
                        //Variación Porcentaje
                        ColTmp++;
                        oHoja.Cells[IniLinea, ColTmp].Value = TotalGeneralVarPor / 100M;
                        oHoja.Cells[IniLinea, ColTmp].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                        oHoja.Cells[IniLinea, ColTmp].Style.Numberformat.Format = "#,##0.00%_);[RED](#,##0.00%)";
                        oHoja.Cells[IniLinea, ColTmp].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[IniLinea, ColTmp].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 182, 210));
                        oHoja.Cells[IniLinea, ColTmp].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.FromArgb(84, 139, 184));

                        #endregion

                        #endregion
                    }

                    #endregion

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();
                    oHoja.Column(1).Width = 50;

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
                    oHoja.Workbook.Properties.Category = "Módulo de Ventas";
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

        void CambioTipo()
        {
            if (cboPresentacion.SelectedIndex == 0)
            {
                cboMoneda.Enabled = true;
            }
            if (cboPresentacion.SelectedIndex == 1 || cboPresentacion.SelectedIndex == 2)
            {
                cboMoneda.Enabled = false;
                cboMoneda.SelectedIndex = 1;
            }
        }

        PdfPTable DetalleCabeceras(List<EmisionDocumentoE> oListaCabecera)
        {
            PdfPTable TablaCab = null;
            Int32 Columnas = 0;
            String[] ArrayTitulos = null;
            String[] ArrayTitulos_2 = null;
            Int32 s = 0;
            Int32 w = 0;
            BaseColor ColorLinea = new BaseColor(84, 139, 184); //ColorLinea
            BaseColor ColorCabDeta = new BaseColor(148, 182, 210);

            if ((TipoReporte == 1 || TipoReporte == 2 || TipoReporte == 3 || TipoReporte == 4 || TipoReporte == 5 || TipoReporte == 6 || TipoReporte == 7 || TipoReporte == 8) && Presentacion != 3)
            {
                Columnas = (oListaCabecera.Count * 4) + 5; //Total de columnas
                ArrayColumnas = new float[Columnas]; //Para crear el tamaño de las columnas
                ArrayTitulos = new String[oListaCabecera.Count + 2]; //Titulos para la primera linea de las cabecera
                ArrayTitulos_2 = new String[Columnas - 1]; //Titulos para la segunda linea de las cabecera

                for (int i = 0; i < Columnas; i++)
                {
                    if (i == 0)
                    {
                        ArrayTitulos[i] = "DESCRIPCIÓN";
                        ArrayColumnas[i] = 0.36f;
                    }
                    else if (i == (oListaCabecera.Count + 1))
                    {
                        ArrayTitulos[i] = "TOTAL GENERAL";
                        ArrayColumnas[i] = 0.1f;

                        ArrayTitulos_2[w] = "VENTA";
                        ArrayTitulos_2[w + 1] = "PRON";
                        ArrayTitulos_2[w + 2] = "VAR";
                        ArrayTitulos_2[w + 3] = "VAR %";
                    }
                    else if (i > 0 && i <= oListaCabecera.Count + 1)
                    {
                        ArrayTitulos[i] = oListaCabecera[s].nomMes.ToUpper();
                        ArrayColumnas[i] = 0.1f;

                        ArrayTitulos_2[w] = "VENTA";
                        ArrayTitulos_2[w + 1] = "PRON";
                        ArrayTitulos_2[w + 2] = "VAR";
                        ArrayTitulos_2[w + 3] = "VAR %";

                        w++;
                        w++;
                        w++;
                        w++;
                        s++;
                    }
                    else
                    {
                        ArrayColumnas[i] = 0.1f;
                    }
                }

                TablaCab = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };

                TablaCab.SetWidths(ArrayColumnas);

                //Primera Linea Cabecera
                for (int i = 0; i < ArrayTitulos.Length; i++)
                {
                    if (i == 0)
                    {
                        TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "S2", 4, 3, "S", "S", "S", "S", 1f));
                    }
                    else
                    {
                        TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S4", "N", 4, 3, "S", "S", "S", "S", 1f));
                    }
                }

                TablaCab.CompleteRow();

                //Segunda Linea Cabecera
                for (int i = 0; i < ArrayTitulos_2.Length; i++)
                {
                    TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos_2[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4, 3, "S", "S", "S", "S", 1f));
                }

                TablaCab.CompleteRow(); 
            }
            else if (TipoReporte == 3 && Presentacion == 3)
            {
                Columnas = (oListaCabecera.Count * 4) + 6; //Total de columnas
                ArrayColumnas = new float[Columnas]; //Para crear el tamaño de las columnas
                ArrayTitulos = new String[oListaCabecera.Count + 3]; //Titulos para la primera linea de las cabecera
                ArrayTitulos_2 = new String[Columnas - 2]; //Titulos para la segunda linea de las cabecera

                for (int i = 0; i < Columnas; i++)
                {
                    if (i == 0)
                    {
                        ArrayTitulos[i] = "DESCRIPCIÓN";
                        ArrayColumnas[i] = 0.45f;
                    }
                    else if (i == 1)
                    {
                        ArrayTitulos[i] = "UN M.";
                        ArrayColumnas[i] = 0.1f;
                    }
                    else if (i == (oListaCabecera.Count + 2))
                    {
                        ArrayTitulos[i] = "TOTAL GENERAL";
                        ArrayColumnas[i] = 0.09f;

                        ArrayTitulos_2[w] = "VENTA";
                        ArrayTitulos_2[w + 1] = "PRON";
                        ArrayTitulos_2[w + 2] = "VAR";
                        ArrayTitulos_2[w + 3] = "VAR %";
                    }
                    else if (i > 1 && i <= oListaCabecera.Count + 1)
                    {
                        ArrayTitulos[i] = oListaCabecera[s].nomMes.ToUpper();
                        ArrayColumnas[i] = 0.09f;

                        ArrayTitulos_2[w] = "VENTA";
                        ArrayTitulos_2[w + 1] = "PRON";
                        ArrayTitulos_2[w + 2] = "VAR";
                        ArrayTitulos_2[w + 3] = "VAR %";

                        w++;
                        w++;
                        w++;
                        w++;
                        s++;
                    }
                    else
                    {
                        ArrayColumnas[i] = 0.09f;
                    }
                }

                TablaCab = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };

                TablaCab.SetWidths(ArrayColumnas);

                //Primera Linea Cabecera
                for (int i = 0; i < ArrayTitulos.Length; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "S2", 4, 3, "S", "S", "S", "S", 1f));
                    }
                    else
                    {
                        TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S4", "N", 4, 3, "S", "S", "S", "S", 1f));
                    }
                }

                TablaCab.CompleteRow();

                //Segunda Linea Cabecera
                for (int i = 0; i < ArrayTitulos_2.Length; i++)
                {
                    TablaCab.AddCell(ReaderHelper.NuevaCelda(ArrayTitulos_2[i], ColorCabDeta, "S", ColorLinea, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4, 3, "S", "S", "S", "S", 1f));
                }

                TablaCab.CompleteRow();
            }

            return TablaCab;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaReporte == null || oListaReporte.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", Titulo.ToUpper(), "Archivos Excel (*.xlsx)|*.xlsx");

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

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (tipo == "buscar")
                {
                    int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    int Local = Convert.ToInt32(cboLocal.SelectedValue);
                    TipoReporte = Convert.ToInt32(cboTipoReporte.SelectedValue);
                    String Moneda = Convert.ToString(cboMoneda.SelectedValue);
                    Presentacion = Convert.ToInt32(cboPresentacion.SelectedValue);

                    oListaReporte = AgenteVentas.Proxy.ComparativoVentasVsPresupuesto(idEmpresa, Local, dtpInicio.Value.ToString("yyyyMMdd"), dtpFinal.Value.ToString("yyyyMMdd"), Moneda, TipoReporte, Presentacion);

                    if ((TipoReporte == 5 || TipoReporte == 8) && Convert.ToInt32(cboZonas.SelectedValue) != 0)
                    {
                        oListaReporte = (from x in oListaReporte where x.desZonaTrabajo == ((EstablecimientosE)cboZonas.SelectedItem).Descripcion select x).ToList();
                    }

                    if ((TipoReporte == 1 || TipoReporte == 6) && Convert.ToInt32(cboVendedor.SelectedValue) != 0)
                    {
                        oListaReporte = (from x in oListaReporte where x.nomVendedor == ((VendedoresE)cboVendedor.SelectedItem).RazonSocial select x).ToList();
                    }

                    if (!String.IsNullOrWhiteSpace(txtArticulo.Text))
                    {
                        oListaReporte = (from x in oListaReporte where x.nomArticulo.ToUpper().Contains(txtArticulo.Text.ToUpper()) select x).ToList();
                    }

                    ConvertirApdf();
                }
                else
                {
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
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
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
                    Global.MensajeComunicacion("Comparativo Exportado...");
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteComparativoVentasMulti_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            CambioTipo();
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

            dtpInicio.Value = Convert.ToDateTime("01/01/" + Convert.ToString(VariablesLocales.FechaHoy.Year));
            cboMoneda.SelectedValue = Variables.Dolares;
            cboLocal.SelectedValue = Convert.ToInt32(VariablesLocales.SesionLocal.IdLocal);

            cboLocal_SelectionChangeCommitted(new Object(), new EventArgs());
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpInicio.Value.Year != dtpFinal.Value.Year)
                {
                    Global.MensajeComunicacion("Las fechas deben ser del mismo año.");
                    return;
                }

                tipo = "buscar";
                Global.QuitarReferenciaWebBrowser(wbNavegador);
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                lblProcesando.Text = "Obteniendo registros ...";
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }        

        private void cboCantidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CambioTipo();
        }

        private void cboTipoReporte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboMoneda.Enabled = true;
                ////Presentación
                cboPresentacion.DataSource = null;

                if (Convert.ToInt32(cboTipoReporte.SelectedValue) == 3)
                {
                    cboPresentacion.DataSource = Global.CargarMontoCantidad(true);
                    cboPresentacion.ValueMember = "id";
                    cboPresentacion.DisplayMember = "Nombre";
                }
                else
                {
                    cboPresentacion.DataSource = Global.CargarMontoCantidad();
                    cboPresentacion.ValueMember = "id";
                    cboPresentacion.DisplayMember = "Nombre";
                }

                //Zonas
                if (Convert.ToInt32(cboTipoReporte.SelectedValue) == 5 || Convert.ToInt32(cboTipoReporte.SelectedValue) == 8)
                {
                    cboZonas.Enabled = true;
                }
                else
                {
                    cboZonas.Enabled = false;
                    cboZonas.SelectedValue = 0;
                }

                //Vendedores
                if (Convert.ToInt32(cboTipoReporte.SelectedValue) == 1 || Convert.ToInt32(cboTipoReporte.SelectedValue) == 6)
                {
                    cboVendedor.Enabled = true;
                }
                else
                {
                    cboVendedor.Enabled = false;
                    cboVendedor.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //Zonas de trabajo
                List<EstablecimientosE> oListaZonas = AgenteMaestro.Proxy.ListarEstablecimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboLocal.SelectedValue));
                oListaZonas.Add(new EstablecimientosE() { idEstablecimiento = Variables.Cero, Descripcion = "<< ESCOGER ZONA >>" });
                ComboHelper.LlenarCombos(cboZonas, (from x in oListaZonas orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion");
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
