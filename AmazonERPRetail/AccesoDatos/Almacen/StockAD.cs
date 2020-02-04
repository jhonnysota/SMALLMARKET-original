using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class StockAD : DbConection
    {

        public StockE LlenarEntidad(IDataReader oReader)
        {
            StockE oStock = new StockE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPaisOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.idPaisOrigen = oReader["idPaisOrigen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPaisOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.NombreOrigen = oReader["NombreOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPaisProcedencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.idPaisProcedencia = oReader["idPaisProcedencia"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPaisProcedencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreProcedencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.NombreProcedencia = oReader["NombreProcedencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreProcedencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Batch'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Batch = oReader["Batch"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Batch"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorcentajeGerminacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.PorcentajeGerminacion = oReader["PorcentajeGerminacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorcentajeGerminacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecPrueba'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.fecPrueba = oReader["fecPrueba"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecPrueba"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecProceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.fecProceso = oReader["fecProceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecProceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='canStock'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.canStock = oReader["canStock"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["canStock"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='canStockUD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.canStockUD = oReader["canStockUD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["canStockUD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitPromBase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.CostoUnitPromBase = oReader["CostoUnitPromBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitPromBase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoTotPromBase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.CostoTotPromBase = oReader["CostoTotPromBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoTotPromBase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitPromSecu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.CostoUnitPromSecu = oReader["CostoUnitPromSecu"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitPromSecu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoTotPromSecu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.CostoTotPromSecu = oReader["CostoTotPromSecu"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoTotPromSecu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.nomUMedida = oReader["nomUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoMedAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.codTipoMedAlmacen = oReader["codTipoMedAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codTipoMedAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codUniMedAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.codUniMedAlmacen = oReader["codUniMedAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codUniMedAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorVentaL1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.ValorVentaL1 = oReader["ValorVentaL1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorVentaL1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorVentaL2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.ValorVentaL2 = oReader["ValorVentaL2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorVentaL2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorVentaL3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.ValorVentaL3 = oReader["ValorVentaL3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorVentaL3"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsComprometido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.EsComprometido = oReader["EsComprometido"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsComprometido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.PesoUnitario = oReader["PesoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PesoUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomEspecie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.NomEspecie = oReader["NomEspecie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomEspecie"]);            

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomcomercial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.nomcomercial = oReader["nomcomercial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomcomercial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomColor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.nomColor = oReader["nomColor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomColor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='hibop'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.hibop = oReader["hibop"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["hibop"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='otros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.otros = oReader["otros"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["otros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cacm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.cacm = oReader["cacm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["cacm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='patron'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.patron = oReader["patron"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["patron"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EntregadoPor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.EntregadoPor = oReader["EntregadoPor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EntregadoPor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Nivel1 = oReader["Nivel1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Nivel2 = oReader["Nivel2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Nivel3 = oReader["Nivel3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.nomCorto = oReader["nomCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreExterior'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.NombreExterior = oReader["NombreExterior"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreExterior"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.LoteAlmacen = oReader["LoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.DesMoneda = oReader["DesMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.ValorVenta = oReader["ValorVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.tipDetraccion = oReader["tipDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.TasaDetraccion = oReader["TasaDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomEspecie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.NomEspecie = oReader["NomEspecie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomEspecie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoMedEnvase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.idTipoMedEnvase = oReader["idTipoMedEnvase"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoMedEnvase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUniMedEnvase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.idUniMedEnvase = oReader["idUniMedEnvase"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUniMedEnvase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Marca'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oStock.Marca = oReader["Marca"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["Marca"]);

            return oStock;
        }

        public List<StockE> ListarReporteStockMensual(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes,Int32 indCorte, string fechaHasta)
        {
            List<StockE> ListaStock = new List<StockE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteStockMensual", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@indCorte", SqlDbType.Int).Value = indCorte;
                    oComando.Parameters.Add("@fechaHasta", SqlDbType.VarChar, 8).Value = fechaHasta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaStock.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaStock;
        }

        public List<StockE> ListarReporteStockMensualMuestra(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 indCorte, string fechaHasta)
        {
            List<StockE> ListaStock = new List<StockE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteStockMensualMuestra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@indCorte", SqlDbType.Int).Value = indCorte;
                    oComando.Parameters.Add("@fechaHasta", SqlDbType.VarChar, 8).Value = fechaHasta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaStock.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaStock;
        }

        public List<StockE> ListarReporteStockMensualSL(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 indCorte, string fechaHasta)
        {
            List<StockE> ListaStock = new List<StockE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteStockMensualSL", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@indCorte", SqlDbType.Int).Value = indCorte;
                    oComando.Parameters.Add("@fechaHasta", SqlDbType.VarChar, 8).Value = fechaHasta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaStock.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaStock;
        }

        public List<StockE> ListarStockArticulo(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, Boolean conLote, string codArticulo, string desArticulo, String EsCotizacion)
        {
            List<StockE> oListaArticulos = new List<StockE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarStockArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@conLote", SqlDbType.Bit).Value = conLote;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = codArticulo;
                    oComando.Parameters.Add("@desArticulo", SqlDbType.VarChar, 50).Value = desArticulo;
                    oComando.Parameters.Add("@EsCotizacion", SqlDbType.Char, 1).Value = EsCotizacion;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oListaArticulos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oListaArticulos;
        }

        public StockE ObtenerStockActual(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, Int32 idArticulo, String Anio, String Mes, Boolean conLote, string Lote)
        {
            StockE oStock = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerStockActual", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@conLote", SqlDbType.Bit).Value = conLote;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = Lote;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            oStock = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return oStock;
        }

        public StockE ObtenerStockActualRequeri(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, Int32 idArticulo, String Anio, String Mes, Boolean conLote, string Lote)
        {
            StockE oStock = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerStockActualRequeri", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@conLote", SqlDbType.Bit).Value = conLote;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = Lote;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            oStock = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return oStock;
        }

        public List<StockE> ListarStockArticuloRequeri(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, Boolean conLote, string codArticulo, string desArticulo)
        {
            List<StockE> oListaArticulos = new List<StockE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarStockArticuloRequeri", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@conLote", SqlDbType.Bit).Value = conLote;
                    oComando.Parameters.Add("@codArticulo", SqlDbType.VarChar, 20).Value = codArticulo;
                    oComando.Parameters.Add("@desArticulo", SqlDbType.VarChar, 50).Value = desArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oListaArticulos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oListaArticulos;
        }

        public List<StockE> StockPorIdArticulo(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, Int32 idArticulo, String Anio, String Mes, Boolean conLote)
        {
            List<StockE> oListaArticulos = new List<StockE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_StockPorIdArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@conLote", SqlDbType.Bit).Value = conLote;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oListaArticulos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oListaArticulos;
        }

    }
}
