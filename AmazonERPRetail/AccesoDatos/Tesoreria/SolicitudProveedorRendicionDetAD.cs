using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class SolicitudProveedorRendicionDetAD : DbConection
    {

        public SolicitudProveedorRendicionDetE LlenarEntidad(IDataReader oReader)
        {
            SolicitudProveedorRendicionDetE solicitudproveedorrendiciondet = new SolicitudProveedorRendicionDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRendicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.idRendicion = oReader["idRendicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRendicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDoc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.MontoDoc = oReader["MontoDoc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDoc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.idMonedaRec = oReader["idMonedaRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.MontoRec = oReader["MontoRec"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTicaAuto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.indTicaAuto = oReader["indTicaAuto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTicaAuto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SolesRecibidos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.SolesRecibidos = oReader["SolesRecibidos"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SolesRecibidos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DolaresRecibidos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.DolaresRecibidos = oReader["DolaresRecibidos"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["DolaresRecibidos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAuxiliar'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.idAuxiliar = oReader["idAuxiliar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAuxiliar"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReparable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.indReparable = oReader["indReparable"] == DBNull.Value ? "N" : Convert.ToString(oReader["indReparable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.idConceptoRep = oReader["idConceptoRep"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desReferenciaRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.desReferenciaRep = oReader["desReferenciaRep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desReferenciaRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAutomatico'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.EsAutomatico = oReader["EsAutomatico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsAutomatico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.idProvision = oReader["idProvision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProvision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indProvBusqueda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.indProvBusqueda = oReader["indProvBusqueda"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indProvBusqueda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indLiquiImpor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.indLiquiImpor = oReader["indLiquiImpor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indLiquiImpor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLiquiImpor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.idLiquiImpor = oReader["idLiquiImpor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLiquiImpor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteLiqui'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.idCtaCteLiqui = oReader["idCtaCteLiqui"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteLiqui"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItemLiqui'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.idCtaCteItemLiqui = oReader["idCtaCteItemLiqui"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItemLiqui"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendiciondet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSolicitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.codSolicitud = oReader["codSolicitud"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSolicitud"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMonedaRec'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.desMonedaRec = oReader["desMonedaRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMonedaRec"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.desConcepto = oReader["desConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDepositado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.MontoDepositado = oReader["MontoDepositado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDepositado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.ctaBanco = oReader["ctaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendiciondet.SaldoSol = oReader["SaldoSol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoSol"]);

            return  solicitudproveedorrendiciondet;        
        }

        public SolicitudProveedorRendicionDetE InsertarSolicitudProveedorRendicionDet(SolicitudProveedorRendicionDetE solicitudproveedorrendiciondet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarSolicitudProveedorRendicionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idRendicion;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = solicitudproveedorrendiciondet.Item;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = solicitudproveedorrendiciondet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = solicitudproveedorrendiciondet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = solicitudproveedorrendiciondet.numDocumento;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = solicitudproveedorrendiciondet.fecDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = solicitudproveedorrendiciondet.idMoneda;
					oComando.Parameters.Add("@MontoDoc", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.MontoDoc;
					oComando.Parameters.Add("@idMonedaRec", SqlDbType.VarChar, 2).Value = solicitudproveedorrendiciondet.idMonedaRec;
					oComando.Parameters.Add("@MontoRec", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.MontoRec;
					oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = solicitudproveedorrendiciondet.indTicaAuto;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.tipCambio;
					oComando.Parameters.Add("@SolesRecibidos", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.SolesRecibidos;
					oComando.Parameters.Add("@DolaresRecibidos", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.DolaresRecibidos;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = solicitudproveedorrendiciondet.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = solicitudproveedorrendiciondet.codCuenta;
					oComando.Parameters.Add("@idAuxiliar", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idAuxiliar;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idConcepto;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = solicitudproveedorrendiciondet.indReparable;
                    oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = solicitudproveedorrendiciondet.desReferenciaRep;
                    oComando.Parameters.Add("@EsAutomatico", SqlDbType.Bit).Value = solicitudproveedorrendiciondet.EsAutomatico;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idProvision;
                    oComando.Parameters.Add("@indProvBusqueda", SqlDbType.Bit).Value = solicitudproveedorrendiciondet.indProvBusqueda;
                    oComando.Parameters.Add("@indLiquiImpor", SqlDbType.Bit).Value = solicitudproveedorrendiciondet.indLiquiImpor;
                    oComando.Parameters.Add("@idLiquiImpor", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idLiquiImpor;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = solicitudproveedorrendiciondet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return solicitudproveedorrendiciondet;
        }
        
        public SolicitudProveedorRendicionDetE ActualizarSolicitudProveedorRendicionDet(SolicitudProveedorRendicionDetE solicitudproveedorrendiciondet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarSolicitudProveedorRendicionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idRendicion;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = solicitudproveedorrendiciondet.Item;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = solicitudproveedorrendiciondet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = solicitudproveedorrendiciondet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = solicitudproveedorrendiciondet.numDocumento;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = solicitudproveedorrendiciondet.fecDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = solicitudproveedorrendiciondet.idMoneda;
					oComando.Parameters.Add("@MontoDoc", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.MontoDoc;
					oComando.Parameters.Add("@idMonedaRec", SqlDbType.VarChar, 2).Value = solicitudproveedorrendiciondet.idMonedaRec;
					oComando.Parameters.Add("@MontoRec", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.MontoRec;
					oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = solicitudproveedorrendiciondet.indTicaAuto;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.tipCambio;
					oComando.Parameters.Add("@SolesRecibidos", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.SolesRecibidos;
					oComando.Parameters.Add("@DolaresRecibidos", SqlDbType.Decimal).Value = solicitudproveedorrendiciondet.DolaresRecibidos;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = solicitudproveedorrendiciondet.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = solicitudproveedorrendiciondet.codCuenta;
					oComando.Parameters.Add("@idAuxiliar", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idAuxiliar;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idConcepto;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = solicitudproveedorrendiciondet.indReparable;
                    oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = solicitudproveedorrendiciondet.desReferenciaRep;
                    oComando.Parameters.Add("@EsAutomatico", SqlDbType.Bit).Value = solicitudproveedorrendiciondet.EsAutomatico;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idProvision;
                    oComando.Parameters.Add("@indProvBusqueda", SqlDbType.Bit).Value = solicitudproveedorrendiciondet.indProvBusqueda;
                    oComando.Parameters.Add("@indLiquiImpor", SqlDbType.Bit).Value = solicitudproveedorrendiciondet.indLiquiImpor;
                    oComando.Parameters.Add("@idLiquiImpor", SqlDbType.Int).Value = solicitudproveedorrendiciondet.idLiquiImpor;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = solicitudproveedorrendiciondet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return solicitudproveedorrendiciondet;
        }        

        public int EliminarSolicitudProveedorRendicionDet(Int32 idRendicion, Int32 Item)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarSolicitudProveedorRendicionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<SolicitudProveedorRendicionDetE> ListarSolicitudProveedorRendicionDet(Int32 idRendicion)
        {
            List<SolicitudProveedorRendicionDetE> listaEntidad = new List<SolicitudProveedorRendicionDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSolicitudProveedorRendicionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;

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
        
        public SolicitudProveedorRendicionDetE ObtenerSolicitudProveedorRendicionDet(Int32 idRendicion, Int32 Item)
        {        
            SolicitudProveedorRendicionDetE solicitudproveedorrendiciondet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSolicitudProveedorRendicionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            solicitudproveedorrendiciondet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return solicitudproveedorrendiciondet;
        }

        public List<SolicitudProveedorRendicionDetE> RendicionImpresion(Int32 idRendicion)
        {
            List<SolicitudProveedorRendicionDetE> listaEntidad = new List<SolicitudProveedorRendicionDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RendicionImpresion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;

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

        public SolicitudProveedorRendicionDetE RendicionDetPorProvision(Int32 idProvision)
        {
            SolicitudProveedorRendicionDetE RendicionDet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RendicionDetPorProvision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            RendicionDet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return RendicionDet;
        }

        public List<SolicitudProveedorRendicionDetE> ProvRendicionDetPorLiquidacion(Int32 idLiquidacion)
        {
            List<SolicitudProveedorRendicionDetE> listaEntidad = new List<SolicitudProveedorRendicionDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProvRendicionDetPorLiquidacion", oConexion))
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

        public int ActualizarProvRendiDetCtaCteLiqui(SolicitudProveedorRendicionDetE RendicionDet, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProvRendiDetCtaCteLiqui", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = RendicionDet.idRendicion;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = RendicionDet.Item;
                    oComando.Parameters.Add("@idCtaCteLiqui", SqlDbType.Int).Value = RendicionDet.idCtaCteLiqui;
                    oComando.Parameters.Add("@idCtaCteItemLiqui", SqlDbType.Int).Value = RendicionDet.idCtaCteItemLiqui;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}