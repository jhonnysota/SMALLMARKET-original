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
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using ClienteWinForm.Busquedas;

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

#region Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteDetallePorCentroDeCostos : FrmMantenimientoBase
    {
        public frmReporteDetallePorCentroDeCostos()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        List<RegistroDiarioE> OListaRegistroDiario = null;
        List<RegistroDiarioE> ListDiario = new List<RegistroDiarioE>();

        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        Int32 letra = 0;
        int tipoProceso = 0; // 1 buscar; 0 exportar;
        readonly BackgroundWorker _bw = new BackgroundWorker();


        int ColumnasTabla = 11;

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


            //// Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);

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

        void CargarDatos(String param1, String param2, String param3, String param4, String param5, String param6, String param7, String param8)
        {
            RegistroDiarioE obj = new RegistroDiarioE();
            obj.codCuenta = param1;
            obj.desCuenta = param2;
            obj.Fecha = param3;
            obj.desGlosa = param4;
            obj.cDesCta1 = param5;
            obj.cDesCta2 = param6;
            obj.c_des_cta = param7;
            obj.c_des_aux = param8;
            ListDiario.Add(obj);
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            String NombreReporte = @"\Detalle Por Centro de Costo " + FechasHelper.NombreMes(dtpFecIni.Value.Month);
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

                PaginaInicialDetallePorCentroDeCostro ev = new PaginaInicialDetallePorCentroDeCostro();

                ev.Periodo = dtpFecIni.Value.Date;
                ev.Periodo2 = dtpFecFin.Value.Date;
                ev.ColumnasTabla = ColumnasTabla;
                oPdfw.PageEvent = ev;

                docPdf.Open();
               
                try
                {
                    #region Detalle

                    PdfPTable TablaCabDetalle = new PdfPTable(ColumnasTabla);
                    TablaCabDetalle.WidthPercentage = 100;
                    TablaCabDetalle.SetWidths(new float[] {  0.05f, 0.05f, 0.09f , 0.08f, 0.04f, 0.18f,0.4f,
                                                        0.15f, 0.15f, 0.15f, 0.15f });
                    int i=-1;
                    int x = 0;
                    int cntRegistro = OListaRegistroDiario.Count -1;
                   
                    decimal totDebe_D_CCostos = 0;
                    decimal totHaber_D_CCostos = 0;

                    decimal totDebe_S_CCostos = 0;
                    decimal totHaber_S_CCostos = 0;


                    String codCuenta = "";
                    String desCuenta = "";

                    String idCCostos = "";
                    String desCCostos = "";

                    List<RegistroDiarioE> oListaRegistroSaldos = OListaRegistroDiario.Where(xx => xx.idComprobante == "00").ToList();

                    RegistroDiarioE oSaldoAnterior = new RegistroDiarioE();

                    foreach (RegistroDiarioE item in OListaRegistroDiario)
                    {

                        if ( item.idComprobante!="00")
                        {
                        i++;
                        x = i - 1;

                        if (i == 0)
                        {
                           
                            #region Primera Linea

                            codCuenta = item.codCuenta;
                            desCuenta = item.desCuenta;

                            cell = new PdfPCell(new Paragraph(item.codCuenta + " - " +item.desCuenta, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = ColumnasTabla;
                            TablaCabDetalle.AddCell(cell);

                            
                            CargarDatos(item.codCuenta, item.desCuenta, "", "", "", "", "", "");
                            TablaCabDetalle.CompleteRow();
                            #endregion

                            #region Segunda Linea

                            idCCostos = item.idCCostos;
                            desCCostos = item.desCCostos;

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = 2;
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph( item.idCCostos + " - " + item.desCCostos, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = ColumnasTabla - 2;
                            TablaCabDetalle.AddCell(cell);
                            
                            TablaCabDetalle.CompleteRow();

                            CargarDatos(item.idCCostos, item.desCCostos, "", "", "", "", "", "");
                            #endregion

                            

                        }
                        else
                        {
                            if (codCuenta != item.codCuenta)
                            {
                                // -------------------------------
                                // TOTALES CENTRO COSTOS
                                // -------------------------------

                                #region Sexta Linea

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = ColumnasTabla - 5;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("Movimientos CCostos : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);


                                cell = new PdfPCell(new Paragraph(totDebe_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(totHaber_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(totDebe_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(totHaber_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                // --------------------------------------------------

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = ColumnasTabla - 5;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("Saldo Anterior : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                List<RegistroDiarioE> oListaTmmp = (from xx in oListaRegistroSaldos where xx.codCuenta == codCuenta && xx.idCCostos == idCCostos select xx).ToList();
                                if (oListaTmmp != null && oListaTmmp.Count > 0)
                                    oSaldoAnterior = oListaTmmp[0];
                                else
                                    oSaldoAnterior = new RegistroDiarioE() { indDebeHaber = "" };

                                cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber=="D" ? oSaldoAnterior.impDolares:0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impDolares : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impSoles : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impSoles : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                // -------------------------

                                totDebe_D_CCostos = totDebe_D_CCostos + (oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impDolares : 0);
                                totHaber_D_CCostos = totHaber_D_CCostos + (oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impDolares : 0);

                                totDebe_D_CCostos = (totDebe_D_CCostos - totHaber_D_CCostos > 0 ? totDebe_D_CCostos - totHaber_D_CCostos : 0);
                                totHaber_D_CCostos = (0 > totDebe_D_CCostos - totHaber_D_CCostos ? Math.Abs(totDebe_D_CCostos - totHaber_D_CCostos) : 0);

                                // -------------------------

                                totDebe_S_CCostos = totDebe_S_CCostos + (oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impSoles : 0);
                                totHaber_S_CCostos = totHaber_S_CCostos + (oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impSoles : 0);

                                totDebe_S_CCostos = (totDebe_S_CCostos - totHaber_S_CCostos > 0 ? totDebe_S_CCostos - totHaber_S_CCostos : 0);
                                totHaber_S_CCostos = (0 > totDebe_S_CCostos - totHaber_S_CCostos ? Math.Abs(totDebe_S_CCostos - totHaber_S_CCostos) : 0);


                                // -------------------------


                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = ColumnasTabla - 5;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("Saldo Actual : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);


                                cell = new PdfPCell(new Paragraph(totDebe_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(totHaber_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(totDebe_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(totHaber_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                #endregion
                                
                                #region Novena Linea
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                cell.Colspan = ColumnasTabla - 4;
                                TablaCabDetalle.AddCell(cell);
                                
                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                //cell.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                                //cell.BorderWidthBottom = 1f;
                                cell.Colspan = 4;
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                CargarDatos("", "", "", "", "", "", "", "");
                                #endregion

                                // -------------------------------
                                // TITULO - CUENTA
                                // -------------------------------

                                totDebe_D_CCostos = 0;
                                totHaber_D_CCostos = 0;

                                totDebe_S_CCostos = 0;
                                totHaber_S_CCostos = 0;

                                //mtoSolHabe = 0;
                                //mtoSolDebe = 0;
                                //mtoDolDebe = 0;
                                //mtoDolHabe = 0;

                                //mtoSolDebeAper = 0;
                                //mtoDolDebeAper = 0;
                                //mtoSolHabeAper = 0;
                                //mtoDolHabeAper = 0;

                                //totDol = 0;
                                //totSol = 0;

                                #region Primera Linea

                                codCuenta = item.codCuenta;
                                desCuenta = item.desCuenta;

                                cell = new PdfPCell(new Paragraph(item.codCuenta+" - "+item.desCuenta, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                cell.Colspan = ColumnasTabla;
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                CargarDatos(item.codCuenta + "  " + item.desCuenta, "", "", "", "", "", "", "");
                                #endregion

                                #region Segunda Linea

                                idCCostos = item.idCCostos;
                                desCCostos = item.desCCostos;

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                cell.Colspan = 2;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.idCCostos + " - " + item.desCCostos, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                cell.Colspan = ColumnasTabla - 2;
                                TablaCabDetalle.AddCell(cell);
                                
                                TablaCabDetalle.CompleteRow();
                                CargarDatos(item.idCCostos + "  " + item.desCCostos, "", "", "", "", "", "", "");
                                #endregion

                            }

                            if (idCCostos != item.idCCostos)
                            {
                                // -------------------------------
                                // TOTALES CENTRO COSTOS
                                // -------------------------------

                                #region Sexta Linea

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = ColumnasTabla - 5;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("Movimientos CCostos : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);


                                cell = new PdfPCell(new Paragraph(totDebe_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(totHaber_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(totDebe_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(totHaber_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                // --------------------------------------------------

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = ColumnasTabla - 5;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("Saldo Anterior : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                List<RegistroDiarioE> oListaTmmp = (from xx in oListaRegistroSaldos where xx.codCuenta == codCuenta && xx.idCCostos == idCCostos select xx).ToList();
                                if (oListaTmmp != null && oListaTmmp.Count > 0)
                                    oSaldoAnterior = oListaTmmp[0];
                                else
                                    oSaldoAnterior = new RegistroDiarioE() { indDebeHaber = "" };

                                cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impDolares : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impDolares : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impSoles : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impSoles : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                // -------------------------

                                totDebe_D_CCostos = totDebe_D_CCostos + (oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impDolares : 0);
                                totHaber_D_CCostos = totHaber_D_CCostos + (oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impDolares : 0);

                                totDebe_D_CCostos = (totDebe_D_CCostos - totHaber_D_CCostos > 0 ? totDebe_D_CCostos - totHaber_D_CCostos : 0);
                                totHaber_D_CCostos = (0 > totDebe_D_CCostos - totHaber_D_CCostos ? Math.Abs(totDebe_D_CCostos - totHaber_D_CCostos) : 0);
                                                                
                                // -------------------------

                                totDebe_S_CCostos = totDebe_S_CCostos + (oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impSoles : 0);
                                totHaber_S_CCostos = totHaber_S_CCostos + (oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impSoles : 0);

                                totDebe_S_CCostos = (totDebe_S_CCostos - totHaber_S_CCostos > 0 ? totDebe_S_CCostos - totHaber_S_CCostos : 0);
                                totHaber_S_CCostos = (0 > totDebe_S_CCostos - totHaber_S_CCostos ? Math.Abs(totDebe_S_CCostos - totHaber_S_CCostos) : 0);


                                // -------------------------


                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                cell.Colspan = ColumnasTabla - 5;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("Saldo Actual : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);


                                cell = new PdfPCell(new Paragraph(totDebe_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(totHaber_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(totDebe_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(totHaber_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                #endregion

                                // -------------------------------
                                // TITULO - CENTRO COSTOS
                                // -------------------------------

                                totDebe_D_CCostos = 0;
                                totHaber_D_CCostos = 0;

                                totDebe_S_CCostos = 0;
                                totHaber_S_CCostos = 0;

                                //mtoSolHabe = 0;
                                //mtoSolDebe = 0;
                                //mtoDolDebe = 0;
                                //mtoDolHabe = 0;

                                //mtoSolDebeAper = 0;
                                //mtoDolDebeAper = 0;
                                //mtoSolHabeAper = 0;
                                //mtoDolHabeAper = 0;

                                //totDol = 0;
                                //totSol = 0;

                                #region Segunda Linea

                                idCCostos = item.idCCostos;
                                desCCostos = item.desCCostos;

                                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                cell.Colspan = 2;
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.idCCostos + " - " + item.desCCostos, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                cell.Colspan = ColumnasTabla - 2;
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                                CargarDatos(item.idCCostos + "  " + item.desCCostos, "", "", "", "", "", "", "");
                                #endregion

                            }   
                        }
                        
                        //if (i == 0)
                        //{
                            #region Cuarta Linea

                            cell = new PdfPCell(new Paragraph(item.idComprobante , FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);
                            
                            cell = new PdfPCell(new Paragraph(item.numFile , FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.numVoucher , FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.idDocumento , FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.numDocumento, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(item.GlosaGeneral, FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            if (item.indDebeHaber == "D")
                            {
                                cell = new PdfPCell(new Paragraph(item.impDolares.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(item.impSoles.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                totDebe_D_CCostos += item.impDolares;                                
                                totDebe_S_CCostos += item.impSoles;

                            }
                            else
                            {
                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(item.impDolares.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                                cell = new PdfPCell(new Paragraph(item.impSoles.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                totHaber_D_CCostos += item.impDolares;
                                totHaber_S_CCostos += item.impSoles;
                            }


                            TablaCabDetalle.CompleteRow();

                            #endregion
                          

                        }
                    }

                    // -------------------------------
                    // TOTALES CENTRO COSTOS
                    // -------------------------------

                    #region Sexta Linea

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = ColumnasTabla - 5;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Movimientos CCostos : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);


                    cell = new PdfPCell(new Paragraph(totDebe_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(totHaber_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(totDebe_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(totHaber_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    // --------------------------------------------------

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = ColumnasTabla - 5;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Saldo Anterior : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    List<RegistroDiarioE> oListaTmmp_ = (from xx in oListaRegistroSaldos where xx.codCuenta == codCuenta && xx.idCCostos == idCCostos select xx).ToList();
                    if (oListaTmmp_ != null && oListaTmmp_.Count > 0)
                        oSaldoAnterior = oListaTmmp_[0];
                    else
                        oSaldoAnterior = new RegistroDiarioE() { indDebeHaber = "" };

                    cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impDolares : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impDolares : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impSoles : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(((oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impSoles : 0)).ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    // -------------------------

                    totDebe_D_CCostos = totDebe_D_CCostos + (oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impDolares : 0);
                    totHaber_D_CCostos = totHaber_D_CCostos + (oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impDolares : 0);

                    totDebe_D_CCostos = (totDebe_D_CCostos - totHaber_D_CCostos > 0 ? totDebe_D_CCostos - totHaber_D_CCostos : 0);
                    totHaber_D_CCostos = (0 > totDebe_D_CCostos - totHaber_D_CCostos ? Math.Abs(totDebe_D_CCostos - totHaber_D_CCostos) : 0);

                    // -------------------------

                    totDebe_S_CCostos = totDebe_S_CCostos + (oSaldoAnterior.indDebeHaber == "D" ? oSaldoAnterior.impSoles : 0);
                    totHaber_S_CCostos = totHaber_S_CCostos + (oSaldoAnterior.indDebeHaber == "H" ? oSaldoAnterior.impSoles : 0);

                    totDebe_S_CCostos = (totDebe_S_CCostos - totHaber_S_CCostos > 0 ? totDebe_S_CCostos - totHaber_S_CCostos : 0);
                    totHaber_S_CCostos = (0 > totDebe_S_CCostos - totHaber_S_CCostos ? Math.Abs(totDebe_S_CCostos - totHaber_S_CCostos) : 0);


                    // -------------------------


                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = ColumnasTabla - 5;
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph("Saldo Actual : ", FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);


                    cell = new PdfPCell(new Paragraph(totDebe_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(totHaber_D_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(totDebe_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);
                    cell = new PdfPCell(new Paragraph(totHaber_S_CCostos.ToString("N2"), FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    #endregion

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
                catch (Exception ex)
                {
                    Global.MensajeError(ex.Message);
                }
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {

            ListaReporte();

            lblProcesando.Text = "Armando el Reporte Detalle Por Centro De Costo...";

            //Generando el PDF
            if (tipoProceso == 1)
                ConvertirApdf();
            else 
                ExportarExcel(RutaGeneral);
        }

        void ListaReporte()
        {
            try
            {
                DateTime fecInicial = dtpFecIni.Value.Date;
                DateTime fecFin = dtpFecFin.Value.Date;
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                String codCuentaIni =txtCuentaIni.Text.ToString();
                String codCuentaFin =txtCuentaFin.Text.ToString();
                Int32 numNivel = Convert.ToInt32(cboNivel.SelectedValue);
                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el Reporte Detalle Por Centro de Costo...";
                
                OListaRegistroDiario = AgenteContabilidad.Proxy.ObtenerDetallePorCenttroDeCostro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal,Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo),fecInicial,fecFin,codCuentaIni,codCuentaFin,numNivel);

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

            if (tipoProceso == 1)
            {
                //Mostrando el reporte en un web browser
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                    tipoProceso = 0;
                }
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Detalle Centro de Costos de " + FechasHelper.NombreMes(dtpFecIni.Value.Month).ToUpper() + " a " + FechasHelper.NombreMes(dtpFecFin.Value.Month).ToUpper() + " del " + dtpFecIni.Value.Year.ToString();
            NombrePestaña = "Centro de Costos";

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
                    Int32 TotColumnas = 16   ;
                    //int col;
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

                    #region Cabecera

                    #region Primera Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, 5, 1])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Cuenta";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, 5, 2])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Descripción";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, 5, 3])
                    {
                        Rango.Merge = true;
                        Rango.Value = "CCostos";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 4, 5, 4])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Descripción";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }


                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, 5, 5])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Libro";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }


                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, 5, 6])
                    {
                        Rango.Merge = true;
                        Rango.Value = "File";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }


                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, 5, 7])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Comprobante";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }


                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, 5, 8])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Item";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, 5, 9])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Fecha";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 10, 5, 10])
                    {
                        Rango.Merge = true;
                        Rango.Value = "TD";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 11, 5, 11])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Documento";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 12, 5, 12])
                    {
                        Rango.Merge = true;
                        Rango.Value = "Glosa";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
                    
                    // ======================
                    // IMPORTES
                    // ======================

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 13, 4, 14])
                    {
                        Rango.Merge = true;
                        Rango.Value = "DOLARES";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 15, 4, 16])
                    {
                        Rango.Merge = true;
                        Rango.Value = "SOLES";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
                    
                    // ======================
                    // Auto Filtro
                    // ======================

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;
                    #endregion
                    InicioLinea++;

                    #region Segunda Linea Cabecera

                    oHoja.Cells[InicioLinea, 13].Value = "DEBE";
                    oHoja.Cells[InicioLinea, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 13].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 13].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    oHoja.Cells[InicioLinea, 14].Value = "HABER";
                    oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    oHoja.Cells[InicioLinea, 15].Value = "DEBE";
                    oHoja.Cells[InicioLinea, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 15].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 15].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    oHoja.Cells[InicioLinea, 16].Value = "HABER";
                    oHoja.Cells[InicioLinea, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 16].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 16].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    #endregion

                    //InicioLinea++;
                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;
                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;
                    //col = 1;

                    int cntRegistro = ListDiario.Count - 1;
                    //int i = 0;
                    //int x = 0;

                    #region Carga Informacion a Excel

                    List<RegistroDiarioE> oListaRegistroSaldos = OListaRegistroDiario.Where(xx => xx.idComprobante == "00").ToList();

                    RegistroDiarioE oSaldoAnterior = new RegistroDiarioE();


                    foreach (RegistroDiarioE item in OListaRegistroDiario)
                    {
                        if (item.idComprobante != "00")
                        {

                            oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                            oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;
                            oHoja.Cells[InicioLinea, 3].Value = item.idCCostos;
                            oHoja.Cells[InicioLinea, 4].Value = item.desCCostos;

                            oHoja.Cells[InicioLinea, 5].Value = item.idComprobante;
                            oHoja.Cells[InicioLinea, 6].Value = item.numFile;
                            oHoja.Cells[InicioLinea, 7].Value = item.numVoucher;
                            oHoja.Cells[InicioLinea, 8].Value = item.numItem;

                            oHoja.Cells[InicioLinea, 9].Value = Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy");
                            oHoja.Cells[InicioLinea, 10].Value = item.idDocumento;
                            oHoja.Cells[InicioLinea, 11].Value = item.numDocumento;
                            oHoja.Cells[InicioLinea, 12].Value = item.GlosaGeneral;

                            oHoja.Cells[InicioLinea, 13].Value = (item.indDebeHaber == "D" ? item.impDolares : 0);
                            oHoja.Cells[InicioLinea, 14].Value = (item.indDebeHaber == "H" ? item.impDolares : 0);
                            oHoja.Cells[InicioLinea, 15].Value = (item.indDebeHaber == "D" ? item.impSoles : 0);
                            oHoja.Cells[InicioLinea, 16].Value = (item.indDebeHaber == "H" ? item.impSoles : 0);


                            InicioLinea++;
                        }
                        // ================
                        // END IF "00"
                        // ================
                    }

                    // ================
                    // END FOR
                    // ================



                    //foreach (RegistroDiarioE item in ListDiario)
                    //{
                    //    i++;
                    //    x = i + 1;
                    //    oHoja.Cells[InicioLinea, 1].Value = item.CodCuenta;
                    //    oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;
                    //    oHoja.Cells[InicioLinea, 3].Value = item.Fecha;
                    //    oHoja.Cells[InicioLinea, 4].Value = item.DesGlosa;
                    //    oHoja.Cells[InicioLinea, 5].Value = item.cDesCta1;
                    //    oHoja.Cells[InicioLinea, 6].Value = item.cDesCta2;
                    //    oHoja.Cells[InicioLinea, 7].Value = item.c_des_cta;
                    //    oHoja.Cells[InicioLinea, 8].Value = item.c_des_aux;

                    //    if (i < cntRegistro)
                    //    {
                    //        if (ListDiario[x].CodCuenta == "" && ListDiario[x].desCuenta == "" && ListDiario[x].Fecha == "" && ListDiario[x].DesGlosa != "")
                    //        {
                    //            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea, 8])
                    //            {
                    //                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    //            }
                    //        }
                    //    }

                    //    if (i < cntRegistro)
                    //    {
                    //        if (ListDiario[x].DesGlosa == "")
                    //        {
                    //            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea, 8])
                    //            {
                    //                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea, 8])
                    //        {
                    //            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    //        }
                    //    }
                        

                    //    InicioLinea++;

                    //}
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

        #region Procesos Heredados
        public override void Exportar()
        {
            try
            {
                if (OListaRegistroDiario.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }
                string dia = VariablesLocales.FechaHoy.Date.Day.ToString("00");
                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registros Importados Detalle por Centro de Costo (" + dia + "_" + mes + "_" + anio + ")", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
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

        #region Eventos

        private void frmDetallePorCentroDeCostos_Load(object sender, EventArgs e)
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
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
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

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                //this.Text = "Reporte Detalle por Centro de Costo Auxiliar Por Sucursal: " + cboSucursales.Text.ToString();
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void txtCuentaFin_Validating(object sender, CancelEventArgs e)
        {
            ObtenerDescripcionCuenta(txtCuentaFin, txtDesCuentaFin);
        }

        private void txtCuentaIni_Validating(object sender, CancelEventArgs e)
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

        #endregion
        
        #region Clase internal
        internal class PaginaInicialDetallePorCentroDeCostro : PdfPageEventHelper
        {
            public DateTime Periodo { get; set; }
            public DateTime Periodo2 { get; set; }
            public String Moneda { get; set; }
            public int ColumnasTabla { get; set; }

            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);

                String TituloGeneral = String.Empty;
                String SubTitulo = String.Empty;
                String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
                String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
                PdfPCell cell = null;

                TituloGeneral = "Detalle Centro de Costos";
                SubTitulo = "De " + FechasHelper.NombreMes(Periodo.Month).ToUpper() + " a " + FechasHelper.NombreMes(Periodo2.Month).ToUpper() + " del " + Periodo.Year;

                if (Periodo.Month == Periodo2.Month)
                    SubTitulo = FechasHelper.NombreMes(Periodo.Month).ToUpper() + " del " + Periodo.Year;

                PdfPTable table = new PdfPTable(2);

                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 0.9f, 0.13f });
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                //Element.ALIGN_LEFT
                #region Titulos Principales

                cell = new PdfPCell(new Paragraph("          " + TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
                table.AddCell(cell);
                cell = new PdfPCell(new Paragraph("Fecha: " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
                table.AddCell(cell);
                table.CompleteRow(); //Fila completada

                cell = new PdfPCell(new Paragraph("          " + SubTitulo, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
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

                cell = new PdfPCell(new Paragraph("RAZON SOCIAL    " + VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
                cell.Colspan = 2;
                table.AddCell(cell);
                table.CompleteRow(); //Fila completada

                cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
                cell.Colspan = 2;
                table.AddCell(cell);
                table.CompleteRow(); //Fila completada

                //Fila en blanco
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
                cell.Colspan = 2;
                table.AddCell(cell);
                table.CompleteRow(); //Fila completada 

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF

                #region Cabecera del Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(ColumnasTabla);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] {  0.05f, 0.05f, 0.09f , 0.08f, 0.04f, 0.18f,0.4f,
                                                        0.15f, 0.15f, 0.15f, 0.15f });

                #region Primera Linea

                //Columna 1
                cell = new PdfPCell(new Paragraph("Libro", FontFactory.GetFont("Arial", 6f))) {  HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);
                
                //Columna 2,3
                cell = new PdfPCell(new Paragraph("File", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                //Columna 2,3
                cell = new PdfPCell(new Paragraph("Comprob.", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                //Columna 4
                cell = new PdfPCell(new Paragraph("FECHA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                //Columna 5
                cell = new PdfPCell(new Paragraph("TD", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                //Columna 5
                cell = new PdfPCell(new Paragraph("DOCUMENTO", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                //Columna 5
                cell = new PdfPCell(new Paragraph("GLOSA", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                //Columna 6,7
                cell = new PdfPCell(new Paragraph("DOLARES", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Colspan = 2;
                TablaCabDetalle.AddCell(cell);

                //Columna 8,9
                cell = new PdfPCell(new Paragraph("SOLES", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                cell.Colspan = 2;
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                #endregion

                #region Segunda Linea
               
                //Columna 5
                cell = new PdfPCell(new Paragraph("DEBE", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                //Columna 6
                cell = new PdfPCell(new Paragraph("HABER", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);
               
                //Columna 7
                cell = new PdfPCell(new Paragraph("DEBE", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);
                
                //Columna 8
                cell = new PdfPCell(new Paragraph("HABER", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();
                #endregion

                document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
                #endregion
            }
        }

        #endregion

    }
}
