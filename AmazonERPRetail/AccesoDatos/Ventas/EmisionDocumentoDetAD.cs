using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class EmisionDocumentoDetAD : DbConection
    {

        public EmisionDocumentoDetE LlenarEntidad(IDataReader oReader)
        {
            EmisionDocumentoDetE emisiondocumentodet = new EmisionDocumentoDetE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='razonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.razonSocial = oReader["razonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["razonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Item = oReader["Item"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadUnit'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.CantidadUnit = oReader["CantidadUnit"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["CantidadUnit"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadFinal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.CantidadFinal = oReader["CantidadFinal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantidadFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioConImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PrecioConImpuesto = oReader["PrecioConImpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioConImpuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioSinImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PrecioSinImpuesto = oReader["PrecioSinImpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioSinImpuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Dscto1 = oReader["Dscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Dscto2 = oReader["Dscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Dscto3 = oReader["Dscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Comision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Comision = oReader["Comision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Comision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flgIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.flgIgv = oReader["flgIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flgIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porDscto1 = oReader["porDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porDscto2 = oReader["porDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porDscto3 = oReader["porDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porComision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porComision = oReader["porComision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porComision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadAtendida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.CantidadAtendida = oReader["CantidadAtendida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantidadAtendida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Isc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Isc = oReader["Isc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Isc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='subTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.subTotal = oReader["subTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["subTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIsc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porIsc = oReader["porIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIsc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUnidadMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idUnidadMedida = oReader["idUnidadMedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUnidadMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenProd'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.numOrdenProd = oReader["numOrdenProd"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenProd"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoImpSelectivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TipoImpSelectivo = oReader["TipoImpSelectivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoImpSelectivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Stock'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Stock = oReader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Stock"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoLista'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TipoLista = oReader["TipoLista"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoLista"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codLineaVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.codLineaVenta = oReader["codLineaVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codLineaVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contiene'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Contiene = oReader["Contiene"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contiene"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Capacidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Capacidad = oReader["Capacidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Capacidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.serDocumentoRef = oReader["serDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.fecDocumentoRef = oReader["fecDocumentoRef"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TotalRef = oReader["TotalRef"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idCampana = oReader["idCampana"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPercepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.indPercepcion = oReader["indPercepcion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPercepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoAfectoPerce'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.MontoAfectoPerce = oReader["MontoAfectoPerce"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoAfectoPerce"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoPercepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.MontoPercepcion = oReader["MontoPercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoPercepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idListaPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idListaPrecio = oReader["idListaPrecio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idListaPrecio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroOt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.nroOt = oReader["nroOt"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroOt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroOtItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.nroOtItem = oReader["nroOtItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroOtItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCalculo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.indCalculo = oReader["indCalculo"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCalculo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.DocumentoAlmacen = oReader["DocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["DocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.tipArticulo = oReader["tipArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.tipDetraccion = oReader["tipDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TasaDetraccion = oReader["TasaDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioSinImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PrecioCad = oReader["PrecioSinImpuesto"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["PrecioSinImpuesto"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioConImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PrecioIncCad = oReader["PrecioConImpuesto"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["PrecioConImpuesto"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='subTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.SubTotalCad = oReader["subTotal"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["subTotal"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porDcto1Cad = oReader["porDscto1"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["porDscto1"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TotalCad = oReader["Total"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["Total"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.desUMedida = oReader["desUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUMedidaCorta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.desUMedidaCorta = oReader["desUMedidaCorta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUMedidaCorta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoBrutoCad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PesoBrutoCad = oReader["PesoBrutoCad"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PesoBrutoCad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.CantFactura = oReader["CantFactura"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codBarra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.codBarra = oReader["codBarra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codBarra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desNomArtCompuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.desNomArtCompuesto = oReader["desNomArtCompuesto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desNomArtCompuesto"]);

            return  emisiondocumentodet;        
        }

        public EmisionDocumentoDetDetalleE LlenarEntidadDetalle(IDataReader oReader)
        {
            EmisionDocumentoDetDetalleE emisiondocumentodet = new EmisionDocumentoDetDetalleE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='razonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.razonSocial = oReader["razonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["razonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Item = oReader["Item"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadUnit'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.CantidadUnit = oReader["CantidadUnit"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["CantidadUnit"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadFinal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.CantidadFinal = oReader["CantidadFinal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantidadFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioConImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PrecioConImpuesto = oReader["PrecioConImpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioConImpuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioSinImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PrecioSinImpuesto = oReader["PrecioSinImpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioSinImpuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Dscto1 = oReader["Dscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Dscto2 = oReader["Dscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Dscto3 = oReader["Dscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Comision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Comision = oReader["Comision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Comision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flgIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.flgIgv = oReader["flgIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flgIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porDscto1 = oReader["porDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porDscto2 = oReader["porDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porDscto3 = oReader["porDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porComision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porComision = oReader["porComision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porComision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadAtendida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.CantidadAtendida = oReader["CantidadAtendida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantidadAtendida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Isc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Isc = oReader["Isc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Isc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='subTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.subTotal = oReader["subTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["subTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIsc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porIsc = oReader["porIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIsc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUnidadMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idUnidadMedida = oReader["idUnidadMedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUnidadMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idTipoMedida = oReader["idTipoMedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenProd'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.numOrdenProd = oReader["numOrdenProd"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenProd"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoImpSelectivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TipoImpSelectivo = oReader["TipoImpSelectivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoImpSelectivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Stock'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Stock = oReader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Stock"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoLista'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TipoLista = oReader["TipoLista"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoLista"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codLineaVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.codLineaVenta = oReader["codLineaVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codLineaVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contiene'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Contiene = oReader["Contiene"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contiene"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Capacidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.Capacidad = oReader["Capacidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Capacidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.serDocumentoRef = oReader["serDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.fecDocumentoRef = oReader["fecDocumentoRef"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TotalRef = oReader["TotalRef"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idCampana = oReader["idCampana"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPercepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.indPercepcion = oReader["indPercepcion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPercepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoAfectoPerce'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.MontoAfectoPerce = oReader["MontoAfectoPerce"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoAfectoPerce"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoPercepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.MontoPercepcion = oReader["MontoPercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoPercepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idListaPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idListaPrecio = oReader["idListaPrecio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idListaPrecio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroOt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.nroOt = oReader["nroOt"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroOt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroOtItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.nroOtItem = oReader["nroOtItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroOtItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCalculo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.indCalculo = oReader["indCalculo"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCalculo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.DocumentoAlmacen = oReader["DocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["DocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.tipArticulo = oReader["tipArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.tipDetraccion = oReader["tipDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TasaDetraccion = oReader["TasaDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioSinImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PrecioCad = oReader["PrecioSinImpuesto"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["PrecioSinImpuesto"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioConImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PrecioIncCad = oReader["PrecioConImpuesto"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["PrecioConImpuesto"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='subTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.SubTotalCad = oReader["subTotal"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["subTotal"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.porDcto1Cad = oReader["porDscto1"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["porDscto1"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.TotalCad = oReader["Total"] == DBNull.Value ? String.Empty : Convert.ToDecimal(oReader["Total"]).ToString("N2");

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.desUMedida = oReader["desUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoBrutoCad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.PesoBrutoCad = oReader["PesoBrutoCad"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PesoBrutoCad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.CantFactura = oReader["CantFactura"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codBarra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.codBarra = oReader["codBarra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codBarra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desNomArtCompuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentodet.desNomArtCompuesto = oReader["desNomArtCompuesto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desNomArtCompuesto"]);

            return emisiondocumentodet;
        }

        public EmisionDocumentoDetE InsertarEmisionDocumentoDet(EmisionDocumentoDetE emisiondocumentodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmisionDocumentoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentodet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentodet.idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentodet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumento;
					oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = emisiondocumentodet.Item;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = emisiondocumentodet.idAlmacen;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = emisiondocumentodet.idArticulo;
					oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 250).Value = emisiondocumentodet.nomArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = emisiondocumentodet.Lote;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = emisiondocumentodet.Cantidad;
					oComando.Parameters.Add("@CantidadUnit", SqlDbType.Int).Value = emisiondocumentodet.CantidadUnit;
					oComando.Parameters.Add("@CantidadFinal", SqlDbType.Decimal).Value = emisiondocumentodet.CantidadFinal;
					oComando.Parameters.Add("@PrecioConImpuesto", SqlDbType.Decimal).Value = emisiondocumentodet.PrecioConImpuesto;
					oComando.Parameters.Add("@PrecioSinImpuesto", SqlDbType.Decimal).Value = emisiondocumentodet.PrecioSinImpuesto;
					oComando.Parameters.Add("@Dscto1", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto1;
					oComando.Parameters.Add("@Dscto2", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto2;
					oComando.Parameters.Add("@Dscto3", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto3;
					oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = emisiondocumentodet.Comision;
					oComando.Parameters.Add("@porDscto1", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto1;
					oComando.Parameters.Add("@porDscto2", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto2;
					oComando.Parameters.Add("@porDscto3", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto3;
					oComando.Parameters.Add("@porComision", SqlDbType.Decimal).Value = emisiondocumentodet.porComision;
					oComando.Parameters.Add("@CantidadAtendida", SqlDbType.Decimal).Value = emisiondocumentodet.CantidadAtendida;
					oComando.Parameters.Add("@Isc", SqlDbType.Decimal).Value = emisiondocumentodet.Isc;
					oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = emisiondocumentodet.Igv;
					oComando.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = emisiondocumentodet.subTotal;
					oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = emisiondocumentodet.Total;
                    oComando.Parameters.Add("@flgIgv", SqlDbType.Bit).Value = emisiondocumentodet.flgIgv;
					oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = emisiondocumentodet.porIsc;
					oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = emisiondocumentodet.porIgv;
                    oComando.Parameters.Add("@idUnidadMedida", SqlDbType.Int).Value = emisiondocumentodet.idUnidadMedida;
					oComando.Parameters.Add("@numOrdenProd", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numOrdenProd;
					oComando.Parameters.Add("@TipoImpSelectivo", SqlDbType.Char, 1).Value = emisiondocumentodet.TipoImpSelectivo;
					oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = emisiondocumentodet.Stock;
					oComando.Parameters.Add("@TipoLista", SqlDbType.VarChar, 1).Value = emisiondocumentodet.TipoLista;
                    oComando.Parameters.Add("@codLineaVenta", SqlDbType.VarChar, 2).Value = emisiondocumentodet.codLineaVenta;
                    oComando.Parameters.Add("@Contiene", SqlDbType.Decimal).Value = emisiondocumentodet.Contiene;
                    oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = emisiondocumentodet.Capacidad;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = emisiondocumentodet.PesoUnitario;
					oComando.Parameters.Add("@idDocumentoRef", SqlDbType.Char, 2).Value = emisiondocumentodet.idDocumentoRef;
					oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumentodet.serDocumentoRef;
					oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumentoRef;
					oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = emisiondocumentodet.fecDocumentoRef;
					oComando.Parameters.Add("@TotalRef", SqlDbType.Decimal).Value = emisiondocumentodet.TotalRef;
					oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = emisiondocumentodet.idCampana;
					oComando.Parameters.Add("@indPercepcion", SqlDbType.Bit).Value = emisiondocumentodet.indPercepcion;
					oComando.Parameters.Add("@MontoAfectoPerce", SqlDbType.Decimal).Value = emisiondocumentodet.MontoAfectoPerce;
					oComando.Parameters.Add("@MontoPercepcion", SqlDbType.Decimal).Value = emisiondocumentodet.MontoPercepcion;
					oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = emisiondocumentodet.idListaPrecio;
                    oComando.Parameters.Add("@nroOt", SqlDbType.Int).Value = emisiondocumentodet.nroOt;
                    oComando.Parameters.Add("@nroOtItem", SqlDbType.Int).Value = emisiondocumentodet.nroOtItem;
                    oComando.Parameters.Add("@Peso", SqlDbType.VarChar, 10).Value = emisiondocumentodet.PesoBrutoCad;
                    oComando.Parameters.Add("@indCalculo", SqlDbType.Bit).Value = emisiondocumentodet.indCalculo;
                    oComando.Parameters.Add("@tipArticulo", SqlDbType.VarChar, 2).Value = emisiondocumentodet.tipArticulo;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = emisiondocumentodet.indDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = emisiondocumentodet.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = emisiondocumentodet.TasaDetraccion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = emisiondocumentodet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentodet;        
        }
        
        public EmisionDocumentoDetE ActualizarEmisionDocumentoDet(EmisionDocumentoDetE emisiondocumentodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisionDocumentoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentodet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentodet.idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentodet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumento;
					oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = emisiondocumentodet.Item;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = emisiondocumentodet.idAlmacen;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = emisiondocumentodet.idArticulo;
					oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 250).Value = emisiondocumentodet.nomArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = emisiondocumentodet.Lote;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = emisiondocumentodet.Cantidad;
					oComando.Parameters.Add("@CantidadUnit", SqlDbType.Int).Value = emisiondocumentodet.CantidadUnit;
					oComando.Parameters.Add("@CantidadFinal", SqlDbType.Decimal).Value = emisiondocumentodet.CantidadFinal;
					oComando.Parameters.Add("@PrecioConImpuesto", SqlDbType.Decimal).Value = emisiondocumentodet.PrecioConImpuesto;
					oComando.Parameters.Add("@PrecioSinImpuesto", SqlDbType.Decimal).Value = emisiondocumentodet.PrecioSinImpuesto;
					oComando.Parameters.Add("@Dscto1", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto1;
					oComando.Parameters.Add("@Dscto2", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto2;
					oComando.Parameters.Add("@Dscto3", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto3;
					oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = emisiondocumentodet.Comision;
					oComando.Parameters.Add("@porDscto1", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto1;
					oComando.Parameters.Add("@porDscto2", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto2;
					oComando.Parameters.Add("@porDscto3", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto3;
					oComando.Parameters.Add("@porComision", SqlDbType.Decimal).Value = emisiondocumentodet.porComision;
					oComando.Parameters.Add("@CantidadAtendida", SqlDbType.Decimal).Value = emisiondocumentodet.CantidadAtendida;
					oComando.Parameters.Add("@Isc", SqlDbType.Decimal).Value = emisiondocumentodet.Isc;
					oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = emisiondocumentodet.Igv;
					oComando.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = emisiondocumentodet.subTotal;
					oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = emisiondocumentodet.Total;
                    oComando.Parameters.Add("@flgIgv", SqlDbType.Bit).Value = emisiondocumentodet.flgIgv;
					oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = emisiondocumentodet.porIsc;
					oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = emisiondocumentodet.porIgv;
					oComando.Parameters.Add("@idUnidaMedida", SqlDbType.Int).Value = emisiondocumentodet.idUnidadMedida;
					oComando.Parameters.Add("@numOrdenProd", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numOrdenProd;
					oComando.Parameters.Add("@TipoImpSelectivo", SqlDbType.Char, 1).Value = emisiondocumentodet.TipoImpSelectivo;
					oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = emisiondocumentodet.Stock;
					oComando.Parameters.Add("@TipoLista", SqlDbType.VarChar, 1).Value = emisiondocumentodet.TipoLista;
                    oComando.Parameters.Add("@codLineaVenta", SqlDbType.VarChar, 2).Value = emisiondocumentodet.codLineaVenta;
					oComando.Parameters.Add("@Contiene", SqlDbType.Decimal).Value = emisiondocumentodet.Contiene;
					oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = emisiondocumentodet.PesoUnitario;
					oComando.Parameters.Add("@idDocumentoRef", SqlDbType.Char, 2).Value = emisiondocumentodet.idDocumentoRef;
					oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumentodet.serDocumentoRef;
					oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumentoRef;
					oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = emisiondocumentodet.fecDocumentoRef;
					oComando.Parameters.Add("@TotalRef", SqlDbType.Decimal).Value = emisiondocumentodet.TotalRef;
					oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = emisiondocumentodet.idCampana;
					oComando.Parameters.Add("@indPercepcion", SqlDbType.Bit).Value = emisiondocumentodet.indPercepcion;
					oComando.Parameters.Add("@MontoAfectoPerce", SqlDbType.Decimal).Value = emisiondocumentodet.MontoAfectoPerce;
					oComando.Parameters.Add("@MontoPercepcion", SqlDbType.Decimal).Value = emisiondocumentodet.MontoPercepcion;
					oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = emisiondocumentodet.idListaPrecio;
                    oComando.Parameters.Add("@nroOt", SqlDbType.Int).Value = emisiondocumentodet.nroOt;
                    oComando.Parameters.Add("@nroOtItem", SqlDbType.Int).Value = emisiondocumentodet.nroOtItem;
                    oComando.Parameters.Add("@Peso", SqlDbType.VarChar, 10).Value = emisiondocumentodet.PesoBrutoCad;
                    oComando.Parameters.Add("@indCalculo", SqlDbType.Bit).Value = emisiondocumentodet.indCalculo;
                    oComando.Parameters.Add("@tipArticulo", SqlDbType.VarChar, 2).Value = emisiondocumentodet.tipArticulo;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = emisiondocumentodet.indDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = emisiondocumentodet.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = emisiondocumentodet.TasaDetraccion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumentodet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentodet;
        }        

        public Int32 EliminarEmisionDocumentoDet(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEmisionDocumentoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EmisionDocumentoDetE> ObtenerEmisionDocumentoDet(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            List<EmisionDocumentoDetE> ListaItems = new List<EmisionDocumentoDetE>();

            using (SqlConnection oConexion = ConexionSql())     
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmisionDocumentoDet", oConexion))
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
                            ListaItems.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaItems;
        }

        public List<EmisionDocumentoDetE> ObtenerEmisionDocumentoDet2(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            List<EmisionDocumentoDetE> ListaItems = new List<EmisionDocumentoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmisionDocumentoDet2", oConexion))
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
                            ListaItems.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaItems;
        }

        public EmisionDocumentoDetE ObtenerEmisionDocumentoDetItem(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Item)
        {        
            EmisionDocumentoDetE emisiondocumentodet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmisionDocumentoDetItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
					oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = Item;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            emisiondocumentodet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return emisiondocumentodet;        
        }

        public decimal ObtenerCantidadDetalle(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            decimal resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCantidadDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    resp = Convert.ToDecimal(oComando.ExecuteScalar());
                }
            }

            return resp;
        }

        public Int32 UpdateVenEmiDetDocAlmacen(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Item, Int32 idAlmacen, Int32 DocumentoAlmacen, String Usuario)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UpdateVenEmiDetDocAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = Item;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@DocumentoAlmacen", SqlDbType.Int).Value = DocumentoAlmacen;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public List<EmisionDocumentoDetE> ReporteGuiaPorFacturar(Int32 idEmpresa, Int32 idLocal, DateTime Desde, DateTime Hasta)
        {
            List<EmisionDocumentoDetE> ListaItems = new List<EmisionDocumentoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteGuiaPorFacturar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Desde", SqlDbType.DateTime).Value = Desde;
                    oComando.Parameters.Add("@Hasta", SqlDbType.DateTime).Value = Hasta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaItems.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaItems;
        }

        public EmisionDocumentoDetE ActualizarDetraccionDetEmisDocu(EmisionDocumentoDetE emisiondocumentodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarDetraccionDetEmisDocu", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentodet.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentodet.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentodet.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumento;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = emisiondocumentodet.Item;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = emisiondocumentodet.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = emisiondocumentodet.TasaDetraccion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumentodet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentodet;
        }

        public EmisionDocumentoDetDetalleE InsertarEmisionDocumentoDetallado(EmisionDocumentoDetDetalleE emisiondocumentodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmisionDocumentoDetallado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentodet.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentodet.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentodet.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumento;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = emisiondocumentodet.Item;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = emisiondocumentodet.idAlmacen;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = emisiondocumentodet.idArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 250).Value = emisiondocumentodet.nomArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = emisiondocumentodet.Lote;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = emisiondocumentodet.Cantidad;
                    oComando.Parameters.Add("@CantidadUnit", SqlDbType.Int).Value = emisiondocumentodet.CantidadUnit;
                    oComando.Parameters.Add("@CantidadFinal", SqlDbType.Decimal).Value = emisiondocumentodet.CantidadFinal;
                    oComando.Parameters.Add("@PrecioConImpuesto", SqlDbType.Decimal).Value = emisiondocumentodet.PrecioConImpuesto;
                    oComando.Parameters.Add("@PrecioSinImpuesto", SqlDbType.Decimal).Value = emisiondocumentodet.PrecioSinImpuesto;
                    oComando.Parameters.Add("@Dscto1", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto1;
                    oComando.Parameters.Add("@Dscto2", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto2;
                    oComando.Parameters.Add("@Dscto3", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto3;
                    oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = emisiondocumentodet.Comision;
                    oComando.Parameters.Add("@porDscto1", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto1;
                    oComando.Parameters.Add("@porDscto2", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto2;
                    oComando.Parameters.Add("@porDscto3", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto3;
                    oComando.Parameters.Add("@porComision", SqlDbType.Decimal).Value = emisiondocumentodet.porComision;
                    oComando.Parameters.Add("@CantidadAtendida", SqlDbType.Decimal).Value = emisiondocumentodet.CantidadAtendida;
                    oComando.Parameters.Add("@Isc", SqlDbType.Decimal).Value = emisiondocumentodet.Isc;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = emisiondocumentodet.Igv;
                    oComando.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = emisiondocumentodet.subTotal;
                    oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = emisiondocumentodet.Total;
                    oComando.Parameters.Add("@flgIgv", SqlDbType.Bit).Value = emisiondocumentodet.flgIgv;
                    oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = emisiondocumentodet.porIsc;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = emisiondocumentodet.porIgv;
                    oComando.Parameters.Add("@idTipoMedida", SqlDbType.Int).Value = emisiondocumentodet.idTipoMedida;
                    oComando.Parameters.Add("@idUnidadMedida", SqlDbType.Int).Value = emisiondocumentodet.idUnidadMedida;
                    oComando.Parameters.Add("@numOrdenProd", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numOrdenProd;
                    oComando.Parameters.Add("@TipoImpSelectivo", SqlDbType.Char, 1).Value = emisiondocumentodet.TipoImpSelectivo;
                    oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = emisiondocumentodet.Stock;
                    oComando.Parameters.Add("@TipoLista", SqlDbType.VarChar, 1).Value = emisiondocumentodet.TipoLista;
                    oComando.Parameters.Add("@codLineaVenta", SqlDbType.VarChar, 2).Value = emisiondocumentodet.codLineaVenta;
                    oComando.Parameters.Add("@Contiene", SqlDbType.Decimal).Value = emisiondocumentodet.Contiene;
                    oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = emisiondocumentodet.Capacidad;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = emisiondocumentodet.PesoUnitario;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.Char, 2).Value = emisiondocumentodet.idDocumentoRef;
                    oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumentodet.serDocumentoRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumentoRef;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = emisiondocumentodet.fecDocumentoRef;
                    oComando.Parameters.Add("@TotalRef", SqlDbType.Decimal).Value = emisiondocumentodet.TotalRef;
                    oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = emisiondocumentodet.idCampana;
                    oComando.Parameters.Add("@indPercepcion", SqlDbType.Bit).Value = emisiondocumentodet.indPercepcion;
                    oComando.Parameters.Add("@MontoAfectoPerce", SqlDbType.Decimal).Value = emisiondocumentodet.MontoAfectoPerce;
                    oComando.Parameters.Add("@MontoPercepcion", SqlDbType.Decimal).Value = emisiondocumentodet.MontoPercepcion;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = emisiondocumentodet.idListaPrecio;
                    oComando.Parameters.Add("@nroOt", SqlDbType.Int).Value = emisiondocumentodet.nroOt;
                    oComando.Parameters.Add("@nroOtItem", SqlDbType.Int).Value = emisiondocumentodet.nroOtItem;
                    oComando.Parameters.Add("@Peso", SqlDbType.VarChar, 10).Value = emisiondocumentodet.PesoBrutoCad;
                    oComando.Parameters.Add("@indCalculo", SqlDbType.Bit).Value = emisiondocumentodet.indCalculo;
                    oComando.Parameters.Add("@tipArticulo", SqlDbType.VarChar, 2).Value = emisiondocumentodet.tipArticulo;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = emisiondocumentodet.indDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = emisiondocumentodet.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = emisiondocumentodet.TasaDetraccion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = emisiondocumentodet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentodet;
        }

        public EmisionDocumentoDetDetalleE ActualizarEmisionDocumentoDetallado(EmisionDocumentoDetDetalleE emisiondocumentodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisionDocumentoDetallado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentodet.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentodet.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentodet.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumento;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = emisiondocumentodet.Item;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = emisiondocumentodet.idAlmacen;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = emisiondocumentodet.idArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 250).Value = emisiondocumentodet.nomArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = emisiondocumentodet.Lote;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = emisiondocumentodet.Cantidad;
                    oComando.Parameters.Add("@CantidadUnit", SqlDbType.Int).Value = emisiondocumentodet.CantidadUnit;
                    oComando.Parameters.Add("@CantidadFinal", SqlDbType.Decimal).Value = emisiondocumentodet.CantidadFinal;
                    oComando.Parameters.Add("@PrecioConImpuesto", SqlDbType.Decimal).Value = emisiondocumentodet.PrecioConImpuesto;
                    oComando.Parameters.Add("@PrecioSinImpuesto", SqlDbType.Decimal).Value = emisiondocumentodet.PrecioSinImpuesto;
                    oComando.Parameters.Add("@Dscto1", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto1;
                    oComando.Parameters.Add("@Dscto2", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto2;
                    oComando.Parameters.Add("@Dscto3", SqlDbType.Decimal).Value = emisiondocumentodet.Dscto3;
                    oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = emisiondocumentodet.Comision;
                    oComando.Parameters.Add("@porDscto1", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto1;
                    oComando.Parameters.Add("@porDscto2", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto2;
                    oComando.Parameters.Add("@porDscto3", SqlDbType.Decimal).Value = emisiondocumentodet.porDscto3;
                    oComando.Parameters.Add("@porComision", SqlDbType.Decimal).Value = emisiondocumentodet.porComision;
                    oComando.Parameters.Add("@CantidadAtendida", SqlDbType.Decimal).Value = emisiondocumentodet.CantidadAtendida;
                    oComando.Parameters.Add("@Isc", SqlDbType.Decimal).Value = emisiondocumentodet.Isc;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = emisiondocumentodet.Igv;
                    oComando.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = emisiondocumentodet.subTotal;
                    oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = emisiondocumentodet.Total;
                    oComando.Parameters.Add("@flgIgv", SqlDbType.Bit).Value = emisiondocumentodet.flgIgv;
                    oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = emisiondocumentodet.porIsc;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = emisiondocumentodet.porIgv;
                    oComando.Parameters.Add("@idTipoMedida", SqlDbType.Int).Value = emisiondocumentodet.idTipoMedida;
                    oComando.Parameters.Add("@idUnidaMedida", SqlDbType.Int).Value = emisiondocumentodet.idUnidadMedida;
                    oComando.Parameters.Add("@numOrdenProd", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numOrdenProd;
                    oComando.Parameters.Add("@TipoImpSelectivo", SqlDbType.Char, 1).Value = emisiondocumentodet.TipoImpSelectivo;
                    oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = emisiondocumentodet.Stock;
                    oComando.Parameters.Add("@TipoLista", SqlDbType.VarChar, 1).Value = emisiondocumentodet.TipoLista;
                    oComando.Parameters.Add("@codLineaVenta", SqlDbType.VarChar, 2).Value = emisiondocumentodet.codLineaVenta;
                    oComando.Parameters.Add("@Contiene", SqlDbType.Decimal).Value = emisiondocumentodet.Contiene;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = emisiondocumentodet.PesoUnitario;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.Char, 2).Value = emisiondocumentodet.idDocumentoRef;
                    oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumentodet.serDocumentoRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumentodet.numDocumentoRef;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = emisiondocumentodet.fecDocumentoRef;
                    oComando.Parameters.Add("@TotalRef", SqlDbType.Decimal).Value = emisiondocumentodet.TotalRef;
                    oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = emisiondocumentodet.idCampana;
                    oComando.Parameters.Add("@indPercepcion", SqlDbType.Bit).Value = emisiondocumentodet.indPercepcion;
                    oComando.Parameters.Add("@MontoAfectoPerce", SqlDbType.Decimal).Value = emisiondocumentodet.MontoAfectoPerce;
                    oComando.Parameters.Add("@MontoPercepcion", SqlDbType.Decimal).Value = emisiondocumentodet.MontoPercepcion;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = emisiondocumentodet.idListaPrecio;
                    oComando.Parameters.Add("@nroOt", SqlDbType.Int).Value = emisiondocumentodet.nroOt;
                    oComando.Parameters.Add("@nroOtItem", SqlDbType.Int).Value = emisiondocumentodet.nroOtItem;
                    oComando.Parameters.Add("@Peso", SqlDbType.VarChar, 10).Value = emisiondocumentodet.PesoBrutoCad;
                    oComando.Parameters.Add("@indCalculo", SqlDbType.Bit).Value = emisiondocumentodet.indCalculo;
                    oComando.Parameters.Add("@tipArticulo", SqlDbType.VarChar, 2).Value = emisiondocumentodet.tipArticulo;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = emisiondocumentodet.indDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = emisiondocumentodet.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = emisiondocumentodet.TasaDetraccion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumentodet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentodet;
        }

        public Int32 UpdateVenEmiDetalladoDocAlmacen(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Item, Int32 idAlmacen, Int32 DocumentoAlmacen, String Usuario)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UpdateVenEmiDetalladoDocAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = Item;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@DocumentoAlmacen", SqlDbType.Int).Value = DocumentoAlmacen;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public List<EmisionDocumentoDetDetalleE> ObtenerEmisionDocumentoDetallado(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            List<EmisionDocumentoDetDetalleE> ListaItems = new List<EmisionDocumentoDetDetalleE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmisionDocumentoDetallado", oConexion))
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
                            ListaItems.Add(LlenarEntidadDetalle(oReader));
                        }
                    }
                }
            }

            return ListaItems;
        }

        public EmisionDocumentoDetDetalleE ObtenerEmisionDocumentoDet(int v, int idLocal, string numSerie, string numDocumento)
        {
            throw new NotImplementedException();
        }
    }
}