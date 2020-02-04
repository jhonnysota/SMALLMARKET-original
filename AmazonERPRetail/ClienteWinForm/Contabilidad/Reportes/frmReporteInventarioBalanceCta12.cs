using ClienteWinForm.Busquedas;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteInventarioBalanceCta12 : FrmMantenimientoBase
    {
        #region Constructora

        public frmReporteInventarioBalanceCta12()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #endregion

        #region Variables
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<conCtaCteE> oCtaCte = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string sParametro = string.Empty;
        String Marque = String.Empty;
        //Int32 idpersona = 0;

        Int32 idEmpresa;
        String PlanCuenta;
        //String CuentaIni;
        //String CuentaFin;
        String MesIni;
        //String MesFin;
        //String TipoReporte;
        Int32 Tipo;
        String Anio;
        String Mes;
        String TipoAccion = String.Empty;
        String RutaExcel = String.Empty;
        String NombreAchivo = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
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
            cboFin.SelectedValue = "12";

            // Anio
            Int32 anioFin = Convert.ToInt32(VariablesLocales.FechaHoy.Year);
            Int32 anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";
            cboAño.SelectedValue = anioFin;

            //Tipo Reporte
            List<ParTabla> oListaReporte = new List<ParTabla>();
            oListaReporte.Add(new ParTabla() { IdParTabla = 1, Nombre = "3.3  LIBRO DE INVENTARIO Y BALANCE 12,13" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 2, Nombre = "3.4  LIBRO DE INVENTARIO Y BALANCE 14" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 3, Nombre = "3.5  LIBRO DE INVENTARIO Y BALANCE 16,17" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 4, Nombre = "3.12 LIBRO DE INVENTARIO Y BALANCE 42,43" });
            oListaReporte.Add(new ParTabla() { IdParTabla = 5, Nombre = "3.13 LIBRO DE INVENTARIO Y BALANCE 47" });

            ComboHelper.RellenarCombos<ParTabla>(cboLibro, oListaReporte);

        }

        void ExportarExcel(String Ruta)
        {
            try
            {
                String TituloGeneral = String.Empty;
                String NombrePestaña = String.Empty;

                TituloGeneral = NombreAchivo;
                NombrePestaña = "Inventario Balance de la Cuenta 12";

                if (File.Exists(Ruta)) File.Delete(Ruta);
                FileInfo newFile = new FileInfo(Ruta);

                using (ExcelPackage oExcel = new ExcelPackage(newFile))
                {
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                    if (oHoja != null)
                    {
                        Int32 InicioLinea = 1;
                        Int32 TotColumnas = 9;

                        #region Cabecera

                        #region Segunda Linea Cabecera

                            oHoja.Cells[InicioLinea, 1].Value = "Periodo";
                            oHoja.Cells[InicioLinea, 2].Value = "Codigo Operacion";
                            oHoja.Cells[InicioLinea, 3].Value = "Correlativo del Asiento";
                            oHoja.Cells[InicioLinea, 4].Value = "Tipo De Documento";
                            oHoja.Cells[InicioLinea, 5].Value = "Numero Documento";
                            oHoja.Cells[InicioLinea, 6].Value = "Razon Social";
                            oHoja.Cells[InicioLinea, 7].Value = "Fecha";
                            oHoja.Cells[InicioLinea, 8].Value = "Monto";
                            oHoja.Cells[InicioLinea, 9].Value = "ESTADO";


                        for (Int32 i = 1; i <= 9 ; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        #endregion

                        // Auto Filtro
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                        #endregion Cabecera

                        #region Detalle

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;

                        foreach (conCtaCteE item in oCtaCte)
                        {
                                oHoja.Cells[InicioLinea, 1].Value = item.AnioPeriodo + item.MesPeriodo;
                                oHoja.Cells[InicioLinea, 2].Value = item.numVoucher;
                                oHoja.Cells[InicioLinea, 3].Value = "M" + item.Item;
                                oHoja.Cells[InicioLinea, 4].Value = item.TipoDoc;
                                oHoja.Cells[InicioLinea, 5].Value = item.Ruc;
                                oHoja.Cells[InicioLinea, 6].Value = item.RazonSocial;
                                oHoja.Cells[InicioLinea, 7].Value = item.fecDocumento.Value.ToString("d");

                                if (item.idMoneda == "01")
                                {
                                oHoja.Cells[InicioLinea, 8].Value = item.SaldoSoles;
                            }

                                if (item.idMoneda == "02")
                                {
                                oHoja.Cells[InicioLinea, 8].Value = item.SaldoDolares;
                            }

                            oHoja.Cells[InicioLinea, 9].Value = item.Estado;

                                // FORMAT 

                                oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                                oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;

                            InicioLinea++;
                        }

                        #endregion

                        //Ajustando el ancho de las columnas automaticamente
                        oHoja.Cells.AutoFitColumns();

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
                        oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                        oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

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
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio si no existe...
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

                // Para la creacion del archivo pdf
                Guid oGuid = Guid.NewGuid();
                RutaGeneral += oGuid.ToString() + Extension;

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

                PaginaCabeceraReporteCtaCtePendientes12 ev = new PaginaCabeceraReporteCtaCtePendientes12();

                ev.ano = Anio;

                if (Tipo == 1)
                {
                    ev.TituloGeneral = "3.3  LIBRO DE INVENTARIO Y BALANCE 12,13";
                }
                else
                if (Tipo == 2)
                {
                    ev.TituloGeneral = "3.4  LIBRO DE INVENTARIO Y BALANCE 14";
                }
                else
                if (Tipo == 3)
                {
                    ev.TituloGeneral = "3.5  LIBRO DE INVENTARIO Y BALANCE 16,17";
                }
                else
                if (Tipo == 4)
                {
                    ev.TituloGeneral = "3.12 LIBRO DE INVENTARIO Y BALANCE 42,43";
                }
                if (Tipo == 5)
                {
                    ev.TituloGeneral = "3.13 LIBRO DE INVENTARIO Y BALANCE 47";
                }

                

                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(9);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.2f, 0.2f, 0.2f, 0.3f, 0.3f, 0.6f, 0.2f, 0.2f, 0.1f });

                String codcuenta = String.Empty;
                String descuenta = String.Empty;

                String ruc = String.Empty;
                String rucTitulo = String.Empty;
                String idDocSerDocNum = String.Empty;


                Decimal TotalCue_SaldoDolares = 0;
                Decimal TotalCue_SaldoSoles = 0;

                String Mon = String.Empty;
                foreach (conCtaCteE item in oCtaCte)
                {
                    if (item.AnioPeriodo != null && item.MesPeriodo !=null)
                    {
                        cell = PdfPCell(item.AnioPeriodo + item.MesPeriodo, 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = PdfPCell_("", 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);

                    }
             
                    if (item.numVoucher != null)
                    {
                        cell = PdfPCell_(item.numVoucher, 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = PdfPCell_("", 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }

                    if (item.Item != null)
                    {
                        cell = PdfPCell_(item.Item, 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = PdfPCell_("", 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }

                    if (item.TipoDoc != null)
                    {
                        cell = PdfPCell_(item.TipoDoc, 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = PdfPCell_("", 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }
     

                    if (item.Ruc != null)
                    {
                        cell = PdfPCell_(item.Ruc, 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = PdfPCell_("", 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }

                    if (item.RazonSocial != null)
                    {
                        cell = PdfPCell_(item.RazonSocial, 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = PdfPCell_("", 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }



                    if (item.fecDocumento != null)
                    {
                        cell = PdfPCell_(item.fecDocumento.Value.ToString("d"), 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }
                    else
                    {
                        cell = PdfPCell_("", 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);
                    }

                        if (item.idMoneda == "01")
                        {

                            cell = PdfPCell_(item.SaldoSoles.ToString("N2"), 6f, "rigth", "bold");
                            TablaCabDetalle.AddCell(cell);
                        }

                        if (item.idMoneda == "02")
                        {
                            cell = PdfPCell_(item.SaldoDolares.ToString("N2"), 6f, "rigth", "bold");
                            TablaCabDetalle.AddCell(cell);
                        }

                        cell = PdfPCell_(item.Estado.ToString(), 6f, "center", "bold");
                        TablaCabDetalle.AddCell(cell);


                        TablaCabDetalle.CompleteRow();

                    if (item.idMoneda == "02")
                    {
                        TotalCue_SaldoDolares += item.SaldoDolares;
                    }
                    if (item.idMoneda == "01")
                    {
                        TotalCue_SaldoSoles += item.SaldoSoles;
                    }

                    Mon = item.idMoneda;

                }

                // TOTALES RESUMEN
                cell = PdfPCell(" ", 6f, "rigth", "bold");
                cell.Colspan = 9;
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = PdfPCell(" TOTAL GENERAL : ", 6f, "rigth", "bold");
                cell.Colspan = 7;
                TablaCabDetalle.AddCell(cell);



                if (Mon == "02")
                {

                    cell = PdfPCell_(TotalCue_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                    TablaCabDetalle.AddCell(cell);
                }
                if (Mon == "01")
                {

                    cell = PdfPCell_(TotalCue_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                    TablaCabDetalle.AddCell(cell);
                }


                cell = PdfPCell_(" ", 6f, "rigth", "bold");
                TablaCabDetalle.AddCell(cell);

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

        void BloquearBotones(Boolean estado)
        {
            btBuscar.Enabled = estado;
            panel4.Enabled = estado;
        }

        PdfPCell PdfPCell(String texto, float tamano_letra, String align, String negrita)
        {
            return new PdfPCell(new Paragraph(texto, FontFactory.GetFont("Arial", tamano_letra, (negrita == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)))) { Border = 0, HorizontalAlignment = (align == "center" ? Element.ALIGN_CENTER : (align == "left" ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        PdfPCell PdfPCell_(String texto, float tamano_letra, String align, String negrita)
        {
            return new PdfPCell(new Paragraph(texto, FontFactory.GetFont("Arial", tamano_letra, (negrita == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)))) { Border = 0 , HorizontalAlignment = (align == "center" ? Element.ALIGN_CENTER : (align == "left" ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT)), VerticalAlignment = Element.ALIGN_MIDDLE};
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oCtaCte == null || oCtaCte.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                NombreAchivo = "Inventario Balance Cuenta 12 " + cboAño.Text + " de " + cboInicio.Text + " a " + cboFin.Text;

                if (cboInicio.Text == cboFin.Text)
                    NombreAchivo = "Inventario Balance Cuenta 12 " + cboAño.Text + " de " + cboInicio.Text;

                RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", NombreAchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaExcel))
                {
                    TipoAccion = "exportar";

                    pbProgress.Visible = true;
                    BloquearBotones(false);

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
                oCtaCte = AgenteContabilidad.Proxy.ReporteInventarioBalanceCtaCte(idEmpresa, Anio, Mes, Tipo);

                if (TipoAccion == "exportar")
                {
                    ExportarExcel(RutaExcel);
                }
                else
                {
                    ConvertirApdf();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            BloquearBotones(true);

            if (TipoAccion == "buscar")
            {
                if (oCtaCte == null || oCtaCte.Count == 0)
                {
                    RutaGeneral = String.Empty;
                    Global.MensajeFault("No hay Datos.");
                }

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }

            if (TipoAccion == "exportar")
            {
                Global.MensajeComunicacion("Se genero el archivo");
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        private void frmReporteInventarioBalanceCta12_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            cboInicio.SelectedIndex = 1;
            cboFin.SelectedIndex = 13;
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
               
                TipoAccion = "buscar";

                pbProgress.Visible = true;
                BloquearBotones(false);

                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                PlanCuenta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                Anio = cboAño.SelectedValue.ToString();
                MesIni = cboInicio.SelectedValue.ToString();
                Mes = cboFin.SelectedValue.ToString();
                Tipo = Convert.ToInt32(cboLibro.SelectedValue.ToString());

                //TipoReporte =  "resumen";

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btPle_Click(object sender, EventArgs e)
        {
            #region Variables

            String nomLibro = String.Empty;
            String MesReal = cboFin.SelectedValue.ToString();
            String AnioReal = cboAño.SelectedValue.ToString();
            Int32 DiaReal = FechasHelper.ObtenerUltimoDia(VariablesLocales.FechaHoy).Day;
            String RutaArchivoTexto = String.Empty;
            String Dato = "1";
            String nLibro = "";

            #endregion Variables

            try
            {
                #region Validaciones

                if (oCtaCte == null || oCtaCte.Count == Variables.Cero)
                {
                    Dato = "0";
                }

                if (Tipo == 1)
                {
                    nLibro = "030300";
                }
                else
             if (Tipo == 2)
                {
                    nLibro = "030400";
                }
                else
             if (Tipo == 3)
                {
                    nLibro = "030500";
                }
                else
             if (Tipo == 4)
                {
                    nLibro = "031200";
                }
                if (Tipo == 5)
                {
                    nLibro = "031300";
                }

                #endregion

                if (Global.MensajeConfirmacion("Desea generar el Archivo para el PLE.") == DialogResult.No)
                {
                    return;
                }

                nomLibro = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + AnioReal + "12" +"31" + nLibro + "011" + Dato +"11";
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

                        #endregion Variables

                        foreach (conCtaCteE item in oCtaCte)
                        {
                            #region Insertar Linea

                            Linea.Append(item.AnioPeriodo + item.MesPeriodo).Append("|").Append(item.numVoucher).Append("|").Append(item.Item).Append("|");
                            Linea.Append(item.TipoDoc).Append("|");
                            if (item.Ruc != null)
                            {
                                Linea.Append(item.Ruc).Append("|");
                            }
                            else
                            {
                                Linea.Append("").Append("|");
                            }

                           String fecDocumento = item.fecDocumento.Value.ToString("dd/MM/yyyy");

                            if (Tipo == 4)
                            {

                               Linea.Append(fecDocumento).Append("|");

                               if (item.Ruc != null)
                                {
                                    Linea.Append(item.RazonSocial).Append("|");
                                }
                                else
                                {
                                    Linea.Append("").Append("|");
                                }

                            }
                            else
                            {
                                if (item.Ruc != null)
                                {
                                    Linea.Append(item.RazonSocial).Append("|");
                                }
                                else
                                {
                                    Linea.Append("").Append("|");
                                }

                                Linea.Append(fecDocumento).Append("|");

                            }

                            if (item.idMoneda == "01")
                            {
                                Linea.Append(item.SaldoSoles).Append("|");
                            }

                            if (item.idMoneda == "02")
                            {
                                Linea.Append(item.SaldoDolares).Append("|");
                            }
                            Linea.Append(item.Estado).Append("|");

                            oSw.WriteLine(Linea.ToString());
                            Linea.Clear();

                            #endregion Insertar Linea
                        }
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

    class PaginaCabeceraReporteCtaCtePendientes12 : PdfPageEventHelper
    {
        public float[] tamano_cabecera { get; set; }
        public Int32 TotalColumnas { get; set; }
        public Int32 WidthTabla { get; set; }
        public String Tipo_Reporte { get; set; }

        public String mes_ini { get; set; }
        public String mes_fin { get; set; }
        public String ano { get; set; }
        public String TituloGeneral { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            String SubTitulo = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            PdfPCell cell = null;

            String nombre_mes = "Apertura";
            String nombres_mes_fin = "Diciembre";

            SubTitulo = "Del Mes de " + nombre_mes + " a " + nombres_mes_fin.ToUpper() + " del " + ano;

            // Cabecera del Reporte
            PdfPTable table = new PdfPTable(2);

            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 0.9f, 0.15f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            #region Cabacera Pagina

            cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("Fecha : " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);

            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("Hora :   " + HoraActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("Pag. :   " + writer.PageNumber, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD))) { Border = 0 };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada 

            #endregion

            #region Titulos Principales

            cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 8))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
            cell.Colspan = 2;
            table.AddCell(cell);

            table.CompleteRow(); //Fila completada 

            #endregion

            document.Add(table); //Añadiendo la tabla al documento PDF

            #region Cabecera del Detalle

            // TABLA CABECERA
            PdfPTable TablaCabDetalle = new PdfPTable(9);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.2f, 0.2f, 0.2f, 0.3f, 0.3f, 0.6f, 0.2f, 0.2f, 0.1f });

            #region Primera Linea


            cell = new PdfPCell(new Paragraph("Periodo", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Codigo Operacion", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Correlativo del Asiento", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph( "Tipo de Documento" , FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph( "Numero Documento", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Razon Social", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Fecha", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Monto", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Estado", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
            TablaCabDetalle.AddCell(cell);

            TablaCabDetalle.CompleteRow();

            #endregion

            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

            #endregion

        }

    }

}
