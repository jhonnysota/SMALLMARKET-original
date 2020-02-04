using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class ProvisionesAD : DbConection
    {

        public ProvisionesE LlenarEntidad(IDataReader oReader)
        {
            ProvisionesE provisiones = new ProvisionesE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.idProvision = oReader["idProvision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.FechaProvision = oReader["FechaProvision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.FechaDocumento = oReader["FechaDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumDiasVen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.NumDiasVen = oReader["NumDiasVen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["NumDiasVen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.FechaVencimiento = oReader["FechaVencimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaVencimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.NumSerie = oReader["NumSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.NumDocumento = oReader["NumDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.numSerieRef = oReader["numSerieRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.fecDocumentoRef = oReader["fecDocumentoRef"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAfectacionAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indAfectacionAlmacen = oReader["indAfectacionAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["indAfectacionAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idOperacion = oReader["idOperacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimientoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.tipMovimientoAlmacen = oReader["tipMovimientoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimientoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodMonedaProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.CodMonedaProvision = oReader["CodMonedaProvision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodMonedaProvision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpMonedaOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.ImpMonedaOrigen = oReader["ImpMonedaOrigen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpMonedaOrigen"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.EstadoProvision = oReader["EstadoProvision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EstadoProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.TipCambio = oReader["TipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IndCalcAuto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.IndCalcAuto = oReader["IndCalcAuto"] == DBNull.Value ? true : Convert.ToBoolean(oReader["IndCalcAuto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impTotalBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impTotalBase = oReader["impTotalBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impTotalBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impImponBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impImponBase = oReader["impImponBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impImponBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impExonBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impExonBase = oReader["impExonBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impExonBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impAjusteBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impAjusteBase = oReader["impAjusteBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impAjusteBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impImpuestoBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impImpuestoBase = oReader["impImpuestoBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impImpuestoBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impTotalSecun'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impTotalSecun = oReader["impTotalSecun"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impTotalSecun"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impImponSecun'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impImponSecun = oReader["impImponSecun"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impImponSecun"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impExonSecun'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impExonSecun = oReader["impExonSecun"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impExonSecun"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impAjusteSecun'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impAjusteSecun = oReader["impAjusteSecun"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impAjusteSecun"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impImpuestoSecun'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.impImpuestoSecun = oReader["impImpuestoSecun"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impImpuestoSecun"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.NumVerPlanCuentas = oReader["NumVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.DesProvision = oReader["DesProvision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRecepcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.idRecepcion = oReader["idRecepcion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRecepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumGuia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.NumGuia = oReader["NumGuia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumGuia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlantilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.idPlantilla = oReader["idPlantilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlantilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.CodPartidaPresu = oReader["CodPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.flagDetraccion = oReader["flagDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flagDetraccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='retNumero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.retNumero = oReader["retNumero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["retNumero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='retFecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.retFecha = oReader["retFecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["retFecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.TipoDetraccion = oReader["TipoDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoDetraccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.TasaDetraccion = oReader["TasaDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaDetraccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.MontoDetraccion = oReader["MontoDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDetraccionSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.MontoDetraccionSoles = oReader["MontoDetraccionSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDetraccionSoles"]);
                        
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPagoDetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indPagoDetra = oReader["indPagoDetra"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPagoDetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCompraFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idCompraFile = oReader["idCompraFile"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCompraFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indHojaCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indHojaCosto = oReader["indHojaCosto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indHojaCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idHojaCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idHojaCosto = oReader["idHojaCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idHojaCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indNoDom'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indNoDom = oReader["indNoDom"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indNoDom"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocCredFiscal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idDocCredFiscal = oReader["idDocCredFiscal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocCredFiscal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='depAduanera'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.depAduanera = oReader["depAduanera"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["depAduanera"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocCredFiscal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.serDocCredFiscal = oReader["serDocCredFiscal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocCredFiscal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioDua'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.AnioDua = oReader["AnioDua"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioDua"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocCredFiscal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.numDocCredFiscal = oReader["numDocCredFiscal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocCredFiscal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RentaBruta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.RentaBruta = oReader["RentaBruta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["RentaBruta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaRetencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.TasaRetencion = oReader["TasaRetencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaRetencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RentaNeta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.RentaNeta = oReader["RentaNeta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["RentaNeta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impRetenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.impRetenido = oReader["impRetenido"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["impRetenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTasaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idTasaRenta = oReader["idTasaRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTasaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.codCuentaRenta = oReader["codCuentaRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIgvNoDom'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indIgvNoDom = oReader["indIgvNoDom"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indIgvNoDom"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvNoDom'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.IgvNoDom = oReader["IgvNoDom"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IgvNoDom"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDistribucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indDistribucion = oReader["indDistribucion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDistribucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReparable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indReparable = oReader["indReparable"] == DBNull.Value ? "N" : Convert.ToString(oReader["indReparable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idConceptoRep = oReader["idConceptoRep"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desReferenciaRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.desReferenciaRep = oReader["desReferenciaRep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desReferenciaRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReversion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indReversion = oReader["indReversion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indReversion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvisionRev'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idProvisionRev = oReader["idProvisionRev"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(oReader["idProvisionRev"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idSistema = oReader["idSistema"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(oReader["idSistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAnticipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.EsAnticipo = oReader["EsAnticipo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["EsAnticipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsLiquidacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.EsLiquidacion = oReader["EsLiquidacion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsLiquidacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConversion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.indConversion = oReader["indConversion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indConversion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenConversion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idOrdenConversion = oReader["idOrdenConversion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenConversion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsRendicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.EsRendicion = oReader["EsRendicion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsRendicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            // Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.DesEstado = oReader["DesEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.DesCuenta = oReader["DesCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.DesComprobante = oReader["DesComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.DesFile = oReader["DesFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.desPartidaPresu = oReader["desPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='monto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.monto = oReader["monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvisionRev'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idProvisionRevTmp = oReader["idProvisionRev"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(oReader["idProvisionRev"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.desCuentaRenta = oReader["desCuentaRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesidDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.DesidDocumentoRef = oReader["DesidDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesidDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.numOrdenCompra = oReader["numOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.TipoOperacion = oReader["TipoOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Redondeo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.Redondeo = oReader["Redondeo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Redondeo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuentaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.numCuentaDetraccion = oReader["numCuentaDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuentaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.CodSunat = oReader["CodSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.idOrdenPago = oReader["idOrdenPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.codOrdenPago = oReader["codOrdenPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreArchivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.NombreArchivo = oReader["NombreArchivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreArchivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLiquidacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.numLiquidacion = oReader["numLiquidacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numLiquidacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AfectaOc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.AfectaOc = oReader["AfectaOc"] == DBNull.Value ? true : Convert.ToBoolean(oReader["AfectaOc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenConversion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones.codOrdenConversion = oReader["codOrdenConversion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenConversion"]);

            return  provisiones;
        }

        public ProvisionesE InsertarProvisiones(ProvisionesE provisiones)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarProvisiones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = provisiones.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = provisiones.idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = provisiones.idPersona;
                    oComando.Parameters.Add("@FechaProvision", SqlDbType.SmallDateTime).Value = provisiones.FechaProvision.Date;
                    oComando.Parameters.Add("@FechaDocumento", SqlDbType.SmallDateTime).Value = provisiones.FechaDocumento.Date;
                    oComando.Parameters.Add("@NumDiasVen", SqlDbType.Int).Value = provisiones.NumDiasVen;
                    oComando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = provisiones.FechaVencimiento;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = provisiones.idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 10).Value = provisiones.NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = provisiones.NumDocumento;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = provisiones.idDocumentoRef;
                    oComando.Parameters.Add("@numSerieRef", SqlDbType.VarChar, 20).Value = provisiones.numSerieRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = provisiones.numDocumentoRef;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = provisiones.fecDocumentoRef;
                    oComando.Parameters.Add("@indAfectacionAlmacen", SqlDbType.Int).Value = provisiones.indAfectacionAlmacen;
                    oComando.Parameters.Add("@CodMonedaProvision", SqlDbType.VarChar, 2).Value = provisiones.CodMonedaProvision;
                    oComando.Parameters.Add("@ImpMonedaOrigen", SqlDbType.Decimal).Value = provisiones.ImpMonedaOrigen;
                    oComando.Parameters.Add("@EstadoProvision", SqlDbType.VarChar, 2).Value = provisiones.EstadoProvision;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = provisiones.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = provisiones.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = provisiones.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = provisiones.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = provisiones.numFile;
                    oComando.Parameters.Add("@TipCambio", SqlDbType.Decimal).Value = provisiones.TipCambio;
                    oComando.Parameters.Add("@IndCalcAuto", SqlDbType.Bit).Value = provisiones.IndCalcAuto;
                    oComando.Parameters.Add("@impTotalBase", SqlDbType.Decimal).Value = provisiones.impTotalBase;
                    oComando.Parameters.Add("@impImponBase", SqlDbType.Decimal).Value = provisiones.impImponBase;
                    oComando.Parameters.Add("@impExonBase", SqlDbType.Decimal).Value = provisiones.impExonBase;
                    oComando.Parameters.Add("@impAjusteBase", SqlDbType.Decimal).Value = provisiones.impAjusteBase;
                    oComando.Parameters.Add("@impImpuestoBase", SqlDbType.Decimal).Value = provisiones.impImpuestoBase;
                    oComando.Parameters.Add("@impTotalSecun", SqlDbType.Decimal).Value = provisiones.impTotalSecun;
                    oComando.Parameters.Add("@impImponSecun", SqlDbType.Decimal).Value = provisiones.impImponSecun;
                    oComando.Parameters.Add("@impExonSecun", SqlDbType.Decimal).Value = provisiones.impExonSecun;
                    oComando.Parameters.Add("@impAjusteSecun", SqlDbType.Decimal).Value = provisiones.impAjusteSecun;
                    oComando.Parameters.Add("@impImpuestoSecun", SqlDbType.Decimal).Value = provisiones.impImpuestoSecun;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = provisiones.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = provisiones.CodPartidaPresu;
                    oComando.Parameters.Add("@NumVerPlanCuentas", SqlDbType.VarChar, 3).Value = provisiones.NumVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = provisiones.codCuenta;
                    oComando.Parameters.Add("@DesProvision", SqlDbType.VarChar, 100).Value = provisiones.DesProvision;
                    oComando.Parameters.Add("@idRecepcion", SqlDbType.Int).Value = provisiones.idRecepcion;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = provisiones.idOrdenCompra;
                    oComando.Parameters.Add("@NumGuia", SqlDbType.VarChar, 8).Value = provisiones.NumGuia;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = provisiones.idPlantilla;
                    oComando.Parameters.Add("@flagDetraccion", SqlDbType.Bit).Value = provisiones.flagDetraccion;
                    oComando.Parameters.Add("@retNumero", SqlDbType.VarChar, 15).Value = provisiones.retNumero;
                    oComando.Parameters.Add("@retFecha", SqlDbType.SmallDateTime).Value = provisiones.retFecha;
                    oComando.Parameters.Add("@TipoDetraccion", SqlDbType.VarChar, 3).Value = provisiones.TipoDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = provisiones.TasaDetraccion;
                    oComando.Parameters.Add("@MontoDetraccion", SqlDbType.Decimal).Value = provisiones.MontoDetraccion;
                    oComando.Parameters.Add("@indPagoDetra", SqlDbType.Bit).Value = provisiones.indPagoDetra;
                    oComando.Parameters.Add("@idCompraFile", SqlDbType.Int).Value = provisiones.idCompraFile;
                    oComando.Parameters.Add("@indHojaCosto", SqlDbType.Bit).Value = provisiones.indHojaCosto;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = provisiones.idHojaCosto;
                    oComando.Parameters.Add("@indNoDom", SqlDbType.Bit).Value = provisiones.indNoDom;
                    oComando.Parameters.Add("@idDocCredFiscal", SqlDbType.VarChar, 2).Value = provisiones.idDocCredFiscal;
                    oComando.Parameters.Add("@depAduanera", SqlDbType.Int).Value = provisiones.depAduanera;
                    oComando.Parameters.Add("@serDocCredFiscal", SqlDbType.VarChar, 10).Value = provisiones.serDocCredFiscal;
                    oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 4).Value = provisiones.AnioDua;
                    oComando.Parameters.Add("@numDocCredFiscal", SqlDbType.VarChar, 10).Value = provisiones.numDocCredFiscal;
                    oComando.Parameters.Add("@RentaBruta", SqlDbType.Decimal).Value = provisiones.RentaBruta;
                    oComando.Parameters.Add("@TasaRetencion", SqlDbType.Decimal).Value = provisiones.TasaRetencion;
                    oComando.Parameters.Add("@RentaNeta", SqlDbType.Decimal).Value = provisiones.RentaNeta;
                    oComando.Parameters.Add("@impRetenido", SqlDbType.Decimal).Value = provisiones.impRetenido;
                    oComando.Parameters.Add("@idTasaRenta", SqlDbType.VarChar, 2).Value = provisiones.idTasaRenta;
                    oComando.Parameters.Add("@codCuentaRenta", SqlDbType.VarChar, 20).Value = provisiones.codCuentaRenta;
                    oComando.Parameters.Add("@indIgvNoDom", SqlDbType.Bit).Value = provisiones.indIgvNoDom;
                    oComando.Parameters.Add("@IgvNoDom", SqlDbType.Decimal).Value = provisiones.IgvNoDom;
                    oComando.Parameters.Add("@indDistribucion", SqlDbType.Bit).Value = provisiones.indDistribucion;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = provisiones.indReparable;
                    oComando.Parameters.Add("@idConceptoRep ", SqlDbType.Int).Value = provisiones.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = provisiones.desReferenciaRep;
                    oComando.Parameters.Add("@indReversion", SqlDbType.Bit).Value = provisiones.indReversion;
                    oComando.Parameters.Add("@idProvisionRev ", SqlDbType.Int).Value = provisiones.idProvisionRev;
                    oComando.Parameters.Add("@idSistema ", SqlDbType.Int).Value = provisiones.idSistema;
                    oComando.Parameters.Add("@EsAnticipo ", SqlDbType.Int).Value = provisiones.EsAnticipo;
                    oComando.Parameters.Add("@EsLiquidacion ", SqlDbType.Bit).Value = provisiones.EsLiquidacion;
                    oComando.Parameters.Add("@indConversion ", SqlDbType.Bit).Value = provisiones.indConversion;
                    oComando.Parameters.Add("@idOrdenConversion ", SqlDbType.Int).Value = provisiones.idOrdenConversion;
                    oComando.Parameters.Add("@EsRendicion ", SqlDbType.Bit).Value = provisiones.EsRendicion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = provisiones.UsuarioRegistro;

                    oConexion.Open();
                    provisiones.idProvision = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return provisiones;
        }

        public ProvisionesE ActualizarProvisiones(ProvisionesE provisiones)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProvisiones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = provisiones.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = provisiones.idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = provisiones.idProvision;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = provisiones.idPersona;
                    oComando.Parameters.Add("@FechaProvision", SqlDbType.SmallDateTime).Value = provisiones.FechaProvision.Date;
                    oComando.Parameters.Add("@FechaDocumento", SqlDbType.SmallDateTime).Value = provisiones.FechaDocumento.Date;
                    oComando.Parameters.Add("@NumDiasVen", SqlDbType.Int).Value = provisiones.NumDiasVen;
                    oComando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = provisiones.FechaVencimiento;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = provisiones.idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 10).Value = provisiones.NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = provisiones.NumDocumento;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = provisiones.idDocumentoRef;
                    oComando.Parameters.Add("@numSerieRef", SqlDbType.VarChar, 20).Value = provisiones.numSerieRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = provisiones.numDocumentoRef;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = provisiones.fecDocumentoRef;
                    oComando.Parameters.Add("@indAfectacionAlmacen", SqlDbType.Int).Value = provisiones.indAfectacionAlmacen;
                    oComando.Parameters.Add("@CodMonedaProvision", SqlDbType.VarChar, 2).Value = provisiones.CodMonedaProvision;
                    oComando.Parameters.Add("@ImpMonedaOrigen", SqlDbType.Decimal).Value = provisiones.ImpMonedaOrigen;
                    oComando.Parameters.Add("@EstadoProvision", SqlDbType.VarChar, 2).Value = provisiones.EstadoProvision;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = provisiones.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = provisiones.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = provisiones.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = provisiones.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = provisiones.numFile;
                    oComando.Parameters.Add("@TipCambio", SqlDbType.Decimal).Value = provisiones.TipCambio;
                    oComando.Parameters.Add("@IndCalcAuto", SqlDbType.Bit).Value = provisiones.IndCalcAuto;
                    oComando.Parameters.Add("@impTotalBase", SqlDbType.Decimal).Value = provisiones.impTotalBase;
                    oComando.Parameters.Add("@impImponBase", SqlDbType.Decimal).Value = provisiones.impImponBase;
                    oComando.Parameters.Add("@impExonBase", SqlDbType.Decimal).Value = provisiones.impExonBase;
                    oComando.Parameters.Add("@impAjusteBase", SqlDbType.Decimal).Value = provisiones.impAjusteBase;
                    oComando.Parameters.Add("@impImpuestoBase", SqlDbType.Decimal).Value = provisiones.impImpuestoBase;
                    oComando.Parameters.Add("@impTotalSecun", SqlDbType.Decimal).Value = provisiones.impTotalSecun;
                    oComando.Parameters.Add("@impImponSecun", SqlDbType.Decimal).Value = provisiones.impImponSecun;
                    oComando.Parameters.Add("@impExonSecun", SqlDbType.Decimal).Value = provisiones.impExonSecun;
                    oComando.Parameters.Add("@impAjusteSecun", SqlDbType.Decimal).Value = provisiones.impAjusteSecun;
                    oComando.Parameters.Add("@impImpuestoSecun", SqlDbType.Decimal).Value = provisiones.impImpuestoSecun;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = provisiones.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = provisiones.CodPartidaPresu;
                    oComando.Parameters.Add("@NumVerPlanCuentas", SqlDbType.VarChar, 3).Value = provisiones.NumVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = provisiones.codCuenta;
                    oComando.Parameters.Add("@DesProvision", SqlDbType.VarChar, 100).Value = provisiones.DesProvision;
                    oComando.Parameters.Add("@idRecepcion", SqlDbType.Int).Value = provisiones.idRecepcion;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = provisiones.idOrdenCompra;
                    oComando.Parameters.Add("@NumGuia", SqlDbType.VarChar, 8).Value = provisiones.NumGuia;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = provisiones.idPlantilla;
                    oComando.Parameters.Add("@flagDetraccion", SqlDbType.Bit).Value = provisiones.flagDetraccion;
                    oComando.Parameters.Add("@retNumero", SqlDbType.VarChar, 15).Value = provisiones.retNumero;
                    oComando.Parameters.Add("@retFecha", SqlDbType.SmallDateTime).Value = provisiones.retFecha;
                    oComando.Parameters.Add("@TipoDetraccion", SqlDbType.VarChar, 3).Value = provisiones.TipoDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = provisiones.TasaDetraccion;
                    oComando.Parameters.Add("@MontoDetraccion", SqlDbType.Decimal).Value = provisiones.MontoDetraccion;
                    oComando.Parameters.Add("@indPagoDetra", SqlDbType.Bit).Value = provisiones.indPagoDetra;
                    oComando.Parameters.Add("@idCompraFile", SqlDbType.Int).Value = provisiones.idCompraFile;
                    oComando.Parameters.Add("@indHojaCosto", SqlDbType.Bit).Value = provisiones.indHojaCosto;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = provisiones.idHojaCosto;
                    oComando.Parameters.Add("@indNoDom", SqlDbType.Bit).Value = provisiones.indNoDom;
                    oComando.Parameters.Add("@idDocCredFiscal", SqlDbType.VarChar, 2).Value = provisiones.idDocCredFiscal;
                    oComando.Parameters.Add("@depAduanera", SqlDbType.Int).Value = provisiones.depAduanera;
                    oComando.Parameters.Add("@serDocCredFiscal", SqlDbType.VarChar, 10).Value = provisiones.serDocCredFiscal;
                    oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 4).Value = provisiones.AnioDua;
                    oComando.Parameters.Add("@numDocCredFiscal", SqlDbType.VarChar, 10).Value = provisiones.numDocCredFiscal;
                    oComando.Parameters.Add("@RentaBruta", SqlDbType.Decimal).Value = provisiones.RentaBruta;
                    oComando.Parameters.Add("@TasaRetencion", SqlDbType.Decimal).Value = provisiones.TasaRetencion;
                    oComando.Parameters.Add("@RentaNeta", SqlDbType.Decimal).Value = provisiones.RentaNeta;
                    oComando.Parameters.Add("@impRetenido", SqlDbType.Decimal).Value = provisiones.impRetenido;
                    oComando.Parameters.Add("@idTasaRenta", SqlDbType.VarChar, 2).Value = provisiones.idTasaRenta;
                    oComando.Parameters.Add("@codCuentaRenta", SqlDbType.VarChar, 20).Value = provisiones.codCuentaRenta;
                    oComando.Parameters.Add("@indIgvNoDom", SqlDbType.Bit).Value = provisiones.indIgvNoDom;
                    oComando.Parameters.Add("@IgvNoDom", SqlDbType.Decimal).Value = provisiones.IgvNoDom;
                    oComando.Parameters.Add("@indDistribucion", SqlDbType.Bit).Value = provisiones.indDistribucion;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = provisiones.indReparable;
                    oComando.Parameters.Add("@idConceptoRep ", SqlDbType.Int).Value = provisiones.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = provisiones.desReferenciaRep;
                    oComando.Parameters.Add("@indReversion", SqlDbType.Bit).Value = provisiones.indReversion;
                    oComando.Parameters.Add("@idProvisionRev ", SqlDbType.Int).Value = provisiones.idProvisionRev;
                    oComando.Parameters.Add("@EsAnticipo ", SqlDbType.Int).Value = provisiones.EsAnticipo;
                    oComando.Parameters.Add("@indConversion ", SqlDbType.Bit).Value = provisiones.indConversion;
                    oComando.Parameters.Add("@idOrdenConversion ", SqlDbType.Int).Value = provisiones.idOrdenConversion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = provisiones.UsuarioModificacion;
                    
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return provisiones;
        }

        public ProvisionesE ActualizarProvisionesDetraccion(ProvisionesE provisiones)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProvisionesDetraccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = provisiones.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = provisiones.idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = provisiones.idProvision;
                    oComando.Parameters.Add("@retNumero", SqlDbType.VarChar,15).Value = provisiones.retNumero;
                    oComando.Parameters.Add("@retFecha", SqlDbType.SmallDateTime).Value = provisiones.retFecha;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return provisiones;
        }

        public List<ProvisionesE> ListarPartidaPresuAgrupadoPorPagos(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPartidaPresuAgrupadoPorPagos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecha_desde", SqlDbType.SmallDateTime).Value = fecha_desde;
                    oComando.Parameters.Add("@fecha_hasta", SqlDbType.SmallDateTime).Value = fecha_hasta;
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
        
        public List<ProvisionesE> ListarPartidaPresuAgrupadoPorProvisiones(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPartidaPresuAgrupadoPorProvisiones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecha_desde", SqlDbType.SmallDateTime).Value = fecha_desde;
                    oComando.Parameters.Add("@fecha_hasta", SqlDbType.SmallDateTime).Value = fecha_hasta;

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
        
        public List<ProvisionesE> ListarProvisionesPorPartidaPresu(Int32 idEmpresa, String codPartidaPresu, String mes,String ano)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvisionesPorPartidaPresupuestaria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = codPartidaPresu;
                    oComando.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                    oComando.Parameters.Add("@ano", SqlDbType.VarChar, 4).Value = ano;

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

        public List<ProvisionesE> ListarPagosPorPartidaPresu(Int32 idEmpresa, String codPartidaPresu, String mes, String ano)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPagosPorPartidaPresupuestaria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = codPartidaPresu;
                    oComando.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                    oComando.Parameters.Add("@ano", SqlDbType.VarChar, 4).Value = ano;

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

        public List<ProvisionesE> ListarProvisionesPorPeriodo(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvisionesPorPeriodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecha_desde", SqlDbType.SmallDateTime).Value = fecha_desde;
                    oComando.Parameters.Add("@fecha_hasta", SqlDbType.SmallDateTime).Value = fecha_hasta;

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

        public List<ProvisionesE> ListarPagosPorPeriodo(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPagosPorPeriodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecha_desde", SqlDbType.SmallDateTime).Value = fecha_desde;
                    oComando.Parameters.Add("@fecha_hasta", SqlDbType.SmallDateTime).Value = fecha_hasta;

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
        
        public Int32 EliminarProvisiones(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarProvisiones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ProvisionesE> ListarProvisiones(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String RazonSocial, String Estado, String idComprobante, String numFile, String idDocumento, String NumSerie, String NumDocumento)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvisiones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.DateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.DateTime).Value = fecFin;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = RazonSocial;
                    oComando.Parameters.Add("@estado", SqlDbType.VarChar, 2).Value = Estado;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = numFile;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 20).Value = NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;

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

        public List<ProvisionesE> ListarProvisionesNC(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String RazonSocial, String Estado, String idComprobante, String numFile, String idDocumento, String NumSerie, String NumDocumento)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvisionesNC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.DateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.DateTime).Value = fecFin;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = RazonSocial;
                    oComando.Parameters.Add("@estado", SqlDbType.VarChar, 2).Value = Estado;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = numFile;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 20).Value = NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;

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

        public ProvisionesE ObtenerProvisionPorOC(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            ProvisionesE provisiones = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProvisionPorOC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

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

        public ProvisionesE ObtenerProvisionPorReferencia(Int32 idEmpresa, Int32 idPersona, String idDocumento, String NumSerie, String NumDocumento)
        {
            ProvisionesE provisiones = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProvisionPorReferencia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 20).Value = NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;
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

        public ProvisionesE RecuperarProvisionesPorId(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            ProvisionesE provisiones = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarProvisionesPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

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

        public ProvisionesE GenerarAsientoProvisiones(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, String Usuario, String Tipo = "N") //Tipo N=Normal G=Agrupado
        {
            ProvisionesE provisiones = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProvisionaCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo;

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

        public Int32 CambiarEstadoProvision(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, String Estado, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CambiarEstadoProvision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 2).Value = Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 LimpiarVoucherProvision(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, String numVoucher, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LimpiarVoucherProvision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public ProvisionesE RevisarDocProvisiones(Int32 idEmpresa, Int32 idLocal, String idDocumento, String NumSerie, String NumDocumento, Int32 idPersona, Int32 idProvision)
        {
            ProvisionesE provisiones = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RevisarDocProvisiones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 10).Value = NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

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

        public List<ProvisionesE> ProvisionesPorRevertir(Int32 idEmpresa, Int32 idLocal)
        {
            List<ProvisionesE> provisiones = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProvisionesPorRevertir", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            provisiones.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return provisiones;
        }

        public List<ProvisionesE> ProvisionesPorRecibir(Int32 idEmpresa, Int32 idLocal)
        {
            List<ProvisionesE> provisiones = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProvisionesPorRecibir", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            provisiones.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return provisiones;
        }

        public Int32 ActualizarNumReversion(Int32 idEmpresa, Int32 idLocal, Int32? idProvision, Int32 idProvisionRev, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarNumReversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
                    oComando.Parameters.Add("@idProvisionRev", SqlDbType.Int).Value = idProvisionRev;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public ProvisionesE ObtenerProvisionPorNumReve(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            ProvisionesE provisiones = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProvisionPorNumReve", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

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

        public List<ProvisionesE> ListarProvisionesCtaCte(Int32 idEmpresa, DateTime fecIni, DateTime fecFin)
        {
            List<ProvisionesE> provisiones = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvisionesCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.DateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.DateTime).Value = fecFin.Date;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            provisiones.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return provisiones;
        }

        public Int32 ActualizarIdCtaCteProvision(Int32 idProvision, Int32? idCtaCte, Int32? idCtaCteItem, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarIdCtaCteProvision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ProvisionesE> ListarProvisionesDetraccion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String RazonSocial, String idDocumento, String NumSerie, String NumDocumento)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvisionesDetraccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = RazonSocial;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 20).Value = NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;

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

        public Int32 ActualizarProvDatosAlmacen(Int32 idProvision, Int32 idAlmacen, Int32 idOperacion, Int32 idTipoArticulo, Int32 tipMovimientoAlmacen, Int32 idDocumentoAlmacen, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProvDatosAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = idOperacion;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@tipMovimientoAlmacen", SqlDbType.Int).Value = tipMovimientoAlmacen;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ProvisionesE> ProvisionesPorEstado(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Estado)
        {
            List<ProvisionesE> listaEntidad = new List<ProvisionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProvisionesPorEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 2).Value = Estado;

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