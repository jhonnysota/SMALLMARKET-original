using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioPlanillaAD : DbConection
    {
        
        public UsuarioPlanillaE LlenarEntidad(IDataReader oReader)
        {
            UsuarioPlanillaE usuarioplanilla = new UsuarioPlanillaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioplanilla.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanillas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioplanilla.idPlanillas = oReader["idPlanillas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idPlanillas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioplanilla.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VerRemun'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioplanilla.VerRemun = oReader["VerRemun"] == DBNull.Value ? true : Convert.ToBoolean(oReader["VerRemun"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioplanilla.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioplanilla.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioplanilla.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioplanilla.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  usuarioplanilla;        
        }

        public UsuarioPlanillaE InsertarUsuarioPlanilla(UsuarioPlanillaE usuarioplanilla)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioplanilla.idPersona;
					oComando.Parameters.Add("@idPlanillas", SqlDbType.VarChar, 3).Value = usuarioplanilla.idPlanillas;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioplanilla.idEmpresa;
                    oComando.Parameters.Add("@VerRemun", SqlDbType.Bit).Value = usuarioplanilla.VerRemun;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = usuarioplanilla.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = usuarioplanilla.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = usuarioplanilla.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = usuarioplanilla.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioplanilla;
        }
        
        public UsuarioPlanillaE ActualizarUsuarioPlanilla(UsuarioPlanillaE usuarioplanilla)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioplanilla.idPersona;
					oComando.Parameters.Add("@idPlanillas", SqlDbType.VarChar, 3).Value = usuarioplanilla.idPlanillas;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioplanilla.idEmpresa;
                    oComando.Parameters.Add("@VerRemun", SqlDbType.Bit).Value = usuarioplanilla.VerRemun;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = usuarioplanilla.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = usuarioplanilla.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = usuarioplanilla.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = usuarioplanilla.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioplanilla;
        }        

        public int EliminarUsuarioPlanilla(Int32 idPersona, Int32 idEmpresa)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioPlanillaE> ListarUsuarioPlanilla(Int32 idEmpresa, Int32 idPersona)
        {
           List<UsuarioPlanillaE> listaEntidad = new List<UsuarioPlanillaE>();
           UsuarioPlanillaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
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
        
        public UsuarioPlanillaE ObtenerUsuarioPlanilla(Int32 idPersona, String idPlanillas, Int32 idEmpresa)
        {        
            UsuarioPlanillaE usuarioplanilla = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idPlanillas", SqlDbType.VarChar, 3).Value = idPlanillas;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuarioplanilla = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return usuarioplanilla;
        }

    }
}