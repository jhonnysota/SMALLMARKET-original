using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteCajayBanco : FrmMantenimientoBase
    {

        public frmReporteCajayBanco()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
            CambiosChecked();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<VoucherItemE> oReporteMovimientos = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marque = String.Empty;
        string tipo = "buscar";
        String CheckMov = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            listaLocales.Add(new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, (from x in listaLocales orderby x.IdLocal select x).ToList(), "idLocal", "Nombre", false);

            /////Mes Inicio////
            cboInicioMes.DataSource = FechasHelper.CargarMesesContable("MA");
            cboInicioMes.ValueMember = "MesId";
            cboInicioMes.DisplayMember = "MesDes";

            /////Mes Final////
            cboFinMes.DataSource = FechasHelper.CargarMesesContable("MA");
            cboFinMes.ValueMember = "MesId";
            cboFinMes.DisplayMember = "MesDes";

            //// Monedas ///
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            /////Años/////
            String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
            Int32 anioInicio = 0;
            Int32 anioFin = Convert.ToInt32(Anio);

            anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

            cboSucursales.SelectedValue = VariablesLocales.SesionLocal.IdLocal;
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            cboInicioMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;
            cboFinMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\ReporteLibroCajasBancos " + Aleatorio.ToString();
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

                //Para la creacion del archivo pdf
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
                    BaseColor FondoColor = new BaseColor(Color.DarkGray);
                    BaseColor ColorLetra = new BaseColor(Color.Navy);
                    PdfPTable TablaCabDetalle = null;
                    float[] AnchoColumnas = null;
                    Int32 Cols = 0; 

                    #endregion

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    if (rbEfectivo.Checked)
                    {
                        Cols = 8;
                        TablaCabDetalle = new PdfPTable(Cols)
                        {
                            WidthPercentage = 100
                        };

                        AnchoColumnas = new float[] { 0.03f, 0.01f, 0.1f, 0.02f, 0.1f, 0.01f, 0.03f, 0.03f };
                    }
                    else
                    {
                        Cols = 11;
                        TablaCabDetalle = new PdfPTable(Cols)
                        {
                            WidthPercentage = 100
                        };

                        AnchoColumnas = new float[] { 0.04f, 0.013f, 0.025f, 0.1f, 0.08f, 0.028f, 0.015f, 0.07f, 0.01f, 0.02f, 0.02f };
                    }

                    TablaCabDetalle.SetWidths(AnchoColumnas);

                    //Parámetros que pasará al inicio del PDF
                    PaginaInicioCajayBanco ev = new PaginaInicioCajayBanco
                    {
                        MesIni = Convert.ToString(cboInicioMes.SelectedValue),
                        MesFin = Convert.ToString(cboFinMes.SelectedValue),
                        Anio = Convert.ToString(cboAño.SelectedValue),
                        CheckMov = rbEfectivo.Checked ? "E" : "B",
                        AnchoCols = AnchoColumnas,
                        Columnas = Cols
                    };
                    
                    oPdfw.PageEvent = ev;
                    docPdf.Open();

                    //Obteniendo la moneda para saber con que moneda se van a presentar los montos
                    Int32 idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                    Decimal totMovimientoH = 0;
                    Decimal totMovimientoD = 0;
                    Decimal SaldoAnteriorH = 0;
                    Decimal SaldoAnteriorD = 0;
                    //Resultado finales
                    Decimal Result = 0;
                    Decimal totGeneralH = 0;
                    Decimal totGeneralD = 0;

                    if (rbEfectivo.Checked)
                    {
                        #region Detalle
                        
                        foreach (VoucherItemE item in oReporteMovimientos)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idLocal + " " + item.idComprobante + " " + item.numVoucher + " " + item.numFile + " " + item.numItem, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecOperacion.Value.ToString("dd/MM/yy"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.GlosaGeneral, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CuentaOrigen, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuentaOrigen, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));

                            if (idMoneda == 1) //Soles
                            {
                                if (item.indDebeHaber == "H") //Si es haber
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                    //Acumulando para el total por banco
                                    totMovimientoH += item.impSoles;
                                }
                                else //Sino Debe
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                    //Acumulando para el total por banco
                                    totMovimientoD += item.impSoles;
                                }
                            }
                            else //Dólares
                            {
                                if (item.indDebeHaber == "H") //Si es haber
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                    //Acumulando para el total por banco
                                    totMovimientoH += item.impDolares;
                                }
                                else //Sino Debe
                                {
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                    //Acumulando para el total por banco
                                    totMovimientoD += item.impDolares;
                                }
                            }

                            TablaCabDetalle.CompleteRow();
                        }

                        #region Total Movimiento

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("".PadLeft(350, '-'), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2, "S" + Cols.ToString(), "N", 0f, 0f));
                        TablaCabDetalle.CompleteRow();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL MOVIMIENTO >>>>> ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2, "S" + (Cols - 2).ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totMovimientoD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totMovimientoH.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.CompleteRow();

                        #endregion

                        #region Saldo Anterior

                        if (idMoneda == 1)
                        {
                            if (oReporteMovimientos[0].salAntSoles > 0)
                            {
                                SaldoAnteriorD = oReporteMovimientos[0].salAntSoles;
                            }
                            else if (oReporteMovimientos[0].salAntSoles < 0)
                            {
                                SaldoAnteriorH = Math.Abs(oReporteMovimientos[0].salAntSoles);
                            }
                        }
                        else
                        {
                            if (oReporteMovimientos[0].salAntDolares > 0)
                            {
                                SaldoAnteriorD = oReporteMovimientos[0].salAntDolares;
                            }
                            else if (oReporteMovimientos[0].salAntDolares < 0)
                            {
                                SaldoAnteriorH = Math.Abs(oReporteMovimientos[0].salAntDolares);
                            }
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("".PadLeft(350, '-'), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2, "S" + Cols.ToString(), "N", 0f, 0f));
                        TablaCabDetalle.CompleteRow();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ANTERIOR >>>>> ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2, "S" + (Cols - 2).ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SaldoAnteriorD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SaldoAnteriorH.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.CompleteRow();

                        #endregion

                        #region Total General

                        Result = (totMovimientoD - totMovimientoH) + (SaldoAnteriorD - SaldoAnteriorH);

                        if (Result > 0)
                        {
                            totGeneralD = Result;
                        }
                        else if (Result < 0)
                        {
                            totGeneralH = Math.Abs(Result);
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("".PadLeft(350, '-'), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2, "S" + Cols.ToString(), "N", 0f, 0f));
                        TablaCabDetalle.CompleteRow();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL >>>>> ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2, "S" + (Cols - 2).ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGeneralD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGeneralH.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.CompleteRow();

                        #endregion

                        docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                        #endregion
                    }

                    if (rbBancos.Checked)
                    {
                        #region Detalle
                        
                        Decimal totBancoH = 0;
                        Decimal totBancoD = 0;

                        //Agrupando por el nombre del Banco
                        var ListarBancosTmp = oReporteMovimientos.GroupBy(x => x.nomBanco).Select(p => p.First()).ToList();

                        //Recorriendo la lista con los nombres de los bancos
                        foreach (var itemTmp in ListarBancosTmp)
                        {
                            //Nombre del Banco
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ENTIDAD FINANCIERA " + itemTmp.nomBanco.ToUpper(), FondoColor, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 0, "S" + Cols.ToString()));
                            //Sacando la nueva lista de acuerdo al nombre del banco
                            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>(from x in oReporteMovimientos
                                                                                      where x.nomBanco == itemTmp.nomBanco
                                                                                      orderby x.AnioPeriodo, x.MesPeriodo, x.codCuenta
                                                                                      select x).ToList();
                            //Recorriendo la lista
                            foreach (VoucherItemE item in ListaVouchers)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idLocal + " " + item.idComprobante + " " + item.numVoucher + " " + item.numFile + " " + item.numItem, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecOperacion.Value.ToString("dd/MM/yy"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMedioPago, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.GlosaGeneral, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento + " " + item.numDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.CuentaOrigen, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuentaOrigen, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));

                                #region Importes

                                if (idMoneda == 1) //Soles
                                {
                                    if (item.indDebeHaber == "H") //Si es haber
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                        //Acumulando para el total por banco
                                        totBancoH += item.impSoles;
                                    }
                                    else //Sino es Debe
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                        //Acumulando para el total por banco
                                        totBancoD += item.impSoles;
                                    }
                                }
                                else //Dólares
                                {
                                    if (item.indDebeHaber == "H") //Si es haber
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                        //Acumulando para el total por banco
                                        totBancoH += item.impDolares;
                                    }
                                    else //Sino es Debe
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.impDolares.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                                        //Acumulando para el total por banco
                                        totBancoD += item.impDolares;
                                    }
                                } 

                                #endregion

                                TablaCabDetalle.CompleteRow();
                            }

                            #region Totales por Banco

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("".PadLeft(200, '-'), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, ColorLetra), 5, 2, "S" + Cols.ToString(), "N", 0f, 0f));
                            TablaCabDetalle.CompleteRow();

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Total Banco >>>>> ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, ColorLetra), 5, 2, "S" + (Cols - 2).ToString()));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totBancoD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD, ColorLetra), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totBancoH.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD, ColorLetra), 5, 2));
                            TablaCabDetalle.CompleteRow();

                            //Linea en blanco
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2, "S" + Cols.ToString()));
                            TablaCabDetalle.CompleteRow();

                            #endregion

                            //Acumulando para el total de todo el movimiento...
                            totMovimientoH += totBancoH;
                            totMovimientoD += totBancoD;

                            //Limpiando las variables
                            totBancoD = 0;
                            totBancoH = 0;
                        }

                        #region Total Movimiento

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("".PadLeft(350, '-'), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2, "S" + Cols.ToString(), "N", 0f, 0f));
                        TablaCabDetalle.CompleteRow();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL MOVIMIENTO >>>>> ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2, "S" + (Cols - 2).ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totMovimientoD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totMovimientoH.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.CompleteRow();

                        #endregion

                        #region Saldo Anterior

                        if (idMoneda == 1)
                        {
                            if (oReporteMovimientos[0].salAntSoles104 > 0)
                            {
                                SaldoAnteriorD = oReporteMovimientos[0].salAntSoles104;
                            }
                            else if (oReporteMovimientos[0].salAntSoles104 < 0)
                            {
                                SaldoAnteriorH = Math.Abs(oReporteMovimientos[0].salAntSoles104);
                            } 
                        }
                        else
                        {
                            if (oReporteMovimientos[0].salAntDolares104 > 0)
                            {
                                SaldoAnteriorD = oReporteMovimientos[0].salAntDolares104;
                            }
                            else if (oReporteMovimientos[0].salAntDolares104 < 0)
                            {
                                SaldoAnteriorH = Math.Abs(oReporteMovimientos[0].salAntDolares104);
                            }
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("".PadLeft(350, '-'), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2, "S" + Cols.ToString(), "N", 0f, 0f));
                        TablaCabDetalle.CompleteRow();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ANTERIOR >>>>> ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2, "S" + (Cols - 2).ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SaldoAnteriorD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(SaldoAnteriorH.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.CompleteRow();

                        #endregion

                        #region Total General

                        Result = (totMovimientoD - totMovimientoH) + (SaldoAnteriorD - SaldoAnteriorH);

                        if (Result > 0)
                        {
                            totGeneralD = Result;
                        }
                        else if (Result < 0)
                        {
                            totGeneralH = Math.Abs(Result);
                        }

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("".PadLeft(350, '-'), null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 2, "S" + Cols.ToString(), "N", 0f, 0f));
                        TablaCabDetalle.CompleteRow();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL >>>>> ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2, "S" + (Cols - 2).ToString()));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGeneralD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(totGeneralH.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.CompleteRow();
                        
                        #endregion

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
                }
            }
        }

        void ExportExcel()
        {
            #region Variables

            String TituloGeneral = String.Empty;
            String SubTitulos = String.Empty;
            String NombrePestaña = String.Empty;
            String nomMesIni = FechasHelper.NombreMes(Convert.ToInt32(cboInicioMes.SelectedValue)).ToUpper();
            String nomMesFin = FechasHelper.NombreMes(Convert.ToInt32(cboFinMes.SelectedValue)).ToUpper();
            Int32 totColumnas = 0;
            Int32 FilaIni = 0; 

            #endregion

            #region Titulos Principales

            if (rbEfectivo.Checked)
            {
                TituloGeneral = "LIBRO CAJA Y BANCOS - DETALLE DE LOS MOVIMIENTOS DEL EFECTIVO";
                NombrePestaña = "EFECTIVO";
                totColumnas = 8;
                FilaIni = 4;
            }

            if (rbBancos.Checked)
            {
                TituloGeneral = "LIBRO CAJA Y BANCOS- DETALLE DE LOS MOVIMIENTOS DE LA CUENTA CORRIENTE";
                NombrePestaña = "CTA.CTE.";
                totColumnas = 11;
                FilaIni = 4;
            }

            if (cboInicioMes.SelectedValue.ToString() != cboFinMes.SelectedValue.ToString())
            {
                SubTitulos = "DESDE " + nomMesIni + "-" + cboAño.SelectedValue.ToString() + " HASTA " + nomMesFin + "-" + cboAño.SelectedValue.ToString();
            }

            if (cboInicioMes.SelectedValue.ToString() == cboFinMes.SelectedValue.ToString())
            {
                SubTitulos = "PERIODO " + nomMesIni + "-" + cboAño.SelectedValue.ToString();
            }

            #endregion

            if (File.Exists(RutaGeneral)) File.Delete(RutaGeneral);
            FileInfo NuevoArchivo = new FileInfo(RutaGeneral);

            using (ExcelPackage oExcel = new ExcelPackage(NuevoArchivo))
            {
                using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña))
                {
                    //Obteniendo la moneda para saber con que moneda se van a presentar los montos
                    Int32 idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                    Decimal totMovimientoH = 0;
                    Decimal totMovimientoD = 0;
                    Decimal SaldoAnteriorH = 0;
                    Decimal SaldoAnteriorD = 0;
                    //Resultado finales
                    Decimal Result = 0;
                    Decimal totGeneralH = 0;
                    Decimal totGeneralD = 0;

                    #region Titulos

                    oHoja.Cells["A1"].Value = TituloGeneral;
                    oHoja.Row(1).Height = 24;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 12, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    }

                    oHoja.Cells["A2"].Value = SubTitulos;
                    oHoja.Row(2).Height = 20;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, totColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 11, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    }

                    #endregion

                    if (rbEfectivo.Checked)
                    {
                        #region Cabeceras del Detalle

                        oHoja.Cells[FilaIni, 1, FilaIni + 1, 1].Merge = true;
                        oHoja.Cells[FilaIni, 1].Value = "Número Correlativo del Registro o Código Unico de la Operación";
                        oHoja.Cells[FilaIni, 1, FilaIni + 1, 1].Style.WrapText = true;

                        oHoja.Cells[FilaIni, 2, FilaIni + 1, 2].Merge = true;
                        oHoja.Cells[FilaIni, 2].Value = "Fecha de la Operación";
                        oHoja.Cells[FilaIni, 2, FilaIni + 1, 2].Style.WrapText = true;

                        oHoja.Cells[FilaIni, 3, FilaIni + 1, 3].Merge = true;
                        oHoja.Cells[FilaIni, 3].Value = "Descripción de la Operación";
                        oHoja.Cells[FilaIni, 3, FilaIni + 1, 3].Style.WrapText = true;

                        oHoja.Cells[FilaIni, 4, FilaIni, 5].Merge = true;
                        oHoja.Cells[FilaIni, 4].Value = "Cuenta Contable Asociada";

                        oHoja.Cells[FilaIni, 6, FilaIni + 1, 6].Merge = true;
                        oHoja.Cells[FilaIni, 6].Value = "T.C.";

                        oHoja.Cells[FilaIni, 7, FilaIni, 8].Merge = true;
                        oHoja.Cells[FilaIni, 7].Value = "Saldos y Movimientos";

                        oHoja.Row(FilaIni).Height = 18;

                        FilaIni++;

                        oHoja.Cells[FilaIni, 4].Value = "Código";
                        oHoja.Cells[FilaIni, 5].Value = "Denominación";
                        oHoja.Cells[FilaIni, 7].Value = "Deudor";
                        oHoja.Cells[FilaIni, 8].Value = "Acreedor";

                        oHoja.Row(FilaIni).Height = 20;

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni - 1, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni - 1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[FilaIni - 1, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                            oHoja.Cells[FilaIni - 1, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[FilaIni - 1, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            oHoja.Cells[FilaIni - 1, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                            oHoja.Cells[FilaIni, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[FilaIni, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        #endregion

                        #region Ancho de Columnas

                        oHoja.Column(1).Width = 18;
                        oHoja.Column(2).Width = 10;
                        oHoja.Column(3).Width = 45;
                        oHoja.Column(4).Width = 8;
                        oHoja.Column(5).Width = 45;
                        oHoja.Column(6).Width = 5;
                        oHoja.Column(7).Width = 12;
                        oHoja.Column(8).Width = 12;

                        #endregion

                        #region Detalle

                        foreach (VoucherItemE item in oReporteMovimientos)
                        {
                            oHoja.Cells[FilaIni, 1].Value = item.idLocal + " " + item.idComprobante + " " + item.numVoucher + " " + item.numFile + " " + item.numItem;
                            oHoja.Cells[FilaIni, 2].Value = item.fecOperacion.Value;
                            oHoja.Cells[FilaIni, 3].Value = item.GlosaGeneral;
                            oHoja.Cells[FilaIni, 4].Value = item.CuentaOrigen;
                            oHoja.Cells[FilaIni, 5].Value = item.desCuentaOrigen;
                            oHoja.Cells[FilaIni, 6].Value = item.tipCambio;

                            if (idMoneda == 1) //Soles
                            {
                                if (item.indDebeHaber == "H") //Si es haber
                                {
                                    oHoja.Cells[FilaIni, 8].Value = item.impSoles;

                                    //Acumulando para el total por banco
                                    totMovimientoH += item.impSoles;
                                }
                                else //Sino Debe
                                {
                                    oHoja.Cells[FilaIni, 7].Value = item.impSoles;

                                    //Acumulando para el total por banco
                                    totMovimientoD += item.impSoles;
                                }
                            }
                            else //Dólares
                            {
                                if (item.indDebeHaber == "H") //Si es haber
                                {
                                    oHoja.Cells[FilaIni, 8].Value = item.impDolares;

                                    //Acumulando para el total por banco
                                    totMovimientoH += item.impDolares;
                                }
                                else //Sino Debe
                                {
                                    oHoja.Cells[FilaIni, 7].Value = item.impDolares;

                                    //Acumulando para el total por banco
                                    totMovimientoD += item.impDolares;
                                }
                            }

                            #region Formateo de las filas

                            for (int i = 1; i <= totColumnas; i++)
                            {
                                oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                if (i > 5)
                                {
                                    oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                    if (i == 6)
                                    {
                                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "##0.000";
                                    }
                                    else
                                    {
                                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                                    }
                                }

                                if (i == 1 || i == 2 || i == 4)
                                {
                                    if (i == 2)
                                    {
                                        oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "dd/MM/yyyy";
                                    }

                                    oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                }
                            }

                            #endregion

                            FilaIni++;
                        }

                        #region Total Movimiento

                        FilaIni++;

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Dashed;
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }

                        oHoja.Cells[FilaIni, 5].Value = "TOTAL MOVIMIENTO >>>>> ";
                        oHoja.Cells[FilaIni, 7].Value = totMovimientoD;
                        oHoja.Cells[FilaIni, 8].Value = totMovimientoH;

                        FilaIni++;

                        #endregion

                        #region Saldo Anterior

                        if (idMoneda == 1)
                        {
                            if (oReporteMovimientos[0].salAntSoles > 0)
                            {
                                SaldoAnteriorD = oReporteMovimientos[0].salAntSoles;
                            }
                            else if (oReporteMovimientos[0].salAntSoles < 0)
                            {
                                SaldoAnteriorH = Math.Abs(oReporteMovimientos[0].salAntSoles);
                            }
                        }
                        else
                        {
                            if (oReporteMovimientos[0].salAntDolares > 0)
                            {
                                SaldoAnteriorD = oReporteMovimientos[0].salAntDolares;
                            }
                            else if (oReporteMovimientos[0].salAntDolares < 0)
                            {
                                SaldoAnteriorH = Math.Abs(oReporteMovimientos[0].salAntDolares);
                            }
                        }

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Dashed;
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }

                        oHoja.Cells[FilaIni, 5].Value = "SALDO ANTERIOR >>>>> ";
                        oHoja.Cells[FilaIni, 7].Value = SaldoAnteriorD;
                        oHoja.Cells[FilaIni, 8].Value = SaldoAnteriorH;

                        FilaIni++;

                        #endregion

                        #region Total General

                        Result = (totMovimientoD - totMovimientoH) + (SaldoAnteriorD - SaldoAnteriorH);

                        if (Result > 0)
                        {
                            totGeneralD = Result;
                        }
                        else if (Result < 0)
                        {
                            totGeneralH = Math.Abs(Result);
                        }

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Dashed;
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }

                        oHoja.Cells[FilaIni, 5].Value = "TOTAL GENERAL >>>>> ";
                        oHoja.Cells[FilaIni, 7].Value = totGeneralD;
                        oHoja.Cells[FilaIni, 8].Value = totGeneralH;

                        FilaIni++;

                        #endregion

                        #endregion
                    }

                    if (rbBancos.Checked)
                    {
                        #region Cabeceras del Detalle

                        oHoja.Cells[FilaIni, 1, FilaIni + 1, 1].Merge = true;
                        oHoja.Cells[FilaIni, 1].Value = "Número Correlativo del Registro o Código Unico de la Operación";
                        oHoja.Cells[FilaIni, 1, FilaIni + 1, 1].Style.WrapText = true;

                        oHoja.Cells[FilaIni, 2, FilaIni + 1, 2].Merge = true;
                        oHoja.Cells[FilaIni, 2].Value = "Fecha de la Operación";
                        oHoja.Cells[FilaIni, 2, FilaIni + 1, 2].Style.WrapText = true;

                        oHoja.Cells[FilaIni, 3, FilaIni, 5].Merge = true;
                        oHoja.Cells[FilaIni, 3].Value = "Operaciones Bancarias";

                        oHoja.Cells[FilaIni, 6, FilaIni + 1, 6].Merge = true;
                        oHoja.Cells[FilaIni, 6].Value = "Núm. Transf. Banc. del Docu. Sustentatorio del Ctrl. Interno de la Oper.";
                        oHoja.Cells[FilaIni, 6, FilaIni + 1, 6].Style.WrapText = true;

                        oHoja.Cells[FilaIni, 7, FilaIni, 8].Merge = true;
                        oHoja.Cells[FilaIni, 7].Value = "Cuenta Contable Asociada";

                        oHoja.Cells[FilaIni, 9, FilaIni + 1, 9].Merge = true;
                        oHoja.Cells[FilaIni, 9].Value = "T.C.";

                        oHoja.Cells[FilaIni, 10, FilaIni, 11].Merge = true;
                        oHoja.Cells[FilaIni, 10].Value = "Saldos y Movimientos";

                        oHoja.Row(FilaIni).Height = 18;

                        FilaIni++;

                        oHoja.Cells[FilaIni, 3].Value = "Medio Pago";
                        oHoja.Cells[FilaIni, 4].Value = "Descripción de la Operación";
                        oHoja.Cells[FilaIni, 5].Value = "Apellidos y Nombres ó Razón Social";
                        oHoja.Cells[FilaIni, 7].Value = "Código";
                        oHoja.Cells[FilaIni, 8].Value = "Denominación";
                        oHoja.Cells[FilaIni, 10].Value = "Deudor";
                        oHoja.Cells[FilaIni, 11].Value = "Acreedor";

                        oHoja.Row(FilaIni).Height = 20;

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni - 1, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni - 1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[FilaIni - 1, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                            oHoja.Cells[FilaIni - 1, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[FilaIni - 1, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            oHoja.Cells[FilaIni - 1, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[FilaIni, i].Style.Fill.BackgroundColor.SetColor(Color.Silver);
                            oHoja.Cells[FilaIni, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[FilaIni, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        #endregion

                        #region Ancho de Columnas

                        oHoja.Column(1).Width = 18;
                        oHoja.Column(2).Width = 10;
                        oHoja.Column(3).Width = 15;
                        oHoja.Column(4).Width = 45;
                        oHoja.Column(5).Width = 45;
                        oHoja.Column(6).Width = 20;
                        oHoja.Column(7).Width = 8;
                        oHoja.Column(8).Width = 30;
                        oHoja.Column(9).Width = 5;
                        oHoja.Column(10).Width = 12;
                        oHoja.Column(11).Width = 12;

                        #endregion

                        #region Detalle

                        Decimal totBancoH = 0;
                        Decimal totBancoD = 0;

                        //Agrupando por el nombre del Banco
                        var ListarBancosTmp = oReporteMovimientos.GroupBy(x => x.nomBanco).Select(p => p.First()).ToList();

                        //Recorriendo la lista con los nombres de los bancos
                        foreach (var itemTmp in ListarBancosTmp)
                        {
                            FilaIni++;
                            //Nombre del Banco
                            oHoja.Cells[FilaIni, 1].Value = "ENTIDAD FINANCIERA " + itemTmp.nomBanco.ToUpper();

                            using (ExcelRange Rango = oHoja.Cells[FilaIni, 1, FilaIni, totColumnas])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }

                            //Sacando la nueva lista de acuerdo al nombre del banco
                            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>(from x in oReporteMovimientos
                                                                                      where x.nomBanco == itemTmp.nomBanco
                                                                                      orderby x.AnioPeriodo, x.MesPeriodo, x.codCuenta
                                                                                      select x).ToList();
                            FilaIni++;

                            //Recorriendo la lista
                            foreach (VoucherItemE item in ListaVouchers)
                            {
                                oHoja.Cells[FilaIni, 1].Value = item.idLocal + " " + item.idComprobante + " " + item.numVoucher + " " + item.numFile + " " + item.numItem;
                                oHoja.Cells[FilaIni, 2].Value = item.fecOperacion.Value;
                                oHoja.Cells[FilaIni, 3].Value = item.desMedioPago;
                                oHoja.Cells[FilaIni, 4].Value = item.GlosaGeneral;
                                oHoja.Cells[FilaIni, 5].Value = item.RazonSocial;
                                oHoja.Cells[FilaIni, 6].Value = item.idDocumento + " " + item.numDocumento;
                                oHoja.Cells[FilaIni, 7].Value = item.CuentaOrigen;
                                oHoja.Cells[FilaIni, 8].Value = item.desCuentaOrigen;
                                oHoja.Cells[FilaIni, 9].Value = item.tipCambio;

                                if (idMoneda == 1) //Soles
                                {
                                    if (item.indDebeHaber == "H") //Si es haber
                                    {
                                        oHoja.Cells[FilaIni, 11].Value = item.impSoles;

                                        //Acumulando para el total por banco
                                        totBancoH += item.impSoles;
                                    }
                                    else //Sino es Debe
                                    {
                                        oHoja.Cells[FilaIni, 10].Value = item.impSoles;

                                        //Acumulando para el total por banco
                                        totBancoD += item.impSoles;
                                    }
                                }
                                else //Dólares
                                {
                                    if (item.indDebeHaber == "H") //Si es haber
                                    {
                                        oHoja.Cells[FilaIni, 11].Value = item.impDolares;

                                        //Acumulando para el total por banco
                                        totBancoH += item.impDolares;
                                    }
                                    else //Sino es Debe
                                    {
                                        oHoja.Cells[FilaIni, 10].Value = item.impDolares;

                                        //Acumulando para el total por banco
                                        totBancoD += item.impDolares;
                                    }
                                }

                                #region Formateo de las filas

                                for (int i = 1; i <= totColumnas; i++)
                                {
                                    oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));

                                    if (i > 8)
                                    {
                                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                        if (i == 9)
                                        {
                                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "##0.000";
                                        }
                                        else
                                        {
                                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                                        }
                                    }

                                    if (i == 1 || i == 2 || i == 7)
                                    {
                                        if (i == 2)
                                        {
                                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "dd/MM/yyyy";
                                        }

                                        oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    }
                                }

                                #endregion

                                FilaIni++;
                            }

                            #region Totales por Banco

                            FilaIni++;

                            for (int i = 5; i <= 11; i++)
                            {
                                oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Dashed;
                                oHoja.Cells[FilaIni, i].Style.Border.Top.Color.SetColor(Color.Navy);
                                oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                                oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                oHoja.Cells[FilaIni, i].Style.Font.Color.SetColor(Color.Navy);
                            }

                            oHoja.Cells[FilaIni, 8].Value = "Total Banco >>>>> ";
                            oHoja.Cells[FilaIni, 10].Value = totBancoD;
                            oHoja.Cells[FilaIni, 11].Value = totBancoH;

                            FilaIni++;

                            #endregion

                            //Acumulando para el total de todo el movimiento...
                            totMovimientoH += totBancoH;
                            totMovimientoD += totBancoD;

                            //Limpiando las variables
                            totBancoD = 0;
                            totBancoH = 0;
                        }

                        #region Total Movimiento

                        FilaIni++;

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Dashed;
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }

                        oHoja.Cells[FilaIni, 8].Value = "TOTAL MOVIMIENTO >>>>> ";
                        oHoja.Cells[FilaIni, 10].Value = totMovimientoD;
                        oHoja.Cells[FilaIni, 11].Value = totMovimientoH;

                        FilaIni++;

                        #endregion

                        #region Saldo Anterior

                        if (idMoneda == 1)
                        {
                            if (oReporteMovimientos[0].salAntSoles > 0)
                            {
                                SaldoAnteriorD = oReporteMovimientos[0].salAntSoles;
                            }
                            else if (oReporteMovimientos[0].salAntSoles < 0)
                            {
                                SaldoAnteriorH = Math.Abs(oReporteMovimientos[0].salAntSoles);
                            }
                        }
                        else
                        {
                            if (oReporteMovimientos[0].salAntDolares > 0)
                            {
                                SaldoAnteriorD = oReporteMovimientos[0].salAntDolares;
                            }
                            else if (oReporteMovimientos[0].salAntDolares < 0)
                            {
                                SaldoAnteriorH = Math.Abs(oReporteMovimientos[0].salAntDolares);
                            }
                        }

                        FilaIni++;

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Dashed;
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }

                        oHoja.Cells[FilaIni, 8].Value = "SALDO ANTERIOR >>>>> ";
                        oHoja.Cells[FilaIni, 10].Value = SaldoAnteriorD;
                        oHoja.Cells[FilaIni, 11].Value = SaldoAnteriorH;

                        FilaIni++;

                        #endregion

                        #region Total General

                        Result = (totMovimientoD - totMovimientoH) + (SaldoAnteriorD - SaldoAnteriorH);

                        if (Result > 0)
                        {
                            totGeneralD = Result;
                        }
                        else if (Result < 0)
                        {
                            totGeneralH = Math.Abs(Result);
                        }

                        FilaIni++;

                        for (int i = 1; i <= totColumnas; i++)
                        {
                            oHoja.Cells[FilaIni, i].Style.Border.Top.Style = ExcelBorderStyle.Dashed;
                            oHoja.Cells[FilaIni, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[FilaIni, i].Style.Numberformat.Format = "###,##0.00";
                            oHoja.Cells[FilaIni, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }

                        oHoja.Cells[FilaIni, 8].Value = "TOTAL GENERAL >>>>> ";
                        oHoja.Cells[FilaIni, 10].Value = totGeneralD;
                        oHoja.Cells[FilaIni, 11].Value = totGeneralH;

                        FilaIni++;

                        #endregion 

                        #endregion
                    }

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Módulo de Contabilidad";
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

        void CambiosChecked()
        {
            if (rbEfectivo.Checked)
            {
                //CheckMov = "Efectivo";
                txtCuentaIni.Text = "101";
                txtCuentaFin.Text = "101";
                ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
                ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
            }
            if (rbBancos.Checked)
            {
                //CheckMov = "Bancos";
                txtCuentaIni.Text = "104";
                txtCuentaFin.Text = "104";
                ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
                ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
            }
        }

        void ObtenerDescripcionCuenta(TextBox txtcuenta, TextBox txtdescripcion)
        {
            if (!String.IsNullOrWhiteSpace(txtcuenta.Text.Trim()))
            {
                txtdescripcion.Text = AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtcuenta.Text.ToString());
            }
            else
            {
                txtdescripcion.Text = String.Empty;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oReporteMovimientos == null || oReporteMovimientos.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreArchivo = "Libro Caja y Bancos - Efectivo ";

                if (rbBancos.Checked)
                {
                    NombreArchivo = "Libro Caja y Bancos - CtaCte ";
                }

                if (cboInicioMes.SelectedValue.ToString() == cboFinMes.SelectedValue.ToString())
                {
                    NombreArchivo += cboInicioMes.SelectedValue.ToString() + "-" + cboAño.SelectedValue.ToString();
                }
                else
                {
                    NombreArchivo += cboInicioMes.SelectedValue.ToString() + "-" + cboAño.SelectedValue.ToString() + " al " + cboFinMes.SelectedValue.ToString() + "-" + cboAño.SelectedValue.ToString();
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Archivos Excel (*.xlsx)|*.xlsx");

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
                    String CuentaIni = txtCuentaIni.Text.Trim();
                    String CuentaFin = txtCuentaFin.Text.Trim();
                    String Plan = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                    Int32 local = Convert.ToInt32(cboSucursales.SelectedValue);

                    if (rbEfectivo.Checked)
                    {
                        lblProcesando.Text = "Obteniendo los Movimientos de Efectivo...";
                        oReporteMovimientos = AgenteContabilidad.Proxy.RepVoucherItemMovimientoEFectivoOpe(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, local, Plan, cboAño.SelectedValue.ToString(), cboInicioMes.SelectedValue.ToString(), cboFinMes.SelectedValue.ToString(), CuentaIni, CuentaFin);
                        lblProcesando.Text = "Armando el Reporte...";
                        ConvertirApdf();
                    }

                    if (rbBancos.Checked)
                    {
                        lblProcesando.Text = "Obteniendo los Movimientos Cta Cte...";
                        oReporteMovimientos = AgenteContabilidad.Proxy.RepVoucherItemMovimientoCtaCteOpe(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, local, Plan, cboAño.SelectedValue.ToString(), cboInicioMes.SelectedValue.ToString(), cboFinMes.SelectedValue.ToString(), CuentaIni, CuentaFin);
                        lblProcesando.Text = "Armando el Reporte...";
                        ConvertirApdf();
                    }
                }
                else
                {
                    ExportExcel();
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
            else
            {
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
                    Global.MensajeComunicacion("Movimientos Exportados...");
                } 
            }
        }

        #endregion

        #region Eventos

        private void frmReporteCajayBanco_Load(object sender, EventArgs e)
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
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void frmReporteCajayBanco_FormClosing(object sender, FormClosingEventArgs e)
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

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            CambiosChecked();
        }

        private void txtCuentaIni_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
        }

        private void txtCuentaFin_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        } 

        #endregion

    }

    #region Pdf Inicio

    class PaginaInicioCajayBanco : PdfPageEventHelper
    {
        public String MesIni { get; set; }
        public String MesFin { get; set; }
        public String Anio { get; set; }
        public String CheckMov { get; set; }
        public Int32 Columnas { get; set; }
        public float[] AnchoCols { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            String SubTitulo = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            String NombreMesIni = String.Empty;
            String NombreMesFin = String.Empty;
            BaseColor ColorFondo = new BaseColor(Color.Silver);

            #region Meses

            NombreMesIni = FechasHelper.NombreMes(Convert.ToInt32(MesIni)).ToUpper();
            NombreMesFin = FechasHelper.NombreMes(Convert.ToInt32(MesFin)).ToUpper();

            #endregion

            //Cabecera del Reporte
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            #region Encabezado

            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            table.CompleteRow(); //Fila completada 

            #endregion

            #region Titulos Principales

            if (CheckMov == "E")
            {
                table.AddCell(ReaderHelper.NuevaCelda("LIBRO CAJA Y BANCOS - DETALLE DE LOS MOVIMIENTOS DEL EFECTIVO", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            }

            if (CheckMov == "B")
            {
                table.AddCell(ReaderHelper.NuevaCelda("LIBRO CAJA Y BANCOS - DETALLE DE LOS MOVIMIENTOS DE LA CUENTA CORRIENTE", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            }

            table.CompleteRow(); //Fila completada

            #endregion

            #region Subtitulos

            //Fila completada
            if (MesIni != MesFin)
            {
                table.AddCell(ReaderHelper.NuevaCelda("DESDE " + NombreMesIni + "-" + Anio + " HASTA " + NombreMesFin + "-" + Anio, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            }
            if (MesIni == MesFin)
            {
                table.AddCell(ReaderHelper.NuevaCelda("Periodo " + NombreMesIni + "-" + Anio, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            }

            table.CompleteRow();

            #endregion

            //Fila en blanco
            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            table.CompleteRow(); //Fila completada

            document.Add(table); //Añadiendo la tabla al documento PDF

            //Nueva tabla para las cabeceras del detalle
            PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
            {
                WidthPercentage = 100
            };

            TablaCabDetalle.SetWidths(AnchoCols);

            #region Cabecera del Detalle

            if (CheckMov == "E")
            {
                #region Primera Linea

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Número Correlativo del Registro o Código Unico de la Operación", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Fecha de la Operación", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Descripción de la Operación", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2", 4));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Cuenta Contable Asociada", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Saldos y Movimientos", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4));
                TablaCabDetalle.CompleteRow(); 

                #endregion

                #region Segunda Linea

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Código", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Denominación", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Deudor", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Acreedor", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.CompleteRow();

                #endregion
            }

            if (CheckMov == "B")
            {
                #region Primera Linea

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Número Correlativo del Registro o Código Unico de la Operación", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Fecha de la Operación", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Operaciones Bancarias", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S3", "N", 4));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Núm. Transf. Banc. del Docu. Sustentatorio del Ctrl. Interno de la Oper.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Cuenta Contable Asociada", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Saldos y Movimientos", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 4));
                TablaCabDetalle.CompleteRow();

                #endregion

                #region Segunda Linea

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Medio Pago", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Descripción de la Operación", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Apellidos y Nombres ó Razón Social", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Código", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Denominación", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Deudor", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Acreedor", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
                TablaCabDetalle.CompleteRow();

                #endregion
            }

            #endregion

            document.Add(TablaCabDetalle);
        }
    }

    #endregion
}
