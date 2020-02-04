using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoBalanceComprobacionSunat : FrmMantenimientoBase
    {
        public frmListadoBalanceComprobacionSunat()
        {
            InitializeComponent();
            LlenarCombos();
            FormatoGrid(dgvDocumentos, true);
            
        }


        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<BalanceComprobacionSunatE> ListaBalanceCompSunat = null;
        BalanceComprobacionSunatE BalanceCompSunat = null;
        int anioInicio = 0;
        int anioFin = 0;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        String anio = String.Empty;
        String Mes = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
        #endregion

        #region Procedimiento Heredados


        void LlenarCombos()
        {

            /////MES////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboMes.DataSource = oDt;
            cboMes.ValueMember = "MesId";
            cboMes.DisplayMember = "MesDes";
            cboMes.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";

        }


        public override void Buscar()
        {
         try
          {
           anio = Convert.ToString(cboAño.SelectedValue);
           Mes = Convert.ToString(cboMes.SelectedValue);

           ListaBalanceCompSunat = AgenteContabilidad.Proxy.ListarBalanceComprobacionSunat(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, anio, Mes);

           BalanceComprobacionSunatE oBalance = new BalanceComprobacionSunatE();
           oBalance.codCuentaSunat = "";
           oBalance.Descripcion = "SUB-TOTALES:";

           oBalance.SaldoInicialDebe = Decimal.Round((from x in ListaBalanceCompSunat select x.SaldoInicialDebe).Sum(), 2);
           oBalance.SaldoInicialHaber = Decimal.Round((from x in ListaBalanceCompSunat select x.SaldoInicialHaber).Sum(), 2);
           oBalance.MovimientoDebe = Decimal.Round((from x in ListaBalanceCompSunat select x.MovimientoDebe).Sum(), 2);
           oBalance.MovimientoHaber = Decimal.Round((from x in ListaBalanceCompSunat select x.MovimientoHaber).Sum(), 2);
           oBalance.SumasMayorDebe = Decimal.Round((from x in ListaBalanceCompSunat select x.SumasMayorDebe).Sum(), 2);
           oBalance.SumasMayorHaber = Decimal.Round((from x in ListaBalanceCompSunat select x.SumasMayorHaber).Sum(), 2);
           oBalance.SaldoDebe = Decimal.Round((from x in ListaBalanceCompSunat select x.SaldoDebe).Sum(), 2);
           oBalance.SaldoHaber = Decimal.Round((from x in ListaBalanceCompSunat select x.SaldoHaber).Sum(), 2);
           oBalance.TransCancDebe = Decimal.Round((from x in ListaBalanceCompSunat select x.TransCancDebe).Sum(), 2);
           oBalance.TransCancHaber = Decimal.Round((from x in ListaBalanceCompSunat select x.TransCancHaber).Sum(), 2);
           oBalance.BalanceActivo = Decimal.Round((from x in ListaBalanceCompSunat select x.BalanceActivo).Sum(), 2);
           oBalance.BalancePasivo = Decimal.Round((from x in ListaBalanceCompSunat select x.BalancePasivo).Sum(), 2);
           oBalance.RPNaturalezaPerdida = Decimal.Round((from x in ListaBalanceCompSunat select x.RPNaturalezaPerdida).Sum(), 2);
           oBalance.RPNaturalezaGanancia = Decimal.Round((from x in ListaBalanceCompSunat select x.RPNaturalezaGanancia).Sum(), 2);

           ListaBalanceCompSunat.Add(oBalance);

           BalanceComprobacionSunatE oDiferencia = new BalanceComprobacionSunatE();

           Decimal DebeActivoPasivo, HaberActivoPasivo,DebeResultado,HaberResultado;

           if (oBalance.BalanceActivo > oBalance.BalancePasivo)
            {
               DebeActivoPasivo = 0;
               HaberActivoPasivo = oBalance.BalanceActivo - oBalance.BalancePasivo;
            }
           else
            {
               DebeActivoPasivo = oBalance.BalancePasivo - oBalance.BalanceActivo;
               HaberActivoPasivo = 0;
            }

           if (oBalance.RPNaturalezaPerdida > oBalance.RPNaturalezaGanancia)
            {
               DebeResultado = 0;
               HaberResultado = oBalance.RPNaturalezaPerdida - oBalance.RPNaturalezaGanancia;
            }
           else
            {
               DebeResultado = oBalance.RPNaturalezaGanancia - oBalance.RPNaturalezaPerdida;
               HaberResultado = 0;
            }

           oDiferencia.codCuentaSunat = "";
           oDiferencia.Descripcion = "RESULTADOS:";
           oDiferencia.SaldoInicialDebe = 0;
           oDiferencia.SaldoInicialHaber = 0;
           oDiferencia.MovimientoDebe = 0;
           oDiferencia.MovimientoHaber = 0;
           oDiferencia.SumasMayorDebe = 0;
           oDiferencia.SumasMayorHaber = 0;
           oDiferencia.SaldoDebe = 0;
           oDiferencia.SaldoHaber = 0;
           oDiferencia.TransCancDebe = 0;
           oDiferencia.TransCancHaber = 0;
           oDiferencia.BalanceActivo = DebeActivoPasivo;
           oDiferencia.BalancePasivo = HaberActivoPasivo;
           oDiferencia.RPNaturalezaPerdida = DebeResultado;
           oDiferencia.RPNaturalezaGanancia = HaberResultado;

           ListaBalanceCompSunat.Add(oDiferencia);

           bsBalanceComprobacionSunat.DataSource = ListaBalanceCompSunat;
           bsBalanceComprobacionSunat.ResetBindings(false);
         
           lblRegistros.Text = "Balance Comprobacion " + bsBalanceComprobacionSunat.Count.ToString() + " Registros";
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
                if (bsBalanceComprobacionSunat.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBalanceComprobacionSunat);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }


                    BalanceCompSunat = (BalanceComprobacionSunatE)bsBalanceComprobacionSunat.Current;



                    oFrm = new frmBalanceComprobacionSunat(BalanceCompSunat);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
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



                if (ListaBalanceCompSunat.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "ListadoBalanceComprobacionSunat.", "Archivos Excel (*.xlsx)|*.xlsx");

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
                                Int32 TotColumnas = 16;

                                #region Titulos Principales

                                // Creando Encabezado;
                                oHoja.Cells["A1"].Value = "BALANCE DE COMPROBACIÓN HISTORICO - PLAN CONTABLE GENERAL EMPRESARIAL - 2014";

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                                }

                                #endregion

                                #region Cabeceras del Detalle

                                // PRIMERA
                                oHoja.Cells[InicioLinea, 1].Value = "  ";
                                oHoja.Cells[InicioLinea, 2].Value = " BALANCE DE COMPROBACIÓN 2014 - HISTÓRICO ";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, TotColumnas])
                                {
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }

                                for (int i = 1; i <= 16; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                }

                                InicioLinea++;

                                // SEGUNDA
                                oHoja.Cells[InicioLinea,3].Value = " SALDOS INICIALES ";
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea, 4])
                                {
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }

                                oHoja.Cells[InicioLinea, 5].Value = " MOVIMIENTO DEL EJERCICIO";
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea, 6])
                                {
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }

                                oHoja.Cells[InicioLinea, 7].Value = " SUMAS DEL MAYOR ";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea, 8])
                                {
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }
                                Int32 anioant = 0;
                                foreach (BalanceComprobacionSunatE item in ListaBalanceCompSunat)
                                {
                                    anioant = Convert.ToInt32(item.AnioPeriodo);

                                }
                                anioant--;
                                oHoja.Cells[InicioLinea, 9].Value = " SALDOS AL 31 DE DICIEMBRE DEL " + anioant;
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, InicioLinea, 10])
                                {
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }

                                oHoja.Cells[InicioLinea, 11].Value = " TRANSFERENCIAS Y CANCELACIONES ";
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 11, InicioLinea, 12])
                                {
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }
                                oHoja.Cells[InicioLinea, 13].Value = " CUENTAS DEL BALANCE ";
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 13, InicioLinea, 14])
                                {
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }

                                oHoja.Cells[InicioLinea, 15].Value = " RESULTADOS POR NATURALEZA ";
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 15, InicioLinea, 16])
                                {
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                }

                                for (int i = 1; i <= 16; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                }
                                InicioLinea++;

                                // TERCERA
                                oHoja.Cells[InicioLinea, 1].Value = " CUENTAS";
                                oHoja.Column(1).Width = 10;
                                oHoja.Cells[InicioLinea, 2].Value = " DESCRIPCION";
                                oHoja.Column(2).Width = 90;
                                oHoja.Cells[InicioLinea, 3].Value = " DEBE ";
                                oHoja.Column(3).Width = 13;
                                oHoja.Cells[InicioLinea, 4].Value = " HABER ";
                                oHoja.Column(4).Width = 13;
                                oHoja.Cells[InicioLinea, 5].Value = " DEBE ";
                                oHoja.Column(5).Width = 13;
                                oHoja.Cells[InicioLinea, 6].Value = " HABER ";
                                oHoja.Column(6).Width = 13;
                                oHoja.Cells[InicioLinea, 7].Value = " DEBE ";
                                oHoja.Column(7).Width = 13;
                                oHoja.Cells[InicioLinea, 8].Value = " HABER ";
                                oHoja.Column(8).Width = 13;
                                oHoja.Cells[InicioLinea, 9].Value = " DEUDOR ";
                                oHoja.Column(9).Width = 17;
                                oHoja.Cells[InicioLinea, 10].Value = " ACREEDOR ";
                                oHoja.Column(10).Width = 17;
                                oHoja.Cells[InicioLinea, 11].Value = " DEBE ";
                                oHoja.Column(11).Width = 17;
                                oHoja.Cells[InicioLinea, 12].Value = " HABER ";
                                oHoja.Column(12).Width = 17;
                                oHoja.Cells[InicioLinea, 13].Value = " ACTIVO ";
                                oHoja.Column(13).Width = 11;
                                oHoja.Cells[InicioLinea, 14].Value = " PASIVO ";
                                oHoja.Column(14).Width = 11;
                                oHoja.Cells[InicioLinea, 15].Value = " PERDIDAS ";
                                oHoja.Column(15).Width = 14;
                                oHoja.Cells[InicioLinea, 16].Value = " GANANCIAS ";
                                oHoja.Column(16).Width = 14;

                                for (int i = 1; i <= 16; i++)
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


                                decimal total1=0;
                                decimal total2=0;
                                decimal total3=0;
                                decimal total4=0;
                                decimal total5=0;
                                decimal total6=0;
                                decimal total7=0;
                                decimal total8=0;
                                decimal total9=0;
                                decimal total10=0;
                                decimal total11=0;
                                decimal total12=0;
                                decimal total13=0;
                                decimal total14=0;


                                foreach (BalanceComprobacionSunatE item in ListaBalanceCompSunat)
                                {
                                    if (item.codCuentaSunat != "89")
                                    {

                                        oHoja.Cells[InicioLinea, 1].Value = item.codCuentaSunat ;
                                        oHoja.Cells[InicioLinea, 2].Value = item.Descripcion;
                                        oHoja.Cells[InicioLinea, 3].Value = item.SaldoInicialDebe;
                                        oHoja.Cells[InicioLinea, 4].Value = item.SaldoInicialHaber;
                                        oHoja.Cells[InicioLinea, 5].Value = item.MovimientoDebe;
                                        oHoja.Cells[InicioLinea, 6].Value = item.MovimientoHaber;
                                        oHoja.Cells[InicioLinea, 7].Value = item.SumasMayorDebe;
                                        oHoja.Cells[InicioLinea, 8].Value = item.SumasMayorHaber;
                                        oHoja.Cells[InicioLinea, 9].Value = item.SaldoDebe;
                                        oHoja.Cells[InicioLinea, 10].Value = item.SaldoHaber;
                                        oHoja.Cells[InicioLinea, 11].Value = item.TransCancDebe;
                                        oHoja.Cells[InicioLinea, 12].Value = item.TransCancHaber;
                                        oHoja.Cells[InicioLinea, 13].Value = item.BalanceActivo;
                                        oHoja.Cells[InicioLinea, 14].Value = item.BalancePasivo;
                                        oHoja.Cells[InicioLinea, 15].Value = item.RPNaturalezaPerdida;
                                        oHoja.Cells[InicioLinea, 16].Value = item.RPNaturalezaGanancia;

                                        if (item.codCuentaSunat.Length == 6)
                                        {
                                            for (int i = 1; i <= 16; i++)
                                            {
                                                oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                                oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(0, 204, 255));
                                            }
                                        }

                                        oHoja.Cells[InicioLinea, 3,InicioLinea,16].Style.Numberformat.Format = "###,###,##0.00";

                                        total1 += item.SaldoInicialHaber;
                                        total2 += item.SaldoInicialDebe;
                                        total3 += item.MovimientoDebe;
                                        total4 += item.MovimientoHaber;
                                        total5 += item.SumasMayorDebe;
                                        total6 += item.SumasMayorHaber;
                                        total7 += item.SaldoDebe;
                                        total8 += item.SaldoHaber;
                                        total9 += item.TransCancDebe;
                                        total10 += item.TransCancHaber;
                                        total11 += item.BalanceActivo;
                                        total12 += item.BalancePasivo;
                                        total13 += item.RPNaturalezaPerdida;
                                        total14 += item.RPNaturalezaGanancia;


                                        InicioLinea++;
                                    }
                                    else
                                    {

                                        Int32 totFilas = InicioLinea;
                                        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                                        InicioLinea++;


                                        oHoja.Cells[InicioLinea, 1].Value = " ";
                                        oHoja.Cells[InicioLinea, 2].Value = " ";
                                        oHoja.Cells[InicioLinea, 3].Value = " ";
                                        oHoja.Cells[InicioLinea, 4].Value = " ";
                                        oHoja.Cells[InicioLinea, 5].Value = " ";
                                        oHoja.Cells[InicioLinea, 6].Value = " ";
                                        oHoja.Cells[InicioLinea, 7].Value = " ";
                                        oHoja.Cells[InicioLinea, 8].Value = " ";
                                        oHoja.Cells[InicioLinea, 9].Value = " ";
                                        oHoja.Cells[InicioLinea, 10].Value =" ";
                                        oHoja.Cells[InicioLinea, 11].Value = " ";
                                        oHoja.Cells[InicioLinea, 12].Value = " ";
                                        oHoja.Cells[InicioLinea, 13].Value =" ";
                                        oHoja.Cells[InicioLinea, 14].Value = " " ;
                                        oHoja.Cells[InicioLinea, 15].Value = " ";
                                        oHoja.Cells[InicioLinea, 16].Value = " ";

                                        InicioLinea++;

                                        oHoja.Cells[InicioLinea, 2].Value = "SUB-TOTALES";
                                        oHoja.Cells[InicioLinea, 3].Value = total1;
                                        oHoja.Cells[InicioLinea, 4].Value = total2;
                                        oHoja.Cells[InicioLinea, 5].Value = total3;
                                        oHoja.Cells[InicioLinea, 6].Value = total4;
                                        oHoja.Cells[InicioLinea, 7].Value = total5;
                                        oHoja.Cells[InicioLinea, 8].Value = total6;
                                        oHoja.Cells[InicioLinea, 9].Value = total7;
                                        oHoja.Cells[InicioLinea,10].Value = total8;
                                        oHoja.Cells[InicioLinea, 11].Value = total9;
                                        oHoja.Cells[InicioLinea, 12].Value = total10;
                                        oHoja.Cells[InicioLinea, 13].Value = total11;
                                        oHoja.Cells[InicioLinea, 14].Value = total12;
                                        oHoja.Cells[InicioLinea, 15].Value = total13;
                                        oHoja.Cells[InicioLinea, 16].Value = total14;

                                        oHoja.Cells[InicioLinea, 3, InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";

                                        for (int i = 1; i <= 16; i++)
                                        {
                                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 204, 153));
                                        }
                                        InicioLinea++;

                                        oHoja.Cells[InicioLinea, 1].Value = item.codCuentaSunat;
                                        oHoja.Cells[InicioLinea, 2].Value = item.Descripcion;
                                        oHoja.Cells[InicioLinea, 3].Value = item.SaldoInicialDebe;
                                        oHoja.Cells[InicioLinea, 4].Value = item.SaldoInicialHaber;
                                        oHoja.Cells[InicioLinea, 5].Value = item.MovimientoDebe;
                                        oHoja.Cells[InicioLinea, 6].Value = item.MovimientoHaber;
                                        oHoja.Cells[InicioLinea,7].Value = item.SumasMayorDebe;
                                        oHoja.Cells[InicioLinea, 8].Value = item.SumasMayorHaber;
                                        oHoja.Cells[InicioLinea, 9].Value = item.SaldoDebe;
                                        oHoja.Cells[InicioLinea, 10].Value = item.SaldoHaber;
                                        oHoja.Cells[InicioLinea, 11].Value = item.TransCancDebe;
                                        oHoja.Cells[InicioLinea, 12].Value = item.TransCancHaber;
                                        oHoja.Cells[InicioLinea, 13].Value = item.BalanceActivo;
                                        oHoja.Cells[InicioLinea, 14].Value = item.BalancePasivo;
                                        oHoja.Cells[InicioLinea, 15].Value = item.RPNaturalezaPerdida;
                                        oHoja.Cells[InicioLinea, 16].Value = item.RPNaturalezaGanancia;
                                        oHoja.Cells[InicioLinea, 3, InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                        InicioLinea++;
                                    }
                                }


                                oHoja.Cells[InicioLinea, 2].Value = "TOTALES";
                                oHoja.Cells[InicioLinea, 3].Value = total1;
                                oHoja.Cells[InicioLinea, 4].Value = total2;
                                oHoja.Cells[InicioLinea, 5].Value = total3;
                                oHoja.Cells[InicioLinea, 6].Value = total4;
                                oHoja.Cells[InicioLinea, 7].Value = total5;
                                oHoja.Cells[InicioLinea, 8].Value = total6;
                                oHoja.Cells[InicioLinea, 9].Value = total7;
                                oHoja.Cells[InicioLinea, 10].Value = total8;
                                oHoja.Cells[InicioLinea, 11].Value = total9;
                                oHoja.Cells[InicioLinea, 12].Value = total10;
                                oHoja.Cells[InicioLinea, 13].Value = total11;
                                oHoja.Cells[InicioLinea, 14].Value = total12;
                                oHoja.Cells[InicioLinea, 15].Value = total13;
                                oHoja.Cells[InicioLinea, 16].Value = total14;

                                oHoja.Cells[InicioLinea, 3, InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";

                                InicioLinea++;


                                #endregion

                                //FIN SUMATORIA //


                                //Linea
                                //Int32 totFilas = InicioLinea;
                                //oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                                //Suma
                                //InicioLinea++;

                                //Ajustando el ancho de las columnas automaticamente
                                //oHoja.Cells.AutoFitColumns(0);

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

                                Global.MensajeComunicacion("Se ha Exportado Correctamente");

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

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmBalanceComprobacionSunat oFrm = sender as frmBalanceComprobacionSunat;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoBalanceComprobacionSunat_Load(object sender, EventArgs e)
        {
            //this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDocumentos.ColumnHeadersHeight = 40;
            this.dgvDocumentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cboAño.SelectedValue = Convert.ToInt32(Anio);
            cboMes.SelectedValue = 12;
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvDocumentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                String nomColumn = dgvDocumentos.Columns[e.ColumnIndex].Name;


                if (e.RowIndex != -1)
                {

                    if (e.Value != null)
                    {
                        string des = dgvDocumentos.Rows[e.RowIndex].Cells[0].Value.ToString();
                        des.Trim();

                        if (des.Length == 6)
                        {
                            e.CellStyle.BackColor = Color.Aquamarine;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }


        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            #region Variables

            String Anio = Convert.ToString(cboAño.SelectedValue);
            Int32 DiaReal = FechasHelper.ObtenerUltimoDia(VariablesLocales.FechaHoy).Day;
            String RutaArchivoTexto = String.Empty;

            #endregion Variables

            try
            {
                #region Validaciones

                if (ListaBalanceCompSunat == null || ListaBalanceCompSunat.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay registros a exportar.");
                    return;
                }

                #endregion

                RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", "0684" + VariablesLocales.SesionUsuario.Empresa.RUC + Anio, "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    //Borrando el archivo...
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        #region Variables

                        StringBuilder Linea = new StringBuilder();

                        #endregion Variables

                        foreach (BalanceComprobacionSunatE item in ListaBalanceCompSunat)
                        {
                            #region Insertar Linea

                            if (item.codCuentaSunat != "")
                            {

                                if (Convert.ToInt32(item.codCuentaSunat.Substring(0,2)) >= 60)
                                {
                                    Linea.Append(item.codCuentaSunat).Append("|").Append("").Append("|").Append("").Append("|");
                                    Linea.Append(Math.Round(item.MovimientoDebe)).Append("|").Append(Math.Round(item.MovimientoHaber)).Append("|").Append(Math.Round(item.TransCancDebe)).Append("|");
                                    Linea.Append(Math.Round(item.TransCancHaber)).Append("|").Append("0").Append("|").Append("0").Append("|");
                                    oSw.WriteLine(Linea.ToString());

                                }
                                else
                                {
                                    Linea.Append(item.codCuentaSunat).Append("|").Append(Math.Round(item.SaldoInicialDebe)).Append("|").Append(Math.Round(item.SaldoInicialHaber)).Append("|");
                                    Linea.Append(Math.Round(item.MovimientoDebe)).Append("|").Append(Math.Round(item.MovimientoHaber)).Append("|").Append(Math.Round(item.TransCancDebe)).Append("|");
                                    Linea.Append(Math.Round(item.TransCancHaber)).Append("|").Append("0").Append("|").Append("0").Append("|");
                                    oSw.WriteLine(Linea.ToString());
                                }
                            }

                       
                            Linea.Clear();

                            #endregion
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

        private void btPle_Click(object sender, EventArgs e)
        {
            #region Variables

            String Anio = Convert.ToString(cboAño.SelectedValue);
            String Mes = Convert.ToString(cboMes.SelectedValue);
            Int32 DiaReal = FechasHelper.ObtenerUltimoDia(VariablesLocales.FechaHoy).Day;
            String RutaArchivoTexto = String.Empty;
            String ConInformacion = "1";
            String NombreArchivo = String.Empty;

            #endregion Variables

            try
            {
                if (ListaBalanceCompSunat == null || ListaBalanceCompSunat.Count == Variables.Cero)
                {
                    ConInformacion = "0";
                    NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + Anio + Mes + "00" + "031700" + "01" + "1" + ConInformacion + "1" + "1";
                }
                else
                {
                    ConInformacion = "1";
                    NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + Anio + Mes + "00" + "031700" + "01" + "1" + ConInformacion + "1" + "1";
                }

                RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo , "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    //Borrando el archivo...
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        if (ListaBalanceCompSunat != null && ListaBalanceCompSunat.Count > Variables.Cero)
                        {
                            #region Variables

                            StringBuilder Linea = new StringBuilder();

                            #endregion Variables

                            foreach (BalanceComprobacionSunatE item in ListaBalanceCompSunat)
                            {
                                #region Insertar Linea

                                if (item.codCuentaSunat != "")
                                {
                                    Linea.Append(item.AnioPeriodo+item.MesPeriodo+"31").Append("|").Append(item.codCuentaSunat).Append("|").Append(item.SaldoInicialDebe).Append("|").Append(item.SaldoInicialHaber).Append("|");
                                    Linea.Append(item.MovimientoDebe).Append("|").Append(item.MovimientoHaber).Append("|").Append(item.SumasMayorDebe).Append("|").Append(item.SumasMayorHaber).Append("|");
                                    Linea.Append(item.SaldoDebe).Append("|").Append(item.SaldoHaber).Append("|").Append(item.TransCancDebe).Append("|").Append(item.TransCancHaber).Append("|");
                                    Linea.Append(item.BalanceActivo).Append("|").Append(item.BalancePasivo).Append("|").Append(item.RPNaturalezaGanancia).Append("|").Append(item.RPNaturalezaPerdida).Append("|");
                                    Linea.Append(item.Adiciones).Append("|").Append(item.Deducciones).Append("|").Append(item.Estado).Append("|");
                                    oSw.WriteLine(Linea.ToString());
                                }


                                Linea.Clear();

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
    }
}
