using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ConciliadoDcmtoPendienteAD : DbConection
    {

        public ConciliadoDcmtoPendienteE LlenarEntidad(IDataReader oReader)
        {
            ConciliadoDcmtoPendienteE conciliadodcmtopendiente = new ConciliadoDcmtoPendienteE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impMonto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.impMonto = oReader["impMonto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impMonto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConciliado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.indConciliado = oReader["indConciliado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indConciliado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conciliadodcmtopendiente.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conciliadodcmtopendiente.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conciliadodcmtopendiente.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Debe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conciliadodcmtopendiente.Debe = oReader["Debe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Debe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Haber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conciliadodcmtopendiente.Haber = oReader["Haber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Haber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Movimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conciliadodcmtopendiente.Movimiento = oReader["Movimiento"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Movimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Orden'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conciliadodcmtopendiente.Orden = oReader["Orden"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Orden"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConciliado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (conciliadodcmtopendiente.indConciliado == "N")
                {
                    conciliadodcmtopendiente.indConciliadoBool = false;
                }
                else
                {
                    conciliadodcmtopendiente.indConciliadoBool = true;
                }
            }

            return conciliadodcmtopendiente;        
        }

        public void ProcesoCierreConciliacion(Int32 idEmpresa, Int32 idLocal, String ano_periodo, String cod_periodo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CierreConciliacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idLocal", idLocal);
                    oComando.Parameters.AddWithValue("@ano_periodo", ano_periodo);
                    oComando.Parameters.AddWithValue("@cod_periodo", cod_periodo);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<ConciliadoDcmtoPendienteE> ReporteConciliadoBancos(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuenta)
        {
            List<ConciliadoDcmtoPendienteE> listaEntidad = new List<ConciliadoDcmtoPendienteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteConciliadoBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

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

        public ConciliadoDcmtoPendienteE ActualizarConciliadoDcmtoPendiente(ConciliadoDcmtoPendienteE conciliadodcmtopendiente)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConciliadoDcmtoPendiente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = conciliadodcmtopendiente.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = conciliadodcmtopendiente.idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = conciliadodcmtopendiente.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = conciliadodcmtopendiente.MesPeriodo;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = conciliadodcmtopendiente.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = conciliadodcmtopendiente.codCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = conciliadodcmtopendiente.idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = conciliadodcmtopendiente.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = conciliadodcmtopendiente.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = conciliadodcmtopendiente.numDocumento;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = conciliadodcmtopendiente.fecDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = conciliadodcmtopendiente.idMoneda;
					oComando.Parameters.Add("@impMonto", SqlDbType.Decimal).Value = conciliadodcmtopendiente.impMonto;
					oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 150).Value = conciliadodcmtopendiente.desGlosa;
					oComando.Parameters.Add("@indConciliado", SqlDbType.VarChar, 1).Value = conciliadodcmtopendiente.indConciliado;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = conciliadodcmtopendiente.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return conciliadodcmtopendiente;
        }

        public ConciliadoDcmtoPendienteE ActualizarConciliado(ConciliadoDcmtoPendienteE conciliadodcmtopendiente)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConciliado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = conciliadodcmtopendiente.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = conciliadodcmtopendiente.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = conciliadodcmtopendiente.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = conciliadodcmtopendiente.MesPeriodo;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = conciliadodcmtopendiente.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = conciliadodcmtopendiente.codCuenta;
                    oComando.Parameters.Add("@indConciliado", SqlDbType.VarChar, 1).Value = conciliadodcmtopendiente.indConciliado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return conciliadodcmtopendiente;
        }

        public int EliminarConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, Int32 idPersona, String idDocumento, String serDocumento, String numDocumento)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConciliadoDcmtoPendiente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ConciliadoDcmtoPendienteE> ListarConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            List<ConciliadoDcmtoPendienteE> listaEntidad = new List<ConciliadoDcmtoPendienteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConciliadoDcmtoPendiente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

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
        
        public ConciliadoDcmtoPendienteE ObtenerConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, Int32 idPersona, String idDocumento, String serDocumento, String numDocumento)
        {        
            ConciliadoDcmtoPendienteE conciliadodcmtopendiente = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConciliadoDcmtoPendiente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            conciliadodcmtopendiente = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return conciliadodcmtopendiente;
        }

        public List<ConciliadoDcmtoPendienteE> ConciliacionPreliminar(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, String idMoneda)
        {
            List<ConciliadoDcmtoPendienteE> listaEntidad = new List<ConciliadoDcmtoPendienteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConciliacionPreliminar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

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