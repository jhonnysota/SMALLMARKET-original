using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class FormaPagoCompFileAD : DbConection
    {
        
        public FormaPagoCompFileE LlenarEntidad(IDataReader oReader)
        {
            FormaPagoCompFileE formapagocompfile = new FormaPagoCompFileE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.codFormaPago = oReader["codFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFormaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				formapagocompfile.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			

            return  formapagocompfile;        
        }

        public FormaPagoCompFileE InsertarFormaPagoCompFile(FormaPagoCompFileE formapagocompfile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarFormaPagoCompFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = formapagocompfile.idEmpresa;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = formapagocompfile.codFormaPago;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = formapagocompfile.idMoneda;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = formapagocompfile.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = formapagocompfile.numFile;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = formapagocompfile.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = formapagocompfile.codCuenta;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = formapagocompfile.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return formapagocompfile;
        }
        
        public FormaPagoCompFileE ActualizarFormaPagoCompFile(FormaPagoCompFileE formapagocompfile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarFormaPagoCompFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = formapagocompfile.idEmpresa;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = formapagocompfile.codFormaPago;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = formapagocompfile.idMoneda;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = formapagocompfile.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = formapagocompfile.numFile;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = formapagocompfile.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = formapagocompfile.codCuenta;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = formapagocompfile.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return formapagocompfile;
        }        

        public Int32 EliminarFormaPagoCompFile(Int32 idEmpresa, String codFormaPago, String idMoneda)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarFormaPagoCompFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = codFormaPago;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = idMoneda;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<FormaPagoCompFileE> ListarFormaPagoCompFile()
        {
           List<FormaPagoCompFileE> listaEntidad = new List<FormaPagoCompFileE>();
           FormaPagoCompFileE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarFormaPagoCompFile", oConexion))
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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public FormaPagoCompFileE ObtenerFormaPagoCompFile(Int32 idEmpresa, String codFormaPago, String idMoneda)
        {        
            FormaPagoCompFileE formapagocompfile = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerFormaPagoCompFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = codFormaPago;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = idMoneda;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            formapagocompfile = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return formapagocompfile;
        }
    }
}