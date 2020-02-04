using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class RetencionItemAD : DbConection
    {
        
        public RetencionItemE LlenarEntidad(IDataReader oReader)
        {
            RetencionItemE RetencionItem = new RetencionItemE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serieCompRete'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.serieCompRete = oReader["serieCompRete"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serieCompRete"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numeroCompRete'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.numeroCompRete = oReader["numeroCompRete"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numeroCompRete"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.Item = oReader["Item"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porcRetencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.porcRetencion = oReader["porcRetencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porcRetencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.MontoOrigen = oReader["MontoOrigen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRetenidoOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.MontoRetenidoOrigen = oReader["MontoRetenidoOrigen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRetenidoOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.MontoSoles = oReader["MontoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRetenidoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.MontoRetenidoSoles = oReader["MontoRetenidoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRetenidoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                RetencionItem.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            return RetencionItem;
        }

        public RetencionItemE InsertarRetencionItem(RetencionItemE RetencionItem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarConRetencionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = RetencionItem.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = RetencionItem.idLocal;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = RetencionItem.serieCompRete;
                    oComando.Parameters.Add("@numeroCompRete", SqlDbType.VarChar, 8).Value = RetencionItem.numeroCompRete;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = RetencionItem.Item;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = RetencionItem.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = RetencionItem.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = RetencionItem.numDocumento;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = RetencionItem.fecDocumento;
                    oComando.Parameters.Add("@porcRetencion", SqlDbType.Decimal).Value = RetencionItem.porcRetencion;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = RetencionItem.idMoneda;
                    oComando.Parameters.Add("@MontoOrigen", SqlDbType.Decimal).Value = RetencionItem.MontoOrigen;
                    oComando.Parameters.Add("@MontoRetenidoOrigen", SqlDbType.Decimal).Value = RetencionItem.MontoRetenidoOrigen;
                    oComando.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = RetencionItem.MontoSoles;
                    oComando.Parameters.Add("@MontoRetenidoSoles", SqlDbType.Decimal).Value = RetencionItem.MontoRetenidoSoles;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = RetencionItem.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = RetencionItem.codCuenta;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = RetencionItem.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return RetencionItem;
        }

        public RetencionItemE ActualizarRetencionItem(RetencionItemE RetencionItem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConRetencionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = RetencionItem.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = RetencionItem.idLocal;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = RetencionItem.serieCompRete;
                    oComando.Parameters.Add("@numeroCompRete", SqlDbType.VarChar, 8).Value = RetencionItem.numeroCompRete;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = RetencionItem.Item;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = RetencionItem.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = RetencionItem.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = RetencionItem.numDocumento;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = RetencionItem.fecDocumento;
                    oComando.Parameters.Add("@porcRetencion", SqlDbType.Decimal).Value = RetencionItem.porcRetencion;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = RetencionItem.idMoneda;
                    oComando.Parameters.Add("@MontoOrigen", SqlDbType.Decimal).Value = RetencionItem.MontoOrigen;
                    oComando.Parameters.Add("@MontoRetenidoOrigen", SqlDbType.Decimal).Value = RetencionItem.MontoRetenidoOrigen;
                    oComando.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = RetencionItem.MontoSoles;
                    oComando.Parameters.Add("@MontoRetenidoSoles", SqlDbType.Decimal).Value = RetencionItem.MontoRetenidoSoles;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = RetencionItem.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = RetencionItem.codCuenta;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = RetencionItem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return RetencionItem;
        }

        public int EliminarRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete, String Item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConRetencionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = serieCompRete;
                    oComando.Parameters.Add("@numeroCompRete", SqlDbType.VarChar, 8).Value = numeroCompRete;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RetencionItemE> ListarRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete)
        {
            List<RetencionItemE> listaEntidad = new List<RetencionItemE>();
            RetencionItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConRetencionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = serieCompRete;
                    oComando.Parameters.Add("@numeroCompRete", SqlDbType.VarChar, 8).Value = numeroCompRete;

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

        public RetencionItemE ObtenerRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete, String Item)
        {
            RetencionItemE RetencionItem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConRetencionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = serieCompRete;
                    oComando.Parameters.Add("@numeroCompRete", SqlDbType.VarChar, 8).Value = numeroCompRete;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = Item;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            RetencionItem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return RetencionItem;
        }

    }
}
