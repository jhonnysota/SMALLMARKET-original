using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class ZonaTrabajoAD : DbConection
    {
        
        public ZonaTrabajoE LlenarEntidad(IDataReader oReader)
        {
            ZonaTrabajoE zonatrabajo = new ZonaTrabajoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEstablecimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.idEstablecimiento = oReader["idEstablecimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEstablecimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idZona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.idZona = oReader["idZona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idZona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Principal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.Principal = oReader["Principal"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Principal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				zonatrabajo.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstablecimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                zonatrabajo.desEstablecimiento = oReader["desEstablecimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstablecimiento"]);

            return  zonatrabajo;        
        }

        public ZonaTrabajoE InsertarZonaTrabajo(ZonaTrabajoE zonatrabajo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarZonaTrabajo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = zonatrabajo.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = zonatrabajo.idLocal;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = zonatrabajo.idEstablecimiento;
					oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = zonatrabajo.idZona;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = zonatrabajo.Descripcion;
					oComando.Parameters.Add("@Principal", SqlDbType.Bit).Value = zonatrabajo.Principal;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = zonatrabajo.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return zonatrabajo;
        }
        
        public ZonaTrabajoE ActualizarZonaTrabajo(ZonaTrabajoE zonatrabajo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarZonaTrabajo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = zonatrabajo.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = zonatrabajo.idLocal;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = zonatrabajo.idEstablecimiento;
					oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = zonatrabajo.idZona;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = zonatrabajo.Descripcion;
					oComando.Parameters.Add("@Principal", SqlDbType.Bit).Value = zonatrabajo.Principal;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = zonatrabajo.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return zonatrabajo;
        }        

        public Int32 EliminarZonaTrabajo(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento, Int32 idZona)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarZonaTrabajo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = idZona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        //public List<ZonaTrabajoE> ListarZonaTrabajo(Int32 idEmpresa, Int32 idLocal, Int32 idVendedor)
        //{
        //    List<ZonaTrabajoE> listaEntidad = new List<ZonaTrabajoE>();
        //    ZonaTrabajoE entidad = null;

        //    using (SqlConnection oConexion = ConexionSql())
        //    {
        //        using (SqlCommand oComando = new SqlCommand("retail.usp_ListarZonaTrabajo", oConexion))
        //        {
        //            oComando.CommandType = CommandType.StoredProcedure;
        //            oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
        //            oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
        //            oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;

        //            oConexion.Open();
                    
        //            using (SqlDataReader oReader = oComando.ExecuteReader())
        //            {
        //                while (oReader.Read())
        //                {
        //                    entidad = LlenarEntidad(oReader);
        //                    listaEntidad.Add(entidad);
        //                }
        //            }
        //        }
        //    }

        //    return listaEntidad;
        //}
        
        public ZonaTrabajoE ObtenerZonaTrabajo(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento, Int32 idZona)
        {        
            ZonaTrabajoE zonatrabajo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerZonaTrabajo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = idZona;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            zonatrabajo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return zonatrabajo;
        }

        public List<ZonaTrabajoE> ListarZonasPorIdEstablecimiento(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento)
        {
            List<ZonaTrabajoE> listaEntidad = new List<ZonaTrabajoE>();
            ZonaTrabajoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarZonasPorIdEstablecimiento", oConexion))
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