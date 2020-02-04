using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class EstablecimientosAD : DbConection
    {

        public EstablecimientosE LlenarEntidad(IDataReader oReader)
        {
            EstablecimientosE establecimientos = new EstablecimientosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				establecimientos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				establecimientos.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEstablecimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				establecimientos.idEstablecimiento = oReader["idEstablecimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEstablecimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				establecimientos.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				establecimientos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				establecimientos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				establecimientos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				establecimientos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idZona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                establecimientos.idZona = oReader["idZona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idZona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desZona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                establecimientos.desZona = oReader["desZona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desZona"]);

            return  establecimientos;        
        }

        public EstablecimientosE InsertarEstablecimientos(EstablecimientosE establecimientos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEstablecimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = establecimientos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = establecimientos.idLocal;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = establecimientos.Descripcion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = establecimientos.UsuarioRegistro;

                    oConexion.Open();
                    establecimientos.idEstablecimiento = Convert.ToInt32(oComando.ExecuteScalar().ToString());
                }
            }

            return establecimientos;
        }
        
        public EstablecimientosE ActualizarEstablecimientos(EstablecimientosE establecimientos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstablecimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = establecimientos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = establecimientos.idLocal;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = establecimientos.idEstablecimiento;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = establecimientos.Descripcion;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = establecimientos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return establecimientos;
        }        

        public Int32 EliminarEstablecimientos(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEstablecimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EstablecimientosE> ListarEstablecimientos(Int32 idEmpresa, Int32 idLocal)
        {
           List<EstablecimientosE> listaEntidad = new List<EstablecimientosE>();
           EstablecimientosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEstablecimientos", oConexion))
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
        
        public EstablecimientosE ObtenerEstablecimientos(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento)
        {        
            EstablecimientosE establecimientos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEstablecimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            establecimientos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return establecimientos;
        }

        public EstablecimientosE ObtenerEstablecimientosPorDescripcionEstablecimiento(String Descripcion)
        {
            EstablecimientosE establecimientos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEstablecimientosPorDescripcionEstablecimiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar,100).Value = Descripcion;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            establecimientos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return establecimientos;
        }

        public Int32 DarBajaEstablecimiento(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento, String UsuarioModificacion)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_DarBajaEstablecimiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EstablecimientosE> ListarEstablecimientosZonas(Int32 idEmpresa, Int32 idLocal, int idEstablecimiento)
        {
            List<EstablecimientosE> listaEntidad = new List<EstablecimientosE>();
            EstablecimientosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEstablecimientosZonas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;

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