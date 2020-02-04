using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
using System.Windows.Forms;

#region Uso General

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

#endregion

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Negocio;

#endregion

#region Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using ClienteWinForm;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteRegistroLibroMayor : FrmMantenimientoBase
    {
        public frmReporteRegistroLibroMayor()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroLibroMayorE> oListaLibroMayor = null;

        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        Int32 letra = 0;
        Int32 tipoProceso = 0; // 1 buscar; 0 exportar;
        readonly BackgroundWorker _bw = new BackgroundWorker();

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

            if (listaLocales.Count <= 2)
            {
                cboSucursales.SelectedValue = 1;
            }

            cboPeriodoIni.DataSource = FechasHelper.CargarMesesContable("PM");
            cboPeriodoIni.ValueMember = "MesId";
            cboPeriodoIni.DisplayMember = "MesDes";
            cboPeriodoIni.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            cboPeriodoFin.DataSource = FechasHelper.CargarMesesContable("PM");
            cboPeriodoFin.ValueMember = "MesId";
            cboPeriodoFin.DisplayMember = "MesDes";
            cboPeriodoFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            MonedasE item = new MonedasE() { idMoneda = "99", desMoneda = "Ambas Monedas" };
            ListaMoneda.Add(item);
            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              where (x.idMoneda == Variables.Soles) 
                                                              || (x.idMoneda == Variables.Dolares)
                                                              || (x.idMoneda == "99")
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desMoneda");
        }

        //void CargarLista(String param1, String param2, String param3, String param4, String param5, String param6, String param7, String param8)
        //{
        //    RegistroDiarioE objRegistroDiario = new RegistroDiarioE();
        //    objRegistroDiario.Nivel1 = param1;
        //    objRegistroDiario.desCuenta = param2;
        //    objRegistroDiario.TD = param3;
        //    objRegistroDiario.numDocumento = param4;
        //    objRegistroDiario.Fecha = param5;
        //    objRegistroDiario.GlosaGeneral = param6;
        //    objRegistroDiario.idDocumento = param7;
        //    objRegistroDiario.idComprobante = param8;
        //    listRegistroDiario.Add(objRegistroDiario);
        //}

        void ListaReporte()
        {
            try
            {
                String MesIni = cboPeriodoIni.SelectedValue.ToString();
                String MesFin = cboPeriodoFin.SelectedValue.ToString();
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                String CuentaIni = txtCuentaIni.Text.Trim();
                String CuentaFin = txtCuentaFin.Text.Trim();

                if (String.IsNullOrEmpty(CuentaIni))
                {
                    CuentaIni = CuentaIni.PadLeft(VariablesLocales.VersionPlanCuentasActual.Longitud, '0');
                }

                if (String.IsNullOrEmpty(CuentaFin))
                {
                    CuentaFin = CuentaFin.PadLeft(VariablesLocales.VersionPlanCuentasActual.Longitud, '9');
                }

                //Obteniendo los datos de la BD
                oListaLibroMayor = AgenteContabilidad.Proxy.RegistroLibroMayor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, VariablesLocales.PeriodoContable.AnioPeriodo, MesIni, MesFin, CuentaIni, CuentaFin);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = String.Empty;
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            if (cboPeriodoIni.SelectedValue.ToString() == cboPeriodoFin.SelectedValue.ToString())
            {
                NombreReporte = @"\Libro Mayor " + cboPeriodoIni.Text + " " + VariablesLocales.PeriodoContable.AnioPeriodo + " " + Aleatorio.ToString();
                TituloCabecera = cboPeriodoIni.Text.ToUpper() + " " + VariablesLocales.PeriodoContable.AnioPeriodo;
            }
            else
            {
                NombreReporte = @"\Libro Mayor " + cboPeriodoIni.Text + " al " + cboPeriodoFin.Text + " " + VariablesLocales.PeriodoContable.AnioPeriodo + " " + Aleatorio.ToString();
                TituloCabecera = cboPeriodoIni.Text.ToUpper().ToUpper() + " A " + cboPeriodoFin.Text.ToUpper() + " " + VariablesLocales.PeriodoContable.AnioPeriodo;
            }

            docPdf.AddAuthor("AMAZONTIC SAC");
            docPdf.AddCreator("AMAZONTIC SAC");
            docPdf.AddCreationDate();
            docPdf.AddTitle("Libro Mayor");
            docPdf.AddSubject("Para el PLE");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte + " " + Guid.NewGuid().ToString() + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    PagRegInicioLibroMayor ev = new PagRegInicioLibroMayor();
                    ev.Periodos = TituloCabecera;
                    ev.Moneda = cboMonedas.SelectedValue.ToString();
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    float[] WidthColumna = null;
                    PdfPTable TablaCabDetalle = null;

                    switch (cboMonedas.SelectedValue.ToString())
                    {
                        case Variables.Soles:
                        case Variables.Dolares:

                            WidthColumna = new float[] { 0.07f, 0.14f, 0.04f, 0.11f, 0.07f, 0.4f, 0.04f, 0.10f, 0.10f };
                            TablaCabDetalle = new PdfPTable(9);
                            TablaCabDetalle.WidthPercentage = 100;
                            TablaCabDetalle.SetWidths(WidthColumna);

                            DetalleReporte(TablaCabDetalle, cboMonedas.SelectedValue.ToString(), oListaLibroMayor);

                            break;
                        case "99":

                            WidthColumna = new float[] { 0.12f, 0.2f, 0.05f, 0.15f, 0.1f, 0.4f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f };
                            TablaCabDetalle = new PdfPTable(11);
                            TablaCabDetalle.WidthPercentage = 100;
                            TablaCabDetalle.SetWidths(WidthColumna);

                            break;
                        default:

                            break;
                    }

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

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

        void ObtenerDescripcionCuenta(TextBox txtcuenta, TextBox txtdescripcion)
        {
            if (!String.IsNullOrEmpty(txtcuenta.Text.Trim()))
            {
                txtdescripcion.Text = AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtcuenta.Text.ToString());
            }
            else
            {
                txtdescripcion.Text = String.Empty;
            }
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = "Libro Mayor";
            String NombrePestaña = "Mayor";

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
                    Int32 InicioLinea = 1;
                    Int32 TotColumnas = 19;

        //            #region Cabecera

        //            #region Primera Linea Cabecera

                    oHoja.Cells[InicioLinea, 1].Value = "Año";
                    oHoja.Cells[InicioLinea, 2].Value = "Periodo";
                    oHoja.Cells[InicioLinea, 3].Value = "Mes";
                    oHoja.Cells[InicioLinea, 4].Value = "Libro";
                    oHoja.Cells[InicioLinea, 5].Value = "File";
                    oHoja.Cells[InicioLinea, 6].Value = "Comprobante";
                    oHoja.Cells[InicioLinea, 7].Value = "Item";
                    oHoja.Cells[InicioLinea, 8].Value = "Moneda";
                    oHoja.Cells[InicioLinea, 9].Value = "TC";
                    oHoja.Cells[InicioLinea, 10].Value = "TD";
                    oHoja.Cells[InicioLinea, 11].Value = "Cuenta";
                    oHoja.Cells[InicioLinea, 12].Value = "Documento";
                    oHoja.Cells[InicioLinea, 13].Value = "F. Documento";
                    oHoja.Cells[InicioLinea, 14].Value = "Fecha";
                    oHoja.Cells[InicioLinea, 15].Value = "Glosa";
                    oHoja.Cells[InicioLinea, 16].Value = "Importe Soles";
                    oHoja.Cells[InicioLinea, 17].Value = "Importe Dolares";
                    oHoja.Cells[InicioLinea, 18].Value = "Debe/Haber";
                    oHoja.Cells[InicioLinea, 19].Value = "Cuenta Descripción";

                    for (int i = 1; i <= TotColumnas; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;
        //            #endregion

        //            InicioLinea++;

        //            #endregion

        //            //Aumentando una Fila mas continuar con el detalle

        //            #region Datos

        //            foreach (RegistroDiarioE item in OListaRegistroDeDiario)
        //            {
        //                oHoja.Cells[InicioLinea, 1].Value = item.AnioPeriodo;
        //                oHoja.Cells[InicioLinea, 2].Value = item.MesPeriodo;
        //                oHoja.Cells[InicioLinea, 3].Value = item.desPeriodo;
        //                oHoja.Cells[InicioLinea, 4].Value = item.idComprobante;
        //                oHoja.Cells[InicioLinea, 5].Value = item.numFile;
        //                oHoja.Cells[InicioLinea, 6].Value = item.numVoucher;
        //                oHoja.Cells[InicioLinea, 7].Value = item.numItem;
        //                oHoja.Cells[InicioLinea, 8].Value = item.desMoneda;
        //                oHoja.Cells[InicioLinea, 9].Value = item.tipCambio;
        //                oHoja.Cells[InicioLinea, 10].Value = item.idDocumento;
        //                oHoja.Cells[InicioLinea, 11].Value = item.codCuenta;
        //                oHoja.Cells[InicioLinea, 12].Value = item.numDocumento;
        //                oHoja.Cells[InicioLinea, 13].Value = (item.fecDocumento == null ? "" : (item.fecDocumento.Value.Year == 1900 ? "" : Convert.ToDateTime(item.fecDocumento).ToString("dd/MM/yy")));

        //                //oHoja.Cells[InicioLinea, 14].Value = (item.Fecha == null ? "" : (item.fecOperacion.Value.Year == 1900 ? "" : Convert.ToDateTime(item.fecOperacion).ToString("dd/MM/yy") ) ) ;
        //                oHoja.Cells[InicioLinea, 14].Value = item.Fecha;
        //                oHoja.Cells[InicioLinea, 15].Value = item.GlosaGeneral;
        //                oHoja.Cells[InicioLinea, 16].Value = item.impSoles;
        //                oHoja.Cells[InicioLinea, 17].Value = item.impDolares;
        //                oHoja.Cells[InicioLinea, 18].Value = item.indDebeHaber;
        //                oHoja.Cells[InicioLinea, 19].Value = item.desCuenta;

        //                InicioLinea++;

        //                //if (!item.IdDocumento.Equals("")) oHoja.Cells[InicioLinea, 7].Value = Convert.ToDecimal(item.IdDocumento);
        //                //else oHoja.Cells[InicioLinea, 7].Value = item.IdDocumento;

        //                //if (!item.IdComprobante.Equals("")) oHoja.Cells[InicioLinea, 8].Value = Convert.ToDecimal(item.IdComprobante);
        //                //else oHoja.Cells[InicioLinea, 8].Value = item.IdComprobante;

        //                //if (!item.Nivel1.Equals("") && !item.desCuenta.Equals("") && item.TD.Equals("") && item.NumDocumento.Equals("") && item.Fecha.Equals("") && !item.IdDocumento.Equals("") && !item.IdComprobante.Equals(""))
        //                //{
        //                //    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 8])
        //                //    {
        //                //        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
        //                //        InicioLinea++;
        //                //    }
        //                //}
        //                //else if (item.Nivel1.Equals("") && item.desCuenta.Equals("") && item.TD.Equals("") && item.NumDocumento.Equals("") && item.Fecha.Equals("") && !item.IdDocumento.Equals("") && !item.IdComprobante.Equals(""))
        //                //{
        //                //    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea, 8])
        //                //    {
        //                //        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
        //                //        InicioLinea++;
        //                //    }
        //                //}
        //                //else
        //                //{
        //                //    InicioLinea++;
        //                //}

        //            }
        //            #endregion

        //            //Linea
        //            Int32 totFilas = InicioLinea;
        //            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

        //            //Suma
        //            InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

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

        void DetalleReporte(PdfPTable pDetalle, String Moneda, List<RegistroLibroMayorE> oListaMayor)
        {
            try
            {
                #region Variables Tipo de Letra
                
                iTextSharp.text.Font fontCuentas = FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLDITALIC);
                iTextSharp.text.Font fontDetalle = FontFactory.GetFont("Arial", 6f);
                iTextSharp.text.Font fontSaldos = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontSaldos2 = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(System.Drawing.Color.DarkRed));
                iTextSharp.text.Font fontSaldos3 = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(System.Drawing.Color.DarkGreen));
                iTextSharp.text.Font fontSaldos4 = FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(System.Drawing.Color.MidnightBlue));

                #endregion Variables Tipo de Letra

                #region Variables para el proceso
                
                var ListaAgrupada = oListaMayor.GroupBy(x => x.codCuenta).Select(p => p.First()).ToList();
                List<RegistroLibroMayorE> oListaTemporal = null;
                String CuentaCab = String.Empty;
                String desCuentaCab = String.Empty;
                String CuentaSub = String.Empty;
                String desCuentaSub = String.Empty;
                String Cuenta = String.Empty;
                String desCuenta = String.Empty;
                String Movimientos = String.Empty;
                
                #endregion Variables para el proceso

                #region Variables para los montos
                
                Decimal totDebe = Variables.ValorCeroDecimal;
                Decimal totHaber = Variables.ValorCeroDecimal;
                Decimal totDebeGeneral = Variables.ValorCeroDecimal;
                Decimal totHaberGeneral = Variables.ValorCeroDecimal;
                Decimal antMontoDebe = Variables.ValorCeroDecimal;
                Decimal antMontoHaber = Variables.ValorCeroDecimal;
                Decimal antMontoDebe2 = Variables.ValorCeroDecimal;
                Decimal antMontoHaber2 = Variables.ValorCeroDecimal;
                Decimal antMontoDebe1 = Variables.ValorCeroDecimal;
                Decimal antMontoHaber1 = Variables.ValorCeroDecimal;
                Decimal antMontoDebe0 = Variables.ValorCeroDecimal;
                Decimal antMontoHaber0 = Variables.ValorCeroDecimal;
                //Decimal antSaldoDebe = Variables.ValorCeroDecimal;
                //Decimal antSaldoHaber = Variables.ValorCeroDecimal;
                //Decimal antSaldoDebe2 = Variables.ValorCeroDecimal;
                //Decimal antSaldoHaber2 = Variables.ValorCeroDecimal;
                //Decimal antSaldoDebe1 = Variables.ValorCeroDecimal;
                //Decimal antSaldoHaber1 = Variables.ValorCeroDecimal;
                //Decimal antSaldoDebe0 = Variables.ValorCeroDecimal;
                //Decimal antSaldoHaber0 = Variables.ValorCeroDecimal;
                
                #endregion Variables para los montos

                switch (Moneda)
                {
                    case Variables.Soles:

                        foreach (var itemAgrupado in ListaAgrupada)
                        {
                            //oListaTemporal = new List<RegistroLibroMayorE>(oListaMayor.Where(x => x.codCuenta.Contains(itemAgrupado.codCuenta)).OrderBy(o => o.Fecha));
                            oListaTemporal = new List<RegistroLibroMayorE>((from x in oListaLibroMayor
                                                                            where x.codCuenta.Contains(itemAgrupado.codCuenta)
                                                                            && !String.IsNullOrEmpty(x.idComprobante)
                                                                            orderby x.Fecha
                                                                            select x).ToList());

                            foreach (RegistroLibroMayorE item in oListaTemporal)
                            {
                                if (item.codCuenta != CuentaSub)
                                {
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S9", "N", 1f, 1f));
                                    pDetalle.CompleteRow(); //Fila completada

                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.Nivel2, null, "N", null, fontCuentas, 1, 0, "N", "N", 1.3f, 1.3f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta2, null, "N", null, fontCuentas, 1, 0, "S9", "N", 1.3f, 1.3f));
                                    pDetalle.CompleteRow(); //Fila completada

                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.codCuenta, null, "N", null, fontCuentas, 1, 0, "N", "N", 1.3f, 1.3f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta, null, "N", null, fontCuentas, 1, 0, "S9", "N", 1.3f, 1.3f));
                                    pDetalle.CompleteRow(); //Fila completada

                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 2.25f), 1, 0, "S9", "N", 1f, 1f, "N", "S", "N", "N", 0.95f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S9", "N", 1f, 1f));
                                    pDetalle.CompleteRow(); //Fila completada
                                }

                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.Fecha.Value.ToString("d"), null, "N", null, fontDetalle, 1, 1, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.idComprobante + "-" + item.numVoucher + "-" + item.numFile + "-" + item.numItem, null, "N", null, fontDetalle, 1, 1, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, fontDetalle, 1, 1, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.serDocumento + '-' + item.numDocumento, null, "N", null, fontDetalle, 1, 0, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecDocumento.Value.ToString("d"), null, "N", null, fontDetalle, 1, 1, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.GlosaGeneral, null, "N", null, fontDetalle, 1, 0, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));

                                if (item.indDebeHaber == Variables.Debe)
                                {
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));

                                    totDebe += item.impSoles;
                                    totDebeGeneral += item.impSoles;
                                }
                                else
                                {
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));

                                    totHaber += item.impSoles;
                                    totHaberGeneral += item.impSoles;
                                }

                                pDetalle.CompleteRow();

                                CuentaCab = item.Nivel2;
                                desCuentaCab = item.desCuenta2;
                                CuentaSub = item.codCuenta;
                                desCuentaSub = item.desCuenta;
                                Cuenta = item.Nivel1;
                                desCuenta = item.desCuenta1;

                                antMontoDebe = item.antSolesDebe;
                                antMontoHaber = item.antSolesHaber;
                                antMontoDebe2 = item.antSolesDebe2;
                                antMontoHaber2 = item.antSolesHaber2;
                                antMontoDebe1 = item.antSolesDebe1;
                                antMontoHaber1 = item.antSolesHaber1;
                                antMontoDebe0 = item.antSolesDebe0;
                                antMontoHaber0 = item.antSolesHaber0;
                            }

                            #region Montos a digitos completos
                            
                            //Salto de Pagina
                            SaltoLinea(pDetalle);

                            Movimientos = GlosaMovimiento(CuentaSub + " " + desCuentaSub);
                            LineaMontos(pDetalle, fontDetalle, fontSaldos, Movimientos, totDebe, totHaber, antMontoDebe, antMontoHaber);
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, -1, -1, "S4", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(Movimientos, null, "N", null, fontSaldos, 1, 2, "S2", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos, 1, 1, "N", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(totDebe.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(totHaber.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
                            //pDetalle.CompleteRow(); //Fila completada

                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ANTERIOR", null, "N", null, fontSaldos, 1, 2, "S2", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos, 1, 1, "N", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(antMontoDebe.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(antMontoHaber.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
                            //pDetalle.CompleteRow(); //Fila completada

                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ACTUAL", null, "N", null, fontSaldos, 1, 2, "S2", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos, 1, 1, "N", "N", 1.3f, 1.3f));

                            //antSaldoDebe = DevolverMonto(Variables.Debe, totDebe, totHaber, antMontoDebe, antMontoHaber);
                            //antSaldoHaber = DevolverMonto(Variables.Haber, totDebe, totHaber, antMontoDebe, antMontoHaber);
                            ////if ((totDebe + antMontoDebe) - (totHaber + antMontoHaber) > 0)
                            ////{
                            ////    antSaldoDebe = (totDebe + antMontoDebe) - (totHaber + antMontoHaber);
                            ////}
                            ////else
                            ////{
                            ////    antSaldoDebe = 0;
                            ////}

                            ////if ((totDebe + antMontoDebe) - (totHaber + antMontoHaber) < 0)
                            ////{
                            ////    antSaldoHaber = Math.Abs((totDebe + antMontoDebe) - (totHaber + antMontoHaber));
                            ////}
                            ////else
                            ////{
                            ////    antSaldoHaber = 0;
                            ////}

                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(antSaldoDebe.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
                            //pDetalle.AddCell(ReaderHelper.NuevaCelda(antSaldoHaber.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
                            //pDetalle.CompleteRow(); //Fila completada

                            ////Salto de Pagina
                            SaltoLinea(pDetalle);

                            #endregion Montos a digitos completos

                            totDebe = Variables.ValorCeroDecimal;
                            totHaber = Variables.ValorCeroDecimal;
                            antMontoDebe = Variables.ValorCeroDecimal;
                            antMontoHaber = Variables.ValorCeroDecimal;
                            //antSaldoDebe = Variables.ValorCeroDecimal;
                            //antSaldoHaber = Variables.ValorCeroDecimal;
                        }

                        //Ultimas Lineas
                        #region Montos a 3 Digitos
		                
                        Movimientos = GlosaMovimiento(CuentaCab + " " + desCuentaCab);
                        LineaMontos(pDetalle, fontDetalle, fontSaldos2, Movimientos, totDebeGeneral, totHaberGeneral, antMontoDebe2, antMontoHaber2);
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, -1, -1, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(Movimientos, null, "N", null, fontSaldos2, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos2, 1, 1, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(totDebeGeneral.ToString("N2"), null, "N", null, fontSaldos2, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(totHaberGeneral.ToString("N2"), null, "N", null, fontSaldos2, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ANTERIOR", null, "N", null, fontSaldos2, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos2, 1, 1, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antMontoDebe2.ToString("N2"), null, "N", null, fontSaldos2, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antMontoHaber2.ToString("N2"), null, "N", null, fontSaldos2, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ACTUAL", null, "N", null, fontSaldos2, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos2, 1, 1, "N", "N", 1.3f, 1.3f));

                        //antSaldoDebe2 = DevolverMonto(Variables.Debe, totDebeGeneral, totHaberGeneral, antMontoDebe2, antMontoHaber2);
                        //antSaldoHaber2 = DevolverMonto(Variables.Haber, totDebeGeneral, totHaberGeneral, antMontoDebe2, antMontoHaber2);
                        
                        ////if ((totDebeGeneral + antMontoDebe2) - (totHaberGeneral + antMontoHaber2) > 0)
                        ////{
                        ////    antSaldoDebe2 = (totDebeGeneral + antMontoDebe2) - (totHaberGeneral + antMontoHaber2);
                        ////}
                        ////else
                        ////{
                        ////    antSaldoDebe2 = 0;
                        ////}

                        ////if ((totDebeGeneral + antMontoDebe2) - (totHaberGeneral + antMontoHaber2) < 0)
                        ////{
                        ////    antSaldoHaber2 = Math.Abs((totDebeGeneral + antMontoDebe2) - (totHaberGeneral + antMontoHaber2));
                        ////}
                        ////else
                        ////{
                        ////    antSaldoHaber2 = 0;
                        ////}

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antSaldoDebe2.ToString("N2"), null, "N", null, fontSaldos2, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antSaldoHaber2.ToString("N2"), null, "N", null, fontSaldos2, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada

                        #endregion Montos a 3 Digitos

                        ////Salto y linea
                        SaltoLinea(pDetalle);

                        #region Montos a 2 digitos                     

                        Movimientos = GlosaMovimiento(Cuenta + " " + desCuenta);
                        LineaMontos(pDetalle, fontDetalle, fontSaldos3, Movimientos, totDebeGeneral, totHaberGeneral, antMontoDebe1, antMontoHaber1);
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, -1, -1, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(Movimientos, null, "N", null, fontSaldos3, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos3, 1, 1, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(totDebeGeneral.ToString("N2"), null, "N", null, fontSaldos3, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(totHaberGeneral.ToString("N2"), null, "N", null, fontSaldos3, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ANTERIOR", null, "N", null, fontSaldos3, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos3, 1, 1, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antMontoDebe1.ToString("N2"), null, "N", null, fontSaldos3, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antMontoHaber1.ToString("N2"), null, "N", null, fontSaldos3, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ACTUAL", null, "N", null, fontSaldos3, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos3, 1, 1, "N", "N", 1.3f, 1.3f));

                        //antSaldoDebe1 = DevolverMonto(Variables.Debe, totDebeGeneral, totHaberGeneral, antMontoDebe1, antMontoHaber1);
                        //antSaldoHaber1 = DevolverMonto(Variables.Haber, totDebeGeneral, totHaberGeneral, antMontoDebe1, antMontoHaber1);

                        ////if ((totDebeGeneral + antMontoDebe1) - (totHaberGeneral + antMontoHaber1) > 0)
                        ////{
                        ////    antSaldoDebe1 = (totDebeGeneral + antMontoDebe1) - (totHaberGeneral + antMontoHaber1);
                        ////}
                        ////else
                        ////{
                        ////    antSaldoDebe1 = 0;
                        ////}

                        ////if ((totDebeGeneral + antMontoDebe1) - (totHaberGeneral + antMontoHaber1) < 0)
                        ////{
                        ////    antSaldoHaber1 = Math.Abs((totDebeGeneral + antMontoDebe1) - (totHaberGeneral + antMontoHaber1));
                        ////}
                        ////else
                        ////{
                        ////    antSaldoHaber1 = 0;
                        ////}

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antSaldoDebe1.ToString("N2"), null, "N", null, fontSaldos3, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antSaldoHaber1.ToString("N2"), null, "N", null, fontSaldos3, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada
                        
                        #endregion Montos a 2 digitos

                        ////Salto y linea
                        SaltoLinea(pDetalle);

                        #region Montos a 1 digitos

                        LineaMontos(pDetalle, fontDetalle, fontSaldos4, "MOVIMIENTOS", totDebeGeneral, totHaberGeneral, antMontoDebe0, antMontoHaber0, true);
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, -1, -1, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTOS", null, "N", null, fontSaldos4, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos4, 1, 1, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(totDebeGeneral.ToString("N2"), null, "N", null, fontSaldos4, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(totHaberGeneral.ToString("N2"), null, "N", null, fontSaldos4, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ANTERIOR", null, "N", null, fontSaldos4, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos4, 1, 1, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antMontoDebe0.ToString("N2"), null, "N", null, fontSaldos4, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antMontoHaber0.ToString("N2"), null, "N", null, fontSaldos4, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda("SALDO ACTUAL", null, "N", null, fontSaldos4, 1, 2, "S2", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos4, 1, 1, "N", "N", 1.3f, 1.3f));

                        //antSaldoDebe0 = totDebeGeneral + antMontoDebe0;
                        //antSaldoHaber0 = totHaberGeneral + antMontoHaber0;

                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antSaldoDebe0.ToString("N2"), null, "N", null, fontSaldos4, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.AddCell(ReaderHelper.NuevaCelda(antSaldoHaber0.ToString("N2"), null, "N", null, fontSaldos4, 1, 2, "N", "N", 1.3f, 1.3f));
                        //pDetalle.CompleteRow(); //Fila completada

                        SaltoLinea(pDetalle);

                        #endregion Montos a 1 digitos

                        break;
                    case Variables.Dolares:

                        foreach (var itemAgrupado in ListaAgrupada)
                        {
                            oListaTemporal = new List<RegistroLibroMayorE>((from x in oListaLibroMayor
                                                                            where x.codCuenta.Contains(itemAgrupado.codCuenta)
                                                                            && !String.IsNullOrEmpty(x.idComprobante)
                                                                            orderby x.Fecha
                                                                            select x).ToList());

                            foreach (RegistroLibroMayorE item in oListaTemporal)
                            {
                                if (item.codCuenta != CuentaSub)
                                {
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S9", "N", 1f, 1f));
                                    pDetalle.CompleteRow(); //Fila completada

                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.Nivel2, null, "N", null, fontCuentas, 1, 0, "N", "N", 1.3f, 1.3f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta2, null, "N", null, fontCuentas, 1, 0, "S9", "N", 1.3f, 1.3f));
                                    pDetalle.CompleteRow(); //Fila completada

                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.codCuenta, null, "N", null, fontCuentas, 1, 0, "N", "N", 1.3f, 1.3f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta, null, "N", null, fontCuentas, 1, 0, "S9", "N", 1.3f, 1.3f));
                                    pDetalle.CompleteRow(); //Fila completada

                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 2.25f), 1, 0, "S9", "N", 1f, 1f, "N", "S", "N", "N", 0.95f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 1, "S9", "N", 1f, 1f));
                                    pDetalle.CompleteRow(); //Fila completada
                                }

                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.Fecha.Value.ToString("d"), null, "N", null, fontDetalle, 1, 1, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.idComprobante + "-" + item.numVoucher + "-" + item.numFile + "-" + item.numItem, null, "N", null, fontDetalle, 1, 1, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, fontDetalle, 1, 1, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.serDocumento + '-' + item.numDocumento, null, "N", null, fontDetalle, 1, 0, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecDocumento.Value.ToString("d"), null, "N", null, fontDetalle, 1, 1, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.GlosaGeneral, null, "N", null, fontDetalle, 1, 0, "N", "N", 1.3f, 1.3f));
                                pDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));

                                if (item.indDebeHaber == Variables.Debe)
                                {
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));

                                    totDebe += item.impDolares;
                                    totDebeGeneral += item.impDolares;
                                }
                                else
                                {
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda("0.00", null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));
                                    pDetalle.AddCell(ReaderHelper.NuevaCelda(item.impSoles.ToString("N2"), null, "N", null, fontDetalle, 1, 2, "N", "N", 1.3f, 1.3f));

                                    totHaber += item.impDolares;
                                    totHaberGeneral += item.impDolares;
                                }

                                pDetalle.CompleteRow();

                                CuentaCab = item.Nivel2;
                                desCuentaCab = item.desCuenta2;
                                CuentaSub = item.codCuenta;
                                desCuentaSub = item.desCuenta;
                                Cuenta = item.Nivel1;
                                desCuenta = item.desCuenta1;

                                antMontoDebe = item.antDolarDebe;
                                antMontoHaber = item.antDolarHaber;
                                antMontoDebe2 = item.antDolarDebe2;
                                antMontoHaber2 = item.antDolarHaber2;
                                antMontoDebe1 = item.antDolarDebe1;
                                antMontoHaber1 = item.antDolarHaber1;
                                antMontoDebe0 = item.antDolarDebe0;
                                antMontoHaber0 = item.antDolarHaber0;
                            }

                            #region Montos a digitos completos
                            
                            SaltoLinea(pDetalle);
                            Movimientos = GlosaMovimiento(CuentaSub + " " + desCuentaSub);
                            LineaMontos(pDetalle, fontDetalle, fontSaldos, Movimientos, totDebe, totHaber, antMontoDebe, antMontoHaber);
                            SaltoLinea(pDetalle);

                            #endregion Montos a digitos completos

                            totDebe = Variables.ValorCeroDecimal;
                            totHaber = Variables.ValorCeroDecimal;
                            antMontoDebe = Variables.ValorCeroDecimal;
                            antMontoHaber = Variables.ValorCeroDecimal;
                            //antSaldoDebe = Variables.ValorCeroDecimal;
                            //antSaldoHaber = Variables.ValorCeroDecimal;
                        }

                        //Ultimas Lineas
                        #region Montos a 3 Digitos
		                
                        Movimientos = GlosaMovimiento(CuentaCab + " " + desCuentaCab);
                        LineaMontos(pDetalle, fontDetalle, fontSaldos2, Movimientos, totDebeGeneral, totHaberGeneral, antMontoDebe2, antMontoHaber2);
                        SaltoLinea(pDetalle);

                        #endregion Montos a 3 Digitos

                        #region Montos a 2 digitos                     

                        Movimientos = GlosaMovimiento(Cuenta + " " + desCuenta);
                        LineaMontos(pDetalle, fontDetalle, fontSaldos3, Movimientos, totDebeGeneral, totHaberGeneral, antMontoDebe1, antMontoHaber1);
                        SaltoLinea(pDetalle);

                        #endregion Montos a 2 digitos

                        #region Montos a 1 digitos

                        LineaMontos(pDetalle, fontDetalle, fontSaldos4, "MOVIMIENTOS", totDebeGeneral, totHaberGeneral, antMontoDebe0, antMontoHaber0, true);
                        SaltoLinea(pDetalle);

                        #endregion Montos a 1 digitos

                        break;
                    default:
                        break;
                }
            }
            catch (PdfException ex)
            {
                throw new PdfException(ex.Message);
            }
            catch (Exception ex2)
            {
                throw new Exception(ex2.Message);
            }
        }

        String GlosaMovimiento(String Descripcion)
        {
            String CadenaNueva = String.Empty;

            if (!String.IsNullOrEmpty(Descripcion))
            {
                if (Descripcion.Length > 66)
                {
                    CadenaNueva = Descripcion.Substring(0, 65);
                }
                else
                {
                    CadenaNueva = Descripcion;
                } 
            }

            return CadenaNueva;
        }

        void SaltoLinea(PdfPTable pLinea)
        {
            //Salto de Pagina
            pLinea.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), 1, 2, "S9", "N", 1f, 1f));
            pLinea.CompleteRow(); //Fila completada
            //Linea para dividir
            pLinea.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 1, 2, "S4", "N", 1f, 1f));
            pLinea.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 3.25f), 1, 2, "S5", "N", 1f, 1f, "S", "N", "N", "N", 0.95f));
            pLinea.CompleteRow(); //Fila completada
        }

        void LineaMontos(PdfPTable pDetalleMontos, iTextSharp.text.Font fontDetalle, iTextSharp.text.Font fontSaldos, String Glosa, Decimal totDebe, Decimal totHaber,
            Decimal antMontoDebe, Decimal antMontoHaber, Boolean Ultimo = false)
        {
            Decimal antSaldoDebe = Variables.ValorCeroDecimal;
            Decimal antSaldoHaber = Variables.ValorCeroDecimal;

            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, -1, -1, "S4", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(Glosa, null, "N", null, fontSaldos, 1, 2, "S2", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos, 1, 1, "N", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(totDebe.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(totHaber.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
            pDetalleMontos.CompleteRow(); //Fila completada

            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda("SALDO ANTERIOR", null, "N", null, fontSaldos, 1, 2, "S2", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos, 1, 1, "N", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(antMontoDebe.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(antMontoHaber.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
            pDetalleMontos.CompleteRow(); //Fila completada

            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, fontDetalle, 1, 2, "S4", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda("SALDO ACTUAL", null, "N", null, fontSaldos, 1, 2, "S2", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(">>>", null, "N", null, fontSaldos, 1, 1, "N", "N", 1.3f, 1.3f));

            if (!Ultimo)
            {
                antSaldoDebe = DevolverMonto(Variables.Debe, totDebe, totHaber, antMontoDebe, antMontoHaber);
                antSaldoHaber = DevolverMonto(Variables.Haber, totDebe, totHaber, antMontoDebe, antMontoHaber);    
            }
            else
            {
                antSaldoDebe = totDebe + antMontoDebe;
                antSaldoHaber = totHaber + antMontoHaber;
            }

            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(antSaldoDebe.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
            pDetalleMontos.AddCell(ReaderHelper.NuevaCelda(antSaldoHaber.ToString("N2"), null, "N", null, fontSaldos, 1, 2, "N", "N", 1.3f, 1.3f));
            pDetalleMontos.CompleteRow(); //Fila completada
        }

        Decimal DevolverMonto(String indDebeHaber, Decimal TotalD, Decimal TotalH, Decimal MontoDebe, Decimal MontoHaber)
        {
            Decimal MontoDevuelto = Variables.ValorCeroDecimal;

            if (indDebeHaber == Variables.Debe)
            {
                if ((TotalD + MontoDebe) - (TotalH + MontoHaber) > 0)
                {
                    MontoDevuelto = (TotalD + MontoDebe) - (TotalH + MontoHaber);
                }
                else
                {
                    MontoDevuelto = 0;
                } 
            }
            else
            {
                if ((TotalD + MontoDebe) - (TotalH + MontoHaber) < 0)
                {
                    MontoDevuelto = Math.Abs((TotalD + MontoDebe) - (TotalH + MontoHaber));
                }
                else
                {
                    MontoDevuelto = 0;
                }
            }

            return MontoDevuelto;
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            //Generando el PDF
            if (tipoProceso == 1)
            {
                lblProcesando.Text = "Obteniendo los registros del Libro Mayor...";
                ListaReporte();
                lblProcesando.Text = "Procesando el Reporte...";
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
            timer.Enabled = false;
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

        #endregion

        #region Eventos
        
        private void frmReporteRegistroLibroMayor_Load(object sender, EventArgs e)
        {
            Grid = true;
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

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void timer_Tick(object sender, EventArgs e)
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

        private void btPle_Click(object sender, EventArgs e)
        {

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
                this.Text = "Libro Mayor: " + cboSucursales.Text.ToString();
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
            frmBuscarCuentas frm = new frmBuscarCuentas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCuentaIni.Text = frm.Cuentas.codCuenta;
                txtDesCuentaIni.Text = frm.Cuentas.desCuenta;
            }
        }

        private void btnBusquedaCuentaFin_Click(object sender, EventArgs e)
        {
            frmBuscarCuentas frm = new frmBuscarCuentas();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCuentaFin.Text = frm.Cuentas.codCuenta;
                txtDesCuentaFin.Text = frm.Cuentas.desCuenta;
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

        #endregion Eventos
    }
}

class PagRegInicioLibroMayor : PdfPageEventHelper
{
    public String Periodos { get; set; }
    public String Moneda { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        #region Variables
        
        iTextSharp.text.BaseColor colCabDetalle = iTextSharp.text.BaseColor.LIGHT_GRAY;
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        String Anio = VariablesLocales.FechaHoy.Year.ToString();

        #endregion Variables

        TituloGeneral = "LIBRO MAYOR - " + Periodos;

        if (Moneda == Variables.Soles)
        {
            SubTitulo = "EXPRESADO EN SOLES";
        }
        else if (Moneda == Variables.Dolares)
        {
            SubTitulo = "EXPRESADO EN DOLARES";
        }
        else
        {
            SubTitulo = "AMBAS MONEDAS";
        }

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.9f, 0.13f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Encabezados

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Pag.    " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Hora:   " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        //Espacio en blanco
        table.SpacingAfter = 25f;
        table.CompleteRow(); //Fila completada

        #endregion

        #region Titulos Principales

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "S2"));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "S2"));
        table.CompleteRow(); //Fila completada

        ////Fila en blanco
        table.SpacingAfter = 10f;
        table.CompleteRow(); //Fila completada

        document.Add(table); //Añadiendo la tabla al documento PDF

        #endregion Titulos Principales

        #region Cabecera del Detalle

        float[] WidthColumna = null;
        PdfPTable TablaCabDetalle = null;

        switch (Moneda)
        {
            case Variables.Soles:
            case Variables.Dolares:

                WidthColumna = new float[] { 0.07f, 0.14f, 0.04f, 0.11f, 0.07f, 0.4f, 0.04f, 0.10f, 0.10f };
                TablaCabDetalle = new PdfPTable(9);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(WidthColumna);

                ////Columna 1
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Fecha Contable", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 2
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Diario/Vou/File/Item", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 3
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.D.", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 4
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Num. Documento", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 5
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Fecha", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 6
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Glosa", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 7
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 8
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Debe", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 9
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Haber", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));

                TablaCabDetalle.CompleteRow();

                document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                break;
            case "99":

                WidthColumna = new float[] { 0.12f, 0.2f, 0.05f, 0.15f, 0.1f, 0.4f, 0.13f, 0.13f, 0.13f, 0.13f, 0.13f };
                TablaCabDetalle = new PdfPTable(11);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(WidthColumna);

                #region Primera Linea

                ////Columna 1
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Fecha Contable", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "S2", 4f, 4f));
                ////Columna 2
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Diario/Comp/File/Item", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "S2", 4f, 4f));
                ////Columna 3
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.D.", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "S2", 4f, 4f));
                ////Columna 4
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Num. Documento", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "S2", 4f, 4f));
                ////Columna 5
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Fecha", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "S2", 4f, 4f));
                ////Columna 6
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Glosa", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "S2", 4f, 4f));
                ////Columna 7
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "S2", 4f, 4f));
                ////Columna 8, 9
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Soles", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "S2", "N", 4f, 4f));
                ////Columna 10, 11
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Dolares", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "S2", "N", 4f, 4f));

                TablaCabDetalle.CompleteRow();

                #endregion Primera Linea

                #region Segunda Linea

                ////Columna 8
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Debe", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 9
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Haber", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 10
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Debe", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));
                ////Columna 11
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("Haber", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), 1, 1, "N", "N", 4f, 4f));

                TablaCabDetalle.CompleteRow();

                #endregion Segunda Linea

                document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF 

                break;
            default:

                break;
        }

        #endregion Cabecera del Detalle

    }
}