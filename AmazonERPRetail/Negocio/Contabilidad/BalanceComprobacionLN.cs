using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
using System.Transactions;

namespace Negocio.Contabilidad
{
    public class BalanceComprobacionLN
    {
        public List<BalanceComprobacionE> ListarBalanceComprobacionAcumulado(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Version, String idMoneda, Int32 Nivel, String Formato)
        {
            try
            {
                List<BalanceComprobacionE> oListaBalanceComprobacion = new BalanceComprobacionAD().ListarBalanceComprobacionAcumulado(idEmpresa, idLocal, Anio, Mes, Version, idMoneda, Nivel, Formato);

                oListaBalanceComprobacion = (from x in oListaBalanceComprobacion where x.MayorDebe != 0 || x.MayorHaber !=0 select x).ToList();

                return oListaBalanceComprobacion;
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

        public List<BalanceComprobacionE> ListarBalanceComprobacionCCostoAcumulado(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Version, String idMoneda, String CCosto, String Formato, Int32 numNivel)
        {
            try
            {
                return new BalanceComprobacionAD().ListarBalanceComprobacionCCostoAcumulado(idEmpresa, idLocal, Anio, Mes, Version, idMoneda, CCosto, Formato,numNivel);
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
