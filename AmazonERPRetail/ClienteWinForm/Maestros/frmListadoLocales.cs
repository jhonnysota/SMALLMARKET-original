using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoLocales : FrmMantenimientoBase
    {

        public frmListadoLocales()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvLocales, true);
            AnchoColumnas();

            if (VariablesLocales.SesionUsuario.Empresa != null)
            {
                lblRazon.Text = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                lblCodigo.Text = VariablesLocales.SesionUsuario.Empresa.IdEmpresa.ToString();
                lblRuc.Text = VariablesLocales.SesionUsuario.Empresa.RUC;
            }
            
            
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<LocalE> Locales = new List<LocalE>();

        #endregion

        #region Procedimientos Usuario

        private void AnchoColumnas()
        {
            //Estableciendo el ancho de las columnas
            dgvLocales.Columns[0].Width = 35;
            dgvLocales.Columns[1].Width = 350;
            dgvLocales.Columns[2].Width = 65;
            dgvLocales.Columns[3].Width = 65;
            dgvLocales.Columns[4].Width = 65;
            dgvLocales.Columns[5].Width = 350;
            dgvLocales.Columns[6].Width = 90;
            dgvLocales.Columns[7].Width = 120;
            dgvLocales.Columns[8].Width = 90;
            dgvLocales.Columns[9].Width = 120;

            // Attach a handler to the CellFormatting event.
            dgvLocales.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvLocales_CellFormatting);
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmLocal);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new FrmLocal(Convert.ToInt32(lblCodigo.Text))
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmLocal);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                LocalE Elocal = (LocalE)bsLocal.Current;

                if (Elocal != null)
                {
                    oFrm = new FrmLocal(AgenteMaestro.Proxy.RecuperarLocalPorCodigo(Elocal.IdLocal, Elocal.IdEmpresa), Elocal.Departamento, Elocal.Provincia, Elocal.Distrito)
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
            if (!chkIncluir.Checked)
            {
                Locales = AgenteMaestro.Proxy.ListarLocal(txtBuscar.Text, false, false, Convert.ToInt32(lblCodigo.Text));
                bsLocal.DataSource = Locales;
            }
            else
            {
                Locales = AgenteMaestro.Proxy.ListarLocal(txtBuscar.Text, false, false, Convert.ToInt32(lblCodigo.Text));
                bsLocal.DataSource = Locales;
            }

            base.Buscar();
            txtBuscar.Focus();
        }

        public override void Exportar()
        {
            try
            {
                if (Locales.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Locales", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Locales");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 10;

                                #region Titulos Principales

                                // Creando Encabezado;
                                oHoja.Cells["A1"].Value = lblRazon.Text;

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 20, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(Color.White);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                                }

                                oHoja.Cells["A2"].Value = " Locales ";

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
                                oHoja.Cells[InicioLinea, 1].Value = " Código ";
                                oHoja.Cells[InicioLinea, 2].Value = " Descripción ";
                                oHoja.Cells[InicioLinea, 3].Value = " Principal ";
                                oHoja.Cells[InicioLinea, 4].Value = " Almacen ";
                                oHoja.Cells[InicioLinea, 5].Value = " Tienda ";
                                oHoja.Cells[InicioLinea, 6].Value = " Dirección ";
                                oHoja.Cells[InicioLinea, 7].Value = " Usuario Reg. ";
                                oHoja.Cells[InicioLinea, 8].Value = " Fecha Reg. ";
                                oHoja.Cells[InicioLinea, 9].Value = " Usuario Mod. ";
                                oHoja.Cells[InicioLinea, 10].Value = " Fecha Mod. ";

                                for (int i = 1; i <= 10; i++)
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

                                foreach (LocalE item in Locales)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.IdLocal;
                                    oHoja.Cells[InicioLinea, 2].Value = item.Nombre;
                                    oHoja.Cells[InicioLinea, 3].Value = item.EsPrincipal;
                                    oHoja.Cells[InicioLinea, 4].Value = item.EsAlmacen;
                                    oHoja.Cells[InicioLinea, 5].Value = item.EsTienda;
                                    oHoja.Cells[InicioLinea, 6].Value = item.Direccion;
                                    oHoja.Cells[InicioLinea, 7].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 8].Value = item.FechaRegistro.ToString("d");
                                    oHoja.Cells[InicioLinea, 9].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 10].Value = item.FechaModificacion.ToString("d");
                                    oHoja.Cells[InicioLinea, 1, InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    InicioLinea++;
                                }

                                #endregion

                                //Ajustando el ancho de las columnas automaticamente
                                oHoja.Cells.AutoFitColumns(0);

                                //Insertando Encabezado
                                //oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
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

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmLocal oFrm = sender as FrmLocal;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmListadoLocales_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvLocales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }            
        }

        private void dgvLocales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvLocales.Rows[e.RowIndex].Cells["Estado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 150, 150);
                    /* 255, 102, 102 Rosado Oscuro
                     * 255, 210, 210 rosado
                     * 255,180,80 Naranja
                     * 252,222,150 Naranja Claro
                     * 196,196,225 Lila
                     * 252,242,214 Medio Crema
                     * 191,255,191 Verde Claro
                     * 185,194,73 Verde
                     * 27,193,228 Turqueza
                     * 185,185,255 lila oscuro
                     */
                }
            }
        }

        private void btBuscarEmpresa_Click(object sender, EventArgs e)
        {
            FrmBusquedaEmpresa oFrm = new FrmBusquedaEmpresa();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.empresa != null)
            {
                lblCodigo.Text = oFrm.empresa.IdEmpresa.ToString();
                lblRazon.Text = oFrm.empresa.RazonSocial;
                lblRuc.Text = oFrm.empresa.RUC;

                lblCodigo_TextChanged(new Object(), new EventArgs());
            }
        }

        private void lblCodigo_TextChanged(object sender, EventArgs e)
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

        #endregion
        
    }
}
