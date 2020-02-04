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
    public partial class FrmListadoKardexValorizadoPorMes : FrmMantenimientoBase
    {

        public FrmListadoKardexValorizadoPorMes()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarTipoArticulo();
        }

        #region Variables
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<KardexValorizadoE> ListaKardexValorizado = null;

        List<KardexValorizadoE> ListaKardexValorizadoPersonas = null;
        
        List<KardexValorizadoE> ListaKardexValorizadoGroupBy = null;

        //List<KardexValorizadoE> ListaKardexValorizado2 = null;
        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String AdquirirRutaGeneral = String.Empty;
        Int32 tipoProceso = 0;
        Int32 idArticulo = 0;
        //Int16 Formato = 1;
        String TituloReporte = String.Empty;

        #endregion

        #region Procedimiento de Usuario

        private void LlenarTipoArticulo()
        {
            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            AlmacenE oItem = new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Todos };
            oListaAlmacen.Add(oItem);

            ComboHelper.LlenarCombos(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            cboMoneda.SelectedIndex = 1;

            cboTipoAlmacen.DataSource = null;
            List<ParTabla> ListaOperacion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            ListaOperacion.Add(p);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaOperacion orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

        }               

        //void ExportarExcel2(String Ruta)
        //{
        //    String TituloGeneral = String.Empty;
        //    String Subtitulo = String.Empty;

        //    TituloGeneral = "REGISTROS DE INVENTARIO PERMANENTE- DETALLE DEL INVENTARIO VALORIZADO";
        //    Subtitulo = "Durante el Periodo " + dtpInicio.Value.ToString("MM/yyyy") + " al " + dtpFinal.Value.ToString("MM/yyyy");
        //    //dtpInicio.Value.Date.ToString("MM/yyyy") + " al " + dtpFinal.Value.Date.ToString("MM/yyyy");
        //    if (File.Exists(Ruta))
        //    {
        //        File.Delete(Ruta);
        //    }

        //    FileInfo newFile = new FileInfo(Ruta);

        //    using (ExcelPackage oExcel = new ExcelPackage(newFile))
        //    {
        //        ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Kardéx");

        //        if (oHoja != null)
        //        {
        //            Int32 InicioLinea = 4;
        //            Int32 TotColumnas = 19;

        //            #region Titulos Principales

        //            // Creando Encabezado;
        //            oHoja.Cells["A1"].Value = TituloGeneral;

        //            using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
        //            {
        //                Rango.Merge = true;
        //                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 12, FontStyle.Bold));
        //                //Rango.Style.Font.Color.SetColor(Color.Black);
        //                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
        //                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            }

        //            oHoja.Cells["A2"].Value = Subtitulo;

        //            using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
        //            {
        //                Rango.Merge = true;
        //                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10, FontStyle.Bold));
        //                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
        //                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            }

        //            #endregion

        //            #region Detalle

        //            Int32 idArt = Variables.Cero;
        //            String desArticulo = string.Empty;
        //            String TipoSalida = String.Empty;

        //            for (int i = 0; i < ListaKardexValorizado.Count; i++)
        //            {
        //                if (idArt != ListaKardexValorizado[i].Articulo)
        //                {
        //                    #region Subtitulos

        //                    if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
        //                    {
        //                        desArticulo = ListaKardexValorizado[i].codArticulo + "-" + ListaKardexValorizado[i].Articulo + " - " + ListaKardexValorizado[i].DesArticulo;
        //                    }
        //                    else
        //                    {
        //                        desArticulo = ListaKardexValorizado[i].codArticulo + "-" + ListaKardexValorizado[i].DesArticulo;
        //                    }

        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 3].Merge = true;
        //                    oHoja.Cells[InicioLinea, 1].Value = "TIPO DE EXISTENCIA:";
        //                    oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
        //                    oHoja.Cells[InicioLinea, 4, InicioLinea, 12].Merge = true;
        //                    oHoja.Cells[InicioLinea, 4].Value = ListaKardexValorizado[i].TipoExistencia + " " + ListaKardexValorizado[i].NomExistencia;
        //                    oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

        //                    InicioLinea++;

        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 3].Merge = true;
        //                    oHoja.Cells[InicioLinea, 1].Value = "CODIGO DE LA EXISTENCIA:";
        //                    oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
        //                    oHoja.Cells[InicioLinea, 4, InicioLinea, 12].Merge = true;
        //                    oHoja.Cells[InicioLinea, 4].Value = desArticulo;
        //                    oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

        //                    InicioLinea++;

        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 3].Merge = true;
        //                    oHoja.Cells[InicioLinea, 1].Value = "UNIDAD DE MEDIDA:";
        //                    oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
        //                    oHoja.Cells[InicioLinea, 4, InicioLinea, 12].Merge = true;
        //                    oHoja.Cells[InicioLinea, 4].Value = ListaKardexValorizado[i].UndMedida + " " + ListaKardexValorizado[i].NomMedida;
        //                    oHoja.Cells[InicioLinea, 4].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

        //                    oHoja.Cells[InicioLinea, 13, InicioLinea, 15].Merge = true;
        //                    oHoja.Cells[InicioLinea, 13].Value = "METODO DE EVALUACION:";
        //                    oHoja.Cells[InicioLinea, 13].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
        //                    oHoja.Cells[InicioLinea, 16, InicioLinea, 18].Merge = true;
        //                    oHoja.Cells[InicioLinea, 16].Value = ListaKardexValorizado[i].Metodo;
        //                    oHoja.Cells[InicioLinea, 16].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8));

        //                    #endregion

        //                    InicioLinea++;
        //                    InicioLinea++;

        //                    #region Cabecera del detalle

        //                    #region Primera Linea

        //                    oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Merge = true;
        //                    oHoja.Cells[InicioLinea, 1].Value = "FEC.OP.";
        //                    oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 2, InicioLinea, 5].Merge = true;
        //                    oHoja.Cells[InicioLinea, 2].Value = "DOC. DE TRASLADO, COMPR. DE PAGO, DOC. INTERNO O SIMILAR";
        //                    oHoja.Cells[InicioLinea, 2, InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 6, InicioLinea, 8].Merge = true;
        //                    oHoja.Cells[InicioLinea, 6].Value = "DOCUMENTO REFERENCIAL";
        //                    oHoja.Cells[InicioLinea, 6, InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 9, InicioLinea, 10].Merge = true;
        //                    oHoja.Cells[InicioLinea, 9].Value = "OPERACION";
        //                    oHoja.Cells[InicioLinea, 9, InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 11, InicioLinea, 13].Merge = true;
        //                    oHoja.Cells[InicioLinea, 11].Value = "ENTRADAS";
        //                    oHoja.Cells[InicioLinea, 11, InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 14, InicioLinea, 16].Merge = true;
        //                    oHoja.Cells[InicioLinea, 14].Value = "SALIDAS";
        //                    oHoja.Cells[InicioLinea, 14, InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 17, InicioLinea, 19].Merge = true;
        //                    oHoja.Cells[InicioLinea, 17].Value = "FINAL";
        //                    oHoja.Cells[InicioLinea, 17, InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 19].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 19].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; 

        //                    #endregion

        //                    InicioLinea++;

        //                    #region Segunda Linea
        //                    oHoja.Cells[InicioLinea, 2].Value = "FECHA";
        //                    oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 3].Value = "DOCUMENTO T.DOC.";
        //                    oHoja.Cells[InicioLinea, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 4].Value = "SER.";
        //                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 5].Value = "NUMERO";
        //                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 6].Value = "T.D.REF.";
        //                    oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 7].Value = "SER.REF.";
        //                    oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 8].Value = "NUM.REF.";
        //                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 9].Value = "SUNAT";
        //                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 10].Value = "NOMBRE OPERACION";
        //                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 11].Value = "CANTIDAD";
        //                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 12].Value = "COST.UNI.";
        //                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 13].Value = "COST.TOTAL";
        //                    oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 14].Value = "CANTIDAD";
        //                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 15].Value = "COST.UNI.";
        //                    oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 16].Value = "COST.TOTAL";
        //                    oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 17].Value = "CANTIDAD";
        //                    oHoja.Cells[InicioLinea, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 18].Value = "COST.UNI.";
        //                    oHoja.Cells[InicioLinea, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 19].Value = "COST.TOTAL";
        //                    oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

        //                    oHoja.Cells[InicioLinea, 2, InicioLinea, 19].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
        //                    oHoja.Cells[InicioLinea, 2, InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                    oHoja.Cells[InicioLinea, 2, InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(192, 192, 192));
        //                    oHoja.Cells[InicioLinea, 2, InicioLinea, 19].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
        //                    oHoja.Cells[InicioLinea, 2, InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; 

        //                    #endregion

        //                    #endregion

        //                    InicioLinea++;

        //                    #region Saldos

        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 2].Merge = true;
        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //                    oHoja.Cells[InicioLinea, 1].Value = ListaKardexValorizado[i].SaldoAnterior.fecProceso.Value.ToString("dd/MM/yy");
        //                    oHoja.Cells[InicioLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 3].Value = ListaKardexValorizado[i].SaldoAnterior.Documento;
        //                    oHoja.Cells[InicioLinea, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 4].Value = ListaKardexValorizado[i].SaldoAnterior.Serie;
        //                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 5].Value = ListaKardexValorizado[i].SaldoAnterior.Numero;
        //                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 6].Value = ListaKardexValorizado[i].SaldoAnterior.idDocumentoRef;
        //                    oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 7].Value = ListaKardexValorizado[i].SaldoAnterior.serDocumentoRef;
        //                    oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 8].Value = ListaKardexValorizado[i].SaldoAnterior.numDocumentoRef;
        //                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 9].Value = ListaKardexValorizado[i].SaldoAnterior.CodSunat;
        //                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 10].Value = ListaKardexValorizado[i].SaldoAnterior.NomOperacion;
        //                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].SaldoAnterior.CantEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.CantEntrada.ToString("N3") : " ";
        //                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 12].Value = ListaKardexValorizado[i].SaldoAnterior.CostEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.CostEntrada.ToString("N6") : " ";
        //                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 13].Value = ListaKardexValorizado[i].SaldoAnterior.TotalEntrada != 0 ? ListaKardexValorizado[i].SaldoAnterior.TotalEntrada.ToString("N2") : " ";
        //                    oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 17].Value = ListaKardexValorizado[i].SaldoAnterior.CantFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.CantFinal.ToString("N3") : " ";
        //                    oHoja.Cells[InicioLinea, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 18].Value = ListaKardexValorizado[i].SaldoAnterior.CostFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.CostFinal.ToString("N6") : " ";
        //                    oHoja.Cells[InicioLinea, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 19].Value = ListaKardexValorizado[i].SaldoAnterior.TotalFinal != 0 ? ListaKardexValorizado[i].SaldoAnterior.TotalFinal.ToString("N2") : " ";
        //                    oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 19].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7, FontStyle.Bold));
        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                    oHoja.Cells[InicioLinea, 1, InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(185, 211, 238));
        //                    //oHoja.Cells[InicioLinea, 2, InicioLinea, 19].Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
        //                    //oHoja.Cells[InicioLinea, 2, InicioLinea, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        //                    #endregion

        //                    InicioLinea++;
        //                }

        //                if (ListaKardexValorizado[i].codArticulo != "X")
        //                {
        //                    if (ListaKardexValorizado[i].Tipo == 1)
        //                    {
        //                        TipoSalida = "C";
        //                    }
        //                    else if (ListaKardexValorizado[i].Tipo == 2)
        //                    {
        //                        TipoSalida = "V";
        //                    }
        //                    else
        //                    {
        //                        TipoSalida = "N";
        //                    }

        //                    if (ListaKardexValorizado[i].fecProceso != null)
        //                    {
        //                        oHoja.Cells[InicioLinea, 1].Value = ListaKardexValorizado[i].fecProceso.Value;
        //                        oHoja.Cells[InicioLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                        oHoja.Cells[InicioLinea, 1].Style.Numberformat.Format = "dd/MM/yyyy";
        //                        oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //                    }
        //                    else
        //                    {
        //                        oHoja.Cells[InicioLinea, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    }

        //                    if (ListaKardexValorizado[i].Fecha != null)
        //                    {
        //                        oHoja.Cells[InicioLinea, 2].Value = ListaKardexValorizado[i].Fecha.Value;
        //                        oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                        oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
        //                        oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //                    }
        //                    else
        //                    {
        //                        oHoja.Cells[InicioLinea, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    }

        //                    oHoja.Cells[InicioLinea, 3].Value = ListaKardexValorizado[i].Documento;
        //                    oHoja.Cells[InicioLinea, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 4].Value = ListaKardexValorizado[i].Serie;
        //                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 5].Value = ListaKardexValorizado[i].Numero;
        //                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

        //                    oHoja.Cells[InicioLinea, 6].Value = ListaKardexValorizado[i].idDocumentoRef;
        //                    oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 7].Value = ListaKardexValorizado[i].serDocumentoRef;
        //                    oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 8].Value = ListaKardexValorizado[i].numDocumentoRef;
        //                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

        //                    if (ListaKardexValorizado[i].CodSunat == null)
        //                    {
        //                        ListaKardexValorizado[i].CodSunat = "";
        //                    }

        //                    oHoja.Cells[InicioLinea, 9].Value = ListaKardexValorizado[i].CodSunat;
        //                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 10].Value = ListaKardexValorizado[i].NomOperacion;
        //                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

        //                    //Ingresos
        //                    oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].CantEntrada;
        //                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 12].Value = ListaKardexValorizado[i].CostEntrada;
        //                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 13].Value = ListaKardexValorizado[i].TotalEntrada;
        //                    oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    //Salidas
        //                    oHoja.Cells[InicioLinea, 14].Value = ListaKardexValorizado[i].CantSalida;
        //                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 15].Value = ListaKardexValorizado[i].CostSalida;
        //                    oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 16].Value = ListaKardexValorizado[i].TotalSalida;
        //                    oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    //Totales
        //                    oHoja.Cells[InicioLinea, 17].Value = ListaKardexValorizado[i].CantFinal;
        //                    oHoja.Cells[InicioLinea, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 18].Value = ListaKardexValorizado[i].CostFinal;
        //                    oHoja.Cells[InicioLinea, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 19].Value = ListaKardexValorizado[i].TotalFinal;
        //                    oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

        //                    for (int z = 1; z <= 19; z++)
        //                    {
        //                        oHoja.Cells[InicioLinea, z].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 7));
        //                    }
        //                }
        //                else
        //                {
        //                    //Empezando con una linea en blanco
        //                    InicioLinea++;

        //                    oHoja.Cells[InicioLinea, 10].Value = ListaKardexValorizado[i].NomOperacion;
        //                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 11].Value = ListaKardexValorizado[i].CantEntrada;
        //                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 14].Value = ListaKardexValorizado[i].CantSalida;
        //                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 17].Value = ListaKardexValorizado[i].CantFinal;
        //                    oHoja.Cells[InicioLinea, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 18].Value = ListaKardexValorizado[i].CostFinal;
        //                    oHoja.Cells[InicioLinea, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                    oHoja.Cells[InicioLinea, 19].Value = ListaKardexValorizado[i].TotalFinal;
        //                    oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //                }

        //                idArt = ListaKardexValorizado[i].Articulo;
        //                InicioLinea++;
        //            }

        //            ////Linea en blanco
        //            InicioLinea++;

        //            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 17, InicioLinea, 18])
        //            {
        //                Rango.Merge = true;
        //                Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 11, FontStyle.Bold));
        //                //Rango.Style.Font.Color.SetColor(Color.Black);
        //                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
        //                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
        //                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //            }

        //            oHoja.Cells[InicioLinea, 17].Value = "TOTAL COSTO >>>";
        //            oHoja.Cells[InicioLinea, 19].Value = Convert.ToDecimal((from x in ListaKardexValorizado
        //                                                                    where x.codArticulo == "X"
        //                                                                    select x.TotalFinal).Sum());
        //            #endregion

        //            //Ajustando el ancho de las columnas automaticamente
        //            oHoja.Cells.AutoFitColumns();

        //            //Insertando Encabezado
        //            oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
        //            //Pie de Pagina(Derecho) "Número de paginas y el total"
        //            oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
        //            //Pie de Pagina(centro)
        //            oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

        //            //Otras Propiedades
        //            oHoja.Workbook.Properties.Title = TituloGeneral;
        //            oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
        //            oHoja.Workbook.Properties.Subject = "Kárdex Oficial";
        //            //oHoja.Workbook.Properties.Keywords = "";
        //            oHoja.Workbook.Properties.Category = "Módulo de Almacén";
        //            oHoja.Workbook.Properties.Comments = Subtitulo;

        //            // Establecer algunos valores de las propiedades extendidas
        //            oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

        //            //Propiedades para imprimir
        //            oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
        //            oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

        //            //Guardando el excel
        //            oExcel.Save();
        //        }
        //    }
        //}

       
        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                string Inicio = dtpInicio.Value.ToString("yyyyMMdd");
                string Fin = dtpFinal.Value.ToString("yyyyMMdd");

                ListaKardexValorizado = AgenteAlmacen.Proxy.ListarKardexValorizado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboAlmacen.SelectedValue), Inicio, Fin);
                bskardexValorizado.DataSource = ListaKardexValorizado;
                bskardexValorizado.ResetBindings(false);

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ConvertirApdf_Kardex()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\KardexStockMensual " + Aleatorio.ToString();
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

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

                    //Boolean TipoReporte = true;
                    //TipoReporte = (txtPersona.Text.Equals("0") ? true : false);


                    // ===========
                    // COLUM - MES
                    // ===========

                    ListaKardexValorizadoGroupBy = ListaKardexValorizado.Where(y => y.fecProceso != null).GroupBy(y => Convert.ToDateTime(y.fecProceso).Month).Select(g => g.First()).OrderBy(x => Convert.ToDateTime(x.fecProceso).Month).ToList();

                    // =========
                    // FLOAT 
                    // =========

                    float[] colFloat = new float[8 + ListaKardexValorizadoGroupBy.Count() * 3];
                    int CantCol = 8 + ListaKardexValorizadoGroupBy.Count() * 3;

                    for (int i = 0; i < CantCol; i++)
                    {
                        if (i == 0)
                            colFloat[i] = 0.032f;
                        if (i == 1)
                            colFloat[i] = 0.075f;
                        if (i == 2)
                            colFloat[i] = 0.40f;
                        if (i >= 3 && i <= 6)
                            colFloat[i] = 0.056f;
                        if (i > 6)
                            colFloat[i] = 0.055f;
                    }

                    // ========
                    // PDF
                    // ========
                    PaginaInicialKardexPorMes ev = new PaginaInicialKardexPorMes();

                    // ==========
                    // PARAMETROS
                    // ==========
                    ev.ListaKardexValorizadoGroupBy = ListaKardexValorizadoGroupBy;
                    ev.colFloat = colFloat;
                    ev.CantCol = CantCol;

                    // ==========
                    if (cboMoneda.SelectedIndex == 0)
                    {
                        TituloReporte = "(Costo Unitario Expresado en SOLES)";
                    }
                    else
                    {
                        TituloReporte = "(Costo Unitario Expresado en DOLARES)";
                    }
                    ev.Titulo = TituloReporte;
                    //ev.TipoReporte = TipoReporte;
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Detalle

                    // ===========
                    // COLUMNAS
                    // ===========

                    PdfPTable TablaCabDetalle = new PdfPTable(CantCol)
                    {
                        WidthPercentage = 100
                    };

                    //TablaCabDetalle.SetWidths(new float[] { 0.022f, 0.075f, 0.17f, 0.075f, 0.075f, 0.075f, 0.075f, 0.075f, 0.075f, 0.075f, 0.075f });
                    TablaCabDetalle.SetWidths(colFloat);

                    // ===========
                    // 
                    // ===========

                    int Count_Lineas = 0;
                    String codArticulo = "";
                    //Boolean NuevaLinea = false;

                    decimal CargaInicial = 0;
                    decimal CantEntrada = 0;
                    decimal CantSalida = 0;
                    decimal CostoUnitario = 0;
                    int mesActual = 0;
                    //Boolean mesEntro = false;
                    int mesKardex = 0;

                    // ============
                    // GROUP BY ART
                    // ============

                    ListaKardexValorizadoPersonas = ListaKardexValorizadoPersonas.Where(y => y.fecProceso != null).GroupBy(y => y.codArticulo).Select(g => g.First()).ToList();

                    // ===========
                    // DETALLE
                    // ===========
                    foreach (KardexValorizadoE item in ListaKardexValorizadoPersonas)
                    {

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((Count_Lineas + 1).ToString(), null, "N", null, FontFactory.GetFont("Arial", 4.5f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "N", null, FontFactory.GetFont("Arial", 4.5f), 5, 1));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.DesArticulo, null, "N", null, FontFactory.GetFont("Arial", 4.5f), 5, 0));

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((item.DesUniMedEnvase.Length > 4 ? item.DesUniMedEnvase.Substring(0, 4) : item.DesUniMedEnvase), null, "N", null, FontFactory.GetFont("Arial", 4.5f), 5, 0));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Contenido.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 4.5f), 5, 2));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((item.DesUniMedPres.Length > 4 ? item.DesUniMedPres.Substring(0, 4) : item.DesUniMedPres), null, "N", null, FontFactory.GetFont("Arial", 4.5f), 5, 0));

                        // Costo Unitario

                        CostoUnitario = ListaKardexValorizado.OrderByDescending(x => x.fecProceso).Where(x => x.codArticulo == item.codArticulo).Select(x => x.CostFinal).FirstOrDefault();

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CostoUnitario.ToString("N6"), null, "N", null, FontFactory.GetFont("Arial", 4.5f), 5, 2));

                        // Carga Inicial

                        CargaInicial = ListaKardexValorizado.Where(x=> x.codArticulo == item.codArticulo).Sum(x=> x.CantEntradaInicial);

                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(CargaInicial.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 4.5f), 5, 2));

                        Decimal CantFinal = CargaInicial;

                        // ===========
                        // FOR - MESES
                        // ===========
                        for (int i = 0; i < ListaKardexValorizadoGroupBy.Count; i++)
                        {
                            mesKardex = Convert.ToDateTime(ListaKardexValorizadoGroupBy[i].fecProceso).Month;

                            CantEntrada = 0;
                            CantSalida = 0;

                            // ===========
                            // FOR - FECHAS
                            // ===========
                            for (int itm = 0; itm < ListaKardexValorizado.Count; itm++)
                            {
                                if (ListaKardexValorizado[itm].fecProceso != null)
                                {
                                    mesActual = Convert.ToDateTime(ListaKardexValorizado[itm].fecProceso).Month;

                                    if (mesActual == mesKardex &&
                                            item.codArticulo == ListaKardexValorizado[itm].codArticulo)
                                    {
                                        //mesEntro = true;
                                        CantEntrada += ListaKardexValorizado[itm].CantEntradaNoInicial;
                                        CantSalida += ListaKardexValorizado[itm].CantSalida;
                                    }
                                }
                            }

                            CantFinal = CantFinal + (CantEntrada - CantSalida);

                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((CantEntrada == 0 ? "-" : CantEntrada.ToString("N2")), null, "N", null, FontFactory.GetFont("Arial", 4.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((CantSalida == 0 ? "-" : CantSalida.ToString("N2")), null, "N", null, FontFactory.GetFont("Arial", 4.25f), 5, 2));
                            TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda((CantFinal.ToString("N2")), null, "N", null, FontFactory.GetFont("Arial", 4.25f), 5, 2));


                        }

                        Count_Lineas++;
                        TablaCabDetalle.CompleteRow();
                        codArticulo = item.codArticulo;

                    }
                    // ==============
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

        void ExportarExcel()
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String SubReporte = String.Empty;

            TituloGeneral = "ESTADISTICO DE KARDEX MENSUAL";
            if (cboMoneda.SelectedIndex == 0)
            {
                SubReporte = "(Costo Unitario Expresado en SOLES)";
            }
            else
            {
                SubReporte = "(Costo Unitario Expresado en DOLARES)";
            }
            NombrePestaña = "Durante el " + dtpInicio.Value.ToString("yyyy");

            if (File.Exists(RutaGeneral))
            {
                File.Delete(RutaGeneral);
            }

            FileInfo newFile = new FileInfo(RutaGeneral);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {

                    // ===========
                    // COLUM - MES
                    // ===========

                    ListaKardexValorizadoGroupBy = ListaKardexValorizado.Where(y => y.fecProceso != null).GroupBy(y => Convert.ToDateTime(y.fecProceso).Month).Select(g => g.First()).OrderBy(x => Convert.ToDateTime(x.fecProceso).Month).ToList();

                    Int32 InicioLinea = 5;
                    float[] colFloat = new float[8 + ListaKardexValorizadoGroupBy.Count() * 3];
                    int CantCol = 8 + ListaKardexValorizadoGroupBy.Count() * 3;

                    for (int i = 0; i < CantCol; i++)
                    {
                        if (i == 0)
                            colFloat[i] = 0.024f;
                        if (i == 1)
                            colFloat[i] = 0.075f;
                        if (i == 2)
                            colFloat[i] = 0.17f;
                        if (i >= 3 && i <= 6)
                            colFloat[i] = 0.056f;
                        if (i > 6)
                            colFloat[i] = 0.055f;
                    }

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, CantCol])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 16, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(117, 113, 113));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, CantCol])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 14, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(174, 170, 170));
                    }

                    oHoja.Cells["A3"].Value = SubReporte;

                    using (ExcelRange Rango = oHoja.Cells[3, 1, 3, CantCol])
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
                    Int32 ColumnaMes = 8+1;
                    Int32 ColumnaS = 9+1;
                    Int32 ColumnaSTOCK = 10+1;
                    BaseColor ColorDet = new BaseColor(170, 181, 191);
                    Int32 ColumnaMesad = 10+1;
                    //PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "N°";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, 5, 1])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 2].Value = "Código";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, 5, 2])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 3].Value = "Descripción";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, 5, 3])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 4].Value = "UND. Envio";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 4, 5, 4])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 5].Value = "Contenido";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, 5, 5])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 6].Value = "UND.\nPresen";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, 5, 6])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 7].Value = "Costo";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, 5, 7])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    oHoja.Cells[InicioLinea, 8].Value = "Inicial";

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, 5, 8])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                    }

                    for (int i = 0; i < ListaKardexValorizadoGroupBy.Count; i++)
                    {
                        int mes = Convert.ToDateTime(ListaKardexValorizadoGroupBy[i].fecProceso).Month;
                        String NombreMes = FechasHelper.NombreMes(mes);
                       
                        oHoja.Cells[InicioLinea, i + ColumnaMes].Value = NombreMes.ToUpper();
                  

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, i + ColumnaMes, InicioLinea, i + ColumnaMesad])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                        }


                        oHoja.Cells[6, i + ColumnaMes].Value = "I";
                        using (ExcelRange Rango = oHoja.Cells[6, i + ColumnaMes, 6, i + ColumnaMes])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                        }

                        oHoja.Cells[6, i + ColumnaS].Value = "S";
                        using (ExcelRange Rango = oHoja.Cells[6, i + ColumnaS, 6, i + ColumnaS])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                        }

                        oHoja.Cells[6, i + ColumnaSTOCK].Value = "Stock";
                        using (ExcelRange Rango = oHoja.Cells[6, i + ColumnaSTOCK, 6, i + ColumnaSTOCK])
                        {
                            Rango.Merge = true;
                            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                            Rango.Style.Font.Color.SetColor(Color.Black);
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(170, 181, 191));
                        }
                        ColumnaMes += 2;
                        ColumnaMesad += 2;
                        ColumnaS += 2;
                        ColumnaSTOCK += 2;
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;
                    InicioLinea++;

                    #endregion

                    #region Detalle

                    int Count_Lineas = 0;
                    String codArticulo = "";
                    //Boolean NuevaLinea = false;

                    decimal CargaInicial = 0;
                    decimal CostoUnitario = 0;
                    decimal CantEntrada = 0;
                    decimal CantSalida = 0;
                    decimal CantFinal = 0;
                    int mesActual = 0;
                    //Boolean mesEntro = false;
                    int mesKardex = 0;

                    // ============
                    // GROUP BY ART
                    // ============
                    ListaKardexValorizadoPersonas = ListaKardexValorizadoPersonas.Where(y => y.fecProceso != null).GroupBy(y => y.codArticulo).Select(g => g.First()).ToList();

                    foreach (KardexValorizadoE item in ListaKardexValorizadoPersonas)
                    {
                        Int32 numeroent = 8+1;
                        Int32 numerosal = 9+1;
                        Int32 numeroentsal = 10+1;

                        CostoUnitario = ListaKardexValorizado.OrderByDescending(x => x.fecProceso).Where(x => x.codArticulo == item.codArticulo).Select(x => x.CostFinal).FirstOrDefault();

                        // Carga Inicial
                        CargaInicial = ListaKardexValorizado.Where(x => x.codArticulo == item.codArticulo).Sum(x => x.CantEntradaInicial);

                        oHoja.Cells[InicioLinea, 1].Value = (Count_Lineas + 1).ToString();
                        oHoja.Cells[InicioLinea, 2].Value = item.codArticulo;
                        oHoja.Cells[InicioLinea, 3].Value = item.DesArticulo;
                        oHoja.Cells[InicioLinea, 4].Value = (item.DesUniMedEnvase.Length > 5 ? item.DesUniMedEnvase.Substring(0, 5) : item.DesUniMedEnvase);
                        oHoja.Cells[InicioLinea, 5].Value = item.Contenido;
                        oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 6].Value = (item.DesUniMedPres.Length > 5 ? item.DesUniMedPres.Substring(0, 5) : item.DesUniMedPres);

                        oHoja.Cells[InicioLinea, 7].Value = CostoUnitario;
                        oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        oHoja.Cells[InicioLinea, 8].Value = CargaInicial;
                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        CantFinal = CargaInicial;

                        // ===========
                        // FOR - MESES
                        // ===========
                        for (int i = 0; i < ListaKardexValorizadoGroupBy.Count; i++)
                        {
                            mesKardex = Convert.ToDateTime(ListaKardexValorizadoGroupBy[i].fecProceso).Month;
                            CantEntrada = 0;
                            CantSalida = 0;

                            // ===========
                            // FOR - FECHAS
                            // ===========
                            for (int itm = 0; itm < ListaKardexValorizado.Count; itm++)
                            {
                                if (ListaKardexValorizado[itm].fecProceso != null)
                                {
                                    mesActual = Convert.ToDateTime(ListaKardexValorizado[itm].fecProceso).Month;

                                    if (mesActual == mesKardex && item.codArticulo == ListaKardexValorizado[itm].codArticulo)
                                    {
                                        //mesEntro = true;
                                        CantEntrada += ListaKardexValorizado[itm].CantEntradaNoInicial;
                                        CantSalida += ListaKardexValorizado[itm].CantSalida;
                                    }
                                }
                            }
                        
                            if (CantEntrada == 0)
                            {
                                oHoja.Cells[InicioLinea, i + numeroent].Value = "-";
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, i + numeroent].Value = CantEntrada;
                                oHoja.Cells[InicioLinea, i + numeroent].Style.Numberformat.Format = "###,###,##0.00";
                            }

                            oHoja.Cells[InicioLinea, i + numeroent].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
              
                            if (CantSalida == 0)
                            {
                                oHoja.Cells[InicioLinea, i + numerosal].Value = "-";
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, i + numerosal].Value = CantSalida;
                                oHoja.Cells[InicioLinea, i + numerosal].Style.Numberformat.Format = "###,###,##0.00";
                            }

                            oHoja.Cells[InicioLinea, i + numerosal].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            CantFinal += (CantEntrada - CantSalida);

                            if (CantEntrada == 0 && CantSalida == 0)
                            {
                                oHoja.Cells[InicioLinea, i + numeroentsal].Value = CantFinal;
                                oHoja.Cells[InicioLinea, i + numeroentsal].Style.Numberformat.Format = "###,###,##0.00";
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, i + numeroentsal].Value = CantFinal;
                                oHoja.Cells[InicioLinea, i + numeroentsal].Style.Numberformat.Format = "###,###,##0.00";
                            }

                            oHoja.Cells[InicioLinea, i + numeroentsal].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            
                            numeroent += 2;
                            numerosal += 2;
                            numeroentsal += 2;
                        }

                        Count_Lineas++;
                        InicioLinea++;
                        codArticulo = item.codArticulo;                                                                                                                                        
                    }

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

        public override bool ValidarGrabacion()
        {
            if (cboTipoAlmacen.SelectedIndex == 0)
            {
                Global.MensajeComunicacion("Debe Seleccionar un Tipo de Almacén");
                return false;
            }

            if (cboAlmacen.SelectedIndex == 0)
            {
                Global.MensajeComunicacion("Debe Seleccionar un Almacén");
                return false;
            }

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
                if (ListaKardexValorizadoGroupBy == null || ListaKardexValorizadoGroupBy.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }
                

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Kardex Mensual" + "-" + VariablesLocales.SesionUsuario.Empresa.NombreComercial , "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    tipoProceso = 2;
                    //lblProcesando.Visible = true;
                    //btBuscar.Enabled = true;
                    //Marque = "Importando los registros a Excel...";
                    //pbProgress.Visible = true;
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
                String idMoneda = Convert.ToString(cboMoneda.SelectedValue);
                Int32 idTipoArticulo = Convert.ToInt32(cboTipoAlmacen.SelectedValue);

                ListaKardexValorizado = AgenteAlmacen.Proxy.ListarKardexValorizadoFilt(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboAlmacen.SelectedValue), Inicio, Fin, idArticulo, idMoneda,idTipoArticulo);
                ListaKardexValorizadoPersonas = ListaKardexValorizado;

                if (tipoProceso == 1)
                {
                    ConvertirApdf_Kardex();
                }
                else
                {
                    ExportarExcel();
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
            cboAlmacen.Enabled = false;
            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            //BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
            Int32 AnioActual = DateTime.Now.Year;
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia("01",AnioActual.ToString()));
            dtpFinal.Value = Convert.ToDateTime(FechasHelper.ObtenerUltimoDia(DateTime.Now));
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

        private void btExportar_Click(object sender, EventArgs e)
        {
            Exportar();
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
                oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Todos });
                ComboHelper.LlenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
            }
        }

        #endregion

    }
}

#region Pdf Inicio

class PaginaInicialKardexPorMes : PdfPageEventHelper
{
    public List<KardexValorizadoE> ListaKardexValorizadoGroupBy;
    public float[] colFloat;
    public int CantCol;
    public String Titulo;

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        #region Variables Internas

        String TituloGeneral = String.Empty;

        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
        BaseColor ColorDet = new BaseColor(170, 181, 191);

        #endregion

        TituloGeneral = Titulo;

        #region Encabezado y Titulo General

        //Cabecera del Reporte
        PdfPTable TablaGeneral = new PdfPTable(2)
        {
            WidthPercentage = 100,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        TablaGeneral.SetWidths(new float[] { 0.9f, 0.13f });

        TablaGeneral.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Pag. " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        TablaGeneral.CompleteRow(); //Fila completada

        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        TablaGeneral.CompleteRow(); //Fila completada

        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
        TablaGeneral.CompleteRow(); //Fila completada

        TablaGeneral.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), -1, -1, "S2"));
        TablaGeneral.CompleteRow();

        TablaGeneral.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 12.25f, iTextSharp.text.Font.BOLD), 5, 1, "S2"));
        TablaGeneral.CompleteRow();

        TablaGeneral.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "S2"));
        TablaGeneral.CompleteRow();

        document.Add(TablaGeneral); //Añadiendo la tabla al documento PDF

        #endregion

        #region Cabecera del Detalle

        // =============
        // COLUMNAS
        // =============
        TablaGeneral = new PdfPTable(CantCol)
        {
            WidthPercentage = 100
        };
        TablaGeneral.SetWidths(colFloat);

        // =============
        // PRIMER LINEA
        // =============
        #region Primera Linea

        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("N°", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Código", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));

        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Und.\nEnvio", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Conten", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Und.\nPresen", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Costo\nUnit.", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));
        TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Inicial", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "N", "S2"));

        // ==========
        // FOR - MESES
        // ==========
        for (int i = 0; i < ListaKardexValorizadoGroupBy.Count; i++)
        {
            int mes = Convert.ToDateTime(ListaKardexValorizadoGroupBy[i].fecProceso).Month;
            String NombreMes = FechasHelper.NombreMes(mes);
            TablaGeneral.AddCell(ReaderHelper.NuevaCelda(NombreMes, ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1, "S3", "N"));
        }

        TablaGeneral.CompleteRow();

        #endregion

        // =============
        // SEGUNDA LINEA
        // =============
        #region Segunda Linea

        // ==========
        // FOR - MESES
        // ==========
        for (int i = 0; i < ListaKardexValorizadoGroupBy.Count; i++)
        {
            TablaGeneral.AddCell(ReaderHelper.NuevaCelda("I", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaGeneral.AddCell(ReaderHelper.NuevaCelda("S", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
            TablaGeneral.AddCell(ReaderHelper.NuevaCelda("Stock", ColorDet, "S", null, FontFactory.GetFont("Arial", 6f, iTextSharp.text.Font.BOLD), 5, 1));
        }

        TablaGeneral.CompleteRow();
        #endregion

        // ============
        // END DOCUMENT
        // ============
        document.Add(TablaGeneral); //Añadiendo la tabla al documento PDF

        #endregion

    }

}

#endregion
