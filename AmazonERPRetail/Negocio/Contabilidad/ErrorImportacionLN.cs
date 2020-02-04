using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contabilidad;
using Entidades.Contabilidad;

namespace Negocio.Contabilidad
{
    public class ErrorImportacionLN
    {
        public List<ErrorImportacionE> ListarErrorImportacion(Int32 idEmpresa ,String Archivo)
        {
            try
            {
                return new ErrorImportacionAD().ListarErrorImportacion(idEmpresa,Archivo);
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
