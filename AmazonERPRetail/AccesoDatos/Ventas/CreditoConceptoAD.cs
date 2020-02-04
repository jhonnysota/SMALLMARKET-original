using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CreditoConceptoAD : DbConection
    {
        
        public CreditoConceptoE LlenarEntidad(IDataReader oReader)
        {
            CreditoConceptoE creditoconcepto = new CreditoConceptoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				creditoconcepto.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				creditoconcepto.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				creditoconcepto.flagMoneda = oReader["flagMoneda"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				creditoconcepto.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				creditoconcepto.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				creditoconcepto.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				creditoconcepto.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				creditoconcepto.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  creditoconcepto;        
        }

        public CreditoConceptoE InsertarCreditoConcepto(CreditoConceptoE creditoconcepto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCreditoConcepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    //oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = creditoconcepto.idConcepto;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = creditoconcepto.Descripcion;
					oComando.Parameters.Add("@flagMoneda", SqlDbType.Bit).Value = creditoconcepto.flagMoneda;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = creditoconcepto.idMoneda;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = creditoconcepto.UsuarioRegistro;
                    //oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = creditoconcepto.FechaRegistro;
                    //oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = creditoconcepto.UsuarioModificacion;
                    //oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = creditoconcepto.FechaModificacion;

                    oConexion.Open();
                    creditoconcepto.idConcepto = Int32.Parse(oComando.ExecuteScalar().ToString());
                    oConexion.Close();
                }
            }

            return creditoconcepto;
        }
        
        public CreditoConceptoE ActualizarCreditoConcepto(CreditoConceptoE creditoconcepto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCreditoConcepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = creditoconcepto.idConcepto;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = creditoconcepto.Descripcion;
					oComando.Parameters.Add("@flagMoneda", SqlDbType.Bit).Value = creditoconcepto.flagMoneda;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = creditoconcepto.idMoneda;
                    //oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = creditoconcepto.UsuarioRegistro;
                    //oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = creditoconcepto.FechaRegistro;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = creditoconcepto.UsuarioModificacion;
                    //oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = creditoconcepto.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return creditoconcepto;
        }        

        public int EliminarCreditoConcepto(Int32 idConcepto)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCreditoConcepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CreditoConceptoE> ListarCreditoConcepto()
        {
           List<CreditoConceptoE> listaEntidad = new List<CreditoConceptoE>();
           CreditoConceptoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCreditoConcepto", oConexion))
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
        
        public CreditoConceptoE ObtenerCreditoConcepto(Int32 idConcepto)
        {        
            CreditoConceptoE creditoconcepto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCreditoConcepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            creditoconcepto = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return creditoconcepto;
        }
    }
}