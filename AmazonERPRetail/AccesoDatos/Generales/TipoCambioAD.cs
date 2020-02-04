using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class TipoCambioAD : DbConection
    {
        
        public TipoCambioE LlenarEntidad(IDataReader oReader)
        {
            TipoCambioE tipocambio = new TipoCambioE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.idCambio = oReader["idCambio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.fecCambio = oReader["fecCambio"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["fecCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='valCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.valCompra = oReader["valCompra"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["valCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='valVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.valVenta = oReader["valVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["valVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='valVentaCaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.valVentaCaja = oReader["valVentaCaja"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["valVentaCaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='valCompraCaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.valCompraCaja = oReader["valCompraCaja"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["valCompraCaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipocambio.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return tipocambio;
        }

        public TipoCambioE InsertarTipoCambio(TipoCambioE tipocambio)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTipoCambio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("idMoneda", SqlDbType.Char, 2).Value = tipocambio.idMoneda;
                    oComando.Parameters.Add("@fecCambio", SqlDbType.VarChar, 8).Value = tipocambio.fecCambio;
                    oComando.Parameters.Add("@valCompra", SqlDbType.Decimal).Value = tipocambio.valCompra;
                    oComando.Parameters.Add("@valVenta", SqlDbType.Decimal).Value = tipocambio.valVenta;
                    oComando.Parameters.Add("@valVentaCaja", SqlDbType.Decimal).Value = tipocambio.valVentaCaja;
                    oComando.Parameters.Add("@valCompraCaja", SqlDbType.Decimal).Value = tipocambio.valCompraCaja;
			        oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tipocambio.UsuarioRegistro;

                    oConexion.Open();
                    tipocambio.idCambio = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return tipocambio;        
        }
        
        public TipoCambioE ActualizarTipoCambio(TipoCambioE tipocambio)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTipoCambio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("idMoneda", SqlDbType.Char, 2).Value = tipocambio.idMoneda;
                    oComando.Parameters.Add("@idCambio", SqlDbType.Int).Value = tipocambio.idCambio;
                    oComando.Parameters.Add("@fecCambio", SqlDbType.VarChar, 8).Value = tipocambio.fecCambio;
                    oComando.Parameters.Add("@valCompra", SqlDbType.Decimal).Value = tipocambio.valCompra;
                    oComando.Parameters.Add("@valVenta", SqlDbType.Decimal).Value = tipocambio.valVenta;
                    oComando.Parameters.Add("@valVentaCaja", SqlDbType.Decimal).Value = tipocambio.valVentaCaja;
                    oComando.Parameters.Add("@valCompraCaja", SqlDbType.Decimal).Value = tipocambio.valCompraCaja;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tipocambio.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipocambio;
        }

        public List<TipoCambioE> ListarTipoCambioPorFechas(String idMoneda, string fecIni, string fecFin)
        {
            List<TipoCambioE> listaEntidad = new List<TipoCambioE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoCambioPorFechas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = idMoneda;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;

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

        public TipoCambioE ObtenerTipoCambioPorDia(String idMoneda, string fecCambio)
        {
            TipoCambioE tipocambio = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoCambioPorDia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = idMoneda;
                    oComando.Parameters.Add("@fecCambio", SqlDbType.VarChar, 8).Value = fecCambio;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipocambio = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipocambio;
        }

    }
}