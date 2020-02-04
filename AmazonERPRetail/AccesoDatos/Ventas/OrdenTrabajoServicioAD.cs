using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class OrdenTrabajoServicioAD : DbConection
    {

        public OrdenTrabajoServicioE LlenarEntidad(IDataReader oReader)
        {
            OrdenTrabajoServicioE ordentrabajoservicio = new OrdenTrabajoServicioE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOT'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.idOT = oReader["idOT"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOT"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numeroOT'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.numeroOT = oReader["numeroOT"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numeroOT"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.FechaEmision = oReader["FechaEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.idArea = oReader["idArea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cotizacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.Cotizacion = oReader["Cotizacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Cotizacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreReal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.NombreReal = oReader["NombreReal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreReal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreImagen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.NombreImagen = oReader["NombreImagen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreImagen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Extension'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.Extension = oReader["Extension"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Extension"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordentrabajoservicio.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.desArea = oReader["desArea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreReal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordentrabajoservicio.ConImagen = oReader["NombreReal"] == DBNull.Value ? false : (String.IsNullOrWhiteSpace((oReader["NombreReal"]).ToString()) ? false : true);

            return  ordentrabajoservicio;        
        }

        public OrdenTrabajoServicioE InsertarOrdenTrabajoServicio(OrdenTrabajoServicioE ordentrabajoservicio)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenTrabajoServicio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordentrabajoservicio.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordentrabajoservicio.idLocal;
					oComando.Parameters.Add("@numeroOT", SqlDbType.VarChar, 20).Value = ordentrabajoservicio.numeroOT;
                    oComando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = ordentrabajoservicio.FechaEmision.Date;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = ordentrabajoservicio.idArea;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ordentrabajoservicio.idPersona;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 800).Value = ordentrabajoservicio.Observacion;
                    oComando.Parameters.Add("@Cotizacion", SqlDbType.VarChar, 20).Value = ordentrabajoservicio.Cotizacion;
                    oComando.Parameters.Add("@NombreReal", SqlDbType.VarChar, 100).Value = ordentrabajoservicio.NombreReal;
                    oComando.Parameters.Add("@NombreImagen", SqlDbType.VarChar, 100).Value = ordentrabajoservicio.NombreImagen;
                    oComando.Parameters.Add("@Extension", SqlDbType.VarChar, 5).Value = ordentrabajoservicio.Extension;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordentrabajoservicio.UsuarioRegistro;

                    oConexion.Open();
                    ordentrabajoservicio.idOT = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordentrabajoservicio;
        }
        
        public OrdenTrabajoServicioE ActualizarOrdenTrabajoServicio(OrdenTrabajoServicioE ordentrabajoservicio)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenTrabajoServicio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordentrabajoservicio.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordentrabajoservicio.idLocal;
					oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = ordentrabajoservicio.idOT;
					oComando.Parameters.Add("@numeroOT", SqlDbType.VarChar, 20).Value = ordentrabajoservicio.numeroOT;
                    oComando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = ordentrabajoservicio.FechaEmision.Date;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = ordentrabajoservicio.idArea;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ordentrabajoservicio.idPersona;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 800).Value = ordentrabajoservicio.Observacion;
                    oComando.Parameters.Add("@Cotizacion", SqlDbType.VarChar, 20).Value = ordentrabajoservicio.Cotizacion;
                    oComando.Parameters.Add("@NombreReal", SqlDbType.VarChar, 100).Value = ordentrabajoservicio.NombreReal;
                    oComando.Parameters.Add("@NombreImagen", SqlDbType.VarChar, 100).Value = ordentrabajoservicio.NombreImagen;
                    oComando.Parameters.Add("@Extension", SqlDbType.VarChar, 5).Value = ordentrabajoservicio.Extension;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordentrabajoservicio.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordentrabajoservicio;
        }        

        public int EliminarOrdenTrabajoServicio(Int32 idEmpresa, Int32 idLocal, Int32 idOT)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenTrabajoServicio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = idOT;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenTrabajoServicioE> ListarOrdenTrabajoServicio(Int32 idEmpresa, Int32 idLocal, Int32 idArea)
        {
            List<OrdenTrabajoServicioE> listaEntidad = new List<OrdenTrabajoServicioE>();
            OrdenTrabajoServicioE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenTrabajoServicio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;

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

        public List<OrdenTrabajoServicioE> ListarOrdenTrabajoServicioPorFilt(Int32 idEmpresa, Int32 idLocal, Int32 idArea)
        {
            List<OrdenTrabajoServicioE> listaEntidad = new List<OrdenTrabajoServicioE>();
            OrdenTrabajoServicioE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenTrabajoServicioPorFiltro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;

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

        public OrdenTrabajoServicioE ObtenerOrdenTrabajoServicio(Int32 idEmpresa, Int32 idLocal, Int32 idOT)
        {        
            OrdenTrabajoServicioE ordentrabajoservicio = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenTrabajoServicio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idOT", SqlDbType.Int).Value = idOT;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordentrabajoservicio = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordentrabajoservicio;
        }

        public List<OrdenTrabajoServicioE> ListarOTServicioPendientes(Int32 idEmpresa, Int32 idLocal,Int32 Personatmp)
        {
            List<OrdenTrabajoServicioE> listaEntidad = new List<OrdenTrabajoServicioE>();
            OrdenTrabajoServicioE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOTServicioPendientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Personatmp", SqlDbType.Int).Value = Personatmp;

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

        public Int32 ObtenerNroOT(Int32 idEmpresa, Int32 idLocal, Int32 idArea)
        {
            Int32 NroOP = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNroOT", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;

                    oConexion.Open();
                    NroOP = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return NroOP;
        }

    }
}