using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PedidoCabAD : DbConection
    {

        public PedidoCabE LlenarPedido(IDataReader oReader)
        {
            PedidoCabE oPedido = new PedidoCabE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idPedido = oReader["idPedido"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPedido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPedidoCad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.codPedidoCad = oReader["codPedidoCad"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPedidoCad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FecPedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.FecPedido = oReader["FecPedido"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["FecPedido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FecCotizacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.FecCotizacion = oReader["FecCotizacion"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["FecCotizacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FecEntrega'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.FecEntrega = oReader["FecEntrega"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["FecEntrega"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idNotificar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idNotificar = oReader["idNotificar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idNotificar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idFacturar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idFacturar = oReader["idFacturar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idFacturar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Indicaciones'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.Indicaciones = oReader["Indicaciones"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Indicaciones"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroGuia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.NroGuia = oReader["NroGuia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroGuia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FecFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.FecFactura = oReader["FecFactura"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["FecFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.nroFactura = oReader["nroFactura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idFormaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idFormaPago = oReader["idFormaPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idFormaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idTipCondicion = oReader["idTipCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipCondicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idCondicion = oReader["idCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCondicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEstablecimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idEstablecimiento = oReader["idEstablecimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idZona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idZona = oReader["idZona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idZona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.Tipo = oReader["Tipo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Tipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totsubTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.totsubTotal = oReader["totsubTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totsubTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.totDscto1 = oReader["totDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.totDscto2 = oReader["totDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.totDscto3 = oReader["totDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totIsc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.totIsc = oReader["totIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totIsc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.totIgv = oReader["totIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.totTotal = oReader["totTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Redondeo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.Redondeo = oReader["Redondeo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Redondeo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSucursalCliente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idSucursalCliente = oReader["idSucursalCliente"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSucursalCliente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuntoLlegada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.PuntoLlegada = oReader["PuntoLlegada"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PuntoLlegada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuntoPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.PuntoPartida = oReader["PuntoPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PuntoPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.TipoDoc = oReader["TipoDoc"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTransporte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idTransporte = oReader["idTransporte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTransporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCotPed'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.indCotPed = oReader["indCotPed"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCotPed"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPedidoEnlace'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idPedidoEnlace = oReader["idPedidoEnlace"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPedidoEnlace"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDivision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idDivision = oReader["idDivision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDivision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CorreoEnviado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.CorreoEnviado = oReader["CorreoEnviado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["CorreoEnviado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.fechaRegistro = oReader["fechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.fechaModificacion = oReader["fechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaModificacion"]);

            ////////////////////////////    Extensiones  //////////////////////////////////////////////////////////////////////////////////////////////////
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desNotificador'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.desNotificador = oReader["desNotificador"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desNotificador"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFacturar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.desFacturar = oReader["desFacturar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFacturar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionCompleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.DireccionCompleta = oReader["DireccionCompleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionCompleta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dirAlmacenIngreso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.dirAlmacenIngreso = oReader["dirAlmacenIngreso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["dirAlmacenIngreso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Vendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.Vendedor = oReader["Vendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Vendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.numDocVendedor = oReader["numDocVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucCliente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.RucCliente = oReader["RucCliente"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucCliente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucNotificador'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.RucNotificador = oReader["RucNotificador"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucNotificador"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.desCondicion = oReader["desCondicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCondicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dirNotificador'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.dirNotificador = oReader["dirNotificador"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["dirNotificador"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NemoTipoDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.NemoTipoDoc = oReader["NemoTipoDoc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NemoTipoDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.numOrdenCompra = oReader["numOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialTransporte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.RazonSocialTransporte = oReader["RazonSocialTransporte"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialTransporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucTransporte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.RucTransporte = oReader["RucTransporte"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucTransporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='telVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.telVendedor = oReader["telVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["telVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EmailVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.EmailVendedor = oReader["EmailVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EmailVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.DesEstado = oReader["DesEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oPedido.idTipoPre = oReader["idTipoPrecio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoPrecio"]);


            return oPedido;
        }

        public PedidoCabE InsertarPedidoCabNacional(PedidoCabE pedidocab)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPedidoCabNacional", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pedidocab.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = pedidocab.idLocal;
                    oComando.Parameters.Add("@codPedidoCad", SqlDbType.VarChar, 20).Value = pedidocab.codPedidoCad;
                    oComando.Parameters.Add("@FecCotizacion", SqlDbType.VarChar, 8).Value = pedidocab.FecCotizacion;
                    oComando.Parameters.Add("@FecEntrega", SqlDbType.VarChar, 8).Value = pedidocab.FecEntrega;
                    oComando.Parameters.Add("@idNotificar", SqlDbType.Int).Value = pedidocab.idNotificar;
                    oComando.Parameters.Add("@idFacturar", SqlDbType.Int).Value = pedidocab.idFacturar;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = pedidocab.idMoneda;
                    oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = pedidocab.Observacion;
                    oComando.Parameters.Add("@Indicaciones", SqlDbType.VarChar, 500).Value = pedidocab.Indicaciones;
                    oComando.Parameters.Add("@idFormaPago", SqlDbType.Int).Value = pedidocab.idFormaPago;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = pedidocab.idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = pedidocab.idCondicion;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = pedidocab.idVendedor;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = pedidocab.idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = pedidocab.idZona;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Bit).Value = pedidocab.Tipo;
                    oComando.Parameters.Add("@totsubTotal", SqlDbType.Decimal).Value = pedidocab.totsubTotal;
                    oComando.Parameters.Add("@totDscto1", SqlDbType.Decimal).Value = pedidocab.totDscto1;
                    oComando.Parameters.Add("@totDscto2", SqlDbType.Decimal).Value = pedidocab.totDscto2;
                    oComando.Parameters.Add("@totDscto3", SqlDbType.Decimal).Value = pedidocab.totDscto3;
                    oComando.Parameters.Add("@totIsc", SqlDbType.Decimal).Value = pedidocab.totIsc;
                    oComando.Parameters.Add("@totIgv", SqlDbType.Decimal).Value = pedidocab.totIgv;
                    oComando.Parameters.Add("@totTotal", SqlDbType.Decimal).Value = pedidocab.totTotal;
                    oComando.Parameters.Add("@idSucursalCliente", SqlDbType.Int).Value = pedidocab.idSucursalCliente;
                    oComando.Parameters.Add("@PuntoPartida", SqlDbType.VarChar, 400).Value = pedidocab.PuntoPartida;
                    oComando.Parameters.Add("@PuntoLlegada", SqlDbType.VarChar, 400).Value = pedidocab.PuntoLlegada;
                    oComando.Parameters.Add("@TipoDoc", SqlDbType.Int).Value = pedidocab.TipoDoc;
                    oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = pedidocab.idTransporte;
                    oComando.Parameters.Add("@indCotPed", SqlDbType.Char, 1).Value = pedidocab.indCotPed;
                    oComando.Parameters.Add("@idPedidoEnlace", SqlDbType.Int).Value = pedidocab.idPedidoEnlace;
                    oComando.Parameters.Add("@idDivision", SqlDbType.Int).Value = pedidocab.idDivision;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = pedidocab.UsuarioRegistro;

                    oConexion.Open();
                    pedidocab.idPedido = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return pedidocab;
        }

        public PedidoCabE ActualizarPedidoCabNacional(PedidoCabE pedidocab)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPedidoCabNacional", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pedidocab.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = pedidocab.idLocal;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = pedidocab.idPedido;
                    oComando.Parameters.Add("@codPedidoCad", SqlDbType.VarChar, 20).Value = pedidocab.codPedidoCad;
                    oComando.Parameters.Add("@FecCotizacion", SqlDbType.VarChar, 8).Value = pedidocab.FecCotizacion;
                    oComando.Parameters.Add("@FecEntrega", SqlDbType.VarChar, 8).Value = pedidocab.FecEntrega;
                    oComando.Parameters.Add("@idNotificar", SqlDbType.Int).Value = pedidocab.idNotificar;
                    oComando.Parameters.Add("@idFacturar", SqlDbType.Int).Value = pedidocab.idFacturar;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = pedidocab.idMoneda;
                    oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = pedidocab.Observacion;
                    oComando.Parameters.Add("@Indicaciones", SqlDbType.VarChar, 500).Value = pedidocab.Indicaciones;
                    oComando.Parameters.Add("@idFormaPago", SqlDbType.Int).Value = pedidocab.idFormaPago;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = pedidocab.idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = pedidocab.idCondicion;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = pedidocab.idVendedor;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = pedidocab.idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = pedidocab.idZona;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Bit).Value = pedidocab.Tipo;
                    oComando.Parameters.Add("@totsubTotal", SqlDbType.Decimal).Value = pedidocab.totsubTotal;
                    oComando.Parameters.Add("@totDscto1", SqlDbType.Decimal).Value = pedidocab.totDscto1;
                    oComando.Parameters.Add("@totDscto2", SqlDbType.Decimal).Value = pedidocab.totDscto2;
                    oComando.Parameters.Add("@totDscto3", SqlDbType.Decimal).Value = pedidocab.totDscto3;
                    oComando.Parameters.Add("@totIsc", SqlDbType.Decimal).Value = pedidocab.totIsc;
                    oComando.Parameters.Add("@totIgv", SqlDbType.Decimal).Value = pedidocab.totIgv;
                    oComando.Parameters.Add("@totTotal", SqlDbType.Decimal).Value = pedidocab.totTotal;
                    oComando.Parameters.Add("@idSucursalCliente", SqlDbType.Int).Value = pedidocab.idSucursalCliente;
                    oComando.Parameters.Add("@PuntoPartida", SqlDbType.VarChar, 400).Value = pedidocab.PuntoPartida;
                    oComando.Parameters.Add("@PuntoLlegada", SqlDbType.VarChar, 400).Value = pedidocab.PuntoLlegada;
                    oComando.Parameters.Add("@TipoDoc", SqlDbType.Int).Value = pedidocab.TipoDoc;
                    oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = pedidocab.idTransporte;
                    oComando.Parameters.Add("@indCotPed", SqlDbType.Char, 1).Value = pedidocab.indCotPed;
                    oComando.Parameters.Add("@idPedidoEnlace", SqlDbType.Int).Value = pedidocab.idPedidoEnlace;
                    oComando.Parameters.Add("@idDivision", SqlDbType.Int).Value = pedidocab.idDivision;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = pedidocab.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return pedidocab;
        }

        public PedidoCabE RecuperarPedidoCabNacional(Int32 idEmpresa, Int32 idLocal, Int32 idPedido)
        {
            PedidoCabE pedidocab = null;
       
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarPedidoCabNacional", oConexion))
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
                            pedidocab = LlenarPedido(oReader);
                        }
                    }
                }
            }

            return pedidocab;
        }

        public List<PedidoCabE> ListarPedidoNacional(int idEmpresa, int idLocal, string codPedidoCad, string fecInicial, string fecFinal, string RazonSocial, string TipoFecha, int idVendedor, string Estado)
        {
            List<PedidoCabE> listaEntidad = new List<PedidoCabE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPedidoNacional", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@codPedidoCad", SqlDbType.VarChar, 20).Value = codPedidoCad;
                    oComando.Parameters.Add("@fecInicial", SqlDbType.VarChar, 8).Value = fecInicial;
                    oComando.Parameters.Add("@fecFinal", SqlDbType.VarChar, 8).Value = fecFinal;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = RazonSocial;
                    oComando.Parameters.Add("@TipoFecha", SqlDbType.Char, 1).Value = TipoFecha;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarPedido(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public Int32 CerrarPedido(Int32 idEmpresa, Int32 idPedido, String Estado)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CerrarPedido", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public String ObtenerUltimoNroPedido(Int32 idEmpresa, Int32 idLocal, String indCotPed)
        {
            String NroPed =  "0";

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNroPedido", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@indCotPed", SqlDbType.Char, 1).Value = indCotPed;

                    oConexion.Open();
                    NroPed = oComando.ExecuteScalar().ToString();
                }
            }

            return NroPed;
        }

        public String GenerarPedidoOrdenCompra(Int32 idEmpresa, Int32 idLocal, Int32 idPedido, String Usuario)
        {
            PedidoCabE oPedido = new PedidoCabE();
            String resp = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarPedidoOrdenCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            oPedido = LlenarPedido(oReader);
                            resp = oPedido.numOrdenCompra;
                        }
                    }
                }
            }

            return resp;
        }

        public PedidoCabE ActualizarDocumentosPed(PedidoCabE pedidocab)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarDocumentosPed", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pedidocab.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = pedidocab.idLocal;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = pedidocab.idPedido;
                    oComando.Parameters.Add("@NroGuia", SqlDbType.VarChar, 20).Value = pedidocab.NroGuia;
                    oComando.Parameters.Add("@nroFactura", SqlDbType.VarChar, 20).Value = pedidocab.nroFactura;
                    oComando.Parameters.Add("@fecFactura", SqlDbType.VarChar, 8).Value = pedidocab.FecFactura == (null) ? null: pedidocab.FecFactura ;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = pedidocab.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return pedidocab;
        }

        public Int32 EliminarTodoPedido(Int32 idEmpresa, Int32 idPedido, Int32 idLocal)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTodoPedido", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarEnvio(Int32 idPedido, Boolean CorreoEnviado)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEnvio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;
                    oComando.Parameters.Add("@CorreoEnviado", SqlDbType.Bit).Value = CorreoEnviado;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PedidoCabE> ListarPedidosPorCliente(Int32 idEmpresa, Int32 idLocal, Int32 idCliente)
        {
            List<PedidoCabE> listaEntidad = new List<PedidoCabE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPedidosPorCliente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarPedido(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public Int32 ConvertirCotiPed(Int32 idPedido)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConvertirCotiPed", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        #region Para el Punto de Venta

        public String GenerarNroPedido(Int32 IdEmpresa, string FecPedido)
        {
            String NroPed = "0";

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNroPedido", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = IdEmpresa;
                    oComando.Parameters.Add("@FecPedido", SqlDbType.VarChar, 8).Value = FecPedido;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read() && oReader.HasRows)
                        {
                            NroPed = oReader["CodPedido"].ToString();
                        }
                    }
                }
            }

            return NroPed;
        }

        public PedidoCabE InsertarPedidoPtoVta(PedidoCabE pedidocab, DataTable oDt)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPedidoPtoVta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pedidocab.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = pedidocab.idLocal;
                    oComando.Parameters.Add("@codPedidoCad", SqlDbType.VarChar, 20).Value = pedidocab.codPedidoCad;
                    oComando.Parameters.Add("@FecPedido", SqlDbType.VarChar, 8).Value = pedidocab.FecPedido;
                    oComando.Parameters.Add("@idFacturar", SqlDbType.Int).Value = pedidocab.idFacturar;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = pedidocab.idMoneda;
                    oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = pedidocab.Observacion;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = pedidocab.idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = pedidocab.idCondicion;
                    oComando.Parameters.Add("@totsubTotal", SqlDbType.Decimal).Value = pedidocab.totsubTotal;
                    oComando.Parameters.Add("@totDscto1", SqlDbType.Decimal).Value = pedidocab.totDscto1;
                    oComando.Parameters.Add("@totDscto2", SqlDbType.Decimal).Value = pedidocab.totDscto2;
                    oComando.Parameters.Add("@totDscto3", SqlDbType.Decimal).Value = pedidocab.totDscto3;
                    oComando.Parameters.Add("@totIsc", SqlDbType.Decimal).Value = pedidocab.totIsc;
                    oComando.Parameters.Add("@totIgv", SqlDbType.Decimal).Value = pedidocab.totIgv;
                    oComando.Parameters.Add("@totTotal", SqlDbType.Decimal).Value = pedidocab.totTotal;
                    oComando.Parameters.Add("@Redondeo", SqlDbType.Decimal).Value = pedidocab.Redondeo;
                    oComando.Parameters.Add("@TipoDoc", SqlDbType.Int).Value = pedidocab.TipoDoc;
                    oComando.Parameters.Add("@indCotPed", SqlDbType.Char, 1).Value = pedidocab.indCotPed;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = pedidocab.UsuarioRegistro;
                    oComando.Parameters.Add(new SqlParameter("@Detalle", oDt));

                    //SqlParameter param = new SqlParameter("@Detalle", SqlDbType.Structured)
                    //{
                    //    TypeName = "ttPedidoPtoVta",
                    //    Value = oDt
                    //};

                    //oComando.Parameters.Add(param);

                    //SqlParameter parameter = new SqlParameter
                    //{
                    //    //The parameter for the SP must be of SqlDbType.Structured 
                    //    ParameterName = "@Detalle",
                    //    SqlDbType = SqlDbType.Structured,
                    //    Value = oDt
                    //};
                    //oComando.Parameters.Add(parameter);

                    oConexion.Open();
                    //oComando.ExecuteNonQuery();
                    pedidocab.idPedido = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return pedidocab;
        }

        public PedidoCabE ActualizarPedidoPtoVta(PedidoCabE pedidocab, DataTable oDt)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPedidoPtoVta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = pedidocab.idPedido;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pedidocab.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = pedidocab.idLocal;
                    oComando.Parameters.Add("@codPedidoCad", SqlDbType.VarChar, 20).Value = pedidocab.codPedidoCad;
                    oComando.Parameters.Add("@FecPedido", SqlDbType.VarChar, 8).Value = pedidocab.FecPedido;
                    oComando.Parameters.Add("@idFacturar", SqlDbType.Int).Value = pedidocab.idFacturar;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = pedidocab.idMoneda;
                    oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = pedidocab.Observacion;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = pedidocab.idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = pedidocab.idCondicion;
                    oComando.Parameters.Add("@totsubTotal", SqlDbType.Decimal).Value = pedidocab.totsubTotal;
                    oComando.Parameters.Add("@totDscto1", SqlDbType.Decimal).Value = pedidocab.totDscto1;
                    oComando.Parameters.Add("@totDscto2", SqlDbType.Decimal).Value = pedidocab.totDscto2;
                    oComando.Parameters.Add("@totDscto3", SqlDbType.Decimal).Value = pedidocab.totDscto3;
                    oComando.Parameters.Add("@totIsc", SqlDbType.Decimal).Value = pedidocab.totIsc;
                    oComando.Parameters.Add("@totIgv", SqlDbType.Decimal).Value = pedidocab.totIgv;
                    oComando.Parameters.Add("@totTotal", SqlDbType.Decimal).Value = pedidocab.totTotal;
                    oComando.Parameters.Add("@Redondeo", SqlDbType.Decimal).Value = pedidocab.Redondeo;
                    oComando.Parameters.Add("@TipoDoc", SqlDbType.Int).Value = pedidocab.TipoDoc;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = pedidocab.UsuarioModificacion;
                    oComando.Parameters.Add(new SqlParameter("@Detalle", oDt));

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return pedidocab;
        }
        
        public List<PedidoCabE> ListarPedidosPtoVta(Int32 idEmpresa, Int32 idLocal, String RazonSocial)
        {
            List<PedidoCabE> listaEntidad = new List<PedidoCabE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPedidosPtoVta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = RazonSocial;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarPedido(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public PedidoCabE ObtenerPedidoPtoVta(Int32 idPedido)
        {
            PedidoCabE pedidocab = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPedidoPtoVta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            pedidocab = LlenarPedido(oReader);
                        }
                    }
                }
            }

            return pedidocab;
        } 

        #endregion

    }
}