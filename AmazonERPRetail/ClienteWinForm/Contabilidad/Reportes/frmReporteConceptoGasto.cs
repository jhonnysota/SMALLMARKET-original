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
    public partial class frmReporteConceptoGasto : FrmMantenimientoBase
    {

        #region Constructor

        public frmReporteConceptoGasto()
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

        List<VoucherItemE> oVoucherItem = null;
        List<ConceptoGastoE> oConceptoGasto = null;
        List<ConceptoGastoE> oConceptoGastoCabecera = new List<ConceptoGastoE>();

        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String Marque = String.Empty;
        string tipo = "buscar";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////MESINICIO////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboInicio.DataSource = oDt;
            cboInicio.ValueMember = "MesId";
            cboInicio.DisplayMember = "MesDes";
            cboInicio.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////MESFINAL////
            DataTable oMC = FechasHelper.CargarMesesContable("MA");
            DataRow File = oMC.NewRow();
            File["MesId"] = "0";
            File["MesDes"] = Variables.Todos;
            oMC.Rows.Add(File);

            oMC.DefaultView.Sort = "MesId";
            cboFin.DataSource = oMC;
            cboFin.ValueMember = "MesId";
            cboFin.DisplayMember = "MesDes";
            cboFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 5;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMon.DataSource = (from x in ListaMoneda
                                 where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                 orderby x.idMoneda
                                 select x).ToList();
            cboMon.ValueMember = "idMoneda";
            cboMon.DisplayMember = "desMoneda";
        }

        #endregion

        #region Procedimientos de Usuario

        //void ConvertirApdf()
        //{
        //    oConceptoGastoCabecera = oConceptoGasto.GroupBy(x => x.mesPeriodo).Select(x => x.First()).OrderBy(x => x.mesPeriodo).ToList();




        //    Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
        //    String NombreReporte = @"\ConceptoGasto";
        //    String Extension = ".pdf";
        //    RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

        //    //Creando el directorio si existe...
        //    if (!Directory.Exists(RutaGeneral))
        //    {
        //        Directory.CreateDirectory(RutaGeneral);
        //    }

        //    docPdf.AddCreationDate();
        //    docPdf.AddAuthor("AMAZONTIC SAC");
        //    docPdf.AddCreator("AMAZONTIC SAC");

        //    if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
        //    {
        //        String TituloGeneral = String.Empty;
        //        String SubTitulo = String.Empty;
        //        PdfPCell cell = null;

        //        //Para la creacion del archivo pdf
        //        RutaGeneral += NombreReporte + Extension;

        //        if (File.Exists(RutaGeneral))
        //        {
        //            File.Delete(RutaGeneral);
        //        }

        //        FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        //        PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
        //        PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

        //        oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
        //        oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
        //        oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

        //        if (docPdf.IsOpen())
        //        {
        //            docPdf.CloseDocument();
        //        }

        //        PaginaInicioConceptoGasto ev = new PaginaInicioConceptoGasto();
        //        ev.Anio = Convert.ToString(cboAño.SelectedValue);
        //        ev.Mes = Convert.ToInt32(cboInicio.SelectedValue);
        //        ev.MesFin = Convert.ToInt32(cboFin.SelectedValue);
        //        ev.Moneda = Convert.ToString(cboMon.SelectedValue);
        //        ev.oConceptoGastoCabecera = oConceptoGastoCabecera;

        //        oPdfw.PageEvent = ev;

        //        docPdf.Open();

        //        #region Detalle

        //        int TotalColumnas = 2 + this.oConceptoGastoCabecera.Count + 1;


        //        float[] array = new float[TotalColumnas];

        //        for (int i = 0; i < TotalColumnas; i++)
        //        {
        //            if (i == 0)
        //                array[i] = 0.025f;
        //            if (i == 1)
        //                array[i] = 0.035f;
        //            if (i >= 2 && i < TotalColumnas - 1)
        //                array[i] = 0.02f;
        //            if (i == TotalColumnas - 1)
        //                array[i] = 0.015f;
        //        }


        //        PdfPTable TablaCabDetalle = new PdfPTable(TotalColumnas);
        //        TablaCabDetalle.WidthPercentage = 100;
        //        TablaCabDetalle.SetWidths(array);


        //        Int32 Contador = 0;
        //        String Proyecto = "";


        //        //Decimal A = 0;

        //        //ORDENAR POR COLUMNA DE AGRUPAR
        //        oConceptoGasto = oConceptoGasto.OrderBy(x => x.nombre).ToList();

        //        foreach (ConceptoGastoE item in oConceptoGasto)
        //        {

        //            Decimal SubTotalHor = 0;
        //            string TituloGrupo = "";
                    
        //            if (Contador == 0)
        //            {
        //                Proyecto = item.nombre;
        //            }

        //            if (Proyecto != item.nombre)
        //            {
        //                Proyecto = item.nombre;
        //                TituloGrupo = item.nombre;

        //                // CELDA PROYECTO
        //                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        //                TablaCabDetalle.AddCell(cell);
        //                // CELDA PROYECTO
        //                cell = new PdfPCell(new Paragraph("SUB TOTALES", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        //                TablaCabDetalle.AddCell(cell);
        //                foreach (ConceptoGastoE itemCabecera in oConceptoGastoCabecera)
        //                {



        //                    cell = new PdfPCell(new Paragraph(itemCabecera.TotalImporte.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
        //                    TablaCabDetalle.AddCell(cell);
        //                    SubTotalHor += itemCabecera.TotalImporte;
        //                    itemCabecera.TotalImporte = 0;




        //                }
        //                cell = new PdfPCell(new Paragraph(SubTotalHor.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
        //                TablaCabDetalle.AddCell(cell);
        //                TablaCabDetalle.CompleteRow();
        //            }
        //            else
        //            {
        //                TituloGrupo = "";

        //            }
        //            // CELDA PROYECTO
        //            cell = new PdfPCell(new Paragraph(TituloGrupo, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        //            TablaCabDetalle.AddCell(cell);

        //            // CELDA CONCEPTO
        //            cell = new PdfPCell(new Paragraph(item.desConcepto, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        //            TablaCabDetalle.AddCell(cell);
        //            //FOR DE CABECER
        //            foreach (ConceptoGastoE itemCabecera in oConceptoGastoCabecera)
        //            {

        //                //EVALUAR MES
        //                if (item.mesPeriodo == itemCabecera.mesPeriodo)
        //                {

        //                    Decimal A = Convert.ToDecimal(item.haberSoles) - Convert.ToDecimal(item.debeSoles);

        //                    itemCabecera.TotalImporte += A;
        //                    itemCabecera.TotalTotales += A;
        //                    SubTotalHor += A;

        //                    cell = new PdfPCell(new Paragraph(A.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
        //                    TablaCabDetalle.AddCell(cell);



        //                }

        //                else
        //                {
        //                    cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
        //                    TablaCabDetalle.AddCell(cell);


        //                }





        //            }


        //            cell = new PdfPCell(new Paragraph(SubTotalHor.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
        //            TablaCabDetalle.AddCell(cell);
        //            Contador++;

        //            TablaCabDetalle.CompleteRow();
        //        }

        //        Decimal SubTotalver = 0;

        //        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        //        TablaCabDetalle.AddCell(cell);
        //        // CELDA ultima
        //        cell = new PdfPCell(new Paragraph("TOTALES", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
        //        TablaCabDetalle.AddCell(cell);
        //        foreach (ConceptoGastoE itemCabecera in oConceptoGastoCabecera)
        //        {



        //            cell = new PdfPCell(new Paragraph(itemCabecera.TotalTotales.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
        //            TablaCabDetalle.AddCell(cell);
                    
        //            SubTotalver += itemCabecera.TotalTotales;
        //            itemCabecera.TotalTotales = 0;
        //            itemCabecera.TotalImporte = 0;




        //        }
        //        cell = new PdfPCell(new Paragraph(SubTotalver.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
        //        TablaCabDetalle.AddCell(cell);
        //        TablaCabDetalle.CompleteRow();




        //        docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        //        #endregion

        //        // crear una nueva acción para enviar el documento a nuestro nuevo destino.
        //        PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

        //        //establecer la acción abierta para nuestro objeto escritor
        //        oPdfw.SetOpenAction(action);

        //        //Liberando memoria
        //        oPdfw.Flush();
        //        docPdf.Close();
        //        fsNuevoArchivo.Close();
        //    }
        //}

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String MesInicio = Convert.ToString(cboInicio.SelectedValue);
                String MesFinal = Convert.ToString(cboFin.SelectedValue);
                String Mon = Convert.ToString(cboMon.SelectedValue);

                oConceptoGasto = AgenteContabilidad.Proxy.ListarReporteConceptoGasto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Mon, Anio, MesInicio, MesFinal);
            }
            else
            {
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String MesInicio = Convert.ToString(cboInicio.SelectedValue);
                String MesFinal = Convert.ToString(cboFin.SelectedValue);
                String Mon = Convert.ToString(cboMon.SelectedValue);
                oVoucherItem = AgenteContabilidad.Proxy.ReporteVoucherItemConceptoGasto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Mon, Anio, MesInicio, MesFinal);
                ExportarExcel(RutaGeneral);
            }
        }
         
        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            if (oConceptoGasto == null || oConceptoGasto.Count == 0)
            {
                Global.MensajeFault("No hay registros");
            }
            else
            {
                Pivot();
            }
            
            _bw.CancelAsync();
            _bw.Dispose();

            if (!String.IsNullOrEmpty(RutaGeneral))
            {
                //wbNavegador.Navigate(RutaGeneral);
                RutaGeneral = String.Empty;
            }
        }

        void Pivot() 
        {
            DataTable dtDatos = new DataTable();

            dtDatos.Columns.Add("PROYECTO");
            dtDatos.Columns.Add("CONCEPTO");
            dtDatos.Columns.Add("TOTAL");

            oConceptoGastoCabecera = oConceptoGasto.GroupBy(x => x.mesPeriodo).Select(x => x.First()).OrderBy(x => x.mesPeriodo).ToList();

            for (int i = 0; i < oConceptoGastoCabecera.Count; i++)
            {
                string mes = FechasHelper.NombreMes(Convert.ToInt32(oConceptoGastoCabecera[i].mesPeriodo)).ToUpper();
                dtDatos.Columns.Add(mes);
            }

            DataRow dt = null;
            String nombre="" ;
            String proyecto = "";

            decimal? fila_Total = 0;
            
            decimal debe = 0;
            decimal haber = 0;

            for (int i = 0; i < oConceptoGasto.Count; i++)
            {
                if(i==0)
                {
                    nombre = oConceptoGasto[i].nombre+oConceptoGasto[i].desConcepto;
                    proyecto = oConceptoGasto[i].nombre;
                }

                if (i == 0 || nombre != oConceptoGasto[i].nombre + oConceptoGasto[i].desConcepto)
                {
                    dt = dtDatos.NewRow();

                    // -----------------------
                    // SUB TOTAL
                    // -----------------------
                    if (proyecto != oConceptoGasto[i].nombre) 
                    {
                        fila_Total = 0;

                        dt["Proyecto"] = "Total";
                        dt["Concepto"] = "";

                        for (int ii = 0; ii < oConceptoGastoCabecera.Count; ii++)
                        {
                            string mes = FechasHelper.NombreMes(Convert.ToInt32(oConceptoGastoCabecera[ii].mesPeriodo));

                            debe = oConceptoGasto.Where(x => x.nombre == proyecto && x.mesPeriodo == oConceptoGastoCabecera[ii].mesPeriodo).ToList().Sum(x => x.debeSoles);
                            haber = oConceptoGasto.Where(x => x.nombre == proyecto && x.mesPeriodo == oConceptoGastoCabecera[ii].mesPeriodo).ToList().Sum(x => x.haberSoles);

                            if (debe > 0 || haber > 0)
                            {
                                dt[mes.ToUpper()] = (haber - debe).ToString("N2");
                                fila_Total += (haber - debe);
                            }
                            else
                                dt[mes.ToUpper()] = "0,00";


                        }

                        dt["TOTAL"] = Convert.ToDecimal(fila_Total).ToString("N2");

                        dtDatos.Rows.Add(dt);

                        proyecto = oConceptoGasto[i].nombre;
                    }

                    fila_Total = 0;
                    dt = dtDatos.NewRow();

                    nombre = oConceptoGasto[i].nombre + oConceptoGasto[i].desConcepto;
                    
                    dt["Proyecto"] = oConceptoGasto[i].nombre;
                    dt["Concepto"] = oConceptoGasto[i].desConcepto;

                    for (int ii = 0; ii < oConceptoGastoCabecera.Count; ii++)
                    {
                        string mes = FechasHelper.NombreMes(Convert.ToInt32(oConceptoGastoCabecera[ii].mesPeriodo));
                        debe = oConceptoGasto.Where(x => x.desConcepto == oConceptoGasto[i].desConcepto &&
                                                        x.nombre == oConceptoGasto[i].nombre && x.mesPeriodo == oConceptoGastoCabecera[ii].mesPeriodo).ToList().Sum(x => x.debeSoles);

                        haber = oConceptoGasto.Where(x => x.desConcepto == oConceptoGasto[i].desConcepto &&
                                                        x.nombre == oConceptoGasto[i].nombre && x.mesPeriodo == oConceptoGastoCabecera[ii].mesPeriodo).ToList().Sum(x => x.haberSoles);

                        if (debe > 0 || haber > 0)
                        {
                            dt[mes.ToUpper()] = (haber - debe).ToString("N2");
                            fila_Total += (haber - debe);
                        }
                        else
                            dt[mes.ToUpper()] = "0,00";
                    }

                    dt["TOTAL"] = Convert.ToDecimal(fila_Total).ToString("N2");
                    dtDatos.Rows.Add(dt);
                }
            }

            dt = dtDatos.NewRow();
            fila_Total = 0;

            dt["Proyecto"] = "Total";
            dt["Concepto"] = "";

            for (int ii = 0; ii < oConceptoGastoCabecera.Count; ii++)
            {
                string mes = FechasHelper.NombreMes(Convert.ToInt32(oConceptoGastoCabecera[ii].mesPeriodo));

                debe = oConceptoGasto.Where(x => x.nombre == proyecto && x.mesPeriodo == oConceptoGastoCabecera[ii].mesPeriodo).ToList().Sum(x => x.debeSoles);
                haber = oConceptoGasto.Where(x => x.nombre == proyecto && x.mesPeriodo == oConceptoGastoCabecera[ii].mesPeriodo).ToList().Sum(x => x.haberSoles);

                if (debe > 0 || haber > 0)
                {
                    dt[mes.ToUpper()] = (haber - debe).ToString("N2");
                    fila_Total += (haber - debe);
                }
                else
                    dt[mes.ToUpper()] = "0,00";
            }

            dt["TOTAL"] = Convert.ToDecimal(fila_Total).ToString("N2");

            dtDatos.Rows.Add(dt);

            // ==========================================

            dgvPivot.DataSource = dtDatos;

            dgvPivot.Columns[0].Width = 170;
            dgvPivot.Columns[1].Width = 230;

            for (int i = 0; i < dgvPivot.Columns.Count; i++)
            {   
                if (i > 1)
                {
                    dgvPivot.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPivot.Columns[i].DefaultCellStyle.Format = "###,###,##0.00";
                    dgvPivot.Columns[i].Width = 90 ;
                }
            }
        }

        #endregion

        #region Eventos

        private void frmReporteConceptoGasto_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
            cboAño.SelectedValue = Anio;
        }

        private void frmReporteConceptoGasto_FormClosing(object sender, FormClosingEventArgs e)
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
                //lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                //panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region EXCELINICIO

        public override void Exportar()
        {
            try
            {
                if (oConceptoGastoCabecera == null || oConceptoGastoCabecera.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String Mes = cboInicio.Text;
                String MesFin = cboFin.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Concepto Gasto" + " Del Mes " + Mes + " Al " + MesFin, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    //lblProcesando.Visible = true;
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
            String nombreMes = cboInicio.Text;
            String FinMes = cboFin.Text;
            String Mon = Convert.ToString(cboMon.SelectedValue);

            TituloGeneral = " Concepto Gasto " + " Al Año " + Anio + " Del Mes " + nombreMes + "  Al Mes  " + FinMes;
            NombrePestaña = " Concepto Gasto ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                String Mes = "";
                List<VoucherItemE> oListaGroup = new List<VoucherItemE>(oVoucherItem.GroupBy(x => x.MesPeriodo).Select(x => x.First()).OrderBy(x => x.MesPeriodo).ToList());

                for (int ii = 0; ii < oListaGroup.Count; ii++)
                {
                    if (ii == 0)
                    {
                        Mes = oListaGroup[ii].MesPeriodo;
                    }
                    if (ii == 0 || Mes != oListaGroup[ii].MesPeriodo)
                    {
                        Mes = oListaGroup[ii].MesPeriodo;

                        ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(FechasHelper.NombreMes(Convert.ToInt32(oListaGroup[ii].MesPeriodo)).ToUpper());

                        if (oHoja != null)
                        {
                            Int32 InicioLinea = 4;
                            Int32 TotColumnas = 6;

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
                            oHoja.Cells[InicioLinea, 1].Value = " PERIODO ";


                            oHoja.Cells[InicioLinea, 2].Value = " VOUCHER ";

                            oHoja.Cells[InicioLinea, 3].Value = " NUM. DOCUMENTO ";

                            oHoja.Cells[InicioLinea, 4].Value = " GLOSA GENERAL";


                            if (Mon == "01")
                            {


                                oHoja.Cells[InicioLinea, 5].Value = " DEBE SOLES";

                                oHoja.Cells[InicioLinea, 6].Value = " HABER SOLES ";
                            }
                            else
                            {

                                oHoja.Cells[InicioLinea, 5].Value = " DEBE DOLARES";

                                oHoja.Cells[InicioLinea, 6].Value = " HABER DOLARES ";
                            }


                            //oHoja.Cells[InicioLinea, 7].Value = " IND DEBE/HABER ";



                            for (int i = 1; i <= 6; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                            }
                            //Aumentando una Fila mas continuar con el detalle


                            InicioLinea++;



                            #endregion

                            #region Formato Excel

                            int Contador = 0;
                            String descampana = "";
                            String descampanae = "";

                            oVoucherItem = (from x in oVoucherItem orderby x.desCampana select x).ToList();

                            foreach (VoucherItemE item in oVoucherItem)
                            {
                                if (Mes == item.MesPeriodo)
                                {
                                    descampana = item.desCampana;

                                    if (descampanae != descampana)
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = "";
                                        oHoja.Cells[InicioLinea, 2].Value = "";
                                        oHoja.Cells[InicioLinea, 3].Value = "";
                                        oHoja.Cells[InicioLinea, 4].Value = descampana;
                                        oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, 5].Value = "";
                                        oHoja.Cells[InicioLinea, 6].Value = "";

                                        descampanae = descampana;
                                        InicioLinea++;
                                    }

                                    oHoja.Cells[InicioLinea, 1].Value = item.AnioPeriodo.ToString();
                                    oHoja.Cells[InicioLinea, 2].Value = item.numVoucher.ToString();
                                    oHoja.Cells[InicioLinea, 3].Value = item.numDocumento.ToString();
                                    oHoja.Cells[InicioLinea, 4].Value = item.desGlosa;
                                    oHoja.Cells[InicioLinea, 5].Value = item.impDebe;
                                    oHoja.Cells[InicioLinea, 6].Value = item.impHaber;

                                    oHoja.Cells[InicioLinea, 5, InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                    InicioLinea++;
                                    Contador++;
                                }
                            }

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

                            #endregion

                        }
                    }
                }

                //Guardando el excel
                oExcel.Save();
            }
        }

        private void dgvPivot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvPivot.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Total") || e.ColumnIndex == 2)
                {
                    e.CellStyle.BackColor = Color.Bisque;
                }
            }
        }

        private void dgvPivot_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            int idLocal = VariablesLocales.SesionLocal.IdLocal;

            int rowindex = dgvPivot.CurrentCell.RowIndex;
            int columnindex = dgvPivot.CurrentCell.ColumnIndex;


            // se valida que sea celda con valor
            if (columnindex > 2  &&
                    dgvPivot.Rows[rowindex].Cells[0].Value.ToString() != "Total")
            {
                
                string proyecto = dgvPivot.Rows[rowindex].Cells[0].Value.ToString();
                string concepto = dgvPivot.Rows[rowindex].Cells[1].Value.ToString();
                
                // =========================================================

                String columnName = dgvPivot.Columns[columnindex].Name;
                string mes = (columnName.Contains("APE") ? "00" :(columnName.Contains("ENE") ? "01" : (columnName.Contains("FEB") ? "02" : (columnName.Contains("MAR") ? "03" : (columnName.Contains("ABR") ? "04" : (columnName.Contains("MAY") ? "05" : (columnName.Contains("JUN") ? "06" : (columnName.Contains("JUL") ? "07" : (columnName.Contains("AGO") ? "08" : (columnName.Contains("SET") ? "09" : (columnName.Contains("OCT") ? "10" : (columnName.Contains("NOV") ? "11" : (columnName.Contains("DIC") ? "12" : "13")))))))))))));

                // =========================================================
                
                List<VoucherItemE> oListaDetalle;

                oListaDetalle = AgenteContabilidad.Proxy.ListarVoucherItemConceptoGasto(
                                        idEmpresa, cboMon.SelectedValue.ToString(), cboAño.SelectedValue.ToString(), mes, proyecto,concepto);
                
                if (oListaDetalle == null || oListaDetalle.Count == 0)
                {
                    Global.MensajeFault("No hay registros ");
                    return;
                }

                // =========================================================

                CerrarFormulario("frmReporteConceptoGastoDetalle");

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteConceptoGastoDetalle);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmReporteConceptoGastoDetalle(oListaDetalle,proyecto + " - " + concepto + " - " + columnName);
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
        }

        private void dgvPivot_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion
    }
}

class PaginaInicioConceptoGasto : PdfPageEventHelper
{
    public String Moneda { get; set; }
    public String NomMoneda { get; set; }
    public String Anio { get; set; }
    public Int32 MesFin { get; set; }
    public Int32 Mes { get; set; }
    public String NombreMes { get; set; }
    public String NombreFinMes { get; set; }
    public List<ConceptoGastoE> oConceptoGastoCabecera { get; set; }

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

        if (Moneda == "01")
        {
            NomMoneda = "Soles Peruanos";
        }

        if (Moneda == "02")
        {
            NomMoneda = "Dolares Americanos";
        }

        NombreMes = FechasHelper.NombreMes(Mes);
        NombreFinMes = FechasHelper.NombreMes(MesFin);

        TituloGeneral = " Concepto Gasto " + " Expresado En " + NomMoneda.ToUpper();
        SubTitulo = "AÑO : " + Anio.ToUpper() + " DEL MES : " + NombreMes.ToUpper() + " AL MES " + NombreFinMes.ToUpper();

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

        int TotalColumnas = 2 + this.oConceptoGastoCabecera.Count + 1;
        PdfPTable TablaCabDetalle = new PdfPTable(TotalColumnas);
        TablaCabDetalle.WidthPercentage = 100;

        float[] array = new float[TotalColumnas];

        for (int i = 0; i < TotalColumnas; i++)
        {
            if (i == 0)
                array[i] = 0.025f;
            if (i == 1)
                array[i] = 0.035f;
            if (i >= 2 && i < TotalColumnas - 1)
                array[i] = 0.02f;
            if (i == TotalColumnas - 1)
                array[i] = 0.015f;
        }

        TablaCabDetalle.SetWidths(array);

        #region Primera Linea

        cell = new PdfPCell(new Paragraph("PROYECTO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("CONCEPTO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        for (int i = 0; i < this.oConceptoGastoCabecera.Count; i++)
        {
            cell = new PdfPCell(new Paragraph(FechasHelper.NombreMes(Convert.ToInt32(this.oConceptoGastoCabecera[i].mesPeriodo)), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);
        }

        cell = new PdfPCell(new Paragraph("SUB TOTAL", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 1;
        TablaCabDetalle.AddCell(cell);
        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }
    

}
       
  