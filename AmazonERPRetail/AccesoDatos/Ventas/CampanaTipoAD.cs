using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CampanaTipoAD : DbConection
    {
        
        public CampanaTipoE LlenarEntidad(IDataReader oReader)
        {
            CampanaTipoE campanatipo = new CampanaTipoE();     

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campanatipo.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campanatipo.idTipoCampana = oReader["idTipoCampana"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campanatipo.desTipoCampana = oReader["desTipoCampana"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campanatipo.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campanatipo.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campanatipo.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campanatipo.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);


            return campanatipo;
        }

        public CampanaTipoE InsertarCampanaTipo(CampanaTipoE campana)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCampanaTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = campana.idEmpresa;
                    oComando.Parameters.Add("@desTipoCampana", SqlDbType.VarChar, 100).Value = campana.desTipoCampana;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = campana.UsuarioRegistro;


                    oConexion.Open();
                    campana.idTipoCampana = Int32.Parse(oComando.ExecuteScalar().ToString());
                    oConexion.Close();
                }
            }

            return campana;
        }

        public CampanaTipoE ActualizarCampanaTipo(CampanaTipoE campana)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCampanaTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = campana.idEmpresa;
                    oComando.Parameters.Add("@idTipoCampana", SqlDbType.Int).Value = campana.idTipoCampana;
                    oComando.Parameters.Add("@desTipoCampana", SqlDbType.VarChar, 100).Value = campana.desTipoCampana;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = campana.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return campana;
        }

        public int EliminarCampanaTipo(Int32 idTipoCampana, Int32 idEmpresa)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCampanaTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idTipoCampana", SqlDbType.Int).Value = idTipoCampana;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CampanaTipoE> ListarCampanaTipo()
        {
            List<CampanaTipoE> listaEntidad = new List<CampanaTipoE>();
            CampanaTipoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCampanaTipo", oConexion))
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

                oConexion.Close();
            }

            return listaEntidad;
        }

        public List<CampanaTipoE> ListarCampanaTipoPorEmpresa(Int32 idEmpresa)
        {
            List<CampanaTipoE> listaEntidad = new List<CampanaTipoE>();
            CampanaTipoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCampanaTipoPorEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
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

                oConexion.Close();
            }

            return listaEntidad;
        }

        public CampanaTipoE ObtenerCampanaTipo(Int32 idTipoCampana,Int32 idEmpresa)
        {
            CampanaTipoE campana = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCampanaTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoCampana", SqlDbType.Int).Value = idTipoCampana;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            campana = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return campana;
        }

    }
}
