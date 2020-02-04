using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen
{
    public partial class frmListadoConceptos : FrmMantenimientoBase
    {

        public frmListadoConceptos()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvConceptos, true);
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        String RutaGeneral = String.Empty;
        List<ConceptosVariosE> oListaConceptos = null;
        List<ParTabla> oTipoConceptos = null;
        Int32 Sistema = 0;
        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            oTipoConceptos = (from x in AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPCON") select x).ToList();
            //if (idSistemaForm == 5) //VariablesLocales.oSistema.idSistema == 5)//Compras
            //{
            //    oTipoConceptos = (from x in AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPCON") where x.NemoTecnico != "TCVAR" select x).ToList();
            //}
            //else //Tesoreria
            //{
            //    oTipoConceptos = (from x in AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPCON") where x.NemoTecnico == "TCVAR" select x).ToList();
            //    cboTipo.Enabled = false;
            //}

            ComboHelper.LlenarCombos<ParTabla>(cboTipo, oTipoConceptos);
        }

        void BuscarFiltro()
        {
            bsConceptos.DataSource = (from x in oListaConceptos
                                       where x.Descripcion.ToUpper().Contains(txtDesConcepto.Text.ToUpper())
                                       select x).ToList();
        }

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Listado De Conceptos";
            NombrePestaña = " CONCEPTOS LISTADO";

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
                        Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(105, 171, 169));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(64, 166, 212));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " Código";
                    oHoja.Cells[InicioLinea, 2].Value = " Descripción";
                    oHoja.Cells[InicioLinea, 3].Value = " Cod. Cuenta Adm.";
                    oHoja.Cells[InicioLinea, 4].Value = " Descripcion Cuenta Adm.";
                    oHoja.Cells[InicioLinea, 5].Value = " Cod. Cuenta Ven. ";
                    oHoja.Cells[InicioLinea, 6].Value = " Descripcion Cuenta Ven. ";
                    oHoja.Cells[InicioLinea, 7].Value = " Cod. Cuenta Pro.  ";
                    oHoja.Cells[InicioLinea, 8].Value = " Descripcion Cuenta Pro.  ";
                    oHoja.Cells[InicioLinea, 9].Value = " Cod. Cuenta Fin ";
                    oHoja.Cells[InicioLinea, 10].Value = " Descripcion Cuenta Fin ";
                    oHoja.Cells[InicioLinea, 11].Value = " Usuario Registo ";
                    oHoja.Cells[InicioLinea, 12].Value = " Fecha Registro ";
                    oHoja.Cells[InicioLinea, 13].Value = " Usuario Modificación";
                    oHoja.Cells[InicioLinea, 14].Value = " Fecha Modificación";

                    for (int i = 1; i <= 14; i++)
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

                    #endregion

                    #region Formato Excel

                    foreach (ConceptosVariosE item in oListaConceptos)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.codConcepto;
                        oHoja.Cells[InicioLinea, 2].Value = item.Descripcion;
                        oHoja.Cells[InicioLinea, 3].Value = item.codCuentaAdm;
                        oHoja.Cells[InicioLinea, 4].Value = item.desCuentaAdm;
                        oHoja.Cells[InicioLinea, 5].Value = item.codCuentaVen;
                        oHoja.Cells[InicioLinea, 6].Value = item.desCuentaVen;
                        oHoja.Cells[InicioLinea, 7].Value = item.codCuentaPro;
                        oHoja.Cells[InicioLinea, 8].Value = item.desCuentaPro;
                        oHoja.Cells[InicioLinea, 9].Value = item.codCuentaFin;
                        oHoja.Cells[InicioLinea, 10].Value = item.desCuentaFin;
                        oHoja.Cells[InicioLinea, 11].Value = item.UsuarioRegistro;
                        oHoja.Cells[InicioLinea, 12].Value = item.FechaRegistro;
                        oHoja.Cells[InicioLinea, 13].Value = item.UsuarioModificacion;
                        oHoja.Cells[InicioLinea, 14].Value = item.FechaModificacion;

                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "dd/MM/yyyy";

                        InicioLinea++;
                    }

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

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
                    Global.MensajeComunicacion("Exportacion Guardada");

                    #endregion

                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmConceptosVarios);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }
                Int32 tipo = Convert.ToInt32(cboTipo.SelectedValue);

                oFrm = new frmConceptosVarios(oTipoConceptos, tipo, Sistema)
                {
                    MdiParent = MdiParent
                };
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmConceptosVarios);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmConceptosVarios((ConceptosVariosE)bsConceptos.Current, oTipoConceptos);
                oFrm.MdiParent = MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
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
                bsConceptos.DataSource = oListaConceptos = AgenteAlmacen.Proxy.ListarConceptosVarios(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                        Convert.ToInt32(cboTipo.SelectedValue));//, idSistemaForm); //VariablesLocales.oSistema.idSistema);

                if (!String.IsNullOrEmpty(txtDesConcepto.Text))
                {
                    BuscarFiltro();
                }

                btCopiar.Enabled = (oListaConceptos.Count == 0);
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
                if (bsConceptos.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteAlmacen.Proxy.EliminarConceptosVarios(((ConceptosVariosE)bsConceptos.Current).idConcepto);
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

        public override void Exportar()
        {
            try
            {
                if (oListaConceptos == null || oListaConceptos.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", " Conceptos ", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Cursor = Cursors.WaitCursor;

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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            ExportarExcel(RutaGeneral);
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Arrow;
            _bw.CancelAsync();
            _bw.Dispose();

            Global.MensajeComunicacion("Conceptos Exportado...");
        }

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmConceptosVarios oFrm = sender as frmConceptosVarios;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoConceptos_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvConceptos.Columns[0].Visible = true;
            }

            if (idSistemaForm == 5) //VariablesLocales.oSistema.idSistema == 5)//Compras
            {
                Text = "Listado de Conceptos Varios - Compras";
            }
            else if (idSistemaForm == 6)//Tesoreria
            {
                Text = "Listado de Conceptos Varios - Tesoreria";
            }
            else //Cobranzas
            {
                Text = "Listado de Conceptos Varios - Cobranzas";
            }

            LlenarCombo();
            Sistema = idSistemaForm;
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void dgvConceptos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && oListaConceptos != null && oListaConceptos.Count > 0)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void bsConceptos_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsConceptos.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesConcepto_TextChanged(object sender, EventArgs e)
        {
            if (oListaConceptos != null && oListaConceptos.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                List<ConceptosVariosE> oListaEmpresas = AgenteAlmacen.Proxy.ListarEmpresaConceptosVarios(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oListaEmpresas.Count > 0)
                {
                    frmBuscarEmpresas oFrm = new frmBuscarEmpresas(oListaEmpresas);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oEmpresaConceptoVarios != null)
                    {
                        Int32 resp = AgenteAlmacen.Proxy.CopiarConceptosVarios(oFrm.oEmpresaConceptoVarios.idEmpresa, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion(String.Format("Se ingresaron los Tipos de Cobranza de {0}", oFrm.oEmpresaConceptoVarios.NombreEmpresa));
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("No existen datos en otras empresas.");
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
