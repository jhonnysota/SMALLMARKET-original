using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class EEFFItemHistoricoAD : DbConection
    {
        
        public EEFFItemHistoricoE LlenarEntidad(IDataReader oReader)
        {
            EEFFItemHistoricoE eeffitemhistorico = new EEFFItemHistoricoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFF'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.idEEFF = oReader["idEEFF"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFF"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.idEEFFItem = oReader["idEEFFItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='saldo_sol'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.saldo_sol = oReader["saldo_sol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["saldo_sol"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='saldo_dol'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.saldo_dol = oReader["saldo_dol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["saldo_dol"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemhistorico.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //extensiones

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='secItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemhistorico.secItem = oReader["secItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["secItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemhistorico.desItem = oReader["desItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoTabla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemhistorico.TipoTabla = oReader["TipoTabla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoTabla"]);


            return  eeffitemhistorico;        
        }

        public EEFFItemHistoricoE InsertarEEFFItemHistorico(EEFFItemHistoricoE eeffitemhistorico)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEEFFItemHistorico", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = eeffitemhistorico.idEmpresa;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = eeffitemhistorico.idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = eeffitemhistorico.idEEFFItem;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = eeffitemhistorico.AnioPeriodo;
					oComando.Parameters.Add("@saldo_sol", SqlDbType.Decimal).Value = eeffitemhistorico.saldo_sol;
					oComando.Parameters.Add("@saldo_dol", SqlDbType.Decimal).Value = eeffitemhistorico.saldo_dol;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = eeffitemhistorico.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return eeffitemhistorico;
        }
        
        public EEFFItemHistoricoE ActualizarEEFFItemHistorico(EEFFItemHistoricoE eeffitemhistorico)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEEFFItemHistorico", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = eeffitemhistorico.idEmpresa;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = eeffitemhistorico.idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = eeffitemhistorico.idEEFFItem;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = eeffitemhistorico.AnioPeriodo;
					oComando.Parameters.Add("@saldo_sol", SqlDbType.Decimal).Value = eeffitemhistorico.saldo_sol;
					oComando.Parameters.Add("@saldo_dol", SqlDbType.Decimal).Value = eeffitemhistorico.saldo_dol;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = eeffitemhistorico.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return eeffitemhistorico;
        }        

        public int EliminarEEFFItemHistorico(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem, String AnioPeriodo)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEEFFItemHistorico", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<EEFFItemHistoricoE> ListarEEFFItemHistorico(Int32 idEmpresa,Int32 idEEFF, String AnioPeriodo)
        {
           List<EEFFItemHistoricoE> listaEntidad = new List<EEFFItemHistoricoE>();
           EEFFItemHistoricoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEEFFItemHistorico", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar,4).Value = AnioPeriodo;

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
        
        public EEFFItemHistoricoE ObtenerEEFFItemHistorico(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem, String AnioPeriodo)
        {        
            EEFFItemHistoricoE eeffitemhistorico = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEEFFItemHistorico", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            eeffitemhistorico = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return eeffitemhistorico;
        }
    }
}