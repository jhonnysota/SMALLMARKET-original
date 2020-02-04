using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class CuentasMigracionAD : DbConection
    {

        public CuentasMigracionE LlenarEntidad(IDataReader oReader)
        {
            CuentasMigracionE CuentaMigracion = new CuentasMigracionE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.tipo = oReader["tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cuentadestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.cuentadestino = oReader["cuentadestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["cuentadestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cuentaorigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.cuentaorigen = oReader["cuentaorigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["cuentaorigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ccosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.ccosto = oReader["ccosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ccosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombredestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.nombredestino = oReader["nombredestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombredestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombreorigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.nombreorigen = oReader["nombreorigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombreorigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombreccosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                CuentaMigracion.nombreccosto = oReader["nombreccosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombreccosto"]);

            return CuentaMigracion;
        }

        public CuentasMigracionE InsertarCuentasMigracion(CuentasMigracionE CuentasMigracion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCuentasMigracion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = CuentasMigracion.idEmpresa;
                    oComando.Parameters.Add("@tipo", SqlDbType.VarChar, 1).Value = CuentasMigracion.tipo;
                    oComando.Parameters.Add("@cuentadestino", SqlDbType.VarChar, 20).Value = CuentasMigracion.cuentadestino;
                    oComando.Parameters.Add("@cuentaorigen", SqlDbType.VarChar, 20).Value = CuentasMigracion.cuentaorigen;
                    oComando.Parameters.Add("@ccosto", SqlDbType.VarChar, 20).Value = CuentasMigracion.ccosto;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = CuentasMigracion.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = CuentasMigracion.codCuenta;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return CuentasMigracion;
        }

        public Int32 EliminarCuentasMigracion(CuentasMigracionE CuentasMigracion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCuentasMigracion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = CuentasMigracion.idEmpresa;
                    oComando.Parameters.Add("@tipo", SqlDbType.VarChar, 1).Value = CuentasMigracion.tipo;
                    oComando.Parameters.Add("@cuentadestino", SqlDbType.VarChar, 20).Value = CuentasMigracion.cuentadestino;
                    oComando.Parameters.Add("@cuentaorigen", SqlDbType.VarChar, 20).Value = CuentasMigracion.cuentaorigen;
                    oComando.Parameters.Add("@ccosto", SqlDbType.VarChar, 20).Value = CuentasMigracion.ccosto;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = CuentasMigracion.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = CuentasMigracion.codCuenta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CuentasMigracionE> ListarCuentasMigracion(Int32 idEmpresa)
        {
            List<CuentasMigracionE> listaEntidad = new List<CuentasMigracionE>();
            CuentasMigracionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCuentasMigracion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<CuentasMigracionE> ListarCuentasConcar(Int32 idEmpresa, String cuentadestino, String nombredestino)
        {
            List<CuentasMigracionE> listaEntidad = new List<CuentasMigracionE>();
            CuentasMigracionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCuentasConcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@cuentadestino", SqlDbType.VarChar, 20).Value = cuentadestino;
                    oComando.Parameters.Add("@nombredestino", SqlDbType.VarChar, 200).Value = nombredestino;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public Int32 MigrarConcarSQL(String empresa, String ejer, Int32 idEmpresa)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MigrarConcarSQL", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@empresa", SqlDbType.VarChar, 4).Value = empresa;
                    oComando.Parameters.Add("@ejer", SqlDbType.VarChar, 2).Value = ejer;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}
