using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Maestros.Reportes;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoProveedores : FrmMantenimientoBase
    {

        public frmListadoProveedores()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvProveedor, true);
            LlenarCombos();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ProveedorE> ListaProveedores = null;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            List<ParTabla> Lista = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPPER");
            Lista.Add(new ParTabla { IdParTabla = 0, Nombre = "<<ESCOGER TIPO PERSONA>>" });

            ComboHelper.RellenarCombos<ParTabla>(cboTipoPersona, (from x in Lista orderby x.IdParTabla ascending select x).ToList(), "IdParTabla", "Nombre");
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
                    oFrm.Enumerado = EnumTipoRolPersona.Proveedor;
                    oFrm.OpcionVentana = (Int32)EnumTipoRolPersona.Proveedor;
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
                if (bsListadoProveedor.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedores2);

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

                    ProveedorE prov = AgenteMaestros.Proxy.RecuperarProveedorPorID(((ProveedorE)bsListadoProveedor.Current).IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmProveedores2(prov, Convert.ToInt32(EnumOpcionGrabar.Actualizar))
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
                String RazonSocial = txtRazonSocial.Text.Trim();
                String NroDocumento = txtNroDocumento.Text.Trim();
                Int32? TipoPersona = (Convert.ToInt32(cboTipoPersona.SelectedValue) != 0) ? Convert.ToInt32(cboTipoPersona.SelectedValue) : (int?)null;
                String indBaja = chkIndBaja.Checked ? "%" : "N";

                bsListadoProveedor.DataSource = ListaProveedores = AgenteMaestros.Proxy.ListarProveedorPorParametro(VariablesLocales.SesionLocal.IdEmpresa, RazonSocial, NroDocumento, TipoPersona, indBaja);
                bsListadoProveedor.ResetBindings(false);
                
                BloquearOpcion(EnumOpcionMenuBarra.Anular, true);                
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
                if (bsListadoProveedor.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteMaestros.Proxy.EliminarProveedor(((ProveedorE)bsListadoProveedor.Current).IdEmpresa, ((ProveedorE)bsListadoProveedor.Current).IdPersona);
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

        public override void Imprimir()
        {
            try
            {
                if (bsListadoProveedor.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteProveedores);

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
                    List<ProveedorE> ListadoProveeedor = new List<ProveedorE>();

                    ListadoProveeedor = ListaProveedores;
                    //sino existe la instancia se crea una nueva
                    oFrm = new frmReporteProveedores(ListadoProveeedor)
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

        public override void Exportar()
        {
            try
            {
                if (ListaProveedores.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Proveedores.", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Proveedores");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 7;

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

                                oHoja.Cells["A2"].Value = " Proveedores ";

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
                                oHoja.Cells[InicioLinea, 1].Value = " Cód.Prov. ";
                                oHoja.Cells[InicioLinea, 2].Value = " Razon Social ";
                                oHoja.Cells[InicioLinea, 3].Value = " N°Documento ";
                                oHoja.Cells[InicioLinea, 4].Value = " Usuario Reg. ";
                                oHoja.Cells[InicioLinea, 5].Value = " Feca Reg. ";
                                oHoja.Cells[InicioLinea, 6].Value = " Usuario Mod. ";
                                oHoja.Cells[InicioLinea, 7].Value = " Fecha Mod. ";



                                for (int i = 1; i <= 7; i++)
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

                                foreach (ProveedorE item in ListaProveedores)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.IdPersona;
                                    oHoja.Cells[InicioLinea, 2].Value = item.RazonSocial;
                                    oHoja.Cells[InicioLinea, 3].Value = item.RUC;
                                    oHoja.Cells[InicioLinea, 4].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 5].Value = item.FechaRegistro.ToString("d");
                                    oHoja.Cells[InicioLinea, 6].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 7].Value = item.FechaModificacion.ToString("d");
                                    oHoja.Cells[InicioLinea, 1, InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                                    InicioLinea++;
                                }
                              
                          
                                #endregion

                                //Linea
                                Int32 totFilas = InicioLinea;
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                                //Suma
                                InicioLinea++;

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
                                oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
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
            frmProveedores2 oFrm = sender as frmProveedores2;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoProveedores_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            cboTipoPersona.Focus();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
        }

        private void dgvProveedor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((String)dgvProveedor.Rows[e.RowIndex].Cells["indBaja"].Value == "S")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;//Color.FromArgb(255, 150, 150);
                }
            }

            if (e.ColumnIndex == Variables.Cero)
            {
                dgvProveedor.Columns[0].DefaultCellStyle.Format = "000000";
            }
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar(); 
            }
        }

        private void BsListadoProveedor_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblTitulo.Text = "Registros " + bsListadoProveedor.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
