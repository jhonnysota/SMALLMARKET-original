using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class MonedasAD : DbConection
    {

        public MonedasE LlenarEntidad(IDataReader oReader)
        {
            MonedasE monedas = new MonedasE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                monedas.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                monedas.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAbreviatura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                monedas.desAbreviatura = oReader["desAbreviatura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAbreviatura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ISO_4217'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                monedas.ISO = oReader["ISO_4217"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ISO_4217"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                monedas.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                monedas.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                monedas.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModifica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                monedas.FechaModifica = oReader["FechaModifica"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModifica"]);

            return  monedas;        
        }

        public MonedasE InsertarMonedas(MonedasE monedas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMonedas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = monedas.idMoneda;
                    oComando.Parameters.Add("@desMoneda", SqlDbType.VarChar, 50).Value = monedas.desMoneda;
                    oComando.Parameters.Add("@desAbreviatura", SqlDbType.VarChar, 6).Value = monedas.desAbreviatura;
                    oComando.Parameters.Add("@ISO_4217", SqlDbType.VarChar, 5).Value = monedas.ISO;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = monedas.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return monedas;        
        }
        
        public MonedasE ActualizarMonedas(MonedasE monedas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMonedas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = monedas.idMoneda;
                    oComando.Parameters.Add("@desMoneda", SqlDbType.VarChar, 50).Value = monedas.desMoneda;
                    oComando.Parameters.Add("@desAbreviatura", SqlDbType.VarChar, 6).Value = monedas.desAbreviatura;
                    oComando.Parameters.Add("@ISO_4217", SqlDbType.VarChar, 5).Value = monedas.ISO;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = monedas.UsuarioModificacion; 

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return monedas;
        }

        public String CorrelativoMoneda()
        {
            String codigo = string.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CorrelativoMonedas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    codigo = oComando.ExecuteScalar().ToString();
                }
                
            }

            return codigo;
        }

        public List<MonedasE> ListarMonedas()
        {
           List<MonedasE> listaEntidad = new List<MonedasE>();
           MonedasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMonedas", oConexion))
                {
                    oComando.CommandType = System.Data.CommandType.StoredProcedure;
                    oConexion.Open();

                    using (SqlDataReader reader = oComando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entidad = LlenarEntidad(reader);
                            listaEntidad.Add(entidad);
                        } 
                    }
                }
            }

            return listaEntidad;
        }
        
    }
}