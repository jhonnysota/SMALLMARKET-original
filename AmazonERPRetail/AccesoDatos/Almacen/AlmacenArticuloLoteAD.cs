using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class AlmacenArticuloLoteAD : DbConection
    {

        public AlmacenArticuloLoteE LlenarEntidad(IDataReader oReader)
        {
            AlmacenArticuloLoteE almacenarticulolote = new AlmacenArticuloLoteE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='canStock'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.canStock = oReader["canStock"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["canStock"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitPromBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.CostoUnitPromBase = oReader["CostoUnitPromBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitPromBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitPromSecu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				almacenarticulolote.CostoUnitPromSecu = oReader["CostoUnitPromSecu"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitPromSecu"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacenarticulolote.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacenarticulolote.desAlmacen = oReader["desAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacenarticulolote.LoteProveedor = oReader["LoteProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacenarticulolote.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacenarticulolote.codCuentaDestino = oReader["codCuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacenarticulolote.desCtaDestino = oReader["desCtaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacenarticulolote.TotalSoles = oReader["TotalSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacenarticulolote.TotalDolar = oReader["TotalDolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalDolar"]);

            return  almacenarticulolote;        
        }

        public AlmacenArticuloLoteE InsertarAlmacenArticuloLote(AlmacenArticuloLoteE almacenarticulolote)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarAlmacenArticuloLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = almacenarticulolote.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = almacenarticulolote.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = almacenarticulolote.MesPeriodo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = almacenarticulolote.idAlmacen;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = almacenarticulolote.idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = almacenarticulolote.Lote;
					oComando.Parameters.Add("@canStock", SqlDbType.Decimal).Value = almacenarticulolote.canStock;
					oComando.Parameters.Add("@CostoUnitPromBase", SqlDbType.Decimal).Value = almacenarticulolote.CostoUnitPromBase;
					oComando.Parameters.Add("@CostoUnitPromSecu", SqlDbType.Decimal).Value = almacenarticulolote.CostoUnitPromSecu;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return almacenarticulolote;
        }
        
        public AlmacenArticuloLoteE ActualizarAlmacenArticuloLote(AlmacenArticuloLoteE almacenarticulolote)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAlmacenArticuloLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = almacenarticulolote.idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = almacenarticulolote.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = almacenarticulolote.MesPeriodo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = almacenarticulolote.idAlmacen;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = almacenarticulolote.idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = almacenarticulolote.Lote;
					oComando.Parameters.Add("@canStock", SqlDbType.Decimal).Value = almacenarticulolote.canStock;
					oComando.Parameters.Add("@CostoUnitPromBase", SqlDbType.Decimal).Value = almacenarticulolote.CostoUnitPromBase;
					oComando.Parameters.Add("@CostoUnitPromSecu", SqlDbType.Decimal).Value = almacenarticulolote.CostoUnitPromSecu;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return almacenarticulolote;
        }        

        public int EliminarAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo, String Lote)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAlmacenArticuloLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = Lote;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<AlmacenArticuloLoteE> ListarAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo)
        {
            List<AlmacenArticuloLoteE> listaEntidad = new List<AlmacenArticuloLoteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAlmacenArticuloLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
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
        
        public AlmacenArticuloLoteE ObtenerAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo, String Lote)
        {        
            AlmacenArticuloLoteE almacenarticulolote = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAlmacenArticuloLote", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
					oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = Lote;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            almacenarticulolote = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return almacenarticulolote;
        }

        public AlmacenArticuloLoteE ActualizarStockValorizado(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idOperacion, Int32 idArticulo, String Lote, Decimal Cantidad, Decimal PUBase, Decimal PURefe, String Tipo)
        {
            AlmacenArticuloLoteE almacenarticulolote = new AlmacenArticuloLoteE();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarStockValorizado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
                    oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = idOperacion;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = Lote;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Cantidad;
                    oComando.Parameters.Add("@PUBase", SqlDbType.Decimal).Value = PUBase;
                    oComando.Parameters.Add("@PURefe", SqlDbType.Decimal).Value = PURefe;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 20).Value = Tipo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return almacenarticulolote;
        }

        public List<AlmacenArticuloLoteE> ListarReporteStockSLPorTipoArticulo(Int32 idEmpresa, Int32 TipoArticulo, String Anio, String Mes, Int32 indCorte, string fechaHasta)
        {
            List<AlmacenArticuloLoteE> listaEntidad = new List<AlmacenArticuloLoteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteStockSLPorTipoArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@TipoArticulo", SqlDbType.Int).Value = TipoArticulo;
                    oComando.Parameters.Add("@Anio", SqlDbType.Char, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.Char, 2).Value = Mes;
                    oComando.Parameters.Add("@indCorte", SqlDbType.Int).Value = indCorte;
                    oComando.Parameters.Add("@fechaHasta", SqlDbType.VarChar, 8).Value = fechaHasta;

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

        public List<AlmacenArticuloLoteE> AlmacenArticuloVsSaldos(Int32 idEmpresa, String Anio, String Mes)
        {
            List<AlmacenArticuloLoteE> listaEntidad = new List<AlmacenArticuloLoteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AlmacenArticuloVsSaldos", oConexion))
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

    }
}