using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteRegistroVentaseIngresos : FrmMantenimientoBase
    {

        public frmReporteRegistroVentaseIngresos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        #region Variables
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroVentasE> oListaRegistroVentas = null;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        //Int32 letra = 0;
        String tipo= "";
        readonly BackgroundWorker _bw = new BackgroundWorker();
        //Int16 Formato = 1;

        #endregion

        #region Procedimientos de Pdf

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

            if (listaLocales.Count == 2)
            {
                cboSucursales.SelectedValue = 1;
            }

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMonedas.DataSource = (from x in ListaMoneda
                                     where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                     orderby x.idMoneda
                                     select x).ToList();
            cboMonedas.ValueMember = "idMoneda";
            cboMonedas.DisplayMember = "desMoneda";
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A3.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Registro de Ventas de " + FechasHelper.NombreMes(dtpFecIni.Value.Month) + " " + Aleatorio.ToString();
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

                InicioVentaeIngresos ev = new InicioVentaeIngresos();
                ev.Periodo = dtpFecIni.Value.Date;
                ev.PeriodoFin = dtpFecFin.Value.Date;
                ev.Moneda = cboMonedas.SelectedValue.ToString();
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle
                Decimal Sub1 = 0;
                Decimal Sub2 = 0;
                Decimal Sub3 = 0;
                Decimal Sub4 = 0;
                Decimal Sub5 = 0;
                Decimal Sub6 = 0;
                int Columnas = 19;
                PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.02f, 0.02f, 0.05f, 0.02f, 0.02f, 0.05f, 0.03f, 0.1f, 0.25f, 0.07f, 0.07f, 0.07f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f });

                foreach (RegistroVentasE item in oListaRegistroVentas)
                {
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecDocumento.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipDocVentaRef, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.SerieRef, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.NumeroRef, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipDocVenta, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Serie, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Numero, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipDocPersona, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocPersona, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.BaseInafecta.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.BaseExportacion.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.BaseImponible.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Isc.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Igv.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Total.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5,2));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Voucher, null, "N", null, FontFactory.GetFont("Arial", 5f), 5,1));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Tica.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5,2));


                    TablaCabDetalle.CompleteRow();
                    Sub1 += item.BaseInafecta;
                    Sub2 += item.BaseExportacion;
                    Sub3 += item.BaseImponible;
                    Sub4 += item.Isc;
                    Sub5 += item.Igv;
                    Sub6 += item.Total;
                }

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1, "S19"));
                TablaCabDetalle.CompleteRow();
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL GENERAL ==>", null, "N", null, FontFactory.GetFont("Arial", 5f), 5,1,"S10"));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Sub1.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Sub2.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Sub3.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Sub4.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Sub5.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Sub6.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                DateTime fecInicial = dtpFecIni.Value.Date;
                DateTime fecFin = dtpFecFin.Value.Date;
                String idMoneda = cboMonedas.SelectedValue.ToString();
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);

                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el Registro de Ventas...";
                oListaRegistroVentas = AgenteContabilidad.Proxy.RegistroDeVentasLe(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, fecInicial, fecFin, idMoneda);

                //if (oListaRegistroVentas.Count > Variables.Cero)
                //{
                //    RegistroVentasE oRegVentasTotal = new RegistroVentasE()
                //    {
                //        fecDocumento = (Nullable<DateTime>)null,
                //        fecVencimiento = (Nullable<DateTime>)null,
                //        RazonSocial = "       Totales Acumulados >>>>>>>>>>",
                //        BaseExportacion = (from x in oListaRegistroVentas select x.BaseExportacion).Sum(),
                //        BaseImponible = (from x in oListaRegistroVentas select x.BaseImponible).Sum(),
                //        BaseExonerada = (from x in oListaRegistroVentas select x.BaseExonerada).Sum(),
                //        BaseInafecta = (from x in oListaRegistroVentas select x.BaseInafecta).Sum(),
                //        Igv = (from x in oListaRegistroVentas select x.Igv).Sum(),
                //        Total = (from x in oListaRegistroVentas select x.Total).Sum(),
                //    };

                //    oListaRegistroVentas.Add(oRegVentasTotal);
                //}

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
                Global.MensajeComunicacion("Registros de Ventas e Ingresos...");
            }
        }

        #endregion

        #region Exportar Excel

        public override void Exportar()
        {
            try
            {
                if (oListaRegistroVentas == null || oListaRegistroVentas.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String mes = dtpFecIni.Value.ToString("MM");
                String anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Ventas Periodo " + mes + "-" + anio, "Archivos Excel (*.xlsx)|*.xlsx");

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
            DateTime Ini = Convert.ToDateTime(dtpFecIni.Value);
            DateTime Fin = Convert.ToDateTime(dtpFecFin.Value);

            TituloGeneral = "REPORTE DE VENTAS E INGRESOS";
            NombrePestaña = "REPORTE DE VENTAS" ;

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 19;

                    #region Titulos Principales

                    // Creando Encabezado
                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 18, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(58, 58, 56));
                    }

                    oHoja.Cells["A2"].Value = "DEL " + Ini.ToString("d") + " AL " + Fin.ToString("d");

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(117, 113, 113));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "FECHA";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, 5, 1])
                    {
                        Rango.Merge = true;
                    }


                    oHoja.Cells[InicioLinea, 2].Value = "REFERENCIA";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 4])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 5].Value = "DOCUMENTO";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea, 7])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 8].Value = "TD";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, 5, 8])
                    {
                        Rango.Merge = true;
                    }
                    oHoja.Cells[InicioLinea, 9].Value = "RUC";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, 5, 9])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 10].Value = "CLIENTE";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 10, 5, 10])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 11].Value = "BASE";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 11, InicioLinea, 13])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 14].Value = "ISC";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 14, 5, 14])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 15].Value = "IGV";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 15, 5, 15])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 16].Value = "TOTAL";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 16, 5, 16])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 17].Value = "NUMERO ASIENTO";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 17, 5, 17])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 18].Value = "REFERENCIA DOLARES";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 18, 5, 18])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 19].Value = "TIPO CAMBIO" ;

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 19, 5, 19])
                    {
                        Rango.Merge = true;
                    }

                    for (int i = 1; i <= 19; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(208, 206, 206));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    InicioLinea++;

                   

                    oHoja.Cells[InicioLinea, 2].Value = "TD";
                    using (ExcelRange Rango = oHoja.Cells[6, 2, 6, 2])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 3].Value = "SER.";
                    using (ExcelRange Rango = oHoja.Cells[6, 3, 6, 3])
                    {
                        Rango.Merge = true;
                    }


                    oHoja.Cells[InicioLinea, 4].Value = "NUMERO";

                    using (ExcelRange Rango = oHoja.Cells[6, 4, 6, 4])
                    {
                        Rango.Merge = true;
                    }


                    oHoja.Cells[InicioLinea, 5].Value = "TD";

                    using (ExcelRange Rango = oHoja.Cells[6, 5, 6, 5])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 6].Value = "SER.";

                    using (ExcelRange Rango = oHoja.Cells[6, 6, 6, 6])
                    {
                        Rango.Merge = true;
                    }
                    oHoja.Cells[InicioLinea, 7].Value = "NUMERO";

                    using (ExcelRange Rango = oHoja.Cells[6, 7, 6, 7])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 11].Value = "BASE GRAVADO";

                    using (ExcelRange Rango = oHoja.Cells[6, 11, 6, 11])
                    {
                        Rango.Merge = true;
                    }

                    oHoja.Cells[InicioLinea, 12].Value = "EXO. EXPORT.";
                    using (ExcelRange Rango = oHoja.Cells[6, 12, 6, 12])
                    {
                        Rango.Merge = true;
                    }



                    oHoja.Cells[InicioLinea, 13].Value = "EXO NAC.";

                    using (ExcelRange Rango = oHoja.Cells[6, 13, 6, 13])
                    {
                        Rango.Merge = true;
                    }

                    for (int i = 1; i <= 19; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(208, 206, 206));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    InicioLinea++;




                    //// Auto Filtro
                    //oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    ////Aumentando una Fila mas continuar con el detalle
                    //InicioLinea++;

                    #endregion

                    #region Detallado

                    Decimal Sub1 = 0;
                    Decimal Sub2 = 0;
                    Decimal Sub3 = 0;
                    Decimal Sub4 = 0;
                    Decimal Sub5 = 0;
                    Decimal Sub6 = 0;

                    foreach (RegistroVentasE item in oListaRegistroVentas)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.fecDocumento;
                        oHoja.Cells[InicioLinea, 2].Value = item.tipDocVentaRef;
                        oHoja.Cells[InicioLinea, 3].Value = item.SerieRef;
                        oHoja.Cells[InicioLinea, 4].Value = item.NumeroRef;
                        oHoja.Cells[InicioLinea, 5].Value = item.tipDocVenta;
                        oHoja.Cells[InicioLinea, 6].Value = item.Serie;
                        oHoja.Cells[InicioLinea, 7].Value = item.Numero;
                        oHoja.Cells[InicioLinea, 8].Value = item.tipDocPersona;
                        oHoja.Cells[InicioLinea, 9].Value = item.numDocPersona;
                        oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 11].Value = item.BaseInafecta;
                        oHoja.Cells[InicioLinea, 12].Value = item.BaseExportacion;
                        oHoja.Cells[InicioLinea, 13].Value = item.BaseImponible;
                        oHoja.Cells[InicioLinea, 14].Value = item.Isc;
                        oHoja.Cells[InicioLinea, 15].Value = item.Igv;
                        oHoja.Cells[InicioLinea, 16].Value = item.Total;
                        oHoja.Cells[InicioLinea, 17].Value = item.Voucher;
                        oHoja.Cells[InicioLinea, 18].Value = " ";
                        oHoja.Cells[InicioLinea, 19].Value = item.Tica;     


                        oHoja.Cells[InicioLinea, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                        InicioLinea++;
                        Sub1 += item.BaseInafecta;
                        Sub2 += item.BaseExportacion;
                        Sub3 += item.BaseImponible;
                        Sub4 += item.Isc;
                        Sub5 += item.Igv;
                        Sub6 += item.Total;
                    }

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 10].Value = "TOTAL GENERAL";
                    oHoja.Cells[InicioLinea, 11].Value = Sub1;
                    oHoja.Cells[InicioLinea, 12].Value = Sub2;
                    oHoja.Cells[InicioLinea, 13].Value = Sub3;
                    oHoja.Cells[InicioLinea, 14].Value = Sub4;
                    oHoja.Cells[InicioLinea, 15].Value = Sub5;
                    oHoja.Cells[InicioLinea, 16].Value = Sub6;

                    InicioLinea++;

                    #endregion



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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
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

        private void frmReporteRegistroVentaseIngresos_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
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
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }
        
        #endregion

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String dia = dtpFecFin.Value.Day.ToString();
                dtpFecFin.Value = Convert.ToDateTime(dia + "/" + dtpFecIni.Value.Month.ToString("00") + "/" + dtpFecIni.Value.Year.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
    }
}

#region Inicio Pdf

class InicioVentaeIngresos : PdfPageEventHelper
{
    public DateTime Periodo { get; set; }

    public DateTime PeriodoFin { get; set; }

    public String Moneda { get; set; }

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


        TituloGeneral = "REGISTRO DE VENTAS DEL " + Periodo.Date.ToString("d") + " Al " + PeriodoFin.Date.ToString("d");


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

        document.Add(table);//Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(19);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.02f, 0.02f, 0.05f, 0.02f, 0.02f, 0.05f, 0.03f, 0.1f, 0.25f, 0.07f, 0.07f, 0.07f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f});

        #region Primera Linea

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));        
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("REFERENCIA", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1,"S3"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DOCUMENTO", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1,"S3"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TD", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RUC", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CLIENTE", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("BASE", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1,"S3"));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ISC", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1)); ;
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IGV", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1)); ;
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1)); ;
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUMERO ASIENTO", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("REFERENCIA DOLARES", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

        TablaCabDetalle.CompleteRow();

        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Td", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Ser.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Numero", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Td", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Ser.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Numero", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Base Gravado", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Exo. Export.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Exo Nac.", BaseColor.LIGHT_GRAY, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        TablaCabDetalle.CompleteRow();

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

        #endregion
    }

}

#endregion