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
    public partial class frmReporteComprasVarias : FrmMantenimientoBase
    {
        #region Constructor

        public frmReporteComprasVarias()
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
        List<ComprasVariasE> oReporteCV = null;
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

            ////FlagGrabado////
            cboFlag.DataSource = Global.CargarFPCE();
            cboFlag.ValueMember = "id";
            cboFlag.DisplayMember = "Nombre";
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\ComprasVarias " + Aleatorio.ToString();
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

                PaginaInicioComprasVarias ev = new PaginaInicioComprasVarias();
                ev.Anio = Convert.ToString(cboAño.SelectedValue);
                ev.Mes = Convert.ToInt32(cboMes.SelectedValue);
                ev.Flag = Convert.ToString(cboFlag.SelectedValue);
                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(12);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.025f, 0.033f, 0.055f, 0.35f, 0.046f, 0.046f, 0.046f, 0.05f, 0.046f, 0.046f, 0.046f, 0.05f });

                Decimal BaseGrabadoS = 0;
                Decimal BaseNoGrabadoS = 0;
                Decimal IGVGrabadoS = 0;

                Decimal BaseGrabadoD = 0;
                Decimal BaseNoGrabadoD = 0;
                Decimal IGVGrabadoD = 0;

                Decimal TotalS = 0;
                Decimal TotalD = 0;
                DateTime FecOperacion;
                Decimal A = 0;
                Decimal B = 0;
                Decimal C = 0;
                Decimal D = 0;
                Decimal E = 0;
                Decimal F = 0;
                Decimal G = 0;
                Decimal H = 0;

                foreach (ComprasVariasE item in oReporteCV)
                {
                    FecOperacion = item.fecOperacion;
                    //SiEsSoles////
                    if (item.idMoneda == "01")
                    {
                        BaseGrabadoS = Convert.ToDecimal(item.montAfecto) / Convert.ToDecimal(item.tipCambio);
                    }
                    else
                    {
                        BaseGrabadoS = Convert.ToDecimal(item.montAfecto);
                    }

                    if (item.idMoneda == "01")
                    {
                        BaseNoGrabadoS = Convert.ToDecimal(item.montInafecto) / Convert.ToDecimal(item.tipCambio);
                    }
                    else
                    {
                        BaseNoGrabadoS = Convert.ToDecimal(item.montInafecto);
                    }

                    if (item.idMoneda == "01")
                    {
                        IGVGrabadoS = Convert.ToDecimal(item.montIGV) / Convert.ToDecimal(item.tipCambio);
                    }
                    else
                    {
                        IGVGrabadoS = Convert.ToDecimal(item.montIGV);
                    }

                    if (item.idMoneda == "01")
                    {
                        TotalS = Convert.ToDecimal(item.montTotal) / Convert.ToDecimal(item.tipCambio);
                    }
                    else
                    {
                        TotalS = Convert.ToDecimal(item.montTotal);
                    }

                    //SIesDolares//
                    if (item.idMoneda == "02")
                    {
                        BaseGrabadoD = Convert.ToDecimal(item.montAfecto) * Convert.ToDecimal(item.tipCambio);
                    }
                    else
                    {
                        BaseGrabadoD = Convert.ToDecimal(item.montAfecto);
                    }

                    if (item.idMoneda == "02")
                    {
                        BaseNoGrabadoD = Convert.ToDecimal(item.montInafecto) * Convert.ToDecimal(item.tipCambio);
                    }
                    else
                    {
                        BaseNoGrabadoD = Convert.ToDecimal(item.montInafecto);
                    }

                    if (item.idMoneda == "02")
                    {
                        IGVGrabadoD = Convert.ToDecimal(item.montIGV) * Convert.ToDecimal(item.tipCambio);
                    }
                    else
                    {
                        IGVGrabadoD = Convert.ToDecimal(item.montIGV);
                    }

                    if (item.idMoneda == "02")
                    {
                        TotalD = Convert.ToDecimal(item.montTotal) * Convert.ToDecimal(item.tipCambio);
                    }
                    else
                    {
                        TotalD = Convert.ToDecimal(item.montTotal);
                    }

                    A = A + BaseGrabadoS;
                    B = B + BaseNoGrabadoS;
                    C = C + IGVGrabadoS;
                    D = D + TotalS;
                    E = E + BaseGrabadoD;
                    F = F + BaseNoGrabadoD;
                    G = G + IGVGrabadoD;
                    H = H + TotalD;

                    cell = new PdfPCell(new Paragraph(item.numRegistro, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(FecOperacion.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.tipDocumento + " " +  item.serDocumento + "-"+ item.numDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.RUC + " " + item.RazonSocial, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(BaseGrabadoS.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(BaseNoGrabadoS.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(IGVGrabadoS.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(TotalS.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(BaseGrabadoD.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(BaseNoGrabadoD.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(IGVGrabadoD.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(TotalD.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);                   

                    TablaCabDetalle.CompleteRow();
                }

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("-----------------------", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(A.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(B.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(C.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(D.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(E.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(F.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(G.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(H.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String nombreMes = cboMes.Text;

            TituloGeneral = " Compras Varias " + Anio + " - " + nombreMes;
            NombrePestaña = " Compras Varias ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 17;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    #endregion Titulos Principales

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " ACTA ";
                    oHoja.Cells[InicioLinea, 2].Value = " FECHA ";
                    oHoja.Cells[InicioLinea, 3].Value = " TD ";
                    oHoja.Cells[InicioLinea, 4].Value = " SERIE ";
                    oHoja.Cells[InicioLinea, 5].Value = " DOCUMENTO ";
                    oHoja.Cells[InicioLinea, 6].Value = " RUC ";
                    oHoja.Cells[InicioLinea, 7].Value = " PROVEEDOR ";
                    oHoja.Cells[InicioLinea, 8].Value = " DOLARES ";
                    oHoja.Cells[InicioLinea, 11].Value = " TOTAL ";
                    oHoja.Cells[InicioLinea, 12].Value = " SOLES ";
                    oHoja.Cells[InicioLinea, 15].Value = " TOTAL ";
                    oHoja.Cells[InicioLinea, 16].Value = " TC. ";
                    oHoja.Cells[InicioLinea, 17].Value = " MON. ";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea + 1, 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea + 1, 3])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 4, InicioLinea + 1, 4])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea + 1, 5])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, InicioLinea, 10])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 11, InicioLinea + 1, 11])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 12, InicioLinea, 14])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 15, InicioLinea + 1, 15])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 16, InicioLinea + 1, 16])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 17, InicioLinea + 1, 17])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    oHoja.Cells[InicioLinea + 1, 8].Value = " GRAVADO ";
                    oHoja.Cells[InicioLinea + 1, 9].Value = " NO GRAVADO ";
                    oHoja.Cells[InicioLinea + 1, 10].Value = " IGV ";

                    oHoja.Cells[InicioLinea + 1, 12].Value = " GRAVADO ";
                    oHoja.Cells[InicioLinea + 1, 13].Value = " NO GRAVADO ";
                    oHoja.Cells[InicioLinea + 1, 14].Value = " IGV ";

                    for (int i = 8; i <= 14; i++)
                    {
                        if (i != 11)
                        {
                            oHoja.Cells[InicioLinea + 1, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea + 1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea + 1, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea + 1, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea + 1, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black); 
                        }
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    #endregion Cabeceras del Detalle

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #region Variables
                    
                    Decimal BaseGrabadoS = 0;
                    Decimal BaseNoGrabadoS = 0;
                    Decimal IGVGrabadoS = 0;

                    Decimal BaseGrabadoD = 0;
                    Decimal BaseNoGrabadoD = 0;
                    Decimal IGVGrabadoD = 0;

                    Decimal TotalS = 0;
                    Decimal TotalD = 0;

                    Decimal A = 0;
                    Decimal B = 0;
                    Decimal C = 0;
                    Decimal D = 0;
                    Decimal E = 0;
                    Decimal F = 0;
                    Decimal G = 0;
                    Decimal H = 0; 

                    #endregion

                    foreach (ComprasVariasE item in oReporteCV)
                    {
                        #region Si es Soles

                        if (item.idMoneda == "01")
                        {
                            BaseGrabadoS = Convert.ToDecimal(item.montAfecto) / Convert.ToDecimal(item.tipCambio);
                        }
                        else
                        {
                            BaseGrabadoS = Convert.ToDecimal(item.montAfecto);
                        }

                        if (item.idMoneda == "01")
                        {
                            BaseNoGrabadoS = Convert.ToDecimal(item.montInafecto) / Convert.ToDecimal(item.tipCambio);
                        }
                        else
                        {
                            BaseNoGrabadoS = Convert.ToDecimal(item.montInafecto);
                        }

                        if (item.idMoneda == "01")
                        {
                            IGVGrabadoS = Convert.ToDecimal(item.montIGV) / Convert.ToDecimal(item.tipCambio);
                        }
                        else
                        {
                            IGVGrabadoS = Convert.ToDecimal(item.montIGV);
                        }

                        if (item.idMoneda == "01")
                        {
                            TotalS = Convert.ToDecimal(item.montTotal) / Convert.ToDecimal(item.tipCambio);
                        }
                        else
                        {
                            TotalS = Convert.ToDecimal(item.montTotal);
                        }

                        #endregion

                        #region Si es Dólares
                        
                        if (item.idMoneda == "02")
                        {
                            BaseGrabadoD = Convert.ToDecimal(item.montAfecto) * Convert.ToDecimal(item.tipCambio);
                        }
                        else
                        {
                            BaseGrabadoD = Convert.ToDecimal(item.montAfecto);
                        }

                        if (item.idMoneda == "02")
                        {
                            BaseNoGrabadoD = Convert.ToDecimal(item.montInafecto) * Convert.ToDecimal(item.tipCambio);
                        }
                        else
                        {
                            BaseNoGrabadoD = Convert.ToDecimal(item.montInafecto);
                        }

                        if (item.idMoneda == "02")
                        {
                            IGVGrabadoD = Convert.ToDecimal(item.montIGV) * Convert.ToDecimal(item.tipCambio);
                        }
                        else
                        {
                            IGVGrabadoD = Convert.ToDecimal(item.montIGV);
                        }

                        if (item.idMoneda == "02")
                        {
                            TotalD = Convert.ToDecimal(item.montTotal) * Convert.ToDecimal(item.tipCambio);
                        }
                        else
                        {
                            TotalD = Convert.ToDecimal(item.montTotal);
                        }

                        #endregion

                        A = A + BaseGrabadoS;
                        B = B + BaseNoGrabadoS;
                        C = C + IGVGrabadoS;
                        D = D + TotalS;
                        E = E + BaseGrabadoD;
                        F = F + BaseNoGrabadoD;
                        G = G + IGVGrabadoD;
                        H = H + TotalD;

                        oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 1].Value = item.numRegistro;
                        oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 2].Value = item.fecOperacion;
                        oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 3].Value = item.tipDocumento;
                        oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 4].Value = item.serDocumento;
                        oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 5].Value = item.numDocumento;
                        oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 6].Value = item.RUC;
                        oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 7].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 8].Value = BaseGrabadoS;
                        oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 9].Value = BaseNoGrabadoS;
                        oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 10].Value = IGVGrabadoS;
                        oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 11].Value = TotalS;
                        oHoja.Cells[InicioLinea, 12].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 12].Value = BaseGrabadoD;
                        oHoja.Cells[InicioLinea, 13].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 13].Value = BaseNoGrabadoD;
                        oHoja.Cells[InicioLinea, 14].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 14].Value = IGVGrabadoD;
                        oHoja.Cells[InicioLinea, 15].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 15].Value = TotalD;
                        oHoja.Cells[InicioLinea, 16].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 16].Value = item.tipCambio;
                        oHoja.Cells[InicioLinea, 17].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        
                        if (item.idMoneda == Variables.Soles)
                        {
                            oHoja.Cells[InicioLinea, 17].Value = "S";
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 17].Value = "D";
                        }

                        // Formateo
                        oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 7, InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "##0.000";

                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 7].Value = " TOTALES ";
                    oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 8].Value = A;
                    oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 9].Value = B;
                    oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 10].Value = C;
                    oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 11].Value = D;
                    oHoja.Cells[InicioLinea, 12].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 12].Value = E;
                    oHoja.Cells[InicioLinea, 13].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 13].Value = F;
                    oHoja.Cells[InicioLinea, 14].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 14].Value = G;
                    oHoja.Cells[InicioLinea, 15].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    oHoja.Cells[InicioLinea, 15].Value = H;

                    oHoja.Cells[InicioLinea, 8, InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";

                    //Linea
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

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

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oReporteCV == null || oReporteCV.Count == Variables.Cero)
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

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Compras Varias" + NombreLocal + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

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
            if (tipo == "buscar")
            {
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String Mes = Convert.ToString(cboMes.SelectedValue);
                String Flag = Convert.ToString(cboFlag.SelectedValue);
            
                lblProcesando.Text = "Obteniendo el Reporte Compras Varias...";
                oReporteCV = AgenteContabilidad.Proxy.ListarReporteComprasVariasPorGrabacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, Anio, Mes, Flag);
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
                Global.MensajeComunicacion("Compras Varias Exportada...");
            }
        }

        #endregion

        #region Eventos

        private void frmReporteComprasVarias_Load(object sender, EventArgs e)
        {
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Ubicacion del Reporte
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void frmReporteComprasVarias_FormClosing(object sender, FormClosingEventArgs e)
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

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        }

        #endregion
    }
}


#region Pdf Inicio


class PaginaInicioComprasVarias : PdfPageEventHelper
{
    public DateTime Per { get; set; }
    public String Moneda { get; set; }
    public String NomMoneda { get; set; }
    public String Anio { get; set; }
    public Int32 Mes { get; set; }
    public String NombreMes { get; set; }
    public String Flag { get; set; }
    public String NombreFlag { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

        if (Flag == "F")
        {
            NombreFlag = "Free";
        }

        if (Flag == "P")
        {
            NombreFlag = "Paid";
        }
        if (Flag == "C")
        {
            NombreFlag = "Costos";
        }
        if (Flag == "E")
        {
            NombreFlag = "Existencia";
        }

        #region Meses

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

        #endregion

        TituloGeneral = "COMPRAS " + NombreFlag.ToUpper();
        SubTitulo = "AÑO : " + Anio.ToUpper() + " MES : " + NombreMes.ToUpper();

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
        TablaCabDetalle.SetWidths(new float[] { 0.025f, 0.033f, 0.055f, 0.35f, 0.046f, 0.046f, 0.046f, 0.05f, 0.046f, 0.046f, 0.046f, 0.05f });
        
        #region Primera Linea

        cell = new PdfPCell(new Paragraph("ACTA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("FECHA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("DOCUMENTO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("PROVEEDOR", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("DOLARES", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 3;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("TOTAL", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("SOLES", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 3;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("TOTAL", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Rowspan = 1;
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion

        #region Segunda Linea

        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Gravado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("No Gravado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("IGV", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Gravado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        //cell.Rowspan = 3;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("No Gravado", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("IGV", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }
}

#endregion