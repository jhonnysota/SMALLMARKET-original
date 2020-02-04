using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class CierreSistemaAD : DbConection
    {
        
        public CierreSistemaE LlenarEntidad(IDataReader oReader)
        {
            CierreSistemaE cierresistema = new CierreSistemaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.idSistema = oReader["idSistema"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSistema"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCierre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.indCierre = oReader["indCierre"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCierre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaCierre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.FechaCierre = oReader["FechaCierre"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaCierre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierresistema.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesSistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cierresistema.DesSistema = oReader["DesSistema"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesSistema"]);

            return  cierresistema;        
        }

        public CierreSistemaE InsertarCierreSistema(CierreSistemaE cierresistema)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCierreSistema", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cierresistema.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = cierresistema.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = cierresistema.MesPeriodo;
					oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = cierresistema.idSistema;
					oComando.Parameters.Add("@indCierre", SqlDbType.Bit).Value = cierresistema.indCierre;
					oComando.Parameters.Add("@FechaCierre", SqlDbType.DateTime).Value = cierresistema.FechaCierre;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = cierresistema.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return cierresistema;
        }
        
        public CierreSistemaE ActualizarCierreSistema(CierreSistemaE cierresistema)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCierreSistema", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cierresistema.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = cierresistema.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = cierresistema.MesPeriodo;
					oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = cierresistema.idSistema;
					oComando.Parameters.Add("@indCierre", SqlDbType.Bit).Value = cierresistema.indCierre;
					oComando.Parameters.Add("@FechaCierre", SqlDbType.DateTime).Value = cierresistema.FechaCierre;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = cierresistema.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return cierresistema;
        }        

        public int EliminarCierreSistema(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idSistema)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCierreSistema", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CierreSistemaE> ListarCierreSistema(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo)
        {
           List<CierreSistemaE> listaEntidad = new List<CierreSistemaE>();
           CierreSistemaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCierreSistema", oConexion))
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
        
        public CierreSistemaE ObtenerCierreSistema(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idSistema)
        {        
            CierreSistemaE cierresistema = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCierreSistema", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cierresistema = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return cierresistema;
        }
    }
}