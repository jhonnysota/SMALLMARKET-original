using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoCostosClasificacion : FrmMantenimientoBase
    {

        public frmListadoCostosClasificacion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCostosClasificacion, false);
            
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<CostosClasificacionE> oListaCostosClasificacion = null;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                    Form oFrm = this.MdiChildren.FirstOrDefault(x => x is frmCostosClasificacion);

                    if (oFrm != null)
                    {
                        oFrm.BringToFront();
                        return;
                    }

                    List<CostosEstrucE> oListaEstructura = AgenteMaestros.Proxy.ListarEstruc(); 
                    oFrm = new frmCostosClasificacion(oListaEstructura);
                    oFrm.MdiParent = this.MdiParent;
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
                if (bsCostosClasificacion.Count > 0)
                {
                    List<CostosEstrucE> oListaEstructura = AgenteMaestros.Proxy.ListarEstruc();
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCostosClasificacion);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmCostosClasificacion((CostosClasificacionE)bsCostosClasificacion.Current, oListaEstructura);
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

        public override void Buscar()
        {
            try
            {
                oListaCostosClasificacion = AgenteMaestros.Proxy.ListarClasificacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsCostosClasificacion.DataSource = oListaCostosClasificacion;
                lblRegistros.Text = "Registros " + bsCostosClasificacion.Count.ToString();

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        //public override void Exportar()
        //{
        //    try
        //    {
        //        Int32 TipoDeArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);

        //        List<ArticuloServE> ListaExportacion = AgenteMaestros.Proxy.ArticuloReporteExportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipoDeArticulo);

        //        if (ListaExportacion.Count > Variables.Cero)
        //        {
        //            String NombreArchivo = String.Empty;
        //            String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "ArticuloServ.", "Archivos Excel (*.xlsx)|*.xlsx");

        //            if (!String.IsNullOrEmpty(RutaArchivo))
        //            {
        //                if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

        //                FileInfo newFile = new FileInfo(RutaArchivo);

        //                using (ExcelPackage oExcel = new ExcelPackage(newFile))
        //                {
        //                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("ArticuloServ.");

        //                    if (oHoja != null)
        //                    {
        //                        Int32 totColumnas = 14;

        //                        //Creando el encabezado
        //                        oHoja.Cells["A1"].Value = "ARTICULOS";// +VariablesLocales.PeriodoContable.AnioPeriodo;

        //                        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
        //                        {
        //                            Rango.Merge = true;
        //                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 18, FontStyle.Bold));
        //                            Rango.Style.Font.Color.SetColor(Color.Black);
        //                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
        //                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        //                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(142, 169, 219));
        //                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Medium);
        //                        }

        //                        //SubTitulos...
        //                        oHoja.Cells["A3"].Value = "Razón Social: " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;

        //                        using (ExcelRange Rango = oHoja.Cells["A3:G3"])
        //                        {
        //                            Rango.Merge = true;
        //                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
        //                            Rango.Style.Font.Color.SetColor(Color.Black);
        //                        }

        //                        oHoja.Cells["A4"].Value = "Dirección: " + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

        //                        using (ExcelRange Rango = oHoja.Cells["A4:G4"])
        //                        {
        //                            Rango.Merge = true;
        //                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
        //                            Rango.Style.Font.Color.SetColor(Color.Black);
        //                        }

        //                        //Detalle...
        //                        using (ExcelRange Rango = oHoja.Cells["A6:V6"])
        //                        {
        //                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
        //                        }

        //                        using (ExcelRange Rango = oHoja.Cells[7, 1, ListaExportacion.Count + 10, 22])
        //                        {
        //                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
        //                        }

        //                        oHoja.Cells["A6"].LoadFromCollection(from x in ListaExportacion
        //                                                             select new
        //                                                             {
        //                                                                 CodigoCategoria = x.codCategoria,
        //                                                                 nombre_Categoria = x.desCategoria,
        //                                                                 IDArticulo = x.idArticulo,
        //                                                                 contenido = x.Contenido,
        //                                                                 capacidad = x.Capacidad,
        //                                                                 pesounitario = x.PesoUnitario,
        //                                                                 DesLinea = x.desLinea,
        //                                                                 codArticulo = x.codArticulo,
        //                                                                 nomArticulo = x.nomArticulo,
        //                                                                 nomArticuloLargo = x.nomArticuloLargo,
        //                                                                 codTipoMedAlmacen = x.codTipoMedAlmacen,
        //                                                                 codUniMedAlmacen = x.codUniMedAlmacen,
        //                                                                 codTipoUnidadMedPresentacion = x.codTipoMedPresentacion,
        //                                                                 codUniMedPresentacion = x.codUniMedPresentacion,

        //                                                                 NomUMedida = x.nomUMedida

        //                                                             }, true, OfficeOpenXml.Table.TableStyles.Medium13);

        //                        //Mostrar las lineas
        //                        oHoja.View.ShowGridLines = false;

        //                        //Ajustando el ancho de las columnas automaticamente
        //                        oHoja.Cells[oHoja.Dimension.Address].AutoFitColumns();

        //                        //Insertando Encabezado
        //                        oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
        //                        //Pie de Pagina(Derecho) "Número de paginas y el total"
        //                        oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
        //                        //Pie de Pagina(centro)
        //                        oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

        //                        //Otras Propiedades
        //                        oHoja.Workbook.Properties.Title = "Listado De Articulos";
        //                        oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
        //                        oHoja.Workbook.Properties.Subject = "Reportes";
        //                        //oHoja.Workbook.Properties.Keywords = "";
        //                        oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
        //                        oHoja.Workbook.Properties.Comments = "Reporte de Articulos";

        //                        // Establecer algunos valores de las propiedades extendidas
        //                        oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

        //                        //Propiedades para imprimir
        //                        oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
        //                        oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

        //                        Decimal Espacios = 0.5M;
        //                        oHoja.PrinterSettings.LeftMargin = Espacios;
        //                        oHoja.PrinterSettings.RightMargin = Espacios;
        //                        oHoja.PrinterSettings.TopMargin = Espacios;
        //                        oHoja.PrinterSettings.BottomMargin = Espacios;
        //                        oHoja.PrinterSettings.ShowGridLines = false;

        //                        //Guardando el excel
        //                        oExcel.Save();

        //                        Global.MensajeComunicacion("Proceso terminado...");
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Global.MensajeFault("No hay datos para la exportación...");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.MensajeError(ex.Message);
        //    }
        //}

        public override void Anular()
        {
            try
            {
                if (bsCostosClasificacion.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteMaestros.Proxy.EliminarClasificacion(((CostosClasificacionE)bsCostosClasificacion.Current).idEmpresa, ((CostosClasificacionE)bsCostosClasificacion.Current).CodClasificacion);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        base.Anular();
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

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCostosClasificacion oFrm = sender as frmCostosClasificacion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }


        #endregion

        #region Eventos

        private void frmListadoCostosClasificacion_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
        }

        private void dgvCostosClasificacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex != -1)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmListadoCostosClasificacion_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }


        #endregion

    }
}
