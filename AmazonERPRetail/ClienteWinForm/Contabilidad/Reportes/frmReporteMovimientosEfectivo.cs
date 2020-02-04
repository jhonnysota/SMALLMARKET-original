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
    public partial class frmReporteMovimientosEfectivo : FrmMantenimientoBase
    {
        public frmReporteMovimientosEfectivo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<VoucherItemE> oReporteMovimientos = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String sParametro = String.Empty;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String Marque = String.Empty;
        string tipo = "buscar";
        String CheckMov = String.Empty;
     
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

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;


            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

            if (rbEfectivo.Checked == true)
            {
                CheckMov = "Efectivo";
            }
            if (rbBancos.Checked == true)
            {
                CheckMov = "Bancos";
            }
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

                PaginaInicialMovimientos ev = new PaginaInicialMovimientos();
                ev.oMov = oReporteMovimientos;
                ev.MesIni = Convert.ToString(cboInicioMes.SelectedValue);
                ev.MesFin = Convert.ToString(cboFinMes.SelectedValue);
                ev.Anio = Convert.ToString(cboAño.SelectedValue);
                ev.CheckMov = CheckMov;
                //Parametros Que Pasaras Al PDF
                oPdfw.PageEvent = ev;
                docPdf.Open();

                if (CheckMov == "Efectivo")
                {
                    #region Detalle

                    PdfPTable TablaCabDetalle = new PdfPTable(7);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.03f, 0.07f, 0.03f, 0.07f, 0.03f, 0.03f });

                    //oReporteMovimientos = oReporteMovimientos.GroupBy(y => y.DNI).Select(g => g.First()).OrderBy(x => x.NomApe).ToList();
                    Decimal Subtotal = 0;
                    Decimal Subtotal2 = 0;
                    Decimal AntSoles = 0;
                    Decimal AntDolares = 0;

                    foreach (VoucherItemE item in oReporteMovimientos)
                    {
                        cell = new PdfPCell(new Paragraph(item.idLocal + " " + item.idComprobante +  " "+ item.numVoucher + " "+ item.numFile + " " + item.numItem, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Fecha.ToString("d"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.GlosaGeneral, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.CuentaOrigen , FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.desCuentaOrigen, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        if (item.idMoneda == "01")
                        {                        
                            if (item.indDebeHaber == "H")
                            {
                                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.impSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }
                            if (item.indDebeHaber == "D")
                            {
                                cell = new PdfPCell(new Paragraph(item.impSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            Subtotal += item.impSoles;
                            AntSoles = item.salAntSoles;
                        }

                        if (item.idMoneda == "02")
                        {
                            if (item.indDebeHaber == "H")
                            {
                                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.impDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            if (item.indDebeHaber == "D")
                            {
                                cell = new PdfPCell(new Paragraph(item.impDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            Subtotal2 += item.impDolares;
                            AntDolares = item.salAntDolares;
                        }

                        TablaCabDetalle.CompleteRow();
                    }

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Saldo Anterior", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(AntSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(AntDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();


                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Totales", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    Decimal Total = AntSoles + Subtotal;
                    cell = new PdfPCell(new Paragraph(Total.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    Decimal Total2 = AntDolares + Subtotal2;
                    cell = new PdfPCell(new Paragraph(Total2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();


                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion
                }
                if (CheckMov == "Bancos")
                {
                    #region Detalle

                    PdfPTable TablaCabDetalle = new PdfPTable(10);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] { 0.04f, 0.025f, 0.02f, 0.08f, 0.08f, 0.1f, 0.015f, 0.05f, 0.025f, 0.025f });

                    //oReporteMovimientos = oReporteMovimientos.GroupBy(y => y.DNI).Select(g => g.First()).OrderBy(x => x.NomApe).ToList();
                    Decimal X2 = 0;
                    Decimal Y2 = 0;
                    Decimal Result = 0;
                    Decimal X1 = 0;
                    Decimal Y1 = 0;
                    Decimal X = 0;
                    Decimal Y = 0;
                    Int32 idMoneda = 0;
                    Int32 Correlativo = 0;

                    foreach (VoucherItemE item in oReporteMovimientos)
                    {
                        if (Correlativo == 0)
                        {
                            if (item.salAntSoles104 > 0)
                            {
                                X1 = item.salAntSoles104;
                            }
                            else if(item.salAntSoles104 < 0)
                            {                                  
                                Y1 = Math.Abs(item.salAntSoles104);
                            }
                        }
                        cell = new PdfPCell(new Paragraph(item.idLocal + " " + item.idComprobante + " " + item.numVoucher + " " + item.numFile + " " + item.numItem, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Fecha.ToString("d"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(item.GlosaGeneral, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.RazonSocialEmisor, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.idDocumento + " " + item.desCuentaOrigen, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.CuentaOrigen, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.desCuenta, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);
                        idMoneda = Convert.ToInt32( cboMoneda.SelectedValue);

                        if (idMoneda == 1)
                        {
                            if (item.indDebeHaber == "H")
                            {
                                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.impSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                Y += item.impSoles;
                            }
                            if (item.indDebeHaber == "D")
                            {
                                cell = new PdfPCell(new Paragraph(item.impSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                X += item.impSoles;
                            }
                         


                        }
                        if (idMoneda == 2)
                        {
                            if (item.indDebeHaber == "H")
                            {
                                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.impDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                Y += item.impDolares;
                            }

                            if (item.indDebeHaber == "D")
                            {
                                cell = new PdfPCell(new Paragraph(item.impDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                X += item.impDolares;
                            }
                          

                        }


                        Correlativo++;
                        TablaCabDetalle.CompleteRow();
                    }





                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Total Movimiento", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                   

                    cell = new PdfPCell(new Paragraph(X.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(Y.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();





                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Saldo Anterior", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(X1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(Y1.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Totales", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    Result = (X - Y) + (X1 - Y1);

                    if (Result > 0)
                    {
                        X2 = Result;
                    }
                    else if(Result < 0)
                    {
                        Y2 = Math.Abs(Result);
                    }

                    cell = new PdfPCell(new Paragraph(X2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(Y2.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    TablaCabDetalle.CompleteRow();

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
                fsNuevoArchivo.Close();
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Reporte Libro Cajas y Bancos";
            NombrePestaña = "Reporte Libro Cajas y Bancos";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                #region Meses
                String MesIni = cboInicioMes.SelectedValue.ToString();
                String NombreMes = String.Empty;

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

                #region Meses
                String MesFin = cboFinMes.SelectedValue.ToString();
                String NombreMes2 = String.Empty;

                if (MesFin == "00")
                {
                    NombreMes2 = "APERTURA";
                }

                if (MesFin == "01")
                {
                    NombreMes2 = "ENERO";
                }
                if (MesFin == "02")
                {
                    NombreMes2 = "FEBRERO";
                }
                if (MesFin == "03")
                {
                    NombreMes2 = "MARZO";
                }
                if (MesFin == "04")
                {
                    NombreMes2 = "ABRIL";
                }
                if (MesFin == "05")
                {
                    NombreMes2 = "MAYO";
                }
                if (MesFin == "06")
                {
                    NombreMes2 = "JUNIO";
                }
                if (MesFin == "07")
                {
                    NombreMes2 = "JULIO";
                }
                if (MesFin == "08")
                {
                    NombreMes2 = "AGOSTO";
                }
                if (MesFin == "09")
                {
                    NombreMes2 = "SETIEMBRE";
                }
                if (MesFin == "10")
                {
                    NombreMes2 = "OCTUBRE";
                }
                if (MesFin == "11")
                {
                    NombreMes2 = "NOVIEMBRE";
                }
                if (MesFin == "12")
                {
                    NombreMes2 = "DICIEMBRE";
                }
                if (MesFin == "13")
                {
                    NombreMes2 = "CIERRE";
                }

                #endregion

                String Anio =cboAño.SelectedValue.ToString();

                if (oHoja != null)
                {
                    #region Efectivo

                    if (CheckMov == "Efectivo")
                    {



                        Int32 InicioLinea = 5;
                        Int32 TotColumnas = 7;

                        #region Titulos Principales

                        // Creando Encabezado;
                        oHoja.Cells["A1"].Value = "Fomato 1.1:Libro Caja Y Bancos - Detalle De Los Movimientos en Efectivo";

                        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(62, 192, 218));
                        }
                        if (MesIni == MesFin)
                        {
                            oHoja.Cells["A2"].Value = "Periodo : " + NombreMes + "Del" + Anio;


                        }
                        if (MesIni != MesFin)
                        {
                            oHoja.Cells["A2"].Value = "Del Mes " + NombreMes + " Al " + NombreMes2 + " Del  " + Anio;


                        }

                        oHoja.Cells["A3"].Value = "Ruc : " + VariablesLocales.SesionUsuario.Empresa.RUC;


                        oHoja.Cells["A4"].Value = "RAZON SOCIAL: " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;



                        #endregion Titulos Principales

                        #region Cabeceras del Detalle


                        oHoja.Cells[InicioLinea, 1].Value = " ";

                        InicioLinea++;
                        InicioLinea++;

                        //// PRIMERA
                        oHoja.Column(1).Width = 45;
                        oHoja.Column(2).Width = 15;
                        oHoja.Column(3).Width = 35;
                        oHoja.Column(4).Width = 10;
                        oHoja.Column(5).Width = 25;
                        oHoja.Column(6).Width = 15;
                        oHoja.Column(7).Width = 15;
                        oHoja.Cells[InicioLinea, 1].Value = "Numero Correlativo Del Registro Unico De La Operacion ";
                        oHoja.Cells[InicioLinea, 2].Value = "Fecha De La Operacion ";
                        oHoja.Cells[InicioLinea, 3].Value = "Descripcion De La Operacion";
                        oHoja.Cells[InicioLinea, 4].Value = "Codigo";
                        oHoja.Cells[InicioLinea, 5].Value = "Cuenta Contable Asociada";
                        oHoja.Cells[InicioLinea, 6].Value = "Saldos Y Movimientos";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, InicioLinea, 7])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        for (int i = 1; i <= 7; i++)
                        {

                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                        }

                        InicioLinea++;

                        // SEGUNDA
                        oHoja.Cells[InicioLinea, 1].Value = "";
                        oHoja.Cells[InicioLinea, 2].Value = "";
                        oHoja.Cells[InicioLinea, 3].Value = "";
                        oHoja.Cells[InicioLinea, 4].Value = "";
                        oHoja.Cells[InicioLinea, 5].Value = "Denominacion";
                        oHoja.Cells[InicioLinea, 6].Value = "Deudor";
                        oHoja.Cells[InicioLinea, 7].Value = "Acreedor";
                        InicioLinea++;

                        Decimal Subtotal = 0;
                        Decimal Subtotal2 = 0;
                        Decimal AntSoles = 0;
                        Decimal AntDolares = 0;

                        #endregion Cabeceras del Detalle

                        foreach (VoucherItemE item in oReporteMovimientos)
                        {

                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 1].Value = item.idLocal + " " + item.idComprobante + " " + item.numVoucher + " " + item.numFile + " " + item.numItem;

                            oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 2].Value = item.Fecha;
                            oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 3].Value = item.GlosaGeneral;

                            oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 4].Value = item.CuentaOrigen;

                            oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 5].Value = item.desCuentaOrigen;

                            if (item.idMoneda == "01")
                            {
                                if (item.indDebeHaber == "H")
                                {

                                    oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 6].Value = "";
                                    oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 7].Value = item.impSoles;

                                }
                                if (item.indDebeHaber == "D")
                                {

                                    oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 6].Value = item.impSoles;
                                    oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 7].Value = "";
                                }
                                Subtotal += item.impSoles;
                                AntSoles = item.salAntSoles;
                            }
                            if (item.idMoneda == "02")
                            {
                                if (item.indDebeHaber == "H")
                                {

                                    oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 6].Value = "";
                                    oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 7].Value = item.impDolares;

                                }
                                if (item.indDebeHaber == "D")
                                {

                                    oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 6].Value = item.impDolares;
                                    oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 7].Value = "";
                                }
                                Subtotal2 += item.impDolares;
                                AntDolares = item.salAntDolares;
                            }


                            oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                            // Formateo
                            oHoja.Cells[InicioLinea, 6, InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";


                            InicioLinea++;



                        }

                        //Linea
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                        InicioLinea++;


                        oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 5].Value = "Saldos Anterior";
                        oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 6].Value = AntSoles;
                        oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 7].Value = AntDolares;
                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 5].Value = "Totales";
                        Decimal Total = AntSoles + Subtotal;
                        oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 6].Value = Total;
                        Decimal Total2 = AntDolares + Subtotal2;
                        oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 7].Value = Total2;
                        InicioLinea++;

                        //Linea
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    }

                    #endregion

                    #region Bancos

                    if (CheckMov == "Bancos")
                    {



                        Int32 InicioLinea = 6;
                        Int32 TotColumnas = 12;

                        #region Titulos Principales

                        // Creando Encabezado;
                        oHoja.Cells["A1"].Value = "Fomato 1.2:Libro Caja Y Bancos - Detalle De Los Movimientos de la Cuenta Corriente";

                        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(62, 192, 218));
                        }
                        if (MesIni == MesFin)
                        {
                            oHoja.Cells["A2"].Value = "Periodo : " + NombreMes + "Del" + Anio;


                        }
                        if (MesIni == MesFin)
                        {
                            oHoja.Cells["A2"].Value = "Del Mes" + NombreMes + "Al" + NombreMes2 + "Del " + Anio;


                        }

                        oHoja.Cells["A3"].Value = "Ruc : " + VariablesLocales.SesionUsuario.Empresa.RUC;


                        oHoja.Cells["A4"].Value = "RAZON SOCIAL: " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                        oHoja.Cells["A5"].Value = "ENTIDAD FINANCIERA: " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;


                        #endregion Titulos Principales

                        #region Cabeceras del Detalle



                        //// PRIMERA
                        oHoja.Column(1).Width = 30;
                        oHoja.Column(2).Width = 15;
                        oHoja.Column(3).Width = 30;
                        oHoja.Column(4).Width = 40;
                        oHoja.Column(5).Width = 40;
                        oHoja.Column(6).Width = 70;
                        oHoja.Column(7).Width = 10;
                        oHoja.Column(8).Width = 30;
                        oHoja.Column(9).Width = 15;
                        oHoja.Column(10).Width = 15;
                        oHoja.Column(11).Width = 15;
                        oHoja.Column(12).Width = 15;

                        oHoja.Cells[InicioLinea, 1].Value = "Numero Correlativo Del";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 1])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 2].Value = "Fecha De";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 2])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 3].Value = "Operaciones Bancarias";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 5])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }
                        oHoja.Cells[InicioLinea, 6].Value = "Numero De Transaccion Bancaria De Documento Sustentatorio o De Control Interno De La Operacion";
                        oHoja.Cells[InicioLinea, 7].Value = "Cuenta Contable Asociada";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea, 8])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 9].Value = "Saldos Y Movimientos";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, InicioLinea, 12])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        for (int i = 1; i <= 12; i++)
                        {

                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                        }

                        InicioLinea++;

                        // SEGUNDA
                        oHoja.Cells[InicioLinea, 1].Value = "Registro Unico De La Operacion";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 1])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 2].Value = "La Operacion";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 2])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 3].Value = "Medio Pago";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 4].Value = "Descripcion De La Operacion";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 4, InicioLinea, 4])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 5].Value = "Apellidos y Nombres o Razon Social";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea, 5])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 6].Value = "";

                        oHoja.Cells[InicioLinea, 7].Value = "Codigo";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea, 7])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 8].Value = "Denominacion";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, InicioLinea, 8])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 9].Value = "Deudor S/.";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, InicioLinea, 9])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 10].Value = "Acreedor S/.";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 10, InicioLinea, 10])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 11].Value = "Deudor US$";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 11, InicioLinea, 11])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        oHoja.Cells[InicioLinea, 12].Value = "Acreedor US$";
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 12, InicioLinea, 12])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        for (int i = 1; i <= 12; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }

                        InicioLinea++;

                        Decimal Subtotal = 0;
                        Decimal Subtotal2 = 0;
                        Decimal AntSoles = 0;
                        Decimal AntDolares = 0;

                        #endregion Cabeceras del Detalle

                        foreach (VoucherItemE item in oReporteMovimientos)
                        {

                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 1].Value = item.idLocal + " " + item.idComprobante + " " + item.numVoucher + " " + item.numFile + " " + item.numItem;

                            oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 2].Value = item.Fecha;
                            oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                            oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 4].Value = item.GlosaGeneral;

                            oHoja.Cells[InicioLinea, 5].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 5].Value = item.RazonSocialEmisor;

                            oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 6].Value = item.idDocumento + " " + item.desCuentaOrigen;

                            oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 7].Value = item.CuentaOrigen;
                            oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                            oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                            oHoja.Cells[InicioLinea, 8].Value = item.desCuenta;

                         
                                if (item.indDebeHaber == "H")
                                {

                                    oHoja.Cells[InicioLinea,9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 9].Value = "";
                                    oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 10].Value = item.impSoles;

                                }
                                if (item.indDebeHaber == "D")
                                {

                                    oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 9].Value = item.impSoles;
                                    oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 10].Value = "";
                                }
                                Subtotal += item.impSoles;
                                AntSoles = item.salAntSoles;
                            

                                if (item.indDebeHaber == "H")
                                {

                                    oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 11].Value = "";
                                    oHoja.Cells[InicioLinea, 12].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 12].Value = item.impDolares;

                                }
                                if (item.indDebeHaber == "D")
                                {

                                    oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 11].Value = item.impDolares;
                                    oHoja.Cells[InicioLinea, 12].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                                    oHoja.Cells[InicioLinea, 12].Value = "";
                                }
                                Subtotal2 += item.impDolares;
                                AntDolares = item.salAntDolares;


                            oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                            // Formateo
                            oHoja.Cells[InicioLinea, 9, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";


                            InicioLinea++;
                        }

                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 8].Value = "Saldos Anterior";
                        oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 9].Value = AntSoles;
                        oHoja.Cells[InicioLinea,11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea,11].Value = AntDolares;
                        oHoja.Cells[InicioLinea, 9, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 8].Value = "Totales";

                        Decimal Total = AntSoles + Subtotal;
                        oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 9].Value = Total;

                        Decimal Total2 = AntDolares + Subtotal2;
                        oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 11].Value = Total2;
                        oHoja.Cells[InicioLinea, 9, InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                        InicioLinea++;

                        //Linea
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                    }

                    #endregion

                    ////Ajustando el ancho de las columnas automaticamente
                    //oHoja.Cells.AutoFitColumns(0);

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
            if (rbEfectivo.Checked == true)
            {
                CheckMov = "Efectivo";
                txtCuentaIni.Text = "101";
                txtCuentaFin.Text = "101";
                ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
                ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
            }
            if (rbBancos.Checked == true)
            {
                CheckMov = "Bancos";
                txtCuentaIni.Text = "104";
                txtCuentaFin.Text = "104";
                ObtenerDescripcionCuenta(txtCuentaIni, txtDesCuentaIni);
                ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
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



                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Reporte Libro Cajas y Bancos" + ".xlsx");

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
            if (!String.IsNullOrWhiteSpace(txtcuenta.Text.Trim()))
            {
                txtdescripcion.Text = AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtcuenta.Text.ToString());
            }
            else
            {
                txtdescripcion.Text = String.Empty;
            }
        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (tipo == "buscar")
                {

                    if (rbEfectivo.Checked == true)
                    {
                    String Plan = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                        Int32 local = Convert.ToInt32(cboSucursales.SelectedValue);
                        lblProcesando.Text = "Obteniendo Los Movimientos Efectivo...";
                    oReporteMovimientos = AgenteContabilidad.Proxy.ReporteVoucherItemMovimientoEFectivo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, local, Plan,cboAño.SelectedValue.ToString(),cboInicioMes.SelectedValue.ToString(),cboFinMes.SelectedValue.ToString(),"101","101");
                    lblProcesando.Text = "Armando el Reporte...";
                    ConvertirApdf();

                    }
                    if (rbBancos.Checked == true)
                    {
                        Int32 local = Convert.ToInt32(cboSucursales.SelectedValue);
                        String CuentaIni = txtCuentaIni.Text;
                        String CuentaFin = txtCuentaFin.Text;
                        String Plan = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                        lblProcesando.Text = "Obteniendo Los Movimientos Cta Cte...";
                    oReporteMovimientos = AgenteContabilidad.Proxy.ReporteVoucherItemMovimientoCtaCte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, local, Plan, cboAño.SelectedValue.ToString(), cboInicioMes.SelectedValue.ToString(), cboFinMes.SelectedValue.ToString(), CuentaIni, CuentaFin);
                        lblProcesando.Text = "Armando el Reporte...";
                    ConvertirApdf();
                    }
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

        private void btPle_Click(object sender, EventArgs e)
        {
            #region Variables Carga Archivo

            StringBuilder Cadena = new StringBuilder();
            String NombreArchivo = String.Empty;
            String MesIni = cboInicioMes.SelectedValue.ToString();
            String MesFin = cboFinMes.SelectedValue.ToString();
            String anioReal = VariablesLocales.PeriodoContable.AnioPeriodo;
            String Moneda = cboMoneda.SelectedValue.ToString();
            String OperacionTmp = String.Empty;
            String RutaArchivoTexto = String.Empty;
            String IndicadorTmp = String.Empty;

            #endregion

            try
            {
                if (rbBancos.Checked == true)
                {
                    if (MesIni != MesFin)
                    {
                        Global.MensajeFault("Los periodos tienes que ser el mismo.");
                        return;
                    }

                    if (MesFin == "13")
                    {
                        MesFin = "12";
                    }

                    NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anioReal + MesFin + "000101000" + OperacionTmp + IndicadorTmp + Moneda + "1";
                    RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                    if (!String.IsNullOrEmpty(RutaArchivoTexto))
                    {
                        if (File.Exists(RutaArchivoTexto))
                        {
                            File.Delete(RutaArchivoTexto);
                        }

                        using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                        {
                            foreach (VoucherItemE item in oReporteMovimientos)
                            {
                                Cadena.Append(item.MesPeriodo).Append("|").Append(item.codCuenta).Append("|").Append(item.desCuenta).Append("|");

                                oSw.WriteLine(Cadena.ToString());
                                Cadena.Clear();
                            }

                            RutaArchivoTexto = String.Empty;
                        }
                    }

                }

                Global.MensajeComunicacion("Se generó el archivo correctamente.");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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


class PaginaInicialMovimientos : PdfPageEventHelper
{
    public List<VoucherItemE> oMov;
    //public String Titulo;
    public String MesIni = String.Empty;
    public String MesFin = String.Empty;
    String NombreMes = String.Empty;
    String NombreMes2 = String.Empty;
    public String Anio = String.Empty;
    public String CheckMov;

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        //String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;

        //TituloGeneral = Titulo;

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

        #region Meses

        if (MesFin == "00")
        {
            NombreMes2 = "APERTURA";
        }

        if (MesFin == "01")
        {
            NombreMes2 = "ENERO";
        }
        if (MesFin == "02")
        {
            NombreMes2 = "FEBRERO";
        }
        if (MesFin == "03")
        {
            NombreMes2 = "MARZO";
        }
        if (MesFin == "04")
        {
            NombreMes2 = "ABRIL";
        }
        if (MesFin == "05")
        {
            NombreMes2 = "MAYO";
        }
        if (MesFin == "06")
        {
            NombreMes2 = "JUNIO";
        }
        if (MesFin == "07")
        {
            NombreMes2 = "JULIO";
        }
        if (MesFin == "08")
        {
            NombreMes2 = "AGOSTO";
        }
        if (MesFin == "09")
        {
            NombreMes2 = "SETIEMBRE";
        }
        if (MesFin == "10")
        {
            NombreMes2 = "OCTUBRE";
        }
        if (MesFin == "11")
        {
            NombreMes2 = "NOVIEMBRE";
        }
        if (MesFin == "12")
        {
            NombreMes2 = "DICIEMBRE";
        }
        if (MesFin == "13")
        {
            NombreMes2 = "CIERRE";
        }

        #endregion

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.1f, 0.9f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales
        if (CheckMov == "Efectivo")
        {
            cell = new PdfPCell(new Paragraph("Formato 1.1:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("LIBRO CAJA Y BANCOS- DETALLE DE LOS MOVIMIENTOS DEL EFECTIVO", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
            table.CompleteRow();
        }
        if (CheckMov == "Bancos")
        {
            cell = new PdfPCell(new Paragraph("Formato 1.2:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("LIBRO CAJA Y BANCOS- DETALLE DE LOS MOVIMIENTOS DE LA CUENTA CORRIENTE", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_CENTER };
            table.AddCell(cell);
            table.CompleteRow();
        }

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

        //Fila completada
        if (MesIni != MesFin)
        {
            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Desde" + " " + NombreMes + " " + "Hasta " + " " + NombreMes2 + " " + "Del Año" + Anio, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);
        }
        if (MesIni == MesFin)
        {
            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Periodo : " + NombreMes + " Del " + Anio, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);
        }
        table.CompleteRow();

        cell = new PdfPCell(new Paragraph("RUC :" , FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RAZON SOCIAL :", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada


        if (CheckMov == "Bancos")
        {

            cell = new PdfPCell(new Paragraph("ENTIDAD FINANCIERA :", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
            table.AddCell(cell);
            table.CompleteRow();
        }
        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        if (CheckMov == "Efectivo")
        {            
            #region Cabecera del Detalle

            PdfPTable TablaCabDetalle = new PdfPTable(7);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.03f, 0.07f, 0.03f, 0.07f, 0.03f, 0.03f });

            #region Primera Linea

            cell = new PdfPCell(new Paragraph("Numero Correlativo Del Registro o Codigo Unico de la Operacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Fecha de la Operacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Descripcion De La Operacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Codigo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Cuenta Contable Asociada", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);


            cell = new PdfPCell(new Paragraph("Saldos Y Movimientos", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);

            TablaCabDetalle.CompleteRow();

            #endregion

            #region Segunda Linea

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Denominacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Deudor", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Acreedor", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);



            TablaCabDetalle.CompleteRow();

            #endregion



            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

            #endregion
        }

        if (CheckMov == "Bancos")
        {
            #region Cabecera del Detalle

            PdfPTable TablaCabDetalle = new PdfPTable(10);
            TablaCabDetalle.WidthPercentage = 100;
            TablaCabDetalle.SetWidths(new float[] { 0.04f, 0.025f, 0.02f, 0.08f, 0.08f, 0.1f, 0.015f, 0.05f, 0.025f, 0.025f });

            #region Primera Linea

            cell = new PdfPCell(new Paragraph("Numero Correlativo Del Registro o Codigo Unico de la Operacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Fecha de la Operacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Operaciones Bancarias", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 3;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Numero De Transaccion Bancaria De Documento Sustentatorio De Control Interno De La Operacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 1;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Cuenta Contable Asociada", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Saldos Y Movimientos", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            cell.Colspan = 2;
            TablaCabDetalle.AddCell(cell);

            TablaCabDetalle.CompleteRow();

            #endregion

            #region Segunda Linea

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) {  HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Medio Pago", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Descripcion De La Operacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Apellidos Y Nombres O Razon Social", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("", FontFactory.GetFont("Arial", 5f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Codigo ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Denominacion", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Deudor", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Acreedor", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
            TablaCabDetalle.AddCell(cell);



            TablaCabDetalle.CompleteRow();

            #endregion



            document.Add(TablaCabDetalle);

            #endregion 
       
        }
    }
}

#endregion