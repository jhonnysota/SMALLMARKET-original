using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;
using Infraestructura.Winform;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoCuentasMigracion : FrmMantenimientoBase
    {

        public frmListadoCuentasMigracion()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvListado, true);
            AnchoColumnas();
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<CuentasMigracionE> oListaCuentas = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;

        #endregion Variables

        #region Procedimiento de Usuario

        void AnchoColumnas()
        {
            dgvListado.Columns[0].Width = 35;  //Tipo
            dgvListado.Columns[1].Width = 60;  //Cuenta Destino
            dgvListado.Columns[2].Width = 200; //Descripción Cta. Destino
            dgvListado.Columns[3].Width = 60;  //Cuenta Origen
            dgvListado.Columns[4].Width = 250; //Descripción Cta. Origen
            dgvListado.Columns[5].Width = 40;  //Cuenta Indusoft
            dgvListado.Columns[6].Width = 180; //Descripción Cta. Indusoft
            dgvListado.Columns[7].Width = 60;  //Cuenta Indusoft
            dgvListado.Columns[8].Width = 300; //Descripción Cta. Indusoft
        }

        void ColorVacios()
        {
            foreach (DataGridViewRow Fila in dgvListado.Rows)
            {
                if (String.IsNullOrEmpty(((CuentasMigracionE)Fila.DataBoundItem).codCuenta))
                {
                    Fila.Cells[7].Style.BackColor = Color.PaleGoldenrod;
                    Fila.Cells[8].Style.BackColor = Color.PaleGoldenrod;
                }
            }
        }

        #endregion Procedimiento de Usuario

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                oListaCuentas = AgenteContabilidad.Proxy.ListarCuentasMigracion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsMigracion.DataSource = oListaCuentas;
                bsMigracion.ResetBindings(false);

                lblRegistros.Text = "Registros " + oListaCuentas.Count.ToString();
                ColorVacios();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Nuevo()
        {
            //try
            //{
            //    if (oListaCuentas.Count > Variables.ValorCero)
            //    {
            //        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCuentasMigracion);

            //        if (oFrm != null)
            //        {
            //            if (oFrm.WindowState == FormWindowState.Minimized)
            //            {
            //                oFrm.WindowState = FormWindowState.Normal;
            //            }

            //            oFrm.BringToFront();
            //            return;
            //        }

            //        oFrm = new frmCuentasMigracion();
            //        oFrm.MdiParent = this.MdiParent;
            //        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
            //        oFrm.Show();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeError(ex.Message);
            //}
        }

        public override void Editar()
        {
            try
            {
                frmBuscarCuentasMigraciones oFrm = new frmBuscarCuentasMigraciones((CuentasMigracionE)bsMigracion.Current);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {


            oListaCuentas = AgenteContabilidad.Proxy.ListarCuentasMigracion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ExportarExcel(RutaGeneral);
        }

        #endregion Procedimientos Heredados

        #region FormatoExcel

        public override void Exportar()
        {
            try
            {
                if (oListaCuentas == null || oListaCuentas.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", " Cuentas-Migracion ", "Archivos Excel (*.xlsx)|*.xlsx");

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

        void ExportarExcel(String Ruta)
        {

            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;


            TituloGeneral = "Cuentas De Migración";
            NombrePestaña = " CDM";

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

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
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(102, 201, 3));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(102, 201, 3));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " Tipo ";

                    oHoja.Cells[InicioLinea, 2].Value = " Cuenta Destino ";

                    oHoja.Cells[InicioLinea, 3].Value = " Nombre Destino";

                    oHoja.Cells[InicioLinea, 4].Value = " Cuenta Origen ";

                    oHoja.Cells[InicioLinea, 5].Value = " Nombre Origen  ";

                    oHoja.Cells[InicioLinea, 6].Value = " Centro de Costos ";

                    oHoja.Cells[InicioLinea, 7].Value = " Descripcion Centro de Costos ";

                    oHoja.Cells[InicioLinea, 8].Value = " Cuenta Indusoft ";

                    oHoja.Cells[InicioLinea, 9].Value = " Nombre Cuentas Indusoft ";


                    for (int i = 1; i <= 9; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(4, 200, 93));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Formato Excel


                    foreach (CuentasMigracionE item in oListaCuentas)
                    {

                        oHoja.Cells[InicioLinea, 1].Value = item.tipo;
                        oHoja.Cells[InicioLinea, 2].Value = item.cuentadestino;
                        oHoja.Cells[InicioLinea, 3].Value = item.nombredestino;
                        oHoja.Cells[InicioLinea, 4].Value = item.cuentaorigen;
                        oHoja.Cells[InicioLinea, 5].Value = item.nombreorigen;
                        oHoja.Cells[InicioLinea, 6].Value = item.ccosto;
                        oHoja.Cells[InicioLinea, 7].Value = item.nombreccosto;
                        oHoja.Cells[InicioLinea, 8].Value = item.codCuenta;
                        oHoja.Cells[InicioLinea, 9].Value = item.desCuenta;


                        InicioLinea++;
                    }
                    //FIN SUMATORIA //


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

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCuentasMigracion oFrm = sender as frmCuentasMigracion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos
        
        private void frmListadoCuentasMigracion_Load(object sender, EventArgs e)
        {
            Grid = true;
            //BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        #endregion Eventos

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
