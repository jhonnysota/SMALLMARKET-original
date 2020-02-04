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
    public class DisFactorLN
    {
        public void ProcesoDistribucionFactor(int idEmpresa, int idLocal, DateTime FechaInicio, DateTime FechaFin, Decimal FactorDistribuidor, String Usuario)
        {
            try
            {
                new DisFactorAD().ProcesoDistribucionFactor(idEmpresa, idLocal, FechaInicio, FechaFin, FactorDistribuidor, Usuario);

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

        public void ProcesoIngresoAlmacenFactor(int idEmpresa, int idLocal, DateTime FechaProceso, string Diario, string File, String Usuario)
        {
            try
            {
                new DisFactorAD().ProcesoIngresoAlmacenFactor(idEmpresa, idLocal, FechaProceso, Diario, File, Usuario);

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
