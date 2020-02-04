using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class TransporteVehiculosAD : DbConection
    {
        
        public TransporteVehiculosE LlenarEntidad(IDataReader oReader)
        {
            TransporteVehiculosE transportevehiculos = new TransporteVehiculosE();
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTransporte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.idTransporte = oReader["idTransporte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTransporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVehiculo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                transportevehiculos.idVehiculo = oReader["idVehiculo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVehiculo"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numPlaca'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.numPlaca = oReader["numPlaca"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numPlaca"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numInscripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.numInscripcion = oReader["numInscripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numInscripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desVehicular'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                transportevehiculos.desVehicular = oReader["desVehicular"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desVehicular"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Marca'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.Marca = oReader["Marca"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Marca"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Capacidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.Capacidad = oReader["Capacidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Capacidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.indEstado = oReader["indEstado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				transportevehiculos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  transportevehiculos;        
        }

        public TransporteVehiculosE InsertarTransporteVehiculos(TransporteVehiculosE transportevehiculos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTransporteVehiculos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = transportevehiculos.idTransporte;
                    oComando.Parameters.Add("@idVehiculo", SqlDbType.Int).Value = transportevehiculos.idVehiculo;
					oComando.Parameters.Add("@numPlaca", SqlDbType.VarChar, 30).Value = transportevehiculos.numPlaca;
					oComando.Parameters.Add("@numInscripcion", SqlDbType.VarChar, 30).Value = transportevehiculos.numInscripcion;
                    oComando.Parameters.Add("@desVehicular", SqlDbType.VarChar, 50).Value = transportevehiculos.desVehicular;
					oComando.Parameters.Add("@Marca", SqlDbType.VarChar, 30).Value = transportevehiculos.Marca;
					oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = transportevehiculos.Capacidad;
					oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = transportevehiculos.indEstado;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = transportevehiculos.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return transportevehiculos;        
        }
        
        public TransporteVehiculosE ActualizarTransporteVehiculos(TransporteVehiculosE transportevehiculos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTransporteVehiculos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = transportevehiculos.idTransporte;
                    oComando.Parameters.Add("@idVehiculo", SqlDbType.Int).Value = transportevehiculos.idVehiculo;
					oComando.Parameters.Add("@numPlaca", SqlDbType.VarChar, 30).Value = transportevehiculos.numPlaca;
					oComando.Parameters.Add("@numInscripcion", SqlDbType.VarChar, 30).Value = transportevehiculos.numInscripcion;
                    oComando.Parameters.Add("@desVehicular", SqlDbType.VarChar, 20).Value = transportevehiculos.desVehicular;
					oComando.Parameters.Add("@Marca", SqlDbType.VarChar, 30).Value = transportevehiculos.Marca;
					oComando.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = transportevehiculos.Capacidad;
					oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = transportevehiculos.indEstado;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = transportevehiculos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return transportevehiculos;
        }        

        public Int32 AnularTransporteVehiculos(Int32 idTransporte, Int32 idVehiculo)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularTransporteVehiculos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = idTransporte;
                    oComando.Parameters.Add("@idVehiculo", SqlDbType.Int).Value = idVehiculo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public void AnularTransporteVehiculosTodos(Int32 idTransporte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularTransporteVehiculosTodos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = idTransporte;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<TransporteVehiculosE> ListarTransporteVehiculos()
        {
            List<TransporteVehiculosE> listaEntidad = new List<TransporteVehiculosE>();
            TransporteVehiculosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTransporteVehiculos", oConexion))
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

        public TransporteVehiculosE ObtenerTransporteVehiculos(Int32 idTransporte, Int32 idVehiculo)
        {        
            TransporteVehiculosE transportevehiculos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTransporteVehiculos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idTransporte", SqlDbType.Int).Value = idTransporte;
                    oComando.Parameters.Add("@idVehiculo", SqlDbType.Int).Value = idVehiculo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            transportevehiculos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return transportevehiculos;        
        }

    }
}