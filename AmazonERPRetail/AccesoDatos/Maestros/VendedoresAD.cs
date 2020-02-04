using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class VendedoresAD : DbConection
    {

        public VendedoresE LlenarEntidad(IDataReader oReader)
        {
            VendedoresE vendedores = new VendedoresE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedores.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedores.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codVendedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedores.codVendedor = oReader["codVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codVendedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedores.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.fecBaja = oReader["fecBaja"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indSupervisor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.indSupervisor = oReader["indSupervisor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indSupervisor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ManejaCartera'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.ManejaCartera = oReader["ManejaCartera"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ManejaCartera"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDivision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.idDivision = oReader["idDivision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDivision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEstablecimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.idEstablecimiento = oReader["idEstablecimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idZona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.idZona = oReader["idZona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idZona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedores.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedores.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApePaterno'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.ApePaterno = oReader["ApePaterno"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApePaterno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApeMaterno'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.ApeMaterno = oReader["ApeMaterno"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApeMaterno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.Nombres = oReader["Nombres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.NroDocumento = oReader["NroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombresCom'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.NombresCom = oReader["NombresCom"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombresCom"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedores.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            return  vendedores;        
        }

        public VendedoresE InsertarVendedores(VendedoresE vendedores)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarVendedores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = vendedores.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = vendedores.idEmpresa;
					oComando.Parameters.Add("@codVendedor", SqlDbType.VarChar, 20).Value = vendedores.codVendedor;
                    oComando.Parameters.Add("@indSupervisor", SqlDbType.Bit).Value = vendedores.indSupervisor;
                    oComando.Parameters.Add("@ManejaCartera", SqlDbType.Bit).Value = vendedores.ManejaCartera;
                    oComando.Parameters.Add("@idDivision", SqlDbType.Int).Value =  vendedores.idDivision;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = vendedores.idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = vendedores.idZona;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = vendedores.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return vendedores;
        }
        
        public VendedoresE ActualizarVendedores(VendedoresE vendedores)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVendedores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = vendedores.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = vendedores.idEmpresa;
					oComando.Parameters.Add("@codVendedor", SqlDbType.VarChar, 20).Value = vendedores.codVendedor;
                    oComando.Parameters.Add("@indSupervisor", SqlDbType.Bit).Value = vendedores.indSupervisor;
                    oComando.Parameters.Add("@ManejaCartera", SqlDbType.Bit).Value = vendedores.ManejaCartera;
                    oComando.Parameters.Add("@idDivision", SqlDbType.Int).Value = vendedores.idDivision;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = vendedores.idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = vendedores.idZona;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = vendedores.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return vendedores;
        }        

        public Int32 EliminarVendedores(Int32 idPersona, Int32 idEmpresa)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarVendedores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<VendedoresE> ListarVendedores(Int32 idEmpresa, String parambusqueda, Boolean indEstado)
        {
           List<VendedoresE> listaEntidad = new List<VendedoresE>();
           VendedoresE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVendedores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@parambusqueda", SqlDbType.VarChar, 80).Value = parambusqueda;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = indEstado;

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

        public List<VendedoresE> BusquedaVendedores(Int32 idEmpresa)
        {
            List<VendedoresE> listaEntidad = new List<VendedoresE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BusquedaVendedores", oConexion))
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

        public VendedoresE RecuperarVendedorPorId(Int32 idPersona, Int32 idEmpresa)
        {
            VendedoresE vendedores = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarVendedorPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            vendedores = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return vendedores;
        }

        public VendedoresE RecuperarIDPersonaPorVendedor(Int32 idPersona, Int32 idEmpresa)
        {
            VendedoresE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarIDPersonaPorVendedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        }    
                    }
                }
            }

            return entidad;
        }

        public Int32 DarBajaVendedores(Int32 idPersona, Int32 idEmpresa, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_DarBajaVendedores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}