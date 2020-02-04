using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class EEFFItemXlsAD : DbConection
    {
        
        public EEFFItemXlsE LlenarEntidad(IDataReader oReader)
        {
            EEFFItemXlsE eeffitemxls = new EEFFItemXlsE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEMPRESA'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.idEMPRESA = oReader["idEMPRESA"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEMPRESA"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFF'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.idEEFF = oReader["idEEFF"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFF"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.idEEFFItem = oReader["idEEFFItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItemXls'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.idEEFFItemXls = oReader["idEEFFItemXls"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItemXls"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codcCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.codcCostos = oReader["codcCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codcCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='descCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemxls.descCostos = oReader["descCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["descCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fila'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.fila = oReader["fila"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["fila"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='columna'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.columna = oReader["columna"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["columna"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemxls.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  eeffitemxls;        
        }

        public EEFFItemXlsE InsertarEEFFItemXls(EEFFItemXlsE eeffitemxls)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEEFFItemXls", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = eeffitemxls.idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = eeffitemxls.idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = eeffitemxls.idEEFFItem;
                    oComando.Parameters.Add("@idEEFFItemXls", SqlDbType.Int).Value = eeffitemxls.idEEFFItemXls;
                    oComando.Parameters.Add("@codcCostos", SqlDbType.VarChar, 20).Value = eeffitemxls.codcCostos;
					oComando.Parameters.Add("@fila", SqlDbType.Int).Value = eeffitemxls.fila;
					oComando.Parameters.Add("@columna", SqlDbType.Int).Value = eeffitemxls.columna;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = eeffitemxls.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteScalar();
                    oConexion.Close();
                }
            }

            return eeffitemxls;
        }
        
        public EEFFItemXlsE ActualizarEEFFItemXls(EEFFItemXlsE eeffitemxls)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEEFFItemXls", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = eeffitemxls.idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = eeffitemxls.idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = eeffitemxls.idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemXls", SqlDbType.Int).Value = eeffitemxls.idEEFFItemXls;
					oComando.Parameters.Add("@codcCostos", SqlDbType.VarChar, 20).Value = eeffitemxls.codcCostos;
					oComando.Parameters.Add("@fila", SqlDbType.Int).Value = eeffitemxls.fila;
					oComando.Parameters.Add("@columna", SqlDbType.Int).Value = eeffitemxls.columna;

					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = eeffitemxls.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return eeffitemxls;
        }

        public Int32 MaxIdConEEFFItemXls(Int32 idEmpresa, int idEEFF, int idEEFFItem)
        {
            Int32 idConEEFFItemXls = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxIdConEEFFItemXls", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
                    oConexion.Open();
                    idConEEFFItemXls = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return idConEEFFItemXls;
        }

        public int EliminarEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemXls)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEEFFItemXls", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemXls", SqlDbType.Int).Value = idEEFFItemXls;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<EEFFItemXlsE> ListarEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem)
        {
           List<EEFFItemXlsE> listaEntidad = new List<EEFFItemXlsE>();
           EEFFItemXlsE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEEFFItemXls", oConexion))
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
        
        public EEFFItemXlsE ObtenerEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemXls)
        {        
            EEFFItemXlsE eeffitemxls = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEEFFItemXls", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemXls", SqlDbType.Int).Value = idEEFFItemXls;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            eeffitemxls = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return eeffitemxls;
        }
    }
}