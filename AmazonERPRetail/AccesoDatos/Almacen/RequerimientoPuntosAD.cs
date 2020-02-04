using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class RequerimientoPuntosAD : DbConection
    {

        public RequerimientoPuntosE LlenarEntidad(IDataReader oReader)
        {
            RequerimientoPuntosE requerimientopuntos = new RequerimientoPuntosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPuntoReq'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientopuntos.idPuntoReq = oReader["idPuntoReq"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPuntoReq"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientopuntos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientopuntos.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientopuntos.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientopuntos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientopuntos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientopuntos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientopuntos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  requerimientopuntos;        
        }

        public RequerimientoPuntosE InsertarRequerimientoPuntos(RequerimientoPuntosE requerimientopuntos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRequerimientoPuntos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requerimientopuntos.idEmpresa;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = requerimientopuntos.Descripcion;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = requerimientopuntos.Observacion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = requerimientopuntos.UsuarioRegistro;

                    oConexion.Open();
                    requerimientopuntos.idPuntoReq = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return requerimientopuntos;
        }
        
        public RequerimientoPuntosE ActualizarRequerimientoPuntos(RequerimientoPuntosE requerimientopuntos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRequerimientoPuntos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = requerimientopuntos.idPuntoReq;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requerimientopuntos.idEmpresa;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = requerimientopuntos.Descripcion;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = requerimientopuntos.Observacion;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = requerimientopuntos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requerimientopuntos;
        }        

        public int EliminarRequerimientoPuntos(Int32 idPuntoReq)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRequerimientoPuntos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = idPuntoReq;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RequerimientoPuntosE> ListarRequerimientoPuntos(Int32 idEmpresa)
        {
           List<RequerimientoPuntosE> listaEntidad = new List<RequerimientoPuntosE>();
           RequerimientoPuntosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRequerimientoPuntos", oConexion))
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
        
        public RequerimientoPuntosE ObtenerRequerimientoPuntos(Int32 idPuntoReq)
        {        
            RequerimientoPuntosE requerimientopuntos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRequerimientoPuntos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = idPuntoReq;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            requerimientopuntos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return requerimientopuntos;
        }

    }
}