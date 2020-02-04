using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using ClienteWinForm;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using ClienteWinForm.Busquedas;
using System.Text;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteRegistroBancos : FrmMantenimientoBase
    {
        public frmReporteRegistroBancos()
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
        List<VoucherItemE> oReporteMovimientos = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String Marque = String.Empty;
        string tipo = "buscar";

        #endregion

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

            /////MES////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboInicioMes.DataSource = oDt;
            cboInicioMes.ValueMember = "MesId";
            cboInicioMes.DisplayMember = "MesDes";
            cboInicioMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;


            /////MES////
            DataTable oET = FechasHelper.CargarMesesContable("MA");
            DataRow Fila2 = oET.NewRow();
            Fila2["MesId"] = "0";
            Fila2["MesDes"] = Variables.Todos;
            oET.Rows.Add(Fila2);

            oET.DefaultView.Sort = "MesId";
            cboFinMes.DataSource = oET;
            cboFinMes.ValueMember = "MesId";
            cboFinMes.DisplayMember = "MesDes";
            cboFinMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;


            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;


            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";


        }

        #region Procedimientos de Usuario

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

                PaginaInicialRegBancos ev = new PaginaInicialRegBancos();
                oPdfw.PageEvent = ev;
                docPdf.Open();

                #region Variables PDF 

                String CodCuenta = String.Empty;            
                List<VoucherItemE> ListaVoucherTmp = null;
                String SubTitulo = String.Empty;
                String SubTitulo2 = String.Empty;
                String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
                String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
                BaseColor ColorCab = BaseColor.LIGHT_GRAY;
                String MesIni = Convert.ToString(cboInicioMes.SelectedValue);
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String NombreMes = String.Empty;
                Int32 contador = 0;

                #endregion

                List<VoucherItemE> oListaCabeceras = oReporteMovimientos.GroupBy(x => x.codCuenta).Select(g => g.First()).ToList();
                //contador = oListaCabeceras.Count;

                foreach (VoucherItemE itemCab in oListaCabeceras)
                {
                    Decimal subtotalsaldos = 0;

                    #region Cabecera y Detalle

                    contador++;

                    PdfPTable TablaCabDetalle = new PdfPTable(10)
                    {
                        WidthPercentage = 100
                    };

                    TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.15f, 0.1f, 0.4f, 0.05f, 0.05f, 0.07f, 0.07f, 0.07f, 0.07f });

                    #region Meses

                    if (MesIni == "00")
                    {
                        NombreMes = "APERTURA";
                    }
                    if (MesIni == "01")
                    {
                        NombreMes = "ENERO";
                    }
                    if (MesIni == "02")
                    {
                        NombreMes = "FEBRERO";
                    }
                    if (MesIni == "03")
                    {
                        NombreMes = "MARZO";
                    }
                    if (MesIni == "04")
                    {
                        NombreMes = "ABRIL";
                    }
                    if (MesIni == "05")
                    {
                        NombreMes = "MAYO";
                    }
                    if (MesIni == "06")
                    {
                        NombreMes = "JUNIO";
                    }
                    if (MesIni == "07")
                    {
                        NombreMes = "JULIO";
                    }
                    if (MesIni == "08")
                    {
                        NombreMes = "AGOSTO";
                    }
                    if (MesIni == "09")
                    {
                        NombreMes = "SETIEMBRE";
                    }
                    if (MesIni == "10")
                    {
                        NombreMes = "OCTUBRE";
                    }
                    if (MesIni == "11")
                    {
                        NombreMes = "NOVIEMBRE";
                    }
                    if (MesIni == "12")
                    {
                        NombreMes = "DICIEMBRE";
                    }
                    if (MesIni == "13")
                    {
                        NombreMes = "CIERRE";
                    }

                    #endregion

                    #region Titulos Principales
                                                            
                    SubTitulo2 = itemCab.codCuenta + "  " + itemCab.desCuenta;


                    PdfPTable table = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    table.SetWidths(new float[] { 0.9f, 0.13f });
                    table.HorizontalAlignment = Element.ALIGN_LEFT;

                    table.AddCell(ReaderHelper.NuevaCelda(SubTitulo2, null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f, "S2"));
                    table.CompleteRow();

                    table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 1, 1, "S2", "N", 1.2f, 1.2f, "S2"));
                    table.CompleteRow();

                    docPdf.Add(table);

                    #endregion

                    #region Cabecera del Detalle


                    table = new PdfPTable(10)
                    {
                        WidthPercentage = 100
                    };

                    table.SetWidths(new float[] { 0.05f, 0.15f, 0.1f, 0.4f, 0.05f, 0.05f, 0.07f, 0.07f, 0.07f, 0.07f });

                    #region Primera Linea

                    table.AddCell(ReaderHelper.NuevaCelda("Partida Presup.", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    table.AddCell(ReaderHelper.NuevaCelda(" ", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N"));
                    table.AddCell(ReaderHelper.NuevaCelda("Glosa/Descripción/Concepto", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                    table.AddCell(ReaderHelper.NuevaCelda("Medio de Pago", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                    table.AddCell(ReaderHelper.NuevaCelda("Tipo de Docum.", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                    table.AddCell(ReaderHelper.NuevaCelda("Docum. N°", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                    table.AddCell(ReaderHelper.NuevaCelda("Movimiento", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                    table.AddCell(ReaderHelper.NuevaCelda("Saldo", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));

                    table.CompleteRow();

                    #endregion

                    #region Segunda Linea

                    table.AddCell(ReaderHelper.NuevaCelda("Cod.", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    table.AddCell(ReaderHelper.NuevaCelda("Concepto", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    table.AddCell(ReaderHelper.NuevaCelda("Fecha", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    table.AddCell(ReaderHelper.NuevaCelda("Debe", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));
                    table.AddCell(ReaderHelper.NuevaCelda("Haber", ColorCab, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));

                    table.CompleteRow();

                    #endregion

                    docPdf.Add(table);

                    #endregion

                    //Detalle
                    ListaVoucherTmp = oReporteMovimientos.Where(x => x.codCuenta == itemCab.codCuenta).ToList();

                    #region Detalle

                    foreach (VoucherItemE item in ListaVoucherTmp)
                    {
                        cell = new PdfPCell(new Paragraph(item.codPartidaPresu, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.desPartidaPresu, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.fecOperacion.Value.ToString("d"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.GlosaGeneral, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.desMedioPago, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.idDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.numDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.impDebe.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.impHaber.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        subtotalsaldos += item.impDebe - item.impHaber;

                        cell = new PdfPCell(new Paragraph(subtotalsaldos.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }
                    
                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion

                    #endregion

                    if (contador != oListaCabeceras.Count)
                    {
                        docPdf.NewPage(); 
                    }
                }

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

            TituloGeneral = "Reporte Registro Bancos";
            NombrePestaña = "Reporte Registro Bancos";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                List<VoucherItemE> oListaCabeceras = oReporteMovimientos.GroupBy(x => x.codCuenta).Select(g => g.First()).ToList();
                List<VoucherItemE> ListaVoucherTmp = null;
                ExcelWorksheet oHoja = null;// oExcel.Workbook.Worksheets.Add(NombrePestaña);

                #region Meses

                String MesIni = cboInicioMes.SelectedValue.ToString();
                String NombreMes = FechasHelper.NombreMes(Convert.ToInt32(MesIni)).ToUpper();
                String MesFin = cboFinMes.SelectedValue.ToString();
                String NombreMes2 = FechasHelper.NombreMes(Convert.ToInt32(MesFin)).ToUpper();

                #endregion

                String Anio = cboAño.SelectedValue.ToString();

                foreach (VoucherItemE item in oListaCabeceras)
                {
                    oHoja = oExcel.Workbook.Worksheets.Add(item.codCuenta);

                    if (oHoja != null)
                    {
                        #region Bancos

                        Int32 InicioLinea = 5;
                        Int32 TotColumnas = 10;

                        #region Titulos Principales

                        // Creando Encabezado;
                        oHoja.Cells["A1"].Value = "REGISTRO DE LIBRO BANCOS";

                        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.White);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(62, 192, 218));
                        }

                        if (MesIni == MesFin)
                        {
                            oHoja.Cells["A2"].Value = "Periodo : " + NombreMes + " Del " + Anio;
                        }

                        if (MesIni == MesFin)
                        {
                            oHoja.Cells["A2"].Value = "Del Mes " + NombreMes + " Al " + NombreMes2 + " Del " + Anio;
                        }

                        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                        {
                            Rango.Merge = true;                                                      
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells["A3"].Value = item.codCuenta + " - " + item.desCuenta ;

                        using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        #endregion Titulos Principales

                        #region Cabeceras del Detalle

                        //// PRIMERA
                        oHoja.Column(1).Width = 10;
                        oHoja.Column(2).Width = 24;
                        oHoja.Column(3).Width = 12;
                        oHoja.Column(4).Width = 75;
                        oHoja.Column(5).Width = 20;
                        oHoja.Column(6).Width = 15;
                        oHoja.Column(7).Width = 10;
                        oHoja.Column(8).Width = 10;
                        oHoja.Column(9).Width = 10;
                        oHoja.Column(10).Width = 12;
                        oHoja.Cells[InicioLinea, 1].Value = "Partida Presup. ";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 2])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        oHoja.Cells[InicioLinea, 3].Value = "Fecha";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, 6, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        oHoja.Cells[InicioLinea, 4].Value = "Glosa / Descripción / Concepto";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 4, 6, 4])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }


                        oHoja.Cells[InicioLinea, 5].Value = "Medio de Pago";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, 6, 5])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        oHoja.Cells[InicioLinea, 6].Value = "Tipo Docum.";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, 6, 6])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        oHoja.Cells[InicioLinea, 7].Value = "Docum. N°";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, 6, 7])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        oHoja.Cells[InicioLinea, 8].Value = "Movimiento";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, InicioLinea, 9])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        oHoja.Cells[InicioLinea, 10].Value = "Saldo";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 10, 6, 10])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        for (int i = 1; i <= 10; i++)
                        {
                                oHoja.Cells[InicioLinea , i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea , i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(220, 216, 210));
                                oHoja.Cells[InicioLinea , i].Style.Font.Bold = true;                          
                        }

                        InicioLinea++;

                        // SEGUNDA
                        oHoja.Cells[InicioLinea, 1].Value = "Cod.";
                        oHoja.Cells[InicioLinea, 1].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        oHoja.Cells[InicioLinea, 2].Value = "Concepto";
                        oHoja.Cells[InicioLinea, 2].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        oHoja.Cells[InicioLinea, 8].Value = "Debe";
                        oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        oHoja.Cells[InicioLinea, 9].Value = "Haber";
                        oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                        for (int i = 1; i <= 10; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(220, 216, 210));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        }


                        InicioLinea++;

                        #endregion Cabeceras del Detalle

                        String CodCuenta = String.Empty;
                        Decimal subtotalsaldos = 0;

                        //Detalle
                        ListaVoucherTmp = oReporteMovimientos.Where(x => x.codCuenta == item.codCuenta).ToList();

                        foreach (VoucherItemE itemdet in ListaVoucherTmp)
                        {
                            
                                oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 1].Value = itemdet.codPartidaPresu;
                                oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[InicioLinea, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 2].Value = itemdet.desPartidaPresu;

                                oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 3].Value = itemdet.fecOperacion;
                                oHoja.Cells[InicioLinea, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[InicioLinea, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 4].Value = itemdet.GlosaGeneral;

                                oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 5].Value = itemdet.desMedioPago;
                                oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[InicioLinea, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 6].Value = itemdet.idDocumento;
                                oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[InicioLinea, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                oHoja.Cells[InicioLinea, 7].Value = itemdet.numDocumento;
                                oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[InicioLinea, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                oHoja.Cells[InicioLinea, 8].Value = itemdet.impDebe;
                                oHoja.Cells[InicioLinea, 9].Value = itemdet.impHaber;

                                subtotalsaldos += itemdet.impDebe - itemdet.impHaber;
                                oHoja.Cells[InicioLinea, 10].Value = subtotalsaldos;

                                oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                                // Formateo
                                oHoja.Cells[InicioLinea, 8, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";

                                InicioLinea++;                          
                        }

                        #endregion

                    }
                }

                if (oHoja != null)
                {
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

        void CambiosChecked()
        {
            //CheckMov = "Bancos";
            txtCuentaIni.Text = "104";
            txtCuentaFin.Text = "104";
            ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
            ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);

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

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Reporte Libro Cajas y Bancos", "Archivos Excel (*.xlsx)|*.xlsx");

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

        private void frmReporteMovimientosEfectivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        void ObtenerDescripcionCuenta(TextBox txtcuenta, TextBox txtdescripcion)
        {
            if (txtcuenta.Text.Trim() != "")
                txtdescripcion.Text = AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtcuenta.Text.ToString());
            else
                txtdescripcion.Text = "";
        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (tipo == "buscar")
                {
                    Int32 local = Convert.ToInt32(cboSucursales.SelectedValue);
                    String CuentaIni = txtCuentaIni.Text;
                    String CuentaFin = txtCuentaFin.Text;
                    String Plan = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                    lblProcesando.Text = "Obteniendo Los Movimientos Cta Cte...";
                    oReporteMovimientos = AgenteContabilidad.Proxy.ReporteMovimientoBanco(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, local, Plan, cboAño.SelectedValue.ToString(), cboInicioMes.SelectedValue.ToString(), cboFinMes.SelectedValue.ToString(), CuentaIni, CuentaFin);
                    lblProcesando.Text = "Armando el Reporte...";
                    ConvertirApdf();

                }
                else
                {
                    ExportarExcel(RutaGeneral);
                }
            }
            catch (Exception ex)
            {

                Global.MensajeError(ex.Message);
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
                Global.MensajeComunicacion("Movimientos Exportado...");
            }
        }
        
        #endregion

        #region Eventos

        private void frmReporteMovimientosEfectivo_Load(object sender, EventArgs e)
        {
            Grid = true;
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            CambiosChecked();
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

        private void txtCuentaIni_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
        }

        private void txtCuentaFin_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
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
             
        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        } 

        #endregion

    }
}


#region Pdf Inicio


class PaginaInicialRegBancos : PdfPageEventHelper
{
    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        #region Variables

        BaseColor colCabDetalle = BaseColor.LIGHT_GRAY;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

        #endregion Variables

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2)
        {
            WidthPercentage = 100
        };

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

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda("REGISTRO DE LIBROS BANCOS", null, "N", null, FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        table.CompleteRow();

        document.Add(table); //Añadiendo la tabla al documento PDF
    }
}

#endregion