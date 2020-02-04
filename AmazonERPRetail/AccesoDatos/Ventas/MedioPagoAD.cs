using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class MedioPagoAD : DbConection
    {

        public MedioPagoE LlenarEntidad(IDataReader oReader)
        {
            MedioPagoE pago = new MedioPagoE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMedioPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.idMedioPago = oReader["idMedioPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMedioPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Codigo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.Codigo = oReader["Codigo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Codigo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.indAuxiliar = oReader["indAuxiliar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.idAuxiliar = oReader["idAuxiliar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPtoVta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.indPtoVta = oReader["indPtoVta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPtoVta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCredito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.indCredito = oReader["indCredito"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCredito"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.indBaja = oReader["indBaja"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.FechaBaja = oReader["FechaBaja"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMedSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                pago.idMedSunat = oReader["idMedSunat"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMedSunat"]);

            return pago;
        }

        public MedioPagoE InsertarMedioPago(MedioPagoE pago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMedioPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pago.idEmpresa;
                    oComando.Parameters.Add("@Codigo", SqlDbType.VarChar, 2).Value = pago.Codigo;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = pago.Nombre;
                    oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = pago.indDebeHaber;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = pago.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = pago.codCuenta;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = pago.idMoneda;
                    oComando.Parameters.Add("@indAuxiliar", SqlDbType.Bit).Value = pago.indAuxiliar;
                    oComando.Parameters.Add("@idAuxiliar", SqlDbType.Int).Value = pago.idAuxiliar;
                    oComando.Parameters.Add("@idMedSunat", SqlDbType.Int).Value = pago.idMedSunat;
                    oComando.Parameters.Add("@indPtoVta", SqlDbType.Bit).Value = pago.indPtoVta;
                    oComando.Parameters.Add("@indCredito", SqlDbType.Bit).Value = pago.indCredito;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = pago.UsuarioRegistro;

                    oConexion.Open();
                    pago.idMedioPago = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return pago;
        }

        public MedioPagoE ActualizarMedioPago(MedioPagoE pago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMedioPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMedioPago", SqlDbType.Int).Value = pago.idMedioPago;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = pago.idEmpresa;
                    oComando.Parameters.Add("@Codigo", SqlDbType.VarChar, 2).Value = pago.Codigo;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = pago.Nombre;
                    oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = pago.indDebeHaber;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = pago.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = pago.codCuenta;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = pago.idMoneda;
                    oComando.Parameters.Add("@indAuxiliar", SqlDbType.Bit).Value = pago.indAuxiliar;
                    oComando.Parameters.Add("@idAuxiliar", SqlDbType.Int).Value = pago.idAuxiliar;
                    oComando.Parameters.Add("@idMedSunat", SqlDbType.Int).Value = pago.idMedSunat;
                    oComando.Parameters.Add("@indPtoVta", SqlDbType.Bit).Value = pago.indPtoVta;
                    oComando.Parameters.Add("@indCredito", SqlDbType.Bit).Value = pago.indCredito;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = pago.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return pago;
        }

        public Int32 EliminarMedioPago(Int32 idMedioPago, Int32 idEmpresa)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMedioPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMedioPago", SqlDbType.Int).Value = idMedioPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MedioPagoE> ListarMedioPago(Int32 idEmpresa)
        {
            List<MedioPagoE> listaEntidad = new List<MedioPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMedioPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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

        public MedioPagoE ObtenerMedioPago(Int32 idMedioPago, Int32 idEmpresa)
        {
            MedioPagoE campana = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMedioPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMedioPago", SqlDbType.Int).Value = idMedioPago;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            campana = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return campana;
        }

        public MedioPagoE ObtenerMedioPagoPorCodigo(Int32 idEmpresa, String Codigo)
        {
            MedioPagoE Entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMedioPagoPorCodigo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Codigo", SqlDbType.VarChar, 2).Value = Codigo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Entidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return Entidad;
        }

        public Int32 AnularMedioPago(Int32 idMedioPago)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularMedioPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMedioPago", SqlDbType.Int).Value = idMedioPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MedioPagoE> ListarMedioPagoPtoVta(Int32 idEmpresa)
        {
            List<MedioPagoE> listaEntidad = new List<MedioPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMedioPagoPtoVta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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

    }
}
