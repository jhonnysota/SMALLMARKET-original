using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen
{
    public partial class FrmListadoOperacion : FrmMantenimientoBase
    {

        public FrmListadoOperacion()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvOperacion, true);
            LlenarCombos();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<OperacionE> ListaOperacion = null;
        string sParametro = string.Empty;

        #endregion

        #region Procedimiento Usuario

        void LlenarCombos()
        {
            cboTipoAlmacen.DataSource = null;
            List<ParTabla> ListaOperacion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos };
            ListaOperacion.Add(p);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaOperacion orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

            List<ParTabla> ListarTipoMovimiento = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPMOVALM");
            ListarTipoMovimiento.Add(p);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoMovimiento, (from x in ListarTipoMovimiento
                                                                     where (x.NemoTecnico == "ING") ||
                                                                           (x.NemoTecnico == "EGR")
                                                                           || (x.IdParTabla == 0)
                                                                     orderby x.IdParTabla
                                                                     select x).ToList(), "IdParTabla", "Nombre", false);
        }

        void BuscarFiltro()
        {
            bsOperacion.DataSource = (from x in ListaOperacion
                                      where x.desOperacion.ToUpper().Contains(txtBuscar.Text.ToUpper())
                                      select x).ToList();

            lblRegistros.Text = "Registros " + bsOperacion.Count.ToString();
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOperacion);

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
                oFrm = new frmOperacion
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
                bsOperacion.DataSource = ListaOperacion = AgenteAlmacen.Proxy.ListarOperacionPorTipoArticulo(Convert.ToInt32(cboTipoAlmacen.SelectedValue), VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoMovimiento.SelectedValue));

                txtBuscar.Focus();
                lblRegistros.Text = "Registros " + bsOperacion.Count.ToString();

                if (!String.IsNullOrEmpty(txtBuscar.Text.Trim()))
                {
                    BuscarFiltro();
                }

                base.Buscar();
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
                if (bsOperacion.Count > 0)
                {
                    OperacionE current = (OperacionE)bsOperacion.Current;

                    if (current != null)
                    {
                        //se localiza el formulario buscandolo entre los forms abiertos 
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOperacion);

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
                        oFrm = new frmOperacion(current.idEmpresa, current.idOperacion)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show(); 
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
                if (bsOperacion.Count > Variables.Cero)
                {
                    OperacionE current = (OperacionE)bsOperacion.Current;

                    if (current != null)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                        {
                            AgenteAlmacen.Proxy.EliminarOperacion(current.idEmpresa, current.idOperacion, current.tipAlmacen, current.tipMovimiento);
                            Buscar();
                            Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                        } 
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
                if (ListaOperacion.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Listado_De_Operaciones", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Operaciones");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 20;

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

                                oHoja.Cells["A2"].Value = " Listado De Operaciones";

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
                                oHoja.Cells[InicioLinea, 1].Value = " Tipo De Art. ";
                                oHoja.Cells[InicioLinea, 2].Value = " Tipo Mov. ";
                                oHoja.Cells[InicioLinea, 3].Value = " Descripción ";
                                oHoja.Cells[InicioLinea, 4].Value = " Detalle ";
                                oHoja.Cells[InicioLinea, 5].Value = " Orden ";
                                oHoja.Cells[InicioLinea, 6].Value = " Ind.Val. ";
                                oHoja.Cells[InicioLinea, 7].Value = " Ind.Ajus. ";
                                oHoja.Cells[InicioLinea, 8].Value = " Autom.";
                                oHoja.Cells[InicioLinea, 9].Value = " Ind.Trans. ";
                                oHoja.Cells[InicioLinea, 10].Value = " Ind.O.T. ";
                                oHoja.Cells[InicioLinea, 11].Value = " Ind.Con. ";
                                oHoja.Cells[InicioLinea, 12].Value = " Ind.Doc.Auto. ";
                                oHoja.Cells[InicioLinea, 13].Value = " Ind.Prov.";
                                oHoja.Cells[InicioLinea, 14].Value = " Ind.Cli. ";
                                oHoja.Cells[InicioLinea, 15].Value = " Ind.O.C. ";
                                oHoja.Cells[InicioLinea, 16].Value = " Ind.Dev. ";
                                oHoja.Cells[InicioLinea, 17].Value = " Usuario Reg. ";
                                oHoja.Cells[InicioLinea, 18].Value = " Fecha Reg. ";
                                oHoja.Cells[InicioLinea, 19].Value = " Usuario Mod. ";
                                oHoja.Cells[InicioLinea, 20].Value = " Fecha Mod. ";



                                for (int i = 1; i <= 20; i++)
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

                                foreach (OperacionE item in ListaOperacion)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.TipoAlmacen;
                                    oHoja.Cells[InicioLinea, 2].Value = item.desMovimiento;
                                    oHoja.Cells[InicioLinea, 3].Value = item.desOperacion;
                                    oHoja.Cells[InicioLinea, 4].Value = item.desDetalle;
                                    oHoja.Cells[InicioLinea, 5].Value = item.orden;
                                    oHoja.Cells[InicioLinea, 6].Value = item.indValorizar;
                                    oHoja.Column(6).Width = 13;
                                    oHoja.Cells[InicioLinea, 7].Value = item.indServicio;
                                    oHoja.Column(7).Width = 13;
                                    oHoja.Cells[InicioLinea, 8].Value = item.automatico;
                                    oHoja.Column(8).Width = 13;
                                    oHoja.Cells[InicioLinea, 9].Value = item.indTransferencia;
                                    oHoja.Column(9).Width = 13;
                                    oHoja.Cells[InicioLinea, 10].Value = item.indOrdentrabajo;
                                    oHoja.Column(10).Width = 13;
                                    oHoja.Cells[InicioLinea, 11].Value = item.indConsumo;
                                    oHoja.Column(11).Width = 13;
                                    oHoja.Cells[InicioLinea, 12].Value = item.indDocumentoAutomatico;
                                    oHoja.Column(12).Width = 13;
                                    oHoja.Cells[InicioLinea, 13].Value = item.indProveedor;
                                    oHoja.Column(13).Width = 13;
                                    oHoja.Cells[InicioLinea, 14].Value = item.indCliente;
                                    oHoja.Column(14).Width = 13;
                                    oHoja.Cells[InicioLinea, 15].Value = item.indOrdenCompra;
                                    oHoja.Column(15).Width = 13;
                                    oHoja.Cells[InicioLinea, 16].Value = item.indDevolucion;
                                    oHoja.Column(16).Width = 13;
                                    oHoja.Cells[InicioLinea, 17].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 18].Value = item.FechaRegistro.Value.ToString("d");
                                    oHoja.Cells[InicioLinea, 19].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 20].Value = item.FechaModificacion.Value.ToString("d");
                                    oHoja.Cells[InicioLinea, 1, InicioLinea,20].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
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

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmOperacion oFrm = sender as frmOperacion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void dgvOperacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmListadoOperacion_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            LlenarCombos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (ListaOperacion != null && ListaOperacion.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        }

        private void cboTipoMovimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsOperacion.Count == 0)
                {
                    List<OperacionE> oListaEmpresas = AgenteAlmacen.Proxy.ListarEmpresaOperacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoAlmacen.SelectedValue));

                    if (oListaEmpresas.Count > 0)
                    {
                        frmBuscarEmpresas oFrm = new frmBuscarEmpresas(oListaEmpresas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oEmpresaOperacion != null)
                        {
                            bsOperacion.DataSource = ListaOperacion = AgenteAlmacen.Proxy.ListarOperacionPorTipoArticulo(Convert.ToInt32(cboTipoAlmacen.SelectedValue), oFrm.oEmpresaOperacion.idEmpresa, Convert.ToInt32(cboTipoMovimiento.SelectedValue));
                            lblRegistros.Text = "Registros " + bsOperacion.Count.ToString();

                            foreach (OperacionE item in ListaOperacion)
                            {
                                OperacionE OpTemporal = new OperacionE
                                {
                                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                    automatico = item.automatico,
                                    TipoAlmacen = item.TipoAlmacen,
                                    codSunat = item.codSunat,
                                    desAlmacen = item.desAlmacen,
                                    desDetalle = item.desDetalle,
                                    desMovimiento = item.desMovimiento,
                                    desOperacion = item.desOperacion,
                                    FechaModificacion = item.FechaModificacion,
                                    FechaRegistro = item.FechaRegistro,
                                    indCliente = item.indCliente,
                                    indConsumo = item.indConsumo,
                                    indConversion = item.indConversion,
                                    indDevolucion = item.indDevolucion,
                                    indDocumentoAutomatico = item.indDocumentoAutomatico,
                                    indEstadistico = item.indEstadistico,
                                    indOrdenCompra = item.indOrdenCompra,
                                    indOrdentrabajo = item.indOrdentrabajo,
                                    indProveedor = item.indProveedor,
                                    indServicio = item.indServicio,
                                    indTransferencia = item.indTransferencia,
                                    indValorizar = item.indValorizar,
                                    nomSunat = item.nomSunat,
                                    orden = item.orden,
                                    tipAlmacen = item.tipAlmacen,
                                    tipMovimiento = item.tipMovimiento,
                                    UsuarioModificacion = item.UsuarioModificacion,
                                    UsuarioRegistro = item.UsuarioRegistro
                                };

                                OpTemporal = AgenteAlmacen.Proxy.InsertarOperacion(OpTemporal);
                            }

                            if (ListaOperacion.Count == 0)
                            {
                                Global.MensajeComunicacion("La Empresa no contiene registros para este Tipo de Articulo");
                            }
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("No existen datos en otras empresas.");
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Esta Tipo de Articulo en esta Empresa ya contiene registros");
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
