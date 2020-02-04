using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class FormaTipoPagoAD : DbConection
    {

        public FormaTipoPagoE LlenarEntidad(IDataReader oReader)
        {
            FormaTipoPagoE formatipopago = new FormaTipoPagoE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formatipopago.codTipoPago = oReader["codTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTipoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formatipopago.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formatipopago.codFormaPago = oReader["codFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFormaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formatipopago.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formatipopago.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formatipopago.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formatipopago.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            //extensiones 
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFormaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formatipopago.desFormaPago = oReader["desFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFormaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formatipopago.desTipoPago = oReader["desTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formatipopago.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formatipopago.desConcepto = oReader["desConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desConcepto"]);

            return  formatipopago;        
        }

        public FormaTipoPagoE InsertarFormaTipoPago(FormaTipoPagoE formatipopago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarFormaTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = formatipopago.codFormaPago;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = formatipopago.codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = formatipopago.idConcepto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = formatipopago.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return formatipopago;
        }
        
        public FormaTipoPagoE ActualizarFormaTipoPago(FormaTipoPagoE formatipopago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarFormaTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = formatipopago.codFormaPago;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = formatipopago.codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = formatipopago.idConcepto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = formatipopago.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return formatipopago;
        }        

        public Int32 EliminarFormaTipoPago(String codTipoPago, Int32 idConcepto, String codFormaPago)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarFormaTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = codFormaPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<FormaTipoPagoE> ListarFormaTipoPago(String codFormaPago, Int32 idEmpresa)
        {
            List<FormaTipoPagoE> listaEntidad = new List<FormaTipoPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarFormaTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = codFormaPago;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public FormaTipoPagoE ObtenerFormaTipoPago(String codFormaPago, String codTipoPago)
        {        
            FormaTipoPagoE formatipopago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerFormaTipoPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = codFormaPago;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            formatipopago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return formatipopago;
        }

    }
}