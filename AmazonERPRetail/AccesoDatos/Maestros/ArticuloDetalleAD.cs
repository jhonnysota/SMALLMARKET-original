using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ArticuloDetalleAD : DbConection
    {

        public ArticuloDetalleE LlenarEntidad(IDataReader oReader)
        {
            ArticuloDetalleE articulodetalle = new ArticuloDetalleE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articulodetalle.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articulodetalle.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCaracteristica'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulodetalle.idCaracteristica = oReader["idCaracteristica"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCaracteristica"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articulodetalle.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articulodetalle.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articulodetalle.fechaRegistro = oReader["fechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articulodetalle.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articulodetalle.fechaModificacion = oReader["fechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaModificacion"]);

            //extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulodetalle.DesArticulo = oReader["DesArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesArticulo"]);

            return  articulodetalle;        
        }

        public ArticuloDetalleE InsertarArticuloDetalle(ArticuloDetalleE articulodetalle)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articulodetalle.idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = articulodetalle.idArticulo;
                    oComando.Parameters.Add("@idCaracteristica", SqlDbType.Int).Value = articulodetalle.idCaracteristica;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = articulodetalle.Descripcion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = articulodetalle.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articulodetalle;
        }
        
        public ArticuloDetalleE ActualizarArticuloDetalle(ArticuloDetalleE articulodetalle)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articulodetalle.idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = articulodetalle.idArticulo;
                    oComando.Parameters.Add("@idCaracteristica", SqlDbType.Int).Value = articulodetalle.idCaracteristica;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = articulodetalle.Descripcion;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = articulodetalle.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articulodetalle;
        }

        public Int32 EliminarArticuloDetalle(Int32 idEmpresa, Int32 idArticulo, Int32 idCaracteristica)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarArticuloDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@idCaracteristica", SqlDbType.Int).Value = idCaracteristica;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ArticuloDetalleE> ListarArticuloDetalle(Int32 idArticulo)
        {
           List<ArticuloDetalleE> listaEntidad = new List<ArticuloDetalleE>();
           ArticuloDetalleE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

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

        public ArticuloDetalleE ObtenerArticuloDetalle(Int32 idEmpresa, Int32 idArticulo, Int32 idCaracteristica)
        {        
            ArticuloDetalleE articulodetalle = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@idCaracteristica", SqlDbType.Int).Value = idCaracteristica;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articulodetalle = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articulodetalle;
        }

    }
}