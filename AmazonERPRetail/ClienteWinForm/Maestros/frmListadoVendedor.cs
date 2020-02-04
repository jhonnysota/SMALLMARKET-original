using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoVendedor : FrmMantenimientoBase
    {

        public frmListadoVendedor()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvVendedor, true);
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        List<VendedoresE> oListaVendedor = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
 
        #endregion

        #region Procedimientos de Usuario

        void VerClientes()
        {
            try
            {
                if (bsVendedor.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCarteraClientes);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    VendedoresE ven = (VendedoresE)bsVendedor.Current;
                    Persona per = AgenteMaestros.Proxy.RecuperarPersonaPorID(((VendedoresE)bsVendedor.Current).idPersona);
                    ven.ListaVendedoresCartera = AgenteMaestros.Proxy.ListarVendedoresCartera(((VendedoresE)bsVendedor.Current).idEmpresa, ((VendedoresE)bsVendedor.Current).idPersona);

                    oFrm = new frmCarteraClientes(ven, per)
                    {
                        MdiParent = MdiParent
                    };
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
            String Paramsde = txtcodigo.Text;

            if (Paramsde == "")
            {
                Paramsde = "TODOS";
            }

            TituloGeneral = " Vendedores " + Paramsde;
            NombrePestaña = " Vendedores Listado ";

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
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

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
                    oHoja.Cells[InicioLinea, 1].Value = " Persona ";
                    oHoja.Cells[InicioLinea, 2].Value = " Empresa ";
                    oHoja.Cells[InicioLinea, 3].Value = " Num. Vendedor";
                    oHoja.Cells[InicioLinea, 4].Value = " Codigo Vendedor  ";
                    oHoja.Cells[InicioLinea, 5].Value = " Estado  ";
                    oHoja.Cells[InicioLinea, 6].Value = " Fecha Baja ";
                    oHoja.Cells[InicioLinea, 7].Value = " Nombres ";
                    oHoja.Cells[InicioLinea, 8].Value = " Apellido Paterno ";
                    oHoja.Cells[InicioLinea, 9].Value = " Apellido Materno ";
                    oHoja.Cells[InicioLinea, 10].Value = " Numero Documento ";
                    oHoja.Cells[InicioLinea, 11].Value = " Fecha Registro ";
                    oHoja.Cells[InicioLinea, 12].Value = " Usuario Registro ";
                    oHoja.Cells[InicioLinea, 13].Value = " Fecha Modificacion";
                    oHoja.Cells[InicioLinea, 14].Value = " Usuario Modificacion ";

                    for (int i = 1; i <= 14; i++)
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

                    #endregion
                                        
                    #region Formato Excel

                    foreach (VendedoresE item in oListaVendedor)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.idPersona;
                        oHoja.Cells[InicioLinea, 2].Value = item.idEmpresa;
                        oHoja.Cells[InicioLinea, 3].Value = item.idPersona;
                        oHoja.Cells[InicioLinea, 4].Value = item.codVendedor;
                        oHoja.Cells[InicioLinea, 5].Value = item.indEstado;
                        oHoja.Cells[InicioLinea, 6].Value = item.fecBaja;
                        oHoja.Cells[InicioLinea, 7].Value = item.Nombres;
                        oHoja.Cells[InicioLinea, 8].Value = item.ApePaterno;
                        oHoja.Cells[InicioLinea, 9].Value = item.ApeMaterno;
                        oHoja.Cells[InicioLinea, 10].Value = item.NroDocumento;
                        oHoja.Cells[InicioLinea, 11].Value = item.FechaRegistro;
                        oHoja.Cells[InicioLinea, 12].Value = item.UsuarioRegistro;

                        oHoja.Cells[InicioLinea, 13].Value = item.FechaModificacion;
                        oHoja.Cells[InicioLinea, 14].Value = item.UsuarioModificacion;

                        oHoja.Cells[InicioLinea,6].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea,11].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea,13].Style.Numberformat.Format = "dd/MM/yyyy";

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
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

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
                FrmDlgPersona oFrm = new FrmDlgPersona();

                if (oFrm.ValidarIngresoVentana())
                {
                    oFrm.Enumerado = EnumTipoRolPersona.Vendedor;
                    oFrm.OpcionVentana = (Int32)EnumTipoRolPersona.Vendedor;
                    oFrm.MdiParent = MdiParent;
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
                if (bsVendedor.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVendedor);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    VendedoresE ven = (VendedoresE)bsVendedor.Current;
                    Persona per = AgenteMaestros.Proxy.RecuperarPersonaPorID(ven.idPersona);

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmVendedor(ven, per, Convert.ToInt32(EnumOpcionGrabar.Actualizar))
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

        public override void Buscar()
        {
            try
            {
                String parambusqueda = txtcodigo.Text.Trim();

                bsVendedor.DataSource = oListaVendedor = AgenteMaestros.Proxy.ListarVendedores(VariablesLocales.SesionLocal.IdEmpresa, parambusqueda, chkIndBaja.Checked);
                bsVendedor.ResetBindings(false);
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
                if (bsVendedor.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteMaestros.Proxy.EliminarVendedores(((VendedoresE)bsVendedor.Current).idPersona, ((VendedoresE)bsVendedor.Current).idEmpresa);
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
                if (oListaVendedor == null || oListaVendedor.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                String Paramsde = txtcodigo.Text.Trim();

                if (String.IsNullOrWhiteSpace(Paramsde))
                {
                    Paramsde = "TODOS";
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Vendedores Listado según el código " + Paramsde, "Archivos Excel (*.xlsx)|*.xlsx");

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
            String paramBus = Convert.ToString(txtcodigo.Text);
            Boolean baja = Convert.ToBoolean(chkIndBaja.Checked);
            
            oListaVendedor = AgenteMaestros.Proxy.ListarVendedores(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, paramBus, baja);
            ExportarExcel(RutaGeneral);
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bw.CancelAsync();
            _bw.Dispose();
            Global.MensajeFault("Exportación Exitósa.");
        }

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmVendedor oFrm = sender as frmVendedor;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            CheckForIllegalCrossThreadCalls = false;
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void dgvVendedor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvVendedor.Rows[e.RowIndex].Cells["indEstadoDataGridViewCheckBoxColumn"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            if (e.ColumnIndex == Variables.Cero)
            {
                dgvVendedor.Columns[0].DefaultCellStyle.Format = "000000";
            }
        }

        private void dgvVendedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void verCarteraVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerClientes();
        }

        private void bsVendedor_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                LblTitulo.Text = "Registros " + bsVendedor.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
