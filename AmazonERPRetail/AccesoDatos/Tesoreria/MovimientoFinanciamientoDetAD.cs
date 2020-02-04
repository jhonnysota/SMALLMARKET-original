using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class MovimientoFinanciamientoDetAD : DbConection
    {

        public MovimientoFinanciamientoDetE LlenarEntidad(IDataReader oReader)
        {
            MovimientoFinanciamientoDetE movimientofinanciamientodet = new MovimientoFinanciamientoDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamientodet.idMovimiento = oReader["idMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamientodet.Tea = oReader["Tea"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Tea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamientodet.Tem = oReader["Tem"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Tem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImporteAmortizado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.ImporteAmortizado = oReader["ImporteAmortizado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImporteAmortizado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Amortizacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.Amortizacion = oReader["Amortizacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Amortizacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Interes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.Interes = oReader["Interes"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Interes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorCuota'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.ValorCuota = oReader["ValorCuota"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorCuota"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Comision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.Comision = oReader["Comision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Comision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVenc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.fecVenc = oReader["fecVenc"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecVenc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiasCuota'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.DiasCuota = oReader["DiasCuota"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["DiasCuota"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiasAcumulados'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.DiasAcumulados = oReader["DiasAcumulados"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["DiasAcumulados"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='InteresPorDa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamientodet.InteresPorDa = oReader["InteresPorDa"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["InteresPorDa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamientodet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamientodet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamientodet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamientodet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DeudaCapital'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.DeudaCapital = oReader["DeudaCapital"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["DeudaCapital"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cuotas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.Cuotas = oReader["Cuotas"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Cuotas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamientodet.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);

            return  movimientofinanciamientodet;
        }

        public MovimientoFinanciamientoDetE InsertarMovimientoFinanciamientoDet(MovimientoFinanciamientoDetE movimientofinanciamientodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovimientoFinanciamientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = movimientofinanciamientodet.idMovimiento;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = movimientofinanciamientodet.Item;
                    oComando.Parameters.Add("@Tea", SqlDbType.Decimal).Value = movimientofinanciamientodet.Tea;
					oComando.Parameters.Add("@Tem", SqlDbType.Decimal).Value = movimientofinanciamientodet.Tem;
					oComando.Parameters.Add("@ImporteAmortizado", SqlDbType.Decimal).Value = movimientofinanciamientodet.ImporteAmortizado;
                    oComando.Parameters.Add("@Amortizacion", SqlDbType.Decimal).Value = movimientofinanciamientodet.Amortizacion;
                    oComando.Parameters.Add("@Interes", SqlDbType.Decimal).Value = movimientofinanciamientodet.Interes;
                    oComando.Parameters.Add("@ValorCuota", SqlDbType.Decimal).Value = movimientofinanciamientodet.ValorCuota;
                    oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = movimientofinanciamientodet.Comision;
                    oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = movimientofinanciamientodet.Total;
                    oComando.Parameters.Add("@fecVenc", SqlDbType.SmallDateTime).Value = movimientofinanciamientodet.fecVenc;
                    oComando.Parameters.Add("@DiasCuota", SqlDbType.Int).Value = movimientofinanciamientodet.DiasCuota;
                    oComando.Parameters.Add("@DiasAcumulados", SqlDbType.Int).Value = movimientofinanciamientodet.DiasAcumulados;
                    oComando.Parameters.Add("@InteresPorDa", SqlDbType.Decimal).Value = movimientofinanciamientodet.InteresPorDa;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = movimientofinanciamientodet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientofinanciamientodet;
        }
        
        public MovimientoFinanciamientoDetE ActualizarMovimientoFinanciamientoDet(MovimientoFinanciamientoDetE movimientofinanciamientodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovimientoFinanciamientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = movimientofinanciamientodet.idMovimiento;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = movimientofinanciamientodet.Item;
                    oComando.Parameters.Add("@Tea", SqlDbType.Decimal).Value = movimientofinanciamientodet.Tea;
                    oComando.Parameters.Add("@Tem", SqlDbType.Decimal).Value = movimientofinanciamientodet.Tem;
                    oComando.Parameters.Add("@ImporteAmortizado", SqlDbType.Decimal).Value = movimientofinanciamientodet.ImporteAmortizado;
                    oComando.Parameters.Add("@Amortizacion", SqlDbType.Decimal).Value = movimientofinanciamientodet.Amortizacion;
                    oComando.Parameters.Add("@Interes", SqlDbType.Decimal).Value = movimientofinanciamientodet.Interes;
                    oComando.Parameters.Add("@ValorCuota", SqlDbType.Decimal).Value = movimientofinanciamientodet.ValorCuota;
                    oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = movimientofinanciamientodet.Comision;
                    oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = movimientofinanciamientodet.Total;
                    oComando.Parameters.Add("@fecVenc", SqlDbType.SmallDateTime).Value = movimientofinanciamientodet.fecVenc;
                    oComando.Parameters.Add("@DiasCuota", SqlDbType.Int).Value = movimientofinanciamientodet.DiasCuota;
                    oComando.Parameters.Add("@DiasAcumulados", SqlDbType.Int).Value = movimientofinanciamientodet.DiasAcumulados;
                    oComando.Parameters.Add("@InteresPorDa", SqlDbType.Decimal).Value = movimientofinanciamientodet.InteresPorDa;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movimientofinanciamientodet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientofinanciamientodet;
        }        

        public int EliminarMovimientoFinanciamientoDet(Int32 idMovimiento, Int32 Item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovimientoFinanciamientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = idMovimiento;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public int EliminarMovFinanDetPorId(Int32 idMovimiento)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovFinanDetPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = idMovimiento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MovimientoFinanciamientoDetE> ListarMovimientoFinanciamientoDet(Int32 idMovimiento)
        {
           List<MovimientoFinanciamientoDetE> listaEntidad = new List<MovimientoFinanciamientoDetE>();
           MovimientoFinanciamientoDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovimientoFinanciamientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = idMovimiento;

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
        
        public MovimientoFinanciamientoDetE ObtenerMovimientoFinanciamientoDet(Int32 idMovimiento, Int32 Item)
        {        
            MovimientoFinanciamientoDetE movimientofinanciamientodet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovimientoFinanciamientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = idMovimiento;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimientofinanciamientodet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movimientofinanciamientodet;
        }

    }
}