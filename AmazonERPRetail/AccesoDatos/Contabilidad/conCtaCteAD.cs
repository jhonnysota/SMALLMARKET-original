using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class conCtaCteAD : DbConection
    {
        
        public conCtaCteE LlenarEntidad(IDataReader oReader)
        {
            conCtaCteE ctacte = new conCtaCteE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecCancelacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.fecCancelacion = oReader["fecCancelacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecCancelacion"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacte.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extension
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CargoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.CargoSoles = oReader["CargoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CargoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SaldoSoles = oReader["SaldoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CargoDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.CargoDolares = oReader["CargoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CargoDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SaldoDolares = oReader["SaldoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoDolares"]);

            //adicionales Henry
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? "" : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? "" : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Item = oReader["Item"] == DBNull.Value ? "" : Convert.ToString(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.TipoDoc = oReader["TipoDoc"] == DBNull.Value ? "" : Convert.ToString(oReader["TipoDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Estado = oReader["Estado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAbreviatura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desAbreviatura = oReader["desAbreviatura"] == DBNull.Value ? "" : Convert.ToString(oReader["desAbreviatura"]);            

            return  ctacte;        
        }

        public conCtaCteE InsertarConCtaCte(conCtaCteE ctacte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarConCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ctacte.idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ctacte.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ctacte.codCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ctacte.idPersona;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = ctacte.fecDocumento;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.Date).Value = ctacte.fecVencimiento;
                    oComando.Parameters.Add("@fecCancelacion", SqlDbType.Date).Value = ctacte.fecCancelacion;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ctacte.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = ctacte.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ctacte.numDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ctacte.idMoneda;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ctacte.idLocal;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = ctacte.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = ctacte.numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = ctacte.numVoucher;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 500).Value = ctacte.Glosa;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = ctacte.fecOperacion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ctacte.UsuarioRegistro;

                    oConexion.Open();
                    ctacte.idCtaCte = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ctacte;
        }
        
        public conCtaCteE ActualizarConCtaCte(conCtaCteE ctacte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = ctacte.idCtaCte;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ctacte.idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ctacte.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ctacte.codCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ctacte.idPersona;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = ctacte.fecDocumento;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.Date).Value = ctacte.fecVencimiento;
                    oComando.Parameters.Add("@fecCancelacion", SqlDbType.Date).Value = ctacte.fecCancelacion;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ctacte.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = ctacte.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ctacte.numDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ctacte.idMoneda;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ctacte.idLocal;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = ctacte.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = ctacte.numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = ctacte.numVoucher;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 500).Value = ctacte.Glosa;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = ctacte.fecOperacion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ctacte.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ctacte;
        }        

        public Int32 EliminarConCtaCte(Int32 idCtaCte)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<conCtaCteE> ListarConCtaCte()
        {
           List<conCtaCteE> listaEntidad = new List<conCtaCteE>();
           conCtaCteE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public conCtaCteE ObtenerConCtaCte(Int32 idCtaCte)
        {        
            conCtaCteE ctacte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacte = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacte;
        }

        public void ActualizarConCtaCteFechaCancelacion(Int32 idCtaCte, Int32 idEmpresa)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConCtaCteFechaCancelacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<conCtaCteE> ResumenConCtaCtePorParametros(Int32 idEmpresa, String codCuenta, Int32 idPersona, DateTime Fecha)
        {
            List<conCtaCteE> oListaCtaCTe = new List<conCtaCteE>();
            conCtaCteE oCtaCte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ResumenConCtaCtePorParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oCtaCte = LlenarEntidad(oReader);
                            oListaCtaCTe.Add(oCtaCte);
                        }
                    }
                }
            }

            return oListaCtaCTe;
        }

        public List<conCtaCteE> ReporteConCtaCtePendientes(Int32 idEmpresa, String numPlanCta, String ano, String cuenta_ini, String cuenta_fin,
            Int32 idPersona, String mes_inicial, String mes_fin, String idmoneda, String historico, String tipo_reporte)
        {
            List<conCtaCteE> oListaCtaCTe = new List<conCtaCteE>();
            conCtaCteE oCtaCte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteConCtaCtePendientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@ver_placta", numPlanCta);
                    oComando.Parameters.AddWithValue("@ano", ano);
                    oComando.Parameters.AddWithValue("@cuenta_ini", cuenta_ini);
                    oComando.Parameters.AddWithValue("@cuenta_fin", cuenta_fin);
                    oComando.Parameters.AddWithValue("@idPersona", idPersona);
                    oComando.Parameters.AddWithValue("@mes_inicial", mes_inicial);
                    oComando.Parameters.AddWithValue("@mes_final", mes_fin);
                    oComando.Parameters.AddWithValue("@idMoneda", idmoneda);
                    oComando.Parameters.AddWithValue("@historico", historico);
                    oComando.Parameters.AddWithValue("@tipo_reporte", tipo_reporte);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oCtaCte = LlenarEntidad(oReader);
                            oListaCtaCTe.Add(oCtaCte);
                        }
                    }
                }
            }

            return oListaCtaCTe;
        }

        public List<conCtaCteE> ReporteInventarioBalanceCtaCte(Int32 idEmpresa, String Anio, String Mes,Int32 Tipo)
        {
            List<conCtaCteE> oListaCtaCTe = new List<conCtaCteE>();
            conCtaCteE oCtaCte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteInventarioBalanceCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@Anio", Anio);
                    oComando.Parameters.AddWithValue("@Mes", Mes);
                    oComando.Parameters.AddWithValue("@Tipo", Tipo);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oCtaCte = LlenarEntidad(oReader);
                            oListaCtaCTe.Add(oCtaCte);
                        }
                    }
                }
            }

            return oListaCtaCTe;
        }

    }
}