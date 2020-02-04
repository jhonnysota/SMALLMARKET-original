using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Maestros;
using Entidades.Generales;
using ClienteWinForm;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class FrmListadoKardexValorizado : FrmMantenimientoBase
    {

        #region Constructor
        public FrmListadoKardexValorizado()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarTipoArticulo();
            
        }
        #endregion 

        #region Variables
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<KardexValorizadoE> ListaKardexValorizado = null;
        //List<KardexValorizadoE> ListaKardexValorizado2 = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String AdquirirRutaGeneral = String.Empty;
        Int32 tipoProceso = 0;
        Int32 idArticulo = 0;
        Int16 Formato = 1;

        #endregion

        #region Procedimiento de Usuario

        private void LlenarTipoArticulo()
        {
            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Todos });

            ComboHelper.LlenarCombos(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");

            cboTipoAlmacen.DataSource = null;
            List<ParTabla> ListaOperacion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaOperacion.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaOperacion orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        private void ExportarExcel(String Ruta2)
        {
            Boolean CtrlTotal = true;
            string TituloGeneral;
            string NombrePestaña = "Durante el " + dtpInicio.Value.ToString("yyyy");

            if (CtrlTotal)
            {
                TituloGeneral = "REGISTROS DE INVENTARIO PERMANENTE- DETALLE DEL INVENTARIO VALORIZADO";
            }
            else
            {
                TituloGeneral = "REGISTROS DE INVENTARIO PERMANENTE- DETALLE DEL INVENTARIO";
            }

            if (File.Exists(Ruta2))
            {
                File.Delete(Ruta2);
            }

            FileInfo newFile = new FileInfo(Ruta2);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = CtrlTotal == true ? 23 : 17;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(117, 113, 113));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(174, 170, 170));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    //PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "COD.ART.";
                    oHoja.Cells[InicioLinea, 2].Value = "ARTICULO";
                    oHoja.Cells[InicioLinea, 3].Value = "FEC.OPE.";
                    oHoja.Cells[InicioLinea, 4].Value = "FEC.DOC.";
                    oHoja.Cells[InicioLinea, 5].Value = "TIP.DOC.";
                    oHoja.Cells[InicioLinea, 6].Value = "SERIE";
                    oHoja.Cells[InicioLinea, 7].Value = "NUMERO";
                    oHoja.Cells[InicioLinea, 8].Value = "TIP.REF.";
                    oHoja.Cells[InicioLinea, 9].Value = "SERIE REF.";
                    oHoja.Cells[InicioLinea, 10].Value = "NUMERO REF.";
                    oHoja.Cells[InicioLinea, 11].Value = "COD.OPERAC.";
                    oHoja.Cells[InicioLinea, 12].Value = "COD.SUNAT";
                    oHoja.Cells[InicioLinea, 13].Value = "NOMBRE OPERACION";

                    if (CtrlTotal)
                    {
                        oHoja.Cells[InicioLinea, 14].Value = "CANT.ENTRADA";
                        oHoja.Cells[InicioLinea, 15].Value = "COST.UNIT.ENTRADA";
                        oHoja.Cells[InicioLinea, 16].Value = "TOTAL ENTRADA"; 
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 14].Value = "CANT.ENTRADA";
                    }

                    if (CtrlTotal)
                    {
                        oHoja.Cells[InicioLinea, 17].Value = "CANT.SALIDA";
                        oHoja.Cells[InicioLinea, 18].Value = "COST.UNIT. SALIDA";
                        oHoja.Cells[InicioLinea, 19].Value = "TOTAL SALIDA"; 
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 15].Value = "CANT.SALIDA";
                    }

                    if (CtrlTotal)
                    {
                        oHoja.Cells[InicioLinea, 20].Value = "CANT.FINAL";
                        oHoja.Cells[InicioLinea, 21].Value = "COST.UNIT.FINAL";
                        oHoja.Cells[InicioLinea, 22].Value = "TOTAL FINAL";
                        oHoja.Cells[InicioLinea, 23].Value = "ALMACEN";
                    }
                    else
                    {
                        oHoja.Cells[InicioLinea, 16].Value = "CANT.FINAL";
                        oHoja.Cells[InicioLinea, 17].Value = "ALMACEN";
                    }

                    oHoja.Row(4).Height = 21;

                    for (int i = 1; i <= TotColumnas; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(208, 206, 206));
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Detalle

                    foreach (KardexValorizadoE item in ListaKardexValorizado)
                    {
                        if (item.NomOperacion.Substring(0, 7) != "TOTALES")
                        {
                            // Si tiene Saldo Anterior se Muestra el Movimiento de Apertura.
                            if (item.SaldoAnterior != null)
                            {
                                if (item.SaldoAnterior.CantEntrada != 0)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                                    oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    oHoja.Cells[InicioLinea, 2].Value = item.nomArticulo;
                                    oHoja.Cells[InicioLinea, 3].Value = item.SaldoAnterior.fecProceso;
                                    oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                                    oHoja.Cells[InicioLinea, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    oHoja.Cells[InicioLinea, 4].Value = item.SaldoAnterior.Fecha;
                                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "dd/MM/yyyy";
                                    oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    oHoja.Cells[InicioLinea, 5].Value = item.SaldoAnterior.Documento;
                                    oHoja.Cells[InicioLinea, 6].Value = item.SaldoAnterior.Serie;
                                    oHoja.Cells[InicioLinea, 7].Value = item.SaldoAnterior.Numero;
                                    oHoja.Cells[InicioLinea, 8].Value = item.SaldoAnterior.idDocumentoRef;
                                    oHoja.Cells[InicioLinea, 9].Value = item.SaldoAnterior.serDocumentoRef;
                                    oHoja.Cells[InicioLinea, 10].Value = item.SaldoAnterior.numDocumentoRef;

                                    if (item.SaldoAnterior.Operacion == 0)
                                    {
                                        oHoja.Cells[InicioLinea, 11].Value = String.Empty;
                                    }
                                    else
                                    {
                                        oHoja.Cells[InicioLinea, 11].Value = item.SaldoAnterior.Operacion;
                                    }

                                    oHoja.Cells[InicioLinea, 12].Value = item.SaldoAnterior.CodSunat;
                                    oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    oHoja.Cells[InicioLinea, 13].Value = item.SaldoAnterior.NomOperacion;

                                    if (CtrlTotal)
                                    {
                                        oHoja.Cells[InicioLinea, 14].Value = item.SaldoAnterior.CantEntrada;
                                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.0000000";
                                        oHoja.Cells[InicioLinea, 15].Value = item.SaldoAnterior.CostEntrada;
                                        oHoja.Cells[InicioLinea, 16].Value = item.SaldoAnterior.TotalEntrada;
                                    }
                                    else
                                    {
                                        oHoja.Cells[InicioLinea, 14].Value = item.SaldoAnterior.CantEntrada;
                                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.0000000";
                                    }

                                    if (CtrlTotal)
                                    {
                                        oHoja.Cells[InicioLinea, 17].Value = item.SaldoAnterior.CantSalida;
                                        oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.0000000";
                                        oHoja.Cells[InicioLinea, 18].Value = item.SaldoAnterior.CostSalida;
                                        oHoja.Cells[InicioLinea, 19].Value = item.SaldoAnterior.TotalSalida;
                                    }
                                    else
                                    {
                                        oHoja.Cells[InicioLinea, 15].Value = item.SaldoAnterior.CantSalida;
                                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.0000000";
                                    }

                                    if (CtrlTotal)
                                    {
                                        oHoja.Cells[InicioLinea, 20].Value = item.SaldoAnterior.CantFinal;
                                        oHoja.Cells[InicioLinea, 21].Value = item.SaldoAnterior.CostFinal;
                                        oHoja.Cells[InicioLinea, 22].Value = item.SaldoAnterior.TotalFinal;
                                        oHoja.Cells[InicioLinea, 23].Value = item.SaldoAnterior.desCortaAlmacen;
                                    }
                                    else
                                    {
                                        oHoja.Cells[InicioLinea, 16].Value = item.SaldoAnterior.CantFinal;
                                        oHoja.Cells[InicioLinea, 17].Value = item.SaldoAnterior.desCortaAlmacen;
                                        oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    }

                                    for (int i = 1; i <= TotColumnas; i++)
                                    {
                                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                                        if (i >= 14 && i <= TotColumnas && i != 17 && i != 23)
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.0000000";
                                            oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                        }
                                    }

                                    InicioLinea++;
                                }
                            }

                            if (item.codArticulo == "X")
                            {
                                oHoja.Cells[InicioLinea, 1].Value = String.Empty;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.codArticulo;
                                oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            oHoja.Cells[InicioLinea, 2].Value = item.nomArticulo;
                            oHoja.Cells[InicioLinea, 3].Value = item.fecProceso;
                            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 4].Value = item.Fecha;
                            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "dd/MM/yyyy";
                            oHoja.Cells[InicioLinea, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 5].Value = item.Documento;
                            oHoja.Cells[InicioLinea, 6].Value = item.Serie;
                            oHoja.Cells[InicioLinea, 7].Value = item.Numero;
                            oHoja.Cells[InicioLinea, 8].Value = item.idDocumentoRef;
                            oHoja.Cells[InicioLinea, 9].Value = item.serDocumentoRef;
                            oHoja.Cells[InicioLinea, 10].Value = item.numDocumentoRef;

                            if (item.Operacion == 0)
                            {
                                oHoja.Cells[InicioLinea, 11].Value = String.Empty;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 11].Value = item.Operacion;
                            }

                            oHoja.Cells[InicioLinea, 12].Value = item.CodSunat;
                            oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 13].Value = item.NomOperacion;

                            oHoja.Cells[InicioLinea, 14].Value = item.CantEntrada;
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.0000000";
                            oHoja.Cells[InicioLinea, 15].Value = item.CostEntrada;
                            oHoja.Cells[InicioLinea, 16].Value = item.TotalEntrada;

                            oHoja.Cells[InicioLinea, 17].Value = item.CantSalida;
                            oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.0000000";
                            oHoja.Cells[InicioLinea, 18].Value = item.CostSalida;
                            oHoja.Cells[InicioLinea, 19].Value = item.TotalSalida;

                            oHoja.Cells[InicioLinea, 20].Value = item.CantFinal;
                            oHoja.Cells[InicioLinea, 21].Value = item.CostFinal;
                            oHoja.Cells[InicioLinea, 22].Value = item.TotalFinal;
                            oHoja.Cells[InicioLinea, 23].Value = item.desCortaAlmacen;

                            for (int i = 1; i <= TotColumnas; i++)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                                if (i >= 14 && i <= TotColumnas && i != 17 && i != 23)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.0000000";
                                    oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                }
                            }

                            InicioLinea++;
                        }
                    }

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();

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
                    oHoja.Workbook.Properties.Category = "Módulo de Almacén";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();

                    #endregion
                }
            }
        }

        private void ExportarExcel2(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String Subtitulo = String.Empty;
            Boolean CtrlTotal = true;

            if (CtrlTotal)
            {
                TituloGeneral = "REGISTROS DE INVENTARIO PERMANENTE - DETALLE DEL INVENTARIO VALORIZADO";
            }
            else
            {
                TituloGeneral = "REGISTROS DE INVENTARIO PERMANENTE - DETALLE DEL INVENTARIO";
            }

            Subtitulo = "Durante el Periodo " + dtpInicio.Value.ToString("MM/yyyy") + " al " + dtpFinal.Value.ToString("MM/yyyy");
            
            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Kardex");

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = CtrlTotal == true ? 20 : 14;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 12, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    }

                    oHoja.Cells["A2"].Value = Subtitulo;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    }

                    #endregion

                    #region Detalle

                    Int32 idArt = Variables.Cero;
                    String desArticulo = string.Empty;
                    String TipoSalida = String.Empty;

                    for (int i = 0; i < ListaKardexValorizado.Count; i++)
                    {
                        if (idArt != ListaKardexValorizado[i].Articulo)
                        {
                            #region Subtitulos

                            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                            {
                                desArticulo = ListaKardexValorizado[i].codArticulo + "-" + ListaKardexValorizado[i].Articulo + " - " + ListaKardexValorizado[i].DesArticulo;
                            }
                            else
                            {
                                desArticulo = ListaKardexValorizado[i].codArticulo + "-" + ListaKardexValorizado[i].DesArticulo;
                            }

                            oHoja.Cells[InicioLinea, 1, InicioLinea, 3].Merge = true;
                            oHoja.Cells[InicioLinea, 1].Value = "TIPO DE EXISTENCIA:";
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                            oHoja.Cells[InicioLinea, 4, InicioLinea, 6].Merge = true;
                            oHoja.Cells[InicioLinea, 4].Value = ListaKardexValorizado[i].TipoExistencia + " " + ListaKardexValorizado[i].NomExistencia;
                            oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                            oHoja.Cells[InicioLinea, 7, InicioLinea, 8].Merge = true;
                            oHoja.Cells[InicioLinea, 7].Value = "METODO DE EVALUACION:";
                            oHoja.Cells[InicioLinea, 7].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 9, InicioLinea, TotColumnas].Merge = true;
                            oHoja.Cells[InicioLinea, 9].Value = ListaKardexValorizado[i].Metodo;
                            oHoja.Cells[InicioLinea, 9].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1, InicioLinea, 3].Merge = true;
                            oHoja.Cells[InicioLinea, 1].Value = "CODIGO DE LA EXISTENCIA:";
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 4, InicioLinea, 12].Merge = true;
                            oHoja.Cells[InicioLinea, 4].Value = desArticulo;
                            oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 1, InicioLinea, 3].Merge = true;
                            oHoja.Cells[InicioLinea, 1].Value = "UNIDAD DE MEDIDA:";
                            oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                            oHoja.Cells[InicioLinea, 4, InicioLinea, 5].Merge = true;
                            oHoja.Cells[InicioLinea, 4].Value = ListaKardexValorizado[i].UndMedida + " " + ListaKardexValorizado[i].NomMedida;
                            oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                            oHoja.Cells[InicioLinea, 6, InicioLinea, 7].Merge = true;
                            oHoja.Cells[InicioLinea, 6].Value = "UNI.MED.ENVASE:";
                            oHoja.Cells[InicioLinea, 6].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));

                            oHoja.Cells[InicioLinea, 8, InicioLinea, 9].Merge = true;
                            oHoja.Cells[InicioLinea, 8].Value = ListaKardexValorizado[i].DesUniMedEnvase;
                            oHoja.Cells[InicioLinea, 8].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

                            #endregion

                            InicioLinea++;
                            InicioLinea++;

                            #region Cabecera del detalle

                            #region Primera Linea

                            oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Merge = true;
                            oHoja.Cells[InicioLinea, 1].Value = "FEC.OP.";
                            oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 2, InicioLinea, 5].Merge = true;
                            oHoja.Cells[InicioLinea, 2].Value = "DOC. DE TRASLADO, COMPR. DE PAGO, DOC. INTERNO O SIMILAR";
                            oHoja.Cells[InicioLinea, 2, InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 6, InicioLinea, 8].Merge = true;
                            oHoja.Cells[InicioLinea, 6].Value = "DOCUMENTO REFERENCIAL";
                            oHoja.Cells[InicioLinea, 6, InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 9, InicioLinea, 10].Merge = true;
                            oHoja.Cells[InicioLinea, 9].Value = "OPERACION";
                            oHoja.Cells[InicioLinea, 9, InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);



                            if (CtrlTotal)
                            {
                                oHoja.Cells[InicioLinea, 11, InicioLinea, 13].Merge = true;
                                oHoja.Cells[InicioLinea, 11].Value = "ENTRADAS";
                                oHoja.Cells[InicioLinea, 11, InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 14, InicioLinea, 16].Merge = true;
                                oHoja.Cells[InicioLinea, 14].Value = "SALIDAS";
                                oHoja.Cells[InicioLinea, 14, InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 17, InicioLinea, 19].Merge = true;
                                oHoja.Cells[InicioLinea, 17].Value = "FINAL";
                                oHoja.Cells[InicioLinea, 17, InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 20, InicioLinea + 1, 20].Merge = true;
                                oHoja.Cells[InicioLinea, 20].Value = "ALMACEN";
                                oHoja.Cells[InicioLinea, 20, InicioLinea + 1, 20].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 11].Value = "ENTRADAS";
                                oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 12].Value = "SALIDAS";
                                oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 13].Value = "FINAL";
                                oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 14, InicioLinea + 1, 14].Merge = true;
                                oHoja.Cells[InicioLinea, 14].Value = "ALMACEN";
                                oHoja.Cells[InicioLinea, 14, InicioLinea + 1, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }

                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; 

                            #endregion

                            InicioLinea++;

                            #region Segunda Linea

                            oHoja.Cells[InicioLinea, 2].Value = "FECHA";
                            oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 3].Style.WrapText = true;
                            oHoja.Cells[InicioLinea, 3].Value = "DOCUMENTO T.DOC.";
                            oHoja.Cells[InicioLinea, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 4].Value = "SER.";
                            oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 5].Value = "NUMERO";
                            oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 6].Value = "T.D.REF.";
                            oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 7].Value = "SER.REF.";
                            oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 8].Value = "NUM.REF.";
                            oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 9].Value = "SUNAT";
                            oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 10].Style.WrapText = true;
                            oHoja.Cells[InicioLinea, 10].Value = "NOMBRE OPERACION";
                            oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                            if (CtrlTotal)
                            {
                                oHoja.Cells[InicioLinea, 11].Value = "CANTIDAD";
                                oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 12].Value = "COST.UNI.";
                                oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 13].Value = "COST.TOT.";
                                oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 14].Value = "CANTIDAD";
                                oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 15].Value = "COST.UNI.";
                                oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 16].Value = "COST.TOT.";
                                oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 17].Value = "CANTIDAD";
                                oHoja.Cells[InicioLinea, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 18].Value = "COST.UNI.";
                                oHoja.Cells[InicioLinea, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 19].Value = "COST.TOT.";
                                oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 11].Value = "CANTIDAD";
                                oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 12].Value = "CANTIDAD";
                                oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 13].Value = "CANTIDAD";
                                oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }

                            oHoja.Cells[InicioLinea, 2, InicioLinea, TotColumnas].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 2, InicioLinea, TotColumnas].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, 2, InicioLinea, TotColumnas].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                            oHoja.Cells[InicioLinea, 2, InicioLinea, TotColumnas].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            oHoja.Cells[InicioLinea, 2, InicioLinea, TotColumnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            #endregion

                            #endregion

                            InicioLinea++;

                            #region Saldos

                            oHoja.Cells[InicioLinea, 1, InicioLinea, 2].Merge = true;
                            oHoja.Cells[InicioLinea, 1, InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            oHoja.Cells[InicioLinea, 1].Value = ListaKardexValorizado[i].SaldoAnterior.fecProceso;
                            oHoja.Cells[InicioLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 3].Value = ListaKardexValorizado[i].SaldoAnterior.Documento;
                            oHoja.Cells[InicioLinea, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 4].Value = ListaKardexValorizado[i].SaldoAnterior.Serie;
                            oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 5].Value = ListaKardexValorizado[i].SaldoAnterior.Numero;
                            oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 6].Value = ListaKardexValorizado[i].SaldoAnterior.idDocumentoRef;
                            oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 7].Value = ListaKardexValorizado[i].SaldoAnterior.serDocumentoRef;
                            oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 8].Value = ListaKardexValorizado[i].SaldoAnterior.numDocumentoRef;
                            oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 9].Value = ListaKardexValorizado[i].SaldoAnterior.CodSunat;
                            oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 10].Value = ListaKardexValorizado[i].SaldoAnterior.NomOperacion;
                            oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                            if (CtrlTotal)
                            {
                                oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].SaldoAnterior.CantEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.CantEntrada.ToString("N3") : " ";
                                oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                oHoja.Cells[InicioLinea, 12].Value = ListaKardexValorizado[i].SaldoAnterior.CostEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.CostEntrada.ToString("N6") : " ";
                                oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                oHoja.Cells[InicioLinea, 13].Value = ListaKardexValorizado[i].SaldoAnterior.TotalEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.TotalEntrada.ToString("N2") : " ";
                                oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                oHoja.Cells[InicioLinea, 17].Value = ListaKardexValorizado[i].SaldoAnterior.CantFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.CantFinal.ToString("N3") : " ";
                                oHoja.Cells[InicioLinea, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                oHoja.Cells[InicioLinea, 18].Value = ListaKardexValorizado[i].SaldoAnterior.CostFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.CostFinal.ToString("N6") : " ";
                                oHoja.Cells[InicioLinea, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                oHoja.Cells[InicioLinea, 19].Value = ListaKardexValorizado[i].SaldoAnterior.TotalFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.TotalFinal.ToString("N2") : " ";
                                oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                oHoja.Cells[InicioLinea, 20].Value = ListaKardexValorizado[i].SaldoAnterior.desCortaAlmacen;
                                oHoja.Cells[InicioLinea, 20].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].SaldoAnterior.CantEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.CantEntrada.ToString("N3") : " ";
                                oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                oHoja.Cells[InicioLinea, 13].Value = ListaKardexValorizado[i].SaldoAnterior.CantFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.CantFinal.ToString("N3") : " ";
                                oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                oHoja.Cells[InicioLinea, 14].Value = ListaKardexValorizado[i].SaldoAnterior.desCortaAlmacen;
                                oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }

                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(185, 211, 238));

                            #endregion

                            InicioLinea++;
                        }

                        if (ListaKardexValorizado[i].codArticulo != "X")
                        {
                            if (ListaKardexValorizado[i].Tipo == 1)
                            {
                                TipoSalida = "C";
                            }
                            else if (ListaKardexValorizado[i].Tipo == 2)
                            {
                                TipoSalida = "V";
                            }
                            else
                            {
                                TipoSalida = "N";
                            }

                            if (ListaKardexValorizado[i].fecProceso != null)
                            {
                                oHoja.Cells[InicioLinea, 1].Value = ListaKardexValorizado[i].fecProceso;
                                oHoja.Cells[InicioLinea, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            if (ListaKardexValorizado[i].Fecha != null)
                            {
                                oHoja.Cells[InicioLinea, 2].Value = ListaKardexValorizado[i].Fecha;
                                oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            oHoja.Cells[InicioLinea, 3].Value = ListaKardexValorizado[i].Documento;
                            oHoja.Cells[InicioLinea, 4].Value = ListaKardexValorizado[i].Serie;
                            oHoja.Cells[InicioLinea, 5].Value = ListaKardexValorizado[i].Numero;
                            oHoja.Cells[InicioLinea, 6].Value = ListaKardexValorizado[i].idDocumentoRef;
                            oHoja.Cells[InicioLinea, 7].Value = ListaKardexValorizado[i].serDocumentoRef;
                            oHoja.Cells[InicioLinea, 8].Value = ListaKardexValorizado[i].numDocumentoRef;

                            if (ListaKardexValorizado[i].CodSunat == null)
                            {
                                ListaKardexValorizado[i].CodSunat = "";
                            }

                            oHoja.Cells[InicioLinea, 9].Value = ListaKardexValorizado[i].CodSunat;
                            oHoja.Cells[InicioLinea, 10].Value = ListaKardexValorizado[i].NomOperacion;

                            if (CtrlTotal)
                            {
                                //Ingresos
                                oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].CantEntrada;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 12].Value = ListaKardexValorizado[i].CostEntrada;
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.000000";
                                oHoja.Cells[InicioLinea, 13].Value = ListaKardexValorizado[i].TotalEntrada;
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                                //Salidas
                                oHoja.Cells[InicioLinea, 14].Value = ListaKardexValorizado[i].CantSalida;
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 15].Value = ListaKardexValorizado[i].CostSalida;
                                oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.000000";
                                oHoja.Cells[InicioLinea, 16].Value = ListaKardexValorizado[i].TotalSalida;
                                oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                //Totales
                                oHoja.Cells[InicioLinea, 17].Value = ListaKardexValorizado[i].CantFinal;
                                oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 18].Value = ListaKardexValorizado[i].CostFinal;
                                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.000000";
                                oHoja.Cells[InicioLinea, 19].Value = ListaKardexValorizado[i].TotalFinal;
                                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 20].Value = ListaKardexValorizado[i].desCortaAlmacen;
                            }
                            else
                            {
                                //Ingresos
                                oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].CantEntrada;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.000";
                                //Salidas
                                oHoja.Cells[InicioLinea, 12].Value = ListaKardexValorizado[i].CantSalida;
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.000";
                                //Totales
                                oHoja.Cells[InicioLinea, 13].Value = ListaKardexValorizado[i].CantFinal;
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 14].Value = ListaKardexValorizado[i].desCortaAlmacen;
                            }

                            for (int z = 1; z <= TotColumnas; z++)
                            {
                                oHoja.Cells[InicioLinea, z].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
                                oHoja.Cells[InicioLinea, z].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                                if (TipoSalida == "V")
                                {
                                    if (z >= 10)
                                    {
                                        oHoja.Cells[InicioLinea, z].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, z].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(207, 228, 194));//Verde claro 
                                    }
                                }

                                if (TipoSalida == "C")
                                {
                                    oHoja.Cells[InicioLinea, z].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, z].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 204, 112));//Amarillo
                                }
                            }
                        }
                        else
                        {
                            oHoja.Row(InicioLinea).Height = 10;

                            //Empezando con una linea en blanco
                            InicioLinea++;

                            oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                            oHoja.Cells[InicioLinea, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, 10].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                            oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            oHoja.Cells[InicioLinea, 10].Value = ListaKardexValorizado[i].NomOperacion;
                            oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            if (CtrlTotal)
                            {
                                oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                                oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].CantEntrada;

                                oHoja.Cells[InicioLinea, 14].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                                oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 14].Value = ListaKardexValorizado[i].CantSalida;

                                oHoja.Cells[InicioLinea, 17].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, 17].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, 17].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                                oHoja.Cells[InicioLinea, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 17].Value = ListaKardexValorizado[i].CantFinal;

                                oHoja.Cells[InicioLinea, 18].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, 18].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, 18].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                                oHoja.Cells[InicioLinea, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.000000";
                                oHoja.Cells[InicioLinea, 18].Value = ListaKardexValorizado[i].CostFinal;

                                oHoja.Cells[InicioLinea, 19].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                                oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 19].Value = ListaKardexValorizado[i].TotalFinal; 
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 11].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                                oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].CantEntrada;

                                oHoja.Cells[InicioLinea, 12].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                                oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 12].Value = ListaKardexValorizado[i].CantSalida;

                                oHoja.Cells[InicioLinea, 13].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
                                oHoja.Cells[InicioLinea, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                oHoja.Cells[InicioLinea, 13].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
                                oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.000";
                                oHoja.Cells[InicioLinea, 13].Value = ListaKardexValorizado[i].CantFinal;
                            }

                            //Empezando con una linea en blanco
                            InicioLinea++;
                            oHoja.Row(InicioLinea).Height = 10;
                        }

                        idArt = ListaKardexValorizado[i].Articulo;
                        InicioLinea++;
                    }

                    ////Linea en blanco
                    InicioLinea++;

                    if (CtrlTotal)
                    {
                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 17, InicioLinea, 18])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 11, FontStyle.Bold));
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                            Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        oHoja.Cells[InicioLinea, 17].Value = "TOTAL COSTO >>>";
                        oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.000";
                        oHoja.Cells[InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 19].Value = Convert.ToDecimal((from x in ListaKardexValorizado
                                                                                where x.codArticulo == "X"
                                                                                select x.TotalFinal).Sum()); 
                    }

                    #endregion

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns();

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Kárdex Oficial";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Módulo de Almacén";
                    oHoja.Workbook.Properties.Comments = Subtitulo;

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

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                string Inicio = dtpInicio.Value.ToString("yyyyMMdd");
                string Fin = dtpFinal.Value.ToString("yyyyMMdd");
                bskardexValorizado.DataSource = ListaKardexValorizado = AgenteAlmacen.Proxy.ListarKardexValorizado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboAlmacen.SelectedValue), Inicio, Fin);
                bskardexValorizado.ResetBindings(false);
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
                if (ListaKardexValorizado != null && ListaKardexValorizado.Count > 0)
                {
                    Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
                    Guid Aleatorio = Guid.NewGuid();
                    String NombreReporte = "Kardex Valorizado " + Aleatorio.ToString();
                    String Extension = ".pdf";
                    RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

                    //Creando el directorio si existe...
                    if (!Directory.Exists(RutaGeneral))
                    {
                        Directory.CreateDirectory(RutaGeneral);
                    }

                    docPdf.AddCreationDate();
                    docPdf.AddAuthor("AMAZONTIC SAC");
                    docPdf.AddCreator("AMAZONTIC SAC");

                    if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
                    {
                        String TituloGeneral = String.Empty;
                        BaseColor colDetalle = BaseColor.LIGHT_GRAY;
                        BaseColor colDetalle2 = BaseColor.GRAY;
                        BaseColor ColorCom = new BaseColor(255, 204, 112); //Para las compras - Naranja Amarillo
                        BaseColor ColorVen = new BaseColor(207, 228, 194); //Para las ventas - Verde Claro
                        BaseColor ColorSaldo = new BaseColor(185, 211, 238); //Celeste - para el saldo inicial

                        //Para la creacion del archivo pdf
                        RutaGeneral += NombreReporte + Extension;

                        if (File.Exists(RutaGeneral))
                        {
                            File.Delete(RutaGeneral);
                        }

                        using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                            oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                            if (docPdf.IsOpen())
                            {
                                docPdf.CloseDocument();
                            }

                            int Columnas = 0;// 19;
                            float[] AnchosCol = null;
                            string tit = string.Empty;
                            //Boolean CtrlTotal = true;

                            //if (CtrlTotal)
                            //{
                            tit = "REGISTROS DE INVENTARIO PERMANENTE - DETALLE DEL INVENTARIO VALORIZADO";
                            Columnas = 20;
                            AnchosCol = new float[] { 0.002f, 0.002f, 0.002f, 0.002f, 0.003f, 0.002f, 0.002f, 0.003f, 0.0015f, 0.0065f, 0.0025f, 0.0030f, 0.0025f, 0.0025f, 0.0030f, 0.0025f, 0.0025f, 0.0030f, 0.0025f, 0.0025f };
                            //}
                            //else
                            //{
                            //    tit = "REGISTROS DE INVENTARIO PERMANENTE - DETALLE DEL INVENTARIO";
                            //    Columnas = 14;
                            //    AnchosCol = new float[] { 0.002f, 0.002f, 0.002f, 0.002f, 0.003f, 0.002f, 0.002f, 0.003f, 0.0015f, 0.0065f, 0.0025f, 0.0025f, 0.0025f, 0.0025f };
                            //}

                            #region Detalle

                            oPdfw.PageEvent = new PagRegInicioKardexValorizado2
                            {
                                Periodo = dtpInicio.Value.Date.ToString("MM/yyyy") + " al " + dtpFinal.Value.Date.ToString("MM/yyyy"),
                                Titulo = tit.Trim()
                            };

                            docPdf.Open();

                            PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
                            {
                                WidthPercentage = 100
                            };

                            TablaCabDetalle.SetWidths(AnchosCol);
                            Int32 idArt = Variables.Cero;
                            String desArticulo = String.Empty;
                            String TipoSalida = String.Empty;
                            Decimal CostTotal1 = 0, CostTotal2 = 0;

                            for (int i = 0; i < ListaKardexValorizado.Count; i++)
                            {
                                if (idArt != ListaKardexValorizado[i].Articulo)
                                {
                                    if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                                    {
                                        desArticulo = ListaKardexValorizado[i].codArticulo + "-" + ListaKardexValorizado[i].Articulo + " - " + ListaKardexValorizado[i].nomArticulo;
                                    }
                                    else
                                    {
                                        desArticulo = ListaKardexValorizado[i].codArticulo + "-" + ListaKardexValorizado[i].nomArticulo;
                                    }

                                    //Linea en blanco
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 4.25f), 1, 1, "S" + Columnas.ToString()));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIPO DE EXISTENCIA:", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, -1, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].TipoExistencia + " " + ListaKardexValorizado[i].NomExistencia, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("METODO DE EVALUACION: ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].Metodo, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S" + (Columnas - 9).ToString()));
                                    TablaCabDetalle.CompleteRow(); //Fila completada

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO DE LA EXISTENCIA:", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, -1, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(desArticulo, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S" + (Columnas - 3).ToString()));
                                    TablaCabDetalle.CompleteRow(); //Fila completada

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNIDAD DE MEDIDA:", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, -1, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].UndMedida + " " + ListaKardexValorizado[i].NomMedida, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S2"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNI.MED.ENVASE: ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S2"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].DesUniMedEnvase, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S2"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNI.MED.PRESENTACION: ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].DesUniMedPres, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONTENIDO: ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S2"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S7"));
                                    //}
                                    //else
                                    //{
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TIPO DE EXISTENCIA:", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, -1, "S2"));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].TipoExistencia + " " + ListaKardexValorizado[i].NomExistencia, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S3"));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("METODO DE EVALUACION:  ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S3"));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].Metodo, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S" + (Columnas - 8).ToString()));
                                    //    TablaCabDetalle.CompleteRow(); //Fila completada

                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CODIGO DE LA EXISTENCIA:", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, -1, "S2"));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(desArticulo, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S" + (Columnas - 2).ToString()));
                                    //    TablaCabDetalle.CompleteRow(); //Fila completada

                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNIDAD DE MEDIDA: ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, -1, "S2"));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].UndMedida + " " + ListaKardexValorizado[i].NomMedida, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S2"));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNI.MED.ENVASE: ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].DesUniMedEnvase, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S2"));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("UNI.MED.PRESENTACION: ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2, "S2"));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].DesUniMedPres, null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CONTENIDO: ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                    //    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, -1, "S3"));
                                    //}
                                    
                                    TablaCabDetalle.CompleteRow(); //Fila completada

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 1, 1, "S" + Columnas.ToString()));

                                    //Primera Linea de la Cabecera
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FEC.OP.", colDetalle2, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DOC. DE TRASLADO, COMPR. DE PAGO, DOC. INTERNO O SIMILAR", colDetalle2, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S4"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DOCUMENTO REFERENCIAL", colDetalle2, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("OPERACION", colDetalle2, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ENTRADAS", colDetalle2, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SALIDAS", colDetalle2, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FINAL", colDetalle2, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S3"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("ALMACEN", colDetalle2, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
                                    TablaCabDetalle.CompleteRow();

                                    //Segunda Linea de la Cabecera
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("FECHA", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.DOC.", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SER", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUMERO", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("T.D.REF", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SER.REF", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NUM.REF", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("SUNAT", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("NOMBRE OPERACION", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANTIDAD", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COST.UNI.", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COST.TOTAL", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    //}

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANTIDAD", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COST.UNI.", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COST.TOTAL", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    //}

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("CANTIDAD", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COST.UNI.", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("COST.TOTAL", colDetalle, "S", null, FontFactory.GetFont("Arial", 5.25f), 5, 1));
                                    //}

                                    TablaCabDetalle.CompleteRow();

                                    if (ListaKardexValorizado[i].SaldoAnterior.CantEntrada != 0)
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.fecProceso, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.Documento, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.Serie, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.Numero, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.idDocumentoRef, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.serDocumentoRef, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.numDocumentoRef, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.CodSunat, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.NomOperacion, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((ListaKardexValorizado[i].SaldoAnterior.CantEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.CantEntrada.ToString("N3") : " "), ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));

                                        //if (CtrlTotal)
                                        //{
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((ListaKardexValorizado[i].SaldoAnterior.CostEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.CostEntrada.ToString("N6") : " "), ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((ListaKardexValorizado[i].SaldoAnterior.TotalEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.TotalEntrada.ToString("N2") : " "), ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                        //}

                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));

                                        //if (CtrlTotal)
                                        //{
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                        //}

                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((ListaKardexValorizado[i].SaldoAnterior.CantFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.CantFinal.ToString("N3") : " "), ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));

                                        //if (CtrlTotal)
                                        //{
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((ListaKardexValorizado[i].SaldoAnterior.CostFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.CostFinal.ToString("N6") : " "), ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((ListaKardexValorizado[i].SaldoAnterior.TotalFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.TotalFinal.ToString("N2") : " "), ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                                        //}

                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].SaldoAnterior.desCortaAlmacen, ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD)));

                                        TablaCabDetalle.CompleteRow();
                                    }
                                }

                                if (ListaKardexValorizado[i].codArticulo != "X")
                                {
                                    if (ListaKardexValorizado[i].Tipo == 1)
                                    {
                                        TipoSalida = "C";
                                    }
                                    else if (ListaKardexValorizado[i].Tipo == 2)
                                    {
                                        TipoSalida = "V";
                                    }
                                    else
                                    {
                                        TipoSalida = "N";
                                    }

                                    if (!string.IsNullOrWhiteSpace(ListaKardexValorizado[i].fecProceso))
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(ListaKardexValorizado[i].fecProceso).ToString("dd/MM/yy"), (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                    }
                                    else
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                    }

                                    if (!string.IsNullOrWhiteSpace(ListaKardexValorizado[i].Fecha))
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(Convert.ToDateTime(ListaKardexValorizado[i].Fecha).ToString("dd/MM/yy"), (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                    }
                                    else
                                    {
                                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f)));
                                    }

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].Documento, (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].Serie.ToString(), (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].Numero.ToString(), (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].idDocumentoRef, (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].serDocumentoRef.ToString(), (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].numDocumentoRef.ToString(), (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));

                                    if (ListaKardexValorizado[i].CodSunat == null)
                                    {
                                        ListaKardexValorizado[i].CodSunat = "";
                                    }

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CodSunat, (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].NomOperacion, (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));
                                    
                                    //Ingresos
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CantEntrada.ToString("N3"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f, (ListaKardexValorizado[i].CantEntrada > 0 ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)), 1, 2));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CostEntrada.ToString("N6"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].TotalEntrada.ToString("N2"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    //}

                                    //Salidas
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CantSalida.ToString("N3"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f, (ListaKardexValorizado[i].CantSalida > 0 ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)), 1, 2));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CostSalida.ToString("N6"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].TotalSalida.ToString("N2"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    //}

                                    //Totales
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CantFinal.ToString("N3"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CostFinal.ToString("N6"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].TotalFinal.ToString("N2"), (TipoSalida == "C" ? ColorCom : (TipoSalida == "V" ? ColorVen : null)), "S", null, FontFactory.GetFont("Arial", 6.25f), 1, 2));
                                    //}
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].desCortaAlmacen, (TipoSalida == "C" ? ColorCom : null), "S", null, FontFactory.GetFont("Arial", 6.25f), -1, -1));

                                    CostTotal1 += ListaKardexValorizado[i].TotalEntrada;
                                    CostTotal2 += ListaKardexValorizado[i].TotalSalida;
                                }
                                else
                                {
                                    //Empezando con una linea en blanco
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), -1, -1, "S" + Columnas.ToString(), "N", 0f, 0f));
                                    TablaCabDetalle.CompleteRow();

                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S9"));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].NomOperacion, colDetalle, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1));

                                    //Ingresos
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((ListaKardexValorizado[i].CantEntrada).ToString("N3"), colDetalle, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CostTotal1.ToString("N3"), colDetalle, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));
                                    //}

                                    //Salidas
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CantSalida.ToString("N3"), colDetalle, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CostTotal2.ToString("N3"), colDetalle, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));
                                    //}

                                    //Totales
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CantFinal.ToString("N3"), colDetalle, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));

                                    //if (CtrlTotal)
                                    //{
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].CostFinal.ToString("N6"), colDetalle, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(ListaKardexValorizado[i].TotalFinal.ToString("N2"), colDetalle, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 2));
                                    //}
                                    TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 2.25f), -1, -1, "S" + Columnas.ToString(), "N", 0f, 0f));

                                    CostTotal1 = 0;
                                    CostTotal2 = 0;
                                }

                                TablaCabDetalle.CompleteRow();

                                idArt = ListaKardexValorizado[i].Articulo;
                            }

                            //Linea en blanco
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 5.25f), -1, -1, "S" + Columnas.ToString(), "N", 0f, 0f));
                            TablaCabDetalle.CompleteRow();

                            //if (CtrlTotal)
                            //{
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1, "S16"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("TOTAL COSTO >>>", ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((from x in ListaKardexValorizado
                                                                             where x.codArticulo == "X"
                                                                             select x.TotalFinal).Sum().ToString("N2"), ColorSaldo, "S", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f), -1, -1));
                            TablaCabDetalle.CompleteRow();
                            //}

                            docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF                                           

                            #endregion

                            // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                            //establecer la acción abierta para nuestro objeto escritor
                            oPdfw.SetOpenAction(action);

                            //Liberando memoria
                            oPdfw.Flush();
                            docPdf.Close(); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (cboTipoAlmacen.SelectedIndex == 0)
            {
                Global.MensajeComunicacion("Debe Seleccionar un Tipo de Almacén");
                return false;
            }

            //if (cboAlmacen.SelectedIndex == 0)
            //{
            //    Global.MensajeComunicacion("Debe Seleccionar un Tipo de Almacén");
            //    return false;
            //}

            if (rbUno.Checked && idArticulo == 0)
            {
                Global.MensajeComunicacion("Debe escoger un articulo.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Exportar()
        {
            try
            {
                if (ListaKardexValorizado == null || ListaKardexValorizado.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                if (Formato == 1)
                {
                    AdquirirRutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en ", "Kárdex Valorizado Listado", "Archivos Excel (*.xlsx)|*.xlsx");
                }
                else
                {
                    AdquirirRutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en ", "Kárdex Valorizado", "Archivos Excel (*.xlsx)|*.xlsx");
                }

                if (!String.IsNullOrEmpty(AdquirirRutaGeneral))
                {
                    tipoProceso = 2;
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

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string Inicio = dtpInicio.Value.ToString("yyyyMMdd");
                string Fin = dtpFinal.Value.ToString("yyyyMMdd");
                Int32 idTipoArticulo = Convert.ToInt32(cboTipoAlmacen.SelectedValue);

                ListaKardexValorizado = AgenteAlmacen.Proxy.ListarKardexValorizadoFilt(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboAlmacen.SelectedValue), Inicio, Fin, idArticulo, Variables.Soles, idTipoArticulo);

                if (tipoProceso == 1)
                {
                    Imprimir();
                }
                else
                {
                    if (Formato == 1)
                    {
                        ExportarExcel(AdquirirRutaGeneral);
                    }
                    else
                    {
                        ExportarExcel2(AdquirirRutaGeneral);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btObtener.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                if (tipoProceso == 1)
                {                    
                    if (ListaKardexValorizado.Count == 0)
                    {
                        if (rbUno.Checked)
                        {
                            Global.MensajeComunicacion("Este articulo no tiene movimientos.");
                        }
                        else
                        {
                            Global.MensajeComunicacion("No existen movimientos en las fechas escogidas.");
                        }
                    }

                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Kardex Valorizado Exportado...");
                }
            }
        }

        private void FrmListadoKardexValorizado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        #endregion

        #region Eventos

        private void FrmListadoKardexValorizado_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            cboAlmacen.Enabled = false;
            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            dtpFinal.Value = Convert.ToDateTime(FechasHelper.ObtenerUltimoDia(dtpInicio.Value));
        }

        private void btObtener_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGrabacion())
                {
                    return;
                }

                tipoProceso = 1;

                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btObtener.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btObtener.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked)
            {
                idArticulo = 0;
                txtArt.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtNomArt.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else
            {
                txtArt.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txtNomArt.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txtArt.Focus();
            }
        }

        private void txtArt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtArt.Text.Trim()) && string.IsNullOrEmpty(txtNomArt.Text.Trim()))
                {
                    txtArt.TextChanged -= txtArt_TextChanged;
                    txtNomArt.TextChanged -= txtNomArt_TextChanged;

                    List<ArticuloServE> oListaArticulo = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                    txtArt.Text.Trim(), "");
                    if (oListaArticulo.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulo);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            idArticulo = oFrm.oArticulo.idArticulo;
                            txtArt.Text = oFrm.oArticulo.codArticulo;
                            txtNomArt.Text = oFrm.oArticulo.nomArticulo;
                            btObtener.Focus();
                        }
                    }
                    else if (oListaArticulo.Count == 1)
                    {
                        idArticulo = oListaArticulo[0].idArticulo;
                        txtArt.Text = oListaArticulo[0].codArticulo;
                        txtNomArt.Text = oListaArticulo[0].nomArticulo;
                        btObtener.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                        idArticulo = 0;
                        txtArt.Text = string.Empty;
                        txtNomArt.Text = string.Empty;
                        txtArt.Focus();
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

        private void txtNomArt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNomArt.Text.Trim()) && string.IsNullOrEmpty(txtArt.Text.Trim()))
                {
                    txtArt.TextChanged -= txtArt_TextChanged;
                    txtNomArt.TextChanged -= txtNomArt_TextChanged;

                    List<ArticuloServE> oListaArticulo = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                    "", txtNomArt.Text.Trim());
                    if (oListaArticulo.Count > 1)
                    {
                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulo);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            idArticulo = oFrm.oArticulo.idArticulo;
                            txtArt.Text = oFrm.oArticulo.codArticulo;
                            txtNomArt.Text = oFrm.oArticulo.nomArticulo;
                            btObtener.Focus();
                        }
                    }
                    else if (oListaArticulo.Count == 1)
                    {
                        idArticulo = oListaArticulo[0].idArticulo;
                        txtArt.Text = oListaArticulo[0].codArticulo;
                        txtNomArt.Text = oListaArticulo[0].nomArticulo;
                        btObtener.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                        idArticulo = 0;
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

        private void txtArt_TextChanged(object sender, EventArgs e)
        {
            idArticulo = 0;
            txtNomArt.Text = string.Empty;
        }

        private void txtNomArt_TextChanged(object sender, EventArgs e)
        {
            idArticulo = 0;
            txtArt.Text = string.Empty;
        }

        private void btPle_Click(object sender, EventArgs e)
        {
            #region Variables

            String Anio = Convert.ToString(dtpFinal.Value.Year);
            String Mes = String.Format("{0:00}", dtpFinal.Value.Month);
            //Int32 DiaReal = FechasHelper.ObtenerUltimoDia(VariablesLocales.FechaHoy).Day;

            #endregion Variables

            try
            {
                string NombreArchivo;
                string ConInformacion;
                if (ListaKardexValorizado == null || ListaKardexValorizado.Count == Variables.Cero)
                {
                    ConInformacion = "0";
                    NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + Anio + Mes + "00" + "13010000" + "1" + ConInformacion + "1" + "1";
                }
                else
                {
                    ConInformacion = "1";
                    NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + Anio + Mes + "00" + "13010000" + "1" + ConInformacion + "1" + "1";
                }

                string RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    //Borrando el archivo...
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        if (ListaKardexValorizado != null && ListaKardexValorizado.Count > Variables.Cero)
                        {

                            #region Variables

                            StringBuilder Linea = new StringBuilder();
                            DateTime FechaPeriodo = dtpFinal.Value.Date;
                            String AsientoContable = String.Empty;
                            String Correlativo = String.Empty;
                            Int32 Cor1 = 1;
                            String CodEstablecimientoAnexo = String.Empty;
                            String MesPer = String.Empty;
                            #endregion Variables

                            foreach (KardexValorizadoE item in ListaKardexValorizado)
                            {
                                if (item.CodSunat == "16")
                                {
                                    AsientoContable = "A";
                                }
                                else
                                {
                                    AsientoContable = "M";
                                }

                                MesPer = String.Format("{0:00}", FechaPeriodo.Month);

                                Correlativo = AsientoContable + String.Format("{0:000}", Cor1);
                                CodEstablecimientoAnexo = String.Format("{0:0000}", item.CodEstablecimiento);
                                #region Insertar Linea

                                if (item.codArticulo != "X")
                                {
                                    Linea.Append(FechaPeriodo.Year + MesPer + "00").Append("|").Append(item.Asiento).Append("|").Append(Correlativo).Append("|");
                                    Linea.Append(CodEstablecimientoAnexo).Append("|").Append("3").Append("|").Append(item.TipoExistencia).Append("|").Append(item.codArticulo).Append("||");
                                    Linea.Append(Convert.ToDateTime(item.fecProceso).ToString("d")).Append("|").Append(item.TipDoc).Append("|").Append(item.Serie).Append("|");
                                    Linea.Append(item.Numero).Append("|").Append(item.CodSunat).Append("|").Append(item.DesArticulo).Append("|").Append(item.codsunatmed).Append("|");
                                    Linea.Append("1").Append("|").Append(item.CantEntrada.ToString("#####0.00")).Append("|").Append(item.CostEntrada.ToString("#####0.00")).Append("|").Append(item.TotalEntrada.ToString("#####0.00")).Append("|").Append(item.CantSalida.ToString("#####0.00")).Append("|");
                                    Linea.Append(item.CostSalida.ToString("#####0.00")).Append("|").Append(item.TotalSalida.ToString("#####0.00")).Append("|").Append(item.CantFinal.ToString("#####0.00")).Append("|").Append(item.CostFinal.ToString("#####0.00")).Append("|").Append(item.TotalFinal.ToString("#####0.00")).Append("|").Append(item.Estado).Append("|");
                                    oSw.WriteLine(Linea.ToString());


                                    Linea.Clear();
                                    Cor1++;
                                }
                                #endregion
                            }
                        }
                    }

                    Global.MensajeComunicacion("Se ha Generado el Archivo");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            //Button btnSender = (Button)sender;
            //Point ptAbajo = new Point(0, btExportar.Height);
            //ptAbajo = btExportar.PointToScreen(ptAbajo);
            //cmsFormatos.Show(ptAbajo);
            cmsFormatos.Show(btExportar, new Point(0, btExportar.Height));
        }

        private void btExportar_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    cmsFormatos.Show(Control.MousePosition);
            //}
        }

        private void tsmFormato1_Click(object sender, EventArgs e)
        {
            try
            {
                Formato = 1;
                Exportar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmFormato2_Click(object sender, EventArgs e)
        {
            try
            {
                Formato = 2;
                Exportar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoAlmacen.SelectedIndex == 0)
            {
                cboAlmacen.Enabled = false;
                cboAlmacen.SelectedIndex = 0;
            }
            else
            {
                cboAlmacen.Enabled = true;
                cboAlmacen.DataSource = null;
                Int32 tipalm = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
                List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipalm);
                AlmacenE oItem = new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Todos };
                oListaAlmacen.Add(oItem);
                ComboHelper.LlenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
            }
        }

        #endregion

    }
}

class PagRegInicioKardexValorizado2 : PdfPageEventHelper
{
    public String Periodo { get; set; }
    public String Titulo { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        #region Variables

        BaseColor colCabDetalle = BaseColor.LIGHT_GRAY;
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

        #endregion Variables

        TituloGeneral = Titulo;
        SubTitulo = "Durante el Periodo " + Periodo;

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2)
        {
            WidthPercentage = 100
        };

        table.SetWidths(new float[] { 0.9f, 0.13f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2", "N", 1.2f, 1.2f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f, "S2"));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 1.2f, 1.2f));
        table.CompleteRow();

        document.Add(table); //Añadiendo la tabla al documento PDF
    }

}