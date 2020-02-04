using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteKardexPorTipoAlmacen : FrmMantenimientoBase
    {

        public frmReporteKardexPorTipoAlmacen()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        readonly BackgroundWorker _bw = new BackgroundWorker();
        List<kardexE> ReporteFinal = null;
        String RutaGeneral = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            /////Mes Inicio////
            cboInicioMes.DataSource = FechasHelper.CargarMeses(1, true, "MA");
            cboInicioMes.ValueMember = "MesId";
            cboInicioMes.DisplayMember = "MesDes";

            /////Mes Fin////
            cbofinMes.DataSource = FechasHelper.CargarMeses(1, true, "MA");
            cbofinMes.ValueMember = "MesId";
            cbofinMes.DisplayMember = "MesDes";

            /////Años/////
            Int32 anioFin = Convert.ToInt32(VariablesLocales.FechaHoy.ToString("yyyy"));
            Int32 anioInicio = anioFin - 5;

            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";

            cboAnio.SelectedValue = Convert.ToInt32(anioFin);
            cboInicioMes.SelectedValue = VariablesLocales.FechaHoy.ToString("MM");
            cbofinMes.SelectedValue = VariablesLocales.FechaHoy.ToString("MM");

            //Tipo de Articulos
            List <ParTabla> ListaTipos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaTipos.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaTipos orderby x.IdParTabla select x).ToList());

            //Monedas
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in VariablesLocales.ListaMonedas where x.idMoneda == "01" || x.idMoneda == "02" select x).ToList(), "idMoneda", "desAbreviatura");

            ListaTipos = null;
        }

        private void ConvertirApdf(List<kardexE> Reporte)
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Movimiento de Almacen " + Aleatorio.ToString();
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
                // Para la creación del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    #region Variables

                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);
                    BaseColor col1 = new BaseColor(Color.FromArgb(191, 191, 191));
                    BaseColor col2 = new BaseColor(Color.FromArgb(132, 151, 176));
                    BaseColor colSaldo = new BaseColor(Color.FromArgb(155, 194, 230));
                    BaseColor FontColorSegun = new BaseColor(Color.Navy);
                    BaseColor FontColorActual = new BaseColor(Color.DarkGreen);
                    PdfPTable TablaCabDetalle = null;
                    float[] AnchoColumnas = null;
                    Int32 Cols = 0;
                    Int32 ColsDinamico = 0;
                    List<kardexE> ListaCabecera = Reporte.GroupBy(x => x.codCuentaDestino).Select(p => p.First()).ToList();
                    String idMoneda = cboMoneda.SelectedValue.ToString();

                    Decimal TotalFila = 0; //Total x fila
                    Decimal TotalColumnas = 0; //Total de la última columna
                    Decimal TotalSegunMov = 0; //Total Según de la última columna
                    Decimal TotalActual = 0; //Total Actual de la última columna
                    Decimal TotalDiferencia = 0; //Total Diferencia de la última columna

                    #endregion

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    //Total de columnas dinámicas que se van a crear
                    ColsDinamico = ListaCabecera.Count;
                    //Total de columnas a crear
                    Cols = 5 + ColsDinamico;

                    //Total de columnas
                    TablaCabDetalle = new PdfPTable(Cols)
                    {
                        WidthPercentage = 100
                    };

                    //Total de anchos para las columnas
                    AnchoColumnas = new float[Cols];
                    //Anchos de columnas fijas
                    AnchoColumnas[0] = 0.01f;  //Orden
                    AnchoColumnas[1] = 0.03f;  //Descripción del movimiento
                    AnchoColumnas[2] = 0.025f; //Cód. de la operación
                    AnchoColumnas[3] = 0.2f;   //Descripción de la operación

                    //Anchos de columnas dinámicas
                    for (int i = 4; i < AnchoColumnas.Length - 1; i++)
                    {
                        AnchoColumnas[i] = 0.04f;
                    }

                    //Anchos de la ultima columna
                    AnchoColumnas[Cols - 1] = 0.05f;

                    TablaCabDetalle.SetWidths(AnchoColumnas);

                    //Obteniendo las cabeceras
                    List<String> Cabeceras = new List<String>();

                    //Añadiendo las cabeceras dinámicas
                    foreach (kardexE item in ListaCabecera)
                    {
                        Cabeceras.Add(item.codCuentaDestino);
                    }


                    if (cboInicioMes.Text.ToString().ToUpper() == cbofinMes.Text.ToString().ToUpper())
                    {
                        //Parámetros que pasará al inicio del PDF
                        oPdfw.PageEvent = new PagInicioMovAlmacenResu
                        {
                            tipMov = ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre,
                            Periodo = " A " + cbofinMes.Text.ToString().ToUpper() + " - " + cboAnio.SelectedValue.ToString(),
                            Moneda = ((MonedasE)cboMoneda.SelectedItem).desMoneda,
                            NombresCol = Cabeceras,
                            AnchoCols = AnchoColumnas,
                            Columnas = Cols,
                            colCabDetalle1 = col1,
                            colCabDetalle2 = col2
                        };
                    }
                    else
                    {
                        //Parámetros que pasará al inicio del PDF
                        oPdfw.PageEvent = new PagInicioMovAlmacenResu
                        {
                            tipMov = ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre,
                            Periodo = cboInicioMes.Text.ToString().ToUpper() + " A " + cbofinMes.Text.ToString().ToUpper() + " - " + cboAnio.SelectedValue.ToString(),
                            Moneda = ((MonedasE)cboMoneda.SelectedItem).desMoneda,
                            NombresCol = Cabeceras,
                            AnchoCols = AnchoColumnas,
                            Columnas = Cols,
                            colCabDetalle1 = col1,
                            colCabDetalle2 = col2
                        };
                    }
                  

                    docPdf.Open();

                    //Saldos Actual
                    List<kardexE> ListaSaldoActual = new List<kardexE>(from x in Reporte where x.idOperacion == 0 && x.codSunatOpe == "x" select x).ToList();
                    //Quitar las lineas de los saldos actuales
                    Reporte = new List<kardexE>(Reporte.Except(ListaSaldoActual));
                    //Saldos Iniciales
                    List<kardexE> ListaSaldos = new List<kardexE>(from x in Reporte where x.idOperacion == 0 && x.codSunatOpe == "16" select x).ToList();
                    //Para saber cuando vamos a insertar la linea de saldos
                    Boolean Insertar = true;
                    //Para saber si hay ingresos diferente a idOperacion 0
                    List<kardexE> Listita = new List<kardexE>(from x in Reporte where x.Orden == 1 && x.idOperacion != 0 select x).ToList();

                    //Si la lista es mayor a 0 quitamos de la lista principal, las lineas de saldos
                    if (Listita.Count > 0)
                    {
                        Reporte = new List<kardexE>(Reporte.Except(ListaSaldos));
                    }
                    
                    //Lista de tipo de movimiento Orden = 1-Ingreso 2-Egreso
                    List<kardexE> ListaTipoMov = Reporte.GroupBy(x => x.Orden).Select(p => p.First()).ToList();

                    foreach (kardexE item in ListaTipoMov)
                    {
                        //Listado de Tipo operación, según el Cód.Sunat de la operación
                        List<kardexE> ListaTipoOpe = Reporte.Where(z => z.Orden == item.Orden).GroupBy(x => x.codSunatOpe).Select(p => p.First()).ToList();
                        Int32 TotFilMerge = ListaTipoOpe.Count;

                        //Si es ingreso y la lista de Ingresos con operaciones diferentes a 0, ingresa...
                        if (item.Orden == 1 && Listita.Count > 0)
                        {
                            TotFilMerge += 1;
                        }

                        //Añadiendo las primeras columnas
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Orden.ToString(), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S" + TotFilMerge.ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMovimiento, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "N", "S" + TotFilMerge.ToString()));

                        //Recorriendo la lista de operaciones
                        foreach (kardexE itemOpe in ListaTipoOpe)
                        {
                            #region Saldo Inicial

                            if (Insertar)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SALDOS INICIALES", colSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));

                                //Recorriendo las cabeceras para sacar el saldo por cuenta
                                foreach (kardexE itemCab in ListaCabecera)
                                {
                                    Decimal MontoSaldo = (from x in ListaSaldos
                                                          where x.Orden == itemCab.Orden
                                                          && x.codCuentaDestino == itemCab.codCuentaDestino
                                                          select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MontoSaldo.ToString("N2"), colSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                    TotalFila += MontoSaldo;
                                }

                                //Ultima columna
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFila.ToString("N2"), colSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                TablaCabDetalle.CompleteRow();

                                Insertar = false;
                                TotalColumnas += TotalFila;
                                TotalFila = 0;
                            }

                            #endregion

                            if (itemOpe.idOperacion != 0)
                            {
                                //Añadiendo las columnas de operaciones
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemOpe.codSunatOpe, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(itemOpe.desOperacion, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 0));

                                //Recorriendo las cabeceras para sacar el total por movimiento, operación y cuenta
                                foreach (kardexE itemCab in ListaCabecera)
                                {
                                    Decimal MontoCuenta = (from x in Reporte
                                                           where x.Orden == item.Orden
                                                           && x.codSunatOpe == itemOpe.codSunatOpe
                                                           && x.codCuentaDestino == itemCab.codCuentaDestino
                                                           select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MontoCuenta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                                    TotalFila += MontoCuenta;
                                }

                                //Ultima columna
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalFila.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2));
                                TablaCabDetalle.CompleteRow();

                                TotalColumnas += TotalFila;
                                TotalFila = 0; 
                            }
                        }

                        //Total Movimiento
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL " + item.desMovimiento, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "S4", "N", 3f, 3f));

                        //Recorriendo las cabeceras para sacar el total por movimiento y cuenta
                        foreach (kardexE itemCab in ListaCabecera)
                        {
                            Decimal MontoColCuenta = (from x in Reporte
                                                      where x.Orden == item.Orden
                                                      && x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.idOperacion != 0
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                            if (item.Orden == 1) //Ingreso
                            {
                                Decimal MontoSaldo = (from x in ListaSaldos
                                                      where x.Orden == item.Orden
                                                      && x.codCuentaDestino == itemCab.codCuentaDestino
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                                MontoColCuenta += MontoSaldo;
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MontoColCuenta.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                        }

                        //Ultima columna
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalColumnas.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                        TablaCabDetalle.CompleteRow();

                        if (item.Orden == 1)
                        {
                            TotalSegunMov += TotalColumnas;
                        }
                        else
                        {
                            TotalSegunMov -= TotalColumnas;
                        }

                        TotalColumnas = 0;

                        //Fila en blanco
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f, iTextSharp.text.Font.BOLD), 5, 2, "S" + Cols.ToString()));
                        TablaCabDetalle.CompleteRow();
                    }

                    #region Saldo Según Movimiento

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO SEGUN MOVIMIENTO", null, "S", FontColorSegun, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorSegun), 5, 2, "S4", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));

                    //Recorriendo las cabeceras para sacar el total por cuenta
                    foreach (kardexE itemCab in ListaCabecera)
                    {
                        Decimal MontoCtaGeneralIng = (from x in Reporte
                                                      where x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.Orden == 1 //Ingresos
                                                      && x.idOperacion != 0
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        Decimal MontoSaldo = (from x in ListaSaldos
                                              where x.Orden == 1 //Ingresos
                                              && x.codCuentaDestino == itemCab.codCuentaDestino
                                              select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        MontoCtaGeneralIng += MontoSaldo;

                        Decimal MontoCtaGeneralEgr = (from x in Reporte
                                                      where x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.Orden == 2 //Egresos
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((MontoCtaGeneralIng - MontoCtaGeneralEgr).ToString("N2"), null, "S", FontColorSegun, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorSegun), 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    }

                    //Ultima columna
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalSegunMov.ToString("N2"), null, "S", FontColorSegun, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorSegun), 5, 2, "N", "N", 3f, 3f, "S", "N", "N", "N", 0.8f));
                    TablaCabDetalle.CompleteRow();

                    #endregion

                    #region Saldo Actual

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ACTUAL", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorSegun), 5, 2, "S4", "N", 3f, 3f));

                    //Recorriendo las cabeceras para sacar el total por cuenta
                    foreach (kardexE itemCab in ListaCabecera)
                    {
                        Decimal MontoSaldoActual = (from x in ListaSaldoActual
                                                    where x.codCuentaDestino == itemCab.codCuentaDestino
                                                    select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(MontoSaldoActual.ToString("N2"), null, "S", FontColorActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorSegun), 5, 2, "N", "N", 3f, 3f, "N", "S", "N", "N", 0.8f));

                        TotalActual += MontoSaldoActual;
                    }

                    //Ultima columna
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalActual.ToString("N2"), null, "S", FontColorActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorSegun), 5, 2, "N", "N", 3f, 3f, "N", "S", "N", "N", 0.8f));
                    TablaCabDetalle.CompleteRow();

                    #endregion

                    #region Diferencia

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DIFERENCIA", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorActual), 5, 2, "S4", "N", 3f, 3f));

                    //Recorriendo las cabeceras para sacar el total por cuenta
                    foreach (kardexE itemCab in ListaCabecera)
                    {
                        #region Según Movimiento

                        Decimal MontoCtaGeneralIng = (from x in Reporte
                                                      where x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.Orden == 1 //Ingresos
                                                      && x.idOperacion != 0
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        Decimal MontoSaldo = (from x in ListaSaldos
                                              where x.Orden == 1 //Ingresos
                                              && x.codCuentaDestino == itemCab.codCuentaDestino
                                              select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        MontoCtaGeneralIng += MontoSaldo;

                        Decimal MontoCtaGeneralEgr = (from x in Reporte
                                                      where x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.Orden == 2 //Egresos
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        #endregion

                        #region Saldo Actual

                        Decimal MontoSaldoActual = (from x in ListaSaldoActual
                                                    where x.codCuentaDestino == itemCab.codCuentaDestino
                                                    select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        #endregion

                        Decimal Diferencia = (MontoCtaGeneralIng - MontoCtaGeneralEgr) - MontoSaldoActual;
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Diferencia.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorActual), 5, 2, "N", "N", 3f, 3f));

                        TotalDiferencia += Diferencia;
                    }

                    //Ultima columna
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotalDiferencia.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, FontColorActual), 5, 2, "N", "N", 3f, 3f));
                    TablaCabDetalle.CompleteRow();

                    #endregion

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

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

        private void ExportarExcel(List<kardexE> Reporte, String Ruta)
        {
            #region Variables

            String NombrePestaña = "Movimientos";
            
            #endregion

            //Creando el directorio si existe...
            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo NuevoArchivo = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(NuevoArchivo))
            {
                using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña))
                {
                    #region Variables

                    String TituloGeneral = "MOVIMIENTO DE ALMACEN POR TIPO DE ARTICULO - " + ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre;
                    String SubTitulos = String.Empty;
                    if (cboInicioMes.Text.ToString().ToUpper() == cbofinMes.Text.ToString().ToUpper())
                    {
                        SubTitulos = "(" + " AL " + cbofinMes.Text.ToString().ToUpper() + "-" + cboAnio.SelectedValue.ToString() + ")";
                    }
                    else
                    {
                        SubTitulos = "(" + cboInicioMes.Text.ToString().ToUpper() + " AL " + cbofinMes.Text.ToString().ToUpper() + "-" + cboAnio.SelectedValue.ToString() + ")";
                    }
                    
                    String SubTituloMes = "(EN " + ((MonedasE)cboMoneda.SelectedItem).desMoneda + ")";
                    Int32 totCols = 0;
                    Int32 FilaIni = 5;
                    Color col1 = Color.FromArgb(191, 191, 191);
                    Color col2 = Color.FromArgb(132, 151, 176);
                    Color colSaldo = Color.FromArgb(155, 194, 230);

                    var ListaCabecera = Reporte.GroupBy(x => x.codCuentaDestino).Select(p => p.First()).ToList();
                    Decimal TotalFila = 0;
                    Decimal TotalColumnas = 0;
                    Decimal TotalSegunMov = 0;
                    Decimal TotalActual = 0; //Total Actual de la última columna
                    Decimal TotalDiferencia = 0; //Total Diferencia de la última columna
                    Int32 c = 5;
                    String idMoneda = cboMoneda.SelectedValue.ToString();

                    #endregion

                    //Total de columnas
                    totCols = 5 + ListaCabecera.Count;

                    #region Titulos

                    if (Convert.ToInt32(cboTipoAlmacen.SelectedValue) == 0)
                    {
                        TituloGeneral = TituloGeneral.Replace("<<", "").Replace(">>", "").Trim();
                    }

                    oHoja.Cells["A1"].Value = TituloGeneral;
                    oHoja.Row(1).Height = 30;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totCols])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    oHoja.Cells["A2"].Value = SubTitulos;
                    oHoja.Row(2).Height = 16;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, totCols])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 11, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    oHoja.Cells["A3"].Value = SubTituloMes;
                    oHoja.Row(2).Height = 14;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, totCols])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    #endregion

                    #region Cabecera del Detalle

                    oHoja.Row(FilaIni).Height = 35;

                    oHoja.Cells[FilaIni, 1].Value = "N°";
                    oHoja.Cells[FilaIni, 2].Value = "MOVIMIENTO";
                    oHoja.Cells[FilaIni, 3].Value = "COD.SUNAT";
                    oHoja.Cells[FilaIni, 4].Value = "OPERACION";

                    for (int i = 5; i <= totCols - 1; i++)
                    {
                        oHoja.Cells[FilaIni, i].Value = ListaCabecera[i - 5].codCuentaDestino;
                    }

                    oHoja.Cells[FilaIni, totCols].Value = "TOTALES";

                    for (int i = 1; i <= totCols; i++)
                    {
                        oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        oHoja.Cells[FilaIni, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[FilaIni, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[FilaIni, i].Style.WrapText = true;

                        if (i <= 4)
                        {
                            oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(col1);
                        }
                        else
                        {
                            if (i == totCols)
                            {
                                oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(col1);
                            }
                            else
                            {
                                oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(col2);
                            }
                        }
                    }

                    #region Ancho de Columnas

                    oHoja.Column(1).Width = 4; //N°
                    oHoja.Column(2).Width = 20; //Movimiento
                    oHoja.Column(3).Width = 10; //Cód Sunat
                    oHoja.Column(4).Width = 50; //Operación

                    for (int i = 5; i <= totCols - 1; i++)
                    {
                        oHoja.Column(i).Width = 17.5;
                    }

                    oHoja.Column(totCols).Width = 17;

                    #endregion

                    #endregion

                    FilaIni++;

                    //Saldos Actual
                    List<kardexE> ListaSaldoActual = new List<kardexE>(from x in Reporte where x.idOperacion == 0 && x.codSunatOpe == "x" select x).ToList();
                    //Quitar las lineas de los saldos actuales
                    Reporte = new List<kardexE>(Reporte.Except(ListaSaldoActual));
                    //Saldos Iniciales
                    List<kardexE> ListaSaldos = new List<kardexE>(from x in Reporte where x.idOperacion == 0 && x.codSunatOpe == "16" select x).ToList();
                    //Para saber cuando vamos a insertar la linea de saldos
                    Boolean Insertar = true;
                    //Para saber si hay ingresos diferente a idOperacion 0
                    List<kardexE> Listita = new List<kardexE>(from x in Reporte where x.Orden == 1 && x.idOperacion != 0 select x).ToList();

                    //Si la lista es mayor a 0 quitamos de la lista principal, las lineas de saldos
                    if (Listita.Count > 0)
                    {
                        Reporte = new List<kardexE>(Reporte.Except(ListaSaldos));
                    }

                    //Lista de tipo de movimiento Orden = 1-Ingreso 2-Egreso
                    List<kardexE> ListaTipoMov = Reporte.GroupBy(x => x.Orden).Select(p => p.First()).ToList();

                    foreach (kardexE item in ListaTipoMov)
                    {
                        //Listado de Tipo operación, según el Cód.Sunat de la operación
                        List<kardexE> ListaTipoOpe = Reporte.Where(z => z.Orden == item.Orden).GroupBy(x => x.codSunatOpe).Select(p => p.First()).ToList();
                        Int32 TotFilMerge = ListaTipoOpe.Count;

                        //Si es ingreso y la lista de Ingresos con operaciones diferentes a 0, ingresa...
                        if (item.Orden == 1 && Listita.Count > 0)
                        {
                            TotFilMerge += 1;
                        }

                        //Añadiendo las primeras columnas
                        oHoja.Cells[FilaIni, 1, FilaIni + (TotFilMerge - 1), 1].Merge = true;
                        oHoja.Cells[FilaIni, 1, FilaIni + (TotFilMerge - 1), 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, 1, FilaIni + (TotFilMerge - 1), 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[FilaIni, 1, FilaIni + (TotFilMerge - 1), 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[FilaIni, 1].Value = item.Orden;
                        oHoja.Cells[FilaIni, 2, FilaIni + (TotFilMerge - 1), 2].Merge = true;
                        oHoja.Cells[FilaIni, 2, FilaIni + (TotFilMerge - 1), 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, 2, FilaIni + (TotFilMerge - 1), 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[FilaIni, 2, FilaIni + (TotFilMerge - 1), 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[FilaIni, 2].Value = item.desMovimiento;

                        //Recorriendo la lista de operaciones
                        foreach (kardexE itemOpe in ListaTipoOpe)
                        {
                            #region Saldo Inicial

                            if (Insertar)
                            {
                                oHoja.Cells[FilaIni, 3, FilaIni, 4].Merge = true;
                                oHoja.Cells[FilaIni, 3, FilaIni, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                oHoja.Cells[FilaIni, 3, FilaIni, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[FilaIni, 3, FilaIni, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                oHoja.Cells[FilaIni, 3].Value = "SALDOS INICIALES";
                                oHoja.Cells[FilaIni, 3, FilaIni, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[FilaIni, 3, FilaIni, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[FilaIni, 3, FilaIni, 4].Style.Fill.BackgroundColor.SetColor(colSaldo);

                                //Recorriendo las cabeceras para sacar el saldo por cuenta
                                c = 5;

                                foreach (kardexE itemCab in ListaCabecera)
                                {
                                    Decimal MontoSaldo = (from x in ListaSaldos
                                                          where x.Orden == item.Orden
                                                          && x.codCuentaDestino == itemCab.codCuentaDestino
                                                          select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                                    oHoja.Cells[FilaIni, c].Value = MontoSaldo;
                                    oHoja.Cells[FilaIni, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    oHoja.Cells[FilaIni, c].Style.Numberformat.Format = "###,##0.00";

                                    TotalFila += MontoSaldo;
                                    c++;
                                }

                                //Ultima columna
                                oHoja.Cells[FilaIni, totCols].Value = TotalFila;
                                oHoja.Cells[FilaIni, totCols].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[FilaIni, totCols].Style.Numberformat.Format = "###,##0.00";

                                for (int i = 5; i <= totCols; i++)
                                {
                                    oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                    oHoja.Cells[FilaIni, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                    oHoja.Cells[FilaIni, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(colSaldo);
                                }

                                Insertar = false;
                                TotalColumnas += TotalFila;
                                TotalFila = 0;
                                FilaIni++; //Aumnetando una fila
                            }

                            #endregion

                            if (itemOpe.idOperacion != 0)
                            {
                                //Añadiendo las columnas de operaciones
                                oHoja.Cells[FilaIni, 3].Value = itemOpe.codSunatOpe;
                                oHoja.Cells[FilaIni, 4].Value = itemOpe.desOperacion;

                                //Recorriendo las cabeceras para sacar el total por movimiento, operación y cuenta
                                c = 5;

                                foreach (kardexE itemCab in ListaCabecera)
                                {
                                    Decimal MontoCuenta = (from x in Reporte
                                                           where x.Orden == item.Orden
                                                           && x.codSunatOpe == itemOpe.codSunatOpe
                                                           && x.codCuentaDestino == itemCab.codCuentaDestino
                                                           select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                                    oHoja.Cells[FilaIni, c].Value = MontoCuenta;
                                    oHoja.Cells[FilaIni, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    oHoja.Cells[FilaIni, c].Style.Numberformat.Format = "###,##0.00";
                                    TotalFila += MontoCuenta;
                                    c++;
                                }

                                //Ultima columna
                                oHoja.Cells[FilaIni, totCols].Value = TotalFila;
                                oHoja.Cells[FilaIni, totCols].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[FilaIni, totCols].Style.Numberformat.Format = "###,##0.00";

                                //Formateo
                                for (int i = 3; i <= totCols; i++)
                                {
                                    oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                                }

                                TotalColumnas += TotalFila;
                                TotalFila = 0;
                                FilaIni++;
                            }
                        }

                        //Total Movimiento
                        oHoja.Cells[FilaIni, 1, FilaIni, 4].Merge = true;
                        oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, 1].Value = "TOTAL " + item.desMovimiento;

                        //Recorriendo las cabeceras para sacar el total por movimiento y cuenta
                        c = 5;

                        foreach (kardexE itemCab in ListaCabecera)
                        {
                            Decimal MontoColCuenta = (from x in Reporte
                                                      where x.Orden == item.Orden
                                                      && x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.idOperacion != 0
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                            if (item.Orden == 1) //Ingreso
                            {
                                Decimal MontoSaldo = (from x in ListaSaldos
                                                      where x.Orden == item.Orden
                                                      && x.codCuentaDestino == itemCab.codCuentaDestino
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                                MontoColCuenta += MontoSaldo;
                            }

                            oHoja.Cells[FilaIni, c].Value = MontoColCuenta;
                            c++;
                        }

                        //Ultima columna
                        oHoja.Cells[FilaIni, totCols].Value = TotalColumnas;

                        for (int i = 5; i <= totCols; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        }

                        if (item.Orden == 1)
                        {
                            TotalSegunMov += TotalColumnas;
                        }
                        else
                        {
                            TotalSegunMov -= TotalColumnas;
                        }

                        TotalColumnas = 0;

                        FilaIni++;
                        FilaIni++;
                    }

                    #region Saldo Según Movimiento

                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Merge = true;
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Font.Color.SetColor(Color.Navy);
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Border.Top.Color.SetColor(Color.Navy);
                    oHoja.Cells[FilaIni, 1].Value = "SALDO SEGUN MOVIMIENTO";

                    //Recorriendo las cabeceras para sacar el total por cuenta
                    c = 5;

                    foreach (kardexE itemCab in ListaCabecera)
                    {
                        Decimal MontoCtaGeneralIng = (from x in Reporte
                                                      where x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.Orden == 1 //Ingresos
                                                      && x.idOperacion != 0
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        Decimal MontoSaldo = (from x in ListaSaldos
                                              where x.Orden == 1 //Ingresos
                                              && x.codCuentaDestino == itemCab.codCuentaDestino
                                              select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        MontoCtaGeneralIng += MontoSaldo;

                        Decimal MontoCtaGeneralEgr = (from x in Reporte
                                                      where x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.Orden == 2 //Egresos
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        oHoja.Cells[FilaIni, c].Value = MontoCtaGeneralIng - MontoCtaGeneralEgr;
                        c++;
                    }

                    //Ultima columna
                    oHoja.Cells[FilaIni, totCols].Value = TotalSegunMov;

                    //Formateo
                    for (int i = 5; i <= totCols; i++)
                    {
                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        oHoja.Cells[FilaIni, i].Style.Border.Top.Color.SetColor(Color.Navy);
                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                        oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, i].Style.Font.Color.SetColor(Color.Navy);
                    }

                    #endregion

                    FilaIni++;

                    #region Saldo Actual

                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Merge = true;
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Font.Color.SetColor(Color.Navy);
                    oHoja.Cells[FilaIni, 1].Value = "SALDO ACTUAL";

                    //Recorriendo las cabeceras para sacar el total por cuenta
                    c = 5;

                    foreach (kardexE itemCab in ListaCabecera)
                    {
                        Decimal MontoSaldoActual = (from x in ListaSaldoActual
                                                    where x.codCuentaDestino == itemCab.codCuentaDestino
                                                    select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        oHoja.Cells[FilaIni, c].Value = MontoSaldoActual;
                        TotalActual += MontoSaldoActual;
                        c++;
                    }

                    //Ultima columna
                    oHoja.Cells[FilaIni, totCols].Value = TotalActual;

                    //Formateo
                    for (int i = 5; i <= totCols; i++)
                    {
                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaIni, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        oHoja.Cells[FilaIni, i].Style.Border.Bottom.Color.SetColor(Color.DarkGreen);
                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                        oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, i].Style.Font.Color.SetColor(Color.Navy);
                    }

                    #endregion

                    FilaIni++;

                    #region Diferencia

                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Merge = true;
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[FilaIni, 1, FilaIni, 4].Style.Font.Color.SetColor(Color.DarkGreen);
                    oHoja.Cells[FilaIni, 1].Value = "DIFERENCIA";

                    //Recorriendo las cabeceras para sacar el total por cuenta
                    c = 5;

                    foreach (kardexE itemCab in ListaCabecera)
                    {
                        #region Según Movimiento

                        Decimal MontoCtaGeneralIng = (from x in Reporte
                                                      where x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.Orden == 1 //Ingresos
                                                      && x.idOperacion != 0
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        Decimal MontoSaldo = (from x in ListaSaldos
                                              where x.Orden == 1 //Ingresos
                                              && x.codCuentaDestino == itemCab.codCuentaDestino
                                              select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        MontoCtaGeneralIng += MontoSaldo;

                        Decimal MontoCtaGeneralEgr = (from x in Reporte
                                                      where x.codCuentaDestino == itemCab.codCuentaDestino
                                                      && x.Orden == 2 //Egresos
                                                      select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        #endregion

                        #region Saldo Actual

                        Decimal MontoSaldoActual = (from x in ListaSaldoActual
                                                    where x.codCuentaDestino == itemCab.codCuentaDestino
                                                    select Decimal.Round((idMoneda == "01" ? x.TotalSoles : x.TotalDolar), 2, MidpointRounding.AwayFromZero)).Sum();

                        #endregion

                        Decimal Diferencia = (MontoCtaGeneralIng - MontoCtaGeneralEgr) - MontoSaldoActual;

                        oHoja.Cells[FilaIni, c].Value = Diferencia;
                        TotalDiferencia += Diferencia;
                        c++;
                    }

                    //Ultima columna
                    oHoja.Cells[FilaIni, totCols].Value = TotalDiferencia;

                    //Formateo
                    for (int i = 5; i <= totCols; i++)
                    {
                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                        oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[FilaIni, i].Style.Font.Color.SetColor(Color.DarkGreen);
                    }

                    #endregion

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Módulo de Almacén";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        #endregion

        #region Eventos Heredados

        public override void Buscar()
        {
            Int32 idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            lblProcesando.Text = "Obteniendo los Movimientos...";
            ReporteFinal = AgenteAlmacen.Proxy.KardexPorTipArticulo(idEmpresa, cboAnio.SelectedValue.ToString(), cboInicioMes.SelectedValue.ToString(), cbofinMes.SelectedValue.ToString(), Convert.ToInt32(cboTipoAlmacen.SelectedValue), Convert.ToInt32(cboAlmacen.SelectedValue));
            lblProcesando.Text = "Armando el Reporte...";

            if (ReporteFinal.Count > 0)
            {
                ConvertirApdf(ReporteFinal);
            }
            else
            {
                Global.MensajeComunicacion("No hay información con el Tipo de Articulo y Almacén escogidos.");
            }
        }

        public override void Exportar()
        {
            try
            {
                if (ReporteFinal == null || ReporteFinal.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreArchivo = "MOVIMIENTOS DE ALMACEN RESUMIDO " + ((ParTabla)cboTipoAlmacen.SelectedItem).Nombre.ToUpper() + " " + cboInicioMes.Text.ToString().ToUpper() + " AL " + cbofinMes.Text.ToString().ToUpper() + "-" + cboAnio.SelectedValue.ToString();
                NombreArchivo = NombreArchivo.Replace("<<", "-").Replace(">>", "-");
                String RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrWhiteSpace(RutaExcel))
                {
                    ExportarExcel(ReporteFinal, RutaExcel);
                    Global.MensajeComunicacion("Información exportada");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Buscar();
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
            //panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                ////Mostrando el reporte en un web browser
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteMovAlmacenPorTipoAlmacen_Load(object sender, EventArgs e)
        {
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

            cboTipoAlmacen_SelectionChangeCommitted(new Object(), new EventArgs());
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
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
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

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<AlmacenE> ListaAlmacenes = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoAlmacen.SelectedValue));
                ListaAlmacenes.Add(new AlmacenE() { idAlmacen = 0, desAlmacen = Variables.Todos });
                ComboHelper.RellenarCombos<AlmacenE>(cboAlmacen, ListaAlmacenes.OrderBy(x => x.idAlmacen).ToList(), "idAlmacen", "desAlmacen");

                if (ListaAlmacenes.Count == 1)
                {
                    cboAlmacen.Enabled = false;
                }
                else if (ListaAlmacenes.Count == 2)
                {
                    cboAlmacen.Enabled = false;
                    cboAlmacen.SelectedIndex = 1;
                }
                else
                {
                    cboAlmacen.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }

    class PagInicioMovAlmacenResu : PdfPageEventHelper
    {
        public String tipMov { get; set; }
        public String Periodo { get; set; }
        public String Moneda { get; set; }
        public Int32 Columnas { get; set; }
        public float[] AnchoCols { get; set; }
        public List<String> NombresCol { get; set; }
        public BaseColor colCabDetalle1 { get; set; }
        public BaseColor colCabDetalle2 { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            PdfPTable table = null;

            #endregion Variables

            //Para el encabezado
            table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            tipMov = tipMov.Replace("<<", "").Replace(">>", "").Trim();

            if (writer.PageNumber == 1)
            {
                #region Encabezado de página

                table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                #endregion

                #region Titulo Principal

                table.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTO DE ALMACEN POR TIPO DE ARTICULO RESUMIDO - " + tipMov, null, "N", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                table.AddCell(ReaderHelper.NuevaCelda("(" + Periodo + ")", null, "N", null, FontFactory.GetFont("Arial", 10.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                table.AddCell(ReaderHelper.NuevaCelda("(EN " + Moneda.ToUpper() + ")", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                //Fila en blanco
                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N"));

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF

                #region Cabecera del Detalle

                table = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };

                table.SetWidths(AnchoCols);

                table.AddCell(ReaderHelper.NuevaCelda("N°", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTO", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("COD.SUNAT", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("OPERACION", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));

                foreach (String item in NombresCol)
                {
                    table.AddCell(ReaderHelper.NuevaCelda(item, colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                }

                table.AddCell(ReaderHelper.NuevaCelda("TOTALES", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));

                table.CompleteRow();

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF
            }
            else
            {
                #region Encabezado de Página

                table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow(); //Fila completada

                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
                table.CompleteRow();

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF

                #region Cabecera del Detalle

                table = new PdfPTable(Columnas)
                {
                    WidthPercentage = 100
                };

                table.SetWidths(AnchoCols);

                table.AddCell(ReaderHelper.NuevaCelda("N°", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTO", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("COD.SUNAT", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                table.AddCell(ReaderHelper.NuevaCelda("OPERACION", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));

                foreach (String item in NombresCol)
                {
                    table.AddCell(ReaderHelper.NuevaCelda(item, colCabDetalle2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                }

                table.AddCell(ReaderHelper.NuevaCelda("TOTALES", colCabDetalle1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));

                table.CompleteRow();

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF
            }
        }
    }

}
