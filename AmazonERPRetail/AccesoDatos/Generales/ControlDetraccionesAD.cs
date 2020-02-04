using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class ControlDetraccionesAD : DbConection
    {

        public ControlDetraccionesE LlenarEntidad(IDataReader oReader)
        {
            ControlDetraccionesE controldetracciones = new ControlDetraccionesE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idControl'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.idControl = oReader["idControl"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idControl"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.idSistema = oReader["idSistema"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSistema"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.idOrdenPago = oReader["idOrdenPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreArchivo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.NombreArchivo = oReader["NombreArchivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreArchivo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				controldetracciones.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FechaRegistro"]);

            return  controldetracciones;        
        }

        public ControlDetraccionesE InsertarControlDetracciones(ControlDetraccionesE controldetracciones)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarControlDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = controldetracciones.idEmpresa;
					oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = controldetracciones.idSistema;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = controldetracciones.idOrdenPago;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = controldetracciones.idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = controldetracciones.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = controldetracciones.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = controldetracciones.numDocumento;
					oComando.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 20).Value = controldetracciones.NombreArchivo;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = controldetracciones.UsuarioRegistro;

                    oConexion.Open();
                    controldetracciones.idControl = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return controldetracciones;
        }
        
        public ControlDetraccionesE ActualizarControlDetracciones(ControlDetraccionesE controldetracciones)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarControlDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = controldetracciones.idControl;
					oComando.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 20).Value = controldetracciones.NombreArchivo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return controldetracciones;
        }        

        public int EliminarControlDetracciones(Int32 idControl)
        {
            int resp = 0;
            
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarControlDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public int EliminarControlDetraccionesPorOp(Int32 idOrdenPago)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarControlDetraccionesPorOp", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ControlDetraccionesE> ListarControlDetracciones(Int32 idEmpresa)
        {
            List<ControlDetraccionesE> listaEntidad = new List<ControlDetraccionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarControlDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

        public List<ControlDetraccionesE> ObtenerControlDetraccionesPorOp(Int32 idOrdenPago)
        {
            List<ControlDetraccionesE> listaEntidad = new List<ControlDetraccionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerControlDetraccionesPorOp", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

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

    }
}