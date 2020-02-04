using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ClienteAvalAD : DbConection
    {

        public ClienteAvalE LlenarEntidad(IDataReader oReader)
        {
            ClienteAvalE clienteaval = new ClienteAvalE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAval'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.idAval = oReader["idAval"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAval"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.TipoDocumento = oReader["TipoDocumento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.nroDocumento = oReader["nroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Telefonos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.Telefonos = oReader["Telefonos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Telefonos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Email'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.Email = oReader["Email"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Email"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsPrincipal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                clienteaval.EsPrincipal = oReader["EsPrincipal"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsPrincipal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clienteaval.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  clienteaval;        
        }

        public ClienteAvalE InsertarClienteAval(ClienteAvalE clienteaval)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarClienteAval", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = clienteaval.idEmpresa;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = clienteaval.idPersona;
					oComando.Parameters.Add("@idAval", SqlDbType.Int).Value = clienteaval.idAval;
					oComando.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = clienteaval.TipoDocumento;
					oComando.Parameters.Add("@nroDocumento", SqlDbType.VarChar, 20).Value = clienteaval.nroDocumento;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = clienteaval.RazonSocial;
					oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = clienteaval.Direccion;
					oComando.Parameters.Add("@Telefonos", SqlDbType.VarChar, 100).Value = clienteaval.Telefonos;
					oComando.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = clienteaval.Email;
                    oComando.Parameters.Add("@EsPrincipal", SqlDbType.Bit).Value = clienteaval.EsPrincipal;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = clienteaval.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return clienteaval;
        }
        
        public ClienteAvalE ActualizarClienteAval(ClienteAvalE clienteaval)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarClienteAval", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = clienteaval.idEmpresa;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = clienteaval.idPersona;
					oComando.Parameters.Add("@idAval", SqlDbType.Int).Value = clienteaval.idAval;
					oComando.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = clienteaval.TipoDocumento;
					oComando.Parameters.Add("@nroDocumento", SqlDbType.VarChar, 20).Value = clienteaval.nroDocumento;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = clienteaval.RazonSocial;
					oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = clienteaval.Direccion;
					oComando.Parameters.Add("@Telefonos", SqlDbType.VarChar, 100).Value = clienteaval.Telefonos;
					oComando.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = clienteaval.Email;
                    oComando.Parameters.Add("@EsPrincipal", SqlDbType.Bit).Value = clienteaval.EsPrincipal;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = clienteaval.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return clienteaval;
        }        

        public int EliminarClienteAval(Int32 idEmpresa, Int32 idPersona)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarClienteAval", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ClienteAvalE> ListarClienteAval(Int32 idEmpresa, Int32 idPersona)
        {
            List<ClienteAvalE> listaEntidad = new List<ClienteAvalE>();
            ClienteAvalE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarClienteAval", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

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
        
        public ClienteAvalE ObtenerClienteAval(Int32 idEmpresa, Int32 idPersona, Int32 idAval)
        {        
            ClienteAvalE clienteaval = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerClienteAval", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idAval", SqlDbType.Int).Value = idAval;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            clienteaval = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return clienteaval;
        }

    }
}