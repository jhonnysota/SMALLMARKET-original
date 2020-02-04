using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen
{
    public partial class frmSalidaAlmacene : FrmMantenimientoBase
    {     

        #region Constructor 

        public frmSalidaAlmacene()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            LlenarCombos();
            FormatoGrid(dgvRegistrosEntrada, true, false, 30);
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MovimientoAlmacenE oMovAlmacen = null;
        List<AlmacenE> ListarTipoAlmacen = null;
        List<MovimientoAlmacenE> oListaMovimientos;
        List<ParTabla> ListarTipoMovimiento = null;
        List<OperacionE> ListaOp = null;
        String RutaGeneral = String.Empty;
        string sParametro = string.Empty;
        string Anio = VariablesLocales.FechaHoy.ToString("yyyy");

        #endregion                

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {  
            //Almacenes//
            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                ListarTipoAlmacen = AgenteAlmacen.Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", 0, false, false);
                ComboHelper.RellenarCombos<AlmacenE>(cboalmacen, (from x in ListarTipoAlmacen orderby x.desAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
            }
            else
            {
                ListarTipoAlmacen = AgenteAlmacen.Proxy.ListarAlmacenPorUsuario(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.IdPersona);
                ComboHelper.RellenarCombos<AlmacenE>(cboalmacen, (from x in ListarTipoAlmacen orderby x.desAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
            }

            if (ListarTipoAlmacen.Count == 0)
            {
                Global.MensajeFault("No hay ningún almacén asignado.");
                return;
            }

            //Tipo de Movimiento//
            ListarTipoMovimiento = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPMOVALM");

            ComboHelper.RellenarCombos<ParTabla>(cboTipoMovimiento, (from x in ListarTipoMovimiento
                                                                     where (x.NemoTecnico == "EG" || x.NemoTecnico == "EGR") ||
                                                                           (x.NemoTecnico == "IN" || x.NemoTecnico == "ING")
                                                                     orderby x.IdParTabla
                                                                     select x).ToList(), "IdParTabla", "Nombre", false);

          
            cboTipoMovimiento.SelectedValue = Convert.ToInt32((from x in ListarTipoMovimiento
                                                               where x.NemoTecnico == "EG" || x.NemoTecnico == "EGR"
                                                               select x.IdParTabla).FirstOrDefault());

            //cboTipoMovimiento_SelectionChangeCommitted(new object(), new EventArgs());
            cboTipoAlmacen.DataSource = null;
            List<ParTabla> ListaOperacion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaOperacion.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaOperacion orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        private void comboTipoOperacion()
        {
            try
            {
                if (cboalmacen.SelectedValue.ToString() != "0" && cboTipoMovimiento.SelectedValue.ToString() != "0")
                {
                    ListaOp = AgenteAlmacen.Proxy.ListarOperacionporTipoMovimiento(sParametro, VariablesLocales.SesionLocal.IdEmpresa, Convert.ToInt32(cboTipoMovimiento.SelectedValue.ToString()));

                    if (ListaOp != null && ListaOp.Count > 0)
                    {
                        ListaOp = ListaOp.Where(x => x.tipAlmacen == ((AlmacenE)cboalmacen.SelectedItem).tipAlmacen).ToList();
                    }

                    OperacionE OperacionItem = new OperacionE() { idOperacion = Variables.Cero, desOperacion = Variables.Todos };
                    ListaOp.Add(OperacionItem);
                    ComboHelper.RellenarCombos<OperacionE>(cboconcepto, (from x in ListaOp orderby x.desOperacion select x).ToList(), "idOperacion", "desOperacion", false);

                    if (cboalmacen.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboconcepto.Enabled = false;
                    }
                    else
                    {
                        cboconcepto.Enabled = true;
                    }

                    cboconcepto.SelectedValue = Variables.Cero;
                }
                else
                {
                    ListaOp = new List<OperacionE>();

                    OperacionE OperacionItem = new OperacionE() { idOperacion = Variables.Cero, desOperacion = Variables.Todos };
                    ListaOp.Add(OperacionItem);
                    ComboHelper.RellenarCombos<OperacionE>(cboconcepto, (from x in ListaOp orderby x.desOperacion select x).ToList(), "idOperacion", "desOperacion", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Movimientos de Almacen";
            NombrePestaña = " Movimiento por OC ";

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    String Docum = String.Empty;
                    String DocumRef = String.Empty;
                    Int32 InicioLinea = 8;
                    Int32 TotColumnas = 11;
                    String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
                    String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 6.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    oHoja.Cells["A2"].Value = "RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC + "                                                " + "Fecha: " + FechaActual;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 6.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    oHoja.Cells["A3"].Value = "Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion + "                                                " + "Hora: " + HoraActual;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 6.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    oHoja.Cells["A5"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[5, 1, 5, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 13.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    oHoja.Cells["A6"].Value = oMovAlmacen.Correlativo;

                    using (ExcelRange Rango = oHoja.Cells[6, 1, 6, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }


                    #endregion

                    #region Cabeceras del Detalle

                    TotColumnas = 4;

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " Almacen  :";
                    oHoja.Cells[InicioLinea, 2].Value = oMovAlmacen.desAlmacen;
                    oHoja.Cells[InicioLinea, 3].Value = " Fecha  :";
                    oHoja.Cells[InicioLinea, 4].Value = oMovAlmacen.fecProceso;
                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "dd/MM/yyyy";

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " Proveedor/Cliente  :";
                    oHoja.Cells[InicioLinea, 2].Value = oMovAlmacen.RazonSocial;
                    oHoja.Cells[InicioLinea, 3].Value = " Operacion :";
                    oHoja.Cells[InicioLinea, 4].Value = oMovAlmacen.desOperacion;

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " Doc. y Doc. Referencia :";

                    if (!String.IsNullOrWhiteSpace(oMovAlmacen.serDocumento.Trim()))
                    {
                        Docum = oMovAlmacen.idDocumento + " " + oMovAlmacen.serDocumento + "-" + oMovAlmacen.numDocumento;
                    }
                    else
                    {
                        Docum = oMovAlmacen.idDocumento + " " + oMovAlmacen.numDocumento;
                    }

                    if (!String.IsNullOrWhiteSpace(oMovAlmacen.SerieDocumentoRef.Trim()))
                    {
                        if (oMovAlmacen.idDocumentoRef.Trim() == "0")
                        {
                            DocumRef = String.Empty;
                        }
                        else
                        {
                            DocumRef = " Ref. " + oMovAlmacen.idDocumentoRef + " " + oMovAlmacen.SerieDocumentoRef + "-" + oMovAlmacen.NumeroDocumentoRef;
                        }
                    }
                    else
                    {
                        if (oMovAlmacen.idDocumentoRef.Trim() == "0")
                        {
                            DocumRef = String.Empty;
                        }
                        else
                        {
                            DocumRef = " Ref. " + oMovAlmacen.idDocumentoRef + " " + oMovAlmacen.NumeroDocumentoRef;
                        }
                    }

                    oHoja.Cells[InicioLinea, 2].Value = Docum + DocumRef;
                    oHoja.Cells[InicioLinea, 3].Value = "  Fecha Doc. :";
                    oHoja.Cells[InicioLinea, 4].Value = oMovAlmacen.fecDocumento;

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " Glosa  :";
                    oHoja.Cells[InicioLinea, 2].Value = oMovAlmacen.Glosa;
                    oHoja.Cells[InicioLinea, 3].Value = " Orden de Compra  :";
                    oHoja.Cells[InicioLinea, 4].Value = oMovAlmacen.numOrdenCompra;

                    InicioLinea++;
                    InicioLinea++;

                    TotColumnas = 11;

                    oHoja.Cells[InicioLinea, 1].Value = " Item";
                    oHoja.Cells[InicioLinea, 2].Value = " Código";
                    oHoja.Cells[InicioLinea, 3].Value = " Descripción";
                    oHoja.Cells[InicioLinea, 4].Value = " Unidad Env.";
                    oHoja.Cells[InicioLinea, 5].Value = " Contenido";
                    oHoja.Cells[InicioLinea, 6].Value = " Unidad Pres.";
                    oHoja.Cells[InicioLinea, 7].Value = " Lote";
                    oHoja.Cells[InicioLinea, 8].Value = " Lote Almacen";
                    oHoja.Cells[InicioLinea, 9].Value = " Cantidad";
                    oHoja.Cells[InicioLinea, 10].Value = " Costo Unitario";
                    oHoja.Cells[InicioLinea, 11].Value = " Impuesto Total";

                    for (int i = 1; i <= 11; i++)
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

                    foreach (MovimientoAlmacenItemE item in oMovAlmacen.ListaAlmacenItem)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.numItem;
                        oHoja.Cells[InicioLinea, 2].Value = item.codArticulo;

                        if (item.oArticulo != null)
                        {
                            if (!String.IsNullOrWhiteSpace(item.oArticulo.nomUMedidaPres.Trim()))
                            {
                                oHoja.Cells[InicioLinea, 3].Value = item.nomArticulo + " x " + item.oArticulo.Cantidad.ToString("N2") + " " + item.oArticulo.nomUMedidaPres;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 3].Value = item.nomArticulo;
                            }
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 3].Value = item.nomArticulo;
                        }

                        oHoja.Cells[InicioLinea, 4].Value = item.oArticulo.nomUMedidaEnv;
                        oHoja.Cells[InicioLinea, 5].Value = item.oArticulo.Contenido;
                        oHoja.Cells[InicioLinea, 6].Value = item.oArticulo.nomUMedidaPres;


                        oHoja.Cells[InicioLinea, 7].Value = item.Lote;
                        oHoja.Cells[InicioLinea, 8].Value = item.oLoteEntidad.LoteAlmacen;
                        oHoja.Cells[InicioLinea, 9].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";

                        if (oMovAlmacen.idMoneda == Variables.Soles)
                        {
                            oHoja.Cells[InicioLinea, 10].Value = item.ImpCostoUnitarioBase;
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 11].Value = item.ImpTotalBase;
                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 10].Value = item.ImpCostoUnitarioRefe;
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 11].Value = item.ImpTotalRefe;
                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        }

                        InicioLinea++;
                    }

                    InicioLinea++;
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = "___________";

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 3].Value = " ";
                    oHoja.Cells[InicioLinea, 6].Value = oMovAlmacen.NombreCompleto;
                    InicioLinea++;
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

        #region Procedimientos heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSalidaAlmacenesEditar);

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
                oFrm = new frmSalidaAlmacenesEditar(Convert.ToInt32(cboalmacen.SelectedValue), Convert.ToInt32(cboTipoMovimiento.SelectedValue), Convert.ToInt32(cboconcepto.SelectedValue), ListarTipoAlmacen, ListarTipoMovimiento, ListaOp)
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

        public override void Buscar()
        {
            try
            {
                bsMovimientoAlmacen.DataSource = null;

                int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                int idAlmacen = Convert.ToInt32(cboalmacen.SelectedValue);
                int idconcepto = Convert.ToInt32(cboalmacen.SelectedValue) != 0 && Convert.ToInt32(cboTipoMovimiento.SelectedValue) != 0 ? Convert.ToInt32(cboconcepto.SelectedValue) : 0;

                if (idAlmacen != 0)
                {
                    oListaMovimientos = AgenteAlmacen.Proxy.ListarMovimientoAlmacen(idEmpresa, Convert.ToInt32(cboTipoMovimiento.SelectedValue), idAlmacen, dtpInicio.Value.ToString("yyyyMMdd"), dtpFin.Value.ToString("yyyyMMdd"), idconcepto, chbAnulados.Checked);
                    bsMovimientoAlmacen.DataSource = (from x in oListaMovimientos orderby x.idDocumentoAlmacen descending select x).ToList();
                    bsMovimientoAlmacen.ResetBindings(false);
                }

                //if (oListaMovimientos != null)
                //{
                //    if (oListaMovimientos.Count > 0)
                //    {
                //        lblregistros.Text = "Registros " + bsMovimientoAlmacen.Count.ToString();
                //    }
                //}
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
                if (bsMovimientoAlmacen.Count > 0)
                {
                    MovimientoAlmacenE current = (MovimientoAlmacenE)bsMovimientoAlmacen.Current;

                    if (current != null)
                    {
                        //se localiza el formulario buscandolo entre los forms abiertos 
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSalidaAlmacenesEditar);

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
                        oFrm = new frmSalidaAlmacenesEditar(current, ListarTipoAlmacen, ListarTipoMovimiento, ListaOp)
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

                if ((MovimientoAlmacenE)bsMovimientoAlmacen.Current != null)
                {
                    if (((MovimientoAlmacenE)bsMovimientoAlmacen.Current).indAutomatico)
                    {
                        Global.MensajeComunicacion("Este es un Movimiento Automático. No puede anularlo.");
                        return;
                    }

                    if (((MovimientoAlmacenE)bsMovimientoAlmacen.Current).indTransferencia && ((MovimientoAlmacenE)bsMovimientoAlmacen.Current).idAlmacenOrigen != 0)
                    {
                        if (((MovimientoAlmacenE)bsMovimientoAlmacen.Current).tipMovimientoAsociado != 0 && ((MovimientoAlmacenE)bsMovimientoAlmacen.Current).idDocumentoAlmacenAsociado != 0)
                        {
                            Global.MensajeComunicacion("Se trata de una transferencia debe anular primero el ingreso.");
                            return;
                        }
                    }

                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        MovimientoAlmacenE oEntidadAnular = (MovimientoAlmacenE)bsMovimientoAlmacen.Current;
                        AgenteAlmacen.Proxy.AnularMovimientoAlmacen(oEntidadAnular.idEmpresa, oEntidadAnular.tipMovimiento, oEntidadAnular.idDocumentoAlmacen, VariablesLocales.SesionUsuario.Credencial);

                        oListaMovimientos.RemoveAt(bsMovimientoAlmacen.Position);
                        bsMovimientoAlmacen.DataSource = oListaMovimientos;
                        bsMovimientoAlmacen.ResetBindings(false);
                        Buscar();
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
                if (bsMovimientoAlmacen.Count > 0)
                {
                    MovimientoAlmacenE current = (MovimientoAlmacenE)bsMovimientoAlmacen.Current;

                    if (current != null)
                    {
                        //se localiza el formulario buscandolo entre los forms abiertos 
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionBase);

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
                        MovimientoAlmacenE oMovimiento = AgenteAlmacen.Proxy.ObtenerMovimientoAlmacenCompleto(current.idEmpresa, current.tipMovimiento, current.idDocumentoAlmacen, true);

                        oFrm = new frmImpresionBase(oMovimiento, "Vista Previa del Movimiento de Almacén")
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show(); 
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
                MovimientoAlmacenE current = (MovimientoAlmacenE)bsMovimientoAlmacen.Current;

                if (current != null)
                {
                    oMovAlmacen = AgenteAlmacen.Proxy.ObtenerMovimientoAlmacenCompleto(current.idEmpresa, current.tipMovimiento, current.idDocumentoAlmacen, true);

                    if (oMovAlmacen == null || oMovAlmacen.ListaAlmacenItem.Count == Variables.Cero)
                    {
                        Global.MensajeFault("No hay datos para exportar a Excel.");
                        return;
                    }

                    RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", " Entrada Almacenes ", "Archivos Excel (*.xlsx)|*.xlsx");
                    ExportarExcel(RutaGeneral); 
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
            frmSalidaAlmacenesEditar oFrm = sender as frmSalidaAlmacenesEditar;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmSalidaAlmacene_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            dtpInicio.ValueChanged -= dtpInicio_ValueChanged;
            dtpFin.ValueChanged -= dtpFin_ValueChanged;
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia(VariablesLocales.FechaHoy.ToString("MM"), VariablesLocales.FechaHoy.ToString("yyyy")));//Convert.ToDateTime("01" + "/" + VariablesLocales.FechaHoy.Month.ToString("00") + "/" + VariablesLocales.FechaHoy.Year.ToString("00"));
            dtpFin.Value = VariablesLocales.FechaHoy.Date;
            dtpInicio.ValueChanged += dtpInicio_ValueChanged;
            dtpFin.ValueChanged += dtpFin_ValueChanged;

            cboTipoMovimiento_SelectionChangeCommitted(new object(), new EventArgs());

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvRegistrosEntrada.Columns[0].Visible = true;
            }
        }

        private void dgvRegistrosEntrada_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex < 6)
                {
                    e.CellStyle.BackColor = Color.PaleTurquoise;
                }

                if ((String)dgvRegistrosEntrada.Rows[e.RowIndex].Cells["indEstado"].Value == "AN")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
            }
        }
 
        private void dgvRegistrosEntrada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void cboTipoMovimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                comboTipoOperacion();
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboconcepto_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            if (cboalmacen.SelectedValue != null)
            {
               // Buscar();
            }
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            if (cboalmacen.SelectedValue != null)
            {
               // Buscar();
            }
        }

        private void cboalmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                comboTipoOperacion();
                Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chbAnulados_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void bsMovimientoAlmacen_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblregistros.Text = "Registros " + bsMovimientoAlmacen.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboalmacen.DataSource = null;
            Int32 tipalm = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipalm);
            oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione });
            ComboHelper.LlenarCombos<AlmacenE>(cboalmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
        }

        #endregion

    }
}
