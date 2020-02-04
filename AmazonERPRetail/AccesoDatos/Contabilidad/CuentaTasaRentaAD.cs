using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class CuentaTasaRentaAD : DbConection
    {
        
        public CuentaTasaRentaE LlenarEntidad(IDataReader oReader)
        {
            CuentaTasaRentaE cuentatasarenta = new CuentaTasaRentaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentatasarenta.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentatasarenta.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentatasarenta.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTasaRenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentatasarenta.idTasaRenta = oReader["idTasaRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTasaRenta"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTasaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cuentatasarenta.desTasaRenta = oReader["desTasaRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTasaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cuentatasarenta.TasaRenta = oReader["TasaRenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaRenta"]);

            return  cuentatasarenta;        
        }

        public CuentaTasaRentaE InsertarCuentaTasaRenta(CuentaTasaRentaE cuentatasarenta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCuentaTasaRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cuentatasarenta.idEmpresa;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cuentatasarenta.codCuenta;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = cuentatasarenta.numVerPlanCuentas;
					oComando.Parameters.Add("@idTasaRenta", SqlDbType.VarChar, 2).Value = cuentatasarenta.idTasaRenta;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cuentatasarenta;
        }
        
     //   public CuentaTasaRentaE ActualizarCuentaTasaRenta(CuentaTasaRentaE cuentatasarenta)
     //   {
     //       using (SqlConnection oConexion = ConexionSql())
     //       {
     //           using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCuentaTasaRenta", oConexion))
     //           {
     //               oComando.CommandType = CommandType.StoredProcedure;

     //               oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cuentatasarenta.idEmpresa;
					//oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cuentatasarenta.codCuenta;
					//oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = cuentatasarenta.numVerPlanCuentas;
					//oComando.Parameters.Add("@idTasaRenta", SqlDbType.VarChar, 2).Value = cuentatasarenta.idTasaRenta;

     //               oConexion.Open();
     //               oComando.ExecuteNonQuery();
     //               oConexion.Close();
     //           }
     //       }

     //       return cuentatasarenta;
     //   }        

        public int EliminarCuentaTasaRenta(Int32 idEmpresa, String codCuenta, String numVerPlanCuentas)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCuentaTasaRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CuentaTasaRentaE> ListarCuentaTasaRenta(Int32 idEmpresa, String codCuenta, String numVerPlanCuentas)
        {
           List<CuentaTasaRentaE> listaEntidad = new List<CuentaTasaRentaE>();
           CuentaTasaRentaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCuentaTasaRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;

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
        
        public CuentaTasaRentaE ObtenerCuentaTasaRenta(Int32 idEmpresa, String codCuenta, String numVerPlanCuentas, String idTasaRenta)
        {        
            CuentaTasaRentaE cuentatasarenta = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCuentaTasaRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
					oComando.Parameters.Add("@idTasaRenta", SqlDbType.VarChar, 2).Value = idTasaRenta;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cuentatasarenta = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return cuentatasarenta;
        }

    }
}