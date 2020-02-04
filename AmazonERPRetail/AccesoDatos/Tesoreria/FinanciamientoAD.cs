using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class FinanciamientoAD : DbConection
    {

        public FinanciamientoE LlenarEntidad(IDataReader oReader)
        {
            FinanciamientoE financiamiento = new FinanciamientoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idFinanciamiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.idFinanciamiento = oReader["idFinanciamiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idFinanciamiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFinanciamiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                financiamiento.codFinanciamiento = oReader["codFinanciamiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFinanciamiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                financiamiento.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLinea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.idLinea = oReader["idLinea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLinea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.Importe = oReader["Importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Garantia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.Garantia = oReader["Garantia"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Garantia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.Tea = oReader["Tea"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Tea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Plazo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.Plazo = oReader["Plazo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Plazo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.fecBaja = oReader["fecBaja"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				financiamiento.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extension
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                financiamiento.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                financiamiento.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                financiamiento.desLinea = oReader["desLinea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLinea"]);

            return  financiamiento;        
        }

        public FinanciamientoE InsertarFinanciamiento(FinanciamientoE financiamiento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codFinanciamiento", SqlDbType.VarChar, 10).Value = financiamiento.codFinanciamiento;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = financiamiento.idEmpresa;
					oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = financiamiento.idBanco;
					oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = financiamiento.idLinea;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = financiamiento.Fecha.Date;
					oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = financiamiento.Importe;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = financiamiento.idMoneda;
					oComando.Parameters.Add("@Garantia", SqlDbType.Decimal).Value = financiamiento.Garantia;
					oComando.Parameters.Add("@Tea", SqlDbType.Decimal).Value = financiamiento.Tea;
					oComando.Parameters.Add("@Plazo", SqlDbType.Int).Value = financiamiento.Plazo;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = financiamiento.UsuarioRegistro;

                    oConexion.Open();
                    financiamiento.idFinanciamiento = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return financiamiento;
        }
        
        public FinanciamientoE ActualizarFinanciamiento(FinanciamientoE financiamiento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idFinanciamiento", SqlDbType.Int).Value = financiamiento.idFinanciamiento;
                    oComando.Parameters.Add("@codFinanciamiento", SqlDbType.VarChar, 10).Value = financiamiento.codFinanciamiento;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = financiamiento.idEmpresa;
					oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = financiamiento.idBanco;
					oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = financiamiento.idLinea;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = financiamiento.Fecha.Date;
                    oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = financiamiento.Importe;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = financiamiento.idMoneda;
					oComando.Parameters.Add("@Garantia", SqlDbType.Decimal).Value = financiamiento.Garantia;
					oComando.Parameters.Add("@Tea", SqlDbType.Decimal).Value = financiamiento.Tea;
					oComando.Parameters.Add("@Plazo", SqlDbType.Int).Value = financiamiento.Plazo;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = financiamiento.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return financiamiento;
        }        

        public int AnularFinanciamiento(Int32 idFinanciamiento)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idFinanciamiento", SqlDbType.Int).Value = idFinanciamiento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<FinanciamientoE> ListarFinanciamiento(Int32 idEmpresa, Int32 idBanco, Int32 idLinea, Boolean indEstado)
        {
           List<FinanciamientoE> listaEntidad = new List<FinanciamientoE>();
           FinanciamientoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = idBanco;
                    oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = idLinea;
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
        
        public FinanciamientoE ObtenerFinanciamiento(Int32 idFinanciamiento)
        {        
            FinanciamientoE financiamiento = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerFinanciamiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idFinanciamiento", SqlDbType.Int).Value = idFinanciamiento;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            financiamiento = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return financiamiento;
        }

        public List<FinanciamientoE> ListarBancosFinanciamiento(Int32 idEmpresa)
        {
            List<FinanciamientoE> listaEntidad = new List<FinanciamientoE>();
            FinanciamientoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarBancosFinanciamiento", oConexion))
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

        public List<FinanciamientoE> ListarBancosFinanPorLinea(Int32 idEmpresa, Int32 idLinea)
        {
            List<FinanciamientoE> listaEntidad = new List<FinanciamientoE>();
            FinanciamientoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarBancosFinanPorLinea", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = idLinea;

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

    }
}