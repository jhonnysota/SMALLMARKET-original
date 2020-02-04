using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ReciboHonorariosDetAD : DbConection
    {

        public ReciboHonorariosDetE LlenarEntidad(IDataReader oReader)
        {
            ReciboHonorariosDetE recibohonorariosdet = new ReciboHonorariosDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idReciboHonorarios'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.idReciboHonorarios = oReader["idReciboHonorarios"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idReciboHonorarios"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idReciboHonorariosDet'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idReciboHonorariosDet = oReader["idReciboHonorariosDet"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idReciboHonorariosDet"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.FechaOperacion = oReader["FechaOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRecibo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.FechaRecibo = oReader["FechaRecibo"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRecibo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impRecibo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.impRecibo = oReader["impRecibo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impRecibo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impFlete'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.impFlete = oReader["impFlete"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impFlete"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impRetencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.impRetencion = oReader["impRetencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impRetencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.FechaPago = oReader["FechaPago"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.numVerPlanCuenta = oReader["numVerPlanCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuentaGastos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.CuentaGastos = oReader["CuentaGastos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CuentaGastos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFormula'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.codFormula = oReader["codFormula"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFormula"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuartaCat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.indCuartaCat = oReader["indCuartaCat"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuartaCat"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porRetencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.porRetencion = oReader["porRetencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porRetencion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCuartaCat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.impCuartaCat = oReader["impCuartaCat"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCuartaCat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.indVoucher = oReader["indVoucher"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indHojaCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.indHojaCosto = oReader["indHojaCosto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indHojaCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idHojaCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idHojaCosto = oReader["idHojaCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idHojaCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorariosdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomGasto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.NomGasto = oReader["NomGasto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomGasto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.NomCosto = oReader["NomCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorariosdet.nomConcepto = oReader["nomConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomConcepto"]);

            return recibohonorariosdet;        
        }

        public ReciboHonorariosDetE InsertarReciboHonorariosDet(ReciboHonorariosDetE recibohonorariosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarReciboHonorariosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = recibohonorariosdet.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = recibohonorariosdet.idLocal;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = recibohonorariosdet.idReciboHonorarios;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = recibohonorariosdet.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = recibohonorariosdet.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = recibohonorariosdet.numDocumento;
                    oComando.Parameters.Add("@FechaOperacion", SqlDbType.SmallDateTime).Value = recibohonorariosdet.FechaOperacion;
                    oComando.Parameters.Add("@FechaRecibo", SqlDbType.SmallDateTime).Value = recibohonorariosdet.FechaRecibo;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = recibohonorariosdet.TipoCambio;
                    oComando.Parameters.Add("@impRecibo", SqlDbType.Decimal).Value = recibohonorariosdet.impRecibo;
					oComando.Parameters.Add("@impFlete", SqlDbType.Decimal).Value = recibohonorariosdet.impFlete;
					oComando.Parameters.Add("@impRetencion", SqlDbType.Decimal).Value = recibohonorariosdet.impRetencion;
					oComando.Parameters.Add("@FechaPago", SqlDbType.SmallDateTime).Value = recibohonorariosdet.FechaPago;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = recibohonorariosdet.idMoneda;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = recibohonorariosdet.numVerPlanCuenta;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = recibohonorariosdet.codCuenta;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = recibohonorariosdet.idConcepto;
                    oComando.Parameters.Add("@CuentaGastos", SqlDbType.VarChar, 20).Value = recibohonorariosdet.CuentaGastos;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = recibohonorariosdet.idCCostos;
					oComando.Parameters.Add("@codFormula", SqlDbType.VarChar, 20).Value = recibohonorariosdet.codFormula;
                    oComando.Parameters.Add("@indCuartaCat", SqlDbType.Bit).Value = recibohonorariosdet.indCuartaCat;
                    oComando.Parameters.Add("@porRetencion", SqlDbType.Decimal).Value = recibohonorariosdet.porRetencion;
					oComando.Parameters.Add("@impCuartaCat", SqlDbType.Decimal).Value = recibohonorariosdet.impCuartaCat;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar,200).Value = recibohonorariosdet.Glosa;
                    oComando.Parameters.Add("@indHojaCosto", SqlDbType.Bit).Value = recibohonorariosdet.indHojaCosto;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = recibohonorariosdet.idHojaCosto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = recibohonorariosdet.UsuarioRegistro;

                    oConexion.Open();
                    recibohonorariosdet.idReciboHonorarios = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return recibohonorariosdet;
        }
        
        public ReciboHonorariosDetE ActualizarReciboHonorariosDet(ReciboHonorariosDetE recibohonorariosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarReciboHonorariosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = recibohonorariosdet.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = recibohonorariosdet.idLocal;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = recibohonorariosdet.idReciboHonorarios;
                    oComando.Parameters.Add("@idReciboHonorariosDet", SqlDbType.Int).Value = recibohonorariosdet.idReciboHonorariosDet;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = recibohonorariosdet.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = recibohonorariosdet.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = recibohonorariosdet.numDocumento;
                    oComando.Parameters.Add("@FechaOperacion", SqlDbType.SmallDateTime).Value = recibohonorariosdet.FechaOperacion;
                    oComando.Parameters.Add("@FechaRecibo", SqlDbType.SmallDateTime).Value = recibohonorariosdet.FechaRecibo;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = recibohonorariosdet.TipoCambio;
                    oComando.Parameters.Add("@impRecibo", SqlDbType.Decimal).Value = recibohonorariosdet.impRecibo;
                    oComando.Parameters.Add("@impFlete", SqlDbType.Decimal).Value = recibohonorariosdet.impFlete;
                    oComando.Parameters.Add("@impRetencion", SqlDbType.Decimal).Value = recibohonorariosdet.impRetencion;
                    oComando.Parameters.Add("@FechaPago", SqlDbType.SmallDateTime).Value = recibohonorariosdet.FechaPago;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = recibohonorariosdet.idMoneda;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = recibohonorariosdet.numVerPlanCuenta;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = recibohonorariosdet.codCuenta;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = recibohonorariosdet.idConcepto;
                    oComando.Parameters.Add("@CuentaGastos", SqlDbType.VarChar, 20).Value = recibohonorariosdet.CuentaGastos;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = recibohonorariosdet.idCCostos;
                    oComando.Parameters.Add("@codFormula", SqlDbType.VarChar, 20).Value = recibohonorariosdet.codFormula;
                    oComando.Parameters.Add("@indCuartaCat", SqlDbType.Bit).Value = recibohonorariosdet.indCuartaCat;
                    oComando.Parameters.Add("@porRetencion", SqlDbType.Decimal).Value = recibohonorariosdet.porRetencion;
                    oComando.Parameters.Add("@impCuartaCat", SqlDbType.Decimal).Value = recibohonorariosdet.impCuartaCat;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = recibohonorariosdet.Glosa;
                    oComando.Parameters.Add("@indHojaCosto", SqlDbType.Bit).Value = recibohonorariosdet.indHojaCosto;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = recibohonorariosdet.idHojaCosto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = recibohonorariosdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return recibohonorariosdet;
        }

        public int EliminarReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios, Int32 idReciboHonorariosDet)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarReciboHonorariosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = idReciboHonorarios;
                    oComando.Parameters.Add("@idReciboHonorariosDet", SqlDbType.Int).Value = idReciboHonorariosDet;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ReciboHonorariosDetE> ListarReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios)
        {
            List<ReciboHonorariosDetE> listaEntidad = new List<ReciboHonorariosDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReciboHonorariosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = idReciboHonorarios;
                    
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

        public ReciboHonorariosDetE ObtenerReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios, Int32 idReciboHonorariosDet)
        {        
            ReciboHonorariosDetE recibohonorariosdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerReciboHonorariosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = idReciboHonorarios;
                    oComando.Parameters.Add("@idReciboHonorariosDet", SqlDbType.Int).Value = idReciboHonorariosDet;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            recibohonorariosdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return recibohonorariosdet;
        }

        public ReciboHonorariosDetE CerrarReciboHonorariosDet(ReciboHonorariosDetE recibohonorariosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CerrarReciboHonorariosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = recibohonorariosdet.idEmpresa;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = recibohonorariosdet.idReciboHonorarios;
                    oComando.Parameters.Add("@idReciboHonorariosDet", SqlDbType.Int).Value = recibohonorariosdet.idReciboHonorariosDet;
                    oComando.Parameters.Add("@indVoucher", SqlDbType.Bit).Value = recibohonorariosdet.indVoucher;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar,4).Value = recibohonorariosdet.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = recibohonorariosdet.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = recibohonorariosdet.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = recibohonorariosdet.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = recibohonorariosdet.numFile;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar,20).Value = recibohonorariosdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return recibohonorariosdet;
        }

        public int ActualizarRHonorariosCtaCte(Int32 idReciboHonorariosDet, Int32? idCtaCte, Int32? idCtaCteItem, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRHonorariosCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idReciboHonorariosDet", SqlDbType.Int).Value = idReciboHonorariosDet;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}