using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Tesoreria.Reportes
{
    public partial class frmReporteCtaCteComparativo : FrmMantenimientoBase
    {

        public frmReporteCtaCteComparativo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            CargarCombos();
            FormatoGrid(dgvPivot, true);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        List<CtaCteE> oListaCtaCteComp = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Int32 Fila = 0;
        Int32 Col = 0;

        #endregion

        #region Procedimientos de Usuario

        void CargarCombos()
        {
            cboSaldo.DataSource = Global.CargarTipoSaldo();
            cboSaldo.ValueMember = "id";
            cboSaldo.DisplayMember = "Nombre";
        }

        void DecimalTotales()
        {
            Decimal totSoles = Decimal.Round((from x in oListaCtaCteComp where x.idMoneda == "01" select x.Diferencia).Sum(), 2);
            Decimal totDolares = Decimal.Round((from x in oListaCtaCteComp where x.idMoneda == "02" select x.Diferencia).Sum(), 2);
            lblDiferenciaSoles.Text = Decimal.Round(totSoles, 2).ToString("N2");
            lblDiferenciaDolares.Text = Decimal.Round(totDolares, 2).ToString("N2");
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = " Comparativo Cuenta Corriente ";
            NombrePestaña = " Comparativo Cuenta Corriente ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 15;

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

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " Cod. Cuenta";
                    oHoja.Cells[InicioLinea, 2].Value = " RUC ";
                    oHoja.Cells[InicioLinea, 3].Value = " Razon Social ";
                    oHoja.Cells[InicioLinea, 4].Value = " Documento";
                    oHoja.Cells[InicioLinea, 5].Value = " Num. Serie";
                    oHoja.Cells[InicioLinea, 6].Value = " Num. Documento";
                    oHoja.Cells[InicioLinea, 7].Value = " Fecha Documento";
                    oHoja.Cells[InicioLinea, 8].Value = " Fecha Vencimiento";
                    oHoja.Cells[InicioLinea, 9].Value = " Moneda ";
                    oHoja.Cells[InicioLinea, 10].Value = " Saldo Operativo Soles";
                    oHoja.Cells[InicioLinea, 11].Value = " Saldo Contable Soles";
                    oHoja.Cells[InicioLinea, 12].Value = " Saldo Operativo Dolares";
                    oHoja.Cells[InicioLinea, 13].Value = " Saldo Contable Dolares";
                    oHoja.Cells[InicioLinea, 14].Value = " Diferencia Soles";
                    oHoja.Cells[InicioLinea, 15].Value = " Diferencia Dolares";

                    for (int i = 1; i <= 15; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Detallado

                    Decimal Total1Sol = 0;
                    Decimal Total2Sol = 0;
                    Decimal Total3Dol = 0;
                    Decimal Total4Dol = 0;
                    Decimal cero = 0;
                    Decimal Total1SolSUB = 0;
                    Decimal Total2SolSUB = 0;
                    Decimal Total3DolSUB = 0;
                    Decimal Total4DolSUB = 0;
                    Decimal ColDif1 = 0;
                    Decimal ColDif2 = 0;
                    Decimal Total5Dif1 = 0;
                    Decimal Total6Dif2 = 0;
                    int contador = 0;
                    string CodCuenta = "";
                    for (int i = 0; i < oListaCtaCteComp.Count; i++)
                    {

                        if (contador == 0)
                        {
                            CodCuenta = oListaCtaCteComp[i].codCuenta;
                        }

                        if (CodCuenta != oListaCtaCteComp[i].codCuenta)
                        {
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Value = " ";
                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 9].Value = "SUB TOTAL GENERAL";
                            oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            oHoja.Cells[InicioLinea, 10].Value = Total1SolSUB;
                            oHoja.Cells[InicioLinea, 11].Value = Total2SolSUB;
                            oHoja.Cells[InicioLinea, 12].Value = Total3DolSUB;
                            oHoja.Cells[InicioLinea, 13].Value = Total4DolSUB;
                            Total5Dif1 = Total1SolSUB - Total2SolSUB;
                            Total6Dif2 = Total3DolSUB - Total4DolSUB;
                            oHoja.Cells[InicioLinea, 14].Value = Total5Dif1;
                            oHoja.Cells[InicioLinea, 15].Value = Total6Dif2;

                            oHoja.Cells[InicioLinea, 10, InicioLinea, TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Value = " ";
                            InicioLinea++;


                            Total1SolSUB = 0;
                            Total2SolSUB = 0;
                            Total3DolSUB = 0;
                            Total4DolSUB = 0;
                            Total5Dif1 = 0;
                            Total6Dif2 = 0;
                            CodCuenta = oListaCtaCteComp[i].codCuenta;
                        }


                        oHoja.Cells[InicioLinea, 1].Value = oListaCtaCteComp[i].codCuenta;
                        oHoja.Cells[InicioLinea, 2].Value = oListaCtaCteComp[i].RUC;
                        oHoja.Cells[InicioLinea, 3].Value = oListaCtaCteComp[i].RazonSocial;
                        oHoja.Cells[InicioLinea, 4].Value = oListaCtaCteComp[i].idDocumento;
                        oHoja.Cells[InicioLinea, 5].Value = oListaCtaCteComp[i].numSerie;
                        oHoja.Cells[InicioLinea, 6].Value = oListaCtaCteComp[i].numDocumento;
                        oHoja.Cells[InicioLinea, 7].Value = oListaCtaCteComp[i].FechaDocumento;
                        oHoja.Cells[InicioLinea, 8].Value = oListaCtaCteComp[i].FechaVencimiento;
                        oHoja.Cells[InicioLinea, 9].Value = oListaCtaCteComp[i].idMoneda;
                        if (oListaCtaCteComp[i].idMoneda == Variables.Soles)
                        {
                            oHoja.Cells[InicioLinea, 10].Value = oListaCtaCteComp[i].SaldoOperativo;
                            oHoja.Cells[InicioLinea, 11].Value = oListaCtaCteComp[i].SaldoContable;
                            Total1Sol += oListaCtaCteComp[i].SaldoOperativo;
                            Total2Sol += oListaCtaCteComp[i].SaldoContable;
                            oHoja.Cells[InicioLinea, 12].Value = cero;
                            oHoja.Cells[InicioLinea, 13].Value = cero;
                            Total1SolSUB += oListaCtaCteComp[i].SaldoOperativo;
                            Total2SolSUB += oListaCtaCteComp[i].SaldoContable;
                            Total5Dif1 = oListaCtaCteComp[i].SaldoOperativo - oListaCtaCteComp[i].SaldoContable;
                            oHoja.Cells[InicioLinea, 14].Value = Total5Dif1;
                            oHoja.Cells[InicioLinea, 15].Value = cero;
                            ColDif1 += Total5Dif1;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 10].Value = cero;
                            oHoja.Cells[InicioLinea, 11].Value = cero;
                            oHoja.Cells[InicioLinea, 12].Value = oListaCtaCteComp[i].SaldoOperativo;
                            oHoja.Cells[InicioLinea, 13].Value = oListaCtaCteComp[i].SaldoContable;
                            Total3Dol += oListaCtaCteComp[i].SaldoOperativo;
                            Total4Dol += oListaCtaCteComp[i].SaldoContable;
                            Total3DolSUB += oListaCtaCteComp[i].SaldoOperativo;
                            Total4DolSUB += oListaCtaCteComp[i].SaldoContable;
                            Total6Dif2 = oListaCtaCteComp[i].SaldoOperativo - oListaCtaCteComp[i].SaldoContable;
                            oHoja.Cells[InicioLinea, 14].Value = cero;
                            oHoja.Cells[InicioLinea, 15].Value = Total6Dif2;
                            ColDif2 += Total6Dif2;
                        }
                        // FORMAT 
                        oHoja.Cells[InicioLinea, 10, InicioLinea, TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 7, InicioLinea, 8].Style.Numberformat.Format = "dd/MM/yyyy";
                        InicioLinea++;
                        contador++;
                    }

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Value = " ";
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 9].Value = "SUB TOTAL GENERAL";
                    oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    oHoja.Cells[InicioLinea, 10].Value = Total1SolSUB;
                    oHoja.Cells[InicioLinea, 11].Value = Total2SolSUB;
                    oHoja.Cells[InicioLinea, 12].Value = Total3DolSUB;
                    oHoja.Cells[InicioLinea, 13].Value = Total4DolSUB;
                    Total5Dif1 = Total1SolSUB - Total2SolSUB;
                    Total6Dif2 = Total3DolSUB - Total4DolSUB;
                    oHoja.Cells[InicioLinea, 14].Value = Total5Dif1;
                    oHoja.Cells[InicioLinea, 15].Value = Total6Dif2;

                    oHoja.Cells[InicioLinea, 10, InicioLinea, TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Value = " ";
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 9].Value = "TOTAL GENERAL";
                    oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    oHoja.Cells[InicioLinea, 10].Value = Total1Sol;
                    oHoja.Cells[InicioLinea, 11].Value = Total2Sol;
                    oHoja.Cells[InicioLinea, 12].Value = Total3Dol;
                    oHoja.Cells[InicioLinea, 13].Value = Total4Dol;
                    oHoja.Cells[InicioLinea, 14].Value = ColDif1;
                    oHoja.Cells[InicioLinea, 15].Value = ColDif2;

                    // FORMAT 
                    oHoja.Cells[InicioLinea, 10, InicioLinea, TotColumnas].Style.Numberformat.Format = "###,###,##0.00";
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Value = " ";
                    InicioLinea++;

                    #endregion

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
        }

        #endregion

        #region Procedimientos Heredados

        public override void Imprimir()
        {
            CerrarFormulario("frmReporteCtaCteComparativoImprimir");

            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteCtaCteComparativoImprimir);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            oFrm = new frmReporteCtaCteComparativoImprimir(oListaCtaCteComp)
            {
                MdiParent = MdiParent
            };

            oFrm.Show();
        }

        public override void Buscar()
        {
            try
            {
                Int32 idPersona = Convert.ToInt32(txtIdProveedor.Text);
                DateTime DtpTmp = dtpFiltro.Value.Date;

                bsCtaCte.DataSource = oListaCtaCteComp = AgenteTesoreria.Proxy.ListarReporteCtaCteComparado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idPersona, DtpTmp.Date, cboSaldo.SelectedValue.ToString());
                bsCtaCte.ResetBindings(false);

                DecimalTotales();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Exportar()
        {
            try
            {
                if (oListaCtaCteComp == null || oListaCtaCteComp.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Comparativo Cta. Cte. ", "Archivos Excel (*.xlsx)|*.xlsx");
                ExportarExcel(RutaGeneral);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void btBuscar_Click(object sender, EventArgs e)
        {
            frmBusquedaProveedor oFrm = new frmBusquedaProveedor();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProveedor != null)
            {
                txtIdProveedor.Text = Convert.ToString(oFrm.oProveedor.IdPersona);
                txtRazonSocial.Text = oFrm.oProveedor.RazonSocial;
            }
        }

        private void frmReporteCtaCteComparativo_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvPivot.Columns["idCtaCte"].Visible = false;
            }

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }

        private void dgvPivot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {              
                if (e.RowIndex != -1)
                {
                    Int32 Columna = 0;
                    Decimal Valorcero = 0;
                    Decimal des3 = 0;

                    if (dgvPivot.Columns[e.ColumnIndex].Name == "Diferencia")
                    {
                        Columna = 1;
                        des3 = Convert.ToDecimal(dgvPivot.Rows[e.RowIndex].Cells[16].Value);
                    }

                    if (des3 != Valorcero && Columna == 1)
                    {
                        dgvPivot.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(186, 225, 143);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPivot_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CerrarFormulario("frmReporteCtaCteComparativoDetalle");

            Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteCtaCteComparativoDetalle);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            List<VoucherItemE> oListaVoucherItem = null;
            List<CtaCteE> oListaCtaCteDet = null;

            CtaCteE Oreg  = (CtaCteE)bsCtaCte.Current;
            String Mes = string.Empty;

            if (dtpFiltro.Value.Month < 10)
            {
                 Mes = "0" + dtpFiltro.Value.Month.ToString();
            }
            else
            {
                 Mes = dtpFiltro.Value.Month.ToString();
            }

            oListaVoucherItem = AgenteContabilidad.Proxy.ListaVoucherItemPorDcmtoCtaCte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpFiltro.Value.Year.ToString(), Mes,Oreg.codCuenta,Oreg.idPersona,Oreg.idDocumento,Oreg.numSerie,Oreg.numDocumento);
            oListaCtaCteDet = AgenteTesoreria.Proxy.ObtenerMaeCtaCteDetalladoPorId(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Oreg.idCtaCte,dtpFiltro.Value.Date);

            oFrm = new frmReporteCtaCteComparativoDetalle(oListaVoucherItem, oListaCtaCteDet)
            {
                MdiParent = MdiParent
            };

            oFrm.Show();
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = "0";
            txtRUC.Text = String.Empty;
        }

        private void txtRUC_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text ="0";
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && string.IsNullOrEmpty(txtRUC.Text.Trim()))
                {
                    txtRUC.TextChanged -= txtRUC_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRUC.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRUC.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRUC.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtIdProveedor.Text = "0";
                        txtRUC.Focus();
                    }

                    txtRUC.TextChanged += txtRUC_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRUC_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRUC.Text.Trim()) && string.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRUC.TextChanged -= txtRUC_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRUC.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRUC.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRUC.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRUC.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtIdProveedor.Text = "0";
                        txtRUC.Focus();
                      
                    }

                    txtRUC.TextChanged += txtRUC_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsCtaCte_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblregistros.Text = "Registros " + bsCtaCte.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPivot.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    VariablesLocales.CopiarCelda(dgvPivot);
                    //Volviendo al modo de selección de toda la fila
                    dgvPivot.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //Seleccionar la toda la fila actual
                    dgvPivot.CurrentCell = dgvPivot.Rows[Fila].Cells[Col];
                    dgvPivot.Rows[Fila].Selected = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPivot_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //Obteniendo la fila y la columna actual
                    Fila = e.RowIndex;
                    Col = e.ColumnIndex;

                    //Si se trata del modo FullRowSelect, lo volvemos a seleccion de una celda
                    if (dgvPivot.SelectedRows.Count > 0)
                    {
                        dgvPivot.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    }

                    //Nos ubicamos en la celda que se quier copiar
                    dgvPivot.CurrentCell = dgvPivot.Rows[Fila].Cells[Col];
                    dgvPivot.Rows[Fila].Cells[Col].Selected = true;

                    //Aparece el Menú...
                    dgvPivot.ContextMenuStrip = cmsPopup;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
        
        #endregion

    }
}


