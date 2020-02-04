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
using ClienteWinForm.Busquedas;

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
    public partial class frmReporteResumenetalleCentrodeCosto : FrmMantenimientoBase
    {
        public frmReporteResumenetalleCentrodeCosto()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        List<Con_SaldosCostosE> OListaSaldoCosto = null;
        List<Con_SaldosCostosE> listaSaldoCosto = null;

        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        Int32 letra = 0;
        int tipoProceso = 0; // 1 buscar; 0 exportar;

        String desMoneda;
        String mesIni;
        String mesFin;
        String Anio;

        readonly BackgroundWorker _bw = new BackgroundWorker();

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
            cboMoneda.DisplayMember = "desMoneda";


            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, listaLocales, "idLocal", "Nombre", false);

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

        void ListaReporte()
        {
            try
            {
                DateTime fecInicial = dtpFecIni.Value.Date;
                DateTime fecFin = dtpFecFin.Value.Date;
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                String codCuentaIni = txtCuentaIni.Text;
                String codCuentaFin = txtCuentaFin.Text;
                Int32 numNivel = Convert.ToInt32(cboNivel.SelectedValue);

                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el Reporte ...";

                OListaSaldoCosto = AgenteContabilidad.Proxy.ObtenerResumenDetallePorCentrodeCosto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, VariablesLocales.PeriodoContable.AnioPeriodo, fecInicial.Month.ToString("00"), fecFin.Month.ToString("00"), VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, codCuentaIni, codCuentaFin,numNivel);

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }

        #endregion

        #region Evento Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            lblProcesando.Text = "Armando el Reporte de Registro de Diario...";
            //Generando el PDF
            if (tipoProceso == 1)
            {
                ListaReporte();
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
            Marque = String.Empty;
            //timer.Enabled = false;
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            //Mostrando el reporte en un web browser
            if (tipoProceso == 1)
            {
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                    tipoProceso = 0;
                }

            }
        }

        void CargarLista(string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8)
        {
            //RegistroDiarioE objRegistroDiario = new RegistroDiarioE();
            //objRegistroDiario.Nivel1 = param1;
            //objRegistroDiario.desCuenta = param2;
            //objRegistroDiario.TD = param3;
            //objRegistroDiario.NumDocumento = param4;
            //objRegistroDiario.Fecha = param5;
            //objRegistroDiario.Glosa_General = param6;
            //objRegistroDiario.IdDocumento = param7;
            //objRegistroDiario.IdComprobante = param8;
            //listRegistroDiario.Add(objRegistroDiario);
        }

        void Pivot()
        {
            //List emp = new List();
            //emp.Add(new Employee { EmpID = 1, SalaryDate = new DateTime(2008, 1, 1), Salary = 1234 });
            //emp.Add(new Employee { EmpID = 1, SalaryDate = new DateTime(2009, 2, 1), Salary = 456 });
            //emp.Add(new Employee { EmpID = 2, SalaryDate = new DateTime(2008, 1, 1), Salary = 2234 });
            //emp.Add(new Employee { EmpID = 2, SalaryDate = new DateTime(2009, 2, 1), Salary = 121345 });
            //emp.Add(new Employee { EmpID = 3, SalaryDate = new DateTime(2003, 2, 1), Salary = 1245 });
            //emp.Add(new Employee { EmpID = 3, SalaryDate = new DateTime(2011, 3, 1), Salary = 5623 });

            //var result = emp
            //.GroupBy(c => c.EmpID)
            //.Select(g => new
            //{
            //    EmpID = g.Key,
            //    Jan = g.Where(c => c.SalaryDate.Month == 1).Sum(c => c.Salary),
            //    Feb = g.Where(c => c.SalaryDate.Month == 2).Sum(c => c.Salary),
            //    March = g.Where(c => c.SalaryDate.Month == 3).Sum(c => c.Salary)
            //});

            //foreach (var data in result)
            //{
            //    Console.WriteLine(data.EmpID + " , " + data.Jan + " , " + data.Feb + " , " + data.March);
            //}
            //Console.ReadLine();

            var rs = new List<Con_SaldosCostosE>(OListaSaldoCosto);

            var valores = OListaSaldoCosto
                   .GroupBy(c => c.idCCostos )
                   .Select(g => new
                   {
                       codcuenta= g.Key,
                       descripcioin = g.Key,
                       idccosto = g.Key,
                       SAL_ACTUAL_SOLES = g.Where(c => c.indNaturalezaCta  == "D").Sum(c => c.TOT_DEBE_SOLES - c.TOT_HABER_SOLES  )  
                   });


            foreach (var data in rs)
            {
                Console.WriteLine(data.idCCostos + " - " + data.descripcion + " - " + data.SAL_ACTUAL_SOLES);
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            String NombreReporte = @"\Resumen Centro Costos " + FechasHelper.NombreMes(dtpFecIni.Value.Month);
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
                PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 0.85f);

                oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                if (docPdf.IsOpen())
                {
                    docPdf.CloseDocument();
                }


                // =======================
                // DETALLE
                // =======================

                List<Con_SaldosCostosE> oListaCabecera = OListaSaldoCosto.GroupBy(y => y.idCCostos).Select(g => g.First()).OrderBy(x => x.idCCostos).ToList();

                int Columnas = oListaCabecera.Count + 3;
                float[] ArrayColumnas = new float[oListaCabecera.Count +3];
                String[] ArrayTitulos = new String[oListaCabecera.Count +3];

                TituloGeneral = "Resumen por Centro de Costos (" + desMoneda + ")";
                SubTitulo = " De " + FechasHelper.NombreMes(Convert.ToInt32(mesIni)).ToUpper() + " a " + FechasHelper.NombreMes(Convert.ToInt32(mesFin)).ToUpper() + " del " + Anio;
                
                for (int i = 0; i < oListaCabecera.Count + 3; i++)
                {
                    if (i == 0)
                    {
                        ArrayTitulos[i] = "Código";
                        ArrayColumnas[i] = 0.05f;
                    }
                    else if (i == 1)
                    {
                        ArrayTitulos[i] = "Cuenta";
                        ArrayColumnas[i] = 0.25f;
                    }
                    else if (i == 2)
                    {
                        ArrayTitulos[i] = "Total";
                        ArrayColumnas[i] = 0.10f;
                    }
                    else
                    {
                        ArrayTitulos[i] = oListaCabecera[i - 3].idCCostos +" - "+oListaCabecera[i - 3].desCosto;
                        ArrayColumnas[i] = 0.1f;
                    }
                }


                PaginaResumenCentrodeCosto ev = new PaginaResumenCentrodeCosto();
                //ev.Periodo = dtpFecIni.Value.Date;
                //ev.Anio = Anio;
                ev.MesIni = "";
                ev.MesFin = "";

                ev.Columnas = Columnas;
                ev.ArrayColumnas = ArrayColumnas;
                ev.ArrayTitulos = ArrayTitulos;
                ev.Titulo = TituloGeneral;
                ev.SubTitulo = SubTitulo;


                oPdfw.PageEvent = ev;
                //ev.OListaSaldoCosto = OListaSaldoCosto;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(ArrayColumnas);

                String codCuenta = "";

                for (int i = 0; i < OListaSaldoCosto.Count; i++)
                {

                    if (codCuenta == "")
                    {
                        codCuenta = OListaSaldoCosto[i].codCuenta;
                    }

                    if (i == 0 || codCuenta != OListaSaldoCosto[i].codCuenta)
                    {
                        codCuenta = OListaSaldoCosto[i].codCuenta;


                        cell = new PdfPCell(new Paragraph(OListaSaldoCosto[i].codCuenta, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(OListaSaldoCosto[i].descripcion, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        decimal a = OListaSaldoCosto.Where(x => x.codCuenta == codCuenta).ToList().Sum(x => x.TOT_DEBE_SOLES);
                        decimal b = OListaSaldoCosto.Where(x => x.codCuenta == codCuenta).ToList().Sum(x => x.TOT_HABER_SOLES);

                        cell = new PdfPCell(new Paragraph((a-b).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        for (int c = 0; c < oListaCabecera.Count; c++)
                        {
                            decimal e = OListaSaldoCosto.Where(x => x.codCuenta == codCuenta && x.idCCostos == oListaCabecera[c].idCCostos).ToList().Sum(x => x.TOT_DEBE_SOLES);
                            decimal f = OListaSaldoCosto.Where(x => x.codCuenta == codCuenta && x.idCCostos == oListaCabecera[c].idCCostos).ToList().Sum(x => x.TOT_HABER_SOLES);

                            cell = new PdfPCell(new Paragraph((e-f).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);
                        }

                        TablaCabDetalle.CompleteRow();
                    }
                }

                //int cntRegistro = OListaSaldoCosto.Count - 1;
                
                //decimal mont01 = 0;
                //decimal mtoHabeAper = 0;

                //listaSaldoCosto = new List<Con_SaldosCostosE>();

                //Pivot();
                //OListaSaldoCosto = (from x in OListaSaldoCosto group x.codCuenta, ).ToList();
                //RegistroDiarioE objRegistroDiario =  null;
                //List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                //                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                //                                         select x).ToList();

//                var lista = (from x in OListaSaldoCosto.GroupBy(x => x.codCuenta, y => x.idccosto ).Select(g => new  ));
                //var result2 = lista.Pivot(emp => emp.TimeStamp, emp2 => emp2.HeaderName, lst => lst.Sum(a => a.Value));



                //foreach (Con_SaldosCostosE item in OListaSaldoCosto)
                //{
                //    i++;
                //    x = i - 1;

                //    cell = new PdfPCell(new Paragraph(item.codCuenta, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                //    TablaCabDetalle.AddCell(cell);

                //    cell = new PdfPCell(new Paragraph(item.descripcion, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                //    TablaCabDetalle.AddCell(cell);

                //    if (i == 0)
                //    {
                //        mont01 = item.SAL_ANTERIOR_SOLES + item.SAL_ACTUAL_SOLES + item.TOT_DEBE_SOLES - item.TOT_HABER_SOLES;
                //    }
                //    else
                //    {
                //        if (item.codCuenta == OListaSaldoCosto[x].codCuenta)
                //        {
                //            if (item.idCCostos != OListaSaldoCosto[x].idCCostos)
                //            {

                //            }
                //        }
                //    }

                //}

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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Resumen Detalle Centro de Costo";
            NombrePestaña = "Resumen Detalle Centro de Costo";

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
                    Int32 TotColumnas = 8;

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

                    //Int32 col = 1;

                    #region Cabecera

                    #region Primera Linea Cabecera
                    using (ExcelRange Rango = oHoja.Cells[4, 1, 5, 1])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FECHA OPERACIÓN";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 2, 5, 2])
                    {
                        Rango.Merge = true;
                        Rango.Value = "NUMERO CORRELATIVO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
                    using (ExcelRange Rango = oHoja.Cells[4, 3, 5, 3])
                    {
                        Rango.Merge = true;
                        Rango.Value = "TD";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 4, 5, 4])
                    {
                        Rango.Merge = true;
                        Rango.Value = "NUMERO DOCUMENTO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 5, 5, 5])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FECHA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 6, 5, 6])
                    {
                        Rango.Merge = true;
                        Rango.Value = "GLOSA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 7, 4, 8])
                    {
                        Rango.Merge = true;
                        Rango.Value = "SALDOS Y MOVIMIENTOS";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;
                    #endregion
                    InicioLinea++;
                    #region Segunda Linea Cabecera

                    oHoja.Cells[InicioLinea, 7].Value = "DEBE";
                    oHoja.Cells[InicioLinea, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 7].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    oHoja.Cells[InicioLinea, 8].Value = "HABER";
                    oHoja.Cells[InicioLinea, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 8].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    #endregion

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;
                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;
                    //col = 1;

                    #region Carga Informacion a Excel
                    foreach (Con_SaldosCostosE item in listaSaldoCosto)
                    {

                    }
                    #endregion

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    #region Propiedades del Excel
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

        #region Eventos

        private void frmReporteResumenetalleCentrodeCosto_Load(object sender, EventArgs e)
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

        private void timer_Tick(object sender, EventArgs e)
        {
            letra += 1;
            if (letra == Marque.Length)
            {
                lblProcesando.Text = string.Empty;
                letra = 0;
            }
            else
            {
                lblProcesando.Text += Marque.Substring(letra - 1, 1);
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipoProceso = 1;
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;

                desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                Anio = dtpFecIni.Value.Year.ToString();
                mesIni = dtpFecIni.Value.Month.ToString();
                mesFin = dtpFecFin.Value.Month.ToString();

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                //this.Text = "Resumen Centro de Costo " + cboSucursales.Text.ToString();
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
            txtCuentaIni.Leave -= txtCuentaIni_Leave;

            frmBuscarCuentas frm = new frmBuscarCuentas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCuentaIni.Text = frm.Cuentas.codCuenta;
                txtDesCuentaIni.Text = frm.Cuentas.Descripcion;
            }

            txtCuentaIni.Leave += txtCuentaIni_Leave;
        }

        private void txtCuentaIni_Leave(object sender, EventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
        }

        void ObtenerDescripcionCuenta(TextBox txtcuenta, TextBox txtdescripcion)
        {
            if (txtcuenta.Text.Trim() != "")
                txtdescripcion.Text = AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtcuenta.Text.ToString());
            else
                txtdescripcion.Text = "";
        }

        private void txtCuentaFin_Leave(object sender, EventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
        }

        private void btnBusquedaCuentaFin_Click(object sender, EventArgs e)
        {
            txtCuentaFin.Leave -= txtCuentaFin_Leave;

            frmBuscarCuentas frm = new frmBuscarCuentas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCuentaFin.Text = frm.Cuentas.codCuenta;
                txtDesCuentaFin.Text = frm.Cuentas.Descripcion;
            }

            txtCuentaFin.Leave += txtCuentaFin_Leave;
        } 

        #endregion

    }
}

internal class PaginaResumenCentrodeCosto : PdfPageEventHelper
{
    public String MesIni { get; set; }
    public String MesFin { get; set; }
    public int Columnas { get; set; }
    public float[] ArrayColumnas { get; set; }
    public String[] ArrayTitulos { get; set; }
    public String Titulo { get; set; }
    public String SubTitulo { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.9f, 0.12f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell(new Paragraph("               "+Titulo, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha: " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("               " + SubTitulo, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
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

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC        " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RAZON SOCIAL   " + VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada 

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(ArrayColumnas);

        

        for (int i = 0; i < ArrayTitulos.Length; i++)
        {
            cell = new PdfPCell(new Paragraph(ArrayTitulos[i], FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);
        }

        TablaCabDetalle.CompleteRow();

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }
}
