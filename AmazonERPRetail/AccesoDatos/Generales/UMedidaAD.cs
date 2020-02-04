using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class UMedidaAD : DbConection
    {
        
        public UMedidaE LlenarEntidad(IDataReader oReader)
        {
            UMedidaE umedida = new UMedidaE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.idUMedida = oReader["idUMedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.NomUMedida = oReader["NomUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomUMedidaCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.NomUMedidaCorto = oReader["NomUMedidaCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomUMedidaCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantConversion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.CantConversion = oReader["CantConversion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantConversion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.codSunat = oReader["codSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UnidadMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                umedida.UnidadMedida = oReader["UnidadMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UnidadMedida"]);


            return umedida;
        }

        public UMedidaE InsertarUMedida(UMedidaE umedida)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUMedida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@NomUMedida", SqlDbType.VarChar, 100).Value = umedida.NomUMedida;
                    oComando.Parameters.Add("@NomUMedidaCorto", SqlDbType.VarChar, 10).Value = umedida.NomUMedidaCorto;
                    oComando.Parameters.Add("@CantConversion", SqlDbType.Decimal).Value = umedida.CantConversion;
                    oComando.Parameters.Add("@Contenido", SqlDbType.Decimal).Value = umedida.Contenido;
                    oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 2).Value = umedida.codSunat;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = umedida.UsuarioRegistro;

                    oConexion.Open();
                    umedida.idUMedida = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return umedida;
        }

        public UMedidaE ActualizarUMedida(UMedidaE umedida)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUMedida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUMedida", SqlDbType.Int).Value = umedida.idUMedida;
                    oComando.Parameters.Add("@NomUMedida", SqlDbType.VarChar, 100).Value = umedida.NomUMedida;
                    oComando.Parameters.Add("@NomUMedidaCorto", SqlDbType.VarChar, 10).Value = umedida.NomUMedidaCorto;
                    oComando.Parameters.Add("@CantConversion", SqlDbType.Decimal).Value = umedida.CantConversion;
                    oComando.Parameters.Add("@Contenido", SqlDbType.Decimal).Value = umedida.Contenido;
                    oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 2).Value = umedida.codSunat;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = umedida.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return umedida;
        }

        public Int32 EliminarUMedida(Int32 idUMedida)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUMedida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUMedida", SqlDbType.Int).Value = idUMedida;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UMedidaE> ListarUMedida(string NomUMedida)
        {
            List<UMedidaE> listaEntidad = new List<UMedidaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUMedida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@NomUMedida", SqlDbType.VarChar, 100).Value = NomUMedida;
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

        public UMedidaE ObtenerUMedida(Int32 idUMedida)
        {
            UMedidaE umedida = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUMedida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUMedida", SqlDbType.Int).Value = idUMedida;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            umedida = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return umedida;
        }

    }
}