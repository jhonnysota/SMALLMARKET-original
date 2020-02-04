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
using Infraestructura.Recursos;
using Infraestructura.Winform;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoArticuloServ : FrmMantenimientoBase
    {

        public frmListadoArticuloServ()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvArticuloServ, false);
        }

        #region Variables
        
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ArticuloServE> oListaArticulosServ = null;
        ArticuloServE oArt = new ArticuloServE();

        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;
        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;

        #endregion Variables

        #region Procedimientos de Usuario

        private void LlenarTipoArticulo()
        {  
            cboTipoArticulo.DataSource = null;
            List<ParTabla> oListaTipoUnidad = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            oListaTipoUnidad.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in oListaTipoUnidad orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
          
            oListaTipoUnidad = null;
           
           // cboTipoArticulo.SelectedValue = 333001;
            cboTipoArticulo.SelectedIndex = 1;
            
            //List<ArticuloCatE> oListaCategoria = new List<ArticuloCatE>
            //{
            //    new ArticuloCatE() { CodCategoria = Variables.Cero.ToString(), nombre_categoria = Variables.Seleccione }
            //};
            //ComboHelper.RellenarCombos<ArticuloCatE>(cboCategoria, oListaCategoria, "CodCategoria", "nombre_categoria", false);
            //ComboHelper.RellenarCombos<ArticuloCatE>(cboClase, oListaCategoria, "CodCategoria", "nombre_categoria", false);
            //oListaCategoria = null;
            cboTipoArticulo_SelectionChangeCommitted(new object(), new EventArgs());
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (Convert.ToInt32(cboTipoArticulo.SelectedValue) != Variables.Cero)
                {
                    Form oFrm = MdiChildren.FirstOrDefault(x => x is frmArticuloServ);

                    if (oFrm != null)
                    {
                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmArticuloServ(Convert.ToInt32(cboTipoArticulo.SelectedValue))
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show(); 
                }
                else
                {
                    Global.MensajeFault("Debe escoger un Tipo de Articulo.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            Form oFrm = MdiChildren.FirstOrDefault(x => x is frmArticuloServ);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            ArticuloServE EArticuloServ = (ArticuloServE)bsArticuloServ.Current;

            if (EArticuloServ != null)
            {
                EArticuloServ.ListaArticuloCaracteristica = AgenteMaestros.Proxy.ListarArticuloDetalle(EArticuloServ.idArticulo);

                oFrm = new frmArticuloServ(EArticuloServ)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
        }

        public override void Buscar()
        {
            try
            {
                string Categoria = cboClase.SelectedValue.ToString() == "0" ? "%" : cboClase.SelectedValue.ToString();
                bsArticuloServ.DataSource = oListaArticulosServ = AgenteMaestros.Proxy.ListarArticuloServ(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 
                                                                    Convert.ToInt32(cboTipoArticulo.SelectedValue), Categoria, txtArticulo.Text.Trim(), chkIncluir.Checked);
                CheckBoxCab.Checked = false;
                HeaderCheckBoxClick(CheckBoxCab);

                TotalChecks = dgvArticuloServ.RowCount;
                TotalCheckeados = 0;

                dgvArticuloServ.Focus();
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
             
                List<ArticuloServE> ListaExportacion = AgenteMaestros.Proxy.ArticuloReporteExportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipoDeArticulo);
                
                if (ListaExportacion.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Listado de Articulos", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Articulos");

                            if (oHoja != null)
                            {
                                Int32 totColumnas = 14;
                                
                                //Creando el encabezado
                                oHoja.Cells["A1"].Value = "ARTICULOS";// +VariablesLocales.PeriodoContable.AnioPeriodo;

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 20, FontStyle.Bold));
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
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 9, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                }

                                oHoja.Cells["A4"].Value = "Dirección: " + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

                                using (ExcelRange Rango = oHoja.Cells["A4:G4"])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 9, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                }

                                //Detalle...
                                using (ExcelRange Rango = oHoja.Cells["A6:V6"])
                                {
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 9, FontStyle.Bold));
                                }

                                using (ExcelRange Rango = oHoja.Cells[7, 1, ListaExportacion.Count + 10, 22])
                                {
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 8));
                                }

                                oHoja.Cells["A6"].LoadFromCollection(from x in ListaExportacion
                                                                    select new
                                                                    {
                                                                        TipoProducto = x.desTipoArticulo,
                                                                        CodCategoria = x.codCategoria,
                                                                        Categoria = x.desCategoria,
                                                                        Linea = x.desLinea,
                                                                        ID = x.idArticulo,
                                                                        CodArticulo = x.codArticulo,
                                                                        Articulo = x.nomArticulo,
                                                                        Descripcion = x.nomArticuloLargo,
                                                                        x.Contenido,
                                                                        x.Capacidad,
                                                                        x.PesoUnitario,
                                                                        UMedida = x.nomUMedida,
                                                                        UMedEnvase = x.nomUMedidaEnv,
                                                                        UMedPresentacion = x.nomUMedidaPres
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
                                oHoja.Workbook.Properties.Title = "Listado de Articulos";
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Maestros Generales";
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

                                Global.MensajeComunicacion("Termino la Exportación...");
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

        public override void Anular()
        {
            Int32 resp = Variables.Cero;

            try
            {               
                if (bsArticuloServ.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                    {
                        resp = AgenteMaestros.Proxy.EliminarArticuloServ(((ArticuloServE)bsArticuloServ.Current).idEmpresa, ((ArticuloServE)bsArticuloServ.Current).idArticulo);
                        oListaArticulosServ.Remove((ArticuloServE)bsArticuloServ.Current);
                        bsArticuloServ.DataSource = oListaArticulosServ;
                        bsArticuloServ.ResetBindings(false);
                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

            if (resp == Variables.Cero)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                {
                    resp = AgenteMaestros.Proxy.AnularArticuloServ(((ArticuloServE)bsArticuloServ.Current).idEmpresa, ((ArticuloServE)bsArticuloServ.Current).idArticulo);
                    Buscar();
                    Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                }
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos de Usuario

        //Eventos del Formulario
        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmArticuloServ oFrm = sender as frmArticuloServ;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                //Buscar();
            }
        }

        #endregion Eventos de Usuario

        #region Eventos y Procedimientos del CheckBox

        //Eventos para el check del datagridview
        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvArticuloServ.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Escoger"]).Value = HCheckBox.Checked;
            }

            dgvArticuloServ.RefreshEdit();
            TotalCheckeados = HCheckBox.Checked ? TotalChecks : 0;
            indClickCab = false;
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void AñadirCheckBox()
        {
            CheckBoxCab = new CheckBox();
            CheckBoxCab.Size = new Size(15, 15);

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvArticuloServ.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            Rectangle oRectangle = dgvArticuloServ.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - CheckBoxCab.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - CheckBoxCab.Height) / 2 + 1;

            //Cambiar la ubicacion del checkbox para que se quede en la cabecera
            CheckBoxCab.Location = oPoint;
        }

        private void FilaCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modificando el contador de los check
                if ((Boolean)RCheckBox.Value && TotalCheckeados < TotalChecks)
                {
                    TotalCheckeados++;
                }
                else if (TotalCheckeados > 0)
                {
                    TotalCheckeados--;
                }

                //Cambiar estado de la casilla de la cabecera si es que se llenan todas las filas o viceversa.
                if (TotalCheckeados < TotalChecks)
                {
                    CheckBoxCab.Checked = false;
                }
                else if (TotalCheckeados == TotalChecks)
                {
                    CheckBoxCab.Checked = true;
                }
            }
        }

        #endregion

        #region Eventos

        private void frmListadoArticuloServ_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = true;
                LlenarTipoArticulo();
                BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

                AñadirCheckBox();
                CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);

                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                {
                    dgvArticuloServ.Columns[1].Visible = true;
                }

                base.Grabar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvArticuloServ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        
        private void cboTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<ArticuloCatE> oListaCategoria = AgenteMaestros.Proxy.ListarCategoriasPorTipoArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue), 1);
                oListaCategoria.Add(new ArticuloCatE() { CodCategoria = Variables.Cero.ToString(), nombre_categoria = Variables.Seleccione });
                ComboHelper.RellenarCombos<ArticuloCatE>(cboCategoria, (from x in oListaCategoria
                                                                        orderby x.CodCategoria
                                                                        select x).ToList(), "CodCategoria", "nombre_categoria", false);
                
                if (oListaCategoria.Count == 1)
                {
                    cboCategoria.Enabled = false;
                }
                else
                {
                    cboCategoria.Enabled = true;
                }

                cboCategoria_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (oListaArticulosServ.Count > Variables.Cero)
                //{
                //    OtrosFiltro(txtArticulo.Text.Trim(), txtSubCategoria.Text.Trim());
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvArticuloServ_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                String nomColumn = dgvArticuloServ.Columns[e.ColumnIndex].Name;

                if (nomColumn == "FlagAprobacion")
                {
                    if (e.Value != null)
                    {
                        dgvArticuloServ.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                    }
                }

                if ((bool)dgvArticuloServ.Rows[e.RowIndex].Cells["flagActivo"].Value)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<ArticuloCatE> oListaCategoria = AgenteMaestros.Proxy.ListarCategPorTipoArtiCategSup(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue), 2, cboCategoria.SelectedValue.ToString());
                oListaCategoria.Add(new ArticuloCatE() { CodCategoria = Variables.Cero.ToString(), nombre_categoria = Variables.Seleccione });
                ComboHelper.RellenarCombos<ArticuloCatE>(cboClase, (from x in oListaCategoria
                                                                    orderby x.CodCategoria
                                                                    select x).ToList(), "CodCategoria", "nombre_categoria", false);
               
                
                if (oListaCategoria.Count == 1)
                {
                    cboClase.Enabled = false;
                }
                else
                {
                    cboClase.Enabled = true;
                }
               
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvArticuloServ_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvArticuloServ_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArticuloServ.Rows.Count != 0)
            {
                if (!indClickCab)
                {
                    FilaCheckBoxClick((DataGridViewCheckBoxCell)dgvArticuloServ[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvArticuloServ_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvArticuloServ.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvArticuloServ.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
            
        private void bsArticuloServ_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsArticuloServ.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void exportarModelo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 TipoDeArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);
                String Categoria = Convert.ToString(cboCategoria.SelectedValue);

                List<ArticuloServE> ListaExportacionDetalle = AgenteMaestros.Proxy.ListarArticuloServDetalle(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipoDeArticulo, 0, "", false);

                DataTable dtDatos = null;
                dtDatos = new DataTable();
                DataRow dt = null;

                dtDatos.Columns.Add("TipoProducto");
                dtDatos.Columns.Add("CodCategoria");
                dtDatos.Columns.Add("Categoria");
                dtDatos.Columns.Add("Linea");
                dtDatos.Columns.Add("IdArticulo");
                dtDatos.Columns.Add("CodArticulo");
                dtDatos.Columns.Add("Articulo");
                dtDatos.Columns.Add("Descripción");
                dtDatos.Columns.Add("Contenido");
                dtDatos.Columns.Add("Capacidad");
                dtDatos.Columns.Add("PesoUnitario");
                dtDatos.Columns.Add("UMedida");
                dtDatos.Columns.Add("UMedEnvase");
                dtDatos.Columns.Add("UMedPresentacion");

                List<ArticuloServE> ListaConceptos = null;
                ListaConceptos = ListaExportacionDetalle.GroupBy(x => x.DescripcionGeneral).Select(g => g.First()).OrderBy(x => x.DescripcionGeneral).ToList();

                for (int i = 0; i < ListaConceptos.Count; i++)
                {
                    if (ListaConceptos[i].DescripcionGeneral != "")
                    {
                        dtDatos.Columns.Add(ListaConceptos[i].DescripcionGeneral);
                    }
                }

                List<ArticuloServE> listaData = (from x in ListaExportacionDetalle orderby Convert.ToInt32(x.idArticulo) select x).ToList();
                Boolean NuevoLinea = false;

                Int32 idArticulo = 0;
                int contador = 0;
                for (int data = 0; data < listaData.Count; data++)
                {
                    if (data == 0)
                    {
                        dt = dtDatos.NewRow();
                        NuevoLinea = true;
                        idArticulo = listaData[data].idArticulo;

                        dt["TipoProducto"] = listaData[data].desTipoArticulo;
                        dt["CodCategoria"] = listaData[data].codCategoria;
                        dt["Categoria"] = listaData[data].desCategoria;
                        dt["Linea"] = listaData[data].desLinea;
                        dt["IdArticulo"] = listaData[data].idArticulo;
                        dt["CodArticulo"] = listaData[data].codArticulo;
                        dt["Articulo"] = listaData[data].nomArticulo;
                        dt["Descripción"] = listaData[data].Descripcion;
                        dt["Contenido"] = listaData[data].Contenido;
                        dt["Capacidad"] = listaData[data].Capacidad;
                        dt["PesoUnitario"] = listaData[data].PesoUnitario;
                        dt["UMedida"] = listaData[data].nomUMedida;
                        dt["UMedEnvase"] = listaData[data].nomUMedidaEnv;
                        dt["UMedPresentacion"] = listaData[data].nomUMedidaPres;

                        contador++;
                    }

                    if (data > 0)
                    {
                        if (idArticulo != listaData[data].idArticulo)
                        {
                            dt = dtDatos.NewRow();
                            NuevoLinea = true;
                            idArticulo = listaData[data].idArticulo;

                            dt["TipoProducto"] = listaData[data].desTipoArticulo;
                            dt["CodCategoria"] = listaData[data].codCategoria;
                            dt["Categoria"] = listaData[data].desCategoria;
                            dt["Linea"] = listaData[data].desLinea;
                            dt["IdArticulo"] = listaData[data].idArticulo;
                            dt["CodArticulo"] = listaData[data].codArticulo;
                            dt["Articulo"] = listaData[data].nomArticulo;
                            dt["Descripción"] = listaData[data].Descripcion;
                            dt["Contenido"] = listaData[data].Contenido;
                            dt["Capacidad"] = listaData[data].Capacidad;
                            dt["PesoUnitario"] = listaData[data].PesoUnitario;
                            dt["UMedida"] = listaData[data].nomUMedida;
                            dt["UMedEnvase"] = listaData[data].nomUMedidaEnv;
                            dt["UMedPresentacion"] = listaData[data].nomUMedidaPres;

                            contador++;
                        }
                        else
                        {
                            NuevoLinea = false;
                        }
                    }

                    if (NuevoLinea)
                    {
                        for (int i = 0; i < ListaConceptos.Count; i++)
                        {
                            List<ArticuloServE> item;
                            string NombreColumna = "";

                            if (ListaConceptos[i].DescripcionGeneral != "")
                            {
                                NombreColumna = ListaConceptos[i].DescripcionGeneral;
                                item = ListaExportacionDetalle.Where(x => x.DescripcionGeneral == NombreColumna && x.idArticulo == idArticulo).ToList();

                                if (item != null && item.Count > 0)
                                {
                                    if (NombreColumna != "")
                                    {
                                        dt[NombreColumna] = item[0].Descripcion.ToString();
                                    }
                                }
                            }
                        }

                        dtDatos.Rows.Add(dt);
                    }
                }

                dgvPivot.DataSource = dtDatos;

                if (ListaExportacionDetalle.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Listado de Articulos", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Articulos");

                            if (oHoja != null)
                            {
                                Int32 totColumnas = dgvPivot.ColumnCount;

                                //Creando el encabezado
                                oHoja.Cells["A1"].Value = "ARTICULOS";

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 20, FontStyle.Bold));
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
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 9, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                }

                                oHoja.Cells["A4"].Value = "Dirección: " + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

                                using (ExcelRange Rango = oHoja.Cells["A4:G4"])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 9, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                }

                                Int32 InicioLinea = 7;
                                Int32 totColumnas2 = dgvPivot.ColumnCount;
                                Int32 col = 1;

                                for (Int32 i = 0; i < dgvPivot.ColumnCount; i++)
                                {
                                    //Nueva celda
                                    {
                                        String titDetalle = dgvPivot.Columns[i].HeaderText;

                                        oHoja.Cells[InicioLinea, col].Value = titDetalle;
                                        oHoja.Cells[InicioLinea, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(100, 173, 65));
                                        oHoja.Cells[InicioLinea, col].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                        col++;
                                    }
                                }

                                //Autofiltro
                                oHoja.Cells[InicioLinea, 1, InicioLinea, totColumnas2].AutoFilter = true;

                                //Aumentando una fila mas para continuar con el detalle
                                InicioLinea++;
                                col = 1;

                                for (int i = 0; i < dgvPivot.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgvPivot.Columns.Count; j++)
                                    {
                                        if (j == 8 || j == 9 || j == 10)
                                        {
                                            oHoja.Cells[InicioLinea, col].Value = Convert.ToDecimal(dgvPivot[j, i].Value);
                                            oHoja.Cells[InicioLinea, col].Style.Numberformat.Format = "###,###,##0.00";
                                            oHoja.Cells[InicioLinea, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                        }
                                        else
                                        {
                                            oHoja.Cells[InicioLinea, col].Value = dgvPivot[j, i].Value.ToString();
                                            oHoja.Cells[InicioLinea, col].Style.Numberformat.Format = "@"; //Formato de texto 
                                        }

                                        col++;
                                    }

                                    col = 1;
                                    InicioLinea++;
                                }

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
                                oHoja.Workbook.Properties.Title = "Listado de Articulos";
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Maestros Generales";
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

                                Global.MensajeComunicacion("Termino la Exportación...");
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

        private void btExcel_Click(object sender, EventArgs e)
        {
            cmsReporteExcel.Show(btExcel, new Point(0, btExcel.Height));
        }

        private void exportalModelo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 TipoDeArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);
                String Categoria = Convert.ToString(cboCategoria.SelectedValue);
                List<ArticuloServE> ListaExportacionDetalle = AgenteMaestros.Proxy.ListarArticuloServDetalle(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, TipoDeArticulo, 0, "", false);
                DataTable dtDatos = new DataTable();
                DataRow dt = null;

                dtDatos.Columns.Add("TipoProducto");
                dtDatos.Columns.Add("Origen");
                dtDatos.Columns.Add("Categoria");
                dtDatos.Columns.Add("Clase");
                dtDatos.Columns.Add("Marca");
                dtDatos.Columns.Add("IdArticulo");
                dtDatos.Columns.Add("CodArticulo");
                dtDatos.Columns.Add("Articulo");
                dtDatos.Columns.Add("Contenido");
                dtDatos.Columns.Add("Capacidad");
                dtDatos.Columns.Add("PesoUnitario");
                dtDatos.Columns.Add("UMedida");
                dtDatos.Columns.Add("UMedEnvase");
                dtDatos.Columns.Add("UMedPresentacion");

                List<ArticuloServE> ListaConceptos = ListaExportacionDetalle.GroupBy(x => x.DescripcionGeneral).Select(g => g.First()).OrderBy(x => x.DescripcionGeneral).ToList();
                List<ArticuloServE> listaData = (from x in ListaExportacionDetalle orderby Convert.ToInt32(x.idArticulo) select x).ToList();
                Boolean NuevoLinea = false;
                Int32 idArticulo = 0;
                int contador = 0;

                for (int data = 0; data < listaData.Count; data++)
                {
                    if (data == 0)
                    {
                        dt = dtDatos.NewRow();
                        NuevoLinea = true;
                        idArticulo = listaData[data].idArticulo;

                        dt["TipoProducto"] = listaData[data].desTipoArticulo;
                        dt["Origen"] = listaData[data].Descripcion;
                        dt["Categoria"] = listaData[data].Nombre_Categoria_Principal;
                        dt["Clase"] = listaData[data].desCategoria;
                        dt["Marca"] = listaData[data].desMarca;                       
                        dt["IdArticulo"] = listaData[data].idArticulo;
                        dt["CodArticulo"] = listaData[data].codArticulo;
                        dt["Articulo"] = listaData[data].nomArticulo;
                        dt["Contenido"] = listaData[data].Contenido;
                        dt["Capacidad"] = listaData[data].Capacidad;
                        dt["PesoUnitario"] = listaData[data].PesoUnitario;
                        dt["UMedida"] = listaData[data].nomUMedida;
                        dt["UMedEnvase"] = listaData[data].nomUMedidaEnv;
                        dt["UMedPresentacion"] = listaData[data].nomUMedidaPres;

                        contador++;
                    }

                    if (data > 0)
                    {
                        if (idArticulo != listaData[data].idArticulo)
                        {
                            dt = dtDatos.NewRow();
                            NuevoLinea = true;
                            idArticulo = listaData[data].idArticulo;

                            dt["TipoProducto"] = listaData[data].desTipoArticulo;
                            dt["Origen"] = listaData[data].Descripcion;
                            dt["Categoria"] = listaData[data].Nombre_Categoria_Principal;
                            dt["Clase"] = listaData[data].desCategoria;
                            dt["Marca"] = listaData[data].desMarca;
                            dt["IdArticulo"] = listaData[data].idArticulo;
                            dt["CodArticulo"] = listaData[data].codArticulo;
                            dt["Articulo"] = listaData[data].nomArticulo;
                            dt["Contenido"] = listaData[data].Contenido;
                            dt["Capacidad"] = listaData[data].Capacidad;
                            dt["PesoUnitario"] = listaData[data].PesoUnitario;
                            dt["UMedida"] = listaData[data].nomUMedida;
                            dt["UMedEnvase"] = listaData[data].nomUMedidaEnv;
                            dt["UMedPresentacion"] = listaData[data].nomUMedidaPres;

                            contador++;
                        }
                        else
                        {
                            NuevoLinea = false;
                        }
                    }

                    if (NuevoLinea)
                    {
                        dtDatos.Rows.Add(dt);
                    }
                }

                dgvPivot.DataSource = dtDatos;

                if (ListaExportacionDetalle.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Listado de Articulos_2", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Articulos");

                            if (oHoja != null)
                            {
                                Int32 totColumnas = dgvPivot.ColumnCount;

                                //Creando el encabezado
                                oHoja.Cells["A1"].Value = "ARTICULOS";

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, totColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 20, FontStyle.Bold));
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
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 9, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                }

                                oHoja.Cells["A4"].Value = "Dirección: " + VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

                                using (ExcelRange Rango = oHoja.Cells["A4:G4"])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Arial", 9, FontStyle.Bold));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                }

                                Int32 InicioLinea = 7;
                                Int32 totColumnas2 = dgvPivot.ColumnCount;
                                Int32 col = 1;

                                for (Int32 i = 0; i < dgvPivot.ColumnCount; i++)
                                {
                                    //Nueva celda
                                    {
                                        String titDetalle = dgvPivot.Columns[i].HeaderText;

                                        oHoja.Cells[InicioLinea, col].Value = titDetalle;
                                        oHoja.Cells[InicioLinea, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(100, 173, 65));
                                        oHoja.Cells[InicioLinea, col].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                        col++;
                                    }
                                }
                                //Autofiltro
                                oHoja.Cells[InicioLinea, 1, InicioLinea, totColumnas2].AutoFilter = true;

                                //Aumentando una fila mas para continuar con el detalle
                                InicioLinea++;
                                col = 1;

                                for (int i = 0; i < dgvPivot.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgvPivot.Columns.Count; j++)
                                    {
                                        if (j == 8 || j == 9 || j == 10)
                                        {
                                            oHoja.Cells[InicioLinea, col].Value = Convert.ToDecimal(dgvPivot[j, i].Value);
                                            oHoja.Cells[InicioLinea, col].Style.Numberformat.Format = "###,###,##0.00";
                                            oHoja.Cells[InicioLinea, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                        }
                                        else
                                        {
                                            oHoja.Cells[InicioLinea, col].Value = dgvPivot[j, i].Value.ToString();
                                            oHoja.Cells[InicioLinea, col].Style.Numberformat.Format = "@"; //Formato de texto 
                                        }

                                        col++;
                                    }

                                    col = 1;
                                    InicioLinea++;
                                }

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
                                oHoja.Workbook.Properties.Title = "Listado de Articulos";
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Maestros Generales";
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

                                Global.MensajeComunicacion("Termino la Exportación...");
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

        private void TxtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Buscar();
                    dgvArticuloServ.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

        private void TsmiKits_Click(object sender, EventArgs e)
        {
            try
            {
                if ((ArticuloServE)bsArticuloServ.Current != null)
                {
                    FrmArticulosKit oFrm = new FrmArticulosKit((ArticuloServE)bsArticuloServ.Current);

                    if (oFrm.ShowDialog() == DialogResult.Yes)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
    }
}
