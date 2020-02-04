using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura.Enumerados;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;

#region Para Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmPlanContable : FrmMantenimientoBase
    {

        public frmPlanContable()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCuentas, true);
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<PlanCuentasE> ListaPlanCuentas;
        String Version = String.Empty;
        Int32 NivelGeneral = 0;
        TreeNode nodoItems;
        Int16 cantFilas = 0;

        #endregion

        #region Procedimientos de Usuario

        /* METODO RECURSIVO PARA LLENAR UN TREEVIEW
        private void CrearNodosDelPadre(int indicePadre, TreeNode nodePadre)
        {
            // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
            DataView dataViewHijos = new DataView(oDsArbol.Tables["Table1"]);
            dataViewHijos.RowFilter = oDsArbol.Tables["Table1"].Columns["codCuentaSup"].ColumnName + " = " + indicePadre;

            // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = dataRowCurrent["codCuenta"].ToString().Trim() + " - " + dataRowCurrent["Descripcion"].ToString().Trim();

                // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                // del primer nivel que no dependen de otro nodo.
                if (nodePadre == null)
                {
                    tvCuentas.Nodes.Add(nuevoNodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodePadre.Nodes.Add(nuevoNodo);
                }

                // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
                CrearNodosDelPadre(Int32.Parse(dataRowCurrent["codCuenta"].ToString()), nuevoNodo);
            }
        }

        private void CrearDataSet()
        {
            List<PlanCuentasE> Lista = AgenteContabilidad.Proxy.ObtenerPlanCuentasPadre(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Version);//new DataSet("DataSetArbol");
            oDsArbol = ComboHelper.ConvertirDataSet(Lista);
        }
         */

        void CargarCuentasPadre()
        {
            tvCuentas.BeginUpdate();
            List<PlanCuentasE> Lista = AgenteContabilidad.Proxy.ObtenerPlanCuentasPadre(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Version);

            TreeNode tnBase = new TreeNode("PLAN DE CUENTAS " + DateTime.Now.ToString("yyyy"));
            tnBase.ImageIndex = 0;
            tnBase.Expand();
            tnBase.Tag = 0;            

            foreach (PlanCuentasE item in Lista)
            {
                nodoItems = new TreeNode(item.codCuenta + " - " + item.Descripcion);
                nodoItems.ImageIndex = 1;
                nodoItems.SelectedImageIndex = 2;
                nodoItems.Tag = item.numNivel;
                tnBase.Nodes.Add(nodoItems);
            }
            
            tvCuentas.Nodes.Add(tnBase);
            tvCuentas.AfterSelect += new TreeViewEventHandler(tvCuentas_AfterSelect);
            tvCuentas.EndUpdate();
        }

        void CargarCuentasDetalle(TreeNode NodoSeleccionado)
        {
            List<String> oLista = new List<String>(NodoSeleccionado.Text.Split('-'));
            Int32 Nivel = Convert.ToInt32(NodoSeleccionado.Tag);
            String CuentaSuperior = oLista[0].Trim();
            tvCuentas.BeginUpdate();

            if (Nivel > 0)
            {
                ListaPlanCuentas = AgenteContabilidad.Proxy.ObtenerPlanCuentasPorCtaSuperior(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Version, CuentaSuperior);
            }
            else
            {
                ListaPlanCuentas = AgenteContabilidad.Proxy.ObtenerPlanCuentasPorCtaSuperior(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Version, "0");
            }

            if (ListaPlanCuentas != null)
            {
                bsPlanCuentas.DataSource = ListaPlanCuentas;
                bsPlanCuentas.ResetBindings(false);
            }

            tvCuentas.EndUpdate();
            oLista = null;
        }

        void ActualizarArbol()
        {
            TreeNode NodoSeleccionado = tvCuentas.SelectedNode;
            Int32 Nivel = Convert.ToInt32(NodoSeleccionado.Tag);
            List<String> oLista = new List<String>(NodoSeleccionado.Text.Split('-'));
            String Cuenta = oLista[0].Trim();

            tvCuentas.BeginUpdate();

            if (NodoSeleccionado.Nodes.Count > 0)
            {
                NodoSeleccionado.Nodes.Clear();
            }

            Nivel++;

            TreeNode nodo2 = null;
            List<PlanCuentasE> ListaCuentas = AgenteContabilidad.Proxy.ObtenerPlanCuentasSubCuentas(VariablesLocales.SesionLocal.IdEmpresa, Version, Nivel, Cuenta);

            foreach (PlanCuentasE item in ListaCuentas)
            {
                nodo2 = new TreeNode(item.codCuenta + " - " + item.Descripcion);
                nodo2.ImageIndex = 3;
                nodo2.SelectedImageIndex = 4;
                nodo2.Tag = item.numNivel;
                NodoSeleccionado.Nodes.Add(nodo2);
            }
            NodoSeleccionado.Expand();
            tvCuentas.EndUpdate();
            oLista = null;
        }
    
        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                PlanCuentasE CuentaContable = new PlanCuentasE();
                TreeNode Nodo = tvCuentas.SelectedNode;
                Int32 Nivel = Convert.ToInt32(Nodo.Tag) + 1;
                List<String> oLista = new List<String>(Nodo.Text.Split('-'));
                String CuentaSuperior = String.Empty;// oLista[0].Trim();
                String desCuentaSuperior = String.Empty; //oLista[1].Trim();

                if (Nivel > 1)
                {
                    CuentaSuperior = oLista[0].Trim();
                    desCuentaSuperior = oLista[1].Trim();
                }
                else
                {
                    CuentaSuperior = String.Empty;
                    desCuentaSuperior = String.Empty;
                }

                if (Nivel > NivelGeneral)
                {
                    Global.MensajeComunicacion("La estructura ya no posee más niveles. Tiene que posicionarse en un nivel anterior.");
                    return;
                }

                CuentaContable.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                CuentaContable.numVerPlanCuentas = Version;
                CuentaContable.numNivel = Nivel;
                CuentaContable.codCuentaSup = CuentaSuperior;
                CuentaContable.desCuentaSup = desCuentaSuperior;
                CuentaContable.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCuentaContable);

                if (oFrm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                //sino existe la instancia se crea una nueva
                oFrm = new frmCuentaContable(CuentaContable)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
        
        public override void Editar()
        {
            try
            {
                if (bsPlanCuentas.Count > 0)
                {
                    PlanCuentasE CuentaContable = (PlanCuentasE)bsPlanCuentas.Current;

                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCuentaContable);

                    if (oFrm != null)
                    {
                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    cantFilas = Convert.ToInt16(bsPlanCuentas.Count);
                    //sino existe la instancia se crea una nueva
                    oFrm = new frmCuentaContable(CuentaContable.idEmpresa, CuentaContable.numVerPlanCuentas, CuentaContable.codCuenta)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                int cantRegistros;

                if (bsPlanCuentas.Count == 0)
                {
                    return;
                }

                cantRegistros = AgenteContabilidad.Proxy.VerificaSubCuentas(Convert.ToInt32(((PlanCuentasE)bsPlanCuentas.Current).idEmpresa), ((PlanCuentasE)bsPlanCuentas.Current).numVerPlanCuentas, ((PlanCuentasE)bsPlanCuentas.Current).codCuenta);

                if (cantRegistros > 0)
                {
                    if (Global.MensajeConfirmacion("Esta cuenta posee SubCuentas.\n\r¿ Desea eliminar todo ?") == DialogResult.Yes)
                    {
                        cantRegistros = AgenteContabilidad.Proxy.EliminarSubCuentas(Convert.ToInt32(((PlanCuentasE)bsPlanCuentas.Current).idEmpresa), ((PlanCuentasE)bsPlanCuentas.Current).numVerPlanCuentas, ((PlanCuentasE)bsPlanCuentas.Current).codCuenta);
                        bsPlanCuentas.RemoveCurrent();

                        TreeNode Nodo = tvCuentas.SelectedNode;

                        if (Nodo.Tag.ToString() == Variables.Cero.ToString())
                        {
                            tvCuentas.Nodes.Clear();
                            CargarCuentasPadre();
                        }
                        else
                        {
                            ActualizarArbol();
                        }

                        Global.MensajeComunicacion(cantRegistros.ToString() + " Registros eliminados... !!");
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarCuenta(Convert.ToInt32(((PlanCuentasE)bsPlanCuentas.Current).idEmpresa), ((PlanCuentasE)bsPlanCuentas.Current).numVerPlanCuentas, ((PlanCuentasE)bsPlanCuentas.Current).codCuenta);
                        bsPlanCuentas.RemoveCurrent();
                        TreeNode Nodo = tvCuentas.SelectedNode;

                        if (Nodo.Tag.ToString() == Variables.Cero.ToString())
                        {
                            tvCuentas.Nodes.Clear();
                            CargarCuentasPadre();
                        }
                        else
                        {
                            ActualizarArbol();
                        }

                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
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
                List<PlanCuentasE> ListaExportacion = AgenteContabilidad.Proxy.PlanContableExportacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);

                if (ListaExportacion.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Plan Contable", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Plan Contable");

                            if (oHoja != null)
                            {
                                Int32 totColumnas = 22;
                                
                                //Creando el encabezado
                                oHoja.Cells["A1"].Value = "PLAN GENERAL";// +VariablesLocales.PeriodoContable.AnioPeriodo;

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
                                                                        Cuenta = x.codCuenta,
                                                                        x.Descripcion,
                                                                        Nivel = x.numNivel,
                                                                        Mon = x.idMoneda,
                                                                        DH = x.indNaturalezaCta,
                                                                        AjusCambio = x.indAjuste_X_Cambio,
                                                                        TipoAjus = x.desTipAjuste,
                                                                        CtaGanan = x.codCuentaGanancia,
                                                                        CtaPerd = x.codCuentaPerdida,
                                                                        CambioCom = x.indCambio_X_Compra,
                                                                        IndGasto = x.indCuentaGastos,
                                                                        CtaDest = x.codCuentaDestino,
                                                                        CtaTransf = x.codCuentaTransferencia,
                                                                        IndCierre = x.indCuentaCierre,
                                                                        CtaCierre = x.codCuentaCieDeb,
                                                                        CtaCte = x.indCtaCte,
                                                                        ConAux = x.indSolicitaAnexo,
                                                                        ConDoc = x.indSolicitaDcto,
                                                                        ConCC = x.indSolicitaCentroCosto,
                                                                        Balance = x.desBalance,
                                                                        ColCV = x.desColumnaCoVen,
                                                                        UltNodo = x.indUltNodo
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
                                oHoja.Workbook.Properties.Title = "Plan de Cuentas";
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                                oHoja.Workbook.Properties.Comments = "Reporte de Plan Contable";

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

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCuentaContable oFrm = sender as frmCuentaContable;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                TreeNode Nodo = tvCuentas.SelectedNode;

                if (Nodo.Tag.ToString() == Variables.Cero.ToString())
                {
                    tvCuentas.Nodes.Clear();
                    CargarCuentasPadre();
                }
                else
                {
                    tvCuentas_AfterSelect(new Object(), new TreeViewEventArgs(Nodo));
                    //ActualizarArbol();
                }
            }
        }

        #endregion

        #region Eventos

        private void frmPlanContable_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            if (VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas != null)
            {
                Version = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                NivelGeneral = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
            }
            else
            {
                Global.MensajeFault("La versión del plan de cuentas no esta definida...");
            }

            tvCuentas.ImageList = imageList1;
            CargarCuentasPadre();
        }

        private void tvCuentas_MouseUp(object sender, MouseEventArgs e)
        {
            //tvCuentas.BeginUpdate();
            //TreeNode NodoSeleccionado = tvCuentas.GetNodeAt(e.X, e.Y);

            //if (NodoSeleccionado != null)
            //{
            //    if (NodoSeleccionado.Level == 0)
            //    {
            //        //Borra todos los nodos mayores de nivel 1
            //        foreach (TreeNode item in tvCuentas.Nodes)
            //        {
            //            if (item.Level > 1)
            //            {
            //                item.Nodes.Clear();
            //            }
            //        }
            //        return;
            //    }

            //    if (NodoSeleccionado.Nodes.Count > 0)
            //    {
            //        NodoSeleccionado.Nodes.Clear();
            //    }
            //    TreeNode nodo2 = new TreeNode();
            //    List<PlanCuentasE> ListaCuentas = AgenteContabilidad.Proxy.ObtenerPlanCuentasSubCuentas(VariablesLocales.SesionLocal.IdEmpresa, Version, NodoSeleccionado.Level, NodoSeleccionado.Tag.ToString());

            //    foreach (PlanCuentasE item in ListaCuentas)
            //    {
            //        nodo2 = new TreeNode(item.codCuenta + "-" + item.Descripcion);
            //        nodo2.Tag = item.codCuenta;
            //        NodoSeleccionado.Nodes.Add(nodo2);
            //    }
            //    //if (NodoSeleccionado.Level != 0)
            //    //{
            //    //    cargarDetalleNodo(NodoSeleccionado);
            //    //}
            //}
            //tvCuentas.EndUpdate();
            ////tvCuentas.ExpandAll();
            ////tvCuentas.
        }

        private void tvCuentas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode NodoSeleccionado = tvCuentas.SelectedNode;          

            if (NodoSeleccionado != null)
            {
                if (NodoSeleccionado.Level == 0)
                {
                    //Borra todos los nodos mayores de nivel 1
                    foreach (TreeNode item in tvCuentas.Nodes)
                    {
                        if (item.Level > 1)
                        {
                            item.Nodes.Clear();
                        }
                    }

                    CargarCuentasDetalle(NodoSeleccionado);//, NodoSeleccionado.Level);
                    return;
                }

                ActualizarArbol();

                if (NodoSeleccionado.Level != 0)
                {
                    CargarCuentasDetalle(NodoSeleccionado);//, NodoSeleccionado.Level);
                }
            }
        }

        private void tsbExpandir_Click(object sender, EventArgs e)
        {
            tvCuentas.ExpandAll();
        }

        private void tsbContraer_Click(object sender, EventArgs e)
        {
            tvCuentas.CollapseAll();
            //CrearDataSet();
            //CrearNodosDelPadre(0, null);
        }        

        private void dgvCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != - 1)
            {
                Editar();
            }
        }

        private void frmPlanContable_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.F2: //Agregar un registro
            //        Nuevo();
            //        break;
            //    case Keys.F3: //Editar un registro
            //        Editar();
            //        break;
            //    case Keys.Delete: //Elimninar Registro
            //        Anular();
            //        break;
            //    case Keys.Escape: //Salir del formulario
            //        Cerrar();
            //        break;
            //    case Keys.F8: // Imprimir...
            //        break;
            //    default:
            //        break;
            //}
        }

        private void bsPlanCuentas_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsPlanCuentas.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion 

    }
}
