using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OrdenCompraAD : DbConection
    {

        public OrdenCompraE LlenarEntidad(IDataReader oReader)
        {
            OrdenCompraE ordencompra = new OrdenCompraE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMigrar'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.idMigrar = oReader["idMigrar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMigrar"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.numOrdenCompra = oReader["numOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRequisicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.idRequisicion = oReader["idRequisicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRequisicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRequisicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.numRequisicion = oReader["numRequisicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numRequisicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCotizacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.numCotizacion = oReader["numCotizacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCotizacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProveedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.idProveedor = oReader["idProveedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProveedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.tipOrdenCompra = oReader["tipOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipSecuenciaFlujo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.tipSecuenciaFlujo = oReader["tipSecuenciaFlujo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipSecuenciaFlujo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipModalCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.tipModalCompra = oReader["tipModalCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipModalCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecRequerida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.fecRequerida = oReader["fecRequerida"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecRequerida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.tipEstado = oReader["tipEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstadoAtencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.tipEstadoAtencion = oReader["tipEstadoAtencion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstadoAtencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstadoPorFacturar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.tipEstadoPorFacturar = oReader["tipEstadoPorFacturar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstadoPorFacturar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRecepFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.MontoRecepFactura = oReader["MontoRecepFactura"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRecepFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numPlazoPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.numPlazoPago = oReader["numPlazoPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numPlazoPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numPlazoEntrega'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.numPlazoEntrega = oReader["numPlazoEntrega"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numPlazoEntrega"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.tipFormaPago = oReader["tipFormaPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipFormaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.desFormaPago = oReader["desFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFormaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.impVenta = oReader["impVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIsc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.porIsc = oReader["porIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIsc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impIsc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.impIsc = oReader["impIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impIsc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impIgv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.impIgv = oReader["impIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impIgv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impTotal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.impTotal = oReader["impTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impTotal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLicitacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.numLicitacion = oReader["numLicitacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numLicitacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indLicitacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.indLicitacion = oReader["indLicitacion"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indLicitacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.indConPresu = oReader["indConPresu"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indConPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioAprobacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.UsuarioAprobacion = oReader["UsuarioAprobacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioAprobacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecAprobacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.fecAprobacion = oReader["fecAprobacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecAprobacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.tipCompra = oReader["tipCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIngAlm'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.indIngAlm = oReader["indIngAlm"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indIngAlm"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCampana'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.indCampana = oReader["indCampana"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCampana"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCampana'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.codCampana = oReader["codCampana"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codCampana"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ModoCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.ModoCompra = oReader["ModoCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ModoCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacenEntrega'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.idAlmacenEntrega = oReader["idAlmacenEntrega"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacenEntrega"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LugarEntrega'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.LugarEntrega = oReader["LugarEntrega"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LugarEntrega"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Via'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.Via = oReader["Via"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Via"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Seguro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.Seguro = oReader["Seguro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Seguro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SemanaEmbarqueDe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.SemanaEmbarqueDe = oReader["SemanaEmbarqueDe"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["SemanaEmbarqueDe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SemanaEmbarqueA'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.SemanaEmbarqueA = oReader["SemanaEmbarqueA"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["SemanaEmbarqueA"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuertoDescarga'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.PuertoDescarga = oReader["PuertoDescarga"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PuertoDescarga"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CondicionEntrega'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.CondicionEntrega = oReader["CondicionEntrega"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CondicionEntrega"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codAgencia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.codAgencia = oReader["codAgencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codAgencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codContacto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.codContacto = oReader["codContacto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codContacto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desResponsable'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.desResponsable = oReader["desResponsable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desResponsable"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioRequerimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.AnioRequerimiento = oReader["AnioRequerimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioRequerimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PeriodoRequerimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.PeriodoRequerimiento = oReader["PeriodoRequerimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PeriodoRequerimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipRequerimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.tipRequerimiento = oReader["tipRequerimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipRequerimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRequerimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.numRequerimiento = oReader["numRequerimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numRequerimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDistribucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.indDistribucion = oReader["indDistribucion"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indDistribucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecAnulacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.fecAnulacion = oReader["fecAnulacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecAnulacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.TipoOrdenCompra = oReader["TipoOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoOrdenCompra"]);          
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompra.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CanOrdenada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.CanOrdenada = oReader["CanOrdenada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CanOrdenada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impPrecioUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impPrecioUnitario = oReader["impPrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impPrecioUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impigv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impigv = oReader["impigv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impigv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impTotalitem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impTotalitem = oReader["impTotalitem"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impTotalitem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='deslarga'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.deslarga = oReader["deslarga"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["deslarga"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desTipOrdenCompra = oReader["desTipOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipSecuenciaFlujo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desTipSecuenciaFlujo = oReader["desTipSecuenciaFlujo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipSecuenciaFlujo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipModalCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desTipModalCompra = oReader["desTipModalCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipModalCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desTipEstado = oReader["desTipEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipEstadoAtencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desTipEstadoAtencion = oReader["desTipEstadoAtencion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipEstadoAtencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desTipCompra = oReader["desTipCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoCCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.tipoCCosto = oReader["tipoCCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipoCCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desPartidaPresu = oReader["desPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desCampana = oReader["desCampana"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.Correo = oReader["Correo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CorreoContacto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.CorreoContacto = oReader["CorreoContacto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CorreoContacto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomContacto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.NomContacto = oReader["NomContacto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomContacto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipEstadoFacturar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desTipEstadoFacturar = oReader["desTipEstadoFacturar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipEstadoFacturar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Saldo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.Saldo = oReader["Saldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Saldo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesAlm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.DesAlm = oReader["DesAlm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesAlm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dirProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.dirProveedor = oReader["dirProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["dirProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Moneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.Moneda = oReader["Moneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Moneda"]);

            return  ordencompra;        
        }

        public OrdenCompraE LlenarOrdenCompra(IDataReader oReader)
        {
            OrdenCompraE ordencompra = new OrdenCompraE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.numOrdenCompra = oReader["numOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.tipCompra = oReader["tipCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impVenta = oReader["impVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.fecAlmacen = oReader["fecAlmacen"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CanOrdenada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.CanOrdenada = oReader["CanOrdenada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CanOrdenada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCostoS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impCostoS = oReader["impCostoS"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCostoS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCostoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impCostoD = oReader["impCostoD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCostoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCostoTotS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impCostoTotS = oReader["impCostoTotS"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCostoTotS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCostoTotD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impCostoTotD = oReader["impCostoTotD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCostoTotD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDocSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impDocSoles = oReader["impDocSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDocSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDocDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.impDocDolar = oReader["impDocDolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDocDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Voucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.Voucher = oReader["Voucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Voucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.Cuenta = oReader["Cuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Cuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompra.CuentaDestino = oReader["CuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CuentaDestino"]);



            return ordencompra;
        }

        public OrdenCompraE InsertarOrdenCompra(OrdenCompraE ordencompra)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompra.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordencompra.idLocal;
					oComando.Parameters.Add("@numOrdenCompra", SqlDbType.VarChar, 20).Value = ordencompra.numOrdenCompra;
                    oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = ordencompra.idRequisicion;
                    oComando.Parameters.Add("@numRequisicion", SqlDbType.VarChar, 7).Value = ordencompra.numRequisicion;
					oComando.Parameters.Add("@numCotizacion", SqlDbType.VarChar, 7).Value = ordencompra.numCotizacion;
					oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = ordencompra.idProveedor;
					oComando.Parameters.Add("@RUC", SqlDbType.VarChar, 20).Value = ordencompra.RUC;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = ordencompra.RazonSocial;
					oComando.Parameters.Add("@tipOrdenCompra", SqlDbType.Int).Value = ordencompra.tipOrdenCompra;
					oComando.Parameters.Add("@tipSecuenciaFlujo", SqlDbType.Int).Value = ordencompra.tipSecuenciaFlujo;
					oComando.Parameters.Add("@tipModalCompra", SqlDbType.Int).Value = ordencompra.tipModalCompra;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = ordencompra.idCCostos;
					oComando.Parameters.Add("@fecEmision", SqlDbType.DateTime).Value = ordencompra.fecEmision;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = ordencompra.tipPartidaPresu;
					oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = ordencompra.codPartidaPresu;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordencompra.idMoneda;
					oComando.Parameters.Add("@fecRequerida", SqlDbType.DateTime).Value = ordencompra.fecRequerida;
					oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = ordencompra.tipEstado;
					oComando.Parameters.Add("@tipEstadoAtencion", SqlDbType.VarChar, 2).Value = ordencompra.tipEstadoAtencion;
                    oComando.Parameters.Add("@tipEstadoPorFacturar", SqlDbType.VarChar, 2).Value = ordencompra.tipEstadoPorFacturar;
                    oComando.Parameters.Add("@MontoRecepFactura", SqlDbType.Decimal).Value = ordencompra.MontoRecepFactura;
                    oComando.Parameters.Add("@numPlazoPago", SqlDbType.Int).Value = ordencompra.numPlazoPago;
					oComando.Parameters.Add("@numPlazoEntrega", SqlDbType.Int).Value = ordencompra.numPlazoEntrega;
					oComando.Parameters.Add("@tipFormaPago", SqlDbType.Int).Value = ordencompra.tipFormaPago;
					oComando.Parameters.Add("@desFormaPago", SqlDbType.VarChar, 150).Value = ordencompra.desFormaPago;
					oComando.Parameters.Add("@impVenta", SqlDbType.Decimal).Value = ordencompra.impVenta;
					oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = ordencompra.porIsc;
					oComando.Parameters.Add("@impIsc", SqlDbType.Decimal).Value = ordencompra.impIsc;
					oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = ordencompra.porIgv;
					oComando.Parameters.Add("@impIgv", SqlDbType.Decimal).Value = ordencompra.impIgv;
					oComando.Parameters.Add("@impTotal", SqlDbType.Decimal).Value = ordencompra.impTotal;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 800).Value = ordencompra.Observacion;
					oComando.Parameters.Add("@numLicitacion", SqlDbType.VarChar, 20).Value = ordencompra.numLicitacion;
					oComando.Parameters.Add("@indLicitacion", SqlDbType.Bit).Value = ordencompra.indLicitacion;
					oComando.Parameters.Add("@indConPresu", SqlDbType.Bit).Value = ordencompra.indConPresu;
					oComando.Parameters.Add("@UsuarioAprobacion", SqlDbType.VarChar, 30).Value = ordencompra.UsuarioAprobacion;
					oComando.Parameters.Add("@fecAprobacion", SqlDbType.DateTime).Value = ordencompra.fecAprobacion;
					oComando.Parameters.Add("@tipCompra", SqlDbType.Char, 1).Value = ordencompra.tipCompra;
					oComando.Parameters.Add("@indIngAlm", SqlDbType.Bit).Value = ordencompra.indIngAlm;					
					oComando.Parameters.Add("@indCampana", SqlDbType.Bit).Value = ordencompra.indCampana;
					oComando.Parameters.Add("@codCampana", SqlDbType.Int).Value = ordencompra.codCampana;
					oComando.Parameters.Add("@ModoCompra", SqlDbType.VarChar, 1).Value = ordencompra.ModoCompra;
					oComando.Parameters.Add("@idAlmacenEntrega", SqlDbType.Int).Value = ordencompra.idAlmacenEntrega;
					oComando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 100).Value = ordencompra.LugarEntrega;
					oComando.Parameters.Add("@Via", SqlDbType.VarChar, 1).Value = ordencompra.Via;
					oComando.Parameters.Add("@Seguro", SqlDbType.VarChar, 50).Value = ordencompra.Seguro;
					oComando.Parameters.Add("@SemanaEmbarqueDe", SqlDbType.Int).Value = ordencompra.SemanaEmbarqueDe;
					oComando.Parameters.Add("@SemanaEmbarqueA", SqlDbType.Int).Value = ordencompra.SemanaEmbarqueA;
					oComando.Parameters.Add("@PuertoDescarga", SqlDbType.VarChar, 50).Value = ordencompra.PuertoDescarga;
					oComando.Parameters.Add("@CondicionEntrega", SqlDbType.VarChar, 10).Value = ordencompra.CondicionEntrega;
					oComando.Parameters.Add("@codAgencia", SqlDbType.VarChar, 3).Value = ordencompra.codAgencia;
					oComando.Parameters.Add("@codContacto", SqlDbType.Int).Value = ordencompra.codContacto;
					oComando.Parameters.Add("@desResponsable", SqlDbType.VarChar, 80).Value = ordencompra.desResponsable;
					oComando.Parameters.Add("@AnioRequerimiento", SqlDbType.VarChar, 4).Value = ordencompra.AnioRequerimiento;
					oComando.Parameters.Add("@PeriodoRequerimiento", SqlDbType.VarChar, 2).Value = ordencompra.PeriodoRequerimiento;
					oComando.Parameters.Add("@tipRequerimiento", SqlDbType.VarChar, 3).Value = ordencompra.tipRequerimiento;
					oComando.Parameters.Add("@numRequerimiento", SqlDbType.VarChar, 10).Value = ordencompra.numRequerimiento;
                    oComando.Parameters.Add("@indDistribucion", SqlDbType.Bit).Value = ordencompra.indDistribucion;
                    oComando.Parameters.Add("@fecAnulacion", SqlDbType.DateTime).Value = ordencompra.fecAnulacion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordencompra.UsuarioRegistro;
                    oComando.Parameters.Add("@TipoOrdenCompra", SqlDbType.VarChar, 1).Value = ordencompra.TipoOrdenCompra;

                    oConexion.Open();
                    ordencompra.idOrdenCompra = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordencompra;
        }
        
        public OrdenCompraE ActualizarOrdenCompra(OrdenCompraE ordencompra)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompra.idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordencompra.idOrdenCompra;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordencompra.idLocal;
					oComando.Parameters.Add("@numOrdenCompra", SqlDbType.VarChar, 20).Value = ordencompra.numOrdenCompra;
                    oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = ordencompra.idRequisicion;
                    oComando.Parameters.Add("@numRequisicion", SqlDbType.VarChar, 7).Value = ordencompra.numRequisicion;
					oComando.Parameters.Add("@numCotizacion", SqlDbType.VarChar, 7).Value = ordencompra.numCotizacion;
					oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = ordencompra.idProveedor;
					oComando.Parameters.Add("@RUC", SqlDbType.VarChar, 20).Value = ordencompra.RUC;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = ordencompra.RazonSocial;
					oComando.Parameters.Add("@tipOrdenCompra", SqlDbType.Int).Value = ordencompra.tipOrdenCompra;
					oComando.Parameters.Add("@tipSecuenciaFlujo", SqlDbType.Int).Value = ordencompra.tipSecuenciaFlujo;
					oComando.Parameters.Add("@tipModalCompra", SqlDbType.Int).Value = ordencompra.tipModalCompra;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = ordencompra.idCCostos;
					oComando.Parameters.Add("@fecEmision", SqlDbType.DateTime).Value = ordencompra.fecEmision;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = ordencompra.tipPartidaPresu;
					oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = ordencompra.codPartidaPresu;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordencompra.idMoneda;
					oComando.Parameters.Add("@fecRequerida", SqlDbType.DateTime).Value = ordencompra.fecRequerida;
					oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = ordencompra.tipEstado;
					oComando.Parameters.Add("@tipEstadoAtencion", SqlDbType.VarChar, 2).Value = ordencompra.tipEstadoAtencion;
                    oComando.Parameters.Add("@tipEstadoPorFacturar", SqlDbType.VarChar, 2).Value = ordencompra.tipEstadoPorFacturar;
                    oComando.Parameters.Add("@MontoRecepFactura", SqlDbType.Decimal).Value = ordencompra.MontoRecepFactura;
                    oComando.Parameters.Add("@numPlazoPago", SqlDbType.Int).Value = ordencompra.numPlazoPago;
					oComando.Parameters.Add("@numPlazoEntrega", SqlDbType.Int).Value = ordencompra.numPlazoEntrega;
					oComando.Parameters.Add("@tipFormaPago", SqlDbType.Int).Value = ordencompra.tipFormaPago;
					oComando.Parameters.Add("@desFormaPago", SqlDbType.VarChar, 150).Value = ordencompra.desFormaPago;
					oComando.Parameters.Add("@impVenta", SqlDbType.Decimal).Value = ordencompra.impVenta;
					oComando.Parameters.Add("@porIsc", SqlDbType.Decimal).Value = ordencompra.porIsc;
					oComando.Parameters.Add("@impIsc", SqlDbType.Decimal).Value = ordencompra.impIsc;
					oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = ordencompra.porIgv;
					oComando.Parameters.Add("@impIgv", SqlDbType.Decimal).Value = ordencompra.impIgv;
					oComando.Parameters.Add("@impTotal", SqlDbType.Decimal).Value = ordencompra.impTotal;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 800).Value = ordencompra.Observacion;
					oComando.Parameters.Add("@numLicitacion", SqlDbType.VarChar, 20).Value = ordencompra.numLicitacion;
					oComando.Parameters.Add("@indLicitacion", SqlDbType.Bit).Value = ordencompra.indLicitacion;
					oComando.Parameters.Add("@indConPresu", SqlDbType.Bit).Value = ordencompra.indConPresu;
					oComando.Parameters.Add("@UsuarioAprobacion", SqlDbType.VarChar, 30).Value = ordencompra.UsuarioAprobacion;
					oComando.Parameters.Add("@fecAprobacion", SqlDbType.DateTime).Value = ordencompra.fecAprobacion;
					oComando.Parameters.Add("@tipCompra", SqlDbType.Char, 1).Value = ordencompra.tipCompra;
					oComando.Parameters.Add("@indIngAlm", SqlDbType.Bit).Value = ordencompra.indIngAlm;
					oComando.Parameters.Add("@indCampana", SqlDbType.Bit).Value = ordencompra.indCampana;
					oComando.Parameters.Add("@codCampana", SqlDbType.Int).Value = ordencompra.codCampana;
					oComando.Parameters.Add("@ModoCompra", SqlDbType.VarChar, 1).Value = ordencompra.ModoCompra;
					oComando.Parameters.Add("@idAlmacenEntrega", SqlDbType.Int).Value = ordencompra.idAlmacenEntrega;
					oComando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 100).Value = ordencompra.LugarEntrega;
					oComando.Parameters.Add("@Via", SqlDbType.VarChar, 1).Value = ordencompra.Via;
					oComando.Parameters.Add("@Seguro", SqlDbType.VarChar, 50).Value = ordencompra.Seguro;
					oComando.Parameters.Add("@SemanaEmbarqueDe", SqlDbType.Int).Value = ordencompra.SemanaEmbarqueDe;
					oComando.Parameters.Add("@SemanaEmbarqueA", SqlDbType.Int).Value = ordencompra.SemanaEmbarqueA;
					oComando.Parameters.Add("@PuertoDescarga", SqlDbType.VarChar, 50).Value = ordencompra.PuertoDescarga;
					oComando.Parameters.Add("@CondicionEntrega", SqlDbType.VarChar, 10).Value = ordencompra.CondicionEntrega;
					oComando.Parameters.Add("@codAgencia", SqlDbType.VarChar, 3).Value = ordencompra.codAgencia;
					oComando.Parameters.Add("@codContacto", SqlDbType.Int).Value = ordencompra.codContacto;
					oComando.Parameters.Add("@desResponsable", SqlDbType.VarChar, 80).Value = ordencompra.desResponsable;
					oComando.Parameters.Add("@AnioRequerimiento", SqlDbType.VarChar, 4).Value = ordencompra.AnioRequerimiento;
					oComando.Parameters.Add("@PeriodoRequerimiento", SqlDbType.VarChar, 2).Value = ordencompra.PeriodoRequerimiento;
					oComando.Parameters.Add("@tipRequerimiento", SqlDbType.VarChar, 3).Value = ordencompra.tipRequerimiento;
					oComando.Parameters.Add("@numRequerimiento", SqlDbType.VarChar, 10).Value = ordencompra.numRequerimiento;
                    oComando.Parameters.Add("@indDistribucion", SqlDbType.Bit).Value = ordencompra.indDistribucion;
                    oComando.Parameters.Add("@fecAnulacion", SqlDbType.DateTime).Value = ordencompra.fecAnulacion;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordencompra.UsuarioModificacion;
                    oComando.Parameters.Add("@TipoOrdenCompra", SqlDbType.VarChar, 1).Value = ordencompra.TipoOrdenCompra;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordencompra;
        }        

        public Int32 EliminarOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenCompraE> ListarOrdenCompra(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, string desProveedor, String TipoOrdenCompra)
        {
           List<OrdenCompraE> listaEntidad = new List<OrdenCompraE>();
           OrdenCompraE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@desProveedor", SqlDbType.VarChar, 80).Value = desProveedor;
                    oComando.Parameters.Add("@TipoOrdenCompra", SqlDbType.VarChar,1).Value = TipoOrdenCompra;

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

        public List<OrdenCompraE> ListarOrdenCompraActivos(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, string desProveedor , String tipEstado)
        {
            List<OrdenCompraE> listaEntidad = new List<OrdenCompraE>();
            OrdenCompraE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenCompraActivos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@desProveedor", SqlDbType.VarChar, 80).Value = desProveedor;
                    oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = tipEstado;
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

        public OrdenCompraE ActivarOrdenCompraActivos(OrdenCompraE ordencompra)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActivarOrdenCompraActivos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value =ordencompra.idEmpresa;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordencompra.idOrdenCompra;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordencompra.idLocal;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordencompra;
        }

        public OrdenCompraE ObtenerOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra)
        {        
            OrdenCompraE ordencompra = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordencompra = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordencompra;
        }

        public Int64 GenerarNroOrdenCompra(Int32 idEmpresa, Int32 idLocal, DateTime fecEmision, String TipoOrdenCompra)
        {
            Int64 NroOC = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNroOrdenCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecEmision", SqlDbType.SmallDateTime).Value = fecEmision;
                    oComando.Parameters.Add("@TipoOrdenCompra", SqlDbType.VarChar, 1).Value = TipoOrdenCompra;

                    oConexion.Open();
                    NroOC = Convert.ToInt64(oComando.ExecuteScalar());
                }
            }

            return NroOC;
        }

        public List<OrdenCompraE> ListarOCPendientes(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Filtro, string Tipo)
        {
            List<OrdenCompraE> listaEntidad = new List<OrdenCompraE>();
            OrdenCompraE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOCPendientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Filtro", SqlDbType.VarChar, 100).Value = Filtro;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = Tipo;

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

        public Int32 ActualizarEstadoPorFacturar(Int32 idEmpresa, Int32 idLocal, Int32 idOrdenCompra, String tipEstadoPorFacturar, Decimal MontoRecepFactura, String UsuarioModificacion)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoPorFacturar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;
                    oComando.Parameters.Add("@tipEstadoPorFacturar", SqlDbType.VarChar, 2).Value = tipEstadoPorFacturar;
                    oComando.Parameters.Add("@MontoRecepFactura", SqlDbType.Decimal).Value = MontoRecepFactura;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    Resp = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return Resp;
        }

        public List<OrdenCompraE> ListarOrdenCompraPendientes(Int32 idEmpresa, Int32 tipo, Int32 idPersona)
        {
            List<OrdenCompraE> listaEntidad = new List<OrdenCompraE>();
            OrdenCompraE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenCompraPendientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
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

        public List<OrdenCompraE> OrdenCompraPorNotaIngreso(Int32 idEmpresa, String numVerPlanCuentas, string fecIni, string fecFin)
        {
            List<OrdenCompraE> listaOC = new List<OrdenCompraE>();
            OrdenCompraE oc = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_OrdenCompraPorNotaIngreso", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.Char, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oc = LlenarOrdenCompra(oReader);
                            listaOC.Add(oc);
                        }
                    }
                }
            }

            return listaOC;
        }

    }
}