using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class RetencionAD : DbConection
    {

        public RetencionE LlenarEntidad(IDataReader oReader)
        {
            RetencionE Retencion = new RetencionE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serieCompRete'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.serieCompRete = oReader["serieCompRete"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serieCompRete"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numeroCompRete'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.numeroCompRete = oReader["numeroCompRete"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numeroCompRete"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoBase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.MontoBase = oReader["MontoBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoBase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRetenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.MontoRetenido = oReader["MontoRetenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRetenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.flagVoucher = oReader["flagVoucher"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.NumVoucher = oReader["NumVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);


            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.NomPersona = oReader["NomPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomPersona"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.FecDocumento = oReader["FecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorcRetencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.PorcRetencion = oReader["PorcRetencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorcRetencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.MontoSoles = oReader["MontoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRetenidoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.MontoRetenidoSoles = oReader["MontoRetenidoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRetenidoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.DesPersona = oReader["DesPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.DireccionPersona = oReader["DireccionPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.Correo = oReader["Correo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Linea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.Linea = oReader["Linea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Linea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='td_proveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.td_proveedor = oReader["td_proveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["td_proveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.ruc = oReader["ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='razonsocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.razonsocial = oReader["razonsocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["razonsocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodigoSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.CodigoSunat = oReader["CodigoSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodigoSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.SerDocumento = oReader["SerDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Debe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.Debe = oReader["Debe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Debe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Haber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.Haber = oReader["Haber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Haber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dirLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Retencion.dirLocal = oReader["dirLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["dirLocal"]);

            return Retencion;
        }

        public RetencionE InsertarRetencion(RetencionE Retencion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarConRetencion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = Retencion.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = Retencion.idLocal;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = Retencion.serieCompRete;
                    oComando.Parameters.Add("@numeroCompRete", SqlDbType.VarChar, 8).Value = Retencion.numeroCompRete;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = Retencion.idPersona;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Retencion.Fecha;
                    oComando.Parameters.Add("@MontoBase", SqlDbType.Decimal).Value = Retencion.MontoBase;
                    oComando.Parameters.Add("@MontoRetenido", SqlDbType.Decimal).Value = Retencion.MontoRetenido;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = Retencion.idMoneda;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = Retencion.TipoCambio;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 2).Value = Retencion.Estado;
                    oComando.Parameters.Add("@flagVoucher", SqlDbType.Bit).Value = Retencion.flagVoucher;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = Retencion.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = Retencion.MesPeriodo;
                    oComando.Parameters.Add("@NumVoucher", SqlDbType.VarChar, 9).Value = Retencion.NumVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = Retencion.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = Retencion.numFile;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = Retencion.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return Retencion;
        }

        public RetencionE ActualizarRetencion(RetencionE Retencion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConRetencion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = Retencion.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = Retencion.idLocal;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = Retencion.serieCompRete;
                    oComando.Parameters.Add("@numeroCompRete", SqlDbType.VarChar, 8).Value = Retencion.numeroCompRete;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = Retencion.idPersona;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Retencion.Fecha;
                    oComando.Parameters.Add("@MontoBase", SqlDbType.Decimal).Value = Retencion.MontoBase;
                    oComando.Parameters.Add("@MontoRetenido", SqlDbType.Decimal).Value = Retencion.MontoRetenido;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = Retencion.idMoneda;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = Retencion.TipoCambio;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 2).Value = Retencion.Estado;
                    oComando.Parameters.Add("@flagVoucher", SqlDbType.Bit).Value = Retencion.flagVoucher;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = Retencion.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = Retencion.MesPeriodo;
                    oComando.Parameters.Add("@NumVoucher", SqlDbType.VarChar, 9).Value = Retencion.NumVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = Retencion.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = Retencion.numFile;          
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = Retencion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return Retencion;
        }

        public int EliminarRetencion(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConRetencion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = serieCompRete;
                    oComando.Parameters.Add("@numeroCompRete", SqlDbType.VarChar, 8).Value = numeroCompRete;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RetencionE> ListarRetencion(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin)
        {
            List<RetencionE> listaEntidad = new List<RetencionE>();
            RetencionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConRetencion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;

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

        public List<RetencionE> ListarReporteRetenciones(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete)
        {
            List<RetencionE> listaEntidad = new List<RetencionE>();
            RetencionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteRetenciones", oConexion))
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

        public RetencionE ObtenerRetencion(Int32 idEmpresa, Int32 @idLocal, String @serieCompRete, String @numeroCompRete)
        {
            RetencionE Retencion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConRetencion", oConexion))
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
                            Retencion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return Retencion;
        }

        public List<RetencionE> LibroRetencionLe(Int32 idEmpresa, DateTime fecIni, DateTime fecFin)
        {
            List<RetencionE> listaEntidad = new List<RetencionE>();
            RetencionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LibroDeRetencionLe", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;

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

        public List<RetencionE> LibroRetenciones(Int32 idEmpresa, DateTime fecIni, DateTime fecFin)
        {
            List<RetencionE> listaEntidad = new List<RetencionE>();
            RetencionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteLibroRetenciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;

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

        public Int32 GeneraAsientoRetencion(Int32 idEmpresa, Int32 @idLocal, String @serieCompRete, String @numeroCompRete)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GeneraAsientoRetencion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@serie", SqlDbType.VarChar, 4).Value = serieCompRete;
                    oComando.Parameters.Add("@numero", SqlDbType.VarChar, 8).Value = numeroCompRete;
                    oComando.Parameters.Add("@usuario", SqlDbType.VarChar, 8).Value = "";
                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                 
                }
            }

            return resp;
        }

        public Int32 EliminaAsientoRetencion(Int32 idEmpresa, Int32 @idLocal, String @serieCompRete, String @numeroCompRete)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminaAsientoRetencion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@serie", SqlDbType.VarChar, 4).Value = serieCompRete;
                    oComando.Parameters.Add("@numero", SqlDbType.VarChar, 8).Value = numeroCompRete;
                    oComando.Parameters.Add("@usuario", SqlDbType.VarChar, 8).Value = "";

                    oConexion.Open();

                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public String ObtenerUltimoNroCorrelativoRetencion(Int32 idEmpresa, String serieCompRete)
        {
            String NroCompRete = "0";

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CorrelativoRetencion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@serieCompRete", SqlDbType.VarChar, 4).Value = serieCompRete;

                    oConexion.Open();
                    NroCompRete = oComando.ExecuteScalar().ToString();
                }
            }

            return NroCompRete;
        }

        public Int32 ProcesarMigrarRetencion(String Cod_empresa, String Anno_periodo, String Mes_periodo, Int32 idEmpresa, Int32 idLocal)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MigrarRetencion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Cod_empresa", SqlDbType.VarChar, 4).Value = Cod_empresa;
                    oComando.Parameters.Add("@Anno_periodo", SqlDbType.VarChar, 4).Value = Anno_periodo;
                    oComando.Parameters.Add("@Mes_periodo", SqlDbType.VarChar, 2).Value = Mes_periodo;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal ", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

    }
}
