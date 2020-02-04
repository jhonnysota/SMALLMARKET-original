using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class RegistroCompras2AD : DbConection
    {

        public RegistroCompras2E LlenarEntidad(IDataReader oReader)
        {
            RegistroCompras2E registrocompras = new RegistroCompras2E();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRegCompras'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.idRegCompras = oReader["idRegCompras"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRegCompras"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.indVoucher = oReader["indVoucher"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indHojaCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.indHojaCosto = oReader["indHojaCosto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indHojaCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idHojaCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.idHojaCosto = oReader["idHojaCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idHojaCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaBen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.idPersonaBen = oReader["idPersonaBen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaBen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Periodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.Periodo = oReader["Periodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Periodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correlativo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.Correlativo = oReader["Correlativo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correlativo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmisDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.fecEmisDocumento = oReader["fecEmisDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmisDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecVencimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocumentoVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.tipDocumentoVenta = oReader["tipDocumentoVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocumentoVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorAdquisicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.ValorAdquisicion = oReader["ValorAdquisicion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorAdquisicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='OtrosConceptos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.OtrosConceptos = oReader["OtrosConceptos"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["OtrosConceptos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalAdquisiciones'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.TotalAdquisiciones = oReader["TotalAdquisiciones"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalAdquisiciones"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocCreditoFiscal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.tipDocCreditoFiscal = oReader["tipDocCreditoFiscal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocCreditoFiscal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serCreditoFiscal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.serCreditoFiscal = oReader["serCreditoFiscal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serCreditoFiscal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioDua'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.AnioDua = oReader["AnioDua"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioDua"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCreditoFiscal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.numCreditoFiscal = oReader["numCreditoFiscal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCreditoFiscal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoIgvRet'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.MontoIgvRet = oReader["MontoIgvRet"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoIgvRet"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTicaAuto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.indTicaAuto = oReader["indTicaAuto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTicaAuto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PaidResidencia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.PaidResidencia = oReader["PaidResidencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PaidResidencia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.tipDocPersona = oReader["tipDocPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseGravado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.BaseGravado = oReader["BaseGravado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseGravado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvGrabado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.IgvGrabado = oReader["IgvGrabado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvGrabado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseGravadoNoGravado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.BaseGravadoNoGravado = oReader["BaseGravadoNoGravado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseGravadoNoGravado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvGravadoNoGravado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.IgvGravadoNoGravado = oReader["IgvGravadoNoGravado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvGravadoNoGravado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseSinDerecho'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.BaseSinDerecho = oReader["BaseSinDerecho"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseSinDerecho"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvSinDerecho'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.IgvSinDerecho = oReader["IgvSinDerecho"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvSinDerecho"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseNoGravado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.BaseNoGravado = oReader["BaseNoGravado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseNoGravado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ISC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.ISC = oReader["ISC"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ISC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.fecDocumentoRef = oReader["fecDocumentoRef"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.serDocumentoRef = oReader["serDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.numDetraccion = oReader["numDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDetraccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.fecDetraccion = oReader["fecDetraccion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDetraccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagRetencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.flagRetencion = oReader["flagRetencion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flagRetencion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ClasificacionBienServ'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.ClasificacionBienServ = oReader["ClasificacionBienServ"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ClasificacionBienServ"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PaisBeneficiario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.PaisBeneficiario = oReader["PaisBeneficiario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PaisBeneficiario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Vinculo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.Vinculo = oReader["Vinculo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Vinculo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RentaBruta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.RentaBruta = oReader["RentaBruta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RentaBruta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EnajenacionBienes'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.EnajenacionBienes = oReader["EnajenacionBienes"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["EnajenacionBienes"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RentaNeta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.RentaNeta = oReader["RentaNeta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RentaNeta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaRetencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.TasaRetencion = oReader["TasaRetencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaRetencion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpuestoRetenido'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.ImpuestoRetenido = oReader["ImpuestoRetenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpuestoRetenido"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ConvenioDobImpo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.ConvenioDobImpo = oReader["ConvenioDobImpo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ConvenioDobImpo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ExoneracionApli'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.ExoneracionApli = oReader["ExoneracionApli"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ExoneracionApli"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoRenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.TipoRenta = oReader["TipoRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoRenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ModalidadServicio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.ModalidadServicio = oReader["ModalidadServicio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ModalidadServicio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LeyImpuestoRenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.LeyImpuestoRenta = oReader["LeyImpuestoRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LeyImpuestoRenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.TipoCompra = oReader["TipoCompra"] == DBNull.Value ? 1 : Convert.ToInt32(oReader["TipoCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registrocompras.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numIdentificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.numIdentificacion = oReader["numIdentificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numIdentificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numIdentiBenef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.numIdentiBenef = oReader["numIdentiBenef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numIdentiBenef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonBeneficiario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registrocompras.RazonBeneficiario = oReader["RazonBeneficiario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonBeneficiario"]);

            return  registrocompras;        
        }

        public RegistroCompras2E InsertarRegistroCompras(RegistroCompras2E registrocompras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRegistroCompras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = registrocompras.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = registrocompras.idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = registrocompras.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = registrocompras.MesPeriodo;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = registrocompras.fecOperacion;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = registrocompras.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = registrocompras.numFile;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = registrocompras.numVoucher;
                    oComando.Parameters.Add("@indVoucher", SqlDbType.Bit).Value = registrocompras.indVoucher;
                    oComando.Parameters.Add("@indHojaCosto", SqlDbType.Bit).Value = registrocompras.indHojaCosto;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = registrocompras.idHojaCosto;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 500).Value = registrocompras.Glosa;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = registrocompras.codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = registrocompras.idPersona;
                    oComando.Parameters.Add("@idPersonaBen", SqlDbType.Int).Value = registrocompras.idPersonaBen;
                    oComando.Parameters.Add("@Periodo", SqlDbType.VarChar, 8).Value = registrocompras.Periodo;
					oComando.Parameters.Add("@Correlativo", SqlDbType.VarChar, 10).Value = registrocompras.Correlativo;
					oComando.Parameters.Add("@fecEmisDocumento", SqlDbType.SmallDateTime).Value = registrocompras.fecEmisDocumento;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = registrocompras.fecVencimiento;
					oComando.Parameters.Add("@tipDocumentoVenta", SqlDbType.VarChar, 2).Value = registrocompras.tipDocumentoVenta;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = registrocompras.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = registrocompras.numDocumento;
					oComando.Parameters.Add("@ValorAdquisicion", SqlDbType.Decimal).Value = registrocompras.ValorAdquisicion;
					oComando.Parameters.Add("@OtrosConceptos", SqlDbType.Decimal).Value = registrocompras.OtrosConceptos;
					oComando.Parameters.Add("@TotalAdquisiciones", SqlDbType.Decimal).Value = registrocompras.TotalAdquisiciones;
					oComando.Parameters.Add("@tipDocCreditoFiscal", SqlDbType.VarChar, 2).Value = registrocompras.tipDocCreditoFiscal;
					oComando.Parameters.Add("@serCreditoFiscal", SqlDbType.VarChar, 5).Value = registrocompras.serCreditoFiscal;
					oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 4).Value = registrocompras.AnioDua;
					oComando.Parameters.Add("@numCreditoFiscal", SqlDbType.VarChar, 5).Value = registrocompras.numCreditoFiscal;
					oComando.Parameters.Add("@MontoIgvRet", SqlDbType.Decimal).Value = registrocompras.MontoIgvRet;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = registrocompras.idMoneda;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = registrocompras.indTicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = registrocompras.tipCambio;
					oComando.Parameters.Add("@PaidResidencia", SqlDbType.VarChar, 4).Value = registrocompras.PaidResidencia;
					oComando.Parameters.Add("@tipDocPersona", SqlDbType.VarChar, 1).Value = registrocompras.tipDocPersona;
					//oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = registrocompras.RazonSocial;
					//oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = registrocompras.Direccion;
					//oComando.Parameters.Add("@numIdentificacion", SqlDbType.VarChar, 15).Value = registrocompras.numIdentificacion;
					oComando.Parameters.Add("@BaseGravado", SqlDbType.Decimal).Value = registrocompras.BaseGravado;
					oComando.Parameters.Add("@IgvGrabado", SqlDbType.Decimal).Value = registrocompras.IgvGrabado;
					oComando.Parameters.Add("@BaseGravadoNoGravado", SqlDbType.Decimal).Value = registrocompras.BaseGravadoNoGravado;
					oComando.Parameters.Add("@IgvGravadoNoGravado", SqlDbType.Decimal).Value = registrocompras.IgvGravadoNoGravado;
					oComando.Parameters.Add("@BaseSinDerecho", SqlDbType.Decimal).Value = registrocompras.BaseSinDerecho;
					oComando.Parameters.Add("@IgvSinDerecho", SqlDbType.Decimal).Value = registrocompras.IgvSinDerecho;
					oComando.Parameters.Add("@BaseNoGravado", SqlDbType.Decimal).Value = registrocompras.BaseNoGravado;
					oComando.Parameters.Add("@ISC", SqlDbType.Decimal).Value = registrocompras.ISC;
					oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = registrocompras.fecDocumentoRef;
					oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = registrocompras.idDocumentoRef;
					oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = registrocompras.serDocumentoRef;
					oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = registrocompras.numDocumentoRef;
					oComando.Parameters.Add("@numDetraccion", SqlDbType.VarChar, 24).Value = registrocompras.numDetraccion;
					oComando.Parameters.Add("@fecDetraccion", SqlDbType.SmallDateTime).Value = registrocompras.fecDetraccion;
					oComando.Parameters.Add("@flagRetencion", SqlDbType.Bit).Value = registrocompras.flagRetencion;
					oComando.Parameters.Add("@ClasificacionBienServ", SqlDbType.VarChar, 2).Value = registrocompras.ClasificacionBienServ;
					//oComando.Parameters.Add("@numIdentiBenef", SqlDbType.VarChar, 15).Value = registrocompras.numIdentiBenef;
					//oComando.Parameters.Add("@RazonBeneficiario", SqlDbType.VarChar, 100).Value = registrocompras.RazonBeneficiario;
					oComando.Parameters.Add("@PaisBeneficiario", SqlDbType.VarChar, 4).Value = registrocompras.PaisBeneficiario;
					oComando.Parameters.Add("@Vinculo", SqlDbType.VarChar, 2).Value = registrocompras.Vinculo;
					oComando.Parameters.Add("@RentaBruta", SqlDbType.Decimal).Value = registrocompras.RentaBruta;
					oComando.Parameters.Add("@EnajenacionBienes", SqlDbType.Decimal).Value = registrocompras.EnajenacionBienes;
					oComando.Parameters.Add("@RentaNeta", SqlDbType.Decimal).Value = registrocompras.RentaNeta;
					oComando.Parameters.Add("@TasaRetencion", SqlDbType.Decimal).Value = registrocompras.TasaRetencion;
					oComando.Parameters.Add("@ImpuestoRetenido", SqlDbType.Decimal).Value = registrocompras.ImpuestoRetenido;
					oComando.Parameters.Add("@ConvenioDobImpo", SqlDbType.VarChar, 2).Value = registrocompras.ConvenioDobImpo;
					oComando.Parameters.Add("@ExoneracionApli", SqlDbType.VarChar, 2).Value = registrocompras.ExoneracionApli;
					oComando.Parameters.Add("@TipoRenta", SqlDbType.VarChar, 2).Value = registrocompras.TipoRenta;
					oComando.Parameters.Add("@ModalidadServicio", SqlDbType.VarChar, 2).Value = registrocompras.ModalidadServicio;
					oComando.Parameters.Add("@LeyImpuestoRenta", SqlDbType.VarChar, 1).Value = registrocompras.LeyImpuestoRenta;
					oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = registrocompras.Estado;
					oComando.Parameters.Add("@TipoCompra", SqlDbType.Int).Value = registrocompras.TipoCompra;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = registrocompras.UsuarioRegistro;

                    oConexion.Open();
                    registrocompras.idRegCompras = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return registrocompras;
        }
        
        public RegistroCompras2E ActualizarRegistroCompras(RegistroCompras2E registrocompras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRegistroCompras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRegCompras", SqlDbType.Int).Value = registrocompras.idRegCompras;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = registrocompras.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = registrocompras.idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = registrocompras.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = registrocompras.MesPeriodo;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = registrocompras.fecOperacion;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = registrocompras.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = registrocompras.numFile;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = registrocompras.numVoucher;
                    oComando.Parameters.Add("@indVoucher", SqlDbType.Bit).Value = registrocompras.indVoucher;
                    oComando.Parameters.Add("@indHojaCosto", SqlDbType.Bit).Value = registrocompras.indHojaCosto;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = registrocompras.idHojaCosto;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 500).Value = registrocompras.Glosa;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = registrocompras.codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = registrocompras.idPersona;
                    oComando.Parameters.Add("@idPersonaBen", SqlDbType.Int).Value = registrocompras.idPersonaBen;
                    oComando.Parameters.Add("@Periodo", SqlDbType.VarChar, 8).Value = registrocompras.Periodo;
					oComando.Parameters.Add("@Correlativo", SqlDbType.VarChar, 10).Value = registrocompras.Correlativo;
					oComando.Parameters.Add("@fecEmisDocumento", SqlDbType.SmallDateTime).Value = registrocompras.fecEmisDocumento;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = registrocompras.fecVencimiento;
					oComando.Parameters.Add("@tipDocumentoVenta", SqlDbType.VarChar, 2).Value = registrocompras.tipDocumentoVenta;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = registrocompras.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = registrocompras.numDocumento;
					oComando.Parameters.Add("@ValorAdquisicion", SqlDbType.Decimal).Value = registrocompras.ValorAdquisicion;
					oComando.Parameters.Add("@OtrosConceptos", SqlDbType.Decimal).Value = registrocompras.OtrosConceptos;
					oComando.Parameters.Add("@TotalAdquisiciones", SqlDbType.Decimal).Value = registrocompras.TotalAdquisiciones;
					oComando.Parameters.Add("@tipDocCreditoFiscal", SqlDbType.VarChar, 2).Value = registrocompras.tipDocCreditoFiscal;
					oComando.Parameters.Add("@serCreditoFiscal", SqlDbType.VarChar, 5).Value = registrocompras.serCreditoFiscal;
					oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 4).Value = registrocompras.AnioDua;
					oComando.Parameters.Add("@numCreditoFiscal", SqlDbType.VarChar, 5).Value = registrocompras.numCreditoFiscal;
					oComando.Parameters.Add("@MontoIgvRet", SqlDbType.Decimal).Value = registrocompras.MontoIgvRet;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = registrocompras.idMoneda;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = registrocompras.indTicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = registrocompras.tipCambio;
					oComando.Parameters.Add("@PaidResidencia", SqlDbType.VarChar, 4).Value = registrocompras.PaidResidencia;
					oComando.Parameters.Add("@tipDocPersona", SqlDbType.VarChar, 1).Value = registrocompras.tipDocPersona;
					//oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = registrocompras.RazonSocial;
					//oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = registrocompras.Direccion;
					//oComando.Parameters.Add("@numIdentificacion", SqlDbType.VarChar, 15).Value = registrocompras.numIdentificacion;
					oComando.Parameters.Add("@BaseGravado", SqlDbType.Decimal).Value = registrocompras.BaseGravado;
					oComando.Parameters.Add("@IgvGrabado", SqlDbType.Decimal).Value = registrocompras.IgvGrabado;
					oComando.Parameters.Add("@BaseGravadoNoGravado", SqlDbType.Decimal).Value = registrocompras.BaseGravadoNoGravado;
					oComando.Parameters.Add("@IgvGravadoNoGravado", SqlDbType.Decimal).Value = registrocompras.IgvGravadoNoGravado;
					oComando.Parameters.Add("@BaseSinDerecho", SqlDbType.Decimal).Value = registrocompras.BaseSinDerecho;
					oComando.Parameters.Add("@IgvSinDerecho", SqlDbType.Decimal).Value = registrocompras.IgvSinDerecho;
					oComando.Parameters.Add("@BaseNoGravado", SqlDbType.Decimal).Value = registrocompras.BaseNoGravado;
					oComando.Parameters.Add("@ISC", SqlDbType.Decimal).Value = registrocompras.ISC;
					oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = registrocompras.fecDocumentoRef;
					oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = registrocompras.idDocumentoRef;
					oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = registrocompras.serDocumentoRef;
					oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = registrocompras.numDocumentoRef;
					oComando.Parameters.Add("@numDetraccion", SqlDbType.VarChar, 24).Value = registrocompras.numDetraccion;
					oComando.Parameters.Add("@fecDetraccion", SqlDbType.SmallDateTime).Value = registrocompras.fecDetraccion;
					oComando.Parameters.Add("@flagRetencion", SqlDbType.Bit).Value = registrocompras.flagRetencion;
					oComando.Parameters.Add("@ClasificacionBienServ", SqlDbType.VarChar, 2).Value = registrocompras.ClasificacionBienServ;
					//oComando.Parameters.Add("@numIdentiBenef", SqlDbType.VarChar, 15).Value = registrocompras.numIdentiBenef;
					//oComando.Parameters.Add("@RazonBeneficiario", SqlDbType.VarChar, 100).Value = registrocompras.RazonBeneficiario;
					oComando.Parameters.Add("@PaisBeneficiario", SqlDbType.VarChar, 4).Value = registrocompras.PaisBeneficiario;
					oComando.Parameters.Add("@Vinculo", SqlDbType.VarChar, 2).Value = registrocompras.Vinculo;
					oComando.Parameters.Add("@RentaBruta", SqlDbType.Decimal).Value = registrocompras.RentaBruta;
					oComando.Parameters.Add("@EnajenacionBienes", SqlDbType.Decimal).Value = registrocompras.EnajenacionBienes;
					oComando.Parameters.Add("@RentaNeta", SqlDbType.Decimal).Value = registrocompras.RentaNeta;
					oComando.Parameters.Add("@TasaRetencion", SqlDbType.Decimal).Value = registrocompras.TasaRetencion;
					oComando.Parameters.Add("@ImpuestoRetenido", SqlDbType.Decimal).Value = registrocompras.ImpuestoRetenido;
					oComando.Parameters.Add("@ConvenioDobImpo", SqlDbType.VarChar, 2).Value = registrocompras.ConvenioDobImpo;
					oComando.Parameters.Add("@ExoneracionApli", SqlDbType.VarChar, 2).Value = registrocompras.ExoneracionApli;
					oComando.Parameters.Add("@TipoRenta", SqlDbType.VarChar, 2).Value = registrocompras.TipoRenta;
					oComando.Parameters.Add("@ModalidadServicio", SqlDbType.VarChar, 2).Value = registrocompras.ModalidadServicio;
					oComando.Parameters.Add("@LeyImpuestoRenta", SqlDbType.VarChar, 1).Value = registrocompras.LeyImpuestoRenta;
					oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = registrocompras.Estado;
					oComando.Parameters.Add("@TipoCompra", SqlDbType.Int).Value = registrocompras.TipoCompra;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = registrocompras.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return registrocompras;
        }

        public RegistroCompras2E InsertarRegistroComprasNoDom(RegistroCompras2E registrocompras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRegistroComprasNoDom", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = registrocompras.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = registrocompras.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = registrocompras.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = registrocompras.MesPeriodo;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = registrocompras.fecOperacion;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = registrocompras.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = registrocompras.numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = registrocompras.numVoucher;
                    oComando.Parameters.Add("@indVoucher", SqlDbType.Bit).Value = registrocompras.indVoucher;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = registrocompras.idHojaCosto;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 500).Value = registrocompras.Glosa;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = registrocompras.codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = registrocompras.idPersona;
                    oComando.Parameters.Add("@idPersonaBen", SqlDbType.Int).Value = registrocompras.idPersonaBen;
                    oComando.Parameters.Add("@Periodo", SqlDbType.VarChar, 8).Value = registrocompras.Periodo;
                    oComando.Parameters.Add("@Correlativo", SqlDbType.VarChar, 10).Value = registrocompras.Correlativo;
                    oComando.Parameters.Add("@fecEmisDocumento", SqlDbType.SmallDateTime).Value = registrocompras.fecEmisDocumento;
                    oComando.Parameters.Add("@tipDocumentoVenta", SqlDbType.VarChar, 2).Value = registrocompras.tipDocumentoVenta;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = registrocompras.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = registrocompras.numDocumento;
                    oComando.Parameters.Add("@ValorAdquisicion", SqlDbType.Decimal).Value = registrocompras.ValorAdquisicion;
                    oComando.Parameters.Add("@OtrosConceptos", SqlDbType.Decimal).Value = registrocompras.OtrosConceptos;
                    oComando.Parameters.Add("@TotalAdquisiciones", SqlDbType.Decimal).Value = registrocompras.TotalAdquisiciones;
                    oComando.Parameters.Add("@tipDocCreditoFiscal", SqlDbType.VarChar, 2).Value = registrocompras.tipDocCreditoFiscal;
                    oComando.Parameters.Add("@serCreditoFiscal", SqlDbType.VarChar, 5).Value = registrocompras.serCreditoFiscal;
                    oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 4).Value = registrocompras.AnioDua;
                    oComando.Parameters.Add("@numCreditoFiscal", SqlDbType.VarChar, 5).Value = registrocompras.numCreditoFiscal;
                    oComando.Parameters.Add("@MontoIgvRet", SqlDbType.Decimal).Value = registrocompras.MontoIgvRet;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = registrocompras.idMoneda;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = registrocompras.indTicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = registrocompras.tipCambio;
                    oComando.Parameters.Add("@PaidResidencia", SqlDbType.VarChar, 4).Value = registrocompras.PaidResidencia;
                    //oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = registrocompras.RazonSocial;
                    //oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = registrocompras.Direccion;
                    //oComando.Parameters.Add("@numIdentificacion", SqlDbType.VarChar, 15).Value = registrocompras.numIdentificacion;
                    //oComando.Parameters.Add("@numIdentiBenef", SqlDbType.VarChar, 15).Value = registrocompras.numIdentiBenef;
                    //oComando.Parameters.Add("@RazonBeneficiario", SqlDbType.VarChar, 100).Value = registrocompras.RazonBeneficiario;
                    oComando.Parameters.Add("@PaisBeneficiario", SqlDbType.VarChar, 4).Value = registrocompras.PaisBeneficiario;
                    oComando.Parameters.Add("@Vinculo", SqlDbType.VarChar, 2).Value = registrocompras.Vinculo;
                    oComando.Parameters.Add("@RentaBruta", SqlDbType.Decimal).Value = registrocompras.RentaBruta;
                    oComando.Parameters.Add("@EnajenacionBienes", SqlDbType.Decimal).Value = registrocompras.EnajenacionBienes;
                    oComando.Parameters.Add("@RentaNeta", SqlDbType.Decimal).Value = registrocompras.RentaNeta;
                    oComando.Parameters.Add("@TasaRetencion", SqlDbType.Decimal).Value = registrocompras.TasaRetencion;
                    oComando.Parameters.Add("@ImpuestoRetenido", SqlDbType.Decimal).Value = registrocompras.ImpuestoRetenido;
                    oComando.Parameters.Add("@ConvenioDobImpo", SqlDbType.VarChar, 2).Value = registrocompras.ConvenioDobImpo;
                    oComando.Parameters.Add("@ExoneracionApli", SqlDbType.VarChar, 2).Value = registrocompras.ExoneracionApli;
                    oComando.Parameters.Add("@TipoRenta", SqlDbType.VarChar, 2).Value = registrocompras.TipoRenta;
                    oComando.Parameters.Add("@ModalidadServicio", SqlDbType.VarChar, 2).Value = registrocompras.ModalidadServicio;
                    oComando.Parameters.Add("@LeyImpuestoRenta", SqlDbType.VarChar, 1).Value = registrocompras.LeyImpuestoRenta;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = registrocompras.Estado;
                    oComando.Parameters.Add("@TipoCompra", SqlDbType.Int).Value = registrocompras.TipoCompra;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = registrocompras.UsuarioRegistro;

                    oConexion.Open();
                    registrocompras.idRegCompras = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return registrocompras;
        }

        public RegistroCompras2E ActualizarRegistroComprasNoDom(RegistroCompras2E registrocompras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRegistroComprasNoDom", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRegCompras", SqlDbType.Int).Value = registrocompras.idRegCompras;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = registrocompras.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = registrocompras.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = registrocompras.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = registrocompras.MesPeriodo;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = registrocompras.fecOperacion;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = registrocompras.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = registrocompras.numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = registrocompras.numVoucher;
                    oComando.Parameters.Add("@indVoucher", SqlDbType.Bit).Value = registrocompras.indVoucher;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = registrocompras.idHojaCosto;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 500).Value = registrocompras.Glosa;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = registrocompras.codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = registrocompras.idPersona;
                    oComando.Parameters.Add("@idPersonaBen", SqlDbType.Int).Value = registrocompras.idPersonaBen;
                    oComando.Parameters.Add("@Periodo", SqlDbType.VarChar, 8).Value = registrocompras.Periodo;
                    oComando.Parameters.Add("@Correlativo", SqlDbType.VarChar, 10).Value = registrocompras.Correlativo;
                    oComando.Parameters.Add("@fecEmisDocumento", SqlDbType.SmallDateTime).Value = registrocompras.fecEmisDocumento;
                    oComando.Parameters.Add("@tipDocumentoVenta", SqlDbType.VarChar, 2).Value = registrocompras.tipDocumentoVenta;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = registrocompras.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = registrocompras.numDocumento;
                    oComando.Parameters.Add("@ValorAdquisicion", SqlDbType.Decimal).Value = registrocompras.ValorAdquisicion;
                    oComando.Parameters.Add("@OtrosConceptos", SqlDbType.Decimal).Value = registrocompras.OtrosConceptos;
                    oComando.Parameters.Add("@TotalAdquisiciones", SqlDbType.Decimal).Value = registrocompras.TotalAdquisiciones;
                    oComando.Parameters.Add("@tipDocCreditoFiscal", SqlDbType.VarChar, 2).Value = registrocompras.tipDocCreditoFiscal;
                    oComando.Parameters.Add("@serCreditoFiscal", SqlDbType.VarChar, 5).Value = registrocompras.serCreditoFiscal;
                    oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 4).Value = registrocompras.AnioDua;
                    oComando.Parameters.Add("@numCreditoFiscal", SqlDbType.VarChar, 5).Value = registrocompras.numCreditoFiscal;
                    oComando.Parameters.Add("@MontoIgvRet", SqlDbType.Decimal).Value = registrocompras.MontoIgvRet;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = registrocompras.idMoneda;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = registrocompras.indTicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = registrocompras.tipCambio;
                    oComando.Parameters.Add("@PaidResidencia", SqlDbType.VarChar, 4).Value = registrocompras.PaidResidencia;
                    //oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = registrocompras.RazonSocial;
                    //oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = registrocompras.Direccion;
                    //oComando.Parameters.Add("@numIdentificacion", SqlDbType.VarChar, 15).Value = registrocompras.numIdentificacion;
                    //oComando.Parameters.Add("@numIdentiBenef", SqlDbType.VarChar, 15).Value = registrocompras.numIdentiBenef;
                    //oComando.Parameters.Add("@RazonBeneficiario", SqlDbType.VarChar, 100).Value = registrocompras.RazonBeneficiario;
                    oComando.Parameters.Add("@PaisBeneficiario", SqlDbType.VarChar, 4).Value = registrocompras.PaisBeneficiario;
                    oComando.Parameters.Add("@Vinculo", SqlDbType.VarChar, 2).Value = registrocompras.Vinculo;
                    oComando.Parameters.Add("@RentaBruta", SqlDbType.Decimal).Value = registrocompras.RentaBruta;
                    oComando.Parameters.Add("@EnajenacionBienes", SqlDbType.Decimal).Value = registrocompras.EnajenacionBienes;
                    oComando.Parameters.Add("@RentaNeta", SqlDbType.Decimal).Value = registrocompras.RentaNeta;
                    oComando.Parameters.Add("@TasaRetencion", SqlDbType.Decimal).Value = registrocompras.TasaRetencion;
                    oComando.Parameters.Add("@ImpuestoRetenido", SqlDbType.Decimal).Value = registrocompras.ImpuestoRetenido;
                    oComando.Parameters.Add("@ConvenioDobImpo", SqlDbType.VarChar, 2).Value = registrocompras.ConvenioDobImpo;
                    oComando.Parameters.Add("@ExoneracionApli", SqlDbType.VarChar, 2).Value = registrocompras.ExoneracionApli;
                    oComando.Parameters.Add("@TipoRenta", SqlDbType.VarChar, 2).Value = registrocompras.TipoRenta;
                    oComando.Parameters.Add("@ModalidadServicio", SqlDbType.VarChar, 2).Value = registrocompras.ModalidadServicio;
                    oComando.Parameters.Add("@LeyImpuestoRenta", SqlDbType.VarChar, 1).Value = registrocompras.LeyImpuestoRenta;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = registrocompras.Estado;
                    oComando.Parameters.Add("@TipoCompra", SqlDbType.Int).Value = registrocompras.TipoCompra;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = registrocompras.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return registrocompras;
        }

        public int EliminarRegistroCompras(Int32 idRegCompras)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRegistroCompras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRegCompras", SqlDbType.Int).Value = idRegCompras;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RegistroCompras2E> ListarRegistroCompras(int idEmpresa, int idLocal, Int32 TipoCompra, DateTime fecIni, DateTime fecFin)
        {
           List<RegistroCompras2E> listaEntidad = new List<RegistroCompras2E>();
           RegistroCompras2E entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRegistroCompras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoCompra", SqlDbType.Int).Value = TipoCompra;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;

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
        
        public RegistroCompras2E ObtenerRegistroCompras(Int32 idRegCompras)
        {        
            RegistroCompras2E registrocompras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRegistroCompras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRegCompras", SqlDbType.Int).Value = idRegCompras;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            registrocompras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return registrocompras;
        }

        public RegistroCompras2E GenerarAsientoCompras(Int32 idEmpresa, Int32 idLocal, Int32 idRegCompras, String Usuario)
        {
            RegistroCompras2E provisiones = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarAsientoCompras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idRegCompras", SqlDbType.Int).Value = idRegCompras;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            provisiones = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return provisiones;
        }

    }
}