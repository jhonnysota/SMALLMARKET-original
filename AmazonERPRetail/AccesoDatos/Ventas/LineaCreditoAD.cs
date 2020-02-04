using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class LineaCreditoAD : DbConection
    {
        
        public LineaCreditoE LlenarEntidad(IDataReader oReader)
        {
            LineaCreditoE lineacredito = new LineaCreditoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Inicio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.Inicio = oReader["Inicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Inicio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fin'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.Fin = oReader["Fin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fin"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Valor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.Valor = oReader["Valor"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Valor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				lineacredito.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  lineacredito;        
        }

        public LineaCreditoE InsertarLineaCredito(LineaCreditoE lineacredito)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = lineacredito.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = lineacredito.idEmpresa;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = lineacredito.idConcepto;
					oComando.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = lineacredito.Inicio;
					oComando.Parameters.Add("@Fin", SqlDbType.DateTime).Value = lineacredito.Fin;
					oComando.Parameters.Add("@Valor", SqlDbType.Decimal).Value = lineacredito.Valor;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = lineacredito.UsuarioRegistro;

                    oConexion.Open();
                    lineacredito.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                    oConexion.Close();
                }
            }

            return lineacredito;
        }
        
        public LineaCreditoE ActualizarLineaCredito(LineaCreditoE lineacredito)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = lineacredito.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = lineacredito.idEmpresa;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = lineacredito.item;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = lineacredito.idConcepto;
					oComando.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = lineacredito.Inicio;
					oComando.Parameters.Add("@Fin", SqlDbType.DateTime).Value = lineacredito.Fin;
					oComando.Parameters.Add("@Valor", SqlDbType.Decimal).Value = lineacredito.Valor;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = lineacredito.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return lineacredito;
        }        

        public int EliminarLineaCredito(Int32 idPersona, Int32 idEmpresa, Int32 item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<LineaCreditoE> ListarLineaCredito()
        {
           List<LineaCreditoE> listaEntidad = new List<LineaCreditoE>();
           LineaCreditoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLineaCredito", oConexion))
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
        
        public LineaCreditoE ObtenerLineaCredito(Int32 idPersona, Int32 idEmpresa, Int32 item)
        {        
            LineaCreditoE lineacredito = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            lineacredito = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return lineacredito;
        }
    }
}