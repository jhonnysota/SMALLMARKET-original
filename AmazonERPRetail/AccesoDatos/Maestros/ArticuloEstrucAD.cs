using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ArticuloEstrucAD : DbConection
    {

        public ArticuloEstrucE LlenarEntidad(IDataReader oReader)
        {
            ArticuloEstrucE articuloestruc = new ArticuloEstrucE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.numNivel = oReader["numNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.desNivel = oReader["desNivel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desNivel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLongitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.numLongitud = oReader["numLongitud"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numLongitud"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indUltimoNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.indUltimoNivel = oReader["indUltimoNivel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indUltimoNivel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.fechaRegistro = oReader["fechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloestruc.fechaModificacion = oReader["fechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaModificacion"]);

            return articuloestruc;
        }

        public ArticuloEstrucE InsertarArticuloEstruc(ArticuloEstrucE articuloestruc)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloestruc.idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = articuloestruc.idTipoArticulo;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = articuloestruc.numNivel;
                    oComando.Parameters.Add("@desNivel", SqlDbType.VarChar, 50).Value = articuloestruc.desNivel;
                    oComando.Parameters.Add("@numLongitud", SqlDbType.Int).Value = articuloestruc.numLongitud;
                    oComando.Parameters.Add("@indUltimoNivel", SqlDbType.Char, 1).Value = articuloestruc.indUltimoNivel;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = articuloestruc.UsuarioRegistro;
                    //oComando.Parameters.Add("@fechaRegistro", SqlDbType.SmallDateTime).Value = articuloestruc.fechaRegistro;
                    //oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = articuloestruc.UsuarioModificacion;
                    //oComando.Parameters.Add("@fechaModificacion", SqlDbType.SmallDateTime).Value = articuloestruc.fechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articuloestruc;
        }

        public ArticuloEstrucE ActualizarArticuloEstruc(ArticuloEstrucE articuloestruc)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloestruc.idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = articuloestruc.idTipoArticulo;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = articuloestruc.numNivel;
                    oComando.Parameters.Add("@desNivel", SqlDbType.VarChar, 50).Value = articuloestruc.desNivel;
                    oComando.Parameters.Add("@numLongitud", SqlDbType.Int).Value = articuloestruc.numLongitud;
                    oComando.Parameters.Add("@indUltimoNivel", SqlDbType.Char, 1).Value = articuloestruc.indUltimoNivel;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = articuloestruc.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articuloestruc;
        }

        public Int32 EliminarArticuloEstruc(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarArticuloEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ArticuloEstrucE> ListarArticuloEstruc(Int32 idEmpresa, Int32 idTipoArticulo)
        {
            List<ArticuloEstrucE> listaEntidad = new List<ArticuloEstrucE>();
            ArticuloEstrucE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;

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

        //public ArticuloServE ObtenerArticuloServ(Int32 idEmpresa, Int32 idArticulo)
        //{
        //    ArticuloServE articuloserv = null;

        //    using (SqlConnection oConexion = ConexionSql())
        //    {
        //        using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloServ", oConexion))
        //        {
        //            oComando.CommandType = CommandType.StoredProcedure;

        //            oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
        //            oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
        //            oConexion.Open();

        //            using (SqlDataReader oReader = oComando.ExecuteReader())
        //            {
        //                while (oReader.Read())
        //                {
        //                    articuloserv = LlenarEntidad(oReader);
        //                }
        //            }
        //        }

        //        oConexion.Close();
        //    }

        //    return articuloserv;
        //}
        
    }
}
