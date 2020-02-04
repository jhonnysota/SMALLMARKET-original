using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioCCostosAD : DbConection
    {
        
        public UsuarioCCostosE LlenarEntidad(IDataReader oReader)
        {
            UsuarioCCostosE usuarioccostos = new UsuarioCCostosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioccostos.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioccostos.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioccostos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioccostos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioccostos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioccostos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioccostos.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            return  usuarioccostos;        
        }

        public UsuarioCCostosE InsertarUsuarioCCostos(UsuarioCCostosE usuarioccostos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioccostos.idPersona;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = usuarioccostos.idCCostos;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.NVarChar, 50).Value = usuarioccostos.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioccostos;
        }
        
        public UsuarioCCostosE ActualizarUsuarioCCostos(UsuarioCCostosE usuarioccostos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioccostos.idPersona;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = usuarioccostos.idCCostos;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.NVarChar, 50).Value = usuarioccostos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioccostos;
        }        

        public Int32 EliminarUsuarioCCostos(Int32 idPersona)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioCCostosE> ListarUsuarioCCostos(Int32 idPersona, Int32 idEmpresa)
        {
           List<UsuarioCCostosE> listaEntidad = new List<UsuarioCCostosE>();
           UsuarioCCostosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
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
        
        public UsuarioCCostosE ObtenerUsuarioCCostos(Int32 idPersona, Int32 idCCostos)
        {        
            UsuarioCCostosE usuarioccostos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = usuarioccostos.idCCostos;
             
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuarioccostos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return usuarioccostos;
        }

    }
}