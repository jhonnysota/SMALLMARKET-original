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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ClienteWinForm;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEstadisticoCuenta : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteEstadisticoCuenta()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
            Nivel();
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<SaldosMensualesE> oSaldos = null;
        List<SaldosMensualesE> oListaCabecera = null;
        List<SaldosMensualesE> oListaAuxiliar = null;

        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        string Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String Marque = String.Empty;
        string tipo = "estadistico";
        string accion = "ninguna";

        #endregion

        #region Procedimientos de Usuario

        void Nivel()
        {
            try
            {
                nudNivel.Value = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
                nudNivel.Minimum = 1;
                //nudNivel.Maximum = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            /////MES inicio////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboInicio.DataSource = oDt;
            cboInicio.ValueMember = "MesId";
            cboInicio.DisplayMember = "MesDes";
            cboInicio.SelectedValue = "00";


            /////MES Final////
            DataTable oET = FechasHelper.CargarMesesContable("MA");
            DataRow Fila2 = oET.NewRow();
            Fila2["MesId"] = "0";
            Fila2["MesDes"] = Variables.Todos;
            oET.Rows.Add(Fila2);

            oET.DefaultView.Sort = "MesId";
            cboFin.DataSource = oET;
            cboFin.ValueMember = "MesId";
            cboFin.DisplayMember = "MesDes";
            cboFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;


            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;


            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";

            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioInicial, AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa), "idComprobante", "desComprobanteComp");
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document((tipo == "estadistico" && oListaCabecera.Count <7  ? PageSize.A4 : PageSize.A4.Rotate()), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\SaldosCuentaAuxiliar ";
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

                int Columnas = 5;
                float[] ArrayColumnas = new float[] { 0.1f, 0.05f, 0.05f, 0.05f, 0.05f };
                String[] ArrayTitulos = new String[] { "Periodo", "Total Debe", "Total Haber", "Saldo Mensual", "Saldo Acumulado"};

               

                String mesIni = Convert.ToString(cboInicio.SelectedValue);

                String mesFin = Convert.ToString(cboFin.SelectedValue);


                String Titulo = "Saldos Cuenta Auxiliar  (" + ((MonedasE) cboMoneda.SelectedItem).desAbreviatura + ")";
                SubTitulo = " De " + FechasHelper.NombreMes(Convert.ToInt32(mesIni)).ToUpper() + " a " + FechasHelper.NombreMes(Convert.ToInt32(mesFin)).ToUpper() + " del " + Anio;
                
                

                Titulo = "Saldos Cuenta Auxiliar (" + ((MonedasE)cboMoneda.SelectedItem).desAbreviatura + ")";

                

                Columnas = oListaCabecera.Count + 3;

                float[] ArrayColumnas_ = new float[oListaCabecera.Count + 3];
                String[] ArrayTitulos_ = new String[oListaCabecera.Count + 3];

                for (int i = 0; i < oListaCabecera.Count + 3; i++)
                {
                    if (i == 0)
                    {
                        ArrayTitulos_[i] = "Código";
                        ArrayColumnas_[i] = 0.08f;
                    }
                    else if (i == 1)
                    {
                        ArrayTitulos_[i] = "Razon Social";
                        ArrayColumnas_[i] = 0.25f;
                    }
                    else if (i == 2)
                    {
                        ArrayTitulos_[i] = "Total";
                        ArrayColumnas_[i] = 0.1f;
                    }
                    else
                    {
                        ArrayTitulos_[i] = FechasHelper.NombreMes(Convert.ToInt32(oListaCabecera[i - 3].MesPeriodo)).ToUpper();
                        ArrayColumnas_[i] = 0.08f;

                    }
                }


                ArrayColumnas = ArrayColumnas_;
                ArrayTitulos = ArrayTitulos_;
                

                PaginaInicioSaldosEstadistico ev = new PaginaInicioSaldosEstadistico();
                //Parametros Que Pasaras Al PDF
                ev.Anio = Convert.ToString(cboAnio.SelectedValue);
                ev.MesInicio = Convert.ToInt32(cboInicio.SelectedValue);
                ev.MesFin = Convert.ToInt32(cboFin.SelectedValue);
                ev.Mon = cboMoneda.SelectedValue.ToString();

                ev.Columnas = Columnas;
                ev.ArrayColumnas = ArrayColumnas;
                ev.ArrayTitulos = ArrayTitulos;
                ev.Titulo = Titulo;
                ev.SubTitulo = SubTitulo;
                ev.tipo = tipo;

                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(ArrayColumnas);
                

                    Int32 Monedas = Convert.ToInt32(cboMoneda.SelectedValue);

                for (int i = 0; i < oListaAuxiliar.Count; i++)
                {
                    
                    cell = new PdfPCell(new Paragraph(oListaAuxiliar[i].idPersona.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(oListaAuxiliar[i].RazonSocial, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    Decimal EntidadSum = new Decimal();

                    EntidadSum = (from x in oSaldos
                                  where (x.idPersona == oListaAuxiliar[i].idPersona)
                                  select x).Sum(x => x.Monto);
                    //select x).SingleOrDefault();


                    if (Monedas == 01)
                    {
                        cell = new PdfPCell(new Paragraph(EntidadSum.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = new PdfPCell(new Paragraph(EntidadSum.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                    }

                    for (int c = 0; c < oListaCabecera.Count; c++)
                        {
                            Decimal Valor;
                            int ValorMes = c + 1;
                            String Mes = String.Format("{0:00}",ValorMes);
                            SaldosMensualesE Entidad = new SaldosMensualesE(); 

                            Entidad = (from x in oSaldos
                                      where (x.idPersona == oListaAuxiliar[i].idPersona) && (x.MesPeriodo == Mes)
                                     select x).SingleOrDefault();

                            if (Entidad == null)
                            {
                            Valor = 0;
                            }
                            else
                            {                              
                            Valor = Entidad.Monto;
                            }

                            if (Monedas == 01)
                            {   
                                cell = new PdfPCell(new Paragraph(Valor.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                            }
                            else
                            {                        
                                cell = new PdfPCell(new Paragraph(Valor.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                            }
                        }

                        TablaCabDetalle.CompleteRow();
                }                

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
            if (border < 0)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 5f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", 5f, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK))) { Border = border, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        
        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (accion == "exportar")
            {
                 ExportarExcelSaldoMensual(RutaGeneral);
            }
            else
            {

                Int32 idLocal = Convert.ToInt32(cboSucursal.SelectedValue);
                String Anio = Convert.ToString(cboAnio.SelectedValue);
                String MesInicio = Convert.ToString(cboInicio.SelectedValue);
                String MesFinal = Convert.ToString(cboFin.SelectedValue);
                String Version = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                String InicioCuenta = txtInicioCuenta.Text;
                String FinCuenta = txtFinCuenta.Text;
                Int32 NivelCuenta = Convert.ToInt32(nudNivel.Value);
                String idComprobanteIni = cboDiarioInicial.SelectedValue.ToString();
                String idMoneda = cboMoneda.SelectedValue.ToString();
                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo los saldos...";

                if (tipo == "estadistico")
                {
                    oSaldos = AgenteContabilidad.Proxy.SaldosCuentaAuxiliar(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Version, idLocal, Anio, InicioCuenta, FinCuenta, MesInicio, MesFinal, idComprobanteIni, NivelCuenta, idMoneda);

                    //lista cabecera
                    oListaCabecera = oSaldos.GroupBy(x => x.MesPeriodo).Select(g => g.First()).OrderBy(x => x.MesPeriodo).ToList();
                    oListaAuxiliar = oSaldos.GroupBy(x => x.idPersona).Select(g => g.First()).OrderBy(x => x.RazonSocial).ToList();
                }


                lblProcesando.Text = "Armando el Reporte...";

                //Generando el PDF
                ConvertirApdf();
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

            //Mostrando el reporte en un web browser
            if (accion == "exportar")
            {
                Global.MensajeComunicacion("Saldos Auxiliar Exportado...");
            }
            else
            {
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }
           
        }

        #endregion

        #region Eventos De Procedimiento

        private void frmReporteSaldos_Load(object sender, EventArgs e)
        {
            cboAnio.SelectedValue = Convert.ToInt32(Anio);
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "estadistico";

                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                accion = "ninguna";

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void frmReporteSaldos_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        #endregion

        #region Eventos Exportar Excel

        public override void Exportar()
        {
            try
            {
                if (oSaldos == null || oSaldos.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }


                String NombreLocal = cboSucursal.Text;
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + cboSucursal.Text;

                String Mes = cboInicio.Text;
                String MesFin = cboFin.Text;
                RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", " Saldos Cuenta Auxiliar " + NombreLocal + "-" + "Desde" + Mes + "Hasta" + MesFin, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    accion = "exportar";
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

        #region Excel Estadistico a Nivel de Saldos

        void ExportarExcelSaldoMensual(String Ruta)
        {

            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String nombreMes = cboInicio.Text;
            String MesFin = cboFin.Text;

            TituloGeneral = " Saldos Cuenta Auxiliar " + " Al Año " + Anio + " Del Mes " + nombreMes + "Hasta el Mes" + MesFin;
            NombrePestaña = " Saldos Cuenta Auxiliar";

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

                    TotColumnas = 4;

                    oHoja.Cells[InicioLinea, 1].Value = " CUENTA ";
                    oHoja.Cells[InicioLinea, 2].Value = " RAZON SOCIAL ";
                    oHoja.Cells[InicioLinea, 3].Value = " TOTAL ";

                    for (int i = 1; i <= 3; i++)
                     {
                     oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                     oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                     oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                     oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                     }

                    Int32 LineaDeMes = 3;                  
                          
                    for (int i = 0; i < oListaCabecera.Count; i++)
                     {
                      oHoja.Cells[InicioLinea, LineaDeMes + 1].Value = FechasHelper.NombreMes(Convert.ToInt32(oListaCabecera[i].MesPeriodo.ToUpper()));

                      using (ExcelRange Rango = oHoja.Cells[InicioLinea, LineaDeMes + 1, InicioLinea, LineaDeMes + 1])
                       {
                        //Rango.Value = Global.NombreMes(Convert.ToInt32(oListaCabecera[i].MesPeriodo.ToUpper()));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        LineaDeMes = LineaDeMes + 1;
                       }

                     }

                    InicioLinea++;

                    #endregion

                    #region Detalle
                    
                    Int32 Moneda = Convert.ToInt32(cboMoneda.SelectedValue);

                    for (int i = 0; i < oListaAuxiliar.Count; i++)
                    {
                       
                       oHoja.Cells[InicioLinea, 1].Value = oListaAuxiliar[i].idPersona;
                       oHoja.Cells[InicioLinea, 2].Value = oListaAuxiliar[i].RazonSocial;


                        Decimal EntidadSum = new Decimal();

                        EntidadSum = (from x in oSaldos
                                      where (x.idPersona == oListaAuxiliar[i].idPersona)
                                      select x).Sum(x => x.Monto);


                        if (Moneda == 01)
                        {
                            oHoja.Cells[InicioLinea, 3].Value = EntidadSum;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 3].Value = EntidadSum;
                        }

                        for (int c = 0; c < oListaCabecera.Count; c++)
                        {
                            Decimal Valor;
                            int ValorMes = c + 1;
                            String Mes = String.Format("{0:00}", ValorMes);
                            SaldosMensualesE Entidad = new SaldosMensualesE();

                            Entidad = (from x in oSaldos
                                       where (x.idPersona == oListaAuxiliar[i].idPersona) && (x.MesPeriodo == Mes)
                                       select x).SingleOrDefault();

                            if (Entidad == null)
                            {
                                Valor = 0;
                            }
                            else
                            {
                                Valor = Entidad.Monto;
                            }


                            if (Moneda == 01)
                            {
                                oHoja.Cells[InicioLinea, c + TotColumnas].Value = Valor;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, c + TotColumnas].Value = Valor;
                            }

                            oHoja.Cells[InicioLinea, 3, InicioLinea, c + TotColumnas].Style.Numberformat.Format = "###,###,##0.00";

                        }

                       InicioLinea++;

                    }

                    #endregion

                    #region Pie de Reporte

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas + oListaCabecera.Count].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

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

                    #endregion

                    #region Propiedades de la Hoja

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

                    #endregion 

                }
            }
        }

        #endregion

        #endregion

        private void txtInicioCuenta_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtInicioCuenta, txtDesCuentaIni);
        }

        private void txtFinCuenta_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtFinCuenta, txtDesCuentaFin);
        }

        void ObtenerDescripcionCuenta(TextBox txtcuenta, TextBox txtdescripcion)
        {
            if (txtcuenta.Text.Trim() != "")
                txtdescripcion.Text = AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtcuenta.Text.ToString());
            else
                txtdescripcion.Text = "";
        }

        private void btnBusquedaCuentaIni_Click(object sender, EventArgs e)
        {
            frmBuscarCuentas frm = new frmBuscarCuentas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtInicioCuenta.Text = frm.Cuentas.codCuenta;
                txtDesCuentaIni.Text = frm.Cuentas.desCuenta;
            }
        }

        private void wbNavegadorFin_Click(object sender, EventArgs e)
        {
            frmBuscarCuentas frm = new frmBuscarCuentas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtFinCuenta.Text = frm.Cuentas.codCuenta;
                txtDesCuentaFin.Text = frm.Cuentas.desCuenta;
            }
        }

    }
}




#region Inicio Pdf

class PaginaInicioSaldosEstadistico : PdfPageEventHelper
{
    public DateTime Per { get; set; }
    public String Mon { get; set; }
    public String Anio { get; set; }
    public Int32 MesInicio { get; set; }
    public Int32 MesFin { get; set; }

    public String tipo { get; set; }
    public int Columnas { get; set; }
    public float[] ArrayColumnas { get; set; }
    public String[] ArrayTitulos { get; set; }
    public String Titulo { get; set; }
    public String SubTitulo { get; set; }


    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        //Chunk ch = new Chunk("This is my Stack Overflow Header on page " + writer.PageNumber);
        //document.Add(ch);

        //String TituloGeneral = String.Empty;
        //String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

        string nombre_mes = (Convert.ToInt32(MesInicio) == 0 ? "APERTURA" : (Convert.ToInt32(MesInicio) == 13 ? "CIERRE" : FechasHelper.NombreMes(Convert.ToInt32(MesInicio))));
        string nombres_mes_fin = (Convert.ToInt32(MesFin) == 0 ? "APERTURA" : (Convert.ToInt32(MesFin) == 13 ? "CIERRE" : FechasHelper.NombreMes(Convert.ToInt32(MesFin))));

        //TituloGeneral = "Saldos Mensuales " + " AL AÑO " + Anio.ToUpper() + " DEL MES " + nombre_mes.ToUpper() + " AL " + nombres_mes_fin.ToUpper() ;

        //if (Mon == Variables.MonedaSoles)
        //{
        //    SubTitulo = "EXPRESADO EN SOLES";
        //}
        //else
        //{
        //    SubTitulo = "EXPRESADO EN DOLARES";
        //}

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.9f, 0.12f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell(new Paragraph("                  " + Titulo, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha: " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("                    " + SubTitulo, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
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

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 6.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 6.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
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

        PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(ArrayColumnas);
        #region Primera Linea


        for (int i = 0; i < ArrayTitulos.Length; i++)
        {
            cell = new PdfPCell(new Paragraph(ArrayTitulos[i], FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);
        }

        TablaCabDetalle.CompleteRow();     
                       
        
        #endregion        

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }

}

#endregion
