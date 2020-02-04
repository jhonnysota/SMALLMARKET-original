using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

#region Para Pdf

using iTextSharp.text;
using iTextSharp.text.pdf;

#endregion

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteRegistroVentasDetallada : FrmMantenimientoBase
    {

        public frmReporteRegistroVentasDetallada()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<EmisionDocumentoE> oListaRegistrosVentaDetallada = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String tipo = "buscar";
        Int16 TipoReporte = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Establecimientos
            List<EstablecimientosE> oListaEstablecimientos = AgenteMaestro.Proxy.ListarEstablecimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
            oListaEstablecimientos.Add(new EstablecimientosE() { idEstablecimiento = Variables.Cero, Descripcion = Variables.Seleccione });
            ComboHelper.LlenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientos orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion");
            
            oListaEstablecimientos = null;
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A1.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Registro de Ventas Detallada " + Aleatorio.ToString();
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
                    int Columnas = TipoReporte == 1 ? 34 : 46;
                    float[] AnchosColumnas = null;

                    if (TipoReporte == 1)
                    {
                        AnchosColumnas = new float[] { 0.05f, 0.08f, 0.15f, 0.03f, 0.1f, 0.08f, 0.1f, 0.1f, 0.1f, 0.4f, 0.09f, 0.1f, 0.4f, 0.1f, 0.13f, 0.1f, 0.05f, 0.1f, 0.06f, 0.05f,
                                                        0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.03f, 0.12f, 0.12f, 0.08f, 0.12f, 0.09f, 0.09f, 0.15f, 0.25f };
                    }
                    else
                    {
                        AnchosColumnas = new float[] { 0.06f, 0.08f, 0.08f, 0.08f, 0.12f, 0.045f, 0.1f, 0.07f, 0.11f, 0.11f, 0.4f, 0.4f, 0.08f, 0.13f, 0.3f, 0.1f, 0.1f, 0.1f, 0.08f, 0.1f, 0.1f, 0.1f, 0.1f, 0.4f,
                                                        0.1f, 0.05f, 0.08f, 0.08f, 0.08f, 0.07f, 0.1f, 0.07f, 0.07f, 0.11f, 0.05f, 0.05f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.07f, 0.07f };
                    }

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    oPdfw.PageEvent = new InicioVentaDetallada()
                    {
                        Periodo = dtpInicio.Value.ToString("dd/MM/yyyy") + " al " + dtpFin.Value.ToString("dd/MM/yyyy"),
                        Empresa = VariablesLocales.SesionUsuario.Empresa.NombreComercial,
                        cantColumnas = Columnas,
                        AnchosColumnas = AnchosColumnas,
                        TipoRep = TipoReporte
                    };

                    docPdf.Open();

                    #region Detalle
                    
                    PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
                    {
                        WidthPercentage = 100
                    };

                    TablaCabDetalle.SetWidths(AnchosColumnas);
                    
                    Decimal TotCantidad = 0;
                    Decimal TotUnitarioSol = 0;
                    Decimal TotsubTotalSol = 0;
                    Decimal TotIgvSol = 0;
                    Decimal TotTotalS = 0;
                    Decimal TotUnitarioDol = 0;
                    Decimal TotsubTotalDol = 0;
                    Decimal TotIgvDol = 0;
                    Decimal TotTotalD = 0;

                    foreach (EmisionDocumentoE item in oListaRegistrosVentaDetallada)
                    {
                        if (TipoReporte == 1)
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Anio, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomMes, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Tipo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numSerie + " - " + item.numDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            //Por revisar//TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecEmision.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Guia, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Pedido, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));

                            if (item.idDocumento == "NC" || item.idDocumento == "ND")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoRef + "/" + Global.Derecha(item.serDocumentoRef, 3) + "-" + Global.Derecha(item.numDocumentoRef, 5), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Ruc, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desDivision, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.EspecieCaracteristica, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.VariedadCaracteristica, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ContenidoPres.ToString("N1"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.subTotalSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.IgvSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalS.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.subTotalDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.IgvDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCondicion, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numLetras, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));

                            if (item.FechaPago == null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaPago.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numOperacion, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda + " " + item.ImporteCobrado.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.indEstado, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desEstablecimiento, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomVendedor, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5)); 
                        }
                        else
                        {
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.AnioPedido, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Pedido, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Anio, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomMes, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Tipo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.numSerie + " - " + item.numDocumento, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            //Por revisar//TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.fecEmision.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Guia, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));

                            if (item.idDocumento == "NC" || item.idDocumento == "ND")
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.idDocumentoRef + "/" + Global.Derecha(item.serDocumentoRef, 3) + "-" + Global.Derecha(item.numDocumentoRef, 5), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5));
                            }

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Referente, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Ruc, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCondicion, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomVendedor, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desZonaTrabajo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desEstablecimiento, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desDivision, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.EspecieCaracteristica, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TipoCaracteristica, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.VariedadCaracteristica, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Clase, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomArticulo, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaEnv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.ContenidoPres.ToString("N1"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.nomUMedidaPres, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((item.LoteAlmacen.Trim().Length > 2 ? item.LoteAlmacen : String.Empty), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.LoteProv, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Batch, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PaisOrigen, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Germinacion.ToString("N2") + "%", null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 0));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.porDscto.Value.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.tipCambio.ToString("N3"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.subTotalSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.IgvSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalS.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.subTotalDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.IgvDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.TotalD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.indEstado, null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));

                            if (item.FechaPago == null)
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5));
                            }
                            else
                            {
                                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.FechaPago.Value.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 5f, (item.Tipo == "ANULADO" ? BaseColor.RED : BaseColor.BLACK)), 5, 1));
                            }
                        }

                        TablaCabDetalle.CompleteRow();
                        
                        TotCantidad += item.Cantidad;
                        TotUnitarioSol += Decimal.Round(item.PrecioUnitSol, 2, MidpointRounding.AwayFromZero);
                        TotsubTotalSol += Decimal.Round(item.subTotalSol, 2, MidpointRounding.AwayFromZero);
                        TotIgvSol += Decimal.Round(item.IgvSol, 2, MidpointRounding.AwayFromZero);
                        TotTotalS += Decimal.Round(item.TotalS, 2, MidpointRounding.AwayFromZero);
                        TotUnitarioDol += Decimal.Round(item.PrecioUnitDol, 2, MidpointRounding.AwayFromZero);
                        TotsubTotalDol += Decimal.Round(item.subTotalDol, 2, MidpointRounding.AwayFromZero);
                        TotIgvDol += Decimal.Round(item.IgvDol, 2, MidpointRounding.AwayFromZero);
                        TotTotalD += Decimal.Round(item.TotalD, 2, MidpointRounding.AwayFromZero);
                    }

                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("=".PadLeft(800, '='), null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 1, "S" + Columnas.ToString()));
                    TablaCabDetalle.CompleteRow();

                    if (TipoReporte == 1)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTALES", null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2, "S18"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotCantidad.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotsubTotalSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotIgvSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotTotalS.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotsubTotalDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotIgvDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotTotalD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2, "S9"));
                        TablaCabDetalle.CompleteRow(); 
                    }
                    else
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTALES ====>", null, "N", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 2, "S36"));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotUnitarioSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotsubTotalSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotIgvSol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotTotalS.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotUnitarioDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotsubTotalDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotIgvDol.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(TotTotalD.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5f), 5, 2, "S2"));
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

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            DateTime Ini = Convert.ToDateTime(dtpInicio.Value);
            DateTime Fin = Convert.ToDateTime(dtpFin.Value);

            TituloGeneral = "REPORTE DE VENTAS";
            NombrePestaña = "VENTAS";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = TipoReporte == 1 ? 35 : 46;

                    #region Titulos Principales

                    // Creando Encabezado
                    oHoja.Cells["A1"].Value = TituloGeneral;
                    oHoja.Row(1).Height = 30;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, 13])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 15, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(58, 58, 56));
                    }

                    oHoja.Cells["A2"].Value = "DEL " + Ini.ToString("d") + " AL " + Fin.ToString("d");
                    oHoja.Row(2).Height = 20;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, 13])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 13, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(117, 113, 113));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    if (TipoReporte == 1)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = "AÑO FACT.";
                        oHoja.Cells[InicioLinea, 2].Value = "EMPRESA";
                        oHoja.Cells[InicioLinea, 3].Value = "MES";
                        oHoja.Cells[InicioLinea, 4].Value = "MOV";
                        oHoja.Cells[InicioLinea, 5].Value = "T.D.";
                        oHoja.Cells[InicioLinea, 6].Value = "N° DOC.";
                        oHoja.Cells[InicioLinea, 7].Value = "FEC. VENTA";
                        oHoja.Cells[InicioLinea, 8].Value = "GUIA REMISION";
                        oHoja.Cells[InicioLinea, 9].Value = "N° PEDIDO";
                        oHoja.Cells[InicioLinea, 10].Value = "REF. NC (FT-BV)";
                        oHoja.Cells[InicioLinea, 11].Value = "CLIENTE FACTURADO";
                        oHoja.Cells[InicioLinea, 12].Value = "RUC/DNI";
                        oHoja.Cells[InicioLinea, 13].Value = "DIVISION";
                        oHoja.Cells[InicioLinea, 14].Value = "DESCRIPCION DEL PRODUCTO";
                        oHoja.Cells[InicioLinea, 15].Value = "ESPECIE";
                        oHoja.Cells[InicioLinea, 16].Value = "VARIEDAD";
                        oHoja.Cells[InicioLinea, 17].Value = "U.M.ENVASE";
                        oHoja.Cells[InicioLinea, 18].Value = "CANT.PRES.";
                        oHoja.Cells[InicioLinea, 19].Value = "U.M.PRES.";
                        oHoja.Cells[InicioLinea, 20].Value = "CANTIDAD";
                        oHoja.Cells[InicioLinea, 21].Value = "BASE S/";
                        oHoja.Cells[InicioLinea, 22].Value = "IGV S/";
                        oHoja.Cells[InicioLinea, 23].Value = "VENTA S/";
                        oHoja.Cells[InicioLinea, 24].Value = "BASE US$";
                        oHoja.Cells[InicioLinea, 25].Value = "IGV US$";
                        oHoja.Cells[InicioLinea, 26].Value = "VENTA US$";
                        oHoja.Cells[InicioLinea, 27].Value = "T.C.";
                        oHoja.Cells[InicioLinea, 28].Value = "COND.PAGO";
                        oHoja.Cells[InicioLinea, 29].Value = "N° LETRAS";
                        oHoja.Cells[InicioLinea, 30].Value = "FEC.DEPOS.";
                        oHoja.Cells[InicioLinea, 31].Value = "N° OP.";
                        oHoja.Cells[InicioLinea, 32].Value = "IMPORTE COB.";
                        oHoja.Cells[InicioLinea, 33].Value = "ESTADO";
                        oHoja.Cells[InicioLinea, 34].Value = "ZONA";
                        oHoja.Cells[InicioLinea, 35].Value = "VENDEDOR"; 
                    }
                    else
                    {
                        oHoja.Row(InicioLinea).Height = 30;

                        oHoja.Cells[InicioLinea, 1].Value = "AÑO PEDIDO";
                        oHoja.Cells[InicioLinea, 2].Value = "NRO PEDIDO";
                        oHoja.Cells[InicioLinea, 3].Value = "AÑO FACTURACION";
                        oHoja.Cells[InicioLinea, 4].Value = "MES  FACTURACION";
                        oHoja.Cells[InicioLinea, 5].Value = "MOVIMIENTO";
                        oHoja.Cells[InicioLinea, 6].Value = "TIPO DOC";
                        oHoja.Cells[InicioLinea, 7].Value = "DOCUMENTO";
                        oHoja.Cells[InicioLinea, 8].Value = "FECHA";
                        oHoja.Cells[InicioLinea, 9].Value = "GR";
                        oHoja.Cells[InicioLinea, 10].Value = "REFERENCIA";
                        oHoja.Cells[InicioLinea, 11].Value = "CLIENTE REFERENTE";
                        oHoja.Cells[InicioLinea, 12].Value = "CLIENTE FACTURADO";
                        oHoja.Cells[InicioLinea, 13].Value = "RUC/DNI";
                        oHoja.Cells[InicioLinea, 14].Value = "FORMAS DE PAGO";
                        oHoja.Cells[InicioLinea, 15].Value = "VENDEDOR";
                        oHoja.Cells[InicioLinea, 16].Value = "ZONA DE INFLUENCIA";
                        oHoja.Cells[InicioLinea, 17].Value = "ZONA";
                        oHoja.Cells[InicioLinea, 18].Value = "DIVISION";
                        oHoja.Cells[InicioLinea, 19].Value = "CODIGO DEL PRODUCTO";
                        oHoja.Cells[InicioLinea, 20].Value = "ESPECIE";
                        oHoja.Cells[InicioLinea, 21].Value = "TIPO";
                        oHoja.Cells[InicioLinea, 22].Value = "VARIEDAD";
                        oHoja.Cells[InicioLinea, 23].Value = "CLASE";
                        oHoja.Cells[InicioLinea, 24].Value = "DESCRIPCION";
                        oHoja.Cells[InicioLinea, 25].Value = "PRESENTACION";
                        oHoja.Cells[InicioLinea, 26].Value = "CANT. PRESENTACION";
                        oHoja.Cells[InicioLinea, 27].Value = "UNIDAD MEDIDA";
                        oHoja.Cells[InicioLinea, 28].Value = "LOTE AG";
                        oHoja.Cells[InicioLinea, 29].Value = "LOTE PROVEEDOR";
                        oHoja.Cells[InicioLinea, 30].Value = "BATCH";
                        oHoja.Cells[InicioLinea, 31].Value = "ORIGEN";
                        oHoja.Cells[InicioLinea, 32].Value = "% DE GERMINACION";
                        oHoja.Cells[InicioLinea, 33].Value = "CANTIDAD";
                        oHoja.Cells[InicioLinea, 34].Value = "MONEDA";
                        oHoja.Cells[InicioLinea, 35].Value = "DESCUENTO";
                        oHoja.Cells[InicioLinea, 36].Value = "TIPO DE CAMBIO";
                        oHoja.Cells[InicioLinea, 37].Value = "VALOR VENTA UNIT SOLES";
                        oHoja.Cells[InicioLinea, 38].Value = "VALOR VENTA SOLES";
                        oHoja.Cells[InicioLinea, 39].Value = "IGV SOLES";
                        oHoja.Cells[InicioLinea, 40].Value = "VALOR BRUTO SOLES";
                        oHoja.Cells[InicioLinea, 41].Value = "VALOR VENTA UNIT DOLARES";
                        oHoja.Cells[InicioLinea, 42].Value = "VALOR VENTA DOLARES";
                        oHoja.Cells[InicioLinea, 43].Value = "IGV DOLARES";
                        oHoja.Cells[InicioLinea, 44].Value = "VALOR BRUTO DOLARES";
                        oHoja.Cells[InicioLinea, 45].Value = "CANCELADA";
                        oHoja.Cells[InicioLinea, 46].Value = "FEC CANC.";

                        //Anchos
                        oHoja.Column(1).Width = 12d;//"AÑO PEDIDO";
                        oHoja.Column(2).Width = 14d;//NRO PEDIDO";
                        oHoja.Column(3).Width = 15d;//AÑO FACTURACION";
                        oHoja.Column(4).Width = 17d;//MES  FACTURACION";
                        oHoja.Column(5).Width = 18d;//MOVIMIENTO";
                        oHoja.Column(6).Width = 10d;//TIPO DOC";
                        oHoja.Column(7).Width = 19d;//DOCUMENTO";
                        oHoja.Column(8).Width = 14.5d;//FECHA";
                        oHoja.Column(9).Width = 14.5d;//GR";
                        oHoja.Column(10).Width = 17d;//REFERENCIA";
                        oHoja.Column(11).Width = 41d;//CLIENTE REFERENTE";
                        oHoja.Column(12).Width = 41d;//CLIENTE FACTURADO";
                        oHoja.Column(13).Width = 18.30d;//RUC/DNI";
                        oHoja.Column(14).Width = 29d;//FORMAS DE PAGO";
                        oHoja.Column(15).Width = 38.80d;//VENDEDOR";
                        oHoja.Column(16).Width = 15.80d;//ZONA DE INFLUENCIA";
                        oHoja.Column(17).Width = 17d;//ZONA";
                        oHoja.Column(18).Width = 17d;//DIVISION";
                        oHoja.Column(19).Width = 14d;//CODIGO DEL PRODUCTO";
                        oHoja.Column(20).Width = 16.5d;//ESPECIE";
                        oHoja.Column(21).Width = 16.5d;//TIPO";
                        oHoja.Column(22).Width = 16.5d;//VARIEDAD";
                        oHoja.Column(23).Width = 14.5d;//CLASE";
                        oHoja.Column(24).Width = 49d;//DESCRIPCION";
                        oHoja.Column(25).Width = 16d;//PRESENTACION";
                        oHoja.Column(26).Width = 18d;//CANT. PRESENTACION";
                        oHoja.Column(27).Width = 16d;//UNIDAD MEDIDA";
                        oHoja.Column(28).Width = 14.5d;//LOTE AG";
                        oHoja.Column(29).Width = 15.5d;//LOTE PROVEEDOR";
                        oHoja.Column(30).Width = 13.7d;//BATCH";
                        oHoja.Column(31).Width = 16.5d;//ORIGEN";
                        oHoja.Column(32).Width = 17d;//% DE GERMINACION";
                        oHoja.Column(33).Width = 12.1d;//CANTIDAD";
                        oHoja.Column(34).Width = 27;//MONEDA";
                        oHoja.Column(35).Width = 14.43d;//DESCUENTO";
                        oHoja.Column(36).Width = 13d;//TIPO DE CAMBIO";
                        oHoja.Column(37).Width = 17d;//VALOR VENTA UNIT SOLES";
                        oHoja.Column(38).Width = 17d;//VALOR VENTA SOLES";
                        oHoja.Column(39).Width = 14d;//IGV SOLES";
                        oHoja.Column(40).Width = 17d;//VALOR BRUTO SOLES";
                        oHoja.Column(41).Width = 17d;//VALOR VENTA UNIT DOLARES";
                        oHoja.Column(42).Width = 17d;//VALOR VENTA DOLARES";
                        oHoja.Column(43).Width = 15d;//IGV DOLARES";
                        oHoja.Column(44).Width = 17d;//VALOR BRUTO DOLARES";
                        oHoja.Column(45).Width = 16d;//CANCELADA";
                        oHoja.Column(46).Width = 16d;//FEC CANC.";
                    }

                    for (int i = 1; i <= TotColumnas; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.White);
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 32, 96));
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.White);
                        oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[InicioLinea, i].Style.WrapText = true;
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Detalle 

                    Decimal TotContenido = 0;
                    Decimal TotCantidad = 0;
                    Decimal TotsubTotalSol = 0;
                    Decimal TotIgvSol = 0;
                    Decimal TotTotalS = 0;
                    Decimal TotsubTotalDol = 0;
                    Decimal TotIgvDol = 0;
                    Decimal TotTotalD = 0;

                    foreach (EmisionDocumentoE item in oListaRegistrosVentaDetallada)
                    {
                        if (TipoReporte == 1)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.Anio;
                            oHoja.Cells[InicioLinea, 2].Value = VariablesLocales.SesionUsuario.Empresa.NombreComercial;
                            oHoja.Cells[InicioLinea, 3].Value = item.nomMes;
                            oHoja.Cells[InicioLinea, 4].Value = item.Tipo;
                            oHoja.Cells[InicioLinea, 5].Value = item.idDocumento;
                            oHoja.Cells[InicioLinea, 6].Value = item.numSerie + "-" + item.numDocumento;
                            oHoja.Cells[InicioLinea, 7].Value = item.fecEmision;
                            oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 8].Value = item.Guia;
                            oHoja.Cells[InicioLinea, 9].Value = item.Pedido;

                            if (item.idDocumento == "NC" || item.idDocumento == "ND")
                            {
                                oHoja.Cells[InicioLinea, 10].Value = item.idDocumentoRef + "/" + Global.Derecha(item.serDocumentoRef, 3) + "-" + Global.Derecha(item.numDocumentoRef, 5);
                            }

                            oHoja.Cells[InicioLinea, 11].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 12].Value = item.Ruc;
                            oHoja.Cells[InicioLinea, 13].Value = item.desDivision;
                            oHoja.Cells[InicioLinea, 14].Value = item.nomArticulo;
                            oHoja.Cells[InicioLinea, 15].Value = item.EspecieCaracteristica;
                            oHoja.Cells[InicioLinea, 16].Value = item.VariedadCaracteristica;
                            oHoja.Cells[InicioLinea, 17].Value = item.nomUMedidaEnv;
                            oHoja.Cells[InicioLinea, 18].Value = item.ContenidoPres;
                            oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.0";
                            oHoja.Cells[InicioLinea, 19].Value = item.nomUMedidaPres;
                            oHoja.Cells[InicioLinea, 20].Value = item.Cantidad;
                            oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 21].Value = item.subTotalSol;
                            oHoja.Cells[InicioLinea, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 21].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 22].Value = item.IgvSol;
                            oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 22].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 23].Value = item.TotalS;
                            oHoja.Cells[InicioLinea, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 23].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 24].Value = item.subTotalDol;
                            oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 25].Value = item.IgvDol;
                            oHoja.Cells[InicioLinea, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 25].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 26].Value = item.TotalD;
                            oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 26].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 27].Value = item.tipCambio;
                            oHoja.Cells[InicioLinea, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 27].Style.Numberformat.Format = "###,###,##0.000";
                            oHoja.Cells[InicioLinea, 28].Value = item.desCondicion;
                            oHoja.Cells[InicioLinea, 29].Value = item.numLetras;
                            oHoja.Cells[InicioLinea, 30].Value = item.FechaPago;
                            oHoja.Cells[InicioLinea, 30].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 30].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 31].Value = item.numOperacion;
                            oHoja.Cells[InicioLinea, 32].Value = item.desMoneda + " " + item.ImporteCobrado.ToString("N2");
                            oHoja.Cells[InicioLinea, 32].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 33].Value = item.indEstado;
                            oHoja.Cells[InicioLinea, 34].Value = item.desEstablecimiento;
                            oHoja.Cells[InicioLinea, 35].Value = item.nomVendedor; 
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.AnioPedido;
                            oHoja.Cells[InicioLinea, 2].Value = item.Pedido;
                            oHoja.Cells[InicioLinea, 3].Value = item.Anio;
                            oHoja.Cells[InicioLinea, 4].Value = item.nomMes;
                            oHoja.Cells[InicioLinea, 5].Value = item.Tipo;
                            oHoja.Cells[InicioLinea, 6].Value = item.idDocumento;
                            oHoja.Cells[InicioLinea, 7].Value = item.numSerie + "-" + item.numDocumento;
                            oHoja.Cells[InicioLinea, 8].Value = item.fecEmision;
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 9].Value = item.Guia;

                            if (item.idDocumento == "NC" || item.idDocumento == "ND")
                            {
                                oHoja.Cells[InicioLinea, 10].Value = item.idDocumentoRef + "/" + Global.Derecha(item.serDocumentoRef, 3) + "-" + Global.Derecha(item.numDocumentoRef, 5);
                            }

                            oHoja.Cells[InicioLinea, 11].Value = item.Referente;
                            oHoja.Cells[InicioLinea, 12].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 13].Value = item.Ruc;
                            oHoja.Cells[InicioLinea, 14].Value = item.desCondicion;
                            oHoja.Cells[InicioLinea, 15].Value = item.nomVendedor;
                            oHoja.Cells[InicioLinea, 16].Value = item.desZonaTrabajo;
                            oHoja.Cells[InicioLinea, 17].Value = item.desEstablecimiento;
                            oHoja.Cells[InicioLinea, 18].Value = item.desDivision;
                            oHoja.Cells[InicioLinea, 19].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 20].Value = item.EspecieCaracteristica;
                            oHoja.Cells[InicioLinea, 21].Value = item.TipoCaracteristica;
                            oHoja.Cells[InicioLinea, 22].Value = item.VariedadCaracteristica;
                            oHoja.Cells[InicioLinea, 23].Value = item.Clase;
                            oHoja.Cells[InicioLinea, 24].Value = item.nomArticulo;
                            oHoja.Cells[InicioLinea, 25].Value = item.nomUMedidaEnv;
                            oHoja.Cells[InicioLinea, 26].Value = item.ContenidoPres;
                            oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 26].Style.Numberformat.Format = "###,###,##0.0";
                            oHoja.Cells[InicioLinea, 27].Value = item.nomUMedidaPres;
                            oHoja.Cells[InicioLinea, 28].Value = item.LoteAlmacen;
                            oHoja.Cells[InicioLinea, 29].Value = item.LoteProv;
                            oHoja.Cells[InicioLinea, 30].Value = item.Batch;
                            oHoja.Cells[InicioLinea, 31].Value = item.PaisOrigen;
                            oHoja.Cells[InicioLinea, 32].Value = item.Germinacion / 100M;
                            oHoja.Cells[InicioLinea, 32].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 32].Style.Numberformat.Format = "##0.00%_);[RED](##0.00%)";
                            oHoja.Cells[InicioLinea, 33].Value = item.Cantidad;
                            oHoja.Cells[InicioLinea, 33].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 33].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 34].Value = item.desMoneda;
                            oHoja.Cells[InicioLinea, 35].Value = item.porDscto / 100M;
                            oHoja.Cells[InicioLinea, 35].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 35].Style.Numberformat.Format = "##0.00%_);[RED](##0.00%)";
                            oHoja.Cells[InicioLinea, 36].Value = item.tipCambio;
                            oHoja.Cells[InicioLinea, 36].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 36].Style.Numberformat.Format = "###,###,##0.000";
                            oHoja.Cells[InicioLinea, 37].Value = item.PrecioUnitSol;
                            oHoja.Cells[InicioLinea, 37].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 37].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 38].Value = item.subTotalSol;
                            oHoja.Cells[InicioLinea, 38].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 38].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 39].Value = item.IgvSol;
                            oHoja.Cells[InicioLinea, 39].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 39].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 40].Value = item.TotalS;
                            oHoja.Cells[InicioLinea, 40].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 40].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 41].Value = item.PrecioUnitDol;
                            oHoja.Cells[InicioLinea, 41].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 41].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 42].Value = item.subTotalDol;
                            oHoja.Cells[InicioLinea, 42].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 42].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 43].Value = item.IgvDol;
                            oHoja.Cells[InicioLinea, 43].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 43].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 44].Value = item.TotalD;
                            oHoja.Cells[InicioLinea, 44].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            oHoja.Cells[InicioLinea, 44].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 45].Value = item.indEstado;
                            oHoja.Cells[InicioLinea, 45].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 46].Value = item.FechaPago;
                            oHoja.Cells[InicioLinea, 46].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 46].Style.Numberformat.Format = "dd/MM/yyyy";
                        }

                        for (int i = 1; i <= TotColumnas; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                            if (item.Tipo == "ANULADO")
                            {
                                oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.Red);
                            }
                        }

                        TotContenido += item.ContenidoPres;
                        TotCantidad += item.Cantidad;
                        TotsubTotalSol += item.subTotalSol;
                        TotIgvSol += item.IgvSol;
                        TotTotalS += item.TotalS;
                        TotsubTotalDol += item.subTotalDol;
                        TotIgvDol += item.IgvDol;
                        TotTotalD += item.TotalD;

                        InicioLinea++;
                    }

                    if (TipoReporte == 1)
                    {
                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 19].Value = "TOTALES";
                        oHoja.Cells[InicioLinea, 19].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 20].Value = TotCantidad;
                        oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 20].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 21].Value = TotsubTotalSol;
                        oHoja.Cells[InicioLinea, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 21].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 21].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 22].Value = TotIgvSol;
                        oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 22].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 22].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 23].Value = TotTotalS;
                        oHoja.Cells[InicioLinea, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 23].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 23].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 24].Value = TotsubTotalDol;
                        oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 24].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 25].Value = TotIgvDol;
                        oHoja.Cells[InicioLinea, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 25].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 25].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 26].Value = TotTotalD;
                        oHoja.Cells[InicioLinea, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 26].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 26].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Top.Style = ExcelBorderStyle.Double;

                        oHoja.Cells[InicioLinea, 1, InicioLinea, 36].Merge = true;
                        oHoja.Cells[InicioLinea, 1, InicioLinea, 36].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 1, InicioLinea, 36].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 1, InicioLinea, 36].Value = "TOTAL >>>>";

                        //InicioLinea++;
                        oHoja.Cells[InicioLinea, 37, InicioLinea, 44].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 37, InicioLinea, 44].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, 37, InicioLinea, 44].Formula = string.Format("SUBTOTAL(9,{0})", new ExcelAddress(5, 37, InicioLinea - 1, 37).Address);
                        oHoja.Cells[InicioLinea, 37, InicioLinea, 44].Style.Numberformat.Format = "###,###0.00";
                        oHoja.Calculate();
                    }

                    InicioLinea++;

                    #endregion

                    //Ajustando el ancho de las columnas automaticamente
                    if (TipoReporte == 1)
                    {
                        oHoja.Cells.AutoFitColumns(); 
                    }

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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
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

        void CambioVendedor()
        {
            txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;
            txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;

            if (chkVendedores.Checked)
            {
                txtNombresVendedor.Enabled = false;
                txtNroDocumentoVen.Enabled = false;
                txtNombresVendedor.BackColor = SystemColors.InactiveCaption;
                txtNroDocumentoVen.BackColor = SystemColors.InactiveCaption;
            }
            else
            {
                txtNombresVendedor.Clear();
                txtNroDocumentoVen.Clear();
                txtNombresVendedor.Enabled = true;
                txtNroDocumentoVen.Enabled = true;
                txtNombresVendedor.BackColor = Color.WhiteSmoke;
                txtNroDocumentoVen.BackColor = Color.WhiteSmoke;
            }

            txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;
            txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
        }

        void CambioCliente()
        {
            txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
            txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;

            if (chbClientes.Checked)
            {
                txtRazonCliente.Enabled = false;
                txtRucCLiente.Enabled = false;
                txtRucCLiente.BackColor = SystemColors.InactiveCaption;
                txtRazonCliente.BackColor = SystemColors.InactiveCaption;
            }
            else
            {
                txtRazonCliente.Clear();
                txtRucCLiente.Clear();
                txtRazonCliente.Enabled = true;
                txtRucCLiente.Enabled = true;
                txtRucCLiente.BackColor = Color.WhiteSmoke;
                txtRazonCliente.BackColor = Color.WhiteSmoke;
            }

            txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
            txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaRegistrosVentaDetallada == null || oListaRegistrosVentaDetallada.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                if (TipoReporte == 1)
                {
                    RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Ventas Detallada", "Archivos Excel (*.xlsx)|*.xlsx");
                }
                else
                {
                    RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Comparativo de Ventas", "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipo = "exportar";
                    lblProcesando.Visible = true;
                    btBuscar.Enabled = true;
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
            try
            {
                if (tipo == "buscar")
                {
                    Int32.TryParse(txtIdVendedor.Text, out Int32 Vendedor);
                    Int32.TryParse(txtIdCliente.Text, out Int32 Cliente);
                    Int32 Zona = Convert.ToInt32(cboEstablecimiento.SelectedValue) ;

                    lblProcesando.Text = "Obteniendo el Registro de Ventas...";
                    oListaRegistrosVentaDetallada = AgenteVentas.Proxy.ListarReporteVentasDetallada(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, dtpInicio.Value.ToString("yyyyMMdd"), dtpFin.Value.ToString("yyyyMMdd"), Vendedor, Cliente, Zona, TipoReporte);
                    lblProcesando.Text = "Armando el Reporte de Ventas...";
                    ConvertirApdf();
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

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeError(String.Format("Ha ocurrido la excepción: {0}", e.Error.Message));
            }
            else
            {
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
                    Global.MensajeComunicacion("Registros de Ventas Detallado Exportado...");
                } 
            }
        }

        #endregion

        #region Eventos

        private void frmReporteRegistroVentasDetallada_Load(object sender, EventArgs e)
        {
            Grid = true;
            LlenarCombos();
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            CambioCliente();
            CambioVendedor();

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
                cmsFormatos.Show(btBuscar, new Point(0, btBuscar.Height));
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void txtNroDocumentoVen_TextChanged(object sender, EventArgs e)
        {
            txtIdVendedor.Text = String.Empty;
            txtNombresVendedor.Text = String.Empty;
        }

        private void chbClientes_CheckedChanged(object sender, EventArgs e)
        {
            CambioCliente();
        }

        private void chkVendedores_CheckedChanged(object sender, EventArgs e)
        {
            CambioVendedor();
        }

        private void txtNombresVendedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()) && String.IsNullOrEmpty(txtNroDocumentoVen.Text.Trim()))
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtNombresVendedor.Text.Trim(), "");

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Vendedor");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            txtIdVendedor.Text = oFrm.oPersona.IdPersona.ToString();

                            if (String.IsNullOrEmpty(oFrm.oPersona.RazonSocial.Trim()))
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.ApePaterno + " " + oFrm.oPersona.ApeMaterno + " " + oFrm.oPersona.Nombres;
                            }
                            else
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                            }
                        }
                        else
                        {
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtIdVendedor.Text = oListaPersonas[0].IdPersona.ToString();

                        if (String.IsNullOrEmpty(oListaPersonas[0].RazonSocial.Trim()))
                        {
                            txtNombresVendedor.Text = oListaPersonas[0].ApePaterno + " " + oListaPersonas[0].ApeMaterno + " " + oListaPersonas[0].Nombres;
                        }
                        else
                        {
                            txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                        }
                    }
                    else
                    {
                        Global.MensajeFault("El nombre ingresado no existe.");
                        txtIdVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Text = String.Empty;
                        txtNombresVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Focus();
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtNombresVendedor_TextChanged(object sender, EventArgs e)
        {
            txtIdVendedor.Text = String.Empty;
            txtNroDocumentoVen.Text = String.Empty;
        }

        private void txtNroDocumentoVen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNroDocumentoVen.Text.Trim()) && String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()))
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", txtNroDocumentoVen.Text.Trim());

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            txtIdVendedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtIdVendedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Nro. de Documento ingresado no existe");
                        txtIdVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Text = String.Empty;
                        txtNombresVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Focus();
                        return;
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonCliente_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = String.Empty;
            txtRucCLiente.Text = String.Empty;
        }

        private void txtRazonCliente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonCliente.Text.Trim()) && string.IsNullOrEmpty(txtIdCliente.Text.Trim()) && string.IsNullOrEmpty(txtRucCLiente.Text.Trim()))
                {
                    txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonCliente.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRucCLiente.Text = oFrm.oPersona.RUC;
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRucCLiente.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdCliente.Text = String.Empty;
                        txtIdCliente.Text = String.Empty;
                        txtRazonCliente.Text = String.Empty;
                        txtRazonCliente.Focus();
                    }

                    txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRucCLiente_TextChanged(object sender, EventArgs e)
        {
            txtRazonCliente.Text = String.Empty;
            txtIdCliente.Text = String.Empty;
        }

        private void txtRucCLiente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRucCLiente.Text.Trim()) && string.IsNullOrEmpty(txtIdCliente.Text.Trim()) && string.IsNullOrEmpty(txtRazonCliente.Text.Trim()))
                {
                    txtRucCLiente.TextChanged -= txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged -= txtRazonCliente_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucCLiente.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucCLiente.Text = oFrm.oPersona.RUC;
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRucCLiente.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRucCLiente.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRucCLiente.Text = String.Empty;
                        txtRazonCliente.Text = String.Empty;
                        txtRucCLiente.Focus();
                        return;
                    }

                    txtRucCLiente.TextChanged += txtRucCLiente_TextChanged;
                    txtRazonCliente.TextChanged += txtRazonCliente_TextChanged;
                }
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
                tipo = "buscar";
                TipoReporte = 1;
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

        private void tsmFormato2_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "buscar";
                TipoReporte = 2;
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

        #endregion

    }

    #region Inicio Pdf

    class InicioVentaDetallada : PdfPageEventHelper
    {
        public String Periodo { get; set; }
        public String Empresa { get; set; }
        public Int32 cantColumnas { get; set; }
        public float[] AnchosColumnas { get; set; }
        public Int16 TipoRep { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            #region Variables

            BaseColor colCabDetalle = new BaseColor(0, 32, 96);
            BaseColor ColorLinea = new BaseColor(Color.White);
            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            #endregion Variables

            TituloGeneral = "REPORTE DE VENTAS";
            SubTitulo = "DEL " + Periodo;

            //Cabecera del Reporte
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100
            };

            table.SetWidths(new float[] { 0.9f, 0.13f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            #region Encabezado de página

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

            #endregion

            if (writer.PageNumber == 1)
            {
                #region Titulo Principal

                table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow();

                table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f, "S2"));
                table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
                table.CompleteRow();

                #endregion

                document.Add(table); //Añadiendo la tabla al documento PDF
            }
            else
            {
                document.Add(table); //Añadiendo la tabla al documento PDF
            }

            PdfPTable TablaCabDetalle = null;
            TablaCabDetalle = new PdfPTable(cantColumnas)
            {
                WidthPercentage = 100
            };

            TablaCabDetalle.SetWidths(AnchosColumnas);

            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3f, iTextSharp.text.Font.BOLD), 5, 1, "S" + cantColumnas.ToString()));
            TablaCabDetalle.CompleteRow();

            if (TipoRep == 1)
            {
                #region Cabecera del Detalle

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("AÑO FACT.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MOV", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.D.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N° DOC.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FEC. VENTA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("GUIA REMISION", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N° PEDIDO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("REF. NC (FT-BV)", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CLIENTE FACTURADO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RUC/DNI", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DIVISION", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION DEL PRODUCTO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ESPECIE", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VARIEDAD", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("U.M.ENVASE", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANT.PRES.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("U.M.PRES.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANTIDAD", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("BASE S/", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IGV S/", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VENTA S/", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("BASE US$", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IGV US$", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VENTA US$", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.C.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COND.PAGO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N° LETRAS", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FEC.DEPOS.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("N° OP.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IMPORTE COB.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ESTADO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ZONA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VENDEDOR", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));

                TablaCabDetalle.CompleteRow();

                #endregion
            }
            else
            {
                #region Cabecera del Detalle

                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("AÑO PEDIDO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NRO PEDIDO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("AÑO FACTUR.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MES FACTUR.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MOVIMIENTO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIPO DOC", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DOCUMENTO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("GR", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("REFERENCIA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CLIENTE REFERENTE", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CLIENTE FACTURADO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("RUC/DNI", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FORMAS DE PAGO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VENDEDOR", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ZONA DE INFLUENCIA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ZONA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DIVISION", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COD.PRO.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ESPECIE", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIPO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VARIEDAD", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CLASE", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PRESENT.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CAN.PRES.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNIDAD MEDIDA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE AG", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("LOTE PROV.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("BATCH", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ORIGEN", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("% GERMI.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANT.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("MONEDA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DSCTO", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TI.CA.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA UNIT SOLES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA SOLES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IGV SOLES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR BRUTO SOLES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA UNIT DOLARES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR VENTA DOLARES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("IGV DOLARES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("VALOR BRUTO DOLARES", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANCELADA", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));
                TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FEC CANC.", colCabDetalle, "S", ColorLinea, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD, BaseColor.WHITE), 5, 1, "N", "N", 4f, 4f));

                TablaCabDetalle.CompleteRow();

                #endregion
            }

            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF
        }

    }

    #endregion
}

