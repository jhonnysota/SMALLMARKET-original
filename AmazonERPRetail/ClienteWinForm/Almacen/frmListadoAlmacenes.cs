using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen
{
    public partial class frmListadoAlmacenes : FrmMantenimientoBase
    {

        public frmListadoAlmacenes()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvAlmacen, true);
            LlenarCombo();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<AlmacenE> ListaAlmacen = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ParTabla> ListarTipoAlmacenes = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("TIPART");
            ParTabla ta = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos };
            ListarTipoAlmacenes.Add(ta);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListarTipoAlmacenes orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);
            cboTipoAlmacen.SelectedValue = 1;
            cboTipoAlmacen.SelectedIndex = 1;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAlmacenes);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                oFrm = new frmAlmacenes();
                oFrm.MdiParent = MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
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
                if (bsAlmacen.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAlmacenes);
                    
                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmAlmacenes(((AlmacenE)bsAlmacen.Current).idEmpresa, ((AlmacenE)bsAlmacen.Current).idAlmacen);
                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                String Descripcion = String.Empty;
                Int32 TipoAlmacen = Variables.Cero;

                if (!String.IsNullOrEmpty(txtDescripcion.Text))
                {
                    Descripcion = txtDescripcion.Text;
                }

                if (Convert.ToInt32(cboTipoAlmacen.SelectedValue) != Variables.Cero)
                {
                    TipoAlmacen = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
                }

                if (chkIndBaja.Checked)
                {
                    ListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Descripcion, TipoAlmacen, true, false);
                }
                else
                {
                    ListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Descripcion, TipoAlmacen, false, false);
                }

                bsAlmacen.DataSource = ListaAlmacen;
                bsAlmacen.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = "Registros " + bsAlmacen.Count.ToString();
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
                if (bsAlmacen.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        Int32 resp = AgenteAlmacen.Proxy.VerificaMovAlmacen(((AlmacenE)bsAlmacen.Current).idEmpresa, ((AlmacenE)bsAlmacen.Current).idAlmacen);

                        if (resp == 0)
                        {
                            AgenteAlmacen.Proxy.AnularAlmacen(((AlmacenE)bsAlmacen.Current).idEmpresa, ((AlmacenE)bsAlmacen.Current).idAlmacen);
                            Buscar();
                            Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                            base.Anular(); 
                        }
                        else
                        {
                            Global.MensajeComunicacion("Este almacén no puede ser anulado porque ya tiene movimientos.");
                        }
                    }
                }
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
                if (ListaAlmacen.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Almacenes", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Almacenes");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 9;

                                #region Titulos Principales

                                // Creando Encabezado;
                                oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 20, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(Color.White);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                                }

                                oHoja.Cells["A2"].Value = " Listado De Almacenes";

                                using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 18, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                                }

                                #endregion

                                #region Cabeceras del Detalle

                                // PRIMERA
                                oHoja.Cells[InicioLinea, 1].Value = " Tipo De Articulo ";
                                oHoja.Cells[InicioLinea, 2].Value = " Cod.Alm. ";
                                oHoja.Cells[InicioLinea, 3].Value = " Descripción ";
                                oHoja.Cells[InicioLinea, 4].Value = " Dirección ";
                                oHoja.Cells[InicioLinea, 5].Value = " Estado ";
                                oHoja.Cells[InicioLinea, 6].Value = " Usuario Reg. ";
                                oHoja.Cells[InicioLinea, 7].Value = " Fecha Reg. ";
                                oHoja.Cells[InicioLinea, 8].Value = " Usuario Mod. ";
                                oHoja.Cells[InicioLinea, 9].Value = " Fecha Mod. ";

                                for (int i = 1; i <= 9; i++)
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

                                foreach (AlmacenE item in ListaAlmacen)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.TipoAlmacen;
                                    oHoja.Cells[InicioLinea, 2].Value = item.idAlmacen;
                                    oHoja.Cells[InicioLinea, 3].Value = item.desAlmacen;
                                    oHoja.Cells[InicioLinea, 4].Value = item.Direccion;
                                    oHoja.Cells[InicioLinea, 5].Value = item.indEstado;
                                    oHoja.Cells[InicioLinea, 6].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 7].Value = item.FechaRegistro.Value.ToString("d");
                                    oHoja.Cells[InicioLinea, 8].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 9].Value = item.FechaModificacion.Value.ToString("d");
                                    oHoja.Cells[InicioLinea, 1, InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    InicioLinea++;
                                }

                                #endregion

                                //Ajustando el ancho de las columnas automaticamente
                                oHoja.Cells.AutoFitColumns();
                                //Pie de Pagina(Derecho) "Número de paginas y el total"
                                oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                                //Pie de Pagina(centro)
                                oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                                //Otras Propiedades
                                //oHoja.Workbook.Properties.Title = TituloGeneral;
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Modulo de Almacén";
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

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmAlmacenes oFrm = sender as frmAlmacenes;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoAlmacenes_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            Buscar();
        }

        private void dgvAlmacen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvAlmacen.Rows[e.RowIndex].Cells["chkIndEstado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado; //Color.FromArgb(255, 150, 150);
                }
            }
        }

        private void dgvAlmacen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion


    }
}
