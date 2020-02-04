using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Generales
{
    public partial class frmListadoUMedida : FrmMantenimientoBase
    {

        public frmListadoUMedida()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
        }

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        List<UMedidaE> ListaUMedida = null;

        #endregion

        #region Procedimientos de Usuario

        private void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 64; //IDMEDIDA
            dgvDocumentos.Columns[1].Width = 200; // NOM. MEDIDA
            dgvDocumentos.Columns[2].Width = 90; // NOM. CORTO
            dgvDocumentos.Columns[3].Width = 90; //USUARIO REG 
            dgvDocumentos.Columns[4].Width = 126; // FECHA REG
            dgvDocumentos.Columns[5].Width = 90; // USUARIO MOD
            dgvDocumentos.Columns[4].Width = 126; //FECHA MOD
        }

        #endregion Procedimientos de Usuario

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmUMedida);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmUMedida()
                {
                    MdiParent = this.MdiParent
                };

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
                ListaUMedida = AgenteGenerales.Proxy.ListarUMedida(string.IsNullOrWhiteSpace(TxtBusqueda.Text) == true ? "%" : TxtBusqueda.Text.Trim());
                bsUnidadMedida.DataSource = ListaUMedida;
                bsUnidadMedida.ResetBindings(false);

                base.Buscar();
                lblRegistros.Text = "Registros " + bsUnidadMedida.Count.ToString();
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
                if (bsUnidadMedida.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmUMedida);

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
                    oFrm = new frmUMedida((UMedidaE)bsUnidadMedida.Current)
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
                if (bsUnidadMedida.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteGenerales.Proxy.EliminarUMedida(((UMedidaE)bsUnidadMedida.Current).idUMedida);
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
                if (ListaUMedida.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Unidades de Medida", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("UnidadDeMedida");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 8;

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

                                oHoja.Cells["A2"].Value = " Unidades De Medida";

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
                                oHoja.Cells[InicioLinea, 1].Value = " Unidad de Medida";
                                oHoja.Cells[InicioLinea, 2].Value = " ID Medida";
                                oHoja.Cells[InicioLinea, 3].Value = " Nombre Medida ";
                                oHoja.Cells[InicioLinea, 4].Value = " Nombre Corto ";
                                oHoja.Cells[InicioLinea, 5].Value = " Usuario Reg. ";
                                oHoja.Cells[InicioLinea, 6].Value = " Fecha Reg. ";
                                oHoja.Cells[InicioLinea, 7].Value = " Usuario Mod. ";
                                oHoja.Cells[InicioLinea, 8].Value = " Fecha Mod. ";

                                for (int i = 1; i <= 8; i++)
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

                                foreach (UMedidaE item in ListaUMedida)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.UnidadMedida;
                                    oHoja.Cells[InicioLinea, 2].Value = item.idUMedida;
                                    oHoja.Cells[InicioLinea, 3].Value = item.NomUMedida;
                                    oHoja.Cells[InicioLinea, 4].Value = item.NomUMedidaCorto;
                                    oHoja.Cells[InicioLinea, 5].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 6].Value = item.FechaRegistro.Value.ToString("d");
                                    oHoja.Cells[InicioLinea, 7].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 8].Value = item.FechaModificacion.Value.ToString("d");
                                    oHoja.Cells[InicioLinea, 1, InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

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

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmUMedida oFrm = sender as frmUMedida;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void frmListadoUMedida_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
        }

        #endregion

    }
}
