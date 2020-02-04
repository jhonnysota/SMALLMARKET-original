using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos
{
    public class CategoriaVendedorLineaAD : DbConection
    {
        
        public CategoriaVendedorLineaE LlenarEntidad(IDataReader oReader)
        {
            CategoriaVendedorLineaE categorialinea = new CategoriaVendedorLineaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categorialinea.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCategoria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categorialinea.idCategoria = oReader["idCategoria"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCategoria"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLinea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                categorialinea.idLinea = oReader["idLinea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idLinea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categorialinea.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categorialinea.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categorialinea.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categorialinea.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                categorialinea.desLinea = oReader["desLinea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLinea"]);
			
            return  categorialinea;        
        }

        public CategoriaVendedorLineaE InsertarCategoriaVendedorLinea(CategoriaVendedorLineaE categorialinea)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCategoriaVendedorLinea", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = categorialinea.idEmpresa;
					oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = categorialinea.idCategoria;
					oComando.Parameters.Add("@idLinea", SqlDbType.VarChar,2).Value = categorialinea.idLinea;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = categorialinea.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = categorialinea.FechaRegistro;
                    //oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = categorialinea.UsuarioModificacion;
                    //oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = categorialinea.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return categorialinea;
        }

        public CategoriaVendedorLineaE ActualizarCategoriaVendedorLinea(CategoriaVendedorLineaE categorialinea)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCategoriaVendedorLinea", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = categorialinea.idEmpresa;
					oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = categorialinea.idCategoria;
					oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = categorialinea.idLinea;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = categorialinea.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = categorialinea.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = categorialinea.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = categorialinea.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return categorialinea;
        }

        public int EliminarCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria, string  idLinea)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCategoriaVendedorLinea", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria;
					oComando.Parameters.Add("@idLinea", SqlDbType.VarChar,2).Value = idLinea;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CategoriaVendedorLineaE> ListarCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria)
        {
            List<CategoriaVendedorLineaE> listaEntidad = new List<CategoriaVendedorLineaE>();
            CategoriaVendedorLineaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCategoriaVendedorLinea", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria;
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

                oConexion.Close();
            }

            return listaEntidad;
        }

        public CategoriaVendedorLineaE ObtenerCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria, Int32 idLinea)
        {
            CategoriaVendedorLineaE categorialinea = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCategoriaVendedorLinea", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria;
					oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = idLinea;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            categorialinea = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return categorialinea;
        }
    }
}