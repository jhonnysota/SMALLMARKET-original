using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class conCtaCteItemAD : DbConection
    {
        
        public conCtaCteItemE LlenarEntidad(IDataReader oReader)
        {
            conCtaCteItemE ctacteitem = new conCtaCteItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacteitem.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacteitem.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.idDocumentoMov = oReader["idDocumentoMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.SerieMov = oReader["SerieMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumeroMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.NumeroMov = oReader["NumeroMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumeroMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.FechaMovimiento = oReader["FechaMovimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaMovimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacteitem.TipoMovimiento = oReader["TipoMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoMovimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacteitem.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacteitem.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacteitem.impSoles = oReader["impSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ctacteitem.impDolares = oReader["impDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones **************************************************************************************************************************
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.Tica = oReader["Tica"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Tica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.SaldoSoles = oReader["SaldoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.SaldoDolares = oReader["SaldoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AgenteRetenedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.AgenteRetenedor = oReader["AgenteRetenedor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AgenteRetenedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.idCCostos = oReader["idCCostos"] == DBNull.Value ? "" : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? "" : Convert.ToString(oReader["tipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacteitem.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? "" : Convert.ToString(oReader["codPartidaPresu"]);


            return ctacteitem;        
        }

        public conCtaCteItemE InsertarConCtaCteItem(conCtaCteItemE ctacteitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarConCtaCteItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = ctacteitem.idCtaCte;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 20).Value = ctacteitem.idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 20).Value = ctacteitem.SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = ctacteitem.NumeroMov;
                    oComando.Parameters.Add("@FechaMovimiento", SqlDbType.SmallDateTime).Value = ctacteitem.FechaMovimiento;
					oComando.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 1).Value = ctacteitem.TipoMovimiento;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ctacteitem.Monto;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ctacteitem.TipoCambio;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = ctacteitem.indDebeHaber;
					oComando.Parameters.Add("@impSoles", SqlDbType.Decimal).Value = ctacteitem.impSoles;
					oComando.Parameters.Add("@impDolares", SqlDbType.Decimal).Value = ctacteitem.impDolares;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ctacteitem.idLocal;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = ctacteitem.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = ctacteitem.numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = ctacteitem.numVoucher;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ctacteitem.UsuarioRegistro;

                    oConexion.Open();
                    ctacteitem.idCtaCteItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ctacteitem;
        }
        
        public conCtaCteItemE ActualizarConCtaCteItem(conCtaCteItemE ctacteitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConCtaCteItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = ctacteitem.idCtaCte;
					oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = ctacteitem.idCtaCteItem;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 2).Value = ctacteitem.idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 20).Value = ctacteitem.SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = ctacteitem.NumeroMov;
                    oComando.Parameters.Add("@FechaMovimiento", SqlDbType.SmallDateTime).Value = ctacteitem.FechaMovimiento;
					oComando.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 1).Value = ctacteitem.TipoMovimiento;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ctacteitem.Monto;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ctacteitem.TipoCambio;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = ctacteitem.indDebeHaber;
					oComando.Parameters.Add("@impSoles", SqlDbType.Decimal).Value = ctacteitem.impSoles;
					oComando.Parameters.Add("@impDolares", SqlDbType.Decimal).Value = ctacteitem.impDolares;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ctacteitem.idLocal;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = ctacteitem.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = ctacteitem.numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = ctacteitem.numVoucher;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ctacteitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ctacteitem;
        }        

        public Int32 EliminarConCtaCteItem(Int32 idCtaCte, Int32 idCtaCteItem)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConCtaCteItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
					oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = idCtaCteItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<conCtaCteItemE> ListarConCtaCteItemPorCodigo(Int32 idCtaCte)
        {
           List<conCtaCteItemE> listaEntidad = new List<conCtaCteItemE>();
           conCtaCteItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConCtaCteItemPorCodigo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;

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
        
        public conCtaCteItemE ObtenerConCtaCteItem(Int32 idCtaCte, Int32 idCtaCteItem)
        {        
            conCtaCteItemE ctacteitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConCtaCteItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
					oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = idCtaCteItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacteitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacteitem;
        }

        public List<conCtaCteItemE> ListarConCtaCtePendientes(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta, Int32 idPersona, DateTime fecFiltro)
        {
            List<conCtaCteItemE> oListaPendientes = new List<conCtaCteItemE>();
            conCtaCteItemE oItem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConCtaCtePendientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oItem = LlenarEntidad(oReader);
                            oListaPendientes.Add(oItem);
                        }
                    }

                    oConexion.Close();
                }
            }

            return oListaPendientes;
        }

        public conCtaCteItemE ObtenerConCtaCtePorDocumento(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta, Int32 idPersona, DateTime fecFiltro, String idDocumento, String serDocumento, String numDocumento)
        {
            conCtaCteItemE oItem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConCtaCtePorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 20).Value = idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oItem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return oItem;
        }

        public List<conCtaCteItemE> DetalleConCtaCtePorParametros(Int32 idCtaCte, Int32 idEmpresa, String codCuenta, Int32 idPersona, DateTime Fecha)
        {
            List<conCtaCteItemE> oListaPendientes = new List<conCtaCteItemE>();
            conCtaCteItemE oItem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_DetalleConCtaCtePorParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oItem = LlenarEntidad(oReader);
                            oListaPendientes.Add(oItem);
                        }
                    }
                }
            }

            return oListaPendientes;
        }

        public conCtaCteItemE RecuperarNaturalezaCargoCtaCte(Int32 idCtaCte, String idDocumento, String serDocumento, String numDocumento)
        {
            conCtaCteItemE ctacteitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarNaturalezaCargoCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 20).Value = idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacteitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacteitem;
        }

    }
}