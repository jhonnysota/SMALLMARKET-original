using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class RegistroLibroMayorLN
    {
        public List<RegistroLibroMayorE> RegistroLibroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String codCuentaIni, String codCuentaFin)
        {
            try
            {
                return new RegistroLibroMayorAD().RegistroLibroMayor(idEmpresa, idLocal, numVerPlanCuentas, AnioPeriodo, MesIni, MesFin, codCuentaIni, codCuentaFin);
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
