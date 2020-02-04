using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class TasaIRentaAD : DbConection
    {
        
        public TasaIRentaE LlenarEntidad(IDataReader oReader)
        {
            TasaIRentaE tasairenta = new TasaIRentaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTasaIRenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasairenta.idTasaIRenta = oReader["idTasaIRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTasaIRenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesTasaIRenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasairenta.DesTasaIRenta = oReader["DesTasaIRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesTasaIRenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Porcentaje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasairenta.Porcentaje = oReader["Porcentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Porcentaje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasairenta.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasairenta.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasairenta.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasairenta.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  tasairenta;        
        }

        public TasaIRentaE InsertarTasaIRenta(TasaIRentaE tasairenta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTasaIRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTasaIRenta", SqlDbType.VarChar, 2).Value = tasairenta.idTasaIRenta;
					oComando.Parameters.Add("@DesTasaIRenta", SqlDbType.VarChar, 100).Value = tasairenta.DesTasaIRenta;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = tasairenta.Porcentaje;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tasairenta.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tasairenta;
        }
        
        public TasaIRentaE ActualizarTasaIRenta(TasaIRentaE tasairenta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTasaIRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTasaIRenta", SqlDbType.VarChar, 2).Value = tasairenta.idTasaIRenta;
					oComando.Parameters.Add("@DesTasaIRenta", SqlDbType.VarChar, 100).Value = tasairenta.DesTasaIRenta;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = tasairenta.Porcentaje;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tasairenta.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tasairenta;
        }        

        public int EliminarTasaIRenta(String idTasaIRenta)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTasaIRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTasaIRenta", SqlDbType.VarChar, 2).Value = idTasaIRenta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TasaIRentaE> ListarTasaIRenta()
        {
           List<TasaIRentaE> listaEntidad = new List<TasaIRentaE>();
           TasaIRentaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTasaIRenta", oConexion))
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
        
        public TasaIRentaE ObtenerTasaIRenta(String idTasaIRenta)
        {        
            TasaIRentaE tasairenta = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTasaIRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTasaIRenta", SqlDbType.VarChar, 2).Value = idTasaIRenta;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tasairenta = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tasairenta;
        }

    }
}