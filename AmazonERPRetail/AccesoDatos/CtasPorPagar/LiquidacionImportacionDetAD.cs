using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class LiquidacionImportacionDetAD : DbConection
    {

        public LiquidacionImportacionDetE LlenarEntidad(IDataReader oReader)
        {
            LiquidacionImportacionDetE liquidacionimportaciondet = new LiquidacionImportacionDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLiquidacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.idLiquidacion = oReader["idLiquidacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLiquidacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.idProvision = oReader["idProvision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.FechaDocumento = oReader["FechaDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDoc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.MontoDoc = oReader["MontoDoc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDoc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.idMonedaRec = oReader["idMonedaRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.MontoRec = oReader["MontoRec"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTicaAuto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.indTicaAuto = oReader["indTicaAuto"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indTicaAuto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SolesRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.SolesRec = oReader["SolesRec"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SolesRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DolaresRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.DolaresRec = oReader["DolaresRec"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["DolaresRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReparable'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.indReparable = oReader["indReparable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indReparable"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoRep'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.idConceptoRep = oReader["idConceptoRep"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoRep"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desReferenciaRep'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.desReferenciaRep = oReader["desReferenciaRep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desReferenciaRep"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportaciondet.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAutomatico'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.EsAutomatico = oReader["EsAutomatico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsAutomatico"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportaciondet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportaciondet.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMonedaRec'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportaciondet.desMonedaRec = oReader["desMonedaRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMonedaRec"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportaciondet.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportaciondet.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportaciondet.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportaciondet.desConcepto = oReader["desConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desConcepto"]);

            return  liquidacionimportaciondet;        
        }

        public LiquidacionImportacionDetE InsertarLiquidacionImportacionDet(LiquidacionImportacionDetE liquidacionimportaciondet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLiquidacionImportacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidacionimportaciondet.idLiquidacion;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = liquidacionimportaciondet.idProvision;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = liquidacionimportaciondet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = liquidacionimportaciondet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = liquidacionimportaciondet.numDocumento;
					oComando.Parameters.Add("@FechaDocumento", SqlDbType.SmallDateTime).Value = liquidacionimportaciondet.FechaDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = liquidacionimportaciondet.idMoneda;
					oComando.Parameters.Add("@MontoDoc", SqlDbType.Decimal).Value = liquidacionimportaciondet.MontoDoc;
					oComando.Parameters.Add("@idMonedaRec", SqlDbType.VarChar, 2).Value = liquidacionimportaciondet.idMonedaRec;
					oComando.Parameters.Add("@MontoRec", SqlDbType.Decimal).Value = liquidacionimportaciondet.MontoRec;
					oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = liquidacionimportaciondet.indTicaAuto;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = liquidacionimportaciondet.TipoCambio;
					oComando.Parameters.Add("@SolesRec", SqlDbType.Decimal).Value = liquidacionimportaciondet.SolesRec;
					oComando.Parameters.Add("@DolaresRec", SqlDbType.Decimal).Value = liquidacionimportaciondet.DolaresRec;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidacionimportaciondet.idPersona;
					oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = liquidacionimportaciondet.indReparable;
					oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = liquidacionimportaciondet.idConceptoRep;
					oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = liquidacionimportaciondet.desReferenciaRep;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = liquidacionimportaciondet.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = liquidacionimportaciondet.codCuenta;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = liquidacionimportaciondet.idConcepto;
                    oComando.Parameters.Add("@EsAutomatico", SqlDbType.Bit).Value = liquidacionimportaciondet.EsAutomatico;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = liquidacionimportaciondet.UsuarioRegistro;

                    oConexion.Open();
                    liquidacionimportaciondet.idItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return liquidacionimportaciondet;
        }
        
        public LiquidacionImportacionDetE ActualizarLiquidacionImportacionDet(LiquidacionImportacionDetE liquidacionimportaciondet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLiquidacionImportacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = liquidacionimportaciondet.idItem;
					oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidacionimportaciondet.idLiquidacion;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = liquidacionimportaciondet.idProvision;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = liquidacionimportaciondet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = liquidacionimportaciondet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = liquidacionimportaciondet.numDocumento;
					oComando.Parameters.Add("@FechaDocumento", SqlDbType.SmallDateTime).Value = liquidacionimportaciondet.FechaDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = liquidacionimportaciondet.idMoneda;
					oComando.Parameters.Add("@MontoDoc", SqlDbType.Decimal).Value = liquidacionimportaciondet.MontoDoc;
					oComando.Parameters.Add("@idMonedaRec", SqlDbType.VarChar, 2).Value = liquidacionimportaciondet.idMonedaRec;
					oComando.Parameters.Add("@MontoRec", SqlDbType.Decimal).Value = liquidacionimportaciondet.MontoRec;
					oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = liquidacionimportaciondet.indTicaAuto;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = liquidacionimportaciondet.TipoCambio;
					oComando.Parameters.Add("@SolesRec", SqlDbType.Decimal).Value = liquidacionimportaciondet.SolesRec;
					oComando.Parameters.Add("@DolaresRec", SqlDbType.Decimal).Value = liquidacionimportaciondet.DolaresRec;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidacionimportaciondet.idPersona;
					oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = liquidacionimportaciondet.indReparable;
					oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = liquidacionimportaciondet.idConceptoRep;
					oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = liquidacionimportaciondet.desReferenciaRep;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = liquidacionimportaciondet.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = liquidacionimportaciondet.codCuenta;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = liquidacionimportaciondet.idConcepto;
                    oComando.Parameters.Add("@EsAutomatico", SqlDbType.Bit).Value = liquidacionimportaciondet.EsAutomatico;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = liquidacionimportaciondet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return liquidacionimportaciondet;
        }        

        public int EliminarLiquidacionImportacionDet(Int32 idItem)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLiquidacionImportacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LiquidacionImportacionDetE> ListarLiquidacionImportacionDet(Int32 idLiquidacion)
        {
            List<LiquidacionImportacionDetE> listaEntidad = new List<LiquidacionImportacionDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLiquidacionImportacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;

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
        
        public LiquidacionImportacionDetE ObtenerLiquidacionImportacionDet(Int32 idItem)
        {        
            LiquidacionImportacionDetE liquidacionimportaciondet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLiquidacionImportacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidacionimportaciondet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return liquidacionimportaciondet;
        }

    }
}