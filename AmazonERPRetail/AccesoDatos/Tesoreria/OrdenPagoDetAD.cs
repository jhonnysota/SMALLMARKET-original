using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class OrdenPagoDetAD : DbConection
    {

        public OrdenPagoDetE LlenarEntidad(IDataReader oReader)
        {
            OrdenPagoDetE ordenpagodet = new OrdenPagoDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.idOrdenPago = oReader["idOrdenPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPagoItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.idOrdenPagoItem = oReader["idOrdenPagoItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPagoItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.codTipoPago = oReader["codTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTipoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.idConcepto = oReader["idConcepto"] == DBNull.Value ?0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFormaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.codFormaPago = oReader["codFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFormaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProveedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.idProveedor = oReader["idProveedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProveedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.idMonedaPago = oReader["idMonedaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.MontoPago = oReader["MontoPago"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.TipPartidaPresu = oReader["TipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.CodPartidaPresu = oReader["CodPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Concepto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.Concepto = oReader["Concepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Concepto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.tipCuenta = oReader["tipCuenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.idMonedaBanco = oReader["idMonedaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCtaBancaria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.numCtaBancaria = oReader["numCtaBancaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCtaBancaria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.indPago = oReader["indPago"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAuto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.indAuto = oReader["indAuto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAuto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpagodet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
			//Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.desProveedor = oReader["desProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucProv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.RucProv = oReader["RucProv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucProv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMonedaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.desMonedaBanco = oReader["desMonedaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMonedaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.porDetraccion = oReader["porDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDetraS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.MontoDetraS = oReader["MontoDetraS"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDetraS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDetraD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.MontoDetraD = oReader["MontoDetraD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDetraD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dias'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.Dias = oReader["Dias"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Dias"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.DesPartida = oReader["DesPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpagodet.codOrdenPago = oReader["codOrdenPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenPago"]);

            return  ordenpagodet;        
        }

        public OrdenPagoDetE InsertarOrdenPagoDet(OrdenPagoDetE ordenpagodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenpagodet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordenpagodet.idLocal;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = ordenpagodet.idOrdenPago;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = ordenpagodet.codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = ordenpagodet.idConcepto;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = ordenpagodet.codFormaPago;
                    oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = ordenpagodet.Fecha;
					oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = ordenpagodet.idProveedor;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ordenpagodet.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = ordenpagodet.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ordenpagodet.numDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordenpagodet.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ordenpagodet.Monto;
                    oComando.Parameters.Add("@idMonedaPago", SqlDbType.VarChar, 2).Value = ordenpagodet.idMonedaPago;
                    oComando.Parameters.Add("@MontoPago", SqlDbType.Decimal).Value = ordenpagodet.MontoPago;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = ordenpagodet.TipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = ordenpagodet.CodPartidaPresu;
                    oComando.Parameters.Add("@Concepto", SqlDbType.VarChar, 50).Value = ordenpagodet.Concepto;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = ordenpagodet.Descripcion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ordenpagodet.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ordenpagodet.codCuenta;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = ordenpagodet.idBanco;
                    oComando.Parameters.Add("@tipCuenta", SqlDbType.Int).Value = ordenpagodet.tipCuenta;
                    oComando.Parameters.Add("@idMonedaBanco", SqlDbType.VarChar, 2).Value = ordenpagodet.idMonedaBanco;
                    oComando.Parameters.Add("@numCtaBancaria", SqlDbType.VarChar, 20).Value = ordenpagodet.numCtaBancaria;
                    oComando.Parameters.Add("@indPago", SqlDbType.Bit).Value = ordenpagodet.indPago;
                    oComando.Parameters.Add("@indAuto", SqlDbType.Bit).Value = ordenpagodet.indAuto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordenpagodet.UsuarioRegistro;

                    oConexion.Open();
                    ordenpagodet.idOrdenPagoItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordenpagodet;
        }
        
        public OrdenPagoDetE ActualizarOrdenPagoDet(OrdenPagoDetE ordenpagodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenpagodet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordenpagodet.idLocal;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = ordenpagodet.idOrdenPago;
					oComando.Parameters.Add("@idOrdenPagoItem", SqlDbType.Int).Value = ordenpagodet.idOrdenPagoItem;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = ordenpagodet.codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = ordenpagodet.idConcepto;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = ordenpagodet.codFormaPago;
                    oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = ordenpagodet.Fecha;
					oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = ordenpagodet.idProveedor;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ordenpagodet.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = ordenpagodet.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ordenpagodet.numDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordenpagodet.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ordenpagodet.Monto;
                    oComando.Parameters.Add("@idMonedaPago", SqlDbType.VarChar, 2).Value = ordenpagodet.idMonedaPago;
                    oComando.Parameters.Add("@MontoPago", SqlDbType.Decimal).Value = ordenpagodet.MontoPago;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = ordenpagodet.TipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = ordenpagodet.CodPartidaPresu;
                    oComando.Parameters.Add("@Concepto", SqlDbType.VarChar, 50).Value = ordenpagodet.Concepto;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = ordenpagodet.Descripcion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ordenpagodet.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ordenpagodet.codCuenta;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = ordenpagodet.idBanco;
                    oComando.Parameters.Add("@tipCuenta", SqlDbType.Int).Value = ordenpagodet.tipCuenta;
                    oComando.Parameters.Add("@idMonedaBanco", SqlDbType.VarChar, 2).Value = ordenpagodet.idMonedaBanco;
                    oComando.Parameters.Add("@numCtaBancaria", SqlDbType.VarChar, 20).Value = ordenpagodet.numCtaBancaria;
                    oComando.Parameters.Add("@indPago", SqlDbType.Bit).Value = ordenpagodet.indPago;
                    oComando.Parameters.Add("@indAuto", SqlDbType.Bit).Value = ordenpagodet.indAuto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordenpagodet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordenpagodet;
        }        

        public int EliminarOrdenPagoDet(Int32 idOrdenPago)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenPagoDetE> ListarOrdenPagoDet(Int32 idOrdenPago)
        {
            List<OrdenPagoDetE> listaEntidad = new List<OrdenPagoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

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
        
        public OrdenPagoDetE ObtenerOrdenPagoDet(Int32 idOrdenPago, Int32 idOrdenPagoItem)
        {        
            OrdenPagoDetE ordenpagodet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;
					oComando.Parameters.Add("@idOrdenPagoItem", SqlDbType.Int).Value = idOrdenPagoItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordenpagodet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenpagodet;
        }

        public int ActualizarEstadoOpDet(int idEmpresa, Int32 idLocal, Int32 idOrdenPago, Int32 idProveedor, String idDocumento, String serDocumento, String numDocumento, Boolean indPago, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoOpDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@indPago", SqlDbType.Bit).Value = indPago;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenPagoDetE> ListarOPagoDetCancel(Int32 idOrdenPago)
        {
            List<OrdenPagoDetE> listaEntidad = new List<OrdenPagoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOPagoDetCancel", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

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

        public List<OrdenPagoDetE> ListarOPDetCancelados(Int32 idOrdenPago)
        {
            List<OrdenPagoDetE> listaEntidad = new List<OrdenPagoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOPDetCancelados", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

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

        public OrdenPagoDetE BuscarDocExistenteOp(Int32 idEmpresa, Int32 idLocal, Int32 idOrdenPago, Int32 idProveedor, String idDocumento, String serDocumento, String numDocumento)
        {
            OrdenPagoDetE ordenpagodet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BuscarDocExistenteOp", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordenpagodet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenpagodet;
        }

        public OrdenPagoDetE ObtenerOrdenPagoDetPorDocumento(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, String idDocumento, String serDocumento, String numDocumento)
        {
            OrdenPagoDetE ordenpagodet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenPagoDetPorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordenpagodet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenpagodet;
        }

    }
}