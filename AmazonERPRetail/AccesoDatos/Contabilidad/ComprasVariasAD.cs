using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ComprasVariasAD : DbConection
    {
        
        public ComprasVariasE LlenarEntidad(IDataReader oReader)
        {
            ComprasVariasE compras = new ComprasVariasE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.idComprobante = oReader["idComprobante"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.idProveedor = oReader["idProveedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.tipDocumento = oReader["tipDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='montAfecto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.montAfecto = oReader["montAfecto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["montAfecto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='montInafecto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.montInafecto = oReader["montInafecto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["montInafecto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='montIGV'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.montIGV = oReader["montIGV"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["montIGV"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='montTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.montTotal = oReader["montTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["montTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.numRegistro = oReader["numRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagGravado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.flagGravado = oReader["flagGravado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["flagGravado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.fecRef = oReader["fecRef"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.tipDocRef = oReader["tipDocRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.serDocRef = oReader["serDocRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.numDocRef = oReader["numDocRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indRectificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.indRectificacion = oReader["indRectificacion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indRectificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecRectificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.fecRectificacion = oReader["fecRectificacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecRectificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impAfectoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.impAfectoRef = oReader["impAfectoRef"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impAfectoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impIGVRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.impIGVRef = oReader["impIGVRef"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impIGVRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.NomDocumento = oReader["NomDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.DesPersona = oReader["DesPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPersona"]);

            return compras;
        }

        public ComprasVariasE InsertarComprasVarias(ComprasVariasE compras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarComprasVarias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = compras.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = compras.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = compras.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = compras.MesPeriodo;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = compras.idProveedor;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = compras.idMoneda;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = compras.fecOperacion;
                    oComando.Parameters.Add("@tipDocumento", SqlDbType.VarChar, 2).Value = compras.tipDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = compras.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = compras.numDocumento;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = compras.tipCambio;
                    oComando.Parameters.Add("@montAfecto", SqlDbType.Decimal).Value = compras.montAfecto;
                    oComando.Parameters.Add("@montInafecto", SqlDbType.Decimal).Value = compras.montInafecto;
                    oComando.Parameters.Add("@montIGV", SqlDbType.Decimal).Value = compras.montIGV;
                    oComando.Parameters.Add("@montTotal", SqlDbType.Decimal).Value = compras.montTotal;
                    oComando.Parameters.Add("@numRegistro", SqlDbType.VarChar, 20).Value = compras.numRegistro;
                    oComando.Parameters.Add("@flagGravado", SqlDbType.Char, 1).Value = compras.flagGravado;
                    oComando.Parameters.Add("@fecRef", SqlDbType.SmallDateTime).Value = compras.fecRef;
                    oComando.Parameters.Add("@tipDocRef", SqlDbType.VarChar, 2).Value = compras.tipDocRef;
                    oComando.Parameters.Add("@serDocRef", SqlDbType.VarChar, 20).Value = compras.serDocRef;
                    oComando.Parameters.Add("@numDocRef", SqlDbType.VarChar, 20).Value = compras.numDocRef;
                    oComando.Parameters.Add("@indRectificacion", SqlDbType.Bit).Value = compras.indRectificacion;
                    oComando.Parameters.Add("@fecRectificacion", SqlDbType.SmallDateTime).Value = compras.fecRectificacion;
                    oComando.Parameters.Add("@impAfectoRef", SqlDbType.Decimal).Value = compras.impAfectoRef;
                    oComando.Parameters.Add("@impIGVRef", SqlDbType.Decimal).Value = compras.impIGVRef;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = compras.UsuarioRegistro;

                    oConexion.Open();
                    compras.idComprobante = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return compras;
        }

        public ComprasVariasE ActualizarComprasVarias(ComprasVariasE compras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarComprasVarias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = compras.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = compras.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = compras.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = compras.MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Int).Value = compras.idComprobante;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = compras.idProveedor;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = compras.idMoneda;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = compras.fecOperacion;
                    oComando.Parameters.Add("@tipDocumento", SqlDbType.VarChar, 2).Value = compras.tipDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = compras.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = compras.numDocumento;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = compras.tipCambio;
                    oComando.Parameters.Add("@montAfecto", SqlDbType.Decimal).Value = compras.montAfecto;
                    oComando.Parameters.Add("@montInafecto", SqlDbType.Decimal).Value = compras.montInafecto;
                    oComando.Parameters.Add("@montIGV", SqlDbType.Decimal).Value = compras.montIGV;
                    oComando.Parameters.Add("@montTotal", SqlDbType.Decimal).Value = compras.montTotal;
                    oComando.Parameters.Add("@numRegistro", SqlDbType.VarChar, 20).Value = compras.numRegistro;
                    oComando.Parameters.Add("@flagGravado", SqlDbType.Char, 1).Value = compras.flagGravado;
                    oComando.Parameters.Add("@fecRef", SqlDbType.DateTime).Value = compras.fecRef;
                    oComando.Parameters.Add("@tipDocRef", SqlDbType.VarChar, 2).Value = compras.tipDocRef;
                    oComando.Parameters.Add("@serDocRef", SqlDbType.VarChar, 20).Value = compras.serDocRef;
                    oComando.Parameters.Add("@numDocRef", SqlDbType.VarChar, 20).Value = compras.numDocRef;
                    oComando.Parameters.Add("@indRectificacion", SqlDbType.Bit).Value = compras.indRectificacion;
                    oComando.Parameters.Add("@fecRectificacion", SqlDbType.SmallDateTime).Value = compras.fecRectificacion;
                    oComando.Parameters.Add("@impAfectoRef", SqlDbType.Decimal).Value = compras.impAfectoRef;
                    oComando.Parameters.Add("@impIGVRef", SqlDbType.Decimal).Value = compras.impIGVRef;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = compras.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return compras;
        }

        public List<ComprasVariasE> ListarComprasVarias(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo)
        {
            List<ComprasVariasE> listaEntidad = new List<ComprasVariasE>();
            ComprasVariasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComprasVarias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;

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

        public ComprasVariasE ObtenerComprasVariasPorId(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, Int32 idComprobante)
        {
            ComprasVariasE compras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerComprasVariasPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Int).Value = idComprobante;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            compras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return compras;
        }

        public int EliminarComprasVarias(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, Int32 idComprobante)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarComprasVarias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Int).Value = idComprobante;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ComprasVariasE> ListarReporteComprasVariasPorGrabacion(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String flagGravado)
        {
            List<ComprasVariasE> listaEntidad = new List<ComprasVariasE>();
            ComprasVariasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteComprasVariasPorGrabacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@flagGravado", SqlDbType.Char, 1).Value = flagGravado;
                    
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

        public ComprasVariasE RevisarDocComprasVarias(Int32 idEmpresa, Int32 idLocal, String tipDocumento, String serDocumento, String numDocumento, Int32 idProveedor)
        {
            ComprasVariasE eCompras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RevisarDocComprasVarias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipDocumento", SqlDbType.VarChar, 2).Value = tipDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            eCompras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return eCompras;
        }

    }
}
