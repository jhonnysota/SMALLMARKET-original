using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class ContactosCorreosAD : DbConection
    {

        public ContactosCorreosE LlenarEntidad(IDataReader oReader)
        {
            ContactosCorreosE contactoscorreos = new ContactosCorreosE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idGrupo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                contactoscorreos.idGrupo = oReader["idGrupo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idGrupo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCorreo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreos.idCorreo = oReader["idCorreo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCorreo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreos.Correo = oReader["Correo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreos.Nombres = oReader["Nombres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CorreoDefecto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                contactoscorreos.CorreoDefecto = oReader["CorreoDefecto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["CorreoDefecto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                contactoscorreos.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            return  contactoscorreos;        
        }

        public ContactosCorreosE InsertarContactosCorreos(ContactosCorreosE contactoscorreos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarContactosCorreos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = contactoscorreos.idGrupo;
                    oComando.Parameters.Add("@idCorreo", SqlDbType.Int).Value = contactoscorreos.idCorreo;
                    oComando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = contactoscorreos.Correo;
					oComando.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = contactoscorreos.Nombres;
                    oComando.Parameters.Add("@CorreoDefecto", SqlDbType.Bit).Value = contactoscorreos.CorreoDefecto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = contactoscorreos.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return contactoscorreos;
        }
        
        public ContactosCorreosE ActualizarContactosCorreos(ContactosCorreosE contactoscorreos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarContactosCorreos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = contactoscorreos.idGrupo;
                    oComando.Parameters.Add("@idCorreo", SqlDbType.Int).Value = contactoscorreos.idCorreo;
                    oComando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = contactoscorreos.Correo;
					oComando.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = contactoscorreos.Nombres;
                    oComando.Parameters.Add("@CorreoDefecto", SqlDbType.Bit).Value = contactoscorreos.CorreoDefecto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = contactoscorreos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return contactoscorreos;
        }        

        public int EliminarContactosCorreos(Int32 idGrupo, Int32 idCorreo)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarContactosCorreos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;
                    oComando.Parameters.Add("@idCorreo", SqlDbType.Int).Value = idCorreo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ContactosCorreosE> ListarContactosCorreos()
        {
            List<ContactosCorreosE> listaEntidad = new List<ContactosCorreosE>();
            ContactosCorreosE entidad = null;
            int Corre = 1;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarContactosCorreos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            entidad.Correlativo = Corre;
                            listaEntidad.Add(entidad);
                            Corre++;
                        }
                    }
                }
            }

            return listaEntidad;
        }
        
        public ContactosCorreosE ObtenerContactosCorreos(Int32 idCorreo)
        {        
            ContactosCorreosE contactoscorreos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerContactosCorreos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCorreo", SqlDbType.Int).Value = idCorreo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            contactoscorreos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return contactoscorreos;
        }

        public List<ContactosCorreosE> ListarCorreosPorDefecto(Int32 idUsuario)
        {
            List<ContactosCorreosE> listaEntidad = new List<ContactosCorreosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCorreosPorDefecto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

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

        public List<ContactosCorreosE> ListarContactosCorreosPorGrupo(Int32 idGrupo)
        {
            List<ContactosCorreosE> listaEntidad = new List<ContactosCorreosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarContactosCorreosPorGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;

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

        public int MaximoGrupo(Int32 idGrupo)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaximoGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;

                    oConexion.Open();
                    resp = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return resp;
        }

    }
}