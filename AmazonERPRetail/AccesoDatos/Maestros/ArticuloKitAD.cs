using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ArticuloKitAD : DbConection
    {

        public ArticuloKitE LlenarEntidad(IDataReader oReader)
        {
            ArticuloKitE articulokit = new ArticuloKitE();
            			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))				articulokit.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);						oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))				articulokit.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);						oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticuloComponente'";			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))				articulokit.idArticuloComponente = oReader["idArticuloComponente"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticuloComponente"]);						oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))				articulokit.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);						oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))				articulokit.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);						oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))				articulokit.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);						oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))				articulokit.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);						oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))				articulokit.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulokit.CodArticulo = oReader["CodArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulokit.NombreArticulo = oReader["NomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomArticulo"]);

            return  articulokit;        
        }

        public ArticuloKitE InsertarArticuloKit(ArticuloKitE articulokit)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articulokit.idEmpresa;					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = articulokit.idArticulo;					oComando.Parameters.Add("@idArticuloComponente", SqlDbType.Int).Value = articulokit.idArticuloComponente;					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = articulokit.Cantidad;					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = articulokit.UsuarioRegistro;
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articulokit;
        }
        
        public ArticuloKitE ActualizarArticuloKit(ArticuloKitE articulokit)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articulokit.idEmpresa;					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = articulokit.idArticulo;					oComando.Parameters.Add("@idArticuloComponente", SqlDbType.Int).Value = articulokit.idArticuloComponente;					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = articulokit.Cantidad;					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = articulokit.UsuarioModificacion;
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articulokit;
        }        

        public int EliminarArticuloKit(Int32 idEmpresa, Int32 idArticulo, Int32 idArticuloComponente)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;					oComando.Parameters.Add("@idArticuloComponente", SqlDbType.Int).Value = idArticuloComponente;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ArticuloKitE> ListarArticuloKit(Int32 idArticulo)
        {
            List<ArticuloKitE> listaEntidad = new List<ArticuloKitE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

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
        
        public ArticuloKitE ObtenerArticuloKit(Int32 idEmpresa, Int32 idArticulo, Int32 idArticuloComponente)
        {        
            ArticuloKitE articulokit = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;					oComando.Parameters.Add("@idArticuloComponente", SqlDbType.Int).Value = idArticuloComponente;
    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articulokit = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articulokit;
        }

    }
}