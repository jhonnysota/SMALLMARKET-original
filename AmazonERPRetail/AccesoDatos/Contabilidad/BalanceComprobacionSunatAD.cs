using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class BalanceComprobacionSunatAD : DbConection
    {
        
        public BalanceComprobacionSunatE LlenarEntidad(IDataReader oReader)
        {
            BalanceComprobacionSunatE balancecomprobacionsunat = new BalanceComprobacionSunatE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaSunat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.codCuentaSunat = oReader["codCuentaSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaSunat"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoInicialDebe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.SaldoInicialDebe = oReader["SaldoInicialDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoInicialDebe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoInicialHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.SaldoInicialHaber = oReader["SaldoInicialHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoInicialHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MovimientoDebe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.MovimientoDebe = oReader["MovimientoDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MovimientoDebe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MovimientoHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.MovimientoHaber = oReader["MovimientoHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MovimientoHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SumasMayorDebe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.SumasMayorDebe = oReader["SumasMayorDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SumasMayorDebe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SumasMayorHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.SumasMayorHaber = oReader["SumasMayorHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SumasMayorHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoDebe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.SaldoDebe = oReader["SaldoDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoDebe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.SaldoHaber = oReader["SaldoHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TransCancDebe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.TransCancDebe = oReader["TransCancDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TransCancDebe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TransCancHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.TransCancHaber = oReader["TransCancHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TransCancHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BalanceActivo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.BalanceActivo = oReader["BalanceActivo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BalanceActivo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BalancePasivo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.BalancePasivo = oReader["BalancePasivo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BalancePasivo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RPNaturalezaPerdida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.RPNaturalezaPerdida = oReader["RPNaturalezaPerdida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RPNaturalezaPerdida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RPNaturalezaGanancia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.RPNaturalezaGanancia = oReader["RPNaturalezaGanancia"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RPNaturalezaGanancia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Adiciones'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.Adiciones = oReader["Adiciones"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Adiciones"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Deducciones'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.Deducciones = oReader["Deducciones"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Deducciones"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				balancecomprobacionsunat.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                balancecomprobacionsunat.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                balancecomprobacionsunat.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                balancecomprobacionsunat.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                balancecomprobacionsunat.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                balancecomprobacionsunat.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
            


            return  balancecomprobacionsunat;        
        }

        public BalanceComprobacionSunatE InsertarBalanceComprobacionSunat(BalanceComprobacionSunatE balancecomprobacionsunat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarBalanceComprobacionSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = balancecomprobacionsunat.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = balancecomprobacionsunat.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = balancecomprobacionsunat.MesPeriodo;
					oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = balancecomprobacionsunat.codCuentaSunat;
					oComando.Parameters.Add("@SaldoInicialDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.SaldoInicialDebe;
					oComando.Parameters.Add("@SaldoInicialHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.SaldoInicialHaber;
					oComando.Parameters.Add("@MovimientoDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.MovimientoDebe;
					oComando.Parameters.Add("@MovimientoHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.MovimientoHaber;
					oComando.Parameters.Add("@SumasMayorDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.SumasMayorDebe;
					oComando.Parameters.Add("@SumasMayorHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.SumasMayorHaber;
					oComando.Parameters.Add("@SaldoDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.SaldoDebe;
					oComando.Parameters.Add("@SaldoHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.SaldoHaber;
					oComando.Parameters.Add("@TransCancDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.TransCancDebe;
					oComando.Parameters.Add("@TransCancHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.TransCancHaber;
					oComando.Parameters.Add("@BalanceActivo", SqlDbType.Decimal).Value = balancecomprobacionsunat.BalanceActivo;
					oComando.Parameters.Add("@BalancePasivo", SqlDbType.Decimal).Value = balancecomprobacionsunat.BalancePasivo;
					oComando.Parameters.Add("@RPNaturalezaPerdida", SqlDbType.Decimal).Value = balancecomprobacionsunat.RPNaturalezaPerdida;
					oComando.Parameters.Add("@RPNaturalezaGanancia", SqlDbType.Decimal).Value = balancecomprobacionsunat.RPNaturalezaGanancia;
					oComando.Parameters.Add("@Adiciones", SqlDbType.Decimal).Value = balancecomprobacionsunat.Adiciones;
					oComando.Parameters.Add("@Deducciones", SqlDbType.Decimal).Value = balancecomprobacionsunat.Deducciones;
					oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = balancecomprobacionsunat.Estado;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = balancecomprobacionsunat.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return balancecomprobacionsunat;
        }
        
        public BalanceComprobacionSunatE ActualizarBalanceComprobacionSunat(BalanceComprobacionSunatE balancecomprobacionsunat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarBalanceComprobacionSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = balancecomprobacionsunat.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = balancecomprobacionsunat.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = balancecomprobacionsunat.MesPeriodo;
					oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = balancecomprobacionsunat.codCuentaSunat;
					oComando.Parameters.Add("@SaldoInicialDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.SaldoInicialDebe;
					oComando.Parameters.Add("@SaldoInicialHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.SaldoInicialHaber;
					oComando.Parameters.Add("@MovimientoDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.MovimientoDebe;
					oComando.Parameters.Add("@MovimientoHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.MovimientoHaber;
					oComando.Parameters.Add("@SumasMayorDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.SumasMayorDebe;
					oComando.Parameters.Add("@SumasMayorHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.SumasMayorHaber;
					oComando.Parameters.Add("@SaldoDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.SaldoDebe;
					oComando.Parameters.Add("@SaldoHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.SaldoHaber;
					oComando.Parameters.Add("@TransCancDebe", SqlDbType.Decimal).Value = balancecomprobacionsunat.TransCancDebe;
					oComando.Parameters.Add("@TransCancHaber", SqlDbType.Decimal).Value = balancecomprobacionsunat.TransCancHaber;
					oComando.Parameters.Add("@BalanceActivo", SqlDbType.Decimal).Value = balancecomprobacionsunat.BalanceActivo;
					oComando.Parameters.Add("@BalancePasivo", SqlDbType.Decimal).Value = balancecomprobacionsunat.BalancePasivo;
					oComando.Parameters.Add("@RPNaturalezaPerdida", SqlDbType.Decimal).Value = balancecomprobacionsunat.RPNaturalezaPerdida;
					oComando.Parameters.Add("@RPNaturalezaGanancia", SqlDbType.Decimal).Value = balancecomprobacionsunat.RPNaturalezaGanancia;
					oComando.Parameters.Add("@Adiciones", SqlDbType.Decimal).Value = balancecomprobacionsunat.Adiciones;
					oComando.Parameters.Add("@Deducciones", SqlDbType.Decimal).Value = balancecomprobacionsunat.Deducciones;
					oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = balancecomprobacionsunat.Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = balancecomprobacionsunat.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return balancecomprobacionsunat;
        }        

        public int EliminarBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuentaSunat)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarBalanceComprobacionSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = codCuentaSunat;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<BalanceComprobacionSunatE> ListarBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo)
        {
           List<BalanceComprobacionSunatE> listaEntidad = new List<BalanceComprobacionSunatE>();
           BalanceComprobacionSunatE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarBalanceComprobacionSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public BalanceComprobacionSunatE ObtenerBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuentaSunat)
        {        
            BalanceComprobacionSunatE balancecomprobacionsunat = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerBalanceComprobacionSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = codCuentaSunat;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            balancecomprobacionsunat = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return balancecomprobacionsunat;
        }
    }
}