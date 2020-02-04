using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OrdenConversionSalidaAD : DbConection
    {

        

        public OrdenConversionSalidaE LlenarEntidad(IDataReader oReader)
        {
            OrdenConversionSalidaE ordenconversionsalida = new OrdenConversionSalidaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenConversion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.idOrdenConversion = oReader["idOrdenConversion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenConversion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Stock'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.Stock = oReader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Stock"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantSolicitada'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.CantSolicitada = oReader["CantSolicitada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantSolicitada"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalPeso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.TotalPeso = oReader["TotalPeso"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalPeso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpCostoUnitarioBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.ImpCostoUnitarioBase = oReader["ImpCostoUnitarioBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpCostoUnitarioBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpCostoUnitarioRefe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.ImpCostoUnitarioRefe = oReader["ImpCostoUnitarioRefe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpCostoUnitarioRefe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpTotalBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.ImpTotalBase = oReader["ImpTotalBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpTotalBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpTotalRefe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversionsalida.ImpTotalRefe = oReader["ImpTotalRefe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpTotalRefe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["tipMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["idDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreArt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.NombreArt = oReader["NombreArt"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreArt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.LoteAlmacen = oReader["LoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.nomAlmacen = oReader["nomAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.CostoUnitario = oReader["CostoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.TotalCosto = oReader["TotalCosto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.contenido = oReader["contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.cantidad = oReader["cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversionsalida.desTipMovimiento = oReader["desTipMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipMovimiento"]);

            return  ordenconversionsalida;        
        }

        public OrdenConversionSalidaE InsertarOrdenConversionSalida(OrdenConversionSalidaE ordenconversionsalida)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenConversionSalida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversionsalida.idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = ordenconversionsalida.idOrdenConversion;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = ordenconversionsalida.idTipoArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = ordenconversionsalida.idAlmacen;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = ordenconversionsalida.idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = ordenconversionsalida.Lote;
					oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = ordenconversionsalida.Stock;
					oComando.Parameters.Add("@CantSolicitada", SqlDbType.Decimal).Value = ordenconversionsalida.CantSolicitada;
					oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = ordenconversionsalida.PesoUnitario;
					oComando.Parameters.Add("@TotalPeso", SqlDbType.Decimal).Value = ordenconversionsalida.TotalPeso;
					oComando.Parameters.Add("@ImpCostoUnitarioBase", SqlDbType.Decimal).Value = ordenconversionsalida.ImpCostoUnitarioBase;
					oComando.Parameters.Add("@ImpCostoUnitarioRefe", SqlDbType.Decimal).Value = ordenconversionsalida.ImpCostoUnitarioRefe;
					oComando.Parameters.Add("@ImpTotalBase", SqlDbType.Decimal).Value = ordenconversionsalida.ImpTotalBase;
					oComando.Parameters.Add("@ImpTotalRefe", SqlDbType.Decimal).Value = ordenconversionsalida.ImpTotalRefe;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordenconversionsalida.UsuarioRegistro;

                    oConexion.Open();
                    ordenconversionsalida.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordenconversionsalida;
        }
        
        public OrdenConversionSalidaE ActualizarOrdenConversionSalida(OrdenConversionSalidaE ordenconversionsalida)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenConversionSalida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversionsalida.idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = ordenconversionsalida.idOrdenConversion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = ordenconversionsalida.item;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = ordenconversionsalida.idTipoArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = ordenconversionsalida.idAlmacen;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = ordenconversionsalida.idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = ordenconversionsalida.Lote;
					oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = ordenconversionsalida.Stock;
					oComando.Parameters.Add("@CantSolicitada", SqlDbType.Decimal).Value = ordenconversionsalida.CantSolicitada;
					oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = ordenconversionsalida.PesoUnitario;
					oComando.Parameters.Add("@TotalPeso", SqlDbType.Decimal).Value = ordenconversionsalida.TotalPeso;
					oComando.Parameters.Add("@ImpCostoUnitarioBase", SqlDbType.Decimal).Value = ordenconversionsalida.ImpCostoUnitarioBase;
					oComando.Parameters.Add("@ImpCostoUnitarioRefe", SqlDbType.Decimal).Value = ordenconversionsalida.ImpCostoUnitarioRefe;
					oComando.Parameters.Add("@ImpTotalBase", SqlDbType.Decimal).Value = ordenconversionsalida.ImpTotalBase;
					oComando.Parameters.Add("@ImpTotalRefe", SqlDbType.Decimal).Value = ordenconversionsalida.ImpTotalRefe;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordenconversionsalida.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordenconversionsalida;
        }

        public int EliminarOrdenConversionSalida(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenConversionSalida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenConversionSalidaE> ListarOrdenConversionSalida(Int32 idEmpresa, Int32 idOrdenConversion)
        {
            List<OrdenConversionSalidaE> listaEntidad = new List<OrdenConversionSalidaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenConversionSalida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;

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
        
        public OrdenConversionSalidaE ObtenerOrdenConversionSalida(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item)
        {        
            OrdenConversionSalidaE ordenconversionsalida = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenConversionSalida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordenconversionsalida = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenconversionsalida;
        }

        public OrdenConversionSalidaE ActualizarOrdenConversionSalidaMovAlmacen(OrdenConversionSalidaE ordenconversionsalida)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenConversionSalidaMovAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = ordenconversionsalida.item;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = ordenconversionsalida.tipMovimiento;
                    oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = ordenconversionsalida.idDocumentoAlmacen;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordenconversionsalida.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordenconversionsalida;
        }

    }
}