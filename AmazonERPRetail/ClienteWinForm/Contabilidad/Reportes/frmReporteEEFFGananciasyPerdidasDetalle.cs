using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteEEFFGananciasyPerdidasDetalle : FrmMantenimientoBase
    {
        #region Constructores
        public frmReporteEEFFGananciasyPerdidasDetalle()
        {
            InitializeComponent();
            FormatoGrid(dgvListado, true);
        }

        public frmReporteEEFFGananciasyPerdidasDetalle(List<VoucherItemE> oListaDetalle, string desItem)
            : this()
        {
            oListaVoucher = oListaDetalle;
            decimal impDebe  = oListaDetalle.Sum(x => x.impDebe);
            decimal impHaber = oListaDetalle.Sum(x => x.impHaber);
            Decimal Total1   = 0;
            Decimal Total2   = 0;
            VoucherItemE oSubTotales = new VoucherItemE { impDebe = impDebe, impHaber = impHaber };
            //oListaDetalle.Add(oSubTotales);

            txtSubDebe.Text = impDebe.ToString("N2");
            txtSubHaber.Text = impHaber.ToString("N2");

            if (impDebe > impHaber)
            {
                Total1 = impDebe - impHaber;
                txtDebe.Text = Total1.ToString("N2");
            }
            else
            {
                txtDebe.Text = Total1.ToString("N2");
            }

            if (impHaber > impDebe)
            {
                Total2 = impHaber - impDebe;
                txtHaber.Text = Total2.ToString("N2");
            }
            else
            {
                txtHaber.Text = Total2.ToString("N2");
            }

            bsVoucherItem.DataSource = oListaDetalle;
            bsVoucherItem.ResetBindings(false);

            lblregistros.Text = desItem + " - " + (oListaDetalle.Count-2).ToString() + " registros";
        }

        #endregion 

        #region Variables

        List<VoucherItemE> oListaVoucher = null;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Boolean Ordenar = false;

        #endregion

        #region proc

        public override void Editar()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVoucher);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                VoucherE Voucher = new VoucherE();
                VoucherItemE item = (VoucherItemE)bsVoucherItem.Current;


                    Voucher.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    Voucher.idLocal = VariablesLocales.SesionLocal.IdLocal;
                    Voucher.AnioPeriodo = item.AnioPeriodo;
                    Voucher.MesPeriodo = item.MesPeriodo;
                    Voucher.numVoucher = item.numVoucher;
                    Voucher.idComprobante = item.idComprobante;
                    Voucher.numFile = item.numFile;
                

                if (Voucher != null)
                {

                    oFrm = new frmVoucher(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile,"DESACTIVADO");
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.Show();
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



            TituloGeneral = " Estado Ganancias y Perdidas Detallado";
            NombrePestaña = " Reporte EEFF DET.";

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
                    oHoja.Cells[InicioLinea, 1].Value = "LIBRO";
                    oHoja.Cells[InicioLinea, 2].Value = "FILE ";
                    oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                    oHoja.Cells[InicioLinea, 3].Value = " NÚMERO VOUCHER ";
                    oHoja.Cells[InicioLinea, 4].Value = " ITEM ";
                    oHoja.Cells[InicioLinea, 5].Value = " CUENTA ";
                    oHoja.Cells[InicioLinea, 6].Value = " FECHA DE OPERACION ";
                    oHoja.Column(6).Width = 12;

                    oHoja.Cells[InicioLinea, 7].Value = " GLOSA ";
                    oHoja.Column(7).Width = 55;

                    oHoja.Cells[InicioLinea, 8].Value = " CENTRO DE COSTO ";
                    oHoja.Column(8).Width = 55;

                    oHoja.Cells[InicioLinea, 9].Value = " DESCRIPCION ";
                    oHoja.Column(9).Width = 55;

                    oHoja.Cells[InicioLinea, 10].Value = " TIPO DE DOC. ";

                    oHoja.Cells[InicioLinea, 11].Value = " SERIE ";

                    oHoja.Cells[InicioLinea, 12].Value = " NUMERO DOC.";
                    oHoja.Column(12).Width = 20;

                    oHoja.Cells[InicioLinea, 13].Value = " EMISION";
                    oHoja.Column(13).Width = 12;

                    oHoja.Cells[InicioLinea, 14].Value = " DEBE";
                    oHoja.Column(14).Width = 15;
                    oHoja.Cells[InicioLinea, 15].Value = " HABER ";
                    oHoja.Column(15).Width = 15;


                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    for (int i = 1; i <= 15; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }




                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    #endregion

                    foreach (VoucherItemE item in oListaVoucher)
                    {



                        if (item.idComprobante != null)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.idComprobante;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1].Value = "";
                        }

                        if (item.numFile != null)
                        {
                            oHoja.Cells[InicioLinea, 2].Value = item.numFile;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 2].Value = "";
                        }

                        if (item.numVoucher != null)
                        {
                            oHoja.Cells[InicioLinea, 3].Value = item.numVoucher;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 3].Value = "";
                        }



                        if (item.numItem != null)
                        {
                            oHoja.Cells[InicioLinea, 4].Value = item.numItem;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 4].Value = "";
                        }



                        if (item.codCuenta != null)
                        {
                            oHoja.Cells[InicioLinea, 5].Value = item.codCuenta;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 5].Value = "";
                        }



                        if (item.fecOperacion != null)
                        {
                            oHoja.Cells[InicioLinea, 6].Value = item.fecOperacion.Value.ToString("d");
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 6].Value = "";
                        }

                        if (item.desGlosa != null)
                        {
                            oHoja.Cells[InicioLinea, 7].Value = item.desGlosa;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 7].Value = "";
                        }

                        if (item.desCCostos != null)
                        {

                            oHoja.Cells[InicioLinea, 8].Value = item.desCCostos;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 8].Value = "";
                        }
                        if (item.DesPersona != null)
                        {

                            oHoja.Cells[InicioLinea, 9].Value = item.DesPersona;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 9].Value = "";
                        }

                        if (item.idDocumento != null)
                        {

                            oHoja.Cells[InicioLinea, 10].Value = item.idDocumento;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 10].Value = "";
                        }

                        if (item.serDocumento != null)
                        {

                            oHoja.Cells[InicioLinea, 11].Value = item.serDocumento;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 11].Value = "";
                        }

                        if (item.numDocumento != null)
                        {

                            oHoja.Cells[InicioLinea, 12].Value = item.numDocumento;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 12].Value = "";
                        }

                        if (item.fecDocumento != null)
                        {


                            oHoja.Cells[InicioLinea, 13].Value = item.fecDocumento.Value.ToString("d");
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 13].Value = "";
                        }



                        oHoja.Cells[InicioLinea, 14].Value = item.impDebe;




                        oHoja.Cells[InicioLinea, 15].Value = item.impHaber;




                        // FORMAT 
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                    }
                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = " ";
                    oHoja.Cells[InicioLinea, 7].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = " ";
                    oHoja.Cells[InicioLinea, 9].Value = " ";
                    oHoja.Cells[InicioLinea, 10].Value = " ";
                    oHoja.Cells[InicioLinea, 11].Value = " ";
                    oHoja.Cells[InicioLinea, 12].Value = " ";
                    oHoja.Cells[InicioLinea, 13].Value = " ";
                    oHoja.Cells[InicioLinea, 14].Value = "----------------";
                    oHoja.Cells[InicioLinea, 15].Value = "----------------";

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = " ";
                    oHoja.Cells[InicioLinea, 7].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = " ";
                    oHoja.Cells[InicioLinea, 9].Value = " ";
                    oHoja.Cells[InicioLinea, 10].Value = " ";
                    oHoja.Cells[InicioLinea, 11].Value = " ";
                    oHoja.Cells[InicioLinea, 12].Value = " ";
                    oHoja.Cells[InicioLinea, 13].Value = "SUBTOTALES : ";
                    oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(txtSubDebe.Text);
                    oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(txtSubHaber.Text);

                    oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = " ";
                    oHoja.Cells[InicioLinea, 7].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = " ";
                    oHoja.Cells[InicioLinea, 9].Value = " ";
                    oHoja.Cells[InicioLinea, 10].Value = " ";
                    oHoja.Cells[InicioLinea, 11].Value = " ";
                    oHoja.Cells[InicioLinea, 12].Value = " ";
                    oHoja.Cells[InicioLinea, 13].Value = " ";
                    oHoja.Cells[InicioLinea, 14].Value = "----------------";
                    oHoja.Cells[InicioLinea, 15].Value = "----------------";

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " ";
                    oHoja.Cells[InicioLinea, 2].Value = " ";
                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 4].Value = " ";
                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = " ";
                    oHoja.Cells[InicioLinea, 7].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = " ";
                    oHoja.Cells[InicioLinea, 9].Value = " ";
                    oHoja.Cells[InicioLinea, 10].Value = " ";
                    oHoja.Cells[InicioLinea, 11].Value = " ";
                    oHoja.Cells[InicioLinea, 12].Value = " ";
                    oHoja.Cells[InicioLinea, 13].Value = "SALDO : ";
                    oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(txtDebe.Text);
                    oHoja.Cells[InicioLinea, 15].Value = Convert.ToDecimal(txtHaber.Text);

                    oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";

                    InicioLinea++;

                    //FIN SUMATORIA //


                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    //oHoja.Cells.AutoFitColumns(0);

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

        #region Eventos

        private void frmReporteEEFFGanaciasPerdidasDetalle_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            //this.Location = new Point(0, 0);
            //this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            

        }


        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (e.Value != null)
                {
                    if (dgvListado.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        string indccosto = dgvListado.Rows[e.RowIndex].Cells[0].Value.ToString();
                        if (indccosto == "N")
                        {
                            dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Red;
                        }
                    }
                }
                
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaVoucher == null)
                {
                    Global.MensajeFault("No hay Registros para exportar a Excel.");
                    return;
                }
                if (oListaVoucher.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Estado Financieros Ganancias y Perdidas", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Marque = "Importando los Registro de Compras a Excel...";
                    Cursor = Cursors.WaitCursor;
                    ExportarExcel(RutaGeneral);
                    Global.MensajeComunicacion("Su archivo ha sido exportado");
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

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvListado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaVoucher != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // POR IDCOMPROBANTE
                    if (e.ColumnIndex == dgvListado.Columns["idComprobante"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.idComprobante ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.idComprobante descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR NUM FILE
                    if (e.ColumnIndex == dgvListado.Columns["numFile"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.numFile ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.numFile descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR numVoucher
                    if (e.ColumnIndex == dgvListado.Columns["numVoucher"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.numVoucher ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.numVoucher descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR numItem
                    if (e.ColumnIndex == dgvListado.Columns["numItem"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.numItem ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.numItem descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR codCuenta
                    if (e.ColumnIndex == dgvListado.Columns["codCuenta"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.codCuenta ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.codCuenta descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR fecOperacion
                    if (e.ColumnIndex == dgvListado.Columns["fecOperacion"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.fecOperacion ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.fecOperacion descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR desGlosa
                    if (e.ColumnIndex == dgvListado.Columns["desGlosa"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.desGlosa ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.desGlosa descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR desCCostos
                    if (e.ColumnIndex == dgvListado.Columns["desCCostos"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.desCCostos ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.desCCostos descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR DesPersona
                    if (e.ColumnIndex == dgvListado.Columns["DesPersona"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.DesPersona ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.DesPersona descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR idDocumento
                    if (e.ColumnIndex == dgvListado.Columns["idDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.idDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.idDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR serDocumento
                    if (e.ColumnIndex == dgvListado.Columns["serDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.serDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.serDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR numDocumento
                    if (e.ColumnIndex == dgvListado.Columns["numDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.numDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.numDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR fecDocumento
                    if (e.ColumnIndex == dgvListado.Columns["fecDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.fecDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.fecDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR impDebe
                    if (e.ColumnIndex == dgvListado.Columns["impDebe"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.impDebe ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.impDebe descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR impHaber
                    if (e.ColumnIndex == dgvListado.Columns["impHaber"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.impHaber ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaVoucher = (from x in oListaVoucher orderby x.impHaber descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                }

                bsVoucherItem.DataSource = oListaVoucher;
            }
        }

        #endregion

    }
}
