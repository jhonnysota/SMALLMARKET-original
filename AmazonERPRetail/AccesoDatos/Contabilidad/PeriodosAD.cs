using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PeriodosAD : DbConection
    {

        public PeriodosE LlenarEntidad(IDataReader oReader)
        {
            PeriodosE periodos = new PeriodosE
            {
                idEmpresa = Convert.ToInt32(oReader["idEmpresa"]),
                AnioPeriodo = Convert.ToString(oReader["AnioPeriodo"]),
                MesPeriodo = Convert.ToString(oReader["MesPeriodo"])
            };

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodos.desPeriodo = oReader["desPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInicio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodos.fecInicio = oReader["fecInicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecInicio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodos.fecFinal = oReader["fecFinal"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCierre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.indCierre = oReader["indCierre"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCierre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indApertura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.indApertura = oReader["indApertura"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indApertura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReapertura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.indReapertura = oReader["indReapertura"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indReapertura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAjusteDifCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.indAjusteDifCambio = oReader["indAjusteDifCambio"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAjusteDifCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAaFinMes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.indAaFinMes = oReader["indAaFinMes"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAaFinMes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEfectivoAsientos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.indEfectivoAsientos = oReader["indEfectivoAsientos"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEfectivoAsientos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAjustePorDocFinMes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.indAjustePorDocFinMes = oReader["indAjustePorDocFinMes"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAjustePorDocFinMes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEfectivoAjusteFinMes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.indEfectivoAjusteFinMes = oReader["indEfectivoAjusteFinMes"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEfectivoAjusteFinMes"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TCCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.TCCompra = oReader["TCCompra"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TCCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TCVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodos.TCVenta = oReader["TCVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TCVenta"]);

            return  periodos;        
        }

        public PeriodosE InsertarPeriodos(PeriodosE periodos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPeriodos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.AddWithValue("@idEmpresa", periodos.idEmpresa); 
					oComando.Parameters.AddWithValue("@AnioPeriodo", periodos.AnioPeriodo); 
					oComando.Parameters.AddWithValue("@MesPeriodo", periodos.MesPeriodo); 
					oComando.Parameters.AddWithValue("@desPeriodo", periodos.desPeriodo); 
					oComando.Parameters.AddWithValue("@fecInicio", periodos.fecInicio); 
					oComando.Parameters.AddWithValue("@fecFinal", periodos.fecFinal); 
					oComando.Parameters.AddWithValue("@indCierre", periodos.indCierre); 
					oComando.Parameters.AddWithValue("@indApertura", periodos.indApertura); 
					oComando.Parameters.AddWithValue("@indReapertura", periodos.indReapertura); 
					oComando.Parameters.AddWithValue("@indAjusteDifCambio", periodos.indAjusteDifCambio); 
					oComando.Parameters.AddWithValue("@indAaFinMes", periodos.indAaFinMes); 
					oComando.Parameters.AddWithValue("@indEfectivoAsientos", periodos.indEfectivoAsientos); 
					oComando.Parameters.AddWithValue("@indAjustePorDocFinMes", periodos.indAjustePorDocFinMes); 
					oComando.Parameters.AddWithValue("@indEfectivoAjusteFinMes", periodos.indEfectivoAjusteFinMes); 
					oComando.Parameters.AddWithValue("@UsuarioRegistro", periodos.UsuarioRegistro);

                    oComando.Parameters.AddWithValue("@TCCompra", periodos.TCCompra);
                    oComando.Parameters.AddWithValue("@TCVenta", periodos.TCVenta); 

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return periodos;        
        }
        
        public PeriodosE ActualizarPeriodos(PeriodosE periodos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPeriodos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", periodos.idEmpresa); 
					oComando.Parameters.AddWithValue("@AnioPeriodo", periodos.AnioPeriodo); 
					oComando.Parameters.AddWithValue("@MesPeriodo", periodos.MesPeriodo); 
					oComando.Parameters.AddWithValue("@desPeriodo", periodos.desPeriodo); 
					oComando.Parameters.AddWithValue("@fecInicio", periodos.fecInicio); 
					oComando.Parameters.AddWithValue("@fecFinal", periodos.fecFinal); 
					oComando.Parameters.AddWithValue("@indCierre", periodos.indCierre); 
					oComando.Parameters.AddWithValue("@indApertura", periodos.indApertura); 
					oComando.Parameters.AddWithValue("@indReapertura", periodos.indReapertura); 
					oComando.Parameters.AddWithValue("@indAjusteDifCambio", periodos.indAjusteDifCambio); 
					oComando.Parameters.AddWithValue("@indAaFinMes", periodos.indAaFinMes); 
					oComando.Parameters.AddWithValue("@indEfectivoAsientos", periodos.indEfectivoAsientos); 
					oComando.Parameters.AddWithValue("@indAjustePorDocFinMes", periodos.indAjustePorDocFinMes); 
					oComando.Parameters.AddWithValue("@indEfectivoAjusteFinMes", periodos.indEfectivoAjusteFinMes); 
					oComando.Parameters.AddWithValue("@UsuarioModificacion", periodos.UsuarioModificacion);
                    oComando.Parameters.AddWithValue("@TCCompra", periodos.TCCompra);
                    oComando.Parameters.AddWithValue("@TCVenta", periodos.TCVenta); 

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return periodos;
        }        

        public Int32 EliminarPeriodos(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPeriodos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PeriodosE> ListarPeriodos(Int32 idEmpresa, String AnioPeriodo)
        {
           List<PeriodosE> listaEntidad = new List<PeriodosE>();
           PeriodosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPeriodos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    
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

        public PeriodosE ObtenerPeriodoPorMes(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo)
        {        
            PeriodosE periodos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPeriodoPorMes", oConexion))
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
                            periodos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return periodos;        
        }

        public Int32 AperturaAnioContable(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String UsuarioRegistro)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AperturaAnioContable", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.AddWithValue("@UsuarioRegistro", UsuarioRegistro);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}