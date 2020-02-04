using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class LiquidacionSaldosAD : DbConection
    {

        public LiquidacionSaldosE LlenarEntidad(IDataReader oReader)
        {
            LiquidacionSaldosE liquidacionsaldos = new LiquidacionSaldosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionsaldos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionsaldos.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionsaldos.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionsaldos.codOrdenPago = oReader["codOrdenPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLiquidacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionsaldos.idLiquidacion = oReader["idLiquidacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLiquidacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoAnterior'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionsaldos.SaldoAnterior = oReader["SaldoAnterior"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoAnterior"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Abono'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionsaldos.Abono = oReader["Abono"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Abono"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Liquidacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionsaldos.Liquidacion = oReader["Liquidacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Liquidacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionsaldos.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);

            return  liquidacionsaldos;        
        }

        public LiquidacionSaldosE InsertarLiquidacionSaldos(LiquidacionSaldosE liquidacionsaldos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLiquidacionSaldos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = liquidacionsaldos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = liquidacionsaldos.idLocal;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidacionsaldos.idPersona;
					oComando.Parameters.Add("@codOrdenPago", SqlDbType.VarChar, 10).Value = liquidacionsaldos.codOrdenPago;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidacionsaldos.idLiquidacion;
                    oComando.Parameters.Add("@SaldoAnterior", SqlDbType.Decimal).Value = liquidacionsaldos.SaldoAnterior;
					oComando.Parameters.Add("@Abono", SqlDbType.Decimal).Value = liquidacionsaldos.Abono;
					oComando.Parameters.Add("@Liquidacion", SqlDbType.Decimal).Value = liquidacionsaldos.Liquidacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return liquidacionsaldos;
        }
        
        public LiquidacionSaldosE ActualizarLiquidacionSaldos(LiquidacionSaldosE liquidacionsaldos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLiquidacionSaldos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = liquidacionsaldos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = liquidacionsaldos.idLocal;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidacionsaldos.idPersona;
                    oComando.Parameters.Add("@codOrdenPago", SqlDbType.VarChar, 10).Value = liquidacionsaldos.codOrdenPago;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidacionsaldos.idLiquidacion;
                    oComando.Parameters.Add("@SaldoAnterior", SqlDbType.Decimal).Value = liquidacionsaldos.SaldoAnterior;
					oComando.Parameters.Add("@Abono", SqlDbType.Decimal).Value = liquidacionsaldos.Abono;
					oComando.Parameters.Add("@Liquidacion", SqlDbType.Decimal).Value = liquidacionsaldos.Liquidacion;
					oComando.Parameters.Add("@indEstado", SqlDbType.Char, 1).Value = liquidacionsaldos.indEstado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return liquidacionsaldos;
        }        

        public int EliminarLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String codOrdenPago)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLiquidacionSaldos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@codOrdenPago", SqlDbType.VarChar, 10).Value = codOrdenPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LiquidacionSaldosE> ListarLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal)
        {
           List<LiquidacionSaldosE> listaEntidad = new List<LiquidacionSaldosE>();
           LiquidacionSaldosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLiquidacionSaldos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

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
        
        public LiquidacionSaldosE ObtenerLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {        
            LiquidacionSaldosE liquidacionsaldos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLiquidacionSaldos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    //oComando.Parameters.Add("@codOrdenPago", SqlDbType.VarChar, 10).Value = codOrdenPago;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidacionsaldos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return liquidacionsaldos;
        }

        public LiquidacionSaldosE ObtenerLiquidacionSaldosC(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            LiquidacionSaldosE liquidacionsaldos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLiquidacionSaldosC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    //oComando.Parameters.Add("@codOrdenPago", SqlDbType.VarChar, 10).Value = codOrdenPago;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidacionsaldos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return liquidacionsaldos;
        }

        public LiquidacionSaldosE ObtenerSaldosPorIdLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, Int32 idLiquidacion)
        {
            LiquidacionSaldosE liquidacionsaldos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSaldosPorIdLiquidacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidacionsaldos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return liquidacionsaldos;
        }

    }
}