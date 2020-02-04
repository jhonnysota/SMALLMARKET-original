using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ProveedorCuentaAD : DbConection
    {

        public ProveedorCuentaE LlenarEntidad(IDataReader oReader)
        {
            ProveedorCuentaE proveedorcuenta = new ProveedorCuentaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.idPersonaBanco = oReader["idPersonaBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaBanco"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.tipCuenta = oReader["tipCuenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.numCuenta = oReader["numCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numInterbancaria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.numInterbancaria = oReader["numInterbancaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numInterbancaria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BancoPorDefecto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.BancoPorDefecto = oReader["BancoPorDefecto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["BancoPorDefecto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuentaPorDefecto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.CuentaPorDefecto = oReader["CuentaPorDefecto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CuentaPorDefecto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.indBaja = oReader["indBaja"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.fecBaja = oReader["fecBaja"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				proveedorcuenta.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.desTipoCuenta = oReader["desTipoCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuentaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                proveedorcuenta.CuentaBanco = oReader["CuentaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CuentaBanco"]);

            return  proveedorcuenta;        
        }

        public ProveedorCuentaE InsertarProveedorCuenta(ProveedorCuentaE proveedorcuenta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarProveedorCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = proveedorcuenta.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = proveedorcuenta.idEmpresa;
					oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = proveedorcuenta.idPersonaBanco;
					oComando.Parameters.Add("@tipCuenta", SqlDbType.Int).Value = proveedorcuenta.tipCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = proveedorcuenta.idMoneda;
					oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 15).Value = proveedorcuenta.numCuenta;
					oComando.Parameters.Add("@numInterbancaria", SqlDbType.VarChar, 15).Value = proveedorcuenta.numInterbancaria;
                    oComando.Parameters.Add("@BancoPorDefecto", SqlDbType.Bit).Value = proveedorcuenta.BancoPorDefecto;
                    oComando.Parameters.Add("@CuentaPorDefecto", SqlDbType.Char, 1).Value = proveedorcuenta.CuentaPorDefecto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = proveedorcuenta.UsuarioRegistro;

                    oConexion.Open();
                    proveedorcuenta.idItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return proveedorcuenta;
        }
        
        public ProveedorCuentaE ActualizarProveedorCuenta(ProveedorCuentaE proveedorcuenta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProveedorCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = proveedorcuenta.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = proveedorcuenta.idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = proveedorcuenta.idItem;
					oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = proveedorcuenta.idPersonaBanco;
					oComando.Parameters.Add("@tipCuenta", SqlDbType.Int).Value = proveedorcuenta.tipCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = proveedorcuenta.idMoneda;
					oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 15).Value = proveedorcuenta.numCuenta;
					oComando.Parameters.Add("@numInterbancaria", SqlDbType.VarChar, 15).Value = proveedorcuenta.numInterbancaria;
                    oComando.Parameters.Add("@BancoPorDefecto", SqlDbType.Bit).Value = proveedorcuenta.BancoPorDefecto;
                    oComando.Parameters.Add("@CuentaPorDefecto", SqlDbType.Char, 1).Value = proveedorcuenta.CuentaPorDefecto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = proveedorcuenta.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return proveedorcuenta;
        }        

        public int AnularProveedorCuenta(Int32 idPersona, Int32 idEmpresa, Int32 idItem, Boolean indBaja)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularProveedorCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = indBaja;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ProveedorCuentaE> ListarProveedorCuenta(Int32 idEmpresa, Int32 idPersona, Boolean indBaja)
        {
            List<ProveedorCuentaE> listaEntidad = new List<ProveedorCuentaE>();
            ProveedorCuentaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProveedorCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = indBaja;

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
        
        public ProveedorCuentaE ObtenerProveedorCuenta(Int32 idPersona, Int32 idEmpresa, Int32 idItem)
        {        
            ProveedorCuentaE proveedorcuenta = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProveedorCuenta", oConexion))
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
                            proveedorcuenta = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return proveedorcuenta;
        }

        public List<ProveedorCuentaE> BancosPorProv(Int32 idPersona, Int32 idEmpresa)
        {
            List<ProveedorCuentaE> listaEntidad = new List<ProveedorCuentaE>();
            ProveedorCuentaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BancosPorProv", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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

        public List<ProveedorCuentaE> TipoCuentaProv(Int32 idPersona, Int32 idEmpresa, Int32 idPersonaBanco)
        {
            List<ProveedorCuentaE> listaEntidad = new List<ProveedorCuentaE>();
            ProveedorCuentaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_TipoCuentaProv", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = idPersonaBanco;

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

        public List<ProveedorCuentaE> CuentasBancosProv(Int32 idPersona, Int32 idEmpresa, Int32 idPersonaBanco, Int32 tipCuenta)
        {
            List<ProveedorCuentaE> listaEntidad = new List<ProveedorCuentaE>();
            ProveedorCuentaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CuentasBancosProv", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = idPersonaBanco;
                    oComando.Parameters.Add("@tipCuenta", SqlDbType.Int).Value = tipCuenta;

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

        public ProveedorCuentaE ObtenerProvCtaDefecto(Int32 idPersona, Int32 idEmpresa, String idMoneda)
        {
            ProveedorCuentaE proveedorcuenta = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProvCtaDefecto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            proveedorcuenta = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return proveedorcuenta;
        }

    }
}