using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class venParametrosAD : DbConection
    {

        public venParametrosE LlenarEntidad(IDataReader oReader)
        {
            venParametrosE parametros = new venParametrosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GeneraAsiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametros.GeneraAsiento = oReader["GeneraAsiento"] == DBNull.Value ? false : Convert.ToBoolean(oReader["GeneraAsiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indFacElec'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.indFacElec = oReader["indFacElec"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indFacElec"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaFacElec'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.FechaFacElec = oReader["FechaFacElec"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaFacElec"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoBoleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.MontoBoleta = oReader["MontoBoleta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoBoleta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Comprometido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.Comprometido = oReader["Comprometido"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Comprometido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='digArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.digArticulo = oReader["digArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["digArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ClienteVarios'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.ClienteVarios = oReader["ClienteVarios"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["ClienteVarios"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EnvioFactEle'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.EnvioFactEle = oReader["EnvioFactEle"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EnvioFactEle"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indListaPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.indListaPrecio = oReader["indListaPrecio"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indListaPrecio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='monPedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.monPedido = oReader["monPedido"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["monPedido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CorreoCobranza'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.CorreoCobranza = oReader["CorreoCobranza"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CorreoCobranza"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.indIgv = oReader["indIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LetraImpresion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.LetraImpresion = oReader["LetraImpresion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LetraImpresion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SizeLetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.SizeLetra = oReader["SizeLetra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["SizeLetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indZona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.indZona = oReader["indZona"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indZona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAfectacionIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.indAfectacionIgv = oReader["indAfectacionIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAfectacionIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoFacturacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.TipoFacturacion = oReader["TipoFacturacion"] == DBNull.Value ? "M" : Convert.ToString(oReader["TipoFacturacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FontPrintLetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.FontPrintLetra = oReader["FontPrintLetra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FontPrintLetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SizeFontLetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.SizeFontLetra = oReader["SizeFontLetra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["SizeFontLetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indNomArtCompuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.indNomArtCompuesto = oReader["indNomArtCompuesto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indNomArtCompuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FontPrintBarras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.FontPrintBarras = oReader["FontPrintBarras"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FontPrintBarras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='digBarras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.digBarras = oReader["digBarras"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["digBarras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticuloCal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.nomArticuloCal = oReader["nomArticuloCal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticuloCal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.indVendedor = oReader["indVendedor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='razonExoIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.razonExoIgv = oReader["razonExoIgv"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["razonExoIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.indBanco = oReader["indBanco"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbl'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.idUbl = oReader["idUbl"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUbl"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoPed'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.TipoPed = oReader["TipoPed"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoPed"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SeriePed'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.SeriePed = oReader["SeriePed"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["SeriePed"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CorrelativoPed'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.CorrelativoPed = oReader["CorrelativoPed"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["CorrelativoPed"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FormatoPed'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.FormatoPed = oReader["FormatoPed"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["FormatoPed"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametros.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            return  parametros;        
        }

        public venParametrosE InsertarVenParametros(venParametrosE parametros)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarVenParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
					oComando.Parameters.Add("@GeneraAsiento", SqlDbType.Bit).Value = parametros.GeneraAsiento;
                    oComando.Parameters.Add("@indFacElec", SqlDbType.Bit).Value = parametros.indFacElec;
                    oComando.Parameters.Add("@FechaFacElec", SqlDbType.Date).Value = parametros.FechaFacElec;
                    oComando.Parameters.Add("@MontoBoleta", SqlDbType.Decimal).Value = parametros.MontoBoleta;
                    oComando.Parameters.Add("@Comprometido", SqlDbType.Bit).Value = parametros.Comprometido;
                    oComando.Parameters.Add("@digArticulo", SqlDbType.Int).Value = parametros.digArticulo;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 500).Value = parametros.Glosa;
                    oComando.Parameters.Add("@ClienteVarios", SqlDbType.Int).Value = parametros.ClienteVarios;
                    oComando.Parameters.Add("@EnvioFactEle", SqlDbType.Bit).Value = parametros.EnvioFactEle;
                    oComando.Parameters.Add("@indListaPrecio", SqlDbType.Bit).Value = parametros.indListaPrecio;
                    oComando.Parameters.Add("@monPedido", SqlDbType.VarChar, 2).Value = parametros.monPedido;
                    oComando.Parameters.Add("@CorreoCobranza", SqlDbType.VarChar, 50).Value = parametros.CorreoCobranza;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = parametros.indIgv;
                    oComando.Parameters.Add("@LetraImpresion", SqlDbType.VarChar, 40).Value = parametros.LetraImpresion;
                    oComando.Parameters.Add("@SizeLetra", SqlDbType.Int).Value = parametros.SizeLetra;
                    oComando.Parameters.Add("@indZona", SqlDbType.Bit).Value = parametros.indZona;
                    oComando.Parameters.Add("@indAfectacionIgv", SqlDbType.Bit).Value = parametros.indAfectacionIgv;
                    oComando.Parameters.Add("@TipoFacturacion", SqlDbType.VarChar, 1).Value = parametros.TipoFacturacion;
                    oComando.Parameters.Add("@FontPrintLetra", SqlDbType.VarChar, 40).Value = parametros.FontPrintLetra;
                    oComando.Parameters.Add("@SizeFontLetra", SqlDbType.Int).Value = parametros.SizeFontLetra;
                    oComando.Parameters.Add("@indNomArtCompuesto", SqlDbType.Bit).Value = parametros.indNomArtCompuesto;
                    oComando.Parameters.Add("@FontPrintBarras", SqlDbType.VarChar, 40).Value = parametros.FontPrintBarras;
                    oComando.Parameters.Add("@digBarras", SqlDbType.Int).Value = parametros.digBarras;
                    oComando.Parameters.Add("@nomArticuloCal", SqlDbType.VarChar, 100).Value = parametros.nomArticuloCal;
                    oComando.Parameters.Add("@indVendedor", SqlDbType.Bit).Value = parametros.indVendedor;
                    oComando.Parameters.Add("@razonExoIgv", SqlDbType.Int).Value = parametros.razonExoIgv;
                    oComando.Parameters.Add("@indBanco", SqlDbType.Bit).Value = parametros.indBanco;
                    oComando.Parameters.Add("@idUbl", SqlDbType.Int).Value = parametros.idUbl;
                    oComando.Parameters.Add("@TipoPed", SqlDbType.Int).Value = parametros.TipoPed;
                    oComando.Parameters.Add("@SeriePed", SqlDbType.VarChar, 3).Value = parametros.SeriePed;
                    oComando.Parameters.Add("@CorrelativoPed", SqlDbType.Int).Value = parametros.CorrelativoPed;
                    oComando.Parameters.Add("@FormatoPed", SqlDbType.VarChar, 20).Value = parametros.FormatoPed;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return parametros;
        }
        
        public venParametrosE ActualizarVenParametros(venParametrosE parametros)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVenParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
					oComando.Parameters.Add("@GeneraAsiento", SqlDbType.Bit).Value = parametros.GeneraAsiento;
                    oComando.Parameters.Add("@indFacElec", SqlDbType.Bit).Value = parametros.indFacElec;
                    oComando.Parameters.Add("@FechaFacElec", SqlDbType.Date).Value = parametros.FechaFacElec;
                    oComando.Parameters.Add("@MontoBoleta", SqlDbType.Decimal).Value = parametros.MontoBoleta;
                    oComando.Parameters.Add("@Comprometido", SqlDbType.Bit).Value = parametros.Comprometido;
                    oComando.Parameters.Add("@digArticulo", SqlDbType.Int).Value = parametros.digArticulo;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 500).Value = parametros.Glosa;
                    oComando.Parameters.Add("@ClienteVarios", SqlDbType.Int).Value = parametros.ClienteVarios;
                    oComando.Parameters.Add("@EnvioFactEle", SqlDbType.Bit).Value = parametros.EnvioFactEle;
                    oComando.Parameters.Add("@indListaPrecio", SqlDbType.Bit).Value = parametros.indListaPrecio;
                    oComando.Parameters.Add("@monPedido", SqlDbType.VarChar, 2).Value = parametros.monPedido;
                    oComando.Parameters.Add("@CorreoCobranza", SqlDbType.VarChar, 50).Value = parametros.CorreoCobranza;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = parametros.indIgv;
                    oComando.Parameters.Add("@LetraImpresion", SqlDbType.VarChar, 40).Value = parametros.LetraImpresion;
                    oComando.Parameters.Add("@SizeLetra", SqlDbType.Int).Value = parametros.SizeLetra;
                    oComando.Parameters.Add("@indZona", SqlDbType.Bit).Value = parametros.indZona;
                    oComando.Parameters.Add("@indAfectacionIgv", SqlDbType.Bit).Value = parametros.indAfectacionIgv;
                    oComando.Parameters.Add("@TipoFacturacion", SqlDbType.VarChar, 1).Value = parametros.TipoFacturacion;
                    oComando.Parameters.Add("@FontPrintLetra", SqlDbType.VarChar, 40).Value = parametros.FontPrintLetra;
                    oComando.Parameters.Add("@SizeFontLetra", SqlDbType.Int).Value = parametros.SizeFontLetra;
                    oComando.Parameters.Add("@indNomArtCompuesto", SqlDbType.Bit).Value = parametros.indNomArtCompuesto;
                    oComando.Parameters.Add("@FontPrintBarras", SqlDbType.VarChar, 40).Value = parametros.FontPrintBarras;
                    oComando.Parameters.Add("@digBarras", SqlDbType.Int).Value = parametros.digBarras;
                    oComando.Parameters.Add("@nomArticuloCal", SqlDbType.VarChar, 100).Value = parametros.nomArticuloCal;
                    oComando.Parameters.Add("@indVendedor", SqlDbType.Bit).Value = parametros.indVendedor;
                    oComando.Parameters.Add("@razonExoIgv", SqlDbType.Int).Value = parametros.razonExoIgv;
                    oComando.Parameters.Add("@indBanco", SqlDbType.Bit).Value = parametros.indBanco;
                    oComando.Parameters.Add("@idUbl", SqlDbType.Int).Value = parametros.idUbl;
                    oComando.Parameters.Add("@TipoPed", SqlDbType.Int).Value = parametros.TipoPed;
                    oComando.Parameters.Add("@SeriePed", SqlDbType.VarChar, 3).Value = parametros.SeriePed;
                    oComando.Parameters.Add("@CorrelativoPed", SqlDbType.Int).Value = parametros.CorrelativoPed;
                    oComando.Parameters.Add("@FormatoPed", SqlDbType.VarChar, 20).Value = parametros.FormatoPed;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return parametros;
        }        

        public List<venParametrosE> ListarVenParametros()
        {
            List<venParametrosE> listaEntidad = new List<venParametrosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVenParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public venParametrosE ObtenerVenParametros(Int32 idEmpresa)
        {        
            venParametrosE parametros = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerVenParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            parametros = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return parametros;
        }

    }
}