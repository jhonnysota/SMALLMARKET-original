using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmListadoArticuloServReporte : FrmMantenimientoBase
    {

        public frmListadoArticuloServReporte()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            //FormatoGrid(dgvArticuloServ, false, false, 30, 25);
            FormatoGrid(dgvArticuloServ, false);
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ArticuloServE> oLista = new List<ArticuloServE>();

        #endregion

        #region Procedimientos Usuario

        private void pLlenarTipoArticulo()
        {
            cboTipoArticulo.DataSource = null;
            List<ParTabla> ListaTipoUnidad = AgenteGeneral.Proxy.ListarParTablaPorGrupo(Convert.ToInt32(EnumParTabla.TipoArticulo), string.Empty);
            ListaTipoUnidad.Add(new ParTabla
            {
                IdParTabla = Variables.Cero,
                Nombre = Variables.Seleccione
            });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoUnidad orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        #endregion

        #region Procedimientos Heredados         
        
        public override void Buscar()
        {
            try
            {
                if (!chkIncluir.Checked)
                {
                    bsArticuloServ.DataSource = AgenteMaestros.Proxy.ListarArticuloServReporte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue));
                    bsArticuloServ.ResetBindings(false);
                }
                else
                {
                    bsArticuloServ.DataSource = AgenteMaestros.Proxy.ListarArticuloServReporte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue));
                    bsArticuloServ.ResetBindings(false);
                }

                base.Buscar();
                txtBuscar.Focus();
                lblRegistros.Text = "Articulos [ " + bsArticuloServ.Count.ToString() + " Registros ]";
                //BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
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
                Int32 TipoDeArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);
             
                List<ArticuloServE> ListaExportacion = AgenteMaestros.Proxy.ArticuloReporteExportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,TipoDeArticulo);
                
                if (ListaExportacion.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "ArticuloServ.", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("ArticuloServ.");

                            if (oHoja != null)
                            {
                                Int32 totColumnas = 12;
                                
                                //Creando el encabezado
                                oHoja.Cells["A1"].Value = "ARTICULOS";// +VariablesLocales.PeriodoContable.AnioPeriodo;

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 18, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(142, 169, 219));
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                                    
                                }
                                
                                //SubTitulos...
                                oHoja.Cells["A3"].Value = "Razón Social: " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                                using (ExcelRange Rango = oHoja.Cells["A3:G3"])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                }

                                oHoja.Cells["A4"].Value = "Dirección: " + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

                                using (ExcelRange Rango = oHoja.Cells["A4:G4"])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                }

                                //Detalle...
                                using (ExcelRange Rango = oHoja.Cells["A6:V6"])
                                {
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 9, FontStyle.Bold));
                                }

                                using (ExcelRange Rango = oHoja.Cells[7, 1, ListaExportacion.Count + 10, 22])
                                {
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));
                                }

                                oHoja.Cells["A6"].LoadFromCollection(from x in ListaExportacion
                                                                    select new
                                                                    {
                                                                        CodigoCategoria = x.codCategoria,
                                                                        nombre_Categoria = x.desCategoria,
                                                                        IDArticulo = x.idArticulo,
                                                                        contenido = x.Contenido,
                                                                        capacidad = x.Capacidad,
                                                                        pesounitario = x.PesoUnitario,
                                                                        DesLinea = x.desLinea,
                                                                        x.codArticulo,
                                                                        x.nomArticulo,
                                                                        x.nomArticuloLargo,
                                                                        x.codUniMedAlmacen,
                                                                        NomUMedida = x.nomUMedida
                                                                    
                                                                    }, true, OfficeOpenXml.Table.TableStyles.Medium13);

                                //Mostrar las lineas
                                oHoja.View.ShowGridLines = false;

                                //Ajustando el ancho de las columnas automaticamente
                                oHoja.Cells[oHoja.Dimension.Address].AutoFitColumns();

                                //Insertando Encabezado
                                oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                                //Pie de Pagina(Derecho) "Número de paginas y el total"
                                oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                                //Pie de Pagina(centro)
                                oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                                //Otras Propiedades
                                oHoja.Workbook.Properties.Title = "Listado De Articulos";
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                                oHoja.Workbook.Properties.Comments = "Reporte de Articulos";

                                // Establecer algunos valores de las propiedades extendidas
                                oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                                //Propiedades para imprimir
                                oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                                oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                                Decimal Espacios = 0.5M;
                                oHoja.PrinterSettings.LeftMargin = Espacios;
                                oHoja.PrinterSettings.RightMargin = Espacios;
                                oHoja.PrinterSettings.TopMargin = Espacios;
                                oHoja.PrinterSettings.BottomMargin = Espacios;
                                oHoja.PrinterSettings.ShowGridLines = false;

                                //Guardando el excel
                                oExcel.Save();

                                Global.MensajeComunicacion("Proceso terminado...");
                            }
                        }
                    }
                }
                else
                {
                    Global.MensajeFault("No hay datos para la exportación...");
                }

                //base.Exportar();
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
                oLista = AgenteMaestros.Proxy.ListarArticuloServReporte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue));

                if (bsArticuloServ.Count > 0)
                {
                    CerrarFormulario("frmArticuloImprimir");

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticuloImprimir);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    //oFrm = new frmCronogramaImprimir((tab.TabIndex == 398?oListaDetalle:oLista), (tab.TabIndex == 398?"": "cronograma_mes"));
                    oFrm = new frmArticuloImprimir((oLista), (""));
                    oFrm.MdiParent = this.MdiParent;
                    //oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
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
                if (bsArticuloServ.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoArticuloServReporteDetalle);

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
                    oFrm = new frmListadoArticuloServReporteDetalle(((ArticuloServE)bsArticuloServ.Current).idArticulo)
                    {
                        MdiParent = this.MdiParent
                    };
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmListadoArticuloServ_Load(object sender, EventArgs e)
        {
            Grid = true;
            
            pLlenarTipoArticulo();

            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            Buscar();
        }

        private void dgvArticuloServ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void cboTipoArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

    }
}
