using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class SaldoSegunBancoAD : DbConection
    {

        public SaldoSegunBancoE LlenarEntidad(IDataReader oReader)
        {
            SaldoSegunBancoE saldosegunbanco = new SaldoSegunBancoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Saldo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.Saldo = oReader["Saldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Saldo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				saldosegunbanco.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  saldosegunbanco;        
        }

        public SaldoSegunBancoE InsertarSaldoSegunBanco(SaldoSegunBancoE saldosegunbanco)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarSaldoSegunBanco", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = saldosegunbanco.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = saldosegunbanco.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = saldosegunbanco.MesPeriodo;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = saldosegunbanco.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = saldosegunbanco.codCuenta;
					oComando.Parameters.Add("@Saldo", SqlDbType.Decimal).Value = saldosegunbanco.Saldo;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = saldosegunbanco.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return saldosegunbanco;
        }
        
        public SaldoSegunBancoE ActualizarSaldoSegunBanco(SaldoSegunBancoE saldosegunbanco)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarSaldoSegunBanco", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = saldosegunbanco.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = saldosegunbanco.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = saldosegunbanco.MesPeriodo;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = saldosegunbanco.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = saldosegunbanco.codCuenta;
					oComando.Parameters.Add("@Saldo", SqlDbType.Decimal).Value = saldosegunbanco.Saldo;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = saldosegunbanco.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return saldosegunbanco;
        }        

        public int EliminarSaldoSegunBanco(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarSaldoSegunBanco", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<SaldoSegunBancoE> ListarSaldoSegunBanco()
        {
            List<SaldoSegunBancoE> listaEntidad = new List<SaldoSegunBancoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSaldoSegunBanco", oConexion))
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
        
        public SaldoSegunBancoE ObtenerSaldoSegunBanco(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {        
            SaldoSegunBancoE saldosegunbanco = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSaldoSegunBanco", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            saldosegunbanco = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return saldosegunbanco;
        }

    }
}