using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CategoriaVendedorAD : DbConection
    {
        
        public CategoriaVendedorE LlenarEntidad(IDataReader oReader)
        {
            CategoriaVendedorE categoria = new CategoriaVendedorE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCategoria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.idCategoria = oReader["idCategoria"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCategoria"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCategoria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.codCategoria = oReader["codCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCategoria"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCategoria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.desCategoria = oReader["desCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCategoria"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCatagoria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.indCatagoria = oReader["indCatagoria"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCatagoria"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				categoria.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);


            //extenciones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                categoria.codVendedor = oReader["codVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                categoria.desVendedor = oReader["desVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                categoria.codLinea = oReader["codLinea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codLinea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                categoria.desLinea = oReader["desLinea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLinea"]);
			


            return  categoria;        
        }

        public CategoriaVendedorE InsertarCategoriaVendedor(CategoriaVendedorE categoria)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCategoriaVendedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = categoria.idEmpresa;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = categoria.idVendedor;
					oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 150).Value = categoria.codCategoria;
					oComando.Parameters.Add("@desCategoria", SqlDbType.VarChar, 150).Value = categoria.desCategoria;
					oComando.Parameters.Add("@indCatagoria", SqlDbType.Bit).Value = categoria.indCatagoria;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = categoria.UsuarioRegistro;
                    //oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = categoria.FechaRegistro;
                    //oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = categoria.UsuarioModificacion;
                    //oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = categoria.FechaModificacion;

                    oConexion.Open();
                    categoria.idCategoria = Int32.Parse(oComando.ExecuteScalar().ToString());
                    oConexion.Close();
                }
            }

            return categoria;
        }

        public CategoriaVendedorE ActualizarCategoriaVendedor(CategoriaVendedorE categoria)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCategoriaVendedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = categoria.idEmpresa;
					oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = categoria.idCategoria;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = categoria.idVendedor;
					oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 150).Value = categoria.codCategoria;
					oComando.Parameters.Add("@desCategoria", SqlDbType.VarChar, 150).Value = categoria.desCategoria;
					oComando.Parameters.Add("@indCatagoria", SqlDbType.Bit).Value = categoria.indCatagoria;
					//oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = categoria.UsuarioRegistro;
					//oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = categoria.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = categoria.UsuarioModificacion;
					//oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = categoria.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return categoria;
        }

        public int EliminarCategoriaVendedor(Int32 idEmpresa, Int32 idCategoria)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCategoriaVendedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CategoriaVendedorE> ListarCategoriaVendedor(string paramBusquedad)
        {
           List<CategoriaVendedorE> listaEntidad = new List<CategoriaVendedorE>();
           CategoriaVendedorE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCategoriaVendedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@paramBusquedad", SqlDbType.VarChar, 150).Value = paramBusquedad;
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

        public CategoriaVendedorE ObtenerCategoriaVendedor(Int32 idEmpresa,int idCategoria, string codCategoria)
        {        
            CategoriaVendedorE categoria = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCategoriaVendedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria;
                    oComando.Parameters.Add("@codCategoria", SqlDbType.VarChar, 150).Value = codCategoria;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            categoria = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return categoria;
        }
    }
}