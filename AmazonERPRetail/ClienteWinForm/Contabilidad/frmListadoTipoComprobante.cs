using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoTipoComprobante : FrmMantenimientoBase
    {

        public frmListadoTipoComprobante()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvTipoComprobantes, true);
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        ComprobantesE TipoComprobante = null;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        #endregion

        #region Procedimientos de Usuario

        //private void FormatoGrid()
        //{ 
        //    //Inicializar propiedades básicas DataGridView.
        //    dgvTipoComprobantes.BackgroundColor = Color.LightSteelBlue;
        //    dgvTipoComprobantes.BorderStyle = BorderStyle.None;

        //    //Establecer el estilo de las filas y columnas del encabezado
        //    dgvTipoComprobantes.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    dgvTipoComprobantes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    dgvTipoComprobantes.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

        //    //Valores de propiedad, conjunto adecuado para la visualización.
        //    dgvTipoComprobantes.AllowUserToAddRows = false;
        //    dgvTipoComprobantes.AllowUserToDeleteRows = false;
        //    dgvTipoComprobantes.AllowUserToOrderColumns = false;
        //    dgvTipoComprobantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvTipoComprobantes.MultiSelect = false;

        //    dgvTipoComprobantes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    dgvTipoComprobantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

        //    ////Para que la primera columan no aparesca
        //    dgvTipoComprobantes.RowHeadersWidth = 20;

        //    //Estableciendo el el alto de los titulos
        //    dgvTipoComprobantes.ColumnHeadersHeight = 30;

        //    //Formato para las filas
        //    DataGridViewRow lineas = dgvTipoComprobantes.RowTemplate; //Establece la plantilla para todas las filas.
        //    lineas.Height = 25;
        //    lineas.MinimumHeight = 10;
        //    dgvTipoComprobantes.Refresh();

        //    //Estableciendo alineaciones
        //    dgvTipoComprobantes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgvTipoComprobantes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgvTipoComprobantes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgvTipoComprobantes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgvTipoComprobantes.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvTipoComprobantes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    dgvTipoComprobantes.AutoResizeColumns();
        //    // Attach a handler to the CellFormatting event.
        //    //dgvTipoComprobantes.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvTipoComprobantes_CellFormatting);
        //}

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoComprobantes);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmTipoComprobantes();
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoComprobantes);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                TipoComprobante = (ComprobantesE)bsTipoComprobantes.Current;

                oFrm = new frmTipoComprobantes(TipoComprobante.idEmpresa, TipoComprobante.idComprobante);
                oFrm.MdiParent = this.MdiParent;
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
                bsTipoComprobantes.DataSource = AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                lblRegistros.Text = "Tipos de Comprobantes [" + bsTipoComprobantes.Count.ToString() + " Registros ]";
                dgvTipoComprobantes.AutoResizeColumns();
                BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                
                dgvTipoComprobantes.AutoResizeColumns();
                base.Buscar();
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
                TipoComprobante = (ComprobantesE)bsTipoComprobantes.Current;
                TipoComprobante.ListaComprobantesFiles = AgenteContabilidad.Proxy.ListarComprobantesFile(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (TipoComprobante.ListaComprobantesFiles == null)
                {
                    Global.MensajeFault("No hay Registros para exportar a Excel.");
                    return;
                }
                if (TipoComprobante.ListaComprobantesFiles.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                string mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                string anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Tipo De Comprobantes", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Marque = "Importando los Registro de Compras a Excel...";
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

        public override void Anular()
        {
            try
            {
                if (bsTipoComprobantes.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.EliminarComprobantes(((ComprobantesE)bsTipoComprobantes.Current).idEmpresa, (((ComprobantesE)bsTipoComprobantes.Current).idComprobante));
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

        #region EXCEL

        void ExportarExcel(String Ruta)
        {

            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;



            TituloGeneral = " Tipo Comprobantes File";
            NombrePestaña = " Tipo Comprobantes File DET.";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 13;

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
                    oHoja.Cells[InicioLinea, 1].Value = "COMPROBANTE";
                    oHoja.Cells[InicioLinea, 2].Value = "DESCRIPCION FILE ";
                    oHoja.Column(2).Width = 35;
                    oHoja.Cells[InicioLinea, 3].Value = "NUM.FILE";
                    oHoja.Column(3).Width = 55;
                    oHoja.Cells[InicioLinea, 4].Value = " DESCRIPCION ";
                    oHoja.Cells[InicioLinea, 5].Value = " DES. LARGA ";
                    oHoja.Column(5).Width = 12;
                    oHoja.Cells[InicioLinea, 6].Value = " IND FORMA ";
                    oHoja.Column(6).Width = 12;
                    oHoja.Cells[InicioLinea, 7].Value = " MONEDA ";
                    oHoja.Column(7).Width = 20;

                    oHoja.Cells[InicioLinea, 8].Value = " LLEVA CUENTA ";
                    oHoja.Column(8).Width = 20;
                    oHoja.Cells[InicioLinea, 9].Value = " CODIGO CUENTA ";
                    oHoja.Column(9).Width = 20;
                    oHoja.Cells[InicioLinea, 10].Value = " USUARIO REGISTRO ";
                    oHoja.Column(10).Width = 20;
                    oHoja.Cells[InicioLinea, 11].Value = " FECHA REGISTRO ";
                    oHoja.Column(11).Width = 20;

                    oHoja.Cells[InicioLinea, 12].Value = " USUARIO MODIFICACION ";
                    oHoja.Column(12).Width = 20;
                    oHoja.Cells[InicioLinea, 13].Value = " FECHA MODIFICACION ";
                    oHoja.Column(13).Width = 20;



                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    for (int i = 1; i <= 13; i++)
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

                    foreach (ComprobantesFileE item in TipoComprobante.ListaComprobantesFiles)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.idComprobante;
                        oHoja.Column(1).Width = 5;
                        oHoja.Cells[InicioLinea, 2].Value = item.desFileComp;
                        oHoja.Column(2).Width = 60;
                        oHoja.Cells[InicioLinea, 3].Value = item.numFile;
                        oHoja.Column(3).Width = 5;
                        oHoja.Cells[InicioLinea, 4].Value = item.Descripcion;
                        oHoja.Column(4).Width = 60;
                        oHoja.Cells[InicioLinea, 5].Value = item.DesLarga;
                        oHoja.Column(5).Width = 100;
                        oHoja.Cells[InicioLinea, 6].Value = item.IndForma;
                        oHoja.Cells[InicioLinea, 7].Value = item.idMoneda;
                        oHoja.Cells[InicioLinea, 8].Value = item.LLevaCuenta;
                        oHoja.Cells[InicioLinea, 9].Value = item.codCuenta;
                        oHoja.Cells[InicioLinea, 10].Value = item.UsuarioRegistro;
                        oHoja.Cells[InicioLinea, 11].Value = item.FechaRegistro.Value.ToString("d");
                        oHoja.Cells[InicioLinea, 12].Value = item.UsuarioModificacion;
                        oHoja.Cells[InicioLinea, 13].Value = item.FechaModificacion.Value.ToString("d");

                        InicioLinea++;
                    }

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

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmTipoComprobantes oFrm = sender as frmTipoComprobantes;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoTipoComprobante_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
        }

        private void frmListadoTipoComprobante_Activated(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void dgvTipoComprobantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();    
            }            
        }

        #endregion
    }
}
