using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class ClonacionTablasAD : DbConection
    {
        
        public ClonacionTablasE LlenarEntidad(IDataReader oReader)
        {
            ClonacionTablasE clonaciontablas = new ClonacionTablasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTabla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clonaciontablas.idTabla = oReader["idTabla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTabla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clonaciontablas.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TablaReal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clonaciontablas.TablaReal = oReader["TablaReal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TablaReal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Orden'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                clonaciontablas.Orden = oReader["Orden"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Orden"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                clonaciontablas.idSistema = oReader["idSistema"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Transferido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                clonaciontablas.Transferido = oReader["Transferido"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Transferido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresaTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                clonaciontablas.idEmpresaTrans = oReader["idEmpresaTrans"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresaTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                clonaciontablas.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clonaciontablas.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clonaciontablas.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clonaciontablas.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clonaciontablas.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                clonaciontablas.RazonSocialTrans = oReader["RazonSocialTrans"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                clonaciontablas.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            return  clonaciontablas;        
        }

        public ClonacionTablasE InsertarClonacionTablas(ClonacionTablasE clonaciontablas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarClonacionTablas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = clonaciontablas.Descripcion;
					oComando.Parameters.Add("@TablaReal", SqlDbType.VarChar, 100).Value = clonaciontablas.TablaReal;
                    oComando.Parameters.Add("@Orden", SqlDbType.Int).Value = clonaciontablas.Orden;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = clonaciontablas.idSistema;
                    oComando.Parameters.Add("@Transferido", SqlDbType.Bit).Value = clonaciontablas.Transferido;
                    oComando.Parameters.Add("@idEmpresaTrans", SqlDbType.Int).Value = clonaciontablas.idEmpresaTrans;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = clonaciontablas.idEmpresa;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = clonaciontablas.UsuarioRegistro;

                    oConexion.Open();
                    clonaciontablas.idTabla = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return clonaciontablas;
        }
        
        public ClonacionTablasE ActualizarClonacionTablas(ClonacionTablasE clonaciontablas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarClonacionTablas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTabla", SqlDbType.Int).Value = clonaciontablas.idTabla;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = clonaciontablas.Descripcion;
					oComando.Parameters.Add("@TablaReal", SqlDbType.VarChar, 100).Value = clonaciontablas.TablaReal;
                    oComando.Parameters.Add("@Orden", SqlDbType.Int).Value = clonaciontablas.Orden;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = clonaciontablas.idSistema;
                    oComando.Parameters.Add("@Transferido", SqlDbType.Bit).Value = clonaciontablas.Transferido;
                    oComando.Parameters.Add("@idEmpresaTrans", SqlDbType.Int).Value = clonaciontablas.idEmpresaTrans;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = clonaciontablas.idEmpresa;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = clonaciontablas.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return clonaciontablas;
        }

        public Int32 EliminarClonacionTablas(Int32 idTabla)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarClonacionTablas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTabla", SqlDbType.Int).Value = idTabla;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ClonacionTablasE> ListarClonacionTablas()
        {
           List<ClonacionTablasE> listaEntidad = new List<ClonacionTablasE>();
           ClonacionTablasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarClonacionTablas", oConexion))
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
        
        public ClonacionTablasE ObtenerClonacionTablas(Int32 idTabla)
        {        
            ClonacionTablasE clonaciontablas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerClonacionTablas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTabla", SqlDbType.Int).Value = idTabla;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            clonaciontablas = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return clonaciontablas;
        }

        public List<ClonacionTablasE> ListarTablasPorSistema(Int32 idSistema)
        {
            List<ClonacionTablasE> listaEntidad = new List<ClonacionTablasE>();
            ClonacionTablasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTablasPorSistema", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

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

        public List<ClonacionTablasE> ListarTablasTransferidas(Int32 idEmpresaTrans, Boolean Transferido)
        {
            List<ClonacionTablasE> listaEntidad = new List<ClonacionTablasE>();
            ClonacionTablasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTablasTransferidas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresaTrans", SqlDbType.Int).Value = idEmpresaTrans;
                    oComando.Parameters.Add("@Transferido", SqlDbType.Bit).Value = Transferido;

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

        public Int32 ClonarTablas(Int32 idEmpresa, Int32 idEmpresaTrans, String Tabla, String Columnas)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ClonarTablas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEmpresaTrans", SqlDbType.Int).Value = idEmpresaTrans;
                    oComando.Parameters.Add("@Tabla", SqlDbType.VarChar, 100).Value = Tabla;
                    oComando.Parameters.Add("@Columnas", SqlDbType.VarChar, 1000).Value = Columnas;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarTablasTransferidas(Int32 idEmpresaTrans, String Tabla)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTablasTransferidas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresaTrans", SqlDbType.Int).Value = idEmpresaTrans;
                    oComando.Parameters.Add("@Tabla", SqlDbType.VarChar, 100).Value = Tabla;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}