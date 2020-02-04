using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class EEFFItemForAD : DbConection
    {
        
        public EEFFItemForE LlenarEntidad(IDataReader oReader)
        {
            EEFFItemForE eeffitemfor = new EEFFItemForE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEMPRESA'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.idEMPRESA = oReader["idEMPRESA"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEMPRESA"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFF'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.idEEFF = oReader["idEEFF"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFF"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.idEEFFItem = oReader["idEEFFItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItemFor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.idEEFFItemFor = oReader["idEEFFItemFor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItemFor"]);
			

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='secItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.secItem = oReader["secItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["secItem"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemfor.desItem = oReader["desItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desItem"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoOperador'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.TipoOperador = oReader["TipoOperador"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoOperador"]);
			

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemfor.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  eeffitemfor;        
        }

        public EEFFItemForE InsertarEEFFItemFor(EEFFItemForE eeffitemfor)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEEFFItemFor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = eeffitemfor.idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = eeffitemfor.idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = eeffitemfor.idEEFFItem;
                    oComando.Parameters.Add("@idEEFFItemFor", SqlDbType.Int).Value = eeffitemfor.idEEFFItemFor;
                    oComando.Parameters.Add("@secItem", SqlDbType.VarChar, 6).Value = eeffitemfor.secItem;
					oComando.Parameters.Add("@TipoOperador", SqlDbType.Char, 1).Value = eeffitemfor.TipoOperador;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = eeffitemfor.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteScalar();
                    oConexion.Close();
                }
            }

            return eeffitemfor;
        }
        
        public EEFFItemForE ActualizarEEFFItemFor(EEFFItemForE eeffitemfor)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEEFFItemFor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = eeffitemfor.idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = eeffitemfor.idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = eeffitemfor.idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemFor", SqlDbType.Int).Value = eeffitemfor.idEEFFItemFor;
					oComando.Parameters.Add("@secItem", SqlDbType.VarChar, 6).Value = eeffitemfor.secItem;
					oComando.Parameters.Add("@TipoOperador", SqlDbType.Char, 1).Value = eeffitemfor.TipoOperador;

					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = eeffitemfor.UsuarioModificacion;
					

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return eeffitemfor;
        }

        public Int32 MaxIdConEEFFItemFor(Int32 idEmpresa, int idEEFF, int idEEFFItem)
        {
            Int32 idConEEFFItemFor = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxIdConEEFFItemFor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
                    oConexion.Open();
                    idConEEFFItemFor = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return idConEEFFItemFor;
        }

        public int EliminarEEFFItemFor(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemFor)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEEFFItemFor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemFor", SqlDbType.Int).Value = idEEFFItemFor;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<EEFFItemForE> ListarEEFFItemFor(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem)
        {
           List<EEFFItemForE> listaEntidad = new List<EEFFItemForE>();
           EEFFItemForE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEEFFItemFor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = idEMPRESA;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;

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
        
        public EEFFItemForE ObtenerEEFFItemFor(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemFor)
        {        
            EEFFItemForE eeffitemfor = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEEFFItemFor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemFor", SqlDbType.Int).Value = idEEFFItemFor;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            eeffitemfor = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return eeffitemfor;
        }
    }
}