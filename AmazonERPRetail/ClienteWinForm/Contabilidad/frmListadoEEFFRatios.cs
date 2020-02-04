using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoEEFFRatios : FrmMantenimientoBase
    {

        public frmListadoEEFFRatios()
        {
            InitializeComponent();
            FormatoGrid(dgvListadoEEFF, true);
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<EEFFRatiosE> oLista = new List<EEFFRatiosE>();

        #endregion

        #region Procedimientos

        public override void Buscar()
        {
            try
            {
                oLista = AgenteContabilidad.Proxy.ListarEEFFRatios(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oLista.Count > 0)
                {
                    base.Grabar();
                    BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
                    bsEEFFRatios.DataSource = oLista;
                    bsEEFFRatios.ResetBindings(false);

                    lblRegistros.Text = "Estados Financieros - Ratios -" + bsEEFFRatios.Count.ToString() + " Registros";
                }
                else
                {
                    Global.MensajeComunicacion("No hay registro");
                }

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsEEFFRatios.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEEFFRatios);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmEEFFRatios(((EEFFRatiosE)bsEEFFRatios.Current).idEmpresa, ((EEFFRatiosE)bsEEFFRatios.Current).idItem);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Nuevo()
        {
            try
            {
                if (!ValidarIngresoVentana())
                {
                    return;
                }

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEEFFRatios);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmEEFFRatios();

                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsEEFFRatios.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarEEFFRatios(((EEFFRatiosE)bsEEFFRatios.Current).idEmpresa, ((EEFFRatiosE)bsEEFFRatios.Current).idItem);
                        oLista.RemoveAt(bsEEFFRatios.Position);
                        bsEEFFRatios.DataSource = oLista;
                        bsEEFFRatios.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImprimirEEFFRatios);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }
               
                oFrm = new frmImprimirEEFFRatios(oLista);
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Exportar()
        {
            try
            {
                if (oLista.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "EEFF_RATIOS", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("EEFFRATIOS");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 11;

                                #region Titulos Principales

                                // Creando Encabezado;
                                oHoja.Cells["A1"].Value = "RATIOS";

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }

                                oHoja.Cells["A2"].Value = " 2017 "  ;

                                using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                }

                                #endregion


                                InicioLinea++;

                                String NumeroTablaEspacio = "";

                                foreach (EEFFRatiosE item in oLista)
                                {

                                    NumeroTablaEspacio = item.TipoTabla;

                                    if (NumeroTablaEspacio == "TIT")
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";
                                        oHoja.Cells[InicioLinea, 3].Value = " ";
                                        InicioLinea++;
                                    }

                                    if (item.TipoTabla == "TIT")
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = item.desItem;

                                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 1])
                                        {
                                            Rango.Merge = true;
                                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Calibri", 14, FontStyle.Bold));
                                            Rango.Style.Font.Color.SetColor(Color.Black);
                                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(229, 112, 59));
                                        }

                                        oHoja.Cells[InicioLinea, 2].Value = item.desGlosa;
                                    }
                                    else
                                    {
                                        oHoja.Cells[InicioLinea, 1].Value = item.desItem;

                                        oHoja.Cells[InicioLinea, 2].Value = item.desGlosa;
                                    }

                                    oHoja.Cells[InicioLinea, 3].Value = item.Formula;                                                                                                  

                                    InicioLinea++;
                                }

                                //Ajustando el ancho de las columnas automaticamente
                                oHoja.Cells.AutoFitColumns(0);
                                //Pie de Pagina(Derecho) "Número de paginas y el total"
                                oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                                //Pie de Pagina(centro)
                                oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                                //Otras Propiedades
                                //oHoja.Workbook.Properties.Title = TituloGeneral;
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Modulo de Ventas";
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
                else
                {
                    Global.MensajeFault("No hay datos para la exportación...");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion 

        #region Eventos

        private void frmListadoEEFFRatios_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            Buscar();
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmEEFFRatios oFrm = sender as frmEEFFRatios;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void dgvListadoEEFF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvListadoEEFF_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvListadoEEFF.Rows[e.RowIndex].Cells[4].Value.ToString() == "TOT" || dgvListadoEEFF.Rows[e.RowIndex].Cells[4].Value.ToString() == "TIT")
                    {

                        //e.CellStyle.Font = new Font(dgvListadoEEFF.Font, FontStyle.Bold);

                        if (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
                        {
                            dgvListadoEEFF.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font(dgvListadoEEFF.Font, FontStyle.Bold);
                        }

                    }
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
