using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class EEFFItemAD : DbConection
    {

        public EEFFItemE LlenarEntidad(IDataReader oReader)
        {
            EEFFItemE entidad = new EEFFItemE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFF'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idEEFF = oReader["idEEFF"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFF"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idEEFFItem = oReader["idEEFFItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='secItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.secItem = oReader["secItem"] == DBNull.Value ? String.Empty : Convert.ToString( oReader["secItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desItem = oReader["desItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoTabla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoTabla = oReader["TipoTabla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoTabla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCaracteristica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoCaracteristica = oReader["TipoCaracteristica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCaracteristica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoItem = oReader["TipoItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoColumna'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoColumna = oReader["TipoColumna"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoColumna"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPorcentaje'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indPorcentaje = oReader["indPorcentaje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indPorcentaje"]);
           
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indImprimir'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indImprimir = oReader["indImprimir"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indImprimir"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEnviaExcel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indEnviaExcel = oReader["indEnviaExcel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEnviaExcel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indMostrar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indMostrar = oReader["indMostrar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indMostrar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.codSunat = oReader["codSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return entidad;        
        }

        public EEFFItemE InsertarEEFFItem(EEFFItemE entidad)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarConEEFFItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", entidad.idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", entidad.idEEFF);
                    oComando.Parameters.AddWithValue("@idEEFFItem", entidad.idEEFFItem);
                    oComando.Parameters.AddWithValue("@secItem", entidad.secItem);
                    oComando.Parameters.AddWithValue("@desItem", entidad.desItem);
                    oComando.Parameters.AddWithValue("@TipoTabla", entidad.TipoTabla);
                    oComando.Parameters.AddWithValue("@TipoCaracteristica", entidad.TipoCaracteristica);
                    oComando.Parameters.AddWithValue("@TipoItem", entidad.TipoItem);
                    oComando.Parameters.AddWithValue("@TipoColumna", entidad.TipoColumna);
                    oComando.Parameters.AddWithValue("@indPorcentaje", entidad.indPorcentaje);                    
                    oComando.Parameters.AddWithValue("@indImprimir", entidad.indImprimir); 
                    oComando.Parameters.AddWithValue("@indEnviaExcel", entidad.indEnviaExcel);
                    oComando.Parameters.Add("@indMostrar", SqlDbType.Bit).Value = entidad.indMostrar;
                    oComando.Parameters.Add("@codSunat", SqlDbType.VarChar,10).Value = entidad.codSunat;
                    oComando.Parameters.AddWithValue("@UsuarioRegistro", entidad.UsuarioRegistro);

                    oConexion.Open();
                    entidad.idEEFFItem = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return entidad;        
        }

        public EEFFItemE ActualizarEEFFItem(EEFFItemE entidad)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConEEFFItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", entidad.idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", entidad.idEEFF);
                    oComando.Parameters.AddWithValue("@idEEFFItem", entidad.idEEFFItem);
                    oComando.Parameters.AddWithValue("@secItem", entidad.secItem);
                    oComando.Parameters.AddWithValue("@desItem", entidad.desItem);
                    oComando.Parameters.AddWithValue("@TipoTabla", entidad.TipoTabla);
                    oComando.Parameters.AddWithValue("@TipoCaracteristica", entidad.TipoCaracteristica);
                    oComando.Parameters.AddWithValue("@TipoItem", entidad.TipoItem);
                    oComando.Parameters.AddWithValue("@TipoColumna", entidad.TipoColumna);
                    oComando.Parameters.AddWithValue("@indPorcentaje", entidad.indPorcentaje);
                    oComando.Parameters.AddWithValue("@indImprimir", entidad.indImprimir);
                    oComando.Parameters.AddWithValue("@indEnviaExcel", entidad.indEnviaExcel);
                    oComando.Parameters.Add("@indMostrar", SqlDbType.Bit).Value = entidad.indMostrar;
                    oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 10).Value = entidad.codSunat;
                    oComando.Parameters.AddWithValue("@UsuarioModificacion", entidad.UsuarioModificacion); 

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return entidad;
        }

        public Int32 EliminarEEFFItem(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConEEFFItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);
                    oComando.Parameters.AddWithValue("@idEEFFItem", idEEFFItem);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 MaxIdConEEFFItem(Int32 idEmpresa, Int32 idEEFF)
        {
            Int32 idConEEFF = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxIdConEEFFItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;

                    oConexion.Open();
                    idConEEFF = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return idConEEFF;
        }

        public Int32 EliminarDetalleEEFFItem(Int32 idEmpresa, Int32 idEEFF)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarDetalleConEEFFItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);
                    
                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EEFFItemE> ListarEEFFItem(Int32 idEmpresa, Int32 idEEFF)
        {
            List<EEFFItemE> listaEntidad = new List<EEFFItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConEEFFItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);

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

        public List<EEFFItemE> ListarConEEFFItemParPres(Int32 idEmpresa, Int32 idEEFF)
        {
            List<EEFFItemE> listaEntidad = new List<EEFFItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConEEFFItemParPres", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);

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

        public EEFFItemE ObtenerEEFFItem(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem)
        {
            EEFFItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConEEFFItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);
                    oComando.Parameters.AddWithValue("@idEEFFItem", idEEFFItem);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return entidad;
        }

        public List<EEFFItemE> ListarConEEFFItemFaltantes(Int32 idEmpresa, Int32 idEEFF)
        {
            List<EEFFItemE> listaEntidad = new List<EEFFItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConEEFFItemFaltantes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;

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