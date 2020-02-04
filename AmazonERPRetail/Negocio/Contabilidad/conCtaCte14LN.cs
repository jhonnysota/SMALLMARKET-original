using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;

namespace Negocio.Contabilidad
{
    public class conCtaCte14LN
    {
        public List<conCtaCteE14> ReporteConCtaCte14(Int32 idEmpresa, String numPlanCta, String ano, String cuenta_ini, String cuenta_fin,
                                                          Int32 idPersona, String mes_inicial, String mes_fin, String idmoneda, String historico, String tipo_reporte)
        {
            try
            {
                return new conCtaCte14AD().ReporteConCtaCte14(idEmpresa, numPlanCta, ano, cuenta_ini, cuenta_fin, idPersona, mes_inicial, mes_fin, idmoneda, historico, tipo_reporte);
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
