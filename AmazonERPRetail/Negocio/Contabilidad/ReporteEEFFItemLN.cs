using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

using Entidades.Contabilidad;
using Entidades.Maestros;
using AccesoDatos.Contabilidad;
using AccesoDatos.Maestros;

namespace Negocio.Contabilidad
{
    public class ReporteEEFFItemLN
    {

        public List<ReporteEEFFItemE> ListarRptEEFFGananciasPerdidas(Int32 idEmpresa, String anio, String mesInicio, String mesFin, Int32 idEEFF, String idCCostos, String indAcumulado, String indCCostos, String NumPlaCta, String TipoReporte, Decimal TipoCambio, Int32 numNivel, Boolean MostrarTodo)
        {
            try
            {
                List<ReporteEEFFItemE> Lista = new ReporteEEFFItemAD().ListarRptEEFFGananciasPerdidas(idEmpresa, anio, mesInicio, mesFin, idEEFF, idCCostos, indAcumulado, indCCostos, NumPlaCta, TipoReporte, TipoCambio, numNivel);

                if (MostrarTodo)
                {
                    List<EEFFItemE> ListaFaltantes = new EEFFItemAD().ListarConEEFFItemFaltantes(idEmpresa, idEEFF);

                    if (ListaFaltantes.Count > 0)
                    {
                        String MesIni = (from x in Lista select x.MesPeriodo).Min();
                        String MesFin = (from x in Lista select x.MesPeriodo).Max();
                        var ListaTmp = Lista.GroupBy(x => x.secItem).Select(p => p.First()).ToList();

                        foreach (EEFFItemE item in ListaFaltantes)
                        {
                            ReporteEEFFItemE ItemFaltante = ListaTmp.Find
                            (
                                delegate (ReporteEEFFItemE re) { return re.idEEFFItem == item.idEEFFItem; }
                            );

                            if (ItemFaltante == null)
                            {
                                for (int i = Convert.ToInt32(MesIni); i <= Convert.ToInt32(MesFin); i++)
                                {
                                    ReporteEEFFItemE itemE = new ReporteEEFFItemE()
                                    {
                                        idEEFFItem = item.idEEFFItem,
                                        AnioPeriodo = anio,
                                        MesPeriodo = String.Format("{0:00}", i),
                                        secItem = item.secItem,
                                        desItem = item.desItem,
                                        TipoTabla = item.TipoTabla,
                                        TipoCaracteristica = item.TipoCaracteristica,
                                        saldo_sol = 0,
                                        saldo_dol = 0
                                    };

                                    Lista.Add(itemE);
                                }
                            }
                        }

                        Lista = (from x in Lista orderby x.idEEFFItem, x.AnioPeriodo, x.MesPeriodo, x.secItem, x.desItem, x.TipoTabla, x.TipoCaracteristica select x).ToList();
                    }
                }

                return Lista;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<VoucherItemE> ListarRptEEFFGananciasPerdidasDetalle(Int32 idEmpresa, Int32 idLocal, String anio, String mesInicio, String mesFin, Int32 idEEFF, Int32 idEEFFItem, String idCCostos, String idMoneda, String TipoReporte)
        {
            try
            {
                return new ReporteEEFFItemAD().ListarRptEEFFGananciasPerdidasDetalle(idEmpresa, idLocal, anio, mesInicio, mesFin, idEEFF, idEEFFItem, idCCostos, idMoneda, TipoReporte);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<ReporteEEFFItemE> ListarReporteEEFFGananciasPerdidasArchivo(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFitem)
        {
            try
            {
                return new ReporteEEFFItemAD().ListarReporteEEFFGananciasPerdidasArchivo(idEmpresa,  idEEFF, idEEFFitem);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<ReporteEEFFItemE> ListarReporteEEFFGananciasPerdidasRatios(Int32 idEmpresa, Int32 Anio, String MesInicio, String MesFin, String NumPlaCta, Boolean Calculo)
        {
            try
            {
                String AnioHistorico = "2016";
                Empresa oEmpresa = new EmpresaAD().RecuperarEmpresaPorID(idEmpresa);

                if (oEmpresa.RUC == "20515657119")
                {
                    AnioHistorico = "2017";
                }

                List<ReporteEEFFItemE> oListaGeneral = new List<ReporteEEFFItemE>();
                List<ReporteEEFFItemE> oListaTmp = null;
                List<ReporteEEFFItemE> oListaCeros = null;
                List<String> ListaAnios = new List<string>();
                Int16 Val1 = 0;

                ListaAnios.Add(Convert.ToString(Anio - 1));
                ListaAnios.Add(Convert.ToString(Anio));

                //idEEFF --- 1 = BALANCE GENERAL 3 = ESTADO DE GANANCIAS Y PERDIDAS POR FUNCION
                Int32 g = 1;

                foreach (String itemAnio in ListaAnios)
                {
                    #region BALANCE GENERAL

                    oListaTmp = (from x in new ReporteEEFFItemAD().ListarReporteEEFFGananciasPerdidasRatios(idEmpresa, itemAnio, MesInicio, MesFin, 1, NumPlaCta, (itemAnio == AnioHistorico ? true : Calculo))
                                 orderby Convert.ToInt32(x.secItem)
                                 select x).ToList();
                    //Sacando los registro tipo detalle que sus saldos sean 0
                    oListaCeros = (from x in oListaTmp where x.TipoTabla == "DET" && x.sSaldoSoles == "0.00" && x.sSaldoDolares == "0.00" select x).ToList();
                    //Quitando del temporal las lista de registros iguales a 0
                    oListaTmp = new List<ReporteEEFFItemE>(oListaTmp.Except(oListaCeros).ToList());
                    //Obteniendo los totales generales
                    List<ReporteEEFFItemE> oListaTotales = (from x in oListaTmp
                                                            where x.desItem == "TOTAL ACTIVO" || x.desItem == "TOTAL PASIVO Y PATRIMONIO"
                                                            orderby x.secItem
                                                            select x).ToList();

                    Val1 = 0;
                    //Val2 = 0;

                    //Para obtener el valor total de cada titulo
                    foreach (ReporteEEFFItemE item in oListaTmp)
                    {
                        item.TipoReporte = "BAL";

                        if (item.TipoTabla == "TOT" && (item.desItem == "TOTAL ACTIVO" || item.desItem == "TOTAL PASIVO" || item.desItem == "TOTAL PASIVO Y PATRIMONIO"))
                        {
                            item.Grupo = g;
                            g++;
                            item.IniFin = "F";
                            Val1 = 0;
                        }
                        else
                        {
                            item.Grupo = g;

                            if (Val1 == 0)
                            {
                                item.IniFin = "I";
                                Val1++;
                            }
                        }
                    }

                    #endregion

                    #region Calculando lo montos para el Análisis vertical

                    foreach (ReporteEEFFItemE item in oListaTmp)
                    {
                        //Titulos, los saldos en blanco
                        if (item.TipoTabla == "TIT")
                        {
                            item.sSaldoSoles = String.Empty;
                            item.sSaldoDolares = String.Empty;
                            item.GrupoTotalSol = String.Empty;
                            item.GrupoTotalDol = String.Empty;
                        }
                        else
                        {
                            if (item.Grupo == 1)
                            {
                                if (item.sSaldoSoles != "0.00" && oListaTotales[0].sSaldoSoles != "0.00")
                                {
                                    item.GrupoTotalSol = ((Convert.ToDecimal(item.sSaldoSoles) / Convert.ToDecimal(oListaTotales[0].sSaldoSoles)) * 100).ToString("N2");
                                    item.GrupoTotalDol = ((Convert.ToDecimal(item.sSaldoDolares) / Convert.ToDecimal(oListaTotales[0].sSaldoDolares)) * 100).ToString("N2");
                                }
                                else
                                {
                                    item.GrupoTotalSol = "0.00";
                                    item.GrupoTotalDol = "0.00";
                                }
                            }

                            if (item.Grupo == 2 || item.Grupo == 3)
                            {
                                if (item.sSaldoSoles != "0.00" && oListaTotales[1].sSaldoSoles != "0.00")
                                {
                                    item.GrupoTotalSol = ((Convert.ToDecimal(item.sSaldoSoles) / Convert.ToDecimal(oListaTotales[1].sSaldoSoles)) * 100).ToString("N2");
                                    item.GrupoTotalDol = ((Convert.ToDecimal(item.sSaldoDolares) / Convert.ToDecimal(oListaTotales[1].sSaldoDolares)) * 100).ToString("N2");
                                }
                                else
                                {
                                    item.GrupoTotalSol = "0.00";
                                    item.GrupoTotalDol = "0.00";
                                }
                            }
                        }
                    }

                    #endregion

                    //Agregando a la lista final...
                    oListaGeneral.AddRange(oListaTmp);

                    #region ESTADO DE GANANCIAS Y PERDIDAS POR FUNCION

                    g = 1;
                    oListaTmp = (from x in new ReporteEEFFItemAD().ListarReporteEEFFGananciasPerdidasRatios(idEmpresa, itemAnio, MesInicio, MesFin, 3, NumPlaCta, (itemAnio == AnioHistorico ? true : Calculo))
                                 orderby Convert.ToInt32(x.secItem)
                                 select x).ToList();
                    //Sacando los registro tipo detalle que sus saldos sean 0
                    oListaCeros = new List<ReporteEEFFItemE>((from x in oListaTmp where x.TipoTabla == "DET" && x.sSaldoSoles == "0.00" && x.sSaldoDolares == "0.00" select x).ToList());
                    //Quitando del temporal las lista de registros iguales a 0
                    oListaTmp = new List<ReporteEEFFItemE>(oListaTmp.Except(oListaCeros).ToList());

                    foreach (ReporteEEFFItemE item in oListaTmp)
                    {
                        item.TipoReporte = "GAPER";
                    }

                    #endregion

                    #region Calculando lo montos para el Análisis Horizontal

                    Decimal Soles = 0;
                    Decimal Dolares = 0;
                    Int16 Comienzo = 1;

                    for (int i = 0; i < oListaTmp.Count; i++)
                    {
                        if (Comienzo == 1)
                        {
                           if (Convert.ToDecimal(oListaTmp[i].sSaldoSoles) == 0)
                            {
                             oListaTmp[i].GrupoTotalSol = (0).ToString("N2");
                            }
                            else
                            {
                             oListaTmp[i].GrupoTotalSol = ((Convert.ToDecimal(oListaTmp[i].sSaldoSoles) / Convert.ToDecimal(oListaTmp[i].sSaldoSoles) * 100)).ToString("N2");
                            }

                           if (Convert.ToDecimal(oListaTmp[i].sSaldoDolares) == 0)
                            {
                             oListaTmp[i].GrupoTotalDol = (0).ToString("N2");
                            }
                            else
                            {
                             oListaTmp[i].GrupoTotalDol = ((Convert.ToDecimal(oListaTmp[i].sSaldoDolares) / Convert.ToDecimal(oListaTmp[i].sSaldoDolares) * 100)).ToString("N2");
                            }

                            Soles = Convert.ToDecimal(oListaTmp[i].sSaldoSoles);
                            Dolares = Convert.ToDecimal(oListaTmp[i].sSaldoDolares);
                            Comienzo++;
                        }
                        else
                        {
                            if (Soles == 0)
                            {
                             oListaTmp[i].GrupoTotalSol = (0).ToString("N2");
                            }
                            else
                            {
                             oListaTmp[i].GrupoTotalSol = ((Convert.ToDecimal(oListaTmp[i].sSaldoSoles) / Soles) * 100).ToString("N2");
                            }

                            if (Dolares == 0)
                            {
                             oListaTmp[i].GrupoTotalDol = (0).ToString("N2");
                            }
                            else
                            {
                             oListaTmp[i].GrupoTotalDol = ((Convert.ToDecimal(oListaTmp[i].sSaldoDolares) / Dolares) * 100).ToString("N2");
                            }
                        }
                    }

                    #endregion

                    oListaGeneral.AddRange(oListaTmp);
                }

                return oListaGeneral;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

    }
}
