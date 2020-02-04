using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class MovimientoFinanciamientoAD : DbConection
    {
        
        public MovimientoFinanciamientoE LlenarEntidad(IDataReader oReader)
        {
            MovimientoFinanciamientoE movimientofinanciamiento = new MovimientoFinanciamientoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.idMovimiento = oReader["idMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMovimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.codMovimiento = oReader["codMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codMovimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idFinanciamiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.idFinanciamiento = oReader["idFinanciamiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idFinanciamiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLinea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.idLinea = oReader["idLinea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLinea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecVencimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.nroCuenta = oReader["nroCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impSolicitado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.impSolicitado = oReader["impSolicitado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impSolicitado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.nroDocumento = oReader["nroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ComisionDesem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.ComisionDesem = oReader["ComisionDesem"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ComisionDesem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ComisionVar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamiento.ComisionVar = oReader["ComisionVar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ComisionVar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Periodicidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamiento.Periodicidad = oReader["Periodicidad"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Periodicidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Portes'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.Portes = oReader["Portes"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Portes"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='segDesgravamen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.segDesgravamen = oReader["segDesgravamen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["segDesgravamen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porTea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.porTea = oReader["porTea"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porTea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Plazo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.Plazo = oReader["Plazo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Plazo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroCuotas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.nroCuotas = oReader["nroCuotas"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroCuotas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDesembolso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.impDesembolso = oReader["impDesembolso"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDesembolso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuotaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.CuotaPago = oReader["CuotaPago"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CuotaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoCredito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamiento.MontoCredito = oReader["MontoCredito"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoCredito"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movimientofinanciamiento.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamiento.desLinea = oReader["desLinea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLinea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamiento.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamiento.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamiento.desCtaBanco = oReader["desCtaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientofinanciamiento.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);

            return  movimientofinanciamiento;
        }

        public MovimientoFinanciamientoE InsertarMovimientoFinanciamiento(MovimientoFinanciamientoE movimientofinanciamiento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovimientoFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codMovimiento", SqlDbType.VarChar, 10).Value = movimientofinanciamiento.codMovimiento;
					oComando.Parameters.Add("@idFinanciamiento", SqlDbType.Int).Value = movimientofinanciamiento.idFinanciamiento;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movimientofinanciamiento.idEmpresa;
					oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = movimientofinanciamiento.idLinea;
					oComando.Parameters.Add("@fecEmision", SqlDbType.SmallDateTime).Value = movimientofinanciamiento.fecEmision;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = movimientofinanciamiento.fecVencimiento;
					oComando.Parameters.Add("@nroCuenta", SqlDbType.VarChar, 20).Value = movimientofinanciamiento.nroCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = movimientofinanciamiento.idMoneda;
					oComando.Parameters.Add("@impSolicitado", SqlDbType.Decimal).Value = movimientofinanciamiento.impSolicitado;
					oComando.Parameters.Add("@nroDocumento", SqlDbType.VarChar, 20).Value = movimientofinanciamiento.nroDocumento;
					oComando.Parameters.Add("@ComisionDesem", SqlDbType.Decimal).Value = movimientofinanciamiento.ComisionDesem;
                    oComando.Parameters.Add("@ComisionVar", SqlDbType.Decimal).Value = movimientofinanciamiento.ComisionVar;
                    oComando.Parameters.Add("@Periodicidad", SqlDbType.Int).Value = movimientofinanciamiento.Periodicidad;
                    oComando.Parameters.Add("@Portes", SqlDbType.Decimal).Value = movimientofinanciamiento.Portes;
					oComando.Parameters.Add("@segDesgravamen", SqlDbType.Decimal).Value = movimientofinanciamiento.segDesgravamen;
					oComando.Parameters.Add("@porTea", SqlDbType.Decimal).Value = movimientofinanciamiento.porTea;
					oComando.Parameters.Add("@Plazo", SqlDbType.Int).Value = movimientofinanciamiento.Plazo;
					oComando.Parameters.Add("@nroCuotas", SqlDbType.Int).Value = movimientofinanciamiento.nroCuotas;
					oComando.Parameters.Add("@impDesembolso", SqlDbType.Decimal).Value = movimientofinanciamiento.impDesembolso;
					oComando.Parameters.Add("@CuotaPago", SqlDbType.Decimal).Value = movimientofinanciamiento.CuotaPago;
                    oComando.Parameters.Add("@MontoCredito", SqlDbType.Decimal).Value = movimientofinanciamiento.MontoCredito;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = movimientofinanciamiento.UsuarioRegistro;

                    oConexion.Open();
                    movimientofinanciamiento.idMovimiento = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return movimientofinanciamiento;
        }
        
        public MovimientoFinanciamientoE ActualizarMovimientoFinanciamiento(MovimientoFinanciamientoE movimientofinanciamiento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovimientoFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = movimientofinanciamiento.idMovimiento;
					oComando.Parameters.Add("@codMovimiento", SqlDbType.VarChar, 10).Value = movimientofinanciamiento.codMovimiento;
					oComando.Parameters.Add("@idFinanciamiento", SqlDbType.Int).Value = movimientofinanciamiento.idFinanciamiento;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movimientofinanciamiento.idEmpresa;
					oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = movimientofinanciamiento.idLinea;
					oComando.Parameters.Add("@fecEmision", SqlDbType.SmallDateTime).Value = movimientofinanciamiento.fecEmision;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = movimientofinanciamiento.fecVencimiento;
					oComando.Parameters.Add("@nroCuenta", SqlDbType.VarChar, 20).Value = movimientofinanciamiento.nroCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = movimientofinanciamiento.idMoneda;
					oComando.Parameters.Add("@impSolicitado", SqlDbType.Decimal).Value = movimientofinanciamiento.impSolicitado;
					oComando.Parameters.Add("@nroDocumento", SqlDbType.VarChar, 20).Value = movimientofinanciamiento.nroDocumento;
                    oComando.Parameters.Add("@ComisionDesem", SqlDbType.Decimal).Value = movimientofinanciamiento.ComisionDesem;
                    oComando.Parameters.Add("@ComisionVar", SqlDbType.Decimal).Value = movimientofinanciamiento.ComisionVar;
                    oComando.Parameters.Add("@Periodicidad", SqlDbType.Int).Value = movimientofinanciamiento.Periodicidad;
                    oComando.Parameters.Add("@Portes", SqlDbType.Decimal).Value = movimientofinanciamiento.Portes;
					oComando.Parameters.Add("@segDesgravamen", SqlDbType.Decimal).Value = movimientofinanciamiento.segDesgravamen;
					oComando.Parameters.Add("@porTea", SqlDbType.Decimal).Value = movimientofinanciamiento.porTea;
					oComando.Parameters.Add("@Plazo", SqlDbType.Int).Value = movimientofinanciamiento.Plazo;
					oComando.Parameters.Add("@nroCuotas", SqlDbType.Int).Value = movimientofinanciamiento.nroCuotas;
					oComando.Parameters.Add("@impDesembolso", SqlDbType.Decimal).Value = movimientofinanciamiento.impDesembolso;
					oComando.Parameters.Add("@CuotaPago", SqlDbType.Decimal).Value = movimientofinanciamiento.CuotaPago;
                    oComando.Parameters.Add("@MontoCredito", SqlDbType.Decimal).Value = movimientofinanciamiento.MontoCredito;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movimientofinanciamiento.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientofinanciamiento;
        }        

        public int EliminarMovimientoFinanciamiento(Int32 idMovimiento)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovimientoFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = idMovimiento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MovimientoFinanciamientoE> ListarMovimientoFinanciamiento(Int32 idEmpresa, Int32 idLinea, Int32 idBanco, DateTime fecIni, DateTime fecFin)
        {
           List<MovimientoFinanciamientoE> listaEntidad = new List<MovimientoFinanciamientoE>();
           MovimientoFinanciamientoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovimientoFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = idLinea;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = idBanco;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;

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
        
        public MovimientoFinanciamientoE ObtenerMovimientoFinanciamiento(Int32 idMovimiento)
        {        
            MovimientoFinanciamientoE movimientofinanciamiento = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovimientoFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovimiento", SqlDbType.Int).Value = idMovimiento;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimientofinanciamiento = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movimientofinanciamiento;
        }

        public String GenerarNumMovFinanciamiento(Int32 idEmpresa)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumMovFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = oReader["codMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codMovimiento"]); //Convert.ToString(oReader["codMovimiento"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public List<MovimientoFinanciamientoE> ListarMovFinCuentasBan(Int32 idPersona, Int32 idEmpresa, String idMoneda)
        {
            List<MovimientoFinanciamientoE> listaEntidad = new List<MovimientoFinanciamientoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovFinCuentasBan", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar).Value = idMoneda;

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

    }
}