using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioFondoFijoAD : DbConection
    {

        public UsuarioFondoFijoE LlenarEntidad(IDataReader oReader)
        {
            UsuarioFondoFijoE UsuarioFondoFijo = new UsuarioFondoFijoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				UsuarioFondoFijo.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoFondo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.TipoFondo = oReader["TipoFondo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoFondo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Edicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.Edicion = oReader["Edicion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Edicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Edicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.Edicion = oReader["Edicion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Edicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Visualizar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.Visualizar = oReader["Visualizar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Visualizar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				UsuarioFondoFijo.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				UsuarioFondoFijo.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.nomEmpresa = oReader["nomEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUsuario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.nomUsuario = oReader["nomUsuario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUsuario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoFondo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.desTipoFondo = oReader["desTipoFondo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoFondo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Asignacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                UsuarioFondoFijo.Asignacion = oReader["Asignacion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Asignacion"]);

            return  UsuarioFondoFijo;        
        }

        public UsuarioFondoFijoE InsertarUsuarioFondoFijo(UsuarioFondoFijoE UsuarioFondoFijo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = UsuarioFondoFijo.idEmpresa;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = UsuarioFondoFijo.idPersona;
                    oComando.Parameters.Add("@TipoFondo", SqlDbType.Int).Value = UsuarioFondoFijo.TipoFondo;
                    oComando.Parameters.Add("@Edicion", SqlDbType.Bit).Value = UsuarioFondoFijo.Edicion;
                    oComando.Parameters.Add("@Visualizar", SqlDbType.Bit).Value = UsuarioFondoFijo.Visualizar;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = UsuarioFondoFijo.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return UsuarioFondoFijo;
        }
        
        public UsuarioFondoFijoE ActualizarUsuarioFondoFijo(UsuarioFondoFijoE UsuarioFondoFijo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = UsuarioFondoFijo.idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = UsuarioFondoFijo.idPersona;
                    oComando.Parameters.Add("@TipoFondo", SqlDbType.Int).Value = UsuarioFondoFijo.TipoFondo;
                    oComando.Parameters.Add("@Edicion", SqlDbType.Bit).Value = UsuarioFondoFijo.Edicion;
                    oComando.Parameters.Add("@Visualizar", SqlDbType.Bit).Value = UsuarioFondoFijo.Visualizar;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioFondoFijo.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return UsuarioFondoFijo;
        }

        public int EliminarUsuarioFondoFijo(Int32 idEmpresa, Int32 idPersona, Int32 TipoFondo)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@TipoFondo", SqlDbType.Int).Value = TipoFondo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioFondoFijoE> ListarUsuarioFondoFijo(Int32 idEmpresa, Int32 idPersona)
        {
            List<UsuarioFondoFijoE> listaEntidad = new List<UsuarioFondoFijoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

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

        public List<UsuarioFondoFijoE> UsuarioFondoFijoPorIdPersona(Int32 idPersona)
        {
            List<UsuarioFondoFijoE> listaEntidad = new List<UsuarioFondoFijoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UsuarioFondoFijoPorIdPersona", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

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