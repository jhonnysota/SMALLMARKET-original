using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class SalesPointAD : DbConection
    {

        public SalesPointE LlenarEntidad(IDataReader oReader)
        {
            SalesPointE salespoint = new SalesPointE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdSalesPoint'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				salespoint.IdSalesPoint = oReader["IdSalesPoint"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdSalesPoint"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Host'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				salespoint.Host = oReader["Host"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Host"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				salespoint.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieCaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				salespoint.SerieCaja = oReader["SerieCaja"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieCaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoImpresora'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.TipoImpresora = oReader["TipoImpresora"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoImpresora"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Impresora'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				salespoint.Impresora = oReader["Impresora"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Impresora"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PtoCobro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				salespoint.PtoCobro = oReader["PtoCobro"] == DBNull.Value ? true : Convert.ToBoolean(oReader["PtoCobro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TituloFac'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.TituloFac = oReader["TituloFac"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TituloFac"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.IdFactura = oReader["IdFactura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["IdFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieFactura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.SerieFactura = oReader["SerieFactura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieFactura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TituloBol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.TituloBol = oReader["TituloBol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TituloBol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdBoleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.IdBoleta = oReader["IdBoleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["IdBoleta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieBoleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.SerieBoleta = oReader["SerieBoleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieBoleta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MostrarPrevio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.MostrarPrevio = oReader["MostrarPrevio"] == DBNull.Value ? false : Convert.ToBoolean(oReader["MostrarPrevio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Head1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Head1 = oReader["Head1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Head1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Head2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Head2 = oReader["Head2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Head2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Head3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Head3 = oReader["Head3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Head3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Head4'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Head4 = oReader["Head4"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Head4"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Head5'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Head5 = oReader["Head5"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Head5"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Head6'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Head6 = oReader["Head6"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Head6"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Foot1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Foot1 = oReader["Foot1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Foot1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Foot2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Foot2 = oReader["Foot2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Foot2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Foot3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Foot3 = oReader["Foot3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Foot3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Foot4'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Foot4 = oReader["Foot4"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Foot4"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Foot5'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Foot5 = oReader["Foot5"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Foot5"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Foot6'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.Foot6 = oReader["Foot6"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Foot6"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                salespoint.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  salespoint;        
        }

        public SalesPointE InsertarSalesPoint(SalesPointE salespoint)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarSalesPoint", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Host", SqlDbType.VarChar, 20).Value = salespoint.Host;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = salespoint.Descripcion;
					oComando.Parameters.Add("@SerieCaja", SqlDbType.VarChar, 20).Value = salespoint.SerieCaja;
                    oComando.Parameters.Add("@TipoImpresora", SqlDbType.Char, 1).Value = salespoint.TipoImpresora;
                    oComando.Parameters.Add("@Impresora", SqlDbType.VarChar, 50).Value = salespoint.Impresora;
					oComando.Parameters.Add("@PtoCobro", SqlDbType.Bit).Value = salespoint.PtoCobro;
                    oComando.Parameters.Add("@TituloFac", SqlDbType.VarChar, 50).Value = salespoint.TituloFac;
                    oComando.Parameters.Add("@IdFactura", SqlDbType.VarChar, 2).Value = salespoint.IdFactura;
                    oComando.Parameters.Add("@SerieFactura", SqlDbType.VarChar, 20).Value = salespoint.SerieFactura;
                    oComando.Parameters.Add("@TituloBol", SqlDbType.VarChar, 50).Value = salespoint.TituloBol;
                    oComando.Parameters.Add("@IdBoleta", SqlDbType.VarChar, 2).Value = salespoint.IdBoleta;
                    oComando.Parameters.Add("@SerieBoleta", SqlDbType.VarChar, 20).Value = salespoint.SerieBoleta;
                    oComando.Parameters.Add("@MostrarPrevio", SqlDbType.Bit).Value = salespoint.MostrarPrevio;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = salespoint.idAlmacen;
                    oComando.Parameters.Add("@Head1", SqlDbType.VarChar, 100).Value = salespoint.Head1;
                    oComando.Parameters.Add("@Head2", SqlDbType.VarChar, 100).Value = salespoint.Head2;
                    oComando.Parameters.Add("@Head3", SqlDbType.VarChar, 100).Value = salespoint.Head3;
                    oComando.Parameters.Add("@Head4", SqlDbType.VarChar, 100).Value = salespoint.Head4;
                    oComando.Parameters.Add("@Head5", SqlDbType.VarChar, 100).Value = salespoint.Head5;
                    oComando.Parameters.Add("@Head6", SqlDbType.VarChar, 100).Value = salespoint.Head6;
                    oComando.Parameters.Add("@Foot1", SqlDbType.VarChar, 100).Value = salespoint.Foot1;
                    oComando.Parameters.Add("@Foot2", SqlDbType.VarChar, 100).Value = salespoint.Foot2;
                    oComando.Parameters.Add("@Foot3", SqlDbType.VarChar, 100).Value = salespoint.Foot3;
                    oComando.Parameters.Add("@Foot4", SqlDbType.VarChar, 100).Value = salespoint.Foot4;
                    oComando.Parameters.Add("@Foot5", SqlDbType.VarChar, 100).Value = salespoint.Foot5;
                    oComando.Parameters.Add("@Foot6", SqlDbType.VarChar, 100).Value = salespoint.Foot6;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = salespoint.UsuarioRegistro;

                    oConexion.Open();
                    salespoint.IdSalesPoint = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return salespoint;
        }
        
        public SalesPointE ActualizarSalesPoint(SalesPointE salespoint)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarSalesPoint", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdSalesPoint", SqlDbType.Int).Value = salespoint.IdSalesPoint;
					oComando.Parameters.Add("@Host", SqlDbType.VarChar, 20).Value = salespoint.Host;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = salespoint.Descripcion;
					oComando.Parameters.Add("@SerieCaja", SqlDbType.VarChar, 20).Value = salespoint.SerieCaja;
                    oComando.Parameters.Add("@TipoImpresora", SqlDbType.Char, 1).Value = salespoint.TipoImpresora;
                    oComando.Parameters.Add("@Impresora", SqlDbType.VarChar, 50).Value = salespoint.Impresora;
					oComando.Parameters.Add("@PtoCobro", SqlDbType.Bit).Value = salespoint.PtoCobro;
                    oComando.Parameters.Add("@TituloFac", SqlDbType.VarChar, 50).Value = salespoint.TituloFac;
                    oComando.Parameters.Add("@IdFactura", SqlDbType.VarChar, 2).Value = salespoint.IdFactura;
                    oComando.Parameters.Add("@SerieFactura", SqlDbType.VarChar, 20).Value = salespoint.SerieFactura;
                    oComando.Parameters.Add("@TituloBol", SqlDbType.VarChar, 50).Value = salespoint.TituloBol;
                    oComando.Parameters.Add("@IdBoleta", SqlDbType.VarChar, 2).Value = salespoint.IdBoleta;
                    oComando.Parameters.Add("@SerieBoleta", SqlDbType.VarChar, 20).Value = salespoint.SerieBoleta;
                    oComando.Parameters.Add("@MostrarPrevio", SqlDbType.Bit).Value = salespoint.MostrarPrevio;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = salespoint.idAlmacen;
                    oComando.Parameters.Add("@Head1", SqlDbType.VarChar, 100).Value = salespoint.Head1;
                    oComando.Parameters.Add("@Head2", SqlDbType.VarChar, 100).Value = salespoint.Head2;
                    oComando.Parameters.Add("@Head3", SqlDbType.VarChar, 100).Value = salespoint.Head3;
                    oComando.Parameters.Add("@Head4", SqlDbType.VarChar, 100).Value = salespoint.Head4;
                    oComando.Parameters.Add("@Head5", SqlDbType.VarChar, 100).Value = salespoint.Head5;
                    oComando.Parameters.Add("@Head6", SqlDbType.VarChar, 100).Value = salespoint.Head6;
                    oComando.Parameters.Add("@Foot1", SqlDbType.VarChar, 100).Value = salespoint.Foot1;
                    oComando.Parameters.Add("@Foot2", SqlDbType.VarChar, 100).Value = salespoint.Foot2;
                    oComando.Parameters.Add("@Foot3", SqlDbType.VarChar, 100).Value = salespoint.Foot3;
                    oComando.Parameters.Add("@Foot4", SqlDbType.VarChar, 100).Value = salespoint.Foot4;
                    oComando.Parameters.Add("@Foot5", SqlDbType.VarChar, 100).Value = salespoint.Foot5;
                    oComando.Parameters.Add("@Foot6", SqlDbType.VarChar, 100).Value = salespoint.Foot6;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = salespoint.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return salespoint;
        }        

        public int EliminarSalesPoint(Int32 IdSalesPoint)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarSalesPoint", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdSalesPoint", SqlDbType.Int).Value = IdSalesPoint;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<SalesPointE> ListarSalesPoint()
        {
            List<SalesPointE> listaEntidad = new List<SalesPointE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSalesPoint", oConexion))
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
        
        public SalesPointE ObtenerSalesPoint(Int32 IdSalesPoint)
        {        
            SalesPointE salespoint = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSalesPoint", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdSalesPoint", SqlDbType.Int).Value = IdSalesPoint;
    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            salespoint = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return salespoint;
        }

        public SalesPointE CargarSalesPoint(string Host)
        {
            SalesPointE salespoint = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CargarSalesPoint", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Host", SqlDbType.VarChar, 20).Value = Host;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            salespoint = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return salespoint;
        }

    }
}