using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ClienteAsociadosAD : DbConection
    {

        public ClienteAsociadosE LlenarEntidad(IDataReader oReader)
        {
            ClienteAsociadosE clienteasociados = new ClienteAsociadosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.IdEmpresa = oReader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdAsociado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.IdAsociado = oReader["IdAsociado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdAsociado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteasociados.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  clienteasociados;        
        }

        public ClienteAsociadosE InsertarClienteAsociados(ClienteAsociadosE clienteasociados)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarClienteAsociados", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = clienteasociados.idPersona;
					oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = clienteasociados.IdEmpresa;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 50).Value = clienteasociados.RazonSocial;
					oComando.Parameters.Add("@RUC", SqlDbType.NVarChar, 25).Value = clienteasociados.RUC;
					oComando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = clienteasociados.Direccion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = clienteasociados.UsuarioRegistro;

                    oConexion.Open();
                    clienteasociados.IdAsociado = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return clienteasociados;
        }
        
        public ClienteAsociadosE ActualizarClienteAsociados(ClienteAsociadosE clienteasociados)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarClienteAsociados", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = clienteasociados.idPersona;
					oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = clienteasociados.IdEmpresa;
					oComando.Parameters.Add("@IdAsociado", SqlDbType.Int).Value = clienteasociados.IdAsociado;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 50).Value = clienteasociados.RazonSocial;
					oComando.Parameters.Add("@RUC", SqlDbType.NVarChar, 25).Value = clienteasociados.RUC;
					oComando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = clienteasociados.Direccion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = clienteasociados.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return clienteasociados;
        }        

        public int EliminarClienteAsociados(Int32 idPersona, Int32 IdEmpresa, Int32 IdAsociado)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarClienteAsociados", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
					oComando.Parameters.Add("@IdAsociado", SqlDbType.Int).Value = IdAsociado;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ClienteAsociadosE> ListarClienteAsociados(Int32 idEmpresa, Int32 idPersona)
        {
           List<ClienteAsociadosE> listaEntidad = new List<ClienteAsociadosE>();
           ClienteAsociadosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarClienteAsociados", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

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
        
        public ClienteAsociadosE ObtenerClienteAsociados(Int32 idPersona, Int32 IdEmpresa, Int32 IdAsociado)
        {        
            ClienteAsociadosE clienteasociados = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerClienteAsociados", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
					oComando.Parameters.Add("@IdAsociado", SqlDbType.Int).Value = IdAsociado;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            clienteasociados = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return clienteasociados;
        }

    }
}