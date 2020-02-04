using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using Negocio;
using ClienteWinForm.Busquedas;
using Entidades.Contabilidad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Presentadora.AgenteServicio;
using ClienteWinForm;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteRegistroComprasEspecial : FrmMantenimientoBase
    {


        #region variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        List<RegistroComprasE> oListaCompras;
        List<RegistroComprasE> oListaCabecera;

        readonly BackgroundWorker _bw = new BackgroundWorker();

        String RutaGeneral;
        String Accion;

        int idPersona = 0;

        String Marque = String.Empty;
        string tipo = "buscar";
        int idEmpresa;
        int idLocal;
        String VerPlanCuenta;
        String Anio;
        String mesIni;
        String mesFin;
        String moneda;

        String desMoneda;

        #endregion

        public frmReporteRegistroComprasEspecial()
        {   
            InitializeComponent();
        }

        private void frmReporteRegistroComprasEspecial_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            LlenarCombos();
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

            if (!String.IsNullOrEmpty(RutaGeneral))
            {
                wbNavegador.Navigate(RutaGeneral);
                RutaGeneral = String.Empty;
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "buscar";
                if (rdbDetalle.Checked)
                    Accion = "detalle";

                if (rdbValorVenta.Checked)
                    Accion = "resumen";

                if (rdbNaturaleza.Checked)
                    Accion = "naturaleza";

                if (rdbCuentas.Checked)
                    Accion = "cuenta";

                if (rdbIncluidoIGV.Checked)
                    Accion = "IGV";

                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                lblProcesando.Text = "Obteniendo registros ...";
                desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;

                Global.QuitarReferenciaWebBrowser(wbNavegador);

                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                idLocal = VariablesLocales.SesionLocal.IdLocal;
                VerPlanCuenta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                Anio = cboAnio.SelectedValue.ToString();
                mesIni = cboPeriodoIni.SelectedValue.ToString();
                mesFin = cboPeriodoFin.SelectedValue.ToString();
                moneda = cboMoneda.SelectedValue.ToString();

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                //btPle.Enabled = true;
                //btPdb.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (tipo == "buscar")
            {
                if (Accion == "detalle")
                {
                    oListaCompras = AgenteContabilidad.Proxy.ReporteDetalleComprasEspecial(idEmpresa, idLocal, idPersona, VerPlanCuenta, Anio, mesIni, mesFin, moneda);
                }
                else if (Accion == "resumen")
                {
                    oListaCompras = AgenteContabilidad.Proxy.ReporteResumenComprasEspecial(idEmpresa, idLocal, idPersona, VerPlanCuenta, Anio, mesIni, mesFin, moneda);
                }
                else if (Accion == "naturaleza")
                {
                    oListaCompras = AgenteContabilidad.Proxy.ReporteNaturalezaComprasEspecial(idEmpresa, idLocal, idPersona, VerPlanCuenta, Anio, mesIni, mesFin, moneda);
                }

                ConvertirApdf();

            }
            else
            {
                ExportarExcel(RutaGeneral);
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document((Accion == "detalle" || Accion == "naturaleza" ? PageSize.A4.Rotate() : PageSize.A4), 10f, 10f, 10f, 10f);
            String NombreReporte = @"\RegistroComprasEspecial2016";
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
                //String SubTitulo = String.Empty;
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
                
                // =======================
                // DETALLE
                // =======================

                int Columnas = 10;
                float[] ArrayColumnas = new float[] { 0.04f, 0.1f, 0.08f, 0.1f, 0.1f, 0.1f, 0.1f, 0.05f, 0.1f, 0.5f };
                String[] ArrayTitulos = new String[] { "TD", "Documento", "Fecha", "Base \n Grabado", "Base no \n Grabado", "IGV", "Total", "TC", "Comprobante", "Glosa" };

                String Titulo = "Detalle Compras Proveedores (" + desMoneda + ")";
                String SubTitulo = " De " + FechasHelper.NombreMes(Convert.ToInt32(mesIni)).ToUpper() + " a " + FechasHelper.NombreMes(Convert.ToInt32(mesFin)).ToUpper() + " del " + Anio;

                // =======================
                // IGV
                // =======================

                if (Accion == "IGV")
                {
                    Titulo = "Resumen Compras Proveedores (" + desMoneda + ") con IGV";

                    oListaCabecera = oListaCompras.GroupBy(x => x.Periodo).Select(g => g.First()).OrderBy(x => x.Periodo).ToList();

                    Columnas = oListaCabecera.Count + 3;

                    float[] ArrayColumnas_ = new float[oListaCabecera.Count + 3];
                    String[] ArrayTitulos_ = new String[oListaCabecera.Count + 3];

                    for (int i = 0; i < oListaCabecera.Count + 3; i++)
                    {
                        if (i == 0)
                        {
                            ArrayTitulos_[i] = "RUC";
                            ArrayColumnas_[i] = 0.1f;
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
                            ArrayTitulos_[i] = oListaCabecera[i - 3].desMes.ToUpper();
                            ArrayColumnas_[i] = 0.09f;
                        }
                    }

                    ArrayColumnas = ArrayColumnas_;
                    ArrayTitulos = ArrayTitulos_;
                }

                // =======================
                // CUENTA
                // =======================

                if (Accion == "cuenta")
                {
                    Titulo = "Compras Proveedores por Cuenta (" + desMoneda + ")";

                    int Col = 5;
                    oListaCabecera = oListaCompras.GroupBy(x => x.codCuenta).Select(g => g.First()).OrderBy(x => x.codCuenta).ToList();

                    Columnas = oListaCabecera.Count + Col;

                    float[] ArrayColumnas_ = new float[oListaCabecera.Count + Col];
                    String[] ArrayTitulos_ = new String[oListaCabecera.Count + Col];

                    for (int i = 0; i < oListaCabecera.Count + Col; i++)
                    {
                        if (i == 0)
                        {
                            ArrayTitulos_[i] = "RUC";
                            ArrayColumnas_[i] = 0.12f;
                        }
                        else if (i == 1)
                        {
                            ArrayTitulos_[i] = "Razon Social";
                            ArrayColumnas_[i] = 0.2f;
                        }
                        else if (i == 2)
                        {
                            ArrayTitulos_[i] = "TD";
                            ArrayColumnas_[i] = 0.04f;
                        }
                        else if (i == 3)
                        {
                            ArrayTitulos_[i] = "Serie";
                            ArrayColumnas_[i] = 0.06f;
                        }
                        else if (i == 4)
                        {
                            ArrayTitulos_[i] = "Documento";
                            ArrayColumnas_[i] = 0.09f;
                        }
                        //else if (i == 5)
                        //{
                        //    ArrayTitulos_[i] = "Total";
                        //    ArrayColumnas_[i] = 0.08f;
                        //}
                        else
                        {
                            ArrayTitulos_[i] = oListaCabecera[i - Col].codCuenta;
                            ArrayColumnas_[i] = 0.1f;
                        }
                    }

                    ArrayColumnas = ArrayColumnas_;
                    ArrayTitulos = ArrayTitulos_;
                }

                if (Accion == "resumen")
                {
                    Titulo = "Resumen Compras Proveedores (" + desMoneda + ") Val. Venta";

                    oListaCabecera = oListaCompras.GroupBy(x => x.Periodo).Select(g => g.First()).OrderBy(x => x.Periodo).ToList();

                    Columnas = oListaCabecera.Count + 3;

                    float[] ArrayColumnas_ = new float[oListaCabecera.Count + 3];
                    String[] ArrayTitulos_ = new String[oListaCabecera.Count + 3];

                    for (int i = 0; i < oListaCabecera.Count + 3; i++)
                    {
                        if (i == 0)
                        {
                            ArrayTitulos_[i] = "RUC";
                            ArrayColumnas_[i] = 0.1f;
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
                            ArrayTitulos_[i] = oListaCabecera[i - 3].desMes.ToUpper();
                            ArrayColumnas_[i] = 0.09f;
                        }
                    }

                    ArrayColumnas = ArrayColumnas_;
                    ArrayTitulos = ArrayTitulos_;
                }

                if (Accion == "naturaleza")
                {
                    Titulo = "Compras Proveedores por Naturaleza (" + desMoneda + ")";

                    int Col = 5;
                    oListaCabecera = oListaCompras.GroupBy(x => x.codCuenta).Select(g => g.First()).OrderBy(x => x.codCuenta).ToList();

                    Columnas = oListaCabecera.Count + Col;

                    float[] ArrayColumnas_ = new float[oListaCabecera.Count + Col];
                    String[] ArrayTitulos_ = new String[oListaCabecera.Count + Col];

                    for (int i = 0; i < oListaCabecera.Count + Col; i++)
                    {
                        if (i == 0)
                        {
                            ArrayTitulos_[i] = "RUC";
                            ArrayColumnas_[i] = 0.12f;
                        }
                        else if (i == 1)
                        {
                            ArrayTitulos_[i] = "Razon Social";
                            ArrayColumnas_[i] = 0.2f;
                        }
                        else if (i == 2)
                        {
                            ArrayTitulos_[i] = "TD";
                            ArrayColumnas_[i] = 0.04f;
                        }
                        else if (i == 3)
                        {
                            ArrayTitulos_[i] = "Serie";
                            ArrayColumnas_[i] = 0.06f;
                        }
                        else if (i == 4)
                        {
                            ArrayTitulos_[i] = "Número";
                            ArrayColumnas_[i] = 0.09f;
                        }
                        //else if (i == 5)
                        //{
                        //    ArrayTitulos_[i] = "Total";
                        //    ArrayColumnas_[i] = 0.08f;
                        //}
                        else
                        {
                            ArrayTitulos_[i] = oListaCabecera[i - Col].codCuenta;
                            ArrayColumnas_[i] = 0.1f;
                        }
                    }

                    ArrayColumnas = ArrayColumnas_;
                    ArrayTitulos = ArrayTitulos_;
                }

                PaginaInicioReporteComprasEspecial ev = new PaginaInicioReporteComprasEspecial();
                ev.Anio = Anio;
                ev.MesIni = mesIni;
                ev.MesFin = mesFin;

                ev.Columnas = Columnas;
                ev.ArrayColumnas = ArrayColumnas;
                ev.ArrayTitulos = ArrayTitulos;
                ev.Titulo = Titulo;
                ev.SubTitulo = SubTitulo;

                oPdfw.PageEvent = ev;

                docPdf.Open();

                #region Detalle



                PdfPTable TablaCabDetalle = new PdfPTable(Columnas);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(ArrayColumnas);

                if (Accion == "IGV")
                {
                    String ruc = "";

                    for (int i = 0; i < oListaCompras.Count; i++)
                    {
                        if (ruc == "")
                        {
                            ruc = oListaCompras[i].RUC;
                        }

                        if (i == 0 || ruc != oListaCompras[i].RUC)
                        {
                            ruc = oListaCompras[i].RUC;

                            cell = new PdfPCell(new Paragraph(oListaCompras[i].RUC, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph((oListaCabecera.Count > 9 ? oListaCompras[i].RazonSocial.Substring(0, (oListaCompras[i].RazonSocial.Length < 25 ? oListaCompras[i].RazonSocial.Length : 25)) : oListaCompras[i].RazonSocial), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == ruc).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == ruc &&
                                                                                            x.Periodo == oListaCabecera[c].Periodo
                                                                                            ).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            TablaCabDetalle.CompleteRow();
                        }
                    }
                }

                if (Accion == "naturaleza")
                {
                    String RucDocumento = "";
                    String Ruc = "";


                    String desRuc = "";
                    String desRazonSocial = "";

                    for (int i = 0; i < oListaCompras.Count; i++)
                    {
                        if (RucDocumento == "")
                        {
                            RucDocumento = oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento;

                        }

                        if (i == 0 || RucDocumento != oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento)
                        {
                            RucDocumento = oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento;



                            if (Ruc == oListaCompras[i].RUC)
                            {
                                desRuc = "";
                                desRazonSocial = "";
                            }
                            else
                            {
                                desRuc = oListaCompras[i].RUC;
                                desRazonSocial = oListaCompras[i].RazonSocial;
                            }

                            Ruc = oListaCompras[i].RUC;

                            cell = new PdfPCell(new Paragraph(desRuc, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(desRazonSocial.Substring(0, (desRazonSocial.Length > 15 ? 15 : desRazonSocial.Length)), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaCompras[i].idDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaCompras[i].serDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaCompras[i].numDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);





                            //cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == oListaCompras[i].RUC).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            //TablaCabDetalle.AddCell(cell);

                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == oListaCompras[i].RUC &&
                                                                                            x.idDocumento == oListaCompras[i].idDocumento &&
                                                                                            x.serDocumento == oListaCompras[i].serDocumento &&
                                                                                            x.numDocumento == oListaCompras[i].numDocumento
                                                                                            ).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            TablaCabDetalle.CompleteRow();
                        }
                    }
                }


                if (Accion == "cuenta")
                {
                    String RucDocumento = "";
                    String Ruc = "";


                    String desRuc = "";
                    String desRazonSocial = "";

                    for (int i = 0; i < oListaCompras.Count; i++)
                    {
                        if (RucDocumento == "")
                        {
                            RucDocumento = oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento;

                        }

                        if (i == 0 || RucDocumento != oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento)
                        {
                            RucDocumento = oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento;



                            if (Ruc == oListaCompras[i].RUC)
                            {
                                desRuc = "";
                                desRazonSocial = "";
                            }
                            else
                            {
                                desRuc = oListaCompras[i].RUC;
                                desRazonSocial = oListaCompras[i].RazonSocial;
                            }

                            Ruc = oListaCompras[i].RUC;

                            cell = new PdfPCell(new Paragraph(desRuc, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(desRazonSocial.Substring(0, (desRazonSocial.Length > 15 ? 15 : desRazonSocial.Length)), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaCompras[i].idDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaCompras[i].serDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaCompras[i].numDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);





                            //cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == oListaCompras[i].RUC).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            //TablaCabDetalle.AddCell(cell);

                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == oListaCompras[i].RUC &&
                                                                                            x.idDocumento == oListaCompras[i].idDocumento &&
                                                                                            x.serDocumento == oListaCompras[i].serDocumento &&
                                                                                            x.numDocumento == oListaCompras[i].numDocumento
                                                                                            ).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            TablaCabDetalle.CompleteRow();
                        }
                    }
                }

                if (Accion == "resumen")
                {
                    String ruc = "";

                    for (int i = 0; i < oListaCompras.Count; i++)
                    {
                        if (ruc == "")
                        {
                            ruc = oListaCompras[i].RUC;
                        }

                        if (i == 0 || ruc != oListaCompras[i].RUC)
                        {
                            ruc = oListaCompras[i].RUC;

                            cell = new PdfPCell(new Paragraph(oListaCompras[i].RUC, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph((oListaCabecera.Count > 9 ? oListaCompras[i].RazonSocial.Substring(0, (oListaCompras[i].RazonSocial.Length < 25 ? oListaCompras[i].RazonSocial.Length : 25)) : oListaCompras[i].RazonSocial), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == ruc).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            for (int c = 0; c < oListaCabecera.Count; c++)
                            {
                                cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == ruc &&
                                                                                            x.Periodo == oListaCabecera[c].Periodo
                                                                                            ).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);
                            }

                            TablaCabDetalle.CompleteRow();
                        }
                    }
                }

                if (Accion == "detalle")
                {
                    String Mes = "-1";
                    String Ruc = "-1";

                    decimal RucTotal = 0;
                    decimal RucBaseGravado = 0;
                    decimal RucBaseNoGravado = 0;
                    decimal RucIgvGrabado = 0;

                    decimal MesTotal = 0;
                    decimal MesBaseGravado = 0;
                    decimal MesBaseNoGravado = 0;
                    decimal MesIgvGrabado = 0;

                    decimal GeneralTotal = 0;
                    decimal GeneralBaseGravado = 0;
                    decimal GeneralBaseNoGravado = 0;
                    decimal GeneralIgvGrabado = 0;

                    foreach (RegistroComprasE item in oListaCompras)
                    {

                        if (Ruc == "-1")
                        {
                            Ruc = item.RUC;

                            cell = new PdfPCell(new Paragraph(" Proveedor : " + item.RUC + " - " + item.RazonSocial, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = Columnas;
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();
                        }
                        if (Mes == "-1")
                        {
                            Mes = item.Periodo;

                            cell = new PdfPCell(new Paragraph(" Mes : " + FechasHelper.NombreMes(Convert.ToInt32(item.Periodo)), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = Columnas;
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();
                        }




                        if (Ruc != item.RUC)
                        {
                            // =================
                            // TOTALES MES
                            // =================

                            cell = new PdfPCell(new Paragraph(" Total " + FechasHelper.NombreMes(Convert.ToInt32(Mes)) + " :", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 3;
                            TablaCabDetalle.AddCell(cell);


                            cell = new PdfPCell(new Paragraph(MesBaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(MesBaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(MesIgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(MesTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            MesBaseGravado = 0;
                            MesBaseNoGravado = 0;
                            MesIgvGrabado = 0;
                            MesTotal = 0;


                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 3;
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            // =================
                            // TOTALES RUC
                            // =================

                            cell = new PdfPCell(new Paragraph(" Total " + Ruc + " :", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 3;
                            TablaCabDetalle.AddCell(cell);


                            cell = new PdfPCell(new Paragraph(RucBaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(RucBaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(RucIgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(RucTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            RucBaseGravado = 0;
                            RucBaseNoGravado = 0;
                            RucIgvGrabado = 0;
                            RucTotal = 0;

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 3;
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            // =================
                            // TITULO PROVEEDOR
                            // =================

                            Ruc = item.RUC;

                            cell = new PdfPCell(new Paragraph(" Proveedor : " + item.RUC + " - " + item.RazonSocial, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = Columnas;
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            // =================
                            // TITULO MES
                            // =================

                            Mes = item.Periodo;

                            cell = new PdfPCell(new Paragraph("Mes : " + FechasHelper.NombreMes(Convert.ToInt32(item.Periodo)), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = Columnas;
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();
                        }

                        if (Mes != item.Periodo)
                        {

                            // =================
                            // TOTALES MES
                            // =================

                            cell = new PdfPCell(new Paragraph(" Total " + FechasHelper.NombreMes(Convert.ToInt32(Mes)) + " :", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 3;
                            TablaCabDetalle.AddCell(cell);


                            cell = new PdfPCell(new Paragraph(MesBaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(MesBaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(MesIgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(MesTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            TablaCabDetalle.AddCell(cell);

                            MesBaseGravado = 0;
                            MesBaseNoGravado = 0;
                            MesIgvGrabado = 0;
                            MesTotal = 0;


                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                            cell.Colspan = 3;
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            // =================
                            // TITULO MES
                            // =================

                            Mes = item.Periodo;

                            cell = new PdfPCell(new Paragraph("Mes : " + FechasHelper.NombreMes(Convert.ToInt32(item.Periodo)), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = Columnas;
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();
                        }

                        cell = new PdfPCell(new Paragraph(item.idDocumentoRef, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.numDocumentoRef, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.fecDocumento.Value.ToString("dd/mm/yyyy"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        TablaCabDetalle.AddCell(cell);

                        //cell = new PdfPCell(new Paragraph(item.RUC, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        //TablaCabDetalle.AddCell(cell);

                        //cell = new PdfPCell(new Paragraph(item.RazonSocial, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        //TablaCabDetalle.AddCell(cell);


                        cell = new PdfPCell(new Paragraph(item.BaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.BaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.IgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.Total.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        MesBaseGravado += item.BaseGravado;
                        MesBaseNoGravado += item.BaseNoGravado;
                        MesIgvGrabado += item.IgvGrabado;
                        MesTotal += item.Total;

                        RucBaseGravado += item.BaseGravado;
                        RucBaseNoGravado += item.BaseNoGravado;
                        RucIgvGrabado += item.IgvGrabado;
                        RucTotal += item.Total;

                        GeneralBaseGravado += item.BaseGravado;
                        GeneralBaseNoGravado += item.BaseNoGravado;
                        GeneralIgvGrabado += item.IgvGrabado;
                        GeneralTotal += item.Total;

                        cell = new PdfPCell(new Paragraph(item.tipCambio.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);



                        cell = new PdfPCell(new Paragraph(item.numFile + " " + item.numVoucher, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.GlosaGeneral, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }

                    // =================
                    // END FOR
                    // =================

                    // =================
                    // TOTALES MES
                    // =================

                    cell = new PdfPCell(new Paragraph(" Total " + FechasHelper.NombreMes(Convert.ToInt32(Mes)) + " :", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = 3;
                    TablaCabDetalle.AddCell(cell);


                    cell = new PdfPCell(new Paragraph(MesBaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(MesBaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(MesIgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(MesTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = 3;
                    TablaCabDetalle.AddCell(cell);

                    TablaCabDetalle.CompleteRow();

                    // =================
                    // TOTALES RUC
                    // =================

                    cell = new PdfPCell(new Paragraph(" Total " + Ruc + " :", FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = 3;
                    TablaCabDetalle.AddCell(cell);


                    cell = new PdfPCell(new Paragraph(RucBaseGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(RucBaseNoGravado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(RucIgvGrabado.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(RucTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    cell.Colspan = 3;
                    TablaCabDetalle.AddCell(cell);

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


        private void button1_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                idPersona = oFrm.oPersona.IdPersona;
                txtRuc.Text = oFrm.oPersona.RUC;
                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
            }
        }

        void LlenarCombos()
        {

            /////ANIOS/////
            int anioFin = Convert.ToInt32(VariablesLocales.FechaHoy.Year);
            int anioInicio = anioFin - 10;


            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
            cboAnio.SelectedValue = VariablesLocales.FechaHoy.Year;

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            /////PERIODO////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataTable oDt2 = FechasHelper.CargarMesesContable("MA");

            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            DataRow Fila2 = oDt2.NewRow();
            Fila2["MesId"] = "0";
            Fila2["MesDes"] = Variables.Todos;
            oDt2.Rows.Add(Fila2);

            oDt.DefaultView.Sort = "MesId";
            oDt2.DefaultView.Sort = "MesId";

            cboPeriodoIni.DataSource = oDt;
            cboPeriodoIni.ValueMember = "MesId";
            cboPeriodoIni.DisplayMember = "MesDes";
            cboPeriodoIni.SelectedValue = "00";

            cboPeriodoFin.DataSource = oDt2;
            cboPeriodoFin.ValueMember = "MesId";
            cboPeriodoFin.DisplayMember = "MesDes";
            cboPeriodoFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;
        }

        private void chbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            idPersona = 0;

            if (chbProveedor.Checked)
            {
                txtRuc.Enabled = true;
                txtRazonSocial.Enabled = true;

                txtRuc.BackColor = Color.LightSteelBlue;
                txtRazonSocial.BackColor = Color.LightSteelBlue;
            }
            else
            {
                txtRuc.Enabled = false;
                txtRazonSocial.Enabled = false;

                txtRuc.BackColor = Color.White;
                txtRazonSocial.BackColor = Color.White;
            }
        }

        private void rdbDetalle_CheckedChanged(object sender, EventArgs e)
        {
            rdbDetalle.ForeColor = Color.Black;
            rdbValorVenta.ForeColor = Color.Black;
            rdbNaturaleza.ForeColor = Color.Black;
            rdbCuentas.ForeColor = Color.Black;
            rdbIncluidoIGV.ForeColor = Color.Black;

            rdbDetalle.ForeColor = Color.Navy;
        }

        private void rdbValorVenta_CheckedChanged(object sender, EventArgs e)
        {
            rdbDetalle.ForeColor = Color.Black;
            rdbValorVenta.ForeColor = Color.Black;
            rdbNaturaleza.ForeColor = Color.Black;
            rdbCuentas.ForeColor = Color.Black;
            rdbIncluidoIGV.ForeColor = Color.Black;

            rdbValorVenta.ForeColor = Color.Navy;
        }

        private void rdbNaturaleza_CheckedChanged(object sender, EventArgs e)
        {
            rdbDetalle.ForeColor = Color.Black;
            rdbValorVenta.ForeColor = Color.Black;
            rdbNaturaleza.ForeColor = Color.Black;
            rdbCuentas.ForeColor = Color.Black;
            rdbIncluidoIGV.ForeColor = Color.Black;

            rdbNaturaleza.ForeColor = Color.Navy;
        }

        private void rdbCuentas_CheckedChanged(object sender, EventArgs e)
        {
            rdbDetalle.ForeColor = Color.Black;
            rdbValorVenta.ForeColor = Color.Black;
            rdbNaturaleza.ForeColor = Color.Black;
            rdbCuentas.ForeColor = Color.Black;
            rdbIncluidoIGV.ForeColor = Color.Black;

            rdbCuentas.ForeColor = Color.Navy;
        }

        private void rdbIncluidoIGV_CheckedChanged(object sender, EventArgs e)
        {
            rdbDetalle.ForeColor = Color.Black;
            rdbValorVenta.ForeColor = Color.Black;
            rdbNaturaleza.ForeColor = Color.Black;
            rdbCuentas.ForeColor = Color.Black;
            rdbIncluidoIGV.ForeColor = Color.Black;

            rdbIncluidoIGV.ForeColor = Color.Navy;
        }

        #region FormatoExcel

        public override void Exportar()
        {
            try
            {
                if (oListaCompras == null || oListaCompras.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String NombreLocal = Convert.ToString(VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString());
                if (NombreLocal == "<<TODOS>>")
                    NombreLocal = "-TODOS-";
                else
                    NombreLocal = "-" + Convert.ToString(VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString());

                String Mes = Convert.ToString(cboPeriodoIni.Text);
                String MesFin = Convert.ToString(cboPeriodoFin.Text);

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Regitros Compras" + NombreLocal + "-" + "Desde el Mes" + Mes + " Hasta El Mes" + MesFin, "Archivos Excel (*.xlsx)|*.xlsx");

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



            TituloGeneral = " Resumen Compras Vendedores " + " Al Año " + Anio + " De " + FechasHelper.NombreMes(Convert.ToInt32(mesIni)).ToUpper() + " a " + FechasHelper.NombreMes(Convert.ToInt32(mesFin)).ToUpper() + " del " + Anio;
            NombrePestaña = " Resumen Compras Vendedores ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {


                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 12;

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

                    if (Accion == "resumen")
                    {
                        oListaCabecera = oListaCompras.GroupBy(x => x.Periodo).Select(g => g.First()).OrderBy(x => x.Periodo).ToList();
                        TotColumnas = 4;

                        oHoja.Cells[InicioLinea, 1].Value = " RUC ";
                        oHoja.Cells[InicioLinea, 2].Value = " Razon Social ";
                        oHoja.Cells[InicioLinea, 3].Value = " Total ";

                        for (int i = 1; i <= 3; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }




                        Int32 LineaDeMes = 4;


                        for (int i = 0; i < oListaCabecera.Count; i++)
                        {
                            using (ExcelRange Rango = oHoja.Cells[4, LineaDeMes, 4, LineaDeMes])
                            {
                                Rango.Value = oListaCabecera[i].desMes;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                                LineaDeMes++;
                            }
                            
                        }

                        InicioLinea++;

                    }

                    if (Accion == "IGV")
                    {

                        oListaCabecera = oListaCompras.GroupBy(x => x.Periodo).Select(g => g.First()).OrderBy(x => x.Periodo).ToList();

                        TotColumnas = 4;


                        oHoja.Cells[InicioLinea, 1].Value = " RUC ";
                        oHoja.Cells[InicioLinea, 2].Value = " Razon Social ";
                        oHoja.Cells[InicioLinea, 3].Value = " Total ";

                        for (int i = 1; i <= 3; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }




                        Int32 LineaDeMes = 4;


                        for (int i = 0; i < oListaCabecera.Count; i++)
                        {
                            using (ExcelRange Rango = oHoja.Cells[4, LineaDeMes, 4, LineaDeMes])
                            {
                                Rango.Value = oListaCabecera[i].desMes;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                                LineaDeMes++;
                            }

                        }

                        InicioLinea++;
                    
                    
                    }




                    if (Accion == "cuenta")
                    {

                        TotColumnas = 6;

                        oHoja.Cells[InicioLinea, 1].Value = " RUC ";
                        oHoja.Cells[InicioLinea, 2].Value = " Razon Social ";
                        oHoja.Cells[InicioLinea, 3].Value = " TD ";
                        oHoja.Cells[InicioLinea, 4].Value = " SERIE ";
                        oHoja.Cells[InicioLinea, 5].Value = " DOCUMENTO ";

                        for (int i = 1; i <= 5; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }



                        Int32 LineaDeMes = 6;


                        for (int i = 0; i < oListaCabecera.Count; i++)
                        {
                            using (ExcelRange Rango = oHoja.Cells[4, LineaDeMes, 4, LineaDeMes])
                            {
                                Rango.Value = oListaCabecera[i].codCuenta;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                                LineaDeMes++;
                            }

                        }


                        InicioLinea++;
                    
                    
                    }



                    if (Accion == "naturaleza")
                    {
                        oListaCabecera = oListaCompras.GroupBy(x => x.codCuenta).Select(g => g.First()).OrderBy(x => x.codCuenta).ToList();
                        TotColumnas = 6;

                        oHoja.Cells[InicioLinea, 1].Value = " RUC ";
                        oHoja.Cells[InicioLinea, 2].Value = " Razon Social ";
                        oHoja.Cells[InicioLinea, 3].Value = " TD ";
                        oHoja.Cells[InicioLinea, 4].Value = " SERIE ";
                        oHoja.Cells[InicioLinea, 5].Value = " NÚMERO ";

                        for (int i = 1; i <= 5; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }



                        Int32 LineaDeMes = 6;


                        for (int i = 0; i < oListaCabecera.Count; i++)
                        {
                            using (ExcelRange Rango = oHoja.Cells[4, LineaDeMes, 4, LineaDeMes])
                            {
                                Rango.Value = oListaCabecera[i].codCuenta;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                                LineaDeMes++;
                            }

                        }
                        

                        InicioLinea++;

                    }







                    if (Accion == "detalle")
                    {
                        TotColumnas = 10;

                        // PRIMERA
                        oHoja.Cells[InicioLinea, 1].Value = " TD ";
                        oHoja.Cells[InicioLinea, 2].Value = " DOCUMENTO ";
                        oHoja.Cells[InicioLinea, 3].Value = " FECHA ";

                        oHoja.Cells[InicioLinea, 4].Value = " BASE GRABADO ";

                        oHoja.Cells[InicioLinea, 5].Value = " BASE NO GRABADO";

                        oHoja.Cells[InicioLinea, 6].Value = " IGV ";

                        oHoja.Cells[InicioLinea, 7].Value = " TOTAL ";

                        oHoja.Cells[InicioLinea, 8].Value = " TC";

                        oHoja.Cells[InicioLinea,9].Value = " COMPROBANTE";

                        oHoja.Cells[InicioLinea, 10].Value = " GLOSA ";

                        for (int i = 1; i <= 10; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                        //Aumentando una Fila mas continuar con el detalle
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                        InicioLinea++;
                    }



                    #endregion

                      #endregion

                    #region Formato Excel

                        if (Accion == "detalle")
                        {
                            String Mes = "-1";
                    String Ruc = "-1";

                    decimal RucTotal = 0;
                    decimal RucBaseGravado = 0;
                    decimal RucBaseNoGravado = 0;
                    decimal RucIgvGrabado = 0;

                    decimal MesTotal = 0;
                    decimal MesBaseGravado = 0;
                    decimal MesBaseNoGravado = 0;
                    decimal MesIgvGrabado = 0;

                    decimal GeneralTotal = 0;
                    decimal GeneralBaseGravado = 0;
                    decimal GeneralBaseNoGravado = 0;
                    decimal GeneralIgvGrabado = 0;

                        foreach (RegistroComprasE item in oListaCompras)
                       {

                        if (Ruc == "-1")
                        {
                            Ruc = item.RUC;

                            oHoja.Cells[InicioLinea, 1].Value = " Proveedor : " + item.RUC + " - " + item.RazonSocial;
                         
                            InicioLinea++;
                        }
                        if (Mes == "-1")
                        {
                            Mes = item.Periodo;

                            oHoja.Cells[InicioLinea, 1].Value = " Mes : " + FechasHelper.NombreMes(Convert.ToInt32(item.Periodo));


                             InicioLinea++;
                        }




                        if (Ruc != item.RUC)
                        {
                            // =================
                            // TOTALES MES
                            // =================

                            oHoja.Cells[InicioLinea, 3].Value = " Total " + FechasHelper.NombreMes(Convert.ToInt32(Mes)) + " :";



                              oHoja.Cells[InicioLinea, 4].Value = MesBaseGravado;
                           

                             oHoja.Cells[InicioLinea, 5].Value = MesBaseNoGravado;
                           

                              oHoja.Cells[InicioLinea, 6].Value = MesIgvGrabado;
                          

                              oHoja.Cells[InicioLinea, 7].Value = MesTotal;
                       

                            MesBaseGravado = 0;
                            MesBaseNoGravado = 0;
                            MesIgvGrabado = 0;
                            MesTotal = 0;

                           

                            InicioLinea++;

                            // =================
                            // TOTALES RUC
                            // =================

                           oHoja.Cells[InicioLinea, 3].Value = " Total " + Ruc + " :";



                          oHoja.Cells[InicioLinea, 4].Value = RucBaseGravado;
                       

                            oHoja.Cells[InicioLinea, 5].Value = RucBaseNoGravado;
                           

                           oHoja.Cells[InicioLinea, 6].Value = RucIgvGrabado;
                         

                           oHoja.Cells[InicioLinea, 7].Value = RucTotal;

                           for (int i = 3; i <= 7; i++)
                           {
                               oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                           }

                            RucBaseGravado = 0;
                            RucBaseNoGravado = 0;
                            RucIgvGrabado = 0;
                            RucTotal = 0;

                          
                            InicioLinea++;

                            // =================
                            // TITULO PROVEEDOR
                            // =================

                            Ruc = item.RUC;

                             oHoja.Cells[InicioLinea, 1].Value = " Proveedor : " + item.RUC + " - " + item.RazonSocial;

                              InicioLinea++;

                            // =================
                            // TITULO MES
                            // =================

                            Mes = item.Periodo;

                            oHoja.Cells[InicioLinea, 1].Value = "Mes : " + FechasHelper.NombreMes(Convert.ToInt32(item.Periodo));
                          
                            InicioLinea++;
                        }

                        if (Mes != item.Periodo)
                        {

                            // =================
                            // TOTALES MES
                            // =================

                            oHoja.Cells[InicioLinea, 3].Value = " Total " + FechasHelper.NombreMes(Convert.ToInt32(Mes)) + " :";
          


                            oHoja.Cells[InicioLinea, 4].Value = MesBaseGravado;
                           

                            oHoja.Cells[InicioLinea, 5].Value = MesBaseNoGravado;
                      

                            oHoja.Cells[InicioLinea, 6].Value = MesIgvGrabado;
                        

                            oHoja.Cells[InicioLinea, 7].Value = MesTotal;

                            for (int i = 3; i <= 7; i++)
                            {                                
                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                            }

                            MesBaseGravado = 0;
                            MesBaseNoGravado = 0;
                            MesIgvGrabado = 0;
                            MesTotal = 0;

                            InicioLinea++;

                            // =================
                            // TITULO MES
                            // =================

                            Mes = item.Periodo;

                            oHoja.Cells[InicioLinea, 7].Value = "Mes : " + FechasHelper.NombreMes(Convert.ToInt32(item.Periodo));
                        

                            InicioLinea++;
                        }

                         oHoja.Cells[InicioLinea, 1].Value = item.idDocumentoRef;
                     

                        oHoja.Cells[InicioLinea, 2].Value = item.numDocumentoRef;
                

                         oHoja.Cells[InicioLinea, 3].Value = item.fecDocumento.Value.ToString("dd/mm/yyyy");
                    

                        //cell = new PdfPCell(new Paragraph(item.RUC, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                        //TablaCabDetalle.AddCell(cell);

                        //cell = new PdfPCell(new Paragraph(item.RazonSocial, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                        //TablaCabDetalle.AddCell(cell);


                         oHoja.Cells[InicioLinea, 4].Value = item.BaseGravado;
                     

                         oHoja.Cells[InicioLinea, 5].Value = item.BaseNoGravado;
                       

                          oHoja.Cells[InicioLinea, 6].Value = item.IgvGrabado;
                    

                         oHoja.Cells[InicioLinea, 7].Value = item.Total;
                  

                        MesBaseGravado += item.BaseGravado;
                        MesBaseNoGravado += item.BaseNoGravado;
                        MesIgvGrabado += item.IgvGrabado;
                        MesTotal += item.Total;

                        RucBaseGravado += item.BaseGravado;
                        RucBaseNoGravado += item.BaseNoGravado;
                        RucIgvGrabado += item.IgvGrabado;
                        RucTotal += item.Total;

                        GeneralBaseGravado += item.BaseGravado;
                        GeneralBaseNoGravado += item.BaseNoGravado;
                        GeneralIgvGrabado += item.IgvGrabado;
                        GeneralTotal += item.Total;

                        oHoja.Cells[InicioLinea, 8].Value = item.tipCambio;
                     

                       oHoja.Cells[InicioLinea, 9].Value = item.numFile + " " + item.numVoucher;
                    

                       oHoja.Cells[InicioLinea, 10].Value = item.GlosaGeneral;
                       

                          InicioLinea++;
                    }

                    // =================
                    // END FOR
                    // =================

                    // =================
                    // TOTALES MES
                    // =================

                        oHoja.Cells[InicioLinea, 3].Value = " Total " + FechasHelper.NombreMes(Convert.ToInt32(Mes)) + " :";
                  

                     oHoja.Cells[InicioLinea, 4].Value = MesBaseGravado;
               

                    oHoja.Cells[InicioLinea, 5].Value = MesBaseNoGravado;
                 

                    oHoja.Cells[InicioLinea, 6].Value = MesIgvGrabado;
                 

                    oHoja.Cells[InicioLinea, 7].Value = MesTotal;

                    for (int i = 3; i <= 7; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                    }
                 


                    InicioLinea++;

                    // =================
                    // TOTALES RUC
                    // =================

                    oHoja.Cells[InicioLinea, 3].Value =" Total " + Ruc + " :";


                     oHoja.Cells[InicioLinea, 4].Value = RucBaseGravado;
                  

                    oHoja.Cells[InicioLinea, 5].Value = RucBaseNoGravado;
                

                     oHoja.Cells[InicioLinea, 6].Value = RucIgvGrabado;
                 

                     oHoja.Cells[InicioLinea, 7].Value = RucTotal;

                     for (int i = 3; i <= 7; i++)
                     {
                         oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                     }
                    
                      InicioLinea++;

                }
                       

                        if (Accion == "naturaleza")
                        {
                            String RucDocumento = "";
                            String Ruc = "";


                            String desRuc = "";
                            String desRazonSocial = "";

                            for (int i = 0; i < oListaCompras.Count; i++)
                            {
                                if (RucDocumento == "")
                                {
                                    RucDocumento = oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento;

                                }

                                if (i == 0 || RucDocumento != oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento)
                                {
                                    RucDocumento = oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento;



                                    if (Ruc == oListaCompras[i].RUC)
                                    {
                                        desRuc = "";
                                        desRazonSocial = "";
                                    }
                                    else
                                    {
                                        desRuc = oListaCompras[i].RUC;
                                        desRazonSocial = oListaCompras[i].RazonSocial;
                                    }

                                    Ruc = oListaCompras[i].RUC;

                                    oHoja.Cells[InicioLinea, 1].Value = desRuc;

                                   oHoja.Cells[InicioLinea, 2].Value = desRazonSocial.Substring(0, (desRazonSocial.Length > 15 ? 15 : desRazonSocial.Length));


                                    oHoja.Cells[InicioLinea, 3].Value = oListaCompras[i].idDocumento;


                                    oHoja.Cells[InicioLinea,4].Value = oListaCompras[i].serDocumento;


                                    oHoja.Cells[InicioLinea, 5].Value = oListaCompras[i].numDocumento;
 





                                    //cell = new PdfPCell(new Paragraph(oListaCompras.Where(x => x.RUC == oListaCompras[i].RUC).ToList().Sum(x => x.Total).ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                    //TablaCabDetalle.AddCell(cell);

                                    for (int c = 0; c < oListaCabecera.Count; c++)
                                    {
                                        oHoja.Cells[InicioLinea, c + TotColumnas].Value =oListaCompras.Where(x => x.RUC == oListaCompras[i].RUC &&
                                                                                                    x.idDocumento == oListaCompras[i].idDocumento &&
                                                                                                    x.serDocumento == oListaCompras[i].serDocumento &&
                                                                                                    x.numDocumento == oListaCompras[i].numDocumento
                                                                                                    ).ToList().Sum(x => x.Total);
                                        oHoja.Cells[InicioLinea, c + TotColumnas].Style.Numberformat.Format = "###,###,##0.00";

                                    }
                                    InicioLinea++;
                                }
                            }

                        }



                        if (Accion == "cuenta")
                        {


                            String RucDocumento = "";
                            String Ruc = "";


                            String desRuc = "";
                            String desRazonSocial = "";

                            for (int i = 0; i < oListaCompras.Count; i++)
                            {
                                if (RucDocumento == "")
                                {
                                    RucDocumento = oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento;

                                }

                                if (i == 0 || RucDocumento != oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento)
                                {
                                    RucDocumento = oListaCompras[i].RUC + oListaCompras[i].idDocumento + oListaCompras[i].serDocumento + oListaCompras[i].numDocumento;



                                    if (Ruc == oListaCompras[i].RUC)
                                    {
                                        desRuc = "";
                                        desRazonSocial = "";
                                    }
                                    else
                                    {
                                        desRuc = oListaCompras[i].RUC;
                                        desRazonSocial = oListaCompras[i].RazonSocial;
                                    }

                                    Ruc = oListaCompras[i].RUC;

                                    oHoja.Cells[InicioLinea, 1].Value = desRuc;


                                    oHoja.Cells[InicioLinea, 2].Value =desRazonSocial.Substring(0, (desRazonSocial.Length > 15 ? 15 : desRazonSocial.Length));


                                    oHoja.Cells[InicioLinea, 3].Value = oListaCompras[i].idDocumento;


                                    oHoja.Cells[InicioLinea, 4].Value = oListaCompras[i].serDocumento;


                                    oHoja.Cells[InicioLinea, 5].Value = oListaCompras[i].numDocumento;
                                    

                                    for (int c = 0; c < oListaCabecera.Count; c++)
                                    {
                                        oHoja.Cells[InicioLinea, c + TotColumnas].Value = oListaCompras.Where(x => x.RUC == oListaCompras[i].RUC &&
                                                                                                    x.idDocumento == oListaCompras[i].idDocumento &&
                                                                                                    x.serDocumento == oListaCompras[i].serDocumento &&
                                                                                                    x.numDocumento == oListaCompras[i].numDocumento
                                                                                                    ).ToList().Sum(x => x.Total);
                                          oHoja.Cells[InicioLinea, c + TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                                    }

                                    InicioLinea++;
                                }
                            }
                        
                        
                        }


                        if (Accion == "IGV")
                        {


                            String ruc = "";

                            for (int i = 0; i < oListaCompras.Count; i++)
                            {
                                if (ruc == "")
                                {
                                    ruc = oListaCompras[i].RUC;
                                }

                                if (i == 0 || ruc != oListaCompras[i].RUC)
                                {
                                    ruc = oListaCompras[i].RUC;

                                    oHoja.Cells[InicioLinea, 1].Value = oListaCompras[i].RUC;


                                    oHoja.Cells[InicioLinea, 2].Value = oListaCabecera.Count > 9 ? oListaCompras[i].RazonSocial.Substring(0, (oListaCompras[i].RazonSocial.Length < 25 ? oListaCompras[i].RazonSocial.Length : 25)) : oListaCompras[i].RazonSocial;


                                    oHoja.Cells[InicioLinea, 3].Value = oListaCompras.Where(x => x.RUC == ruc).ToList().Sum(x => x.Total);
                                    oHoja.Cells[InicioLinea, 3].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";


                                    for (int c = 0; c < oListaCabecera.Count; c++)
                                    {
                                        oHoja.Cells[InicioLinea, c + TotColumnas].Value = oListaCompras.Where(x => x.RUC == ruc &&
                                                                                                    x.Periodo == oListaCabecera[c].Periodo
                                                                                                    ).ToList().Sum(x => x.Total);
                                        oHoja.Cells[InicioLinea, c + TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                                    }



                                    InicioLinea++;
                                }
                            }
                        }

                            if (Accion == "resumen")
                            {
                                String ruc = ""; 
                                for (int i = 0; i < oListaCompras.Count; i++)
                                {
                                    if (ruc == "")
                                    {
                                        ruc = oListaCompras[i].RUC;
                                    }

                                    if (i == 0 || ruc != oListaCompras[i].RUC)
                                    {
                                        ruc = oListaCompras[i].RUC;

                                        oHoja.Cells[InicioLinea, 1].Value = oListaCompras[i].RUC;


                                        oHoja.Cells[InicioLinea, 2].Value = oListaCabecera.Count > 9 ? oListaCompras[i].RazonSocial.Substring(0, (oListaCompras[i].RazonSocial.Length < 25 ? oListaCompras[i].RazonSocial.Length : 25)) : oListaCompras[i].RazonSocial;


                                       oHoja.Cells[InicioLinea, 3].Value = oListaCompras.Where(x => x.RUC == ruc).ToList().Sum(x => x.Total);
                                       oHoja.Cells[InicioLinea, 3].Style.Font.Bold = true;
                                       oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";


                                        for (int c = 0; c < oListaCabecera.Count; c++)
                                        {
                                            oHoja.Cells[InicioLinea, c + TotColumnas].Value = oListaCompras.Where(x => x.RUC == ruc &&
                                                                                                        x.Periodo == oListaCabecera[c].Periodo
                                                                                                        ).ToList().Sum(x => x.Total);
                                            oHoja.Cells[InicioLinea, c + TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                                        }

                                      

                                        InicioLinea++;
                                    }
                                }
                            }
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
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

                        //Guardando el excel
                        oExcel.Save();

                    }
                }

                        #endregion



        
            }
        }
    }




#region Inicio Pdf

class PaginaInicioReporteComprasEspecial : PdfPageEventHelper
{
    public String Anio { get; set; }
    
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
        //Chunk ch = new Chunk("This is my Stack Overflow Header on page " + writer.PageNumber);
        //document.Add(ch);

        //String TituloGeneral = String.Empty;
        //String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        PdfPCell cell = null;


        
        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.8f, 0.12f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        cell = new PdfPCell(new Paragraph("                            " + Titulo, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
        table.AddCell(cell);
        cell = new PdfPCell(new Paragraph("Fecha: " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("                            " + SubTitulo, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
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

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6.0f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph("RUC   " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 6.0f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 6.0f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
        cell.Colspan = 2;
        table.AddCell(cell);
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6.5f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))) { Border = 0 };
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


        for(int i =0; i < ArrayTitulos.Length; i++)
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
