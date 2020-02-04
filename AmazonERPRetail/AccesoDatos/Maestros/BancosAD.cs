using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class BancosAD : DbConection
    {

        public BancosE LlenarEntidad(IDataReader oReader)
        {
            BancosE bancos = new BancosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SiglaComercial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.SiglaComercial = oReader["SiglaComercial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SiglaComercial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.codSunat = oReader["codSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancos.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancos.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);   
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.indBaja = oReader["indBaja"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.fecBaja = oReader["fecBaja"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  bancos;        
        }

        public BancosE InsertarBancos(BancosE bancos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = bancos.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = bancos.idEmpresa;
					oComando.Parameters.Add("@SiglaComercial", SqlDbType.VarChar, 100).Value = bancos.SiglaComercial;
					oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 2).Value = bancos.codSunat;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = bancos.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return bancos;
        }
        
        public BancosE ActualizarBancos(BancosE bancos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = bancos.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = bancos.idEmpresa;
					oComando.Parameters.Add("@SiglaComercial", SqlDbType.VarChar, 100).Value = bancos.SiglaComercial;
					oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 2).Value = bancos.codSunat;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = bancos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return bancos;
        }        

        public int EliminarBancos(Int32 idPersona, Int32 idEmpresa)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarBancos", oConexion))
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

        public List<BancosE> ListarBancos(Int32 idEmpresa)
        {
           List<BancosE> listaEntidad = new List<BancosE>();
           BancosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public BancosE ObtenerBancos(Int32 idPersona, Int32 idEmpresa)
        {        
            BancosE bancos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            bancos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return bancos;
        }

        public BancosE RecuperarBancoPorRUC(Int32 idEmpresa, String ruc)
        {
            BancosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarBancoPorRUC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@RUC", SqlDbType.NVarChar, 25).Value = ruc;

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

    }
}