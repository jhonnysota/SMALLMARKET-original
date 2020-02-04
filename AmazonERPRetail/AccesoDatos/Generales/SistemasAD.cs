using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class SistemasAD : DbConection
    {

        public SistemasE LLenarEntidad(IDataReader oReader)
        {
            SistemasE Sistemas = new SistemasE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Sistemas.idSistema = oReader["idSistema"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Sistemas.descripcion = oReader["descripcion"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["descripcion"]);

            return Sistemas;
        }

        public List<SistemasE> ListarSistemas()
        {
            List<SistemasE> Lista = new List<SistemasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.uspListarSistemas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();

                    SqlDataReader oReader = oComando.ExecuteReader();

                    while (oReader.Read())
                    {
                        Lista.Add(LLenarEntidad(oReader));
                    }
                }
            }

            return Lista;
        }

    }
}
