using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class PublicidadLN
    {
        public List<PublicidadE> ListarReportePublicidad(Int32 idEmpresa, DateTime fecha)
        {
            try
            {
                return new PublicidadAD().ListarReportePublicidad(idEmpresa, fecha);
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
