using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class MovimientoAlmacenAD : DbConection
    {

        public MovimientoAlmacenE LlenarEntidad(IDataReader oReader)
        {
            MovimientoAlmacenE MovimientoAlmacen = new MovimientoAlmacenE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimiento"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.tipAlmacen = oReader["tipAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idOperacion = oReader["idOperacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecProceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.fecProceso = oReader["fecProceso"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["fecProceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.indFactura = oReader["indFactura"] == DBNull.Value ? false: Convert.ToBoolean(oReader["indFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDocDevolucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.indDocDevolucion = oReader["indDocDevolucion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDocDevolucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoDevolucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idDocumentoDevolucion = oReader["idDocumentoDevolucion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoDevolucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumentoDevolucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.serDocumentoDevolucion = oReader["serDocumentoDevolucion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumentoDevolucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoDevolucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.numDocumentoDevolucion = oReader["numDocumentoDevolucion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoDevolucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumRequisicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.numRequisicion = oReader["NumRequisicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumRequisicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.SerieDocumentoRef = oReader["SerieDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumeroDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.NumeroDocumentoRef = oReader["NumeroDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumeroDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.indCambio = oReader["indCambio"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impValorVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.impValorVenta = oReader["impValorVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impValorVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.indImpuesto = oReader["indImpuesto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indImpuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Impuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.Impuesto = oReader["Impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Impuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impTotal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.impTotal = oReader["impTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPorAsociar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.indPorAsociar = oReader["indPorAsociar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPorAsociar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacenOrigen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idAlmacenOrigen = oReader["idAlmacenOrigen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacenOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacenDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idAlmacenDestino = oReader["idAlmacenDestino"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacenDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimientoAsociado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.tipMovimientoAsociado = oReader["tipMovimientoAsociado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimientoAsociado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacenAsociado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idDocumentoAlmacenAsociado = oReader["idDocumentoAlmacenAsociado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDocumentoAlmacenAsociado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCorrelativo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.numCorrelativo = oReader["numCorrelativo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCorrelativo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAutomatico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.indAutomatico = oReader["indAutomatico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAutomatico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioAnula'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.UsuarioAnula = oReader["UsuarioAnula"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioAnula"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaAnula'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.FechaAnula = oReader["FechaAnula"] == DBNull.Value ? MovimientoAlmacen.FechaAnula : Convert.ToDateTime(oReader["FechaAnula"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				MovimientoAlmacen.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
            //Extensiones...
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.desOperacion = oReader["desOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.desAlmacen = oReader["desAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.ruc = oReader["ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Documento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.Documento = oReader["Documento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Documento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Referencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.Referencia = oReader["Referencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Referencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Guia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.Guia = oReader["Guia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Guia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.numOrdenCompra = oReader["numOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correlativo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.Correlativo = oReader["Correlativo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correlativo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTransferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.indTransferencia = oReader["indTransferencia"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTransferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCompleto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.NombreCompleto = oReader["NombreCompleto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCompleto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VerificaLote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.VerificaLote = oReader["VerificaLote"] == DBNull.Value ? false : Convert.ToBoolean(oReader["VerificaLote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.codCuentaDestino = oReader["codCuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.desCtaDestino = oReader["desCtaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.desMovimiento = oReader["desMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoMovS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.CostoMovS = oReader["CostoMovS"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoMovS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoMovD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.CostoMovD = oReader["CostoMovD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoMovD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoKarS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.CostoKarS = oReader["CostoKarS"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoKarS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoKarD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.CostoKarD = oReader["CostoKarD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoKarD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.idMonedaPrecio = oReader["idMonedaPrecio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaPrecio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMonedaPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.desMonedaPrecio = oReader["desMonedaPrecio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMonedaPrecio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Precio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                MovimientoAlmacen.Precio = oReader["Precio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Precio"]);

            return  MovimientoAlmacen;        
        }

        public MovimientoAlmacenE InsertarMovimientoAlmacen(MovimientoAlmacenE movimientoalmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovimientoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movimientoalmacen.idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = movimientoalmacen.tipMovimiento;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = movimientoalmacen.idAlmacen;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = movimientoalmacen.tipAlmacen;
                    oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = movimientoalmacen.idOperacion;

                    //oComando.Parameters.Add("@fecProceso", SqlDbType.VarChar, 8).Value = Convert.ToString(movimientoalmacen.fecProceso.ToString());
                    //oComando.Parameters.Add("@fecProceso", SqlDbType.VarChar,8).Value = Convert.ToString(movimientoalmacen.fecProceso.ToString());
                    
                    oComando.Parameters.Add("@indFactura", SqlDbType.Bit).Value = movimientoalmacen.indFactura;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = movimientoalmacen.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = movimientoalmacen.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = movimientoalmacen.numDocumento;
                    oComando.Parameters.Add("@indDocDevolucion", SqlDbType.Bit).Value = movimientoalmacen.indDocDevolucion;
                    oComando.Parameters.Add("@idDocumentoDevolucion", SqlDbType.VarChar, 2).Value = movimientoalmacen.idDocumentoDevolucion;
                    oComando.Parameters.Add("@serDocumentoDevolucion", SqlDbType.VarChar, 20).Value = movimientoalmacen.serDocumentoDevolucion;
                    oComando.Parameters.Add("@numDocumentoDevolucion", SqlDbType.VarChar, 20).Value = movimientoalmacen.numDocumentoDevolucion;

                    oComando.Parameters.Add("@fecDocumento", SqlDbType.VarChar,8).Value = Convert.ToString(movimientoalmacen.fecDocumento.ToString());

                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = movimientoalmacen.idOrdenCompra;				
					oComando.Parameters.Add("@NumRequisicion", SqlDbType.VarChar, 7).Value = movimientoalmacen.numRequisicion;
					oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = movimientoalmacen.idDocumentoRef;
					oComando.Parameters.Add("@SerieDocumentoRef", SqlDbType.VarChar, 20).Value = movimientoalmacen.SerieDocumentoRef;
					oComando.Parameters.Add("@NumeroDocumentoRef", SqlDbType.VarChar, 20).Value = movimientoalmacen.NumeroDocumentoRef;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = movimientoalmacen.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = movimientoalmacen.idMoneda;
					oComando.Parameters.Add("@indCambio", SqlDbType.Bit).Value = movimientoalmacen.indCambio;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = movimientoalmacen.tipCambio;
					oComando.Parameters.Add("@impValorVenta", SqlDbType.Decimal).Value = movimientoalmacen.impValorVenta;
                    oComando.Parameters.Add("@indImpuesto", SqlDbType.Bit).Value = movimientoalmacen.indImpuesto;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = movimientoalmacen.porIgv;
                    oComando.Parameters.Add("@Impuesto", SqlDbType.Decimal).Value = movimientoalmacen.Impuesto;
					oComando.Parameters.Add("@impTotal", SqlDbType.Decimal).Value = movimientoalmacen.impTotal;
                    oComando.Parameters.Add("@idAlmacenOrigen", SqlDbType.Int).Value = movimientoalmacen.idAlmacenOrigen;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 80).Value = movimientoalmacen.Glosa;
                    oComando.Parameters.Add("@indPorAsociar", SqlDbType.Bit).Value = movimientoalmacen.indPorAsociar;
                    oComando.Parameters.Add("@idAlmacenDestino", SqlDbType.Int).Value = movimientoalmacen.idAlmacenDestino;
                    oComando.Parameters.Add("@tipMovimientoAsociado", SqlDbType.Int).Value = movimientoalmacen.tipMovimientoAsociado;
                    oComando.Parameters.Add("@idDocumentoAlmacenAsociado", SqlDbType.Int).Value = movimientoalmacen.idDocumentoAlmacenAsociado;
                    oComando.Parameters.Add("@indAutomatico", SqlDbType.Bit).Value = movimientoalmacen.indAutomatico;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = movimientoalmacen.UsuarioRegistro;
                    
                    oConexion.Open();
                    movimientoalmacen.idDocumentoAlmacen = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return movimientoalmacen;
        }
        
        public MovimientoAlmacenE ActualizarMovimientoAlmacen(MovimientoAlmacenE movimientoalmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovimientoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movimientoalmacen.idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = movimientoalmacen.tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = movimientoalmacen.idDocumentoAlmacen;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = movimientoalmacen.idAlmacen;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = movimientoalmacen.tipAlmacen;
                    oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = movimientoalmacen.idOperacion;
                    oComando.Parameters.Add("@fecProceso", SqlDbType.VarChar, 8).Value = movimientoalmacen.fecProceso;
                    oComando.Parameters.Add("@indFactura", SqlDbType.Bit).Value = movimientoalmacen.indFactura;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = movimientoalmacen.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = movimientoalmacen.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = movimientoalmacen.numDocumento;
                    oComando.Parameters.Add("@indDocDevolucion", SqlDbType.Bit).Value = movimientoalmacen.indDocDevolucion;
                    oComando.Parameters.Add("@idDocumentoDevolucion", SqlDbType.VarChar, 2).Value = movimientoalmacen.idDocumentoDevolucion;
                    oComando.Parameters.Add("@serDocumentoDevolucion", SqlDbType.VarChar, 20).Value = movimientoalmacen.serDocumentoDevolucion;
                    oComando.Parameters.Add("@numDocumentoDevolucion", SqlDbType.VarChar, 20).Value = movimientoalmacen.numDocumentoDevolucion;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.VarChar, 8).Value = movimientoalmacen.fecDocumento;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = movimientoalmacen.idOrdenCompra;
                    oComando.Parameters.Add("@NumRequisicion", SqlDbType.VarChar, 7).Value = movimientoalmacen.numRequisicion;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = movimientoalmacen.idDocumentoRef;
                    oComando.Parameters.Add("@SerieDocumentoRef", SqlDbType.VarChar, 20).Value = movimientoalmacen.SerieDocumentoRef;
                    oComando.Parameters.Add("@NumeroDocumentoRef", SqlDbType.VarChar, 20).Value = movimientoalmacen.NumeroDocumentoRef;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = movimientoalmacen.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = movimientoalmacen.idMoneda;
                    oComando.Parameters.Add("@indCambio", SqlDbType.Bit).Value = movimientoalmacen.indCambio;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = movimientoalmacen.tipCambio;
                    oComando.Parameters.Add("@impValorVenta", SqlDbType.Decimal).Value = movimientoalmacen.impValorVenta;
                    oComando.Parameters.Add("@indImpuesto", SqlDbType.Bit).Value = movimientoalmacen.indImpuesto;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = movimientoalmacen.porIgv;
                    oComando.Parameters.Add("@Impuesto", SqlDbType.Decimal).Value = movimientoalmacen.Impuesto;
                    oComando.Parameters.Add("@impTotal", SqlDbType.Decimal).Value = movimientoalmacen.impTotal;
                    oComando.Parameters.Add("@idAlmacenOrigen", SqlDbType.Int).Value = movimientoalmacen.idAlmacenOrigen;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 80).Value = movimientoalmacen.Glosa;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movimientoalmacen.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientoalmacen;
        }

        public Int32 EliminarMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovimientoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 AnularMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, String UsuarioAnula)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularMovimientoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;
                    oComando.Parameters.Add("@UsuarioAnula", SqlDbType.VarChar, 20).Value = UsuarioAnula;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MovimientoAlmacenE> ListarMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, string desde, string hasta, Int32 idconcepto, Boolean IncluirAnulados)
        {
            List<MovimientoAlmacenE> listaEntidad = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovimientoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@desde", SqlDbType.VarChar, 8).Value = desde;
                    oComando.Parameters.Add("@hasta", SqlDbType.VarChar, 8).Value = hasta;
                    oComando.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                    oComando.Parameters.Add("@IncluirAnulados", SqlDbType.Bit).Value = IncluirAnulados;
                    
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

        public void ProcesoGenerarSalidaAlmacen(Int32 idEmpresa, Int32 TipoArticulo, String idCCosto, string vd_desde, string vd_hasta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarSalidaAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.AddWithValue("@TipoArticulo", TipoArticulo);
                    oComando.Parameters.AddWithValue("@idCCosto", idCCosto);
                    oComando.Parameters.AddWithValue("@vd_desde", vd_desde);
                    oComando.Parameters.AddWithValue("@vd_hasta", vd_hasta);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<MovimientoAlmacenE> ListarMovimientoAlmacenPorArticulo(Int32 idEmpresa, Int32 idArticulo)
        {
            List<MovimientoAlmacenE> listaEntidad = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloServReporteDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

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

        public MovimientoAlmacenE ObtenerMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {        
            MovimientoAlmacenE movimiento_almacen = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovimientoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimiento_almacen = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movimiento_almacen;
        }

        public List<MovimientoAlmacenE> ObtenerMovAlmacenporID(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idAlmacen)
        {
            List<MovimientoAlmacenE> movimiento_almacen = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovAlmacenporID", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimiento_almacen.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return movimiento_almacen;
        }

        public List<MovimientoAlmacenE> ListarMovEgresosPorAsociar(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen)
        {
            List<MovimientoAlmacenE> listaEntidad = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovEgresosPorAsociar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
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

        // Movimiento de Almacen de Ingresos Por Recibir 
        public List<MovimientoAlmacenE> ListarIngresosCompraPendiente(Int32 idEmpresa, String CodMoneda)
        {
            List<MovimientoAlmacenE> listaEntidad = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarIngresosCompraPendiente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@CodMoneda", SqlDbType.VarChar,2).Value = CodMoneda;

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

        public List<MovimientoAlmacenE> ListarMovimientosPorOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            List<MovimientoAlmacenE> listaEntidad = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovimientosPorOrdenCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

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

        public MovimientoAlmacenE ActualizarMovimientoTrans(MovimientoAlmacenE movimientoalmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovimientoTrans", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movimientoalmacen.idEmpresa;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = movimientoalmacen.idDocumentoAlmacen;
                    oComando.Parameters.Add("@indPorAsociar", SqlDbType.Bit).Value = movimientoalmacen.indPorAsociar;
                    oComando.Parameters.Add("@idAlmacenOrigen", SqlDbType.Int).Value = movimientoalmacen.idAlmacenOrigen;
                    oComando.Parameters.Add("@tipMovimientoAsociado", SqlDbType.Int).Value = movimientoalmacen.tipMovimientoAsociado;
                    oComando.Parameters.Add("@idDocumentoAlmacenAsociado", SqlDbType.Int).Value = movimientoalmacen.idDocumentoAlmacenAsociado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movimientoalmacen.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientoalmacen;
        }

        public MovimientoAlmacenE MovimientoAlmacenPorReferencia(Int32 idEmpresa, String idDocumentoRef, String SerieDocumentoRef, String NumeroDocumentoRef)
        {
            MovimientoAlmacenE movimiento_almacen = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MovimientoAlmacenPorReferencia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = idDocumentoRef;
                    oComando.Parameters.Add("@SerieDocumentoRef", SqlDbType.VarChar, 20).Value = SerieDocumentoRef;
                    oComando.Parameters.Add("@NumeroDocumentoRef", SqlDbType.VarChar, 20).Value = NumeroDocumentoRef;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimiento_almacen = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movimiento_almacen;
        }

        public MovimientoAlmacenE MovimientoAlmacenPorDocumento(Int32 idEmpresa, String idDocumento, String SerieDocumento, String NumeroDocumento)
        {
            MovimientoAlmacenE movimiento_almacen = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MovimientoAlmacenPorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@SerieDocumento", SqlDbType.VarChar, 20).Value = SerieDocumento;
                    oComando.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 20).Value = NumeroDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimiento_almacen = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movimiento_almacen;
        }

        public List<MovimientoAlmacenE> GenerarAperturaAlmacen(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, string FechaIngreso, String Usuario)
        {
            List<MovimientoAlmacenE> ListaBalance = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GeneraAperturaAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@FechaIngreso", SqlDbType.VarChar, 8).Value = FechaIngreso;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaBalance.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaBalance;
        }

        public List<MovimientoAlmacenE> ListarMovimientoSalidasAlmacen(Int32 idEmpresa, Int32 idArticulo, String Lote)
        {
            List<MovimientoAlmacenE> listaEntidad = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovimientoSalidasAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 40).Value = Lote;

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

        public List<MovimientoAlmacenE> MovimientoAlmacenPorTipArticulo(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, Int32 tipArticulo, Int32 idOperacion, string fecIni, string fecFin)
        {
            List<MovimientoAlmacenE> listaEntidad = new List<MovimientoAlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MovimientoAlmacenPorTipArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@tipArticulo", SqlDbType.Int).Value = tipArticulo;
                    oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = idOperacion;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;

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

        #region Procedimientos para la importacion de movimientos XLS

        public Int32 AnularMovAlmacenPorParametros(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, Int32 tipAlmacen, Int32 idOperacion, DateTime fecProceso, String UsuarioAnula)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularMovAlmacenPorParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = tipAlmacen;
                    oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = idOperacion;
                    oComando.Parameters.Add("@fecProceso", SqlDbType.DateTime).Value = fecProceso;
                    oComando.Parameters.Add("@UsuarioAnula", SqlDbType.VarChar, 20).Value = UsuarioAnula;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 InsertarMovimientoAlmacenXLS(DataTable oDt)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovimientoAlmacenXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    SqlParameter param = new SqlParameter("@Tabla", SqlDbType.Structured)
                    {
                        TypeName = "utt_MovimientoAlmacenXLS",
                        Value = oDt
                    };

                    oComando.Parameters.Add(param);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarMovimientoAlmacenXLS(Int32 idEmpresa, Int32 idUsuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovimientoAlmacenXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ProcesarMovimientoAlmacenXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesarMovimientoAlmacenXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        #endregion

    }
}