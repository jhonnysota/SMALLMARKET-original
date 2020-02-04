using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class EEFFAD : DbConection
    {

        public EEFFE LlenarEntidad(IDataReader oReader)
        {
            EEFFE entidad = new EEFFE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFF'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idEEFF = oReader["idEEFF"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFF"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoSeccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoSeccion = oReader["TipoSeccion"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["TipoSeccion"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desSeccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desSeccion = oReader["desSeccion"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["desSeccion"]);            
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoReporte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.tipoReporte = oReader["tipoReporte"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["tipoReporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VerReporte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.VerReporte = oReader["VerReporte"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["VerReporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indComparativo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indComparativo = oReader["indComparativo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indComparativo"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indcCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indcCostos = oReader["indcCostos"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["indcCostos"]);

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

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoTabla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoTabla = oReader["TipoTabla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoTabla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='secitem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.secitem = oReader["secitem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["secitem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desitem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desitem = oReader["desitem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desitem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPlaCta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.CodPlaCta = oReader["CodPlaCta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodPlaCta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesAnterior'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.MesAnterior = oReader["MesAnterior"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MesAnterior"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesAnteriorAcumulado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.MesAnteriorAcumulado = oReader["MesAnteriorAcumulado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MesAnteriorAcumulado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesActual'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.MesActual = oReader["MesActual"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MesActual"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesActualAcumulado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.MesActualAcumulado = oReader["MesActualAcumulado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MesActualAcumulado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Deudor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Deudor = oReader["Deudor"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Deudor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Acreedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Acreedor = oReader["Acreedor"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Acreedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Columna'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Columna = oReader["Columna"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Columna"]);

            return entidad;        
        }

        public EEFFE InsertarEEFF(EEFFE entidad)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarConEEFF", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.AddWithValue("@idEmpresa", entidad.idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", entidad.idEEFF);
                    oComando.Parameters.AddWithValue("@TipoSeccion", entidad.TipoSeccion);
                    oComando.Parameters.AddWithValue("@desSeccion", entidad.desSeccion);
                    oComando.Parameters.AddWithValue("@tipoReporte", entidad.tipoReporte);
                    oComando.Parameters.AddWithValue("@indComparativo", entidad.indComparativo);
                    oComando.Parameters.AddWithValue("@indcCostos", entidad.indcCostos);
                    oComando.Parameters.AddWithValue("@VerReporte", entidad.VerReporte);
                    oComando.Parameters.AddWithValue("@UsuarioRegistro", entidad.UsuarioRegistro);
                    
                    oConexion.Open();
                    entidad.idEEFF = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return entidad;        
        }

        public EEFFE ActualizarEEFF(EEFFE entidad)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConEEFF", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", entidad.idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", entidad.idEEFF);
                    oComando.Parameters.AddWithValue("@TipoSeccion", entidad.TipoSeccion);
                    oComando.Parameters.AddWithValue("@desSeccion", entidad.desSeccion);
                    oComando.Parameters.AddWithValue("@tipoReporte", entidad.tipoReporte);
                    oComando.Parameters.AddWithValue("@indComparativo", entidad.indComparativo);
                    oComando.Parameters.AddWithValue("@indcCostos", entidad.indcCostos);
                    oComando.Parameters.AddWithValue("@VerReporte", entidad.VerReporte);    
                    oComando.Parameters.AddWithValue("@UsuarioModificacion", entidad.UsuarioModificacion);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return entidad;
        }

        public Int32 EliminarEEFF(int idEmpresa, int idEEFF)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConEEFF", oConexion))
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

        public Int32 MaxIdConEEFF(Int32 idEmpresa)
        {
            Int32 idConEEFF = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxIdConEEFF", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                 
                    oConexion.Open();
                    idConEEFF = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return idConEEFF;
        }

        public List<EEFFE> ListarEEFF(int idEmpresa, int idEEFF, string desSeccion, Boolean VerReporte)
        {
            List<EEFFE> listaEntidad = new List<EEFFE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConEEFF", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);
                    oComando.Parameters.AddWithValue("@desSeccion", desSeccion);
                    oComando.Parameters.AddWithValue("@VerReporte", VerReporte);
                    
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

        public List<EEFFE> ListarEEFFParaPres(int idEmpresa)
        {
            List<EEFFE> listaEntidad = new List<EEFFE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConEEFFPres", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);

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

        public EEFFE ObtenerEEFF(int idEmpresa, int idEEFF)
        {
            EEFFE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConEEFF", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);

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

        public List<EEFFE> ListarBalanceGeneral(Int32 idEmpresa, String TipoSeccion, String AnioPeriodo, String MesPeriodo)
        {
            List<EEFFE> listaEntidad = new List<EEFFE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BalanceGeneralDetallado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@TipoSeccion", TipoSeccion);
                    oComando.Parameters.AddWithValue("@AnioPeriodo", AnioPeriodo);
                    oComando.Parameters.AddWithValue("@MesPeriodo", MesPeriodo);

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

        public List<EEFFE> ListarBalanceGeneralResumen(Int32 idEmpresa,String VerPlanCuenta, Int32 TipoSeccion, String AnioPeriodo, String MesPeriodo)
        {
            List<EEFFE> listaEntidad = new List<EEFFE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_listadoEEFFresumen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@VerPlanCuenta", VerPlanCuenta);
                    oComando.Parameters.AddWithValue("@TipoSeccion", TipoSeccion);
                    oComando.Parameters.AddWithValue("@AnioPeriodo", AnioPeriodo);
                    oComando.Parameters.AddWithValue("@MesPeriodo", MesPeriodo);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }

                oConexion.Close();
            }

            return listaEntidad;
        }

    }
}