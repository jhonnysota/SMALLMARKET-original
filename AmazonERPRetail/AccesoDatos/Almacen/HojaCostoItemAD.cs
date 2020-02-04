using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class HojaCostoItemAD : DbConection
    {

        public HojaCostoItemE LlenarEntidad(IDataReader oReader)
        {
            HojaCostoItemE hojacostoitem = new HojaCostoItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idHojaCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.idHojaCosto = oReader["idHojaCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idHojaCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItemOC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.idItemOC = oReader["idItemOC"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItemOC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nNivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.nNivel = oReader["nNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nNivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.Nivel = oReader["Nivel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivelinv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.Nivelinv = oReader["Nivelinv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivelinv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PartidaArancelaria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.PartidaArancelaria = oReader["PartidaArancelaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PartidaArancelaria"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Peso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.Peso = oReader["Peso"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Peso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoUmedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.idTipoUmedida = oReader["idTipoUmedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoUmedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUmedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.idUmedida = oReader["idUmedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUmedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FobUnitario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.FobUnitario = oReader["FobUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["FobUnitario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorFob'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.ValorFob = oReader["ValorFob"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorFob"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorPeso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.ValorPeso = oReader["ValorPeso"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorPeso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorVolumen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.ValorVolumen = oReader["ValorVolumen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorVolumen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Flete'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.Flete = oReader["Flete"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Flete"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Seguro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.Seguro = oReader["Seguro"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Seguro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='OtrosCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.OtrosCostos = oReader["OtrosCostos"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["OtrosCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorCif'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.ValorCif = oReader["ValorCif"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorCif"]);
						
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.TCambio = oReader["TCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorTotalDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.ValorTotalDolares = oReader["ValorTotalDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorTotalDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AdValorem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.AdValorem = oReader["AdValorem"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["AdValorem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GstoAduana'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.GstoAduana = oReader["GstoAduana"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["GstoAduana"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GstoComision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.GstoComision = oReader["GstoComision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["GstoComision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GstoSeguro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.GstoSeguro = oReader["GstoSeguro"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["GstoSeguro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GstoBancario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.GstoBancario = oReader["GstoBancario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["GstoBancario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GstoOtros'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.GstoOtros = oReader["GstoOtros"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["GstoOtros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GstoOtrosMN'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.GstoOtrosMN = oReader["GstoOtrosMN"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["GstoOtrosMN"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoTotalMN'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.CostoTotalMN = oReader["CostoTotalMN"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoTotalMN"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitarioMN'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.CostoUnitarioMN = oReader["CostoUnitarioMN"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitarioMN"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoTotalME'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.CostoTotalME = oReader["CostoTotalME"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoTotalME"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitarioME'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.CostoUnitarioME = oReader["CostoUnitarioME"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitarioME"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FactorVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.FactorVenta = oReader["FactorVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["FactorVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.PrecioVenta = oReader["PrecioVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Utilidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.Utilidad = oReader["Utilidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Utilidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extension 
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.NomArticulo = oReader["NomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.nomCorto = oReader["nomCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUmedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.desUmedida = oReader["desUmedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUmedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                hojacostoitem.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            return  hojacostoitem;        
        }

        public HojaCostoItemE InsertarHojaCostoItem(HojaCostoItemE hojacostoitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarHojaCostoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacostoitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacostoitem.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = hojacostoitem.idHojaCosto;
                    oComando.Parameters.Add("@idItemOC", SqlDbType.Int).Value = hojacostoitem.idItemOC;
                    oComando.Parameters.Add("@nNivel", SqlDbType.Int).Value = hojacostoitem.nNivel;
					oComando.Parameters.Add("@Nivel", SqlDbType.VarChar, 1).Value = hojacostoitem.Nivel;
					oComando.Parameters.Add("@Nivelinv", SqlDbType.VarChar, 1).Value = hojacostoitem.Nivelinv;
					oComando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 15).Value = hojacostoitem.PartidaArancelaria;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = hojacostoitem.idArticulo;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = hojacostoitem.Descripcion;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = hojacostoitem.Cantidad;
					oComando.Parameters.Add("@Peso", SqlDbType.Decimal).Value = hojacostoitem.Peso;
					oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = hojacostoitem.PesoUnitario;
                    oComando.Parameters.Add("@idTipoUmedida", SqlDbType.Int).Value = hojacostoitem.idTipoUmedida;
                    oComando.Parameters.Add("@idUmedida", SqlDbType.Int).Value = hojacostoitem.idUmedida;
                    oComando.Parameters.Add("@FobUnitario", SqlDbType.Decimal).Value = hojacostoitem.FobUnitario;
					oComando.Parameters.Add("@ValorFob", SqlDbType.Decimal).Value = hojacostoitem.ValorFob;
					oComando.Parameters.Add("@ValorPeso", SqlDbType.Decimal).Value = hojacostoitem.ValorPeso;
                    //oComando.Parameters.Add("@ValorVolumen", SqlDbType.Decimal).Value = hojacostoitem.ValorVolumen;
                    oComando.Parameters.Add("@Flete", SqlDbType.Decimal).Value = hojacostoitem.Flete;
                    oComando.Parameters.Add("@Seguro", SqlDbType.Decimal).Value = hojacostoitem.Seguro;
                    oComando.Parameters.Add("@OtrosCostos", SqlDbType.Decimal).Value = hojacostoitem.OtrosCostos;
					oComando.Parameters.Add("@ValorCif", SqlDbType.Decimal).Value = hojacostoitem.ValorCif;
					oComando.Parameters.Add("@TCambio", SqlDbType.Decimal).Value = hojacostoitem.TCambio;
                    oComando.Parameters.Add("@ValorTotalDolares", SqlDbType.Decimal).Value = hojacostoitem.ValorTotalDolares;
                    oComando.Parameters.Add("@AdValorem", SqlDbType.Decimal).Value = hojacostoitem.AdValorem;
					oComando.Parameters.Add("@GstoAduana", SqlDbType.Decimal).Value = hojacostoitem.GstoAduana;
					oComando.Parameters.Add("@GstoComision", SqlDbType.Decimal).Value = hojacostoitem.GstoComision;
					oComando.Parameters.Add("@GstoSeguro", SqlDbType.Decimal).Value = hojacostoitem.GstoSeguro;
					oComando.Parameters.Add("@GstoBancario", SqlDbType.Decimal).Value = hojacostoitem.GstoBancario;
					oComando.Parameters.Add("@GstoOtros", SqlDbType.Decimal).Value = hojacostoitem.GstoOtros;
                    oComando.Parameters.Add("@GstoOtrosMN", SqlDbType.Decimal).Value = hojacostoitem.GstoOtrosMN;
                    oComando.Parameters.Add("@CostoTotalMN", SqlDbType.Decimal).Value = hojacostoitem.CostoTotalMN;
					oComando.Parameters.Add("@CostoUnitarioMN", SqlDbType.Decimal).Value = hojacostoitem.CostoUnitarioMN;
					oComando.Parameters.Add("@CostoTotalME", SqlDbType.Decimal).Value = hojacostoitem.CostoTotalME;
					oComando.Parameters.Add("@CostoUnitarioME", SqlDbType.Decimal).Value = hojacostoitem.CostoUnitarioME;
					oComando.Parameters.Add("@FactorVenta", SqlDbType.Decimal).Value = hojacostoitem.FactorVenta;
					oComando.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = hojacostoitem.PrecioVenta;
					oComando.Parameters.Add("@Utilidad", SqlDbType.Decimal).Value = hojacostoitem.Utilidad;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = hojacostoitem.UsuarioRegistro;

                    oConexion.Open();
                    hojacostoitem.item = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return hojacostoitem;
        }
        
        public HojaCostoItemE ActualizarHojaCostoItem(HojaCostoItemE hojacostoitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarHojaCostoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacostoitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacostoitem.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = hojacostoitem.idHojaCosto;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = hojacostoitem.item;
                    oComando.Parameters.Add("@idItemOC", SqlDbType.Int).Value = hojacostoitem.idItemOC;
                    oComando.Parameters.Add("@nNivel", SqlDbType.Int).Value = hojacostoitem.nNivel;
					oComando.Parameters.Add("@Nivel", SqlDbType.VarChar, 1).Value = hojacostoitem.Nivel;
					oComando.Parameters.Add("@Nivelinv", SqlDbType.VarChar, 1).Value = hojacostoitem.Nivelinv;
					oComando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 15).Value = hojacostoitem.PartidaArancelaria;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = hojacostoitem.idArticulo;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = hojacostoitem.Descripcion;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = hojacostoitem.Cantidad;
					oComando.Parameters.Add("@Peso", SqlDbType.Decimal).Value = hojacostoitem.Peso;
					oComando.Parameters.Add("@PesoUnitario", SqlDbType.Decimal).Value = hojacostoitem.PesoUnitario;
                    oComando.Parameters.Add("@idTipoUmedida", SqlDbType.Int).Value = hojacostoitem.idTipoUmedida;
                    oComando.Parameters.Add("@idUmedida", SqlDbType.Int).Value = hojacostoitem.idUmedida;
                    oComando.Parameters.Add("@FobUnitario", SqlDbType.Decimal).Value = hojacostoitem.FobUnitario;
					oComando.Parameters.Add("@ValorFob", SqlDbType.Decimal).Value = hojacostoitem.ValorFob;
					oComando.Parameters.Add("@ValorPeso", SqlDbType.Decimal).Value = hojacostoitem.ValorPeso;
                    //oComando.Parameters.Add("@ValorVolumen", SqlDbType.Decimal).Value = hojacostoitem.ValorVolumen;
                    oComando.Parameters.Add("@Flete", SqlDbType.Decimal).Value = hojacostoitem.Flete;
                    oComando.Parameters.Add("@Seguro", SqlDbType.Decimal).Value = hojacostoitem.Seguro;
                    oComando.Parameters.Add("@OtrosCostos", SqlDbType.Decimal).Value = hojacostoitem.OtrosCostos;
					oComando.Parameters.Add("@ValorCif", SqlDbType.Decimal).Value = hojacostoitem.ValorCif;
					oComando.Parameters.Add("@TCambio", SqlDbType.Decimal).Value = hojacostoitem.TCambio;
                    oComando.Parameters.Add("@ValorTotalDolares", SqlDbType.Decimal).Value = hojacostoitem.ValorTotalDolares;
                    oComando.Parameters.Add("@AdValorem", SqlDbType.Decimal).Value = hojacostoitem.AdValorem;
					oComando.Parameters.Add("@GstoAduana", SqlDbType.Decimal).Value = hojacostoitem.GstoAduana;
					oComando.Parameters.Add("@GstoComision", SqlDbType.Decimal).Value = hojacostoitem.GstoComision;
					oComando.Parameters.Add("@GstoSeguro", SqlDbType.Decimal).Value = hojacostoitem.GstoSeguro;
					oComando.Parameters.Add("@GstoBancario", SqlDbType.Decimal).Value = hojacostoitem.GstoBancario;
					oComando.Parameters.Add("@GstoOtros", SqlDbType.Decimal).Value = hojacostoitem.GstoOtros;
                    oComando.Parameters.Add("@GstoOtrosMN", SqlDbType.Decimal).Value = hojacostoitem.GstoOtrosMN;
                    oComando.Parameters.Add("@CostoTotalMN", SqlDbType.Decimal).Value = hojacostoitem.CostoTotalMN;
					oComando.Parameters.Add("@CostoUnitarioMN", SqlDbType.Decimal).Value = hojacostoitem.CostoUnitarioMN;
					oComando.Parameters.Add("@CostoTotalME", SqlDbType.Decimal).Value = hojacostoitem.CostoTotalME;
					oComando.Parameters.Add("@CostoUnitarioME", SqlDbType.Decimal).Value = hojacostoitem.CostoUnitarioME;
					oComando.Parameters.Add("@FactorVenta", SqlDbType.Decimal).Value = hojacostoitem.FactorVenta;
					oComando.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = hojacostoitem.PrecioVenta;
					oComando.Parameters.Add("@Utilidad", SqlDbType.Decimal).Value = hojacostoitem.Utilidad;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = hojacostoitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return hojacostoitem;
        }        

        public int EliminarHojaCostoItem(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarHojaCostoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<HojaCostoItemE> ListarHojaCostoItem(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {
           List<HojaCostoItemE> listaEntidad = new List<HojaCostoItemE>();
           HojaCostoItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarHojaCostoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;

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
        
        public HojaCostoItemE ObtenerHojaCostoItem(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 item)
        {        
            HojaCostoItemE hojacostoitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerHojaCostoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            hojacostoitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return hojacostoitem;
        }

    }
}