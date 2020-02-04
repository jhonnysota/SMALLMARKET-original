using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OrdenConversionDetalleAD : DbConection
    {

        public OrdenConversionDetalleE LlenarEntidad(IDataReader oReader)
        {
            OrdenConversionDetalleE ordenconversiondetalle = new OrdenConversionDetalleE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenConversion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.idOrdenConversion = oReader["idOrdenConversion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenConversion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Equivalente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.Equivalente = oReader["Equivalente"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Equivalente"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indGenerada'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.indGenerada = oReader["indGenerada"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indGenerada"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["tipMovimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["idDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalPeso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.TotalPeso = oReader["TotalPeso"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalPeso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.CostoUnitario = oReader["CostoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.TotalCosto = oReader["TotalCosto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiondetalle.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
            
            //Extension
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreArt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.NombreArt = oReader["NombreArt"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreArt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.nomAlmacen = oReader["nomAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.contenido = oReader["contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomTipoMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.nomTipoMov = oReader["nomTipoMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomTipoMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiondetalle.LoteAlmacen = oReader["LoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteAlmacen"]);

            return  ordenconversiondetalle;        
        }

        public OrdenConversionDetalleE InsertarOrdenConversionDetalle(OrdenConversionDetalleE ordenconversiondetalle)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenConversionDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversiondetalle.idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = ordenconversiondetalle.idOrdenConversion;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = ordenconversiondetalle.Fecha;
					oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = ordenconversiondetalle.idTipoArticulo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = ordenconversiondetalle.idAlmacen;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = ordenconversiondetalle.idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = ordenconversiondetalle.Lote;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = ordenconversiondetalle.Cantidad;
                    oComando.Parameters.Add("@Equivalente", SqlDbType.Decimal).Value = ordenconversiondetalle.Equivalente;
					oComando.Parameters.Add("@indGenerada", SqlDbType.Bit).Value = ordenconversiondetalle.indGenerada;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = ordenconversiondetalle.tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = ordenconversiondetalle.idDocumentoAlmacen;
                    oComando.Parameters.Add("@TotalPeso", SqlDbType.Decimal).Value = ordenconversiondetalle.TotalPeso;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = ordenconversiondetalle.PesoUnitario;
                    oComando.Parameters.Add("@CostoUnitario", SqlDbType.Decimal).Value = ordenconversiondetalle.CostoUnitario;
                    oComando.Parameters.Add("@TotalCosto", SqlDbType.Decimal).Value = ordenconversiondetalle.TotalCosto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordenconversiondetalle.UsuarioRegistro;

                    oConexion.Open();
                    ordenconversiondetalle.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordenconversiondetalle;
        }
        
        public OrdenConversionDetalleE ActualizarOrdenConversionDetalle(OrdenConversionDetalleE ordenconversiondetalle)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenConversionDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversiondetalle.idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = ordenconversiondetalle.idOrdenConversion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = ordenconversiondetalle.item;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = ordenconversiondetalle.Fecha;
					oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = ordenconversiondetalle.idTipoArticulo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = ordenconversiondetalle.idAlmacen;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = ordenconversiondetalle.idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = ordenconversiondetalle.Lote;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = ordenconversiondetalle.Cantidad;
                    oComando.Parameters.Add("@Equivalente", SqlDbType.Decimal).Value = ordenconversiondetalle.Equivalente;
					oComando.Parameters.Add("@indGenerada", SqlDbType.Bit).Value = ordenconversiondetalle.indGenerada;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = ordenconversiondetalle.tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = ordenconversiondetalle.idDocumentoAlmacen;
                    oComando.Parameters.Add("@TotalPeso", SqlDbType.Decimal).Value = ordenconversiondetalle.TotalPeso;
                    oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = ordenconversiondetalle.PesoUnitario;
                    oComando.Parameters.Add("@CostoUnitario", SqlDbType.Decimal).Value = ordenconversiondetalle.CostoUnitario;
                    oComando.Parameters.Add("@TotalCosto", SqlDbType.Decimal).Value = ordenconversiondetalle.TotalCosto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordenconversiondetalle.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordenconversiondetalle;
        }        

        public int EliminarOrdenConversionDetalle(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenConversionDetalle", oConexion))
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

        public List<OrdenConversionDetalleE> ListarOrdenConversionDetalle(Int32 idEmpresa, Int32 idOrdenConversion)
        {
           List<OrdenConversionDetalleE> listaEntidad = new List<OrdenConversionDetalleE>();
           OrdenConversionDetalleE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenConversionDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;

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
        
        public OrdenConversionDetalleE ObtenerOrdenConversionDetalle(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item)
        {        
            OrdenConversionDetalleE ordenconversiondetalle = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenConversionDetalle", oConexion))
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
                            ordenconversiondetalle = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenconversiondetalle;
        }


        public OrdenConversionDetalleE ActualizarLoteOrdenConversion(OrdenConversionDetalleE ordenconversiondetalle)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLoteOrdenConversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversiondetalle.idEmpresa;
                    oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = ordenconversiondetalle.idOrdenConversion;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = ordenconversiondetalle.item;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = ordenconversiondetalle.Lote;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordenconversiondetalle.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordenconversiondetalle;
        }



    }
}