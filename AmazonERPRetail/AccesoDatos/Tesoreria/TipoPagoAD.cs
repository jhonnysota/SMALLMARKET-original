using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class TipoPagoAD : DbConection
    {

        public TipoPagoE LlenarEntidad(IDataReader oReader)
        {
            TipoPagoE tipopago = new TipoPagoE();
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopago.codTipoPago = oReader["codTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTipoPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopago.desTipoPago = oReader["desTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopago.indTipo = oReader["indTipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indTipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopago.codTipo = oReader["codTipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetalle'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopago.indDetalle = oReader["indDetalle"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetalle"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HabilitarDatos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopago.HabilitarDatos = oReader["HabilitarDatos"] == DBNull.Value ? false : Convert.ToBoolean(oReader["HabilitarDatos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indSolProv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopago.indSolProv = oReader["indSolProv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indSolProv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopago.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopago.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopago.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopago.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopago.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  tipopago;        
        }

        public TipoPagoE InsertarTipoPago(TipoPagoE tipopago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@desTipoPago", SqlDbType.VarChar, 50).Value = tipopago.desTipoPago;
					oComando.Parameters.Add("@indTipo", SqlDbType.Char, 1).Value = tipopago.indTipo;
					oComando.Parameters.Add("@codTipo", SqlDbType.VarChar, 4).Value = tipopago.codTipo;
                    oComando.Parameters.Add("@indDetalle", SqlDbType.Bit).Value = tipopago.indDetalle;
                    oComando.Parameters.Add("@HabilitarDatos", SqlDbType.Bit).Value = tipopago.HabilitarDatos;
                    oComando.Parameters.Add("@indSolProv", SqlDbType.Bit).Value = tipopago.indSolProv;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tipopago.UsuarioRegistro;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipopago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipopago;
        }
        
        public TipoPagoE ActualizarTipoPago(TipoPagoE tipopago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = tipopago.codTipoPago;
					oComando.Parameters.Add("@desTipoPago", SqlDbType.VarChar, 50).Value = tipopago.desTipoPago;
					oComando.Parameters.Add("@indTipo", SqlDbType.Char, 1).Value = tipopago.indTipo;
					oComando.Parameters.Add("@codTipo", SqlDbType.VarChar, 4).Value = tipopago.codTipo;
                    oComando.Parameters.Add("@indDetalle", SqlDbType.Bit).Value = tipopago.indDetalle;
                    oComando.Parameters.Add("@HabilitarDatos", SqlDbType.Bit).Value = tipopago.HabilitarDatos;
                    oComando.Parameters.Add("@indSolProv", SqlDbType.Bit).Value = tipopago.indSolProv;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tipopago.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipopago;
        }        

        public Int32 EliminarTipoPago( String codTipoPago)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 AnularTipoPago(String codTipoPago, String UsuarioModificacion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TipoPagoE> ListarTipoPago()
        {
            List<TipoPagoE> listaEntidad = new List<TipoPagoE>();
            TipoPagoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoPago", oConexion))
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
        
        public TipoPagoE ObtenerTipoPago(String codTipoPago)
        {        
            TipoPagoE tipopago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipopago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipopago;
        }

        public List<TipoPagoE> ListarTipoPagoCombo(String indTipo)
        {
            List<TipoPagoE> listaEntidad = new List<TipoPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoPagoCombo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@indTipo", SqlDbType.Char, 1).Value = indTipo;

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

        public TipoPagoE ObtenerTipoPagoPorTipo(String codTipo)
        {
            TipoPagoE tipopago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoPagoPorTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codTipo", SqlDbType.VarChar, 4).Value = codTipo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipopago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipopago;
        }

    }
}