using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

using iTextSharp.text;
using iTextSharp.text.pdf;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteCtaCtePendientes : FrmMantenimientoBase
    {

        public frmReporteCtaCtePendientes()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<conCtaCteE> oListaReporte;

        String RutaGeneral = String.Empty;

        Int32 TotalColumnas = 15;
        Int32 TotalColumnasResumen = 9;
        Int32 TotalColumnasResumen2 = 8;

        Int32 WidthTabla = 100;
        float[] TamanoCabecera = new float[] { 0.05f, 0.04f, 0.07f, 0.06f, 0.08f, 0.08f, 0.05f, 0.04f, 0.35f, 0.2f, 0.08f, 0.12f, 0.12f, 0.12f, 0.12f };
        float[] TamanoCabeceraResumen = new float[] { 0.1f, 0.3f, 0.2f, 0.1f, 0.1f, 0.12f, 0.12f, 0.12f, 0.12f };
        float[] TamanoCabeceraResumen2 = new float[] { 0.1f, 0.45f, 0.12f, 0.12f, 0.12f, 0.12f, 0.12f, 0.12f };

        Int32 idPersona = 0;
        Int32 idEmpresa;
        String PlanCuenta;
        String Anio;
        String CuentaIni;
        String CuentaFin;
        String MesIni;
        String MesFin;
        String TipoReporte;
        String TipoAccion = String.Empty;
        String RutaExcel = String.Empty;
        String NombreAchivo = String.Empty;
        List<conCtaCteE> oListaReporteAgrupadoRes2 = new List<conCtaCteE>();

        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////MES inicio////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboInicio.DataSource = oDt;
            cboInicio.ValueMember = "MesId";
            cboInicio.DisplayMember = "MesDes";
            cboInicio.SelectedValue = "00";

            /////MES Final////
            DataTable oET = FechasHelper.CargarMesesContable("MA");
            DataRow Fila2 = oET.NewRow();
            Fila2["MesId"] = "0";
            Fila2["MesDes"] = Variables.Todos;
            oET.Rows.Add(Fila2);

            oET.DefaultView.Sort = "MesId";
            cboFin.DataSource = oET;
            cboFin.ValueMember = "MesId";
            cboFin.DisplayMember = "MesDes";
            cboFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            // Anio
            Int32 anioFin = Convert.ToInt32(VariablesLocales.FechaHoy.Year);
            Int32 anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";
            cboAño.SelectedValue = anioFin;

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ListaMoneda.Add(new MonedasE() { idMoneda = "0", desMoneda = "Ambos" });

            //cboMoneda.DataSource = (from x in ListaMoneda
            //                        where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares) || (x.idMoneda == "0")
            //                        orderby x.idMoneda
            //                        select x).ToList();
            //cboMoneda.ValueMember = "idMoneda";
            //cboMoneda.DisplayMember = "desMoneda";
        }

        void ExportarExcel(String Ruta)
        {
            try
            {
                String TituloGeneral = String.Empty;
                String NombrePestaña = String.Empty;

                TituloGeneral = NombreAchivo;
                NombrePestaña = "Detalle Cta Cte Pendientes";

                if (File.Exists(Ruta)) File.Delete(Ruta);
                FileInfo newFile = new FileInfo(Ruta);

                using (ExcelPackage oExcel = new ExcelPackage(newFile))
                {
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                    if (oHoja != null)
                    {
                        Int32 InicioLinea = 1;
                        Int32 TotColumnas = 0;
                        Decimal TotalDol1 = 0;
                        Decimal TotalDol2 = 0;
                        Decimal TotalSol1 = 0;
                        Decimal TotalSol2 = 0;
                        Decimal Tot1 = 0;
                        Decimal Tot2 = 0;
                        Decimal ValCero = 0;
                        String codcuenta = String.Empty;
                        String descuenta = String.Empty;
                        Decimal Totaldol = 0;
                        Decimal Totalsol = 0;
                        Decimal TotalTot1 = 0;
                        Decimal TotalTot2 = 0;

                        #region Cabecera

                        #region Segunda Linea Cabecera

                        if (TipoReporte == "resumen")
                        {
                            TotColumnas = 14;

                            oHoja.Cells[InicioLinea, 1].Value = "Cuenta";
                            oHoja.Cells[InicioLinea, 2].Value = "Descripcion";
                            oHoja.Cells[InicioLinea, 3].Value = "RUC";
                            oHoja.Cells[InicioLinea, 4].Value = "Proveedor";
                            oHoja.Cells[InicioLinea, 5].Value = "Tipo Doc";
                            oHoja.Cells[InicioLinea, 6].Value = "Serie Doc";
                            oHoja.Cells[InicioLinea, 7].Value = "Numero Doc";
                            oHoja.Cells[InicioLinea, 8].Value = "F.Documento";
                            oHoja.Cells[InicioLinea, 9].Value = "F.Vencimiento";
                            oHoja.Cells[InicioLinea, 10].Value = "Moneda";
                            oHoja.Cells[InicioLinea, 11].Value = "Debe D";
                            oHoja.Cells[InicioLinea, 12].Value = "Haber D";
                            oHoja.Cells[InicioLinea, 13].Value = "Debe S";
                            oHoja.Cells[InicioLinea, 14].Value = "Haber S";
                        }
                        else if (TipoReporte == "detalle")
                        {
                            TotColumnas = 21;

                            oHoja.Cells[InicioLinea, 1].Value = "Cuenta";
                            oHoja.Cells[InicioLinea, 2].Value = "Descripcion";
                            oHoja.Cells[InicioLinea, 3].Value = "RUC";
                            oHoja.Cells[InicioLinea, 4].Value = "Proveedor";
                            oHoja.Cells[InicioLinea, 5].Value = "Tipo Doc";
                            oHoja.Cells[InicioLinea, 6].Value = "Serie Doc";
                            oHoja.Cells[InicioLinea, 7].Value = "Numero Doc";
                            oHoja.Cells[InicioLinea, 8].Value = "Diario";
                            oHoja.Cells[InicioLinea, 9].Value = "File";
                            oHoja.Cells[InicioLinea, 10].Value = "Comprobante";
                            oHoja.Cells[InicioLinea, 11].Value = "Periodo";
                            oHoja.Cells[InicioLinea, 12].Value = "F.Operacion";
                            oHoja.Cells[InicioLinea, 13].Value = "F.Documento";
                            oHoja.Cells[InicioLinea, 14].Value = "F.Vencimiento";
                            oHoja.Cells[InicioLinea, 15].Value = "TC";
                            oHoja.Cells[InicioLinea, 16].Value = "Mon";
                            oHoja.Cells[InicioLinea, 17].Value = "Glosa";
                            oHoja.Cells[InicioLinea, 18].Value = "Debe D";
                            oHoja.Cells[InicioLinea, 19].Value = "Haber D";
                            oHoja.Cells[InicioLinea, 20].Value = "Debe S";
                            oHoja.Cells[InicioLinea, 21].Value = "Haber S";
                        }
                        else if(TipoReporte == "resumen2")
                        {
                            TotColumnas = 8;

                            oHoja.Cells[InicioLinea, 1].Value = "Cuenta";
                            oHoja.Cells[InicioLinea, 2].Value = "Descripcion";
                            oHoja.Cells[InicioLinea, 3].Value = "Debe D.";
                            oHoja.Cells[InicioLinea, 4].Value = "Haber D.";
                            oHoja.Cells[InicioLinea, 5].Value = "Saldo D.";
                            oHoja.Cells[InicioLinea, 6].Value = "Debe S.";
                            oHoja.Cells[InicioLinea, 7].Value = "Haber S.";
                            oHoja.Cells[InicioLinea, 8].Value = "Saldo S.";
                        }
                        

                        for (Int32 i = 1; i < TotColumnas + 1; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        #endregion

                        // Auto Filtro
                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                        #endregion Cabecera

                        #region Detalle

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;

                        foreach (conCtaCteE item in oListaReporte)
                        {
                            if (TipoReporte == "resumen")
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                                oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;
                                oHoja.Cells[InicioLinea, 3].Value = item.Ruc;
                                oHoja.Cells[InicioLinea, 4].Value = item.RazonSocial;
                                oHoja.Cells[InicioLinea, 5].Value = item.idDocumento;
                                oHoja.Cells[InicioLinea, 6].Value = item.serDocumento;
                                oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;
                                oHoja.Cells[InicioLinea, 8].Value = item.fecDocumento;
                                oHoja.Cells[InicioLinea, 9].Value = item.fecVencimiento;
                                oHoja.Cells[InicioLinea, 10].Value = item.desAbreviatura;
                                oHoja.Cells[InicioLinea, 11].Value = (item.CargoDolares > 0 ? item.CargoDolares : 0);
                                oHoja.Cells[InicioLinea, 12].Value = (item.CargoDolares < 0 ? Math.Abs(item.CargoDolares) : 0);
                                oHoja.Cells[InicioLinea, 13].Value = (item.CargoSoles > 0 ? item.CargoSoles : 0);
                                oHoja.Cells[InicioLinea, 14].Value = (item.CargoSoles < 0 ? Math.Abs(item.CargoSoles) : 0);

                                if (item.CargoDolares > 0)
                                {
                                    TotalDol1 += item.CargoDolares;
                                }
                                else
                                {
                                    TotalDol2 += Math.Abs(item.CargoDolares);
                                }                            

                                if (item.CargoSoles > 0)
                                {
                                    TotalSol1 += item.CargoSoles;
                                }
                                else
                                {
                                    TotalSol2 += Math.Abs(item.CargoSoles);
                                }

                                // FORMAT 
                                oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "dd/MM/yyyy";

                                oHoja.Cells[InicioLinea, 11].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 12].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 13].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 14].Style.Font.Bold = true;
                                InicioLinea++;
                            }
                            else if (TipoReporte == "detalle")
                            {
                                oHoja.Cells[InicioLinea, 1].Value = item.codCuenta;
                                oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;
                                oHoja.Cells[InicioLinea, 3].Value = item.Ruc;
                                oHoja.Cells[InicioLinea, 4].Value = item.RazonSocial;
                                oHoja.Cells[InicioLinea, 5].Value = item.idDocumento;
                                oHoja.Cells[InicioLinea, 6].Value = item.serDocumento;
                                oHoja.Cells[InicioLinea, 7].Value = item.numDocumento;
                                oHoja.Cells[InicioLinea, 8].Value = item.idComprobante;
                                oHoja.Cells[InicioLinea, 9].Value = item.numFile;
                                oHoja.Cells[InicioLinea, 10].Value = item.numVoucher;
                                oHoja.Cells[InicioLinea, 11].Value = item.MesPeriodo;
                                oHoja.Cells[InicioLinea, 12].Value = item.fecCancelacion;
                                oHoja.Cells[InicioLinea, 13].Value = item.fecDocumento;
                                oHoja.Cells[InicioLinea, 14].Value = item.fecVencimiento;
                                oHoja.Cells[InicioLinea, 15].Value = item.tipCambio;
                                oHoja.Cells[InicioLinea, 16].Value = item.idMoneda;
                                oHoja.Cells[InicioLinea, 17].Value = item.Glosa;
                                oHoja.Cells[InicioLinea, 18].Value = item.SaldoDolares;
                                oHoja.Cells[InicioLinea, 19].Value = Math.Abs(item.CargoDolares);
                                oHoja.Cells[InicioLinea, 20].Value = item.SaldoSoles;
                                oHoja.Cells[InicioLinea, 21].Value = Math.Abs(item.CargoSoles);

                                // FORMAT 
                                oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 19].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                                oHoja.Cells[InicioLinea, 21].Style.Numberformat.Format = "###,###,##0.00";

                                oHoja.Cells[InicioLinea, 18].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 19].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 20].Style.Font.Bold = true;
                                oHoja.Cells[InicioLinea, 21].Style.Font.Bold = true;
                                InicioLinea++;
                            }                                                     
                        }

                        if (TipoReporte == "resumen2")
                        {
                            foreach (conCtaCteE item in oListaReporteAgrupadoRes2)
                            {
                                if (codcuenta == String.Empty)
                                {
                                    codcuenta = item.codCuenta;
                                    descuenta = item.desCuenta;

                                    oHoja.Cells[InicioLinea, 1].Value = "Cuenta : " + item.codCuenta;
                                    oHoja.Cells[InicioLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(178, 172, 200));
                                    oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;
                                    oHoja.Cells[InicioLinea, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(178, 172, 200));
                                                                                                   

                                    InicioLinea++;
                                }

                                if (codcuenta != item.codCuenta)
                                {
                                    codcuenta = item.codCuenta;
                                    descuenta = item.desCuenta;

                                    oHoja.Cells[InicioLinea, 1].Value = " ";
                                    oHoja.Cells[InicioLinea, 2].Value = "Saldos Totales : ";
                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                    oHoja.Cells[InicioLinea, 4].Value = " ";
                                    oHoja.Cells[InicioLinea, 5].Value = TotalTot1;
                                    oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, 6].Value = " ";
                                    oHoja.Cells[InicioLinea, 7].Value = " ";
                                    oHoja.Cells[InicioLinea, 8].Value = TotalTot2;
                                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                                    InicioLinea++;

                                    oHoja.Cells[InicioLinea, 1].Value = "Cuenta : " + item.codCuenta;
                                    oHoja.Cells[InicioLinea, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(178, 172, 200));
                                    oHoja.Cells[InicioLinea, 2].Value = item.desCuenta;
                                    oHoja.Cells[InicioLinea, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(178, 172, 200));
                                    InicioLinea++;

                                    TotalTot1 = 0;
                                    TotalTot2 = 0;
                                }

                                if (codcuenta == item.codCuenta)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.Ruc;
                                    oHoja.Cells[InicioLinea, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    oHoja.Cells[InicioLinea, 2].Value = item.RazonSocial;
                                    oHoja.Cells[InicioLinea, 3].Value = item.SaldoDolares;
                                    oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 4].Value = item.CargoDolares;
                                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";
                                    Totaldol = item.SaldoDolares - item.CargoDolares;
                                    oHoja.Cells[InicioLinea, 5].Value = Totaldol;
                                    oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 6].Value = item.SaldoSoles;
                                    oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 7].Value = item.CargoSoles;
                                    oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                                    Totalsol = item.SaldoSoles - item.CargoSoles;
                                    oHoja.Cells[InicioLinea, 8].Value = Totalsol;
                                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                                    InicioLinea++;

                                    codcuenta = item.codCuenta;
                                    descuenta = item.desCuenta;

                                    TotalTot1 += Totaldol;
                                    TotalTot2 += Totalsol;
                                }

                            }


                            oHoja.Cells[InicioLinea, 1].Value = " ";
                            oHoja.Cells[InicioLinea, 2].Value = "Saldos Totales : ";
                            oHoja.Cells[InicioLinea, 3].Value = " ";
                            oHoja.Cells[InicioLinea, 4].Value = " ";
                            oHoja.Cells[InicioLinea, 5].Value = TotalTot1;
                            oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 5].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, 6].Value = " ";
                            oHoja.Cells[InicioLinea, 7].Value = " ";
                            oHoja.Cells[InicioLinea, 8].Value = TotalTot2;
                            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 8].Style.Font.Bold = true;
                            InicioLinea++;
                            TotalTot1 = 0;
                            TotalTot2 = 0;
                        }
                        else
                        {

                            oHoja.Cells[InicioLinea, 7].Value = "TOTALES";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea, 10])
                            {
                                Rango.Merge = true;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                            }
                            oHoja.Cells[InicioLinea, 11].Value = TotalDol1;
                            oHoja.Cells[InicioLinea, 12].Value = TotalDol2;
                            oHoja.Cells[InicioLinea, 13].Value = TotalSol1;
                            oHoja.Cells[InicioLinea, 14].Value = TotalSol2;

                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;


                            oHoja.Cells[InicioLinea, 7].Value = "DIFERENCIA";

                            using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea, 10])
                            {
                                Rango.Merge = true;
                                Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202));
                                Rango.Style.Font.Bold = true;
                                Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Distributed;
                            }

                            if (TotalDol1 > TotalDol2)
                            {
                                Tot1 = TotalDol1 - TotalDol2;
                                oHoja.Cells[InicioLinea, 11].Value = Tot1;
                                oHoja.Cells[InicioLinea, 12].Value = ValCero;
                            }
                            else
                            {
                                Tot1 = TotalDol2 - TotalDol1;
                                oHoja.Cells[InicioLinea, 11].Value = ValCero;
                                oHoja.Cells[InicioLinea, 12].Value = Tot1;
                            }

                            if (TotalSol1 > TotalSol2)
                            {
                                Tot2 = TotalSol1 - TotalSol2;
                                oHoja.Cells[InicioLinea, 13].Value = Tot2;
                                oHoja.Cells[InicioLinea, 14].Value = ValCero;
                            }
                            else
                            {
                                Tot2 = TotalSol2 - TotalSol1;
                                oHoja.Cells[InicioLinea, 13].Value = ValCero;
                                oHoja.Cells[InicioLinea, 14].Value = Tot2;
                            }

                            oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";
                            oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;
                        }

                        #endregion

                        //Ajustando el ancho de las columnas automaticamente
                        oHoja.Cells.AutoFitColumns();

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
                        oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                        oHoja.Workbook.Properties.Comments = "Reporte de " + NombrePestaña;

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
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document((TipoReporte == "detalle" ? PageSize.A4.Rotate() : PageSize.A4), 10f, 10f, 10f, 10f);
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio si no existe...
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
                String SubTitulo = String.Empty;
                PdfPCell cell = null;

                // Para la creacion del archivo pdf
                Guid oGuid = Guid.NewGuid();
                RutaGeneral += oGuid.ToString() + Extension;

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

                    //Parametros Que Pasaras Al PDF
                    PaginaCabeceraReporteCtaCtePendientes ev = new PaginaCabeceraReporteCtaCtePendientes();


                    if (TipoReporte == "detalle")
                    {
                        ev.tamano_cabecera = TamanoCabecera;
                    }
                    else if(TipoReporte == "resumen")
                    {
                        ev.tamano_cabecera = TamanoCabeceraResumen;
                    }
                    else if (TipoReporte == "resumen2")
                    {
                        ev.tamano_cabecera = TamanoCabeceraResumen2;
                    }

                    if (TipoReporte == "detalle")
                    {
                        ev.TotalColumnas = TotalColumnas;
                    }
                    else if (TipoReporte == "resumen")
                    {
                        ev.TotalColumnas = TotalColumnasResumen;
                    }
                    else if (TipoReporte == "resumen2")
                    {
                        ev.TotalColumnas = TotalColumnasResumen2;
                    }

                    ev.WidthTabla = WidthTabla;
                    ev.Tipo_Reporte = TipoReporte;
                    ev.mes_ini = MesIni;
                    ev.mes_fin = MesFin;
                    ev.ano = Anio;
                    
            
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Detalle

                    PdfPTable TablaCabDetalle = new PdfPTable((TipoReporte == "detalle" ? TotalColumnas : TipoReporte == "resumen" ? TotalColumnasResumen : TotalColumnasResumen2))
                    {
                        WidthPercentage = WidthTabla
                    };

                    TablaCabDetalle.SetWidths((TipoReporte == "detalle" ? TamanoCabecera : TipoReporte == "resumen" ? TamanoCabeceraResumen : TamanoCabeceraResumen2));

                    String codcuenta = String.Empty;
                    String descuenta = String.Empty;

                    String ruc = String.Empty;
                    String rucTitulo = String.Empty;

                    Int32 idPersona = 0;
                    String idDocSerDocNum = String.Empty;

                    Decimal subTotalDoc_SaldoDolares = 0;
                    Decimal subTotalDoc_CargoDolares = 0;
                    Decimal subTotalDoc_SaldoSoles = 0;
                    Decimal subTotalDoc_CargoSoles = 0;

                    Decimal subTotalPro_SaldoDolares = 0;
                    Decimal subTotalPro_CargoDolares = 0;
                    Decimal subTotalPro_SaldoSoles = 0;
                    Decimal subTotalPro_CargoSoles = 0;

                    Decimal subTotalCue_SaldoDolares = 0;
                    Decimal subTotalCue_CargoDolares = 0;
                    Decimal subTotalCue_SaldoSoles = 0;
                    Decimal subTotalCue_CargoSoles = 0;

                    Decimal TotalCue_SaldoDolares = 0;
                    Decimal TotalCue_CargoDolares = 0;
                    Decimal TotalCue_SaldoSoles = 0;
                    Decimal TotalCue_CargoSoles = 0;

                    Decimal Totaldol = 0;
                    Decimal Totalsol = 0;
                    Decimal TotalTot1 = 0;
                    Decimal TotalTot2 = 0;

                    Decimal ValorDolar = 0;
                    Decimal ValorSoles = 0;

                    if (rdbDetalle.Checked )
                    {
                        // DETALLE
                        oListaReporte = (from x in oListaReporte
                                         orderby x.codCuenta, x.idPersona, x.idDocumento, x.serDocumento, x.numDocumento
                                         select x).ToList();
                    }
                    else if (rdbResumen.Checked )
                    {
                        // RESUMEN
                        oListaReporte = (from x in oListaReporte orderby x.codCuenta, x.idPersona select x).ToList();
                    }
                    else if (rbRes.Checked)
                    {
                        // RESUMEN
                        oListaReporte = (from x in oListaReporte orderby x.codCuenta select x).ToList();
                    }
                    else
                    {
                        // RESUMEN
                        oListaReporte = (from x in oListaReporte orderby x.idPersona, x.codCuenta select x).ToList();
                    }

                    foreach (conCtaCteE item in oListaReporte)
                    {
                        if (TipoReporte == "detalle")
                        {
                                if (codcuenta == String.Empty)
                                {
                                    codcuenta = item.codCuenta;
                                    descuenta = item.desCuenta;

                                    cell = PdfPCell(" Cuenta : " + item.codCuenta + " - " + item.desCuenta, 6f, "left", "bold");
                                    cell.Colspan = TotalColumnas;
                                    TablaCabDetalle.AddCell(cell);
                                    TablaCabDetalle.CompleteRow();

                                    idPersona = item.idPersona;

                                    cell = PdfPCell(" Proveedor : " + item.Ruc + " - " + item.RazonSocial, 6f, "left", "bold");
                                    cell.Colspan = TotalColumnas;
                                    TablaCabDetalle.AddCell(cell);
                                    TablaCabDetalle.CompleteRow();

                                    idDocSerDocNum = item.idDocumento + item.serDocumento + item.numDocumento;
                                }

                                if (codcuenta != item.codCuenta)
                                {
                                    // sub totales documento
                                    cell = PdfPCell(" Documento : ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    ValorDolar = (subTotalDoc_SaldoDolares - Math.Abs(subTotalDoc_CargoDolares));
                                    ValorSoles = (subTotalDoc_SaldoSoles - Math.Abs(subTotalDoc_CargoSoles));

                                    cell = PdfPCell((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    subTotalDoc_SaldoDolares = 0;
                                    subTotalDoc_CargoDolares = 0;
                                    subTotalDoc_SaldoSoles = 0;
                                    subTotalDoc_CargoSoles = 0;

                                    // sub totales proveedor
                                    cell = PdfPCell(" Proveedor : ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalPro_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalPro_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalPro_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalPro_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    cell = PdfPCell(" ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    ValorDolar = (subTotalPro_SaldoDolares - subTotalPro_CargoDolares);
                                    ValorSoles = (subTotalPro_SaldoSoles - subTotalPro_CargoSoles);

                                    cell = PdfPCell_((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    subTotalPro_SaldoDolares = 0;
                                    subTotalPro_CargoDolares = 0;
                                    subTotalPro_SaldoSoles = 0;
                                    subTotalPro_CargoSoles = 0;

                                    // sub totales cuenta
                                    cell = PdfPCell(" Cuenta " + codcuenta + " - " + descuenta + " : ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalCue_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalCue_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalCue_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalCue_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    cell = PdfPCell(" ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    ValorDolar = (subTotalCue_SaldoDolares - Math.Abs(subTotalCue_CargoDolares));
                                    ValorSoles = (subTotalCue_SaldoSoles - Math.Abs(subTotalCue_CargoSoles));

                                    cell = PdfPCell_((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    subTotalCue_SaldoDolares = 0;
                                    subTotalCue_CargoDolares = 0;
                                    subTotalCue_SaldoSoles = 0;
                                    subTotalCue_CargoSoles = 0;

                                    codcuenta = item.codCuenta;
                                    descuenta = item.desCuenta;

                                    cell = PdfPCell(" Cuenta : " + item.codCuenta + " - " + item.desCuenta, 6f, "left", "bold");
                                    cell.Colspan = TotalColumnas;
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    idPersona = item.idPersona;

                                    cell = PdfPCell(" Proveedor : " + item.Ruc + " - " + item.RazonSocial, 6f, "left", "bold");
                                    cell.Colspan = TotalColumnas;
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    idDocSerDocNum = item.idDocumento + item.serDocumento + item.numDocumento;
                                }

                                if (idPersona != item.idPersona)
                                {
                                    // sub totales documento
                                    cell = PdfPCell(" Documento : ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    ValorDolar = (subTotalDoc_SaldoDolares - subTotalDoc_CargoDolares);
                                    ValorSoles = (subTotalDoc_SaldoSoles - subTotalDoc_CargoSoles);

                                    cell = PdfPCell((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    subTotalDoc_SaldoDolares = 0;
                                    subTotalDoc_CargoDolares = 0;
                                    subTotalDoc_SaldoSoles = 0;
                                    subTotalDoc_CargoSoles = 0;

                                    // sub totales proveedor
                                    cell = PdfPCell(" Proveedor : ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalPro_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalPro_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalPro_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_(subTotalPro_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    cell = PdfPCell(" ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    ValorDolar = (subTotalPro_SaldoDolares - subTotalPro_CargoDolares);
                                    ValorSoles = (subTotalPro_SaldoSoles - subTotalPro_CargoSoles);

                                    cell = PdfPCell_((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell_((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    subTotalPro_SaldoDolares = 0;
                                    subTotalPro_CargoDolares = 0;
                                    subTotalPro_SaldoSoles = 0;
                                    subTotalPro_CargoSoles = 0;

                                    idPersona = item.idPersona;

                                    cell = PdfPCell(" proveedor : " + item.Ruc + " - " + item.RazonSocial, 6f, "left", "bold");
                                    cell.Colspan = TotalColumnas;
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    idDocSerDocNum = item.idDocumento + item.serDocumento + item.numDocumento;
                                }

                                String Documento = item.idDocumento + item.serDocumento + item.numDocumento;

                                if (idDocSerDocNum != Documento)
                                {
                                    // sub totales documento
                                    cell = PdfPCell(" Documento : ", 6f, "rigth", "bold");
                                    cell.Colspan = 11;
                                    TablaCabDetalle.AddCell(cell);

                                    ValorDolar = (subTotalDoc_SaldoDolares - Math.Abs(subTotalDoc_CargoDolares));
                                    ValorSoles = (subTotalDoc_SaldoSoles - Math.Abs(subTotalDoc_CargoSoles));

                                    cell = PdfPCell((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    cell = PdfPCell((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                    TablaCabDetalle.AddCell(cell);

                                    TablaCabDetalle.CompleteRow();

                                    subTotalDoc_SaldoDolares = 0;
                                    subTotalDoc_CargoDolares = 0;
                                    subTotalDoc_SaldoSoles = 0;
                                    subTotalDoc_CargoSoles = 0;

                                    idDocSerDocNum = item.idDocumento + item.serDocumento + item.numDocumento;
                                }
                            
                            // DETALLE
                            cell = PdfPCell(item.idComprobante, 6f, "center", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.numFile, 6f, "center", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.numVoucher, 6f, "center", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.MesPeriodo, 6f, "center", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.fecCancelacion.Value.ToString("dd/MM/yyyy"), 6f, "center", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            if (item.fecDocumento != null)
                            {
                                cell = PdfPCell(item.fecDocumento.Value.ToString("dd/MM/yyyy"), 6f, "center", String.Empty);
                                TablaCabDetalle.AddCell(cell);
                            }
                            else
                            {
                                cell = PdfPCell(" ", 6f, "center", String.Empty);
                                TablaCabDetalle.AddCell(cell);
                            }

                            cell = PdfPCell(item.tipCambio.ToString(), 6f, "center", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.idMoneda, 6f, "center", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.Glosa, 6f, "left", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.idDocumento + " " + item.serDocumento + " " + item.numDocumento, 6f, "left", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.fecVencimiento.Value.ToString("d"), 6f, "left", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(Math.Abs(item.CargoDolares).ToString("###,###,##0.00"), 6f, "rigth", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(Math.Abs(item.CargoSoles).ToString("###,###,##0.00"), 6f, "rigth", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            subTotalDoc_SaldoDolares += item.SaldoDolares;
                            subTotalDoc_CargoDolares += item.CargoDolares;
                            subTotalDoc_SaldoSoles += item.SaldoSoles;
                            subTotalDoc_CargoSoles += item.CargoSoles;

                            subTotalPro_SaldoDolares += item.SaldoDolares;
                            subTotalPro_CargoDolares += item.CargoDolares;
                            subTotalPro_SaldoSoles += item.SaldoSoles;
                            subTotalPro_CargoSoles += item.CargoSoles;

                            subTotalCue_SaldoDolares += item.SaldoDolares;
                            subTotalCue_CargoDolares += item.CargoDolares;
                            subTotalCue_SaldoSoles += item.SaldoSoles;
                            subTotalCue_CargoSoles += item.CargoSoles;

                            TotalCue_SaldoDolares += item.SaldoDolares;
                            TotalCue_CargoDolares += item.CargoDolares;
                            TotalCue_SaldoSoles += item.SaldoSoles;
                            TotalCue_CargoSoles += item.CargoSoles;

                            TablaCabDetalle.CompleteRow();
                        }
                        else if (TipoReporte == "resumen")
                        {
                            if (codcuenta == String.Empty)
                            {
                                codcuenta = item.codCuenta;
                                descuenta = item.desCuenta;

                                cell = PdfPCell("Cuenta : " + item.codCuenta, 6f, "left", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.desCuenta, 6f, "left", "bold");
                                cell.Colspan = 8;
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                            }

                            if (codcuenta != item.codCuenta)
                            {
                                // CUENTA
                                cell = PdfPCell(" Cuenta " + codcuenta + " - " + descuenta + " : ", 6f, "rigth", "bold");
                                cell.Colspan = 5;
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_(subTotalCue_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_(subTotalCue_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_(subTotalCue_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_(subTotalCue_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                cell = PdfPCell(" ", 6f, "rigth", "bold");
                                cell.Colspan = 5;
                                TablaCabDetalle.AddCell(cell);

                                ValorDolar = (subTotalCue_SaldoDolares - subTotalCue_CargoDolares);
                                ValorSoles = (subTotalCue_SaldoSoles - subTotalCue_CargoSoles);

                                cell = PdfPCell_((subTotalCue_SaldoDolares > subTotalCue_CargoDolares ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_((subTotalCue_SaldoDolares < subTotalCue_CargoDolares ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_((subTotalCue_SaldoSoles > subTotalCue_CargoSoles ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_((subTotalCue_SaldoSoles < subTotalCue_CargoSoles ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                subTotalCue_SaldoDolares = 0;
                                subTotalCue_CargoDolares = 0;
                                subTotalCue_SaldoSoles = 0;
                                subTotalCue_CargoSoles = 0;

                                codcuenta = item.codCuenta;
                                descuenta = item.desCuenta;

                                cell = PdfPCell("Cuenta : " + item.codCuenta, 6f, "left", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.desCuenta, 6f, "left", "bold");
                                cell.Colspan = 8;
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                            }

                            if (ruc == item.Ruc)
                                rucTitulo = String.Empty;

                            if (ruc == String.Empty)
                            {
                                ruc = item.Ruc;
                                rucTitulo = ruc;
                            }

                            if (ruc != item.Ruc)
                            {
                                ruc = item.Ruc;
                                rucTitulo = ruc;
                            }

                            cell = PdfPCell(rucTitulo, 6f, "left", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell((rucTitulo == String.Empty ? String.Empty : item.RazonSocial), 6f, "left", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.idDocumento + " " + item.serDocumento + " " + item.numDocumento, 6f, "left", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.fecDocumento.Value.ToString("d"), 6f, "left", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell(item.fecVencimiento.Value.ToString("d"), 6f, "left", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell((item.CargoDolares > 0 ? item.CargoDolares : 0).ToString("###,###,##0.00"), 6f, "rigth", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell((item.CargoDolares < 0 ? Math.Abs(item.CargoDolares) : 0).ToString("###,###,##0.00"), 6f, "rigth", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell((item.CargoSoles > 0 ? item.CargoSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            cell = PdfPCell((item.CargoSoles < 0 ? Math.Abs(item.CargoSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", String.Empty);
                            TablaCabDetalle.AddCell(cell);

                            subTotalCue_SaldoDolares += (item.CargoDolares > 0 ? item.CargoDolares : 0);
                            subTotalCue_CargoDolares += (item.CargoDolares < 0 ? Math.Abs(item.CargoDolares) : 0);
                            subTotalCue_SaldoSoles += (item.CargoSoles > 0 ? item.CargoSoles : 0);
                            subTotalCue_CargoSoles += (item.CargoSoles < 0 ? Math.Abs(item.CargoSoles) : 0);

                            TotalCue_SaldoDolares += (item.CargoDolares > 0 ? item.CargoDolares : 0);
                            TotalCue_CargoDolares += (item.CargoDolares < 0 ? Math.Abs(item.CargoDolares) : 0);
                            TotalCue_SaldoSoles += (item.CargoSoles > 0 ? item.CargoSoles : 0);
                            TotalCue_CargoSoles += (item.CargoSoles < 0 ? Math.Abs(item.CargoSoles) : 0);

                            TablaCabDetalle.CompleteRow();
                        }
                    }

                    if (TipoReporte == "resumen2")
                    {
                        foreach (conCtaCteE item in oListaReporteAgrupadoRes2)
                        {
                            if (codcuenta == String.Empty)
                            {
                                codcuenta = item.codCuenta;
                                descuenta = item.desCuenta;

                                cell = PdfPCell("Cuenta : " + item.codCuenta, 6f, "left", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.desCuenta, 6f, "left", "bold");
                                cell.Colspan = 7;
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                            }

                            if (codcuenta != item.codCuenta)
                            {
                                codcuenta = item.codCuenta;
                                descuenta = item.desCuenta;


                                cell = PdfPCell("Saldos Totales : ", 6f, "rigth", "bold");
                                cell.Colspan = 4;
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_(TotalTot1.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(" ", 6f, "rigth", "bold");
                                cell.Colspan = 2;
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell_(TotalTot2.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);
                                TablaCabDetalle.CompleteRow();


                                cell = PdfPCell("Cuenta : " + item.codCuenta, 6f, "left", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.desCuenta, 6f, "left", "bold");
                                cell.Colspan = 7;
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();

                                TotalTot1 = 0;
                                TotalTot2 = 0;
                            }

                            if (codcuenta == item.codCuenta)
                            {
                                cell = PdfPCell(item.Ruc, 6f, "center", String.Empty);
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.RazonSocial, 6f, "left", String.Empty);
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                Totaldol = item.SaldoDolares - item.CargoDolares;
                                cell = PdfPCell_(Totaldol.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                cell = PdfPCell(item.CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);

                                Totalsol = item.SaldoSoles - item.CargoSoles;
                                cell = PdfPCell_(Totalsol.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                                TablaCabDetalle.AddCell(cell);


                                TablaCabDetalle.CompleteRow();

                                codcuenta = item.codCuenta;
                                descuenta = item.desCuenta;

                                TotalTot1 += Totaldol;
                                TotalTot2 += Totalsol;
                            }

                        }
                    }

                    if (TipoReporte == "detalle")
                    {
                        // sub totales documento
                        cell = PdfPCell(" Documento : ", 6f, "rigth", "bold");
                        cell.Colspan = 11;
                        TablaCabDetalle.AddCell(cell);

                        ValorDolar = (subTotalDoc_SaldoDolares - subTotalDoc_CargoDolares);
                        ValorSoles = (subTotalDoc_SaldoSoles - subTotalDoc_CargoSoles);

                        cell = PdfPCell((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // sub totales proveedor
                        cell = PdfPCell(" Proveedor : ", 6f, "rigth", "bold");
                        cell.Colspan = 11;
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalPro_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalPro_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalPro_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalPro_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = PdfPCell(" ", 6f, "rigth", "bold");
                        cell.Colspan = 11;
                        TablaCabDetalle.AddCell(cell);

                        ValorDolar = (subTotalPro_SaldoDolares - Math.Abs(subTotalPro_CargoDolares));
                        ValorSoles = (subTotalPro_SaldoSoles - Math.Abs(subTotalPro_CargoSoles));

                        cell = PdfPCell_((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        subTotalPro_SaldoDolares = 0;
                        subTotalPro_CargoDolares = 0;
                        subTotalPro_SaldoSoles = 0;
                        subTotalPro_CargoSoles = 0;

                        // sub totales cuenta
                        cell = PdfPCell(" Cuenta " + codcuenta + " - " + descuenta + " : ", 6f, "rigth", "bold");
                        cell.Colspan = 11;
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalCue_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalCue_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalCue_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalCue_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = PdfPCell(" ", 6f, "rigth", "bold");
                        cell.Colspan = 11;
                        TablaCabDetalle.AddCell(cell);

                        ValorDolar = (subTotalCue_SaldoDolares - Math.Abs(subTotalCue_CargoDolares));
                        ValorSoles = (subTotalCue_SaldoSoles - Math.Abs(subTotalCue_CargoSoles));

                        cell = PdfPCell_((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // TOTALES CUENTA 
                        cell = PdfPCell(" ", 6f, "rigth", "bold");
                        cell.Colspan = TotalColumnas;
                        TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();

                        cell = PdfPCell(" TOTAL GENERAL : ", 6f, "rigth", "bold");
                        cell.Colspan = 11;
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalCue_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalCue_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalCue_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalCue_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = PdfPCell(" ", 6f, "rigth", "bold");
                        cell.Colspan = 11;
                        TablaCabDetalle.AddCell(cell);

                        ValorDolar = (TotalCue_SaldoDolares - Math.Abs(TotalCue_CargoDolares));
                        ValorSoles = (TotalCue_SaldoSoles - Math.Abs(TotalCue_CargoSoles));

                        cell = PdfPCell_((ValorDolar > 0 ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorDolar < 0 ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorSoles > 0 ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((ValorSoles < 0 ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }
                    else if (TipoReporte == "resumen")
                    {
                        // CUENTA
                        cell = PdfPCell(" Cuenta " + codcuenta + " - " + descuenta + " : ", 6f, "rigth", "bold");
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalCue_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalCue_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalCue_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(subTotalCue_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = PdfPCell(" ", 6f, "rigth", "bold");
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        ValorDolar = (subTotalCue_SaldoDolares - subTotalCue_CargoDolares);
                        ValorSoles = (subTotalCue_SaldoSoles - subTotalCue_CargoSoles);

                        cell = PdfPCell_((subTotalCue_SaldoDolares > subTotalCue_CargoDolares ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((subTotalCue_SaldoDolares < subTotalCue_CargoDolares ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((subTotalCue_SaldoSoles > subTotalCue_CargoSoles ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((subTotalCue_SaldoSoles < subTotalCue_CargoSoles ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        // TOTALES RESUMEN
                        cell = PdfPCell(" ", 6f, "rigth", "bold");
                        cell.Colspan = TotalColumnasResumen;
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = PdfPCell(" TOTAL GENERAL : ", 6f, "rigth", "bold");
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalCue_SaldoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalCue_CargoDolares.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalCue_SaldoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalCue_CargoSoles.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();

                        cell = PdfPCell(" ", 6f, "rigth", "bold");
                        cell.Colspan = 5;
                        TablaCabDetalle.AddCell(cell);

                        ValorDolar = (TotalCue_SaldoDolares - TotalCue_CargoDolares);
                        ValorSoles = (TotalCue_SaldoSoles - TotalCue_CargoSoles);

                        cell = PdfPCell_((TotalCue_SaldoDolares > TotalCue_CargoDolares ? ValorDolar : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((TotalCue_SaldoDolares < TotalCue_CargoDolares ? Math.Abs(ValorDolar) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((TotalCue_SaldoSoles > TotalCue_CargoSoles ? ValorSoles : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_((TotalCue_SaldoSoles < TotalCue_CargoSoles ? Math.Abs(ValorSoles) : 0).ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        TablaCabDetalle.CompleteRow();
                    }
                    else if (TipoReporte == "resumen2")
                    {
                        cell = PdfPCell("Saldos Totales : ", 6f, "rigth", "bold");
                        cell.Colspan = 4;
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalTot1.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell(" ", 6f, "rigth", "bold");
                        cell.Colspan = 2;
                        TablaCabDetalle.AddCell(cell);

                        cell = PdfPCell_(TotalTot2.ToString("###,###,##0.00"), 6f, "rigth", "bold");
                        TablaCabDetalle.AddCell(cell);
                        TablaCabDetalle.CompleteRow();
                        TotalTot1 = 0;
                        TotalTot2 = 0;
                    }


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

        void BloquearBotones(Boolean estado)
        {
            btBuscar.Enabled = estado;
            panel5.Enabled = estado;
            panel4.Enabled = estado;
            panel1.Enabled = estado;
            //panel2.Enabled = estado;
            panel6.Enabled = estado;
            panel7.Enabled = estado;
        }

        PdfPCell PdfPCell(String texto, float tamano_letra, String align, String negrita)
        {
            return new PdfPCell(new Paragraph(texto, FontFactory.GetFont("Arial", tamano_letra, (negrita == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)))) { Border = 0, HorizontalAlignment = (align == "center" ? Element.ALIGN_CENTER : (align == "left" ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

        PdfPCell PdfPCell_(String texto, float tamano_letra, String align, String negrita)
        {
            return new PdfPCell(new Paragraph(texto, FontFactory.GetFont("Arial", tamano_letra, (negrita == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL)))) { HorizontalAlignment = (align == "center" ? Element.ALIGN_CENTER : (align == "left" ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT)), VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                if (oListaReporte == null || oListaReporte.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                NombreAchivo = "Cuenta Corriente Pendientes " + cboAño.Text + " de " + cboInicio.Text + " a " + cboFin.Text;

                if (cboInicio.Text == cboFin.Text)
                    NombreAchivo = "Cuenta Corriente Pendientes " + cboAño.Text + " de " + cboInicio.Text;

                RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", NombreAchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaExcel))
                {
                    TipoAccion = "exportar";

                    pbProgress.Visible = true;
                    BloquearBotones(false);

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
                if (TipoAccion == "buscar")
                {
                    Boolean MonedaOrigen = true;

                    if (rdbAmbasMn.Checked)
                    {
                      MonedaOrigen = false;
                    }

                    if (rdbMnOrigen.Checked)
                    {
                        MonedaOrigen = true;
                    }

                    lblProcesando.Text = "Obteniendo la información de Pendientes.";
                    oListaReporte = AgenteContabilidad.Proxy.ReporteConCtaCtePendientes(idEmpresa, PlanCuenta, Anio, CuentaIni, CuentaFin, idPersona, MesIni, MesFin, String.Empty, "S", TipoReporte);

                    if (oListaReporte != null && oListaReporte.Count > 0)
                    {
                        // Detallado solo pendientes
                        if (rdbDetalle.Checked)
                        {
                            if (!chbCancelados.Checked)
                            {
                                List<conCtaCteE> oListaReporteAgrupado = new List<conCtaCteE>(from x in oListaReporte
                                                                                              group x by x.codCuenta + x.idPersona + x.idDocumento + x.serDocumento + x.numDocumento + x.idMoneda
                                                                                              into g select g.First()).ToList();
                                Decimal valor_d_dolar = 0;
                                Decimal valor_h_dolar = 0;
                                Decimal valor_d_soles = 0;
                                Decimal valor_h_soles = 0;

                                List<conCtaCteE> oListaReporte_temporal = new List<conCtaCteE>(oListaReporte);

                                for (Int32 i = 0; i < oListaReporteAgrupado.Count; i++)
                                {
                                    List<conCtaCteE> oListaReporte_tmp = new List<conCtaCteE>((from x in oListaReporte_temporal
                                                                                               where oListaReporteAgrupado[i].codCuenta == x.codCuenta
                                                                                               && oListaReporteAgrupado[i].idPersona == x.idPersona
                                                                                               && oListaReporteAgrupado[i].idDocumento == x.idDocumento
                                                                                               && oListaReporteAgrupado[i].serDocumento == x.serDocumento
                                                                                               && oListaReporteAgrupado[i].numDocumento == x.numDocumento
                                                                                               && oListaReporteAgrupado[i].idMoneda == x.idMoneda
                                                                                               select x).ToList());

                                    valor_d_dolar = oListaReporte_tmp.Sum(x => x.SaldoDolares);
                                    valor_h_dolar = oListaReporte_tmp.Sum(x => x.CargoDolares);
                                    valor_d_soles = oListaReporte_tmp.Sum(x => x.SaldoSoles);
                                    valor_h_soles = oListaReporte_tmp.Sum(x => x.CargoSoles);

                                    if (MonedaOrigen)
                                    {
                                        if ((oListaReporteAgrupado[i].idMoneda == "01" && (valor_d_soles - valor_h_soles) == 0) || (oListaReporteAgrupado[i].idMoneda == "02" && (valor_d_dolar - valor_h_dolar) == 0))
                                        {
                                            List<conCtaCteE> oListaReporte_eli = new List<conCtaCteE>((from x in oListaReporte_temporal
                                                                                                       where oListaReporteAgrupado[i].codCuenta == x.codCuenta
                                                                                                       && oListaReporteAgrupado[i].idPersona == x.idPersona 
                                                                                                       && oListaReporteAgrupado[i].idDocumento == x.idDocumento 
                                                                                                       && oListaReporteAgrupado[i].serDocumento == x.serDocumento 
                                                                                                       && oListaReporteAgrupado[i].numDocumento == x.numDocumento
                                                                                                       select x).ToList());
                                            foreach (conCtaCteE ite in oListaReporte_eli)
                                            {
                                                oListaReporte.Remove(ite);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ((valor_d_dolar - valor_h_dolar) == 0 && (valor_d_soles - valor_h_soles) == 0)
                                        {
                                            List<conCtaCteE> oListaReporte_eli = new List<conCtaCteE>((from x in oListaReporte_temporal
                                                                                                       where oListaReporteAgrupado[i].codCuenta == x.codCuenta
                                                                                                       && oListaReporteAgrupado[i].idPersona == x.idPersona
                                                                                                       && oListaReporteAgrupado[i].idDocumento == x.idDocumento
                                                                                                       && oListaReporteAgrupado[i].serDocumento == x.serDocumento
                                                                                                       && oListaReporteAgrupado[i].numDocumento == x.numDocumento
                                                                                                       select x).ToList());
                                            foreach (conCtaCteE ite in oListaReporte_eli)
                                            {
                                                oListaReporte.Remove(ite);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                        // RESUMEN solo pendientes
                        if (rdbResumen.Checked)
                        {
                            if (!chbCancelados.Checked)
                            {
                                List<conCtaCteE> oListaReporteAgrupado = new List<conCtaCteE>(oListaReporte);

                                foreach (conCtaCteE item in oListaReporteAgrupado)
                                {
                                    if (MonedaOrigen)
                                    {
                                        if ((item.idMoneda == "01" && item.CargoSoles == 0) || (item.idMoneda == "02" && item.CargoDolares == 0))
                                        {
                                            oListaReporte.Remove(item);
                                        }

                                    }
                                    else
                                    {
                                        if (item.CargoDolares == 0 && item.CargoSoles == 0)
                                        {
                                            oListaReporte.Remove(item);
                                        }
                                    }
                                }
                            }
                        }

                        if (rbRes.Checked)
                        {
                            oListaReporteAgrupadoRes2 = new List<conCtaCteE>(from x in oListaReporte
                                                                             group x by new
                                                                             {
                                                                                 x.codCuenta ,
                                                                                 x.Ruc
                                                                             } into g
                                                                             select g.First()).OrderBy(x => x.codCuenta).ToList();

                            foreach (conCtaCteE item in oListaReporteAgrupadoRes2)
                            {
                                item.SaldoDolares = (from x in oListaReporte where x.Ruc == item.Ruc  select x.SaldoDolares).Sum();
                                item.CargoDolares = (from x in oListaReporte where x.Ruc == item.Ruc select x.CargoDolares).Sum();
                                item.SaldoSoles = (from x in oListaReporte where x.Ruc == item.Ruc select x.SaldoSoles).Sum();
                                item.CargoSoles = (from x in oListaReporte where x.Ruc == item.Ruc select x.CargoSoles).Sum();
                            }
                        }

                        lblProcesando.Text = "Armando el reporte...";
                        ConvertirApdf();
                    }
                }

                if (TipoAccion == "exportar")
                {
                    ExportarExcel(RutaExcel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            BloquearBotones(true);
            lblProcesando.Visible = false;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                if (TipoAccion == "buscar")
                {
                    if (oListaReporte == null || oListaReporte.Count == 0)
                    {
                        RutaGeneral = String.Empty;
                        Global.MensajeFault("No hay Datos.");
                    }

                    if (!String.IsNullOrEmpty(RutaGeneral))
                    {
                        wbNavegador.Navigate(RutaGeneral);
                        RutaGeneral = String.Empty;
                    }
                }

                if (TipoAccion == "exportar")
                {
                    Global.MensajeComunicacion("Se genero el archivo");
                }
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmReporteCtaCtePendientes_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (pnlContenedor.Width - pbProgress.Width) / 2;
            pbProgress.Top = (pnlContenedor.Height - pbProgress.Height) / 2;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkTodasCtas.Checked)
                {
                    if (txtCuentaInicial.Text.Trim().Length == 0)
                    {
                        Global.MensajeFault("Debe de ingresar la Cuenta Inicial");
                        return;
                    }

                    if (txtCuentaFin.Text.Trim().Length == 0)
                    {
                        Global.MensajeFault("Debe de ingresar la Cuenta Fin");
                        return;
                    }
                }

                if (!chkProveedor.Checked)
                {
                    if (idPersona == 0)
                    {
                        Global.MensajeFault("Debe de seleccionar un Proveedor");
                        return;
                    }
                }

                TipoAccion = "buscar";

                pbProgress.Visible = true;
                BloquearBotones(false);

                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                PlanCuenta = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                Anio = cboAño.SelectedValue.ToString();
                CuentaIni = txtCuentaInicial.Text;
                CuentaFin = txtCuentaFin.Text;
                MesIni = cboInicio.SelectedValue.ToString();
                MesFin = cboFin.SelectedValue.ToString();
                TipoReporte = (rdbResumen.Checked ? "resumen" : rdbDetalle.Checked ?  "detalle" : "resumen2");
                lblProcesando.Visible = true;
                lblProcesando.Text = String.Empty;
                Global.QuitarReferenciaWebBrowser(wbNavegador);

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProveedor.Checked)
            {
                idPersona = 0;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                btBuscar.Focus();
            }
            else
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                txtRuc.Focus();
            }
        }

        private void btnCuentaInicio_Click(object sender, EventArgs e)
        {
            frmBuscarCuentasCte frm = new frmBuscarCuentasCte();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCuentaInicial.Text = frm.Cuentas.codCuenta;
                txtdesCuentaInicial.Text = frm.Cuentas.Descripcion;
            }
        }

        private void btnCuentaFin_Click(object sender, EventArgs e)
        {
            frmBuscarCuentasCte frm = new frmBuscarCuentasCte();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCuentaFin.Text = frm.Cuentas.codCuenta;
                txtDesCuentaFin.Text = frm.Cuentas.Descripcion;
            }
        }

        private void rdbResumen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbResumen.Checked)
            {
                chbPendientes.Enabled = false;
                chbCancelados.Enabled = false;
                //BloquearOpcion(EnumOpcionMenuBarra.Exportar, false);
            }
        }

        private void rdbDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDetalle.Checked)
            {
                chbPendientes.Enabled = true;
                chbCancelados.Enabled = true;
                //BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            }
        }

        private void txtCuentaInicial_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCuentaInicial.TextLength > 0)
                {
                    PlanCuentasE Plan = new PlanCuentasE();
                    Plan = AgenteContabilidad.Proxy.ObtenerPlanCuentasPorCodigo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtCuentaInicial.Text);

                    if (Plan != null)
                    {
                        txtdesCuentaInicial.Text = Plan.Descripcion;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCuentaFin_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCuentaFin.TextLength > 0)
                {
                    PlanCuentasE Plan = new PlanCuentasE();
                    Plan = AgenteContabilidad.Proxy.ObtenerPlanCuentasPorCodigo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtCuentaFin.Text);

                    if (Plan != null)
                    {
                        txtDesCuentaFin.Text = Plan.Descripcion;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkTodasCtas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodasCtas.Checked)
            {
                txtCuentaInicial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtCuentaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtdesCuentaInicial.Text = String.Empty;
                txtDesCuentaFin.Text = String.Empty;
                btnCuentaInicio.Enabled = false;
                btnCuentaFin.Enabled = false;
                btBuscar.Focus();
            }
            else
            {
                txtCuentaInicial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                txtCuentaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                txtdesCuentaInicial.Text = String.Empty;
                txtDesCuentaFin.Text = String.Empty;
                btnCuentaInicio.Enabled = true;
                btnCuentaFin.Enabled = true;
                txtCuentaInicial.Focus();
            }
        }

        private void cboAño_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboInicio.Focus();
        }

        private void cboInicio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboFin.Focus();
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            idPersona = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            
                            btBuscar.Focus();
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        idPersona = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        btBuscar.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        idPersona = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
            idPersona = 0;
            txtRazonSocial.Text = String.Empty;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
        }
        
        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            idPersona = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            
                            btBuscar.Focus();
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        idPersona = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        btBuscar.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        idPersona = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.TextChanged -= txtRuc_TextChanged;
            idPersona = 0;
            txtRuc.Text = String.Empty;
            txtRuc.TextChanged += txtRuc_TextChanged;
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (pnlContenedor.Width - lblProcesando.Width) / 2;
            lblProcesando.Top = ((pnlContenedor.Height - pbProgress.Height) + (pbProgress.Height + 150)) / 2;
        }

        #endregion Eventos

    }

    class PaginaCabeceraReporteCtaCtePendientes : PdfPageEventHelper
    {
        public float[] tamano_cabecera { get; set; }
        public Int32 TotalColumnas { get; set; }
        public Int32 WidthTabla { get; set; }
        public String Tipo_Reporte { get; set; }
        public String mes_ini { get; set; }
        public String mes_fin { get; set; }
        public String ano { get; set; }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            String TituloGeneral = String.Empty;
            String SubTitulo = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");
            PdfPCell cell = null;

            TituloGeneral = "PENDIENTES POR CUENTA CONTABLE";

            String nombre_mes = (Convert.ToInt32(mes_ini) == 0 ? "APERTURA" : (Convert.ToInt32(mes_ini) == 13 ? "CIERRE" : FechasHelper.NombreMes(Convert.ToInt32(mes_ini))));
            String nombres_mes_fin = (Convert.ToInt32(mes_fin) == 0 ? "APERTURA" : (Convert.ToInt32(mes_fin) == 13 ? "CIERRE" : FechasHelper.NombreMes(Convert.ToInt32(mes_fin))));

            SubTitulo = "Del Mes de " + nombre_mes + " a " + nombres_mes_fin.ToUpper() + " del " + ano;

            // Cabecera del Reporte
            PdfPTable table = new PdfPTable(2);

            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 0.9f, 0.15f });
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            #region Cabacera Pagina

            cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.RazonSocial, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("Fecha : " + FechaActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);

            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph("RUC     " + VariablesLocales.SesionUsuario.Empresa.RUC, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("Hora :   " + HoraActual, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph(VariablesLocales.SesionUsuario.Empresa.DireccionCompleta, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            cell = new PdfPCell(new Paragraph("Pag. :   " + writer.PageNumber, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD))) { Border = 0 };
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD))) { Border = 0 };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada 

            #endregion

            #region Titulos Principales

            cell = new PdfPCell(new Paragraph(TituloGeneral, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            cell = new PdfPCell(new Paragraph(SubTitulo, FontFactory.GetFont("Arial", 8))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER };
            cell.Colspan = 2;
            table.AddCell(cell);
            table.CompleteRow(); //Fila completada

            //Fila en blanco
            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 7.25f))) { Border = 0 };
            cell.Colspan = 2;
            table.AddCell(cell);

            table.CompleteRow(); //Fila completada 

            #endregion

            document.Add(table); //Añadiendo la tabla al documento PDF

            #region Cabecera del Detalle

            // TABLA CABECERA
            PdfPTable TablaCabDetalle = new PdfPTable(this.TotalColumnas);
            TablaCabDetalle.WidthPercentage = this.WidthTabla;
            TablaCabDetalle.SetWidths(this.tamano_cabecera);

            #region Primera Linea

            if (Tipo_Reporte == "detalle")
            {
                cell = new PdfPCell(new Paragraph("Comprobante", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 3;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Periodo", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("F.Operación", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("F.Doc.", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("T.C.", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Mon", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Glosa", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);
            }
            else
            {
                cell = new PdfPCell(new Paragraph("Ruc", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Proveedor", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);
            }

            if (Tipo_Reporte == "resumen"|| Tipo_Reporte == "detalle")
            {
                cell = new PdfPCell(new Paragraph("Documento", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);

                if (Tipo_Reporte == "resumen")
                {
                    cell = new PdfPCell(new Paragraph("Fecha Doc.", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                    cell.Rowspan = 2;
                    TablaCabDetalle.AddCell(cell);
                }            

                cell = new PdfPCell(new Paragraph("Fecha Ven.", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Rowspan = 2;
                TablaCabDetalle.AddCell(cell);
            }

            if (Tipo_Reporte != "resumen2")
            {
                cell = new PdfPCell(new Paragraph((this.Tipo_Reporte == "resumen" ? "Saldo Dolares" : "Dolares"), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 2;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph((this.Tipo_Reporte == "resumen" ? "Saldo Soles" : "Soles"), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 2;
                TablaCabDetalle.AddCell(cell);

            }
            else if (Tipo_Reporte == "resumen2")
            {
                cell = new PdfPCell(new Paragraph( "Saldo Dolares" , FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 3;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Saldo Soles" , FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 3;
                TablaCabDetalle.AddCell(cell);
            }

            TablaCabDetalle.CompleteRow();

            #endregion

            #region Segunda Linea

            if (Tipo_Reporte == "detalle")
            {
                cell = new PdfPCell(new Paragraph(" Diario ", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" File ", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" Comprob. ", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);
            }

            if (Tipo_Reporte == "resumen" || Tipo_Reporte == "detalle")
            {

                cell = new PdfPCell(new Paragraph((this.Tipo_Reporte == "resumen" ? "Debe" : "Debe"), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph((this.Tipo_Reporte == "resumen" ? "Haber" : "Haber"), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph((this.Tipo_Reporte == "resumen" ? "Debe" : "Debe"), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph((this.Tipo_Reporte == "resumen" ? "Haber" : "Haber"), FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

            }


            if (Tipo_Reporte == "resumen2")
            {
                cell = new PdfPCell(new Paragraph("Debe", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Haber", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Saldo", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Debe", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Haber", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Saldo", FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY };
                cell.Colspan = 1;
                TablaCabDetalle.AddCell(cell);

            }

            TablaCabDetalle.CompleteRow();

            #endregion

            document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

            #endregion

        }

    }
}



