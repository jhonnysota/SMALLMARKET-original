using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen
{
    public partial class frmOrdenConversionListado : FrmMantenimientoBase
    {

        #region Constructor

        public frmOrdenConversionListado()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarTipoArticulo();
            FormatoGrid(dgvConversion, false);
            
        }

        #endregion 

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<OrdenConversionE> oListaConv = null;
        OrdenConversionE ListaConversiones = new OrdenConversionE();
        String RutaGeneral = String.Empty;
        #endregion

        #region Procedimientos de Usuario

        private void LlenarTipoArticulo()
        {
            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione });

            ComboHelper.LlenarCombos(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
        }

        void ExportarExcel(String Ruta, OrdenConversionE oOrdenConv)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "ORDEN DE CONVERSION N° " + oOrdenConv.Numero;
            NombrePestaña = " Orden Conversion ";

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    String Docum = String.Empty;
                    String DocumRef = String.Empty;
                    Int32 InicioLinea = 10;
                    Int32 TotColumnas = 15;
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

                    oHoja.Cells["A7"].Value = " Fecha De La Conversion: " + oOrdenConv.Fecha.ToString("d");

                    using (ExcelRange Rango = oHoja.Cells[7, 1, 7, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 8.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    oHoja.Cells["A9"].Value = "ORDEN CONVERSION SALIDAS";

                    using (ExcelRange Rango = oHoja.Cells[9, 1, 9, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 11.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    TotColumnas = 15;

                    oHoja.Cells[InicioLinea, 1].Value = " Item";
                    oHoja.Cells[InicioLinea, 2].Value = " Almacen";
                    oHoja.Cells[InicioLinea, 3].Value = " Lote Interno";
                    oHoja.Cells[InicioLinea, 4].Value = " Código ";
                    oHoja.Cells[InicioLinea, 5].Value = " Descripción";
                    oHoja.Cells[InicioLinea, 6].Value = " Unidad Env.";
                    oHoja.Cells[InicioLinea, 7].Value = " Contenido";
                    oHoja.Cells[InicioLinea, 8].Value = " Unidad Pres.";
                    oHoja.Cells[InicioLinea, 9].Value = " Lote Almacen";
                    oHoja.Cells[InicioLinea, 10].Value = " Cantidad";
                    oHoja.Cells[InicioLinea, 11].Value = " Peso Unit.";
                    oHoja.Cells[InicioLinea, 12].Value = " Peso Total";
                    oHoja.Cells[InicioLinea, 13].Value = " Costo Unitario S/";
                    oHoja.Cells[InicioLinea, 14].Value = " Costo Total S/";
                    oHoja.Cells[InicioLinea, 15].Value = " Stock";


                    for (int i = 1; i <= 15; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                        oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.Black);
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Formato Excel
                    Int32 Correlativo = 1;
                    Decimal MontosubCantidad = 0;
                    Decimal MontosubPesoTotal = 0;
                    Decimal MontosubCostoTotal = 0;
                    foreach (OrdenConversionSalidaE item in oOrdenConv.ListaConverSalida)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = Correlativo;
                        oHoja.Cells[InicioLinea, 2].Value = item.nomAlmacen;
                        oHoja.Cells[InicioLinea, 3].Value = item.Lote;
                        oHoja.Cells[InicioLinea, 4].Value = item.codArticulo;
                        oHoja.Cells[InicioLinea, 5].Value = item.NombreArt;
                        oHoja.Cells[InicioLinea, 6].Value = item.nomUMedidaEnv;
                        oHoja.Cells[InicioLinea, 7].Value = item.contenido;
                        oHoja.Cells[InicioLinea, 8].Value = item.nomUMedidaPres;
                        oHoja.Cells[InicioLinea, 9].Value = item.LoteAlmacen;
                        oHoja.Cells[InicioLinea, 10].Value = item.CantSolicitada;
                        oHoja.Cells[InicioLinea, 11].Value = item.PesoUnitario;
                        oHoja.Cells[InicioLinea, 12].Value = item.TotalPeso;
                        oHoja.Cells[InicioLinea, 13].Value = item.CostoUnitario;
                        oHoja.Cells[InicioLinea, 14].Value = item.TotalCosto;
                        oHoja.Cells[InicioLinea, 15].Value = item.Stock;
                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                        MontosubCantidad += item.CantSolicitada;
                        MontosubPesoTotal += item.TotalPeso;
                        MontosubCostoTotal += item.TotalCosto;
                        InicioLinea++;
                        Correlativo++;
                    }

                    oHoja.Cells[InicioLinea, 5].Value = "Sub Total";
                    oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    oHoja.Cells[InicioLinea, 5].Style.Font.Color.SetColor(Color.Black);
                    oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 10].Value = MontosubCantidad;
                    oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 10].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    oHoja.Cells[InicioLinea, 10].Style.Font.Color.SetColor(Color.Black);
                    oHoja.Cells[InicioLinea, 10].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    oHoja.Cells[InicioLinea, 12].Value = MontosubPesoTotal;
                    oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    oHoja.Cells[InicioLinea, 12].Style.Font.Color.SetColor(Color.Black);
                    oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    oHoja.Cells[InicioLinea, 14].Value = MontosubCostoTotal;
                    oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    oHoja.Cells[InicioLinea, 14].Style.Font.Color.SetColor(Color.Black);
                    oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    InicioLinea++;
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = "ORDEN CONVERSION ENTRADAS";
                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 11.25f, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    }

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " Item";
                    oHoja.Cells[InicioLinea, 2].Value = " Almacen";
                    oHoja.Cells[InicioLinea, 3].Value = " Lote Interno";
                    oHoja.Cells[InicioLinea, 4].Value = " Código ";
                    oHoja.Cells[InicioLinea, 5].Value = " Descripción";
                    oHoja.Cells[InicioLinea, 6].Value = " Unidad Env.";
                    oHoja.Cells[InicioLinea, 7].Value = " Contenido";
                    oHoja.Cells[InicioLinea, 8].Value = " Unidad Pres.";
                    oHoja.Cells[InicioLinea, 9].Value = " Lote Almacen";
                    oHoja.Cells[InicioLinea, 10].Value = " Cantidad";
                    oHoja.Cells[InicioLinea, 11].Value = " Peso Unit.";
                    oHoja.Cells[InicioLinea, 12].Value = " Peso Total";
                    oHoja.Cells[InicioLinea, 13].Value = " Costo Unitario S/";
                    oHoja.Cells[InicioLinea, 14].Value = " Costo Total S/";
                    oHoja.Cells[InicioLinea, 15].Value = " Stock";

                    for (int i = 1; i <= 15; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                        oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Formato Excel

                    Decimal MontosubCantidad2 = 0;
                    Decimal MontosubPesoTotal2 = 0;
                    Decimal MontosubCostoTotal2 = 0;
                    Int32 Correlativo2 = 1;

                    foreach (OrdenConversionDetalleE item in oOrdenConv.ListaConverDetalle)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = Correlativo2;
                        oHoja.Cells[InicioLinea, 2].Value = item.nomAlmacen;
                        oHoja.Cells[InicioLinea, 3].Value = item.Lote;
                        oHoja.Cells[InicioLinea, 4].Value = item.codArticulo;
                        oHoja.Cells[InicioLinea, 5].Value = item.NombreArt;
                        oHoja.Cells[InicioLinea, 6].Value = item.nomUMedidaEnv;
                        oHoja.Cells[InicioLinea, 7].Value = item.contenido;
                        oHoja.Cells[InicioLinea, 8].Value = item.nomUMedidaPres;
                        oHoja.Cells[InicioLinea, 9].Value = item.LoteAlmacen;
                        oHoja.Cells[InicioLinea, 10].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 11].Value = item.PesoUnitario;
                        oHoja.Cells[InicioLinea, 12].Value = item.TotalPeso;
                        oHoja.Cells[InicioLinea, 13].Value = item.CostoUnitario;
                        oHoja.Cells[InicioLinea, 14].Value = item.TotalCosto;
                        oHoja.Cells[InicioLinea, 15].Value = 0;
                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                        MontosubCantidad2 += item.Cantidad;
                        MontosubPesoTotal2 += item.TotalPeso;
                        MontosubCostoTotal2 += item.TotalCosto;
                        Correlativo2++;
                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 5].Value = "Sub Total";
                    oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    oHoja.Cells[InicioLinea, 5].Style.Font.Color.SetColor(Color.Black);
                    oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    oHoja.Cells[InicioLinea, 10].Value = MontosubCantidad2;
                    oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 10].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    oHoja.Cells[InicioLinea, 10].Style.Font.Color.SetColor(Color.Black);
                    oHoja.Cells[InicioLinea, 10].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    oHoja.Cells[InicioLinea, 12].Value = MontosubPesoTotal2;
                    oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    oHoja.Cells[InicioLinea, 12].Style.Font.Color.SetColor(Color.Black);
                    oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    oHoja.Cells[InicioLinea, 14].Value = MontosubCostoTotal2;
                    oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    oHoja.Cells[InicioLinea, 14].Style.Font.Color.SetColor(Color.Black);
                    oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    InicioLinea++;
                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = "___________";

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 5].Value = " ";
                    oHoja.Cells[InicioLinea, 8].Value = oOrdenConv.NombreCompleto;
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

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenConversion);

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

                Int32 idconcepto = 0;

                if (rb1.Checked)
                {
                    idconcepto = 1;
                }

                if (rbTransformacion.Checked)
                {
                    idconcepto = 2;
                }

                //sino existe la instancia se crea una nueva
                oFrm = new frmOrdenConversion(idconcepto)
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
            Form oFrm = this.MdiChildren.FirstOrDefault(x => x is frmOrdenConversion);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            Int32 idconcepto = 0;

            if (rb1.Checked)
            {
                idconcepto = 1;
            }

            oFrm = new frmOrdenConversion((OrdenConversionE)bsOrdenConversion.Current, idconcepto)
            {
                MdiParent = MdiParent
            };

            oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
            oFrm.Show();
        }

        public override void Buscar()
        {
            try
            {
                int art = Convert.ToInt32(txtArt.Tag);
                String Tipo = "O";

                if (rbMovimiento.Checked)
                {
                    Tipo = "M";
                }

                if (rb0.Checked)
                {
                    oListaConv = AgenteAlmacen.Proxy.ListarOrdenConversion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpDesde.Value.Date, dtpHasta.Value.Date, 0, art, txtNomArt.Text.Trim(), Tipo);
                }
                else
                {
                    oListaConv = AgenteAlmacen.Proxy.ListarOrdenConversion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpDesde.Value.Date, dtpHasta.Value.Date, 1, art, txtNomArt.Text.Trim(), Tipo);
                }
 
                bsOrdenConversion.DataSource = oListaConv;
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
                if (bsOrdenConversion.Count > Variables.Cero)
                {
                    #region Ingresos
                    
                    //Obteniendo la cabecera de la Orden de Conversion.
                    OrdenConversionE oOrden = (OrdenConversionE)bsOrdenConversion.Current;
                    //Obteniendo el detalle
                    oOrden.ListaConverDetalle = AgenteAlmacen.Proxy.ListarOrdenConversionDetalle(oOrden.idEmpresa, oOrden.idOrdenConversion);

                    //Revisando si la cabecera tiene detalle
                    if (oOrden.ListaConverDetalle != null && oOrden.ListaConverDetalle.Count > 0)
                    {
                        //Recorriendo el detalle para saber si ya se generó el Ingreso.
                        foreach (OrdenConversionDetalleE item in oOrden.ListaConverDetalle)
                        {
                            if (item.indGenerada)
                            {
                                Global.MensajeComunicacion("No se puede eliminar porque tiene Movimientos de Ingreso.");
                                return;
                            }
                        }
                    }

                    #endregion

                    #region Salidas

                    if (((OrdenConversionE)bsOrdenConversion.Current).indGenerada)
                    {
                        Global.MensajeComunicacion("No se puede eliminar la conversión por que ya tiene Movimientos de Salida.");
                        return;
                    } 

                    #endregion

                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteAlmacen.Proxy.EliminarOrdenConversion(((OrdenConversionE)bsOrdenConversion.Current).idEmpresa, ((OrdenConversionE)bsOrdenConversion.Current).idOrdenConversion);
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
                if (bsOrdenConversion.Count > 0)
                {
                    OrdenConversionE EOrdenConvers = AgenteAlmacen.Proxy.ObtenerOrdenConversionCompleta(((OrdenConversionE)bsOrdenConversion.Current).idEmpresa, ((OrdenConversionE)bsOrdenConversion.Current).idOrdenConversion);//(OrdenConversionE)bsOrdenConversion.Current;

                    frmImpresionBase oFrm = new frmImpresionBase(EOrdenConvers, "Vista Previa de Orden Conversión")
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
                OrdenConversionE EOrdenConvers = AgenteAlmacen.Proxy.ObtenerOrdenConversionCompleta(((OrdenConversionE)bsOrdenConversion.Current).idEmpresa, ((OrdenConversionE)bsOrdenConversion.Current).idOrdenConversion);

                if (EOrdenConvers == null || EOrdenConvers.ListaConverDetalle.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Orden Conversion", "Archivos Excel (*.xlsx)|*.xlsx");
                ExportarExcel(RutaGeneral, EOrdenConvers);
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
            frmOrdenConversion oFrm = sender as frmOrdenConversion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmOrdenConversionListado_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            // Los Ultimos 10 Dias
            dtpDesde.Value = VariablesLocales.FechaHoy.AddDays(-10);
            dtpHasta.Value = VariablesLocales.FechaHoy;
            txtArt.Tag = 0;
        }

        private void dgvConversion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void tsmGenerarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (((OrdenConversionE)bsOrdenConversion.Current).indGenerada)
                {
                    Global.MensajeComunicacion("Ya fue Generada la Salida por Conversión...!!! ");
                }
                else
                {
                    if (Global.MensajeConfirmacion("Generar Salida para Conversion....") == DialogResult.Yes)
                    {
                        //Obteniendo la cabecera de la Orden de Conversion
                        OrdenConversionE oOrden = AgenteAlmacen.Proxy.ObtenerOrdenConversionCompleta(((OrdenConversionE)bsOrdenConversion.Current).idEmpresa, ((OrdenConversionE)bsOrdenConversion.Current).idOrdenConversion);
                        //Generando la salida...
                        oOrden = AgenteAlmacen.Proxy.GeneraSalidaAlmacenPorConversion(oOrden, VariablesLocales.SesionUsuario.Credencial);
                        //Actualizando la linea
                        oListaConv[bsOrdenConversion.Position] = oOrden;

                        Global.MensajeComunicacion("Se generó la salida al almacén.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmEliminarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (!((OrdenConversionE)bsOrdenConversion.Current).indGenerada)
                {
                    Global.MensajeComunicacion("Aún no se ha generado ningúna Salida al almacén.");
                }
                else
                {
                    if (Global.MensajeConfirmacion("Desea eliminar la Salida del Almacén.") == DialogResult.Yes)
                    {
                        //Mandando la entidad para eliminar los movimientos
                        OrdenConversionE oOrden = AgenteAlmacen.Proxy.AnularSalAlmacenPorConversion((OrdenConversionE)bsOrdenConversion.Current, VariablesLocales.SesionUsuario.Credencial);

                        //Verificando si todo esta correcto...
                        if (oOrden != null)
                        {
                            //Actualizando la linea
                            oListaConv[bsOrdenConversion.Position] = oOrden;
                            Global.MensajeComunicacion("Movimiento de salida anulado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmGeneraIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                //Obteniendo la cabecera de la Orden de Conversion.
                OrdenConversionE oOrden = (OrdenConversionE)bsOrdenConversion.Current;
                //Obteniendo el detalle
                oOrden.ListaConverDetalle = AgenteAlmacen.Proxy.ListarOrdenConversionDetalle(oOrden.idEmpresa, oOrden.idOrdenConversion);

                //Revisando si la cabecera tiene detalle
                if (oOrden.ListaConverDetalle != null && oOrden.ListaConverDetalle.Count > 0)
                {
                    //Recorriendo el detalle para saber si ya se generó el Ingreso.
                    foreach (OrdenConversionDetalleE item in oOrden.ListaConverDetalle)
                    {
                        if (item.indGenerada)
                        {
                            Global.MensajeComunicacion("Esta Orden de Conversión ya ha sido ingresada al almacén.");
                            return;
                        }
                    }

                    if (Global.MensajeConfirmacion("Generar el Ingreso por Conversion al almacén...") == DialogResult.Yes)
                    {
                        oOrden = AgenteAlmacen.Proxy.GeneraIngresoAlmacenPorConversion(oOrden, VariablesLocales.SesionUsuario.Credencial);

                        if (oOrden != null)
                        {
                            Global.MensajeComunicacion("Se generó el Ingreso al almacén correctamente.");
                        }
                        else
                        {
                            Global.MensajeComunicacion("No se pudo generar el ingreso al almacén.");
                        }

                        Buscar();
                    } 
                }
                else
                {
                    Global.MensajeComunicacion("Esta Orden de Conversión no tiene detalle para generar los ingresos.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmEliminarIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                //Obteniendo la cabecera de la Orden de Conversion.
                OrdenConversionE oOrden = (OrdenConversionE)bsOrdenConversion.Current;
                //Obteniendo el detalle
                oOrden.ListaConverDetalle = AgenteAlmacen.Proxy.ListarOrdenConversionDetalle(oOrden.idEmpresa, oOrden.idOrdenConversion);

                //Revisando si la cabecera tiene detalle
                if (oOrden.ListaConverDetalle != null && oOrden.ListaConverDetalle.Count > 0)
                {
                    //Recorriendo el detalle para saber si ya se generó el Ingreso.
                    foreach (OrdenConversionDetalleE item in oOrden.ListaConverDetalle)
                    {
                        if (!item.indGenerada)
                        {
                            Global.MensajeComunicacion("Esta Orden de Conversión no ha sido ingresado al almacén.");
                            return;
                        }
                    }

                    //Anulando los movimientos en el almacén...
                    if (Global.MensajeConfirmacion("Desea eliminar los Ingresos del Almacen.") == DialogResult.Yes)
                    {
                        oOrden = AgenteAlmacen.Proxy.AnularIngAlmacenPorConversion(oOrden, VariablesLocales.SesionUsuario.Credencial);

                        if (oOrden != null)
                        {
                            Global.MensajeComunicacion("Se anularon los Movimientos de Ingresos al Almacén");
                        }
                        else
                        {
                            Global.MensajeComunicacion("No se pudo anular los ingreso al almacén.");
                        }

                        Buscar();
                    } 
                }
                else
                {
                    Global.MensajeComunicacion("Esta Orden de Conversión no tiene detalle para anular los ingreso.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtNomArt_TextChanged(object sender, EventArgs e)
        {
            txtArt.Tag = 0;
            txtArt.Text = string.Empty;
        }

        private void txtArt_TextChanged(object sender, EventArgs e)
        {
            txtArt.Tag = 0;
            txtNomArt.Text = string.Empty;
        }

        private void txtNomArt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNomArt.Text.Trim()) && string.IsNullOrEmpty(txtArt.Text.Trim()))
                {
                    txtArt.TextChanged -= txtArt_TextChanged;
                    txtNomArt.TextChanged -= txtNomArt_TextChanged;

                    List<ArticuloServE> oListaArticulo = AgenteMaestros.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                    "", txtNomArt.Text.Trim());
                    if (oListaArticulo.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulo);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            txtArt.Tag = Convert.ToInt32(oFrm.oArticulo.idArticulo);
                            txtArt.Text = oFrm.oArticulo.codArticulo;
                            txtNomArt.Text = oFrm.oArticulo.nomArticulo;
                        }
                    }
                    else if (oListaArticulo.Count == 1)
                    {
                        txtArt.Tag = Convert.ToInt32(oListaArticulo[0].idArticulo);
                        txtArt.Text = oListaArticulo[0].codArticulo;
                        txtNomArt.Text = oListaArticulo[0].nomArticulo;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                        txtArt.Tag = 0;
                        txtArt.Text = string.Empty;
                        txtNomArt.Text = string.Empty;
                        txtNomArt.Focus();
                    }

                    txtArt.TextChanged += txtArt_TextChanged;
                    txtNomArt.TextChanged += txtNomArt_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsOrdenConversion_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                LblRegistros.Text = "Registros " + bsOrdenConversion.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
