using Entidades.Contabilidad;
using Entidades.CtasPorPagar;
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
using System.Windows.Forms;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmReporteProvisiones : FrmMantenimientoBase
    {
        int TotalRow = 0;

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }

        List<ProvisionesE> oListaDetalle;

        public frmReporteProvisiones()
        {
            InitializeComponent();
            FormatoGrid(dgvListado, false, false, 30, 25, false);
        }

        void FormatoGrid(DataGridView oDgv, bool PrimerCol, Boolean EscogerVariasFilas = false, Int32 AltoCabecera = 25, Int32 AltoFilas = 20, Boolean MostrarColorAlterno = true)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = PrimerCol;
            oDgv.RowHeadersWidth = 20;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BackgroundColor = Color.LightSteelBlue;
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;

            if (MostrarColorAlterno)
            {
                oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            }

            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = EscogerVariasFilas;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = AltoCabecera;

            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = AltoFilas;
            lineas.MinimumHeight = 10;

            oDgv.Refresh();
        }


        private void frmReporteEEFFGanaciasPerdidasDetalle_Load(object sender, EventArgs e)
        {
            
            txtDesde.Value = Convert.ToDateTime("01/" + txtDesde.Value.Month.ToString("00") + "/" + txtDesde.Value.Year);
        }

        
        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13 || e.ColumnIndex == 14)
            {
                dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            }

            if (e.RowIndex >= TotalRow - 1)
            {
                dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {

            oListaDetalle = AgenteCtasPorPagar.Proxy.ListarProvisionesPorPeriodo(4, txtDesde.Value, txtHasta.Value);

            // ==========================================
            if (oListaDetalle == null || oListaDetalle.Count == 0)
            {
                dgvListado.DataSource = null;
                lblregistros.Text = "0 registros";
                Global.MensajeFault("No hay registros");
                return;
            }
            // ==========================================

            lblregistros.Text = oListaDetalle.Count.ToString() + " registros";

            decimal oimpTotalBase = oListaDetalle.Sum(x => x.impTotalBase);
            decimal oimpTotalSecun = oListaDetalle.Sum(x => x.impTotalSecun);

            oListaDetalle.Add(new ProvisionesE() { CodMonedaProvision = "", impTotalBase = oimpTotalBase, impTotalSecun = oimpTotalSecun });

            TotalRow = oListaDetalle.Count;

            bsProvisiones.DataSource = oListaDetalle;
            bsProvisiones.ResetBindings(false);
        }
        
        bool OrdenarColumnas01 = true;
        bool OrdenarColumnas02 = true;
        bool OrdenarColumnas03 = true;

        private void dgvListado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaDetalle != null)
            {
                if (e.Button == MouseButtons.Left)
                {   
                    // COLUMNA
                    if (e.ColumnIndex == dgvListado.Columns["impMonedaOrigenDataGridViewTextBoxColumn"].Index)
                    {
                        if (OrdenarColumnas01)
                        {
                            oListaDetalle = (from x in oListaDetalle orderby x.ImpMonedaOrigen ascending select x).ToList();
                            OrdenarColumnas01 = false;
                        }
                        else
                        {
                            oListaDetalle = (from x in oListaDetalle orderby x.ImpMonedaOrigen descending select x).ToList();
                            OrdenarColumnas01 = true;
                        }
                    }

                    // COLUMNA
                    if (e.ColumnIndex == dgvListado.Columns["razonSocialDataGridViewTextBoxColumn"].Index)
                    {
                        if (OrdenarColumnas02)
                        {
                            oListaDetalle = (from x in oListaDetalle orderby x.RazonSocial ascending select x).ToList();
                            OrdenarColumnas02 = false;
                        }
                        else
                        {
                            oListaDetalle = (from x in oListaDetalle orderby x.RazonSocial descending select x).ToList();
                            OrdenarColumnas02 = true;
                        }
                    }

                    // COLUMNA
                    if (e.ColumnIndex == dgvListado.Columns["desProvisionDataGridViewTextBoxColumn"].Index)
                    {
                        if (OrdenarColumnas03)
                        {
                            oListaDetalle = (from x in oListaDetalle orderby x.DesProvision ascending select x).ToList();
                            OrdenarColumnas03 = false;
                        }
                        else
                        {
                            oListaDetalle = (from x in oListaDetalle orderby x.DesProvision descending select x).ToList();
                            OrdenarColumnas03 = true;
                        }
                    }
                    
                    bsProvisiones.DataSource = oListaDetalle;
                }
            }
        }

        string RutaGeneral;

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
        }

        // ===========================
        // EXPORTAR EXCEL
        // ===========================
        void ExportarExcel(String Ruta)
        {
            
            String NombrePestaña = String.Empty;

            
            NombrePestaña = "Provisiones";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 2;
                    Int32 TotColumnas = dgvListado.ColumnCount;

                    #region Titulos Principales

                    // Creando Encabezado;
                    //oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    //using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    //{
                    //    Rango.Merge = true;
                    //    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                    //    Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    //    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                    //    Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    //}

                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
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
                        String titDetalle = dgvListado.Columns[i].HeaderText;

                        oHoja.Cells[InicioLinea, col].Value = titDetalle;
                        oHoja.Cells[InicioLinea, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, col].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        col++;
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;
                    col = 1;

                    foreach (ProvisionesE item in oListaDetalle)
                    {

                        oHoja.Cells[InicioLinea, 1].Value = item.CodPartidaPresu;
                        oHoja.Cells[InicioLinea, 2].Value = item.desPartidaPresu;

                        oHoja.Cells[InicioLinea, 3].Value = item.FechaProvision;
                        oHoja.Cells[InicioLinea, 4].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 5].Value = item.DesProvision;

                        oHoja.Cells[InicioLinea, 6].Value = item.FechaDocumento;
                        oHoja.Cells[InicioLinea, 7].Value = item.FechaVencimiento;

                        oHoja.Cells[InicioLinea, 8].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 9].Value = item.desDocumento;
                        oHoja.Cells[InicioLinea, 10].Value = item.NumSerie;
                        oHoja.Cells[InicioLinea, 11].Value = item.NumDocumento;
                        oHoja.Cells[InicioLinea, 12].Value = item.TipCambio;
                        oHoja.Cells[InicioLinea, 13].Value = item.CodMonedaProvision;

                        oHoja.Cells[InicioLinea, 14].Value = item.impTotalBase;
                        oHoja.Cells[InicioLinea, 15].Value = item.impTotalSecun;

                        oHoja.Cells[InicioLinea, 16].Value = item.EstadoProvision;
                        oHoja.Cells[InicioLinea, 17].Value = item.idComprobante;

                        oHoja.Cells[InicioLinea, 18].Value = item.numFile;
                        oHoja.Cells[InicioLinea, 19].Value = item.numVoucher;
                        oHoja.Cells[InicioLinea, 50].Value = item.codCuenta;
                        oHoja.Cells[InicioLinea, 20].Value = item.DesCuenta;

                        // FORMAT 
                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "dd/MM/yyyy";

                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 13].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;

                        InicioLinea++;
                    }

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    #region Datos de Archivo

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    //Insertando Encabezado
                    //oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                    oHoja.HeaderFooter.OddHeader.CenteredText = TituloGeneral;
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

                    //Guardando el excel
                    oExcel.Save();

                    #endregion
                }
            }

            Global.MensajeComunicacion("Se genero el archivo excel");
        }

        String TituloGeneral = String.Empty;

        private void btnExportar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvListado.RowCount == 0)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String dia = txtHasta.Value.Day.ToString("00");
                String mes = txtHasta.Value.Month.ToString("00");
                String anio = txtHasta.Value.Year.ToString();

                TituloGeneral = "Provisiones " + dia + "_" + mes + "_" + anio;

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", TituloGeneral, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    ExportarExcel(RutaGeneral);
                }

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }


        // ===========================
        // END
        // ===========================
    }
}
