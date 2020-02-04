using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.CtasPorCobrar;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.CtasPorCobrar.Reportes
{
    public partial class frmReporteCobranzasConciliados : FrmMantenimientoBase
    {

        public frmReporteCobranzasConciliados()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            BuscarImagen();
            LlenarCombos();
        }

        #region Variables

        CtasPorCobrarServiceAgent AgenteCtasPorCobrar { get { return new CtasPorCobrarServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<CobranzasItemE> oListaReporte = null;
        String RutaGeneral = String.Empty;
        String RutaImagen = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        int tipoProceso = Variables.Cero; //0 exportar, 1 Buscar
        Int32 letra = 0;

        #endregion

        #region Procedimientos Usuario

        void LlenarCombos()
        {
            //Bancos
            List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListarBancos.Add(new BancosE() { idPersona = Variables.Cero, RazonSocial = Variables.Seleccione });
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "RazonSocial");

            //Monedas
            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in oListaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");

            oListaMonedas = null;
            oListarBancos = null;
        }

        void LlenarCuentasBancarias(Int32 idBanco, String idMoneda)
        {
            List<BancosCuentasE> oListaCuentas = AgenteMaestro.Proxy.ListarCuentasPorBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idBanco, idMoneda);
            ComboHelper.RellenarCombos<BancosCuentasE>(cboCuentas, (from x in oListaCuentas orderby x.idPersona select x).ToList(), "codCuenta", "numCuenta");

            if (cboCuentas.SelectedValue != null)
            {
                txtCodCuenta.Text = cboCuentas.SelectedValue.ToString();
                ObtenerCuentaContable(txtCodCuenta.Text.Trim());
            }
            else
            {
                txtCodCuenta.Text = "";
                txtNomCuenta.Text = "";
            }

            oListaCuentas = null;
        }

        void ObtenerCuentaContable(String Cuenta)
        {
            BancosCuentasE oBancoTmp = AgenteMaestro.Proxy.ObtenerBancosPorCodCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCodCuenta.Text);
            txtNomCuenta.Text = oBancoTmp.DescripcionCuenta;
        }

        void BuscarImagen()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void ConvertirApdf()
        {
            Document DocumentoPdf = new Document(PageSize.A2.Rotate(), 10f, 10f, 15f, 15f);

            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Conciliacion Cobranzas " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Cobranzas");
            DocumentoPdf.AddSubject("Reporte Conciliados");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = "REPORTE COBRANZAS CONCILIADAS";

                    BaseColor ColorFondo1 = new BaseColor(0, 102, 204); //Cabeceras del detalle conciliados
                    BaseColor ColorFondo2 = new BaseColor(204, 204, 255); //Cabeceras del detalle bancos
                    BaseColor ColorLetraDet = new BaseColor(0, 0, 128); //Letra del detalle
                    BaseColor ColorLetraTitulos = new BaseColor(0, 51, 102); //Letra del titulo
                    BaseColor ColorLetraSub = new BaseColor(51, 51, 153); //Letra del subtitulo
                    BaseColor ColorLetraSub2 = new BaseColor(153, 51, 102); //Letra del subtitulo

                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    #region Encabezado

                    PdfPTable tableEncabezado = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    tableEncabezado.SetWidths(new float[] { 0.9f, 0.13f });

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow(); //Fila completada

                    //Filas en blanco
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f), -1, -1, "S4"));
                    tableEncabezado.CompleteRow();

                    DocumentoPdf.Add(tableEncabezado); //Añadiendo la tabla al documento PDF

                    #endregion Encabezado

                    #region Titulos Principales

                    PdfPTable tableTitulos = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    tableTitulos.SetWidths(new float[] { 0.03f, 0.2f });
                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f)) { Rowspan = 2 };
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                        CeldaImagen.Rowspan = 2;
                    }
                    
                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 1, "N", "N", 4f, 5f));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 11f, iTextSharp.text.Font.BOLD, ColorLetraSub), 5, 1, "N", "N", 5f, 5f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S2"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos); //Añadiendo la tabla al documento PDF

                    #endregion 

                    #region Subtitulos

                    PdfPTable TablaDeta = new PdfPTable(25)
                    {
                        WidthPercentage = 100
                    };

                    TablaDeta.SetWidths(new float[] { 0.04f, 0.02f, 0.015f, 0.014f, 0.008f, 0.052f, 0.015f, 0.015f, 0.02f, 0.023f, 0.031f, 0.015f, 0.015f, 0.017f, 0.015f, 0.015f, 0.03f, 0.015f, 0.015f, 0.012f, 0.012f, 0.045f, 0.02f, 0.02f, 0.045f });

                    #region Subtitulos

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("MES     : ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 0));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(FechasHelper.NombreMes(dtpInicial.Value.Month).ToUpper(), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 0, "S4"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "S19"));
                    TablaDeta.CompleteRow();

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("DESDE: ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 0));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(dtpInicial.Value.ToString("dd/MM/yyyy") + " HASTA: " + dtpFinal.Value.ToString("dd/MM/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 0, "S4"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "S19"));
                    TablaDeta.CompleteRow();

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "S5"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("BANCO:", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 1));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(((BancosE)cboBancosEmpresa.SelectedItem).RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 8.25f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 0, "S19"));
                    TablaDeta.CompleteRow();

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0, "S5"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Nº CTA:", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 1));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(((BancosCuentasE)cboCuentas.SelectedItem).numCuenta, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraSub2), 5, 0, "S3"));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("MONEDA:", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraTitulos), 5, 0));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(((MonedasE)cboMoneda.SelectedItem).desAbreviatura, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, ColorLetraSub2), 5, 0, "S15"));
                    TablaDeta.CompleteRow();

                    //Lineas en Blanco
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S25"));
                    TablaDeta.CompleteRow();

                    #endregion

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("REGISTRADO", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "S14", "N", 6f, 3.5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("CONCILIADO", ColorFondo2, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4", "N", 6f, 3.5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 1, "S7", "N", 6f, 3.5f));
                    TablaDeta.CompleteRow();

                    #endregion

                    #region Detalle

                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Entidad", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Sucursal", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Fecha", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Tipo Pago", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Mon.", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Cuenta Bancaria", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Fecha Cobro", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("N° Oper.", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Dcto.", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("N° Doc.", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Referencia", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Importe", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Gastos Bancarios", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Cód.Pla.", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Fecha de Cobro o Pago", ColorFondo2, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("N° Oper.", ColorFondo2, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Concepto", ColorFondo2, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Imp. Total", ColorFondo2, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Saldo", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Cant. Dctos.", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Cant. Clientes", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Vendedor", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Cond.Pago", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Estado Doc.", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.AddCell(ReaderHelper.NuevaCelda("Usuario", ColorFondo1, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 5f, 5f));
                    TablaDeta.CompleteRow();

                    Int32 ItemCorre = 1;

                    foreach (CobranzasItemE item in oListaReporte)
                    {
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.RazonSocialEmpresa, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.desLocal, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                        if (item.Fecha == null)
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 0));
                        }
                        else
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Fecha.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                        }
        
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.TipoCobro, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.CuentaBancaria, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                        if (item.fecCobranza == null)
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 1));
                        }
                        else
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.fecCobranza.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                        }
                  
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numCheque, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.tipDocumento, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Documento, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Referencia.Trim(), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Monto.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda((item.Comision + item.Interes).ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.codPlanilla, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));

                        if (item.FechaConciliacion == null)
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda("", null, "N", null, FontFactory.GetFont("Arial", 6f), 5, 1));
                        }
                        else
                        {
                            TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.FechaConciliacion.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                        }

                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Operacion, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.GlosaBanco, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.MontoConciliacion.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Saldo.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 2));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numRegistros.ToString(), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.numClientes.ToString(), null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Vendedor, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.CondicionPago, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.Estado, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 1));
                        TablaDeta.AddCell(ReaderHelper.NuevaCelda(item.UsuarioRegistro, null, "N", null, FontFactory.GetFont("Arial", 6f, ColorLetraDet), 5, 0));

                        TablaDeta.CompleteRow();

                        ItemCorre++;
                    }

                    DocumentoPdf.Add(TablaDeta); //Añadiendo la tabla al documento PDF

                    #endregion

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //Establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    DocumentoPdf.Close();
                }
            }
        }

        void ExportarExcel(String Ruta)
        {
            if (oListaReporte.Count > Variables.Cero)
            {
                if (!String.IsNullOrEmpty(Ruta))
                {
                    if (File.Exists(Ruta)) File.Delete(Ruta);

                    FileInfo newFile = new FileInfo(Ruta);

                    using (ExcelPackage oExcel = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Conciliados");

                        if (oHoja != null)
                        {
                            Int32 InicioLinea = 9;
                            Int32 TotColumnas = 25;

                            #region Titulos Principales

                            oHoja.Cells["A1"].Value = "COBRANZAS CONCILIADAS";
                            oHoja.Row(1).Height = 25;

                            using (ExcelRange Rango = oHoja.Cells[1, 1, 1, 15])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                                Rango.Style.Font.Color.SetColor(Color.FromArgb(0, 51,102));
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                            }

                            oHoja.Cells["A2"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                            oHoja.Row(2).Height = 25;

                            using (ExcelRange Rango = oHoja.Cells[2, 1, 2, 15])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 12, FontStyle.Bold));
                                Rango.Style.Font.Color.SetColor(Color.FromArgb(51, 51, 153));
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                            }

                            oHoja.Cells["B4"].Value = "MES     :";
                            oHoja.Cells["B4"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["B4"].Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));

                            oHoja.Cells["C4"].Value = FechasHelper.NombreMes(dtpInicial.Value.Month).ToUpper();
                            oHoja.Cells["C4"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["C4"].Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));

                            oHoja.Cells["B5"].Value = "DESDE: ";
                            oHoja.Cells["B5"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["B5"].Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));

                            oHoja.Cells["C5"].Value = dtpInicial.Value.ToString("dd/MM/yyyy") + " HASTA: " + dtpFinal.Value.ToString("dd/MM/yyyy");
                            oHoja.Cells["C5"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["C5"].Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));

                            oHoja.Cells["F6"].Value = "BANCO:";
                            oHoja.Cells["F6"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["F6"].Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));

                            oHoja.Cells["G6"].Value = ((BancosE)cboBancosEmpresa.SelectedItem).RazonSocial;
                            oHoja.Cells["G6"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["G6"].Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));

                            oHoja.Cells["F7"].Value = "Nº CTA:";
                            oHoja.Cells["F7"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["F7"].Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));

                            oHoja.Cells["G7"].Value = ((BancosCuentasE)cboCuentas.SelectedItem).numCuenta;
                            oHoja.Cells["G7"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["G7"].Style.Font.Color.SetColor(Color.FromArgb(153, 51, 102));

                            oHoja.Cells["J7"].Value = "MONEDA:";
                            oHoja.Cells["J7"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["J7"].Style.Font.Color.SetColor(Color.FromArgb(0, 51, 102));

                            oHoja.Cells["K7"].Value = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                            oHoja.Cells["K7"].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells["K7"].Style.Font.Color.SetColor(Color.FromArgb(153, 51, 102));

                            #endregion

                            #region Detalle

                            #region Cabecera del detalle

                            oHoja.Cells[InicioLinea, 1].Value = "REGISTRADO";
                            oHoja.Row(InicioLinea).Height = 20;

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 14])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.Font.Color.SetColor(Color.White);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }

                            oHoja.Cells[InicioLinea, 15].Value = "CONCILIADO";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 15, InicioLinea, 18])
                            {
                                Rango.Merge = true;
                                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(204, 204, 255));
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }

                            InicioLinea++;

                            // Primera
                            oHoja.Cells[InicioLinea, 1].Value = "Entidad";
                            oHoja.Cells[InicioLinea, 2].Value = "Sucursal";
                            oHoja.Cells[InicioLinea, 3].Value = "Fecha";
                            oHoja.Cells[InicioLinea, 4].Value = "Tipo Pago";
                            oHoja.Cells[InicioLinea, 5].Value = "Mon.";
                            oHoja.Cells[InicioLinea, 6].Value = "Cuenta Bancaria";
                            oHoja.Cells[InicioLinea, 7].Value = "Fecha Cobro";
                            oHoja.Cells[InicioLinea, 8].Value = "N° Oper.";
                            oHoja.Cells[InicioLinea, 9].Value = "Dcto.";
                            oHoja.Cells[InicioLinea, 10].Value = "N° Doc.";
                            oHoja.Cells[InicioLinea, 11].Value = "Referencia";
                            oHoja.Cells[InicioLinea, 12].Value = "Importe ";
                            oHoja.Cells[InicioLinea, 13].Value = "Gastos Bancarios";
                            oHoja.Cells[InicioLinea, 14].Value = "Cód.Pla.";
                            oHoja.Cells[InicioLinea, 15].Value = "Fecha de Cobro o Pago";
                            oHoja.Cells[InicioLinea, 16].Value = "N° Oper.";
                            oHoja.Cells[InicioLinea, 17].Value = "Concepto";
                            oHoja.Cells[InicioLinea, 18].Value = "Imp. Total";
                            oHoja.Cells[InicioLinea, 19].Value = "Saldo";
                            oHoja.Cells[InicioLinea, 20].Value = "Cant. Dctos.";
                            oHoja.Cells[InicioLinea, 21].Value = "Cant. Clientes";
                            oHoja.Cells[InicioLinea, 22].Value = "Vendedor";
                            oHoja.Cells[InicioLinea, 23].Value = "Cond.Pago";
                            oHoja.Cells[InicioLinea, 24].Value = "Estado Doc.";
                            oHoja.Cells[InicioLinea, 25].Value = "Usuarios ";

                            for (int i = 1; i <= 25; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;

                                if ((i >= 1 && i <= 14) || (i >= 19 && i <= 25))
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.White);
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204));
                                }

                                if (i >= 15 && i <= 18)
                                {
                                    //oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.White);
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(204, 204, 255));
                                }

                                oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            }

                            oHoja.Row(InicioLinea).Height = 15; 

                            #endregion

                            //Aumentando una Fila mas continuar con el detalle
                            InicioLinea++;

                            foreach (CobranzasItemE item in oListaReporte)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.RazonSocialEmpresa;
                                oHoja.Cells[InicioLinea, 2].Value = item.desLocal;

                                if (item.Fecha == null)
                                {
                                    oHoja.Cells[InicioLinea, 3].Value = "";
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 3].Value = item.Fecha;
                                }

                                oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 4].Value = item.TipoCobro;
                                oHoja.Cells[InicioLinea, 5].Value = item.desMoneda;                      
                                oHoja.Cells[InicioLinea, 6].Value = item.CuentaBancaria;

                                if (item.fecCobranza == null)
                                {
                                    oHoja.Cells[InicioLinea, 7].Value = "";
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 7].Value = item.fecCobranza;
                                }

                                oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 8].Value = item.numCheque;
                                oHoja.Cells[InicioLinea, 9].Value = item.tipDocumento;
                                oHoja.Cells[InicioLinea, 10].Value = item.Documento;
                                oHoja.Cells[InicioLinea, 11].Value = item.Referencia;
                                oHoja.Cells[InicioLinea, 12].Value = item.Monto;
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 13].Value = item.Comision + item.Interes;
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 14].Value = item.codPlanilla;

                                if (item.FechaConciliacion == null)
                                {
                                    oHoja.Cells[InicioLinea, 15].Value = "";
                                }
                                else
                                {
                                    oHoja.Cells[InicioLinea, 15].Value = item.FechaConciliacion;
                                }

                                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 16].Value = item.Operacion;
                                oHoja.Cells[InicioLinea, 17].Value = item.GlosaBanco;
                                oHoja.Cells[InicioLinea, 18].Value = item.MontoConciliacion;
                                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 19].Value = item.Saldo;
                                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 20].Value = item.numRegistros;
                                oHoja.Cells[InicioLinea, 21].Value = item.numClientes;
                                oHoja.Cells[InicioLinea, 22].Value = item.Vendedor;
                                oHoja.Cells[InicioLinea, 23].Value = item.CondicionPago;
                                oHoja.Cells[InicioLinea, 24].Value = item.Estado;
                                oHoja.Cells[InicioLinea, 25].Value = item.UsuarioRegistro;

                                for (int i = 1; i <= 25; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                                    oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.FromArgb(0, 0, 128));

                                    if (i == 3 || i == 7 || i == 14 || i == 15)
                                    {
                                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    }
                                }

                                InicioLinea++;
                            }

                            #endregion

                            // Auto Filtro
                            oHoja.Cells[10, 1, 10, TotColumnas].AutoFilter = true;

                            //Ajustando el ancho de las columnas automaticamente
                            oHoja.Cells.AutoFitColumns();

                            oHoja.Column(3).Width = 10;
                            oHoja.Column(6).Width = 6;
                            oHoja.Column(7).Width = 10;
                            oHoja.Column(11).Width = 25;

                            //Insertando Encabezado
                            //oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                            //Pie de Pagina(Derecho) "Número de paginas y el total"
                            oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                            //Pie de Pagina(centro)
                            oHoja.HeaderFooter.OddFooter.CenteredText = "Cobranzas Conciliadas"; //ExcelHeaderFooter.SheetName;

                            //Otras Propiedades
                            //oHoja.Workbook.Properties.Title = TituloGeneral;
                            oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                            oHoja.Workbook.Properties.Subject = "Reportes";
                            //oHoja.Workbook.Properties.Keywords = "";
                            oHoja.Workbook.Properties.Category = "Módulo de Cobranzas";
                            //oHoja.Workbook.Properties.Comments = NombrePestaña;

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
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime Ini = dtpInicial.Value.Date;
                DateTime Fin = dtpFinal.Value.Date;
                String cod = txtCodCuenta.Text;

                if (tipoProceso == 1)
                {
                    //Obteniendo los datos de la BD
                    lblProcesando.Text = "Obteniendo las Cobranzas Conciliadas...";
                    oListaReporte = AgenteCtasPorCobrar.Proxy.ReporteCobranzasConciliados(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, cod, Ini, Fin, 1);
                    lblProcesando.Text = "Armando el Reporte de Cobranzas Conciliados...";
                    ConvertirApdf();//Generando el PDF
                }
                else
                {
                    ExportarExcel(RutaGeneral);
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
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            pnlParametros.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                if (tipoProceso == 1)
                {
                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                        tipoProceso = 0;
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Exportación Exitosa.");
                } 
            }
        }

        #endregion

        #region Procesos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaReporte.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Reporte de Cobranzas Conciliados", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = Variables.Cero;
                    lblProcesando.Visible = true;
                    timer.Enabled = true;
                    Marque = "Exportando el reporte de conciliación a Excel...";
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

        private void frmReporteCobranzasConciliados_Load(object sender, EventArgs e)
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
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
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

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboBancosEmpresa.SelectedValue) == 0)
                {
                    Global.MensajeAdvertencia("Debe escoger un banco.");
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtCodCuenta.Text))
                {
                    Global.MensajeAdvertencia("Debe escoger una Cta.Bancaria que tenga su Cuenta Contable.");
                    return;
                }

                tipoProceso = 1; //Reporte en Pdf
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

        private void cboBancosEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancosEmpresa.SelectedValue != null)
                {
                    LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMoneda.SelectedValue != null)
                {
                    LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboCuentas.SelectedValue != null)
            {
                txtCodCuenta.Text = cboCuentas.SelectedValue.ToString();
                ObtenerCuentaContable(txtCodCuenta.Text.Trim());
            }
            else
            {
                txtCodCuenta.Text = "";
                txtNomCuenta.Text = "";
            }
        }

        #endregion

    }
}
