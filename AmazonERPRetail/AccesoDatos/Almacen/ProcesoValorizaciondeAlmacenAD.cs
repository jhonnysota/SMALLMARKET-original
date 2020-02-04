using System;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class ProcesoValorizaciondeAlmacenAD : DbConection
    {

        public ProcesoValorizaciondeAlmacenE LlenarEntidad(IDataReader oReader)
        {
            ProcesoValorizaciondeAlmacenE ValorizaciondeAlmacen = new ProcesoValorizaciondeAlmacenE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ValorizaciondeAlmacen.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ValorizaciondeAlmacen.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ValorizaciondeAlmacen.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioInicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ValorizaciondeAlmacen.AnioInicio = oReader["AnioInicio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioInicio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesInicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ValorizaciondeAlmacen.MesInicio = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ValorizaciondeAlmacen.AnioFin = oReader["AnioFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ValorizaciondeAlmacen.MesFin = oReader["MesFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesFin"]);

            return ValorizaciondeAlmacen;
        }

        public int ValorizaciondeAlmacen(Int32 idEmpresa, Int32 idAlmacen, Int32 idArticulo, String AnioInicio, String MesInicio, String AnioFin, String MesFin, String ValConversion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesaValorizacionAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@MesInicio", SqlDbType.VarChar, 2).Value = MesInicio;
                    oComando.Parameters.Add("@AnioInicio", SqlDbType.VarChar, 4).Value = AnioInicio;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@AnioFin", SqlDbType.VarChar, 4).Value = AnioFin;
                    oComando.Parameters.Add("@ValConversion", SqlDbType.VarChar, 1).Value = ValConversion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}
