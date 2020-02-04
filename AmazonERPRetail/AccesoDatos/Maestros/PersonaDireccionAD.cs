using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PersonaDireccionAD : DbConection
    {

        public PersonaDireccionE LlenarEntidad(IDataReader oReader)
        {
            PersonaDireccionE personadireccion = new PersonaDireccionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.IdPersona = oReader["IdPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdDireccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.IdDireccion = oReader["IdDireccion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdDireccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DescripcionSucursal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.DescripcionSucursal = oReader["DescripcionSucursal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DescripcionSucursal"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodUbigeo'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.CodUbigeo = oReader["CodUbigeo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodUbigeo"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDireccion'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.TipoDireccion = oReader["TipoDireccion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoDireccion"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoVia'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.TipoVia = oReader["TipoVia"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoVia"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreVia'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.NombreVia = oReader["NombreVia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreVia"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoZona'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.TipoZona = oReader["TipoZona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoZona"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreZona'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.NombreZona = oReader["NombreZona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreZona"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroVia'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.NroVia = oReader["NroVia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroVia"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Manzana'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.Manzana = oReader["Manzana"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Manzana"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Interior'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.Interior = oReader["Interior"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Interior"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Referencia'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.Referencia = oReader["Referencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Referencia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionCompleta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.DireccionCompleta = oReader["DireccionCompleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionCompleta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.Estado = oReader["Estado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Estado"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Telefono'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.Telefono = oReader["Telefono"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Telefono"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdAgenciaTransportista'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.IdAgenciaTransportista = oReader["IdAgenciaTransportista"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdAgenciaTransportista"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contacto'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.Contacto = oReader["Contacto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Contacto"]);
			
            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cargo'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    personadireccion.Cargo = oReader["Cargo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Cargo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				personadireccion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  personadireccion;        
        }

        public PersonaDireccionE InsertarPersonaDireccion(PersonaDireccionE personadireccion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPersonaDireccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = personadireccion.IdPersona;
                    oComando.Parameters.Add("@DescripcionSucursal", SqlDbType.NVarChar, 100).Value = personadireccion.DescripcionSucursal;
					oComando.Parameters.Add("@DireccionCompleta", SqlDbType.NVarChar, 250).Value = personadireccion.DireccionCompleta;
					oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = personadireccion.Estado;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = personadireccion.UsuarioRegistro;

                    oConexion.Open();
                    personadireccion.IdDireccion = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return personadireccion;
        }
        
        public PersonaDireccionE ActualizarPersonaDireccion(PersonaDireccionE personadireccion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPersonaDireccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = personadireccion.IdPersona;
					oComando.Parameters.Add("@IdDireccion", SqlDbType.Int).Value = personadireccion.IdDireccion;
					oComando.Parameters.Add("@DescripcionSucursal", SqlDbType.NVarChar, 100).Value = personadireccion.DescripcionSucursal;
					oComando.Parameters.Add("@DireccionCompleta", SqlDbType.NVarChar, 250).Value = personadireccion.DireccionCompleta;
					oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = personadireccion.Estado;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = personadireccion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return personadireccion;
        }        

        public int EliminarPersonaDireccion(Int32 IdPersona, Int32 IdDireccion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPersonaDireccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = IdPersona;
					oComando.Parameters.Add("@IdDireccion", SqlDbType.Int).Value = IdDireccion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PersonaDireccionE> ListarPersonaDireccion(Int32 IdPersona)
        {
           List<PersonaDireccionE> listaEntidad = new List<PersonaDireccionE>();
           PersonaDireccionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPersonaDireccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = IdPersona;

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
        
        public PersonaDireccionE ObtenerPersonaDireccion(Int32 IdPersona, Int32 IdDireccion)
        {        
            PersonaDireccionE personadireccion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPersonaDireccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = IdPersona;
					oComando.Parameters.Add("@IdDireccion", SqlDbType.Int).Value = IdDireccion;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            personadireccion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return personadireccion;
        }
    }
}