using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Generales;

namespace Negocio.Generales
{
    public class ImportarComprasLN 
    {

        public int ImportarCompras(String codEmpresa, String codSucursal, String codLibro, DateTime fecDesde, DateTime fecHasta, int idEmpresa)
        {
            try
            {
                return new ImportarComprasAD().ImportarCompras(codEmpresa, codSucursal, codLibro, fecDesde, fecHasta, idEmpresa);
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
