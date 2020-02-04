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
using Infraestructura.Extensores;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen
{
    public partial class frmEntradaAlmacenes : FrmMantenimientoBase
    {

        #region Constructor

        public frmEntradaAlmacenes()
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

        List<AlmacenE> ListaAlmacenes = null;
        List<MovimientoAlmacenE> oListaMovimientos;
        List<ParTabla> ListaTipoArticulos = null;
        List<OperacionE> ListaOperaciones = null;
        MovimientoAlmacenE oMovAlmacen = null;
        Boolean Ordenar = false;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        String RutaGeneral = String.Empty;

        #endregion

        #region Procedimientos Usuario

        private void LlenarCombos()
        {
            //Almacenes//
            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                ListaAlmacenes = AgenteAlmacen.Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", 0, false, false);
                ComboHelper.RellenarCombos<AlmacenE>(cboalmacen, (from x in ListaAlmacenes orderby x.desAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
            }
            else
            {
                ListaAlmacenes = AgenteAlmacen.Proxy.ListarAlmacenPorUsuario(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.IdPersona);
                ComboHelper.RellenarCombos<AlmacenE>(cboalmacen, (from x in ListaAlmacenes orderby x.desAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
            }

            if (ListaAlmacenes.Count == 0)
            {
                Global.MensajeFault("No hay ningún almacén asignado.");
                return;
            }

            //Tipo de Movimiento//
            ListaTipoArticulos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPMOVALM");
            ComboHelper.RellenarCombos<ParTabla>(cboTipoMovimiento, (from x in ListaTipoArticulos
                                                                     where (x.NemoTecnico == "EG" || x.NemoTecnico == "EGR") ||
                                                                           (x.NemoTecnico == "IN" || x.NemoTecnico == "ING")
                                                                     orderby x.IdParTabla
                                                                     select x).ToList(), "IdParTabla", "Nombre", false);

            cboTipoMovimiento.SelectedValue = Convert.ToInt32((from x in ListaTipoArticulos
                                                               where x.NemoTecnico == "IN" || x.NemoTecnico == "ING"
                                                               select x.IdParTabla).FirstOrDefault());

            cboTipoAlmacen.DataSource = null;
            List<ParTabla> ListaOperacion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaOperacion.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaOperacion orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
            cboTipoAlmacen.SelectedIndex = 1;
        }

        private void comboTipoOperacion()
        {
            try
            {
                if (cboalmacen.SelectedValue.ToString() != "0" && cboTipoMovimiento.SelectedValue.ToString() != "0")
                {
                    ListaOperaciones = AgenteAlmacen.Proxy.ListarOperacionporTipoMovimiento("", VariablesLocales.SesionLocal.IdEmpresa, Convert.ToInt32(cboTipoMovimiento.SelectedValue));

                    if (ListaOperaciones != null && ListaOperaciones.Count > 0)
                    {
                        ListaOperaciones = ListaOperaciones.Where(x => x.tipAlmacen == ((AlmacenE)cboalmacen.SelectedItem).tipAlmacen).ToList();
                    }

                    OperacionE OperacionItem = new OperacionE() { idOperacion = Variables.Cero, desOperacion = Variables.Todos };
                    ListaOperaciones.Add(OperacionItem);
                    ComboHelper.RellenarCombos<OperacionE>(cboconcepto, (from x in ListaOperaciones orderby x.desOperacion select x).ToList(), "idOperacion", "desOperacion", false);
                    
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
                    ListaOperaciones = new List<OperacionE>
                    {
                        new OperacionE() { idOperacion = Variables.Cero, desOperacion = Variables.Todos }
                    };
                    ComboHelper.RellenarCombos<OperacionE>(cboconcepto, (from x in ListaOperaciones orderby x.desOperacion select x).ToList(), "idOperacion", "desOperacion", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportarExcel(String Ruta)
        {
            string TituloGeneral = "Movimientos de Almacen";
            string NombrePestaña = " Movimiento por OC ";

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
                    Int32 TotColumnas = 13;
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
                        Rango.Style.Font.SetFromFont(new Font("Arial", 8.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }


                    #endregion

                    #region Cabeceras del Detalle

                    TotColumnas = 4;

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " Almacen  :";
                    oHoja.Cells[InicioLinea, 2].Value = oMovAlmacen.desAlmacen;
                    oHoja.Cells[InicioLinea, 3].Value = " Fecha  :";
                    oHoja.Cells[InicioLinea, 4].Value = Convert.ToDateTime(oMovAlmacen.fecProceso);
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
                    oHoja.Cells[InicioLinea, 3].Value = " Orden De Compra  :";
                    oHoja.Cells[InicioLinea, 4].Value = oMovAlmacen.numOrdenCompra;

                    InicioLinea++;
                    InicioLinea++;

                    TotColumnas = 13;

                    oHoja.Cells[InicioLinea, 1].Value = " Item";
                    oHoja.Cells[InicioLinea, 2].Value = " Código";
                    oHoja.Cells[InicioLinea, 3].Value = " Descripción";
                    oHoja.Cells[InicioLinea, 4].Value = " Unidad Env.";
                    oHoja.Cells[InicioLinea, 5].Value = " Contenido";
                    oHoja.Cells[InicioLinea, 6].Value = " Unidad Pres.";
                    oHoja.Cells[InicioLinea, 7].Value = " Lote";
                    oHoja.Cells[InicioLinea, 8].Value = " Lote Almacen";
                    oHoja.Cells[InicioLinea, 9].Value = " Cantidad";
                    oHoja.Cells[InicioLinea, 10].Value = " Costo Unitario S/";
                    oHoja.Cells[InicioLinea, 11].Value = " Impuesto Total S/";
                    oHoja.Cells[InicioLinea, 12].Value = " Costo Unitario $";
                    oHoja.Cells[InicioLinea, 13].Value = " Impuesto Total $";


                    for (int i = 1; i <= 13; i++)
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
                            oHoja.Cells[InicioLinea, 12].Value = item.ImpCostoUnitarioRefe;
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 13].Value = item.ImpTotalRefe;
                            oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 10].Value = item.ImpCostoUnitarioRefe;
                            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 11].Value = item.ImpTotalRefe;
                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 12].Value = item.ImpCostoUnitarioRefe;
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 13].Value = item.ImpTotalRefe;
                            oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
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

        private void ExportarExcelLote(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Movimientos de Almacen";
            NombrePestaña = "Detalle";

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
                    Int32 TotColumnas = 31;
                    String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
                    String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

                    #region Titulos Principales

                    // Nombre de la Empresa
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 16.25f, FontStyle.Bold));
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    oHoja.Row(2).Height = 8.25;

                    //RUC
                    oHoja.Cells["A3"].Value = "RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, 10])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 9.25f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    //Fecha de Reporte
                    oHoja.Cells["K3"].Value = "Fecha: " + FechaActual;

                    using (ExcelRange Rango = oHoja.Cells[3, 11, 3, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 9.25f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    //Dirección
                    oHoja.Cells["A4"].Value = "Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion;

                    using (ExcelRange Rango = oHoja.Cells[4, 1, 4, 10])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 9.25f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    //Hora del Reporte
                    oHoja.Cells["K4"].Value = "Hora: " + HoraActual;

                    using (ExcelRange Rango = oHoja.Cells[4, 11, 4, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 9.25f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    oHoja.Row(5).Height = 8.25;

                    //Número del movimiento
                    oHoja.Cells["A6"].Value = "Movimiento N°: " + oMovAlmacen.Correlativo;

                    using (ExcelRange Rango = oHoja.Cells[6, 1, 6, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 9.25f, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    oHoja.Cells[InicioLinea, 1].Value = "Item";
                    oHoja.Column(1).Width = 6;
                    oHoja.Cells[InicioLinea, 2].Value = "Código";
                    oHoja.Column(2).Width = 8;
                    oHoja.Cells[InicioLinea, 3].Value = "Nombre";
                    oHoja.Column(3).Width = 30;
                    oHoja.Cells[InicioLinea, 4].Value = "Nombre Comer.";
                    oHoja.Column(4).Width = 16;
                    oHoja.Cells[InicioLinea, 5].Value = "Nombre Ext.";
                    oHoja.Column(5).Width = 8.25;
                    oHoja.Cells[InicioLinea, 6].Value = "Unid. Medida";
                    oHoja.Column(6).Width = 9;
                    oHoja.Cells[InicioLinea, 7].Value = "U.M. Env.";
                    oHoja.Column(7).Width = 9;
                    oHoja.Cells[InicioLinea, 8].Value = "U.M. Pres.";
                    oHoja.Column(8).Width = 9;
                    oHoja.Cells[InicioLinea, 9].Value = "Cant. Pres.";
                    oHoja.Column(9).Width = 9;
                    oHoja.Cells[InicioLinea, 10].Value = "Lote";
                    oHoja.Column(10).Width = 6;
                    oHoja.Cells[InicioLinea, 11].Value = "Cant.";
                    oHoja.Column(11).Width = 7;
                    oHoja.Cells[InicioLinea, 12].Value = "Imp. Tot.";
                    oHoja.Column(12).Width = 8.25;
                    oHoja.Cells[InicioLinea, 13].Value = "Lote Prov.";
                    oHoja.Column(13).Width = 8.25;
                    oHoja.Cells[InicioLinea, 14].Value = "Lote Alma.";
                    oHoja.Column(14).Width = 8.25;
                    oHoja.Cells[InicioLinea, 15].Value = "Pais Orig.";
                    oHoja.Column(15).Width = 8.50;
                    oHoja.Cells[InicioLinea, 16].Value = "Pais Proc.";
                    oHoja.Column(16).Width = 8.50;
                    oHoja.Cells[InicioLinea, 17].Value = "Batch";
                    oHoja.Column(17).Width = 8.5;
                    oHoja.Cells[InicioLinea, 18].Value = "% Germ.";
                    oHoja.Column(18).Width = 8.5;
                    oHoja.Cells[InicioLinea, 19].Value = "Fec. Prueba";
                    oHoja.Column(19).Width = 8.50;
                    oHoja.Cells[InicioLinea, 20].Value = "Peso Unit.";
                    oHoja.Column(20).Width = 8.50;
                    oHoja.Cells[InicioLinea, 21].Value = "Cod. Color";
                    oHoja.Column(21).Width = 8;
                    oHoja.Cells[InicioLinea, 22].Value = "Hib. Op.";
                    oHoja.Column(22).Width = 8;
                    oHoja.Cells[InicioLinea, 23].Value = "Otros";
                    oHoja.Column(23).Width = 8;
                    oHoja.Cells[InicioLinea, 24].Value = "Ca.Cm.";
                    oHoja.Column(24).Width = 8;
                    oHoja.Cells[InicioLinea, 25].Value = "Patron";
                    oHoja.Column(25).Width = 8;
                    oHoja.Cells[InicioLinea, 26].Value = "Observacion";
                    oHoja.Column(26).Width = 8.25;
                    oHoja.Cells[InicioLinea, 27].Value = "Entregado Por";
                    oHoja.Column(27).Width = 8;
                    oHoja.Cells[InicioLinea, 28].Value = "Usu. Reg.";
                    oHoja.Column(28).Width = 10;
                    oHoja.Cells[InicioLinea, 29].Value = "Fec. Reg.";
                    oHoja.Column(29).Width = 13;
                    oHoja.Cells[InicioLinea, 30].Value = "Usu. Mod.";
                    oHoja.Column(30).Width = 10;
                    oHoja.Cells[InicioLinea, 31].Value = "Fec. Mod.";
                    oHoja.Column(31).Width = 13;

                    for (int i = 1; i <= 31; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;

                        if (i <= 9)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        }

                        if (i >= 10)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(216, 190, 156));
                        }
                        
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new Font("Arial", 7.25f, FontStyle.Bold));
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
                        oHoja.Cells[InicioLinea, 3].Value = item.nomArticulo;
                        oHoja.Cells[InicioLinea, 4].Value = item.oArticulo.nomArticuloLargo;
                        oHoja.Cells[InicioLinea, 5].Value = item.oArticulo.nomCorto;
                        oHoja.Cells[InicioLinea, 6].Value = item.oArticulo.nomUMedida;
                        oHoja.Cells[InicioLinea, 7].Value = item.oArticulo.nomUMedidaEnv;
                        oHoja.Cells[InicioLinea, 8].Value = item.oArticulo.nomUMedidaPres;
                        oHoja.Cells[InicioLinea, 9].Value = item.oArticulo.Contenido;
                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 10].Value = item.Lote;
                        oHoja.Cells[InicioLinea, 11].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";

                        if (oMovAlmacen.idMoneda == Variables.Soles)
                        {
                            oHoja.Cells[InicioLinea, 12].Value = item.ImpTotalBase;
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 12].Value = item.ImpTotalRefe;
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                        }

                        oHoja.Cells[InicioLinea, 13].Value = item.LoteProveedor;
                        oHoja.Cells[InicioLinea, 14].Value = item.oLoteEntidad.LoteAlmacen;
                        oHoja.Cells[InicioLinea, 15].Value = item.oLoteEntidad.DesPaisOrigen;
                        oHoja.Cells[InicioLinea, 16].Value = item.oLoteEntidad.DesPaisProcedencia;
                        oHoja.Cells[InicioLinea, 17].Value = item.oLoteEntidad.Batch;
                        oHoja.Cells[InicioLinea, 18].Value = item.oLoteEntidad.PorcentajeGerminacion;
                        oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 19].Value = item.oLoteEntidad.fecPrueba;
                        oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 20].Value = item.oArticulo.Contenido;
                        oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 21].Value = item.oLoteEntidad.DesColor;
                        oHoja.Cells[InicioLinea, 22].Value = item.oLoteEntidad.HibOp;
                        oHoja.Cells[InicioLinea, 23].Value = item.oLoteEntidad.Otros;
                        oHoja.Cells[InicioLinea, 24].Value = item.oLoteEntidad.CaCm;
                        oHoja.Cells[InicioLinea, 25].Value = item.oLoteEntidad.Patron;
                        oHoja.Cells[InicioLinea, 26].Value = item.oLoteEntidad.Observacion;
                        oHoja.Cells[InicioLinea, 27].Value = item.oLoteEntidad.EntregadoPor;
                        oHoja.Cells[InicioLinea, 28].Value = item.oLoteEntidad.UsuarioRegistro;
                        oHoja.Cells[InicioLinea, 29].Value = item.oLoteEntidad.FechaRegistro;
                        oHoja.Cells[InicioLinea, 29].Style.Numberformat.Format = "dd/MM/yyyy hh:mm";
                        oHoja.Cells[InicioLinea, 29].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[InicioLinea, 30].Value = item.oLoteEntidad.UsuarioModificacion;
                        oHoja.Cells[InicioLinea, 31].Value = item.oLoteEntidad.FechaModificacion;
                        oHoja.Cells[InicioLinea, 31].Style.Numberformat.Format = "dd/MM/yyyy hh:mm";
                        oHoja.Cells[InicioLinea, 31].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        for (int c = 1; c <= TotColumnas; c++)
                        {
                            oHoja.Cells[InicioLinea, c].Style.Font.SetFromFont(new Font("Arial", 7.25f));
                        }

                        InicioLinea++;
                    }

                    InicioLinea++;
            
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
                //se localiza el formulario buscandolo entre los forms abiertos
                if (0 != Convert.ToInt32(cboalmacen.SelectedValue))
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEntradaAlmacenesEditar);

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
                    oFrm = new frmEntradaAlmacenesEditar(Convert.ToInt32(cboalmacen.SelectedValue), Convert.ToInt32(cboTipoMovimiento.SelectedValue), Convert.ToInt32(cboconcepto.SelectedValue), ListaAlmacenes, ListaTipoArticulos, ListaOperaciones)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
                else
                {
                    Global.MensajeComunicacion("Selecciones un Almacen");
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
                bsMovimientoAlmacen.DataSource = null;

                int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                int idAlmacen = Convert.ToInt32(cboalmacen.SelectedValue);
                int idconcepto = Convert.ToInt32(cboalmacen.SelectedValue) != 0 && Convert.ToInt32(cboTipoMovimiento.SelectedValue) != 0 ? Convert.ToInt32(cboconcepto.SelectedValue.ToString()) : 0;

                if (idAlmacen != 0)
                {
                    oListaMovimientos = AgenteAlmacen.Proxy.ListarMovimientoAlmacen(idEmpresa, Convert.ToInt32(cboTipoMovimiento.SelectedValue), idAlmacen, dtpInicio.Value.ToString("yyyyMMdd"), dtpFin.Value.ToString("yyyyMMdd"), idconcepto, chkAnulados.Checked);
                    bsMovimientoAlmacen.DataSource = (from x in oListaMovimientos orderby x.idDocumentoAlmacen descending select x).ToList();
                    bsMovimientoAlmacen.ResetBindings(false);
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
                if (bsMovimientoAlmacen.Count > 0)
                {
                    MovimientoAlmacenE current = (MovimientoAlmacenE)bsMovimientoAlmacen.Current;

                    if (current != null)
                    {
                        //se localiza el formulario buscandolo entre los forms abiertos 
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEntradaAlmacenesEditar);

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
                        oFrm = new frmEntradaAlmacenesEditar(current, ListaAlmacenes, ListaTipoArticulos, ListaOperaciones)
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

                    if (((MovimientoAlmacenE)bsMovimientoAlmacen.Current).indEstado == "HC")
                    {
                        Global.MensajeComunicacion("Debe eliminar primero la hoja de costo, antes de anular el movimiento.");
                        return;
                    }

                    if (((MovimientoAlmacenE)bsMovimientoAlmacen.Current).indEstado == "AN")
                    {
                        Global.MensajeComunicacion("Este movimiento de almacén ya se encuentra anulado.");
                        return;
                    }

                    if (((MovimientoAlmacenE)bsMovimientoAlmacen.Current).indTransferencia)
                    {
                        if (((MovimientoAlmacenE)bsMovimientoAlmacen.Current).tipMovimientoAsociado != 0 && ((MovimientoAlmacenE)bsMovimientoAlmacen.Current).idDocumentoAlmacenAsociado != 0)
                        {
                            MovimientoAlmacenE oMovimiento = Colecciones.CopiarEntidad((MovimientoAlmacenE)bsMovimientoAlmacen.Current);
                            oMovimiento.tipMovimiento = Convert.ToInt32(oMovimiento.tipMovimientoAsociado);
                            oMovimiento.idDocumentoAlmacen = Convert.ToInt32(oMovimiento.idDocumentoAlmacenAsociado);
                            oMovimiento.indPorAsociar = true;
                            oMovimiento.idAlmacenOrigen = null;
                            oMovimiento.tipMovimientoAsociado = null;
                            oMovimiento.idDocumentoAlmacenAsociado = null;
                            oMovimiento.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                            AgenteAlmacen.Proxy.ActualizarMovimientoTrans(oMovimiento);
                        }
                    }

                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        MovimientoAlmacenE oEntidadAnular = (MovimientoAlmacenE)bsMovimientoAlmacen.Current;
                        AgenteAlmacen.Proxy.AnularMovimientoAlmacen(oEntidadAnular.idEmpresa, oEntidadAnular.tipMovimiento, oEntidadAnular.idDocumentoAlmacen, VariablesLocales.SesionUsuario.Credencial);

                        oListaMovimientos.RemoveAt(bsMovimientoAlmacen.Position);
                        bsMovimientoAlmacen.DataSource = oListaMovimientos;
                        bsMovimientoAlmacen.ResetBindings(false);
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

                    if (!String.IsNullOrWhiteSpace(RutaGeneral))
                    {
                        ExportarExcel(RutaGeneral); 
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

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmEntradaAlmacenesEditar oFrm = sender as frmEntradaAlmacenesEditar;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmEntradaAlmacenes_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            dtpInicio.ValueChanged -= dtpInicio_ValueChanged;
            dtpFin.ValueChanged -= dtpFin_ValueChanged;
            dtpInicio.Value = Convert.ToDateTime("01" + "/" + VariablesLocales.FechaHoy.Month.ToString("00") + "/" + VariablesLocales.FechaHoy.Year.ToString("00"));
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
                if ((String)dgvRegistrosEntrada.Rows[e.RowIndex].Cells["indEstado"].Value == "AN")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
                else
                {
                    if (e.ColumnIndex < 6)
                    {
                        e.CellStyle.BackColor = Color.PaleTurquoise;
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

        private void cboconcepto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void cboTipoMovimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            comboTipoOperacion();
            Buscar();
        }

        private void cboAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboTipoOperacion();
            Buscar();
        }
        
        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            if (cboalmacen.SelectedValue != null)
            {
                //Buscar();
            }
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            if (cboalmacen.SelectedValue != null)
            {
                //Buscar();
            }
        }

        private void chkAnulados_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvRegistrosEntrada_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaMovimientos != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // POR FILE
                    if (e.ColumnIndex == dgvRegistrosEntrada.Columns["numCorrelativo"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaMovimientos = (from x in oListaMovimientos orderby x.Correlativo ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaMovimientos = (from x in oListaMovimientos orderby x.Correlativo descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR DECRIPCION FILE
                    if (e.ColumnIndex == dgvRegistrosEntrada.Columns["fecProceso"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaMovimientos = (from x in oListaMovimientos orderby x.fecProceso ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaMovimientos = (from x in oListaMovimientos orderby x.fecProceso descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR FECHA DE OPERACION
                    if (e.ColumnIndex == dgvRegistrosEntrada.Columns["RazonSocial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaMovimientos = (from x in oListaMovimientos orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaMovimientos = (from x in oListaMovimientos orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR ORDEN DE COMPRA
                    if (e.ColumnIndex == dgvRegistrosEntrada.Columns["numOrdenCompra"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaMovimientos = (from x in oListaMovimientos orderby x.numOrdenCompra ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaMovimientos = (from x in oListaMovimientos orderby x.numOrdenCompra descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }

                bsMovimientoAlmacen.DataSource = oListaMovimientos;
            }
        }

        private void tsmiGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                MovimientoAlmacenE current = (MovimientoAlmacenE)bsMovimientoAlmacen.Current;

                if (current != null)
                {
                    if (current.indEstado == "HC")
                    {
                        Global.MensajeFault("La hoja de costo se encuentra cerrada, no se podrán hacer modificaciones.");
                        return;
                    }

                    if (current.indEstado == "AN")
                    {
                        Global.MensajeFault("No se puede generar Hoja de Costo porque el movimiento se encuentra anulado.");
                        return;
                    }

                    Boolean Retorno = AgenteAlmacen.Proxy.GenerarHojaCostos(current, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.SesionUsuario.Credencial);

                    if (Retorno)
                    {
                        Global.MensajeFault("Se generó la hoja de costo con éxito.");
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiGenerarExcel_Click(object sender, EventArgs e)
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

                    RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Detalle del Movimiento", "Archivos Excel (*.xlsx)|*.xlsx");
                    ExportarExcelLote(RutaGeneral); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void bsMovimientoAlmacen_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                if (oListaMovimientos != null)
                {
                    if (oListaMovimientos.Count > 0)
                    {
                        lblregistros.Text = "Registros " + bsMovimientoAlmacen.Count.ToString();
                    }
                    else
                    {
                        lblregistros.Text = "Registros 0";
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboalmacen.DataSource = null;
            Int32 tipalm = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipalm);
            AlmacenE oItem = new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione };
            oListaAlmacen.Add(oItem);
            ComboHelper.LlenarCombos<AlmacenE>(cboalmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
        }

        #endregion

    }
}
