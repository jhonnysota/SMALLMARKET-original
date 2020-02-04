using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class comisionPagoAD : DbConection
    {

        public comisionPagoE LlenarEntidad(IDataReader oReader)
        {
            comisionPagoE comisionpago = new comisionPagoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionpago.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCalculo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionpago.idCalculo = oReader["idCalculo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCalculo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaProceso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionpago.FechaProceso = oReader["FechaProceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaProceso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionpago.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionpago.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionpago.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionpago.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  comisionpago;        
        }

        public comisionPagoE InsertarcomisionPago(comisionPagoE comisionpago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarcomisionPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comisionpago.idEmpresa;
					oComando.Parameters.Add("@FechaProceso", SqlDbType.DateTime).Value = comisionpago.FechaProceso;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = comisionpago.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = comisionpago.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = comisionpago.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = comisionpago.FechaModificacion;

                    oConexion.Open();
                    comisionpago.idCalculo = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return comisionpago;
        }
        
        public comisionPagoE ActualizarcomisionPago(comisionPagoE comisionpago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarcomisionPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comisionpago.idEmpresa;
					oComando.Parameters.Add("@idCalculo", SqlDbType.Int).Value = comisionpago.idCalculo;
					oComando.Parameters.Add("@FechaProceso", SqlDbType.DateTime).Value = comisionpago.FechaProceso;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = comisionpago.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = comisionpago.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = comisionpago.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = comisionpago.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return comisionpago;
        }        

        public int EliminarcomisionPago(Int32 idEmpresa, Int32 idCalculo)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarcomisionPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCalculo", SqlDbType.Int).Value = idCalculo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<comisionPagoE> ListarcomisionPago()
        {
            List<comisionPagoE> listaEntidad = new List<comisionPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarcomisionPago", oConexion))
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
        
        public comisionPagoE ObtenercomisionPago(Int32 idEmpresa, Int32 idCalculo)
        {        
            comisionPagoE comisionpago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenercomisionPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCalculo", SqlDbType.Int).Value = idCalculo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            comisionpago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return comisionpago;
        }

    }
}