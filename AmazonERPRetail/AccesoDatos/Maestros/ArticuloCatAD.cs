using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ArticuloCatAD : DbConection
    {

        public ArticuloCatE LlenarEntidad(IDataReader oReader)
        {
            ArticuloCatE articulocat = new ArticuloCatE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.CodCategoria = oReader["CodCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombre_categoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.nombre_categoria = oReader["nombre_categoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombre_categoria"]);
          
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.numNivel = oReader["numNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indUltimoNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.indUltimoNivel = oReader["indUltimoNivel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indUltimoNivel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodCategoriaSup'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.CodCategoriaSup = oReader["CodCategoriaSup"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodCategoriaSup"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.indCuenta = oReader["indCuenta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaAdm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCuentaAdm = oReader["codCuentaAdm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaAdm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaVta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCuentaVta = oReader["codCuentaVta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaVta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCuentaPro = oReader["codCuentaPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaConsumo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCuentaConsumo = oReader["codCuentaConsumo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaConsumo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCuentaVenta = oReader["codCuentaVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaVenta12'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCuentaVenta12 = oReader["codCuentaVenta12"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaVenta12"]);            

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCuentaCompra = oReader["codCuentaCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaPorRecibir'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCuentaPorRecibir = oReader["codCuentaPorRecibir"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaPorRecibir"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.fechaRegistro = oReader["fechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.fechaModificacion = oReader["fechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticuloAsoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.idTipoArticuloAsoc = oReader["idTipoArticuloAsoc"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticuloAsoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCategoriaAsoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.codCategoriaAsoc = oReader["codCategoriaAsoc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCategoriaAsoc"]);

            //Extenciones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCuenta2 = oReader["desCuenta2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCuenta3 = oReader["desCuenta3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta4'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCuenta4 = oReader["desCuenta4"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta4"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta5'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCuenta5 = oReader["desCuenta5"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta5"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta6'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCuenta6 = oReader["desCuenta6"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta6"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta7'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCuenta7 = oReader["desCuenta7"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta7"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.TipoAlmacen = oReader["TipoAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta12'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCuenta12 = oReader["desCuenta12"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta12"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCategoria1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCategoria1 = oReader["desCategoria1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCategoria1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCategoria2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulocat.desCategoria2 = oReader["desCategoria2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCategoria2"]);






            return articulocat;
        }

        public ArticuloCatE InsertarArticuloCat(ArticuloCatE articulocat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloCat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articulocat.idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = articulocat.idTipoArticulo;
                    oComando.Parameters.Add("@CodCategoria", SqlDbType.VarChar, 20).Value = articulocat.CodCategoria;
                    oComando.Parameters.Add("@nombre_categoria", SqlDbType.VarChar, 100).Value = articulocat.nombre_categoria;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = articulocat.numNivel;
                    oComando.Parameters.Add("@indUltimoNivel", SqlDbType.Char, 1).Value = articulocat.indUltimoNivel;
                    oComando.Parameters.Add("@CodCategoriaSup", SqlDbType.VarChar, 20).Value = articulocat.CodCategoriaSup;
                    oComando.Parameters.Add("@indCuenta", SqlDbType.Bit).Value = articulocat.indCuenta;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = articulocat.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuentaAdm", SqlDbType.VarChar, 20).Value = articulocat.codCuentaAdm;
                    oComando.Parameters.Add("@codCuentaVta", SqlDbType.VarChar, 20).Value = articulocat.codCuentaVta;
                    oComando.Parameters.Add("@codCuentaPro", SqlDbType.VarChar, 20).Value = articulocat.codCuentaPro;
                    oComando.Parameters.Add("@codCuentaConsumo", SqlDbType.VarChar, 20).Value = articulocat.codCuentaConsumo;
                    oComando.Parameters.Add("@codCuentaVenta", SqlDbType.VarChar, 20).Value = articulocat.codCuentaVenta;
                    oComando.Parameters.Add("@codCuentaVenta12", SqlDbType.VarChar, 20).Value = articulocat.codCuentaVenta12;
                    oComando.Parameters.Add("@codCuentaCompra", SqlDbType.VarChar, 20).Value = articulocat.codCuentaCompra;
                    oComando.Parameters.Add("@codCuentaPorRecibir", SqlDbType.VarChar, 20).Value = articulocat.codCuentaPorRecibir;
                    oComando.Parameters.Add("@idTipoArticuloAsoc", SqlDbType.Int).Value = articulocat.idTipoArticuloAsoc;
                    oComando.Parameters.Add("@codCategoriaAsoc", SqlDbType.VarChar, 20).Value = articulocat.codCategoriaAsoc;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = articulocat.UsuarioRegistro;
                    
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articulocat;
        }

        public ArticuloCatE ActualizarArticuloCat(ArticuloCatE articulocat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloCat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articulocat.idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = articulocat.idTipoArticulo;
                    oComando.Parameters.Add("@CodCategoria", SqlDbType.VarChar, 20).Value = articulocat.CodCategoria;
                    oComando.Parameters.Add("@CodCategoriaAnte", SqlDbType.VarChar, 20).Value = articulocat.CodCategoriaAnte;
                    oComando.Parameters.Add("@nombre_categoria", SqlDbType.VarChar, 100).Value = articulocat.nombre_categoria;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = articulocat.numNivel;
                    oComando.Parameters.Add("@indUltimoNivel", SqlDbType.Char, 1).Value = articulocat.indUltimoNivel;
                    oComando.Parameters.Add("@CodCategoriaSup", SqlDbType.VarChar, 20).Value = articulocat.CodCategoriaSup;
                    oComando.Parameters.Add("@indCuenta", SqlDbType.Bit).Value = articulocat.indCuenta;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = articulocat.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuentaAdm", SqlDbType.VarChar, 20).Value = articulocat.codCuentaAdm;
                    oComando.Parameters.Add("@codCuentaVta", SqlDbType.VarChar, 20).Value = articulocat.codCuentaVta;
                    oComando.Parameters.Add("@codCuentaPro", SqlDbType.VarChar, 20).Value = articulocat.codCuentaPro;
                    oComando.Parameters.Add("@codCuentaConsumo", SqlDbType.VarChar, 20).Value = articulocat.codCuentaConsumo;
                    oComando.Parameters.Add("@codCuentaVenta", SqlDbType.VarChar, 20).Value = articulocat.codCuentaVenta;
                    oComando.Parameters.Add("@codCuentaVenta12", SqlDbType.VarChar, 20).Value = articulocat.codCuentaVenta12;
                    oComando.Parameters.Add("@codCuentaCompra", SqlDbType.VarChar, 20).Value = articulocat.codCuentaCompra;
                    oComando.Parameters.Add("@codCuentaPorRecibir", SqlDbType.VarChar, 20).Value = articulocat.codCuentaPorRecibir;
                    oComando.Parameters.Add("@idTipoArticuloAsoc", SqlDbType.Int).Value = articulocat.idTipoArticuloAsoc;
                    oComando.Parameters.Add("@codCategoriaAsoc", SqlDbType.VarChar, 20).Value = articulocat.codCategoriaAsoc;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = articulocat.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articulocat;
        }

        public List<ArticuloCatE> ListarCategoriasPorTipoArticulo(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel)
        {
            List<ArticuloCatE> listaArticuloCat = new List<ArticuloCatE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCategoriasPorTipoArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaArticuloCat.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaArticuloCat;
        }

        public List<ArticuloCatE> ListarCategPorTipoArtiCategSup(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel, string CodCategoriaSup)
        {
            List<ArticuloCatE> listaArticuloCat = new List<ArticuloCatE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCategPorTipoArtiCategSup", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;
                    oComando.Parameters.Add("@CodCategoriaSup", SqlDbType.VarChar, 20).Value = CodCategoriaSup;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaArticuloCat.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaArticuloCat;
        }

        public List<ArticuloCatE> ListarCategoriasPorUltNivel(Int32 idEmpresa, Int32 idTipoArticulo)
        {
            List<ArticuloCatE> listaArticuloCat = new List<ArticuloCatE>();
            ArticuloCatE ArticuloCat = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCategoriasPorUltNivel", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ArticuloCat = LlenarEntidad(oReader);
                            listaArticuloCat.Add(ArticuloCat);
                        }
                    }
                }
            }

            return listaArticuloCat;
        }

        public Int32 EliminarArticuloCat(Int32 idEmpresa, Int32 idTipoArticulo, String CodCategoria)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarArticuloCat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@CodCategoria", SqlDbType.VarChar).Value = CodCategoria;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ArticuloCatE> ListarArticuloCatArbol(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel, string filtro)
        {
            List<ArticuloCatE> listaEntidad = new List<ArticuloCatE>();
            ArticuloCatE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloCatArbol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;
                    oComando.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
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



        ///NEW PROCEDURE///

        public List<ArticuloCatE> ListarArticuloCategoria(Int32 idEmpresa, Int32 idTipoArticulo, Int32 numNivel, string filtro)
        {
            List<ArticuloCatE> listaEntidad = new List<ArticuloCatE>();
            ArticuloCatE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloCategoria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = idTipoArticulo;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;
                    oComando.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
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

    }
}
