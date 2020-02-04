using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class tesParametrosAD : DbConection
    {

        public tesParametrosE LlenarEntidad(IDataReader oReader)
        {
            tesParametrosE parametros = new tesParametrosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Rmv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.Rmv = oReader["Rmv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Rmv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porRmv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.porRmv = oReader["porRmv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porRmv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  parametros;        
        }

        public tesParametrosE InsertarTesParametros(tesParametrosE parametros)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTesParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
					oComando.Parameters.Add("@Rmv", SqlDbType.Decimal).Value = parametros.Rmv;
					oComando.Parameters.Add("@porRmv", SqlDbType.Decimal).Value = parametros.porRmv;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = parametros.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return parametros;
        }
        
        public tesParametrosE ActualizarTesParametros(tesParametrosE parametros)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTesParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
					oComando.Parameters.Add("@Rmv", SqlDbType.Decimal).Value = parametros.Rmv;
					oComando.Parameters.Add("@porRmv", SqlDbType.Decimal).Value = parametros.porRmv;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = parametros.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return parametros;
        }        

        public int EliminarTesParametros(Int32 idEmpresa)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTesParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<tesParametrosE> ListarTesParametros()
        {
            List<tesParametrosE> listaEntidad = new List<tesParametrosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTesParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }
        
        public tesParametrosE ObtenerTesParametros(Int32 idEmpresa)
        {
            tesParametrosE parametros = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTesParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            parametros = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return parametros;
        }

    }
}