using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class ProgramaPagoAD : DbConection
    {

        public ProgramaPagoE LlenarEntidad(IDataReader oReader)
        {
            ProgramaPagoE programapago = new ProgramaPagoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProgramaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idProgramaPago = oReader["idProgramaPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProgramaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.codTipoPago = oReader["codTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTipoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.codFormaPago = oReader["codFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFormaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idPersonaBanco = oReader["idPersonaBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaBanco"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idMonedaPago = oReader["idMonedaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.numCuenta = oReader["numCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCheque'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.numCheque = oReader["numCheque"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCheque"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBancoAuxliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.idBancoAuxliar = oReader["idBancoAuxliar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBancoAuxliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCtaAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.tipCtaAuxiliar = oReader["tipCtaAuxiliar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipCtaAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.idMonedaAuxiliar = oReader["idMonedaAuxiliar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCtaAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.numCtaAuxiliar = oReader["numCtaAuxiliar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCtaAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Grupo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.Grupo = oReader["Grupo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Grupo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecVencimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Aprobado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.Aprobado = oReader["Aprobado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Aprobado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idNumEgreso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.idNumEgreso = oReader["idNumEgreso"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idNumEgreso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBeneficiario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.desBeneficiario = oReader["desBeneficiario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBeneficiario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.MontoOrigen = oReader["MontoOrigen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.idDocumentoBanco = oReader["idDocumentoBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.SerieBanco = oReader["SerieBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumeroBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.NumeroBanco = oReader["NumeroBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumeroBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.idOrdenPago = oReader["idOrdenPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indComision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.indComision = oReader["indComision"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indComision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoCom'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.idConceptoCom = oReader["idConceptoCom"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoCom"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoCom'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.MontoCom = oReader["MontoCom"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoCom"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				programapago.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.desPartida = oReader["desPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.nomBanco = oReader["nomBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NemoFormaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.NemoFormaPago = oReader["NemoFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NemoFormaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAprobacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.desAprobacion = oReader["desAprobacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAprobacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.codOrdenPago = oReader["codOrdenPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NemoTipoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.NemoTipoPago = oReader["NemoTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NemoTipoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VieneDeOp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                programapago.VieneDeOp = oReader["VieneDeOp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["VieneDeOp"]);

            return  programapago;        
        }

        public ProgramaPagoE InsertarProgramaPago(ProgramaPagoE programapago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarProgramaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = programapago.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = programapago.idLocal;
					oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = programapago.Fecha;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = programapago.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = programapago.codCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = programapago.idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = programapago.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = programapago.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = programapago.numDocumento;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = programapago.codFormaPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = programapago.idConcepto;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = programapago.codTipoPago;
					oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = programapago.idPersonaBanco;
					oComando.Parameters.Add("@idMonedaPago", SqlDbType.VarChar, 2).Value = programapago.idMonedaPago;
					oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 30).Value = programapago.numCuenta;
					oComando.Parameters.Add("@numCheque", SqlDbType.VarChar, 50).Value = programapago.numCheque;
                    oComando.Parameters.Add("@idBancoAuxliar", SqlDbType.Int).Value = programapago.idBancoAuxliar;
                    oComando.Parameters.Add("@tipCtaAuxiliar", SqlDbType.Int).Value = programapago.tipCtaAuxiliar;
                    oComando.Parameters.Add("@idMonedaAuxiliar", SqlDbType.VarChar, 2).Value = programapago.idMonedaAuxiliar;
                    oComando.Parameters.Add("@numCtaAuxiliar", SqlDbType.VarChar, 30).Value = programapago.numCtaAuxiliar;
                    oComando.Parameters.Add("@Grupo", SqlDbType.VarChar, 2).Value = programapago.Grupo;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = programapago.Glosa;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = programapago.fecDocumento;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = programapago.TipoCambio;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = programapago.fecVencimiento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = programapago.idMoneda;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = programapago.indDebeHaber;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = programapago.Monto;
					oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = programapago.idNumEgreso;
					oComando.Parameters.Add("@desBeneficiario", SqlDbType.VarChar, 150).Value = programapago.desBeneficiario;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = programapago.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = programapago.numFile;
                    oComando.Parameters.Add("@MontoOrigen", SqlDbType.Decimal).Value = programapago.MontoOrigen;
                    oComando.Parameters.Add("@idDocumentoBanco", SqlDbType.VarChar, 2).Value = programapago.idDocumentoBanco;
                    oComando.Parameters.Add("@SerieBanco", SqlDbType.VarChar, 20).Value = programapago.SerieBanco;
                    oComando.Parameters.Add("@NumeroBanco", SqlDbType.VarChar, 20).Value = programapago.NumeroBanco;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = programapago.idOrdenPago;
                    oComando.Parameters.Add("@indComision", SqlDbType.Bit).Value = programapago.indComision;
                    oComando.Parameters.Add("@idConceptoCom", SqlDbType.Int).Value = programapago.idConceptoCom;
                    oComando.Parameters.Add("@MontoCom", SqlDbType.Decimal).Value = programapago.MontoCom;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = programapago.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = programapago.codPartidaPresu;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = programapago.UsuarioRegistro;					

                    oConexion.Open();
                    programapago.idProgramaPago = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return programapago;
        }
        
        public ProgramaPagoE ActualizarProgramaPago(ProgramaPagoE programapago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProgramaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = programapago.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = programapago.idLocal;
					oComando.Parameters.Add("@idProgramaPago", SqlDbType.Int).Value = programapago.idProgramaPago;
					oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = programapago.Fecha;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = programapago.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = programapago.codCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = programapago.idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = programapago.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = programapago.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = programapago.numDocumento;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = programapago.codFormaPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = programapago.idConcepto;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = programapago.codTipoPago;
					oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = programapago.idPersonaBanco;
					oComando.Parameters.Add("@idMonedaPago", SqlDbType.VarChar, 2).Value = programapago.idMonedaPago;
					oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 30).Value = programapago.numCuenta;
					oComando.Parameters.Add("@numCheque", SqlDbType.VarChar, 50).Value = programapago.numCheque;
                    oComando.Parameters.Add("@idBancoAuxliar", SqlDbType.Int).Value = programapago.idBancoAuxliar;
                    oComando.Parameters.Add("@tipCtaAuxiliar", SqlDbType.Int).Value = programapago.tipCtaAuxiliar;
                    oComando.Parameters.Add("@idMonedaAuxiliar", SqlDbType.VarChar, 2).Value = programapago.idMonedaAuxiliar;
                    oComando.Parameters.Add("@numCtaAuxiliar", SqlDbType.VarChar, 30).Value = programapago.numCtaAuxiliar;
                    oComando.Parameters.Add("@Grupo", SqlDbType.VarChar, 2).Value = programapago.Grupo;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = programapago.Glosa;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = programapago.fecDocumento;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = programapago.TipoCambio;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = programapago.fecVencimiento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = programapago.idMoneda;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = programapago.indDebeHaber;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = programapago.Monto;
					oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = programapago.idNumEgreso;
					oComando.Parameters.Add("@desBeneficiario", SqlDbType.VarChar, 150).Value = programapago.desBeneficiario;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = programapago.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = programapago.numFile;
                    oComando.Parameters.Add("@MontoOrigen", SqlDbType.Decimal).Value = programapago.MontoOrigen;
                    oComando.Parameters.Add("@idDocumentoBanco", SqlDbType.VarChar, 2).Value = programapago.idDocumentoBanco;
                    oComando.Parameters.Add("@SerieBanco", SqlDbType.VarChar, 20).Value = programapago.SerieBanco;
                    oComando.Parameters.Add("@NumeroBanco", SqlDbType.VarChar, 20).Value = programapago.NumeroBanco;
                    oComando.Parameters.Add("@indComision", SqlDbType.Bit).Value = programapago.indComision;
                    oComando.Parameters.Add("@idConceptoCom", SqlDbType.Int).Value = programapago.idConceptoCom;
                    oComando.Parameters.Add("@MontoCom", SqlDbType.Decimal).Value = programapago.MontoCom;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = programapago.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = programapago.codPartidaPresu;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = programapago.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return programapago;
        }        

        public Int32 EliminarProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarProgramaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idProgramaPago", SqlDbType.Int).Value = idProgramaPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ProgramaPagoE> ListarProgramaPagos(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Estado, String codFormaPago, Int32 idPersonaBanco, Int32 idPersona)
        {
            List<ProgramaPagoE> listaEntidad = new List<ProgramaPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProgramaPagos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = codFormaPago;
                    oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = idPersonaBanco;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

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
        
        public ProgramaPagoE ObtenerProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago)
        {        
            ProgramaPagoE programapago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProgramaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idProgramaPago", SqlDbType.Int).Value = idProgramaPago;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            programapago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return programapago;
        }

        public Int32 MaxGrupoProgramaPagos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime Fecha)
        {
            Int32 Maximo = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxGrupoProgramaPagos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha.Date;
                    //oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;

                    oConexion.Open();
                    Maximo = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return Maximo;
        }

        public List<ProgramaPagoE> ListarPagosParaAprobacion(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Aprobado)
        {
            List<ProgramaPagoE> listaEntidad = new List<ProgramaPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPagosParaAprobacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Aprobado", SqlDbType.Char, 1).Value = Aprobado;

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

        public ProgramaPagoE ActualizarProgramaPagoAprobacion(ProgramaPagoE programapago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProgramaPagoAprobacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = programapago.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = programapago.idLocal;
                    oComando.Parameters.Add("@idProgramaPago", SqlDbType.Int).Value = programapago.idProgramaPago;
                    oComando.Parameters.Add("@Aprobado", SqlDbType.Char, 1).Value = programapago.Aprobado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = programapago.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return programapago;
        }

        public void GenerarCheque(Int32 idEmpresa, Int32 idLocal, DateTime Fecha, Int32 idPersona, String Usuario, String Estado, String Grupo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarCheque", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha.Date;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@usuario", SqlDbType.VarChar, 20).Value = Usuario;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("Grupo", SqlDbType.VarChar, 2).Value = Grupo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<ProgramaPagoE> ListarProgramaPagoPorGrupo(Int32 idEmpresa, Int32 idLocal, DateTime Fecha, Int32 idPersona, String Grupo, String Estado)
        {
            List<ProgramaPagoE> listaEntidad = new List<ProgramaPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProgramaPagoPorGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("Grupo", SqlDbType.VarChar, 2).Value = Grupo;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;

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

        public ProgramaPagoE GenerarVoucherTesTransferencia(Int32 idEmpresa, Int32 idLocal, DateTime Fecha, Int32 idPersona, String Usuario, String Estado, String Grupo, String codTipoPago)
        {
            ProgramaPagoE programapago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarVoucherTesTransferencia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha.Date;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@usuario", SqlDbType.VarChar, 20).Value = Usuario;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@Grupo", SqlDbType.VarChar, 2).Value = Grupo;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;

                    oConexion.Open();
                    //Resp = oComando.ExecuteNonQuery();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            programapago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return programapago;
        }

        public Int32 ActualizarGrupoPP(Int32 idProgramaPago, String Grupo, String idDocumentoBanco, String SerieBanco, String NumeroBanco, String Glosa)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarGrupoPP", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idProgramaPago", SqlDbType.Int).Value = idProgramaPago;
                    oComando.Parameters.Add("@Grupo", SqlDbType.VarChar, 2).Value = Grupo;
                    oComando.Parameters.Add("@idDocumentoBanco", SqlDbType.VarChar, 2).Value = idDocumentoBanco;
                    oComando.Parameters.Add("@SerieBanco", SqlDbType.VarChar, 20).Value = SerieBanco;
                    oComando.Parameters.Add("@NumeroBanco", SqlDbType.VarChar, 20).Value = NumeroBanco;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = Glosa;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public Int32 ActualizarProgramaPagoEstado(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago, Int32 idNumEgreso, String Estado, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProgramaPagoEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProgramaPago", SqlDbType.Int).Value = idProgramaPago;
                    oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = idNumEgreso;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarPPagoEstadoPorGrupo(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String Grupo, Int32 idOrdenPago, DateTime Fecha, Int32 idNumEgreso, String Estado, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPPagoEstadoPorGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@Grupo", SqlDbType.VarChar, 2).Value = Grupo;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;
                    oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha.Date;
                    oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = idNumEgreso;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 LimpiarVoucherPP(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String Grupo, Int32 idNumEgreso, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LimpiarVoucherPP", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@Grupo", SqlDbType.VarChar, 2).Value = Grupo;
                    oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = idNumEgreso;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}