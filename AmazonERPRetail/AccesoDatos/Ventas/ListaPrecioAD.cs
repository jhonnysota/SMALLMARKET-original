using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class ListaPrecioAD : DbConection
    {

        public ListaPrecioE LlenarEntidad(IDataReader oReader)
        {
            ListaPrecioE listaprecio = new ListaPrecioE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idListaPrecio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.idListaPrecio = oReader["idListaPrecio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idListaPrecio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecio.NombreCorto = oReader["NombreCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ParaTicket'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecio.ParaTicket = oReader["ParaTicket"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ParaTicket"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Principal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecio.Principal = oReader["Principal"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Principal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.indBaja = oReader["indBaja"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecio.FechaBaja = oReader["FechaBaja"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroLista'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecio.NroLista = oReader["NroLista"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["NroLista"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecio.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecio.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            return  listaprecio;        
        }

        public ListaPrecioE InsertarListaPrecio(ListaPrecioE listaprecio)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarListaPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = listaprecio.idEmpresa;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = listaprecio.idMoneda;
					oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 150).Value = listaprecio.Nombre;
                    oComando.Parameters.Add("@NombreCorto", SqlDbType.VarChar, 10).Value = listaprecio.NombreCorto;
                    oComando.Parameters.Add("@NroLista", SqlDbType.Int).Value = listaprecio.NroLista;
                    oComando.Parameters.Add("@ParaTicket", SqlDbType.Bit).Value = listaprecio.ParaTicket;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = listaprecio.indBaja;
                    oComando.Parameters.Add("@Principal", SqlDbType.Bit).Value = listaprecio.Principal;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = listaprecio.UsuarioRegistro;

                    oConexion.Open();
                    listaprecio.idListaPrecio = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return listaprecio;
        }
        
        public ListaPrecioE ActualizarListaPrecio(ListaPrecioE listaprecio)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarListaPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = listaprecio.idEmpresa;
					oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = listaprecio.idListaPrecio;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = listaprecio.idMoneda;
					oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 150).Value = listaprecio.Nombre;
                    oComando.Parameters.Add("@NombreCorto", SqlDbType.VarChar, 10).Value = listaprecio.NombreCorto;
                    oComando.Parameters.Add("@NroLista", SqlDbType.Int).Value = listaprecio.NroLista;
                    oComando.Parameters.Add("@ParaTicket", SqlDbType.Bit).Value = listaprecio.ParaTicket;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = listaprecio.indBaja;
                    oComando.Parameters.Add("@Principal", SqlDbType.Bit).Value = listaprecio.Principal;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = listaprecio.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return listaprecio;
        }        

        public Int32 EliminarListaPrecio(Int32 idEmpresa, Int32 idListaPrecio)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarListaPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ListaPrecioE> ListarListaPrecio(Int32 idEmpresa)
        {
            List<ListaPrecioE> listaEntidad = new List<ListaPrecioE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarListaPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public ListaPrecioE ObtenerListaPrecio(Int32 idEmpresa, Int32 idListaPrecio)
        {        
            ListaPrecioE listaprecio = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerListaPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaprecio = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return listaprecio;
        }

        public List<ListaPrecioE> ListarPrecioPorTipo(Int32 idEmpresa, Boolean ParaTicket)
        {
            List<ListaPrecioE> listaEntidad = new List<ListaPrecioE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPrecioPorTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@ParaTicket", SqlDbType.Bit).Value = ParaTicket;

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

    }
}