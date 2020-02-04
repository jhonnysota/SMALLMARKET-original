using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PresupuestoAD : DbConection
    {

        public PresupuestoE LlenarEntidad(IDataReader oReader)
        {
            PresupuestoE Presupuesto = new PresupuestoE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPresupuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.idPresupuesto = oReader["idPresupuesto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPresupuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Anio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.Anio = oReader["Anio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Anio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);          
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFF'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.idEEFF = oReader["idEEFF"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFF"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Presupuesto.NomMoneda = oReader["NomMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomMoneda"]);
            


            return Presupuesto;
        }

        public PresupuestoE InsertarPresupuesto(PresupuestoE Presupuesto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPresupuesto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = Presupuesto.idEmpresa;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Presupuesto.Descripcion;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Presupuesto.Anio;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = Presupuesto.idMoneda;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = Presupuesto.idEEFF;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = Presupuesto.UsuarioRegistro;

                    oConexion.Open();
                    Presupuesto.idPresupuesto = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return Presupuesto;
        }

        public PresupuestoE ActualizarPresupuesto(PresupuestoE Presupuesto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPresupuesto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = Presupuesto.idEmpresa;
                    oComando.Parameters.Add("@idPresupuesto", SqlDbType.Int).Value = Presupuesto.idPresupuesto;                   
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Presupuesto.Descripcion;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Presupuesto.Anio;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = Presupuesto.idMoneda;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = Presupuesto.idEEFF;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = Presupuesto.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return Presupuesto;
        }

        public int EliminarPresupuesto(Int32 idEmpresa, Int32 idPresupuesto)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPresupuesto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPresupuesto", SqlDbType.Int).Value = idPresupuesto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PresupuestoE> ListarPresupuesto(Int32 idEmpresa)
        {
            List<PresupuestoE> listaEntidad = new List<PresupuestoE>();
            PresupuestoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPresupuesto", oConexion))
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
            }

            return listaEntidad;
        }

        public PresupuestoE ObtenerPresupuesto(Int32 idEmpresa, Int32 idPresupuesto)
        {
            PresupuestoE Presupuesto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPresupuesto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPresupuesto", SqlDbType.Int).Value = idPresupuesto;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Presupuesto = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return Presupuesto;
        }

    }
}
