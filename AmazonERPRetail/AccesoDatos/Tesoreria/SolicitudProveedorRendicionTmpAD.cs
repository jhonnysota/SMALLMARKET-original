using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class SolicitudProveedorRendicionTmpAD : DbConection
    {

        public SolicitudProveedorRendicionTmpE LlenarEntidad(IDataReader oReader)
        {
            SolicitudProveedorRendicionTmpE solicitudproveedorrendicion = new SolicitudProveedorRendicionTmpE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSolicitud'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.idSolicitud = oReader["idSolicitud"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSolicitud"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecOperacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numserie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.numserie = oReader["numserie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numserie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idMoneda = oReader["idMoneda"] == DBNull.Value ? "01" : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDoc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.MontoDoc = oReader["MontoDoc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDoc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.idMonedaRec = oReader["idMonedaRec"] == DBNull.Value ? "01" : Convert.ToString(oReader["idMonedaRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoRecibido'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.MontoRecibido = oReader["MontoRecibido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoRecibido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTicaAuto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.indTicaAuto = oReader["indTicaAuto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTicaAuto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedorrendicion.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idAuxiliar = oReader["idAuxiliar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAutomatico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.EsAutomatico = oReader["EsAutomatico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsAutomatico"]);

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
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSolicitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.codSolicitud = oReader["codSolicitud"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSolicitud"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.ctaBanco = oReader["ctaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDepositado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.MontoDepositado = oReader["MontoDepositado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDepositado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.desConcepto = oReader["desConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMonedaRec'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedorrendicion.desMonedaRec = oReader["desMonedaRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMonedaRec"]);

            return  solicitudproveedorrendicion;        
        }

        public SolicitudProveedorRendicionTmpE InsertarSolicitudProveedorRendicion(SolicitudProveedorRendicionTmpE solicitudproveedorrendicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = solicitudproveedorrendicion.idSolicitud;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = solicitudproveedorrendicion.Item;
					oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = solicitudproveedorrendicion.fecOperacion.Date;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idDocumento;
					oComando.Parameters.Add("@numserie", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numserie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numDocumento;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = solicitudproveedorrendicion.fecDocumento.Date;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idMoneda;
                    oComando.Parameters.Add("@MontoDoc", SqlDbType.Decimal).Value = solicitudproveedorrendicion.MontoDoc;
					oComando.Parameters.Add("@idMonedaRec", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idMonedaRec;
					oComando.Parameters.Add("@MontoRecibido", SqlDbType.Decimal).Value = solicitudproveedorrendicion.MontoRecibido;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = solicitudproveedorrendicion.indTicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = solicitudproveedorrendicion.tipCambio;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = solicitudproveedorrendicion.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.codCuenta;
                    oComando.Parameters.Add("@idAuxiliar", SqlDbType.Int).Value = solicitudproveedorrendicion.idAuxiliar;
                    oComando.Parameters.Add("@EsAutomatico", SqlDbType.Bit).Value = solicitudproveedorrendicion.EsAutomatico;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = solicitudproveedorrendicion.idConcepto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return solicitudproveedorrendicion;
        }
        
        public SolicitudProveedorRendicionTmpE ActualizarSolicitudProveedorRendicion(SolicitudProveedorRendicionTmpE solicitudproveedorrendicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = solicitudproveedorrendicion.idSolicitud;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = solicitudproveedorrendicion.Item;
					oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = solicitudproveedorrendicion.fecOperacion.Date;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idDocumento;
					oComando.Parameters.Add("@numserie", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numserie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.numDocumento;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = solicitudproveedorrendicion.fecDocumento.Date;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idMoneda;
                    oComando.Parameters.Add("@MontoDoc", SqlDbType.Decimal).Value = solicitudproveedorrendicion.MontoDoc;
					oComando.Parameters.Add("@idMonedaRec", SqlDbType.VarChar, 2).Value = solicitudproveedorrendicion.idMonedaRec;
					oComando.Parameters.Add("@MontoRecibido", SqlDbType.Decimal).Value = solicitudproveedorrendicion.MontoRecibido;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = solicitudproveedorrendicion.indTicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = solicitudproveedorrendicion.tipCambio;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = solicitudproveedorrendicion.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.codCuenta;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = solicitudproveedorrendicion.idConcepto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = solicitudproveedorrendicion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return solicitudproveedorrendicion;
        }        

        public int EliminarSolicitudProveedorRendicion(Int32 idSolicitud)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<SolicitudProveedorRendicionTmpE> ListarSolicitudProveedorRendicion(Int32 idSolicitud)
        {
            List<SolicitudProveedorRendicionTmpE> listaEntidad = new List<SolicitudProveedorRendicionTmpE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;

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
        
        public SolicitudProveedorRendicionTmpE ObtenerSolicitudProveedorRendicion(Int32 idSolicitud, Int32 Item)
        {        
            SolicitudProveedorRendicionTmpE solicitudproveedorrendicion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSolicitudProveedorRendicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

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

        public List<SolicitudProveedorRendicionTmpE> RendicionImpresion(Int32 idSolicitud)
        {
            List<SolicitudProveedorRendicionTmpE> listaEntidad = new List<SolicitudProveedorRendicionTmpE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RendicionImpresion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;

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