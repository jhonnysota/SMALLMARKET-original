using System;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Util;

namespace Negocio.Contabilidad
{
    public class RegistroVentaGeneralAD : DbConection
    {

        public Int32 InsertarVentaGeneralMasivo(Int32 idEmpresa, DataTable oDt)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRegistroVentaMasivo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 360;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    SqlParameter param = new SqlParameter("@Tabla", SqlDbType.Structured);
                    param.TypeName = "TipoRegistroVentaGeneral";
                    param.Value = oDt;

                    oComando.Parameters.Add(param);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}