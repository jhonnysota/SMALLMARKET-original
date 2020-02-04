using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class ListaPrecioItemAD : DbConection
    {

        public ListaPrecioItemE LlenarEntidad(IDataReader oReader)
        {
            ListaPrecioItemE listaprecioitem = new ListaPrecioItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idListaPrecio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.idListaPrecio = oReader["idListaPrecio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idListaPrecio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioBruto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.PrecioBruto = oReader["PrecioBruto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioBruto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDscto1'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.PorDscto1 = oReader["PorDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorDscto1"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDscto2'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.PorDscto2 = oReader["PorDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorDscto2"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDscto3'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.PorDscto3 = oReader["PorDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorDscto3"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDscto1'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.MontoDscto1 = oReader["MontoDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDscto1"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDscto2'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.MontoDscto2 = oReader["MontoDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDscto2"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDscto3'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.MontoDscto3 = oReader["MontoDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDscto3"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioValorVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.PrecioValorVenta = oReader["PrecioValorVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioValorVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flgisc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.flgisc = oReader["flgisc"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flgisc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoImpSelectivo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.TipoImpSelectivo = oReader["TipoImpSelectivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoImpSelectivo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porisc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.porisc = oReader["porisc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porisc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='isc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.isc = oReader["isc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["isc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flgigv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.flgigv = oReader["flgigv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flgigv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porigv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.porigv = oReader["porigv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porigv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='igv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.igv = oReader["igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["igv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.PrecioVenta = oReader["PrecioVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Capacidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.Capacidad = oReader["Capacidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Capacidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioVentaConte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.PrecioVentaConte = oReader["PrecioVentaConte"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioVentaConte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.IdUMedida = oReader["IdUMedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdUMedidaD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.IdUMedidaD = oReader["IdUMedidaD"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdUMedidaD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.PrecioD = oReader["PrecioD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDsctoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.PorDsctoD = oReader["PorDsctoD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorDsctoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDsctoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.MontoDsctoD = oReader["MontoDsctoD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDsctoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioValorVentaD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.PrecioValorVentaD = oReader["PrecioValorVentaD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioValorVentaD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FlgIgvD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.FlgIgvD = oReader["FlgIgvD"] == DBNull.Value ? false : Convert.ToBoolean(oReader["FlgIgvD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorIgvD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.PorIgvD = oReader["PorIgvD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorIgvD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.IgvD = oReader["IgvD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioVentaD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.PrecioVentaD = oReader["PrecioVentaD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioVentaD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.Estado = oReader["Estado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				listaprecioitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //extension
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.desTipoArticulo = oReader["desTipoArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoImpSelectivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.desTipoImpSelectivo = oReader["desTipoImpSelectivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoImpSelectivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.nomUMedida = oReader["nomUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ContenidoPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.ContenidoPres = oReader["ContenidoPres"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ContenidoPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomTipoUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.nomTipoUMedida = oReader["nomTipoUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomTipoUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomTipoUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                listaprecioitem.nomTipoUMedidaEnv = oReader["nomTipoUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomTipoUMedidaEnv"]);

            return  listaprecioitem;        
        }

        public ListaPrecioItemE InsertarListaPrecioItem(ListaPrecioItemE listaprecioitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarListaPrecioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = listaprecioitem.idEmpresa;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = listaprecioitem.idListaPrecio;
					oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = listaprecioitem.idTipoArticulo;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = listaprecioitem.idArticulo;
					oComando.Parameters.Add("@PrecioBruto", SqlDbType.Decimal).Value = listaprecioitem.PrecioBruto;
					oComando.Parameters.Add("@PorDscto1", SqlDbType.Decimal).Value = listaprecioitem.PorDscto1;
					oComando.Parameters.Add("@PorDscto2", SqlDbType.Decimal).Value = listaprecioitem.PorDscto2;
					oComando.Parameters.Add("@PorDscto3", SqlDbType.Decimal).Value = listaprecioitem.PorDscto3;
					oComando.Parameters.Add("@MontoDscto1", SqlDbType.Decimal).Value = listaprecioitem.MontoDscto1;
					oComando.Parameters.Add("@MontoDscto2", SqlDbType.Decimal).Value = listaprecioitem.MontoDscto2;
					oComando.Parameters.Add("@MontoDscto3", SqlDbType.Decimal).Value = listaprecioitem.MontoDscto3;
					oComando.Parameters.Add("@PrecioValorVenta", SqlDbType.Decimal).Value = listaprecioitem.PrecioValorVenta;
					oComando.Parameters.Add("@flgisc", SqlDbType.Bit).Value = listaprecioitem.flgisc;
					oComando.Parameters.Add("@TipoImpSelectivo", SqlDbType.Char, 1).Value = listaprecioitem.TipoImpSelectivo;
					oComando.Parameters.Add("@porisc", SqlDbType.Decimal).Value = listaprecioitem.porisc;
					oComando.Parameters.Add("@isc", SqlDbType.Decimal).Value = listaprecioitem.isc;
					oComando.Parameters.Add("@flgigv", SqlDbType.Bit).Value = listaprecioitem.flgigv;
					oComando.Parameters.Add("@porigv", SqlDbType.Decimal).Value = listaprecioitem.porigv;
					oComando.Parameters.Add("@igv", SqlDbType.Decimal).Value = listaprecioitem.igv;
					oComando.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = listaprecioitem.PrecioVenta;
                    oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = listaprecioitem.Capacidad;
                    oComando.Parameters.Add("@Contenido", SqlDbType.Decimal).Value = listaprecioitem.Contenido;
                    oComando.Parameters.Add("@PrecioVentaConte", SqlDbType.Decimal).Value = listaprecioitem.PrecioVentaConte;
                    oComando.Parameters.Add("@PrecioBrutoConte", SqlDbType.Decimal).Value = listaprecioitem.PrecioBrutoConte;
                    oComando.Parameters.Add("@IdUMedida", SqlDbType.Int).Value = listaprecioitem.IdUMedida;
                    oComando.Parameters.Add("@IdUMedidaD", SqlDbType.Int).Value = listaprecioitem.IdUMedidaD;
                    oComando.Parameters.Add("@PrecioD", SqlDbType.Decimal).Value = listaprecioitem.PrecioD;
                    oComando.Parameters.Add("@PorDsctoD", SqlDbType.Decimal).Value = listaprecioitem.PorDsctoD;
                    oComando.Parameters.Add("@MontoDsctoD", SqlDbType.Decimal).Value = listaprecioitem.MontoDsctoD;
                    oComando.Parameters.Add("@PrecioValorVentaD", SqlDbType.Decimal).Value = listaprecioitem.PrecioValorVentaD;
                    oComando.Parameters.Add("@FlgIgvD", SqlDbType.Bit).Value = listaprecioitem.FlgIgvD;
                    oComando.Parameters.Add("@PorIgvD", SqlDbType.Decimal).Value = listaprecioitem.PorIgvD;
                    oComando.Parameters.Add("@IgvD", SqlDbType.Decimal).Value = listaprecioitem.IgvD;
                    oComando.Parameters.Add("@PrecioVentaD", SqlDbType.Decimal).Value = listaprecioitem.PrecioVentaD;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = listaprecioitem.UsuarioRegistro;

                    oConexion.Open();
                    listaprecioitem.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return listaprecioitem;
        }
        
        public ListaPrecioItemE ActualizarListaPrecioItem(ListaPrecioItemE listaprecioitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarListaPrecioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = listaprecioitem.idEmpresa;
					oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = listaprecioitem.idListaPrecio;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = listaprecioitem.item;
					oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = listaprecioitem.idTipoArticulo;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = listaprecioitem.idArticulo;
					oComando.Parameters.Add("@PrecioBruto", SqlDbType.Decimal).Value = listaprecioitem.PrecioBruto;
					oComando.Parameters.Add("@PorDscto1", SqlDbType.Decimal).Value = listaprecioitem.PorDscto1;
					oComando.Parameters.Add("@PorDscto2", SqlDbType.Decimal).Value = listaprecioitem.PorDscto2;
					oComando.Parameters.Add("@PorDscto3", SqlDbType.Decimal).Value = listaprecioitem.PorDscto3;
					oComando.Parameters.Add("@MontoDscto1", SqlDbType.Decimal).Value = listaprecioitem.MontoDscto1;
					oComando.Parameters.Add("@MontoDscto2", SqlDbType.Decimal).Value = listaprecioitem.MontoDscto2;
					oComando.Parameters.Add("@MontoDscto3", SqlDbType.Decimal).Value = listaprecioitem.MontoDscto3;
					oComando.Parameters.Add("@PrecioValorVenta", SqlDbType.Decimal).Value = listaprecioitem.PrecioValorVenta;
					oComando.Parameters.Add("@flgisc", SqlDbType.Bit).Value = listaprecioitem.flgisc;
					oComando.Parameters.Add("@TipoImpSelectivo", SqlDbType.Char, 1).Value = listaprecioitem.TipoImpSelectivo;
					oComando.Parameters.Add("@porisc", SqlDbType.Decimal).Value = listaprecioitem.porisc;
					oComando.Parameters.Add("@isc", SqlDbType.Decimal).Value = listaprecioitem.isc;
					oComando.Parameters.Add("@flgigv", SqlDbType.Bit).Value = listaprecioitem.flgigv;
					oComando.Parameters.Add("@porigv", SqlDbType.Decimal).Value = listaprecioitem.porigv;
					oComando.Parameters.Add("@igv", SqlDbType.Decimal).Value = listaprecioitem.igv;
					oComando.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = listaprecioitem.PrecioVenta;
                    oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = listaprecioitem.Capacidad;
                    oComando.Parameters.Add("@Contenido", SqlDbType.Decimal).Value = listaprecioitem.Contenido;
                    oComando.Parameters.Add("@PrecioVentaConte", SqlDbType.Decimal).Value = listaprecioitem.PrecioVentaConte;
                    oComando.Parameters.Add("@PrecioBrutoConte", SqlDbType.Decimal).Value = listaprecioitem.PrecioBrutoConte;
                    oComando.Parameters.Add("@IdUMedida", SqlDbType.Int).Value = listaprecioitem.IdUMedida;
                    oComando.Parameters.Add("@IdUMedidaD", SqlDbType.Int).Value = listaprecioitem.IdUMedidaD;
                    oComando.Parameters.Add("@PrecioD", SqlDbType.Decimal).Value = listaprecioitem.PrecioD;
                    oComando.Parameters.Add("@PorDsctoD", SqlDbType.Decimal).Value = listaprecioitem.PorDsctoD;
                    oComando.Parameters.Add("@MontoDsctoD", SqlDbType.Decimal).Value = listaprecioitem.MontoDsctoD;
                    oComando.Parameters.Add("@PrecioValorVentaD", SqlDbType.Decimal).Value = listaprecioitem.PrecioValorVentaD;
                    oComando.Parameters.Add("@FlgIgvD", SqlDbType.Bit).Value = listaprecioitem.FlgIgvD;
                    oComando.Parameters.Add("@PorIgvD", SqlDbType.Decimal).Value = listaprecioitem.PorIgvD;
                    oComando.Parameters.Add("@IgvD", SqlDbType.Decimal).Value = listaprecioitem.IgvD;
                    oComando.Parameters.Add("@PrecioVentaD", SqlDbType.Decimal).Value = listaprecioitem.PrecioVentaD;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = listaprecioitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return listaprecioitem;
        }

        public Int32 EliminarListaPrecioItem(Int32 idEmpresa, Int32 idListaPrecio, Int32 item)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarListaPrecioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ListaPrecioItemE> ListarListaPrecioItem(Int32 idEmpresa, Int32 idListaPrecio)
        {
            List<ListaPrecioItemE> listaEntidad = new List<ListaPrecioItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarListaPrecioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;

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
        
        public ListaPrecioItemE ObtenerListaPrecioItem(Int32 idEmpresa, Int32 idListaPrecio, Int32 item)
        {        
            ListaPrecioItemE listaprecioitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerListaPrecioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaprecioitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return listaprecioitem;
        }

        public ListaPrecioItemE ObtenerListaPrecioItemArticulo(Int32 idEmpresa, Int32 idListaPrecio, Int32 idArticulo)
        {
            ListaPrecioItemE listaprecioitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerListaPrecioItemArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaprecioitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return listaprecioitem;
        }

        public Int32 RevisarPrecioItem(Int32 idEmpresa, Int32 idLocal, Int32 idTipoArticulo, Int32 idArticulo, Int32 idListaPrecio)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RevisarPrecioItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@idListaPrecio", SqlDbType.Int).Value = idListaPrecio;

                    oConexion.Open();
                    resp = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return resp;
        }

    }
}