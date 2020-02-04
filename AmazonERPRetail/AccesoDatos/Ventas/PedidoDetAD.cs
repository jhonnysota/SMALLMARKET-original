using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PedidoDetAD : DbConection
    {

        public PedidoDetE LlenarDetallePedido(IDataReader oReader)
        {
            PedidoDetE pedidodet = new PedidoDetE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idPedido = oReader["idPedido"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPedido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idTipoPrecio = oReader["idTipoPrecio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoPrecio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.PrecioUnitario = oReader["PrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioConImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.PrecioConImpuesto = oReader["PrecioConImpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioConImpuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Dscto1 = oReader["Dscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Dscto2 = oReader["Dscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Dscto3 = oReader["Dscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.porDscto1 = oReader["porDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.porDscto2 = oReader["porDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.porDscto3 = oReader["porDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flgIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.flgIgv = oReader["flgIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flgIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Isc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Isc = oReader["Isc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Isc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='subTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.subTotal = oReader["subTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["subTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIsc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.porIsc = oReader["porIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIsc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idUMedida = oReader["idUMedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Stock'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Stock = oReader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Stock"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroOt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.nroOt = oReader["nroOt"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroOt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCalculo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.indCalculo = oReader["indCalculo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCalculo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoImpSelectivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.TipoImpSelectivo = oReader["TipoImpSelectivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoImpSelectivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Capacidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Capacidad = oReader["Capacidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Capacidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.tipDetraccion = oReader["tipDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.TasaDetraccion = oReader["TasaDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUnidadMed'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.desUnidadMed = oReader["desUnidadMed"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUnidadMed"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoMedAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.codTipoMedAlmacen = oReader["codTipoMedAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codTipoMedAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codUniMedAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.codUniMedAlmacen = oReader["codUniMedAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codUniMedAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUniAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.desUniAlmacen = oReader["desUniAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUniAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoMedEnvase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idTipoMedEnvase = oReader["idTipoMedEnvase"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoMedEnvase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUniMedEnvase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.idUniMedEnvase = oReader["idUniMedEnvase"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUniMedEnvase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUniEnvase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.desUniEnvase = oReader["desUniEnvase"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUniEnvase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticuloCompuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.desArticuloCompuesto = oReader["desArticuloCompuesto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticuloCompuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SiglaEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.SiglaEmpresa = oReader["SiglaEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SiglaEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.LoteAlmacen = oReader["LoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodBarras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.CodBarras = oReader["CodBarras"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodBarras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pedidodet.DesAlmacen = oReader["DesAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesAlmacen"]);

            return pedidodet;
        }

        public PedidoDetE InsertarPedidoNacionalDet(PedidoDetE pedidodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPedidoNacionalDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pedidodet.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = pedidodet.idLocal;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = pedidodet.idPedido;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = pedidodet.idItem;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = pedidodet.idArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar,250).Value = pedidodet.nomArticulo;
                    oComando.Parameters.Add("@idTipoPrecio", SqlDbType.Int).Value = pedidodet.idTipoPrecio;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = pedidodet.Cantidad;
                    oComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = pedidodet.PrecioUnitario;
                    oComando.Parameters.Add("@PrecioConImpuesto", SqlDbType.Decimal).Value = pedidodet.PrecioConImpuesto;
                    oComando.Parameters.Add("@Dscto1", SqlDbType.Decimal).Value = pedidodet.Dscto1;
                    oComando.Parameters.Add("@Dscto2", SqlDbType.Decimal).Value = pedidodet.Dscto2;
                    oComando.Parameters.Add("@Dscto3", SqlDbType.Decimal).Value = pedidodet.Dscto3;
                    oComando.Parameters.Add("@porDscto1", SqlDbType.Decimal).Value = pedidodet.porDscto1;
                    oComando.Parameters.Add("@porDscto2", SqlDbType.Decimal).Value = pedidodet.porDscto2;
                    oComando.Parameters.Add("@porDscto3", SqlDbType.Decimal).Value = pedidodet.porDscto3;
                    oComando.Parameters.Add("@flgIgv", SqlDbType.Bit).Value = pedidodet.flgIgv;
                    oComando.Parameters.Add("@Isc", SqlDbType.Decimal).Value = pedidodet.Isc;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = pedidodet.Igv;
                    oComando.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = pedidodet.subTotal;
                    oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = pedidodet.Total;
                    oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = pedidodet.porIsc;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = pedidodet.porIgv;
                    oComando.Parameters.Add("@idUMedida", SqlDbType.Int).Value = pedidodet.idUMedida;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = pedidodet.idTipoArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = pedidodet.idAlmacen;
                    oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = pedidodet.Stock;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = pedidodet.Lote;
                    oComando.Parameters.Add("@nroOt", SqlDbType.VarChar, 20).Value = pedidodet.nroOt;
                    oComando.Parameters.Add("@indCalculo", SqlDbType.Bit).Value = pedidodet.indCalculo;
                    oComando.Parameters.Add("@TipoImpSelectivo", SqlDbType.Char, 1).Value = pedidodet.TipoImpSelectivo;
                    oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = pedidodet.Capacidad;
                    oComando.Parameters.Add("@Contenido", SqlDbType.Decimal).Value = pedidodet.Contenido;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = pedidodet.indDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = pedidodet.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = pedidodet.TasaDetraccion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = pedidodet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return pedidodet;
        }

        public PedidoDetE ActualizarPedidoNacionalDet(PedidoDetE pedidodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPedidoNacionalDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pedidodet.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = pedidodet.idLocal;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = pedidodet.idPedido;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = pedidodet.idItem;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = pedidodet.idArticulo;
                    oComando.Parameters.Add("@nomArticulo", SqlDbType.VarChar, 250).Value = pedidodet.nomArticulo;
                    oComando.Parameters.Add("@idTipoPrecio", SqlDbType.Int).Value = pedidodet.idTipoPrecio;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = pedidodet.Cantidad;
                    oComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = pedidodet.PrecioUnitario;
                    oComando.Parameters.Add("@PrecioConImpuesto", SqlDbType.Decimal).Value = pedidodet.PrecioConImpuesto;
                    oComando.Parameters.Add("@Dscto1", SqlDbType.Decimal).Value = pedidodet.Dscto1;
                    oComando.Parameters.Add("@Dscto2", SqlDbType.Decimal).Value = pedidodet.Dscto2;
                    oComando.Parameters.Add("@Dscto3", SqlDbType.Decimal).Value = pedidodet.Dscto3;
                    oComando.Parameters.Add("@porDscto1", SqlDbType.Decimal).Value = pedidodet.porDscto1;
                    oComando.Parameters.Add("@porDscto2", SqlDbType.Decimal).Value = pedidodet.porDscto2;
                    oComando.Parameters.Add("@porDscto3", SqlDbType.Decimal).Value = pedidodet.porDscto3;
                    oComando.Parameters.Add("@flgIgv", SqlDbType.Bit).Value = pedidodet.flgIgv;
                    oComando.Parameters.Add("@Isc", SqlDbType.Decimal).Value = pedidodet.Isc;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = pedidodet.Igv;
                    oComando.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = pedidodet.subTotal;
                    oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = pedidodet.Total;
                    oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = pedidodet.porIsc;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = pedidodet.porIgv;
                    oComando.Parameters.Add("@idUMedida", SqlDbType.Int).Value = pedidodet.idUMedida;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = pedidodet.idTipoArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = pedidodet.idAlmacen;
                    oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = pedidodet.Stock;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = pedidodet.Lote;
                    oComando.Parameters.Add("@nroOt", SqlDbType.VarChar, 20).Value = pedidodet.nroOt;
                    oComando.Parameters.Add("@indCalculo", SqlDbType.Bit).Value = pedidodet.indCalculo;
                    oComando.Parameters.Add("@TipoImpSelectivo", SqlDbType.Char, 1).Value = pedidodet.TipoImpSelectivo;
                    oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = pedidodet.Capacidad;
                    oComando.Parameters.Add("@Contenido", SqlDbType.Decimal).Value = pedidodet.Contenido;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = pedidodet.indDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = pedidodet.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = pedidodet.TasaDetraccion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = pedidodet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return pedidodet;
        }

        public List<PedidoDetE> RecuperarPedidoNacionalDet(Int32 idEmpresa, Int32 idLocal, Int32 idPedido)
        {
            List<PedidoDetE> listaEntidad = new List<PedidoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarPedidoNacionalDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarDetallePedido(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<PedidoDetE> ListaPedidoDetPtoVta(Int32 idPedido)
        {
            List<PedidoDetE> listaEntidad = new List<PedidoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListaPedidoDetPtoVta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            PedidoDetE pedidoDet = LlenarDetallePedido(oReader);
                            pedidoDet.PrecioConDscto = pedidoDet.PrecioConImpuesto - pedidoDet.Dscto1;
                            listaEntidad.Add(pedidoDet);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public int EliminarPedidoNacionalDet(Int32 idEmpresa, Int32 idPedido)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPedidoNacionalDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
       }
    }

    
}