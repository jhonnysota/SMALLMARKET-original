using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class ContactosCorreosGrupoAD : DbConection
    {

        public ContactosCorreosGrupoE LlenarEntidad(IDataReader oReader)
        {
            ContactosCorreosGrupoE contactoscorreosgrupo = new ContactosCorreosGrupoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idGrupo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreosgrupo.idGrupo = oReader["idGrupo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idGrupo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreosgrupo.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUsuario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreosgrupo.idUsuario = oReader["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUsuario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GrupoDefecto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreosgrupo.GrupoDefecto = oReader["GrupoDefecto"] == DBNull.Value ? true : Convert.ToBoolean(oReader["GrupoDefecto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreosgrupo.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreosgrupo.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreosgrupo.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				contactoscorreosgrupo.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                contactoscorreosgrupo.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            return  contactoscorreosgrupo;        
        }

        public ContactosCorreosGrupoE InsertarContactosCorreosGrupo(ContactosCorreosGrupoE contactoscorreosgrupo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarContactosCorreosGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = contactoscorreosgrupo.Descripcion;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = contactoscorreosgrupo.idUsuario;
					oComando.Parameters.Add("@GrupoDefecto", SqlDbType.Bit).Value = contactoscorreosgrupo.GrupoDefecto;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = contactoscorreosgrupo.UsuarioRegistro;

                    oConexion.Open();
                    contactoscorreosgrupo.idGrupo = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return contactoscorreosgrupo;
        }
        
        public ContactosCorreosGrupoE ActualizarContactosCorreosGrupo(ContactosCorreosGrupoE contactoscorreosgrupo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarContactosCorreosGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = contactoscorreosgrupo.idGrupo;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = contactoscorreosgrupo.Descripcion;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = contactoscorreosgrupo.idUsuario;
					oComando.Parameters.Add("@GrupoDefecto", SqlDbType.Bit).Value = contactoscorreosgrupo.GrupoDefecto;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = contactoscorreosgrupo.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return contactoscorreosgrupo;
        }        

        public Int32 EliminarContactosCorreosGrupo(Int32 idGrupo)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarContactosCorreosGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ContactosCorreosGrupoE> ListarContactosCorreosGrupo(Int32 idUsuario)
        {
            List<ContactosCorreosGrupoE> listaEntidad = new List<ContactosCorreosGrupoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarContactosCorreosGrupo", oConexion))
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
        
        public ContactosCorreosGrupoE ObtenerContactosCorreosGrupo(Int32 idGrupo)
        {        
            ContactosCorreosGrupoE contactoscorreosgrupo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerContactosCorreosGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            contactoscorreosgrupo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return contactoscorreosgrupo;
        }

        public Int32 RevisarCorreosGrupoPorDefecto(Int32 idGrupo, Int32 idUsuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RevisarCorreosGrupoPorDefecto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    oConexion.Open();
                    resp = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return resp;
        }

    }
}