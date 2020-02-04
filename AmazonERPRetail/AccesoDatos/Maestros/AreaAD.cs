using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class AreaAD : DbConection
    {

        public Area LlenarEntidadAreas(IDataReader oReader)
        {
            Area Areas = new Area();

            Areas.idArea = Convert.ToInt32(oReader["idArea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName= 'idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(oReader["idEmpresa"]))
                {
                    Areas.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);
                }
            }

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(oReader["idLocal"]))
                {
                    Areas.idLocal = Convert.ToInt32(oReader["idLocal"]);
                }
            }

            oReader.GetSchemaTable().DefaultView.RowFilter = " ColumnName= 'descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1)) 
            {
                if (!Convert.IsDBNull(oReader["descripcion"]))  
                {
                    Areas.descripcion = Convert.ToString(oReader["descripcion"]);  
                }
            }

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(oReader["idLocal"]))
                {
                    Areas.idLocal = Convert.ToInt32(oReader["idLocal"]);
                }
            }

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(oReader["estado"]))
                {
                    Areas.estado = Convert.ToInt32(oReader["estado"]);
                }
            }

			oReader.GetSchemaTable().DefaultView.RowFilter = " ColumnName= 'UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1)) 
            {  
                if (!Convert.IsDBNull(oReader["UsuarioRegistro"]))  
                {
                    Areas.UsuarioRegistro = Convert.ToString(oReader["UsuarioRegistro"]);  
                }
            }

			oReader.GetSchemaTable().DefaultView.RowFilter = " ColumnName= 'UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1)) 
            {  		  
                if (!Convert.IsDBNull(oReader["UsuarioModificacion"]))  
                {
                    Areas.UsuarioModificacion = Convert.ToString(oReader["UsuarioModificacion"]);  
                }
            }
			oReader.GetSchemaTable().DefaultView.RowFilter = " ColumnName= 'FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1)) 
            {  			  
                if (!Convert.IsDBNull(oReader["FechaModificacion"]))  
                {
                    Areas.FechaModificacion = Convert.ToDateTime(oReader["FechaModificacion"]);  
                }
            }
			oReader.GetSchemaTable().DefaultView.RowFilter = " ColumnName= 'FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1)) 
            {			  
                if (!Convert.IsDBNull(oReader["FechaRegistro"]))  
                {
                    Areas.FechaRegistro = Convert.ToDateTime(oReader["FechaRegistro"]);  
                }
            }

            return Areas;
        }

        public Area InsertarArea(Area areas)
        {    
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArea", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = areas.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = areas.idLocal;
                    oComando.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = areas.descripcion;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = areas.estado;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = areas.UsuarioRegistro;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = areas.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
            return areas;        
        }
        
        public Area ActualizarArea(Area areas)
        {          
            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArea", conexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = areas.idArea;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = areas.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = areas.idLocal;
                    oComando.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = areas.descripcion;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = areas.estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = areas.UsuarioModificacion;

                    conexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return areas;
        }

        public List<Area> ListarTodasAreas(Int32 idEmpresa, Int32 idLocal)
        {
            List<Area> ListaAreas = new List<Area>();
            Area entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAreas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidadAreas(oReader);
                            ListaAreas.Add(entidad);
                        }    
                    }
                }
            }

            return ListaAreas;
        }

        public List<Area> BuscarAreaDescripcion(Int32 idEmpresa, Int32 idLocal, String descripcion)
        {
            List<Area> listaEntidad = new List<Area>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAreasPorDescripcion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = descripcion;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Area Areas = new Area
                            {
                                idArea = Convert.ToInt32(oReader["idArea"]),
                                descripcion = oReader["descripcion"].ToString(),
                                estado = Convert.ToInt32(oReader["estado"]),
                                DesEstado = oReader["DesEstado"].ToString()
                            };

                            listaEntidad.Add(Areas);
                        }    
                    }
                }                
            }

            return listaEntidad;
        }

        public List<Area> ListarAreaPorUsuario(Int32 idPersona)
        {
            List<Area> ListaAreas = new List<Area>();
            Area entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAreaPorUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidadAreas(oReader);
                            ListaAreas.Add(entidad);
                        }
                    }
                }
            }

            return ListaAreas;
        }

        public List<Area> ListarTodasAreasPorUsuario(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            List<Area> ListaAreas = new List<Area>();
            Area entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTodasAreasPorUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidadAreas(oReader);
                            ListaAreas.Add(entidad);
                        }
                    }
                }
            }

            return ListaAreas;
        }

    }
}