using AccesoDatos.Contabilidad;
using Entidades.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contabilidad
{
    public class InventarioBalanceLN
    {

        public List<InventarioBalanceE> ReporteInventarioBalance(Int32 idEmpresa, Int32 idLocal, String ANO_PERIODO, String COD_PERIODO, String VERSION, String COD_CUENTA)
        {
            try
            {
                return new InventarioBalanceAD().ReporteInventarioBalance(idEmpresa, idLocal, ANO_PERIODO, COD_PERIODO, VERSION, COD_CUENTA);
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
