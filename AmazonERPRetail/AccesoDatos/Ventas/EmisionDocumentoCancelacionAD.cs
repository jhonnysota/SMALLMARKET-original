using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class EmisionDocumentoCancelacionAD : DbConection
    {

        public EmisionDocumentoCancelacionE LlenarEntidad(IDataReader oReader)
        {
            EmisionDocumentoCancelacionE emisiondocumentocancelacion = new EmisionDocumentoCancelacionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.Fecha = oReader["Fecha"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMedioPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.idMedioPago = oReader["idMedioPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMedioPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoReci'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.idDocumentoReci = oReader["idDocumentoReci"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoReci"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieReci'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.numSerieReci = oReader["numSerieReci"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieReci"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoReci'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.numDocumentoReci = oReader["numDocumentoReci"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoReci"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaRecibida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.idMonedaRecibida = oReader["idMonedaRecibida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaRecibida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRecibido'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.MontoRecibido = oReader["MontoRecibido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRecibido"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaDocum'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.idMonedaDocum = oReader["idMonedaDocum"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaDocum"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoAplicar'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.MontoAplicar = oReader["MontoAplicar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoAplicar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Vuelto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.Vuelto = oReader["Vuelto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Vuelto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuentaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.numCuentaBanco = oReader["numCuentaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuentaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecAbono'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.fecAbono = oReader["fecAbono"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["fecAbono"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanilla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.idPlanilla = oReader["idPlanilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlanilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VariosCobros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.VariosCobros = oReader["VariosCobros"] == DBNull.Value ? false : Convert.ToBoolean(oReader["VariosCobros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentocancelacion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMedioPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.desMedioPago = oReader["desMedioPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMedioPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMonedaDocu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.desMonedaDocu = oReader["desMonedaDocu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMonedaDocu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMonedaRec'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.desMonedaRec = oReader["desMonedaRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMonedaRec"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlanilla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.codPlanilla = oReader["codPlanilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPlanilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.TotalDoc = oReader["TotalDoc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IndTarjCredito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentocancelacion.IndTarjCredito = oReader["IndTarjCredito"] == DBNull.Value ? false : Convert.ToBoolean(oReader["IndTarjCredito"]);

            return  emisiondocumentocancelacion;        
        }

        public EmisionDocumentoCancelacionE InsertarEmisionDocumentoCancelacion(EmisionDocumentoCancelacionE emisiondocumentocancelacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmisionDocumentoCancelacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentocancelacion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentocancelacion.idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numDocumento;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = emisiondocumentocancelacion.Item;
					oComando.Parameters.Add("@Fecha", SqlDbType.VarChar, 8).Value = emisiondocumentocancelacion.Fecha;
					oComando.Parameters.Add("@idMedioPago", SqlDbType.Int).Value = emisiondocumentocancelacion.idMedioPago;
					oComando.Parameters.Add("@idDocumentoReci", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idDocumentoReci;
					oComando.Parameters.Add("@numSerieReci", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numSerieReci;
					oComando.Parameters.Add("@numDocumentoReci", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numDocumentoReci;
					oComando.Parameters.Add("@idMonedaRecibida", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idMonedaRecibida;
					oComando.Parameters.Add("@MontoRecibido", SqlDbType.Decimal).Value = emisiondocumentocancelacion.MontoRecibido;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = emisiondocumentocancelacion.tipCambio;
					oComando.Parameters.Add("@idMonedaDocum", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idMonedaDocum;
					oComando.Parameters.Add("@MontoAplicar", SqlDbType.Decimal).Value = emisiondocumentocancelacion.MontoAplicar;
                    oComando.Parameters.Add("@Vuelto", SqlDbType.Decimal).Value = emisiondocumentocancelacion.Vuelto;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = emisiondocumentocancelacion.idBanco;
                    oComando.Parameters.Add("@numCuentaBanco", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numCuentaBanco;
                    oComando.Parameters.Add("@fecAbono", SqlDbType.VarChar, 8).Value = String.IsNullOrWhiteSpace(emisiondocumentocancelacion.fecAbono) == true ? null : emisiondocumentocancelacion.fecAbono;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentocancelacion;
        }
        
        public EmisionDocumentoCancelacionE ActualizarEmisionDocumentoCancelacion(EmisionDocumentoCancelacionE emisiondocumentocancelacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisionDocumentoCancelacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentocancelacion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentocancelacion.idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numDocumento;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = emisiondocumentocancelacion.Item;
					oComando.Parameters.Add("@Fecha", SqlDbType.VarChar, 8).Value = emisiondocumentocancelacion.Fecha;
					oComando.Parameters.Add("@idMedioPago", SqlDbType.Int).Value = emisiondocumentocancelacion.idMedioPago;
					oComando.Parameters.Add("@idDocumentoReci", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idDocumentoReci;
					oComando.Parameters.Add("@numSerieReci", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numSerieReci;
					oComando.Parameters.Add("@numDOcumentoReci", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numDocumentoReci;
					oComando.Parameters.Add("@idMonedaRecibida", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idMonedaRecibida;
					oComando.Parameters.Add("@MontoRecibido", SqlDbType.Decimal).Value = emisiondocumentocancelacion.MontoRecibido;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = emisiondocumentocancelacion.tipCambio;
					oComando.Parameters.Add("@idMonedaDocum", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idMonedaDocum;
					oComando.Parameters.Add("@MontoAplicar", SqlDbType.Decimal).Value = emisiondocumentocancelacion.MontoAplicar;
                    oComando.Parameters.Add("@Vuelto", SqlDbType.Decimal).Value = emisiondocumentocancelacion.Vuelto;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = emisiondocumentocancelacion.idBanco;
                    oComando.Parameters.Add("@numCuentaBanco", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numCuentaBanco;
                    oComando.Parameters.Add("@fecAbono", SqlDbType.VarChar, 8).Value = string.IsNullOrWhiteSpace(emisiondocumentocancelacion.fecAbono) == true ? null : emisiondocumentocancelacion.fecAbono;
                    //oComando.Parameters.Add("@VariosCobros", SqlDbType.Bit).Value = emisiondocumentocancelacion.VariosCobros;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentocancelacion;
        }        

        public Int32 EliminarEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEmisionDocumentoCancelacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EmisionDocumentoCancelacionE> ListarEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumentoReci, String numSerieReci, String numDocumentoReci, string fecIni, string fecFin)
        {
            List<EmisionDocumentoCancelacionE> listaEntidad = new List<EmisionDocumentoCancelacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmisionDocumentoCancelacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumentoReci", SqlDbType.VarChar, 2).Value = idDocumentoReci;
                    oComando.Parameters.Add("@numSerieReci", SqlDbType.VarChar, 20).Value = numSerieReci;
                    oComando.Parameters.Add("@numDocumentoReci", SqlDbType.VarChar, 20).Value = numDocumentoReci;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = string.IsNullOrWhiteSpace(fecIni) != true ? fecIni : null;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = string.IsNullOrWhiteSpace(fecFin) != true ? fecFin : null;

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
        
        public List<EmisionDocumentoCancelacionE> ObtenerEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            List<EmisionDocumentoCancelacionE> listaEntidad = new List<EmisionDocumentoCancelacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmisionDocumentoCancelacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

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

        public EmisionDocumentoCancelacionE ObtenerDiarioFileCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            EmisionDocumentoCancelacionE Entidad = new EmisionDocumentoCancelacionE();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerDiarioFileCancelacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

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

        public EmisionDocumentoCancelacionE ActualizarEmisDocuCancelacionPlanilla(EmisionDocumentoCancelacionE emisiondocumentocancelacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisDocuCancelacionPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentocancelacion.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentocancelacion.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentocancelacion.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.numDocumento;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = emisiondocumentocancelacion.Item;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = emisiondocumentocancelacion.idPlanilla;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumentocancelacion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentocancelacion;
        }

        public List<EmisionDocumentoCancelacionE> ReporteConsolidadoCaja(Int32 idEmpresa, Int32 idLocal, string fecha)
        {
            List<EmisionDocumentoCancelacionE> listaEntidad = new List<EmisionDocumentoCancelacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteConsolidadoCaja", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@IdLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Fecha", SqlDbType.VarChar, 8).Value = fecha;

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