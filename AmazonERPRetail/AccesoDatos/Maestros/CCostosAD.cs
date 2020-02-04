using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CCostosAD : DbConection
    {

        public CCostosE LlenarEntidad(IDataReader oReader)
        {
            CCostosE ccostos = new CCostosE();
            ccostos.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);
            ccostos.idCCostos = Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostosSup'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.idCCostosSup = oReader["idCCostosSup"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostosSup"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.numNivel = oReader["numNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.indBaja = oReader["indBaja"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.fecBaja = oReader["fecBaja"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.idSistema = oReader["idSistema"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoCCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.tipoCCosto = oReader["tipoCCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipoCCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModifica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.FechaModifica = oReader["FechaModifica"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModifica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AbrevCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.AbrevCCostos = oReader["AbrevCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AbrevCCostos"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.desTemporal = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]) + "-" + Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesTipoCCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ccostos.DesTipoCCosto = oReader["DesTipoCCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesTipoCCosto"]);



            return ccostos;
        }

        public CCostosE InsertarCCostos(CCostosE ccostos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ccostos.idEmpresa;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = ccostos.idCCostos;
                    oComando.Parameters.Add("@idCCostosSup", SqlDbType.VarChar, 10).Value = ccostos.idCCostosSup;
                    oComando.Parameters.Add("@desCCostos", SqlDbType.VarChar, 100).Value = ccostos.desCCostos;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = ccostos.numNivel;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = ccostos.indBaja;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Char,1).Value = ccostos.idSistema;
                    oComando.Parameters.Add("@tipoCCosto", SqlDbType.VarChar,1).Value = ccostos.tipoCCosto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ccostos.UsuarioRegistro;
                    oComando.Parameters.Add("@AbrevCCostos", SqlDbType.VarChar, 20).Value = ccostos.AbrevCCostos;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ccostos;
        }

        public CCostosE ActualizarCCostos(CCostosE ccostos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ccostos.idEmpresa;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = ccostos.idCCostos;
                    oComando.Parameters.Add("@idCCostosSup", SqlDbType.VarChar, 10).Value = ccostos.idCCostosSup;
                    oComando.Parameters.Add("@desCCostos", SqlDbType.VarChar, 100).Value = ccostos.desCCostos;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = ccostos.numNivel;
                    oComando.Parameters.Add("@tipoCCosto", SqlDbType.VarChar,1).Value = ccostos.tipoCCosto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ccostos.UsuarioModificacion;
                    oComando.Parameters.Add("@AbrevCCostos", SqlDbType.VarChar, 20).Value = ccostos.AbrevCCostos;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ccostos;
        }

        public List<CCostosE> ListarCCostosPorNivel(Int32 idEmpresa, Int32? numNivel)
        {
            List<CCostosE> ccostos = new List<CCostosE>();
            CCostosE CC;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCCostosPorNivel", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            CC = new CCostosE();
                            CC.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);
                            CC.idCCostos = Convert.ToString(oReader["idCCostos"]);
                            CC.tipoCCosto = Convert.ToString(oReader["tipoCCosto"]);
                            CC.desCCostos = Convert.ToString(oReader["desCCostos"]);
                            ccostos.Add(CC);
                        }
                    }
                }
            }

            return ccostos;
        }

        public List<CCostosE> ListarCCostosPorSistema(Int32 idEmpresa, Int32 idSistema)
        {
            List<CCostosE> listaCCostos = new List<CCostosE>();
            CCostosE CCostos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCCostosPorSistema", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            CCostos = LlenarEntidad(oReader);
                            listaCCostos.Add(CCostos);
                        }
                    }
                }
            }

            return listaCCostos;
        }

        public Int32 AnularCCostos(Int32 idEmpresa, String idCCostos)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = idCCostos;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public CCostosE ObtenerCCostos(Int32 idEmpresa, String idCCostos)
        {
            CCostosE ccostos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = idCCostos;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ccostos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ccostos;
        }

        public List<CCostosE> ObtenerDetallePorCenttroDeCosto(Int32 idEmpresa, Int32 idLocal, Int32 anioPeriodo, DateTime fecIni, DateTime fecFin, String codCuentaIni, String codCuentaFin)
        {
            List<CCostosE> ccostos = new List<CCostosE>();
            CCostosE CC;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteDetallePorCentroDeCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.Int).Value = anioPeriodo;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@codCuentaIni", SqlDbType.VarChar,20).Value = codCuentaIni;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar,20).Value = codCuentaFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            CC = LlenarEntidad(oReader);
                            ccostos.Add(CC);
                        }
                    }
                }
            }

            return ccostos;
        }

        public String ObtenerIdCosto(Int32 idEmpresa, String desCCostos)
        {
            CCostosE ccostos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerIdCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@desCCostos", SqlDbType.VarChar, 100).Value = desCCostos;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ccostos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ccostos.idCCostos;
        }

        public Int32 MaxNivelCCostos(Int32 idEmpresa)
        {
            Int32 Nivel = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxNivelCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    Nivel = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return Nivel;
        }

        public List<CCostosE> ListarCCostosPorTipoCCosto(Int32 idEmpresa, Int32 idSistema, Int32 tipoCCosto)
        {
            List<CCostosE> listaCCostos = new List<CCostosE>();
            CCostosE CCostos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCCostosPorTipoCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;
                    oComando.Parameters.Add("@tipoCCosto", SqlDbType.Int).Value = tipoCCosto;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            CCostos = LlenarEntidad(oReader);
                            listaCCostos.Add(CCostos);
                        }
                    }
                }
            }

            return listaCCostos;
        }

    }
}