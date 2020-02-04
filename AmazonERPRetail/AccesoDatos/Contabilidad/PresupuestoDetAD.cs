using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PresupuestoDetAD : DbConection
    {

        public PresupuestoDetE LlenarEntidad(IDataReader oReader)
        {
            PresupuestoDetE PresupuestoDet = new PresupuestoDetE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPresupuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.idPresupuesto = oReader["idPresupuesto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPresupuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.idEEFFItem = oReader["idEEFFItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPresupuestoItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.idPresupuestoItem = oReader["idPresupuestoItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPresupuestoItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Anio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.Anio = oReader["Anio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Anio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.Mes = oReader["Mes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.DesItem = oReader["DesItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomMes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                PresupuestoDet.NomMes = oReader["NomMes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomMes"]);          




            return PresupuestoDet;
        }

        public PresupuestoDetE InsertarPresupuestoDet(PresupuestoDetE PresupuestoDet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPresupuestoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = PresupuestoDet.idEmpresa;
                    oComando.Parameters.Add("@idPresupuesto", SqlDbType.Int).Value = PresupuestoDet.idPresupuesto;         
                    oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = PresupuestoDet.idEEFFItem;                                
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = PresupuestoDet.Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = PresupuestoDet.Mes;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = PresupuestoDet.Monto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = PresupuestoDet.UsuarioRegistro;

                    oConexion.Open();
                    PresupuestoDet.idPresupuestoItem= Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return PresupuestoDet;
        }

        public PresupuestoDetE ActualizarPresupuestoDet(PresupuestoDetE PresupuestoDet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPresupuestoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = PresupuestoDet.idEmpresa;
                    oComando.Parameters.Add("@idPresupuesto", SqlDbType.VarChar, 3).Value = PresupuestoDet.idPresupuesto;
                    oComando.Parameters.Add("@idPresupuestoItem", SqlDbType.Int).Value = PresupuestoDet.idPresupuestoItem;
                    oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = PresupuestoDet.idEEFFItem;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = PresupuestoDet.Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = PresupuestoDet.Mes;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = PresupuestoDet.Monto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = PresupuestoDet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return PresupuestoDet;
        }

        public int EliminarPresupuestoDet(Int32 idEmpresa, Int32 idPresupuesto, Int32 idPresupuestoItem)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPresupuestoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPresupuesto", SqlDbType.Int).Value = idPresupuesto;
                    oComando.Parameters.Add("@idPresupuestoItem", SqlDbType.Int).Value = idPresupuestoItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PresupuestoDetE> ListarPresupuestoDet(Int32 idEmpresa , Int32 idPresupuesto)
        {
            List<PresupuestoDetE> listaEntidad = new List<PresupuestoDetE>();
            PresupuestoDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPresupuestoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPresupuesto", SqlDbType.Int).Value = idPresupuesto;

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

        public PresupuestoDetE ObtenerPresupuestoDet(Int32 idEmpresa, Int32 idPresupuesto, Int32 idPresupuestoItem)
        {
            PresupuestoDetE Presupuesto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPresupuestoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPresupuesto", SqlDbType.Int).Value = idPresupuesto;
                    oComando.Parameters.Add("@idPresupuestoItem", SqlDbType.Int).Value = idPresupuestoItem;
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

        public PresupuestoDetE ObtenerPresupuestosDetPorMes(Int32 idEmpresa,String Anio, String Mes)
        {
            PresupuestoDetE Presupuesto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPresupuestosDetPorMes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
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
