using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class LiquidacionDetAD : DbConection
    {

        public LiquidacionDetE LlenarEntidad(IDataReader oReader)
        {
            LiquidacionDetE liquidaciondet = new LiquidacionDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLiquidacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.idLiquidacion = oReader["idLiquidacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLiquidacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.tipoDocumento = oReader["tipoDocumento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipoDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.idProvision = oReader["idProvision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMovilidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.idMovilidad = oReader["idMovilidad"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMovilidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.FechaDocumento = oReader["FechaDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTicaAuto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.indTicaAuto = oReader["indTicaAuto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTicaAuto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoLiquidar'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.MontoLiquidar = oReader["MontoLiquidar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoLiquidar"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReparable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.indReparable = oReader["indReparable"] == DBNull.Value ? "N" : Convert.ToString(oReader["indReparable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.idConceptoRep = oReader["idConceptoRep"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desReferenciaRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.desReferenciaRep = oReader["desReferenciaRep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desReferenciaRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidaciondet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.DesCCostos = oReader["DesCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.desTipoDocumento = oReader["desTipoDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoLiqui'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.TipoLiqui = oReader["TipoLiqui"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoLiqui"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Concepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.Concepto = oReader["Concepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Concepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.impSoles = oReader["impSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.impDolares = oReader["impDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.desAuxiliar = oReader["desAuxiliar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Voucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.Voucher = oReader["Voucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Voucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VVentaSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.VVentaSoles = oReader["VVentaSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["VVentaSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.IgvSoles = oReader["IgvSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.TotalSoles = oReader["TotalSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VVentaDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.VVentaDolar = oReader["VVentaDolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["VVentaDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.IgvDolar = oReader["IgvDolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidaciondet.TotalDolar = oReader["TotalDolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalDolar"]);

            return  liquidaciondet;        
        }

        public LiquidacionDetE InsertarLiquidacionDet(LiquidacionDetE liquidaciondet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLiquidacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = liquidaciondet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = liquidaciondet.idLocal;
					oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidaciondet.idLiquidacion;
					oComando.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = liquidaciondet.tipoDocumento;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = liquidaciondet.idProvision;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = liquidaciondet.idMovilidad;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = liquidaciondet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 10).Value = liquidaciondet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = liquidaciondet.numDocumento;
					oComando.Parameters.Add("@FechaDocumento", SqlDbType.SmallDateTime).Value = liquidaciondet.FechaDocumento.Value.Date;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = liquidaciondet.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = liquidaciondet.Monto;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = liquidaciondet.indTicaAuto;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = liquidaciondet.TipoCambio;
					oComando.Parameters.Add("@MontoLiquidar", SqlDbType.Decimal).Value = liquidaciondet.MontoLiquidar;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = liquidaciondet.Glosa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = liquidaciondet.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = liquidaciondet.codCuenta;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = liquidaciondet.idConcepto;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = liquidaciondet.indReparable;
                    oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = liquidaciondet.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = liquidaciondet.desReferenciaRep;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidaciondet.idPersona;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = liquidaciondet.idCCostos;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = liquidaciondet.UsuarioRegistro;

                    oConexion.Open();
                    liquidaciondet.idItem = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return liquidaciondet;
        }
        
        public LiquidacionDetE ActualizarLiquidacionDet(LiquidacionDetE liquidaciondet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLiquidacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = liquidaciondet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = liquidaciondet.idLocal;
					oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidaciondet.idLiquidacion;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = liquidaciondet.idItem;
					oComando.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = liquidaciondet.tipoDocumento;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = liquidaciondet.idProvision;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = liquidaciondet.idMovilidad;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = liquidaciondet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 10).Value = liquidaciondet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = liquidaciondet.numDocumento;
					oComando.Parameters.Add("@FechaDocumento", SqlDbType.SmallDateTime).Value = liquidaciondet.FechaDocumento.Value.Date;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = liquidaciondet.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = liquidaciondet.Monto;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = liquidaciondet.indTicaAuto;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = liquidaciondet.TipoCambio;
					oComando.Parameters.Add("@MontoLiquidar", SqlDbType.Decimal).Value = liquidaciondet.MontoLiquidar;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = liquidaciondet.Glosa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = liquidaciondet.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = liquidaciondet.codCuenta;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = liquidaciondet.idConcepto;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = liquidaciondet.indReparable;
                    oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = liquidaciondet.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = liquidaciondet.desReferenciaRep;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidaciondet.idPersona;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = liquidaciondet.idCCostos;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = liquidaciondet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return liquidaciondet;
        }        

        public int EliminarLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion, Int32 idItem)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLiquidacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LiquidacionDetE> ListarLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion)
        {
            List<LiquidacionDetE> listaEntidad = new List<LiquidacionDetE>();
            LiquidacionDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLiquidacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;

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
        
        public LiquidacionDetE ObtenerLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion, Int32 idItem)
        {        
            LiquidacionDetE liquidaciondet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLiquidacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidaciondet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return liquidaciondet;
        }

        public List<LiquidacionDetE> LiquidacionRendicionCaja(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Tipo)
        {
            List<LiquidacionDetE> listaEntidad = new List<LiquidacionDetE>();
            LiquidacionDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LiquidacionRendicionCaja", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char).Value = Tipo;

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

        public LiquidacionDetE LiquidacionDetPorDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            LiquidacionDetE liquidaciondet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LiquidacionDetPorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidaciondet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return liquidaciondet;
        }

        public LiquidacionDetE ObtenerLiquidacionDetPorIdProvision(Int32 idProvision)
        {
            LiquidacionDetE liquidaciondet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLiquidacionDetPorIdProvision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidaciondet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return liquidaciondet;
        }

        public List<LiquidacionDetE> LiquidacionDetPorTipoDoc(Int32 idLiquidacion, Int32 tipoDocumento)
        {
            List<LiquidacionDetE> listaEntidad = new List<LiquidacionDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LiquidacionDetPorTipoDoc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
                    oComando.Parameters.Add("@tipoDocumento", SqlDbType.Int).Value = tipoDocumento;

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