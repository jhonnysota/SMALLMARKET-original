using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class kardexAD : DbConection
    {

        public kardexE LlenarEntidad(IDataReader oReader)
        {
            kardexE kardex = new kardexE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDocumentoAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Num_Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.Num_Item = oReader["Num_Item"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Num_Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.tipAlmacen = oReader["tipAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idOperacion = oReader["idOperacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOperacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecProceso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.fecProceso = oReader["fecProceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecProceso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbicacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idUbicacion = oReader["idUbicacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUbicacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.Cantidad = oReader["Cantidad"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Cantidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpCostoUnitarioBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.ImpCostoUnitarioBase = oReader["ImpCostoUnitarioBase"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ImpCostoUnitarioBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpCostoUnitarioRefe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.ImpCostoUnitarioRefe = oReader["ImpCostoUnitarioRefe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ImpCostoUnitarioRefe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpTotalBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.ImpTotalBase = oReader["ImpTotalBase"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ImpTotalBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpTotalRefe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.ImpTotalRefe = oReader["ImpTotalRefe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ImpTotalRefe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCalidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.indCalidad = oReader["indCalidad"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCalidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConformidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.indConformidad = oReader["indConformidad"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indConformidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostosUso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idCCostosUso = oReader["idCCostosUso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostosUso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticuloUso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idArticuloUso = oReader["idArticuloUso"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticuloUso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroEnvases'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.nroEnvases = oReader["nroEnvases"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroEnvases"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Valorizado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.Valorizado = oReader["Valorizado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Valorizado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroParteProd'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.nroParteProd = oReader["nroParteProd"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroParteProd"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItemCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.idItemCompra = oReader["idItemCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItemCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioAnula'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.UsuarioAnula = oReader["UsuarioAnula"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioAnula"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaAnula'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				kardex.FechaAnula = oReader["FechaAnula"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaAnula"]);

            //Extensión
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.NombreOrigen = oReader["NombreOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreProcedencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.NombreProcedencia = oReader["NombreProcedencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreProcedencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Persona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.Persona = oReader["Persona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Persona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Batch'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.Batch = oReader["Batch"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Batch"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorcentajeGerminacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.PorcentajeGerminacion = oReader["PorcentajeGerminacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorcentajeGerminacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecPrueba'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.fecPrueba = oReader["fecPrueba"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecPrueba"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Inicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.Inicio = oReader["Inicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Inicio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.Fin = oReader["Fin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.DesArticulo = oReader["DesArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.desAlmacen = oReader["desAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.codCuentaDestino = oReader["codCuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.desCtaDestino = oReader["desCtaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.TotalSoles = oReader["TotalSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.TotalDolar = oReader["TotalDolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Orden'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.Orden = oReader["Orden"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Orden"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunatOpe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.codSunatOpe = oReader["codSunatOpe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunatOpe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.desOperacion = oReader["desOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.desMovimiento = oReader["desMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AlmacenOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.AlmacenOrigen = oReader["AlmacenOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AlmacenOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumItemOrg'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.NumItemOrg = oReader["NumItemOrg"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumItemOrg"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpCostoPromUnitarioBaseOrg'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.ImpCostoPromUnitarioBaseOrg = oReader["ImpCostoPromUnitarioBaseOrg"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpCostoPromUnitarioBaseOrg"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AlmacenDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.AlmacenDestino = oReader["AlmacenDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AlmacenDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumItemDst'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.NumItemDst = oReader["NumItemDst"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumItemDst"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpCostoPromUnitarioBaseDst'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.ImpCostoPromUnitarioBaseDst = oReader["ImpCostoPromUnitarioBaseDst"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpCostoPromUnitarioBaseDst"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalIngreso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.TotalIngreso = oReader["TotalIngreso"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalIngreso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Diferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.Diferencia = oReader["Diferencia"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Diferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteOrg'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.LoteOrg = oReader["LoteOrg"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteOrg"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadOrg'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.CantidadOrg = oReader["CantidadOrg"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CantidadOrg"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteDst'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.LoteDst = oReader["LoteDst"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteDst"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadDst'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.CantidadDst = oReader["CantidadDst"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CantidadDst"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocMovAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.numDocMovAlmacen = oReader["numDocMovAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocMovAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='KardexSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.KardexSoles = oReader["KardexSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["KardexSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='StockSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                kardex.StockSoles = oReader["StockSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["StockSoles"]);

            return  kardex;        
        }

        public kardexE Insertarkardex(kardexE kardex)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Insertarlog_kardex", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = kardex.idEmpresa;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = kardex.tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = kardex.idDocumentoAlmacen;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = kardex.idItem;
					oComando.Parameters.Add("@Num_Item", SqlDbType.VarChar, 5).Value = kardex.Num_Item;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = kardex.idAlmacen;
					oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = kardex.tipAlmacen;
					oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = kardex.idOperacion;
					oComando.Parameters.Add("@fecProceso", SqlDbType.SmallDateTime).Value = kardex.fecProceso;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = kardex.idMoneda;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = kardex.idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = kardex.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = kardex.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = kardex.numDocumento;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = kardex.idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = kardex.Lote;
					oComando.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = kardex.idUbicacion;
					oComando.Parameters.Add("@indCalidad", SqlDbType.Bit).Value = kardex.indCalidad;
					oComando.Parameters.Add("@indConformidad", SqlDbType.Bit).Value = kardex.indConformidad;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = kardex.idCCostos;
					oComando.Parameters.Add("@idCCostosUso", SqlDbType.VarChar, 20).Value = kardex.idCCostosUso;
					oComando.Parameters.Add("@idArticuloUso", SqlDbType.Int).Value = kardex.idArticuloUso;
                    oComando.Parameters.Add("@nroEnvases", SqlDbType.Decimal).Value = kardex.nroEnvases;
                    oComando.Parameters.Add("@Valorizado", SqlDbType.Bit).Value = kardex.Valorizado;
					oComando.Parameters.Add("@nroParteProd", SqlDbType.VarChar, 10).Value = kardex.nroParteProd;
					oComando.Parameters.Add("@idItemCompra", SqlDbType.Int).Value = kardex.idItemCompra;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = kardex.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return kardex;
        }
        
        public kardexE Actualizarkardex(kardexE kardex)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Actualizarlog_kardex", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = kardex.idEmpresa;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = kardex.tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = kardex.idDocumentoAlmacen;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = kardex.idItem;
					oComando.Parameters.Add("@Num_Item", SqlDbType.VarChar, 5).Value = kardex.Num_Item;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = kardex.idAlmacen;
					oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = kardex.tipAlmacen;
					oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = kardex.idOperacion;
					oComando.Parameters.Add("@fecProceso", SqlDbType.SmallDateTime).Value = kardex.fecProceso;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = kardex.idMoneda;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = kardex.idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = kardex.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = kardex.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = kardex.numDocumento;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = kardex.idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = kardex.Lote;
					oComando.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = kardex.idUbicacion;
					oComando.Parameters.Add("@indCalidad", SqlDbType.Bit).Value = kardex.indCalidad;
					oComando.Parameters.Add("@indConformidad", SqlDbType.Bit).Value = kardex.indConformidad;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = kardex.idCCostos;
					oComando.Parameters.Add("@idCCostosUso", SqlDbType.VarChar, 20).Value = kardex.idCCostosUso;
					oComando.Parameters.Add("@idArticuloUso", SqlDbType.Int).Value = kardex.idArticuloUso;
					oComando.Parameters.Add("@Valorizado", SqlDbType.Bit).Value = kardex.Valorizado;
					oComando.Parameters.Add("@Nro_Parte_Prod", SqlDbType.VarChar, 10).Value = kardex.nroParteProd;
					oComando.Parameters.Add("@idItemCompra", SqlDbType.Int).Value = kardex.idItemCompra;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = kardex.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return kardex;
        }        

        public int Eliminarkardex(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Eliminarlog_kardex", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<kardexE> Listarkardex(Int32 idEmpresa)
        {
            List<kardexE> listaEntidad = new List<kardexE>();
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Listarlog_kardex", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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

        public List<kardexE> Listarkardex2(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, Int32 idOperacion, DateTime Inicio, DateTime Fin)
        {
            List<kardexE> listaEntidad = new List<kardexE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Listar_Kardex2", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = idOperacion;
                    oComando.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = Inicio;
                    oComando.Parameters.Add("@Fin", SqlDbType.DateTime).Value = Fin;

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

        public kardexE Obtenerkardex(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem)
        {        
            kardexE kardex = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Obtenerlog_kardex", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            kardex = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return kardex;
        }

        public List<kardexE> KardexVsSaldo(Int32 idEmpresa, String Anio, String Mes)
        {
            List<kardexE> listaEntidad = new List<kardexE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_KardexVsSaldo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;

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

        public List<kardexE> KardexPorTipArticulo(Int32 idEmpresa, String Anio, String MesInicio, String Mes, Int32 tipArticulo, Int32 idAlmacen)
        {
            List<kardexE> listaEntidad = new List<kardexE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_KardexPorTipArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@MesInicio", SqlDbType.VarChar, 2).Value = MesInicio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@tipArticulo", SqlDbType.Int).Value = tipArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

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

        public List<kardexE> ListarTransferencia(Int32 idEmpresa, Int32 idTipoArticulo, string Inicio, string Fin)
        {
            List<kardexE> listaEntidad = new List<kardexE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTransferencia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@Inicio", SqlDbType.VarChar, 8).Value = Inicio;
                    oComando.Parameters.Add("@Fin", SqlDbType.VarChar, 8).Value = Fin;

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

        public List<kardexE> ListarKardexPorLote(Int32 idEmpresa, String Lote)
        {
            List<kardexE> listaEntidad = new List<kardexE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarKardexPorLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = Lote;

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

        public List<kardexE> KardexConsistencia(Int32 idEmpresa, String Anio, String MesInicio, String Mes, Int32 tipArticulo, Int32 idAlmacen)
        {
            List<kardexE> listaEntidad = new List<kardexE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_KardexConsistencia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@MesInicio", SqlDbType.VarChar, 2).Value = MesInicio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@tipArticulo", SqlDbType.Int).Value = tipArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

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