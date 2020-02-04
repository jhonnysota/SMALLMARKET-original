using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoArticuloCat : FrmMantenimientoBase
    {

        public frmListadoArticuloCat()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
            
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro {get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ArticuloCatE> ListaArticulo = null;
        List<ParTabla> ListaTipoArticulo = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 70;
            dgvDocumentos.Columns[1].Width = 250;
            dgvDocumentos.Columns[2].Width = 80;
            dgvDocumentos.Columns[3].Width = 70;
            dgvDocumentos.Columns[4].Width = 70;
            dgvDocumentos.Columns[5].Width = 90;
            dgvDocumentos.Columns[6].Width = 120;
            dgvDocumentos.Columns[7].Width = 90;
            dgvDocumentos.Columns[8].Width = 120;
        }

        void LlenarTipoArticulo()
        {
            cboTipoArticulo.DataSource = null;
            ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            ListaTipoArticulo.Add(p);

            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

            cboTipoArticulo.SelectedValue = 1;
            cboTipoArticulo.SelectedIndex = 1;

            Buscar();
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Int32 TipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);

                if (TipoArticulo > Variables.Cero)
                {
                    List<ArticuloEstrucE> oListaEstructura = AgenteMaestro.Proxy.ListarArticuloEstruc(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue));

                    if (oListaEstructura.Count > Variables.Cero)
                    {
                        //se localiza el formulario buscandolo entre los forms abiertos 
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticuloCat);

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

                        TipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);

                        //sino existe la instancia se crea una nueva
                        oFrm = new frmArticuloCat(TipoArticulo, oListaEstructura, ListaTipoArticulo)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show();
                    }
                    else
                    {
                        Global.MensajeComunicacion("No puede crear ninguna categoria hasta que no haya una estructura.");
                    } 
                }
                else
                {
                    Global.MensajeComunicacion("Debe escoger un tipo de articulo.");
                    cboTipoArticulo.Focus();
                    SendKeys.Send("{F4}");
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
                bsArticuloCat.DataSource = ListaArticulo = AgenteMaestro.Proxy.ListarCategoriasPorTipoArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue), 0);
                bsArticuloCat.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = "Registros " + bsArticuloCat.Count.ToString();
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
                if (bsArticuloCat.Count > 0)
                {
                    List<ArticuloEstrucE> oListaEstructura = AgenteMaestro.Proxy.ListarArticuloEstruc(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 
                                                                Convert.ToInt32(cboTipoArticulo.SelectedValue));
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticuloCat);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmArticuloCat((ArticuloCatE)bsArticuloCat.Current, oListaEstructura, ListaTipoArticulo)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
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
                if (bsArticuloCat.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                    {
                        AgenteMaestro.Proxy.EliminarArticuloCat(((ArticuloCatE)bsArticuloCat.Current).idEmpresa, ((ArticuloCatE)bsArticuloCat.Current).idTipoArticulo, ((ArticuloCatE)bsArticuloCat.Current).CodCategoria);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                        base.Anular();
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
                if (ListaArticulo.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Articulos_Categorias", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("ArticulosCategorias");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 10;

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

                                oHoja.Cells["A2"].Value = " Articulo Categoría";

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
                                oHoja.Cells[InicioLinea, 1].Value = " Tipor De Articulo ";
                                oHoja.Cells[InicioLinea, 2].Value = " Código ";
                                oHoja.Cells[InicioLinea, 3].Value = " Nombre ";
                                oHoja.Cells[InicioLinea, 4].Value = " Num.Nivel ";
                                oHoja.Cells[InicioLinea, 5].Value = " Cat.Superior ";
                                oHoja.Cells[InicioLinea, 6].Value = " Ult.Nivel ";
                                oHoja.Cells[InicioLinea, 7].Value = " Usuario Reg. ";
                                oHoja.Cells[InicioLinea, 8].Value = " Fecha Reg. ";
                                oHoja.Cells[InicioLinea, 9].Value = " Usuario Mod. ";
                                oHoja.Cells[InicioLinea, 10].Value = " Fecha Mod. ";

                                for (int i = 1; i <= 10; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                }

                                // Auto Filtro
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                                //Aumentando una Fila mas continuar con el detalle
                                InicioLinea++;

                                foreach (ArticuloCatE item in ListaArticulo)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.TipoAlmacen;
                                    oHoja.Cells[InicioLinea, 2].Value = item.CodCategoria;
                                    oHoja.Cells[InicioLinea, 3].Value = item.nombre_categoria;
                                    oHoja.Cells[InicioLinea, 4].Value = item.numNivel;
                                    oHoja.Cells[InicioLinea, 5].Value = item.CodCategoriaSup;
                                    oHoja.Cells[InicioLinea, 6].Value = item.indUltimoNivel;
                                    oHoja.Cells[InicioLinea, 7].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 8].Value = item.fechaRegistro.ToString("d");
                                    oHoja.Cells[InicioLinea, 9].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 10].Value = item.fechaModificacion.ToString("d");
                                    oHoja.Cells[InicioLinea, 1, InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    InicioLinea++;
                                }

                                #endregion

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

        #region Eventos de usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmArticuloCat oFrm = sender as frmArticuloCat;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion Eventos de usuario

        #region Eventos

        private void frmListadoArticuloCat_Load(object sender, EventArgs e)
        {
            Grid = true;
            LlenarTipoArticulo();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
        }

        private void frmListadoArticuloCat_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void cboTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion Eventos

    }
}
