using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class TransporteConductoresAD : DbConection
    {
        
        public TransporteConductoresE LlenarEntidad(IDataReader oReader)
        {
            TransporteConductoresE transporteconductores = new TransporteConductoresE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTransporte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.idTransporte = oReader["idTransporte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTransporte"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConductor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.idConductor = oReader["idConductor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConductor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Licencia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.Licencia = oReader["Licencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Licencia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.Nombres = oReader["Nombres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombres"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomResumido'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.nomResumido = oReader["nomResumido"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomResumido"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.indEstado = oReader["indEstado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transporteconductores.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  transporteconductores;        
        }

        public TransporteConductoresE InsertarTransporteConductores(TransporteConductoresE transporteconductores)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTransporteConductores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = transporteconductores.idTransporte;
                    oComando.Parameters.Add("@idConductor", SqlDbType.Int).Value = transporteconductores.idConductor;
					oComando.Parameters.Add("@Licencia", SqlDbType.VarChar, 30).Value = transporteconductores.Licencia;
					oComando.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = transporteconductores.Nombres;
					oComando.Parameters.Add("@nomResumido", SqlDbType.VarChar, 50).Value = transporteconductores.nomResumido;
					oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = transporteconductores.indEstado;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = transporteconductores.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return transporteconductores;        
        }
        
        public TransporteConductoresE ActualizarTransporteConductores(TransporteConductoresE transporteconductores)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTransporteConductores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = transporteconductores.idTransporte;
					oComando.Parameters.Add("@idConductor", SqlDbType.Int).Value = transporteconductores.idConductor;
					oComando.Parameters.Add("@Licencia", SqlDbType.VarChar, 30).Value = transporteconductores.Licencia;
					oComando.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = transporteconductores.Nombres;
					oComando.Parameters.Add("@nomResumido", SqlDbType.VarChar, 50).Value = transporteconductores.nomResumido;
					oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = transporteconductores.indEstado;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = transporteconductores.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return transporteconductores;
        }

        public Int32 AnularTransporteConductores(Int32 idTransporte, Int32 idConductor)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularTransporteConductores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = idTransporte;
                    oComando.Parameters.Add("@idConductor", SqlDbType.Int).Value = idConductor;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public void AnularTransporteConductoresTodo(Int32 idTransporte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularTransporteConductoresTodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = idTransporte;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<TransporteConductoresE> ListarTransporteConductores()
        {
            List<TransporteConductoresE> listaEntidad = new List<TransporteConductoresE>();
            TransporteConductoresE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTransporteConductores", oConexion))
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

        public TransporteConductoresE ObtenerTransporteConductores(Int32 idTransporte, Int32 idConductor)
        {        
            TransporteConductoresE transporteconductores = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTransporteConductores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = idTransporte;
                    oComando.Parameters.Add("@idConductor", SqlDbType.Int).Value = idConductor;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            transporteconductores = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return transporteconductores;        
        }

    }
}