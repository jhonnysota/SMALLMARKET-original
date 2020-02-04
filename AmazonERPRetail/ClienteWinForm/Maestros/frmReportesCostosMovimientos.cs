using Entidades.Maestros;
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

namespace ClienteWinForm.Maestros
{
    public partial class frmReportesCostosMovimientos : FrmMantenimientoBase
    {

        DataTable dtDatos = new DataTable();
        decimal? Total = 0;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
        public frmReportesCostosMovimientos()
        {
            InitializeComponent();
        }

        public frmReportesCostosMovimientos(List<CostosMovimientosE> oListaReporte,List<CostosMovimientosItemE> oListaReporteItem,String Anio_)
            : this()
        {
            // ==========================================
            DataRow dt = null;
            dtDatos.Columns.Add("Consumo En La Produccion");
            // ==========================================
            List<CostosMovimientosItemE> ListaDetalle;
            List<CostosMovimientosE> ListaCabecera;

            ListaDetalle = oListaReporteItem.Where(x => Convert.ToDecimal(x.Monto) != 0 ).GroupBy(x => x.Mes).Select(g => g.First()).OrderBy(x => x.Mes).ToList();



            for (int i = 0; i < 12; i++)
            {
                #region Meses
                String NombreMes = String.Empty;
                String MesVariado = String.Empty;
                if (i == 0)
                {
                    NombreMes = "ENERO";
                    MesVariado = "01";
                }
                if (i == 1)
                {
                    NombreMes = "FEBRERO";
                    MesVariado = "02";
                }
                if (i == 2)
                {
                    NombreMes = "MARZO";
                    MesVariado = "03";
                }
                if (i == 3)
                {
                    NombreMes = "ABRIL";
                    MesVariado = "04";
                }
                if (i == 4)
                {
                    NombreMes = "MAYO";
                    MesVariado = "05";
                }
                if (i == 5)
                {
                    NombreMes = "JUNIO";
                    MesVariado = "06";
                }
                if (i == 6)
                {
                    NombreMes = "JULIO";
                    MesVariado = "07";
                }
                if (i == 7)
                {
                    NombreMes = "AGOSTO";
                    MesVariado = "08";
                }
                if (i == 8)
                {
                    NombreMes = "SETIEMBRE";
                    MesVariado = "09";
                }
                if (i == 9)
                {
                    NombreMes = "OCTUBRE";
                    MesVariado = "10";
                }
                if (i == 10)
                {
                    NombreMes = "NOVIEMBRE";
                    MesVariado = "11";
                }
                if (i == 11)
                {
                    NombreMes = "DICIEMBRE";
                    MesVariado = "12";
                }

                #endregion              

                dtDatos.Columns.Add(Anio_ + " - " + NombreMes);
            }
           
            dtDatos.Columns.Add("TOTALES");
            // ==========================================

            ListaCabecera = (from x in oListaReporte where x.idElemento  != 0  orderby Convert.ToInt32(x.idElemento) select x).ToList();

            Boolean NuevoLinea = false;

            string secItem = "";
            int contador = 0;

            for (int data = 0; data < ListaCabecera.Count; data++)
            {
                if (data == 0)
                {
                    dt = dtDatos.NewRow();
                    NuevoLinea = true;
                    secItem = ListaCabecera[data].idElemento.ToString();

                    dt["Consumo En La Produccion"] = ListaCabecera[data].Nombre;


                    contador++;
                }

                if (data > 0)
                {
                    if (secItem != ListaCabecera[data].idElemento.ToString())
                    {
                        dt = dtDatos.NewRow();
                        NuevoLinea = true;
                        secItem = ListaCabecera[data].idElemento.ToString();

                        dt["Consumo En La Produccion"] = ListaCabecera[data].Nombre;

                        contador++;
                    }
                    else
                    {
                        NuevoLinea = false;
                    }
                }

                if (NuevoLinea)
                {
                   

                    for (int i = 0; i < 12; i++)
                    {
                        String NombreMes = String.Empty;
                        List<CostosMovimientosItemE> item;
                        string NombreColumna = "";
                        String MesVariado = String.Empty;

                        #region Meses

                        if (i == 0)
                        {
                            NombreMes = "ENERO";
                            MesVariado = "01";
                        }
                        if (i == 1)
                        {
                            NombreMes = "FEBRERO";
                            MesVariado = "02";
                        }
                        if (i == 2)
                        {
                            NombreMes = "MARZO";
                            MesVariado = "03";
                        }
                        if (i == 3)
                        {
                            NombreMes = "ABRIL";
                            MesVariado = "04";
                        }
                        if (i == 4)
                        {
                            NombreMes = "MAYO";
                            MesVariado = "05";
                        }
                        if (i == 5)
                        {
                            NombreMes = "JUNIO";
                            MesVariado = "06";
                        }
                        if (i == 6)
                        {
                            NombreMes = "JULIO";
                            MesVariado = "07";
                        }
                        if (i == 7)
                        {
                            NombreMes = "AGOSTO";
                            MesVariado = "08";
                        }
                        if (i == 8)
                        {
                            NombreMes = "SETIEMBRE";
                            MesVariado = "09";
                        }
                        if (i == 9)
                        {
                            NombreMes = "OCTUBRE";
                            MesVariado = "10";
                        }
                        if (i == 10)
                        {
                            NombreMes = "NOVIEMBRE";
                            MesVariado = "11";
                        }
                        if (i == 11)
                        {
                            NombreMes = "DICIEMBRE";
                            MesVariado = "12";
                        }

                        #endregion

                        NombreColumna = Anio_ + " - " + NombreMes;
                        item = (from x in oListaReporteItem where x.Mes == MesVariado && Convert.ToString(x.idElemento) == secItem select x).ToList();

                            if (item != null && item.Count > 0)
                            {

                                dt[NombreColumna] = Convert.ToDecimal(Convert.ToDecimal(item[0].Monto)).ToString("N2");
                                Total += ( Convert.ToDecimal(item[0].Monto) );

                            }
                            else
                                dt[NombreColumna] = "0.00";
                        

                    }
                    dt["TOTALES"] = Convert.ToDecimal(Total).ToString("N2");
                    dtDatos.Rows.Add(dt);
                    
                }
            }

            lblregistros.Text =  contador.ToString() + " Registros";

            dgvPivot.DataSource = dtDatos;
            // ==========================================

        }

        private void frmReportesCostosMovimientos_Load(object sender, EventArgs e)
        {
            Grid = true;
            
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            // exportar excel GIF LOADGIND
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

        }

        public override void Exportar()
        {
            try
            {


                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Reportes Costos Movimientos"  , "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    timer1.Enabled = true;
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

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            ExportarExcel(RutaGeneral);
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;


            Global.MensajeComunicacion("Exportación Terminado...");


            _bw.CancelAsync();
            _bw.Dispose();
        }

        #region Exportar Excel

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Costos Movimientos";
            NombrePestaña = "Reporte";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 6;
                    Int32 TotColumnas = dgvPivot.ColumnCount;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = "FORMATO 10.2: REGISTRO DE COSTOS - ELEMENTOS DEL COSTO MENSUAL";

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas - 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = "Periodo                 " + VariablesLocales.FechaHoy.ToString("yyyy");

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas - 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }

                    oHoja.Cells["A3"].Value = "RUC                               " + VariablesLocales.SesionUsuario.Empresa.RUC;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas - 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                    }


                    oHoja.Cells["A4"].Value = "Apellidos Y Nombres, Denominacion Razon Social :                       " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[4, 1, 4, TotColumnas - 2])
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

                    Int32 col = 1;
                    for (Int32 i = 0; i < TotColumnas; i++)
                    {
                        //Nueva Celda
                        String titDetalle = dgvPivot.Columns[i].HeaderText;

                        oHoja.Cells[InicioLinea, col].Value = titDetalle;
                        oHoja.Cells[InicioLinea, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, col].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        col++;
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas ].AutoFilter = true;

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;
                    col = 1;

                    foreach (DataRow item in dtDatos.Rows)
                    {
                        for (int i = 0; i < TotColumnas; i++)
                        {

                            oHoja.Cells[InicioLinea, col].Value = item[i];


                            if (i >= 1)
                            {
                                oHoja.Cells[InicioLinea, col].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                            }
                            col++;
                        }
                       
                        InicioLinea++;
                    }



                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
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
                    oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

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

        #endregion
    }
}
