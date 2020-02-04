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
    public class FlujoDeCajaLN
    {
        public List<FlujoDeCajaE> ReporteFlujoCaja(Int32 idEmpresa, Int32 idLocal, String MesAnoIni, String MesAnoFin)
        {
            try
            {
                return new FlujoDeCajaAD().ReporteFlujoCaja(idEmpresa, idLocal, MesAnoIni, MesAnoFin);
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

        public List<FlujoDeCajaE> ReporteFlujoCajaDetalle(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Movimiento, String Partida)
        {
            try
            {
                return new FlujoDeCajaAD().ReporteFlujoCajaDetalle(idEmpresa, idLocal, Anio, Mes, Movimiento, Partida);
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
