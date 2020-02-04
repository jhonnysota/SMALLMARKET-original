using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class MovimientoAlmacenItemAD : DbConection
    {

        public MovimientoAlmacenItemE LlenarEntidad(IDataReader oReader)
        {
            MovimientoAlmacenItemE item = new MovimientoAlmacenItemE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbicacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idUbicacion = oReader["idUbicacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUbicacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpCostoUnitarioBase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.ImpCostoUnitarioBase = oReader["ImpCostoUnitarioBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpCostoUnitarioBase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpCostoUnitarioRefe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.ImpCostoUnitarioRefe = oReader["ImpCostoUnitarioRefe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpCostoUnitarioRefe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpTotalBase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.ImpTotalBase = oReader["ImpTotalBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpTotalBase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpTotalRefe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.ImpTotalRefe = oReader["ImpTotalRefe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpTotalRefe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCalidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.indCalidad = oReader["indCalidad"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCalidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConformidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.indConformidad = oReader["indConformidad"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indConformidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostosUso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idCCostosUso = oReader["idCCostosUso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostosUso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticuloUso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idArticuloUso = oReader["idArticuloUso"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticuloUso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroEnvases'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.nroEnvases = oReader["nroEnvases"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroEnvases"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Valorizado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.Valorizado = oReader["Valorizado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Valorizado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroParteProd'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.nroParteProd = oReader["nroParteProd"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroParteProd"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItemCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.idItemCompra = oReader["idItemCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItemCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioAnula'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.UsuarioAnula = oReader["UsuarioAnula"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioAnula"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaAnula'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.FechaAnula = oReader["FechaAnula"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaAnula"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.codSerie = oReader["codSerie"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                item.LoteAnterior = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);
            
            return item;
        }

        public MovimientoAlmacenItemE InsertarMovimiento_Almacen_Item(MovimientoAlmacenItemE item)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovimientoAlmacenItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = item.idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = item.tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = item.idDocumentoAlmacen;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 4).Value = item.numItem;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = item.idArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = item.Lote;
                    oComando.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = item.idUbicacion;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = item.Cantidad;
                    oComando.Parameters.Add("@ImpCostoUnitarioBase", SqlDbType.Decimal).Value = item.ImpCostoUnitarioBase;
                    oComando.Parameters.Add("@ImpCostoUnitarioRefe", SqlDbType.Decimal).Value = item.ImpCostoUnitarioRefe;
                    oComando.Parameters.Add("@ImpTotalBase", SqlDbType.Decimal).Value = item.ImpTotalBase;
                    oComando.Parameters.Add("@ImpTotalRefe", SqlDbType.Decimal).Value = item.ImpTotalRefe;
                    oComando.Parameters.Add("@indCalidad", SqlDbType.Bit).Value = item.indCalidad;
                    oComando.Parameters.Add("@indConformidad", SqlDbType.Bit).Value = item.indConformidad;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = item.idCCostos;
                    oComando.Parameters.Add("@idCCostosUso", SqlDbType.VarChar, 4).Value = item.idCCostosUso;
                    oComando.Parameters.Add("@idArticuloUso", SqlDbType.Int).Value = item.idArticuloUso;
                    oComando.Parameters.Add("@nroEnvases", SqlDbType.Int).Value = item.nroEnvases;
                    oComando.Parameters.Add("@Valorizado", SqlDbType.Bit).Value = item.Valorizado;
                    oComando.Parameters.Add("@nroParteProd", SqlDbType.VarChar, 10).Value = item.nroParteProd;
                    oComando.Parameters.Add("@idItemCompra", SqlDbType.Int).Value = item.idItemCompra;
                    oComando.Parameters.Add("@UsuarioAnula", SqlDbType.VarChar, 20).Value = item.UsuarioAnula;
                    oComando.Parameters.Add("@FechaAnula", SqlDbType.SmallDateTime).Value = item.FechaAnula;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = item.UsuarioRegistro;

                    oConexion.Open();
                    item.idItem = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return item;
        }

        public MovimientoAlmacenItemE ActualizarMovimiento_Almacen_Item(MovimientoAlmacenItemE item)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovimientoAlmacenItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = item.idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = item.tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = item.idDocumentoAlmacen;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = item.idItem;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 4).Value = item.numItem;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = item.idArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = item.Lote;
                    oComando.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = item.idUbicacion;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = item.Cantidad;
                    oComando.Parameters.Add("@ImpCostoUnitarioBase", SqlDbType.Decimal).Value = item.ImpCostoUnitarioBase;
                    oComando.Parameters.Add("@ImpCostoUnitarioRefe", SqlDbType.Decimal).Value = item.ImpCostoUnitarioRefe;
                    oComando.Parameters.Add("@ImpTotalBase", SqlDbType.Decimal).Value = item.ImpTotalBase;
                    oComando.Parameters.Add("@ImpTotalRefe", SqlDbType.Decimal).Value = item.ImpTotalRefe;
                    oComando.Parameters.Add("@indCalidad", SqlDbType.Bit).Value = item.indCalidad;
                    oComando.Parameters.Add("@indConformidad", SqlDbType.Bit).Value = item.indConformidad;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = item.idCCostos;
                    oComando.Parameters.Add("@idCCostosUso", SqlDbType.VarChar, 4).Value = item.idCCostosUso;
                    oComando.Parameters.Add("@idArticuloUso", SqlDbType.Int).Value = item.idArticuloUso;
                    oComando.Parameters.Add("@nroEnvases", SqlDbType.Int).Value = item.nroEnvases;
                    oComando.Parameters.Add("@Valorizado", SqlDbType.Bit).Value = item.Valorizado;
                    oComando.Parameters.Add("@nroParteProd", SqlDbType.VarChar, 10).Value = item.nroParteProd;
                    oComando.Parameters.Add("@idItemCompra", SqlDbType.Int).Value = item.idItemCompra;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = item.UsuarioModificacion;

                    //Para la actualizacion del lote en caso sea salida de venta en almacén...
                    oComando.Parameters.Add("@Revisar", SqlDbType.Bit).Value = item.Revisar;
                    oComando.Parameters.Add("@LoteAnterior", SqlDbType.VarChar, 10).Value = item.LoteAnterior;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return item;
        }

        public Int32 EliminarMovimiento_Almacen_Item(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovimientoAlmacenItem", oConexion))
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

        public Int32 EliminarMovimiento_Almacen_ItemTodos(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovimientoAlmacenItemTodos", oConexion))
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

        public List<MovimientoAlmacenItemE> ListarMovimiento_Almacen_Item(Int32 idEmpresa, Int32 idDocumentoAlmacen)
        {
            List<MovimientoAlmacenItemE> listaEntidad = new List<MovimientoAlmacenItemE>();
            MovimientoAlmacenItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovimientoAlmacenItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            //entidad.oLoteEntidad = new LoteAD().ObtenerLote(entidad.idEmpresa, entidad.tipMovimiento, entidad.idDocumentoAlmacen, entidad.Lote);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public MovimientoAlmacenItemE ObtenerMovimiento_Almacen_Item(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem)
        {
            MovimientoAlmacenItemE item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovimientoAlmacenItem", oConexion))
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
                            item = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return item;
        }

        public MovimientoAlmacenItemE ObtenerMovimiento_Almacen_ItemLote(Int32 idEmpresa, Int32 idOrdenCompra, Int32 idItemCompra, String idDocumento, String serDocumento, String numDocumento)
        {
            MovimientoAlmacenItemE item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovimiento_Almacen_ItemLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;
                    oComando.Parameters.Add("@idItemCompra", SqlDbType.Int).Value = idItemCompra;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar,2).Value = idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar,20).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar,20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            item = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return item;
        }

        public MovimientoAlmacenItemE ActualizarLoteMovAlmacen(MovimientoAlmacenItemE item)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLoteMovAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = item.idItem;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = item.Lote;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = item.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return item;
        }

        public Int32 ActualizarCostosAlmacenItem(MovimientoAlmacenItemE item)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCostosAlmacenItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = item.idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = item.tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = item.idDocumentoAlmacen;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = item.idArticulo;
                    oComando.Parameters.Add("@ImpCostoUnitarioBase", SqlDbType.Decimal).Value = item.ImpCostoUnitarioBase;
                    oComando.Parameters.Add("@ImpCostoUnitarioRefe", SqlDbType.Decimal).Value = item.ImpCostoUnitarioRefe;
                    oComando.Parameters.Add("@ImpTotalBase", SqlDbType.Decimal).Value = item.ImpTotalBase;
                    oComando.Parameters.Add("@ImpTotalRefe", SqlDbType.Decimal).Value = item.ImpTotalRefe;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = item.UsuarioModificacion;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

    }
}
