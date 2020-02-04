using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class EEFFRatiosAD : DbConection
    {
        
        public EEFFRatiosE LlenarEntidad(IDataReader oReader)
        {
            EEFFRatiosE eeffratios = new EEFFRatiosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='secItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.secItem = oReader["secItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["secItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.desItem = oReader["desItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoTabla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.TipoTabla = oReader["TipoTabla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoTabla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Formula'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.Formula = oReader["Formula"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Formula"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagActivo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.flagActivo = oReader["flagActivo"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagActivo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffratios.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  eeffratios;        
        }

        public EEFFRatiosE InsertarEEFFRatios(EEFFRatiosE eeffratios)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEEFFRatios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = eeffratios.idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = eeffratios.idItem;
					oComando.Parameters.Add("@secItem", SqlDbType.VarChar, 20).Value = eeffratios.secItem;
					oComando.Parameters.Add("@desItem", SqlDbType.VarChar, 100).Value = eeffratios.desItem;
					oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 250).Value = eeffratios.desGlosa;
					oComando.Parameters.Add("@TipoTabla", SqlDbType.Char, 3).Value = eeffratios.TipoTabla;
					oComando.Parameters.Add("@Formula", SqlDbType.VarChar, 250).Value = eeffratios.Formula;
					oComando.Parameters.Add("@flagActivo", SqlDbType.Bit).Value = eeffratios.flagActivo;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = eeffratios.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return eeffratios;
        }
        
        public EEFFRatiosE ActualizarEEFFRatios(EEFFRatiosE eeffratios)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEEFFRatios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = eeffratios.idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = eeffratios.idItem;
					oComando.Parameters.Add("@secItem", SqlDbType.VarChar, 20).Value = eeffratios.secItem;
					oComando.Parameters.Add("@desItem", SqlDbType.VarChar, 100).Value = eeffratios.desItem;
					oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 250).Value = eeffratios.desGlosa;
					oComando.Parameters.Add("@TipoTabla", SqlDbType.Char, 3).Value = eeffratios.TipoTabla;
					oComando.Parameters.Add("@Formula", SqlDbType.VarChar, 250).Value = eeffratios.Formula;
					oComando.Parameters.Add("@flagActivo", SqlDbType.Bit).Value = eeffratios.flagActivo;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = eeffratios.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return eeffratios;
        }        

        public int EliminarEEFFRatios(Int32 idEmpresa, Int32 idItem)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEEFFRatios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<EEFFRatiosE> ListarEEFFRatios(Int32 idEmpresa)
        {
           List<EEFFRatiosE> listaEntidad = new List<EEFFRatiosE>();
           EEFFRatiosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEEFFRatios", oConexion))
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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public EEFFRatiosE ObtenerEEFFRatios(Int32 idEmpresa, Int32 idItem)
        {        
            EEFFRatiosE eeffratios = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEEFFRatios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            eeffratios = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return eeffratios;
        }
    }
}