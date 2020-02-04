using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ConceptoGastoAD : DbConection
    {
        
        public ConceptoGastoE LlenarEntidad(IDataReader oReader)
        {
            ConceptoGastoE concepto = new ConceptoGastoE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.desConcepto = oReader["desConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);





            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVourcher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.numVourcher = oReader["numVourcher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVourcher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.nombre = oReader["nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='mesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.mesPeriodo = oReader["mesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["mesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='anioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.anioPeriodo = oReader["anioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["anioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='debeSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.debeSoles = oReader["debeSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["debeSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='haberSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.haberSoles = oReader["haberSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["haberSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='debeDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.debeDolares = oReader["debeDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["debeDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='haberDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                concepto.haberDolares = oReader["haberDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["haberDolares"]);


            return concepto;
        }

        public ConceptoGastoE InsertarConceptoGasto(ConceptoGastoE concepto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarConceptoGasto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codConcepto", SqlDbType.VarChar, 10).Value = concepto.codConcepto;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = concepto.idEmpresa;
                    oComando.Parameters.Add("@desConcepto", SqlDbType.VarChar, 50).Value = concepto.desConcepto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = concepto.UsuarioRegistro;

                    oConexion.Open();
                    concepto.idConcepto = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return concepto;
        }

        public ConceptoGastoE ActualizarConceptoGasto(ConceptoGastoE concepto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConceptoGasto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = concepto.idConcepto;
                    oComando.Parameters.Add("@codConcepto", SqlDbType.VarChar, 10).Value = concepto.codConcepto;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = concepto.idEmpresa;
                    oComando.Parameters.Add("@desConcepto", SqlDbType.VarChar, 50).Value = concepto.desConcepto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = concepto.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return concepto;
        }

        public Int32 EliminarConceptoGasto(Int32 idConcepto, Int32 idEmpresa)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConceptoGasto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ConceptoGastoE> ListarConceptoGasto(Int32 idEmpresa)
        {
            List<ConceptoGastoE> listaEntidad = new List<ConceptoGastoE>();
            ConceptoGastoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConceptoGasto", oConexion))
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

        public ConceptoGastoE ObtenerConceptoGasto(Int32 idConcepto, Int32 idEmpresa)
        {
            ConceptoGastoE concepto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConceptoGasto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            concepto = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return concepto;
        }

        public List<ConceptoGastoE> ObtenerListarConceptoGasto(Int32 idEmpresa, String anioPeriodo, Int32 idMoneda, DateTime periodoIni, DateTime periodoFin)
        {
            List<ConceptoGastoE> lista = new List<ConceptoGastoE>();
            ConceptoGastoE concepto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteGastoCampania", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.Int).Value = anioPeriodo;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Int).Value = idMoneda;
                    oComando.Parameters.Add("@periodoIni", SqlDbType.Int).Value = periodoIni;
                    oComando.Parameters.Add("@periodoFin", SqlDbType.Int).Value = periodoFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            concepto = LlenarEntidad(oReader);
                            lista.Add(concepto);
                        }
                    }
                }
            }

            return lista;
        }

        public List<ConceptoGastoE> ListarReporteConceptoGasto(Int32 idEmpresa, String idMoneda, String anio, String mesInicio, String mesFinal)
        {
            List<ConceptoGastoE> ListaConcepto = new List<ConceptoGastoE>();
            ConceptoGastoE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.USP_LISTAR_REPORTE_CAMPANAS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                    oComando.Parameters.Add("@mesInicio", SqlDbType.VarChar, 2).Value = mesInicio;
                    oComando.Parameters.Add("@mesFinal", SqlDbType.VarChar, 2).Value = mesFinal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaConcepto.Add(Item);
                        }
                    }
                }
            }

            return ListaConcepto;
        }

    }
}
