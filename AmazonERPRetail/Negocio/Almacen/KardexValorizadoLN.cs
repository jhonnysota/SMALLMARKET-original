using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

using AccesoDatos.Almacen;
using Entidades.Almacen;
using Entidades.Generales;
using AccesoDatos.Generales;

namespace Negocio.Almacen
{
    public class KardexValorizadoLN
    {

        public List<KardexValorizadoE> ListarKardexValorizado(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin)
        {
            try
            {
                return new KardexValorizadoAD().ListarKardexValorizado(idEmpresa, idAlmacen, Inicio, Fin);
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

        public List<KardexValorizadoE> ListarKardexValorizadoFilt(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin, Int32 idArticulo, String idMoneda, Int32 idTipoArticulo)
        {
            try
            {
                List<KardexValorizadoE> oKardex = new KardexValorizadoAD().ListarKardexValorizadoFilt(idEmpresa, idAlmacen, Inicio, Fin, idArticulo, idMoneda, idTipoArticulo);
                List<KardexValorizadoE> oKardexRetorno = new List<KardexValorizadoE>();
                ParTabla oMovimiento = new ParTablaAD().ParTablaPorNemo("ING");
                ParTabla oMovimientoSalida = new ParTablaAD().ParTablaPorNemo("EGR");
                string codSunatInicial = string.Empty;
                string desInicial = string.Empty;
                DateTime fechaInicial = Convert.ToDateTime(Inicio.Insert(6, "-").Insert(4, "-")).AddDays(-1);
                //mov_almacen.fecProceso.IndexOf("-") > 0 || mov_almacen.fecProceso.IndexOf("/") > 0 ? Convert.ToDateTime(mov_almacen.fecProceso).ToString("yyyy") : mov_almacen.fecProceso.Substring(0, 4);
                int idOperacionDescuento = 0;

                if (oMovimiento == null)
                {
                    throw new Exception("Debe configurar el parámetro de Ingreso en Parámetros Generales");
                }

                List<OperacionE> oListaOperaciones = new OperacionAD().ListarOperacionporTipoMovimiento("", idEmpresa, oMovimiento.IdParTabla);
                List<OperacionE> oListaOperacionesSalida = new OperacionAD().ListarOperacionporTipoMovimiento("", idEmpresa, oMovimientoSalida.IdParTabla);

                OperacionE oOperacion = oListaOperaciones.Find
                (
                    delegate (OperacionE cc) { return cc.codSunat == "16"; }
                );

                if (oOperacion != null)
                {
                    codSunatInicial = oOperacion.codSunat;
                    desInicial = oOperacion.desOperacion;
                }
                else
                {
                    throw new Exception("Debe configurar el código 16 en alguna de las operaciones de almacén.");
                }

                OperacionE oOperacionDescuento = oListaOperacionesSalida.Find
                (
                   delegate (OperacionE dd) { return dd.indServicio == true && dd.desOperacion.Contains("DESCUENTO"); }
                );

                if (oOperacionDescuento != null)
                {
                    idOperacionDescuento = oOperacionDescuento.idOperacion;
                };


                if (oKardex != null && oKardex.Count > 0)
                {
                    Decimal CantidadFinal = 0;
                    int idArticuloTemp = oKardex[0].Articulo;
                    int idArt = 0;

                    List<KardexValorizadoE> oKardexTmp = oKardex.GroupBy(g => new { g.Articulo }).Select(g => new KardexValorizadoE()
                    {
                        Articulo = g.Key.Articulo,
                        CantEntradaInicial = g.Sum(x => x.CantEntradaInicial),
                        CantEntradaNoInicial = g.Sum(x => x.CantEntradaNoInicial),
                        CantEntrada = g.Sum(x => x.CantEntrada),
                        CostEntrada = g.Sum(x => x.CostEntrada),
                        TotalEntrada = g.Sum(x => x.TotalEntrada),
                        CantSalida = g.Sum(x => x.CantSalida),
                        CostSalida = g.Sum(x => x.CostSalida),
                        TotalSalida = g.Sum(x => x.TotalSalida)
                    }).ToList();

                    for (int i = 0; i < oKardex.Count; i++)
                    {
                        //La primera fila, el saldo inicial
                        if (idArt != oKardex[i].Articulo)
                        {
                            oKardex[i].SaldoAnterior = new KardexValorizadoE()
                            {
                                NomExistencia = "X",
                                Articulo = oKardex[i].Articulo,
                                fecProceso = fechaInicial.ToString("dd/MM/yyyy"),
                                Fecha = null,
                                Documento = "00",
                                Serie = "0",
                                Numero = "0",
                                idDocumentoRef = String.Empty,
                                serDocumentoRef = String.Empty,
                                numDocumentoRef = String.Empty,
                                CodSunat = codSunatInicial,
                                NomOperacion = desInicial,
                                //entradas
                                CantEntrada = oKardex[i].cantAnte,
                                CostEntrada = oKardex[i].CostoAnte,
                                TotalEntrada = oKardex[i].cantAnte * oKardex[i].CostoAnte,
                                //salidas
                                CantSalida = 0,
		                        CostSalida = 0,
		                        TotalSalida = 0,
                                //totales
                                CantFinal = oKardex[i].cantAnte,
		                        CostFinal = oKardex[i].CostoAnte,
                                TotalFinal = oKardex[i].cantAnte * oKardex[i].CostoAnte,
                                cantAnte = 0
                            };
                        }

                        CantidadFinal = 0;

                        if (i == 0)
                        {
                            //if (oKardex[i].Tipo == 2)
                            //{
                                CantidadFinal = ObtenerCantFinal(oKardex[i].Tipo, oKardex[i].CantEntrada, oKardex[i].CantSalida, oKardex[i].CantFinal, oKardex[i].cantAnte);
                            //}
                            //else
                            //{
                            //    CantidadFinal = ObtenerCantFinal(oKardex[i].Tipo, oKardex[i].CantEntrada, oKardex[i].CantSalida, oKardex[i].CantFinal);
                            //}
                        }
                        else
                        {
                            if (oKardex[i].Articulo != idArticuloTemp)
                            {
                                CantidadFinal = ObtenerCantFinal(oKardex[i].Tipo, oKardex[i].CantEntrada, oKardex[i].CantSalida, oKardex[i].CantFinal, oKardex[i].cantAnte);

                                KardexValorizadoE oKardexTotal = new KardexValorizadoE()
                                {
                                    Articulo = idArticuloTemp,
                                    codArticulo = "X",
                                    NomOperacion = "TOTALES >>> ",
                                    CantEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CantEntrada).First()) + oKardex[i - 1].cantAnte,
                                    //CostEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CostEntrada).First()),
                                    //TotalEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.TotalEntrada).First()),
                                    CantSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CantSalida).First()),
                                    //CostSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CostSalida).First()),
                                    //TotalSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.TotalSalida).First()),
                                    CantFinal = 0,
                                    CostFinal = 0,
                                    TotalFinal = 0
                                };

                                oKardexTotal.CantFinal = (oKardexTotal.CantEntrada) - oKardexTotal.CantSalida;
                                oKardexTotal.CostFinal = oKardex[i - 1].CostoActual;
                                oKardexTotal.TotalFinal = oKardexTotal.CantFinal * oKardexTotal.CostFinal;
                                oKardexRetorno.Add(oKardexTotal);
                            }
                            else
                            {
                                CantidadFinal = ObtenerCantFinal(oKardex[i].Tipo, oKardex[i].CantEntrada, oKardex[i].CantSalida, oKardex[i - 1].CantFinal);
                            }
                        }

                        // Codigo de Ajuste de Ingreso
                        if (oKardex[i].CodSunat == "93")
                         {
                            oKardex[i].TotalEntrada = oKardex[i].CostEntrada;
                         }
                        else
                         {
                            oKardex[i].TotalEntrada = oKardex[i].CantEntrada * oKardex[i].CostEntrada;
                         }

                        // Codigo de Ajuste de Salida
                        if (oKardex[i].CodSunat == "94" || idOperacionDescuento == oKardex[i].Operacion)
                        {
                            oKardex[i].TotalSalida = oKardex[i].CostSalida;
                        }
                        else
                        {
                            oKardex[i].TotalSalida = oKardex[i].CantSalida * oKardex[i].CostSalida;
                        }

                        oKardex[i].CantFinal = CantidadFinal;
                        idArticuloTemp = oKardex[i].Articulo;
                        idArt = oKardex[i].Articulo;
                        oKardex[i].TotalFinal = oKardex[i].CantFinal * oKardex[i].CostFinal;
                        oKardexRetorno.Add(oKardex[i]);
                    }

                    KardexValorizadoE oKardexTotalUltimo = new KardexValorizadoE()
                    {
                        Articulo = idArticuloTemp,
                        codArticulo = "X",
                        NomOperacion = "TOTALES >>> ",
                        CantEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CantEntrada).First()) + oKardex[oKardex.Count - 1].cantAnte,
                        //CostEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CostEntrada).First()),
                        //TotalEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.TotalEntrada).First()),
                        CantSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CantSalida).First()),
                        //CostSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CostSalida).First()),
                        //TotalSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.TotalSalida).First()),
                        CantFinal = 0,
                        CostFinal = 0,
                        TotalFinal = 0
                    };

                    oKardexTotalUltimo.CantFinal = (oKardexTotalUltimo.CantEntrada) - oKardexTotalUltimo.CantSalida;
                    oKardexTotalUltimo.CostFinal = oKardexRetorno[oKardexRetorno.Count - 1].CostoActual;
                    oKardexTotalUltimo.TotalFinal = oKardexTotalUltimo.CantFinal * oKardexTotalUltimo.CostFinal;
                    oKardexRetorno.Add(oKardexTotalUltimo);
                }

                return oKardexRetorno;
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

        public List<KardexValorizadoE> ListarKardexValorizadoFiltPorLote(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin, Int32 idArticulo,String Lote,String LoteAlmacen, Int32 idTipoArticulo)
        {
            try
            {
                List<KardexValorizadoE> oKardex = new KardexValorizadoAD().ListarKardexValorizadoFiltPorLote(idEmpresa, idAlmacen, Inicio, Fin, idArticulo, Lote, LoteAlmacen, idTipoArticulo);
                List<KardexValorizadoE> oKardexRetorno = new List<KardexValorizadoE>();
                ParTabla oMovimiento = new ParTablaAD().ParTablaPorNemo("ING");
                ParTabla oMovimientoSalida = new ParTablaAD().ParTablaPorNemo("EGR");
                String codSunatInicial = String.Empty;
                String desInicial = String.Empty;
                DateTime fechaInicial = Convert.ToDateTime(Inicio.Insert(6, "-").Insert(4, "-")).AddDays(-1); //Inicio.AddDays(-1);
                int idOperacionDescuento = 0;

                if (oMovimiento == null)
                {
                    throw new Exception("Debe configurar el parámetro de Ingreso en Parámetros Generales");
                }

                List<OperacionE> oListaOperaciones = new OperacionAD().ListarOperacionporTipoMovimiento("", idEmpresa, oMovimiento.IdParTabla);
                List<OperacionE> oListaOperacionesSalida = new OperacionAD().ListarOperacionporTipoMovimiento("", idEmpresa, oMovimientoSalida.IdParTabla);

                OperacionE oOperacion = oListaOperaciones.Find
                (
                    delegate (OperacionE cc) { return cc.codSunat == "16"; }
                );

                if (oOperacion != null)
                {
                    codSunatInicial = oOperacion.codSunat;
                    desInicial = oOperacion.desOperacion;
                }
                else
                {
                    throw new Exception("Debe configurar el código 16 en alguna de las operaciones de almacén.");
                }

                OperacionE oOperacionDescuento = oListaOperacionesSalida.Find
               (
                  delegate (OperacionE dd) { return dd.indServicio == true && dd.desOperacion.Contains("DESCUENTO"); }
               );

                if (oOperacionDescuento != null)
                {
                    idOperacionDescuento = oOperacionDescuento.idOperacion;
                };


                if (oKardex != null && oKardex.Count > 0)
                {
                    Decimal CantidadFinal = 0;
                    int idArticuloTemp = oKardex[0].Articulo;
                    int idArt = 0;

                    List<KardexValorizadoE> oKardexTmp = oKardex.GroupBy(g => new { g.Articulo }).Select(g => new KardexValorizadoE()
                    {
                        Articulo = g.Key.Articulo,
                        CantEntrada = g.Sum(x => x.CantEntrada),
                        CostEntrada = g.Sum(x => x.CostEntrada),
                        TotalEntrada = g.Sum(x => x.TotalEntrada),
                        CantSalida = g.Sum(x => x.CantSalida),
                        CostSalida = g.Sum(x => x.CostSalida),
                        TotalSalida = g.Sum(x => x.TotalSalida)
                    }).ToList();

                    for (int i = 0; i < oKardex.Count; i++)
                    {
                        //La primera fila, el saldo inicial
                        if (idArt != oKardex[i].Articulo)
                        {
                            oKardex[i].SaldoAnterior = new KardexValorizadoE()
                            {
                                NomExistencia = "X",
                                Articulo = oKardex[i].Articulo,
                                fecProceso = fechaInicial.ToString("dd/MM/yyyy"),
                                Fecha = null,
                                Documento = "00",
                                Serie = "0",
                                Numero = "0",
                                idDocumentoRef = String.Empty,
                                serDocumentoRef = String.Empty,
                                numDocumentoRef = String.Empty,
                                CodSunat = codSunatInicial,
                                NomOperacion = desInicial,
                                //entradas
                                CantEntrada = oKardex[i].cantAnte,
                                CostEntrada = oKardex[i].CostoAnte,
                                TotalEntrada = oKardex[i].cantAnte * oKardex[i].CostoAnte,
                                //salidas
                                CantSalida = 0,
                                CostSalida = 0,
                                TotalSalida = 0,
                                //totales
                                CantFinal = oKardex[i].cantAnte,
                                CostFinal = oKardex[i].CostoAnte,
                                TotalFinal = oKardex[i].cantAnte * oKardex[i].CostoAnte,
                                cantAnte = 0
                            };
                        }

                        CantidadFinal = 0;

                        if (i == 0)
                        {
                            //if (oKardex[i].Tipo == 2)
                            //{
                            CantidadFinal = ObtenerCantFinal(oKardex[i].Tipo, oKardex[i].CantEntrada, oKardex[i].CantSalida, oKardex[i].CantFinal, oKardex[i].cantAnte);
                            //}
                            //else
                            //{
                            //    CantidadFinal = ObtenerCantFinal(oKardex[i].Tipo, oKardex[i].CantEntrada, oKardex[i].CantSalida, oKardex[i].CantFinal);
                            //}
                        }
                        else
                        {
                            if (oKardex[i].Articulo != idArticuloTemp)
                            {
                                CantidadFinal = ObtenerCantFinal(oKardex[i].Tipo, oKardex[i].CantEntrada, oKardex[i].CantSalida, oKardex[i].CantFinal, oKardex[i].cantAnte);

                                KardexValorizadoE oKardexTotal = new KardexValorizadoE()
                                {
                                    Articulo = idArticuloTemp,
                                    codArticulo = "X",
                                    NomOperacion = "TOTALES >>> ",
                                    CantEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CantEntrada).First()) + oKardex[i - 1].cantAnte,
                                    //CostEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CostEntrada).First()),
                                    //TotalEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.TotalEntrada).First()),
                                    CantSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CantSalida).First()),
                                    //CostSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CostSalida).First()),
                                    //TotalSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.TotalSalida).First()),
                                    CantFinal = 0,
                                    CostFinal = 0,
                                    TotalFinal = 0
                                };

                                oKardexTotal.CantFinal = (oKardexTotal.CantEntrada) - oKardexTotal.CantSalida;
                                oKardexTotal.CostFinal = oKardex[i - 1].CostoActual;
                                oKardexTotal.TotalFinal = oKardexTotal.CantFinal * oKardexTotal.CostFinal;
                                oKardexRetorno.Add(oKardexTotal);
                            }
                            else
                            {
                                CantidadFinal = ObtenerCantFinal(oKardex[i].Tipo, oKardex[i].CantEntrada, oKardex[i].CantSalida, oKardex[i - 1].CantFinal);
                            }
                        }

                        //oKardex[i].TotalEntrada = oKardex[i].CantEntrada * oKardex[i].CostEntrada;
                        //oKardex[i].TotalSalida = oKardex[i].CantSalida * oKardex[i].CostSalida;

                        // Codigo de Ajuste de Ingreso
                        if (oKardex[i].CodSunat == "93")
                        {
                            oKardex[i].TotalEntrada = oKardex[i].CostEntrada;
                        }
                        else
                        {
                            oKardex[i].TotalEntrada = oKardex[i].CantEntrada * oKardex[i].CostEntrada;
                        }

                        // Codigo de Ajuste de Salida
                        if (oKardex[i].CodSunat == "94" || idOperacionDescuento == oKardex[i].Operacion)
                        {
                            oKardex[i].TotalSalida = oKardex[i].CostSalida;
                        }
                        else
                        {
                            oKardex[i].TotalSalida = oKardex[i].CantSalida * oKardex[i].CostSalida;
                        }


                        oKardex[i].CantFinal = CantidadFinal;
                        idArticuloTemp = oKardex[i].Articulo;
                        idArt = oKardex[i].Articulo;
                        oKardex[i].TotalFinal = oKardex[i].CantFinal * oKardex[i].CostFinal;
                        oKardexRetorno.Add(oKardex[i]);
                    }

                    KardexValorizadoE oKardexTotalUltimo = new KardexValorizadoE()
                    {
                        Articulo = idArticuloTemp,
                        codArticulo = "X",
                        NomOperacion = "TOTALES >>> ",
                        CantEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CantEntrada).First()) + oKardex[oKardex.Count - 1].cantAnte,
                        //CostEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CostEntrada).First()),
                        //TotalEntrada = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.TotalEntrada).First()),
                        CantSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CantSalida).First()),
                        //CostSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.CostSalida).First()),
                        //TotalSalida = Convert.ToDecimal((from x in oKardexTmp where x.Articulo == idArticuloTemp select x.TotalSalida).First()),
                        CantFinal = 0,
                        CostFinal = 0,
                        TotalFinal = 0
                    };

                    oKardexTotalUltimo.CantFinal = (oKardexTotalUltimo.CantEntrada) - oKardexTotalUltimo.CantSalida;
                    oKardexTotalUltimo.CostFinal = oKardexRetorno[oKardexRetorno.Count - 1].CostoActual;
                    oKardexTotalUltimo.TotalFinal = oKardexTotalUltimo.CantFinal * oKardexTotalUltimo.CostFinal;
                    oKardexRetorno.Add(oKardexTotalUltimo);
                }

                return oKardexRetorno;
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

        private Decimal ObtenerCantFinal(int TipoOpe, Decimal cantIngreso, Decimal cantSalida, Decimal cantFinal, decimal Anterior = 0)
        {
            Decimal CantidadTotal = 0;

            if (TipoOpe == 1)
            {
            CantidadTotal = (cantFinal + Anterior) + cantIngreso;  
            }
            else
            {    
            CantidadTotal = (cantFinal + Anterior) - cantSalida;
            }

            return CantidadTotal;
        }

    }
}
