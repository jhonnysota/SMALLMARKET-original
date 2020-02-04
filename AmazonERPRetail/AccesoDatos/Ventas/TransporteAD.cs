using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class TransporteAD : DbConection
    {
        
        public TransporteE LlenarEntidad(IDataReader oReader)
        {
            TransporteE transporte = new TransporteE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTransporte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.idTransporte = oReader["idTransporte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTransporte"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.indEstado = oReader["indEstado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporte.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  transporte;        
        }

        public TransporteE InsertarTransporte(TransporteE transporte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTransporte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = transporte.RazonSocial;
					oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = transporte.Direccion;
					oComando.Parameters.Add("@Ruc", SqlDbType.VarChar, 15).Value = transporte.Ruc;
					oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = transporte.Tipo;
					oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = transporte.indEstado;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = transporte.UsuarioRegistro;

                    oConexion.Open();
                    transporte.idTransporte = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return transporte;        
        }
        
        public TransporteE ActualizarTransporte(TransporteE transporte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTransporte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = transporte.idTransporte;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = transporte.RazonSocial;
					oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = transporte.Direccion;
					oComando.Parameters.Add("@Ruc", SqlDbType.VarChar, 15).Value = transporte.Ruc;
					oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = transporte.Tipo;
					oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = transporte.indEstado;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = transporte.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return transporte;
        }        

        public Int32 AnularTransporte(Int32 idTransporte)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularTransporte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = idTransporte;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TransporteE> ListarTransporte(String RazonSocial, String Ruc, Boolean Activo, Boolean Inactivo)
        {
            List<TransporteE> listaEntidad = new List<TransporteE>();
            TransporteE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTransporte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = RazonSocial;
                    oComando.Parameters.Add("@Ruc", SqlDbType.VarChar, 15).Value = Ruc;
                    oComando.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;
                    oComando.Parameters.Add("@Inactivo", SqlDbType.Bit).Value = Inactivo;

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
        
        public TransporteE ObtenerTransporte(Int32 idTransporte)
        {        
            TransporteE transporte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTransporte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = idTransporte;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            transporte = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return transporte;        
        }

        public List<TransporteE> ListarTransporteBusqueda(String RazonSocial, String Ruc)
        {
            List<TransporteE> listaEntidad = new List<TransporteE>();
            TransporteE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTransporteBusqueda", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = RazonSocial;
                    oComando.Parameters.Add("@Ruc", SqlDbType.VarChar, 15).Value = Ruc;

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

    }
}