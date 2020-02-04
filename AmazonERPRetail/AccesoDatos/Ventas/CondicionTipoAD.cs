using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CondicionTipoAD : DbConection
    {
        
        public CondicionTipoE LlenarEntidad(IDataReader oReader)
        {
            CondicionTipoE condiciontipo = new CondicionTipoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciontipo.idTipCondicion = oReader["idTipCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciontipo.desTipCondicion = oReader["desTipCondicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciontipo.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciontipo.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciontipo.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciontipo.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  condiciontipo;        
        }

        public CondicionTipoE InsertarCondicionTipo(CondicionTipoE condiciontipo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCondicionTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@desTipCondicion", SqlDbType.VarChar, 50).Value = condiciontipo.desTipCondicion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = condiciontipo.UsuarioRegistro;

                    oConexion.Open();
                    condiciontipo.idTipCondicion = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return condiciontipo;
        }
        
        public CondicionTipoE ActualizarCondicionTipo(CondicionTipoE condiciontipo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCondicionTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = condiciontipo.idTipCondicion;
					oComando.Parameters.Add("@desTipCondicion", SqlDbType.VarChar, 50).Value = condiciontipo.desTipCondicion;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = condiciontipo.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    
                }
            }

            return condiciontipo;
        }

        public List<CondicionTipoE> ListarCondicionTipo()
        {
            List<CondicionTipoE> listaEntidad = new List<CondicionTipoE>();
            CondicionTipoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCondicionTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public CondicionTipoE ObtenerCondicionTipo(Int32 idTipCondicion)
        {        
            CondicionTipoE condiciontipo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCondicionTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = idTipCondicion;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            condiciontipo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return condiciontipo;
        }

    }
}