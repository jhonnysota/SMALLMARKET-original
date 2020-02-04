using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class EstructuraXLSAD : DbConection
    {
        
        public EstructuraXLSE LlenarEntidad(IDataReader oReader)
        {
            EstructuraXLSE estructuraxls = new EstructuraXLSE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                estructuraxls.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.Tipo = oReader["Tipo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Tipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCampo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.NombreCampo = oReader["NombreCampo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCampo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fila'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.Fila = oReader["Fila"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Fila"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Columna'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.Columna = oReader["Columna"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Columna"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Incluir'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                estructuraxls.Incluir = oReader["Incluir"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Incluir"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsLineal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                estructuraxls.EsLineal = oReader["EsLineal"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsLineal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FilaInicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                estructuraxls.FilaInicio = oReader["FilaInicio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["FilaInicio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estructuraxls.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones...
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                estructuraxls.desTipo = oReader["desTipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipo"]);

            return  estructuraxls;        
        }

        public EstructuraXLSE InsertarEstructuraXLS(EstructuraXLSE estructuraxls)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEstructuraXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = estructuraxls.idEmpresa;
					oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = estructuraxls.Tipo;
					oComando.Parameters.Add("@NombreCampo", SqlDbType.VarChar, 50).Value = estructuraxls.NombreCampo;
					oComando.Parameters.Add("@Fila", SqlDbType.Int).Value = estructuraxls.Fila;
					oComando.Parameters.Add("@Columna", SqlDbType.Int).Value = estructuraxls.Columna;
                    oComando.Parameters.Add("@Incluir", SqlDbType.Bit).Value = estructuraxls.Incluir;
                    oComando.Parameters.Add("@EsLineal", SqlDbType.Bit).Value = estructuraxls.EsLineal;
                    oComando.Parameters.Add("@FilaInicio", SqlDbType.Int).Value = estructuraxls.FilaInicio;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = estructuraxls.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return estructuraxls;
        }
        
        public EstructuraXLSE ActualizarEstructuraXLS(EstructuraXLSE estructuraxls)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstructuraXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = estructuraxls.Item;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = estructuraxls.idEmpresa;
					oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = estructuraxls.Tipo;
					oComando.Parameters.Add("@NombreCampo", SqlDbType.VarChar, 50).Value = estructuraxls.NombreCampo;
					oComando.Parameters.Add("@Fila", SqlDbType.Int).Value = estructuraxls.Fila;
					oComando.Parameters.Add("@Columna", SqlDbType.Int).Value = estructuraxls.Columna;
                    oComando.Parameters.Add("@Incluir", SqlDbType.Bit).Value = estructuraxls.Incluir;
                    oComando.Parameters.Add("@EsLineal", SqlDbType.Bit).Value = estructuraxls.EsLineal;
                    oComando.Parameters.Add("@FilaInicio", SqlDbType.Int).Value = estructuraxls.FilaInicio;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = estructuraxls.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return estructuraxls;
        }        

        public int EliminarEstructuraXLS(Int32 Item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEstructuraXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EstructuraXLSE> ListarEstructuraXLS(Int32 idEmpresa)
        {
           List<EstructuraXLSE> listaEntidad = new List<EstructuraXLSE>();
           EstructuraXLSE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEstructuraXLS", oConexion))
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
        
        public EstructuraXLSE ObtenerEstructuraXLS(Int32 idEmpresa, Int32 Tipo)
        {
            EstructuraXLSE estructuraxls = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEstructuraXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            estructuraxls = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return estructuraxls;
        }

        public List<EstructuraXLSE> NombreColumnasTabla(String NombreTabla)
        {
            List<EstructuraXLSE> listaEntidad = new List<EstructuraXLSE>();
            EstructuraXLSE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_NombreColumnasTabla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@NombreTabla", SqlDbType.VarChar, 50).Value = NombreTabla;

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