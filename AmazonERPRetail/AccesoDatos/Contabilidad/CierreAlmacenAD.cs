using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class CierreAlmacenAD : DbConection
    {
        
        public CierreAlmacenE LlenarEntidad(IDataReader oReader)
        {
            CierreAlmacenE cierrealmacen = new CierreAlmacenE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCierre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.indCierre = oReader["indCierre"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCierre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaCierre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.FechaCierre = oReader["FechaCierre"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaCierre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cierrealmacen.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cierrealmacen.DesAlmacen = oReader["DesAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesAlmacen"]);

            return  cierrealmacen;        
        }

        public CierreAlmacenE InsertarCierreAlmacen(CierreAlmacenE cierrealmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCierreAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cierrealmacen.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = cierrealmacen.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = cierrealmacen.MesPeriodo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = cierrealmacen.idAlmacen;
					oComando.Parameters.Add("@indCierre", SqlDbType.Bit).Value = cierrealmacen.indCierre;
					oComando.Parameters.Add("@FechaCierre", SqlDbType.DateTime).Value = cierrealmacen.FechaCierre;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = cierrealmacen.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return cierrealmacen;
        }
        
        public CierreAlmacenE ActualizarCierreAlmacen(CierreAlmacenE cierrealmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCierreAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cierrealmacen.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = cierrealmacen.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = cierrealmacen.MesPeriodo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = cierrealmacen.idAlmacen;
					oComando.Parameters.Add("@indCierre", SqlDbType.Bit).Value = cierrealmacen.indCierre;
					oComando.Parameters.Add("@FechaCierre", SqlDbType.DateTime).Value = cierrealmacen.FechaCierre;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = cierrealmacen.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return cierrealmacen;
        }        

        public int EliminarCierreAlmacen(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCierreAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CierreAlmacenE> ListarCierreAlmacen(Int32 idEmpresa, String AnioPeriodo , String MesPeriodo)
        {
           List<CierreAlmacenE> listaEntidad = new List<CierreAlmacenE>();
           CierreAlmacenE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCierreAlmacen", oConexion))
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
        
        public CierreAlmacenE ObtenerCierreAlmacen(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen)
        {        
            CierreAlmacenE cierrealmacen = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCierreAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cierrealmacen = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return cierrealmacen;
        }
    }
}