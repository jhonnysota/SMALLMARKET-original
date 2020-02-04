using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ProveedorContactoAD : DbConection
    {

        public ProveedorContactoE LlenarEntidad(IDataReader oReader)
        {
            ProveedorContactoE proveedorcontacto = new ProveedorContactoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.NroDocumento = oReader["NroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApePaterno'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.ApePaterno = oReader["ApePaterno"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApePaterno"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApeMaterno'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.ApeMaterno = oReader["ApeMaterno"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApeMaterno"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.Nombres = oReader["Nombres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombres"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Telefono1'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.Telefono1 = oReader["Telefono1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Telefono1"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Telefono2'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.Telefono2 = oReader["Telefono2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Telefono2"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Celular1'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.Celular1 = oReader["Celular1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Celular1"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Celular2'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.Celular2 = oReader["Celular2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Celular2"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correo1'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.Correo1 = oReader["Correo1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correo1"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correo2'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.Correo2 = oReader["Correo2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correo2"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcontacto.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  proveedorcontacto;        
        }

        public ProveedorContactoE InsertarProveedorContacto(ProveedorContactoE proveedorcontacto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarProveedorContacto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = proveedorcontacto.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = proveedorcontacto.idEmpresa;
					oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = proveedorcontacto.NroDocumento;
					oComando.Parameters.Add("@ApePaterno", SqlDbType.NVarChar, 50).Value = proveedorcontacto.ApePaterno;
					oComando.Parameters.Add("@ApeMaterno", SqlDbType.NVarChar, 50).Value = proveedorcontacto.ApeMaterno;
					oComando.Parameters.Add("@Nombres", SqlDbType.NVarChar, 50).Value = proveedorcontacto.Nombres;
					oComando.Parameters.Add("@Telefono1", SqlDbType.VarChar, 20).Value = proveedorcontacto.Telefono1;
					oComando.Parameters.Add("@Telefono2", SqlDbType.VarChar, 20).Value = proveedorcontacto.Telefono2;
					oComando.Parameters.Add("@Celular1", SqlDbType.VarChar, 10).Value = proveedorcontacto.Celular1;
					oComando.Parameters.Add("@Celular2", SqlDbType.VarChar, 10).Value = proveedorcontacto.Celular2;
					oComando.Parameters.Add("@Correo1", SqlDbType.NVarChar, 100).Value = proveedorcontacto.Correo1;
					oComando.Parameters.Add("@Correo2", SqlDbType.NVarChar, 100).Value = proveedorcontacto.Correo2;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = proveedorcontacto.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = proveedorcontacto.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = proveedorcontacto.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = proveedorcontacto.FechaModificacion;

                    oConexion.Open();
                    proveedorcontacto.idItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return proveedorcontacto;
        }
        
        public ProveedorContactoE ActualizarProveedorContacto(ProveedorContactoE proveedorcontacto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProveedorContacto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = proveedorcontacto.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = proveedorcontacto.idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = proveedorcontacto.idItem;
					oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = proveedorcontacto.NroDocumento;
					oComando.Parameters.Add("@ApePaterno", SqlDbType.NVarChar, 50).Value = proveedorcontacto.ApePaterno;
					oComando.Parameters.Add("@ApeMaterno", SqlDbType.NVarChar, 50).Value = proveedorcontacto.ApeMaterno;
					oComando.Parameters.Add("@Nombres", SqlDbType.NVarChar, 50).Value = proveedorcontacto.Nombres;
					oComando.Parameters.Add("@Telefono1", SqlDbType.VarChar, 20).Value = proveedorcontacto.Telefono1;
					oComando.Parameters.Add("@Telefono2", SqlDbType.VarChar, 20).Value = proveedorcontacto.Telefono2;
					oComando.Parameters.Add("@Celular1", SqlDbType.VarChar, 10).Value = proveedorcontacto.Celular1;
					oComando.Parameters.Add("@Celular2", SqlDbType.VarChar, 10).Value = proveedorcontacto.Celular2;
					oComando.Parameters.Add("@Correo1", SqlDbType.NVarChar, 100).Value = proveedorcontacto.Correo1;
					oComando.Parameters.Add("@Correo2", SqlDbType.NVarChar, 100).Value = proveedorcontacto.Correo2;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = proveedorcontacto.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = proveedorcontacto.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = proveedorcontacto.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = proveedorcontacto.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return proveedorcontacto;
        }        

        public int EliminarProveedorContacto(Int32 idPersona, Int32 idEmpresa, Int32 idItem)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarProveedorContacto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ProveedorContactoE> ListarProveedorContacto(Int32 idEmpresa,Int32 idPersona)
        {
           List<ProveedorContactoE> listaEntidad = new List<ProveedorContactoE>();
           ProveedorContactoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProveedorContacto", oConexion))
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
        
        public ProveedorContactoE ObtenerProveedorContacto(Int32 idPersona, Int32 idEmpresa, Int32 idItem)
        {        
            ProveedorContactoE proveedorcontacto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProveedorContacto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            proveedorcontacto = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return proveedorcontacto;
        }

    }
}