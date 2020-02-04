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
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Maestros.Reportes;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoClientes : FrmMantenimientoBase
    {

        public frmListadoClientes()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvClientes, true);
            AnchoColumnas();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        List<ClienteE> ListaClientes = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvClientes.Columns[0].Width = 70;
            dgvClientes.Columns[1].Width = 300;
            dgvClientes.Columns[2].Width = 100;
            dgvClientes.Columns[3].Width = 90;
            dgvClientes.Columns[4].Width = 120;
            dgvClientes.Columns[5].Width = 90;
            dgvClientes.Columns[6].Width = 120;
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
                    oFrm.Enumerado = EnumTipoRolPersona.Cliente;
                    oFrm.OpcionVentana = (Int32)EnumTipoRolPersona.Cliente;
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
                if (bsListadoCliente.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmClientes);

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
                    
                    ClienteE cli = AgenteMaestros.Proxy.RecuperarClientePorId(((ClienteE)bsListadoCliente.Current).idPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmClientes(cli, Convert.ToInt32(EnumOpcionGrabar.Actualizar))
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
                String RazonSocial = String.Empty;
                String NroDocumento = String.Empty;

                if (!String.IsNullOrEmpty(txtRazonSocial.Text))
                {
                    RazonSocial = txtRazonSocial.Text;
                }

                if (!String.IsNullOrEmpty(txtNroDocumento.Text))
                {
                    NroDocumento = txtNroDocumento.Text;
                }

                if (chkIndBaja.Checked)
                {
                    ListaClientes = AgenteMaestros.Proxy.ListarClientePorParametro(VariablesLocales.SesionLocal.IdEmpresa, RazonSocial, NroDocumento, true, false);    
                }
                else
                {
                    ListaClientes = AgenteMaestros.Proxy.ListarClientePorParametro(VariablesLocales.SesionLocal.IdEmpresa, RazonSocial, NroDocumento, false, false);
                }
                
                bsListadoCliente.DataSource = ListaClientes;
                bsListadoCliente.ResetBindings(false);
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
                if (bsListadoCliente.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteMaestros.Proxy.EliminarCliente(((ClienteE)bsListadoCliente.Current).idEmpresa, ((ClienteE)bsListadoCliente.Current).idPersona);
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
                if (bsListadoCliente.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteClientes);

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
                    List<ClienteE> ListadClientes = new List<ClienteE>();

                    ListadClientes = ListaClientes;
                    //sino existe la instancia se crea una nueva
                    oFrm = new frmReporteClientes(ListadClientes);
                    oFrm.MdiParent = this.MdiParent;
                    //oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
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
                if (ListaClientes.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Clientes", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Clientes");

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

                                oHoja.Cells["A2"].Value = " Clientes ";

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
                                oHoja.Cells[InicioLinea, 1].Value = " Cód.Cli. ";
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

                                foreach (ClienteE item in ListaClientes)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.idPersona;
                                    oHoja.Cells[InicioLinea, 2].Value = item.RazonSocial;
                                    oHoja.Cells[InicioLinea, 3].Value = item.RUC;
                                    oHoja.Cells[InicioLinea, 4].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 5].Value = item.FechaRegistro.ToString("d");
                                    oHoja.Cells[InicioLinea, 6].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 7].Value = item.FechaModificacion.ToString("d");
                                    oHoja.Cells[InicioLinea, 1,InicioLinea,7].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
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

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmClientes oFrm = sender as frmClientes;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                if (ListaClientes != null && ListaClientes.Count > Variables.Cero)
                {
                    if (oFrm.OpcionGrabar == (Int32)EnumOpcionGrabar.Actualizar)
                    {
                        for (Int32 i = 0; i < ListaClientes.Count - 1; i++)
                        {
                            if (ListaClientes[i].idEmpresa == oFrm.oCliente.idEmpresa && ListaClientes[i].idPersona == oFrm.oCliente.idPersona)
                            {
                                ListaClientes[i] = oFrm.oCliente;
                                i = ListaClientes.Count;
                            }
                        }
                    }
                    else
                    {
                        ListaClientes.Add(oFrm.oCliente);
                        bsListadoCliente.MovePrevious();
                    }

                    bsListadoCliente.DataSource = ListaClientes;
                    bsListadoCliente.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Eventos

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvClientes.Rows[e.RowIndex].Cells["chkindEstado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            if (e.ColumnIndex == Variables.Cero)
            {
                dgvClientes.Columns[0].DefaultCellStyle.Format = "000000";
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void BsListadoCliente_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblTitulo.Text = "Registros " + bsListadoCliente.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
