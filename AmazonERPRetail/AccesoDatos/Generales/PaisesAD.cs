using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class PaisesAD : DbConection
    {

        public PaisesE LlenarEntidad(IDataReader oReader)
        {
            PaisesE paises = new PaisesE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPais'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				paises.idPais = oReader["idPais"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPais"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				paises.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodigoSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                paises.CodigoSunat = oReader["CodigoSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodigoSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodIso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                paises.CodIso = oReader["CodIso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodIso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				paises.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				paises.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				paises.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				paises.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Gentilicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                paises.Gentilicio = oReader["Gentilicio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Gentilicio"]);


            return  paises;        
        }

        public PaisesE InsertarPaises(PaisesE paises)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPaises", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = paises.Nombre;
                    oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 5).Value = paises.CodigoSunat;
                    oComando.Parameters.Add("@CodIso", SqlDbType.VarChar, 2).Value = paises.CodIso;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = paises.UsuarioRegistro;
                    oComando.Parameters.Add("@Gentilicio", SqlDbType.VarChar, 100).Value = paises.Gentilicio;

                    oConexion.Open();
                    paises.idPais = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return paises;
        }
        
        public PaisesE ActualizarPaises(PaisesE paises)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPaises", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPais", SqlDbType.Int).Value = paises.idPais;
					oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = paises.Nombre;
                    oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 5).Value = paises.CodigoSunat;
                    oComando.Parameters.Add("@CodIso", SqlDbType.VarChar, 2).Value = paises.CodIso;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = paises.UsuarioModificacion;
                    oComando.Parameters.Add("@Gentilicio", SqlDbType.VarChar, 100).Value = paises.Gentilicio;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return paises;
        }        

        public List<PaisesE> ListarPaises()
        {
            List<PaisesE> listaEntidad = new List<PaisesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPaises", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

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

        public List<PaisesE> ListarPaisesPuerto()
        {
            List<PaisesE> listaEntidad = new List<PaisesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPaisesPuerto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

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
        
        public PaisesE ObtenerPaises(Int32 idPais)
        {        
            PaisesE paises = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPaises", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPais", SqlDbType.Int).Value = idPais;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            paises = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return paises;
        }

        public PaisesE ObtenerPaisesPorNombre(String Nombre)
        {
            PaisesE paises = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPaisesPorNombre", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = Nombre;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            paises = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return paises;
        }

    }
}