using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class SolicitudProveedorRendicionAD : DbConection
    {

        public SolicitudProveedorRendicionE LlenarEntidad(IDataReader oReader)
        {
            SolicitudProveedorRendicionE solicitudproveedorrendicion = new SolicitudProveedorRendicionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRendicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.idRendicion = oReader["idRendicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRendicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codRendicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.codRendicion = oReader["codRendicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codRendicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSolicitud'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.idSolicitud = oReader["idSolicitud"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSolicitud"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecOperacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.totSoles = oReader["totSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.totDolares = oReader["totDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoAplicado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.MontoAplicado = oReader["MontoAplicado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoAplicado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Diferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.Diferencia = oReader["Diferencia"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Diferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDeposito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.indDeposito = oReader["indDeposito"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDeposito"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBancoDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idBancoDepo = oReader["idBancoDepo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBancoDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idDocumentoDepo = oReader["idDocumentoDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.numSerieDepo = oReader["numSerieDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.numDocumentoDepo = oReader["numDocumentoDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.fecDepo = oReader["fecDepo"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idMonedaDepo = oReader["idMonedaDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImporteDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.ImporteDepo = oReader["ImporteDepo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImporteDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.AnioDepo = oReader["AnioDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.MesDepo = oReader["MesDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.DiarioDepo = oReader["DiarioDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.FileDepo = oReader["FileDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucherDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.numVoucherDepo = oReader["numVoucherDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucherDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaDepo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.GlosaDepo = oReader["GlosaDepo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaDepo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.Estado = oReader["Estado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idMonedaSol = oReader["idMonedaSol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idProveedor = oReader["idProveedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.desComprobante = oReader["desComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.desFile = oReader["desFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impSolicitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.impSolicitud = oReader["impSolicitud"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impSolicitud"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSolicitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.codSolicitud = oReader["codSolicitud"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSolicitud"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoSolicitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.SaldoSolicitud = oReader["SaldoSolicitud"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoSolicitud"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fila'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.Fila = oReader["Fila"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Fila"]);

            return  solicitudproveedorrendicion;        
        }

        public SolicitudProveedorRendicionE InsertarSolicitudProveedorRendicion(SolicitudProveedorRendicionE solicitudproveedorrendicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codRendicion", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.codRendicion;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = solicitudproveedorrendicion.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = solicitudproveedorrendicion.idLocal;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = solicitudproveedorrendicion.idSolicitud;
					oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = solicitudproveedorrendicion.fecOperacion;
					oComando.Parameters.Add("@totSoles", SqlDbType.Decimal).Value = solicitudproveedorrendicion.totSoles;
					oComando.Parameters.Add("@totDolares", SqlDbType.Decimal).Value = solicitudproveedorrendicion.totDolares;
                    oComando.Parameters.Add("@MontoAplicado", SqlDbType.Decimal).Value = solicitudproveedorrendicion.MontoAplicado;
                    oComando.Parameters.Add("@Diferencia", SqlDbType.Decimal).Value = solicitudproveedorrendicion.Diferencia;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numDocumento;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = solicitudproveedorrendicion.Glosa;
                    oComando.Parameters.Add("@indDeposito", SqlDbType.Bit).Value = solicitudproveedorrendicion.indDeposito;
                    oComando.Parameters.Add("@idBancoDepo", SqlDbType.Int).Value = solicitudproveedorrendicion.idBancoDepo;
                    oComando.Parameters.Add("@idDocumentoDepo", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idDocumentoDepo;
                    oComando.Parameters.Add("@numSerieDepo", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numSerieDepo;
                    oComando.Parameters.Add("@numDocumentoDepo", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numDocumentoDepo;
                    oComando.Parameters.Add("@fecDepo", SqlDbType.SmallDateTime).Value = solicitudproveedorrendicion.fecDepo;
                    oComando.Parameters.Add("@idMonedaDepo", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idMonedaDepo;
                    oComando.Parameters.Add("@ImporteDepo", SqlDbType.Decimal).Value = solicitudproveedorrendicion.ImporteDepo;
                    oComando.Parameters.Add("@GlosaDepo", SqlDbType.VarChar, 100).Value = solicitudproveedorrendicion.GlosaDepo;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.UsuarioRegistro;

                    oConexion.Open();
                    solicitudproveedorrendicion.idRendicion = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return solicitudproveedorrendicion;
        }
        
        public SolicitudProveedorRendicionE ActualizarSolicitudProveedorRendicion(SolicitudProveedorRendicionE solicitudproveedorrendicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = solicitudproveedorrendicion.idRendicion;
                    oComando.Parameters.Add("@codRendicion", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.codRendicion;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = solicitudproveedorrendicion.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = solicitudproveedorrendicion.idLocal;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = solicitudproveedorrendicion.idSolicitud;
					oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = solicitudproveedorrendicion.fecOperacion;
					oComando.Parameters.Add("@totSoles", SqlDbType.Decimal).Value = solicitudproveedorrendicion.totSoles;
					oComando.Parameters.Add("@totDolares", SqlDbType.Decimal).Value = solicitudproveedorrendicion.totDolares;
                    oComando.Parameters.Add("@MontoAplicado", SqlDbType.Decimal).Value = solicitudproveedorrendicion.MontoAplicado;
                    oComando.Parameters.Add("@Diferencia", SqlDbType.Decimal).Value = solicitudproveedorrendicion.Diferencia;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numDocumento;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = solicitudproveedorrendicion.Glosa;
                    oComando.Parameters.Add("@indDeposito", SqlDbType.Bit).Value = solicitudproveedorrendicion.indDeposito;
                    oComando.Parameters.Add("@idBancoDepo", SqlDbType.Int).Value = solicitudproveedorrendicion.idBancoDepo;
                    oComando.Parameters.Add("@idDocumentoDepo", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idDocumentoDepo;
                    oComando.Parameters.Add("@numSerieDepo", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numSerieDepo;
                    oComando.Parameters.Add("@numDocumentoDepo", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numDocumentoDepo;
                    oComando.Parameters.Add("@fecDepo", SqlDbType.SmallDateTime).Value = solicitudproveedorrendicion.fecDepo;
                    oComando.Parameters.Add("@idMonedaDepo", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idMonedaDepo;
                    oComando.Parameters.Add("@ImporteDepo", SqlDbType.Decimal).Value = solicitudproveedorrendicion.ImporteDepo;
                    oComando.Parameters.Add("@GlosaDepo", SqlDbType.VarChar, 100).Value = solicitudproveedorrendicion.GlosaDepo;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return solicitudproveedorrendicion;
        }        

        public int EliminarSolicitudProveedorRendicion(Int32 idRendicion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<SolicitudProveedorRendicionE> ListarSolicitudProveedorRendicion(Int32 idEmpresa, Int32 idAuxiliar, DateTime fecIni, DateTime fecFin)
        {
            List<SolicitudProveedorRendicionE> listaEntidad = new List<SolicitudProveedorRendicionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAuxiliar", SqlDbType.Int).Value = idAuxiliar;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;

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
        
        public SolicitudProveedorRendicionE ObtenerSolicitudProveedorRendicion(Int32 idRendicion)
        {        
            SolicitudProveedorRendicionE solicitudproveedorrendicion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            solicitudproveedorrendicion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return solicitudproveedorrendicion;
        }

        public String GenerarNumRendicionProveedor(Int32 idEmpresa, Int32 idLocal, Int32 Anio)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumRendicionProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = Convert.ToString(oReader["codRendicion"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public Int32 ActualizarRendicionContaCtaCte(SolicitudProveedorRendicionE solicitudproveedorrendicion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRendicionContaCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = solicitudproveedorrendicion.idRendicion;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = solicitudproveedorrendicion.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = solicitudproveedorrendicion.numVoucher;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = solicitudproveedorrendicion.idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = solicitudproveedorrendicion.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarRendicionEstado(Int32 idRendicion, Boolean Estado, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRendicionEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Decimal SaldoPorIdSolicitud(Int32 idRendicion, Int32 idEmpresa, Int32 idLocal, Int32 idSolicitud)
        {
            Decimal SaldoRetorno = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_SaldoPorIdSolicitud", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;

                    SqlParameter Saldito = new SqlParameter("@Saldo", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Output,
                        Precision = 16,
                        Scale = 2
                    };

                    oComando.Parameters.Add(Saldito);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();

                    SaldoRetorno = Decimal.Parse(oComando.Parameters["@Saldo"].Value.ToString());
                }
            }

            return SaldoRetorno;
        }

        public Int32 ActualizarRendicionContaDepo(SolicitudProveedorRendicionE solicitudproveedorrendicion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRendicionContaDepo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRendicion", SqlDbType.Int).Value = solicitudproveedorrendicion.idRendicion;
                    oComando.Parameters.Add("@AnioDepo", SqlDbType.VarChar, 4).Value = solicitudproveedorrendicion.AnioDepo;
                    oComando.Parameters.Add("@MesDepo", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.MesDepo;
                    oComando.Parameters.Add("@DiarioDepo", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.DiarioDepo;
                    oComando.Parameters.Add("@FileDepo", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.FileDepo;
                    oComando.Parameters.Add("@numVoucherDepo", SqlDbType.VarChar, 9).Value = solicitudproveedorrendicion.numVoucherDepo;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}