using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Almacen
{
    public partial class frmConsultaStockMensual : FrmMantenimientoBase
    {
        public frmConsultaStockMensual()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<StockE> oVistaStock = null;
        List<StockE> oVistaStockMod = new List<StockE>();
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        String RutaGeneral = String.Empty;
        #endregion


        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////MES////
            cboMes.DataSource = FechasHelper.CargarMesesContable("MA");
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = VariablesLocales.FechaHoy.ToString("MM");

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

            /////Almacenes/////
            List<AlmacenE> ListarTipoAlmacen = AgenteAlmacen.Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", 0, false, false);
            ComboHelper.RellenarCombos<AlmacenE>(cboalmacen, (from x in ListarTipoAlmacen orderby x.desAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
        }

        public override void Buscar()
        {
            try
            {
                String Anio = Convert.ToString(cboAño.SelectedValue);
                String Mes = Convert.ToString(cboMes.SelectedValue);
                Int32 Almacen = Convert.ToInt32(cboalmacen.SelectedValue);
                string FechaAleat = VariablesLocales.FechaHoy.ToString("yyyyMMdd");

                oVistaStock = AgenteAlmacen.Proxy.ListarReporteStockMensual(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Almacen, Anio, Mes, 0, FechaAleat);

                foreach (StockE item in oVistaStock)
                {
                    if (chkDiferencia.Checked == true)
                    {
                        if (chkCero.Checked == true)
                        {
                            oVistaStockMod.Add(item);
                        }
                        else
                        {
                            if (item.canStock != 0)
                            {
                                oVistaStockMod.Add(item);
                            }
                        }
                    }
                    else
                    {
                        if (chkCero.Checked == true)
                        {
                            if (item.canStock == 0)
                            {
                                oVistaStockMod.Add(item);
                            }
                        }
                    }
                }

                bsStock.DataSource = oVistaStockMod;
                lblRegistros.Text = "Registros " + bsStock.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ExportarExcel(String Ruta)
        {
            String nombreMes = cboMes.Text;

            string TituloGeneral = " Stock Alt. " + Anio + " - " + nombreMes;
            string NombrePestaña = " Stock Alt. ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 8;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(81, 175, 92));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(81, 175, 92));
                    }

                    #endregion Titulos Principales

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " CODIGO ";
                    oHoja.Cells[InicioLinea, 2].Value = " DESCRIPCION ";
                    oHoja.Cells[InicioLinea, 3].Value = " LOTE ";
                    oHoja.Cells[InicioLinea, 4].Value = " STOCK ";
                    oHoja.Cells[InicioLinea, 5].Value = " UNIDAD MED. ";
                    oHoja.Cells[InicioLinea, 6].Value = " CONTENIDO";
                    oHoja.Cells[InicioLinea, 7].Value = " UNIDAD PRES. ";
                    oHoja.Cells[InicioLinea, 8].Value = " STOCK FISICO ";

                    for (int i = 1; i <= 8; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    //Aumentando una Fila mas continuar con el detalle


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    InicioLinea++;

                    #endregion Cabeceras del Detalle

                    #region Detalle

                    foreach (StockE item in oVistaStockMod)
                    {

                        oHoja.Cells[InicioLinea, 1].Value = item.idArticulo;
                        oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                        oHoja.Cells[InicioLinea, 3].Value = item.Lote;
                        oHoja.Cells[InicioLinea, 4].Value = item.canStock;
                        oHoja.Cells[InicioLinea, 5].Value = item.nomUMedida;
                        oHoja.Cells[InicioLinea, 6].Value = item.Contenido;
                        oHoja.Cells[InicioLinea, 7].Value = item.nomUMedidaPres;
                        oHoja.Cells[InicioLinea, 8].Value = item.StockFisico;


                        oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.000";
                        oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                        InicioLinea++;

                    }

                    #endregion

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
                    oHoja.Workbook.Properties.Category = "Modulo de Almacén";
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

        public override void Exportar()
        {
            try
            {
                if (oVistaStockMod == null || oVistaStockMod.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String Mes = cboMes.Text;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Consultas Stock Mensuales" + "-" + VariablesLocales.SesionUsuario.Empresa.NombreComercial + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    ExportarExcel(RutaGeneral);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
        
        #endregion

        private void frmConsultaStockMensual_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            LlenarCombos();
        }
    }
}
