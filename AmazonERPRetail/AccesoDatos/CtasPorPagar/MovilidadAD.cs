using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class MovilidadAD : DbConection
    {

        public MovilidadE LlenarEntidad(IDataReader oReader)
        {
            MovilidadE movilidad = new MovilidadE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMovilidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.idMovilidad = oReader["idMovilidad"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMovilidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Serie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.Serie = oReader["Serie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Serie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipGastoMovi'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.tipGastoMovi = oReader["tipGastoMovi"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipGastoMovi"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				movilidad.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReparado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movilidad.indReparado = oReader["indReparado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indReparado"]);

            return  movilidad;        
        }

        public MovilidadE InsertarMovilidad(MovilidadE movilidad)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovilidad", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movilidad.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = movilidad.idLocal;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = movilidad.Fecha.Date;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = movilidad.Serie;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = movilidad.Numero;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = movilidad.idPersona;
                    oComando.Parameters.Add("@tipGastoMovi", SqlDbType.Int).Value = movilidad.tipGastoMovi;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = movilidad.UsuarioRegistro;

                    oConexion.Open();
                    movilidad.idMovilidad = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return movilidad;
        }
        
        public MovilidadE ActualizarMovilidad(MovilidadE movilidad)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovilidad", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movilidad.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = movilidad.idLocal;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = movilidad.idMovilidad;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = movilidad.Fecha.Date;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = movilidad.Serie;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = movilidad.Numero;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = movilidad.idPersona;
                    oComando.Parameters.Add("@tipGastoMovi", SqlDbType.Int).Value = movilidad.tipGastoMovi;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movilidad.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movilidad;
        }        

        public int EliminarMovilidad(Int32 idMovilidad)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovilidad", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = idMovilidad;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MovilidadE> ListarMovilidad(Int32 idEmpresa, Int32 idLocal)
        {
           List<MovilidadE> listaEntidad = new List<MovilidadE>();
           MovilidadE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovilidad", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

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
        
        public MovilidadE ObtenerMovilidad(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad)
        {        
            MovilidadE movilidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovilidad", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = idMovilidad;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movilidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movilidad;
        }

        public List<MovilidadE> ListarMovilidadPendientes(Int32 idEmpresa, Int32 idLocal)
        {
            List<MovilidadE> listaEntidad = new List<MovilidadE>();
            MovilidadE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovilidadPendientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

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

        public int ActualizarEstadoMovi(Int32 idMovilidad, Boolean indEstado, String UsuarioModificacion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoMovi", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovilidad", SqlDbType.Int).Value = idMovilidad;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = indEstado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}