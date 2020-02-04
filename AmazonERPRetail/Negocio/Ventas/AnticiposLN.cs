using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

using Entidades.Ventas;
using AccesoDatos.Ventas;

namespace Negocio.Ventas
{
    public class AnticiposLN
    {

        public AnticiposE InsertarAnticipos(AnticiposE anticipos)
        {
            try
            {
                return new AnticiposAD().InsertarAnticipos(anticipos);
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

        public AnticiposE ActualizarAnticipos(AnticiposE anticipos)
        {
            try
            {
                return new AnticiposAD().ActualizarAnticipos(anticipos);
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

        public int EliminarAnticipos(Int32 idEmpresa, Int32 idLocal, String idDocAnticipo, String numSerieAnticipo, String numDocAnticipo, Int32 idPersona)
        {
            try
            {
                return new AnticiposAD().EliminarAnticipos(idEmpresa, idLocal, idDocAnticipo, numSerieAnticipo, numDocAnticipo, idPersona);
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

        public List<AnticiposE> ListarAnticipos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            try
            {
                return new AnticiposAD().ListarAnticipos(idEmpresa, idLocal, idPersona);
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

        public AnticiposE ObtenerAnticipos(Int32 idEmpresa, Int32 idLocal, String idDocAnticipo, String numSerieAnticipo, String numDocAnticipo, Int32 idPersona)
        {
            try
            {
                return new AnticiposAD().ObtenerAnticipos(idEmpresa, idLocal, idDocAnticipo, numSerieAnticipo, numDocAnticipo, idPersona);
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

        public List<AnticiposE> ReporteAnticipos(Int32 idEmpresa, DateTime Desde, DateTime Hasta, String idMoneda, Int32 idPersona, Boolean PorAplicar, Boolean Aplicado)
        {
            try
            {
                List<AnticiposE> oListaTmp = new AnticiposAD().ReporteAnticipos(idEmpresa, Desde, Hasta, idMoneda, idPersona, PorAplicar, Aplicado);
                List<AnticiposE> oListaDevuelta = new List<AnticiposE>();

                if (oListaTmp != null && oListaTmp.Count > 0)
                {
                    foreach (AnticiposE item in oListaTmp)
                    {
                        if (item.Tipo == "C")
                        {
                            item.TotalSaldoTmp = item.Haber;
                        }

                        oListaDevuelta.Add(item);
                    }

                    var agrupado = oListaTmp.GroupBy(x => new { x.RazonSocial, x.idDocAnticipo, x.numSerieAnticipo, x.numDocAnticipo }).Select(group =>
                                                                new
                                                                {
                                                                    group.Key,
                                                                    totDebe = group.Sum(x => x.Debe),
                                                                    totHaber = group.Sum(x => x.Haber),
                                                                    numOrden = group.Max(x => x.Orden)
                                                                });
                    foreach (var item in agrupado)
                    {
                        AnticiposE ItemNuevo = new AnticiposE()
                        {
                            Banco = String.Empty,
                            idDocAnticipo = item.Key.idDocAnticipo,
                            numSerieAnticipo = item.Key.numSerieAnticipo,
                            numDocAnticipo = item.Key.numDocAnticipo,
                            numDocFactura = "x",
                            RUC = String.Empty,
                            RazonSocial = item.Key.RazonSocial,
                            nomArticulo = "Total " + item.Key.RazonSocial,
                            Debe = item.totDebe,
                            Haber = item.totHaber,
                            TotalSaldoTmp = 0,
                            Tipo = "x",
                            Orden = item.numOrden + 1
                        };

                        oListaDevuelta.Add(ItemNuevo);
                    }

                    oListaDevuelta = (from x in oListaDevuelta orderby x.RazonSocial, x.idDocAnticipo, x.numSerieAnticipo, x.numDocAnticipo, x.Orden select x).ToList();
                    Decimal MontoHaber = 0;
                    //Int32 MaximoOrden = oListaDevuelta.Max(x => x.Orden);

                    foreach (AnticiposE item in oListaDevuelta)
                    {
                        if (item.nomArticulo.Substring(0, 5) == "Total")
                        {
                            item.numDocAnticipo = "x";
                            item.numDocFactura = "x";
                            item.RUC = String.Empty;
                        }

                        if (item.Tipo == "C")
                        {
                            MontoHaber = item.TotalSaldoTmp;
                        }
                        else if (item.Tipo == "D")
                        {
                            item.TotalSaldoTmp = MontoHaber - item.Debe;
                            MontoHaber = item.TotalSaldoTmp;
                        }
                        else
                        {
                            MontoHaber = 0;
                        }
                    }

                    //foreach (AnticiposE item in oListaDevuelta)
                    //{
                    //    if (item.nomArticulo.Substring(0, 5) == "Total")
                    //    {
                    //        //item.numDocAnticipo = "x";
                    //        //item.numDocFactura = "x";
                    //        //item.RUC = String.Empty;

                    //        //if (item.Orden == MaximoOrden - 1)
                    //        //{
                    //        //    if (item.TotalSaldoTmp > 0)
                    //        //    {
                    //        //        item.CambiarColor = true;
                    //        //    }
                    //        //    else
                    //        //    {
                    //        //        item.CambiarColor = false;
                    //        //    }
                    //        //}
                    //        //else
                    //        //{
                    //        //    item.CambiarColor = false;
                    //        //}

                            
                    //    }

                    //    //if (item.Tipo == "C")
                    //    //{
                    //    //    MontoHaber = item.TotalSaldoTmp;
                    //    //}
                    //    //else if (item.Tipo == "D")
                    //    //{
                    //    //    item.TotalSaldoTmp = MontoHaber - item.Debe;
                    //    //    MontoHaber = item.TotalSaldoTmp;
                    //    //}
                    //    //else
                    //    //{
                    //    //    MontoHaber = 0;
                    //    //}
                    //}
                }

                return oListaDevuelta;
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
