using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class VoucherItemAD : DbConection
    {

        public VoucherItemE LlenarEntidad(IDataReader oReader)
        {
            VoucherItemE voucheritem = new VoucherItemE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                voucheritem.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

                if (Convert.ToInt32(voucheritem.idPersona) == 0)
                {
                    voucheritem.idPersonaCad = String.Empty;
                }
                else
                {
                    voucheritem.idPersonaCad = Convert.ToString(oReader["idPersona"]);
                }
            }

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.indCambio = oReader["indCambio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.fecDocumentoRef = oReader["fecDocumentoRef"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.serDocumentoRef = oReader["serDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.impSoles = oReader["impSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.impDolares = oReader["impDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAutomatica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.indAutomatica = oReader["indAutomatica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indAutomatica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CorrelativoAjuste'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.CorrelativoAjuste = oReader["CorrelativoAjuste"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CorrelativoAjuste"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFteFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codFteFin = oReader["codFteFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFteFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codProgramaCred'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codProgramaCred = oReader["codProgramaCred"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codProgramaCred"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indMovimientoAnterior'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.indMovimientoAnterior = oReader["indMovimientoAnterior"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indMovimientoAnterior"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desPartidaPresu = oReader["desPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numDocumentoPresu = oReader["numDocumentoPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColumnaCoven'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codColumnaCoven = oReader["codColumnaCoven"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codColumnaCoven"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='depAduanera'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.depAduanera = oReader["depAduanera"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["depAduanera"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroDua'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.nroDua = oReader["nroDua"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroDua"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioDua'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.AnioDua = oReader["AnioDua"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioDua"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.flagDetraccion = oReader["flagDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["flagDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numDetraccion = oReader["numDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.fecDetraccion = oReader["fecDetraccion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.tipDetraccion = oReader["tipDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.TasaDetraccion = oReader["TasaDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.MontoDetraccion = oReader["MontoDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPagoDetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.indPagoDetra = oReader["indPagoDetra"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPagoDetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReparable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.indReparable = oReader["indReparable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indReparable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idConceptoRep = oReader["idConceptoRep"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desReferenciaRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desReferenciaRep = oReader["desReferenciaRep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desReferenciaRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimientoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.tipMovimientoAlmacen = oReader["tipMovimientoAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipMovimientoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numDocumentoAlmacen = oReader["numDocumentoAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItemAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.numItemAlmacen = oReader["numItemAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItemAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CajaSucursal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.CajaSucursal = oReader["CajaSucursal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CajaSucursal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.indCompra = oReader["indCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConciliado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                voucheritem.indConciliado = oReader["indConciliado"] == DBNull.Value ? "N" : Convert.ToString(oReader["indConciliado"]);

                if (voucheritem.indConciliado == "N")
                {
                    voucheritem.indConciliadoBool = false;
                }
                else
                {
                    voucheritem.indConciliadoBool = true;
                }
            }

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecRecepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.fecRecepcion = oReader["fecRecepcion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecRecepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMedioPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codMedioPago = oReader["codMedioPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codMedioPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idCampana = oReader["idCampana"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoGasto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idConceptoGasto = oReader["idConceptoGasto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoGasto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idAccion = oReader["idAccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idAccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            // Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.Ruc = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreColumna'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.NombreColumna = oReader["NombreColumna"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreColumna"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuentaGastos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.indCuentaGastos = oReader["indCuentaGastos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCuentaGastos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codCuentaDestino = oReader["codCuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaTransferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codCuentaTransferencia = oReader["codCuentaTransferencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaTransferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desComprobante = oReader["desComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desFile = oReader["desFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMedioPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desMedioPago = oReader["desMedioPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMedioPago"]);            

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaGeneral'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.GlosaGeneral = oReader["GlosaGeneral"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaGeneral"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.Importe = oReader["Importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desConcepto = oReader["desConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desCampana = oReader["desCampana"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.impDebe = oReader["impDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.impHaber = oReader["impHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDebeDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.impDebeDolares = oReader["impDebeDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDebeDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impHaberDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.impHaberDolares = oReader["impHaberDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impHaberDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoAnterior'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.SaldoAnterior = oReader["SaldoAnterior"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoAnterior"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuentaOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.CuentaOrigen = oReader["CuentaOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CuentaOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.desCuentaOrigen = oReader["desCuentaOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='salAntSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.salAntSoles = oReader["salAntSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["salAntSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='salAntDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.salAntDolares = oReader["salAntDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["salAntDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='salActSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.salActSoles = oReader["salActSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["salActSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='salActDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.salActDolares = oReader["salActDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["salActDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='salAntSoles104'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.salAntSoles104 = oReader["salAntSoles104"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["salAntSoles104"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='salAntDolares104'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.salAntDolares104 = oReader["salAntDolares104"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["salAntDolares104"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='monto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.monto = oReader["monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.sistema = oReader["sistema"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAutomatico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.EsAutomatico = oReader["EsAutomatico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsAutomatico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Campo3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.Campo3 = oReader["Campo3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Campo3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPlanCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.CodPlanCuenta = oReader["CodPlanCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodPlanCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.TD = oReader["TD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.codSunat = oReader["codSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DebeSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.DebeSoles = oReader["DebeSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DebeSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HaberSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.HaberSoles = oReader["HaberSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["HaberSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DebeDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.DebeDolares = oReader["DebeDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DebeDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HaberDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.HaberDolares = oReader["HaberDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["HaberDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritem.nomBanco = oReader["nomBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomBanco"]);



            return  voucheritem;
        }

        public VoucherItemE InsertarVoucherItem(VoucherItemE voucheritem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarVoucherItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucheritem.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucheritem.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucheritem.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucheritem.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucheritem.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucheritem.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = voucheritem.numFile;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = voucheritem.numItem;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = voucheritem.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = voucheritem.idMoneda;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = voucheritem.tipCambio;
                    oComando.Parameters.Add("@indCambio", SqlDbType.Char, 1).Value = voucheritem.indCambio;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = voucheritem.idCCostos;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = voucheritem.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = voucheritem.codCuenta;
                    oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = voucheritem.desGlosa;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = voucheritem.fecDocumento;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.DateTime).Value = voucheritem.fecVencimiento;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = voucheritem.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = voucheritem.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = voucheritem.numDocumento;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = voucheritem.fecDocumentoRef;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = voucheritem.idDocumentoRef;
                    oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = voucheritem.serDocumentoRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoRef;
                    oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = voucheritem.indDebeHaber;
                    oComando.Parameters.Add("@impSoles", SqlDbType.Decimal).Value = voucheritem.impSoles;
                    oComando.Parameters.Add("@impDolares", SqlDbType.Decimal).Value = voucheritem.impDolares;
                    oComando.Parameters.Add("@indAutomatica", SqlDbType.Char, 1).Value = voucheritem.indAutomatica;
                    oComando.Parameters.Add("@CorrelativoAjuste", SqlDbType.VarChar, 5).Value = voucheritem.CorrelativoAjuste;
                    oComando.Parameters.Add("@codFteFin", SqlDbType.VarChar, 2).Value = voucheritem.codFteFin;
                    oComando.Parameters.Add("@codProgramaCred", SqlDbType.VarChar, 9).Value = voucheritem.codProgramaCred;
                    oComando.Parameters.Add("@indMovimientoAnterior", SqlDbType.Char, 1).Value = voucheritem.indMovimientoAnterior;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = voucheritem.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = voucheritem.codPartidaPresu;
                    oComando.Parameters.Add("@numDocumentoPresu", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoPresu;
                    oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = voucheritem.codColumnaCoven;
                    oComando.Parameters.Add("@depAduanera", SqlDbType.Int).Value = voucheritem.depAduanera;
                    oComando.Parameters.Add("@nroDua", SqlDbType.VarChar, 10).Value = voucheritem.nroDua;
                    oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 10).Value = voucheritem.AnioDua;
                    oComando.Parameters.Add("@flagDetraccion", SqlDbType.Char, 1).Value = voucheritem.flagDetraccion;
                    oComando.Parameters.Add("@numDetraccion", SqlDbType.VarChar, 15).Value = voucheritem.numDetraccion;
                    oComando.Parameters.Add("@fecDetraccion", SqlDbType.SmallDateTime).Value = voucheritem.fecDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = voucheritem.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = voucheritem.TasaDetraccion;
                    oComando.Parameters.Add("@MontoDetraccion", SqlDbType.Decimal).Value = voucheritem.MontoDetraccion;
                    oComando.Parameters.Add("@indPagoDetra", SqlDbType.Bit).Value = voucheritem.indPagoDetra;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = voucheritem.indReparable;
                    oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = voucheritem.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = voucheritem.desReferenciaRep;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.VarChar, 3).Value = voucheritem.idAlmacen;
                    oComando.Parameters.Add("@tipMovimientoAlmacen", SqlDbType.VarChar, 2).Value = voucheritem.tipMovimientoAlmacen;
                    oComando.Parameters.Add("@numDocumentoAlmacen", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoAlmacen;
                    oComando.Parameters.Add("@numItemAlmacen", SqlDbType.VarChar, 4).Value = voucheritem.numItemAlmacen;
                    oComando.Parameters.Add("@CajaSucursal", SqlDbType.VarChar, 3).Value = voucheritem.CajaSucursal;
                    oComando.Parameters.Add("@indCompra", SqlDbType.VarChar, 1).Value = voucheritem.indCompra;
                    oComando.Parameters.Add("@indConciliado", SqlDbType.VarChar, 1).Value = voucheritem.indConciliado;
                    oComando.Parameters.Add("@fecRecepcion", SqlDbType.SmallDateTime).Value = voucheritem.fecRecepcion;
                    oComando.Parameters.Add("@codMedioPago", SqlDbType.Int).Value = voucheritem.codMedioPago;
                    oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = voucheritem.idCampana;
                    oComando.Parameters.Add("@idConceptoGasto", SqlDbType.Int).Value = voucheritem.idConceptoGasto;
                    //oComando.Parameters.Add("@idAccion", SqlDbType.VarChar, 1).Value = voucheritem.idAccion;
                    //oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = voucheritem.idCtaCte;
                    //oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = voucheritem.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = voucheritem.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return voucheritem;        
        }

        public VoucherItemE InsertarVoucherItemSt(VoucherItemE voucheritem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarVoucherItemSt", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucheritem.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucheritem.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucheritem.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucheritem.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucheritem.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucheritem.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = voucheritem.numFile;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = voucheritem.numItem;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = voucheritem.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = voucheritem.idMoneda;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = voucheritem.tipCambio;
                    oComando.Parameters.Add("@indCambio", SqlDbType.Char, 1).Value = voucheritem.indCambio;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = voucheritem.idCCostos;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = voucheritem.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = voucheritem.codCuenta;
                    oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = voucheritem.desGlosa;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = voucheritem.fecDocumento;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.DateTime).Value = voucheritem.fecVencimiento;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = voucheritem.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = voucheritem.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = voucheritem.numDocumento;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = voucheritem.fecDocumentoRef;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = voucheritem.idDocumentoRef;
                    oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = voucheritem.serDocumentoRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoRef;
                    oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = voucheritem.indDebeHaber;
                    oComando.Parameters.Add("@impSoles", SqlDbType.Decimal).Value = voucheritem.impSoles;
                    oComando.Parameters.Add("@impDolares", SqlDbType.Decimal).Value = voucheritem.impDolares;
                    oComando.Parameters.Add("@indAutomatica", SqlDbType.Char, 1).Value = voucheritem.indAutomatica;
                    oComando.Parameters.Add("@CorrelativoAjuste", SqlDbType.VarChar, 5).Value = voucheritem.CorrelativoAjuste;
                    oComando.Parameters.Add("@codFteFin", SqlDbType.VarChar, 2).Value = voucheritem.codFteFin;
                    oComando.Parameters.Add("@codProgramaCred", SqlDbType.VarChar, 9).Value = voucheritem.codProgramaCred;
                    oComando.Parameters.Add("@indMovimientoAnterior", SqlDbType.Char, 1).Value = voucheritem.indMovimientoAnterior;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = voucheritem.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = voucheritem.codPartidaPresu;
                    oComando.Parameters.Add("@numDocumentoPresu", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoPresu;
                    oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = voucheritem.codColumnaCoven;
                    oComando.Parameters.Add("@depAduanera", SqlDbType.Int).Value = voucheritem.depAduanera;
                    oComando.Parameters.Add("@nroDua", SqlDbType.VarChar, 10).Value = voucheritem.nroDua;
                    oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 10).Value = voucheritem.AnioDua;
                    oComando.Parameters.Add("@flagDetraccion", SqlDbType.Char, 1).Value = voucheritem.flagDetraccion;
                    oComando.Parameters.Add("@numDetraccion", SqlDbType.VarChar, 15).Value = voucheritem.numDetraccion;
                    oComando.Parameters.Add("@fecDetraccion", SqlDbType.SmallDateTime).Value = voucheritem.fecDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = voucheritem.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = voucheritem.TasaDetraccion;
                    oComando.Parameters.Add("@MontoDetraccion", SqlDbType.Decimal).Value = voucheritem.MontoDetraccion;
                    oComando.Parameters.Add("@indPagoDetra", SqlDbType.Bit).Value = voucheritem.indPagoDetra;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = voucheritem.indReparable;
                    oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = voucheritem.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = voucheritem.desReferenciaRep;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.VarChar, 3).Value = voucheritem.idAlmacen;
                    oComando.Parameters.Add("@tipMovimientoAlmacen", SqlDbType.VarChar, 2).Value = voucheritem.tipMovimientoAlmacen;
                    oComando.Parameters.Add("@numDocumentoAlmacen", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoAlmacen;
                    oComando.Parameters.Add("@numItemAlmacen", SqlDbType.VarChar, 4).Value = voucheritem.numItemAlmacen;
                    oComando.Parameters.Add("@CajaSucursal", SqlDbType.VarChar, 3).Value = voucheritem.CajaSucursal;
                    oComando.Parameters.Add("@indCompra", SqlDbType.VarChar, 1).Value = voucheritem.indCompra;
                    oComando.Parameters.Add("@indConciliado", SqlDbType.VarChar, 1).Value = voucheritem.indConciliado;
                    oComando.Parameters.Add("@fecRecepcion", SqlDbType.SmallDateTime).Value = voucheritem.fecRecepcion;
                    oComando.Parameters.Add("@codMedioPago", SqlDbType.Int).Value = voucheritem.codMedioPago;
                    oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = voucheritem.idCampana;
                    oComando.Parameters.Add("@idConceptoGasto", SqlDbType.Int).Value = voucheritem.idConceptoGasto;
                    //oComando.Parameters.Add("@idAccion", SqlDbType.VarChar, 1).Value = voucheritem.idAccion;
                    //oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = voucheritem.idCtaCte;
                    //oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = voucheritem.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = voucheritem.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return voucheritem;
        }

        public VoucherItemE ActualizarVoucherItem(VoucherItemE voucheritem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVoucherItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucheritem.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucheritem.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucheritem.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucheritem.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucheritem.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucheritem.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = voucheritem.numFile;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = voucheritem.numItem;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = voucheritem.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = voucheritem.idMoneda;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = voucheritem.tipCambio;
                    oComando.Parameters.Add("@indCambio", SqlDbType.Char, 1).Value = voucheritem.indCambio;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = voucheritem.idCCostos;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = voucheritem.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = voucheritem.codCuenta;
                    oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = voucheritem.desGlosa;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = voucheritem.fecDocumento;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.DateTime).Value = voucheritem.fecVencimiento;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = voucheritem.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = voucheritem.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = voucheritem.numDocumento;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = voucheritem.fecDocumentoRef;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = voucheritem.idDocumentoRef;
                    oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = voucheritem.serDocumentoRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoRef;
                    oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = voucheritem.indDebeHaber;
                    oComando.Parameters.Add("@impSoles", SqlDbType.Decimal).Value = voucheritem.impSoles;
                    oComando.Parameters.Add("@impDolares", SqlDbType.Decimal).Value = voucheritem.impDolares;
                    oComando.Parameters.Add("@indAutomatica", SqlDbType.Char, 1).Value = voucheritem.indAutomatica;
                    oComando.Parameters.Add("@CorrelativoAjuste", SqlDbType.VarChar, 5).Value = voucheritem.CorrelativoAjuste;
                    oComando.Parameters.Add("@codFteFin", SqlDbType.VarChar, 2).Value = voucheritem.codFteFin;
                    oComando.Parameters.Add("@codProgramaCred", SqlDbType.VarChar, 9).Value = voucheritem.codProgramaCred;
                    oComando.Parameters.Add("@indMovimientoAnterior", SqlDbType.Char, 1).Value = voucheritem.indMovimientoAnterior;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = voucheritem.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = voucheritem.codPartidaPresu;
                    oComando.Parameters.Add("@numDocumentoPresu", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoPresu;
                    oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = voucheritem.codColumnaCoven;
                    oComando.Parameters.Add("@depAduanera", SqlDbType.Int).Value = voucheritem.depAduanera;
                    oComando.Parameters.Add("@nroDua", SqlDbType.VarChar, 10).Value = voucheritem.nroDua;
                    oComando.Parameters.Add("@AnioDua", SqlDbType.VarChar, 10).Value = voucheritem.AnioDua;
                    oComando.Parameters.Add("@flagDetraccion", SqlDbType.Char, 1).Value = voucheritem.flagDetraccion;
                    oComando.Parameters.Add("@numDetraccion", SqlDbType.VarChar, 15).Value = voucheritem.numDetraccion;
                    oComando.Parameters.Add("@fecDetraccion", SqlDbType.SmallDateTime).Value = voucheritem.fecDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = voucheritem.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = voucheritem.TasaDetraccion;
                    oComando.Parameters.Add("@MontoDetraccion", SqlDbType.Decimal).Value = voucheritem.MontoDetraccion;
                    oComando.Parameters.Add("@indPagoDetra", SqlDbType.Bit).Value = voucheritem.indPagoDetra;
                    oComando.Parameters.Add("@indReparable", SqlDbType.Char, 1).Value = voucheritem.indReparable;
                    oComando.Parameters.Add("@idConceptoRep", SqlDbType.Int).Value = voucheritem.idConceptoRep;
                    oComando.Parameters.Add("@desReferenciaRep", SqlDbType.VarChar, 50).Value = voucheritem.desReferenciaRep;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.VarChar, 3).Value = voucheritem.idAlmacen;
                    oComando.Parameters.Add("@tipMovimientoAlmacen", SqlDbType.VarChar, 2).Value = voucheritem.tipMovimientoAlmacen;
                    oComando.Parameters.Add("@numDocumentoAlmacen", SqlDbType.VarChar, 20).Value = voucheritem.numDocumentoAlmacen;
                    oComando.Parameters.Add("@numItemAlmacen", SqlDbType.VarChar, 4).Value = voucheritem.numItemAlmacen;
                    oComando.Parameters.Add("@CajaSucursal", SqlDbType.VarChar, 3).Value = voucheritem.CajaSucursal;
                    oComando.Parameters.Add("@indCompra", SqlDbType.VarChar, 1).Value = voucheritem.indCompra;
                    oComando.Parameters.Add("@indConciliado", SqlDbType.VarChar, 1).Value = voucheritem.indConciliado;
                    oComando.Parameters.Add("@fecRecepcion", SqlDbType.SmallDateTime).Value = voucheritem.fecRecepcion;
                    oComando.Parameters.Add("@codMedioPago", SqlDbType.Int).Value = voucheritem.codMedioPago;
                    oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = voucheritem.idCampana;
                    oComando.Parameters.Add("@idConceptoGasto", SqlDbType.Int).Value = voucheritem.idConceptoGasto;
                    //oComando.Parameters.Add("@idAccion", SqlDbType.VarChar, 1).Value = voucheritem.idAccion;
                    //oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = voucheritem.idCtaCte;
                    //oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = voucheritem.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = voucheritem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return voucheritem;
        }

        public VoucherItemE ActualizarVoucherConciliado(VoucherItemE voucheritem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVoucherConciliado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucheritem.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucheritem.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucheritem.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucheritem.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucheritem.numVoucher;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = voucheritem.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = voucheritem.codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = voucheritem.idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = voucheritem.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = voucheritem.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = voucheritem.numDocumento;
                    oComando.Parameters.Add("@indConciliado", SqlDbType.VarChar, 1).Value = voucheritem.indConciliado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return voucheritem;
        }

        public Int32 EliminarVoucherItem(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)  
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarVoucherItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<VoucherItemE> ObtenerVoucherItemPorCodigo(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerVoucherItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public VoucherItemE RecuperarVoucherItemPorLinea(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem)
        {
            VoucherItemE voucheritem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarVoucherItemPorLinea", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = numItem;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            voucheritem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return voucheritem;
        }

        public List<VoucherItemE> VoucherDetalle(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_VoucherDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }
            return ListaVouchers;
        }

        public List<VoucherItemE> VoucherDetalleEgreso(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_VoucherDetalleEgreso", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> ReporteVoucherItemConceptoGasto(Int32 idEmpresa, String idMoneda, String AnioPeriodo, String MesPeriodoIni, String MesPeriodoFin)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteVoucherItemConceptoGasto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar,2).Value = idMoneda;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodoIni", SqlDbType.VarChar, 2).Value = MesPeriodoIni;
                    oComando.Parameters.Add("@MesPeriodoFin", SqlDbType.VarChar, 2).Value = MesPeriodoFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> ListaVoucherItemPorDcmtoCtaCte(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuenta, Int32 idPersona, String idDocumento , String Serie, String Numero)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListaVoucherItemPorDcmtoCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = Numero;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> ListarVoucherItemConceptoGasto(Int32 idEmpresa, String idMoneda, String AnioPeriodo, String MesPeriodo, String idConceptoGasto, String idCampana)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVoucherItemConceptoGasto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idConceptoGasto", SqlDbType.VarChar, 80).Value = idConceptoGasto;
                    oComando.Parameters.Add("@idCampana", SqlDbType.VarChar, 80).Value = idCampana;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> ReporteVoucherItemMovimientoEFectivo(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CbMovimientosEfectivo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@CuentaIni", SqlDbType.VarChar, 20).Value = CuentaIni;
                    oComando.Parameters.Add("@CuentaFin", SqlDbType.VarChar, 20).Value = CuentaFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> ReporteVoucherItemMovimientoCtaCte(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CbMovimientosCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@CuentaIni", SqlDbType.VarChar, 20).Value = CuentaIni;
                    oComando.Parameters.Add("@CuentaFin", SqlDbType.VarChar, 20).Value = CuentaFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> ReporteMovimientoBanco(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteMovimientoBanco", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@CuentaIni", SqlDbType.VarChar, 20).Value = CuentaIni;
                    oComando.Parameters.Add("@CuentaFin", SqlDbType.VarChar, 20).Value = CuentaFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> ListaVoucherItemActivacion(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String MesPeriodoFin)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListaVoucherItemActivacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@MesPeriodoFin", SqlDbType.VarChar, 2).Value = MesPeriodoFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> ListarVoucherItemPorCuenta(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVoucherItemPorCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> RegistroDeDiarioTxt(Int32 idEmpresa, Int32 idLocal, DateTime FechaIni, DateTime FechaFin, String NumVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroDeDiarioTxt", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = FechaIni;
                    oComando.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;
                    oComando.Parameters.Add("@NumVerPlanCuenta", SqlDbType.VarChar, 3).Value = NumVerPlanCuenta;
                    oComando.Parameters.Add("@idComprobanteInicial", SqlDbType.VarChar, 2).Value = idComprobanteInicial;
                    oComando.Parameters.Add("@idComprobanteFinal", SqlDbType.VarChar, 2).Value = idComprobanteFinal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> RepVoucherItemMovimientoCtaCteOpe(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CbMovimientosCtaCteOperativo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@CuentaIni", SqlDbType.VarChar, 20).Value = CuentaIni;
                    oComando.Parameters.Add("@CuentaFin", SqlDbType.VarChar, 20).Value = CuentaFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> RepVoucherItemMovimientoEFectivoOpe(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CbMovimientosEfectivoOperativo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@CuentaIni", SqlDbType.VarChar, 20).Value = CuentaIni;
                    oComando.Parameters.Add("@CuentaFin", SqlDbType.VarChar, 20).Value = CuentaFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public List<VoucherItemE> BuscarVoucherPorCtaContableTipo(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String codCuenta, String Tipo)
        {
            List<VoucherItemE> ListaVouchers = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BuscarVoucherPorCtaContableTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = Tipo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVouchers.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVouchers;
        }

        public Int32 ActualizarVoucherItemAuxiCcDoc(VoucherItemE voucheritem, String Tipo)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVoucherItemAuxiCcDoc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucheritem.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucheritem.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucheritem.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucheritem.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucheritem.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucheritem.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = voucheritem.numFile;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = voucheritem.numItem;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = Tipo;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = voucheritem.idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = voucheritem.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = voucheritem.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = voucheritem.numDocumento;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = voucheritem.idCCostos;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}