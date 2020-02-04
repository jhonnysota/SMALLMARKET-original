using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class EmpresaImagenesAD : DbConection
    {

        public EmpresaImagenesE LlenarEntidad(IDataReader oReader)
        {
            EmpresaImagenesE empresaimagenes = new EmpresaImagenesE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImagen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				empresaimagenes.idImagen = oReader["idImagen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImagen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				empresaimagenes.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				empresaimagenes.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Extension'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				empresaimagenes.Extension = oReader["Extension"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Extension"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Imagen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                empresaimagenes.Imagen = oReader["Imagen"] == DBNull.Value ? null : (byte[])(oReader["Imagen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				empresaimagenes.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				empresaimagenes.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				empresaimagenes.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				empresaimagenes.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  empresaimagenes;        
        }

        public EmpresaImagenesE InsertarEmpresaImagenes(EmpresaImagenesE empresaimagenes)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmpresaImagenes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = empresaimagenes.idEmpresa;
                    oComando.Parameters.Add("@idImagen", SqlDbType.Int).Value = empresaimagenes.idImagen;
					oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = empresaimagenes.Nombre;
					oComando.Parameters.Add("@Extension", SqlDbType.VarChar, 5).Value = empresaimagenes.Extension;
                    oComando.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = empresaimagenes.Imagen;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = empresaimagenes.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return empresaimagenes;
        }
        
        public EmpresaImagenesE ActualizarEmpresaImagenes(EmpresaImagenesE empresaimagenes)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmpresaImagenes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImagen", SqlDbType.Int).Value = empresaimagenes.idImagen;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = empresaimagenes.idEmpresa;
					oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = empresaimagenes.Nombre;
					oComando.Parameters.Add("@Extension", SqlDbType.VarChar, 5).Value = empresaimagenes.Extension;
                    oComando.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = empresaimagenes.Imagen;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = empresaimagenes.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return empresaimagenes;
        }

        public int EliminarEmpresaImagenes(Int32 idImagen, Int32 idEmpresa)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEmpresaImagenes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImagen", SqlDbType.Int).Value = idImagen;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EmpresaImagenesE> ListarEmpresaImagenes(Int32 idEmpresa)
        {
           List<EmpresaImagenesE> listaEntidad = new List<EmpresaImagenesE>();
           EmpresaImagenesE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmpresaImagenes", oConexion))
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

        public EmpresaImagenesE ObtenerEmpresaConImagenes(Int32 idImagen, Int32 idEmpresa)
        {        
            EmpresaImagenesE empresaimagenes = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmpresaConImagenes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImagen", SqlDbType.Int).Value = idImagen;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            empresaimagenes = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return empresaimagenes;
        }

        public EmpresaImagenesE ObtenerEmpresaSinImagenes(Int32 idImagen, Int32 idEmpresa)
        {
            EmpresaImagenesE empresaimagenes = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmpresaSinImagenes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImagen", SqlDbType.Int).Value = idImagen;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            empresaimagenes = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return empresaimagenes;
        }

    }
}