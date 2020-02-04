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

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Negocio;

#endregion

#region Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteRegistroVentasLe : FrmMantenimientoBase
    {

        public frmReporteRegistroVentasLe()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            Global.CrearToolTip(btPle, "Importar para el PLE");
            Global.CrearToolTip(btPdb, "Importar para el PDB");
            Global.CrearToolTip(btBuscar, "Mostrar reporte");
            Global.CrearToolTip(btExportar, "Exportar al Excel");
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroVentasE> oListaRegistroVentas = null;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        Int32 letra = 0;
        int tipoProceso = 0; // 1 buscar ; 0 exportar
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Int16 Formato = 1;

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
            try
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
                    float[] Columnas = new float[] { 0.08f, 0.068f, 0.068f, 0.033f, 0.045f, 0.06f, 0.03f, 0.033f, 0.09f, 0.42f, 0.08f, 0.08f,
                                                            0.06f, 0.06f, 0.05f, 0.045f, 0.08f, 0.03f, 0.068f, 0.033f, 0.045f, 0.06f };
                    //Para la creacion del archivo pdf
                    RutaGeneral += NombreReporte + Extension;

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

                        PaginaInicialRegistroVentas ev = new PaginaInicialRegistroVentas
                        {
                            Periodo = dtpFecIni.Value.Date,
                            PeriodoFin = dtpFecFin.Value.Date,
                            Moneda = cboMonedas.SelectedValue.ToString(),
                            Anchos = Columnas
                        };

                        oPdfw.PageEvent = ev;

                        docPdf.Open();

                        #region Detalle

                        PdfPTable TablaCabDetalle = new PdfPTable(22)
                        {
                            WidthPercentage = 100
                        };

                        TablaCabDetalle.SetWidths(Columnas);

                        foreach (RegistroVentasE item in oListaRegistroVentas)
                        {
                            if (item.RazonSocial.Contains("Totales Acumulados"))
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 3f), 5, 1, "S22", "N", 2f, 2f, "S", "N", "N", "N", 1f));
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Correlativo, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));

                            if (item.fecDocumento != null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecDocumento.Value.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            }

                            if (item.fecVencimiento != null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecVencimiento.Value.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipDocVenta, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Serie, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Numero, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipDocPersona, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numDocPersona, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));

                            if (item.RazonSocial.Contains("Totales Acumulados"))
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2)); 
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 0));
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.BaseExportacion.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.BaseImponible.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.BaseExonerada.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.BaseInafecta.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Igv.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.OtrosTributos.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Total.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));

                            if (item.Tica > Variables.Cero)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Tica.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("0.000", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2));
                            }

                            if (item.tipDocVenta == "07" || item.tipDocVenta == "08")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(item.FechaRef).ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipDocVentaRef, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.SerieRef, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.NumeroRef, null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1));
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = "REGISTRO DE VENTAS DEL ";
            String NombrePestaña = "Ventas";
            DateTime per = dtpFecIni.Value.Date;
            DateTime perfinal = dtpFecFin.Value.Date;
            String TituloGeneral2 = per.Date.ToString("d") + " Al " + perfinal.Date.ToString("d");

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
                    Int32 InicioLinea = 5;
                    Int32 TotColumnas = 22;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 219, 219));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Regular));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
                    }

                    oHoja.Cells["A3"].Value = TituloGeneral2;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Regular));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
                    }

                    #endregion

                    #region Cabecera

                    oHoja.Column(1).Width = 17;
                    oHoja.Column(2).Width = 15;
                    oHoja.Column(3).Width = 15;
                    oHoja.Column(4).Width = 5;
                    oHoja.Column(5).Width = 8;
                    oHoja.Column(8).Width = 5;
                    oHoja.Column(9).Width = 18;
                    oHoja.Column(10).Width = 70;
                    oHoja.Column(11).Width = 15;
                    oHoja.Column(12).Width = 15;
                    oHoja.Column(13).Width = 10;
                    oHoja.Column(14).Width = 10;
                    oHoja.Column(15).Width = 15;
                    oHoja.Column(16).Width = 15;
                    oHoja.Column(17).Width = 15;
                    oHoja.Column(18).Width = 8;
                    oHoja.Column(19).Width = 15;
                    oHoja.Column(20).Width = 5;
                    oHoja.Column(21).Width = 8;
                    oHoja.Column(22).Width = 12;

                    oHoja.Row(5).Height = 30;
                    oHoja.Row(6).Height = 18;
                    oHoja.Row(7).Height = 18;

                    #region Primera Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[5, 1, 7, 1])
                    {
                        Rango.Merge = true;
                        Rango.Value = "COD. UNI. DE LA OPE.";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 2, 7, 2])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FECHA DE EMISION DEL DOC.";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.WrapText = true;
                        
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 3, 7, 3])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FECHA DE VENC. Y/O PAGO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.WrapText = true;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 4,5, 7])
                    {
                        Rango.Merge = true;
                        Rango.Value = "COMPROBANTE DE PAGO O DOCUMENTO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.WrapText = true;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 8, 5, 10])
                    {
                        Rango.Merge = true;
                        Rango.Value = "INFORMACION DEL CLIENTE";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 11, 7, 11])
                    {
                        Rango.Merge = true;
                        Rango.Value = "VALOR FACTURADO DE LA EXPORT.";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.WrapText = true;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 12, 7, 12])
                    {
                        Rango.Merge = true;
                        Rango.Value = "BASE IMPONIB. DE LA OPERAC. GRAVADA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.WrapText = true;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 13, 6, 14])
                    {
                        Rango.Merge = true;
                        Rango.Value = "IMPORTE TOTAL DE LA OPERACIÓN EXONERADA O INAFECTA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.WrapText = true;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 15, 7, 15])
                    {
                        Rango.Merge = true;
                        Rango.Value = "IGV Y/O IPM";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 16, 7, 16])
                    {
                        Rango.Merge = true;
                        Rango.Value = "OTROS CARGOS";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 17,7, 17])
                    {
                        Rango.Merge = true;
                        Rango.Value = "IMPORTE TOTAL DEL COMPROB. DE PAGO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.WrapText = true;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 18, 7, 18])
                    {
                        Rango.Merge = true;
                        Rango.Value = "TIPO DE CAMBIO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.WrapText = true;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 19, 6, 22])
                    {
                        Rango.Merge = true;
                        Rango.Value = "REFERENCIA DEL COMPROBANTE DE PAGO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    #endregion

                    InicioLinea++;

                    #region Segunda Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[6, 4, 7, 4])
                    {
                        Rango.Merge = true;
                        Rango.Value = "TIPO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 5, 7, 5])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Nº SERIE";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 6,6, 7])
                    {
                        Rango.Merge = true;
                        Rango.Value = "NUMERO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 8,6, 9])
                    {
                        Rango.Merge = true;
                        Rango.Value = "DOC. DE IDENTIDAD";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 10, 7, 10])
                    {
                        Rango.Merge = true;
                        Rango.Value = "APELLIDOS Y NOMBRES Ó RAZON SOCIAL";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 13, 7, 13])
                    {
                        Rango.Value = "EXONERADA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 14, 7, 14])
                    {
                      
                        Rango.Value = "INAFECTA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                    }

                    #endregion

                    InicioLinea++;

                    #region Tercera Linea Cabecera

                    oHoja.Cells[InicioLinea, 6].Value = "DEL";
                    oHoja.Cells[InicioLinea, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                    oHoja.Cells[InicioLinea, 7].Value = "AL";
                    oHoja.Cells[InicioLinea, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 7].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                    oHoja.Cells[InicioLinea, 8].Value = "TIPO";
                    oHoja.Cells[InicioLinea, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                    oHoja.Cells[InicioLinea, 9].Value = "NUMERO";
                    oHoja.Cells[InicioLinea, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                    oHoja.Cells[InicioLinea, 19].Value = "FECHA";
                    oHoja.Cells[InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 19].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 19].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                    oHoja.Cells[InicioLinea, 20].Value = "TIPO";
                    oHoja.Cells[InicioLinea, 20].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 20].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 20].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 20].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 20].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                    oHoja.Cells[InicioLinea, 21].Value = "SERIE";
                    oHoja.Cells[InicioLinea, 21].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 21].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 21].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 21].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 21].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                    oHoja.Cells[InicioLinea, 22].Value = "NUMERO";
                    oHoja.Cells[InicioLinea, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 22].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 22].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    oHoja.Cells[InicioLinea, 22].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                    #endregion

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #region Detalle

                    foreach (RegistroVentasE item in oListaRegistroVentas)
                    {
                        if (!item.RazonSocial.Contains("Totales Acumulados"))
                        {
                            lblExportar.Text = "Exportando " + item.Correlativo + " TD. " + item.tipDocVenta + " Doc. N° " + item.Numero;
                            lblExportar.Refresh();

                            oHoja.Cells[InicioLinea, 1].Value = item.Correlativo;
                            oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 2].Value = item.fecDocumento.Value.ToString("dd/MM/yyyy");
                            oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 3].Value = Convert.ToDateTime(item.fecVencimiento).ToString("d");
                            oHoja.Cells[InicioLinea, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 4].Value = item.tipDocVenta;
                            oHoja.Cells[InicioLinea, 5].Value = item.Serie;
                            oHoja.Cells[InicioLinea, 6].Value = item.Numero;
                            oHoja.Cells[InicioLinea, 7].Value = " ";
                            oHoja.Cells[InicioLinea, 8].Value = item.tipDocPersona;
                            oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 9].Value = item.numDocPersona;
                            oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 11].Value = Convert.ToDecimal(item.BaseExportacion);
                            oHoja.Cells[InicioLinea, 12].Value = Convert.ToDecimal(item.BaseImponible);
                            oHoja.Cells[InicioLinea, 13].Value = Convert.ToDecimal(item.BaseExonerada);
                            oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(item.BaseInafecta);
                            oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(item.Igv);
                            oHoja.Cells[InicioLinea, 16].Value = Convert.ToDecimal(item.OtrosTributos);
                            oHoja.Cells[InicioLinea, 17].Value = Convert.ToDecimal(item.Total);

                            if (item.idMoneda != "PEN")
                            {
                                oHoja.Cells[InicioLinea, 18].Value = Convert.ToDecimal(item.Tica);
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 18].Value = 0;
                            }
                          
                            if (item.tipDocVenta == "07" || item.tipDocVenta == "08")
                            {
                                oHoja.Cells[InicioLinea, 19].Value = Convert.ToDateTime(item.FechaRef).ToString("d");
                                oHoja.Cells[InicioLinea, 20].Value = item.tipDocVentaRef;
                                oHoja.Cells[InicioLinea, 21].Value = item.SerieRef;
                                oHoja.Cells[InicioLinea, 22].Value = item.NumeroRef;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 19].Value = " ";
                                oHoja.Cells[InicioLinea, 20].Value = " ";
                                oHoja.Cells[InicioLinea, 21].Value = " ";
                                oHoja.Cells[InicioLinea, 22].Value = " ";
                            }
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;

                            oHoja.Cells[InicioLinea, 10].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 11].Value = Convert.ToDecimal(item.BaseExportacion);
                            oHoja.Cells[InicioLinea, 12].Value = Convert.ToDecimal(item.BaseImponible);
                            oHoja.Cells[InicioLinea, 13].Value = Convert.ToDecimal(item.BaseExonerada);
                            oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(item.BaseInafecta);
                            oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(item.Igv);
                            oHoja.Cells[InicioLinea, 16].Value = Convert.ToDecimal(item.OtrosTributos);
                            oHoja.Cells[InicioLinea, 17].Value = Convert.ToDecimal(item.Total);
                        }

                        for (int i = 1; i <= 22; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                            if (i >= 11 && i <= 18)
                            {
                                oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                if (i == 18)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.000";
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                                }
                            }
                        }

                        InicioLinea++;
                    }

                    #endregion

                    //Ajustando el ancho de las columnas automaticamente
                    //oHoja.Cells.AutoFitColumns();

                    #region Propiedades del Excel

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
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

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

        void ExportarExcel2(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String TituloGeneral2 = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Registro Verificación Ventas ";

            if (dtpFecIni.Value.Date.Month == dtpFecFin.Value.Date.Month)
            {
                TituloGeneral2 = dtpFecIni.Value.Date.ToString("d") + " Al " + dtpFecFin.Value.Date.ToString("d")  + "   Expresado en " + cboMonedas.Text;
            }
            else
            {
                TituloGeneral2 = dtpFecIni.Value.Date.Month.ToString("mm") + " del " + dtpFecIni.Value.Date.Year.ToString("yyyy") + "   Expresado en " + cboMonedas.Text;
            }

            NombrePestaña = "Ventas";

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
                    Int32 InicioLinea = 5;
                    Int32 TotColumnas = 34;

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 219, 219));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Regular));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
                    }

                    oHoja.Cells["A3"].Value = TituloGeneral2;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Regular));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
                    }

                    oHoja.Column(1).Width = 10;
                    oHoja.Column(2).Width = 16;
                    oHoja.Column(3).Width = 11;
                    oHoja.Column(4).Width = 15;
                    oHoja.Column(5).Width = 15;
                    oHoja.Column(6).Width = 11;
                    oHoja.Column(7).Width = 12;
                    oHoja.Column(8).Width = 15;
                    oHoja.Column(9).Width = 11;
                    oHoja.Column(10).Width = 15;
                    oHoja.Column(11).Width = 20;
                    oHoja.Column(12).Width = 55;
                    oHoja.Column(13).Width = 15;
                    oHoja.Column(14).Width = 15;
                    oHoja.Column(15).Width = 15;
                    oHoja.Column(16).Width = 15;
                    oHoja.Column(17).Width = 15;
                    oHoja.Column(18).Width = 15;
                    oHoja.Column(19).Width = 15;
                    oHoja.Column(20).Width = 15;
                    oHoja.Column(21).Width = 15;
                    oHoja.Column(22).Width = 15;
                    oHoja.Column(23).Width = 15;
                    oHoja.Column(24).Width = 15;
                    oHoja.Column(25).Width = 7;
                    oHoja.Column(26).Width = 8;
                    oHoja.Column(27).Width = 20;
                    oHoja.Column(28).Width = 18;
                    oHoja.Column(29).Width = 18;
                    oHoja.Column(30).Width = 18;
                    oHoja.Column(31).Width = 18;
                    oHoja.Column(32).Width = 18;
                    oHoja.Column(33).Width = 18;
                    oHoja.Column(34).Width = 8;

                    oHoja.Row(6).Height = 59;

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = "PERIODO";
                    oHoja.Cells[InicioLinea, 2].Value = "NUMERO CORRELATIVO O CODIGO UNICO DE LA OPERACIÓN";
                    oHoja.Cells[InicioLinea, 3].Value = "SECUENCIA";
                    oHoja.Cells[InicioLinea, 4].Value = "FECHA DE EMISIÓN DEL COMPROBANTE DE PAGO O DOCUMENTO";
                    oHoja.Cells[InicioLinea, 5].Value = "FECHA DE VENCIMIENTO O FECHA DE PAGO";
                    oHoja.Cells[InicioLinea, 6].Value = "TIPO DE COMPROBANTE DE PAGO O DOCUMENTO";
                    oHoja.Cells[InicioLinea, 7].Value = "SERIE DE COMPROBANTE DE PAGO O DOCUMENTO";
                    oHoja.Cells[InicioLinea, 8].Value = "NUMERO DE COMPROBANTE DE PAGO O DOCUMENTO";
                    oHoja.Cells[InicioLinea, 9].Value = "PARA EFECTOS DEL REGISTRO DE TICKETS O CINTAS EMITIDOS POR MAQUINAS REGISTRADORAS";
                    oHoja.Cells[InicioLinea, 10].Value = "TIPO DOC. IDENTIDAD CLIENTE";
                    oHoja.Cells[InicioLinea, 11].Value = "NUMERO DOC. IDENTIDAD CLIENTE";
                    oHoja.Cells[InicioLinea, 12].Value = "APELLIDOS Y NOMBRES DENOMINACION O RAZÓN SOCIAL CLIENTE";
                    oHoja.Cells[InicioLinea, 13].Value = "VALOR FACTURADO DE LA EXPORTACION";
                    oHoja.Cells[InicioLinea, 14].Value = "BASE IMPONIBLE DE LA OPERACIÓN GRAVADA";
                    oHoja.Cells[InicioLinea, 15].Value = "DESCUENTO DE LA BASE IMPONIBLE ";
                    oHoja.Cells[InicioLinea, 16].Value = "IMPUESTO GRAL. A LAS VENTAS Y/O IMPUESTO DE PROMOCION MUNICIPAL";
                    oHoja.Cells[InicioLinea, 17].Value = "DCTO. DEL IMPUESTO GENERAL A LAS VENTAS Y/O IMPUESTO DE PROMOCION MUNICIPLA";
                    oHoja.Cells[InicioLinea, 18].Value = "IMPORTE TOTAL DELA OPERACIÓN EXONERADA";
                    oHoja.Cells[InicioLinea, 19].Value = "IMPORTE TOTAL DELA OPERACIÓN INAFECTA";
                    oHoja.Cells[InicioLinea, 20].Value = "IMPUESTO SELECTIVO AL CONSUMO";
                    oHoja.Cells[InicioLinea, 21].Value = "BASE IMPONIBLE DE LA OPERACION GRAVADA VENTAS ARROZ PILADO";
                    oHoja.Cells[InicioLinea, 22].Value = "IMPUESTO A LAS VENTAS ARROZ PILADO";
                    oHoja.Cells[InicioLinea, 23].Value = "OTROS TRIBUTOS Y CARGOS QUE NO FORMAN PARTE DE LA BASE IMPONIBLE";
                    oHoja.Cells[InicioLinea, 24].Value = "IMPORTE TOTAL DEL COMPROBANTE DE PAGO";
                    oHoja.Cells[InicioLinea, 25].Value = "MONEDA";
                    oHoja.Cells[InicioLinea, 26].Value = "TIPO DE CAMBIO";
                    oHoja.Cells[InicioLinea, 27].Value = "FECHA DE REF. DEL COMPROBANTE DE PAGO  O DOCUMENTO  MODIFICADO";
                    oHoja.Cells[InicioLinea, 28].Value = "TIPO DE REF. DEL COMPROBANTE DE PAGO  O DOCUMENTO MODIFICADO";
                    oHoja.Cells[InicioLinea, 29].Value = "SERIE DE REF. DEL COMPROBANTE DE PAGO  O DOCUMENTO MODIFICADO";
                    oHoja.Cells[InicioLinea, 30].Value = "NUMERO DE REF. DEL COMPROBANTE DE PAGO  O DOCUMENTO MODIFICADO";
                    oHoja.Cells[InicioLinea, 31].Value = "IDENTIFICACION DEL CONTRATO O PROYECTO (JOINT VENTURES)";
                    oHoja.Cells[InicioLinea, 32].Value = "ERROR 1: INCONSISTENCIA EN EL TIPO DE CAMBIO";
                    oHoja.Cells[InicioLinea, 33].Value = "INDICADOR DE COMPROBANTES DE PAGO CANCELADOS CON MEDIOS DE PAGO";
                    oHoja.Cells[InicioLinea, 34].Value = "ESTADO";

                    for (int i = 1; i <= 34; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.WrapText = true;
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    foreach (RegistroVentasE item in (from x in oListaRegistroVentas where x.RazonSocial != "       Totales Acumulados >>>>>>>>>>" select x).ToList())
                    {
                        if (item.fecDocumento != null && item.tipDocVenta != null && item.tipDocPersona != null)
                        {
                            lblExportar.Text = "Exportando " + item.Correlativo + " TD. " + item.tipDocVenta + " Doc. N° " + item.Numero;
                            lblExportar.Refresh();

                            oHoja.Cells[InicioLinea, 1].Value = item.Periodo;
                            oHoja.Cells[InicioLinea, 2].Value = item.Correlativo;
                            oHoja.Cells[InicioLinea, 3].Value = item.PrimerDigito;
                            oHoja.Cells[InicioLinea, 4].Value = item.fecDocumento.Value.ToString("dd/MM/yyyy");
                            oHoja.Cells[InicioLinea, 5].Value = item.fecVencimiento.Value.ToString("dd/MM/yyyy");
                            oHoja.Cells[InicioLinea, 6].Value = item.tipDocVenta;
                            String Serie = DevolverSerie(item.tipDocVenta, item.Serie);
                            oHoja.Cells[InicioLinea, 7].Value = Serie;
                            oHoja.Cells[InicioLinea, 8].Value = item.Numero;
                            oHoja.Cells[InicioLinea, 9].Value = String.Empty;
                            oHoja.Cells[InicioLinea, 10].Value = item.tipDocPersona;
                            oHoja.Cells[InicioLinea, 11].Value = item.numDocPersona;
                            oHoja.Cells[InicioLinea, 12].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 13].Value = item.BaseExportacion;
                            oHoja.Cells[InicioLinea, 14].Value = item.BaseImponible;
                            oHoja.Cells[InicioLinea, 15].Value = item.dctoBaseImponible;
                            oHoja.Cells[InicioLinea, 16].Value = item.Igv;
                            oHoja.Cells[InicioLinea, 17].Value = item.dsctoIgv;
                            oHoja.Cells[InicioLinea, 18].Value = item.BaseExonerada;
                            oHoja.Cells[InicioLinea, 19].Value = item.BaseInafecta;
                            oHoja.Cells[InicioLinea, 20].Value = item.Isc;
                            oHoja.Cells[InicioLinea, 21].Value = item.BaseImponibleIvap;
                            oHoja.Cells[InicioLinea, 22].Value = item.Ivap;
                            oHoja.Cells[InicioLinea, 23].Value = item.OtrosTributos;
                            oHoja.Cells[InicioLinea, 24].Value = item.Total;
                            oHoja.Cells[InicioLinea, 25].Value = item.idMoneda;
                            oHoja.Cells[InicioLinea, 26].Value = item.Tica;

                            if (item.FechaRef != null)
                            {
                                oHoja.Cells[InicioLinea, 27].Value = item.FechaRef.Value.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 27].Value = " ";
                            }

                            oHoja.Cells[InicioLinea, 28].Value = item.tipDocVentaRef;
                            oHoja.Cells[InicioLinea, 29].Value = item.SerieRef;
                            oHoja.Cells[InicioLinea, 30].Value = item.NumeroRef;
                            oHoja.Cells[InicioLinea, 31].Value = item.Identificacion;
                            oHoja.Cells[InicioLinea, 32].Value = item.Inconsistencia;
                            oHoja.Cells[InicioLinea, 33].Value = item.idMedioPago;
                            oHoja.Cells[InicioLinea, 34].Value = item.Estado;

                            for (int i = 1; i <= 34; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                                if (i >= 13 && i <= 24)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                                }

                                if (i == 26)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.000";
                                }
                            }

                            InicioLinea++;
                        }
                    }

                    #region Propiedades del Excel

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
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

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

        void ExportarExcel3(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String TituloGeneral2 = String.Empty;
            String NombrePestaña = String.Empty;

            DateTime per;
            DateTime perfinal;

            per = dtpFecIni.Value.Date;
            perfinal = dtpFecFin.Value.Date;

            TituloGeneral = "REGISTRO DE VENTAS PARA IMPORTAR DEL ";

            TituloGeneral2 = per.Date.ToString("d") + " Al " + perfinal.Date.ToString("d");

            NombrePestaña = "Ventas";

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
                    Int32 InicioLinea = 5;
                    Int32 TotColumnas = 27;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        //Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 219, 219));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Regular));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
                    }

                    oHoja.Cells["A3"].Value = TituloGeneral2;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Regular));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242));
                    }

                    #endregion

                    #region Cabecera

                    #region Primera Linea Cabecera

                    oHoja.Column(1).Width = 7;
                    oHoja.Column(2).Width = 7;
                    oHoja.Column(3).Width = 11;
                    oHoja.Column(4).Width = 12;
                    oHoja.Column(5).Width = 15;
                    oHoja.Column(6).Width = 15;
                    //oHoja.Column(4).Width = 15;
                    //oHoja.Column(5).Width = 20;
                    //oHoja.Column(6).Width = 20;
                    //oHoja.Column(7).Width = 20;
                    oHoja.Column(7).Width = 5;
                    oHoja.Column(8).Width = 10;
                    oHoja.Column(9).Width = 12;
                    oHoja.Column(10).Width = 7;
                    oHoja.Column(11).Width = 8;
                    oHoja.Column(12).Width = 15;
                    oHoja.Column(13).Width = 70;
                    oHoja.Column(14).Width = 15;
                    oHoja.Column(15).Width = 15;
                    oHoja.Column(16).Width = 15;
                    oHoja.Column(17).Width = 15;
                    oHoja.Column(18).Width = 20;
                    oHoja.Column(19).Width = 20;
                    oHoja.Column(20).Width = 20;
                    oHoja.Column(21).Width = 20;
                    oHoja.Column(22).Width = 20;
                    using (ExcelRange Rango = oHoja.Cells[5, 1, 7, 1])
                    {
                        Rango.Merge = true;
                        Rango.Value = "DIARIO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 2, 7, 2])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FILE";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 3, 7, 3])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FECHA OPERACION";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 4, 7, 4])
                    {
                        Rango.Merge = true;
                        Rango.Value = "VOUCHER";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 5, 7, 5])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FECHA DE EMISION DEL DOC.";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 6, 7, 6])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FECHA DE VENC. Y/O PAGO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 7, 5, 10])
                    {
                        Rango.Merge = true;
                        Rango.Value = "COMPROBANTE DE PAGO O DOCUMENTO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 11, 5, 13])
                    {
                        Rango.Merge = true;
                        Rango.Value = "INFORMACION DEL CLIENTE";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 14, 7, 14])
                    {
                        Rango.Merge = true;
                        Rango.Value = "VALOR FACTURADO DE LA EXPORT.";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 15, 7, 15])
                    {
                        Rango.Merge = true;
                        Rango.Value = "BASE IMPONIB. DE LA OPERAC. GRAVADA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 16, 6, 17])
                    {
                        Rango.Merge = true;
                        Rango.Value = "IMPORTE TOTAL DE LA OPERACIÓN EXONERADA O INAFECTA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;


                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 18, 7, 18])
                    {
                        Rango.Merge = true;
                        Rango.Value = "IGV Y/O IPM";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 19, 7, 19])
                    {
                        Rango.Merge = true;
                        Rango.Value = "OTROS CARGOS";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 20, 7, 20])
                    {
                        Rango.Merge = true;
                        Rango.Value = "IMPORTE TOTAL DEL COMPROB. DE PAGO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 21, 7, 21])
                    {
                        Rango.Merge = true;
                        Rango.Value = "MONEDA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 22, 7, 22])
                    {
                        Rango.Merge = true;
                        Rango.Value = "TIPO DE CAMBIO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 23, 6, 26])
                    {
                        Rango.Merge = true;
                        Rango.Value = "REFERENCIA DEL COMPROBANTE DE PAGO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[5, 27, 7, 27])
                    {
                        Rango.Merge = true;
                        Rango.Value = "VTA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    #endregion

                    InicioLinea++;

                    #region Segunda Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[6, 7, 7, 7])
                    {
                        Rango.Merge = true;
                        Rango.Value = "TIPO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 8, 7, 8])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Nº SERIE";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 9, 6, 10])
                    {
                        Rango.Merge = true;
                        Rango.Value = "NUMERO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 11, 6, 12])
                    {
                        Rango.Merge = true;
                        Rango.Value = "DOC. DE IDENTIDAD";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 13, 7, 13])
                    {
                        Rango.Merge = true;
                        Rango.Value = "APELLIDOS Y NOMBRES Ó RAZON SOCIAL";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 16, 7, 16])
                    {

                        Rango.Value = "EXONERADA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    using (ExcelRange Rango = oHoja.Cells[6, 17, 7, 17])
                    {

                        Rango.Value = "INAFECTA";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }


                    #endregion

                    InicioLinea++;

                    #region Tercera Linea Cabecera

                    oHoja.Cells[InicioLinea, 9].Value = "DEL";
                    oHoja.Cells[InicioLinea, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 9].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 10].Value = "AL";
                    oHoja.Cells[InicioLinea, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 10].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 10].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 10].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 11].Value = "TIPO";
                    oHoja.Cells[InicioLinea, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 11].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 11].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 12].Value = "NUMERO";
                    oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 23].Value = "FECHA";
                    oHoja.Cells[InicioLinea, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 23].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 23].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 23].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 24].Value = "TIPO";
                    oHoja.Cells[InicioLinea, 24].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 24].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 24].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 24].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 24].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 25].Value = "SERIE";
                    oHoja.Cells[InicioLinea, 25].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 25].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 25].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 25].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    oHoja.Cells[InicioLinea, 26].Value = "NUMERO";
                    oHoja.Cells[InicioLinea, 26].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 26].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                    oHoja.Cells[InicioLinea, 26].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 26].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Cells[InicioLinea, 26].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;

                    #endregion

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #region Detalle

                    foreach (RegistroVentasE item in oListaRegistroVentas)
                    {
                        if (!item.RazonSocial.Contains("Totales Acumulados"))
                        {
                            lblExportar.Text = "Exportando " + item.Correlativo + " TD. " + item.tipDocVenta + " Doc. N° " + item.Numero;
                            lblExportar.Refresh();

                            oHoja.Cells[InicioLinea, 1].Value = item.Diario;
                            oHoja.Cells[InicioLinea, 2].Value = item.NumFile;
                            oHoja.Cells[InicioLinea, 3].Value = item.FecOperacion;
                            oHoja.Cells[InicioLinea, 3].Value = item.fecDocumento.Value.ToString("dd/MM/yyyy");
                            oHoja.Cells[InicioLinea, 4].Value = item.Voucher;
                            oHoja.Cells[InicioLinea, 1, InicioLinea,4].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 5].Value = item.fecDocumento.Value.ToString("dd/MM/yyyy");
                            oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 6].Value = Convert.ToDateTime(item.fecVencimiento).ToString("d");
                            oHoja.Cells[InicioLinea, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 7].Value = item.tipDocVenta;
                            oHoja.Cells[InicioLinea, 8].Value = item.Serie;
                            oHoja.Cells[InicioLinea, 9].Value = item.Numero;
                            oHoja.Cells[InicioLinea, 10].Value = " ";
                            oHoja.Cells[InicioLinea, 11].Value = item.tipDocPersona;
                            oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 12].Value = item.numDocPersona;
                            oHoja.Cells[InicioLinea, 13].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(item.BaseExportacion);

                            oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(item.BaseImponible);
                            oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 16].Value = Convert.ToDecimal(item.BaseExonerada);
                            oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 17].Value = Convert.ToDecimal(item.BaseInafecta);
                            oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 18].Value = Convert.ToDecimal(item.Igv);
                            oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 19].Value = Convert.ToDecimal(item.OtrosTributos);
                            oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 20].Value = Convert.ToDecimal(item.Total);

                            String Mon = string.Empty;

                            if (item.Moneda == Variables.Soles)
                            {
                                Mon = "EXPRESADO EN SOLES";
                            }
                            else
                            {
                                Mon = "EXPRESADO EN DOLARES";
                            }

                            oHoja.Cells[InicioLinea, 21].Value = Mon;
                            oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 22].Style.Numberformat.Format = "##0.000";

                            if (item.idMoneda != "PEN")
                            {
                                oHoja.Cells[InicioLinea, 22].Value = Convert.ToDecimal(item.Tica);
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 22].Value = 0;
                            }

                            String VTA = String.Empty;

                            if (item.RazonSocial != "ANULADO")
                            {
                                 VTA = "CONT";
                                oHoja.Cells[InicioLinea, 27].Value = VTA;
                            }
                            else
                            {
                                VTA = "ANUL";
                                oHoja.Cells[InicioLinea, 27].Value = VTA;
                            }

                            if (item.tipDocVenta == "07" || item.tipDocVenta == "08")
                            {
                                oHoja.Cells[InicioLinea, 23].Value = Convert.ToDateTime(item.FechaRef).ToString("d");
                                oHoja.Cells[InicioLinea, 24].Value = item.tipDocVentaRef;
                                oHoja.Cells[InicioLinea, 25].Value = item.SerieRef;
                                oHoja.Cells[InicioLinea, 26].Value = item.NumeroRef;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 23].Value = " ";
                                oHoja.Cells[InicioLinea, 24].Value = " ";
                                oHoja.Cells[InicioLinea, 25].Value = " ";
                                oHoja.Cells[InicioLinea, 26].Value = " ";
                            }
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;

                            oHoja.Cells[InicioLinea, 13].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(item.BaseExportacion);
                            oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(item.BaseImponible);
                            oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 16].Value = Convert.ToDecimal(item.BaseExonerada);
                            oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 17].Value = Convert.ToDecimal(item.BaseInafecta);
                            oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 18].Value = Convert.ToDecimal(item.Igv);
                            oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 19].Value = Convert.ToDecimal(item.OtrosTributos);
                            oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 20].Value = Convert.ToDecimal(item.Total);
                        }

                        InicioLinea++;
                    }

                    #endregion

                    //Ajustando el ancho de las columnas automaticamente
                    //oHoja.Cells.AutoFitColumns();

                    #region Propiedades del Excel

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
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

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

        String DevolverSerie(String tipDocVenta, String SerieTemp)
        {
            String SerieDevuelta = String.Empty;

            if (!String.IsNullOrEmpty(SerieTemp))
            {
                if (Global.EsNumero(SerieTemp.Substring(0, 1)))
                {
                    if (tipDocVenta == "01" || tipDocVenta == "03" || tipDocVenta == "04" || tipDocVenta == "06" || tipDocVenta == "07" || tipDocVenta == "08"||
                        tipDocVenta == "34" || tipDocVenta == "35" || tipDocVenta == "36" || tipDocVenta == "48" || tipDocVenta == "56")
                    {
                        if (SerieTemp.Length <= 4)
                        {
                            SerieDevuelta = String.Format("{0:0000}", Convert.ToInt32(SerieTemp));
                        }
                        else
                        {
                            SerieDevuelta = Global.Derecha(SerieTemp, 4);
                        }
                    }
                    else if (tipDocVenta == "02" || tipDocVenta == "09" || tipDocVenta == "10" || tipDocVenta == "20" || tipDocVenta == "22" || tipDocVenta == "31" ||
                            tipDocVenta == "33" || tipDocVenta == "40" || tipDocVenta == "41" || tipDocVenta == "46" || tipDocVenta == "50" || tipDocVenta == "51" ||
                            tipDocVenta == "52" || tipDocVenta == "53" || tipDocVenta == "54" || tipDocVenta == "89" || tipDocVenta == "91" || tipDocVenta == "96" ||
                            tipDocVenta == "97" || tipDocVenta == "98")
                    {
                        SerieDevuelta = String.Empty;
                    }
                    else
                    {
                        SerieDevuelta = SerieTemp.Trim();
                    }
                }
                else
                {
                    SerieDevuelta = SerieTemp.Trim();
                }
            }

            return SerieDevuelta;
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Generando el PDF
                if (tipoProceso == 1)
                {
                    DateTime fecInicial = dtpFecIni.Value.Date;
                    DateTime fecFin = dtpFecFin.Value.Date;
                    String idMoneda = cboMonedas.SelectedValue.ToString();
                    Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);

                    //Obteniendo los datos de la BD
                    lblProcesando.Text = "Obteniendo el Registro de Ventas...";
                    oListaRegistroVentas = AgenteContabilidad.Proxy.RegistroDeVentasLe(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, fecInicial, fecFin, idMoneda);

                    if (oListaRegistroVentas.Count > Variables.Cero)
                    {
                        RegistroVentasE oRegVentasTotal = new RegistroVentasE()
                        {
                            fecDocumento = null,
                            fecVencimiento = null,
                            RazonSocial = "       Totales Acumulados >>>>>>>>>>",
                            BaseExportacion = (from x in oListaRegistroVentas select x.BaseExportacion).Sum(),
                            BaseImponible = (from x in oListaRegistroVentas select x.BaseImponible).Sum(),
                            BaseExonerada = (from x in oListaRegistroVentas select x.BaseExonerada).Sum(),
                            BaseInafecta = (from x in oListaRegistroVentas select x.BaseInafecta).Sum(),
                            Igv = (from x in oListaRegistroVentas select x.Igv).Sum(),
                            OtrosTributos = (from x in oListaRegistroVentas select x.OtrosTributos).Sum(),
                            Total = (from x in oListaRegistroVentas select x.Total).Sum(),
                        };

                        oListaRegistroVentas.Add(oRegVentasTotal);
                    }

                    lblProcesando.Text = "Armando el Reporte...";

                    ConvertirApdf();
                }
                else
                {
                    if (Formato == 1)
                    {
                        ExportarExcel(RutaGeneral);
                    }
                    if (Formato == 2)
                    {
                        ExportarExcel2(RutaGeneral);
                    }
                    if (Formato == 3)
                    {
                        ExportarExcel3(RutaGeneral);
                    }
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
            Marque = String.Empty;
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;
            btPle.Enabled = true;
            btPdb.Enabled = true;
            btExportar.Enabled = true;
            timer.Enabled = false;

            if (e.Error != null)
            {
                Global.MensajeError(String.Format("Ha ocurrido la excepción: {0}", e.Error.Message));
            }
            else
            {
                //Mostrando el reporte en un web browser
                if (tipoProceso == 1)
                {
                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        tipoProceso = 0;
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Exportación Exitosa.");
                    lblExportar.Text = String.Empty;
                }
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        #endregion

        #region Procesos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaRegistroVentas.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String mes = dtpFecIni.Value.ToString("MM");
                String anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                if (Formato == 1) //Formato Normal
                {
                    RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Ventas Periodo " + mes + "-" + anio, "Archivos Excel (*.xlsx)|*.xlsx");
                }
                if (Formato == 2) //Formato PLE
                {
                    RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Ventas PLE Periodo " + mes + "-" + anio, "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (Formato == 3) //Formato PLE
                {
                    RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Ventas Para Importar Del Periodo " + mes + "-" + anio, "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = Variables.Cero;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Importando el Registro de Ventas a Excel...";
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

        #region Eventos

        private void frmReporteRegistroVentasLe_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

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
                tipoProceso = 1;
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                btPle.Enabled = false;
                btPdb.Enabled = false;
                btExportar.Enabled = false;
                oListaRegistroVentas = null;
                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                btPle.Enabled = true;
                btPdb.Enabled = true;
                btExportar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void btPle_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                if (oListaRegistroVentas.Count == Variables.Cero || oListaRegistroVentas == null)
                {
                    Global.MensajeFault("No hay datos para exportar al Libro Electrónico.");
                    return;
                }

                if (Global.MensajeConfirmacion("Desea generar el Archivo del Registro de Ventas para el PLE") == DialogResult.No)
                {
                    return;
                }

                #endregion Validaciones

                String NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + oListaRegistroVentas[0].Periodo.Substring(0, 4) + oListaRegistroVentas[0].Periodo.Substring(4, 2) + "00140100001111";
                String RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    #region Exportacion a un archivo de texto

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        StringBuilder Cadena = new StringBuilder();
                        String tipDocIdentidad = String.Empty;
                        String numDocIdentidad = String.Empty;
                        String RazonSocial = String.Empty;
                        String fecDocumento = String.Empty;
                        String fecVencimiento = String.Empty;
                        String tipDocVentaRef = String.Empty;
                        String Serie = String.Empty;
                        String SerieRef = String.Empty;
                        String NumeroRef = String.Empty;
                        String fecRef = String.Empty;
                        String Moneda = String.Empty;

                        foreach (RegistroVentasE item in oListaRegistroVentas)
                        {
                            if (item.fecDocumento != null && item.tipDocVenta != null && item.tipDocPersona != null)
                            {
                                if (item.Estado == "2")
                                {
                                    fecDocumento = String.Empty;
                                }
                                else
                                {
                                    fecDocumento = item.fecDocumento.Value.ToString("dd/MM/yyyy");
                                    fecVencimiento = String.Empty;

                                    if (item.tipDocVenta == "14")
                                    {
                                        fecVencimiento = Convert.ToDateTime(item.fecVencimiento).ToString("dd/MM/yyyy");

                                        if (String.IsNullOrEmpty(fecVencimiento))
                                        {
                                            throw new Exception(String.Format("Para los Recibos de Servicios Públicos es obligatorio que tengan fecha de vencimiento"));
                                        }
                                    }
                                }

                                Serie = DevolverSerie(item.tipDocVenta, item.Serie);

                                if (item.Estado != "2")
                                {
                                    if (item.tipDocVenta == "01" || item.tipDocVenta == "02" || item.tipDocVenta == "03" ||
                                        item.tipDocVenta == "04" || item.tipDocVenta == "09" || item.tipDocVenta == "10" ||
                                        item.tipDocVenta == "17" || item.tipDocVenta == "20" || item.tipDocVenta == "21" ||
                                        item.tipDocVenta == "22" || item.tipDocVenta == "24" || item.tipDocVenta == "25" ||
                                        item.tipDocVenta == "27" || item.tipDocVenta == "29" || item.tipDocVenta == "31" ||
                                        item.tipDocVenta == "32" || item.tipDocVenta == "40" || item.tipDocVenta == "50" ||
                                        item.tipDocVenta == "52" || item.tipDocVenta == "53" || item.tipDocVenta == "54" ||
                                        item.tipDocVenta == "07" || item.tipDocVenta == "08" || item.tipDocVenta == "12")
                                    {
                                        tipDocIdentidad = item.tipDocPersona;
                                        numDocIdentidad = item.numDocPersona;
                                        RazonSocial = item.RazonSocial;
                                    }
                                    else
                                    {
                                        tipDocIdentidad = String.Empty;
                                        numDocIdentidad = String.Empty;
                                        RazonSocial = String.Empty;
                                    }
                                }
                                else
                                {
                                    tipDocIdentidad = String.Empty;
                                    numDocIdentidad = String.Empty;
                                    RazonSocial = String.Empty;
                                }

                                if (item.Estado != "2")
                                {
                                    if (item.tipDocVenta == "07" || item.tipDocVenta == "08" || item.tipDocVenta == "87" || item.tipDocVenta == "88")
                                    {
                                        fecRef = Convert.ToDateTime(item.FechaRef).ToString("dd/MM/yyyy");
                                        tipDocVentaRef = item.tipDocVentaRef;
                                        SerieRef = DevolverSerie(item.tipDocVentaRef, item.SerieRef);
                                        NumeroRef = item.NumeroRef;
                                    }
                                    else
                                    {
                                        fecRef = "01/01/0001";
                                        tipDocVentaRef = String.Empty;
                                        SerieRef = String.Empty;
                                        NumeroRef = String.Empty;
                                    }
                                }
                                else
                                {
                                    fecRef = "01/01/0001";
                                    tipDocVentaRef = String.Empty;
                                    SerieRef = String.Empty;
                                    NumeroRef = String.Empty;
                                }
                                //if (item.idMoneda == Variables.MonedaSoles)
                                //{
                                //    Moneda = "PEN";
                                //}
                                //else
                                //{
                                //    Moneda = "USD";
                                //}
                                Cadena.Append(item.Periodo).Append("|").Append(item.Correlativo).Append("|").Append(item.PrimerDigito).Append("|").Append(fecDocumento).Append("|");
                                Cadena.Append(fecVencimiento).Append("|").Append(item.tipDocVenta).Append("|").Append(Serie).Append("|").Append(item.Numero).Append("|").Append(String.Empty).Append("|");
                                Cadena.Append(tipDocIdentidad).Append("|").Append(numDocIdentidad).Append("|").Append(RazonSocial).Append("|").Append(item.BaseExportacion.ToString("#####0.00")).Append("|");
                                Cadena.Append(item.BaseImponible.ToString("#####0.00")).Append("|").Append(item.dctoBaseImponible.ToString("#####0.00")).Append("|").Append(item.Igv.ToString("#####0.00")).Append("|");
                                Cadena.Append(item.dsctoIgv.ToString("#####0.00")).Append("|").Append(item.BaseExonerada.ToString("#####0.00")).Append("|").Append(item.BaseInafecta.ToString("#####0.00")).Append("|");
                                Cadena.Append(item.Isc.ToString("#####0.00")).Append("|").Append(item.BaseImponibleIvap.ToString("#####0.00")).Append("|").Append(item.Ivap.ToString("#####0.00")).Append("|");
                                Cadena.Append(item.OtrosTributos.ToString("#####0.00")).Append("|").Append(item.Total.ToString("#####0.00")).Append("|").Append(item.idMoneda).Append("|");
                                Cadena.Append(Convert.ToDecimal(item.Tica).ToString("##0.000")).Append("|").Append(fecRef).Append("|").Append(tipDocVentaRef).Append("|").Append(SerieRef).Append("|");
                                Cadena.Append(NumeroRef).Append("|").Append(item.Identificacion).Append("|").Append(item.Inconsistencia).Append("|").Append(item.idMedioPago).Append("|").Append(item.Estado).Append("|");


                                oSw.WriteLine(Cadena.ToString());
                                Cadena.Clear(); 
                            }
                        }

                        RutaArchivoTexto = String.Empty;
                    } 

                    #endregion

                    Global.MensajeComunicacion("Se generó el archivo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmReporteRegistroVentasLe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void btPdb_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaRegistroVentas != null)
                {
                    if (oListaRegistroVentas.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar el Registro de Ventas al PDB.");
                        return;
                    }
                }
                else
                {
                    Global.MensajeFault("No hay datos para exportar el Registro de Ventas al PDB.");
                    return;
                }

                if (Global.MensajeConfirmacion("Desea generar el archivo para el PDB") == DialogResult.No)
                {
                    return;
                }

                String NombreArchivo1 = "V" + VariablesLocales.SesionUsuario.Empresa.RUC + oListaRegistroVentas[0].Periodo.Substring(0, 4) + oListaRegistroVentas[0].Periodo.Substring(4, 2);
                String NombreArchivo2 = VariablesLocales.SesionUsuario.Empresa.RUC + oListaRegistroVentas[0].Periodo.Substring(0, 4) + oListaRegistroVentas[0].Periodo.Substring(4, 2) + ".exp";
                
                String RutaArchivoTexto1 = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo1, "Documentos de Texto (*.txt)|*.txt");
                String RutaArchivoTexto2 = RutaArchivoTexto1.Replace(NombreArchivo1 + ".txt", NombreArchivo2);

                if (!String.IsNullOrEmpty(RutaArchivoTexto1))
                {
                    #region Borrando los archivos si existieran
                    
                    if (File.Exists(RutaArchivoTexto1))
                    {
                        File.Delete(RutaArchivoTexto1);
                    }

                    if (File.Exists(RutaArchivoTexto2))
                    {
                        File.Delete(RutaArchivoTexto2);
                    } 

                    #endregion

                    #region Exportacion a un archivo de texto

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto1, true, Encoding.Default))
                    {
                        #region Variables

                        StringBuilder Cadena = new StringBuilder();
                        String tipVenta = "02";
                        String Serie = String.Empty;
                        String Moneda = String.Empty;
                        String tipPersona = String.Empty;
                        String RazonSocial = String.Empty;
                        String CodigoDestino = String.Empty;
                        String BaseImponible = String.Empty;
                        String MontoIsc = "0.00";
                        String MontoIgv = "0.00";
                        String MontoOtros = "0.00";

                        #region Variables Percepcion

                        String indPercepcion = "0";
                        String TasaPercepcion = String.Empty;
                        String serPercepcion = String.Empty;
                        String numPercepcion = String.Empty;

                        #endregion

                        #region Variables para la referencia

                        String tipDocumentoRef = String.Empty;
                        String serDocumentoRef = String.Empty;
                        String numDocumentoRef = String.Empty;
                        String fecDocumentoRef = String.Empty;
                        String BaseImponibleRef = String.Empty;
                        String IgvRef = String.Empty;

                        #endregion 

                        #endregion

                        using (StreamWriter oSw2 = new StreamWriter(RutaArchivoTexto2, true, Encoding.Default))
                        {
                            List<RegistroVentasE> oListaPdb = null;

                            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Solo para aldeasa
                            {
                                oListaPdb = new List<RegistroVentasE>(from x in oListaRegistroVentas
                                                                      where x.Serie != "0050" && x.Serie != "050"
                                                                         && x.Serie != "0032" && x.Serie != "032"
                                                                         && x.Serie != "0033" && x.Serie != "033"
                                                                         && x.Serie != "0034" && x.Serie != "034"
                                                                         && x.Serie != "0035" && x.Serie != "035"
                                                                         && x.Serie != "0036" && x.Serie != "036"
                                                                      select x).ToList();
                            }
                            else
                            {
                                oListaPdb = new List<RegistroVentasE>(oListaRegistroVentas);                                                                                            
                            }

                            foreach (RegistroVentasE item in oListaPdb)
                            {
                                if (item.fecDocumento != null && !String.IsNullOrEmpty(item.tipDocVenta) && !String.IsNullOrEmpty(item.tipDocPersona) && item.Estado != "2")
                                {
                                    Serie = DevolverSerie(item.tipDocVenta, item.Serie);

                                    #region Tipo Persona

                                    if (item.tipDocPersona == "6")
                                    {
                                        tipPersona = "02";
                                    }
                                    else if (item.tipDocPersona == "7")
                                    {
                                        tipPersona = "03";
                                    }
                                    else if (item.tipDocPersona == "0")
                                    {
                                        tipPersona = "03";
                                    }
                                    else
                                    {
                                        throw new Exception(String.Format("Tipo de documento de la persona es desconocido. Revisar la linea con correlativo {0}", item.Correlativo));
                                    }

                                    #endregion

                                    #region Otros - Razon Social, Moneda y el codigo del destino

                                    if (item.RazonSocial.Length > 40)
                                    {
                                        RazonSocial = item.RazonSocial.Substring(0, 40);
                                    }
                                    else
                                    {
                                        RazonSocial = item.RazonSocial;
                                    }

                                    if (item.idMoneda == "PEN")
                                    {
                                        Moneda = "1";
                                    }
                                    else if (item.idMoneda == "USD")
                                    {
                                        Moneda = "2";
                                    }

                                    if (item.csIgv)
                                    {
                                        CodigoDestino = "1";
                                        BaseImponible = Math.Abs(item.BaseImponible).ToString("#####0.00");
                                        MontoIgv = Math.Abs(item.Igv).ToString("#####0.00");
                                    }
                                    else
                                    {
                                        CodigoDestino = "2";
                                        BaseImponible = Math.Abs(item.BaseExportacion).ToString("#####0.00");
                                        MontoIgv = String.Empty;
                                    }

                                    #endregion

                                    #region Referencia

                                    if (item.tipDocVenta == "07" || item.tipDocVenta == "08" || item.tipDocVenta == "97" || item.tipDocVenta == "98")
                                    {
                                        tipDocumentoRef = item.tipDocVentaRef;
                                        serDocumentoRef = DevolverSerie(item.tipDocVentaRef, item.SerieRef);
                                        numDocumentoRef = item.NumeroRef;
                                        fecDocumentoRef = Convert.ToDateTime(item.FechaRef).ToString("dd/MM/yyyy");
                                        BaseImponibleRef = Math.Abs(item.Total).ToString("#####0.00");

                                        if (CodigoDestino == "1")
                                        {
                                            IgvRef = Math.Abs(item.Igv).ToString("#####0.00");
                                        }
                                        else
                                        {
                                            IgvRef = String.Empty;
                                        }
                                    }
                                    else
                                    {
                                        tipDocumentoRef = String.Empty;
                                        serDocumentoRef = String.Empty;
                                        numDocumentoRef = String.Empty;
                                        fecDocumentoRef = String.Empty;
                                        BaseImponibleRef = String.Empty;
                                        IgvRef = String.Empty;
                                    }

                                    #endregion

                                    String tipDocPersona = item.tipDocPersona;

                                    if (item.tipDocPersona == "0")
                                    {
                                        tipDocPersona = "7";
                                    }


                                    if (item.tipDocVenta == "01" || item.tipDocVenta == "03" || item.tipDocVenta == "07" || item.tipDocVenta == "08" || item.tipDocVenta == "12" ||
                                        item.tipDocVenta == "34" || item.tipDocVenta == "35" || item.tipDocVenta == "36" || item.tipDocVenta == "37")
                                    {
                                        Cadena.Append(tipVenta).Append("|").Append(item.tipDocVenta).Append("|").Append(item.fecDocumento.Value.ToString("dd/MM/yyyy")).Append("|").Append(Serie).Append("|");
                                        Cadena.Append(item.Numero).Append("|").Append(tipPersona).Append("|").Append(tipDocPersona).Append("|").Append(item.numDocPersona).Append("|");
                                        Cadena.Append(RazonSocial).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|").Append(String.Empty).Append("|");
                                        Cadena.Append(String.Empty).Append("|").Append(Moneda).Append("|").Append(CodigoDestino).Append("|").Append("1").Append("|").Append(BaseImponible).Append("|");
                                        Cadena.Append(MontoIsc).Append("|").Append(MontoIgv).Append("|").Append(MontoOtros).Append("|").Append(indPercepcion).Append("|").Append(TasaPercepcion).Append("|");
                                        Cadena.Append(serPercepcion).Append("|").Append(numPercepcion).Append("|").Append(tipDocumentoRef).Append("|").Append(serDocumentoRef).Append("|");
                                        Cadena.Append(numDocumentoRef).Append("|").Append(fecDocumentoRef).Append("|").Append(BaseImponibleRef).Append("|").Append(IgvRef).Append("|");

                                        oSw.WriteLine(Cadena.ToString());
                                        Cadena.Clear();

                                        Cadena.Append(item.Periodo.Substring(0, 4) + item.Periodo.Substring(4, 2)).Append("|").Append(item.tipDocVenta).Append("|").Append(Serie).Append("|").Append(item.Numero);
                                        Cadena.Append("|10|");
                                        oSw2.WriteLine(Cadena.ToString());
                                    }
                                    else
                                    {
                                        throw new Exception(String.Format("El tipo de comprobante {0} no esta permitido para la Venta Externa", item.tipDocVenta));
                                    }  
                                }
                                
                                
                                Cadena.Clear();
                            }
                        }

                        RutaArchivoTexto1 = String.Empty;
                        RutaArchivoTexto2 = String.Empty;
                    }

                    #endregion

                    Global.MensajeComunicacion("Se generó el archivo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                letra += 1;

                if (letra == Marque.Length)
                {
                    lblProcesando.Text = String.Empty;
                    letra = 0;
                }
                else
                {
                    lblProcesando.Text += Marque.Substring(letra - 1, 1);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

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

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                cmsFormatos.Show(btExportar, new Point(0, btExportar.Height));
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmFormato1_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaRegistroVentas.Count > 0)
                {
                    Formato = 1;
                    Exportar(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmFormato2_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaRegistroVentas.Count > 0)
                {
                    Formato = 2;
                    Exportar(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void formatoRegistoVentasParaImportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaRegistroVentas.Count > 0)
                {
                    Formato = 3;
                    Exportar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }

    internal class PaginaInicialRegistroVentas : PdfPageEventHelper
    {
        public DateTime Periodo { get; set; }
        public DateTime PeriodoFin { get; set; }
        public String Moneda { get; set; }
        public float[] Anchos { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            Boolean MostrarFecPrint = VariablesLocales.oConParametros.MostrarFechaPrint;
            BaseColor ColorFondo = new BaseColor(Color.Silver);

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
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.9f, 0.1f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            #region Titulos Principales

            table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD), 5, 1));
            table.AddCell(ReaderHelper.NuevaCelda(MostrarFecPrint ? "Fecha: " + FechaActual : "", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 0f, 0f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 5, 1));
            table.AddCell(ReaderHelper.NuevaCelda(MostrarFecPrint ? "Hora: " + HoraActual : "", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 0f, 0f));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f)));
            table.AddCell(ReaderHelper.NuevaCelda("Pag.    " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "N", "N", 0f, 0f));
            table.CompleteRow(); //Fila completada

            #endregion

            #region Subtitulos

            table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
            table.CompleteRow(); //Fila completada

            table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 8f, iTextSharp.text.Font.BOLD), -1, -1, "S2"));
            table.CompleteRow(); //Fila completada

            #endregion

            document.Add(table); //Añadiendo la tabla al documento PDF

            #region Cabecera del Detalle

            PdfPTable TablaCabDetalle = new PdfPTable(22)
            {
                WidthPercentage = 100
            };

            TablaCabDetalle.SetWidths(Anchos);

            #region Primera Linea

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COD. UNI. DE LA OPE.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA DE EMISION DEL DOC.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA DE VENC. Y/O PAGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COMPROBANTE DE PAGO O DOCUMENTO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("INFORMACION DEL CLIENTE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR FACTURADO DE LA EXPORT.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("BASE IMPONIB. DE LA OPERAC. GRAVADA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IMPORTE TOTAL DE LA OPERACIÓN EXONERADA O INAFECTA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IGV Y/O IPM", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OTROS CARGOS", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IMPORTE TOTAL DEL COMPROB. DE PAGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIPO DE CAMBIO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S3"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("REFERENCIA DEL COMPROBANTE DE PAGO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));

            TablaCabDetalle.CompleteRow();

            #endregion

            #region Segunda Linea

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIP.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N° DE SERIE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUMERO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DOC. DE IDENTIDAD", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("APELLIDOS Y NOMBRES O RAZON SOCIAL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("EXONE.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("INAFE.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIP.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SERIE", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUME.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));

            TablaCabDetalle.CompleteRow();

            #endregion

            #region Tercera Linea

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DEL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("AL", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIP.", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUMERO", ColorFondo, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));

            TablaCabDetalle.CompleteRow();

            #endregion

            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

            #endregion

        }

    }
}

