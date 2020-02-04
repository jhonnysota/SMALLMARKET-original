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
    public partial class frmReporteFlujoDeCajaDetalle : FrmMantenimientoBase
    {
        public frmReporteFlujoDeCajaDetalle()
        {
            InitializeComponent();
            FormatoGrid(dgvListado, true);
        }

        private void frmReporteEEFFGanaciasPerdidasDetalle_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        public frmReporteFlujoDeCajaDetalle(List<FlujoDeCajaE> oListaDetalle)
            : this()
        {
            oListaFlujo = oListaDetalle;
            decimal impDebe  = oListaDetalle.Sum(x => x.DEBE);
            decimal impHaber = oListaDetalle.Sum(x => x.HABER);
            //Decimal Total1   = 0;
            //Decimal Total2   = 0;
            FlujoDeCajaE oSubTotales = new FlujoDeCajaE { DEBE = impDebe, HABER = impHaber };

            txtSubDebe.Text = impDebe.ToString("N2");
            txtSubHaber.Text = impHaber.ToString("N2");

            Decimal Resto = 0;

            if (impDebe > impHaber)
            {
                Resto = impDebe - impHaber;
                textrziq.Visible = true;
                textrziq.Text = Resto.ToString("N2");

            }
            else if (impDebe < impHaber)
            {
                Resto = impHaber - impDebe;
                textder.Visible = true;
                textder.Text = Resto.ToString("N2");
            }

            //if (impDebe > impHaber)
            //{
            //    Total1 = impDebe - impHaber;
            //    txtDebe.Text = Total1.ToString("N2");
            //}
            //else
            //{
            //    txtDebe.Text = Total1.ToString("N2");
            //}

            //if (impHaber > impDebe)
            //{
            //    Total2 = impHaber - impDebe;
            //    txtHaber.Text = Total2.ToString("N2");
            //}
            //else
            //{
            //    txtHaber.Text = Total2.ToString("N2");
            //}

            bsFlujoDeCaja.DataSource = oListaDetalle;
            bsFlujoDeCaja.ResetBindings(false);

            lblregistros.Text =  (oListaDetalle.Count-2).ToString() + " registros";
        }

        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex >= bsVoucherItem.Count - 2)
            //{
            //    dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            //}
        }


        #region Variables

        List<FlujoDeCajaE> oListaFlujo = null;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion


        #region proc

        public override void Editar()
        {
            try
            {
                //Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVoucher);

                //if (oFrm != null)
                //{
                //    if (oFrm.WindowState == FormWindowState.Minimized)
                //    {
                //        oFrm.WindowState = FormWindowState.Normal;
                //    }

                //    oFrm.BringToFront();
                //    return;
                //}

                //VoucherE Voucher = new VoucherE();
                //FlujoDeCajaE item = (FlujoDeCajaE)bs.Current;


                //    Voucher.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                //    Voucher.idLocal = VariablesLocales.SesionLocal.IdLocal;
                //    Voucher.AnioPeriodo = item.AnioPeriodo;
                //    Voucher.MesPeriodo = item.MesPeriodo;
                //    Voucher.numVoucher = item.numVoucher;
                //    Voucher.idComprobante = item.idComprobante;
                //    Voucher.numFile = item.numFile;
                

                //if (Voucher != null)
                //{

                //    oFrm = new frmVoucher(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile,"DESACTIVADO");
                //    oFrm.MdiParent = this.MdiParent;
                //    oFrm.Show();
                //}

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region

        void ExportarExcel(String Ruta)
        {

            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;



            TituloGeneral = " Flujo De Cajas";
            NombrePestaña = " Reporte Flujo De Cajas.";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 14;

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
                    oHoja.Cells[InicioLinea, 1].Value = "RANGO";
                    oHoja.Cells[InicioLinea, 2].Value = "COD_PARTIDA ";                   
                    oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    oHoja.Column(2).Width = 13;
                    oHoja.Cells[InicioLinea, 3].Value = " PARTIDA_PRESU";
                    oHoja.Column(3).Width = 17;
                    oHoja.Cells[InicioLinea, 4].Value = " LIBRO ";
                    oHoja.Column(4).Width = 8;
                    oHoja.Cells[InicioLinea, 5].Value = " NFILE ";
                    oHoja.Column(5).Width = 8;
                    oHoja.Cells[InicioLinea, 6].Value = " NUMERO ";
                    oHoja.Column(6).Width = 12;

                    oHoja.Cells[InicioLinea, 7].Value = " ITEM ";
                    oHoja.Column(7).Width = 7;

                    oHoja.Cells[InicioLinea, 8].Value = " CUENTA ";
                    oHoja.Column(8).Width = 8;

                    oHoja.Cells[InicioLinea, 9].Value = " FECHA_COMP ";
                    oHoja.Column(9).Width = 12;

                    oHoja.Cells[InicioLinea, 10].Value = " GLOSA ";
                    oHoja.Column(10).Width = 72;

                    oHoja.Cells[InicioLinea, 11].Value = " DOCUMENTO ";
                    oHoja.Column(11).Width = 12;

                    oHoja.Cells[InicioLinea, 12].Value = " FECHA_EMIS";
                    oHoja.Column(12).Width = 12;

                    oHoja.Cells[InicioLinea, 13].Value = " DEBE";
                    oHoja.Column(13).Width = 15;

                    oHoja.Cells[InicioLinea, 14].Value = " HABER";
                    oHoja.Column(14).Width = 15;



                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    for (int i = 1; i <= 14; i++)
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

                    foreach (FlujoDeCajaE item in oListaFlujo)
                    {



                        if (item.RANGO != null)
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.RANGO;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 1].Value = "";
                        }

                        if (item.COD_PARTIDA_PRES != null)
                        {
                            oHoja.Cells[InicioLinea, 2].Value = item.COD_PARTIDA_PRES;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 2].Value = "";
                        }

                        if (item.PARTIDA_PRESU != null)
                        {
                            oHoja.Cells[InicioLinea, 3].Value = item.PARTIDA_PRESU;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 3].Value = "";
                        }



                        if (item.LIBRO != null)
                        {
                            oHoja.Cells[InicioLinea, 4].Value = item.LIBRO;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 4].Value = "";
                        }



                        if (item.NFILE != null)
                        {
                            oHoja.Cells[InicioLinea, 5].Value = item.NFILE;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 5].Value = "";
                        }



                        if (item.NUMERO != null)
                        {
                            oHoja.Cells[InicioLinea, 6].Value = item.NUMERO;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 6].Value = "";
                        }

                        if (item.ITEM != null)
                        {
                            oHoja.Cells[InicioLinea, 7].Value = item.ITEM;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 7].Value = "";
                        }

                        if (item.CUENTA != null)
                        {

                            oHoja.Cells[InicioLinea, 8].Value = item.CUENTA;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 8].Value = "";
                        }
                        if (item.FECHA_COMP != null)
                        {

                            oHoja.Cells[InicioLinea, 9].Value = item.FECHA_COMP.Value.ToString("d");
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 9].Value = "";
                        }

                        if (item.GLOSA != null)
                        {

                            oHoja.Cells[InicioLinea, 10].Value = item.GLOSA;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 10].Value = "";
                        }

                        if (item.DOCUMENTO != null)
                        {

                            oHoja.Cells[InicioLinea, 11].Value = item.DOCUMENTO;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 11].Value = "";
                        }

                        if (item.FECHA_EMIS != null)
                        {

                            oHoja.Cells[InicioLinea, 12].Value = item.FECHA_EMIS.Value.ToString("d");
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 12].Value = "";
                        }

                        oHoja.Cells[InicioLinea, 13].Value = item.DEBE;

                        oHoja.Cells[InicioLinea, 14].Value = item.HABER;




                        // FORMAT 
                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";

                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";

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
                    oHoja.Cells[InicioLinea, 13].Value = "----------------";
                    oHoja.Cells[InicioLinea, 14].Value = "----------------";

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
                    oHoja.Cells[InicioLinea, 12].Value = "Saldos : ";
                    oHoja.Cells[InicioLinea, 13].Value = Convert.ToDecimal(txtSubDebe.Text);
                    oHoja.Cells[InicioLinea, 14].Value = Convert.ToDecimal(txtSubHaber.Text);

                    oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";

                    oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";

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

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaFlujo == null)
                {
                    Global.MensajeFault("No hay Registros para exportar a Excel.");
                    return;
                }
                if (oListaFlujo.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Registro de Flujo De Cajas", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Marque = "Importando los Registro de Flujos a Excel...";
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
    }
}
