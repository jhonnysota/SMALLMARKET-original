using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class OrdenTrabajoServicioItemAD : DbConection
    {

        public OrdenTrabajoServicioItemE LlenarEntidad(IDataReader oReader)
        {
            OrdenTrabajoServicioItemE ordentrabajoservicioitem = new OrdenTrabajoServicioItemE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOT'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idOT = oReader["idOT"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOT"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Item = oReader["Item"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaEntrega'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.FechaEntrega = oReader["FechaEntrega"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaEntrega"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticuloProducto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idTipoArticuloProducto = oReader["idTipoArticuloProducto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticuloProducto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticuloProducto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idArticuloProducto = oReader["idArticuloProducto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticuloProducto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.PrecioUnitario = oReader["PrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.ValorVenta = oReader["ValorVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flgIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.flgIgv = oReader["flgIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flgIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.desCostos = oReader["desCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.codArticulo2 = oReader["codArticulo2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.desArticulo2 = oReader["desArticulo2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Moneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Moneda = oReader["Moneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Moneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.desArea = oReader["desArea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numeroOT'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.numeroOT = oReader["numeroOT"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numeroOT"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.FechaEmision = oReader["FechaEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.ruc = oReader["ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.igv = oReader["igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SolicitudFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.SolicitudFactura = oReader["SolicitudFactura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SolicitudFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Factura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Factura = oReader["SolicitudFactura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Factura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cotizacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicioitem.Cotizacion = oReader["Cotizacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Cotizacion"]);



            return  ordentrabajoservicioitem;        
        }

        public OrdenTrabajoServicioItemE InsertarOrdenTrabajoServicioItem(OrdenTrabajoServicioItemE ordentrabajoservicioitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenTrabajoServicioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordentrabajoservicioitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordentrabajoservicioitem.idLocal;
					oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = ordentrabajoservicioitem.idOT;
					oComando.Parameters.Add("@Item", SqlDbType.VarChar, 2).Value = ordentrabajoservicioitem.Item;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = ordentrabajoservicioitem.idArticulo;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = ordentrabajoservicioitem.idCCostos;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 800).Value = ordentrabajoservicioitem.Descripcion;
					oComando.Parameters.Add("@FechaEntrega", SqlDbType.SmallDateTime).Value = ordentrabajoservicioitem.FechaEntrega.Value.Date;
					oComando.Parameters.Add("@idTipoArticuloProducto", SqlDbType.Int).Value = ordentrabajoservicioitem.idTipoArticuloProducto;
					oComando.Parameters.Add("@idArticuloProducto", SqlDbType.Int).Value = ordentrabajoservicioitem.idArticuloProducto;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordentrabajoservicioitem.idMoneda;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = ordentrabajoservicioitem.Cantidad;
                    oComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = ordentrabajoservicioitem.PrecioUnitario;
                    oComando.Parameters.Add("@ValorVenta", SqlDbType.Decimal).Value = ordentrabajoservicioitem.ValorVenta;
                    oComando.Parameters.Add("@flgIgv", SqlDbType.Bit).Value = ordentrabajoservicioitem.flgIgv;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = ordentrabajoservicioitem.porIgv;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = ordentrabajoservicioitem.Igv;
                    oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = ordentrabajoservicioitem.Total;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordentrabajoservicioitem.UsuarioRegistro;

                    oConexion.Open();
                    ordentrabajoservicioitem.idItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordentrabajoservicioitem;
        }
        
        public OrdenTrabajoServicioItemE ActualizarOrdenTrabajoServicioItem(OrdenTrabajoServicioItemE ordentrabajoservicioitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenTrabajoServicioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordentrabajoservicioitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordentrabajoservicioitem.idLocal;
					oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = ordentrabajoservicioitem.idOT;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = ordentrabajoservicioitem.idItem;
					oComando.Parameters.Add("@Item", SqlDbType.VarChar, 2).Value = ordentrabajoservicioitem.Item;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = ordentrabajoservicioitem.idArticulo;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = ordentrabajoservicioitem.idCCostos;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 800).Value = ordentrabajoservicioitem.Descripcion;
					oComando.Parameters.Add("@fechaEntrega", SqlDbType.SmallDateTime).Value = ordentrabajoservicioitem.FechaEntrega.Value.Date;
					oComando.Parameters.Add("@idTipoArticuloProducto", SqlDbType.Int).Value = ordentrabajoservicioitem.idTipoArticuloProducto;
					oComando.Parameters.Add("@idArticuloProducto", SqlDbType.Int).Value = ordentrabajoservicioitem.idArticuloProducto;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordentrabajoservicioitem.idMoneda;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = ordentrabajoservicioitem.Cantidad;
                    oComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = ordentrabajoservicioitem.PrecioUnitario;
                    oComando.Parameters.Add("@ValorVenta", SqlDbType.Decimal).Value = ordentrabajoservicioitem.ValorVenta;
                    oComando.Parameters.Add("@flgIgv", SqlDbType.Bit).Value = ordentrabajoservicioitem.flgIgv;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = ordentrabajoservicioitem.porIgv;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = ordentrabajoservicioitem.Igv;
                    oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = ordentrabajoservicioitem.Total;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordentrabajoservicioitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordentrabajoservicioitem;
        }        

        public int EliminarOrdenTrabajoServicioItem(Int32 idEmpresa, Int32 idLocal, Int32 idOT, Int32 idItem)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenTrabajoServicioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = idOT;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenTrabajoServicioItemE> ListarOrdenTrabajoServicioItem(Int32 idEmpresa, Int32 idLocal, Int32 idOT)
        {
           List<OrdenTrabajoServicioItemE> listaEntidad = new List<OrdenTrabajoServicioItemE>();
           OrdenTrabajoServicioItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenTrabajoServicioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = idOT;

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

        public List<OrdenTrabajoServicioItemE> ListarOrdenTrabajoServicioItemTodo()
        {
            List<OrdenTrabajoServicioItemE> listaEntidad = new List<OrdenTrabajoServicioItemE>();
            OrdenTrabajoServicioItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenTrabajoServicioItemAll", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

        public OrdenTrabajoServicioItemE ObtenerOrdenTrabajoServicioItem(Int32 idEmpresa, Int32 idLocal, Int32 idOT, Int32 idItem)
        {        
            OrdenTrabajoServicioItemE ordentrabajoservicioitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenTrabajoServicioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = idOT;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordentrabajoservicioitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordentrabajoservicioitem;
        }

        public List<OrdenTrabajoServicioItemE> ListarReporteOTPorEstado(Int32 idEmpresa, String Estado, Int32 idPersona, Int32 idArea, DateTime fecIni, DateTime fecFin)
        {
            List<OrdenTrabajoServicioItemE> listaEntidad = new List<OrdenTrabajoServicioItemE>();
            OrdenTrabajoServicioItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteOTPorEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;
                    oComando.Parameters.Add("@fecIni", SqlDbType.DateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.DateTime).Value = fecFin;

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

        public void CambiarEstadoDocumentoOT(Int32 idEmpresa, Int32 idLocal, Int32 idOT, Int32 idItem, String Estado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CambiarEstadoOT", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = idOT;
                    oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char).Value = Estado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

    }
}