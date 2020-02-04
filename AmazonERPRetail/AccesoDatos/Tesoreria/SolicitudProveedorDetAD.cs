using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class SolicitudProveedorDetAD : DbConection
    {

        public SolicitudProveedorDetE LlenarEntidad(IDataReader oReader)
        {
            SolicitudProveedorDetE solicitudproveedordet = new SolicitudProveedorDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSolicitud'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.idSolicitud = oReader["idSolicitud"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSolicitud"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.indIgv = oReader["indIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.Importe = oReader["Importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indRetencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.indRetencion = oReader["indRetencion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indRetencion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tasa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.Tasa = oReader["Tasa"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Tasa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impImpuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.impImpuesto = oReader["impImpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impImpuesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedordet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.desConcepto = oReader["desConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOpeSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.fecOpeSol = oReader["fecOpeSol"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecOpeSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.idMonedaSol = oReader["idMonedaSol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaCompras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedordet.codCuentaCompras = oReader["codCuentaCompras"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaCompras"]);

            return  solicitudproveedordet;        
        }

        public SolicitudProveedorDetE InsertarSolicitudProveedorDet(SolicitudProveedorDetE solicitudproveedordet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarSolicitudProveedorDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = solicitudproveedordet.idSolicitud;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = solicitudproveedordet.Item;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = solicitudproveedordet.idConcepto;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = solicitudproveedordet.Cantidad;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = solicitudproveedordet.indIgv;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = solicitudproveedordet.porIgv;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = solicitudproveedordet.Igv;
                    oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = solicitudproveedordet.Importe;
					oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = solicitudproveedordet.indDetraccion;
					oComando.Parameters.Add("@indRetencion", SqlDbType.Bit).Value = solicitudproveedordet.indRetencion;
					oComando.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = solicitudproveedordet.Tasa;
					oComando.Parameters.Add("@impImpuesto", SqlDbType.Decimal).Value = solicitudproveedordet.impImpuesto;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = solicitudproveedordet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return solicitudproveedordet;
        }
        
        public SolicitudProveedorDetE ActualizarSolicitudProveedorDet(SolicitudProveedorDetE solicitudproveedordet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarSolicitudProveedorDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = solicitudproveedordet.idSolicitud;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = solicitudproveedordet.Item;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = solicitudproveedordet.idConcepto;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = solicitudproveedordet.Cantidad;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = solicitudproveedordet.indIgv;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = solicitudproveedordet.porIgv;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = solicitudproveedordet.Igv;
                    oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = solicitudproveedordet.Importe;
					oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = solicitudproveedordet.indDetraccion;
					oComando.Parameters.Add("@indRetencion", SqlDbType.Bit).Value = solicitudproveedordet.indRetencion;
					oComando.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = solicitudproveedordet.Tasa;
					oComando.Parameters.Add("@impImpuesto", SqlDbType.Decimal).Value = solicitudproveedordet.impImpuesto;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = solicitudproveedordet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return solicitudproveedordet;
        }        

        public int EliminarSolicitudProveedorDet(Int32 idSolicitud, Int32 Item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarSolicitudProveedorDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<SolicitudProveedorDetE> ListarSolicitudProveedorDet(Int32 idSolicitud)
        {
            List<SolicitudProveedorDetE> listaEntidad = new List<SolicitudProveedorDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSolicitudProveedorDet", oConexion))
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
        
        public SolicitudProveedorDetE ObtenerSolicitudProveedorDet(Int32 idSolicitud, Int32 Item)
        {        
            SolicitudProveedorDetE solicitudproveedordet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSolicitudProveedorDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            solicitudproveedordet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return solicitudproveedordet;
        }

        public List<SolicitudProveedorDetE> ListarSolicitudProveedorDetOp(Int32 idSolicitud)
        {
            List<SolicitudProveedorDetE> listaEntidad = new List<SolicitudProveedorDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSolicitudProveedorDetOp", oConexion))
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