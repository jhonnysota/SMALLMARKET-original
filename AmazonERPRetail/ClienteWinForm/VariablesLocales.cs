using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Seguridad;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Almacen;
using Entidades.Ventas;
using Entidades.Tesoreria;
using Infraestructura;

#region Para Excel

using OfficeOpenXml;
using OfficeOpenXml.Drawing;

#endregion

namespace ClienteWinForm
{
    public static class VariablesLocales
    {

        #region Variables
        
        public static Usuario SesionUsuario { get; set; }
        public static LocalE SesionLocal { get; set; }
        public static Area SesionArea { get; set; }
        public static DateTime FechaHoy { get; set; }
        public static PeriodosE PeriodoContable { get; set; }
        public static PeriodosAlmE PeriodoContableAlm { get; set; }
        public static PlanCuentasVersionE VersionPlanCuentasActual { get; set; }
        public static List<CCostosE> ListarCCostosPorSistema { get; set; }
        public static List<DocumentosE> ListarDocumentoGeneral { get; set; } //Lectura y Escritura...
        public static List<MonedasE> ListaMonedas { get; set; }
        public static TipoCambioE TipoCambioDelDia { get; set; }
        public static List<Opcion> listaOpciones { get; set; }
        //public static ParametroE PesoArchivos { get; set; }
        public static List<NumControlDetE> ListaDetalleNumControl { get; set; }
        public static List<ParametroE> ListaParametros { get; set; }
        public static List<ComprobantesE> oListaComprobantes { get; set; }
        public static List<CuentaCCostoE> oListaCuentaCC { get; set; }
        public static List<ImpuestosPeriodoE> oListaImpuestos { get; set; }
        public static List<ParTabla> oListaBasesImponibles { get; set; }
        //public static CampanaAgricolaE CampanaVigente { get; set; }
        public static SistemasE oSistema { get; set; }
        public static List<SistemasE> oListaSistemas { get; set; }
        public static ParametrosContaE oConParametros { get; set; }
        public static venParametrosE oVenParametros { get; set; }
        public static tesParametrosE oTesParametros { get; set; }
        public static OrdenCompraParametrosE oComprasParametros { get; set; }
        public static SalesPointE oSalesPoint { get; set; }

        public static String RutaZipSunat = String.Empty;
        public static String EsLiquidacion { get; set; }

        #region Ancho del Menu

        public static int AnchoMdi { get; set; }
        public static int AltoMdi { get; set; }

        #endregion

        #endregion

        #region Procedimientos

        public static TipoCambioE RetornaTipoCambio(String Moneda, DateTime Fecha)
        {
            try
            {
                if (Moneda == Variables.Soles)
                {
                    return new GeneralesServiceAgent().Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));
                }
                else
                {
                    return new GeneralesServiceAgent().Proxy.ObtenerTipoCambioPorDia(Moneda, Fecha.ToString("yyyyMMdd"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Decimal MontoTicaConta(DateTime Fecha, String Moneda, String Libro = "")
        {
            Decimal MontoDevuelto = 0;
            TipoCambioE Tica = null;

            if (Moneda == Variables.Soles)
            {
                Tica = new GeneralesServiceAgent().Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));
            }
            else
            {
                Tica = new GeneralesServiceAgent().Proxy.ObtenerTipoCambioPorDia(Moneda, Fecha.ToString("yyyyMMdd"));
            }

            if (!String.IsNullOrWhiteSpace(Libro))
            {
                ComprobantesE lLibro = (from x in oListaComprobantes
                                        where x.idComprobante == Libro
                                        select x).FirstOrDefault();
                if (Tica != null)
                {
                    if (lLibro.indTCVenta)
                    {
                        MontoDevuelto = Tica.valVenta;
                    }
                    else
                    {
                        MontoDevuelto = Tica.valCompra;
                    }
                }
                else
                {
                    MontoDevuelto = Variables.ValorCeroDecimal;
                }
            }
            else
            {
                if (Tica != null)
                {
                    MontoDevuelto = Tica.valVenta;
                }
                else
                {
                    MontoDevuelto = Variables.ValorCeroDecimal;
                }
            }

            return MontoDevuelto;
        }

        public static PlanCuentasE ObtenerPlanCuenta(String Cuenta)
        {
            try
            {
                return new ContabilidadServiceAgent().Proxy.ObtenerPlanCuentasPorCodigo(SesionUsuario.Empresa.IdEmpresa, VersionPlanCuentasActual.numVerPlanCuentas, Cuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Logo de la Empresa

        static String RutaTmp = @"C:\AmazonErp\Logo\";

        public static String ObtenerLogo(Int32 idEmpresa, String RazonSocial = "")
        {
            String RutaImagen = RutaTmp;
            EmpresaImagenesE oEmpresaImagen = new MaestrosServiceAgent().Proxy.ObtenerEmpresaSinImagenes(2, idEmpresa);

            if (!Directory.Exists(RutaImagen))
            {
                Directory.CreateDirectory(RutaTmp);
            }

            if (oEmpresaImagen != null)
            {
                if (String.IsNullOrWhiteSpace(RazonSocial))
                {
                    RutaImagen += SesionUsuario.Empresa.RazonSocial + oEmpresaImagen.Extension;
                }
                else
                {
                    RutaImagen += RazonSocial + oEmpresaImagen.Extension;
                }

                if (!File.Exists(RutaImagen))
                {
                    oEmpresaImagen = new MaestrosServiceAgent().Proxy.ObtenerEmpresaConImagenes(2, SesionUsuario.Empresa.IdEmpresa);

                    if (oEmpresaImagen.Imagen != null)
                    {
                        Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, RutaImagen);
                    }
                    else
                    {
                        RutaImagen = String.Empty;
                    }
                }
            }
            else
            {
                RutaImagen = String.Empty;
            }

            return RutaImagen;
        }

        #endregion

        #region Firma del gerente

        static String RutaFirma = @"C:\AmazonErp\Firma\";

        public static String ObtenerFirma(Int32 idEmpresa, String Ruc = "")
        {
            String RutaImagen = String.Empty;
            EmpresaImagenesE oEmpresaImagen = new MaestrosServiceAgent().Proxy.ObtenerEmpresaSinImagenes(1, idEmpresa);

            if (!Directory.Exists(RutaFirma))
            {
                Directory.CreateDirectory(RutaFirma);
            }

            RutaImagen = RutaFirma;

            if (oEmpresaImagen != null)
            {
                if (String.IsNullOrWhiteSpace(Ruc))
                {
                    RutaImagen += oEmpresaImagen.Nombre + " " + VariablesLocales.SesionUsuario.Empresa.RUC + oEmpresaImagen.Extension;
                }
                else
                {
                    RutaImagen += oEmpresaImagen.Nombre + " " + Ruc + oEmpresaImagen.Extension;
                }

                if (!File.Exists(RutaImagen))
                {
                    oEmpresaImagen = new MaestrosServiceAgent().Proxy.ObtenerEmpresaConImagenes(1, SesionUsuario.Empresa.IdEmpresa);

                    if (oEmpresaImagen.Imagen != null)
                    {
                        Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, RutaImagen);
                    }
                    else
                    {
                        RutaImagen = String.Empty;
                    }
                }
            }
            else
            {
                RutaImagen = String.Empty;
            }

            return RutaImagen;
        }

        #endregion

        #region Imagen de la Letra

        public static String ObtenerLetra(Int32 idEmpresa, String RazonSocial = "")
        {
            String RutaImagen = String.Empty;
            EmpresaImagenesE oEmpresaImagen = new MaestrosServiceAgent().Proxy.ObtenerEmpresaSinImagenes(3, idEmpresa);

            if (!Directory.Exists(RutaTmp))
            {
                Directory.CreateDirectory(RutaTmp);
            }

            RutaImagen = RutaTmp;

            if (oEmpresaImagen != null)
            {
                if (String.IsNullOrWhiteSpace(RazonSocial))
                {
                    RutaImagen += oEmpresaImagen.Nombre + " " + VariablesLocales.SesionUsuario.Empresa.RazonSocial + oEmpresaImagen.Extension;
                }
                else
                {
                    RutaImagen += oEmpresaImagen.Nombre + " " + RazonSocial + oEmpresaImagen.Extension;
                }

                if (!File.Exists(RutaImagen))
                {
                    oEmpresaImagen = new MaestrosServiceAgent().Proxy.ObtenerEmpresaConImagenes(3, SesionUsuario.Empresa.IdEmpresa);

                    if (oEmpresaImagen.Imagen != null)
                    {
                        Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, RutaImagen);
                    }
                    else
                    {
                        RutaImagen = String.Empty;
                    }
                }
            }
            else
            {
                RutaImagen = String.Empty;
            }

            return RutaImagen;
        }

        #endregion

        public static Int32 DevolverBase(String Documento)
        {
            Int32 Columna = 0;

            if (Documento == "BR") //Boleta de Venta Recibida
            {
                ParTabla Tipo = VariablesLocales.oListaBasesImponibles.Find
                (
                    delegate (ParTabla t) { return t.NemoTecnico == "BAINA"; }
                );

                if (Tipo != null)
                {
                    Columna = Tipo.IdParTabla;
                }
            }

            return Columna;
        }

        public static void CopiarCelda(DataGridView oDgv)
        {
            //Copiando al portapapeles
            DataObject dataObj = oDgv.GetClipboardContent();

            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
            }
        }

        #endregion

        #region Excel

        public static void ImagenExcel(ExcelWorksheet HojaExcel, int rowIndex, int colIndex, String RutaImagen)
        {
            Bitmap Imagen = new Bitmap(RutaImagen);
            if (Imagen != null)
            {
                ExcelPicture excelImage = HojaExcel.Drawings.AddPicture("Logo", Imagen);
                excelImage.From.Column = colIndex;
                excelImage.From.Row = rowIndex;
                excelImage.SetSize(230, 55);
                // Espacio de 2x2 px para una mejor alineación.
                excelImage.From.ColumnOff = Pixel2MTU(2);
                excelImage.From.RowOff = Pixel2MTU(2);
            }
        }

        private static int Pixel2MTU(int pixels)
        {
            int mtus = pixels * 9525;
            return mtus;
        }

        #endregion

        #region Control Dinámico

        public static object ObjDinamico(Panel oFrm, String nameControl)
        {
            try
            {
                Control[] ctr = oFrm.Controls.Find(nameControl, true);
                return (object)ctr[0];
            }
            catch
            {
                return null;
            }
        }

        #endregion

        public static bool BuscarCadenaGrid(String TextoABuscar, String Columna, DataGridView grid)
        {
            Boolean encontrado = false;
            if (String.IsNullOrWhiteSpace(TextoABuscar)) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();

            if (String.IsNullOrWhiteSpace(Columna))
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (Convert.ToString(cell.Value).ToUpper().Contains(TextoABuscar.ToUpper()))
                        {
                            row.Selected = true;
                            grid.FirstDisplayedScrollingRowIndex = row.Index;
                            return true;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if ((String)row.Cells[Columna].Value == TextoABuscar)
                    {
                        row.Selected = true;
                        return true;
                    }
                }
            }

            return encontrado;
        }

    }
}
