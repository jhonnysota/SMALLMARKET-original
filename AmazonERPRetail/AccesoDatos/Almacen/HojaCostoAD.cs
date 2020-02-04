using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class HojaCostoAD : DbConection
    {

        public HojaCostoE LlenarEntidad(IDataReader oReader)
        {
            HojaCostoE hojacosto = new HojaCostoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idHojaCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.idHojaCosto = oReader["idHojaCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idHojaCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.numOrdenCompra = oReader["numOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaCierreCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.FechaCierreCosto = oReader["FechaCierreCosto"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaCierreCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.NumVoucher = oReader["NumVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.NumFile = oReader["NumFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodoCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.AnioPeriodoCosto = oReader["AnioPeriodoCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodoCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodoCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.MesPeriodoCosto = oReader["MesPeriodoCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodoCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumVoucherCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.NumVoucherCosto = oReader["NumVoucherCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumVoucherCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobanteCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.idComprobanteCosto = oReader["idComprobanteCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobanteCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumFileCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.NumFileCosto = oReader["NumFileCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumFileCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumCarperta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.NumCarperta = oReader["NumCarperta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumCarperta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.idPersona = oReader["idPersona"] == DBNull.Value ? (int?)null : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.tipFormaPago = oReader["tipFormaPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipFormaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.idDocumentoFact = oReader["idDocumentoFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FactComercial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.FactComercial = oReader["FactComercial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FactComercial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecFacturaComer'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.fecFacturaComer = oReader["fecFacturaComer"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecFacturaComer"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DUA'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.DUA = oReader["DUA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DUA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDua'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.fecDua = oReader["fecDua"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecDua"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AgAduana'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.AgAduana = oReader["AgAduana"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AgAduana"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Transporte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Transporte = oReader["Transporte"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Transporte"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaLlegadaPuerto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.FechaLlegadaPuerto = oReader["FechaLlegadaPuerto"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["FechaLlegadaPuerto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroBultos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.NroBultos = oReader["NroBultos"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["NroBultos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CiadeSeguros'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.CiadeSeguros = oReader["CiadeSeguros"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CiadeSeguros"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Embarque'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Embarque = oReader["Embarque"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Embarque"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaLlegadaAduana'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.FechaLlegadaAduana = oReader["FechaLlegadaAduana"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["FechaLlegadaAduana"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaLlegadaAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.FechaLlegadaAlmacen = oReader["FechaLlegadaAlmacen"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["FechaLlegadaAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Secuencia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Secuencia = oReader["Secuencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Secuencia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Peso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Peso = oReader["Peso"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Peso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Calculo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Calculo = oReader["Calculo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Calculo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Prorrateo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Prorrateo = oReader["Prorrateo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Prorrateo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorcAdvalorem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.PorcAdvalorem = oReader["PorcAdvalorem"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorcAdvalorem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorcIgvCif'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.PorcIgvCif = oReader["PorcIgvCif"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorcIgvCif"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorcIgvAduana'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.PorcIgvAduana = oReader["PorcIgvAduana"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorcIgvAduana"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Grupo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Grupo = oReader["Grupo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Grupo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FlagControl'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.FlagControl = oReader["FlagControl"] == DBNull.Value ? false : Convert.ToBoolean(oReader["FlagControl"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalCantidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalCantidad = oReader["TotalCantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalCantidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalPeso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalPeso = oReader["TotalPeso"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalPeso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalVolumen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalVolumen = oReader["TotalVolumen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalVolumen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalFob'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalFob = oReader["TotalFob"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalFob"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalFlete'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalFlete = oReader["TotalFlete"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalFlete"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalSeguro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalSeguro = oReader["TotalSeguro"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalSeguro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalSgs'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalSgs = oReader["TotalSgs"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalSgs"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalValorCifME'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalValorCifME = oReader["TotalValorCifME"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalValorCifME"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalValorCifMN'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalValorCifMN = oReader["TotalValorCifMN"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalValorCifMN"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalAdvalorem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalAdvalorem = oReader["TotalAdvalorem"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalAdvalorem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalGstoAduana'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalGstoAduana = oReader["TotalGstoAduana"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalGstoAduana"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalGstoComision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalGstoComision = oReader["TotalGstoComision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalGstoComision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalGstoBancario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalGstoBancario = oReader["TotalGstoBancario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalGstoBancario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalGstoOtros'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalGstoOtros = oReader["TotalGstoOtros"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalGstoOtros"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalCostoImportacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.TotalCostoImportacion = oReader["TotalCostoImportacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalCostoImportacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Transferido'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.Transferido = oReader["Transferido"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Transferido"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacosto.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.DesPersona = oReader["DesPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesFormaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.DesFormaPago = oReader["DesFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesFormaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesGrupo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.DesGrupo = oReader["DesGrupo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesGrupo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaIngreso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.FechaIngreso = oReader["FechaIngreso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaIngreso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.cantidad = oReader["cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FobUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.FobUnitario = oReader["FobUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["FobUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitarioME'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.CostoUnitarioME = oReader["CostoUnitarioME"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitarioME"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Factor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.Factor = oReader["Factor"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Factor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorFob'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.ValorFob = oReader["ValorFob"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorFob"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoTotalME'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.CostoTotalME = oReader["CostoTotalME"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoTotalME"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesTransporte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.DesTransporte = oReader["DesTransporte"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesTransporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacosto.NomTipoArticulo = oReader["NomTipoArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomTipoArticulo"]);


            return  hojacosto;        
        }

        public HojaCostoE InsertarHojaCosto(HojaCostoE hojacosto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarHojaCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacosto.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacosto.idLocal;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = hojacosto.Fecha;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = hojacosto.idOrdenCompra;
                    oComando.Parameters.Add("@numOrdenCompra", SqlDbType.VarChar, 100).Value = hojacosto.numOrdenCompra;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = hojacosto.Descripcion;
					//oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = hojacosto.Estado;
					oComando.Parameters.Add("@FechaCierreCosto", SqlDbType.SmallDateTime).Value = hojacosto.FechaCierreCosto;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = hojacosto.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = hojacosto.MesPeriodo;
					oComando.Parameters.Add("@NumVoucher", SqlDbType.VarChar, 9).Value = hojacosto.NumVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = hojacosto.idComprobante;
					oComando.Parameters.Add("@NumFile", SqlDbType.VarChar, 2).Value = hojacosto.NumFile;
					oComando.Parameters.Add("@AnioPeriodoCosto", SqlDbType.VarChar, 4).Value = hojacosto.AnioPeriodoCosto;
					oComando.Parameters.Add("@MesPeriodoCosto", SqlDbType.VarChar, 2).Value = hojacosto.MesPeriodoCosto;
					oComando.Parameters.Add("@NumVoucherCosto", SqlDbType.VarChar, 9).Value = hojacosto.NumVoucherCosto;
					oComando.Parameters.Add("@idComprobanteCosto", SqlDbType.VarChar, 2).Value = hojacosto.idComprobanteCosto;
					oComando.Parameters.Add("@NumFileCosto", SqlDbType.VarChar, 2).Value = hojacosto.NumFileCosto;
					oComando.Parameters.Add("@NumCarperta", SqlDbType.VarChar, 10).Value = hojacosto.NumCarperta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = hojacosto.idPersona;
					oComando.Parameters.Add("@tipFormaPago", SqlDbType.Int).Value = hojacosto.tipFormaPago;
                    oComando.Parameters.Add("@idDocumentoFact", SqlDbType.VarChar, 2).Value = hojacosto.idDocumentoFact;
                    oComando.Parameters.Add("@FactComercial", SqlDbType.VarChar, 20).Value = hojacosto.FactComercial;
                    oComando.Parameters.Add("@fecFacturaComer", SqlDbType.SmallDateTime).Value = hojacosto.fecFacturaComer;
                    oComando.Parameters.Add("@DUA", SqlDbType.VarChar, 15).Value = hojacosto.DUA;
                    oComando.Parameters.Add("@fecDua", SqlDbType.SmallDateTime).Value = hojacosto.fecDua;
                    oComando.Parameters.Add("@AgAduana", SqlDbType.VarChar, 7).Value = hojacosto.AgAduana;
					oComando.Parameters.Add("@Transporte", SqlDbType.VarChar, 1).Value = hojacosto.Transporte;
					oComando.Parameters.Add("@FechaLlegadaPuerto", SqlDbType.SmallDateTime).Value = hojacosto.FechaLlegadaPuerto;
					oComando.Parameters.Add("@NroBultos", SqlDbType.Int).Value = hojacosto.NroBultos;
					oComando.Parameters.Add("@CiadeSeguros", SqlDbType.VarChar, 7).Value = hojacosto.CiadeSeguros;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = hojacosto.idMoneda;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = hojacosto.TipoCambio;
					oComando.Parameters.Add("@Embarque", SqlDbType.VarChar, 6).Value = hojacosto.Embarque;
					oComando.Parameters.Add("@FechaLlegadaAduana", SqlDbType.SmallDateTime).Value = hojacosto.FechaLlegadaAduana;
					oComando.Parameters.Add("@FechaLlegadaAlmacen", SqlDbType.SmallDateTime).Value = hojacosto.FechaLlegadaAlmacen;
					oComando.Parameters.Add("@Secuencia", SqlDbType.VarChar, 4).Value = hojacosto.Secuencia;
					oComando.Parameters.Add("@Peso", SqlDbType.Int).Value = hojacosto.Peso;
					oComando.Parameters.Add("@Calculo", SqlDbType.Char, 1).Value = hojacosto.Calculo;
					oComando.Parameters.Add("@Prorrateo", SqlDbType.Char, 1).Value = hojacosto.Prorrateo;
					oComando.Parameters.Add("@PorcAdvalorem", SqlDbType.Decimal).Value = hojacosto.PorcAdvalorem;
					oComando.Parameters.Add("@PorcIgvCif", SqlDbType.Decimal).Value = hojacosto.PorcIgvCif;
					oComando.Parameters.Add("@PorcIgvAduana", SqlDbType.Decimal).Value = hojacosto.PorcIgvAduana;
					oComando.Parameters.Add("@Grupo", SqlDbType.VarChar, 3).Value = hojacosto.Grupo;
					oComando.Parameters.Add("@FlagControl", SqlDbType.Bit).Value = hojacosto.FlagControl;
					oComando.Parameters.Add("@TotalCantidad", SqlDbType.Decimal).Value = hojacosto.TotalCantidad;
					oComando.Parameters.Add("@TotalPeso", SqlDbType.Decimal).Value = hojacosto.TotalPeso;
					oComando.Parameters.Add("@TotalFob", SqlDbType.Decimal).Value = hojacosto.TotalFob;
					oComando.Parameters.Add("@TotalFlete", SqlDbType.Decimal).Value = hojacosto.TotalFlete;
					oComando.Parameters.Add("@TotalSeguro", SqlDbType.Decimal).Value = hojacosto.TotalSeguro;
					oComando.Parameters.Add("@TotalSgs", SqlDbType.Decimal).Value = hojacosto.TotalSgs;
					oComando.Parameters.Add("@TotalValorCifME", SqlDbType.Decimal).Value = hojacosto.TotalValorCifME;
					oComando.Parameters.Add("@TotalValorCifMN", SqlDbType.Decimal).Value = hojacosto.TotalValorCifMN;
					oComando.Parameters.Add("@TotalAdvalorem", SqlDbType.Decimal).Value = hojacosto.TotalAdvalorem;
					oComando.Parameters.Add("@TotalGstoAduana", SqlDbType.Decimal).Value = hojacosto.TotalGstoAduana;
					oComando.Parameters.Add("@TotalGstoComision", SqlDbType.Decimal).Value = hojacosto.TotalGstoComision;
					oComando.Parameters.Add("@TotalGstoBancario", SqlDbType.Decimal).Value = hojacosto.TotalGstoBancario;
					oComando.Parameters.Add("@TotalGstoOtros", SqlDbType.Decimal).Value = hojacosto.TotalGstoOtros;
					oComando.Parameters.Add("@TotalCostoImportacion", SqlDbType.Decimal).Value = hojacosto.TotalCostoImportacion;
					oComando.Parameters.Add("@Transferido", SqlDbType.Bit).Value = hojacosto.Transferido;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = hojacosto.UsuarioRegistro;

                    oConexion.Open();
                    hojacosto.idHojaCosto = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return hojacosto;
        }
        
        public HojaCostoE ActualizarHojaCosto(HojaCostoE hojacosto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarHojaCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacosto.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacosto.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = hojacosto.idHojaCosto;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = hojacosto.Fecha;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = hojacosto.idOrdenCompra;
                    oComando.Parameters.Add("@numOrdenCompra", SqlDbType.VarChar, 100).Value = hojacosto.numOrdenCompra;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = hojacosto.Descripcion;
					//oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = hojacosto.Estado;
					oComando.Parameters.Add("@FechaCierreCosto", SqlDbType.DateTime).Value = hojacosto.FechaCierreCosto;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = hojacosto.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = hojacosto.MesPeriodo;
					oComando.Parameters.Add("@NumVoucher", SqlDbType.VarChar, 9).Value = hojacosto.NumVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = hojacosto.idComprobante;
					oComando.Parameters.Add("@NumFile", SqlDbType.VarChar, 2).Value = hojacosto.NumFile;
					oComando.Parameters.Add("@AnioPeriodoCosto", SqlDbType.VarChar, 4).Value = hojacosto.AnioPeriodoCosto;
					oComando.Parameters.Add("@MesPeriodoCosto", SqlDbType.VarChar, 2).Value = hojacosto.MesPeriodoCosto;
					oComando.Parameters.Add("@NumVoucherCosto", SqlDbType.VarChar, 9).Value = hojacosto.NumVoucherCosto;
					oComando.Parameters.Add("@idComprobanteCosto", SqlDbType.VarChar, 2).Value = hojacosto.idComprobanteCosto;
					oComando.Parameters.Add("@NumFileCosto", SqlDbType.VarChar, 2).Value = hojacosto.NumFileCosto;
					oComando.Parameters.Add("@NumCarperta", SqlDbType.VarChar, 10).Value = hojacosto.NumCarperta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = hojacosto.idPersona;
                    oComando.Parameters.Add("@tipFormaPago", SqlDbType.Int).Value = hojacosto.tipFormaPago;
                    oComando.Parameters.Add("@idDocumentoFact", SqlDbType.VarChar, 2).Value = hojacosto.idDocumentoFact;
                    oComando.Parameters.Add("@FactComercial", SqlDbType.VarChar, 20).Value = hojacosto.FactComercial;
                    oComando.Parameters.Add("@fecFacturaComer", SqlDbType.SmallDateTime).Value = hojacosto.fecFacturaComer;
                    oComando.Parameters.Add("@DUA", SqlDbType.VarChar, 15).Value = hojacosto.DUA;
                    oComando.Parameters.Add("@fecDua", SqlDbType.SmallDateTime).Value = hojacosto.fecDua;
                    oComando.Parameters.Add("@AgAduana", SqlDbType.VarChar, 7).Value = hojacosto.AgAduana;
					oComando.Parameters.Add("@Transporte", SqlDbType.VarChar, 1).Value = hojacosto.Transporte;
					oComando.Parameters.Add("@FechaLlegadaPuerto", SqlDbType.SmallDateTime).Value = hojacosto.FechaLlegadaPuerto;
					oComando.Parameters.Add("@NroBultos", SqlDbType.Int).Value = hojacosto.NroBultos;
					oComando.Parameters.Add("@CiadeSeguros", SqlDbType.VarChar, 7).Value = hojacosto.CiadeSeguros;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = hojacosto.idMoneda;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = hojacosto.TipoCambio;
					oComando.Parameters.Add("@Embarque", SqlDbType.VarChar, 6).Value = hojacosto.Embarque;
					oComando.Parameters.Add("@FechaLlegadaAduana", SqlDbType.SmallDateTime).Value = hojacosto.FechaLlegadaAduana;
					oComando.Parameters.Add("@FechaLlegadaAlmacen", SqlDbType.SmallDateTime).Value = hojacosto.FechaLlegadaAlmacen;
					oComando.Parameters.Add("@Secuencia", SqlDbType.VarChar, 4).Value = hojacosto.Secuencia;
					oComando.Parameters.Add("@Peso", SqlDbType.Int).Value = hojacosto.Peso;
					oComando.Parameters.Add("@Calculo", SqlDbType.Char, 1).Value = hojacosto.Calculo;
					oComando.Parameters.Add("@Prorrateo", SqlDbType.Char, 1).Value = hojacosto.Prorrateo;
					oComando.Parameters.Add("@PorcAdvalorem", SqlDbType.Decimal).Value = hojacosto.PorcAdvalorem;
					oComando.Parameters.Add("@PorcIgvCif", SqlDbType.Decimal).Value = hojacosto.PorcIgvCif;
					oComando.Parameters.Add("@PorcIgvAduana", SqlDbType.Decimal).Value = hojacosto.PorcIgvAduana;
					oComando.Parameters.Add("@Grupo", SqlDbType.VarChar, 3).Value = hojacosto.Grupo;
					oComando.Parameters.Add("@FlagControl", SqlDbType.Bit).Value = hojacosto.FlagControl;
					oComando.Parameters.Add("@TotalCantidad", SqlDbType.Decimal).Value = hojacosto.TotalCantidad;
					oComando.Parameters.Add("@TotalPeso", SqlDbType.Decimal).Value = hojacosto.TotalPeso;
					oComando.Parameters.Add("@TotalFob", SqlDbType.Decimal).Value = hojacosto.TotalFob;
					oComando.Parameters.Add("@TotalFlete", SqlDbType.Decimal).Value = hojacosto.TotalFlete;
					oComando.Parameters.Add("@TotalSeguro", SqlDbType.Decimal).Value = hojacosto.TotalSeguro;
					oComando.Parameters.Add("@TotalSgs", SqlDbType.Decimal).Value = hojacosto.TotalSgs;
					oComando.Parameters.Add("@TotalValorCifME", SqlDbType.Decimal).Value = hojacosto.TotalValorCifME;
					oComando.Parameters.Add("@TotalValorCifMN", SqlDbType.Decimal).Value = hojacosto.TotalValorCifMN;
					oComando.Parameters.Add("@TotalAdvalorem", SqlDbType.Decimal).Value = hojacosto.TotalAdvalorem;
					oComando.Parameters.Add("@TotalGstoAduana", SqlDbType.Decimal).Value = hojacosto.TotalGstoAduana;
					oComando.Parameters.Add("@TotalGstoComision", SqlDbType.Decimal).Value = hojacosto.TotalGstoComision;
					oComando.Parameters.Add("@TotalGstoBancario", SqlDbType.Decimal).Value = hojacosto.TotalGstoBancario;
					oComando.Parameters.Add("@TotalGstoOtros", SqlDbType.Decimal).Value = hojacosto.TotalGstoOtros;
					oComando.Parameters.Add("@TotalCostoImportacion", SqlDbType.Decimal).Value = hojacosto.TotalCostoImportacion;
					oComando.Parameters.Add("@Transferido", SqlDbType.Bit).Value = hojacosto.Transferido;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = hojacosto.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return hojacosto;
        }        

        public int EliminarHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarHojaCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<HojaCostoE> ListarHojaCosto(Int32 idEmpresa , DateTime FechaIni,DateTime FechaFin)
        {
            List<HojaCostoE> listaEntidad = new List<HojaCostoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarHojaCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@FechaIni", SqlDbType.SmallDateTime).Value = FechaIni.Date;
                    oComando.Parameters.Add("@FechaFin", SqlDbType.SmallDateTime).Value = FechaFin.Date;

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

        public List<HojaCostoE> ReporteHojaCosto(Int32 idEmpresa, string FechaInicio, string FechaFin, String DesProveedor , String codArticulo, String nomArticulo)
        {
            List<HojaCostoE> listaEntidad = new List<HojaCostoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteHojaCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@FechaInicio", SqlDbType.VarChar, 8).Value = FechaInicio;
                    oComando.Parameters.Add("@FechaFin", SqlDbType.VarChar, 8).Value = FechaFin;
                    oComando.Parameters.Add("@DesProveedor", SqlDbType.VarChar, 200).Value = DesProveedor;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 10).Value = codArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 100).Value = nomArticulo;

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

        public HojaCostoE ObtenerHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {        
            HojaCostoE hojacosto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerHojaCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            hojacosto = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return hojacosto;
        }

        public HojaCostoE ActualizarHojaCostoDua(HojaCostoE hojacosto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarHojaCostoDua", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacosto.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacosto.idLocal;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = hojacosto.idHojaCosto;
                    oComando.Parameters.Add("@DUA", SqlDbType.VarChar, 15).Value = hojacosto.DUA;
                    oComando.Parameters.Add("@fecDua", SqlDbType.SmallDateTime).Value = hojacosto.fecDua;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = hojacosto.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return hojacosto;
        }

        public int ActualizarEstadoHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 idOrdenCompra, String Estado, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoHojaCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public HojaCostoE ObtenerHojaCostoPorOC(Int32 idEmpresa, Int32 idLocal, Int32 idOrdenCompra)
        {
            HojaCostoE hojacosto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerHojaCostoPorOC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            hojacosto = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return hojacosto;
        }

    }
}