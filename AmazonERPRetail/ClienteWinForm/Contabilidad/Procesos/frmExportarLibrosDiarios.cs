using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Procesos
{
    public partial class frmExportarLibrosDiarios : FrmMantenimientoBase
    {

        public frmExportarLibrosDiarios()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<RegistroDiarioE> oListaRegistroDiario = new List<RegistroDiarioE>();

        List<RegistroDiarioE> oListaRegistroDiarioTmp = null;
        List<ComprobantesE> oListaComprobantesTmp = null;
        List<ComprobantesE> oListaComprobantes = new List<ComprobantesE>();
        String ComprobanteINI = String.Empty;
        String ComprobanteFin = String.Empty;
        String ComTmp = String.Empty;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        String UNO = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        #region Procedimientos Almacenados

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;
            String Moneda = String.Empty;


            if (ComprobanteINI == ComprobanteFin)
            {
                TituloGeneral = "Libro Diario del Comprobante";
            }
            else
            {
                TituloGeneral = "Libro Diario del Comprobante " + ComprobanteINI.ToUpper() + " al " + ComprobanteFin.ToUpper();
            }

            NombrePestaña = "Libro Diario";

            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 28;

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

                    oHoja.Cells["A2"].Value = TituloGeneral;

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

                    #region Cabecera

                    #region Primera Linea Cabecera

                    using (ExcelRange Rango = oHoja.Cells[4, 1, 5, 1])
                    {
                        Rango.Merge = true;
                        Rango.Value = "NUMERO CORRELATIVO DEL ASIENTO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 2, 5, 2])
                    {
                        Rango.Merge = true;
                        Rango.Value = "FECHA DE OPERACION";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }
                    
                    using (ExcelRange Rango = oHoja.Cells[4, 3, 5, 3])
                    {
                        Rango.Merge = true;
                        Rango.Value = "GLOSA O DESCRIPCION DE LA OPERACION";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 4, 4, 15])
                    {
                        Rango.Merge = true;
                        Rango.Value = "REFERENCIA DE LA OPERACION";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 16, 4, 17])
                    {
                        Rango.Merge = true;
                        Rango.Value = "ANEXO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 18, 4, 21])
                    {
                        Rango.Merge = true;
                        Rango.Value = "CUENTA CONTABLE ASOCIADA A LA OPERACION";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 22, 4, 23])
                    {
                        Rango.Merge = true;
                        Rango.Value = "DÓLAR";
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 24, 4, 25])
                    {
                        Rango.Merge = true;
                        Rango.Value = "SOLES";
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    using (ExcelRange Rango = oHoja.Cells[4, 26, 4, 28])
                    {
                        Rango.Merge = true;
                        Rango.Value = "PARTIDA PRESUPUESTO";
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                        Rango.Style.Font.Bold = true;
                        Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    #endregion

                    InicioLinea++;

                    #region Segunda Linea Cabecera

                    oHoja.Cells[InicioLinea, 4].Value = "CODIGO DEL LIBRO REGISTRO";
                    oHoja.Cells[InicioLinea, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 4].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 5].Value = "USUARIO";
                    oHoja.Cells[InicioLinea, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 6].Value = "FECHA CREACION";
                    oHoja.Cells[InicioLinea, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 6].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 7].Value = "HORA REGISTRO";
                    oHoja.Cells[InicioLinea, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 7].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 7].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 8].Value = "Número Correlativo";
                    oHoja.Cells[InicioLinea, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 9].Value = "TD";
                    oHoja.Cells[InicioLinea, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 9].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 9].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 10].Value = "SERIE";
                    oHoja.Cells[InicioLinea, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 10].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 10].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 11].Value = "NUMERO";
                    oHoja.Cells[InicioLinea, 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 11].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 11].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 12].Value = "FECHA DOC.";
                    oHoja.Cells[InicioLinea, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 12].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 13].Value = "FECHA VENC.";
                    oHoja.Cells[InicioLinea, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 13].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 13].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 14].Value = "C.COSTOS";
                    oHoja.Cells[InicioLinea, 14].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 14].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);


                    oHoja.Cells[InicioLinea, 15].Value = "DESCRIPCION C.COSTOS";
                    oHoja.Cells[InicioLinea, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 15].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 15].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 16].Value = "Ruc";
                    oHoja.Cells[InicioLinea, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 16].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 16].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);


                    oHoja.Cells[InicioLinea, 17].Value = "Razon Social";
                    oHoja.Cells[InicioLinea, 17].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 17].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 17].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);


                    oHoja.Cells[InicioLinea, 18].Value = "CODIGO";
                    oHoja.Cells[InicioLinea, 18].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 18].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 18].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 19].Value = "DENOMINACION";
                    oHoja.Cells[InicioLinea, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 19].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 19].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 20].Value = "Moneda";
                    oHoja.Cells[InicioLinea, 20].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 20].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 20].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 20].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 21].Value = "TC";
                    oHoja.Cells[InicioLinea, 21].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 21].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 21].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 21].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 22].Value = "DEBE";
                    oHoja.Cells[InicioLinea, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    oHoja.Cells[InicioLinea, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 22].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 22].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 22].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 23].Value = "HABER";
                    oHoja.Cells[InicioLinea, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    oHoja.Cells[InicioLinea, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 23].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 23].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 24].Value = "DEBE";
                    oHoja.Cells[InicioLinea, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    oHoja.Cells[InicioLinea, 24].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 24].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 24].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 24].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 25].Value = "HABER";
                    oHoja.Cells[InicioLinea, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    oHoja.Cells[InicioLinea, 25].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 25].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 25].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 25].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 26].Value = "TP";
                    oHoja.Cells[InicioLinea, 26].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 26].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 26].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 26].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 27].Value = "PARTIDA";
                    oHoja.Cells[InicioLinea, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 27].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 27].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 27].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    oHoja.Cells[InicioLinea, 28].Value = "NOMBRE PARTIDA";
                    oHoja.Cells[InicioLinea, 28].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    oHoja.Cells[InicioLinea, 28].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                    oHoja.Cells[InicioLinea, 28].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 28].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                    #endregion

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    #endregion

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    decimal totDebesoles = 0;
                    decimal totHabersoles = 0;
                    decimal totDebedolares = 0;
                    decimal totHaberdolares = 0;

                    #region Carga Informacion a Excel

                    foreach (RegistroDiarioE item in oListaRegistroDiario)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.idLocal + "-" + item.idComprobante + "-" + item.numFile + "-" + item.numVoucher;
                        oHoja.Cells[InicioLinea, 2].Value = Convert.ToDateTime(item.fecOperacion).ToString("dd/MM/yy");
                        //oHoja.Cells[InicioLinea, 3].Value = item.desMoneda;
                        oHoja.Cells[InicioLinea, 3].Value = item.GlosaGeneral;
                        oHoja.Cells[InicioLinea, 4].Value = item.idComprobante;
                        oHoja.Cells[InicioLinea, 5].Value = item.UsuarioRegistro;
                        if (item.FechaRegistro != null)
                        {
                            oHoja.Cells[InicioLinea, 6].Value = item.FechaRegistro.ToString("dd/MM/yy");
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 6].Value = "";
                        }

                        if (item.FechaRegistro != null)
                        {
                            oHoja.Cells[InicioLinea, 7].Value = item.FechaRegistro.ToString("hh:mm");
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 7].Value = "";
                        }

                        oHoja.Cells[InicioLinea, 8].Value = item.numItem;
                        oHoja.Cells[InicioLinea, 9].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 10].Value = item.serDocumento;
                        oHoja.Cells[InicioLinea, 11].Value = item.numDocumento;

                        if (item.fecDocumento != null)
                        {
                            oHoja.Cells[InicioLinea, 12].Value = item.fecDocumento.Value.ToString("dd/MM/yy");
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 12].Value = "";
                        }

                        if (item.fecVencimiento != null)
                        {
                            oHoja.Cells[InicioLinea, 13].Value = item.fecVencimiento.Value.ToString("dd/MM/yy");
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 13].Value = "";
                        }

                        oHoja.Cells[InicioLinea, 14].Value = item.idCCostos;
                        oHoja.Cells[InicioLinea, 15].Value = item.desCCostos;

                        oHoja.Cells[InicioLinea, 16].Value = item.Ruc;
                        oHoja.Cells[InicioLinea, 17].Value = item.RazonSocial;

                        oHoja.Cells[InicioLinea, 18].Value = item.codCuenta;
                        oHoja.Cells[InicioLinea, 19].Value = item.desCuenta;
                        oHoja.Cells[InicioLinea, 20].Value = item.desMoneda;
                        oHoja.Cells[InicioLinea, 21].Value = Convert.ToDecimal(item.tipCambio);
                        oHoja.Cells[InicioLinea, 22].Value = item.DebeDolares;
                        oHoja.Cells[InicioLinea, 23].Value = item.HaberDolares;
                        oHoja.Cells[InicioLinea, 24].Value = item.DebeSoles;
                        oHoja.Cells[InicioLinea, 25].Value = item.HaberSoles;

                        oHoja.Cells[InicioLinea, 26].Value = item.tipPartidaPresu;
                        oHoja.Cells[InicioLinea, 27].Value = item.codPartidaPresu;
                        oHoja.Cells[InicioLinea, 28].Value = item.desPartidaPresu;

                        oHoja.Cells[InicioLinea, 21, InicioLinea, 24].Style.Numberformat.Format = "###,###,##0.00";
                        InicioLinea++;
                        totDebedolares += item.DebeDolares;
                        totHaberdolares += item.HaberDolares;
                        totDebesoles += item.DebeSoles;
                        totHabersoles += item.HaberSoles;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea, 19])
                    {
                        Rango.Merge = true;
                        Rango.Value = String.Empty;
                    }

                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 20, InicioLinea, 21])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.Bold = true;
                        Rango.Value = "TOTAL ";
                    }

                    oHoja.Cells[InicioLinea, 22].Value = totDebedolares;
                    oHoja.Cells[InicioLinea, 23].Value = totHaberdolares;
                    oHoja.Cells[InicioLinea, 24].Value = totDebesoles;
                    oHoja.Cells[InicioLinea, 25].Value = totHabersoles;

                    oHoja.Cells[InicioLinea, 22].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 22].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 22].Value = Convert.ToDecimal(totDebedolares.ToString("N2"));

                    oHoja.Cells[InicioLinea, 23].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 23].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 23].Value = Convert.ToDecimal(totHaberdolares.ToString("N2"));

                    oHoja.Cells[InicioLinea, 24].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 24].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 24].Value = Convert.ToDecimal(totDebesoles.ToString("N2"));

                    oHoja.Cells[InicioLinea, 25].Style.Numberformat.Format = "###,###,##0.00";
                    oHoja.Cells[InicioLinea, 25].Style.Font.Bold = true;
                    oHoja.Cells[InicioLinea, 25].Value = Convert.ToDecimal(totHabersoles.ToString("N2"));

                    InicioLinea++;

                    #endregion

                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    #region Propiedades del Excel

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = String.Empty;
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                    #endregion

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
                bsComprobantes.DataSource = AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                lblRegistros.Text = "Registros " + bsComprobantes.Count.ToString();
                dgvTipoComprobantes.AutoResizeColumns();

                base.Buscar();
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
                //if (oListaRegistroDiario.Count == Variables.Cero)
                //{
                //    Global.MensajeFault("No hay datos para exportar a Excel.");
                //    return;
                //}
                String dia = VariablesLocales.FechaHoy.Date.Day.ToString("00");
                String mes = VariablesLocales.FechaHoy.Date.Month.ToString("00");
                String anio = VariablesLocales.FechaHoy.Date.Year.ToString();

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Libro Diario (" + dia + "_" + mes + "_" + anio + ")", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Marque = "Importando los registros a Excel...";
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
                oListaComprobantesTmp = (List<ComprobantesE>)bsComprobantes.List;

                if (oListaComprobantesTmp.Count > 0)
                {
                    String IncluirAutomatico = String.Empty;
                    DateTime FechaIni = dtpIngreso.Value.Date;
                    DateTime FechaFin = dtpFinal.Value.Date;
                    Int32 idLocal = VariablesLocales.SesionLocal.IdLocal;

                    if (chkCuentas.Checked == true)
                    {
                        IncluirAutomatico = "S";
                    }
                    else
                    {
                        IncluirAutomatico = "N";
                    }

                    foreach (ComprobantesE item in oListaComprobantesTmp)
                    {
                        String idComprobanteIni = item.idComprobante;
                        String idComprobanteFin = item.idComprobante;

                        if (item.Check == true)
                        {
                            oListaRegistroDiarioTmp = AgenteContabilidad.Proxy.RegistroDeDiarioEXCEL(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                  idLocal, FechaIni, FechaFin, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                  idComprobanteIni, idComprobanteFin, IncluirAutomatico);
                            foreach (RegistroDiarioE item2 in oListaRegistroDiarioTmp)
                            {
                                oListaRegistroDiario.Add(item2);
                            }
                        }
                    }

                    ExportarExcel(RutaGeneral);
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
            btExportar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                Global.MensajeComunicacion("Proceso Terminado...!!!");
            }
        }

        #endregion

        #region Eventos

        private void frmExportarLibrosDiarios_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                oListaRegistroDiario = new List<RegistroDiarioE>();
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btExportar.Enabled = false;
                Imprimir();
            }
            catch (Exception ex)
            {
                btExportar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvTipoComprobantes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    String nomColumn = dgvTipoComprobantes.Columns[e.ColumnIndex].Name;

            //    if (nomColumn == "Check")
            //    {
            //        dgvTipoComprobantes.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            //    }
            //    else
            //    {
            //        dgvTipoComprobantes.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            //    }
            //}
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            oListaComprobantesTmp = (List<ComprobantesE>)bsComprobantes.List;

            if (oListaComprobantesTmp.Count > 0)
            {
                foreach (ComprobantesE item in oListaComprobantesTmp)
                {
                    if (chkTodos.Checked == true)
                    {
                        item.Check = true;
                    }
                    else
                    {
                        item.Check = false;
                    }
                }

                bsComprobantes.DataSource = oListaComprobantesTmp;
                bsComprobantes.ResetBindings(false);
            }
        }

        #endregion

    }
}
