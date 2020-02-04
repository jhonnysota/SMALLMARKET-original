using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class CuentaCCostoAD : DbConection
    {
        
        public CuentaCCostoE LlenarEntidad(IDataReader oReader)
        {
            CuentaCCostoE cuentaccosto = new CuentaCCostoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCuentaC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.idCuentaC = oReader["idCuentaC"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCuentaC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.idCCosto = oReader["idCCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDigitos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.numDigitos = oReader["numDigitos"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numDigitos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cuentaccosto.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  cuentaccosto;        
        }

        public CuentaCCostoE InsertarCuentaCCosto(CuentaCCostoE cuentaccosto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCuentaCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cuentaccosto.idEmpresa;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cuentaccosto.codCuenta;
					oComando.Parameters.Add("@idCCosto", SqlDbType.VarChar, 10).Value = cuentaccosto.idCCosto;
					oComando.Parameters.Add("@numDigitos", SqlDbType.Int).Value = cuentaccosto.numDigitos;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = cuentaccosto.UsuarioRegistro;

                    oConexion.Open();
                    cuentaccosto.idCuentaC = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return cuentaccosto;
        }
        
        public CuentaCCostoE ActualizarCuentaCCosto(CuentaCCostoE cuentaccosto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCuentaCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cuentaccosto.idEmpresa;
					oComando.Parameters.Add("@idCuentaC", SqlDbType.Int).Value = cuentaccosto.idCuentaC;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cuentaccosto.codCuenta;
					oComando.Parameters.Add("@idCCosto", SqlDbType.VarChar, 10).Value = cuentaccosto.idCCosto;
					oComando.Parameters.Add("@numDigitos", SqlDbType.Int).Value = cuentaccosto.numDigitos;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = cuentaccosto.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cuentaccosto;
        }

        public Int32 EliminarCuentaCCosto(Int32 idEmpresa, Int32 idCuentaC)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCuentaCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCuentaC", SqlDbType.Int).Value = idCuentaC;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CuentaCCostoE> ListarCuentaCCosto(Int32 idEmpresa)
        {
           List<CuentaCCostoE> listaEntidad = new List<CuentaCCostoE>();
           CuentaCCostoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCuentaCCosto", oConexion))
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
        
        public CuentaCCostoE ObtenerCuentaCCosto(Int32 idEmpresa, Int32 idCuentaC)
        {        
            CuentaCCostoE cuentaccosto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCuentaCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCuentaC", SqlDbType.Int).Value = idCuentaC;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cuentaccosto = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return cuentaccosto;
        }

    }
}