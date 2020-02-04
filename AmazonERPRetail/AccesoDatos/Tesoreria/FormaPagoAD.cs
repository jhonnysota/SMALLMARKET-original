using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class FormaPagoAD : DbConection
    {

        public FormaPagoE LlenarEntidad(IDataReader oReader)
        {
            FormaPagoE formapago = new FormaPagoE();
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapago.codFormaPago = oReader["codFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFormaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapago.desFormaPago = oReader["desFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFormaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indForma'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapago.indForma = oReader["indForma"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indForma"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodForma'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapago.CodForma = oReader["CodForma"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodForma"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoTope'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapago.MontoTope = oReader["MontoTope"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoTope"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDatosBancoAuxi'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formapago.indDatosBancoAuxi = oReader["indDatosBancoAuxi"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDatosBancoAuxi"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMedioPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formapago.codMedioPago = oReader["codMedioPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codMedioPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formapago.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapago.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                formapago.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapago.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  formapago;        
        }

        public FormaPagoE InsertarFormaPago(FormaPagoE formapago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarFormaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@desFormaPago", SqlDbType.VarChar, 30).Value = formapago.desFormaPago;
					oComando.Parameters.Add("@indForma", SqlDbType.Char, 1).Value = formapago.indForma;
					oComando.Parameters.Add("@CodForma", SqlDbType.VarChar, 4).Value = formapago.CodForma;
					oComando.Parameters.Add("@MontoTope", SqlDbType.Decimal).Value = formapago.MontoTope;             
                    oComando.Parameters.Add("@indDatosBancoAuxi", SqlDbType.Bit).Value = formapago.indDatosBancoAuxi;
                    oComando.Parameters.Add("@codMedioPago", SqlDbType.Int).Value = formapago.codMedioPago;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = formapago.UsuarioRegistro;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            formapago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return formapago;
        }
        
        public FormaPagoE ActualizarFormaPago(FormaPagoE formapago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarFormaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = formapago.codFormaPago;
					oComando.Parameters.Add("@desFormaPago", SqlDbType.VarChar, 30).Value = formapago.desFormaPago;
					oComando.Parameters.Add("@indForma", SqlDbType.Char, 1).Value = formapago.indForma;
					oComando.Parameters.Add("@CodForma", SqlDbType.VarChar, 4).Value = formapago.CodForma;
					oComando.Parameters.Add("@MontoTope", SqlDbType.Decimal).Value = formapago.MontoTope;
                    oComando.Parameters.Add("@indDatosBancoAuxi", SqlDbType.Bit).Value = formapago.indDatosBancoAuxi;
                    oComando.Parameters.Add("@codMedioPago", SqlDbType.Int).Value = formapago.codMedioPago;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = formapago.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return formapago;
        }        

        public Int32 EliminarFormaPago(String codFormaPago)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarFormaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = codFormaPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<FormaPagoE> ListarFormaPago()
        {
            List<FormaPagoE> listaEntidad = new List<FormaPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarFormaPago", oConexion))
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
        
        public FormaPagoE ObtenerFormaPago(String codFormaPago)
        {        
            FormaPagoE formapago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerFormaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = codFormaPago;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            formapago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return formapago;
        }

        public List<FormaPagoE> ListarFormaPagoPorTipo(String codTipoPago, Int32 idConcepto, Int32 idEmpresa)
        {
            List<FormaPagoE> listaEntidad = new List<FormaPagoE>();
            FormaPagoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarFormaPagoPorTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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

    }
}